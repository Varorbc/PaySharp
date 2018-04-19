using ICanPay.Core;
using Org.BouncyCastle.Crypto;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Unionpay
{
    public class Merchant : IMerchant
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version => "5.1.0";

        /// <summary>
        /// 编码
        /// </summary>
        public string Encoding => "UTF-8";

        /// <summary>
        /// 证书号
        /// </summary>
        public string CertId { get; internal set; }

        /// <summary>
        /// 加密证书号
        /// </summary>
        public string EncryptCertId { get; internal set; }

        /// <summary>
        /// 证书私钥
        /// </summary>
        [Ignore]
        internal AsymmetricKeyParameter CertKey { get; set; }

        /// <summary>
        /// 签名类型
        /// 01（表示采用 RSA 签名）
        /// </summary>
        [ReName(Name = Constant.SIGNMETHOD)]
        public string SignType => "01";

        /// <summary>
        /// 接入类型	
        /// 0：商户直连接入1：收单机构接入 2：平台商户接入
        /// </summary>
        public int AccessType => 0;

        /// <summary>
        /// 商户代码,即merId
        /// </summary>
        [ReName(Name = Constant.MERID)]
        [Required(ErrorMessage = "请设置商户代码")]
        [StringLength(15, ErrorMessage = "通商户代码最大长度为256位")]
        public string AppId { get; set; }

        /// <summary>
        /// 后台返回商户结果时使用，
        /// 如上送，则发送商户后台交 易结果通知，不支持换行符等不可见字符，
        /// 如需通过专 线通知，需要在通知地址前面加上前缀：专线的首字母 加竖线 ZX|
        /// </summary>
        [ReName(Name = Constant.BACKURL)]
        [Required(ErrorMessage = "请设置通知地址")]
        [StringLength(256, ErrorMessage = "通知地址最大长度为256位")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 前台返回商户结果时使用，前台类交易需上送 不支持换行符等不可见字符
        /// </summary>
        [StringLength(256, ErrorMessage = "前台成功返回地址最大长度为256位")]
        [Necessary(GatewayTradeType.Web)]
        public string FrontUrl { get; set; }

        /// <summary>
        /// 前台消费交易若商户上送此字段，
        /// 则在支付失败时，页面跳转至商户该URL（不带交易信息，仅跳转），支持HTTP与HTTPS协议，互联网可访问
        /// </summary>
        [StringLength(256, ErrorMessage = "前台失败返回地址最大长度为256位")]
        public string FrontFailUrl { get; set; }

        /// <summary>
        /// 签名证书路径
        /// </summary>
        [Ignore]
        [Required(ErrorMessage = "请设置签名证书路径")]
        public string CertPath { get; set; }

        /// <summary>
        /// 签名证书密码
        /// </summary>
        [Ignore]
        [Required(ErrorMessage = "请设置签名证书密码")]
        public string CertPwd { get; set; }

        /// <summary>
        /// 验证证书目录
        /// </summary>
        [Ignore]
        public string ValidateCertDir { get; set; }

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
        public string TxnType { get; internal set; } = "01";

        /// <summary>
        /// 交易子类
        /// </summary>
        public string TxnSubType { get; internal set; } = "01";

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
        public string BizType { get; internal set; } = "000201";

        /// <summary>
        /// 渠道类型
        /// </summary>
        public string ChannelType { get; internal set; } = "08";
    }
}
