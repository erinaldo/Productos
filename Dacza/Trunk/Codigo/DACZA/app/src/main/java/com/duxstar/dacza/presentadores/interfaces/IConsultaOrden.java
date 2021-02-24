package com.duxstar.dacza.presentadores.interfaces;

import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.Vin;
import com.duxstar.dacza.presentadores.IVista;

public interface IConsultaOrden extends IVista{
	
	public void setCliente(Cliente oCliente);
    public void setAgente(Usuario oAgente);
    public void setVin(Vin oVin, Articulo articulo);

    public void refrescarProductos();

    public void setFolio(String folio);
    public void setFecha(String fecha);
    public void setObservacion(String observacion);

}
