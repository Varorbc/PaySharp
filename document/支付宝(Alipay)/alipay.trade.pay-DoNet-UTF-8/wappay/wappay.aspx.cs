using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using System;
using System.Web.UI;

namespace alipay.wappay
{
    public partial class wappay : Page
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

            // 支付中途退出返回商户网站地址
            string quit_url = WIDquit_url.Text.Trim();

            // 组装业务参数model
            AlipayTradeWapPayModel model = new AlipayTradeWapPayModel();
            model.Body = body;
            model.Subject = subject;
            model.TotalAmount = total_amout;
            model.OutTradeNo = out_trade_no;
            model.ProductCode = "QUICK_WAP_PAY";
            model.QuitUrl = quit_url;

            AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
            // 设置支付完成同步回调地址
            // request.SetReturnUrl("");
            // 设置支付完成异步通知接收地址
            // request.SetNotifyUrl("");
            // 将业务model载入到request
            request.SetBizModel(model);

            AlipayTradeWapPayResponse response = null;
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