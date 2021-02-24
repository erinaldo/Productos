package com.duxstar.dacza.presentadores.interfaces;

import android.database.Cursor;

import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.OrdenTrabajo;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.Vin;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.presentadores.IVista;

public interface  ICapturaOrden extends IVista {
	//public void presentarProductos(String accion,Cursor datosProductos) throws Exception;
	
	//void setListaPrecios(String valor);
	void setHuboCambios(boolean cambio);
	
	//void refrescarProductos(String TransProdId);
	//void mostrarUnidades(ISetDatos unidades);
	//void seleccionarProducto(String ProductoClave, String TipoUnidad);
	
	public void setClienteActual(Cliente oCliente);
    public void setAgenteActual(Usuario oAgente);
    public void setVinActual(Vin oVin, Articulo articulo);
    public void setVinActual(Vin oVin, Articulo articulo, OrdenTrabajo ordenTrabajo);

    public void setFolio(String folio);
    public void setFecha(String fecha);

	public void setSoloLectura(boolean soloLectura); 
	public void setEsNuevo(boolean esNuevo);
	public void setCapturaEnabled(boolean enabled);

    public float getKilometrajeActual();
}
