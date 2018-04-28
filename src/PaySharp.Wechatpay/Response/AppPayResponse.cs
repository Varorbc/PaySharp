using PaySharp.Core;
using PaySharp.Core.Request;
using PaySharp.Core.Utils;
using System;

namespace PaySharp.Wechatpay.Response
{
    public class AppPayResponse : BaseResponse
    {
        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { get; set; }

        /// <summary>
        /// 微信生成的预支付回话标识，用于后续接口调用中使用，该值有效期为2小时
        /// </summary>
        public string PrepayId { get; set; }

        /// <summary>
        /// 用于唤起App的订单参数
        /// </summary>
        public string OrderInfo { get; set; }

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
            if (ResultCode == "SUCCESS")
            {
                var gatewayData = new GatewayData();
                gatewayData.Add("appid", merchant.AppId);
                gatewayData.Add("partnerid", merchant.MchId);
                gatewayData.Add("prepayid", PrepayId);
                gatewayData.Add("package", "Sign=WXPay");
                gatewayData.Add("noncestr", Util.GenerateNonceStr());
                gatewayData.Add("timestamp", DateTime.Now.ToTimeStamp());

                string data = $"{gatewayData.ToUrl(false)}&key={merchant.Key}";
                string sign = EncryptUtil.MD5(data);
                gatewayData.Add("sign", sign);

                OrderInfo = gatewayData.ToJson();
            }
        }
    }
}
