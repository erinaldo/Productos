package com.amesol.routelite.controles;

import java.util.HashMap;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.util.AttributeSet;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.WindowManager;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.TextBoxScanner.OnCodigoIngresadoListener;
import com.amesol.routelite.controles.TextBoxScanner.OnTextChangedListener;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.interfaces.IBuscaProducto;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.Vista;

public class CapturaProducto extends LinearLayout
{

	// controles
	TextBoxScanner txtScanner;
	//LinearLayout btnBuscar;
	ImageButton btnBuscar;
	Spinner cboUnidad;
	EditText txtCantidad;
	ImageButton btnAgregar;
	TextView lblProDescripcion;
	TextView lblProExistencia;

	// variables
	Producto oProducto = null;
	Vista mVista = null;

	// parametros para la busqueda
	String PCEPrecioClave = null;
	String TransProdIds = null;
	String moduloEsquemas = "";
	int tipoValidacionExistencia = TiposValidacionInventario.NoValidar;
	short tipoMovimiento;
	short tipoTransProd;
	//ModuloMovDetalle moduloMovDetalle = null;
	boolean mDevolucionesManuales = false;
	Context context;

	boolean bClaveManual = false;
	boolean bMostrandoBusqueda = false;
	boolean bAdvertencia = false;
	String error = "";

	// ************************************************ constructores
	// ************************************************
	public CapturaProducto(Context context, AttributeSet attrs)
	{
		super(context, attrs);
		inicializar();
	}

	public CapturaProducto(Context context)
	{
		super(context);
		inicializar();
	}

	// ***************************************************************************************************************

	// ****************************************** funciones generales
	// ************************************************
	private void inicializar()
	{
		// Utilizamos el layout como interfaz del control
		String infService = Context.LAYOUT_INFLATER_SERVICE;
		LayoutInflater li = (LayoutInflater) getContext().getSystemService(infService);
		li.inflate(R.layout.captura_producto, this, true);

		if (this.isInEditMode()) // para que no truene cuando se agrega al
									// layout en vista de diseño
			return;

		// Obtenemos las referencias a los distintos controles
		txtScanner = (TextBoxScanner) findViewById(R.id.textBoxScanner);
		txtScanner.setOnCodigoIngresado(mCodigoBarras);
		txtScanner.setOnTextChanged(new OnTextChangedListener()
		{
			@Override
			public void OnTextChanged(CharSequence s)
			{
				if (bClaveManual)
					return;
				if (cboUnidad.getAdapter() != null)
				{
					((SimpleCursorAdapter) cboUnidad.getAdapter()).getCursor().close();
				}
				txtCantidad.setText("");
				lblProDescripcion.setText("");
				lblProExistencia.setText("");

				oProducto = null;
			}
		});

		//btnBuscar = (LinearLayout) findViewById(R.id.btnBuscarProducto); //se cambio el id al ImageButton en el layout (captura_producto.xml), con el LinearLayout daba problemas al darle click
		btnBuscar = (ImageButton) findViewById(R.id.btnBuscarProducto);
		btnBuscar.setOnClickListener(mBuscarProducto);

		cboUnidad = (Spinner) findViewById(R.id.cboUnidad);
		txtCantidad = (EditText) findViewById(R.id.txtCantidad);
		txtCantidad.selectAll();
		txtCantidad.setSelectAllOnFocus(true);

		lblProDescripcion = (TextView) findViewById(R.id.lblProDescripcion);
		lblProExistencia = (TextView) findViewById(R.id.lblProExistencia);
		// final InputMethodManager imm = (InputMethodManager)
		// context.getSystemService(Context.INPUT_METHOD_SERVICE);

		txtCantidad.setOnKeyListener(new OnKeyListener()
		{

			@Override
			public boolean onKey(View v, int keyCode, KeyEvent event)
			{
				if (event.getAction() == KeyEvent.ACTION_UP)
				{
					// check if the right key was pressed
					if (keyCode == KeyEvent.KEYCODE_ENTER)
					{
						btnAgregar.performClick();
						return true;
					}
				}
				return false;
			}
		});

		btnAgregar = (ImageButton) findViewById(R.id.btnAgregar);
		btnAgregar.setOnClickListener(mAgregarProducto);

		Activity act = (Activity) li.getContext();
		mVista = (Vista) act;
	}

	public void limpiarProducto()
	{
		try
		{
			txtScanner.BorrarTexto();
			if (cboUnidad.getAdapter() != null)
			{
				((SimpleCursorAdapter) cboUnidad.getAdapter()).getCursor().close();
			}
			cboUnidad.setEnabled(false);
			txtCantidad.setText("");
			lblProDescripcion.setText("");
			lblProExistencia.setText("");
			oProducto = null;
			txtScanner.requestFocus();
		}
		catch (Exception e)
		{
			Log.e("", "" + e);

		}

	}

	public void llenarProductoUnidad(Producto producto, int tipoUnidad, Float cantidad)
	{
		txtScanner.setTexto(producto.ProductoClave);
		oProducto = producto;
		try
		{
			obtenerDetallesProducto(producto);
			Generales.SelectSpinnerItemByValue(cboUnidad, tipoUnidad);

			txtCantidad.setText(cantidad.toString());
			if (cboUnidad.getCount() > 1)
			{
				cboUnidad.requestFocus();
			}
			else
			{
				cboUnidad.setEnabled(false);
				txtCantidad.requestFocus();
				txtCantidad.selectAll();
				txtCantidad.setSelectAllOnFocus(true);
			}
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	// ***************************************************************************************************************

	// ****************************** setters para los parametros de la busqueda
	// *************************************
	public void setPCEPrecioClave(String precioClave)
	{
		PCEPrecioClave = precioClave;
	}

	public void setTransProdIds(String transProdIds)
	{
		TransProdIds = transProdIds;
	}

	public void setModuloEsquemas(String pModuloEsquemas)
	{
		moduloEsquemas = pModuloEsquemas;
	}
	public void setTipoValidacionExistencia(int tipoValidaExistencia)
	{
		tipoValidacionExistencia = tipoValidaExistencia;
	}

	public void setTipoMovimiento(short pTipoMovimiento)
	{
		tipoMovimiento = pTipoMovimiento;
	}

	public void setTipoTransProd(short pTipoTransProd)
	{
		tipoTransProd = pTipoTransProd;
	}

	public void setDevolucionesManuales(boolean Devolucion)
	{
		mDevolucionesManuales = Devolucion;
	}

	// *******Asignación de valores a las
	// propiedades************************************************
	public void setCantidad(Float cantidad)
	{
		txtCantidad.setText(cantidad.toString());
	}

	public void setError(String Error)
	{
		error = Error;
	}

	public void setAdvertencia(String Advertencia)
	{
		bAdvertencia = true;
		error = Advertencia;
	}

	// *************************************************************************************************
	public void setEnabled(boolean habilitar)
	{
		txtScanner.setEnabled(habilitar);
		btnBuscar.setEnabled(habilitar);
		cboUnidad.setEnabled(habilitar);
		txtCantidad.setEnabled(habilitar);
		btnAgregar.setEnabled(habilitar);
		txtScanner.habilitarBotonScanner(habilitar);
		/*
		 * if (!habiliar){
		 * 
		 * }
		 */
	}

	public void onActivityResult(int requestCode, int resultCode, Intent intent)
	{
		// pasar a la vista el manejo
		mVista.resultadoActividad(requestCode, resultCode, intent);

	}

	public void setFinBusqueda()
	{
		limpiarProducto();
		bMostrandoBusqueda = false;
	}

	private android.view.View.OnClickListener mBuscarProducto = new android.view.View.OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			buscarProducto(txtScanner.getTexto(), false);
		}
	};

	private OnCodigoIngresadoListener mCodigoBarras = new OnCodigoIngresadoListener()
	{
		public void OnCodigoIngresado(String Codigo, int codigoLeido)
		{
			if (bClaveManual)
				return;
			if (Codigo.length() == 0)
				return;

			buscarProducto(Codigo, codigoLeido == 1 ? true : false);
		}
	};

	private void buscarProducto(String cadenaBusqueda, boolean codigoLeido)
	{
		try
		{
			if (bClaveManual)
				return;
			if (cadenaBusqueda.equals(""))
			{
				if (bMostrandoBusqueda)
					return;
				if (buscarListener != null)
				{
					buscarListener.onProductoNoEncontrado();
				}
				final HashMap<String, Object> parametros = new HashMap<String, Object>();
				parametros.put("Esquema", "Todos");
				parametros.put("Cadena", cadenaBusqueda);
				parametros.put("ListaPrecios", PCEPrecioClave);
				parametros.put("TransProd", TransProdIds);
				parametros.put("TipoValidarExistencia", tipoValidacionExistencia);
				parametros.put("TipoMovimiento", tipoMovimiento);
				parametros.put("TipoTransProd", tipoTransProd);
				parametros.put("ModuloEsquemas", moduloEsquemas);
				bMostrandoBusqueda = true;
				mVista.iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_PRODUCTOS_SELECCIONADOS, parametros);
			}
			else
			{
				oProducto = null;
				if (!codigoLeido)
				{
					oProducto = Consultas.ConsultasProducto.obtenerProductoIdentico(cadenaBusqueda);
					if (oProducto == null)
					{
						// Buscar codigo barras
						ISetDatos unidades = Consultas.ConsultasProducto.buscarCodigoBarras(cadenaBusqueda, PCEPrecioClave);
						if (unidades != null && unidades.getCount() > 0)
						{
							if (unidades.moveToFirst())
							{
								bClaveManual = true;
								txtScanner.txtScanner.setText(unidades.getString("ProductoClave"));
								txtCantidad.requestFocus();
								bClaveManual = false;
								oProducto = Consultas.ConsultasProducto.obtenerProducto(unidades.getString("ProductoClave"));
								if (oProducto != null)
								{
									if (moduloEsquemas.length()>0){
										if (!Consultas.ConsultasProductoEsquema.productoEsquemaValido(oProducto.ProductoClave, moduloEsquemas)){
											mVista.mostrarError(Mensajes.get("E0923", "XModulo"));
											oProducto = null;
											unidades.close();
											return;
										}
									}
									obtenerDetallesProducto(oProducto);
									//mostrarUnidades(unidades);
									cboUnidad.setEnabled(false);
									mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
									unidades.close();
									return;
								}
							}
						}
						else
						{
							if (bMostrandoBusqueda)
								return;
							if (buscarListener != null)
							{
								buscarListener.onProductoNoEncontrado();
							}
							final HashMap<String, Object> parametros = new HashMap<String, Object>();
							parametros.put("Esquema", "Todos");
							parametros.put("Cadena", cadenaBusqueda);
							parametros.put("ListaPrecios", PCEPrecioClave);
							parametros.put("TransProd", TransProdIds);
							parametros.put("TipoValidarExistencia", tipoValidacionExistencia);
							parametros.put("TipoMovimiento", tipoMovimiento);
							parametros.put("TipoTransProd", tipoTransProd);
							parametros.put("ModuloEsquemas", moduloEsquemas);
							bMostrandoBusqueda = true;
							mVista.iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_PRODUCTOS_SELECCIONADOS, parametros);
						}
					}
					else
					{
						/*
						 * Se encontró el producto, buscar que pertenezca a los esquemas válidos
						 * para el módulo actual
						 */
						if (moduloEsquemas.length()>0){
							if (!Consultas.ConsultasProductoEsquema.productoEsquemaValido(oProducto.ProductoClave, moduloEsquemas)){
								mVista.mostrarError(Mensajes.get("E0923", "XModulo"));
								oProducto = null;
								return;
							}
						}
						obtenerDetallesProducto(oProducto);
					}
				}
				else
				{
					ISetDatos unidades = Consultas.ConsultasProducto.buscarCodigoBarras(cadenaBusqueda, PCEPrecioClave);
					if (unidades != null)
					{
						if (unidades.moveToFirst())
						{
							bClaveManual = true;
							txtScanner.txtScanner.setText(unidades.getString("ProductoClave"));
							txtCantidad.requestFocus();
							bClaveManual = false;
							oProducto = Consultas.ConsultasProducto.obtenerProducto(unidades.getString("ProductoClave"));
							if (oProducto != null)
							{
								if (moduloEsquemas.length()>0){
									if (!Consultas.ConsultasProductoEsquema.productoEsquemaValido(oProducto.ProductoClave, moduloEsquemas)){
										mVista.mostrarError(Mensajes.get("E0923", "XModulo"));
										oProducto = null;
										unidades.close();
										return;
									}
								}
								obtenerDetallesProducto(oProducto);
								//mostrarUnidades(unidades);
								cboUnidad.setEnabled(false);							
								mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
								unidades.close();
								return;
							}
						}
					}
					mVista.mostrarError(Mensajes.get("E0863"));
					txtScanner.BorrarTexto();

				}
			}
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}
	}

	public void obtenerDetallesProducto(Producto producto)
	{
		try
		{
			validarProductoContenido(producto);
			lblProDescripcion.setText(producto.Nombre);
			if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
			{
				lblProExistencia.setText(Mensajes.get("XExist") + ": " + Generales.getFormatoDecimal(Consultas.ConsultasInventario.obtenerExistencia(producto.ProductoClave, PCEPrecioClave, mDevolucionesManuales), producto.DecimalProducto));
			}
			else
			{
				lblProExistencia.setVisibility(View.GONE);
			}

			ISetDatos unidades = Consultas.ConsultasProducto.obtenerUnidadesProducto(producto.ProductoClave, PCEPrecioClave);
			if (unidades.getCount() <= 0)
			{
				unidades.close();
				mVista.mostrarError("El producto no tiene unidades definidas");
			}
			else
			{
				mostrarUnidades(unidades);
			}
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
		}
	}

	@SuppressWarnings("deprecation")
	public void mostrarUnidades(ISetDatos unidades)
	{
		try
		{
			Cursor unidad = (Cursor) unidades.getOriginal();
			mVista.startManagingCursor(unidad);
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(mVista, android.R.layout.simple_spinner_item, unidad, new String[]
			{ "PRUTipoUnidad" }, new int[]
			{ android.R.id.text1 });
			adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
			adapter.setViewBinder(new vista());
			cboUnidad.setAdapter(adapter);
			if (cboUnidad.getCount() > 0)
			{
				cboUnidad.setSelection(0);
				cboUnidad.setEnabled(true);
				txtCantidad.requestFocus();
			}
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public boolean validarProductoContenido(Producto producto) throws Exception
	{
		if (producto.Contenido && !producto.Venta)
		{
			throw new ControlError("E0725");
		}
		return true;
	}

	public boolean validarCaptura()
	{
		if (oProducto == null)
		{
			mVista.mostrarError(Mensajes.get("BE0001", Mensajes.get("XProducto")));
			txtScanner.requestFocus();
			return false;
		}
		if (cboUnidad.getSelectedItemPosition() < 0)
		{
			mVista.mostrarError(Mensajes.get("BE0001", Mensajes.get("XUnidad")));
			cboUnidad.requestFocus();
			return false;
		}
		if (txtCantidad.getText().toString().trim().equals(""))
		{
			mVista.mostrarError(Mensajes.get("BE0001", Mensajes.get("XCantidad")));
			txtCantidad.requestFocus();
			return false;
		}

		return true;
	}

	private class vista implements ViewBinder
	{
		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case android.R.id.text1: // para llenar el combo de la unidad
					TextView combo = (TextView) view;
					Log.e("", ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("PRUTipoUnidad"))));
					combo.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("PRUTipoUnidad"))));
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}

	public String getCantidad()
	{
		return txtCantidad.getText().toString();
	}

	private OnClickListener mAgregarProducto = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			// solo se dispara el listener cuando esta el producto capturado y
			// tiene cantidad > 0
			if (agregarListener == null)
				return;
			// if(agregarListener != null && oProducto != null &&
			// !txtCantidad.getText().toString().equals("")){
			if (validarCaptura())
			{
				//permitir capturar cero en reparto, ya que la opcion de eliminar no existe, se eliminan con cero
				if (Float.parseFloat(txtCantidad.getText().toString()) > 0 || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && Float.parseFloat(txtCantidad.getText().toString()) == 0))
				{
					//ajustar la cantidad capturada al numero de decimales configurados para el producto
					float cantidad = Float.parseFloat(Generales.getFormatoDecimal(Float.parseFloat(txtCantidad.getText().toString()), oProducto.DecimalProducto));
					agregarListener.onAgregarProducto(oProducto, Integer.parseInt(String.valueOf(cboUnidad.getSelectedItemId())), cantidad);
					//agregarListener.onAgregarProducto(oProducto, Integer.parseInt(String.valueOf(cboUnidad.getSelectedItemId())), Float.parseFloat(txtCantidad.getText().toString()));
					if (error == "")
					{
						limpiarProducto();
					}
					else
					{
						mVista.mostrarError(error);
						error = "";
						if (bAdvertencia)
						{
							limpiarProducto();
							bAdvertencia = false;
						}
					}
				}
				else
				{
					mVista.mostrarError(Mensajes.get("E0012"));
				}
			}
		}
	};

	// ***************************** listener para agregar producto
	// **************************************
	public interface onAgregarProductoListener
	{
		void onAgregarProducto(Producto producto, int tipoUnidad, float cantidad);
	}

	private onAgregarProductoListener agregarListener = null;

	public void setOnAgregarProductoListener(onAgregarProductoListener l)
	{
		agregarListener = l;
	}

	// ***************************************************************************************************

	// ***************************** listener para buscar producto
	// ***************************************
	public interface onProductoNoEncontradoListener
	{
		void onProductoNoEncontrado();
	}

	private onProductoNoEncontradoListener buscarListener = null;

	public void setOnProductoNoEncontradoListener(onProductoNoEncontradoListener l)
	{
		buscarListener = l;
	}

}
