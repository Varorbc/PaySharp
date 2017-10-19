using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class CustomerConfig
{
    static CustomerConfig()
    {
        //易宝支付提供的测试账号
        //网银2015收银台
        //商户密钥


        //merchantAccount = "10012442782";
        //merchantKey = "mP42238826nuW64r7yh26DGK34o2L2m81L25RG32lD7Lo1058A7iJ28at6QS";


        //2013网关
        merchantAccount = "10000457067";

        //相应的测试密钥
        merchantKey = "U26po59182dV8d7654bo24o5z369408u4sQ3To9j6QuopAbo3gwj4h33mro4";
    }
    /// <summary>
    /// 商户编号
    /// </summary>
    public static string merchantAccount { get; set; }
    /// <summary>
    /// 商户密钥
    /// </summary>
    public static string merchantKey { get; private set; }
}
