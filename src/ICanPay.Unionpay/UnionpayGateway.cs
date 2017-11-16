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
        IFormPayment, IAppPayment,IScanPayment
    {

        #region 私有字段

        private const string FRONTGATEWAYURL = "https://gateway.test.95516.com/gateway/api/frontTransReq.do";
        private const string APPGATEWAYURL = "https://gateway.test.95516.com/gateway/api/appTransReq.do";
        private const string BACKGATEWAYURL = "https://gateway.test.95516.com/gateway/api/backTransReq.do";

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

        public override string GatewayUrl { get; set; } = FRONTGATEWAYURL;

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
            InitOrderParameter();
            GatewayUrl = FRONTGATEWAYURL;
        }

        #endregion

        #region App支付

        public string BuildAppPayment()
        {
            InitAppPayment();

            Commit();

            return Notify.Tn;
        }

        public void InitAppPayment()
        {
            InitOrderParameter();
            GatewayUrl = APPGATEWAYURL;
        }

        #endregion

        #region 扫码支付

        public string BuildScanPayment()
        {
            InitScanPayment();

            Commit();

            return Notify.QrCode;
        }

        public void InitScanPayment()
        {
            Merchant.TxnSubType = "07";
            Merchant.BizType = "000000";
            InitOrderParameter();
            GatewayUrl = BACKGATEWAYURL;
        }

        #endregion

        private void InitOrderParameter()
        {
            GatewayData.Add(Merchant, StringCase.Camel);
            GatewayData.Add(Order, StringCase.Camel);
            GatewayData.Add(Constant.SIGNATURE, BuildSign());
        }

        private void Commit()
        {
            string result = HttpUtil
                .PostAsync(GatewayUrl, GatewayData.ToUrl())
                .GetAwaiter()
                .GetResult();

            ReadReturnResult(result);
        }

        private void ReadReturnResult(string result)
        {
            GatewayData.FromUrl(result, false);
            base.Notify = GatewayData.ToObject<Notify>(StringCase.Camel);
            if (!IsSuccessPay)
            {
                throw new GatewayException(Notify.RespMsg);
            }
            ValidateNotifySign();
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <returns></returns>
        private string BuildSign()
        {
            return Util.Sign(Merchant.CertKey, GatewayData.ToUrl(false));
        }

        /// <summary>
        /// 是否是已成功支付的支付通知
        /// </summary>
        /// <returns></returns>
        private bool IsSuccessResult()
        {
            ValidateNotifySign();

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
            GatewayData.Remove(Constant.SIGNATURE);

            bool result = Util.VerifyData(GatewayData.ToUrl(false),
                Notify.Sign, Notify.SignPubKeyCert);

            if (!result)
            {
                throw new GatewayException("签名不一致");
            }

            return result;
        }
    }
}
