using ICanPay.Core.Request;
using System;
using System.Threading.Tasks;

namespace ICanPay.Core
{
    /// <summary>
    /// 未知网关
    /// </summary>
    public class NullGateway : GatewayBase
    {

        #region 属性

        public override string GatewayUrl { get; set; } = string.Empty;

        protected internal override bool IsSuccessPay => false;

        protected override bool IsWaitPay => false;

        protected internal override string[] NotifyVerifyParameter => new string[0];

        #endregion

        #region 方法

        protected internal override async Task<bool> ValidateNotifyAsync()
        {
            return await Task.Run(() => { return false; });
        }

        public override T SdkExecute<T>(Request<T> request)
        {
            throw new NotImplementedException();
        }

        public override T Execute<T>(Request<T> request)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
