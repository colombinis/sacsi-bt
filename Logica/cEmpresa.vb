Namespace Logica

  Public Class cEmpresa

    Public Sub New()
      'constructor vacio
    End Sub

    Public Function Agregar(ByVal cuit As String, ByVal razonSocial As String, ByVal domicilio As String, ByVal telefonos As String, ByVal email As String, ByVal web As String, ByVal personaContacto As String, ByVal tipoEmpresa As Integer) As String
      Dim strIDMomentos As String
      Dim strPosibleError As String = ""
      Dim oDB As Logica.cBaseDatos
      Dim IDEmpresa As Integer

      If strPosibleError = "" Then
        strPosibleError = oDB.EjecutarAccion("INSERT INTO tbl_empresa (cuit, razonSocial, domicilio, telefonos, email, web, personaContacto, tipoEmpresa,idestadoEmpresa) values (" & oDB.xSQL(cuit, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & oDB.xSQL(razonSocial, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & oDB.xSQL(domicilio, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & oDB.xSQL(telefonos, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & oDB.xSQL(email, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & oDB.xSQL(web, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & oDB.xSQL(personaContacto, cBaseDatos.MiTipoDeDatosSQL.Texto) & "," & oDB.xSQL(tipoEmpresa, cBaseDatos.MiTipoDeDatosSQL.Numero) & "," & oDB.xSQL(Logica.estadoEmpresa.inicial, cBaseDatos.MiTipoDeDatosSQL.Numero) & ")")
      End If

      'obtengo el id secuencial asignado a la empresa recien insertada
      If strPosibleError = "" Then
        IDEmpresa = oDB.EjecutarScalar("SELECT idEmpresa FROM tbl_empresa WHERE cuit=" & oDB.xSQL(cuit, cBaseDatos.MiTipoDeDatosSQL.Texto))
      End If

      'si hay error el idempresa es -1
      If IDEmpresa = -1 Then
        strPosibleError = "Error al recuperar datos de la empresa por el cuit (cEmpresa.vb)"
      Else
        Select Case tipoEmpresa
          Case Logica.TipoEmpresa.Sociedades_de_hecho
            strIDMomentos = Logica.idMomento.Documentacion_a_presentar_para_Sociedades_de_hecho
          Case Logica.TipoEmpresa.Sociedades_inscriptas
            strIDMomentos = Logica.idMomento.Documentacion_a_presentar_para_Sociedades_inscriptas
        End Select
        'inicializo la documentacion
        Logica.ReglasNegocio.InicializarDocumentacion(IDEmpresa, strIDMomentos)
      End If

      Return strPosibleError
    End Function

    Public Function Editar(ByVal idempresa As Integer, ByVal cuit As String, ByVal razonSocial As String, ByVal domicilio As String, ByVal telefonos As String, ByVal email As String, ByVal web As String, ByVal personaContacto As String, ByVal tipoEmpresa As Integer, ByVal estadoEmpresa As Integer) As String
      Dim oDB As Logica.cBaseDatos
      Return oDB.EjecutarAccion("UPDATE tbl_empresa set " & _
      " cuit =" & oDB.xSQL(cuit, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", razonSocial=" & oDB.xSQL(razonSocial, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", domicilio=" & oDB.xSQL(domicilio, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", telefonos=" & oDB.xSQL(telefonos, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", email=" & oDB.xSQL(email, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", web=" & oDB.xSQL(web, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", personaContacto=" & oDB.xSQL(personaContacto, cBaseDatos.MiTipoDeDatosSQL.Texto) & _
      ", tipoEmpresa=" & oDB.xSQL(tipoEmpresa, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      ", idestadoEmpresa=" & oDB.xSQL(estadoEmpresa, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
      " WHERE idEmpresa=" & idempresa)
    End Function

    Public Function Borrar(ByVal idempresa As Integer) As String
      Dim strWhere As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      'verifico si puede eliminarse , solo si las tablas relacionadas no tienen datos
      strWhere = " WHERE idEmpresa=" & idempresa
        oDT = oDB.EjecutarDataTable("SELECT idEmpresa FROM tbl_busqueda " & strWhere)
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        'error existen datos
        Return "Error al eliminar la empresa. Elimine primero las busquedas para la Empresa"
        Exit Function
      End If
      Return oDB.EjecutarAccion("DELETE FROM tbl_empresa WHERE idempresa=" & oDB.xSQL(idempresa, cBaseDatos.MiTipoDeDatosSQL.Numero))
    End Function

    Public Function Traer(ByVal ID As Integer) As DataRow
      'Trae una determinada empresa o la primera de todas las empresas
      Dim strWhere As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      If ID > 0 Then
        strWhere = " WHERE idEmpresa=" & ID
      End If
      oDT = oDB.EjecutarDataTable("SELECT idEmpresa, cuit, razonSocial, domicilio, telefonos, email, web, personaContacto, tipoEmpresa,  fechaAlta, idEstadoEmpresa FROM tbl_empresa " & strWhere & " ORDER BY cuit ")
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT.Rows(0)
      Else
        Return Nothing
      End If
    End Function


    Public Function Traer(Optional ByVal strcuit As String = "", Optional ByVal strRazonSocial As String = "") As DataTable
      'Trae todas las 
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim strWhere As String = ""

      If strcuit <> "" Then
        strWhere = " WHERE cuit=" & oDB.xSQL(strcuit, cBaseDatos.MiTipoDeDatosSQL.Texto)
      End If

      If strRazonSocial <> "" Then
        If strWhere <> "" Then
          strWhere = " AND razonSocial like(" & oDB.xSQL(strRazonSocial & "%", cBaseDatos.MiTipoDeDatosSQL.Texto) & " )"
        Else
          strWhere = " WHERE razonSocial like(" & oDB.xSQL(strRazonSocial & "%", cBaseDatos.MiTipoDeDatosSQL.Texto) & " )"
        End If
      End If

      oDT = oDB.EjecutarDataTable("SELECT idEmpresa, cuit, razonSocial, domicilio, telefonos, email, web, personaContacto, tipoEmpresa , fechaAlta, idEstadoEmpresa FROM tbl_empresa " & strWhere & " ORDER BY razonSocial ")
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Public Function Existe(ByVal cuit As String) As Boolean
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Try
        oDT = oDB.EjecutarDataTable("SELECT cuit FROM tbl_empresa WHERE cuit=" & oDB.xSQL(cuit, cBaseDatos.MiTipoDeDatosSQL.Texto))
        If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
          Return True
        Else
          Return False
        End If
      Catch ex As Exception
        Return False
      End Try
    End Function

    Public Function ListarCombo_TipoEmpresa() As DataTable
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      oDT = oDB.EjecutarDataTable("SELECT idTipoEmpresa as ID, dscTipoEmpresa as DESCRIPCION FROM tbl_tipoEmpresa")
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Public Function ListarCombo_EstadoEmpresa() As DataTable
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      oDT = oDB.EjecutarDataTable("SELECT idEstadoEmpresa as ID, dscEstadoEmpresa as DESCRIPCION FROM tbl_estadoEmpresa")
      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Public Function ListarGrilla_DocumentacionPorEmpresa(ByVal idEmpresa As Integer) As DataTable
      'Objetivos:Obtengo los documentos por momentos
      'in
      ' idEmpresa : el id de la empresa

      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim strSQl As String
      Dim strWhere As String

      'Todos los documentos inicializados para la empresa
      strSQl = "SELECT TDE.idEmpresa,TDE.idmomento ,TDE.idDocumento, TDE.Presentado, TDE.Requerido, D.dscDocumento " & _
      " FROM tbl_Doc_x_Empresa TDE INNER JOIN tbl_documento D ON TDE.idDocumento = D.idDoc " & _
      " WHERE  (TDE.idEmpresa = " & oDB.xSQL(idEmpresa, cBaseDatos.MiTipoDeDatosSQL.Numero) & " )"

      oDT = oDB.EjecutarDataTable(strSQl)

      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT
      Else
        Return Nothing
      End If
    End Function

    Public Function ObtenerEmailPorBusqueda(ByVal idB As String) As String
      'objetivo: obtengo el email de la empresa a partir de la busqueda
      'in
      ' idB: el nro de la busqueda
      Dim strSQL As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable

      Dim strWhere As String

      strSQL = "SELECT B.idBusqueda, E.idEmpresa, E.cuit, E.razonSocial, E.domicilio, E.telefonos, E.email, E.web, E.personaContacto, E.tipoEmpresa, E.fechaAlta, E.idEstadoEmpresa " & _
      " FROM dbo.tbl_busqueda B INNER JOIN dbo.tbl_empresa E ON B.idEmpresa = E.idEmpresa " & _
      " WHERE  B.idBusqueda = " & oDB.xSQL(idB, cBaseDatos.MiTipoDeDatosSQL.Numero)

      oDT = oDB.EjecutarDataTable(strSQl)

      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Return oDT.Rows(0).Item("email").ToString
      Else
        Return Nothing
      End If
    End Function
  End Class

End Namespace

