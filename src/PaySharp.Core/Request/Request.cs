using PaySharp.Core.Response;
using PaySharp.Core.Utils;
using System.Collections.Generic;

namespace PaySharp.Core.Request
{
    public abstract class Request<TModel, TResponse> where TResponse : IResponse
    {
        protected Request()
        {
            GatewayData = new GatewayData();
        }

        protected Request(IComparer<string> comparer)
        {
            GatewayData = new GatewayData(comparer);
        }

        /// <summary>
        /// 请求地址
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        /// 异步通知地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 同步通知地址
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 网关数据
        /// </summary>
        /// <returns></returns>
        public GatewayData GatewayData { get; }

        /// <summary>
        /// 模型
        /// </summary>
        /// <returns></returns>
        public TModel Model { get; private set; }

        /// <summary>
        /// 添加网关数据
        /// </summary>
        /// <param name="model">模型</param>
        public virtual void AddGatewayData(TModel model)
        {
            Model = model;
            ValidateUtil.Validate(model, null);
        }
    }
}
