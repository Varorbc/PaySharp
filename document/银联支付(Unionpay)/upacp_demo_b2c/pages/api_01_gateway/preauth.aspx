<form class="api-form" method="post" action="demo/api_01_gateway/Form_6_6_1_FrontPreauth.aspx" target="_blank">
<p>
<label>商户号：</label>
<input id="merId" pattern="\d{15}" type="text" name="merId" placeholder="" value="777290058110048" title="默认商户号仅作为联调测试使用，正式上线还请使用正式申请的商户号" required="required"/>
</p>
<p>
<label>交易金额：</label>
<input id="txnAmt" pattern="\d{1,12}" type="text" name="txnAmt" placeholder="交易金额" value="1000" title="单位为分 " required="required"/>
</p>
<p>
<label>订单发送时间：</label>
<input id="txnTime" pattern="\d{14}" type="text" name="txnTime" placeholder="订单发送时间，YYYYMMDDhhmmss格式" value="<%= DateTime.Now.ToString("yyyyMMddHHmmss") %>" title="取北京时间" required="required"/>
</p>
<p>
<label>商户订单号：</label>
<input id="orderId" pattern="[0-9a-zA-Z]{8,32}" type="text" name="orderId" placeholder="商户订单号" value="<%= DateTime.Now.ToString("yyyyMMddHHmmssfff") %>" title="自行定义，8-32位数字字母 " required="required"/>
</p>
<p>
<label>&nbsp;</label>
<input type="submit" class="button" value="跳转银联页面预授权" />
<input type="button" class="showFaqBtn" value="遇到问题？" />
</p>
</form>

<div class="question">
<hr />
<h4>跳转网关页面您可能会遇到...</h4>
<p class="faq">
<a href="https://open.unionpay.com/ajweb/help/faq/list?id=4&level=0&from=0" target="_blank">测试卡信息</a><br>
<a href="https://open.unionpay.com/ajweb/help/faq/list?id=24&level=0&from=0" target="_blank">http400错误</a><br>
<a href="https://open.unionpay.com//ajweb/help/respCode/respCodeList?respCode=9100004" target="_blank">测试环境9100004</a><br>
<a href="https://open.unionpay.com/ajweb/help/faq/list?id=40&level=0&from=0" target="_blank">正式环境9100004</a><br>
<a href="https://open.unionpay.com/ajweb/help/faq/list?id=113&level=0&from=0" target="_blank">打开页面出现"此网站的安全证书有问题"或"您的连接不是私密连接"等阻止打开支付页面跳转的内容</a><br>
<a href="https://open.unionpay.com/ajweb/help/faq/list?id=34&level=0&from=0" target="_blank">测试环境跳转报http501错误</a><br>
<a href="https://open.unionpay.com/ajweb/help/faq/list?id=169&level=0&from=0" target="_blank">wap跳转银联后白屏</a><br>
<a href="https://open.unionpay.com//ajweb/help/respCode/respCodeList?respCode=5131008" target="_blank">5131008</a><br>
</p>
<hr />
<!--#include file="/pages/more_faq.htm"--> 
</div>
