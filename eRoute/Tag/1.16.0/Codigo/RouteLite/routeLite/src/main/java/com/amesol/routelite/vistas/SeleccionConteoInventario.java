package com.amesol.routelite.vistas;

import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.SeleccionarConteoInventario;
import com.amesol.routelite.presentadores.interfaces.ISeleccionConteoInventario;

public class SeleccionConteoInventario  extends Vista implements ISeleccionConteoInventario {
    SeleccionarConteoInventario mPresenta;
    String mAccion;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        try
        {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.seleccion_transaccion);
            deshabilitarBarra(true);

            lblTitle.setText(Mensajes.get("XAConteoInv"));
            Button btn = (Button) findViewById(R.id.btnContinuar);
            btn.setText(Mensajes.get("XContinuar"));
            btn.setOnClickListener(mContinuar);

            TextView mTexto;
            mTexto = (TextView) findViewById(R.id.lblRuta);
            mTexto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Descripcion);
            mTexto = (TextView) findViewById(R.id.lblDia);
            mTexto.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);
            mTexto = (TextView) findViewById(R.id.lblCliente);
            mTexto.setVisibility(View.GONE);

            ListView lista = (ListView) findViewById(R.id.lstTransaccion);
            lista.setOnItemClickListener(mSeleccion);
            registerForContextMenu(lista);

            mPresenta = new SeleccionarConteoInventario(this, mAccion);
            mPresenta.iniciar();
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
    }

    @Override
    public void iniciar() {

    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {

    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {

    }

    private View.OnClickListener mContinuar = new View.OnClickListener()
    {
        public void onClick(View v)
        {

        }
    };

    private AdapterView.OnItemClickListener mSeleccion = new AdapterView.OnItemClickListener()
    {
        public void onItemClick(AdapterView<?> parent, View v, int position, long id)
        {

        }
    };

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event)
    {
        switch (keyCode)
        {
            case KeyEvent.KEYCODE_BACK:
                this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                this.finalizar();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }
}
