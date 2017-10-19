using Aop.Api.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI;

namespace alipay
{
    public partial class Return_url : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* 实际验证过程建议商户添加以下校验。
            1、商户需要验证该通知数据中的out_trade_no是否为商户系统中创建的订单号，
            2、判断total_amount是否确实为该订单的实际金额（即商户订单创建时的金额），
            3、校验通知中的seller_id（或者seller_email) 是否为out_trade_no这笔单据的对应的操作方（有的时候，一个商户可能有多个seller_id/seller_email）
            4、验证app_id是否为该商户本身。
            */
            Dictionary<string, string> sArray = GetRequestGet();
            if (sArray.Count != 0)
            {
                bool flag = AlipaySignature.RSACheckV1(sArray, config.alipay_public_key, config.charset, config.sign_type, false);
                if (flag)
                {
                    Response.Write("同步验证通过");
                }
                else
                {
                    Response.Write("同步验证失败");
                }
            }
        }

        public Dictionary<string, string> GetRequestGet()
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();
            NameValueCollection coll;
            //coll = Request.Form;
            coll = Request.QueryString;
            String[] requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.QueryString[requestItem[i]]);
            }
            return sArray;

        }
    }
}