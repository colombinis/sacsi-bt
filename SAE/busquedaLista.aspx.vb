
Public Class BusquedaLista
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
  Protected WithEvents cmdVolver As System.Web.UI.WebControls.Button
  Protected WithEvents cmdListarPostulantes As System.Web.UI.WebControls.Button
  Protected WithEvents cboEmpresas As System.Web.UI.WebControls.DropDownList
  Protected WithEvents lblError As System.Web.UI.WebControls.Label

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
    Dim idEmpresa As Integer
    Me.lblError.Visible = False

    If Not Page.IsPostBack Then
      If Not Request.QueryString("ID") Is Nothing Then
        ViewState("IdEmpresa") = Request.QueryString("ID").ToString
        idEmpresa = CInt(ViewState("IdEmpresa"))
        initScreen(idEmpresa)
        Me.LoadList(idEmpresa)
      Else
        'redirecciono a la pagina desde donde se llamo
        Response.Redirect(Request.UrlReferrer.ToString)
      End If
    End If

  End Sub

  Private Sub initScreen(ByVal idEmpresa As Integer)
    'Cargo el combo de las empresas  y sincronizo con la empresa que elegi
    Me.CargoRecursos("cboEmpresas")
    If idEmpresa > 0 Then
      Me.cboEmpresas.SelectedValue = CStr(idEmpresa)
    End If
  End Sub


  Private Sub LoadList(Optional ByVal idEmpresa As Integer = 0, Optional ByVal idBusqueda As Integer = 0)
    'cargo las busquedas de la empresa
    Dim oDT As DataTable

    otbl_busqueda.idEmpresa = idEmpresa
    otbl_busqueda.idBusqueda = idBusqueda
    oDT = otbl_busqueda.Traer()

    If Not IsNothing(oDT) Then
      cantReg.InnerText = "Lista de Busquedas(" & oDT.Rows.Count & ")"
    Else
      cantReg.InnerText = "Lista de Busquedas(0)"
      'ocultar los botones de las acciones que no se pueden hacer si no hay registros
    End If
    oGrid.DataKeyField = "idBusqueda"
    oGrid.DataSource = oDT
    oGrid.DataBind()
  End Sub

  Private Sub oGrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles oGrid.ItemDataBound
    Dim strIdFiltro As String
    'agrego el script a cada fila
    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
      strIdFiltro = e.Item.Cells(2).Text
      CType(e.Item.FindControl("imgDelete"), ImageButton).Attributes.Add("onClick", "javascript:return confirmDelete();")
      CType(e.Item.FindControl("optRows"), RadioButton).Attributes.Add("onClick", "javascript:return Selrow(this,'" & strIdFiltro & "');")
    End If

  End Sub

  Private Sub oGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles oGrid.ItemCommand
    'al hacer clic en la imagen de la columna
    Dim idB As String = oGrid.Items(e.Item.ItemIndex).Cells(2).Text
    'Solo permito realizar acciones con las busquedas si esta seleccionada una Empresa en el combo
    If Me.cboEmpresas.SelectedValue <> "-1" Then
      Select Case e.CommandName.ToUpper

        Case "VIEW"
          Response.Redirect("BusquedaDetalle.aspx?IDE=" & Val(Me.cboEmpresas.SelectedValue) & "&IDB=" & idB & "&ACTION=V")
        Case "EDIT"
          Response.Redirect("BusquedaDetalle.aspx?IDE=" & Val(Me.cboEmpresas.SelectedValue) & "&IDB=" & idB)
        Case "DELETE"
          otbl_busqueda.idEmpresa = CInt(Me.cboEmpresas.SelectedValue)
          otbl_busqueda.idBusqueda = CInt(idB)
          otbl_busqueda.Borrar()
          Response.Redirect("busquedalista.aspx?ID=" & Val(ViewState("IdEmpresa")))
      End Select
    Else
      'error, que seleccione una empresa
      ColocarMensaje("Debe seleccionar una empresa")
    End If
    

  End Sub

  Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
    Response.Redirect("BusquedaDetalle.aspx?IDE=" & Val(ViewState("IdEmpresa")))
  End Sub

  Private Sub RefrescarGrilla()
    Dim idE As Integer = 0
    Dim idB As Integer = 0

    'busco la idBusqueda con el filtro ingresado
    If IsNumeric(Me.txtFILTRO.Text) Then
      idB = CInt(Me.txtFILTRO.Text)
    End If

    'la empresa
    If Me.cboEmpresas.SelectedValue <> "-1" Then
      idE = CInt(Me.cboEmpresas.SelectedValue)
    End If

    Me.LoadList(idE, idB)

  End Sub

  Private Sub CargoRecursos(ByVal selector As String)
    'cargo recursos selectivamente
    Select Case selector
      Case "cboEmpresas"

        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Empresas)
        With Me.cboEmpresas
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With
    End Select
  End Sub

  Private Sub MostrarOcultar(ByVal selector As String, ByVal valor As Boolean)
    ''''oculto o muestro selectivamente
    '''Select Case selector.ToUpper
    '''  Case ""
    '''    'van siempre deshabilitados
    '''    'Me.txtCuit.Enabled = valor
    '''End Select
  End Sub

  Private Sub cmdVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
    Response.Redirect("empresalista.aspx")
  End Sub

  Private Sub cmdListarPostulantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListarPostulantes.Click
    If Me.txtIDOculto.Value <> "" Then
      Response.Redirect("lstDatosP.aspx?IDB=" & Me.txtIDOculto.Value)
    End If
  End Sub

  Private Sub txtFILTRO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFILTRO.TextChanged
    'refresco la grilla
    Me.RefrescarGrilla()
  End Sub

  Private Sub cboEmpresas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmpresas.SelectedIndexChanged
    'refresco la grilla
    Me.RefrescarGrilla()
  End Sub

  Private Sub ColocarMensaje(ByVal texto As String)
    'coloco el mensaje de error
    lblError.Text = texto
    lblError.Visible = True
  End Sub

End Class
