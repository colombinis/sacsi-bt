Namespace Logica

  'TABLA tbl_momento
  Public Enum idMomento
    Documentacion_a_presentar_para_Sociedades_inscriptas = 1
    Documentacion_a_presentar_para_Sociedades_de_hecho = 2
    IniciarVinculo_Pasantia = 3
    IniciarVinculo_BolsaDeTrabajo = 4
  End Enum


  Public Enum tipoDomicilio
    DomicilioFamiliar = 1
    DomicilioActual = 2
  End Enum

  'TABLA tbl_estadoEmpresa
  Public Enum estadoEmpresa
    inicial = 1
    habilitada = 2
  End Enum

  'TABLA tbl_tipoEmpresa
  Public Enum TipoEmpresa
    Sociedades_inscriptas = 1
    Sociedades_de_hecho = 2
  End Enum

  Public Class ReglasNegocio

#Region "Documentacion"
    Shared Function InicializarDocumentacion(ByVal idEmpresa As Integer, ByVal strIdMomentos As String) As String
      'objetivo: inserto de la tabla doc_x_mom a la doc_x_empresa
      'in
      ' idEmpresa : la empresa a inicializar la documentacion
      ' strIdMomentos: el o los momentos para inicializar los documentos
      ' "" o el error
      Dim oDB As Logica.cBaseDatos
      Dim strSQL As String
      strSQL = "INSERT INTO tbl_Doc_x_Empresa ( idEmpresa, idDocumento, idMomento, Requerido)SELECT " & idEmpresa & " as idEmp , idDocumento, idMomento, Requerido FROM tbl_Doc_x_Momento WHERE (idMomento IN ( " & strIdMomentos & ")) "
      Return oDB.EjecutarAccion(strSQL)
    End Function
#End Region

    Shared Function ListarCombo_Especialidad() As DataTable
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      oDT = oDB.EjecutarDataTable("SELECT idEspecialidad as ID, LTRIM(dscEspecialidad) as DESCRIPCION FROM tbl_especialidad")
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Shared Function ListarCombo_Vinculo() As DataTable
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      oDT = oDB.EjecutarDataTable("SELECT idVinculo as ID, dscVinculo as DESCRIPCION FROM tbl_vinculo")
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Shared Function ListarCombo_EstadoCuotas() As DataTable
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      oDT = oDB.EjecutarDataTable("SELECT     idestadocuota as ID, dscestadocuota as DESCRIPCION  FROM tbl_estadoCuota")
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function
    Shared Function ListarCombo_TipoDoc() As DataTable
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      oDT = oDB.EjecutarDataTable("SELECT idTipoDoc as ID, dscTipoDoc as DESCRIPCION FROM tbl_tipoDoc")
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function
    Shared Function ListarCombo_Empresas() As DataTable
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      oDT = oDB.EjecutarDataTable("SELECT idEmpresa AS ID, cuit + '' + razonSocial AS DESCRIPCION FROM tbl_empresa")
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Shared Function ListarCombo_Conocimientos() As DataTable
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      oDT = oDB.EjecutarDataTable("SELECT idConocimiento AS ID, dscConocimiento AS DESCRIPCION FROM tbl_Conocimiento")

      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Shared Function ListarCombo_Busquedas(ByVal SoloActivas As Boolean) As DataTable
      'lista  todas las lbusquedas de todas las empresas
      'in
      ' SoloActivas: filtra trayendo solo las busquedas activas ( donde fecha vencimiento es mayor a fecha inicio ) 
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim strSQL As String

      If SoloActivas Then
        strSQL = "SELECT  idBusqueda as ID , (cast(idbusqueda as varchar(3)) + ' - ' + titulo + ' - Publica:' + publica + ' - Tipo:' + dscVinculo) as DESCRIPCION FROM dbo.tbl_busqueda INNER JOIN  dbo.tbl_vinculo ON dbo.tbl_busqueda.tipoVinculo = dbo.tbl_vinculo.idVinculo  WHERE fechaHasta > " & Logica.cBaseDatos.xSQL(Now(), cBaseDatos.MiTipoDeDatosSQL.Fecha) & " ORDER BY 1"
      Else
        strSQL = "SELECT  idBusqueda as ID , (cast(idbusqueda as varchar(3)) + ' - ' + titulo + ' - Publica:' + publica + ' - Tipo:' + dscVinculo) as DESCRIPCION FROM dbo.tbl_busqueda INNER JOIN  dbo.tbl_vinculo ON dbo.tbl_busqueda.tipoVinculo = dbo.tbl_vinculo.idVinculo  ORDER BY 1 "
      End If

      oDT = oDB.EjecutarDataTable(strSQL)
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function


    Shared Function ListarCombo_Postulantes() As DataTable
      'lista  Postulantes
      'in

      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim strSQL As String

      strSQL = "SELECT idPostulante AS ID, ' ' + COALESCE (apellido, ' ') + ',' + COALESCE (nombres, ' ') AS DESCRIPCION FROM tbl_postulante ORDER BY 1 "

      oDT = oDB.EjecutarDataTable(strSQL)
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Shared Function ListarCombo_Pais() As DataTable
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      oDT = oDB.EjecutarDataTable("SELECT idPais AS ID , dscPais as DESCRIPCION FROM dbo.tbl_Pais order by 2")
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Shared Function ListarCombo_Provincia(ByVal idPais As String) As DataTable
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      oDT = oDB.EjecutarDataTable("SELECT idProvincia  AS ID, dscProvincia as DESCRIPCION  FROM tbl_Provincia WHERE (idPais = " & idPais & ") ORDER BY 2")
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Shared Function ListarCombo_Localidad(ByVal idProvincia As String) As DataTable
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      oDT = oDB.EjecutarDataTable("SELECT idLocalidad AS ID, dscLocalidad as DESCRIPCION  FROM tbl_localidad WHERE (idProvincia = " & idProvincia & ") ORDER BY 2")
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

#Region "combos para el filtrado de postulantes"


    Shared Function ListarCombo_FILTRO_campos() As DataTable
      'objetivo: listar los conocimientos y en un futuro añadirles los campos propios del alumno
      'in

      'NOTA: para el discriminar el grupo de los conocimientos 
      ' el ID es 1, para los datos personales el id es 2
      ' en el combo el valor lo formo "idGrupo|idCampo"
      ' para los datos personales el idCampo es 0
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim strSQL As String

      strSQL = "SELECT '1|'+ RTRIM(cast(idConocimiento as nchar(4))) AS ID, dscConocimiento AS DESCRIPCION FROM tbl_Conocimiento ORDER BY 1"

      oDT = oDB.EjecutarDataTable(strSQL)
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Shared Function ListarCombo_FILTRO_operadores(ByVal idGrupoOperadores As String) As DataTable
      'objetivo: lista grupo de operadores segun el id del grupo del campo
      'in
      ' idGrupoOperadores:el ID es 1 para los conocimientos, para los datos personales el id es 2
      '                  viene con el formato idGrupo|idCampo
      Dim oDT As New DataTable
      oDT.Columns.Add("ID")
      oDT.Columns.Add("Descripcion")

      Select Case Convert.ToInt16(idGrupoOperadores.Split("|")(0))
        Case 1
          'para el grupo de conocimientos los operadores son :
          ' =
          oDT.Rows.Add(New Object() {"=", "="})
        Case 2
          'para el grupo de los datos personales los operadores son:
          ' > , < , >= , <= , <> , =
          oDT.Rows.Add(New Object() {">", ">"})
          oDT.Rows.Add(New Object() {"<", "<"})
          oDT.Rows.Add(New Object() {"<=", "<="})
          oDT.Rows.Add(New Object() {">=", ">="})
          oDT.Rows.Add(New Object() {"<>", "<>"})
          oDT.Rows.Add(New Object() {"=", "="})
      End Select

      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Shared Function ListarCombo_FILTRO_nexos() As DataTable
      'objetivo: lista los nexos y ( AND ) o ( Or )
      'in

      Dim oDT As New DataTable
      oDT.Columns.Add("ID")
      oDT.Columns.Add("Descripcion")

      oDT.Rows.Add(New Object() {"0", "Excluyente"})
      oDT.Rows.Add(New Object() {"1", "NO excluyente"})

      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Shared Function ListarCombo_FILTRO_valores(ByVal campo As String) As DataTable
      'objetivo: lista los posibles valores dependiendo del campo elegido
      'in
      ' campo: el nombre dle campo para cargar los posibles valores
      '       viene con el formato "idgrupo|idCampo"

      Dim oDT As New DataTable
      oDT.Columns.Add("ID")
      oDT.Columns.Add("Descripcion")

      oDT.Rows.Add(New Object() {"1", "Bajo"})
      oDT.Rows.Add(New Object() {"2", "Medio"})
      oDT.Rows.Add(New Object() {"3", "Alto"})
      oDT.Rows.Add(New Object() {"4", "cualquier"})

      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function
#End Region
  End Class

End Namespace
