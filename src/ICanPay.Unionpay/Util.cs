using ICanPay.Core.Utils;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Text;

namespace ICanPay.Unionpay
{
    internal static class Util
    {
        /// <summary>
        /// 获取Pkcs12Store
        /// </summary>
        /// <param name="path">证书路径</param>
        /// <param name="pwd">证书密码</param>
        /// <returns></returns>
        private static (Pkcs12Store Store, string Aliase) GetPkcs12Store(string path, string pwd)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                Pkcs12Store store = new Pkcs12Store(fileStream, pwd.ToCharArray());
                foreach (string n in store.Aliases)
                {
                    if (store.IsKeyEntry(n))
                    {
                        return (store, n);
                    }
                }
            }

            return (null, null);
        }

        /// <summary>
        /// 获取证书编号
        /// </summary>
        /// <param name="path">证书路径</param>
        /// <param name="pwd">证书密码</param>
        /// <returns></returns>
        public static string GetCertId(string path, string pwd)
        {
            var store = GetPkcs12Store(path, pwd);
            return store
                .Store
                .GetCertificateChain(store.Aliase)[0]
                .Certificate
                .SerialNumber
                .ToString();
        }

        /// <summary>
        /// 获取证书编号
        /// </summary>
        /// <param name="path">证书路径</param>
        /// <param name="pwd">证书密码</param>
        /// <returns></returns>
        public static AsymmetricKeyParameter GetCertKey(string path, string pwd)
        {
            var store = GetPkcs12Store(path, pwd);
            return store
                .Store
                .GetKey(store.Aliase)
                .Key;
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="key">私钥</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static string Sign(AsymmetricKeyParameter key, string data)
        {
            var byteData = Encoding.UTF8.GetBytes(EncryptUtil.SHA256(data));
            ISigner normalSig = SignerUtilities.GetSigner("SHA256WithRSA");
            normalSig.Init(true, key);
            normalSig.BlockUpdate(byteData, 0, byteData.Length);
            byte[] normalResult = normalSig.GenerateSignature();
            return Convert.ToBase64String(normalResult);
        }

    }
}
