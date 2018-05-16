using PaySharp.Core;
using PaySharp.Core.Response;

namespace PaySharp.Wechatpay.Response
{
    public class OAuthResponse : IResponse
    {
        /// <summary>
        /// 网页授权接口调用凭证
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// access_token接口调用凭证超时时间，单位（秒）
        /// </summary>
        public string ExpiresIn { get; set; }

        /// <summary>
        /// 用户刷新access_token
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// 用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        /// </summary>
        [ReName(Name = "openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 当且仅当该网站应用已获得该用户的userinfo授权时，才会出现该字段
        /// </summary>
        [ReName(Name = "unionid")]
        public string UnionId { get; set; }

        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误代码描述
        /// </summary>
        public string ErrMsg { get; set; }

        public string Raw { get; set; }

        internal GatewayData GatewayData { get; set; }
    }
}
