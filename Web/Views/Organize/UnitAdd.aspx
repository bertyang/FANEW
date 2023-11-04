<%@ Page Title="" Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>单位信息</title>
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
                            window.parent.location.href = "../Unit";
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
                    url: '/Organize/UnitTree/',
                    onLoadSuccess: function (data) {
                        $('#unit').combotree('setValue', <%=ViewData["unit"]%>);
                    }
                });
                
                $('#manager').combobox({
                        url: '/Organize/GetAllWorker/',
                        valueField: 'ID',
                        textField: 'Name',
                        onLoadSuccess: function (data) {
                        $('#manager').combobox('setValue', '');
                    }
                });

                $('#type').combobox({
                        url: '/Organize/UnitType/',
                        valueField: 'Value',
                        textField: 'Name'//,
//                        onLoadSuccess: function (data) {
//                        $('#type').combobox('setValue', <%=ViewData["type"]%>);
//                    }
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

    </script>
</head>
<body class="easyui-layout">
    <div region="center" border="false">
        <div region="north" style="margin-left:45px;margin-top:20px">
            <span class="editTitle">编辑单位</span>
        </div>
        <div region="center">
            <form id="form" method="post" action="/Organize/UnitSave/" enctype="application/x-www-form-urlencoded">
            <table width="100%">
                <tr>
                    <td style="text-align: right; width: 120px;">
                        名称(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" required="true" name="entity.Name"
                            validtype="length[1,40]" style="border: 1px solid #8DB2E3; width: 146px; height: 18px" />
                    </td>
                </tr>
               <%-- <tr style="display:none">
                    <td style="text-align: right; width: 120px;">
                        机构代码(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" name="entity.ID" />
                    </td>
                </tr>--%>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        上级机构(<font color="red">*</font>)：
                    </td>
                    <td>
                        <select id="unit"  class="easyui-combotree"  required="true" name="entity.ParentID"  style="width:150px;"></select>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        负责人(<font color="red">*</font>)：
                    </td>
                    <td>
                        <select id="manager" editable="false" class="easyui-combobox"  required="true" name="entity.ManagerID"   style="width:150px;"></select>
                    </td>
                </tr>
<%--                <tr>
                    <td style="text-align: right; width: 120px;">
                        机构层级(<font color="red">*</font>)：
                    </td>
                    <td>
                        <input type="text" class="easyui-numberbox" required="true" missingMessage="必须填写数字" name="entity.Level" validType="length[1,11]" style="width:145px;"
                             />
                    </td>
                </tr>--%>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        机构类别(<font color="red">*</font>)：
                    </td>
                    <td>
                        <select id="type"  editable="false" class="easyui-combobox"  required="true" name="entity.Type"  style="width:150px;"/>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        地址：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" name="entity.Address" validtype="length[1,50]"
                            style="border: 1px solid #8DB2E3; width: 146px; height: 18px" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 120px;">
                        电话：
                    </td>
                    <td>
                        <input type="text" class="easyui-validatebox" validtype="phone" name="entity.Tel"
                            validtype="length[1,11]" style="border: 1px solid #8DB2E3; width: 146px; height: 18px" />
                    </td>
                </tr>
            </table> 
            </form>
        </div>
    </div>
    <div region="south" border="true" style="text-align: right; height: 40px; line-height: 30px;
        background-color: #f7f7f7;">
        <table style="width: 100%">
            <tr>
                <td>
                </td>
                <td style="text-align: LEFT">
                    <a href="#" class="easyui-linkbutton" iconcls="icon-save" onclick="submit();">提交</a>
                    <a href="#" class="easyui-linkbutton" iconcls="icon-cancel" onclick="location.href = document.referrer;">取消</a>

                </td>
            </tr>
        </table>
    </div>
</body>
</html>
