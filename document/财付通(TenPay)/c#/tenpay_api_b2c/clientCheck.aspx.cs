using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using tenpay;

public partial class clientQueryRefund : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //商户号
        string partner = "1900000109";


        //密钥
        string key = "8934e7d15453e97507ef794cf7b0519d";

        //创建请求对象
        CheckRequestHandler reqHandler = new CheckRequestHandler(Context);

        //通信对象
        TenpayHttpClient httpClient = new TenpayHttpClient();

  
        //-----------------------------
        //设置请求参数
        //-----------------------------
        reqHandler.init();
        reqHandler.setKey(key);


        reqHandler.setParameter("spid", partner);
        reqHandler.setParameter("trans_time", "2011-10-12");
        reqHandler.setParameter("stamp", TenpayUtil.UnixStamp().ToString());
        reqHandler.setParameter("cft_signtype", "0");
        reqHandler.setParameter("mchtype", "0");

        string requestUrl = reqHandler.getRequestURL();

        //设置请求内容
        httpClient.setReqContent(requestUrl);
        //设置超时
        httpClient.setTimeOut(10);

        string rescontent = "";
        //后台调用
        
        if (httpClient.call())
        {
            //获取结果
            rescontent = httpClient.getResContent();


            Response.Write("OK,内容:<br>\r\n" + httpClient.getResContent() + "<br>");
            
        }
        else
        {
            //后台调用通信失败
            Response.Write("call err:" + httpClient.getErrInfo() + "<br>" + httpClient.getResponseCode() + "<br>");
            //有可能因为网络原因，请求已经处理，但未收到应答。
        }

        


        //获取debug信息,建议把请求、应答内容、debug信息，通信返回码写入日志，方便定位问题
        /*
        Response.Write("http res:" + httpClient.getResponseCode() + "," + httpClient.getErrInfo() + "<br>");
        Response.Write("req url:" + requestUrl + "<br/>");
        Response.Write("req debug:" + reqHandler.getDebugInfo() + "<br/>");

         */
    }
}
