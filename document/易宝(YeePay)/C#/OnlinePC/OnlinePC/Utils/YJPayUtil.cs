using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;

/// <summary>
/// 一键支付工具类
/// </summary>

public class YJPayUtil
{
    //商户账户编号
    public static string merchantAccount = CustomerConfig.merchantAccount;



    /// <summary>
    /// 请求一键支付接口
    /// </summary>
    /// <param name="requestURL">完整的URL</param>
    /// <param name="data">加密后的业务数据</param>
    /// <param name="post">是否发生post请求</param>
    /// <returns></returns>
    public static string payAPIRequest(string requestURL, string datastring, bool post)
    {
        string postParams = "data=" + HttpUtil.UrlEncode(datastring) + "&customernumber=" + merchantAccount;
        string responseStr = "";
        if (post)
        {
            responseStr = HttpUtil.HttpPost(requestURL, postParams);
        }
        else
        {
            responseStr = HttpUtil.HttpGet(requestURL, postParams);
        }
        return responseStr;
    }


    /// <summary>
    /// 网银
    /// </summary>
    /// <param name="requestURL"></param>
    /// <param name="datastring"></param>
    /// <param name="post"></param>
    /// <returns></returns>
    public static string payAPIRequestOnlince(string requestURL, string datastring, bool post)
    {
        
        string responseStr = "";
        if (post)
        {
            responseStr = HttpUtil.HttpPost(requestURL, datastring);
        }
        else
        {
            responseStr = HttpUtil.HttpGet(requestURL, datastring);
        }
        return responseStr;

    }



    /// <summary>
    /// 下载文件
    /// </summary>
    /// <param name="requestURL"></param>
    /// <param name="datastring"></param>
    /// <param name="post"></param>
    /// <returns></returns>
    public static string downloadRequest(string requestURL, string datastring, bool post)
    {
        string postParams =  "authorize_no=" + merchantAccount+"&certify_token=" + HttpUtil.UrlEncode(datastring) ;
        string responseStr = "";
        if (post)
        {
            responseStr = HttpUtil.HttpPost(requestURL, postParams);
        }
        else
        {
            responseStr = HttpUtil.HttpGet(requestURL, postParams);
        }
        return responseStr;
    }



    /// <summary>
    /// 请求一键支付接口 仅适用于GET方法
    /// </summary>
    /// <param name="formUrl">请求的完整url</param>
    /// <param name="formData">请求的数据</param>
    /// <returns></returns>
    public static string payApirequest(string formUrl, string formData)
    {
        string result = string.Empty;
        //GET 提交方式
        Encoding myEncoding = Encoding.GetEncoding("UTF-8");
        string address = formUrl + "?" + formData;
        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(address);
        req.Method = "GET";
        using (WebResponse wr = req.GetResponse())
        {
            //在这里对接收到的页面内容进行处理
            System.IO.Stream responseStream = wr.GetResponseStream();
            StreamReader reader;
            string srcString;
            reader = new System.IO.StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
            srcString = reader.ReadToEnd();
            result = srcString;   //返回值赋值
            reader.Close();
        }
        return result;
    }
}

