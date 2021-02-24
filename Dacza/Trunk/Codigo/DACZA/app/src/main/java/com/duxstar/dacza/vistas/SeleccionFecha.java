package com.duxstar.dacza.vistas;

import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;

import com.duxstar.dacza.R;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.act.SeleccionarFecha;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionFecha;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

public class SeleccionFecha extends Vista implements ISeleccionFecha
{
    SeleccionarFecha mPresenta;
    String mAccion;

    @SuppressWarnings("deprecation")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        try {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.seleccion_fecha);
            deshabilitarBarra(true);
            setTitulo("Inicio de Jornada");

            Button btn = (Button) findViewById(R.id.btnContinuar);
            btn.setText("Continuar");
            btn.setOnClickListener(mContinuar);


            mPresenta = new SeleccionarFecha(this, mAccion);
            mPresenta.iniciar();
            //mPresenta.mostrarOrdenes(Enumeradores.Vista.VISTA_CAPTURA);
        } catch (Exception e) {
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
                this.finalizar();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data)
    {

    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        super.onActivityResult(requestCode, resultCode, data);
    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje)
    {

    }

    public void iniciar()
    {

    }

    public void setFecha(String fecha)
    {
        DatePicker dpFecha = (DatePicker) findViewById(R.id.dpFecha);
        String[] sFecha = fecha.split("/");
        dpFecha.updateDate(Integer.parseInt(sFecha[0]), Integer.parseInt(sFecha[1])-1, Integer.parseInt(sFecha[2]));
    }

    public String getFecha()
    {
        DatePicker dpFecha = (DatePicker) findViewById(R.id.dpFecha);
        return String.format("%04d", dpFecha.getYear()) + "/" + String.format("%02d", dpFecha.getMonth()+1)  + "/" + String.format("%02d", dpFecha.getDayOfMonth());
    }

    private View.OnClickListener mContinuar = new View.OnClickListener() {
        public void onClick(View v) {
            mPresenta.Continuar();
        }
    };
}
