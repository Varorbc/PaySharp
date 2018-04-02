using ICanPay.Core;
using ICanPay.Core.Response;
using ICanPay.Wechatpay;
using ICanPay.Wechatpay.Domain;
using ICanPay.Wechatpay.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ICanPay.Demo.Controllers
{
    public class WechatpayController : Controller
    {
        private readonly BaseGateway _baseGateway;

        public WechatpayController(IGateways gateways)
        {
            _baseGateway = gateways.Get<WechatpayGateway>();
        }

        [HttpPost]
        public IActionResult PublicPay(string out_trade_no, int total_amount, string body, string open_id, string spbill_create_ip)
        {
            var request = new PublicPayRequest();
            request.AddGatewayData(new PublicPayModel()
            {
                Body = body,
                OutTradeNo = out_trade_no,
                SpbillCreateIp = spbill_create_ip,
                TotalAmount = total_amount,
                OpenId = open_id
            });

            var response = _baseGateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public IActionResult AppPay(string out_trade_no, int total_amount, string body, string spbill_create_ip)
        {
            var request = new AppPayRequest();
            request.AddGatewayData(new AppPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                OutTradeNo = out_trade_no,
                SpbillCreateIp = spbill_create_ip
            });

            var response = _baseGateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public IActionResult AppletPay(string out_trade_no, int total_amount, string body, string open_id, string spbill_create_ip)
        {
            var request = new AppletPayRequest();
            request.AddGatewayData(new AppletPayModel()
            {
                Body = body,
                OutTradeNo = out_trade_no,
                SpbillCreateIp = spbill_create_ip,
                TotalAmount = total_amount,
                OpenId = open_id
            });

            var response = _baseGateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public IActionResult WapPay(string out_trade_no, int total_amount, string body, string spbill_create_ip, string scene_info)
        {
            var request = new WapPayRequest();
            request.AddGatewayData(new WapPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                OutTradeNo = out_trade_no,
                SpbillCreateIp = spbill_create_ip,
                SceneInfo = scene_info
            });

            var response = _baseGateway.Execute(request);
            return Json(response);
        }

        /*[HttpPost]
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
        public IActionResult Cancel(string out_trade_no, string trade_no)
        {
            var request = new CancelRequest();
            request.AddGatewayData(new CancelModel()
            {
                TradeNo = trade_no,
                OutTradeNo = out_trade_no
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

        [HttpPost]
        public IActionResult Transfer(string out_trade_no, string payee_account, string payee_type, double amount, string remark)
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

            var response = _baseGateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public IActionResult TransferQuery(string out_trade_no, string trade_no)
        {
            var request = new TransferQueryRequest();
            request.AddGatewayData(new TransferQueryModel()
            {
                TradeNo = trade_no,
                OutTradeNo = out_trade_no
            });

            var response = _baseGateway.Execute(request);
            return Json(response);
        }

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
        }*/
    }
}
