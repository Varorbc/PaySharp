using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICanPay.Abstractions
{
    public class HubHandlerData
    {
        public string GatewayOrder { get; set; }
        public string BusinessOrder { get; set; }

        public DateTimeOffset ProcessTime { get; set; }

        public string GatewayType { get; set; }

        public object RawData { get; set; }
    }
}
