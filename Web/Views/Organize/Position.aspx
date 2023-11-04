<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <%: Styles.Render( "~/Content/css") %>
    <%: Scripts.Render("~/bundles/js")%>
        <script type="text/javascript" language="javascript">
            $(function () {
                $('#grid').datagrid({
                    iconCls: 'icon-save',
                    nowrap: false,
                    striped: true,
                    url: '/Organize/PositionLoad/',
                    sortName: 'ID',
                    sortOrder: 'asc',
                    remoteSort: false,
                    fitColumns: true,  //自适应列宽
                    fit: true,
                    pagination: true,  //分页工具栏
                    pageNumber: 1,
                    pageList: [10, 15, 20],
                    pageSize: 15,  
                    rownumbers: true,
                    idField: 'ID',
                    frozenColumns: [[
	                { field: 'ID', checkbox: true, align: 'center' }
				    ]],

                    columns: [[
                    { field: 'Name', title: '职位名称', width: 80, align: 'center' },
                    { field: 'Level', title: '职位层级', width: 80, align: 'center' }
                    ]],

                    toolbar: ['-', {
                        id: 'btnAdd',
                        text: '添加',
                        iconCls: 'icon-add',
                        handler: function () {
                            this.href = "/Organize/PositionEdit/";
                        }
                    }, '-', {
                        id: 'btnUpdate',
                        text: '修改',
                        iconCls: 'icon-edit',
                        handler: function () {
                            var row = $('#grid').datagrid('getSelected');
                            if (row) {
                                this.href = "/Organize/PositionEdit/?id=" + row.ID;
                            }
                            else {
                                $.messager.alert('提示', '请选择要修改的数据');
                                return;
                            }

                        }

                    }, '-', {
                        id: 'btnDelete',
                        text: '删除',
                        disabled: false,
                        iconCls: 'icon-remove',
                        handler: function () {
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
                                    url: "/Organize/PositionDelete/",
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
                    }, '-']
                });
                $("#btnSave").attr("href", "/Organize/Position/");
            });        
        </script>
</head>
<body class="easyui-layout">
    <div region="center" style="padding: 5px" border="true" > 
        <table id="grid" align="center"  >
        </table>
    </div>
</body>
</html>

