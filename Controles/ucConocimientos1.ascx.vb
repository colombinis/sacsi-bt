Public Class ucConocimientos1
    Inherits System.Web.UI.UserControl

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents cboConocimiento As System.Web.UI.WebControls.DropDownList
  Protected WithEvents cboValor As System.Web.UI.WebControls.DropDownList
  Protected WithEvents cmdAgregarConocimiento As System.Web.UI.WebControls.Button
  Protected WithEvents oGrid As System.Web.UI.WebControls.DataGrid

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

  Public Event Update(ByVal strPosibleError As String, ByVal strConocimientos As String)
  Public Event Delete(ByVal strPosibleError As String, ByVal strConocimientos As String)

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'Introducir aquí el código de usuario para inicializar la página
    If Not IsPostBack Then
      InitScreen()
    End If
  End Sub

  Private Sub cmdAgregarConocimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregarConocimiento.Click
    Dim strError As String
    Dim strValor As String
    'NOTA: strValor debe ser una cadena de la forma : "Conocimiento,Valor"

    If Me.cboConocimiento.SelectedItem.Value = "-1" Then
      strError = "Debe seleccionar un conocimiento"
    End If
    strValor = Me.cboConocimiento.SelectedItem.Value & "," & Me.cboValor.SelectedItem.Value
    RaiseEvent Update(strError, strValor)

  End Sub

  Private Sub InitScreen()

    CargoRecuros("cboConocimiento")
  End Sub

  Private Sub CargoRecuros(ByVal selector As String)
    'cargo recursos selectivamente
    Select Case selector
      Case "cboConocimiento"
        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Conocimientos)
        With Me.cboConocimiento
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With
    End Select
  End Sub

  Private Sub oGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles oGrid.ItemCommand
    'al hacer clic en la imagen de la columna
    Dim strError As String
    Dim strValor As String

    Select Case e.CommandName.ToUpper

      Case "DELETE"
        'NOTA: strValor debe ser una cadena de la forma : "Conocimiento,Valor"
        strValor = oGrid.Items(e.Item.ItemIndex).Cells(0).Text & "," & oGrid.Items(e.Item.ItemIndex).Cells(2).Text
        RaiseEvent Delete(strError, strValor)
    End Select

  End Sub

  Public Sub InicializarConocimientos(ByVal oDT As DataTable)
    oGrid.DataSource = oDT
    oGrid.DataBind()
  End Sub
End Class
