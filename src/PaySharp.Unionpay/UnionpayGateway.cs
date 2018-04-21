using PaySharp.Core;
using PaySharp.Core.Request;
using PaySharp.Core.Utils;
using PaySharp.Unionpay.Request;
using System.Threading.Tasks;

namespace PaySharp.Unionpay
{
    /// <summary>
    /// 银联支付网关
    /// </summary>
    public class UnionpayGateway : BaseGateway
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
            : base(merchant)
        {
            _merchant = merchant;
            //TODO:测试同时读取是否有问题
            _merchant.CertId = Util.GetCertId(merchant.CertPath, merchant.CertPwd);
            _merchant.CertKey = Util.GetCertKey(merchant.CertPath, merchant.CertPwd);
            //_merchant.EncryptCertId = Util.GetEncryptCertId();
        }

        #endregion

        #region 属性

        public override string GatewayUrl { get; set; } = "https://gateway.95516.com";

        private string BackUrl => GatewayUrl + "gateway/api/backTransReq.do";

        private string QueryUrl => GatewayUrl + "gateway/api/queryTrans.do";

        public new Merchant Merchant => _merchant;

        public new Notify Notify => (Notify)base.Notify;

        protected override bool IsSuccessPay => Notify.RespCode == "00" || Notify.RespCode == "A6";

        protected override string[] NotifyVerifyParameter => new string[]
        {
            "merId",  "respCode", "respMsg", "queryId", "signMethod"
        };

        #endregion

        protected override async Task<bool> ValidateNotifyAsync()
        {
            base.Notify = await GatewayData.ToObjectAsync<Notify>(StringCase.Camel);
            if (SubmitProcess.CheckSign(GatewayData, Notify.Sign, Notify.SignPubKeyCert))
            {
                return true;
            }

            return false;
        }

        #region 扫码支付

        public string BuildScanPayment()
        {
            InitScanPayment();

            //Commit();

            return Notify.QrCode;
        }

        public void InitScanPayment()
        {
            //Merchant.TxnSubType = "07";
            //Merchant.BizType = "000000";
            //InitOrderParameter();
            //RequestUrl = BackUrl;
        }

        #endregion

        #region 条码支付

        public void BuildBarcodePayment()
        {
            InitBarcodePayment();

            //Commit();
        }

        public void InitBarcodePayment()
        {
            //Merchant.TxnSubType = "06";
            //Merchant.BizType = "000000";
            //Merchant.ChannelType = "07";
            //InitOrderParameter();
            //RequestUrl = BackUrl;
        }

        #endregion

        #region 查询订单

        //public INotify BuildQuery(IAuxiliary auxiliary)
        //{
        //    InitQuery(auxiliary);

        //    Commit();

        //    return Notify;
        //}

        //public void InitQuery(IAuxiliary auxiliary)
        //{
        //    Merchant.TxnType = "00";
        //    Merchant.BizType = "000000";
        //    RequestUrl = QueryUrl;

        //    InitAuxiliaryParameter(auxiliary);
        //}

        #endregion

        #region 撤销订单

        //public INotify BuildCancel(IAuxiliary auxiliary)
        //{
        //    InitCancel(auxiliary);

        //    Commit();

        //    return Notify;
        //}

        //public void InitCancel(IAuxiliary auxiliary)
        //{
        //    Merchant.TxnType = "31";
        //    RequestUrl = BackUrl;

        //    InitAuxiliaryParameter(auxiliary);
        //}

        #endregion

        #region 订单退款

        //public INotify BuildRefund(IAuxiliary auxiliary)
        //{
        //    InitRefund(auxiliary);

        //    Commit();

        //    return Notify;
        //}

        //public void InitRefund(IAuxiliary auxiliary)
        //{
        //    Merchant.TxnType = "04";
        //    RequestUrl = BackUrl;

        //    InitAuxiliaryParameter(auxiliary);
        //}

        #endregion

        #region 对账单下载

        //public FileStream BuildBillDownload(IAuxiliary auxiliary)
        //{
        //    InitBillDownload(auxiliary);

        //    Commit();

        //    return CreateZip(Notify.FileContent);
        //}

        //public void InitBillDownload(IAuxiliary auxiliary)
        //{
        //    Merchant.TxnType = "76";
        //    Merchant.TxnSubType = "01";
        //    Merchant.ChannelType = "07";
        //    Merchant.BizType = "000000";

        //    GatewayData.Add(Merchant, StringCase.Camel);
        //    GatewayData.Add(auxiliary, StringCase.Camel);
        //    GatewayData.Remove(Constant.BACKURL);
        //    GatewayData.Remove(Constant.FRONTURL);
        //    GatewayData.Add(Constant.SIGNATURE, BuildSign());
        //    RequestUrl = FILEGATEWAYURL;
        //}

        ///// <summary>
        ///// 创建Zip文件
        ///// </summary>
        ///// <param name="content">内容</param>
        ///// <returns></returns>
        //private FileStream CreateZip(string content)
        //{
        //    byte[] buffer = Util.Inflater(content);
        //    FileStream fileStream = new FileStream($"{DateTime.Now.ToString("yyyyMMddHHmmss")}.zip", FileMode.Create);
        //    fileStream.Write(buffer, 0, buffer.Length);
        //    fileStream.Position = 0;

        //    return fileStream;
        //}

        #endregion

        //private void InitAuxiliaryParameter(IAuxiliary auxiliary)
        //{
        //    Merchant.TxnSubType = "00";
        //    Merchant.ChannelType = "07";

        //    GatewayData.Add(Merchant, StringCase.Camel);
        //    GatewayData.Add(auxiliary, StringCase.Camel);
        //    GatewayData.Add(Constant.SIGNATURE, BuildSign());
        //}

        public override TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request)
        {
            if (request is WebPayRequest)
            {
                return SubmitProcess.SdkExecute(_merchant, request, GatewayUrl);
            }

            return SubmitProcess.Execute(_merchant, request, GatewayUrl);
        }
    }
}
