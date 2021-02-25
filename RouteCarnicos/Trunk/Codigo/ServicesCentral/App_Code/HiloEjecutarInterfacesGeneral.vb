Imports Microsoft.VisualBasic
Imports System.Threading

Public Class HiloEjecutarInterfacesGeneral
    Private Class HiloParametro
        Private _vendedorid As String
        Private _fechainicio As DateTime
        Private _fechaprimerdia As DateTime
        Public ReadOnly Property VendedorId() As String
            Get
                Return _vendedorid
            End Get
        End Property
        Public ReadOnly Property FechaInicio() As DateTime
            Get
                Return _fechainicio
            End Get
        End Property
        Public ReadOnly Property FechaPrimerDia() As DateTime
            Get
                Return _fechaprimerdia
            End Get
        End Property
        Public Sub New(ByVal vendedorid As String, ByVal fechainicio As DateTime, ByVal fechaprimerdia As DateTime)
            _vendedorid = vendedorid
            _fechainicio = fechainicio
            _fechaprimerdia = fechaprimerdia
        End Sub
    End Class
    Private _hiloejecuta As Thread

    Private _listaParametros As System.Collections.Generic.Queue(Of HiloParametro)


    Public Sub New()
        _listaParametros = New System.Collections.Generic.Queue(Of HiloParametro)
        _hiloejecuta = New Thread(AddressOf Ejecutar)
    End Sub
    Public Sub Agregar(ByVal vendedorid As String, ByVal fechainicio As DateTime, ByVal fechaprimerdia As DateTime)
        Dim par As New HiloParametro(vendedorid, fechainicio, fechaprimerdia)
        _listaParametros.Enqueue(par)
    End Sub
    Private Sub Ejecutar()
        Do While _listaParametros.Count <> 0
            Dim par As HiloParametro = _listaParametros.Dequeue()
            EjecutarInterfaces(par.VendedorId, par.FechaInicio, par.FechaPrimerDia, "", False)
        Loop
    End Sub
    Public Sub EjecutarInterfaces()
        If _hiloejecuta.ThreadState <> ThreadState.Running Then
            If _hiloejecuta.ThreadState <> ThreadState.Unstarted Then
                _hiloejecuta = New Thread(AddressOf Ejecutar)
            End If
            _hiloejecuta.Start()
        End If
        Thread.Sleep(1000)
    End Sub
    Private Function EjecutarInterfaces(ByVal parsVendedorID As String, ByVal pardFechaInicial As Date, ByVal pardFechaPrimerDia As Date, ByRef refparsMensaje As String, ByRef refparbReintentar As Boolean) As Boolean
        Dim oVendedor As New MobileClient.Vendedor
        Dim bResult As Boolean
        oVendedor.VendedorId = parsVendedorID
        oVendedor.Recuperar()
        refparbReintentar = True
        bResult = oVendedor.EjecutarInterfaces(pardFechaInicial, pardFechaPrimerDia, refparsMensaje, refparbReintentar)
        Return bResult
    End Function
End Class
