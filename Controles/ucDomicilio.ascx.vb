Public Class ucDomicilio
  Inherits System.Web.UI.UserControl

#Region " Código generado por el Diseñador de Web Forms "

  <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub

  Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
  Protected WithEvents txtcalle As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtnroCalle As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtletraBis As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtpiso As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtdepto As System.Web.UI.WebControls.TextBox
  Protected WithEvents txttelParticular As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtotrosTelefonos As System.Web.UI.WebControls.TextBox
  Protected WithEvents btnSave As System.Web.UI.WebControls.Button
  Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents txtpais As System.Web.UI.WebControls.DropDownList
  Protected WithEvents txtprovincia As System.Web.UI.WebControls.DropDownList
  Protected WithEvents txtlocalidad As System.Web.UI.WebControls.DropDownList
  Protected WithEvents RegularExpressionValidator15 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator2 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator3 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator4 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator5 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator6 As System.Web.UI.WebControls.RegularExpressionValidator
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    InitializeComponent()
  End Sub

#End Region

  Private m_idPostulante As Int32
  Private m_idDomicilio As Int32
  Private m_MODO As String

  Public Property MODO() As String
    Get
      Return m_MODO
    End Get
    Set(ByVal Value As String)
      m_MODO = Value
      ViewState("m_MODO") = Value
    End Set
  End Property

  Public Property idPostulante() As Int32
    Get
      Return Val(ViewState("m_idPostulante"))
    End Get
    Set(ByVal Value As Int32)
      m_idPostulante = Value
      ViewState("m_idPostulante") = Value
    End Set
  End Property
  Public Property idDomicilio() As Int32
    Get
      Return Val(ViewState("m_idDomicilio"))
    End Get
    Set(ByVal Value As Int32)
      m_idDomicilio = Value
      ViewState("m_idDomicilio") = Value
    End Set
  End Property

  Dim otbl_domicilios_x_postulante As New Logica.domicilios_x_postulante

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If Not Page.IsPostBack Then
      If Me.idPostulante > 0 AndAlso Me.idDomicilio > 0 Then
        otbl_domicilios_x_postulante.idPostulante = Me.idPostulante
        otbl_domicilios_x_postulante.idDomicilio = Me.idDomicilio
        If m_MODO = "V" Then
          Me.DisableControls()
        End If
      End If
      Me.InitScreen()
    End If

  End Sub

  Private Sub InitScreen()

    Me.CargoRecuros("txtpais")

    'busco si el id es <> ""
    Dim oDR As DataRow
    If Me.idPostulante > 0 AndAlso Me.idDomicilio > 0 Then
      oDR = otbl_domicilios_x_postulante.Traer(Me.idPostulante, Me.idDomicilio)
    End If

    If Not oDR Is Nothing Then
      'cargo los valores existentes
      'Me.txtdscDomicilio.Text = Trim("" & oDR("dscDomicilio"))
      Me.txtcalle.Text = Trim("" & oDR("calle"))
      Me.txtnroCalle.Text = Trim("" & oDR("nroCalle"))
      Me.txtletraBis.Text = Trim("" & oDR("letraBis"))
      Me.txtpiso.Text = Trim("" & oDR("piso"))
      Me.txtdepto.Text = Trim("" & oDR("depto"))
      Me.txtpais.SelectedValue = Trim("" & oDR("pais"))
      'si hay pais cargo las provincias para ese pais
            If Trim("" & oDR("pais")) <> "-1" Then
                Me.CargoRecuros("txtprovincia", Trim("" & oDR("pais")))
            End If
            Me.txtprovincia.SelectedValue = Trim("" & oDR("provincia"))
            'si hay provincias cargo las localidades
            If Trim("" & oDR("provincia")) <> "-1" Then
                Me.CargoRecuros("txtlocalidad", Trim("" & oDR("provincia")))
            End If
            Me.txtlocalidad.SelectedValue = Trim("" & oDR("localidad"))
            Me.txttelParticular.Text = Trim("" & oDR("telParticular"))
            Me.txtotrosTelefonos.Text = Trim("" & oDR("otrosTelefonos"))

        Else
        'precargo los valores para un registro nuevo
        '''Me.cboEstadotbl_domicilios_x_postulante.SelectedValue = Logica.estadotbl_domicilios_x_postulante.inicial
      End If
      'van siempre deshabilitados
      '''Me.cboEstadotbl_domicilios_x_postulante.Enabled = False
  End Sub

  Private Sub DisableControls()
    'desabilito los controles 
    'Me.txtdscDomicilio.Enabled = False
    Me.txtcalle.Enabled = False
    Me.txtnroCalle.Enabled = False
    Me.txtletraBis.Enabled = False
    Me.txtpiso.Enabled = False
    Me.txtdepto.Enabled = False
    Me.txtpais.Enabled = False
    Me.txtprovincia.Enabled = False
    Me.txtlocalidad.Enabled = False
    Me.txttelParticular.Enabled = False
    Me.txtotrosTelefonos.Enabled = False
  End Sub

  Public Function Guardar() As String
    Dim strPosibleError As String = ""

    otbl_domicilios_x_postulante.idPostulante = Me.idPostulante
    otbl_domicilios_x_postulante.idDomicilio = Me.idDomicilio

    'If Me.txtdscDomicilio.Text <> "" Then otbl_domicilios_x_postulante.dscDomicilio = Me.txtdscDomicilio.Text
    If Me.txtcalle.Text <> "" Then otbl_domicilios_x_postulante.calle = Me.txtcalle.Text
    If Me.txtnroCalle.Text <> "" Then otbl_domicilios_x_postulante.nroCalle = Me.txtnroCalle.Text
    If Me.txtletraBis.Text <> "" Then otbl_domicilios_x_postulante.letraBis = Me.txtletraBis.Text
    If Me.txtpiso.Text <> "" Then otbl_domicilios_x_postulante.piso = Me.txtpiso.Text
    If Me.txtdepto.Text <> "" Then otbl_domicilios_x_postulante.depto = Me.txtdepto.Text
        If Me.txtpais.SelectedValue <> "-1" Then otbl_domicilios_x_postulante.pais = Me.txtpais.SelectedValue
        If Me.txtprovincia.SelectedValue <> "-1" Then otbl_domicilios_x_postulante.provincia = Me.txtprovincia.SelectedValue
        If Me.txtlocalidad.SelectedValue <> "-1" Then otbl_domicilios_x_postulante.localidad = Me.txtlocalidad.SelectedValue
        If Me.txttelParticular.Text <> "" Then otbl_domicilios_x_postulante.telParticular = Me.txttelParticular.Text
        If Me.txtotrosTelefonos.Text <> "" Then otbl_domicilios_x_postulante.otrosTelefonos = Me.txtotrosTelefonos.Text

        If Me.idPostulante > 0 AndAlso Me.idDomicilio > 0 Then
            'Ya existe en la Base de datos
            'modifico los valores
            otbl_domicilios_x_postulante.Editar()
        Else
            'antes de agregar verifico si existe en la BD
            If Not IsNothing(otbl_domicilios_x_postulante.Traer(Me.idPostulante, Me.idDomicilio)) Then
                strPosibleError = "Ya existe una tbl_domicilios_x_postulante"
            Else
                'agrego el nuevo registro
                strPosibleError = otbl_domicilios_x_postulante.Agregar()
            End If
        End If

        If strPosibleError <> "" Then
            Return strPosibleError
        Else
            Return ""
        End If
  End Function

  Private Sub CargoRecuros(ByVal selector As String, Optional ByVal valorSincro As String = "")
    Dim oDT As DataTable
    Select Case selector
      Case "txtpais"
        oDT = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Pais)
        With Me.txtpais
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With

      Case "txtprovincia"
        oDT = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Provincia(valorSincro))
        With Me.txtprovincia
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With

      Case "txtlocalidad"
        oDT = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Localidad(valorSincro))
        With Me.txtlocalidad
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With
    End Select
  End Sub

  Private Sub txtpais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpais.SelectedIndexChanged
    'limpio combo de provincias y localidades
    Me.CargoRecuros("txtprovincia", Me.txtpais.SelectedItem.Value)
    Me.CargoRecuros("txtlocalidad", Me.txtprovincia.SelectedItem.Value)
  End Sub

  Private Sub txtprovincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprovincia.SelectedIndexChanged
    Me.CargoRecuros("txtlocalidad", Me.txtprovincia.SelectedItem.Value)
  End Sub
End Class