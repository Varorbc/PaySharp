using ICanPay.Alipay;
using ICanPay.Core;
using ICanPay.Tenpay;
using ICanPay.Wechatpay;
using ICanPay.Yeepay;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ICanPay.Demo.Controllers
{
    public class PaymentController : Controller
    {
        private ICollection<GatewayBase> gatewayList;
        public PaymentController(ICollection<GatewayBase> gatewayList)
        {
            this.gatewayList = gatewayList;
        }

        public IActionResult Index()
        {
            string content = CreateWechatpayOrder();

            return Content(content);
        }

        /// <summary>
        /// 创建易宝的支付订单
        /// </summary>
        private void CreateYeepayOrder()
        {
            var gateway = new YeepayGateway();
            PaymentSetting paymentSetting = new PaymentSetting(gateway);
            //paymentSetting.Merchant.UserName = "000000000000000";
            //paymentSetting.Merchant.Key = "000000000000000000000000000000000000000000";
            //paymentSetting.Merchant.NotifyUrl = new Uri("http://yourwebsite.com/Notify.aspx");

            paymentSetting.Order.Amount = 0.01;
            paymentSetting.Order.OutTradeNo = "24";
            paymentSetting.Order.Body = "测试易宝";

            paymentSetting.Payment();
        }


        private void CreateTenpayOrder()
        {
            var gateway = new TenpayGateway();
            PaymentSetting paymentSetting = new PaymentSetting(gateway);
            //paymentSetting.Merchant.UserName = "000000000000000";
            //paymentSetting.Merchant.Key = "000000000000000000000000000000000000000000";
            //paymentSetting.Merchant.NotifyUrl = new Uri("http://yourwebsite.com/Notify.aspx");

            paymentSetting.Order.Amount = 0.01;
            paymentSetting.Order.OutTradeNo = "93";
            paymentSetting.Order.Body = "测测看";

            paymentSetting.Payment();
        }


        /// <summary>
        /// 创建支付宝的支付订单
        /// </summary>
        private string CreateAlipayOrder()
        {
            var order = new Alipay.Order()
            {
                Amount = 0.01,
                OutTradeNo = "35",
                Subject = "测测看支付宝",
                Body = "1234",
                ExtendParams = new ExtendParam()
                {
                    HbFqNum = "3"
                },
                GoodsDetail = new Goods[] {
                    new Goods()
                    {
                        Id = "12"
                    }
                }
            };

            var gateway = gatewayList.GetGateway(GatewayType.Alipay);
            gateway.GatewayTradeType = GatewayTradeType.Web;

            PaymentSetting paymentSetting = new PaymentSetting(gateway, order);
            return paymentSetting.Payment();
        }


        /// <summary>
        /// 创建微信的支付订单
        /// </summary>
        private string CreateWechatpayOrder()
        {
            var order = new Wechatpay.Order()
            {
                Amount = 0.01,
                OutTradeNo = "35",
                Body = "测测看微信支付",
            };

            var gateway = gatewayList.GetGateway(GatewayType.Wechatpay);
            gateway.GatewayTradeType = GatewayTradeType.App;

            PaymentSetting paymentSetting = new PaymentSetting(gateway, order);
            return paymentSetting.Payment();
        }
    }
}
