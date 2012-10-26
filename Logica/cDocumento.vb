Namespace Logica

  Public Class cDocumento

    Public Function ActualizarDocumentacion(ByVal IdEmpresa As Integer, ByVal idDocumento As Integer, ByVal idMomento As Integer, ByVal Presentado As Integer) As String
      'actualiza en la tabla doc_x_Empresa
      'in
      '
      'out
      ' "" o el error
      Dim oDB As Logica.cBaseDatos
      Dim strSql As String
      strSql = "UPDATE tbl_Doc_x_Empresa SET " & _
              " presentado = " & oDB.xSQL(Presentado, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
              " WHERE idEmpresa=" & oDB.xSQL(IdEmpresa, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
              " AND idDocumento = " & oDB.xSQL(idDocumento, cBaseDatos.MiTipoDeDatosSQL.Numero) & _
              " AND  idmomento=" & oDB.xSQL(idMomento, cBaseDatos.MiTipoDeDatosSQL.Numero)
      Return oDB.EjecutarAccion(strSql)
    End Function

  End Class

End Namespace
