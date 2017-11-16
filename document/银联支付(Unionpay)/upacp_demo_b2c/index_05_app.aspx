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
  <title>控件支付产品示例</title>
  <link rel="stylesheet" href="static/jquery-ui.min.css">
  <script src="static/jquery-1.11.2.min.js"></script>
  <script src="static/jquery-ui.min.js"></script>
  <script src="static/demo.js"></script>
  <script>
      $(function () {
          setApiDemoTabs("#tabs-purchase");
          setApiDemoTabs("#tabs-preauth");
      });
  </script>
  <link rel="stylesheet" href="static/demo.css">

</head>
<body style="background-color:#e5eecc;">
<div id="wrapper">

<div id="header">
<h2>控件支付产品示例</h2>

</div>

<div id="tabs-api">
  <ul>
    <li><a href="#tabs-api-1">前言</a></li>
    <li><a href="#tabs-api-2">消费样例</a></li>
    <li><a href="#tabs-api-3">预授权样例</a></li>
    <li><a href="#tabs-api-4">常见开发问题</a></li>
  </ul>
  
  <div id="tabs-api-1">
    <!--#include file="/pages/api_05_app/introduction.htm"--> 
  </div>
  
  <div id="tabs-api-4">
     <!--#include file="/pages/dev_faq.htm"--> 
  </div>
  
  <div id="tabs-api-2">
	<div id="tabs-purchase">
	  <ul>
	    <li><a href="#tabs-purchase-1">说明</a></li>
	    <li><a href="pages/api_05_app/consume.aspx">消费获取tn</a></li>
	    <li><a href="pages/api_05_app/query.aspx">交易状态查询</a></li>
			<li><a href="pages/api_05_app/consume_undo.aspx">消费撤销</a></li>
			<li><a href="pages/api_05_app/refund.aspx">退货</a></li>
			<li><a href="pages/api_05_app/file_transfer.aspx">对账文件下载</a></li>
	  </ul>
	  <div id="tabs-purchase-1">
             <!--#include file="/pages/api_05_app/consume_intro.htm"--> 
	  </div>
	</div>
  </div>
  
  <div id="tabs-api-3">
	  <div id="tabs-preauth">
		  <ul>
		    <li><a href="#tabs-preauth-1">说明</a></li>
		    <li><a href="pages/api_05_app/preauth.aspx">预授权获取tn</a></li>
		    <li><a href="pages/api_05_app/query.aspx">交易状态查询</a></li>
		    <li><a href="pages/api_05_app/preauth_finish.aspx">预授权完成</a></li>
		    <li><a href="pages/api_05_app/preauth_undo.aspx">预授权撤销</a></li>
		    <li><a href="pages/api_05_app/preauth_finish_undo.aspx">预授权完成撤销</a></li>
		    <li><a href="pages/api_05_app/refund.aspx">退货</a></li>
		    <li><a href="pages/api_05_app/file_transfer.aspx">对账文件下载</a></li>
		  </ul>
		  <div id="tabs-preauth-1">
             <!--#include file="/pages/api_05_app/preauth_intro.htm"--> 
	      </div>
		</div>
	  </div> <!-- end of tabs-api-3-->
  </div> <!-- end of tabs-api-->
</div><!-- end of wrapper-->
 
 
</body>
</html>