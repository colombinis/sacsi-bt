Namespace Logica

  Public Class cBaseDatos

    Private Shared oCN As SqlClient.SqlConnection
    Private Shared oCN_SysAcad As SqlClient.SqlConnection
    Private Shared mMutex As New System.Threading.Mutex

    Private Sub New()
      'queda como private
    End Sub

#Region "Coneccion del sistema"
    Protected Friend Shared Function CN() As SqlClient.SqlConnection
      'mMutex.WaitOne()
      If oCN Is Nothing Then
        Dim mCS As String
        mCS = Logica.cUtil.strCadenaConeccion
        oCN = New SqlClient.SqlConnection(mCS)
        oCN.Open()
      End If
      'mMutex.ReleaseMutex()
      Return oCN
    End Function

#End Region

#Region "Coneccion al sysacad"

    Protected Friend Shared Function CN_SysAcad() As SqlClient.SqlConnection
      'mMutex.WaitOne()
      If oCN_SysAcad Is Nothing Then
        ''' "PROVIDER=SQLOLEDB;DATA SOURCE=srvsql;UID=usrsysacad;PWD=piojos1298;DATABASE=db_sysacad"
        Dim mCS As String = "Data Source=srvsql" & _
                 ";Initial catalog=db_sysacad" & _
                 ";User id=usrsysacad" & _
                 ";Password=piojos1298" & _
                 ";Connection TimeOut=10;"
        oCN_SysAcad = New SqlClient.SqlConnection(mCS)
        oCN_SysAcad.Open()
      End If
      'mMutex.ReleaseMutex()
      Return oCN_SysAcad
    End Function

#End Region

    Protected Friend Shared Sub Dispose()
      If Not oCN Is Nothing Then
        If oCN.State <> ConnectionState.Closed Then oCN.Close()
        oCN.Dispose()
        oCN = Nothing
      End If

      If Not oCN_SysAcad Is Nothing Then
        If oCN_SysAcad.State <> ConnectionState.Closed Then oCN_SysAcad.Close()
        oCN_SysAcad.Dispose()
        oCN_SysAcad = Nothing
      End If
    End Sub


#Region "Consultas y acciones a la Base del sistema"

    Protected Friend Shared Function EjecutarScalar(ByVal strNombreSP As String, ByVal parametros() As Object) As Long
      'objetivo: Ejecuta el SP
      'in
      '   strNombreSP: El nombre del SP
      '   parametros: el array de parametros
      'out
      '   el valor o -1 si hay error
      Dim valRet As Long

      Dim oSql As Microsoft.ApplicationBlocks.Data.SqlHelper

      Try

        valRet = oSql.ExecuteScalar(CN, strNombreSP, parametros)
        Return valRet
      Catch ex As Exception
        'devuelve 
        Return -1
      End Try

    End Function

    Protected Friend Shared Function EjecutarScalar(ByVal strSql As String) As Long
      'objetivo: Ejecuta la accion SQL
      'in
      '   strSql: La cadena SQL a ejecutar
      'out
      '   el valor o -1 si hay error
      Dim valRet As Long

      Dim oSql As Microsoft.ApplicationBlocks.Data.SqlHelper

      Try

        valRet = oSql.ExecuteScalar(CN, CommandType.Text, strSql)
        Return valRet
      Catch ex As Exception
        'devuelve 
        Return -1
      End Try

    End Function

    Protected Friend Shared Function EjecutarDataTable(ByVal strSql As String) As DataTable
      'objetivo: Ejecuta la accion SQL
      'in
      '   strSql: La cadena SQL a ejecutar
      'out
      '   la tabla o nada si hay error
      Dim oSql As Microsoft.ApplicationBlocks.Data.SqlHelper
      Dim oDT As DataTable

      Try
        'retorna la primera tabla del conjunto 
        oDT = oSql.ExecuteDataset(CN, CommandType.Text, strSql).Tables(0)
        Return oDT
      Catch ex As Exception
        Logica.cUtil.XML_Logerror("strSql", ex.Message)
        'devuelve 
        Return Nothing
      End Try
    End Function

    Protected Friend Shared Function EjecutarAccion(ByVal strSql As String) As String
      'objetivo: Ejecuta la accion SQL
      'in
      '   strSql: La cadena SQL a ejecutar
      'out
      '   "" o el error
      Dim oSql As Microsoft.ApplicationBlocks.Data.SqlHelper

      Try
        oSql.ExecuteNonQuery(CN, CommandType.Text, strSql)
        'retorna vacio
        Return ""
      Catch ex As Exception
        Logica.cUtil.XML_Logerror("strSql", ex.Message)
        'devuelve 
        Return ex.Message
      End Try
    End Function


#End Region

#Region "Consultas y acciones a la Base del SysAcad"

    Protected Friend Shared Function EjecutarDataTable_SysAcad(ByVal strSql As String) As DataTable
      'objetivo: Ejecuta la accion SQL creando una coneccion al sysacad
      'in
      '   strSql: La cadena SQL a ejecutar
      'out
      '   la tabla o nada si hay error
      Dim oSql As Microsoft.ApplicationBlocks.Data.SqlHelper
      Dim oDT As DataTable

      Try
        'retorna la primera tabla del conjunto 
        oDT = oSql.ExecuteDataset(CN_SysAcad, CommandType.Text, strSql).Tables(0)
        Return oDT
      Catch ex As Exception
        Logica.cUtil.XML_Logerror("strSqlSysAcad", ex.Message)
        'devuelve 
        Return Nothing
      End Try
    End Function

#End Region


#Region "metodos relacionadas con la BDatos"

    Protected Friend Enum MiTipoDeDatosSQL
      Texto = 1
      Numero = 2
      Fecha = 3
      Booleano = 4
    End Enum
    Protected Friend Enum MisMotoresDB
      SQLserver = 1
      Access2000 = 2
    End Enum

    Protected Friend Shared Function xSQL(ByVal strValorTemp As Object, ByVal ElTipoDato As MiTipoDeDatosSQL, Optional ByVal MotorSQL As MisMotoresDB = MisMotoresDB.SQLserver) As String
      'objetivo: modifica los valores SQL
      'in
      '   strValorTemp: el valor a verificar el SQL
      '   strTipoDato: el tipo de dato
      'out
      Dim strValor As String

      'verifico si es nulo
      If strValorTemp Is System.DBNull.Value Then
        strValorTemp = "null"
      End If
      strValor = CType(strValorTemp, String)

      Select Case ElTipoDato
        Case MiTipoDeDatosSQL.Texto
          'saco los valores que pueden causar que no se ejecute bien el SQL
          strValor.Replace("'", "")

          'concateno las comillas simples
          Return "'" & strValor & "'"
        Case MiTipoDeDatosSQL.Numero
          'reemplazo la coma por punto
          strValor = strValor
          Return strValor.Replace(",", ".")
        Case MiTipoDeDatosSQL.Fecha
          'segun el motor de base de datos
          Select Case MotorSQL
            Case MisMotoresDB.SQLserver
              'concateno las comillas y coloco formato MM/dd/yyyy HH:mm
              Return "'" & CDate(strValor).Month & "/" & CDate(strValor).Day & "/" & CDate(strValor).Year & " " & CDate(strValor).Hour & ":" & CDate(strValor).Minute & "'"
            Case MisMotoresDB.Access2000
              'concateno los cardinales y coloco formato mm/dd/yyyy
              Return "#" & CDate(strValor).Month & "/" & CDate(strValor).Day & "/" & CDate(strValor).Year & "#"
          End Select

      End Select
    End Function

#End Region

  End Class
End Namespace
