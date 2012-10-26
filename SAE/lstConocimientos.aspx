<%@ Page Language="vb" AutoEventWireup="false" Codebehind="lstConocimientos.aspx.vb" Inherits="bolsatrabajo.lstConocimientos"%>
<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
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
			<!-- ### CONTENIDO AQUI ### -->
			<input type="hidden" id="txtIDOculto" runat="server" NAME="txtIDOculto">
			<div class="divTitle" runat="server" id="cantReg">Lista de XXX(--)</div>
			<div class="divFiltro">Buscar conocimiento con la&nbsp;descripcion&nbsp;
				<asp:TextBox id="txtFILTRO" runat="server"></asp:TextBox>
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
						<asp:BoundColumn Visible="False" DataField="idConocimiento" HeaderText="idConocimiento"></asp:BoundColumn>
						<asp:BoundColumn DataField="dscConocimiento" HeaderText="Conocimiento"></asp:BoundColumn>
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
				</asp:datagrid>
			</div>
			<div id="divAcciones" class="divAcciones">
				<asp:Button id="btnNew" runat="server" Text="Agregar Nuevo conocimiento" CausesValidation="False"></asp:Button>
			</div>
			<div id="piePag">
				<uc1:ucBolsaTrabajoPie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucBolsaTrabajoPie>
			</div>
			<!-- ### CONTENIDO AQUI ###-->
		</form>
	</body>
</HTML>
