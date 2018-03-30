using ICanPay.Core.Request;
using ICanPay.Core.Response;
using ICanPay.Core.Utils;
using System.Threading.Tasks;

namespace ICanPay.Core
{
    /// <summary>
    /// 网关的抽象基类
    /// </summary>
    public abstract class BaseGateway
    {
        #region 公共字段

        public const string TRUE = "true";
        public const string FALSE = "false";
        public const string SUCCESS = "success";
        public const string FAILURE = "failure";
        public const string FAIL = "FAIL";
        public const string TIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        public const string TIMEFORMAT = "yyyyMMddHHmmss";
        public const string BODY = "body";

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        protected BaseGateway()
            : this(new GatewayData())
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="merchant">商户数据</param>
        protected BaseGateway(IMerchant merchant)
            : this(new GatewayData())
        {
            Merchant = merchant;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="merchant">商户数据</param>
        /// <param name="gatewayData">网关数据</param>
        protected BaseGateway(IMerchant merchant, GatewayData gatewayData)
        {
            Merchant = merchant;
            GatewayData = gatewayData;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gatewayData">网关数据</param>
        protected BaseGateway(GatewayData gatewayData)
        {
            GatewayData = gatewayData;
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
        public INotify Notify { get; set; }

        /// <summary>
        /// 网关的地址
        /// </summary>
        public abstract string GatewayUrl { get; set; }

        /// <summary>
        /// 网关数据
        /// </summary>
        public GatewayData GatewayData { get; set; }

        /// <summary>
        /// 是否成功支付
        /// </summary>
        protected internal abstract bool IsSuccessPay { get; }

        /// <summary>
        /// 需要验证的参数名称数组，用于识别不同的网关类型。
        /// 商户号(AppId)必须放第一位
        /// </summary>
        protected internal abstract string[] NotifyVerifyParameter { get; }

        #endregion

        #region 方法

        #region 抽象方法

        /// <summary>
        /// 检验网关返回的通知，确认订单是否支付成功
        /// </summary>
        protected internal abstract Task<bool> ValidateNotifyAsync();

        /// <summary>
        /// 当接收到支付网关通知并验证无误时按照支付网关要求格式输出表示成功接收到网关通知的字符串
        /// </summary>
        protected internal virtual void WriteSuccessFlag()
        {
            HttpUtil.Write(SUCCESS);
        }

        /// <summary>
        /// 当接收到支付网关通知并验证有误时按照支付网关要求格式输出表示失败接收到网关通知的字符串
        /// </summary>
        protected internal virtual void WriteFailureFlag()
        {
            HttpUtil.Write(FAILURE);
        }

        /// <summary>
        /// 执行请求
        /// </summary>
        /// <typeparam name="TModel">数据模型</typeparam>
        /// <typeparam name="TResponse">返回模型</typeparam>
        /// <param name="request">请求</param>
        /// <returns></returns>
        public abstract TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request) where TResponse : IResponse;

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="gatewayData">网关数据</param>
        /// <returns></returns>
        protected abstract string BuildSign(GatewayData gatewayData);

        /// <summary>
        /// 检验签名
        /// </summary>
        /// <param name="data">待验证数据</param>
        /// <param name="sign">签名</param>
        /// <returns></returns>
        protected abstract bool CheckSign(string data, string sign);

        #endregion

        #endregion
    }
}
