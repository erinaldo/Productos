package com.amesol.routelite.vistas;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
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
import com.amesol.routelite.presentadores.interfaces.IDisInformacionGeneralDatos;
import com.amesol.routelite.presentadores.interfaces.IDisInformacionGeneralPromociones;
import com.amesol.routelite.vistas.generico.DisAlarmasAdapter;
import com.amesol.routelite.vistas.generico.DisDatosAdapter;

import java.util.ArrayList;

/**
 * Created by ldelatorre on 04/03/2018.
 */
public class DisConsultaInformacionGeneralAlarmas extends Vista implements IDisInformacionGeneralAlarmas {

    private Context context = DisConsultaInformacionGeneralAlarmas.this;
    Cliente clienteSesion;
    ListView lsInformacionAlarmas;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.dis_informacion_general_alarmas);
        deshabilitarBarra(true);
        lblTitle.setText(Mensajes.get("XInformacionGeneral"));

        inicializar();

        TextView lblMensaje = (TextView) findViewById(R.id.lblTitulo);
        lblMensaje.setText(Mensajes.get("XConsultaAlarmas"));

        lblMensaje = (TextView) findViewById(R.id.lblCliente);
        lblMensaje.setText(clienteSesion.Clave +" - "+ clienteSesion.RazonSocial);

        lblMensaje = (TextView) findViewById(R.id.txtCol1);
        lblMensaje.setText(Mensajes.get("XTipoAlarma"));


        Button btnGeneral = (Button) findViewById(R.id.btnAtras);
        btnGeneral.setText(Mensajes.get("XAnterior"));

        btnGeneral.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                iniciarActividadConResultado(IDisInformacionGeneralDatos.class, 0, Enumeradores.Acciones.ACCION_NO_VENTA);
                finalizar();
            }
        });

        Button btnGeneral2 = (Button) findViewById(R.id.btnSalir);
        btnGeneral2.setText(Mensajes.get("XSalirS"));

        Button btnGeneral3 = (Button) findViewById(R.id.btnSiguiente);
        btnGeneral3.setText(Mensajes.get("XSiguiente"));

        btnGeneral3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                iniciarActividadConResultado(IDisInformacionGeneralPromociones.class, 0, Enumeradores.Acciones.ACCION_NO_VENTA);
                finalizar();
            }
        });

        lsInformacionAlarmas.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                try {
                    ListaAlarmas lista = (ListaAlarmas) parent.getItemAtPosition(position);
                    ISetDatos datos = Consultas2.ConsultarActividadesDis.obtenerInformacionAlarmasTexto(clienteSesion.ClienteClave, lista.getInformacion());
                    if(datos.moveToNext()){
                        mostrarError(datos.getString("Texto").replace("&", datos.getString("Valor")));
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }



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

    }

    public void inicializar(){

        clienteSesion = (Cliente) Sesion.get(Sesion.Campo.ClienteActual);
        lsInformacionAlarmas = (ListView) findViewById(R.id.lsInformacionAlarmas);

        ISetDatos datos = null;
        try
        {

            datos = Consultas2.ConsultarActividadesDis.obtenerInformacionAlarmas(clienteSesion.ClienteClave);
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage());
        }

        if(datos != null){
            ArrayList<ListaAlarmas> obtenerItem = obtenerItems(datos);
            DisAlarmasAdapter adaptador = new DisAlarmasAdapter(context, obtenerItem);
            lsInformacionAlarmas.setAdapter(adaptador);
        }

    }

    private ArrayList<ListaAlarmas> obtenerItems(ISetDatos datos) {
        ArrayList<ListaAlarmas> items = new ArrayList<ListaAlarmas>();

        while (datos.moveToNext()){
            String informacion = datos.getString("TipoAlarma");
            items.add(new ListaAlarmas(informacion));
        }

        return items;
    }

    public static class ListaAlarmas {
        public String informacion;

        public ListaAlarmas(String informacion) {
            this.informacion = informacion;
        }

        public String getInformacion() {
            return informacion;
        }

        public void setInformacion(String informacion) {
            this.informacion = informacion;
        }
    }
}
