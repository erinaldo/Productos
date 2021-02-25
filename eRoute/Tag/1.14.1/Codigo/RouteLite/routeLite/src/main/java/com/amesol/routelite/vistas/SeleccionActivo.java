package com.amesol.routelite.vistas;

import android.app.AlertDialog;
import android.app.Dialog;
import android.app.SearchManager;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.Point;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.Display;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.SeleccionarActivo;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActivo;

import java.util.HashMap;

/**
 * Created by Adriana on 26/12/2016.
 */
public class SeleccionActivo extends Vista implements ISeleccionActivo {

    SeleccionarActivo mPresenta;
    String mAccion;
    private TextView mTexto;
    Cliente cliente;
    Vendedor oVendedor;
    boolean iniciarActividad;
    String sSOLIdSel;

    @SuppressWarnings("deprecation")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        try {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.seleccion_activo);
            deshabilitarBarra(true);
            setTitulo(Mensajes.get("XActivos"));

            mTexto = (TextView) findViewById(R.id.lblCliente);
            mTexto.setVisibility(View.GONE);
            cliente = (Cliente) Sesion.get(Sesion.Campo.ClienteActual);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(cliente.Clave + " - " + cliente.RazonSocial);

            mTexto = (TextView) findViewById(R.id.lblRuta);
            mTexto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Descripcion);

            mTexto = (TextView) findViewById(R.id.lblDia);
            mTexto.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);

            /*ListView lista = (ListView) findViewById(R.id.lstActivos);
            registerForContextMenu(lista);*/

            mPresenta = new SeleccionarActivo(this, mAccion) ;
            mPresenta.iniciar();
        } catch (Exception e) {
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
    }

    public void mostrarActivos(ISetDatos activos) {
        ListView lstActivos = (ListView) findViewById(R.id.lstActivos);

        Cursor cActivos = (Cursor) activos.getOriginal();
        SimpleCursorAdapter adapter;

        adapter = new SimpleCursorAdapter(this, R.layout.lista_div2_rojo, cActivos, new String[]
                { "Descripcion", "Tipo", "TipoFase" }, new int[]
                { R.id.texto1, R.id.texto2, R.id.texto3 });

        adapter.setViewBinder(new vista());
        lstActivos.setAdapter(adapter);
    }


    @Override
    public void iniciar() {

    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {

    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
        setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
        finalizar();
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        switch (keyCode) {
            case KeyEvent.KEYCODE_BACK:
                this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                this.finalizar();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }

    private class vista implements SimpleCursorAdapter.ViewBinder
    {

        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex)
        {
            int viewId = view.getId();
            try {
                switch (viewId) {
                    case R.id.texto1:
                        TextView texto1 = (TextView) view;
                        texto1.setText(cursor.getString(cursor.getColumnIndex("Descripcion")));
                        break;
                    case R.id.texto2:
                        TextView texto2 = (TextView) view;
                        texto2.setText(ValoresReferencia.getDescripcion("ACITIPO", cursor.getString(cursor.getColumnIndex("Tipo"))));
                        break;
                    case R.id.texto3:
                        TextView texto3 = (TextView) view;
                        texto3.setText(ValoresReferencia.getDescripcion("ACIFASE", cursor.getString(cursor.getColumnIndex("TipoFase"))));
                        break;
                    default:
                        TextView texto = (TextView) view;
                        texto.setText(cursor.getString(columnIndex));
                        break;
                }
            }catch(Exception ex){
                mostrarError(ex.getMessage());
            }
            return true;
        }
    }
}
