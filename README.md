# PaySharp介绍
---

PaySharp是一个支持多商户多种支付方式的跨平台网关处理类库，使用PaySharp可以简化订单的创建、查询、退款和接收网关返回的支付通知等操作。

目前支持的支付网关有：支付宝(Alipay)、微信支付(Wechatpay)、银联支付(Unionpay)

### 1.支付宝：

##### 支持的支付方式：

	移动支付(App)、手机网站支付(Wap)、电脑网站支付(Web)、小程序支付(Applet)、条码支付(Barcode)、扫码支付(Scan)、
	
	转账(Transfer)、转账查询(TransferQuery)

##### 支持的辅助接口：

	查询、退款、退款查询、撤销、关闭、对账单下载

### 2.微信：

##### 支持的支付方式：
		
	移动支付(App)、手机网站支付(Wap)、公众号支付(Public)、小程序支付(Applet)、条码支付(Barcode)、扫码支付(Scan)、
	
	转账(Transfer)、转账查询(TransferQuery)、转账到银行卡(TransferToBank)、转账到银行卡查询(TransferToBank)Query)

##### 支持的辅助接口：
		
	查询、退款、退款查询、撤销、关闭、对账单下载、资金账单下载
			
### 3.银联：

##### 支持的支付方式：
		
	移动支付(App)、手机网站支付(Wap)、电脑网站支付(Web)、条码支付(Barcode)、扫码支付(Scan)

##### 支持的辅助接口：
		
	查询、退款、撤销、对账单下载

# Package
---

Package  | NuGet 
-------- | :------------ 
PaySharp.Core		| [![NuGet](https://img.shields.io/nuget/v/PaySharp.Core.svg)](https://www.nuget.org/packages/PaySharp.Core)
PaySharp.Core.Mvc		| [![NuGet](https://img.shields.io/nuget/v/PaySharp.Core.Mvc.svg)](https://www.nuget.org/packages/PaySharp.Core.Mvc)
PaySharp.Alipay		| [![NuGet](https://img.shields.io/nuget/v/PaySharp.Alipay.svg)](https://www.nuget.org/packages/PaySharp.Alipay)
PaySharp.Wechatpay	| [![NuGet](https://img.shields.io/nuget/v/PaySharp.Wechatpay.svg)](https://www.nuget.org/packages/PaySharp.Wechatpay)
PaySharp.Unionpay	| [![NuGet](https://img.shields.io/nuget/v/PaySharp.Unionpay.svg)](https://www.nuget.org/packages/PaySharp.Unionpay)

# 开发环境
* Windows 10
* VS2017

# 如何使用
---

见[Wiki](https://github.com/Varorbc/PaySharp/wiki)

# 交流讨论
---

[![加入QQ群](http://pub.idqqimg.com/wpa/images/group.png)](http://shang.qq.com/wpa/qunwpa?idkey=5d2538328d53d0610188d9dc4a62a7b51e50fe56ad1b35ca9e96308507eb09a7)

# Wiki
---

支付宝支付文档：

https://openhome.alipay.com/developmentDocument.htm

微信支付文档：

https://pay.weixin.qq.com/wiki/doc/api/index.html

银联支付文档：

https://open.unionpay.com/ajweb/product

# 支持/打赏

<p align="center">
    <img src="https://github.com/Varorbc/PaySharp/blob/2.0.0-alpha/reward.jpg">
    <p align="center">打赏扫这里，请留下尊姓大名</p>
</p>

# 致谢
---

[hiihellox10](https://github.com/hiihellox10)

[John0King](https://github.com/John0King)

[stulzq](https://github.com/stulzq)

[EssenRoc](https://github.com/EssenRoc)
