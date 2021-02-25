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
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.interfaces.IDisObjetivoMensual;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.DisObjetivoAdapter;
import com.amesol.routelite.vistas.generico.DisPortafolioAdapter;

import java.util.ArrayList;

/**
 * Created by ldelatorre on 11/03/2018.
 */
public class DisConsultaObjetivoMensual extends Vista implements IDisObjetivoMensual {

    private Context context = DisConsultaObjetivoMensual.this;
    ListView lsObjetivo;
    ArrayList<String> categorias;
    ArrayList<String> esquemas;
    Ruta rutaActual;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.dis_objetivo_mensual);
        deshabilitarBarra(true);
        lblTitle.setText(Mensajes.get("XObjetivoMensual"));

        inicializar();

        TextView lblMensaje = (TextView) findViewById(R.id.txtCol1);
        lblMensaje.setText(Mensajes.get("XCategoria"));

        lblMensaje = (TextView) findViewById(R.id.txtCol2);
        lblMensaje.setText(Mensajes.get("XMetaCajaMensual"));

        lblMensaje = (TextView) findViewById(R.id.txtCol3);
        lblMensaje.setText(Mensajes.get("XFaltantesCajas"));

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

        rutaActual = (Ruta) Sesion.get(Sesion.Campo.RutaActual);
        lsObjetivo = (ListView) findViewById(R.id.lsObjetivo);
        cargarCategorias();
        cargarEsquemas();
        ISetDatos datos = null;
        try
        {
            datos = Consultas2.ConsultarActividadesDis.obtenerObjetivo(rutaActual.RUTClave);
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage());
        }


        ArrayList<ListaObjetivo> obtenerItem = obtenerItems(datos);
        DisObjetivoAdapter adaptador = new DisObjetivoAdapter(context, obtenerItem);
        lsObjetivo.setAdapter(adaptador);

    }

    private void cargarCategorias(){
        categorias = new ArrayList<String>();
        for(int i = 1; i <= 12; i++)
            categorias.add(Mensajes.get("DISCategoria"+String.valueOf(i)));
    }

    private void cargarEsquemas()
    {
        esquemas = new ArrayList<String>();
        esquemas.add("'Victoria_Cuarto_media'");
        esquemas.add("'Corona_Cuarto_media'");
        esquemas.add("'Otras_Cervezas'");
        esquemas.add("'Corona_Victoria_Modelo_Bote'");
        esquemas.add("'Corona_Victoria_Familiar_Mega'");
        esquemas.add("'Cerveza_Barril'");
        esquemas.add("'Agua_mayor_1'");
        esquemas.add("'Otros_Productos'");
        esquemas.add("'Agua_menor_600'");
        esquemas.add("'Agua_menor_600','Agua_mayor_1'");
        esquemas.add("'Victoria_Cuarto_media','Corona_Cuarto_media','Otras_Cervezas','Corona_Victoria_Modelo_Bote'," +
                "'Corona_Victoria_Familiar_Mega', 'Cerveza_Barri'");
    }

    private ArrayList<ListaObjetivo> obtenerItems(ISetDatos datos) {

        ArrayList<ListaObjetivo> items = new ArrayList<ListaObjetivo>();
        datos.moveToFirst();
        String metaCajaOtrosPro = "";
        String faltanteOtrosProd = "";
        double faltantes = 0;
        int pos = 0;
        while(pos < (categorias.size()-1)){
            faltantes = 0;
            String categoria = categorias.get(pos);
            String metaCaja = (datos.getCount() > 0 ? datos.getString(1+pos) : "0");
            try {
                faltantes = Consultas2.ConsultarActividadesDis.obtenerFaltanteCajas(rutaActual.RUTClave, esquemas.get(pos));
            }catch (Exception ex){
                mostrarError(ex.getMessage());
            }
            String faltante = Generales.getFormatoDecimal((datos.getCount() > 0 ? datos.getDouble(12+pos) : 0) - faltantes ,0);
            if(pos == 7){
                metaCajaOtrosPro = metaCaja;
                faltanteOtrosProd = faltante;
            }
            items.add(new ListaObjetivo(categoria, faltante, metaCaja));
            pos++;
        }

        items.add(new ListaObjetivo(categorias.get(pos), faltanteOtrosProd, metaCajaOtrosPro));


       /* while (datos.moveToNext()){
            String categoria = datos.getString("Categoria");
            String metaCaja = datos.getString("Desc_corta");
            String faltante = datos.getString("Pesos");

            items.add(new ListaObjetivo(categoria, faltante, metaCaja));

        }*/

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
