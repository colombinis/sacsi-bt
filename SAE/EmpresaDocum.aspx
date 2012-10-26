<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmpresaDocum.aspx.vb" Inherits="bolsatrabajo.EmpresasDocum"%>
<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Documentacion presentada por la Empresa</title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:usMenuSAE id="UsMenuSAE1" runat="server"></uc1:usMenuSAE></div>
			<!-- ### CONTENIDO AQUI ### -->
			<div class="divTitle">Documentacion presentada por la Empresa:</div>
			<div id="datos">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<TD width="27" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">CUIT</td>
						<td><asp:textbox id="txtCuit" runat="server" width="200px" maxlength="100"></asp:textbox></td>
					</tr>
					<TR>
						<TD width="27" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">Razon social</TD>
						<TD><asp:textbox id="txtRazonSocial" runat="server" width="200px" maxlength="100"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="27" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">Domicilio</TD>
						<TD><asp:textbox id="txtDomicilio" runat="server" width="200px" maxlength="100"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="27" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">Telefonos</TD>
						<TD><asp:textbox id="txtTelefonos" runat="server" width="200px" maxlength="100"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="27" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">Tipo Empresa</TD>
						<TD>
							<asp:dropdownlist id="cboTipoEmpresa" runat="server" width="200px"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD width="27" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">Estado Empresa</TD>
						<TD>
							<asp:dropdownlist id="cboEstadoEmpresa" runat="server" width="200px"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD width="27" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">
							<P>Documentacion</P>
						</TD>
						<TD><asp:datagrid id="oGrid" runat="server" AutoGenerateColumns="False" Width="100%">
								<AlternatingItemStyle CssClass="gridAlternativeItem"></AlternatingItemStyle>
								<HeaderStyle CssClass="GridHeader"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<ItemTemplate>
											<asp:CheckBox id="chkRow" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="idDocumento" HeaderText="idDoc"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="idEmpresa" HeaderText="idEmpresa"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="idMomento" HeaderText="idMomento"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="Presentado" HeaderText="Presentado"></asp:BoundColumn>
									<asp:BoundColumn DataField="dscDocumento" HeaderText="Tilde la Doc presentada"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="requerido" HeaderText="requerido"></asp:BoundColumn>
								</Columns>
								<PagerStyle CssClass="GridHeader"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</table>
			</div>
			<div class="divAcciones" id="divAcciones"><asp:button id="cmdAceptar" runat="server" Text="Aceptar"></asp:button>
				<asp:Button id="cmdVolver" runat="server" Text="Volver"></asp:Button></div>
			<div id="piePag">
				<uc1:ucBolsaTrabajoPie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucBolsaTrabajoPie>
			</div>
			<!-- ### CONTENIDO AQUI ### --></form>
	</body>
</HTML>
