using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ICanPay.Core
{
    /// <summary>
    /// 必要验证属性
    /// </summary>
    public class NecessaryAttribute : ValidationAttribute
    {
        private const GatewayAuxiliaryType AllGatewayAuxiliaryType = (GatewayAuxiliaryType)100;
        private const GatewayTradeType AllGatewayTradeType = (GatewayTradeType)100;
        private readonly GatewayAuxiliaryType[] gatewayAuxiliaryType = { AllGatewayAuxiliaryType };
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

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gatewayAuxiliaryType">网关辅助类型</param>
        public NecessaryAttribute(GatewayAuxiliaryType gatewayAuxiliaryType)
        {
            this.gatewayAuxiliaryType = new GatewayAuxiliaryType[] { gatewayAuxiliaryType };
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gatewayAuxiliaryType">网关辅助类型</param>
        public NecessaryAttribute(params GatewayAuxiliaryType[] gatewayAuxiliaryType)
        {
            this.gatewayAuxiliaryType = gatewayAuxiliaryType;
        }

        #endregion

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            validationContext.Items.TryGetValue(nameof(GatewayAuxiliaryType), out object obj);
            var currentGatewayAuxiliaryType = (GatewayAuxiliaryType)obj;
            validationContext.Items.TryGetValue(nameof(GatewayTradeType), out obj);
            var currentGatewayTradeType = (GatewayTradeType)obj;

            if (currentGatewayAuxiliaryType == 0)
            {
                if (gatewayTradeType.Contains(currentGatewayTradeType) || gatewayTradeType.Contains(AllGatewayTradeType))
                {
                    if (value is null || string.IsNullOrEmpty(value.ToString()))
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }
            }
            else
            {
                if (gatewayAuxiliaryType.Contains(currentGatewayAuxiliaryType) || gatewayAuxiliaryType.Contains(AllGatewayAuxiliaryType))
                {
                    if (value is null || string.IsNullOrEmpty(value.ToString()))
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }

            }

            return ValidationResult.Success;
        }
    }
}
