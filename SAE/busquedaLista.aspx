<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="busquedaLista.aspx.vb" Inherits="bolsatrabajo.BusquedaLista"%>
<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
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
			<div id="divMenu"><uc1:usMenuSAE id="UsMenuSAE1" runat="server"></uc1:usMenuSAE></div>
			<!-- ### CONTENIDO AQUI ### --><input id="txtIDOculto" type="hidden" name="txtIDOculto" runat="server">
			<div class="divTitle" runat="server" id="cantReg">Lista de XXX(--)</div>
			<div class="divFiltro">Busqueda con el&nbsp;Nro&nbsp;
				<asp:TextBox id="txtFILTRO" runat="server" AutoPostBack="True"></asp:TextBox>&nbsp;de 
				la empresa:
				<asp:DropDownList id="cboEmpresas" runat="server" AutoPostBack="True"></asp:DropDownList>
			</div>
			<DIV id="datos" style="OVERFLOW:auto;HEIGHT:400px">
				<asp:label id="lblError" runat="server" visible="False" width="100%" cssclass="errorBox">Mensaje de error personal</asp:label>
				<asp:datagrid id="oGrid" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="None">
					<AlternatingItemStyle CssClass="gridAlternativeItem"></AlternatingItemStyle>
					<HeaderStyle CssClass="GridHeader"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn>
							<HeaderStyle Width="50px"></HeaderStyle>
							<ItemTemplate>
								<asp:RadioButton id="optRows" runat="server"></asp:RadioButton>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn Visible="False" DataField="idEmpresa" HeaderText="idEmpresa"></asp:BoundColumn>
						<asp:BoundColumn DataField="idBusqueda" HeaderText="Nro"></asp:BoundColumn>
						<asp:BoundColumn DataField="titulo" HeaderText="titulo"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="tipoVinculo" HeaderText="tipoVinculo"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="fechaDesde" HeaderText="fechaDesde"></asp:BoundColumn>
						<asp:BoundColumn DataField="fechaHasta" HeaderText="fechaHasta"></asp:BoundColumn>
						<asp:TemplateColumn>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<asp:ImageButton id="imgView" CommandName="View" Runat="server" ImageUrl="../img/view.gif" AlternateText="Ver"
									BorderStyle="None"></asp:ImageButton>
								<asp:ImageButton id="imgEdit" CommandName="Edit" Runat="server" ImageUrl="../img/edit.gif" AlternateText="Editar"
									BorderStyle="None"></asp:ImageButton>
								<asp:ImageButton id="imgDelete" CommandName="Delete" Runat="server" ImageUrl="../img/delete.gif"
									AlternateText="Borrar" BorderStyle="None"></asp:ImageButton>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle CssClass="GridHeader"></PagerStyle>
				</asp:datagrid></DIV>
			<div id="divAcciones" class="divAcciones">
				<asp:Button id="btnNew" runat="server" Text="Agregar Nueva Busqueda" CausesValidation="False"></asp:Button>
				<asp:Button id="cmdVolver" runat="server" Text="Volver" CausesValidation="False"></asp:Button>
				<asp:Button id="cmdListarPostulantes" runat="server" Text="Ver Postulantes" CausesValidation="False"
					ToolTip="Muestra el listado de los postulantes incluidos en la busqueda seleccionada"></asp:Button>
			</div>
			<div id="piePag">
				<uc1:ucBolsaTrabajoPie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucBolsaTrabajoPie>
			</div>
			<!-- ### CONTENIDO AQUI ###--></form>
	</body>
</HTML>
