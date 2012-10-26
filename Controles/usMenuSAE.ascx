<%@ Control Language="vb" AutoEventWireup="false" Codebehind="usMenuSAE.ascx.vb" Inherits="bolsatrabajo.usMenuSAE" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Import Namespace="bolsaTrabajo.Logica.cUtil" %>

<!--<IFRAME SRC="<%= GetHttpAppRootPath() %>estad.aspx" height="0" width="0" ></IFRAME>
-->
<table width="100%" border="0"  >
  <tr>
    <td  >
			<img src="<%= GetHttpAppRootPath() %>img/logoutn.gif" border="0">
		</td>
	</tr>	
	<tr>
    <td align="left" >
				<div id="MENUPRINCIPAL" >  
						<ul>
								<li><img width="12" height="35" border="0" alt="" src="img/topnav_left.gif"/></li>
								<li><a href="EmpresaLista.aspx">Empresa</a></li>
								<li><a href="lstDatosP.aspx">Postulante</a></li>
								<li><a href="lstCuotas.aspx">Cuotas</a></li>
								<li><a href="lstConocimientos.aspx">Conocimientos</a></li>
								<li><a href="filtroPostulantes.aspx">Reportes</a></li>
								<li><a href="../logout.aspx">Salir</a></li>
								<li><img width="12" height="35" border="0" alt="" src="img/topnav_right.gif"/></li>
						</ul>
				</div>    
    </td>
  </tr>
</table>
