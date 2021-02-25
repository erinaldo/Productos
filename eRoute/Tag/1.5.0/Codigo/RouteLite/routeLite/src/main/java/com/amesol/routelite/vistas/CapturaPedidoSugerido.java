package com.amesol.routelite.vistas;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.Map.Entry;
import java.util.concurrent.atomic.AtomicReference;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.View;
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
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.CapturarPedidoSugerido;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedidoSugerido;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

public class CapturaPedidoSugerido extends Vista implements ICapturaPedidoSugerido
{

	CapturarPedidoSugerido mPresenta;
	String mAccion;
	boolean cargando;
	String precioClave;
	Cursor productos;
	ListView listProductos;
	boolean bEsVisible = false;
	@SuppressLint("UseSparseArrays")
	HashMap<Integer, EditText> eCantidades = new HashMap<Integer, EditText>();
	HashMap<String, HashMap<Short, TransProdDetalle>> seleccionTPD = new HashMap<String, HashMap<Short, TransProdDetalle>>();
	//HashMap<String, HashMap<String,com.amesol.routelite.datos.Inventario>> productoInventario = new HashMap<String, HashMap<String,com.amesol.routelite.datos.Inventario>>();

	ArrayList<String> mensajesAdvertencia = new ArrayList<String>();

	String transProdIds;
	int tipoValidacionExistencia;
	boolean errorDeCaptura = false;
	int indiceMsgAdvertencia = 0;
	int posicionError = -1;
	ModuloMovDetalle moduloMovDetalle;
	boolean mostrarValIniciales = true;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();
			setContentView(R.layout.captura_pedido_sugerido);
			deshabilitarBarra(true);
			lblTitle.setText(Mensajes.get("XPedidoSugerido"));

			HashMap<String, Object> oParametros = null;
			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
			}

			Button btn = (Button) findViewById(R.id.btnContinuar);
			btn.setText(Mensajes.get("btContinuar"));
			btn.setOnClickListener(mAgregar);

			btn = (Button) findViewById(R.id.btnRegresar);
			btn.setText(Mensajes.get("btRegresar"));
			btn.setOnClickListener(mRegresar);

			cargando = true;

			if (oParametros != null)
			{
				precioClave = oParametros.get("ListaPrecios").toString();
				transProdIds = oParametros.get("TransProd").toString();
				tipoValidacionExistencia = (Integer) oParametros.get("tipoValidacionExistencia");
				moduloMovDetalle = (ModuloMovDetalle) oParametros.get("ModuloMovDetalle");
				mostrarValIniciales = (Boolean) oParametros.get("mostrarValIniciales");
			}

			String sClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
			short nFrecuenciaDia = ((Dia) Sesion.get(Campo.DiaActual)).Frecuencia;

			ArrayList<Integer> tipoPedido = new ArrayList<Integer>();
			String productosSinPrecio = "";
			String productosSinExistencia = "";
			String filtroConsulta = "";
			int contadorEliminados = 0;
			productos = Consultas.ConsultasTransProd.obtenerPedidoSugerido(sClienteClave, nFrecuenciaDia, precioClave, transProdIds, tipoPedido, false, "");
			if (productos != null && productos.getCount() > 0)
			{
				if (tipoPedido.get(0) == 2)
				{
					mensajesAdvertencia.add(Mensajes.get("I0248").replace("$0$", ((Cliente) Sesion.get(Campo.ClienteActual)).Clave));
				}
				while (productos.moveToNext())
				{
					if (productos.isNull(productos.getColumnIndex("Precio")) || productos.getShort(productos.getColumnIndex("Precio")) <= 0)
					{
						productosSinPrecio += productos.getString(productos.getColumnIndex("ProductoClave")) + "(" + ValoresReferencia.getDescripcion("UNIDADV", productos.getString(productos.getColumnIndex("PRUTipoUnidad"))) + "),";
						contadorEliminados += 1;
					}
					else if (tipoValidacionExistencia == TiposValidacionInventario.ValidacionRestrictiva)
					{
						AtomicReference<Float> existencia = new AtomicReference<Float>();
						StringBuilder error = new StringBuilder();
						if (!Inventario.ValidarExistencia(productos.getString(productos.getColumnIndex("ProductoClave")), productos.getInt(productos.getColumnIndex("PRUTipoUnidad")), productos.getFloat(productos.getColumnIndex("Sugerido")), moduloMovDetalle, existencia, error))
						{
							if (existencia.get() == null || existencia.get() == 0)
							{
								contadorEliminados += 1;
								productosSinExistencia += productos.getString(productos.getColumnIndex("ProductoClave")) + "(" + ValoresReferencia.getDescripcion("UNIDADV", productos.getString(productos.getColumnIndex("PRUTipoUnidad"))) + "),";
								if (filtroConsulta.length() > 0)
								{
									filtroConsulta += " or ";
								}
								filtroConsulta += "( PRO.ProductoClave = '" + productos.getString(productos.getColumnIndex("ProductoClave")) + "' and PDE.PRUTipoUnidad = " + productos.getString(productos.getColumnIndex("PRUTipoUnidad")) + ") ";
							}
						}
						existencia = null;
						error = null;
					}
				}

				String msgSinPrecio = "";
				String msgSinExistencia = "";
				if (productosSinPrecio.length() > 0)
				{
					productosSinPrecio = productosSinPrecio.substring(0, productosSinPrecio.length() - 1);
					msgSinPrecio = Mensajes.get("I0258").replace("$0$", productosSinPrecio);
					mensajesAdvertencia.add(msgSinPrecio);
				}
				if (productosSinExistencia.length() > 0)
				{
					productosSinExistencia = productosSinExistencia.substring(0, productosSinExistencia.length() - 1);
					msgSinExistencia = Mensajes.get("I0252").replace("$0$", productosSinExistencia);
					mensajesAdvertencia.add(msgSinExistencia);
				}
				if (productos.getCount() <= contadorEliminados)
				{
					this.setResultado(Enumeradores.Resultados.RESULTADO_MAL, msgSinPrecio + "\n\n" + msgSinExistencia);
					finalizar();
					return;
				}

				if (mensajesAdvertencia.size() > 0)
				{
					if (mostrarValIniciales)
					{
						mostrarError(mensajesAdvertencia.get(indiceMsgAdvertencia));
						indiceMsgAdvertencia += 1;
					}
					else
					{
						mensajesAdvertencia.clear();
					}

					//Si hubo productos sin precio, requery;
					if (productosSinPrecio.length() > 0 || productosSinExistencia.length() > 0)
					{
						productos.close();
						productos = Consultas.ConsultasTransProd.obtenerPedidoSugerido(sClienteClave, nFrecuenciaDia, precioClave, transProdIds, tipoPedido, true, filtroConsulta);
					}
				}

			}
			else
			{
				this.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("I0249").replace("$0$", ((Cliente) Sesion.get(Campo.ClienteActual)).Clave));
				finalizar();
				return;
			}

			listProductos = (ListView) findViewById(R.id.lstProductos);
			listProductos.setDescendantFocusability(ViewGroup.FOCUS_AFTER_DESCENDANTS);
			listProductos.setChoiceMode(1);
			listProductos.setItemsCanFocus(true);
			listProductos.setClickable(false);

			cargando = false;
			//Intent intent = getIntent();  
			mPresenta = new CapturarPedidoSugerido(this, mAccion);
			//mPresenta.setParametros(oParametros);
			mPresenta.iniciar();

		}
		catch (ControlError e)
		{
			//mostrarError(e.getMessage());
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
				for (int i = 0; i < eCantidades.size(); i++)
				{
					if (eCantidades.get(i).isEnabled())
					{
						listProductos.setSelection(i);
						eCantidades.get(i).requestFocus();
						break;
					}
				}
				bEsVisible = true;
			}
	}

	@Override
	public void finalizar()
	{
		productos.close();
		listProductos = null;
		eCantidades = null;
		//productoInventario = null;
		super.finalizar();
	}

	/*
	 * public ISetDatos obtenerProducts(){ return products; }
	 */
	public Cursor obtenerProductos()
	{
		return productos;
	}

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
		if (tipoMensaje == 3)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				finalizar();
			}
		}
		else if (mensajesAdvertencia.size() > 0)
		{
			if (indiceMsgAdvertencia < mensajesAdvertencia.size())
			{
				String Msg = mensajesAdvertencia.get(indiceMsgAdvertencia);
				indiceMsgAdvertencia += 1;
				if (indiceMsgAdvertencia >= mensajesAdvertencia.size())
				{
					mensajesAdvertencia.clear();
					indiceMsgAdvertencia = 0;
				}
				mostrarError(Msg);
			}
			else
			{
				mensajesAdvertencia.clear();
			}
		}
	}

	@SuppressWarnings("deprecation")
	public void mostrarProductos(Cursor productos)
	{

		this.productos = productos;

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
			final MySimpleCursorAdapter adapter = new MySimpleCursorAdapter(this, R.layout.elemento_pedido_sugerido, productos,
					new String[]
					{ "PRUTipoUnidad", "Producto", "Sugerido", "Cantidad" },
					new int[]
					{ R.id.txtUnidad, R.id.txtDescripcion, R.id.txtSugerido, R.id.npCantidad });

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

	private android.view.View.OnClickListener mAgregar = new android.view.View.OnClickListener()
	{
		@Override
		public void onClick(View v)
		{

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

	private android.view.View.OnClickListener mRegresar = new android.view.View.OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			if (seleccionTPD.size() > 0)
			{
				mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
			}
			else
			{
				finalizar();
			}
		}
	};

	/*
	 * private android.view.View.OnClickListener mBuscarEsquemas = new
	 * android.view.View.OnClickListener() {
	 * 
	 * @Override public void onClick(View v) { mostrarBusquedaEsquemas(); } };
	 */

	private class MySimpleCursorAdapter extends SimpleCursorAdapter
	{
		@SuppressWarnings("deprecation")
		public MySimpleCursorAdapter(Context context, int layout, Cursor c, String[] from, int[] to)
		{
			super(context, layout, c, from, to);
		}

		@Override
		public View getView(int pos, View v, ViewGroup parent)
		{
			v = super.getView(pos, v, parent);

			Cursor c = ((SimpleCursorAdapter) ((ListView) parent).getAdapter()).getCursor();

			final EditText et = (EditText) v.findViewById(R.id.npCantidad);

			String clave = (c.getString(c.getColumnIndex("_id")) + "|" + ((TextView) v.findViewById(R.id.txtUnidad)).getTag().toString() + "|" + c.getFloat(c.getColumnIndex("Precio")) + "|" + c.getInt(c.getColumnIndex("DecimalProducto")) + "|" + pos);
			et.setTag(clave);

			if (c.getFloat(c.getColumnIndex("Cantidad")) > 0)
			{
				et.setText(Generales.getFormatoDecimal(c.getFloat(c.getColumnIndex("Cantidad")), c.getInt(c.getColumnIndex("DecimalProducto"))));
				et.setEnabled(false);
			}
			else
			{
				et.setEnabled(true);
			}

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
								// listProductos.requestFocusFromTouch();
								// listProductos.setSelection(index);
								if (eCantidades.containsKey(index))
								{
									eCantidades.get(index).requestFocus();
								}
							}
							return false;

					}
					return v.onKeyDown(keyCode, event);
				}
			});

			et.setOnFocusChangeListener(new View.OnFocusChangeListener()
			{
				@SuppressWarnings("rawtypes")
				@Override
				public void onFocusChange(View v, boolean hasFocus)
				{
					if (!hasFocus)
					{
						EditText et = (EditText) v;
						if (!et.isEnabled())
							return;
						//Estructura del tag ProductoClave|Unidad|Precio|Decimales
						String[] llave = et.getTag().toString().split("\\|");
						String productoClave = llave[0];
						Short unidad = Short.parseShort(llave[1]);
						Float precio = Float.parseFloat(llave[2]);
						int decimalProducto = Integer.parseInt(llave[3]);
						//Se agrego la posicion porque la funcion getPositionForView
						int pos = Integer.parseInt(llave[4]);
						AtomicReference<Float> existencia = new AtomicReference<Float>();
						StringBuilder error = new StringBuilder();

						try
						{
							if (seleccionTPD.containsKey(productoClave))
							{//El producto ya tiene alguna unidad capturada
								if (seleccionTPD.get(productoClave).containsKey(unidad))
								{//La unidad ya fue capturada
									//La cantidad capturada en la unidad es diferente a la que estaba
									if (((TransProdDetalle) seleccionTPD.get(productoClave).get(unidad)).Cantidad != Float.parseFloat(et.getText().toString()))
									{
										if (Float.parseFloat(et.getText().toString()) <= 0)
										{
											//Si la cantidad que existia se hizo 0, se quita la unidad de seleccionTPD y se revisa si tambien se quita
											//el producto
											seleccionTPD.get(productoClave).remove(unidad);
											if (seleccionTPD.get(productoClave).size() <= 0)
											{
												seleccionTPD.remove(productoClave);
											}
											et.setText(Generales.getFormatoDecimal(0, decimalProducto));
										}
										else
										{
											if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
											{
												HashMap<String, com.amesol.routelite.datos.Inventario> hmInventario = (HashMap<String, com.amesol.routelite.datos.Inventario>) Consultas.ConsultasInventario.obtenerInventarioProducto(productoClave);
												if (seleccionTPD.get(productoClave).size() > 1)
												{
													//Si hay mas de una unidad quitar primero lo que ya fue agregado
													Iterator<Entry<Short, TransProdDetalle>> it = seleccionTPD.get(productoClave).entrySet().iterator();
													while (it.hasNext())
													{ // recorrer los detalles de otras unidades
														Map.Entry producto = (Map.Entry) it.next();
														if ((Short) producto.getKey() != unidad)
														{
															Inventario.ValidarExistencia(productoClave, ((TransProdDetalle) producto.getValue()).TipoUnidad, ((TransProdDetalle) producto.getValue()).Cantidad, moduloMovDetalle.TipoMovimiento, moduloMovDetalle.TipoTransProd, existencia, hmInventario, error);
														}
													}
												}

												if (!Inventario.ValidarExistencia(productoClave, unidad, Float.parseFloat(et.getText().toString()), moduloMovDetalle.TipoMovimiento, moduloMovDetalle.TipoTransProd, existencia, hmInventario, error))
												{
													if (tipoValidacionExistencia == TiposValidacionInventario.ValidacionRestrictiva)
													{
														errorDeCaptura = true;
														posicionError = pos;
														mostrarError(error.toString());
														seleccionTPD.get(productoClave).get(unidad).Cantidad = Generales.getRound(existencia.get(), decimalProducto);
														et.setText(Generales.getFormatoDecimal(existencia.get(), decimalProducto));
														hmInventario = null;
														return;
													}
													else
													{
														//Si la validación es solo informativa
														mostrarAdvertencia(error.toString());
													}
												}
												hmInventario = null;
											}
											seleccionTPD.get(productoClave).get(unidad).Cantidad = Generales.getRound(Float.parseFloat(et.getText().toString()), decimalProducto);
											et.setText(Generales.getFormatoDecimal(seleccionTPD.get(productoClave).get(unidad).Cantidad, decimalProducto));
										}
									}
								}
								else if (et.getText().toString().length() > 0 && Float.parseFloat(et.getText().toString()) > 0)
								{ //Si la unidad no existe
									//Dar de alta la unidad
									if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
									{
										HashMap<String, com.amesol.routelite.datos.Inventario> hmInventario = (HashMap<String, com.amesol.routelite.datos.Inventario>) Consultas.ConsultasInventario.obtenerInventarioProducto(productoClave);
										if (seleccionTPD.get(productoClave).size() > 0)
										{
											//Si hay una unidad mas que la que se agrega quitar primero lo que ya fue agregado											
											Iterator<Entry<Short, TransProdDetalle>> it = seleccionTPD.get(productoClave).entrySet().iterator();
											while (it.hasNext())
											{ // recorrer los detalles de otras unidades
												Map.Entry producto = (Map.Entry) it.next();
												Inventario.ValidarExistencia(productoClave, ((TransProdDetalle) producto.getValue()).TipoUnidad, ((TransProdDetalle) producto.getValue()).Cantidad, moduloMovDetalle.TipoMovimiento, moduloMovDetalle.TipoTransProd, existencia, hmInventario, error);
											}
										}

										if (!Inventario.ValidarExistencia(productoClave, unidad, Float.parseFloat(et.getText().toString()), moduloMovDetalle.TipoMovimiento, moduloMovDetalle.TipoTransProd, existencia, hmInventario, error))
										{
											if (tipoValidacionExistencia == TiposValidacionInventario.ValidacionRestrictiva)
											{
												errorDeCaptura = true;
												posicionError = pos;
												mostrarError(error.toString());
												seleccionTPD.get(productoClave).get(unidad).Cantidad = Generales.getRound(existencia.get(), decimalProducto);
												et.setText(Generales.getFormatoDecimal(existencia.get(), decimalProducto));
												hmInventario = null;
												return;
											}
											else
											{
												//Si la validación es solo informativa
												mostrarAdvertencia(error.toString());
											}
										}
										hmInventario = null;
									}
									seleccionTPD.get(productoClave).put(unidad, TransaccionesDetalle.GenerarDetalleBusqueda(productoClave, unidad, Generales.getRound(Float.parseFloat(et.getText().toString()), decimalProducto), precio));
									et.setText(Generales.getFormatoDecimal(seleccionTPD.get(productoClave).get(unidad).Cantidad, decimalProducto));

								}
								else if (et.getText().toString().length() <= 0)
								{
									et.setText(Generales.getFormatoDecimal(0, decimalProducto));
								}
							}
							else if (et.getText().toString().length() > 0 && Float.parseFloat(et.getText().toString()) > 0)
							{
								//Dar de alta el producto y la unidad
								if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
								{
									HashMap<String, com.amesol.routelite.datos.Inventario> hmInventario = (HashMap<String, com.amesol.routelite.datos.Inventario>) Consultas.ConsultasInventario.obtenerInventarioProducto(productoClave);
									if (!Inventario.ValidarExistencia(productoClave, unidad, Float.parseFloat(et.getText().toString()), moduloMovDetalle.TipoMovimiento, moduloMovDetalle.TipoTransProd, existencia, hmInventario, error))
									{
										if (tipoValidacionExistencia == TiposValidacionInventario.ValidacionRestrictiva)
										{
											errorDeCaptura = true;
											posicionError = pos;
											mostrarError(error.toString());
											seleccionTPD.get(productoClave).get(unidad).Cantidad = Generales.getRound(existencia.get(), decimalProducto);
											et.setText(Generales.getFormatoDecimal(existencia.get(), decimalProducto));
											hmInventario = null;
											return;
										}
										else
										{
											//Si la validación es solo informativa
											mostrarAdvertencia(error.toString());
										}
									}
									hmInventario = null;
								}

								HashMap<Short, TransProdDetalle> hm = new HashMap<Short, TransProdDetalle>();
								hm.put(unidad, TransaccionesDetalle.GenerarDetalleBusqueda(productoClave, unidad, Generales.getRound(Float.parseFloat(et.getText().toString()), decimalProducto), precio));
								seleccionTPD.put(productoClave, hm);
								et.setText(Generales.getFormatoDecimal(seleccionTPD.get(productoClave).get(unidad).Cantidad, decimalProducto));

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
				case R.id.txtSugerido:
					TextView sugerido = (TextView) view;
					sugerido.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), cursor.getInt(cursor.getColumnIndex("DecimalProducto"))));
					break;
				case R.id.txtPrecio:
					TextView precio = (TextView) view;
					//precio.setText(String.format("$ %.2f", cursor.getFloat(columnIndex)));
					precio.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), "$ #,##0.00"));
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
							if (seleccionTPD.containsKey(cursor.getString(cursor.getColumnIndex("_id"))) && seleccionTPD.get(cursor.getString(cursor.getColumnIndex("_id"))).containsKey(cursor.getShort(cursor.getColumnIndex("PRUTipoUnidad"))))
							{
								if (seleccionTPD.get(cursor.getString(cursor.getColumnIndex("ProductoClave"))).get(cursor.getShort(cursor.getColumnIndex("PRUTipoUnidad"))).Cantidad != Float.parseFloat(texto.getText().toString()))
								{
									texto.setText(Generales.getFormatoDecimal(seleccionTPD.get(cursor.getString(cursor.getColumnIndex("ProductoClave"))).get(cursor.getShort(cursor.getColumnIndex("PRUTipoUnidad"))).Cantidad, Integer.parseInt(cursor.getString(cursor.getColumnIndex("DecimalProducto")))));
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