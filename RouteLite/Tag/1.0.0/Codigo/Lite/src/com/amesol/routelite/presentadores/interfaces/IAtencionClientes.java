package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.IVista;

public interface IAtencionClientes extends IVista {	

	void mostrarClientes(ISetDatos clientes, int vista);	
	String getCliente();
	void HabilitarPantalla(Boolean Habilitado);
	void mostrarMensajeEiniciarActividad(String mensaje, Class <?> actividad);
	void reiniciarPantalla();
	void habilitaDeshabilitaCodigoBarras(boolean habilitado);
	
}
