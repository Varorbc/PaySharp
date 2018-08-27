using System;
using System.Collections.Generic;
using System.Text;

namespace PaySharp.Abstractions
{
    /// <summary>
    /// 网关提供器的构造器
    /// </summary>
    public interface IPaySharpBuilder
    {
        /// <summary>
        /// 添加一个命名的网关
        /// </summary>
        /// <typeparam name="T">网关的类型</typeparam>
        /// <param name="name">网关的名字</param>
        /// <param name="service">网关</param>
        /// <returns></returns>
        void TryAddService<T>(T service) where T : class;
        void TryAddService<T, TImplementation>() where T:class where TImplementation :class, T;
        void AddOption<T>(T option) where T : class, IPaySharpOption;

    }
}
