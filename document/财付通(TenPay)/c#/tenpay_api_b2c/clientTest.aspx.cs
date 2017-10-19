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

public partial class clientTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //商户号
        string partner = "1900000107";

        //密钥
        string key = "82d2f8b9fd7695aec51415ab2900a755";

        //创建请求对象
        RequestHandler reqHandler = new RequestHandler(Context);

        //通信对象
        TenpayHttpClient httpClient = new TenpayHttpClient();

        //应答对象
        ClientResponseHandler resHandler = new ClientResponseHandler();

        //-----------------------------
        //设置请求参数
        //-----------------------------
        reqHandler.init();
        reqHandler.setKey(key);
        reqHandler.setGateUrl("https://gw.tenpay.com/gateway/normalrefundquery.xml");
        //reqHandler.setGateUrl("https://api.mch.tenpay.com/refundapi/gateway/normalrefundquery.xml");

        reqHandler.setParameter("partner", partner);
        //out_trade_no和transaction_id至少一个必填，同时存在时transaction_id优先
        reqHandler.setParameter("out_trade_no", "1144357708");
        //reqHandler.setParameter("transaction_id", "1900000107201011300017102199");

        string requestUrl = reqHandler.getRequestURL();
        requestUrl = "http://localhost:8180/test/test.jsp";
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
            /*
            resHandler.setKey(key);
            //设置结果参数
            resHandler.setContent(rescontent);

            //判断签名及结果
            if (resHandler.isTenpaySign() && resHandler.getParameter("retcode") == "0")
            {
                //商户订单号
                string out_trade_no = resHandler.getParameter("out_trade_no");
                //财付通订单号
                string transaction_id = resHandler.getParameter("transaction_id");
                //金额,以分为单位
                string total_fee = resHandler.getParameter("total_fee");
                //如果有使用折扣券，discount有值，total_fee+discount=原请求的total_fee
                string discount = resHandler.getParameter("discount");
                string refund_state_0 = resHandler.getParameter("refund_state_0");

                Response.Write("OK,transaction_id=" + resHandler.getParameter("transaction_id") + ", refund_state_0=" + refund_state_0 + "<br>");


            }
            else
            {
                //错误时，返回结果未签名。
                //如包格式错误或未确认结果的，请使用原来订单号重新发起，确认结果，避免多次操作
                Response.Write("业务错误信息或签名错误:" + resHandler.getParameter("retcode") + "," + resHandler.getParameter("retmsg") + "<br>");
            }
             * */


        }
        else
        {
            //后台调用通信失败
            Response.Write("call err:" + httpClient.getErrInfo() + "<br>" + httpClient.getResponseCode() + "<br>");
            //有可能因为网络原因，请求已经处理，但未收到应答。
        }


        //获取debug信息,建议把请求、应答内容、debug信息，通信返回码写入日志，方便定位问题

        Response.Write("http res:" + httpClient.getResponseCode() + "," + httpClient.getErrInfo() + "<br>");
        Response.Write("req url:" + requestUrl + "<br/>");
        Response.Write("req debug:" + reqHandler.getDebugInfo() + "<br/>");
        Response.Write("res content:" + Server.HtmlEncode(rescontent) + "<br/>");
        Response.Write("res debug:" + Server.HtmlEncode(resHandler.getDebugInfo()) + "<br/>");
    }
}
