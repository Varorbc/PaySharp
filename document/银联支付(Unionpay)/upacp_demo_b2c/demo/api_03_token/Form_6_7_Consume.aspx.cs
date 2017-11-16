using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.unionpay.acp.sdk;

namespace upacp_demo_wtz_token.demo.api_03_token
{
    public partial class Form_6_7_Consume : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /**
             * 重要：联调测试时请仔细阅读注释！
             * 
             * 产品：无跳转token产品<br>
             * 交易：消费：后台资金类交易，有同步应答和后台通知应答<br>
             * 日期： 2015-09<br>
             * 版本： 1.0.0
             * 版权： 中国银联<br>
             * 说明：以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己需要，按照技术文档编写。该代码仅供参考，不提供编码性能规范性等方面的保障<br>
             * 交易说明:1）确定交易成功机制：商户需开发后台通知接口或交易状态查询接口（Form03_6_5_Query）确定交易是否成功，建议发起查询交易的机制：可查询N次（不超过6次），每次时间间隔2N秒发起,即间隔1，2，4，8，16，32S查询（查询到03，04，05继续查询，否则终止查询）
             *       2）交易要素token号+短息验证码(默认验证短信，如果配置了不验证短信则不送短信验证码）
             */


            Dictionary<string, string> param = new Dictionary<string, string>();
            
            //以下信息需要填写
            param["orderId"] = Request.Form["orderId"].ToString();//商户订单号，8-32位数字字母，可按自己规则产生，如上送短信验证码，请填写获取验证码时一样的orderId，此处默认取demo演示页面传递的参数
            param["merId"] = Request.Form["merId"].ToString();//商户代码，请改成自己的测试商户号，此处默认取demo演示页面传递的参数
            param["txnTime"] = Request.Form["txnTime"].ToString();//订单发送时间，取系统时间，如上送短信验证码，请填写获取验证码时一样的txnTime，此处默认取demo演示页面传递的参数
            param["txnAmt"] = Request.Form["txnAmt"].ToString();//交易金额，单位分，如上送短信验证码，请填写获取验证码时一样的txnAmt，此处默认取demo演示页面传递的参数
            param["tokenPayData"] = "{trId=62000000001&token=" + Request.Form["token"].ToString() + "}"; //token号从开通和开通查询借口获取

            //支付卡信息填写
            //贷记卡 必送：手机号、CVN2、有效期；验证码看业务配置（默认需要短信验证码）。
            //借记卡 必送：手机号；选送：证件类型+证件号、姓名；验证码看业务配置（默认需要短信验证码）。
            Dictionary<string, string> customerInfo = new Dictionary<string, string>();
            customerInfo["smsCode"] = "111111"; //短信验证码，测试环境不会真实收到短信，固定填111111。除了123456和654321固定反失败，其余固定成功。

            //param["customerInfo"] = AcpService.GetCustomerInfo(customerInfo, System.Text.Encoding.UTF8); //持卡人身份信息，旧规范请按此方式填写
            param["customerInfo"] = AcpService.GetCustomerInfoWithEncrypt(customerInfo, System.Text.Encoding.UTF8); //持卡人身份信息，新规范请按此方式填写

            // 请求方保留域，
            // 透传字段，查询、通知、对账文件中均会原样出现，如有需要请启用并修改自己希望透传的数据。
            // 出现部分特殊字符时可能影响解析，请按下面建议的方式填写：
            // 1. 如果能确定内容不会出现&={}[]"'等符号时，可以直接填写数据，建议的方法如下。
            //param["reqReserved"] = "透传信息1|透传信息2|透传信息3";
            // 2. 内容可能出现&={}[]"'符号时：
            // 1) 如果需要对账文件里能显示，可将字符替换成全角＆＝｛｝【】“‘字符（自己写代码，此处不演示）；
            // 2) 如果对账文件没有显示要求，可做一下base64（如下）。
            //    注意控制数据长度，实际传输的数据长度不能超过1024位。
            //    查询、通知等接口解析时使用System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(reqReserved))解base64后再对数据做后续解析。
            //param["reqReserved"] = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("任意格式的信息都可以"));

            //以下信息非特殊情况不需要改动
             param["version"] = SDKConfig.Version;//版本号
            param["encoding"] = "UTF-8";//编码方式
            param["signMethod"] =SDKConfig.SignMethod;//签名方法
            param["txnType"] = "01";//交易类型
            param["txnSubType"] = "01";//交易子类
            param["bizType"] = "000902";//业务类型
            param["accessType"] = "0";//接入类型
            param["channelType"] = "07";//渠道类型
            param["currencyCode"] = "156";//交易币种，境内商户勿改
            param["encryptCertId"] = AcpService.GetEncryptCertId();//加密证书ID
            param["backUrl"] = SDKConfig.BackUrl;  //后台通知地址

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
                        //交易已受理，等待接收后台通知更新订单状态，如果通知长时间未收到也可发起交易状态查询
                        //TODO
                        Response.Write("受理成功。<br>\n");
                    }
                    else if ("03" == respcode ||
                            "04" == respcode ||
                            "05" == respcode )
                    {
                        //后续需发起交易状态查询交易确定交易状态
                        //TODO
                        Response.Write("处理超时，请稍微查询。<br>\n");
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
                    Response.Write("商户端验证返回报文签名失败。<br>\n");
                }
            }
            else
            {
                Response.Write("请求失败\n");
            }
        }
    }
}