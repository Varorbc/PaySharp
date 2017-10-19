using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WxPayAPI
{
    public partial class NativeNotifyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NativeNotify nativeNatify = new NativeNotify(this);
            nativeNatify.ProcessNotify();
        }
    }
}