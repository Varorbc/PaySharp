using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePC.Utils
{

    /// <summary>
	/// FormatQueryString 的摘要说明。
	/// </summary>
    public abstract class FormatQueryString
    {
        public FormatQueryString()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strParaName"></param>
        /// <param name="strUrl"></param>
        /// <param name="strSplitChar"></param>
        /// <returns></returns>
        public static string GetQueryString(string strParaName, string strUrl, char strSplitChar)
        {
            string result = "";

            string[] strUrlArg = strUrl.Split(strSplitChar);

            for (int i = 0; i < strUrlArg.Length; i++)
            {
                if (strUrlArg[i].IndexOf(strParaName) >= 0)
                {
                    result = System.Web.HttpUtility.UrlDecode(strUrlArg[i].Split('=')[1], System.Text.Encoding.GetEncoding("gb2312"));
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strParaName"></param>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public static string GetQueryString(string strParaName, string strUrl)
        {
            return GetQueryString(strParaName, strUrl, '&');
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strParaName"></param>
        /// <returns></returns>
        public static string GetQueryString(string strParaName)
        {
            return GetQueryString(strParaName, System.Web.HttpContext.Current.Request.Url.Query, '&');
        }

    }
}
