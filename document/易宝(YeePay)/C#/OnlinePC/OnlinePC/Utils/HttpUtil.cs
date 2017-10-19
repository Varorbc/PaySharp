using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Linq;

public class HttpUtil
{
    /// <summary>
    /// 发生post请求
    /// </summary>
    /// <param name="Url"></param>
    /// <param name="postDataStr"></param>
    /// <returns></returns>
    public static string HttpPost(string Url, string postDataStr)
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
        Stream myRequestStream = request.GetRequestStream();
        StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
        myStreamWriter.Write(postDataStr);
        myStreamWriter.Close();

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream myResponseStream = response.GetResponseStream();
        StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
        string retString = myStreamReader.ReadToEnd();
        myStreamReader.Close();
        myResponseStream.Close();

        return retString;
    }

    /// <summary>
    /// 发生get请求
    /// </summary>
    /// <param name="Url"></param>
    /// <param name="postDataStr"></param>
    /// <returns></returns>
    public static string HttpGet(string Url, string postDataStr)
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
        request.Method = "GET";
        request.ContentType = "text/html;charset=UTF-8";

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream myResponseStream = response.GetResponseStream();
        StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
        string retString = myStreamReader.ReadToEnd();
        myStreamReader.Close();
        myResponseStream.Close();

        return retString;
    }

    /// <summary>
    /// 将字符串进行urlencode
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string UrlEncode(string str)
    {
        StringBuilder sb = new StringBuilder();
        byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
        for (int i = 0; i < byStr.Length; i++)
        {
            sb.Append(@"%" + Convert.ToString(byStr[i], 16));
        }

        return (sb.ToString());
    }

    public static string Upload(string filePath, string fileName,string data,string customernumber)
    {
        //参考http://www.cnblogs.com/greenerycn/archive/2010/05/15/csharp_http_post.html  
        string postURL = "https://o2o.yeepay.com/zgt-api/api/uploadLedgerQualifications";

        // 边界符  
        var boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
        var beginBoundary = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        // 最后的结束符  
        var endBoundary = Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");

        // 文件参数头  
        const string filePartHeader =
            "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
             "Content-Type: application/octet-stream\r\n\r\n";
        var fileHeader = string.Format(filePartHeader, "file", fileName);
        var fileHeaderBytes = Encoding.UTF8.GetBytes(fileHeader);

        // 开始拼数据  
        var memStream = new MemoryStream();
        memStream.Write(beginBoundary, 0, beginBoundary.Length);

        // 文件数据  
        memStream.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);
        var buffer = new byte[1024];
        int bytesRead; // =0  
        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
        {
            memStream.Write(buffer, 0, bytesRead);
        }
        fileStream.Close();

        // Key-Value数据  
        var stringKeyHeader = "\r\n--" + boundary +
                               "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                               "\r\n\r\n{1}\r\n";

        Dictionary<string, string> stringDict = new Dictionary<string, string>();
        stringDict.Add("data", data);
        stringDict.Add("customernumber", customernumber);
        foreach (byte[] formitembytes in from string key in stringDict.Keys
                                         select string.Format(stringKeyHeader, key, stringDict[key])
                                             into formitem
                                         select Encoding.UTF8.GetBytes(formitem))
        {
            memStream.Write(formitembytes, 0, formitembytes.Length);
        }

        // 写入最后的结束边界符  
        memStream.Write(endBoundary, 0, endBoundary.Length);

        //倒腾到tempBuffer?  
        memStream.Position = 0;
        var tempBuffer = new byte[memStream.Length];
        memStream.Read(tempBuffer, 0, tempBuffer.Length);
        memStream.Close();

        // 创建webRequest并设置属性  
        var webRequest = (HttpWebRequest)WebRequest.Create(postURL);
        webRequest.Method = "POST";
        webRequest.Timeout = 100000;
        webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
        webRequest.ContentLength = tempBuffer.Length;

        var requestStream = webRequest.GetRequestStream();
        requestStream.Write(tempBuffer, 0, tempBuffer.Length);
        requestStream.Close();

        var httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
        string responseContent;
        using (var httpStreamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("utf-8")))
        {
            responseContent = httpStreamReader.ReadToEnd();
        }

        httpWebResponse.Close();
        webRequest.Abort();
        return responseContent;
    }



}

