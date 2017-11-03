using System.Collections.Generic;

namespace ICanPay.Core
{
    public interface IGateways
    {
        /// <summary>
        /// 添加网关
        /// </summary>
        /// <param name="gateway">网关</param>
        /// <returns></returns>
        bool Add(GatewayBase gateway);

        /// <summary>
        /// 获取指定网关
        /// </summary>
        /// <typeparam name="T">网关类型</typeparam>
        /// <returns></returns>
        GatewayBase Get<T>();

        /// <summary>
        /// 通过交易类型获取网关
        /// </summary>
        /// <typeparam name="T">网关类型</typeparam>
        /// <param name="gatewayTradeType">网关交易类型</param>
        /// <returns></returns>
        GatewayBase Get<T>(GatewayTradeType gatewayTradeType);

        /// <summary>
        /// 获取网关列表
        /// </summary>
        /// <returns></returns>
        ICollection<GatewayBase> GetList();
    }
}