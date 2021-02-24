package com.duxstar.dacza.presentadores;

public final class Enumeradores
{

	public final class Resultados
	{
		public final static int RESULTADO_MAL = 0;
		public final static int RESULTADO_BIEN = 1;
		public final static int RESULTADO_TERMINAR = 2;
        public final static int RESULTADO_ENVIAR = 3;
	}

	public final class TipoEnvioInfo
	{
		public final static int ENVIO_AGENTE = 0;
        public final static int ENVIO_ORDENES = 1;
		public final static int ENVIO_INVENTARIO = 2;
        public final static int ENVIO_RECARGAS = 3;
        public final static int ENVIO_DEVOLUCIONES = 4;
        public final static int ENVIO_ORDEN = 5;
        public final static int ENVIO_ORDEN_DETALLE = 6;
        public final static int ENVIO_RECARGA = 7;
        public final static int ENVIO_DEVOLUCION = 8;
	}

	public final class Solicitudes
	{
		public final static int SOLICITUD_SERVIDOR_COMUNICACIONES = 1;
		public final static int SOLICITUD_CONFIGURACION = 2;
		public final static int SOLICITUD_AGENDA = 3;
		public final static int SOLICITUD_RECIBIR = 4;
		public final static int SOLICITUD_BUSQUEDA_CLIENTES = 5;
        public final static int SOLICITUD_BUSQUEDA_AGENTES = 6;
        public final static int SOLICITUD_BUSQUEDA_VINS = 7;
        public final static int SOLICITUD_BUSQUEDA_ARTICULOS = 8;
        public final static int SOLICITUD_CAPTURA_IMAGEN = 9;
        public final static int SOLICITUD_CAPTURA_OBSERVACIONES = 10;
    }

	public final class Acciones
	{
		public final static String ACCION_CONFIGURAR = "CONFIGURAR";
		public final static String ACCION_OBTENER_BD_TERMINAL = "OBDT";
		public final static String ACCION_ENVIAR_BD_TERMINAL = "EBDT";
		public final static String ACCION_RECIBIR_TRASPASOS = "RECTRA";
        public final static String ACCION_OBTENER_CLIENTE_SELECCIONADO = "OBTCTE";
        public final static String ACCION_OBTENER_AGENTE_SELECCIONADO = "OBTAGE";
        public final static String ACCION_OBTENER_VIN_SELECCIONADO = "OBTVIN";
        public final static String ACCION_CONSULTAR_CLIENTE = "CONSCLI";
        public final static String ACCION_OBTENER_ARTICULOS_SELECCIONADOS = "OBTART";
	}

	public enum RespuestaMsg
	{
		Si, No, OK
	}

	public final class TiposFasesDocto
	{
		public final static int CANCELADO = 0;
		public final static int CAPTURA = 1;
		public final static int CERRADO = 2;
        public final static int SURTIDO = 3;
	}

	public final class TiposMovimientos
	{
		public final static int NO_DEFINIDO = 0;
		public final static int ORDEN_TRABAJO = 1;
		public final static int RECARGA_INVENTARIO = 2;
        public final static int DEVOLUCION_INVENTARIO = 3;
	}

    public final class TiposMovimientoInv
    {
        public final static int NO_DEFINIDO = 0;
        public final static int ENTRADA = 1;
        public final static int SALIDA = 2;
        public final static int ENTRADA_APARTADO = 3;
        public final static int SALIDA_APARTADO = 4;
    }

	public final class ACTIVIDADES
	{
        public final static int ORDEN_TRABAJO = 1;
		public final static int CONSULTA_INVENTARIO = 2;
		public final static int RECARGA_INVENTARIO = 3;
		public final static int TRASPASO_INVENTARIO = 4;
	}

    public final class ACTMENU{
        public final static int CONFIGURACION = 1;
        public final static int RECIBIR = 2;
        public final static int SALIR = 3;
        public final static int ENVIO_PARCIAL = 3;
        public final static int SINCRONIZAR = 4;
        public final static int VISTAS = 5;
        public final static int VER_TRASPASO = 6;
    }

    public final class TIPOCODIGO{ //Menu AccesoSistema
        public final static int CLIENTE = 1;
        public final static int AGENTE = 2;
        public final static int VIN = 3;
        public final static int ARTICULO = 4;
    }

    public final class TipoContenidoFolio{
        public final static int ROTULO_FIJO = 1;
        public final static int INCREMENTAL_NUMERICO = 2;
    }

    public final class ACTBUSQ{
        public final static int BUSCAR = 1;
    }

    public final class Vista
    {
        public final static int VISTA_TODAS = 0;
        public final static int VISTA_CAPTURA = 1;
        public final static int VISTA_CANCELADAS = 2;
        public final static int VISTA_CERRADAS = 3;
        public final static int VISTA_NO_ENVIADAS = 4;
        public final static int VISTA_SURTIDAS = 5;
    }
}
