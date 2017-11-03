using ICanPay.Core;
using Microsoft.AspNetCore.Mvc;

namespace ICanPay.Demo.Controllers
{
    public class CloseController : Controller
    {
        private readonly IGateways gateways;

        public CloseController(IGateways gateways)
        {
            this.gateways = gateways;
        }

        public IActionResult Index(string id)
        {
            var notify = (Alipay.Notify)CloseAlipayOrder(id);

            return Json(notify);
        }

        /// <summary>
        /// 关闭支付宝的订单
        /// </summary>
        private Alipay.Notify CloseAlipayOrder(string id)
        {
            var gateway = gateways.Get<Alipay.AlipayGateway>();

            return (Alipay.Notify)gateway.Close(new Alipay.Auxiliary
            {
                OutTradeNo = id
            });
        }

        /// <summary>
        /// 关闭微信的订单
        /// </summary>
        private Wechatpay.Notify CloseWechatpayOrder(string id)
        {
            var gateway = gateways.Get<Wechatpay.WechatpayGataway>();

            return (Wechatpay.Notify)gateway.Query(new Wechatpay.Auxiliary
            {
                OutTradeNo = id
            });
        }
    }
}
