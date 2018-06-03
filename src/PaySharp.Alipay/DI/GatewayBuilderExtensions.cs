using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaySharp.Abstractions;

namespace PaySharp.Alipay
{
    public static class GatewayBuilderExtensions
    {
        public static IGatewayBuilder AddAlipay(this IGatewayBuilder builder)
        {
            
            return builder;
        }
    }
}
