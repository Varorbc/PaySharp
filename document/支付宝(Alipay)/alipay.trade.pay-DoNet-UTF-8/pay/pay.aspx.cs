using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Response;
using System;

namespace alipay.pay
{
    public partial class pay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DefaultAopClient client = new DefaultAopClient(config.gatewayUrl, config.app_id, config.private_key, "json", "1.0", config.sign_type, config.alipay_public_key, config.charset, false);
            AlipayTradePayRequest request = new AlipayTradePayRequest();
            request.BizContent = "{" +
            "\"out_trade_no\":\"20150320010101001\"," +
            "\"scene\":\"bar_code\"," +
            "\"auth_code\":\"28763443825664394\"," +
            "\"product_code\":\"FACE_TO_FACE_PAYMENT\"," +
            "\"subject\":\"Iphone616G\"," +
            "\"buyer_id\":\"2088202954065786\"," +
            "\"seller_id\":\"2088102146225135\"," +
            "\"total_amount\":88.88," +
            "\"discountable_amount\":8.88," +
            "\"body\":\"Iphone616G\"," +
            "\"goods_detail\":[{" +
            "\"goods_id\":\"apple-01\"," +
            "\"goods_name\":\"ipad\"," +
            "\"quantity\":1," +
            "\"price\":2000," +
            "\"goods_category\":\"34543238\"," +
            "\"body\":\"特价手机\"," +
            "\"show_url\":\"http://www.alipay.com/xxx.jpg\"" +
            "}]," +
            "\"operator_id\":\"yx_001\"," +
            "\"store_id\":\"NJ_001\"," +
            "\"terminal_id\":\"NJ_T_001\"," +
            "\"extend_params\":{" +
            "\"sys_service_provider_id\":\"2088511833207846\"" +
            "}," +
            "\"timeout_express\":\"90m\"" +
            "}";

            AlipayTradePayResponse response = client.Execute(request);
            Response.Write(response.Body);
        }
    }
}