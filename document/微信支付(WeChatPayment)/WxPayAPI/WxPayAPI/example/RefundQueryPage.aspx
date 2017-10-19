<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RefundQueryPage.aspx.cs" Inherits="WxPayAPI.RefundQueryPage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" /> 
    <title>微信支付样例-退款查询</title>
</head>
<body>  
	<form runat="server">
        <div style="margin-left:2%;color:#f00">微信订单号、商户订单号、商户退款单号、微信退款单号选填至少一个，微信退款单号优先：</div><br/>
        <div style="margin-left:2%;">微信订单号：</div><br/>
        <asp:TextBox ID="transaction_id" runat="server" style="width:96%;height:35px;margin-left:2%;" /><br /><br />
        <div style="margin-left:2%;">商户订单号：</div><br/>
        <asp:TextBox ID="out_trade_no" runat="server" style="width:96%;height:35px;margin-left:2%;"/><br /><br />
        <div style="margin-left:2%;">商户退款单号：</div><br/>
        <asp:TextBox ID="out_refund_no" runat="server" style="width:96%;height:35px;margin-left:2%;" /><br /><br />
        <div style="margin-left:2%;">微信退款单号：</div><br/>
        <asp:TextBox ID="refund_id" runat="server" style="width:96%;height:35px;margin-left:2%;" /><br /><br />
		<div align="center">
			<asp:Button ID="submit" Text="查询退款" runat="server" style="width:210px; height:50px; border-radius: 15px;background-color:#00CD00; border:0px #FE6714 solid; cursor: pointer;  color:white;  font-size:16px;" OnClick="submit_Click" />
		</div>
	</form>
</body>
</html>