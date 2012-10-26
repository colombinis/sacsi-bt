Public Class ucLogin
    Inherits System.Web.UI.UserControl

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents txtUsuario As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
  Protected WithEvents cmdAceptar As System.Web.UI.WebControls.Button
  Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents lblError As System.Web.UI.WebControls.Label

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
    If Not IsPostBack Then

    End If
  End Sub

  Private Sub cmdAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
    VerificarLogueo()
  End Sub

  Private Sub VerificarLogueo()
    'verifico el logueo
    Dim strposibleError As String
    Dim strUsuario As String = txtUsuario.Text
    Dim strPass As String = txtPassword.Text
    Dim bolExistelocal As Boolean = False

    strposibleError = Logica.cUtil.LogOnSession(strUsuario, strPass, bolExistelocal)
    If strposibleError = "" Then
      'redirecciono a la pagina inicial
      Response.Redirect(Logica.cUtil.GetHttpAppRootPath)
    Else
      'hubo algun error en el logueo
      Me.lblError.Visible = True
      Me.lblError.Text = strposibleError
    End If
  End Sub

End Class
