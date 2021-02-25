package com.amesol.routelite.vistas;

import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.controles.CapturaProducto;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.CapturarConteoInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaConteoInventario;

public class CapturaConteoInventario extends Vista implements ICapturaConteoInventario{

    CapturarConteoInventario mPresenta;
    CapturaProducto captura;

    String mAccion;


    @SuppressWarnings("unchecked")
    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        try
        {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();
            setContentView(R.layout.captura_conteo_inventario);
            deshabilitarBarra(true);

            TextView texto = (TextView) findViewById(R.id.lblProducto);
            texto.setText(Mensajes.get("XProducto"));

            texto = (TextView) findViewById(R.id.lblUnidad);
            texto.setText(Mensajes.get("XUnidad"));

            mPresenta.iniciar();

        }catch (Exception ex){

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
}
