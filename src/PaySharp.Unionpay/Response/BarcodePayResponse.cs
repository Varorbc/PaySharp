using System.Threading;
using System.Threading.Tasks;
using PaySharp.Core.Request;
using PaySharp.Unionpay.Domain;
using PaySharp.Unionpay.Request;

namespace PaySharp.Unionpay.Response
{
    public class BarcodePayResponse : BaseResponse
    {
        /// <summary>
        /// 查询流水号	
        /// </summary>
        public string QueryId { get; set; }

        private Merchant _merchant;

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
            _merchant = merchant;
            var barcodePayRequest = request as BarcodePayRequest;

            if (RespCode == "00")
            {
                barcodePayRequest.OnPaySucceed(this, null);
                return;
            }

            if (RespCode == "05")
            {
                var queryResponse = new QueryResponse();
                Task.Run(async () =>
                {
                    queryResponse = await PollQueryTradeStateAsync(
                        barcodePayRequest.Model.OrderId,
                        barcodePayRequest.PollTime,
                        barcodePayRequest.PollCount);
                })
                .GetAwaiter()
                .GetResult();

                if (queryResponse != null)
                {
                    barcodePayRequest.OnPaySucceed(queryResponse, null);
                    return;
                }
                else
                {
                    barcodePayRequest.OnPayFailed(this, "支付超时");
                    return;
                }
            }

            barcodePayRequest.OnPayFailed(this, RespMsg);
        }

        /// <summary>
        /// 轮询查询用户是否支付
        /// </summary>
        /// <param name="outTradeNo">订单号</param>
        /// <param name="pollTime">轮询间隔</param>
        /// <param name="pollCount">轮询次数</param>
        /// <returns></returns>
        private QueryResponse PollQueryTradeState(string outTradeNo, int pollTime, int pollCount)
        {
            for (var i = 0; i < pollCount; i++)
            {
                var queryRequest = new QueryRequest();
                queryRequest.AddGatewayData(new QueryModel
                {
                    OrderId = outTradeNo
                });
                var queryResponse = SubmitProcess.Execute(_merchant, queryRequest);
                if (queryResponse.RespCode == "00")
                {
                    return queryResponse;
                }

                Thread.Sleep(pollTime);
            }

            //支付超时，取消订单
            var cancelRequest = new CancelRequest();
            cancelRequest.AddGatewayData(new CancelModel
            {
                OrderId = outTradeNo
            });
            SubmitProcess.Execute(_merchant, cancelRequest);

            return null;
        }

        /// <summary>
        /// 轮询查询用户是否支付
        /// </summary>
        /// <param name="outTradeNo">订单号</param>
        /// <param name="pollTime">轮询间隔</param>
        /// <param name="pollCount">轮询次数</param>
        /// <returns></returns>
        private async Task<QueryResponse> PollQueryTradeStateAsync(string outTradeNo, int pollTime, int pollCount)
        {
            return await Task.Run(() => PollQueryTradeState(outTradeNo, pollTime, pollCount));
        }
    }
}
