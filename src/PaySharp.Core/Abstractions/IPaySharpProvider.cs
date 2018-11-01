using System;
using System.Collections.Generic;
using System.Text;

namespace PaySharp.Abstractions
{
    public interface IPaySharpProvider
    {
        T GetRequired<T>() where T : class;
        IEnumerable<T> GetMutiple<T>() where T : class;

        T GetOption<T>() where T : class, IPaySharpOption;

        IEnumerable<T> GetOptions<T>() where T : class, IPaySharpOption;
    }
}
