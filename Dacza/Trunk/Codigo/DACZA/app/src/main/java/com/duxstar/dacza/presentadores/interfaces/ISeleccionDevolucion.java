package com.duxstar.dacza.presentadores.interfaces;

import com.duxstar.dacza.presentadores.IVista;
import com.duxstar.dacza.presentadores.act.SeleccionarDevolucion;

public interface ISeleccionDevolucion extends IVista
{

	void mostrarDevoluciones(SeleccionarDevolucion.VistaDevoluciones[] devoluciones);
    void actualizarTitulo();

    //SeleccionarRecarga.VistaRecargas[] obtenerRecargas();

	//String getDescripcionFase(int TipoFase);

	public void mostrarMensajeEiniciarActividad(String mensaje, Class<?> actividad);

    //public void actualizarVista();
}
