using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICanPay.Abstractions
{
    public class ProcessResult
    {
        public bool IsSuccess { get; private set; }
        public HubHandlerData Data { get; private set; }
        private ProcessResult(bool state,HubHandlerData data)
        {
            IsSuccess = state;
            Data = data;
        }
        public static ProcessResult Success(HubHandlerData data)
        {
            return new ProcessResult(true, data);
        }

        public static ProcessResult Fail(HubHandlerData data)
        {
            return new ProcessResult(false, data);
        }
    }
}
