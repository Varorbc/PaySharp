using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaySharp.Abstractions;
using PaySharp.Alipay.DI.fake;

namespace PaySharp.Alipay
{
    public static class PaySharpBuilderExtensions
    {
        public static IPaySharpBuilder AddAlipay(this IPaySharpBuilder builder,Merchant option)
        {
            builder.AddOption(option);
            builder.TryAddService<IAlipayClient, FakeAlipayClient>();
            builder.TryAddService<IAlipayListener, FakeAlipayListener>();
            builder.TryAddService<AlipayFactory, AlipayFactory>();
            return builder;
        }
    }
}
