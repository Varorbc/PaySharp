#if NETSTANDARD2_0
using PaySharp.Alipay;
using PaySharp.Core;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IGateways UseAlipay(this IGateways gateways, IConfigurationSection configuration)
        {
            var merchants = configuration.Get<Merchant[]>();
            if (merchants != null)
            {
                for (int i = 0; i < merchants.Length; i++)
                {
                    gateways.Add(new AlipayGateway(merchants[i]));
                }
            }

            return gateways;
        }
    }
}

#endif