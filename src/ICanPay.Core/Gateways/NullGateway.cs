﻿using ICanPay.Core.Request;
using System;
using System.Threading.Tasks;

namespace ICanPay.Core
{
    /// <summary>
    /// 未知网关
    /// </summary>
    public class NullGateway : BaseGateway
    {
        public override string GatewayUrl { get; set; }

        protected internal override bool IsSuccessPay { get; }

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
