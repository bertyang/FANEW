<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PositionInfo</title>
    <%: Styles.Render( "~/Content/css") %>
    <%: Scripts.Render("~/bundles/js")%>
    <script language="javascript" type="text/javascript">

        function submit() {
            $('#form').form('submit', {
                onSubmit: function () {
                    return $(this).form('validate');
                },
                success: function (msg) {
                    var data = eval('(' + msg + ')'); 
                    if(data.IsSuccess)
                    {
                        $.messager.alert('提示', data.Message, 'info', function(){
                            //window.parent.location.href = "../Unit";
                        });
                    }
                    else
                    {
                        $.messager.alert('提示', data.Message, 'info', function(){
                        });

                    }
                }
            });
        }

        $(document).ready(function () {
                $('#unit').combotree({
                    url: '/Organize/UnitTree/?exceptUnitId='+'<%=ViewData["UnitId"]%>',
                    onLoadSuccess: function (data) {
                        $('#unit').combotree('setValue', <%=ViewData["ParentUnitId"]%>);
                    }
                });
                
//                $('#manager').combobox({
//                        url: '/Organize/GetAllWorker/',
//                        valueField: 'ID',
//                        textField: 'Name',
//                        onLoadSuccess: function (data) {

//                        <% if(ViewData["ManagerId"]!=null){%>
//                            $('#manager').combobox('setValue', <%=ViewData["ManagerId"]%>);
//                        <%}%>
//                    }
//                });

                $('#type').combobox({
                        url: '/Organize/UnitType/',
                        valueField: 'Value',
                        textField: 'Name',
                        onLoadSuccess: function (data) {
                        $('#type').combobox('setValue', <%=ViewData["Type"]%>);
                    }
                });

                //验证电话
                $.extend($.fn.validatebox.defaults.rules, {
                    phone : {
                        validator : function(value) {
                            var reg = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/; 
                            return reg.test(value);
                        },
                        message : '电话格式不正确,正确格式:0571-88888888'
                     }
            });
        });

        function del(id) {
            if ('<%=ViewData["worker"]%>' == 1) {
                $.messager.alert('提示', '该部门还有人员存在！');
                return;
            }
            if ('<%=ViewData["post"]%>' == 1) {
                $.messager.alert('提示', '该部门还有职位存在！');
                return;
            }
            if ('<%=ViewData["storehouse"]%>' == 1) {
                $.messager.alert('提示', '该部门还有库房存在！');
                return;
            }

            var message = '是否删除这些数据?';

            if('<%=ViewData["Type"]%>'==3)
            {
                message = '调度系统对应分站也将删除，是否删除这些数据?';
            }
            $.messager.confirm('提示', message, function (result) {
                if (!result) {return;}               

                $.ajax({
                    type: "POST",
                    url: "/Organize/UnitDelete/" + id,
                    dataType: "json",
                    success: function (msg) {
                        if (msg.IsSuccess) {
                            $.messager.alert('提示', '删除成功！', "info", function () {
                                window.parent.location.href = "../Unit";
                            });
                        }
                        else {
                            $.messager.alert('提示', '请先删除其子节点！', "info", function () {
                            });
                        }

                    },
                    error: function () {
                        $.messager.alert('错误', '删除失败！', "error");
                    }
                });

            }); 
       }

        function selectWorkers() {
            $('#worker').datagrid({
                url: '/Organize/WorkerLoad/'
            });

            //弹出选择框
            $('#WorkerDiv').show();
            $('#WorkerDiv').dialog({
                collapsible: true,
                minimizable: true,
                maximizable: true,
                height: 450,
                width: 700,
                modal: true, //阴影（弹出会影响页面大小）
                title: '选择人员',
                buttons: [{
                    text: '确定',
                    iconCls: 'icon-ok',
                    handler: function () {

                        var rows = $('#worker').datagrid('getSelected');

                        if (rows) {
                                $("#managerId").val(rows.ID);
                                $("#managerName").val(rows.Name);   
                        }

                        $('#WorkerDiv').dialog('close');
                        $('#worker').datagrid('clearSelections');
                        $('#txtName').val("");
                        $('#role_sel').combobox('setValue', "--请选择--");
                    }
                },
                    {
                        text: '取消',
                        iconCls: 'icon-cancel',
                        handler: function () {
                            $('#WorkerDiv').dialog('close');
                            $('#worker').datagrid('clearSelections');
                            $('#txtName').val("");
                            $('#role_sel').combobox('setValue', "--请选择--");
                        }
                    }]
            });

            //组织机构树
            $(function () {
                $('#tree').tree({
                    url: '/Organize/WorkerTree/',

                    onClick: function (node) {

                        var urlw = "/Organize/WorkerLoad/?orgId=" + node.id;
                        $('#worker').datagrid({
                            url: urlw
                        });
                        $('#orgId').val(node.id);
                    }
                });

                $('#btnSearch').bind('click',
                        function () {
                            $('#worker').datagrid('options').url = '/Organize/WorkerLoad/?Name=' + escape($('#txtName').val())
                                + '&orgId=' + $('#orgId').val()
                                + '&roleId=' + $("#role_sel").combobox('getValue');
                            $('#worker').datagrid("reload");
                        }
                );

            
                $('#role_sel').combobox({
                    url: '/Organize/RoleLoadAll/',
                    valueField: 'ID',
                    textField: 'Name',
                    onLoadSuccess: function (data) {
                        $('#role_sel').combobox('setValue', "--请选择--");
                    }
                });
            });
        }
    </script>
</head>
<body class="easyui-layout">
    <!--编辑页面-->
    <div region="center" border="false">
        <div region="north" style="margin-left:45px;margin-top:20px">
            <span class="editTitle">单位信息</span>
        </div>
        <div region="center">
            <form id="form" method="post" action="/Organize/UnitSave/" enctype="application/x-www-form-urlencoded">
            <table style="width: 100%">
                <tr>
                    <td style="text-align: right; width: 120px;">
                        名称(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" validtype="length[1,40]" required="true"
                            name="entity.Name" validtype="length[1,40]" value="<%= ((dynamic)this.ViewData["B_ORGANIZATION"]).Name %>"
                            style="border: 1px solid #8DB2E3; width: 146px; height: 18px" />
                    </td>
                </tr>

                <tr style="display:none">
                    <td style="text-align: right; width: 120px;">
                        机构代码(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" required="true" name="entity.ID" value="<%= ((dynamic)this.ViewData["B_ORGANIZATION"]).ID %>"
                            style="border: 1px solid #8DB2E3; width: 145px; height: 18px" />
                    </td>
                </tr>
                <%if (((dynamic)this.ViewData["B_ORGANIZATION"]).ParentID != 0)
                  { %>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        上级机构(<font color="red">*</font>)：
                    </td>
                    <td>
                        <select id="unit"  class="easyui-combotree" required="true" name="entity.ParentID"  style="width:150px;"></select>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        负责人(<font color="red">*</font>)：
                    </td>
                    <td>
                        <%--<select id="manager"  editable="false" required="true"  class="easyui-combobox"  name="entity.ManagerID" style="width:150px;"></select>--%>
                        <input id="managerId" type="text"  name="entity.ManagerID"  style="display: none"  value="<%=ViewData["ManagerId"]%>" />
                        <input id="managerName" type="text" required="true" readonly="true" 
                         class="easyui-validatebox" style="border: 1px solid #8DB2E3; width: 146px; "
                         value="<%=ViewData["ManagerName"]%>"/>
                        <a href="#" class="easyui-linkbutton" iconcls="icon-ok" onclick="selectWorkers();">选择</a>
                    </td>
                </tr>
<%--                <tr>
                    <td style="text-align: right; width: 120px;">
                        机构层级(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-numberbox" required="true" missingMessage="必须填写数字" 
                           name="entity.Level"  validType="length[1,11]"
                            value="<%= ((dynamic)this.ViewData["B_ORGANIZATION"]).Level %>" style="width:145px;"/>
                    </td>
                </tr>--%>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        机构类别(<font color="red">*</font>)：
                    </td>
                    <td>
                        <select id="type" disabled=true class="easyui-combobox"  required="true" name="entity.Type"  style="width:150px;"/>
                    </td>
                </tr>
<%--                <tr>
                    <td style="text-align: right; width: 120px;">
                        地址：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" name="entity.Address" validtype="length[1,50]"
                            value="<%= ((dynamic)this.ViewData["B_ORGANIZATION"]).Address==null?"":((dynamic)this.ViewData["B_ORGANIZATION"]).Address %>"
                            style="border: 1px solid #8DB2E3; width: 146px; height: 18px" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        电话：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" validtype="phone" name="entity.Tel"
                            validtype="length[1,13]" value="<%= ((dynamic)this.ViewData["B_ORGANIZATION"]).Tel ==null?"":((dynamic)this.ViewData["B_ORGANIZATION"]).Tel%>"
                            style="border: 1px solid #8DB2E3; width: 146px; height: 18px" />
                    </td>
                </tr>--%>
            </table>
            </form>
        </div>
    </div>
    <!--工具条-->
    <div region="south" border="true" style="text-align: right; height: 40px; line-height: 30px;
        background-color: #f7f7f7;">
        <table style="width: 100%">
            <tr>
                <td style="text-align: LEFT">
                    <a href="#" class="easyui-linkbutton" iconcls="icon-save" onclick="submit();">提交</a>
                      <%= Html.ActionLink("新建", "UnitAdd", new { id = ((dynamic)this.ViewData["B_ORGANIZATION"]).ID }, new { @class = "easyui-linkbutton", iconcls = "icon-add" })%>
                    <a href="#" class="easyui-linkbutton" iconcls="icon-remove" onclick="del(<%= ((dynamic)this.ViewData["B_ORGANIZATION"]).ID %>)">删除</a>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <!--选人窗口-->
    <div id="WorkerDiv" icon="icon-save" style="overflow: hidden; padding: 5px; display: none">
        <div class="easyui-layout" icon="icon-save" style="padding: 5px; width: 100%; height: 100%;">
            <div region="west" split="true" title="组织机构" iconcls="icon icon-sys" style="width: 180px;"
                id="west">
                <ul id="tree" line="true">
                </ul>
            </div>
            <div region="center">
                <table  id="worker" class="easyui-datagrid" align="center" title="人员" pagination="true"
                    pagenumber="1" pagelist="[10, 15, 20]" pagesize="15" idfield="ID" nowrap="false"
                    striped="true" rownumbers="true" sortname="ID" sortorder="asc" toolbar="#tb"
                    remotesort="false" width="300" fit="true" fitcolumns="true" singleSelect="true">
                    <thead>
                        <tr>
                            <th field="ID" width="60" checkbox="true" align='center'>
                                Item ID
                            </th>
                            <th field="Name" width="80" align='center'>
                                姓名
                            </th>
                        </tr>
                    </thead>
                </table>
            </div>
            <div id="tb"  style="padding: 5px; height: auto">
                <table  width="100%">
                    <tr>
                        <td  width="40%">
                            姓名:
                            <input id="txtName" class="easyui-validatebox" style="border: 1px solid #8DB2E3;
                                width: 81px; height: 18px" />
                        </td>
                        <td  width="40%">
                            角色:
                            <select id="role_sel"  class="easyui-combobox"  style="width:100px;">
                            </select>
                        </td>
                        <td  width="20%">
                            <input type="hidden" id="orgId"/>
                            <a href="#" id="btnSearch" class="easyui-linkbutton" iconcls="icon-search">查询</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</body>
</html>
