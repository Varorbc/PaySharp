using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePC.PayPage
{
    public partial class Pay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                p0_Cmd.Value = "Buy";
                p1_MerId.Value = CustomerConfig.merchantAccount;
                p2_Order.Value ="Onlince" +Guid.NewGuid().ToString().Replace("-", "o").Substring(0,9);
                p3_Amt.Value = "0.02";
                p4_Cur.Value = "CNY";
                p5_Pid.Value = "测试产品（一键支付必填）";
                p9_SAF.Value = "0";
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder log = new StringBuilder();
            log.Append(DateTime.Now.ToString() + "\n");
            log.Append("测试功能：" + theme.InnerText + "\n");


            //***********************修改内容****************************

            string requestUrl = APIURLConfig.pay;
            string[] list = { "p0_Cmd", "p1_MerId", "p2_Order", "p3_Amt", "p4_Cur", "p5_Pid", "p6_Pcat", "p7_Pdesc", "p8_Url", "p9_SAF", "pa_MP", "pd_FrpId", "pm_Period", "pm_Period", "pr_NeedResponse", "pt_UserName", "pt_Address", "pt_TeleNo", "pt_Mobile", "pt_Email", "pt_LeaveMessage" };
            
            
            //***********************************************************


            log.Append("请求地址：" + requestUrl + "\n");
            log.Append("商户编号：" + p1_MerId.Value + "\n");
            log.Append("商户密钥：" + CustomerConfig.merchantKey + "\n");


            //存储前台数据
            string data = "";

            //循环生成
            foreach (string listname in list)
            {
                if (Request[listname] != "")
                {
                    data = data + Request[listname];
                }
            }

            //生成hmac签名
            string hmac = Digest.CreateHmac(data);
            log.Append("加密的字符串：" + data + "\n");
            log.Append("请求hmac：" + hmac + "\n");

            //循环生成请求数据
            data = "";
            foreach (string listname in list)
            {
                if (Request[listname] != "")
                {
                    data = data +listname+"="+ Request[listname]+"&";
                }
            }

            data = data + "hmac=" + hmac;

            log.Append("请求链接：" +requestUrl+"?"+ data + "\n");


            SoftLog.LogStr(log.ToString(), theme.InnerText);

            Response.Redirect(requestUrl + "?" + data);

            


        }
    }
}