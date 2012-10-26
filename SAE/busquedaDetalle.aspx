<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="busquedaDetalle.aspx.vb" Inherits="bolsatrabajo.busquedaDetalle" validateRequest="false"%>
<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Detalle </title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:usMenuSAE id="UsMenuSAE1" runat="server"></uc1:usMenuSAE></div>
			<!--CONTENIDO-->
			<div class="divTitle">Detalle de Busqueda</div>
			<div><asp:validationsummary id="ValidationSummary1" runat="server" cssclass="errorBox" headertext="<b>Errores en el formulario.</b>"></asp:validationsummary></div>
			<div><asp:label id="lblError" runat="server" cssclass="errorBox" visible="False" width="100%">Mensaje de error personal</asp:label></div>
			<div id="datos">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<TD width="23" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4" width="92">Cod Empresa</td>
						<td><asp:textbox id="txtidEmpresa" runat="server" maxlength="10" readonly="True"></asp:textbox></td>
					</tr>
					<tr>
						<TD width="23" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4" width="92">Nro Busqueda</td>
						<td><asp:textbox id="txtidBusqueda" runat="server" maxlength="10" ReadOnly="True"></asp:textbox></td>
					</tr>
					<TR>
						<TD width="23" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4" width="92">Busqueda publica</TD>
						<TD>
							<asp:DropDownList id="cbobusquedaPublica" runat="server">
								<asp:ListItem Value="S">SI</asp:ListItem>
								<asp:ListItem Value="N">No</asp:ListItem>
							</asp:DropDownList></TD>
					</TR>
					<tr>
						<TD width="23" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4" width="92">Titulo</td>
						<td><asp:textbox id="txttitulo" runat="server" maxlength="100" Width="481px"></asp:textbox><asp:requiredfieldvalidator id="reqtitulo" runat="server" errormessage="El dato titulo es requerido." controltovalidate="txttitulo"
								display="None"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<TD width="23" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4" width="92">Tipo Vinculo</td>
						<td>
							<asp:dropdownlist id="cboVinculo" runat="server" width="200px"></asp:dropdownlist><asp:requiredfieldvalidator id="reqtipoVinculo" runat="server" errormessage="El dato tipoVinculo es requerido."
								controltovalidate="cboVinculo" display="None" InitialValue="-1"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<TD width="23" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4" width="92">Fecha Desde</td>
						<td><asp:textbox id="txtfechaDesde" runat="server" maxlength="23"></asp:textbox><asp:requiredfieldvalidator id="reqfechaDesde" runat="server" errormessage="El dato fechaDesde es requerido."
								controltovalidate="txtfechaDesde" display="None"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<TD width="23" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4" width="92">Fecha Hasta</td>
						<td><asp:textbox id="txtfechaHasta" runat="server" maxlength="23"></asp:textbox><asp:requiredfieldvalidator id="reqfechaHasta" runat="server" errormessage="El dato fechaHasta es requerido."
								controltovalidate="txtfechaHasta" display="None"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<TD width="23" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4" width="92">Otros Requisitos</td>
						<td><asp:textbox id="txtotroRequisitos" runat="server" maxlength="4000" Width="100%" TextMode="MultiLine"
								Height="70%"></asp:textbox><asp:requiredfieldvalidator id="reqotroRequisitos" runat="server" errormessage="El dato otroRequisitos es requerido."
								controltovalidate="txtotroRequisitos" display="None"></asp:requiredfieldvalidator></td>
					</tr>
					<TR>
						<TD width="23" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4" width="92">Especialidad</TD>
						<TD>
							<asp:datagrid id="gridEspecialidad" runat="server" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="gridAlternativeItem"></AlternatingItemStyle>
								<HeaderStyle CssClass="GridHeader"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<ItemTemplate>
											<asp:CheckBox id="chkRow" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="DESCRIPCION" HeaderText="Seleccione la Especialidad"></asp:BoundColumn>
								</Columns>
								<PagerStyle CssClass="GridHeader"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</table>
			</div>
			<div class="divAcciones" id="divAcciones"><asp:button id="btnSave" runat="server" text="Guardar"></asp:button>&nbsp;<asp:button id="btnCancel" runat="server" text="Cancelar" causesvalidation="False"></asp:button>
				<asp:button id="AficheEditable" runat="server" text="Afiche Editable" causesvalidation="False"></asp:button></div>
			<div id="piePag">
				<uc1:ucBolsaTrabajoPie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucBolsaTrabajoPie>
			</div>
			<!-- ### CONTENIDO AQUI ### --></form>
	</body>
</HTML>
