using System;
using System.Threading.Tasks;
using PaySharp.Core.Exceptions;
using PaySharp.Core.Utils;

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



        private async Task<NotifyEventArgs> GetNotifyEvent(BaseGateway gateway)
        {
            if (gateway is NullGateway)
            {
                return new UnknownGatewayEventArgs(gateway);
            }

            if (!await gateway.ValidateNotifyAsync())
            {
                return new UnKnownNotifyEventArgs(gateway) { Message = "签名验证失败" };
            }

            if (HttpUtil.RequestType == "GET")
            {
                return new PaySucceedEventArgs(gateway);
            }

            if (gateway.IsPaySuccess)
            {
                return new PaySucceedEventArgs(gateway);
            }

            if (gateway.IsRefundSuccess)
            {
                return new RefundSucceedEventArgs(gateway);
            }

            if (gateway.IsCancelSuccess)
            {
                return new CancelSucceedEventArgs(gateway);
            }

            return new UnKnownNotifyEventArgs(gateway);


        }
        private async Task<SendEventResult> SendNotifyEventAsync(BaseGateway gateway)
        {
            var success = false;
            try
            {
                var eventArgs = await GetNotifyEvent(gateway);
                switch (eventArgs)
                {
                    case UnknownGatewayEventArgs unknownGatewayEventArgs:
                        OnUnknownGateway(unknownGatewayEventArgs);
                        break;
                    case UnKnownNotifyEventArgs unKnownNotifyEventArgs:
                        OnUnknownNotify(unKnownNotifyEventArgs);
                        break;
                    case PaySucceedEventArgs args:
                    {
                        OnPaySucceed(args);
                        success = true;
                    }
                    break;
                    case RefundSucceedEventArgs refundSucceedEventArgs:
                    {
                        OnRefundSucceed(refundSucceedEventArgs);
                        success = true;
                    }
                    break;
                    case CancelSucceedEventArgs cancelSucceedEventArgs:
                    {
                        OnCancelSucceed(cancelSucceedEventArgs);
                        success = true;
                    }
                    break;
                }
            }
            catch (GatewayException ex)
            {
                OnUnknownNotify(new UnKnownNotifyEventArgs(gateway)
                {
                    Message = ex.Message
                });

            }


            return new SendEventResult(gateway,success);
        }


        /// <summary>
        /// 接收并验证网关的支付通知
        /// </summary>
        public async Task<SendEventResult> ReceivedAsync(bool writeFlag = false)
        {
            var gateway = await NotifyProcess.GetGatewayAsync(_gateways);
            var sendEventResult = await SendNotifyEventAsync(gateway);

            if (writeFlag)
            {
                sendEventResult.WriteFlagXml();
            }

            return sendEventResult;


            // var gateway = await NotifyProcess.GetGatewayAsync(_gateways);
            // if (gateway is NullGateway)
            // {
            //     OnUnknownGateway(new UnknownGatewayEventArgs(gateway));
            //     return;
            // }
            //
            // try
            // {
            //     if (!await gateway.ValidateNotifyAsync())
            //     {
            //         OnUnknownNotify(new UnKnownNotifyEventArgs(gateway)
            //         {
            //             Message = "签名验证失败"
            //         });
            //         gateway.WriteFailureFlag();
            //         return;
            //     }
            //
            //     if (HttpUtil.RequestType == "GET")
            //     {
            //         OnPaySucceed(new PaySucceedEventArgs(gateway));
            //         return;
            //     }
            //
            //     var result = false;
            //     if (gateway.IsPaySuccess)
            //     {
            //         result = OnPaySucceed(new PaySucceedEventArgs(gateway));
            //     }
            //     else if (gateway.IsRefundSuccess)
            //     {
            //         result = OnRefundSucceed(new RefundSucceedEventArgs(gateway));
            //     }
            //     else if (gateway.IsCancelSuccess)
            //     {
            //         result = OnCancelSucceed(new CancelSucceedEventArgs(gateway));
            //     }
            //     else
            //     {
            //         result = OnUnknownNotify(new UnKnownNotifyEventArgs(gateway));
            //     }
            //
            //     if (result)
            //     {
            //         gateway.WriteSuccessFlag();
            //     }
            //     else
            //     {
            //         gateway.WriteFailureFlag();
            //     }
            // }
            // catch (GatewayException ex)
            // {
            //     OnUnknownNotify(new UnKnownNotifyEventArgs(gateway)
            //     {
            //         Message = ex.Message
            //     });
            //     gateway.WriteFailureFlag();
            // }
        }

        #endregion
    }
}
