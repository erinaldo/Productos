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
import com.amesol.routelite.presentadores.interfaces.IDisComportamientoCompra;
import com.amesol.routelite.vistas.generico.DisComportamientoAdapter;
import com.amesol.routelite.vistas.generico.DisPromoAdapter;

import java.util.ArrayList;

/**
 * Created by ldelatorre on 04/03/2018.
 */
public class DisConsultaComportamiendoCompra extends Vista implements IDisComportamientoCompra {

    private Context context = DisConsultaComportamiendoCompra.this;
    Cliente clienteSesion;
    ListView lsComportamiento;


    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.dis_comportamiento_compra);
        deshabilitarBarra(true);
        lblTitle.setText(Mensajes.get("XComportamientoCompra"));

        inicializar();

        TextView lblMensaje = (TextView) findViewById(R.id.lblTitulo);
        lblMensaje.setText(clienteSesion.Clave +" - "+ clienteSesion.RazonSocial);

        lblMensaje = (TextView) findViewById(R.id.txtCol1);
        lblMensaje.setText(Mensajes.get("XCategoria"));
        lblMensaje = (TextView) findViewById(R.id.txtCol2);
        lblMensaje.setText(Mensajes.get("XMesAnterior"));
        lblMensaje = (TextView) findViewById(R.id.txtCol3);
        lblMensaje.setText(Mensajes.get("XNumeroCajas"));


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
        lsComportamiento = (ListView) findViewById(R.id.lsComportamiento);

        ISetDatos datos = null;
        try
        {

            datos = Consultas2.ConsultarActividadesDis.obtenerComportamiento(clienteSesion.ClienteClave);
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage());
        }

        if(datos != null  && datos.getCount() > 0){
            ArrayList<ListaComportamiento> obtenerItem = obtenerItems(datos);
            DisComportamientoAdapter adaptador = new DisComportamientoAdapter(context, obtenerItem);
            lsComportamiento.setAdapter(adaptador);
        }else{
            //mostrarError(Mensajes.get("ME0390").replace("$0$", clienteSesion.ClienteClave), 99);
            mostrarError(Mensajes.get("ME0390").replace("$0$", Mensajes.get("DISInfCliente")), 99);
        }

    }

    private ArrayList<ListaComportamiento> obtenerItems(ISetDatos datos) {
        ArrayList<ListaComportamiento> items = new ArrayList<ListaComportamiento>();

        if(datos.moveToNext()){
            String categoria = "Cajas Mensual";
            String mesAnterior = datos.getString("CaM_CajasMensual");
            String numCajas = datos.getString("CaA_CajasMensual");
            items.add(new ListaComportamiento(categoria, mesAnterior, numCajas));

            categoria = "Descuento Mensual";
            mesAnterior = datos.getString("Mes_DescMensual");
            numCajas = datos.getString("Act_DescMensual");
            items.add(new ListaComportamiento(categoria, mesAnterior, numCajas));

            categoria = "Victoria cuarto y media";
            mesAnterior = datos.getString("CaM_VicCuaMed");
            numCajas = datos.getString("CaA_VicCuaMed");
            items.add(new ListaComportamiento(categoria, mesAnterior, numCajas));

            categoria = "Corona cuarto y media";
            mesAnterior = datos.getString("CaM_CorCuaMed");
            numCajas = datos.getString("CaA_CorCuaMed");
            items.add(new ListaComportamiento(categoria, mesAnterior, numCajas));

            categoria = "Otras Cervezas";
            mesAnterior = datos.getString("CaM_Ocer");
            numCajas = datos.getString("CaA_CorVicModBote");
            items.add(new ListaComportamiento(categoria, mesAnterior, numCajas));

            categoria = "Corona, Victoria y Modelo Bote";
            mesAnterior = datos.getString("CaM_CorVicModBote");
            numCajas = datos.getString("CaA_CorVicModBote");
            items.add(new ListaComportamiento(categoria, mesAnterior, numCajas));

            categoria = "Corona y Victoria    Familiar y Mega";
            mesAnterior = datos.getString("CaM_CorVicFamMega");
            numCajas = datos.getString("CaA_CorVicFamMega");
            items.add(new ListaComportamiento(categoria, mesAnterior, numCajas));

            categoria = "Cerveza Barril";
            mesAnterior = datos.getString("CaM_CerBarril");
            numCajas = datos.getString("CaA_CerBarril");
            items.add(new ListaComportamiento(categoria, mesAnterior, numCajas));

            categoria = "Agua de 1L o Mayor";
            mesAnterior = datos.getString("CaM_Agua1L");
            numCajas = datos.getString("CaA_Agua1L");
            items.add(new ListaComportamiento(categoria, mesAnterior, numCajas));

            categoria = "Otros Productos";
            mesAnterior = datos.getString("CaM_OtrosPro");
            numCajas = datos.getString("CaA_OtrosPro");
            items.add(new ListaComportamiento(categoria, mesAnterior, numCajas));

            categoria = "Agua de 600ml o Menor";
            mesAnterior = datos.getString("CaM_Agua600");
            numCajas = datos.getString("CaA_Agua600");
            items.add(new ListaComportamiento(categoria, mesAnterior, numCajas));

            categoria = "Agua Total";
            mesAnterior = datos.getString("CaM_AguaTot");
            numCajas = datos.getString("CaA_AguaTot");
            items.add(new ListaComportamiento(categoria, mesAnterior, numCajas));

            categoria = "Cerveza Total";
            mesAnterior = datos.getString("CaM_CerTot");
            numCajas = datos.getString("CaA_CerTot");
            items.add(new ListaComportamiento(categoria, mesAnterior, numCajas));

            categoria = "Otros Productos Total";
            mesAnterior = datos.getString("CaM_OtrosPro");
            numCajas = datos.getString("CaA_OtrosPro");
            items.add(new ListaComportamiento(categoria, mesAnterior, numCajas));

        }

        return items;
    }

    public static class ListaComportamiento {
        public String categoria;
        public String mesAnterior;
        public String numeroCajas;

        public ListaComportamiento(String categoria, String mesAnterior, String numeroCajas) {
            this.categoria = categoria;
            this.mesAnterior = mesAnterior;
            this.numeroCajas = numeroCajas;
        }

        public String getCategoria() {
            return categoria;
        }

        public String getMesAnterior() {
            return mesAnterior;
        }

        public String getNumeroCajas() {
            return numeroCajas;
        }
    }

}
