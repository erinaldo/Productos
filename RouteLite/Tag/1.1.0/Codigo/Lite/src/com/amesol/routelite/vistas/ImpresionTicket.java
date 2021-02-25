package com.amesol.routelite.vistas;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.ImprimirTicket;
import com.amesol.routelite.presentadores.interfaces.IImpresionTicket;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;


public class ImpresionTicket extends Vista implements IImpresionTicket
{

	ImprimirTicket mPresenta;
	String accion;
	String error;
	String folioActualVista = "";

	public static final int PREGUNTA_REINTENTAR_IMPRESION = 99;
	List<Map<String, String>> mDocumentosSeleccionados;

	HashMap<String, Boolean > listadoDocumentos  = new HashMap<String,Boolean>();
	
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);

		accion = getIntent().getAction();
		setContentView(R.layout.seleccion_transaccion);
		deshabilitarBarra(true);

		setTitulo(Mensajes.get("XImpresion"));
		if (!accion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))
		{
			TextView lblCliente = (TextView) findViewById(R.id.lblCliente);
			lblCliente.setVisibility(View.GONE);
			TextView lblRuta = (TextView) findViewById(R.id.lblRuta);
			lblRuta.setVisibility(View.GONE);
			TextView lblDia = (TextView) findViewById(R.id.lblDia);
			lblDia.setVisibility(View.GONE);
		}

		Button boton = (Button) findViewById(R.id.btnContinuar);
		boton.setText(Mensajes.get("BtContinuar"));
		boton.setOnClickListener(mContinuar);
		setTitulo(Mensajes.get("MDB0212"));

		mPresenta = new ImprimirTicket(this, accion);
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
			mDocumentosSeleccionados = getDocumentosSeleccionados();
			if (mDocumentosSeleccionados.size() > 0)
			{
				try
				{
					if (!bluetoothEncendido())
					{
						encenderBluetooth();
					}
					else
					{
						imprimirRecibos();
					}
					//getVista().mostrarAdvertencia("Recibos generados");
				}
				catch (ControlError e)
				{
					e.Mostrar(getVista());
				}
				catch (Exception e)
				{
					getVista().mostrarError(e.getMessage());
				}
			}
			else
			{
				mostrarAdvertencia(Mensajes.get("E0161", Mensajes.get("XMovimiento")));
			}
		}
	};

	private Vista getVista()
	{
		return this;
	}

	private void imprimirRecibos() throws Exception
	{
		Recibos recibos = new Recibos();
		recibos.imprimirRecibos(mDocumentosSeleccionados, false, mPresenta.getIVista());
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
		else if (requestCode == REQUEST_ENABLE_BT)
		{
			if (resultCode == RESULT_OK)
			{
				try
				{
					imprimirRecibos();
				}
				catch (ControlError e)
				{
					e.Mostrar(getVista());
				}
				catch (Exception e)
				{
					getVista().mostrarError(e.getMessage());
				}

			}
			else
			{
				mostrarError("No se pudo encender el BT");
			}
			return;
		}
		else
		{
			finish();
		}

	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		
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

	/*
	 * private OnItemClickListener mSeleccionarItem = new OnItemClickListener()
	 * { public void onItemClick(AdapterView<?> parent, View v, int position,
	 * long id) { ValorReferenciaAdapter adapter = (ValorReferenciaAdapter)
	 * parent.getAdapter(); adapter.setChecked(v,position);
	 * 
	 * } };
	 */
	public void iniciar()
	{
		// TODO Auto-generated method stub

	}

	public void presentarDocumentos(String accion, Cursor datosDocumentos) throws Exception
	{
		try
		{
			List<Map<String, String>> tabla = new ArrayList<Map<String, String>>();
			Map<String, String> registro;

			String descValor = "";
			while (datosDocumentos.moveToNext())
			{
				registro = new HashMap<String, String>();
				for (int i = 0; i < datosDocumentos.getColumnCount(); i++)
				{
					registro.put(datosDocumentos.getColumnName(i), datosDocumentos.getString(i));
				}
				NumberFormat numberFormat = new DecimalFormat("$#,##0.00");
				registro.put("Total", numberFormat.format(datosDocumentos.getDouble(datosDocumentos.getColumnIndex("Total"))));
				descValor = ValoresReferencia.getDescripcion(datosDocumentos.getString(datosDocumentos.getColumnIndex("VARCodigo")), datosDocumentos.getString(datosDocumentos.getColumnIndex("Tipo")));
				registro.put("DescTipo", descValor);
				registro.put("TipoRecibo", mPresenta.obtenerTipoRecibo(registro));
				registro.put("Seleccionado",String.valueOf( false));
				tabla.add(registro);
			}


			
			ListView lista = (ListView) findViewById(R.id.lstTransaccion);

			lista.setDescendantFocusability(ViewGroup.FOCUS_BLOCK_DESCENDANTS);
			//lista.setChoiceMode(1);
			lista.setItemsCanFocus(true);
			lista.setClickable(true);
			
	        lista.setOnItemClickListener(new AdapterView.OnItemClickListener() {
	            public void onItemClick(AdapterView<?> parent, View v, int position, long arg3) {
	                if (v != null) {
	                    CheckBox checkBox = (CheckBox)v.findViewById(R.id.chkSeleccion);
	                    if (listadoDocumentos.containsKey(checkBox.getTag())){
	                    	listadoDocumentos.put(checkBox.getTag().toString(),Boolean.valueOf(!listadoDocumentos.get(checkBox.getTag()))); 
	                    	checkBox.setChecked(listadoDocumentos.get(checkBox.getTag()));
	                    }
	                }	                	             
	            }
	        });
			MySimpleAdapter adapter = new MySimpleAdapter(this, tabla, R.layout.lista_impresion,
					new String[]
					{"DescTipo", "Folio", "Fecha", "Total", "Seleccionado" },
					new int[]
					{ R.id.lbTipo, R.id.lbFolio, R.id.lbFecha, R.id.lbTotal, R.id.chkSeleccion  });
			adapter.setViewBinder(new vista());				        
			
			lista.setAdapter(adapter);		}
		catch (Exception ex)
		{
			throw new Exception(ex);
		}
	}

	@SuppressWarnings("unchecked")
	public List<Map<String, String>> getDocumentosSeleccionados()
	{
		ListView lista = (ListView) findViewById(R.id.lstTransaccion);
		ListAdapter adapter = lista.getAdapter();

		List<Map<String, String>> tabla = new ArrayList<Map<String, String>>();
		for (int i = 0; i < adapter.getCount(); i++)
		{
				if (listadoDocumentos.containsKey(((Map<String, String>) adapter.getItem(i)).get("Folio"))){
					if (listadoDocumentos.get(((Map<String, String>) adapter.getItem(i)).get("Folio"))){
						tabla.add((Map<String, String>) adapter.getItem(i));	
					}
				}			
		}
		return tabla;
	}

	@Override
	public void setCliente(String cliente)
	{
		if (accion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))
		{
			TextView texto = (TextView) findViewById(R.id.lblCliente);
			texto.setText(cliente);
		}
	}

	@Override
	public void setRuta(String ruta)
	{
		if (accion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))
		{
			TextView texto = (TextView) findViewById(R.id.lblRuta);
			texto.setText(Mensajes.get("XRuta") + ": " + ruta);
		}
	}

	@Override
	public void setDia(String dia)
	{
		if (accion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))
		{
			TextView texto = (TextView) findViewById(R.id.lblDia);
			texto.setText(Mensajes.get("XDiaTrabajo") + ": " + dia);
		}
	}
	
	@Override
	public void impresionFinalizada(boolean impresionExitosa,String mensajeError)
	{
		/* Al finalizar la impresion no salimos */
		Log.i("IMPRESION_TICKETS", "Impresion finalizada: "+impresionExitosa);
		
		quitarProgreso();
	}
	
	private class MySimpleAdapter extends SimpleAdapter
	{
		List<Map<String,String>> c;
		
		public MySimpleAdapter(Context context,  List<Map<String, String>>  c, int layout, String[] from, int[] to)
		{
			super(context,  c, layout, from, to);
			this.c = c;
		}
		

		@Override
		public View getView(int pos, View v, ViewGroup parent)
		{
			v = super.getView(pos, v, parent);
			final CheckBox chb = (CheckBox) v.findViewById(R.id.chkSeleccion);

			chb.setFocusable(false);
			chb.setClickable(false);
			chb.setFocusableInTouchMode(false);
			chb.setEnabled(false);
			HashMap<String,String> reg = ((HashMap<String,String>)((SimpleAdapter)((ListView) parent).getAdapter()).getItem(pos));
			if (!listadoDocumentos.containsKey(reg.get("Folio")))
			{
				listadoDocumentos.put(reg.get("Folio"), false);				
			}
			chb.setTag(reg.get("Folio"));

			/* chb.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {

                 public void onCheckedChanged(CompoundButton buttonView,
                         boolean isChecked) {
                      // TODO Auto-generated method stub
                      if (buttonView.isChecked()) {
                         
                       }
                      else
                     {
                 
                      }

                 }
               });*/					
			
			return v;
		}

	}
	private class vista implements SimpleAdapter.ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Object data, String textRepresentation)
		{
			int viewId = view.getId();

			switch (viewId)
			{
				case R.id.chkSeleccion:
					CheckBox chb = (CheckBox)view;
					if (listadoDocumentos.containsKey(folioActualVista)){
						chb.setChecked(listadoDocumentos.get(folioActualVista));
					}

					break;
				case R.id.lbFolio:
					folioActualVista = textRepresentation;
					TextView txt = (TextView) view;
					txt.setText(textRepresentation);
					break;
				default:
					TextView txt2 = (TextView) view;
					txt2.setText(textRepresentation);
					break;
			}

			return true;
		}
	}

}
