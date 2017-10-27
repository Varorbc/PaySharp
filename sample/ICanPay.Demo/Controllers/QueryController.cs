using ICanPay.Core;
using Microsoft.AspNetCore.Mvc;

namespace ICanPay.Demo.Controllers
{
    public class QueryController : Controller
    {
        private IGateways gateways;

        public QueryController(IGateways gateways)
        {
            this.gateways = gateways;
        }

        public IActionResult Index()
        {
            QueryAlipayOrder();

            return Ok();
        }

        /// <summary>
        /// 查询支付宝的订单
        /// </summary>
        private Alipay.Notify QueryAlipayOrder()
        {
            var gateway = gateways.Get(GatewayType.Alipay);
            gateway.Order = new Alipay.Order
            {
                OutTradeNo = "123"
            };

            return (Alipay.Notify)gateway.Query();
        }

        /// <summary>
        /// 查询微信的订单
        /// </summary>
        private Wechatpay.Notify QueryWechatpayOrder()
        {
            var gateway = gateways.Get(GatewayType.Wechatpay);
            gateway.Order = new Wechatpay.Order
            {
                OutTradeNo = "123"
            };

            return (Wechatpay.Notify)gateway.Query();
        }
    }
}
