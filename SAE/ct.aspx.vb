Imports System.Text
Public Class ct
  Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

  'El Diseñador de Web Forms requiere esta llamada.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
  Protected WithEvents UcConocimientos11 As UcConocimientos1

  'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
  'No se debe eliminar o mover.
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
    'No la modifique con el editor de código.
    InitializeComponent()
  End Sub

#End Region

  Dim oCono As New Logica.tbl_conocimiento_x_postulante

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Introducir aquí el código de usuario para inicializar la página
    If Not Page.IsPostBack Then

      If Not Request.QueryString("ID") Is Nothing Then
        ViewState("idPostulante") = Request.QueryString("ID").ToString
        oCono.idPostulante = CInt(ViewState("idPostulante"))
        Me.initScreen()
      Else
        Response.Redirect(Request.UrlReferrer.ToString)
      End If

    End If
  End Sub

  Private Sub initScreen()
    'cargo la grilla de conocimientos
    Me.CargoRecuros("UcConocimientos11")

  End Sub

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    'redireccionar a la pagina principal
    cancelar()
  End Sub

  Private Sub cancelar()
    'acciones comunes al cancelar la pagina
    Response.Redirect("detDatosP.aspx?ID=" & Val(ViewState("idPostulante")) & "&ACTION=V")
  End Sub

  Private Sub CargoRecuros(ByVal selector As String)
    'cargo recursos selectivamente
    Select Case selector
      Case "UcConocimientos11"
        'inicializo el control de conocimientos
        Dim oDT As DataTable = oCono.TraerTodos
        'si no tiene conocimientos cargados salgo
        '''If IsNothing(oDT) Then Exit Sub
        'inicializo el control
        Me.UcConocimientos11.InicializarConocimientos(oDT)
        '''Dim strValores As New StringBuilder
        '''Dim i As Integer
        ''''tengo que concatenar idConocimiento,idvalor|
        '''For i = 0 To oDT.Rows.Count - 1
        '''  strValores.Append("|" & oDT.Rows(i).Item("idconocimiento") & "," & oDT.Rows(i).Item("idvalor"))
        '''Next
        ''''saco el 1er caracter
        '''strValores.Remove(0, 1)
        ''''inicializo el control
        '''Me.UcConocimientos1.InicializarConocimientos(strValores.ToString)
    End Select
  End Sub

  Private Sub ColocarMensaje(ByVal texto As String)
    'coloco el mensaje de error
    lblError.Text = texto
    lblError.Visible = True
  End Sub

  Private Sub UcConocimientos1_Update(ByVal strPosibleError As String, ByVal strConocimientos As String) Handles UcConocimientos11.Update
    If strPosibleError = "" Then
      'actualizo los conocimientos
      oCono.idPostulante = Val(ViewState("idPostulante"))
      strPosibleError = oCono.AgregarMasivo(strConocimientos)
      If strPosibleError = "" Then
        'actualizo el valor de la grilla
        Me.CargoRecuros("UcConocimientos11")
      Else
        'muestro el error al agregar los conocimiento
        ColocarMensaje("Error al agregar el conocimiento.<br />Verifique que no este repetido.")
      End If
    Else
      'muestro el error
      ColocarMensaje(strPosibleError)
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
        ColocarMensaje("Error al eliminar el conocimiento. <br /> Intentelo nuevamente")
      End If
    Else
      'muestro el error
      ColocarMensaje(strPosibleError)
    End If
  End Sub
End Class
