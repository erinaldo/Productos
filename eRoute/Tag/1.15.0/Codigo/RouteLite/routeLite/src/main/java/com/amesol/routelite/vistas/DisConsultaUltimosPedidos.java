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
import com.amesol.routelite.presentadores.interfaces.IDisUltimoPedido;
import com.amesol.routelite.vistas.generico.DisComportamientoAdapter;
import com.amesol.routelite.vistas.generico.DisUltimoAdapter;

import java.util.ArrayList;

/**
 * Created by ldelatorre on 04/03/2018.
 */
public class DisConsultaUltimosPedidos extends Vista implements IDisUltimoPedido {

    private Context context = DisConsultaUltimosPedidos.this;
    Cliente clienteSesion;
    ListView lsUltimo;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.dis_ultimos_pedidos);
        deshabilitarBarra(true);
        lblTitle.setText(Mensajes.get("XUltimosPedidosTitulo"));

        inicializar();

        TextView lblMensaje = (TextView) findViewById(R.id.lblTitulo);
        lblMensaje.setText(clienteSesion.Clave +" - "+ clienteSesion.RazonSocial);

        lblMensaje = (TextView) findViewById(R.id.txtCol1);
        lblMensaje.setText(Mensajes.get("XCategoria"));
        lblMensaje = (TextView) findViewById(R.id.txtCol2);
        lblMensaje.setText(Mensajes.get("XUltimaFechaCompra"));
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
        lsUltimo = (ListView) findViewById(R.id.lsUltimo);

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
            ArrayList<ListaUltimo> obtenerItem = obtenerItems(datos);
            DisUltimoAdapter adaptador = new DisUltimoAdapter(context, obtenerItem);
            lsUltimo.setAdapter(adaptador);
        }else{
            mostrarError(Mensajes.get("ME0390").replace("$0$", clienteSesion.ClienteClave), 99);
        }

    }

    private ArrayList<ListaUltimo> obtenerItems(ISetDatos datos) {
        ArrayList<ListaUltimo> items = new ArrayList<ListaUltimo>();

        if(datos.moveToNext()){
            String categoria = "Victoria cuarto y media";
            String mesAnterior = datos.getString("Fe_VicCuaMed");
            if(mesAnterior == null || mesAnterior.equals("")){
                mesAnterior = "Sin Compra";
            }
            String numCajas = datos.getString("CaU_VicCuaMed");
            items.add(new ListaUltimo(categoria, mesAnterior, numCajas));

            categoria = "Corona cuarto y media";
            mesAnterior = datos.getString("Fe_CorCuaMed");
            if(mesAnterior == null || mesAnterior.equals("")){
                mesAnterior = "Sin Compra";
            }
            numCajas = datos.getString("CaU_CorCuaMed");
            items.add(new ListaUltimo(categoria, mesAnterior, numCajas));

            categoria = "Otras Cervezas";
            mesAnterior = datos.getString("Fe_OCer");
            if(mesAnterior == null || mesAnterior.equals("")){
                mesAnterior = "Sin Compra";
            }
            numCajas = datos.getString("CaU_Ocer");
            items.add(new ListaUltimo(categoria, mesAnterior, numCajas));

            categoria = "Corona, Victoria y Modelo Bote";
            mesAnterior = datos.getString("Fe_CorVicModBote");
            if(mesAnterior == null || mesAnterior.equals("")){
                mesAnterior = "Sin Compra";
            }
            numCajas = datos.getString("CaU_CorVicModBote");
            items.add(new ListaUltimo(categoria, mesAnterior, numCajas));

            categoria = "Corona y Victoria    Familiar y Mega";
            mesAnterior = datos.getString("Fe_CorVicFamMega");
            if(mesAnterior == null || mesAnterior.equals("")){
                mesAnterior = "Sin Compra";
            }
            numCajas = datos.getString("CaU_CorVicFamMega");
            items.add(new ListaUltimo(categoria, mesAnterior, numCajas));

            categoria = "Cerveza Barril";
            mesAnterior = datos.getString("Fe_CerBarril");
            if(mesAnterior == null || mesAnterior.equals("")){
                mesAnterior = "Sin Compra";
            }
            numCajas = datos.getString("CaU_CerBarril");
            items.add(new ListaUltimo(categoria, mesAnterior, numCajas));

            categoria = "Agua de 1L o Mayor";
            mesAnterior = datos.getString("Fe_Agua1L");
            if(mesAnterior == null || mesAnterior.equals("")){
                mesAnterior = "Sin Compra";
            }
            numCajas = datos.getString("CaU_Agua1L");
            items.add(new ListaUltimo(categoria, mesAnterior, numCajas));

            categoria = "Otros Productos";
            mesAnterior = datos.getString("Fe_OtrosPro");
            if(mesAnterior == null || mesAnterior.equals("")){
                mesAnterior = "Sin Compra";
            }
            numCajas = datos.getString("CaU_OtrosPro");
            items.add(new ListaUltimo(categoria, mesAnterior, numCajas));

            categoria = "Agua de 600ml o Menor";
            mesAnterior = datos.getString("Fe_Agua600");
            if(mesAnterior == null || mesAnterior.equals("")){
                mesAnterior = "Sin Compra";
            }
            numCajas = datos.getString("CaU_Agua600");
            items.add(new ListaUltimo(categoria, mesAnterior, numCajas));

        }

        return items;
    }

    public static class ListaUltimo {
        public String categoria;
        public String ultimaFecha;
        public String numeroCajas;

        public ListaUltimo(String categoria, String ultimaFecha, String numeroCajas) {
            this.categoria = categoria;
            this.ultimaFecha = ultimaFecha;
            this.numeroCajas = numeroCajas;
        }

        public String getCategoria() {
            return categoria;
        }

        public String getUltimaFecha() {
            return ultimaFecha;
        }

        public String getNumeroCajas() {
            return numeroCajas;
        }
    }

}
