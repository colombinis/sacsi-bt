<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mUpF.aspx.vb" Inherits="bolsatrabajo.mUpF"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Subir Archivos</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server" enctype="multipart/form-data">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
				<TR>
					<TD><INPUT id="file" type="file" runat="server" NAME="file"></TD>
					<TD>
						<asp:Button id="cmdGuardar" runat="server" Text="Actualizar"></asp:Button></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
