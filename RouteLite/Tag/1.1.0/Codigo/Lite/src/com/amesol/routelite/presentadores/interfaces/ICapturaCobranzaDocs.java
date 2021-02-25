package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.presentadores.IVista;

public interface ICapturaCobranzaDocs extends IVista {
		
	public void mostrarCobranzaDocs(Cobranza.VistaDocumentos[] oDocumentos);
	//public void insertTransProdId(String sTransProdId);
	//public void removeTransProdId(String sTransProdId);
	void setCliente(String cliente);
	void setRuta(String ruta);
	void setDia(String dia);
}
