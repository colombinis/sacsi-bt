Public Class mUpF
  Inherits System.Web.UI.Page

#Region " C�digo generado por el Dise�ador de Web Forms "

  'El Dise�ador de Web Forms requiere esta llamada.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents file As System.Web.UI.HtmlControls.HtmlInputFile
  Protected WithEvents cmdGuardar As System.Web.UI.WebControls.Button

  'NOTA: el Dise�ador de Web Forms necesita la siguiente declaraci�n del marcador de posici�n.
  'No se debe eliminar o mover.
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
    'No la modifique con el editor de c�digo.
    InitializeComponent()
  End Sub

#End Region

  Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
    Dim pathFile As String = "c:\Inetpub\wwwroot\bolsaTrabajo\public\"
    Try
      If Not IsNothing(Me.file.PostedFile) Then
        Dim iComienzo As Integer = file.PostedFile.FileName.LastIndexOf("\")
        Dim strNombre As String = file.PostedFile.FileName.Remove(0, iComienzo + 1)

        file.PostedFile.SaveAs(pathFile & strNombre)

      End If
    Catch ex As Exception
      Stop
    End Try
  End Sub
End Class
