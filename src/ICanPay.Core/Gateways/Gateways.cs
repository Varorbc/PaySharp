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
        /// 获取指定网关
        /// </summary>
        /// <typeparam name="T">网关类型</typeparam>
        /// <returns></returns>
        public GatewayBase Get<T>()
        {
            var gatewayBase = list.FirstOrDefault(a => a is T);

            return gatewayBase;
        }

        /// <summary>
        /// 通过交易类型获取网关
        /// </summary>
        /// <typeparam name="T">网关类型</typeparam>
        /// <param name="gatewayTradeType">网关交易类型</param>
        /// <returns></returns>
        public GatewayBase Get<T>(GatewayTradeType gatewayTradeType)
        {
            var gatewayBase = Get<T>();
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
