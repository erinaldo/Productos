package com.amesol.routelite.vistas;

import java.util.HashMap;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Button;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.SeleccionarVisita;
import com.amesol.routelite.presentadores.interfaces.ISeleccionVisita;
import com.amesol.routelite.presentadores.parcelables.DatosGPS;

public class SeleccionVisita extends Vista implements ISeleccionVisita
{

	SeleccionarVisita mPresenta;
	String mAccion;
	Vendedor oVendedor;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();

			HashMap<String, Object> oParametros = null;

			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
			}

			setContentView(R.layout.seleccion_visita);
			deshabilitarBarra(true);

			setTitulo(Mensajes.get("XSeleccionar", Mensajes.get("XVisita")));
			Button btn = (Button) findViewById(R.id.btnNuevaVisita);
			btn.setText(Mensajes.get("XNuevaVisita"));
			btn.setOnClickListener(mNuevaVisita);

			Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

			TextView texto = (TextView) findViewById(R.id.lblCliente);
			texto.setText(cliente.Clave + " - " + cliente.RazonSocial);

			texto = (TextView) findViewById(R.id.lblRuta);
			texto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion);

			texto = (TextView) findViewById(R.id.lblDia);
			texto.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);

			ListView lista = (ListView) findViewById(R.id.lstVisitas);
			registerForContextMenu(lista);

			oVendedor = (Vendedor) Sesion.get(Campo.VendedorActual);

			mPresenta = new SeleccionarVisita(this, mAccion);
			mPresenta.setParametros(oParametros);
			mPresenta.iniciar();
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
			e.printStackTrace();
		}
	}

	@Override
	public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo)
	{
		super.onCreateContextMenu(menu, v, menuInfo);
		MenuInflater inflater = getMenuInflater();
		AdapterContextMenuInfo info = (AdapterContextMenuInfo) menuInfo;
		ListView lista = (ListView) findViewById(R.id.lstVisitas);
		Cursor visita = (Cursor) lista.getItemAtPosition((int) info.position);
		menu.setHeaderTitle(visita.getString(2));
		menu.setHeaderIcon(android.R.drawable.ic_menu_agenda);

		inflater.inflate(R.menu.context_manto_visitas, menu);

		menu.getItem(0).setTitle(Mensajes.get("XResumenMov"));
	}

	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.getMenuInfo();
		ListView lista = (ListView) findViewById(R.id.lstVisitas);
		Cursor visita = (Cursor) lista.getItemAtPosition((int) info.position);

		switch (item.getItemId())
		{
			case R.id.resumenmovs:
				// TODO: falta agregar el metodo que va a llamar la actividad
				mPresenta.mostrarResumen(visita);
				// iniciarActividad(IResumenMovVisita.class, false);
				return true;
			default:
				return super.onOptionsItemSelected(item);
		}

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

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{

		if (requestCode == Enumeradores.Solicitudes.SOLICITUD_GPS)
		{

			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				DatosGPS datosGps;
				datosGps = (DatosGPS) data.getExtras().getParcelable("Objeto");

				mPresenta.ValidarDatosGPS(datosGps);

			}
			else
			{
				mPresenta.iniciarVisita();
			}
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if (tipoMensaje == 1)
		{
			if (respuesta.equals(RespuestaMsg.Si))
			{
				mPresenta.IniciarGPS();
				return;
			}
			else if (respuesta.equals(RespuestaMsg.No))
			{
				mPresenta.iniciarVisita();
				// iniciarActividad(ISeleccionVisita.class,
				// Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null,
				// false);
			}
		}

	}

	@SuppressWarnings("deprecation")
	public void mostrarVisitasCliente(ISetDatos visitas)
	{
		ListView lista = (ListView) findViewById(R.id.lstVisitas);
		Cursor cVisitas = (Cursor) visitas.getOriginal();
		startManagingCursor(cVisitas);
		ListAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple3, cVisitas, new String[]
		{ "Descripcion", "FechaHoraInicial", "FechaHoraFinal" }, new int[]
		{ R.id.texto1, R.id.texto2, R.id.texto3 });
		lista.setAdapter(adapter);
		lista.setOnItemClickListener(mSeleccion);
	}

	public void iniciar()
	{

	}

	private OnItemClickListener mSeleccion = new OnItemClickListener()
	{

		public void onItemClick(AdapterView<?> parent, View v, int position, long id)
		{

			if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA)))
			{
				Cursor visita = (Cursor) parent.getItemAtPosition(position);
				visita.moveToPosition(position);
				String sVisitaClave = visita.getString(1);
				mPresenta.seleccionarVisita(sVisitaClave);
			}
		}
	};

	private OnClickListener mNuevaVisita = new OnClickListener()
	{
		public void onClick(View v)
		{
			if ((mAccion != null))
			{
				mPresenta.seleccionarNueva();
			}
		}
	};

}
