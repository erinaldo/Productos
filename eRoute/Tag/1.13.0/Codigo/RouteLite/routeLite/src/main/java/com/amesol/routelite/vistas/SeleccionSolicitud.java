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
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.controles.CargasTextBoxScanner;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;
import com.amesol.routelite.presentadores.act.SeleccionarSolicitud;
import com.amesol.routelite.presentadores.interfaces.ICancelaPedido;
import com.amesol.routelite.presentadores.interfaces.ICapturaSolicitud;
import com.amesol.routelite.presentadores.interfaces.ISeleccionSolicitud;
import com.amesol.routelite.vistas.generico.PedidosAdapter;

import java.util.HashMap;

/**
 * Created by Adriana on 26/12/2016.
 */
public class SeleccionSolicitud extends Vista implements ISeleccionSolicitud {

    SeleccionarSolicitud mPresenta;
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

            setContentView(R.layout.seleccion_solicitud);
            deshabilitarBarra(true);
            setTitulo(Mensajes.get("XSolicitudes"));

            Button btn = (Button) findViewById(R.id.btnContinuar);
            btn.setText(Mensajes.get("XContinuar"));
            btn.setOnClickListener(mContinuar);

            mTexto = (TextView) findViewById(R.id.lblCliente);
            mTexto.setVisibility(View.GONE);
            cliente = (Cliente) Sesion.get(Sesion.Campo.ClienteActual);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(cliente.Clave + " - " + cliente.RazonSocial);

            mTexto = (TextView) findViewById(R.id.lblRuta);
            mTexto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Descripcion);

            mTexto = (TextView) findViewById(R.id.lblDia);
            mTexto.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);

            ListView lista = (ListView) findViewById(R.id.lstSolicitudes);
            registerForContextMenu(lista);

            oVendedor = (Vendedor) Sesion.get(Sesion.Campo.VendedorActual);
            iniciarActividad = false;

            mPresenta = new SeleccionarSolicitud(this, mAccion) ;
            mPresenta.iniciar();
        } catch (Exception e) {
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
    }

    public void mostrarSolicitudes(ISetDatos solicitudes) {
        ListView lstSolicitudes = (ListView) findViewById(R.id.lstSolicitudes);

        Cursor cSolicitudes = (Cursor) solicitudes.getOriginal();
        startManagingCursor(cSolicitudes);

        SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple1_rojo, cSolicitudes, new String[]
                {SearchManager.SUGGEST_COLUMN_TEXT_1}, new int[]
                {R.id.texto1});
        lstSolicitudes.setAdapter(adapter);
    }


    @Override
    public void iniciar() {

    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {

    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
        if (respuesta == Enumeradores.RespuestaMsg.Si && tipoMensaje == 10){
            mPresenta.eliminar(sSOLIdSel);
            mPresenta.actualizarLista();
        }
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

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.context_lista_solicitudes, menu);

        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) menuInfo;
        ListView lista = (ListView) findViewById(R.id.lstSolicitudes);
        String sSOLId = ((Cursor)lista.getItemAtPosition((int) info.position)).getString(0);


        if (mPresenta.validarEliminar(sSOLId)) {
            menu.getItem(0).setTitle(Mensajes.get("XModificar"));
            menu.getItem(1).setTitle(Mensajes.get("XEliminar"));
            menu.getItem(0).setVisible(true);
            menu.getItem(1).setVisible(true);
        }
        else{
            menu.getItem(0).setVisible(false);
            menu.getItem(1).setVisible(false);
        }
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
        ListView lista = (ListView) findViewById(R.id.lstSolicitudes);
        sSOLIdSel = ((Cursor)lista.getItemAtPosition((int) info.position)).getString(0);

        if (item.getItemId() ==  R.id.modificar){
            mPresenta.modificar(sSOLIdSel);
            return true;
        }
        else{
            mostrarPreguntaSiNo(Mensajes.get("P0001"), 10);
            return true;
        }
    }

    private View.OnClickListener mContinuar = new View.OnClickListener() {

        @Override
        public void onClick(View v) {
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
            iniciarActividadConResultado(ICapturaSolicitud.class, 0, null);
        }

    };
}
