Imports System.Text
Imports bolsatrabajo.Logica.cUtil

Public Class busquedaDetalle
  Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

  <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

  End Sub

  Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
  Protected WithEvents txtidEmpresa As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtidBusqueda As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqtitulo As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txttitulo As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqtipoVinculo As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents reqfechaDesde As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtfechaDesde As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqfechaHasta As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtfechaHasta As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqotroRequisitos As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtotroRequisitos As System.Web.UI.WebControls.TextBox
  Protected WithEvents btnSave As System.Web.UI.WebControls.Button
  Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents cboVinculo As System.Web.UI.WebControls.DropDownList
  Protected WithEvents gridEspecialidad As System.Web.UI.WebControls.DataGrid
  Protected WithEvents AficheEditable As System.Web.UI.WebControls.Button
  Protected WithEvents cbobusquedaPublica As System.Web.UI.WebControls.DropDownList
  Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    InitializeComponent()
  End Sub

#End Region

  Dim otbl_busqueda As New Logica.tbl_busqueda

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If Not Page.IsPostBack Then
      If Not Request.QueryString("IDE") Is Nothing Then
        ViewState("idEmpresa") = Request.QueryString("IDE").ToString
        Me.txtidEmpresa.Text = CStr(ViewState("idEmpresa"))
        otbl_busqueda.idEmpresa = CInt(ViewState("idEmpresa"))
        If Not Request.QueryString("IDB") Is Nothing Then
          ViewState("idBusqueda") = Request.QueryString("IDB").ToString
          otbl_busqueda.idBusqueda = CInt(ViewState("idBusqueda"))
        End If
        If Not Request.QueryString("Action") Is Nothing AndAlso Request.QueryString("Action").ToString = "V" Then
          Me.DisableControls()
        End If
      End If
      Me.InitScreen()
    End If

  End Sub

  Private Sub InitScreen()
    CargoRecuros("gridEspecialidad")
    CargoRecuros("cboVinculo")

    'busco si el id es <> ""
    Dim oDR As DataRow
    If otbl_busqueda.idBusqueda > 0 And otbl_busqueda.idEmpresa > 0 Then
      oDR = otbl_busqueda.Traer().Rows(0)
    End If

    If Not oDR Is Nothing Then
      'cargo los valores existentes
      Me.txtidBusqueda.Text = Trim("" & CStr(oDR("idBusqueda")))
      Me.txttitulo.Text = Trim("" & CStr(oDR("titulo")))
      Me.cboVinculo.SelectedValue = Trim("" & CStr(oDR("tipoVinculo")))
      Me.txtfechaDesde.Text = Trim("" & CStr(oDR("fechaDesde")))
      Me.txtfechaHasta.Text = Trim("" & CStr(oDR("fechaHasta")))
      Me.txtotroRequisitos.Text = Trim("" & CStr(oDR("otroRequisitos")))
      otbl_busqueda.strEspecialidad = Trim("" & CStr(oDR("strEspecialidad")))
      ViewState("strEspecialidad") = otbl_busqueda.strEspecialidad
      Me.cbobusquedaPublica.SelectedValue = Trim("" & CStr(oDR("publica")))

    Else
      'precargo los valores para un registro nuevo
      '''Me.cboEstadoEmpresa.SelectedValue = Logica.estadoEmpresa.inicial
      Me.txtfechaDesde.Text = Format(Date.Now, "dd/MM/yyyy")
      Me.txtfechaHasta.Text = Format(Date.Now.AddMonths(1), "dd/MM/yyyy")
    End If

    'actualizo los datos en la grilla
    ColocarValoresEnGrilla()
  End Sub

  Private Sub DisableControls()
    'desabilito los controles 
    Me.txtidEmpresa.Enabled = False
    Me.txtidBusqueda.Enabled = False
    Me.txttitulo.Enabled = False
    Me.cboVinculo.Enabled = False
    Me.gridEspecialidad.Enabled = False
    Me.txtfechaDesde.Enabled = False
    Me.txtfechaHasta.Enabled = False
    Me.txtotroRequisitos.Enabled = False
    Me.cbobusquedaPublica.Enabled = False
    btnSave.Enabled = False
  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    Dim strPosibleError As String = ""

    otbl_busqueda.idEmpresa = CInt(ViewState("idEmpresa"))
    otbl_busqueda.idBusqueda = CInt(ViewState("idBusqueda"))
    otbl_busqueda.titulo = Me.txttitulo.Text
    otbl_busqueda.tipoVinculo = CInt(Me.cboVinculo.SelectedItem.Value)
    otbl_busqueda.fechaDesde = CDate(Me.txtfechaDesde.Text)
    otbl_busqueda.fechaHasta = CDate(Me.txtfechaHasta.Text)
    otbl_busqueda.otroRequisitos = Me.txtotroRequisitos.Text
    otbl_busqueda.strEspecialidad = getValoresEspecialidad()
    ViewState("strEspecialidad") = getValoresEspecialidad()
    otbl_busqueda.publica = Me.cbobusquedaPublica.SelectedValue

    'verifico si se eligio alguna especialidad
    If otbl_busqueda.strEspecialidad = "" Then
      strPosibleError = "Debe seleccionar al menos una especialidad"
    End If

    'verifico si el texto ingresado en otros requisitos es menor igual a 4000
    If otbl_busqueda.otroRequisitos.Length >= 4000 Then
      strPosibleError = "El dato 'Otros requisitos' tiene demasiados caracteres. Maximo permitido 4000 caracteres "
    End If

    If strPosibleError = "" Then
      If otbl_busqueda.idBusqueda > 0 Then
        'Ya existe en la Base de datos
        'modifico los valores
        otbl_busqueda.Editar()
      Else
        'agrego el nuevo registro
        'nro de busqueda es secuencial
        strPosibleError = otbl_busqueda.Agregar()
        If strPosibleError <> "" Then
          Me.ColocarMensaje("Error al agregar datos")
        End If
      End If
    Else
      Me.ColocarMensaje(strPosibleError)
    End If

    'si todo esta ok regreso al listado
    If strPosibleError = "" Then Response.Redirect("busquedaLista.aspx?ID=" & otbl_busqueda.idEmpresa)
  End Sub

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    Response.Redirect("busquedaLista.aspx?ID=" & Val(ViewState("idEmpresa")))
  End Sub

  Private Sub CargoRecuros(ByVal selector As String)
    'cargo recursos selectivamente
    Select Case selector
      Case "gridEspecialidad"
        Dim oDT As DataTable = Logica.ReglasNegocio.ListarCombo_Especialidad
        With Me.gridEspecialidad
          .DataSource = oDT
          .DataBind()
        End With

      Case "cboVinculo"
        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Vinculo)
        With Me.cboVinculo
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With
    End Select
  End Sub

  Private Sub ColocarMensaje(ByVal texto As String)
    'coloco el mensaje de error
    lblError.Text = texto
    lblError.Visible = True
  End Sub

  Private Function getDescripEspecialidadesElegidas() As String
    'recorro la grilla y devuelvo concatenados las descripciones de las especialidades elegidas en la grilla

    Dim i As Integer
    Dim oChk As CheckBox
    Dim strCods As New StringBuilder
    Dim codId As String
    strCods.Append("<UL>")
    For i = 0 To Me.gridEspecialidad.Items.Count - 1
      codId = Me.gridEspecialidad.Items(i).Cells(1).Text
      If InStr(CStr(ViewState("strEspecialidad")), "[" & codId & "]") > 0 Then

        strCods.Append("<LI>" & Trim(Me.gridEspecialidad.Items(i).Cells(2).Text))
      End If
      ' strCods.Append(Trim(Me.gridEspecialidad.Items(i).Cells(2).Text))
    Next
    strCods.Append("</UL>")

    Return strCods.ToString
  End Function

  Private Function getValoresEspecialidad() As String
    'recorro la grilla y devuelvo concatenados los ids de la especialidad
    'NOTA: el formato es [cod1][cod2]
    Dim i As Integer
    Dim oChk As CheckBox
    Dim strCods As New StringBuilder
    For i = 0 To Me.gridEspecialidad.Items.Count - 1
      oChk = Me.gridEspecialidad.Items(i).Cells(0).FindControl("chkRow")
      If oChk.Checked = True Then
        strCods.Append("[" & Me.gridEspecialidad.Items(i).Cells(1).Text & "]")
      End If
    Next
    Return strCods.ToString
  End Function

  Private Sub ColocarValoresEnGrilla()
    'coloca los chek de las carreras
    Dim i As Integer
    Dim codId As String
    Dim oChk As CheckBox
    For i = 0 To Me.gridEspecialidad.Items.Count - 1
      codId = Me.gridEspecialidad.Items(i).Cells(1).Text
      oChk = Me.gridEspecialidad.Items(i).Cells(0).FindControl("chkRow")
      'obtengo si esta chekeada la carrera
      If InStr(otbl_busqueda.strEspecialidad, "[" & codId & "]") > 0 Then
        'si esta
        oChk.Checked = True
      Else
        'No esta
        oChk.Checked = False
      End If
    Next
  End Sub

  Private Sub AficheEditable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AficheEditable.Click

    'Introducir aquí el código de usuario para inicializar la página
    '[@pathimagenes]
    '[@nrobusqueda]
    '[@modalidad]
    '[@carrera]
    '[@requisitos]
    'plantBusqueda.htm
    Dim strPlantilla As String = Server.MapPath("../public/plantilla/plantBusqueda.htm")
    Dim oST As New StringBuilder
    oST.Append(ReadTextFile(strPlantilla))
    'reemplazo por los valores reales
    oST.Replace("[@pathimagenes]", GetHttpAppRootPath)
    oST.Replace("[@nrobusqueda]", "Busqueda N" & encriptarHTML("°") & Me.txtidBusqueda.Text)
    oST.Replace("[@modalidad]", Me.cboVinculo.SelectedItem.Text.Replace(" ", ""))
    oST.Replace("[@requisitos]", Me.txtotroRequisitos.Text)
    oST.Replace("[@carrera]", getDescripEspecialidadesElegidas())

    BajarArchivoComo(Response, oST.ToString, "doc", "busqueda", "iso-8859-1")
  End Sub

End Class