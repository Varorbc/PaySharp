using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.unionpay.acp.sdk;

namespace upacp_demo_qrc.demo.api_16_qrc
{
    public partial class Form_6_4_Refund : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /**
             * 重要：联调测试时请仔细阅读注释！
             * 产品：二维码支付<br>
             * 交易：退货交易：后台资金类交易，有同步应答和后台通知应答<br>
             * 日期： 2017-02<br>
             * 版本： 1.0.0 
             * 版权： 中国银联<br>
             */

            Dictionary<string, string> param = new Dictionary<string, string>();

            //以下信息非特殊情况不需要改动
            param["version"] = SDKConfig.Version;//版本号
            param["encoding"] = "UTF-8";//编码方式
            param["signMethod"] = SDKConfig.SignMethod;// "01";//签名方法
            param["txnType"] = "04";//交易类型
            param["txnSubType"] = "00";//交易子类
            param["bizType"] = "000000";//产品类型
            param["channelType"] = "07";//渠道类型
            param["backUrl"] = SDKConfig.BackUrl;// "http://www.specialUrl.com";//后台返回商户结果时使用，根据实际修改‘
            param["accessType"] = "0";//接入类型（0普通商户直接接入）

            //TODO 以下信息需要填写
            param["orderId"] = Request.Form["orderId"].ToString();//商户订单号，8-32位数字字母，不能含“-”或“_”，可以自行定制规则，重新产生，不同于原消费，此处默认取demo演示页面传递的参数
            param["merId"] = Request.Form["merId"].ToString();//商户代码，请改成自己的测试商户号，此处默认取demo演示页面传递的参数
            param["txnTime"] = Request.Form["txnTime"].ToString();//订单发送时间，格式为YYYYMMDDhhmmss，重新产生，不同于原消费，此处默认取demo演示页面传递的参数，参考取法： DateTime.Now.ToString("yyyyMMddHHmmss")
            param["txnAmt"] = Request.Form["txnAmt"].ToString(); //交易金额，退货总金额需要小于等于原消费
            
            string origQryId = Request.Form["origQryId"].ToString();
            string origOrderId = Request.Form["origOrderId"].ToString();
            string origTxnTime = Request.Form["origTxnTime"].ToString();
            if (origQryId != "")
                param["origQryId"] = origQryId; //原消费的queryId，可以从查询接口或者通知接口中获取，此处默认取demo演示页面传递的参数
            if (origOrderId != "")
                param["origOrderId"] = origOrderId;
            if (origTxnTime != "")
                param["origTxnTime"] = origTxnTime; 

            AcpService.Sign(param, System.Text.Encoding.UTF8);  // 签名

            string url = SDKConfig.BackTransUrl;//发送post 请求的地址

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
                            "05" == respcode)
                    {
                        //后续需发起交易状态查询交易确定交易状态
                        //TODO
                        Response.Write("处理超时，请稍后查询。<br>\n");
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
                Response.Write("请求失败<br>\n");
            }
        }
    }
}