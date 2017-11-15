using ICanPay.Core;
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

        protected override bool IsSuccessPay => throw new NotImplementedException();

        protected override bool IsWaitPay => throw new NotImplementedException();

        protected override string[] NotifyVerifyParameter => throw new NotImplementedException();

        #endregion

        protected override Task<bool> ValidateNotifyAsync()
        {
            throw new NotImplementedException();
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
            Order.Amount *= 100;

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
    }
}
