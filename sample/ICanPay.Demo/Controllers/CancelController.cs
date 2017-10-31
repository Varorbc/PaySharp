using ICanPay.Core;
using Microsoft.AspNetCore.Mvc;

namespace ICanPay.Demo.Controllers
{
    public class CancelController : Controller
    {
        private IGateways gateways;

        public CancelController(IGateways gateways)
        {
            this.gateways = gateways;
        }

        public IActionResult Index()
        {
            CancelAlipayOrder();

            return Ok();
        }

        /// <summary>
        /// 撤销支付宝的订单
        /// </summary>
        private Alipay.Notify CancelAlipayOrder()
        {
            var gateway = gateways.Get(GatewayType.Alipay);
            gateway.Order = new Alipay.Order
            {
                OutTradeNo = "123"
            };

            return (Alipay.Notify)gateway.Cancel();
        }

        /// <summary>
        /// 撤销微信的订单
        /// </summary>
        private Wechatpay.Notify CancelWechatpayOrder()
        {
            var gateway = gateways.Get(GatewayType.Wechatpay);
            gateway.Order = new Wechatpay.Order
            {
                OutTradeNo = "123"
            };

            return (Wechatpay.Notify)gateway.Cancel();
        }
    }
}
