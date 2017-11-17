using ICanPay.Core;
using Microsoft.AspNetCore.Mvc;

namespace ICanPay.Demo.Controllers
{
    public class CancelController : Controller
    {
        private readonly IGateways gateways;

        public CancelController(IGateways gateways)
        {
            this.gateways = gateways;
        }

        public IActionResult Index(string id)
        {
            var notify = CancelAlipayOrder(id);

            return Json(notify);
        }

        /// <summary>
        /// 撤销支付宝的订单
        /// </summary>
        private Alipay.Notify CancelAlipayOrder(string id)
        {
            var gateway = gateways.Get<Alipay.AlipayGateway>();

            return (Alipay.Notify)gateway.Cancel(new Alipay.Auxiliary
            {
                OutTradeNo = id
            });
        }

        /// <summary>
        /// 撤销微信的订单
        /// </summary>
        private Wechatpay.Notify CancelWechatpayOrder(string id)
        {
            var gateway = gateways.Get<Wechatpay.WechatpayGateway>();

            return (Wechatpay.Notify)gateway.Cancel(new Wechatpay.Auxiliary
            {
                OutTradeNo = id
            });
        }
    }
}
