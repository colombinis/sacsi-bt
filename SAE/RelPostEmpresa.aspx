<%@ Register TagPrefix="uc1" TagName="ucCuotas" Src="../Controles/ucCuotas.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RelPostEmpresa.aspx.vb" Inherits="bolsatrabajo.RelPostEmpresa"%>
<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<HTML>
	<HEAD>
		<title>Detalle </title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:usmenusae id="UsMenuSAE1" runat="server"></uc1:usmenusae></div>
			<div class="divTitle">Detalle del vinculo entre la empresa y el postulante</div>
			<div><asp:validationsummary id="ValidationSummary1" runat="server" headertext="<b>Errores en el formulario.</b>"
					cssclass="errorBox"></asp:validationsummary></div>
			<div><asp:label id="lblError" runat="server" cssclass="errorBox" width="100%" visible="False">Mensaje de error personal</asp:label></div>
			<div id="datos">
				<table cellSpacing="4" cellPadding="0" width="100%" border="0">
					<tr>
						<td>Postulante</td>
						<td><asp:textbox id="txtidPostulante" runat="server" readonly="False" maxlength="10" Width="100%"></asp:textbox></td>
					</tr>
					<tr>
						<td>Empresa</td>
						<td><asp:textbox id="txtidEmpresa" runat="server" readonly="False" maxlength="10" Width="100%"></asp:textbox></td>
					</tr>
					<tr>
						<td>fecha Inicio</td>
						<td><asp:textbox id="txtfechaInicio" runat="server" readonly="False" maxlength="10"></asp:textbox><asp:requiredfieldvalidator id="reqfechaInicio" runat="server" display="None" controltovalidate="txtfechaInicio"
								errormessage="El dato fechaInicio es requerido."></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td>fecha Fin</td>
						<td><asp:textbox id="txtfechaFin" runat="server" readonly="False" maxlength="10"></asp:textbox><asp:requiredfieldvalidator id="reqfechaFin" runat="server" display="None" controltovalidate="txtfechaFin" errormessage="El dato fechaFin es requerido."></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td>tipo vinculo</td>
						<td><asp:dropdownlist id="cboTipoVinculo" runat="server"></asp:dropdownlist><asp:requiredfieldvalidator id="reqtipovinculo" runat="server" display="None" controltovalidate="cboTipoVinculo"
								errormessage="El dato tipovinculo es requerido." InitialValue="-1"></asp:requiredfieldvalidator></td>
					</tr>
					<TR>
						<TD></TD>
						<TD><uc1:uccuotas id="UcCuotas1" runat="server"></uc1:uccuotas></TD>
					</TR>
				</table>
			</div>
			<div class="divAcciones" id="divAcciones"><asp:button id="btnSave" runat="server" text="Guardar"></asp:button>&nbsp;<asp:button id="btnCancel" runat="server" text="Cancelar" causesvalidation="False"></asp:button></div>
			<div id="piePag">
				<uc1:ucBolsaTrabajoPie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucBolsaTrabajoPie>
			</div>
			<!-- ### CONTENIDO AQUI ### --></form>
	</body>
</HTML>
