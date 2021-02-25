package com.amesol.routelite.vistas;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.DialogInterface.OnShowListener;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Color;
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
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.Spinner;
import android.widget.TableLayout.LayoutParams;
import android.widget.TextView;
import android.widget.Toast;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.EnvioPDF;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.InventarioDobleUnidad;
import com.amesol.routelite.actividades.InventarioLotesKey;
import com.amesol.routelite.actividades.ListaPrecio;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Promociones2;
import com.amesol.routelite.actividades.Promociones2.onTerminarAplicacionListener;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.CapturaProducto;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TPDImpuesto;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
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
import com.amesol.routelite.presentadores.interfaces.ICapturaInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedidoSugerido;
import com.amesol.routelite.presentadores.interfaces.ICapturaTotales;
import com.amesol.routelite.presentadores.interfaces.ICapturaTotalesConsignacion;
import com.amesol.routelite.presentadores.interfaces.IConsultaUltimaVenta;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.DialogoAlerta;
import com.amesol.routelite.vistas.generico.StockAdapter;

import org.w3c.dom.Document;
import org.w3c.dom.NodeList;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.Map.Entry;
import java.util.concurrent.atomic.AtomicReference;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;


public class CapturaPedido extends Vista implements ICapturaPedido {

    CapturarPedido mPresenta;

    CapturaProducto captura;

    String mAccion;
    int index;
    int top;
    HashMap<String, String> oParametros = null;
    HashMap<String, String> htColores = null;


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
//private Cursor producto;
	private Menu mnu;
	boolean surtir = false;
	boolean reparto = false;
	ArrayList<TransProdDetalle> prodSinExistencia = new ArrayList<TransProdDetalle>();
	boolean consultar = false;
	boolean modificando = false;
    boolean modificandoAutoventa = false;
	MenuItem modificar;
	MenuItem convertir;
	boolean manejoDobleUnidad = false;

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
    ISetDatos envasesPorRecolectar;
	String inventarioID;
	HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleDobleUnidadAgregar = null;

	private static final String FRAGMENT_TAG = "ventaMensualFragment";
    private Button btPrecioManualAceptar=null;

	boolean mensajeValidaCredito = false;
	boolean mensajeLimiteEnvase = false;
	boolean mensajeError = false;

	boolean inventarioPorLotes = false;
	boolean capturaCadLote = false;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
            if(Integer.parseInt(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString()) != Enumeradores.TiposModuloMovDetalle.CONSIGNACION)
                BDVend.setGuardarLog(true);

			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();
			setContentView(R.layout.captura_pedido);
			deshabilitarBarra(true);

			try {
				inventarioPorLotes = (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("InventarioPorLotes") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("InventarioPorLotes").equals("1"));
			}catch(Exception e){}

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

			if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1")) {
				manejoDobleUnidad = true;
			}
			captura = (CapturaProducto) findViewById(R.id.capturaProducto);
			if(manejoDobleUnidad){
				captura.setOnAgregarProdDobleUnidadListener(mAgregarProdDobleUnidadListener);
			}else {
				captura.setOnAgregarProductoListener(mAgregarProductoListener);
			}
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
                if( (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
                        && mAccion != Acciones.ACCION_CAPTURAR_MOV_SIN_INV_EN_VISITA
                        && ((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("AgruparTransacciones").toString().equals("1")){
					//agrupar transacciones
					ArrayList<String> transacciones = Consultas.ConsultasTransProd.agruparTransacciones(oParametros.get("TransProdId"));
					for(String tran : transacciones){
						mPresenta.agregarTransaccion(tran);
						Consultas.ConsultasTRPGrupo.eliminarTransaccionGrupo(tran); //eliminar el registro del grupo
                        setHuboCambios(true);
					}
                }else
					mPresenta.agregarTransaccion(oParametros.get("TransProdId"));
			}

            Date seleccion = new Date();
            SimpleDateFormat x = new SimpleDateFormat("dd/MM/yyyy");
            seleccion = x.parse(((Dia)Sesion.get(Campo.DiaActual)).DiaClave );
            if (Generales.getFechaActual().compareTo(seleccion) != 0){
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ValidarActPrecio")) {
                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ValidarActPrecio").equals("1")) {
                        //Se revisa el archivo de actualizaciones, para ver si se actualizaron los precios
                        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
                        DocumentBuilder db;
                        Document xmlActualiza;
                        boolean archivosServerEliminados = true;
                        try {
                            ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
                            File archXML = new File(conf.get(ArchivoConfiguracion.CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
                            archXML = new File(archXML, "bd");
                            archXML = new File(archXML, BDVend.nombreBaseDatos().replace("db", "xml"));

                            db = dbf.newDocumentBuilder();
                            xmlActualiza = db.parse(new File(archXML.getAbsolutePath()));

                            NodeList tablasXml = xmlActualiza.getFirstChild().getChildNodes();
                            String nombreTabla;
                            Date fechaActualizacion = new Date(1900,1,1);
                            for (int i = 0; i <= tablasXml.getLength() - 1; i++)
                            {
                                nombreTabla = tablasXml.item(i).getChildNodes().item(0).getTextContent();
                                if (nombreTabla.equalsIgnoreCase("Precio") || nombreTabla.equalsIgnoreCase("PrecioProductoVig"))
                                {
                                    Date actualizacion = new Date();
                                    SimpleDateFormat formatDate = new SimpleDateFormat("yyyy-MM-dd");
                                    actualizacion = formatDate.parse( tablasXml.item(i).getChildNodes().item(1).getTextContent());
                                    if (fechaActualizacion.compareTo(actualizacion) >0){
                                        fechaActualizacion =actualizacion;
                                    }
                                }
                            }

                            if (Generales.getFechaActual().compareTo(fechaActualizacion) >0){
                                mostrarError(Mensajes.get("E0954"),0);
                                mPresenta.errorFinalizar = true;
                                //BDVend.setGuardarLog(false);
                                return;
                            }

                        }catch (Exception ex){
                            mostrarError("Error al recuperar el parámetro ValidarActPrecio");
                        }
                    }
                }
            }

			mPresenta.iniciar();

			if (mPresenta.errorFinalizar){
                //BDVend.setGuardarLog(false);
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
                //marcar como modificado CAI 3111
				modificandoAutoventa = true;
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
            captura.setSurtir(surtir);

			try {

				capturaCadLote = (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()) && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("1"));
			}catch(Exception e){}

			captura.setCapturaCadLote(capturaCadLote );

            /*Se excluyen de la venta los productos tipo Canje
            Con la finalidad de que solo se muestren en
            las promociones*/
            captura.setExcluirCanjes(true);

			if (!soloLectura)
			{
				registerForContextMenu(lista);
				//lista.setOnItemLongClickListener(menu);
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

		txtScaner.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {

                if (hasFocus) {
                    // getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE);
                    txtCantidad.clearFocus();
                }
            }
        });
	}
	
	public void setCapturaCantidad(float cantidad){
		captura.setCantidad(cantidad);
	}
	

	//Se usa solo para el manejo normal de unidades
	private boolean validarVenderApartado(Producto producto, int tipoUnidad, float cantidad){
		return validarVenderApartado(producto,tipoUnidad,cantidad, null, null, null);
	}

	//Se usa para el manejo normal de unidades
	private boolean validarVenderApartado(Producto producto, int tipoUnidad, float cantidad, Float cantidadOriginal, String transProdID, String transProdDetalleID ){
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
				/*guardar todo en las varibles para poder agregar si responde SI*/
				tipoUnidadAgregar = tipoUnidad;
				productoAgregar = producto;
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
                Button boton = (Button) findViewById(R.id.btnContinuar);
                boton.setEnabled(false);

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
							promociones.EliminarProductosAplicados();
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

	/*public OnItemLongClickListener menu = new OnItemLongClickListener()
	{

		@Override
		public boolean onItemLongClick(AdapterView<?> arg0, View arg1, int arg2, long arg3)
		{
			openContextMenu(lista);
			return true;
		}
	};*/

	@Override
	public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo)
	{
		super.onCreateContextMenu(menu, v, menuInfo);
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.context_transaccion_detalle, menu);

		if(mPresenta.getTipoPedido() == Enumeradores.TipoPedido.BACKORDER)
			menu.getItem(0).setVisible(false);
		else
			menu.getItem(0).setTitle(Mensajes.get("XEliminar"));
		if (((Vendedor) Sesion.get(Campo.VendedorActual)).ModificarPrecios != 0){
			menu.getItem(1).setTitle(Mensajes.get("XModificarPrecio"));
			menu.getItem(1).setVisible(true);
		}

        if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("AsignarManualListas").equals("1")){
            menu.getItem(2).setTitle(Mensajes.get("XCambiarListaPrecio"));
            menu.getItem(2).setVisible(true);
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

					View dialogView;
                    if (((Vendedor) Sesion.get(Campo.VendedorActual)).ModificarPrecios == 1)
                        dialogView = inflater.inflate(R.layout.dialog_number_picker, null);
                    else
                        dialogView = inflater.inflate(R.layout.dialog_modificar_precio, null);

					AlertDialog.Builder builder = new AlertDialog.Builder(CapturaPedido.this);
					final EditText  np = (EditText) dialogView.findViewById(R.id.numText );
					np.setSelectAllOnFocus(true);

					Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
					final String transProdID= producto.getString(producto.getColumnIndex("TransProdID"));
					final String transProdDetalleID = producto.getString(producto.getColumnIndex("TransProdDetalleID"));
					final String subEmpresaId = producto.getString(producto.getColumnIndex("SubEmpresaId"));
					final String productoClave = producto.getString(producto.getColumnIndex("ProductoClave"));
					final short tipoUnidad = producto.getShort(producto.getColumnIndex("TipoUnidad"));
					final float cantidad = producto.getFloat(producto.getColumnIndex("Cantidad"));
					final float precio = Generales.getRound(producto.getFloat(producto.getColumnIndex("Precio")),Integer.parseInt(((CONHist)Sesion.get(Campo.CONHist)).get("DecimalesImporte").toString()));
					final String listaPrecio = producto.getString(producto.getColumnIndex("PrecioClave"));
					final float precioMax = ListaPrecio.BuscarPrecio(productoClave, tipoUnidad, "'" + listaPrecio + "'", new StringBuilder(), cantidad);
                    final float precioMin = ListaPrecio.ObtenerPecioMinimo("'" + listaPrecio + "'", productoClave, tipoUnidad);
                    final float precioSug = ListaPrecio.obtenerPrecioSugerido("'" + listaPrecio + "'", productoClave, tipoUnidad);


                    if (((Vendedor) Sesion.get(Campo.VendedorActual)).ModificarPrecios == 1)
					    np.setText(Generales.getFormatoDecimal(producto.getFloat(producto.getColumnIndex("Precio")),Integer.parseInt(((CONHist)Sesion.get(Campo.CONHist)).get("DecimalesImporte").toString())));
                    else {
                        TextView lblMinimo = (TextView)dialogView.findViewById(R.id.lblMinimo);
                        lblMinimo.setText(Mensajes.get("XMINIMO"));
                        TextView lblMaximo = (TextView)dialogView.findViewById(R.id.lblMaximo);
                        lblMaximo.setText(Mensajes.get("XMAXIMO"));

                        np.setText(Generales.getFormatoDecimal(precioSug,Integer.parseInt(((CONHist)Sesion.get(Campo.CONHist)).get("DecimalesImporte").toString())));
                        TextView txtMinimo = (TextView)dialogView.findViewById(R.id.txtMinimo);
                        txtMinimo.setText(Generales.getFormatoDecimal(precioMin, Integer.parseInt(((CONHist)Sesion.get(Campo.CONHist)).get("DecimalesImporte").toString())));
                        TextView txtMaximo = (TextView)dialogView.findViewById(R.id.txtMaximo);
						txtMaximo.setText(Generales.getFormatoDecimal(precioMax, Integer.parseInt(((CONHist)Sesion.get(Campo.CONHist)).get("DecimalesImporte").toString())));
                        //txtMaximo.setText(Generales.getFormatoDecimal(producto.getFloat(producto.getColumnIndex("Precio")),Integer.parseInt(((CONHist)Sesion.get(Campo.CONHist)).get("DecimalesImporte").toString())));
                    }
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
										//Float precioMin = ListaPrecio.ObtenerPecioMinimo(mPresenta.getListasPrecios(), productoClave, tipoUnidad);
										if((((Vendedor) Sesion.get(Campo.VendedorActual)).ModificarPrecios == 1 && precioEspecial >= precioMin) || (((Vendedor) Sesion.get(Campo.VendedorActual)).ModificarPrecios == 2 && precioEspecial >= precioMin && precioEspecial <= precioMax)){
											mPresenta.eliminarDetalle(transProdID, transProdDetalleID, subEmpresaId, productoClave, tipoUnidad, cantidad, false );
											mPresenta.agregarProductoUnidad(productoClave, subEmpresaId, tipoUnidad, cantidad, precioEspecial,true,listaPrecio);
											dialog.dismiss();
										}else{
											if (((Vendedor) Sesion.get(Campo.VendedorActual)).ModificarPrecios == 1)
												mostrarError(Mensajes.get("I0278"));
											else
												mostrarError(Mensajes.get("I0333"));
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
										mPresenta.eliminarDetalle(transProdID, transProdDetalleID, subEmpresaId, productoClave, tipoUnidad, cantidad, false );
										mPresenta.agregarProductoUnidad(productoClave, subEmpresaId, tipoUnidad, cantidad, precioEspecial, true,listaPrecio);
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
            case R.id.modificarListaPrecio:
                try
                {
                    //obtenerTotales(TransProdId);
                    //SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.elemento_captura_producto, cProductos, new String[]
                      //      { "TipoUnidad", "ProductoClave", "Descripcion", "Precio", "Cantidad", "Total", "Existencia", "CantidadOriginal" }, new int[]
                       //     { R.id.lblUnidadProductoClave, R.id.lblUnidadProductoClave, R.id.lblDescripcion, R.id.lblPU, R.id.lblCantidad, R.id.lblTotal, R.id.lblExistencia, R.id.lblCantidadOriginal });
                    //adapter.setViewBinder(new vista());
                    //lista.setAdapter(adapter);

                    Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
                    final String productoClave = producto.getString(producto.getColumnIndex("ProductoClave"));
                    final short tipoUnidad = producto.getShort(producto.getColumnIndex("TipoUnidad"));

                    LayoutInflater inflater = (LayoutInflater) CapturaPedido.this
                            .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

                    View dialogViewModificarListaPrecio = inflater.inflate(R.layout.dialog_listas_precios, null);

                    AlertDialog.Builder builder = new AlertDialog.Builder(CapturaPedido.this);
                    ListView lista_precios = (ListView) dialogViewModificarListaPrecio.findViewById(R.id.lstAgenda);

                    String sClienteClave = ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave;
                    ISetDatos MinMaxJerarquia = Consultas.ConsultasPrecio.obtenerJerarquiaMinMaxCliente(sClienteClave);
                    MinMaxJerarquia.moveToFirst();

                    String sListaPrecios = mPresenta.getListasPreciosPedido();
                    ISetDatos precios = Consultas.ConsultasPrecio.obtenerPreciosProducto(productoClave, tipoUnidad, sClienteClave, sListaPrecios, MinMaxJerarquia.getShort("JerarquiaMinima"), MinMaxJerarquia.getShort("JerarquiaMaxima"));

                    if (precios.getCount() == 0){
                        mostrarError(Mensajes.get("I0306"));
                        return true;
                    }


                    Cursor cPrecios = (Cursor) precios.getOriginal();
                    startManagingCursor(cPrecios);
                    //ListAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple2_hor, cPrecios, new String[] { "Descripcion", "Precio" }, new int[] { R.id.txtCol1, R.id.txtCol2 });
                    SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple2_hor, cPrecios, new String[] { "Descripcion", "Precio" }, new int[] { R.id.txtCol1, R.id.txtCol2 });
                    adapter.setViewBinder(new vistaListasPrecios());
                    lista_precios.setAdapter(adapter);
                    lista_precios.setOnItemClickListener(new OnItemClickListener() {
                        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                            String sPrecioManual;
                            Cursor listasprecios = (Cursor) parent.getItemAtPosition(position);
                            listasprecios.moveToPosition(position);
                            sPrecioManual = listasprecios.getString(2);

                            Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
                            final String transProdID= producto.getString(producto.getColumnIndex("TransProdID"));
                            final String transProdDetalleID = producto.getString(producto.getColumnIndex("TransProdDetalleID"));
                            final String subEmpresaId = producto.getString(producto.getColumnIndex("SubEmpresaId"));
                            final String productoClave = producto.getString(producto.getColumnIndex("ProductoClave"));
                            final short tipoUnidad = producto.getShort(producto.getColumnIndex("TipoUnidad"));
                            final float cantidad = producto.getFloat(producto.getColumnIndex("Cantidad"));
                            float precioEspecial = Generales.getRound(Float.parseFloat(sPrecioManual),Integer.parseInt(((CONHist)Sesion.get(Campo.CONHist)).get("DecimalesImporte").toString()));

                            Sesion.set(Campo.CambioLPTpdExtra,true);
                            Sesion.set(Campo.LPTpdExtra,listasprecios.getString(0));
                            mPresenta.eliminarDetalle(transProdID, transProdDetalleID, subEmpresaId, productoClave, tipoUnidad, cantidad, false );
                            mPresenta.agregarProductoUnidad(productoClave, subEmpresaId, tipoUnidad, cantidad, precioEspecial);
                            Sesion.set(Campo.LPTpdExtra,"");
                            Sesion.set(Campo.CambioLPTpdExtra,false);
                            btPrecioManualAceptar.performClick();
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
                    builder.setView(dialogViewModificarListaPrecio);
                    final Dialog dialog = builder.create();
                    dialog.setOnShowListener(new OnShowListener() {
                        @Override
                        public void onShow(DialogInterface dialog) {
                            btPrecioManualAceptar = ((AlertDialog) dialog)
                                    .getButton(AlertDialog.BUTTON_NEGATIVE);
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

	public void mostrarPromocionProducto(String promocionClave, String promocionReglaID, int CantidadGrupoApp, String SubEmpresaId, int cantidad, String productoDisparador, String cadenaListasPrecios)
	{
        Button boton = (Button) findViewById(R.id.btnContinuar);
        boton.setEnabled(false);
		HashMap<String, Object> oParametros = new HashMap<String, Object>();
		oParametros.put("PromocionClave", promocionClave);
		oParametros.put("PromocionReglaID", promocionReglaID);
		oParametros.put("CantidadGrupo", CantidadGrupoApp);
		oParametros.put("SubEmpresaID", SubEmpresaId);
		oParametros.put("CantidadMax", cantidad);
		oParametros.put("TipoValidarExistencia", mPresenta.getTipoValidacionExistencia());
        oParametros.put("ProductoDisparador", productoDisparador);
        oParametros.put("CadenaListasPrecio", cadenaListasPrecios);
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
		Button botonContinuar = (Button) findViewById(R.id.btnContinuar);
		botonContinuar.setEnabled(true);

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
					if(inventarioPorLotes){
						insertarSeleccionLotes((HashMap<InventarioLotesKey, TransProdDetalle>) Sesion.get(Campo.ResultadoActividad));
					}else {
						if(Sesion.get(Campo.ResultadoActividad).getClass()  == HashMap.class) {
							insertarSeleccion((HashMap<String, TransProdDetalle>) Sesion.get(Campo.ResultadoActividad));
						}
					}
					Sesion.remove(Campo.ResultadoActividad);
                    captura.setFinBusqueda();
				}else{
					captura.setFinBusqueda();
					if(data != null) {
						txtScanner.setTexto(data.getStringExtra("mensajeIniciar"));
						captura.IngresaProductoBusquedaSimple(data.getStringExtra("mensajeIniciar"));
					}
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
                captura.setFinBusqueda();
			}
			//captura.setFinBusqueda();
		}
		else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_PROMOCIONES_APLICADAS)
		{
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				regresandoPromo = true;
			}else {
                if (data != null) {
                    String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                    if (mensajeError.contains("SinPrecio")) {
                        mostrarError(Mensajes.get("E0958", mensajeError.replace("SinPrecio", "")), 60);
                    }
                }
            }
		}
		else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_TOTALES)
		{
			// regreso de la pantalla de totales
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				if (data != null)
				{
					String mensaje = (String) data.getExtras().getString("mensajeIniciar");
					if (mensaje != null && (mensaje.equals("I0274") || mensaje.equals("I0321")))
					{
						mostrarAdvertencia(Mensajes.get(mensaje));
						mPresenta.eliminarPromos();
					    refrescarProductos(mPresenta.getTransaccionesIds());
						setListaPrecios(mPresenta.getNombreListaPrecioInicial());
						return;
					}
				}
				// si selecciono terminar, finalizar la captura del pedido
				setResult(Enumeradores.Resultados.RESULTADO_BIEN);
				finalizar();
			}
			else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
			{
				String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
				if (!mensajeError.equals(""))
				{// cuando se presiona back se manda el mensaje vacio
						this.setResultado(Enumeradores.Resultados.RESULTADO_MAL, mensajeError);
						finalizar();
				}
				else
				{ // si el mensaje esta vacio, presiono back
					mPresenta.eliminarPromos();
					if (Sesion.get(Campo.ResultadoActividad) != null && Sesion.get(Campo.ResultadoActividad).equals("ErrorLimiteCredito") ){
						botonContinuar.setEnabled(false);
						if (mnu != null && mnu.getItem(2)!= null){
							mnu.getItem(2).setEnabled(false);
						}
						Sesion.remove(Campo.ResultadoActividad);
					}
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
        else if (requestCode == Solicitudes.SOLICITUD_TOMAR_INVENTARIO_PEDIDO) {
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
            {
                if (Sesion.get(Campo.ResultadoActividad) != null)
                {
                    insertarSeleccion((HashMap<String, TransProdDetalle>) Sesion.get(Campo.ResultadoActividad));
                    Sesion.remove(Campo.ResultadoActividad);
                    if (data != null)
                    {
                        String res = (String) data.getExtras().getString("mensajeIniciar");
                        if (!res.equals(""))
                        {
                            inventarioID = res;
                        }
                    }
                }
            }else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
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
        }

	}

	@Override
	public void onDestroy()
	{
		super.onDestroy();
        if (lista.getAdapter() != null){
            stopManagingCursor(((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())));
            ((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())).close();
        }

        if (captura.getSpinnerUnidad() != null && captura.getSpinnerUnidad().getAdapter() != null){
            stopManagingCursor(((Cursor) (((SimpleCursorAdapter) captura.getSpinnerUnidad().getAdapter()).getCursor())));
            ((Cursor) (((SimpleCursorAdapter) captura.getSpinnerUnidad().getAdapter()).getCursor())).close();
        }
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if(mensajeValidaCredito) //quitar la bandera del mensaje de limite de credito para continuar
			mensajeValidaCredito = false;

		if(mensajeLimiteEnvase)
			mensajeLimiteEnvase = false;

		if (tipoMensaje == 2)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				if (manejoDobleUnidad){
					Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
					HashMap<Short,InventarioDobleUnidad.DetalleProductoDobleUnidad> hmUnidades = new HashMap<Short,InventarioDobleUnidad.DetalleProductoDobleUnidad>();
					hmUnidades.put(producto.getShort(producto.getColumnIndex("TipoUnidad")), new InventarioDobleUnidad.DetalleProductoDobleUnidad(producto.getShort(producto.getColumnIndex("TipoUnidad")), null,  producto.getFloat(producto.getColumnIndex("Cantidad")),null, null, producto.getShort(producto.getColumnIndex("DecimalProd1")),null));
					if(producto.getShort(producto.getColumnIndex("UnidadAlterna"))>0 ){
						hmUnidades.put(producto.getShort(producto.getColumnIndex("UnidadAlterna")), new InventarioDobleUnidad.DetalleProductoDobleUnidad(producto.getShort(producto.getColumnIndex("UnidadAlterna")), null,  producto.getFloat(producto.getColumnIndex("CantidadAlterna")),null, null, producto.getShort(producto.getColumnIndex("DecimalProd2")),null));
					}
					mPresenta.eliminarDetalleDobleUnidad(producto.getString(producto.getColumnIndex("TransProdID")), producto.getString(producto.getColumnIndex("TransProdDetalleID")),producto.getString(producto.getColumnIndex("SubEmpresaId")), producto.getString(producto.getColumnIndex("ProductoClave")),  hmUnidades,true);
					captura.limpiarProducto();
				}else {
					Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
					mPresenta.eliminarDetalle(producto.getString(producto.getColumnIndex("TransProdID")), producto.getString(producto.getColumnIndex("TransProdDetalleID")), producto.getString(producto.getColumnIndex("SubEmpresaId")), producto.getString(producto.getColumnIndex("ProductoClave")), producto.getShort(producto.getColumnIndex("TipoUnidad")), producto.getFloat(producto.getColumnIndex("Cantidad")));
					captura.limpiarProducto();
				}
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
					if (promociones.promocionActual.Tipo == com.amesol.routelite.actividades.Enumeradores.Promocion.Tipo.ProductoAcumulado || promociones.promocionActual.Tipo == com.amesol.routelite.actividades.Enumeradores.Promocion.Tipo.EsquemaProducto)
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
					//ajustar inventario
					for(TransProdDetalle oTpd : prodSinExistencia){
						if(oTpd.Promocion == 2){//Solo los regalados se ajustan, para los canjes hay que modificar el pedido porque hay recalculo implicado
								Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, TiposTransProd.PEDIDO, TiposMovimientos.NO_DEFINIDO, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID, true);
								oTpd.CantidadOriginal = oTpd.Cantidad;
								oTpd.Cantidad = 0;
                                BDVend.guardarInsertar(oTpd);
						}
					}
                    if(Consultas.ConsultasPromocion.validarProntoPagoAplicadas(mPresenta.getTransProdIds()))
                        mostrarMensaje(Mensajes.get("I0311"), 0, 100);
                    else
                        cuadreEnvases();
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
				//modificar pedido
				modificarPedidoReparto();
				/*captura.setVisibility(View.VISIBLE);
				modificando = true;
				modificar.setEnabled(false);
				mPresenta.modificarPedido();*/
			}
		}else if(tipoMensaje == 10){
			if(respuesta == RespuestaMsg.Si){
				//mostrarAdvertencia("Agregar Producto");
				if (manejoDobleUnidad){
					if (transprodIDEliminar == null)
						mPresenta.agregarProductoDobleUnidad(hmDetalleDobleUnidadAgregar, productoAgregar.ProductoClave, productoAgregar.SubEmpresaId, null);
					else {
						mPresenta.eliminarDetalleDobleUnidad(transprodIDEliminar, transprodDetalleIDEliminar, productoAgregar.SubEmpresaId, productoAgregar.ProductoClave, hmDetalleDobleUnidadAgregar, false);
						mPresenta.agregarProductoDobleUnidad(hmDetalleDobleUnidadAgregar, productoAgregar.ProductoClave, productoAgregar.SubEmpresaId, transprodDetalleIDEliminar);
					}
				}else {
					if (cantidadOriginalAgregar == null)
						mPresenta.agregarProductoUnidad(productoAgregar.ProductoClave, productoAgregar.SubEmpresaId,  Short.parseShort(String.valueOf(tipoUnidadAgregar)), cantidadAgregar, Float.parseFloat("-1"));
					else {
						mPresenta.eliminarDetalle(transprodIDEliminar, transprodDetalleIDEliminar, productoAgregar.SubEmpresaId, productoAgregar.ProductoClave,  Short.parseShort(String.valueOf(tipoUnidadAgregar)), cantidadOriginalAgregar, false);
						mPresenta.agregarProductoUnidad(productoAgregar.ProductoClave, productoAgregar.SubEmpresaId, tipoUnidadAgregar, cantidadAgregar, Float.parseFloat("-1"), cantidadOriginalAgregar);
					}
				}
			}else{
				//mostrarAdvertencia("NO Agregar Producto");
			}
		}else if(tipoMensaje == 30){
			//cantidad maxima de producto
			if(respuesta == RespuestaMsg.Si){
				if(existe){
					int nPartida = 0;
					float nCantOrigReparto = 0;
					try {
						if ((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO)) {
							nPartida = Consultas.ConsultasTransProdDetalle.obtenerPartida(transprodIDEliminar, transprodDetalleIDEliminar);
							nCantOrigReparto = Consultas.ConsultasTransProdDetalle.obtenerCantidadOriginal(transprodIDEliminar, transprodDetalleIDEliminar);
						}
					}catch(Exception e){}

					mPresenta.eliminarDetalle(transprodIDEliminar, transprodDetalleIDEliminar, productoAgregar.SubEmpresaId, productoAgregar.ProductoClave, tipoUnidadAgregar, cantidadOriginalAgregar, false);
					if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO))
						mPresenta.agregarProductoUnidad(productoAgregar.ProductoClave, productoAgregar.SubEmpresaId, tipoUnidadAgregar, cantidadAgregar, Float.parseFloat("-1"),nCantOrigReparto, transprodDetalleIDEliminar, nPartida);
					else
						mPresenta.agregarProductoUnidad(productoAgregar.ProductoClave, productoAgregar.SubEmpresaId, tipoUnidadAgregar, cantidadAgregar, Float.parseFloat("-1"), cantidadOriginalAgregar);
				}else{
					mPresenta.agregarProductoUnidad(productoAgregar.ProductoClave, productoAgregar.SubEmpresaId, tipoUnidadAgregar, cantidadAgregar, Float.parseFloat("-1"));
				}
			}
		}else if(tipoMensaje == 40){
            if(respuesta == RespuestaMsg.Si){
                //TODO: sperez CUROLMOV_18 1.4.1.1
                try {
                    TransProd oTrp = null;
					docsTransProd = mPresenta.getHashMapTransacciones().values().iterator();
                    if(docsTransProd.hasNext()){
                        oTrp = docsTransProd.next();
                        Transacciones.recolectarEnvasesAutomaticamente(oTrp, envasesPorRecolectar,false);
                    }
                    //envasesPorRecolectar.close();
                    //iniciarCapturaTotales();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
			envasesPorRecolectar.close();
            iniciarCapturaTotales();
        }else if(tipoMensaje ==0){
			if(mPresenta.errorFinalizar){
                //BDVend.setGuardarLog(false);
				finalizar();
			}
		}else if (tipoMensaje == 60){
            regresandoPromo = true;
        }
        else if (tipoMensaje == 100){
            cuadreEnvases();
        }
		else if (tipoMensaje == 70){
			if(respuesta == RespuestaMsg.Si) {
				//Convertir pedido completo en consigna
				mPresenta.convertirPedidoEnConsigna();
				Runnable accion = new Runnable()
				{

					@Override
					public void run()
					{
						while(getMensajeLimiteCredito() || getMensajeLimiteEnvase()){
							//esperar hasta que se quite el mensaje de validacion de credito para continuar
						}
						runOnUiThread(new Runnable()
						{ //ejecutar en el thread de la ui para poder mostrar el mensaje de impresion
							@Override
							public void run()
							{
								terminar();
							}
						});
					}
				};
				final Thread hilo = new Thread(accion);
				hilo.start();
			}
		}
		else if (tipoMensaje == 8)
		{
			// imprimir recibo de consignación
			if (respuesta.equals(RespuestaMsg.Si))
			{
				// Imprimir ticket
				//imprimiendo = true;
				try
				{
					if (!bluetoothEncendido())
					{
						encenderBluetooth();
					}
					else
					{
						mPresenta.imprimirTicketConsignacion();
					}
					// getVista().mostrarAdvertencia("Recibos generados");
				}
				catch (Exception e)
				{
					Toast.makeText(getBaseContext(), e.getMessage(), Toast.LENGTH_LONG).show();
					setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
					finalizar();
				}
			}
			else
			{
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				finalizar();
			}
		}
	}
	
	private void modificarPedidoReparto(){
		//registerForContextMenu(lista);
		//lista.setOnItemLongClickListener(menu);
		convertir.setVisible(false);
		captura.setVisibility(View.VISIBLE);
		modificando = true;
		modificar.setEnabled(false);
		Button boton = (Button) findViewById(R.id.btnContinuar);
		boton.setEnabled(true);
		if (manejoDobleUnidad){
			mPresenta.modificarPedidoDobleUnidad();
		}else {
			mPresenta.modificarPedido();
		}
	}

	private void salir()
	{
		if (!esNuevo)
		{
			if (!soloLectura)
				mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
			else
			{
                try{
                    //Se agrega este rollback porque al surtir pedido entra como solo lectura y estaba cambiando el
                    //TipoPedido al entrar a los totales, lo que provocaba que el pedido desapareciera del listado
                   BDVend.rollback();
                }catch (Exception ex){
                    if (ex != null && ex.getMessage() != null){
                        mostrarError(ex.getMessage());
                    }
                }
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                //BDVend.setGuardarLog(false);
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
                    //BDVend.setGuardarLog(false);
					finalizar();
				}
			}
			else
			{ // no hay productos
				regresar();
			}
		}
	}

	public void terminar(){
		try{
			if (mensajeError){
				BDVend.rollback();
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				//BDVend.setGuardarLog(false);
				finalizar();
			}
			else {
				com.amesol.routelite.actividades.ModuloMovDetalle mmd = Consultas.ConsultasModuloMovDetalle.obtenerModuloMovDetallePorIndice(26);
				String mmdClave = mmd.getModuloMovDetalleClave();
				Folios.confirmar(mmdClave);
				BDVend.commit();

				solicitarImprimirTicket();
			}
		}catch (Exception ex){
			if (ex != null && ex.getMessage() != null){
				mostrarError(ex.getMessage());
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
            //BDVend.setGuardarLog(false);
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

	public void insertarSeleccionLotes(HashMap<InventarioLotesKey, TransProdDetalle> transProdDetalles)
	{
		try
		{
			Iterator<Entry<InventarioLotesKey, TransProdDetalle>> it = transProdDetalles.entrySet().iterator();
			boolean bHuboInserciones = false;
			while (it.hasNext())
			{ // recorrer los productos
				Map.Entry producto = (Map.Entry) it.next();
				String productoClave = ((InventarioLotesKey)producto.getKey()).ProductoClave;
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
						if (inventarioPorLotes) {
							TransProdDetalle otpd = Consultas.ConsultasTransProdDetalle.obtenerTPDProductoUnidadLote(mPresenta.getTransProdIds(), ((TransProdDetalle) producto.getValue()).ProductoClave, ((TransProdDetalle) producto.getValue()).TipoUnidad, ((TransProdDetalle) producto.getValue()).TPDDatosExtra.get(0).Lote  );
							if (otpd.isRecuperado()){
								mPresenta.eliminarDetalle(otpd.TransProdID, otpd.TransProdDetalleID, oProducto.getSubEmpresaId() , otpd.ProductoClave, otpd.TipoUnidad , otpd.Cantidad, false);
							}
						}
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
				refrescarProductosLote(mPresenta.getTransaccionesIds());
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

    public boolean getModificandoPedidoReparto()
    {
        return modificando;
    }

	public boolean getModificandoPedidoNoReparto()
	{
		return modificandoAutoventa;
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
                boton.setEnabled(true);
			}
			else
			{
				boolean cancConsigLiqui = "0".equals(((CONHist)Sesion.get(Campo.CONHist)).get("CancConsigLiqui"));
				if(consultar || (mPresenta.getModuloMovDetalle().TipoTransProd == TiposTransProd.VENTA_CONSIGNACION && cancConsigLiqui)
						|| (mAccion != null && mAccion.equals(Enumeradores.Acciones.ACCION_ELIMINAR_CONSIGNACIONES))){
					Sesion.set(Campo.ArrayTransProd, mPresenta.getHashMapTransacciones());
					iniciarCapturaTotales();
                    boton.setEnabled(true);
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
		}
	};

	private boolean hayProductos()
	{
		TextView totalProductos = (TextView) findViewById(R.id.txtTotalProductos);
		TextView totalUnidades = (TextView) findViewById(R.id.txtTotalUnidades);
		if (totalProductos.getText().toString().trim().equals("") || Float.parseFloat(totalProductos.getText().toString().replace(",", ".")) == 0 || totalUnidades.getText().toString().trim().equals("") || Float.parseFloat(totalUnidades.getText().toString().replace(",", ".")) == 0)
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
				for (TransProdDetalle oTpd : ((TransProd) transProd).TransProdDetalle)
				{
					BDVend.recuperar(oTpd, TPDImpuesto.class);
				}
			}
			catch (Exception e)
			{
				e.printStackTrace();
			}

			promociones = new Promociones2((TransProd) transProd, (Vista) this, modificando);

            promociones.setOnTerminarAplicacionListener(new onTerminarAplicacionListener()
            {
                @Override
                public void onTerminarAplicacion()
                {

                    if (docsTransProd.hasNext())
                    {
                        calcularPromociones(docsTransProd.next());
                    }
                    else
                    {
                        //validar reparto aqui?  *********** no validar inv para msiev
                        if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && mPresenta.getTipoTransProd() != 21 && surtir && reparto ){
                            //validar inventario despues de calcular las promociones, se validan tambien los productos promocionales
							try {
								if (manejoDobleUnidad) {
									prodSinExistencia = mPresenta.validarInventarioASurtirDobleUnidad();
								}else{
									prodSinExistencia = mPresenta.validarInventarioASurtir();
								}
							}catch(Exception ex){
								mostrarError("Error al validar inventario");
								return;
							}
                            if(prodSinExistencia.size() != 0){
                                boolean soloPromo = true;
                                String productosNoPromo = "";
                                String productosPromo = "";
                                String productosCanje = "";

                                for(TransProdDetalle oTpd : prodSinExistencia){
                                    //Los productos tipo Canje no se ajustan, solo modificando el pedido, ya que hay recalculo
                                    if(oTpd.Promocion != 2  && oTpd.Promocion != 3){
                                        productosNoPromo += oTpd.ProductoClave + ", ";
                                        soloPromo = false;
                                    }else if(oTpd.Promocion == 2){
                                        productosPromo += oTpd.ProductoClave + ", ";
                                    }else if(oTpd.Promocion == 3) {
                                        productosCanje += oTpd.ProductoClave + ", ";
                                    }
                                }
                                if(productosNoPromo != ""){
                                    productosNoPromo = productosNoPromo.substring(0, productosNoPromo.length() - 2);
                                }
                                if(productosPromo != "" && soloPromo){
                                    productosPromo = productosPromo.substring(0, productosPromo.length() - 2);
                                }
                                if(productosCanje != "" && soloPromo){
                                    productosCanje = productosCanje.substring(0, productosCanje.length() - 2);
                                }
                                if(productosNoPromo != ""){
                                    mostrarAdvertencia(Mensajes.get("E0714").replace("$0$", productosNoPromo));
                                    return;
                                }else if(productosCanje!=""){
                                    mostrarAdvertencia(Mensajes.get("E0714").replace("$0$", " tipo Canje " + productosCanje ));
                                    return;
                                }else if(productosPromo != ""){
                                    mostrarPreguntaSiNo(Mensajes.get("P0209", productosPromo), 50);
                                    return;
                                }
                            }
                        }

                        //Lo que estaba del cuadre de envase se manda a un método separado
                        //para poder llamarlo en la respuesta afirmativa del mensaje P0209
                        if(Consultas.ConsultasPromocion.validarProntoPagoAplicadas(mPresenta.getTransProdIds()))
                            mostrarMensaje(Mensajes.get("I0311"),0,100);
                        else
                            cuadreEnvases();
                    }
                }
            });

            if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && mPresenta.getTipoTransProd() != 21 && surtir && !modificando){
                //Se recorre hasta el final para que no se aplique ninguna promocion
                while (docsTransProd.hasNext()){
                    docsTransProd.next();
                }
                promociones.TerminarAplicacionSinCalculos();
                return;
            }

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

			promociones.Aplicar();

		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}

	}
	
	@SuppressWarnings("rawtypes")
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
        oParametros.put("ModificandoAutoventa", Boolean.toString(modificandoAutoventa));
		if (mPresenta.getProdSinExistencia()!= null) {
			HashMap<String, Float> hsProdSinExistencia = new HashMap<>();
			Iterator itProd = mPresenta.getProdSinExistencia().iterator();
			while (itProd.hasNext())
			{
				TransProdDetalle tpdSE = (TransProdDetalle)itProd.next();
				hsProdSinExistencia.put(tpdSE.TransProdDetalleID, tpdSE.CantidadInventario);
			}
			oParametros.put("ProdSinExistencia", hsProdSinExistencia);
		}

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

    private void LlenarColorTiposProducto(){
        try {
            htColores = new HashMap<>();
            for (ValorReferencia valor : ValoresReferencia.getValores("PROTIPO")) {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ColorearTipoProducto", valor.getVavclave())) {
                    String color = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ColorearTipoProducto", valor.getVavclave().toString()).toString();
                    htColores.put(valor.getVavclave(), color);
                }
            }
        }catch (Exception e){

        }
    }

	@SuppressWarnings("deprecation")
	public void refrescarProductos(String TransProdId)
	{
		try
		{

			// limpiarProducto();
			// ocultarTeclado();
			if (manejoDobleUnidad){
				refrescarProductosDobleUnidad(TransProdId);
				return;
			}

			if (inventarioPorLotes){
				refrescarProductosLote(TransProdId);
				return;
			}

            boolean existe = false;
            if (lista.getAdapter() != null){
                stopManagingCursor(((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())));
                ((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())).close();
                existe = true;
            }
		    ISetDatos stTransProdDetalle = Consultas.ConsultasTransProdDetalle.obtenerDetalle(TransProdId);

			Cursor cProductos = (Cursor) stTransProdDetalle.getOriginal();
			startManagingCursor(cProductos);
			try
			{
				obtenerTotales(TransProdId);
				String [] columnas;
				int [] campos;
				boolean parametroActivado = false;

				if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("MostrarLPreciosListView")) {
					if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("MostrarLPreciosListView").equalsIgnoreCase("1")) {
						parametroActivado = true;
					}
				}

				if(parametroActivado)
				{
					columnas = new String[]{ "TipoUnidad", "ProductoClave", "Descripcion", "Precio", "Cantidad", "Total", "Existencia", "CantidadOriginal","Nombre"};
					campos =  new int[]{ R.id.lblUnidadProductoClave, R.id.lblUnidadProductoClave, R.id.lblDescripcion, R.id.lblPU, R.id.lblCantidad, R.id.lblTotal, R.id.lblExistencia, R.id.lblCantidadOriginal, R.id.lblListaPrecioNombre };
				}
				else
				{
					columnas = new String[]{ "TipoUnidad", "ProductoClave", "Descripcion", "Precio", "Cantidad", "Total", "Existencia", "CantidadOriginal"};
					campos =  new int[]{ R.id.lblUnidadProductoClave, R.id.lblUnidadProductoClave, R.id.lblDescripcion, R.id.lblPU, R.id.lblCantidad, R.id.lblTotal, R.id.lblExistencia, R.id.lblCantidadOriginal};
				}

                LlenarColorTiposProducto();

				SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.elemento_captura_producto, cProductos, columnas ,campos);
				adapter.setViewBinder(new vista());
				lista.setAdapter(adapter);

				lista.setOnItemClickListener(new OnItemClickListener()
				{

					public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
					{
						captura.setEnableCantidadAgregar(true);
						
						if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")) && (mPresenta.getTipoFase() == 0 || mPresenta.getTipoFase() == 2) && calculando)
						{
							// si recibio el transprodid como parametro y esta
							// cancelado o surtido, mostrar cantidad de solo
							// lectura
							return;
						}
						// calculando = true;
						Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
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


                stopManagingCursor(cProductos);
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

	public void refrescarProductosLote(String TransProdId)
	{
		try
		{

			boolean existe = false;
			if (lista.getAdapter() != null){
				stopManagingCursor(((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())));
				((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())).close();
				existe = true;
			}
			ISetDatos stTransProdDetalle = Consultas.ConsultasTransProdDetalle.obtenerDetalleLotes(TransProdId);

			Cursor cProductos = (Cursor) stTransProdDetalle.getOriginal();
			startManagingCursor(cProductos);
			try
			{
				obtenerTotales(TransProdId);
				String [] columnas;
				int [] campos;
				boolean parametroActivado = false;

				if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("MostrarLPreciosListView")) {
					if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("MostrarLPreciosListView").equalsIgnoreCase("1")) {
						parametroActivado = true;
					}
				}

				if(parametroActivado)
				{
					columnas = new String[]{ "TipoUnidad", "ProductoClave", "Descripcion", "Precio", "Cantidad", "Total", "Existencia", "Nombre", "Lote", "Caducidad"};
					campos =  new int[]{ R.id.lblUnidadProductoClave, R.id.lblUnidadProductoClave, R.id.lblDescripcion, R.id.lblPU, R.id.lblCantidad, R.id.lblTotal, R.id.lblExistencia, R.id.lblListaPrecioNombre, R.id.lblLote, R.id.lblCaducidad };
				}
				else
				{
					columnas = new String[]{ "TipoUnidad", "ProductoClave", "Descripcion", "Precio", "Cantidad", "Total", "Existencia", "Lote", "Caducidad"};
					campos =  new int[]{ R.id.lblUnidadProductoClave, R.id.lblUnidadProductoClave, R.id.lblDescripcion, R.id.lblPU, R.id.lblCantidad, R.id.lblTotal, R.id.lblExistencia, R.id.lblLote, R.id.lblCaducidad};
				}

				LlenarColorTiposProducto();

				SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.elemento_captura_producto_lote, cProductos, columnas ,campos);
				adapter.setViewBinder(new vista());
				lista.setAdapter(adapter);

				lista.setOnItemClickListener(new OnItemClickListener()
											 {

												 public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
												 {
													 captura.setEnableCantidadAgregar(true);

													 if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")) && (mPresenta.getTipoFase() == 0 || mPresenta.getTipoFase() == 2) && calculando)
													 {
														 // si recibio el transprodid como parametro y esta
														 // cancelado o surtido, mostrar cantidad de solo
														 // lectura
														 return;
													 }
													 // calculando = true;
													 Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
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


				stopManagingCursor(cProductos);
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

	@SuppressWarnings("deprecation")
	public void refrescarProductosDobleUnidad(String TransProdIds)
	{
		try
		{

			// limpiarProducto();
			// ocultarTeclado();
			boolean existe = false;
			if (lista.getAdapter() != null){
				stopManagingCursor(((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())));
				((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())).close();
				existe = true;
			}
			ISetDatos stTransProdDetalle = Consultas.ConsultasTransProdDetalle.obtenerDetalleDobleUnidad(TransProdIds);

			Cursor cProductos = (Cursor) stTransProdDetalle.getOriginal();
			startManagingCursor(cProductos);
			try
			{
				obtenerTotales(TransProdIds);
				SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.elemento_captura_prod_doble_unidad, cProductos, new String[]
						{ "TipoUnidad", "Cantidad","UnidadAlterna","CantidadAlterna","ProductoClave", "Precio", "Total"}, new int[]
						{ R.id.lblUnidad1, R.id.lblCantidad1, R.id.lblUnidad2, R.id.lblCantidad2, R.id.lblProducto,R.id.lblPU, R.id.lblTotal});
				adapter.setViewBinder(new vistaDobleUnidad());
				lista.setAdapter(adapter);

				lista.setOnItemClickListener(new OnItemClickListener()
											 {

												 public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
												 {
													 captura.setEnableCantidadAgregar(true);

													 if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")) && (mPresenta.getTipoFase() == 0 || mPresenta.getTipoFase() == 2) && calculando)
													 {
														 // si recibio el transprodid como parametro y esta
														 // cancelado o surtido, mostrar cantidad de solo
														 // lectura
														 return;
													 }
													 // calculando = true;
													 Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
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
													 HashMap<Short,Float> hmUnidades = new HashMap<Short,Float>();
													 hmUnidades.put(producto.getShort(producto.getColumnIndex("TipoUnidad")), producto.getFloat(producto.getColumnIndex("Cantidad")));
													 if(producto.getShort(producto.getColumnIndex("UnidadAlterna"))>0  ){
														 hmUnidades.put(producto.getShort(producto.getColumnIndex("UnidadAlterna")), producto.getFloat(producto.getColumnIndex("CantidadAlterna")));
													 }
													 captura.llenarProductoDobleUnidad(oProducto,hmUnidades);
												 }
											 }
				);


				stopManagingCursor(cProductos);
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
                texto.setText(Generales.getFormatoDecimal(setDatos.getFloat(1), "$ #,##0.00"));

				texto = (TextView) findViewById(R.id.txtTotalProductos);
				texto.setText(String.format("%.0f", setDatos.getFloat(0)));

				texto = (TextView) findViewById(R.id.txtTotalUnidades);
				texto.setText(String.format("%.2f", setDatos.getFloat("Unidades")));
				
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
        menu.getItem(5).setTitle(Mensajes.get("XSaldoEnvases"));
        menu.getItem(6).setTitle(Mensajes.get("XTomaInventario"));
		menu.getItem(7).setTitle(Mensajes.get("XStock"));
		menu.getItem(8).setTitle(Mensajes.get("XConvertirEnConsigna"));

		//if(!(((Ruta) Sesion.get(Campo.RutaActual)).Inventario && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)){
		menu.getItem(1).setVisible(false);
		//}
		
		menu.getItem(2).setVisible(false);
        menu.getItem(5).setVisible(false);
        menu.getItem(6).setVisible(false);
		menu.getItem(7).setVisible(false);
		menu.getItem(8).setVisible(false);
		convertir = menu.getItem(8);

		if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && mPresenta.getTipoFase() == TiposFasesDocto.CAPTURA && mPresenta.getTipoTransProd() == TiposTransProd.PEDIDO && reparto && surtir){// || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && surtir)){
			if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ModificarVenta").toString().equals("1"))
				menu.getItem(2).setVisible(true);
			try {
				if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ConvertirPedCompEnConsigna") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ConvertirPedCompEnConsigna").equals("1"))
					menu.getItem(8).setVisible(true);
			}catch (Exception e){}
		}
		
		MOTConfiguracion motConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
		if(motConf.get("MostrarUltVta").equals("0")){
			menu.getItem(3).setVisible(false);
		}
		
		if(!Consultas.ConsultasClienteVentaMensual.existeInformacion(
				((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave)){
			menu.getItem(4).setVisible(false);
		}

        if ( (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) && mPresenta.getTipoTransProd() == TiposTransProd.PEDIDO && ((Cliente)Sesion.get(Campo.ClienteActual)).Prestamo ) {
            menu.getItem(5).setVisible(true);
        }
        try {
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("TomaInventario") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("TomaInventario").equals("1")) {
                menu.getItem(6).setVisible(true);
            }
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("MostrarStockPedido") && (Integer.parseInt(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("MostrarStockPedido")) > 0)) {
				menu.getItem(7).setVisible(true);
			}
        }catch(Exception ex){
            mostrarError("Error al recuperar");
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
				//modificar pedido de reparto
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
            case R.id.saldoEnvase:
                mostrarSaldoEnvase();
                return true;
            case R.id.tomaInventario:
                if (hayProductos()){
                    mostrarError(Mensajes.get("I0297"));
                }else {
                    HashMap<String, Object> oParametros = new HashMap<String, Object>();
                    oParametros.put("ListasPrecio", mPresenta.getListasPrecios());
                    oParametros.put("TipoValidarExistencia", mPresenta.getTipoValidacionExistencia());
                    if (inventarioID!= null && !inventarioID.equals("")) {
                        oParametros.put("InventarioID", inventarioID);
                    }
                    iniciarActividadConResultado(ICapturaInventario.class, Solicitudes.SOLICITUD_TOMAR_INVENTARIO_PEDIDO, Acciones.ACCION_TOMAR_INVENTARIO_PEDIDO, oParametros);
                }
                return true;
			case R.id.stock:
				mostrarStock();
				return true;
			case R.id.convertir:
				mostrarPreguntaSiNo(Mensajes.get("P0243").replace("$0$", "XConvertirPedidoCompleto"), 70);
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

    public boolean getSoloLectura(){
        return this.soloLectura;
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
            String sColor = "";
            if (htColores.containsKey(cursor.getString(cursor.getColumnIndex("TipoProducto")))){
                sColor = htColores.get(cursor.getString(cursor.getColumnIndex("TipoProducto")));
            }
            if (sColor == "")
                sColor = "#CC0000";

			switch (viewId)
			{
				case android.R.id.text1: // para llenar el combo
					TextView combo = (TextView) view;
					combo.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("PRUTipoUnidad"))));

					break;
				case R.id.lblUnidadProductoClave:
					TextView unidadproducto = (TextView) view;
                    if (sColor != "")
                        unidadproducto.setTextColor(Color.parseColor(sColor));

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
                    if (sColor != "")
                        cantidad.setTextColor(Color.parseColor(sColor));

					cantidad.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), cursor.getInt(cursor.getColumnIndex("DecimalProducto"))));

					break;
				case R.id.lblDescripcion:
					TextView lblDescripcion = (TextView) view;
                    if (sColor != "")
                        lblDescripcion.setTextColor(Color.parseColor(sColor));
					lblDescripcion.setText(cursor.getString(columnIndex));
					break;
				case R.id.lblLote:
					TextView lblLote = (TextView) view;
					lblLote.setText(cursor.getString(columnIndex));
					break;
				case R.id.lblCaducidad:
					TextView lblCaducidad = (TextView) view;
					String fecha = cursor.getString(columnIndex);
					fecha = fecha.substring(0, 6) + fecha.substring(8, 10);
					lblCaducidad.setText(fecha);
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}

	private class vistaDobleUnidad implements ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();

			switch (viewId)
			{
				/*case android.R.id.text1: // para llenar el combo
					TextView combo = (TextView) view;
					combo.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("PRUTipoUnidad"))));

					break;*/
				case R.id.lblUnidad1:
					TextView unidadproducto1 = (TextView) view;
					unidadproducto1.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("TipoUnidad"))));
					break;
				case R.id.lblUnidad2:
					TextView unidadproducto2 = (TextView) view;
					if (cursor.getString(cursor.getColumnIndex("UnidadAlterna")) != null) {
						unidadproducto2.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("UnidadAlterna"))));
					}else{
						unidadproducto2.setText("");
					}
					break;
				case R.id.lblPU:
				case R.id.lblTotal:
					TextView total = (TextView) view;
					total.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), "$ #,##0.00"));
					break;
				case R.id.lblCantidad1:
					TextView cantidad1 = (TextView) view;
					cantidad1.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), cursor.getInt(cursor.getColumnIndex("DecimalProd1"))));

					break;
				case R.id.lblCantidad2:
					TextView cantidad2 = (TextView) view;
					if ( cursor.getFloat(columnIndex)>0) {
						cantidad2.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), cursor.getInt(cursor.getColumnIndex("DecimalProd2"))));
					}else{
						cantidad2.setText("");
					}
					break;
				case R.id.lblProducto:
                    String sColor = "";
					//Revisar esta parte, de momento se comentara.
//                    if (htColores.containsKey(cursor.getString(cursor.getColumnIndex("TipoProducto")))){
//                        sColor = htColores.get(cursor.getString(cursor.getColumnIndex("TipoProducto")));
//                    }
                    if (sColor == "")
                        sColor = "#CC0000";

					TextView producto = (TextView) view;
                    if (sColor != "")
                        producto.setTextColor(Color.parseColor(sColor));
					producto.setText(cursor.getString(columnIndex) + " - " + cursor.getString(cursor.getColumnIndex("Descripcion")));
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}

    private class vistaListasPrecios implements ViewBinder
    {

        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex)
        {
            int viewId = view.getId();
            switch (viewId)
            {
                case R.id.txtCol2:
                    TextView total = (TextView) view;
                    total.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), "$ #,##0.00"));
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
				((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave);
		getFragmentManager().beginTransaction().
			setCustomAnimations(android.R.animator.fade_in, android.R.animator.fade_out).
			add(R.id.layout_captura_pedido, vm, FRAGMENT_TAG).commit();
	}

    private void mostrarSaldoEnvase() {
		try{
			LayoutInflater inflater = (LayoutInflater) CapturaPedido.this.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			View dialogView = inflater.inflate(R.layout.dialog_saldoenvase, null);
			AlertDialog.Builder builder = new AlertDialog.Builder(this);

			TextView lbl = (TextView) dialogView.findViewById(R.id.lblTituloDialogoSaldoEnvase);
			lbl.setText(Mensajes.get("XSaldoEnvases"));

			lbl = (TextView) dialogView.findViewById(R.id.lblClave);
			lbl.setText(Mensajes.get("XClave"));

			lbl = (TextView) dialogView.findViewById(R.id.lblCargo);
			lbl.setText(Mensajes.get("XCargo"));

			lbl = (TextView) dialogView.findViewById(R.id.lblAbono);
			lbl.setText(Mensajes.get("XAbono"));

			lbl = (TextView) dialogView.findViewById(R.id.lblVenta);
			lbl.setText(Mensajes.get("XVenta"));

			lbl = (TextView) dialogView.findViewById(R.id.lblSaldo);
			lbl.setText(Mensajes.get("XSaldo"));

			ListView modeList = (ListView) dialogView.findViewById(R.id.lstSaldoEnvase);
			modeList.setBackgroundColor(Color.WHITE);

			Cursor cursor = mPresenta.obtenerSaldoEnvase();
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(this,R.layout.lista_simple_hor5,cursor,
					new String[]{"ProductoClave","Cargo","Abono","Venta","Saldo"},
					new int[]{R.id.txtCol1,R.id.txtCol2,R.id.txtCol3,R.id.txtCol4,R.id.txtCol5});

			modeList.setAdapter(adapter);

			builder.setPositiveButton("Aceptar", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface dialog, int id) {
					dialog.dismiss();
				}
			});
			builder.setView(dialogView);
			final Dialog dialog = builder.create();
			dialog.show();
		}catch(Exception e){
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
    }

    private void cuadreEnvases(){
        Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
        boolean iniciarTotales = true; //bandera para iniciar la captura de totales
        MOTConfiguracion oMC = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
        if(( (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && !surtir && !reparto) || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA)
                //&& mPresenta.getTipoTransProd() == 1 && oCliente.Prestamo && oCliente.LimiteEnvase == 0 ){
                && mPresenta.getTipoTransProd() == TiposTransProd.PEDIDO && oMC.get("CuadreDeEnvase").toString().equals("1") && oCliente.Prestamo ){
            //TODO sperez CUROLMOV18 Anexo 3 punto 1.1: cuadre de envase
            try
            {
                String transprodIds = mPresenta.getTransProdIds();
                envasesPorRecolectar = Consultas.ConsultasTransProd.obtenerDiferenciaEnvase(transprodIds);
                String sProductos = "";
                while(envasesPorRecolectar.moveToNext()){
                    float dif = envasesPorRecolectar.getFloat("Diferencia");
                    int decimales = envasesPorRecolectar.getInt("DecimalProducto");
                    if(dif > 0){
                        sProductos += envasesPorRecolectar.getString("ProductoDetClave") + " (" + String.format("%."+decimales+"f",dif) + "), ";
                    }
                }
                if(sProductos.length() > 0){
                    sProductos = sProductos.substring(0,sProductos.length()-2);
                    mostrarPreguntaSiNo(Mensajes.get("P0242").replace("$0$", sProductos), 40);
                    iniciarTotales = false; //no iniciar totales para poder mostrar y contestar la pregunta
                }

            }catch (Exception e){
                e.printStackTrace();
            }
        }

        if(iniciarTotales){
            iniciarCapturaTotales();
        }

    }

	private void mostrarStock(){
		try{
			int cantDias = 0;
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("MostrarStockPedido"))
				cantDias = Integer.parseInt(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("MostrarStockPedido"));


			LayoutInflater inflater = (LayoutInflater) CapturaPedido.this.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			View dialogView = inflater.inflate(R.layout.dialog_stock, null);
			AlertDialog.Builder builder = new AlertDialog.Builder(this);

			TextView lbl = (TextView) dialogView.findViewById(R.id.lblTituloDialogoStock);
			lbl.setText(Mensajes.get("XStock"));

			lbl = (TextView) dialogView.findViewById(R.id.lblClave);
			lbl.setText(Mensajes.get("XClave"));

			lbl = (TextView) dialogView.findViewById(R.id.lblDescripcion);
			lbl.setText(Mensajes.get("XDescripcion"));

			lbl = (TextView) dialogView.findViewById(R.id.lblUnidad);
			lbl.setText(Mensajes.get("XUnidad"));

			lbl = (TextView) dialogView.findViewById(R.id.lblCantidad1);
			lbl.setText("C1");

			switch (cantDias){
				case 5:
					lbl = (TextView) dialogView.findViewById(R.id.lblCantidad5);
					lbl.setText("C5");
					lbl.setVisibility(View.VISIBLE);
				case 4:
					lbl = (TextView) dialogView.findViewById(R.id.lblCantidad4);
					lbl.setText("C4");
					lbl.setVisibility(View.VISIBLE);
				case 3:
					lbl = (TextView) dialogView.findViewById(R.id.lblCantidad3);
					lbl.setText("C3");
					lbl.setVisibility(View.VISIBLE);
				case 2:
					lbl = (TextView) dialogView.findViewById(R.id.lblCantidad2);
					lbl.setText("C2");
					lbl.setVisibility(View.VISIBLE);
			}

			ListView modeList = (ListView) dialogView.findViewById(R.id.lstStock);
			modeList.setBackgroundColor(Color.WHITE);

			String ultimaVenta = Consultas.ConsultasStock.obtenerUltimaVisita(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave, false);
			String ultimoMSIEV = Consultas.ConsultasStock.obtenerUltimaVisita(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave, true);

			ISetDatos datos = null;
			try
			{
				datos = Consultas.ConsultasStock.obtenerDetalleStock(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave);
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}

			if(datos != null ){

				ArrayList<ListaStock> obtenerItem = obtenerItems(datos, cantDias);
				StockAdapter adapter = new StockAdapter(this, obtenerItem, cantDias);
				modeList.setAdapter(adapter);
			}

			builder.setPositiveButton("Aceptar", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface dialog, int id) {
					dialog.dismiss();
				}
			});
			builder.setView(dialogView);
			final Dialog dialog = builder.create();
			dialog.show();

		}catch(Exception e) {
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}

	private ArrayList<ListaStock> obtenerItems(ISetDatos datos, int cantDias){
		ArrayList<ListaStock> items = new ArrayList<ListaStock>();
		String Visita = "";
		int vuelta = 0;

		while(datos.moveToNext()){
			if(!Visita.equals(datos.getString("VisitaClave"))){
				Visita = datos.getString("VisitaClave");
				vuelta ++;
			}
			if(vuelta > cantDias){
				break;
			}
			if(vuelta ==1) {
				String claveProducto = datos.getString("_id");
				String nombre = datos.getString("Nombre");
				String unidad = ValoresReferencia.getDescripcion("UNIDADV", datos.getString("TipoUnidad"));
				double cantidad = datos.getDouble("Cantidad");
				items.add(new ListaStock(claveProducto, nombre, unidad, cantidad, 0, 0, 0, 0));
			}
			if(vuelta > 1) {
				String claveProducto = datos.getString("_id");
				String nombre = datos.getString("Nombre");
				String unidad = ValoresReferencia.getDescripcion("UNIDADV", datos.getString("TipoUnidad"));
				double cantidad = datos.getDouble("Cantidad");
				boolean lock = false;
				for(int i=0; i<items.size(); i++) {
					if((items.get(i).claveProducto).equals(claveProducto)) {
						lock = true;
						if(vuelta == 2) {
							items.get(i).cantidad2 = cantidad;
						}
						if(vuelta == 3) {
							items.get(i).cantidad3 = cantidad;
						}
						if(vuelta == 4) {
							items.get(i).cantidad4 = cantidad;
						}
						if(vuelta == 5) {
							items.get(i).cantidad5 = cantidad;
						}
						break;
					}
				}
				if(lock == false) {
					if(vuelta == 2) {
						items.add(new ListaStock(claveProducto, nombre, unidad, 0, cantidad, 0, 0, 0));
					}
					if(vuelta == 3) {
						items.add(new ListaStock(claveProducto, nombre, unidad, 0, 0, cantidad, 0, 0));
					}
					if(vuelta == 4) {
						items.add(new ListaStock(claveProducto, nombre, unidad, 0, 0, 0, cantidad, 0));
					}
					if(vuelta == 5) {
						items.add(new ListaStock(claveProducto, nombre, unidad, 0, 0, 0, 0, cantidad));
					}
				}
			}
		}
		return items;
	}

	public static class ListaStock{
		public String claveProducto;
		public String nombre;
		public String unidad;
		public double cantidad1;
		public double cantidad2;
		public double cantidad3;
		public double cantidad4;
		public double cantidad5;

		public ListaStock(String claveProducto, String nombre, String unidad, double cantidad1, double cantidad2, double cantidad3, double cantidad4, double cantidad5) {
			this.claveProducto = claveProducto;
			this.nombre= nombre;
			this.unidad = unidad;
			this.cantidad1 = cantidad1;
			this.cantidad2 = cantidad2;
			this.cantidad3 = cantidad3;
			this.cantidad4 = cantidad4;
			this.cantidad5 = cantidad5;

		}

		public String getClaveProducto(){
			return claveProducto;
		}

		public void setClaveProducto(String claveProducto){
			this.claveProducto = claveProducto;
		}

		public String getNombre(){
			return nombre;
		}

		public void setNombre(String descripcion){
			this.nombre = descripcion;
		}

		public String getUnidad(){
			return unidad;
		}

		public void setUnidad(String unidad){
			this.unidad = unidad;
		}

		public String getCantidad1(){
			return Generales.getFormatoDecimal(cantidad1, 0);
		}

		public void setCantidad1(int cantidad1){
			this.cantidad1 = cantidad1;
		}

		public String getCantidad2(){
			return Generales.getFormatoDecimal(cantidad2, 0);
		}

		public void setCantidad2(int cantidad2){
			this.cantidad2 = cantidad2;
		}

		public String getCantidad3(){
			return Generales.getFormatoDecimal(cantidad3, 0);
		}

		public void setCantidad3(int cantidad3){
			this.cantidad3 = cantidad3;
		}

		public String getCantidad4(){
			return Generales.getFormatoDecimal(cantidad4, 0);
		}

		public void setCantidad4(int cantidad4){
			this.cantidad4 = cantidad4;
		}

		public String getCantidad5(){
			return Generales.getFormatoDecimal(cantidad5, 0);
		}

		public void setCantidad5(int cantidad5){
			this.cantidad5 = cantidad5;
		}

	}

	private CapturaProducto.onAgregarProductoListener mAgregarProductoListener = new CapturaProducto.onAgregarProductoListener() {
		@Override
		public void onAgregarProducto (Producto producto,int tipoUnidad, float cantidad)
		{
			try
			{
                producto.obtenerExcepcionSubEmpresaID(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
				Object aTransProdDetalle[] = Consultas.ConsultasTransProdDetalle.obtenerDetallePorProductoClaveUnidad(producto.ProductoClave, String.valueOf(tipoUnidad), mPresenta.getTransaccionesIds());

				MOTConfiguracion motConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
				//validacion NoAdicionProducto
				if(mPresenta.getTipoPedido() == Enumeradores.TipoPedido.BACKORDER || (modificando == true && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) && motConf.get("NoAdicionProducto").toString().equals("1"))){
					if(aTransProdDetalle == null){
						//no existe en el pedido, no se puede agregar
						mostrarAdvertencia(Mensajes.get("E0908"));
						return;
					}

					//si existe, validar cantidades
					float valorOriginal = Float.parseFloat(aTransProdDetalle[4].toString());
					float valorActual = cantidad;
					if(valorOriginal < valorActual){
						captura.setEnableCantidadAgregar(false);
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
                            float cantValidar = cantidad;
                            boolean bValidar = true;

                            if (producto.Contenido && producto.Venta)
                            {
                                float SaldoPrestamoIni = mPresenta.obtenerSaldoDeEnvase(producto.ProductoClave);
                                if (SaldoPrestamoIni < 0)
                                    SaldoPrestamoIni = 0;

                                if (SaldoPrestamoIni < cantidad)
                                    cantValidar -= SaldoPrestamoIni;
                                else
                                    bValidar = false;
                            }

                            if (bValidar) {
                                if (!Inventario.ValidarExistencia(producto.ProductoClave, tipoUnidad, cantValidar, Float.parseFloat(aTransProdDetalle[2].toString()), mPresenta.getModuloMovDetalle(), false, existencia, error)) {
                                    captura.setError(error.toString());
                                    if (mPresenta.getTipoValidacionExistencia() == TiposValidacionInventario.ValidacionRestrictiva) {
                                        if (!validarVenderApartado(producto, Short.parseShort(String.valueOf(tipoUnidad)), cantValidar, Float.parseFloat(aTransProdDetalle[2].toString()), aTransProdDetalle[0].toString(), aTransProdDetalle[1].toString()))
                                            return;
                                        if (existencia.get() != null && existencia.get() > 0) {
                                            captura.setCantidad(Float.parseFloat(aTransProdDetalle[2].toString()) + existencia.get());
                                        } else {
                                            captura.setCantidad(cantidad);
                                        }
                                        return;
                                    }
                                } else {
                                    captura.setAdvertencia(error.toString());
                                }
                            }
						}

						if(!mPresenta.validarCantMax(cantidad)){
							//no esta configurada ninguna cantidad, continuar normal
							int nPartida = 0;
							float nCantOrigReparto = 0;
							try {
								if (mPresenta.getTipoPedido() == Enumeradores.TipoPedido.BACKORDER || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO)) {
									nPartida = Consultas.ConsultasTransProdDetalle.obtenerPartida(aTransProdDetalle[0].toString(), aTransProdDetalle[1].toString());
									nCantOrigReparto = Consultas.ConsultasTransProdDetalle.obtenerCantidadOriginal(aTransProdDetalle[0].toString(), aTransProdDetalle[1].toString());
								}
							}catch(Exception e){}

							mPresenta.eliminarDetalle(aTransProdDetalle[0].toString(), aTransProdDetalle[1].toString(), producto.SubEmpresaId, producto.ProductoClave, tipoUnidad, Float.parseFloat(aTransProdDetalle[2].toString()), false);
							if(mPresenta.getTipoPedido() == Enumeradores.TipoPedido.BACKORDER ||(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO))
								mPresenta.agregarProductoUnidad(producto.ProductoClave, producto.SubEmpresaId, tipoUnidad, cantidad, Float.parseFloat("-1"),nCantOrigReparto, aTransProdDetalle[1].toString(), nPartida);
							else
								mPresenta.agregarProductoUnidad(producto.ProductoClave, producto.SubEmpresaId, tipoUnidad, cantidad, Float.parseFloat("-1"), aTransProdDetalle[1].toString());
						}else{
							//guardar la info en las varibles para poder agregar el producto si contesta que si a la pregunta
							productoAgregar = producto;
							tipoUnidadAgregar = Short.parseShort(String.valueOf(tipoUnidad)) ;
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
                        float cantValidar = cantidad;
                        boolean bValidar = true;

                        if (producto.Contenido && producto.Venta)
                        {
                            float SaldoPrestamoIni = mPresenta.obtenerSaldoDeEnvase(producto.ProductoClave);
                            if (SaldoPrestamoIni < 0)
                                SaldoPrestamoIni = 0;

                            if (SaldoPrestamoIni < cantidad)
                                cantValidar -= SaldoPrestamoIni;
                            else
                                bValidar = false;
                        }

                        if (bValidar) {
                            if (!Inventario.ValidarExistencia(producto.ProductoClave, tipoUnidad, cantValidar, mPresenta.getModuloMovDetalle(), existencia, error)) {
                                captura.setError(error.toString());
                                if (mPresenta.getTipoValidacionExistencia() == TiposValidacionInventario.ValidacionRestrictiva) {
                                    if (!validarVenderApartado(producto, tipoUnidad, cantValidar))
                                        return;
                                    if (existencia.get() != null && existencia.get() > 0) {
                                        captura.setCantidad(existencia.get());
                                    } else {
                                        captura.setCantidad(Float.valueOf(0));
                                    }
                                    return;
                                }
                            } else {
                                captura.setAdvertencia(error.toString());
                            }
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
	};

	private CapturaProducto.onAgregarProdDobleUnidadListener mAgregarProdDobleUnidadListener = new CapturaProducto.onAgregarProdDobleUnidadListener(){
		@Override
		public void onAgregarProdDobleUnidad(Producto producto, HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades) {
			try
			{
                producto.obtenerExcepcionSubEmpresaID(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
				TransProdDetalle oTPD = Consultas.ConsultasTransProdDetalle.obtenerTPDDobleUnidadPorProducto(producto.ProductoClave, mPresenta.getTransaccionesIds());

				//Verificar inventario
				if (oTPD != null)
				{ // si ya existe, seleccionarlo de la lista E0714

					HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmCantidadesOrig = new HashMap<Short,InventarioDobleUnidad.DetalleProductoDobleUnidad>();
					hmCantidadesOrig.put(Short.parseShort(String.valueOf(oTPD.TipoUnidad)), new InventarioDobleUnidad.DetalleProductoDobleUnidad(Short.parseShort(String.valueOf(oTPD.TipoUnidad)),null,oTPD.Cantidad,null, null, hmDetalleUnidades.get(Short.parseShort(String.valueOf(oTPD.TipoUnidad))).DecimalProducto , null));
					if(oTPD.TPDDatosExtra.size() >0 && oTPD.TPDDatosExtra.get(0).UnidadAlterna != null && oTPD.TPDDatosExtra.get(0).UnidadAlterna>0){
						hmCantidadesOrig.put(oTPD.TPDDatosExtra.get(0).UnidadAlterna, new InventarioDobleUnidad.DetalleProductoDobleUnidad(oTPD.TPDDatosExtra.get(0).UnidadAlterna,null,oTPD.TPDDatosExtra.get(0).CantidadAlterna, null,null,hmDetalleUnidades.get(oTPD.TPDDatosExtra.get(0).UnidadAlterna).DecimalProducto,null ));
					}

					//Se guarda en el arreglo la cantidad original para tenerla de referencia al guardar el TransProdDetalle, cuando es reparto
					if (hmDetalleUnidades.containsKey(Short.parseShort(String.valueOf(oTPD.TipoUnidad)))){
						hmDetalleUnidades.get(Short.parseShort(String.valueOf(oTPD.TipoUnidad))).CantidadOriginal =  ((oTPD.CantidadOriginal != null && oTPD.CantidadOriginal>0 )? oTPD.CantidadOriginal : oTPD.Cantidad);
					}

					if (oTPD.TPDDatosExtra != null && oTPD.TPDDatosExtra.size() >0 && oTPD.TPDDatosExtra.get(0).UnidadAlterna != null &&  hmDetalleUnidades.containsKey(oTPD.TPDDatosExtra.get(0).UnidadAlterna)){
						hmDetalleUnidades.get(oTPD.TPDDatosExtra.get(0).UnidadAlterna).CantidadOriginal =  ((oTPD.TPDDatosExtra.get(0).CantidadAlternaOriginal != null && oTPD.TPDDatosExtra.get(0).CantidadAlternaOriginal >0 )? oTPD.TPDDatosExtra.get(0).CantidadAlternaOriginal : oTPD.TPDDatosExtra.get(0).CantidadAlterna);
					}

					boolean bCambioCantidad = false;
					boolean bTomarApartado = false;
					for(Short unidad : hmDetalleUnidades.keySet()){
						if (!hmCantidadesOrig.containsKey(unidad)){
							throw( new Exception("La unidad " + ValoresReferencia.getDescripcion("UNIDADV",unidad.toString()) + " no existe en el documento original"));
						}
						if (hmDetalleUnidades.get(unidad).Cantidad != hmCantidadesOrig.get(unidad).Cantidad){
							bCambioCantidad = true;
							AtomicReference<Float> existencia = new AtomicReference<Float>();
							StringBuilder error = new StringBuilder();
							if (mPresenta.getTipoValidacionExistencia() != TiposValidacionInventario.NoValidar)
							{
								if (!InventarioDobleUnidad.ValidarExistencia(producto.ProductoClave, unidad, hmDetalleUnidades.get(unidad).Cantidad, hmCantidadesOrig.get(unidad).Cantidad, mPresenta.getModuloMovDetalle(), false, existencia, error))
								{
									captura.setError(error.toString());
									if (mPresenta.getTipoValidacionExistencia() == TiposValidacionInventario.ValidacionRestrictiva)
									{
										if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
											/*if(((CONHist)Sesion.get(Campo.CONHist)).get("VenderApartado").toString().equals("0")){
												captura.setError(Mensajes.get("E0714").replace("$0$", producto.ProductoClave));
												return;
											}else */if(((CONHist)Sesion.get(Campo.CONHist)).get("VenderApartado").toString().equals("1")){
												AtomicReference<Float> existenciaApartado = new AtomicReference<Float>();
												StringBuilder errorApartado = new StringBuilder();
												if(!InventarioDobleUnidad.ValidarExistenciaDifNoDisponible(producto.ProductoClave, unidad, hmDetalleUnidades.get(unidad).Cantidad, existencia, error)){
													captura.setError(Mensajes.get("E0714").replace("$0$", producto.ProductoClave));
													return;
												}
												bTomarApartado=true;
												captura.setError("");
											}
										}
										if (existencia.get() != null && existencia.get() > 0)
										{
											captura.setCantidad( hmCantidadesOrig.get(unidad).Cantidad + existencia.get(), unidad);
										}
										else
										{
											//revisar esto en el escenario normal
											captura.setCantidad(hmDetalleUnidades.get(unidad).Cantidad, unidad);
										}
										if(!bTomarApartado)
											return;
									}
								}
								else
								{
									captura.setAdvertencia(error.toString());
								}
							}

						}
					}
					if(bCambioCantidad) {
						if (bTomarApartado){
							mostrarPreguntaSiNo(Mensajes.get("P0087"), 10);
							hmDetalleDobleUnidadAgregar = hmDetalleUnidades;
							productoAgregar = producto;
							transprodIDEliminar = oTPD.TransProdID;
							transprodDetalleIDEliminar = oTPD.TransProdDetalleID;
							return;
						}
						mPresenta.eliminarDetalleDobleUnidad(oTPD.TransProdID, oTPD.TransProdDetalleID, producto.SubEmpresaId, producto.ProductoClave, hmCantidadesOrig, false);
						mPresenta.agregarProductoDobleUnidad(hmDetalleUnidades, producto.ProductoClave,  producto.SubEmpresaId, oTPD.TransProdDetalleID);
					}
				}
				else
				{
					boolean bTomarApartado = false;
					if (mPresenta.getTipoValidacionExistencia() != TiposValidacionInventario.NoValidar)
					{
						captura.setError("");
						for(Short unidad : hmDetalleUnidades.keySet()) {
							AtomicReference<Float> existencia = new AtomicReference<Float>();
							StringBuilder error = new StringBuilder();
							if (!InventarioDobleUnidad.ValidarExistencia(producto.ProductoClave, unidad, hmDetalleUnidades.get(unidad).Cantidad, mPresenta.getModuloMovDetalle(), existencia, error)) {
								captura.setError(error.toString());
								if (mPresenta.getTipoValidacionExistencia() == TiposValidacionInventario.ValidacionRestrictiva) {
									if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
										if(((CONHist)Sesion.get(Campo.CONHist)).get("VenderApartado").toString().equals("0")){
											captura.setError(Mensajes.get("E0714").replace("$0$", producto.ProductoClave));
											return;
										}else if(((CONHist)Sesion.get(Campo.CONHist)).get("VenderApartado").toString().equals("1")){
											AtomicReference<Float> existenciaApartado = new AtomicReference<Float>();
											StringBuilder errorApartado = new StringBuilder();
											if(!InventarioDobleUnidad.ValidarExistenciaDifNoDisponible(producto.ProductoClave, unidad, hmDetalleUnidades.get(unidad).Cantidad, existencia, error)){
												captura.setError(Mensajes.get("E0714").replace("$0$", producto.ProductoClave));
												return;
											}
											bTomarApartado=true;
											captura.setError("");
										}
									}
									if (existencia.get() != null && existencia.get() > 0) {
										captura.setCantidad(existencia.get(), unidad);
									} else {
										captura.setCantidad(Float.valueOf(0),unidad);
									}
									if(!bTomarApartado)
										return;
								}else{
									captura.setAdvertencia(error.toString());
								}
							} else {
								captura.setAdvertencia(error.toString());
							}
						}
					}
					if(bTomarApartado){

						mostrarPreguntaSiNo(Mensajes.get("P0087"), 10);
						hmDetalleDobleUnidadAgregar = hmDetalleUnidades;
						productoAgregar = producto;
						transprodIDEliminar = null;
						transprodDetalleIDEliminar = null;
						return;
					}
					mPresenta.agregarProductoDobleUnidad( hmDetalleUnidades, producto.ProductoClave, producto.SubEmpresaId,null);
				}
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}
		}

	};

	public void setMensajeLimiteCredito(boolean mostrandoMensaje, boolean error){
		mensajeValidaCredito = mostrandoMensaje;
		mensajeError = error;
	}

	public boolean getMensajeLimiteCredito(){
		return mensajeValidaCredito;
	}

	public void setMensajeLimiteEnvase(boolean mostrandoMensaje, boolean error){
		mensajeLimiteEnvase = mostrandoMensaje;
		mensajeError = error;
	}

	public boolean getMensajeLimiteEnvase(){
		return mensajeLimiteEnvase;
	}

	public void solicitarImprimirTicket(){
		MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
		if (motConfig.get("MensajeImpresion").equals("0"))
		{
			// si no esta configurada la pregunta salir
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}else if(motConfig.get("MensajeImpresion").equals("1")){
			mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
		}//else if (motConfig.get("MensajeImpresion").equals("2") || motConfig.get("MensajeImpresion").equals("3")){
			//EnvioPDF.enviarTicketPDF( CapturaPedido.this, Short.valueOf(motConfig.get("MensajeImpresion").toString()));
		//}
	}
}
