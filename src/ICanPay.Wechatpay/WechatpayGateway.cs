using ICanPay.Core;
using ICanPay.Core.Exceptions;
using ICanPay.Core.Request;
using ICanPay.Core.Utils;
using System.Threading.Tasks;

namespace ICanPay.Wechatpay
{
    /// <summary>
    /// 微信支付网关
    /// </summary>
    public sealed class WechatpayGateway : BaseGateway
    {
        #region 私有字段

        private readonly Merchant _merchant;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化微信支付网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public WechatpayGateway(Merchant merchant)
            : base(merchant)
        {
            _merchant = merchant;
        }

        #endregion

        #region 属性

        public override string GatewayUrl { get; set; } = "https://api.mch.weixin.qq.com";

        public new Merchant Merchant => _merchant;

        public new Notify Notify => (Notify)base.Notify;

        protected override bool IsSuccessPay => Notify.ResultCode.ToLower() == SUCCESS;

        protected override string[] NotifyVerifyParameter => new string[]
        {
            "appid", "return_code", "mch_id", "nonce_str", "result_code"
        };

        #endregion

        #region 方法

        protected override async Task<bool> ValidateNotifyAsync()
        {
            base.Notify = await GatewayData.ToObjectAsync<Notify>(StringCase.Snake);

            if (IsSuccessResult())
            {
                return true;
            }

            return false;
        }

        /*/// <summary>
        /// 通过code获取AccessToken
        /// </summary>
        /// <param name="code"></param>
        public OAuth GetAccessTokenByCode(string code)
        {
            string result = null;
            Task.Run(async () =>
            {
                result = await HttpUtil
                .GetAsync(string.Format(ACCESSTOKENURL, Merchant.AppId, Merchant.AppSecret, code));
            })
            .GetAwaiter()
            .GetResult();
            GatewayData.FromJson(result);

            int _code = GatewayData.GetIntValue(Constant.ERRCODE);
            int _msg = GatewayData.GetIntValue(Constant.ERRMSG);
            if (_code == 40029)
            {
                throw new GatewayException($"{_code} {_msg}");
            }

            return GatewayData.ToObject<OAuth>(StringCase.Snake);
        }

        /// <summary>
        /// 通过授权码获取OpenId
        /// </summary>
        /// <param name="authCode">授权码</param>
        public string GetOpenIdByAuthCode(string authCode)
        {
            GatewayData.Clear();
            Merchant.NonceStr = Util.GenerateNonceStr();
            GatewayData.Add(Constant.APPID, Merchant.AppId);
            GatewayData.Add(Constant.MCH_ID, Merchant.AppId);
            GatewayData.Add(Constant.AUTH_CODE, Merchant.AppId);
            GatewayData.Add(Constant.NONCE_STR, Merchant.NonceStr);
            GatewayData.Add(Constant.SIGN, BuildSign());
            RequestUrl = AuthCodeToOpenIdUrl;

            Commit();

            return Notify.OpenId;
        }*/

        /// <summary>
        /// 获得签名
        /// </summary>
        /// <returns></returns>
        private string BuildSign()
        {
            GatewayData.Remove(Constant.SIGN);

            string data = $"{GatewayData.ToUrl(false)}&key={_merchant.Key}";
            return EncryptUtil.MD5(data);
        }

        /// <summary>
        /// 是否是已成功支付的支付通知
        /// </summary>
        /// <returns></returns>
        private bool IsSuccessResult()
        {
            if (Notify.ReturnCode.ToLower() != SUCCESS)
            {
                throw new GatewayException("不是成功的返回码");
            }

            if (Notify.Sign != BuildSign())
            {
                throw new GatewayException("签名不一致");
            }

            if (Notify.ResultCode.ToLower() == SUCCESS)
            {
                return true;
            }

            return false;
        }

        /*/// <summary>
        /// 提交请求
        /// </summary>
        /// <param name="isCert">是否添加证书</param>
        private void Commit(bool isCert = false)
        {
            var cert = isCert ? new X509Certificate2(Merchant.SslCertPath, Merchant.SslCertPassword) : null;

            string result = null;
            Task.Run(async () =>
            {
                result = await HttpUtil
                .PostAsync(RequestUrl, GatewayData.ToXml(), cert);
            })
            .GetAwaiter()
            .GetResult();
            ReadReturnResult(result);
        }*/

        protected override void WriteSuccessFlag()
        {
            GatewayData.Add(Constant.RETURN_CODE, SUCCESS.ToUpper());
            HttpUtil.Write(GatewayData.ToXml());
        }

        protected override void WriteFailureFlag()
        {
            GatewayData.Add(Constant.RETURN_CODE, FAIL);
            HttpUtil.Write(GatewayData.ToXml());
        }

        public override TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request)
        {
            return SubmitProcess.Execute(_merchant, request, GatewayUrl);
        }

        #endregion
    }
}
