Public Enum eEstado
    Vacio = 0
    Nuevo
    Modificado
    Recuperado
    Eliminado
End Enum

Public Class cCliente
    Private vcCliente As LbDatos.cTabla
    Friend vcCLDArrayList As New ArrayList
    Friend vcCLDDataTable As New DataTable
    Private vcCLDTabla As cCLDTabla
    Friend vcCLPArrayList As New ArrayList
    Friend vcCLPDataTable As New DataTable
    Private vcCLPTabla As cCLPTabla
    Friend vcCLEArrayList As New ArrayList
    Friend vcCLEDataTable As New DataTable
    Private vcCLETabla As cCLETabla
    Friend vcCFVArrayList As New ArrayList
    Friend vcCFVDataTable As New DataTable
    Private vcCFVTabla As cCFVTabla

    Friend vcCNDIArrayList As New ArrayList
    Friend vcCNDIDataTable As New DataTable
    Private vcCNDITabla As cCNDITabla

    Friend vcCCNCArrayList As New ArrayList
    Friend vcCCNCDataTable As New DataTable
    Private vcCCNCTabla As cCCNCTabla

    Public Tabla As cCLITabla
    Public dsDatos As cCLIDataSet
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcEstado As eEstado
    Private bEnBloqueo As Boolean
    Private sEsquemasCliente As String


#Region "Propiedades"
    Public Property ClienteClave() As String
        Get
            Return IIf(IsDBNull(vcCliente.Campos("ClienteClave").Valor), String.Empty, vcCliente.Campos("ClienteClave").Valor)
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcCliente.Campos("ClienteClave").Valor = Value
            End If
        End Set
    End Property

    Public Property ImpuestoClave() As String
        Get
            Return IIf(IsDBNull(vcCliente.Campos("ImpuestoClave").Valor), String.Empty, vcCliente.Campos("ImpuestoClave").Valor)
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcCliente.Campos("ImpuestoClave").Valor = Value
            End If
        End Set
    End Property

    Public Property Clave() As String
        Get
            Return IIf(IsDBNull(vcCliente.Campos("Clave").Valor), String.Empty, vcCliente.Campos("Clave").Valor)
        End Get
        Set(ByVal Value As String)
            vcCliente.Campos("Clave").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property CNPId() As String
        Get
            If IsDBNull(vcCliente.Campos("CNPId").Valor) Then
                Return Nothing
            Else
                Return vcCliente.Campos("CNPId").Valor
            End If
        End Get
        Set(ByVal Value As String)
            vcCliente.Campos("CNPId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property IdElectronico() As String
        Get
            Return IIf(IsDBNull(vcCliente.Campos("IdElectronico").Valor), String.Empty, vcCliente.Campos("IdElectronico").Valor)
        End Get
        Set(ByVal Value As String)
            vcCliente.Campos("IdElectronico").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property IdFiscal() As String
        Get
            Return IIf(IsDBNull(vcCliente.Campos("IdFiscal").Valor), String.Empty, vcCliente.Campos("IdFiscal").Valor)
        End Get
        Set(ByVal Value As String)
            vcCliente.Campos("IdFiscal").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property RazonSocial() As String
        Get
            Return IIf(IsDBNull(vcCliente.Campos("RazonSocial").Valor), String.Empty, vcCliente.Campos("RazonSocial").Valor)
        End Get
        Set(ByVal Value As String)
            vcCliente.Campos("RazonSocial").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoFiscal() As Integer
        Get
            Return IIf(IsDBNull(vcCliente.Campos("TipoFiscal").Valor), 0, vcCliente.Campos("TipoFiscal").Valor)
        End Get
        Set(ByVal Value As Integer)
            vcCliente.Campos("TipoFiscal").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoImpuesto() As Integer
        Get
            Return IIf(IsDBNull(vcCliente.Campos("TipoImpuesto").Valor), 0, vcCliente.Campos("TipoImpuesto").Valor)
        End Get
        Set(ByVal Value As Integer)
            vcCliente.Campos("TipoImpuesto").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property NombreContacto() As String
        Get
            Return IIf(IsDBNull(vcCliente.Campos("NombreContacto").Valor), String.Empty, vcCliente.Campos("NombreContacto").Valor)
            ' Return vcCliente.Campos("NombreContacto").Valor
        End Get
        Set(ByVal Value As String)
            vcCliente.Campos("NombreContacto").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TelefonoContacto() As String
        Get
            Return IIf(IsDBNull(vcCliente.Campos("TelefonoContacto").Valor), String.Empty, vcCliente.Campos("TelefonoContacto").Valor)
        End Get
        Set(ByVal Value As String)
            vcCliente.Campos("TelefonoContacto").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property FechaRegistroSistema() As Date
        Get
            Return IIf(IsDBNull(vcCliente.Campos("FechaRegistroSistema").Valor), Nothing, vcCliente.Campos("FechaRegistroSistema").Valor)
        End Get
        Set(ByVal Value As Date)
            vcCliente.Campos("FechaRegistroSistema").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property FechaNacimiento() As Date
        Get
            Return IIf(IsDBNull(vcCliente.Campos("FechaNacimiento").Valor), "01/01/1900", vcCliente.Campos("FechaNacimiento").Valor)
        End Get
        Set(ByVal Value As Date)
            vcCliente.Campos("FechaNacimiento").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property LimiteCreditoDinero() As Double
        Get
            Return IIf(IsDBNull(vcCliente.Campos("LimiteCreditoDinero").Valor), Nothing, vcCliente.Campos("LimiteCreditoDinero").Valor)
        End Get
        Set(ByVal Value As Double)
            vcCliente.Campos("LimiteCreditoDinero").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property NombreCorto() As String
        Get
            Return IIf(IsDBNull(vcCliente.Campos("NombreCorto").Valor), String.Empty, vcCliente.Campos("NombreCorto").Valor)
        End Get
        Set(ByVal Value As String)
            vcCliente.Campos("NombreCorto").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoEstado() As Integer
        Get
            Return IIf(IsDBNull(vcCliente.Campos("TipoEstado").Valor), 0, vcCliente.Campos("TipoEstado").Valor)
        End Get
        Set(ByVal Value As Integer)
            vcCliente.Campos("TipoEstado").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property LimiteDescuento() As Double
        Get
            Return IIf(IsDBNull(vcCliente.Campos("LimiteDescuento").Valor), 0, vcCliente.Campos("LimiteDescuento").Valor)
        End Get
        Set(ByVal Value As Double)
            vcCliente.Campos("LimiteDescuento").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property SaldoEfectivo() As Double
        Get

            Return IIf(IsDBNull(vcCliente.Campos("SaldoEfectivo").Valor), 0, vcCliente.Campos("SaldoEfectivo").Valor)
        End Get
        Set(ByVal Value As Double)
            vcCliente.Campos("SaldoEfectivo").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Prestamo() As Boolean
        Get
            On Error Resume Next
            Return vcCliente.Campos("Prestamo").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcCliente.Campos("Prestamo").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property SaldoPrestamo() As Double
        Get
            Return vcConexion.EjecutarComandoScalar("select isnull(sum(saldo),0) as saldo from productoprestamocli where clienteclave='" & Me.ClienteClave & "' and saldo <> 0 ")
        End Get
    End Property
    Public Property Exclusividad() As Boolean
        Get
            Return IIf(IsDBNull(vcCliente.Campos("Exclusividad").Valor), 0, vcCliente.Campos("Exclusividad").Valor)
        End Get
        Set(ByVal Value As Boolean)
            vcCliente.Campos("Exclusividad").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property VigExclusividad() As Date
        Get
            Return IIf(IsDBNull(vcCliente.Campos("VigExclusividad").Valor), "01/01/1900", vcCliente.Campos("VigExclusividad").Valor)
        End Get
        Set(ByVal Value As Date)
            vcCliente.Campos("VigExclusividad").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property ActualizaSaldoCheque() As Boolean
        Get
            Return IIf(IsDBNull(vcCliente.Campos("ActualizaSaldoCheque").Valor), 0, vcCliente.Campos("ActualizaSaldoCheque").Valor)
        End Get
        Set(ByVal Value As Boolean)
            vcCliente.Campos("ActualizaSaldoCheque").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property VencimientoVenta() As Boolean
        Get
            Return IIf(IsDBNull(vcCliente.Campos("VencimientoVenta").Valor), 0, vcCliente.Campos("VencimientoVenta").Valor)
        End Get
        Set(ByVal Value As Boolean)
            vcCliente.Campos("VencimientoVenta").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property DesgloseImpuesto() As Boolean
        Get
            Return IIf(IsDBNull(vcCliente.Campos("DesgloseImpuesto").Valor), 0, vcCliente.Campos("DesgloseImpuesto").Valor)
        End Get
        Set(ByVal Value As Boolean)
            vcCliente.Campos("DesgloseImpuesto").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property CorreoElectronico() As String
        Get
            Return IIf(IsDBNull(vcCliente.Campos("CorreoElectronico").Valor), String.Empty, vcCliente.Campos("CorreoElectronico").Valor)
        End Get
        Set(ByVal Value As String)
            vcCliente.Campos("CorreoElectronico").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property DiasVencimiento() As Integer
        Get
            Return IIf(IsDBNull(vcCliente.Campos("DiasVencimiento").Valor), 0, vcCliente.Campos("DiasVencimiento").Valor)
        End Get
        Set(ByVal Value As Integer)
            vcCliente.Campos("DiasVencimiento").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property SaldoGarantia() As Double
        Get

            Return IIf(IsDBNull(vcCliente.Campos("SaldoGarantia").Valor), 0, vcCliente.Campos("SaldoGarantia").Valor)
        End Get
        Set(ByVal Value As Double)
            vcCliente.Campos("SaldoGarantia").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property FechaFactura() As Date
        Get
            Return IIf(IsDBNull(vcCliente.Campos("FechaFactura").Valor), Nothing, vcCliente.Campos("FechaFactura").Valor)
        End Get
        Set(ByVal Value As Date)
            vcCliente.Campos("FechaFactura").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return IIf(IsDBNull(vcCliente.Campos("MUsuarioId").Valor), String.Empty, vcCliente.Campos("MUsuarioId").Valor)
        End Get
        Set(ByVal Value As String)
            vcCliente.Campos("MUsuarioId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As Date
        Get
            Return IIf(IsDBNull(vcCliente.Campos("MFechaHora").Valor), "01/01/1900", vcCliente.Campos("MFechaHora").Valor)
        End Get
    End Property

    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcCliente
        End Get
    End Property

    Public ReadOnly Property cEstado() As eEstado
        Get
            Return vcEstado
        End Get
    End Property

    Public ReadOnly Property SaldoProducto() As Double
        Get
            Return vcConexion.EjecutarComandoScalar("select isnull(sum(saldo),0) as saldo from productoprestamocli where clienteclave='" & Me.ClienteClave & "' and saldo <> 0 ")
        End Get
    End Property

    Public Property ExigirOrdenCompra() As Boolean
        Get
            Return IIf(IsDBNull(vcCliente.Campos("ExigirOrdenCompra").Valor), False, vcCliente.Campos("ExigirOrdenCompra").Valor)
        End Get
        Set(ByVal value As Boolean)
            vcCliente.Campos("ExigirOrdenCompra").Valor = value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property CriterioCredito() As Boolean
        Get
            Return IIf(IsDBNull(vcCliente.Campos("CriterioCredito").Valor), False, vcCliente.Campos("CriterioCredito").Valor)
        End Get
        Set(ByVal value As Boolean)
            vcCliente.Campos("CriterioCredito").Valor = value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property ImprimirPagare() As Boolean
        Get
            Return IIf(IsDBNull(vcCliente.Campos("ImprimirPagare").Valor), False, vcCliente.Campos("ImprimirPagare").Valor)
        End Get
        Set(ByVal value As Boolean)
            vcCliente.Campos("ImprimirPagare").Valor = value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property CapturaDatosFacturacion() As Boolean
        Get
            Return IIf(IsDBNull(vcCliente.Campos("CapturaDatosFacturacion").Valor), False, vcCliente.Campos("CapturaDatosFacturacion").Valor)
        End Get
        Set(ByVal value As Boolean)
            vcCliente.Campos("CapturaDatosFacturacion").Valor = value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property EsquemasCliente() As String
        Get
            Return sEsquemasCliente
        End Get
    End Property

#End Region

#Region "Funciones"

    Public Sub New()
        vcCliente = New LbDatos.cTabla("Cliente")
        vcCLDTabla = New cCLDTabla(Me)
        vcCLPTabla = New cCLPTabla(Me)
        vcCLETabla = New cCLETabla(Me)
        vcCFVTabla = New cCFVTabla(Me)
        vcCNDITabla = New cCNDITabla(Me)
        vcCCNCTabla = New cCCNCTabla(Me)

        Tabla = New cCLITabla(Me)
        dsDatos = New cCLIDataSet(Me)
        vcCLDDataTable = ClienteDomicilio.Tabla.Recuperar("ClienteClave=''")
        vcCLPDataTable = ClientePago.Tabla.Recuperar("ClienteClave=''")
        vcCLEDataTable = ClienteEsquema.Tabla.Recuperar("ClienteClave=''")
        vcCFVDataTable = CLIFormaVenta.Tabla.Recuperar("ClienteClave=''")
        vcCNDIDataTable = CLINoDesImp.Tabla.Recuperar("ClienteClave=''")
        vcCCNCDataTable = CLIConfNumCta.Tabla.Recuperar("ClienteClave=''")


        vcCliente.AgregarCampo(New LbDatos.cCampo("ClienteClave", LbDatos.ETipo.Cadena, "", True, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("Clave", LbDatos.ETipo.Cadena, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("CNPId", LbDatos.ETipo.Cadena, System.DBNull.Value, False, False, True, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("IdElectronico", LbDatos.ETipo.Cadena, False))
        vcCliente.AgregarCampo(New LbDatos.cCampo("IdFiscal", LbDatos.ETipo.Cadena, False))
        vcCliente.AgregarCampo(New LbDatos.cCampo("RazonSocial", LbDatos.ETipo.Cadena, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("TipoFiscal", LbDatos.ETipo.Numerico, System.DBNull.Value, False, True, False))
        vcCliente.AgregarCampo(New LbDatos.cCampo("TipoImpuesto", LbDatos.ETipo.Numerico, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("NombreContacto", LbDatos.ETipo.Cadena, False))
        vcCliente.AgregarCampo(New LbDatos.cCampo("TelefonoContacto", LbDatos.ETipo.Cadena, False))
        vcCliente.AgregarCampo(New LbDatos.cCampo("FechaRegistroSistema", LbDatos.ETipo.Fecha, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("FechaNacimiento", LbDatos.ETipo.Fecha, False))
        vcCliente.AgregarCampo(New LbDatos.cCampo("LimiteCreditoDinero", LbDatos.ETipo.Numerico, False))
        vcCliente.AgregarCampo(New LbDatos.cCampo("NombreCorto", LbDatos.ETipo.Cadena, False))
        vcCliente.AgregarCampo(New LbDatos.cCampo("TipoEstado", LbDatos.ETipo.Numerico, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("LimiteDescuento", LbDatos.ETipo.Numerico, False))
        vcCliente.AgregarCampo(New LbDatos.cCampo("SaldoEfectivo", LbDatos.ETipo.Numerico, System.DBNull.Value, False, False, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("Prestamo", LbDatos.ETipo.Bit, False))
        'vcCliente.AgregarCampo(New LbDatos.cCampo("SaldoPrestamo", LbDatos.ETipo.Numerico, System.DBNull.Value, False, False,  True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("Exclusividad", LbDatos.ETipo.Bit, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("VigExclusividad", LbDatos.ETipo.Fecha, False))
        vcCliente.AgregarCampo(New LbDatos.cCampo("ActualizaSaldoCheque", LbDatos.ETipo.Bit, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("VencimientoVenta", LbDatos.ETipo.Bit, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("DiasVencimiento", LbDatos.ETipo.Numerico, False))
        vcCliente.AgregarCampo(New LbDatos.cCampo("SaldoGarantia", LbDatos.ETipo.Numerico, System.DBNull.Value, False, False, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("FechaFactura", LbDatos.ETipo.Fecha, False))
        vcCliente.AgregarCampo(New LbDatos.cCampo("DesgloseImpuesto", LbDatos.ETipo.Bit, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("CorreoElectronico", LbDatos.ETipo.Cadena, False))

        vcCliente.AgregarCampo(New LbDatos.cCampo("ExigirOrdenCompra", LbDatos.ETipo.Bit, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("CriterioCredito", LbDatos.ETipo.Bit, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("ImprimirPagare", LbDatos.ETipo.Bit, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("CapturaDatosFacturacion", LbDatos.ETipo.Bit, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("MUsuarioId", LbDatos.ETipo.Cadena, "", False, True))
        vcCliente.AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, "", False, , True))

        vcEstado = eEstado.Vacio
    End Sub

    Public Function Bloquear(ByVal pvMUsuarioId As String) As String
        Dim vlMUsuarioId As String

        vlMUsuarioId = MUsuarioId
        MUsuarioId = pvMUsuarioId
        Try
            bEnBloqueo = True
            Grabar()
            bEnBloqueo = False
        Catch ex As LbControlError.cError
            bEnBloqueo = False
            Throw New LbControlError.cError("BI0001", vlMUsuarioId)
        End Try
        Bloquear = vlMUsuarioId
    End Function

    Public Sub Insertar(ByVal pvClienteClave As String, ByVal pvClave As String, ByVal pvCNPId As String, ByVal pvIdElectronico As String, ByVal pvIdFiscal As String, _
                        ByVal pvRazonSocial As String, ByVal pvTipoFiscal As Integer, ByVal pvTipoImpuesto As Integer, _
                        ByVal pvNombreContacto As String, ByVal pvTelefonoContacto As String, ByVal pvFechaRegistroSistema As Date, _
                        ByVal pvFechaNacimiento As Date, ByVal pvLimiteCreditoDinero As Double, ByVal pvNombreCorto As String, _
                        ByVal pvTipoEstado As Integer, ByVal pvLimiteDescuento As Double, ByVal pvSaldoEfectivo As Double, _
                        ByVal pvPrestamo As Boolean, ByVal pvSaldoPrestamo As Double, ByVal pvExclusividad As Boolean, _
                        ByVal pvVigExclusividad As Date, ByVal pvActualizaSaldoCheque As Boolean, ByVal pvVencimientoVenta As Boolean, _
                        ByVal pvDiasVencimiento As Integer, ByVal pvSaldoGarantia As Double, ByVal pvDesgloseImpuesto As Boolean, ByVal pvCorreoElectronico As String, _
                        ByVal pvExigirOrdenCompra As Boolean, ByVal pvCriterioCredito As Boolean, ByVal pvImprimirPagare As Boolean, ByVal pvCapturaDatosFacturacion As String, ByVal pvMUsuarioId As String)
        Call Limpiar()
        ClienteClave = pvClienteClave
        Clave = pvClave
        CNPId = pvCNPId
        IdElectronico = pvIdElectronico
        IdFiscal = pvIdFiscal
        RazonSocial = pvRazonSocial
        TipoFiscal = pvTipoFiscal
        TipoImpuesto = pvTipoImpuesto
        NombreContacto = pvNombreContacto
        TelefonoContacto = pvTelefonoContacto
        FechaRegistroSistema = pvFechaRegistroSistema
        FechaNacimiento = pvFechaNacimiento
        LimiteCreditoDinero = pvLimiteCreditoDinero
        NombreCorto = pvNombreCorto
        TipoEstado = pvTipoEstado
        LimiteDescuento = pvLimiteDescuento
        SaldoEfectivo = pvSaldoEfectivo
        Prestamo = pvPrestamo
        Exclusividad = pvExclusividad
        VigExclusividad = pvVigExclusividad
        ActualizaSaldoCheque = pvActualizaSaldoCheque
        VencimientoVenta = pvVencimientoVenta
        DiasVencimiento = pvDiasVencimiento
        'SaldoPrestamo = pvSaldoPrestamo
        SaldoGarantia = pvSaldoGarantia
        DesgloseImpuesto = pvDesgloseImpuesto
        CorreoElectronico = pvCorreoElectronico
        ExigirOrdenCompra = pvExigirOrdenCompra
        CriterioCredito = pvCriterioCredito
        ImprimirPagare = pvImprimirPagare
        CapturaDatosFacturacion = pvCapturaDatosFacturacion
        MUsuarioId = pvMUsuarioId
        Call Insertar()
    End Sub

    Public Sub Insertar()
        Try
            If Existe(Me.ClienteClave, Me.Clave) Then
                Throw New LbControlError.cError("BE0002", , "Clave")
            End If
            ValidarCampos()
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        vcEstado = eEstado.Nuevo
    End Sub

    Public Sub Limpiar()
        For Each vlCampo As LbDatos.cCampo In vcCliente.Campos
            If vlCampo.Tipo = LbDatos.ETipo.Numerico Then
                vlCampo.Valor = System.DBNull.Value
            Else
                vlCampo.Valor = Nothing
            End If
        Next
        vcCLDArrayList.Clear()
        vcCLDDataTable.Reset()
        vcCLPArrayList.Clear()
        vcCLPDataTable.Reset()
        vcCLEArrayList.Clear()
        vcCLEDataTable.Reset()
        vcCFVArrayList.Clear()
        vcCFVDataTable.Reset()

        vcCNDIArrayList.Clear()
        vcCNDIDataTable.Reset()

        vcCCNCArrayList.Clear()
        vcCCNCDataTable.Reset()

        vcCLDDataTable = ClienteDomicilio.Tabla.Recuperar("ClienteClave=''")
        vcCLPDataTable = ClientePago.Tabla.Recuperar("ClienteClave=''")
        vcCLEDataTable = ClienteEsquema.Tabla.Recuperar("ClienteClave=''")
        vcCFVDataTable = CLIFormaVenta.Tabla.Recuperar("ClienteClave=''")

        vcCNDIDataTable = CLINoDesImp.Tabla.Recuperar("ClienteClave=''")

        vcCCNCDataTable = CLIConfNumCta.Tabla.Recuperar("ClienteClave=''")

        vcEstado = eEstado.Vacio
    End Sub

    Public Sub Recuperar(ByVal pvClienteClave As String)
        Dim vlCLIDataTable As New DataTable
        Dim vlCLIDataRow As DataRow

        Dim vlClienteDomicilio As New cClienteDomicilio(Me)
        Dim vlCienteDomicilioDT As New cCLDDataTable(vlClienteDomicilio)

        Dim vlClientePago As New cClientePago(Me)
        Dim vlCientePagoDT As New cCLPDataTable(vlClientePago)

        Dim vlClienteEsquema As New cClienteEsquema(Me)
        Dim vlCienteEsquemaDT As New cCLEDataTable(vlClienteEsquema)

        Dim vlCLIFormaVenta As New cCLIFormaVenta(Me)
        Dim vlCLIFormaVentaDT As New cCFVDataTable(vlCLIFormaVenta)

        Dim vlCLINoDesImp As New cCLINoDesImp(Me)
        Dim vlCLINoDesImpDT As New cCNDIDataTable(vlCLINoDesImp)

        Dim vlCLIConfNumCta As New cCLIConfNumCta(Me)
        Dim vlCLIConfNumCtaDT As New cCCNCDataTable(vlCLIConfNumCta)

        Call Limpiar()
        Try
            vlCLIDataTable = vcCliente.Seleccionar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(pvClienteClave) + "'")
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        If vlCLIDataTable.Rows.Count <= 0 Then
            Throw New LbControlError.cError("E0027")
        End If
        vlCLIDataRow = vlCLIDataTable.Rows(0)
        For Each vlCampo As LbDatos.cCampo In vcCliente.Campos
            vlCampo.Valor = vlCLIDataRow(vlCampo.Nombre)
        Next

        vcCLDArrayList.Clear()
        vcCLDDataTable.Clear()
        vcCLDDataTable = vlCienteDomicilioDT.Recuperar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(pvClienteClave) + "'")
        For Each vlCLDDataRow As DataRow In vcCLDDataTable.Rows
            Dim vlClienteDomicilio1 As New cClienteDomicilio(Me)
            vlClienteDomicilio1.Recuperar(vlCLDDataRow("ClienteDomicilioId"))
            vcCLDArrayList.Add(vlClienteDomicilio1)
        Next

        vcCLPArrayList.Clear()
        vcCLPDataTable.Clear()
        vcCLPDataTable = vlCientePagoDT.Recuperar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(pvClienteClave) + "'")
        For Each vlCLPDataRow As DataRow In vcCLPDataTable.Rows
            Dim vlClientePago1 As New cClientePago(Me)
            vlClientePago1.Recuperar(vlCLPDataRow("ClientePagoId"))
            vcCLPArrayList.Add(vlClientePago1)
        Next

        vcCLEArrayList.Clear()
        vcCLEDataTable.Clear()
        vcCLEDataTable = vlCienteEsquemaDT.Recuperar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(pvClienteClave) + "'")
        For Each vlCLEDataRow As DataRow In vcCLEDataTable.Rows
            Dim vlClienteEsquema1 As New cClienteEsquema(Me)
            vlClienteEsquema1.Recuperar(vlCLEDataRow("EsquemaId"))
            vcCLEArrayList.Add(vlClienteEsquema1)
        Next

        vcCFVArrayList.Clear()
        vcCFVDataTable.Clear()
        vcCFVDataTable = vlCLIFormaVentaDT.Recuperar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(pvClienteClave) + "'")
        For Each vlCFVDataRow As DataRow In vcCFVDataTable.Rows
            Dim vlCLIFormaVenta1 As New cCLIFormaVenta(Me)
            vlCLIFormaVenta1.Recuperar(vlCFVDataRow("CFVTipo"))
            vcCFVArrayList.Add(vlCLIFormaVenta1)
        Next

        vcCNDIArrayList.Clear()
        vcCNDIDataTable.Clear()
        vcCNDIDataTable = vlCLINoDesImpDT.Recuperar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(pvClienteClave) + "' and '" + LbConexion.cConexion.Instancia.ObtenerFecha().ToString("s") + "' between FechaInicio and FechaFin")
        For Each vlCNDIDataRow As DataRow In vcCNDIDataTable.Rows
            Dim vlCLINoDesImp1 As New cCLINoDesImp(Me)
            vlCLINoDesImp1.Recuperar(vlCNDIDataRow("CNDIID"))
            vcCNDIArrayList.Add(vlCLINoDesImp1)
        Next

        vcCCNCArrayList.Clear()
        vcCCNCDataTable.Clear()
        vcCCNCDataTable = vlCLIConfNumCtaDT.Recuperar(lbGeneral.ValidaFormatoSQLString(pvClienteClave))
        For Each vlCCNCDataRow As DataRow In vcCCNCDataTable.Rows
            Dim vlCLIConfNumCta1 As New cCLIConfNumCta(Me)
            If vlCCNCDataRow("Recuperado") Then
                vlCLIConfNumCta1.Recuperar(vlCCNCDataRow("Campo"))
                vcCCNCArrayList.Add(vlCLIConfNumCta1)
            End If
        Next

        vcEstado = eEstado.Recuperado
    End Sub


    Public Function Existe(ByVal pvClienteClave As String, ByVal pvClave As String) As Boolean
        Dim vlDtClave As DataTable
        vlDtClave = vcCliente.Seleccionar("Clave='" & lbGeneral.ValidaFormatoSQLString(pvClave) & "' and ClienteClave<>'" & lbGeneral.ValidaFormatoSQLString(pvClienteClave) & "'")
        If vlDtClave.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Function ExisteClave(ByVal pvClave As String) As Boolean
        Dim vlDtClave As DataTable
        vlDtClave = vcCliente.Seleccionar("Clave='" & lbGeneral.ValidaFormatoSQLString(pvClave) & "' ")
        If vlDtClave.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Function ExisteClienteClave(ByVal pvClienteClave As String) As Boolean
        Dim vlDtClave As DataTable
        vlDtClave = vcCliente.Seleccionar(" ClienteClave='" & lbGeneral.ValidaFormatoSQLString(pvClienteClave) & "' ")
        If vlDtClave.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Function ObtenerClienteClave(ByVal pvClave As String) As String
        Dim vlDtClave As DataTable
        vlDtClave = vcCliente.Seleccionar("Clave='" & lbGeneral.ValidaFormatoSQLString(pvClave) & "' ")
        If vlDtClave.Rows.Count > 0 Then
            Return vlDtClave.Rows(0).Item("ClienteClave").ToString()
        End If

        Return ""
    End Function

    Public Sub Grabar()
        Try
            Select Case vcEstado
                Case eEstado.Nuevo
                    vcCliente.Insertar()
                    For Each vlClienteDomicilio As cClienteDomicilio In vcCLDArrayList
                        vlClienteDomicilio.Grabar()
                    Next
                    For Each vlClientePago As cClientePago In vcCLPArrayList
                        vlClientePago.Grabar()
                    Next
                    For Each vlClienteEsquema As cClienteEsquema In vcCLEArrayList
                        vlClienteEsquema.Grabar()
                    Next

                    For Each vlCLIFormaVenta As cCLIFormaVenta In vcCFVArrayList
                        vlCLIFormaVenta.Grabar()
                    Next

                    For Each vlCLINoDesImp As cCLINoDesImp In vcCNDIArrayList
                        vlCLINoDesImp.Grabar()
                    Next

                    For Each vlCLIConfNumCta As cCLIConfNumCta In vcCCNCArrayList
                        vlCLIConfNumCta.Grabar()
                    Next

                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado
                    vcCliente.Modificar()

                    If Not bEnBloqueo Then
                        If Existe(Me.ClienteClave, Me.Clave) Then
                            Throw New LbControlError.cError("BE0002", , "Clave")
                        End If
                    End If

                    For i As Integer = 0 To vcCLDArrayList.Count - 1
                        If vcCLDArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcCLDArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next
                    For i As Integer = 0 To vcCLPArrayList.Count - 1
                        If vcCLPArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcCLPArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next
                    For i As Integer = 0 To vcCLEArrayList.Count - 1
                        If vcCLEArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcCLEArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next
                    For i As Integer = 0 To vcCFVArrayList.Count - 1
                        If vcCFVArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcCFVArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next

                    For i As Integer = 0 To vcCNDIArrayList.Count - 1
                        If vcCNDIArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcCNDIArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next

                    For i As Integer = 0 To vcCCNCArrayList.Count - 1
                        If vcCCNCArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcCCNCArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next
                    vcEstado = eEstado.Recuperado
                Case eEstado.Recuperado
                    For i As Integer = 0 To vcCLDArrayList.Count - 1
                        If vcCLDArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcCLDArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next
                    For i As Integer = 0 To vcCLPArrayList.Count - 1
                        If vcCLPArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcCLPArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next
                    For i As Integer = 0 To vcCLEArrayList.Count - 1
                        If vcCLEArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcCLEArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next
                    For i As Integer = 0 To vcCFVArrayList.Count - 1
                        If vcCFVArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcCFVArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next
                    For i As Integer = 0 To vcCNDIArrayList.Count - 1
                        If vcCNDIArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcCNDIArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next

                    For i As Integer = 0 To vcCCNCArrayList.Count - 1
                        If vcCCNCArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcCCNCArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next
                Case eEstado.Eliminado
                    For i As Integer = 0 To vcCLDArrayList.Count - 1
                        If vcCLDArrayList(i).cEstado = eEstado.Modificado Or vcCLDArrayList(i).cEstado = eEstado.Recuperado Or vcCLDArrayList(i).cEstado = eEstado.Eliminado Then
                            vcCLDArrayList(i).Eliminar()
                            If vcCLDArrayList(i).Grabar() = eEstado.Eliminado Then
                                If i >= vcCLDArrayList.Count Then
                                    Exit For
                                End If
                                i = i - 1
                            End If
                        End If
                    Next
                    For i As Integer = 0 To vcCLPArrayList.Count - 1
                        If vcCLPArrayList(i).cEstado = eEstado.Modificado Or vcCLPArrayList(i).cEstado = eEstado.Recuperado Or vcCLPArrayList(i).cEstado = eEstado.Eliminado Then
                            vcCLPArrayList(i).Eliminar()
                            If vcCLPArrayList(i).Grabar() = eEstado.Eliminado Then
                                If i >= vcCLPArrayList.Count Then
                                    Exit For
                                End If
                                i = i - 1
                            End If
                        End If
                    Next
                    For i As Integer = 0 To vcCLEArrayList.Count - 1
                        If vcCLEArrayList(i).cEstado = eEstado.Modificado Or vcCLEArrayList(i).cEstado = eEstado.Recuperado Or vcCLEArrayList(i).cEstado = eEstado.Eliminado Then
                            vcCLEArrayList(i).Eliminar()
                            If vcCLEArrayList(i).Grabar() = eEstado.Eliminado Then
                                If i >= vcCLEArrayList.Count Then
                                    Exit For
                                End If
                                i = i - 1
                            End If
                        End If
                    Next
                    For i As Integer = 0 To vcCFVArrayList.Count - 1
                        If vcCFVArrayList(i).cEstado = eEstado.Modificado Or vcCFVArrayList(i).cEstado = eEstado.Recuperado Or vcCFVArrayList(i).cEstado = eEstado.Eliminado Then
                            vcCFVArrayList(i).Eliminar()
                            If vcCFVArrayList(i).Grabar() = eEstado.Eliminado Then
                                If i >= vcCFVArrayList.Count Then
                                    Exit For
                                End If
                                i = i - 1
                            End If
                        End If
                    Next
                    For i As Integer = 0 To vcCNDIArrayList.Count - 1
                        If vcCNDIArrayList(i).cEstado = eEstado.Modificado Or vcCNDIArrayList(i).cEstado = eEstado.Recuperado Or vcCNDIArrayList(i).cEstado = eEstado.Eliminado Then
                            vcCNDIArrayList(i).Eliminar()
                            If vcCNDIArrayList(i).Grabar() = eEstado.Eliminado Then
                                If i >= vcCNDIArrayList.Count Then
                                    Exit For
                                End If
                                i = i - 1
                            End If
                        End If
                    Next
                    For i As Integer = 0 To vcCCNCArrayList.Count - 1
                        If vcCCNCArrayList(i).cEstado = eEstado.Modificado Or vcCCNCArrayList(i).cEstado = eEstado.Recuperado Or vcCCNCArrayList(i).cEstado = eEstado.Eliminado Then
                            vcCCNCArrayList(i).Eliminar()
                            If vcCCNCArrayList(i).Grabar() = eEstado.Eliminado Then
                                If i >= vcCCNCArrayList.Count Then
                                    Exit For
                                End If
                                i = i - 1
                            End If
                        End If
                    Next
                    vcCliente.Eliminar()
                    Call Limpiar()
            End Select
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    Public Sub Eliminar()
        vcEstado = eEstado.Eliminado
    End Sub

    Public Sub ValidarCampos(Optional ByVal pvCampo() As String = Nothing)
        If IsNothing(pvCampo) Then
            Dim i As Integer
            With vcCliente
                For i = 0 To .Campos.Count - 1
                    Try
                        Call ValidaCampo(.Campos(i).Nombre)
                    Catch ex As LbControlError.cError
                        Throw ex
                    End Try
                Next
            End With
        Else
            For Each vlCampo As String In pvCampo
                Try
                    Call ValidaCampo(vlCampo, True)
                Catch ex As LbControlError.cError
                    Throw ex
                End Try
            Next
        End If
    End Sub

    Private Sub ValidaCampo(ByVal pvNombre As String, Optional ByVal pvTodos As Boolean = False)
        Try
            With vcCliente
                If .Campos(pvNombre).Requerido Then
                    If IsDBNull(.Campos(pvNombre).Valor) Or .Campos(pvNombre).Valor Is Nothing Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CLI" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                    End If
                    If .Campos(pvNombre).Tipo = LbDatos.ETipo.Cadena Then
                        If .Campos(pvNombre).Valor = "" Then
                            Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CLI" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                        End If
                    End If
                End If
                Select Case .Campos(pvNombre).Tipo
                    Case LbDatos.ETipo.Numerico
                        If IsDBNull(.Campos(pvNombre).Valor) = False Then
                            If pvNombre <> "SaldoEfectivo" And .Campos(pvNombre).Valor < 0 Then
                                Throw New LbControlError.cError("E0007", , .Campos(pvNombre).Nombre)
                            End If
                            If pvNombre = "LimiteDescuento" And .Campos(pvNombre).Valor > 100 Then
                                Throw New LbControlError.cError("E0049", , .Campos(pvNombre).Nombre)
                            End If
                        End If
                End Select
                If pvNombre = "FechaNacimiento" Or pvNombre = "FechaRegistroSistema" Then
                    If .Campos(pvNombre).Valor > vcConexion.ObtenerFecha.Date Then
                        Throw New LbControlError.cError("E0087", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CLI" & pvNombre, True)}, .Campos(pvNombre).Nombre)
                    End If
                End If
                If pvNombre = "IdElectronico" And Not IsDBNull(.Campos(pvNombre).Valor) Then
                    If .Campos(pvNombre).Valor <> "" Then
                        Dim aObj As Object = LbConexion.cConexion.Instancia().EjecutarComandoScalar("SELECT clave FROM Cliente WHERE IdElectronico = '" & lbGeneral.ValidaFormatoSQLString(.Campos(pvNombre).Valor) & "' and ClienteClave <> '" & lbGeneral.ValidaFormatoSQLString(Me.ClienteClave) & "' AND Tipoestado > 0")
                        If (Not IsDBNull(aObj)) And (Not IsNothing(aObj)) Then
                            Throw New LbControlError.cError("E0555", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(aObj)})
                        End If
                    End If
                End If
                If pvNombre = "Clave" Then
                    If .Campos(pvNombre).Valor.ToString.ToUpper.StartsWith("NUEVO") Then
                        Throw New LbControlError.cError("E0736", , .Campos(pvNombre).Nombre)
                    End If
                End If
            End With
            'Catch ex As Exception
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    Public Sub InsertarEn(ByRef prDataTable As DataTable)
        vcCliente.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcCliente.Modificar(prDataTable)
    End Sub

    Function ClienteDomicilio() As cCLDTabla
        Return vcCLDTabla
    End Function

    Function ClienteDomicilio(ByVal pvIndex As Integer) As cClienteDomicilio
        Dim vlClienteDomicilio As cClienteDomicilio
        While 1
            vlClienteDomicilio = vcCLDArrayList(pvIndex)
            If vlClienteDomicilio.cEstado <> eEstado.Eliminado Then
                Return vcCLDArrayList(pvIndex)
            Else
                pvIndex = pvIndex + 1
            End If
        End While
        Return Nothing
    End Function

    '--Verificar que solo exista un solo Domicilio Fiscal
    '--Tipo 1 
    Function VerificarDomicilioFiscalUnico() As Boolean

        For Each vlClienteDomicilio As cClienteDomicilio In vcCLDArrayList
            If vlClienteDomicilio.Tipo = 1 Then
                Return False
            End If
        Next

        Return True

    End Function

    Public Function ValidarSaldos() As Boolean
        If Me.SaldoEfectivo <> 0 Then
            Return False
        End If
        Dim sConsulta As String = "select COUNT(*) as ConSaldo from ProductoPrestamoCli  where ClienteClave = '" & Me.ClienteClave & "' and Saldo <> 0 "
        If Me.cTabla.Conexion.EjecutarComandoScalar(sConsulta) > 0 Then
            Return False
        End If
        sConsulta = "select COUNT(*) as Asignados from ActivoClienteHist ACH "
        sConsulta &= "inner join (select ActivoClave, max(fecha) as Fecha from ActivoClienteHist where ClienteClave = '" & Me.ClienteClave & "' group by ActivoClave "
        sConsulta &= ") ACH1 on ACH.ActivoClave = ACH1.ActivoClave and ACH.Fecha = ACH1.Fecha "
        sConsulta &= "where ACH.ClienteClave = '" & Me.ClienteClave & "' and ACH.TipoEstado = 1"
        If Me.cTabla.Conexion.EjecutarComandoScalar(sConsulta) > 0 Then
            Return False
        End If
        Return True
    End Function

    Public Sub EliminarSecuencias(ByVal pvUsuarioId As String)
        Dim dtSec As Data.DataTable = Me.cTabla.Conexion.EjecutarConsulta("select SECId, RUTClave, FrecuenciaClave, Orden from Secuencia where ClienteClave = '" & Me.ClienteClave & "' and not RUTClave is null order by RUTClave, FrecuenciaClave, Orden ")
        For Each drSec As Data.DataRow In dtSec.Rows
            Dim oSec As New ERMSECLOG.cSecuencia
            oSec.ReordenarSecuencia(drSec("FrecuenciaClave"), drSec("Orden"), drSec("RUTClave"))
            oSec.Limpiar()
            oSec.SECId = drSec("SECId")
            oSec.Recuperar(drSec("SECId"))
            oSec.RUTClave = ""
            oSec.Orden = 0
            oSec.MUsuarioId = pvUsuarioId
            oSec.Grabar()
        Next
    End Sub

    Function ClienteDomicilio(ByVal pvClienteDomicilioId As String) As cClienteDomicilio
        For Each vlClienteDomicilio As cClienteDomicilio In vcCLDArrayList
            If vlClienteDomicilio.ClienteDomicilioId = pvClienteDomicilioId Then
                Return vlClienteDomicilio
            End If
        Next
        Return Nothing
    End Function

    Function ClientePago() As cCLPTabla
        Return vcCLPTabla
    End Function

    Function ClientePago(ByVal pvIndex As Integer) As cClientePago
        Return vcCLPArrayList(pvIndex)
    End Function

    Function ClientePago(ByVal pvClientePagoId As String) As cClientePago
        For Each vlClientePago As cClientePago In vcCLPArrayList
            If vlClientePago.ClientePagoId = pvClientePagoId Then
                Return vlClientePago
            End If
        Next
        Return Nothing
    End Function

    Function ClienteEsquema() As cCLETabla
        Return vcCLETabla
    End Function

    Function ClienteEsquema(ByVal pvIndex As Integer) As cClienteEsquema
        Return vcCLEArrayList(pvIndex)
    End Function

    Function ClienteEsquema(ByVal pvEsquemaId As String) As cClienteEsquema
        For Each vlClienteEsquema As cClienteEsquema In vcCLEArrayList
            If vlClienteEsquema.EsquemaId = pvEsquemaId Then
                Return vlClienteEsquema
            End If
        Next
        Return Nothing
    End Function

    Function CLIFormaVenta() As cCFVTabla
        Return vcCFVTabla
    End Function

    Function CLINoDesImp() As cCNDITabla
        Return vcCNDITabla
    End Function

    Function CLIConfNumCta() As cCCNCTabla
        Return vcCCNCTabla
    End Function

    Function CLIFormaVenta(ByVal pvCFVTipo As Integer) As cCLIFormaVenta
        For Each vlCLIFormaVenta As cCLIFormaVenta In vcCFVArrayList
            If vlCLIFormaVenta.CFVTipo = pvCFVTipo Then
                Return vlCLIFormaVenta
            End If
        Next
        Return Nothing
    End Function

    Function CLINoDesImp(ByVal pvImpuestoClave As String) As cCLINoDesImp
        For Each vlCLINoDesImp As cCLINoDesImp In vcCNDIArrayList
            If vlCLINoDesImp.ImpuestoClave = pvImpuestoClave Then
                Return vlCLINoDesImp
            End If
        Next
        Return Nothing
    End Function

    Function CLIConfNumCta(ByVal pvCampoC As String) As cCLIConfNumCta
        For Each vlCLIConfNumCta As cCLIConfNumCta In vcCCNCArrayList
            If vlCLIConfNumCta.Campo = pvCampoC Then
                Return vlCLIConfNumCta
            End If
        Next
        Return Nothing
    End Function
    Public Sub ObtenerEsquemasCliente()
        Dim dvEsquemas As DataView
        Dim dtEsquemasCliente As DataTable

        RecuperarEsquemas(dvEsquemas, dtEsquemasCliente, Me.ClienteClave)

        sEsquemasCliente = ""
        For Each dr As DataRow In dtEsquemasCliente.Rows
            sEsquemasCliente &= "'" & dr("EsquemaID") & "',"
            RecuperarEsquemasCliente(dvEsquemas, sEsquemasCliente, dr("EsquemaID"))
        Next
        If sEsquemasCliente.Length > 0 Then
            sEsquemasCliente = Left(sEsquemasCliente, sEsquemasCliente.Length - 1)
        End If
    End Sub

    Private Function RecuperarEsquemas(ByRef refparoDataViewEsquemas As DataView, ByRef refparoDataTableEsquemasClientes As DataTable, ByVal pvClienteClave As String) As Boolean
        Try
            Dim sConsultaSQL As String = "SELECT ESQ.EsquemaID "
            sConsultaSQL &= "FROM ClienteEsquema CLE "
            sConsultaSQL &= "INNER JOIN Esquema ESQ ON CLE.EsquemaID = ESQ.EsquemaID "
            sConsultaSQL &= "WHERE ESQ.TipoEstado = 1 AND ESQ.Baja = 0 AND CLE.TipoEstado = 1 AND CLE.ClienteClave = '" & pvClienteClave & "'"

            ' Crear los DataTables y DataViews para buscar los esquemas
            refparoDataTableEsquemasClientes = LbConexion.cConexion.Instancia().EjecutarConsulta(sConsultaSQL)
            If refparoDataTableEsquemasClientes.Rows.Count = 0 Then
                ' El cliente no pertenece al menos a un esquema de clientes
                Return False
            End If
            ' DataTable de Esquemas (para buscar ascendentemente)
            Dim dtEsquemas As DataTable
            sConsultaSQL = "SELECT EsquemaID,EsquemaIDPadre FROM Esquema WHERE Tipo= 1 AND TipoEstado = 1 AND Baja = 0 "
            dtEsquemas = LbConexion.cConexion.Instancia().EjecutarConsulta(sConsultaSQL)
            If dtEsquemas.Rows.Count = 0 Then
                ' No hay esquemas de clientes definidos
                dtEsquemas.Dispose()
                Return False
            End If
            ' Crear el DataView de busqueda de esquemas
            refparoDataViewEsquemas = New DataView(dtEsquemas, "", "EsquemaID", DataViewRowState.CurrentRows)
            dtEsquemas.Dispose()
            Return True
        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function

    Private Sub RecuperarEsquemasCliente(ByRef refDataViewEsquemas As DataView, ByRef refparsEsquemasCliente As String, ByVal parsNodo As String)
        Try
            If parsNodo = String.Empty Then Exit Sub
            Dim sNodo As String = String.Empty
            Dim iPos As Integer = refDataViewEsquemas.Find(parsNodo)
            If iPos > -1 Then
                If Not IsDBNull(refDataViewEsquemas(iPos)("EsquemaIDPadre")) Then
                    refparsEsquemasCliente &= "'" & refDataViewEsquemas(iPos)("EsquemaIDPadre") & "',"
                    RecuperarEsquemasCliente(refDataViewEsquemas, refparsEsquemasCliente, refDataViewEsquemas(iPos)("EsquemaIDPadre"))
                Else
                    Exit Sub
                End If
            End If
        Catch ExcA As Exception
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarNodosArbol")
        End Try
    End Sub
#End Region
End Class


Public Class cCLITabla
    Private vcCliente As cCliente
    Dim vlDataTable As DataTable

    Public Function recuperarCliente(ByVal pvClienteClave As String) As cCliente
        Dim clientetemp As New cCliente
        Dim y As Integer = 0
        Dim dr() As DataRow = vlDataTable.Select("ClienteClave='" & lbGeneral.ValidaFormatoSQLString(pvClienteClave) & "'")

        'For y = 0 To vlDataTable.Rows.Count - 1

        'If pvClienteClave = dr(0)("ClienteClave") Then
        If dr.Length > 0 Then
            clientetemp.ClienteClave = dr(0)("ClienteClave")
            clientetemp.Clave = IIf(IsDBNull(dr(0).Item("Clave")), "", dr(0).Item("Clave"))

            'clientetemp.CNPId = IIf(IsDBNull(dr(0).Item("CNPId")), "", dr(0).Item("CNPId"))
            'clientetemp.IdElectronico = IIf(IsDBNull(dr(0).Item("IdElectronico")), "", dr(0).Item("IdElectronico"))
            clientetemp.IdFiscal = IIf(IsDBNull(dr(0).Item("IdFiscal")), "", dr(0).Item("IdFiscal"))
            clientetemp.RazonSocial = IIf(IsDBNull(dr(0).Item("RazonSocial")), "", dr(0).Item("RazonSocial"))
            'clientetemp.TipoFiscal = IIf(IsDBNull(dr(0).Item("TipoFiscal")), "", dr(0).Item("TipoFiscal"))
            clientetemp.TipoImpuesto = IIf(IsDBNull(dr(0).Item("TipoImpuesto")), "", dr(0).Item("TipoImpuesto"))
            'clientetemp.TipoFiscal = IIf(IsDBNull(dr(0).Item("TipoFiscal")), "", dr(0).Item("TipoFiscal"))
            clientetemp.NombreContacto = IIf(IsDBNull(dr(0).Item("NombreContacto")), "", dr(0).Item("NombreContacto"))
            clientetemp.TelefonoContacto = IIf(IsDBNull(dr(0).Item("TelefonoContacto")), "", dr(0).Item("TelefonoContacto"))
            'clientetemp.FechaRegistroSistema = IIf(IsDBNull(dr(0).Item("FechaRegistroSistema")), "", dr(0).Item("FechaRegistroSistema"))
            'clientetemp.FechaNacimiento = IIf(IsDBNull(dr(0).Item("FechaNacimiento")), Nothing, dr(0).Item("FechaNacimiento"))
            clientetemp.LimiteCreditoDinero = IIf(IsDBNull(dr(0).Item("LimiteCreditoDinero")), 0, dr(0).Item("LimiteCreditoDinero"))
            clientetemp.NombreCorto = IIf(IsDBNull(dr(0).Item("NombreCorto")), "", dr(0).Item("NombreCorto"))
            clientetemp.TelefonoContacto = IIf(IsDBNull(dr(0).Item("TelefonoContacto")), "", dr(0).Item("TelefonoContacto"))
            'clientetemp.TipoEstado = IIf(IsDBNull(dr(0).Item("TipoEstado")), "", dr(0).Item("TipoEstado"))
            clientetemp.LimiteDescuento = IIf(IsDBNull(dr(0).Item("LimiteDescuento")), 0, dr(0).Item("LimiteDescuento"))
            clientetemp.SaldoEfectivo = IIf(IsDBNull(dr(0).Item("SaldoEfectivo")), 0, dr(0).Item("SaldoEfectivo"))
            'clientetemp.Prestamo = IIf(IsDBNull(dr(0).Item("Prestamo")), "", dr(0).Item("Prestamo"))
            'clientetemp.SaldoPrestamo = IIf(IsDBNull(dr(0).Item("SaldoPrestamo")), 0, dr(0).Item("SaldoPrestamo"))
            clientetemp.Exclusividad = IIf(IsDBNull(dr(0).Item("Exclusividad")), "", dr(0).Item("Exclusividad"))
            clientetemp.VigExclusividad = IIf(IsDBNull(dr(0).Item("VigExclusividad")), Nothing, dr(0).Item("VigExclusividad"))
            clientetemp.VencimientoVenta = IIf(IsDBNull(dr(0).Item("VencimientoVenta")), "", dr(0).Item("VencimientoVenta"))
            clientetemp.DiasVencimiento = IIf(IsDBNull(dr(0).Item("DiasVencimiento")), 0, dr(0).Item("DiasVencimiento"))
            clientetemp.SaldoGarantia = IIf(IsDBNull(dr(0).Item("SaldoGarantia")), Nothing, dr(0).Item("SaldoGarantia"))
            'clientetemp.MFechaHora = IIf(IsDBNull(dr(0).Item("MFechaHora")
            clientetemp.DesgloseImpuesto = IIf(IsDBNull(dr(0).Item("DesgloseImpuesto")), "", dr(0).Item("DesgloseImpuesto"))
            clientetemp.CorreoElectronico = IIf(IsDBNull(dr(0).Item("CorreoElectronico")), "", dr(0).Item("CorreoElectronico"))
            'clientetemp.MUsuarioId = IIf(IsDBNull(dr(0).Item("MUsuarioId")), "", dr(0).Item("MUsuarioId"))
        End If

        'End If
        'Next y

        Return clientetemp

    End Function

    Public Sub New(ByRef prCliente As cCliente)
        vcCliente = prCliente
    End Sub

    Public Function Recuperar(ByVal pvFiltro As String) As DataTable
        vlDataTable = vcCliente.cTabla.Seleccionar(pvFiltro)
        Recuperar = vlDataTable
    End Function
    Public Function Recuperar(ByVal pvFiltro As String, ByVal pvCampos As String) As DataTable
        vlDataTable = vcCliente.cTabla.Seleccionar(pvFiltro, pvCampos)
        Recuperar = vlDataTable
    End Function


    Public Function RecuperarVistaDatosCliente(ByVal pvTipoDomicilo As Integer, Optional ByVal pvFiltro As String = "") As DataTable
        Dim vlDataTable As DataTable
        Dim lsConsulta As String

        lsConsulta = "select ClienteDomicilioID, Cliente.ClienteClave, Cliente.Clave, RazonSocial,NombreCorto, " _
                    & " Calle,Numero,Colonia,CodigoPostal,Poblacion, Entidad, Pais " _
                    & " from ClienteDomicilio inner join cliente on ClienteDomicilio.ClienteClave = Cliente.ClienteClave " _
                    & " where ClienteDomicilio.Tipo = " & pvTipoDomicilo
        If pvFiltro <> "" Then
            lsConsulta &= " AND " & pvFiltro
        End If

        vlDataTable = vcCliente.cTabla.Conexion.EjecutarConsulta(lsConsulta)
        Return vlDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcCliente.cTabla.GrabarTabla(prDataTable, vcCliente.cTabla.Campos)
    End Sub
End Class


Public Class cCLIDataSet
    Private vcCliente As cCliente

    Public Sub New(ByRef prCliente As cCliente)
        vcCliente = prCliente
    End Sub

    Public Function Recuperar(ByVal pvFiltro As String) As DataSet
        Dim vlDataSet As New DataSet
        Dim vlCLIDataTable As New DataTable
        Dim vlCLDDataTable As New DataTable
        Dim vlCLPDataTable As New DataTable
        Dim vlCFVDataTable As New DataTable
        Dim vlFiltro As String = String.Empty
        Dim vlClienteDomicilio As New cClienteDomicilio(vcCliente)
        Dim vlClienteDomicilioDT As New cCLDDataTable(vlClienteDomicilio)
        Dim vlClientePago As New cClientePago(vcCliente)
        Dim vlClientePagoDT As New cCLPDataTable(vlClientePago)
        Dim vlCLIFormaVenta As New cCLIFormaVenta(vcCliente)
        Dim vlCLIFormaVentaDT As New cCFVDataTable(vlCLIFormaVenta)

        vlCLIDataTable = vcCliente.Tabla.Recuperar(pvFiltro)
        vlDataSet.Tables.Add(vlCLIDataTable)
        If vlCLIDataTable.Rows.Count <= 0 Then
            Return vlDataSet
        End If

        If Not IsNothing(pvFiltro) And pvFiltro <> "" Then
            vlFiltro = "ClienteClave in ("
            For Each vlDataRow As DataRow In vlCLIDataTable.Rows
                vlFiltro = vlFiltro + "'" + lbGeneral.ValidaFormatoSQLString(vlDataRow("ClienteClave")) + "',"
            Next
            vlFiltro = vlFiltro.Substring(0, vlFiltro.Length - 1) + ")"
        End If

        vlCLDDataTable = vlClienteDomicilioDT.Recuperar(vlFiltro)
        vlDataSet.Tables.Add(vlCLDDataTable)

        vlCLPDataTable = vlClientePagoDT.Recuperar(vlFiltro)
        vlDataSet.Tables.Add(vlCLPDataTable)

        vlCFVDataTable = vlCLIFormaVentaDT.Recuperar(vlFiltro)
        vlDataSet.Tables.Add(vlCFVDataTable)

        vlDataSet.Relations.Add("ClienteClienteDomicilio", vlDataSet.Tables("Cliente").Columns("ClienteClave"), vlDataSet.Tables("ClienteDomicilio").Columns("ClienteClave"))
        vlDataSet.Relations.Add("ClienteClientePago", vlDataSet.Tables("Cliente").Columns("ClienteClave"), vlDataSet.Tables("ClientePago").Columns("ClienteClave"))
        vlDataSet.Relations.Add("ClienteCLIFormaVenta", vlDataSet.Tables("Cliente").Columns("ClienteClave"), vlDataSet.Tables("CLIFormaVenta").Columns("ClienteClave"))
        Return vlDataSet
    End Function

    Public Sub Grabar(ByRef prDataSet As DataSet)

    End Sub
End Class
