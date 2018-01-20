using ICanPay.Core.Response;

namespace ICanPay.Core.Request
{
    public interface IRequest<T> where T : IResponse
    {
        /// <summary>
        /// 请求地址
        /// </summary>
        string RequestUrl { get; set; }

        /// <summary>
        /// 异步通知地址
        /// </summary>
        string NotifyUrl { get; set; }

        /// <summary>
        /// 同步通知地址
        /// </summary>
        string ReturnUrl { get; set; }

        /// <summary>
        /// 网关数据
        /// </summary>
        /// <returns></returns>
        GatewayData GatewayData { get; set; }
    }
}
