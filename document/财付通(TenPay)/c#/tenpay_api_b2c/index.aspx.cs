using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("页面跳转调用:</br>");
        Response.Write("<a target=\"_blank\" href=\"" + "payRequest.aspx" + "\">" + "支付请求" + "</a></br>");
        Response.Write("</br>后台调用：</br>");
        Response.Write("<a target=\"_blank\" href=\"" + "clientQueryTrans.aspx" + "\">" + "订单查询" + "</a></br>");
        Response.Write("<a target=\"_blank\" href=\"" + "clientRefund.aspx" + "\">" + "退款" + "</a></br>");
        Response.Write("<a target=\"_blank\" href=\"" + "clientQueryRefund.aspx" + "\">" + "退款查询" + "</a></br>");
    }
}
