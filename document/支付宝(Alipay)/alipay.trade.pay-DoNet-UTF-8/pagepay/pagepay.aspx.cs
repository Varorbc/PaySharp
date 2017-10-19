using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using System;

namespace alipay.pagepay
{
    public partial class pagepay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAlipay_Click(object sender, EventArgs e)
        {

            DefaultAopClient client = new DefaultAopClient(config.gatewayUrl, config.app_id, config.private_key, "json", "1.0", config.sign_type, config.alipay_public_key, config.charset, false);

            // 外部订单号，商户网站订单系统中唯一的订单号
            string out_trade_no = WIDout_trade_no.Text.Trim();

            // 订单名称
            string subject = WIDsubject.Text.Trim();

            // 付款金额
            string total_amout = WIDtotal_amount.Text.Trim();

            // 商品描述
            string body = WIDbody.Text.Trim();

            // 组装业务参数model
            AlipayTradePagePayModel model = new AlipayTradePagePayModel();
            model.Body = body;
            model.Subject = subject;
            model.TotalAmount = total_amout;
            model.OutTradeNo = out_trade_no;
            model.ProductCode = "FAST_INSTANT_TRADE_PAY";

            AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
            // 设置同步回调地址
            request.SetReturnUrl("");
            // 设置异步通知接收地址
            request.SetNotifyUrl("");
            // 将业务model载入到request
            request.SetBizModel(model);

            AlipayTradePagePayResponse response = null;
            try
            {
                response = client.pageExecute(request, null, "post");
                Response.Write(response.Body);
            }
            catch (Exception exp)
            {
                throw exp;
            }


        }
    }
}