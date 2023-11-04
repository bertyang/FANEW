<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <%: Styles.Render( "~/Content/css") %>
    <%: Scripts.Render("~/bundles/js")%>
    <script type="text/javascript" language="javascript">
       
        //页面初始化
        $(document).ready(function () {
            //办公类型
            $('#infoType').combobox({
                url: '/Office/OfficeType/',
                valueField: '编码',
                textField: '名称',
                onLoadSuccess: function (data) {
                    $('#infoType').combobox('setValue', '<%=ViewData["type"]%>');
                }
            });

            $('#grid').datagrid({
                url: '/Office/OfficeSearch/?type=' + '<%=ViewData["type"] %>' + '&startTime=' + '<%=ViewData["startTime"] %>' + '&endTime=' + '<%=ViewData["endTime"] %>'
            });
        });

        //查询
        function doSearch() {
            $('#grid').datagrid('load', {
                startTime: $("#startTime").datetimebox('getText'),
                endTime: $('#endTime').datetimebox('getText'),
                type: $('#infoType').combobox('getValue'),
                title: $('#title').val(),
                writer: $('#writer').val()
            });
        }

        //格式化“查看”
        function formatCharge(val, rec) {

            return "<a href='/Office/OfficeDetail/?officeId=" + rec.ID + "'><img alt='查看' src='../../Content/images/find.gif' border='0'/></a>";

        }
    </script>
</head>
<body class="easyui-layout">
    <div region="center" style="padding: 5px" border="true" > 
         <table id="grid" class="easyui-datagrid" align="center"  toolbar="#tb" url="/Office/OfficeSearch/"
             pagination="true"  pageNumber=1 pageList= "[10, 15, 20]" pageSize=15  
             nowrap="false" striped="true" rownumbers="true"
             sortName="CreateTime" sortOrder= "desc" remoteSort="false" fit="true" fitColumns="true" onclick="onDblClickRow"
             >
                <thead>
			        <tr>
                        <%--<th field="AttachmentNum" width="100"  align='center'>附件个数</th>--%>
                        <th field="Title" width="100"  align='center'>标题</th>
                        <th field="Writer" width="100"  align='center'>作者</th>
                        <th field="CreateTime" width="100"  align='center'>创建时间</th>
                        <th field="SendType" width="100"  align='center'>发送类型</th>
                        <%--<th field="ReadNum" width="100"  align='center'>阅读人数</th>--%>
                        <th field="ID" width="100" align='center' formatter="formatCharge">查看</th>   
			        </tr>
		        </thead>
            </table>  
      </div>
      <div id="tb" style="padding:5px;height:auto; margin-top:3px" >     
            <table border="0" cellspacing="0" cellpadding="0" width="100%" height="10%">
                <tr>
                    <td width="5%"></td>
                    <td width="8%">起始时刻: </td>
                    <td><input id="startTime" type="text" class="easyui-datetimebox" value="<%= ((dynamic)this.ViewData["startTime"]) %>"
                            style="width: 150px;" /></td>
                    <td width="8%">终止时刻: </td>
                    <td><input id="endTime" type="text" class="easyui-datetimebox"  value="<%= ((dynamic)this.ViewData["endTime"]) %>" style="width:150px;"/></td>
                    <td width="8%">办公类型：</td>
                    <td>
                        <select id="infoType" class="easyui-combobox" name="infoType" style="width: 150px;">
                        </select>
                    </td>
                </tr>  
                <tr>
                    <td width="5%"></td>
                    <td width="8%">
                        标题:
                    </td>
                    <td>
                        <input id="title" type="text" class="easyui-validatebox" style="border: 1px solid #8DB2E3;
                            width: 146px; height: 18px" />
                    </td>
                    <td width="8%">
                        作者:
                    </td>
                    <td>
                        <input id="writer" type="text" class="easyui-validatebox" style="border: 1px solid #8DB2E3;
                            width: 146px; height: 18px" />
                    </td>
                    <td width="8%">
                    </td>
                    <td></td>
                    <td>
                        <a href="#" class="easyui-linkbutton" iconcls="icon-search" onclick="doSearch()">查询</a>
                    </td>
                </tr> 
           </table>  
    </div>  
</body>
</html>


