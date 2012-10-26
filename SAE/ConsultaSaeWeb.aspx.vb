Imports System.Xml
Imports System.Text
Imports bolsatrabajo.Logica.cUtil

Public Class ConsultaSaeWeb
  Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

  'El Diseñador de Web Forms requiere esta llamada.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents cmdVolver As System.Web.UI.WebControls.Button
  Protected WithEvents lblPlan As System.Web.UI.WebControls.Label
  Protected WithEvents lblDatosPersonales As System.Web.UI.WebControls.Label
  Protected WithEvents lblMateriasRegulares As System.Web.UI.WebControls.Label
  Protected WithEvents lblExamenes As System.Web.UI.WebControls.Label
  Protected WithEvents lblPromedio As System.Web.UI.WebControls.Label
  Protected WithEvents lblCursadoActual As System.Web.UI.WebControls.Label

  'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
  'No se debe eliminar o mover.
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
    'No la modifique con el editor de código.
    InitializeComponent()
  End Sub

#End Region

  Dim sEspecialidad As String

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Introducir aquí el código de usuario para inicializar la página
    If Not Page.IsPostBack Then
      If Not Request.QueryString("legajo") Is Nothing Then
        ViewState("legajo") = Request.QueryString("legajo").ToString
      Else
        'muestro un mensaje de error
        Me.ColocarMensaje("Error al recuperar las materias del postulante.")
        Exit Sub
      End If
      Me.InitScreen()
    End If
  End Sub

  Private Sub InitScreen()
    Try
      'coloco los datos del postulante
      LlenarCarrera()
    Catch ex As Exception
      Me.ColocarMensaje("No existen datos para mostrar de 'Carrera': <br/>" & ex.Message)
    End Try

    Try
      'Datos personales
      Datos_personales()
    Catch ex As Exception
      Me.ColocarMensaje("No existen datos para mostrar de 'Datos personales': <br/>" & ex.Message)
    End Try

    Try
      'Materias regulares
      Materias_regulares()
    Catch ex As Exception
      Me.ColocarMensaje("No existen datos para mostrar de 'Materias regulares': <br/>" & ex.Message)
    End Try

    Try
      'Examenes
      Examenes()
    Catch ex As Exception
      Me.ColocarMensaje("No existen datos para mostrar de 'Examenes': <br/>" & ex.Message)
    End Try

    Try
      'Promedio
      Promedio()
    Catch ex As Exception
      Me.ColocarMensaje("No existen datos para mostrar de  'Promedio': <br/>" & ex.Message)
    End Try

    Try
      'Cursado
      Cursado()
    Catch ex As Exception
      Me.ColocarMensaje("No existen datos para mostrar de 'Cursado': <br/>" & ex.Message)
    End Try
    
  End Sub

  Private Sub ColocarMensaje(ByVal texto As String)
    'coloco el mensaje de error
    lblError.Text = texto
    lblError.Visible = True
  End Sub

  Private Sub LlenarCarrera()
    'objetivo
    'in
    'out
    Dim sOut As New StringBuilder

    Dim oCons As Logica.cConsultasSysacad
    Dim oDoc As New XmlDocument
    'coloco el plan y Materia
    oDoc.LoadXml(oCons.XML_obtenerCarreraPlan(CStr(ViewState("legajo"))))
    Dim sLegajo As String = getNodo(oDoc, "//LEGAJO")
    Dim sPlan As String = getNodo(oDoc, "//PLAN")
    Dim sDscEspe As String = getNodo(oDoc, "//ESPECIALIDAD")
    'coloco la especialidad en una varible global porque lo necesito para otras consultas
    sEspecialidad = getNodo(oDoc, "//CODESPECIALIDAD")

    sOut.Append(sLegajo & " - Especialidad : " & sDscEspe & " ( " & sPlan & " )")

    Me.lblPlan.Text = sOut.ToString

  End Sub

  Private Sub Datos_personales()
    'objetivo: Datos personales
    'in
    'out
    Dim sOut As New StringBuilder

    Dim oCons As Logica.cConsultasSysacad
    Dim oDoc As New XmlDocument
    oDoc.LoadXml(oCons.XML_obtenerDatosPersonales(CStr(ViewState("legajo"))))

    Dim NOMBRE As String = getNodo(oDoc, "//NOMBRE")
    Dim TDOCUMENTO As String = getNodo(oDoc, "//TDOCUMENTO")
    Dim NDOCUMENTO As String = getNodo(oDoc, "//NDOCUMENTO")
    Dim DCALLE As String = getNodo(oDoc, "//DCALLE")
    Dim DNUMERO As String = getNodo(oDoc, "//DNUMERO")
    Dim DPISO As String = getNodo(oDoc, "//DPISO")
    Dim DDEPARTAMENTO As String = getNodo(oDoc, "//DDEPARTAMENTO")
    Dim CODIGO_POSTAL As String = getNodo(oDoc, "//CODIGO_POSTAL")
    Dim PNOMBRE As String = getNodo(oDoc, "//PNOMBRE")
    Dim CIUDAD As String = getNodo(oDoc, "//CIUDAD")
    Dim PCODIGO As String = getNodo(oDoc, "//PCODIGO")
    Dim TELEFONO As String = getNodo(oDoc, "//TELEFONO")
    Dim MAIL As String = getNodo(oDoc, "//MAIL")
    Dim TRABAJA_SN As String = getNodo(oDoc, "//TRABAJA_SN")
    Dim ANIO_INGRESO As String = getNodo(oDoc, "//ANIO_INGRESO")
    Dim LEGAJO As String = getNodo(oDoc, "//LEGAJO")
    Dim ESPECIALIDAD As String = getNodo(oDoc, "//ESPECIALIDAD")
    Dim PLAN As String = getNodo(oDoc, "//PLAN")
    Dim FECHANACIM As String = getNodo(oDoc, "//FECHANACIM")

    sOut.Append("<HR>")
    sOut.Append("DATOS PERSONALES<br />")
    sOut.Append("NOMBRE : " & NOMBRE & "<br />")
    sOut.Append("DOCUMENTO " & TDOCUMENTO & "-" & NDOCUMENTO & "<br />")
    sOut.Append("FECHA NACIMIENTO " & FECHANACIM & "<br />")
    sOut.Append("CALLE : " & DCALLE & "<br />")
    sOut.Append("NUMERO : " & DNUMERO & "<br />")
    sOut.Append("PISO " & DPISO & "<br />")
    sOut.Append("DTO. " & DDEPARTAMENTO & "<br />")
    sOut.Append("CIUDAD ( " & CODIGO_POSTAL & " ) " & CIUDAD & " - " & PNOMBRE & "<br />")
    sOut.Append("TELEFONO: " & TELEFONO & "<br />")
    sOut.Append("MAIL: " & MAIL & "<br />")
    'sOut.Append("TRABAJA_SN " & TRABAJA_SN & "<br />")
    sOut.Append("AÑO INGRESO " & ANIO_INGRESO & "<br />")
    'sOut.Append("LEGAJO " & LEGAJO & "<br />")
    'sOut.Append("ESPECIALIDAD " & ESPECIALIDAD & "<br />")
    'sOut.Append("PLAN " & PLAN & "<br />")

    Me.lblDatosPersonales.Text = sOut.ToString
  End Sub

  Private Sub Materias_regulares()
    'objetivo: Materias regulares
    'in
    'out
    Dim sOut As New StringBuilder

    Dim oCons As Logica.cConsultasSysacad
    Dim oDoc As New XmlDocument
    Dim oNodo As XmlNode

    oDoc.LoadXml(oCons.XML_obtenerMateriasRegulares(CStr(ViewState("legajo")), sEspecialidad))
    sOut.Append("<HR>")
    sOut.Append("MATERIAS REGULARES<br />")
    sOut.Append("	<TABLE BORDER='1'>")
    sOut.Append("		<TR >")
    sOut.Append("			<TH>Cursada</TH>")
    sOut.Append("			<TH>Año</TH>")
    sOut.Append("			<TH>Plan</TH>")
    sOut.Append("			<TH>Materia</TH>")
    sOut.Append("			<TH>Comision</TH>")
    sOut.Append("		</TR>")

    For Each oNodo In oDoc.SelectSingleNode("DATOS").ChildNodes
      sOut.Append("<TR >")
      sOut.Append("	<TD >" & getNodo(oNodo, "CURSADA") & "</TD>")
      sOut.Append("	<TD >" & getNodo(oNodo, "ANIO") & "º</TD>")
      sOut.Append("	<TD >" & getNodo(oNodo, "PLAN") & "</TD>")
      sOut.Append("	<TD >" & getNodo(oNodo, "MATERIA") & "</TD>")
      sOut.Append("	<TD >" & getNodo(oNodo, "COMISION") & "</TD>")
      sOut.Append("</TR>")
    Next
    sOut.Append("	</TABLE>")

    Me.lblMateriasRegulares.Text = sOut.ToString
  End Sub

  Private Sub Examenes()
    'objetivo: Examenes
    'in
    'out
    Dim sOut As New StringBuilder

    Dim oCons As Logica.cConsultasSysacad
    Dim oDoc As New XmlDocument
    Dim oNodo As XmlNode

    oDoc.LoadXml(oCons.XML_obtenerExamenes(CStr(ViewState("legajo")), sEspecialidad))
    sOut.Append("<HR>")
    sOut.Append("EXAMENES<br />")
    sOut.Append("	<TABLE BORDER='1'>")
    sOut.Append("		<TR >")
    sOut.Append("			<TH>Año</TH>")
    sOut.Append("			<TH>Plan</TH>")
    sOut.Append("			<TH>Materia</TH>")
    sOut.Append("			<TH>Nota</TH>")
    sOut.Append("			<TH>Fecha</TH>")
    sOut.Append("		</TR>")

    For Each oNodo In oDoc.SelectSingleNode("DATOS").ChildNodes
      sOut.Append("<TR >")
      sOut.Append("	<TD >" & getNodo(oNodo, "ANIO") & "º</TD>")
      sOut.Append("	<TD >" & getNodo(oNodo, "PLAN") & "</TD>")
      sOut.Append("	<TD >" & getNodo(oNodo, "MATERIA") & "</TD>")
      sOut.Append("	<TD >" & getNodo(oNodo, "NOTA") & "</TD>")
      sOut.Append("	<TD >" & getNodo(oNodo, "FECHA") & "</TD>")
      sOut.Append("</TR>")
    Next
    sOut.Append("	</TABLE>")

    Me.lblExamenes.Text = sOut.ToString
  End Sub

  Private Sub Promedio()
    'objetivo: Promedio
    'in
    'out
    Dim sOut As New StringBuilder

    Dim oCons As Logica.cConsultasSysacad
    Dim oDoc As New XmlDocument

    oDoc.LoadXml(oCons.XML_obtenerPromedio(CStr(ViewState("legajo")), sEspecialidad))
    sOut.Append("<HR>")
    sOut.Append("PROMEDIO<br />")
    sOut.Append("NOTA: " & getNodo(oDoc, "//PROMEDIO"))

    Me.lblPromedio.Text = sOut.ToString
  End Sub

  Private Sub Cursado()
    'objetivo: Cursado actual
    'in
    'out
    Dim sOut As New StringBuilder

    Dim oCons As Logica.cConsultasSysacad
    Dim oDoc As New XmlDocument
    Dim oNodo As XmlNode

    oDoc.LoadXml(oCons.XML_obtenerCursadoActual(CStr(ViewState("legajo")), sEspecialidad))
    sOut.Append("<HR>")
    sOut.Append("CURSANDO<br />")
    sOut.Append("	<TABLE BORDER='1'>")
    sOut.Append("		<TR >")
    sOut.Append("			<TH>Año</TH>")
    sOut.Append("			<TH>Materia</TH>")
    sOut.Append("			<TH>Comision</TH>")
    sOut.Append("		</TR>")

    For Each oNodo In oDoc.SelectSingleNode("DATOS").ChildNodes
      sOut.Append("<TR >")
      sOut.Append("	<TD >" & getNodo(oNodo, "ANIO") & "º</TD>")
      sOut.Append("	<TD >" & getNodo(oNodo, "MATERIA") & "</TD>")
      sOut.Append("	<TD >" & getNodo(oNodo, "COMISION") & "</TD>")
      sOut.Append("</TR>")
    Next
    sOut.Append("	</TABLE>")

    Me.lblCursadoActual.Text = sOut.ToString
  End Sub

  Private Sub cmdVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
    Response.Redirect("lstDatosP.aspx")
  End Sub
End Class
