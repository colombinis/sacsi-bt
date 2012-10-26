Public Class ucConocimientos
    Inherits System.Web.UI.UserControl

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
    Protected WithEvents txtPrecarga As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtSalida As System.Web.UI.HtmlControls.HtmlInputHidden
  Protected WithEvents contenido As System.Web.UI.WebControls.Table
  Protected WithEvents cmdRec As System.Web.UI.HtmlControls.HtmlInputButton

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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
    If Not IsPostBack Then

      'NOTA: los combos no los levanto de la base de datos los tengo "hardcodeados en el html" 
    End If

    End Sub

  Private Sub cmdRec_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRec.ServerClick
    If Me.txtSalida.Value <> "" Then
      RaiseEvent Update("", Me.txtSalida.Value)
    End If
  End Sub

  Public Sub InicializarConocimientos(ByVal cadenaInicial As String)
    Me.txtPrecarga.Value = cadenaInicial
  End Sub
End Class
