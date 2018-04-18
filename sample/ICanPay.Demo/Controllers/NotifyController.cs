using ICanPay.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICanPay.Demo.Controllers
{
    public class NotifyController : Controller
    {
        private readonly IGateways gateways;

        public NotifyController(IGateways gateways)
        {
            this.gateways = gateways;
        }

        public async Task Index()
        {
            // 订阅支付通知事件
            PayNotify notify = new PayNotify(gateways);
            notify.PaySucceed += Notify_PaySucceed;
            notify.PayFailed += Notify_PayFailed;
            notify.UnknownGateway += Notify_UnknownGateway;

            // 接收并处理支付通知
            await notify.ReceivedAsync();
        }

        private bool Notify_PaySucceed(object sender, PaySucceedEventArgs e)
        {
            // 支付成功时时的处理代码
            /* 建议添加以下校验。
             * 1、需要验证该通知数据中的OutTradeNo是否为商户系统中创建的订单号，
             * 2、判断Amount是否确实为该订单的实际金额（即商户订单创建时的金额），
             */
            if (e.GatewayType == typeof(Alipay.AlipayGateway))
            {
                var alipayNotify = (Alipay.Notify)e.Notify;

                //同步通知，即浏览器跳转返回
                if(e.NotifyType == NotifyType.Sync)
                {

                }
            }

            //处理成功返回true
            return true;
        }

        private void Notify_PayFailed(object sender, PayFailedEventArgs e)
        {
            // 支付失败时的处理代码
        }

        private void Notify_UnknownGateway(object sender, UnknownGatewayEventArgs e)
        {
            // 无法识别支付网关时的处理代码
        }
    }
}
