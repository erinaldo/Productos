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
import com.amesol.routelite.presentadores.interfaces.IDisObjetivoMensual;
import com.amesol.routelite.vistas.generico.DisObjetivoAdapter;
import com.amesol.routelite.vistas.generico.DisPortafolioAdapter;

import java.util.ArrayList;

/**
 * Created by ldelatorre on 11/03/2018.
 */
public class DisConsultaObjetivoMensual extends Vista implements IDisObjetivoMensual {

    private Context context = DisConsultaObjetivoMensual.this;
    Cliente clienteSesion;
    ListView lsObjetivo;


    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.dis_portafolio_recomendado);
        deshabilitarBarra(true);
        lblTitle.setText(Mensajes.get("XPortafolioRecomendado"));

        inicializar();

        TextView lblMensaje = (TextView) findViewById(R.id.lblTitulo);
        lblMensaje.setText(clienteSesion.Clave +" - "+ clienteSesion.RazonSocial);


        lblMensaje = (TextView) findViewById(R.id.txtCol1);
        lblMensaje.setText(Mensajes.get("XClave"));

        lblMensaje = (TextView) findViewById(R.id.txtCol2);
        lblMensaje.setText(Mensajes.get("XCategoria"));

        lblMensaje = (TextView) findViewById(R.id.txtCol3);
        lblMensaje.setText("$$");

        lblMensaje = (TextView) findViewById(R.id.txtCol4);
        lblMensaje.setText(Mensajes.get("XPromocion"));

        Button btnSalir = (Button) findViewById(R.id.btnSalir);
        btnSalir.setText(Mensajes.get("XSalirS"));

        btnSalir.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finalizar();
            }
        });

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

    @Override
    public void iniciar() {

    }

    public void inicializar(){

        clienteSesion = (Cliente) Sesion.get(Sesion.Campo.ClienteActual);
        lsObjetivo = (ListView) findViewById(R.id.lsObjetivo);

        ISetDatos datos = null;
        try
        {

            datos = Consultas2.ConsultarActividadesDis.obtenerObjetivo(clienteSesion.ClienteClave);
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage());
        }

        if(datos != null  && datos.getCount() > 0){
           /* ArrayList<ListaObjetivo> obtenerItem = obtenerItems(datos);
            DisObjetivoAdapter adaptador = new DisObjetivoAdapter(context, obtenerItem);
            lsObjetivo.setAdapter(adaptador);*/
        }else{
            mostrarError(Mensajes.get("ME0390").replace("$0$", clienteSesion.ClienteClave), 99);
            finalizar();
        }

    }

    private ArrayList<ListaObjetivo> obtenerItems(ISetDatos datos) {
        ArrayList<ListaObjetivo> items = new ArrayList<ListaObjetivo>();

        while (datos.moveToNext()){
            String categoria = datos.getString("Categoria");
            String metaCaja = datos.getString("Desc_corta");
            String faltante = datos.getString("Pesos");

            items.add(new ListaObjetivo(categoria, faltante, metaCaja));

        }

        return items;
    }

    public static class ListaObjetivo {
        public String categoria;
        public String metaCajas;
        public String faltante;

        public ListaObjetivo(String categoria, String faltante, String metaCajas) {
            this.categoria = categoria;
            this.faltante = faltante;
            this.metaCajas = metaCajas;
        }

        public String getCategoria() {
            return categoria;
        }

        public String getFaltante() {
            return faltante;
        }

        public String getMetaCajas() {
            return metaCajas;
        }
    }
}
