using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Abstractions
{
    public class ProcessResult
    {
        public bool IsSuccess { get; private set; }
        public HubOrder Data { get; private set; }
        private ProcessResult(bool state,HubOrder data)
        {
            IsSuccess = state;
            Data = data;
        }
        public static ProcessResult Success(HubOrder data)
        {
            return new ProcessResult(true, data);
        }

        public static ProcessResult Fail(HubOrder data)
        {
            return new ProcessResult(false, data);
        }
    }
}
