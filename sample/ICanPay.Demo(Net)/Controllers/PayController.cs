using ICanPay.Core;
using System;
using System.Web.Mvc;

namespace ICanPay.Demo_Net_.Controllers
{
    public class PayController : Controller
    {
        private readonly IGateways _gateways;
        private readonly string outTradeNo = DateTime.Now.ToString("yyyyMMddhhmmss");

        public PayController(IGateways gateways)
        {
            _gateways = gateways;
        }

        [HttpGet]
        public ActionResult Index()
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
                Subject = "测测看支付宝"
            };

            var gateway = _gateways.Get<Alipay.AlipayGateway>(GatewayTradeType.Web);

            return gateway.Payment(order);
        }
    }
}