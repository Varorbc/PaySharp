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

        public bool CanQueryNotify
        {
            get
            {
                if (gateway is IQueryUrl || gateway is IQueryForm)
                {
                    return true;
                }

                return false;
            }
        }

        public bool CanQueryNow
        {
            get
            {
                return gateway is IQueryNow;
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
            if (gateway.GatewayTradeType == GatewayTradeType.Wap && gateway is IPaymentUrl paymentUrl)
            {
                HttpUtil.Redirect(paymentUrl.BuildPaymentUrl());
                return null;
            }

            if (gateway.GatewayTradeType == GatewayTradeType.Web && gateway is IPaymentForm paymentForm)
            {
                HttpUtil.Write(paymentForm.BuildPaymentForm());
                return null;
            }

            if (gateway.GatewayTradeType == GatewayTradeType.App && gateway is IPaymentApp paymentApp)
            {
                return paymentApp.BuildPaymentApp();
            }

            if (gateway.GatewayTradeType == GatewayTradeType.Scan && gateway is IPaymentQRCode paymentQRCode)
            {
                BuildQRCodeImage(paymentQRCode.BuildPaymentQRCode());
                return null;
            }

            throw new NotSupportedException(gateway.GatewayType + " 没有实现支付接口");
        }

        /// <summary>
        /// 查询订单，订单的查询通知数据通过跟支付通知一样的形式反回。用处理网关通知一样的方法接受查询订单的数据。
        /// </summary>
        public void QueryNotify()
        {
            if (gateway is IQueryUrl queryUrl)
            {
                HttpUtil.Redirect(queryUrl.BuildQueryUrl());
                return;
            }

            if (gateway is IQueryForm queryForm)
            {
                HttpUtil.Write(queryForm.BuildQueryForm());
                return;
            }

            throw new NotSupportedException(gateway.GatewayType + " 没有实现 IQueryUrl 或 IQueryForm 查询接口");
        }

        /// <summary>
        /// 查询订单，立即获得订单的查询结果
        /// </summary>
        /// <returns></returns>
        public bool QueryNow()
        {
            if (gateway is IQueryNow queryNow)
            {
                return queryNow.QueryNow();
            }

            throw new NotSupportedException(gateway.GatewayType + " 没有实现 IQueryNow 查询接口");
        }

        /// <summary>
        /// 生成并输出二维码图片
        /// </summary>
        /// <param name="qrCodeContent">二维码内容</param>
        private void BuildQRCodeImage(string qrCodeContent)
        {
#if NET35
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder
            {
                QRCodeScale = 4  // 二维码大小
            };
            Bitmap image = qrCodeEncoder.Encode(qrCodeContent, Encoding.Default);
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            HttpContext.Current.Response.ContentType = "image/x-png";
            HttpContext.Current.Response.BinaryWrite(ms.GetBuffer());
#endif
        }

        #endregion

    }
}
