Public Class inicioSesion1
    Inherits System.Web.UI.Page

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTA: el Dise�ador de Web Forms necesita la siguiente declaraci�n del marcador de posici�n.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
        'No la modifique con el editor de c�digo.
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
