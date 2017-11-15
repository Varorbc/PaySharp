using ICanPay.Core.Utils;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Pkix;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.X509.Store;
using System;
using System.Collections;
using System.IO;
using System.Text;

namespace ICanPay.Unionpay
{
    internal static class Util
    {
        #region 证书

#if DEBUG

        #region 测试证书

        private const string ACPTESTENCCER = "-----BEGIN CERTIFICATE-----" +
            "MIIEQzCCAyugAwIBAgIFEAJkkicwDQYJKoZIhvcNAQEFBQAwWDELMAkGA1UEBhMC" +
            "Q04xMDAuBgNVBAoTJ0NoaW5hIEZpbmFuY2lhbCBDZXJ0aWZpY2F0aW9uIEF1dGhv" +
            "cml0eTEXMBUGA1UEAxMOQ0ZDQSBURVNUIE9DQTEwHhcNMTUxMjE1MDkxMTM1WhcN" +
            "MTcxMjE1MDkxMTM1WjCBgTELMAkGA1UEBhMCY24xFzAVBgNVBAoTDkNGQ0EgVEVT" +
            "VCBPQ0ExMRIwEAYDVQQLEwlDRkNBIFRFU1QxFDASBgNVBAsTC0VudGVycHJpc2Vz" +
            "MS8wLQYDVQQDFCYwNDFAWjIwMTQtMTEtMTFAMDAwNDAwMDA6U0lHTkAwMDAwMDAw" +
            "NTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBANHnoPx0JZKZmFjIURxN" +
            "AbLlWAw2jiFFWBnDF2MIGkya2r0fGiR0knq8zkKUnoIyC+tzEiOavniQaSu0ucuv" +
            "/V4ugz66PSRxw1gaPcR2dDVdgojF00TcewxlJEA65fK3eKhUYfC3NbRaVQOMMdwv" +
            "7nNEvzxvdExE47ceMya7FmsUPyLFu9X++chFQiYfr8nH+wdDeYo8w8vCX+Jd2vRu" +
            "qDOah29CQfkAmXsx3D68zg0q4AjlLI1t5gLKiU5YoG6yWrigPyreEHh716rV8HkT" +
            "jGWx3cxF/HsLZ/E4SgIr5yIZA6qw8RFqaSXuyw3iDrNf6aSJGO0GKlvxnvD20oGR" +
            "JokCAwEAAaOB6TCB5jAfBgNVHSMEGDAWgBTPcJ1h6518Lrj3ywJA9wmd/jN0gDBI" +
            "BgNVHSAEQTA/MD0GCGCBHIbvKgEBMDEwLwYIKwYBBQUHAgEWI2h0dHA6Ly93d3cu" +
            "Y2ZjYS5jb20uY24vdXMvdXMtMTQuaHRtMDgGA1UdHwQxMC8wLaAroCmGJ2h0dHA6" +
            "Ly91Y3JsLmNmY2EuY29tLmNuL1JTQS9jcmw0NTE3LmNybDALBgNVHQ8EBAMCA+gw" +
            "HQYDVR0OBBYEFGjriHHUE1MnYX7H6GrFi+8R2zmUMBMGA1UdJQQMMAoGCCsGAQUF" +
            "BwMCMA0GCSqGSIb3DQEBBQUAA4IBAQAjsN0fyDqcxS9YKMpY3CIdlarCjvnus+wS" +
            "ExjNnPv7n2urqhz2Jf3yJuhxVVPzdgKT51C2UiR+/i1OJPWFx0IUos/v8js/TM5j" +
            "mTdPkBsRSxSDieHHiuE1nPUwGXUEO7mlOVkkzmLI75bJ86foxNflbQCF0+VvpMe7" +
            "KwQoNOR8DxIBxHdlsjSxE2RKM/ftXLhptrK4GK3K4FAcSiqBMEn5PF/5V9mHp5N6" +
            "3LdkMYqBj4pRcy8vrclucq99b2glmMLw7CI6Kxu22WVoRnZESjcgXiMVLLe+qy55" +
            "0pWcZ2BChS7Ln19tj49LnS3vFp6xf4qNSqxEBaQuNLEx0ObjI6pz" +
            "-----END CERTIFICATE-----";
        private const string ACPTESTROOTCER = "-----BEGIN CERTIFICATE-----" +
            "MIIDkzCCAnugAwIBAgIKUhN+zB19hbc65jANBgkqhkiG9w0BAQUFADBZMQswCQYD" +
            "VQQGEwJDTjEwMC4GA1UEChMnQ2hpbmEgRmluYW5jaWFsIENlcnRpZmljYXRpb24g" +
            "QXV0aG9yaXR5MRgwFgYDVQQDEw9DRkNBIFRFU1QgQ1MgQ0EwHhcNMTIwODI5MDUw" +
            "MTI5WhcNMzIwODI5MDUwMTI5WjBZMQswCQYDVQQGEwJDTjEwMC4GA1UEChMnQ2hp" +
            "bmEgRmluYW5jaWFsIENlcnRpZmljYXRpb24gQXV0aG9yaXR5MRgwFgYDVQQDEw9D" +
            "RkNBIFRFU1QgQ1MgQ0EwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDa" +
            "rMJGruH6rOBPFxUI7T1ybydSRRtOM1xvkVjQNX0qmYir8feE6Tb0ctgtKR7a20DI" +
            "YCj9kZ5ANBQqjRcj3Soq9XH3cirqhYHJ723OKyTpS0RPQ0N6vtVt3P5JQ+ztjWHd" +
            "qIbbTOQ6O024TGTiqi6uHgMuz9/OVur81X3a5YVkK7jFeZ9o8cTcvQxD853/1sgZ" +
            "QcmR9aUSw0RXH4XFLTrn7n4QSfWKiNotlD8Ag5gS1pH9ONUb6nGkMn3gh1xfJqjm" +
            "ONMSknPXTGiNpXtqvYi8oIvByVCbUDO59IwPP1r1SYyE3P8Nr7DdQRu0KQSdXLoG" +
            "iugSR3fn+toObVAQmplDAgMBAAGjXTBbMB8GA1UdIwQYMBaAFHTexY0KfRAaqmmD" +
            "W00hzoabzHE4MAwGA1UdEwQFMAMBAf8wCwYDVR0PBAQDAgEGMB0GA1UdDgQWBBR0" +
            "3sWNCn0QGqppg1tNIc6Gm8xxODANBgkqhkiG9w0BAQUFAAOCAQEAM0eTkM35D4hj" +
            "RlGC63wY0h++wVPUvOrObqAVBbzEEQ7ScBienmeY8Q6lWMUTXM9ALibZklpJPcJv" +
            "3ntht7LL6ztd4wdX7E9RzZCQnRvbL9A/BU3NxWdeSpCg/OyPod5oCKP+6Uc7kApi" +
            "F9OtYNWnt3l2Zp/NiedzEQD8H4qEWQLAq+0dFo5BkfVhb/jPcktndpfPOuH1IMhP" +
            "tVcvo6jpFHw4U/nP2Jv59osIE97KJz/SPt2JAYnZOlIDqWwp9/Afvt0/MDr8y0PK" +
            "Q9c6eqIzBx7a9LpUTUl5u1jS+xSDZ/KF2lXnjwaFp7jICLWEMlBstCoogi7KwH9A" +
            "LpJP7/dj9g==" +
            "-----END CERTIFICATE-----";
        private const string ACPTESTMIDDLECER = "-----BEGIN CERTIFICATE-----" +
            "MIIDzjCCAragAwIBAgIKGNDz/H99Hd/CxjANBgkqhkiG9w0BAQUFADBZMQswCQYD" +
            "VQQGEwJDTjEwMC4GA1UEChMnQ2hpbmEgRmluYW5jaWFsIENlcnRpZmljYXRpb24g" +
            "QXV0aG9yaXR5MRgwFgYDVQQDEw9DRkNBIFRFU1QgQ1MgQ0EwHhcNMTIwODMwMDMx" +
            "NDMzWhcNMzEwNTExMDMxNDMzWjBYMQswCQYDVQQGEwJDTjEwMC4GA1UEChMnQ2hp" +
            "bmEgRmluYW5jaWFsIENlcnRpZmljYXRpb24gQXV0aG9yaXR5MRcwFQYDVQQDEw5D" +
            "RkNBIFRFU1QgT0NBMTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALiL" +
            "J/BrdvHSbXNfLIMTwUg9tDtVjMRGXOl6aZnu9IpxjI5SMUJ4hVwgJnmbTokxs6GF" +
            "IXKsCLSm5H1jHLI22ysc/ltByEybLWj5jjJuC9+Uknbl3/Ls1RBG6MogUCqZckuo" +
            "hKrf5DmlV3C/jVLxGn3pUeanvmqVUi4TKpXxgm5QqKSPF8VtQY4qCpNcQwwZqbMr" +
            "D+IfJtfpGAeVrP+Kg6i1t65seeEnVSaLhqpRUDU0PTblOuUv3OhiKJWA3cYWxUrg" +
            "7U7SIHNJLSEUWmjy4mKty+g7Cnjzt29F9qXFb6oB2mR8yt4GHCilw1Rc5RBXY63H" +
            "eTuOwdtGE3M2p7Q++OECAwEAAaOBmDCBlTAfBgNVHSMEGDAWgBR03sWNCn0QGqpp" +
            "g1tNIc6Gm8xxODAMBgNVHRMEBTADAQH/MDgGA1UdHwQxMC8wLaAroCmGJ2h0dHA6" +
            "Ly8yMTAuNzQuNDIuMy90ZXN0cmNhL1JTQS9jcmwxLmNybDALBgNVHQ8EBAMCAQYw" +
            "HQYDVR0OBBYEFM9wnWHrnXwuuPfLAkD3CZ3+M3SAMA0GCSqGSIb3DQEBBQUAA4IB" +
            "AQC0JOazrbkk0XMxMMeBCc3lgBId1RjQLgWUZ7zaUISpPstGIrE5A9aB6Ppq0Sxl" +
            "pt2gkFhPEKUqgOFN1CzCDEbP3n4H0chqK1DOMrgTCD8ID5UW+ECTYNe35rZ+1JiF" +
            "lOPEhFL3pv6XSkiKTfDnjum8+wFwUBGlfoWK1Hcx0P2Hk1jcZZKwGTx1IAkesF83" +
            "pufhxHE2Ur7W4d4tfp+eC7XXcA91pdd+VUrAfkj9eKHcDEYZz66HvHzmt6rtJVBa" +
            "pwrtCi9pW3rcm8c/1jSnEETZIaokai0fD7260h/LkD/GrNCibSWxFj1CqyP9Y5Yv" +
            "cj6aA5LnUcJYeNkrQ3V4XvVc" +
            "-----END CERTIFICATE-----";

        #endregion

#else

        #region 正式证书

        private const string ACPPRODENCCER = "-----BEGIN CERTIFICATE-----" +
            "MIIEEDCCAvigAwIBAgIFEBNHISEwDQYJKoZIhvcNAQEFBQAwITELMAkGA1UEBhMC" +
            "Q04xEjAQBgNVBAoTCUNGQ0EgT0NBMTAeFw0xNDAxMDIwOTA3MThaFw0xOTAxMDIw" +
            "OTA3MThaMIGFMQswCQYDVQQGEwJjbjESMBAGA1UEChMJQ0ZDQSBPQ0ExMRYwFAYD" +
            "VQQLEw1Mb2NhbCBSQSBPQ0ExMRQwEgYDVQQLEwtFbnRlcnByaXNlczE0MDIGA1UE" +
            "AxQrMDQxQFoxMjAwMDQwMDAwOlNJR05AMDAwNDAwMDA6U0lHTkAwMDAwMDAwMjCC" +
            "ASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAN3BsX/kyJ2BRh2IW4GyYfFs" +
            "4g5RcIEPhzGfo0IztDeqM8cfwRGqklavYHuZfFG6XPb1N/p1rXQlwyBJ6UQwgnVu" +
            "ACyWa9+Cqf664XNp+vIVx9grqor9lzrJK6jTPrd57AJNuhpFGAW0dRAjfF5ZAdpZ" +
            "56gYiWFgp2zTIXGjXoA0MHqYKBGMMYdFSZ3EkRhsJ0jyJeaBep2VmsFDtODliW0X" +
            "5T+cSgPn1+zzlHwu1svmBYxh3ZpEY3hEwR8KQwja5d5b0kUZ5eCepg9OyB8y+K6P" +
            "5VxCN8YHwVsXFYz1rpEmjGp2qObO2A+vyJaaCdtB3AeppsGLwGCIXQ/t5wyjOqEC" +
            "AwEAAaOB6TCB5jAfBgNVHSMEGDAWgBTR2+mIguXdGo9MqgCMvnzyqxv22TBIBgNV" +
            "HSAEQTA/MD0GCGCBHIbvKgEBMDEwLwYIKwYBBQUHAgEWI2h0dHA6Ly93d3cuY2Zj" +
            "YS5jb20uY24vdXMvdXMtMTQuaHRtMDgGA1UdHwQxMC8wLaAroCmGJ2h0dHA6Ly9j" +
            "cmwuY2ZjYS5jb20uY24vUlNBL2NybDE1Mjk4LmNybDALBgNVHQ8EBAMCA+gwHQYD" +
            "VR0OBBYEFAIndZ83GnekyNLXDbnxhC6+p4aCMBMGA1UdJQQMMAoGCCsGAQUFBwMC" +
            "MA0GCSqGSIb3DQEBBQUAA4IBAQBKgpV4bGWiQdNy38evxrR8NIWHIwSinNL7JGZz" +
            "EFMRc0ld8PRcztdK6NpmZSbJLz/6HUD+ou8CrFHxfgvWleoQzSZtwdICb06MTz3T" +
            "gp8RyJNZEQ3HErDRGSa0vecT1Tuk1qAbrxZ1KRWkjyHciam7Sr8junEBfSx3VaZ+" +
            "JU/wKs3gb1GO/h9VD5YSKqXYqvQ0CZamJgFDgkgXP8+3+HIe64BRspkTmlnR+Zf0" +
            "ZUYqMgsGF9kSy2yajSkJvyyriezko9VrIBqvITM6615W9YxaDAfQISmw8bjpUg99" +
            "rs3vzfwHTAGXiDXyWng+mVe8UDOv0roIJxaWzfx1XZFVEuCR" +
            "-----END CERTIFICATE-----";
        private const string ACPPRODROOTCER = "-----BEGIN CERTIFICATE-----" +
            "MIIDHzCCAgegAwIBAgIEGCVShDANBgkqhkiG9w0BAQUFADAiMQswCQYDVQQGEwJD" +
            "TjETMBEGA1UEChMKQ0ZDQSBDUyBDQTAeFw0xMTA1MjAxNTI3MDVaFw00MTA1MTIx" +
            "NTI3MDVaMCIxCzAJBgNVBAYTAkNOMRMwEQYDVQQKEwpDRkNBIENTIENBMIIBIjAN" +
            "BgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAshVScIOG1yHCTl2FSU1XHONBWXcS" +
            "tlJr79ZeOZ8GkH+YFG0U60iaveoYBb4B7gAcc/pprxHEhgVr8uRBjlOAfp9vLrRX" +
            "1dJH00j93T7DXVRchGVjD/4x3zyjKLuNekeiBcA+7ry0m3FCHGSj31Kocw4kfrUc" +
            "+BsDz4gIXJtsu617/AO4bvA+a+nBfxhwnIRNItsCLkO6qJfGIzeGMO+IYJ1s4XzL" +
            "XCsrXM4ofUj6jblh5Cqo7ZwFRa0dV5lmgOz8xBYzvn/t+8HoIlwRq7zAbw1I8IpC" +
            "VYcaE4+aPBK47hY9o9q9+JAqKbYQQwjLW4MSv4GNCKCVHQCeHD0QLoxtQwIDAQAB" +
            "o10wWzAfBgNVHSMEGDAWgBRYacnV3RSzE6BxPHwDjQPmPQ+OATAMBgNVHRMEBTAD" +
            "AQH/MAsGA1UdDwQEAwIBBjAdBgNVHQ4EFgQUWGnJ1d0UsxOgcTx8A40D5j0PjgEw" +
            "DQYJKoZIhvcNAQEFBQADggEBAGXTChXGscLtYcWtYF8v9OLdvzEWXclSAbyPI15S" +
            "PYVrTleGMfUWraszz9CUrypuoYiWTnhr8ldOZ5HmR1IYIcs/XFQztTruAyCbAnMQ" +
            "s2il3WqEZ1N5N5AG9PeAg/EYoLxJ9+lHpNa9fLjMK9x9IzDu6/qtkdDN6NuJgqTX" +
            "6gk8RpSl8PSaxxhmyum6t1adm5S7fj2IlbWdjHcRUQEBn5l7/MNaleGh1q7+5fc3" +
            "sLIC+udfA42SLYrDCAQGJ8UK5ec37hKSKQxT1WXJnSgP5hcYd+Jmb3AeXz7PoR7t" +
            "8TsDYnMum7OHLlLlxm+wmZ1ew+SCTlz1nwhPaDqWOIZmSXc=" +
            "-----END CERTIFICATE-----";
        private const string ACPPRODMIDDLECER = "-----BEGIN CERTIFICATE-----" +
            "MIIDgzCCAmugAwIBAgIFEAAAABkwDQYJKoZIhvcNAQEFBQAwIjELMAkGA1UEBhMC" +
            "Q04xEzARBgNVBAoTCkNGQ0EgQ1MgQ0EwHhcNMTEwNTIwMTc0MTI0WhcNMzEwNTE1" +
            "MTc0MTI0WjAhMQswCQYDVQQGEwJDTjESMBAGA1UEChMJQ0ZDQSBPQ0ExMIIBIjAN" +
            "BgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEApR8eQ7of5iMfk2hlgGC9Z0jcpiFs" +
            "f6ligck4WoLNgEiYg7jWL0jKkcxxlTt79maSEHRWHbdYCIQ0gq/xdIY6EUbIJ4Wd" +
            "J46dTHBOL+OVE93P3Qd422WiDMTkYsH3Mb2BcTKK/1B4jPNCL0eqCDmJrYgBiAo8" +
            "FZqm9zHmDNZHwRF/5NsyoqwuZBbTiU+JVZqrxZRtQY2k74H+umQXBNoxxHlsi0QQ" +
            "itqrhuLczY21Q0IsAAYkAuok1amDdTvNBNeP2c0lKs6N8tOfCDzi6Xz+VxMs7nJj" +
            "6sz5GCR1d1rRQDh59DfmxKlWVzAiSDIdAfBAbICLE0NQNAhYulwUSJS1wQIDAQAB" +
            "o4HAMIG9MB8GA1UdIwQYMBaAFFhpydXdFLMToHE8fAONA+Y9D44BMAwGA1UdEwQF" +
            "MAMBAf8wYAYDVR0fBFkwVzBVoFOgUaRPME0xCzAJBgNVBAYTAkNOMRMwEQYDVQQK" +
            "EwpDRkNBIENTIENBMQwwCgYDVQQLEwNDUkwxDDAKBgNVBAsTA1JTQTENMAsGA1UE" +
            "AxMEY3JsMTALBgNVHQ8EBAMCAQYwHQYDVR0OBBYEFNHb6YiC5d0aj0yqAIy+fPKr" +
            "G/bZMA0GCSqGSIb3DQEBBQUAA4IBAQAhsQGgMpueLi4lVn+TmU8MN7sO+T9/fg1S" +
            "KPKedwPZ4arpRC2etLtQ1YC4xK8LdZcQVC3cCJ3MXeBLPJS0fVOtMI10LIhasYyy" +
            "U1Zj3OSwPSBbHXwMiaTdphDMG3ZowZ7x/4OL/QS90+Zp8zfCxt9uPWPKS6QR81oa" +
            "nkrXhPJ13zBMhbP8ZpakhSfMqYG8z9l41ujmI92NahrFivl/qQrIVP6A+8KsS45d" +
            "0MVnkM2ggqDDi42KZ05zkpwpLdGOSfZ+V54GqfhjgtYxkd5I3vAGNad0hWPuIQ59" +
            "H2HILbGHI45vG7803rh5CsyqvaW1KUD4i2sLkgs9vI432PyPJVBi" +
            "-----END CERTIFICATE-----";

        #endregion

#endif

        #endregion

        #region 证书操作

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

        #endregion

        #region 签名

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

        #endregion

        #region 验签

        /// <summary>
        /// 验签
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="sign">签名</param>
        /// <param name="signPubKeyCert">验证公钥</param>
        /// <returns></returns>
        public static bool VerifyData(string data, string sign, string signPubKeyCert)
        {
            byte[] dataByte = Encoding.UTF8.GetBytes(EncryptUtil.SHA256(data));
            byte[] signByte = Convert.FromBase64String(sign);

            X509Certificate x509Cert = VerifyAndGetPubKey(signPubKeyCert);
            if (x509Cert == null)
            {
                return false;
            }
            return VerifySignature(x509Cert.GetPublicKey(), signByte, dataByte);
        }

        private static bool VerifySignature(AsymmetricKeyParameter key, byte[] base64DecodingSignStr, byte[] srcByte)
        {
            ISigner verifier = SignerUtilities.GetSigner("SHA256WithRSA");
            verifier.Init(false, key);
            verifier.BlockUpdate(srcByte, 0, srcByte.Length);
            return verifier.VerifySignature(base64DecodingSignStr);
        }

        private static X509Certificate VerifyAndGetPubKey(string signPubKeyCert)
        {
            X509Certificate x509Cert = GetPubKeyCert(signPubKeyCert);
            if (x509Cert == null)
            {
                return null;
            }

            return VerifyCertificate(x509Cert) ? x509Cert : null;
        }

        private static bool VerifyCertificate(X509Certificate x509Cert)
        {
            string cn = GetIdentitiesFromCertficate(x509Cert);
            try
            {
                x509Cert.CheckValidity();//验证有效期
                if (!VerifyCertificateChain(x509Cert))//验证书链
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            string unionpayCnName = "中国银联股份有限公司";

#if DEBUG

            // 验证公钥是否属于银联
            if (!unionpayCnName.Equals(cn))
            {
                return false;
            }

#else

            if (!unionpayCnName.Equals(cn) && !"00040000:SIGN".Equals(cn))
            {
                return false;
            }

#endif

            return true;
        }

        private static bool VerifyCertificateChain(X509Certificate cert)
        {
            if (cert is null)
            {
                return false;
            }

#if DEBUG
            X509Certificate rootCert = GetCert(ACPTESTROOTCER);
#else
            X509Certificate rootCert = GetCert(ACPPRODROOTCER);
#endif
            if (rootCert is null)
            {
                return false;
            }
#if DEBUG
            X509Certificate middleCert = GetCert(ACPTESTMIDDLECER);
#else
            X509Certificate middleCert = GetCert(ACPPRODMIDDLECER);
#endif
            if (middleCert is null)
            {
                return false;
            }

            try
            {
                X509CertStoreSelector selector = new X509CertStoreSelector
                {
                    Subject = cert.SubjectDN
                };

                ISet trustAnchors = new HashSet
                {
                    new TrustAnchor(rootCert, null)
                };
                PkixBuilderParameters pkixParams = new PkixBuilderParameters(trustAnchors, selector);

                IList intermediateCerts = new ArrayList
                {
                    rootCert,
                    middleCert,
                    cert
                };

                pkixParams.IsRevocationEnabled = false;

                IX509Store intermediateCertStore = X509StoreFactory.Create(
                    "Certificate/Collection",
                    new X509CollectionStoreParameters(intermediateCerts));
                pkixParams.AddStore(intermediateCertStore);

                PkixCertPathBuilder pathBuilder = new PkixCertPathBuilder();
                PkixCertPathBuilderResult result = pathBuilder.Build(pkixParams);
                PkixCertPath path = result.CertPath;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static X509Certificate GetCert(string cert)
        {
            try
            {
                byte[] certByte = Encoding.UTF8.GetBytes(cert);
                return new X509CertificateParser().ReadCertificate(certByte);
            }
            catch
            {
                return null;
            }
        }

        private static string GetIdentitiesFromCertficate(X509Certificate aCert)
        {
            string tDN = aCert.SubjectDN.ToString();
            string tPart = "";
            if ((tDN != null))
            {
                string[] tSplitStr = tDN.Substring(tDN.IndexOf("CN=")).Split("@".ToCharArray());
                if (tSplitStr != null && tSplitStr.Length > 2 && tSplitStr[2] != null)
                {
                    tPart = tSplitStr[2];
                }
            }
            return tPart;
        }

        private static X509Certificate GetPubKeyCert(string pubKeyCert)
        {
            try
            {
                pubKeyCert = pubKeyCert
                    .Replace("-----END CERTIFICATE-----", "")
                    .Replace("-----BEGIN CERTIFICATE-----", "");
                byte[] x509CertBytes = Convert.FromBase64String(pubKeyCert);
                X509CertificateParser cf = new X509CertificateParser();
                X509Certificate x509Cert = cf.ReadCertificate(x509CertBytes);
                return x509Cert;
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
