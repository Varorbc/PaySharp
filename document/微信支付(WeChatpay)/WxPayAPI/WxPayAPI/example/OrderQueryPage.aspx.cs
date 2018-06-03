using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WxPayAPI
{
    public partial class OrderQueryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Log.Info(this.GetType().ToString(), "page load");
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(transaction_id.Text) && string.IsNullOrEmpty(out_trade_no.Text))
            {
                Response.Write("<script LANGUAGE='javascript'>alert('微信订单号和商户订单号至少填写一个,微信订单号优先！');</script>");
                return;
            }

            //调用订单查询接口,如果内部出现异常则在页面上显示异常原因
            try
            {
                string result = OrderQuery.Run(transaction_id.Text, out_trade_no.Text);//调用订单查询业务逻辑
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