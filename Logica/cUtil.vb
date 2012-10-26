
Imports System
Imports System.IO
Imports System.Xml


Namespace Logica

  Public Class cUtil
    'objetivo: funciones y metodos que pueden ser llamados de todo el site

#Region "Constantes y valores de configuracion"

#Region "Coneccion base de datos"

    Public Shared Function strCadenaConeccion() As String

      If System.Web.HttpContext.Current.Session("strCadenaConeccion") Is Nothing Then
        'SQL2000
        'verifico como armo la coneccion del SQL 
        'NOTA: por defecto es de tipo SQL
        If Not System.Configuration.ConfigurationSettings.AppSettings("integrada") Is Nothing AndAlso System.Configuration.ConfigurationSettings.AppSettings("integrada") = "si" Then
          System.Web.HttpContext.Current.Session("strCadenaConeccion") = "Data Source=" & System.Configuration.ConfigurationSettings.AppSettings("SQLsrv").ToString() & _
          ";Initial Catalog=" & System.Configuration.ConfigurationSettings.AppSettings("SQLdb").ToString() & _
          ";Integrated Security=SSPI;"
        Else
          'armo la cadena de coneccion con usurio y password de SQL
          System.Web.HttpContext.Current.Session("strCadenaConeccion") = "Data Source=" & System.Configuration.ConfigurationSettings.AppSettings("SQLsrv").ToString() & _
          ";Initial catalog=" & System.Configuration.ConfigurationSettings.AppSettings("SQLdb").ToString() & _
          ";User id=" & System.Configuration.ConfigurationSettings.AppSettings("SQLu").ToString() & _
          ";Password=" & System.Configuration.ConfigurationSettings.AppSettings("SQLp").ToString() & _
          ";Connection TimeOut=10;"
        End If
      End If
      'obtengo directo de la variable session
      Return System.Web.HttpContext.Current.Session("strCadenaConeccion")
    End Function

#End Region

#Region "servidor de correo"

    Public Shared Function getServidorPOP() As String
      'obtengo el servidor de correo desde web config
      Dim strClave As String = "ServidorPOP"
      If System.Web.HttpContext.Current.Session(strClave) Is Nothing Then
        System.Web.HttpContext.Current.Session(strClave) = System.Configuration.ConfigurationSettings.AppSettings(strClave).ToString()
      End If
      Return System.Web.HttpContext.Current.Session(strClave)
    End Function
    Public Shared Function getPuertoPOP() As String
      'obtengo el puerto del servidor de correo desde web config
      Dim strClave As String = "PuertoPOP"
      If System.Web.HttpContext.Current.Session(strClave) Is Nothing Then
        System.Web.HttpContext.Current.Session(strClave) = System.Configuration.ConfigurationSettings.AppSettings(strClave).ToString()
      End If
      Return System.Web.HttpContext.Current.Session(strClave)
    End Function
#End Region

#End Region

#Region "path aplicacion"

    Public Shared Function GetAppRootPath() As String
      'objetivo: devuelve la ruta relativa en formato uri
      'in
      'out
      ' el path desde el directorio seteado como aplicacion
      Return System.Web.HttpContext.Current.Request.ApplicationPath()
    End Function

    Public Shared Function GetAppRootPathTEMP() As String
      'objetivo: devuelve la ruta relativa en formato uri
      'in
      'out
      ' el path desde el directorio temporal con acceso escritura 
      Return System.Web.HttpContext.Current.Request.ApplicationPath() & "/public/"
    End Function

    Public Shared Function GetAppRootPathFisico() As String
      'objetivo: devuelve la ruta fisica al inicio del dir de la aplicacion
      'in
      'out
      ' el path desde el directorio seteado como aplicacion
      Dim strRoot As String = System.Web.HttpContext.Current.Request.PhysicalApplicationPath
      If (Right(strRoot, 1) <> "\") Then
        strRoot &= "\"
      End If

      Return strRoot
    End Function

    Public Shared Function GetAppRootPathFisicoTEMP() As String
      'objetivo: devuelve la ruta fisica al inicio del dir de la aplicacion
      'in
      'out
      ' el path desde el directorio seteado como aplicacion
      Dim strRoot As String = System.Web.HttpContext.Current.Request.PhysicalApplicationPath
      If (Right(strRoot, 1) <> "\") Then
        strRoot &= "\"
      End If

      Return strRoot & "public"
    End Function

    Public Shared Function GetHttpAppRootPath() As String
      'objetivo: devuelve la ruta con el HTTP://
      'in
      'out
      Dim strRoot As String = "http://" & System.Web.HttpContext.Current.Request.ServerVariables("SERVER_NAME") & GetAppRootPath()

      If (Right(strRoot, 1) <> "/") Then
        strRoot &= "/"
      End If

      Return strRoot
    End Function

    Public Shared Function GetHttpAppRootMyaccount() As String
      'objetivo: devuelve la ruta con el HTTP://.../myAccount.aspx
      'in
      'out
      ' la ruta a la pagina de login
      Dim strRoot As String = GetHttpAppRootPath() & "default.aspx"
      Return strRoot
    End Function

#End Region

#Region "Variables de session y Aplicacion "
    'para manejar las variables de sesion y de aplicacion de manerta centralizada
    'NOTA:hacer un listado de nombreclave = "descripcion de para que se utiliza"
    'Clave = descripcion
    '===================
        Public Enum userSession
            UserLogonName = 1
            UserLogonPass = 2
            UserSectionCode = 3
            UserLogonFullName = 4
            UserLogonCompanyName = 5
            UserSectionURL = 6
            UserFTPRoot = 7
            UserRoot = 8
            UserLogonID = 9
            Useremail = 10
            'Datos que necesito recordar entre las paginas
            comunes_BusquedaActual = 100
        End Enum


        Public Shared Function LogOnSession(ByRef userName As String, ByRef pass As String, ByRef bolExisteLocal As Boolean) As String
            'objetivo: realiza la verificacion del usuario segun la cuenta de correo
            'in
            ' userName: el nombre de usuario 
            ' pass: la contraseña
            ' bolExisteLocal: bandera para indicar si existe en la BD local
            'out
            ' "" si todo OK o el error

            Dim strPosibleError As String

            Try

                'verifico si hay acceso a la Base de datos
                'NOTA este select tiene que ser a una tabla "chiquita" y que siempre tenga datos
                If (Logica.cBaseDatos.EjecutarDataTable("SELECT TOP 1 * FROM tbl_tipoDoc")) Is Nothing Then
                    Throw New Exception("Error: No se pudo conectar con la base de datos.")
                End If

                'verifico si el usuario existe en la base de datos local
                Dim oPos As New Logica.tbl_postulante
                'limpio los carateres dañinos
                userName = Logica.cBaseDatos.xSQL(userName, cBaseDatos.MiTipoDeDatosSQL.Texto)
                'reemplazo las comillas simples
                oPos.usuario = userName.Replace("'", "")

                If oPos.CargarDatos(oPos.usuario) <> "" Then
                    bolExisteLocal = False
                    'inserto el registro en la BD con el usuario
                    oPos.fechaAltaSistema = Now()
                    strPosibleError = oPos.Agregar()
                    If strPosibleError <> "" Then
                        'error al insertar el postulante en la BD local
                        Throw New Exception("Error: No se pudo crear el nuevo registro.")
                    End If
                Else
                    bolExisteLocal = True
                End If

                If CargarSesionPostulante(oPos) <> "" Then
                    Throw New Exception("Error: No se pudo inicializar la sesion.")
                End If

                Return ""
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        Public Shared Function CargarSesionPostulante(ByVal oPostulante As Logica.tbl_postulante) As String
            'carga los datos en la sesion desde el pbjeto postulante
            'in
            'out
            ' "" o el Error 
            Try
                'cargo los datos de sesion

                'coloco las variables de session
                varSession(userSession.UserLogonName, oPostulante.usuario)
                varSession(userSession.UserLogonID, oPostulante.idPostulante)
                varSession(userSession.Useremail, oPostulante.email)
                varSession(userSession.UserLogonFullName, oPostulante.apellido & ", " & oPostulante.nombres)
                '''varSession(userSession.UserLogonPass, pass)
                '''varSession(userSession.UserSectionCode, "")
                '''varSession(userSession.UserSectionURL, "")
                '''varSession(userSession.UserLogonCompanyName, "Sistema Area ingreso")
                '''varSession(userSession.UserFTPRoot, "")
                '''varSession(userSession.UserRoot, "/public")
                Return ""
            Catch ex As Exception
                Return "Error al iniciar datos de sesion"
            End Try
        End Function

        Public Shared Function LogOutSession()
            'Objetivo: limpio las variables de session
            System.Web.HttpContext.Current.Session.RemoveAll()
        End Function

        Public Shared Function usrSessionChangePassword(ByVal strNewPass As String)
            'objetivo: le cambia el password a la usuario de la session actual
            Dim strPosibleError As String
            Try
                ''''preparo el valor para insertarlo
                '''strNewPass = Logica.cBaseDatos.xSQL(strNewPass, cBaseDatos.MiTipoDeDatosSQL.Texto)
                '''Dim IDusuario As Integer = CType(Logica.cUtil.varSession(userSession.UserLogonID), Integer)

                '''Dim oBD As New Logica.cBaseDatos
                ''''verifico si esta el usuario en la BD
                '''strPosibleError = oBD.EjecutarAccion("UPDATE BREALMSITES_USERS SET " & _
                '''            " password = " & strNewPass & _
                '''            " WHERE  ID = " & IDusuario)

                ''''coloco el nuevo valor de password en la session actual
                '''Logica.cUtil.varSession(userSession.UserLogonPass, strNewPass)

                strPosibleError = "No esta implementada esta funcionalidad"
                Return strPosibleError
            Catch ex As Exception
                Return ex.Message
            End Try

        End Function

        Public Shared Sub varSession(ByVal strClave As userSession, ByRef strValor As Object)
            'objetivo: Colcoca un para valor clave para que sea recordado durante la sesion del usuario
            'in
            ' strClave : la clave
            ' strValor : la variable para colocar el valor
            'out
            ' Coloca en la strValor el valor, si es que existe

            Dim oSession As System.Web.SessionState.HttpSessionState = System.Web.HttpContext.Current.Session

            'verifico los valores nulos
            If strValor Is System.DBNull.Value Or strValor Is Nothing Then
                strValor = ""
            End If
            oSession.Item(CType(strClave, String)) = CType(strValor, String)

        End Sub
        Public Shared Function varSession(ByVal strClave As userSession) As String
            'objetivo: obtiene un valor a partir de la clave
            'in
            ' strClave : la clave
            'out
            ' retorna el valor de la clave o "" si no existe
            Dim oSession As System.Web.SessionState.HttpSessionState = System.Web.HttpContext.Current.Session
            Dim valRet As Object
            valRet = oSession.Item(CType(strClave, String))
            If valRet Is Nothing Then
                Return ""
            Else
                Return CType(valRet, String)
            End If
    End Function

    Public Shared Sub RedireccionarInicioPostulante(ByVal oResponse As System.Web.HttpResponse)
      'redirecciono a la pagina inicio
      oResponse.Redirect("~/postulante/lstBPost.aspx", False)
    End Sub

#End Region

    Public Shared Sub XML_Logerror(ByRef TituloError As String, ByRef dscError As String)
      'objetivo: guardar en un xml el error
      'in
      ' TituloError: el titulo del error
      ' dscError: la descripcion del error
      'out
      Dim miapp As New System.Web.HttpApplication
      Dim oDS As New DataSet
      Dim strArchivo As String = Logica.cUtil.GetAppRootPathFisicoTEMP() & "\logerrorApp.xml"

      oDS.ReadXml(strArchivo)

      oDS.Tables(0).Rows.Add(New Object() {Now(), TituloError, dscError})
            Try
                oDS.WriteXml(strArchivo)
            Catch ex As Exception
                Dim strError As String = ex.Message
            End Try
    End Sub

    Public Shared Sub XML_LogGenerico(ByRef Titulo As String, ByRef Descripcion As String)
      'objetivo: guardar en un xml el error
      'in
      ' Titulo: el titulo 
      ' Descripcion: la descripcion 
      'out
      Dim miapp As New System.Web.HttpApplication
      Dim oDS As New DataSet
      Dim strArchivo As String = Logica.cUtil.GetAppRootPathFisicoTEMP() & "\logGenericoApp.xml"

      oDS.ReadXml(strArchivo)

      oDS.Tables(0).Rows.Add(New Object() {Now(), Titulo, Descripcion})

      oDS.WriteXml(strArchivo)
    End Sub


    Public Shared Function Agregar1raFila(ByVal oDT As DataTable) As DataTable
      'Objetivo: agrega una fila al principio de todo para los combos del estilo
      '       (seleccionar) con ID = -1
      'in
      '   oDT: la datable a la que le agrego la fila
      'out:
      '    una datable con la fila agregada

      If IsNothing(oDT) Then
        oDT = New DataTable
        oDT.Columns.Add(New DataColumn("ID", Type.GetType("System.Int32")))
        oDT.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
      End If


      Dim oRW As DataRow
      oRW = oDT.NewRow
      oRW("ID") = -1
      oRW("Descripcion") = "( - - - )"
      oDT.Rows.InsertAt(oRW, 0)

      Return oDT
    End Function

    Public Shared Function encriptarHTML(ByVal strAEncriptar As String) As String
      'Objetivo: agrega una fila al principio de todo para los combos del estilo
      '       (seleccionar) con ID = -1
      'in
      '   oDT: la datable a la que le agrego la fila
      'out:
      '    una datable con la fila agregada
      Dim strHTML As New System.Text.StringBuilder
      Dim mtzChar() As Char = strAEncriptar.ToCharArray
      Dim i As Integer
      For i = 0 To mtzChar.Length - 1
        strHTML.Append("&#" & Asc(mtzChar(i)) & ";")
      Next

      Return strHTML.ToString
    End Function

    Public Shared Function Num2Text(ByVal value As Double) As String
      'objetivo: pasa el valor a letras
      Select Case value
        Case 0 : Num2Text = "CERO"
        Case 1 : Num2Text = "UN"
        Case 2 : Num2Text = "DOS"
        Case 3 : Num2Text = "TRES"
        Case 4 : Num2Text = "CUATRO"
        Case 5 : Num2Text = "CINCO"
        Case 6 : Num2Text = "SEIS"
        Case 7 : Num2Text = "SIETE"
        Case 8 : Num2Text = "OCHO"
        Case 9 : Num2Text = "NUEVE"
        Case 10 : Num2Text = "DIEZ"
        Case 11 : Num2Text = "ONCE"
        Case 12 : Num2Text = "DOCE"
        Case 13 : Num2Text = "TRECE"
        Case 14 : Num2Text = "CATORCE"
        Case 15 : Num2Text = "QUINCE"
        Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
        Case 20 : Num2Text = "VEINTE"
        Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
        Case 30 : Num2Text = "TREINTA"
        Case 40 : Num2Text = "CUARENTA"
        Case 50 : Num2Text = "CINCUENTA"
        Case 60 : Num2Text = "SESENTA"
        Case 70 : Num2Text = "SETENTA"
        Case 80 : Num2Text = "OCHENTA"
        Case 90 : Num2Text = "NOVENTA"
        Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
        Case 100 : Num2Text = "CIEN"
        Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
        Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
        Case 500 : Num2Text = "QUINIENTOS"
        Case 700 : Num2Text = "SETECIENTOS"
        Case 900 : Num2Text = "NOVECIENTOS"
        Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
        Case 1000 : Num2Text = "MIL"
        Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
        Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
          If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
        Case 1000000 : Num2Text = "UN MILLON"
        Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
        Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
          If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
        Case 1000000000000.0# : Num2Text = "UN BILLON"
        Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
          If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
      End Select

    End Function


    Public Shared Function ReadTextFile(ByVal path As String) As String
      'lee un archivo
      Dim sr As System.IO.StreamReader
      Dim Contents As String
      If File.Exists(path) Then
        sr = New StreamReader(path)
        Contents = sr.ReadToEnd()
        sr.Close()
      End If
      Return Contents
    End Function

    Public Shared Sub WriteTextFile(ByVal path As String, ByVal value As String)
      'escribe archivo
      Dim sr As StreamWriter
      Dim Contents As String
      If File.Exists(path) Then
        sr = New StreamWriter(path)
        sr.Write(value)
        sr.Close()
      End If
    End Sub


    Public Shared Sub BajarArchivoComo(ByVal Response As System.Web.HttpResponse, ByVal strContenidoArchivo As String, Optional ByVal extension As String = "txt", Optional ByVal nombreArchivo As String = "file", Optional ByVal Charset As String = "")
      'Descarga el contenido pasado, como un tipo determindo de archivo
      Response.ContentEncoding = System.Text.Encoding.UTF7
      Response.Clear()
      Response.AddHeader("content-disposition", "attachment;filename=" & nombreArchivo & "." & extension)
      Response.Charset = Charset
      Response.ContentType = "application/vnd." & extension
      Response.Write(strContenidoArchivo)
      Response.End()
    End Sub

    Public Shared Function BorrarArchivoDe(ByVal pathFile As String) As String
      'objetivo: borrar el archivo en el directorio especificado
      'in
      ' pathFile :la ruta en donde guardar el archivo incluido el nombre del archivo y la extension
      'out
      ' "" o el error
      Try


        If System.IO.File.Exists(pathFile) Then
          'si existe borro
          System.IO.File.Delete(pathFile)
        End If

        Return ""
      Catch ex As Exception
        Return ex.Message
      End Try
    End Function

    Public Shared Function GuardarArchivoEn(ByVal pathFile As String, ByRef file As System.Web.UI.HtmlControls.HtmlInputFile, Optional ByVal sobreEscribir As Boolean = True) As String
      'objetivo: guarda el archivo en el directorio especificado
      'in
      ' pathFile :la ruta en donde guardar el archivo incluido el nombre del archivo y la extension
      ' file: el control para guardar el archivo
      'out
      ' "" o el error
      Try
        If Not IsNothing(file) Then

          If System.IO.File.Exists(pathFile) Then
            ' ya existe
            If sobreEscribir Then
              'borro
              System.IO.File.Delete(pathFile)
              'coloco
              file.PostedFile.SaveAs(pathFile)
            End If
          Else
            'no existe, entonces  coloco
            file.PostedFile.SaveAs(pathFile)
          End If
        Else
          Throw New Exception("El contenido del control esta vacio")
        End If
        Return ""
      Catch ex As Exception
        Return ex.Message
      End Try
    End Function

    Public Shared Function getNodo(ByRef oDoc As XmlDocument, ByVal xPATH As String) As String
      'objetivo: obtiene el innerText del nodo con el PATH
      'in
      ' oDoc
      ' xPATH
      'out
      If oDoc.SelectSingleNode(xPATH) Is Nothing Then
        Return ""
      Else
        Return oDoc.SelectSingleNode(xPATH).InnerText()
      End If
    End Function
    Public Shared Function getNodo(ByRef oDoc As XmlNode, ByVal xPATH As String) As String
      'objetivo: obtiene el innerText del nodo con el PATH
      'in
      ' oDoc
      ' xPATH
      'out
      If oDoc.SelectSingleNode(xPATH) Is Nothing Then
        Return ""
      Else
        Return oDoc.SelectSingleNode(xPATH).InnerText()
      End If
    End Function
  End Class
End Namespace
