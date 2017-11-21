<form class="api-form" method="post" action="demo/api_03_token/Form_6_2_BackOpen.aspx" target="_blank">
<p>
<label>商户号：</label>
  <input id="merId" pattern="\d{15}" type="text" name="merId" placeholder="" value="777290058110097" title="默认商户号仅作为联调测试使用，正式上线还请使用正式申请的商户号" required="required"/>
</p>
<p>
  <label>订单发送时间：</label>
  <input id="txnTime" pattern="\d{14}" type="text" name="txnTime" placeholder="订单发送时间" value="<%= DateTime.Now.ToString("yyyyMMddHHmmss") %>" title="取北京时间，YYYYMMDDhhmmss格式。如之前调用获取验证码接口，填写获取验证码时的txnTime。" required="required"/>
</p>
<p>
  <label>商户订单号：</label>
  <input id="orderId" pattern="[0-9a-zA-Z]{8,32}" type="text" name="orderId" placeholder="商户订单号" value="<%= DateTime.Now.ToString("yyyyMMddHHmmssfff") %>" title="8-32位数字字母，自行定义内容。如之前调用获取验证码接口，填写获取验证码时的orderId。" required="required"/>
</p>
<p>
<label>&nbsp;</label>
<input type="submit" class="button" value="提交" />
<input type="button" class="showFaqBtn" value="遇到问题？"  />
</p>
</form>

<hr />
<p class="faq">
* 此demo使用的交易卡写死在代码里了，请查看Form_6_2_BackOpen代码。<br />
</p>

<div class="question" >
<hr />
<h4>后台开通您可能会遇到...</h4>
<p class="faq">
<a href="https://open.unionpay.com//ajweb/help/respCode/respCodeList?respCode=6100030" target="_blank">6100030</a><br>
<br>
</p>
<hr />
<!--#include file="/pages/more_faq.htm"--> 
</div>

