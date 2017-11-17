using ICanPay.Core;
using Microsoft.AspNetCore.Mvc;

namespace ICanPay.Demo.Controllers
{
    public class RefundController : Controller
    {
        private readonly IGateways gateways;

        public RefundController(IGateways gateways)
        {
            this.gateways = gateways;
        }

        public IActionResult Index(string id)
        {
            var notify = RefundAlipayOrder(id);

            return Json(notify);
        }

        /// <summary>
        /// 支付宝的订单的退款
        /// </summary>
        private Alipay.Notify RefundAlipayOrder(string id)
        {
            var gateway = gateways.Get<Alipay.AlipayGateway>();

            return (Alipay.Notify)gateway.Refund(new Alipay.Auxiliary
            {
                OutTradeNo = id,
                RefundAmount = 123,
                OutRefundNo = "13"
            });
        }

        /// <summary>
        /// 微信的订单的退款
        /// </summary>
        private Wechatpay.Notify RefundWechatpayOrder(string id)
        {
            var gateway = gateways.Get<Wechatpay.WechatpayGateway>();

            return (Wechatpay.Notify)gateway.Refund(new Wechatpay.Auxiliary
            {
                OutTradeNo = id
            });
        }
    }
}
