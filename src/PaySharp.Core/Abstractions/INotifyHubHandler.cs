using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Abstractions
{
    /// <summary>
    /// NotifyHub 处理器
    /// </summary>
    public interface INotifyHubHandler
    {
        [Obsolete("似乎没什么用", true)]
        INotifyDataConverter Converter { get; }
        Task<ProcessResult> ProcessAsync(IKeyValueProvider valueProvider);

    }

}
