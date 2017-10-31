using System;

namespace ICanPay.Core
{
    /// <summary>
    /// 不添加到网关参数属性
    /// </summary>
    public class NotAddAttribute : Attribute
    {
        public NotAddAttribute()
        {
        }
    }
}
