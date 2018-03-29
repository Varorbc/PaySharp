using ICanPay.Alipay.Domain;
using ICanPay.Alipay.Response;
using ICanPay.Core;
using System;

namespace ICanPay.Alipay.Request
{
    public class BarcodePayRequest : BaseRequest<BarcodePayModel, BarcodePayResponse>
    {
        public BarcodePayRequest()
            : base("alipay.trade.pay")
        {
        }

        /// <summary>
        /// 轮询间隔,单位毫秒
        /// </summary>
        public int PollTime { get; set; } = 5000;

        /// <summary>
        /// 轮询次数
        /// </summary>
        public int PollCount { get; set; } = 5;

        /// <summary>
        /// 支付失败事件
        /// </summary>
        /// <param name="e"></param>
        internal void OnPayFailed(PayFailedEventArgs e) => PayFailed?.Invoke(this, e);

        /// <summary>
        /// 支付成功事件
        /// </summary>
        /// <param name="e"></param>
        internal void OnPaySucceed(PaySucceedEventArgs e) => PaySucceed?.Invoke(this, e);

        /// <summary>
        /// 网关同步返回的支付通知验证失败时触发
        /// </summary>
        public event Action<object, PayFailedEventArgs> PayFailed;

        /// <summary>
        /// 网关同步返回的支付通知验证成功时触发
        /// </summary>
        public event Action<object, PaySucceedEventArgs> PaySucceed;
    }
}
