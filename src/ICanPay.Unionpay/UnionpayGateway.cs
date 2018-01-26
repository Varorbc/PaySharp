using ICanPay.Core;
using ICanPay.Core.Exceptions;
using ICanPay.Core.Utils;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ICanPay.Unionpay
{
    /// <summary>
    /// 银联支付网关
    /// </summary>
    public class UnionpayGateway
        : GatewayBase,
        IFormPayment, IAppPayment, IScanPayment, IBarcodePayment,
        IQuery, ICancel, IRefund, IBillDownload
    {

        #region 私有字段

#if DEBUG

        private string FILEGATEWAYURL = "https://filedownload.test.95516.com/";

#else

        private const string FILEGATEWAYURL = "https://filedownload.95516.com/";

#endif

        private readonly Merchant _merchant;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public UnionpayGateway(Merchant merchant)
            : base(merchant, new GatewayData(StringComparer.Ordinal))
        {
            _merchant = merchant;
            _merchant.CertId = Util.GetCertId(merchant.CertPath, merchant.CertPwd);
            _merchant.CertKey = Util.GetCertKey(merchant.CertPath, merchant.CertPwd);
            //_merchant.EncryptCertId = Util.GetEncryptCertId();
        }

        #endregion

        #region 属性

        public override string GatewayUrl { get; set; } = "https://gateway.95516.com/";

        private string FrontUrl => GatewayUrl + "gateway/api/frontTransReq.do";

        private string AppUrl => GatewayUrl + "gateway/api/appTransReq.do";

        private string BackUrl => GatewayUrl + "gateway/api/backTransReq.do";

        private string QueryUrl => GatewayUrl + "gateway/api/queryTrans.do";

        private string RequestUrl { get; set; }

        public new Merchant Merchant => _merchant;

        public new Order Order
        {
            get => (Order)base.Order;
            set => base.Order = value;
        }

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

            return GatewayData.ToForm(RequestUrl);
        }

        public void InitFormPayment()
        {
            InitOrderParameter();
            RequestUrl = FrontUrl;
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
            RequestUrl = AppUrl;
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
            RequestUrl = BackUrl;
        }

        #endregion

        #region 条码支付

        public void BuildBarcodePayment()
        {
            InitBarcodePayment();

            Commit();
        }

        public void InitBarcodePayment()
        {
            Merchant.TxnSubType = "06";
            Merchant.BizType = "000000";
            Merchant.ChannelType = "07";
            InitOrderParameter();
            RequestUrl = BackUrl;
        }

        #endregion

        #region 查询订单

        public INotify BuildQuery(IAuxiliary auxiliary)
        {
            InitQuery(auxiliary);

            Commit();

            return Notify;
        }

        public void InitQuery(IAuxiliary auxiliary)
        {
            Merchant.TxnType = "00";
            Merchant.BizType = "000000";
            RequestUrl = QueryUrl;

            InitAuxiliaryParameter(auxiliary);
        }

        #endregion

        #region 撤销订单

        public INotify BuildCancel(IAuxiliary auxiliary)
        {
            InitCancel(auxiliary);

            Commit();

            return Notify;
        }

        public void InitCancel(IAuxiliary auxiliary)
        {
            Merchant.TxnType = "31";
            RequestUrl = BackUrl;

            InitAuxiliaryParameter(auxiliary);
        }

        #endregion

        #region 订单退款

        public INotify BuildRefund(IAuxiliary auxiliary)
        {
            InitRefund(auxiliary);

            Commit();

            return Notify;
        }

        public void InitRefund(IAuxiliary auxiliary)
        {
            Merchant.TxnType = "04";
            RequestUrl = BackUrl;

            InitAuxiliaryParameter(auxiliary);
        }

        #endregion

        #region 对账单下载

        public FileStream BuildBillDownload(IAuxiliary auxiliary)
        {
            InitBillDownload(auxiliary);

            Commit();

            return CreateZip(Notify.FileContent);
        }

        public void InitBillDownload(IAuxiliary auxiliary)
        {
            Merchant.TxnType = "76";
            Merchant.TxnSubType = "01";
            Merchant.ChannelType = "07";
            Merchant.BizType = "000000";

            GatewayData.Add(Merchant, StringCase.Camel);
            GatewayData.Add(auxiliary, StringCase.Camel);
            GatewayData.Remove(Constant.BACKURL);
            GatewayData.Remove(Constant.FRONTURL);
            GatewayData.Add(Constant.SIGNATURE, BuildSign());
            RequestUrl = FILEGATEWAYURL;
        }

        /// <summary>
        /// 创建Zip文件
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns></returns>
        private FileStream CreateZip(string content)
        {
            byte[] buffer = Util.Inflater(content);
            FileStream fileStream = new FileStream($"{DateTime.Now.ToString(TIMEFORMAT)}.zip", FileMode.Create);
            fileStream.Write(buffer, 0, buffer.Length);
            fileStream.Position = 0;

            return fileStream;
        }

        #endregion

        private void InitAuxiliaryParameter(IAuxiliary auxiliary)
        {
            Merchant.TxnSubType = "00";
            Merchant.ChannelType = "07";

            GatewayData.Add(Merchant, StringCase.Camel);
            GatewayData.Add(auxiliary, StringCase.Camel);
            GatewayData.Add(Constant.SIGNATURE, BuildSign());
        }

        private void InitOrderParameter()
        {
            GatewayData.Add(Merchant, StringCase.Camel);
            GatewayData.Add(Order, StringCase.Camel);
            GatewayData.Add(Constant.SIGNATURE, BuildSign());
        }

        private void Commit()
        {
            string result = null;
            Task.Run(async () =>
            {
                result = await HttpUtil
                .PostAsync(RequestUrl, GatewayData.ToUrl());
            })
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
            IsSuccessReturn();
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
        /// 是否是已成功的返回
        /// </summary>
        /// <returns></returns>
        private bool IsSuccessReturn()
        {
            ValidateNotifySign();

            if (Notify.RespCode != "00")
            {
                throw new GatewayException(Notify.RespMsg);
            }

            return true;
        }

        /// <summary>
        /// 是否是已成功支付的支付通知
        /// </summary>
        /// <returns></returns>
        private bool IsSuccessResult()
        {
            return ValidateNotifySign();
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
