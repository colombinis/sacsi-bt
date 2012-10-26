Namespace Logica
    Public Enum Estado_de_cuota
        vigente = 1
        vencida = 2
        pagada = 3
        Anticipada = 4
        eliminada = 5
    End Enum


    Public Class tbl_cuotasEmpresa

#Region "Variables Privadas, GET, SET "
        Private m_idCuota As Int32
        Private m_fechaVto1 As Date
        Private m_dscConcepto As String
        Private m_valor As Double
        Private m_idEstadoCuota As Int32
        Private m_idEmpresa As Int32
        Private m_idBusqueda As Int32
        Private m_idPostulante As Int32
        Public Property idCuota() As Int32
            Get
                Return m_idCuota
            End Get
            Set(ByVal Value As Int32)
                m_idCuota = Value
            End Set
        End Property
        Public Property fechaVto1() As Date
            Get
                Return m_fechaVto1
            End Get
            Set(ByVal Value As Date)
                m_fechaVto1 = Value
            End Set
        End Property
        Public Property dscConcepto() As String
            Get
                Return m_dscConcepto
            End Get
            Set(ByVal Value As String)
                m_dscConcepto = Value
            End Set
        End Property
        Public Property valor() As Double
            Get
                Return m_valor
            End Get
            Set(ByVal Value As Double)
                m_valor = Value
            End Set
        End Property
        Public Property idEstadoCuota() As Int32
            Get
                Return m_idEstadoCuota
            End Get
            Set(ByVal Value As Int32)
                m_idEstadoCuota = Value
            End Set
        End Property
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
        Public Property idPostulante() As Int32
            Get
                Return m_idPostulante
            End Get
            Set(ByVal Value As Int32)
                m_idPostulante = Value
            End Set
        End Property
#End Region

#Region "Funciones ABM "

        Public Sub New()
            'constructor vacio
        End Sub

        Public Function AgregarMasivo(ByVal strFechasValores As String) As String
            'Objetivo:
            'in
            '   strFechasValores =con el siguiente formato 'dd/MM/yyyy¦valor|  ej: '01/01/2006¦15.23|01/02/2006¦40.23'
            'out
            ' "" o el error

            'NOTA: el idempresa, postulante , busqueda y description lo precargo
            '       el estado por defecto de la cuota es vigente
            Dim oDB As Logica.cBaseDatos
            Dim strPosibleError As String = ""
            Dim strSQL As String = ""
            Dim strValores() As String
            Dim strRenglon() As String
            'verifico si viene mas de una fecha separada por |
            If InStr(strFechasValores, "|") > 0 Then
                'vienen mas de una cuota
                strRenglon = strFechasValores.Split("|")
                Dim i As Integer
                For i = 0 To strRenglon.GetUpperBound(0)
                    strValores = strRenglon(i).Split("¦")
                    strSQL &= "INSERT INTO tbl_cuotasEmpresa (  fechaVto1 , dscConcepto , valor , idEstadoCuota , idEmpresa , idBusqueda , idPostulante  )  values ( " & Logica.cBaseDatos.xSQL(strValores(0), cBaseDatos.MiTipoDeDatosSQL.Fecha) & "," & Logica.cBaseDatos.xSQL(Me.dscConcepto, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(strValores(1), cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Logica.Estado_de_cuota.vigente, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.idEmpresa, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.idBusqueda, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & ")" & vbNewLine
                Next
            Else
                'viene una sola cuota
                strValores = strFechasValores.Split("¦")
                strSQL = "INSERT INTO tbl_cuotasEmpresa (  fechaVto1 , dscConcepto , valor , idEstadoCuota , idEmpresa , idBusqueda , idPostulante  )  values ( " & Logica.cBaseDatos.xSQL(strValores(0), cBaseDatos.MiTipoDeDatosSQL.Fecha) & "," & Logica.cBaseDatos.xSQL(Me.dscConcepto, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(strValores(1), cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Logica.Estado_de_cuota.vigente, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.idEmpresa, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.idBusqueda, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & ")"
            End If

            If strPosibleError = "" Then
                strPosibleError = oDB.EjecutarAccion(strSQL)
            End If
            Return strPosibleError
    End Function

    Public Function Agregar() As String
      'Objetivo:
      'in
      'out
      ' "" o el error

      Dim oDB As Logica.cBaseDatos
      Dim strPosibleError As String = ""
      Dim strSQL As String = ""
      strSQL = "INSERT INTO tbl_cuotasEmpresa (  fechaVto1 , dscConcepto , valor , idEstadoCuota , idEmpresa , idBusqueda , idPostulante  )  values ( " & Logica.cBaseDatos.xSQL(Me.fechaVto1, cBaseDatos.MiTipoDeDatosSQL.Fecha) & "," & Logica.cBaseDatos.xSQL(Me.dscConcepto, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & Logica.cBaseDatos.xSQL(Me.valor, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.idEstadoCuota, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.idEmpresa, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.idBusqueda, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & ")"
      If strPosibleError = "" Then
        strPosibleError = oDB.EjecutarAccion(strSQL)
      End If
      Return strPosibleError
    End Function

    '''Public Function Editar() As String
    '''    'Objetivo:
    '''    'in
    '''    'out
    '''    ' "" o el error
    '''    'TODO: revisar
    '''    Dim oDB As Logica.cBaseDatos
    '''    Dim strSQL As String
    '''    strSQL = "UPDATE tbl_cuotasEmpresa set " & _
    '''  "  idCuota=" & Logica.cBaseDatos.xSQL(Me.idCuota, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
    '''  ", fechaVto1=" & Logica.cBaseDatos.xSQL(Me.fechaVto1, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
    '''  ", dscConcepto=" & Logica.cBaseDatos.xSQL(Me.dscConcepto, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
    '''  ", valor=" & Logica.cBaseDatos.xSQL(Me.valor, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
    '''  ", idEstadoCuota=" & Logica.cBaseDatos.xSQL(Me.idEstadoCuota, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
    '''  ", idEmpresa=" & Logica.cBaseDatos.xSQL(Me.idEmpresa, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
    '''  ", idBusqueda=" & Logica.cBaseDatos.xSQL(Me.idBusqueda, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
    '''  ", idPostulante=" & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Texto)

    '''    Return oDB.EjecutarAccion(strSQL)
    '''End Function
    '''Public Function Borrar() As String
    '''    'Objetivo:
    '''    'in
    '''    'out
    '''    ' "" o el error
    '''    'TODO: revisar
    '''    Dim oDB As Logica.cBaseDatos
    '''    Dim strSql As String
    '''    strSql = "DELETE FROM tbl_cuotasEmpresa WHERE"
    '''    Return oDB.EjecutarAccion(strSql)
    '''End Function
    '''Public Function Traer(ByVal ID As Integer) As DataRow
    '''    'Trae una 
    '''    Dim strWhere As String
    '''    Dim oDB As Logica.cBaseDatos
    '''    Dim oDT As DataTable

    '''    If ID > 0 Then
    '''        strWhere = " WHERE ID=" & ID
    '''    End If
    '''    oDT = oDB.EjecutarDataTable("SELECT  idCuota , fechaVto1 , dscConcepto , valor , idEstadoCuota , idEmpresa , idBusqueda , idPostulante  FROM tbl_cuotasEmpresa " & strWhere & " ORDER BY 1 ")
    '''    If oDT.Rows.Count <> 0 Then
    '''        Return oDT.Rows(0)
    '''    Else
    '''        Return Nothing
    '''    End If
    '''End Function

    Public Function TraerUna(Optional ByVal idCuota As Integer = 0) As DataRow
      'Trae una cuota por id
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim strwhere As String = ""

      If idCuota > 0 Then
        strwhere = " WHERE idCuota=" & Logica.cBaseDatos.xSQL(idCuota, cBaseDatos.MiTipoDeDatosSQL.Numero)
      End If

      oDT = oDB.EjecutarDataTable("SELECT  idCuota , fechaVto1 , dscConcepto , valor , idEstadoCuota , idEmpresa , idBusqueda , idPostulante  FROM tbl_cuotasEmpresa " & strwhere & " ORDER BY 1 ")

      If oDT.Rows.Count <> 0 Then
        Return oDT.Rows(0)
      Else
        Return Nothing
      End If
    End Function

    Public Function Traer(Optional ByVal idEmpresa As Integer = 0) As DataTable
      'Trae todos las cuotas o las de determinada empresa 
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim strwhere As String = ""

      If idEmpresa > 0 Then
        strwhere = " WHERE C.idempresa=" & Logica.cBaseDatos.xSQL(idEmpresa, cBaseDatos.MiTipoDeDatosSQL.Numero)
      End If

      oDT = oDB.EjecutarDataTable("SELECT  C.idCuota , C.fechaVto1 , C.dscConcepto , C.valor , C.idEstadoCuota , C.idEmpresa , C.idBusqueda , C.idPostulante  , E.dscEstadoCuota FROM dbo.tbl_cuotasEmpresa C INNER JOIN dbo.tbl_estadoCuota E ON C.idEstadoCuota = E.idEstadoCuota " & strwhere & " ORDER BY 1 ")

      If oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Public Function EditarEstado() As String
      'Objetivo: cambia SOLO el estado de la cuota
      'in
      'out
      ' "" o el error
      'NOTA: antes debo pasarles los valores al objeto
      Dim oDB As Logica.cBaseDatos
      Dim strSQL As String
      strSQL = "UPDATE tbl_cuotasEmpresa set " & _
                " idEstadoCuota=" & Logica.cBaseDatos.xSQL(Me.idEstadoCuota, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
                " WHERE idCuota=" & Logica.cBaseDatos.xSQL(Me.idCuota, cBaseDatos.MiTipoDeDatosSQL.Numero)
      Return oDB.EjecutarAccion(strSQL)
    End Function


#End Region

  End Class
End Namespace