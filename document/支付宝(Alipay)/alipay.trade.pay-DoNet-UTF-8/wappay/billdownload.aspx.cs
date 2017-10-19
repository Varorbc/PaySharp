using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Response;
using System;
using System.Web.UI;

namespace alipay.wappay
{
    public partial class billdownload : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAopClient client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", "app_id", "merchant_private_key", "json", "1.0", "RSA2", "alipay_public_key", "GBK", false);
            AlipayDataDataserviceBillDownloadurlQueryRequest request = new AlipayDataDataserviceBillDownloadurlQueryRequest();
            request.BizContent = "{" +
            "\"bill_type\":\"trade\"," +
            "\"bill_date\":\"2016-04-05\"" +
            "  }";
            AlipayDataDataserviceBillDownloadurlQueryResponse response = client.Execute(request);
            Console.WriteLine(response.Body);
        }
    }
}