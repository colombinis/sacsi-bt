Imports System.Text

Namespace Logica


  Public Class tbl_postulante
#Region "Variables Privadas, GET, SET "
    Private m_idPostulante As Int32
    Private m_usuario As String
    Private m_fechaAltaSistema As DateTime
    Private m_email As String = ""
    Private m_nroLegajo As Int32
    Private m_tipoDoc As Int32 = -1
    Private m_nroDoc As String = ""
    Private m_apellido As String = ""
    Private m_nombres As String = ""
    Private m_nroCuil As String = ""
    Private m_fechaNacimiento As DateTime
    Private m_sexo As Int32 = -1
    Private m_idDomicilioFamiliar As Int32
    Private m_idDomicilioActual As Int32
    Private m_fecUltMateriaAprobada As DateTime
    Private m_dscUltMateriaAprobada As String = ""
    Private m_idEspecialidad As Int32 = -1
    Private m_cantMateriasAprobadas As Int32
    Private m_planEspecialidad As String = ""
    Private m_anioCursa As Int32 = -1
    Private m_turnoCursa As String = "-1"
    Private m_promConAplazos As Double
    Private m_promSinAplazos As Double
    Private m_matRegExamenPend As Int32
    Private m_tituloUniversitario As String = ""
    Private m_titulosecundario As String = ""
    Private m_archivoFoto As String = ""
    Private m_archivoCV As String = ""
    Private m_otrosComentarios As String = ""
    Private m_emailalternativo As String = ""
    Private m_estadoCivil As Int32 = -1

    Public Property idPostulante() As Int32
      Get
        Return m_idPostulante
      End Get
      Set(ByVal Value As Int32)
        m_idPostulante = Value
      End Set
    End Property

    Public Property usuario() As String
      Get
        Return m_usuario
      End Get
      Set(ByVal Value As String)
        m_usuario = Value
      End Set
    End Property


    Public Property fechaAltaSistema() As DateTime
      Get
        Return m_fechaAltaSistema
      End Get
      Set(ByVal Value As DateTime)
        m_fechaAltaSistema = Value
      End Set
    End Property

    Public Property email() As String
      Get
        Return m_email
      End Get
      Set(ByVal Value As String)
        m_email = Value
      End Set
    End Property
    Public Property nroLegajo() As Int32
      Get
        Return m_nroLegajo
      End Get
      Set(ByVal Value As Int32)
        m_nroLegajo = Value
      End Set
    End Property
    Public Property tipoDoc() As Int32
      Get
        Return m_tipoDoc
      End Get
      Set(ByVal Value As Int32)
        m_tipoDoc = Value
      End Set
    End Property
    Public Property nroDoc() As String
      Get
        Return m_nroDoc
      End Get
      Set(ByVal Value As String)
        m_nroDoc = Value
      End Set
    End Property
    Public Property apellido() As String
      Get
        Return m_apellido
      End Get
      Set(ByVal Value As String)
        m_apellido = Value
      End Set
    End Property
    Public Property nombres() As String
      Get
        Return m_nombres
      End Get
      Set(ByVal Value As String)
        m_nombres = Value
      End Set
    End Property
    Public Property nroCuil() As String
      Get
        Return m_nroCuil
      End Get
      Set(ByVal Value As String)
        m_nroCuil = Value
      End Set
    End Property
    Public Property fechaNacimiento() As DateTime
      Get
        Return m_fechaNacimiento
      End Get
      Set(ByVal Value As DateTime)
        m_fechaNacimiento = Value
      End Set
    End Property
    Public Property sexo() As Int32
      Get
        Return m_sexo
      End Get
      Set(ByVal Value As Int32)
        m_sexo = Value
      End Set
    End Property
    Public Property idDomicilioFamiliar() As Int32
      Get
        Return m_idDomicilioFamiliar
      End Get
      Set(ByVal Value As Int32)
        m_idDomicilioFamiliar = Value
      End Set
    End Property
    Public Property idDomicilioActual() As Int32
      Get
        Return m_idDomicilioActual
      End Get
      Set(ByVal Value As Int32)
        m_idDomicilioActual = Value
      End Set
    End Property
    Public Property fecUltMateriaAprobada() As DateTime
      Get
        Return m_fecUltMateriaAprobada
      End Get
      Set(ByVal Value As DateTime)
        m_fecUltMateriaAprobada = Value
      End Set
    End Property
    Public Property dscUltMateriaAprobada() As String
      Get
        Return m_dscUltMateriaAprobada
      End Get
      Set(ByVal Value As String)
        m_dscUltMateriaAprobada = Value
      End Set
    End Property
    Public Property idEspecialidad() As Int32
      Get
        Return m_idEspecialidad
      End Get
      Set(ByVal Value As Int32)
        m_idEspecialidad = Value
      End Set
    End Property
    Public Property cantMateriasAprobadas() As Int32
      Get
        Return m_cantMateriasAprobadas
      End Get
      Set(ByVal Value As Int32)
        m_cantMateriasAprobadas = Value
      End Set
    End Property
    Public Property planEspecialidad() As String
      Get
        Return m_planEspecialidad
      End Get
      Set(ByVal Value As String)
        m_planEspecialidad = Value
      End Set
    End Property
    Public Property anioCursa() As Int32
      Get
        Return m_anioCursa
      End Get
      Set(ByVal Value As Int32)
        m_anioCursa = Value
      End Set
    End Property
    Public Property turnoCursa() As String
      Get
        Return m_turnoCursa
      End Get
      Set(ByVal Value As String)
        m_turnoCursa = Value
      End Set
    End Property
    Public Property promConAplazos() As Double
      Get
        Return m_promConAplazos
      End Get
      Set(ByVal Value As Double)
        m_promConAplazos = Value
      End Set
    End Property
    Public Property promSinAplazos() As Double
      Get
        Return m_promSinAplazos
      End Get
      Set(ByVal Value As Double)
        m_promSinAplazos = Value
      End Set
    End Property
    Public Property matRegExamenPend() As Int32
      Get
        Return m_matRegExamenPend
      End Get
      Set(ByVal Value As Int32)
        m_matRegExamenPend = Value
      End Set
    End Property
    Public Property tituloUniversitario() As String
      Get
        Return m_tituloUniversitario
      End Get
      Set(ByVal Value As String)
        m_tituloUniversitario = Value
      End Set
    End Property
    Public Property titulosecundario() As String
      Get
        Return m_titulosecundario
      End Get
      Set(ByVal Value As String)
        m_titulosecundario = Value
      End Set
    End Property
    Public Property archivoFoto() As String
      Get
        Return m_archivoFoto
      End Get
      Set(ByVal Value As String)
        m_archivoFoto = Value
      End Set
    End Property
    Public Property archivoCV() As String
      Get
        Return m_archivoCV
      End Get
      Set(ByVal Value As String)
        m_archivoCV = Value
      End Set
    End Property
    Public Property otrosComentarios() As String
      Get
        Return m_otrosComentarios
      End Get
      Set(ByVal Value As String)
        m_otrosComentarios = Value
      End Set
    End Property

    Public Property emailalternativo() As String
      Get
        Return m_emailalternativo
      End Get
      Set(ByVal Value As String)
        m_emailalternativo = Value
      End Set
    End Property

    Public Property estadoCivil() As Int32
      Get
        Return m_estadoCivil
      End Get
      Set(ByVal Value As Int32)
        m_estadoCivil = Value
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
      strSQL = "INSERT INTO tbl_postulante (  fechaAltaSistema , usuario ,  email , nroLegajo , tipoDoc , nroDoc , apellido , nombres , nroCuil , fechaNacimiento , sexo , idDomicilioFamiliar , idDomicilioActual , fecUltMateriaAprobada , dscUltMateriaAprobada , idEspecialidad , cantMateriasAprobadas , planEspecialidad , anioCursa , turnoCursa , promConAplazos , promSinAplazos , matRegExamenPend , tituloUniversitario , titulosecundario , archivoFoto , archivoCV , otrosComentarios, estadoCivil, emailAlternativo, fechaUltimaActualizacion  )  values ( " & _
      Logica.cBaseDatos.xSQL(Me.fechaAltaSistema, cBaseDatos.MiTipoDeDatosSQL.Fecha) & "," & _
      Logica.cBaseDatos.xSQL(Me.usuario, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & _
      Logica.cBaseDatos.xSQL(Me.email, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & _
      Logica.cBaseDatos.xSQL(Me.nroLegajo, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & _
      Logica.cBaseDatos.xSQL(Me.tipoDoc, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & _
      Logica.cBaseDatos.xSQL(Me.nroDoc, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & _
      Logica.cBaseDatos.xSQL(Me.apellido, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & _
      Logica.cBaseDatos.xSQL(Me.nombres, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & _
      Logica.cBaseDatos.xSQL(Me.nroCuil, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & _
      Logica.cBaseDatos.xSQL(Me.fechaNacimiento, cBaseDatos.MiTipoDeDatosSQL.Fecha) & "," & _
      Logica.cBaseDatos.xSQL(Me.sexo, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & _
      Logica.cBaseDatos.xSQL(Me.idDomicilioFamiliar, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & _
      Logica.cBaseDatos.xSQL(Me.idDomicilioActual, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & _
      Logica.cBaseDatos.xSQL(Me.fecUltMateriaAprobada, cBaseDatos.MiTipoDeDatosSQL.Fecha) & "," & _
      Logica.cBaseDatos.xSQL(Me.dscUltMateriaAprobada, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & _
      Logica.cBaseDatos.xSQL(Me.idEspecialidad, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & _
      Logica.cBaseDatos.xSQL(Me.cantMateriasAprobadas, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & _
      Logica.cBaseDatos.xSQL(Me.planEspecialidad, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & _
      Logica.cBaseDatos.xSQL(Me.anioCursa, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & _
      Logica.cBaseDatos.xSQL(Me.turnoCursa, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & _
      Logica.cBaseDatos.xSQL(Me.promConAplazos, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & _
      Logica.cBaseDatos.xSQL(Me.promSinAplazos, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & _
      Logica.cBaseDatos.xSQL(Me.matRegExamenPend, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & _
      Logica.cBaseDatos.xSQL(Me.tituloUniversitario, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & _
      Logica.cBaseDatos.xSQL(Me.titulosecundario, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & _
      Logica.cBaseDatos.xSQL(Me.archivoFoto, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & _
      Logica.cBaseDatos.xSQL(Me.archivoCV, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & _
      Logica.cBaseDatos.xSQL(Me.otrosComentarios, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & _
      Logica.cBaseDatos.xSQL(Me.estadoCivil, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & _
      Logica.cBaseDatos.xSQL(Me.emailalternativo, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & _
      Logica.cBaseDatos.xSQL(Me.fechaAltaSistema, cBaseDatos.MiTipoDeDatosSQL.Fecha) & ")" 'este lugar es la fcha de la ultima modificacion, que es la misma cuando se da de alta

      If strPosibleError = "" Then
        strPosibleError = oDB.EjecutarAccion(strSQL)
        'recupero el ID generado automaticamente y lo coloco en la propiedad
        Dim idP As Integer = oDB.EjecutarScalar("SELECT @@IDENTITY")
        If idP = -1 Then
          strPosibleError = "No se pudo recuperar el ID del postulante agregado"
        Else
          'paso el valor del idPostulante a la propiedad
          Me.idPostulante = idP
        End If
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
      strSQL = "UPDATE tbl_postulante set " & _
      " fechaUltimaActualizacion=" & Logica.cBaseDatos.xSQL(Date.Now, cBaseDatos.MiTipoDeDatosSQL.Fecha) & _
      ", email=" & Logica.cBaseDatos.xSQL(Me.email, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", nroLegajo=" & Logica.cBaseDatos.xSQL(Me.nroLegajo, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      ", tipoDoc=" & Logica.cBaseDatos.xSQL(Me.tipoDoc, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      ", nroDoc=" & Logica.cBaseDatos.xSQL(Me.nroDoc, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", apellido=" & Logica.cBaseDatos.xSQL(Me.apellido, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", nombres=" & Logica.cBaseDatos.xSQL(Me.nombres, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", nroCuil=" & Logica.cBaseDatos.xSQL(Me.nroCuil, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", fechaNacimiento=" & Logica.cBaseDatos.xSQL(Me.fechaNacimiento, cBaseDatos.MiTipoDeDatosSQL.Fecha) & _
      ", sexo=" & Logica.cBaseDatos.xSQL(Me.sexo, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      ", idDomicilioFamiliar=" & Logica.cBaseDatos.xSQL(Me.idDomicilioFamiliar, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      ", idDomicilioActual=" & Logica.cBaseDatos.xSQL(Me.idDomicilioActual, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      ", fecUltMateriaAprobada=" & Logica.cBaseDatos.xSQL(Me.fecUltMateriaAprobada, cBaseDatos.MiTipoDeDatosSQL.Fecha) & _
      ", dscUltMateriaAprobada=" & Logica.cBaseDatos.xSQL(Me.dscUltMateriaAprobada, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", idEspecialidad=" & Logica.cBaseDatos.xSQL(Me.idEspecialidad, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      ", cantMateriasAprobadas=" & Logica.cBaseDatos.xSQL(Me.cantMateriasAprobadas, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      ", planEspecialidad=" & Logica.cBaseDatos.xSQL(Me.planEspecialidad, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", anioCursa=" & Logica.cBaseDatos.xSQL(Me.anioCursa, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      ", turnoCursa=" & Logica.cBaseDatos.xSQL(Me.turnoCursa, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", promConAplazos=" & Logica.cBaseDatos.xSQL(Me.promConAplazos, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      ", promSinAplazos=" & Logica.cBaseDatos.xSQL(Me.promSinAplazos, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      ", matRegExamenPend=" & Logica.cBaseDatos.xSQL(Me.matRegExamenPend, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      ", tituloUniversitario=" & Logica.cBaseDatos.xSQL(Me.tituloUniversitario, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", titulosecundario=" & Logica.cBaseDatos.xSQL(Me.titulosecundario, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", archivoFoto=" & Logica.cBaseDatos.xSQL(Me.archivoFoto, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", archivoCV=" & Logica.cBaseDatos.xSQL(Me.archivoCV, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", otrosComentarios=" & Logica.cBaseDatos.xSQL(Me.otrosComentarios, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", emailAlternativo=" & Logica.cBaseDatos.xSQL(Me.emailalternativo, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", estadoCivil=" & Logica.cBaseDatos.xSQL(Me.estadoCivil, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      " WHERE idPostulante=" & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero)
      Return oDB.EjecutarAccion(strSQL)

    End Function
    Public Function Borrar() As String
      'Objetivo:
      'in
      'out
      ' "" o el error
      Dim oDB As Logica.cBaseDatos
      Dim strSql As String
      Dim strPosibleError As String

      strSql = "DELETE FROM tbl_postulante WHERE idPostulante=" & Me.idPostulante
      strPosibleError = oDB.EjecutarAccion(strSql)
      If strPosibleError = "" Then
        'elimino los domicilios familiar y actual
        strSql = "DELETE FROM tbl_domicilios_x_postulante WHERE idPostulante=" & Me.idPostulante & " AND idDomicilio IN( " & Logica.tipoDomicilio.DomicilioActual & " , " & Logica.tipoDomicilio.DomicilioFamiliar & " )"
        strPosibleError = oDB.EjecutarAccion(strSql)
      End If
      Return strPosibleError
    End Function

    Public Function Traer(ByVal ID As Integer) As DataRow
      'Trae un postulante por el ID interno
      Dim strWhere As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      If ID > 0 Then
        strWhere = " WHERE idPostulante=" & ID
      End If
      oDT = oDB.EjecutarDataTable("SELECT  idPostulante , fechaAltaSistema , usuario , contrasenia , email , nroLegajo , tipoDoc , nroDoc , apellido , nombres , nroCuil , fechaNacimiento , sexo , idDomicilioFamiliar , idDomicilioActual , fecUltMateriaAprobada , dscUltMateriaAprobada , idEspecialidad , cantMateriasAprobadas , planEspecialidad , anioCursa , turnoCursa , promConAplazos , promSinAplazos , matRegExamenPend , tituloUniversitario , titulosecundario , archivoFoto , archivoCV , otrosComentarios, estadoCivil, emailalternativo  FROM tbl_postulante " & strWhere)
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT.Rows(0)
      Else
        Return Nothing
      End If
    End Function

    Public Function CargarDatos(ByVal strUsuario As String) As String
      'Trae un postulante por el nombre de usuario
      'in
      ' strUsuario: el nombre de usuario
      'out
      ' "" o el error
      Dim strWhere As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      If strUsuario <> "" Then
        strWhere = " WHERE usuario=" & Logica.cBaseDatos.xSQL(strUsuario, cBaseDatos.MiTipoDeDatosSQL.Texto)
      End If
      oDT = oDB.EjecutarDataTable("SELECT  *  FROM tbl_postulante " & strWhere)
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        'cargo los datos al objeto
        Me.m_idPostulante = oDT.Rows(0).Item("idPostulante")
        Me.m_fechaAltaSistema = oDT.Rows(0).Item("fechaAltaSistema")
        Me.m_email = oDT.Rows(0).Item("email")
        Me.m_nroLegajo = oDT.Rows(0).Item("nroLegajo")
        Me.m_tipoDoc = oDT.Rows(0).Item("tipoDoc")
        Me.m_nroDoc = oDT.Rows(0).Item("nroDoc")
        Me.m_apellido = oDT.Rows(0).Item("apellido")
        Me.m_nombres = oDT.Rows(0).Item("nombres")
        Me.m_nroCuil = oDT.Rows(0).Item("nroCuil")
        Me.m_fechaNacimiento = oDT.Rows(0).Item("fechaNacimiento")
        Me.m_sexo = oDT.Rows(0).Item("sexo")
        Me.m_idDomicilioFamiliar = oDT.Rows(0).Item("idDomicilioFamiliar")
        Me.m_idDomicilioActual = oDT.Rows(0).Item("idDomicilioActual")
        Me.m_fecUltMateriaAprobada = oDT.Rows(0).Item("fecUltMateriaAprobada")
        Me.m_dscUltMateriaAprobada = oDT.Rows(0).Item("dscUltMateriaAprobada")
        Me.m_idEspecialidad = oDT.Rows(0).Item("idEspecialidad")
        Me.m_cantMateriasAprobadas = oDT.Rows(0).Item("cantMateriasAprobadas")
        Me.m_planEspecialidad = oDT.Rows(0).Item("planEspecialidad")
        Me.m_anioCursa = oDT.Rows(0).Item("anioCursa")
        Me.m_turnoCursa = oDT.Rows(0).Item("turnoCursa")
        Me.m_promConAplazos = oDT.Rows(0).Item("promConAplazos")
        Me.m_promSinAplazos = oDT.Rows(0).Item("promSinAplazos")
        Me.m_matRegExamenPend = oDT.Rows(0).Item("matRegExamenPend")
        Me.m_tituloUniversitario = oDT.Rows(0).Item("tituloUniversitario")
        Me.m_titulosecundario = oDT.Rows(0).Item("titulosecundario")
        Me.m_archivoFoto = oDT.Rows(0).Item("archivoFoto")
        Me.m_archivoCV = oDT.Rows(0).Item("archivoCV")
        Me.m_otrosComentarios = oDT.Rows(0).Item("otrosComentarios")
        Me.m_emailalternativo = oDT.Rows(0).Item("emailalternativo")
        Me.m_estadoCivil = oDT.Rows(0).Item("estadoCivil")

        Return ""
      Else
        Return "No existen datos para cargar"
      End If
    End Function

    Public Function TraerTodos(Optional ByVal legajo As Integer = 0, Optional ByVal idBusqueda As Integer = 0) As DataTable
      'Trae todos los postulantes  o filtra por legajo 
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim strWhere As String
      Dim strWhereLegajo As String
      Dim strWhereBusqueda As String
      Dim strSQL As String

      If legajo > 0 Then
        strWhereLegajo = " nroLegajo=" & legajo
      End If

      If idBusqueda > 0 Then
        strSQL = "SELECT     P.idPostulante, P.fechaAltaSistema, P.usuario, P.contrasenia, P.email, P.tipoDoc, P.nroDoc, P.apellido, P.nombres, P.nroCuil, P_X_B.idBusqueda, P_X_B.fechaPostulacion , P_X_B.fechaVinculacion, P_X_B.fechaExclusion, P.nroLegajo, E.dscEspecialidad , P.fechaUltimaActualizacion, P.fechaUltimaRevision, P.archivoCV , P_X_B.fechaEnvioCV " & _
                " FROM         dbo.tbl_postulante_x_Busqueda P_X_B INNER JOIN  " & _
                " dbo.tbl_postulante P ON P_X_B.idPostulante = P.idPostulante  LEFT OUTER JOIN " & _
                " dbo.tbl_especialidad E ON P.idEspecialidad = E.idEspecialidad "
        If strWhereLegajo <> "" Then
          strWhere = " WHERE P_X_B.fechaExclusion is null AND " & strWhereLegajo & " AND P_X_B.idBusqueda =" & Logica.cBaseDatos.xSQL(idBusqueda, cBaseDatos.MiTipoDeDatosSQL.Numero)
        Else
          strWhere = " WHERE P_X_B.fechaExclusion is null AND P_X_B.idBusqueda =" & Logica.cBaseDatos.xSQL(idBusqueda, cBaseDatos.MiTipoDeDatosSQL.Numero)
        End If
      Else
        strSQL = "SELECT  top 100 idPostulante , fechaAltaSistema , usuario , contrasenia , email , nroLegajo , tipoDoc , nroDoc , apellido , nombres , nroCuil , fechaNacimiento , sexo , idDomicilioFamiliar , idDomicilioActual , fecUltMateriaAprobada , dscUltMateriaAprobada , P.idEspecialidad , cantMateriasAprobadas , planEspecialidad , anioCursa , turnoCursa , promConAplazos , promSinAplazos , matRegExamenPend , tituloUniversitario , titulosecundario , archivoFoto , archivoCV , otrosComentarios,  0 as fechaPostulacion , 0 as fechaVinculacion, 0 as fechaExclusion ,dscEspecialidad , fechaUltimaActualizacion, fechaUltimaRevision , null as fechaEnvioCV  FROM tbl_postulante P LEFT OUTER JOIN dbo.tbl_especialidad E ON P.idEspecialidad = E.idEspecialidad "
        If strWhereLegajo <> "" Then
          strWhere = " WHERE" & strWhereLegajo
        Else
          strWhere = ""
        End If
      End If

      'aL FINAL 
      strSQL = strSQL & strWhere

      oDT = oDB.EjecutarDataTable(strSQL)
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Public Function ActualizarFechaRevision(ByVal IDP As String) As String
      'objetivo: actualiza la fecha de revision del postulante
      'in
      'out
      ' "" o el error
      'NOTA: es cuando se verifican los datos cargados por los postulantes
      Dim oDB As Logica.cBaseDatos
      Dim strSQL As String
      strSQL = "UPDATE tbl_postulante set " & _
      " fechaUltimaRevision=" & Logica.cBaseDatos.xSQL(Date.Now, cBaseDatos.MiTipoDeDatosSQL.Fecha) & _
      " WHERE idPostulante=" & Logica.cBaseDatos.xSQL(IDP, cBaseDatos.MiTipoDeDatosSQL.Numero)
      Return oDB.EjecutarAccion(strSQL)
    End Function
#End Region

#Region "Busqueda de postulantes por Filtrado"

    Public Function TraerPostulantesPorFiltrado(ByVal idCodigoListado As Integer) As DataTable
      'Trae todos los postulantes que cumplan con el criterio de filtrado
      'in
      ' idCodigoListado : el listado seleccionado del combo
      'valores:
      '1-Alumnos ingresados en el sistema con la cantidad de postulaciones

      Dim strSQL As String
      Select Case idCodigoListado
        Case 1
          strSQL = " SELECT P.idPostulante, P.fechaAltaSistema, P.usuario, P.email, P.emailAlternativo, P.nroLegajo, D.dscTipoDoc, P.nroDoc, P.apellido, P.nombres, " & _
                    " P.nroCuil, P.fechaNacimiento, P.sexo, P.fecUltMateriaAprobada, P.dscUltMateriaAprobada, dbo.tbl_especialidad.dscEspecialidad,  " & _
                    " P.cantMateriasAprobadas, P.planEspecialidad, P.anioCursa, P.turnoCursa, P.promConAplazos, P.promSinAplazos, P.matRegExamenPend,  " & _
                    " P.tituloUniversitario, P.titulosecundario, P.archivoCV, P.otrosComentarios, P.fechaUltimaActualizacion, P.fechaUltimaRevision  ,  " & _
                    " (select count(idBusqueda) FROM   tbl_postulante_x_Busqueda B where B.idPostulante =P.idPostulante ) as Postulaciones  " & _
                    " FROM dbo.tbl_postulante P INNER JOIN  " & _
                    " dbo.tbl_especialidad ON P.idEspecialidad = dbo.tbl_especialidad.idEspecialidad INNER JOIN  " & _
                    " dbo.tbl_tipoDoc D ON P.tipoDoc = D.idTipoDoc  "
        Case 2
          strSQL = ""
      End Select

      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      oDT = oDB.EjecutarDataTable(strSQL)
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Public Function TraerPostulantesPorFiltrado(ByVal sWhere As String, ByVal sEspe As String) As DataTable
      'Trae todos los postulantes que cumplan con el criterio de filtrado
      'in
      ' sWhere : el string a parsear de los campos y valores
      '         con formato: idGrupo|idCampo;operador;idvalor;idNexo¦
      '         idGrupo: 1=conocimientos . 2=Datos Personales
      '         idCampo: con grupo=1 seria el idConocimiento
      '         operador: con el grupo=1 es siempre "="
      '         idvalor: con el grupo=1 si es 4 (cualquier) reemplazar con IN(1,2,3)
      '         idNexo: 0 (Excluyente). 1 (No excluyente)
      ' sEspe:  el string a parsear de las especialidades. 
      '         con formato: cod1,cod2

      'armo el filtro por especialidad
      Dim sWEspe As New StringBuilder
      If sEspe <> "" Then
        sWEspe.Append(" ( idEspecialidad IN ( " & sEspe & " ) )")
      End If

      Dim sWExcluyente As New StringBuilder
      Dim sWNOExcluyente As New StringBuilder
      'verifico si hay mas de una fila por el separador de renglon ¦
      Dim sRows() As String
      Dim sCel() As String
      If InStr(sWhere, "¦") > 0 Then
        'hay mas de un renglon
        sRows = sWhere.Split("¦")
      Else
        'hay 1 solo renglon
        ReDim sRows(0)
        sRows(0) = sWhere
      End If
      'recorro todos los renglones
      Dim i As Integer
      Dim contExclu As Integer = 0
      Dim ultimo As Integer = sRows.GetUpperBound(0)
      For i = 0 To ultimo
        'separo en celdas
        sCel = sRows(i).Split(";")
        'verifico si la condicion es excluyente
        If sCel(3) = "0" Then
          contExclu += 1
          'Excluyente
          sWExcluyente.Append(WhereExcluyente(sCel(0), sCel(1), sCel(2), (i = ultimo)))
        Else
          'NO excluyente
          sWNOExcluyente.Append(WhereNOExcluyente(sCel(0), sCel(1), sCel(2), (i = ultimo)))
        End If
      Next

      Dim strSQL As String
      'verifico si hay al menos un exluyente NO tengo que hacer el otro filtrado
      If contExclu > 0 Then
        'Solo filtro por excluyentes
        'tengo que cerrar el where con la cantidad de ) igual a la cantidad del contador
        Dim sCierra As New StringBuilder
        sCierra.Append(")", contExclu)
        strSQL = " Select idPostulante, fechaAltaSistema, usuario, contrasenia, email, tipoDoc, nroDoc, apellido, nombres, nroCuil, nroLegajo FROM dbo.tbl_postulante WHERE " & sWEspe.ToString & " AND (idPostulante IN  " & sWExcluyente.ToString & " " & sCierra.ToString & " )"
      Else
        'solo filtro por NO excluyentes
        strSQL = " Select idPostulante, fechaAltaSistema, usuario, contrasenia, email, tipoDoc, nroDoc, apellido, nombres, nroCuil, nroLegajo FROM dbo.tbl_postulante WHERE " & sWEspe.ToString & " AND (idPostulante IN (  " & sWNOExcluyente.ToString & " ))"
      End If

      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      oDT = oDB.EjecutarDataTable(strSQL)
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Private Function WhereExcluyente(ByVal sGrupo_y_Campo As String, ByVal soperador As String, ByVal sidValor As String, ByVal esUltimo As Boolean) As String
      'objetivo: armo el where excluyente
      ' in
      ' sGrupo_y_Campo : idGrupo|idCampo
      ' soperador : 
      ' sidValor 
      ' esUltimo: indica si es la ultima condicion a inlcuir en el where
      'out
      ' string que filtra Excluyente como el que sigue ( marcado en empieza y termina)

      '=============== PARA LA SELECCION EXCLUYENTE ARMAR SQL COMO
      ' Select idPostulante
      ' FROM dbo.tbl_postulante
      ' WHERE (idPostulante IN 
      '           <!--Empieza aca-->
      '                    (SELECT idPostulante
      '                    FROM tbl_conocimiento_x_postulante
      '                    WHERE idconocimiento = 1 AND idValor IN (1, 2, 3) AND idPostulante IN
      '                                                                                       (SELECT idPostulante
      '                                                                                       FROM tbl_conocimiento_x_postulante
      '                                                                                       WHERE idconocimiento = 1 AND idValor = 3))
      '         '<!--Termina aca-->
      '       )
      '===============
      Dim sWE As New StringBuilder
      'verifico en que grupo se encuentra
      Dim idGrupo As Integer = Convert.ToInt16(sGrupo_y_Campo.Split("|")(0))
      Dim idCampo As Integer = Convert.ToInt16(sGrupo_y_Campo.Split("|")(1))

      If idGrupo = 1 Then
        'grupo de conocimiento
        sWE.Append("(SELECT idPostulante FROM tbl_conocimiento_x_postulante WHERE idconocimiento = " & idCampo & " AND idValor IN ( [@idValor] ) ")
        'verifico si es el ultimo
        If Not esUltimo Then
          sWE.Append(" AND idPostulante IN ")
        End If
        'verifico si el valor es cualquier y reemplzo
        If sidValor = "4" Then
          sidValor = "1,2,3"
        End If
        sWE.Replace("[@idValor]", sidValor)

      Else
        'grupo de datos personales
        'TODO : hacer en un futuro
      End If

      Return sWE.ToString
    End Function

    Private Function WhereNOExcluyente(ByVal sGrupo_y_Campo As String, ByVal soperador As String, ByVal sidValor As String, ByVal esUltimo As Boolean) As String
      'objetivo: armo el where NO excluyente
      ' in
      ' sGrupo_y_Campo : idGrupo|idCampo
      ' soperador : 
      ' sidValor 
      ' esUltimo: indica si es la ultima condicion a inlcuir en el where
      'out
      ' string que filtra NO Excluyente como el que sigue ( marcado en empieza y termina)

      '=============== PARA LA SELECCION NO EXCLUYENTE ARMAR SQL COMO
      'Select idPostulante  FROM dbo.tbl_postulante  
      ' WHERE (idPostulante IN 
      '           (
      '     <empieza aca>
      '             SELECT idPostulante
      '             FROM tbl_conocimiento_x_postulante
      '             WHERE idconocimiento = 1 AND idValor IN (1, 2, 3)
      '             UNION
      '             SELECT idPostulante
      '             FROM tbl_conocimiento_x_postulante
      '             WHERE idconocimiento = 1 AND idValor IN (1, 2, 3)
      '     <termina aca>
      '           ) 
      '       )
      '===============
      Dim sWE As New StringBuilder
      'verifico en que grupo se encuentra
      Dim idGrupo As Integer = Convert.ToInt16(sGrupo_y_Campo.Split("|")(0))
      Dim idCampo As Integer = Convert.ToInt16(sGrupo_y_Campo.Split("|")(1))

      If idGrupo = 1 Then
        'grupo de conocimiento
        sWE.Append(" SELECT idPostulante FROM tbl_conocimiento_x_postulante WHERE idconocimiento = " & idCampo & " AND idValor IN ( [@idValor] ) ")
        'verifico si es el ultimo
        If Not esUltimo Then
          sWE.Append(" UNION ")
        End If
        'verifico si el valor es cualquier y reemplzo
        If sidValor = "4" Then
          sidValor = "1,2,3"
        End If
        sWE.Replace("[@idValor]", sidValor)

      Else
        'grupo de datos personales
        'TODO : hacer en un futuro
      End If

      Return sWE.ToString
    End Function

#End Region

    Public Function ListarPostulaciones() As DataTable

      'Trae un postulante por el ID interno
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      oDT = oDB.EjecutarDataTable("SELECT P_X_B.idPostulante, P_X_B.fechaPostulacion, P_X_B.fechaExclusion, P_X_B.motivoExclusion, P_X_B.fechaVinculacion, B.idBusqueda, B.titulo, B.tipoVinculo, B.fechaDesde, B.fechaHasta, B.otroRequisitos, B.strEspecialidad, B.publica FROM dbo.tbl_postulante_x_Busqueda P_X_B INNER JOIN dbo.tbl_busqueda B ON P_X_B.idBusqueda = B.idBusqueda " & _
      " WHERE P_X_B.idPostulante = " & Logica.cBaseDatos.xSQL(Me.idPostulante, cBaseDatos.MiTipoDeDatosSQL.Numero))

      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If

    End Function

  End Class

End Namespace