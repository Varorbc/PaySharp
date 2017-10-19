using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections;

namespace tenpay
{
    public class CheckRequestHandler : RequestHandler
    {
        public CheckRequestHandler(HttpContext httpContext) : base(httpContext)
		{

            this.setGateUrl("http://api.mch.tenpay.com/cgi-bin/mchdown_real_new.cgi");
		}



        protected override void createSign()
        {
            StringBuilder sb = new StringBuilder();

            ArrayList akeys = new ArrayList();
            akeys.Add("spid");
            akeys.Add("trans_time");
            akeys.Add("stamp");
            akeys.Add("cft_signtype");
            akeys.Add("mchtype");
            

            foreach (string k in akeys)
            {
                string v = (string)parameters[k];
                if (null != v && "".CompareTo(v) != 0
                    && "sign".CompareTo(k) != 0 && "key".CompareTo(k) != 0)
                {
                    sb.Append(k + "=" + v + "&");
                }
            }

            sb.Append("key=" + this.getKey());
            string sign = MD5Util.GetMD5(sb.ToString(), getCharset()).ToLower();

            this.setParameter("sign", sign);

            //debugÐÅÏ¢
            this.setDebugInfo(sb.ToString() + " => sign:" + sign);		
        }
    }
}
