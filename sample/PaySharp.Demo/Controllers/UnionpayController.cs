using Microsoft.AspNetCore.Mvc;
using PaySharp.Core;
using PaySharp.Core.Response;
using PaySharp.Unionpay;
using PaySharp.Unionpay.Domain;
using PaySharp.Unionpay.Request;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Demo.Controllers
{
    public class UnionpayController : Controller
    {
        private readonly IGateway _gateway;

        public UnionpayController(IGateways gateways)
        {
            _gateway = gateways.Get<UnionpayGateway>();
        }

        [HttpPost]
        public IActionResult WebPay(string out_trade_no, double total_amount)
        {
            var request = new WebPayRequest();
            request.AddGatewayData(new WebPayModel()
            {
                ToalAmount = total_amount,
                OutTradeNo = out_trade_no
            });

            var response = _gateway.Execute(request);
            return Content(response.Html, "text/html", Encoding.UTF8);
        }

        //[HttpPost]
        //public IActionResult WapPay(string out_trade_no, string subject, double total_amount, string body)
        //{
        //    var request = new WapPayRequest();
        //    request.AddGatewayData(new WapPayModel()
        //    {
        //        Body = body,
        //        TotalAmount = total_amount,
        //        Subject = subject,
        //        OutTradeNo = out_trade_no
        //    });

        //    var response = _gateway.Execute(request);
        //    return Redirect(response.Url);
        //}

        //[HttpPost]
        //public IActionResult AppPay(string out_trade_no, string subject, double total_amount, string body)
        //{
        //    var request = new AppPayRequest();
        //    request.AddGatewayData(new AppPayModel()
        //    {
        //        Body = body,
        //        TotalAmount = total_amount,
        //        Subject = subject,
        //        OutTradeNo = out_trade_no
        //    });

        //    var response = _gateway.Execute(request);
        //    return Json(response);
        //}

        //[HttpPost]
        //public IActionResult ScanPay(string out_trade_no, string subject, double total_amount, string body)
        //{
        //    var request = new ScanPayRequest();
        //    request.AddGatewayData(new ScanPayModel()
        //    {
        //        Body = body,
        //        TotalAmount = total_amount,
        //        Subject = subject,
        //        OutTradeNo = out_trade_no
        //    });

        //    var response = _gateway.Execute(request);

        //    return Json(response);
        //}

        //[HttpPost]
        //public IActionResult BarcodePay(string out_trade_no, string auth_code, string subject, double total_amount, string body)
        //{
        //    var request = new BarcodePayRequest();
        //    request.AddGatewayData(new BarcodePayModel()
        //    {
        //        Body = body,
        //        TotalAmount = total_amount,
        //        Subject = subject,
        //        OutTradeNo = out_trade_no,
        //        AuthCode = auth_code
        //    });
        //    request.PaySucceed += BarcodePay_PaySucceed;
        //    request.PayFailed += BarcodePay_PayFaild;

        //    var response = _gateway.Execute(request);

        //    return Json(response);
        //}

        ///// <summary>
        ///// 支付成功事件
        ///// </summary>
        ///// <param name="response">返回结果</param>
        ///// <param name="message">提示信息</param>
        //private void BarcodePay_PaySucceed(IResponse response, string message)
        //{
        //}

        ///// <summary>
        ///// 支付失败事件
        ///// </summary>
        ///// <param name="response">返回结果,可能是BarcodePayResponse/QueryResponse</param>
        ///// <param name="message">提示信息</param>
        //private void BarcodePay_PayFaild(IResponse response, string message)
        //{
        //}

        //[HttpPost]
        //public IActionResult Query(string out_trade_no, string trade_no)
        //{
        //    var request = new QueryRequest();
        //    request.AddGatewayData(new QueryModel()
        //    {
        //        TradeNo = trade_no,
        //        OutTradeNo = out_trade_no
        //    });

        //    var response = _gateway.Execute(request);
        //    return Json(response);
        //}

        //[HttpPost]
        //public IActionResult Refund(string out_trade_no, string trade_no, double refund_amount, string refund_reason, string out_request_no)
        //{
        //    var request = new RefundRequest();
        //    request.AddGatewayData(new RefundModel()
        //    {
        //        TradeNo = trade_no,
        //        OutTradeNo = out_trade_no,
        //        RefundAmount = refund_amount,
        //        RefundReason = refund_reason,
        //        OutRefundNo = out_request_no
        //    });

        //    var response = _gateway.Execute(request);
        //    return Json(response);
        //}

        //[HttpPost]
        //public IActionResult RefundQuery(string out_trade_no, string trade_no, string out_request_no)
        //{
        //    var request = new RefundQueryRequest();
        //    request.AddGatewayData(new RefundQueryModel()
        //    {
        //        TradeNo = trade_no,
        //        OutTradeNo = out_trade_no,
        //        OutRefundNo = out_request_no
        //    });

        //    var response = _gateway.Execute(request);
        //    return Json(response);
        //}

        //[HttpPost]
        //public IActionResult Cancel(string out_trade_no, string trade_no)
        //{
        //    var request = new CancelRequest();
        //    request.AddGatewayData(new CancelModel()
        //    {
        //        TradeNo = trade_no,
        //        OutTradeNo = out_trade_no
        //    });

        //    var response = _gateway.Execute(request);
        //    return Json(response);
        //}

        //[HttpPost]
        //public IActionResult Close(string out_trade_no, string trade_no)
        //{
        //    var request = new CloseRequest();
        //    request.AddGatewayData(new CloseModel()
        //    {
        //        TradeNo = trade_no,
        //        OutTradeNo = out_trade_no
        //    });

        //    var response = _gateway.Execute(request);
        //    return Json(response);
        //}

        //[HttpPost]
        //public IActionResult Transfer(string out_trade_no, string payee_account, string payee_type, double amount, string remark)
        //{
        //    var request = new TransferRequest();
        //    request.AddGatewayData(new TransferModel()
        //    {
        //        OutTradeNo = out_trade_no,
        //        PayeeAccount = payee_account,
        //        Amount = amount,
        //        Remark = remark,
        //        PayeeType = payee_type
        //    });

        //    var response = _gateway.Execute(request);
        //    return Json(response);
        //}

        //[HttpPost]
        //public IActionResult TransferQuery(string out_trade_no, string trade_no)
        //{
        //    var request = new TransferQueryRequest();
        //    request.AddGatewayData(new TransferQueryModel()
        //    {
        //        TradeNo = trade_no,
        //        OutTradeNo = out_trade_no
        //    });

        //    var response = _gateway.Execute(request);
        //    return Json(response);
        //}

        //[HttpPost]
        //public async Task<IActionResult> BillDownload(string bill_date, string bill_type)
        //{
        //    var request = new BillDownloadRequest();
        //    request.AddGatewayData(new BillDownloadModel()
        //    {
        //        BillDate = bill_date,
        //        BillType = bill_type
        //    });

        //    var response = _gateway.Execute(request);
        //    return File(await response.GetBillFileAsync(), "application/zip");
        //}
    }
}
