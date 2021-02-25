package com.amesol.routelite.vistas;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.interfaces.IDisInformacionGeneralAlarmas;
import com.amesol.routelite.presentadores.interfaces.IDisInformacionGeneralPromociones;
import com.amesol.routelite.vistas.generico.DisDatosAdapter;
import com.amesol.routelite.vistas.generico.DisPromoAdapter;

import java.util.ArrayList;

/**
 * Created by ldelatorre on 04/03/2018.
 */
public class DisConsultaInformacionGeneralPromociones extends Vista implements IDisInformacionGeneralPromociones {
    private Context context = DisConsultaInformacionGeneralPromociones.this;
    Cliente clienteSesion;
    ListView lsInformacionPromo;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.dis_informacion_general_promociones);
        deshabilitarBarra(true);
        lblTitle.setText(Mensajes.get("XInformacionGeneral"));

        inicializar();

        TextView lblMensaje = (TextView) findViewById(R.id.lblTitulo);
        lblMensaje.setText(Mensajes.get("XPromociones"));

        lblMensaje = (TextView) findViewById(R.id.lblCliente);
        lblMensaje.setText(clienteSesion.Clave +" - "+ clienteSesion.RazonSocial);

        lblMensaje = (TextView) findViewById(R.id.txtCol1);
        lblMensaje.setText(Mensajes.get("XNombre"));

        lblMensaje = (TextView) findViewById(R.id.txtCol2);
        lblMensaje.setText(Mensajes.get("XSegmento"));

        lblMensaje = (TextView) findViewById(R.id.txtCol3);
        lblMensaje.setText(Mensajes.get("XFechaInicial"));

        lblMensaje = (TextView) findViewById(R.id.txtCol4);
        lblMensaje.setText(Mensajes.get("XFechaFinal"));


        Button btnGeneral = (Button) findViewById(R.id.btnAtras);
        btnGeneral.setText(Mensajes.get("XAnterior"));

        btnGeneral.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                iniciarActividadConResultado(IDisInformacionGeneralAlarmas.class, 0, Enumeradores.Acciones.ACCION_NO_VENTA);
                finalizar();
            }
        });

        Button btnGeneral2 = (Button) findViewById(R.id.btnSalir);
        btnGeneral2.setText(Mensajes.get("XSalirS"));

        btnGeneral2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finalizar();
            }
        });

        Button btnGeneral3 = (Button) findViewById(R.id.btnSiguiente);
        btnGeneral3.setText(Mensajes.get("XSiguiente"));


    }

    @Override
    public void iniciar() {

    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {

    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {

    }

    public void inicializar(){

        clienteSesion = (Cliente) Sesion.get(Sesion.Campo.ClienteActual);
        lsInformacionPromo = (ListView) findViewById(R.id.lsInformacionPromo);

        ISetDatos datos = null;
        try
        {
            datos = Consultas2.ConsultarActividadesDis.obtenerInformacionPromos();
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage());
        }

        if(datos != null ){
            ArrayList<ListaPromo> obtenerItem = obtenerItems(datos);
            DisPromoAdapter adaptador = new DisPromoAdapter(context, obtenerItem);
            lsInformacionPromo.setAdapter(adaptador);
        }

    }

    private ArrayList<ListaPromo> obtenerItems(ISetDatos datos) {
        ArrayList<ListaPromo> items = new ArrayList<ListaPromo>();

        while(datos.moveToNext()){
            String nombre = datos.getString("Nombre");
            String segmento = datos.getString("Segmento");
            String ini = datos.getString("FechaInicial");
            String fin = datos.getString("FechaFinal");
            items.add(new ListaPromo(ini, fin, nombre, segmento));

        }

        return items;
    }

    public static class ListaPromo {
        public String nombre;
        public String segmento;
        public String fechaIni;
        public String fechaFin;

        public ListaPromo(String fechaFin, String fechaIni, String nombre, String segmento) {
            this.fechaFin = fechaFin;
            this.fechaIni = fechaIni;
            this.nombre = nombre;
            this.segmento = segmento;
        }

        public String getFechaFin() {
            return fechaFin;
        }

        public void setFechaFin(String fechaFin) {
            this.fechaFin = fechaFin;
        }

        public String getFechaIni() {
            return fechaIni;
        }

        public void setFechaIni(String fechaIni) {
            this.fechaIni = fechaIni;
        }

        public String getNombre() {
            return nombre;
        }

        public void setNombre(String nombre) {
            this.nombre = nombre;
        }

        public String getSegmento() {
            return segmento;
        }

        public void setSegmento(String segmento) {
            this.segmento = segmento;
        }
    }
}
