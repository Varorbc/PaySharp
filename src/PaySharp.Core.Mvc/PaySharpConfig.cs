using Autofac;
using Autofac.Integration.Mvc;
//using Autofac.Integration.WebApi;
using System.Web.Mvc;
//using System.Web.Http;
using System;

namespace PaySharp.Core
{
    public static class PaySharpConfig
    {
        /// <summary>
        /// 注册PaySharp
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
        /// 注册PaySharp-适用于WebApi
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