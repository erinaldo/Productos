package com.amesol.routelite.vistas;

import java.io.File;
import java.util.Enumeration;
import java.util.Hashtable;

import android.content.ContentValues;
import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.presentadores.act.ConsultarReporte;
import com.amesol.routelite.presentadores.interfaces.IConsultaReporte;
import com.amesol.routelite.vistas.generico.DialogoProgreso;

import cx.hell.android.pdfview.ChooseFileActivity;

public class ConsultaReporte extends Vista implements IConsultaReporte
{
	
	ConsultarReporte mPresenta;
	Spinner spReporte;
	private ListView listClientes;
	
	@Override
	public void onCreate(Bundle savedInstanceState)
	{	
		try{
			super.onCreate(savedInstanceState);

			setContentView(R.layout.consulta_reporte);
			deshabilitarBarra(true);
			
			setTitulo(Mensajes.get("XReportes"));
			
			TextView texto = (TextView) this.findViewById(R.id.txtReporte);
			texto.setText(Mensajes.get("XReporte"));
			
			Button btn = (Button) this.findViewById(R.id.btnContinuar);
			btn.setText(Mensajes.get("BTContinuar"));
			btn.setOnClickListener(new OnClickListener(){
				@Override
				public void onClick(View v)
				{
					generarReporte(null);
				}
			});
			
			spReporte = (Spinner) this.findViewById(R.id.SpReporte);
			ISetDatos reportes = Consultas.ConsultasValorReferencia.obtenerValores("REPORTEA", null);
			llenarSpiner(spReporte, reportes);
			
			mPresenta = new ConsultarReporte(this);
			mPresenta.iniciar();
		}catch(Exception e){
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}
	
	private void generarReporte(Cliente cliente){
		if(spReporte.getSelectedItemPosition() == 0){
			mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", Mensajes.get("XReporte")));
			return;
		}
		mPresenta.generarReporte(cliente);
		/*File file = new File(Environment.getExternalStorageDirectory().getAbsolutePath()+"/example.pdf");
		Intent intent = new Intent();
		intent.setDataAndType(Uri.fromFile(file), "application/pdf");
		intent.setClass(this, PDFViewer.class);
		intent.setAction("android.intent.action.VIEW");
		this.startActivity(intent);*/
	}
	
	private void generarReporteAsync(){
		final DialogoProgreso dialog = new DialogoProgreso(this);
		dialog.setProgressStyle(DialogoProgreso.STYLE_SPINNER);
		dialog.setMessage("Generando reporte ...");
		dialog.setCancelable(false);
		dialog.show();

		Runnable accion = new Runnable()
		{
			public void run()
			{
				//runOnUiThread(new Runnable()
				//{
					//public void run()
					//{
						mPresenta.generarReporte(null);	
					//}
				//});
			}
		};
		final Thread reporte = new Thread(accion);
		
		Runnable mensaje = new Runnable()
		{
			public void run()
			{
				while (reporte.isAlive())
				{
				}
				dialog.dismiss();
				runOnUiThread(new Runnable()
				{
					public void run()
					{
						Enumeration<String> e = ((Hashtable<String, ContentValues>) Sesion.get(Campo.ArchivosGenerados)).keys();
						String archivo = "";
						while (e.hasMoreElements()){
							archivo = e.nextElement();	
						}
						ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
						File impresion = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
						File file = new File(impresion.getAbsolutePath()+"/"+""+".pdf");
						Intent intent = new Intent();
						intent.setDataAndType(Uri.fromFile(file), "application/pdf");
						//intent.setClass(((Context) this), PDFViewer.class);
						intent.setClassName("com.amesol.routelite.vistas", "PDFViewer");
						intent.setAction("android.intent.action.VIEW");
						startActivity(intent);
					}
				});
			}
		};
		new Thread(mensaje).start();
		reporte.start();
	}
	
	public int getReporteId(){
		return (int) spReporte.getSelectedItemId();
	}
	
	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode){
			case KeyEvent.KEYCODE_BACK:
				finalizar();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		
	}
	
	@SuppressWarnings("deprecation")
	public void llenarSpiner(Spinner control, ISetDatos valores)
	{
		try
		{
			Cursor unidad = (Cursor) valores.getOriginal();
			startManagingCursor(unidad);
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, unidad, new String[]
			{ "VAVClave" }, new int[]
			{ android.R.id.text1 });
			adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
			adapter.setViewBinder(new llenarSpinner());
			control.setAdapter(adapter);
			
			control.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener()
			{
				@Override
				public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3)
				{
					if(getReporteId() == 6){ // Si es un reporte de cobranza
						((Button) findViewById(R.id.btnContinuar)).setVisibility(View.INVISIBLE);
						findViewById(R.id.layout_filtro_clientes).setVisibility(View.VISIBLE);
						if(listClientes == null){
							listClientes = (ListView) findViewById(R.id.listClientes);
							mPresenta.cargaClientes(listClientes);
							((TextView)findViewById(R.id.textCliente)).setText(Mensajes.get("XClientes"));
							listClientes.setOnItemClickListener(new AdapterView.OnItemClickListener()
							{
								@Override
								public void onItemClick(AdapterView<?> arg0, View arg1, int arg2, long arg3)
								{
									// Continuar con el reporte
									generarReporte((Cliente)arg0.getAdapter().getItem(arg2));
								}
							});
						}
					}else{
						((Button) findViewById(R.id.btnContinuar)).setVisibility(View.VISIBLE);
						findViewById(R.id.layout_filtro_clientes).setVisibility(View.GONE);
					}
					
				}
				@Override
				public void onNothingSelected(AdapterView<?> arg0)
				{
					findViewById(R.id.layout_filtro_clientes).setVisibility(View.GONE);
				}
			});
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}

	}

	private class llenarSpinner implements ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case android.R.id.text1: // para llenar el combo de la unidad
					TextView combo = (TextView) view;
					combo.setGravity(Gravity.CENTER);
					combo.setText(ValoresReferencia.getDescripcion("REPORTEA", cursor.getString(cursor.getColumnIndex("VAVClave"))));
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}

	@Override
	public void iniciar()
	{
		
	}

}
