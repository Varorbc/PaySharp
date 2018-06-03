#if NETCOREAPP
using Microsoft.AspNetCore.Mvc;
#else
using System.Web.Mvc;
#endif
using PaySharp.Core;
using PaySharp.Core.Response;
using PaySharp.Qpay;
using PaySharp.Qpay.Domain;
using PaySharp.Qpay.Request;
using System;

namespace PaySharp.Demo.Controllers
{
    public class QpayController : Controller
    {
        private readonly IGateway _gateway;

        public QpayController(IGateways gateways)
        {
            _gateway = gateways.Get<QpayGateway>();
        }

        [HttpPost]
        public ActionResult PublicPay(string out_trade_no, int total_amount, string body)
        {
            var request = new PublicPayRequest();
            request.AddGatewayData(new PublicPayModel()
            {
                Body = body,
                OutTradeNo = out_trade_no,
                TotalAmount = total_amount
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult AppPay(string out_trade_no, int total_amount, string body)
        {
            var request = new AppPayRequest();
            request.AddGatewayData(new AppPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                OutTradeNo = out_trade_no
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult ScanPay(string out_trade_no, string body, int total_amount)
        {
            var request = new ScanPayRequest();
            request.AddGatewayData(new ScanPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                OutTradeNo = out_trade_no
            });

            var response = _gateway.Execute(request);

            return Json(response);
        }

        [HttpPost]
        public ActionResult BarcodePay(string out_trade_no, string auth_code, int total_amount, string body, string device_info)
        {
            var request = new BarcodePayRequest();
            request.AddGatewayData(new BarcodePayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                OutTradeNo = out_trade_no,
                AuthCode = auth_code,
                DeviceInfo = device_info
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
        public ActionResult Refund(string out_trade_no, string trade_no, string out_refund_no, int refund_amount, string op_user_id, string op_user_passwd)
        {
            var request = new RefundRequest();
            request.AddGatewayData(new RefundModel()
            {
                TradeNo = trade_no,
                RefundAmount = refund_amount,
                OutRefundNo = out_refund_no,
                OutTradeNo = out_trade_no,
                OpUserId = op_user_id,
                OpUserPasswd = op_user_passwd
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult RefundQuery(string out_trade_no, string trade_no, string out_refund_no, string refund_no)
        {
            var request = new RefundQueryRequest();
            request.AddGatewayData(new RefundQueryModel()
            {
                TradeNo = trade_no,
                OutTradeNo = out_trade_no,
                OutRefundNo = out_refund_no,
                RefundNo = refund_no
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult Close(string out_trade_no)
        {
            var request = new CloseRequest();
            request.AddGatewayData(new CloseModel()
            {
                OutTradeNo = out_trade_no
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult Cancel(string out_trade_no)
        {
            var request = new CancelRequest();
            request.AddGatewayData(new CancelModel()
            {
                OutTradeNo = out_trade_no
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult BillDownload(string bill_date, string bill_type)
        {
            var request = new BillDownloadRequest();
            request.AddGatewayData(new BillDownloadModel()
            {
                BillDate = bill_date,
                BillType = bill_type
            });

            var response = _gateway.Execute(request);
            return File(response.GetBillFile(), "text/csv", $"{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv");
        }
    }
}
