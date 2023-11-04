<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title></title>
    <%: Styles.Render( "~/Content/css") %>
    <%: Scripts.Render("~/bundles/js")%>
    <script type="text/javascript" language="javascript">

        $(function () {
            $('#catalog').combobox({
                url: '/WorkFlow/FlowCatalog/',
                valueField: 'ID',
                textField: 'Name'
            });

            EUIcombobox("#txt_catalog", {
                valueField: "ID",
                textField: "Name",
                OneOption: [{
                    ID: "",
                    Name: "--请选择--"
                }],
                url: "/WorkFlow/FlowCatalog/"
            });

            //添加
            $('#btnAdd').bind('click',
                    function () {
                        $('#FlowEdit').show();
                        $('#FlowEdit').dialog({
                            collapsible: true,
                            minimizable: true,
                            maximizable: true,
                            height: 300,
                            width: 500,
                            modal: true,
                            title: '编辑表单',
                            buttons: [
                            {
                                text: '保存',
                                iconCls: 'icon-ok',
                                handler: function () {
                                    $('#form').form('submit', {
                                        onSubmit: function () {
                                            return $(this).form('validate');
                                        },
                                        success: function (msg) {
                                            var data = eval('(' + msg + ')');
                                            if (data.IsSuccess) {
                                                $.messager.alert('提示', data.Message, 'info', function () {
                                                    $('#FlowEdit').dialog('close');
                                                    $('#grid').datagrid('reload');
                                                });
                                            }
                                            else {
                                                $.messager.alert('提示', data.Message, 'info', function () {
                                                });
                                            }
                                        }
                                    });
                                }
                            },
                            {
                                text: '关闭',
                                iconCls: 'icon-cancel',
                                handler: function () {
                                    $('#FlowEdit').dialog('close');
                                }
                            }]
                        });
                        $("input[name=isInner]:eq(0)").attr("checked", 'checked');

                        $('#id').val('0');
                        $('#name').val('');
                        $('#catalog').combobox('setValue', '');
                        $('#description').val('');
                        $('#url').val('');
                        $('#layouttype').numberbox('setValue', '');
                    }
                );

            //修改
            $('#btnEdit').bind('click',
                    function () {
                        var node = $('#grid').datagrid('getSelected');
                        if (node) {
                            $('#FlowEdit').show();
                            $('#FlowEdit').dialog({
                                collapsible: true,
                                minimizable: true,
                                maximizable: true,
                                height: 300,
                                width: 500,
                                modal: true,
                                title: '编辑表单',
                                buttons: [
                                {
                                    text: '保存',
                                    iconCls: 'icon-ok',
                                    handler: function () {
                                        $('#form').form('submit', {
                                            onSubmit: function () {
                                                return $(this).form('validate');
                                            },
                                            success: function (msg) {
                                                var data = eval('(' + msg + ')');
                                                if (data.IsSuccess) {
                                                    $.messager.alert('提示', data.Message, 'info', function () {
                                                        $('#FlowEdit').dialog('close');
                                                        $('#grid').datagrid('reload');
                                                    });
                                                }
                                                else {
                                                    $.messager.alert('提示', data.Message, 'info', function () {
                                                    });
                                                }
                                            }
                                        });
                                    }
                                },
                                {
                                    text: '关闭',
                                    iconCls: 'icon-cancel',
                                    handler: function () {
                                        $('#FlowEdit').dialog('close');
                                    }
                                }]
                            });

                            $('#id').val(node.ID);
                            $('#name').val(node.Name);
                            $('#catalog').combobox('setValue', node.CatalogID);
                            $('#description').val(node.Description);
                            $('#url').val(node.Url);

                            if (node.IsInner == "是") {
                                $("input[name=isInner]:eq(0)").attr("checked", 'checked');
                            } else {
                                $("input[name=isInner]:eq(1)").attr("checked", 'checked');
                            }

                            if (node.LayoutType == 1) {
                                $("input[name=layouttype]:eq(0)").attr("checked", 'checked');
                            } else if (node.LayoutType == 2) {
                                $("input[name=layouttype]:eq(1)").attr("checked", 'checked');
                            }
                            else {
                                $("input[name=layouttype]:eq(2)").attr("checked", 'checked');
                            }
                        }
                        else {
                            $.messager.alert('提示', '请选择要修改的数据');
                            return;
                        }
                    }
                );
            //删除
            $('#btnDel').bind('click',
                    function () {
                        var rows = $('#grid').datagrid('getSelections');
                        if (!rows || rows.length == 0) {
                            $.messager.alert('提示', '请选择要删除的数据');
                            return;
                        }
                        var parm;
                        $.each(rows, function (i, n) {
                            if (i == 0) {
                                parm = "idList=" + n.ID;
                            }
                            else {
                                parm += "&idList=" + n.ID;
                            }
                        });
                        $.messager.confirm('提示', '是否删除这些数据?', function (r) {
                            if (!r) {
                                return;
                            }

                            $.ajax({
                                type: "POST",
                                url: "/WorkFlow/FlowDelete/",
                                data: parm,
                                success: function (msg) {
                                    if (msg.IsSuccess) {
                                        $.messager.alert('提示', '删除成功！', "info", function () {
                                            $('#grid').datagrid("reload");
                                            $('#grid').datagrid('clearSelections');
                                        });
                                    }
                                },
                                error: function () {
                                    $.messager.alert('错误', '删除失败！', "error");
                                }
                            });
                        });
                    }
            );

            var editFlag = 0; //是否处于编辑状态的标记
            var editIndex = 0; //编辑行

            $('#catalogGrid').datagrid({
                iconCls: 'icon-save',
                nowrap: false,
                striped: true,
                url: '/WorkFlow/FlowCatalogLoad/',
                sortName: 'ID',
                sortOrder: 'asc',
                remoteSort: false,
                width: 1000,
                fit: true,
                fitColumns: true,
                pagination: true,
                rownumbers: true,
                pageNumber: 1,
                pageList: [10, 15, 20],
                pageSize: 15,
                idField: 'ID',
                singleSelect: true,
                frozenColumns: [[
	                { field: 'cb', checkbox: true, align: 'center' }
                    ]],
                columns: [[
                    { field: 'ID', title: '类型ID', width: 100, align: 'center', sortable: "true" },
                    { field: 'Name', title: '名称', width: 100, align: 'center', sortable: "true", editor: { type: 'text', options: { required: true}} },
                    { field: 'Action', title: '操作', width: 80, align: 'center',
                        formatter: function (value, row, index) {
                            if (row.editing) {
                                var s = '<a href="javascript:void(0)" onclick="CheckName(' + index + ')" onfocus=""><img alt="保存" src="../../Content/easyui1.3.3/themes/icons/filesave.png" border="0"/></a>&nbsp;&nbsp;';
                                var c = '<a href="javascript:void(0)" onclick="cancelrow(' + index + ')"><img alt="取消" src="../../Content/easyui1.3.3/themes/icons/undo.png" border="0"/></a>';
                                return s + c;
                            } else {
                                var e = '<a href="javascript:void(0)" onclick="editrow(' + index + ')"><img alt="编辑" src="../../Content/easyui1.3.3/themes/icons/pencil.png" border="0"/></a>&nbsp;&nbsp;';
                                var d = '<a href="javascript:void(0)" onclick="deleterow(' + index + ')"><img alt="删除" src="../../Content/easyui1.3.3/themes/icons/edit_remove.png" border="0"/></a>';
                                return e + d;
                            }
                        }
                    }

                    ]],
                onLoadSuccess: function (data) {
                    var panel = $(this).datagrid('getPanel');
                    var tr = panel.find('div.datagrid-header tr');
                    //修改标题“批次号、库位、生产日期、有效期、数量、单价”的字体颜色
                    tr.each(function () {
                        var td = $(this).children('td[field="Name"]');
                        td.children("div").css({ "color": "#0066CC" });
                    });
                },
                onBeforeEdit: function (index, row) {
                    row.editing = true;
                    updateActions(index);
                },
                onAfterEdit: function (index, row) {
                    row.editing = false;
                    updateActions(index);
                },
                onCancelEdit: function (index, row) {
                    row.editing = false;
                    updateActions(index);
                },
                toolbar: ['-', {
                    id: 'btnAdd-d',
                    text: '添加',
                    iconCls: 'icon-add',
                    handler: function () {
                        $('#catalogGrid').datagrid('appendRow', { ID: 0, Name: "" });
                    }
                }, '-']
            });

            //分类管理
            $('#btnSort').bind('click',
                    function () {
                        $('#sort').show();
                        $('#sort').dialog({
                            collapsible: true,
                            minimizable: true,
                            maximizable: true,
                            height: 440,
                            width: 550,
                            modal: true,
                            onClose: function () {
                                $('#catalogGrid').datagrid('clearSelections');
                                $('#catalog').combobox({ url: '/WorkFlow/FlowCatalog/' });
                                EUIcombobox("#txt_catalog", {
                                    OneOption: [{
                                        ID: "",
                                        Name: "--请选择--"
                                    }],
                                    url: "/WorkFlow/FlowCatalog/"
                                });
                            },
                            buttons: [
                            {
                                text: '关闭',
                                iconCls: 'icon-cancel',
                                handler: function () {
                                    $('#catalogGrid').datagrid('clearSelections');
                                    $('#sort').dialog('close');
                                    $('#catalog').combobox({ url: '/WorkFlow/FlowCatalog/' });
                                    EUIcombobox("#txt_catalog", {
                                        OneOption: [{
                                            ID: "",
                                            Name: "--请选择--"
                                        }],
                                        url: "/WorkFlow/FlowCatalog/"
                                    });
                                }
                            }]
                        });
                    }
            );

            //查询
            $('#btnSearch').bind('click',
                    function () {
                        $('#grid').datagrid('options').url = '/WorkFlow/FlowLoad/?catalogID=' + $('#txt_catalog').combobox('getValue');
                        $('#grid').datagrid("reload");
                    }
               );
        });  

        //#region 分类管理操作
        function updateActions(index) {
            $('#catalogGrid').datagrid('updateRow', { index: index, row: {} });
        }
        function editrow(index) {
            $('#catalogGrid').datagrid('beginEdit', index);
        }  
        function cancelrow(index) {
            $('#catalogGrid').datagrid('cancelEdit', index);
        }
        function deleterow(index) {
            $('#catalogGrid').datagrid('selectRow', index);
            var row = $('#catalogGrid').datagrid('getSelected', index);
            if (row.ID == 0) {
                $('#catalogGrid').datagrid('deleteRow', index);
            }
            else {
                var parm = "id=" + row.ID;

                $.messager.confirm('提示', '是否删除这些数据?', function (r) {
                    if (!r) {
                        return;
                    }

                    $.ajax({
                        type: "POST",
                        url: "/WorkFlow/FlowCatalogDelete/",
                        data: parm,
                        success: function (msg) {
                            if (msg.IsSuccess) {
                                $.messager.alert('提示', msg.Message + '!', "info", function () {
                                    $('#catalogGrid').datagrid("reload");
                                    $('#catalogGrid').datagrid('clearSelections');
                                });
                            }
                            else {
                                $.messager.alert('提示', msg.Message + '!', 'info', function () {
                                });

                            }
                        },
                        error: function () {
                            $.messager.alert('错误', '删除失败！', "error");
                        }
                    });
                });
            }       
        }

        function CheckName(index) {
            $('#catalogGrid').datagrid('endEdit', index);
            var rows = $('#catalogGrid').datagrid('getRows');
            if (rows) {
                for (var i = 0; i < rows.length; i++) {
                    if (i != index && rows[i].Name == rows[index].Name) {
                        $.messager.alert('提示', '名称重复，请重新输入！');
                        return;
                    }
                }
            }
            Save(index);
        }

        function Save(index) {
            var row = $('#catalogGrid').datagrid('getRows')[index];
            var params = 'id=' + row.ID + '&name=' + row.Name;
            $.ajax({
                type: "POST",
                url: "/WorkFlow/FlowCatalogSave/",
                data: params,
                success: function (msg) {
                    var data = eval('(' + msg + ')');
                    if (data.IsSuccess) {
                        $.messager.alert('提示', data.Message + '!', "info", function () {
                            $('#catalogGrid').datagrid({
                                onLoadSuccess: function () {
                                    var panel = $(this).datagrid('getPanel');
                                    var tr = panel.find('div.datagrid-header tr');
                                    tr.each(function () {
                                        var td = $(this).children('td[field="BatchNo"]');
                                        td.children("div").css({ "color": "#0066CC" });
                                    });
                                    $('#catalogGrid').datagrid('selectRow', index);
                                }
                            });
                        });
                    }
                    else {
                        $.messager.alert('提示', data.Message + '!', 'info', function () {
                        });
                    }
                },
                error: function () {
                    $.messager.alert('错误', '保存失败！', "error");
                }
            });
        }
        //#endregion


        function DesignForm(val, row) {
            return "<a href='#' onclick=AddTab('页面布局','/FormDesign/Maintain/?flowId="+row.ID + "','tu1201')><img alt='页面布局' src='../../Content/images/wm.png' border='0'/></a>";
        }


    </script>
</head>
<body class="easyui-layout">
    <div region="center" style="padding: 5px" border="true">
        <table id="grid" class="easyui-datagrid" align="center" toolbar="#tb" url="/WorkFlow/FlowLoad/"
            pagination="true" pagenumber="1" pagelist="[10, 15, 20]" pagesize="15" idfield="ID"
            fitcolumns="true" nowrap="false" striped="true" rownumbers="true" sortname="ID"  singleSelect="true"
            sortorder="asc" remotesort="false" width="1000px" fit="true">
            <thead frozen="true">
                <tr>
                    <th field="ck" width="60" checkbox="true" align='center'>
                    </th>
                </tr>
            </thead>
            <thead>
                <tr>
                    <th field="ID" width="50px" align='center' sortable='true'>
                        表单ID
                    </th>
                    <th field="Name" width="100px" align='center' sortable='true' >
                        表单名称
                    </th>
                    <th field="CatalogID" width="100px" align='center' hidden='true'>
                        表单类别ID
                    </th>
                    <th field="CatalogName" width="100px" align='center' sortable='true'>
                        表单类别
                    </th>
                    <th field="CreateDate" width="100px" align='center' sortable='true'>
                        创建日期
                    </th>
                    <th field="ModifyDate" width="100px" align='center' sortable='true'>
                        修改日期
                    </th>
                    <th field="Url" width="200px" align='center'>
                        默认签核页面
                    </th>
                    <th field="IsInner" width="80px" align='center' sortable='true'>
                        是否内部表单
                    </th>
                    <th field="Description" width="150px" align='center'>
                        备注
                    </th>
                    <th field="Layout" width="60px" align='center' formatter='DesignForm'>
                        表单设计工具
                    </th>

                </tr>
            </thead>
        </table>
    </div>
    <div id="tb" style="padding: 5px; height: auto">
        <table width="100%">
            <tr>
                <td style="width: 50%">
                    <div style="margin-bottom: 5px">
                        <a href="#" id="btnAdd" class="easyui-linkbutton" iconcls="icon-add" plain="true">添加</a>
                        <a href="#" id="btnEdit" class="easyui-linkbutton" iconcls="icon-edit" plain="true">修改</a> 
                        <a href="#" id="btnDel" class="easyui-linkbutton" iconcls="icon-remove" plain="true">删除</a> 
                        <a href="#" id="btnSort" class="easyui-linkbutton" iconcls="icon-wm" plain="true">分类管理</a>
                    </div>
                </td>
                <td>
                    <div>
                        <table width="50%" align="right">
                            <tr>
                                <td>
                                    表单分类:
                                    <select id="txt_catalog" editable="false" style="width: 110px;">
                                    </select>
                                </td>
                                <td width="100px">
                                    <a href="#" id="btnSearch" class="easyui-linkbutton" iconcls="icon-search">查询</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
             </tr>
        </table>
    </div>

    <!--表单编辑-->
    <div id="FlowEdit" icon="icon-save" style="padding: 30px; display: none">
        <form id="form" method="post" action="/WorkFlow/FlowSave/" enctype="application/x-www-form-urlencoded">
            <table>
                <tr style="display: none">
                    <td>
                        <input id="id" type="hidden" name="entity.ID" />
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td style="width: 100px; text-align: right">
                        表单名称(<font color="red">*</font>)：
                    </td>
                    <td style="text-align: left">
                        <input id="name" type="text" name="entity.Name" class="easyui-validatebox" required="true"
                            validtype="length[1,100]" style="width: 105px;" />
                    </td>

                    <td style="width: 100px; text-align: right">
                        表单类别(<font color="red">*</font>)：
                    </td>
                    <td style="text-align: left">
                        <select id="catalog" name="entity.CatalogID" required="true"
                            editable="false" style="width: 110px;">
                        </select>
                    </td>
                </tr>
              <%--  <tr>
                    <td style="width: 100px; text-align: right">
                        创建日期(<font color="red">*</font>)：
                    </td>
                    <td style="text-align: left">
                        <input id="createdate" type="text" name="entity.CreateDate" class="easyui-datebox"
                            required="true" style="width: 110px;" />
                    </td>
                    <td style="width: 100px; text-align: right">
                        修改日期(<font color="red">*</font>)：
                    </td>
                    <td style="text-align: left">
                        <input id="modifydate" type="text" name="entity.ModifyDate" class="easyui-datebox"
                            required="true" style="width: 110px;" />
                    </td>
                </tr>--%>
                <tr style="height: 30px;">
                    <td style="width: 100px; text-align: right">
                        页面布局(<font color="red">*</font>)：
                    </td>
                    <td style="text-align: left">
                        <input type="radio" name="layoutType" value="1" checked />一栏&nbsp;
                        <input type="radio" name="layoutType" value="2" checked />两栏&nbsp;
                        <input type="radio" name="layoutType" value="3" />三栏&nbsp;
                    </td>
                    <td style="width: 100px; text-align: right">
                        内部表单：
                    </td>
                    <td style="text-align: left">
                        <input type="radio" name="isInner" value="Y" checked />是&nbsp;
                        <input type="radio" name="isInner" value="N" />否&nbsp;
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td style="width: 100px; text-align: right">
                        备注：
                    </td>
                    <td style="text-align: left" colspan="3">
                        <input id="description" type="text" class="easyui-validatebox" name="entity.Description"
                            validtype="length[1,255]" style="border: 1px solid #8DB2E3; width: 320px;" />
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td style="width: 100px; text-align: right">
                        默认签核页面：
                    </td>
                    <td style="text-align: left" colspan="3">
                        <input id="url" type="text" class="easyui-validatebox" name="entity.Url" validtype="length[1,255]"
                            style="border: 1px solid #8DB2E3; width: 320px;" />
                    </td>
                </tr>

            </table>
        </form>
    </div>

    <!--表单类型-->
    <div id="sort" style="padding: 5px; height: 250px; display: none" border="true" title="分类管理">
        <table id="catalogGrid" align="center">
        </table>
    </div>
</body>
</html>
