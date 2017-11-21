<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index_03_wtz.aspx.cs" Inherits="upacp_demo_wtz.index_09_dk" %>

<!doctype html>

<html xmlns="http://www.w3.org/1999/xhtml">
<!-- 

  借地写说明：
  jquery-ui的说明参考：http://www.runoob.com/jqueryui/jqueryui-tutorial.html
  jquery的说明参考：http://www.w3school.com.cn/jquery/index.asp
  
  tabs-api为横向的标签，下面定义的div比如tabs-purchase是竖向的标签，按已有的往下添加，名字别重复就行。
  
  新增横向标签：
  1. <div id="tabs-api"><ul><li>下面新加个a标签，指向一个锚点。
  2. 上一条的<ul>同级别下新加一个<div>，id使用上一条锚点指定的id。
  
  新增纵向标签：
  1. js加一行，设置纵向标签的参数。
  2. 总之参考已有的样例吧。
  
-->

<head>
  <meta charset="utf-8">
  <title>无跳转产品示例</title>
  <link rel="stylesheet" href="static/jquery-ui.min.css">
  <script src="static/jquery-1.11.2.min.js"></script>
  <script src="static/jquery-ui.min.js"></script>
  <script src="static/demo.js"></script>
  <script>
      $(function () {
          setApiDemoTabs("#tabs-front");
          setApiDemoTabs("#tabs-back");
          setApiDemoTabs("#tabs-open-pay");
      });
  </script>
  <link rel="stylesheet" href="static/demo.css">

</head>
<body style="background-color:#e5eecc;">
<div id="wrapper">

<div id="header">
<h2>无跳转产品示例</h2>

</div>

<div id="tabs-api">
  <ul>
    <li><a href="#tabs-api-1">前言</a></li>
    <li><a href="#tabs-api-2">银联侧开通</a></li>
    <li><a href="#tabs-api-3">商户侧开通</a></li>
    <li><a href="#tabs-api-5">银联侧开通（开通并支付）</a></li>
    <li><a href="#tabs-api-4">常见开发问题</a></li>
  </ul>
  
  <div id="tabs-api-1">
    <!--#include file="/pages/api_03_wtz/introduction.htm"--> 
  </div>
  
  <div id="tabs-api-4">
     <!--#include file="/pages/dev_faq.htm"--> 
  </div>
  
  <div id="tabs-api-2">
	<div id="tabs-front">
	  <ul>
	    <li><a href="#tabs-front-1">说明</a></li>
	    <li><a href="pages/api_03_wtz/open_query.aspx">开通状态查询</a></li>
	    <li><a href="pages/api_03_wtz/front_open.aspx">开通</a></li>
	    <li><a href="pages/api_03_wtz/sms_consume.aspx">获取消费验证码</a></li>
	    <li><a href="pages/api_03_wtz/consume.aspx">消费</a></li>
	    <li><a href="pages/api_03_wtz/query.aspx">交易状态查询</a></li>
	    <li><a href="pages/api_03_wtz/consume_undo.aspx">消费撤销</a></li>
	    <li><a href="pages/api_03_wtz/refund.aspx">退货</a></li>
		<li><a href="pages/api_03_wtz/file_transfer.aspx">对账文件下载</a></li>
	  </ul>
	  <div id="tabs-front-1">
             <!--#include file="/pages/api_03_wtz/front_intro.htm"--> 
	  </div>
	</div>
  </div>
  
  <div id="tabs-api-3">
	<div id="tabs-back">
	  <ul>
	    <li><a href="#tabs-back-1">说明</a></li>
	    <li><a href="pages/api_03_wtz/sms_open.aspx">获取开通验证码</a></li>
	    <li><a href="pages/api_03_wtz/back_open.aspx">开通</a></li>
	    <li><a href="pages/api_03_wtz/sms_consume.aspx">获取消费验证码</a></li>
	    <li><a href="pages/api_03_wtz/consume.aspx">消费</a></li>
	    <li><a href="pages/api_03_wtz/query.aspx">交易状态查询</a></li>
	    <li><a href="pages/api_03_wtz/consume_undo.aspx">消费撤销</a></li>
	    <li><a href="pages/api_03_wtz/refund.aspx">退货</a></li>
		<li><a href="pages/api_03_wtz/file_transfer.aspx">对账文件下载</a></li>
	  </ul>
	  <div id="tabs-back-1">
             <!--#include file="/pages/api_03_wtz/back_intro.htm"--> 
	  </div>
	</div>
  </div>
  

  <div id="tabs-api-5">
	  <div id="tabs-open-pay">
		  <ul>
		    <li><a href="#tabs-open-pay-1">说明</a></li>
	        <li><a href="pages/api_03_wtz/open_query.aspx">开通状态查询</a></li>
	        <li><a href="pages/api_03_wtz/front_open_pay.aspx">开通并支付</a></li>
	        <li><a href="pages/api_03_wtz/sms_consume.aspx">获取消费验证码</a></li>
	        <li><a href="pages/api_03_wtz/consume.aspx">消费</a></li>
	        <li><a href="pages/api_03_wtz/query.aspx">交易状态查询</a></li>
	        <li><a href="pages/api_03_wtz/consume_undo.aspx">消费撤销</a></li>
	        <li><a href="pages/api_03_wtz/refund.aspx">退货</a></li>
		    <li><a href="pages/api_03_wtz/file_transfer.aspx">对账文件下载</a></li>
		  </ul>
		  <div id="tabs-open-pay-1">
             <!--#include file="/pages/api_03_wtz/open_pay_intro.htm"--> 
	      </div>
		</div>
	  </div> <!-- end of tabs-api-3-->
  
  </div> <!-- end of tabs-api-->
</div><!-- end of wrapper-->
 
 
</body>
</html>