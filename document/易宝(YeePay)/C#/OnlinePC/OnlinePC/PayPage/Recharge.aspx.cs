using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePC.PayPage
{
    public partial class Recharge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                p0_Cmd.Value = "Load";
                p1_MerId.Value = CustomerConfig.merchantAccount;
                p2_Order.Value = "Onlince" + Guid.NewGuid().ToString().Replace("-", "o").Substring(0, 9);
                p3_Amt.Value = "1.01";
                p4_Cur.Value = "CNY";
                pt_ActId.Value = "0";
                pv_Ver.Value = "2.0";

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder log = new StringBuilder();
            log.Append(DateTime.Now.ToString() + "\n");
            log.Append("测试功能：" + theme.InnerText + "\n");


            //***********************修改内容****************************

            string requestUrl = APIURLConfig.recharge;
            string[] list = { "p0_Cmd",
                "p1_MerId", "p2_Order", "p3_Amt", "p4_Cur", "p5_Pid", "p6_Pcat", "p7_Pdesc", "p8_Url",
                 "pa_MP","pa_Ext", "pa_Ext","pd_FrpId","pd_BankBranch","pt_ActId","pv_Ver" };


            //***********************************************************


            log.Append("请求地址：" + requestUrl + "\n");
            log.Append("商户编号：" + p1_MerId.Value + "\n");
            log.Append("商户密钥：" + CustomerConfig.merchantKey + "\n");


            //存储前台数据
            string data_hmac = "";

            //循环生成
            foreach (string listname in list)
            {
                if (Request[listname] != "")
                {
                    data_hmac = data_hmac + Request[listname];
                }
            }

            //生成hmac签名
            string hmac = Digest.CreateHmac(data_hmac);
            log.Append("加密的字符串：" + data_hmac + "\n");
            log.Append("请求hmac：" + hmac + "\n");

            //循环生成请求数据
            string data = "";
            foreach (string listname in list)
            {
                if (Request[listname] != "")
                {
                    data = data + listname + "=" + Request[listname] + "&";
                }
            }

            data = data + "hmac=" + hmac;

            log.Append("请求链接：" + requestUrl + "?" + data + "\n");


            SoftLog.LogStr(log.ToString(), theme.InnerText);

            Response.Redirect(requestUrl + "?" + data);




        }
    }
}