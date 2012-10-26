<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucCuotas.ascx.vb" Inherits="bolsatrabajo.ucCuotas" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language="javascript">
		function init()
		{	
			var mtzVal = document.getElementById("UcCuotas1_txtPrecarga").value.split("|");
			var i;
			var fecvto,valor;
			
			for (i=0;i < mtzVal.length ;i++)
			{
				fecvto = mtzVal[i].split("¦")[0];
				valor = mtzVal[i].split("¦")[1];
				AddR(fecvto,valor)
			}
		}
		
		function AddR(fecvto,valor)
		{	
			var txtF= document.getElementById("txtfecvto").cloneNode(true);
			var txtV= document.getElementById("txtvalor").cloneNode(true);
			//coloco los pre
			if (fecvto!="0")
			{	//coloco la precarga
				txtF.value=fecvto;
				txtV.value=valor;
			}
			var oT = document.getElementById("UcCuotas1_contenido");
			var tbody = oT.getElementsByTagName("TBODY")[0];
			var row = document.createElement("TR");
			var td1 = document.createElement('TD');
			var td2 = document.createElement('TD');
			td1.appendChild (txtF);
			td2.appendChild (txtV);
			row.appendChild (td1);
			row.appendChild (td2);
			tbody.appendChild(row); 			
		}
		
		function DelR()
		{	var oT = document.getElementById("UcCuotas1_contenido");
			var tbody = oT.getElementsByTagName("TBODY")[0];
			var mtxR =oT.getElementsByTagName("TR");
			var ultR = mtxR[mtxR.length-1];
			if (mtxR.length>1){tbody.removeChild(ultR);}
		}
		
		function recolectar()
		{	//validaciones 
			var isValid=true;
			try{
				var txtSal = document.getElementById("UcCuotas1_txtSalida");
				var mtzF =document.getElementsByName("txtfecvto");
				var mtzV =document.getElementsByName("txtvalor");
				var i;
				var cods='';
				for (i=1;i<mtzF.length;i++)
				{	validarFechaValor(mtzF[i].value,mtzV[i].value);
					cods+= '|'+mtzF[i].value+'¦'+mtzV[i].value;
				}
				cods = cods.substring(1,cods.length);
				txtSal.value= cods;
			
			}catch(e){
				alert(e.description);
				isValid = false;
			}
			
			if (isValid){
				return confirm("Se generará el plan de cuotas. ¿ Desea continuar ?");
			}
			else
			{//hubo errores
				return isValid
			}		
		}
		
		function validarFechaValor(fecha,valor)
		{ 
			var reF;
		
			//fecha
			reF = /^[0-9]{2}\/[0-9]{2}\/[0-9]{4}$/;
			if (reF.test(fecha)==false){
				throw new Error(-1, "Error: ["+ fecha +"] verifique que todas las fechas tengan el formato dd/mm/yyyy");
			}
			//valor
			reF = /^[0-9]+\.?[0-9]*$/;
			if (reF.test(valor)==false){
				throw new Error(-1, "Error: ["+valor+"] verifique que los valores de las cuotas no tengan separadores de miles\n y como separador decimal use el punto . ")
			}
		}
		
</script>
<div id="plantilla" style="DISPLAY:none">
	<input type="text" name="txtfecvto" id="txtfecvto"> <input type="text" name="txtvalor" id="txtvalor">
</div>
<input type="hidden" name="txtPrecarga" id="txtPrecarga" runat="server"> <input type="hidden" name="txtSalida" id="txtSalida" runat="server">
<input type="button" onclick="AddR(0,0);" id="cmdAddrow" value="Agregar Cuota"> <input type="button" onclick="DelR();" id="cmdDelrow" value="Eliminar Cuota">
<input type="button" onclick="if(recolectar())" id="cmdRec" value="Guardar cambios" runat="server"
	NAME="cmdRec"> 
<!--<table id="_contenido" name="_contenido" border="1" runat="server">
	<tr>
		<td>Fecha vto</td>
		<td>Valor</td>
	</tr>
</table>-->
<asp:Table id="contenido" runat="server" BorderWidth="1px">
	<asp:TableRow>
		<asp:TableCell Text="Fecha vto"></asp:TableCell>
		<asp:TableCell Text="Valor"></asp:TableCell>
	</asp:TableRow>
</asp:Table>
<script language="javascript">
init();
</script>
