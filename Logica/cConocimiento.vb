Namespace Logica
  Public Class cConocimiento
#Region "Variables Privadas, GET, SET "
    Private m_idConocimiento As Int32
    Private m_dscConocimiento As String
    Public Property idConocimiento() As Int32
      Get
        Return m_idConocimiento
      End Get
      Set(ByVal Value As Int32)
        m_idConocimiento = Value
      End Set
    End Property
    Public Property dscConocimiento() As String
      Get
        Return m_dscConocimiento
      End Get
      Set(ByVal Value As String)
        m_dscConocimiento = Value
      End Set
    End Property
#End Region
#Region "Funciones ABM "

    Public Sub New()
      'constructor vacio
    End Sub
    Public Function Agregar() As String
      'Objetivo:
      'in
      'out
      ' "" o el error
      Dim oDB As Logica.cBaseDatos
      Dim strPosibleError As String = ""
      Dim strSQL As String = ""
      Dim idConocimiento_NEXT As Long
      strSQL = "select max(idConocimiento)+1  as ID from tbl_Conocimiento"
      idConocimiento_NEXT = oDB.EjecutarScalar(strSQL)

      strSQL = "INSERT INTO tbl_Conocimiento (  idConocimiento , dscConocimiento  )  values ( " & Logica.cBaseDatos.xSQL(idConocimiento_NEXT, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.dscConocimiento, cBaseDatos.MiTipoDeDatosSQL.Texto) & ")"
      If strPosibleError = "" Then
        strPosibleError = oDB.EjecutarAccion(strSQL)
      End If
      Return strPosibleError
    End Function
    Public Function Editar() As String
      'Objetivo:
      'in
      'out
      ' "" o el error

      Dim oDB As Logica.cBaseDatos
      Dim strSQL As String
      strSQL = "UPDATE tbl_Conocimiento set " & _
      " dscConocimiento=" & Logica.cBaseDatos.xSQL(Me.dscConocimiento, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      " WHERE idConocimiento=" & Logica.cBaseDatos.xSQL(Me.idConocimiento, cBaseDatos.MiTipoDeDatosSQL.Numero)

      Return oDB.EjecutarAccion(strSQL)
    End Function
    Public Function Borrar() As String
      'Objetivo:
      'in
      'out
      ' "" o el error
      'TODO: revisar
      Dim oDB As Logica.cBaseDatos
      Dim strSql As String
      strSql = "DELETE FROM tbl_Conocimiento " & _
      " WHERE idConocimiento=" & Logica.cBaseDatos.xSQL(Me.idConocimiento, cBaseDatos.MiTipoDeDatosSQL.Numero)
      Return oDB.EjecutarAccion(strSql)
    End Function
    Public Function Traer(ByVal idConocimiento As Integer) As DataRow
      'Trae una 
      Dim strWhere As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      If idConocimiento > 0 Then
        strWhere = " WHERE idConocimiento=" & idConocimiento
      End If
      oDT = oDB.EjecutarDataTable("SELECT  idConocimiento , dscConocimiento  FROM tbl_Conocimiento " & strWhere)
      If oDT.Rows.Count <> 0 Then
        Return oDT.Rows(0)
      Else
        Return Nothing
      End If
    End Function

    Public Function TraerTodos(ByVal dscConocimiento As String) As DataTable
      'Trae todos 
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim strWhere As String = ""

      If dscConocimiento <> "" Then
        strWhere = " WHERE dscConocimiento like " & Logica.cBaseDatos.xSQL(dscConocimiento & "%", cBaseDatos.MiTipoDeDatosSQL.Texto)
      End If
      oDT = oDB.EjecutarDataTable("SELECT  idConocimiento , dscConocimiento  FROM tbl_Conocimiento " & strWhere & " ORDER BY 2 ")
      If oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function


    Public Function Existe(ByVal dscConocimiento As String) As Boolean
      'verifica si ya existe un conocimiento
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim strWhere As String = ""

      If dscConocimiento <> "" Then
        strWhere = " WHERE dscConocimiento =" & Logica.cBaseDatos.xSQL(dscConocimiento, cBaseDatos.MiTipoDeDatosSQL.Texto)
      End If
      oDT = oDB.EjecutarDataTable("SELECT  idConocimiento , dscConocimiento  FROM tbl_Conocimiento " & strWhere & " ORDER BY 2 ")
      If oDT.Rows.Count <> 0 Then
        Return True
      Else
        Return False
      End If
    End Function
#End Region
  End Class
End Namespace
