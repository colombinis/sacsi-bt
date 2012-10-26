<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucLogin.ascx.vb" Inherits="bolsatrabajo.ucLogin" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE BORDER="0" CELLSPACING="2" CELLPADDING="0" align="center" style="BORDER-RIGHT:1px solid; BORDER-TOP:1px solid; BORDER-LEFT:1px solid; BORDER-BOTTOM:1px solid">
	<TR>
		<TD class="TextoNormal" align="center" colSpan="2">
			<asp:Label id="lblError" runat="server" ForeColor="Red" Visible="False" CssClass="TextoNormal">Label</asp:Label></TD>
	</TR>
	<TR>
		<TD colspan="2" class="TextoNormal"><b><u>Acceso al sistema</u></b></TD>
	</TR>
	<TR>
		<TD class="TextoNormal">
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtUsuario"
				Display="Dynamic"></asp:RequiredFieldValidator>Usuario</TD>
		<TD>&nbsp;
			<asp:TextBox id="txtUsuario" runat="server" MaxLength="50"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD class="TextoNormal">
			<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtPassword"
				Display="Dynamic"></asp:RequiredFieldValidator>Contraseña</TD>
		<TD>&nbsp;
			<asp:TextBox id="txtPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD class="TextoNormal">&nbsp;</TD>
		<TD align="right" class="TextoNormal"><asp:Button id="cmdAceptar" runat="server" Text="Aceptar"></asp:Button></TD>
	</TR>
</TABLE>

