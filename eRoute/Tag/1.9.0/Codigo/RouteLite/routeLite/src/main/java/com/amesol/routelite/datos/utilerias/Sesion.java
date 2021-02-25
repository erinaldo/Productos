package com.amesol.routelite.datos.utilerias;

import java.util.Hashtable;

;

public class Sesion
{

	private static Hashtable<String, Object> datos = new Hashtable<String, Object>();

	public enum Campo
	{
		UsuarioActual,
		ClienteActual,
		VendedorActual,
		DiaActual,
		RutaActual,
		CONHist,
		MOTConfiguracion,
		TipoModulo,
		ConfiguracionLocal,
		ModuloMovDetalleClave,
		TipoIndiceModuloMovDetalleClave,
		VisitaActual,
		ArrayTransProd,
		ResultadoActividad,
		ExistenPuertosConfigurados,
		Folio,
		MovSinVisita,
		MovConVisita,
		Devoluciones,
		ExcepcionFreq,
		FechaMinimaEntrega,
		FechaMaximaEntrega,
		TotalInicialCredito,
		VistaConsignacion,
		TransProd,
		ArchivosGenerados,
		VistaAtualClientes, 
		FoliosFiscales,
		ConfigParametro,
		SolicitarContrasenaDevolucionAlmacen, //variable para validar contraseña en devoulciones al almacen y descargar
		SolicitarContrasenaDescarga,
        UsuarioSustitutoPendiente,
        ObjUsuarioSustitutoPendiente,
        ModeloDispositivo,
        MensajeEntrePantalla,
        FiltroReporteCliente,
        FiltroReporteFechas,
        FiltroReporteFechaIni,
        FiltroReporteFechaFin,
        FiltroReporteDiaClave,
        Envio_Mov_Sin_Inv_Sin_Visita,
        FiltroVarioDetallado,
        FiltroVarioGeneral,
        FiltroVarioTotalProductosPrecio,
        FiltroVarioTotalizar,
        FiltroVarioDevoluciones,
        FiltroVarioCambios,
        tipoEnvioInformacion,
        RenglonVacioAntesTexto,
        VerificarUsuarioSustitutoPrevio,
        CambioLPTpdExtra,
        LPTpdExtra
	}

	public static Object get(Campo campo)
	{
		return datos.get(campo.toString());
	}

	public static void set(Campo campo, Object valor)
	{
		datos.put(campo.toString(), valor);
	}

	public static void remove(Campo campo)
	{
		datos.remove(campo.toString());
	}
}
