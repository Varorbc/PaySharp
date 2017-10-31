using ICanPay.Core;
using Microsoft.AspNetCore.Mvc;

namespace ICanPay.Demo.Controllers
{
    public class BillDownloadController : Controller
    {
        private IGateways gateways;

        public BillDownloadController(IGateways gateways)
        {
            this.gateways = gateways;
        }

        public IActionResult Index()
        {
            AlipayBillDownload();

            return Ok();
        }

        /// <summary>
        /// 支付宝对账单下载
        /// </summary>
        private void AlipayBillDownload()
        {
            var gateway = gateways.Get(GatewayType.Alipay);
            gateway.Order = new Alipay.Order
            {
                OutTradeNo = "123"
            };

            gateway.BillDownload("trade", "2017-10");
        }
    }
}
