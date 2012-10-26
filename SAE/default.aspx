<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="bolsatrabajo._default1"%>
<%@ Register TagPrefix="uc1" TagName="ucIngreso_BannerTop" Src="../Controles/ucIngreso_BannerTop.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucIngreso_Foot" Src="../Controles/ucIngreso_Foot.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucBolsaTrabajoPie" Src="../Controles/ucBolsaTrabajoPie.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Bolsa de trabajo</title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Verif()
		{ 
			var oFrm= document.getElementById("frmPOSTULANTE");
			var oU= document.getElementById("usuario");
			var oP= document.getElementById("pass");
			
			if (oU.value!="" && oP.value!="")
			{
				oFrm.submit(); 
			}
			else
			{
				alert ("Los datos de Usuario y contraseña son obligatorios.");
			}
		}
		
		</script>
</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
		
			<TABLE WIDTH="760" BORDER="0" CELLSPACING="0" CELLPADDING="0" align="center">
				<TR>
					<TD><uc1:ucIngreso_BannerTop id="UcIngreso_BannerTop1" runat="server"></uc1:ucIngreso_BannerTop></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD align="center">
						<!--c-->
						<div id="login">
							<TABLE id="tblLogin" cellSpacing="1" cellPadding="1" border="0">
								<TR>
								<TD><img src="img/folder1_locked.jpg" border="0" alt="Ingreso al sistema" /></TD>
												<TD colSpan="2"><INPUT id="clave" type="hidden" value="SAE" name="clave">
													<h3>Bolsa de trabajo (area administrativa)</h3>
												</TD>
											</TR>
											<TR>
								<TD></TD>
												<TD>Usuario</TD>
												<TD>
													<input type="text" name="usuario" id="usuario"></TD>
											</TR>
											<TR>
								<TD></TD>
												<TD>Contraseña</TD>
												<TD>
													<input type="password" name="pass" id="pass"></TD>
											</TR>
											<TR>
								<TD></TD>
												<TD></TD>
												<TD align="right">
													<asp:Button id="cmdAceptar" runat="server" Text="Aceptar"></asp:Button>
												</TD>
											</TR>
							</TABLE>
						<!--c f-->
						</div>
					</TD>
				</TR>
				<TR>
					<TD>
						<uc1:ucBolsaTrabajoPie id="UcBolsaTrabajoPie1" runat="server"></uc1:ucBolsaTrabajoPie></TD>
				</TR>
			</TABLE>
			
		</form>
	</body>
</HTML>
