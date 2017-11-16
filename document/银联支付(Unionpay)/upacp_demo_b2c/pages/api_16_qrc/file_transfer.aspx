<form class="api-form" method="post" action="demo/api_16_qrc/Form_7_2_FileTransfer.aspx" target="_blank">
<p>
<label>商户号：</label>
<input id="merId" pattern="\d{15}" type="text" name="merId" placeholder="" value="700000000000001" title="请替换实际商户号测试，自助化平台注册的商户号（777开头的）无法测试此接口，如无真实商户号，请使用700000000000001测试此接口" required="required"/>
</p>
<p>
<label>订单发送时间：</label>
<input id="txnTime" pattern="\d{14}" type="text" name="txnTime" placeholder="订单发送时间" value="<%= DateTime.Now.ToString("yyyyMMddHHmmss") %>" title="取北京时间，YYYYMMDDhhmmss格式" required="required"/>
</p>
<p>
<label>清算日期：</label>
<input id="settleDate" pattern="\d{4}" type="text" name="settleDate" placeholder="清算日期" value="0119" title="格式为MMDD" required="required"/>
</p>
<p>
<label>&nbsp;</label>
<input type="submit" class="button" value="提交" />
<input type="button" class="showFaqBtn" value="遇到问题？" />
</p>
</form>

<hr />
<p class="faq">
* 此demo代码默认会将文件存放至D:/file/目录，请先建立此文件夹并保证有读写权限。如需修改其他路径，请至Form_7_2_FileTransfer中修改。<br />
</p>

<div class="question">
<hr />
<h4>对账文件下载您可能会遇到...</h4>
<p class="faq">
<a href="https://open.unionpay.com/ajweb/help/faq/list?ha=http500" target="_blank">http500错误</a><br>
<a href="https://open.unionpay.com/ajweb/help/faq/list?ha=respcode%3d99" target="_blank">respcode=99</a><br>
<a href="https://open.unionpay.com/ajweb/help/faq/list?ha=respcode%3d98" target="_blank">respcode=98</a><br>
<br>
另外请注意阅读：<br>
<a href="https://open.unionpay.com/ajweb/help/faq/list?ha=%e5%af%b9%e8%b4%a6%e6%96%87%e4%bb%b6%e4%bb%80%e4%b9%88%e6%97%b6%e5%80%99%e8%83%bd%e4%b8%8b%e8%bd%bd" target="_blank">对账文件什么时候能下载？</a><br>
<a href="https://open.unionpay.com/ajweb/help/faq/list?ha=%e6%b8%85%e7%ae%97%e6%97%a5%e6%9c%9fsettleDate%e6%98%af%e4%bb%80%e4%b9%88" target="_blank">清算日期settleDate是什么？</a><br>
<br>
</p>
<hr />
<!--#include file="/pages/more_faq.htm"--> 
</div>