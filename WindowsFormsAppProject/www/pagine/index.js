"use strict"

$(document).ready(function(){
	let Var=$("#lstVoci");
	Var.prop("selectedIndex","-1");
	$("#btnSend").on("click",function(){
		console.log("btnSend_Click")
		if(Var.prop("selectedIndex")==-1)
		{
			alert("Nessuna voce selezionata");
		}
		else
		{
			let _form=$(this).parent("form");
			_form.prop("method",/*metodo invio parametri*/);
			_form.prop("action",/*nome pagina da aprire*/);
			_form.submit();
		}
	});
});