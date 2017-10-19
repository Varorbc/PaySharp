using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace ICanPay.Core
{
    /// <summary>
    /// 支付网关数据
    /// </summary>
    public class GatewayData
    {
        #region 属性

        public SortedDictionary<string, object> Values { get; set; } = new SortedDictionary<string, object>();

        #endregion

        #region 方法

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key">参数名</param>
        /// <param name="value">参数值</param>
        public void Add(string key, object value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key", "参数名不能为空");
            }

            if (value is null || string.IsNullOrEmpty(value.ToString()))
            {
                throw new ArgumentNullException("value", "参数值不能为空");
            }

            if (Exists(key))
            {
                Values[key] = value;
            }
            else
            {
                Values.Add(key, value);
            }
        }

        /// <summary>
        /// 根据参数名获取参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns>参数值</returns>
        public object GetValue(string key)
        {
            Values.TryGetValue(key, out object value);
            return value;
        }

        /// <summary>
        /// 根据参数名获取参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns>参数值</returns>
        public string GetStringValue(string key)
        {
            return GetValue(key)?.ToString();
        }

        /// <summary>
        /// 根据参数名获取参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns>参数值</returns>
        public double GetDoubleValue(string key)
        {
            double.TryParse(GetStringValue(key), out double value);
            return value;
        }

        /// <summary>
        /// 根据参数名获取参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns>参数值</returns>
        public int GetIntValue(string key)
        {
            int.TryParse(GetStringValue(key), out int value);
            return value;
        }

        /// <summary>
        /// 根据参数名获取参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns>参数值</returns>
        public DateTime GetDateTimeValue(string key)
        {
            DateTime.TryParse(GetStringValue(key), out DateTime value);
            return value;
        }

        /// <summary>
        /// 根据参数名获取参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns>参数值</returns>
        public float GetFloatValue(string key)
        {
            float.TryParse(GetStringValue(key), out float value);
            return value;
        }

        /// <summary>
        /// 根据参数名获取参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns>参数值</returns>
        public decimal GetDecimalValue(string key)
        {
            decimal.TryParse(GetStringValue(key), out decimal value);
            return value;
        }

        /// <summary>
        /// 根据参数名获取参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns>参数值</returns>
        public byte GetByteValue(string key)
        {
            byte.TryParse(GetStringValue(key), out byte value);
            return value;
        }

        /// <summary>
        /// 根据参数名获取参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns>参数值</returns>
        public char GetCharValue(string key)
        {
            char.TryParse(GetStringValue(key), out char value);
            return value;
        }

        /// <summary>
        /// 根据参数名获取参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns>参数值</returns>
        public bool GetBoolValue(string key)
        {
            bool.TryParse(GetStringValue(key), out bool value);
            return value;
        }

        /// <summary>
        /// 是否存在指定参数名
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns></returns>
        public bool Exists(string key) => Values.ContainsKey(key);

        /// <summary>
        /// 将网关数据转成Xml格式数据
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            if (Values.Count == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            sb.Append("<xml>");
            foreach (var item in Values)
            {
                if (item.Value.GetType() == typeof(double))
                {
                    sb.AppendFormat("<{0}>{1}</{0}>", item.Key, item.Value);
                }
                else if (item.Value.GetType() == typeof(string))
                {
                    sb.AppendFormat("<{0}><![CDATA[{1}]]></{0}>", item.Key, item.Value);
                }
                else
                {
                    throw new Exception("GatewayData字段数据类型错误");
                }
            }
            sb.Append("</xml>");

            return sb.ToString();
        }

        /// <summary>
        /// 将Xml格式数据转换为网关数据
        /// </summary>
        /// <param name="xml">Xml数据</param>
        /// <returns></returns>
        public void FromXml(string xml)
        {
            Clear();
            if (!string.IsNullOrEmpty(xml))
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                var xmlNode = xmlDoc.FirstChild;
                var nodes = xmlNode.ChildNodes;
                foreach (var item in nodes)
                {
                    var xe = (XmlElement)item;
                    Add(xe.Name, xe.InnerText);
                }
            }
        }

        /// <summary>
        /// 将网关数据转换为Url格式数据
        /// </summary>
        /// <param name="key">不需要转换的key</param>
        /// <returns></returns>
        public string ToUrl(params string[] key)
        {
            var sb = new StringBuilder();
            foreach (var item in Values)
            {
                if (!key.Contains(item.Key))
                {
                    sb.AppendFormat("{0}={1}&", item.Key, item.Value);
                }
            }

            return sb.ToString().TrimEnd('&');
        }

        /// <summary>
        /// 将网关数据转换为Url编码格式数据
        /// </summary>
        /// <param name="key">不需要转换的key</param>
        /// <returns></returns>
        public string ToUrlEncode(params string[] key)
        {
            var sb = new StringBuilder();
            foreach (var item in Values)
            {
                if (!key.Contains(item.Key))
                {
                    sb.AppendFormat("{0}={1}&", item.Key, WebUtility.UrlEncode(item.Value.ToString()));
                }
            }

            return sb.ToString().TrimEnd('&');
        }

        /// <summary>
        /// 将Url格式数据转换为网关数据
        /// </summary>
        /// <returns></returns>
        public void FromUrl(string url)
        {
            Clear();
            if (!string.IsNullOrEmpty(url))
            {
                int index = url.IndexOf('?');

                if (index == 0)
                {
                    url = url.Substring(index + 1);
                }

                var regex = new Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", RegexOptions.Compiled);
                var mc = regex.Matches(url);

                foreach (Match item in mc)
                {
                    Add(item.Result("$2"), WebUtility.UrlDecode(item.Result("$3")));
                }
            }
        }

        /// <summary>
        /// 将表单数据转换为网关数据
        /// </summary>
        /// <returns></returns>
        public void FromForm(IFormCollection form)
        {
            try
            {
                var allKeys = form.Keys;

                foreach (var item in allKeys)
                {
                    Add(item, WebUtility.UrlDecode(form[item]));
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 将网关数据转换为表单数据
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public string ToForm(string url)
        {
            var html = new StringBuilder();
            html.AppendLine("<body>");
            html.AppendLine("<form name='Gateway' method='post' action ='" + url + "'>");
            foreach (var item in Values)
            {
                html.AppendLine($"<input type='hidden' name='{item.Key}' value='{item.Value}'>");
            }
            html.AppendLine("</form>");
            html.AppendLine("<script language='javascript' type='text/javascript'>");
            html.AppendLine("document.Gateway.submit();");
            html.AppendLine("</script>");
            html.AppendLine("</body>");

            return html.ToString();
        }

        /// <summary>
        /// 将网关数据转成Json格式数据
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(Values);
        }

        /// <summary>
        /// 清空网关数据
        /// </summary>
        public void Clear()
        {
            Values.Clear();
        }

        #endregion
    }
}