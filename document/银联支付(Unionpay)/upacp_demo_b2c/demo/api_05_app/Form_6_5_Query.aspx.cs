using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.unionpay.acp.sdk;

namespace upacp_demo_app.demo.api_05_app
{
    public partial class Form_6_5_Query : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /**
             * 重要：联调测试时请仔细阅读注释！
             * 
             * 产品：跳转网关支付产品<br>
             * 交易：交易状态查询交易：只有同步应答 <br>
             * 日期： 2015-09<br>
             * 版本： 1.0.0 
             * 版权： 中国银联<br>
             * 说明：以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己需要，按照技术文档编写。该代码仅供参考，不提供编码性能及规范性等方面的保障<br>
             * 该接口参考文档位置：open.unionpay.com帮助中心 下载  产品接口规范  《网关支付产品接口规范》，<br>
             *              《平台接入接口规范-第5部分-附录》（内包含应答码接口规范，全渠道平台银行名称-简码对照表）<br>
             * 测试过程中的如果遇到疑问或问题您可以：1）优先在open平台中查找答案：
             * 							        调试过程中的问题或其他问题请在 https://open.unionpay.com/ajweb/help/faq/list 帮助中心 FAQ 搜索解决方案
             *                             测试过程中产生的7位应答码问题疑问请在https://open.unionpay.com/ajweb/help/respCode/respCodeList 输入应答码搜索解决方案
             *                           2） 咨询在线人工支持： open.unionpay.com注册一个用户并登陆在右上角点击“在线客服”，咨询人工QQ测试支持。
             * 交易说明： 1）对前台交易发起交易状态查询：前台类交易建议间隔（5分、10分、30分、60分、120分）发起交易查询，如果查询到结果成功，则不用再查询。（失败，处理中，查询不到订单均可能为中间状态）。也可以建议商户使用payTimeout（支付超时时间），过了这个时间点查询，得到的结果为最终结果。
             *        2）对后台交易发起交易状态查询：后台类资金类交易同步返回00，成功银联有后台通知，商户也可以发起 查询交易，可查询N次（不超过6次），每次时间间隔2N秒发起,即间隔1，2，4，8，16，32S查询（查询到03，04，05继续查询，否则终止查询）。
             *        					         后台类资金类同步返03 04 05响应码及未得到银联响应（读超时）需发起查询交易，可查询N次（不超过6次），每次时间间隔2N秒发起,即间隔1，2，4，8，16，32S查询（查询到03，04，05继续查询，否则终止查询）。
             */
 
            Dictionary<string, string> param = new Dictionary<string, string>();

            //以下信息非特殊情况不需要改动
            param["version"] = SDKConfig.Version;//版本号
            param["encoding"] = "UTF-8";//编码方式
            param["certId"] = CertUtil.GetSignCertId();//证书ID
            param["signMethod"] = SDKConfig.SignMethod;//签名方法
            param["txnType"] = "00";//交易类型
            param["txnSubType"] = "00";//交易子类
            param["bizType"] = "000000";//业务类型
            param["accessType"] = "0";//接入类型
            param["channelType"] = "07";//渠道类型

            //TODO 以下信息需要填写
            param["orderId"] = Request.Form["orderId"].ToString();	//请修改被查询的交易的订单号，8-32位数字字母，不能含“-”或“_”，此处默认取demo演示页面传递的参数
            param["merId"] = Request.Form["merId"].ToString();//商户代码，请改成自己的测试商户号，此处默认取demo演示页面传递的参数
            param["txnTime"] = Request.Form["txnTime"].ToString();//请修改被查询的交易的订单发送时间，格式为YYYYMMDDhhmmss，此处默认取demo演示页面传递的参数

      
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
                        string origRespCode = rspData["origRespCode"]; //其他应答参数也可用此方法获取
                        //处理被查询交易的应答码逻辑
                        if ("00" == origRespCode)
                        {
                            //交易成功，更新商户订单状态
                            //TODO
                            Response.Write("交易成功。<br>\n");
                        }
                        else if ("03" == origRespCode ||
                            "04" == origRespCode ||
                            "05" == origRespCode )
                        {
                            //需再次发起交易状态查询交易
                            //TODO
                            Response.Write("稍后查询。<br>\n");
                        }
                        else
                        {
                            //其他应答码做以失败处理
                            //TODO
                            Response.Write("交易失败：" + rspData["origRespMsg"] + "。<br>\n");
                        }
                    }
                    else if ("03" == respcode ||
                            "04" == respcode ||
                            "05" == respcode)
                    {
                        //不明原因超时，后续继续发起交易查询。
                        //TODO
                        Response.Write("处理超时，请稍后查询。<br>\n");
                    }
                    else
                    {
                        //其他应答码做以失败处理
                        //TODO
                        Response.Write("查询操作失败：" + rspData["respMsg"] + "。<br>\n");
                    }
                }
            }
            else
            {
                Response.Write("请求失败\n");
            }
        }
    }
}