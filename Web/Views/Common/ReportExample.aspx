<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>ReportExample</title>
    <%: Styles.Render( "~/Content/css") %>
    <%: Scripts.Render("~/bundles/js")%>
    <script type="text/javascript" language="javascript">
        function print() {
            //通用代码，防止连击按钮
            $('#btnSearch').attr("disnable", "false");

            //根据报表不同修改
            var modelFile = 'testReport.xls';
            var dsFile = 'testReport.ds';
            var paramNames = 'paramNames=workerID&paramNames=startTime&paramNames=status';
            var paramValues = 'paramValues=' + escape($('#workerId').combobox('getValue'));
            paramValues = paramValues + '&paramValues=' + escape($('#startTime').datebox('getValue'));
            paramValues = paramValues + '&paramValues=' + escape($('#status').combobox('getValue'));

            //通用代码
            var parm = 'modelFile=' + modelFile + '&dsFile=' + dsFile + "&" + paramNames + '&' + paramValues;
            $.ajax({
                type: "POST",
                url: "/Common/CreateExcelReport/",//根据你自己的报表修改
                data: parm,
                success: function (msg) {
                    $('#FramePrint').attr("src", msg);
                },
                error: function () {
                    $.messager.alert('错误', '数据装载失败！', "error");
                }
                        });
                        
            $('#btnSearch').attr("disnable", "true");
        }

        $(document).ready(function () {
            //查询
            $('#btnSearch').bind('click',
                    function () {
                        print();
                    }
               );
        });
    </script>
</head>
<body class="easyui-layout">
    <div region="north" style="height:30px">  
        <form>
            库管员: <select id="workerId"  class="easyui-combobox" style="width:90px"> </select> 
            创建时间起点: <input id="startTime" editable="false" class="easyui-datebox" value="<%=this.ViewData["StartTime"] %>" style="width:90px">  
            状态: <select id="status" name="status" class="easyui-combobox" style="width:90px;">   
                        <option value="C" selected="selected">未送审</option>   
                        <option value="A">已送审</option>    
                        <option value="Y">审核通过</option>   
                        <option value="N">审核未通过</option> 
                    </select>  
            <a href="#" id="btnSearch" class="easyui-linkbutton" iconCls="icon-search" >查询</a>
        </form>
    </div>
    <div region="center"> 
        <iframe id="FramePrint" width="100%" height="100%" allowtransparency="true" style="background-color=transparent"></iframe>
    </div>
</body>
</html>
