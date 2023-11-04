<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Index</title>
    <%: Styles.Render( "~/Content/css") %>
    <%: Scripts.Render("~/bundles/js")%>
    <script type="text/javascript" language="javascript">
        $(function () {
            $.extend($.fn.validatebox.defaults.rules, {
                //移动手机号码验证
                mobile: {//value值为文本框中的值
                    validator: function (value) {
                        var reg = /^1[3|4|5|8|9]\d{9}$/;
                        return reg.test(value);
                    },
                    message: '输入手机号码格式不准确.'
                },
                //验证工号必须输入5位数
                number: {//value值为文本框中的值
                    validator: function (value) {
                        if (value.length == 5) {
                            var reg = /^\d+$/;
                            return reg.test(value);
                        }
                        return false;
                    },
                    message: '请输入5位数字'
                }
            });
           
            //角色
            $('#role').combobox({
                    url: '/Organize/RoleLoadAll/',
                    valueField: 'ID',
                    textField: 'Name'

                });

            $('#grid_role').datagrid({
                    url: '/Organize/WorkerRoleLoad/?workerId=' + '<%=ViewData["workerId"] %>',
                    singleSelect: true,
                    toolbar: ['-', {
                        id: 'RbtnAdd',
                        text: '添加',
                        iconCls: 'icon-add',
                    }, '-', {
                        id: 'RbtnDel',
                        text: '删除',
                        iconCls: 'icon-remove',
                    },'-']
                });
             
            $("#SyncDM").change(function() {                     
                        
                        if (!$("#SyncDM").attr("checked")) {
                            $("#SyncEmpNo").css('display','none');
                            $('#EmpNo').val('');
                        }else if($("#SyncDM").attr("checked")){
                            $("#SyncEmpNo").css('display','block');
                        }
                    });

            //添加
            $('#RbtnAdd').bind('click',
                    function () {

                        $("#SyncDM").attr("checked",false);
                        $("#SyncEmpNo").css('display','none');

                        $('#WorkerRoleEdit').show();
                        $('#WorkerRoleEdit').dialog({
                             collapsible: true,
                             minimizable: true,
                             maximizable: true,
                             height: 200,
                             width: 250,
                             modal: true,
                             title: '新增角色',
                             buttons: [
                                    {
                                        text: '确定',
                                        iconCls: 'icon-save',
                                        handler: function () {
                                             SaveWorkerRole();  
                                        }
                                    },
                                    {
                                        text: '取消',
                                        iconCls: 'icon-cancel',
                                        handler: function () {
                                            $('#WorkerRoleEdit').dialog('close');
                                        }
                                    }]
                         });
                        $('#role').combobox('clear'); 
                        $('#EmpNo').val('');
                        $('#Rtype').val('add');
                    }
                );

            $('#RbtnDel').bind('click',
                    function () {

                            var row = $('#grid_role').datagrid('getSelected');
                            if (!row) {
                                $.messager.alert('提示', '请选择要删除的数据');
                                return;
                            }

                            var message="是否删除?";
                            
                            if(row.EmpNo != null && row.EmpNo != "")
                            {
                                message="调度系统的相关数据也将删除,是否确认删除?";
                            }

                            $.messager.confirm('提示', message, function (r) {
                                if (!r) {
                                    return;
                                }

                                $.ajax({
                                    type: "POST",
                                    url: "/Organize/WorkerRoleDel/?EmpNo=" +row.EmpNo+"&RoleID=" +row.RoleID + "&Rworkerid=" + <%=ViewData["workerId"] %>,
                                    success: function (msg) {
 
                                        $.messager.alert('提示', msg.Message, "info", function () {
                                            $('#grid_role').datagrid("reload");
                                        });
                                      
                                    },
                                    error: function () {
                                        $.messager.alert('错误', '删除失败！', "error");
                                    }
                                });
                            });
                    }
                );

            //兼职职位
            $('#post_s').combobox({
                url: '/Organize/WorkerPost/',
                valueField: 'ID',
                textField: 'Name'
            });

            //机构
            $('#unit_s').combotree({
                url: '/Organize/UnitTree/'
            });

//            //上级
            $('#manage_s').combobox({
                url: '/Organize/GetAllWorker/',
                valueField: 'ID',
                textField: 'Name'
            });            

            //加载兼职信息
            $('#grid').datagrid({
                    url: '/Organize/WorkerSideline/?workerId=' +　'<%=ViewData["workerId"] %>',
                    singleSelect: true,
                    toolbar: ['-', {
                        id: 'btnAdd',
                        text: '添加',
                        iconCls: 'icon-add',
                        handler: function () {
                            $('#workerId').val('<%=ViewData["workerId"] %>'); 
                            $('#unit_s').combotree('setValue', ''); 
                            $('#post_s').combobox('setValue', '');
                            $('#manage_s').combobox('setValue', '');

                            $('#type').val("add"); 

                            openDialog("新增兼职");
                        }
                    }, '-', {
                        id: 'btnUpdate',
                        text: '修改',
                        iconCls: 'icon-edit',
                        handler: function () {
                            var row = $('#grid').datagrid('getSelected');
                            if (row) {
                                $('#workerId').val('<%=ViewData["workerId"] %>'); 
                                $('#unit_s').combotree('setValue', row.OrgID); 
                                $('#post_s').combobox('setValue',row.PostID);
                                $('#manage_s').combobox('setValue',row.ParentID);

                                $('#type').val("update");
                                $('#update_unit').val(row.OrgID); 

                                openDialog("新增兼职");
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
                            var row = $('#grid').datagrid('getSelected');
                            if (!row) {
                                $.messager.alert('提示', '请选择要删除的数据');
                                return;
                            }
                            $.messager.confirm('提示', '是否删除这些数据?', function (r) {
                                if (!r) {
                                    return;
                                }

                                $.ajax({
                                    type: "POST",
                                    url: "/Organize/WorkerSidelinDelete/?orgId=" + row.OrgID + "&workerId=" + <%=ViewData["workerId"] %>,
                                    success: function (msg) {
                                        if (msg.IsSuccess) {
                                            $.messager.alert('提示', '删除成功！', "info", function () {
                                                $('#grid').datagrid("reload");
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

            })

            function getBackURL()
            {
                return "/Organize/WorkerEdit/?workerId=" + '<%=ViewData["workerId"] %>' + '&type=add';
            }

            //保存角色
            function SaveWorkerRole(){

//                var rows = $('#grid_role').datagrid('getRows');
//                if(rows){
//                    for (var i = 0; i < rows.length; i++) {
//                        if (rows[i].RoleID == $('#role').combobox("getValue")) {
//                            $.messager.alert('提示','角色重复，请重新选择！');
//                            $('#role').focus();
//                            return;
//                        }
//                    }
//                }


                if($("#SyncDM").attr("checked") && !CheckEmpNo($('#EmpNo').val()))
                {
                    $.messager.alert('提示','工号请输入5位数字');
                    $('#EmpNo').focus();
                    return;
                }

                $.ajax({
                    type: "POST",
                    async:false,
                    url: "/Organize/IsExistEmpNo/?empNo=" + $('#EmpNo').val(),
                    success: function (msg) {
                        if (msg.IsSuccess) {
                            $.messager.alert('提示', '已存此工号');
                                $('#EmpNo').focus();
                                return;
                        }
                        else
                        {
                            $('#Rform').form('submit', {
                                onSubmit: function () {
                                    return $(this).form('validate') ;
  
                                },
                                success: function (msg) {
                                    var data = eval('(' + msg + ')');
                                    if (data.IsSuccess) {
                                        $.messager.alert('提示', data.Message, 'info', function () {
                                            $('#Rtype').val('');
                                            $('#OldEmpNo').val('');
                                            $('#WorkerRoleEdit').dialog('close');
                                            $('#grid_role').datagrid('reload');
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
                    error: function () {
                        $.messager.alert('错误', '检查工号失败！', "error");
                    }
                });
 
            }

            //兼职信息弹出框
            function openDialog(title){

                $('#SidelineEdit').show();
                $('#SidelineEdit').dialog({
                    collapsible: true,
                    minimizable: true,
                    maximizable: true,
                    height: 400,
                    width: 500,
                    modal: true, //阴影（弹出会影响页面大小）
                    title: title,
                    onClose: function () {
                        $('#grid').datagrid("reload");
                    },
                    buttons: [{
                        text: '保存',
                        iconCls: 'icon-save',
                        handler: function () {
                            $('#form_s').form('submit', { 
                                onSubmit: function () {
                                    return $(this).form('validate');
                                },
                                success: function (msg) {
                                    var data = eval('(' + msg + ')'); 
                                    if(data.IsSuccess)
                                    {
                                        $.messager.alert('提示', data.Message, 'info', function(){
                                            $('#SidelineEdit').dialog('close');
                                            $('#grid').datagrid("reload");
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
                    },
                    {
                        text: '取消',
                        iconCls: 'icon-cancel',
                        handler: function () {
                            $('#SidelineEdit').dialog('close');
                        }
                    }]
                });         
            }

         function CheckEmpNo(value) {
            if (value.length == 5) {
                var reg = /^\d+$/;
                return reg.test(value);
            }
            return false;
        }                           
    </script>
</head>
<body class="easyui-layout">
    <div region="center" border="true" >
       <form id="form" method="post"  enctype="application/x-www-form-urlencoded">
            <table>
                <tr>
                    <td colspan=2>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: right; vertical-align: top">
                        角色：
                    </td>
                    <td>
                        <div region="center" style="width: 400px;" border="true">
                            <table id="grid_role" class="easyui-datagrid" align="center" nowrap="false"
                                striped="true" rownumbers="true" " remotesort="false"
                                singleselect="true" height="200" fitcolumns="true">
                                <thead frozen="true">
                                    <tr>
                                        <th field="RoleID" checkbox="true" align='center'>
                                            RoleID
                                        </th>
                                    </tr>
                                </thead>
                                <thead>
                                    <tr>
                                        <th field="RoleName" width="50" align='center'>
                                            角色
                                        </th>
                                        <th field="EmpNo" width="50" align='center'>
                                            调度系统工号
                                        </th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; vertical-align: top">
                        兼职：
                    </td>
                    <td colspan="6">
                        <div region="center" style="width:400px;" border="true">
                            <table id="grid" class="easyui-datagrid" align="center"  idfield="OrgID"
                                nowrap="false" striped="true" rownumbers="true" sortname="OrgID" sortorder="asc"
                                remotesort="false" singleselect="true" height="200" fitcolumns="true">
                                <thead frozen="true">
                                    <tr>
                                        <th field="OrgID" checkbox="true" align='center'>
                                            OrgID
                                        </th>
                                    </tr>
                                </thead>
                                <thead>
                                    <tr>
                                        <th field="OrgName" width="50" align='center'>
                                            机构
                                        </th>
                                        <th field="PostID" align='center' hidden=true'>
                                            职位ID
                                        </th>
                                        <th field="Post" width="50" align='center'>
                                            职位
                                        </th>
                                        <th field="ParentID"  align='center' hidden='true'>
                                            上级ID
                                        </th>
                                        <th field="Parent" width="50" align='center'>
                                            上级
                                        </th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </td>
                </tr>   
            </table>
            </form>
    </div>
    <div region="south" border="true" style="text-align: right; height: 40px; line-height: 30px;
        background-color: #f7f7f7;">
        <table style="width: 100%">
            <tr>
                <td style="text-align: LEFT">
                    <a href="#" class="easyui-linkbutton" iconcls="icon-back" onclick="location.href = getBackURL();">上一步</a>
                    <a href="#" class="easyui-linkbutton" iconcls="icon-ok" onclick="CloseCurrentTab();">完成</a>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <!--兼职信息编辑-->
    <div id="SidelineEdit" icon="icon-save" style="padding: 5px; display: none">
        <div region="center" border="true" style="margin-top: 25px">
            <form id="form_s" method="post" action="/Organize/WorkerSidelineSave/" enctype="application/x-www-form-urlencoded">
            <table>
                <tr style="display: none">
                    <td>
                        <input id="workerId" type="hidden" name="entity.WorkerID" />
                        <input id="type" type="hidden" name="type" />
                        <input id="update_unit" type="hidden" name="update_unit" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%; text-align: right">
                        机构(<font color="red">*</font>)：
                    </td>
                    <td style="width: 15%; text-align: left">
                        <select id="unit_s" class="easyui-combotree" name="entity.OrgID" required="true"
                            style="width: 150px;">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%; text-align: right">
                        职位(<font color="red">*</font>)：
                    </td>
                    <td style="width: 15%; text-align: left">
                        <select id="post_s" class="easyui-combobox" required="true" name="entity.PostID"
                            style="width: 150px;">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%; text-align: right">
                        上级(<font color="red">*</font>)：
                    </td>
                    <td style="width: 15%; text-align: left">
                        <select id="manage_s" class="easyui-combobox" required="true" name="entity.ParentID"
                            style="width: 150px;">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%; text-align: right">
                        备注：
                    </td>
                    <td style="width: 15%; text-align: left">
                        <input id="remark" type="text" class="easyui-validatebox" name="entity.Remark" validtype="length[1,255]"
                            style="border: 1px solid #8DB2E3; width: 146px; height: 18px" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>

    <!--人员角色-->
    <div id="WorkerRoleEdit" icon="icon-save" style="padding: 5px; display: none">
        <div region="center" border="true" style="margin-top: 25px">
            <form id="Rform" method="post" action="/Organize/WorkerRoleSave/" enctype="application/x-www-form-urlencoded">
            <table>
                <tr style="display: none">
                    <td>
                        <input id="Rtype" name="Rtype" type="hidden" />
                        <input id="OldEmpNo" name="OldEmpNo" type="hidden" />
                        <input id="Rworkerid" name="Rworkerid" type="hidden" value="<%=ViewData["workerId"] %>" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; text-align: right">
                        角色(<font color="red">*</font>)：
                    </td>
                    <td style="text-align: left">
                        <select id="role" class="easyui-combobox" name="RoleID" required="true" style="width: 125px;">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; text-align: right">
                        同步调度系统：
                    </td>
                    <td style="text-align: left">
                        <input type="checkbox" id="SyncDM" />
                    </td>
                </tr>
                <tr  id="SyncEmpNo" style="display: none">
                    <td style="width: 100px; text-align: right">
                        工号(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input id="EmpNo" type="text" name="EmpNo"  style="border: 1px solid #8DB2E3; width: 119px;" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
</body>
</html>
