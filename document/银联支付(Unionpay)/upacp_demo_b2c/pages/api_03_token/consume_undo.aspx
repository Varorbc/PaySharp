<form class="api-form" method="post" action="demo/api_03_token/Form_6_8_ConsumeUndo.aspx" target="_blank">
<p>
<label>商户号：</label>
<input id="merId" type="text" pattern="\d{15}" name="merId" placeholder="" value="777290058110097" title="默认商户号仅作为联调测试使用，正式上线还请使用正式申请的商户号。" required="required"/>
</p>
<p>
<label>订单发送时间：</label>
<input id="txnTime" type="text" pattern="\d{14}" name="txnTime" placeholder="订单发送时间" value="<%= DateTime.Now.ToString("yyyyMMddHHmmss") %>" title="取北京时间，YYYYMMDDhhmmss格式。" required="required"/>
<p>
<label>商户订单号：</label>
<input id="orderId" type="text" pattern="[0-9a-zA-Z]{8,32}" name="orderId" placeholder="商户订单号" value="<%= DateTime.Now.ToString("yyyyMMddHHmmssfff") %>" title="8-32位数字字母，自行定义内容。" required="required"/>
</p>
<p>
<label>交易金额：</label>
<input id="txnAmt" type="text" pattern="\d{1,12}" name="txnAmt" placeholder="交易金额" value="" title="单位分，需与原消费一致。" required="required"/>
</p>
<p>
<label>原交易流水号：</label>
<input id="origQryId" type="text" pattern="\d{21}" name="origQryId" placeholder="原交易流水号" value="" title="填写原交易的查询或通知接口中的queryId字段。" required="required"/>
</p>
<p>
<label>&nbsp;</label>
<input type="submit" class="button" value="提交" />
<input type="button" class="showFaqBtn" value="遇到问题？" />
</p>
</form>

<div class="question">
<hr />
<h4>消费撤销您可能会遇到...</h4>
<p class="faq">
<a href="https://open.unionpay.com//ajweb/help/respCode/respCodeList?respCode=2010002" target="_blank">2010002</a><br>
<a href="https://open.unionpay.com//ajweb/help/respCode/respCodeList?respCode=2040004" target="_blank">2040004</a><br>
<a href="https://open.unionpay.com//ajweb/help/respCode/respCodeList?respCode=2040006" target="_blank">2040006</a><br>
<a href="https://open.unionpay.com//ajweb/help/respCode/respCodeList?respCode=2050001" target="_blank">2050001</a><br>
<a href="https://open.unionpay.com//ajweb/help/respCode/respCodeList?respCode=2050002" target="_blank">2050002</a><br>
</p>
<hr />
<!--#include file="/pages/more_faq.htm"--> 
</div>