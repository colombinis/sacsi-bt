Public Class msgGral
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If Not IsPostBack Then
      'Verifico si tengo los parametros en el Querystring
      If Not Request.QueryString("msg") Is Nothing AndAlso Not Request.QueryString("flag") Is Nothing Then
        ColocarMensaje(Server.HtmlDecode(Request.QueryString("msg")), Request.QueryString("flag"))
      Else
        ColocarMensaje("Parametros incorrectos de llamado a funcion", "N")
      End If
    End If
  End Sub
  Private Sub ColocarMensaje(ByVal Mensaje As String, ByVal tipoMSg As String)
    Select Case tipoMSg
      Case "Y"
        'Mensaje normal
        Me.lblMensaje.ForeColor = Color.Black
        Me.lblMensaje.CssClass = "finalLog"
      Case "N"
        'Mensaje de error
        Me.lblMensaje.ForeColor = Color.Red
        Me.lblMensaje.CssClass = "errorBox"
    End Select

    Me.lblMensaje.Text = Mensaje
  End Sub
End Class
