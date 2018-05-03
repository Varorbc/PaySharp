using PaySharp.Internal;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using PaySharp.Abstractions;
using System.ComponentModel;
using PaySharp.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// PaySharp 对 <see cref="IServiceCollection"/> 的扩展方法
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]//先不要让其他人访问
        public static IServiceCollection AddPaySharp(this IServiceCollection services)
        {
            services = services ?? throw new ArgumentNullException(nameof(services));
            AddPaySharp(services, null);
            return services;
        }

        /// <summary>
        /// 添加PaySharp相关服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="buildAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddPaySharp(this IServiceCollection services,Action<IGatewayBuilder> buildAction)
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
