Public Class EmpresaDetalle
  Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()

  End Sub

  Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
  Protected WithEvents txtID As System.Web.UI.WebControls.TextBox
  Protected WithEvents vldDescripcion As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents btnSave As System.Web.UI.WebControls.Button
  Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Requiredfieldvalidator4 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Requiredfieldvalidator6 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtCuit As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtRazonSocial As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtDomicilio As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtTelefonos As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtPaginaWeb As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtPersonaContacto As System.Web.UI.WebControls.TextBox
  Protected WithEvents cboTipoEmpresa As System.Web.UI.WebControls.DropDownList
  Protected WithEvents Requiredfieldvalidator7 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents cboEstadoEmpresa As System.Web.UI.WebControls.DropDownList
  Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    InitializeComponent()
  End Sub

#End Region

  Dim oEmpresa As New Logica.cEmpresa

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If Not Page.IsPostBack Then
      If Not Request.QueryString("ID") Is Nothing Then
        txtID.Text = Request.QueryString("ID")
        If Not Request.QueryString("Action") Is Nothing AndAlso _
               Request.QueryString("Action").ToString = "V" Then
          Me.DisableControls()
        End If
      End If
      Me.InitScreen()
    End If

  End Sub

  Private Sub InitScreen()
    CargoRecuros("cboTipoEmpresa")
    CargoRecuros("cboEstadoEmpresa")

    'busco la empresa si el id es <> ""
    Dim oDR As DataRow
    If txtID.Text <> "" Then
      oDR = oEmpresa.Traer(CType(txtID.Text, Integer))
    End If

    If Not oDR Is Nothing Then
      'cargo los valores existentes
      'Me.txtID.Text = "" & oDR("idEmpresa")
      Me.txtCuit.Text = Trim("" & oDR("cuit"))
            '''Me.txtCuit.Enabled = False
      Me.txtRazonSocial.Text = Trim("" & oDR("razonSocial"))
      Me.txtDomicilio.Text = Trim("" & oDR("domicilio"))
      Me.txtTelefonos.Text = Trim("" & oDR("telefonos"))
      Me.txtEmail.Text = Trim("" & oDR("email"))
      Me.txtPaginaWeb.Text = Trim("" & oDR("Web"))
      Me.txtPersonaContacto.Text = Trim("" & oDR("personaContacto"))
      'sincronizo los combos de tipo empresa y estado empresa
      Me.cboTipoEmpresa.SelectedValue = oDR("tipoEmpresa")
      Me.cboEstadoEmpresa.SelectedValue = oDR("idEstadoEmpresa")

    Else
      'precargo los valores para un registro nuevo
      Me.cboEstadoEmpresa.SelectedValue = Logica.estadoEmpresa.inicial
    End If
    'van siempre deshabilitados
    '''Me.cboEstadoEmpresa.Enabled = False
  End Sub

  Private Sub DisableControls()
    'desabilito los controles 
    Me.txtID.Enabled = False
    Me.txtCuit.Enabled = False
    Me.txtRazonSocial.Enabled = False
    Me.txtDomicilio.Enabled = False
    Me.txtTelefonos.Enabled = False
    Me.txtEmail.Enabled = False
    Me.txtPaginaWeb.Enabled = False
    Me.txtPersonaContacto.Enabled = False
    Me.cboTipoEmpresa.Enabled = False
    Me.cboEstadoEmpresa.Enabled = False
    btnSave.Enabled = False
  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    Dim strPosibleError As String = ""

    If Val(txtID.Text) > 0 Then
      'Ya existe en la Base de datos
      'modifico los valores
      oEmpresa.Editar(Val(txtID.Text), Me.txtCuit.Text, Me.txtRazonSocial.Text, Me.txtDomicilio.Text, Me.txtTelefonos.Text, Me.txtEmail.Text, Me.txtPaginaWeb.Text, Me.txtPersonaContacto.Text, Me.cboTipoEmpresa.SelectedItem.Value, Me.cboEstadoEmpresa.SelectedItem.Value)
    Else
      'antes de agregar verifico si existe en la BD
      If oEmpresa.Existe(Me.txtCuit.Text) = True Then
        strPosibleError = "Ya existe una Empresa con ese CUIT"
        Me.ColocarMensaje(strPosibleError)
      Else
        'agrego el nuevo registro
        strPosibleError = oEmpresa.Agregar(Me.txtCuit.Text, Me.txtRazonSocial.Text, Me.txtDomicilio.Text, Me.txtTelefonos.Text, Me.txtEmail.Text, Me.txtPaginaWeb.Text, Me.txtPersonaContacto.Text, Me.cboTipoEmpresa.SelectedItem.Value)
        If strPosibleError <> "" Then
          Me.ColocarMensaje("Error al agregar datos")
        End If
      End If
    End If

    'si todo esta ok regreso al listado
    If strPosibleError = "" Then Response.Redirect("EmpresaLista.aspx")
  End Sub

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    Response.Redirect("EmpresaLista.aspx")
  End Sub

  Private Sub CargoRecuros(ByVal selector As String)
    'cargo recursos selectivamente
    Select Case selector
      Case "cboTipoEmpresa"
        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(oEmpresa.ListarCombo_TipoEmpresa())
        With Me.cboTipoEmpresa
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With

      Case "cboEstadoEmpresa"
        Dim oDT As DataTable = oEmpresa.ListarCombo_EstadoEmpresa()
        With Me.cboEstadoEmpresa
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With
    End Select
  End Sub
  Private Sub ColocarMensaje(ByVal texto As String)
    'coloco el mensaje de error
    lblError.Text = texto
    lblError.Visible = True
  End Sub

End Class