<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EnviarEmail.aspx.vb" Inherits="bolsatrabajo.EnviarEmail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>EnviarEmail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
				<TR>
					<TD>De</TD>
					<TD>
						<asp:TextBox id="txtDe" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>Para</TD>
					<TD>
						<asp:TextBox id="txtPara" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>Asunto</TD>
					<TD>
						<asp:TextBox id="txtAsunto" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>Mensaje</TD>
					<TD>
						<asp:TextBox id="txtMensaje" runat="server" Rows="10" Columns="50" TextMode="MultiLine"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:CheckBox id="chkIncluirAtach" runat="server" Text="Incluir ultimo archivo generado"></asp:CheckBox></TD>
				</TR>
				<TR>
					<TD>
						<asp:Button id="cmdEnviar" runat="server" Text="Enviar email"></asp:Button></TD>
					<TD></TD>
				</TR>
			</TABLE>
			<asp:Label id="lblLog" runat="server"></asp:Label></form>
	</body>
</HTML>
