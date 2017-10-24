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

        #endregion

        #region 方法

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
        private void ValidateParameter(object instance)
        {
            var validationContext = new ValidationContext(instance, new Dictionary<object, object>
            {
                { "GatewayTradeType", GatewayTradeType }
            });
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instance, validationContext, results, true);

            if (!isValid)
            {
                throw new Exception(results[0].ErrorMessage);
            }
        }

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

        /// <summary>
        /// 初始化订单参数
        /// </summary>
        protected virtual void InitOrderParameter()
        {
            SupplementaryParameter();
        }

        /// <summary>
        /// 补充不同支付类型的缺少参数
        /// </summary>
        private void SupplementaryParameter()
        {
            switch (GatewayTradeType)
            {
                case GatewayTradeType.App:
                    {
                        SupplementaryAppParameter();
                    }
                    break;
                case GatewayTradeType.Wap:
                    {
                        SupplementaryWapParameter();
                    }
                    break;
                case GatewayTradeType.Web:
                    {
                        SupplementaryWebParameter();
                    }
                    break;
                case GatewayTradeType.Scan:
                    {
                        SupplementaryScanParameter();
                    }
                    break;
                case GatewayTradeType.Public:
                    {
                        SupplementaryPublicParameter();
                    }
                    break;
                case GatewayTradeType.Barcode:
                    {
                        SupplementaryBarcodeParameter();
                    }
                    break;
                case GatewayTradeType.Applet:
                    {
                        SupplementaryAppletParameter();
                    }
                    break;
                default:
                    break;
            }

            ValidateParameter(Merchant);
            ValidateParameter(Order);
        }

        /// <summary>
        /// 补充移动支付的缺少参数
        /// </summary>
        protected abstract void SupplementaryAppParameter();

        /// <summary>
        /// 补充电脑网站支付的缺少参数
        /// </summary>
        protected abstract void SupplementaryWebParameter();

        /// <summary>
        /// 补充手机网站支付的缺少参数
        /// </summary>
        protected abstract void SupplementaryWapParameter();

        /// <summary>
        /// 补充扫码支付的缺少参数
        /// </summary>
        protected abstract void SupplementaryScanParameter();

        /// <summary>
        /// 补充公众号支付的缺少参数
        /// </summary>
        protected virtual void SupplementaryPublicParameter()
        {
        }

        /// <summary>
        /// 补充条码支付的缺少参数
        /// </summary>
        protected abstract void SupplementaryBarcodeParameter();

        /// <summary>
        /// 补充小程序支付的缺少参数
        /// </summary>
        protected virtual void SupplementaryAppletParameter()
        {
        }

        /// <summary>
        /// 读取通知
        /// </summary>
        protected void ReadNotify<T>() where T : INotify
        {
            Task.Run(() =>
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
            })
            .GetAwaiter()
            .GetResult();
        }

        #endregion

    }
}
