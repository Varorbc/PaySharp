using System;
using System.Collections.Generic;
using System.Text;

namespace ICanPay.AspNetCore.DI
{
    public interface IGatewayProvider
    {
        T GetGateway<T>();
        T GetGateway<T>(string gatewayName);
    }
}
