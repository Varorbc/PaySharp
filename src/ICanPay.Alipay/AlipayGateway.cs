using ICanPay.Core;
using ICanPay.Core.Utils;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ICanPay.Alipay
{
    /// <summary>
    /// 支付宝网关
    /// </summary>
    public sealed class AlipayGateway
        : GatewayBase,
        IFormPayment, IUrlPayment, IAppPayment, IScanPayment, IBarcodePayment, IAppletPayment,
        IQuery, ICancel, IClose, IBillDownload, IRefund, IRefundQuery
    {

        #region 私有字段

        private const string GATEWAYURL = "https://openapi.alipay.com/gateway.do?charset=UTF-8";
        private readonly Merchant merchant;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化支付宝网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public AlipayGateway(Merchant merchant)
            : base(merchant)
        {
            this.merchant = merchant;
        }

        #endregion

        #region 属性

        public override string GatewayUrl { get; set; } = GATEWAYURL;

        public new Merchant Merchant => merchant;

        public new Order Order => (Order)base.Order;

        public new Notify Notify => (Notify)base.Notify;

        protected override bool IsWaitPay => Notify.TradeStatus == "WAIT_BUYER_PAY";

        protected override bool IsSuccessPay => Notify.Code == "TRADE_SUCCESS";

        protected override string[] NotifyVerifyParameter => new string[] { "notify_type", "notify_id", "notify_time", "sign", "sign_type" };

    #endregion

    #region 方法

    #region 表单支付

    public string BuildFormPayment()
        {
            InitFormPayment();

            return GatewayData.ToForm(GatewayUrl);
        }

        public void InitFormPayment()
        {
            Merchant.Method = Constant.WEB;
            Order.ProductCode = Constant.FAST_INSTANT_TRADE_PAY;

            InitOrderParameter();
        }

        #endregion

        #region Url支付

        public string BuildUrlPayment()
        {
            InitUrlPayment();

            return $"{GatewayUrl}?{GetPaymentQueryString()}";
        }

        public void InitUrlPayment()
        {
            Merchant.Method = Constant.WAP;
            Order.ProductCode = Constant.QUICK_WAP_WAY;

            InitOrderParameter();
        }

        #endregion

        #region App支付

        public string BuildAppPayment()
        {
            InitAppPayment();

            return GetPaymentQueryString();
        }

        public void InitAppPayment()
        {
            Merchant.Method = Constant.APP;
            Order.ProductCode = Constant.QUICK_MSECURITY_PAY;

            InitOrderParameter();
        }

        #endregion

        #region 扫码支付

        public string BuildScanPayment()
        {
            PreCreate();

            return Notify.QrCode;
        }

        /// <summary>
        /// 预创建订单
        /// </summary>
        /// <returns></returns>
        private void PreCreate()
        {
            InitScanPayment();

            Commit(Constant.ALIPAY_TRADE_PRECREATE_RESPONSE);
        }

        public void InitScanPayment()
        {
            Merchant.Method = Constant.SCAN;

            InitOrderParameter();
        }

        #endregion

        #region 条码支付

        public void BuildBarcodePayment()
        {
            InitBarcodePayment();

            Commit(Constant.ALIPAY_TRADE_PAY_RESPONSE);

            if (!string.IsNullOrEmpty(Notify.TradeNo))
            {
                PollQueryTradeState(new Auxiliary
                {
                    TradeNo = Notify.TradeNo
                });
            }
        }

        public void InitBarcodePayment()
        {
            Merchant.Method = Constant.BARCODE;
            Order.ProductCode = Constant.FACE_TO_FACE_PAYMENT;

            InitOrderParameter();
        }

        /// <summary>
        /// 每隔5秒轮询判断用户是否支付,总共轮询5次
        /// </summary>
        private void PollQueryTradeState(IAuxiliary auxiliary)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(5000);
                BuildQuery(auxiliary);
                if (IsSuccessPay)
                {
                    OnPaymentSucceed(new PaymentSucceedEventArgs(this));
                    return;
                }
            }

            BuildCancel(auxiliary);
            OnPaymentFailed(new PaymentFailedEventArgs(this));
        }

        /// <summary>
        /// 异步每隔5秒轮询判断用户是否支付,总共轮询5次
        /// </summary>
        private async Task PollQueryTradeStateAsync(IAuxiliary auxiliary)
        {
            await Task.Run(() => PollQueryTradeState(auxiliary));
        }

        #endregion

        #region 小程序支付

        public string BuildAppletPayment()
        {
            return BuildAppPayment();
        }

        public void InitAppletPayment()
        {
        }

        #endregion

        #region 查询订单

        public void InitQuery(IAuxiliary auxiliary)
        {
            InitAuxiliaryParameter(GatewayAuxiliaryType.Query, auxiliary);
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        public INotify BuildQuery(IAuxiliary auxiliary)
        {
            InitQuery(auxiliary);

            Commit(Constant.ALIPAY_TRADE_QUERY_RESPONSE);

            return Notify;
        }

        #endregion

        #region 撤销订单

        public void InitCancel(IAuxiliary auxiliary)
        {
            InitAuxiliaryParameter(GatewayAuxiliaryType.Cancel, auxiliary);
        }

        /// <summary>
        /// 撤销订单
        /// </summary>
        public INotify BuildCancel(IAuxiliary auxiliary)
        {
            InitCancel(auxiliary);

            Commit(Constant.ALIPAY_TRADE_CANCEL_RESPONSE);

            return Notify;
        }

        #endregion

        #region 关闭订单

        public INotify BuildClose(IAuxiliary auxiliary)
        {
            InitClose(auxiliary);

            Commit(Constant.ALIPAY_TRADE_CLOSE_RESPONSE);

            return Notify;
        }

        public void InitClose(IAuxiliary auxiliary)
        {
            InitAuxiliaryParameter(GatewayAuxiliaryType.Close, auxiliary);
        }

        #endregion

        #region 对账单下载

        public FileStream BuildBillDownload(IAuxiliary auxiliary)
        {
            InitBillDownload(auxiliary);

            Commit(Constant.ALIPAY_DATA_DATASERVICE_BILL_DOWNLOADURL_QUERY_RESPONSE);

            GatewayData.FromUrl(Notify.BillDownloadUrl);

            return HttpUtil.Download(Notify.BillDownloadUrl, $"{DateTime.Now.ToString(TIMEFORMAT)}.{GatewayData.GetStringValue(Constant.FILETYPE)}");
        }

        public void InitBillDownload(IAuxiliary auxiliary)
        {
            Merchant.Method = Constant.BILLDOWNLOAD;
            Merchant.BizContent = Util.SerializeObject((Auxiliary)auxiliary);
            GatewayData.Add(Merchant);
            BuildSign();
        }

        #endregion

        #region 订单退款

        public INotify BuildRefund(IAuxiliary auxiliary)
        {
            InitRefund(auxiliary);

            Commit(Constant.ALIPAY_TRADE_REFUND_RESPONSE);

            return Notify;
        }

        public void InitRefund(IAuxiliary auxiliary)
        {
            InitAuxiliaryParameter(GatewayAuxiliaryType.Refund, auxiliary);
        }

        #endregion

        #region 查询退款订单

        public INotify BuildRefundQuery(IAuxiliary auxiliary)
        {
            InitRefundQuery(auxiliary);

            Commit(Constant.ALIPAY_TRADE_FASTPAY_REFUND_QUERY_RESPONSE);

            return Notify;
        }

        public void InitRefundQuery(IAuxiliary auxiliary)
        {
            InitAuxiliaryParameter(GatewayAuxiliaryType.RefundQuery, auxiliary);
        }

        #endregion

        protected override async Task<bool> CheckNotifyDataAsync()
        {
            base.Notify = await GatewayData.ToObjectAsync<Notify>();
            if (await IsSuccessResultAsync())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 初始化订单参数
        /// </summary>
        private void InitOrderParameter()
        {
            Merchant.BizContent = Util.SerializeObject(Order);
            GatewayData.Add(Merchant);
            BuildSign();

            ValidateParameter(Merchant);
            ValidateParameter(Order);
        }

        /// <summary>
        /// 初始化辅助接口的参数
        /// </summary>
        /// <param name="method">接口名称</param>
        private void InitAuxiliaryParameter(GatewayAuxiliaryType gatewayAuxiliaryType, IAuxiliary auxiliary)
        {
            auxiliary.Validate(gatewayAuxiliaryType);
            switch (gatewayAuxiliaryType)
            {
                case GatewayAuxiliaryType.Query:
                    Merchant.Method = Constant.QUERY;
                    break;
                case GatewayAuxiliaryType.Close:
                    Merchant.Method = Constant.CLOSE;
                    break;
                case GatewayAuxiliaryType.Cancel:
                    Merchant.Method = Constant.CANCEL;
                    break;
                case GatewayAuxiliaryType.Refund:
                    Merchant.Method = Constant.REFUND;
                    break;
                case GatewayAuxiliaryType.RefundQuery:
                    Merchant.Method = Constant.REFUNDQUERY;
                    break;
                default:
                    break;
            }
            Merchant.BizContent = Util.SerializeObject((Auxiliary)auxiliary);
            GatewayData.Add(Merchant);
            BuildSign();
        }

        /// <summary>
        /// 提交请求
        /// </summary>
        /// <param name="type">结果类型</param>
        private void Commit(string type)
        {
            string result = HttpUtil
                .PostAsync(GatewayUrl, GatewayData.ToUrlEncode())
                .GetAwaiter()
                .GetResult();
            ReadReturnResult(result, type);
        }

        private string GetPaymentQueryString()
        {
            return GatewayData.ToUrlEncode();
        }

        /// <summary>
        /// 读取返回结果
        /// </summary>
        /// <param name="result">结果</param>
        /// <param name="key">结果的对象名</param>
        private void ReadReturnResult(string result, string key)
        {
            GatewayData.FromJson(result);
            string sign = GatewayData.GetStringValue(Constant.SIGN);
            result = GatewayData.GetStringValue(key);
            GatewayData.FromJson(result);
            base.Notify = GatewayData.ToObject<Notify>();
            Notify.Sign = sign;
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        private void BuildSign()
        {
            Merchant.Sign = EncryptUtil.RSA2(GatewayData.ToUrl(), Merchant.Privatekey);
            GatewayData.Add(Constant.SIGN, Merchant.Sign);
        }

        /// <summary>
        /// 是否是已成功支付的支付通知
        /// </summary>
        /// <returns></returns>
        private async Task<bool> IsSuccessResultAsync()
        {
            if (ValidateNotifyParameter() && ValidateNotifySign() && await ValidateNotifyIdAsync())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 检查支付通知，是否支付成功
        /// </summary>
        /// <returns></returns>
        private bool ValidateNotifyParameter()
        {
            // 支付状态是否为成功。
            if (Notify.TradeStatus == Constant.TRADE_SUCCESS)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 验证支付宝通知的签名
        /// </summary>
        private bool ValidateNotifySign()
        {
            Merchant.Sign = EncryptUtil.RSA2(GatewayData.ToUrl(Constant.SIGN, Constant.SIGN_TYPE), Merchant.Privatekey);
            // 验证通知的签名
            if (Notify.Sign == Merchant.Sign)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 验证网关的通知Id是否有效
        /// </summary>
        private bool ValidateNotifyId()
        {
            string data = HttpUtil.Get(GetValidateNotifyUrl());
            GatewayData.FromXml(data);
            // 服务器异步通知的通知Id则会在输出标志成功接收到通知的success字符串后失效。
            if (GatewayData.GetStringValue(Constant.IS_SUCCESS) == Constant.T)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 异步验证网关的通知Id是否有效
        /// </summary>
        private async Task<bool> ValidateNotifyIdAsync()
        {
            return await Task.Run(() => ValidateNotifyId());
        }

        /// <summary>
        /// 获得验证支付宝通知的Url
        /// </summary>
        private string GetValidateNotifyUrl()
        {
            return $"{GatewayUrl}?service=notify_verify&partner={Merchant.AppId}&notify_id={Notify.NotifyId}";
        }

        #endregion

    }
}