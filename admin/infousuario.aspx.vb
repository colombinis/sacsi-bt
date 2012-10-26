Public Class infousuario
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents lblInfo As System.Web.UI.WebControls.Label

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
    'Introducir aquí el código de usuario para inicializar la página
    PrepararPagina()
    End Sub

  Private Sub PrepararPagina()
    'Recolecto info del usuario
    Dim strInfo As New System.Text.StringBuilder
    strInfo.Append("User.Identity.Name: " & User.Identity.Name)
    strInfo.Append("</br>")
    strInfo.Append("User.Identity.IsAuthenticated: " & User.Identity.IsAuthenticated)
    strInfo.Append("</br>")
    strInfo.Append("User.Identity.AuthenticationType: " & User.Identity.AuthenticationType)
    strInfo.Append("</br>")
    strInfo.Append("Corre como " & System.Security.Principal.WindowsIdentity.GetCurrent.Name)
    strInfo.Append("</br>")
    strInfo.Append("IsAuthenticated " & System.Security.Principal.WindowsIdentity.GetCurrent.IsAuthenticated)
    strInfo.Append("</br>")
    strInfo.Append("AuthenticationType " & System.Security.Principal.WindowsIdentity.GetCurrent.AuthenticationType)
    'muestro la info
    Me.lblInfo.Text = strInfo.ToString
  End Sub
End Class
