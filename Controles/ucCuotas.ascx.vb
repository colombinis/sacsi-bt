Public Class ucCuotas
    Inherits System.Web.UI.UserControl

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cmdRec As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents txtSalida As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents contenido As System.Web.UI.WebControls.Table
    Protected WithEvents txtPrecarga As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Public Event Update(ByVal strPosibleError As String, ByVal strFechasSalida As String)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
    End Sub

  Private Sub cmdRec_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRec.ServerClick
        'objetivo: valida en el cliente y en caso de estar correcto genera un string con el siguiente formato
        'dd/MM/yyyy¦valor|  ej: '01/01/2006¦15.23|01/02/2006¦40.23'
    If Me.txtSalida.Value <> "" Then
            RaiseEvent Update("", Me.txtSalida.Value)
    End If
  End Sub

  Public Sub InicializarFechas(ByVal cadenaInicial As String)
    Me.txtPrecarga.Value = cadenaInicial
  End Sub
End Class
