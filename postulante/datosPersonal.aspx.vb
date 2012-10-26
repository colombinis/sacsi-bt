Public Class datosPersonal
  Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

  <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

  End Sub

  Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents UcDatosPost1 As ucDatosPost

  Private designerPlaceholderDeclaration As System.Object

  
#End Region

  Private Sub UcDatosPost1_OcurioError(ByVal codError As Integer, ByVal strMsgError As String) Handles UcDatosPost1.OcurioError
    'si ocurre algun error lo muestro
    Me.ColocarMensaje(codError, strMsgError)
  End Sub

  Private Sub ColocarMensaje(ByVal codError As Integer, ByVal texto As String)
    'in
    ' codError: 0= mensaje, 1 error
    If codError = 0 Then
      lblError.CssClass = "finalLog"
    Else
      lblError.CssClass = "errorBox"
    End If
    Me.lblError.Text = texto
    Me.lblError.Visible = True

  End Sub
End Class