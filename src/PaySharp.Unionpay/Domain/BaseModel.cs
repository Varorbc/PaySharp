using System;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.Unionpay.Domain
{
    public class BaseModel
    {
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
        /// 订单发送时间
        /// </summary>
        public string TxnTime { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");

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
        /// 01：自助消费，通过地址的方式区分前台消费和后台消费（含无跳转支付）
        /// 03：分期付款
        /// 10：签约支付（协议号支付)
        /// </summary>
        [Required(ErrorMessage = "请设置交易子类")]
        public string TxnSubType { get; internal set; } = "01";
    }
}
