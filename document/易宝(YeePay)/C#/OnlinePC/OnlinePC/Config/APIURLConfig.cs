using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class APIURLConfig
{

    static APIURLConfig()
    {
        //网银支付地址
        pay = "https://www.yeepay.com/app-merchant-proxy/node";
        //查询地址
        QueryableOrder = "https://cha.yeepay.com/app-merchant-proxy/command";
        //单笔退款接口
        refund = "https://cha.yeepay.com/app-merchant-proxy/command";
        //退款查询
        refundOrder = "https://www.yeepay.com/app-merchant-proxy/node";
        //单笔订单撤销
        orderBack = "https://cha.yeepay.com/app-merchant-proxy/command";
        //充值支付
        recharge = "http://www.yeepay.com/app-merchant-proxy/node";

    }
    /// <summary>
    /// 单笔订单撤销
    /// </summary>
    public static string orderBack { get; private set; }
    /// <summary>
    /// 网银支付地址
    /// </summary>
    public static string pay { get; private set; }
    /// <summary>
    /// 查询地址
    /// </summary>
    public static string QueryableOrder { get; private set; }
    /// <summary>
    /// 充值支付
    /// </summary>
    public static string recharge { get; private set; }
    /// <summary>
    /// 单笔退款接口
    /// </summary>
    public static string refund { get; private set; }
    /// <summary>
    /// 退款查询
    /// </summary>
    public static string refundOrder { get; private set; }
}
