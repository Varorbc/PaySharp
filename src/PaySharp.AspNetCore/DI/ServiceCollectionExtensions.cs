using PaySharp.AspNetCore.DI;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using PaySharp.Abstractions;
using System.ComponentModel;
using PaySharp.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]//先不要让其他人访问
        public static IServiceCollection AddICanPay(this IServiceCollection services)
        {
            services = services ?? throw new ArgumentNullException(nameof(services));
            services.AddICanPay(null);
            return services;
        }

        public static IServiceCollection AddICanPay(this IServiceCollection services,Action<IGatewayBuilder> buildAction)
        {
            services.TryAddSingleton<IGatewayBuilder, GatewayBuilder>();
            services.TryAddScoped<IKeyValueProvider, HttpContextKeyValueProvider>();
            services.TryAddScoped(svcs =>
            {
                var builder = svcs.GetRequiredService<IGatewayBuilder>();
                if (builder != null)
                {
                    buildAction(builder);
                }
                return builder.Build();
            });

            return services;
        }
    }
}
