using PaySharp.Core.Request;
using System;
using System.Threading.Tasks;

namespace PaySharp.Core
{
    /// <summary>
    /// 未知网关
    /// </summary>
    public class NullGateway : BaseGateway
    {
        public override string GatewayUrl { get; set; }

        protected internal override bool IsPaySuccess { get; }

        protected internal override bool IsRefundSuccess { get; }

        protected internal override bool IsCancelSuccess { get; }

        protected internal override string[] NotifyVerifyParameter { get; }

        protected internal override async Task<bool> ValidateNotifyAsync()
        {
            return await Task.Run(() => { return false; });
        }

        public override TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request)
        {
            throw new NotImplementedException();
        }
    }
}
