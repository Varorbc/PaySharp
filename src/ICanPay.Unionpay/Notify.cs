using ICanPay.Core;

namespace ICanPay.Unionpay
{
    public class Notify : INotify
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Encoding { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        [ReName(Name = Constant.SIGNMETHOD)]
        public string SignType { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [ReName(Name = Constant.SIGNATURE)]
        public string Sign { get; set; }

        /// <summary>
        /// 接入类型	
        /// 0：商户直连接入1：收单机构接入 2：平台商户接入
        /// </summary>
        public int AccessType { get; set; }

        /// <summary>
        /// 商户代码,即merId
        /// </summary>
        [ReName(Name = Constant.MERID)]
        public string AppId { get; set; }

        /// <summary>
        /// 签名公钥 证书	
        /// </summary>
        public string SignPubKeyCert { get; set; }

        /// <summary>
        /// 交易类型
        ///00：查询交易，
        ///01：消费，
        ///02：预授权，
        ///03：预授权完成，
        ///04：退货，
        ///05：圈存，
        ///11：代收，
        ///12：代付，
        ///13：账单支付，
        ///14：转账（保留），
        ///21：批量交易，
        ///22：批量查询，
        ///31：消费撤销，
        ///32：预授权撤销，
        ///33：预授权完成撤销，
        ///71：余额查询，
        ///72：实名认证-建立绑定关系，
        ///73：账单查询，
        ///74：解除绑定关系，
        ///75：查询绑定关系，
        ///77：发送短信验证码交易，
        ///78：开通查询交易，
        ///79：开通交易，
        ///94：IC卡脚本通知 
        ///95：查询更新加密公钥证书
        /// </summary>
        public string TxnType { get; set; }

        /// <summary>
        /// 交易子类
        /// </summary>
        public string TxnSubType { get; set; }

        /// <summary>
        /// 产品类型
        /// 000201：B2C 网关支付 
        /// 000301：认证支付 2.0 
        /// 000302：评级支付 
        /// 000401：代付 
        /// 000501：代收
        /// 000601：账单支付 
        /// 000801：跨行收单
        /// 000901：绑定支付
        /// 001001：订购
        /// 000202：B2B
        /// </summary>
        public string BizType { get; set; }

        /// <summary>
        /// 商户订单号，不应含“-”或“_”
        /// </summary>
        [ReName(Name = Constant.ORDERID)]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 交易金额,单位元
        /// </summary>
        [ReName(Name = Constant.TXNAMT)]
        public double Amount
        {
            get => _amount;
            set => _amount = value * 100;
        }
        private double _amount;

        /// <summary>
        /// 交易币种,默认156
        /// </summary>
        public int CurrencyCode { get; set; }

        /// <summary>
        /// 订单发送时间
        /// </summary>
        public string TxnTime { get; set; }

        /// <summary>
        /// 支付方式
        /// 默认不返回此域，如需要返此域，需要提交申请，视商户配置返回，可在消费类交易中返回以下中的一种：
        /// 0001：认证支付 
        /// 0002：快捷支付 
        /// 0004：储值卡支付 
        /// 0005：IC卡支付 
        /// 0201：网银支付 
        /// 1001：牡丹畅通卡支付 
        /// 1002：中铁银通卡支付 
        /// 0401：信用卡支付——暂定 
        /// 0402：小额临时支付 
        /// 0403：认证支付 2.0 
        /// 0404：互联网订单手机支付 
        /// 9000：其他无卡支付(如手机客户端支付)
        /// </summary>
        public string PayType { get; set; }

        /// <summary>
        /// 交易账号。请求时使用加密公钥对交易账号加密，并做 Base64 编码后上送；
        /// 应答时如需返回，则使用签名私钥 进行解密。 
        /// 前台交易可由银联页面采集，也可由商户上送并返显。 
        /// 如需锁定返显卡号，应通过保留域（reserved）上送卡 号锁定标识。
        /// </summary>
        public string AccNo { get; set; }

        /// <summary>
        /// 支付卡类型	
        /// 消费交易，视商户配置返回。该域取值为： 
        /// 00：未知
        /// 01：借记账户
        /// 02：贷记账户 
        /// 03：准贷记账户 
        /// 04：借贷合一账户 
        /// 05：预付费账户 
        /// 06：半开放预付费账户
        /// </summary>
        public string PayCardType { get; set; }

        /// <summary>
        /// 商户自定义保留域，交易应答时会原样返回
        /// </summary>
        public string ReqReserved { get; set; }

        /// <summary>
        /// 保留域
        /// 1.保留域包含多个子域，所有子域需用“{}”包含，子域间以“&”符号链接。
        /// 格式如下：{子域名1=值&子域名2=值&子域名3=值}。 
        /// 2.应答报文中出现保留域，base64后的{子域名1=值&子域名2=值&子域名3=值} 
        /// 例如注14中，立减金额为100，收到的报文格式为reserved=e2Rpc2NvdW50QW10PTEwMH0=，
        /// 即base64后的{discountAmt=100}。
        /// </summary>
        public string Reserved { get; set; }

        /// <summary>
        /// 查询流水号
        /// </summary>
        public string QueryId { get; set; }

        /// <summary>
        /// 系统跟踪号
        /// </summary>
        public string TraceNo { get; set; }

        /// <summary>
        /// 交易传输时间（月月日日时时分分秒秒）
        /// </summary>
        public string TraceTime { get; set; }

        /// <summary>
        /// 清算日期	（月月日日）
        /// </summary>
        public string SettleDate { get; set; }

        /// <summary>
        /// 清算币种
        /// </summary>
        public string SettleCurrencyCode { get; set; }

        /// <summary>
        /// 清算金额
        /// </summary>
        public string SettleAmt { get; set; }

        /// <summary>
        /// 应答码
        /// </summary>
        public string RespCode { get; set; }

        /// <summary>
        /// 应答信息
        /// </summary>
        public string RespMsg { get; set; }

        /// <summary>
        /// 银联受理订单号
        /// </summary>
        public string Tn { get; set; }

        /// <summary>
        /// 支付卡标识
        /// </summary>
        public string PayCardNo { get; set; }

        /// <summary>
        /// 支付卡名称
        /// </summary>
        public string PayCardIssueName { get; set; }

        /// <summary>
        /// 清算汇率
        /// </summary>
        public string ExchangeRate { get; set; }

        /// <summary>
        /// 兑换日期
        /// </summary>
        public string ExchangeDate { get; set; }

        /// <summary>
        /// 绑定关系标识号
        /// 适用于代收类绑定产品，字母不区分大小写，
        /// 用法：在绑定后支付时客户仅需要上送本字段，无需上送卡号,不支持换行符等不可见字符 用于唯一标识绑定关系
        /// </summary>
        public string BindId { get; set; }

        /// <summary>
        /// 发卡机构代码
        /// </summary>
        public string IssInsNo { get; set; }

        /// <summary>
        /// 接入机构代码
        /// </summary>
        public string AccInsCode { get; set; }

        /// <summary>
        /// 二维码
        /// </summary>
        public string QrCode { get; set; }

        /// <summary>
        /// 发卡机构识别模式
        /// </summary>
        public string IssuerIdentifyMode { get; set; }

        /// <summary>
        /// 原交易应答码
        /// </summary>
        public string OrigRespCode { get; set; }

        /// <summary>
        /// 原交易应答信息
        /// </summary>
        public string OrigRespMsg { get; set; }
    }
}
