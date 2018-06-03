#if NET45
using PaySharp.Qpay;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace PaySharp.Core.Mvc
{
    public static class PaySharpConfigExtensions
    {
        public static IGateways RegisterQpay(this IGateways gateways, Action<Merchant> action)
        {
            if (action != null)
            {
                var merchant = new Merchant();
                action(merchant);
                gateways.Add(new QpayGateway(merchant));
            }

            return gateways;
        }

        public static IGateways RegisterQpay(this IGateways gateways)
        {
            var merchants = (List<Hashtable>)ConfigurationManager.GetSection("paySharp/qpays");
            if (merchants == null)
            {
                return gateways;
            }

            foreach (var item in merchants)
            {
                var QpayGateway = new QpayGateway(new Merchant
                {
                    AppId = item["appId"].ToString(),
                    MchId = item["mchId"].ToString(),
                    NotifyUrl = item["notifyUrl"].ToString(),
                    Key = item["key"].ToString(),
                    SslCertPath = item["sslCertPath"].ToString(),
                    SslCertPassword = item["sslCertPassword"].ToString()
                });

                var gatewayUrl = item["gatewayUrl"].ToString();
                if (!string.IsNullOrEmpty(gatewayUrl))
                {
                    QpayGateway.GatewayUrl = gatewayUrl;
                }

                gateways.Add(QpayGateway);
            }

            return gateways;
        }
    }
}

#endif