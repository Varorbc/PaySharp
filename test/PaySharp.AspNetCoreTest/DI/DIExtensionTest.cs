using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PaySharp.Abstractions;
using PaySharp.Internal;
using System;
using System.Collections.Generic;
using Xunit;

namespace PaySharp.AspNetCoreTest
{
    public class DIExtensionTest
    {
        [Fact]
        public void ConfigDI_Repeate_Test()
        {
            var service = new ServiceCollection();
            service.TryAddScoped<IGatewayBuilder, TestGatewayBuilder>();
            service.AddPaySharp(builder =>
            {
                builder.TryAdd("A", new XGateway());
            });

            var provider = service.BuildServiceProvider();

            try
            {
                var gateway1 = GetGateway(provider);
            }
            catch(Exception e)
            {
                throw new Exception("第一次获取就出错了", e);
            }


            try
            {
                var gateway2 = GetGateway(provider);
            }
            catch(Exception e)
            {
                throw new Exception("第二次获取出错了", e);
            }
        }

        private XGateway GetGateway(IServiceProvider servicProvider)
        {
            using (var provider = servicProvider.CreateScope())
            {
                var gateWays = provider.ServiceProvider.GetRequiredService<IGatewayProvider>();
                return gateWays.GetGateway<XGateway>("A");
            }
        }

        private class XGateway
        {
            public Guid Id { get; } = Guid.NewGuid();
        }


        private class TestGatewayBuilder : IGatewayBuilder
        {
            private readonly IDictionary<Type, IDictionary<string, object>> _store = new Dictionary<Type, IDictionary<string, object>>();

            /// <inheritdoc />
            public bool TryAdd<T>(string name, T gateway) where T : class
            {
                var t = typeof(T);
                if (_store.ContainsKey(t))
                {
                    var innerStore = _store[t];
                    innerStore.Add(name, gateway);
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
}
