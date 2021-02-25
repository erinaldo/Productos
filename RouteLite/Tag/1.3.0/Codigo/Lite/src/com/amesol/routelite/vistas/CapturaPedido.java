package com.amesol.routelite.vistas;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.Map.Entry;
import java.util.concurrent.atomic.AtomicReference;

import android.app.AlertDialog;
import android.app.Dialog;
import android.app.DialogFragment;
import android.content.Context;
import android.content.DialogInterface;
import android.content.DialogInterface.OnShowListener;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnFocusChangeListener;
import android.view.View.OnKeyListener;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemLongClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.Spinner;
import android.widget.TableLayout.LayoutParams;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.ListaPrecio;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Promociones2;
import com.amesol.routelite.actividades.Promociones2.onTerminarAplicacionListener;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.CapturaProducto;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TPDImpuesto;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.Acciones;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.Solicitudes;
import com.amesol.routelite.presentadores.Enumeradores.TiposFasesDocto;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.presentadores.act.CapturarPedido;
import com.amesol.routelite.presentadores.interfaces.IAplicacionPromocion;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedidoSugerido;
import com.amesol.routelite.presentadores.interfaces.ICapturaTotales;
import com.amesol.routelite.presentadores.interfaces.ICapturaTotalesConsignacion;
import com.amesol.routelite.presentadores.interfaces.IConsultaUltimaVenta;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.DialogoAlerta;
 
public class CapturaPedido extends Vista implements ICapturaPedido
{

	CapturarPedido mPresenta;

	CapturaProducto captura;

	String mAccion;
	int index;
	int top;
	HashMap<String, String> oParametros = null;


	boolean siguiente = false;
	boolean salir = false;
	Object mPausaCiclo;
	//Runnable hiloFor;
	//Thread promo;
	boolean esNuevo = true;
	boolean soloLectura = false;
	boolean mostrandoPregunta = false;
	boolean huboCambios = false;
	boolean calculando = false;
	boolean regresandoPromo = false;
	boolean sugeridoMostrado = false;
	private Cursor producto;
	private Menu mnu;
	boolean surtir = false;
	boolean reparto = false;
	ArrayList<TransProdDetalle> prodSinExistencia = new ArrayList<TransProdDetalle>();
	boolean consultar = false;
	boolean modificando = false;
	MenuItem modificar;

	Iterator<TransProd> docsTransProd;

	ListView lista;
	Handler handler;

	Promociones2 promociones;
	
	Producto productoAgregar;
	int tipoUnidadAgregar;
	float cantidadAgregar;
	Float cantidadOriginalAgregar;
	String transprodIDEliminar;
	String transprodDetalleIDEliminar;
	boolean existe;
	
	private static final String FRAGMENT_TAG = "ventaMensualFragment";

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();
			setContentView(R.layout.captura_pedido);
			deshabilitarBarra(true);

			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO)
				setTitulo(Mensajes.get("XReparto"));
			else if(Integer.parseInt(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString()) == Enumeradores.TiposModuloMovDetalle.CONSIGNACION)
				setTitulo(Mensajes.get("XConsignacion"));
			else
				setTitulo(Mensajes.get("XVentas"));
			
			if(mAccion != null){
				if(mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_MOV_SIN_INV_EN_VISITA)){
					setTitulo(Consultas.ConsultasModuloMovDetalle.obtenerTitulo());
				}	
			}

			TextView texto = (TextView) findViewById(R.id.lblProducto);
			texto.setText(Mensajes.get("XProducto"));

			texto = (TextView) findViewById(R.id.lblUnidad);
			texto.setText(Mensajes.get("XUnidad"));

			texto = (TextView) findViewById(R.id.lblTotalPrevio);
			texto.setText(Mensajes.get("MDBTotalPrevio") + ":");
			
			texto = (TextView) findViewById(R.id.lblVolumen);
			texto.setText(Mensajes.get("XKgVol") + ":");

			texto = (TextView) findViewById(R.id.lblTotalProductos);
			texto.setText(Mensajes.get("MDBFilas") + ":");

			texto = (TextView) findViewById(R.id.lblTotalUnidades);
			texto.setText(Mensajes.get("XUnidades") + ":");

			Button boton = (Button) findViewById(R.id.btnSugerido);
			boton.setText(Mensajes.get("XSugerido"));
			boton.setOnClickListener(mPedidoSugerido);
			boton = (Button) findViewById(R.id.btnContinuar);
			boton.setText(Mensajes.get("XContinuar"));
			boton.setOnClickListener(mAplicarPromociones);

			lista = (ListView) findViewById(R.id.lsTransProdDetalle);
			lista.setItemsCanFocus(false);

			//TODO: checar esto!!!! cuando truena el quecolin se brinca todo el codigo que sigue ya que se va al catch!!! -Sergio
			//le agregue un try-catch para que no se fuera hasta abajo, checar si esta bien asi!!!
			try{
				encenderBluetooth();
			}catch(Exception e){
				e.printStackTrace();
			}
			
			captura = (CapturaProducto) findViewById(R.id.capturaProducto);

			captura.setOnAgregarProductoListener(new CapturaProducto.onAgregarProductoListener()
			{
				@Override
				public void onAgregarProducto(Producto producto, int tipoUnidad, float cantidad)
				{
					try
					{						
						Object aTransProdDetalle[] = Consultas.ConsultasTransProdDetalle.obtenerDetallePorProductoClaveUnidad(producto.ProductoClave, String.valueOf(tipoUnidad), mPresenta.getTransaccionesIds());
						
						MOTConfiguracion motConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
						//validacion NoAdicionProducto
						if(mPresenta.getTipoTransProd() == 1 && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) && motConf.get("NoAdicionProducto").toString().equals("1")){
							if(aTransProdDetalle == null){
								//no existe en el pedido, no se puede agregar
								mostrarAdvertencia(Mensajes.get("E0908"));
								return;
							}
							
							//si existe, validar cantidades
							float valorOriginal = Float.parseFloat(aTransProdDetalle[2].toString());
							float valorActual = cantidad;
							if(valorOriginal < valorActual){
								mostrarAdvertencia(Mensajes.get("E0908"));
								return;
							}
						}
						
						if (aTransProdDetalle != null)
						{ // si ya existe, seleccionarlo de la lista E0714
							if (Float.parseFloat(aTransProdDetalle[2].toString()) != cantidad)
							{
								AtomicReference<Float> existencia = new AtomicReference<Float>();
								StringBuilder error = new StringBuilder();
								if (mPresenta.getTipoValidacionExistencia() != TiposValidacionInventario.NoValidar)
								{
									if (!Inventario.ValidarExistencia(producto.ProductoClave, tipoUnidad, cantidad, Float.parseFloat(aTransProdDetalle[2].toString()), mPresenta.getModuloMovDetalle(), false, existencia, error))
									{
										captura.setError(error.toString());
										if (mPresenta.getTipoValidacionExistencia() == TiposValidacionInventario.ValidacionRestrictiva)
										{
											if(!validarVenderApartado(producto, tipoUnidad, cantidad, Float.parseFloat(aTransProdDetalle[2].toString()),aTransProdDetalle[0].toString(),aTransProdDetalle[1].toString()))
												return;
											if (existencia.get() != null && existencia.get() > 0)
											{
												captura.setCantidad(Float.parseFloat(aTransProdDetalle[2].toString()) + existencia.get());
											}
											else
											{
												captura.setCantidad(cantidad);
											}
											return;
										}
									}
									else
									{
										captura.setAdvertencia(error.toString());
									}
								}
																
								if(!mPresenta.validarCantMax(cantidad)){
									//no esta configurada ninguna cantidad, continuar normal
									mPresenta.eliminarDetalle(aTransProdDetalle[0].toString(), aTransProdDetalle[1].toString(), producto.SubEmpresaId, producto.ProductoClave, tipoUnidad, Float.parseFloat(aTransProdDetalle[2].toString()));
									
									if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO))
										mPresenta.agregarProductoUnidad(producto.ProductoClave, producto.SubEmpresaId, tipoUnidad, cantidad, Float.parseFloat("-1"),Float.parseFloat(aTransProdDetalle[2].toString()), aTransProdDetalle[1].toString());
									else
										mPresenta.agregarProductoUnidad(producto.ProductoClave, producto.SubEmpresaId, tipoUnidad, cantidad, Float.parseFloat("-1"), aTransProdDetalle[1].toString());	
								}else{
									//guardar la info en las varibles para poder agregar el producto si contesta que si a la pregunta
									productoAgregar = producto;
									tipoUnidadAgregar = tipoUnidad;
									cantidadAgregar = cantidad;
									cantidadOriginalAgregar = Float.parseFloat(aTransProdDetalle[2].toString());
									transprodIDEliminar = aTransProdDetalle[0].toString();
									transprodDetalleIDEliminar = aTransProdDetalle[1].toString();
									existe = true;
								}
								
							}
						}
						else
						{
							AtomicReference<Float> existencia = new AtomicReference<Float>();
							StringBuilder error = new StringBuilder();
							
							if (mPresenta.getTipoValidacionExistencia() != TiposValidacionInventario.NoValidar)
							{
								if (!Inventario.ValidarExistencia(producto.ProductoClave, tipoUnidad, cantidad, mPresenta.getModuloMovDetalle(), existencia, error))
								{
									captura.setError(error.toString());
									if (mPresenta.getTipoValidacionExistencia() == TiposValidacionInventario.ValidacionRestrictiva)
									{
										if(!validarVenderApartado(producto, tipoUnidad, cantidad))
											return;
										if (existencia.get() != null && existencia.get() > 0)
										{
											captura.setCantidad(existencia.get());
										}
										else
										{
											captura.setCantidad(Float.valueOf(0));
										}
										return;
									}
								}
								else
								{
									captura.setAdvertencia(error.toString());
								}
							}
							//mPresenta.agregarProductoUnidad(producto.ProductoClave, producto.SubEmpresaId, tipoUnidad, cantidad, Float.parseFloat("-1"));
							if(!mPresenta.validarCantMax(cantidad)){
								//no esta configurada ninguna cantidad, continuar normal
								mPresenta.agregarProductoUnidad(producto.ProductoClave, producto.SubEmpresaId, tipoUnidad, cantidad, Float.parseFloat("-1"));
							}else{
								//guardar la info en las varibles para poder agregar el producto si contesta que si a la pregunta
								productoAgregar = producto;
								tipoUnidadAgregar = tipoUnidad;
								cantidadAgregar = cantidad;
								existe = false;
							}
							
						}
					}
					catch (Exception e)
					{
						mostrarError(e.getMessage());
					}
				}
			});

			captura.setOnProductoNoEncontradoListener(new CapturaProducto.onProductoNoEncontradoListener()
			{

				@Override
				public void onProductoNoEncontrado()
				{
					captura.setTransProdIds(mPresenta.getTransProdIds());
				}
			});

			mPresenta = new CapturarPedido(this, mAccion);

			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");
			}

			if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")))
			{
				mPresenta.agregarTransaccion(oParametros.get("TransProdId"));
			}

			mPresenta.iniciar();

			if (mPresenta.errorFinalizar){
				return;
			}
			// si se paso como parametro el TransProdId, cargar el detalle del
			// pedido
			if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")))
			{
				//boolean reparto = false;
				if (oParametros != null && oParametros.get("Reparto") != null && (!oParametros.get("Reparto").trim().equals(""))){
					reparto = Boolean.parseBoolean(oParametros.get("Reparto"));
				}
				if (oParametros != null && oParametros.get("Consultar") != null && (!oParametros.get("Consultar").trim().equals(""))){
					consultar = Boolean.parseBoolean(oParametros.get("Consultar"));
				}
				if (oParametros != null && oParametros.get("Surtir") != null && (!oParametros.get("Surtir").trim().equals(""))){
					surtir = Boolean.parseBoolean(oParametros.get("Surtir"));
				}
				esNuevo = false;
				refrescarProductos(mPresenta.getTransaccionesIds());
				if (mPresenta.getTipoFase() == 0 || mPresenta.getTipoFase() == 3 ||((mPresenta.getTipoFase() == 2 || mPresenta.getTipoFase() == 1) && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO  && reparto) )
				{ // si esta cancelado o surtido mostrar como solo lectura, si viene de reparto tambien
						soloLectura = true;
						captura.setVisibility(View.GONE);
				}

			}
			else if (mPresenta.getPedidoSugerido())
			{
				esNuevo = true;
				refrescarProductos(mPresenta.getTransaccionesIds());
			}
			captura.setTipoValidacionExistencia(mPresenta.getTipoValidacionExistencia());

			captura.setCadenaListasPrecios(mPresenta.getListasPrecios());
			captura.setTipoMovimiento(mPresenta.getModuloMovDetalle().TipoMovimiento);
			captura.setTipoTransProd(mPresenta.getModuloMovDetalle().TipoTransProd);

			if (!soloLectura)
			{
				registerForContextMenu(lista);
				lista.setOnItemLongClickListener(menu);
			}

		}
		catch (Exception ex)
		{
			ex.printStackTrace();
			//			mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
		}
		final EditText txtScaner = (EditText) findViewById(R.id.txtScanner);
		final EditText txtCantidad = (EditText) findViewById(R.id.txtCantidad);

		final Spinner spinUnit = (Spinner) findViewById(R.id.cboUnidad);
		if (!(spinUnit.getCount() > 1))
			spinUnit.setEnabled(false);

		final InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);

		txtCantidad.setOnFocusChangeListener(new View.OnFocusChangeListener()
		{
			@Override
			public void onFocusChange(View v, boolean hasFocus)
			{
				// TODO Auto-generated method stub
				if (hasFocus)
				{
					// getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE);
					txtScaner.clearFocus();
					imm.showSoftInput(txtCantidad, InputMethodManager.SHOW_FORCED);
					if (!(spinUnit.getCount() > 1))
						spinUnit.setEnabled(false);

					String mCantidad = mPresenta.consultarUnidadProductoExistente(mPresenta.getTransProdIds(), txtScaner.getText().toString());
					if (!mCantidad.equals("0"))
					{
						txtCantidad.setText(mCantidad);
						txtCantidad.requestFocus();
						txtCantidad.selectAll();
						txtCantidad.setSelectAllOnFocus(true);
					}

				}
			}
		});

		txtScaner.setOnFocusChangeListener(new View.OnFocusChangeListener()
		{
			@Override
			public void onFocusChange(View v, boolean hasFocus)
			{

				if (hasFocus)
				{
					// getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE);
					txtCantidad.clearFocus();
				}
			}
		});
	}
	
	public void setCapturaCantidad(float cantidad){
		captura.setCantidad(cantidad);
	}
	

	private boolean validarVenderApartado(Producto producto, int tipoUnidad, float cantidad){
		return validarVenderApartado(producto,tipoUnidad,cantidad, null, null, null);
	}
	
	private boolean validarVenderApartado(Producto producto, int tipoUnidad, float cantidad, Float cantidadOriginal, String transProdID, String transProdDetalleID){
		if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
			if(((CONHist)Sesion.get(Campo.CONHist)).get("VenderApartado").toString().equals("0")){
				//mostrarAdvertencia(Mensajes.get("E0714").replace("$0$", productoClave));
				captura.setError(Mensajes.get("E0714").replace("$0$", producto.ProductoClave));
				return false;
			}else if(((CONHist)Sesion.get(Campo.CONHist)).get("VenderApartado").toString().equals("1")){
				AtomicReference<Float> existencia = new AtomicReference<Float>();
				StringBuilder error = new StringBuilder();
				if(!Inventario.ValidarExistenciaDifNoDisponible(producto.ProductoClave, tipoUnidad, cantidad, existencia, error)){
					//mostrarAdvertencia(Mensajes.get("E0714").replace("$0$", productoClave));
					captura.setError(Mensajes.get("E0714").replace("$0$", producto.ProductoClave));
					return false;
				}
				mostrarPreguntaSiNo(Mensajes.get("P0087"), 10);
				captura.setError("");
				//guardar todo en las varibles para poder agregar si responde SI
				productoAgregar = producto;
				tipoUnidadAgregar = tipoUnidad;
				cantidadAgregar = cantidad;
				cantidadOriginalAgregar = cantidadOriginal;
				transprodIDEliminar = transProdID;
				transprodDetalleIDEliminar = transProdDetalleID;
			}
		}
		return true;
	}

	public void onWindowFocusChanged(boolean hasFocus)
	{

		super.onWindowFocusChanged(hasFocus);

		if (hasFocus)
		{
			if (regresandoPromo)
			{
				regresandoPromo = false;
				try
				{
					if (Sesion.get(Campo.ResultadoActividad) != null)
					{
						if ((Boolean) Sesion.get(Campo.ResultadoActividad))
						{
							promociones.TerminoPromocionRegalo();
							Sesion.remove(Campo.ResultadoActividad);
						}
						else
						{
							promociones.SiguientePromocion();
							Sesion.remove(Campo.ResultadoActividad);
						}
					}
					else
					{
						promociones.SiguientePromocion();
					}
				}
				catch (Exception e)
				{
					// TODO Auto-generated catch block
					mostrarError(e.getMessage());
				}
			}
		}
		// Toast.makeText(context, text, duration).show();
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				VentaMensual fmFragment;
				if((fmFragment = (VentaMensual) getFragmentManager().findFragmentByTag(FRAGMENT_TAG)) != null){
					fmFragment.close();
				}else{
					salir();
				}
				return true;
		}
		return super.onKeyDown(keyCode, event);	
	}

	public OnItemLongClickListener menu = new OnItemLongClickListener()
	{

		@Override
		public boolean onItemLongClick(AdapterView<?> arg0, View arg1, int arg2, long arg3)
		{
			openContextMenu(lista);
			return true;
		}
	};

	@Override
	public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo)
	{
		super.onCreateContextMenu(menu, v, menuInfo);
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.context_transaccion_detalle, menu);
		 
		menu.getItem(0).setTitle(Mensajes.get("XEliminar"));
		if (((Vendedor) Sesion.get(Campo.VendedorActual)).ModificarPrecios == 1){
			menu.getItem(1).setTitle(Mensajes.get("XModificarPrecio"));	
			menu.getItem(1).setVisible(true);
		}
	}

	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		switch (item.getItemId())
		{
			case R.id.eliminar:
				mostrandoPregunta = true;
				mostrarPreguntaSiNo(Mensajes.get("P0233"), 2);
				return true;
			case R.id.modificarPrecio:
				try
				{

					LayoutInflater inflater = (LayoutInflater) CapturaPedido.this
							.getSystemService(Context.LAYOUT_INFLATER_SERVICE);

					View dialogView = inflater.inflate(R.layout.dialog_number_picker, null);

					AlertDialog.Builder builder = new AlertDialog.Builder(CapturaPedido.this);
					final EditText  np = (EditText) dialogView.findViewById(R.id.numText );
					np.setSelectAllOnFocus(true);


					Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
					final String transProdID= producto.getString(producto.getColumnIndex("TransProdID"));
					final String transProdDetalleID = producto.getString(producto.getColumnIndex("TransProdDetalleID"));
					final String subEmpresaId = producto.getString(producto.getColumnIndex("SubEmpresaId"));
					final String productoClave = producto.getString(producto.getColumnIndex("ProductoClave"));
					final int tipoUnidad = producto.getInt(producto.getColumnIndex("TipoUnidad"));
					final float cantidad = producto.getFloat(producto.getColumnIndex("Cantidad"));
					final float precio = Generales.getRound(producto.getFloat(producto.getColumnIndex("Precio")),Integer.parseInt(((CONHist)Sesion.get(Campo.CONHist)).get("DecimalesImporte").toString()));
					np.setText(Generales.getFormatoDecimal(producto.getFloat(producto.getColumnIndex("Precio")),Integer.parseInt(((CONHist)Sesion.get(Campo.CONHist)).get("DecimalesImporte").toString())));
					np.selectAll();
					np.requestFocus();
					
					np.setOnFocusChangeListener(new OnFocusChangeListener() {
						@Override public void onFocusChange(View v, boolean hasFocus) {
						    if (!hasFocus) {
						        String userInput = np.getText().toString();

						        if (userInput.toString().matches("")) {
						            userInput = "0.00";
						        } else {
						            float floatValue = Float.parseFloat(userInput);						           
						            userInput = String.format("%." + Integer.parseInt(((CONHist)Sesion.get(Campo.CONHist)).get("DecimalesImporte").toString())  + "f",floatValue);
						        }

						        np.setText(userInput);
						        np.selectAll();
						    }
						}
						});
										
					builder.setPositiveButton(Mensajes.get("XAceptar"),new DialogInterface.OnClickListener()
					{
						
						@Override
						public void onClick(DialogInterface dialog, int which)
						{
							MOTConfiguracion motConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
							float precioEspecial = Generales.getRound(Float.parseFloat(np.getText().toString()),Integer.parseInt(((CONHist)Sesion.get(Campo.CONHist)).get("DecimalesImporte").toString()));
							if(precio != precioEspecial){
								if(motConf.get("ValidaRangoPrecio").toString().equals("1")){
										try{
											Float precioMin = ListaPrecio.ObtenerPecioMinimo(mPresenta.getListasPrecios(), productoClave, tipoUnidad);
											if(precioEspecial >= precioMin && precioEspecial <= precio){
												mPresenta.eliminarDetalle(transProdID, transProdDetalleID, subEmpresaId, productoClave, tipoUnidad, cantidad );													
												mPresenta.agregarProductoUnidad(productoClave, subEmpresaId, tipoUnidad, cantidad, precioEspecial);
												dialog.dismiss();	
											}else{
												mostrarError(Mensajes.get("I0278"));
												return;
											}
										}
										catch (Exception e){
											mostrarError(e.getMessage());
										}
								}else{
									if (Float.parseFloat(np.getText().toString()) < 0f){
										mostrarError(Mensajes.get("E0007"));
										return;
									}
									if(precio != precioEspecial){
										mPresenta.eliminarDetalle(transProdID, transProdDetalleID, subEmpresaId, productoClave, tipoUnidad, cantidad );													
										mPresenta.agregarProductoUnidad(productoClave, subEmpresaId, tipoUnidad, cantidad, precioEspecial);
										dialog.dismiss();
									}
								}
							}else{
								dialog.dismiss();	
							}
							
					  }
							
					});
					
					
					builder.setNegativeButton(Mensajes.get("XCancelar"),new DialogInterface.OnClickListener()
					{						
						@Override
						public void onClick(DialogInterface dialog, int which)
						{
							
							dialog.dismiss();
					  }
							
					});
					builder.setView(dialogView);
					final Dialog dialog = builder.create();
					
					 dialog.setOnShowListener(new OnShowListener() {
				            @Override
				            public void onShow(DialogInterface dialog) {   
								final Button btPrecioAceptar;
				            	btPrecioAceptar = ((AlertDialog) dialog)
				                        .getButton(AlertDialog.BUTTON_POSITIVE);
				            	
								np.setOnKeyListener(new OnKeyListener()
								{

									@Override
									public boolean onKey(View v, int keyCode, KeyEvent event)
									{
										if (event.getAction() == KeyEvent.ACTION_UP)
										{
											// check if the right key was pressed
											if (keyCode == KeyEvent.KEYCODE_ENTER)
											{
												btPrecioAceptar.performClick();
												return true;
											}
										}
										return false;
									}
								});
				            }
				        });

					dialog.show();
					
				}
				catch (Exception ex)
				{
					mostrarError(ex.getMessage());
				}
				
				return true;
			default:
				return super.onOptionsItemSelected(item);
		}
		

	}


	@Override
	public void iniciar()
	{

	}

	public void mostrarPromocionProducto(String promocionClave, String promocionReglaID, int CantidadGrupoApp, String SubEmpresaId, int cantidad)
	{
		HashMap<String, Object> oParametros = new HashMap<String, Object>();
		oParametros.put("PromocionClave", promocionClave);
		oParametros.put("PromocionReglaID", promocionReglaID);
		oParametros.put("CantidadGrupo", CantidadGrupoApp);
		oParametros.put("SubEmpresaID", SubEmpresaId);
		oParametros.put("CantidadMax", cantidad);
		oParametros.put("TipoValidarExistencia", mPresenta.getTipoValidacionExistencia());
		iniciarActividadConResultado(IAplicacionPromocion.class, Solicitudes.SOLICITUD_MOSTRAR_PROMOCIONES_APLICADAS, Acciones.ACCION_APLICAR_PROMOCIONES, oParametros);
	}

	@SuppressWarnings("deprecation")
	public void mostrarObligatorio(String mensaje, final int tipoMensaje, String...titulo)
	{

		DialogoAlerta dialogo = new DialogoAlerta(this);
		dialogo.setMessage(mensaje);
		dialogo.setCancelable(false);
		String msgSi = "Si";
		String msgNo = "No";
		if (Mensajes.existe())
		{
			msgSi = Mensajes.get("XSi");
			msgNo = Mensajes.get("XNo");
		}

		dialogo.setButton(msgSi, new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int id)
			{
				respuestaMensaje(RespuestaMsg.Si, tipoMensaje);
				dialog.dismiss();
			}
		});
		dialogo.setButton2(msgNo, new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int id)
			{
				respuestaMensaje(RespuestaMsg.No, tipoMensaje);
				dialog.cancel();
			}
		});
		dialogo.show();
	}

	@SuppressWarnings("unchecked")
	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if (requestCode == Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS)
		{
			// si esta regresándo de la busqueda de productos
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				// si selecciono Agregar en la busqueda de productos, obtener la
				// seleccion y agregarlos al pedido
				// DatosProductos productosSeleccionados;
				// productosSeleccionados = (DatosProductos)
				// data.getExtras().getParcelable("Objeto");
				if (Sesion.get(Campo.ResultadoActividad) != null)
				{
					insertarSeleccion((HashMap<String, TransProdDetalle>) Sesion.get(Campo.ResultadoActividad));
					Sesion.remove(Campo.ResultadoActividad);
				}
			}
			else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
			{
				if (data != null)
				{
					String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
					if (!mensajeError.equals(""))
					{ // cuando se presiona back se manda el mensaje vacio
						mostrarError(mensajeError);
					}
				}
			}

			captura.setFinBusqueda();
		}
		else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_PROMOCIONES_APLICADAS)
		{
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				regresandoPromo = true;
			}
			//				try
			//				{
			//					if (Sesion.get(Campo.ResultadoActividad) != null)
			//					{
			//						if ((Boolean) Sesion.get(Campo.ResultadoActividad))
			//						{
			//							promociones.TerminoPromocionRegalo();
			//							Sesion.remove(Campo.ResultadoActividad);
			//						}
			//						else
			//						{
			//							promociones.SiguientePromocion();
			//							Sesion.remove(Campo.ResultadoActividad);
			//						}
			//					}
			//					else
			//					{
			//						promociones.SiguientePromocion();
			//					}
			//				}
			//				catch (Exception e)
			//				{
			//					// TODO Auto-generated catch block
			//					mostrarError(e.getMessage());
			//				}

			// TODO, que pasa si la promocion marca error

			// si esta regresando de la pantalla de promociones, continuar el
			// ciclo
			/*
			 * if(resultCode == Enumeradores.Resultados.RESULTADO_BIEN){
			 * synchronized(mPausaCiclo){ siguiente = true;
			 * mPausaCiclo.notifyAll(); } }else if(resultCode ==
			 * Enumeradores.Resultados.RESULTADO_MAL){
			 * synchronized(mPausaCiclo){ siguiente = true; salir = true;
			 * mPausaCiclo.notifyAll(); } }
			 */
		}
		else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_TOTALES)
		{
			// regreso de la pantalla de totales
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				// si selecciono terminar, finalizar la captura del pedido
				setResult(Enumeradores.Resultados.RESULTADO_BIEN);
				finalizar();
			}
			else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
			{
				String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
				if (!mensajeError.equals(""))
				{ // cuando se presiona back se manda el mensaje vacio
					this.setResultado(Enumeradores.Resultados.RESULTADO_MAL, mensajeError);
					finalizar();
				}
				else
				{ // si el mensaje esta vacio, presiono back
					mPresenta.eliminarPromos();
				}
			}
		}
		else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_PEDIDO_SUGERIDO)
		{
			// si esta regresándo de la busqueda de productos
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				// si selecciono Agregar en la busqueda de productos, obtener la
				// seleccion y agregarlos al pedido
				// DatosProductos productosSeleccionados;
				// productosSeleccionados = (DatosProductos)
				// data.getExtras().getParcelable("Objeto");
				if (Sesion.get(Campo.ResultadoActividad) != null)
				{
					insertarSeleccionSugerido((HashMap<String, HashMap<Short, TransProdDetalle>>) Sesion.get(Campo.ResultadoActividad));
					Sesion.remove(Campo.ResultadoActividad);
				}
			}
			else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
			{
				if (data != null)
				{
					String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
					if (!mensajeError.equals(""))
					{ // cuando se presiona back se manda el mensaje vacio
						mostrarError(mensajeError);
					}
				}
			}
		}else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES_ENVIO_PARCIAL) && (resultCode == Enumeradores.Resultados.RESULTADO_BIEN))
			//si el envio parcial fue correcto, sincronizar el inventario
			mPresenta.obtenerInventarioEnLinea();
		else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES_ENVIO_PARCIAL || requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES) && (resultCode == Enumeradores.Resultados.RESULTADO_MAL))
		{
			if (data != null)
			{
				String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
				if (mensajeError != null)
				{
					iniciarActividad(ICapturaPedido.class, mensajeError);
					return;
				}
			}
			iniciarActividad(ICapturaPedido.class);
		}
		else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_TOTALES_CONSIGNACION)
		{
			// regreso de la pantalla de totales
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				// si selecciono terminar, finalizar la captura del pedido
				setResultado(Enumeradores.Resultados.RESULTADO_MAL);
				finalizar();
			}
			else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
			{
				if (!esNuevo)
				{ // cuando se presiona back se manda el mensaje vacio
					if(mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CONSIGNACIONES))
					{
						salir();
					}else{
						this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
						finalizar();
					}
				}
				else
				{ // si el mensaje esta vacio, presiono back
					mPresenta.eliminarPromos();
				}
			}
		}

	}

	@Override
	public void onDestroy()
	{
		super.onDestroy();
		/*
		 * if (promo != null) { // detener el hilo antes de salir para que no se
		 * bloquee promo.interrupt(); promo = null; }
		 */
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if (tipoMensaje == 2)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
				mPresenta.eliminarDetalle(producto.getString(producto.getColumnIndex("TransProdID")), producto.getString(producto.getColumnIndex("TransProdDetalleID")), producto.getString(producto.getColumnIndex("SubEmpresaId")), producto.getString(producto.getColumnIndex("ProductoClave")), producto.getInt(producto.getColumnIndex("TipoUnidad")), producto.getFloat(producto.getColumnIndex("Cantidad")));
				captura.limpiarProducto();
			}
			mostrandoPregunta = false;
		}
		else if (tipoMensaje == 3)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				regresar();
			}
		}
		else if (tipoMensaje == 99)
		{ // pregunta aplicar promocion
			/*
			 * synchronized(mPausaCiclo){ siguiente = true;
			 * mPausaCiclo.notifyAll(); }
			 */

			try
			{
				if (respuesta.equals(RespuestaMsg.Si))
				{
					if (promociones.promocionActual.Tipo == com.amesol.routelite.actividades.Enumeradores.Promocion.Tipo.ProductoAcumulado)
					{
						if (promociones.reglaAcumActual != null)
						{
							promociones.reglaAcumActual.Aplicar();
							promociones.promocionActual.SeAcepto = true;
						}
					}
					else
					{
						if (promociones.reglaActual != null)
						{
							promociones.reglaActual.Aplicar();
						}
					}
				}
				promociones.SiguientePromocion();

			}
			catch (Exception ex)
			{
				mostrarError(ex.getMessage());
			}
		}else if(tipoMensaje == 50){
			try
			{
				if (respuesta == RespuestaMsg.Si){
					//TODO: ajustar inventario
					for(TransProdDetalle oTpd : prodSinExistencia){
						if(oTpd.Promocion == 2){
								Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, TiposTransProd.PEDIDO, TiposMovimientos.NO_DEFINIDO, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID, true);
								oTpd.CantidadOriginal = oTpd.Cantidad;
								oTpd.Cantidad = 0;
						}
					}
				}else{
					regresar();
				}
			}
			catch (Exception e)
			{
				e.printStackTrace();
			}
		}else if(tipoMensaje == 20){
			if(respuesta == RespuestaMsg.Si){
				//TODO: modificar pedido
				modificarPedidoReparto();
				/*captura.setVisibility(View.VISIBLE);
				modificando = true;
				modificar.setEnabled(false);
				mPresenta.modificarPedido();*/
			}
		}else if(tipoMensaje == 10){
			if(respuesta == RespuestaMsg.Si){
				//mostrarAdvertencia("Agregar Producto");
				if(cantidadOriginalAgregar == null)
					mPresenta.agregarProductoUnidad(productoAgregar.ProductoClave, productoAgregar.SubEmpresaId, tipoUnidadAgregar, cantidadAgregar, Float.parseFloat("-1"));
				else{
					mPresenta.eliminarDetalle(transprodIDEliminar, transprodDetalleIDEliminar, productoAgregar.SubEmpresaId, productoAgregar.ProductoClave, tipoUnidadAgregar, cantidadOriginalAgregar);
					mPresenta.agregarProductoUnidad(productoAgregar.ProductoClave, productoAgregar.SubEmpresaId, tipoUnidadAgregar, cantidadAgregar, Float.parseFloat("-1"), cantidadOriginalAgregar);
				}
			}else{
				//mostrarAdvertencia("NO Agregar Producto");
			}
		}else if(tipoMensaje == 30){
			//cantidad maxima de producto
			if(respuesta == RespuestaMsg.Si){
				if(existe){
					mPresenta.eliminarDetalle(transprodIDEliminar, transprodDetalleIDEliminar, productoAgregar.SubEmpresaId, productoAgregar.ProductoClave, tipoUnidadAgregar, cantidadOriginalAgregar);
					if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO))
						mPresenta.agregarProductoUnidad(productoAgregar.ProductoClave, productoAgregar.SubEmpresaId, tipoUnidadAgregar, cantidadAgregar, Float.parseFloat("-1"),cantidadOriginalAgregar, transprodDetalleIDEliminar);
					else
						mPresenta.agregarProductoUnidad(productoAgregar.ProductoClave, productoAgregar.SubEmpresaId, tipoUnidadAgregar, cantidadAgregar, Float.parseFloat("-1"), cantidadOriginalAgregar);
				}else{
					mPresenta.agregarProductoUnidad(productoAgregar.ProductoClave, productoAgregar.SubEmpresaId, tipoUnidadAgregar, cantidadAgregar, Float.parseFloat("-1"));
				}
			}
		}else if(tipoMensaje ==0){
			if(mPresenta.errorFinalizar){
				finalizar();
			}
		}
	}
	
	private void modificarPedidoReparto(){
		//registerForContextMenu(lista);
		//lista.setOnItemLongClickListener(menu);
		captura.setVisibility(View.VISIBLE);
		modificando = true;
		modificar.setEnabled(false);
		mPresenta.modificarPedido();
	}

	private void salir()
	{
		if (!esNuevo)
		{
			if (!soloLectura)
				mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
			else
			{
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				finalizar();
			}
		}
		else
		{
			if (hayProductos())
			{
				if (!soloLectura)
					mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
				else
				{
					setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
					finalizar();
				}
			}
			else
			{ // no hay productos
				regresar();
			}
		}
	}

	private void regresar()
	{
		try
		{
			if (esNuevo)
			{
				BDVend.rollback();
			}
			else
			{
				if (huboCambios)
					BDVend.rollback();
			}
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	@SuppressWarnings("rawtypes")
	public void insertarSeleccion(HashMap<String, TransProdDetalle> transProdDetalles)
	{
		try
		{
			Iterator<Entry<String, TransProdDetalle>> it = transProdDetalles.entrySet().iterator();
			boolean bHuboInserciones = false;
			while (it.hasNext())
			{ // recorrer los productos
				Map.Entry producto = (Map.Entry) it.next();
				String productoClave = producto.getKey().toString();
				// int tipoUnidad =((TransProdDetalle)
				// producto.getValue()).TipoUnidad ;
				// Ya no es necesario buscar si existe porque se filtran los
				// productos que ya fueron capturados
				// Object aTransProdDetalle[] =
				// Consultas.ConsultasTransProdDetalle.obtenerDetallePorProductoClaveUnidad(productoClave,
				// String.valueOf(tipoUnidad), mPresenta.getTransaccionesIds());
				boolean validar = false;
				Producto oProducto = Consultas.ConsultasProducto.obtenerProducto(productoClave);
				try
				{
					validar = mPresenta.validarProductoContenido(oProducto);
				}
				catch (Exception ex)
				{
					mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
				}
				if (/* aTransProdDetalle== null && */validar)
				{ // agregarlo solo si no existe
					try
					{
						bHuboInserciones = true;
						//mPresenta.agregarProductoUnidad(oProducto.SubEmpresaId, ((TransProdDetalle) producto.getValue()), false);
						mPresenta.agregarProductoUnidad(oProducto, ((TransProdDetalle) producto.getValue()), false);
					}
					catch (Exception ex)
					{
						mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
					}
				}
			}

			if (bHuboInserciones)
			{
				refrescarProductos(mPresenta.getTransaccionesIds());
			}
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	@SuppressWarnings(
	{ "rawtypes", "unchecked" })
	public void insertarSeleccionSugerido(HashMap<String, HashMap<Short, TransProdDetalle>> transProdDetalles)
	{
		try
		{
			boolean bHuboInserciones = false;
			Iterator<Entry<String, HashMap<Short, TransProdDetalle>>> itProd = transProdDetalles.entrySet().iterator();
			while (itProd.hasNext())
			{
				Map.Entry producto = (Map.Entry) itProd.next();

				boolean validar = false;
				Producto oProducto = Consultas.ConsultasProducto.obtenerProducto(producto.getKey().toString());
				try
				{
					validar = mPresenta.validarProductoContenido(oProducto);
				}
				catch (Exception ex)
				{
					mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
				}
				Iterator<Entry<Short, TransProdDetalle>> it = ((HashMap<Short, TransProdDetalle>) producto.getValue()).entrySet().iterator();
				while (it.hasNext())
				{ // recorrer los productos
					Map.Entry productoUnidad = (Map.Entry) it.next();
					// Los productos que ya estan capturados no se permite editar
					//por lo que no es necesario verificar la existencia, ademas, ya se valido el inventario en caso de ser necesario.

					if (validar)
					{ // agregarlo solo si no existe
						try
						{
							bHuboInserciones = true;
							//mPresenta.agregarProductoUnidad(oProducto.SubEmpresaId, ((TransProdDetalle) productoUnidad.getValue()), false);
							mPresenta.agregarProductoUnidad(oProducto, ((TransProdDetalle) productoUnidad.getValue()), false);
						}
						catch (Exception ex)
						{
							mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
						}
					}
				}
			}

			if (bHuboInserciones)
			{
				refrescarProductos(mPresenta.getTransaccionesIds());
			}
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	public void setProductoActual(Producto producto)
	{
		txtScanner.setTexto(producto.ProductoClave);
		txtScanner.setTag(producto.SubEmpresaId);
	}

	public void setListaPrecios(String valor)
	{
		TextView texto = (TextView) findViewById(R.id.lblListaPrecios);
		texto.setText(valor);
	}

	public void setHuboCambios(boolean cambio)
	{
		huboCambios = cambio;
	}

	public boolean getSurtir()
	{
		return surtir;
	}
	
	public boolean getReparto()
	{
		return reparto;
	}
	private OnClickListener mPedidoSugerido = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{
			final HashMap<String, Object> parametros = new HashMap<String, Object>();
			parametros.put("ListaPrecios", mPresenta.getListasPrecios());
			parametros.put("TransProd", mPresenta.getTransProdIds());
			parametros.put("tipoValidacionExistencia", mPresenta.getTipoValidacionExistencia());
			parametros.put("ModuloMovDetalle", mPresenta.getModuloMovDetalle());
			parametros.put("mostrarValIniciales", !sugeridoMostrado);
			sugeridoMostrado = true;
			iniciarActividadConResultado(ICapturaPedidoSugerido.class, Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_PEDIDO_SUGERIDO, Enumeradores.Acciones.ACCION_CAPTURAR_SUGERIDO, parametros);

		}
	};

	/**
	 * Para el caso del modulo de consignaciones que reutiliza esta actividad, se deberá
	 * de validar la bandera CancConsigLiqui para calcular o no promociones.
	 */
	private OnClickListener mAplicarPromociones = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			Button boton = (Button) findViewById(R.id.btnContinuar);
			boton.setEnabled(false);
			if (!hayProductos())
			{
				mostrarError(Mensajes.get("MDBAsignarProducto"));
			}
			else
			{
				boolean cancConsigLiqui = "0".equals(((CONHist)Sesion.get(Campo.CONHist)).get("CancConsigLiqui"));
				if(consultar || (mPresenta.getModuloMovDetalle().TipoTransProd == TiposTransProd.VENTA_CONSIGNACION && cancConsigLiqui)
						|| (mAccion != null && mAccion.equals(Enumeradores.Acciones.ACCION_ELIMINAR_CONSIGNACIONES))){
					Sesion.set(Campo.ArrayTransProd, mPresenta.getHashMapTransacciones());
					iniciarCapturaTotales();
				}else{
					Sesion.set(Campo.ArrayTransProd, mPresenta.getHashMapTransacciones());
					mPausaCiclo = new Object();
					docsTransProd = mPresenta.getHashMapTransacciones().values().iterator();
					if (docsTransProd.hasNext())
					{
						calcularPromociones(docsTransProd.next());
					}
				}
			}
			boton.setEnabled(true);
		}
	};

	private boolean hayProductos()
	{
		TextView totalProductos = (TextView) findViewById(R.id.txtTotalProductos);
		if (totalProductos.getText().toString().trim().equals("") || Float.parseFloat(totalProductos.getText().toString().replace(",", ".")) == 0)
			return false;
		else
			return true;
	}

	private void calcularPromociones(TransProd transProd)
	{

		// for(final Object transProd :
		// mPresenta.getHashMapTransacciones().values().toArray()){ //recorrer
		// todas las transacciones generadas y aplicar las promociones
		// correspondientes
		try
		{
			siguiente = false;
			try
			{
				BDVend.recuperar((TransProd) transProd, TransProdDetalle.class);
			}
			catch (Exception e)
			{
				e.printStackTrace();
			}

			promociones = new Promociones2((TransProd) transProd, (Vista) this);

			if (promociones.Preparar())
			{
				try
				{
					BDVend.recuperar((TransProd) transProd);
					BDVend.recuperar((TransProd) transProd, TransProdDetalle.class);
					// obtener todos los impuestos para que se recalculen
					// correctamente
					for (TransProdDetalle oTpd : ((TransProd) transProd).TransProdDetalle)
					{
						BDVend.recuperar(oTpd, TPDImpuesto.class);
					}
				}
				catch (Exception e)
				{
					e.printStackTrace();
				}
			}

			promociones.setOnTerminarAplicacionListener(new onTerminarAplicacionListener()
			{
				@SuppressWarnings("rawtypes")
				@Override
				public void onTerminarAplicacion()
				{

					if (docsTransProd.hasNext())
					{
						calcularPromociones(docsTransProd.next());
					}
					else
					{
						//TODO: validar reparto aqui?  *********** no validar inv para msiev
						if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && mPresenta.getTipoTransProd() != 21 && surtir && reparto ){
							//TODO: validar inventario despues de calcular las promociones, se validan tambien los productos promocionales
							prodSinExistencia = mPresenta.validarInventarioASurtir();
							if(prodSinExistencia.size() != 0){
								boolean soloPromo = true;
								String productosNoPromo = "";
								String productosPromo = "";
								
								for(TransProdDetalle oTpd : prodSinExistencia){
									if(oTpd.Promocion != 2){
										productosNoPromo += oTpd.ProductoClave + ", ";
										soloPromo = false;
									}else if(oTpd.Promocion == 2){
										productosPromo += oTpd.ProductoClave + ", ";
									}
								}
								if(productosNoPromo != ""){
									productosNoPromo = productosNoPromo.substring(0, productosNoPromo.length() - 2);
								}
								if(productosPromo != "" && soloPromo){
									productosPromo = productosPromo.substring(0, productosPromo.length() - 2);
								}
								
								if(productosNoPromo != ""){
									mostrarAdvertencia(Mensajes.get("E0714").replace("$0$", productosNoPromo));
									return;
								}else if(productosPromo != ""){
									mostrarPreguntaSiNo(Mensajes.get("P0209"), 50);
								}
						 	}
						}
						
						iniciarCapturaTotales();
						/*HashMap<String, Object> oParametros = new HashMap<String, Object>();
						ArrayList<String> nuevo = new ArrayList<String>();
						nuevo.add(String.valueOf(esNuevo));
						ArrayList<String> transprod = new ArrayList<String>();
						Iterator it = mPresenta.getHashMapTransacciones().entrySet().iterator();

						while (it.hasNext())
						{ // recorrer todas las transacciones generadas para
							// calcular totales, impuestos, descuentos, etc ...
							Map.Entry e = (Map.Entry) it.next();
							transprod.add(((TransProd) e.getValue()).TransProdID);
						}
						
						oParametros.put("TransProdId", transprod);
						oParametros.put("esNuevo", nuevo);
						oParametros.put("ModuloMovDetalle", mPresenta.getModuloMovDetalle());
						oParametros.put("TotalInicial", mPresenta.getTotalInicial());
						oParametros.put("Surtir",  Boolean.toString(surtir));
						iniciarActividadConResultado(ICapturaTotales.class, Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_TOTALES, Enumeradores.Acciones.ACCION_APLICAR_TOTALES, oParametros);*/
					}
				}
			});

			promociones.Aplicar();

		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}

	}
	
	private void iniciarCapturaTotales(){
		HashMap<String, Object> oParametros = new HashMap<String, Object>();
		ArrayList<String> nuevo = new ArrayList<String>();
		nuevo.add(String.valueOf(esNuevo));
		ArrayList<String> transprod = new ArrayList<String>();
		Iterator it = mPresenta.getHashMapTransacciones().entrySet().iterator();

		while (it.hasNext())
		{ // recorrer todas las transacciones generadas para
			// calcular totales, impuestos, descuentos, etc ...
			Map.Entry e = (Map.Entry) it.next();
			transprod.add(((TransProd) e.getValue()).TransProdID);
		}
		oParametros.put("TransProdId", transprod);
		oParametros.put("esNuevo", nuevo);
		oParametros.put("ModuloMovDetalle", mPresenta.getModuloMovDetalle());
		oParametros.put("TotalInicial", mPresenta.getTotalInicial());
		oParametros.put("Surtir",  Boolean.toString(surtir));
		oParametros.put("Modificando",  Boolean.toString(modificando));
		if(mPresenta.getModuloMovDetalle().TipoTransProd == TiposTransProd.VENTA_CONSIGNACION)
		{
			iniciarActividadConResultado(ICapturaTotalesConsignacion.class, Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_TOTALES_CONSIGNACION, mAccion, oParametros);
		}else
		{
			iniciarActividadConResultado(ICapturaTotales.class, Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_TOTALES, Enumeradores.Acciones.ACCION_APLICAR_TOTALES, oParametros);
		}
	}

	public Handler getHandler()
	{
		return handler;
	}

	public Object getPausaCiclo()
	{
		return mPausaCiclo;
	}

	/*
	 * public boolean getSiguiente(){ return siguiente; }
	 */

	public void setSiguiente(boolean bsiguiente)
	{
		siguiente = bsiguiente;
	}

	@SuppressWarnings("deprecation")
	public void refrescarProductos(String TransProdId)
	{
		try
		{

			// limpiarProducto();
			// ocultarTeclado();
			ISetDatos stTransProdDetalle = Consultas.ConsultasTransProdDetalle.obtenerDetalle(TransProdId);

			Cursor cProductos = (Cursor) stTransProdDetalle.getOriginal();
			startManagingCursor(cProductos);
			try
			{
				obtenerTotales(TransProdId);
				SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.elemento_captura_producto, cProductos, new String[]
				{ "TipoUnidad", "ProductoClave", "Descripcion", "Precio", "Cantidad", "Total", "Existencia", "CantidadOriginal" }, new int[]
				{ R.id.lblUnidadProductoClave, R.id.lblUnidadProductoClave, R.id.lblDescripcion, R.id.lblPU, R.id.lblCantidad, R.id.lblTotal, R.id.lblExistencia, R.id.lblCantidadOriginal });
				adapter.setViewBinder(new vista());
				lista.setAdapter(adapter);

				lista.setOnItemClickListener(new OnItemClickListener()
				{

					public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
					{
						if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")) && (mPresenta.getTipoFase() == 0 || mPresenta.getTipoFase() == 2) && calculando)
						{
							// si recibio el transprodid como parametro y esta
							// cancelado o surtido, mostrar cantidad de solo
							// lectura
							return;
						}
						// calculando = true;
						producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
						Log.d("CapturaPedido", "Producto Seleccionado: " + producto.getString(producto.getColumnIndex("ProductoClave")));
						//						final String TransProdId = producto.getString(producto.getColumnIndex("TransProdID"));
						//						final String TransProdDetalleId = producto.getString(producto.getColumnIndex("TransProdDetalleID"));
						lista.requestFocusFromTouch();
						lista.setSelection(pos);
						// Se crea el objeto producto con lo que se trae en la
						// consulta para eficientar tiempos.
						Producto oProducto = new Producto();
						oProducto.ProductoClave = producto.getString(producto.getColumnIndex("ProductoClave"));
						oProducto.Nombre = producto.getString(producto.getColumnIndex("Descripcion"));
						oProducto.SubEmpresaId = producto.getString(producto.getColumnIndex("SubEmpresaId"));
						oProducto.Venta = ((producto.getShort(producto.getColumnIndex("Venta")) == 1) ? true : false);
						oProducto.Contenido = ((producto.getShort(producto.getColumnIndex("Contenido")) == 1) ? true : false);
						captura.llenarProductoUnidad(oProducto, producto.getInt(producto.getColumnIndex("TipoUnidad")), producto.getFloat(producto.getColumnIndex("Cantidad")));
					}
				}
						);

			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}

			txtScanner.requestFocus();
			calculando = false;

		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	private void obtenerTotales(String TransProdID)
	{
		try
		{
			ISetDatos setDatos = Consultas.ConsultasTransProdDetalle.obtenerTotales(TransProdID);
			if (setDatos.moveToNext())
			{
				TextView texto = (TextView) findViewById(R.id.txtTotalPrevio);
				// texto.setText(String.format("%.2f", setDatos.getFloat(1)));
				texto.setText(Generales.getFormatoDecimal(setDatos.getFloat(1), "$ #,##0.00"));

				texto = (TextView) findViewById(R.id.txtTotalProductos);
				texto.setText(String.format("%.0f", setDatos.getFloat(0)));

				texto = (TextView) findViewById(R.id.txtTotalUnidades);
				texto.setText(String.format("%.0f", setDatos.getFloat("Unidades")));
				
				String peso$volumen = String.format("%.2f", setDatos.getFloat("Peso")) + " / ";
				peso$volumen +=  String.format("%.2f", setDatos.getFloat("Volumen"));
				
				texto = (TextView) findViewById(R.id.txtVolumen);
				texto.setText(peso$volumen);
			}
			setDatos.close();
			
			if(mnu != null){
				if(hayProductos()){
					mnu.getItem(1).setEnabled(false);
				}else{
					mnu.getItem(1).setEnabled(true);
				}	
			}
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
			//mostrarError(e);
		}
	}
 
	//	private void ocultarTeclado()
	//	{
	//		InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
	//		TextView texto = (TextView) findViewById(R.id.txtTotalPrevio);
	//		imm.hideSoftInputFromWindow(texto.getWindowToken(), 0);
	//	}

	public void ocultarPedidoSugerido()
	{
		Button boton = (Button) findViewById(R.id.btnSugerido);
		boton.setVisibility(View.GONE);
		boton = (Button) findViewById(R.id.btnContinuar);
		android.widget.LinearLayout.LayoutParams param = new LinearLayout.LayoutParams(
				0,
				LayoutParams.WRAP_CONTENT, 0.9f);
		boton.setLayoutParams(param);

	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		if (mPresenta.errorFinalizar) return false;
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.menu_captura_pedido, menu);

		menu.getItem(0).setTitle(Mensajes.get("XPromociones"));
		menu.getItem(1).setTitle(Mensajes.get("XActualizar") + " " + Mensajes.get("XInventario"));
		menu.getItem(2).setTitle(Mensajes.get("XModificar"));
		menu.getItem(3).setTitle(Mensajes.get("MCNMostrarUltimaVenta"));
		menu.getItem(4).setTitle(Mensajes.get("XAcMenVen"));
		
		//if(!(((Ruta) Sesion.get(Campo.RutaActual)).Inventario && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)){
		menu.getItem(1).setVisible(false);
		//}
		
		menu.getItem(2).setVisible(false);
		
		if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && mPresenta.getTipoFase() == TiposFasesDocto.CAPTURA && mPresenta.getTipoTransProd() == 1 && reparto && surtir){// || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && surtir)){
			menu.getItem(2).setVisible(true);
		}
		
		MOTConfiguracion motConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
		if(motConf.get("MostrarUltVta").equals("0")){
			menu.getItem(3).setVisible(false);
		}
		
		if(!Consultas.ConsultasClienteVentaMensual.existeInformacion(
				((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave)){
			menu.getItem(4).setVisible(false);
		}
		
		mnu = menu;

		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{

		switch (item.getItemId())
		{
			case R.id.promociones:
				mPresenta.consultarPromociones();
				return true;
			case R.id.actualizar:
				mPresenta.obtenerInventarioEnLinea();
				return true;
			case R.id.modificar:
				//TODO: modificar pedido de reparto
				modificar = item;
				if(mPresenta.getTipoFase() != TiposFasesDocto.CAPTURA_ESCRITORIO)
					mostrarPreguntaSiNo(Mensajes.get("P0232"), 20);
				else{
					modificarPedidoReparto();
					/*captura.setVisibility(View.VISIBLE);
					modificando = true;
					modificar.setEnabled(false);
					mPresenta.modificarPedido();*/
				}
				return true;
			case R.id.ultimavta:
				iniciarActividad(IConsultaUltimaVenta.class,null,null,false);
				return true;
			case R.id.ventaMensual:
				mostrarVentaMensual();
				return true;
			default:
				return super.onOptionsItemSelected(item);
		}
	}
	
	public void setSurtir(boolean surtir){
		this.surtir = surtir;
	}
	
	public void setSoloLectura(boolean soloLectura){
		this.soloLectura = soloLectura;
	}
	
	public void setEsNuevo(boolean esNuevo){
		this.esNuevo = esNuevo;
	}
	
	public void setCapturaEnabled(boolean enabled){
		captura.setEnabled(enabled);
	}

	// viewbinder para la lista de productos
	private class vista implements ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case android.R.id.text1: // para llenar el combo
					TextView combo = (TextView) view;
					combo.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("PRUTipoUnidad"))));

					break;
				case R.id.lblUnidadProductoClave:
					TextView unidadproducto = (TextView) view;
					if (columnIndex == 6)
					{ // tipo unidad
						unidadproducto.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("TipoUnidad"))));
					}
					else if (columnIndex == 3)
					{ // producto clave
						unidadproducto.setText(unidadproducto.getText() + " - " + cursor.getString(columnIndex));
					}
					break;
				case R.id.lblPU:
				case R.id.lblTotal:
					TextView total = (TextView) view;
					total.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), "$ #,##0.00"));
					break;
				case R.id.lblExistencia:
					// mostrar la existencia con los decimales configurados
					TextView existencia = (TextView) view;
					if (mPresenta.getTipoValidacionExistencia() == TiposValidacionInventario.NoValidar)
					{
						existencia.setVisibility(View.GONE);
					}
					else
					{
						existencia.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), cursor.getInt(cursor.getColumnIndex("DecimalProducto"))));
					}
					break;
				case R.id.lblCantidad:
					TextView cantidad = (TextView) view;
					cantidad.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), cursor.getInt(cursor.getColumnIndex("DecimalProducto"))));

					break;
				case R.id.lblDescripcion:
					TextView lblDescripcion = (TextView) view;
					lblDescripcion.setText(cursor.getString(columnIndex));
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}
	
	private void mostrarVentaMensual(){
		VentaMensual vm = VentaMensual.newInstance(
				((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave, 
				((Vendedor)Sesion.get(Campo.VendedorActual)).MCNClave);
		getFragmentManager().beginTransaction().
			setCustomAnimations(android.R.animator.fade_in, android.R.animator.fade_out).
			add(R.id.layout_captura_pedido, vm, FRAGMENT_TAG).commit();
	}
}
