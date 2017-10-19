using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WxPayAPI
{
    public partial class RefundQueryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Log.Debug(this.GetType().ToString(), "page load");
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(refund_id.Text) && string.IsNullOrEmpty(out_refund_no.Text) &&
                string.IsNullOrEmpty(transaction_id.Text) && string.IsNullOrEmpty(out_trade_no.Text))
            {
                Response.Write("<script LANGUAGE='javascript'>alert('微信订单号、商户订单号、商户退款单号、微信退款单号选填至少一个，微信退款单号优先！');</script>");
                return;
            }

            //调用退款查询接口,如果内部出现异常则在页面上显示异常原因
            try
            {
                string result = RefundQuery.Run(refund_id.Text, out_refund_no.Text, transaction_id.Text, out_trade_no.Text);
                Response.Write("<span style='color:#00CD00;font-size:20px'>" + result + "</span>");
            }
            catch (WxPayException ex)
            {
                Response.Write("<span style='color:#FF0000;font-size:20px'>" + ex.ToString() + "</span>");
            }
            catch (Exception ex)
            {
                Response.Write("<span style='color:#FF0000;font-size:20px'>" + ex.ToString() + "</span>");
            }
        }
    }
}