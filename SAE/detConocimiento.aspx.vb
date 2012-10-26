Public Class detConocimiento
  Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

  <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

  End Sub

  Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
  Protected WithEvents txtidConocimiento As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqdscConocimiento As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtdscConocimiento As System.Web.UI.WebControls.TextBox
  Protected WithEvents btnSave As System.Web.UI.WebControls.Button
  Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    InitializeComponent()
  End Sub

#End Region

  Dim oCono As New Logica.cConocimiento

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If Not Page.IsPostBack Then
      If Not Request.QueryString("ID") Is Nothing Then
        ViewState("idclave") = Request.QueryString("ID").ToString
        oCono.idConocimiento = Val(ViewState("idclave"))
        If Not Request.QueryString("Action") Is Nothing AndAlso _
               Request.QueryString("Action").ToString = "V" Then
          Me.DisableControls()
        End If
      End If
      Me.InitScreen()
    End If

  End Sub

  Private Sub InitScreen()
    '''CargoRecuros("cboTipoCono")

    'busco si el id es <> ""
    Dim oDR As DataRow
    If ViewState("idclave") <> "" Then
      oDR = oCono.Traer(CType(ViewState("idclave"), Integer))
    End If

    If Not oDR Is Nothing Then
      'cargo los valores existentes
      Me.txtidConocimiento.Text = Trim("" & oDR("idConocimiento"))
      Me.txtdscConocimiento.Text = Trim("" & oDR("dscConocimiento"))

    Else
      'precargo los valores para un registro nuevo
      '''Me.cboEstadoCono.SelectedValue = Logica.estadoCono.inicial
    End If
    'van siempre deshabilitados
    '''Me.cboEstadoCono.Enabled = False
  End Sub

  Private Sub DisableControls()
    'desabilito los controles 
    Me.txtidConocimiento.Enabled = False
    Me.txtdscConocimiento.Enabled = False
    btnSave.Enabled = False
  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    Dim strPosibleError As String = ""
    If Me.txtidConocimiento.Text <> "" Then oCono.idConocimiento = Me.txtidConocimiento.Text
    If Me.txtdscConocimiento.Text <> "" Then oCono.dscConocimiento = Me.txtdscConocimiento.Text
    If oCono.idConocimiento > 0 Then
      'Ya existe en la Base de datos
      'modifico los valores
      oCono.Editar()
    Else
      'antes de agregar verifico si existe en la BD
      If oCono.Existe(oCono.dscConocimiento) Then
        strPosibleError = "Ya existe un conocimiento con esa descripcion"
        Me.ColocarMensaje(strPosibleError)
      Else
        'agrego el nuevo registro
        strPosibleError = oCono.Agregar()
        If strPosibleError <> "" Then
          Me.ColocarMensaje("Error al agregar datos")
        End If
      End If
    End If

    'si todo esta ok regreso al listado
    If strPosibleError = "" Then Response.Redirect("lstConocimientos.aspx")
  End Sub

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    Response.Redirect("lstConocimientos.aspx")
  End Sub

  Private Sub CargoRecuros(ByVal selector As String)
    ''''cargo recursos selectivamente
    '''Select Case selector
    '''  Case "cboTipoCono"
    '''    Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(oCono.ListarCombo_TipoCono())
    '''    With Me.cboTipoCono
    '''      .DataValueField = "ID"
    '''      .DataTextField = "DESCRIPCION"
    '''      .DataSource = oDT
    '''      .DataBind()
    '''    End With
    '''End Select
  End Sub
  Private Sub ColocarMensaje(ByVal texto As String)
    'coloco el mensaje de error
    lblError.Text = texto
    lblError.Visible = True
  End Sub
End Class