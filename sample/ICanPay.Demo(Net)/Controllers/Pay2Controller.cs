using ICanPay.Core;
using System;
using System.Web.Http;

namespace ICanPay.Demo_Net_.Controllers
{
    public class Pay2Controller : ApiController
    {
        private readonly IGateways _gateways;
        private readonly string outTradeNo = DateTime.Now.ToString("yyyyMMddhhmmss");

        public Pay2Controller(IGateways gateways)
        {
            _gateways = gateways;
        }

        [HttpGet]
        public IHttpActionResult Index()
        {
            var content = CreateAlipayOrder();

            return Ok(content.ToString());
        }

        /// <summary>
        /// 创建支付宝的支付订单
        /// </summary>
        private object CreateAlipayOrder()
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