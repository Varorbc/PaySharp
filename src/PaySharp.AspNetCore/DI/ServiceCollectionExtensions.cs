using PaySharp.AspNetCore.DI;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddICanPay(this IServiceCollection services)
        {
            services = services ?? throw new ArgumentNullException(nameof(services));
            services.AddICanPay(null);
            return services;
        }

        public static IServiceCollection AddICanPay(this IServiceCollection services,Action<IGatewayBuilder> buildAction)
        {
            services.TryAddSingleton<IGatewayBuilder, GatewayBuilder>();
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
