Public Class PostAmano
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents btnSave As System.Web.UI.WebControls.Button
  Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
  Protected WithEvents cboBusqueda As System.Web.UI.WebControls.DropDownList
  Protected WithEvents txtPostulante As System.Web.UI.WebControls.TextBox

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

  Dim otbl_busqueda As New Logica.tbl_busqueda

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'Introducir aquí el código de usuario para inicializar la página
    If Not Page.IsPostBack Then
      If Not Request.QueryString("IDP") Is Nothing AndAlso Not Request.QueryString("datdesc") Is Nothing Then
        ViewState("idPostulante") = Request.QueryString("IDP").ToString
        ViewState("DatosP") = Request.QueryString("datdesc").ToString
        initSreen()
      Else
        'redirecciono a la pantalla desde donde se llamo
        Response.Redirect(Request.UrlReferrer.ToString)
      End If

    End If
  End Sub

  Private Sub initSreen()

    'coloco los datos del postulante 
    Me.txtPostulante.Text = Server.UrlDecode(ViewState("DatosP"))
    'Precarga la seleccion del combo de busquedas
    Me.CargoRecuros("cboBusqueda")
    
  End Sub

  Private Sub CargoRecuros(ByVal selector As String)
    'cargo recursos selectivamente
    Select Case selector
      Case "cboBusqueda"
        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Busquedas(False))
        With Me.cboBusqueda
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With
    End Select
  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    Dim strPosibleError As String

    If Me.cboBusqueda.SelectedValue = -1 Then
      strPosibleError = "Debe seleccionar una busqueda"
    End If

    If strPosibleError = "" Then
      otbl_busqueda.idBusqueda = Val(Me.cboBusqueda.SelectedValue)
      'Registro los datos de postulacion
      strPosibleError = otbl_busqueda.PostularseAbusqueda(Val(ViewState("idPostulante")))
    End If

    If strPosibleError <> "" Then
      Me.ColocarMensaje(strPosibleError)
    Else
      'redirecciono a la pantalla desde donde se llamo
      Response.Redirect("lstdatosP.aspx")
    End If
  End Sub

  Private Sub ColocarMensaje(ByVal texto As String)
    'coloco el mensaje de error
    lblError.Text = texto
    lblError.Visible = True
  End Sub

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    'redirecciono a la pantalla desde donde se llamo
    Response.Redirect("lstdatosP.aspx")
  End Sub
End Class
