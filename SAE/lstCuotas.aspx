<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<%@ Register TagPrefix="uc1" TagName="usMenuSAE" Src="../Controles/usMenuSAE.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="lstCuotas.aspx.vb" Inherits="bolsatrabajo.lstCuotas"%>
<HTML>
	<HEAD>
		<title>Lista de cuotas</title>
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
			<div class="divTitle" runat="server" id="cantReg">Lista de cuotas(--)</div>
			<div class="divFiltro">Buscar&nbsp;cuotas de la empresa&nbsp;
				<asp:dropdownlist id="cboBusqueda" runat="server" AutoPostBack="True"></asp:dropdownlist>
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
						<asp:BoundColumn Visible="False" DataField="idCuota" HeaderText="idCuota"></asp:BoundColumn>
						<asp:BoundColumn DataField="fechaVto1" HeaderText="Fecha Vto." DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
						<asp:BoundColumn DataField="dscConcepto" HeaderText="Concepto"></asp:BoundColumn>
						<asp:BoundColumn DataField="valor" HeaderText="valor"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="idEstadoCuota" HeaderText="idEstadoCuota"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="idEmpresa" HeaderText="idEmpresa"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="idBusqueda" HeaderText="idBusqueda"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="idPostulante" HeaderText="idPostulante"></asp:BoundColumn>
						<asp:BoundColumn DataField="dscEstadocuota" HeaderText="Estado"></asp:BoundColumn>
						<asp:TemplateColumn>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<asp:ImageButton id="imgView" BorderStyle="None" AlternateText="Ver" ImageUrl="../img/view.gif" Runat="server"
									CommandName="View"></asp:ImageButton>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle CssClass="GridHeader"></PagerStyle>
				</asp:datagrid>
			</div>
			<div id="divAcciones" class="divAcciones">
				<asp:Button id="btnNew" runat="server" Text="Agregar Nueva Cuota" CausesValidation="False"></asp:Button>
				<asp:Button id="cmdNotaPagoGenerica" runat="server" CausesValidation="False" Text="Nota de Pago Generica"></asp:Button>
			</div>
			<div id="piePag">
				<uc1:ucBolsaTrabajoPie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucBolsaTrabajoPie>
			</div>
			<!-- ### CONTENIDO AQUI ###-->
		</form>
	</body>
</HTML>
