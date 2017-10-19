<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallBack.aspx.cs" Inherits="OnlinePC.CallBack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>测试功能请求结果</title>
    <link href="css/temp.css" rel="Stylesheet" type="text/css" />
</head>

<body>
    <form method="post" class="smart-green" runat="server">

        <h1 id="theme" runat="server">返回信息解析</h1>

        <label>
            <span>易宝支付回调返回的data为：</span>
           <textarea id="LabData" rows="15" cols="30"  runat="server"></textarea>
        </label>

        <label>
            <span>返回的信息类别</span>
            <input id="Labtype" type="text" placeholder="" runat="server"/>
        </label>

    </form>
</body>
</html>
