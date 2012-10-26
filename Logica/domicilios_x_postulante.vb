Namespace Logica

  Public Class domicilios_x_postulante

#Region "Variables Privadas, GET, SET "
    Private m_idPostulante As Int32
    Private m_idDomicilio As Int32
    Private m_dscDomicilio As String = ""
    Private m_calle As String = ""
    Private m_nroCalle As String = ""
    Private m_letraBis As String = ""
    Private m_piso As String = ""
    Private m_depto As String = ""
        Private m_pais As Int32 = -1
        Private m_provincia As Int32 = -1
        Private m_localidad As Int32 = -1
    Private m_telParticular As String = ""
    Private m_otrosTelefonos As String = ""

    Public Property idPostulante() As Int32
      Get
        Return m_idPostulante
      End Get
      Set(ByVal Value As Int32)
        m_idPostulante = Value
      End Set
    End Property
    Public Property idDomicilio() As Int32
      Get
        Return m_idDomicilio
      End Get
      Set(ByVal Value As Int32)
        m_idDomicilio = Value
      End Set
    End Property
    Public Property dscDomicilio() As String
      Get
        Return m_dscDomicilio
      End Get
      Set(ByVal Value As String)
        m_dscDomicilio = Value
      End Set
    End Property
    Public Property calle() As String
      Get
        Return m_calle
      End Get
      Set(ByVal Value As String)
        m_calle = Value
      End Set
    End Property
    Public Property nroCalle() As String
      Get
        Return m_nroCalle
      End Get
      Set(ByVal Value As String)
        m_nroCalle = Value
      End Set
    End Property
    Public Property letraBis() As String
      Get
        Return m_letraBis
      End Get
      Set(ByVal Value As String)
        m_letraBis = Value
      End Set
    End Property
    Public Property piso() As String
      Get
        Return m_piso
      End Get
      Set(ByVal Value As String)
        m_piso = Value
      End Set
    End Property
    Public Property depto() As String
      Get
        Return m_depto
      End Get
      Set(ByVal Value As String)
        m_depto = Value
      End Set
    End Property
    Public Property pais() As Int32
      Get
        Return m_pais
      End Get
      Set(ByVal Value As Int32)
        m_pais = Value
      End Set
    End Property
    Public Property provincia() As Int32
      Get
        Return m_provincia
      End Get
      Set(ByVal Value As Int32)
        m_provincia = Value
      End Set
    End Property
    Public Property localidad() As Int32
      Get
        Return m_localidad
      End Get
      Set(ByVal Value As Int32)
        m_localidad = Value
      End Set
    End Property
    Public Property telParticular() As String
      Get
        Return m_telParticular
      End Get
      Set(ByVal Value As String)
        m_telParticular = Value
      End Set
    End Property
    Public Property otrosTelefonos() As String
      Get
        Return m_otrosTelefonos
      End Get
      Set(ByVal Value As String)
        m_otrosTelefonos = Value
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
      strSQL = "INSERT INTO tbl_domicilios_x_postulante (  idpostulante,idDomicilio,dscDomicilio , calle , nroCalle , letraBis , piso , depto , pais , provincia , localidad , telParticular , otrosTelefonos  )  values ( " & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.idDomicilio, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.dscDomicilio, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(Me.calle, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(Me.nroCalle, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(Me.letraBis, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(Me.piso, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(Me.depto, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(Me.pais, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(Me.provincia, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(Me.localidad, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(Me.telParticular, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(Me.otrosTelefonos, cBaseDatos.MiTipoDeDatosSQL.Texto) & ")"
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
      Dim oDT As DataTable
      Dim strSQL As String
      Dim strWhere As String

      strWhere = " WHERE idPostulante=" & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & " AND idDomicilio=" & Logica.cBaseDatos.xSQL(Me.idDomicilio, cBaseDatos.MiTipoDeDatosSQL.Numero)

      If Not IsNothing(Me.Traer(Me.idPostulante, Me.idDomicilio)) Then
        'actualizo
        strSQL = "UPDATE tbl_domicilios_x_postulante set " & _
        " dscDomicilio=" & Logica.cBaseDatos.xSQL(Me.dscDomicilio, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
        ", calle=" & Logica.cBaseDatos.xSQL(Me.calle, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
        ", nroCalle=" & Logica.cBaseDatos.xSQL(Me.nroCalle, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
        ", letraBis=" & Logica.cBaseDatos.xSQL(Me.letraBis, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
        ", piso=" & Logica.cBaseDatos.xSQL(Me.piso, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
        ", depto=" & Logica.cBaseDatos.xSQL(Me.depto, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
        ", pais=" & Logica.cBaseDatos.xSQL(Me.pais, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
        ", provincia=" & Logica.cBaseDatos.xSQL(Me.provincia, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
        ", localidad=" & Logica.cBaseDatos.xSQL(Me.localidad, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
        ", telParticular=" & Logica.cBaseDatos.xSQL(Me.telParticular, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
        ", otrosTelefonos=" & Logica.cBaseDatos.xSQL(Me.otrosTelefonos, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
        strWhere
        Return oDB.EjecutarAccion(strSQL)
      Else
        'inserto 
        Me.Agregar()
      End If

    End Function
    Public Function Borrar() As String
      'Objetivo:
      'in
      'out
      ' "" o el error

      Dim oDB As Logica.cBaseDatos
      Dim strWhere As String
      If idPostulante > 0 AndAlso idDomicilio > 0 Then
        strWhere = " WHERE idPostulante=" & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & " AND idDomicilio=" & Logica.cBaseDatos.xSQL(Me.idDomicilio, cBaseDatos.MiTipoDeDatosSQL.Numero)
      End If
      Dim strSql As String
      strSql = "DELETE FROM tbl_domicilios_x_postulante " & strWhere
      Return oDB.EjecutarAccion(strSql)
    End Function
    Public Function Traer(ByVal idPostulante As Integer, ByVal idDomicilio As Integer) As DataRow
      'Trae una 
      Dim strWhere As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      strWhere = " WHERE idPostulante=" & Logica.cBaseDatos.xSQL(idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & " AND idDomicilio=" & Logica.cBaseDatos.xSQL(idDomicilio, cBaseDatos.MiTipoDeDatosSQL.Numero)

      oDT = oDB.EjecutarDataTable("SELECT  idPostulante , idDomicilio , dscDomicilio , calle , nroCalle , letraBis , piso , depto , pais , provincia , localidad , telParticular , otrosTelefonos  FROM tbl_domicilios_x_postulante " & strWhere & " ORDER BY 1 ")
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT.Rows(0)
      Else
        Return Nothing
      End If
    End Function

#End Region
  End Class

End Namespace