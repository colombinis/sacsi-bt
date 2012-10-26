Public Class EmpresaLista
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

  'El Diseñador de Web Forms requiere esta llamada.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents oGrid As System.Web.UI.WebControls.DataGrid
  Protected WithEvents btnNew As System.Web.UI.WebControls.Button
  Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
  Protected WithEvents txtCuit As System.Web.UI.WebControls.TextBox
  Protected WithEvents cantReg As System.Web.UI.HtmlControls.HtmlGenericControl
  Protected WithEvents cmdDocumentacion As System.Web.UI.WebControls.Button
  Protected WithEvents txtIDempresa As System.Web.UI.HtmlControls.HtmlInputHidden
  Protected WithEvents cmdBusquedas As System.Web.UI.WebControls.Button
  Protected WithEvents txtRaxonSocial As System.Web.UI.WebControls.TextBox

  'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
  'No se debe eliminar o mover.
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
    'No la modifique con el editor de código.
    InitializeComponent()
  End Sub

#End Region

  Dim oEmpresa As New Logica.cEmpresa

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If Not Page.IsPostBack Then
      Me.LoadList()
    End If

  End Sub

  Private Sub LoadList(Optional ByVal strCuit As String = "", Optional ByVal strRazonSocial As String = "")
    'cargo los datos de la grilla
    Dim oDT As DataTable = oEmpresa.Traer(strCuit, strRazonSocial)
    If Not IsNothing(oDT) Then
      cantReg.InnerText = "Lista de Empresas(" & oDT.Rows.Count & ")"
    Else
      cantReg.InnerText = "Lista de Empresas(0)"
      'ocultar los botones de las acciones
      'NOTA: solo se podria Agregar nueva o buscar 
      Me.cmdDocumentacion.Visible = False
    End If
    oGrid.DataKeyField = "idempresa"
    oGrid.DataSource = oDT
    oGrid.DataBind()

  End Sub

  Private Sub oGrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles oGrid.ItemDataBound
    Dim strIdEmpresa As String
    'agrego el script a cada fila
    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
      strIdEmpresa = e.Item.Cells(1).Text
      CType(e.Item.FindControl("imgDelete"), ImageButton).Attributes.Add("onClick", "javascript:return confirmDelete();")
      CType(e.Item.FindControl("optRows"), RadioButton).Attributes.Add("onClick", "javascript:return Selrow(this,'" & strIdEmpresa & "');")
    End If

  End Sub

  Private Sub oGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles oGrid.ItemCommand
    'al hacer clic en la imagen de la columna
    Dim mKey As String = oGrid.DataKeys(e.Item.ItemIndex)

    Select Case e.CommandName.ToUpper

      Case "VIEW"
        Response.Redirect("EmpresaDetalle.aspx?ID=" & mKey & "&ACTION=V")
      Case "EDIT"
        Response.Redirect("EmpresaDetalle.aspx?ID=" & mKey)
      Case "DELETE"
        oEmpresa.Borrar(mKey)

        Me.LoadList()

    End Select

  End Sub

  Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
    Response.Redirect("EmpresaDetalle.aspx")
  End Sub

  Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
    'busco la empresa con el cuit ingresado y la razon social
    Me.LoadList(Me.txtCuit.Text, Me.txtRaxonSocial.Text)
  End Sub

  'ACCIONES
  Private Sub cmdDocumentacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDocumentacion.Click
    If Me.txtIDempresa.Value <> "" Then
      Response.Redirect("EmpresaDocum.aspx?ID=" & Me.txtIDempresa.Value)
    End If

  End Sub
  Private Sub cmdBusquedas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBusquedas.Click
    If Me.txtIDempresa.Value <> "" Then
      Response.Redirect("BusquedaLista.aspx?ID=" & Me.txtIDempresa.Value)
    End If
  End Sub
End Class
