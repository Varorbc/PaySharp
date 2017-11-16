<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrontRcvResponse.aspx.cs" Inherits="upacp_demo_app.demo.api_05_app.FrontRcvResponse" %>

<%@ Import Namespace="com.unionpay.acp.sdk" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table  border="1">
    <%
        // **************演示前台接收银联返回报文交易结果展示***********************
        
        if (Request.HttpMethod == "POST")
        {
            // 使用Dictionary保存参数
            Dictionary<string, string> resData = new Dictionary<string, string>();

            NameValueCollection coll = Request.Form;

            string[] requestItem = coll.AllKeys;

            for (int i = 0; i < requestItem.Length; i++)
            {
                resData.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

             // 返回报文中不包含UPOG,表示Server端正确接收交易请求,则需要验证Server端返回报文的签名
            if (SDKUtil.Validate(resData, System.Text.Encoding.UTF8))
                {
                    //Response.Write("商户端验证返回报文签名成功\n");

                    string respcode = resData["respCode"]; //00、A6为成功，其余为失败。其他字段也可按此方式获取。

                    //如果卡号我们业务配了会返回且配了需要加密的话，请按此方法解密
                    //if(resData.ContainsKey("accNo"))
                    //{
                    //    string accNo = SecurityUtil.DecryptData(resData["accNo"], System.Text.Encoding.UTF8); 
                    //}

                    //商户端根据返回报文内容处理自己的业务逻辑 ,DEMO此处只输出报文结果
                    StringBuilder builder = new StringBuilder();

                    builder.Append("<tr><td align=\"center\" colspan=\"2\"><b>商户端接收银联返回报文并按照表格形式输出结果</b></td></tr>");
                    
                    for (int i = 0; i < requestItem.Length; i++)
                    {
                        builder.Append("<tr><td width=\"30%\" align=\"right\">" + requestItem[i] + "</td><td style='word-break:break-all'>" + Request.Form[requestItem[i]] + "</td></tr>");
                    }
                    
                    builder.Append("<tr><td width=\"30%\" align=\"right\">商户端验证银联返回报文结果</td><td>验证签名成功.</td></tr>");
                    Response.Write(builder.ToString());
                    
                }
                else
                {
                    Response.Write("<tr><td width=\"30%\" align=\"right\">商户端验证银联返回报文结果</td><td>验证签名失败.</td></tr>");
                }       
        
        }

         %>
         </table>
    </form>
</body>

</html>

    
    
   