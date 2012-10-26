Namespace Logica

  Public Class tbl_busqueda
#Region "Variables Privadas, GET, SET "
    Private m_idEmpresa As Int32
    Private m_idBusqueda As Int32
    Private m_titulo As String
    Private m_tipoVinculo As Integer
    Private m_strEspecialidad As String
    Private m_fechaDesde As DateTime
    Private m_fechaHasta As DateTime
    Private m_otroRequisitos As String
    Private m_publica As String

    Public Property idEmpresa() As Int32
      Get
        Return m_idEmpresa
      End Get
      Set(ByVal Value As Int32)
        m_idEmpresa = Value
      End Set
    End Property
    Public Property idBusqueda() As Int32
      Get
        Return m_idBusqueda
      End Get
      Set(ByVal Value As Int32)
        m_idBusqueda = Value
      End Set
    End Property
    Public Property titulo() As String
      Get
        Return m_titulo
      End Get
      Set(ByVal Value As String)
        m_titulo = Value
      End Set
    End Property
    Public Property tipoVinculo() As Integer
      Get
        Return m_tipoVinculo
      End Get
      Set(ByVal Value As Integer)
        m_tipoVinculo = Value
      End Set
    End Property
    Public Property strEspecialidad() As String
      Get
        Return m_strEspecialidad
      End Get
      Set(ByVal Value As String)
        m_strEspecialidad = Value
      End Set
    End Property
    Public Property fechaDesde() As DateTime
      Get
        Return m_fechaDesde
      End Get
      Set(ByVal Value As DateTime)
        m_fechaDesde = Value
      End Set
    End Property
    Public Property fechaHasta() As DateTime
      Get
        Return m_fechaHasta
      End Get
      Set(ByVal Value As DateTime)
        m_fechaHasta = Value
      End Set
    End Property
    Public Property otroRequisitos() As String
      Get
        Return m_otroRequisitos
      End Get
      Set(ByVal Value As String)
        m_otroRequisitos = Value
      End Set
    End Property
    Public Property publica() As String
      Get
        Return m_publica
      End Get
      Set(ByVal Value As String)
        m_publica = Value
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
      'TODO: revisar
      Dim oDB As Logica.cBaseDatos
      Dim strPosibleError As String = ""
      Dim strSQL As String = ""
      strSQL = "INSERT INTO tbl_busqueda (  idEmpresa , titulo , tipoVinculo , fechaDesde , fechaHasta , otroRequisitos,strEspecialidad , publica )  values ( " & Logica.cBaseDatos.xSQL(Me.idEmpresa, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.titulo, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(Me.tipoVinculo, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.fechaDesde, cBaseDatos.MiTipoDeDatosSQL.Fecha) & "," & Logica.cBaseDatos.xSQL(Me.fechaHasta, cBaseDatos.MiTipoDeDatosSQL.Fecha) & "," & Logica.cBaseDatos.xSQL(Me.otroRequisitos, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(Me.m_strEspecialidad, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(Me.m_publica, cBaseDatos.MiTipoDeDatosSQL.Texto) & ")"
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
      strSQL = "UPDATE tbl_busqueda set " & _
      " titulo=" & Logica.cBaseDatos.xSQL(Me.titulo, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", tipoVinculo=" & Logica.cBaseDatos.xSQL(Me.tipoVinculo, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      ", strEspecialidad=" & Logica.cBaseDatos.xSQL(Me.m_strEspecialidad, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", fechaDesde=" & Logica.cBaseDatos.xSQL(Me.fechaDesde, cBaseDatos.MiTipoDeDatosSQL.Fecha) & _
      ", fechaHasta=" & Logica.cBaseDatos.xSQL(Me.fechaHasta, cBaseDatos.MiTipoDeDatosSQL.Fecha) & _
      ", otroRequisitos=" & Logica.cBaseDatos.xSQL(Me.otroRequisitos, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", publica=" & Logica.cBaseDatos.xSQL(Me.publica, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      " WHERE " & _
      "  idEmpresa=" & Me.idEmpresa & _
      " AND idBusqueda=" & Me.idBusqueda

      Return oDB.EjecutarAccion(strSQL)
    End Function
    Public Function Borrar() As String
      'Objetivo:Borra el registro
      'in
      'out
      ' "" o el error
      'NOTA: antes tengo que pasarle los valores al objeto
      Dim oDB As Logica.cBaseDatos
      Dim strSql As String
      strSql = "DELETE FROM tbl_busqueda WHERE idBusqueda=" & Me.idBusqueda & " AND idEmpresa=" & Me.idEmpresa
      Me.idBusqueda = 0
      Return oDB.EjecutarAccion(strSql)
    End Function
    Public Function Traer() As DataTable
      'Trae las busquedas de una  o todas las empresas 
      Dim strWhere As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      If Me.idBusqueda > 0 Then
        'busqueda determinada
        strWhere = " WHERE IDBusqueda =" & Me.idBusqueda
      End If

      If Me.idEmpresa > 0 Then
        If strWhere = "" Then
          strWhere = " WHERE "
        Else
          strWhere &= " AND "
        End If
        'Todas las busquedas
        strWhere &= " idEmpresa=" & Me.idEmpresa
      End If

      oDT = oDB.EjecutarDataTable("SELECT  idEmpresa , idBusqueda , titulo , tipoVinculo , fechaDesde , fechaHasta , otroRequisitos ,strEspecialidad , publica FROM tbl_busqueda " & strWhere & " ORDER BY 1 ")
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Public Function TraerTodas(ByVal IDP As Integer) As DataTable
      'sobrecarga
      'NOTA: por defecto la busqueda es 0
      'NOTA: por defecto el campo de orden es ""
      Return Me.TraerTodas(IDP, 0, "")
    End Function
    Public Function TraerTodas(ByVal IDP As Integer, ByVal IDB As Integer) As DataTable
      'sobrecarga
      Return Me.TraerTodas(IDP, IDB, "")
    End Function
    Public Function TraerTodas(ByVal IDP As Integer, ByVal ordenColumna As String) As DataTable
      'sobrecarga
      Return Me.TraerTodas(IDP, 0, ordenColumna)
    End Function
    Public Function TraerTodas(ByVal IDP As Integer, ByVal IDB As Integer, ByVal ordenColumna As String) As DataTable
      'Para el postulante Trae las TODAS las busquedas de TODAS las empresas que SI sean publicas
      'in
      ' IDP= el id del postulante
      ' IDB= el postulante puede filtrar por el nro de busqueda
      Dim strSQl As String
      Dim strWhere As String = ""
      Dim strOrderBy As String = ""

      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      'Siempre traigo SOLO las Publicas
      strWhere = " WHERE GetDate() >= fechaDesde  and GetDate() <= fechaHasta AND (B.publica ='S' )"

      If IDB > 0 Then
        'busqueda determinada
        strWhere = strWhere & " and (B.idBusqueda =" & IDB & " )"
      End If

      'orden de columnas
      Select Case ordenColumna
        Case "Titulo"
          strOrderBy = " titulo "
        Case "Especialidad"
          strOrderBy = " strEspecialidad "
        Case "Estado"
          strOrderBy = " fechaPostulacion "
        Case "Tipo"
          strOrderBy = " dscVinculo "
        Case Else
          strOrderBy = " titulo "
      End Select
      If strOrderBy <> "" Then
        strOrderBy = " ORDER BY " & strOrderBy
      End If

      strSQl = "SELECT idEmpresa, idBusqueda, titulo, tipoVinculo, fechaDesde, fechaHasta, otroRequisitos, strEspecialidad , publica , " & _
              "( SELECT fechaPostulacion FROM  tbl_postulante_x_Busqueda PB WHERE (PB.idBusqueda = B.idBusqueda) AND (idPostulante = " & IDP & ")) as fechaPostulacion , " & _
              "( SELECT motivoExclusion FROM  tbl_postulante_x_Busqueda PB WHERE (PB.idBusqueda = B.idBusqueda) AND (idPostulante = " & IDP & ")) as motivoExclusion,  " & _
              " V.dscVinculo " & _
              " FROM tbl_busqueda B INNER JOIN dbo.tbl_vinculo V ON B.tipoVinculo = V.idVinculo " & strWhere & strOrderBy

      oDT = oDB.EjecutarDataTable(strSQl)
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Public Function PostularseAbusqueda(ByVal idPostulante As Integer) As String
      ' El postulante ser postula para una determinada busqueda
      'in
      ' idPostulante= el id del postulante
      'out
      ' "" o el error
      Dim strPosibleError As String
      Dim strSQl As String
      Dim strWhere As String
      Dim oDT As DataTable
      Dim oDB As Logica.cBaseDatos

      'Verifico YA ESTA POSTULADO
      strSQl = " SELECT fechaPostulacion FROM tbl_postulante_x_Busqueda " & _
              " WHERE (idBusqueda = " & Me.idBusqueda & ") AND (idPostulante = " & idPostulante & ")"
      oDT = oDB.EjecutarDataTable(strSQl)
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        'Error ya esta postulado
        strPosibleError = "Ya esta registrada su postulacion el " & Format(oDT.Rows(0).Item("fechaPostulacion"), "dd/MM/yyyy hh:mm")
      Else
        'registro la postulacion en la fecha de hoy
        strSQl = "INSERT INTO tbl_postulante_x_Busqueda ( idBusqueda, idPostulante, fechaPostulacion) values ( " & Me.idBusqueda & " , " & idPostulante & ", " & Logica.cBaseDatos.xSQL(Now(), cBaseDatos.MiTipoDeDatosSQL.Fecha) & ")"
        strPosibleError = oDB.EjecutarAccion(strSQl)
      End If
      Return strPosibleError
    End Function

#End Region

    Public Function ExcluirPostulanteDeBusqueda(ByVal idBusqueda As Integer, ByVal idPostulante As Integer, ByVal strMotivo As String)
      'registra la exclusion del postulante para una busqueda
      Dim oDB As Logica.cBaseDatos
      Dim strSQL As String = ""
      Dim strPosibleError As String = ""
      strSQL = "  UPDATE tbl_postulante_x_Busqueda SET " & _
                " fechaExclusion=" & Logica.cBaseDatos.xSQL(Now(), cBaseDatos.MiTipoDeDatosSQL.Fecha) & _
                " , motivoExclusion=" & Logica.cBaseDatos.xSQL(strMotivo, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
                " WHERE idBusqueda=" & Logica.cBaseDatos.xSQL(idBusqueda, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
                " AND idPostulante=" & Logica.cBaseDatos.xSQL(idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero)
      strPosibleError = oDB.EjecutarAccion(strSQL)
      Return strPosibleError
    End Function

    Public Function ActualizarFechaEnvio(ByVal idBusqueda As Integer, ByVal strIDSPostulantes As String) As String
      'registra la exclusion del postulante para una busqueda
      Dim oDB As Logica.cBaseDatos
      Dim strSQL As String = ""
      Dim strPosibleError As String = ""

    'si en los ids separados por coma, el ultimo caracter es una coma se la saco
    If strIDSPostulantes.EndsWith(",") Then
        strIDSPostulantes = strIDSPostulantes.Remove(strIDSPostulantes.Length - 1, 1)
    End If
      strSQL = " UPDATE tbl_postulante_x_Busqueda SET " & _
               " fechaEnvioCV=" & Logica.cBaseDatos.xSQL(Now(), cBaseDatos.MiTipoDeDatosSQL.Fecha) & _
               " WHERE idBusqueda=" & Logica.cBaseDatos.xSQL(idBusqueda, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
               " AND idPostulante in (" & strIDSPostulantes & ")"
      strPosibleError = oDB.EjecutarAccion(strSQL)
      Return strPosibleError
    End Function
  End Class


End Namespace

