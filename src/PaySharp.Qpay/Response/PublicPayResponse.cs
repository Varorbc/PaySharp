using PaySharp.Core;
using PaySharp.Core.Request;

namespace PaySharp.Qpay.Response
{
    public class PublicPayResponse : BaseResponse
    {
        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { get; set; }

        /// <summary>
        /// QQ钱包生成的预支付回话标识，用于后续接口调用中使用，该值有效期为2小时
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
                gatewayData.Add("tokenId", PrepayId);
                gatewayData.Add("pubAcc", "");
                gatewayData.Add("pubAccHint", "欢迎关注");
                gatewayData.Add("appInfo", $"appid#{merchant.AppId}|bargainor_id#{merchant.MchId}|channel#wallet");

                OrderInfo = gatewayData.ToJson();
            }
        }
    }
}
