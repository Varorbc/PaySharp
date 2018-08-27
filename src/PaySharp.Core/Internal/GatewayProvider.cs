//using PaySharp.Abstractions;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace PaySharp.Internal
//{
//    /// <inheritdoc />
//    public class GatewayProvider : IGatewayProvider
//    {
//        private readonly IDictionary<Type, IDictionary<string, object>> _store;

//        public GatewayProvider(IDictionary<Type,IDictionary<string,object>> store)
//        {
//            _store = store ?? throw new ArgumentNullException(nameof(store));
//        }

//        /// <inheritdoc />
//        public T GetGateway<T>()  where T:class
//        {
//            return GetGateway<T>(string.Empty);
//        }

//        /// <inheritdoc />
//        public T GetGateway<T>(string gatewayName) where T:class
//        {
//            gatewayName = gatewayName ?? throw new ArgumentNullException(nameof(gatewayName), "Gateway name must not be null");
//            if (_store.TryGetValue(typeof(T), out var innerStore))
//            {
//                if (innerStore.TryGetValue(gatewayName, out var gateway))
//                {
//                    if(gateway is T)
//                    {
//                        return (T)gateway;
//                    }
//                }
//            }
//            return null;
//        }
//    }
//}
