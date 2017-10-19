<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadBillPage.aspx.cs" Inherits="WxPayAPI.DownloadBillPage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" /> 
    <title>微信支付样例-下载对账单</title>
</head>
<body>  
	<form runat="server">
        <div style="margin-left:2%;">对账日期：</div><br/>
        <asp:TextBox ID="bill_date" runat="server" style="width:96%;height:35px;margin-left:2%;"/><br /><br />
        <div style="margin-left:2%;">账单类型：</div><br/>
        <asp:DropDownList ID="bill_type" runat="server" style="width:96%;height:35px;margin-left:2%;">
            <asp:ListItem Value="ALL">所有订单信息</asp:ListItem>
            <asp:ListItem Value="SUCCESS">成功支付的订单</asp:ListItem>
            <asp:ListItem Value="REFUND">退款订单</asp:ListItem>
            <asp:ListItem Value="REVOKED">撤销的订单</asp:ListItem>
        </asp:DropDownList>
        <br /><br />
       	<div align="center">
			<asp:Button ID="submit" runat="server" Text="下载对账单" style="width:210px; height:50px; border-radius: 15px;background-color:#00CD00; border:0px #FE6714 solid; cursor: pointer;  color:white;  font-size:16px;" OnClick="submit_Click" />
		</div>
	</form>
</body>
</html>