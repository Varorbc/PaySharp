using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.unionpay.acp.sdk;

namespace upacp_demo_wtz_token.demo.api_03_token
{
    public partial class Form_6_2_BackOpen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /**
             * 重要：联调测试时请仔细阅读注释！
             * 
             * 产品：无跳转产品<br>
             * 交易：后台开通：后台交易，只有同步应答<br>
             * 日期： 2015-11<br>
             * 版本： 1.0.0
             * 版权： 中国银联<br>
             * 说明：以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己需要，按照技术文档编写。该代码仅供参考，不提供编码性能规范性等方面的保障<br>
             * 该接口参考文档位置：open.unionpay.com帮助中心 下载  产品接口规范  《代收产品接口规范》<br>
             *              《平台接入接口规范-第5部分-附录》（内包含应答码接口规范）<br>
             * 测试过程中的如果遇到疑问或问题您可以：1）优先在open平台中查找答案：
             * 							        调试过程中的问题或其他问题请在 https://open.unionpay.com/ajweb/help/faq/list 帮助中心 FAQ 搜索解决方案
             *                             测试过程中产生的7位应答码问题疑问请在https://open.unionpay.com/ajweb/help/respCode/respCodeList 输入应答码搜索解决方案
             *                          2） 咨询在线人工支持： open.unionpay.com注册一个用户并登陆在右上角点击“在线客服”，咨询人工QQ测试支持。
             * 交易说明:同步交易，不需要接收后台通知或发起交易状态查询交易，同步应答确定交易成功。
             */

            Dictionary<string, string> param = new Dictionary<string, string>();

            //  以下信息需要填写
            param["orderId"] = Request.Form["orderId"].ToString();//商户订单号，8-32位数字字母，可按自己规则产生，如上送短信验证码，请填写获取验证码时一样的orderId，此处默认取demo演示页面传递的参数
            param["merId"] = Request.Form["merId"].ToString();//商户代码，请改成自己的测试商户号，此处默认取demo演示页面传递的参数
            param["txnTime"] = Request.Form["txnTime"].ToString();//订单发送时间，取系统时间，如上送短信验证码，请填写获取验证码时一样的txnTime，此处默认取demo演示页面传递的参数
            param["tokenPayData"] = "{trId=62000000001&tokenType=01}"; //测试环境固定trId=62000000001&tokenType=01，生产环境由业务分配。测试环境因为所有商户都使用同一个trId，所以同一个卡获取的token号都相同，任一人发起更新token或者解除token请求都会导致原token号失效，所以之前成功、突然出现3900002报错时请先尝试重新开通一下。

            //支付卡信息填写
            //贷记卡 必送：卡号、手机号、CVN2、有效期；验证码看业务配置（默认不要短信验证码）。
            //借记卡 必送：卡号、手机号；选送：证件类型+证件号、姓名；验证码看业务配置（默认不要短信验证码）。
            string accNo = "6226388000000095"; //卡号
            Dictionary<string, string> customerInfo = new Dictionary<string, string>();
            customerInfo["phoneNo"] = "18100000000"; //手机号
            //customerInfo["certifTp"] = "01"; //证件类型，01-身份证
            //customerInfo["certifId"] = "510265790128303"; //证件号，15位身份证不校验尾号，18位会校验尾号，请务必在前端写好校验代码
            //customerInfo["customerNm"] = "张三"; //姓名
            customerInfo["cvn2"] = "248"; //cvn2
            customerInfo["expired"] = "1912"; //有效期，YYMM格式，持卡人卡面印的是MMYY的，请注意代码设置倒一下
            customerInfo["smsCode"] = "111111"; //短信验证码
            
            //param["accNo"] = accNo; //卡号，旧规范请按此方式填写
            //param["customerInfo"] = AcpService.GetCustomerInfo(customerInfo, System.Text.Encoding.UTF8); //持卡人身份信息，旧规范请按此方式填写
            param["accNo"] = AcpService.EncryptData(accNo, System.Text.Encoding.UTF8); //卡号，新规范请按此方式填写
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
            param["txnType"] = "79";//交易类型
            param["txnSubType"] = "00";//交易子类
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
                        //后台开通成功
                        //TODO
                        Response.Write("后台开通成功。<br>\n");
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