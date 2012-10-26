<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ct.aspx.vb" Inherits="bolsatrabajo.ct"%>
<%@ Register TagPrefix="uc1" TagName="ucConocimientos1" Src="../Controles/ucConocimientos1.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucConocimientos" Src="../Controles/ucConocimientos.ascx" %>
<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Conocimientos</title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:usmenusae id="UsMenuSAE1" runat="server"></uc1:usmenusae></div>
			<!---->
			<div class="divTitle">Conocimientos</div>
			<div><asp:validationsummary id="ValidationSummary1" runat="server" headertext="<b>Errores en el formulario.</b>"
					cssclass="errorBox"></asp:validationsummary></div>
			<div><asp:label id="lblError" runat="server" cssclass="errorBox" visible="False" width="100%">Mensaje de error personal</asp:label></div>
			<div id="datos">
				<table cellSpacing="4" cellPadding="0" width="100%" border="0">
					<tr>
						<td>
							<uc1:ucConocimientos1 id="UcConocimientos11" runat="server"></uc1:ucConocimientos1></td>
					</tr>
				</table>
			</div>
			<div class="divAcciones" id="divAcciones">&nbsp;
				<asp:button id="btnCancel" runat="server" text="Volver" causesvalidation="False"></asp:button>
			</div>
			<div id="piePag">
				<uc1:ucBolsaTrabajoPie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucBolsaTrabajoPie>
			</div>
			<!-- ### CONTENIDO AQUI ### --></form>
	</body>
</HTML>
