Namespace Logica
  Public Class tbl_RelacionPostulante_Empresa
#Region "Variables Privadas, GET, SET "
    Private m_idBusqueda As Integer
    Private m_idPostulante As Integer
    Private m_idEmpresa As Integer
    Private m_fechaInicio As Date
    Private m_fechaFin As Date
    Private m_tipovinculo As Integer
    Public Property idBusqueda() As Integer
      Get
        Return m_idBusqueda
      End Get
      Set(ByVal Value As Integer)
        m_idBusqueda = Value
      End Set
    End Property
    Public Property idPostulante() As Integer
      Get
        Return m_idPostulante
      End Get
      Set(ByVal Value As Integer)
        m_idPostulante = Value
      End Set
    End Property
    Public Property idEmpresa() As Integer
      Get
        Return m_idEmpresa
      End Get
      Set(ByVal Value As Integer)
        m_idEmpresa = Value
      End Set
    End Property
    Public Property fechaInicio() As Date
      Get
        Return m_fechaInicio
      End Get
      Set(ByVal Value As Date)
        m_fechaInicio = Value
      End Set
    End Property
    Public Property fechaFin() As Date
      Get
        Return m_fechaFin
      End Get
      Set(ByVal Value As Date)
        m_fechaFin = Value
      End Set
    End Property
    Public Property tipovinculo() As Integer
      Get
        Return m_tipovinculo
      End Get
      Set(ByVal Value As Integer)
        m_tipovinculo = Value
      End Set
    End Property
#End Region
#Region "Funciones ABM "

    Public Sub New()
      'constructor vacio
    End Sub


    Public Function Actualizar() As String
      'Agrego o actualizo segun exista o no la relacion en la tabla
      Dim oDR As DataRow = Me.Traer(Me.idBusqueda, Me.idEmpresa, Me.idPostulante)

      If IsNothing(oDR) Then
        'No estan, entonces inserto y actualizo la tabla del postulante_x_busqueda
        Return Me.Agregar
      Else
        'Si estan Actualizo
        Return Me.Editar
      End If
    End Function

    Public Function Agregar() As String
      'Objetivo:
      'in
      'out
      ' "" o el error

      Dim oDB As Logica.cBaseDatos
      Dim strPosibleError As String = ""
      Dim strSQL As String = ""
      strSQL = "INSERT INTO tbl_RelacionPostulante_Empresa (  idbusqueda, idPostulante , idEmpresa , fechaInicio , fechaFin , tipovinculo  )  values ( " & Logica.cBaseDatos.xSQL(Me.idBusqueda, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.idEmpresa, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & Logica.cBaseDatos.xSQL(Me.fechaInicio, cBaseDatos.MiTipoDeDatosSQL.Fecha) & "," & Logica.cBaseDatos.xSQL(Me.fechaFin, cBaseDatos.MiTipoDeDatosSQL.Fecha) & "," & Logica.cBaseDatos.xSQL(Me.tipovinculo, cBaseDatos.MiTipoDeDatosSQL.Numero) & ")"
      If strPosibleError = "" Then
        strPosibleError = oDB.EjecutarAccion(strSQL)
      End If

      'actualizo la tabla de la postulacion 
      strSQL = "UPDATE  tbl_postulante_x_busqueda set " & _
      " fechaVinculacion= " & Logica.cBaseDatos.xSQL(Now(), cBaseDatos.MiTipoDeDatosSQL.Fecha) & _
      " WHERE idbusqueda=" & Logica.cBaseDatos.xSQL(Me.idBusqueda, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      " AND idpostulante=" & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero)
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
      strSQL = "UPDATE tbl_RelacionPostulante_Empresa set " & _
    " fechaInicio=" & Logica.cBaseDatos.xSQL(Me.fechaInicio, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
    " , fechaFin=" & Logica.cBaseDatos.xSQL(Me.fechaFin, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
    " , tipovinculo=" & Logica.cBaseDatos.xSQL(Me.tipovinculo, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
    " WHERE     " & _
    " (idPostulante = " & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & ") AND " & _
    " (idEmpresa = " & Logica.cBaseDatos.xSQL(Me.idEmpresa, cBaseDatos.MiTipoDeDatosSQL.Numero) & ") AND " & _
    " (idbusqueda = " & Logica.cBaseDatos.xSQL(Me.idBusqueda, cBaseDatos.MiTipoDeDatosSQL.Numero) & ")"

      Return oDB.EjecutarAccion(strSQL)
    End Function

    Public Function Traer(ByVal IDBusqueda As Integer, ByVal IDEmpresa As Integer, ByVal IDPostulante As Integer) As DataRow
      'Trae una 
      Dim strSQL As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      strSQL = " SELECT idBusqueda, idPostulante, idEmpresa, fechaInicio, fechaFin, tipovinculo " & _
                  " FROM tbl_RelacionPostulante_Empresa " & _
                  " WHERE     (idPostulante = " & Logica.cBaseDatos.xSQL(IDPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero) & ") AND " & _
                  " (idEmpresa = " & Logica.cBaseDatos.xSQL(IDEmpresa, cBaseDatos.MiTipoDeDatosSQL.Numero) & ") AND " & _
                  " (idbusqueda = " & Logica.cBaseDatos.xSQL(IDBusqueda, cBaseDatos.MiTipoDeDatosSQL.Numero) & ")"
      oDT = oDB.EjecutarDataTable(strSQL)

      If oDT.Rows.Count <> 0 Then
        Return oDT.Rows(0)
      Else
        Return Nothing
      End If
    End Function

    Public Function TraerEmpresa(ByVal IDbusqueda As Integer) As DataRow
      'Trae la empresa que solicito una busqueda 
      Dim strSQL As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      If IDbusqueda <= 0 Then Return Nothing

      strSQL = "SELECT E.idEmpresa, E.cuit, E.razonSocial, E.domicilio, E.telefonos, E.email, E.web, E.personaContacto, E.tipoEmpresa, E.fechaAlta, E.idEstadoEmpresa,  B.idBusqueda " & _
            " FROM         dbo.tbl_busqueda B INNER JOIN dbo.tbl_empresa E ON B.idEmpresa = E.idEmpresa " & _
            " WHERE(B.idBusqueda =" & Logica.cBaseDatos.xSQL(IDbusqueda, cBaseDatos.MiTipoDeDatosSQL.Numero) & ")"

      oDT = oDB.EjecutarDataTable(strSQL)
      If oDT.Rows.Count <> 0 Then
        Return oDT.Rows(0)
      Else
        Return Nothing
      End If
    End Function
#End Region
  End Class
End Namespace
