package com.amesol.routelite.presentadores.interfaces;

import java.util.ArrayList;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.presentadores.IVista;

public interface ISeleccionCobranza extends IVista {
	
	void mostrarCobranzaCliente(ArrayList<Cobranza.VistaCobranza> oAbonos);
	void setCliente(String cliente);
	void setRuta(String ruta);
	void setDia(String dia);
	
}
