#if NETSTANDARD2_0
using Microsoft.AspNetCore.Http;
#else
using System.Collections.Specialized;
using System.Web;
#endif
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ICanPay.Core.Utils
{
    /// <summary>
    /// Http工具类
    /// </summary>
    public static class HttpUtil
    {
        #region 属性

#if NETSTANDARD2_0

        private static IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 当前上下文
        /// </summary>
        public static HttpContext Current => _httpContextAccessor.HttpContext;

        /// <summary>
        /// 本地IP
        /// </summary>
        public static string LocalIpAddress
        {
            get
            {
#if DEBUG
                return "127.0.0.1";
#else
                return Current.Connection.LocalIpAddress.ToString();
#endif
            }
        }

        /// <summary>
        /// 客户端IP
        /// </summary>
        public static string RemoteIpAddress
        {
            get
            {
#if DEBUG
                return "127.0.0.1";
#else
                return Current.Connection.RemoteIpAddress.ToString();
#endif
            }
        }

        /// <summary>
        /// 请求类型
        /// </summary>
        public static string RequestType => Current.Request.Method;

        /// <summary>
        /// 表单
        /// </summary>
        public static IFormCollection Form => Current.Request.Form;

        /// <summary>
        /// 请求体
        /// </summary>
        public static Stream Body => Current.Request.Body;

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        internal static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

#else

        public static HttpContext Current => HttpContext.Current;

        /// <summary>
        /// 本地IP
        /// </summary>
        public static string LocalIpAddress
        {
            get
            {
#if DEBUG
                return "127.0.0.1";
#else
                return  Current.Request.UserHostAddress;
#endif
            }
        }

        /// <summary>
        /// 客户端IP
        /// </summary>
        public static string RemoteIpAddress
        {
            get
            {
#if DEBUG
                return "127.0.0.1";
#else
                return  Current.Request.ServerVariables ["REMOTE_ADDR"];
#endif
            }
        }

        /// <summary>
        /// 请求类型
        /// </summary>
        public static string RequestType => Current.Request.HttpMethod;

        /// <summary>
        /// 表单
        /// </summary>
        public static NameValueCollection Form => Current.Request.Form;

        /// <summary>
        /// 请求体
        /// </summary>
        public static Stream Body => Current.Request.InputStream;

#endif

        /// <summary>
        /// 用户代理
        /// </summary>
        public static string UserAgent => Current.Request.Headers["User-Agent"];

        /// <summary>
        /// 内容类型
        /// </summary>
        public static string ContentType => Current.Request.ContentType;

        /// <summary>
        /// 参数
        /// </summary>
        public static string QueryString => Current.Request.QueryString.ToString();

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
            Current.Response.ContentType = "text/html;charset=utf-8";

#if NETSTANDARD2_0
            AsyncUtil.Run(async () =>
            {
                await Current.Response.WriteAsync(text);
            });
#else
            Current.Response.Write(text);
#endif

        }

        /// <summary>
        /// 输出文件
        /// </summary>
        /// <param name="stream">文件流</param>
        public static void Write(FileStream stream)
        {
            long size = stream.Length;
            byte[] buffer = new byte[size];
            stream.Read(buffer, 0, (int)size);
            stream.Dispose();
            File.Delete(stream.Name);

            Current.Response.ContentType = "application/octet-stream";
            Current.Response.Headers.Add("Content-Disposition", "attachment;filename=" + WebUtility.UrlEncode(Path.GetFileName(stream.Name)));
            Current.Response.Headers.Add("Content-Length", size.ToString());

#if NETSTANDARD2_0
            AsyncUtil.Run(async () =>
            {
                await Current.Response.Body.WriteAsync(buffer, 0, (int)size);
            });
            Current.Response.Body.Close();
#else
            Current.Response.BinaryWrite(buffer);
            Current.Response.End();
            Current.Response.Close();
#endif
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">url</param>
        /// <returns></returns>
        public static string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd().Trim();
                }
            }
        }

        /// <summary>
        /// 异步Post请求
        /// </summary>
        /// <param name="url">url</param>
        /// <returns></returns>
        public static async Task<string> GetAsync(string url)
        {
            return await Task.Run(() => Get(url));
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="data">数据</param>
        /// <param name="cert">证书</param>
        /// <returns></returns>
        public static string Post(string url, string data, X509Certificate2 cert = null)
        {
            byte[] dataByte = Encoding.UTF8.GetBytes(data);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            request.ContentLength = dataByte.Length;

            if (cert != null)
            {
                request.ClientCertificates.Add(cert);
            }

            using (Stream outStream = request.GetRequestStream())
            {
                outStream.Write(dataByte, 0, dataByte.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd().Trim();
                }
            }
        }

        /// <summary>
        /// 异步Post请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="data">数据</param>
        /// <param name="cert">证书</param>
        /// <returns></returns>
        public static async Task<string> PostAsync(string url, string data, X509Certificate2 cert = null)
        {
            return await Task.Run(() => Post(url, data, cert));
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="path">下载路径</param>
        /// <returns></returns>
        public static FileStream Download(string url, string path)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    FileStream fileStream = new FileStream(path, FileMode.Create);
                    byte[] buffer = new byte[1024];
                    int size = responseStream.Read(buffer, 0, buffer.Length);
                    while (size > 0)
                    {
                        fileStream.Write(buffer, 0, size);
                        size = responseStream.Read(buffer, 0, buffer.Length);
                    }

                    fileStream.Position = 0;
                    return fileStream;

                }
            }
        }

        /// <summary>
        /// 异步下载
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="path">下载路径</param>
        /// <returns></returns>
        public static async Task<FileStream> DownloadAsync(string url, string path)
        {
            return await Task.Run(() => Download(url, path));
        }

        #endregion
    }
}
