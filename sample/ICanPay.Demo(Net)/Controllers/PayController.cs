using ICanPay.Core;
using ICanPay.Core.Utils;
using System;
using System.Drawing.Imaging;
using System.IO;
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
            var content = CreateAlipayOrder();

            return Content(content.ToString());
        }

        [HttpGet]
        public ActionResult GetQrCode()
        {
            var bitMap = QrCodeUtil.Create("123", 300, 300);
            MemoryStream ms = new MemoryStream();
            bitMap.Save(ms, ImageFormat.Jpeg);
            bitMap.Dispose();
            return File(ms.ToArray(), "image/jpeg");
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