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
    public partial class EncryptCerUpdateQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            Dictionary<string, string> param = new Dictionary<string, string>();

            //以下信息非特殊情况不需要改动
            param["version"] = SDKConfig.Version;//版本号
            param["encoding"] = "UTF-8";//编码方式
            param["txnType"] = "95";//交易类型
            param["txnSubType"] = "00";//交易子类
            param["bizType"] = "000000";//业务类型
            param["signMethod"] = SDKConfig.SignMethod;//签名方法
            param["channelType"] = "08";//渠道类型
            param["certType"]= "01"; //01：敏感信息加密公钥(只有01可用)
            param["accessType"] = "0";//
            //TODO 以下信息需要填写
            param["merId"] = Request.Form["merId"].ToString();//商户号，请改自己的测试商户号，此处默认取demo演示页面传递的参数
            param["orderId"] = Request.Form["orderId"].ToString();//商户订单号，8-32位数字字母，不能含“-”或“_”，此处默认取demo演示页面传递的参数，可以自行定制规则
            param["txnTime"] = Request.Form["txnTime"].ToString();//订单发送时间，格式为YYYYMMDDhhmmss，取北京时间，此处默认取demo演示页面传递的参数，参考取法： DateTime.Now.ToString("yyyyMMddHHmmss")
            
            //TODO 其他特殊用法请查看 pages/api_05_app/special_use_purchase.htm

            AcpService.Sign(param, System.Text.Encoding.UTF8);  // 签名
            string url = SDKConfig.AppRequestUrl;

            Dictionary<String, String> rspData = AcpService.Post(param, url, System.Text.Encoding.UTF8);

            Response.Write(DemoUtil.GetPrintResult(url, param, rspData));

            if (rspData.Count!=0)
            {
                if (AcpService.Validate(rspData, System.Text.Encoding.UTF8))
                {
                    Response.Write("商户端验证返回报文签名成功。<br>\n");
                    string respcode = rspData["respCode"]; //其他应答参数也可用此方法获取
                    if ("00" == respcode)
                    {
                        int resultCode = AcpService.UpdateEncryptCert(rspData, System.Text.Encoding.UTF8);
                        if (resultCode == 1)
                        {
                            Response.Write("加密公钥更新成功");
                        }
                        else if (resultCode == 0)
                        {
                            Response.Write("加密公钥无更新");
                        }
                        else
                        {
                            Response.Write("加密公钥更新失败");
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