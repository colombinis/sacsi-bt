function VistaPrevia(){
		var ow;
		var contenido;
		ow= window.open ();
		contenido ="<HTML><HEAD><title>vista Previa</title><LINK href='Styles.css' type='text/css' rel='stylesheet'></HEAD>";
		contenido +="<body><h2>" + strCab + "</h2><br/><hr/>";
		contenido +=document.getElementById("contGrilla").outerHTML;
		contenido +="<hr/><b>" + strPie + "</b></body></HTML>";
		ow.document.write(contenido);
	}

function numEnt(oEl){
	var key=window.event.keyCode;
	if (key < 48 || key > 57 )
		{window.event.keyCode=0;}
}

function numDecimal(oEl){
	var key=window.event.keyCode;
	if (key == 46 || key == 44)
	{		if (Buscar(/,/,oEl.value) ==1)
			{window.event.keyCode=0;}
			else
			{window.event.keyCode=44;
			}
	}
	else
	{	
		if ((key < 48 || key > 57 ))
		{window.event.keyCode=0;}
	
	}
}

function Buscar(patron,valor){
	var ExReg = new RegExp(patron);
		if (valor.search(ExReg)>=0)
		{return 1;}else{return 0;}}