using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Text;
using ThoughtWorks;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace WxPayAPI
{
    public partial class NativePayPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Log.Info(this.GetType().ToString(), "page load");

            NativePay nativePay = new NativePay();

            //生成扫码支付模式一url
            string url1 = nativePay.GetPrePayUrl("123456789");

            //生成扫码支付模式二url
            string url2 = nativePay.GetPayUrl("123456789");

            //将url生成二维码图片
            Image1.ImageUrl = "MakeQRCode.aspx?data=" + HttpUtility.UrlEncode(url1);
            Image2.ImageUrl = "MakeQRCode.aspx?data=" + HttpUtility.UrlEncode(url2);
        }
    }
}