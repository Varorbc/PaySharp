using PaySharp.Core.Exceptions;
using PaySharp.Wechatpay.Domain;
using PaySharp.Wechatpay.Response;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PaySharp.Wechatpay.Request
{
    public class TransferToBankRequest : BaseRequest<TransferToBankModel, TransferToBankResponse>
    {
        private static RSACryptoServiceProvider _rSACryptoServiceProvider;

        public TransferToBankRequest()
        {
            RequestUrl = "/mmpaysptrans/pay_bank";
            IsUseCert = true;
        }

        internal override void Execute(Merchant merchant)
        {
            if (string.IsNullOrEmpty(merchant.PublicKey))
            {
                throw new GatewayException("请设置商户公钥");
            }

            if (_rSACryptoServiceProvider == null)
            {
                var rsaPubStructure = RsaPublicKeyStructure.GetInstance(
                    Asn1Object.FromByteArray(Convert.FromBase64String(merchant.PublicKey)));
                var rSAParameters = new RSAParameters()
                {
                    Exponent = rsaPubStructure.PublicExponent.ToByteArrayUnsigned(),
                    Modulus = rsaPubStructure.Modulus.ToByteArrayUnsigned()
                };
                _rSACryptoServiceProvider = new RSACryptoServiceProvider();
                _rSACryptoServiceProvider.ImportParameters(rSAParameters);
            }

            GatewayData.Add("enc_bank_no", Convert.ToBase64String(
                _rSACryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(Model.BankNo), false)));
            GatewayData.Add("enc_true_name", Convert.ToBase64String(
                _rSACryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(Model.TrueName), false)));
            GatewayData.Remove("notify_url");
            GatewayData.Remove("appid");
            GatewayData.Remove("sign_type");
        }
    }
}
