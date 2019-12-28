using PaySharp.Allinpay;
using PaySharp.Allinpay.Domain;
using PaySharp.Allinpay.Request;
using PaySharp.Core;
using PaySharp.Core.Response;
#if NETCOREAPP
using Microsoft.AspNetCore.Mvc;
#else
using System.Web.Mvc;
#endif
using PaySharp.Allinpay.Enum;

namespace PaySharp.Demo.Controllers
{
    public class AllinpayController : Controller
    {
        private readonly IGateway _gateway;

        public AllinpayController(IGateways gateways)
        {
            _gateway = gateways.Get<AllinpayGateway>();
        }

        [HttpPost]
        public ActionResult UnifiedPay(string out_trade_no, int total_amount, string body)
        {
            var request = new UnifiedPayRequest();
            request.AddGatewayData(new UnifiedPayModel()
            {
                PayType = PayType.A01,
                Body = body,
                TotalAmount = total_amount,
                OutTradeNo = out_trade_no
            });

            var response = _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public ActionResult BarcodePay(string out_trade_no, string auth_code, int total_amount, string body)
        {
            var request = new BarcodePayRequest();
            request.AddGatewayData(new BarcodePayModel()
            {
                Body = body,
                TotalAmount = total_amount,
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

        //[HttpPost]
        //public ActionResult Query(string out_trade_no, string trade_no)
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
        //public ActionResult Cancel(string out_trade_no)
        //{
        //    var request = new CancelRequest();
        //    request.AddGatewayData(new CancelModel()
        //    {
        //        OutTradeNo = out_trade_no
        //    });

        //    var response = _gateway.Execute(request);
        //    return Json(response);
        //}
    }
}
