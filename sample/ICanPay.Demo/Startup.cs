using ICanPay.Alipay;
using ICanPay.Core;
//using ICanPay.Unionpay;
using ICanPay.Wechatpay;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Encodings.Web;
using System.Text.Unicode;

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
            services.AddWebEncoders(opt =>
            {
                opt.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
            });

            services.AddICanPay(a =>
            {
                var gateways = new Gateways();

                var alipayMerchants = Configuration.GetSection("Alipay").Get<Alipay.Merchant[]>();
                foreach (var item in alipayMerchants)
                {
                    gateways.Add(new AlipayGateway(item)
                    {
                        GatewayUrl = "https://openapi.alipaydev.com"
                    });
                }

                var wechatpayMerchants = Configuration.GetSection("Wechatpay").Get<Wechatpay.Merchant[]>();
                foreach (var item in wechatpayMerchants)
                {
                    gateways.Add(new WechatpayGateway(item));
                }

                //var unionpayMerchants = Configuration.GetSection("Unionpay").Get<Unionpay.Merchant[]>();
                //foreach (var item in unionpayMerchants)
                //{
                //    gateways.Add(new UnionpayGateway(item)
                //    {
                //        GatewayUrl = "https://gateway.test.95516.com"
                //    });
                //}

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
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });

            app.UseICanPay();
        }
    }
}
