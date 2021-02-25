Imports System.Security.Cryptography
Imports System.Text.RegularExpressions

Public Class cConfiguracion
    Dim vcConfig As LbDatos.cTabla
    Dim vcHistorial As LbDatos.cTabla
    Dim vcGuardarHist As Boolean = False
    Dim vcMoneda As ERMMONLOG.cMoneda
    Dim vcLogo As LbDatos.cCampo

    Public Sub New()
        vcConfig = New LbDatos.cTabla("Configuracion")
        vcHistorial = New LbDatos.cTabla("CONHist")
        vcConfig.Campos.Add(New LbDatos.cCampo("ConfiguracionID", LbDatos.ETipo.Cadena, True, True))
        vcConfig.Campos.Add(New LbDatos.cCampo("NombreEmpresa", LbDatos.ETipo.Cadena, True))
        vcConfig.Campos.Add(New LbDatos.cCampo("RFC", LbDatos.ETipo.Cadena, True))
        vcConfig.Campos.Add(New LbDatos.cCampo("Telefono", LbDatos.ETipo.Cadena, False))
        vcConfig.Campos.Add(New LbDatos.cCampo("Pais", LbDatos.ETipo.Cadena, True))
        vcConfig.Campos.Add(New LbDatos.cCampo("Region", LbDatos.ETipo.Cadena, True))
        vcConfig.Campos.Add(New LbDatos.cCampo("Localidad", LbDatos.ETipo.Cadena, False))
        vcConfig.Campos.Add(New LbDatos.cCampo("ReferenciaDom", LbDatos.ETipo.Cadena, False))
        vcConfig.Campos.Add(New LbDatos.cCampo("Ciudad", LbDatos.ETipo.Cadena, True))
        vcConfig.Campos.Add(New LbDatos.cCampo("Colonia", LbDatos.ETipo.Cadena, True))
        vcConfig.Campos.Add(New LbDatos.cCampo("Calle", LbDatos.ETipo.Cadena, True))
        vcConfig.Campos.Add(New LbDatos.cCampo("Numero", LbDatos.ETipo.Cadena, True))
        vcConfig.Campos.Add(New LbDatos.cCampo("NumeroInterior", LbDatos.ETipo.Cadena, False))
        vcConfig.Campos.Add(New LbDatos.cCampo("CodigoPostal", LbDatos.ETipo.Cadena, False))
        'vcConfig.Campos.Add(New LbDatos.cCampo("CodigoBarrasCEDI", LbDatos.ETipo.Cadena, True))
        vcLogo = New LbDatos.cCampo("Logotipo", LbDatos.ETipo.Binario, True)
        vcConfig.Campos.Add(vcLogo)
        vcConfig.Campos.Add(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, False))
        vcConfig.Campos.Add(New LbDatos.cCampo("MUsuarioID", LbDatos.ETipo.Cadena, True))

        vcHistorial.Campos.Add(New LbDatos.cCampo("ConfiguracionID", LbDatos.ETipo.Cadena, True, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("CONHistFechaInicio", LbDatos.ETipo.FechaHora, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("MonedaID", LbDatos.ETipo.Cadena, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("TipoLenguaje", LbDatos.ETipo.Cadena, True))
        'vcHistorial.Campos.Add(New LbDatos.cCampo("Promocion", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("TipoClaveProducto", LbDatos.ETipo.Numerico, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("DigitoClaveProd", LbDatos.ETipo.Numerico, False))
        vcHistorial.Campos.Add(New LbDatos.cCampo("AbonoProgramado", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("CantidadSerAct", LbDatos.ETipo.Numerico, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("FiltroProductos", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("DiasSurtido", LbDatos.ETipo.Numerico, True))

        vcHistorial.Campos.Add(New LbDatos.cCampo("DiasPosteriores", LbDatos.ETipo.Numerico, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("DiasAnteriores", LbDatos.ETipo.Numerico, True))

        vcHistorial.Campos.Add(New LbDatos.cCampo("DirectorioSDF", LbDatos.ETipo.Cadena, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("ClienteVariasRutas", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, False))
        vcHistorial.Campos.Add(New LbDatos.cCampo("MUsuarioID", LbDatos.ETipo.Cadena, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("DirInterfaz", LbDatos.ETipo.Cadena, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("InterfazTXT", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("DepGarantia", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("CuotasGarantia", LbDatos.ETipo.Numerico, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("CodigoBarrasCliente", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("ContrasenaCliente", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("CambioProducto", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("CobrarVentas", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("ConversionKg", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("IntUnidadVta", LbDatos.ETipo.Bit, True))

        'vcHistorial.Campos.Add(New LbDatos.cCampo("LimiteCredito", LbDatos.ETipo.Bit, True))
        'vcHistorial.Campos.Add(New LbDatos.cCampo("VencimientoPagos", LbDatos.ETipo.Bit, True))
        'vcHistorial.Campos.Add(New LbDatos.cCampo("PagoContado", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("EliminaEnviado", LbDatos.ETipo.Bit, True))
        'vcHistorial.Campos.Add(New LbDatos.cCampo("DiasVencimiento", LbDatos.ETipo.Numerico, False))
        'vcHistorial.Campos.Add(New LbDatos.cCampo("LimiteCreditoCheque", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("TicketConfigurado", LbDatos.ETipo.Numerico, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("PagoAutomatico", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("PreLiquidacion", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("DiferenciaPreliqui", LbDatos.ETipo.Numerico, False))

        vcHistorial.Campos.Add(New LbDatos.cCampo("Inventario", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("ModificarVenta", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("AuditarCarga", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("MostrarLogo", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("EnvioParcial", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("TipoLimiteCredito", LbDatos.ETipo.Numerico, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("PorcentajeRiesgo", LbDatos.ETipo.Numerico, False))
        vcHistorial.Campos.Add(New LbDatos.cCampo("PorcentajeInteres", LbDatos.ETipo.Numerico, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("DecimalesImporte", LbDatos.ETipo.Numerico, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("ValidaInv", LbDatos.ETipo.Bit, True))

        '        vcHistorial.Campos.Add(New LbDatos.cCampo("RFCGenerico", LbDatos.ETipo.Cadena, False))

        vcHistorial.Campos.Add(New LbDatos.cCampo("TipoIniciarVisita", LbDatos.ETipo.Numerico, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("LimiteGPS", LbDatos.ETipo.Numerico, False))
        vcHistorial.Campos.Add(New LbDatos.cCampo("ClientesVisitados", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("DatosCteNuevo", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("VenderApartado", LbDatos.ETipo.Bit, True))
        vcHistorial.Campos.Add(New LbDatos.cCampo("VentaSinSurtir", LbDatos.ETipo.Bit, True))

        vcHistorial.Campos("CONHistFechaInicio").Valor = vcHistorial.Conexion.ObtenerFecha


        vcHistorial.Campos.Add(New LbDatos.cCampo("Puerto", LbDatos.ETipo.Numerico, False))
        vcHistorial.Campos.Add(New LbDatos.cCampo("ServidorSMTP", LbDatos.ETipo.Cadena, False))
        vcHistorial.Campos.Add(New LbDatos.cCampo("Correo", LbDatos.ETipo.Cadena, False))
        vcHistorial.Campos.Add(New LbDatos.cCampo("Password", LbDatos.ETipo.Cadena, False))

        vcHistorial.Campos.Add(New LbDatos.cCampo("SSL", LbDatos.ETipo.Bit, True))

        vcMoneda = New ERMMONLOG.cMoneda
        vcGuardarHist = False
    End Sub

#Region "Propiedades"

    Public Property ConfiguracionID() As String
        Get
            Return vcConfig.Campos("ConfiguracionID").Valor
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("ConfiguracionID").Valor = Value
            vcHistorial.Campos("ConfiguracionID").Valor = Value
        End Set
    End Property

    Public Property NombreEmpresa() As String
        Get
            Return vcConfig.Campos("NombreEmpresa").Valor
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("NombreEmpresa").Valor = Value
        End Set
    End Property

    Public Property RFC() As String
        Get
            Return vcConfig.Campos("RFC").Valor
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("RFC").Valor = Value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return vcConfig.Campos("Telefono").Valor.ToString
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("Telefono").Valor = Value
        End Set
    End Property

    Public Property Pais() As String
        Get
            Return vcConfig.Campos("Pais").Valor
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("Pais").Valor = Value
        End Set
    End Property

    Public Property Region() As String
        Get
            Return vcConfig.Campos("Region").Valor
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("Region").Valor = Value
        End Set
    End Property

    Public Property Localidad() As String
        Get
            Return vcConfig.Campos("Localidad").Valor
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("Localidad").Valor = Value
        End Set
    End Property

    Public Property ReferenciaDom() As String
        Get
            Return vcConfig.Campos("ReferenciaDom").Valor
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("ReferenciaDom").Valor = Value
        End Set
    End Property

    'Public Property CodigoBarrasCEDI() As String
    '    Get
    '        Return vcConfig.Campos("CodigoBarrasCEDI").Valor
    '    End Get
    '    Set(ByVal Value As String)
    '        vcConfig.Campos("CodigoBarrasCEDI").Valor = Value
    '    End Set
    'End Property

    Public Property Ciudad() As String
        Get
            Return vcConfig.Campos("Ciudad").Valor
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("Ciudad").Valor = Value
        End Set
    End Property

    Public Property Colonia() As String
        Get
            Return vcConfig.Campos("Colonia").Valor
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("Colonia").Valor = Value
        End Set
    End Property

    Public Property Calle() As String
        Get
            Return vcConfig.Campos("Calle").Valor
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("Calle").Valor = Value
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return vcConfig.Campos("Numero").Valor
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("Numero").Valor = Value
        End Set
    End Property

    Public Property NumeroInterior() As String
        Get
            Return vcConfig.Campos("NumeroInterior").Valor
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("NumeroInterior").Valor = Value
        End Set
    End Property

    Public Property CodigoPostal() As String
        Get
            Return vcConfig.Campos("CodigoPostal").Valor
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("CodigoPostal").Valor = Value
        End Set
    End Property

    Public Property Logotipo() As Byte()
        Get
            Return vcConfig.Campos("Logotipo").Valor
        End Get
        Set(ByVal Value As Byte())
            vcConfig.Campos("Logotipo").Valor = Value
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcConfig.Campos("MUsuarioID").Valor
        End Get
        Set(ByVal Value As String)
            vcConfig.Campos("MUsuarioID").Valor = Value
            vcHistorial.Campos("MUsuarioID").Valor = Value
        End Set
    End Property

    Public ReadOnly Property FechaInicio() As Date
        Get
            Return vcHistorial.Campos("CONHistFechaInicio").Valor
        End Get
    End Property

    Public Property TipoLenguaje() As String
        Get
            Return vcHistorial.Campos("TipoLenguaje").Valor
        End Get
        Set(ByVal Value As String)
            If Me.TipoLenguaje <> Value Then vcGuardarHist = True
            vcHistorial.Campos("TipoLenguaje").Valor = Value
        End Set
    End Property

    'Public Property Promocion() As Boolean
    '    Get
    '        Return vcHistorial.Campos("Promocion").Valor
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        If Me.Promocion <> Value Then vcGuardarHist = True
    '        vcHistorial.Campos("Promocion").Valor = Value
    '    End Set
    'End Property

    Public Property TipoClaveProducto() As Integer
        Get
            Return vcHistorial.Campos("TipoClaveProducto").Valor
        End Get
        Set(ByVal Value As Integer)
            If Me.TipoClaveProducto <> Value Then vcGuardarHist = True
            vcHistorial.Campos("TipoClaveProducto").Valor = Value
        End Set
    End Property

    Public Property DigitoClaveProd() As Integer
        Get
            Return vcHistorial.Campos("DigitoClaveProd").Valor
        End Get
        Set(ByVal Value As Integer)
            If Me.DigitoClaveProd <> Value Then vcGuardarHist = True
            vcHistorial.Campos("DigitoClaveProd").Valor = Value
        End Set
    End Property

    Public Property AbonoProgramado() As Boolean
        Get
            Return vcHistorial.Campos("AbonoProgramado").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.AbonoProgramado <> Value Then vcGuardarHist = True
            vcHistorial.Campos("AbonoProgramado").Valor = Value
        End Set
    End Property

    Public Property MonedaID() As String
        Get
            Return vcHistorial.Campos("MonedaID").Valor
        End Get
        Set(ByVal Value As String)
            If Me.MonedaID <> Value Then vcGuardarHist = True
            vcHistorial.Campos("MonedaID").Valor = Value
            vcMoneda.MonedaID = Value
        End Set
    End Property

    Public Property CantidadSerAct() As Integer
        Get
            Return vcHistorial.Campos("CantidadSerAct").Valor
        End Get
        Set(ByVal Value As Integer)
            If Me.CantidadSerAct <> Value Then vcGuardarHist = True
            vcHistorial.Campos("CantidadSerAct").Valor = Value
        End Set
    End Property

    Public Property FiltroProductos() As Boolean
        Get
            Return vcHistorial.Campos("FiltroProductos").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.FiltroProductos <> Value Then vcGuardarHist = True
            vcHistorial.Campos("FiltroProductos").Valor = Value
        End Set
    End Property

    Public Property DiasSurtido() As Integer
        Get
            Return vcHistorial.Campos("DiasSurtido").Valor
        End Get
        Set(ByVal Value As Integer)
            If Me.DiasSurtido <> Value Then vcGuardarHist = True
            vcHistorial.Campos("DiasSurtido").Valor = Value
        End Set
    End Property

    Public Property DiasAnteriores() As Integer
        Get
            Return vcHistorial.Campos("DiasAnteriores").Valor
        End Get
        Set(ByVal Value As Integer)
            If Me.DiasAnteriores <> Value Then vcGuardarHist = True
            vcHistorial.Campos("DiasAnteriores").Valor = Value
        End Set
    End Property

    Public Property DiasPosteriores() As Integer
        Get
            Return vcHistorial.Campos("DiasPosteriores").Valor
        End Get
        Set(ByVal Value As Integer)
            If Me.DiasPosteriores <> Value Then vcGuardarHist = True
            vcHistorial.Campos("DiasPosteriores").Valor = Value
        End Set
    End Property

    Public Property DirectorioSDF() As String
        Get
            Return vcHistorial.Campos("DirectorioSDF").Valor
        End Get
        Set(ByVal Value As String)
            If Me.DirectorioSDF <> Value Then vcGuardarHist = True
            vcHistorial.Campos("DirectorioSDF").Valor = Value
        End Set
    End Property

    Public Property ClienteVariasRutas() As Boolean
        Get
            Return vcHistorial.Campos("ClienteVariasRutas").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.ClienteVariasRutas <> Value Then vcGuardarHist = True
            vcHistorial.Campos("ClienteVariasRutas").Valor = Value
        End Set
    End Property

    Public Property DirInterfaz() As String
        Get
            Return vcHistorial.Campos("DirInterfaz").Valor
        End Get
        Set(ByVal Value As String)
            If Me.DirInterfaz <> Value Then vcGuardarHist = True
            vcHistorial.Campos("DirInterfaz").Valor = Value
        End Set
    End Property

    Public Property InterfazTXT() As Boolean
        Get
            Return vcHistorial.Campos("InterfazTXT").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.InterfazTXT <> Value Then vcGuardarHist = True
            vcHistorial.Campos("InterfazTXT").Valor = Value
        End Set
    End Property

    Public Property DepGarantia() As Boolean
        Get
            Return vcHistorial.Campos("DepGarantia").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.DepGarantia <> Value Then vcGuardarHist = True
            vcHistorial.Campos("DepGarantia").Valor = Value
        End Set
    End Property

    Public Property CuotasGarantia() As Integer
        Get
            Return vcHistorial.Campos("CuotasGarantia").Valor
        End Get
        Set(ByVal Value As Integer)
            If Me.CuotasGarantia <> Value Then vcGuardarHist = True
            vcHistorial.Campos("CuotasGarantia").Valor = Value
        End Set
    End Property

    Public Property CodigoBarrasCliente() As Boolean
        Get
            Return vcHistorial.Campos("CodigoBarrasCliente").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.CodigoBarrasCliente <> Value Then vcGuardarHist = True
            vcHistorial.Campos("CodigoBarrasCliente").Valor = Value
        End Set
    End Property

    Public Property ContrasenaCliente() As Boolean
        Get
            Return vcHistorial.Campos("ContrasenaCliente").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.ContrasenaCliente <> Value Then vcGuardarHist = True
            vcHistorial.Campos("ContrasenaCliente").Valor = Value
        End Set
    End Property

    Public Property CambioProducto() As Boolean
        Get
            Return vcHistorial.Campos("CambioProducto").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.CambioProducto <> Value Then vcGuardarHist = True
            vcHistorial.Campos("CambioProducto").Valor = Value
        End Set
    End Property

    Public Property CobrarVentas() As Boolean
        Get
            Return vcHistorial.Campos("CobrarVentas").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.CobrarVentas <> Value Then vcGuardarHist = True
            vcHistorial.Campos("CobrarVentas").Valor = Value
        End Set
    End Property

    Public Property ConversionKg() As Boolean
        Get
            Return vcHistorial.Campos("ConversionKg").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.ConversionKg <> Value Then vcGuardarHist = True
            vcHistorial.Campos("ConversionKg").Valor = Value
        End Set
    End Property

    Public Property IntUnidadVta() As Boolean
        Get
            Return vcHistorial.Campos("IntUnidadVta").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.IntUnidadVta <> Value Then vcGuardarHist = True
            vcHistorial.Campos("IntUnidadVta").Valor = Value
        End Set
    End Property

    'Public Property LimiteCredito() As Boolean
    '    Get
    '        Return vcHistorial.Campos("LimiteCredito").Valor
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        If Me.LimiteCredito <> Value Then vcGuardarHist = True
    '        vcHistorial.Campos("LimiteCredito").Valor = Value
    '    End Set
    'End Property

    'Public Property VencimientoPagos() As Boolean
    '    Get
    '        Return vcHistorial.Campos("VencimientoPagos").Valor
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        If Me.VencimientoPagos <> Value Then vcGuardarHist = True
    '        vcHistorial.Campos("VencimientoPagos").Valor = Value
    '    End Set
    'End Property
    'Public Property PagoContado() As Boolean
    '    Get
    '        Return vcHistorial.Campos("PagoContado").Valor
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        If Me.PagoContado <> Value Then vcGuardarHist = True
    '        vcHistorial.Campos("PagoContado").Valor = Value
    '    End Set
    'End Property
    Public Property EliminaEnviado() As Boolean
        Get
            Return vcHistorial.Campos("EliminaEnviado").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.EliminaEnviado <> Value Then vcGuardarHist = True
            vcHistorial.Campos("EliminaEnviado").Valor = Value
        End Set
    End Property
    'Public Property DiasVencimiento() As Integer
    '    Get
    '        Return vcHistorial.Campos("DiasVencimiento").Valor
    '    End Get
    '    Set(ByVal Value As Integer)
    '        If Me.DiasVencimiento <> Value Then vcGuardarHist = True
    '        vcHistorial.Campos("DiasVencimiento").Valor = Value
    '    End Set
    'End Property

    'Public Property LimiteCreditoCheque() As Boolean
    '    Get
    '        Return vcHistorial.Campos("LimiteCreditoCheque").Valor
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        If Me.LimiteCreditoCheque <> Value Then vcGuardarHist = True
    '        vcHistorial.Campos("LimiteCreditoCheque").Valor = Value
    '    End Set
    'End Property

    Public Property TicketConfigurado() As Integer
        Get
            Return vcHistorial.Campos("TicketConfigurado").Valor
        End Get
        Set(ByVal Value As Integer)
            If Me.TicketConfigurado <> Value Then vcGuardarHist = True
            vcHistorial.Campos("TicketConfigurado").Valor = Value
        End Set
    End Property

    Public Property PagoAutomatico() As Boolean
        Get
            Return vcHistorial.Campos("PagoAutomatico").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.PagoAutomatico <> Value Then vcGuardarHist = True
            vcHistorial.Campos("PagoAutomatico").Valor = Value
        End Set
    End Property

    Public Property PreLiquidacion() As Boolean
        Get
            Return vcHistorial.Campos("PreLiquidacion").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.PreLiquidacion <> Value Then vcGuardarHist = True
            vcHistorial.Campos("PreLiquidacion").Valor = Value
        End Set
    End Property

    Public Property DiferenciaPreliqui() As Decimal
        Get
            Return vcHistorial.Campos("DiferenciaPreliqui").Valor
        End Get
        Set(ByVal Value As Decimal)
            If Me.DiferenciaPreliqui <> Value Then vcGuardarHist = True
            vcHistorial.Campos("DiferenciaPreliqui").Valor = Decimal.Round(Value, 2)
        End Set
    End Property

    Public Property AuditarCarga() As Boolean
        Get
            Return vcHistorial.Campos("AuditarCarga").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.AuditarCarga <> Value Then vcGuardarHist = True
            vcHistorial.Campos("AuditarCarga").Valor = Value
        End Set
    End Property

    Public Property Inventario() As Boolean
        Get
            Return vcHistorial.Campos("Inventario").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.Inventario <> Value Then vcGuardarHist = True
            vcHistorial.Campos("Inventario").Valor = Value
        End Set
    End Property

    Public Property ModificarVenta() As Boolean
        Get
            Return vcHistorial.Campos("ModificarVenta").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.ModificarVenta <> Value Then vcGuardarHist = True
            vcHistorial.Campos("ModificarVenta").Valor = Value
        End Set
    End Property

    Public Property MostrarLogo() As Boolean
        Get
            Return vcHistorial.Campos("MostrarLogo").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.MostrarLogo <> Value Then vcGuardarHist = True
            vcHistorial.Campos("MostrarLogo").Valor = Value
        End Set
    End Property

    Public Property EnvioParcial() As Boolean
        Get
            Return vcHistorial.Campos("EnvioParcial").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.EnvioParcial <> Value Then vcGuardarHist = True
            vcHistorial.Campos("EnvioParcial").Valor = Value
        End Set
    End Property

    Public Property TipoLimiteCredito() As Integer
        Get
            Return vcHistorial.Campos("TipoLimiteCredito").Valor
        End Get
        Set(ByVal Value As Integer)
            If Me.TipoLimiteCredito <> Value Then vcGuardarHist = True
            vcHistorial.Campos("TipoLimiteCredito").Valor = Value
        End Set
    End Property

    Public Property PorcentajeRiesgo() As Double
        Get
            Return vcHistorial.Campos("PorcentajeRiesgo").Valor
        End Get
        Set(ByVal Value As Double)
            If Me.PorcentajeRiesgo <> Value Then vcGuardarHist = True
            vcHistorial.Campos("PorcentajeRiesgo").Valor = Value
        End Set
    End Property

    Public Property PorcentajeInteres() As Double
        Get
            Return vcHistorial.Campos("PorcentajeInteres").Valor
        End Get
        Set(ByVal Value As Double)
            If Me.PorcentajeInteres <> Value Then vcGuardarHist = True
            vcHistorial.Campos("PorcentajeInteres").Valor = Value
        End Set
    End Property
    Public Property DecimalesImporte() As Integer
        Get
            Return vcHistorial.Campos("DecimalesImporte").Valor
        End Get
        Set(ByVal Value As Integer)
            If Me.DecimalesImporte <> Value Then vcGuardarHist = True
            vcHistorial.Campos("DecimalesImporte").Valor = Value
        End Set
    End Property

    Public Property ValidaInv() As Boolean
        Get
            Return vcHistorial.Campos("ValidaInv").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.ValidaInv <> Value Then vcGuardarHist = True
            vcHistorial.Campos("ValidaInv").Valor = Value
        End Set
    End Property

    Public ReadOnly Property Monedas() As ERMMONLOG.cMonedaTabla
        Get
            Return vcMoneda.Tabla
        End Get
    End Property

    Public Property TipoIniciarVisita() As Integer
        Get
            Return vcHistorial.Campos("TipoIniciarVisita").Valor
        End Get
        Set(ByVal Value As Integer)
            If Me.TipoIniciarVisita <> Value Then vcGuardarHist = True
            vcHistorial.Campos("TipoIniciarVisita").Valor = Value
        End Set
    End Property

    Public Property LimiteGPS() As Decimal
        Get
            Return vcHistorial.Campos("LimiteGPS").Valor
        End Get
        Set(ByVal Value As Decimal)
            If Me.LimiteGPS <> Value Then vcGuardarHist = True
            vcHistorial.Campos("LimiteGPS").Valor = Value
        End Set
    End Property

    Public Property ClientesVisitados() As Boolean
        Get
            Return vcHistorial.Campos("ClientesVisitados").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.ClientesVisitados <> Value Then vcGuardarHist = True
            vcHistorial.Campos("ClientesVisitados").Valor = Value
        End Set
    End Property

    Public Property DatosCteNuevo() As Boolean
        Get
            Return vcHistorial.Campos("DatosCteNuevo").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.DatosCteNuevo <> Value Then vcGuardarHist = True
            vcHistorial.Campos("DatosCteNuevo").Valor = Value
        End Set

    End Property

    Public Property VenderApartado() As Boolean
        Get
            Return vcHistorial.Campos("VenderApartado").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.VenderApartado <> Value Then vcGuardarHist = True
            vcHistorial.Campos("VenderApartado").Valor = Value
        End Set

    End Property

    Public Property VentaSinSurtir() As Boolean
        Get
            Return vcHistorial.Campos("VentaSinSurtir").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.VentaSinSurtir <> Value Then vcGuardarHist = True
            vcHistorial.Campos("VentaSinSurtir").Valor = Value
        End Set
    End Property

    Public Property Puerto() As Integer
        Get
            Return vcHistorial.Campos("Puerto").Valor
        End Get
        Set(ByVal value As Integer)
            If Me.Puerto <> value Then vcGuardarHist = True
            vcHistorial.Campos("Puerto").Valor = value
        End Set
    End Property

    Public Property ServidorSMTP() As String
        Get
            Return vcHistorial.Campos("ServidorSMTP").Valor
        End Get
        Set(ByVal Value As String)
            If Me.ServidorSMTP <> Value Then vcGuardarHist = True
            vcHistorial.Campos("ServidorSMTP").Valor = Value
        End Set
    End Property
    Public Property Correo() As String
        Get
            Return vcHistorial.Campos("Correo").Valor
        End Get
        Set(ByVal Value As String)
            If Me.Correo <> Value Then vcGuardarHist = True
            vcHistorial.Campos("Correo").Valor = Value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return vcHistorial.Campos("Password").Valor
        End Get
        Set(ByVal Value As String)
            If Me.Password <> Value Then vcGuardarHist = True
            vcHistorial.Campos("Password").Valor = Value
        End Set
    End Property

    Public Property SSL() As Boolean
        Get
            Return vcHistorial.Campos("SSL").Valor
        End Get
        Set(ByVal Value As Boolean)
            If Me.SSL <> Value Then vcGuardarHist = True
            vcHistorial.Campos("SSL").Valor = Value
        End Set
    End Property

#End Region

    Public Function Recuperar() As Boolean
        Dim vlDt As DataTable
        vlDt = vcConfig.Seleccionar()
        If vlDt.Rows.Count = 0 Then Return False
        With vcConfig
            .Campos("ConfiguracionID").Valor = vlDt.Rows.Item(0).Item("ConfiguracionID")
            .Campos("NombreEmpresa").Valor = vlDt.Rows.Item(0).Item("NombreEmpresa")
            .Campos("RFC").Valor = vlDt.Rows.Item(0).Item("RFC")
            .Campos("Pais").Valor = vlDt.Rows.Item(0).Item("Pais")
            .Campos("Region").Valor = vlDt.Rows.Item(0).Item("Region")
            .Campos("Localidad").Valor = vlDt.Rows.Item(0).Item("Localidad")
            .Campos("ReferenciaDom").Valor = vlDt.Rows.Item(0).Item("ReferenciaDom")
            .Campos("Ciudad").Valor = vlDt.Rows.Item(0).Item("Ciudad")
            .Campos("Colonia").Valor = vlDt.Rows.Item(0).Item("Colonia")
            .Campos("Calle").Valor = vlDt.Rows.Item(0).Item("Calle")
            .Campos("Numero").Valor = vlDt.Rows.Item(0).Item("Numero")
            .Campos("NumeroInterior").Valor = vlDt.Rows.Item(0).Item("NumeroInterior")
            .Campos("CodigoPostal").Valor = vlDt.Rows.Item(0).Item("CodigoPostal")
            .Campos("LogoTipo").Valor = vlDt.Rows.Item(0).Item("LogoTipo")
            .Campos("Telefono").Valor = vlDt.Rows.Item(0).Item("Telefono")
            '.Campos("CodigoBarrasCEDI").Valor = vlDt.Rows.Item(0).Item("CodigoBarrasCEDI")
        End With
        vcHistorial.Campos("ConfiguracionID").Valor = vlDt.Rows.Item(0).Item("ConfiguracionID")
        vlDt = Me.RecuperarHistorial()
        If vlDt.Rows.Count > 0 Then
            Me.TipoLenguaje = vlDt.Rows(vlDt.Rows.Count - 1).Item("TipoLenguaje")
            'Me.Promocion = vlDt.Rows(vlDt.Rows.Count - 1).Item("Promocion")
            Me.TipoClaveProducto = vlDt.Rows(vlDt.Rows.Count - 1).Item("TipoClaveProducto")
            Me.DigitoClaveProd = vlDt.Rows(vlDt.Rows.Count - 1).Item("DigitoClaveProd")
            Me.AbonoProgramado = vlDt.Rows(vlDt.Rows.Count - 1).Item("AbonoProgramado")
            Me.MonedaID = vlDt.Rows(vlDt.Rows.Count - 1).Item("MonedaID")
            Me.DiasSurtido = vlDt.Rows(vlDt.Rows.Count - 1).Item("DiasSurtido")

            Me.DiasAnteriores = vlDt.Rows(vlDt.Rows.Count - 1).Item("DiasAnteriores")
            Me.DiasPosteriores = vlDt.Rows(vlDt.Rows.Count - 1).Item("DiasPosteriores")

            Me.CantidadSerAct = vlDt.Rows(vlDt.Rows.Count - 1).Item("CantidadSerAct")
            Me.FiltroProductos = vlDt.Rows(vlDt.Rows.Count - 1).Item("FiltroProductos")
            Me.ClienteVariasRutas = vlDt.Rows(vlDt.Rows.Count - 1).Item("ClienteVariasRutas")
            Me.DirectorioSDF = IIf(IsDBNull(vlDt.Rows(vlDt.Rows.Count - 1).Item("DirectorioSDF")), "", vlDt.Rows(vlDt.Rows.Count - 1).Item("DirectorioSDF"))
            Me.DirInterfaz = IIf(IsDBNull(vlDt.Rows(vlDt.Rows.Count - 1).Item("DirInterfaz")), String.Empty, vlDt.Rows(vlDt.Rows.Count - 1).Item("DirInterfaz"))
            Me.InterfazTXT = vlDt.Rows(vlDt.Rows.Count - 1).Item("InterfazTXT")
            Me.DepGarantia = vlDt.Rows(vlDt.Rows.Count - 1).Item("DepGarantia")
            Me.CuotasGarantia = vlDt.Rows(vlDt.Rows.Count - 1).Item("CuotasGarantia")
            Me.CodigoBarrasCliente = vlDt.Rows(vlDt.Rows.Count - 1).Item("CodigoBarrasCliente")
            Me.ContrasenaCliente = vlDt.Rows(vlDt.Rows.Count - 1).Item("ContrasenaCliente")
            Me.CambioProducto = vlDt.Rows(vlDt.Rows.Count - 1).Item("CambioProducto")
            Me.CobrarVentas = vlDt.Rows(vlDt.Rows.Count - 1).Item("CobrarVentas")

            Me.ConversionKg = vlDt.Rows(vlDt.Rows.Count - 1).Item("ConversionKg")
            Me.IntUnidadVta = vlDt.Rows(vlDt.Rows.Count - 1).Item("IntUnidadVta")
            'Me.LimiteCredito = vlDt.Rows(vlDt.Rows.Count - 1).Item("LimiteCredito")
            'Me.VencimientoPagos = vlDt.Rows(vlDt.Rows.Count - 1).Item("VencimientoPagos")
            'Me.DiasVencimiento = vlDt.Rows(vlDt.Rows.Count - 1).Item("DiasVencimiento")
            'Me.PagoContado = vlDt.Rows(vlDt.Rows.Count - 1).Item("PagoContado")
            Me.EliminaEnviado = vlDt.Rows(vlDt.Rows.Count - 1).Item("EliminaEnviado")
            'Me.LimiteCreditoCheque = vlDt.Rows(vlDt.Rows.Count - 1).Item("LimiteCreditoCheque")
            Me.TicketConfigurado = vlDt.Rows(vlDt.Rows.Count - 1).Item("TicketConfigurado")
            Me.PagoAutomatico = vlDt.Rows(vlDt.Rows.Count - 1).Item("PagoAutomatico")
            Me.PreLiquidacion = vlDt.Rows(vlDt.Rows.Count - 1).Item("PreLiquidacion")
            Me.DiferenciaPreliqui = IIf(IsDBNull(vlDt.Rows(vlDt.Rows.Count - 1).Item("DiferenciaPreliqui")), 0, vlDt.Rows(vlDt.Rows.Count - 1).Item("DiferenciaPreliqui"))
            Me.Inventario = vlDt.Rows(vlDt.Rows.Count - 1).Item("Inventario")
            Me.ModificarVenta = vlDt.Rows(vlDt.Rows.Count - 1).Item("ModificarVenta")
            Me.AuditarCarga = vlDt.Rows(vlDt.Rows.Count - 1).Item("AuditarCarga")
            Me.MostrarLogo = vlDt.Rows(vlDt.Rows.Count - 1).Item("MostrarLogo")
            Me.EnvioParcial = vlDt.Rows(vlDt.Rows.Count - 1).Item("EnvioParcial")
            Me.TipoLimiteCredito = vlDt.Rows(vlDt.Rows.Count - 1).Item("TipoLimiteCredito")
            Me.PorcentajeRiesgo = vlDt.Rows(vlDt.Rows.Count - 1).Item("PorcentajeRiesgo")
            Me.PorcentajeInteres = vlDt.Rows(vlDt.Rows.Count - 1).Item("PorcentajeInteres")
            Me.DecimalesImporte = vlDt.Rows(vlDt.Rows.Count - 1).Item("DecimalesImporte")
            Me.ValidaInv = vlDt.Rows(vlDt.Rows.Count - 1).Item("ValidaInv")


            'Me.RFCGenerico = vlDt.Rows(vlDt.Rows.Count - 1).Item("RFCGenerico")            
 
            Me.TipoIniciarVisita = vlDt.Rows(vlDt.Rows.Count - 1).Item("TipoIniciarVisita")
            Me.LimiteGPS = IIf(IsDBNull(vlDt.Rows(vlDt.Rows.Count - 1).Item("LimiteGPS")), 0, vlDt.Rows(vlDt.Rows.Count - 1).Item("LimiteGPS"))
            Me.ClientesVisitados = vlDt.Rows(vlDt.Rows.Count - 1).Item("ClientesVisitados")
            Me.DatosCteNuevo = vlDt.Rows(vlDt.Rows.Count - 1).Item("DatosCteNuevo")
            Me.VenderApartado = vlDt.Rows(vlDt.Rows.Count - 1).Item("VenderApartado")
            Me.VentaSinSurtir = vlDt.Rows(vlDt.Rows.Count - 1).Item("VentaSinSurtir")

            Me.Puerto = IIf(IsDBNull(vlDt.Rows(vlDt.Rows.Count - 1).Item("Puerto")), 0, vlDt.Rows(vlDt.Rows.Count - 1).Item("Puerto"))
            Me.Password = IIf(IsDBNull(vlDt.Rows(vlDt.Rows.Count - 1).Item("Password")), "", vlDt.Rows(vlDt.Rows.Count - 1).Item("Password"))
            Me.ServidorSMTP = IIf(IsDBNull(vlDt.Rows(vlDt.Rows.Count - 1).Item("ServidorSMTP")), "", vlDt.Rows(vlDt.Rows.Count - 1).Item("ServidorSMTP"))
            Me.Correo = IIf(IsDBNull(vlDt.Rows(vlDt.Rows.Count - 1).Item("Correo")), "", vlDt.Rows(vlDt.Rows.Count - 1).Item("Correo"))

            Me.SSL = vlDt.Rows(vlDt.Rows.Count - 1).Item("SSL")
        End If
        vcGuardarHist = False
        Return True
    End Function

    Public Sub Grabar(ByVal pvLogo As Boolean)  'pvlogo nos indica si vamos a actualizar el logo
        If Not pvLogo Then vcConfig.Campos.Remove(vcLogo)
        vcConfig.Modificar()
        If Not pvLogo Then vcConfig.Campos.Add(vcLogo)
        If vcGuardarHist Then vcHistorial.Insertar()
    End Sub

    Public Sub Insertar()
        vcConfig.Insertar()
        vcHistorial.Insertar()
    End Sub

    Public Sub ValidarCON(ByVal vlCampoNombre As String)
        Dim vlCampo As LbDatos.cCampo
        vlCampo = vcConfig.Campos(vlCampoNombre)

        If vlCampo.Requerido Then
            If IsDBNull(vlCampo.Valor) Or vlCampo.Valor Is Nothing Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CON" + vlCampo.Nombre, True)}, vlCampo.Nombre)
            End If
            If vlCampo.Tipo = LbDatos.ETipo.Cadena Then
                If vlCampo.Valor = "" Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CON" + vlCampo.Nombre, True)}, vlCampo.Nombre)
                End If
            End If
        End If
        Select Case vlCampo.Tipo
            Case LbDatos.ETipo.Numerico
                If IsDBNull(vlCampo.Valor) = False Then
                    If vlCampo.Valor < 0 Then
                        'Throw New LbControlError.cError("E0007", , vlCampo.Nombre)
                        Throw New LbControlError.cError("E0607", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CON" + vlCampo.Nombre, True)}, vlCampo.Nombre)
                    End If
                End If
        End Select
    End Sub

    Public Sub ValidarCOH(ByVal vlCampoNombre As String)
        Dim vlCampo As LbDatos.cCampo
        vlCampo = vcHistorial.Campos(vlCampoNombre)

        If vlCampo.Requerido Then
            If IsDBNull(vlCampo.Valor) Or vlCampo.Valor Is Nothing Then
                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("COH" + vlCampo.Nombre, True)}, vlCampo.Nombre)
            End If
            If vlCampo.Tipo = LbDatos.ETipo.Cadena Then
                If vlCampo.Valor = "" Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("COH" + vlCampo.Nombre, True)}, vlCampo.Nombre)
                End If
            End If
        End If
        Select Case vlCampo.Tipo
            Case LbDatos.ETipo.Numerico
                If IsDBNull(vlCampo.Valor) = False Then
                    If vlCampo.Valor < 0 Then
                        'Throw New LbControlError.cError("E0007", , vlCampo.Nombre)
                        Throw New LbControlError.cError("E0607", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("COH" + vlCampo.Nombre, True)}, vlCampo.Nombre)
                    End If
                End If
        End Select
        If vlCampo.Nombre = "DigitoClaveProd" Then
            If vcHistorial.Campos("TipoClaveProducto").Valor = 2 Then 'Numérico
                If vlCampo.Valor <= 0 Then
                    Throw New LbControlError.cError("E0237", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("COH" + vlCampo.Nombre, True)}, vlCampo.Nombre)
                    Exit Sub
                End If
                If vlCampo.Valor > 10 Then
                    Throw New LbControlError.cError("E0333", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("COH" + vlCampo.Nombre, True), New LbControlError.cParametroMSG("10", False)}, vlCampo.Nombre)
                    Exit Sub
                End If
            End If
        End If
        If vlCampo.Nombre = "CuotasGarantia" Then
            If Me.DepGarantia Then
                If vlCampo.Valor <= 0 Then
                    Throw New LbControlError.cError("E0012", , vlCampo.Nombre)
                End If
            End If
        End If
        If vlCampo.Nombre = "DiferenciaPreliqui" Then
            If Me.PreLiquidacion Then
                If vlCampo.Valor < 0 Then
                    Throw New LbControlError.cError("E0007", , vlCampo.Nombre)
                End If
            End If
        End If

        If vlCampo.Nombre = "PorcentajeRiesgo" Or vlCampo.Nombre = "DecimalesImporte" Or vlCampo.Nombre = "PorcentajeInteres" Then
            If vlCampo.Valor < 0 Then
                Throw New LbControlError.cError("E0007", , vlCampo.Nombre)
            End If
        End If


        If vlCampo.Nombre = "DecimalesImporte" Then
            If vlCampo.Valor > 13 Then
                Throw New LbControlError.cError("E0333", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("COH" + vlCampo.Nombre, True), New LbControlError.cParametroMSG(13, False)}, vlCampo.Nombre)
            End If
        End If

        If vlCampo.Nombre = "ServidorSMTP" Then
            If vlCampo.Valor.ToString <> "" Then
                Dim oReg As New Regex("^[a-zA-Z][\w\.'-]*[a-zA-Z0-9\.']$")
                If Not oReg.IsMatch(vlCampo.Valor) Then
                    Throw New LbControlError.cError("E0600", , vlCampo.Nombre)
                End If
            End If
        End If

        If vlCampo.Nombre = "Correo" Then
            If vlCampo.Valor.ToString <> "" Then
                Dim oReg As New Regex("^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")
                If Not oReg.IsMatch(vlCampo.Valor) Then
                    Throw New LbControlError.cError("E0816", , vlCampo.Nombre)
                End If
            End If
        End If

        If vlCampo.Nombre = "Password" Then
            If vlCampo.Valor.ToString <> "" Then
                Dim oReg As New Regex("^[\S]*[\S]$")
                If Not oReg.IsMatch(vlCampo.Valor) Then
                    Throw New LbControlError.cError("E0600", , vlCampo.Nombre)
                End If
            End If
        End If

    End Sub

    Public Function Validar() As Boolean
        For Each vlCampo As LbDatos.cCampo In vcConfig.Campos
            ValidarCON(vlCampo.Nombre)
        Next

        For Each vlCampo As LbDatos.cCampo In vcHistorial.Campos
            ValidarCOH(vlCampo.Nombre)
        Next
    End Function

    Public Function RecuperarHistorialOrdenado() As DataTable
        Dim campos As String = "ConHist.tipolenguaje,ConHist.MonedaId,ConHist.MostrarLogo,ConHist.TipoClaveProducto,ConHist.DigitoClaveProd,ConHist.DiasSurtido,ConHist.CambioProducto,ConHist.ConversionKg,ConHist.FiltroProductos,ConHist.ModificarVenta,ConHist.AbonoProgramado,ConHist.CobrarVentas,ConHist.PagoAutomatico,"
        campos = campos & "ConHist.TipoLimiteCredito,ConHist.PorcentajeRiesgo,ConHist.DecimalesImporte ,ConHist.TicketConfigurado,ConHist.DiasAnteriores,ConHist.DiasPosteriores,ConHist.ClienteVariasRutas,ConHist.CodigoBarrasCliente,ConHist.ContrasenaCliente,ConHist.ValidaInv,ConHist.DirectorioSDF,ConHist.DirInterfaz,ConHist.InterfazTXT,ConHist.IntUnidadVta,ConHist.Inventario,"
        campos = campos & "ConHist.AuditarCarga,ConHist.Interfaztxt,ConHist.Preliquidacion,ConHist.DiferenciaPreliqui,ConHist.CantidadSerAct,ConHist.EnvioParcial,Conhist.EliminaEnviado,CONHistFechaInicio,ConHist.TipoIniciarVisita,ConHist.LimiteGPS,ConHist.ClientesVisitados,ConHist.DatosCteNuevo,ConHist.VenderApartado,ConHist.VentaSinSurtir,"
        campos = campos & "Conhist.SSL,ConHist.PorcentajeInteres, ConHist.MFechaHora, "
        Return vcHistorial.Seleccionar("ConfiguracionID='" & Me.ConfiguracionID & "' ORDER BY CONHistFechaInicio", campos + " isnull((select Usuario.Clave from Usuario where Usuario.USUId = ConHist.MUsuarioId), ConHist.MUsuarioId) as UsuarioClave ")
    End Function

    Public Function RecuperarHistorial() As DataTable

        Return vcHistorial.Seleccionar("ConfiguracionID='" & Me.ConfiguracionID & "' ORDER BY CONHistFechaInicio", "ConHist.*, isnull((select Usuario.Clave from Usuario where Usuario.USUId = ConHist.MUsuarioId), ConHist.MUsuarioId) as UsuarioClave")
    End Function

    Public Function ExistenFoliosAsignados() As Boolean
        Dim sConsulta As String
        sConsulta = "select count(*) as Asignados from FolioSolicitado FOS "
        sConsulta &= "inner join FosHist FOH on FOH.FolioId = FOS.FolioId and FOH.FOSId = FOS.FOSId "
        sConsulta &= "where FOS.Usados < FOS.CantSolicitada "
        Return (vcConfig.Conexion.EjecutarComandoScalar(sConsulta) > 0)
    End Function

    'Public Sub GenerarArchivoPEM()
    '    If ContrasenaClave <> "" And DirArchivosFacElec <> "" And System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "OPENSSL\OPENSSL.exe") Then
    '        Dim DirSello As String = Nothing
    '        Dim DirOpenSSL As String = Nothing
    '        Dim Leido As String = Nothing

    '        If Not System.IO.Directory.Exists(DirArchivosFacElec) Then
    '            Throw New LbControlError.cError("E0682", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(DirArchivosFacElec, False)}, "DirDocXML")
    '        End If

    '        For Each s As String In System.IO.Directory.GetFiles(DirArchivosFacElec)
    '            If s.EndsWith(".key") Then
    '                DirSello = s
    '                Exit For
    '            End If
    '        Next

    '        Try
    '            If Not DirSello Is Nothing Then
    '                DirOpenSSL = System.AppDomain.CurrentDomain.BaseDirectory & "OPENSSL\OPENSSL.exe"
    '                Dim cmd As String = "pkcs8 -inform DER -in """ & DirSello & """ -passin pass:" & ContrasenaClave & " -out """ & DirSello & ".pem"""

    '                Process.Start("""" & DirOpenSSL & """", cmd)
    '                For i As Integer = 0 To 3
    '                    System.Threading.Thread.Sleep(500)
    '                    If System.IO.File.Exists(DirSello & ".pem") AndAlso New System.IO.FileInfo(DirSello & ".pem").Length > 0 Then
    '                        Exit For
    '                    End If
    '                Next

    '                If Not System.IO.File.Exists(DirSello & ".pem") Then
    '                    Throw New LbControlError.cError("E0681", , "DirDocXML")
    '                End If
    '                Dim fi1 As System.IO.FileInfo = New System.IO.FileInfo(DirSello & ".pem")
    '                If fi1.Length = 0 Then Throw New LbControlError.cError("E0681", , "DirDocXML")

    '                Dim leer_archivo As New System.IO.FileStream(DirSello & ".pem", IO.FileMode.Open)
    '                Dim bytesLeidos(leer_archivo.Length) As Byte
    '                leer_archivo.Read(bytesLeidos, 0, leer_archivo.Length)
    '                leer_archivo.Close()

    '                ArchivoPEM = Convert.ToBase64String(bytesLeidos)
    '                System.Threading.Thread.Sleep(500)
    '                System.IO.File.Delete(DirSello & ".pem")
    '            Else
    '                Throw New LbControlError.cError("E0681", , "DirDocXML")
    '            End If

    '        Catch ex As LbControlError.cError
    '            If System.IO.File.Exists(DirSello & ".pem") Then
    '                System.IO.File.Delete(DirSello & ".pem")
    '            End If
    '            ArchivoPEM = ""
    '            ex.Mostrar()
    '            'Throw New LbControlError.cError("E0681", , "DirDocXML")
    '        End Try

    '    End If

    'End Sub
End Class
