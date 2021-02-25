package com.amesol.routelite.presentadores.interfaces;

import java.util.List;
import java.util.Map;

import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.IVista;

public interface IConsultaCliente extends IVista {
	
	void mostrarDatosCliente(List<Map<String,String>> datosCliente, ISetDatos mensajes);
	void mostrarDatosCliente(List<Map<String,String>> datosCliente);
}
