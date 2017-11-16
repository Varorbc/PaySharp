using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.unionpay.acp.sdk;

namespace upacp_demo_wtz_token.demo.api_03_token
{
    public partial class Form_6_2_FrontOpen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /**
              * 重要：联调测试时请仔细阅读注释！
              * 
              * 产品：无跳转产品<br>
              * 交易：银联侧开通：前台交易，有前台通知后台通知<br>
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
              * 交易说明:后台通知或者发起开通查询交易确认卡是否已经开通。
              */

            Dictionary<string, string> param = new Dictionary<string, string>();

            //  以下信息需要填写
            param["orderId"] = Request.Form["orderId"].ToString();//商户订单号，8-32位数字字母，可按自己规则产生，此处默认取demo演示页面传递的参数
            param["merId"] = Request.Form["merId"].ToString();//商户代码，请改成自己的测试商户号，此处默认取demo演示页面传递的参数
            param["txnTime"] = Request.Form["txnTime"].ToString();//订单发送时间，取系统时间，此处默认取demo演示页面传递的参数
            param["tokenPayData"] = "{trId=62000000001&tokenType=01}"; //测试环境固定trId=62000000001&tokenType=01，生产环境由业务分配。测试环境因为所有商户都使用同一个trId，所以同一个卡获取的token号都相同，任一人发起更新token或者解除token请求都会导致原token号失效，所以之前成功、突然出现3900002报错时请先尝试重新开通一下。
            //param["reserved"] = "{customPage=true}";//如果开通页面需要使用嵌入页面的话，请上送此用法

            //支付卡信息填写
            //可选送卡号、手机号、证件类型+证件号、姓名，也可以都不送，在界面输入这些要素
            string accNo = "6226090000000048";//卡号
            Dictionary<string, string> customerInfo = new Dictionary<string, string>();
            customerInfo["phoneNo"] = "18100000000"; //手机号
            customerInfo["certifTp"] = "01"; //证件类型，01-身份证
            customerInfo["certifId"] = "510265790128303"; //证件号，15位身份证不校验尾号，18位会校验尾号，请务必在前端写好校验代码
            customerInfo["customerNm"] = "张三"; //姓名

            //param["accNo"] = accNo; //卡号，旧规范请按此方式填写
            //param["customerInfo"] = AcpService.GetCustomerInfo(customerInfo, System.Text.Encoding.UTF8); //持卡人身份信息，旧规范请按此方式填写
            param["accNo"] = AcpService.EncryptData(accNo, System.Text.Encoding.UTF8); //卡号，新规范请按此方式填写
            param["customerInfo"] = AcpService.GetCustomerInfoWithEncrypt(customerInfo, System.Text.Encoding.UTF8); //持卡人身份信息，新规范请按此方式填写

            // 订单超时时间。
            // 超过此时间后，除网银交易外，其他交易银联系统会拒绝受理，提示超时。 跳转银行网银交易如果超时后交易成功，会自动退款，大约5个工作日金额返还到持卡人账户。
            // 此时间建议取支付时的北京时间加15分钟。
            // 超过超时时间调查询接口应答origRespCode不是A6或者00的就可以判断为失败。
            param["payTimeout"] = DateTime.Now.AddMinutes(15).ToString("yyyyMMddHHmmss");

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
            param["frontUrl"] = SDKConfig.FrontUrl;  //前台通知地址
            param["backUrl"] = SDKConfig.BackUrl;  //后台通知地址

            AcpService.Sign(param, System.Text.Encoding.UTF8);  // 签名
            string url = SDKConfig.FrontTransUrl;
            string html = AcpService.CreateAutoFormHtml(url, param, System.Text.Encoding.UTF8);
            Response.ContentEncoding = Encoding.UTF8; // 指定输出编码
            Response.Write(html);
        }
    }
}