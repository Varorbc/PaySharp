<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrontRcvResponse.aspx.cs" Inherits="upacp_demo_b2c.demo.api_01_gateway.FrontRcvResponse" %>

<%@ Import Namespace="com.unionpay.acp.sdk" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table  border="1">
    <%
        Response.Write(this.html);
    %>
    </table>
    </form>
</body>

</html>

    
    
   