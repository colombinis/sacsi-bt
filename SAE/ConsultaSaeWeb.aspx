<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ConsultaSaeWeb.aspx.vb" Inherits="bolsatrabajo.ConsultaSaeWeb"%>
<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Consulta del Postulante al SysAcad</title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:usmenusae id="UsMenuSAE1" runat="server"></uc1:usmenusae></div>
			<div class="divTitle">Consulta del Postulante al SysAcad</div>
			<div><asp:validationsummary id="ValidationSummary1" runat="server" headertext="<b>Errores en el formulario.</b>"
					cssclass="errorBox"></asp:validationsummary></div>
			<div><asp:label id="lblError" runat="server" cssclass="errorBox" width="100%" visible="False">Mensaje de error personal</asp:label></div>
			<div id="datos">
				<table cellSpacing="4" cellPadding="0" width="100%" border="0">
					<TR>
						<TD><asp:label id="lblPlan" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD><asp:label id="lblDatosPersonales" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD><asp:label id="lblMateriasRegulares" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD><asp:label id="lblExamenes" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD><asp:label id="lblPromedio" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD><asp:label id="lblCursadoActual" runat="server"></asp:label></TD>
					</TR>
				</table>
			</div>
			<div class="divAcciones" id="divAcciones">&nbsp;<asp:button id="cmdVolver" runat="server" causesvalidation="False" text="Volver"></asp:button></div>
			<div id="piePag"><uc1:ucbolsatrabajopie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucbolsatrabajopie></div>
			<!-- ### CONTENIDO AQUI ### --></form>
	</body>
</HTML>
