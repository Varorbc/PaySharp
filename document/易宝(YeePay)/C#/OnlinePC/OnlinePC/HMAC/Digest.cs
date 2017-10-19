using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


public class Digest
{

    public Digest() { }

    /// <summary>
    /// 生成请求hmac签名
    /// </summary>
    public static string CreateHmac(Dictionary<String, String> data)
    {
        //输出
        String resp = "";
        //字符串
        String unsignString = "";
        //商户key
        string key = CustomerConfig.merchantKey;
        List<String> nameList = new List<String>(data.Keys);
        //首先按字段名的字典序排列
        nameList.Sort();
        foreach (String name in nameList)
        {
            String value = data[name];
            if (value != null)
            {
                unsignString += name + "=" + value + "&";
            }
        }
        //后面加上key然后md5签名
        unsignString += "key=" + key;
        try
        {
            resp = MD5.HmacSign(unsignString);
        }
        catch (Exception e)
        {
            e.ToString();
        }
        resp = resp.ToUpper();
        return resp;
    }


    public static string CreateHmac(string aValue)
    {
        string aKey = CustomerConfig.merchantKey;
        byte[] k_ipad = new byte[64];
        byte[] k_opad = new byte[64];
        byte[] keyb;
        byte[] Value;
        keyb = Encoding.UTF8.GetBytes(aKey);
        Value = Encoding.UTF8.GetBytes(aValue);

        for (int i = keyb.Length; i < 64; i++)
            k_ipad[i] = 54;

        for (int i = keyb.Length; i < 64; i++)
            k_opad[i] = 92;

        for (int i = 0; i < keyb.Length; i++)
        {
            k_ipad[i] = (byte)(keyb[i] ^ 0x36);
            k_opad[i] = (byte)(keyb[i] ^ 0x5c);
        }

        HmacMD5 md = new HmacMD5();

        md.update(k_ipad, (uint)k_ipad.Length);
        md.update(Value, (uint)Value.Length);
        byte[] dg = md.finalize();
        md.init();
        md.update(k_opad, (uint)k_opad.Length);
        md.update(dg, 16);
        dg = md.finalize();

        return toHex(dg);
    }

    public static string toHex(byte[] input)
    {
        if (input == null)
            return null;

        StringBuilder output = new StringBuilder(input.Length * 2);

        for (int i = 0; i < input.Length; i++)
        {
            int current = input[i] & 0xff;
            if (current < 16)
                output.Append("0");
            output.Append(current.ToString("x"));
        }

        return output.ToString();
    }


}