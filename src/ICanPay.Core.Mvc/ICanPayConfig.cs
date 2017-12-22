using Autofac;
using Autofac.Integration.Mvc;
//using Autofac.Integration.WebApi;
using System.Web.Mvc;
//using System.Web.Http;
using System;

namespace ICanPay.Core
{
    public static class ICanPayConfig
    {
        /// <summary>
        /// 注册ICanPay
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
        //public static void Register(Type type, HttpConfiguration config, Func<IComponentContext, IGateways> func)
        //{
        //    var builder = new ContainerBuilder();
        //    builder.Register(func).InstancePerRequest();
        //    builder.RegisterApiControllers(type.Assembly);

        //    var container = builder.Build();
        //    config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        //}
    }
}