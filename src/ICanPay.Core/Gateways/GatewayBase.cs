using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ICanPay.Core
{
    /// <summary>
    /// 支付网关的抽象基类
    /// </summary>
    public abstract class GatewayBase
    {
        #region 公共字段

        public const string TRUE = "true";
        public const string FALSE = "false";
        public const string SUCCESS = "success";
        public const string FAILURE = "failure";
        public const string FAIL = "FAIL";
        public const string TIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        #endregion

        #region 私有字段

        private GatewayData gatewayData;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        protected GatewayBase()
            : this(new GatewayData())
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="merchant">商户数据</param>
        protected GatewayBase(IMerchant merchant)
            : this(new GatewayData())
        {
            Merchant = merchant;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gatewayData">网关数据</param>
        protected GatewayBase(GatewayData gatewayData)
        {
            this.gatewayData = gatewayData;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 订单数据
        /// </summary>
        public IOrder Order { get; set; }

        /// <summary>
        /// 商户数据
        /// </summary>
        public IMerchant Merchant { get; set; }

        /// <summary>
        /// 通知数据
        /// </summary>
        public INotify Notify { get; set; }

        /// <summary>
        /// 支付网关的类型
        /// </summary>
        public abstract GatewayType GatewayType { get; }

        /// <summary>
        /// 支付网关的地址
        /// </summary>
        public abstract string GatewayUrl { get; set; }

        /// <summary>
        /// 支付网关的交易类型
        /// </summary>
        public GatewayTradeType GatewayTradeType { get; set; }

        /// <summary>
        /// 网关数据
        /// </summary>
        public GatewayData GatewayData
        {
            get
            {
                return gatewayData;
            }
            set
            {
                gatewayData = value;
            }
        }

        /// <summary>
        /// 是否成功支付
        /// </summary>
        protected abstract bool IsSuccessPay { get; }

        /// <summary>
        /// 是否等待支付
        /// </summary>
        protected abstract bool IsWaitPay { get; }

        #endregion

        #region 方法

        #region 抽象方法

        /// <summary>
        /// 检验网关返回的通知，确认订单是否支付成功
        /// </summary>
        protected abstract Task<bool> CheckNotifyDataAsync();

        /// <summary>
        /// 当接收到支付网关通知并验证无误时按照支付网关要求格式输出表示成功接收到网关通知的字符串
        /// </summary>
        public virtual void WriteSuccessFlag()
        {
            HttpUtil.Write(SUCCESS);
        }

        /// <summary>
        /// 当接收到支付网关通知并验证有误时按照支付网关要求格式输出表示失败接收到网关通知的字符串
        /// </summary>
        public virtual void WriteFailureFlag()
        {
            HttpUtil.Write(FAILURE);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 验证订单是否支付成功
        /// </summary>
        internal async Task<bool> ValidateNotifyAsync()
        {
            if (await CheckNotifyDataAsync())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="instance">验证对象</param>
        protected void ValidateParameter(object instance)
        {
            var validationContext = new ValidationContext(instance, new Dictionary<object, object>
            {
                { "GatewayTradeType", GatewayTradeType }
            });
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instance, validationContext, results, true);

            if (!isValid)
            {
                throw new ArgumentNullException(results[0].ErrorMessage);
            }
        }

        /// <summary>
        /// 读取通知
        /// </summary>
        protected void ReadNotify<T>() where T : INotify
        {
            var type = typeof(T);
            var notify = Activator.CreateInstance(type);
            var properties = type.GetProperties();

            foreach (var item in properties)
            {
                string key = item
                    .GetCustomAttributesData()[0]
                    .NamedArguments[0]
                    .TypedValue
                    .Value
                    .ToString();
                object value = GatewayData.GetValue(key);

                if (value != null)
                {
                    item.SetValue(notify, Convert.ChangeType(value, item.PropertyType));
                }
            }

            Notify = (INotify)notify;
        }

        /// <summary>
        /// 异步读取通知
        /// </summary>
        protected async Task ReadNotifyAsync<T>() where T : INotify
        {
            await Task.Run(() => ReadNotify<T>());
        }

        protected void OnPaymentFailed(PaymentFailedEventArgs e) => PaymentFailed?.Invoke(this, e);

        protected void OnPaymentSucceed(PaymentSucceedEventArgs e) => PaymentSucceed?.Invoke(this, e);

        #endregion

        #region 公共方法

        /// <summary>
        /// 支付
        /// </summary>
        public string Payment()
        {
            switch (GatewayTradeType)
            {
                case GatewayTradeType.App:
                    {
                        if (this is IAppPayment appPayment)
                        {
                            return appPayment.BuildAppPayment();
                        }
                    }
                    break;
                case GatewayTradeType.Wap:
                    {
                        if (this is IUrlPayment urlPayment)
                        {
                            HttpUtil.Redirect(urlPayment.BuildUrlPayment());
                            return null;
                        }
                    }
                    break;
                case GatewayTradeType.Web:
                    {
                        if (this is IFormPayment formPayment)
                        {
                            HttpUtil.Write(formPayment.BuildFormPayment());
                            return null;
                        }
                    }
                    break;
                case GatewayTradeType.Scan:
                    {
                        if (this is IScanPayment scanPayment)
                        {
                            return scanPayment.BuildScanPayment();
                        }
                    }
                    break;
                case GatewayTradeType.Public:
                    {
                        if (this is IPublicPayment publicPayment)
                        {
                            return publicPayment.BuildPublicPayment();
                        }
                    }
                    break;
                case GatewayTradeType.Barcode:
                    {
                        if (this is IBarcodePayment barcodePayment)
                        {
                            barcodePayment.BuildBarcodePayment();
                            return null;
                        }
                    }
                    break;
                case GatewayTradeType.Applet:
                    {
                        if (this is IAppletPayment appletPayment)
                        {
                            return appletPayment.BuildAppletPayment();
                        }
                    }
                    break;
                default:
                    break;
            }

            throw new NotSupportedException($"{GatewayType} 没有实现 {GatewayTradeType} 接口");
        }

        /// <summary>
        /// 查询
        /// </summary>
        public INotify Query()
        {
            if (this is IQuery query)
            {
                return query.BuildQuery();
            }

            throw new NotSupportedException($"{GatewayType} 没有实现 IQuery 查询接口");
        }

        /// <summary>
        /// 撤销/关闭
        /// </summary>
        public INotify Cancel()
        {
            if (this is ICancel cancel)
            {
                return cancel.BuildCancel();
            }

            throw new NotSupportedException($"{GatewayType} 没有实现 ICancel 查询接口");
        }

        #endregion

        #endregion

        #region 事件

        /// <summary>
        /// 网关同步返回的支付通知验证失败时触发,目前仅针对条码支付
        /// </summary>
        public event Action<object, PaymentFailedEventArgs> PaymentFailed;

        /// <summary>
        /// 网关同步返回的支付通知验证成功时触发,目前仅针对条码支付
        /// </summary>
        public event Action<object, PaymentSucceedEventArgs> PaymentSucceed;

        #endregion
    }
}
