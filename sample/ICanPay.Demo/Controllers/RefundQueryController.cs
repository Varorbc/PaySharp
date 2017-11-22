using ICanPay.Core;
using Microsoft.AspNetCore.Mvc;

namespace ICanPay.Demo.Controllers
{
    public class RefundQueryController : Controller
    {
        private readonly IGateways gateways;

        public RefundQueryController(IGateways gateways)
        {
            this.gateways = gateways;
        }

        public IActionResult Index(string id)
        {
            var notify = RefundQueryAlipayOrder(id);

            return Json(notify);
        }

        /// <summary>
        /// 查询支付宝的订单
        /// </summary>
        private Alipay.Notify RefundQueryAlipayOrder(string id)
        {
            var gateway = gateways.Get<Alipay.AlipayGateway>();

            return (Alipay.Notify)gateway.RefundQuery(new Alipay.Auxiliary
            {
                OutTradeNo = id,
                OutRefundNo = "13"
            });
        }

        /// <summary>
        /// 查询微信的订单
        /// </summary>
        private Wechatpay.Notify RefundQueryWechatpayOrder(string id)
        {
            var gateway = gateways.Get<Wechatpay.WechatpayGateway>();

            return (Wechatpay.Notify)gateway.RefundQuery(new Wechatpay.Auxiliary
            {
                OutTradeNo = id
            });
        }
    }
}
