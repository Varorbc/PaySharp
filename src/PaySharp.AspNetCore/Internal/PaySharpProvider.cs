using PaySharp.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaySharp.AspNetCore.Internal
{
    public class PaySharpProvider : IPaySharpProvider
    {
        public IEnumerable<T> GetMutiple<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T GetRequired<T>() where T : class
        {
            throw new NotImplementedException();
        }

        T IPaySharpProvider.GetOption<T>()
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IPaySharpProvider.GetOptions<T>()
        {
            throw new NotImplementedException();
        }
    }
}
