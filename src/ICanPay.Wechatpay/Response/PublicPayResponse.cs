using ICanPay.Core;
using ICanPay.Core.Utils;
using System;

namespace ICanPay.Wechatpay.Response
{
    public class PublicPayResponse : BaseResponse
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

        internal override void Execute(Merchant merchant)
        {
            var gatewayData = new GatewayData();
            gatewayData.Add("appId", merchant.AppId);
            gatewayData.Add("timeStamp", DateTime.Now.ToTimeStamp());
            gatewayData.Add("nonceStr", Util.GenerateNonceStr());
            gatewayData.Add("package", $"prepay_id={PrepayId}");
            gatewayData.Add("signType", "MD5");

            string data = $"{gatewayData.ToUrl(false)}&key={merchant.Key}";
            string sign = EncryptUtil.MD5(data);
            gatewayData.Add("paySign", sign);

            OrderInfo = gatewayData.ToJson();
        }
    }
}
