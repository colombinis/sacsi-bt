<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmpresaLista.aspx.vb" Inherits="bolsatrabajo.EmpresaLista"%>
<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>EmpresaLista</title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
			<script language="javascript">
		var ofila ={obj:new Object(),val:-1};
		
		function init()
		{	//inicializo la pantalla
		}
		
		function confirmDelete() {
			var result = confirm("Desea borrar el registro ?");
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
			document.getElementById("txtIDempresa").value=val;
		}

			</script>
	</HEAD>
	<body onload="init();">
		<form id="Form1" method="post" runat="server">
			<div id="divMenu">
				<uc1:usMenuSAE id="UsMenuSAE1" runat="server"></uc1:usMenuSAE></div>
			<!-- ### CONTENIDO AQUI ### -->
			<input type="hidden" id="txtIDempresa" runat="server">
			<div class="divTitle" runat="server" id="cantReg">Lista de Empresas(--)</div>
			<div class="divFiltro">Buscar Empresa con el&nbsp;CUIT&nbsp;
				<asp:TextBox id="txtCuit" runat="server"></asp:TextBox>&nbsp;y Razon social
				<asp:TextBox id="txtRaxonSocial" runat="server" Width="256px"></asp:TextBox>
				<asp:Button id="cmdBuscar" runat="server" Text="Buscar"></asp:Button>
			</div>
			<div id="datos" style="OVERFLOW:auto;HEIGHT:400px">
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
						<asp:BoundColumn Visible="False" DataField="idempresa" HeaderText="idempresa"></asp:BoundColumn>
						<asp:BoundColumn DataField="CUIT" HeaderText="CUIT"></asp:BoundColumn>
						<asp:BoundColumn DataField="razonsocial" HeaderText="Razon social"></asp:BoundColumn>
						<asp:TemplateColumn>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<asp:ImageButton id="imgView" BorderStyle="None" AlternateText="Ver" ImageUrl="../img/view.gif" Runat="server"
									CommandName="View"></asp:ImageButton>
								<asp:ImageButton id="imgEdit" BorderStyle="None" AlternateText="Editar" ImageUrl="../img/edit.gif"
									Runat="server" CommandName="Edit"></asp:ImageButton>
								<asp:ImageButton id="imgDelete" BorderStyle="None" AlternateText="Borrar" ImageUrl="../img/delete.gif"
									Runat="server" CommandName="Delete"></asp:ImageButton>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle CssClass="GridHeader"></PagerStyle>
				</asp:datagrid>
			</div>
			<DIV class="divAcciones">
				<asp:Button id="btnNew" runat="server" Text="Agregar Nueva Empresa" CausesValidation="False"></asp:Button>
				<asp:Button id="cmdDocumentacion" runat="server" Text="Documentacion" CausesValidation="False"></asp:Button>
				<asp:Button id="cmdBusquedas" runat="server" Text="Busquedas" CausesValidation="False"></asp:Button>
			</DIV>
			<div id="piePag">
				<uc1:ucBolsaTrabajoPie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucBolsaTrabajoPie>
			</div>
			<!-- ### CONTENIDO AQUI ### -->
		</form>
	</body>
</HTML>
