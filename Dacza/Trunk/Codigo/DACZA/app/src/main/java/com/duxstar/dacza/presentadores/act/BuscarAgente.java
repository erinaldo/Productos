package com.duxstar.dacza.presentadores.act;
import android.app.Activity;
import android.content.Intent;
import android.location.Location;
import android.text.SpannableStringBuilder;
import android.text.style.RelativeSizeSpan;
import android.view.Gravity;
import android.widget.Toast;

import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.IBuscaAgente;

import java.util.ArrayList;
import java.util.HashMap;

public class BuscarAgente extends Presentador {

    IBuscaAgente mVista;
    String mAccion;
    String mFiltro;
    HashMap<String, Object> oParametros;

    public BuscarAgente(IBuscaAgente vista, String accion, String filtro) {
        this.mVista = vista;
        this.mAccion = accion;
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
                mostrarAgentes(mFiltro);
            else {
                mostrarAgentes(null);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void mostrarAgentes(String filtro) {
        ISetDatos agentes = null;
        try
        {
            agentes = Consultas.ConsultasUsuario.obtenerTodos(filtro);
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
        if (agentes != null) {
            mVista.mostrarAgentes(agentes);
        }
    }

    private void seleccionar(int Codigoleido) {

        //ReiniciarParametrosHash();
        //oParametros.put("CodigoLeido", Codigoleido);

        try {
            Usuario agente = new Usuario();
            agente = Consultas.ConsultasUsuario.obtenerUsuario(mVista.getAgente());

            Sesion.set(Campo.AgenteActual, agente);

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
