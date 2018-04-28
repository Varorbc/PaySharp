using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Abstractions
{
    /// <summary>
    /// 通知数据转换器， 他从HttpContext 转换为强类型数据
    /// </summary>
    /// <remarks>HttpContext在实现的类中采用构造函数注入，</remarks>
    public interface INotifyDataConverter
    {
        Task<object> ConvertDataAsync();
    }

    public interface INotifyDataConverter<T> : INotifyDataConverter
    {
        new Task<T> ConvertDataAsync();
    }
}
