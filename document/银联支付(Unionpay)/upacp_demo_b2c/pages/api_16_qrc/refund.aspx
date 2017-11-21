<form class="api-form" method="post" action="demo/api_16_qrc/Form_6_4_Refund.aspx" target="_blank">
    <p>
        <label>商户号：</label>
        <input id="merId" type="text" name="merId" placeholder="" value="777290058110048" title="默认商户号仅作为联调测试使用，正式上线还请使用正式申请的商户号" required="required" />
    </p>
    <p>
        <label>订单发送时间：</label>
        <input id="txnTime" type="text" name="txnTime" placeholder="订单发送时间" value="<%= DateTime.Now.ToString("yyyyMMddHHmmss") %>" title="取北京时间，YYYYMMDDhhmmss格式" required="required" />
    </p>
    <p>
        <label>商户订单号：</label>
        <input id="orderId" type="text" name="orderId" placeholder="商户订单号" value="<%= DateTime.Now.ToString("yyyyMMddHHmmssfff") %>" title="自行定义，8-32位数字字母" required="required" />
    </p>
    <p>
        <label>交易金额：</label>
        <input id="txnAmt" type="text" name="txnAmt" placeholder="交易金额" value="" title="单位分，退货总金额要小于等于原消费" required="required" />
    </p>
    <p>
        <label>原交易流水号：</label>
        <input id="origQryId" type="text" name="origQryId" placeholder="原交易流水号" value="" title="原交易流水号，从交易状态查询返回报文或代收的通知报文中获取 "  />
    </p>
    <p>
<label>原交易商户订单号：</label>
<input id="origOrderId" type="text" name="origOrderId" placeholder="原交易商户订单号" value="" title="原交易商户订单号" />
</p>

<p>
<label>原交易商户发送交易时间：</label>
<input id="origTxnTime" type="text" name="origTxnTime" placeholder="原交易商户发送交易时间" value="" title="原交易商户发送交易时间 " />
</p>

    <p>
        <label>&nbsp;</label>
        <input type="submit" class="button" value="提交" />
        <input type="button" class="showFaqBtn" value="遇到问题？" />
    </p>
</form>

<div class="question">
    <hr />
    <h4>退货接口您可能会遇到...</h4>
    <p class="faq">
        <a href="https://open.unionpay.com//ajweb/help/respCode/respCodeList?respCode=2010002" target="_blank">订单重复[2010002]</a><br>
        <br>
        <a href="https://open.unionpay.com//ajweb/help/respCode/respCodeList?respCode=2040004" target="_blank">原交易状态不正确[2040004]</a><br>
        <br>
        <a href="https://open.unionpay.com//ajweb/help/respCode/respCodeList?respCode=2050004" target="_blank">与原交易信息不符[2050004]</a><br>
        <br>
    </p>
    <hr />
    <!--#include file="/pages/more_faq.htm"-->
</div>
