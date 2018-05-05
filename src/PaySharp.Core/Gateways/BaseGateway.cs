using PaySharp.Core.Request;
using PaySharp.Core.Response;
using PaySharp.Core.Utils;
using System.Threading.Tasks;

namespace PaySharp.Core
{
    /// <summary>
    /// 网关的抽象基类
    /// </summary>
    public abstract class BaseGateway : IGateway
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        protected BaseGateway()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="merchant">商户数据</param>
        protected BaseGateway(IMerchant merchant)
        {
            Merchant = merchant;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 商户数据
        /// </summary>
        public IMerchant Merchant { get; set; }

        /// <summary>
        /// 通知数据
        /// </summary>
        public IResponse NotifyResponse { get; set; }

        /// <summary>
        /// 网关的地址
        /// </summary>
        public abstract string GatewayUrl { get; set; }

        /// <summary>
        /// 网关数据
        /// </summary>
        protected internal GatewayData GatewayData { get; set; }

        /// <summary>
        /// 是否支付成功
        /// </summary>
        protected internal abstract bool IsPaySuccess { get; }

        /// <summary>
        /// 是否退款成功
        /// </summary>
        protected internal abstract bool IsRefundSuccess { get; }

        /// <summary>
        /// 是否撤销成功
        /// </summary>
        protected internal abstract bool IsCancelSuccess { get; }

        /// <summary>
        /// 需要验证的参数名称数组，用于识别不同的网关类型。
        /// 商户号(AppId)必须放第一位
        /// </summary>
        protected internal abstract string[] NotifyVerifyParameter { get; }

        #endregion

        #region 方法

        /// <summary>
        /// 检验网关返回的通知，确认订单是否支付成功
        /// </summary>
        protected internal abstract Task<bool> ValidateNotifyAsync();

        /// <summary>
        /// 当接收到支付网关通知并验证无误时按照支付网关要求格式输出表示成功接收到网关通知的字符串
        /// </summary>
        protected internal virtual void WriteSuccessFlag()
        {
            HttpUtil.Write("success");
        }

        /// <summary>
        /// 当接收到支付网关通知并验证有误时按照支付网关要求格式输出表示失败接收到网关通知的字符串
        /// </summary>
        protected internal virtual void WriteFailureFlag()
        {
            HttpUtil.Write("failure");
        }

        /// <summary>
        /// 执行请求
        /// </summary>
        /// <typeparam name="TModel">数据模型</typeparam>
        /// <typeparam name="TResponse">返回模型</typeparam>
        /// <param name="request">请求</param>
        /// <returns></returns>
        public abstract TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request) where TResponse : IResponse;

        #endregion
    }
}
