using System;

namespace ICanPay.Core
{
    /// <summary>
    /// 商户数据
    /// </summary>
    public class Merchant
    {

        #region 私有字段

        string userName;
        string key;
        Uri notifyUrl;

        #endregion


        #region 构造函数

        public Merchant()
        {
        }


        public Merchant(string userName, string key, Uri notifyUrl, GatewayBase gateway)
        {
            this.userName = userName;
            this.key = key;
            this.notifyUrl = notifyUrl;
            Gateway = gateway;
        }

        #endregion


        #region 属性

        /// <summary>
        /// 商户帐号
        /// </summary>
        public string UserName
        {
            get
            {
                if (string.IsNullOrEmpty(userName))
                {
                    throw new ArgumentNullException("UserName", "商户帐号没有设置");
                }

                return userName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("UserName", "商户帐号不能为空");
                }

                userName = value;
            }
        }


        /// <summary>
        /// 商户密钥
        /// </summary>
        public string Key
        {
            get
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException("Key", "商户密钥没有设置");
                }

                return key;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Key", "商户密钥不能为空");
                }

                key = value;
            }
        }


        /// <summary>
        /// 网关回发通知URL
        /// </summary>
        public Uri NotifyUrl
        {
            get
            {
                if (notifyUrl == null)
                {
                    throw new ArgumentNullException("NotifyUrl", "网关通知Url没有设置");
                }

                return notifyUrl;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("NotifyUrl", "网关通知Url不能为空");
                }

                notifyUrl = value;
            }
        }


        /// <summary>
        /// 网关
        /// </summary>
        public GatewayBase Gateway { get; set; }

        #endregion

    }
}