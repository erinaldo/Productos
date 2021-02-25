package com.amesol.routelite.vistas;

import java.util.List;
import java.util.Map;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.ConsultarCliente;
import com.amesol.routelite.presentadores.interfaces.IConsultaCliente;

public class ConsultaCliente extends Vista implements IConsultaCliente
{

	ConsultarCliente mPresenta;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);

		setContentView(R.layout.consulta_cliente);
		deshabilitarBarra(true);
		lblTitle.setText(Mensajes.get("XGeneralesCliente"));

		TextView lblMensaje = (TextView) findViewById(R.id.lblMensajes);
		lblMensaje.setText(Mensajes.get("XMensajesCte"));

		mPresenta = new ConsultarCliente(this);
		mPresenta.iniciar();
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

	public void iniciar()
	{

		// TODO Auto-generated method stub

	}

	private void mostrarGenerales(List<Map<String, String>> datosCliente)
	{
		//Datos del cliente
		ListView lstCliente = (ListView) findViewById(R.id.lstCliente);

		ListAdapter adapter = new SimpleAdapter(this, datosCliente, R.layout.lista_simple2,
				new String[]
				{ "descripcion", "valor" },
				new int[]
				{ R.id.texto1, R.id.texto2 });

		lstCliente.setAdapter(adapter);
	}

	public void mostrarDatosCliente(List<Map<String, String>> datosCliente, ISetDatos mensajes)
	{
		//Datos generales
		mostrarGenerales(datosCliente);

		//Mensajes
		ListView lstMensajes = (ListView) findViewById(R.id.lstMensajes);
		Cursor cMensajes = (Cursor) mensajes.getOriginal();
		@SuppressWarnings("deprecation")
		ListAdapter adapter2 = new SimpleCursorAdapter(this, R.layout.lista_simple1_ch, cMensajes,
				new String[]
				{ "Descripcion" },
				new int[]
				{ R.id.texto1 });
		lstMensajes.setAdapter(adapter2);
	}

	public void mostrarDatosCliente(List<Map<String, String>> datosCliente)
	{
		//Datos generales
		mostrarGenerales(datosCliente);

		TextView lblMensaje = (TextView) findViewById(R.id.lblMensajes);
		ListView lstMensajes = (ListView) findViewById(R.id.lstMensajes);

		lblMensaje.setVisibility(View.INVISIBLE);
		lstMensajes.setVisibility(View.INVISIBLE);

	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		// TODO Auto-generated method stub

	}

}
