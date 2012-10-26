Imports System.Text

Public Class ucfiltrado
  Inherits System.Web.UI.UserControl

#Region " Código generado por el Diseñador de Web Forms "

  'El Diseñador de Web Forms requiere esta llamada.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents cboCampo As System.Web.UI.WebControls.DropDownList
  Protected WithEvents cboOperador As System.Web.UI.WebControls.DropDownList
  Protected WithEvents cboNexo As System.Web.UI.WebControls.DropDownList
  Protected WithEvents txtValor As System.Web.UI.WebControls.TextBox
  Protected WithEvents cmdAgregarrecondicion As System.Web.UI.WebControls.Button
  Protected WithEvents cmdBuscarPostulantes As System.Web.UI.WebControls.Button
  Protected WithEvents cboValor As System.Web.UI.WebControls.DropDownList
  Protected WithEvents txtFiltroAcumulado As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtOcultoAcumulado As System.Web.UI.WebControls.TextBox
  Protected WithEvents gridEspecialidad As System.Web.UI.WebControls.DataGrid
  Protected WithEvents cboOpciones As System.Web.UI.WebControls.DropDownList
  Protected WithEvents cmdListarPostulantes As System.Web.UI.WebControls.Button

  'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
  'No se debe eliminar o mover.
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
    'No la modifique con el editor de código.
    InitializeComponent()
  End Sub

#End Region

  Public Event HayError(ByVal codError As Integer, ByVal msgError As String)
  Public Event ListaPostulantesActualizada(ByVal oDT As DataTable)

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'Introducir aquí el código de usuario para inicializar la página
    If Not Me.IsPostBack Then
      initscreen()
    End If
  End Sub

  Private Sub initscreen()
    Me.CargarRecursos("cboCampo")
    Me.CargarRecursos("cboNexo")
    Me.CargarRecursos("gridEspecialidad")
    'oculto el combo de los valores y el txt
    Me.txtValor.Visible = False
    Me.cboValor.Visible = False
  End Sub

  Private Sub CargarRecursos(ByVal selector As String)
    'carga recursos selectivamente
    Select Case selector
      Case "cboCampo"
        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_FILTRO_campos)
        With Me.cboCampo
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With
      Case "cboOperador"
        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_FILTRO_operadores(Me.cboCampo.SelectedItem.Value))
        With Me.cboOperador
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With

      Case "cboNexo"
        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_FILTRO_nexos)
        With Me.cboNexo
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With

      Case "cboValor"
        'TODO:en un futuro los valores dependeran del campo elegido
        Dim oDT As DataTable = Logica.cUtil.Agregar1raFila(Logica.ReglasNegocio.ListarCombo_FILTRO_valores(Me.cboCampo.SelectedItem.Text))
        With Me.cboValor
          .DataValueField = "ID"
          .DataTextField = "DESCRIPCION"
          .DataSource = oDT
          .DataBind()
        End With

      Case "gridEspecialidad"
        Dim oDT As DataTable = Logica.ReglasNegocio.ListarCombo_Especialidad
        With Me.gridEspecialidad
          .DataSource = oDT
          .DataBind()
        End With
    End Select
  End Sub

  Private Sub cboCampo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCampo.SelectedIndexChanged
    If cboCampo.SelectedItem.Value <> "-1" Then
      'lleno los operadores segun el campo seleccionado
      Me.CargarRecursos("cboOperador")
      'por ahora solo muestro el combo
      Me.cboValor.Visible = True
      Me.CargarRecursos("cboValor")

    End If
  End Sub

  Private Sub cmdAgregarrecondicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregarrecondicion.Click
    'verifico valores que se puedan agregar al filtro
    If Me.cboCampo.SelectedItem.Value <> "-1" AndAlso _
        Me.cboOperador.SelectedItem.Value <> "-1" AndAlso _
        Me.cboValor.SelectedItem.Value <> "-1" AndAlso _
        Me.cboNexo.SelectedItem.Value <> "-1" Then
      'coloco la descripcion del filtro acumulado
      Me.txtFiltroAcumulado.Text &= Trim(Me.cboCampo.SelectedItem.Text) & " " & Trim(Me.cboOperador.SelectedItem.Text) & " " & Trim(Me.cboValor.SelectedItem.Text) & " " & Trim(Me.cboNexo.SelectedItem.Text) & " ; "
      'coloco las condicieones en una cadena para luego Parsearla y obtener el Where
      Me.txtOcultoAcumulado.Text &= "¦" & Trim(Me.cboCampo.SelectedItem.Value) & ";" & Trim(Me.cboOperador.SelectedItem.Value) & ";" & Trim(Me.cboValor.SelectedItem.Value) & ";" & Trim(Me.cboNexo.SelectedItem.Value)
    Else
      'desencadeno el error
      RaiseEvent HayError(1, "Verifique que haya ingresado todos los datos correctamente")
    End If
  End Sub

  Private Sub cmdBuscarPostulantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscarPostulantes.Click
    'objetivo: recorro para armar el filtro por especialidades y termino de armar el general
    Dim sWhere As String

    If Me.txtOcultoAcumulado.Text = "" Then
      RaiseEvent HayError(1, "Debe ingresar al menos un condicion de filtrado")
      Exit Sub
    End If

    'saco el 1er caracter ¦
    sWhere = Me.txtOcultoAcumulado.Text.Remove(0, 1)
    Dim oP As New Logica.tbl_postulante
    Dim oDT As DataTable

    Dim strValoresEspe = getValoresEspecialidad()
    If strValoresEspe <> "" Then
      oDT = oP.TraerPostulantesPorFiltrado(sWhere, strValoresEspe)
      RaiseEvent ListaPostulantesActualizada(oDT)
    Else
      'error debe seleccionar al menos una especialiad
      RaiseEvent HayError(1, "Debe seleccionar al menos una especialiad")
    End If
  End Sub

  Private Function getValoresEspecialidad() As String
    'recorro la grilla y devuelvo concatenados los ids de la especialidad
    'in
    'out 
    ' string con el formato es cod1,cod2
    Dim i As Integer
    Dim oChk As CheckBox
    Dim strCods As New StringBuilder
    For i = 0 To Me.gridEspecialidad.Items.Count - 1
      oChk = Me.gridEspecialidad.Items(i).Cells(0).FindControl("chkRow")
      If oChk.Checked = True Then
        strCods.Append("," & Me.gridEspecialidad.Items(i).Cells(1).Text)
      End If
    Next

    'saco la 1er coma si hay elegida una especialidad
    If strCods.ToString <> "" Then
      strCods.Remove(0, 1)
    End If

    Return strCods.ToString
  End Function

  Private Sub cboOpciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOpciones.SelectedIndexChanged
    'si elige algo de este combo invalida las selecciones de los conocimientos.
    If cboOpciones.SelectedValue = "-1" Then
      '
    Else
      'saco las opciones
      txtFiltroAcumulado.Text = ""
      txtOcultoAcumulado.Text = ""
    End If
  End Sub

  Private Sub cmdListarPostulantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListarPostulantes.Click

    Dim oP As New Logica.tbl_postulante
    Dim oDT As DataTable

    If cboOpciones.SelectedValue = "-1" Then
      'error debe seleccionar al menos una especialiad
      RaiseEvent HayError(1, "Debe seleccionar un listado")
    Else
      oDT = oP.TraerPostulantesPorFiltrado(CInt(cboOpciones.SelectedValue))
      RaiseEvent ListaPostulantesActualizada(oDT)
    End If

  End Sub
End Class
