#if NET45
using PaySharp.Alipay;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace PaySharp.Core.Mvc
{
    public static class PaySharpConfigExtensions
    {
        public static IGateways RegisterAlipay(this IGateways gateways, Action<Merchant> action)
        {
            if (action != null)
            {
                var merchant = new Merchant();
                action(merchant);
                gateways.Add(new AlipayGateway(merchant));
            }

            return gateways;
        }

        public static IGateways RegisterAlipay(this IGateways gateways)
        {
            var merchants = (List<Hashtable>)ConfigurationManager.GetSection("paySharp/alipays");
            if (merchants == null)
            {
                return gateways;
            }

            foreach (var item in merchants)
            {
                var alipayGateway = new AlipayGateway(new Merchant
                {
                    AppId = item["appId"].ToString(),
                    AlipayPublicKey = item["alipayPublicKey"].ToString(),
                    NotifyUrl = item["notifyUrl"].ToString(),
                    Privatekey = item["privatekey"].ToString(),
                    ReturnUrl = item["returnUrl"].ToString()
                });

                var gatewayUrl = item["gatewayUrl"].ToString();
                if (!string.IsNullOrEmpty(gatewayUrl))
                {
                    alipayGateway.GatewayUrl = gatewayUrl;
                }

                gateways.Add(alipayGateway);
            }

            return gateways;
        }
    }
}

#endif