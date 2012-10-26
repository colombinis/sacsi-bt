<%@ Page Language="vb" AutoEventWireup="false" Codebehind="lstDatosP.aspx.vb" Inherits="bolsatrabajo.lstDatosP"%>
<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Lista</title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY onload="init();">
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
		<form id="Form1" method="post" runat="server">
			<div id="divMenu"><uc1:usmenusae id="UsMenuSAE1" runat="server"></uc1:usmenusae></div>
			<!-- ### CONTENIDO AQUI ### --><input id="txtIDOculto" type="hidden" name="txtIDOculto" runat="server">
			<div class="divTitle" id="cantReg" runat="server">Lista de Postulante(--)</div>
			<div><asp:label id="lblError" runat="server" cssclass="errorBox" visible="False" width="100%">Mensaje de error personal</asp:label></div>
			<div class="divFiltro">Buscar Postulante con el&nbsp;legajo&nbsp;<asp:textbox id="txtFILTRO" runat="server" AutoPostBack="True"></asp:textbox>
				o incluidos en la busqueda:&nbsp;<asp:dropdownlist id="cboBusqueda" runat="server" AutoPostBack="True"></asp:dropdownlist>
			</div>
			<div id="datos" style="OVERFLOW:auto;HEIGHT:400px"><asp:datagrid id="oGrid" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="None"
					PageSize="30">
					<HeaderStyle CssClass="GridHeader"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn>
							<HeaderStyle Width="50px"></HeaderStyle>
							<ItemTemplate>
								<asp:RadioButton id="optRows" runat="server"></asp:RadioButton>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn Visible="False" DataField="idPostulante" HeaderText="idPostulante"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="fechaAltaSistema" HeaderText="fechaAltaSistema"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="usuario" HeaderText="usuario"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="email" HeaderText="email"></asp:BoundColumn>
						<asp:BoundColumn DataField="nroLegajo" HeaderText="nroLegajo"></asp:BoundColumn>
						<asp:BoundColumn DataField="apellido" HeaderText="apellido"></asp:BoundColumn>
						<asp:BoundColumn DataField="nombres" HeaderText="nombres"></asp:BoundColumn>
						<asp:BoundColumn DataField="dscEspecialidad" HeaderText="Especialidad"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="fechaUltimaActualizacion" HeaderText="fechaUltimaActualizacion"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="fechaUltimaRevision" HeaderText="UltimaRevision"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="archivoCV" HeaderText="archivoCV"></asp:BoundColumn>
						<asp:BoundColumn DataField="fechaEnvioCV" HeaderText="Fecha Envio CV"></asp:BoundColumn>
						<asp:TemplateColumn>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<asp:ImageButton id="imgView" ToolTip="Visualiza los datos del Postulante" CommandName="View" Runat="server"
									ImageUrl="../img/view.gif" AlternateText="Ver" BorderStyle="None"></asp:ImageButton>
								<asp:ImageButton id="imgEdit" ToolTip="Postular manualmente" CommandName="Edit" Runat="server" ImageUrl="../img/edit.gif"
									AlternateText="Editar" BorderStyle="None"></asp:ImageButton>
								<asp:ImageButton id="imgInfoAcad" Width="16px" ToolTip="Muestra informacion academica del postulante"
									CommandName="infoacad" Runat="server" ImageUrl="../img/infoacad.gif" AlternateText="Editar" BorderStyle="None"
									Height="18px"></asp:ImageButton>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle CssClass="GridHeader"></PagerStyle>
				</asp:datagrid></div>
			<div class="divAcciones" id="divAcciones">
			</div>
			<DIV class="divAcciones"><asp:button id="btnNew" runat="server" Text="Agregar Nuevo Postulante" CausesValidation="False"></asp:button><asp:button id="cmdIniciarVinculo" runat="server" Text="Vinculo con empresa" CausesValidation="False"></asp:button><asp:button id="cmdFiltradoPostulantes" runat="server" Text="Buscar Postulantes con filtro"
					CausesValidation="False"></asp:button><asp:button id="cmdRealizarProceso" runat="server" Text="Proceso de Envio" CausesValidation="False"
					ToolTip="Comenzar el proceso de envio de CVs de los postulantes a la Empresa."></asp:button>
				<hr>
				Exclusion :
				<asp:dropdownlist id="cboMotivo" runat="server">
					<asp:ListItem Value="-1">Seleccione un motivo para excluir al postulante de la busqueda.</asp:ListItem>
					<asp:ListItem Value="1">No cumplir con los requerimientos solicitados</asp:ListItem>
					<asp:ListItem Value="2">No cumplir con las condiciones académica</asp:ListItem>
				</asp:dropdownlist><asp:button id="cmdExcluir" runat="server" Text="Excluir"></asp:button></DIV>
			<div id="piePag"><uc1:ucbolsatrabajopie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucbolsatrabajopie></div>
			<!-- ### CONTENIDO AQUI ###--></form>
		<DIV></DIV>
	</BODY>
</HTML>
