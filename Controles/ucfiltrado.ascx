<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucfiltrado.ascx.vb" Inherits="bolsatrabajo.ucfiltrado" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<div id="filtroPostulante" class="divFiltro" style="BORDER-RIGHT:#000 2px solid; BORDER-TOP:#000 2px solid; BORDER-LEFT:#000 2px solid; WIDTH:90%; BORDER-BOTTOM:#000 2px solid">
	<div id="contieneTabs">
		<ul>
			<li>
				<a href="#" onclick="MostrarTab(0);">Listados directos</a>
			<li>
				<a href="#" onclick="MostrarTab(1);">Listados con filtros</a></li>
		</ul>
	</div>
	<div id="hoja_0">
		<div id="divCV" class="divTitle">Listado de alumnos</div>
		<TABLE id="Table0" cellSpacing="1" cellPadding="1" width="100%" border="0" class="divFiltro">
			<TR>
				<TD>
					Listar los
					<asp:DropDownList id="cboOpciones" runat="server" AutoPostBack="True">
						<asp:ListItem Value="-1">---</asp:ListItem>
						<asp:ListItem Value="1">Alumnos ingresados en el sistema con la cantidad de postulaciones</asp:ListItem>
					</asp:DropDownList>
					<asp:Button id="cmdListarPostulantes" runat="server" Text="Listar postulantes"></asp:Button>
				</TD>
			</TR>
		</TABLE>
	</div>
	<div id="hoja_1" style="DISPLAY:none">
		<div id="divEspecialidad" class="divTitle">Inscriptos en la/s especialidad/es</div>
		<TABLE id="Table0" cellSpacing="1" cellPadding="1" width="100%" border="0" class="divFiltro">
			<TR>
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
							<asp:BoundColumn DataField="DESCRIPCION" HeaderText=""></asp:BoundColumn>
						</Columns>
						<PagerStyle CssClass="GridHeader"></PagerStyle>
					</asp:datagrid></TD>
			</TR>
		</TABLE>
		<div id="divConocimiento" class="divTitle">Conocimientos</div>
		<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0" class="divFiltro">
			<TR>
				<TD>Campo</TD>
				<TD>Operador</TD>
				<TD>Valor</TD>
				<TD>Condicion</TD>
				<TD>&nbsp;</TD>
			</TR>
			<TR>
				<TD><asp:DropDownList id="cboCampo" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
				<TD><asp:DropDownList id="cboOperador" runat="server"></asp:DropDownList></TD>
				<TD>
					<asp:TextBox id="txtValor" runat="server"></asp:TextBox>
					<asp:DropDownList id="cboValor" runat="server"></asp:DropDownList></TD>
				<td><asp:DropDownList id="cboNexo" runat="server"></asp:DropDownList></td>
				<TD><asp:Button id="cmdAgregarrecondicion" Text="Agregar al filtro" runat="server"></asp:Button></TD>
			</TR>
		</TABLE>
		<asp:TextBox id="txtFiltroAcumulado" runat="server" TextMode="MultiLine" Width="100%" Enabled="False"
			CssClass="TEXTAREAANCHO"></asp:TextBox>
		<asp:TextBox id="txtOcultoAcumulado" runat="server" TextMode="MultiLine" Width="100%" Visible="False"></asp:TextBox>
		<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0" class="divFiltro">
			<TR>
				<TD><asp:Button id="cmdBuscarPostulantes" Text="Buscar postulantes" runat="server"></asp:Button></TD>
			</TR>
		</TABLE>
	</div>
</div>
<script language="javascript">
function MostrarTab(indexEl){
	var cantidadHojas=2;
var oD;
	var i;
	for(i=0;i<cantidadHojas;i++)
	{	oD = document.getElementById("hoja_"+i);
		if(indexEl==i)
		{oD.style.display="";}
		else
		{oD.style.display="none";}
	}
	return false;
}
</script>
