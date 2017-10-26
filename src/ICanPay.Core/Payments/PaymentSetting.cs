using System;

namespace ICanPay.Core
{
    /// <summary>
    /// 设置需要支付的订单的数据，创建支付订单URL地址或HTML表单
    /// </summary>
    public class PaymentSetting
    {

        #region 字段

        private GatewayBase gateway;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gateway">网关</param>
        public PaymentSetting(GatewayBase gateway)
        {
            this.gateway = gateway;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gateway">网关</param>
        /// <param name="order">订单</param>
        public PaymentSetting(GatewayBase gateway, IOrder order)
            : this(gateway)
        {
            this.gateway.Order = order;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 订单数据
        /// </summary>
        public IOrder Order
        {
            get
            {
                return gateway.Order;
            }

            set
            {
                gateway.Order = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 创建订单的支付Url、Form表单、二维码。
        /// </summary>
        /// <remarks>
        /// 如果创建的是订单的Url或Form表单将跳转到相应网关支付，如果是二维码将输出二维码图片。
        /// </remarks>
        public string Payment()
        {
            switch (gateway.GatewayTradeType)
            {
                case GatewayTradeType.App:
                    {
                        if (gateway is IAppPayment appPayment)
                        {
                            return appPayment.BuildAppPayment();
                        }
                    }
                    break;
                case GatewayTradeType.Wap:
                    {
                        if (gateway is IUrlPayment urlPayment)
                        {
                            HttpUtil.Redirect(urlPayment.BuildUrlPayment());
                            return null;
                        }
                    }
                    break;
                case GatewayTradeType.Web:
                    {
                        if (gateway is IFormPayment formPayment)
                        {
                            HttpUtil.Write(formPayment.BuildFormPayment());
                            return null;
                        }
                    }
                    break;
                case GatewayTradeType.Scan:
                    {
                        if (gateway is IScanPayment scanPayment)
                        {
                            return scanPayment.BuildScanPayment();
                        }
                    }
                    break;
                case GatewayTradeType.Public:
                    {
                        if (gateway is IPublicPayment publicPayment)
                        {
                            return publicPayment.BuildPublicPayment();
                        }
                    }
                    break;
                case GatewayTradeType.Barcode:
                    {
                        if (gateway is IBarcodePayment barcodePayment)
                        {
                            barcodePayment.BuildBarcodePayment();
                            return null;
                        }
                    }
                    break;
                case GatewayTradeType.Applet:
                    {
                        if (gateway is IAppletPayment appletPayment)
                        {
                            return appletPayment.BuildAppletPayment();
                        }
                    }
                    break;
                default:
                    break;
            }

            throw new NotSupportedException(gateway.GatewayType + " 没有实现支付接口");
        }

        #endregion
    }
}
