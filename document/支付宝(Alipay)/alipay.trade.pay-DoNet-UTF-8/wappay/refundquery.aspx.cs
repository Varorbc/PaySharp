using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using System;
using System.Web.UI;

namespace alipay.wappay
{
    public partial class refundquery : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAlipay_Click(object sender, EventArgs e)
        {
            DefaultAopClient client = new DefaultAopClient(config.gatewayUrl, config.app_id, config.private_key, "json", "1.0", config.sign_type, config.alipay_public_key, config.charset, false);

            // 商户订单号，和交易号不能同时为空
            string out_trade_no = WIDout_trade_no.Text.Trim();

            // 支付宝交易号，和商户订单号不能同时为空
            string trade_no = WIDtrade_no.Text.Trim();

            // 请求退款接口时，传入的退款号，如果在退款时未传入该值，则该值为创建交易时的商户订单号，必填。
            string out_request_no = WIDout_request_no.Text.Trim();

            AlipayTradeFastpayRefundQueryModel model = new AlipayTradeFastpayRefundQueryModel();
            model.OutTradeNo = out_trade_no;
            model.TradeNo = trade_no;
            model.OutRequestNo = out_request_no;

            AlipayTradeFastpayRefundQueryRequest request = new AlipayTradeFastpayRefundQueryRequest();
            request.SetBizModel(model);

            AlipayTradeFastpayRefundQueryResponse response = null;
            try
            {
                response = client.Execute(request);
                WIDresule.Text = response.Body;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}