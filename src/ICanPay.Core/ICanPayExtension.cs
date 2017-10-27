using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ICanPay.Core
{
    public static class ICanPayExtension
    {
        public static void AddICanPay(this IServiceCollection services, Func<IServiceProvider, IGateways> func)
        {
            AddStaticHttpContext(services);

            services.AddTransient(func);
        }

        public static IApplicationBuilder UseICanPay(this IApplicationBuilder app)
        {
            UseStaticHttpContext(app);

            return app;
        }

        private static void AddStaticHttpContext(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        private static IApplicationBuilder UseStaticHttpContext(this IApplicationBuilder app)
        {
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            HttpUtil.Configure(httpContextAccessor);
            return app;
        }
    }
}
