<%@ Page Language="vb" AutoEventWireup="false" Codebehind="msgGral.aspx.vb" Inherits="bolsatrabajo.msgGral"%>
<%@ Register TagPrefix="uc1" TagName="ucIngreso_BannerTop" Src="Controles/ucIngreso_BannerTop.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucIngreso_Foot" Src="Controles/ucIngreso_Foot.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="Controles/ucBolsaTrabajoPie.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Bolsa de trabajo</title>
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onclick="OcultarTodos();">
		<form id="Form1" method="post" runat="server">
			<TABLE WIDTH="760" BORDER="0" CELLSPACING="0" CELLPADDING="0" align="center">
				<TR>
					<TD><uc1:ucIngreso_BannerTop id="UcIngreso_BannerTop1" runat="server"></uc1:ucIngreso_BannerTop></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<div id="cuerpomensaje" style="HEIGHT:500px;TEXT-ALIGN:center;whidth:300px">
							<!--c-->
							<asp:Label id="lblMensaje" runat="server" Font-Size="X-Large">Mensaje</asp:Label>
							<!--c f-->
						</div>
					</TD>
				</TR>
				<TR>
					<TD>
						<uc1:ucBolsaTrabajoPie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucBolsaTrabajoPie></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
