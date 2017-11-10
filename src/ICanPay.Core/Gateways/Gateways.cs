using System;
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

        private readonly ICollection<GatewayBase> _list;

        #endregion

        #region 属性

        /// <summary>
        /// 网关数量
        /// </summary>
        public int Count => _list.Count;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Gateways()
        {
            _list = new List<GatewayBase>();
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
                _list.Add(gateway);
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
            var gatewayList = _list
                .Where(a => a is T)
                .ToList();

            return gatewayList.Count > 0 ? gatewayList[0] : throw new Exception("找不到指定网关");
        }

        /// <summary>
        /// 通过交易类型获取网关
        /// </summary>
        /// <typeparam name="T">网关类型</typeparam>
        /// <param name="gatewayTradeType">网关交易类型</param>
        /// <returns></returns>
        public GatewayBase Get<T>(GatewayTradeType gatewayTradeType)
        {
            var gatewayList = _list
                .Where(a => a is T && a.GatewayTradeType == gatewayTradeType)
                .ToList();

            var gateway = gatewayList.Count > 0 ? gatewayList[0] : Get<T>();
            gateway.GatewayTradeType = gatewayTradeType;

            return gateway;
        }

        /// <summary>
        /// 获取网关列表
        /// </summary>
        /// <returns></returns>
        public ICollection<GatewayBase> GetList()
        {
            return _list;
        }

        #endregion
    }
}
