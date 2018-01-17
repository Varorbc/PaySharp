using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICanPay.Abstractions
{
    public interface INotifyResponse
    {

        INotifyResponse SetStateCode(int code);
        INotifyResponse SetContextType(string type);
        INotifyResponse AddHeader(IDictionary<string, string> headers);

        INotifyResponse AddCookies(IDictionary<string, string> cookies);

        Task WriteBodyAsync(Stream bodyStream);
    }
}
