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
        /// 通过网关类型获取网关
        /// </summary>
        /// <param name="gatewayType">网关类型</param>
        /// <returns></returns>
        GatewayBase Get(GatewayType gatewayType);

        /// <summary>
        /// 通过网关类型,交易类型获取网关
        /// </summary>
        /// <param name="gatewayType">网关类型</param>
        /// <param name="gatewayTradeType">网关交易类型</param>
        /// <returns></returns>
        GatewayBase Get(GatewayType gatewayType, GatewayTradeType gatewayTradeType);

        /// <summary>
        /// 获取网关列表
        /// </summary>
        /// <returns></returns>
        ICollection<GatewayBase> GetList();
    }
}