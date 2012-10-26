Imports bolsatrabajo.Logica.cUtil
Imports System.Diagnostics
Imports System.IO
Imports System.Web.Mail

Public Class lstDatosP
  Inherits System.Web.UI.Page
#Region " Código generado por el Diseñador de Web Forms "

  'El Diseñador de Web Forms requiere esta llamada.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents oGrid As System.Web.UI.WebControls.DataGrid
  Protected WithEvents btnNew As System.Web.UI.WebControls.Button
  Protected WithEvents txtFILTRO As System.Web.UI.WebControls.TextBox
  Protected WithEvents cantReg As System.Web.UI.HtmlControls.HtmlGenericControl
  Protected WithEvents cmdDocumentacion As System.Web.UI.WebControls.Button
  Protected WithEvents txtIDOculto As System.Web.UI.HtmlControls.HtmlInputHidden
  Protected WithEvents cboBusqueda As System.Web.UI.WebControls.DropDownList
  Protected WithEvents cmdExcluir As System.Web.UI.WebControls.Button
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents cmdIniciarVinculo As System.Web.UI.WebControls.Button
  Protected WithEvents cmdFiltradoPostulantes As System.Web.UI.WebControls.Button
  Protected WithEvents cboMotivo As System.Web.UI.WebControls.DropDownList
  Protected WithEvents cmdRealizarProceso As System.Web.UI.WebControls.Button

  'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
  'No se debe eliminar o mover.
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
    'No la modifique con el editor de código.
    InitializeComponent()
  End Sub

#End Region

  Dim otbl_postulante As New Logica.tbl_postulante

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim intB As Integer = 0

        If Not Page.IsPostBack Then
            If Not Request.QueryString("IDB") Is Nothing Then
                ViewState("idbusqueda") = Request.QueryString("IDB").ToString
                intB = Val(ViewState("idbusqueda"))
            Else
                'Obtengo la busqueda de los datos por la sesion
                Dim sbusqueda As String = Logica.cUtil.varSession(userSession.comunes_BusquedaActual)
                If sbusqueda <> "" Then
                    ViewState("idbusqueda") = sbusqueda
                    intB = Val(sbusqueda)
                End If
            End If

            initSreen(intB)
            Me.LoadList(, intB)
        End If

        lblError.Visible = False
  End Sub

  Private Sub initSreen(ByVal PrecargaIDB As Integer)

    'Precarga la seleccion del combo de busquedas
    Me.CargoRecuros("cboBusqueda")
    If PrecargaIDB > 0 Then
      Me.cboBusqueda.SelectedValue = PrecargaIDB
    End If
  End Sub

  Private Sub LoadList(Optional ByVal legajo As Integer = 0, Optional ByVal idBusqueda As Integer = 0)

    'cargo los datos de la grilla
    Dim oDT As DataTable = otbl_postulante.TraerTodos(legajo, idBusqueda)
    If Not IsNothing(oDT) Then
      cantReg.InnerText = "Lista de Postulantes (" & oDT.Rows.Count & ")"
      oGrid.DataKeyField = "idPostulante"


      Me.cmdExcluir.Enabled = True
      cmdIniciarVinculo.Enabled = True
      cmdRealizarProceso.Enabled = True
    Else
      cantReg.InnerText = "Lista de Postulantes(0)"
      'ocultar los botones de las acciones que no se pueden hacer si no hay registros
      'Si no hay Alumnos 
      'no se puede excluir
      Me.cmdExcluir.Enabled = False
      'no se puede vincular a una busqueda
      cmdIniciarVinculo.Enabled = False
      'no se puede realizar el proceso de envio
      cmdRealizarProceso.Enabled = False
    End If
    oGrid.DataSource = oDT
    oGrid.DataBind()
  End Sub

  Private Sub oGrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles oGrid.ItemDataBound
    Dim strIdFiltro As String
    Dim fechaActualiza As Date
    Dim fechaRevision As Date
    'agrego el script a cada fila
    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
      strIdFiltro = e.Item.Cells(1).Text
      If e.Item.Cells(9).Text <> "" AndAlso e.Item.Cells(9).Text <> "&nbsp;" Then
        fechaActualiza = e.Item.Cells(9).Text
      End If
      If e.Item.Cells(10).Text <> "" AndAlso e.Item.Cells(10).Text <> "&nbsp;" Then
        fechaRevision = e.Item.Cells(10).Text
      End If
      If fechaActualiza > fechaRevision Then
        'el postulante actualizo sus datos y no se revisaron posteriormente
        'marco la fila en rojo
        e.Item.Attributes.Add("class", "filaSeleccionada")
      End If


      '''CType(e.Item.FindControl("imgDelete"), ImageButton).Attributes.Add("onClick", "javascript:return confirmDelete();")
      CType(e.Item.FindControl("optRows"), RadioButton).Attributes.Add("onClick", "javascript:return Selrow(this,'" & strIdFiltro & "');")
    End If

  End Sub

  Private Sub oGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles oGrid.ItemCommand

    'cuando pagino se ejecuta este evento pero no deberia
    If e.Item.ItemIndex = -1 Then Exit Sub

    'al hacer clic en la imagen de la columna
    Dim mKey As String = oGrid.DataKeys(e.Item.ItemIndex)
    otbl_postulante.idPostulante = mKey
    Dim strLega As String = e.Item.Cells(5).Text

    Select Case e.CommandName.ToUpper
      Case "VIEW"
        Response.Redirect("detDatosP.aspx?ID=" & mKey & "&ACTION=V")

      Case "EDIT"
        Dim DatosDesc As String ' coloco datos del alumno
        DatosDesc = Server.UrlEncode(Trim(e.Item.Cells(5).Text) & " " & Trim(e.Item.Cells(6).Text) & " " & Trim(e.Item.Cells(7).Text))
        'redirecciono a la pantalla
        Response.Redirect("postAmano.aspx?IDP=" & mKey & "&datdesc=" & DatosDesc)


      Case "INFOACAD"
        'muestra la informacion academica
        If strLega = "" Then
          Me.ColocarMensaje("No se puede obtener la informacion academica sin numero de legajo")
        Else
          Response.Redirect("ConsultaSaeWeb.aspx?legajo=" & strLega)
        End If

    End Select

  End Sub

  '''Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
  '''  Response.Redirect("detDatosP.aspx")
  '''End Sub

  Private Sub RefrescarGrilla()
    'en el onchange del legajo y del combo de la pasantia
    Dim legajo As Integer = 0
    Dim busqueda As Integer = 0

    'busco la XXX con el filtro ingresado
    If IsNumeric(Me.txtFILTRO.Text) Then
      legajo = Val(Me.txtFILTRO.Text)
    End If

    If Me.cboBusqueda.SelectedValue <> -1 Then
      busqueda = Me.cboBusqueda.SelectedValue
    End If
    'Coloco la busqueda actual en una variable de sesion
    Logica.cUtil.varSession(userSession.comunes_BusquedaActual, Me.cboBusqueda.SelectedValue)

    Me.LoadList(legajo, busqueda)
  End Sub

  Private Sub CargoRecuros(ByVal selector As String)
    'cargo recursos selectivamente
    Select Case selector
      Case "cboBusqueda"
        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_Busquedas(False))
        With Me.cboBusqueda
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With
    End Select
  End Sub

  '''Private Sub MostrarOcultar(ByVal selector As String, ByVal valor As Boolean)
  '''  ''''oculto o muestro selectivamente
  '''  '''Select Case selector.ToUpper
  '''  '''  Case ""
  '''  '''    'van siempre deshabilitados
  '''  '''    'Me.txtCuit.Enabled = valor
  '''  '''End Select
  '''End Sub

  Private Sub cboBusqueda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBusqueda.SelectedIndexChanged
    'refresco la grilla
    Me.RefrescarGrilla()
  End Sub

  Private Sub txtFILTRO_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFILTRO.TextChanged
    'refresco la grilla
    Me.RefrescarGrilla()
  End Sub

  '''Private Sub ColocarMensaje(ByVal texto As String)
  '''  'coloco el mensaje de error
  '''  lblError.Text = texto
  '''  lblError.Visible = True
  '''End Sub

  Private Sub ColocarMensaje(ByVal texto As String, Optional ByVal codError As Integer = 1)
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

  Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
    Dim strMotivo As String

    If Me.cboBusqueda.SelectedValue = -1 Then
      ColocarMensaje("Debe seleccionar una busqueda")
      Exit Sub
    End If

    'verifico si coloco un motivo y si selecciono algun
    If Me.txtIDOculto.Value = "" Then
      ColocarMensaje("Debe seleccionar un postulante")
      Exit Sub
    End If

    'If Me.txtMotivo.Text = "" Then
    If Me.cboMotivo.SelectedValue = "-1" Then
      ColocarMensaje("Debe ingresar un motivo para la exclusion")
      Exit Sub
    Else
      strMotivo = cboMotivo.SelectedItem.Text
    End If



    'obtengo los datos de la busqueda y del Postulante seleccionado
    Dim busqueda As Integer = Me.cboBusqueda.SelectedValue
    Dim idPost As Integer = Val(Me.txtIDOculto.Value)
    Dim strPosibleError As String
    Dim oB As New Logica.tbl_busqueda

    strPosibleError = oB.ExcluirPostulanteDeBusqueda(busqueda, idPost, strMotivo)
    If strPosibleError <> "" Then
      ColocarMensaje(strPosibleError)
      Exit Sub
    End If
    Me.LoadList(0, busqueda)
  End Sub

  Private Sub cmdIniciarVinculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIniciarVinculo.Click
    'verifico si coloco un motivo y si selecciono algun
    If Me.txtIDOculto.Value = "" Then
      ColocarMensaje("Debe seleccionar un postulante")
      Exit Sub
    End If

    If Me.cboBusqueda.SelectedValue = -1 Then
      ColocarMensaje("Debe seleccionar una busqueda")
      Exit Sub
    End If

    'obtengo los datos de la busqueda y del Postulante seleccionado
    Dim idB As Integer = Me.cboBusqueda.SelectedValue
    Dim idP As Integer = Val(Me.txtIDOculto.Value)
    'redirecciono a la pantalla
    Response.Redirect("RelPostEmpresa.aspx?IDP=" & idP & "&IDB=" & idB)
  End Sub

  Private Sub cmdFiltradoPostulantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFiltradoPostulantes.Click
    'voy a la pagina donde realiza el filtro avanzado de postulantes
    Response.Redirect("filtropostulantes.aspx")
  End Sub

  Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
    Response.Redirect("detDatosP.aspx")
  End Sub

  Private Sub cmdRealizarProceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRealizarProceso.Click
    Dim LegajosEnviadosPorEmail As String

    If Me.cboBusqueda.SelectedValue = -1 Then
      ColocarMensaje("Debe seleccionar una busqueda")
      Exit Sub
    End If

    Dim strPosibleError As String
    strPosibleError = ProcesoEnvio(LegajosEnviadosPorEmail)
    If strPosibleError <> "" Then
      Me.ColocarMensaje(strPosibleError)
      Exit Sub
    Else
      Me.ColocarMensaje("El email se ha enviado correctamente " & vbNewLine & " Con una copia a " & System.Configuration.ConfigurationSettings.AppSettings("emailSystema").ToString() & vbNewLine & " Se incluyeron los siguientes archivos: " & LegajosEnviadosPorEmail, 0)
    End If

    'si llego hasta aca es porque el proceso se realizo correctamente

  End Sub

  Private Function ProcesoEnvio(ByRef LegajosEnviadosPorEmail As String) As String
    'objetivo: Porceso de envio por email de los CVs comprimidos en un .zip
    'in
    '
    'out
    ' "" si todo ok, o el error.
    Dim codigosPostulantesEnviados As String = ""
    Dim strPosibleError As String = ""
    Dim strPathPublico As String = ""
    Dim strPathCarpeta As String = ""
    Dim strPathBat As String = ""
    LegajosEnviadosPorEmail = ""
    '0-Borro todos los archivos con extension .tmp generados por el bat que comprime a .zip
    '1-Borrar la carpeta a comprimir y su contenido para asegurarme de que no haya contenido que no corresponda
    '2-Recorrer listado de CVs e ir copiando en la carpeta a comprimir
    '3-Comprimir la carpeta con su contenido
    '4-Enviar un email a la empresa con copia a una direccion de la SAE

    '1- Borrar carpeta
    Logica.cUtil.XML_LogGenerico("ProcesoEnvio", "1- Borrar carpeta")

    strPathPublico = Server.MapPath(Logica.cUtil.GetAppRootPath & "/" & System.Configuration.ConfigurationSettings.AppSettings("Carpeta_CV").ToString())
    strPathCarpeta = System.Configuration.ConfigurationSettings.AppSettings("Carpeta_ZIP").ToString() ' debe concidir con el que esta en el bat
    strPathBat = System.Configuration.ConfigurationSettings.AppSettings("COMPRIME_BAT").ToString() ' "comprime.bat"
    Dim oD As Directory
    Dim [oF] As File
    Dim archiTmp As String
    Dim strMailEmp As String = ""
    Dim strMailCopia As String = ""
    'con el id de la busqueda obtengo el email de la empresa que la realizo
    Dim idB As Integer = Me.cboBusqueda.SelectedValue
    Dim oE As New Logica.cEmpresa
    strMailEmp = Trim(oE.ObtenerEmailPorBusqueda(idB))
    strMailCopia = System.Configuration.ConfigurationSettings.AppSettings("emailSystema").ToString()
    Try

      'Borro todos los archivos temporales
      For Each archiTmp In oD.GetFiles(strPathPublico, "*.tmp")
        [oF].Delete(archiTmp)
      Next

      'borro el fichero aEnviar.zip
      If [oF].Exists(strPathPublico & strPathCarpeta & ".zip") Then
        [oF].Delete(strPathPublico & strPathCarpeta & ".zip")
      End If

      'elimino con todo y contenido
      If oD.Exists(strPathPublico & strPathCarpeta) Then
        oD.Delete(strPathPublico & strPathCarpeta, True)
      End If
      'creo la carpeta "limpia"
      oD.CreateDirectory(strPathPublico & strPathCarpeta)

      Dim dI As DataGridItem
      Dim strarchivoCV As String
      Dim strfechaEnvioCV As String
      Dim strIdPostulante As String
      For Each dI In Me.oGrid.Items
        If dI.ItemType = ListItemType.Item Or dI.ItemType = ListItemType.AlternatingItem Then
          strarchivoCV = Trim(dI.Cells(11).Text)
          strfechaEnvioCV = Trim(dI.Cells(12).Text)
          strIdPostulante = Trim(dI.Cells(1).Text)
          'segun la fecha del envio del CV
          If strfechaEnvioCV = "" Or strfechaEnvioCV = "&nbsp;" Then
            'verifico si existe el archivo
            If [oF].Exists(strPathPublico & strarchivoCV) Then
              'copio de la carpeta de CVs a la que se va a comprimir
              [oF].Copy(strPathPublico & strarchivoCV, strPathPublico & strPathCarpeta & "\" & strarchivoCV, True)
              LegajosEnviadosPorEmail = LegajosEnviadosPorEmail & strarchivoCV & " ;"
              codigosPostulantesEnviados = codigosPostulantesEnviados & strIdPostulante & ","
            Else
              'error no existe el archivo del
              'Throw New Exception("No existe el archivo para el legajo " & Trim(dI.Cells(3).Text))
            End If
          End If
        End If
      Next

      'verifico que exista al menos un postulante para realizar el envio de email
      If codigosPostulantesEnviados <> "" Then
        '3-Zipeo la carpeta a enviar con todos los CVs
        Logica.cUtil.XML_LogGenerico("ProcesoEnvio", "3-Zipeo la carpeta a enviar con todos los CVs")

        Dim fichero As String = strPathPublico & strPathBat
        Dim psi = New ProcessStartInfo(fichero)
        psi.UseShellExecute = False
        psi.ErrorDialog = False
        psi.CreateNoWindow = True

        psi.WorkingDirectory = strPathPublico
        'psi.WindowStyle = ProcessWindowStyle.Hidden
        Dim miProceso As Process
        miProceso = Process.Start(psi)
        Do While Not miProceso.HasExited
          ' Espero 1 segundo
          System.Threading.Thread.Sleep(1000)
        Loop
        'libero los recursos del proceso
        miProceso.Close()

        Logica.cUtil.XML_LogGenerico("ProcesoEnvio", "antes del Dim msg As New MailMessage")

        Dim msg As New MailMessage
        Dim oAttach As New Mail.MailAttachment(strPathPublico & strPathCarpeta & ".zip")
        msg.From = System.Configuration.ConfigurationSettings.AppSettings("emailSystema").ToString()

        'strMailEmp = "scolombini@frro.utn.edu.ar"
        'strMailCopia = strMailEmp

        If strMailEmp = "" Then
          'error la empresa no tiene email
          Throw New Exception("no se pudo recuperar el dato de email de la empresa.")
        End If

        'en lugar de strMailEmp coloco el de SAE temporalmente
        msg.To = strMailEmp

        'mail con copia oculta
        If strMailCopia <> "" Then
          msg.Cc = strMailCopia
          'msg.Bcc = strMailCopia
        End If

        Dim strPlantilla As String = Server.MapPath("../public/plantilla/plantEmailBusquedas.htm")
        Dim oST As New System.Text.StringBuilder
        oST.Append(ReadTextFile(strPlantilla))
        'reemplazo por los valores reales
        oST.Replace("[@pathimagenes]", GetHttpAppRootPath)

        msg.Subject = "Resultados de la busqueda. Reenviar a:" & Trim(strMailEmp)

        msg.BodyFormat = MailFormat.Html
        msg.Body = oST.ToString
        msg.Attachments.Add(oAttach)
        SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings("ServidorPOP").ToString()
        Logica.cUtil.XML_LogGenerico("ProcesoEnvio", "antes del SmtpMail.Send(msg)")

        SmtpMail.Send(msg)

        Logica.cUtil.XML_LogGenerico("ProcesoEnvio", "Justo despues del SmtpMail.Send(msg)")
        msg = Nothing
        oAttach = Nothing

        'actualizo las fechas de envio de CV en los postulantes incluidos
        Dim oB As New Logica.tbl_busqueda
        strPosibleError = oB.ActualizarFechaEnvio(idB, codigosPostulantesEnviados)
        If strPosibleError <> "" Then
          Throw New Exception(strPosibleError)
        End If
      Else
        strPosibleError = "No hay postulantes con datos validos para enviar por email"
        If strPosibleError <> "" Then
          Throw New Exception(strPosibleError)
        End If
      End If

      Return strPosibleError
    Catch ex As Exception
      Logica.cUtil.XML_LogGenerico("ProcesoEnvio", "Error: en el proceso de envio por correo. " & ex.Message)
      Return "Error: en el proceso de envio por correo. " & ex.Message & " Enviar a :::" & strMailEmp & " / " & strMailCopia & " ::: Archivo adjunto::: http://bolsadetrabajo.frro.utn.edu.ar/public/currV/aEnviar.zip"
    End Try

  End Function

  'metodo para agregar para paginar datagrid
  '''Private Sub oGrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles oGrid.PageIndexChanged
  '''  Me.oGrid.CurrentPageIndex = e.NewPageIndex
  '''  Me.RefrescarGrilla()
  '''End Sub
End Class