<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelOrder.aspx.cs" Inherits="OnlinePC.PayPage.CancelOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>网银订单撤销功能</title>
    <link href="../css/temp.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <form method="post" class="smart-green" runat="server">
        <h1 id="theme" runat="server">网银订单撤销功能</h1>
        <label>
            <span>p0_Cmd:</span>
            <input id="p0_Cmd" type="text"  readonly="true" placeholder="业务类型" runat="server" />
        </label>

        <label>
            <span>p1_MerId</span>
            <input id="p1_MerId" type="text" placeholder="商户编号" readonly="true"  value="" runat="server"/>
        </label>

          <label>
            <span>pb_TrxId</span>
            <input id="pb_TrxId" type="text" placeholder="商户订单号" value="" runat="server"/>
        </label>

        <label>
            <span>pv_Ver</span>
            <input id="pv_Ver" type="text" placeholder="版本号" value="" runat="server"/>
        </label>

        <label>
            <span>&nbsp;</span>
            <asp:Button ID="Button2" runat="server" class="button" Text="去撤销" OnClick="Button1_Click" />
        </label>
    </form>
</body>
</html>






     
