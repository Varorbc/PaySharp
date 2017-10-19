using ICanPay.Alipay;
using ICanPay.Core;
using ICanPay.Tenpay;
using ICanPay.Wechatpay;
using ICanPay.Yeepay;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICanPay.Demo.Controllers
{
    public class NotifyController : Controller
    {
        private ICollection<GatewayBase> gatewayList;
        public NotifyController(ICollection<GatewayBase> gatewayList)
        {
            this.gatewayList = gatewayList;
        }

        public async Task Index()
        {
            // 订阅支付通知事件
            PaymentNotify notify = new PaymentNotify(gatewayList);
            notify.PaymentSucceed += Notify_PaymentSucceed;
            notify.PaymentFailed += Notify_PaymentFailed;
            notify.UnknownGateway += Notify_UnknownGateway;

            // 接收并处理支付通知
            await notify.ReceivedAsync();
        }

        private void Notify_PaymentSucceed(object sender, PaymentSucceedEventArgs e)
        {
            // 支付成功时时的处理代码
            if (e.GatewayType == GatewayType.Alipay)
            {
                var alipayNotify = (Notify)e.Notify;
            }
        }

        private void Notify_PaymentFailed(object sender, PaymentFailedEventArgs e)
        {
            // 支付失败时的处理代码
        }

        private void Notify_UnknownGateway(object sender, UnknownGatewayEventArgs e)
        {
            // 无法识别支付网关时的处理代码
        }
    }
}
