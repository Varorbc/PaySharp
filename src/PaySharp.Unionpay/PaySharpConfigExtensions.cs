#if NET45
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using PaySharp.Unionpay;

namespace PaySharp.Core.Mvc
{
    public static class PaySharpConfigExtensions
    {
        public static IGateways RegisterUnionpay(this IGateways gateways, Action<Merchant> action)
        {
            if (action != null)
            {
                var merchant = new Merchant();
                action(merchant);
                gateways.Add(new UnionpayGateway(merchant));
            }

            return gateways;
        }

        public static IGateways RegisterUnionpay(this IGateways gateways)
        {
            var merchants = (List<Hashtable>)ConfigurationManager.GetSection("paySharp/unionpays");
            if (merchants == null)
            {
                return gateways;
            }

            foreach (var item in merchants)
            {
                var unionpayGateway = new UnionpayGateway(new Merchant
                {
                    AppId = item["appId"].ToString(),
                    CertPwd = item["certPwd"].ToString(),
                    NotifyUrl = item["notifyUrl"].ToString(),
                    CertPath = item["certPath"].ToString(),
                    ReturnUrl = item["returnUrl"].ToString()
                });

                var gatewayUrl = item["gatewayUrl"].ToString();
                if (!string.IsNullOrEmpty(gatewayUrl))
                {
                    unionpayGateway.GatewayUrl = gatewayUrl;
                }

                gateways.Add(unionpayGateway);
            }

            return gateways;
        }
    }
}

#endif
