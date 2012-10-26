Namespace Logica


  Public Class cUsuarioSae

    Public Shared Function CuentaValida(ByVal usuario As String, ByVal password As String) As Boolean
      Dim oDB As Logica.cBaseDatos
      Dim oDT As DataTable
      oDT = oDB.EjecutarDataTable(" SELECT idUsuarioSAE, nombre, usuario, pass , email FROM tbl_usuarioSAE WHERE usuario=" & Logica.cBaseDatos.xSQL(usuario, Logica.cBaseDatos.MiTipoDeDatosSQL.Texto) & " AND " & _
    " pass= " & Logica.cBaseDatos.xSQL(password, Logica.cBaseDatos.MiTipoDeDatosSQL.Texto))

      If Not IsNothing(oDT) AndAlso oDT.Rows.Count <> 0 Then
        Logica.cUtil.varSession(Logica.cUtil.userSession.UserLogonID, oDT.Rows(0).Item("idUsuarioSAE"))
        Logica.cUtil.varSession(Logica.cUtil.userSession.UserLogonFullName, oDT.Rows(0).Item("nombre"))
        Logica.cUtil.varSession(Logica.cUtil.userSession.Useremail, oDT.Rows(0).Item("email"))

        Return True
      Else
        Return False
      End If

    End Function


  End Class

End Namespace