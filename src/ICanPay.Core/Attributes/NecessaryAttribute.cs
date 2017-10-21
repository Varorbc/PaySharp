using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ICanPay.Core
{
    /// <summary>
    /// 必要验证属性
    /// </summary>
    public class NecessaryAttribute : ValidationAttribute
    {
        private const GatewayTradeType AllGatewayTradeType = (GatewayTradeType)100;
        private readonly GatewayTradeType[] gatewayTradeType = { AllGatewayTradeType };

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gatewayTradeType">网关交易类型</param>
        public NecessaryAttribute(GatewayTradeType gatewayTradeType)
        {
            this.gatewayTradeType = new GatewayTradeType[] { gatewayTradeType };
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gatewayTradeType">网关交易类型</param>
        public NecessaryAttribute(params GatewayTradeType[] gatewayTradeType)
        {
            this.gatewayTradeType = gatewayTradeType;
        }

        #endregion

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            validationContext.Items.TryGetValue("GatewayTradeType", out object obj);
            var currentGatewayTradeType = (GatewayTradeType)obj;

            if (gatewayTradeType.Contains(currentGatewayTradeType) || gatewayTradeType.Contains(AllGatewayTradeType))
            {
                if (value is null || string.IsNullOrEmpty(value.ToString()))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
