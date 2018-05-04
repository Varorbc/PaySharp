using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace WxPayAPI
{
    public partial class MicroPayPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Log.Info(this.GetType().ToString(), "page load");         
        }

        protected void submit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(auth_code.Text))
            {
                Response.Write("<script LANGUAGE='javascript'>alert('请输入授权码！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(body.Text))
            {
                Response.Write("<script LANGUAGE='javascript'>alert('请输入商品描述！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(fee.Text))
            {
                Response.Write("<script LANGUAGE='javascript'>alert('请输入商品总金额！');</script>");
                return;
            }
            //调用刷卡支付,如果内部出现异常则在页面上显示异常原因
            try
            {
                string result = MicroPay.Run(body.Text, fee.Text, auth_code.Text);
                Response.Write("<span style='color:#00CD00;font-size:20px'>" + result + "</span>");
            }
            catch(WxPayException ex)
            {
                Response.Write("<span style='color:#FF0000;font-size:20px'>" + ex.ToString() + "</span>");
            }
            catch(Exception ex)
            {
                Response.Write("<span style='color:#FF0000;font-size:20px'>" + ex.ToString() + "</span>");
            }
        }
    }
}