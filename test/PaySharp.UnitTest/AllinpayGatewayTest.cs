using System;
using PaySharp.Allinpay;
using PaySharp.Allinpay.Domain;
using PaySharp.Allinpay.Enum;
using PaySharp.Allinpay.Request;
using PaySharp.Core.Response;
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
                Body = "通联收银宝统一支付测试",
                TotalAmount = 1,
                OutTradeNo = OutTradeNo
            });

            var response = _allinpayGateway.Execute(request);

            _output.WriteLine(response.PayInfo);
            Assert.NotNull(response.PayInfo);
        }

        [Fact]
        public void TestBarcodePay()
        {
            var request = new BarcodePayRequest();
            request.AddGatewayData(new BarcodePayModel()
            {
                TotalAmount = 1,
                Body = "通联收银宝条码支付测试",
                OutTradeNo = OutTradeNo,
                AuthCode = "134682490424538597"
            });
            request.PaySucceed += BarcodePay_PaySucceed;
            request.PayFailed += BarcodePay_PayFaild;

            var response = _allinpayGateway.Execute(request);
            Assert.Equal("SUCCESS", response.ReturnCode);
        }

        private void BarcodePay_PaySucceed(IResponse response, string message)
        {
        }

        private void BarcodePay_PayFaild(IResponse response, string message)
        {
        }

        [Fact]
        public void TestQuery()
        {
            var request = new QueryRequest();
            request.AddGatewayData(new QueryModel()
            {
                OutTradeNo = "20191228080146"
            });

            var response = _allinpayGateway.Execute(request);
            Assert.Equal("SUCCESS", response.ReturnCode);
        }
    }
}
