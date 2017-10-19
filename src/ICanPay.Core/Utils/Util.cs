using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ICanPay.Core
{
    /// <summary>
    /// 支付的相关操作
    /// </summary>
    public static class Util
    {

        #region 方法

        /// <summary>
        /// 获得字符串的MD5值，MD5值为大写
        /// </summary>
        /// <param name="text">字符串</param>
        public static string GetMD5(string text)
        {
            return GetMD5(text, Encoding.UTF8);
        }

        /// <summary>
        /// 获得字符串的MD5值，MD5值为大写
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="textEncoding">字符串编码</param>
        /// <returns></returns>
        public static string GetMD5(string text, Encoding textEncoding)
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(textEncoding.GetBytes(text));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("X2"));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// 读取网页，返回网页内容
        /// </summary>
        /// <param name="pageUrl">网页URL</param>
        /// <returns></returns>
        public static string ReadPage(string pageUrl)
        {
            return ReadPage(pageUrl, Encoding.UTF8);
        }

        /// <summary>
        /// 异步读取网页，返回网页内容
        /// </summary>
        /// <param name="pageUrl">网页URL</param>
        /// <returns></returns>
        public static async Task<string> ReadPageAsync(string pageUrl)
        {
            return await ReadPageAsync(pageUrl, Encoding.UTF8);
        }

        /// <summary>
        /// 读取网页，返回网页内容
        /// </summary>
        /// <param name="pageUrl">网页URL</param>
        /// <param name="pageEncoding">网页编码</param>
        /// <returns></returns>
        public static string ReadPage(string pageUrl, Encoding pageEncoding)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pageUrl);
            request.Method = "GET";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), pageEncoding))
                    {
                        if (reader != null)
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                request.Abort();
            }

            return string.Empty;
        }

        /// <summary>
        /// 读取网页，返回网页内容
        /// </summary>
        /// <param name="pageUrl">网页URL</param>
        /// <param name="pageEncoding">网页编码</param>
        /// <returns></returns>
        public static async Task<string> ReadPageAsync(string pageUrl, Encoding pageEncoding)
        {
            return await Task.Run(() => ReadPage(pageUrl, pageEncoding));
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">链接</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static string Post(string url, string data)
        {
            byte[] dataByte = Encoding.UTF8.GetBytes(data);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = dataByte.Length;

            try
            {
                using (Stream outStream = request.GetRequestStream())
                {
                    outStream.Write(dataByte, 0, dataByte.Length);
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        if (reader != null)
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                request.Abort();
            }

            return string.Empty;
        }

        /// <summary>
        /// 异步Post请求
        /// </summary>
        /// <param name="url">链接</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static async Task<string> PostAsync(string url, string data)
        {
            return await Task.Run(() => Post(url, data));
        }

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
        /// 通过网关类型获取网关
        /// </summary>
        public static GatewayBase GetGateway(this ICollection<GatewayBase> gatewayList, GatewayType gatewayType)
        {
            return gatewayList.FirstOrDefault(a => a.GatewayType == gatewayType);
        }

        #endregion

    }
}
