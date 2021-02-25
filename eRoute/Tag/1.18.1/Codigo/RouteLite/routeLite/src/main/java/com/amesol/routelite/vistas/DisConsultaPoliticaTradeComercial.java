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
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.DisMaterialAdapter;
import com.amesol.routelite.vistas.generico.DisPoliticaAdapter;

import java.util.ArrayList;

/**
 * Created by ldelatorre on 04/03/2018.
 */
public class DisConsultaPoliticaTradeComercial extends Vista implements IDisPoliticaTradeComercial {

    private Context context = DisConsultaPoliticaTradeComercial.this;
    Cliente clienteSesion;
    ListView lsPolitica;
    TextView txtSaldo;
    TextView txtLimite;
    TextView txtVencimiento;


    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.dis_politica_trade_comercial);
        deshabilitarBarra(true);
        lblTitle.setText(Mensajes.get("XPoliticaTitulo"));

        txtSaldo = (TextView) findViewById(R.id.txtSaldo);
        txtLimite = (TextView) findViewById(R.id.txtLimiteCredito);
        txtVencimiento = (TextView) findViewById(R.id.txtVencimiento);

        inicializar();

        TextView lblMensaje = (TextView) findViewById(R.id.lblTitulo);
        lblMensaje.setText(clienteSesion.Clave +" - "+ clienteSesion.RazonSocial);

        lblMensaje = (TextView) findViewById(R.id.lblLimiteCredito);
        lblMensaje.setText(Mensajes.get("XLimiteDeCredito"));

        lblMensaje = (TextView) findViewById(R.id.lblVencimiento);
        lblMensaje.setText(Mensajes.get("XVencimiento"));

        lblMensaje = (TextView) findViewById(R.id.lblSaldo);
        lblMensaje.setText(Mensajes.get("XSaldo"));

        lblMensaje = (TextView) findViewById(R.id.txtCol1);
        lblMensaje.setText(Mensajes.get("XCategoria"));

        lblMensaje = (TextView) findViewById(R.id.txtCol2);
        lblMensaje.setText(Mensajes.get("XTipo"));

        lblMensaje = (TextView) findViewById(R.id.txtCol3);
        lblMensaje.setText(Mensajes.get("XCantidad"));

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
        lsPolitica = (ListView) findViewById(R.id.lsPolitica);

        ISetDatos datos = null;
        try
        {

            datos = Consultas2.ConsultarActividadesDis.obtenerPoliticas(clienteSesion.ClienteClave);
            txtLimite.setText(Consultas2.ConsultarActividadesDis.obtenerPoliticasCredito(clienteSesion.ClienteClave));
            ISetDatos datos1 = Consultas2.ConsultarActividadesDis.obtenerPoliticasSaldo(clienteSesion.ClienteClave);
            if(datos1 != null) {
                if (datos1.moveToNext()) {
                    txtSaldo.setText(datos1.getString("Saldo"));
                    String fecha = Generales.getFormatoFecha(datos1.getDate("FechaCobranza"), "dd/MM/yyyy");
                    txtVencimiento.setText(fecha);
                }
            }
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage());
        }

        if(datos != null  && datos.getCount() > 0){


            ArrayList<ListaPolitica> obtenerItem = obtenerItems(datos);
            DisPoliticaAdapter adaptador = new DisPoliticaAdapter(context, obtenerItem);
            lsPolitica.setAdapter(adaptador);
        }else{
            mostrarError(Mensajes.get("ME0390").replace("$0$", Mensajes.get("DISInfCliente")), 99);
        }

    }

    private ArrayList<ListaPolitica> obtenerItems(ISetDatos datos) {
        ArrayList<ListaPolitica> items = new ArrayList<ListaPolitica>();

        while (datos.moveToNext()){
            String categoria = datos.getString("Categoria");
            String tipo = datos.getString("Tipo");
            String cantidad = datos.getString("Cantidad");

            items.add(new ListaPolitica(cantidad, categoria, tipo));

        }

        return items;
    }

    public static class ListaPolitica {
        public String categoria;
        public String tipo;
        public String cantidad;

        public ListaPolitica(String cantidad, String categoria, String tipo) {
            this.cantidad = cantidad;
            this.categoria = categoria;
            this.tipo = tipo;
        }

        public String getCantidad() {
            return cantidad;
        }

        public void setCantidad(String cantidad) {
            this.cantidad = cantidad;
        }

        public String getCategoria() {
            return categoria;
        }

        public void setCategoria(String categoria) {
            this.categoria = categoria;
        }

        public String getTipo() {
            return tipo;
        }

        public void setTipo(String tipo) {
            this.tipo = tipo;
        }
    }
}
