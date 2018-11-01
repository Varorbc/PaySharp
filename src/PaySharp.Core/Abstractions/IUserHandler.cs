using PaySharp.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Abstractions
{
    /// <summary>
    /// 用户逻辑处理器
    /// </summary>
    public interface IUserHandler
    {
        
        Task OnProcessingAsync(IKeyValueProvider keyValueProvider);

        Task OnProcessedAsync(HubOrder hubOrder, IKeyValueProvider valueProvider);

        Task OnSuccessedAsync(HubOrder hubOrder, IKeyValueProvider provider);

        Task OnFailedAsync(HubOrder hubOrder, IKeyValueProvider provider);

        Task OnExceptionAsync(Exception exception, IKeyValueProvider provider);
    }
}
