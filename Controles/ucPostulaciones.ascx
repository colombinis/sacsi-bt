<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucPostulaciones.ascx.vb" Inherits="bolsatrabajo.ucPostulaciones" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<h3>Historial de postulaciones</h3>
<asp:datagrid id="oGrid" Width="100%" AutoGenerateColumns="False" GridLines="None" runat="server">
	<AlternatingItemStyle CssClass="gridAlternativeItem"></AlternatingItemStyle>
	<HeaderStyle CssClass="GridHeader"></HeaderStyle>
	<Columns>
		<asp:BoundColumn Visible="False" DataField="idPostulante" HeaderText="idPostulante"></asp:BoundColumn>
		<asp:BoundColumn DataField="idBusqueda" HeaderText="Nro Busqueda"></asp:BoundColumn>
		<asp:BoundColumn DataField="titulo" HeaderText="&nbsp;Titulo de la busqueda&nbsp;&nbsp;&nbsp;"></asp:BoundColumn>
		<asp:BoundColumn DataField="fechaPostulacion" HeaderText="&nbsp;Fecha de postulacion&nbsp;&nbsp;&nbsp;"></asp:BoundColumn>
		<asp:BoundColumn Visible="False" DataField="fechaExclusion" HeaderText="fechaExclusion"></asp:BoundColumn>
		<asp:BoundColumn Visible="False" DataField="motivoExclusion" HeaderText="motivoExclusion"></asp:BoundColumn>
		<asp:BoundColumn Visible="False" DataField="fechaVinculacion" HeaderText="fechaVinculacion"></asp:BoundColumn>
		<asp:BoundColumn Visible="False" DataField="tipoVinculo" HeaderText="tipoVinculo"></asp:BoundColumn>
		<asp:BoundColumn Visible="False" DataField="fechaDesde" HeaderText="fechaDesde"></asp:BoundColumn>
		<asp:BoundColumn Visible="False" DataField="fechaHasta" HeaderText="fechaHasta"></asp:BoundColumn>
		<asp:BoundColumn Visible="False" DataField="otroRequisitos" HeaderText="otroRequisitos"></asp:BoundColumn>
		<asp:BoundColumn Visible="False" DataField="strEspecialidad" HeaderText="strEspecialidad"></asp:BoundColumn>
		<asp:BoundColumn Visible="False" DataField="publica" HeaderText="publica"></asp:BoundColumn>
	</Columns>
	<PagerStyle CssClass="GridHeader"></PagerStyle>
</asp:datagrid>
<br/>