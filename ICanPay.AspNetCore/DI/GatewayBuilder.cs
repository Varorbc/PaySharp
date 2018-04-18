using System;
using System.Collections.Generic;
using System.Text;

namespace ICanPay.AspNetCore.DI
{
    public class GatewayBuilder : IGatewayBuilder
    {
        public void Add(object gateway)
        {
            throw new NotImplementedException();
        }

        public IGatewayProvider Build()
        {
            throw new NotImplementedException();
        }
    }
}
