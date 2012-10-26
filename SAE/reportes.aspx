<%@ Page Language="vb" AutoEventWireup="false" Codebehind="reportes.aspx.vb" Inherits="bolsatrabajo.reportes"%>
<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Reportes</title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:usmenusae id="UsMenuSAE1" runat="server"></uc1:usmenusae></div>
			<!-- ### CONTENIDO AQUI ### -->

			<!-- ### CONTENIDO AQUI ### -->
			<div id="piePag"><uc1:ucbolsatrabajopie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucbolsatrabajopie></div>
			
		</form>
		
	</BODY>
</HTML>