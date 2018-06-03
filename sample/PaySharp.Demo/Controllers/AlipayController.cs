using PaySharp.Alipay;
using PaySharp.Alipay.Domain;
using PaySharp.Alipay.Request;
using PaySharp.Core;
using PaySharp.Core.Response;
#if NETCOREAPP
using Microsoft.AspNetCore.Mvc;
#else
using System.Web.Mvc;
#endif
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Demo.Controllers
{
    public class AlipayController : Controller
    {
        private readonly IGateway _gateway;

        public AlipayController(IGateways gateways)
        {
            _gateway = gateways.Get<AlipayGateway>();
        }

        [HttpPost]
        public ActionResult WebPay(string out_trade_no, string subject, double total_amount, string body)
        {
            var request = new WebPayRequest();
            request.AddGatewayData(new WebPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                Subject = subject,
                OutTradeNo = out_trade_no
            });

            var response = _gateway.Execute(request);
            return Content(response.Html, "text/html", Encoding.UTF8);
        }

        [HttpPost]
        public ActionResult WapPay(string out_trade_no, string subject, double total_amount, string body)
        {
            var request = new WapPayRequest();
            request.AddGatewayData(new WapPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                Subject = subject,
                OutTradeNo = out_trade_no
            });

            var response = _gateway.Execute(request);
            return Redirect(response.Url);
        }

        [HttpPost]
        public ActionResult AppPay(string out_trade_no, string subject, double total_amount, string body)
        {
            var request = new AppPayRequest();
            request.AddGatewayData(new AppPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                Subject = subject,
                OutTradeNo = out_trade_no
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult ScanPay(string out_trade_no, string subject, double total_amount, string body)
        {
            var request = new ScanPayRequest();
            request.AddGatewayData(new ScanPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                Subject = subject,
                OutTradeNo = out_trade_no
            });

            var response = _gateway.Execute(request);

            return Json(response);
        }

        [HttpPost]
        public ActionResult BarcodePay(string out_trade_no, string auth_code, string subject, double total_amount, string body)
        {
            var request = new BarcodePayRequest();
            request.AddGatewayData(new BarcodePayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                Subject = subject,
                OutTradeNo = out_trade_no,
                AuthCode = auth_code
            });
            request.PaySucceed += BarcodePay_PaySucceed;
            request.PayFailed += BarcodePay_PayFaild;

            var response = _gateway.Execute(request);

            return Json(response);
        }

        /// <summary>
        /// 支付成功事件
        /// </summary>
        /// <param name="response">返回结果</param>
        /// <param name="message">提示信息</param>
        private void BarcodePay_PaySucceed(IResponse response, string message)
        {
        }

        /// <summary>
        /// 支付失败事件
        /// </summary>
        /// <param name="response">返回结果,可能是BarcodePayResponse/QueryResponse</param>
        /// <param name="message">提示信息</param>
        private void BarcodePay_PayFaild(IResponse response, string message)
        {
        }

        [HttpPost]
        public ActionResult Query(string out_trade_no, string trade_no)
        {
            var request = new QueryRequest();
            request.AddGatewayData(new QueryModel()
            {
                TradeNo = trade_no,
                OutTradeNo = out_trade_no
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult Refund(string out_trade_no, string trade_no, double refund_amount, string refund_reason, string out_request_no)
        {
            var request = new RefundRequest();
            request.AddGatewayData(new RefundModel()
            {
                TradeNo = trade_no,
                OutTradeNo = out_trade_no,
                RefundAmount = refund_amount,
                RefundReason = refund_reason,
                OutRefundNo = out_request_no
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult RefundQuery(string out_trade_no, string trade_no, string out_request_no)
        {
            var request = new RefundQueryRequest();
            request.AddGatewayData(new RefundQueryModel()
            {
                TradeNo = trade_no,
                OutTradeNo = out_trade_no,
                OutRefundNo = out_request_no
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult Cancel(string out_trade_no, string trade_no)
        {
            var request = new CancelRequest();
            request.AddGatewayData(new CancelModel()
            {
                TradeNo = trade_no,
                OutTradeNo = out_trade_no
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult Close(string out_trade_no, string trade_no)
        {
            var request = new CloseRequest();
            request.AddGatewayData(new CloseModel()
            {
                TradeNo = trade_no,
                OutTradeNo = out_trade_no
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult Transfer(string out_trade_no, string payee_account, string payee_type, double amount, string remark)
        {
            var request = new TransferRequest();
            request.AddGatewayData(new TransferModel()
            {
                OutTradeNo = out_trade_no,
                PayeeAccount = payee_account,
                Amount = amount,
                Remark = remark,
                PayeeType = payee_type
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult TransferQuery(string out_trade_no, string trade_no)
        {
            var request = new TransferQueryRequest();
            request.AddGatewayData(new TransferQueryModel()
            {
                TradeNo = trade_no,
                OutTradeNo = out_trade_no
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> BillDownload(string bill_date, string bill_type)
        {
            var request = new BillDownloadRequest();
            request.AddGatewayData(new BillDownloadModel()
            {
                BillDate = bill_date,
                BillType = bill_type
            });

            var response = _gateway.Execute(request);
            return File(await response.GetBillFileAsync(), "application/zip");
        }
    }
}
