using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Net;
using log4net;
using System.Net.Security;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.X509;

namespace com.unionpay.acp.sdk
{
    public class AcpService
    {

        static AcpService() 
        {
            log.Debug("false".Equals(SDKConfig.IfValidateRemoteCert) ? "不验https证书。":"验https证书。");
            if ("false".Equals(SDKConfig.IfValidateRemoteCert)) //测试环境不验https证书
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(AcpService));

        /// <summary>
        /// 使用配置文件配置的证书/密钥签名
        /// </summary>
        /// <param name="reqData"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static void Sign(Dictionary<string, string> reqData, Encoding encoding)
        {
            if (!reqData.ContainsKey("signMethod"))
            {
                log.Error("signMethod must Not null");
                return;
            }
            string signMethod = reqData["signMethod"];
		    
            if("01".Equals(signMethod))
            {
                SignByCertInfo(reqData, SDKConfig.SignCertPath, SDKConfig.SignCertPwd, encoding);
            } 
            else if("11".Equals(signMethod) || "12".Equals(signMethod))
            {
                SignBySecureKey(reqData, SDKConfig.SecureKey, encoding);
            }
            else {
                log.Error("Error signMethod [" + signMethod + "] in Sign. ");
            }
        }

        [Obsolete("不建议使用", false)]
        public static void Sign(Dictionary<string, string> reqData, Encoding encoding, string certPath, string certPwd){
            SignByCertInfo(reqData, certPath, certPwd, encoding);
        }

        /// <summary>
        /// 证书方式签名（多证书时使用），指定证书路径。
        /// </summary>
        /// <param name="reqData"></param>
        /// <param name="encoding">编码</param>
        /// <param name="certPath">证书路径</param>
        /// <param name="certPwd">证书密码</param>
        /// <returns></returns>
        public static void SignByCertInfo(Dictionary<string, string> reqData, string certPath, string certPwd, Encoding encoding)
        {
            if (!reqData.ContainsKey("signMethod")) {
			    log.Error("signMethod must Not null");
			    return;
		    }
            string signMethod = reqData["signMethod"];
		    
            if (!reqData.ContainsKey("version")) {
			    log.Error("version must Not null");
			    return;
		    }
            string version = reqData["version"];

            if ("01".Equals(signMethod))
            {
                reqData["certId"] = CertUtil.GetSignCertId(certPath, certPwd);

                //将Dictionary信息转换成key1=value1&key2=value2的形式
                string stringData = SDKUtil.CreateLinkString(reqData, true, false, encoding);
                log.Info("待签名排序串：[" + stringData + "]");

                if ("5.0.0".Equals(version))
                {
                    byte[] signDigest = SecurityUtil.Sha1(stringData, encoding);

                    string stringSignDigest = SDKUtil.ByteArray2HexString(signDigest);
                    log.Info("sha1结果：[" + stringSignDigest + "]");

                    byte[] byteSign = SecurityUtil.SignSha1WithRsa(CertUtil.GetSignKeyFromPfx(certPath, certPwd), encoding.GetBytes(stringSignDigest));

                    string stringSign = Convert.ToBase64String(byteSign);
                    log.Info("5.0.0报文sha1RSA签名结果：[" + stringSign + "]");

                    //设置签名域值
                    reqData["signature"] = stringSign;
                }
                else
                {
                    byte[] signDigest = SecurityUtil.Sha256(stringData, encoding);

                    string stringSignDigest = SDKUtil.ByteArray2HexString(signDigest);
                    log.Info("sha256结果：[" + stringSignDigest + "]");

                    byte[] byteSign = SecurityUtil.SignSha256WithRsa(CertUtil.GetSignKeyFromPfx(certPath, certPwd), encoding.GetBytes(stringSignDigest));

                    string stringSign = Convert.ToBase64String(byteSign);
                    log.Info("5.1.0报文sha256RSA签名结果：[" + stringSign + "]");

                    //设置签名域值
                    reqData["signature"] = stringSign;

                }
            }
            else {
                log.Error("Error signMethod [" + signMethod + "] in SignByCertInfo. ");
            }
        }

        /// <summary>
        /// 用密钥签名（多密钥时使用）。
        /// </summary>
        /// <param name="reqData"></param>
        /// <param name="encoding">编码</param>
        /// <param name="certPath">证书路径</param>
        /// <param name="certPwd">证书密码</param>
        /// <returns></returns>
        public static void SignBySecureKey(Dictionary<string, string> reqData, string secureKey, Encoding encoding)
        {
            if (!reqData.ContainsKey("signMethod"))
            {
                log.Error("signMethod must Not null");
                return;
            }
            string signMethod = reqData["signMethod"];

            //将Dictionary信息转换成key1=value1&key2=value2的形式
            string stringData = SDKUtil.CreateLinkString(reqData, true, false, encoding);
            log.Info("待签名排序串：[" + stringData + "]");

            if ("11".Equals(signMethod))
            {
                String strBeforeSha256 = stringData + "&" + SDKUtil.ByteArray2HexString(SecurityUtil.Sha256(secureKey, encoding));
                String strAfterSha256 = SDKUtil.ByteArray2HexString(SecurityUtil.Sha256(strBeforeSha256, encoding));
                log.Info("5.1.0 sha256 密钥方式签名结果：[" + strAfterSha256 + "]");
                //设置签名域值
                reqData["signature"] = strAfterSha256;
            }
            else if ("12".Equals(signMethod))
            {
                String strBeforeSm3 = stringData + "&" + SDKUtil.ByteArray2HexString(SecurityUtil.Sm3(secureKey, encoding));
                String strAfterSm3 = SDKUtil.ByteArray2HexString(SecurityUtil.Sm3(strBeforeSm3, encoding));
                log.Info("5.1.0 sm3 密钥方式签名结果：[" + strAfterSm3 + "]");
                //设置签名域值
                reqData["signature"] = strAfterSm3;
            }
            else
            {
                log.Error("Error signMethod [" + signMethod + "] in SignBySecureKey. ");
            }
        }


        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="rspData"></param>
        /// <param name="encoder"></param>
        /// <returns></returns>
        public static bool Validate(Dictionary<string, string> rspData, Encoding encoding)
        {
            if (!rspData.ContainsKey("signMethod") || !rspData.ContainsKey("signature") || !rspData.ContainsKey("version"))
            {
                log.Error("signMethod或signature或version为空，无法验证签名。");
                return false;
            }
            string signMethod = rspData["signMethod"];
            string version = rspData["version"];
            bool result = false;
            
            if ("01".Equals(signMethod))
            {
                log.Info("验签处理开始");
                if ("5.0.0".Equals(version))
                {
                    string signValue = rspData["signature"];
                    log.Info("签名原文：[" + signValue + "]");
                    byte[] signByte = Convert.FromBase64String(signValue);
                    rspData.Remove("signature");
                    string stringData = SDKUtil.CreateLinkString(rspData, true, false, encoding);
                    log.Info("排序串：[" + stringData + "]");
                    byte[] signDigest = SecurityUtil.Sha1(stringData, encoding);
                    string stringSignDigest = SDKUtil.ByteArray2HexString(signDigest);
                    log.Debug("sha1结果：[" + stringSignDigest + "]");
                    AsymmetricKeyParameter key = CertUtil.GetValidateKeyFromPath(rspData["certId"]);
                    if (null == key)
                    {
                        log.Error("未找到证书，无法验签，验签失败。");
                        return false;
                    }
                    result = SecurityUtil.ValidateSha1WithRsa(key, signByte, encoding.GetBytes(stringSignDigest));
                } 
                else
                {
                    string signValue = rspData["signature"];
                    log.Info("签名原文：[" + signValue + "]");
                    byte[] signByte = Convert.FromBase64String(signValue);
                    rspData.Remove("signature");
                    string stringData = SDKUtil.CreateLinkString(rspData, true, false, encoding);
                    log.Info("排序串：[" + stringData + "]");
                    byte[] signDigest = SecurityUtil.Sha256(stringData, encoding);
                    string stringSignDigest = SDKUtil.ByteArray2HexString(signDigest);
                    log.Debug("sha256结果：[" + stringSignDigest + "]");

                    string signPubKeyCert = rspData["signPubKeyCert"];
                    X509Certificate x509Cert = CertUtil.VerifyAndGetPubKey(signPubKeyCert);
                    if (x509Cert == null)
                    {
                        log.Error("获取验签证书失败，无法验签，验签失败。");
                        return false;
                    }
                    result = SecurityUtil.ValidateSha256WithRsa(x509Cert.GetPublicKey(), signByte, encoding.GetBytes(stringSignDigest));
                }
            } 
            else if ("11".Equals(signMethod) || "12".Equals(signMethod))
            {
                return ValidateBySecureKey(rspData, SDKConfig.SecureKey, encoding);
            }
            else
            {
                log.Error("Error signMethod [" + signMethod + "] in Validate. ");
                return false;
            }
            if (result)
            {
                log.Info("验签成功");
            }
            else
            {
                log.Info("验签失败");
            }
            return result;
        }

        /// <summary>
        /// 验证签名（多密钥方式）
        /// </summary>
        /// <param name="rspData"></param>
        /// <param name="secureKey"></param>
        /// <param name="encoder"></param>
        /// <returns></returns>
        public static bool ValidateBySecureKey(Dictionary<string, string> rspData, string secureKey, Encoding encoding)
        {
            log.Info("验签处理开始");
            if (!rspData.ContainsKey("signMethod") || !rspData.ContainsKey("signature"))
            {
                log.Error("signMethod或signature为空，无法验证签名。");
                return false;
            }
            string signMethod = rspData["signMethod"];
            
            bool result = false;
            if ("11".Equals(signMethod))
            {
                string stringSign = rspData["signature"];
                log.Info("签名原文：[" + stringSign + "]");
                rspData.Remove("signature");
                string stringData = SDKUtil.CreateLinkString(rspData, true, false, encoding);
                log.Info("待验签返回报文串：[" + stringData + "]");
                string strBeforeSha256 = stringData + "&" + SDKUtil.ByteArray2HexString(SecurityUtil.Sha256(secureKey, encoding));
                log.Debug("before final sha256: [" + strBeforeSha256 + "]");
                string strAfterSha256 = SDKUtil.ByteArray2HexString(SecurityUtil.Sha256(strBeforeSha256, encoding));
                result = stringSign.Equals(strAfterSha256);
                if (!result) log.Debug("after final sha256: [" + strAfterSha256 + "]");
            }
            else if ("12".Equals(signMethod))
            {
                string stringSign = rspData["signature"];
                log.Info("签名原文：[" + stringSign + "]");
                rspData.Remove("signature");
                string stringData = SDKUtil.CreateLinkString(rspData, true, false, encoding);
                log.Info("待验签返回报文串：[" + stringData + "]");
                string strBeforeSm3 = stringData + "&" + SDKUtil.ByteArray2HexString(SecurityUtil.Sm3(secureKey, encoding));
                log.Debug("before final sm3: [" + strBeforeSm3 + "]");
                string strAfterSm3 = SDKUtil.ByteArray2HexString(SecurityUtil.Sm3(strBeforeSm3, encoding));
                result = stringSign.Equals(strAfterSm3);
                if (!result) log.Debug("after final sm3: [" + strAfterSm3 + "]");
            }
            else
            {
                log.Error("Error signMethod [" + signMethod + "] in ValidateBySecureKey. ");
                return false;
            }
            if (result)
            {
                log.Info("验签成功");
            }
            else
            {
                log.Info("验签失败");
            }
            return result;
        }

        /// <summary>
        /// 对控件支付成功返回的结果信息中data域进行验签（控件端获取的应答信息）
        /// </summary>
        /// <param name="jsonData">json格式数据，例如：{"sign" : "J6rPLClQ64szrdXCOtV1ccOMzUmpiOKllp9cseBuRqJ71pBKPPkZ1FallzW18gyP7CvKh1RxfNNJ66AyXNMFJi1OSOsteAAFjF5GZp0Xsfm3LeHaN3j/N7p86k3B1GrSPvSnSw1LqnYuIBmebBkC1OD0Qi7qaYUJosyA1E8Ld8oGRZT5RR2gLGBoiAVraDiz9sci5zwQcLtmfpT5KFk/eTy4+W9SsC0M/2sVj43R9ePENlEvF8UpmZBqakyg5FO8+JMBz3kZ4fwnutI5pWPdYIWdVrloBpOa+N4pzhVRKD4eWJ0CoiD+joMS7+C0aPIEymYFLBNYQCjM0KV7N726LA==",  "data" : "pay_result=success&tn=201602141008032671528&cert_id=68759585097"}</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        [Obsolete("5.1.0开发包已删除此方法，请直接参考5.1.0开发包中的VerifyAppData.aspx.cs验签。", false)]
        public static bool ValidateAppResponse(string jsonData, Encoding encoding)
        {
            log.Info("控件返回报文验签：[" + jsonData + "]");
            //获取签名
            Dictionary<string, object> data = SDKUtil.JsonToDictionary(jsonData);

            string stringData = (string)data["data"];
            string signValue = (string)data["sign"];
            Dictionary<string, string> dataMap = SDKUtil.parseQString(stringData, encoding);

            byte[] signByte = Convert.FromBase64String(signValue);
            byte[] signDigest = SecurityUtil.Sha1(stringData, encoding);
            string stringSignDigest = BitConverter.ToString(signDigest).Replace("-", "").ToLower();
            log.Debug("sha1结果：[" + stringSignDigest + "]");
            AsymmetricKeyParameter key = CertUtil.GetValidateKeyFromPath(dataMap["cert_id"]);
            if (null == key)
            {
                log.Error("未找到证书，无法验签，验签失败。");
                return false;
            }
            bool result = SecurityUtil.ValidateSha1WithRsa(key, signByte, encoding.GetBytes(stringSignDigest));
            if (result)
            {
                log.Info("验签成功");
            }
            else
            {
                log.Info("验签失败");
            }
            return result;
        }


        /// <summary>
        /// 前台交易构造HTTP POST自动提交的交易表单
        /// </summary>
        /// <param name="reqUrl"></param>
        /// <param name="reqData"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string CreateAutoFormHtml(string reqUrl, Dictionary<string, string> reqData, Encoding encoding)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendFormat("<meta http-equiv=\"Content-Type\" content=\"text/html; charset={0}\" />", encoding);
            html.AppendLine("</head>");
            html.AppendLine("<body onload=\"OnLoadSubmit();\">");
            html.AppendFormat("<form id=\"pay_form\" action=\"{0}\" method=\"post\">", reqUrl);
            foreach (KeyValuePair<string, string> kvp in reqData)
            {
                html.AppendFormat("<input type=\"hidden\" name=\"{0}\" id=\"{0}\" value=\"{1}\" />", kvp.Key, kvp.Value);
            }
            html.AppendLine("</form>");
            html.AppendLine("<script type=\"text/javascript\">");
            html.AppendLine("<!--");
            html.AppendLine("function OnLoadSubmit()");
            html.AppendLine("{");
            html.AppendLine("document.getElementById(\"pay_form\").submit();");
            html.AppendLine("}");
            html.AppendLine("//-->");
            html.AppendLine("</script>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");
            string result = html.ToString();
            log.Info("生成自动跳转的HTML：[" + result + "]");
            return result;
        }

        private static bool ValidateServerCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        /// <summary>
        /// http的基本post方法
        /// </summary>
        /// <param name="reqData">请求数据</param>
        /// <param name="url">URL地址</param>
        /// <param name="encoding">编码</param>
        /// <returns>服务器返回的数据</returns>
        public static Dictionary<String, String> Post(Dictionary<String, String> reqData, String reqUrl, Encoding encoding)
        {
            string postData = SDKUtil.CreateLinkString(reqData, false, true, encoding);
            byte[] byteArray = encoding.GetBytes(postData);
            Stream requestStream = null;
            StreamReader reader = null;
            HttpWebResponse webResponse = null;
            try
            {
                log.Info("发送post请求，url=[" + reqUrl + "]，data=[" + postData + "]");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(reqUrl);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                request.ContentLength = byteArray.Length;
                request.ServicePoint.Expect100Continue = false;

                requestStream = request.GetRequestStream();
                requestStream.Write(byteArray, 0, byteArray.Length);

                webResponse = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(webResponse.GetResponseStream(), encoding);
                String sResult = reader.ReadToEnd();
                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    log.Info("收到后台应答，data=[" + sResult + "]");
                    return SDKUtil.CoverStringToDictionary(sResult, encoding);
                }
                else
                {
                    string httpStatus = Enum.GetName(typeof(HttpStatusCode), webResponse.StatusCode);
                    log.Info("非200HTTP状态，httpStatus=" + httpStatus + "，data=[" + sResult + "]");
                    return new Dictionary<string, string>();
                }
            }
            catch (Exception ex)
            {
                log.Error("post失败，异常：" + ex.Message);
                return new Dictionary<string, string>();
            }
            finally {
                if(requestStream != null)
                    requestStream.Close();
                if (reader != null)
                    reader.Close();
                if (webResponse != null)
                    webResponse.Close();
            }

        }


        /// <summary>
        /// get方法
        /// </summary>
        /// <param name="reqData">请求数据</param>
        /// <param name="url">URL地址</param>
        /// <param name="encoding">编码</param>
        /// <returns>服务器返回的数据</returns>
        public static String Get(String reqUrl, Encoding encoding)
        {
            log.Debug("发送get请求：" + reqUrl); //get先debug，缴费相关前端接口数据量貌似还挺大
            StreamReader reader = null;
            HttpWebResponse webResponse = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(reqUrl);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "GET";
                request.ServicePoint.Expect100Continue = false;

                webResponse = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(webResponse.GetResponseStream(), encoding);
                String sResult = reader.ReadToEnd();
                reader.Close();
                webResponse.Close();

                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    log.Debug("收到后台应答，data=[" + sResult + "]");
                    return sResult;
                }
                else
                {
                    string httpStatus = Enum.GetName(typeof(HttpStatusCode), webResponse.StatusCode);
                    log.Debug("非200HTTP状态，httpStatus=" + httpStatus + "，data=[" + sResult + "]");
                    return "";
                }
            }
            catch (Exception ex)
            {
                log.Error("get失败，异常：" + ex.Message);
                return ex.Message;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (webResponse != null)
                    webResponse.Close();
            }

        }

        /// <summary>
        /// 不勾选对敏感信息加密权限使用旧的构造customerInfo域方式，不对敏感信息进行加密（对 phoneNo，cvn2， expired不加密）
        /// </summary>
        /// <param name="customerInfo">Dictionary的customerInfo</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        /// <returns>string类型结果</returns>
        public static string GetCustomerInfo(Dictionary<string, string> customerInfo, Encoding encoding)
        {
            if (customerInfo == null || customerInfo.Count == 0)
            {
                return "";
            }
            string customerInfoStr = "{" + SDKUtil.CreateLinkString(customerInfo, false, false, encoding) + "}";
            return Convert.ToBase64String(encoding.GetBytes(customerInfoStr));
        }

        /// <summary>
        /// 持卡人信息域customerInfo构造，当勾选对敏感信息加密权限，启用新加密规范（对phoneNo，cvn2，expired加密）适用
        /// </summary>
        /// <param name="customerInfo">Dictionary的customerInfo</param>
        /// <param name="encoding">编码</param>
        /// <returns>string类型结果</returns>
        public static string GetCustomerInfoWithEncrypt(Dictionary<string, string> customerInfo, Encoding encoding)
        {
            if (customerInfo == null || customerInfo.Count == 0)
            {
                return "";
            }
            Dictionary<string, string> encryptedInfo = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> pair in customerInfo)
            {
                if (pair.Key == "phoneNo" || pair.Key == "cvn2" || pair.Key == "expired")
                {
                    encryptedInfo[pair.Key] = pair.Value;
                }
            }
            customerInfo.Remove("phoneNo");
            customerInfo.Remove("cvn2");
            customerInfo.Remove("expired");
            if (encryptedInfo.Count != 0)
            {
                string encryptedInfoStr = SDKUtil.CreateLinkString(encryptedInfo, false, false, encoding);
                encryptedInfoStr = SecurityUtil.EncryptData(encryptedInfoStr, encoding);
                customerInfo["encryptedInfo"] = encryptedInfoStr;
            }
            string customerInfoStr = "{" + SDKUtil.CreateLinkString(customerInfo, false, false, encoding) + "}";
            return Convert.ToBase64String(encoding.GetBytes(customerInfoStr));
        }


        /// <summary>
        /// 将批量文件内容使用DEFLATE压缩算法压缩，Base64编码生成字符串
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="encoding"></param>
        public static string EnCodeFileContent(string filePath, Encoding encoding)
        {

            string fileContent;
            if (File.Exists(filePath))
            {
                FileStream fs = new FileStream(filePath, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                fileContent = sr.ReadToEnd();
                byte[] fileContentByte = SecurityUtil.deflater(encoding.GetBytes(fileContent));
                fileContent = Convert.ToBase64String(fileContentByte);
                sr.Close();
                fs.Close();
                return fileContent;
            }
            else
            {
                log.Error(filePath + "文件不存在，无法得到fileContent");
                return null;
            }
        }

        /// <summary>
        /// 解析交易返回的fileContent字符串并落地 (解base64，解DEFLATE压缩并落地) 适用：对账文件下载，批量交易状态查询的文件落地
        /// </summary>
        /// <param name="resData"></param>
        /// <param name="savePath"></param>
        public static bool DeCodeFileContent(Dictionary<string, string> resData, string fileDirectory)
        {
            string fileContent = resData["fileContent"];
            string fileName;
            if ( resData.ContainsKey("fileName")) 
                fileName = resData["fileName"];
            else 
                fileName = resData["merId"] + "_" + resData["batchNo"] + "_" + resData["txnTime"] + ".txt";
            try
            {
                //Base64解码
                byte[] dBase64Byte = Convert.FromBase64String(fileContent);
                //解压缩
                byte[] fileByte = SecurityUtil.Inflater(dBase64Byte);

                //保存
                string path = System.IO.Path.Combine(fileDirectory, fileName);
                System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create);
                fs.Write(fileByte, 0, fileByte.Length);
                fs.Close();
                fs.Dispose();

                return true;
            }
            catch (Exception e)
            {
                log.Error("保存fileContent出错：" + e.Message);
                return false;
            }
        }

        /// <summary>
        /// 敏感信息加密并做base64(卡号，手机号，cvn2,有效期）
        /// </summary>
        /// <param name="encoder"></param>
        /// <returns></returns>
        public static string EncryptData(string data, Encoding encoding)
        {
            return SecurityUtil.EncryptData(data, encoding);
        }

        /// <summary>
        /// 敏感信息解密
        /// </summary>
        /// <param name="encoder"></param>
        /// <returns></returns>
        public static string DecryptData(string data, Encoding encoding)
        {
            return SecurityUtil.DecryptData(data, encoding);
        }


        /// <summary>
        /// 敏感信息解密，多证书
        /// </summary>
        /// <param name="encoder"></param>
        /// <returns></returns>
        public static string DecryptData(string data, Encoding encoding, string certPath, string certPwd)
        {
            return SecurityUtil.DecryptData(data, encoding, certPath, certPwd);
        }

        //获取敏感信息加密证书的物理序列号
        public static String GetEncryptCertId()
        {
            return CertUtil.GetEncryptCertId();
        }

        /// <summary>
        /// 将customerInfo转化为Dictionary，为方便处理，encryptedInfo下面的信息也均转换为customerInfo子域一样方式处理
        /// </summary>
        /// <param name="customerInfoStr">string的customerInfo</param>
        /// <param name="encoding">编码</param>
        /// <returns>Dictionary类型结果</returns>
        public static Dictionary<string, string> ParseCustomerInfo(string customerInfoStr, Encoding encoding)
        {
            return ParseCustomerInfo(customerInfoStr, SDKConfig.SignCertPath, SDKConfig.SignCertPwd, encoding);
        }

        /// <summary>
        /// 将customerInfo转化为Dictionary，为方便处理，encryptedInfo下面的信息也均转换为customerInfo子域一样方式处理
        /// </summary>
        /// <param name="customerInfoStr">string的customerInfo</param>
        /// <param name="encoding">编码</param>
        /// <returns>Dictionary类型结果</returns>
        public static Dictionary<string, string> ParseCustomerInfo(string customerInfoStr, string certPath, string certPwd, Encoding encoding)
        {
            if (customerInfoStr == null || customerInfoStr.Trim().Equals(""))
            {
                return new Dictionary<string, string>();
            }
            string s = null;
            try
            {
                s = encoding.GetString(Convert.FromBase64String(customerInfoStr));
            }
            catch (Exception e)
            {
                log.Error("customerInfoStr解析失败，异常：" + e.Message);
                return new Dictionary<string, string>();
            }
            s = s.Substring(1, s.Length - 2);
            Dictionary<string, string> customerInfo = SDKUtil.parseQString(s, encoding);
            if (customerInfo.Keys.Contains("encryptedInfo"))
            {
                string encryptedInfoStr = customerInfo["encryptedInfo"];
                customerInfo.Remove("encryptedInfo");
                encryptedInfoStr = SecurityUtil.DecryptData(encryptedInfoStr, encoding, certPath, certPwd);
                Dictionary<string, string> encryptedInfo = SDKUtil.parseQString(encryptedInfoStr, encoding);
                foreach (KeyValuePair<string, string> pair in encryptedInfo)
                {
                    customerInfo[pair.Key] = pair.Value;
                }
            }
            return customerInfo;
        }




        /// <summary>
        /// 获取应答报文中的加密公钥证书,并存储到本地,并备份原始证书。
        /// 更新成功则返回1，无更新返回0，失败异常返回-1。
        /// </summary>
        /// <param name="dic">Dictionary数据</param>
        /// <param name="encoding">编码</param>
        /// <returns>成功返回1，无更新返回0，失败异常返回-1</returns>
        public static int UpdateEncryptCert(Dictionary<string, string> dic, Encoding encoding)
        {
            if (!dic.ContainsKey("encryptPubKeyCert") || !dic.ContainsKey("certType"))
            {
                log.Error("encryptPubKeyCert or certType is null.");
                return -1;
            }
            string strCert = dic["encryptPubKeyCert"];
            string certType = dic["certType"];
            X509Certificate x509Cert = CertUtil.GetPubKeyCert(strCert);
            if (x509Cert == null)
            {
                log.Error("从encryptPubKeyCert获取证书内容失败。");
                return -1;
            }
            if ("01".Equals(certType))
            {
                if (!CertUtil.GetEncryptCertId().Equals(x509Cert.SerialNumber.ToString()))
                {
                    // ID不同时进行本地证书更新操作
                    string localCertPath = SDKConfig.EncryptCert;
                    string newLocalCertPath = SDKUtil.GenBackupName(localCertPath);

                    // 1.将本地证书进行备份存储
                    try
                    {
                        System.IO.File.Copy(localCertPath, newLocalCertPath, true);
                    }
                    catch (Exception e)
                    {
                        log.Error("备份旧加密证书失败：", e);
                        return -1;
                    }
                    // 2.备份成功,进行新证书的存储
                    FileStream fs = null;
                    try
                    {
                        fs = File.OpenWrite(localCertPath);
                        Byte[] info = encoding.GetBytes(strCert);
                        fs.Write(info, 0, info.Length);
                    }
                    catch (Exception e)
                    {
                        log.Error("写入新加密证书失败：", e);
                        return -1;
                    }
                    finally
                    {
                        if (fs != null)
                            fs.Close();
                    }
                    log.Info("save new encryptPubKeyCert success");
                    CertUtil.resetEncryptCertPublicKey();
                    return 1;
                }
                else
                {
                    log.Info("加密公钥无更新。");
                    return 0;
                }
            }
            else if ("02".Equals(certType))
            {
                log.Info("加密公钥无更新。");
                return 0;
            }
            else
            {
                log.Error("unknown cerType:" + certType);
                return -1;
            }

        }
    }
}