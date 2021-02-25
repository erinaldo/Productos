package com.amesol.routelite.vistas;

import android.app.AlertDialog;
import android.app.Dialog;
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
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.SeleccionarMercadeo;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;
import com.amesol.routelite.presentadores.interfaces.ISeleccionMercadeo;

public class SeleccionMercadeo extends Vista implements ISeleccionMercadeo {
    SeleccionarMercadeo mPresenta;
    String mAccion;

    boolean iniciarActividad;
    String sMRDIdSeleccionado = null;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        try
        {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.seleccion_transaccion);
            deshabilitarBarra(true);

            lblTitle.setText(Mensajes.get("XMercadeo"));
            Button btn = (Button) findViewById(R.id.btnContinuar);
            btn.setText(Mensajes.get("XContinuar"));
            btn.setOnClickListener(mContinuar);

            ListView lista = (ListView) findViewById(R.id.lstTransaccion);
            lista.setOnItemClickListener(mSeleccion);
            registerForContextMenu(lista);

            mPresenta = new SeleccionarMercadeo(this, mAccion);
            mPresenta.iniciar();
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event)
    {
        switch (keyCode)
        {
            case KeyEvent.KEYCODE_BACK:
                setResult(Enumeradores.Resultados.RESULTADO_BIEN);
                this.finish();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }




        @Override
        public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo)
        {
            super.onCreateContextMenu(menu, v, menuInfo);
            MenuInflater inflater = getMenuInflater();
            inflater.inflate(R.menu.context_manto_mercadeo, menu);

            menu.getItem(0).setTitle(Mensajes.get("XEliminar"));
        }


        @Override
        public boolean onContextItemSelected(MenuItem item)
        {
            AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
            ListView lista = (ListView) findViewById(R.id.lstTransaccion);
            Cursor mercadeo = (Cursor) lista.getItemAtPosition((int) info.position);
            mercadeo.moveToPosition((int)info.position);
            sMRDIdSeleccionado = mercadeo.getString(mercadeo.getColumnIndex("_id"));
            switch (item.getItemId()) {
                case R.id.eliminar:
                    mostrarPreguntaSiNo(Mensajes.get("P0001"), 9);
                    return true;
            }
            return true;
        }

    private AdapterView.OnItemClickListener mSeleccion = new AdapterView.OnItemClickListener()
    {
        public void onItemClick(AdapterView<?> parent, View v, int position, long id)
        {
            String MRDId = ((SimpleCursorAdapter) parent.getAdapter()).getCursor().getString(((SimpleCursorAdapter) parent.getAdapter()).getCursor().getColumnIndex("_id"));
            mPresenta.modificarMERDetalle(MRDId);
        }
    };

    private View.OnClickListener mContinuar = new View.OnClickListener()
    {
        public void onClick(View v)
        {
            mPresenta.generarMERDetalle();
        }
    };

    @Override
    public void iniciar()
    {
        // TODO Auto-generated method stub
    }

    @Override
    public void mostrarMercadeoCliente(ISetDatos sdMERDetalle)
    {
        ListView lstMercadeo = (ListView) findViewById(R.id.lstTransaccion);

        Cursor cMERDetalle = (Cursor) sdMERDetalle.getOriginal();
        startManagingCursor(cMERDetalle);
        try {
            SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple3, cMERDetalle, new String[]
                    {"Producto", "Marca","Presentacion"}, new int[]
                    {R.id.texto1, R.id.texto2, R.id.texto3});
            lstMercadeo.setAdapter(adapter);
        } catch (Exception e) {
            mostrarError(e.getMessage());
        }
        lstMercadeo.setOnItemClickListener(mSeleccion);
    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data)
    {
        if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
        {
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        }
        else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
        {
            if (data != null) {
                String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                if (mPresenta.existenAbonos())
                    mostrarError(mensajeError);
                else {
                    setResultado(Enumeradores.Resultados.RESULTADO_MAL, mensajeError);
                    finalizar();
                }
            }
        }
        else if (resultCode == Enumeradores.Resultados.RESULTADO_TERMINAR)
        {
            if (!mPresenta.existenAbonos())
            {
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }
        }
    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje)
    {
        if (tipoMensaje == 9 && respuesta == Enumeradores.RespuestaMsg.Si){
            mPresenta.eliminarMERDetalle(sMRDIdSeleccionado);
            mPresenta.refrescarMERDetalle();
        }
    }

   /* private void consultarCobranza(Cobranza.VistaCobranza abono)
    {
        try
        {
            HashMap<String, Cobranza.VistaCobranza> oParametros = new HashMap<String, Cobranza.VistaCobranza>();
            oParametros.put("Abono", abono);
            iniciarActividadConResultado(ICapturaCobranzaDocs.class, 0, Enumeradores.Acciones.ACCION_CONSULTAR_COBRANZA, oParametros);
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
    }*/

   /* private void generarCobranza()
    {
        try
        {
            iniciarActividadConResultado(ICapturaCobranzaDocs.class, 0, Enumeradores.Acciones.ACCION_GENERAR_COBRANZA);
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }

    }*/

    @Override
    public void setCliente(String cliente)
    {
        TextView texto = (TextView) findViewById(R.id.lblCliente);
        texto.setText(Mensajes.get("XCliente") + ": " + cliente);
    }

    @Override
    public void setRuta(String ruta)
    {
        TextView texto = (TextView) findViewById(R.id.lblRuta);
        texto.setText(Mensajes.get("XRuta") + ": " + ruta);
    }

    @Override
    public void setDia(String dia)
    {
        TextView texto = (TextView) findViewById(R.id.lblDia);
        texto.setText(Mensajes.get("XDiaTrabajo") + ": " + dia);
    }

}
