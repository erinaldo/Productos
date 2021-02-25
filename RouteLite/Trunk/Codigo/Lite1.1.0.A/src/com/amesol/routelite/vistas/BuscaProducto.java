package com.amesol.routelite.vistas;

import java.util.HashMap;
import java.util.concurrent.atomic.AtomicReference;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnKeyListener;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.presentadores.act.BuscarProducto;
import com.amesol.routelite.presentadores.interfaces.IBuscaProducto;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

public class BuscaProducto extends Vista implements IBuscaProducto
{

	private BuscarProducto mPresenta;
	private String mAccion;
	//BusquedaProductosAdapter adapter;
	private ListView listProductos;
	private String precioClave = "";
	private boolean validarPrecio = false;
	private String filtroEsquema = "";
	private String filtroProducto = "";
	private boolean iniciarBusquedaEsquema = false;
	private boolean errorDeCaptura = false;
	private int posicionError = -1;
	private ISetDatos products;
	private Cursor productos;
	private boolean filtrar;
	private boolean cargando;
	private String transProdIds;
	private int tipoValidarExistencia;
	private short tipoMovimiento;
	private short tipoTransProd;

	private EditText etCant;
	
	@SuppressLint("UseSparseArrays")
	private HashMap<Integer, EditText> eCantidades = new HashMap<Integer, EditText>();

	private HashMap<String, TransProdDetalle> seleccionTPD = new HashMap<String, TransProdDetalle>();
	private boolean bEsVisible = false;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();

			setContentView(R.layout.buscar_producto);
			deshabilitarBarra(true);
			lblTitle.setText(Mensajes.get("XBuscar", Mensajes.get("XProducto")));

			MOTConfiguracion m = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
			filtrar = Boolean.parseBoolean(m.get("FiltrarProductos").toString().equals("0") ? "false" : "true");

			/*
			 * if (Sesion.get(Campo.TipoIndiceModuloMovDetalleClave) == null)
			 * finalizar(); else tipoIndice =
			 * Short.parseShort(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave
			 * ).toString());
			 */

			HashMap<String, Object> oParametros = null;
			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
			}

			Button btn = (Button) findViewById(R.id.btnAgregar);
			btn.setText(Mensajes.get("XAgregar"));
			btn.setOnClickListener(mAgregar);

			//TODO: omitir todo lo relacionado a la busqueda de esquemas
			//			ImageButton imgbtn = (ImageButton) findViewById(R.id.btnEsquemas);
			//			imgbtn.setOnClickListener(mBuscarEsquemas);
			//			imgbtn.setVisibility(View.GONE);
			//
			//			TextView texto = (TextView) findViewById(R.id.lblEsquema);
			//			texto.setText(Mensajes.get("XEsquema"));
			//			texto.setVisibility(View.GONE);
			//****************************************************

			TextView texto = (TextView) findViewById(R.id.lblProducto);
			texto.setText(Mensajes.get("XProducto"));

			cargando = true;

			//			EditText edit = (EditText) findViewById(R.id.txtEsquema);
			//			edit.setVisibility(View.GONE);
			/*
			 * // * edit.setOnKeyListener(mTecla); // *
			 * edit.setOnFocusChangeListener(mFoco); if (oParametros != null &&
			 * // * (!oParametros.get("Esquema").trim().equals(""))){ // *
			 * edit.setText(oParametros.get("Esquema")); //mandar un 'Enter' //
			 * * para que haga la busqueda edit.dispatchKeyEvent(new // *
			 * KeyEvent(KeyEvent.ACTION_DOWN, KeyEvent.KEYCODE_ENTER)); } //
			 */

			EditText edit = (EditText) findViewById(R.id.txtProducto);
			edit.setOnKeyListener(mFiltrarProducto);
			edit.setSelectAllOnFocus(true);
			edit.setSingleLine(true);
			edit.setFocusable(true);
			/*
			 * edit.setOnFocusChangeListener(mFoco);
			 * edit.setOnTouchListener(mTouch);
			 */
			//edit.setOnFocusChangeListener(mFoco);
			//edit.addTextChangedListener(mFiltroProducto);
			if (oParametros != null)
			{
				transProdIds = oParametros.get("TransProd").toString();
				tipoValidarExistencia = Integer.parseInt(oParametros.get("TipoValidarExistencia").toString());
				tipoMovimiento = Short.parseShort(oParametros.get("TipoMovimiento").toString());
				tipoTransProd = Short.parseShort(oParametros.get("TipoTransProd").toString());
				if (oParametros.get("ListaPrecios") != null)
				{
					precioClave = oParametros.get("ListaPrecios").toString();
					if (!(tipoTransProd == TiposTransProd.DEVOLUCIONES_CLIENTE && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA))
					{
						validarPrecio = true;
					}
				}
			}

			if (oParametros != null && (!oParametros.get("Cadena").toString().trim().equals("")))
			{
				edit.setText(oParametros.get("Cadena").toString());
				edit.selectAll();
				//mandar un 'Enter' para que haga la busqueda
				edit.dispatchKeyEvent(new KeyEvent(KeyEvent.ACTION_UP, KeyEvent.KEYCODE_ENTER));
			}
			
			if (mAccion.equals(Enumeradores.Acciones.ACCION_OBTENER_PRODUCTOS_SELECCIONADOS))
				productos = Consultas.ConsultasProducto.obtenerProductosExistencia(filtroEsquema + filtroProducto, precioClave, filtrar, transProdIds, tipoTransProd, (tipoValidarExistencia == TiposValidacionInventario.NoValidar ? false : true));
			else
				productos = Consultas.ConsultasProducto.obtenerProductosExistencia(filtroEsquema + filtroProducto, precioClave, filtrar, transProdIds, tipoTransProd, (tipoValidarExistencia == TiposValidacionInventario.NoValidar ? false : true));

			if (productos == null)
			{

				this.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("E0878"));
				finalizar();
			}
			
			

			listProductos = (ListView) findViewById(R.id.lstProductos);
			listProductos.setDescendantFocusability(ViewGroup.FOCUS_BEFORE_DESCENDANTS);
			listProductos.setChoiceMode(1);
			listProductos.setItemsCanFocus(true);
			listProductos.setClickable(false);
			iniciarBusquedaEsquema = false;

			cargando = false;
			//Intent intent = getIntent();  
			mPresenta = new BuscarProducto(this, mAccion);
			mPresenta.iniciar();
			//
		}
		catch (ControlError e)
		{
			mostrarError(e.getMessage());
			finalizar();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
		}
	}

	@Override
	public void onWindowFocusChanged(boolean hasFocus)
	{

		super.onWindowFocusChanged(hasFocus);

		if (hasFocus)
			if (!bEsVisible)
			{
				listProductos.requestFocusFromTouch();
				listProductos.setSelection(0);
				eCantidades.get(0).requestFocus();
				bEsVisible = true;
			}
	}

	private OnKeyListener mFiltrarProducto = new OnKeyListener()
	{
		@Override
		public boolean onKey(View v, int keyCode, KeyEvent event)
		{
			if (event.getAction() == KeyEvent.ACTION_UP)
			{
				if (keyCode == KeyEvent.KEYCODE_ENTER)
				{
					try
					{
						String texto = ((TextView) v).getText().toString().trim();
						if (!texto.equals(""))
							filtroProducto = " (PRO.Id LIKE '%" + texto + "%' or PRO.ProductoClave LIKE '%" + texto + "%' or PRO.Nombre LIKE '%" + texto + "%' or PRO.NombreLargo LIKE '%" + texto + "%')";
						else
							filtroProducto = "";
						seleccionTPD.clear();
						if (!cargando)
						{
							if (mAccion.equals(Enumeradores.Acciones.ACCION_OBTENER_PRODUCTOS_SELECCIONADOS))
								mostrarProductos(Consultas.ConsultasProducto.obtenerProductosExistencia(filtroEsquema + filtroProducto, precioClave, false, transProdIds, tipoTransProd, (tipoValidarExistencia == TiposValidacionInventario.NoValidar ? false : true)));
							else
								mostrarProductos(Consultas.ConsultasProducto.obtenerProductosExistencia(filtroEsquema + filtroProducto, precioClave, filtrar, transProdIds, tipoTransProd, (tipoValidarExistencia == TiposValidacionInventario.NoValidar ? false : true)));
						}
						return true;
					}
					catch (Exception e)
					{
						mostrarError(e.getMessage().equals("") ? e.getCause().getMessage() : e.getMessage());
					}
				}
			}
			return false;
		}
	};

	public ISetDatos obtenerProducts()
	{
		return products;
	}

	public Cursor obtenerProductos()
	{
		return productos;
	}

	//	private void filtrarListaPorEsquema()
	//	{
	//		try
	//		{
	//			EditText edit = (EditText) findViewById(R.id.txtEsquema);
	//			if (!edit.getText().toString().trim().toUpperCase().equals(Mensajes.get("XTodos").toUpperCase()))
	//			{ //si el esquema es diferente a 'todos', filtrar
	//				Esquema esquema = Consultas.ConsultasEsquema.obtenerEsquemaPorClaveNombre(edit.getText().toString().trim(), "2");
	//				if (esquema != null)
	//					filtroEsquema = " and EsquemaID = '" + esquema.EsquemaId + "'";
	//				else
	//				{
	//					filtroEsquema = "";
	//					iniciarBusquedaEsquema = true;
	//					mostrarAdvertencia(Mensajes.get("E0026"));
	//				}
	//
	//				seleccionTPD.clear();
	//				//if(filtrar)
	//				//mostrarProductos(Consultas.ConsultasProducto.obtenerProductosExistencia(filtroEsquema + filtroProducto,precio.PrecioClave,filtrar));
	//				if (!cargando)
	//					mostrarProductos(Consultas.ConsultasProducto.obtenerProductosExistencia(filtroEsquema + filtroProducto, precioClave, filtrar, transProdIds, tipoTransProd, (tipoValidarExistencia == TiposValidacionInventario.NoValidar ? false : true)));
	//				//else
	//				//mostrarProductos(Consultas.ConsultasProducto.obtenerProductosExistencia(filtroEsquema + filtroProducto,"",filtrar));
	//				//mostrarProductos(Consultas2.ConsultasProducto.obtenerProductosExistencia(filtroEsquema + filtroProducto,"",filtrar));
	//			}
	//		}
	//		catch (Exception e)
	//		{
	//			mostrarError(e.getMessage().equals("") ? e.getCause().getMessage() : e.getMessage());
	//		}
	//	}

	@Override
	public void iniciar()
	{
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
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
		if (respuesta.equals(Enumeradores.RespuestaMsg.OK) && iniciarBusquedaEsquema)
		{
			iniciarBusquedaEsquema = false;
			mostrarBusquedaEsquemas();
		}
		else if (respuesta.equals(Enumeradores.RespuestaMsg.OK) && errorDeCaptura)
		{
			errorDeCaptura = false;
			//listProductos.setFocusableInTouchMode(true);
			if (posicionError >= 0)
			{
				listProductos.setSelection(posicionError);
				eCantidades.get(posicionError).requestFocus();
			}
		}else if(tipoMensaje == 30){
			//cantidad maxima de producto
			if(respuesta == RespuestaMsg.Si){
				aceptarCantidad(etCant);
			}else if(respuesta == RespuestaMsg.No){
				//regresar el focus al producto
				int index = listProductos.getPositionForView(etCant);
				if (eCantidades.containsKey(index))
				{
					eCantidades.get(index).requestFocus();
				}
			}
		}
	}

	/*
	 * public void mostrarProductos(ISetDatos productos){ //seleccion.clear();
	 * //limpiar el hashmap cuando cambie el contenido de la lista this.products
	 * = productos; //ListView lista = (ListView)
	 * findViewById(R.id.lstProductos); Cursor cProductos = (Cursor)
	 * productos.getOriginal(); startManagingCursor(cProductos); try{
	 * SimpleCursorAdapter adapter = new SimpleCursorAdapter(this,
	 * R.layout.lista_busqueda_producto, cProductos, new String[] { "Unidad",
	 * "ProductoClave", "Nombre", "Existencia", "Precio","Cantidad"}, new int[]
	 * {R.id.txtUnidad, R.id.txtClave, R.id.txtDescripcion, R.id.txtExistencia,
	 * R.id.txtPrecio, R.id.npCantidad }); adapter.setViewBinder(new vista());
	 * listProductos.setAdapter(adapter); }catch(Exception e){
	 * mostrarError(e.getMessage()); } }
	 */

	@SuppressWarnings("deprecation")
	public void mostrarProductos(Cursor productos)
	{
		//seleccion.clear(); //limpiar el hashmap cuando cambie el contenido de la lista
		//Handler handler = new Handler();
		this.productos = productos;
		//final ListView lista = (ListView) findViewById(R.id.lstProductos);

		if (productos == null)
		{ //da problemas cuando el cursor es null, por eso solo se oculta la lista para no mostrar ningun resultado
			listProductos.setVisibility(View.INVISIBLE);
			return;
		}
		else
		{
			listProductos.setVisibility(View.VISIBLE);
		}

		startManagingCursor(productos);
		try
		{
			final MySimpleCursorAdapter adapter = new MySimpleCursorAdapter(this, R.layout.lista_busqueda_producto, productos,
					new String[]
					{ "Unidad", "ProductoClave", "Nombre", "Existencia", "Precio", "Cantidad", "PrecioSugerido" },
					new int[]
					{ R.id.txtUnidad, R.id.txtClave, R.id.txtDescripcion, R.id.txtExistencia, R.id.txtPrecio, R.id.npCantidad, R.id.txtPrecioSugerido });
			adapter.setViewBinder(new vista());

			listProductos.setAdapter(adapter);

			eCantidades.clear();
			listProductos.requestFocusFromTouch();
			listProductos.setSelection(0);

		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
	}

	public void mostrarBusquedaEsquemas()
	{
		mostrarAdvertencia("Mostrar pantalla de busqueda de esquemas");
	}

	private android.view.View.OnClickListener mAgregar = new android.view.View.OnClickListener()
	{
		@Override
		public void onClick(View v)
		{

			//final ListView lista = (ListView) findViewById(R.id.lstProductos);
			listProductos.clearFocus();
			if (errorDeCaptura)
				return;
			if (listProductos.getVisibility() == View.VISIBLE)
			{
				Sesion.set(Campo.ResultadoActividad, seleccionTPD);
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN, null);
			}
			finalizar();
		}
	};

	//	private android.view.View.OnClickListener mBuscarEsquemas = new android.view.View.OnClickListener()
	//	{
	//		@Override
	//		public void onClick(View v)
	//		{
	//			mostrarBusquedaEsquemas();
	//		}
	//	};

	private class MySimpleCursorAdapter extends SimpleCursorAdapter
	{
		Cursor c;
		
		@SuppressWarnings("deprecation")
		public MySimpleCursorAdapter(Context context, int layout, Cursor c, String[] from, int[] to)
		{
			super(context, layout, c, from, to);
			this.c = c;
		}
		
		/*@Override
		public int getViewTypeCount()
		{
			return c.getCount();
		}*/
		
		/*@Override
		public int getItemViewType(int position)
		{
			return position;
		}*/

		@Override
		public View getView(int pos, View v, ViewGroup parent)
		{
			v = super.getView(pos, v, parent);
			final EditText et = (EditText) v.findViewById(R.id.npCantidad);

			Cursor c = ((SimpleCursorAdapter) ((ListView) parent).getAdapter()).getCursor();
			String clave = (((TextView) v.findViewById(R.id.txtClave)).getText().toString() + "|" + ((TextView) v.findViewById(R.id.txtUnidad)).getTag().toString() + "|" + ((TextView) v.findViewById(R.id.txtExistencia)).getText().toString() + "|" + (c.isNull(c.getColumnIndex("Precio")) ? null : c.getFloat(c.getColumnIndex("Precio"))) + "|" + c.getInt(c.getColumnIndex("DecimalProducto")) + "|" + pos);
			et.setTag(clave);
			et.setFocusable(true);
			et.setSelectAllOnFocus(true);
			et.setClickable(false);
			et.setFocusableInTouchMode(true);

			if (!eCantidades.containsKey(pos))
			{
				eCantidades.put(pos, et);
			}

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
								int index = listProductos.getPositionForView(v) + 1;

								if (eCantidades.containsKey(index))
								{
									eCantidades.get(index).requestFocus();
								}
							}
							return false;
						case KeyEvent.KEYCODE_BACK:
							finalizar();
							return true;
					}
					return v.onKeyDown(keyCode, event);
				}
			});

			et.setOnFocusChangeListener(new View.OnFocusChangeListener()
			{
				@Override
				public void onFocusChange(View v, boolean hasFocus)
				{
					if (!hasFocus)
					{
						EditText et = (EditText) v;
						
						if(!mPresenta.validarCantMax(Float.parseFloat(et.getText().toString()), tipoTransProd)){
							//no esta configurada ninguna cantidad, continuar normal
							aceptarCantidad(et);
						}else{
							//guardar la info en las varibles para poder agregar el producto si contesta que si a la pregunta
							etCant = et;
						}

						//Estructura del tag ProductoClave|Unidad|Existencia|Precio|Decimales
						/*String[] llave = et.getTag().toString().split("\\|");
						String productoClave = llave[0];
						Integer unidad = Integer.parseInt(llave[1]);
						AtomicReference<Float> existencia = new AtomicReference<Float>();
						existencia.set(Float.parseFloat(llave[2]));
						Float precio = null;
						if (!llave[3].equals("null"))
							precio = Float.parseFloat(llave[3]);
						int decimalProducto = Integer.parseInt(llave[4]);
						//Se agrego la posicion porque la funcion getPositionForView
						int pos = Integer.parseInt(llave[5]);
						StringBuilder error = new StringBuilder();
						try
						{
							if (seleccionTPD.containsKey(productoClave))
							{
								if (((TransProdDetalle) seleccionTPD.get(productoClave)).Cantidad != Float.parseFloat(et.getText().toString()))
								{
									if (Float.parseFloat(et.getText().toString()) <= 0)
									{
										seleccionTPD.remove(productoClave);
										et.setText(Generales.getFormatoDecimal(0, decimalProducto));
									}
									else
									{
										if (tipoValidarExistencia != TiposValidacionInventario.NoValidar)
										{
											if (!Inventario.ValidarExistencia(productoClave, unidad, Float.parseFloat(et.getText().toString()), tipoMovimiento, tipoTransProd, existencia, error))
											{
												if (tipoValidarExistencia == TiposValidacionInventario.ValidacionInformativa)
												{
													mostrarAdvertencia(error.toString());
												}
												else
												{
													errorDeCaptura = true;
													posicionError = pos;
													mostrarError(error.toString());
													seleccionTPD.get(productoClave).Cantidad = Generales.getRound(existencia.get(), decimalProducto);
													et.setText(Generales.getFormatoDecimal(existencia.get(), decimalProducto));
													return;
												}
											}
											seleccionTPD.get(productoClave).Cantidad = Generales.getRound(Float.parseFloat(et.getText().toString()), decimalProducto);
											et.setText(Generales.getFormatoDecimal(seleccionTPD.get(productoClave).Cantidad, decimalProducto));

										}
										else
										{
											seleccionTPD.get(productoClave).Cantidad = Generales.getRound(Float.parseFloat(et.getText().toString()), decimalProducto);
											et.setText(Generales.getFormatoDecimal(seleccionTPD.get(productoClave).Cantidad, decimalProducto));
										}
									}

								}
							}
							else if (et.getText().toString().length() > 0 && Float.parseFloat(et.getText().toString()) > 0)
							{
								//Dar de alta

								if (precio == null && validarPrecio)
								{
									errorDeCaptura = true;
									posicionError = pos;
									mostrarError(Mensajes.get("E0742", productoClave, ValoresReferencia.getDescripcion("UNIDADV", unidad.toString())));
									et.setText(Generales.getFormatoDecimal(0, decimalProducto));
								}
								else
								{
									if (tipoValidarExistencia != TiposValidacionInventario.NoValidar)
									{
										if (!Inventario.ValidarExistencia(productoClave, unidad, Float.parseFloat(et.getText().toString()), tipoMovimiento, tipoTransProd, existencia, error))
										{
											if (tipoValidarExistencia == TiposValidacionInventario.ValidacionInformativa)
											{
												mostrarAdvertencia(error.toString());
											}
											else
											{
												errorDeCaptura = true;
												posicionError = pos;
												mostrarError(error.toString());
												et.setText(Generales.getFormatoDecimal(existencia.get(), decimalProducto));
												return;
											}
										}
										seleccionTPD.put(productoClave, TransaccionesDetalle.GenerarDetalleBusqueda(productoClave, unidad, Generales.getRound(Float.parseFloat(et.getText().toString()), decimalProducto), (precio == null ? 0 : precio)));
										et.setText(Generales.getFormatoDecimal(seleccionTPD.get(productoClave).Cantidad, decimalProducto));

									}
									else
									{
										seleccionTPD.put(productoClave, TransaccionesDetalle.GenerarDetalleBusqueda(productoClave, unidad, Generales.getRound(Float.parseFloat(et.getText().toString()), decimalProducto), (precio == null ? 0 : precio)));
										et.setText(Generales.getFormatoDecimal(seleccionTPD.get(productoClave).Cantidad, decimalProducto));
									}
								}
							}
							else if (et.getText().toString().length() <= 0)
							{
								et.setText(Generales.getFormatoDecimal(0, decimalProducto));
							}

						}
						catch (Exception ex)
						{
							mostrarError(ex.getMessage());
						}*/
					}
					else
					{
						EditText et = (EditText) v;
						et.selectAll();
					}

				}
			});

			et.setOnTouchListener(new View.OnTouchListener()
			{

				@Override
				public boolean onTouch(View v, MotionEvent event)
				{
					v.onTouchEvent(event);
					((EditText) v).selectAll();
					return true;
				}
			});
			return v;
		}

	}
	
	private void aceptarCantidad(EditText et){
		//Estructura del tag ProductoClave|Unidad|Existencia|Precio|Decimales
		String[] llave = et.getTag().toString().split("\\|");
		String productoClave = llave[0];
		Integer unidad = Integer.parseInt(llave[1]);
		AtomicReference<Float> existencia = new AtomicReference<Float>();
		existencia.set(Float.parseFloat(llave[2]));
		Float precio = null;
		if (!llave[3].equals("null"))
			precio = Float.parseFloat(llave[3]);
		int decimalProducto = Integer.parseInt(llave[4]);
		//Se agrego la posicion porque la funcion getPositionForView
		int pos = Integer.parseInt(llave[5]);
		StringBuilder error = new StringBuilder();
		try
		{
			if (seleccionTPD.containsKey(productoClave))
			{
				if (((TransProdDetalle) seleccionTPD.get(productoClave)).Cantidad != Float.parseFloat(et.getText().toString()))
				{
					if (Float.parseFloat(et.getText().toString()) <= 0)
					{
						seleccionTPD.remove(productoClave);
						et.setText(Generales.getFormatoDecimal(0, decimalProducto));
					}
					else
					{
						if (tipoValidarExistencia != TiposValidacionInventario.NoValidar)
						{
							if (!Inventario.ValidarExistencia(productoClave, unidad, Float.parseFloat(et.getText().toString()), tipoMovimiento, tipoTransProd, existencia, error))
							{
								if (tipoValidarExistencia == TiposValidacionInventario.ValidacionInformativa)
								{
									mostrarAdvertencia(error.toString());
								}
								else
								{
									errorDeCaptura = true;
									posicionError = pos;
									mostrarError(error.toString());
									seleccionTPD.get(productoClave).Cantidad = Generales.getRound(existencia.get(), decimalProducto);
									et.setText(Generales.getFormatoDecimal(existencia.get(), decimalProducto));
									return;
								}
							}
							seleccionTPD.get(productoClave).Cantidad = Generales.getRound(Float.parseFloat(et.getText().toString()), decimalProducto);
							et.setText(Generales.getFormatoDecimal(seleccionTPD.get(productoClave).Cantidad, decimalProducto));

						}
						else
						{
							seleccionTPD.get(productoClave).Cantidad = Generales.getRound(Float.parseFloat(et.getText().toString()), decimalProducto);
							et.setText(Generales.getFormatoDecimal(seleccionTPD.get(productoClave).Cantidad, decimalProducto));
						}
					}

				}
			}
			else if (et.getText().toString().length() > 0 && Float.parseFloat(et.getText().toString()) > 0)
			{
				//Dar de alta

				if (precio == null && validarPrecio)
				{
					errorDeCaptura = true;
					posicionError = pos;
					mostrarError(Mensajes.get("E0742", productoClave, ValoresReferencia.getDescripcion("UNIDADV", unidad.toString())));
					et.setText(Generales.getFormatoDecimal(0, decimalProducto));
				}
				else
				{
					if (tipoValidarExistencia != TiposValidacionInventario.NoValidar)
					{
						if (!Inventario.ValidarExistencia(productoClave, unidad, Float.parseFloat(et.getText().toString()), tipoMovimiento, tipoTransProd, existencia, error))
						{
							if (tipoValidarExistencia == TiposValidacionInventario.ValidacionInformativa)
							{
								mostrarAdvertencia(error.toString());
							}
							else
							{
								errorDeCaptura = true;
								posicionError = pos;
								mostrarError(error.toString());
								et.setText(Generales.getFormatoDecimal(existencia.get(), decimalProducto));
								return;
							}
						}
						seleccionTPD.put(productoClave, TransaccionesDetalle.GenerarDetalleBusqueda(productoClave, unidad, Generales.getRound(Float.parseFloat(et.getText().toString()), decimalProducto), (precio == null ? 0 : precio)));
						et.setText(Generales.getFormatoDecimal(seleccionTPD.get(productoClave).Cantidad, decimalProducto));

					}
					else
					{
						seleccionTPD.put(productoClave, TransaccionesDetalle.GenerarDetalleBusqueda(productoClave, unidad, Generales.getRound(Float.parseFloat(et.getText().toString()), decimalProducto), (precio == null ? 0 : precio)));
						et.setText(Generales.getFormatoDecimal(seleccionTPD.get(productoClave).Cantidad, decimalProducto));
					}
				}
			}
			else if (et.getText().toString().length() <= 0)
			{
				et.setText(Generales.getFormatoDecimal(0, decimalProducto));
			}

		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	private class vista implements ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();

			switch (viewId)
			{
				case R.id.txtUnidad:
					TextView unidad = (TextView) view;
					unidad.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(columnIndex)));
					unidad.setTag(cursor.getInt(columnIndex));
					break;
				case R.id.txtExistencia:
					TextView existencia = (TextView) view;
					if (tipoValidarExistencia == TiposValidacionInventario.NoValidar)
					{
						existencia.setText(String.valueOf(cursor.getFloat(columnIndex)));
						existencia.setVisibility(View.GONE);
					}
					else
					{
						existencia.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), cursor.getInt(cursor.getColumnIndex("DecimalProducto"))));
					}
					break;
				case R.id.txtPrecio:
					TextView precio = (TextView) view;
					//precio.setText(String.format("$ %.2f", cursor.getFloat(columnIndex)));
					if (precioClave.equals("")){						
						precio.setVisibility(View.INVISIBLE);
					}
					if (!cursor.isNull(8)){
						precio.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), "$ #,##0.00"));
						precio.setVisibility(View.VISIBLE);
					}
					else{
						precio.setVisibility(View.INVISIBLE);
					}
						
					break;
					
				case R.id.txtPrecioSugerido:
					TextView precioSug = (TextView) view;
					if(tipoTransProd != 1){ //solo se muestra el precio sugerido para los pedidos
						precioSug.setVisibility(View.GONE);
					}else{
						if (precioClave.equals("")){						
							precioSug.setVisibility(View.INVISIBLE);
						}
						if (!cursor.isNull(8)){
							precioSug.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), "$ #,##0.00"));
							precioSug.setVisibility(View.VISIBLE);
						}
						else{
							precioSug.setVisibility(View.INVISIBLE);
						}
					}
					break;

				default:
					if (viewId != R.id.npCantidad)
					{
						TextView texto = (TextView) view;

						if (!texto.getText().equals(cursor.getString(columnIndex)))
						{
							texto.setText(cursor.getString(columnIndex));
						}
					}
					else
					{
						EditText texto = (EditText) view;

						view.clearFocus();

						if (!Generales.isNumeric(texto.getText().toString()))
						{
							texto.setText(Generales.getFormatoDecimal(0, Integer.parseInt(cursor.getString(cursor.getColumnIndex("DecimalProducto")))));
						}
						try
						{
							if (seleccionTPD.containsKey(cursor.getString(cursor.getColumnIndex("ProductoClave"))))
							{
								if (seleccionTPD.get(cursor.getString(cursor.getColumnIndex("ProductoClave"))).Cantidad != Float.parseFloat(texto.getText().toString()))
								{
									texto.setText(Generales.getFormatoDecimal(seleccionTPD.get(cursor.getString(cursor.getColumnIndex("ProductoClave"))).Cantidad, Integer.parseInt(cursor.getString(cursor.getColumnIndex("DecimalProducto")))));
								}

							}
							else
							{
								texto.setText(Generales.getFormatoDecimal(0, Integer.parseInt(cursor.getString(cursor.getColumnIndex("DecimalProducto")))));
							}

						}
						catch (Exception ex)
						{
							mostrarError(ex.getMessage());
						}
					}

					break;
			}

			return true;
		}
	}

}
