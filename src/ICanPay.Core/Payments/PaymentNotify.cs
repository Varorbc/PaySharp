using System;
using System.Threading.Tasks;

namespace ICanPay.Core
{
    /// <summary>
    /// 网关返回的支付通知数据的接受
    /// </summary>
    public class PaymentNotify
    {
        #region 私有字段

        private IGateways gateways;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化支付通知
        /// </summary>
        /// <param name="gateways">用于验证支付网关返回数据的网关列表</param>
        public PaymentNotify(IGateways gateways)
        {
            this.gateways = gateways;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 网关异步返回的支付通知验证失败时触发
        /// </summary>
        public event Action<object, PaymentFailedEventArgs> PaymentFailed;

        /// <summary>
        /// 网关异步返回的支付通知验证成功时触发
        /// </summary>
        public event Action<object, PaymentSucceedEventArgs> PaymentSucceed;

        /// <summary>
        /// 网关异步返回的支付通知无法识别时触发
        /// </summary>
        public event Action<object, UnknownGatewayEventArgs> UnknownGateway;

        #endregion

        #region 方法

        private void OnPaymentFailed(PaymentFailedEventArgs e) => PaymentFailed?.Invoke(this, e);

        private void OnPaymentSucceed(PaymentSucceedEventArgs e) => PaymentSucceed?.Invoke(this, e);

        private void OnUnknownGateway(UnknownGatewayEventArgs e) => UnknownGateway?.Invoke(this, e);

        /// <summary>
        /// 接收并验证网关的支付通知
        /// </summary>
        public async Task ReceivedAsync()
        {
            GatewayBase gateway = NotifyProcess.GetGateway(gateways);
            if (gateway.GatewayType != GatewayType.None)
            {
                if (await gateway.ValidateNotifyAsync())
                {
                    OnPaymentSucceed(new PaymentSucceedEventArgs(gateway));
                    gateway.WriteSuccessFlag();
                }
                else
                {
                    OnPaymentFailed(new PaymentFailedEventArgs(gateway));
                    gateway.WriteFailureFlag();
                }
            }
            else
            {
                OnUnknownGateway(new UnknownGatewayEventArgs(gateway));
            }
        }

        #endregion

    }
}