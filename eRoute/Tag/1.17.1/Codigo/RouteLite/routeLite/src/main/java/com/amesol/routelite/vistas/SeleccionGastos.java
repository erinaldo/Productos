package com.amesol.routelite.vistas;

import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.KeyEvent;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.SeleccionarGastos;
import com.amesol.routelite.presentadores.interfaces.ICapturaGastos;
import com.amesol.routelite.presentadores.interfaces.ISeleccionGastos;
import com.amesol.routelite.vistas.generico.GastosAdapter;

import java.util.Date;
import java.util.HashMap;

/**
 * Created by ldelatorre on 29/05/2017.
 */
public class SeleccionGastos extends Vista implements ISeleccionGastos {

    private Context context = SeleccionGastos.this;
    private TextView txtRuta;
    private TextView txtDiaTrabajo;
    private Button btnContinuar;
    private SeleccionarGastos mPresentador;
    private ListView listaGastos;
    ListaGastos lGastos = null;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        // TODO Auto-generated method stub
        super.onCreate(savedInstanceState);
        setContentView(R.layout.seleccion_gastos);

        mPresentador = new SeleccionarGastos(this);
        setTitulo(Mensajes.get("XGatosVendedor")); //Mandas el titulo
        txtRuta = (TextView) findViewById(R.id.txtRuta);
        txtDiaTrabajo = (TextView) findViewById(R.id.txtDiaTrabajo);
        btnContinuar = (Button) findViewById(R.id.btnContinuarGastos);

        listaGastos = (ListView) findViewById(R.id.lstGastos);
        mPresentador.llenarLista(context);
        registerForContextMenu(listaGastos);

        String ruta = Mensajes.get("XRuta")+": "+((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Descripcion;
        String diaTrabajo = Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave;
        txtRuta.setText(ruta);
        txtDiaTrabajo.setText(diaTrabajo);

        btnContinuar.setText(Mensajes.get("XContinuar"));
        btnContinuar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                mPresentador.capturaGastos();
            }
        });
    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {

        if (tipoMensaje == 1){
            if(respuesta == Enumeradores.RespuestaMsg.Si){
                mPresentador.eliminarGasto(lGastos.getFecheCompleta());
            }
        }
    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {

    }

    @Override
    public void iniciar() {

    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        switch (keyCode)
        {
            case KeyEvent.KEYCODE_BACK: //cacho el valor del "regreso"

                finalizar(); //con este metodo me regreso al menu anterior
                break;

        }
        // TODO Auto-generated method stub
        return super.onKeyDown(keyCode, event);
    }

    @Override
    public void llenarListaGastos(GastosAdapter adapter) {
        listaGastos.setAdapter(adapter);
    }

    @Override
    public void refrescarLista() {
        mPresentador.llenarLista(context);
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);


        if(v.getId() == R.id.lstGastos){
            MenuInflater inflater = getMenuInflater();
            inflater.inflate(R.menu.menu_gasto, menu);

            menu.getItem(0).setTitle(Mensajes.get("XModificar"));
            menu.getItem(1).setTitle(Mensajes.get("XEliminar"));
        }
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterView.AdapterContextMenuInfo info = null;

        if (item.getMenuInfo() != null) {
            info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
            lGastos = (ListaGastos)  listaGastos.getItemAtPosition((int) info.position);
        }

        switch (item.getItemId()) {
            case R.id.modificarGastos:
                if(lGastos != null){
                    HashMap<String,Date> parametros = new HashMap<String, Date>();
                    parametros.put("Fecha",lGastos.getFecheCompleta());
                    iniciarActividadConResultado(ICapturaGastos.class,0,"",parametros);
                }

                return true;

            case R.id.eliminarGastos:
                mostrarPreguntaSiNo(Mensajes.get("P0001"),1);
                return true;
        }

        return false;
    }

    public static class ListaGastos {
        public Date fecheCompleta;
        public String fecha;
        public String concepto;
        public String total;

        public ListaGastos(Date fecheCompleta, String fecha, String concepto , String total) {
            this.concepto = concepto;
            this.fecha = fecha;
            this.fecheCompleta = fecheCompleta;
            this.total = total;
        }

        public String getConcepto() {
            return concepto;
        }

        public void setConcepto(String concepto) {
            this.concepto = concepto;
        }

        public String getFecha() {
            return fecha;
        }

        public void setFecha(String fecha) {
            this.fecha = fecha;
        }

        public Date getFecheCompleta() {
            return fecheCompleta;
        }

        public void setFecheCompleta(Date fecheCompleta) {
            this.fecheCompleta = fecheCompleta;
        }

        public String getTotal() {
            return total;
        }

        public void setTotal(String total) {
            this.total = total;
        }
    }
}
