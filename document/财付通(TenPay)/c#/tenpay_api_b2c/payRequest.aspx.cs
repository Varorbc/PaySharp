using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using tenpay;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /* 商户号，上线时务必将测试商户号替换为正式商户号 */
        string partner = "1900000109";


        //密钥
        string key = "8934e7d15453e97507ef794cf7b0519d";


        //当前时间 yyyyMMdd
        string date = DateTime.Now.ToString("yyyyMMdd");
        //订单号，此处用时间和随机数生成，商户根据自己调整，保证唯一
        string out_trade_no = "" + DateTime.Now.ToString("HHmmss") + TenpayUtil.BuildRandomStr(4);




        //创建RequestHandler实例
        RequestHandler reqHandler = new RequestHandler(Context);
        //初始化
        reqHandler.init();
        //设置密钥
        reqHandler.setKey(key);
        reqHandler.setGateUrl("https://gw.tenpay.com/gateway/pay.htm");



        //-----------------------------
        //设置支付参数
        //-----------------------------
        reqHandler.setParameter("total_fee", "1");
        //用户的公网ip,测试时填写127.0.0.1,只能支持10分以下交易
        reqHandler.setParameter("spbill_create_ip", Page.Request.UserHostAddress);
        reqHandler.setParameter("return_url", "http://localhost:1588/tenpay_api_b2c/payReturnUrl.aspx");
        //reqHandler.setParameter("return_url", "");
        reqHandler.setParameter("partner", partner);
        reqHandler.setParameter("out_trade_no", out_trade_no);
        reqHandler.setParameter("notify_url", "http://localhost:1588/tenpay_api_b2c/payNotifyUrl.aspx");
        reqHandler.setParameter("attach", "123");
        reqHandler.setParameter("body", "测试");
        reqHandler.setParameter("bank_type", "DEFAULT");


        //系统可选参数
        reqHandler.setParameter("sign_type", "MD5");
        reqHandler.setParameter("service_version", "1.0");
        reqHandler.setParameter("input_charset", "GBK");
        reqHandler.setParameter("sign_key_index", "1");

        //业务可选参数
        /*
        reqHandler.setParameter("attach", "");
        reqHandler.setParameter("product_fee", "");
        reqHandler.setParameter("transport_fee", "");
        reqHandler.setParameter("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
        reqHandler.setParameter("time_expire", "");
       
        reqHandler.setParameter("buyer_id", "");
        reqHandler.setParameter("goods_tag", "");
        reqHandler.setParameter("agentid", "");
        reqHandler.setParameter("agent_type", "");
         */

        


        //获取请求带参数的url
        string requestUrl = reqHandler.getRequestURL();

        //Get的实现方式
        string a_link = "<a target=\"_blank\" href=\"" + requestUrl + "\">" + "财付通支付" + "</a>";
        Response.Write(a_link);


        //post实现方式
        /*
        Response.Write("<form method=\"post\" action=\""+ reqHandler.getGateUrl() + "\" >\n");
        Hashtable ht = reqHandler.getAllParameters();
        foreach(DictionaryEntry de in ht) 
        {
            Response.Write("<input type=\"hidden\" name=\"" + de.Key + "\" value=\"" + de.Value + "\" >\n");
        }
        Response.Write("<input type=\"submit\" value=\"财付通支付\" >\n</form>\n");
        */

        //获取debug信息,建议把请求和debug信息写入日志，方便定位问题
        //string debuginfo = reqHandler.getDebugInfo();
        //Response.Write("<br/>requestUrl:" + requestUrl + "<br/>");
        //Response.Write("<br/>debuginfo:" + debuginfo + "<br/>");
    }
}
