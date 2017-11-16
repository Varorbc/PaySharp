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
    public partial class Form_6_2_FrontConsume : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /**
             * 产品：二维码支付<br>
             * 交易：二维码消费（被扫）<br>
             * 日期： 2017-02<br>
             * 版权： 中国银联<br>
            **/
            Dictionary<string, string> param = new Dictionary<string, string>();

            //以下信息非特殊情况不需要改动
            param["version"] = SDKConfig.Version;//版本号
            param["encoding"] = "UTF-8";//编码方式
            param["signMethod"] = SDKConfig.SignMethod;// "01";//签名方法
            param["txnType"] = "01";//交易类型
            param["txnSubType"] = "06";//交易子类
            param["bizType"] = "000000";//产品类型
            param["channelType"] = "07";//渠道类型
            param["backUrl"] = SDKConfig.BackUrl;// "http://www.specialUrl.com";
            param["accessType"] = "0";//接入类型（0普通商户直接接入）   
            param["accType"] = "01";//账号类型(01银行卡)
            param["currencyCode"] = "156";//交易币种
           // param["reserved"] = "";//保留域

            //TODO 以下信息需要填写
            param["merId"] = Request.Form["merId"].ToString();//商户号，请改自己的测试商户号，此处默认取demo演示页面传递的参数
            param["orderId"] = Request.Form["orderId"].ToString();//商户订单号，8-32位数字字母，不能含“-”或“_”，此处默认取demo演示页面传递的参数，可以自行定制规则
            param["txnTime"] = Request.Form["txnTime"].ToString();//订单发送时间，格式为YYYYMMDDhhmmss，取北京时间，此处默认取demo演示页面传递的参数，参考取法： DateTime.Now.ToString("yyyyMMddHHmmss")
            param["txnAmt"] = Request.Form["txnAmt"].ToString();//交易金额，单位分，此处默认取demo演示页面传递的参数
            param["qrNo"] = Request.Form["qrNo"].ToString();//二维码 编号，此处默认取demo演示页面传递的参数
            param["termId"] = Request.Form["termId"].ToString();//终端号
            //param["reqReserved"] = "透传信息";//请求方保留域，透传字段，查询、通知、对账文件中均会原样出现，如有需要请启用并修改自己希望透传的数据

            //TODO 其他特殊用法请查看 pages/api_01_gateway/special_use_purchase.htm

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