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
		FechaMaximaEntrega
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
