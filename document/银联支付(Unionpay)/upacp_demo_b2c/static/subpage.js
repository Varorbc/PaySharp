$(function() {
    //各个接口的页面
    $( document ).tooltip();
	$( ".question" ).hide();
    $( "div.question" ).hide();
    $( ".showFaqBtn" ).click(function() {  $( ".question" ).toggle();   });
  });
