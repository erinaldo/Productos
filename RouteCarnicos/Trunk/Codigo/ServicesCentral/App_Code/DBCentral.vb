Imports Microsoft.VisualBasic

Namespace DBCentral

    Public Class CVista

        Protected iVistaId As Integer
        Protected sNombre As String

        Public Property VistaId() As Integer
            Get
                Return iVistaId
            End Get
            Set(ByVal Value As Integer)
                iVistaId = Value
            End Set
        End Property
        Public Property Nombre() As String
            Get
                Return sNombre
            End Get
            Set(ByVal Value As String)
                sNombre = Value
            End Set
        End Property

    End Class

    Public Class CVistaElemento

        Protected iVistaElementoId As Integer
        Protected sNombre As String
        Protected sMensajeClave As String
        Protected eTipoControl As DBCentral.TiposControl
        Protected eTipoContenido As DBCentral.TiposContenido
        Protected sConsultaSQL As String

        Public Property VistaElementoId() As Integer
            Get
                Return iVistaElementoId
            End Get
            Set(ByVal Value As Integer)
                iVistaElementoId = Value
            End Set
        End Property
        Public Property Nombre() As String
            Get
                Return sNombre
            End Get
            Set(ByVal Value As String)
                sNombre = Value
            End Set
        End Property
        Public Property MensajeClave() As String
            Get
                Return sMensajeClave
            End Get
            Set(ByVal Value As String)
                sMensajeClave = Value
            End Set
        End Property
        Public Property TipoControl() As DBCentral.TiposControl
            Get
                Return eTipoControl
            End Get
            Set(ByVal Value As DBCentral.TiposControl)
                eTipoControl = Value
            End Set
        End Property
        Public Property TipoContenido() As DBCentral.TiposContenido
            Get
                Return eTipoContenido
            End Get
            Set(ByVal Value As DBCentral.TiposContenido)
                eTipoContenido = Value
            End Set
        End Property
        Public Property ConsultaSQL() As String
            Get
                Return sConsultaSQL
            End Get
            Set(ByVal Value As String)
                sConsultaSQL = Value
            End Set
        End Property

    End Class

    Public Class CVistaElementoDet

        Protected iVistaElementoDetId As Integer
        Protected sNombre As String
        Protected sMensajeClave As String
        Protected iOrden As Integer
        Protected iIndice As Short
        Protected iAncho As Short
        Protected eTipoControl As DBCentral.TiposControlDetalle
        Protected eTipoEdicion As DBCentral.TiposEdicion
        Protected eTipoVisible As DBCentral.TiposVisible
        Protected eTipoAlineacion As DBCentral.TiposAlineacion

        Public Property VistaElementoDetId() As Integer
            Get
                Return iVistaElementoDetId
            End Get
            Set(ByVal Value As Integer)
                iVistaElementoDetId = Value
            End Set
        End Property
        Public Property Nombre() As String
            Get
                Return sNombre
            End Get
            Set(ByVal Value As String)
                sNombre = Value
            End Set
        End Property
        Public Property MensajeClave() As String
            Get
                Return sMensajeClave
            End Get
            Set(ByVal Value As String)
                sMensajeClave = Value
            End Set
        End Property
        'Public Property Orden() As Integer
        '    Get
        '        Return iOrden
        '    End Get
        '    Set(ByVal Value As Integer)
        '        iOrden = Value
        '    End Set
        'End Property
        Public Property Indice() As Short
            Get
                Return iIndice
            End Get
            Set(ByVal Value As Short)
                iIndice = Value
            End Set
        End Property
        Public Property Ancho() As Short
            Get
                Return iAncho
            End Get
            Set(ByVal Value As Short)
                iAncho = Value
            End Set
        End Property
        Public Property TipoControl() As DBCentral.TiposControlDetalle
            Get
                Return eTipoControl
            End Get
            Set(ByVal Value As DBCentral.TiposControlDetalle)
                eTipoControl = Value
            End Set
        End Property
        Public Property TipoEdicion() As DBCentral.TiposEdicion
            Get
                Return eTipoEdicion
            End Get
            Set(ByVal Value As DBCentral.TiposEdicion)
                eTipoEdicion = Value
            End Set
        End Property
        Public Property TipoVisible() As DBCentral.TiposVisible
            Get
                Return eTipoVisible
            End Get
            Set(ByVal Value As DBCentral.TiposVisible)
                eTipoVisible = Value
            End Set
        End Property
        Public Property TipoAlineacion() As DBCentral.TiposAlineacion
            Get
                Return eTipoAlineacion
            End Get
            Set(ByVal Value As DBCentral.TiposAlineacion)
                eTipoAlineacion = Value
            End Set
        End Property

    End Class

    Public Class CValorReferencia

        Protected sVarCodigo As String
        Protected sDescripcion As String
        Protected sTipoDato As String
        Protected tTipoNulo As DBCentral.TiposNulo
        Protected tTipoModificable As DBCentral.TiposModificable

        Public Property VarCodigo() As String
            Get
                Return sVarCodigo
            End Get
            Set(ByVal Value As String)
                sVarCodigo = Value
            End Set
        End Property
        Public Property Descripcion() As String
            Get
                Return sDescripcion
            End Get
            Set(ByVal Value As String)
                sDescripcion = Value
            End Set
        End Property
        Public Property TipoDato() As String
            Get
                Return sTipoDato
            End Get
            Set(ByVal Value As String)
                sTipoDato = Value
            End Set
        End Property
        Public Property TipoNulo() As DBCentral.TiposNulo
            Get
                Return tTipoNulo
            End Get
            Set(ByVal Value As DBCentral.TiposNulo)
                tTipoNulo = Value
            End Set
        End Property
        Public Property TipoModificable() As DBCentral.TiposModificable
            Get
                Return tTipoModificable
            End Get
            Set(ByVal Value As DBCentral.TiposModificable)
                tTipoModificable = Value
            End Set
        End Property

    End Class

    Public Class CUsuario

        Protected sUsuarioId As String
        Protected sUsuarioClave As String
        Protected sNombre As String
        Protected sClaveEmpleado As String
        Protected sClaveAcceso As String
        Protected iDiasLimite As Integer
        Protected dFechaModificacion As Date
        Protected bActivo As Boolean
        Protected tTipo As DBCentral.TiposUsuarios

        Public Property UsuarioId() As String
            Get
                Return sUsuarioId
            End Get
            Set(ByVal Value As String)
                sUsuarioId = Value
            End Set
        End Property
        Public Property Clave() As String
            Get
                Return sUsuarioClave
            End Get
            Set(ByVal Value As String)
                sUsuarioClave = Value
            End Set
        End Property
        Public Property Nombre() As String
            Get
                Return sNombre
            End Get
            Set(ByVal Value As String)
                sNombre = Value
            End Set
        End Property
        Public Property ClaveEmpleado() As String
            Get
                Return sClaveEmpleado
            End Get
            Set(ByVal Value As String)
                sClaveEmpleado = Value
            End Set
        End Property
        Public Property ClaveAcceso() As String
            Get
                Return sClaveAcceso
            End Get
            Set(ByVal Value As String)
                sClaveAcceso = Value
            End Set
        End Property
        Public Property DiasLimite() As Integer
            Get
                Return iDiasLimite
            End Get
            Set(ByVal Value As Integer)
                iDiasLimite = Value
            End Set
        End Property
        Public Property FechaModificacion() As Date
            Get
                Return dFechaModificacion
            End Get
            Set(ByVal Value As Date)
                dFechaModificacion = Value
            End Set
        End Property
        Public Property Activo() As Boolean
            Get
                Return bActivo
            End Get
            Set(ByVal Value As Boolean)
                bActivo = Value
            End Set
        End Property
        Public Property Tipo() As DBCentral.TiposUsuarios
            Get
                Return tTipo
            End Get
            Set(ByVal Value As DBCentral.TiposUsuarios)
                tTipo = Value
            End Set
        End Property

    End Class

    Public Class CTabla

        Protected sTablaId As String
        Protected sNombre As String
        Protected sDescripcion As String
        Protected tTipo As DBCentral.TiposBase
        Protected iGrupo As Integer
        Protected iorden As Integer
        Protected sConsultaSQL As String

        Public Property TablaId() As String
            Get
                Return sTablaId
            End Get
            Set(ByVal Value As String)
                sTablaId = Value
            End Set
        End Property
        Public Property Nombre() As String
            Get
                Return sNombre
            End Get
            Set(ByVal Value As String)
                sNombre = Value
            End Set
        End Property
        Public Property Descripcion() As String
            Get
                Return sDescripcion
            End Get
            Set(ByVal Value As String)
                sDescripcion = Value
            End Set
        End Property
        Public Property Tipo() As DBCentral.TiposBase
            Get
                Return tTipo
            End Get
            Set(ByVal Value As DBCentral.TiposBase)
                tTipo = Value
            End Set
        End Property
        Public Property Grupo() As Integer
            Get
                Return iGrupo
            End Get
            Set(ByVal Value As Integer)
                iGrupo = Value
            End Set
        End Property
        Public Property Orden() As Integer
            Get
                Return iorden
            End Get
            Set(ByVal Value As Integer)
                iorden = Value
            End Set
        End Property
        Public Property ConsultaSQL() As String
            Get
                Return sConsultaSQL
            End Get
            Set(ByVal Value As String)
                sConsultaSQL = Value
            End Set
        End Property

    End Class

    Public Class CCampo

        Protected sCampoId As String
        Protected sNombre As String
        Protected sDescripcion As String
        Protected tTipo As DBCentral.TiposCampos
        Protected iLongitud As Short

        Public Property CampoId() As String
            Get
                Return sCampoId
            End Get
            Set(ByVal Value As String)
                sCampoId = Value
            End Set
        End Property
        Public Property Nombre() As String
            Get
                Return sNombre
            End Get
            Set(ByVal Value As String)
                sNombre = Value
            End Set
        End Property
        Public Property Descripcion() As String
            Get
                Return sDescripcion
            End Get
            Set(ByVal Value As String)
                sDescripcion = Value
            End Set
        End Property
        Public Property Tipo() As DBCentral.TiposCampos
            Get
                Return tTipo
            End Get
            Set(ByVal Value As DBCentral.TiposCampos)
                tTipo = Value
            End Set
        End Property
        Public Property Longitud() As Short
            Get
                Return iLongitud
            End Get
            Set(ByVal Value As Short)
                iLongitud = Value
            End Set
        End Property

    End Class

    Public Class CDia

        Protected sNombre As String
        Protected eTipoEstado As DBCentral.TiposEstadosRegistros
        Protected sReferencia As String
        Protected dFechaCaptura As Date

        Public Property Nombre() As String
            Get
                Return sNombre
            End Get
            Set(ByVal Value As String)
                sNombre = Value
            End Set
        End Property
        Public Property TipoEstado() As DBCentral.TiposEstadosRegistros
            Get
                Return eTipoEstado
            End Get
            Set(ByVal Value As DBCentral.TiposEstadosRegistros)
                eTipoEstado = Value
            End Set
        End Property
        Public Property Referencia() As String
            Get
                Return sReferencia
            End Get
            Set(ByVal Value As String)
                sReferencia = Value
            End Set
        End Property
        Public Property FechaCaptura() As Date
            Get
                Return dFechaCaptura
            End Get
            Set(ByVal Value As Date)
                dFechaCaptura = Value
            End Set
        End Property

    End Class

    Public Enum TiposModificable
        NoDefinido = 0
    End Enum

    Public Enum TiposNulo
        NoDefinido = 0

    End Enum

    Public Enum TiposDatos
        NoDefinido = 0

    End Enum

    Public Enum TiposCampos
        NoDefinido = 0
        Bit = 1
        Datetime = 2
        Int = 3
        Money = 4
        Ntext = 5
        Nvarchar = 6
        Real = 7
        Smallint = 8
        Image = 9
        Float = 10
    End Enum

    Public Enum TiposUsuarios
        NoDefinido = 0
        Administrador = 1
        Vendedor = 2
        Supervisor = 3
    End Enum

    Public Enum TiposFrecuencias
        NoDefinido = 0
        Semana = 1
        Mes = 2
        Año = 3
    End Enum

    Public Enum TiposEstadosRegistros
        Inactivo = 0
        Activo = 1
    End Enum

    Public Enum TiposNivelesVendedores
        NoDefinido = 0
        Principiante = 1
        Intermedio = 2
        Avanzado = 3
    End Enum

    Public Enum TiposOpcionesMenuVendedor
        NoDefinido = 0
        IniciarJornada = 1
        DiasDeTrabajo = 2
        FinalizarJornada = 3
        TransmitirInformacion = 4
        ConfigurarTerminal = 5
        InformacionSistema = 6
        UtileriasSistema = 7
        Preliquidacion = 8
        Reportes = 9
        Kilometraje = 10
    End Enum

    Public Enum TiposOpcionesMenuDia
        NoDefinido = 0
        Cargas = 1
        VisitarClientes = 2
        RegistrarGastos = 3
        CierreDiario = 4
        TransferirInformacion = 5
        Devoluciones = 6
        Depositos = 7
        Kardex = 8
        Descargas = 9
        Ajustes = 10
        ImpresionTickets = 11
        Reportes = 12
        AunSinUso = 13
        MovSinInv = 14
    End Enum

    Public Enum TiposBase
        NoDefinido = 0
        Aplicacion = 1
        Vendedor = 2
        Dia = 3
    End Enum

    Public Enum TiposControlDetalle
        NoDefinido = 0
        Texto = 1
        Fecha = 2
        Numerico = 3
        Logico = 4
        Etiqueta = 5
        Salto = 6
        Combo = 7
    End Enum

    Public Enum TiposEdicion
        NoDefinido = 0
        Editar = 1
        NoEditar = 2
    End Enum

    Public Enum TiposVisible
        NoDefinido = 0
        Visible = 1
        NoVisible = 2
    End Enum

    Public Enum TiposControl
        NoDefinido = 0
        Etiqueta = 1
        Boton = 2
        BarraDeEstado = 3
        PaginaDeTab = 4
        Detalle = 5
        Lista = 6
        Mensaje = 7
        Menu = 8
        MenuEmergente = 9
        SubMenu = 10
        BotonMultiple = 11
    End Enum

    Public Enum TiposAlineacion
        NoDefinido = 0
        Izquierda = 1
        Centro = 2
        Derecha = 3
    End Enum

    Public Enum TiposVistasDetalle
        NoDefinido = 0
        Sencilla = 1
        Compuesta = 2
    End Enum

    Public Enum TiposContenido
        NoDefinido = 0
        Sencillo = 1
        Multiple = 2
        Consulta = 3
    End Enum

    'Public Enum TiposEstadosClientes
    '    NoDefinido = 0
    '    ClienteVisitado = 1
    '    ClienteNoVisitado = 2
    'End Enum

    Public Enum TiposVistasAgendas
        NoDefinido = 0
        ClientesVisitados = 1
        ClientesNoVisitados = 2
        TodosClientes = 3
        PorSurtir = 6
    End Enum

    Public Enum TiposModulos
        NoDefinido = 0
        Venta = 1
        Preventa = 2
        Distribucion = 3
    End Enum

    Public Enum TiposAmbitosModulos
        NoDefinido = 0
        Visitas = 1
        General = 2
    End Enum

    Public Enum TiposModulosMov
        NoDefinido = 0
        Producto = 1
        Encuestas = 2
        Cobranza = 3
        Otros = 4
        Impresion = 5
    End Enum

    Public Enum TiposModulosMovDet
        NoDefinido = 0
        Improductivo = 1
        Solicitudes = 2
        Mensajes = 3
        Activos = 4
        Facturacion = 5
        Pagos = 6
        CuentasPorCobrar = 7
        DevolucionAlmacen = 8
        Pedido = 9
        Cargas = 10
        Ajustes = 11
        HistoricoVentas = 12
        DevolucionClientes = 13
        Cambios = 14
        Descargas = 15
        Canjes = 16
        Prestamos = 17
        DevolucionPrestamos = 18
        Mercadeo = 19
        PagosProgramados = 20
        Cobranza = 21
        MovSinInvConVis = 22
        MovSinInvSinVis = 23
        SurtirProductoPromocion = 24
        FacturacionElectronica = 25
        VentaConsignacion = 26
        Encuestas = 27
        Impresion = 28
    End Enum

    Public Enum TiposEsquemas
        NoDefinido = 0
        Clientes = 1
        Productos = 2
        Impuestos = 3
    End Enum

    Public Enum TiposContenidoFolios
        NoDefinido = 0
        Constante = 1
        Incremental = 2
    End Enum

    Public Enum TiposTransProd
        NoDefinido = 0
        Pedido = 1
        Cargas = 2
        DevolucionesCliente = 3
        DevolucionesAlmacen = 4
        SurtirPedido = 5
        Ajustes = 6
        Descargas = 7
        Factura = 8
        CambioDeProducto = 9
        Pagos = 10
        CuentasPorCobrar = 11
        BonificacionPorDetalle = 12 'Antes Cargas X Reparto
        UsuFuturo2 = 13 'Antes DesCargas X Reparto
        CargaPorCanje = 14
        DevolucionDePrestamo = 15
        PrestamoDeProducto = 16
        PreciosDeVenta = 17
        FondoCristal = 18
        MovSinInvSV = 19
        SurtirProductoPromocion = 20
        MovSinInvEV = 21
        Reclasificado = 22
        InventarioABordo = 23
        VentaConsignacion = 24
    End Enum

    Public Enum TiposFasesPedidos
        Cancelado = 0
        Captura = 1
        Surtido = 2
        Facturado = 3
        Impreso = 4
        Transferir = 5
        Liquidado = 6
        CapturaEscritorio = 7
        CanceladaPorLiquidacion = 8
        Exportar = 9
        DevolucionTotal = 10
    End Enum

    Public Enum TiposPedidos
        NoDefinido = 0
        Normal = 1
        Posfechado = 2
        Estimados = 3
        Consignacion = 4
    End Enum

    Public Enum TiposMovimientos
        NoDefinido = 0
        Entrada = 1
        Salida = 2
        Pedido = 3
    End Enum

    Public Enum TiposReinicioFolios
        NoDefinido = 0
        ValorInicial = 1
        ValorInicialMasUno = 2
    End Enum

    Public Enum TiposAccionReiniciarFolios
        NoDefinido = 0
        Diario = 1
        Continua = 2
    End Enum

    Public Enum TiposValoresAplicacionImpuestos
        NoDefinido = 0
        Porcentaje = 1
        Importe = 2
    End Enum

    Public Enum TiposAplicacionImpuestos
        NoDefinido = 0
        SubtotalSinImpuestos = 1
        SubtotalConImpuestos = 2
    End Enum

    Public Enum TiposDescuentos
        NoDefinido = 0
        Inmediato = 1
        Programado = 2
    End Enum

    Public Enum TiposAplicacionDescuentos
        NoDefinido = 0
        Total = 1
        Producto = 2
    End Enum

    Public Enum TiposValoresDescuentos
        NoDefinido = 0
        Importe = 1
        Porcentaje = 2
    End Enum

    Public Enum TiposInspeccionDescuentos
        NoDefinido = 0
        PorImporte = 1
        PorCantidad = 2
    End Enum

    Public Enum TiposPromociones
        NoDefinido = 0
        Producto = 1
        Cliente = 2
        FondoCristal = 3
        ProductosAcumulados = 4
    End Enum

    Public Enum TiposAplicacionPromociones
        NoDefinido = 0
        Descuento = 1
        Bonificacion = 2
        Precio = 3
        Producto = 4
    End Enum

    Public Enum TiposRangosPromociones
        NoDefinido = 0
        PorCantidad = 1
        PorImporte = 2
        PorElemento = 3
    End Enum

    Public Enum TiposTablasCampos
        Nulos = 0 ' NULL
        LlavePrimaria = 1
        LlaveForanea = 2
        LlavePrimariaForanea = 3
        LlaveForaneaNulos = 4
        NoNulos = 5 ' NOT NULL
    End Enum

    Public Enum TiposMensajesAplicacion
        NoDefinido = 0
        Escritorio = 1
        Movil = 2
        Ambas = 3
    End Enum


    Public Enum TiposConsulta
        NoDefinido = 0
        Canjes = 1
        Facturas = 2
        Prestamos = 3
        Actualizacion = 4
        Reparto = 5
        Cargas = 6
        PedidosConSaldo = 7
        Recargas = 8
        InventarioABordo = 9
        Consignacion = 10
    End Enum

    Public Enum EstadoTarea
        NoDefinido = 0
        Procesada = 1
        EnProceso = 2
        ConError = 3
    End Enum
End Namespace

