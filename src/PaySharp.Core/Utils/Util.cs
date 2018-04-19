using Newtonsoft.Json;
using System;

namespace PaySharp.Core.Utils
{
    /// <summary>
    /// 工具类
    /// </summary>
    public static class Util
    {
        #region 方法

        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <returns></returns>
        public static string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 将时间转换为时间戳
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        public static int ToTimeStamp(this DateTime time)
        {
            return (int)(time.ToUniversalTime().Ticks / 10000000 - 62135596800);
        }

        #endregion
    }
}
