using System;
using PaySharp.Allinpay;
using PaySharp.Allinpay.Domain;
using PaySharp.Allinpay.Enum;
using PaySharp.Allinpay.Request;
using Xunit;
using Xunit.Abstractions;

namespace PaySharp.UnitTest
{
    public class AllinpayGatewayTest
    {
        private readonly ITestOutputHelper _output;
        private readonly AllinpayGateway _allinpayGateway;
        private readonly Merchant _merchant;
        private string OutTradeNo => DateTime.Now.ToString("yyyyMMddhhmmss");

        public AllinpayGatewayTest(ITestOutputHelper output)
        {
            _output = output;

            _merchant = new Merchant
            {
                AppId = "00000051",
                MchId = "990581007426001",
                Key = "allinpay888",
                NotifyUrl = "http://localhost:61337/Notify"
            };

            _allinpayGateway = new AllinpayGateway(_merchant)
            {
                GatewayUrl = "https://test.allinpaygd.com"
            };
        }

        [Fact]
        public void TestUnifiedPay()
        {
            var request = new UnifiedPayRequest();
            request.AddGatewayData(new UnifiedPayModel
            {
                PayType = PayType.A01,
                Body = "通联收银宝商品测试",
                TotalAmount = 1,
                OutTradeNo = OutTradeNo
            });

            var response = _allinpayGateway.Execute(request);

            _output.WriteLine(response.PayInfo);
            Assert.NotNull(response.PayInfo);
        }
    }
}
