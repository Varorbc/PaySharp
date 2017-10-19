※说明※

本demo仅仅为学习参考使用，请根据实际情况自行开发，把功能嵌入您的项目或平台中。

※Demo运行环境※

.net 2010及以上

※业务处理注意事项※

请配置notify_url文件、return_url文件，其中，notify_url文件主要是写入业务处理逻辑代码，请结合自身情况谨慎编写。

如何验证异步通知数据？

1、商户需要验证该通知数据中的out_trade_no是否为商户系统中创建的订单号

2、判断total_amount是否确实为该订单的实际金额（即商户订单创建时的金额）

3、校验通知中的seller_id（或者seller_email) 是否为该笔交易对应的操作方（一个商户可能有多个seller_id/seller_email）

4、验证接口调用方的app_id
