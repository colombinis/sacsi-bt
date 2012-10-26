Public Class detDatosP
  Inherits System.Web.UI.Page
  Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
  
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents cmdRevisado As System.Web.UI.WebControls.Button
  Protected WithEvents cmdvolver As System.Web.UI.WebControls.Button
  Protected WithEvents UcDatosPost1 As ucDatosPost

  Private Sub InitializeComponent()

  End Sub

  Private Sub UcDatosPost1_OcurioError(ByVal codError As Integer, ByVal strMsgError As String) Handles UcDatosPost1.OcurioError
    'si ocurre algun error lo muestro
    Me.ColocarMensaje(strMsgError)
  End Sub

  Private Sub ColocarMensaje(ByVal texto As String)
    Me.lblError.Text = texto
    Me.lblError.Visible = True

  End Sub

  Private Sub cmdvolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdvolver.Click
    'Vuelvo a mostrar el listado de postulantes
    Response.Redirect("lstdatosp.aspx")
  End Sub

  Private Sub cmdRevisado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRevisado.Click
    'Actualizar fecha de revision
    otbl_postulante.ActualizarFechaRevision(ViewState("idPostulante"))
  End Sub

  Dim otbl_postulante As New Logica.tbl_postulante
  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Not IsPostBack Then
      If Not IsNothing(Request.QueryString("ID")) Then
        ViewState("idPostulante") = Request.QueryString("ID").ToString
      End If
    End If

  End Sub
End Class