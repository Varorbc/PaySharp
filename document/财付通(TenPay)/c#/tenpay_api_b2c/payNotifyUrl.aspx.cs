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

public partial class payNotifyUrl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //商户号
        string partner = "1900000109";

        //密钥
        string key = "8934e7d15453e97507ef794cf7b0519d";


        //创建ResponseHandler实例
        ResponseHandler resHandler = new ResponseHandler(Context);
        resHandler.setKey(key);

        //判断签名
        if (resHandler.isTenpaySign())
        {

            ///通知id
            string notify_id = resHandler.getParameter("notify_id");

            //通过通知ID查询，确保通知来至财付通
            //创建查询请求
            RequestHandler queryReq = new RequestHandler(Context);
            queryReq.init();
            queryReq.setKey(key);
            queryReq.setGateUrl("https://gw.tenpay.com/gateway/verifynotifyid.xml");
            queryReq.setParameter("partner", partner);
            queryReq.setParameter("notify_id", notify_id);

            //通信对象
            TenpayHttpClient httpClient = new TenpayHttpClient();
            httpClient.setTimeOut(5);
            //设置请求内容
            httpClient.setReqContent(queryReq.getRequestURL());

            //后台调用
            if (httpClient.call())
            {
                //设置结果参数
                ClientResponseHandler queryRes = new ClientResponseHandler();
                queryRes.setContent(httpClient.getResContent());
                queryRes.setKey(key);

                //判断签名及结果
                //只有签名正确,retcode为0，trade_state为0才是支付成功
                if (queryRes.isTenpaySign() && queryRes.getParameter("retcode") == "0" && queryRes.getParameter("trade_state") == "0" && queryRes.getParameter("trade_mode") == "1")
                {
                    //取结果参数做业务处理
                    string out_trade_no = queryRes.getParameter("out_trade_no");
                    //财付通订单号
                    string transaction_id = queryRes.getParameter("transaction_id");
                    //金额,以分为单位
                    string total_fee = queryRes.getParameter("total_fee");
                    //如果有使用折扣券，discount有值，total_fee+discount=原请求的total_fee
                    string discount = queryRes.getParameter("discount");

                    //------------------------------
                    //处理业务开始
                    //------------------------------

                    //处理数据库逻辑
                    //注意交易单不要重复处理
                    //注意判断返回金额

                    //------------------------------
                    //处理业务完毕
                    //------------------------------
                    //通知财付通已经处理成功，无需重新通知
                    Response.Write("success");

                }
                else
                {
                    //错误时，返回结果可能没有签名，写日志trade_state、retcode、retmsg看失败详情。
                    //通知财付通处理失败，需要重新通知
                    Response.Write("fail");
                }

                //获取查询的debug信息,建议把请求、应答内容、debug信息，通信返回码写入日志，方便定位问题
                /*
                Response.Write("http res:" + httpClient.getResponseCode() + "," + httpClient.getErrInfo() + "<br>");
                Response.Write("query req url:" + queryReq.getRequestURL() + "<br/>");
                Response.Write("query req debug:" + queryReq.getDebugInfo() + "<br/>");
                Response.Write("query res content:" + Server.HtmlEncode(httpClient.getResContent()) + "<br/>");
                Response.Write("query res debug:" + Server.HtmlEncode(queryRes.getDebugInfo()) + "<br/>");
                 */
                


            }
            else
            {
                //通知财付通处理失败，需要重新通知
                Response.Write("fail");
                //写错误日志
                Response.Write("call err:" + httpClient.getErrInfo() + "<br>" + httpClient.getResponseCode() + "<br>");

            }

            //获取debug信息,建议把debug信息写入日志，方便定位问题
            /*
            string debuginfo = resHandler.getDebugInfo();
            Response.Write("<br/>debuginfo:" + debuginfo + "<br/>");
            */
        }
    }
}
