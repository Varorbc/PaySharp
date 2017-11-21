using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.unionpay.acp.sdk;

namespace upacp_demo_wtz_token.demo.api_03_token
{
    public partial class Form_6_5_UpdateToken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /**
             * 重要：联调测试时请仔细阅读注释！
             * 
             * 产品：无跳转token产品<br>
             * 交易：更新token号：后台交易，无通知<br>
             * 日期： 2015-09<br>
             * 版本： 1.0.0
             * 版权： 中国银联<br>
             * 说明：以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己需要，按照技术文档编写。该代码仅供参考，不提供编码性能规范性等方面的保障<br>
             * 交易说明: 同步应答确定交易成功。仅支持商户侧开通的方式。推荐直接使用开通接口来更新token，而非用这个接口更新。
             *        
             */

            Dictionary<string, string> param = new Dictionary<string, string>();

            //  以下信息需要填写
            param["orderId"] = Request.Form["orderId"].ToString();//商户订单号，8-32位数字字母，可按自己规则产生，如上送短信验证码，请填写获取验证码时一样的orderId，此处默认取demo演示页面传递的参数
            param["merId"] = Request.Form["merId"].ToString();//商户代码，请改成自己的测试商户号，此处默认取demo演示页面传递的参数
            param["txnTime"] = Request.Form["txnTime"].ToString();//订单发送时间，取系统时间，如上送短信验证码，请填写获取验证码时一样的orderId，此处默认取demo演示页面传递的参数
            param["tokenPayData"] = "{trId=62000000001&token=" + Request.Form["token"].ToString() + "&tokenType=01}"; //token号从开通和开通查询借口获取，trId和开通接口时上送的相同

            //支付卡信息填写
            //贷记卡 必送：手机号、CVN2、有效期；验证码看业务配置（默认需要短信验证码）。
            //借记卡 必送：手机号；选送：证件类型+证件号、姓名；验证码看业务配置（默认需要短信验证码）。
            Dictionary<string, string> customerInfo = new Dictionary<string, string>();
            customerInfo["phoneNo"] = "18100000000"; //手机号
            //customerInfo["certifTp"] = "01"; //证件类型，01-身份证
            //customerInfo["certifId"] = "510265790128303"; //证件号，15位身份证不校验尾号，18位会校验尾号，请务必在前端写好校验代码
            //customerInfo["customerNm"] = "张三"; //姓名
            customerInfo["cvn2"] = "248"; //cvn2
            customerInfo["expired"] = "1912"; //有效期，YYMM格式，持卡人卡面印的是MMYY的，请注意代码设置倒一下
            customerInfo["smsCode"] = "111111"; //短信验证码，测试环境不会真实收到短信，固定填111111。除了123456和654321固定反失败，其余固定成功。此接口获取验证码接口同开通的获取验证码接口。

            //param["customerInfo"] = AcpService.GetCustomerInfo(customerInfo, System.Text.Encoding.UTF8); //持卡人身份信息，旧规范请按此方式填写
            param["customerInfo"] = AcpService.GetCustomerInfoWithEncrypt(customerInfo, System.Text.Encoding.UTF8); //持卡人身份信息，新规范请按此方式填写

            //以下信息非特殊情况不需要改动
             param["version"] = SDKConfig.Version;//版本号
            param["encoding"] = "UTF-8";//编码方式
            param["signMethod"] =SDKConfig.SignMethod;//签名方法
            param["txnType"] = "79";//交易类型
            param["txnSubType"] = "03";//交易子类
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
                        //更新标记成功
                        //TODO
                        Response.Write("更新标记成功。<br>\n");
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