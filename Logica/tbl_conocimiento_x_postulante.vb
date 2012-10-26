Namespace Logica

  Public Class tbl_conocimiento_x_postulante

#Region "Variables Privadas, GET, SET "
    Private m_idPostulante As Int32
    Private m_idConocimiento As Int32
    Private m_idvalor As Int32
    Public Property idPostulante() As Int32
      Get
        Return m_idPostulante
      End Get
      Set(ByVal Value As Int32)
        m_idPostulante = Value
      End Set
    End Property
    Public Property idConocimiento() As Int32
      Get
        Return m_idConocimiento
      End Get
      Set(ByVal Value As Int32)
        m_idConocimiento = Value
      End Set
    End Property
    Public Property idvalor() As Int32
      Get
        Return m_idvalor
      End Get
      Set(ByVal Value As Int32)
        m_idvalor = Value
      End Set
    End Property
#End Region
#Region "Funciones ABM "

    Public Sub New()
      'constructor vacio
    End Sub

    Public Function AgregarMasivo(ByVal strValores As String) As String
      'Objetivo:
      'in
      'out
      ' "" o el error
      'NOTA: strValores viene con el formato "idConocimiento,idValor|"  ej:"1,3|1,3|1,3"
      Dim oDB As Logica.cBaseDatos
      Dim strPosibleError As String = ""
      Dim strSQL As String = ""
      Dim strRenglon() As String
      Dim valores() As String
      Dim i As Integer
      'verifico si viene mas de uno
      If InStr(strValores, "|") > 0 Then
        'vienen mas de un valor
        strRenglon = strValores.Split("|")
        For i = 0 To strRenglon.GetUpperBound(0)
          valores = strRenglon(i).Split(",")
          strSQL &= "INSERT INTO tbl_conocimiento_x_postulante (  idPostulante , idConocimiento , idvalor  )  values ( " & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(valores(0), cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(valores(1), cBaseDatos.MiTipoDeDatosSQL.Numero) & ")" & vbNewLine
        Next
      Else
        'viene un solo valor
        valores = strValores.Split(",")
        strSQL = "INSERT INTO tbl_conocimiento_x_postulante (  idPostulante , idConocimiento , idvalor  )  values ( " & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(valores(0), cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(valores(1), cBaseDatos.MiTipoDeDatosSQL.Numero) & ")"
      End If

      If strPosibleError = "" Then
        strPosibleError = oDB.EjecutarAccion(strSQL)
      End If
      Return strPosibleError
    End Function
    Public Function Borrar(ByVal strconocimiento_Valor As String) As String
      'Objetivo: borra todos los conocimientos del idpostulante
      'in
      ' strconocimiento_Valor= viene de la forma "conocimiento,valor"
      'out
      ' "" o el error
      Dim oDB As Logica.cBaseDatos
      Dim strSql As String
      Dim valores() As String
      valores = strconocimiento_Valor.Split(",")
      strSql = "DELETE FROM tbl_conocimiento_x_postulante WHERE idPostulante=" & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & " AND idConocimiento=" & Logica.cBaseDatos.xSQL(valores(0), cBaseDatos.MiTipoDeDatosSQL.Numero)
      Return oDB.EjecutarAccion(strSql)
    End Function

    Public Function TraerTodos() As DataTable
      'Trae todos los conocimientos segun el idpostulante cargado
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim strSQL As String
      'strSQL = "SELECT  idConocimiento , idvalor  FROM tbl_conocimiento_x_postulante WHERE idPostulante=" & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & " ORDER BY 1 "
      strSQL = "SELECT CP.idConocimiento, C.dscConocimiento, CP.idvalor, V.dscValor, CP.idPostulante FROM dbo.tbl_conocimiento_x_postulante CP INNER JOIN dbo.tbl_Conocimiento C ON CP.idConocimiento = C.idConocimiento INNER JOIN dbo.tbl_valorConocimiento V ON CP.idvalor = V.idValor WHERE CP.idPostulante=" & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & " ORDER BY C.dscConocimiento"
      oDT = oDB.EjecutarDataTable(strSQL)

      If oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function
#End Region
  End Class
End Namespace
