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

            gateway.BillDownload(new Alipay.Auxiliary
            {
                BillType = "trade",
                BillDate = "2017-10-31"
            });
        }
    }
}
