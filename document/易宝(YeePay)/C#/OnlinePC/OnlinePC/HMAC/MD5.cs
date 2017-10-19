using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;


public class MD5
{

    public MD5() { }


    /// <summary>
    /// 签名生成方法
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string HmacSign(string value)
    {

        byte[] bytes = Encoding.UTF8.GetBytes(value.Trim());
        System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
        byte[] output = md5.ComputeHash(bytes);
        String result = BitConverter.ToString(output).Replace("-", "");

        return result;
    }


}
