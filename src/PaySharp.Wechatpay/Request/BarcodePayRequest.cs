using PaySharp.Core.Response;
using PaySharp.Wechatpay.Domain;
using PaySharp.Wechatpay.Response;
using System;

namespace PaySharp.Wechatpay.Request
{
    public class BarcodePayRequest : BaseRequest<BarcodePayModel, BarcodePayResponse>
    {
        public BarcodePayRequest()
        {
            RequestUrl = "/pay/micropay";
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
        /// <param name="response">返回结果</param>
        /// <param name="message">提示信息</param>
        internal void OnPayFailed(IResponse response, string message) => PayFailed?.Invoke(response, message);

        /// <summary>
        /// 支付成功事件
        /// </summary>
        /// <param name="response">返回结果</param>
        /// <param name="message">提示信息</param>
        internal void OnPaySucceed(IResponse response, string message) => PaySucceed?.Invoke(response, message);

        /// <summary>
        /// 网关同步返回的支付通知验证失败时触发
        /// </summary>
        public event Action<IResponse, string> PayFailed;

        /// <summary>
        /// 网关同步返回的支付通知验证成功时触发
        /// </summary>
        public event Action<IResponse, string> PaySucceed;

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notify_url");
        }
    }
}
