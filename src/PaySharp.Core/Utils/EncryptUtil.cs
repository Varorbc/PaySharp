using PaySharp.Core.Exceptions;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PaySharp.Core.Utils
{
    /// <summary>
    /// 加密工具类
    /// </summary>
    public static class EncryptUtil
    {
        #region 私有字段

        /// <summary>
        /// 默认编码
        /// </summary>
        private static readonly string _defaultCharset = "UTF-8";

        #endregion

        #region MD5加密

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="data">数据</param>
        public static string MD5(string data)
        {
            return MD5(data, Encoding.UTF8);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static string MD5(string data, Encoding encoding)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var dataByte = md5.ComputeHash(encoding.GetBytes(data));

            return BitConverter.ToString(dataByte).Replace("-", "");
        }

        #endregion

        #region RSA加密

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="privateKey">私钥</param>
        /// <param name="signType">签名类型</param>
        /// <returns></returns>
        public static string RSA(string data, string privateKey, string signType)
        {
            return RSA(data, privateKey, _defaultCharset, signType, false);
        }

        private static string RSA(string data, string privateKeyPem, string charset, string signType, bool keyFromFile)
        {

            byte[] signatureBytes = null;
            try
            {
                RSA rsaCsp = null;
                if (keyFromFile)
                {
                    //文件读取
                    rsaCsp = LoadCertificateFile(privateKeyPem, signType);
                }
                else
                {
                    //字符串获取
                    rsaCsp = LoadCertificateString(privateKeyPem, signType);
                }

                byte[] dataBytes = null;

                if (string.IsNullOrEmpty(charset))
                {
                    dataBytes = Encoding.UTF8.GetBytes(data);
                }
                else
                {
                    dataBytes = Encoding.GetEncoding(charset).GetBytes(data);
                }

                if (null == rsaCsp)
                {
                    throw new GatewayException("您使用的私钥格式错误，请检查RSA私钥配置" + ",charset = " + charset);
                }

                if ("RSA2".Equals(signType))
                {
#if NETSTANDARD2_0
                    signatureBytes = rsaCsp.SignData(dataBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
#else
                    signatureBytes = ((RSACryptoServiceProvider)rsaCsp).SignData(dataBytes, "SHA256");
#endif
                }
                else
                {
#if NETSTANDARD2_0
                    signatureBytes = rsaCsp.SignData(dataBytes, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
#else
                    signatureBytes = ((RSACryptoServiceProvider)rsaCsp).SignData(dataBytes, "SHA1");
#endif
                }
            }
            catch
            {
                throw new GatewayException("您使用的私钥格式错误，请检查RSA私钥配置" + ",charset = " + charset);
            }

            return Convert.ToBase64String(signatureBytes);
        }

        /// <summary>
        /// RSA2验签
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="sign">签名</param>
        /// <param name="publicKey">公钥</param>
        /// <param name="signType">签名类型</param>
        /// <returns></returns>
        public static bool RSAVerifyData(string data, string sign, string publicKey, string signType)
        {
            return RSAVerifyData(data, sign, publicKey, _defaultCharset, signType, false);
        }

        private static bool RSAVerifyData(string signContent, string sign, string publicKeyPem, string charset, string signType, bool keyFromFile)
        {
            try
            {
                string sPublicKeyPEM = publicKeyPem;

                if (keyFromFile)
                {
                    sPublicKeyPEM = File.ReadAllText(publicKeyPem);
                }
                var rsa = CreateRsaProviderFromPublicKey(sPublicKeyPEM, signType);
                bool bVerifyResultOriginal = false;

                if ("RSA2".Equals(signType))
                {
#if NETSTANDARD2_0
                    bVerifyResultOriginal = rsa.VerifyData(Encoding.GetEncoding(charset).GetBytes(signContent),
                       Convert.FromBase64String(sign), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
#else
                    bVerifyResultOriginal = ((RSACryptoServiceProvider)rsa).VerifyData(
                        Encoding.GetEncoding(charset).GetBytes(signContent), "SHA256", Convert.FromBase64String(sign));
#endif
                }
                else
                {
#if NETSTANDARD2_0
                    bVerifyResultOriginal = rsa.VerifyData(Encoding.GetEncoding(charset).GetBytes(signContent),
                       Convert.FromBase64String(sign), HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
#else
                    bVerifyResultOriginal = ((RSACryptoServiceProvider)rsa).VerifyData(
                        Encoding.GetEncoding(charset).GetBytes(signContent), "SHA1", Convert.FromBase64String(sign));
#endif
                }

                return bVerifyResultOriginal;
            }
            catch
            {
                return false;
            }

        }

        private static RSA CreateRsaProviderFromPublicKey(string publicKeyString, string signType)
        {
            byte[] seqOid = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            byte[] seq = new byte[15];

            var x509Key = Convert.FromBase64String(publicKeyString);
            using (MemoryStream mem = new MemoryStream(x509Key))
            {
                using (BinaryReader binr = new BinaryReader(mem))
                {
                    byte bt = 0;
                    ushort twobytes = 0;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130)
                    {
                        binr.ReadByte();
                    }
                    else if (twobytes == 0x8230)
                    {
                        binr.ReadInt16();
                    }
                    else
                    {
                        return null;
                    }

                    seq = binr.ReadBytes(15);
                    if (!CompareBytearrays(seq, seqOid))
                    {
                        return null;
                    }

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8103)
                    {
                        binr.ReadByte();
                    }
                    else if (twobytes == 0x8203)
                    {
                        binr.ReadInt16();
                    }
                    else
                    {
                        return null;
                    }

                    bt = binr.ReadByte();
                    if (bt != 0x00)
                    {
                        return null;
                    }

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130)
                    {
                        binr.ReadByte();
                    }
                    else if (twobytes == 0x8230)
                    {
                        binr.ReadInt16();
                    }
                    else
                    {
                        return null;
                    }

                    twobytes = binr.ReadUInt16();
                    byte lowbyte = 0x00;
                    byte highbyte = 0x00;

                    if (twobytes == 0x8102)
                    {
                        lowbyte = binr.ReadByte();
                    }
                    else if (twobytes == 0x8202)
                    {
                        highbyte = binr.ReadByte();
                        lowbyte = binr.ReadByte();
                    }
                    else
                    {
                        return null;
                    }
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                    int modsize = BitConverter.ToInt32(modint, 0);

                    int firstbyte = binr.PeekChar();
                    if (firstbyte == 0x00)
                    {
                        binr.ReadByte();
                        modsize -= 1;
                    }

                    byte[] modulus = binr.ReadBytes(modsize);

                    if (binr.ReadByte() != 0x02)
                    {
                        return null;
                    }
                    int expbytes = binr.ReadByte();
                    byte[] exponent = binr.ReadBytes(expbytes);

                    RSA rsa = System.Security.Cryptography.RSA.Create();
                    rsa.KeySize = signType == "RSA" ? 1024 : 2048;
                    RSAParameters rsaKeyInfo = new RSAParameters
                    {
                        Modulus = modulus,
                        Exponent = exponent
                    };
                    rsa.ImportParameters(rsaKeyInfo);

                    return rsa;
                }
            }
        }

        private static bool CompareBytearrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            int i = 0;
            foreach (byte c in a)
            {
                if (c != b[i])
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        private static RSA LoadCertificateFile(string filename, string signType)
        {
            using (FileStream fs = File.OpenRead(filename))
            {
                byte[] data = new byte[fs.Length];
                byte[] res = null;
                fs.Read(data, 0, data.Length);
                if (data[0] != 0x30)
                {
                    res = GetPem("RSA PRIVATE KEY", data);
                }
                try
                {
                    return DecodeRSAPrivateKey(res, signType);
                }
                catch
                {
                    return null;
                }
            }
        }

        private static RSA LoadCertificateString(string strKey, string signType)
        {
            byte[] data = Convert.FromBase64String(strKey);
            try
            {
                return DecodeRSAPrivateKey(data, signType);
            }
            catch
            {
                return null;
            }
        }

        private static RSA DecodeRSAPrivateKey(byte[] privkey, string signType)
        {
            byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;
            MemoryStream mem = new MemoryStream(privkey);
            BinaryReader binr = new BinaryReader(mem);
            byte bt = 0;
            ushort twobytes = 0;
            int elems = 0;
            try
            {
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)
                {
                    binr.ReadByte();
                }
                else if (twobytes == 0x8230)
                {
                    binr.ReadInt16();
                }
                else
                {
                    return null;
                }

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102)
                {
                    return null;
                }

                bt = binr.ReadByte();
                if (bt != 0x00)
                {
                    return null;
                }

                elems = GetIntegerSize(binr);
                MODULUS = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                E = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                D = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                P = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                Q = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                DP = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                DQ = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                IQ = binr.ReadBytes(elems);

                int bitLen = 1024;
                if ("RSA2".Equals(signType))
                {
                    bitLen = 2048;
                }

                RSA RSA = RSA.Create();
                RSA.KeySize = bitLen;
                RSAParameters RSAparams = new RSAParameters
                {
                    Modulus = MODULUS,
                    Exponent = E,
                    D = D,
                    P = P,
                    Q = Q,
                    DP = DP,
                    DQ = DQ,
                    InverseQ = IQ
                };
                RSA.ImportParameters(RSAparams);
                return RSA;
            }
            catch
            {
                return null;
            }
            finally
            {
                binr.Close();
            }
        }

        private static byte[] GetPem(string type, byte[] data)
        {
            string pem = Encoding.UTF8.GetString(data);
            string header = String.Format("-----BEGIN {0}-----\\n", type);
            string footer = String.Format("-----END {0}-----", type);
            int start = pem.IndexOf(header) + header.Length;
            int end = pem.IndexOf(footer, start);
            string base64 = pem.Substring(start, (end - start));

            return Convert.FromBase64String(base64);
        }

        private static int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02)
            {
                return 0;
            }

            bt = binr.ReadByte();

            if (bt == 0x81)
            {
                count = binr.ReadByte();
            }
            else if (bt == 0x82)
            {
                highbyte = binr.ReadByte();
                lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt;
            }

            while (binr.ReadByte() == 0x00)
            {
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);
            return count;
        }

        #endregion

        #region SHA256加密

        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static string SHA256(string data)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            var sha256 = new SHA256Managed();
            byte[] result = sha256.ComputeHash(byteData);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }

        #endregion

        #region HMACSHA1加密

        /// <summary>
        /// HMACSHA1加密
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string HMACSHA1(string data, string key)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            byte[] byteKey = Encoding.UTF8.GetBytes(key);
            var hmacsha1 = new HMACSHA1(byteKey);
            byte[] result = hmacsha1.ComputeHash(byteData);
            return Convert.ToBase64String(result);
        }

        #endregion

        #region HMACSHA256加密

        /// <summary>
        /// HMACSHA256加密
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string HMACSHA256(string data, string key)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            byte[] byteKey = Encoding.UTF8.GetBytes(key);
            var hmacsha256 = new HMACSHA256(byteKey);
            byte[] result = hmacsha256.ComputeHash(byteData);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }

        #endregion

        #region AES解密

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="data">待解密数据</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string AESDecrypt(string data, string key)
        {
            var keyArray = Encoding.UTF8.GetBytes(key);
            var toEncryptArray = Convert.FromBase64String(data);
            var rDel = new RijndaelManaged
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var cTransform = rDel.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }

        #endregion
    }
}
