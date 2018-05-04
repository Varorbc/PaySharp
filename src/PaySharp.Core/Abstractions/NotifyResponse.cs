using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Abstractions
{
    public class NotifyResponse : IDisposable
    {
        public NotifyResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public virtual bool IsSuccess { get; private set; }
        public virtual int StatusCode { get; private set; }
        public virtual string ContentType { get; private set; }
        public virtual IDictionary<string, string> Headers { get; private set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public virtual IDictionary<string, string> Cookies { get; private set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public virtual Stream Body { get; private set; } = new MemoryStream();

        public virtual NotifyResponse SetStatusCode(int code)
        {
            StatusCode = code;
            return this;
        }
        public virtual NotifyResponse SetContentType(string type)
        {
            ContentType = type;
            return this;
        }
        public virtual NotifyResponse AddHeader(Action<IDictionary<string,string>> headerConfig)
        {
            headerConfig?.Invoke(Headers);
            return this;
        }

        public virtual NotifyResponse AddCookies(Action<IDictionary<string,string>> cookiesConfig)
        {
            cookiesConfig?.Invoke(Cookies);
            return this;
        }

        public virtual async Task<NotifyResponse> SetBodyAsync(Func<Stream,Task> bodyConfig)
        {
            if(bodyConfig != null)
            {
                await bodyConfig(Body);
            }
            Body.Seek(0, SeekOrigin.Begin);
            return this;
        }
        public virtual NotifyResponse SetBody(Action<Stream> bodyConfig)
        {
            bodyConfig?.Invoke(Body);
            Body.Seek(0, SeekOrigin.Begin);
            return this;
        }

        #region IDisposable Support
        private bool _isDisposed = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    Body?.Dispose();
                    Headers?.Clear();
                    Cookies?.Clear();
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                Body = null;
                Headers = null;
                Cookies = null;

                _isDisposed = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~NotifyResponse() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
