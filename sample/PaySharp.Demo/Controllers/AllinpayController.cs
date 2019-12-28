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
using System.Text;
using System.Threading.Tasks;

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
    }
}
