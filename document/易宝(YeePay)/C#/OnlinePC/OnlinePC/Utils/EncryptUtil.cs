using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class EncryptUtil
    {
        /// <summary>
        /// 将SortedDictionary中的键值拼接成一个大字符串，然后使用RSA生成签名
        /// </summary>
        /// <param name="sd"></param>
        /// <param name="privatekey"></param>
        /// <returns></returns>
        public static string handleRSA(SortedDictionary<string, object> sd,string privatekey)
        {
            StringBuilder sbuffer = new StringBuilder();
            foreach (KeyValuePair<string, object> item in sd)
             {
                 sbuffer.Append(item.Value);
             }
            Console.WriteLine(sbuffer.ToString());
            string sign = "";
            sign = RSAFromPkcs8.sign(sbuffer.ToString(), privatekey,"UTF-8");
            return sign;
        }

        /// <summary>
        /// 对一键支付返回的业务数据进行验签
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encrypt_key"></param>
        /// <param name="yibaoPublickKey"></param>
        /// <param name="merchantPrivateKey"></param>
        /// <returns></returns>
        public static bool checkDecryptAndSign(string data, string encrypt_key,
            string yibaoPublickKey, string merchantPrivateKey)
        {
            /** 1.使用YBprivatekey解开aesEncrypt。 */
            string AESKey = "";
            try
            {
                AESKey = RSAFromPkcs8.decryptData(encrypt_key, merchantPrivateKey,"UTF-8");
            }
            catch (Exception e)
            {
                /** AES密钥解密失败 */
                return false;
            }

            /** 2.用aeskey解开data。取得data明文 */
            string realData = AES.Decrypt(data, AESKey);

            
            SortedDictionary<string, object> sd = Newtonsoft.Json.JsonConvert.DeserializeObject<SortedDictionary<string, object>>(realData);
            

            /** 3.取得data明文sign。 */
            string sign =(string) sd["sign"];

            /** 4.对map中的值进行验证 */
            StringBuilder signData = new StringBuilder();
            foreach (var item in sd)
            {
                /** 把sign参数隔过去 */
                if (item.Key == "sign")
                {
                    continue;
                }
                signData.Append(item.Value);
            }

            signData = signData.Replace("\r", "");
            signData = signData.Replace("\n", "");
            signData = signData.Replace("    ", "");
            signData = signData.Replace("  ", "");
            signData = signData.Replace("\": \"", "\":\"");
            signData = signData.Replace("\": ", "\":");

            /**5. result为true时表明验签通过 */
            bool result = RSAFromPkcs8.checkSign(Convert.ToString(signData), sign,
                    yibaoPublickKey,"UTF-8");

            return result;
        }
    }

