<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="detCuotas.aspx.vb" Inherits="bolsatrabajo.detCuotas"%>
<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<HTML>
	<HEAD>
		<title>Detalle de la cuota</title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
			<script language="javascript">
			function validarOnSub(msg)
			{
				return confirm(msg);
			}
			</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:usmenusae id="UsMenuSAE1" runat="server"></uc1:usmenusae></div>
			<div class="divTitle">Detalle de la cuota</div>
			<div><asp:validationsummary id="ValidationSummary1" runat="server" cssclass="errorBox" headertext="<b>Errores en el formulario.</b>"></asp:validationsummary></div>
			<div><asp:label id="lblError" runat="server" cssclass="errorBox" visible="False" width="100%">Mensaje de error personal</asp:label></div>
			<div id="datos">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="25" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">Cod Cuota</TD>
						<TD><asp:textbox id="txtidCuota" runat="server" maxlength="10" readonly="False"></asp:textbox></TD>
					</TR>
					<tr>
						<TD width="25" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">Fecha Vencimiento</td>
						<td><asp:textbox id="txtfechaVto1" runat="server" maxlength="23" readonly="False"></asp:textbox><asp:requiredfieldvalidator id="reqfechaVto1" runat="server" errormessage="El dato fechaVto1 es requerido."
								controltovalidate="txtfechaVto1" display="None"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<TD width="25" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">Concepto</td>
						<td><asp:textbox id="txtdscConcepto" runat="server" maxlength="100" readonly="False"></asp:textbox><asp:requiredfieldvalidator id="reqdscConcepto" runat="server" errormessage="El dato dscConcepto es requerido."
								controltovalidate="txtdscConcepto" display="None"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<TD width="25" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">Valor</td>
						<td><asp:textbox id="txtvalor" runat="server" maxlength="18" readonly="False"></asp:textbox><asp:requiredfieldvalidator id="reqvalor" runat="server" errormessage="El dato valor es requerido." controltovalidate="txtvalor"
								display="None"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<TD width="25" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">Estado de la Cuota</td>
						<td><asp:dropdownlist id="cboidEstadoCuota" runat="server"></asp:dropdownlist></td>
					</tr>
					<tr>
						<TD width="25" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">Empresa</td>
						<td><asp:dropdownlist id="cboidEmpresa" runat="server"></asp:dropdownlist><asp:requiredfieldvalidator id="reqidEmpresa" runat="server" errormessage="El dato idEmpresa es requerido."
								controltovalidate="cboidEmpresa" display="None"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<TD width="25" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">Busqueda</td>
						<td><asp:dropdownlist id="cboidBusqueda" runat="server"></asp:dropdownlist><asp:requiredfieldvalidator id="reqidBusqueda" runat="server" errormessage="El dato idBusqueda es requerido."
								controltovalidate="cboidBusqueda" display="None"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<TD width="25" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">Postulante</td>
						<td><asp:dropdownlist id="cboidPostulante" runat="server"></asp:dropdownlist><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" errormessage="El dato Postulante es requerido."
								controltovalidate="cboidPostulante" display="None"></asp:requiredfieldvalidator></td>
					</tr>
				</table>
			</div>
			<div class="divAcciones" id="divAcciones"><asp:button id="btnSave" runat="server" text="Guardar"></asp:button>&nbsp;<asp:button id="btnCancel" runat="server" text="Cancelar" causesvalidation="False"></asp:button>
				<asp:button id="cmdAfiche" runat="server" text="Nota de Pago" causesvalidation="False"></asp:button><asp:button id="btnPagar" runat="server" text="Pagar" causesvalidation="False"></asp:button></div>
			<div id="piePag"><uc1:ucbolsatrabajopie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucbolsatrabajopie></div>
			<!-- ### CONTENIDO AQUI ### --></form>
	</body>
</HTML>
