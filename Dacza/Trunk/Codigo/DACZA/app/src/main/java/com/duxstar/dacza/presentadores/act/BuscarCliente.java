package com.duxstar.dacza.presentadores.act;
import android.app.Activity;
import android.content.Intent;
import android.location.Location;
import android.text.SpannableStringBuilder;
import android.text.style.RelativeSizeSpan;
import android.view.Gravity;
import android.widget.Toast;

import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.OrdenTrabajo;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.IBuscaCliente;
import com.duxstar.dacza.presentadores.interfaces.IConsultaCliente;
import com.duxstar.dacza.vistas.CapturaOrden;

import java.util.ArrayList;
import java.util.HashMap;

public class BuscarCliente extends Presentador {

    IBuscaCliente mVista;
    String mAccion;
    String mFiltroOrig;
    String mFiltro;
    HashMap<String, Object> oParametros;

    public BuscarCliente(IBuscaCliente vista, String accion, String filtroOrig, String filtro) {
        this.mVista = vista;
        this.mAccion = accion;
        this.mFiltroOrig = filtroOrig;
        this.mFiltro = filtro;
        oParametros = new HashMap<String, Object>();

    }

    /*public void SeleccionVisita() {
        mVista.finalizar();
        mVista.iniciarActividad(ISeleccionVisita.class, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null, false, oParametros);
    }*/

    public HashMap<String, Object> obtenerParametros() {
        return oParametros;
    }

    @Override
    public void iniciar() {
        try {

            mVista.iniciar();
            if ((mAccion != null) && (mAccion.equals(Intent.ACTION_SEARCH)))
                mostrarClientes(mFiltroOrig, mFiltro);
            else {
                mostrarClientes(mFiltroOrig, null);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void mostrarClientes(String filtroOrig, String filtro) {
        ISetDatos clientes = null;
        try
        {
            clientes = Consultas.ConsultasCliente.obtenerTodos(filtroOrig, filtro);
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
        if (clientes != null) {
            mVista.mostrarClientes(clientes);
        }
    }

    private void seleccionar(int Codigoleido) {

        //ReiniciarParametrosHash();
        //oParametros.put("CodigoLeido", Codigoleido);

        try {
            Cliente cliente = new Cliente();
            cliente.ClienteId = mVista.getCliente();
            //cliente = Consultas.ConsultasCliente.obtenerCliente(mVista.getCliente());
            BDTerm.recuperar(cliente);

            if(Sesion.get(Campo.ClienteActual)!= null) {
                if (!((Cliente) Sesion.get(Campo.ClienteActual)).ClienteId.equals(cliente.ClienteId)) {
                    Sesion.remove(Campo.VinActual);
                }
            }

            Sesion.set(Campo.ClienteActual, cliente);

            mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            mVista.finalizar();

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void seleccionar() {
        // seleccionar(false);
        seleccionar(0);

    }

    public void consultarCliente()
    {
        try {
            Cliente cliente = new Cliente();
            cliente.ClienteId = mVista.getCliente(); //Consultas.ConsultasCliente.obtenerCliente(mVista.getCliente());
            BDTerm.recuperar(cliente);

            Sesion.set(Campo.ClienteActual, cliente);
            mVista.iniciarActividad(IConsultaCliente.class, Enumeradores.Acciones.ACCION_CONSULTAR_CLIENTE, null, false);
        }catch (Exception ex)
        {
            ex.printStackTrace();
        }
    }
}
