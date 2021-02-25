package com.amesol.routelite.vistas;

import java.util.ArrayList;

import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Button;
import android.widget.ListView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.RecibirInformacion;
import com.amesol.routelite.presentadores.interfaces.IRecepcionInformacion;
import com.amesol.routelite.vistas.generico.ValorReferenciaAdapter;

public class RecepcionInformacion extends Vista implements IRecepcionInformacion
{

	RecibirInformacion mPresenta;
	String accion;
	String error;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);

		accion = getIntent().getAction();

		setContentView(R.layout.recepcion_informacion);
		deshabilitarBarra(true);

		Button boton = (Button) findViewById(R.id.btnContinuar);
		boton.setText(Mensajes.get("BtContinuar"));
		boton.setOnClickListener(mContinuar);
		setTitulo(Mensajes.get("MDB0212"));

		mPresenta = new RecibirInformacion(this, accion);
		mPresenta.iniciar();
	}

	@Override
	public void onResume()
	{
		super.onResume();

	}

	@Override
	public void onWindowFocusChanged(boolean hasFocus)
	{
		super.onWindowFocusChanged(hasFocus);
		if (error != null)
		{
			mostrarError(error);
			error = null;
		}
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{

		//		String accion = getIntent().getAction();
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.menu_solo_salir, menu);
		//if((accion!= null)&&(accion.equals(Enumeradores.Acciones.ACCION_CONFIGURAR_PUERTOS))) menu.getItem(0).setVisible(false);
		menu.getItem(0).setTitle(Mensajes.get("BTSalir"));
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{

		switch (item.getItemId())
		{
			case R.id.salir:
				finish();
				return false;
			default:
				return super.onOptionsItemSelected(item);
		}
	}

	private OnClickListener mContinuar = new OnClickListener()
	{

		public void onClick(View v)
		{
			mPresenta.recibirInformacion();
		}
	};

	public String obtenerTablas()
	{
		String tablas = "";
		ListView lista = (ListView) findViewById(android.R.id.list);
		ValorReferenciaAdapter adapter = (ValorReferenciaAdapter) lista.getAdapter();

		for (int i = 0; i < adapter.getCount(); i++)
		{
			if (adapter.isChecked(i))
			{
				switch (Integer.parseInt(adapter.getItem(i).getVavclave()))
				{
					case 8:
						tablas += "''Configuracion'',''ValorReferencia'',''VARValor'',''VAVDescripcion'',";
						break;
					case 9:
						tablas += "''Usuario'',";
						break;
					case 10:
						tablas += "''MENDetalle'',";
						break;
					case 11:
						tablas += "''ConfiguracionRecibo'',''Recibo'',''CORTabla'',''RECNota'',''RECEncabezadoPie'',''COTCampo'',''RECContenido'',''REODetalle'',";
						break;
					case 12:
						tablas += "''Vendedor'',";
						break;
				}
			}

		}

		if (!tablas.equals(""))
		{
			tablas = tablas.substring(0, tablas.length() - 1);
		}

		return tablas;
	}

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
					error = mensajeError;
					return;
				}
			}
			finish();
		}
		else
		{
			finish();
		}

	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
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

	public void presentarOpciones(ValorReferencia[] valores, String grupo)
	{
		ArrayList<ValorReferencia> Valores = new ArrayList<ValorReferencia>();

		for (int i = 0; i < valores.length; i++)
		{
			Valores.add(valores[i]);

		}
		ListView lista = (ListView) findViewById(android.R.id.list);
		lista.setTag(grupo);
		ValorReferenciaAdapter adapter = new ValorReferenciaAdapter(this, R.layout.elemento_checkbox, Valores);
		lista.setAdapter(adapter);
		lista.setOnItemClickListener(mSeleccionarItem);
	}

	private OnItemClickListener mSeleccionarItem = new OnItemClickListener()
	{
		public void onItemClick(AdapterView<?> parent, View v, int position, long id)
		{
			ValorReferenciaAdapter adapter = (ValorReferenciaAdapter) parent.getAdapter();
			adapter.setChecked(v, position);

		}
	};

	public void iniciar()
	{
		// TODO Auto-generated method stub

	}
}
