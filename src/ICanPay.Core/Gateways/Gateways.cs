using System.Collections.Generic;
using System.Linq;

namespace ICanPay.Core
{
    /// <summary>
    /// 网关集合类
    /// </summary>
    public class Gateways : IGateways
    {
        #region 私有字段

        private readonly ICollection<GatewayBase> list;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Gateways()
        {
            list = new List<GatewayBase>();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 添加网关
        /// </summary>
        /// <param name="gateway">网关</param>
        /// <returns></returns>
        public bool Add(GatewayBase gateway)
        {
            if (gateway != null)
            {
                list.Add(gateway);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 通过网关类型获取网关
        /// </summary>
        /// <param name="gatewayType">网关类型</param>
        /// <returns></returns>
        public GatewayBase Get(GatewayType gatewayType)
        {
            return list.FirstOrDefault(a => a.GatewayType == gatewayType);
        }

        /// <summary>
        /// 通过网关类型,交易类型获取网关
        /// </summary>
        /// <param name="gatewayType">网关类型</param>
        /// <param name="gatewayTradeType">网关交易类型</param>
        /// <returns></returns>
        public GatewayBase Get(GatewayType gatewayType,GatewayTradeType gatewayTradeType)
        {
            var gatewayBase = list.FirstOrDefault(a => a.GatewayType == gatewayType);
            gatewayBase.GatewayTradeType = gatewayTradeType;

            return gatewayBase;
        }

        /// <summary>
        /// 获取网关列表
        /// </summary>
        /// <returns></returns>
        public ICollection<GatewayBase> GetList()
        {
            return list;
        }

        #endregion
    }
}
