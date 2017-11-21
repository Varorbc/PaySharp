$(function() {
	
	  //index
    $( "#tabs-api" ).tabs(); 
    //form的title属性提示信息
    $( document ).tooltip();
	
});
  
function setApiDemoTabs(selector){
		  //beforeLoad是ajax应答失败的情况给个提示，load是html加载成功之后再加js，不然不会执行。
		  //默认上边圆角，改为左边圆角
	  $( selector ).tabs({ beforeLoad: function( event, ui ) { 
    	ui.jqXHR.error(function() { ui.panel.html( "加载中" ); });
    	}, load: function(event, ui){
					 $( ".question" ).hide();
				   $( ".showFaqBtn" ).click(
				       function() {  $( ".question" ).toggle();   });}}).addClass( "ui-tabs-vertical ui-helper-clearfix" );
    $( selector+" li" ).removeClass( "ui-corner-top" ).addClass( "ui-corner-left" ); 
}