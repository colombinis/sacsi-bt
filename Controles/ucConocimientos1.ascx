<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucConocimientos1.ascx.vb" Inherits="bolsatrabajo.ucConocimientos1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>



<TABLE id=Table1 cellSpacing=1 cellPadding=1 width="100%" border=0>
  <TR>
    <TD>Seleccione un conocimiento :<asp:dropdownlist id=cboConocimiento runat="server"></asp:dropdownlist>&nbsp;y 
      un Valor :<asp:dropdownlist id=cboValor runat="server">
				<asp:ListItem Value="1">Bajo</asp:ListItem>
				<asp:ListItem Value="2">Medio</asp:ListItem>
				<asp:ListItem Value="3">Alto</asp:ListItem>
			</asp:dropdownlist></TD></TR>
  <TR>
    <TD><asp:button id=cmdAgregarConocimiento runat="server" Text="Agregar Conocimiento seleccionado" ToolTip="Muestra el listado de los postulantes incluidos en la busqueda seleccionada" CausesValidation="False"></asp:button></TD></TR>
  <TR>
    <TD colSpan=2><asp:datagrid id=oGrid runat="server" AutoGenerateColumns="False" Width="100%">
				<AlternatingItemStyle CssClass="gridAlternativeItem"></AlternatingItemStyle>
				<HeaderStyle CssClass="GridHeader"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="idConocimiento" HeaderText="idConocimiento"></asp:BoundColumn>
					<asp:BoundColumn DataField="dscConocimiento" HeaderText="Conocimiento"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="idValor" HeaderText="idValor"></asp:BoundColumn>
					<asp:BoundColumn DataField="dscValor" HeaderText="Valor"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:ImageButton id="imgDelete" CommandName="Delete" Runat="server" ImageUrl="../img/delete.gif" 
 AlternateText="Borrar" BorderStyle="None"></asp:ImageButton>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle CssClass="GridHeader"></PagerStyle>
			</asp:datagrid></TD></TR></TABLE>
