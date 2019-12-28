using System.Threading.Tasks;
using PaySharp.Allinpay.Enum;
using PaySharp.Allinpay.Request;
using PaySharp.Core;
using PaySharp.Core.Request;

namespace PaySharp.Allinpay.Response
{
    public class BarcodePayResponse : BaseResponse
    {
        /// <summary>
        /// 支付平台用户标识
        /// </summary>
        [ReName(Name = "acct")]
        public string UserId { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        [ReName(Name = "trxcode")]
        public TradeType TradeType { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        [ReName(Name = "initamt")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// 结算金额
        /// </summary>
        [ReName(Name = "trxamt")]
        public int SettleAmount { get; set; }

        /// <summary>
        /// 手续费金额
        /// </summary>
        [ReName(Name = "fee")]
        public int Poundage { get; set; }

        /// <summary>
        /// 渠道子商户号
        /// </summary>
        [ReName(Name = "cmid")]
        public string ChannelMchId { get; set; }

        /// <summary>
        /// 渠道号
        /// </summary>
        [ReName(Name = "chnlid")]
        public string ChannelId { get; set; }

        private Merchant _merchant;

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
            _merchant = merchant;
            var barcodePayRequest = request as BarcodePayRequest;

            if (TradeStatus == "SUCCESS")
            {
                barcodePayRequest.OnPaySucceed(this, null);
                return;
            }

            if (TradeStatus == "2000")
            {
                //var queryResponse = new QueryResponse();
                //Task.Run(async () =>
                //{
                //    queryResponse = await PollQueryTradeStateAsync(
                //        barcodePayRequest.Model.OutTradeNo,
                //        barcodePayRequest.PollTime,
                //        barcodePayRequest.PollCount);
                //})
                //.GetAwaiter()
                //.GetResult();

                //if (queryResponse != null)
                //{
                //    barcodePayRequest.OnPaySucceed(queryResponse, null);
                //    return;
                //}
                //else
                //{
                //    barcodePayRequest.OnPayFailed(this, "支付超时");
                //    return;
                //}
            }

            barcodePayRequest.OnPayFailed(this, ErrMsg);
        }

        ///// <summary>
        ///// 轮询查询用户是否支付
        ///// </summary>
        ///// <param name="outTradeNo">订单号</param>
        ///// <param name="pollTime">轮询间隔</param>
        ///// <param name="pollCount">轮询次数</param>
        ///// <returns></returns>
        //private QueryResponse PollQueryTradeState(string outTradeNo, int pollTime, int pollCount)
        //{
        //    for (var i = 0; i < pollCount; i++)
        //    {
        //        var queryRequest = new QueryRequest();
        //        queryRequest.AddGatewayData(new QueryModel
        //        {
        //            OutTradeNo = outTradeNo
        //        });
        //        var queryResponse = SubmitProcess.Execute(_merchant, queryRequest);
        //        if (queryResponse.TradeState == "SUCCESS")
        //        {
        //            return queryResponse;
        //        }

        //        Thread.Sleep(pollTime);
        //    }

        //    //支付超时，取消订单
        //    var cancelRequest = new CancelRequest();
        //    cancelRequest.AddGatewayData(new CancelModel
        //    {
        //        OutTradeNo = outTradeNo
        //    });
        //    SubmitProcess.Execute(_merchant, cancelRequest);

        //    return null;
        //}

        ///// <summary>
        ///// 轮询查询用户是否支付
        ///// </summary>
        ///// <param name="outTradeNo">订单号</param>
        ///// <param name="pollTime">轮询间隔</param>
        ///// <param name="pollCount">轮询次数</param>
        ///// <returns></returns>
        //private async Task<QueryResponse> PollQueryTradeStateAsync(string outTradeNo, int pollTime, int pollCount)
        //{
        //    return await Task.Run(() => PollQueryTradeState(outTradeNo, pollTime, pollCount));
        //}
    }
}
