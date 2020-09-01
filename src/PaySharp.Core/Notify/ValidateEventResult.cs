namespace PaySharp.Core
{
    public class ValidateEventResult
    {
        private BaseGateway Gateway { get; }
        public bool Success { get; }
        public ValidateEventResult(BaseGateway gateway,bool success)
        {
            Gateway = gateway;
            Success = success;
        }

        #region Overrides of Object

        /// <summary>返回表示当前对象的字符串。</summary>
        /// <returns>表示当前对象的字符串。</returns>
        public string GetFlagXml()
        {
            return Success ? Gateway.GetSuccessFlag() : Gateway.GetFailureFlag();
        }

        #endregion

        public void WriteFlagXml()
        {
            if (Success)
            {
                Gateway.WriteSuccessFlag();
            }
            else
            {
                Gateway.WriteFailureFlag();
            }
        }
    }
}
