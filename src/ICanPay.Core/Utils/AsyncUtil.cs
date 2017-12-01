using Nito.AsyncEx;
using System;
using System.Threading.Tasks;

namespace ICanPay.Core.Utils
{
    /// <summary>
    /// 异步操作
    /// </summary>
    public static class AsyncUtil
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="action">操作</param>
        public static void Run(Action action)
        {
            AsyncContext.Run(action);
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="action">操作</param>
        public static void Run(Func<Task> action)
        {
            AsyncContext.Run(action);
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <typeparam name="TResult">返回类型</typeparam>
        /// <param name="action">操作</param>
        public static TResult Run<TResult>(Func<TResult> action)
        {
            return AsyncContext.Run(action);
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <typeparam name="TResult">返回类型</typeparam>
        /// <param name="action">操作</param>
        public static TResult Run<TResult>(Func<Task<TResult>> action)
        {
            return AsyncContext.Run(action);
        }
    }
}