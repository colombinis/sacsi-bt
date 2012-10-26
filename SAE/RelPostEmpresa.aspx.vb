Imports System.Text

Public Class RelPostEmpresa
  Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

  <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

  End Sub

  Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
  Protected WithEvents txtidPostulante As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtidEmpresa As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqfechaInicio As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtfechaInicio As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqfechaFin As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtfechaFin As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqtipovinculo As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents btnSave As System.Web.UI.WebControls.Button
  Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents cboTipoVinculo As System.Web.UI.WebControls.DropDownList
  Protected WithEvents UcCuotas1 As ucCuotas

  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    InitializeComponent()
  End Sub

#End Region

  Dim otbl_RelacionPostulante_Empresa As New Logica.tbl_RelacionPostulante_Empresa

  Dim pasoActual As Integer = 0

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If Not Page.IsPostBack Then
      If Not Request.QueryString("IDP") Is Nothing AndAlso Not Request.QueryString("IDB") Is Nothing Then
        ViewState("idPostulante") = Request.QueryString("IDP").ToString
        ViewState("idBusqueda") = Request.QueryString("IDB").ToString
        otbl_RelacionPostulante_Empresa.idBusqueda = Val(ViewState("idBusqueda"))
        otbl_RelacionPostulante_Empresa.idPostulante = Val(ViewState("idPostulante"))

        Me.InitScreen()
      Else
        'redirecciono a la pantalla desde donde se llamo
        Response.Redirect(Request.UrlReferrer.ToString)
      End If

    End If

  End Sub

  Private Sub InitScreen()
    Select Case pasoActual
      Case 0
        '================================================================
        MostrarOcultar("paso0", True)
        MostrarOcultar("paso1", False)

        Dim idBusqueda As Integer
        Dim idEmpresa As Integer
        Dim idPostulante As Integer

        Dim oDR As DataRow
        Dim oDR1 As DataRow

        CargoRecuros("cboTipoVinculo")

        idBusqueda = otbl_RelacionPostulante_Empresa.idBusqueda
        idPostulante = otbl_RelacionPostulante_Empresa.idPostulante
        If idPostulante > 0 AndAlso idBusqueda > 0 Then
          'traigo los datos del postulante para el encabezado
          Dim oP As New Logica.tbl_postulante
          oDR = oP.Traer(idPostulante)
          Me.txtidPostulante.Text = Trim(oDR("idPostulante")) & " - " & Trim(oDR("apellido")) & ", " & Trim(oDR("nombres"))

          'traigo los datos de la empresa que realizo la busqueda
          oDR = otbl_RelacionPostulante_Empresa.TraerEmpresa(idBusqueda)
          If Not IsNothing(oDR) Then
            idEmpresa = oDR("idempresa")
            ViewState("idempresa") = idEmpresa
            otbl_RelacionPostulante_Empresa.idEmpresa = idEmpresa
            Me.txtidEmpresa.Text = Trim(oDR("cuit")) & " - " & Trim(oDR("razonSocial"))
          End If

          'en este punto tengo los datos de la empresa y postulante
          oDR1 = otbl_RelacionPostulante_Empresa.Traer(idBusqueda, idEmpresa, idPostulante)
        End If

        If Not oDR1 Is Nothing Then
          'cargo los valores existentes
          Me.txtfechaInicio.Text = Trim("" & oDR1("fechaInicio"))
          Me.txtfechaFin.Text = Trim("" & oDR1("fechaFin"))
          Me.cboTipoVinculo.SelectedValue = Trim("" & oDR1("tipovinculo"))
          'como solo se pueden dar de alta los vinculos... deshabilito
          Me.DisableControls()
        Else
          'precargo los valores para un registro nuevo
          '''Me.cboEstadotbl_RelacionPostulante_Empresa.SelectedValue = Logica.estadotbl_RelacionPostulante_Empresa.inicial
        End If
        'van siempre deshabilitados
        Me.txtidPostulante.Enabled = False
        Me.txtidEmpresa.Enabled = False
      Case 1
        '================================================================
        'oculto los controles del paso 0 y muestro/inicializo para el paso 1
        MostrarOcultar("paso0", False)
        MostrarOcultar("paso1", True)
        'para inicializar el control de cuotas tomo las fechas desde y hasta
        Dim fecDesde As Date = Me.txtfechaInicio.Text
        Dim fechasta As Date = Me.txtfechaFin.Text
        Dim fectemp As Date
        Dim strFechas As New StringBuilder
        'NOTA: concatenado dd/MM/yyyy¦valor|
        'ej formato: 01012006¦10.3|01022006¦11.3|01032006¦20
        Dim cont As Integer = 0
        Do
          cont += 1
          fectemp = fecDesde.AddMonths(cont)
          'pongo los valores en 0
          strFechas.Append("|" & String.Format("{0:dd/MM/yyyy}", fectemp) & "¦0")
        Loop Until fectemp > fechasta
        strFechas.Remove(0, 1)
        Me.UcCuotas1.InicializarFechas(strFechas.ToString)
    End Select

  End Sub

  Private Sub DisableControls()
    'desabilito los controles 
    Me.txtidPostulante.Enabled = False
    Me.txtidEmpresa.Enabled = False
    Me.txtfechaInicio.Enabled = False
    Me.txtfechaFin.Enabled = False
    Me.cboTipoVinculo.Enabled = False
    btnSave.Enabled = False
  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    Dim strPosibleError As String = ""

    'le paso los datos al objeto y actualizo
    otbl_RelacionPostulante_Empresa.idPostulante = Val(ViewState("idPostulante"))
    otbl_RelacionPostulante_Empresa.idEmpresa = Val(ViewState("idempresa"))
    otbl_RelacionPostulante_Empresa.idBusqueda = Val(ViewState("idBusqueda"))

    If Me.txtfechaInicio.Text <> "" Then otbl_RelacionPostulante_Empresa.fechaInicio = Me.txtfechaInicio.Text
    If Me.txtfechaFin.Text <> "" Then otbl_RelacionPostulante_Empresa.fechaFin = Me.txtfechaFin.Text
    If Me.cboTipoVinculo.SelectedValue <> -1 Then otbl_RelacionPostulante_Empresa.tipovinculo = Me.cboTipoVinculo.SelectedValue

    'verifico si existe la relacion, porque desde esta pantalla solo se pueden CREAR RELACIONES
    Dim oDR As DataRow = otbl_RelacionPostulante_Empresa.Traer(otbl_RelacionPostulante_Empresa.idBusqueda, otbl_RelacionPostulante_Empresa.idEmpresa, otbl_RelacionPostulante_Empresa.idPostulante)
    If IsNothing(oDR) Then
      strPosibleError = otbl_RelacionPostulante_Empresa.Actualizar()
      'inicializo la documentacion segun la relacion
      Dim momento As String
      Select Case Me.cboTipoVinculo.SelectedValue
        Case 1
          momento = Logica.idMomento.IniciarVinculo_Pasantia
        Case 2
          momento = Logica.idMomento.IniciarVinculo_BolsaDeTrabajo
      End Select
      Logica.ReglasNegocio.InicializarDocumentacion(otbl_RelacionPostulante_Empresa.idEmpresa, momento)
    Else
      strPosibleError = "El vinculo entre el Postulante y la empresa ya existe."
    End If

    'si todo esta ok regreso al listado
        If strPosibleError = "" Then

            Select Case Me.cboTipoVinculo.SelectedValue

                Case 1
                    'Como es Pasantia muestro los controles para la generacion de cuotas
                    Me.pasoActual = 1
                    Me.InitScreen()
                Case Else

                    Cancelar()
            End Select
        Else
            Me.ColocarMensaje(strPosibleError)
        End If
  End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'vuelvo al listado
        Cancelar()
    End Sub

    Private Sub CargoRecuros(ByVal selector As String)
        'cargo recursos selectivamente
        Select Case selector
            Case "cboTipoVinculo"
                Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Vinculo)
                With Me.cboTipoVinculo
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


    Private Sub MostrarOcultar(ByVal selector As String, ByVal valor As Boolean)
        'Objetivo:muestra/oculta selectivamente
        Select Case selector

            Case "paso0"

                Me.txtidPostulante.Enabled = valor
                Me.txtidEmpresa.Enabled = valor
                Me.txtfechaInicio.Enabled = valor
                Me.txtfechaFin.Enabled = valor
                Me.cboTipoVinculo.Enabled = valor
                Me.btnSave.Enabled = valor

            Case "paso1"
                Me.UcCuotas1.Visible = valor

        End Select
    End Sub

    Private Sub UcCuotas1_Update(ByVal strPosibleError As String, ByVal strFechasSalida As String) Handles UcCuotas1.Update
        'Se validaron y concatenaron las fechas y los valores en un strin
        If strPosibleError <> "" Then
            Me.ColocarMensaje(strPosibleError)
        Else
            Dim oCuota As New Logica.tbl_cuotasEmpresa
            oCuota.idBusqueda = Val(ViewState("idBusqueda"))
            oCuota.idEmpresa = Val(ViewState("idempresa"))
            oCuota.idPostulante = Val(ViewState("idPostulante"))
            'la descripcion del concepto
            oCuota.dscConcepto = Trim(Me.cboTipoVinculo.SelectedItem.Text) & "  " & Trim(Me.txtidPostulante.Text)
            strPosibleError = oCuota.AgregarMasivo(strFechasSalida)
            If strPosibleError <> "" Then
                'error al grabar las cuotas
                Me.ColocarMensaje(strPosibleError)
            Else
                'vuelvo al listado
                Cancelar()
            End If
        End If
    End Sub

    Private Sub Cancelar()
        'como la accion de cancelar la utilizo en varios lugares lo unifico
        Response.Redirect("lstdatosp.aspx")
    End Sub
End Class