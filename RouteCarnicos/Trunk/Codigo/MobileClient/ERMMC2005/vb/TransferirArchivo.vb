Public Class TransferirArchivo
    Implements IDisposable
    Public Enum TraEstados
        Nuevo
        Iniciado
        Transferido
        Fallido
        Cancelado
    End Enum
    Private Class Transferir
        Implements IDisposable

        Private _url As String
        Private _dest As String
        Private _estado As TraEstados
        Private _bytesReci As Integer
        Private _cancelar As Boolean
        Private _bytesTotales As Integer
        Private _requestTimeOut As Integer
        Private _response As System.Net.WebResponse
        Private _error As String
        Public ReadOnly Property DescError() As String
            Get
                Return _error
            End Get
        End Property

        Public ReadOnly Property Estado() As TraEstados
            Get
                If _bytesTotales = _bytesReci Then
                    _estado = TraEstados.Transferido
                End If
                Return _estado
            End Get
        End Property
        Public ReadOnly Property BytesRecibidos() As Integer
            Get
                Return _bytesReci
            End Get
        End Property
        Public ReadOnly Property BytesTotales() As Integer
            Get
                Return _bytesTotales
            End Get
        End Property

        Public Sub Cancelar()
            Me._cancelar = True
        End Sub
        Public Sub DescargarAsincrono()
            Dim success As Boolean = False
            Me._cancelar = False
            If _estado = TraEstados.Nuevo Then
                Dim responseStream As System.IO.Stream = Nothing
                Dim fileStream As System.IO.FileStream = Nothing
                _bytesReci = 0
                _estado = TraEstados.Iniciado
                _error = ""
                Try
                    _bytesTotales = _response.ContentLength

                    responseStream = _response.GetResponseStream()

                    fileStream = System.IO.File.Open(Me._dest, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None)

                    Dim maxRead As Integer = 10240
                    Dim buffer As Byte() = New Byte(maxRead - 1) {}
                    Dim bytesRead As Integer = 0


                    Do
                        bytesRead = responseStream.Read(buffer, 0, maxRead)
                        If bytesRead > 0 Then

                            Me._bytesReci += bytesRead
                            fileStream.Write(buffer, 0, bytesRead)
                            If Me._cancelar Then
                                Exit Do
                            End If
                        End If
                    Loop While Me._bytesReci <> _bytesTotales
                    If Me._cancelar OrElse Me._bytesReci <> _bytesTotales Then
                        success = False
                    Else
                        success = True
                    End If
                Catch exp As Exception
                    If exp.Message.Length > 0 Then
                        _error = exp.Message
                    Else
                        _error = "Error Desconocido"
                    End If

                    success = False
                    Debug.WriteLine(exp)
                Finally

                    If responseStream IsNot Nothing Then
                        responseStream.Close()
                    End If
                    If _response IsNot Nothing Then
                        _response.Close()
                    End If
                    If fileStream IsNot Nothing Then
                        fileStream.Close()
                    End If
                End Try
            End If

            If Not success Then
                If System.IO.File.Exists(Me._dest) Then
                    System.IO.File.Delete(Me._dest)
                End If
                If Me._cancelar Then
                    _estado = TraEstados.Cancelado
                Else
                    _estado = TraEstados.Fallido
                End If
            Else
                _estado = TraEstados.Transferido
            End If

        End Sub

        Public Sub Nuevo(ByVal url As String, ByVal dest As String)
            Nuevo(url, dest, 100000)
        End Sub
        Public Sub Nuevo(ByVal url As String, ByVal dest As String, ByVal reqTimeout As Integer)
            _url = url
            _dest = dest
            _bytesTotales = -1
            _estado = TraEstados.Nuevo
            _requestTimeOut = reqTimeout
            _error = ""
            Try
                Dim request As System.Net.HttpWebRequest = Nothing
                request = DirectCast(System.Net.WebRequest.Create(Me._url), System.Net.HttpWebRequest)
                request.Method = "GET"
                request.Timeout = _requestTimeOut
                _response = request.GetResponse()
            Catch ex As Exception
                If ex.Message.Length > 0 Then
                    _error = ex.Message
                Else
                    _error = "Error Desconocido"
                End If
                If _response IsNot Nothing Then
                    _response.Close()
                End If
                _estado = TraEstados.Fallido
            End Try

        End Sub
        Public Sub New()
            _requestTimeOut = 100000
        End Sub

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    If _response IsNot Nothing Then
                        _response.Close()
                    End If
                End If

                ' TODO: free shared unmanaged resources
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Private _trans As New Transferir
    Private _hilo As System.Threading.Thread
    Dim _tempo As New Timer()
    ''' <summary>
    ''' Obtiene la descripcion del error en caso de que exista alguno
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DescError() As String
        Get
            Return _trans.DescError
        End Get
    End Property
    ''' <summary>
    ''' Obtiene los bytes recibidos hasta el momento
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property BytesRecibidos() As Integer
        Get
            Return _trans.BytesRecibidos
        End Get
    End Property
    ''' <summary>
    ''' Obtiene los bytes totales de la transferencia
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property BytesTotales() As Integer
        Get
            Return _trans.BytesTotales
        End Get
    End Property
    ''' <summary>
    ''' Obtiene el Estado actual de la transferencia del archivo
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Estado() As TraEstados
        Get
            Return _trans.Estado
        End Get
    End Property
    ''' <summary>
    ''' Inicia un proceso asincrono de Descarga de Archivos
    ''' </summary>
    ''' <param name="url">la direccion web del archivo que se va a descargar</param>
    ''' <param name="destino">la ruta en el dispositivo para guardar</param>
    ''' <returns></returns>
    ''' <remarks>Mientras se ejecuta la propiedad Estado se encuentra en TraEstados.Iniciado
    '''  Al terminar establece la propiedad Estado segun el resultado de la transferencia a:
    ''' TraEstados.Transferido (Se transfirio el Archivo Exitosamente)
    ''' TraEstados.Fallido (Por alguna causa Fallo el envio de datos, la razon se establece en la propiedad DescError
    ''' TraEstados.Cancelado (Se establece cuando se ejecuta el metodo Cancelar)</remarks>
    Public Function Descargar(ByVal url As String, ByVal destino As String) As Boolean
        Return Descargar(url, destino, 100000)
    End Function
    ''' <summary>
    ''' Inicia un proceso asincrono de Descarga de Archivos
    ''' </summary>
    ''' <param name="url">la direccion web del archivo que se va a descargar</param>
    ''' <param name="destino">la ruta en el dispositivo para guardar</param>
    ''' <param name="TimeOut">el tiempo de espera de respuesta del servidor en milisegundos</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Descargar(ByVal url As String, ByVal destino As String, ByVal TimeOut As Integer) As Boolean
        Dim res As Boolean = False
        If _trans.Estado <> TraEstados.Iniciado Then
            _trans.Nuevo(url, destino, TimeOut)
            If _trans.Estado = TraEstados.Nuevo Then
                _hilo = New System.Threading.Thread(AddressOf _trans.DescargarAsincrono)
                _hilo.Start()
                System.Threading.Thread.Sleep(1000)
                _tempo = New Timer()
                _tempo.Enabled = False
                AddHandler _tempo.Tick, AddressOf tempo_tick
                _tempo.Interval = 100
                _tempo.Enabled = True
                res = True
            End If
        End If
        Return res
    End Function
    ''' <summary>
    ''' Cancela la transferencia actual
    ''' </summary>
    ''' <remarks>al cancelar establece el Estado en TraEstados.Cancelado</remarks>
    Public Sub Cancelar()
        _trans.Cancelar()
    End Sub

    Private Sub tempo_tick(ByVal sender As Object, ByVal e As System.EventArgs)
        If _trans.Estado <> TraEstados.Iniciado Then
            _tempo.Enabled = False
            RemoveHandler _tempo.Tick, AddressOf tempo_tick
            _tempo.Dispose()
        End If
    End Sub

    Private disposedValue As Boolean = False        ' To detect redundant calls

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                _trans.Cancelar()
                _trans.Dispose()
                _tempo.Enabled = False
                _tempo.Dispose()
            End If
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
