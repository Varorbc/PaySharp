using PaySharp.Abstractions;
using PaySharp.Alipay.DI.fake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Alipay.DI
{
    public static class PaySharpProviderExtensions
    {
        public static IAlipayClient CreateAlipayClient(this IPaySharpProvider provider)
        {
            var option = provider.GetRequired<Merchant>();
            return CreateAlipayClient(provider,option);
        }
        public static IAlipayClient CreateAlipayClient(this IPaySharpProvider provider,Merchant merchant)
        {
            var factory = provider.GetRequired<AlipayFactory>();
            return factory.CreateClient(merchant);
        }

        public static IAlipayListener CreateAlipayListener(this IPaySharpProvider provider,Merchant merchant)
        {
            throw new NotImplementedException();
        }
    }
}
