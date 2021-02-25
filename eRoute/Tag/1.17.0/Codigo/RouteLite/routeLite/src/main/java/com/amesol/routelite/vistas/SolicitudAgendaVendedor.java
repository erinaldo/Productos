package com.amesol.routelite.vistas;

import java.util.Date;

import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.SolicitarAgendaVendedor;
import com.amesol.routelite.presentadores.interfaces.ISolicitudAgendaVendedor;

public class SolicitudAgendaVendedor extends Vista implements ISolicitudAgendaVendedor
{

	SolicitarAgendaVendedor mPresenta;
    boolean noFechaFinAgenda = false;
    boolean FechaInicialAgendaNoMenor = false;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.solicitud_agenda_vendedor);
		deshabilitarBarra(true);
		TextView texto = (TextView) findViewById(R.id.lblFechaInicial);
		texto.setText(Mensajes.get("PRMFechaInicial"));
		texto = (TextView) findViewById(R.id.lblFechaFinal);
		texto.setText(Mensajes.get("PRMFechaFinal"));
		Button boton = (Button) findViewById(R.id.btnContinuar2);
		boton.setText(Mensajes.get("BtContinuar"));
		boton.setOnClickListener(mContinuar);
		setTitulo(Mensajes.get("XSolicitarAgenda"));

		mPresenta = new SolicitarAgendaVendedor(this);
        try {
            if (BDVend.estaAbierta() && Sesion.get(Sesion.Campo.MOTConfiguracion) != null) {
                if (((MOTConfiguracion) Sesion.get(Sesion.Campo.MOTConfiguracion)).get("NoFechaFinAgenda").equals("1")) {
                    noFechaFinAgenda = true;
                    texto.setVisibility(View.INVISIBLE);
                    DatePicker dpFechaFin = (DatePicker) findViewById(R.id.dpFechaFinal);
                    dpFechaFin.setVisibility(View.INVISIBLE);
                }
            } else {
                mPresenta.recuperarParametroNoFechaFinAgenda();
            }
        }catch(Exception ex){
            mostrarError("Error al leer el parámetro NoFechaFinAgenda ");
        }

        try {
            if (BDVend.estaAbierta() && Sesion.get(Sesion.Campo.MOTConfiguracion) != null) {
                if (((MOTConfiguracion) Sesion.get(Sesion.Campo.MOTConfiguracion)).get("FechaInicialAgendaNoMenor").equals("1")) {
                    FechaInicialAgendaNoMenor = true;
                }
            } else {
                mPresenta.recuperarParametroFechaInicialAgendaNoMenor();
            }
        }catch(Exception ex){
            mostrarError("Error al leer el parámetro FechaInicialAgendaNoMenor ");
        }

		mPresenta.iniciar();

        if (Sesion.get(Sesion.Campo.MensajeEntrePantalla) != null && !Sesion.get(Sesion.Campo.MensajeEntrePantalla).toString().equals("")){
            mostrarAdvertencia(Sesion.get(Sesion.Campo.MensajeEntrePantalla).toString());
            Sesion.set(Sesion.Campo.MensajeEntrePantalla,"");
        }
	}

	private OnClickListener mContinuar = new OnClickListener()
	{

		public void onClick(View v)
		{
			DatePicker dp = (DatePicker) findViewById(R.id.dpFechaInicial);

			dp.requestFocus();
			mPresenta.solicitarAgenda();
		}
	};

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES) && (resultCode == Enumeradores.Resultados.RESULTADO_MAL))
		{
			if (data != null)
			{
				String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
				if (mensajeError != null)
				{
					iniciarActividad(ISolicitudAgendaVendedor.class, mensajeError);
					return;
				}
			}
			iniciarActividad(ISolicitudAgendaVendedor.class);

		}else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_PARAMETRO_NOFECHAFINAGENDA))
        {

            try {
                if (resultCode == Enumeradores.Resultados.RESULTADO_MAL) {
                    mostrarError("Error al recuperar el parámetro NoFechaFinAgenda ");
                }else{
                    if (data != null) {
                        if (data.getExtras().getString("mensajeIniciar").equalsIgnoreCase("true")) {
                            noFechaFinAgenda = true;
                            TextView texto = (TextView) findViewById(R.id.lblFechaFinal);
                            texto.setVisibility(View.INVISIBLE);
                            DatePicker dpFechaFin = (DatePicker) findViewById(R.id.dpFechaFinal);
                            dpFechaFin.setVisibility(View.INVISIBLE);
                        }
                    }
                }
            }catch(Exception ex){
                mostrarError("Error al leer el parámetro NoFechaFinAgenda ");
            }
        }else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_PARAMETRO_FECHAINICIALAGENDANOMENOR)){
            try {
                if (resultCode == Enumeradores.Resultados.RESULTADO_MAL) {
                    mostrarError("Error al recuperar el parámetro FechaInicialAgendaNoMenor ");
                }else{
                    if (data != null) {
                        if (data.getExtras().getString("mensajeIniciar").equalsIgnoreCase("true")) {
                            FechaInicialAgendaNoMenor = true;
                        }
                    }
                }
            }catch(Exception ex){
                mostrarError("Error al leer el parámetro FechaInicialAgendaNoMenor ");
            }
        }
		else
		{
			this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN, "NuevaAgenda");
			finish();
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		// TODO Auto-generated method stub

	}

	public void iniciar()
	{
		// TODO Auto-generated method stub

	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				this.finish();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

    public boolean getNoFechaFinAgenda(){
        return noFechaFinAgenda;
    }

    public boolean getFechaInicialAgendaNoMenor(){
        return FechaInicialAgendaNoMenor;
    }

	@SuppressWarnings("deprecation")
	public Date getFechaInicial()
	{
		DatePicker fecha = (DatePicker) findViewById(R.id.dpFechaInicial);
		return new Date(fecha.getYear() - 1900, fecha.getMonth(), fecha.getDayOfMonth());
	}

	@SuppressWarnings("deprecation")
	public Date getFechaFinal()
	{
		DatePicker fecha = (DatePicker) findViewById(R.id.dpFechaFinal);
		return new Date(fecha.getYear() - 1900, fecha.getMonth(), fecha.getDayOfMonth());
	}

	@SuppressWarnings("deprecation")
	public void setFechaInicial(Date fecha)
	{
		DatePicker control = (DatePicker) findViewById(R.id.dpFechaInicial);
		control.updateDate(fecha.getYear(), fecha.getMonth(), fecha.getDay());
	}

	@SuppressWarnings("deprecation")
	public void setFechaFinal(Date fecha)
	{
		DatePicker control = (DatePicker) findViewById(R.id.dpFechaFinal);
		control.updateDate(fecha.getYear(), fecha.getMonth(), fecha.getDay());
	}

}
