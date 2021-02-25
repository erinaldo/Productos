package com.amesol.routelite.vistas;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;

import android.annotation.SuppressLint;
import android.app.SearchManager;
import android.content.DialogInterface;
import android.content.DialogInterface.OnCancelListener;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.os.SystemClock;
import android.text.format.DateFormat;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.Chronometer;
import android.widget.Chronometer.OnChronometerTickListener;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TiempoMuerto;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.RegistrarTiemposMuertos;
import com.amesol.routelite.presentadores.interfaces.IRegistroTiemposMuertos;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.generico.DialogoAlerta;

@SuppressLint("SimpleDateFormat")
public class RegistroTiemposMuertos extends Vista implements IRegistroTiemposMuertos
{

	RegistrarTiemposMuertos mPresenta;
	Chronometer cronometro;
	boolean terminar;
	TiempoMuerto tiempoMuerto;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.tiempos_muertos);
		deshabilitarBarra(true);
		setTitulo(Mensajes.get("XRegistrar", Mensajes.get("XTiemposMuertos")));

		TextView texto = (TextView) findViewById(R.id.lblMotivo);
		texto.setText(Mensajes.get("XMotivo"));

		texto = (TextView) findViewById(R.id.lblFechaInicioTitulo);
		texto.setText(Mensajes.get("XFechaIni") + ": ");

		texto = (TextView) findViewById(R.id.lblFechaInicio);
		texto.setText(Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss"));

		texto = (TextView) findViewById(R.id.lblFechaActualTitulo);
		texto.setText(Mensajes.get("XFechaActual") + ": ");

		texto = (TextView) findViewById(R.id.lblFechaActual);
		texto.setText(Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss"));

		//texto = (TextView) findViewById(R.id.lblTiempoTranscurrido);
		//texto.setText("00:00:00");
		cronometro = (Chronometer) findViewById(R.id.chronometer1);
		cronometro.setOnChronometerTickListener(mCronometro);
		cronometro.setText("00:00:00");

		Button boton = (Button) findViewById(R.id.btnIniciar);
		boton.setText(Mensajes.get("BTIniciar"));
		boton.setOnClickListener(mIniciar);

		boton = (Button) findViewById(R.id.btnRegresarTerminar);
		boton.setText(Mensajes.get("BTRegresar"));
		boton.setOnClickListener(mTerminar);

		terminar = false;
		tiempoMuerto = new TiempoMuerto();

		mPresenta = new RegistrarTiemposMuertos(this);
		mPresenta.iniciar();
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				Button boton = (Button) findViewById(R.id.btnIniciar);
				if (!boton.isEnabled()) //si esta deshabilitado no puede salir
					mostrarAdvertencia(Mensajes.get("I0228"));
				else
					this.finish();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	@SuppressWarnings("deprecation")
	@Override
	public void mostrarMotivos()
	{
		try
		{
			ISetDatos vis = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TIMMOT", Mensajes.get("XSeleccionar", new String[]
			{ Mensajes.get("XMotivo") }));
			Cursor valores = (Cursor) vis.getOriginal();
			startManagingCursor(valores);
			Spinner s = (Spinner) findViewById(R.id.cmbMotivos);
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, valores,
					new String[]
					{ SearchManager.SUGGEST_COLUMN_TEXT_1 },
					new int[]
					{ android.R.id.text1 });
			adapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
			s.setAdapter(adapter);
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}

	private OnClickListener mIniciar = new OnClickListener()
	{
		public void onClick(View v)
		{
			try
			{
				mPresenta.mIniciar();
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
				e.printStackTrace();
			}
		}
	};

	private OnClickListener mTerminar = new OnClickListener()
	{
		public void onClick(View v)
		{
			try
			{
				mPresenta.mTerminar();
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
				e.printStackTrace();
			}
		}
	};

	private OnChronometerTickListener mCronometro = new OnChronometerTickListener()
	{

		@Override
		public void onChronometerTick(Chronometer chronometer)
		{
			CharSequence text = chronometer.getText();
			if (text.length() == 5)
			{
				chronometer.setText("00:" + text);
			}
			else if (text.length() == 7)
			{
				chronometer.setText("0" + text);
			}

			//SimpleDateFormat dateFormatGmt = new SimpleDateFormat("dd/MM/yyyy hh:mm:ss");
			//dateFormatGmt.setTimeZone(TimeZone.getTimeZone("GMT"));
			//Calendar calendar = Calendar.getInstance();

			try
			{
				TextView texto = (TextView) findViewById(R.id.lblFechaInicio);
				Calendar c = Calendar.getInstance();
				//Date inicio = (new SimpleDateFormat("dd/MM/yyyy HH:mm:ss")).parse(texto.getText().toString());
				c.setTime((new SimpleDateFormat("dd/MM/yyyy HH:mm:ss")).parse(texto.getText().toString()));
				long inicial = c.getTimeInMillis();//Date.parse(texto.getText().toString());
				long tiempoTranscurrido = SystemClock.elapsedRealtime() - cronometro.getBase();
				texto = (TextView) findViewById(R.id.lblFechaActual);
				texto.setText(DateFormat.format("dd/MM/yyyy hh:mm:ss", inicial + tiempoTranscurrido));
			}
			catch (ParseException e)
			{
				mostrarError(e.getMessage());
			}
		}
	};

	public void iniciarCronometro()
	{
		try
		{
			TextView texto = (TextView) findViewById(R.id.lblFechaInicio);
			texto.setText(Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss"));
			cronometro.setBase(SystemClock.elapsedRealtime());
			cronometro.start();

			Spinner spin = (Spinner) findViewById(R.id.cmbMotivos);
			Cursor motivo = (Cursor) spin.getSelectedItem();
			SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss"); //usar formato de 24 hrs
			tiempoMuerto.TIMId = KeyGen.getId();
			tiempoMuerto.TipoMotivo = motivo.getInt(1);
			tiempoMuerto.DiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			tiempoMuerto.RUTClave = ((Ruta) Sesion.get(Campo.RutaActual)).RUTClave;
			tiempoMuerto.FechaHoraInicial = dateFormat.parse(texto.getText().toString());
		}
		catch (ParseException e)
		{
			mostrarError(e.getMessage());
		}
	}

	public void detenerCronometro()
	{
		try
		{
			cronometro.stop();

			SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss"); //usar formato de 24 hrs
			TextView texto = (TextView) findViewById(R.id.lblFechaActual);
			tiempoMuerto.FechaHoraFinal = dateFormat.parse(texto.getText().toString());
			tiempoMuerto.MFechaHora = dateFormat.parse(texto.getText().toString());
			tiempoMuerto.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			tiempoMuerto.Enviado = false;

			BDVend.guardarInsertar(tiempoMuerto);
			BDVend.commit();
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
	}

	public short getMotivo()
	{
		Spinner spin = (Spinner) findViewById(R.id.cmbMotivos);
		return (short) spin.getSelectedItemId();
	}

	public void mostrarMensajeRequerido()
	{
		TextView texto = (TextView) findViewById(R.id.lblMotivo);
		mostrarError(Mensajes.get("BE0001", new String[]
		{ texto.getText().toString() }));
	}

	public void cambiarVista()
	{
		Spinner spin = (Spinner) findViewById(R.id.cmbMotivos);
		spin.setEnabled(false);

		Button boton = (Button) findViewById(R.id.btnIniciar);
		boton.setEnabled(false);

		boton = (Button) findViewById(R.id.btnRegresarTerminar);
		boton.setText(Mensajes.get("BTTerminar"));
	}

	@SuppressWarnings("deprecation")
	public void mostrarTiempoRegistrado()
	{
		Button boton = (Button) findViewById(R.id.btnIniciar);
		if (boton.isEnabled()) //si esta habilitado puede salir
			finalizar();
		else
		{
			Spinner spin = (Spinner) findViewById(R.id.cmbMotivos);
			Cursor motivo = (Cursor) spin.getSelectedItem();

			DialogoAlerta dialogo = new DialogoAlerta(this, false, mCancelado);
			dialogo.setTitle(Mensajes.get("XTiempoRegistrado"));
			dialogo.setIcon(R.drawable.ic_menu_compose);
			String Horas = cronometro.getText().toString().substring(0, 2);
			String Minutos = cronometro.getText().toString().substring(3, 5);
			String Segundos = cronometro.getText().toString().substring(6, 8);
			if (!Horas.equals("00"))
			{
				if (Horas.equals("01"))
					dialogo.setMessage(motivo.getString(2) + "\n" + cronometro.getText() + " Hora");
				else
					dialogo.setMessage(motivo.getString(2) + "\n" + cronometro.getText() + " " + Mensajes.get("XHoras"));

			}
			else if (!Minutos.equals("00"))
			{
				if (Minutos.equals("01"))
					dialogo.setMessage(motivo.getString(2) + "\n" + cronometro.getText() + " Minuto");
				else
					dialogo.setMessage(motivo.getString(2) + "\n" + cronometro.getText() + " Minutos");
			}
			else if (!Segundos.equals("00"))
			{
				if (Segundos.equals("01"))
					dialogo.setMessage(motivo.getString(2) + "\n" + cronometro.getText() + " Segundo");
				else
					dialogo.setMessage(motivo.getString(2) + "\n" + cronometro.getText() + " Segundos");
			}
			String msgSi = "Aceptar";
			String msgNo = "Cancelar";
			dialogo.setButton(msgSi, new DialogInterface.OnClickListener()
			{
				public void onClick(DialogInterface dialog, int id)
				{
					terminar = true;
					respuestaMensaje(RespuestaMsg.OK, 0);
					dialog.dismiss();
				}
			});
			dialogo.setButton2(msgNo, new DialogInterface.OnClickListener()
			{
				public void onClick(DialogInterface dialog, int id)
				{
					terminar = false;
					dialog.dismiss();
					//					finalizar();

				}
			});
			dialogo.show();
		}
	}

	private OnCancelListener mCancelado = new OnCancelListener()
	{

		@Override	
		public void onCancel(DialogInterface dialog)
		{
			terminar = false;
			dialog.dismiss();
			//mostrarAdvertencia(Mensajes.get("I0228"));
		}
	};

	@Override
	public void iniciar()
	{

	}  

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{

	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if (respuesta == RespuestaMsg.OK && terminar)
		{
			detenerCronometro();
			finalizar();
			//guardar todo aqui
		}
	}

}
