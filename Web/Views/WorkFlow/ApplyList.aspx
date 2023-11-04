<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<List<Anchor.FA.Model.F_FLOW>>" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>ApplyList</title>
    <%: Styles.Render( "~/Content/css") %>
    <%: Scripts.Render("~/bundles/js")%>
    <script language="javascript" type="text/javascript">

        function Open(src) {

            $('#main').attr("src", src);
            $('#form').show();
            $('#form').dialog({
                collapsible: true,
                minimizable: true,
                maximizable: true,
                height: 500,
                width: 800,
                modal: true, //阴影（弹出会影响页面大小）
                title: '申请表单'
            });
        }
    </script>
</head>
<body class="easyui-layout">
    <div region="center" style="padding: 5px" border="true">
            <%foreach(var item in Model) {%>
                 <a href='#' onclick="Open('/WorkFlow/Apply/?flowId=<%=item.ID%>')"><u><%=item.Name%></u></a><P>
            <%}%>
    </div>
    <div id="form" icon="icon-save" style="padding: 0px; overflow:hidden;">
         <iframe name="main" id="main" height="100%" width="100%"   marginheight="0" marginwidth="0" frameborder="0"></iframe>
    </div>  
</body>
</html>
