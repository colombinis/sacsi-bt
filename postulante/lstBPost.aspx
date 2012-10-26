<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="lstBPost.aspx.vb" Inherits="bolsatrabajo.lstBPost"%>
<%@ Register TagPrefix="uc1" TagName="ucMenuPostulante" Src="../Controles/ucMenuPostulante.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Lista</title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
			<script language="javascript">
		var ofila ={obj:new Object(),val:-1};

		function init()
		{	//inicializo la pantalla
		}

		function confirmDelete() {
			var result = confirm('Desea borrar el registro ?');
			return result;
		}

		function Selrow(ochkrow, valorID)
		{	var oTR;	
			if (ofila.obj.checked)
			{	oTR = ofila.obj.parentElement.parentElement;
				oTR.style.backgroundColor='';
				ofila.obj.checked=false;
			}
			ofila.obj=ochkrow;
			colocarValor(valorID);
			ofila.val=valorID;
			oTR = ofila.obj.parentElement.parentElement;
			oTR.style.backgroundColor='#FFCCAA';
		}

		function colocarValor(val)
		{
			document.getElementById("txtIDOculto").value=val;
		}

			</script>
	</HEAD>
	<body onload="init();">
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:ucmenupostulante id="UcMenuPostulante1" runat="server"></uc1:ucmenupostulante></div>
			<!-- ### CONTENIDO AQUI ### --><input id="txtIDOculto" type="hidden" name="txtIDOculto" runat="server">
			<div class="divTitle" id="cantReg" runat="server">Lista de XXX(--)</div>
			<div class="divFiltro">Busqueda con el&nbsp;Nro&nbsp;
				<asp:textbox id="txtFILTRO" runat="server"></asp:textbox><asp:button id="cmdBuscar" runat="server" Text="Buscar"></asp:button>
				&nbsp;y ordenado por
				<asp:dropdownlist id="cboOrdenColumna" runat="server" AutoPostBack="True">
					<asp:ListItem Value="Titulo">Titulo</asp:ListItem>
					<asp:ListItem Value="Especialidad">Especialidad</asp:ListItem>
					<asp:ListItem Value="Estado">Estado</asp:ListItem>
					<asp:ListItem Value="Tipo">Tipo</asp:ListItem>
				</asp:dropdownlist></div>
			<div id="datos"><asp:datagrid id="oGrid" runat="server" UseAccessibleHeader="True" Width="100%" AutoGenerateColumns="False"
					GridLines="None" EnableViewState="False">
					<AlternatingItemStyle CssClass="gridAlternativeItem"></AlternatingItemStyle>
					<HeaderStyle CssClass="GridHeader"></HeaderStyle>
					<Columns>
						<asp:BoundColumn Visible="False" DataField="idEmpresa" HeaderText="idEmpresa"></asp:BoundColumn>
						<asp:BoundColumn DataField="idBusqueda" HeaderText="Nro"></asp:BoundColumn>
						<asp:BoundColumn DataField="titulo" HeaderText="Titulo"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="tipoVinculo" HeaderText="tipoVinculo"></asp:BoundColumn>
						<asp:BoundColumn DataField="dscVinculo" HeaderText="Tipo "></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="Especialidad">
							<ItemTemplate>
								<%# getDescripcionCarrera(DataBinder.Eval(Container.DataItem,"strEspecialidad"))%>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Estado"></asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Detalle">
							<ItemTemplate>
								<%# getURLBusqueda(DataBinder.Eval(Container.DataItem,"idEmpresa"),DataBinder.Eval(Container.DataItem,"idBusqueda"))%>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn Visible="False" DataField="motivoExclusion" HeaderText="motivoExclusion"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="fechaHasta" HeaderText="Fecha limite" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="fechaPostulacion" HeaderText="fechaPostulacion" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
					</Columns>
					<PagerStyle CssClass="GridHeader"></PagerStyle>
				</asp:datagrid></div>
			<div class="divAcciones" id="divAcciones">&nbsp;</div>
			<div id="piePag"><uc1:ucbolsatrabajopie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucbolsatrabajopie></div>
			<!-- ### CONTENIDO AQUI ###--></form>
	</body>
</HTML>
