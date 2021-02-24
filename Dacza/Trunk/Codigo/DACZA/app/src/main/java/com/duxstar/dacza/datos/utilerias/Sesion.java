package com.duxstar.dacza.datos.utilerias;

import java.util.Hashtable;

public class Sesion
{

	private static Hashtable<String, Object> datos = new Hashtable<String, Object>();

	public enum Campo
	{
        TallerActual,
		UsuarioActual,
        ConfiguracionLocal,
        ExistenPuertosConfigurados,
        ModeloDispositivo,
        TipoCodigoActual,
        AgenteActual,
		ClienteActual,
		VinActual,
        Kilometraje,
        OrdenTrabajoActual,
        ArticuloActual,
        ArticuloDescActual,
        ResultadoActividad,
        RecargaActual,
        DevolucionActual,
        SiguientePartida,
        VistaOrdenesActual,
        VistaRecargasActual,
        VistaDevolucionesActual,
        IdDocumentoEnviar,
        PermitirRecibir,
        TituloFoto,
        FiltroCliente,
        Observaciones
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
