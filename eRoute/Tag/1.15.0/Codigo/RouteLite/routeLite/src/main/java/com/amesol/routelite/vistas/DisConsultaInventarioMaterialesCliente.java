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
import com.amesol.routelite.presentadores.interfaces.IDisInventarioMaterialesCliente;
import com.amesol.routelite.vistas.generico.DisMaterialAdapter;
import com.amesol.routelite.vistas.generico.DisUltimoAdapter;

import java.util.ArrayList;

/**
 * Created by ldelatorre on 04/03/2018.
 */
public class DisConsultaInventarioMaterialesCliente extends Vista implements IDisInventarioMaterialesCliente {

    private Context context = DisConsultaInventarioMaterialesCliente.this;
    Cliente clienteSesion;
    ListView lsMaterial;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.dis_inventario_materiales_cliente);
        deshabilitarBarra(true);
        lblTitle.setText(Mensajes.get("XInventarioMaterialesClienteTitulo"));

        inicializar();

        TextView lblMensaje = (TextView) findViewById(R.id.lblTitulo);
        lblMensaje.setText(clienteSesion.Clave +" - "+ clienteSesion.RazonSocial);

        lblMensaje = (TextView) findViewById(R.id.txtCol1);
        lblMensaje.setText(Mensajes.get("XClave"));
        lblMensaje = (TextView) findViewById(R.id.txtCol2);
        lblMensaje.setText(Mensajes.get("XCategoria"));
        lblMensaje = (TextView) findViewById(R.id.txtCol3);
        lblMensaje.setText(Mensajes.get("XModeloSerial"));
        lblMensaje = (TextView) findViewById(R.id.txtCol4);
        lblMensaje.setText(Mensajes.get("XMarca"));
        lblMensaje = (TextView) findViewById(R.id.txtCol5);
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
        lsMaterial = (ListView) findViewById(R.id.lsMaterial);

        ISetDatos datos = null;
        try
        {

            datos = Consultas2.ConsultarActividadesDis.obtenerMateriales(clienteSesion.ClienteClave);
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage());
        }

        if(datos != null  && datos.getCount() > 0){
            ArrayList<ListaMaterial> obtenerItem = obtenerItems(datos);
            DisMaterialAdapter adaptador = new DisMaterialAdapter(context, obtenerItem);
            lsMaterial.setAdapter(adaptador);
        }else{
            mostrarError(Mensajes.get("ME0390").replace("$0$", clienteSesion.ClienteClave), 99);
        }

    }

    private ArrayList<ListaMaterial> obtenerItems(ISetDatos datos) {
        ArrayList<ListaMaterial> items = new ArrayList<ListaMaterial>();

        while (datos.moveToNext()){
            String clave = datos.getString("Clave");
            String categoria = datos.getString("Categoria");
            String modeloSerial = datos.getString("No_Serie") + " - " + datos.getString("Modelo");
            String marca = datos.getString("Marca");
            String cantidad = datos.getString("Cantidad");
            items.add(new ListaMaterial(cantidad, categoria, clave, marca, modeloSerial));

        }

        return items;
    }

    public static class ListaMaterial {
        public String clave;
        public String categoria;
        public String modeloSerial;
        public String marca;
        public String cantidad;

        public ListaMaterial(String cantidad, String categoria, String clave, String marca, String modeloSerial) {
            this.cantidad = cantidad;
            this.categoria = categoria;
            this.clave = clave;
            this.marca = marca;
            this.modeloSerial = modeloSerial;
        }

        public String getCantidad() {
            return cantidad;
        }

        public String getCategoria() {
            return categoria;
        }

        public String getClave() {
            return clave;
        }

        public String getMarca() {
            return marca;
        }

        public String getModeloSerial() {
            return modeloSerial;
        }
    }
}
