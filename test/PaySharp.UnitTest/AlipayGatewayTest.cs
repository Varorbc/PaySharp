using PaySharp.Alipay;
using PaySharp.Alipay.Domain;
using PaySharp.Alipay.Request;
using PaySharp.Core.Response;
using PaySharp.Core.Utils;
using System;
using Xunit;
using Xunit.Abstractions;

namespace PaySharp.UnitTest
{
    public class AlipayGatewayTest
    {
        private readonly ITestOutputHelper _output;
        private readonly AlipayGateway _alipayGateway;
        private readonly Merchant _merchant;
        private string _outTradeNo => DateTime.Now.ToString("yyyyMMddhhmmss");
        private string _outRefundNo => DateTime.Now.ToString("yyyyMMddhhmmss");

        public AlipayGatewayTest(ITestOutputHelper output)
        {
            _output = output;

            _merchant = new Merchant
            {
                AppId = "2016081600256163",
                NotifyUrl = "http://localhost:61337/Notify",
                ReturnUrl = "http://localhost:61337/Return",
                AlipayPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAsW6+mN2E3Oji2DPjSKuYgRzK6MlH9q6W0iM0Yk3R0qbpp5wSesSXqudr2K25gIBOTCchiIbXO7GXt/zEdnhnC32eOaTnonDsnuBWIp+q7LoVx/gvKIX5LTHistCvGli8VW4EDGsu2jAyQXyMPgPrIz+/NzWis/gZsa4TaqVY4SpWRuSgMXxleh2ERB6k0ijK0IYM+Cv5fz1ZPDCgk7EbII2jk2fDxtlMLoN5UYEJCcD8OUyivm3Hti3u1kPolckCCf0xk+80g/4EdmzFAffsVgPeXZrkm5EIuiTTOIeRHXlTg3HtkkCw2Wl0CpYSKBr9Vzv7x0gNvb1wnXPmBJNRgQIDAQAB",
                Privatekey = "MIIEpAIBAAKCAQEAyC43UbsE5XZ2Pmqg1YgzeCqAMk4HOH8fYHslseeSgKxyDjybjqM0yjGIJry1FRmVvLnY7v8jURgwr7d/pDCSRdoHa6zaxuSzg0OlieNmujae34YZ54PmFxULZW0BHSdzmx3OIYK2GarRECkds531ZzpbLdRXqsxQf5G26JZLIFxmNuh/VjBjJ6Hic1WOFT+FCYyi8om+LkPn3jELeA7LPLXzFqzzxx0vo4yiAePrsX5WucWxf+Y8rZoDhRIy/cPtQECXi9SiAWOJe/82JqjVjfpowf3QN7UJHsA82RBloAS4lvvDGJA7a+8DDlqpqPer8cS41Dv5r39iqtJUybDqoQIDAQABAoIBAHi39kBhiihe8hvd7bQX+QIEj17G02/sqZ1jZm4M+rqCRB31ytGP9qvghvzlXEanMTeo0/v8/O1Qqzusa1s2t19MhqEWkrDTBraoOtIWwsKVYeXmVwTY9A8Db+XwgHV2by8iIEbxLqP38S/Pu8uv/GgONyJCJcQohnsIAsfsqs2OGggz+PplZaXJfUkPomWkRdHM9ZWWDLrCIlmRSHLmhHEtFJaXD083kqo437qra58Amw/n+2gH57utbAQ9V3YQFjD8zW511prC+mB6N/WUlaLstkxswGJ16obEJfQ0r8wYHx14ep6UKGyi3YXlMHcteI8gz+uFx4RuVV9EotdXagECgYEA7AEz9oPFYlW1H15OkDGy8yBnpJwIBu2CQLxINsxhrLIAZ2Bgxqcsv+D9CpnYCBDisbXoGoyMK6XaSypBMRKe2y8yRv4c+w00rcKHtGfRjzSJ5NQO0Tv+q8vKY+cd6BuJ6OUQw82ICLANIfHJZNxtvtTCmmqBwSJDpcQJQXmKXTECgYEA2SQCSBWZZONkvhdJ15K+4IHP2HRbYWi+C1OvKzUiK5bdJm77zia4yJEJo5Y/sY3mV3OK0Bgb7IAaxL3i0oH+WNTwbNoGpMlYHKuj4x1453ITyjOwPNj6g27FG1YSIDzhB6ZC4dBlkehi/7gIlIiQt1wkIZ+ltOqgI5IqIdXoSHECgYB3zCiHYt4oC1+UW7e/hCrVNUbHDRkaAygSGkEB5/9QvU5tK0QUsrmJcPihj/RUK9YW5UK7b0qbwWWsr/dFpLEUi8GWvdkSKuLprQxbrDN44O96Q5Z96Vld9WV4DtJkhs4bdWNsMQFzf4I7D9PuKeJfcvqRjaztz6nNFFSqcrqkkQKBgQCJKlUCohpG/9notp9fvQQ0n+viyQXcj6TVVOSnf6X5MRC8MYmBHTbHA8+59bSAfanO/l7muwQQro+6TlUVMyaviLvjlwpxV/sACXC6jCiO06IqreIbXdlJ41RBw2op0Ss5gM5pBRLUS58V+HP7GBWKrnrofofXtAq6zZ8txok4EQKBgQCXrTeGMs7ECfehLz64qZtPkiQbNwupg938Z40Qru/G1GR9u0kmN7ibTyYauI6NNVHGEZa373EBEkacfN+kkkLQMs1tj5Zrlw+iITm+ad/irpXQZS/NHCcrg6h82vu0LcgiKnHKlmW6K5ne0w4LqmsmRCm7JdJjt9WlapAs0ticiw=="
            };

            _alipayGateway = new AlipayGateway(_merchant)
            {
                GatewayUrl = "https://openapi.alipaydev.com"
            };
        }

        [Fact]
        public void TestWebPay()
        {
            var request = new WebPayRequest();
            request.AddGatewayData(new WebPayModel()
            {
                TotalAmount = 1,
                Subject = "支付宝电脑网站支付测试",
                OutTradeNo = _outTradeNo
            });

            var response = _alipayGateway.Execute(request);

            _output.WriteLine(response.Html);
            Assert.NotNull(response.Html);
        }

        [Fact]
        public void TestWapPay()
        {
            var request = new WapPayRequest();
            request.AddGatewayData(new WapPayModel()
            {
                TotalAmount = 1,
                Subject = "支付宝手机网站支付测试",
                OutTradeNo = _outTradeNo
            });

            var response = _alipayGateway.Execute(request);

            _output.WriteLine(response.Url);
            string result = HttpUtil.Get(response.Url);
            Assert.Contains("支付宝", result);
        }

        [Fact]
        public void TestAppPay()
        {
            var request = new AppPayRequest();
            request.AddGatewayData(new AppPayModel()
            {
                TotalAmount = 1,
                Subject = "支付宝手机APP支付测试",
                OutTradeNo = _outTradeNo
            });

            var response = _alipayGateway.Execute(request);

            _output.WriteLine(response.OrderInfo);
            Assert.NotNull(response.OrderInfo);
        }

        [Fact]
        public void TestBarcodePay()
        {
            var request = new BarcodePayRequest();
            request.AddGatewayData(new BarcodePayModel()
            {
                TotalAmount = 1,
                Subject = "支付宝条码支付测试",
                OutTradeNo = _outTradeNo,
                AuthCode = "123"
            });
            request.PaySucceed += BarcodePay_PaySucceed;
            request.PayFailed += BarcodePay_PayFaild;

            var response = _alipayGateway.Execute(request);
            Assert.Equal("40004", response.Code);
        }

        private void BarcodePay_PaySucceed(IResponse response, string message)
        {
        }

        private void BarcodePay_PayFaild(IResponse response, string message)
        {
        }

        [Fact]
        public void TestScanPay()
        {
            var request = new ScanPayRequest();
            request.AddGatewayData(new ScanPayModel()
            {
                TotalAmount = 1,
                Subject = "支付宝扫码支付测试",
                OutTradeNo = _outTradeNo
            });

            var response = _alipayGateway.Execute(request);

            _output.WriteLine(response.QrCode);
            Assert.NotNull(response.QrCode);
        }

        [Fact]
        public void TestQuery()
        {
            var request = new QueryRequest();
            request.AddGatewayData(new QueryModel()
            {
                OutTradeNo = _outTradeNo
            });

            var response = _alipayGateway.Execute(request);
            Assert.Equal("40004", response.Code);
        }

        [Fact]
        public void TestCancel()
        {
            var request = new CancelRequest();
            request.AddGatewayData(new CancelModel()
            {
                OutTradeNo = _outTradeNo
            });

            var response = _alipayGateway.Execute(request);
            Assert.Equal("10000", response.Code);
        }

        [Fact]
        public void TestClose()
        {
            var request = new CloseRequest();
            request.AddGatewayData(new CloseModel()
            {
                OutTradeNo = _outTradeNo
            });

            var response = _alipayGateway.Execute(request);
            Assert.Equal("40004", response.Code);
        }

        [Fact]
        public void TestRefund()
        {
            var request = new RefundRequest();
            request.AddGatewayData(new RefundModel()
            {
                OutTradeNo = _outTradeNo,
                RefundAmount = 1,
                OutRefundNo = _outRefundNo
            });

            var response = _alipayGateway.Execute(request);
            Assert.Equal("40004", response.Code);
        }

        [Fact]
        public void TestRefundQuery()
        {
            var request = new RefundQueryRequest();
            request.AddGatewayData(new RefundQueryModel()
            {
                OutTradeNo = _outTradeNo,
                OutRefundNo = _outRefundNo
            });

            var response = _alipayGateway.Execute(request);
            Assert.Equal("40004", response.Code);
        }

        [Fact]
        public void TestTransfer()
        {
            var request = new TransferRequest();
            request.AddGatewayData(new TransferModel()
            {
                OutTradeNo = _outTradeNo,
                PayeeAccount = "lmgnst2438@sandbox.com",
                Amount = 1,
                PayeeType = "ALIPAY_LOGONID"
            });

            var response = _alipayGateway.Execute(request);
            Assert.Equal("10000", response.Code);
        }

        [Fact]
        public void TestTransferQuery()
        {
            var request = new TransferQueryRequest();
            request.AddGatewayData(new TransferQueryModel()
            {
                OutTradeNo = _outTradeNo
            });

            var response = _alipayGateway.Execute(request);
            Assert.Equal("40004", response.Code);
        }

        [Fact]
        public void TestBillDownload()
        {
            var request = new BillDownloadRequest();
            request.AddGatewayData(new BillDownloadModel()
            {
                BillDate = "2018-04-09",
                BillType = "trade"
            });

            var response = _alipayGateway.Execute(request);
            Assert.True(response.GetBillFile().Length > 0);
        }
    }
}
