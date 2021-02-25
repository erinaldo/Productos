package com.amesol.routelite.vistas;

import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;

import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.actividades.Cobranza.VistaCobranza;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.act.SeleccionarCobranza;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDocs;
import com.amesol.routelite.presentadores.interfaces.ISeleccionCobranza;
import com.amesol.routelite.vistas.generico.CobranzaAdapter;

public class SeleccionCobranza extends Vista implements ISeleccionCobranza
{

	SeleccionarCobranza mPresenta;
	String mAccion;

	boolean iniciarActividad;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();

			encenderBluetooth();

			setContentView(R.layout.seleccion_transaccion);
			deshabilitarBarra(true);

			lblTitle.setText(Mensajes.get("XCobranza"));
			Button btn = (Button) findViewById(R.id.btnContinuar);
			btn.setText(Mensajes.get("XContinuar"));
			btn.setOnClickListener(mContinuar);

			ListView lista = (ListView) findViewById(R.id.lstTransaccion);
			lista.setOnItemClickListener(mSeleccion);
			registerForContextMenu(lista);

			mPresenta = new SeleccionarCobranza(this, mAccion);
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
				setResult(Resultados.RESULTADO_BIEN);
				this.finish();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}
	
	
	

	@Override
	public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo)
	{
		super.onCreateContextMenu(menu, v, menuInfo);
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.context_lista_abonos, menu);

		menu.getItem(0).setTitle(Mensajes.get("XEliminar"));
	}

	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.getMenuInfo();
		ListView lista = (ListView) findViewById(R.id.lstTransaccion);

		CobranzaAdapter adapter = (CobranzaAdapter) lista.getAdapter();
		VistaCobranza abono = (VistaCobranza) lista.getItemAtPosition((int) info.position);

		if (mPresenta.eliminarCobranza(abono.getABNId()))
		{
			adapter.remove(abono);
			adapter.notifyDataSetChanged();
		}

		return true;
	}

	private OnItemClickListener mSeleccion = new OnItemClickListener()
	{
		public void onItemClick(AdapterView<?> parent, View v, int position, long id)
		{
			VistaCobranza abono = (VistaCobranza) parent.getItemAtPosition(position);
			consultarCobranza(abono);
		}
	};

	private OnClickListener mContinuar = new OnClickListener()
	{
		public void onClick(View v)
		{
			generarCobranza();
		}
	};

	@Override
	public void iniciar()
	{
		// TODO Auto-generated method stub
	}

	@Override
	public void mostrarCobranzaCliente(ArrayList<Cobranza.VistaCobranza> oAbonos)
	{
		// TODO Auto-generated method stub
		ListView lista = (ListView) findViewById(R.id.lstTransaccion);
		CobranzaAdapter adapter = new CobranzaAdapter(this, R.layout.lista_dividida2, oAbonos);
		lista.setAdapter(adapter);
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
		{
			//			mPresenta.actualizarCobranza();
			//TODO se cambio el actualizar por finalizar, verificar que no efecte en otra cosa.
			setResultado(Resultados.RESULTADO_BIEN);
			finalizar();
		}
		else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
		{
			String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
			if (mPresenta.existenAbonos())
				mostrarError(mensajeError);
			else
			{
				setResultado(Resultados.RESULTADO_MAL, mensajeError);
				finalizar();
			}
		}
		else if (resultCode == Enumeradores.Resultados.RESULTADO_TERMINAR)
		{
			if (!mPresenta.existenAbonos())
			{
				setResultado(Resultados.RESULTADO_BIEN);
				finalizar();
			}
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		// TODO Auto-generated method stub
	}

	private void consultarCobranza(VistaCobranza abono)
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
	}

	private void generarCobranza()
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

	}

	@Override
	public void setCliente(String cliente)
	{
		TextView texto = (TextView) findViewById(R.id.lblCliente);
		texto.setText(cliente);
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
