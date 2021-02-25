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
import com.amesol.routelite.presentadores.interfaces.IDisPoliticaTradeComercial;
import com.amesol.routelite.presentadores.interfaces.IDisPortafolioRecomendado;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.DisPoliticaAdapter;
import com.amesol.routelite.vistas.generico.DisPortafolioAdapter;

import java.util.ArrayList;

/**
 * Created by ldelatorre on 11/03/2018.
 */
public class DisPortafolioRecomendado extends Vista implements IDisPortafolioRecomendado {

    private Context context = DisPortafolioRecomendado.this;
    Cliente clienteSesion;
    ListView lsPortafolio;


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
        lsPortafolio = (ListView) findViewById(R.id.lsPortafolio);

        ISetDatos datos = null;
        try
        {

            datos = Consultas2.ConsultarActividadesDis.obtenerPortafolio(clienteSesion.ClienteClave);
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage());
        }

        if(datos != null  && datos.getCount() > 0){
            ArrayList<ListaPortafolio> obtenerItem = obtenerItems(datos);
            DisPortafolioAdapter adaptador = new DisPortafolioAdapter(context, obtenerItem);
            lsPortafolio.setAdapter(adaptador);
        }else{
            mostrarError(Mensajes.get("ME0390").replace("$0$", Mensajes.get("DISInfCliente")), 99);
        }

    }

    private ArrayList<ListaPortafolio> obtenerItems(ISetDatos datos) {
        ArrayList<ListaPortafolio> items = new ArrayList<ListaPortafolio>();

        while (datos.moveToNext()){
            String clave = datos.getString("Categoria");
            String categoria = datos.getString("Desc_corta");
            String pesos = datos.getString("Pesos");
            String prom = datos.getString("Promo");

            items.add(new ListaPortafolio(categoria, clave, pesos, prom));

        }

        return items;
    }

    public static class ListaPortafolio {
        public String clave;
        public String categoria;
        public String pesos;
        public String prom;

        public ListaPortafolio(String categoria, String clave, String pesos, String prom) {
            this.categoria = categoria;
            this.clave = clave;
            this.pesos = pesos;
            this.prom = prom;
        }

        public String getCategoria() {
            return categoria;
        }

        public String getClave() {
            return clave;
        }

        public String getPesos() {
            return pesos;
        }

        public String getProm() {
            return prom;
        }
    }
}

