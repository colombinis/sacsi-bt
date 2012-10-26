
Imports System.Net.Sockets
Imports System.Text

Public Class mServer


  Private _tcpClient As System.Net.Sockets.TcpClient
  Private _networkStream As networkStream

  Public Sub New()
    'constructor vacio
  End Sub
  
  Private Function get_tcpClient() As System.Net.Sockets.TcpClient
    If _tcpClient Is Nothing Then
      _tcpClient = New System.Net.Sockets.TcpClient
    End If
    Return _tcpClient
  End Function

  Public Sub Nuevo(ByVal server As String, ByVal port As Integer)
    Try
      get_tcpClient().Connect(server, port)
      _networkStream = _tcpClient.GetStream()
    Catch ex As Exception
      '''Liberar()
      'Throw New Exception("Error: al conectar con el servidor de correo")
      Throw New Exception("Error:" & ex.Message)
    End Try
  End Sub

  Public Function Leer()
    'obtengo la salida
    '''If _networkStream.CanRead AndAlso _networkStream.DataAvailable Then
    If _networkStream.CanRead Then
      'Leo el saludo del server
      Dim bytes(_tcpClient.ReceiveBufferSize) As Byte
      _networkStream.Read(bytes, 0, CInt(_tcpClient.ReceiveBufferSize))
      Dim returndata As String = Encoding.ASCII.GetString(bytes)
      Return returndata
    Else
      Throw New Exception("Error en la lectura. CanRead : " & IIf(_networkStream.CanRead, "SI", "NO") & " DataAvailable: " & IIf(_networkStream.DataAvailable, "SI", "NO"))
    End If
  End Function

  Public Sub Escribir(ByVal msg As String)
    'envio comandos
    'agrego el fin de mensaje
    msg &= vbNewLine
    If _networkStream.CanWrite Then
      Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(msg)
      _networkStream.Write(sendBytes, 0, sendBytes.Length)
    Else
      Throw New Exception("Error en la escritura")
    End If
  End Sub

  '''Public Function Liberar()
  '''  'objetivo: libera los recursos
  '''  If Not _networkStream Is Nothing Then _networkStream.Close()
  '''  If Not _tcpClient Is Nothing Then _tcpClient.Close()
  '''End Function

  Public Function CuentaValida(ByVal usuario As String, ByVal password As String, ByRef strPosibleError As String) As Boolean
    Dim retorno As Boolean = False
    Try
      Dim lectura As String

      lectura = Leer()
      If lectura.Substring(0, 3) <> "+OK" Then
        strPosibleError = lectura
        Throw New Exception("Error al conectar con el server")
      End If

      Escribir("USER " & usuario)
      lectura = Leer()
      If lectura.Substring(0, 3) <> "+OK" Then
        strPosibleError = lectura
        Throw New Exception("Error en el usuario")
      End If

      Escribir("PASS " & password)
      lectura = Leer()
      If lectura.Substring(0, 3) <> "+OK" Then
        strPosibleError = lectura
        Throw New Exception("Error en el password")
      End If

      Escribir("QUIT")
      lectura = Leer()
      If lectura.Substring(0, 3) <> "+OK" Then
        strPosibleError = lectura
        Throw New Exception("Error al desconectarse del POP3")
      End If

      Return True
    Catch ex As Exception
      strPosibleError = ex.Message
      Return False
    End Try

  End Function

  '''Public Function Leer1(Optional ByVal multiLine As Boolean = False) As String
  '''    'GetResponse wraps the work of waiting for a server response to complete
  '''    'Single-Line and Multi-Line responses end
  '''    'differently, so they need slightly different end conditions.
  '''    Dim sOutput As String = ""
  '''    Dim input As Integer
  '''    Dim str(4096) As Byte
  '''    Dim startTime As Date = Now
  '''    Dim endCondition As String

  '''    If multiLine Then
  '''        endCondition = vbCrLf & vbCrLf & "."
  '''    Else
  '''        endCondition = vbCrLf
  '''    End If

  '''    Do
  '''        While networkStream.DataAvailable()
  '''            input = networkStream.Read(str, 0, 4096)
  '''            sOutput &= ASCIIEncoding.ASCII.GetChars(str, 0, input)
  '''        End While
  '''    Loop Until sOutput.IndexOf(endCondition) >= 0

  '''    If sOutput.IndexOf(endCondition) < 0 Then
  '''        Return sOutput
  '''    Else
  '''        Return sOutput
  '''    End If
  '''End Function

End Class

