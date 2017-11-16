using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.unionpay.acp.sdk;

namespace upacp_demo_wtz_token.demo.api_03_token
{
    public partial class Form_6_3_OpenQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /**
             * 重要：联调测试时请仔细阅读注释！
             * 
             * 产品：无跳转token产品<br>
             * 交易：查询开通：后台交易，无通知<br>
             * 日期： 2015-09<br>
             * 版本： 1.0.0
             * 版权： 中国银联<br>
             * 说明：以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己需要，按照技术文档编写。该代码仅供参考，不提供编码性能规范性等方面的保障<br>
             * 交易说明:1）使用此交易获取token号。
             *       2) 只能针对前台开通交易（银联侧）做查询。 
             */

            Dictionary<string, string> param = new Dictionary<string, string>();

            //  以下信息需要填写
            param["orderId"] = Request.Form["orderId"].ToString();//商户订单号，填写被查询开通交易的orderId，此处默认取demo演示页面传递的参数
            param["merId"] = Request.Form["merId"].ToString();//商户代码，请改成自己的测试商户号，此处默认取demo演示页面传递的参数
            param["txnTime"] = Request.Form["txnTime"].ToString();//订单发送时间，填写被查询开通交易的txnTime，此处默认取demo演示页面传递的参数
            
            //以下信息非特殊情况不需要改动
             param["version"] = SDKConfig.Version;//版本号
            param["encoding"] = "UTF-8";//编码方式
            param["signMethod"] =SDKConfig.SignMethod;//签名方法
            param["txnType"] = "78";//交易类型
            param["txnSubType"] = "02";//交易子类
            param["bizType"] = "000902";//业务类型
            param["accessType"] = "0";//接入类型
            param["channelType"] = "07";//渠道类型
            param["encryptCertId"] = AcpService.GetEncryptCertId();//加密证书ID

            AcpService.Sign(param, System.Text.Encoding.UTF8);  // 签名
            string url = SDKConfig.SingleQueryUrl;

            Dictionary<String, String> rspData = AcpService.Post(param, url, System.Text.Encoding.UTF8);

            Response.Write(DemoUtil.GetPrintResult(url, param, rspData));

            if (rspData.Count != 0)
            {

                if (AcpService.Validate(rspData, System.Text.Encoding.UTF8))
                {
                    Response.Write("商户端验证返回报文签名成功。<br>\n");
                    string respcode = rspData["respCode"]; //其他应答参数也可用此方法获取
                    if ("00" == respcode)
                    {
                        //开通成功
                        //TODO
                        Response.Write("开通成功。<br>\n");
                        string tokenPayDataStr = rspData["tokenPayData"];
                        Dictionary<string, string> tokenPayData = SDKUtil.parseQString(tokenPayDataStr.Substring(1, tokenPayDataStr.Length - 2), System.Text.Encoding.UTF8);
                        if (tokenPayData.ContainsKey("token"))
                        {
                            string token = tokenPayData["token"]; //tokenPayData其他子域均可参考此方式获取  
                        }
                        foreach (KeyValuePair<string, string> pair in tokenPayData)
                        {
                            Response.Write(pair.Key + "=" + pair.Value + "<br>\n");
                        }
                    }
                    else
                    {
                        //其他应答码做以失败处理
                        //TODO
                        Response.Write("失败：" + rspData["respMsg"] + "。<br>\n");
                    }
                }
                else
                {
                    Response.Write("商户端验证返回报文签名失败\n");
                }
            }
            else
            {
                Response.Write("请求失败\n");
            }
        }
    }
}