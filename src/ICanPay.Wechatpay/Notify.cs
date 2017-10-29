using ICanPay.Core;
using System.ComponentModel.DataAnnotations;

namespace ICanPay.Wechatpay
{
    public class Notify : INotify
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 业务结果
        /// </summary>
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误代码描述
        /// </summary>
        public string ErrCodeDes { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { get; set; }

        /// <summary>
        /// 微信生成的预支付回话标识，用于后续接口调用中使用，该值有效期为2小时
        /// </summary>
        public string PrepayId { get; set; }

        /// <summary>
        /// 返回状态码
        /// </summary>
        public string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 支付跳转链接
        /// mweb_url为拉起微信支付收银台的中间页面，可通过访问该url来拉起微信客户端，完成支付,mweb_url的有效期为5分钟。
        /// </summary>
        public string MWebUrl { get; set; }

        /// <summary>
        /// 二维码链接
        /// trade_type为NATIVE时有返回，用于生成二维码，展示给用户进行扫码支付
        /// </summary>
        public string CodeUrl { get; set; }

        /// <summary>
        /// 用户标识
        /// 用户在商户appid 下的唯一标识
        /// </summary>
        [ReName(Name = Constant.OPENID)]
        public string OpenId { get; set; }

        /// <summary>
        /// 是否关注公众账号
        /// 仅在公众账号类型支付有效，取值范围：Y或N;Y-关注;N-未关注
        /// </summary>
        public string IsSubscribe { get; set; }

        /// <summary>
        /// 银行类型，采用字符串类型的银行标识，详见银行类型
        /// </summary>
        public string BankType { get; set; }

        /// <summary>
        /// 应结订单金额
        /// 当订单使用了免充值型优惠券后返回该参数，应结订单金额=订单金额-免充值优惠券金额。
        /// </summary>
        public double SettlementTotalFee { get; set; }

        /// <summary>
        /// 代金券金额
        /// “代金券”金额小于等于订单金额，订单金额-“代金券”金额=现金支付金额，详见支付金额
        /// </summary>
        public double CouponFee { get; set; }

        /// <summary>
        /// 代金券使用数量
        /// </summary>
        public int CouponCount { get; set; }

        /// <summary>
        /// 货币类型
        /// 符合ISO 4217标准的三位字母代码，默认人民币：CNY，详见货币类型
        /// </summary>
        public string FeeType { get; set; }

        /// <summary>
        /// 订单金额
        /// 订单总金额，单位为元
        /// </summary>
        public double TotalFee { get; set; }

        /// <summary>
        /// 现金支付货币类型
        /// 符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        public string CashFeeType { get; set; }

        /// <summary>
        /// 现金支付金额
        /// 订单现金支付金额，详见支付金额
        /// </summary>
        public double CashFee { get; set; }

        /// <summary>
        /// 微信支付订单号
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商家数据包
        /// </summary>
        public string Attach { get; set; }

        /// <summary>
        /// 支付完成时间
        /// </summary>
        public string TimeEnd { get; set; }

        /// <summary>
        /// 营销详情
        /// 新增返回，单品优惠功能字段，需要接入请见详细说明
        /// </summary>
        public string PromotionDetail { get; set; }

        /// <summary>
        /// 交易状态描述
        /// 对当前查询订单状态的描述和下一步操作的指引
        /// </summary>
        public string TradeStateDesc { get; set; }

        /// <summary>
        /// 交易状态
        /// SUCCESS—支付成功
        /// REFUND—转入退款
        /// NOTPAY—未支付
        /// CLOSED—已关闭
        /// REVOKED—已撤销（刷卡支付）
        /// USERPAYING--用户支付中
        /// PAYERROR--支付失败(其他原因，如银行返回失败)
        /// 支付状态机请见下单API页面
        /// </summary>
        public string TradeState { get; set; }

        /// <summary>
        /// 是否重调
        /// 是否需要继续调用撤销，Y-需要，N-不需要
        /// </summary>
        public string Recall { get; set; }
    }
}
