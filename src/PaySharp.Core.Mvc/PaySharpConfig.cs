using System;
//using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
//using Autofac.Integration.WebApi;

namespace PaySharp.Core.Mvc
{
    public static class PaySharpConfig
    {
        /// <summary>
        /// 注册PaySharp
        /// </summary>
        /// <param name="type"></param>
        /// <param name="containerBuilder"></param>
        /// <param name="func"></param>
        public static void Register(Type type, ContainerBuilder containerBuilder, Func<IComponentContext, IGateways> func)
        {
            containerBuilder.Register(func).InstancePerRequest();
            containerBuilder.RegisterControllers(type.Assembly);

            var container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        ///// <summary>
        ///// 注册PaySharp-适用于WebApi
        ///// </summary>
        ///// <param name="type"></param>
        ///// <param name="containerBuilder"></param>
        ///// <param name="config"></param>
        ///// <param name="func"></param>
        //public static void Register(Type type, ContainerBuilder containerBuilder, HttpConfiguration config, Func<IComponentContext, IGateways> func)
        //{
        //    containerBuilder.Register(func).InstancePerRequest();
        //    containerBuilder.RegisterApiControllers(type.Assembly);

        //    var container = containerBuilder.Build();
        //    config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        //}
    }
}
