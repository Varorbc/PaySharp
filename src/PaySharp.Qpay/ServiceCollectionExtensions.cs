#if NETSTANDARD2_0
using Microsoft.Extensions.Configuration;
using PaySharp.Qpay;
using PaySharp.Core;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IGateways UseQpay(this IGateways gateways, Action<Merchant> action)
        {
            if (action != null)
            {
                var merchant = new Merchant();
                action(merchant);
                gateways.Add(new QpayGateway(merchant));
            }

            return gateways;
        }

        public static IGateways UseQpay(this IGateways gateways, IConfiguration configuration)
        {
            var merchants = configuration.GetSection("Qpay").Get<Merchant[]>();
            if (merchants != null)
            {
                for (int i = 0; i < merchants.Length; i++)
                {
                    gateways.Add(new QpayGateway(merchants[i]));
                }
            }

            return gateways;
        }
    }
}

#endif