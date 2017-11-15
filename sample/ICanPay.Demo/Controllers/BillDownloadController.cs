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
            WechatpayBillDownload();

            return Ok();
        }

        /// <summary>
        /// 支付宝对账单下载
        /// </summary>
        private void AlipayBillDownload()
        {
            var gateway = gateways.Get<Alipay.AlipayGateway>();

            gateway.BillDownload(new Alipay.Auxiliary
            {
                BillType = "trade",
                BillDate = "2017-10-31"
            });
        }

        /// <summary>
        /// 微信对账单下载
        /// </summary>
        private void WechatpayBillDownload()
        {
            var gateway = gateways.Get<Wechatpay.WechatpayGateway>();

            gateway.BillDownload(new Wechatpay.Auxiliary
            {
                BillType = "ALL",
                BillDate = "20171002"
            });
        }
    }
}
