using PaySharp.Core.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace PaySharp.Core
{
    /// <summary>
    /// 网关集合类
    /// </summary>
    public class Gateways : IGateways
    {
        #region 私有字段

        private readonly ICollection<BaseGateway> _list;

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
            _list = new List<BaseGateway>();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 添加网关
        /// </summary>
        /// <param name="gateway">网关</param>
        /// <returns></returns>
        public bool Add(BaseGateway gateway)
        {
            if (gateway != null)
            {
                if (!Exist(gateway.Merchant.AppId))
                {
                    _list.Add(gateway);

                    return true;
                }
                else
                {
                    throw new GatewayException("该商户数据已存在");
                }
            }

            return false;
        }

        /// <summary>
        /// 获取指定网关
        /// </summary>
        /// <typeparam name="T">网关类型</typeparam>
        /// <returns></returns>
        public BaseGateway Get<T>()
        {
            var gatewayList = _list
                .Where(a => a is T)
                .ToList();

            return gatewayList.Count > 0 ? gatewayList[0] : throw new GatewayException("找不到指定网关");
        }

        /// <summary>
        /// 通过AppId获取网关
        /// </summary>
        /// <typeparam name="T">网关类型</typeparam>
        /// <param name="appId">AppId</param>
        /// <returns></returns>
        public BaseGateway Get<T>(string appId)
        {
            var gatewayList = _list
                .Where(a => a is T && a.Merchant.AppId == appId)
                .ToList();

            var gateway = gatewayList.Count > 0 ? gatewayList[0] : throw new GatewayException("找不到指定网关");

            return gateway;
        }

        /// <summary>
        /// 指定AppId是否存在
        /// </summary>
        /// <param name="appId">appId</param>
        /// <returns></returns>
        private bool Exist(string appId) => _list.Any(a => a.Merchant.AppId == appId);

        /// <summary>
        /// 获取网关列表
        /// </summary>
        /// <returns></returns>
        public ICollection<BaseGateway> GetList()
        {
            return _list;
        }

        #endregion
    }
}
