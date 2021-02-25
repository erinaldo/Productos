package com.amesol.routelite.vistas;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.app.PendingIntent;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.DialogInterface.OnDismissListener;
import android.content.Intent;
import android.content.IntentFilter;
import android.database.Cursor;
import android.nfc.NdefRecord;
import android.nfc.NfcAdapter;
import android.nfc.Tag;
import android.nfc.tech.Ndef;
import android.os.Bundle;
import android.os.Handler;
import android.provider.Settings;
import android.text.SpannableStringBuilder;
import android.text.style.RelativeSizeSpan;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;
import android.widget.Toast;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Impuestos;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ModuloMov;
import com.amesol.routelite.actividades.ModuloMovDetalle;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.TextBoxScanner;
import com.amesol.routelite.controles.TextBoxScanner.OnCodigoIngresadoListener;
import com.amesol.routelite.datos.Agenda;
import com.amesol.routelite.datos.AseguramientoVisita;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.ProductoPrestamoCli;
import com.amesol.routelite.datos.PuntoGPS;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TPDImpuesto;
import com.amesol.routelite.datos.TPDImpuestoEliminado;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.VisitaModificada;
import com.amesol.routelite.datos.VisitaHist;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasVisita;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.Enumeradores.TiposModuloMovDetalle;
import com.amesol.routelite.presentadores.act.AtenderClientes;
import com.amesol.routelite.presentadores.act.SeleccionarActividadesVisita;
import com.amesol.routelite.presentadores.interfaces.IAtencionClientes;
import com.amesol.routelite.presentadores.interfaces.IAutorizaMovimiento;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
import com.amesol.routelite.presentadores.interfaces.IConsultaReporte;
import com.amesol.routelite.presentadores.interfaces.IResumenMovVisita;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVisita;
import com.amesol.routelite.presentadores.interfaces.ISeleccionPedido;
import com.amesol.routelite.presentadores.interfaces.ISeleccionPedidoBackOrder;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.EncriptaDesencripta;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.generico.DialogoAlerta;
import com.amesol.routelite.vistas.generico.ModuloGridAdapter;

import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class SeleccionActividadesVisita extends Vista implements ISeleccionActividadesVisita, OnItemClickListener
{
	SeleccionarActividadesVisita mPresenta;
	String visitaClave;
	Visita visita;
	VisitaHist visitaHist;
	PuntoGPS puntoGPS;
	HashMap<String, Object> parametros;
	ModuloMovDetalle actividad = null;
	ModuloGridAdapter gridAdapter = null;
	boolean mostrandoMensajeLimiteCredito = false;
	boolean mostrandoCodigoBarras = false;
    boolean mostrarResumenMov = false;
	boolean terminarVisita = false;
	AseguramientoVisita aseguramiento;
    ISetDatos dtReportesTerminarVisita;
    ArrayList<String> ReportesTerminarVisitaFaltaMostrarPregunta = new ArrayList<>();
	public static boolean ImpTerminarVisita = false;
	static boolean NFCFinalizar = false;

	//NFC
	private NfcAdapter nfcAdapter;
	private PendingIntent nfcPendingIntent;
	private IntentFilter writeTagFilters[];
	private boolean NFCleido = false;

	private int codigoLeido = 0;
    private int solicitarContrasenaCobranza = 0;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		String accion = getIntent().getAction();
		if (getIntent().getSerializableExtra("parametros") != null)
			parametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
		setContentView(R.layout.seleccion_actividades_visita);
		deshabilitarBarra(true);
		crearVisita();
		mPresenta = new SeleccionarActividadesVisita(this, accion);
		mPresenta.iniciar();

		TextView lblDia = (TextView) findViewById(R.id.txtDia);
		TextView lblRuta = (TextView) findViewById(R.id.txtRuta);
		TextView lblCliente = (TextView) findViewById(R.id.txtCliente);

		lblDia.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
		lblRuta.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion);

		Cliente oClienteAct = (Cliente) Sesion.get(Campo.ClienteActual);

		lblCliente.setText(Mensajes.get("XCliente") + ": " + oClienteAct.RazonSocial);

        if (Sesion.get(Campo.SolicitarContrasenaCobranza) == null || Sesion.get(Campo.SolicitarContrasenaCobranza).equals(""))
            Sesion.set(Campo.SolicitarContrasenaCobranza, "1");

		try{
            dtReportesTerminarVisita = Consultas.ConsultasValorReferencia.obtenerValoresReferenciaVariosFiltros("REPORTEA", "", "", "'TerminarVisita'", "cast(VAVClave as integer)");
            while(dtReportesTerminarVisita.moveToNext()){
                ReportesTerminarVisitaFaltaMostrarPregunta.add(dtReportesTerminarVisita.getString("VavClave")+"-"+dtReportesTerminarVisita.getString("Descripcion"));
            }

			aseguramiento = Consultas.ConsultarAseguramientoVisita.obtenerAseguramientoPorVendedor((Vendedor) Sesion.get(Sesion.Campo.VendedorActual));
			if(aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.NFC_INI_FIN  || aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.COD_BARRAS_NFC_INI_FIN || aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.NFC_INI_FIN_ATM_VISITA){
				checarNFC();
			}
		}catch(Exception e){
			e.printStackTrace();
		}

		mostrarMensajesCliente();
	}

	public void checarNFC(){
		nfcAdapter = NfcAdapter.getDefaultAdapter(this);
		if (nfcAdapter != null) {
			//tiene NFC
			if(!nfcAdapter.isEnabled()){
				//NFC apagado
				mostrarPreguntaSiNo(Mensajes.get("P0249"),3);
			}else {
				habilitarNFC();
			}
		}
	}

	public void habilitarNFC(){
		nfcPendingIntent = PendingIntent.getActivity(this, 0, new Intent(this, getClass()).addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP), 0);
		IntentFilter tagDetected = new IntentFilter(NfcAdapter.ACTION_TAG_DISCOVERED);
		tagDetected.addCategory(Intent.CATEGORY_DEFAULT);
		writeTagFilters = new IntentFilter[] { tagDetected };
	}

	public void mostrarConfiguracionNFC(){
		if (android.os.Build.VERSION.SDK_INT >= 16) {
			startActivityForResult(new Intent(Settings.ACTION_NFC_SETTINGS), Enumeradores.Solicitudes.SOLICITUD_CONFIGURACION_NFC);
		} else {
			startActivityForResult(new Intent(Settings.ACTION_WIRELESS_SETTINGS), Enumeradores.Solicitudes.SOLICITUD_CONFIGURACION_NFC);
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				/*guardarVisita();
				finalizar();
				iniciarActividad(IAtencionClientes.class, false);*/
				terminarVisita();
                EnvioParcialAutomatico();
				return true;
				/*
				 * case KeyEvent.KEYCODE_SEARCH: //temporal, quitar de aqui
				 * HashMap<String, String> parametros = new HashMap<String,
				 * String>(); parametros.put("Esquema", Mensajes.get("XTodos"));
				 * parametros.put("Producto", ""); //pasarle el producto que se
				 * va a buscar
				 * iniciarActividadConResultado(IBuscaProducto.class, 0, "",
				 * parametros); //iniciarActividad(IBuscaProducto.class, false);
				 */
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.menu_actividades_visita, menu);
		menu.getItem(0).setTitle(Mensajes.get("XTerminarVisita"));
        menu.getItem(1).setTitle(Mensajes.get("XReportes"));
		menu.getItem(2).setTitle(Mensajes.get("XVistaCredito"));
		menu.getItem(3).setTitle(Mensajes.get("XListaPrecio"));
		menu.getItem(4).setTitle(Mensajes.get("XBackOrder"));
		menu.getItem(4).setVisible(false);
		try{
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("MostrarPedidosBckOrder")) {
				if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("MostrarPedidosBckOrder").equalsIgnoreCase("1")) {
					menu.getItem(4).setVisible(true);
				}
			}
		}
		catch(Exception ex){

		}
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{
		switch (item.getItemId())
		{
			case R.id.terminar:
				try
				{
					/*if(guardarVisita()){
						finalizar();
						iniciarActividad(IAtencionClientes.class, false);	
					}*/

					terminarVisita();
					EnvioParcialAutomatico();
				}
				catch (Exception ex)
				{
					ex.printStackTrace();
				}
				return true;
            case R.id.consultar_reporte:
                Sesion.set(Campo.FiltroTiposReportes, "'VISITA','NO DEFINIDO'");
                iniciarActividad(IConsultaReporte.class, null, null, false);
                return true;
			case R.id.vista_credito:
				mostrarVistaCredito();
				return true;
			case R.id.listadoPrecios:
				mostrarMensajeImpresion();
				return true;
			case R.id.backorder:
				iniciarActividad(ISeleccionPedidoBackOrder.class, null, null, false);
				return true;
			default:
				return super.onOptionsItemSelected(item);
		}
	}
	
	public void terminarVisita() {
		if (validarTiempoCliente() && validarPedidoAdicional()) {
			try {
				Consultas.ConsultasVentasInconsistentes.eliminarVentasInconsistentes();
				ArrayList<TransProd> TRPResultado = null;
				if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == com.amesol.routelite.presentadores.Enumeradores.TiposModulos.REPARTO) {
					TRPResultado = Consultas.ConsultasVentasInconsistentes.regresaVentasInconsistentes();
				} else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA) {
					TRPResultado = Consultas.ConsultasVentasInconsistentes.regresaPreventasInconsistentes();
				}
				if (TRPResultado != null && TRPResultado.size() > 0) {
					for (TransProd t : TRPResultado) {
						Transacciones.Pedidos.cancelarPedidoInconsistente(t);
						String text = "Ocurrió un problema en la aplicación, ten en cuenta las acciones realizadas en el último pedido. ";
						SpannableStringBuilder biggerText = new SpannableStringBuilder(text);
						biggerText.setSpan(new RelativeSizeSpan(3f), 0, text.length(), 0);
						Toast toast = Toast.makeText((Activity) this, biggerText, Toast.LENGTH_LONG);
						toast.setGravity(Gravity.CENTER | Gravity.CENTER_HORIZONTAL, 0, 0);
						toast.show();
						toast.show();
					}
				}
			} catch (Exception ex) {
				Toast.makeText((Activity) this, "Error al revisar incosistencias ", Toast.LENGTH_LONG).show();
			}

			/*CAI 4978*/
			if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("ValidarPromoFinVisita")) {
				try {
					if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("ValidarPromoFinVisita").toString().equals(1)){
						Visita vis = (Visita) Sesion.get(Campo.VisitaActual);
						ISetDatos Recalcular = Consultas.ConsultasPromociones.obtenerVentasARecalcular(vis.VisitaClave);

						Impuesto[] listaImpuestos;
						Short tipoImpuesto = 1;
						int Recalculos = 0;

						while (Recalcular.moveToNext()) {
							Recalculos += 1;
							TransProd T = new TransProd();
							T.TransProdID = Recalcular.getString("TransProdID");
							BDVend.recuperar(T);

							TransProdDetalle TD = new TransProdDetalle();
							TD.TransProdID = Recalcular.getString("TransProdID");
							TD.TransProdDetalleID = Recalcular.getString("TransProdDetalleId");
							BDVend.recuperar(TD);

							TD.DescuentoImp =  Consultas.ConsultasPromociones.obtenerImportePromocion(TD.TransProdID, TD.TransProdDetalleID);
							TD.Subtotal = (TD.Precio * TD.Cantidad) - TD.DescuentoImp;
							if (TD.Precio > 0) {
								listaImpuestos = Impuestos.Buscar(TD.ProductoClave, tipoImpuesto);
								TD.Impuesto = Impuestos.Calcular(listaImpuestos, TD.getSubTotal(), TD.Precio, TD.getCantidad());
							}else
								TD.Impuesto = (float)0;
							TD.Total = TD.Subtotal + TD.Impuesto;

							ISetDatos ImpuestosDuplicados = Consultas.ConsultasPromociones.obtenerImpuestosDuplicados(TD.TransProdID, TD.TransProdDetalleID);
							while (ImpuestosDuplicados.moveToNext()) {
								String TPDImpuestoId = Consultas.ConsultasPromociones.obtenerImpuestoDetalle(TD.TransProdID, TD.TransProdDetalleID, ImpuestosDuplicados.getString("ImpuestoClave"));
								TPDImpuesto TI = new TPDImpuesto();
								TI.TransProdID = TD.TransProdID;
								TI.TransProdDetalleID = TD.TransProdDetalleID;
								TI.ImpuestoClave = ImpuestosDuplicados.getString("ImpuestoClave");
								TI.TPDImpuestoID = TPDImpuestoId;
								BDVend.recuperar(TI);

								TPDImpuestoEliminado TE = new TPDImpuestoEliminado();
								TE.TransProdID = TI.TransProdID;
								TE.TransProdDetalleID = TI.TransProdDetalleID;
								TE.ImpuestoClave = TI.ImpuestoClave;
								TE.TPDImpuestoID = TI.TPDImpuestoID;
								TE.ImpuestoPor = TI.ImpuestoPor;
								TE.ImpuestoImp = TI.ImpuestoImp;
								TE.ImpuestoPU = TI.ImpuestoPU;
								TE.ImpDesGlb = TI.ImpDesGlb;
								TE.MFechaHora = TI.MFechaHora;
								TE.MUsuarioID = TI.MUsuarioID;
								TE.Enviado = false;
								BDVend.guardarInsertar(TE);
								BDVend.eliminar(TI);
							}
							Boolean[] redondeo = new Boolean[1];
							redondeo[0]=false;
							Impuestos.RecalcularGlobal(T, redondeo);

							T.Notas = ((T.Notas == null || T.Notas == "" || T.Notas == " " ) ? "Promoción Recalculada" : T.Notas + "|Promoción Recalculada");
							T.Subtotal = Consultas.ConsultasPromociones.obtenerSubTotal(T.TransProdID);
							T.Impuesto = Consultas.ConsultasPromociones.obtenerImpuestos(T.TransProdID);
							T.Total = T.Subtotal + T.Impuesto;
							BDVend.guardarInsertar(T);
						}
						Recalcular.close();
						if(Recalculos > 0){
							String text = Mensajes.get("I0356");
							SpannableStringBuilder biggerText = new SpannableStringBuilder(text);
							biggerText.setSpan(new RelativeSizeSpan(3f), 0, text.length(), 0);
							Toast toast = Toast.makeText((Activity) this, biggerText, Toast.LENGTH_LONG);
							toast.setGravity(Gravity.CENTER | Gravity.CENTER_HORIZONTAL, 0, 0);
							toast.show();
							toast.show();
						}
					}
				}catch (Exception ex){

				}
			}
			/*CAI 4978*/

			if (!mPresenta.validaVentasContado(visita)) {
				mostrarError(Mensajes.get("E0532"));
				return;
			}

			if (((CONHist) Sesion.get(Campo.CONHist)).get("ConsignaSaldada").equals("1")) {
				String sConsignas = mPresenta.obtenerConsignasConSaldo();
				if (sConsignas.length() > 0) {
					mostrarError(Mensajes.get("E0748").replace("$0$", sConsignas));
					return;
				}
			}

			MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);

			if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == com.amesol.routelite.presentadores.Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == com.amesol.routelite.presentadores.Enumeradores.TiposModulos.REPARTO) {
				if((motConfig.get("VentasFacturas").equals("1"))){
					if (!mPresenta.validaVentasFacturadas()) {
						return;
					}
				}

			}

			if (!validarCuadreEnvase())
				return;

			if (!mPresenta.validarEncuestasAplicadas(visita))
				return;

			if (!NFCleido)
				validarFinVisita();

			if (motConfig.get("MensajeImpresion").equals("1") || ReportesTerminarVisitaFaltaMostrarPregunta.size() > 0) {
				ImpTerminarVisita = true;
				for (int i = 0; i < ReportesTerminarVisitaFaltaMostrarPregunta.size(); i++) {
					String[] split = ReportesTerminarVisitaFaltaMostrarPregunta.get(i).split("-");
					mostrarPreguntaSiNo(Mensajes.get("P0800", split[1]), 4);
					break;
				}
			}

			if (codigoLeido == 0 || (aseguramiento.TipoAseguramiento != Enumeradores.TipoAseguramiento.COD_BARRAS_INI_FIN && aseguramiento.TipoAseguramiento != Enumeradores.TipoAseguramiento.COD_BARRAS_INI_FIN_GPS && aseguramiento.TipoAseguramiento != Enumeradores.TipoAseguramiento.COD_BARRAS_NFC_INI_FIN)) {


				Runnable accion = new Runnable() {
					@Override
					public void run() {
						while (mostrandoCodigoBarras) {
							//esperar a que se cierre o lea el codigo de barras
						}
						while (!ReportesTerminarVisitaFaltaMostrarPregunta.isEmpty()) {
							//esperar a que se cierre el mensaje
						}
						if (terminarVisita) {
							runOnUiThread(new Runnable() {
								public void run() {
									if (guardarVisita()) {
										new Thread(new Runnable() {
											@Override
											public void run() {
												while (mostrandoMensajeLimiteCredito) {
													//esperar a que se cierre el mensaje
												}
												runOnUiThread(new Runnable() { //ejecutar en el thread de la ui para poder mostrar el mensaje de impresion
													@Override
													public void run() {
														finalizar();
														if (!mostrarResumenMov) {//Si se va a mostrar el resumen, no ir a Atencion a Clientes
															iniciarActividad(IAtencionClientes.class, false);
														}
													}
												});
											}
										}).start();
									}
								}
							});

						}
					}
				};
				final Thread hilo = new Thread(accion);
				hilo.start();

			/*if(guardarVisita()){
				Runnable accion = new Runnable()
				{
					@Override
					public void run()
					{
						while(mostrandoMensajeLimiteCredito){
							//esperar a que se cierre el mensaje
						}
						runOnUiThread(new Runnable()
						{ //ejecutar en el thread de la ui para poder mostrar el mensaje de impresion
							@Override
							public void run()
							{
								finalizar();
								iniciarActividad(IAtencionClientes.class, false);
							}
						});
					}
				};
				final Thread hilo = new Thread(accion);
				hilo.start();

				//finalizar();
				//iniciarActividad(IAtencionClientes.class, false);
			}*/
			}
		}
	}

    public void EnvioParcialAutomatico(){
        try{
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("EnvioAtmFinVisita", ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString())) {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("EnvioAtmFinVisita", ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString()).toString().equals("1")){
                    Sesion.set(Campo.DetonarEnvioParcialAutomatico, "1");
                }else{
                    Sesion.set(Campo.DetonarEnvioParcialAutomatico, "0");
                }
            }else{
                Sesion.set(Campo.DetonarEnvioParcialAutomatico, "0");
            }
        } catch (Exception ex) {
            mostrarError(ex.getMessage());
        }
    }

    private boolean validarCuadreEnvase(){
        try{
            Cliente cli = (Cliente) Sesion.get(Campo.ClienteActual);
            MOTConfiguracion oMC = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
            boolean ok = true;
            if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA)
                    && oMC.get("CuadreDeEnvase").toString().equals("1") && cli.Prestamo ){
                ArrayList<ProductoPrestamoCli> prestamoCli = Consultas2.ConsultasProductoPrestamoCli.recuperarProductoPrestamoCli(cli.ClienteClave);
                for(ProductoPrestamoCli prestamo : prestamoCli){
                    if(prestamo.Saldo > prestamo.SaldoCarga){
                        ok = false;
                    }
                }
                if(!ok)
                    mostrarError(Mensajes.get("E0912"));
            }
            return ok;
        }catch(Exception ex){
            mostrarError(ex.getMessage());
            ex.printStackTrace();
            return false;
        }
    }
	
	private void validarFinVisita(){
		try{
			//AseguramientoVisita aseguramiento = Consultas.ConsultarAseguramientoVisita.obtenerAseguramientoPorVendedor((Vendedor) Sesion.get(Sesion.Campo.VendedorActual));
			codigoLeido = Integer.parseInt(parametros.get("CodigoLeido").toString());
			if((aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.COD_BARRAS_INI_FIN ||
                    aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.COD_BARRAS_INI_FIN_GPS ||
                    //aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.NFC_INI_FIN ||
					aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.COD_BARRAS_NFC_INI_FIN) && (codigoLeido == 1 || codigoLeido == 2)){
				mostrandoCodigoBarras = true;
				terminarVisita = false;

				LayoutInflater inflater = (LayoutInflater) this.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
				View dialogView = inflater.inflate(R.layout.dialog_codigobarras_finvisita, null);
				AlertDialog.Builder builder = new AlertDialog.Builder(this);
				
				/*builder.setPositiveButton("Aceptar", new DialogInterface.OnClickListener()
				{
					public void onClick(DialogInterface dialog, int id)
					{
						dialog.dismiss();
					}
				});*/
				builder.setView(dialogView);
				final Dialog dialog = builder.create();
				dialog.show();
				
				dialog.setOnDismissListener(new OnDismissListener()
				{
					@Override
					public void onDismiss(DialogInterface dialog)
					{
						mostrandoCodigoBarras = false;
					}
				});
				
				TextView lblTituloGeneral = (TextView) dialogView.findViewById(R.id.lblTitulo);
				lblTituloGeneral.setText(Mensajes.get("COHCodigoBarrasCliente"));

				if (aseguramiento.TipoContrasena == 1 || aseguramiento.TipoContrasena == 2) { //Contraseña variable, permitir ingresar token si no se puede leer el codigo de barras
					ImageButton btnToken = (ImageButton) dialogView.findViewById(R.id.btnToken);
					btnToken.setOnClickListener(new View.OnClickListener() {
						@Override
						public void onClick(View v) {
							dialog.dismiss();
							iniciarActividadConResultado(IAutorizaMovimiento.class, Enumeradores.Solicitudes.SOLICITUD_AUTORIZARMOVIMIENTO, Enumeradores.Acciones.ACCION_FINALIZAR_CLIENTE_VISITA);
						}
					});

				} else {
					LinearLayout layToken = (LinearLayout)dialogView.findViewById(R.id.layToken);
					layToken.setVisibility(View.GONE);
				}
				
				final TextBoxScanner scaner = (TextBoxScanner) dialogView.findViewById(R.id.textBoxScanner);
				scaner.setOnCodigoIngresado(new OnCodigoIngresadoListener()
				{
					@Override
					public void OnCodigoIngresado(String Codigo, int codigoLeido)
					{
						Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
						if(Codigo.equals(cliente.IdElectronico)){
							/*terminarVisita = true;
							dialog.dismiss();
							finalizar();*/
							if (guardarVisita()) {

								if(!mostrandoMensajeLimiteCredito) {
									finalizar();
									dialog.dismiss();
									if (!mostrarResumenMov) {//Si se va a mostrar el resumen, no ir a Atencion a Clientes
										iniciarActividad(IAtencionClientes.class, false);
									}
								}
							}
						}else{
							mostrarAdvertencia(Mensajes.get("E0489").replace("$0$", Mensajes.get("XCliente")));
							scaner.BorrarTexto();
						}
					}
				});

				if (aseguramiento.TipoContrasena != 0 && aseguramiento.TipoAseguramiento != Enumeradores.TipoAseguramiento.COD_BARRAS_INI_FIN){
					//deshabilitar textview CAI 3901
					txtScanner.setEnabled(false);
				}

				if (aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.NFC_INI_FIN || aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.NFC_INI_FIN_ATM_VISITA ) {
					//deshabilitar boton codigo de barras cuando el aseguramiento es solo por NFC
					scaner.habilitarBotonScanner(false);
				}

				if(aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.COD_BARRAS_INI_FIN)
					txtScanner.setOcultarTexto();

			}else if ((aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.NFC_INI_FIN || aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.NFC_INI_FIN_ATM_VISITA ) && !NFCleido && codigoLeido == 1){
                mostrarError(Mensajes.get("I0298"));
                terminarVisita = false;
				checarNFC();
            }else{
				mostrandoCodigoBarras = false;
				terminarVisita = true;
			}
		}catch(Exception e){
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}

    public boolean getMostrandoMensajeLimiteCredito() {
        return mostrandoMensajeLimiteCredito;
    }

    public void setMostrandoMensajeLimiteCredito(boolean mensaje) {
        mostrandoMensajeLimiteCredito = mensaje;
    }
	
	public void iniciar()
	{
	}

	public void mostrarActividades(ModuloMovDetalle[] modulosDetalle)
	{
		GridView gridview = (GridView) findViewById(R.id.gridVisitaAct);
		gridAdapter = new ModuloGridAdapter(this, R.layout.lista_grid_cliente, modulosDetalle);
		gridview.setAdapter(gridAdapter);
		gridview.setOnItemClickListener(this);
	}

	public Activity getActivity()
	{
		return this;
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		GridView gridview = (GridView) findViewById(R.id.gridVisitaAct);
		gridview.setEnabled(true);
		if (requestCode == Enumeradores.Solicitudes.SOLICITUD_AUTORIZARMOVIMIENTO) {
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
				if (Sesion.get(Sesion.Campo.ResultadoActividad) != null)
					parametros.put("Token", Sesion.get(Sesion.Campo.ResultadoActividad));
				if (guardarVisita()) {
					if(!mostrandoMensajeLimiteCredito) {
						finalizar();
						if (!mostrarResumenMov) {//Si se va a mostrar el resumen, no ir a Atencion a Clientes
							iniciarActividad(IAtencionClientes.class, false);
						}
					}
				}
			}
		}else {
			if (actividad != null) {
				if (actividad.getTipoIndice() == TiposModuloMovDetalle.COBRANZAMULTIPLE) { // Cobranza
					if (resultCode == Resultados.RESULTADO_MAL) {
						String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
						mostrarError(mensajeError);
					}
				} else if (actividad.getTipoIndice() == TiposModuloMovDetalle.PEDIDO) {
					if (resultCode == Resultados.RESULTADO_MAL) {
						// if(data.getExtras() != null){
						String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
						if (mensajeError.startsWith("[P0086]"))
							mostrarPreguntaSiNo(mensajeError, 20);
						else
							mostrarError(mensajeError);
						// }
					}
				} else if (actividad.getTipoIndice() == TiposModuloMovDetalle.DEVOLUCIONCLIENTES) {
					if (resultCode == Resultados.RESULTADO_MAL) {
						if (data != null && data.getExtras() != null) {
							String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
							if (mensajeError.startsWith("[P0086]"))
								mostrarPreguntaSiNo(mensajeError, 20);
							else
								mostrarError(mensajeError);
						}
					}
				}
			}
		}
    }

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		GridView gridview = (GridView) findViewById(R.id.gridVisitaAct);
		if (!gridview.isEnabled()) {
			gridview.setEnabled(true);
		}
		if(mostrandoMensajeLimiteCredito)
			mostrandoMensajeLimiteCredito = false;
		
		if (tipoMensaje == 20 && respuesta == RespuestaMsg.Si){
			//no hay pedidos por surtir y contesto SI, ir a captura de pedido
			iniciarActividadConResultado(ICapturaPedido.class, 0, null);
		}else if (tipoMensaje == 3) {
			//NFC apagado
			if(respuesta.equals(RespuestaMsg.Si)){
				mostrarConfiguracionNFC();
			}
		}else if (tipoMensaje == 4){
            if (respuesta == RespuestaMsg.Si){
                try{
                    boolean BlueEncendido=false;

                    while(!BlueEncendido){
                        if (!bluetoothEncendido()) {
                            encenderBluetooth();
                            Thread.sleep(3000);
                        } else {
                            BlueEncendido=true;
                        }
                    }

                    String[] split = ReportesTerminarVisitaFaltaMostrarPregunta.get(0).split("-");

                    Recibos recibo = new Recibos();
                    List<Map<String, String>> tabla = new ArrayList<Map<String, String>>();
                    Map<String, String> registro;
                    registro = new HashMap<String, String>();
                    registro.put("_Id", split[0]);
                    registro.put("TipoRecibo", split[0]);
                    registro.put("Tipo", "TerminarVisita");
                    tabla.add(registro);

                    recibo.imprimirRecibos(tabla, false, this, (short) 0);

                    mostrarPreguntaSiNo(Mensajes.get("P0800", split[1]),4);
                } catch (ControlError e) {
                    String[] split = ReportesTerminarVisitaFaltaMostrarPregunta.get(0).split("-");
                    mostrarPreguntaSiNo(Mensajes.get("P0800", split[1]),4);
                    mostrarError(e.getMessage());
                } catch (Exception e) {
                    String[] split = ReportesTerminarVisitaFaltaMostrarPregunta.get(0).split("-");
                    mostrarPreguntaSiNo(Mensajes.get("P0800", split[1]),4);
                    mostrarError(e.getMessage());
                }
            }else{
                ReportesTerminarVisitaFaltaMostrarPregunta.remove(0);

                if(!ReportesTerminarVisitaFaltaMostrarPregunta.isEmpty()){
                    String[] split = ReportesTerminarVisitaFaltaMostrarPregunta.get(0).split("-");
                    mostrarPreguntaSiNo(Mensajes.get("P0800", split[1]),4);
                }
            }
        }else if (tipoMensaje == 100 ){
            if(respuesta == RespuestaMsg.Si){
                mPresenta.borrarImproductividad();
                mPresenta.seleccionar();
            }
        }
	}

	//	private OnClickListener mSelectActView = new OnClickListener()
	//	{
	//
	//		@Override
	//		public void onClick(DialogInterface dialog, int which)
	//		{
	//			// TODO Auto-generated method stub
	//			mPresenta.seleccionar();
	//		}
	//	};

	//	private OnItemClickListener mSeleccion = new OnItemClickListener()
	//	{
	//		public void onItemClick(AdapterView<?> parent, View v, int position, long id)
	//		{
	//			actividad = (ModuloMovDetalle) parent.getItemAtPosition(position);
	//			mPresenta.seleccionar();
	//		}
	//	};

	public ModuloMovDetalle getActividad()
	{
		return actividad;
	}

	private void crearVisita()
	{
		try
		{
			visita = new Visita();
			visitaHist = new VisitaHist();

			if (parametros.containsKey("visitaClave"))
			{
				visitaClave = (String) parametros.get("visitaClave");
				visita.VisitaClave = visitaClave;
                visita.DiaClave = ((Dia)Sesion.get(Campo.DiaActual)).DiaClave;
				BDVend.recuperar(visita);
				
				//REcuperar el punto GPS
				puntoGPS = Consultas.ConsultasPuntoGPS.obtenerPuntoGPS(visitaClave, visita.DiaClave);			
			}
			else
			{
				if (parametros.containsKey("nuevaVisita"))
				{
					Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

					Agenda agenda = Consultas.ConsultasAgenda.obtenerAgendaPorDiaClienteRutaVendedor(((Dia) Sesion.get(Campo.DiaActual)).DiaClave, ((Ruta) Sesion.get(Campo.RutaActual)).RUTClave, ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId, cliente.ClienteClave);
					if (agenda != null)
					{
						agenda.Visitado = 1; // marcar como visitado
						BDVend.guardarInsertar(agenda);
					}
				}

				visita.VisitaClave = KeyGen.getId();
				visita.DiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
				visita.ClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
				visita.VendedorId = ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId;
				visita.RUTClave = ((Ruta) Sesion.get(Campo.RutaActual)).RUTClave;
				visita.Numero = Consultas.ConsultasVisita.obtenerConsecutivo((Dia) Sesion.get(Campo.DiaActual));
				visita.FechaHoraInicial = Generales.getFechaHoraActual();
				visita.FechaHoraFinal = visita.FechaHoraInicial;
				visita.TipoEstado = 1; // activo
				visita.FueraFrecuencia = (Boolean) parametros.get("FueraFrecuencia");
				visita.CodigoLeido = Integer.parseInt(parametros.get("CodigoLeido").toString()); // (Boolean)parametros.get("CodigoLeido");
				visita.GPSLeido = (Boolean) parametros.get("GPSLeido");
				visita.DistanciaGPS = (Float) parametros.get("DistanciaGPS");
                if (parametros.containsKey("Token") && parametros.get("Token") != null)
                    visita.Token = parametros.get("Token").toString();
                if (parametros.containsKey("ActivosAsignados") && parametros.get("ActivosAsignados") != null)
                    visita.ActivosAsignados = Integer.parseInt(parametros.get("ActivosAsignados").toString());
                if (parametros.containsKey("ActivosAsegurados") && parametros.get("ActivosAsegurados") != null)
                    visita.ActivosAsegurados = Integer.parseInt(parametros.get("ActivosAsegurados").toString());

				visita.Enviado = false;
				visita.MFechaHora = Generales.getFechaHoraActual();
				visita.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				visita.HorarioProgramadoVisita = Consultas.ConsultasAgenda.horarioProgramado(visita.DiaClave, visita.RUTClave, visita.ClienteClave);

				BDVend.guardarInsertar(visita);

				if (visita.GPSLeido)
				{
					puntoGPS = new PuntoGPS();
					puntoGPS.PuntoGPSId = KeyGen.getId();
					puntoGPS.CoordenadaX = ((Double) parametros.get("LongitudGPS")).floatValue();
					puntoGPS.CoordenadaY = ((Double) parametros.get("LatitudGPS")).floatValue();
					puntoGPS.DiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
					puntoGPS.DiaClave1 = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
					puntoGPS.RUTClave = ((Ruta) Sesion.get(Campo.RutaActual)).RUTClave;
					puntoGPS.VisitaClave = visita.VisitaClave;
					puntoGPS.MFechaHora = Generales.getFechaHoraActual();
					puntoGPS.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
					puntoGPS.Enviado = false;
					BDVend.guardarInsertar(puntoGPS);
				}

				BDVend.commit();
			}

			visitaHist.VisitaHistId = KeyGen.getId();
			visitaHist.VisitaClave = visita.VisitaClave;
			visitaHist.FechaHoraInicial = Generales.getFechaHoraActual();
			visitaHist.FechaHoraFinal = visitaHist.FechaHoraInicial;
			visitaHist.Enviado = false;

			visita.VisitaHist.add(visitaHist);

			BDVend.commit();
			
			Sesion.set(Campo.VisitaActual, visita);

		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}

	private boolean guardarVisita()
	{
		try
		{
			if(!mPresenta.validarLimiteCreditoCliente(visita))
				return false;

			if (Consultas.ConsultasVisita.hayMovimientos(((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave))
			{
				// si hay movimientos guardar la visita
				Usuario usuario = (Usuario) Sesion.get(Campo.UsuarioActual);
				/*
				 * if(parametros.containsKey("nuevaVisita")){ Cliente cliente =
				 * new Cliente(); cliente.ClienteClave =
				 * Sesion.get(Campo.ClienteActual).toString();
				 * BDVend.recuperar(cliente); Agenda agenda =
				 * Consultas.ConsultasAgenda
				 * .obtenerAgendaPorDiaClienteRutaVendedor
				 * ((Dia)Sesion.get(Campo.DiaActual),
				 * (Ruta)Sesion.get(Campo.RutaActual),
				 * (Vendedor)Sesion.get(Campo.VendedorActual), cliente);
				 * if(agenda!=null){ agenda.Visitado = 1; //marcar como visitado
				 * BDVend.guardarInsertar(agenda); } }
				 */
				//recuperar la visita por si cambio algo
				BDVend.recuperar(visita);
				if (visita.Enviado){
					VisitaModificada visitaModificada = new VisitaModificada();
					visitaModificada.VisitaClave = visita.VisitaClave;
					visitaModificada.DiaClave = visita.DiaClave;
					visitaModificada.FechaHoraFinal = Generales.getFechaHoraActual();
					visitaModificada.TipoEstado = 1; //El Services Central modifica la fecha final
					visitaModificada.Enviado = false;
					if (!BDVend.existe(visitaModificada)) {
						BDVend.guardarInsertar(visitaModificada);
					}
				}
				if (parametros.containsKey("Token") && parametros.get("Token") != null)
					visita.Token = parametros.get("Token").toString();
				visita.FechaHoraFinal = Generales.getFechaHoraActual();
				visita.MFechaHora = Generales.getFechaHoraActual();
				visita.MUsuarioID = usuario.USUId;
				visita.VisitaHist.get(visita.VisitaHist.size() - 1).MFechaHora = visita.MFechaHora;
				visita.VisitaHist.get(visita.VisitaHist.size() - 1).MUsuarioID = visita.MUsuarioID;
				visita.VisitaHist.get(visita.VisitaHist.size() - 1).FechaHoraFinal = visita.FechaHoraFinal;
				BDVend.guardarInsertar(visita);
				
				mPresenta.validarLimiteCreditoCliente(visita);

				if (visita.GPSLeido)
				{
					if (!parametros.containsKey("visitaClave"))
					{
						puntoGPS.MFechaHora = Generales.getFechaHoraActual();
						puntoGPS.MUsuarioID = usuario.USUId;
						BDVend.guardarInsertar(puntoGPS);
					}
				} 

				//no puede haber improductividad de visita porque hay movimientos capturados
				if (Consultas.ConsultasImproductividades.existeImproductividadVisita(visita.DiaClave, visita.ClienteClave)){
					Agenda agenda = Consultas.ConsultasAgenda.obtenerAgendaPorDiaClienteRutaVendedor(visita.DiaClave, visita.RUTClave, visita.VendedorId, visita.ClienteClave );
					agenda.TipoMotivo = null;
					agenda.Comentario = null;					
					BDVend.guardarInsertar(agenda);
				}

                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ValidarImprodEnVisita")) {
                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ValidarImprodEnVisita").equalsIgnoreCase("0")) {
                        if (Consultas.ConsultasTransProd.existenVentas(visita.DiaClave, visita.ClienteClave)) {
                            Consultas.ConsultasImproductividades.eliminarImproductividadVenta(visita.ClienteClave, visita.DiaClave, visita.VendedorId, visita.RUTClave);
                        }
                    }
                }
				
				MOTConfiguracion motConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
				if (motConf.get("ResumenMovimientos").equals("1"))
				{
					HashMap<String, Object> oParametros = new HashMap<String, Object>();
					oParametros.put("visita", Mensajes.get("XVisita") + " " + visita.Numero);
					iniciarActividadConResultado(IResumenMovVisita.class, 0, "", oParametros);
                    mostrarResumenMov = true;
				}

                /*private Vista getVista() {
        return this;
    }*/

			}
			else
			{
					if(!validarImproductividad())//validamos la improductividad, si esta apagada dejara salir sin problemas de lo contrario mandara un mensaje de quebe realizar la iproductividad ya que no se hiso ningun movimiento
					{
						// si no hay movimientos, eliminar la visita
						BDVend.recuperar(visita); //Se vuelve a recuperar por si ya fue enviada
						if (visita.Enviado){
							VisitaModificada visitaModificada = new VisitaModificada();
							visitaModificada.VisitaClave = visita.VisitaClave;
							visitaModificada.DiaClave = visita.DiaClave;
							visitaModificada.FechaHoraFinal = Generales.getFechaHoraActual();
							visitaModificada.TipoEstado = 0; //El Services Central la elimina
							visitaModificada.Enviado = false;
							if (!BDVend.existe(visitaModificada)) {
								BDVend.guardarInsertar(visitaModificada);
							}
						}
						BDVend.eliminar(visita);
						BDVend.eliminar(visita.VisitaHist.get(visita.VisitaHist.size() - 1));
						if (visita.GPSLeido){
							if (puntoGPS != null){
								BDVend.eliminar(puntoGPS);
							}
						}
		
						Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
		
						Agenda agenda = Consultas.ConsultasAgenda.obtenerAgendaPorDiaClienteRutaVendedor(((Dia) Sesion.get(Campo.DiaActual)).DiaClave, ((Ruta) Sesion.get(Campo.RutaActual)).RUTClave, ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId, cliente.ClienteClave);
						if (agenda != null && !ConsultasVisita.existenVisitas(((Dia) Sesion.get(Campo.DiaActual)).DiaClave, cliente.ClienteClave))
						{
							// solo marcar como no visitado si no existen mas visitas
							agenda.Visitado = 2; // marcar como no visitado
							BDVend.guardarInsertar(agenda);
						}
					}
					else
					{
						mostrarAdvertencia(Mensajes.get("I0269"));
						return false;
					}
			}

			BDVend.commit();
			Consultas.ConsultasVisita.eliminarVisitasSinMovimientos(false);
			return true;
		}
		catch (Exception e)
		{
			if (e instanceof NullPointerException) {
				mostrarError("Referencia a objeto vacío");
			}else{
				mostrarError(e.getMessage());
			}			
			e.printStackTrace();
			return false;
		}
	}

	@Override
	public void mostrarActividades(ModuloMov[] modulos)
	{
		// TODO Auto-generated method stub
		// ListView lista = (ListView) findViewById(R.id.list);
		// ModulosAdapter adapter = new ModulosAdapter(this,R.layout,
		// modulos,mSeleccion);
		// lista.setAdapter(adapter);
	}

	@Override
	public void onItemClick(AdapterView<?> adapter, View arg1, int position, long arg3)
	{
		GridView gridview = (GridView) findViewById(R.id.gridVisitaAct);
		gridview.setEnabled(false);

		actividad = (ModuloMovDetalle) gridAdapter.getItem(position);

        if (actividad.getTipoIndice() == TiposModuloMovDetalle.COBRANZASIMPLE || actividad.getTipoIndice() == TiposModuloMovDetalle.COBRANZAMULTIPLE)
        {
            validarPermisoAcceso(actividad.getTipoIndice(), Enumeradores.TipoPermiso.ACCESAR);
        }
        else
        {
            mPresenta.seleccionar();
        }
	}
	
	public boolean validarImproductividad ()
	{
		boolean pasa = false;
		String forzarCapturaImpro = (String) ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ForzarCapturaImpro");
        if(forzarCapturaImpro.equals("1"))
        {
        	pasa = true;
        }
		return pasa;
	}

	@Override
	protected void onNewIntent(Intent intent) {
		super.onNewIntent(intent);
		if(NfcAdapter.ACTION_TAG_DISCOVERED.equals(intent.getAction())){
				Tag tag = intent.getParcelableExtra(NfcAdapter.EXTRA_TAG);
				String codigoCliente = read(tag);
				if(codigoCliente != null) {
                    codigoCliente = EncriptaDesencripta.encripta(codigoCliente);
					Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
					if(codigoCliente.equals(cliente.IdElectronico)){
						/*if(dialog != null)
							dialog.dismiss();
						mostrandoCodigoBarras = false;
						readNfc = false;*/
						mostrandoCodigoBarras = false;
						terminarVisita = true;
						NFCleido = true;
						terminarVisita();
					}else{
						mostrarAdvertencia(Mensajes.get("E0489").replace("$0$", Mensajes.get("XCliente")));
					}
				}
                else{
                    Toast.makeText(this, Mensajes.get("XNFCErrorLectura"), Toast.LENGTH_LONG).show();
                }
		}
	}

	/*******************METODOS PARA FUNCIONALIDAD NFC*******************/
	@Override
	protected void onResume() {
		super.onResume();
		GridView gridview = (GridView) findViewById(R.id.gridVisitaAct);
		gridview.setEnabled(true);
		if(AtenderClientes.aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.NFC_INI_FIN_ATM_VISITA){
			if(NFCFinalizar == true)
				terminarVisita();
		}
		if (nfcAdapter != null)
			if(nfcAdapter.isEnabled())
				WriteModeOn();
	}

	@Override
	protected void onPause() {
		super.onPause();
		if (nfcAdapter != null)
			if(nfcAdapter.isEnabled())
				WriteModeOff();
	}

	private String read(Tag tag) {

		try {
			String codigoCliente = null;
			// Get an instance of Ndef for the tag.
			Ndef ndef = Ndef.get(tag);

			if(ndef != null){

				// Enable I/O
				ndef.connect();
				// Write the message
				//ndef.getNdefMessage();

				NdefRecord[] rawMsgs = ndef.getNdefMessage().getRecords();
				int numRecords = rawMsgs.length;

				if (numRecords > 0) {
					for(int i=0;i<numRecords;i++) {
						String[] parts =  new String(rawMsgs[i].getPayload()).split("@");
						//Log.i(TAG, Integer.toString(i));
						codigoCliente = parts[parts.length-1];
						//Log.i(TAG,codigoCliente);
					}
				}


				//Toast.makeText(this, new String(ndef.getNdefMessage().toByteArray()),Toast.LENGTH_SHORT).show();
				// Close the connection
				ndef.close();

				return  codigoCliente;
			}
			else
				return null;
		} catch (Exception e){
			return null;
		}
	}

	private void WriteModeOn(){
		//writeMode = true;
		nfcAdapter.enableForegroundDispatch(this, nfcPendingIntent, writeTagFilters, null);
	}

	private void WriteModeOff(){
		//writeMode = false;
		nfcAdapter.disableForegroundDispatch(this);
	}

	public void mostrarMensajesCliente(){
		if (parametros.get("VisitaClave") != 0){ mostrarAdvertencia(Mensajes.get("E1011"));	}
		try
		{
			ISetDatos mensajesCliente = Consultas.ConsultasCliente.obtenerMensajes(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave);

			while(mensajesCliente.moveToNext())
			{
				mostrarMensajeConTitulo(mensajesCliente.getString("Descripcion"), Mensajes.get("XMensajeDelCliente"), 1);
				Consultas.ConsultasCliente.actualizarEstadoMensaje(mensajesCliente.getString("ClienteMensajeId"));
			}

		}catch (Exception e)
		{
			e.printStackTrace();
		}
	}

	/*******************METODOS PARA FUNCIONALIDAD NFC*******************/

    @Override
    public void impresionFinalizada(boolean impresionExitosa, String mensajeError) {
        if (!mensajeError.equals(""))
            Toast.makeText(getApplicationContext(), mensajeError, Toast.LENGTH_LONG).show();

        setResult(Enumeradores.Resultados.RESULTADO_BIEN);

        quitarProgreso();
    }

    private void validarPermisoAcceso(int tipoIndice, int tipoPermiso)//Metodo que valida permisos ldelatorre
    {
        boolean validar = true;
        try
        {
            if (Sesion.get(Sesion.Campo.ConfigParametro) != null && ((ConfigParametro)Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("ValidarAcceso", Integer.toString(tipoIndice)) && ((ConfigParametro)Sesion.get(Sesion.Campo.ConfigParametro)).get("ValidarAcceso", Integer.toString(tipoIndice)).equals("1")){
                if (tipoIndice == TiposModuloMovDetalle.COBRANZASIMPLE || tipoIndice == TiposModuloMovDetalle.COBRANZAMULTIPLE){
                    solicitarContrasenaCobranza = 1;
                }
            }
            else {
                solicitarContrasenaCobranza = Integer.parseInt(String.valueOf(Sesion.get(Campo.SolicitarContrasenaCobranza)));
            }

            String id = "TINDMMD" + tipoIndice;
            String permiso = Consultas.ConsultasPermisos.validarPermisos(id).trim();
            String contrasenaPara = ValoresReferencia.getDescripcion("TINDMMD", String.valueOf(tipoIndice));

            if (permiso.equals("1"))
            {
                validar = true;
            }
            else
            {
                if (tipoPermiso == Enumeradores.TipoPermiso.ACCESAR && permiso.equals("") && ((tipoIndice == TiposModuloMovDetalle.COBRANZASIMPLE || tipoIndice == TiposModuloMovDetalle.COBRANZAMULTIPLE) && solicitarContrasenaCobranza == 1) )
                {
                    solicitarAcceso(contrasenaPara, tipoIndice);
                    validar = false;
                }
            }
            if(validar)
            {
                mPresenta.seleccionar();
            }

        }
        catch (Exception e)
        {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }

    public void solicitarAcceso(String contrasenaPara, final int tipoIndice)//Metodo que valida permisos ldelatorre
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
        alert.setTitle(contrasenaPara).setView(textEntryView).setPositiveButton(Mensajes.get("BTContinuar"), new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int whichButton) {
                String clave = txtUser.getText().toString();
                String pass = txtPass.getText().toString();
                if (validarInformacion(clave, pass)) {
                    Usuario usuario = null;
                    try {
                        usuario = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(clave);
                    } catch (Exception e) {
                        e.printStackTrace();
                        mostrarError(e.getMessage());
                    }

                    if ((usuario == null) || (!EncriptaDesencripta.encripta(pass).equals(usuario.ClaveAcceso))) {
                        mostrarAdvertencia(Mensajes.get("MDB050601"));

                    } else {
                        if (!usuario.PERClave.equals("Admin")) {
                            mostrarAdvertencia(Mensajes.get("I0271"));
                        } else {
                            try {
                                if (tipoIndice == TiposModuloMovDetalle.COBRANZASIMPLE || tipoIndice == TiposModuloMovDetalle.COBRANZAMULTIPLE){
                                    Sesion.set(Campo.SolicitarContrasenaCobranza, "0");
                                }
                            }catch(Exception e){}

                            mPresenta.seleccionar();
                        }
                    }
                }
            }
        }).setNegativeButton(Mensajes.get("BTRegresar"), new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int whichButton) {
                // regresar();
            }
        }).setOnKeyListener(new DialogInterface.OnKeyListener() {

            @Override
            public boolean onKey(DialogInterface dialog, int keyCode, KeyEvent event) {
                switch (keyCode) {
                    case KeyEvent.KEYCODE_BACK:
                        //regresar();
                        break;
                }
                return false;
            }
        });
        alert.show();

        //return vali;
    }

    private boolean validarInformacion(String id, String pass)//Metodo que valida permisos ldelatorre
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

	public boolean validarPedidoAdicional()
	{
		Boolean valido = true;
		try {
			if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("CapturarPedAdSinModVenta")) {
				Cliente cli = (Cliente) Sesion.get(Campo.ClienteActual);
				String param = ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("CapturarPedAdSinModVenta");
				param = param.replace("|", "','");
				if (Consultas.ConsultasPedidosAdicional.obtenerClientesEsquemas(param, cli.ClienteClave) > 0){
					Visita vis = (Visita) Sesion.get(Campo.VisitaActual);
					if(Consultas.ConsultasPedidosAdicional.existeVentas(vis.VisitaClave)) {
						if (Consultas.ConsultasPedidosAdicional.obtenerPedAdicionalVacios(vis.VisitaClave, true) > 0 || Consultas.ConsultasPedidosAdicional.obtenerPedAdicionalVacios(vis.VisitaClave, false) == 0) {
							valido = false;
							mostrarError(Mensajes.get("I0340").replace("$0$", Mensajes.get("XPedidoAdicional")));
						}
					}
				}

			}
		}catch(Exception ex){
			mostrarError(ex.getMessage());
		}
		return valido;
	}

	public boolean validarTiempoCliente()
	{
		boolean valido = true;
		try
		{
			BDVend.recuperar(visita);
			Date fechaFinal = Generales.getFechaHoraActual();

			double tiempoVisita = (fechaFinal.getTime() - visita.FechaHoraInicial.getTime()) / (60.0 * 1000.0);
			int tiempoMin = Consultas.ConsultasCliente.obtenerTiempoMinVisita();

			if(tiempoMin == 0 || (tiempoVisita >= tiempoMin && tiempoVisita > 0))
			{
				valido = true;
			}
			else
			{
				mostrarAdvertencia(Mensajes.get("E1010").replace("$0", String.valueOf(tiempoMin)));
				valido = false;
			}
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
			ex.printStackTrace();
		}
		return valido;
	}

	public void mostrarMensajeImpresion(){
		DialogoAlerta dialogo = new DialogoAlerta(this);
		dialogo.setMessage("Que desea realizar?");
		dialogo.setCancelable(false);
		String msgSi = "Imprimir";
		String msgNo = "Mostrar";

		dialogo.setButton(msgSi, new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int id)
			{
				try {
					mPresenta.imprimirListaPrecios();
				}catch (Exception ex){
					mostrarError(ex.getMessage());
				}
				dialog.dismiss();
			}
		});
		dialogo.setButton2(msgNo, new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int id)
			{
				dialog.cancel();
				mostrarListaPrecio();
				//dialog.cancel();
			}
		});
		dialogo.show();
	}

	public void mostrarListaPrecio(){
		try{
			LayoutInflater inflater = (LayoutInflater) this
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);

			final View listaPrecios = inflater.inflate(R.layout.dialog_listas_precios, null);

			AlertDialog.Builder builder = new AlertDialog.Builder(this);
			final ListView lista_precios = (ListView) listaPrecios.findViewById(R.id.lstAgenda);

			String sClienteClave = ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave;

			ISetDatos precios = Consultas.ConsultasReportesNGO.obtenerListasPrecios(sClienteClave);
			String listaPreciosClave ="";
			if(precios.moveToFirst())
				listaPreciosClave = precios.getString("PrecioClave");

			precios = Consultas.ConsultasReportesNGO.obtenerPrecios(listaPreciosClave);
			Cursor cPrecios = (Cursor) precios.getOriginal();
			startManagingCursor(cPrecios);

			SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple_hor3, cPrecios,
					new String[] { "Descripcion", "PRUTipoUnidad","Precio" },
					new int[] { R.id.txtCol1, R.id.txtCol2, R.id.txtCol3 });
			adapter.setViewBinder(new vistaListasPrecios());
			lista_precios.setAdapter(adapter);
			builder.setNegativeButton(Mensajes.get("XCancelar"),new DialogInterface.OnClickListener()
			{
				@Override
				public void onClick(DialogInterface dialog, int which)
				{
					dialog.dismiss();
				}

			});
			builder.setView(listaPrecios);
			final Dialog dialog = builder.create();
			/*dialog.setOnShowListener(new DialogInterface.OnShowListener() {
				@Override
				public void onShow(DialogInterface dialog) {
					dialog.dismiss();
				}
			});*/
			dialog.show();


		}catch (Exception ex){
			mostrarError(ex.getMessage());
		}
	}

	private class vistaListasPrecios implements SimpleCursorAdapter.ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case R.id.txtCol2:
					TextView unidad = (TextView) view;
					unidad.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(columnIndex)));
					break;
				case R.id.txtCol3:
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

	private void mostrarVistaCredito(){
		try{
			LayoutInflater inflater = (LayoutInflater) this.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			View dialogView = inflater.inflate(R.layout.dialog_vista_credito, null);
			AlertDialog.Builder builder = new AlertDialog.Builder(this);

			builder.setPositiveButton("Aceptar", new DialogInterface.OnClickListener()
			{
				public void onClick(DialogInterface dialog, int id)
				{
					dialog.dismiss();
				}
			});

			builder.setView(dialogView);
			final Dialog dialog = builder.create();
			dialog.show();

			dialog.setOnDismissListener(new OnDismissListener()
			{
				@Override
				public void onDismiss(DialogInterface dialog)
				{
					mostrandoCodigoBarras = false;
				}
			});

			//TextView lblTituloGeneral = (TextView) dialogView.findViewById(R.id.lblTitulo);
			//lblTituloGeneral.setText(Mensajes.get("COHCodigoBarrasCliente"));

			//TextView txtCliente = (TextView) dialogView.findViewById(R.id.txtCliente);
			//TextView txtRuta = (TextView) dialogView.findViewById(R.id.txtRuta);
			//TextView txtDia = (TextView) dialogView.findViewById(R.id.txtDia);
			TextView lblLimiteCredito = (TextView) dialogView.findViewById(R.id.lblLimiteCredito);
			TextView txtLimiteCredito = (TextView) dialogView.findViewById(R.id.txtLimiteCredito);
			TextView lblDiasCredito = (TextView) dialogView.findViewById(R.id.lblDiasCredito);
			TextView txtDiasCredito = (TextView) dialogView.findViewById(R.id.txtDiasCredito);
			TextView lblSaldoDocumentos = (TextView) dialogView.findViewById(R.id.lblSaldoDocumentos);
			TextView txtSaldoDocumentos = (TextView) dialogView.findViewById(R.id.txtSaldoDocumentos);
			TextView lblSaldoVencido = (TextView) dialogView.findViewById(R.id.lblSaldoVencido);
			TextView txtSaldoVencido = (TextView) dialogView.findViewById(R.id.txtSaldoVencido);
			TextView lblCreditoDisponible = (TextView) dialogView.findViewById(R.id.lblCreditoDisponible);
			TextView txtCreditoDisponible = (TextView) dialogView.findViewById(R.id.txtCreditoDisponible);

			//txtCliente.setVisibility(View.GONE);
			//txtRuta.setVisibility(View.GONE);
			//txtDia.setVisibility(View.GONE);
			/*Cliente oClienteAct = (Cliente) Sesion.get(Campo.ClienteActual);
			txtCliente.setText(Mensajes.get("XCliente") + ": " + oClienteAct.RazonSocial);
			txtRuta.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
			txtDia.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion);*/

			lblLimiteCredito.setText(Mensajes.get("XALimiteCredito"));
			lblDiasCredito.setText(Mensajes.get("CFVDiasCredito"));
			lblSaldoDocumentos.setText(Mensajes.get("XSaldoDocumentos"));
			lblSaldoVencido.setText(Mensajes.get("XSaldoVencido"));
			lblCreditoDisponible.setText(Mensajes.get("XCreditoDisponible"));

			mPresenta.obtenerInformacionDeCredito(visita);
			txtLimiteCredito.setText(Generales.getFormatoDecimal(mPresenta.limiteCredito, 2));
			txtDiasCredito.setText(String.valueOf(mPresenta.diasCredito));
			txtSaldoDocumentos.setText(Generales.getFormatoDecimal(mPresenta.saldoDocumentos, 2));
			txtSaldoVencido.setText(Generales.getFormatoDecimal(mPresenta.saldoVencido, 2));
			txtCreditoDisponible.setText(Generales.getFormatoDecimal(mPresenta.creditoDisponible, 2));

		}catch(Exception e){
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}

	private void mostrarBackOrderDisp(){
		try{
			LayoutInflater inflater = (LayoutInflater) this.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			View dialogView = inflater.inflate(R.layout.dialog_vista_credito, null);
			AlertDialog.Builder builder = new AlertDialog.Builder(this);

			builder.setPositiveButton("Aceptar", new DialogInterface.OnClickListener()
			{
				public void onClick(DialogInterface dialog, int id)
				{
					dialog.dismiss();
				}
			});

			builder.setView(dialogView);
			final Dialog dialog = builder.create();
			dialog.show();

			dialog.setOnDismissListener(new OnDismissListener()
			{
				@Override
				public void onDismiss(DialogInterface dialog)
				{
					mostrandoCodigoBarras = false;
				}
			});

			//TextView lblTituloGeneral = (TextView) dialogView.findViewById(R.id.lblTitulo);
			//lblTituloGeneral.setText(Mensajes.get("COHCodigoBarrasCliente"));

			//TextView txtCliente = (TextView) dialogView.findViewById(R.id.txtCliente);
			//TextView txtRuta = (TextView) dialogView.findViewById(R.id.txtRuta);
			//TextView txtDia = (TextView) dialogView.findViewById(R.id.txtDia);
			TextView lblLimiteCredito = (TextView) dialogView.findViewById(R.id.lblLimiteCredito);
			TextView txtLimiteCredito = (TextView) dialogView.findViewById(R.id.txtLimiteCredito);
			TextView lblDiasCredito = (TextView) dialogView.findViewById(R.id.lblDiasCredito);
			TextView txtDiasCredito = (TextView) dialogView.findViewById(R.id.txtDiasCredito);
			TextView lblSaldoDocumentos = (TextView) dialogView.findViewById(R.id.lblSaldoDocumentos);
			TextView txtSaldoDocumentos = (TextView) dialogView.findViewById(R.id.txtSaldoDocumentos);
			TextView lblSaldoVencido = (TextView) dialogView.findViewById(R.id.lblSaldoVencido);
			TextView txtSaldoVencido = (TextView) dialogView.findViewById(R.id.txtSaldoVencido);
			TextView lblCreditoDisponible = (TextView) dialogView.findViewById(R.id.lblCreditoDisponible);
			TextView txtCreditoDisponible = (TextView) dialogView.findViewById(R.id.txtCreditoDisponible);

			//txtCliente.setVisibility(View.GONE);
			//txtRuta.setVisibility(View.GONE);
			//txtDia.setVisibility(View.GONE);
			/*Cliente oClienteAct = (Cliente) Sesion.get(Campo.ClienteActual);
			txtCliente.setText(Mensajes.get("XCliente") + ": " + oClienteAct.RazonSocial);
			txtRuta.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
			txtDia.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion);*/

			lblLimiteCredito.setText(Mensajes.get("XALimiteCredito"));
			lblDiasCredito.setText(Mensajes.get("CFVDiasCredito"));
			lblSaldoDocumentos.setText(Mensajes.get("XSaldoDocumentos"));
			lblSaldoVencido.setText(Mensajes.get("XSaldoVencido"));
			lblCreditoDisponible.setText(Mensajes.get("XCreditoDisponible"));

			mPresenta.obtenerInformacionDeCredito(visita);
			txtLimiteCredito.setText(Generales.getFormatoDecimal(mPresenta.limiteCredito, 2));
			txtDiasCredito.setText(String.valueOf(mPresenta.diasCredito));
			txtSaldoDocumentos.setText(Generales.getFormatoDecimal(mPresenta.saldoDocumentos, 2));
			txtSaldoVencido.setText(Generales.getFormatoDecimal(mPresenta.saldoVencido, 2));
			txtCreditoDisponible.setText(Generales.getFormatoDecimal(mPresenta.creditoDisponible, 2));

		}catch(Exception e){
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}


}
