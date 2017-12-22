#if NETSTANDARD2_0
using ICanPay.Core.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ICanPay.Core
{
    public static class ICanPayConfig
    {
        /// <summary>
        /// 添加ICanPay
        /// </summary>
        /// <param name="services"></param>
        /// <param name="func"></param>
        public static void AddICanPay(this IServiceCollection services, Func<IServiceProvider, IGateways> func)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient(func);
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