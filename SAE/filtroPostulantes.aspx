<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="filtroPostulantes.aspx.vb" Inherits="bolsatrabajo.filtroPostulantes"%>
<%@ Register TagPrefix="uc1" TagName="ucfiltrado" Src="../Controles/ucfiltrado.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Lista</title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:usMenuSAE id="UsMenuSAE1" runat="server"></uc1:usMenuSAE></div>
			<!-- ### CONTENIDO AQUI ### -->
			<input type="hidden" id="txtIDOculto" runat="server" NAME="txtIDOculto">
			<div><asp:label id="lblError" runat="server" cssclass="errorBox" visible="False" width="100%">Mensaje de error personal</asp:label></div>
			
			<div class="divTitle" runat="server" id="Div1">Buscar Postulantes que cumplan con 
				los siguientes criterios:</div>
			<div class="divFiltro" align="center">
				<uc1:ucfiltrado id="Ucfiltrado1" runat="server"></uc1:ucfiltrado>
			</div>
			<div class="divTitle" runat="server" id="cantReg">Lista de Postulante(--)</div>
			<div id="divAcciones" class="divAcciones">
				<asp:Button id="cmdExportarGrilla" runat="server" Text="Exportar Grilla a Excel" CausesValidation="False"
					Enabled="False"></asp:Button>
			</div>
			<div id="datos">
				<asp:datagrid id="oGrid" runat="server" Width="100%">
					<AlternatingItemStyle CssClass="gridAlternativeItem"></AlternatingItemStyle>
					<HeaderStyle CssClass="GridHeader"></HeaderStyle>
					<PagerStyle CssClass="GridHeader"></PagerStyle>
				</asp:datagrid>
			</div>

			<div id="piePag">
				<uc1:ucBolsaTrabajoPie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucBolsaTrabajoPie>
			</div>
			<!-- ### CONTENIDO AQUI ###-->
		</form>
	</BODY>
</HTML>
