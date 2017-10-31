using ICanPay.Core;
using Microsoft.AspNetCore.Mvc;

namespace ICanPay.Demo.Controllers
{
    public class CloseController : Controller
    {
        private IGateways gateways;

        public CloseController(IGateways gateways)
        {
            this.gateways = gateways;
        }

        public IActionResult Index()
        {
            CloseAlipayOrder();

            return Ok();
        }

        /// <summary>
        /// 关闭支付宝的订单
        /// </summary>
        private Alipay.Notify CloseAlipayOrder()
        {
            var gateway = gateways.Get(GatewayType.Alipay);
            gateway.Order = new Alipay.Order
            {
                OutTradeNo = "123"
            };

            return (Alipay.Notify)gateway.Close();
        }

        /// <summary>
        /// 关闭微信的订单
        /// </summary>
        private Wechatpay.Notify CloseWechatpayOrder()
        {
            var gateway = gateways.Get(GatewayType.Wechatpay);
            gateway.Order = new Wechatpay.Order
            {
                OutTradeNo = "123"
            };

            return (Wechatpay.Notify)gateway.Close();
        }
    }
}
