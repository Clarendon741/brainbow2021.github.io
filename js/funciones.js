
function cambiar(elem)
{
	if(window.innerWidth  > 540 ){
		$('#'+elem+'Blanco').hide();
		$('#'+elem+'Color').show();
	}
	
}

function cambiarReversa(elem)
{
	if(window.innerWidth  > 540 ){
		$('#'+elem+'Color').hide();
		$('#'+elem+'Blanco').show();
	}
}


$(window).resize(function() {
	var arr = ["in2it", "envioSMS", "iAvaluos", "Brainbow"];
	if(window.innerWidth  > 540 ){
		for (i = 0; i < arr.length; i++) { 
			$('#'+arr[i]+'Color').hide();
			$('#'+arr[i]+'Blanco').show();
		}
	}else{
		for (i = 0; i < arr.length; i++) { 
			$('#'+arr[i]+'Blanco').hide();
			$('#'+arr[i]+'Color').show();
		}
	}
});