#if NET45
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using PaySharp.Allinpay;

namespace PaySharp.Core.Mvc
{
    public static class PaySharpConfigExtensions
    {
        public static IGateways RegisterAllinpay(this IGateways gateways, Action<Merchant> action)
        {
            if (action != null)
            {
                var merchant = new Merchant();
                action(merchant);
                gateways.Add(new AllinpayGateway(merchant));
            }

            return gateways;
        }

        public static IGateways RegisterAllinpay(this IGateways gateways)
        {
            var merchants = (List<Hashtable>)ConfigurationManager.GetSection("paySharp/allinpays");
            if (merchants == null)
            {
                return gateways;
            }

            foreach (var item in merchants)
            {
                var allinpayGateway = new AllinpayGateway(new Merchant
                {
                    AppId = item["appId"].ToString(),
                    MchId = item["mchId"].ToString(),
                    NotifyUrl = item["notifyUrl"].ToString()
                });

                var gatewayUrl = item["gatewayUrl"].ToString();
                if (!string.IsNullOrEmpty(gatewayUrl))
                {
                    allinpayGateway.GatewayUrl = gatewayUrl;
                }

                gateways.Add(allinpayGateway);
            }

            return gateways;
        }
    }
}

#endif
