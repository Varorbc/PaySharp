using System;
using System.Collections.Generic;
using System.Text;

namespace PaySharp.AspNetCore.DI
{
    public interface IGatewayBuilder
    {
        void Add(object gateway);

        IGatewayProvider Build();
    }
}
