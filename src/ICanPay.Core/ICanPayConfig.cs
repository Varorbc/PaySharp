#if NETSTANDARD2_0
using ICanPay.Core.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
#else
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Web.Mvc;
using System.Web.Http;
#endif
using System;

namespace ICanPay.Core
{
    public static class ICanPayConfig
    {
#if NETSTANDARD2_0

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

#else

        /// <summary>
        /// 注册ICanPay-适用于Mvc
        /// </summary>
        /// <param name="type"></param>
        /// <param name="func"></param>
        public static void Register(Type type, Func<IComponentContext, IGateways> func)
        {
            var builder = new ContainerBuilder();
            builder.Register(func).InstancePerRequest();
            builder.RegisterControllers(type.Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        /// <summary>
        /// 注册ICanPay-适用于WebApi
        /// </summary>
        /// <param name="type"></param>
        /// <param name="config"></param>
        /// <param name="func"></param>
        public static void Register(Type type, HttpConfiguration config, Func<IComponentContext, IGateways> func)
        {
            var builder = new ContainerBuilder();
            builder.Register(func).InstancePerRequest();
            builder.RegisterApiControllers(type.Assembly);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

#endif

    }
}
