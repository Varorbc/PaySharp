using System;
using System.Collections.Generic;
using System.Text;

namespace PaySharp.Abstractions
{
    /// <summary>
    /// 网关提供器的构造器
    /// </summary>
    public interface IGatewayBuilder
    {
        /// <summary>
        /// 添加一个命名的网关
        /// </summary>
        /// <typeparam name="T">网关的类型</typeparam>
        /// <param name="name">网关的名字</param>
        /// <param name="gateway">网关</param>
        /// <returns></returns>
        bool TryAdd<T>(string name,T gateway) where T:class;

        /// <summary>
        /// 返回一个 <see cref="IGatewayProvider"/> 的实例
        /// </summary>
        /// <returns></returns>
        IGatewayProvider Build();
    }
}
