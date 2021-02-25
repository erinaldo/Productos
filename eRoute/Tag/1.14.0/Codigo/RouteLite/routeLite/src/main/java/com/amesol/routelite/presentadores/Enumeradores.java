package com.amesol.routelite.presentadores;

public final class Enumeradores
{

	public final class Resultados
	{
		public final static int RESULTADO_MAL = 0;
		public final static int RESULTADO_BIEN = 1;
		public final static int RESULTADO_TERMINAR = 2;
	}

	public final class TipoBD
	{
		public final static int BD_TERMINAL = 0;
		public final static int BD_VENDEDOR = 1;
	}

	public final class TipoEnvioInfo
	{
		public final static int ENVIO_JORNADA = 0;
		public final static int ENVIO_PARCIAL = 1;
		public final static int ENVIO_PENDIENTES_VENDEDOR=2;
        public final static int ENVIO_MOV_SIN_INV_SIN_VISITA=3;
	}

	public final class Solicitudes
	{
		public final static int SOLICITUD_SERVIDOR_COMUNICACIONES = 0;
		public final static int SOLICITUD_CONFIGURACION = 1;
		public final static int SOLICITUD_AGENDA = 2;
		public static final int SOLICITUD_RECIBIR = 3;
		public static final int SOLICITUD_ATENDER_CLIENTES = 4;
		public static final int SOLICITUD_GPS = 5;
		public static final int SOLICITUD_AUTORIZARMOVIMIENTO = 6;
		public static final int SOLICITUD_BUSQUEDA_PRODUCTOS = 7;
		public static final int SOLICITUD_MOSTRAR_PROMOCIONES_APLICADAS = 8;
		public static final int SOLICITUD_MOSTRAR_TOTALES = 9;
		public static final int SOLICITUD_MOSTRAR_CAPTURA_PEDIDO = 10;
		public static final int SOLICITUD_MOSTRAR_CANCELAR_PEDIDO = 11;
		public static final int SOLICITUD_ABONO_DETALLE = 12;
		public static final int SOLICITUD_CAMBIOS_PRODUCTO_ENTRADA = 13;
		public static final int SOLICITUD_CAMBIAR_PRODUCTO_SALIDA = 14;
		public static final int SOLICITUD_MOSTRAR_PEDIDO_SUGERIDO = 15;
		public final static int SOLICITUD_SERVIDOR_COMUNICACIONES_ENVIO_PARCIAL = 16;
		public static final int SOLICITUD_ELIMINAR_AJUSTE_INV = 17;
		public static final int SOLICITUD_ELIMINAR_DESCARGA_INV = 18;
		public static final int SOLICITUD_ELIMINAR_DEV_ALMACEN = 19;
		public static final int SOLICITUD_MOSTRAR_TOTALES_CONSIGNACION = 20;
		public static final int SOLICITUD_LIQUIDAR_CONSIGNACION = 21;
		public static final int SOLICITUD_SELECCIONAR_ESQUEMAS_PRODUCTO = 22;
        public static final int SOLICITUD_PARAMETRO_NOFECHAFINAGENDA = 23;
        public static final int SOLICITUD_TOMAR_INVENTARIO_PEDIDO = 24;
		public static final int SOLICITUD_CONFIGURACION_NFC = 25;
        public static final int SOLICITUD_CAPTURAR_FIRMA = 26;
		public static final int SOLICITUD_PARAMETRO_LIMPIARCLAVEACCESO = 27;
        public static final int SOLICITUD_ENVIAR_PDF = 28;
        public static final int SOLICITUD_ENVIAR_PDF_SERVER = 29;
        public static final int SOLICITUD_ENVIAR_SMS = 30;
        public static final int SOLICITUD_PARAMETRO_FECHAINICIALAGENDANOMENOR = 31;
        public static final int SOLICITUD_MOSTRAR_ESTADISTICAS = 32;
		public static final int SOLICITUD_CAPTURAR_MONTO_POR_DOC_COBRANZA = 33;
        public static final int SOLICITUD_ELIMINAR_CANJE = 34;
	}

	public final class Acciones
	{
		public final static String ACCION_AGENDA_VENDEDOR = "AGVEN";
		public final static String ACCION_CONFIGURAR_PUERTOS = "CONFPUER";
		public final static String ACCION_OBTENER_BD_TERMINAL = "OBDT";
		public final static String ACCION_OBTENER_BD_VENDEDOR = "OBDV";
		public static final String ACCION_ENVIAR_BD_VENDEDOR = "EBDV";
		public final static String ACCION_RECIBIR_INFO_TERMINAL = "REINFTE";
		public final static String ACCION_RECIBIR_INFO_VENDEDOR = "REINFVE";
		public final static String ACCION_RECIBIR_INFO_INVENTARIO = "REINFIN";
        public final static String ACCION_RECIBIR_INFO_CONFIRMACIONPEDIDO = "REINFCONPED";
		public final static String ACCION_RECIBIR_INFO_DOCUMENTO = "REINFDOCTO";
		public final static String ACCION_RECIBIR_INFO_TIMBRADO_CDFIs = "REINFTIMCFDI";
		public final static String ACCION_ATENDER_CLIENTES_DIA = "ACDIA";
		public final static String ACCION_ATENDER_CLIENTES_RUTA = "ACRUTA";
		public final static String ACCION_ATENDER_CLIENTES_CLIENTE = "ACCLI";
		public final static String ACCION_CONSULTAR_CLIENTE = "CONCLI";
		public final static String ACCION_IMPRIMIR_TICKET_CON_VISITA = "ITCV";
		public final static String ACCION_IMPRIMIR_TICKET_SIN_VISITA = "ITSV";
		public final static String ACCION_VISITAR_CLIENTE_CLIENTE = "VISCLI";
		public final static String ACCION_VISITAR_CLIENTE_VISITA = "VCVIS";
		public final static String ACCION_AUTORIZAR_MOVIMIENTO = "AUMOV";
		public final static String ACCION_NO_VISITAR_CLIENTE = "NOVISCLI";
		public final static String ACCION_NO_VENTA = "NOVISI";
		public final static String ACCION_OBTENER_GPS = "OBTGPS";
		public final static String ACCION_OBTENER_PRODUCTOS_SELECCIONADOS = "OBTPRO";
        public final static String ACCION_OBTENER_BUSQUEDA_SIMPLE= "BUSSIM";
		public final static String ACCION_APLICAR_PROMOCIONES = "APLPRO";
		public final static String ACCION_APLICAR_TOTALES = "APLTOT";
		public final static String ACCION_MOSTRAR_SOLO_LECTURA = "MOSSOL";
		public final static String ACCION_CANCELAR_PEDIDO = "CANPED";
		public final static String ACCION_SELECCIONAR_COBRANZA = "SELCOB";
		public final static String ACCION_CONSULTAR_COBRANZA = "CONCOB";
		public final static String ACCION_GENERAR_COBRANZA = "GENCOB";
		public final static String ACCION_CANCELAR_COBRANZA = "CANCOB";
		public final static String ACCION_RECIBIR_PENDIENTES = "REINFPE";
		public final static String ACCION_MOSTRAR_PEDIDOS = "MOSPED";
		public final static String ACCION_MOSTRAR_CAMBIOS = "MOSCAM";
		public final static String ACCION_MOSTRAR_DEVOLUCIONES = "MOSDEV";
		public final static String ACCION_CAMBIOS_PRODUCTO_ENTRADA = "CAMENT";
		public final static String ACCION_CAMBIAR_PRODUCTO_SALIDA = "CAMSAL";
		public final static String ACCION_CAPTURAR_SUGERIDO = "CAPSUG";
		public final static String ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO = "CAPMSI";
		public final static String ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO_RUTA = "CAPMSIR";
		public final static String ACCION_CAPTURAR_AJUSTES = "CAI";
		public final static String ACCION_CAPTURAR_AJUSTES_RUTA = "CAIR";
		public final static String ACCION_CAPTURAR_DESCARGA = "CDI";
		public final static String ACCION_CAPTURAR_DESCARGA_RUTA = "CDIR";
		public final static String ACCION_CAPTURAR_DEPOSITO = "CDE";
		public final static String ACCION_CAPTURAR_DEPOSITO_RUTA = "CDER";
		public final static String ACCION_CAPTURAR_DEVOLUCION = "CDEV";
		public final static String ACCION_CAPTURAR_DEVOLUCION_RUTA = "CDEVR";
		public final static String ACCION_CAPTURAR_CARGAS = "CCAD";
		public final static String ACCION_CAPTURAR_CARGAS_RUTA = "CCAR";
		public final static String ACCION_CAPTURAR_CARGAS_NO_MODIFICAR = "CCADN";
		public final static String ACCION_CAPTURAR_CARGAS_ELIMINAR = "CCADE";
		public final static String ACCION_MOSTRAR_PEDIDOS_POR_SURTIR = "MOSPEDPS";
		public final static String ACCION_CAPTURAR_MOV_SIN_INV_EN_VISITA = "CAPMSIVIS";
		public final static String ACCION_MOSTRAR_MOV_SIN_INV_EN_VISITA = "MOSMSIVIS";
		public final static String ACCION_MOSTRAR_CONSIGNACIONES = "MOSCON";
		public final static String ACCION_CAPTURAR_CONSIGNACIONES = "CAPCONSIG";
		public static final String ACCION_ELIMINAR_CONSIGNACIONES = "ELIMCONS";
		public static final String ACCION_LIQUIDAR_CONSIGNACION = "LIQCONS";
		public static final String ACCION_MOSTRAR_FACTURAS = "MOSFAC";
		public static final String ACCION_CAPTURAR_TRASPASO = "CAPTRASP";
		public static final String ACCION_CAPTURAR_TRASPASO_RUTA = "CAPTRASPRUT";
		public static final String ACCION_MOSTRAR_ENCUESTAS = "MOSENC";
		public static final String ACCION_SELECCIONAR_ESQUEMAS_PRODUCTO = "SELESQPRO";
        public static final String ACCION_MODIFICAR_CONTRASENA_USUARIO="MODCONTUSU";
        public static final String ACCION_OBTENER_NOFECHAFINAGENDA="OBTNOFEFIN";
        public static final String ACCION_ENVIAR_MOV_SIN_INV_SIN_VISITA="EMSISV";
        public static final String ACCION_TOMAR_INVENTARIO_PEDIDO = "TOMINV";
        public static final String ACCION_MOSTRAR_MERCADEO = "MOSMERC";
        public static final String ACCION_GENERAR_MERDETALLE = "GENMERDET";
        public static final String ACCION_MODIFICAR_MERDETALLE = "MODMERDET";
        public static final String ACCION_CAPTURAR_FIRMA = "CAPFIRMA";
        public static final String ACCION_MOSTRAR_SOLICITUDES = "MOSSOL";
		public static final String ACCION_LIMPIAR_CLAVEACCESO="LIMPCLAVACC";
        public static final String ACCION_ENVIAR_ARCHIVO_PDF = "EAPDF";
		public final static String ACCION_CAPTURAR_DEPOSITO_VINCULADO = "CDV";
		public final static String ACCION_CAPTURAR_DEPOSITO_VINCULADO_RUTA = "CDVR";
        public static final String ACCION_OBTENER_FECHAINICIALAGENDANOMENOR="OBTFECINIAGENOMEN";
        public static final String ACCION_MOSTRAR_HISTORICOVENTAS="MOSHISVEN";
		public static final String ACCION_CANCELAR_MOVS_ENVIADOS = "CANCMOVSENV";
        public static final String ACCION_MOSTRAR_ESTADISTICAS = "MOSEST";
        public static final String ACCION_CONSULTAR_ESTADO_CUENTA = "CONSEDOCTA";
		public static final String ACCION_MOSTRAR_GASTOS = "MOSGAS";
		public static final String ACCION_MOSTRAR_GASTOS_RUTAS = "MOSGASRUT";
		public static final String ACCION_CAPTURA_MONTO_POR_DOC_COBRANZA = "CAPMONDOCCOB";
        public static final String ACCION_CAPTURA_CANJE = "CAPTCANJE";
        public static final String ACCION_MOSTRAR_ACTIVOS = "MOSACT";
	}

	public enum RespuestaMsg
	{
		Si, No, OK
	}

	public final class VistaClientes
	{
		public final static int VISTA_CLIENTES_VISITADOS = 0;
		public final static int VISTA_CLIENTES_NO_VISITADOS = 1;
		public final static int VISTA_CLIENTES_FUERA_FRECUENCIA = 2;
		public final static int VISTA_CLIENTES_TODOS = 3;
		public final static int VISTA_CLIENTES_CON_MENSAJE = 4;
		public final static int VISTA_CLIENTES_CON_COBRANZA = 5;
		public final static int VISTA_CLIENTES_IMPRODUCTIVOS = 6;
		public final static int VISTA_CLIENTES_NUEVOS = 7;
		public final static int VISTA_CLIENTES_POR_SURTIR = 8;
		public final static int VISTA_CLIENTES_NO_VISITADOS_REC = 9;
	}

	public final class TiposModulos
	{
		public final static int NO_DEFINIDO = 0;
		public final static int VENTA = 1;
		public final static int PREVENTA = 2;
		public final static int REPARTO = 3;
	}

	public final class TiposTransProd
	{
		public final static int NO_DEFINIDO = 0;
		public final static int PEDIDO = 1;
		public final static int CARGAS = 2;
		public final static int DEVOLUCIONES_CLIENTE = 3;
		public final static int DEVOLUCIONES_MANUALES = 4;
        public final static int CANJES = 5;
		public final static int AJUSTES = 6;
		public final static int DESCARGAS = 7;
		public final static int CAMBIOS = 9;
		public final static int FONDO_CRISTAL = 18;
		public final static int MOV_SIN_INV_SV = 19;
		public final static int MOV_SIN_INV_EV = 21;
		public final static int INVENTARIO_A_BORDO = 23;
		public final static int VENTA_CONSIGNACION = 24;
	}

	/*
	 * Cancelado
	 * 
	 * '''<comentarios/> Captura
	 * 
	 * '''<comentarios/> Surtido
	 * 
	 * '''<comentarios/> Facturado
	 * 
	 * '''<comentarios/> Impreso
	 * 
	 * '''<comentarios/> Transferir
	 * 
	 * '''<comentarios/> Liquidado
	 * 
	 * '''<comentarios/> CapturaEscritorio
	 * 
	 * '''<comentarios/> CaneladaLiquidacion
	 */
	public final class TiposFasesDocto
	{
		public final static int CANCELADO = 0;
		public final static int CAPTURA = 1;
		public final static int SURTIDO = 2;
		public final static int FACTURADO = 3;
		public final static int IMPRESO = 4;
		public final static int TRANSFERIR = 5;
		public final static int LIQUIDADO = 6;
		public final static int CAPTURA_ESCRITORIO = 7;
		public final static int CANCELADA_LIQUIDACION = 8;
        public final static int CONFIRMADO_POR_EL_VENDEDOR = 11;
        public final static int CONFIRMADO_SAP = 12;
		public final static int PENDIENTE_CONFIRMAR = 15;
	}

	public final class TiposModuloMovDetalle
	{
		public final static int NO_DEFINIDO = 0;
		public final static int NO_VENTA = 1;
        public final static int SOLICITUDES = 2;
        public final static int ACTIVOS = 4;
		public final static int PAGOS = 6;
		public final static int DEVOLUCIONMANUALES = 8;
		public final static int PEDIDO = 9;
		public final static int CARGAS = 10;
		public final static int AJUSTES = 11;
        public final static int HISTORICOVENTAS = 12;
		public final static int DEVOLUCIONCLIENTES = 13;
		public final static int CAMBIOS = 14;
        public final static int DESCARGAS = 15;
        public final static int CANJES = 16;
        public final static int MERCADEO = 19;
		public final static int MOV_SIN_INV_CON_VISITA = 22;
		public final static int MOV_SIN_INV_SIN_VISITA = 23;
		public static final int FACTURACION = 25;
        public final static int CONSIGNACION = 26;
		public final static int ENCUESTAS = 27;
        public final static int IMPRESION = 28;
        public final static int COBRANZAMULTIPLE = 30;
		public final static int CANCELACION_MOV_ENVIADOS = 33;


		// public final static int NO_DEFINIDO = 0;
		// public final static int PEDIDO = 9;
		// public final static int DEVOLUCIONCLIENTES = 13;
		// public final static int CAMBIOS = 14;
		// public final static int IMPRESION = 0;
		// public final static int COBRANZAMULTIPLE = 30;
	}

	public final class TiposMovimientos
	{
		public final static int NO_DEFINIDO = 0;
		public final static int ENTRADA = 1;
		public final static int SALIDA = 2;
		public final static int PEDIDO = 3;
	}

	public final class FormasDeVenta
	{
		public final static int CONTADO = 1;
		public final static int CREDITO = 2;
	}

	public final class FormasDePago
	{
		public final static int EFECTIVO = 1;
		public final static int CHEQUE = 2;
		public final static int OTRO = 3;
		public final static int NO_IDENTIFICADO = 4;
	}

	public final class ACTROL
	{
        public final static int DATOS_DEL_VENDEDOR = 12;
		public final static int CONSULTA_INVENTARIO = 14;
		public final static int MOV_SIN_INV_SIN_VISITA = 15;
		public final static int AJUSTES = 16;
		public final static int DESCARGAS = 17;
		public final static int RECARGAS = 18;
		public final static int DEVOLUCIONESALMACEN = 24;
		public final static int CARGAS = 25;
		public final static int TRASPASO_INVENTARIO = 26;
        public final static int ACTUALIZAR_PRECIOS = 30;
		public final static int GASTOSVENDEDOR = 34;
        public final static int COBRANZA = 35;
	}

    public final class ACTMAC
    {
        public final static int VISTAS = 1;
        public final static int BUSCAR = 2;
        public final static int MIS_CUOTAS = 3;
        public final static int ENVIO_PARCIAL = 4;
        public final static int TIEMPOS_MUERTOS = 5;
        public final static int MIS_PENDIENTES= 6;
        public final static int NUEVO_CLIENTE = 7;
        public final static int PEDIDOS_PAGO_ANTICIPADO = 8;
		public final static int IMPRIMIR_CLIENTES = 9;
    }

	public final class TipoFecha{
		public final static int DIA_EXACTO = 1;
		public final static int DIA_DE_LA_SEMANA = 2;
		public final static int DIA_MES = 3;
	}
	
	public final class TipoPedido{
		public final static int NO_DEFINIDO = 0;
		public final static int NORMAL = 1;
		public final static int POSFECHADO = 2;
		public final static int ESTIMADO = 3;
		public final static int CONSIGNACION = 4;
	}

    public final class PROTipo{
        public final static int LINEA = 1;
        public final static int CANJE = 2;
        public final static int LINEA_CANJE = 3;
        public final static int PLACA = 4;
        public final static int CHAROLA = 5;
        public final static int NOTACREDITO = 6;
    }

	public final class TipoPermiso{
		public final static int NO_DEFINIDO = 0;
		public final static int ACCESAR = 1;
		public final static int CREAR = 2;
		public final static int MODIFICAR = 3;
		public final static int ELIMINAR = 4;
	}

    public final class ACTSMLO{
        public final static int USUARIO_SUSTITUTO = 1;
        public final static int MODIFICAR_CONTRASEÑA = 2;
        public final static int CONFIGURACION = 3;
        public final static int RECIBIR = 4;
        public final static int SALIR = 5;
    }

    public final class REPORTEA{
        public final static int COBRANZA_GONAC = 6;
        public final static int PEDIDOS_CONFIRMADOS_SAP = 11;
        public final static int COBRANZA_GENERICO = 7;
        public final static int EFECTIVIDAD_RUTA = 9;
        public final static int RESUMEN_MOV_MASIVO_COSTENA = 12;
        public final static int RESUMEN_MOVIMIENTOS_GENERICO = 14;
        public final static int RESUMEN_COBRANZA_GENERICO = 19;
        public final static int PREPEDIDO = 21;
        public final static int INVENTARIO_GENERICO = 15;
	    public final static int CARGAS_GENERICO = 16;
		public final static int SALDO_CLIENTE_ENVASE = 18;
		public final static int RECOLECCION_ENVASE = 22;
        public final static int VENTAS=13;
        public final static int VENTAS_NOMBRE_CORTO=23;
        public final static int PRE_LIQUIDACION=25;
        public final static int DEVOLUCIONES_CAMBIOS=24;
        public final static int SALDO_CLIENTE_EFECTIVO=17;
        public final static int MOVIMIENTOS_SIN_INVENTARIO_SIN_VISITA=20;
		public final static int DESCARGAS_DEVOLUCIONES_ALMACEN = 27;
        public final static int GENERAL_PROMOCIONES = 26;
        public final static int ESTATUS_PEDIDOS_SAP = 28;
        public final static int ESTADO_DE_CUENTA = 29;
        public final static int VISTA_DOCS_COBRANZA = 30;
        public final static int EXTALMBORDO = 32;
        public final static int VTAPRODUCTOYMOVENVASE = 33;
    }
    public final class BFNUMERI{
        public final static int IGUAL = 1;
        public final static int DIFERENTE = 2;
        public final static int MAYOR_QUE = 3;
        public final static int MENOR_QUE = 4;
        public final static int MAYOR_IGUAL_QUE = 5;
        public final static int MENOR_IGUAL_QUE = 6;
        public final static int ENTRE = 7;
    }

    public final class TIPOCOB{
        public final static int FACTURAS = 0;
        public final static int VENTAS = 1;
        public final static int AMBAS = 2;
    }

    public final class DOCFISC{
        public final static int NOTA_VENTA = 1;
        public final static int FACTURA = 2;
    }

    public final class TipoAseguramiento {
        public final static int NINGUNO = 0;
        public final static int COD_BARRAS = 1;
        public final static int GPS = 2;
        public final static int AMBOS = 3;
        public final static int COD_BARRAS_INI_FIN = 4;
        public final static int COD_BARRAS_INI_FIN_GPS = 5;
        public final static int NFC_INI_FIN = 6;
        public final static int COD_BARRAS_NFC_INI_FIN = 7;
    }

    public final class TTICKET {
        public final static int PEDIDO_IBA = 12;
        public final static int PEDIDO_COS = 15;
        public final static int PEDIDO_AYA = 24;
		public final static int PEDIDO_RIP = 17;
    }

    public final class TipoArchivoZip
    {
        public final static int ENCUESTA = 1;
        public final static int FIRMA = 2;
        public final static int TICKET_PDF = 3;
        public final static int IMPRODUCTIVIDAD = 4;
    }
}
