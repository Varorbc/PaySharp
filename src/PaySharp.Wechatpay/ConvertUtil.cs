using PaySharp.Core;
using PaySharp.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PaySharp.Wechatpay
{
    internal static class ConvertUtil
    {

        public static List<T> ToList<T, TChildren>(GatewayData gatewayData, int index) where T:new() where TChildren:new()
        {
            var flag = true;
            var list = new List<T>();
            int i = 0;
            while (flag)
            {
                var type = typeof(T);
                var obj = new T();
                var properties = type.GetProperties();
                var isFirstProperty = true;

                foreach (var item in properties)
                {
                    if (item.PropertyType == typeof(List<TChildren>))
                    {
                        var chidrenList = ToList<TChildren, object>(gatewayData, i);
                        item.SetValue(obj, chidrenList);
                        continue;
                    }

                    string key = GetRealName(item);
                    if (index > -1)
                    {
                        key += $"_{index}";
                    }
                    key += $"_{i}";

                    var value = gatewayData.GetStringValue(key);
                    if (value == null)
                    {
                        if (isFirstProperty)
                        {
                            flag = false;
                            break;
                        }
                        continue;
                    }

                    isFirstProperty = false;
                    item.SetValue(obj, Convert.ChangeType(value, item.PropertyType));
                }

                if (!flag)
                {
                    return list;
                }

                list.Add((T)obj);
                i++;
            }

            return list;
        }

        /// <summary>
        /// 获取字段json中的名字
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static string GetRealName(System.Reflection.PropertyInfo item)
        {
            string key;
            var renameAttribute = item.GetCustomAttributes(typeof(ReNameAttribute), true);
            if (renameAttribute.Length > 0)
            {
                key = ((ReNameAttribute)renameAttribute[0]).Name;
            }
            else
            {
                key = item.Name.ToSnakeCase();
            }

            return key;
        }

        /// <summary>
        /// 将微信返回值特殊格式转化为列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gatewayData"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(GatewayData gatewayData) where T : new()
        {
            var list = new List<T>();
            var properties = typeof(T).GetProperties();
            var keyfirst = properties[0];
            var count = gatewayData.Keys.Where(p => Regex.IsMatch(p, $@"{GetRealName(keyfirst)}_\d")).Count();

            for (var i = 0; i < count; i++)
            {
                var item = new T();
                foreach(var field in properties)
                {
                    string keyname = $"{GetRealName(field)}_{i}";
                    field.SetValue(item, gatewayData.GetStringValue(keyname));
                }
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// 将微信返回值特殊格式转化为列表(二级)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TChildren"></typeparam>
        /// <param name="gatewayData"></param>
        /// <returns></returns>
        public static List<T> ToList<T, TChildren>(GatewayData gatewayData) where T : new() where TChildren : new()
        {
            var list = new List<T>();
            var properties = typeof(T).GetProperties();
            var keyfirst = properties[0];
            var count = gatewayData.Keys.Where(p => Regex.IsMatch(p, $@"{GetRealName(keyfirst)}_\d")).Count();

            for (var i = 0; i < count; i++)
            {
                var item = new T();
                foreach (var field in properties)
                {
                    if (field.PropertyType == typeof(List<TChildren>))
                    {
                        var sublist = new List<TChildren>();
                        var subProperties = typeof(TChildren).GetProperties();
                        var subFirstkey = subProperties[0];
                        var SubFirstName = GetRealName(subFirstkey);
                        var subCount = gatewayData.Keys.Where(p => Regex.IsMatch(p,  $@"{SubFirstName}_{i}_\d")).Count();
                        for(var j = 0; j < subCount; j++)
                        {
                            var subItem = new TChildren();
                            foreach (var subfield in subProperties)
                            {
                                string keyname = $"{GetRealName(subfield)}_{i}_{j}";
                                subfield.SetValue(subItem, gatewayData.GetStringValue(keyname));
                            }
                            sublist.Add(subItem);
                        }
                        field.SetValue(item, sublist);
                    }
                    else
                    {
                        string keyname = $"{GetRealName(field)}_{i}";
                        field.SetValue(item, gatewayData.GetStringValue(keyname));
                    }
                }
                list.Add(item);
            }
            return list;
        }
    }
}