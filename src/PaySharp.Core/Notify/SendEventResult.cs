namespace PaySharp.Core
{
    public class SendEventResult
    {
        private BaseGateway Gateway { get; }
        public bool Success { get; }
        public SendEventResult(BaseGateway gateway,bool success)
        {
            Gateway = gateway;
            Success = success;
        }

        #region Overrides of Object
        /// <summary>
        /// 获取当前处理结果的XML
        /// </summary>
        /// <returns></returns>
        public string GetFlagXml()
        {
            return Success ? Gateway.GetSuccessFlag() : Gateway.GetFailureFlag();
        }

        #endregion
        /// <summary>
        /// 立即响应处理结果的XML，并结束请求
        /// </summary>
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
