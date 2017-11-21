using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.unionpay.acp.sdk;

namespace upacp_demo_wtz.demo.api_03_wtz
{
    public partial class Form_6_3_OpenQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /**
             * 重要：联调测试时请仔细阅读注释！
             * 
             * 产品：无跳转产品<br>
             * 交易：查询开通状态：后台交易，同步交易<br>
             * 日期： 2015-11<br>
             * 版权： 中国银联<br>
             * 说明：以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己需要，按照技术文档编写。该代码仅供参考，不提供编码性能规范性等方面的保障<br>
             * 提示：该接口参考文档位置：open.unionpay.com帮助中心 下载  产品接口规范  《无跳转产品接口规范》，<br>
             *                  《全渠道平台接入接口规范 第3部分 文件接口》（4.批量文件基本约定）<br>
             * 测试过程中的如果遇到疑问或问题您可以：1）优先在open平台中查找答案：
             * 							        调试过程中的问题或其他问题请在 https://open.unionpay.com/ajweb/help/faq/list 帮助中心 FAQ 搜索解决方案
             *                             测试过程中产生的7位应答码问题疑问请在https://open.unionpay.com/ajweb/help/respCode/respCodeList 输入应答码搜索解决方案
             *                          2） 咨询在线人工支持： open.unionpay.com注册一个用户并登陆在右上角点击“在线客服”，咨询人工QQ测试支持。
             *                          3） 测试环境测试支付请使用测试卡号测试， FAQ搜索“测试卡号”
             *                          4） 切换生产环境要点请FAQ搜索“切换”
             * 交易说明：根据卡号查询卡是否已经开通，同步应答确定交易成功。
             */

            Dictionary<string, string> param = new Dictionary<string, string>();

            //  以下信息需要填写
            param["orderId"] = Request.Form["orderId"].ToString();//商户订单号，8-32位数字字母，可按自己规则产生，此处默认取demo演示页面传递的参数
            param["merId"] = Request.Form["merId"].ToString();//商户代码，请改成自己的测试商户号，此处默认取demo演示页面传递的参数
            param["txnTime"] = Request.Form["txnTime"].ToString();//订单发送时间，取系统时间，此处默认取demo演示页面传递的参数

            //支付卡信息填写
            string accNo = "6226090000000048"; //卡号
            //param["accNo"] = accNo; //卡号，旧规范请按此方式填写
            param["accNo"] = AcpService.EncryptData(accNo, System.Text.Encoding.UTF8); //卡号，新规范请按此方式填写
            
            //以下信息非特殊情况不需要改动
             param["version"] = SDKConfig.Version;//版本号
            param["encoding"] = "UTF-8";//编码方式
            param["signMethod"] =SDKConfig.SignMethod;//签名方法
            param["txnType"] = "78";//交易类型
            param["txnSubType"] = "00";//交易子类
            param["bizType"] = "000301";//业务类型
            param["accessType"] = "0";//接入类型
            param["channelType"] = "07";//渠道类型
            param["encryptCertId"] = AcpService.GetEncryptCertId();//加密证书ID

            AcpService.Sign(param, System.Text.Encoding.UTF8);  // 签名
            string url = SDKConfig.BackTransUrl;

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
                        //成功
                        //TODO
                        Response.Write("已开通。<br>\n");
                        if (rspData.ContainsKey("customerInfo")) 
                        {
                            Dictionary<string, string> customerInfo = AcpService.ParseCustomerInfo(rspData["customerInfo"], System.Text.Encoding.UTF8);
                            if (customerInfo.ContainsKey("phoneNo")) {
                                string phoneNo = customerInfo["phoneNo"]; //customerInfo其他子域均可参考此方式获取  
                            }
                            foreach (KeyValuePair<string, string> pair in customerInfo)
                            {
                                Response.Write(pair.Key + "=" + pair.Value + "<br>\n");
                            }
                        }
                    }
                    else if ("77" == respcode)
                    {
                        //未开通
                        //TODO
                        Response.Write("未开通。<br>\n");
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
                Response.Write("请求失败<br>\n");
            }
        }
    }
}