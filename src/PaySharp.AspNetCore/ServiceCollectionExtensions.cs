using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using PaySharp.Abstractions;
using System.ComponentModel;
using PaySharp.AspNetCore;
using PaySharp.AspNetCore.Internal;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// PaySharp 对 <see cref="IServiceCollection"/> 的扩展方法
    /// </summary>
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// 添加PaySharp相关服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="buildAction"></param>
        /// <returns></returns>
        public static IPaySharpBuilder AddPaySharp(this IServiceCollection services)
        {
            services.TryAddScoped<IPaySharpProvider, PaySharpProvider>();
            services.TryAddScoped<IKeyValueProvider, HttpContextKeyValueProvider>();
            

            return new PaySharpBuilder(services);
        }
    }
}
