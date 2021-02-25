package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.presentadores.IVista;

public interface IRecepcionInformacion extends IVista {

	void presentarOpciones(ValorReferencia[] valores,String grupo);
	String obtenerTablas(boolean recargas[], boolean precios[], boolean cobranza[], boolean promociones[], boolean productos[]);
}
