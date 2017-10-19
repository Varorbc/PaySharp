<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pay.aspx.cs" Inherits="OnlinePC.PayPage.Pay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=GBK"/>
     <title>网银支付功能</title>
    
    <link href="../css/temp.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <form method="post" class="smart-green" runat="server">
        <h1 id="theme" runat="server">网银支付功能</h1>
        <label>
            <span>p0_Cmd:</span>
            <input id="p0_Cmd" type="text"  readonly="true" placeholder="业务类型" runat="server" />
        </label>

        <label>
            <span>p1_MerId</span>
            <input id="p1_MerId" type="text" placeholder="商户编号" readonly="true"  value="" runat="server"/>
        </label>

          <label>
            <span>p2_Order</span>
            <input id="p2_Order" type="text" placeholder="商户订单号" value="" runat="server"/>
        </label>

        <label>
            <span>p3_Amt</span>
            <input id="p3_Amt" type="text" placeholder="支付金额" value="" runat="server"/>
        </label>

        <label>
            <span>p4_Cur</span>
            <input id="p4_Cur" type="text" placeholder="交易币种" value="" runat="server" />
        </label>

        <label>
            <span>p5_Pid</span>
            <input id="p5_Pid" type="text" placeholder="商品名称" value="" runat="server" />
        </label>

        <label>
            <span>p6_Pcat</span>
            <input id="p6_Pcat" type="text" placeholder="商品种类" value="" runat="server" />
        </label>

        <label>
            <span>p7_Pdesc</span>
            <input id="p7_Pdesc" type="text" placeholder="商品描述" value=""  runat="server"/>
        </label>

        <label>
            <span>p8_Url</span>
            <input id="p8_Url" type="text" placeholder="回掉地址" value="" runat="server"/>
        </label>

        <label>
            <span>p9_SAF</span>
            <input id="p9_SAF" type="text" placeholder="送货地址" value="" runat="server"/>
        </label>

        <label>
            <span>pa_MP</span>
            <input id="pa_MP" type="text" placeholder="商户扩展信息" value="" runat="server"/>
        </label>

        <label>
            <span>pd_FrpId</span>
            <input id="pd_FrpId" type="text" placeholder="支付通道编码" value="" runat="server" />
        </label>

         <label>
            <span>pm_Period</span>
            <input id="pm_Period" type="text" placeholder="订单有效期" value="" runat="server" />
        </label>

         <label>
            <span>pn_Unit</span>
            <input id="pn_Unit" type="text" placeholder="订单有效期单位" value="" runat="server" />
        </label>

         <label>
            <span>pr_NeedResponse</span>
            <input id="pr_NeedResponse" type="text" placeholder="应答机制" value="" runat="server" />
        </label>

         <label>
            <span>pt_UserName</span>
            <input id="pt_UserName" type="text" placeholder="考生/用户姓名" value="" runat="server" />
        </label>

         <label>
            <span>pt_PostalCode</span>
            <input id="pt_PostalCode" type="text" placeholder="身份证" value="" runat="server" />
        </label>

         <label>
            <span>pt_Address</span>
            <input id="pt_Address" type="text" placeholder="地区" value="" runat="server" />
        </label>

          <label>
            <span>pt_TeleNo</span>
            <input id="pt_TeleNo" type="text" placeholder="报考序号/银行卡号" value="" runat="server" />
        </label>

          <label>
            <span>pt_Mobile</span>
            <input id="pt_Mobile" type="text" placeholder="手机号" value="" runat="server" />
        </label>

          <label>
            <span>pt_Email</span>
            <input id="pt_Email" type="text" placeholder="邮件地址" value="" runat="server" />
        </label>

          <label>
            <span>pt_LeaveMessage</span>
            <input id="pt_LeaveMessage" type="text" placeholder="用户标识" value="" runat="server" />
        </label>

        <label>
            <span>&nbsp;</span>
            <asp:Button ID="Button2" runat="server" class="button" Text="去支付" OnClick="Button1_Click" />
        </label>
    </form>
</body>
</html>






     