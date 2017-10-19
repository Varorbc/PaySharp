using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace alipay
{
    /// <summary>
    /// config 的摘要说明
    /// </summary>
    public class config
    {
        public config()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        // 应用ID,您的APPID
        public static string app_id = "2017093009005992";

        // 支付宝网关
        public static string gatewayUrl = "https://openapi.alipay.com/gateway.do";

        // 商户私钥，您的原始格式RSA私钥
        public static string private_key = "MIIEpAIBAAKCAQEAyC43UbsE5XZ2Pmqg1YgzeCqAMk4HOH8fYHslseeSgKxyDjybjqM0yjGIJry1FRmVvLnY7v8jURgwr7d/pDCSRdoHa6zaxuSzg0OlieNmujae34YZ54PmFxULZW0BHSdzmx3OIYK2GarRECkds531ZzpbLdRXqsxQf5G26JZLIFxmNuh/VjBjJ6Hic1WOFT+FCYyi8om+LkPn3jELeA7LPLXzFqzzxx0vo4yiAePrsX5WucWxf+Y8rZoDhRIy/cPtQECXi9SiAWOJe/82JqjVjfpowf3QN7UJHsA82RBloAS4lvvDGJA7a+8DDlqpqPer8cS41Dv5r39iqtJUybDqoQIDAQABAoIBAHi39kBhiihe8hvd7bQX+QIEj17G02/sqZ1jZm4M+rqCRB31ytGP9qvghvzlXEanMTeo0/v8/O1Qqzusa1s2t19MhqEWkrDTBraoOtIWwsKVYeXmVwTY9A8Db+XwgHV2by8iIEbxLqP38S/Pu8uv/GgONyJCJcQohnsIAsfsqs2OGggz+PplZaXJfUkPomWkRdHM9ZWWDLrCIlmRSHLmhHEtFJaXD083kqo437qra58Amw/n+2gH57utbAQ9V3YQFjD8zW511prC+mB6N/WUlaLstkxswGJ16obEJfQ0r8wYHx14ep6UKGyi3YXlMHcteI8gz+uFx4RuVV9EotdXagECgYEA7AEz9oPFYlW1H15OkDGy8yBnpJwIBu2CQLxINsxhrLIAZ2Bgxqcsv+D9CpnYCBDisbXoGoyMK6XaSypBMRKe2y8yRv4c+w00rcKHtGfRjzSJ5NQO0Tv+q8vKY+cd6BuJ6OUQw82ICLANIfHJZNxtvtTCmmqBwSJDpcQJQXmKXTECgYEA2SQCSBWZZONkvhdJ15K+4IHP2HRbYWi+C1OvKzUiK5bdJm77zia4yJEJo5Y/sY3mV3OK0Bgb7IAaxL3i0oH+WNTwbNoGpMlYHKuj4x1453ITyjOwPNj6g27FG1YSIDzhB6ZC4dBlkehi/7gIlIiQt1wkIZ+ltOqgI5IqIdXoSHECgYB3zCiHYt4oC1+UW7e/hCrVNUbHDRkaAygSGkEB5/9QvU5tK0QUsrmJcPihj/RUK9YW5UK7b0qbwWWsr/dFpLEUi8GWvdkSKuLprQxbrDN44O96Q5Z96Vld9WV4DtJkhs4bdWNsMQFzf4I7D9PuKeJfcvqRjaztz6nNFFSqcrqkkQKBgQCJKlUCohpG/9notp9fvQQ0n+viyQXcj6TVVOSnf6X5MRC8MYmBHTbHA8+59bSAfanO/l7muwQQro+6TlUVMyaviLvjlwpxV/sACXC6jCiO06IqreIbXdlJ41RBw2op0Ss5gM5pBRLUS58V+HP7GBWKrnrofofXtAq6zZ8txok4EQKBgQCXrTeGMs7ECfehLz64qZtPkiQbNwupg938Z40Qru/G1GR9u0kmN7ibTyYauI6NNVHGEZa373EBEkacfN+kkkLQMs1tj5Zrlw+iITm+ad/irpXQZS/NHCcrg6h82vu0LcgiKnHKlmW6K5ne0w4LqmsmRCm7JdJjt9WlapAs0ticiw==";

        // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
        public static string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA9NT40P1EYDxWSiBWsPJh2/vdYPVDg3n+UALO6wXmeOHDY9un7F6M2/QBeceXbJuRxfXKpKRScugKcnz4Wh1KMWTk1kfjhoyDXHtZOFO/HFXJiK1xF1IZsxCFbyDo7GxLwhIx1AIIHnjxFGPiRk6yUZRYlEUjADpyEY/xTmAJBdcW8AK8yw4CzaP0OzwBXZsnIiMyp5vvkiLNvaKtiUz2USOZFITmrdPcYsFHVeMNhMK1upzcEFKVUp6SytkotGVWD5d5TNBSFQuxeCGXGqIvkSTcZDS+L5mg3D/OtIJLBcdUf+z2qKEsOgaOA9P2TVnyojXJKq0QTcG4+nz0YGEVJQIDAQAB";

        // 签名方式
        public static string sign_type = "RSA2";

        // 编码格式
        public static string charset = "UTF-8";
    }
}