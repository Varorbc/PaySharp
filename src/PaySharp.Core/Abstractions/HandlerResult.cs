using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Abstractions
{
    public class HandlerResult
    {
        public HandlerResult(NotifyResponse response)
        {
            Response = response ?? throw new ArgumentNullException(nameof(response));
        }
        public bool IsSuccess => Response.IsSuccess;
        public HubOrder Data { get; set; }

        public NotifyResponse Response { get; set; }
    }
}
