using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using PaySharp.Abstractions;

namespace PaySharp.Internal
{
    /// <inheritdoc />
    public class GatewayBuilder : IGatewayBuilder
    {
        private readonly IDictionary<Type, IDictionary<string, object>> _store = new Dictionary<Type, IDictionary<string, object>>();

        /// <inheritdoc />
        public bool TryAdd<T>(string name, T gateway) where T : class
        {
            try
            {
                var t = typeof(T);
                if (_store.ContainsKey(t))
                {
                    var innerStore = _store[t];
                    innerStore[name] = gateway;
                    return true;
                }
                else
                {
                    var innerStore = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                    {
                        [name] = gateway
                    };
                    _store.Add(t, innerStore);
                    return true;
                }
            }
            catch
            {
                return false;
            }


        }

        /// <inheritdoc />
        public IGatewayProvider Build()
        {
            return new GatewayProvider(_store);
        }


        private class GatewayStore
        {
            public string Name { get; set; }
            public object Gateway { get; set; }
        }
    }
}
