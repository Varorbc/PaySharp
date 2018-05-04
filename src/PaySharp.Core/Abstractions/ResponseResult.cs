using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Abstractions
{
    public class ResponseResult
    {
        public bool IsSuccess { get; set; }

        public NotifyResponse Response { get; set; }
    }
}
