using ICanPay.Alipay;
using ICanPay.Alipay.Domain;
using ICanPay.Alipay.Request;
using ICanPay.Core;
using ICanPay.Core.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ICanPay.Demo.Controllers
{
    public class AlipayController : Controller
    {
        private readonly BaseGateway _baseGateway;

        public AlipayController(IGateways gateways)
        {
            _baseGateway = gateways.Get<AlipayGateway>();
        }

        [HttpPost]
        public IActionResult WebPay(string out_trade_no, string subject, double total_amount, string body)
        {
            var request = new WebPayRequest();
            request.AddGatewayData(new WebPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                Subject = subject,
                OutTradeNo = out_trade_no
            });

            var response = _baseGateway.Execute(request);
            return Content(response.Html, "text/html", Encoding.UTF8);
        }

        [HttpPost]
        public IActionResult WapPay(string out_trade_no, string subject, double total_amount, string body)
        {
            var request = new WapPayRequest();
            request.AddGatewayData(new WapPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                Subject = subject,
                OutTradeNo = out_trade_no
            });

            var response = _baseGateway.Execute(request);
            return Redirect(response.Url);
        }

        [HttpPost]
        public IActionResult AppPay(string out_trade_no, string subject, double total_amount, string body)
        {
            var request = new AppPayRequest();
            request.AddGatewayData(new AppPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                Subject = subject,
                OutTradeNo = out_trade_no
            });

            var response = _baseGateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public IActionResult ScanPay(string out_trade_no, string subject, double total_amount, string body)
        {
            var request = new ScanPayRequest();
            request.AddGatewayData(new ScanPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                Subject = subject,
                OutTradeNo = out_trade_no
            });

            var response = _baseGateway.Execute(request);

            return Json(response);
        }

        [HttpPost]
        public IActionResult BarcodePay(string out_trade_no, string auth_code, string subject, double total_amount, string body)
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

            var response = _baseGateway.Execute(request);

            return Json(response);
        }

        /// <summary>
        /// 支付成功事件
        /// </summary>
        /// <param name="response">返回结果</param>
        /// <param name="message">提示信息</param>
        private void BarcodePay_PaySucceed(IResponse response, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 支付失败事件
        /// </summary>
        /// <param name="response">返回结果,可能是BarcodePayResponse/QueryResponse</param>
        /// <param name="message">提示信息</param>
        private void BarcodePay_PayFaild(IResponse response, string message)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Query(string out_trade_no, string trade_no)
        {
            var request = new QueryRequest();
            request.AddGatewayData(new QueryModel()
            {
                TradeNo = trade_no,
                OutTradeNo = out_trade_no
            });

            var response = _baseGateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public IActionResult Refund(string out_trade_no, string trade_no, double refund_amount, string refund_reason, string out_request_no)
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

            var response = _baseGateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public IActionResult RefundQuery(string out_trade_no, string trade_no, string out_request_no)
        {
            var request = new RefundQueryRequest();
            request.AddGatewayData(new RefundQueryModel()
            {
                TradeNo = trade_no,
                OutTradeNo = out_trade_no,
                OutRefundNo = out_request_no
            });

            var response = _baseGateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public IActionResult Close(string out_trade_no, string trade_no)
        {
            var request = new CloseRequest();
            request.AddGatewayData(new CloseModel()
            {
                TradeNo = trade_no,
                OutTradeNo = out_trade_no
            });

            var response = _baseGateway.Execute(request);
            return Json(response);
        }

        //[HttpPost]
        //public async Task<IActionResult> Trans(string out_biz_no, string payee_account, string payee_type, string amount, string remark)
        //{
        //    var model = new AlipayFundTransToaccountTransferModel()
        //    {
        //        OutBizNo = out_biz_no,
        //        PayeeType = payee_type,
        //        PayeeAccount = payee_account,
        //        Amount = amount,
        //        Remark = remark
        //    };
        //    var req = new AlipayFundTransToaccountTransferRequest();
        //    req.SetBizModel(model);
        //    var response = await _client.ExecuteAsync(req);
        //    return Ok(response.Body);
        //}

        //[HttpPost]
        //public async Task<IActionResult> TransQuery(string out_biz_no, string order_id)
        //{
        //    var model = new AlipayFundTransOrderQueryModel()
        //    {
        //        OutBizNo = out_biz_no,
        //        OrderId = order_id,
        //    };

        //    var req = new AlipayFundTransOrderQueryRequest();
        //    req.SetBizModel(model);
        //    var response = await _client.ExecuteAsync(req);
        //    return Ok(response.Body);
        //}

        [HttpPost]
        public async Task<IActionResult> BillDownload(string bill_date, string bill_type)
        {
            var request = new BillDownloadRequest();
            request.AddGatewayData(new BillDownloadModel()
            {
                BillDate = bill_date,
                BillType = bill_type
            });

            var response = _baseGateway.Execute(request);
            return File(await response.GetBillFileAsync(), "application/zip");
        }
    }
}
