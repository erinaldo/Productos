package com.duxstar.dacza.presentadores.interfaces;

import com.duxstar.dacza.presentadores.IVista;
import com.duxstar.dacza.presentadores.act.SeleccionarRecarga;

public interface ISeleccionRecarga extends IVista
{

	void mostrarRecargas(SeleccionarRecarga.VistaRecargas[] recargas);
    void actualizarTitulo();

    //SeleccionarRecarga.VistaRecargas[] obtenerRecargas();

	//String getDescripcionFase(int TipoFase);

	public void mostrarMensajeEiniciarActividad(String mensaje, Class<?> actividad);

    //public void actualizarVista();
}
