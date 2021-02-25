package com.amesol.routelite.vistas;

import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.ContentValues;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.os.Handler;
import android.support.v4.widget.SlidingPaneLayout.PanelSlideListener;
import android.text.Html;
import android.util.Log;
import android.view.ContextMenu;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.EditText;
import android.widget.FrameLayout;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.SpinnerAdapter;
import android.widget.TextView;
import android.widget.AdapterView.OnItemLongClickListener;
import android.widget.Toast;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.EnvioPDF;
import com.amesol.routelite.actividades.FoliosFiscales;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.FoliosFiscales.FoliosFiscalesException;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.CLIFormaVenta;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.ClientePago;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.FolioFiscal;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.SEMHist;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.ImprimirTicket;
import com.amesol.routelite.presentadores.act.SeleccionarFacturacion;
import com.amesol.routelite.presentadores.act.SeleccionarFacturacion.TransProdFactura;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;
import com.amesol.routelite.presentadores.interfaces.IRevisionPendientes;
import com.amesol.routelite.presentadores.interfaces.ISeleccionFacturacion;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.ConsignacionAdapter;
import com.amesol.routelite.vistas.generico.FacturacionAdapter;
import com.itextpdf.text.ExceptionConverter;
import com.itextpdf.text.pdf.PdfStructTreeController.returnType;


public class SeleccionFacturacion extends Vista implements ISeleccionFacturacion
{

	private SeleccionarFacturacion mPresentador;
	
	public static final int GENERALES_INDEX = 1;
	public static final int METODOS_PAGO_INDEX = 2;
	public static final int PEDIDOS_INDEX = 3;
	public static final int DATOS_FACTURACION_INDEX = 4;
	
	private static final int PREGUNTA_SALIR_SIN_GUARDAR = 0;
	private static final int IMPRESION = 1;
	private static final int PREGUNTAR_CANCELAR = 2;
    private static final int ENVIO_PDF = 3;
    private static final int PREGUNTAR_REINTENTAR_SMS = 4;
	private static final int IMPRESION_SOLO_TIMBRADO = 5;
	
	private int indiceActivo;
	
	private boolean existenFacturas;
	private boolean soloLectura;

	private boolean enviandoInfo = false;
	private boolean cargandoInfo = true;

	private boolean finalizarFacturacion = true;
	
	private String [] camposRequeridos = new String[]{"RazonSocial", 
			"RFC", 
			"CalleDF", 
			"EntidadDF", 
			"MunicipioDF", 
			"PaisDF",
			"CodigoPostalDF"};

	ProgressDialog progressDialog;
	Handler mHandler;
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.seleccion_facturacion);
		iniciar();
	}
	
	@Override
	public void iniciar()
	{
		/* Agregar labels */
		Button btnContinuar = (Button) findViewById(R.id.btnContinuar);
		btnContinuar.setOnClickListener(continuarListener);
		btnContinuar.setText(Mensajes.get("XContinuar"));
		
		setTitulo(Mensajes.get("XAFacturacion"));
		
		TextView mTexto = (TextView) findViewById(R.id.lblCliente);
		Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
		mTexto.setText(cliente.Clave + " - " + cliente.RazonSocial);
		mTexto = (TextView) findViewById(R.id.lblRuta);
		mTexto.setText(Html.fromHtml("<b>"+Mensajes.get("XRuta") + ":</b> " + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion));
		mTexto = (TextView) findViewById(R.id.lblDia);
		mTexto.setText(Html.fromHtml("<b>"+Mensajes.get("XDiaTrabajo") + ":</b> " + ((Dia) Sesion.get(Campo.DiaActual)).DiaClave));
		
		/* General */
		mTexto = (TextView) findViewById(R.id.lblGenerales);
		mTexto.setText(Mensajes.get("XDatosGenerales"));
		mTexto = (TextView) findViewById(R.id.lblSubEmpresa);
		mTexto.setText(Mensajes.get("XSUBEMPRESA"));
		mTexto = (TextView) findViewById(R.id.lblFolio);
		mTexto.setText(Mensajes.get("XFolio"));
		mTexto = (TextView) findViewById(R.id.lblFecha);
		mTexto.setText(Mensajes.get("XFecha"));
		mTexto = (TextView) findViewById(R.id.lblFormaPago);
		mTexto.setText(Mensajes.get("XFormaPago"));
		mTexto = (TextView) findViewById(R.id.lblOrdenCompra);
		mTexto.setText(Mensajes.get("XOrdendeCompra"));
        mTexto = (TextView) findViewById(R.id.lblUsoCFDI);
        mTexto.setText(Mensajes.get("TDFUsoCFDI"));
		
		/* Metodos de pago */
		mTexto = (TextView) findViewById(R.id.lblMetodosPago);
		mTexto.setText(Mensajes.get("XMetodoPago"));
		
		/* Pedidos */
		mTexto = (TextView) findViewById(R.id.lblPedidos);
		mTexto.setText(Mensajes.get("XTabPedidos"));
		mTexto = (TextView) findViewById(R.id.lblFolioCol);
		mTexto.setText(Mensajes.get("XFolio"));
		mTexto = (TextView) findViewById(R.id.lblFechaCol);
		mTexto.setText(Mensajes.get("XFecha"));
		mTexto = (TextView) findViewById(R.id.lblTotalCol);
		mTexto.setText(Mensajes.get("XTotal"));
		((TextView) findViewById(R.id.lblEtiquetaTotal)).setText(mTexto.getText()+":");
		
		/* Datos de facturación */
		mTexto = (TextView) findViewById(R.id.lblDatosFacturacion);
		mTexto.setText("Datos de Facturación");
//		mTexto.setText(Mensajes.get("XDatosFacturacion"));
		
		mTexto = (TextView) findViewById(R.id.lblRazonSocial);
		mTexto.setText(Mensajes.get("XRazonSocial"));
		mTexto = (TextView) findViewById(R.id.lblRFC);
		mTexto.setText(Mensajes.get("XRFC"));
		mTexto = (TextView) findViewById(R.id.lblNumeroExtDF);
		mTexto.setText(Mensajes.get("XExterior"));
		mTexto = (TextView) findViewById(R.id.lblNumeroIntDF);
		mTexto.setText(Mensajes.get("TDFNumIntEx"));
		mTexto = (TextView) findViewById(R.id.lblCalleDF);
		mTexto.setText(Mensajes.get("XCalle"));
		mTexto = (TextView) findViewById(R.id.lblColoniaDF);
		mTexto.setText(Mensajes.get("XColonia"));
		mTexto = (TextView) findViewById(R.id.lblEntidadDF);
		mTexto.setText(Mensajes.get("XEntidad"));
		mTexto = (TextView) findViewById(R.id.lblMunicipioDF);
		mTexto.setText(Mensajes.get("XMunicipio"));
		mTexto = (TextView) findViewById(R.id.lblPaisDF);
		mTexto.setText(Mensajes.get("XPais"));
		mTexto = (TextView) findViewById(R.id.lblCodigoPostalDF);
		mTexto.setText(Mensajes.get("XCodigoPostal"));
		mTexto = (TextView) findViewById(R.id.lblReferenciaDF);
		mTexto.setText(Mensajes.get("XReferencia"));
		
		EditText editText = (EditText) findViewById(R.id.txtFecha);
		editText.setText(Generales.getFechaActualStr());
		
		mPresentador = new SeleccionarFacturacion(this);
		try{
            if (!mPresentador.validarInicioFacturacion()){
                mPresentador.iniciar();
            }else {
                btnContinuar.setEnabled(false);
            }
		}catch(ControlError error){
			mostrarError(error.getMessage());
		}
	}
	
	/**
	 * Validar que los parametros y configuracion esten completos
	 * para poder realizar la factura.
	 */
	//@Override
	public void validarInicioFacturacion() throws ControlError
	{
		mPresentador.validarInicioFacturacion();
	}
	
	/**
	 * Inicia la actividad para crear una nueva factura.
	 */
	@Override
	public void iniciaNuevaFactura()
	{
		Button btnContinuar = (Button) findViewById(R.id.btnContinuar);
		btnContinuar.performClick();
	}
	
	@Override
	public void initSpinners()
	{
		mPresentador.initSpinner((Spinner) findViewById(R.id.spnSubEmpresa));
		mPresentador.initSpinner((Spinner) findViewById(R.id.spnFormaPago));
        mPresentador.initSpinner((Spinner) findViewById(R.id.spnUsoCFDI));
	}
	
	@Override
	public void cargarDetalleFactura(TransProd factura, TRPDatoFiscal datoFiscal)
	{
		findViewById(R.id.btnContinuar).performClick();
		/* Cargar todos los datos de la factura */
		/* Generales */
		SEMHist se = mPresentador.getSubEmpresa();
	    ArrayAdapter<SEMHist> aas = new ArrayAdapter<SEMHist>(this, android.R.layout.simple_spinner_item, new SEMHist[]{se});
		((Spinner)findViewById(R.id.spnSubEmpresa)).setAdapter(aas);
		
		CLIFormaVenta cfv = mPresentador.getFormaVenta();
	    ArrayAdapter<CLIFormaVenta> aafv = new ArrayAdapter<CLIFormaVenta>(this, android.R.layout.simple_spinner_item, new CLIFormaVenta[]{cfv});
		((Spinner)findViewById(R.id.spnFormaPago)).setAdapter(aafv);
		
		FolioFiscal folio = new FolioFiscal();
		folio.setFolio(factura.Folio);
		ArrayAdapter<FolioFiscal> aaf = new ArrayAdapter<FolioFiscal>(this, android.R.layout.simple_spinner_item, new FolioFiscal[]{folio});
		((Spinner)findViewById(R.id.spnFolio)).setAdapter(aaf);
		((TextView)findViewById(R.id.txtOrdenCompra)).setText(factura.Notas);
		((TextView)findViewById(R.id.txtFecha)).setText(Generales.getFormatoFecha(factura.FechaFacturacion, "dd/MM/yyyy"));

        if (datoFiscal.UsoCFDI != 0) {
            LinkedList<SeleccionarFacturacion.VistaSpinner> oValores = SeleccionarFacturacion.obtenerValoresSAT("TUSOCFDI", String.valueOf(datoFiscal.UsoCFDI));
            ArrayAdapter<SeleccionarFacturacion.VistaSpinner> vAdapter = new ArrayAdapter<SeleccionarFacturacion.VistaSpinner>(this, android.R.layout.simple_spinner_item, oValores);
            vAdapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
            ((Spinner) findViewById(R.id.spnUsoCFDI)).setAdapter(vAdapter);
        }
		
		/* Metodos de Pago */
		List<Entidad> pagos = new ArrayList<Entidad>();
		String [] metodoPago = datoFiscal.MetodoPago.split(",");
		String [] cuentas = datoFiscal.NumCtaPago.split(",");
		String [] bancos = datoFiscal.Banco.split(",");
		for(int i = 0; i < metodoPago.length ; i++)
		{
			ClientePago cliPago = new ClientePago();
			cliPago.Cuenta = cuentas[i];
			cliPago.Descripcion = metodoPago[i];
			cliPago.Banco = bancos[i];
			pagos.add(cliPago);
		}
		((ListView)findViewById(R.id.lstMetodosPago)).setAdapter(new AdapterGenerico(R.layout.lista_metodo_pago_facturacion, pagos));
		
		/* Datos Fiscales */
		cargaDatosDeFacturacion(null, null, datoFiscal);
	}
	
	@Override
	public void initAdapterView(ArrayAdapter<? extends Entidad> adapter, int idList)
	{
		ListView listView = (ListView) findViewById(idList);
		if(listView.getOnItemClickListener() == null)
		{
			listView.setOnItemClickListener(new AdapterView.OnItemClickListener()
			{

				@Override
				public void onItemClick(AdapterView<?> arg0, View view, int arg2, long arg3)
				{
					CheckBox chk = (CheckBox) view.findViewById(R.id.chkSeleccion);
					if(chk.isEnabled())
						chk.setChecked(!chk.isChecked());
				}
			});
		}
		listView.setAdapter(adapter);
	}
	
	/**
	 * Muestra las facturas existentes para el cliente actual.
	 */
	@Override
	public void mostrarFacturas(List<TransProdFactura> facturas)
	{
		if(facturas.isEmpty())
		{
			existenFacturas = false;
			iniciaNuevaFactura();
		}else
		{
			existenFacturas = true;
			ListView lstFacturas = (ListView) findViewById(R.id.lstFacturas);
			registerForContextMenu(lstFacturas);
			//lstFacturas.setOnItemLongClickListener(menu);
			FacturacionAdapter adapter = new FacturacionAdapter(this, R.layout.lista_simple4, facturas.toArray(new TransProdFactura[facturas.size()]));
			lstFacturas.setAdapter(adapter);
		}
	}
	
	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				if(validarSalida()){
					this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
					this.finalizar();
					return true;
				}
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		switch(requestCode)
		{
			case Vista.REQUEST_ENABLE_BT:
				if(resultCode == RESULT_OK)
				{
					imprimirTicket(finalizarFacturacion);
				}
				break;
            case Enumeradores.Solicitudes.SOLICITUD_ENVIAR_PDF:

                if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                    //imprimiendo = true;

                    Sesion.remove(Campo.ArchivoPDF);
                    Sesion.remove(Campo.ArchivosPDFxEnviar);
                    Sesion.remove(Campo.ArchivosPDFxGenerar);

                    try
                    {
                        imprimirTicket(true);
                    }
                    catch (Exception e)
                    {
                        EnvioPDF.guardarArchivosNoGenerados();
                        this.mostrarError(e.getMessage(), ENVIO_PDF);
                    }

                    if (Sesion.get(Campo.ArchivosPDFxEnviar) != null)
                    {
                        EnvioPDF.enviarArchivos(SeleccionFacturacion.this);
                    }
                    else {
                        this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                        this.finalizar();
                    }
                }
                else{
                    this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                    this.finalizar();
                }
                break;

            case Enumeradores.Solicitudes.SOLICITUD_ENVIAR_PDF_SERVER:
                if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                    if (Short.valueOf(((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MensajeImpresion").toString()) == 3) {
                        String sURLServer = Sesion.get(Campo.URLServerPDF).toString();
                        Hashtable<String, ContentValues> htArchivosPDF = (Hashtable<String, ContentValues>)Sesion.get(Campo.ArchivosPDFxEnviar);
                        Iterator<Map.Entry<String, ContentValues>> it =  htArchivosPDF.entrySet().iterator();
                        Map.Entry<String, ContentValues> entry = it.next();
                        Sesion.set(Campo.ArchivoPDF, entry.getKey());
                        Sesion.set(Campo.TransaccionActualPDF, entry.getValue());
                        EnvioPDF.enviarSMS(SeleccionFacturacion.this);
                    }
                    else{
                        this.mostrarMensaje(Mensajes.get("I0307").replace("$0$", Mensajes.get("XCorreoElectronico")), 0, ENVIO_PDF);
                    }
                }
                else{
                    EnvioPDF.guardarArchivosNoEnviados();
                    if (data != null) {
                        String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                        if (mensajeError != null) {
                            this.mostrarError(mensajeError, ENVIO_PDF);
                        }
                    }
                    else {
                        this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                        this.finalizar();
                    }
                }
                break;

            case Enumeradores.Solicitudes.SOLICITUD_ENVIAR_SMS:
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                EnvioPDF.agregarArchivoEnviado();

                Sesion.remove(Campo.ArchivoPDF);
                String sArchivoPDF = EnvioPDF.obtenerSiguienteArchivo();
                if (sArchivoPDF != "")
                {
                    EnvioPDF.EnviarSiguiente(SeleccionFacturacion.this, sArchivoPDF);
                }
                else
                {
                    this.mostrarMensaje(Mensajes.get("I0307").replace("$0$", "SMS"), 0, ENVIO_PDF);
                }
            }
            else {
                this.mostrarPreguntaSiNo(Mensajes.get("P0254"), PREGUNTAR_REINTENTAR_SMS);
            }
            break;
			case Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES:
					if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
					{
						if (enviandoInfo) enviandoInfo = false;
						if (cargandoInfo) cargandoInfo = false;
						if (data != null && data.getExtras() != null && data.getExtras().containsKey("mensajeIniciar")){
							mostrarError(data.getExtras().getString("mensajeIniciar").toString());
						}
					}
					else if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN /*&& !envioPendientesTerminado*/)
					{
						mostrarAdvertencia("La informacion se envió correctamente");

						if (enviandoInfo) {
							try {
								long espera = 10000;
								if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("TiempoEsperaRecepcionTimbrado")){
									espera =(Long.parseLong(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("TiempoEsperaRecepcionTimbrado").toString()) * 1000);
								}
								mHandler= new Handler();
								progressDialog = new ProgressDialog(this);
								progressDialog.setMessage(Mensajes.get("I0325"));
								progressDialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);
								progressDialog.setCancelable(false);
								progressDialog.show();
								progressDialog.setOnDismissListener(new DialogInterface.OnDismissListener() {

									@Override
									public void onDismiss(DialogInterface dialog) {
										mHandler.removeCallbacksAndMessages(null);
									}
								});
								mHandler.postDelayed(new Runnable()
								{
									@Override
									public void run() {
										progressDialog.dismiss();
										HashMap<String, String> parametros = new HashMap<String, String>();
										String listadoFacturas = "";
										try{
											listadoFacturas = Consultas.ConsultasTransProd.obtenerFacturasConTimbradoPendiente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
										}catch (Exception ex){
											if (ex!=null && ex.getMessage()!= null){
												mostrarError(ex.getMessage());
											}else{
												mostrarError("Error al obtener las Facturas con Timbrado Pendiente");
											}
										}
										if (listadoFacturas.length() > 0) {
											parametros.put("FolioDocto", listadoFacturas);
											iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_RECIBIR_INFO_TIMBRADO_CDFIs, parametros);
											cargandoInfo = true;
										} else {
											mostrarAdvertencia(Mensajes.get("I0326"));
										}
									}

								}, espera);

								//progressDialog.dismiss();

							} catch (Exception ex) {
								if (ex != null && ex.getMessage() != null) {
									mostrarError(ex.getMessage());
								} else {
									mostrarError("Error al recuperar las facturas");
								}

							}
							enviandoInfo = false;

						}else if(cargandoInfo){
							cargandoInfo = false;
							try{
								mPresentador.cargarFacturas();
							}catch(Exception ex){
								if (ex!= null && ex.getMessage()!= null) {
									mostrarError("Cargando Facturas: " + ex.getMessage());
								}else{
									mostrarError("Error Cargando Facturas");
								}
							}

						}
					}
				break;
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		switch(tipoMensaje)
		{
			case PREGUNTA_SALIR_SIN_GUARDAR:
				if(respuesta == RespuestaMsg.Si)
				{
					if(existenFacturas){
						reiniciar();
					}else{
						setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
						finalizar();
					}
				}
				break;
			case IMPRESION:
				if(respuesta == RespuestaMsg.Si)
				{
					imprimirTicket(true);
				}else
					finalizarCapturaFacturacion();
			break;
			case IMPRESION_SOLO_TIMBRADO:
				if (respuesta == RespuestaMsg.Si){
					imprimirTicket(false);
				}
				break;
			case PREGUNTAR_CANCELAR:
				if(respuesta == RespuestaMsg.Si)
				{
					mPresentador.cancelarFactura();
				}
				finalizarCapturaFacturacion();
                break;
            case ENVIO_PDF:
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();

            case PREGUNTAR_REINTENTAR_SMS:
                if (respuesta.equals(RespuestaMsg.Si)) {
                    EnvioPDF.enviarSMS(SeleccionFacturacion.this);
                }
                else{
                    EnvioPDF.guardarArchivosNoEnviados();
                    setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                    finalizar();
                }
		}
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		try{
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("TimbradoCFDIMovil") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("TimbradoCFDIMovil").toString().equals("1") ) {
				MenuInflater inflater = getMenuInflater();
				inflater.inflate(R.menu.menu_seleccion_facturacion, menu);
				menu.getItem(0).setTitle(Mensajes.get("BTEnviarRecibir")); // Mensajes.get("BTNuevo"));
			}
		}catch (Exception ex){
			if (ex != null && ex.getMessage()!=null) {
				mostrarError(ex.getMessage());
			}
		}

		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{
		switch (item.getItemId())
		{
			case R.id.enviar_recibir:
				HashMap<String, String> oParametros = new HashMap<String, String>();
				oParametros.put("TipoEnvioInfo", String.valueOf(Enumeradores.TipoEnvioInfo.ENVIO_PARCIAL));
				oParametros.put("Continuar", "true");
				iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_ENVIAR_BD_VENDEDOR, oParametros);
				enviandoInfo = true;
				return true;
			default:
				return super.onOptionsItemSelected(item);
		}
	}
	@Override
	public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo)
	{
		super.onCreateContextMenu(menu, v, menuInfo);
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.context_operaciones_facturacion , menu);

		AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) menuInfo;
		ListView lstFacturas = (ListView) findViewById(R.id.lstFacturas);
		TransProdFactura factura = (TransProdFactura) lstFacturas.getItemAtPosition((int) info.position);

		mPresentador.setFacturaSeleccionada(factura);

		menu.getItem(0).setTitle(Mensajes.get("Xconsultar"));
		menu.getItem(1).setTitle(Mensajes.get("XCancelar"));
		if (factura.UUID!=null && factura.UUID.length()>0 )
			menu.getItem(2).setTitle(Mensajes.get("XImprimir"));
		else
            menu.getItem(2).setVisible(false);
	}
	
	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		try{
			mPresentador.validarAccion(item.getItemId());
		}catch(Exception ex){
			mostrarAdvertencia(ex.getMessage());
		}
		return super.onContextItemSelected(item);
	}
	
	@Override
	public OnItemSelectedListener getListenerSpinners()
	{
		return listenerSpinners;
	}
	
	@Override
	public void setContinuar(boolean continuar)
	{
		findViewById(R.id.btnContinuar).setEnabled(continuar);
	}
	
	@Override
	public int getFormaDeVentaSeleccionada()
	{
		CLIFormaVenta cfv = (CLIFormaVenta) ((Spinner) findViewById(R.id.spnFormaPago)).getSelectedItem();
		return cfv == null ? -1 : cfv.CFVTipo;
	}
	
	@Override
	public SEMHist getSubEmpresaSeleccionada()
	{
		SEMHist se = (SEMHist) ((Spinner) findViewById(R.id.spnSubEmpresa)).getSelectedItem();
		return se;
	}

    @Override
    public int getUsoCFDSeleccionado(){
         Object x = ((Spinner)findViewById(R.id.spnUsoCFDI)).getSelectedItem();
        return ( x == null ? 0 : Integer.parseInt(((SeleccionarFacturacion.VistaSpinner) x).getId()));
    }
	
	@Override
	public FolioFiscal getFolio()
	{
		FolioFiscal folio = (FolioFiscal) ((Spinner) findViewById(R.id.spnFolio)).getSelectedItem();
		return folio;
	}
	
	public boolean isSoloLectura()
	{
		return soloLectura;
	}
	
	public void setSoloLectura(boolean soloLectura)
	{
		this.soloLectura = soloLectura;
		setEnabledControles(GENERALES_INDEX, !soloLectura);
		setEnabledControles(METODOS_PAGO_INDEX, !soloLectura);
		setEnabledControles(PEDIDOS_INDEX, !soloLectura);
		setEnabledControles(DATOS_FACTURACION_INDEX, soloLectura ? false : ((Vendedor)Sesion.get(Campo.VendedorActual)).EditarDatosFiscal);
	}
	
	@Override
	public void setVisivilityTotalFactura(int visibility)
	{
		View v = findViewById(R.id.lblTotalFactura);
		if(v.getVisibility() != visibility){
			v.setVisibility(visibility);
			findViewById(R.id.lblEtiquetaTotal).setVisibility(visibility);
		}
	}
	
	@Override
	public void actualizaTotalFactura(float total)
	{
		setVisivilityTotalFactura(View.VISIBLE);
		((TextView)findViewById(R.id.lblTotalFactura)).setText("$ ".concat(Generales.getFormatoDecimal(total, "#,###,##0.00")));
	}
	
	@Override
	public float getTotalFactura()
	{
		ListView listView = (ListView) findViewById(R.id.lstPedidos);
		return ((AdapterGenerico)listView.getAdapter()).getTotal();
	}
	
	@Override
	public String getOrdenCompra()
	{
		return ((TextView) findViewById(R.id.txtOrdenCompra)).getText().toString();
	}
	
	@Override
	public List<Entidad> getPedidosParaFactura()
	{
		ListView lstPedidos = (ListView) findViewById(R.id.lstPedidos);
		return ((AdapterGenerico) lstPedidos.getAdapter()).getSeleccionados();
	}
	
	@Override
	public List<Entidad> getPedidosDeFactura()
	{
		ListView lstPedidos = (ListView) findViewById(R.id.lstPedidos);
		return ((AdapterGenerico) lstPedidos.getAdapter()).getItems();
	}
	
	private void reiniciar(){
		FrameLayout layoutParent = (FrameLayout) findViewById(R.id.layoutParentFacturacion);
		for(int i = indiceActivo; i > 0; i--)
		{
			layoutParent.getChildAt(i).setVisibility(View.GONE);
		}
		indiceActivo = 0;
		setContinuar(true);
		mPresentador.iniciar();
	}
	
	public String[] getMetodosPagoSeleccionados(){
		ListView lstMetodosPago = (ListView) findViewById(R.id.lstMetodosPago);
		Iterator<Entidad> iterador = ((AdapterGenerico) lstMetodosPago.getAdapter()).getSeleccionados().iterator();
		StringBuilder metodosPago = new StringBuilder();
		StringBuilder cuentas = new StringBuilder();
		StringBuilder bancos = new StringBuilder();
		ClientePago pago;
		String existeOtro;
		while(iterador.hasNext())
		{
			pago = (ClientePago) iterador.next();
			existeOtro = iterador.hasNext() ? ", " : "";
			metodosPago.append(ValoresReferencia.getDescripcion("PAGO", String.valueOf(pago.Tipo))).append(existeOtro);
            cuentas.append(pago.Cuenta).append(existeOtro);
            bancos.append(ValoresReferencia.getDescripcion("TBANCO", String.valueOf(pago.TipoBanco))).append(existeOtro);
		}
		return new String[]{metodosPago.toString(), cuentas.toString(), bancos.toString()};
	}
	
	/**
	 * Se inicia el proceso de facturación, se realizan validaciones a los
	 * datos fiscales y se muestra el error al usuario o de lo contrario
	 * se genera el registro de factura (TransProd)
	 */
	private void facturar(){
		String mensaje = null;
		boolean puedeModificar = findViewById(R.id.txtRazonSocial).isFocusable();
		if(puedeModificar && (mensaje = validarDatosFiscales()) != null)
		{
			mostrarAdvertencia(mensaje);
		}else
		{
			/* Actualizar el cliente y el Cliente Domicilio */
			Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
			if(puedeModificar)
			{
				String idUsuario = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				cliente.IdFiscal = ((TextView)findViewById(R.id.txtRFC)).getText().toString().replace("-", "").trim();
				cliente.RazonSocial = ((TextView)findViewById(R.id.txtRazonSocial)).getText().toString().trim();
				cliente.Enviado = false;
				cliente.MFechaHora = Generales.getFechaHoraActual();
				cliente.MUsuarioID = idUsuario;
				ClienteDomicilio dom = null;
				for(ClienteDomicilio domicilio : cliente.ClienteDomicilio)
				{
					if(domicilio.Tipo == 1)
					{
						dom = domicilio;
						break;
					}
				}
				dom.Calle = ((TextView)findViewById(R.id.txtCalleDF)).getText().toString().trim();
				dom.Numero = ((TextView)findViewById(R.id.txtNumeroExtDF)).getText().toString().trim();
				dom.NumInt = ((TextView)findViewById(R.id.txtNumeroIntDF)).getText().toString().trim();
				dom.Colonia = ((TextView)findViewById(R.id.txtColoniaDF)).getText().toString().trim();
				dom.Localidad = ((TextView)findViewById(R.id.txtMunicipioDF)).getText().toString().trim();
				dom.Entidad = ((TextView)findViewById(R.id.txtEntidadDF)).getText().toString().trim();
				dom.Pais = ((TextView)findViewById(R.id.txtPaisDF)).getText().toString().trim();
				dom.CodigoPostal = ((TextView)findViewById(R.id.txtCodigoPostalDF)).getText().toString().trim();
				dom.ReferenciaDom = ((TextView)findViewById(R.id.txtReferenciaDF)).getText().toString().trim();
			
				dom.Enviado = false;
				dom.MFechaHora = Generales.getFechaHoraActual();
				dom.MUsuarioID = idUsuario;
			}
			if(mPresentador.crearFactura(cliente, puedeModificar))
			{
//				if(getSubEmpresaSeleccionada().VersionCFD == 5)
//				{
					MOTConfiguracion motCfg = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
					if("1".equals(motCfg.get("MensajeImpresion")))
					{
						mostrarPreguntaSiNo(Mensajes.get("P0103"), IMPRESION);
						return;
					}else if (motCfg.get("MensajeImpresion").equals("2") || motCfg.get("MensajeImpresion").equals("3")){
                        EnvioPDF.enviarTicketPDF(SeleccionFacturacion.this, Short.valueOf(motCfg.get("MensajeImpresion").toString()));
                    }
//				}
				finalizarCapturaFacturacion();
			}
		}
	}
	
	private void finalizarCapturaFacturacion()
	{
		setVisivilityTotalFactura(View.INVISIBLE);
		reiniciar();
	}
	
	/**
	 * Valida que los campos de datos fiscales esten correctos.
	 * @return mensaje con la descripcion del error en el dato fiscal
	 */
	private String validarDatosFiscales(){
		String mensaje = null;
		TextView txtReq = null;
		/* Validar campos requeridos */
		try
		{
			for(int i = 0; i < camposRequeridos.length; i++){
				Field field = R.id.class.getField("txt".concat(camposRequeridos[i]));
				txtReq = (TextView) findViewById(field.getInt(null));
				if(txtReq.getText().toString().trim().isEmpty())
				{
					field = R.id.class.getField("lbl".concat(camposRequeridos[i]));
					String etiqueta = ((TextView)findViewById(field.getInt(null))).getText().toString();
					mensaje = Mensajes.get("BE0001", etiqueta);
					txtReq.requestFocus();
					return mensaje;
				}
			}
		}catch(Exception ex){
			Log.e("EROUTE", ex.getMessage()); // No deberia de suceder si no se modifican los id's
		}
		/* Otras validaciones */
		//Validar RFC
		
		return mensaje;
	}
	
	@Override
	public void cargaDatosDeFacturacion(Cliente cliente, ClienteDomicilio domicilioFiscal, TRPDatoFiscal...datoFiscal)
	{
		boolean existeFiscal = datoFiscal.length > 0;
		TextView txt = (TextView)findViewById(R.id.txtRazonSocial);
		txt.setText(existeFiscal ? datoFiscal[0].RazonSocial:cliente.RazonSocial);
		txt = (TextView)findViewById(R.id.txtRFC);
		txt.setText(existeFiscal ? datoFiscal[0].RFC:cliente.IdFiscal);
		txt = (TextView)findViewById(R.id.txtCalleDF);
		txt.setText(existeFiscal ? datoFiscal[0].Calle:domicilioFiscal.Calle);
		txt = (TextView)findViewById(R.id.txtNumeroExtDF);
		txt.setText(existeFiscal ? datoFiscal[0].NumExt:domicilioFiscal.Numero);
		txt = (TextView)findViewById(R.id.txtNumeroIntDF);
		txt.setText(existeFiscal ? datoFiscal[0].NumInt:domicilioFiscal.NumInt);
		txt = (TextView)findViewById(R.id.txtColoniaDF);
		txt.setText(existeFiscal ? datoFiscal[0].Colonia:domicilioFiscal.Colonia);
		txt = (TextView)findViewById(R.id.txtMunicipioDF);
		txt.setText(existeFiscal ? datoFiscal[0].Municipio:domicilioFiscal.Localidad);
		txt = (TextView)findViewById(R.id.txtEntidadDF);
		txt.setText(existeFiscal ? datoFiscal[0].Entidad:domicilioFiscal.Entidad);
		txt = (TextView)findViewById(R.id.txtPaisDF);
		txt.setText(existeFiscal ? datoFiscal[0].Pais:domicilioFiscal.Pais);
		txt = (TextView)findViewById(R.id.txtCodigoPostalDF);
		txt.setText(existeFiscal ? datoFiscal[0].CodigoPostal:domicilioFiscal.CodigoPostal);
		txt = (TextView)findViewById(R.id.txtReferenciaDF);
		txt.setText(existeFiscal ? datoFiscal[0].ReferenciaDom:domicilioFiscal.ReferenciaDom);	
	}
	
	/**
	 * Valida los formularios de las diferentes etapas de la facturacion, si el
	 * formulario esta completo se considerara valido el avance
	 * @return true si es factible pasar a la siguiente etapa de facturación
	 */
	private String validaAvance(){
		switch(indiceActivo)
		{
			case GENERALES_INDEX:
				Spinner spinner = (Spinner) findViewById(R.id.spnSubEmpresa);
				if(spinner.getSelectedItem() == null)
					return Mensajes.get("BE0001", Mensajes.get("XSUBEMPRESA"));
				else if((spinner = (Spinner) findViewById(R.id.spnFolio)).getSelectedItem() == null)
					return Mensajes.get("BE0001", Mensajes.get("XFolio"));
				else if((spinner = (Spinner) findViewById(R.id.spnFormaPago)).getSelectedItem() == null)
					return Mensajes.get("BE0001", Mensajes.get("XFormaPago"));
				else if(((Cliente)Sesion.get(Campo.ClienteActual)).ExigirOrdenCompra) 
				{
					String ordenCompra = ((TextView) findViewById(R.id.txtOrdenCompra)).getText().toString().trim();
					if(ordenCompra.isEmpty())
						return Mensajes.get("BE0001", Mensajes.get("XOrdendeCompra"));
				}
			break;
			case METODOS_PAGO_INDEX:
				if(((SEMHist)((Spinner)findViewById(R.id.spnSubEmpresa)).getSelectedItem()).VersionCFD == 4 | ((SEMHist)((Spinner)findViewById(R.id.spnSubEmpresa)).getSelectedItem()).VersionCFD == 6){
					if(!((AdapterGenerico)((ListView)findViewById(R.id.lstMetodosPago)).getAdapter()).haySeleccionados()){
                        try {
                            if (getFormaDeVentaSeleccionada() == 2) {
                                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("SeleccionarMetodoPagoCredito")) {
                                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("SeleccionarMetodoPagoCredito").equals("1")) {
                                        return Mensajes.get("E0867", Mensajes.get("XMetodoPago"));
                                    }
                                }
                            } else
                                return Mensajes.get("E0867", Mensajes.get("XMetodoPago"));


                        }catch(Exception e){}
					}
				}
			break;
			case PEDIDOS_INDEX:
				if(!((AdapterGenerico)((ListView)findViewById(R.id.lstPedidos)).getAdapter()).haySeleccionados()){
					return Mensajes.get("E0062");
				}
				break;
		}
		return null;
	}
	
	private void imprimirTicket(boolean parfinalizarFacturacion){
		finalizarFacturacion= parfinalizarFacturacion ;
		if(bluetoothEncendido())
		{
			try{
				mPresentador.imprimirTicket();
			}catch(Exception e){
				mostrarError(e.getMessage());
				/* Si ocurre el error en la impresion finalizar la captura */
				if (finalizarFacturacion) {
					finalizarCapturaFacturacion();
				}
			}
		}else
		{
			try
			{
				encenderBluetooth();
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
                if (finalizarFacturacion) {
                    finalizarCapturaFacturacion();
                }
			}
		}
	}
	
	@Override
	public void impresionFinalizada(boolean impresionExitosa, String mensajeError)
	{
		quitarProgreso();
		if (!finalizarFacturacion) {
			return;
		}
        try {
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString())) {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("0")) {
                    mostrarPreguntaSiNo(Mensajes.get("P0103"), IMPRESION);
                } else {
						finalizarCapturaFacturacion();
                }
            } else {
                mostrarPreguntaSiNo(Mensajes.get("P0103"), IMPRESION);
            }
        }catch(Exception ex){
            mostrarPreguntaSiNo(Mensajes.get("P0103"), IMPRESION);
        }
	}
	
	@Override
	public void setEnabledControles(int panelIndice, boolean enabled)
	{
		FrameLayout layoutParent = (FrameLayout) findViewById(R.id.layoutParentFacturacion);
		if(panelIndice < layoutParent.getChildCount())
		{
			ViewGroup layout = (ViewGroup) layoutParent.getChildAt(panelIndice);
			enabledControles(layout, enabled);
		}
	}
	
	private void enabledControles(ViewGroup panel, boolean enabled){
		for(int i = 0; i < panel.getChildCount(); i++)
		{
			View v = panel.getChildAt(i);
			if(v instanceof ViewGroup)
			{
				v.setEnabled(enabled);
				v.setClickable(enabled);
				enabledControles((ViewGroup)v, enabled);
			}else {
				v.setFocusable(enabled);
				v.setClickable(enabled);
			}
		}
	}
	
	/**
	 * Valida si el usuario puede salir de la actividad de facturacion o 
	 * retrocede en el proceso.
	 * @return true, si puede abandonar la actividad
	 */
	private boolean validarSalida(){
		if(indiceActivo == 0){
			return true;
		}else if(indiceActivo == GENERALES_INDEX){
			if(soloLectura){
				finalizarCapturaFacturacion();
			}else{
				mostrarPreguntaSiNo(Mensajes.get("BP0002"), PREGUNTA_SALIR_SIN_GUARDAR);
			}
			return false;
		}else{
			FrameLayout layoutParent = (FrameLayout) findViewById(R.id.layoutParentFacturacion);
			layoutParent.getChildAt(indiceActivo).setVisibility(View.GONE);
			indiceActivo--;
			switch(indiceActivo){
				case 0:
					setContinuar(true);
				break;
				case METODOS_PAGO_INDEX:
					setVisivilityTotalFactura(View.INVISIBLE);
			}
			return false;
		}
	}
	
	private OnClickListener continuarListener = new OnClickListener()
	{
		
		@Override
		public void onClick(View v)
		{
			if(indiceActivo == DATOS_FACTURACION_INDEX)
			{
				if(mPresentador.isCancelar()){
					mostrarPreguntaSiNo(Mensajes.get("P0212"), PREGUNTAR_CANCELAR);
				}else if(soloLectura){
//					if(getSubEmpresaSeleccionada().VersionCFD == 5)
//					{
						MOTConfiguracion motCfg = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
						if("1".equals(motCfg.get("MensajeImpresion")))
						{
							mostrarPreguntaSiNo(Mensajes.get("P0103"), IMPRESION);
							return;
						}
//					}
					finalizarCapturaFacturacion();
				}else {
                    if (((TextView) findViewById(R.id.txtRFC)).getText().toString().length() < 12) {
                        mostrarAdvertencia(Mensajes.get("E0718").replace("$0$", "RFC").replace("menos", "al menos").replace("$1$", "12"));
                        return;
                    }
                    facturar();
                }
			}else{
				boolean continuar = true;
				if(!soloLectura && indiceActivo == 0)
				{
					try
					{
						continuar = FoliosFiscales.validarExistencia();
					}catch(FoliosFiscalesException ffe){
						ffe.muestraError(SeleccionFacturacion.this);
						continuar = false;
					}
				}
				if(continuar)
				{
					String mensaje;
					if(soloLectura || (mensaje = validaAvance()) == null)
					{
						FrameLayout layoutParent = (FrameLayout) findViewById(R.id.layoutParentFacturacion);
						for(int index = layoutParent.getChildCount()-2; index >= 0; index--){
							if(layoutParent.getChildAt(index).getVisibility() != View.GONE)
							{
								indiceActivo = index+1;
								layoutParent.getChildAt(indiceActivo).setVisibility(View.VISIBLE);
								/* Inicializar panel */
								switch(indiceActivo){
									case PEDIDOS_INDEX:
										mPresentador.cargaPedidos(soloLectura);
										if(soloLectura)
											((AdapterGenerico)((ListView)findViewById(R.id.lstPedidos)).getAdapter()).calculaTotal();
										else actualizaTotalFactura(0);
								}
								break;
							}
						}
					}else
					{
						mostrarAdvertencia(mensaje);
					}
				}else
				{
					mostrarAdvertencia(Mensajes.get("E0659"));
				}
			}
		}
	};

	private OnItemLongClickListener menu = new OnItemLongClickListener()
	{

		@Override
		public boolean onItemLongClick(AdapterView<?> arg0, View arg1, int position, long arg3)
		{
			mPresentador.setFacturaSeleccionada(((FacturacionAdapter)arg0.getAdapter()).getItem(position));
			openContextMenu(arg0);
			return true;
		}
	};
	
	private OnItemSelectedListener listenerSpinners = new OnItemSelectedListener()
	{
		@Override
		public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3)
		{
			if(!soloLectura && arg0.getId() == R.id.spnSubEmpresa){
				SEMHist se = (SEMHist) arg0.getItemAtPosition(arg2);
				mPresentador.initSpinner((Spinner)findViewById(R.id.spnFolio), se.SubEmpresaId);
			}
		}
		@Override
		public void onNothingSelected(AdapterView<?> arg0)
		{
			
		}
	};
	
	public class AdapterGenerico extends ArrayAdapter<Entidad>{
		
		private int idLayout;
		private boolean [] seleccionados;
		private float total;
		private CONHist conHist;
		private List<Entidad> entidades;
		
		public AdapterGenerico(int idResource, List<Entidad> entidades){
			super(SeleccionFacturacion.this, idResource, entidades);
			idLayout = idResource;
			this.entidades = entidades;
			seleccionados = new boolean[entidades.size()];
			conHist = (CONHist) Sesion.get(Campo.CONHist);
		}
		
		public float getTotal(){
			return total;
		}
		
		public void calculaTotal(){
			total = 0;
			if(getCount() > 0)
				if(getItem(0) instanceof TransProd){
					for(int i = 0; i < getCount(); i++){
						if(seleccionados[i] || soloLectura){
							total+= ((TransProd)getItem(i)).Total;
						}
					}
				}else{
					throw new UnsupportedOperationException("Esta operacion no se puede aplicar con la entidad:"+getItemId(0));
				}
			actualizaTotalFactura(total);
		}
		
		public boolean haySeleccionados(){
			for(boolean seleccion : seleccionados){
				if(seleccion) return seleccion;
			}
			return false;
		}
		
		public List<Entidad> getSeleccionados(){
			List<Entidad> lstSeleccion = new ArrayList<Entidad>();
			for(int i = 0; i < getCount(); i++){
				if(seleccionados[i]){
					lstSeleccion.add(getItem(i));
				}
			}
			return lstSeleccion;
		}
		
		public List<Entidad> getItems(){
			return entidades;
		}
		
		@Override
		public View getView(final int position, View convertView, ViewGroup parent)
		{
			View fila = convertView;

			if (convertView == null)
			{
				LayoutInflater inflater = (SeleccionFacturacion.this).getLayoutInflater();
				fila = inflater.inflate(idLayout, null);
			}
			final Entidad entidad = getItem(position);
			switch(idLayout)
			{
				case R.layout.lista_metodo_pago_facturacion:
					if(soloLectura){
						((TextView)fila.findViewById(R.id.lblMetodoPago)).setText(Html.fromHtml("<b>"+Mensajes.get("XMetodoPago")+":</b> "+ ((ClientePago)entidad).Descripcion));
						((TextView)fila.findViewById(R.id.lblCuenta)).setText(Html.fromHtml("<b>"+Mensajes.get("TDFNumerosCuenta")+":</b> "+
								((ClientePago)entidad).Cuenta));
						((TextView)fila.findViewById(R.id.lblBanco)).setText(Html.fromHtml("<b>"+Mensajes.get("XBanco")+":</b> "+ ((ClientePago)entidad).Banco));
					}else{
						((TextView)fila.findViewById(R.id.lblMetodoPago)).setText(Html.fromHtml("<b>"+Mensajes.get("XMetodoPago")+":</b> "+
											ValoresReferencia.getDescripcion("PAGO", String.valueOf(((ClientePago)entidad).Tipo))));
						((TextView)fila.findViewById(R.id.lblCuenta)).setText(Html.fromHtml("<b>"+Mensajes.get("TDFNumerosCuenta")+":</b> "+
											((ClientePago)entidad).Cuenta));
						((TextView)fila.findViewById(R.id.lblBanco)).setText(Html.fromHtml("<b>"+Mensajes.get("XBanco")+":</b> "+
								ValoresReferencia.getDescripcion("TBANCO", String.valueOf(((ClientePago)entidad).TipoBanco))));
					}
					break;
				default :
					((TextView)fila.findViewById(R.id.lblFolio)).setText(((TransProd)entidad).Folio);
					((TextView)fila.findViewById(R.id.lblFecha)).setText(Generales.getFormatoFecha(((TransProd)entidad).FechaSurtido, "dd/MM/yyyy"));
					((TextView)fila.findViewById(R.id.lblTotal)).setText("$ ".concat(Generales.getFormatoDecimal(((TransProd)entidad).Total, "#,###,##0.00")));
					fila.findViewById(R.id.chkSeleccion).setEnabled(!haySeleccionados() || (!"0".equals(conHist.get("VariosPedidos")) || seleccionados[position]));
					
			}
			if(isSoloLectura()){
				fila.findViewById(R.id.chkSeleccion).setVisibility(View.GONE);
			}else
			{
				((CheckBox)fila.findViewById(R.id.chkSeleccion)).setOnCheckedChangeListener(new OnCheckedChangeListener()	
				{
					
					@Override
					public void onCheckedChanged(CompoundButton check, boolean checked)
					{
						seleccionados[position] = checked;
						if(idLayout == R.layout.lista_pedidos_facturacion){
							if(checked){
								/* Validar la seleccion del pedido */
								String aux = conHist.get("TipoCobranza").toString();
								Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
								if("1".equals(aux) || ("2".equals(aux) && cliente.TipoFiscal == 1)) {
									if (((TransProd) entidad).Saldo > 0)
									{
										boolean bFacturarCualquierVenta = false;
										try {
											if (((TransProd)entidad).CFVTipo !=1){
												if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("FacturarCualquierVenta")) {
													if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("FacturarCualquierVenta").equals("1")) {
														bFacturarCualquierVenta = true;
													}
												}
											}
										}catch (Exception ex){
											if (ex!=null && ex.getMessage()!=null) {
												mostrarError(ex.getMessage());
											}

										}
										if (!bFacturarCualquierVenta) {
											mostrarAdvertencia(Mensajes.get("E0743"));
											check.setChecked(false);
										}
									}
								}
							}
							calculaTotal();
							notifyDataSetChanged();
						}else if(idLayout == R.layout.lista_metodo_pago_facturacion){
                            if(checked){
                                if (((SEMHist)((Spinner)findViewById(R.id.spnSubEmpresa)).getSelectedItem()).VersionCFD == 6){
                                    if(getSeleccionados().size() > 1){
                                        mostrarAdvertencia(Mensajes.get("E0975").replace("$0$","método de pago").replace("$1$","el CFDI version 3.3"));
                                        check.setChecked(false);
                                        seleccionados[position] = false;
                                    }
                                }
                            }
                            notifyDataSetChanged();
                        }
					}
				});
			}
			return fila;
		}
	}

	public void mostrarPreguntaImpresionTimbrado(){
		mostrarPreguntaSiNo(Mensajes.get("P0103"), IMPRESION_SOLO_TIMBRADO);
	}
}
