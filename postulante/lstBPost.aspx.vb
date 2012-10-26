Imports bolsatrabajo.Logica.cUtil

Public Class lstBPost
  Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

  'El Diseñador de Web Forms requiere esta llamada.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents oGrid As System.Web.UI.WebControls.DataGrid
  Protected WithEvents cantReg As System.Web.UI.HtmlControls.HtmlGenericControl
  Protected WithEvents cmdDocumentacion As System.Web.UI.WebControls.Button
  Protected WithEvents txtIDOculto As System.Web.UI.HtmlControls.HtmlInputHidden
  Protected WithEvents txtFILTRO As System.Web.UI.WebControls.TextBox
  Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
  Protected WithEvents cboOrdenColumna As System.Web.UI.WebControls.DropDownList

  'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
  'No se debe eliminar o mover.
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
    'No la modifique con el editor de código.
    InitializeComponent()
  End Sub

#End Region

  Dim otbl_busqueda As New Logica.tbl_busqueda

  Dim idPostulante As Integer

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Try
      idPostulante = Logica.cUtil.varSession(Logica.cUtil.userSession.UserLogonID)

      If Not Page.IsPostBack Then
        If idPostulante > 0 Then
          Me.LoadList()
        Else
          'redirecciono a la pagina desde donde se llamo
          Response.Redirect(Request.UrlReferrer.ToString)
        End If
      End If
    Catch ex As Exception
      Logica.cUtil.XML_Logerror("Error", Server.HtmlEncode(ex.Message))
      Response.Redirect("msgGral.aspx?flag=N&msg=" & Server.UrlEncode("Error: " & vbNewLine & "Los datos de la sesion han caducado."), False)
    End Try
    

  End Sub

  Private Sub LoadList()
    'cargo las busquedas de todas las empresas
    Dim oDT As DataTable
    Dim idBusqueda As Integer
    If IsNumeric(Me.txtFILTRO.Text) Then
      idBusqueda = Val(Me.txtFILTRO.Text)
    Else
      idBusqueda = 0
    End If
    otbl_busqueda.idBusqueda = idBusqueda
    oDT = otbl_busqueda.TraerTodas(idPostulante, idBusqueda, Me.cboOrdenColumna.SelectedValue)

    If Not IsNothing(oDT) Then
      cantReg.InnerText = "Lista de Busquedas(" & oDT.Rows.Count & ")"
      oGrid.DataKeyField = "idBusqueda"
      oGrid.DataSource = oDT
      oGrid.DataBind()
    Else
      cantReg.InnerText = "Lista de Busquedas(0)"
      'ocultar los botones de las acciones que no se pueden hacer si no hay registros
    End If
  End Sub

  Private Sub oGrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles oGrid.ItemDataBound
    Dim fechaPostulacion As String
    Dim strMotivo As String
    Dim strEstado As String
    'agrego el script a cada fila
    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
      'Obtengo la fecha de postulacion
      fechaPostulacion = e.Item.Cells.Item(10).Text
      'Obtengo el motivo de exclusion
      'strMotivo = e.Item.Cells.Item(7).Text
      'si no hay motivo de excusion es porque o no esta o si esta postulado 
      '''If strMotivo <> "&nbsp;" Then
      '''  'esta excluido de la busqueda
      '''  strEstado = "Excluido por: " & Trim(strMotivo)
      '''Else
      '''  'Puede que este Postulado o no
      '''  If fechaPostulacion <> "&nbsp;" Then
      '''    'Esta postulado
      '''    strEstado = "Postulado el: " & fechaPostulacion
      '''  Else
      '''    'todavia no se postulo
      '''    strEstado = ""
      '''  End If
      '''End If
      'Puede que este Postulado o no
      If fechaPostulacion <> "&nbsp;" Then
        'Esta postulado
        strEstado = "Postulado el: " & fechaPostulacion
      Else
        'todavia no se postulo
        strEstado = ""
      End If
      'coloco el estado en la columna del estado
      e.Item.Cells.Item(6).Text = strEstado
    End If

  End Sub

  '''Private Sub oGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles oGrid.ItemCommand
  '''  'al hacer clic en la imagen de la columna
  '''  If e.Item.ItemIndex >= 0 Then
  '''    Dim idE As String = oGrid.Items(e.Item.ItemIndex).Cells(0).Text
  '''    Dim idB As String = oGrid.Items(e.Item.ItemIndex).Cells(1).Text

  '''    Select Case e.CommandName.ToUpper
  '''      Case "VIEW"
  '''        Response.Redirect("detBP.aspx?IDE=" & idE & "&IDB=" & idB)
  '''    End Select
  '''  End If


  '''End Sub

  Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'busco la idBusqueda con el filtro ingresado
    Me.LoadList()
  End Sub


  Private Sub CargoRecuros(ByVal selector As String)
    ''''cargo recursos selectivamente
    '''Select Case selector
    '''  Case ""
    '''    Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(oEmpresa.ListarCombo_TipoEmpresa())
    '''    With Me.cboTipoEmpresa
    '''      .DataValueField = "ID"
    '''      .DataTextField = "DESCRIPCION"
    '''      .DataSource = oDT
    '''      .DataBind()
    '''    End With
    '''End Select
  End Sub

  Private Sub MostrarOcultar(ByVal selector As String, ByVal valor As Boolean)
    ''''oculto o muestro selectivamente
    '''Select Case selector.ToUpper
    '''  Case ""
    '''    'van siempre deshabilitados
    '''    'Me.txtCuit.Enabled = valor
    '''End Select
  End Sub

  Public Function getDescripcionCarrera(ByVal strID As String) As String
    'reemplazo los codigos de las carreras por sus nemonicos
    '1	Ingeniería en Sistemas de Información                                                               
    '2  Ingeniería Mecánica
    '3  Ingeniería Química 
    '4  Ingeniería Civil 
    '5  Ingeniería Eléctrica 
    strID = strID.Replace("[1]", ",ISI")
    strID = strID.Replace("[2]", ",IM")
    strID = strID.Replace("[3]", ",IQ")
    strID = strID.Replace("[4]", ",IC")
    strID = strID.Replace("[5]", ",IE")
    Return strID
  End Function

  Public Function getURLBusqueda(ByVal idE As String, ByVal idB As String) As String
    Dim strLink As String = "detBP.aspx?IDE=" & idE & "&IDB=" & idB
    Return "<a href='" & strLink & "'><img src='../img/view.gif' alt='Ver' border='0' ></a>"
  End Function

  Private Sub cboOrdenColumna_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrdenColumna.SelectedIndexChanged
    Me.LoadList()
  End Sub

End Class
