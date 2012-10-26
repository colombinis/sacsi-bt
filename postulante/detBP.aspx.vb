Public Class detBP
  Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

  <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

  End Sub

  Protected WithEvents txtidEmpresa As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtidBusqueda As System.Web.UI.WebControls.TextBox
  Protected WithEvents txttitulo As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtfechaDesde As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtfechaHasta As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtotroRequisitos As System.Web.UI.WebControls.TextBox
  Protected WithEvents btnSave As System.Web.UI.WebControls.Button
  Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents cboVinculo As System.Web.UI.WebControls.DropDownList
  Protected WithEvents gridEspecialidad As System.Web.UI.WebControls.DataGrid
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    InitializeComponent()
  End Sub

#End Region

  Dim otbl_busqueda As New Logica.tbl_busqueda

  Dim idPostulante As Integer

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    idPostulante = Logica.cUtil.varSession(Logica.cUtil.userSession.UserLogonID)

    If Not Page.IsPostBack Then
      If Not Request.QueryString("IDE") Is Nothing AndAlso Not Request.QueryString("IDB") Is Nothing Then
        If IsNumeric(Request.QueryString("IDE").ToString) AndAlso IsNumeric(Request.QueryString("IDB").ToString) Then
          ViewState("idEmpresa") = Request.QueryString("IDE").ToString
          ViewState("idBusqueda") = Request.QueryString("IDB").ToString
          Me.txtidEmpresa.Text = Val(ViewState("idEmpresa"))
          Me.txtidBusqueda.Text = Val(ViewState("idBusqueda"))
          ' el postulante ve SOLO LECTURA
          Me.DisableControls()
          Me.InitScreen()
        Else
          'redirecciono a la pagina inicio
          Logica.cUtil.RedireccionarInicioPostulante(Response)
        End If
      Else
        'redirecciono a la pagina inicio
        'Response.Redirect("~/postulante/lstBPost.aspx", False)
        Logica.cUtil.RedireccionarInicioPostulante(Response)
      End If
    End If

  End Sub


  Private Sub InitScreen()
    CargoRecuros("gridEspecialidad")
    CargoRecuros("cboVinculo")

    'busco si el id es <> ""
    Dim oDT As DataTable
    Dim oDR As DataRow
    If Val(ViewState("idBusqueda")) > 0 And Val(ViewState("idEmpresa")) > 0 Then
      oDT = otbl_busqueda.TraerTodas(idPostulante, CInt(ViewState("idBusqueda")))
      If Not IsNothing(oDT) Then
        oDR = oDT.Rows(0)
      End If
    End If

    If Not oDR Is Nothing Then
      'cargo los valores existentes
      Me.txtidBusqueda.Text = Trim("" & oDR("idBusqueda"))
      Me.txttitulo.Text = Trim("" & oDR("titulo"))
      Me.txtfechaDesde.Text = Trim("" & oDR("fechaDesde"))
      Me.txtfechaHasta.Text = Trim("" & oDR("fechaHasta"))
      Me.txtotroRequisitos.Text = Trim("" & oDR("otroRequisitos"))
      Me.cboVinculo.SelectedValue = Trim("" & oDR("tipoVinculo"))
      otbl_busqueda.strEspecialidad = Trim("" & oDR("strEspecialidad"))
      ViewState("strEspecialidad") = otbl_busqueda.strEspecialidad
    End If
    'actualizo los datos en la grilla
    ColocarValoresEnGrilla()
  End Sub

  Private Sub DisableControls()
    'desabilito los controles
    'COLOCO LOS CONTROLES EN SOLO LECTURA
    Me.txtidEmpresa.ReadOnly = True
    Me.txtidBusqueda.ReadOnly = True
    Me.txttitulo.ReadOnly = True
    Me.txtfechaDesde.ReadOnly = True
    Me.txtfechaHasta.ReadOnly = True
    Me.txtotroRequisitos.ReadOnly = True
    Me.cboVinculo.Enabled = False
    Me.gridEspecialidad.Enabled = False
  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    Dim strPosibleError As String = ""

    otbl_busqueda.idEmpresa = Val(ViewState("idEmpresa"))
    otbl_busqueda.idBusqueda = Val(ViewState("idBusqueda"))

    'Regristro los datos de postulacion
    strPosibleError = otbl_busqueda.PostularseAbusqueda(idPostulante)
    If strPosibleError <> "" Then
      Me.ColocarMensaje(strPosibleError)
    End If

    'si todo esta ok regreso al listado
    If strPosibleError = "" Then Response.Redirect("lstBPost.aspx")
  End Sub

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    'Vuelvo a la lista de las busquedas para el postulante
    Response.Redirect("lstBPost.aspx")
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


  Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
    ''''Objetivo: agrego el script para los cotroles
    '''Dim strValores As String
    ''''javascript que visualiza el afiche
    '''Me.cmdAfiche.Attributes.Add("onClick", "javascript:return verAfiche('" & strValores & "');")
  End Sub

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

End Class