using PaySharp.Core.Exceptions;
using PaySharp.Core.Utils;
using System;
using System.Threading.Tasks;

namespace PaySharp.Core
{
    /// <summary>
    /// 网关返回的支付通知数据的接受
    /// </summary>
    public class Notify
    {
        #region 私有字段

        private readonly IGateways _gateways;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化支付通知
        /// </summary>
        /// <param name="gateways">用于验证支付网关返回数据的网关列表</param>
        public Notify(IGateways gateways)
        {
            _gateways = gateways;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 网关异步返回的支付通知验证成功时触发
        /// </summary>
        public event Func<object, PaySucceedEventArgs, bool> PaySucceed;

        /// <summary>
        /// 网关异步返回的撤销通知验证成功时触发
        /// </summary>
        public event Func<object, CancelSucceedEventArgs, bool> CancelSucceed;

        /// <summary>
        /// 网关异步返回的退款通知验证成功时触发
        /// </summary>
        public event Func<object, RefundSucceedEventArgs, bool> RefundSucceed;

        /// <summary>
        /// 网关异步返回的未知通知时触发
        /// </summary>
        public event Func<object, UnKnownNotifyEventArgs, bool> UnknownNotify;

        /// <summary>
        /// 找不到网关时触发
        /// </summary>
        public event Action<object, UnknownGatewayEventArgs> UnknownGateway;

        #endregion

        #region 方法

        private bool OnPaySucceed(PaySucceedEventArgs e) => PaySucceed?.Invoke(this, e) ?? false;

        private bool OnCancelSucceed(CancelSucceedEventArgs e) => CancelSucceed?.Invoke(this, e) ?? false;

        private bool OnRefundSucceed(RefundSucceedEventArgs e) => RefundSucceed?.Invoke(this, e) ?? false;

        private bool OnUnknownNotify(UnKnownNotifyEventArgs e) => UnknownNotify?.Invoke(this, e) ?? false;

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
                if (!await gateway.ValidateNotifyAsync())
                {
                    OnUnknownNotify(new UnKnownNotifyEventArgs(gateway)
                    {
                        Message = "签名验证失败"
                    });
                    gateway.WriteFailureFlag();
                    return;
                }

                if (HttpUtil.RequestType == "GET")
                {
                    OnPaySucceed(new PaySucceedEventArgs(gateway));
                    return;
                }

                bool result = false;
                if (gateway.IsPaySuccess)
                {
                    result = OnPaySucceed(new PaySucceedEventArgs(gateway));
                }
                else if (gateway.IsRefundSuccess)
                {
                    result = OnRefundSucceed(new RefundSucceedEventArgs(gateway));
                }
                else if (gateway.IsCancelSuccess)
                {
                    result = OnCancelSucceed(new CancelSucceedEventArgs(gateway));
                }
                else
                {
                    result = OnUnknownNotify(new UnKnownNotifyEventArgs(gateway));
                }

                if (result)
                {
                    gateway.WriteSuccessFlag();
                }
                else
                {
                    gateway.WriteFailureFlag();
                }
            }
            catch (GatewayException ex)
            {
                OnUnknownNotify(new UnKnownNotifyEventArgs(gateway)
                {
                    Message = ex.Message
                });
                gateway.WriteFailureFlag();
            }
        }

        #endregion
    }
}