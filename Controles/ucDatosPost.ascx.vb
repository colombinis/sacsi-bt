Imports bolsatrabajo.Logica

Public Class ucDatosPost
  Inherits System.Web.UI.UserControl

#Region " C�digo generado por el Dise�ador de Web Forms "

  <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

  End Sub

  Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
  Protected WithEvents txtidPostulante As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtfechaAltaSistema As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtemail As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqnroDoc As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtnroDoc As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqapellido As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtapellido As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtfechaNacimiento As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtcantMateriasAprobadas As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtplanEspecialidad As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtpromConAplazos As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtpromSinAplazos As System.Web.UI.WebControls.TextBox
  Protected WithEvents txttituloUniversitario As System.Web.UI.WebControls.TextBox
  Protected WithEvents txttitulosecundario As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtotrosComentarios As System.Web.UI.WebControls.TextBox
  Protected WithEvents btnSave As System.Web.UI.WebControls.Button
  Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents cboTipoDoc As System.Web.UI.WebControls.DropDownList
  Protected WithEvents cboEspecialidad As System.Web.UI.WebControls.DropDownList

  Protected WithEvents btnModificarConocimientos As System.Web.UI.WebControls.Button
  Protected WithEvents reqemail As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtarchivoCV As System.Web.UI.HtmlControls.HtmlInputFile
  Protected WithEvents txtUsuario As System.Web.UI.WebControls.TextBox

  Protected WithEvents UcConocimientos11 As ucConocimientos1
  Protected WithEvents ucPostulaciones1 As ucPostulaciones

  Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtValorTab As System.Web.UI.HtmlControls.HtmlInputHidden
  Protected WithEvents linkCV As System.Web.UI.WebControls.HyperLink
  Protected WithEvents regTipoDoc As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents reqCantMateriasAprobadas As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Requiredfieldvalidator4 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Requiredfieldvalidator5 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Requiredfieldvalidator6 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents Requiredfieldvalidator7 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator2 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator5 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator7 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator9 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator10 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator11 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator12 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator14 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator15 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator16 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator17 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents RegularExpressionValidator18 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
  Protected WithEvents reqEstadoCivil As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents cboEstadoCivil As System.Web.UI.WebControls.DropDownList
  Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents cboSexo As System.Web.UI.WebControls.DropDownList
  Protected WithEvents RegularExpressionValidator8 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents txtnroCuil As System.Web.UI.WebControls.TextBox
  Protected WithEvents RegularExpressionValidator3 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents txtemailAlternativo As System.Web.UI.WebControls.TextBox
  Protected WithEvents RegularExpressionValidator6 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents reqnombres As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtnombres As System.Web.UI.WebControls.TextBox
  Protected WithEvents RegularExpressionValidator4 As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents reqnroLegajo As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtnroLegajo As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtanioCursa As System.Web.UI.WebControls.DropDownList
  Protected WithEvents txtturnoCursa As System.Web.UI.WebControls.DropDownList
  Protected WithEvents ucDomicilioActual As ucDomicilio
  Protected WithEvents ucDomicilioFamiliar As ucDomicilio

  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    InitializeComponent()
  End Sub

#End Region

  Public Event OcurioError(ByVal codError As Integer, ByVal strMsgError As String)

  Dim otbl_postulante As New Logica.tbl_postulante
  Dim oCono As New Logica.tbl_conocimiento_x_postulante

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Try

      If Not Page.IsPostBack Then
        'verifico si ingreso por administracion SAE
        'verifico en que pagina esta contenido el control
        Dim strRutaPadre As String = Page.TemplateSourceDirectory()
        Dim DirPadre As String
        DirPadre = strRutaPadre.Substring(strRutaPadre.LastIndexOf("/") + 1, strRutaPadre.Length - 1 - strRutaPadre.LastIndexOf("/"))
                Select Case DirPadre.ToUpper
                    Case "SAE"
                        ViewState("ENTROPOR") = "SAE"
                        'el txtusuario lo tengo que habilitar, solo si viene por sae.
                        Me.txtUsuario.ReadOnly = False

                        'verifico si viene por un postulante en particular
                        If Not Request.QueryString("ID") Is Nothing Then
                            ViewState("idPostulante") = Request.QueryString("ID").ToString
                        Else
                            ViewState("idPostulante") = ""
                        End If

                        otbl_postulante.idPostulante = Val(ViewState("idPostulante"))
                        Me.txtidPostulante.Text = Val(ViewState("idPostulante"))
                        If Not Request.QueryString("Action") Is Nothing AndAlso _
                               Request.QueryString("Action").ToString = "V" Then
                            Me.ucDomicilioActual.MODO = "V"
                            Me.ucDomicilioFamiliar.MODO = "V"
                            Me.DisableControls()
                        End If

                    Case "POSTULANTE"
                        ViewState("ENTROPOR") = "POSTULANTE"

                        'verifico si estan las variables de sesion
                        If Not Logica.cUtil.varSession(Logica.cUtil.userSession.UserLogonID) Is Nothing AndAlso Val(Logica.cUtil.varSession(Logica.cUtil.userSession.UserLogonID)) > 0 Then
                            ViewState("idPostulante") = Logica.cUtil.varSession(Logica.cUtil.userSession.UserLogonID).ToString
                            otbl_postulante.usuario = Logica.cUtil.varSession(Logica.cUtil.userSession.UserLogonName).ToString
                            otbl_postulante.idPostulante = Val(ViewState("idPostulante"))
                            Me.txtidPostulante.Text = Val(ViewState("idPostulante"))
                        Else
                            Throw New Exception("Datos de la sesion no se pudieron recuperar.")
                        End If

                    Case Else
                        'no se sabe por donde ingreso a la pagina tendria que redireccionar
                        Throw New Exception("No se pudo recuperar los datos de origen, al ingresar a esta seccion. DirPadre :" & DirPadre)
                End Select
                Me.InitScreen()
            End If
    Catch ex As Exception
      'logear el error y mostrar el mensaje
      Logica.cUtil.XML_Logerror("Error ucDatosPost - load:", ex.Message)
      'mensaje de error
      Response.Redirect("../msgGral.aspx?flag=N&msg=" & Server.UrlEncode("No se pudo establecer el origen de la solicitud"))
    End Try

  End Sub

  Private Sub InitScreen()
    'agrego las propieades a los ucDomicilios
    Me.ucDomicilioFamiliar.idDomicilio = Logica.tipoDomicilio.DomicilioFamiliar
    Me.ucDomicilioFamiliar.idPostulante = Val(ViewState("idPostulante"))
    Me.ucDomicilioActual.idDomicilio = Logica.tipoDomicilio.DomicilioActual
    Me.ucDomicilioActual.idPostulante = Val(ViewState("idPostulante"))
    oCono.idPostulante = Val(ViewState("idPostulante"))

    CargoRecuros("cboEspecialidad")
    CargoRecuros("cboTipoDoc")
    'cargo la grilla de conocimientos
    Me.CargoRecuros("UcConocimientos11")
    'Cargo las lista de las postulaciones
    Me.CargoRecuros("ucPostulaciones1")


    'busco si el id es <> ""
    Dim oDR As DataRow
    If Val(ViewState("idPostulante")) > 0 Then
      oDR = otbl_postulante.Traer(Val(ViewState("idPostulante")))
    End If

    If Not oDR Is Nothing Then
      'cargo los valores existentes
      Me.txtidPostulante.Text = Trim("" & oDR("idPostulante"))
      Me.txtUsuario.Text = Trim("" & oDR("usuario"))
      Me.txtfechaAltaSistema.Text = Trim("" & oDR("fechaAltaSistema"))
      Me.txtemail.Text = Trim("" & oDR("email"))
      Me.txtnroLegajo.Text = Trim("" & oDR("nroLegajo"))
      Me.cboTipoDoc.SelectedValue = Trim("" & oDR("tipoDoc"))
      Me.txtnroDoc.Text = Trim("" & oDR("nroDoc"))
      Me.txtapellido.Text = Trim("" & oDR("apellido"))
      Me.txtnombres.Text = Trim("" & oDR("nombres"))
      Me.txtnroCuil.Text = Trim("" & oDR("nroCuil"))
      Me.txtfechaNacimiento.Text = Trim("" & oDR("fechaNacimiento"))
      Me.cboTipoDoc.SelectedValue = Trim("" & oDR("tipodoc"))
      Me.cboSexo.SelectedValue = Trim("" & oDR("sexo"))
      'Me.txtfecUltMateriaAprobada.Text = Trim("" & oDR("fecUltMateriaAprobada"))
      'Me.txtdscUltMateriaAprobada.Text = Trim("" & oDR("dscUltMateriaAprobada"))
      Me.cboEspecialidad.SelectedValue = Trim("" & oDR("idEspecialidad"))
      Me.txtcantMateriasAprobadas.Text = Trim("" & oDR("cantMateriasAprobadas"))
      Me.txtplanEspecialidad.Text = Trim("" & oDR("planEspecialidad"))
      Me.txtanioCursa.SelectedValue = Trim("" & oDR("anioCursa"))
      Me.txtturnoCursa.SelectedValue = Trim("" & oDR("turnoCursa"))
      Me.txtpromConAplazos.Text = Trim("" & oDR("promConAplazos"))
      Me.txtpromSinAplazos.Text = Trim("" & oDR("promSinAplazos"))
      'Me.txtmatRegExamenPend.Text = Trim("" & oDR("matRegExamenPend"))
      Me.txttituloUniversitario.Text = Trim("" & oDR("tituloUniversitario"))
      Me.txttitulosecundario.Text = Trim("" & oDR("titulosecundario"))
      '''Me.txtarchivoFoto.Value = Trim("" & oDR("archivoFoto"))
      '''Me.txtarchivoCV.Value = Trim("" & oDR("archivoCV"))
      Dim strValorlink As String = Trim("" & oDR("archivoCV"))
      Me.ViewState("NOMBREARCHIVOCV") = strValorlink ' guardo el nombre del archivo, porque si lo actualiza a este lo tengo que eliminar
      If strValorlink = "" Then
        Me.linkCV.Visible = False
        Me.linkCV.ToolTip = ""
      Else
        Me.linkCV.Visible = True
        Me.linkCV.NavigateUrl = Logica.cUtil.GetHttpAppRootPath & System.Configuration.ConfigurationSettings.AppSettings("Carpeta_CV") & strValorlink
        Me.linkCV.ToolTip = strValorlink
      End If

      Me.txtotrosComentarios.Text = Trim("" & oDR("otrosComentarios"))
      Me.txtemailAlternativo.Text = Trim("" & oDR("emailAlternativo"))
      Me.cboEstadoCivil.SelectedValue = Trim("" & oDR("estadoCivil"))
    Else
      'precargo los valores para un registro nuevo
      '''Me.cboEstadotbl_postulante.SelectedValue = Logica.estadotbl_postulante.inicial
    End If
    'NOTA: tener en cuenta los controles que van siempre solo lectura
  End Sub

  Private Sub DisableControls()
    'desabilito los controles 
    Me.txtidPostulante.Enabled = False
    Me.txtUsuario.Enabled = False
    Me.txtfechaAltaSistema.Enabled = False
    Me.txtemail.Enabled = False
    Me.txtnroLegajo.Enabled = False
    Me.cboTipoDoc.Enabled = False
    Me.txtnroDoc.Enabled = False
    Me.txtapellido.Enabled = False
    Me.txtnombres.Enabled = False
    Me.txtnroCuil.Enabled = False
    Me.txtfechaNacimiento.Enabled = False
    Me.cboSexo.Enabled = False
    'Me.txtfecUltMateriaAprobada.Enabled = False
    'Me.txtdscUltMateriaAprobada.Enabled = False
    Me.cboEspecialidad.Enabled = False
    Me.txtcantMateriasAprobadas.Enabled = False
    Me.txtplanEspecialidad.Enabled = False
    Me.txtanioCursa.Enabled = False
    Me.txtturnoCursa.Enabled = False
    Me.txtpromConAplazos.Enabled = False
    Me.txtpromSinAplazos.Enabled = False
    'Me.txtmatRegExamenPend.Enabled = False
    Me.txttituloUniversitario.Enabled = False
    Me.txttitulosecundario.Enabled = False
    '''Me.txtarchivoFoto.Disabled = False
    Me.txtarchivoCV.Disabled = False
    Me.txtotrosComentarios.Enabled = False
    Me.txtemailAlternativo.Enabled = False
    Me.cboEstadoCivil.Enabled = False

    btnSave.Enabled = False
  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    Dim strPosibleError As String = ""
    Dim nombreArchiCV As String = ""
    Try
      '''''''''VALIDACIONES del lado del servidor

      If Me.txtpromConAplazos.Text <> "" Then
        Dim promcon As Decimal = Convert.ToDecimal(Me.txtpromConAplazos.Text.Replace(".", ","))
        If Not (0 <= promcon AndAlso promcon <= 10) Then
          Throw New Exception("El promedio con aplazos deberia ser un numero entre 0 y 10")
        End If
      End If

      If Me.txtpromSinAplazos.Text <> "" Then
        Dim prom As Decimal = Convert.ToDecimal(Me.txtpromSinAplazos.Text.Replace(".", ","))
        If Not (0 <= prom AndAlso prom <= 10) Then
          Throw New Exception("El promedio sin aplazos deberia ser un numero entre 0 y 10")
        End If
      End If


      'If Me.txtfechaAltaSistema.Text <> "" Then otbl_postulante.fechaAltaSistema = Me.txtfechaAltaSistema.Text
      If Me.txtUsuario.Text <> "" Then otbl_postulante.usuario = Me.txtUsuario.Text
      If Me.txtemail.Text <> "" Then otbl_postulante.email = Me.txtemail.Text
      If Me.txtnroLegajo.Text <> "" Then otbl_postulante.nroLegajo = Me.txtnroLegajo.Text
      If Me.cboTipoDoc.SelectedValue <> -1 Then otbl_postulante.tipoDoc = Me.cboTipoDoc.SelectedValue
      If Me.txtnroDoc.Text <> "" Then otbl_postulante.nroDoc = Me.txtnroDoc.Text
      If Me.txtapellido.Text <> "" Then otbl_postulante.apellido = Me.txtapellido.Text
      If Me.txtnombres.Text <> "" Then otbl_postulante.nombres = Me.txtnombres.Text
      If Me.txtnroCuil.Text <> "" Then otbl_postulante.nroCuil = Me.txtnroCuil.Text
      If Me.txtfechaNacimiento.Text <> "" Then otbl_postulante.fechaNacimiento = Me.txtfechaNacimiento.Text
      If Me.cboSexo.SelectedValue <> -1 Then otbl_postulante.sexo = Me.cboSexo.SelectedValue

      'siempre son fijos
      otbl_postulante.idDomicilioFamiliar = Logica.tipoDomicilio.DomicilioFamiliar
      otbl_postulante.idDomicilioActual = Logica.tipoDomicilio.DomicilioActual

      'If Me.txtfecUltMateriaAprobada.Text <> "" Then otbl_postulante.fecUltMateriaAprobada = Me.txtfecUltMateriaAprobada.Text
      'If Me.txtdscUltMateriaAprobada.Text <> "" Then otbl_postulante.dscUltMateriaAprobada = Me.txtdscUltMateriaAprobada.Text
      If Me.cboEspecialidad.SelectedValue <> -1 Then otbl_postulante.idEspecialidad = Me.cboEspecialidad.SelectedValue
      If Me.txtcantMateriasAprobadas.Text <> "" Then otbl_postulante.cantMateriasAprobadas = Me.txtcantMateriasAprobadas.Text
      If Me.txtplanEspecialidad.Text <> "" Then otbl_postulante.planEspecialidad = Me.txtplanEspecialidad.Text
      If Me.txtanioCursa.SelectedValue <> "-1" Then otbl_postulante.anioCursa = Me.txtanioCursa.SelectedValue
      If Me.txtturnoCursa.SelectedValue <> "-1" Then otbl_postulante.turnoCursa = Me.txtturnoCursa.SelectedValue
      If Me.txtpromConAplazos.Text <> "" Then otbl_postulante.promConAplazos = Convert.ToDecimal(Me.txtpromConAplazos.Text.Replace(".", ","))
      If Me.txtpromSinAplazos.Text <> "" Then otbl_postulante.promSinAplazos = Convert.ToDecimal(Me.txtpromSinAplazos.Text.Replace(".", ","))
      'If Me.txtmatRegExamenPend.Text <> "" Then otbl_postulante.matRegExamenPend = Me.txtmatRegExamenPend.Text
      If Me.txttituloUniversitario.Text <> "" Then otbl_postulante.tituloUniversitario = Me.txttituloUniversitario.Text
      If Me.txttitulosecundario.Text <> "" Then otbl_postulante.titulosecundario = Me.txttitulosecundario.Text

      If Me.txtemailAlternativo.Text <> "" Then otbl_postulante.emailalternativo = Me.txtemailAlternativo.Text
      If Me.cboEstadoCivil.SelectedValue <> -1 Then otbl_postulante.estadoCivil = Me.cboEstadoCivil.SelectedValue

      'guardo el CV y obtengo el nombre generado del archivo
      nombreArchiCV = guardarCV(otbl_postulante.nroLegajo, Me.ViewState("NOMBREARCHIVOCV"))
      otbl_postulante.archivoCV = nombreArchiCV
      'actualizo el link para verlo
      If nombreArchiCV = "" Then
        Me.linkCV.Visible = False
        Me.linkCV.ToolTip = ""
      Else
        Me.linkCV.Visible = True
        Me.linkCV.NavigateUrl = Logica.cUtil.GetHttpAppRootPath & System.Configuration.ConfigurationSettings.AppSettings("Carpeta_CV") & nombreArchiCV
        Me.linkCV.ToolTip = nombreArchiCV
      End If

      '''If Me.txtarchivoFoto.Value <> "" Then otbl_postulante.archivoFoto = Me.txtarchivoFoto.Value
      If Me.txtotrosComentarios.Text <> "" Then otbl_postulante.otrosComentarios = Me.txtotrosComentarios.Text

      If Val(ViewState("idPostulante")) > 0 Then
        'Ya existe en la Base de datos
        otbl_postulante.idPostulante = Val(ViewState("idPostulante"))
        'modifico los valores
        otbl_postulante.Editar()
      Else
        'agrego el nuevo registro
        strPosibleError = otbl_postulante.Agregar()
        'recupero el IDPostulante generado y se los paso a los controles 
        ViewState("idPostulante") = otbl_postulante.idPostulante
        Me.ucDomicilioActual.idPostulante = Val(ViewState("idPostulante"))
        Me.ucDomicilioFamiliar.idPostulante = Val(ViewState("idPostulante"))
      End If

      'Agrego el domicilio Familiar y el actual
      If strPosibleError = "" Then strPosibleError = Me.ucDomicilioFamiliar.Guardar
      If strPosibleError = "" Then strPosibleError = Me.ucDomicilioActual.Guardar

      If strPosibleError <> "" Then
        Me.ColocarMensaje(1, "Error al agregar datos")
      End If

      'verifico que hacer luego de que 
      'si todo esta ok regreso al listado
      If strPosibleError = "" Then
        Me.ColocarMensaje(0, "Se actualizaron los datos correctamente")
      End If

    Catch ex As Exception
      Me.ColocarMensaje(1, "Error al agregar datos: " & ex.Message)
    End Try
  End Sub

  '''Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
  '''  Response.Redirect("lstDatosP.aspx")
  '''End Sub

  Private Sub CargoRecuros(ByVal selector As String)
    Dim oDT As DataTable
    Select Case selector
      Case "cboEspecialidad"
        oDT = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Especialidad)
        With Me.cboEspecialidad
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With

      Case "cboTipoDoc"
        oDT = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_TipoDoc)
        With Me.cboTipoDoc
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With

      Case "UcConocimientos11"
        oDT = oCono.TraerTodos
        'inicializo el control
        Me.UcConocimientos11.InicializarConocimientos(oDT)

      Case "ucPostulaciones1"
        oDT = otbl_postulante.ListarPostulaciones
        'inicializo el control
        Me.ucPostulaciones1.InicializarPostulaciones(oDT)

    End Select
  End Sub
  Private Sub ColocarMensaje(ByVal tipoMensaje As Integer, ByVal texto As String)
    'Desencadeno el mensaje coloco el mensaje de error
    'in
    ' tipoMensaje: 0 solo mensaje , 1 error
    RaiseEvent OcurioError(tipoMensaje, texto)
  End Sub

  '''Private Sub btnModificarConocimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarConocimientos.Click
  '''  'voy a la pantalla de los conocimientos tecnicos
  '''  Dim idPostulante As Integer = Val(ViewState("idPostulante"))
  '''  If idPostulante > 0 Then
  '''    Response.Redirect("ct.aspx")
  '''  Else
  '''    Me.ColocarMensaje(1, "No se pudo recuperar el codigo")
  '''  End If
  '''End Sub

  Private Function guardarCV(ByVal legajoPost As Integer, ByVal strnombreAnteriorCV As String) As String
    'objetivo verifica y guarda el archivo de CV
    'NOTA: hay que borrar el fichero anterior : strnombreAnteriorCV
    'NOTA: el archivo se generara "nroLegajo_yyyyMMddhhmmss.ext"

    Dim strPosibleError As String

    Dim [oF] As System.Web.UI.HtmlControls.HtmlInputFile
    [oF] = Me.txtarchivoCV

    'verifico que no este vacio
    If IsNothing([oF]) Or [oF].Value = "" Then
      'salgo  devolviendo el nombre que tenia previamente
      Return IIf(Me.linkCV.ToolTip <> "", Me.linkCV.ToolTip, "")
      Exit Function
    End If

    Dim iComienzo As Integer = [oF].PostedFile.FileName.LastIndexOf("\")
    Dim strNombre As String = [oF].PostedFile.FileName.Remove(0, iComienzo + 1)
    Dim ultPunto As Integer = [oF].PostedFile.FileName.LastIndexOf(".")
    Dim extension As String = [oF].PostedFile.FileName.Substring(ultPunto + 1, 3)
    'verifico el tama�o
    '(1 Kb = 1024 bytes), en Megabytes (1 Mb = 1024 Kb), Gigabytes (1 Gb = 1024 Mb), Terabytes (1 Tb = 1024 Gb) o Petabytes (1 Pb = 1024 Tb).
    'el dato esta en bytes
    'COMPRUEBO que el archivo no sea mayor a 2 MB
    If [oF].PostedFile.ContentLength > Val(2 * 1024 * 1024) Then
      Throw New Exception("El tama�o del archivo debe ser menor a 2Mb")
      Exit Function
    End If
    'verifico la extension
    Select Case extension.ToUpper
      Case "ZIP", "RAR", "DOC"
      Case Else
        Throw New Exception("El archivo debe estar comprimido en Zip o Rar")
        Exit Function
    End Select

    'NOTA: el idPostulante sirve para armar el nombre del archivo
    strNombre = legajoPost & "_" & Date.Now.ToString("yyyyMMddhhmmss") & "." & extension.ToLower
    Dim Path As String = Server.MapPath(Logica.cUtil.GetAppRootPath & "/" & System.Configuration.ConfigurationSettings.AppSettings("Carpeta_CV").ToString())
    'guardo
    strPosibleError = cUtil.GuardarArchivoEn(Path & strNombre, Me.txtarchivoCV)
    If strPosibleError <> "" Then
      Throw New Exception(strPosibleError)
    End If

    'si se grabo correctamente el anterior, tengo que eliminar el archivo anterior
    Path = Server.MapPath(Logica.cUtil.GetAppRootPath & "/" & System.Configuration.ConfigurationSettings.AppSettings("Carpeta_CV").ToString() & "/" & strnombreAnteriorCV)
    strPosibleError = cUtil.BorrarArchivoDe(Path)
    If strPosibleError <> "" Then
      'logueo el error del archivo que no se pudo borrar
      cUtil.XML_Logerror("Error al eliminar CV anterior", strPosibleError)
    End If

    'retorno el nombre del archivo
    Return strNombre
  End Function

  Private Sub UcConocimientos11_Update(ByVal strPosibleError As String, ByVal strConocimientos As String) Handles UcConocimientos11.Update
    If strPosibleError = "" Then
      'actualizo los conocimientos
      oCono.idPostulante = Val(ViewState("idPostulante"))
      strPosibleError = oCono.AgregarMasivo(strConocimientos)
      If strPosibleError = "" Then
        'actualizo el valor de la grilla
        Me.CargoRecuros("UcConocimientos11")
      Else
        'muestro el error al agregar los conocimiento
        ColocarMensaje(1, "Error al agregar el conocimiento.<br />Verifique que no este repetido.")
      End If
    Else
      'muestro el error
      ColocarMensaje(1, strPosibleError)
    End If
  End Sub

  Private Sub UcConocimientos11_Delete(ByVal strPosibleError As String, ByVal strConocimientos As String) Handles UcConocimientos11.Delete
    If strPosibleError = "" Then
      'Elimino el conocimiento
      oCono.idPostulante = Val(ViewState("idPostulante"))
      strPosibleError = oCono.Borrar(strConocimientos)
      If strPosibleError = "" Then
        'actualizo el valor de la grilla
        Me.CargoRecuros("UcConocimientos11")
      Else
        'muestro el error al agregar los conocimiento
        ColocarMensaje(1, "Error al eliminar el conocimiento. <br /> Intentelo nuevamente")
      End If
    Else
      'muestro el error
      ColocarMensaje(1, strPosibleError)
    End If
  End Sub

  Private Sub txtnombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

  End Sub

  Private Sub txtpromConAplazos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpromConAplazos.TextChanged

  End Sub
End Class