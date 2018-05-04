<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderQueryPage.aspx.cs" Inherits="WxPayAPI.OrderQueryPage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" /> 
    <title>微信支付样例-订单查询</title>
</head>
<body>  
	<form runat="server">
        <div style="margin-left:2%;color:#f00">微信订单号和商户订单号选少填一个，微信订单号优先：</div><br/>
        <div style="margin-left:2%;">微信订单号：</div><br/>
        <asp:TextBox ID="transaction_id" runat="server" style="width:96%;height:35px;margin-left:2%;" /><br /><br />
        <div style="margin-left:2%;">商户订单号：</div><br/>
        <asp:TextBox ID="out_trade_no" runat="server" style="width:96%;height:35px;margin-left:2%;" /><br /><br />
		<div align="center">
			<asp:Button ID="submit" runat="server" Text="查询" style="width:210px; height:50px; border-radius: 15px;background-color:#00CD00; border:0px #FE6714 solid; cursor: pointer;  color:white;  font-size:16px;" OnClick="submit_Click" />
		</div>
	</form>
</body>
</html>