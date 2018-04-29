using System;
using System.Collections.Generic;
using System.Text;

namespace PaySharp.Abstractions
{
    public interface IGatewayProvider
    {
        T GetGateway<T>() where T : class;
        T GetGateway<T>(string gatewayName) where T : class;
    }
}
