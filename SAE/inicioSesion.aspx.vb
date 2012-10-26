Public Class inicioSesion1
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

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

    'Verifico que los datos sean correctos
    Dim usuario As String = Request.Form("usuario")
    Dim pass As String = Request.Form("pass")

    If Logica.cUsuarioSae.CuentaValida(usuario, pass) Then
      Response.Redirect("empresalista.aspx", True)
    Else
      Response.Redirect("../msgGral.aspx?flag=N&msg=" & Server.UrlEncode("Error: en el inicio de sesion de usuario"))
    End If

  End Sub

End Class
