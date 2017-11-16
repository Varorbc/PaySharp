<form class="api-form" method="post" action="demo/api_01_gateway/Form_6_6_3_PreauthFinish.aspx" target="_blank">
<p>
<label>商户号：</label>
<input id="merId" pattern="\d{15}" type="text" name="merId" placeholder="" value="777290058110048" title="默认商户号仅作为联调测试使用，正式上线还请使用正式申请的商户号" required="required"/>
</p>
<p>
<label>订单发送时间：</label>
<input id="txnTime" pattern="\d{14}" type="text" name="txnTime" placeholder="订单发送时间" value="<%= DateTime.Now.ToString("yyyyMMddHHmmss") %>" title="取北京时间，YYYYMMDDhhmmss格式。" required="required"/>
</p>
<p>
<label>商户订单号：</label>
<input id="orderId" pattern="[0-9a-zA-Z]{8,32}" type="text" name="orderId" placeholder="商户订单号" value="<%= DateTime.Now.ToString("yyyyMMddHHmmssfff") %>" title="8-32位数字字母，自行定义内容。" required="required"/>
</p>
<p>
<label>交易金额：</label>
<input id="txnAmt" pattern="\d{1,12}" type="text" name="txnAmt" placeholder="交易金额" value="" title="单位分，整数，小于等于原预授权的115%。" required="required"/>
</p>
<p>
<label>原交易流水号：</label>
<input id="origQryId" pattern="\d{21}" type="text" name="origQryId" placeholder="原交易流水号" value="" title="填写原预授权的查询或通知接口的queryId字段。" required="required"/>
</p>
<p>
<label>&nbsp;</label>
<input type="submit" class="button" value="提交" />
<input type="button" class="showFaqBtn" value="遇到问题？" />
</p>
</form>

<div class="question">
<hr />
<h4>预授权完成您可能会遇到...</h4>
<p class="faq">
测试的人不多，木有足量样本/(ㄒoㄒ)/~~<br>
<br>
</p>
<hr />
<!--#include file="/pages/more_faq.htm"--> 
</div>