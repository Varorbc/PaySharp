using ICanPay.Alipay.Domain;
using ICanPay.Alipay.Request;
using ICanPay.Core;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ICanPay.Demo.Controllers
{
    public class PayController : Controller
    {
        private readonly IGateways gateways;
        private readonly string outTradeNo = DateTime.Now.ToString("yyyyMMddhhmmss");

        public PayController(IGateways gateways)
        {
            this.gateways = gateways;
        }

        public IActionResult Index()
        {
            string content = CreateAlipayOrder();

            return Content(content, "text/html");
        }

        /// <summary>
        /// 创建支付宝的支付订单
        /// </summary>
        private string CreateAlipayOrder()
        {
            var gateway = gateways.Get<Alipay.AlipayGateway>();

            var webPayRequest = new WebPayRequest();
            webPayRequest.AddGatewayData(new WebPayModel
            {
                TotalAmount = 1,
                OutTradeNo = outTradeNo,
                Subject = "测测看支付宝",
            });
            var webPayResponse = gateway.SdkExecute(webPayRequest);

            var barcodePayRequest = new BarcodePayRequest();
            barcodePayRequest.PaySucceed += BarcodePayRequest_PaySucceed;

            return webPayResponse.Html;
        }

        private void BarcodePayRequest_PaySucceed(object arg1, PaySucceedEventArgs arg2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建微信的支付订单
        /// </summary>
        private string CreateWechatpayOrder()
        {
            var order = new Wechatpay.Order()
            {
                ProductId = "123",
                Amount = 0.01,
                OutTradeNo = outTradeNo,
                Body = "测测看微信支付"
            };

            var gateway = gateways.Get<Wechatpay.WechatpayGateway>(GatewayTradeType.Scan);

            return gateway.Payment(order);
        }

        /// <summary>
        /// 创建银联支付订单
        /// </summary>
        private string CreateUnionpayOrder()
        {
            var order = new Unionpay.Order()
            {
                Amount = 0.01,
                OutTradeNo = outTradeNo
            };

            var gateway = gateways.Get<Unionpay.UnionpayGateway>(GatewayTradeType.Web);

            return gateway.Payment(order);
        }
    }
}
