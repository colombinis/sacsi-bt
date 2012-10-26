<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="detConocimiento.aspx.vb" Inherits="bolsatrabajo.detConocimiento"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Detalle </title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:usmenusae id="UsMenuSAE1" runat="server"></uc1:usmenusae></div>
			<div class="divTitle">Detalle de conocimiento</div>
			<div><asp:validationsummary id="ValidationSummary1" runat="server" cssclass="errorBox" headertext="<b>Errores en el formulario.</b>"></asp:validationsummary></div>
			<div><asp:label id="lblError" runat="server" cssclass="errorBox" visible="False" width="100%">Mensaje de error personal</asp:label></div>
			<div id="datos">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<TD width="36" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">Codigo</td>
						<td><asp:textbox id="txtidConocimiento" runat="server" maxlength="10" readonly="True"></asp:textbox></td>
					</tr>
					<tr>
						<TD width="36" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">Conocimiento</td>
						<td><asp:textbox id="txtdscConocimiento" runat="server" maxlength="100" readonly="False" Width="100%"></asp:textbox><asp:requiredfieldvalidator id="reqdscConocimiento" runat="server" errormessage="El dato dscConocimiento es requerido."
								controltovalidate="txtdscConocimiento" display="None"></asp:requiredfieldvalidator></td>
					</tr>
				</table>
			</div>
			<div class="divAcciones" id="divAcciones"><asp:button id="btnSave" runat="server" text="Guardar"></asp:button>&nbsp;<asp:button id="btnCancel" runat="server" text="Cancelar" causesvalidation="False"></asp:button></div>
			<div id="piePag"><uc1:ucbolsatrabajopie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucbolsatrabajopie></div>
			<!-- ### CONTENIDO AQUI ### --></form>
	</body>
</HTML>
