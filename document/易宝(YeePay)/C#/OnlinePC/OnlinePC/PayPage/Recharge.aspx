<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recharge.aspx.cs" Inherits="OnlinePC.PayPage.Recharge" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=GBK"/>
    <title>网银充值功能</title>
    <link href="../css/temp.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <form method="post" class="smart-green" runat="server">
        <h1 id="theme" runat="server">网银充值功能</h1>
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
            <span>pa_MP</span>
            <input id="pa_MP" type="text" placeholder="商户扩展信息" value="" runat="server"/>
        </label>

         <label>
            <span>pa_Ext</span>
            <input id="pa_Ext" type="text" placeholder="商户扩展属性" value="" runat="server"/>
        </label>

         <label>
            <span>pb_Oper</span>
            <input id="pb_Oper" type="text" placeholder="操作员" value="" runat="server"/>
        </label>

        <label>
            <span>pd_FrpId</span>
            <input id="pd_FrpId" type="text" placeholder="支付通道编码" value="" runat="server" />
        </label>

         <label>
            <span>pd_BankBranch</span>
            <input id="pd_BankBranch" type="text" placeholder="银行分行" value="" runat="server" />
        </label>

         <label>
            <span>pt_ActId</span>
            <input id="pt_ActId" type="text" placeholder="充值目标账号" value="" runat="server" />
        </label>         

          <label>
            <span>pv_Ver</span>
            <input id="pv_Ver" type="text" placeholder="版本号" value="" runat="server" />
        </label>

        <label>
            <span>&nbsp;</span>
            <asp:Button ID="Button2" runat="server" class="button" Text="去支付" OnClick="Button1_Click" />
        </label>
    </form>
</body>
</html>






     