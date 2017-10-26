using ICanPay.Alipay;
using ICanPay.Core;
using ICanPay.Wechatpay;
using Microsoft.AspNetCore.Mvc;

namespace ICanPay.Demo.Controllers
{
    public class QueryPaymentController : Controller
    {
        public IActionResult Index()
        {
            QueryWechatpayOrder();

            return Ok();
        }

        /// <summary>
        /// 查询微信的订单支付状态
        /// </summary>
        private void QueryWechatpayOrder()
        {
            //var gateway = new WechatpayGataway();
            //PaymentSetting querySetting = new PaymentSetting(gateway);
            //querySetting.GatewayData.Add("appid", "wx000000000000000");
            //querySetting.Merchant.UserName = "000000000000000";
            //querySetting.Merchant.Key = "0000000000000000000000000000000000000000";

            // 查询时需要设置订单的Id与金额，在查询结果中将会核对订单的Id与金额，如果不相符会返回查询失败。
            //querySetting.Order.OutTradeNo = "20";
            //querySetting.Order.Amount = 0.01;

            //if (querySetting.CanQueryNow && querySetting.QueryNow())
            //{
            //    // 订单已支付
            //}
        }
    }
}
