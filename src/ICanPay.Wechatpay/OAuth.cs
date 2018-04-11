using ICanPay.Core;
using System;

namespace ICanPay.Wechatpay
{
    public class OAuth
    {
        /// <summary>
        /// 接口调用凭证
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// access_token接口调用凭证超时时间，单位（秒）
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// 用户刷新access_token
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// 授权用户唯一标识
        /// </summary>
        [ReName(Name = "openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// 当且仅当该网站应用已获得该用户的userinfo授权时，才会出现该字段。
        /// </summary>
        [ReName(Name = "unionid")]
        public string UnionId { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpiresTime
        {
            get
            {
                return now.AddSeconds(ExpiresIn);
            }
        }

        private readonly DateTime now = DateTime.Now;
    }
}
