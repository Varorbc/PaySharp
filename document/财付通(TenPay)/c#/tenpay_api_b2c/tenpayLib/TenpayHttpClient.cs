using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;


using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/**
 * http、https通信类
 * ============================================================================
 * api说明：
 * setReqContent($reqContent),设置请求内容，无论post和get，都用get方式提供
 * getResContent(), 获取应答内容
 * setMethod($method),设置请求方法,post或者get
 * getErrInfo(),获取错误信息
 * setCertInfo($certFile, $certPasswd, $certType="PEM"),设置证书，双向https时需要使用
 * setCaInfo($caFile), 设置CA，格式未pem，不设置则不检查
 * setTimeOut($timeOut)， 设置超时时间，单位秒
 * getResponseCode(), 取返回的http状态码
 * call(),真正调用接口
 * 
 * ============================================================================
 *
 */

namespace tenpay
{
    public class TenpayHttpClient
    {
        //请求内容，无论post和get，都用get方式提供
        private string reqContent;

        //应答内容
        private string resContent;

        //请求方法
        private string method;

        //错误信息
        private string errInfo;

        //证书文件 
        private string certFile;

        //证书密码 
        private string certPasswd;

        //ca证书文件 
        private string caFile;

        //超时时间,以秒为单位 
        private int timeOut;

        //http应答编码 
        private int responseCode;

        //字符编码
        private string charset;

        public TenpayHttpClient()
        {
            this.caFile = "";
            this.certFile = "";
            this.certPasswd = "";

            this.reqContent = "";
            this.resContent = "";
            this.method = "POST";
            this.errInfo = "";
            this.timeOut = 1 * 60;//5分钟

            this.responseCode = 0;
            this.charset = "gb2312";

        }

        //设置请求内容
        public void setReqContent(string reqContent)
        {
            this.reqContent = reqContent;
        }

        //获取结果内容
        public string getResContent()
        {
            return this.resContent;
        }

        //设置请求方法post或者get	
        public void setMethod(string method)
        {
            this.method = method;
        }

        //获取错误信息
        public string getErrInfo()
        {
            return this.errInfo;
        }

        //设置证书信息
        public void setCertInfo(string certFile, string certPasswd)
        {
            this.certFile = certFile;
            this.certPasswd = certPasswd;
        }

        //设置ca
        public void setCaInfo(string caFile)
        {
            this.caFile = caFile;
        }

        //设置超时时间,以秒为单位

        public void setTimeOut(int timeOut)
        {
            this.timeOut = timeOut;
        }


        //获取http状态码
        public int getResponseCode()
        {
            return this.responseCode;
        }

        public void setCharset(string charset)
        {
            this.charset = charset;
        }

        //验证服务器证书
        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        //执行http调用
        public bool call()
        {
            StreamReader sr = null;
            HttpWebResponse wr = null;

            HttpWebRequest hp = null;
            try
            {
                string postData = null;
                if (this.method.ToUpper() == "POST")
                {
                    string[] sArray = System.Text.RegularExpressions.Regex.Split(this.reqContent, "\\?");

                    hp = (HttpWebRequest)WebRequest.Create(sArray[0]);

                    if (sArray.Length >= 2)
                    {
                        postData = sArray[1];
                    }

                }
                else
                {
                    hp = (HttpWebRequest)WebRequest.Create(this.reqContent);
                }


                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                if (this.certFile != "")
                {
                    hp.ClientCertificates.Add(new X509Certificate2(this.certFile, this.certPasswd));
                }
                hp.Timeout = this.timeOut * 1000;

                System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(this.charset);
                if (postData != null)
                {
                    byte[] data = encoding.GetBytes(postData);

                    hp.Method = "POST";

                    hp.ContentType = "application/x-www-form-urlencoded";

                    hp.ContentLength = data.Length;

                    Stream ws = hp.GetRequestStream();

                    // 发送数据

                    ws.Write(data, 0, data.Length);
                    ws.Close();


                }


                wr = (HttpWebResponse)hp.GetResponse();
                sr = new StreamReader(wr.GetResponseStream(), encoding);



                this.resContent = sr.ReadToEnd();
                sr.Close();
                wr.Close();
            }
            catch (Exception exp)
            {
                this.errInfo += exp.Message;
                if (wr != null)
                {
                    this.responseCode = Convert.ToInt32(wr.StatusCode);
                }

                return false;
            }

            this.responseCode = Convert.ToInt32(wr.StatusCode);

            return true;
        }
    }
}
