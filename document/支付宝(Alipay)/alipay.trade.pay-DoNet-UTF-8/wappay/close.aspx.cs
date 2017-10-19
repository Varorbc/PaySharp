using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using System;
using System.Web.UI;

namespace alipay.wappay
{
    public partial class close : Page
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

            AlipayTradeCloseModel model = new AlipayTradeCloseModel();
            model.OutTradeNo = out_trade_no;
            model.TradeNo = trade_no;

            AlipayTradeCloseRequest request = new AlipayTradeCloseRequest();
            request.SetBizModel(model);

            AlipayTradeCloseResponse response = null;
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