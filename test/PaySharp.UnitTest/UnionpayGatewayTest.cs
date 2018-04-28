using PaySharp.Core.Exceptions;
using PaySharp.Core.Utils;
using PaySharp.Unionpay;
using System;
using Xunit;
using Xunit.Abstractions;

namespace PaySharp.UnitTest
{
    public class UnionpayGatewayTest
    {
        private readonly ITestOutputHelper _output;
        private readonly UnionpayGateway _unionGateway;
        private readonly Merchant _merchant;
        private readonly Order _order;
        private string _outTradeNo => DateTime.Now.ToString("yyyyMMddhhmmss");

        public UnionpayGatewayTest(ITestOutputHelper output)
        {
            _output = output;

            _merchant = new Merchant
            {
                AppId = "777290058110048",
                CertPwd = "000000",
                CertPath = Environment.CurrentDirectory + "\\acp_test_sign.pfx",
                NotifyUrl = "http://localhost:61337/Notify",
                FrontUrl = "http://localhost:61337/Notify"
            };

            _order = new Order()
            {
                Amount = 0.01,
            };

            _unionGateway = new UnionpayGateway(_merchant);
        }

        [Fact]
        public void TestWebPay()
        {
            _order.OutTradeNo = _outTradeNo;
            _unionGateway.Order = _order;
            _unionGateway.InitFormPayment();

            string result = HttpUtil.Post(_unionGateway.GatewayUrl, _unionGateway.GatewayData.ToUrl());

            Assert.Contains("Gateway-Response", result);
            _output.WriteLine(result);
        }

        [Fact]
        public void TestAppPay()
        {
            _order.OutTradeNo = _outTradeNo;
            _unionGateway.Order = _order;
            string tn = _unionGateway.BuildAppPayment();

            Assert.NotNull(tn);
            _output.WriteLine(tn);
        }

        [Fact]
        public void TestScanPay()
        {
            _order.OutTradeNo = _outTradeNo;
            _unionGateway.Order = _order;
            string result = _unionGateway.BuildScanPayment();

            Assert.Contains("http", result);
            _output.WriteLine(result);
        }

        [Fact]
        public void TestBarcodePay()
        {
            _order.OutTradeNo = _outTradeNo;
            _order.QrNo = "6221662493284300242";
            _unionGateway.Order = _order;

            Assert.Throws<GatewayException>(() =>
            {
                _unionGateway.BuildBarcodePayment();
            });
        }

        [Fact]
        public void TestQuery()
        {
            Assert.Throws<GatewayException>(() =>
            {
                _unionGateway.BuildQuery(new Auxiliary
                {
                    OutTradeNo = _outTradeNo,
                    TxnTime = _outTradeNo
                });
            });
        }

        [Fact]
        public void TestCancel()
        {
            Assert.Throws<GatewayException>(() =>
            {
                _unionGateway.BuildCancel(new Auxiliary
                {
                    OutTradeNo = _outTradeNo,
                    TxnTime = _outTradeNo
                });
            });
        }

        [Fact]
        public void TestRefund()
        {
            Assert.Throws<GatewayException>(() =>
            {
                _unionGateway.BuildCancel(new Auxiliary
                {
                    OutRefundNo = _outTradeNo,
                    TxnTime = _outTradeNo,
                    TradeNo = _outTradeNo,
                    RefundAmount = 0.01
                });
            });
        }

        [Fact]
        public void TestBillDownload()
        {
            //特殊处理
            _unionGateway.Merchant.AppId = "700000000000001";
            var fileStream = _unionGateway.BuildBillDownload(new Auxiliary
            {
                BillDate = "0119",
                TxnTime = _outTradeNo
            });

            Assert.True(fileStream.Length > 0);
        }
    }
}
