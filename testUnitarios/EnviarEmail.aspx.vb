Imports bolsatrabajo.Logica.cUtil
Imports System.Diagnostics
Imports System.IO
Imports System.Web.Mail

Public Class EnviarEmail
    Inherits System.Web.UI.Page

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents chkIncluirAtach As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents txtDe As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPara As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAsunto As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMensaje As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblLog As System.Web.UI.WebControls.Label

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
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
    End Sub

    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        'objetivo: Porceso de envio por email de los CVs comprimidos en un .zip
        'in
        '
        'out
        ' "" si todo ok, o el error.
        Dim strPosibleError As String = ""

        Try
Logica.cUtil.XML_LogGenerico("cmdEnviar_Click", "Inicio")

            Dim strPathPublico As String = Server.MapPath(Logica.cUtil.GetAppRootPath & "/" & System.Configuration.ConfigurationSettings.AppSettings("Carpeta_CV").ToString())
            Dim strPathCarpeta As String = System.Configuration.ConfigurationSettings.AppSettings("Carpeta_ZIP").ToString() ' debe concidir con el que esta en el bat
            Dim oD As Directory
            Dim [oF] As File

Logica.cUtil.XML_LogGenerico("cmdEnviar_Click", "antes del Dim msg As New MailMessage")

            Dim msg As New MailMessage
            Dim oAttach As Mail.MailAttachment
            msg.From = Trim(Me.txtDe.Text)
            msg.To = Trim(Me.txtPara.Text)
            msg.Subject = Trim(Me.txtAsunto.Text)
            msg.BodyFormat = MailFormat.Html
            msg.Body = Trim(Me.txtMensaje.Text)

            If Me.chkIncluirAtach.Checked = True Then
                oAttach = New Mail.MailAttachment(strPathPublico & strPathCarpeta & ".zip")
                msg.Attachments.Add(oAttach)
            End If

            SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings("ServidorPOP").ToString()
Logica.cUtil.XML_LogGenerico("cmdEnviar_Click", "antes del SmtpMail.Send(msg)")
            SmtpMail.Send(msg)
            msg = Nothing
            oAttach = Nothing

Logica.cUtil.XML_LogGenerico("cmdEnviar_Click", "Final")

        strPosibleError = "Se ha enviado correctamente"
        Catch ex As Exception
            Logica.cUtil.XML_LogGenerico("ProcesoEnvio", "Error: en el proceso de envio por correo. " & ex.Message)
            strPosibleError = "Error: en el proceso de envio por correo. " & ex.Message

        Finally
            Me.lblLog.Text = strPosibleError
        End Try

    End Sub
End Class
