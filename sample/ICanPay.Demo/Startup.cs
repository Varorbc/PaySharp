using ICanPay.Alipay;
using ICanPay.Core;
using ICanPay.Wechatpay;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace ICanPay.Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddICanPay(a =>
            {
                var gateways = new List<GatewayBase>();

                // 设置商户数据
                var alipayMerchant = new Alipay.Merchant
                {
                    AppId = "2017093009005992",
                    NotifyUrl = "http://localhost:61337/Notify",
                    ReturnUrl = "http://localhost:61337/Return",
                    AlipayPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA9NT40P1EYDxWSiBWsPJh2/vdYPVDg3n+UALO6wXmeOHDY9un7F6M2/QBeceXbJuRxfXKpKRScugKcnz4Wh1KMWTk1kfjhoyDXHtZOFO/HFXJiK1xF1IZsxCFbyDo7GxLwhIx1AIIHnjxFGPiRk6yUZRYlEUjADpyEY/xTmAJBdcW8AK8yw4CzaP0OzwBXZsnIiMyp5vvkiLNvaKtiUz2USOZFITmrdPcYsFHVeMNhMK1upzcEFKVUp6SytkotGVWD5d5TNBSFQuxeCGXGqIvkSTcZDS+L5mg3D/OtIJLBcdUf+z2qKEsOgaOA9P2TVnyojXJKq0QTcG4+nz0YGEVJQIDAQAB",
                    Privatekey = "MIIEpAIBAAKCAQEAyC43UbsE5XZ2Pmqg1YgzeCqAMk4HOH8fYHslseeSgKxyDjybjqM0yjGIJry1FRmVvLnY7v8jURgwr7d/pDCSRdoHa6zaxuSzg0OlieNmujae34YZ54PmFxULZW0BHSdzmx3OIYK2GarRECkds531ZzpbLdRXqsxQf5G26JZLIFxmNuh/VjBjJ6Hic1WOFT+FCYyi8om+LkPn3jELeA7LPLXzFqzzxx0vo4yiAePrsX5WucWxf+Y8rZoDhRIy/cPtQECXi9SiAWOJe/82JqjVjfpowf3QN7UJHsA82RBloAS4lvvDGJA7a+8DDlqpqPer8cS41Dv5r39iqtJUybDqoQIDAQABAoIBAHi39kBhiihe8hvd7bQX+QIEj17G02/sqZ1jZm4M+rqCRB31ytGP9qvghvzlXEanMTeo0/v8/O1Qqzusa1s2t19MhqEWkrDTBraoOtIWwsKVYeXmVwTY9A8Db+XwgHV2by8iIEbxLqP38S/Pu8uv/GgONyJCJcQohnsIAsfsqs2OGggz+PplZaXJfUkPomWkRdHM9ZWWDLrCIlmRSHLmhHEtFJaXD083kqo437qra58Amw/n+2gH57utbAQ9V3YQFjD8zW511prC+mB6N/WUlaLstkxswGJ16obEJfQ0r8wYHx14ep6UKGyi3YXlMHcteI8gz+uFx4RuVV9EotdXagECgYEA7AEz9oPFYlW1H15OkDGy8yBnpJwIBu2CQLxINsxhrLIAZ2Bgxqcsv+D9CpnYCBDisbXoGoyMK6XaSypBMRKe2y8yRv4c+w00rcKHtGfRjzSJ5NQO0Tv+q8vKY+cd6BuJ6OUQw82ICLANIfHJZNxtvtTCmmqBwSJDpcQJQXmKXTECgYEA2SQCSBWZZONkvhdJ15K+4IHP2HRbYWi+C1OvKzUiK5bdJm77zia4yJEJo5Y/sY3mV3OK0Bgb7IAaxL3i0oH+WNTwbNoGpMlYHKuj4x1453ITyjOwPNj6g27FG1YSIDzhB6ZC4dBlkehi/7gIlIiQt1wkIZ+ltOqgI5IqIdXoSHECgYB3zCiHYt4oC1+UW7e/hCrVNUbHDRkaAygSGkEB5/9QvU5tK0QUsrmJcPihj/RUK9YW5UK7b0qbwWWsr/dFpLEUi8GWvdkSKuLprQxbrDN44O96Q5Z96Vld9WV4DtJkhs4bdWNsMQFzf4I7D9PuKeJfcvqRjaztz6nNFFSqcrqkkQKBgQCJKlUCohpG/9notp9fvQQ0n+viyQXcj6TVVOSnf6X5MRC8MYmBHTbHA8+59bSAfanO/l7muwQQro+6TlUVMyaviLvjlwpxV/sACXC6jCiO06IqreIbXdlJ41RBw2op0Ss5gM5pBRLUS58V+HP7GBWKrnrofofXtAq6zZ8txok4EQKBgQCXrTeGMs7ECfehLz64qZtPkiQbNwupg938Z40Qru/G1GR9u0kmN7ibTyYauI6NNVHGEZa373EBEkacfN+kkkLQMs1tj5Zrlw+iITm+ad/irpXQZS/NHCcrg6h82vu0LcgiKnHKlmW6K5ne0w4LqmsmRCm7JdJjt9WlapAs0ticiw=="
                };
                var alipayGateway = new AlipayGateway(alipayMerchant)
                {
                    GatewayTradeType = GatewayTradeType.Web
                };

                var wechatpayMerchant = new Wechatpay.Merchant
                {
                    AppId = "wx2428e34e0e7dc6ef",
                    MchId = "1233410002",
                    Key = "e10adc3849ba56abbe56e056f20f883e",
                    AppSecret = "51c56b886b5be869567dd389b3e5d1d6",
                    SslCertPath = "Certs/apiclient_cert.p12",
                    SslCertPassword = "1233410002",
                    NotifyUrl = "http://localhost:61337/Notify"
                };
                var wechatpayGateway = new WechatpayGataway(wechatpayMerchant)
                {
                    GatewayTradeType = GatewayTradeType.Web
                };

                gateways.Add(alipayGateway);
                gateways.Add(wechatpayGateway);

                return gateways;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Payment}/{action=Index}");
            });

            app.UseICanPay();
        }
    }
}
