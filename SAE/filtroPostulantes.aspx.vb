Imports bolsatrabajo.Logica.cUtil

Public Class filtroPostulantes
  Inherits System.Web.UI.Page
#Region " Código generado por el Diseñador de Web Forms "

  'El Diseñador de Web Forms requiere esta llamada.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents oGrid As System.Web.UI.WebControls.DataGrid
  Protected WithEvents cantReg As System.Web.UI.HtmlControls.HtmlGenericControl
  Protected WithEvents cmdDocumentacion As System.Web.UI.WebControls.Button
  Protected WithEvents txtIDOculto As System.Web.UI.HtmlControls.HtmlInputHidden
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents cmdExportarGrilla As System.Web.UI.WebControls.Button
  Protected WithEvents Ucfiltrado1 As ucfiltrado
  Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl

  'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
  'No se debe eliminar o mover.
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
    'No la modifique con el editor de código.
    InitializeComponent()
  End Sub

#End Region

  Dim otbl_postulante As New Logica.tbl_postulante

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim intB As Integer = 0

    If Not Page.IsPostBack Then
      '''If Not Request.QueryString("IDB") Is Nothing Then
      '''  ViewState("idbusqueda") = Request.QueryString("IDB").ToString
      '''  intB = Val(ViewState("idbusqueda"))
      '''End If
    End If

    lblError.Visible = False
  End Sub


  '''Private Sub LoadList(Optional ByVal legajo As Integer = 0, Optional ByVal idBusqueda As Integer = 0)

  '''  'cargo los datos de la grilla
  '''  Dim oDT As DataTable = otbl_postulante.TraerTodos(legajo, idBusqueda)
  '''  If Not IsNothing(oDT) Then
  '''    cantReg.InnerText = "Lista de Postulantes (" & oDT.Rows.Count & ")"
  '''    oGrid.DataKeyField = "idPostulante"

  '''  Else
  '''    cantReg.InnerText = "Lista de Postulantes(0)"
  '''    'ocultar los botones de las acciones que no se pueden hacer si no hay registros
  '''    'TODO: verificar  
  '''  End If
  '''  oGrid.DataSource = oDT
  '''  oGrid.DataBind()
  '''End Sub

  '''Private Sub oGrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles oGrid.ItemDataBound
  '''  Dim strIdFiltro As String
  '''  'agrego el script a cada fila
  '''  If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
  '''    strIdFiltro = e.Item.Cells(1).Text
  '''    '''CType(e.Item.FindControl("imgDelete"), ImageButton).Attributes.Add("onClick", "javascript:return confirmDelete();")
  '''    CType(e.Item.FindControl("optRows"), RadioButton).Attributes.Add("onClick", "javascript:return Selrow(this,'" & strIdFiltro & "');")
  '''  End If

  '''End Sub

  '''Private Sub oGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles oGrid.ItemCommand
  '''  'al hacer clic en la imagen de la columna
  '''  Dim mKey As String = oGrid.DataKeys(e.Item.ItemIndex)
  '''  otbl_postulante.idPostulante = mKey

  '''  Select Case e.CommandName.ToUpper
  '''    Case "VIEW"
  '''      Response.Redirect("detDatosP.aspx?ID=" & mKey & "&ACTION=V")
  '''      '''Case "EDIT"
  '''      '''  Response.Redirect("detDatosP.aspx?ID=" & mKey)
  '''      '''Case "DELETE"
  '''      '''  otbl_postulante.Borrar()
  '''      '''  Me.LoadList()
  '''  End Select

  '''End Sub

  '''Private Sub RefrescarGrilla()
  '''  'en el onchange del legajo y del combo de la pasantia
  '''  Dim legajo As Integer = 0
  '''  Dim busqueda As Integer = 0
  '''  Me.LoadList(legajo, busqueda)
  '''End Sub

  Private Sub CargoRecuros(ByVal selector As String)
    'cargo recursos selectivamente
    '''Select Case selector
    '''  Case "cboBusqueda"
    '''    Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Busquedas(False))
    '''    With Me.cboBusqueda
    '''      .DataValueField = "ID"
    '''      .DataTextField = "DESCRIPCION"
    '''      .DataSource = oDT
    '''      .DataBind()
    '''    End With
    '''End Select
  End Sub


  Private Sub ColocarMensaje(ByVal texto As String)
    'coloco el mensaje de error
    lblError.Text = texto
    lblError.Visible = True
  End Sub

  Private Sub Ucfiltrado1_HayError(ByVal codError As Integer, ByVal msgError As String) Handles Ucfiltrado1.HayError
    Me.ColocarMensaje(msgError)
  End Sub


  Private Sub cmdExportarGrilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarGrilla.Click
    'exportar los datos de la grilla a excell

    Dim tw As New System.IO.StringWriter
    Dim hw As New System.Web.UI.HtmlTextWriter(tw)
    ' obtengo el HTML del control
    Me.oGrid.RenderControl(hw)
    BajarArchivoComo(Response, tw.ToString, "xls", "busqueda")

  End Sub

  Private Sub Ucfiltrado1_ListaPostulantesActualizada(ByVal oDT As System.Data.DataTable) Handles Ucfiltrado1.ListaPostulantesActualizada

    If Not IsNothing(oDT) Then
      cantReg.InnerText = "Lista de Postulantes (" & oDT.Rows.Count & ")"
      oGrid.DataKeyField = "idPostulante"
      Me.cmdExportarGrilla.Enabled = True
    Else
      cantReg.InnerText = "Lista de Postulantes(0)"
      'ocultar los botones de las acciones que no se pueden hacer si no hay registros
      Me.cmdExportarGrilla.Enabled = False
    End If
    oGrid.DataSource = oDT
    oGrid.DataBind()
  End Sub
End Class