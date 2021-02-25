package com.amesol.routelite.vistas;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.util.Log;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.MeasureSpec;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemLongClickListener;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.VendedorMensaje;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.TipoEnvioInfo;
import com.amesol.routelite.presentadores.act.RevisarPendientes;
import com.amesol.routelite.presentadores.interfaces.IPullRefresh;
import com.amesol.routelite.presentadores.interfaces.IRevisionPendientes;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.utilerias.Generales;

@SuppressLint("NewApi")
public class RevisionPendientes extends Vista implements IRevisionPendientes, IPullRefresh
{
	RevisarPendientes mPresenta;
	ISetDatos estados;
	String fechaActual;
	ListView lista;
	String seleccion;
	boolean envioPendientesTerminado;
	boolean huboError;
	boolean enviarRecibir;
	String mensajesInformativos ="";
	HashMap<String, Object> oParametros = null;

	@SuppressWarnings(
	{ "deprecation", "unchecked" })
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			setContentView(R.layout.revisar_pendientes);
			deshabilitarBarra(true);
			setTitulo(Mensajes.get("XMisPendientes"));

			Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
			TextView texto = (TextView) findViewById(R.id.lblVendedor);
			texto.setText("Nombre del Vendedor: " + vendedor.Nombre);

			fechaActual = Generales.getFechaHoraActualStr("dd/MM/yyyy");

			texto = (TextView) findViewById(R.id.lblFecha);
			texto.setText("Dia de Trabajo: " + Mensajes.get("XFecha"));

			estados = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("CLMPOSPO", "");

			startManagingCursor((Cursor) estados.getOriginal());
			/*
			 * ISetDatos mensajes =
			 * Consultas2.ConsultasVendedorMensaje.obtenerMensajes(); Cursor c =
			 * (Cursor) mensajes.getOriginal(); startManagingCursor(c);
			 */

			lista = (ListView) findViewById(R.id.lstPendientes);
			/*
			 * SimpleCursorAdapter adapter = new SimpleCursorAdapter(this,
			 * R.layout.elemento_revisar_pendientes, c, new
			 * String[]{"Asunto","MFechaHora","Posponer","Descripcion"}, new
			 * int[
			 * ]{R.id.txtAsunto,R.id.txtFecha,R.id.txtEstado,R.id.txtDescripcion No existen datos para
			 * }); adapter.setViewBinder(new vista());
			 * lista.setAdapter(adapter);
			 */
			// lista.setOnDragListener(l)
			mostrarMensajes();
			registerForContextMenu(lista);
			lista.setOnItemLongClickListener(menu);
			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
				enviarRecibir = (Boolean) oParametros.get("enviarRecibir");
				huboError = (Boolean) oParametros.get("huboError");
				envioPendientesTerminado = (Boolean) oParametros.get("envioPendientesTerminado");
			}
			else
				enviarRecibir = false;
			mPresenta = new RevisarPendientes(this);
			mPresenta.iniciar();
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
	}

	/*
	 * public void clickHandler(View v){ int viewId = v.getId(); switch(viewId){
	 * case R.id.txtDescripcion: openContextMenu(lista); break; } }
	 */
	public void mostrarMensajes()
	{
		try
		{
			/*
			 * ISetDatos mensajes =
			 * Consultas2.ConsultasVendedorMensaje.obtenerMensajes();
			 * if(mensajes != null){ Cursor c = (Cursor) mensajes.getOriginal();
			 * startManagingCursor(c);
			 * 
			 * SimpleCursorAdapter adapter = new SimpleCursorAdapter(this,
			 * R.layout.elemento_revisar_pendientes, c, new
			 * String[]{"Asunto","MFechaHora","Posponer","Descripcion"}, new
			 * int[
			 * ]{R.id.txtAsunto,R.id.txtFecha,R.id.txtEstado,R.id.txtDescripcion
			 * }); adapter.setViewBinder(new vista());
			 * lista.setAdapter(adapter); }
			 * 
			 * SimpleCursorAdapter adapter = new SimpleCursorAdapter(this,
			 * R.layout.elemento_revisar_pendientes, c, new
			 * String[]{"Asunto","MFechaHora","Posponer","Descripcion"}, new
			 * int[
			 * ]{R.id.txtAsunto,R.id.txtFecha,R.id.txtEstado,R.id.txtDescripcion
			 * }); adapter.setViewBinder(new vista());
			 * lista.setAdapter(adapter);
			 */
			pendientes[] mensajes = Consultas.ConsultasVendedorMensaje.obtenerListaMensajes();
			if (mensajes != null)
			{
				PendientesAdapter adapter = new PendientesAdapter(this, R.layout.elemento_revisar_pendientes, mensajes);
				lista.setAdapter(adapter);
			}
			else
			{
				// Message to cause back //-- this is an elopez implementation
				// --//
			}
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
	}

	public OnItemLongClickListener menu = new OnItemLongClickListener()
	{
		@Override
		public boolean onItemLongClick(AdapterView<?> arg0, View arg1, int arg2, long arg3)
		{
			seleccion = arg1.getTag().toString(); // recuperar VendedorMensajeId
													// para modificar estado
			openContextMenu(lista);
			return true;
		}
	};

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				mPresenta.toActividadesVed();
				finalizar();
				return true;
		}
		return super.onKeyDown(keyCode, event);

		// return false;
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.menu_revision_pendientes, menu);
		menu.getItem(0).setTitle("Enviar y Recibir"); // Mensajes.get("BTNuevo"));
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{
		switch (item.getItemId())
		{
			case R.id.enviar_recibir:
				envioPendientesTerminado = false;
				huboError = false;
				enviarRecibir = true;
				mensajesInformativos = "";
				HashMap<String, String> oParametros = new HashMap<String, String>();
				oParametros.put("TipoEnvioInfo", String.valueOf(TipoEnvioInfo.ENVIO_PENDIENTES_VENDEDOR));
				oParametros.put("Continuar", "true");
				iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_ENVIAR_BD_VENDEDOR, oParametros);
				return true;
			default:
				return super.onOptionsItemSelected(item);
		}
	}

	@Override
	public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo)
	{
		if (v.getId() == R.id.lstPendientes)
		{
			estados.moveToFirst();
			do
			{
				menu.add(Menu.NONE, estados.getInt(0), estados.getPosition(), estados.getString(2));
			}
			while (estados.moveToNext());
		}
	}

	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		try
		{
			int estadoSeleccionado = item.getItemId();
			VendedorMensaje mensaje = new VendedorMensaje();
			mensaje.VendedorMensajeId = seleccion;
			BDVend.recuperar(mensaje);
			mensaje.Posponer = estadoSeleccionado;
			mensaje.Enviado = false;
			mensaje.MFechaHora = Generales.getFechaHoraActual();
			mensaje.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			BDVend.guardarInsertar(mensaje);
			BDVend.commit();
			mostrarMensajes();
			return true;
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
			return false;
		}
	}

	@Override
	public void iniciar()
	{
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if (requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES)
		{
			if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
			{
				mensajesInformativos += (String) data.getExtras().getString("mensajeIniciar") + "\n";
				if (mensajesInformativos != null && !mensajesInformativos.equals(""))
				{
					finalizar();
					huboError = true;
					HashMap<String, Object> oParam = new HashMap<String, Object>();
					oParam.put("huboError", huboError);
					oParam.put("enviarRecibir", enviarRecibir);
					oParam.put("envioPendientesTerminado", envioPendientesTerminado);
					iniciarActividad(IRevisionPendientes.class, null, mensajesInformativos, false, oParam);
				}
			}
			else if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN && !envioPendientesTerminado)
			{
				if (data != null && data.getExtras()!=null && data.getExtras().containsKey("mensajeIniciar")){
					mensajesInformativos += (String) data.getExtras().getString("mensajeIniciar") + "\n";					
				}
				iniciarActualizacion();		
			}
			else if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN && envioPendientesTerminado)
			{	
				mostrarMensajes();
			}
		}
	}

	private void iniciarActualizacion()
	{
		HashMap<String, String> parametros = new HashMap<String, String>();
		parametros.put("Tablas", "''MDBMensaje'',''VendedorMensaje''");
		iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_RECIBIR_PENDIENTES, parametros);
		envioPendientesTerminado = true;
		enviarRecibir = false;
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if (respuesta == RespuestaMsg.OK && huboError && enviarRecibir && !envioPendientesTerminado)
		{
			iniciarActualizacion();
			huboError = false;
		}
	}

	public static class pendientes
	{
		public String VendedorMensajeId;
		public String Asunto;
		public Date Fecha;
		public int Posponer;
		public String Descripcion;
	}

	private class PendientesAdapter extends ArrayAdapter<pendientes>
	{
		int textViewResourceId;
		LayoutInflater inflater;
		pendientes[] objetos;
		View fila;

		public PendientesAdapter(Context context, int textViewResourceId, pendientes[] objects)
		{
			super(context, textViewResourceId, objects);
			this.textViewResourceId = textViewResourceId;
			objetos = objects;
			inflater = LayoutInflater.from(context);
		}

		@Override
		public int getViewTypeCount()
		{
			return objetos.length;
		}

		@Override
		public int getItemViewType(int position)
		{
			return position;
		}

		@SuppressLint("SimpleDateFormat")
		@Override
		public View getView(int position, View convertView, ViewGroup parent)
		{
			try
			{
				fila = convertView;
				if (convertView == null)
				{
					fila = inflater.inflate(textViewResourceId, null);
					pendientes mensaje = getItem(position);
					TextView texto = (TextView) fila.findViewById(R.id.txtAsunto);
					texto.setText(mensaje.Asunto);

					texto = (TextView) fila.findViewById(R.id.txtFecha);
					try
					{
						Date fecha = mensaje.Fecha;
						String _fecha = new SimpleDateFormat("dd/MM/yyyy hh:mm a").format(fecha);
/*						if (_fecha.equals(fechaActual))
						{
							_fecha = new SimpleDateFormat("hh:mm a").format(fecha);
						}*/
						texto.setText(_fecha);
					}
					catch (Exception e)
					{
						mostrarError(e.getMessage());
					}
					texto = (TextView) fila.findViewById(R.id.txtEstado);
					if (mensaje.Posponer > 0)
					{
						estados.moveToPosition(mensaje.Posponer - 1);
						texto.setText(estados.getString(2));
					}
					else
						texto.setText("		");
					texto = (TextView) fila.findViewById(R.id.txtDescripcion);
					texto.setText(mensaje.Descripcion);
					texto.setTag(mensaje.VendedorMensajeId);
					ImageButton btn = (ImageButton) fila.findViewById(R.id.btnMasMenos);
					btn.setOnClickListener(new OnClickListener()
					{
						@Override
						public void onClick(View v)
						{
							View parent = (View) v.getParent().getParent();
							ListView lst = lista;// (ListView)
													// parent.findViewById(R.id.lstPendientes);
							LinearLayout lay = (LinearLayout) parent.findViewById(R.id.layDetalle);
							if (lay.getVisibility() == View.GONE)
							{
								// lst.setVisibility(View.VISIBLE);
								lay.setVisibility(View.VISIBLE);
								((ImageButton) v).setImageResource(R.drawable.ic_menu_contraer);
								if (lst.getTag() == null)
									setListViewHeightBasedOnChildren(lst);
							}
							else
							{
								// lst.setVisibility(View.GONE);
								lay.setVisibility(View.GONE);
								((ImageButton) v).setImageResource(R.drawable.ic_menu_more);
							}
						}
					});
				}
				return fila;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		private void setListViewHeightBasedOnChildren(ListView listView)
		{
			ListAdapter listAdapter = listView.getAdapter();
			if (listAdapter == null)
			{
				// pre-condition
				return;
			}
			int totalHeight = 0;
			int desiredWidth = MeasureSpec.makeMeasureSpec(listView.getWidth(), MeasureSpec.AT_MOST);
			for (int i = 0; i < listAdapter.getCount(); i++)
			{
				View listItem = listAdapter.getView(i, null, listView);
				listItem.measure(desiredWidth, MeasureSpec.UNSPECIFIED);
				totalHeight += listItem.getMeasuredHeight();
			}
			ViewGroup.LayoutParams params = listView.getLayoutParams();
			params.height = totalHeight + (listView.getDividerHeight() * (listAdapter.getCount() - 1));
			listView.setLayoutParams(params);
			listView.requestLayout();
			listView.setTag(true);
		}
	}

	/*
	 * private class vista implements ViewBinder{
	 * 
	 * @Override public boolean setViewValue(View view, Cursor cursor, int
	 * columnIndex) { int viewId = view.getId(); switch(viewId){ case
	 * R.id.txtEstado: TextView text = (TextView) view;
	 * if(cursor.getInt(columnIndex) > 0){
	 * estados.moveToPosition(cursor.getInt(columnIndex) - 1);
	 * text.setText(estados.getString(2)); }else text.setText("");
	 * 
	 * //if(text.getTag() == null){ ImageButton btn = (ImageButton)
	 * view.getRootView().findViewById(R.id.btnMasMenos); text.setTag(true);
	 * btn.setOnClickListener(new OnClickListener() {
	 * 
	 * @Override public void onClick(View v) { View parent = (View)
	 * v.getParent().getParent().getParent(); ListView lst = (ListView)
	 * parent.findViewById(R.id.lstPendientes); LinearLayout lay =
	 * (LinearLayout) parent.findViewById(R.id.layDetalle);
	 * 
	 * if (lay.getVisibility() == View.GONE) {
	 * //lst.setVisibility(View.VISIBLE); lay.setVisibility(View.VISIBLE);
	 * ((ImageButton) v).setImageResource(R.drawable.ic_menu_contraer);
	 * if(lst.getTag()==null) setListViewHeightBasedOnChildren(lst); } else {
	 * //lst.setVisibility(View.GONE); lay.setVisibility(View.GONE);
	 * ((ImageButton) v).setImageResource(android.R.drawable.ic_menu_more);
	 * 
	 * } } }); //} break; case R.id.txtFecha: try { Date fecha = new
	 * SimpleDateFormat
	 * ("yyyy-MM-dd hh:mm:ss").parse(cursor.getString(columnIndex)); String
	 * _fecha = new SimpleDateFormat("dd/MM/yyyy").format(fecha);
	 * if(_fecha.equals(fechaActual)){ _fecha = new
	 * SimpleDateFormat("hh:mm a").format(fecha); } TextView txt = (TextView)
	 * view; txt.setText(_fecha); } catch (Exception e) {
	 * mostrarError(e.getMessage()); } break; case R.id.txtDescripcion: TextView
	 * desc = (TextView) view; desc.setText(cursor.getString(columnIndex));
	 * desc.setTag(cursor.getString(0)); //guardar VendedorMensajeId en el tag
	 * break; default: TextView texto = (TextView) view;
	 * texto.setText(cursor.getString(columnIndex)); break; } return true; }
	 * 
	 * 
	 * private void setListViewHeightBasedOnChildren(ListView listView) {
	 * ListAdapter listAdapter = listView.getAdapter(); if (listAdapter == null)
	 * { // pre-condition return; }
	 * 
	 * int totalHeight = 0; int desiredWidth =
	 * MeasureSpec.makeMeasureSpec(listView.getWidth(), MeasureSpec.AT_MOST);
	 * for (int i = 0; i < listAdapter.getCount(); i++) { View listItem =
	 * listAdapter.getView(i, null, listView); listItem.measure(desiredWidth,
	 * MeasureSpec.UNSPECIFIED); totalHeight += listItem.getMeasuredHeight(); }
	 * 
	 * ViewGroup.LayoutParams params = listView.getLayoutParams(); params.height
	 * = totalHeight + (listView.getDividerHeight() * (listAdapter.getCount() -
	 * 1));
	 * 
	 * listView.setLayoutParams(params); listView.requestLayout();
	 * listView.setTag(true); } }
	 */

	@Override
	public void PullingToRefech()
	{
		Log.i("i get the pull", "came on!!!!");
	}
}
