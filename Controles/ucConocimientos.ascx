<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucConocimientos.ascx.vb" Inherits="bolsatrabajo.ucConocimientos" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language="javascript">
	function init()
	{	
		var mtzVal = document.getElementById("UcConocimientos1_txtPrecarga").value.split("|");
		var i;
		var idC,idV;
		
		for (i=0;i < mtzVal.length ;i++)
		{
			idC = mtzVal[i].split(",")[0];
			idV = mtzVal[i].split(",")[1];
			AddR(idC,idV)
		}
	}

	function sincCbo(cbo,val)
	{
		var i;
		for (i=0;1<cbo.length;i++)
		{
			if(cbo[i].value==val)
			{	cbo.selectedIndex=i;
				break; 
			}
		}
	}

	function AddR(idC,idV)
	{	
		var cboC= document.getElementById("cboConocimiento").cloneNode(true);
		var cboV= document.getElementById("cboValor").cloneNode(true);
		//coloco los pre
		if (idC>0&&idV>0)
		{	
			sincCbo(cboC,idC);
			sincCbo(cboV,idV);
		}
		var oT = document.getElementById("UcConocimientos1_contenido");
		var tbody = oT.getElementsByTagName("TBODY")[0];
		var row = document.createElement("TR");
		var td1 = document.createElement('TD');
		var td2 = document.createElement('TD');
		td1.appendChild (cboC);
		td2.appendChild (cboV);
		row.appendChild (td1);
		row.appendChild (td2);
		tbody.appendChild(row); 			
	}

	function DelR()
	{	var oT = document.getElementById("UcConocimientos1_contenido");
		var tbody = oT.getElementsByTagName("TBODY")[0];
		var mtxR =oT.getElementsByTagName("TR");
		var ultR = mtxR[mtxR.length-1];
		if (mtxR.length>1){tbody.removeChild(ultR);}
	}

	function recolectar()
	{	//no deberia estar el mismo conocimiento 2 veces
		var isValid=true;
		try{
		
			var txtSal = document.getElementById("UcConocimientos1_txtSalida");
			var mtzcboC =document.getElementsByName("cboConocimiento");
			var mtzcboV =document.getElementsByName("cboValor");
			var i;
			var cods='';
			var val=0;
			var mtzVal= new Array();
			var reg;
			for (i=1;i<mtzcboC.length;i++)
			{	val = mtzcboC[i].value;
				
				if(YaEstaElegido(val,mtzVal)){
					throw new Error(-1, "Error: hay datos repetidos.");
				}
				cods+= '|'+val+','+mtzcboV[i].value;
			}
			cods = cods.substring(1,cods.length);
			txtSal.value= cods;
		
		}catch(e){
			alert(e.description);
			isValid=false;
		}
		return isValid;
	}
	
	function YaEstaElegido(val,mtzVal)
	{ var i;
		var esta=false;
		for(i=0;i<mtzVal.length;i++)
		{	if (mtzVal[i]==val){
				esta=true;
				break;
			}
		}
		if(!esta){mtzVal[mtzVal.length]=val;}
		return esta;
	}
</script>
<div id="plantilla" style="DISPLAY:none">
	<!--#include file="../public/lstconocimientos.xml"-->
	<SELECT id="cboValor" name="cboValor">
		<OPTION value="1" selected>Bajo</OPTION>
		<OPTION value="2">Medio</OPTION>
		<OPTION value="3">Alto</OPTION>
	</SELECT>
</div>
<input type="hidden" name="txtPrecarga" id="txtPrecarga" runat="server"> <input type="hidden" name="txtSalida" id="txtSalida" runat="server">
<input type="button" onclick="AddR(0,0);" id="cmdAddrow" value="Agregar"> <input type="button" onclick="DelR();" id="cmdDelrow" value="Eliminar">
<input type="button" onclick="if(recolectar())" id="cmdRec" value="Grabar los cambios"
	runat="server">
<asp:Table id="contenido" runat="server" BorderWidth="1px">
	<asp:TableRow>
		<asp:TableCell Text=""></asp:TableCell>
		<asp:TableCell Text=""></asp:TableCell>
	</asp:TableRow>
</asp:Table>
<script language="javascript">
	init();
</script>
