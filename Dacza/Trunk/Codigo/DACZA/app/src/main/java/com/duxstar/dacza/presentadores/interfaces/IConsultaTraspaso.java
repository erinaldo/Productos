package com.duxstar.dacza.presentadores.interfaces;

import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.Vin;
import com.duxstar.dacza.datos.basedatos.SetDatos;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.presentadores.IVista;
import com.duxstar.dacza.vistas.ConsultaTraspaso;

public interface IConsultaTraspaso extends IVista{

    public void refrescarProductos(ConsultaTraspaso.ListaTRPDetalle[] detalles);

    public void setFolio(String folio);
    public void setFecha(String fecha);
    public void setFolioRecarga(String folio);
}
