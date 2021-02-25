package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.MERDetalle;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDocs;
import com.amesol.routelite.presentadores.interfaces.ICapturaMercadeo;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
import com.amesol.routelite.presentadores.interfaces.ISeleccionMercadeo;

import java.util.ArrayList;
import java.util.HashMap;

public class SeleccionarMercadeo extends Presentador {
    ISeleccionMercadeo mVista;
    String mAccion;
    Vendedor oVendedor;
    ISetDatos sdMercadeo;
    String clienteClave;
    String diaClave;
    String visitaClave;

    public SeleccionarMercadeo(ISeleccionMercadeo vista, String accion)
    {
        mVista = vista;
        mAccion = accion;
    }

    @Override
    public void iniciar()
    {
        try
        {
            Cliente cliente = (Cliente) Sesion.get(Sesion.Campo.ClienteActual);

            Dia dia = (Dia) Sesion.get(Sesion.Campo.DiaActual);
            Visita visita = (Visita) Sesion.get(Sesion.Campo.VisitaActual);

            mVista.setCliente(cliente.Clave + " - " + cliente.RazonSocial);
            mVista.setRuta(((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Descripcion);
            mVista.setDia(((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);

            diaClave = dia.DiaClave;
            clienteClave = cliente.ClienteClave;
            visitaClave = visita.VisitaClave;

            refrescarMERDetalle();
        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }

    }

    public void refrescarMERDetalle()
    {
        try
        {
            sdMercadeo =Consultas.ConsultasMercadeo.recuperarMERDetalleNavegacion(visitaClave, diaClave);

            if (sdMercadeo.getCount() > 0)
                mVista.mostrarMercadeoCliente(sdMercadeo);
            else
            {
                // mVista.finalizar();
                generarMERDetalle();
            }
        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }
    }

    public void generarMERDetalle()
    {
        try
        {
            mVista.iniciarActividadConResultado(ICapturaMercadeo.class, 0, Enumeradores.Acciones.ACCION_GENERAR_MERDETALLE);
        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }

    };

    public void modificarMERDetalle(String MRDId){
        try
        {
            HashMap<String, String> oParametros = new HashMap<String, String>();
            oParametros.put("MRDId", MRDId);
            mVista.iniciarActividadConResultado(ICapturaMercadeo.class, 0, Enumeradores.Acciones.ACCION_MODIFICAR_MERDETALLE, oParametros);
        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
    }

    public boolean eliminarMERDetalle(String MRDId)
    {
        try
        {
            MERDetalle oMRD = new MERDetalle();
            oMRD.MRDId = MRDId;
            BDVend.recuperar(oMRD);
            if (oMRD.isRecuperado()){
                BDVend.eliminar(oMRD);
            }
            BDVend.commit();
            return true;
        }

        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
            e.printStackTrace();
            return false;
        }

    }

    public boolean existenAbonos()
    {
        if (sdMercadeo != null && sdMercadeo.getCount() > 0)
            return true;
        return false;
    }
}
