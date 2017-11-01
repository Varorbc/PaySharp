# ICanPay介绍
---

ICanPay是一个提供了多个支付网关支付处理的跨平台类库，使用ICanPay可以简化订单的创建、查询、退款和接收网关返回的支付通知等操作。

目前支持的支付网关有：支付宝(Alipay)、微信支付(Wechatpay)

支付宝：
		支持的支付方式：
		
			移动支付(App)、手机网站支付(Wap)、电脑网站支付(Web)、小程序支付(Applet)、条码支付(Barcode)、扫码支付(Scan)
			
		支持的辅助接口：
		
			查询、退款、退款查询、撤销、关闭、对账单下载
		
微信：

		支持的支付方式：
		
			移动支付(App)、手机网站支付(Wap)、公众号支付(Web)、小程序支付(Applet)、条码支付(Barcode)、扫码支付(Scan)

		支持的辅助接口：
		
			查询、退款、退款查询、撤销、关闭、对账单下载

# Package
---

Package  | NuGet 
-------- | :------------ 
ICanPay.Core		| [![NuGet](https://img.shields.io/nuget/v/ICanPay.Core.svg)](https://www.nuget.org/packages/ICanPay.Core)
ICanPay.Alipay		| [![NuGet](https://img.shields.io/nuget/v/ICanPay.Alipay.svg)](https://www.nuget.org/packages/ICanPay.Alipay)
ICanPay.Wechatpay	| [![NuGet](https://img.shields.io/nuget/v/ICanPay.Wechatpay.svg)](https://www.nuget.org/packages/ICanPay.Wechatpay)

# 如何使用

首先在Startup文件中添加如下方法：

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddICanPay(a =>
			{
				var gateways = new Gateways();

				// 设置商户数据
				var alipayMerchant = new Alipay.Merchant
				{
					AppId = "2017093009005992",
					NotifyUrl = "http://localhost:61337/Notify",
					ReturnUrl = "http://localhost:61337/Return",
					AlipayPublicKey = "Varorbc",
					Privatekey = "Varorbc"
				};

				var wechatpayMerchant = new Wechatpay.Merchant
				{
					AppId = "wx2428e34e0e7dc6ef",
					MchId = "1233410002",
					Key = "e10adc3849ba56abbe56e056f20f883e",
					AppSecret = "51c56b886b5be869567dd389b3e5d1d6",
					SslCertPath = "Certs/apiclient_cert.p12",
					SslCertPassword = "1233410002",
					NotifyUrl = "http://localhost:61337/Notify"
				};

				gateways.Add(new AlipayGateway(alipayMerchant));
				gateways.Add(new WechatpayGataway(wechatpayMerchant));

				return gateways;
			});
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseICanPay();
		}
    
然后创建支付控制类：

		using ICanPay.Alipay;
		using ICanPay.Core;
		using Microsoft.AspNetCore.Mvc;

		namespace ICanPay.Demo.Controllers
		{
			public class PaymentController : Controller
			{
				private IGateways gateways;
				public PaymentController(IGateways gateways)
				{
					this.gateways = gateways;
				}

				public IActionResult Index()
				{
					string content = CreateAlipayOrder();

					return Content(content);
				}

				/// <summary>
				/// 创建支付宝的支付订单
				/// </summary>
				private string CreateAlipayOrder()
				{
					var order = new Order()
					{
						Amount = 0.01,
						OutTradeNo = "35",
						Subject = "测测看支付宝",
						Body = "1234",
						ExtendParams = new ExtendParam()
						{
							HbFqNum = "3"
						},
						GoodsDetail = new Goods[] {
							new Goods()
							{
								Id = "12"
							}
						}
					};

					var gateway = gateways.Get(GatewayType.Alipay, GatewayTradeType.Web);

					return gateway.Payment(order);
				}
			}
		}

再创建通知控制类：

        using ICanPay.Core;
		using Microsoft.AspNetCore.Mvc;
		using System.Threading.Tasks;

		namespace ICanPay.Demo.Controllers
		{
			public class NotifyController : Controller
			{
				private IGateways gateways;
				public NotifyController(IGateways gateways)
				{
					this.gateways = gateways;
				}

				public async Task Index()
				{
					// 订阅支付通知事件
					PaymentNotify notify = new PaymentNotify(gateways);
					notify.PaymentSucceed += Notify_PaymentSucceed;
					notify.PaymentFailed += Notify_PaymentFailed;
					notify.UnknownGateway += Notify_UnknownGateway;

					// 接收并处理支付通知
					await notify.ReceivedAsync();
				}

				private void Notify_PaymentSucceed(object sender, PaymentSucceedEventArgs e)
				{
					// 支付成功时时的处理代码
					if (e.GatewayType == GatewayType.Alipay)
					{
						var alipayNotify = (Alipay.Notify)e.Notify;
					}
				}

				private void Notify_PaymentFailed(object sender, PaymentFailedEventArgs e)
				{
					// 支付失败时的处理代码
				}

				private void Notify_UnknownGateway(object sender, UnknownGatewayEventArgs e)
				{
					// 无法识别支付网关时的处理代码
				}
			}
		}

# Wiki
---

支付宝支付文档：

https://docs.open.alipay.com/203/105288/

https://docs.open.alipay.com/204/105051/

https://docs.open.alipay.com/270/105898/

https://docs.open.alipay.com/api_1/alipay.trade.pay

https://docs.open.alipay.com/api_1/alipay.trade.precreate

微信支付文档：

https://pay.weixin.qq.com/wiki/doc/api/index.html

# 致谢

[hiihellox10](https://github.com/hiihellox10)
