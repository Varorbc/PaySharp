<form class="api-form" method="post" action="demo/api_05_app/Form_6_5_Query.aspx" target="_blank">
<p>
<label>商户号：</label>
<input id="merId" pattern="\d{15}" type="text" name="merId" placeholder="" value="777290058110048" title="默认商户号仅作为联调测试使用，正式上线还请使用正式申请的商户号" required="required"/>
</p>
<p>
<label>订单发送时间：</label>
<input id="txnTime" pattern="\d{14}"type="text" name="txnTime" placeholder="填写被查询交易的订单发送时间" value="" title="填写被查询交易的订单发送时间，YYYYMMDDhhmmss格式" required="required"/>
</p>
<p>
<label>商户订单号：</label>
<input id="orderId" pattern="[0-9a-zA-Z]{8,32}" type="text" name="orderId" placeholder="填写被查询交易的商户订单号" value="" title="填写被查询交易的商户订单号" required="required"/>
</p>
<p>
<label>&nbsp;</label>
<input type="submit" class="button" value="提交" />
<input type="button" class="showFaqBtn" value="遇到问题？"  />
</p>
</form>

<div class="question" >
<hr />
<h4>交易状态查询您可能会遇到...</h4>
<p class="faq">
<a href="https://open.unionpay.com//ajweb/help/respCode/respCodeList?respCode=2600000" target="_blank">=查无此交易[2600000]</a><br>
 <br>
</p>
<hr />
<!--#include file="/pages/more_faq.htm"--> 
</div>

