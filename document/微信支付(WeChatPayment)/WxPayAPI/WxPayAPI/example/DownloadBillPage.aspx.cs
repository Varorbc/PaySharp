using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WxPayAPI
{
    public partial class DownloadBillPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Log.Debug(this.GetType().ToString(), "page load");
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(bill_date.Text))
            {
                Response.Write("<script LANGUAGE='javascript'>alert('请输入对账单日期！');</script>");
                return;
            }

            //调用下载对账单接口,如果内部出现异常则在页面上显示异常原因
            try
            {
                string result = DownloadBill.Run(bill_date.Text, bill_type.SelectedValue);
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