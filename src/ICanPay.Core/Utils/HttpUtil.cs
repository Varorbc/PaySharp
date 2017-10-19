using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net;

namespace ICanPay
{
    /// <summary>
    /// Http工具类
    /// </summary>
    public class HttpUtil
    {
        #region 属性

        private static IHttpContextAccessor HttpContextAccessor;

        /// <summary>
        /// 当前上下文
        /// </summary>
        public static HttpContext Current => HttpContextAccessor.HttpContext;

        /// <summary>
        /// 本地IP
        /// </summary>
        public static IPAddress LocalIpAddress => Current.Connection.LocalIpAddress;

        /// <summary>
        /// 客户端IP
        /// </summary>
        public static IPAddress RemoteIpAddress => Current.Connection.RemoteIpAddress;

        /// <summary>
        /// 用户代理
        /// </summary>
        public static string UserAgent => Current.Request.Headers["UserAgent"];

        /// <summary>
        /// 请求类型
        /// </summary>
        public static string RequestType => Current.Request.Headers["RequestType"];

        /// <summary>
        /// 内容类型
        /// </summary>
        public static string ContentType => Current.Request.ContentType;

        /// <summary>
        /// 参数
        /// </summary>
        public static string QueryString => Current.Request.QueryString.ToString();

        /// <summary>
        /// 表单
        /// </summary>
        public static IFormCollection Form => Current.Request.Form;

        /// <summary>
        /// 请求体
        /// </summary>
        public static Stream Body => Current.Request.Body;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        internal static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 跳转到指定链接
        /// </summary>
        /// <param name="url">链接</param>
        public static void Redirect(string url)
        {
            Current.Response.Redirect(url);
        }

        /// <summary>
        /// 输出内容
        /// </summary>
        /// <param name="text">内容</param>
        public static void Write(string text)
        {
            Current.Response.WriteAsync(text).GetAwaiter().GetResult();
        }

        #endregion
    }
}
