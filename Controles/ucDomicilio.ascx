<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucDomicilio.ascx.vb" Inherits="bolsatrabajo.ucDomicilio" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<div id="datos">
	<table cellSpacing="0" cellPadding="0" width="472" border="0" style="WIDTH: 472px; HEIGHT: 291px">
		<tr>
			<td style="WIDTH: 136px; HEIGHT: 23px" bgColor="#f4f4f4"><STRONG>Calle</STRONG>
			</td>
			<TD style="HEIGHT: 23px">
				<asp:textbox id="txtcalle" runat="server" readonly="False" maxlength="100" ToolTip="ej: Entre Rios"
					Columns="50"></asp:textbox>
				<asp:RegularExpressionValidator id="RegularExpressionValidator15" runat="server" ToolTip="ej: Entre Rios" ErrorMessage="Dato Calle incorrecto"
					ValidationExpression="[\w ]{1,99}" ControlToValidate="txtcalle"></asp:RegularExpressionValidator></TD>
		</tr>
		<tr>
			<td style="WIDTH: 136px" bgColor="#f4f4f4"><STRONG>Nro Calle</STRONG>&nbsp;&nbsp;
			</td>
			<TD>
				<asp:textbox id="txtnroCalle" runat="server" readonly="False" maxlength="100" ToolTip="ej: 1341"
					Columns="10"></asp:textbox>
				<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ToolTip="Ej: 1341" ErrorMessage="Dato Nro Calle incorrecto. Ej: 1341"
					ValidationExpression="\d{1,5}" ControlToValidate="txtnroCalle"></asp:RegularExpressionValidator></TD>
		</tr>
		<TR>
			<TD style="WIDTH: 136px" bgColor="#f4f4f4"><STRONG>Letra Bis</STRONG>
			</TD>
			<TD>
				<asp:textbox id="txtletraBis" runat="server" readonly="False" maxlength="100" Columns="2"></asp:textbox>
				<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ToolTip="ej: A" ErrorMessage="Dato Letra Bis incorrecto"
					ValidationExpression="\w{1,9}" ControlToValidate="txtletraBis"></asp:RegularExpressionValidator></TD>
		</TR>
		<tr>
			<td style="WIDTH: 136px" bgColor="#f4f4f4"><STRONG>Piso</STRONG>&nbsp;
			</td>
			<TD>
				<asp:textbox id="txtpiso" runat="server" readonly="False" maxlength="100" ToolTip="ej: 1" Columns="2"></asp:textbox>
				<asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ToolTip="ej: 1" ErrorMessage="Dato Piso incorrecto"
					ValidationExpression="\w{1,9}" ControlToValidate="txtpiso"></asp:RegularExpressionValidator></TD>
		</tr>
		<TR>
			<TD style="WIDTH: 136px" bgColor="#f4f4f4"><STRONG>Depto</STRONG></TD>
			<TD>
				<asp:textbox id="txtdepto" runat="server" readonly="False" maxlength="100" ToolTip="ej: B" Columns="2"></asp:textbox>
				<asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ToolTip="ej: B" ErrorMessage="Dato depto incorrecto"
					ValidationExpression="\w{1,9}" ControlToValidate="txtdepto"></asp:RegularExpressionValidator></TD>
		</TR>
		<tr>
			<td style="WIDTH: 136px" bgColor="#f4f4f4"><STRONG>Pais</STRONG>&nbsp;&nbsp;&nbsp;
			</td>
			<TD>
				<asp:DropDownList id="txtpais" runat="server" AutoPostBack="True">
					<asp:ListItem Value="-1">(---)</asp:ListItem>
				</asp:DropDownList></TD>
		</tr>
		<TR>
			<TD style="WIDTH: 136px" bgColor="#f4f4f4"><STRONG>Provincia</STRONG></TD>
			<TD>
				<asp:DropDownList id="txtprovincia" runat="server" AutoPostBack="True">
					<asp:ListItem Value="-1">(---)</asp:ListItem>
				</asp:DropDownList></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 136px" bgColor="#f4f4f4"><STRONG>Localidad</STRONG></TD>
			<TD>
				<asp:DropDownList id="txtlocalidad" runat="server">
					<asp:ListItem Value="-1">(---)</asp:ListItem>
				</asp:DropDownList></TD>
		</TR>
		<tr>
			<td style="WIDTH: 136px; HEIGHT: 22px" bgColor="#f4f4f4"><STRONG>Telefono particular</STRONG>
			</td>
			<TD style="HEIGHT: 22px">
				<asp:textbox id="txttelParticular" runat="server" readonly="False" maxlength="100" Columns="50"></asp:textbox>
				<asp:RegularExpressionValidator id="RegularExpressionValidator5" runat="server" ToolTip="Ej: 342 156784523" ErrorMessage="Dato Telefono particular incorrecto. Ej: 342 156784523"
					ValidationExpression="[\w- ]{1,50}" ControlToValidate="txttelParticular"></asp:RegularExpressionValidator></TD>
		</tr>
		<tr>
			<td style="WIDTH: 136px" bgColor="#f4f4f4"><STRONG>Otros Telefonos</STRONG>
			</td>
			<TD>
				<asp:textbox id="txtotrosTelefonos" runat="server" readonly="False" maxlength="100" Columns="50"></asp:textbox>
				<asp:RegularExpressionValidator id="RegularExpressionValidator6" runat="server" ToolTip="Ej: 342 156784523" ErrorMessage="Dato Otros telefonos incorrecto. Ej: 342 156784523"
					ValidationExpression="[\w- ]{1,50}" ControlToValidate="txtotrosTelefonos"></asp:RegularExpressionValidator></TD>
		</tr>
	</table>
</div>
