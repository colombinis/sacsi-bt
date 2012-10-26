<%@ Page Language="vb" AutoEventWireup="false" Codebehind="datosPersonal.aspx.vb" Inherits="bolsatrabajo.datosPersonal"%>
<%@ Register TagPrefix="uc1" TagName="ucConocimientos1" Src="../Controles/ucConocimientos1.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucDatosPost" Src="../Controles/ucDatosPost.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucMenuPostulante" Src="../Controles/ucMenuPostulante.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucDomicilio" Src="../Controles/ucDomicilio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Detalle </title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
			<style type="text/css">
			#tabulador UL { PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; WIDTH: 100%; PADDING-TOP: 0px; LIST-STYLE-TYPE: none }
			#tabulador UL LI { DISPLAY: inline }
			#tabulador UL LI A:hover { COLOR: blue }
			#tabulador UL LI A:active { COLOR: black }
			P.break { PAGE-BREAK-AFTER: always }
			</style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:ucMenuPostulante id="UcMenuPostulante1" runat="server"></uc1:ucMenuPostulante></div>
			<!---->
			<div class="divTitle">Detalle de Postulante</div>
			<div><asp:validationsummary id="ValidationSummary1" runat="server" headertext="<b>Errores en el formulario.</b>"
					cssclass="errorBox"></asp:validationsummary></div>
			<div><asp:label id="lblError" runat="server" cssclass="errorBox" visible="False" width="100%">Mensaje de error personal</asp:label></div>
			<div id="datos">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<TD>
							<uc1:ucDatosPost id="UcDatosPost1" runat="server"></uc1:ucDatosPost>
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
