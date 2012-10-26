Imports System.Text

Namespace Logica

  Public Class cConsultasSysacad

    Shared Function XML_obtenerCarreraPlan(ByVal strLegajo As String) As String
      'objetivo: recupera plan  y carrera
      'in
      'out
      ' un xml formado con los datos
      Dim strSQL As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim salida As New StringBuilder

      Try
        strSQL = " select nom_tipo,nro_documento,legajo,nombre,especialidad,nom_especialidad,[plan]  from usrdbsysacad.v_ITalumnos " & _
                       " where legajo = " & strLegajo
        oDT = oDB.EjecutarDataTable_SysAcad(strSQL)

        If Not oDT Is Nothing AndAlso oDT.Rows.Count > 0 Then
          salida.Append("<DATOS>" & _
            "<LEGAJO>" & AntiNull(oDT.Rows(0).Item("legajo")) & "</LEGAJO>" & _
            "<CODESPECIALIDAD>" & AntiNull(oDT.Rows(0).Item("especialidad")) & "</CODESPECIALIDAD>" & _
            "<ESPECIALIDAD>" & AntiNull(oDT.Rows(0).Item("nom_especialidad")) & "</ESPECIALIDAD>" & _
            "<PLAN>" & AntiNull(oDT.Rows(0).Item("plan")) & "</PLAN>" & _
            "</DATOS>")
        End If

        Return salida.ToString
      Catch ex As Exception
        Throw New Exception("Error al Obtener los datos de carrera y plan")
      End Try
    End Function

    Private Shared Function AntiNull(ByVal valorDB As Object) As String
      'le paso un valor
      'verifico si es <> "" 
      If Not IsNothing(valorDB) Then
        Return Trim(valorDB.ToString)
      Else
        Return ""
      End If

    End Function

    Shared Function XML_obtenerDatosPersonales(ByVal strLegajo As String) As String
      'objetivo: recupera datos personales
      'in
      'out
      ' un xml formado con los datos
      Dim strSQL As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim salida As New StringBuilder

      Try
        strSQL = " select * from usrdbsysacad.v_ITDatosPersonales " & _
                 " where legajo = " & strLegajo
        oDT = oDB.EjecutarDataTable_SysAcad(strSQL)

        If Not oDT Is Nothing AndAlso oDT.Rows.Count > 0 Then
          salida.Append("<DATOS>" & _
          "<NOMBRE>" & AntiNull(oDT.Rows(0).Item("nombre")) & "</NOMBRE>" & _
          "<TDOCUMENTO>" & AntiNull(oDT.Rows(0).Item("TDOCUMENTO")) & "</TDOCUMENTO>" & _
          "<NDOCUMENTO>" & AntiNull(oDT.Rows(0).Item("NDOCUMENTO")) & "</NDOCUMENTO>" & _
          "<DCALLE>" & AntiNull(oDT.Rows(0).Item("DCALLE")) & "</DCALLE>" & _
          "<DNUMERO>" & AntiNull(oDT.Rows(0).Item("DNUMERO")) & "</DNUMERO>" & _
          "<DPISO>" & AntiNull(oDT.Rows(0).Item("DPISO")) & "</DPISO>" & _
          "<DDEPARTAMENTO>" & AntiNull(oDT.Rows(0).Item("DDEPARTAMENTO")) & "</DDEPARTAMENTO>" & _
          "<CODIGO_POSTAL>" & AntiNull(oDT.Rows(0).Item("CODIGO_POSTAL")) & "</CODIGO_POSTAL>" & _
          "<PNOMBRE>" & AntiNull(oDT.Rows(0).Item("PNOMBRE")) & "</PNOMBRE>" & _
          "<CIUDAD>" & AntiNull(oDT.Rows(0).Item("CIUDAD")) & "</CIUDAD>" & _
          "<PCODIGO>" & AntiNull(oDT.Rows(0).Item("PCODIGO")) & "</PCODIGO>" & _
          "<TELEFONO>" & AntiNull(oDT.Rows(0).Item("TELEFONO")) & "</TELEFONO>" & _
          "<MAIL>" & AntiNull(oDT.Rows(0).Item("MAIL")) & "</MAIL>" & _
          "<TRABAJA_SN>" & AntiNull(oDT.Rows(0).Item("TRABAJA_SN")) & "</TRABAJA_SN>" & _
          "<ANIO_INGRESO>" & AntiNull(oDT.Rows(0).Item("ANIO_INGRESO")) & "</ANIO_INGRESO>" & _
          "<LEGAJO>" & AntiNull(oDT.Rows(0).Item("LEGAJO")) & "</LEGAJO>" & _
          "<ESPECIALIDAD>" & AntiNull(oDT.Rows(0).Item("ESPECIALIDAD")) & "</ESPECIALIDAD>" & _
          "<PLAN>" & AntiNull(oDT.Rows(0).Item("PLAN")) & "</PLAN>" & _
          "<FECHANACIM>" & AntiNull(oDT.Rows(0).Item("FECHANACIM")) & "</FECHANACIM>" & _
          "</DATOS>")
        End If

        Return salida.ToString
      Catch ex As Exception
        Throw New Exception("Error al Obtener los datos personales")
      End Try
    End Function

    Shared Function XML_obtenerMateriasRegulares(ByVal strLegajo As String, ByVal strEspecialidad As String) As String
      'objetivo: recupera Materias Regulares
      'in
      'out
      ' un xml formado con los datos
      Dim strSQL As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim salida As New StringBuilder
      Dim server As System.Web.HttpUtility

      Try
        strSQL = " SELECT [plan],anio_cursado as anio,nom_materia as materia,anio_academico as cursada,comision as comision " & _
              " FROM usrdbsysacad.v_ITregulares " & _
              " WHERE legajo = " & strLegajo & " AND " & _
              " especialidad = " & strEspecialidad & _
              " ORDER BY cursada,anio,materia"

        oDT = oDB.EjecutarDataTable_SysAcad(strSQL)

        If Not oDT Is Nothing AndAlso oDT.Rows.Count > 0 Then
          salida.Append("<DATOS>")
          Dim intI As Integer

          For intI = 0 To oDT.Rows.Count - 1
            salida.Append("<REG ID=""" & intI & """>")
            salida.Append("<CURSADA>" & server.HtmlEncode(AntiNull(oDT.Rows(intI).Item("cursada"))) & "</CURSADA>")
            salida.Append("<ANIO>" & server.HtmlEncode(AntiNull(oDT.Rows(intI).Item("anio"))) & "</ANIO>")
            salida.Append("<PLAN>" & server.HtmlEncode(AntiNull(oDT.Rows(intI).Item("plan"))) & "</PLAN>")
            salida.Append("<MATERIA>" & server.HtmlEncode(AntiNull(oDT.Rows(intI).Item("materia"))) & "</MATERIA>")
            salida.Append("<COMISION>" & server.HtmlEncode(AntiNull(oDT.Rows(intI).Item("comision"))) & "</COMISION>")
            salida.Append("</REG>")
          Next
          salida.Append("</DATOS>")
        End If

        Return salida.ToString
      Catch ex As Exception
        Throw New Exception("Error al Obtener las materias regulares")
      End Try
    End Function

    Shared Function XML_obtenerExamenes(ByVal strLegajo As String, ByVal strEspecialidad As String) As String
      'objetivo: recupera los examenes
      'in
      'out
      ' un xml formado con los datos
      Dim strSQL As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim salida As New StringBuilder
      Dim server As System.Web.HttpUtility

      Try
        strSQL = "SELECT anio as anio, [plan],nom_materia as materia, nota as nota, convert(char(10),fecha,103) as fecha " & _
        " FROM usrdbsysacad.v_ITexamenes " & _
        " WHERE legajo = " & strLegajo & " AND  especialidad = " & strEspecialidad & _
        " ORDER BY convert(char(10),fecha,111)"

        oDT = oDB.EjecutarDataTable_SysAcad(strSQL)

        If Not oDT Is Nothing AndAlso oDT.Rows.Count > 0 Then
          salida.Append("<DATOS>")
          Dim intI As Integer

          For intI = 0 To oDT.Rows.Count - 1
            salida.Append("<REG ID=""" & intI & """>")
            salida.Append("<ANIO>" & server.HtmlEncode(AntiNull(oDT.Rows(intI).Item("anio"))) & "</ANIO>")
            salida.Append("<PLAN>" & server.HtmlEncode(AntiNull(oDT.Rows(intI).Item("plan"))) & "</PLAN>")
            salida.Append("<MATERIA>" & server.HtmlEncode(AntiNull(oDT.Rows(intI).Item("materia"))) & "</MATERIA>")
            salida.Append("<NOTA>" & server.HtmlEncode(AntiNull(oDT.Rows(intI).Item("nota"))) & "</NOTA>")
            salida.Append("<FECHA>" & server.HtmlEncode(AntiNull(oDT.Rows(intI).Item("fecha"))) & "</FECHA>")
            salida.Append("</REG>")
          Next
          salida.Append("</DATOS>")
        End If

        Return salida.ToString
      Catch ex As Exception
        Throw New Exception("Error al Obtener los examenes")
      End Try
    End Function

    Shared Function XML_obtenerPromedio(ByVal strLegajo As String, ByVal strEspecialidad As String) As String
      'objetivo: recupera el promedio
      'in
      'out
      ' un xml formado con los datos
      Dim strSQL As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim salida As New StringBuilder
      Dim server As System.Web.HttpUtility

      Try
        strSQL = " SELECT convert(numeric(4,2),Round(sum(convert(numeric(4,2),nota))/count(*),2)) as promedio " & _
                  " FROM usrdbsysacad.v_ITexamenes " & _
                  " WHERE legajo = " & strLegajo & " AND " & _
                  "       especialidad = " & strEspecialidad & " AND " & _
                  "		    nota <> 'Eq' "

        oDT = oDB.EjecutarDataTable_SysAcad(strSQL)

        If Not oDT Is Nothing AndAlso oDT.Rows.Count > 0 Then
          salida.Append("<DATOS>")
          salida.Append("<PROMEDIO>" & server.HtmlEncode(AntiNull(oDT.Rows(0).Item("promedio"))) & "</PROMEDIO>")
          salida.Append("</DATOS>")
        End If

        Return salida.ToString
      Catch ex As Exception
        Throw New Exception("Error al Obtener el promedio")
      End Try
    End Function

    Shared Function XML_obtenerCursadoActual(ByVal strLegajo As String, ByVal strEspecialidad As String) As String
      'objetivo: recupera los examenes
      'in
      'out
      ' un xml formado con los datos
      Dim strSQL As String
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      Dim salida As New StringBuilder
      Dim server As System.Web.HttpUtility

      Try
        strSQL = " SELECT anio_cursado as anio,nom_materia as materia,anio_academico as cursada,comision as comision " & _
        " FROM usrdbsysacad.v_ITcursando as c " & _
        " WHERE legajo = " & strLegajo & " AND " & _
        "       anio_academico = Year(GetDate()) " & _
        " ORDER BY cursada,anio,materia"

        oDT = oDB.EjecutarDataTable_SysAcad(strSQL)

        If Not oDT Is Nothing AndAlso oDT.Rows.Count > 0 Then
          salida.Append("<DATOS>")
          Dim intI As Integer

          For intI = 0 To oDT.Rows.Count - 1
            salida.Append("<REG ID=""" & intI & """>")
            salida.Append("<ANIO>" & server.HtmlEncode(AntiNull(oDT.Rows(intI).Item("anio"))) & "</ANIO>")
            salida.Append("<MATERIA>" & server.HtmlEncode(AntiNull(oDT.Rows(intI).Item("materia"))) & "</MATERIA>")
            salida.Append("<COMISION>" & server.HtmlEncode(AntiNull(oDT.Rows(intI).Item("comision"))) & "</COMISION>")
            salida.Append("</REG>")
          Next
          salida.Append("</DATOS>")
        End If

        Return salida.ToString
      Catch ex As Exception
        Throw New Exception("Error al Obtener el cursado actual")
      End Try
    End Function

  End Class
End Namespace
