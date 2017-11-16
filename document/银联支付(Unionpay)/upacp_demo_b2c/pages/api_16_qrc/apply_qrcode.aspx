<form class="api-form" method="post" action="demo/api_16_qrc/Form_6_2_ApplyQrCode.aspx" target="_blank">
    <p>
        <label>商户号：</label>
        <input id="merId" type="text" name="merId" placeholder="" value="777290058110048" title="默认商户号仅作为联调测试使用，正式上线还请使用正式申请的商户号" required="required" />
    </p>
    <p>
        <label>订单发送时间：</label>
        <input id="txnTime" type="text" name="txnTime" placeholder="订单发送时间" value="<%= DateTime.Now.ToString("yyyyMMddHHmmss") %>" title="取北京时间，YYYYMMDDhhmmss格式" required="required" />
    <p>
        <label>商户订单号：</label>
        <input id="orderId" type="text" name="orderId" placeholder="商户订单号" value="<%= DateTime.Now.ToString("yyyyMMddHHmmssfff") %>" title="自行定义，8-32位数字字母" required="required" />
    </p>
    <p>
        <label>交易金额：</label>
        <input id="txnAmt" type="text" name="txnAmt" placeholder="交易金额" value="" title="单位分，需与原消费一致" required="required" />
    </p>
    <p>
        <label>&nbsp;</label>
        <input type="submit" class="button" value="消费" />
        <input type="button" class="showFaqBtn" value="遇到问题？" />
    </p>
</form>

<div class="question">
    <hr />
    <h4>消费您可能会遇到...</h4>
    <p class="faq">
        暂无
    </p>
    <hr />
    <!--#include file="/pages/more_faq.htm"-->
</div>
