Imports ProxyServer

Public Class inicioSesion
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
        Dim bolExisteLocal As Boolean = True
        Dim usuario As String = Request.Form("usuario")
        Dim pass As String = Request.Form("pass")

        Try
            'Verifico que los datos sean correctos en el email
            Dim mSer As mServer
            Dim strServidor As String = Logica.cUtil.getServidorPOP()
            Dim intPuertoPOP As Integer = Logica.cUtil.getPuertoPOP()
            Dim strSocketError As String
            Dim usuarioValido As Boolean = False
            mSer = New mServer
            mSer.Nuevo(strServidor, intPuertoPOP)
      usuarioValido = mSer.CuentaValida(usuario, pass, strSocketError)

            If Not usuarioValido Then
                '''Response.Redirect("../msgGral.aspx?flag=N&msg=" & Server.UrlEncode("Error: en el inicio de sesion de usuario"), False)
                Throw New Exception("Error: en el inicio de sesion de usuario")
            Else
                Dim strPosibleError As String = Logica.cUtil.LogOnSession(usuario, pass, bolExisteLocal)
                If strPosibleError = "" Then
                    'verifico si existe en la base de datos local
                    If bolExisteLocal Then
                        'redirecciono a la pagina inicio
                        Response.Redirect("~/postulante/lstBPost.aspx", False)
                    Else
                        'NO existe localmente. Lo redirecciono para que complete sus datos
                        Response.Redirect("~/postulante/lstBPost.aspx", False)
                    End If
                Else
                    'mensaje de error
                    '''Response.Redirect("msgGral.aspx?flag=N&msg=" & Server.UrlEncode(strPosibleError))
                    Throw New Exception(strPosibleError)
                End If
            End If
        Catch ex As Exception
      'Logica.cUtil.XML_Logerror("Error", Server.HtmlEncode(ex.Message))
            Response.Redirect("msgGral.aspx?flag=N&msg=" & Server.UrlEncode("Error: en el inicio de sesion de usuario"), False)
        End Try
    End Sub

End Class
