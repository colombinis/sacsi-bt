<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucCuotas" Src="../Controles/ucCuotas.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PostAmano.aspx.vb" Inherits="bolsatrabajo.PostAmano"%>
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
						<td style="WIDTH: 105px">Postulante</td>
						<td><asp:textbox id="txtPostulante" runat="server" readonly="False" maxlength="10" Width="100%" Enabled="False"></asp:textbox></td>
					</tr>
					<tr>
						<td style="WIDTH: 105px">Busqueda</td>
						<td>
							<asp:dropdownlist id="cboBusqueda" runat="server"></asp:dropdownlist></td>
					</tr>
					<TR>
						<TD style="WIDTH: 105px"></TD>
						<TD></TD>
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
