using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using System;
using System.Web.UI;

namespace alipay.wappay
{
    public partial class refund : Page
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

            // 退款金额，不能大于订单总金额
            string refund_amount = WIDrefund_amount.Text.Trim();

            // 退款原因
            string refund_reason = WIDrefund_reason.Text.Trim();

            // 退款单号，同一笔多次退款需要保证唯一，部分退款该参数必填。
            string out_request_no = WIDout_request_no.Text.Trim();

            AlipayTradeRefundModel model = new AlipayTradeRefundModel();
            model.OutTradeNo = out_trade_no;
            model.TradeNo = trade_no;
            model.RefundAmount = refund_amount;
            model.RefundReason = refund_reason;
            model.OutRequestNo = out_request_no;

            AlipayTradeRefundRequest request = new AlipayTradeRefundRequest();
            request.SetBizModel(model);

            AlipayTradeRefundResponse response = null;
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