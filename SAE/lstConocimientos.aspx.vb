Public Class lstConocimientos
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

  'El Diseñador de Web Forms requiere esta llamada.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents oGrid As System.Web.UI.WebControls.DataGrid
  Protected WithEvents btnNew As System.Web.UI.WebControls.Button
  Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
  Protected WithEvents txtFILTRO As System.Web.UI.WebControls.TextBox
  Protected WithEvents cantReg As System.Web.UI.HtmlControls.HtmlGenericControl
  Protected WithEvents cmdDocumentacion As System.Web.UI.WebControls.Button
  Protected WithEvents txtIDOculto As System.Web.UI.HtmlControls.HtmlInputHidden

  'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
  'No se debe eliminar o mover.
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
    'No la modifique con el editor de código.
    InitializeComponent()
  End Sub

#End Region

  Dim oCono As New Logica.cConocimiento

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If Not Page.IsPostBack Then
      Me.LoadList()
    End If

  End Sub

  Private Sub LoadList(Optional ByVal Filtro As String = "")
    'cargo los datos de la grilla
    Dim oDT As DataTable = oCono.TraerTodos(Filtro)
    If Not IsNothing(oDT) Then
      cantReg.InnerText = "Lista de conocimientos(" & oDT.Rows.Count & ")"

      oGrid.DataKeyField = "idconocimiento"
      oGrid.DataSource = oDT
      oGrid.DataBind()
    Else
      cantReg.InnerText = "Lista de conocimientos(0)"
      'ocultar los botones de las acciones que no se pueden hacer si no hay registros
    End If

  End Sub

  Private Sub oGrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles oGrid.ItemDataBound
    Dim strIdFiltro As String
    'agrego el script a cada fila
    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
      'TODO: verificar en que celda oculta quedo el id para pasar al javascript  
      strIdFiltro = e.Item.Cells(1).Text
      CType(e.Item.FindControl("imgDelete"), ImageButton).Attributes.Add("onClick", "javascript:return confirmDelete();")
      CType(e.Item.FindControl("optRows"), RadioButton).Attributes.Add("onClick", "javascript:return Selrow(this,'" & strIdFiltro & "');")
    End If

  End Sub

  Private Sub oGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles oGrid.ItemCommand
    'al hacer clic en la imagen de la columna
    Dim mKey As String = oGrid.DataKeys(e.Item.ItemIndex)

    Select Case e.CommandName.ToUpper

      Case "VIEW"
        Response.Redirect("detConocimiento.aspx?ID=" & mKey & "&ACTION=V")
      Case "EDIT"
        Response.Redirect("detConocimiento.aspx?ID=" & mKey)
      Case "DELETE"
        oCono.idConocimiento = mKey
        oCono.Borrar()
        Me.LoadList()

    End Select

  End Sub

  Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
    Response.Redirect("detConocimiento.aspx")
  End Sub

  Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
    'busco por la descripcion del conocimiento
    Me.LoadList(Me.txtFILTRO.Text)
  End Sub

  Private Sub InitScreen()
    ''''CargoRecuros("")
    ''''oculto los cotroles de la cabecera
    ''''MostrarOcultar("", False)
    ''''busco la XXX si el id es <> ""
    ''''Dim oDR As DataRow
    ''''If IdEmpresa > 0 Then
    ''''  oDR = oCono.Traer(IdEmpresa)
    ''''End If

    ''''If Not oDR Is Nothing Then
    ''''  'cargo los valores existentes
    ''''  'Me.txtCuit.Text = Trim("" & oDR("cuit"))
    ''''  'Me.cboEstadoCono.SelectedValue = oDR("idEstadoCono")
    ''''End If
  End Sub
  Private Sub CargoRecuros(ByVal selector As String)
    'cargo recursos selectivamente
    '''Select Case selector
    '''  Case ""
    '''    Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(oCono.ListarCombo_TipoCono())
    '''    With Me.cboTipoCono
    '''      .DataValueField = "ID"
    '''      .DataTextField = "DESCRIPCION"
    '''      .DataSource = oDT
    '''      .DataBind()
    '''    End With
    '''End Select
  End Sub

  Private Sub MostrarOcultar(ByVal selector As String, ByVal valor As Boolean)
    'oculto o muestro selectivamente
    Select Case selector.ToUpper
      Case ""
        'van siempre deshabilitados
        'Me.txtCuit.Enabled = valor
    End Select
  End Sub
End Class