using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePC
{
    public partial class CallBack : System.Web.UI.Page
    {
        /// <summary>
        /// 接收易宝支付回调示例
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            StringBuilder log = new StringBuilder();

            string data = Request["data"];

            string type = Request["type"];

            Labtype.Value = type;

            LabData.Value = data;

        }
    }
}