using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICanPay.Abstractions
{
    /// <summary>
    /// NotifyHub 处理器
    /// </summary>
    public interface INotifyHubHandler
    {
        INotifyDataConverter Converter { get; }
        ProcessResult Process(IPaymentNotifyData notifyData);

    }

}
