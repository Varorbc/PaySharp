#if NETSTANDARD2_0
using Microsoft.AspNetCore.Http;
#endif
using PaySharp.Core.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace PaySharp.Core
{
    /// <summary>
    /// 网关数据
    /// </summary>
    public class GatewayData
    {
        #region 私有字段

        private readonly SortedDictionary<string, object> _values;

        #endregion

        #region 属性

        public object this[string key]
        {
            get => _values[key];
            set => _values[key] = value;
        }

        public SortedDictionary<string, object>.KeyCollection Keys
        {
            get => _values.Keys;
        }

        public SortedDictionary<string, object>.ValueCollection Values
        {
            get => _values.Values;
        }

        public KeyValuePair<string, object> this[int index]
        {
            get => _values.ElementAt(index);
        }

        public int Count => _values.Count;

        /// <summary>
        /// 原始值
        /// </summary>
        public string Raw { get; set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public GatewayData()
        {
            _values = new SortedDictionary<string, object>();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="comparer">排序策略</param>
        public GatewayData(IComparer<string> comparer)
        {
            _values = new SortedDictionary<string, object>(comparer);
        }

        #endregion

        #region 方法

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key">参数名</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public bool Add(string key, object value)
        {
            Raw = null;
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key", "参数名不能为空");
            }

            if (value is null || string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }

            if (Exists(key))
            {
                _values[key] = value;
            }
            else
            {
                _values.Add(key, value);
            }

            return true;
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="stringCase">字符串策略</param>
        /// <returns></returns>
        public bool Add(object obj, StringCase stringCase)
        {
            ValidateUtil.Validate(obj, null);

            Raw = null;
            var type = obj.GetType();
            var properties = type.GetProperties();
            var fields = type.GetFields();

            Add(properties);
            Add(fields);

            return true;

            void Add(MemberInfo[] info)
            {
                foreach (var item in info)
                {
                    var notAddattributes = item.GetCustomAttributes(typeof(IgnoreAttribute), true);
                    if (notAddattributes.Length > 0)
                    {
                        continue;
                    }

                    string key;
                    object value;
                    var renameAttribute = item.GetCustomAttributes(typeof(ReNameAttribute), true);
                    if (renameAttribute.Length > 0)
                    {
                        key = ((ReNameAttribute)renameAttribute[0]).Name;
                    }
                    else
                    {
                        if (stringCase is StringCase.Camel)
                        {
                            key = item.Name.ToCamelCase();
                        }
                        else if (stringCase is StringCase.Snake)
                        {
                            key = item.Name.ToSnakeCase();
                        }
                        else
                        {
                            key = item.Name;
                        }
                    }

                    switch (item.MemberType)
                    {
                        case MemberTypes.Field:
                            value = ((FieldInfo)item).GetValue(obj);
                            break;
                        case MemberTypes.Property:
                            value = ((PropertyInfo)item).GetValue(obj);
                            break;
                        default:
                            throw new NotImplementedException();
                    }

                    if (value is null || string.IsNullOrEmpty(value.ToString()))
                    {
                        continue;
                    }

                    if (Exists(key))
                    {
                        _values[key] = value;
                    }
                    else
                    {
                        _values.Add(key, value);
                    }
                }
            }
        }

        /// <summary>
        /// 根据参数名获取参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns>参数值</returns>
        public object GetValue(string key)
        {
            _values.TryGetValue(key, out object value);
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
        public bool Exists(string key) => _values.ContainsKey(key);

        /// <summary>
        /// 将网关数据转成Xml格式数据
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            if (_values.Count == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            sb.Append("<xml>");
            foreach (var item in _values)
            {
                if (item.Value is string)
                {
                    sb.AppendFormat("<{0}><![CDATA[{1}]]></{0}>", item.Key, item.Value);

                }
                else
                {
                    sb.AppendFormat("<{0}>{1}</{0}>", item.Key, item.Value);
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
            try
            {
                Clear();
                if (!string.IsNullOrEmpty(xml))
                {
                    var xmlDoc = new XmlDocument()
                    {
                        XmlResolver = null
                    };
                    xmlDoc.LoadXml(xml);
                    var xmlElement = xmlDoc.DocumentElement;
                    var nodes = xmlElement.ChildNodes;
                    foreach (var item in nodes)
                    {
                        var xe = (XmlElement)item;
                        Add(xe.Name, xe.InnerText);
                    }
                }
            }
            finally
            {
                Raw = xml;
            }
        }

        /// <summary>
        /// 将网关数据转换为Url格式数据
        /// </summary>
        /// <param name="isUrlEncode">是否需要url编码</param>
        /// <returns></returns>
        public string ToUrl(bool isUrlEncode = true)
        {
            return string.Join("&",
                _values
                .Select(a => $"{a.Key}={(isUrlEncode ? WebUtility.UrlEncode(a.Value.ToString()) : a.Value.ToString())}"));
        }

        /// <summary>
        /// 将Url格式数据转换为网关数据
        /// </summary>
        /// <param name="url">url数据</param>
        /// <param name="isUrlDecode">是否需要url解码</param>
        /// <returns></returns>
        public void FromUrl(string url, bool isUrlDecode = true)
        {
            try
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
                        string value = item.Result("$3");
                        Add(item.Result("$2"), isUrlDecode ? WebUtility.UrlDecode(value) : value);
                    }
                }
            }
            finally
            {
                Raw = url;
            }
        }

#if NETSTANDARD2_0

        /// <summary>
        /// 将表单数据转换为网关数据
        /// </summary>
        /// <param name="form">表单</param>
        /// <returns></returns>
        public void FromForm(IFormCollection form)
        {
            try
            {
                Clear();
                var allKeys = form.Keys;

                foreach (var item in allKeys)
                {
                    Add(item, form[item]);
                }
            }
            catch { }
        }
#endif

        /// <summary>
        /// 将键值对转换为网关数据
        /// </summary>
        /// <param name="nvc">键值对</param>
        /// <returns></returns>
        public void FromNameValueCollection(NameValueCollection nvc)
        {
            foreach (var item in nvc.AllKeys)
            {
                Add(item, nvc[item]);
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
            html.AppendLine($"<form name='gateway' method='post' action ='{url}'>");
            foreach (var item in _values)
            {
                html.AppendLine($"<input type='hidden' name='{item.Key}' value='{item.Value}'>");
            }
            html.AppendLine("</form>");
            html.AppendLine("<script language='javascript' type='text/javascript'>");
            html.AppendLine("document.gateway.submit();");
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
            return JsonConvert.SerializeObject(_values);
        }

        /// <summary>
        /// 将Json格式数据转成网关数据
        /// </summary>
        /// <param name="json">json数据</param>
        /// <returns></returns>
        public void FromJson(string json)
        {
            try
            {
                Clear();
                if (!string.IsNullOrEmpty(json))
                {
                    var jObject = JObject.Parse(json);
                    foreach (var item in jObject)
                    {
                        if (item.Value.Type == JTokenType.Object)
                        {
                            Add(item.Key, item.Value.ToString(Newtonsoft.Json.Formatting.None));
                        }
                        else
                        {
                            Add(item.Key, item.Value.ToString());
                        }
                    }
                }
            }
            finally
            {
                Raw = json;
            }
        }

        /// <summary>
        /// 将网关参数转为类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="stringCase">字符串策略</param>
        /// <returns></returns>
        public T ToObject<T>(StringCase stringCase)
        {
            var type = typeof(T);
            var obj = Activator.CreateInstance(type);
            var properties = type.GetProperties();

            foreach (var item in properties)
            {
                var renameAttribute = item.GetCustomAttributes(typeof(ReNameAttribute), true);

                string key;
                if (renameAttribute.Length > 0)
                {
                    key = ((ReNameAttribute)renameAttribute[0]).Name;
                }
                else
                {
                    if (stringCase is StringCase.Camel)
                    {
                        key = item.Name.ToCamelCase();
                    }
                    else if (stringCase is StringCase.Snake)
                    {
                        key = item.Name.ToSnakeCase();
                    }
                    else
                    {
                        key = item.Name;
                    }
                }

                var value = GetStringValue(key);

                if (value != null)
                {
                    item.SetValue(obj, Convert.ChangeType(value, item.PropertyType));
                }
            }

            return (T)obj;
        }

        /// <summary>
        /// 异步将网关参数转为类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="stringCase">字符串策略</param>
        /// <returns></returns>
        public async Task<T> ToObjectAsync<T>(StringCase stringCase)
        {
            return await Task.Run(() => ToObject<T>(stringCase));
        }

        /// <summary>
        /// 清空网关数据
        /// </summary>
        public void Clear()
        {
            _values.Clear();
        }

        /// <summary>
        /// 移除指定参数
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            return _values.Remove(key);
        }

        #endregion
    }
}