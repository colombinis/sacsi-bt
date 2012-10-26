Imports System.Text
Imports bolsatrabajo.Logica.cUtil

Public Class lstCuotas
  Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

  'El Diseñador de Web Forms requiere esta llamada.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents oGrid As System.Web.UI.WebControls.DataGrid
  Protected WithEvents btnNew As System.Web.UI.WebControls.Button
  Protected WithEvents cantReg As System.Web.UI.HtmlControls.HtmlGenericControl
  Protected WithEvents cmdDocumentacion As System.Web.UI.WebControls.Button
  Protected WithEvents txtIDOculto As System.Web.UI.HtmlControls.HtmlInputHidden
  Protected WithEvents cboBusqueda As System.Web.UI.WebControls.DropDownList
  Protected WithEvents cmdNotaPagoGenerica As System.Web.UI.WebControls.Button

  'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
  'No se debe eliminar o mover.
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
    'No la modifique con el editor de código.
    InitializeComponent()
  End Sub

#End Region

  Dim otbl_cuotasEmpresa As New Logica.tbl_cuotasEmpresa

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If Not Page.IsPostBack Then
      InitScreen()
    End If

  End Sub

  Private Sub LoadList(Optional ByVal idFiltro As Integer = 0)
    'cargo los datos de la grilla
    Dim oDT As DataTable

    If idFiltro > 0 Then
      oDT = otbl_cuotasEmpresa.Traer(idFiltro)
    Else
      oDT = otbl_cuotasEmpresa.Traer()
    End If

    If Not IsNothing(oDT) Then
      cantReg.InnerText = "Lista de cuotas(" & oDT.Rows.Count & ")"
    Else
      cantReg.InnerText = "Lista de cuotas(0)"
      'ocultar los botones de las acciones que no se pueden hacer si no hay registros
    End If

    oGrid.DataSource = oDT
    oGrid.DataBind()
  End Sub

  Private Sub oGrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles oGrid.ItemDataBound
    Dim strIdFiltro As String
    'agrego el script a cada fila
    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
      'TODO: verificar en que celda oculta quedo el id para pasar al javascript  
      strIdFiltro = e.Item.Cells(1).Text

      CType(e.Item.FindControl("optRows"), RadioButton).Attributes.Add("onClick", "javascript:return Selrow(this,'" & strIdFiltro & "');")
    End If

  End Sub

  Private Sub oGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles oGrid.ItemCommand
    'al hacer clic en la imagen de la columna
    Dim mKey As String = e.Item.Cells(1).Text

    Select Case e.CommandName.ToUpper

      Case "VIEW"
        Response.Redirect("detCuotas.aspx?ID=" & mKey & "&ACTION=V")
        '''Case "EDIT"
        '''  Response.Redirect("XXXDetalle.aspx?ID=" & mKey)
        '''Case "DELETE"
        '''  otbl_cuotasEmpresa.Borrar(mKey)
        '''  Me.LoadList()
    End Select

  End Sub

  Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
    Response.Redirect("detCuotas.aspx")
  End Sub


  Private Sub InitScreen()
    CargoRecuros("cboBusqueda")
    Me.LoadList()
  End Sub

  Private Sub CargoRecuros(ByVal selector As String)
    'cargo recursos selectivamente
    Select Case selector
      Case "cboBusqueda"
        'lleno el como con las empresas
        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Empresas)
        With Me.cboBusqueda
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With
    End Select
  End Sub

  Private Sub MostrarOcultar(ByVal selector As String, ByVal valor As Boolean)
    'oculto o muestro selectivamente
    Select Case selector.ToUpper
      Case ""
        'van siempre deshabilitados
        'Me.txtCuit.Enabled = valor
    End Select
  End Sub

  Private Sub cboBusqueda_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBusqueda.SelectedIndexChanged
    If Me.cboBusqueda.SelectedItem.Value = -1 Then
      Me.LoadList()
    Else
      Me.LoadList(Me.cboBusqueda.SelectedItem.Value)
    End If
  End Sub

  Private Sub cmdNotaPagoGenerica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNotaPagoGenerica.Click
    'Introducir aquí el código de usuario para inicializar la página
    '[@pathimagenes]
    '[@fechaHoy]
    '[@importe]
    '[@importePesos]
    '[@empresa]
    '[@concepto]
    Dim strPlantilla As String = Server.MapPath("../public/plantilla/plantNotaPagoGenerica.htm")
    Dim oST As New StringBuilder
    oST.Append(ReadTextFile(strPlantilla))
    'reemplazo por los valores reales
    oST.Replace("[@pathimagenes]", GetHttpAppRootPath)
    oST.Replace("[@fechaHoy]", String.Format("{0:dd 'de' MMMM 'de' yyyy}", Date.Today))

    BajarArchivoComo(Response, oST.ToString, "doc", "NotaPago")
  End Sub
End Class