using ICanPay.Alipay;
using ICanPay.Core;
using ICanPay.Core.Utils;
using System;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace ICanPay.UnitTest
{
    public class AlipayGatewayTest
    {
        private readonly ITestOutputHelper _output;
        private readonly AlipayGateway _alipayGateway;
        private readonly Merchant _merchant;
        private readonly Order _order;
        private string _outTradeNo => DateTime.Now.ToString("yyyyMMddhhmmss");

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

            _order = new Order()
            {
                Amount = 0.01,
                Subject = "支付宝测试"
            };

            _alipayGateway = new AlipayGateway(_merchant);
        }

        [Fact]
        public void TestWebPay()
        {
            _order.OutTradeNo = _outTradeNo;
            _alipayGateway.Order = _order;
            _alipayGateway.InitFormPayment();

            Assert.Throws<WebException>(() =>
            {
                HttpUtil.Post(_alipayGateway.GatewayUrl, _alipayGateway.GatewayData.ToUrl());
            });
        }

        [Fact]
        public void TestWapPay()
        {
            _order.OutTradeNo = _outTradeNo;
            _alipayGateway.Order = _order;
            string url = _alipayGateway.BuildUrlPayment();

            Assert.Throws<WebException>(() =>
            {
                HttpUtil.Get(url);
            });
        }

        [Fact]
        public void TestAppPay()
        {
            _order.OutTradeNo = _outTradeNo;
            _alipayGateway.Order = _order;
            string result = _alipayGateway.BuildAppPayment();

            _output.WriteLine(result);
        }

        [Fact]
        public void TestBarcodePay()
        {
            _order.OutTradeNo = _outTradeNo;
            _alipayGateway.Order = _order;
            _alipayGateway.PaymentSucceed += _alipayGateway_PaymentSucceed;
            _alipayGateway.PaymentFailed += _alipayGateway_PaymentFailed;
            _alipayGateway.BuildBarcodePayment();
        }

        private void _alipayGateway_PaymentSucceed(object arg1, PaymentSucceedEventArgs arg2)
        {
            _output.WriteLine("支付成功");
        }

        private void _alipayGateway_PaymentFailed(object arg1, PaymentFailedEventArgs arg2)
        {
            _output.WriteLine(arg2.Message);
        }

        [Fact]
        public void TestScanPay()
        {
            _order.OutTradeNo = _outTradeNo;
            _alipayGateway.Order = _order;
            string result = _alipayGateway.BuildScanPayment();

            Assert.Contains("http", result);
            _output.WriteLine(result);
        }

        [Fact]
        public void TestQuery()
        {
            var notify = (Notify)_alipayGateway.BuildQuery(new Auxiliary
            {
                OutTradeNo = _outTradeNo
            });

            Assert.Contains("交易不存在", notify.SubMessage);
            _output.WriteLine(Util.SerializeObject(notify));
        }

        [Fact]
        public void TestCancel()
        {
            var notify = (Notify)_alipayGateway.BuildCancel(new Auxiliary
            {
                OutTradeNo = _outTradeNo
            });

            Assert.Contains("10000", notify.Code);
            _output.WriteLine(Util.SerializeObject(notify));
        }

        [Fact]
        public void TestClose()
        {
            var notify = (Notify)_alipayGateway.BuildClose(new Auxiliary
            {
                OutTradeNo = _outTradeNo
            });

            Assert.Contains("交易不存在", notify.SubMessage);
            _output.WriteLine(Util.SerializeObject(notify));
        }

        [Fact]
        public void TestRefund()
        {
            var notify = (Notify)_alipayGateway.BuildRefund(new Auxiliary
            {
                OutTradeNo = _outTradeNo,
                RefundAmount = 0.01,
                OutRefundNo = _outTradeNo
            });

            Assert.Contains("交易不存在", notify.SubMessage);
            _output.WriteLine(Util.SerializeObject(notify));
        }

        [Fact]
        public void TestRefundQuery()
        {
            var notify = (Notify)_alipayGateway.BuildRefundQuery(new Auxiliary
            {
                OutTradeNo = _outTradeNo,
                OutRefundNo = "123"
            });

            Assert.Contains("交易不存在", notify.SubMessage);
            _output.WriteLine(Util.SerializeObject(notify));
        }

        [Fact]
        public void TestBillDownload()
        {
            var fileStream = _alipayGateway.BuildBillDownload(new Auxiliary
            {
                BillType = "trade",
                BillDate = "2017-10-31"
            });

            Assert.True(fileStream.Length > 0);
        }
    }
}
