using System;
using PaySharp.Netpay;
using PaySharp.Netpay.Domain;
using PaySharp.Netpay.Request;
using Xunit;
using Xunit.Abstractions;

namespace PaySharp.UnitTest
{
    public class NetpayGatewayTest
    {
        private readonly ITestOutputHelper _output;
        private readonly NetpayGateway _netpayGateway;
        private readonly Merchant _merchant;
        private string OutTradeNo => DateTime.Now.ToString("3194yyyyMMddhhmmss");

        public NetpayGatewayTest(ITestOutputHelper output)
        {
            _output = output;

            _merchant = new Merchant
            {
                AppId = "00000001",
                MchId = "898310148160568",
                Key = "fcAmtnx7MwismjWNhNKdHC44mNXtnEQeJkRrhKJwyrW2ysRR",
                Source = "WWW.TEST.COM",
                NotifyUrl = "http://localhost:61337/Notify"
            };

            _netpayGateway = new NetpayGateway(_merchant)
            {
                GatewayUrl = "https://qr-test2.chinaums.com"
            };
        }

        [Fact]
        public void TestUnifiedPay()
        {
            var request = new UnifiedPayRequest();
            request.AddGatewayData(new UnifiedPayModel
            {
                MsgType = "trade.precreate",
                Body = "银联商务统一支付测试",
                TotalAmount = 1,
                OriginalAmount = 1,
                OutTradeNo = OutTradeNo
            });

            var response = _netpayGateway.Execute(request);

            _output.WriteLine(response.QrCode);
            Assert.NotNull(response.QrCode);
        }

        [Fact]
        public void TestQuery()
        {
            var request = new QueryRequest();
            request.AddGatewayData(new QueryModel()
            {
                MsgType = "query",
                OutTradeNo = "319420200104045313"
            });

            var response = _netpayGateway.Execute(request);
            Assert.Equal(1, response.TotalAmount);
        }
    }
}
