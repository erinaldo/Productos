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
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.interfaces.IDisInformacionGeneralAlarmas;
import com.amesol.routelite.presentadores.interfaces.IDisInformacionGeneralDatos;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.DisDatosAdapter;
import com.amesol.routelite.vistas.generico.GastosAdapter;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Locale;

/**
 * Created by ldelatorre on 04/03/2018.
 */
public class DisConsultaInformacionGeneralDatos extends Vista implements IDisInformacionGeneralDatos {

    private Context context = DisConsultaInformacionGeneralDatos.this;
    Cliente clienteSesion;
    ListView lsInformacionGeneral;


    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.dis_informacion_general_datos);
        deshabilitarBarra(true);
        lblTitle.setText(Mensajes.get("XInformacionGeneral"));

        inicializar();

        TextView lblMensaje = (TextView) findViewById(R.id.lblTitulo);
        lblMensaje.setText(Mensajes.get("XDatosCliente"));

        lblMensaje = (TextView) findViewById(R.id.lblCliente);
        lblMensaje.setText(clienteSesion.Clave +" - "+ clienteSesion.RazonSocial);


        Button btnGeneral = (Button) findViewById(R.id.btnAtras);
        btnGeneral.setText(Mensajes.get("XAnterior"));

        Button btnGeneral2 = (Button) findViewById(R.id.btnSalir);
        btnGeneral2.setText(Mensajes.get("XSalirS"));

        Button btnGeneral3 = (Button) findViewById(R.id.btnSiguiente);
        btnGeneral3.setText(Mensajes.get("XSiguiente"));

        btnGeneral3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                iniciarActividadConResultado(IDisInformacionGeneralAlarmas.class, 0, Enumeradores.Acciones.ACCION_NO_VENTA);
                finalizar();
            }
        });


    }

    @Override
    public void iniciar() {

    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {

    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
        if (tipoMensaje == 99){
            finalizar();
        }

    }

    public void inicializar(){

        clienteSesion = (Cliente) Sesion.get(Sesion.Campo.ClienteActual);
        lsInformacionGeneral = (ListView) findViewById(R.id.lsInformacionDatos);

        ISetDatos datos = null;
        try
        {

            datos = Consultas2.ConsultarActividadesDis.obtenerInformacionDatos(clienteSesion.ClienteClave);
        }
        catch (Exception e)
        {
           mostrarError(e.getMessage());
        }

        if(datos != null && datos.getCount() > 0){
            ArrayList<ListaDatos> obtenerItem = obtenerItems(datos);
            DisDatosAdapter adaptador = new DisDatosAdapter(context, obtenerItem);
            lsInformacionGeneral.setAdapter(adaptador);
        }else{
            mostrarError(Mensajes.get("ME0390").replace("$0$", Mensajes.get("DISInfCliente")), 99);
        }

    }

    private ArrayList<ListaDatos> obtenerItems(ISetDatos datos) {
        ArrayList<ListaDatos> items = new ArrayList<ListaDatos>();

       if(datos.moveToNext()){
           String dato = Mensajes.get("XClienteSap");
           String informacion = datos.getString("ClienteClave");
           items.add(new ListaDatos(dato, informacion));

           dato = Mensajes.get("XNombre");
           informacion = datos.getString("Nombre");
           items.add(new ListaDatos(dato, informacion));

           dato = Mensajes.get("XNombreComercial");
           informacion = datos.getString("NombreComercial");
           items.add(new ListaDatos(dato, informacion));

           dato = Mensajes.get("XSegmento");
           informacion = datos.getString("Segmento");
           items.add(new ListaDatos(dato, informacion));

           dato = Mensajes.get("XClase");
           informacion = datos.getString("Clase");
           items.add(new ListaDatos(dato, informacion));

           dato = Mensajes.get("XEstrategia");
           informacion = datos.getString("Estrategia");
           items.add(new ListaDatos(dato, informacion));

           dato = Mensajes.get("XEfectividadVista");
           informacion = datos.getString("EfectividadCompra") +"% ("+ datos.getString("FrecuenciaCompra")+ " de cada "+ datos.getString("TotalVisitas") +" visitas)" ;
           items.add(new ListaDatos(dato, informacion));

           dato = Mensajes.get("XDropSize");
           informacion = datos.getString("DropSize") + " caja (s) por Visita";
           items.add(new ListaDatos(dato, informacion));

           dato = Mensajes.get("XNumVisitasCompra");
           informacion = datos.getString("VisitaSinCompra");
           items.add(new ListaDatos(dato, informacion));

           dato = Mensajes.get("XCondicionesComerciales");
           informacion = "Descuento actual " + datos.getString("DescActual") +"%\nDescuento Propuesto " + datos.getString("DescProp") + "%";
           items.add(new ListaDatos(dato, informacion));
        }

        return items;
    }

    public static class ListaDatos {
        public String dato;
        public String informacion;

        public ListaDatos(String dato, String informacion) {
            this.dato = dato;
            this.informacion = informacion;
        }

        public String getDato() {
            return dato;
        }

        public void setDato(String dato) {
            this.dato = dato;
        }

        public String getInformacion() {
            return informacion;
        }

        public void setInformacion(String informacion) {
            this.informacion = informacion;
        }
    }


}
