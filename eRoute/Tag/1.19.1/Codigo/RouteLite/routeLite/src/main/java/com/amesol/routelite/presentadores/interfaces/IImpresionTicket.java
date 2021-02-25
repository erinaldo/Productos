package com.amesol.routelite.presentadores.interfaces;

import java.util.List;
import java.util.Map;

import android.database.Cursor;

import com.amesol.routelite.presentadores.IVista;

public interface IImpresionTicket extends IVista {
	void presentarDocumentos(String accion,  Cursor datosDocumentos) throws Exception;
	List<Map<String,String>> getDocumentosSeleccionados();
	void setCliente(String cliente);
	void setRuta(String ruta);
	void setDia(String dia);
}
