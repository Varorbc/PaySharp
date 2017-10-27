using ICanPay.Alipay;
using ICanPay.Core;
using ICanPay.Wechatpay;
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
        /// 关闭微信的订单
        /// </summary>
        private void CancelWechatpayOrder()
        {

        }
    }
}
