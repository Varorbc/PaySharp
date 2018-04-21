using PaySharp.Core;
using PaySharp.Core.Request;
using PaySharp.Core.Response;

namespace PaySharp.Unionpay.Response
{
    public abstract class BaseResponse : IResponse
    {
        /// <summary>
        /// 签名
        /// </summary>
        [ReName(Name = "signature")]
        public string Sign { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        [ReName(Name = "signMethod")]
        public string SignType { get; set; }

        /// <summary>
        /// 应答码
        /// </summary>
        public string RespCode { get; set; }

        /// <summary>
        /// 应答信息
        /// </summary>
        public string RespMsg { get; set; }

        /// <summary>
        /// 签名公钥证书
        /// </summary>
        public string SignPubKeyCert { get; set; }

        /// <summary>
        ///版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 编码方式
        /// </summary>
        public string Encoding { get; set; }

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
        /// 订单发送时间
        /// </summary>
        public string TxnTime { get; set; }

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
        /// 接入类型	
        /// 0：商户直连接入
        /// 1：收单机构接入
        /// 2：平台商户接入
        /// </summary>
        public int AccessType { get; set; }

        /// <summary>
        /// 商户自定义保留域，交易应答时会原样返回
        /// </summary>
        public string ReqReserved { get; set; }

        /// <summary>
        /// 商户代码,即merId
        /// </summary>
        [ReName(Name = "merId")]
        public string AppId { get; set; }

        /// <summary>
        /// 商户订单号，不应含“-”或“_”
        /// </summary>
        [ReName(Name = "orderId")]
        public string OutTradeNo { get; set; }

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
        /// 原始值
        /// </summary>
        public string Raw { get; set; }

        internal abstract void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request) where TResponse : IResponse;
    }
}
