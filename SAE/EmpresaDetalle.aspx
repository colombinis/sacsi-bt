<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmpresaDetalle.aspx.vb" Inherits="bolsatrabajo.EmpresaDetalle"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Detalle Empresa</title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:usMenuSAE id="UsMenuSAE1" runat="server"></uc1:usMenuSAE></div>
			<div class="divTitle">Detalle de Empresa</div>
			<div><asp:validationsummary id="ValidationSummary1" runat="server" headertext="<b>Errores en el formulario.</b>"
					cssclass="errorBox"></asp:validationsummary></div>
			<div><asp:label id="lblError" runat="server" cssclass="errorBox" width="100%" visible="False">Ya existe una Empresa con ese CUIT</asp:label></div>
			<div id="datos">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<TD width="26" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">Código</td>
						<td><asp:textbox id="txtID" runat="server" readonly="True"></asp:textbox></td>
					</tr>
					<tr>
						<TD width="26" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">CUIT</td>
						<td><asp:textbox id="txtCuit" runat="server" width="200px" maxlength="15"></asp:textbox><asp:requiredfieldvalidator id="vldDescripcion" runat="server" display="None" controltovalidate="txtCuit" errormessage="El campo CUIT es requerido."></asp:requiredfieldvalidator></td>
					</tr>
					<TR>
						<TD width="26" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">Razon social</TD>
						<TD><asp:textbox id="txtRazonSocial" runat="server" width="200px" maxlength="100"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" display="None" controltovalidate="txtRazonSocial"
								errormessage="El campo Razon social es requerido."></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD width="26" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">Domicilio</TD>
						<TD><asp:textbox id="txtDomicilio" runat="server" width="200px" maxlength="100"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="26" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">Telefonos</TD>
						<TD><asp:textbox id="txtTelefonos" runat="server" width="200px" maxlength="50"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" display="None" controltovalidate="txtTelefonos"
								errormessage="El campo Telefonos es requerido."></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD width="26" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">Email</TD>
						<TD><asp:textbox id="txtEmail" runat="server" width="200px" maxlength="50"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" display="None" controltovalidate="txtEmail"
								errormessage="El campo Email es requerido."></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD width="26" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">Pagina Web</TD>
						<TD><asp:textbox id="txtPaginaWeb" runat="server" width="200px" maxlength="50"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="26" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">Persona Contacto</TD>
						<TD><asp:textbox id="txtPersonaContacto" runat="server" width="200px" maxlength="50"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator6" runat="server" display="None" controltovalidate="txtPersonaContacto"
								errormessage="El campo Persona Contacto es requerido."></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD width="26" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">Tipo Empresa</TD>
						<TD><asp:dropdownlist id="cboTipoEmpresa" runat="server" width="200px"></asp:dropdownlist><asp:requiredfieldvalidator id="Requiredfieldvalidator7" runat="server" display="None" controltovalidate="cboTipoEmpresa"
								errormessage="El campo Tipo Empresa es requerido." InitialValue="-1"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD width="26" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">Estado Empresa</TD>
						<TD>
							<asp:dropdownlist id="cboEstadoEmpresa" runat="server" width="200px"></asp:dropdownlist>
							<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" errormessage="El campo Estado Empresa es requerido."
								controltovalidate="cboEstadoEmpresa" display="None" InitialValue="-1"></asp:requiredfieldvalidator></TD>
					</TR>
				</table>
			</div>
			<div id="divAcciones" class="divAcciones"><asp:button id="btnSave" runat="server" text="Guardar"></asp:button>&nbsp;<asp:button id="btnCancel" runat="server" text="Cancelar" causesvalidation="False"></asp:button></div>
			<div id="piePag">
				<uc1:ucBolsaTrabajoPie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucBolsaTrabajoPie>
			</div>
			<!-- ### CONTENIDO AQUI ### --></form>
	</body>
</HTML>
