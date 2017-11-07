using ICanPay.Core;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ICanPay.Demo.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IGateways gateways;
        private readonly string outTradeNo = DateTime.Now.ToString("yyyyMMddhhmmss");

        public PaymentController(IGateways gateways)
        {
            this.gateways = gateways;
        }

        public IActionResult Index()
        {
            string content = CreateAlipayOrder();

            return Content(content);
        }

        /// <summary>
        /// 创建支付宝的支付订单
        /// </summary>
        private string CreateAlipayOrder()
        {
            var order = new Alipay.Order()
            {
                Amount = 0.01,
                OutTradeNo = outTradeNo,
                Subject = "测测看支付宝",
                //AuthCode = "12323",
                //Scene = Alipay.Constant.BAR_CODE
                //Body = "1234",
                //ExtendParams = new ExtendParam()
                //{
                //    HbFqNum = "3"
                //},
                //GoodsDetail = new Goods[] {
                //    new Goods()
                //    {
                //        Id = "12"
                //    }
                //}
            };

            var gateway = gateways.Get<Alipay.AlipayGateway>(GatewayTradeType.Web);

            //gateway.PaymentFailed += Gateway_BarcodePaymentFailed;

            return gateway.Payment(order);
        }

        private void Gateway_BarcodePaymentFailed(object arg1, PaymentFailedEventArgs arg2)
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
                Amount = 0.01,
                OutTradeNo = outTradeNo,
                Body = "测测看微信支付",
                AuthCode = "123"
            };

            var gateway = gateways.Get<Wechatpay.WechatpayGataway>(GatewayTradeType.Barcode);

            return gateway.Payment(order);
        }
    }
}
