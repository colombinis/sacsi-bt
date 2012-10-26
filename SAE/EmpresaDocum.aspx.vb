Public Class EmpresasDocum
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents cmdAceptar As System.Web.UI.WebControls.Button
  Protected WithEvents txtCuit As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtRazonSocial As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtDomicilio As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtTelefonos As System.Web.UI.WebControls.TextBox
  Protected WithEvents oGrid As System.Web.UI.WebControls.DataGrid
  Protected WithEvents cmdVolver As System.Web.UI.WebControls.Button
  Protected WithEvents cboEstadoEmpresa As System.Web.UI.WebControls.DropDownList
  Protected WithEvents cboTipoEmpresa As System.Web.UI.WebControls.DropDownList

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
  Dim IdEmpresa As Integer = 0

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If Not Page.IsPostBack Then
      If Not Request.QueryString("ID") Is Nothing Then
        IdEmpresa = Request.QueryString("ID").ToString
        Me.InitScreen()
      Else
        'redirecciono a la pagina desde donde se llamo
        Response.Redirect(Request.UrlReferrer.ToString)
      End If
    End If
  End Sub

  Private Sub InitScreen()
    CargoRecuros("cboTipoEmpresa")
    CargoRecuros("cboEstadoEmpresa")

    'oculto los cotroles de la cabecera
    MostrarOcultar("cabecera", False)

    'busco la empresa si el id es <> ""
    Dim oDR As DataRow
    If IdEmpresa > 0 Then
      oDR = oEmpresa.Traer(IdEmpresa)
    End If

    If Not oDR Is Nothing Then
      'cargo los valores existentes
      Me.txtCuit.Text = Trim("" & oDR("cuit"))
      Me.txtRazonSocial.Text = Trim("" & oDR("razonSocial"))
      Me.txtDomicilio.Text = Trim("" & oDR("domicilio"))
      Me.txtTelefonos.Text = Trim("" & oDR("telefonos"))
      Me.cboTipoEmpresa.SelectedValue = oDR("tipoEmpresa")
      Me.cboEstadoEmpresa.SelectedValue = oDR("idEstadoEmpresa")
      'segun el tipo de la empresa obtengo los momentos y traigo la documentacion que NO presento todabia
      Dim oDT As DataTable = oEmpresa.ListarGrilla_DocumentacionPorEmpresa(IdEmpresa)
      With Me.oGrid
        .DataSource = oDT
        .DataBind()
      End With
    End If

  End Sub

  Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
    Dim oDoc As New Logica.cDocumento
    'Recorrer los items  de la grilla y verificar si estan o no seleccionados
    Dim i As Integer
    Dim ochk As CheckBox
    Dim iDoc As Integer
    Dim iEmp As Integer
    Dim imom As Integer
    Dim Presentado As Integer
    For i = 0 To oGrid.Items.Count - 1
      ochk = oGrid.Items(i).Cells(0).FindControl("chkRow")
      iDoc = oGrid.Items(i).Cells(1).Text
      iEmp = oGrid.Items(i).Cells(2).Text
      imom = oGrid.Items(i).Cells(3).Text

      If ochk.Checked Then
        Presentado = 1
      Else
        Presentado = 0
      End If
      'actualizo el doc
      oDoc.ActualizarDocumentacion(iEmp, iDoc, imom, Presentado)
    Next

    Response.Redirect("empresalista.aspx")
  End Sub

  Private Sub oGrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles oGrid.ItemDataBound
    'actualizo el check si esta presentado o no el documento
    Dim iPres As Integer
    Dim oChk As CheckBox
    'agrego el script a cada fila
    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
      'obtengo si esta presentado
      iPres = e.Item.Cells(4).Text
      'objtengo el chek
      oChk = e.Item.Cells(0).FindControl("chkRow")
      If iPres = 0 Then
        'coloco NO presentado 
        oChk.Checked = False
      Else
        'coloco SI presentado 
        oChk.Checked = True
      End If

    End If
  End Sub

  Private Sub CargoRecuros(ByVal selector As String)
    'cargo recursos selectivamente
    Select Case selector
        Case "cboTipoEmpresa"
          Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(oEmpresa.ListarCombo_TipoEmpresa())
          With Me.cboTipoEmpresa
            .DataValueField = "ID"
            .DataTextField = "DESCRIPCION"
            .DataSource = oDT
            .DataBind()
          End With

        Case "cboEstadoEmpresa"
          Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(oEmpresa.ListarCombo_EstadoEmpresa())
          With Me.cboEstadoEmpresa
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
      Case "CABECERA"
        'van siempre deshabilitados
        Me.txtCuit.Enabled = valor
        Me.txtRazonSocial.Enabled = valor
        Me.txtDomicilio.Enabled = valor
        Me.txtTelefonos.Enabled = valor
        Me.cboTipoEmpresa.Enabled = valor
        Me.cboEstadoEmpresa.Enabled = valor

    End Select
  End Sub


  Private Sub cmdVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
    Response.Redirect("empresalista.aspx")
  End Sub
End Class
