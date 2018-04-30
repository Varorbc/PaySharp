<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MicroPayPage.aspx.cs" Inherits="WxPayAPI.MicroPayPage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" /> 
    <title>微信支付样例-刷卡支付</title>
</head>
<body>  
	<form runat="server">
        <div style="margin-left:2%;">商品描述：</div><br/>
        <asp:TextBox ID="body" runat="server" style="width:96%;height:35px;margin-left:2%;" value="test"/><br /><br />
        <div style="margin-left:2%;">支付金额(分)：</div><br/>
        <asp:TextBox ID="fee" runat="server" style="width:96%;height:35px;margin-left:2%;" value="1" /><br /><br />
        <div style="margin-left:2%;">授权码：</div><br/>
        <asp:TextBox ID="auth_code" runat="server" style="width:96%;height:35px;margin-left:2%;" /><br /><br />
       	<div align="center">
			    <asp:Button ID="submit" Text="提交刷卡" runat="server" style="width:210px; height:50px; border-radius: 15px;background-color:#00CD00; border:0px #FE6714 solid; cursor: pointer;  color:white;  font-size:16px;" OnClick="submit_Click"/>
		</div>
	</form>
</body>
</html>