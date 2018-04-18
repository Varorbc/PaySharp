using System;
using System.Collections.Generic;
using System.Text;

namespace ICanPay.AspNetCore.DI
{
    public interface IGatewayBuilder
    {
        void Add(object gateway);

        IGatewayProvider Build();
    }
}
