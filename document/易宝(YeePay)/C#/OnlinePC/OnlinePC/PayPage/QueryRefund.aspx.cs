using OnlinePC.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePC.PayPage
{
    public partial class QueryRefund : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                p0_Cmd.Value = "RefundResults";
                p1_MerId.Value = CustomerConfig.merchantAccount;
                p2_Order.Value = "";
                pb_TrxId.Value = "";


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder log = new StringBuilder();
            log.Append(DateTime.Now.ToString() + "\n");
            log.Append("测试功能：" + theme.InnerText + "\n");


            //***********************修改内容****************************

            string requestUrl = APIURLConfig.refundOrder;
            string[] list = { "p0_Cmd", "p1_MerId", "p2_Order", "pb_TrxId" };
            string[] list_response = { "r0_Cmd",
                                       "r1_Code",
                                       "r2_TrxId",                                      
                                       "r4_Cur",
                                       "refundStatus",
                                       "refundFrpStatus"                              
                                        };

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
            log.Append("请求加密的字符串：" + data_hmac + "\n");
            log.Append("请求hmac：" + hmac + "\n");

            //循环生成要请求链接的数据
            string data_request = "";
            foreach (string listname in list)
            {
                data_request = data_request + listname + "=" + Request[listname] + "&";
            }
            //最终字符串
            data_request = data_request + "hmac=" + hmac;

            log.Append("请求链接：" + requestUrl + "?" + data_request + "\n");

            //发出请求
            string reqResult = YJPayUtil.payAPIRequestOnlince(requestUrl, data_request, true);
            log.Append("返回的原始信息：" + reqResult + "\n");

            //存储响应信息
            SortedDictionary<string, string> sd = new SortedDictionary<string, string>();

            //循环存储response
            foreach (string listname in list_response)
            {
                sd.Add(listname, FormatQueryString.GetQueryString(listname, reqResult, '\n'));
            }
            sd.Add("hmac", FormatQueryString.GetQueryString("hmac", reqResult, '\n'));


            string response_json = Newtonsoft.Json.JsonConvert.SerializeObject(sd);

            string type = "";
            if (sd["r1_Code"] == "1")
            {
                //回调验证签名
                string response_data = "";

                //循环生成
                foreach (string listname in list_response)
                {

                    response_data = response_data + sd[listname];

                }

                //回调信息生成HMAC
                string hmac_location = Digest.CreateHmac(response_data);


                //验证签名
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;
                if (0 == comparer.Compare(hmac_location, sd["hmac"]))
                {
                    type = "验证签名成功";
                }
                else
                {
                    type = "验证签名失败";
                }
            }
            else
            {
                type = "请检查数据";
            }

            //返回数据data
            string data = response_json.ToString();



            SoftLog.LogStr(log.ToString(), theme.InnerText);

            //跳转页面
            Response.Redirect("http://localhost:58903/CallBack.aspx?data=" + data + "&type=" + type);



        }
    }
}