package com.duxstar.dacza.presentadores.interfaces;

import java.util.List;
import java.util.Map;

import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.presentadores.IVista;

public interface IConsultaCliente extends IVista {
	void mostrarDatosCliente(List<Map<String,String>> datosCliente);
}
