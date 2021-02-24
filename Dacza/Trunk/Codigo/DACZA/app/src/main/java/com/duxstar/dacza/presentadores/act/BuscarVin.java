package com.duxstar.dacza.presentadores.act;
import android.app.Activity;
import android.content.Intent;
import android.location.Location;
import android.text.SpannableStringBuilder;
import android.text.style.RelativeSizeSpan;
import android.view.Gravity;
import android.widget.Toast;

import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.Vin;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.IBuscaVin;

import java.util.ArrayList;
import java.util.HashMap;

public class BuscarVin extends Presentador {

    IBuscaVin mVista;
    String mAccion;
    String mFiltro;
    String sClienteId;


    public BuscarVin(IBuscaVin vista, String accion, String filtro) {
        this.mVista = vista;
        this.mAccion = accion;
        this.mFiltro = filtro;


    }

    public void setClienteId (String clienteId)
    {
        sClienteId = clienteId;
    }

    public void setFiltro (String filtro)
    {
        mFiltro = filtro;
    }

    /*public HashMap<String, Object> obtenerParametros() {
        return oParametros;
    }*/

    @Override
    public void iniciar() {
        try {

            Cliente cliente = (Cliente)Sesion.get(Campo.ClienteActual);
            sClienteId = cliente.ClienteId;
            mVista.iniciar();
            if ((mAccion != null) && (mAccion.equals(Intent.ACTION_SEARCH)))
                mostrarVins(mFiltro);
            else {
                mostrarVins(null);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void mostrarVins(String filtro) {
        ISetDatos vins = null;
        try
        {
            vins = Consultas.ConsultasVin.obtenerTodos(filtro, sClienteId);
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
        if (vins != null) {
            mVista.mostrarVins(vins);
        }
    }

    private void seleccionar(int Codigoleido) {
        try {
            Vin vin = null;
            vin = Consultas.ConsultasVin.obtenerVin(mVista.getVin(), sClienteId);

            Sesion.set(Campo.VinActual, vin);

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
}
