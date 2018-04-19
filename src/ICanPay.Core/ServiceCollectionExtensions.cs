#if NETSTANDARD2_0
using ICanPay.Core;
using ICanPay.Core.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加ICanPay
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setupAction"></param>
        public static void AddICanPay(this IServiceCollection services, Action<IGateways> setupAction)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var gateways = new Gateways();
            setupAction(gateways);
            services.AddSingleton(gateways);
        }

        /// <summary>
        /// 使用ICanPay
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseICanPay(this IApplicationBuilder app)
        {
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            HttpUtil.Configure(httpContextAccessor);

            return app;
        }
    }
}

#endif