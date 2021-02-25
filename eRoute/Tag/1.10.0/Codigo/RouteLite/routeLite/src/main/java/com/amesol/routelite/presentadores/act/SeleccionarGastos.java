package com.amesol.routelite.presentadores.act;

import android.content.Context;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Gasto;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaGastos;
import com.amesol.routelite.presentadores.interfaces.ISeleccionGastos;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.SeleccionGastos;
import com.amesol.routelite.vistas.generico.GastosAdapter;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Locale;

/**
 * Created by ldelatorre on 29/05/2017.
 */
public class SeleccionarGastos extends Presentador{

    ISeleccionGastos mVista;

    public SeleccionarGastos(ISeleccionGastos mVista) {
        this.mVista = mVista;
    }

    @Override
    public void iniciar() {

    }

    public void capturaGastos(){

        mVista.iniciarActividad(ICapturaGastos.class);
    }

    public void llenarLista(Context context){

        ISetDatos datos = null;
        try
        {
            datos = Consultas2.ConsultarGastos.obtenerGastos();
        }
        catch (Exception e)
        {
           mVista.mostrarError(e.getMessage());
        }

        if(datos != null){
            if(datos.getCount() <= 0){
                mVista.iniciarActividad(ICapturaGastos.class);
            }else {
                ArrayList<SeleccionGastos.ListaGastos> obtenerItem = obtenerItems(datos);
                GastosAdapter adaptador = new GastosAdapter(context, obtenerItem);
                mVista.llenarListaGastos(adaptador);
            }
        }

    }

    private ArrayList<SeleccionGastos.ListaGastos> obtenerItems(ISetDatos datos) {
        ArrayList<SeleccionGastos.ListaGastos> items = new ArrayList<SeleccionGastos.ListaGastos>();

        while (datos.moveToNext()){
            SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy", Locale.getDefault());
            String fecha = Mensajes.get("XFecha")+": "+format.format(datos.getDate("Fecha"));
            String concepto = Mensajes.get("XConcepto")+": "+obtenerConcepto(datos.getString("TipoConcepto"));
            double total1 = Double.parseDouble(datos.getString("Total"));
            String total = Mensajes.get("XTotal")+": $"+ Generales.getFormatoDecimal(total1, "###0.00");
            items.add(new SeleccionGastos.ListaGastos(datos.getDate("Fecha"),fecha,concepto, total));
        }

        return items;
    }

    public String obtenerConcepto(String concepto){

        String valor = "";
        try{
            valor = Consultas.ConsultasValorReferencia.obtenerDescripcion("GASTIPO",concepto);
        }catch (Exception e){
            mVista.mostrarError(e.getMessage());
        }
        return valor;
    }

    public void eliminarGasto(Date fecha){
        try {
            Gasto gastoEliminar = new Gasto();
            gastoEliminar.fecha = fecha;
            BDVend.eliminar(gastoEliminar);
            BDVend.commit();
            mVista.refrescarLista();
        } catch (Exception e) {
           mVista.mostrarError(e.getMessage());
        }
    }

}
