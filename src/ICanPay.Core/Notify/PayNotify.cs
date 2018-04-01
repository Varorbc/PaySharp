using ICanPay.Core.Exceptions;
using ICanPay.Core.Utils;
using System;
using System.Threading.Tasks;

namespace ICanPay.Core
{
    /// <summary>
    /// 网关返回的支付通知数据的接受
    /// </summary>
    public class PayNotify
    {
        #region 私有字段

        private readonly IGateways _gateways;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化支付通知
        /// </summary>
        /// <param name="gateways">用于验证支付网关返回数据的网关列表</param>
        public PayNotify(IGateways gateways)
        {
            _gateways = gateways;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 网关异步返回的支付通知验证失败时触发
        /// </summary>
        public event Action<object, PayFailedEventArgs> PayFailed;

        /// <summary>
        /// 网关异步返回的支付通知验证成功时触发
        /// </summary>
        public event Func<object, PaySucceedEventArgs, bool> PaySucceed;

        /// <summary>
        /// 网关异步返回的支付通知无法识别时触发
        /// </summary>
        public event Action<object, UnknownGatewayEventArgs> UnknownGateway;

        #endregion

        #region 方法

        private void OnPayFailed(PayFailedEventArgs e) => PayFailed?.Invoke(this, e);

        private bool OnPaySucceed(PaySucceedEventArgs e) => PaySucceed?.Invoke(this, e) ?? false;

        private void OnUnknownGateway(UnknownGatewayEventArgs e) => UnknownGateway?.Invoke(this, e);

        /// <summary>
        /// 接收并验证网关的支付通知
        /// </summary>
        public async Task ReceivedAsync()
        {
            var gateway = NotifyProcess.GetGateway(_gateways);
            if (gateway is NullGateway)
            {
                OnUnknownGateway(new UnknownGatewayEventArgs(gateway));
                return;
            }

            try
            {
                if (await gateway.ValidateNotifyAsync())
                {
                    if (HttpUtil.RequestType == "GET")
                    {
                        OnPaySucceed(new PaySucceedEventArgs(gateway));
                        return;
                    }

                    if (!gateway.IsSuccessPay)
                    {
                        OnPayFailed(new PayFailedEventArgs(gateway));
                        gateway.WriteFailureFlag();
                        return;
                    }

                    bool result = OnPaySucceed(new PaySucceedEventArgs(gateway));
                    if (result)
                    {
                        gateway.WriteSuccessFlag();
                    }
                    else
                    {
                        gateway.WriteFailureFlag();
                    }
                }
                else
                {
                    OnPayFailed(new PayFailedEventArgs(gateway));
                    gateway.WriteFailureFlag();
                }
            }
            catch (GatewayException ex)
            {
                OnPayFailed(new PayFailedEventArgs(gateway)
                {
                    Message = ex.Message
                });
                gateway.WriteFailureFlag();
            }
        }

        #endregion
    }
}