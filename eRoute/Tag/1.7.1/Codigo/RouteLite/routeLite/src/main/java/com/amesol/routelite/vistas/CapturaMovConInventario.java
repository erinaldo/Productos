package com.amesol.routelite.vistas;

import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.Map.Entry;
import java.util.concurrent.atomic.AtomicReference;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.DialogInterface.OnKeyListener;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.util.Log;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.WindowManager;
import android.view.View.OnClickListener;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemLongClickListener;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.Toast;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.CapturaProducto;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.InventarioTraspaso;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.act.CapturarMovimientosConInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaMovConInventario;
import com.amesol.routelite.presentadores.parcelables.DatosAbnDetalle;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.EncriptaDesencripta;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

public class CapturaMovConInventario extends Vista implements ICapturaMovConInventario
{
	private CapturarMovimientosConInventario mPresenta;
	private ListView lista;
	private CapturaProducto captura;
	private String mAccion;
	private HashMap<String, String> oParametros = null;
	private boolean esNuevo = true;
	private boolean soloLectura = false;
	private Cursor producto;
	private Spinner spinMotivo;
	private boolean imprimiendo;
	private boolean hayProductos = false;
	private boolean eliminar = false;
	
	private Spinner spDe;
	private Spinner spA;
	private String InventarioTraspasoID_sel = "";
	private float Cantidad_anterior_sel = 0;
	private int origen = 0;
	private int destino = 0;
	private int motivo = 0;
	private boolean hayProductosCargados = false;
	private boolean huboCambios = false;
	
	private boolean vali = false; // esta variable se utiliza para regresar el booleano desde el dialogo para validar los permisos
	private int solicitarContrasena;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		try 
		{
			setContentView(R.layout.capturar_movsininvent);
			deshabilitarBarra(true);

			imprimiendo = false;

			mAccion = getIntent().getAction();
			
			
            
			if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)))
			{
				lblTitle.setText("Ajustes");
			}
			else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA)))
			{
				lblTitle.setText("Descargas");
				TextView texto = (TextView) findViewById(R.id.lblMotivo);
				texto.setVisibility(View.GONE);
				Spinner spinMotivo = (Spinner) findViewById(R.id.cboMotivo);
				spinMotivo.setVisibility(View.GONE);
				//se valida los permisos al accesar
				solicitarContrasena = Integer.parseInt(String.valueOf(Sesion.get(Campo.SolicitarContrasenaDescarga)));
	            Log.i(null,"solicitar: "+solicitarContrasena);
				this.validarPermisos(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString(), Enumeradores.TipoPermiso.ACCESAR);
				

			}
			else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION)))
			{
				lblTitle.setText("Devoluciones al Almacen");
				TextView texto = (TextView) findViewById(R.id.lblMotivo);
				texto.setVisibility(View.GONE);
				Spinner spinMotivo = (Spinner) findViewById(R.id.cboMotivo);
				spinMotivo.setVisibility(View.GONE);
				//se valida los permisos al accesar
				solicitarContrasena = Integer.parseInt(String.valueOf(Sesion.get(Campo.SolicitarContrasenaDevolucionAlmacen)));
	            Log.i(null,"solicitar: "+solicitarContrasena);
				this.validarPermisos(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString(), Enumeradores.TipoPermiso.ACCESAR);
				

			}
			else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS)) || (mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_NO_MODIFICAR)) || (mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_ELIMINAR)))
			{
				lblTitle.setText("Cargas");
				TextView texto = (TextView) findViewById(R.id.lblMotivo);
				texto.setVisibility(View.GONE);
				Spinner spinMotivo = (Spinner) findViewById(R.id.cboMotivo);
				spinMotivo.setVisibility(View.GONE);
				
			}
			if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO)))
			{
				//traspaso de inventario
				lblTitle.setText(ValoresReferencia.getDescripcion("ACTROL", "26"));
				
				
				TextView texto = (TextView) findViewById(R.id.lblFolio);
				texto.setText(Mensajes.get("XRuta")+": "+((Ruta)Sesion.get(Campo.RutaActual)).RUTClave+" - "+((Ruta)Sesion.get(Campo.RutaActual)).Descripcion);
				
				texto = (TextView) findViewById(R.id.lblFecha);
				texto.setText(Mensajes.get("XDiaTrabajo")+": "+((Dia)Sesion.get(Campo.DiaActual)).DiaClave);
				
				texto = (TextView) findViewById(R.id.lblDe);
				texto.setText(Mensajes.get("XDe"));
				
				texto = (TextView) findViewById(R.id.lblA);
				texto.setText(Mensajes.get("XA"));
				Log.i(null, "2");
			}

			TextView texto = (TextView) findViewById(R.id.lblProducto);
			texto.setText(Mensajes.get("XProducto"));
			texto = (TextView) findViewById(R.id.lblUnidad);
			texto.setText(Mensajes.get("XUnidad"));
			texto = (TextView) findViewById(R.id.lblMotivo);
			texto.setText(Mensajes.get("XMotivo"));
			Button boton = (Button) findViewById(R.id.btnContinuar);
			boton.setText(Mensajes.get("XContinuar"));
			boton.setOnClickListener(mContinuar);
			
			lista = (ListView) findViewById(R.id.lsTransProdDetalle);
			lista.setItemsCanFocus(false);
			
			captura = (CapturaProducto) findViewById(R.id.capturaProducto);

			captura.setOnAgregarProductoListener(new CapturaProducto.onAgregarProductoListener()
			{
				@Override
				public void onAgregarProducto(Producto producto, int tipoUnidad, float cantidad)
				{
					if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO))){
						try{
							if(spDe.getSelectedItemId() == spA.getSelectedItemId()){
								mostrarAdvertencia(Mensajes.get("E0926"));
								return;
							}
							if(spinMotivo.getSelectedItemId() == 0){
								mostrarAdvertencia(Mensajes.get("E0161").replace("$0$", Mensajes.get("XMotivo")));
								return;
							}
							huboCambios = true;
							float cantidad_capturada = cantidad;
							if (mPresenta.getTipoValidacionExistencia() != TiposValidacionInventario.NoValidar){
								AtomicReference<Float> existencia = new AtomicReference<Float>();
								StringBuilder error = new StringBuilder();
								String grupoMotivo = "";
								if(spDe.getSelectedItemId() == 1)
									grupoMotivo = "VENTA";
								else if(spDe.getSelectedItemId() == 2)
									grupoMotivo = "NO VENTA";
								
								if(InventarioTraspasoID_sel != "" && Cantidad_anterior_sel < cantidad){
									//si se esta modificando uno que ya existia solo validar la diferencia en la existencia
									cantidad = cantidad - Cantidad_anterior_sel;
									habilitarOrigenDestino(true);
								}
								
								if(!Inventario.ValidarExistencia(producto.ProductoClave, tipoUnidad, cantidad, (short) 0, grupoMotivo, existencia, error)){
									captura.setError(error.toString());
									if (mPresenta.getTipoValidacionExistencia() == TiposValidacionInventario.ValidacionRestrictiva)
									{ //cuando se esta validando un producto que tiene existencia 0 de entrada, regresa 'null' como existencia, por eso se esta validando
										if(existencia.get() != null)
											captura.setCantidad(existencia.get());
										else
											captura.setCantidad((float) 0);
										return;

									}
									else
									{
										captura.setAdvertencia(error.toString());

									}
								}
							}
							//agregar traspaso
							
							if(InventarioTraspasoID_sel != ""){ //si se esta modificando uno que ya existia eliminarlo y agregarlo
								mPresenta.eliminarTraspaso(InventarioTraspasoID_sel);
								cantidad = cantidad_capturada; //poner otra vez la cantidad original para agregar el registro
							}
							
							mPresenta.agregarProductoUnidadTraspaso(producto.ProductoClave, tipoUnidad, cantidad, (int) spinMotivo.getSelectedItemId(), (int) spDe.getSelectedItemId(), (int) spA.getSelectedItemId());
							
							InventarioTraspasoID_sel = "";
							Cantidad_anterior_sel = 0;
						}catch(Exception e){
							e.printStackTrace();
							mostrarError(e.getMessage());
						}
						
					}else{
						Object aTransProdDetalle[] = null;
						try
						{

							aTransProdDetalle = Consultas.ConsultasTransProdDetalle.obtenerDetallePorProductoClaveUnidad(producto.ProductoClave, String.valueOf(tipoUnidad), "'" + mPresenta.getTransaccionesIds() + "'");

							if (aTransProdDetalle != null)
							{ // si ya existe, seleccionarlo de la lista
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
												if (existencia.get() != null && existencia.get() > 0)
												{
													if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS)))

														captura.setCantidad(Float.parseFloat(aTransProdDetalle[2].toString()) - existencia.get());
													else
														captura.setCantidad(Float.parseFloat(aTransProdDetalle[2].toString()) + existencia.get());
												}
												else
												{
													captura.setCantidad(cantidad);
												}
												return;

											}
											else
											{
												captura.setAdvertencia(error.toString());

											}
										}
									}
									soloLectura = false;
									/*String mMotivo = "0";
									if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)))
									{
										mMotivo = String.valueOf(spinMotivo.getSelectedItemId());
									}*/
									mPresenta.eliminarDetalle(aTransProdDetalle[0].toString(), tipoUnidad, aTransProdDetalle[1].toString(), producto.ProductoClave, Float.parseFloat(aTransProdDetalle[2].toString()));
									//mPresenta.agregarProductoUnidad(producto.ProductoClave, tipoUnidad, cantidad, mMotivo);
									mPresenta.agregarProductoUnidad(producto.ProductoClave, tipoUnidad, cantidad, "0");

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
								soloLectura = false;
								/*String mMotivo = "0";
								if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)))
								{
									mMotivo = String.valueOf(spinMotivo.getSelectedItemId());
								}*/
								//mPresenta.agregarProductoUnidad(producto.ProductoClave, tipoUnidad, cantidad, mMotivo);
								mPresenta.agregarProductoUnidad(producto.ProductoClave, tipoUnidad, cantidad, "0");
							}
						}
						catch (Exception e)
						{
							mostrarError(e.getMessage());
						}
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

			mPresenta = new CapturarMovimientosConInventario(this, mAccion);

			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");
			}

			if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")))
			{
				mPresenta.agregarTransaccion(oParametros.get("TransProdId"));
			}
			
			if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)))
			{
				spinMotivo = (Spinner) findViewById(R.id.cboMotivo);
				//spinMotivo.setEnabled(false);
				ISetDatos valores;
				try
				{
					valores = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT", "'Ajuste'", "", false);
					llenarSpiner(spinMotivo, valores);
					//spinMotivo.setEnabled(true);
				}
				catch (Exception e)
				{
					mostrarError(e.getMessage());
				}
			}
			if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO))){
				spDe = (Spinner) findViewById(R.id.spDe);
				spA = (Spinner) findViewById(R.id.spA);
				spinMotivo = (Spinner) findViewById(R.id.cboMotivo);
				ISetDatos valores;
				ISetDatos motivos;
				try
				{
					valores = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("INVUBIC", "''", "", false);
					motivos = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT", "'TraspasoInv'", "", true);
					llenarSpiner(spDe, valores);
					llenarSpiner(spA, valores);
					llenarSpiner(spinMotivo, motivos);
				}
				catch (Exception e)
				{
					mostrarError(e.getMessage());
				}
				
				spDe.setOnItemSelectedListener(new OnItemSelectedListener()
				{
					@Override
					public void onItemSelected(AdapterView<?> parent, View view, int pos, long id)
					{
						//cambiar la ubicacion del inventario de acuerdo al spinner "De"
						captura.setUbicacionExistencia((short) id);
						//captura.limpiarProducto();
						origen = (int) id;
						
						if(spDe.getSelectedItemId() == spA.getSelectedItemId()){
							captura.setOrigenDestinoOk(false);
						}else{
							captura.setOrigenDestinoOk(true);
						}
					}

					@Override
					public void onNothingSelected(AdapterView<?> parent)
					{
					}
				});
				
				spA.setOnItemSelectedListener(new OnItemSelectedListener()
				{
					@Override
					public void onItemSelected(AdapterView<?> parent, View view, int pos, long id)
					{
						//captura.limpiarProducto();
						destino = (int) id;
						if(spDe.getSelectedItemId() == spA.getSelectedItemId()){
							captura.setOrigenDestinoOk(false);
						}else{
							captura.setOrigenDestinoOk(true);
						}
					}

					@Override
					public void onNothingSelected(AdapterView<?> parent)
					{
					}
				});
				
				spinMotivo.setOnItemSelectedListener(new OnItemSelectedListener()
				{
					@Override
					public void onItemSelected(AdapterView<?> parent, View view, int pos, long id)
					{
						//captura.limpiarProducto();
						motivo = (int) id;
						if(id == 0){
							captura.setTipoMotivoOk(false);
						}else{
							captura.setTipoMotivoOk(true);
						}
					}

					@Override
					public void onNothingSelected(AdapterView<?> parent)
					{
					}
				});
				
				Generales.SelectSpinnerItemByValue(spDe, 1);
				Generales.SelectSpinnerItemByValue(spA, 2);
			}else{
				//ocultar los spinners para las demas actividades
				spDe = (Spinner) findViewById(R.id.spDe);
				spDe.setVisibility(View.GONE);
				spA = (Spinner) findViewById(R.id.spA);
				spA.setVisibility(View.GONE);
				TextView text = (TextView) findViewById(R.id.lblDe);
				text.setVisibility(View.GONE);
				text = (TextView) findViewById(R.id.lblA);
				text.setVisibility(View.GONE);
				this.validarPermisos(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString(), Enumeradores.TipoPermiso.ACCESAR);
			}

			mPresenta.iniciar();

			// si se paso como parametro el TransProdId, cargar el detalle del
			// pedido
			if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")))
			{
				esNuevo = false;
				refrescarProductos(mPresenta.getTransaccionesIds());
				if (!oParametros.containsKey("Modificar")){
					soloLectura = true;				
					//Log.i(null, "modifica");
				}else{
					if (!Boolean.parseBoolean(oParametros.get("Modificar"))){
						soloLectura = true;	
						//Log.i(null, "modifica");
						this.validarPermisos(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString(), Enumeradores.TipoPermiso.MODIFICAR);
					
					}
				}
					
				if(oParametros.get("Eliminar") != null && !oParametros.get("Eliminar").trim().equals("")){
					if(Boolean.parseBoolean(oParametros.get("Eliminar"))){
						soloLectura = true;
						eliminar = true;
						//captura.setVisibility(View.GONE);
						captura.setEnabled(false);
						spinMotivo.setEnabled(false);
					}
				}
			}

			captura.setTipoValidacionExistencia(mPresenta.getTipoValidacionExistencia());

			if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION)))
				captura.setDevolucionesManuales(true);

			if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO))){
				captura.setTipoMovimiento((short) TiposMovimientos.SALIDA);
				captura.setTipoTransProd((short) 0);
				captura.setTraspasoInventario(true);
				refrescarProductos("");
				hayProductosCargados = hayProductos;
			}else{
				captura.setTipoMovimiento(mPresenta.getModuloMovDetalle().TipoMovimiento);
				captura.setTipoTransProd(mPresenta.getModuloMovDetalle().TipoTransProd);
			}
			/*captura.setTipoMovimiento(mPresenta.getModuloMovDetalle().TipoMovimiento);
			captura.setTipoTransProd(mPresenta.getModuloMovDetalle().TipoTransProd);*/
			
			if(!soloLectura){
				registerForContextMenu(lista);
				lista.setOnItemLongClickListener(menu);	
			}
			
			if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_ELIMINAR)) || (mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_NO_MODIFICAR)))
			{
				captura.setEnabled(false);

                if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_ELIMINAR)) || (mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_NO_MODIFICAR)))
				{
					getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
					boton.setEnabled(false);
                    if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_ELIMINAR))){
                        mostrarError(Mensajes.get("I0126").replace("$0$","Eliminar"));
                    }
                    else{
                        mostrarError(Mensajes.get("I0126").replace("$0$","Modificar"));
                    }
				}
			}
		}
		catch (Exception ex)
		{
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
				if (hasFocus)
				{
					// getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE);

					txtScaner.clearFocus();
					imm.showSoftInput(txtCantidad, InputMethodManager.SHOW_FORCED);
					if (!(spinUnit.getCount() > 1))
						spinUnit.setEnabled(false);

					/*if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)))
					{
						ISetDatos valores;
						try
						{
							valores = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT", "'Ajuste'", "", false);
							llenarSpiner(spinMotivo, valores);
							//spinMotivo.setEnabled(true);
						}
						catch (Exception e)
						{
							mostrarError(e.getMessage());
						}

					}*/

					String mCantidad = mPresenta.consultarUnidadProductoExistente(mPresenta.getTransaccionesIds(), txtScaner.getText().toString());
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
		
		
		if(esNuevo)
		{
			this.validarPermisos(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString(), Enumeradores.TipoPermiso.CREAR);

		}
		
		if(eliminar)
		{
			this.validarPermisos(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString(), Enumeradores.TipoPermiso.ELIMINAR);
			

			
		}
	
	}

	private OnClickListener mContinuar = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			Button boton = (Button) findViewById(R.id.btnContinuar);
			try
			{

				if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_ELIMINAR)))
				{
					mostrarPreguntaSiNo(Mensajes.get("P0001"), 15);
				}
				else
				{
					if (!hayProductos && (!hayProductosCargados && mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO)) )
					{
						mostrarError(Mensajes.get("MDBAsignarProducto"));
					}
					else
					{
						if (!soloLectura)
						{ // no modificar si esta solo lectura

							boton.setEnabled(false);
							mPresenta.asignarGuardarValores();

						}
						else
						{ // si es solo lectura, salir
							if(eliminar){
								mostrarPreguntaSiNo(Mensajes.get("P0001"), 99);
							}else{
								setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
								finalizar();	
							}					
						}

						MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
						if (motConfig.get("MensajeImpresion").equals("0"))
						{
							// si no esta configurada la pregunta salir
							setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
							finalizar();
						}else if (motConfig.get("MensajeImpresion").equals("2")){
                            mostrarToast(Mensajes.get("E0934"));
                            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                            finalizar();
                        }
					}
				}
			}
			catch (Exception ex)
			{
				mostrarError(ex.getMessage());
				boton.setEnabled(true);
			}
		}

	};

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
		}else if (requestCode == REQUEST_ENABLE_BT)
		{
			if (resultCode == RESULT_OK)
			{
				try
				{
					imprimiendo = true;
					mPresenta.imprimirTicket();
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

	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if (tipoMensaje == 2)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				AtomicReference<Float> existencia = new AtomicReference<Float>();
				StringBuilder error = new StringBuilder();
				Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
				if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO))){
					if(producto.getInt(producto.getColumnIndex("Enviado")) == 1){
						mostrarAdvertencia(Mensajes.get("E0596").replace("$0$", Mensajes.get("XEliminar")));
						return;
					}
					try
					{
						mPresenta.eliminarTraspaso(producto.getString(producto.getColumnIndex("_id")));
						refrescarProductos("");
					}
					catch (Exception e)
					{
						e.printStackTrace();
						mostrarAdvertencia(e.getMessage());
					}
				}else{
					if (!Inventario.ValidarExistencia(producto.getString(producto.getColumnIndex("ProductoClave")), producto.getInt(producto.getColumnIndex("TipoUnidad")), producto.getFloat(producto.getColumnIndex("Cantidad")), 0.0f, mPresenta.getModuloMovDetalle(), true, existencia, error))
					{
						mostrarError(Mensajes.get("E0714", producto.getString(producto.getColumnIndex("ProductoClave"))));
						captura.setError(error.toString());

						return;
					}
					else
					{
						captura.setAdvertencia(error.toString());
					}

					soloLectura = false;

					mPresenta.eliminarDetalle(producto.getString(producto.getColumnIndex("mTransProdID")), producto.getInt(producto.getColumnIndex("TipoUnidad")), producto.getString(producto.getColumnIndex("_id")), producto.getString(producto.getColumnIndex("ProductoClave")), producto.getFloat(producto.getColumnIndex("Cantidad")));
				}
				
			}
		}
		else if (tipoMensaje == 3)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				regresar();
			}
		}
		else if (tipoMensaje == 8)
		{ // imprimir recibo
			if (respuesta.equals(RespuestaMsg.Si))
			{
				// Imprimir ticket
				imprimiendo = true;
				try
				{
					if (!bluetoothEncendido())
					{
						encenderBluetooth();
					}
					else
					{
						mPresenta.imprimirTicket();
					}

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
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				finalizar();
			}
		}
		else if (tipoMensaje == 0 && imprimiendo)
		{

			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
		else if (tipoMensaje == 15)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				try
				{

					if (TransaccionesDetalle.Pedidos.EliminarDetalleAjustesInventario(mPresenta.getTransProdIds().replace("'", ""), true))
					{
						BDVend.commit();
						finalizar();
					}
					else
					{
						mostrarError(Mensajes.get("E0029"));
					}

				}
				catch (Exception e)
				{
					mostrarError("" + e);
				}

			}
		}else if(tipoMensaje == 99){
			try{
				if(respuesta == RespuestaMsg.Si){
					huboCambios = true;
					TransaccionesDetalle.Pedidos.EliminarDetalleAjustesInventario(mPresenta.getTransProdIds().replace("'", ""), false);
					BDVend.commit();
					setResultado(Resultados.RESULTADO_BIEN);
					finalizar();
				}else if(respuesta == RespuestaMsg.No){
					setResultado(Resultados.RESULTADO_MAL);
					finalizar();
				}
			}catch(Exception e){
				mostrarError(e.getMessage());
				e.printStackTrace();
			}
		}

	}
	
	private void habilitarOrigenDestino(boolean habilitado){
		spDe.setEnabled(habilitado);
		spA.setEnabled(habilitado);
	}

	@SuppressWarnings("deprecation")
	@Override
	public void refrescarProductos(String TransProdId)
	{
		try
		{
			hayProductos = true;
			ISetDatos stTransProdDetalle; //= Consultas.ConsultasTransProdDetalle.obtenerDetalle_Mov(TransProdId);
			if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO))){
				stTransProdDetalle = Consultas.ConsultasInventarioTraspaso.obtenerDetalleTraspaso(((Dia)Sesion.get(Campo.DiaActual)).DiaClave);
				if(stTransProdDetalle.getCount() == 0)
					hayProductos = false;
			}else{
				stTransProdDetalle = Consultas.ConsultasTransProdDetalle.obtenerDetalle_Mov(TransProdId);
			}
			Cursor cProductos = (Cursor) stTransProdDetalle.getOriginal();
			startManagingCursor(cProductos);
			try
			{
				SimpleCursorAdapter adapter;
				if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO))){
					adapter = new SimpleCursorAdapter(this, R.layout.elemento_captura_traspaso, cProductos, new String[]
							{ "Cantidad", "TipoUnidad", "Descripcion", "Origen", "Destino", "TipoMotivo", "De", "A", "Motivo" }, new int[]
							{ R.id.lblCantidad, R.id.lblUnidad, R.id.lblDescripcion, R.id.lblOrigen, R.id.lblDestino, R.id.lblMotivoTxt, R.id.lblDe, R.id.lblA, R.id.lblMotivo });
				}else{
					adapter = new SimpleCursorAdapter(this, R.layout.elemento_captura_movimiento, cProductos, new String[]
							{ "ProductoClave", "Cantidad", "Descripcion" }, new int[]
							{ R.id.lblUnidadProductoClave_Mov, R.id.lblCantidad_Mov, R.id.lblDescripcion_Mov });
				}
				
				/*SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.elemento_captura_movimiento, cProductos, new String[]
				{ "ProductoClave", "Cantidad", "Descripcion" }, new int[]
				{ R.id.lblUnidadProductoClave_Mov, R.id.lblCantidad_Mov, R.id.lblDescripcion_Mov });*/
				adapter.setViewBinder(new vista());
				lista.setAdapter(adapter);

					lista.setOnItemClickListener(new OnItemClickListener()
					{

						public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
						{
							if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_ELIMINAR)) || (mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_NO_MODIFICAR)) || eliminar)
							{

							}
							else
							{
								if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")) && (mPresenta.getTipoFase() == 0 || mPresenta.getTipoFase() == 2))
								{
									// si recibio el transprodid como parametro y esta
									// cancelado o surtido, mostrar cantidad de solo
									// lectura
									return;
								}
								producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
								if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO))){
									if(producto.getInt(producto.getColumnIndex("Enviado")) == 1){
										mostrarAdvertencia(Mensajes.get("E0596").replace("$0$", Mensajes.get("XModificar")));
										return;
									}/*else{
										Generales.SelectSpinnerItemByValue(spDe, producto.getInt(producto.getColumnIndex("Origen")));
										Generales.SelectSpinnerItemByValue(spA, producto.getInt(producto.getColumnIndex("Destino")));
										Generales.SelectSpinnerItemByValue(spinMotivo, producto.getInt(producto.getColumnIndex("TipoMotivo")));
									}*/
									habilitarOrigenDestino(false);
								}
								Log.d("CapturaPedido", "Producto Seleccionado: " + producto.getString(producto.getColumnIndex("ProductoClave")));
								lista.requestFocusFromTouch();
								lista.setSelection(pos);
								// Se crea el objeto producto con lo que se trae en la
								// consulta para eficientar tiempos.
								Producto oProducto = new Producto();
								oProducto.ProductoClave = producto.getString(producto.getColumnIndex("ProductoClave"));
								oProducto.Nombre = producto.getString(producto.getColumnIndex("Descripcion"));
								if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO))){
									Generales.SelectSpinnerItemByValue(spDe, producto.getInt(producto.getColumnIndex("Origen")));
									captura.setUbicacionExistencia((short) producto.getInt(producto.getColumnIndex("Origen")));
									Generales.SelectSpinnerItemByValue(spA, producto.getInt(producto.getColumnIndex("Destino")));
									Generales.SelectSpinnerItemByValue(spinMotivo, producto.getInt(producto.getColumnIndex("TipoMotivo")));
									InventarioTraspasoID_sel = producto.getString(producto.getColumnIndex("_id"));
									Cantidad_anterior_sel = producto.getFloat(producto.getColumnIndex("Cantidad"));
								}
								captura.llenarProductoUnidad(oProducto, producto.getInt(producto.getColumnIndex("TipoUnidad")), producto.getFloat(producto.getColumnIndex("Cantidad")));
								/*if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)))
								{
									int Tipo = producto.getInt(producto.getColumnIndex("TipoMotivo"));
									Generales.SelectSpinnerItemByValue(spinMotivo, Tipo);
								}*/
							}

						}
					});	

			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}

			txtScanner.requestFocus();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}

	}
	
	public void setMotivo(Short tipo){
		Generales.SelectSpinnerItemByValue(spinMotivo, tipo);
	}
	
	public Short getMotivo(){
		return (short) spinMotivo.getSelectedItemId();
	}

	public void setFolio(String folio)
	{
		TextView texto = (TextView) findViewById(R.id.lblFolio);
		texto.setText(Mensajes.get("XFolio") + ": " + folio);
	}

	public void setFecha(String fecha)
	{
		TextView texto = (TextView) findViewById(R.id.lblFecha);
		texto.setText(Mensajes.get("XFecha") + ": " + fecha);
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				salir();
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
		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_ELIMINAR)) || (mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_NO_MODIFICAR)))
		{

		}
		else
		{
			super.onCreateContextMenu(menu, v, menuInfo);
			MenuInflater inflater = getMenuInflater();
			inflater.inflate(R.menu.context_transaccion_detalle, menu);
			menu.getItem(0).setTitle(Mensajes.get("XEliminar"));
		}
	}

	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		mostrarPreguntaSiNo(Mensajes.get("P0233"), 2);
		return true;
	}

	@Override
	public void iniciar()
	{
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
			if (hayProductos && (huboCambios && mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO)))
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
			BDVend.rollback();
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
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
            try {
                switch (viewId) {
                    case R.id.lblUnidad:
                    case R.id.lblUnidadProductoClave_Mov:
                        TextView unidadproducto = (TextView) view;
                        unidadproducto.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("TipoUnidad"))));
                        break;
                    case R.id.lblCantidad_Mov:
                        TextView cantidad = (TextView) view;
                        cantidad.setText(String.valueOf(cursor.getFloat(columnIndex)));
                        break;
                    case R.id.lblDescripcion_Mov:
                        TextView lblDescripcion = (TextView) view;
                        lblDescripcion.setText(cursor.getString(cursor.getColumnIndex("ProductoClave")) + " - " + cursor.getString(columnIndex));
                        break;
                    case R.id.lblOrigen:
                        TextView origen = (TextView) view;
                        origen.setText(ValoresReferencia.getDescripcion("INVUBIC", cursor.getString(cursor.getColumnIndex("Origen"))));
                        break;
                    case R.id.lblDestino:
                        TextView destino = (TextView) view;
                        destino.setText(ValoresReferencia.getDescripcion("INVUBIC", cursor.getString(cursor.getColumnIndex("Destino"))));
                        break;
                    case R.id.lblMotivoTxt:
                        TextView motivo = (TextView) view;
                        motivo.setText(ValoresReferencia.getDescripcion("TRPMOT", cursor.getString(cursor.getColumnIndex("TipoMotivo"))));
                        break;
                    case R.id.lblDe:
                        TextView de = (TextView) view;
                        de.setText(Mensajes.get("XDe") + ":");
                        break;
                    case R.id.lblA:
                        TextView a = (TextView) view;
                        a.setText(Mensajes.get("XA") + ":");
                        break;
                    case R.id.lblMotivo:
                        TextView mot = (TextView) view;
                        mot.setText(Mensajes.get("XMotivo") + ":");
                        break;
                    default:
                        TextView texto = (TextView) view;
                        texto.setText(cursor.getString(columnIndex));
                        break;
                }
            }catch(Exception ex){
                mostrarError(ex.getMessage());
            }
			return true;
		}
	}

	/*public void setLimpiarMotivo()
	{
		if (spinMotivo.getAdapter() != null)
		{
			((SimpleCursorAdapter) spinMotivo.getAdapter()).getCursor().close();
		}
		spinMotivo.setEnabled(false);
	}*/
	
	@Override
	public void impresionFinalizada(boolean impresionExitosa, String mensajeError)
	{
		if (mensajeError.equals(""))
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
		else			
			setResultado(Enumeradores.Resultados.RESULTADO_MAL, mensajeError);

        try {
            if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
                if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).equals("0")) {
                    mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
                } else {
                    finalizar();
                }
            } else {
                mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
            }
        }catch(Exception ex){
            mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
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
				try
				{
					bHuboInserciones = true;
					if (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO)){
						TransProdDetalle detalle = ((TransProdDetalle) producto.getValue());
						mPresenta.agregarProductoUnidadTraspaso(detalle.ProductoClave, detalle.TipoUnidad, detalle.Cantidad, motivo, origen, destino);
					}else
						mPresenta.agregarProductoUnidad(((TransProdDetalle) producto.getValue()), false);
				}
				catch (Exception ex)
				{
					mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
				}
			}

			if (bHuboInserciones)
			{
				if (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO)){
					refrescarProductos("");
				}else
					refrescarProductos(mPresenta.getTransaccionesIds());
			}
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	private Vista getVista()
	{
		return this;
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
					if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO))){
						combo.setText(cursor.getString(cursor.getColumnIndex("suggest_text_1")));
					}else{
						Log.e("", ValoresReferencia.getDescripcion("TRPMOT", cursor.getString(cursor.getColumnIndex("suggest_intent_data"))));
						combo.setText(ValoresReferencia.getDescripcion("TRPMOT", cursor.getString(cursor.getColumnIndex("suggest_intent_data"))));
					}
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}

	@SuppressWarnings("deprecation")
	public void llenarSpiner(Spinner control, ISetDatos valores)
	{
		try
		{
			Cursor unidad = (Cursor) valores.getOriginal();
			startManagingCursor(unidad);
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(CapturaMovConInventario.this, android.R.layout.simple_spinner_item, unidad, new String[]
			{ "suggest_intent_data" }, new int[]
			{ android.R.id.text1 });
			adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
			adapter.setViewBinder(new llenarSpinner());
			control.setAdapter(adapter);
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
	}

	private boolean validarInformacion(String id, String pass)
	{
		if (id.length() == 0)
		{
			mostrarAdvertencia(Mensajes.get("BE0001", Mensajes.get("XUsuario")));
			return false;
		}
		if (pass.length() == 0)
		{
			mostrarAdvertencia(Mensajes.get("BE0001", Mensajes.get("XContraseña")));
			return false;
		}
		return true;
	}
	
    public void validarPermisos(String tipoIndice, int tipoPermiso) //Metodo que valida permisos ldelatorre
    {
    	boolean validar = false;
		try
		{
			
			String id = "TINDMMD" + tipoIndice;
			String permiso = Consultas.ConsultasPermisos.validarPermisos(id);
			String contrasenaPara = ValoresReferencia.getDescripcion("TINDMMD", String.valueOf(tipoIndice));
            Log.i(null,"Chequeo de variables id:"+id+" permiso: "+permiso);
            
			if (permiso.equals("1"))
			{
				validar = true;
			}
			else
			{
				
				switch(tipoPermiso)
				{
					case Enumeradores.TipoPermiso.ACCESAR:
						if(permiso.equals("") && solicitarContrasena == 1)
						{
						
							showAlertDialog(contrasenaPara);
							solicitarContrasena = 0;
						}
						break;
					
					case Enumeradores.TipoPermiso.CREAR:
						if(!lineaPermiso('C',permiso) && solicitarContrasena == 1)
						{
				
							showAlertDialog(contrasenaPara);
						}
						break;
						
					case Enumeradores.TipoPermiso.MODIFICAR:
						if(!lineaPermiso('U',permiso) && solicitarContrasena == 1)
						{
						
							showAlertDialog(contrasenaPara);
						}
						break;
						
					case Enumeradores.TipoPermiso.ELIMINAR:
						if(!lineaPermiso('D',permiso) && solicitarContrasena == 1)
						{
						
							showAlertDialog(contrasenaPara);
						}
						break;				
				}
				
				validar = vali;
			
			}
			
			if(Integer.parseInt(tipoIndice) == 8)
			{
				Log.i(null,"pasa contrasena: "+solicitarContrasena+" tipo indice"+tipoIndice);
				Sesion.set(Campo.SolicitarContrasenaDevolucionAlmacen, solicitarContrasena);
			}
			if(Integer.parseInt(tipoIndice) == 15 )
			{
				Log.i(null,"pasa contrasena: "+solicitarContrasena+" tipo indice"+tipoIndice);
				Sesion.set(Campo.SolicitarContrasenaDescarga, solicitarContrasena);
			}
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		//return validar;
    }

    public void showAlertDialog(String contrasenaPara)//Metodo que valida permisos ldelatorre
	{
    	
    	
		LayoutInflater factory = LayoutInflater.from(this);

		// text_entry is an Layout XML file containing two text field to display
		// in alert dialog
		
		
		final View textEntryView = factory.inflate(R.layout.acceso_dia_diferente, null);

		final TextView lblLogin = (TextView) textEntryView.findViewById(R.id.lblAlertUser);
		lblLogin.setText(Mensajes.get("XUsuario"));

		final TextView lblPass = (TextView) textEntryView.findViewById(R.id.lblAlertPass);
		lblPass.setText(Mensajes.get("XContraseña"));

		final EditText txtUser = (EditText) textEntryView.findViewById(R.id.txtAlertUser);
		final EditText txtPass = (EditText) textEntryView.findViewById(R.id.txtAlertPass);

		final AlertDialog.Builder alert = new AlertDialog.Builder(this, R.style.MisClientes_CustomDialog);
		alert.setTitle(contrasenaPara).setView(textEntryView).setPositiveButton(Mensajes.get("BTContinuar"), new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int whichButton)
			{
				String clave = txtUser.getText().toString();
				String pass = txtPass.getText().toString();
				if (validarInformacion(clave, pass))
				{
					Usuario usuario = null;
					try
					{
						usuario = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(clave);
					}
					catch (Exception e)
					{
						e.printStackTrace();
						mostrarError(e.getMessage());
					}

					if ((usuario == null) || (!EncriptaDesencripta.encripta(pass).equals(usuario.ClaveAcceso)))
					{
						dialogoRegresar();
						
					}
					else
					{
						if (!usuario.PERClave.equals("Admin"))
							mostrarAdvertencia(Mensajes.get("I0271"));
						else
						 vali = true;
					}
				}
			}
		}).setNegativeButton(Mensajes.get("BTRegresar"), new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int whichButton)
			{
                 regresar();
			}
		}).setOnKeyListener(new OnKeyListener()
		{
			
			@Override
			public boolean onKey(DialogInterface dialog, int keyCode, KeyEvent event)
			{
				switch (keyCode)
				{
					case KeyEvent.KEYCODE_BACK:
						regresar();
						break;
				}
				return false;
			}
		});
		alert.show();
		
		//return vali;
	}
    
    private void dialogoRegresar()//Metodo que valida permisos ldelatorre
    {
    	AlertDialog.Builder dialog = new AlertDialog.Builder(this);

		dialog.setMessage(Mensajes.get("MDB050601"));
		dialog.setCancelable(false);
		dialog.setPositiveButton(Mensajes.get("XAceptar"), new DialogInterface.OnClickListener()
		{

			@Override
			public void onClick(DialogInterface dialog, int which)
			{
				regresar();
			}
		});
		dialog.show();
    }

    private boolean lineaPermiso(char per, String permisos)//Metodo que valida permisos ldelatorre
    {
    	for(int x = 0; x < permisos.length(); x++)
    	{
    		char caracter = permisos.charAt(x);
    		
    		if(caracter == per)
    		{
    			return true;
    		}
    	}
    	return false;
    }
}
