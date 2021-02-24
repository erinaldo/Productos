package com.duxstar.dacza.presentadores.interfaces;

import com.duxstar.dacza.presentadores.IVista;
import com.duxstar.dacza.presentadores.act.SeleccionarOrden;

public interface ISeleccionOrden extends IVista
{

	void mostrarOrdenesCliente(SeleccionarOrden.VistaOrdenes[] ordenes);
    void actualizarTitulo();
	//SeleccionarOrden.VistaOrdenes[] obtenerOrdenes();

	//String getDescripcionFase(int TipoFase);

	public void mostrarMensajeEiniciarActividad(String mensaje, Class<?> actividad);

	//public void actualizarVista();
}
