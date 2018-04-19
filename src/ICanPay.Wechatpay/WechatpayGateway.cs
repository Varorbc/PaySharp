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

        protected override bool IsSuccessPay => Notify.ResultCode == "SUCCESS";

        protected override string[] NotifyVerifyParameter => new string[]
        {
            "appid", "return_code", "mch_id", "nonce_str", "result_code"
        };

        #endregion

        #region 方法

        protected override async Task<bool> ValidateNotifyAsync()
        {
            base.Notify = await GatewayData.ToObjectAsync<Notify>(StringCase.Snake);

            if (Notify.ReturnCode != "SUCCESS")
            {
                throw new GatewayException("不是成功的返回码");
            }

            if (string.IsNullOrEmpty(Notify.ReqInfo))
            {
                if (Notify.Sign != SubmitProcess.BuildSign(GatewayData, _merchant.Key))
                {
                    throw new GatewayException("签名不一致");
                }
            }
            else
            {
                //TODO:解密
                var key = EncryptUtil.MD5(_merchant.Key).ToLower();
                var data = EncryptUtil.AESDecrypt(Notify.ReqInfo, key);
            }

            return true;
        }

        protected override void WriteSuccessFlag()
        {
            GatewayData.Add("return_code", "SUCCESS");
            HttpUtil.Write(GatewayData.ToXml());
        }

        protected override void WriteFailureFlag()
        {
            GatewayData.Add("return_code", "FAIL");
            HttpUtil.Write(GatewayData.ToXml());
        }

        public override TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request)
        {
            return SubmitProcess.Execute(_merchant, request, GatewayUrl);
        }

        #endregion
    }
}
