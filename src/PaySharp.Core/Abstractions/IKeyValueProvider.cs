using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Abstractions
{
    /// <summary>
    /// 键值提供器，用于从 HttpContext.Request 中提取数据。
    /// </summary>
    /// <remarks>因为 HttpContext 在不同的框架中类不同，所以该接口用于协调这些专用类</remarks>
    public interface IKeyValueProvider
    {
        /// <summary>
        /// 获取 HttpContext.Request.Body 数据
        /// </summary>
        /// <returns>Body的所有的字节</returns>
        byte[] Get();

        /// <summary>
        /// 获取所有的键
        /// </summary>
        /// <param name="part">该值指示从哪个部分中提取 比如：QueryString 或 Form ，
        /// 注意：该值为null时从所有的部分获取，而且应该忽略大小写 </param>
        /// <returns></returns>
        IEnumerable<string> GetKeys(string part = null);

        /// <summary>
        /// 通过提供键，获取值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="part">该值指示从哪个部分中提取 比如：QueryString 或 Form ，
        /// 注意：该值为null时从所有的部分获取，而且应该忽略大小写</param>
        /// <returns></returns>
        string GetValue(string key, string part = null);

        IEnumerable<string> SupportedParts { get; }
    }
}
