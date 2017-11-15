using ICanPay.Core;
using ICanPay.Core.Exceptions;
using ICanPay.Core.Utils;
using System;
using System.Threading.Tasks;

namespace ICanPay.Unionpay
{
    /// <summary>
    /// 银联支付网关
    /// </summary>
    public class UnionpayGateway
        : GatewayBase,
        IFormPayment
    {

        #region 私有字段

        private const string GATEWAYURL = "https://gateway.test.95516.com/gateway/api/frontTransReq.do";
        private readonly Merchant _merchant;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public UnionpayGateway(Merchant merchant)
            : base(merchant)
        {
            _merchant = merchant;
            _merchant.CertId = Util.GetCertId(merchant.CertPath, merchant.CertPwd);
            _merchant.CertKey = Util.GetCertKey(merchant.CertPath, merchant.CertPwd);
        }

        #endregion

        #region 属性

        public override string GatewayUrl { get; set; } = GATEWAYURL;

        public new Merchant Merchant => _merchant;

        public new Order Order => (Order)base.Order;

        public new Notify Notify => (Notify)base.Notify;

        protected override bool IsSuccessPay => Notify.RespCode == "00" || Notify.RespCode == "A6";

        protected override bool IsWaitPay => throw new NotImplementedException();

        protected override string[] NotifyVerifyParameter => new string[]
        { Constant.MERID, Constant.RESPCODE, Constant.RESPMSG, Constant.QUERYID, Constant.SIGNMETHOD };

        #endregion

        protected override async Task<bool> ValidateNotifyAsync()
        {
            base.Notify = await GatewayData.ToObjectAsync<Notify>(StringCase.Camel);
            if (IsSuccessResult())
            {
                return true;
            }

            return false;
        }

        #region 表单支付

        public string BuildFormPayment()
        {
            InitFormPayment();

            return GatewayData.ToForm(GatewayUrl);
        }

        public void InitFormPayment()
        {
            _merchant.TxnType = "01";
            _merchant.TxnSubType = "01";
            _merchant.BizType = "000201";

            GatewayData.Add(Merchant, StringCase.Camel);
            GatewayData.Add(Order, StringCase.Camel);
            GatewayData.Add(Constant.SIGNATURE, BuildSign());
        }

        #endregion

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <returns></returns>
        private string BuildSign()
        {
            return Util.Sign(_merchant.CertKey, GatewayData.ToUrl());
        }

        /// <summary>
        /// 是否是已成功支付的支付通知
        /// </summary>
        /// <returns></returns>
        private bool IsSuccessResult()
        {
            if (!ValidateNotifySign())
            {
                throw new GatewayException("签名不一致");
            }

            if (IsSuccessPay)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 验证银联通知的签名
        /// </summary>
        private bool ValidateNotifySign()
        {
            return Util.VerifyData(GatewayData.ToUrl(Constant.SIGNATURE), Notify.Sign, Notify.SignPubKeyCert);
        }
    }
}
