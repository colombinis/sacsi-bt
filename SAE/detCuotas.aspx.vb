Imports System.Text
Imports bolsatrabajo.Logica.cUtil

Public Class detCuotas
  Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

  <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

  End Sub

  Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
  Protected WithEvents reqfechaVto1 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtfechaVto1 As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqdscConcepto As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtdscConcepto As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqvalor As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtvalor As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtidCuota As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqidEmpresa As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents reqidBusqueda As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents btnSave As System.Web.UI.WebControls.Button
  Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents cboidEstadoCuota As System.Web.UI.WebControls.DropDownList
  Protected WithEvents cboidEmpresa As System.Web.UI.WebControls.DropDownList
  Protected WithEvents cboidBusqueda As System.Web.UI.WebControls.DropDownList
  Protected WithEvents cboidPostulante As System.Web.UI.WebControls.DropDownList
  Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents cmdAfiche As System.Web.UI.WebControls.Button
  Protected WithEvents btnPagar As System.Web.UI.WebControls.Button
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    InitializeComponent()
  End Sub

#End Region

  Dim otbl_cuotasEmpresa As New Logica.tbl_cuotasEmpresa

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If Not Page.IsPostBack Then
      If Not Request.QueryString("ID") Is Nothing Then
        ViewState("idcuota") = Request.QueryString("ID").ToString
        otbl_cuotasEmpresa.idCuota = CInt(ViewState("idcuota"))

        If Not Request.QueryString("Action") Is Nothing AndAlso _
               Request.QueryString("Action").ToString = "V" Then
          Me.DisableControls()
        End If

      End If
      Me.InitScreen()
    End If

  End Sub

  Private Sub InitScreen()
    otbl_cuotasEmpresa.idCuota = CInt(ViewState("idcuota"))

    CargoRecuros("cboidBusqueda")
    CargoRecuros("cboidEmpresa")
    CargoRecuros("cboidEstadoCuota")
    CargoRecuros("cboidPostulante")

    'busco si el id es <> ""
    Dim oDR As DataRow
    If otbl_cuotasEmpresa.idCuota > 0 Then
      oDR = otbl_cuotasEmpresa.TraerUna(otbl_cuotasEmpresa.idCuota)
    End If

    If Not oDR Is Nothing Then
      'cargo los valores existentes
      Me.txtfechaVto1.Text = Trim("" & CStr(oDR("fechaVto1")))
      Me.txtdscConcepto.Text = Trim("" & CStr(oDR("dscConcepto")))
      Me.txtvalor.Text = Trim("" & CStr(oDR("valor")))
      Me.cboidEstadoCuota.SelectedValue = Trim("" & CStr(oDR("idEstadoCuota")))
      Me.txtidCuota.Text = Trim("" & CStr(oDR("idCuota")))
      Me.cboidEmpresa.SelectedValue = Trim("" & CStr(oDR("idEmpresa")))
      Me.cboidBusqueda.SelectedValue = Trim("" & CStr(oDR("idBusqueda")))
      Me.cboidPostulante.SelectedValue = Trim("" & CStr(oDR("idPostulante")))
      AcomodarAcciones()
    Else
      AcomodarAcciones("nuevacuota")
      'precargo los valores para un registro nuevo
      Me.cboidEstadoCuota.SelectedValue = CStr(Logica.Estado_de_cuota.vigente)
    End If
    'van siempre deshabilitados
    Me.txtidCuota.Enabled = False
    Me.cboidEstadoCuota.Enabled = False
  End Sub

  Private Sub DisableControls()
    'desabilito los controles 
    Me.txtfechaVto1.Enabled = False
    Me.txtdscConcepto.Enabled = False
    Me.txtvalor.Enabled = False
    Me.cboidEstadoCuota.Enabled = False
    Me.txtidCuota.Enabled = False
    Me.cboidEmpresa.Enabled = False
    Me.cboidBusqueda.Enabled = False
    Me.cboidPostulante.Enabled = False
    btnSave.Enabled = False
  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    Dim strPosibleError As String = ""

    If Me.txtfechaVto1.Text <> "" Then otbl_cuotasEmpresa.fechaVto1 = CDate(Me.txtfechaVto1.Text)
    If Me.txtdscConcepto.Text <> "" Then otbl_cuotasEmpresa.dscConcepto = Me.txtdscConcepto.Text
    If Me.txtvalor.Text <> "" Then otbl_cuotasEmpresa.valor = CDbl(Me.txtvalor.Text)
    If Me.cboidEstadoCuota.SelectedValue <> "-1" Then otbl_cuotasEmpresa.idEstadoCuota = CInt(Me.cboidEstadoCuota.SelectedValue)
    If Me.cboidEmpresa.SelectedValue <> "-1" Then otbl_cuotasEmpresa.idEmpresa = CInt(Me.cboidEmpresa.SelectedValue)
    If Me.cboidBusqueda.SelectedValue <> "-1" Then otbl_cuotasEmpresa.idBusqueda = CInt(Me.cboidBusqueda.SelectedValue)
    If Me.cboidPostulante.SelectedValue <> "-1" Then otbl_cuotasEmpresa.idPostulante = CInt(Me.cboidPostulante.SelectedValue)

    'agrego el nuevo registro
    strPosibleError = otbl_cuotasEmpresa.Agregar()

    If strPosibleError <> "" Then
      Me.ColocarMensaje("Error al agregar datos")
    End If

    'si todo esta ok regreso al listado
    If strPosibleError = "" Then cancelar()
  End Sub

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    cancelar()
  End Sub

  Private Sub CargoRecuros(ByVal selector As String)
    'cargo recursos selectivamente
    Select Case selector
      Case "cboidBusqueda"
        'puede haber cuotas de busquedas que ya no esten activas
        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Busquedas(False))
        With Me.cboidBusqueda
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With

      Case "cboidEmpresa"
        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Empresas)
        With Me.cboidEmpresa
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With

      Case "cboidEstadoCuota"
        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_EstadoCuotas)
        With Me.cboidEstadoCuota
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With

      Case "cboidPostulante"
        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Postulantes)
        With Me.cboidPostulante
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

  Private Sub cancelar()
    'cancelar comun
    Response.Redirect("lstCuotas.aspx")
  End Sub

  Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
    'verifico si la cuota ya existe
    If otbl_cuotasEmpresa.idCuota > 0 Then
      Me.btnPagar.Attributes.Add("onClick", "javascript:return validarOnSub('Se registrara el pago de la cuota ¿Desea continuar?');")
    End If
  End Sub

  Private Sub btnPagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPagar.Click
    Dim strPosibleError As String
    'coloco el estado de la cuota como pagada
    otbl_cuotasEmpresa.idCuota = Val(ViewState("idcuota"))
    otbl_cuotasEmpresa.idEstadoCuota = Logica.Estado_de_cuota.pagada
    strPosibleError = otbl_cuotasEmpresa.EditarEstado()
    If strPosibleError <> "" Then
      'error al actualizar el estado
      Me.ColocarMensaje("Error al actualizar el estado de la cuota")
    Else
      'se actualizo el estado vuelvo al listado de cuotas
      cancelar()
    End If
  End Sub

  Private Sub AcomodarAcciones(Optional ByVal selector As String = "")
    Select Case selector
      Case "nuevacuota"
        'no puede imprimir 
        Me.cmdAfiche.Enabled = False
        'no puedo pagar
        Me.btnPagar.Enabled = False

    End Select
    'verifico el estado de la cuenta
    ' si esta pagada deshabilito los botones de Pagar
    If Me.cboidEstadoCuota.SelectedItem.Value = Logica.Estado_de_cuota.pagada Then
      Me.btnPagar.Enabled = False
    End If

  End Sub

  Private Sub cmdAfiche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAfiche.Click
    'Introducir aquí el código de usuario para inicializar la página
    '[@pathimagenes]
    '[@fechaHoy]
    '[@importe]
    '[@importePesos]
    '[@empresa]
    '[@concepto]
    Dim strPlantilla As String = Server.MapPath("../public/plantilla/plantNotaPago.htm")
    Dim oST As New StringBuilder
    oST.Append(ReadTextFile(strPlantilla))
    'reemplazo por los valores reales
    oST.Replace("[@pathimagenes]", GetHttpAppRootPath)
    oST.Replace("[@fechaHoy]", String.Format("{0:dd 'de' MMMM 'de' yyyy}", Date.Today))
    oST.Replace("[@importe]", Trim(Me.txtvalor.Text))
    oST.Replace("[@importePesos]", Num2Text(Convert.ToDouble(Trim(Me.txtvalor.Text))))
    oST.Replace("[@empresa]", Trim(Me.cboidEmpresa.SelectedItem.Text))
    oST.Replace("[@concepto]", Trim(Me.txtdscConcepto.Text))

    BajarArchivoComo(Response, oST.ToString, "doc", "NotaPago")
  End Sub
End Class