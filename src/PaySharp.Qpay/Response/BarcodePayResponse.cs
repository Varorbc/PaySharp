using System.Threading;
using System.Threading.Tasks;
using PaySharp.Core.Request;
using PaySharp.Qpay.Domain;
using PaySharp.Qpay.Request;

namespace PaySharp.Qpay.Response
{
    public class BarcodePayResponse : QueryResponse
    {
        private Merchant _merchant;

        internal override void Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
            _merchant = merchant;
            var barcodePayRequest = request as BarcodePayRequest;

            if (ResultCode == "SUCCESS")
            {
                barcodePayRequest.OnPaySucceed(this, null);
                return;
            }

            if (ErrCode == "USERPAYING")
            {
                var queryResponse = new QueryResponse();
                Task.Run(async () =>
                {
                    queryResponse = await PollQueryTradeStateAsync(
                        barcodePayRequest.Model.OutTradeNo,
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

            barcodePayRequest.OnPayFailed(this, ErrCodeDes);
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
                    OutTradeNo = outTradeNo
                });
                var queryResponse = SubmitProcess.Execute(_merchant, queryRequest);
                if (queryResponse.TradeState == "SUCCESS")
                {
                    return queryResponse;
                }

                Thread.Sleep(pollTime);
            }

            //支付超时，取消订单
            var cancelRequest = new CancelRequest();
            cancelRequest.AddGatewayData(new CancelModel
            {
                OutTradeNo = outTradeNo
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
