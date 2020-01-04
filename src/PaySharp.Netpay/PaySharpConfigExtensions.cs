#if NET45
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using PaySharp.Netpay;

namespace PaySharp.Core.Mvc
{
    public static class PaySharpConfigExtensions
    {
        public static IGateways RegisterNetpay(this IGateways gateways, Action<Merchant> action)
        {
            if (action != null)
            {
                var merchant = new Merchant();
                action(merchant);
                gateways.Add(new NetpayGateway(merchant));
            }

            return gateways;
        }

        public static IGateways RegisterNetpay(this IGateways gateways)
        {
            var merchants = (List<Hashtable>)ConfigurationManager.GetSection("paySharp/Netpays");
            if (merchants == null)
            {
                return gateways;
            }

            foreach (var item in merchants)
            {
                var netpayGateway = new NetpayGateway(new Merchant
                {
                    AppId = item["appId"].ToString(),
                    SubAppId = item["subAppId"].ToString(),
                    MchId = item["mchId"].ToString(),
                    InstMchId = item["instMchId"].ToString(),
                    Key = item["key"].ToString(),
                    Source = item["source"].ToString(),
                    NotifyUrl = item["notifyUrl"].ToString(),
                    ReturnUrl = item["returnUrl"].ToString()
                });

                var gatewayUrl = item["gatewayUrl"].ToString();
                if (!string.IsNullOrEmpty(gatewayUrl))
                {
                    netpayGateway.GatewayUrl = gatewayUrl;
                }

                gateways.Add(netpayGateway);
            }

            return gateways;
        }
    }
}

#endif
