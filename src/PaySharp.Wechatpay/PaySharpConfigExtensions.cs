#if NET45
using PaySharp.Wechatpay;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace PaySharp.Core.Mvc
{
    public static class PaySharpConfigExtensions
    {
        public static IGateways RegisterWechatpay(this IGateways gateways, Action<Merchant> action)
        {
            if (action != null)
            {
                var merchant = new Merchant();
                action(merchant);
                gateways.Add(new WechatpayGateway(merchant));
            }

            return gateways;
        }

        public static IGateways RegisterWechatpay(this IGateways gateways)
        {
            var merchants = (List<Hashtable>)ConfigurationManager.GetSection("paySharp/wechatpays");
            if (merchants == null)
            {
                return gateways;
            }

            foreach (var item in merchants)
            {
                var WechatpayGateway = new WechatpayGateway(new Merchant
                {
                    AppId = item["appId"].ToString(),
                    MchId = item["mchId"].ToString(),
                    NotifyUrl = item["notifyUrl"].ToString(),
                    Key = item["key"].ToString(),
                    AppSecret = item["appSecret"].ToString(),
                    SslCertPath = item["sslCertPath"].ToString(),
                    SslCertPassword = item["sslCertPassword"].ToString(),
                    PublicKey = item["publicKey"].ToString()
                });

                var gatewayUrl = item["gatewayUrl"].ToString();
                if (!string.IsNullOrEmpty(gatewayUrl))
                {
                    WechatpayGateway.GatewayUrl = gatewayUrl;
                }

                gateways.Add(WechatpayGateway);
            }

            return gateways;
        }
    }
}

#endif