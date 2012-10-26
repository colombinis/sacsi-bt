<%@ Register TagPrefix="uc1" TagName="ucMenuPostulante" Src="../Controles/ucMenuPostulante.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="detBP.aspx.vb" Inherits="bolsatrabajo.detBP"%>
<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Detalle </title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
			<style>
			INPUT { BORDER-RIGHT: #fff 1px solid; BORDER-TOP: #fff 1px solid; BORDER-LEFT: #fff 1px solid; BORDER-BOTTOM: #fff 1px solid }
			TEXTAREA { BORDER-RIGHT: #fff 1px solid; BORDER-TOP: #fff 1px solid; BORDER-LEFT: #fff 1px solid; BORDER-BOTTOM: #fff 1px solid }
			SELECT { BORDER-RIGHT: #fff 1px solid; BORDER-TOP: #fff 1px solid; BORDER-LEFT: #fff 1px solid; BORDER-BOTTOM: #fff 1px solid }
			</style>
			<script language="javascript">
			function init()
			{
				var capCbo= document.getElementById("capVinculo");
				var Cbo= document.getElementById("cboVinculo");
				capCbo.innerHTML=Cbo.item(Cbo.selectedIndex).text;
				Cbo.style.display='none';
			}
			
			function verAfiche(str)
			{
				var oW=window.open("afichebusqueda.htm"+str);
			}
		
			</script>
	</HEAD>
	<body onload="init();">
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:ucMenuPostulante id="UcMenuPostulante1" runat="server"></uc1:ucMenuPostulante></div>
			<!---->
			<div class="divTitle">Detalle de Busqueda</div>
			<div><asp:label id="lblError" runat="server" cssclass="errorBox" visible="False" width="100%">Mensaje de error personal</asp:label></div>
			<div id="datos">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<TD width="22"></TD>
						<td></td>
						<td><asp:textbox id="txtidEmpresa" runat="server" maxlength="10" readonly="True" Visible="False">noMuestro</asp:textbox></td>
					</tr>
					<tr>
						<TD width="22" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">Nro Busqueda</td>
						<td><asp:textbox id="txtidBusqueda" runat="server" maxlength="10" readonly="True"></asp:textbox></td>
					</tr>
					<tr>
						<TD width="22" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">Titulo</td>
						<td><asp:textbox id="txttitulo" runat="server" maxlength="100" Width="481px"></asp:textbox></td>
					</tr>
					<tr>
						<TD width="22" bgColor="#f4f4f4" height="11"></TD>
						<td height="11" bgColor="#f4f4f4">Tipo Vinculo</td>
						<td height="11"><span id="capVinculo"></span>
							<asp:dropdownlist id="cboVinculo" runat="server" width="200px"></asp:dropdownlist></td>
					</tr>
					<tr>
						<TD width="22" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">Fecha Desde</td>
						<td><asp:textbox id="txtfechaDesde" runat="server" maxlength="23"></asp:textbox></td>
					</tr>
					<tr>
						<TD width="22" bgColor="#f4f4f4"></TD>
						<td bgColor="#f4f4f4">Fecha Hasta</td>
						<td><asp:textbox id="txtfechaHasta" runat="server" maxlength="23"></asp:textbox></td>
					</tr>
					<tr>
						<TD vAlign="top" width="22" bgColor="#f4f4f4"></TD>
						<td valign="top" bgColor="#f4f4f4">Otros Requisitos</td>
						<td valign="top"><asp:textbox id="txtotroRequisitos" runat="server" maxlength="1000" Width="100%" TextMode="MultiLine"
								Height="64px"></asp:textbox></td>
					</tr>
					<TR>
						<TD width="22" bgColor="#f4f4f4"></TD>
						<TD bgColor="#f4f4f4">&nbsp;</TD>
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
									<asp:BoundColumn DataField="DESCRIPCION" HeaderText="Busqueda para las siguiente/s carreras :"></asp:BoundColumn>
								</Columns>
								<PagerStyle CssClass="GridHeader"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</table>
			</div>
			<div class="divAcciones" id="divAcciones"><asp:button id="btnSave" runat="server" text="Postularme a esta busqueda"></asp:button>&nbsp;<asp:button id="btnCancel" runat="server" text="Volver" causesvalidation="False"></asp:button></div>
			<div id="piePag">
				<uc1:ucBolsaTrabajoPie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucBolsaTrabajoPie>
			</div>
			<!-- ### CONTENIDO AQUI ### --></form>
	</body>
</HTML>
