using PaySharp.Allinpay;
using PaySharp.Allinpay.Domain;
using PaySharp.Allinpay.Request;
using PaySharp.Core;
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

        //[HttpPost]
        //public ActionResult WapPay(string out_trade_no, string subject, double total_amount, string body)
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
    }
}
