package com.duxstar.dacza.presentadores.act;

import com.duxstar.dacza.actividades.OrdenesTrabajo;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.OrdenTrabajo;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.Vin;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.IConsultaOrden;

import java.text.SimpleDateFormat;

/**
 * Created by Adriana on 09/06/2016.
 */
public class ConsultarOrden extends Presentador {
    IConsultaOrden mVista;
    String mAccion;
    String sOrdenId;

    OrdenTrabajo ordenTrabajo;

    public ConsultarOrden(IConsultaOrden vista)
    {
        mVista = vista;
    }

    public ConsultarOrden(IConsultaOrden vista, String accion)
    {
        mVista = vista;
        mAccion = accion;
    }

    @Override
    public void iniciar()
    {
        try
        {
            mVista.iniciar();

            ordenTrabajo = OrdenesTrabajo.recuperarOrdenConDetalle(sOrdenId);

            Usuario usuario = Consultas.ConsultasUsuario.obtenerUsuarioPorId(ordenTrabajo.AgenteId);
            Cliente cliente = Consultas.ConsultasCliente.obtenerClientePorId(ordenTrabajo.ClienteId);
            Vin vin = Consultas.ConsultasVin.obtenerVinPorId(ordenTrabajo.VinId);
            Articulo articulo = new Articulo();
            articulo.ArticuloId = vin.ArticuloId;
            BDTerm.recuperar(articulo);

            mVista.setFolio(ordenTrabajo.Folio);
            mVista.setFecha(new SimpleDateFormat("dd/MM/yyyy").format(ordenTrabajo.FechaIni));

            mVista.setCliente(cliente);
            mVista.setAgente(usuario);
            mVista.setVin(vin, articulo);
            mVista.setObservacion(ordenTrabajo.Observacion);

            mVista.refrescarProductos();


        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }
    }

    public void setOrdenId(String ordenId){
        sOrdenId = ordenId;
    }

    public OrdenTrabajo getOrdenTrabajo()
    {
        return ordenTrabajo;
    }
}
