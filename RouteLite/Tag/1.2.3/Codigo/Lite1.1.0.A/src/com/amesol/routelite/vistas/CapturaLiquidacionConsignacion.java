package com.amesol.routelite.vistas;

import java.util.LinkedHashMap;
import java.util.Map;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnTouchListener;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.CapturarLiquidacionConsignacion;
import com.amesol.routelite.presentadores.act.CapturarLiquidacionConsignacion.VistaConsignacionLiquidacion;
import com.amesol.routelite.presentadores.interfaces.ICapturaLiquidacionConsignacion;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;


public class CapturaLiquidacionConsignacion extends Vista implements ICapturaLiquidacionConsignacion
{

	private static final String FORMATO_TOTALES = "$ #,##0.00";
	private static final int PREGUNTA_PERDER_CAMBIOS = 1;
	private static final int PREGUNTA_GENERA_CONSIGNACION = 2;
	
	private CapturarLiquidacionConsignacion mPresenta;
	private String mAccion;
	private String labelDevolucion;
	private String labelLiquidacion;
	private ListView lstProductos;
	private boolean bEsVisible;
	private Map<Integer, EditText[]> mapDevoluciones = new LinkedHashMap<Integer, EditText[]>();
	
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.captura_liquidacion_consignacion);
		mAccion = getIntent().getAction();
		mPresenta = new CapturarLiquidacionConsignacion(this);
		labelDevolucion = Mensajes.get("XDevolucion");
		labelLiquidacion = Mensajes.get("XLiquidar");
		lstProductos = (ListView) findViewById(R.id.lstProductos);
		lstProductos.setDescendantFocusability(ViewGroup.FOCUS_BEFORE_DESCENDANTS);
		lstProductos.setChoiceMode(1);
		lstProductos.setItemsCanFocus(true);
		lstProductos.setClickable(false);
		mPresenta.iniciar();
	}
	
	@Override
	public void iniciar()
	{
		Button btnTerminar = (Button) findViewById(R.id.btnTerminar);
		btnTerminar.setText(Mensajes.get("XTerminar"));
		btnTerminar.setOnClickListener(listenerTerminar);
		((TextView)findViewById(R.id.lblImporteLiquidar)).setText(Mensajes.get("XImporteLiquidar").concat(":"));
	}
	
	/**
	 * Muestra el folio de la consignacion a liquidar en la vista.
	 * @param folio, representa el folio de la consignacion a liquidar
	 */
	@Override
	public void setFolio(String folio)
	{
		((TextView)findViewById(R.id.lblFolio)).setText(Mensajes.get("XFolio")
				.concat(": ")
				.concat(folio));
	}
	
	/**
	 * Muestra la fecha de captura de la consignacion en la vista.
	 * @param fecha, string con la fecha de captura en formato dd/MM/aaaa
	 */
	@Override
	public void setFecha(String fecha)
	{
		((TextView)findViewById(R.id.lblFecha)).setText(Mensajes.get("XFecha")
				.concat(": ")
				.concat(fecha));
	}
	
	@Override
	public void onWindowFocusChanged(boolean hasFocus)
	{

		super.onWindowFocusChanged(hasFocus);

		if (hasFocus)
			if (!bEsVisible)
			{
				lstProductos.requestFocusFromTouch();
				lstProductos.setSelection(0);
				mapDevoluciones.get(0)[0].requestFocus();
				bEsVisible = true;
			}
	}
	
	/**
	 * Agrega al ListView de la actividad los productos asociados a la consignacion
	 * @param arreglo de transproddetalle con los detalles de la consignacion a liquidar
	 */
	@Override
	public void cargaDetalle(VistaConsignacionLiquidacion[] detalle)
	{
		ListAdapter adapter = new LiquidacionConsignacionAdapter(this, R.layout.elemento_liquidacion_consignacion, detalle);
		mapDevoluciones.clear();
		lstProductos.setAdapter(adapter);
		lstProductos.requestFocusFromTouch();
		lstProductos.setSelection(0);
	}
	
	/**
	 * Actualiza las cantidades de totales que se encuentran en la barra inferior de la vista.
	 * @param importeLiquidar valor que representa el importe total a liquidar
	 * @param devoluciones sumatoria de los importes por cada detalle donde sería
	 * en precio del producto por la cantidad a devolver
	 * @param saldo sumatoria de los importes por cada detalle a liquidar
	 */
	@Override
	public void setTotales(float importeLiquidar, float devoluciones, Float saldo)
	{
		((TextView)findViewById(R.id.lblImporteLiquidarMonto)).setText(Generales.getFormatoDecimal(importeLiquidar, FORMATO_TOTALES));
		((TextView)findViewById(R.id.lblDevoluciones)).setText(Mensajes.get("XDevoluciones")
				.concat(": ")
				.concat(Generales.getFormatoDecimal(devoluciones, FORMATO_TOTALES)));
		if(saldo == null)
		{
			((TextView)findViewById(R.id.lblSaldo)).setVisibility(View.INVISIBLE);
		}
		else{
			TextView lblSaldo = (TextView)findViewById(R.id.lblSaldo);
			lblSaldo.setVisibility(View.VISIBLE);
			lblSaldo.setText(Mensajes.get("XSaldo")
					.concat(": ")
					.concat(Generales.getFormatoDecimal(saldo, FORMATO_TOTALES)));
		}
	}
	
	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		if(keyCode == KeyEvent.KEYCODE_BACK)
		{
			if(mPresenta.hayDevoluciones()){
				mostrarPreguntaSiNo(Mensajes.get("BP0002"), PREGUNTA_PERDER_CAMBIOS);
			}else{
				setResultado(Enumeradores.Resultados.RESULTADO_MAL);
				finalizar();
			}
			return false;
		}
		return super.onKeyDown(keyCode, event);
	}
	
	@Override
	public void preguntarSiGeneraConsignacion()
	{
		mostrarPreguntaSiNo(Mensajes.get("P0228"), PREGUNTA_GENERA_CONSIGNACION);
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		// TODO Auto-generated method stub
		
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if(PREGUNTA_PERDER_CAMBIOS == tipoMensaje)
		{
			if(RespuestaMsg.Si == respuesta)
			{
				setResultado(Enumeradores.Resultados.RESULTADO_MAL);
				finalizar();
			}
		}else if(PREGUNTA_GENERA_CONSIGNACION == tipoMensaje)
		{
			if(RespuestaMsg.Si == respuesta)
			{
				mPresenta.setTipoLiquidacion(CapturarLiquidacionConsignacion.LIQUIDACION_GENERA_CONSIGNACION);
			}
		}
	}
	
	// Sección de getters de la clase
	
	/**
	 * Regresa la accion asociada a la actividad
	 * @return constante que determina la accion con la que fue lanzada la actividad
	 */
	public String getAccion(){
		return mAccion;
	}
	
	// Sección de listener asociados a los controles de esta vista
	private OnClickListener listenerTerminar = new OnClickListener()
	{
		
		@Override
		public void onClick(View v)
		{
			try{
				View edit = lstProductos.findFocus();
				if(edit != null && edit instanceof EditText){
					edit.clearFocus();
					InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
					imm.hideSoftInputFromWindow(edit.getWindowToken(), 0);
				}
				mPresenta.validaCapturaLiquidacion();
				
			}catch(ControlError error){
				mostrarAdvertencia(error.getMessage());
			}
			//setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			//finalizar();
		}
	};
	
	private class LiquidacionConsignacionAdapter extends ArrayAdapter<VistaConsignacionLiquidacion>{

		private VistaConsignacionLiquidacion[] objects;
		
		public LiquidacionConsignacionAdapter(Context context, int textViewResourceId, VistaConsignacionLiquidacion[] objects)
		{
			super(context, textViewResourceId, objects);
			this.objects = objects;
		}
		
		@Override
		public View getView(final int position, View convertView, ViewGroup parent)
		{
			View fila = convertView;

			if (convertView == null)
			{
				LayoutInflater inflater = ((Activity) CapturaLiquidacionConsignacion.this).getLayoutInflater();
				fila = inflater.inflate(R.layout.elemento_liquidacion_consignacion, null);
			}
			
			VistaConsignacionLiquidacion detalle = getItem(position);
			((TextView)fila.findViewById(R.id.lblClaveNombre)).setText(detalle.ProductoClave.concat(" - ").concat(detalle.Nombre));
			((TextView)fila.findViewById(R.id.lblImporte)).setText(Generales.getFormatoDecimal(detalle.Total, FORMATO_TOTALES));
			((TextView)fila.findViewById(R.id.lblCantidad)).setText(String.valueOf(detalle.Cantidad));
			((TextView)fila.findViewById(R.id.lblUnidad)).setText(String.valueOf(detalle.Unidad));
			
			((TextView)fila.findViewById(R.id.lblDevolucion)).setText(labelDevolucion);
			((TextView)fila.findViewById(R.id.lblLiquidacion)).setText(labelLiquidacion);
			
			((EditText)fila.findViewById(R.id.txtLiquidacion)).setText(Generales.getFormatoDecimal(detalle.Liquidar, detalle.DecimalProducto));
			
			EditText et = (EditText) fila.findViewById(R.id.txtDevolucion);
			et.setText(Generales.getFormatoDecimal(detalle.Devoluciones, detalle.DecimalProducto));
			
			et.setTag(detalle.ProductoClave+"/"+position);
			et.setFocusable(true);
			et.setSelectAllOnFocus(true);
			et.setClickable(false);
			et.setFocusableInTouchMode(true);
			
			if(!mapDevoluciones.containsKey(position))
			{
				mapDevoluciones.put(position, new EditText[]{et, (EditText)fila.findViewById(R.id.txtLiquidacion)});
			}
			
			et.setOnTouchListener(new OnTouchListener()
			{
				
				@Override
				public boolean onTouch(View v, MotionEvent event)
				{
					v.onTouchEvent(event);
					((EditText)v).selectAll();
					return false;
				}
			});
			
			et.setOnKeyListener(new EditText.OnKeyListener()
			{
				
				@Override
				public boolean onKey(View v, int keyCode, KeyEvent event)
				{
					if (event.getAction() != KeyEvent.ACTION_UP)
						return true;

					switch (keyCode)
					{
						case KeyEvent.KEYCODE_ENTER:
							if (v.getParent().getParent().getParent().getParent() != null)
							{
								int index = lstProductos.getPositionForView(v) + 1;

								if (mapDevoluciones.containsKey(index))
								{
									mapDevoluciones.get(index)[0].requestFocus();
								}
							}
							return false;
//						case KeyEvent.KEYCODE_BACK:
//							finalizar();
//							return true;
					}
					return v.onKeyDown(keyCode, event);
				}
			});
			
			et.setOnFocusChangeListener(new View.OnFocusChangeListener()
			{
				
				@Override
				public void onFocusChange(View v, boolean hasFocus)
				{
					EditText editText = (EditText)v;
					if(hasFocus)
					{
						editText.selectAll();
					}else
					{
						//Si perdio el foco validar y hacer los cambios
						VistaConsignacionLiquidacion d = getItem(position);
						float devoluciones = Generales.getFloat(editText.getText().toString(), d.DecimalProducto);
						if(devoluciones > d.Cantidad || devoluciones < 0){
							mostrarAdvertencia(Mensajes.get("E0216", "0", String.valueOf(d.Cantidad)));
							mapDevoluciones.get(position)[0].setText(Generales.getFormatoDecimal(d.Devoluciones, d.DecimalProducto));
						}else{
							d.Devoluciones = devoluciones;
							d.Liquidar = d.Cantidad - d.Devoluciones;
							mapDevoluciones.get(position)[1].setText(Generales.getFormatoDecimal(d.Liquidar, d.DecimalProducto));
							try{
								mPresenta.calculaTotales(objects);
							}catch(ControlError e){
								mostrarError(e.getMessage());
							}
						}
					}
				}
			});
			
			return fila;
		}
	}
}
