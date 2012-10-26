<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucDatosPost" Src="../Controles/ucDatosPost.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="detDatosP.aspx.vb" Inherits="bolsatrabajo.detDatosP"%>
<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Detalle </title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:usmenusae id="UsMenuSAE1" runat="server"></uc1:usmenusae></div>
			<!---->
			<div class="divTitle">Detalle de Postulante</div>
			<div><asp:validationsummary id="ValidationSummary1" runat="server" headertext="<b>Errores en el formulario.</b>"
					cssclass="errorBox"></asp:validationsummary></div>
			<div><asp:label id="lblError" runat="server" cssclass="errorBox" visible="False" width="100%">Mensaje de error personal</asp:label></div>
			<div id="datos">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<TD>
							<uc1:ucDatosPost id="UcDatosPost1" runat="server"></uc1:ucDatosPost><br>
							<asp:Button id="cmdvolver" runat="server" Text="Volver" CausesValidation="False"></asp:Button>
							<asp:Button id="cmdRevisado" runat="server" Text="Actualizar revision"></asp:Button>
						</TD>
					</tr>
				</table>
			</div>
			<div id="piePag">
				<uc1:ucBolsaTrabajoPie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucBolsaTrabajoPie>
			</div>
			<!-- ### CONTENIDO AQUI ### --></form>
	</body>
</HTML>
