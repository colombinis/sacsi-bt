<%@ Register TagPrefix="uc1" TagName="ucPostulaciones" Src="ucPostulaciones.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucDatosPost.ascx.vb" Inherits="bolsatrabajo.ucDatosPost" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="ucConocimientos1" Src="ucConocimientos1.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucDomicilio" Src="ucDomicilio.ascx" %>
<SCRIPT language="javascript" type="text/javascript">

	function muestroPagina(nroPag)
	{ 
		//coloco el tab seleccionado
		document.getElementById("UcDatosPost1_txtValorTab").value=nroPag;
		var cantPaginas=5+1;
		var prePagina="pagina_"
		var preMenu = "menu_"
		var i;
		var oPag;
		var oMenu;
		
		for (i=1;i<cantPaginas;i++)
		{	oPag=document.getElementById(prePagina+i);
		  oMenu=document.getElementById(preMenu+i);
      if(nroPag==i)
      {	oPag.className = 'VISIBLE';
				oMenu.className = 'active';
      }
      else
      {	oPag.className= 'OCULTO';
				oMenu.className = 'inactive';
      }
		}

	}

</SCRIPT>
<div id="tabulador">
	<ul id="listaMenu">
		<li>
			<A class="active" id="menu_1" onclick="muestroPagina(1);" href="#">Datos Personales</A>
		<li>
			<A class="inactive" id="menu_2" onclick="muestroPagina(2);" href="#">Datos 
				Universitarios</A>
		<li>
			<A class="inactive" id="menu_3" onclick="muestroPagina(3);" href="#">Otros Datos</A>
		<li>
			<A class="inactive" id="menu_4" onclick="muestroPagina(4);" href="#">Actualizar 
				Conocimientos </A>
		<li>
			<A class="inactive" id="menu_5" onclick="muestroPagina(5);" href="#">Historial </A>
		</li>
	</ul>
</div>
<div id="LineaAzul"></div>
<DIV class="VISIBLE" id="pagina_1">
	<div id="codigo" style="DISPLAY: none">Cod - Fecha Alta
		<asp:textbox id="txtidPostulante" readonly="True" maxlength="10" runat="server"></asp:textbox><asp:textbox id="txtfechaAltaSistema" readonly="True" maxlength="23" runat="server"></asp:textbox><INPUT id="txtValorTab" type="hidden" name="txtValorTab" runat="server">
	</div>
	<table cellSpacing="0" cellPadding="0" border="0">
		<TR class="separaDatos">
			<TD style="WIDTH: 31px" align="center"></TD>
			<TD align="center" colSpan="5"><STRONG>-&nbsp;: - Nota: los datos marcados con (*) son 
					obligatorios -&nbsp;: -</STRONG></TD>
		</TR>
		<tr>
			<TD style="WIDTH: 31px"></TD>
			<TD style="WIDTH: 133px" bgColor="#f4f4f4"><STRONG>Usuario (*)</STRONG></TD>
			<TD style="WIDTH: 338px"><asp:textbox id="txtUsuario" maxlength="99" runat="server" ReadOnly="True"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Dato Usuario incorrecto"
					ValidationExpression="[\w]{1,99}" ControlToValidate="txtUsuario"></asp:regularexpressionvalidator></TD>
			<td style="WIDTH: 137px" bgColor="#f4f4f4"><STRONG>Legajo (*)</STRONG></td>
			<TD colSpan="2">08-
				<asp:textbox id="txtnroLegajo" maxlength="10" runat="server" ToolTip="Ej: 26702"></asp:textbox><asp:requiredfieldvalidator id="reqnroLegajo" runat="server" errormessage="El dato nroLegajo es requerido."
					controltovalidate="txtnroLegajo" display="None"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator4" runat="server" ErrorMessage="Dato Legajo incorrecto. Ej: 25689"
					ValidationExpression="[\d]{5}" ControlToValidate="txtnroLegajo"></asp:regularexpressionvalidator></TD>
		</tr>
		<TR>
			<TD style="WIDTH: 31px"></TD>
			<TD style="WIDTH: 133px" bgColor="#f4f4f4"><STRONG>Apellido (*)</STRONG></TD>
			<TD style="WIDTH: 338px"><asp:textbox id="txtapellido" readonly="False" maxlength="99" runat="server" ToolTip="ej: Perez"></asp:textbox><asp:requiredfieldvalidator id="reqapellido" runat="server" errormessage="El dato apellido es requerido." controltovalidate="txtapellido"
					display="None"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator5" runat="server" ErrorMessage="Dato Apellido  incorrecto. Ej: Perez "
					ValidationExpression="[\w ]{1,99}" ControlToValidate="txtapellido" ToolTip="Ej: Perez"></asp:regularexpressionvalidator></TD>
			<TD style="WIDTH: 137px" bgColor="#f4f4f4"><STRONG>Nombres (*)</STRONG></TD>
			<TD colSpan="2"><asp:textbox id="txtnombres" readonly="False" maxlength="99" runat="server" ToolTip="ej: Juan Manuel"></asp:textbox><asp:requiredfieldvalidator id="reqnombres" runat="server" errormessage="El dato nombres es requerido." controltovalidate="txtnombres"
					display="None"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator6" runat="server" ErrorMessage="Dato Nombres incorrecto. Ej: Juan Manuel"
					ValidationExpression="[\w áéíóú ]{1,99}" ControlToValidate="txtnombres" ToolTip="Ej: Juan Manuel"></asp:regularexpressionvalidator></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 31px"></TD>
			<TD style="WIDTH: 133px" bgColor="#f4f4f4"><STRONG>Email (*)</STRONG></TD>
			<TD style="WIDTH: 338px"><asp:textbox id="txtemail" readonly="False" maxlength="99" runat="server" ToolTip="ej: pepe@frro.utn.edu.ar"></asp:textbox><asp:requiredfieldvalidator id="reqemail" runat="server" errormessage="El dato email es requerido." controltovalidate="txtemail"
					display="None"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ErrorMessage="Dato Email incorrecto. Ej: pepe@frro.utn.edu.ar"
					ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail"></asp:regularexpressionvalidator></TD>
			<TD style="WIDTH: 137px" bgColor="#f4f4f4"><STRONG>Email alternativo</STRONG></TD>
			<TD colSpan="2"><asp:textbox id="txtemailAlternativo" readonly="False" maxlength="99" runat="server" ToolTip="ej: jose@hotmail.com"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" ErrorMessage="Dato Email alternativo incorrectoDato Email incorrecto. Ej: pepe@hotmail.com"
					ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemailAlternativo"></asp:regularexpressionvalidator></TD>
		</TR>
		<tr>
			<TD style="WIDTH: 31px"></TD>
			<TD style="WIDTH: 133px" bgColor="#f4f4f4"><STRONG>Tipo y Nro Documento&nbsp;(*)</STRONG></TD>
			<TD style="WIDTH: 338px"><asp:dropdownlist id="cboTipoDoc" runat="server"></asp:dropdownlist><asp:textbox id="txtnroDoc" readonly="False" maxlength="14" runat="server" ToolTip="Ej: 40111625"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator7" runat="server" ErrorMessage="Dato Nro Doc incorrecto. Ej: 40111625"
					ValidationExpression="[\d]{1,14}" ControlToValidate="txtnroDoc"></asp:regularexpressionvalidator><asp:requiredfieldvalidator id="regTipoDoc" runat="server" errormessage="El dato nroDoc es requerido." controltovalidate="cboTipoDoc"
					display="None"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="reqnroDoc" runat="server" errormessage="El dato Tipo Documento es requerido."
					controltovalidate="txtnroDoc" display="None"></asp:requiredfieldvalidator></TD>
			<td style="WIDTH: 137px" bgColor="#f4f4f4"><STRONG>CUIL o CUIT</STRONG></td>
			<TD colSpan="2"><asp:textbox id="txtnroCuil" readonly="False" maxlength="100" runat="server" ToolTip="Ej: 23-26654485-9"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator8" runat="server" ErrorMessage="Dato CUIL/CUIT incorrecto. Ej: 23-26654485-9"
					ValidationExpression="[\d-]{1,14}" ControlToValidate="txtnroCuil"></asp:regularexpressionvalidator></TD>
		</tr>
		<tr>
			<TD style="WIDTH: 31px"></TD>
			<TD style="WIDTH: 133px" bgColor="#f4f4f4"><STRONG>Fecha Nacimiento</STRONG></TD>
			<TD style="WIDTH: 338px"><asp:textbox id="txtfechaNacimiento" readonly="False" maxlength="23" runat="server" ToolTip="ej: 01/11/1980"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ToolTip="ej: 01/11/2004" errormessage="El dato Fecha Nacimiento es requerido."
					controltovalidate="txtfechaNacimiento" display="None"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator9" runat="server" ErrorMessage="Dato Fecha Nacimiento incorrecto"
					ValidationExpression="\d{2}\/\d{2}/\d{4}" ControlToValidate="txtfechaNacimiento" ToolTip="ej: 01/11/1980"></asp:regularexpressionvalidator></TD>
			<td style="WIDTH: 137px" bgColor="#f4f4f4"><STRONG>Sexo (*)</STRONG></td>
			<TD colSpan="2"><asp:dropdownlist id="cboSexo" runat="server">
					<asp:ListItem Value="-1">(---)</asp:ListItem>
					<asp:ListItem Value="1">M</asp:ListItem>
					<asp:ListItem Value="2">F</asp:ListItem>
				</asp:dropdownlist><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" errormessage="El dato Sexo es requerido."
					controltovalidate="cboSexo" display="None" InitialValue="-1"></asp:requiredfieldvalidator></TD>
		</tr>
		<TR>
			<TD style="WIDTH: 31px"></TD>
			<TD style="WIDTH: 133px" bgColor="#f4f4f4"><STRONG>Estado Civil (*)</STRONG></TD>
			<TD style="WIDTH: 338px"><asp:dropdownlist id="cboEstadoCivil" runat="server">
					<asp:ListItem Value="-1">(---)</asp:ListItem>
					<asp:ListItem Value="1">Soltero</asp:ListItem>
					<asp:ListItem Value="2">Casado</asp:ListItem>
				</asp:dropdownlist><asp:requiredfieldvalidator id="reqEstadoCivil" runat="server" errormessage="El dato Estado Civil es requerido."
					controltovalidate="cboEstadoCivil" display="None" InitialValue="-1"></asp:requiredfieldvalidator></TD>
			<TD style="WIDTH: 137px" bgColor="#f4f4f4">&nbsp;</TD>
			<TD colSpan="2"></TD>
		</TR>
		<TR>
			<TD class="separaDatos" style="WIDTH: 31px"></TD>
			<TD class="separaDatos" style="WIDTH: 133px" colSpan="2"><b>Domicilio Familiar</b></TD>
			<TD class="separaDatos" style="WIDTH: 137px" colSpan="3"><b>Domicilio Actual</b></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 31px"></TD>
			<TD style="WIDTH: 133px" colSpan="2"><uc1:ucdomicilio id="ucDomicilioFamiliar" runat="server"></uc1:ucdomicilio></TD>
			<TD style="WIDTH: 137px" colSpan="3"><uc1:ucdomicilio id="ucDomicilioActual" runat="server"></uc1:ucdomicilio></TD>
		</TR>
	</table>
</DIV>
<p class="break"></p>
<DIV class="OCULTO" id="pagina_2">
	<table cellSpacing="0" cellPadding="0" border="0">
		<tr>
			<TD bgColor="#f4f4f4"></TD>
			<TD style="WIDTH: 30px"></TD>
			<td bgColor="#f4f4f4"><STRONG>Especialidad</STRONG></td>
			<td><asp:dropdownlist id="cboEspecialidad" runat="server"></asp:dropdownlist></td>
		</tr>
		<tr>
			<TD bgColor="#f4f4f4"></TD>
			<TD style="WIDTH: 30px"></TD>
			<td bgColor="#f4f4f4"><STRONG>Cantidad de Materias Aprobadas</STRONG></td>
			<td><asp:textbox id="txtcantMateriasAprobadas" readonly="False" maxlength="3" runat="server" ToolTip="ej: 2"
					Columns="3"></asp:textbox><asp:requiredfieldvalidator id="reqCantMateriasAprobadas" runat="server" errormessage="El dato Cantidad de Materias Aprobadas es requerido."
					controltovalidate="txtcantMateriasAprobadas" display="None"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator10" runat="server" ErrorMessage="Dato Cantidad de Materias  Aprobadas incorrecto"
					ValidationExpression="\d{1,2}" ControlToValidate="txtcantMateriasAprobadas" ToolTip="ej: 2"></asp:regularexpressionvalidator></td>
		</tr>
		<tr>
			<TD bgColor="#f4f4f4"></TD>
			<TD style="WIDTH: 30px"></TD>
			<td bgColor="#f4f4f4"><STRONG>Plan Especialidad (*)</STRONG></td>
			<td><asp:textbox id="txtplanEspecialidad" readonly="False" maxlength="100" runat="server" ToolTip="Ej: Plan 95"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" errormessage="El dato Plan Especialidad es requerido."
					controltovalidate="txtplanEspecialidad" display="None"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator11" runat="server" ErrorMessage="Dato Plan Especialidad  incorrecto.Ej: Plan 95"
					ValidationExpression="[\w ]{1,99}" ControlToValidate="txtplanEspecialidad" ToolTip="Ej: Plan 95"></asp:regularexpressionvalidator></td>
		</tr>
		<tr>
			<TD bgColor="#f4f4f4"></TD>
			<TD style="WIDTH: 30px"></TD>
			<td bgColor="#f4f4f4"><STRONG>Año que Cursa</STRONG></td>
			<td><asp:dropdownlist id="txtanioCursa" runat="server">
					<asp:ListItem Value="-1">(---)</asp:ListItem>
					<asp:ListItem Value="1">1&#186; A&#241;o</asp:ListItem>
					<asp:ListItem Value="2">2&#186; A&#241;o</asp:ListItem>
					<asp:ListItem Value="3">3&#186; A&#241;o</asp:ListItem>
					<asp:ListItem Value="4">4&#186; A&#241;o</asp:ListItem>
					<asp:ListItem Value="5">5&#186; A&#241;o</asp:ListItem>
				</asp:dropdownlist><asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" errormessage="El dato Año que Cursa es requerido."
					controltovalidate="txtanioCursa" display="None"></asp:requiredfieldvalidator></td>
		</tr>
		<tr>
			<TD bgColor="#f4f4f4"></TD>
			<TD style="WIDTH: 30px"></TD>
			<td bgColor="#f4f4f4"><STRONG>Turno que Cursa</STRONG></td>
			<td><asp:dropdownlist id="txtturnoCursa" runat="server">
					<asp:ListItem Value="-1">(---)</asp:ListItem>
					<asp:ListItem Value="M">Ma&#241;ana</asp:ListItem>
					<asp:ListItem Value="T">Tarde</asp:ListItem>
					<asp:ListItem Value="N">Noche</asp:ListItem>
				</asp:dropdownlist><asp:requiredfieldvalidator id="Requiredfieldvalidator5" runat="server" errormessage="El dato Turno que cursa es requerido."
					controltovalidate="txtturnoCursa" display="None"></asp:requiredfieldvalidator></td>
		</tr>
		<TR>
			<TD bgColor="#f4f4f4"></TD>
			<TD style="WIDTH: 30px"></TD>
			<TD bgColor="#f4f4f4"><STRONG>Promedio con Aplazos</STRONG></TD>
			<td><asp:textbox id="txtpromConAplazos" readonly="False" maxlength="18" runat="server" ToolTip="ej: 6.5"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator6" runat="server" errormessage="El dato Promedio con Aplazos es requerido."
					controltovalidate="txtpromConAplazos" display="None"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator16" runat="server" ErrorMessage="Dato Promedio con Aplazos incorrecto. Ej: 6,5"
					ValidationExpression="[0123456789,]{1,5}" ControlToValidate="txtpromConAplazos" ToolTip="Ej: 6,5"></asp:regularexpressionvalidator></td>
		</TR>
		<tr>
			<TD bgColor="#f4f4f4"></TD>
			<TD style="WIDTH: 30px"></TD>
			<td bgColor="#f4f4f4"><STRONG>Promedio sin Aplazos</STRONG></td>
			<td><asp:textbox id="txtpromSinAplazos" readonly="False" maxlength="18" runat="server"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator7" runat="server" errormessage="El dato Promedio sin aplazos es requerido."
					controltovalidate="txtpromSinAplazos" display="None"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator17" runat="server" ErrorMessage="Dato Promedio sin Aplazos incorrecto.Ej: 6,5"
					ValidationExpression="[0123456789,]{1,5}" ControlToValidate="txtpromSinAplazos" ToolTip="Ej: 6,5"></asp:regularexpressionvalidator></td>
		</tr>
		<tr>
			<TD bgColor="#f4f4f4"></TD>
			<TD style="WIDTH: 30px"></TD>
			<td bgColor="#f4f4f4"><STRONG>Titulo Universitario</STRONG></td>
			<td><asp:textbox id="txttituloUniversitario" readonly="False" maxlength="100" runat="server" ToolTip="ej: Analista Universitario de Sistemas"
					Columns="50"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator14" runat="server" ErrorMessage="Dato Titulo Universitario incorrecto. Ej: Analista Universitario de Sistemas"
					ValidationExpression="[\w ]{1,99}" ControlToValidate="txttituloUniversitario" ToolTip="Ej: Analista Universitario de Sistemas"></asp:regularexpressionvalidator></td>
		</tr>
	</table>
</DIV>
<p class="break"></p>
<DIV class="OCULTO" id="pagina_3">
	<table cellSpacing="0" cellPadding="0" border="0">
		<tr>
			<TD style="WIDTH: 30px"></TD>
			<td style="WIDTH: 204px" bgColor="#f4f4f4"><STRONG>Titulo secundario</STRONG></td>
			<td><asp:textbox id="txttitulosecundario" readonly="False" maxlength="100" runat="server" Columns="50"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator15" runat="server" ErrorMessage="Dato Titulo Secundario incorrecto. Ej: Tecnico Mecanico"
					ValidationExpression="[\w ]{1,99}" ControlToValidate="txttitulosecundario" ToolTip="Ej: Tecnico Mecanico"></asp:regularexpressionvalidator></td>
		</tr>
		<tr>
			<TD style="WIDTH: 30px"></TD>
			<td style="WIDTH: 204px" bgColor="#f4f4f4"><STRONG>Archivo CV</STRONG></td>
			<td><INPUT id="txtarchivoCV" type="file" name="File1" runat="server">
				<asp:hyperlink id="linkCV" runat="server">Ver CV actual</asp:hyperlink></td>
		</tr>
		<tr>
			<TD style="WIDTH: 30px"></TD>
			<td style="WIDTH: 204px" bgColor="#f4f4f4"><STRONG>Observaciones</STRONG></td>
			<td><asp:textbox id="txtotrosComentarios" readonly="False" maxlength="1000" runat="server" Columns="100"
					Rows="5" TextMode="MultiLine" Width="100%"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator18" runat="server" ErrorMessage="Dato Observaciones incorrecto"
					ValidationExpression="[\w ]{1,899}" ControlToValidate="txtotrosComentarios" ToolTip="ej: Tambien tengo experiencia en ..."></asp:regularexpressionvalidator></td>
		</tr>
	</table>
</DIV>
<p class="break"></p>
<DIV class="OCULTO" id="pagina_4">
	<table cellSpacing="0" cellPadding="0" border="0">
		<tr>
			<td style="WIDTH: 30px">&nbsp;</td>
			<td><uc1:ucconocimientos1 id="UcConocimientos11" runat="server"></uc1:ucconocimientos1></td>
		</tr>
	</table>
</DIV>
<p class="break"></p>
<DIV class="OCULTO" id="pagina_5">
	<table cellSpacing="0" cellPadding="0" border="0">
		<tr>
			<td style="WIDTH: 30px">&nbsp;</td>
			<td><uc1:ucpostulaciones id="UcPostulaciones1" runat="server"></uc1:ucpostulaciones></td>
		</tr>
	</table>
</DIV>
<div class="divAcciones" id="divAcciones"><asp:button id="btnSave" runat="server" text="Guardar"></asp:button>&nbsp;<asp:button id="btnCancel" runat="server" text="Cancelar" Visible="False" causesvalidation="False"></asp:button>
	<asp:button id="btnModificarConocimientos" runat="server" text="Actualizar Conocimientos" Visible="False"
		causesvalidation="False"></asp:button></div>
<script language="javascript">
//muestro el tab por defecto
	var Tab = document.getElementById("UcDatosPost1_txtValorTab");
	if (Tab.value!=""){muestroPagina(Tab.value);}
</script>
<DIV></DIV>
