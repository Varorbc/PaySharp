using PaySharp.Core;
using PaySharp.Core.Utils;
using System;
using System.Collections.Generic;

namespace PaySharp.Wechatpay
{
    internal static class ConvertUtil
    {
        public static List<T> ToList<T, TChildren>(GatewayData gatewayData, int index)
        {
            var flag = true;
            var list = new List<T>();
            int i = 0;
            while (flag)
            {
                var type = typeof(T);
                var obj = Activator.CreateInstance(type);
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
    }
}