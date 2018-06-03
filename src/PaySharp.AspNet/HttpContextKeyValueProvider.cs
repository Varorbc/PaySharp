using PaySharp.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PaySharp.AspNetCore
{
    /// <summary>
    /// Asp.Net 的键值提供器
    /// </summary>
    public class HttpContextKeyValueProvider : IKeyValueProvider
    {
        public HttpContextBase HttpContext { get; }

        public IEnumerable<string> SupportedParts => _supportedParts;

        private IEnumerable<string> _supportedParts = new[] { "QueryString", "Form" };

        public HttpContextKeyValueProvider(HttpContextBase httpContext)
        {
            HttpContext = HttpContext;
        }

        /// <inheritdoc />
        public byte[] Get()
        {
            using (var ms = new MemoryStream())
            {
                HttpContext.Request.GetBufferedInputStream().CopyTo(ms);
                return ms.ToArray();
            }

        }

        /// <inheritdoc />
        public IEnumerable<string> GetKeys(string part = null)
        {
            var request = HttpContext.Request;
            var result = new List<string>();
            if (NullEq(part, "QueryString"))
            {
                result.AddRange(request.QueryString.AllKeys);
                
            }
            if (NullEq(part, "Form"))
            {
                result.AddRange(request.Form.AllKeys);
            }

            return result.Distinct();
        }

        /// <inheritdoc />
        public string GetValue(string key, string part = null)
        {
            var request = HttpContext.Request;
            if (NullEq(part, "QueryString"))
            {
                return request.QueryString[key];
            }

            if (NullEq(part, "Form"))
            {
                return request.Form[key];
            }

            return null;
        }


        private bool NullEq(string val, string compare)
        {
            return string.IsNullOrEmpty(val) || string.Equals(val, compare, StringComparison.OrdinalIgnoreCase);
        }
        private bool Eq(string str1, string str2)
        {
            return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
        }
    }
}
