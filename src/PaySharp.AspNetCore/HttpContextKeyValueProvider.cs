using PaySharp.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PaySharp.AspNetCore
{
    /// <summary>
    /// Asp.Net-Core 的键值提供器
    /// </summary>
    public class HttpContextKeyValueProvider : IKeyValueProvider
    {
        public HttpContext HttpContext { get; }

        public IEnumerable<string> SupportedParts => _supportedParts;

        private IEnumerable<string> _supportedParts = new[] { "QueryString", "Form" };

        public HttpContextKeyValueProvider(IHttpContextAccessor httpContextAccessor)
        {
            HttpContext = httpContextAccessor.HttpContext;
        }

        /// <inheritdoc />
        public byte[] Get()
        {
            using(var ms = new MemoryStream())
            {
                HttpContext.Request.Body.CopyTo(ms);
                return ms.ToArray();
            }
            
        }

        /// <inheritdoc />
        public IEnumerable<string> GetKeys(string part = null)
        {
            var request = HttpContext.Request;
            var result = new List<string>();
            if(NullEq(part,"QueryString"))
            {
                result.AddRange(request.Query.Keys);
                
                
            }
            if(NullEq(part, "Form"))
            {
                if (request.HasFormContentType && Eq("POST", request.Method))
                {
                    result.AddRange(request.Form.Keys);
                }
            }

            return result.Distinct();
        }

        /// <inheritdoc />
        public string GetValue(string key, string part = null)
        {
            var request = HttpContext.Request;
            if (NullEq(part, "QueryString"))
            {
                if (request.Query.ContainsKey(key))
                {
                    return request.Query[key];
                }
            }

            if (NullEq(part, "Form"))
            {
                if (request.HasFormContentType && Eq("POST", request.Method))
                {
                    if (request.Form.ContainsKey(key))
                    {
                        return request.Form[key];
                    }
                }
                
            }

            return null;
        }


        private bool NullEq(string val,string compare)
        {
            return string.IsNullOrEmpty(val) || string.Equals(val, compare, StringComparison.OrdinalIgnoreCase);
        }
        private bool Eq(string str1, string str2)
        {
            return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
        }
    }
}
