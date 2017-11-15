using System;

namespace ICanPay.Core.Exceptions
{
    public class GatewayException : Exception
    {
        public GatewayException(string message)
            : base(message)
        {
        }
    }
}
