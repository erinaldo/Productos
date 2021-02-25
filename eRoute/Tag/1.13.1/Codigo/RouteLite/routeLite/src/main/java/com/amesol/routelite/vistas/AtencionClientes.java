package com.amesol.routelite.vistas;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.PendingIntent;
import android.app.ProgressDialog;
import android.app.SearchManager;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.database.Cursor;
import android.location.LocationManager;
import android.net.Uri;
import android.nfc.FormatException;
import android.nfc.NdefMessage;
import android.nfc.NdefRecord;
import android.nfc.NfcAdapter;
import android.nfc.Tag;
import android.nfc.tech.Ndef;
import android.nfc.tech.NdefFormatable;
import android.os.Bundle;
import android.provider.Settings;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;
import android.widget.Toast;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.TextBoxScanner;
import com.amesol.routelite.controles.TextBoxScanner.OnCodigoIngresadoListener;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.TipoEnvioInfo;
import com.amesol.routelite.presentadores.Enumeradores.VistaClientes;
import com.amesol.routelite.presentadores.act.AtenderClientes;
import com.amesol.routelite.presentadores.interfaces.IAtencionClientes;
import com.amesol.routelite.presentadores.interfaces.IAutorizaMovimiento;
import com.amesol.routelite.presentadores.interfaces.IConsultaIndicadores;
import com.amesol.routelite.presentadores.interfaces.IRegistroTiemposMuertos;
import com.amesol.routelite.presentadores.interfaces.IRevisionPendientes;
import com.amesol.routelite.presentadores.interfaces.ISeleccionPedidosPagoAnticipado;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.presentadores.parcelables.DatosGPS;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.EncriptaDesencripta;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.math.BigInteger;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Locale;

public class AtencionClientes extends Vista implements IAtencionClientes {

    AtenderClientes mPresenta;
    String sClienteClave;
    private OnCodigoIngresadoListener mCodigoBarras = new OnCodigoIngresadoListener() {

        public void OnCodigoIngresado(String Codigo, int codigoLeido) {
            if (Codigo.length() == 0)
                return;

            HabilitarPantalla(false);

            try {
                sClienteClave = Consultas.ConsultasCliente.validarClienteClave(Codigo);
            } catch (Exception ex) {
                ex.printStackTrace();
            }
            mPresenta.seleccionarCodigoBarras(codigoLeido, Codigo);

            HabilitarPantalla(true);
        }

    };
    private OnItemClickListener mSeleccion = new OnItemClickListener() {

        public void onItemClick(AdapterView<?> parent, View v, int position, long id) {
            // CODIGO PARA EL DOBLE CLICK
            /*
			 * if(!mTakeEvent) { mPositionHolder=position; //this will hold the
			 * position variable of the first event mTakeEvent=true; }
			 * if(mCountdownTillNextEvent==null && !mTimerRunning) {
			 * mTimerRunning=true; //signaling that timer is running
			 * mCountdownTillNextEvent = new
			 * CountDownTimer(ViewConfiguration.getDoubleTapTimeout(), 1)
			 * //default time in milliseconds between single and double tap
			 * (see: ViewConfiguration.getDoubleTapTimeout();) {
			 *
			 * @Override public void onTick(long millisUntilFinished) {
			 * //Log.i("onTick", "Entry: "+ millisUntilFinished); }
			 *
			 * @Override public void onFinish() { //when time expires reverting
			 * to non-clicked state mTakeEvent=false;
			 * mCountdownTillNextEvent=null; mTimerRunning=false;
			 * mPositionHolder=-1; //after this point, means that single tap
			 * occured. Do something } }; mCountdownTillNextEvent.start();
			 * //firing the countdown }else{ if(mCountdownTillNextEvent!=null &&
			 * mTimerRunning && mPositionHolder == position) { mTakeEvent=false;
			 * //reverting when to non clicked state when double tap on the
			 * listview item occurred mCountdownTillNextEvent=null;
			 * mTimerRunning=false; mTakeSecond=true; mPositionHolder =
			 * position; //do the processing here... HabilitarPantalla(false);
			 * Cursor cliente = (Cursor)parent.getItemAtPosition(position);
			 * cliente.moveToPosition(position); sClienteClave =
			 * cliente.getString(1);
			 *
			 * mPresenta.seleccionar(); HabilitarPantalla(true); } }
			 */

            HabilitarPantalla(false);
            MOTConfiguracion oConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
            String clientesPedido = oConf.get("ClientesPedido").toString();
            if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && clientesPedido.equals("1")) {
                ClientesVistaReparto cliente = (ClientesVistaReparto) parent.getItemAtPosition(position);
                sClienteClave = cliente.get_clienteClave();
            } else {
                Cursor cliente = (Cursor) parent.getItemAtPosition(position);
                cliente.moveToPosition(position);
                sClienteClave = cliente.getString(1);
            }

            try {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ValidarInicioVisita")) {
                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ValidarInicioVisita").equalsIgnoreCase("1")) {
                        mostrarPreguntaSiNo(Mensajes.get("P0009"), 2);
                        return;
                    }
                }
            } catch (Exception ex) {
                if (ex != null) {
                    mostrarError(ex.getMessage());
                } else {
                    mostrarError("Error de nulos");
                }
            }

            mPresenta.seleccionar();
            HabilitarPantalla(true);
        }
    };

    public Vista getVista() {
        return this;
    }

    int tipoVista;
    boolean iniciarActividad;
    Class<?> actvdd;
    TextBoxScanner txtScanner;
    Vendedor oVendedor;
    CONHist oCONHist;
    Boolean optionsFlag = false;
    Boolean optionPlusFlag = false;
    boolean enviando = false;
    boolean actualizandoInventario = false;
    boolean actualizandoConfirmacionPedidos = false;
    boolean habilitarScanner = true;

    //NFC
    //private final String TAG = SeleccionActividadesVisita.class.getName();
    //private Context context = SeleccionActividadesVisita.this;
    private NfcAdapter nfcAdapter;
    private PendingIntent nfcPendingIntent;
    private IntentFilter writeTagFilters[];
    //private boolean writeMode;
    private Tag tag;
    private boolean mensajeNoNFC = false;
    //private boolean readNfc = false;
    //private Dialog dialog;
    private ProgressDialog dialog;
    private boolean escribiendoTag = false;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.atencion_clientes);
        deshabilitarBarra(true);

        getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
        lblTitle.setText(Mensajes.get("XSeleccionar", Mensajes.get("XCliente")));
        if (getDisplayHeight()<=480){
            lblTitle.setTextSize(12);
            lblDateBottom.setTextSize(12);
        }

        // Get the intent, verify the action and get the query
        Intent intent = getIntent();
        String filtro = null;
        if (intent.getAction() != null && Intent.ACTION_SEARCH.equals(intent.getAction())) {
            filtro = intent.getStringExtra(SearchManager.USER_QUERY);
            mPresenta = new AtenderClientes(this, Intent.ACTION_SEARCH, Enumeradores.VistaClientes.VISTA_CLIENTES_NO_VISITADOS, filtro);
        } else
            mPresenta = new AtenderClientes(this, null, 0, null);

        ListView lista_1 = (ListView) findViewById(R.id.lstAgenda);
        registerForContextMenu(lista_1);

        txtScanner = (TextBoxScanner) findViewById(R.id.textBoxScanner);

        txtScanner.setOnCodigoIngresado(mCodigoBarras);
        txtScanner.setEnabled(false);

        habilitarScanner = mPresenta.validarTextCodigoBarra();

        if(mPresenta.aseguramientoNFC()){
            checarNFC();
            //deshabilitar boton codigo de barras cuando el aseguramiento es solo por NFC
            txtScanner.habilitarBotonScanner(!mPresenta.soloNFC());
        }

        HabilitarPantalla(true);

        iniciarActividad = false;
        oVendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
        oCONHist = (CONHist) Sesion.get(Campo.CONHist);
        mPresenta.iniciar();

        TextView lblDia = (TextView) findViewById(R.id.txtDia);
        TextView lblRuta = (TextView) findViewById(R.id.txtRuta);

        lblDia.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
        lblRuta.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion);
    }

    public void checarNFC(){
        nfcAdapter = NfcAdapter.getDefaultAdapter(this);
        if(nfcAdapter != null){
            //tiene NFC
            if(!nfcAdapter.isEnabled()){
                //NFC apagado
                mostrarPreguntaSiNo(Mensajes.get("P0249"),3);
            }else {
                habilitarNFC();
            }
        }else {
            //no tiene NFC
            mensajeNoNFC = true;
            mostrarError(Mensajes.get("E0955"));
        }
    }

    public boolean tieneNFC() {
        return nfcAdapter != null;
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

    /*public void habilitaDeshabilitaCodigoBarras(boolean habilitado) {
        txtScanner.setEnabled(habilitado);
    }*/

    public void iniciar() {

    }

    public void reiniciarPantalla() {
        txtScanner.BorrarTexto();
    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {
        if (requestCode == Enumeradores.Solicitudes.SOLICITUD_GPS) {

            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                DatosGPS datosGps;
                datosGps = (DatosGPS) data.getExtras().getParcelable("Objeto");

                mPresenta.ValidarDatosGPS(datosGps);

            } else {
                mPresenta.SeleccionVisita();
            }
        } else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_AUTORIZARMOVIMIENTO) {
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                if (oVendedor.GPS && !(Boolean) mPresenta.obtenerParametros().get("bVisitado") && mPresenta.iniciarGPS())
                    mPresenta.IniciarGPS();
                else
                    mPresenta.SeleccionVisita();
            }
        } else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES) {
            if (enviando) {
                if (resultCode == Enumeradores.Resultados.RESULTADO_MAL) {
                    if (data != null) {
                        String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                        if (mensajeError != null) {
                            finalizar();
                            iniciarActividad(IAtencionClientes.class, mensajeError);
                        }
                    }
                } else {
                    if ((((Ruta) Sesion.get(Campo.RutaActual)).Inventario && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)) {
                        HashMap<String, String> parametros = new HashMap<String, String>();
                        String tablasActualizar = "''Inventario''";
                        parametros.put("Tablas", tablasActualizar);
                        parametros.put("Continuar", "true");
                        actualizandoInventario = true;
                        iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_RECIBIR_INFO_INVENTARIO, parametros);
                    } else if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("SincronizarConfirmPedido").equals("1")) {
                        HashMap<String, String> parametros = new HashMap<String, String>();
                        //No se especifican las tablas a actualizar pero se envian para que se considere en el regreso
                        //de la actividad
                        String tablasActualizar = "";
                        parametros.put("Tablas", tablasActualizar);
                        actualizandoConfirmacionPedidos = true;
                        iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_RECIBIR_INFO_CONFIRMACIONPEDIDO, parametros);
                    }
                }
                enviando = false;
                return;
            }
            if (actualizandoInventario) {
                if (resultCode == Enumeradores.Resultados.RESULTADO_MAL) {
                    if (data != null) {
                        String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                        if (mensajeError != null) {
                            finalizar();
                            iniciarActividad(IAtencionClientes.class, mensajeError);
                        }
                    }
                }
                actualizandoInventario = false;
                if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("SincronizarConfirmPedido").equals("1")) {
                    HashMap<String, String> parametros = new HashMap<String, String>();
                    String tablasActualizar = "";
                    parametros.put("Tablas", tablasActualizar);
                    actualizandoConfirmacionPedidos = true;
                    iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_RECIBIR_INFO_CONFIRMACIONPEDIDO, parametros);
                } else if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                    if (data != null) {
                        String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                        if (mensajeError != null) {
                            mostrarError(mensajeError);
                        }
                    }
                }
                return;
            }
            if (actualizandoConfirmacionPedidos) {
                if (resultCode == Enumeradores.Resultados.RESULTADO_MAL) {
                    if (data != null) {
                        String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                        if (mensajeError != null) {
                            finalizar();
                            iniciarActividad(IAtencionClientes.class, mensajeError);
                        }
                    }
                }
                actualizandoConfirmacionPedidos = false;
                return;
            }
        }else if(requestCode == Enumeradores.Solicitudes.SOLICITUD_CONFIGURACION_NFC){
            checarNFC();
        }
        else if (requestCode == 99){
            mPresenta.llevameACliente();
        }
		/*
		 * else if(requestCode==
		 * Enumeradores.Solicitudes.SOLICITUD_AUTORIZARMOVIMIENTO) {
		 * if(resultCode== Enumeradores.Resultados.RESULTADO_BIEN) {
		 * if(oVendedor.GPS &&
		 * !(Boolean)mPresenta.obtenerParametros().get("bVisitado")) {
		 * mPresenta.IniciarGPS(); } else { mPresenta.SeleccionVisita(); } }
		 * else {
		 *
		 * } }
		 */
    }

    @Override
    public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje) {
        mPresenta.validarTextCodigoBarra();
        if (respuesta.equals(RespuestaMsg.OK) && iniciarActividad) // iniciar
        // visita o
        // autorizacion
        {
            if (actvdd == IAutorizaMovimiento.class) {
                iniciarActividadConResultado(IAutorizaMovimiento.class, Enumeradores.Solicitudes.SOLICITUD_AUTORIZARMOVIMIENTO, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA);
            } else {
                if ((oVendedor.GPS) && !(Boolean) mPresenta.obtenerParametros().get("bVisitado")) {
                    mPresenta.IniciarGPS();
                    return;
                }

                mPresenta.SeleccionVisita();
                // iniciarActividad(ISeleccionVisita.class,
                // Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null,
                // false);
            }

        } else if (tipoMensaje == 1) {
            if (respuesta.equals(RespuestaMsg.Si)) {
                mPresenta.IniciarGPS();
            } else if (respuesta.equals(RespuestaMsg.No)) {
                mPresenta.SeleccionVisita();
                // iniciarActividad(ISeleccionVisita.class,
                // Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null,
                // false);
            }
        } else if (tipoMensaje == 2) {
            if (respuesta.equals(RespuestaMsg.Si)) {
                mPresenta.seleccionar();
                HabilitarPantalla(true);
            } else {
                HabilitarPantalla(true);
            }
        }else if (tipoMensaje == 3) {
            //NFC apagado
            if(respuesta.equals(RespuestaMsg.Si)){
                mostrarConfiguracionNFC();
            }
        }else if (mensajeNoNFC) {
            //no tiene NFC, salir
            //finalizar();
            mPresenta.toActividadesVed();
            this.finish();
        }
        else if(tipoMensaje == 99){
            if(respuesta == RespuestaMsg.Si){
                startActivityForResult(new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS), 99);
            }
        }

        // iniciarActividad(IAutorizaMovimiento.class,
        // Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null, false);
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        switch (keyCode) {
            case KeyEvent.KEYCODE_BACK:
                mPresenta.toActividadesVed();
                this.finish();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        try {
            ValorReferencia[] mCliente = ValoresReferencia.getValores("ACTMAC");

            if (mCliente == null) return true;

            for (int a = 0; a < mCliente.length; a++) {
                menu.add(0, Integer.parseInt(mCliente[a].getVavclave().toString()), Integer.parseInt(mCliente[a].getVavclave().toString()), mCliente[a].getDescripcion());
            }

            if (!oVendedor.TiemposMuertos) {
                MenuItem item = menu.findItem(Enumeradores.ACTMAC.TIEMPOS_MUERTOS);
                if (item != null)
                    item.setVisible(false);
            }

            if (oCONHist.get("EnvioParcial").equals("0")) {
                MenuItem item = menu.findItem(Enumeradores.ACTMAC.ENVIO_PARCIAL).setVisible(false);
                if (item != null)
                    item.setVisible(false);
            }

        } catch (Exception e) {
            mostrarError(e.getMessage());
        }

        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case Enumeradores.ACTMAC.VISTAS:
                ListView lista_2 = (ListView) findViewById(R.id.lstAgenda);
                optionPlusFlag = true;
                registerForContextMenu(lista_2);
                openContextMenu(lista_2);
                return true;
            case Enumeradores.ACTMAC.BUSCAR:
                startSearch(null, false, null, false);
                // onSearchRequested();
                return true;
            case Enumeradores.ACTMAC.MIS_CUOTAS:
                iniciarActividad(IConsultaIndicadores.class, false);
                return true;
            case Enumeradores.ACTMAC.ENVIO_PARCIAL:
                HashMap<String, String> oParametros = new HashMap<String, String>();
                oParametros.put("TipoEnvioInfo", String.valueOf(TipoEnvioInfo.ENVIO_PARCIAL));
                if ((((Ruta) Sesion.get(Campo.RutaActual)).Inventario && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA) || (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("SincronizarConfirmPedido").equals("1"))) {
                    oParametros.put("Continuar", "true");
                }
                enviando = true;
                iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_ENVIAR_BD_VENDEDOR, oParametros);
                return true;
            case Enumeradores.ACTMAC.TIEMPOS_MUERTOS:
                iniciarActividad(IRegistroTiemposMuertos.class, false);
                return true;
            case Enumeradores.ACTMAC.MIS_PENDIENTES:
                finalizar();
                iniciarActividad(IRevisionPendientes.class, false);
                return true;
            case Enumeradores.ACTMAC.NUEVO_CLIENTE:
                mPresenta.crearCliente();
                return true;
            case Enumeradores.ACTMAC.PEDIDOS_PAGO_ANTICIPADO:
                if (ValoresReferencia.getCadenaValores("PEDTIPO", "PagoAnticipado").length() <= 0) {
                    mostrarError(Mensajes.get("E0173", Mensajes.get(" Valor con Grupo PagoAnticipado")));
                    return true;
                }
                iniciarActividad(ISeleccionPedidosPagoAnticipado.class, false);
                return true;
            case Enumeradores.ACTMAC.IMPRIMIR_CLIENTES:
                try {
                    if (!bluetoothEncendido()) {
                        encenderBluetooth();
                    } else {
                        //mPresenta.imprimirTicket();
                        mPresenta.imprimirClientes();
                    }
                    // getVista().mostrarAdvertencia("Recibos generados");
                } catch (ControlError e) {
                    e.Mostrar(getVista());
                } catch (Exception e) {
                    getVista().mostrarError(e.getMessage());
                }
                return true;
            default:
                optionPlusFlag = true;
                return super.onOptionsItemSelected(item);
        }
    }

    //	private boolean mTakeEvent = false;
    //	private CountDownTimer mCountdownTillNextEvent;
    //	private boolean mTimerRunning = false;
    //	private int mPositionHolder = -1;
    //	private boolean mTakeSecond = false;

    @Override
    public void onNewIntent(final Intent newIntent) {
        super.onNewIntent(newIntent);

        final String queryAction = newIntent.getAction();
        if (Intent.ACTION_SEARCH.equals(queryAction)) {
            if (newIntent.getData() != null) {
                sClienteClave = newIntent.getData().toString();
                mPresenta.seleccionar();
            } else {
                //				String s = newIntent.getStringExtra(SearchManager.QUERY);
            }
        }else if (NfcAdapter.ACTION_TAG_DISCOVERED.equals(newIntent.getAction())) {
            tag = newIntent.getParcelableExtra(NfcAdapter.EXTRA_TAG);

            if(escribiendoTag){
                escribiendoTag = false;
                //if( write(sClienteClave,tag) )
                //if(writeTag(tag,createTextMessage(sClienteClave)))
                if(writeTag(tag,createTextMessage(EncriptaDesencripta.encripta(sClienteClave))))
                    Toast.makeText(this, Mensajes.get("XNFCEscritura"), Toast.LENGTH_LONG).show();
                else
                    Toast.makeText(this, Mensajes.get("XNFCErrorEscritura"), Toast.LENGTH_LONG).show();
                dialog.dismiss();
            }else{
                String codigoCliente = read(tag);
                if(codigoCliente != null) {
                    if (codigoCliente.length() == 0)
                        return;

                    codigoCliente = EncriptaDesencripta.encripta(codigoCliente);
                    HabilitarPantalla(false);
                    try
                    {
                        sClienteClave = Consultas.ConsultasCliente.validarClienteClave(codigoCliente);
                    }
                    catch(Exception ex)
                    {
                        ex.printStackTrace();
                    }
                    mPresenta.seleccionarCodigoBarras(1,codigoCliente);
                    HabilitarPantalla(true);
                }
                else{
                    Toast.makeText(this, Mensajes.get("XNFCErrorLectura"), Toast.LENGTH_LONG).show();
                }
            }
        }
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();

        optionsFlag = optionPlusFlag;

        if (v instanceof ListView && !optionsFlag) {
            inflater.inflate(R.menu.context_atencion_clientes, menu);

            menu.getItem(0).setTitle(Mensajes.get("XConsultar"));
            if (tipoVista == Enumeradores.VistaClientes.VISTA_CLIENTES_FUERA_FRECUENCIA || tipoVista == Enumeradores.VistaClientes.VISTA_CLIENTES_IMPRODUCTIVOS || tipoVista == Enumeradores.VistaClientes.VISTA_CLIENTES_NUEVOS)
                menu.getItem(1).setVisible(false);
            else {
                try {
                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("NoMostrarImprodVisita", ((Vendedor)Sesion.get(Campo.VendedorActual)).MCNClave) && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("NoMostrarImprodVisita", ((Vendedor)Sesion.get(Campo.VendedorActual)).MCNClave).equals("1")) {
                        menu.getItem(1).setVisible(false);
                    }else{
                        menu.getItem(1).setVisible(true);
                        menu.getItem(1).setTitle(Mensajes.get("XNoVisitar"));
                    }
                }catch (Exception ex){
                    if (ex!=null && ex.getMessage() != null) {
                        mostrarError(ex.getMessage());
                    }
                }
            }

            if ( !mPresenta.aseguramientoNFC() && !tieneNFC() ) {
                menu.getItem(2).setVisible(false);
            }else {
                menu.getItem(2).setVisible(true);
                menu.getItem(2).setTitle(Mensajes.get("XVincularNFC"));
            }

            ListView lista_3 = (ListView) findViewById(R.id.lstAgenda);

            Cursor cliente = null;
            MOTConfiguracion oConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
            String clientesPedido = oConf.get("ClientesPedido").toString();
            if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && clientesPedido.equals("1")) {
                ClientesVistaReparto cli = (ClientesVistaReparto) lista_3.getItemAtPosition(((AdapterContextMenuInfo) menuInfo).position);
                sClienteClave = cli.get_clienteClave();
            } else {
                cliente = (Cursor) lista_3.getItemAtPosition(((AdapterContextMenuInfo) menuInfo).position);
                sClienteClave = cliente.getString(1);
            }

            if (mPresenta.tieneCoordenadas()){
                menu.getItem(3).setTitle(Mensajes.get("XLlevame"));
                menu.getItem(3).setVisible(true);
            }
            else
                menu.getItem(3).setVisible(false);

            String[] sTelefonos = mPresenta.obtenerTelefonosContacto();
            if (sTelefonos != null && sTelefonos.length > 0)
            {
                menu.getItem(4).setTitle(Mensajes.get("XLlamar"));
                menu.getItem(4).setVisible(true);
                if (sTelefonos.length > 1){
                    int nIndex = 0;
                    for (String sTelefono: sTelefonos)
                        menu.getItem(4).getSubMenu().add(1, nIndex, nIndex, sTelefono.trim());
                }
            }
            else
                menu.getItem(4).setVisible(false);



        } else {
            inflater.inflate(R.menu.context_vistas, menu);
            menu.setHeaderTitle("Vistas");
            menu.getItem(0).setTitle(Mensajes.get("XClientesVisitados"));
            menu.getItem(1).setTitle(Mensajes.get("XClientesNoVisitados"));
            menu.getItem(2).setTitle(Mensajes.get("XClientesFueraFrecuencia"));
            menu.getItem(3).setTitle(Mensajes.get("MDB0125"));
            menu.getItem(4).setTitle(Mensajes.get("XClientesConMensajes"));
            menu.getItem(5).setTitle(Mensajes.get("XClientesConCobranza"));
            menu.getItem(6).setTitle(Mensajes.get("XClientesImproductivos"));
            menu.getItem(7).setTitle(Mensajes.get("XClientesNuevos"));
            menu.getItem(8).setTitle(Mensajes.get("XPorSurtir"));
            menu.getItem(9).setTitle(Mensajes.get("XClientesNoVisitadosRec"));
            if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.REPARTO)
                menu.getItem(8).setVisible(false);
            if (menu.size() > 10) {
                for (int i = 10; i < menu.size(); i++)
                    menu.getItem(i).setVisible(false);
            }
            optionPlusFlag = false;
        }
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterContextMenuInfo info = null;
        Cursor cliente = null;
        if (item.getMenuInfo() != null) {
            info = (AdapterContextMenuInfo) item.getMenuInfo();
            ListView lista_3 = (ListView) findViewById(R.id.lstAgenda);

            MOTConfiguracion oConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
            String clientesPedido = oConf.get("ClientesPedido").toString();
            if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && clientesPedido.equals("1")) {
                ClientesVistaReparto cli = (ClientesVistaReparto) lista_3.getItemAtPosition((int) info.position);
                sClienteClave = cli.get_clienteClave();
            } else {
                cliente = (Cursor) lista_3.getItemAtPosition((int) info.position);
                if (cliente.getCount()<=0){
                    sClienteClave = null;
                }else {
                    sClienteClave = cliente.getString(1);
                }
            }
        }

        if(item.getGroupId() == 1){
            //Tiene varios telefonos de contacto, llamar al seleccionado en el submenu
            marcarTelefonoContacto(item.getTitle().toString());
            return true;
        }else {

            switch (item.getItemId()) {
                case R.id.consultar:
                    mPresenta.consultarCliente();
                    return true;
                case R.id.novisitar:
                    try {
                        if (Consultas.ConsultasVisita.existenVisitas(((Dia) Sesion.get(Campo.DiaActual)).DiaClave, sClienteClave)) {
                            mostrarError(Mensajes.get("I0286"));
                            return false;
                        }
                    } catch (Exception ex) {
                        mostrarError(ex.getMessage());
                    }
                    mPresenta.mostrarImproductividadCliente();
                    return true;
                case R.id.vincularNFC:
                    showAlertDialogUsuario();
               /*checarNFC();
                if(nfcAdapter != null) {
                    if (nfcAdapter.isEnabled()) { //escribir solo si esta encendido el NFC
                        escribiendoTag = true;
                        dialog = new ProgressDialog(this);
                        dialog.setMessage("Acerca el Tag NFC");
                        dialog.show();
                        //dialog.setCancelable(false);
                        dialog.setCanceledOnTouchOutside(false);
                        dialog.setOnCancelListener(new DialogInterface.OnCancelListener() {
                            @Override
                            public void onCancel(DialogInterface dialog) {
                                escribiendoTag = false;
                            }
                        });

                        *//*if( write(sClienteClave,tag) )
                            Toast.makeText(this, Mensajes.get("XNFCEscritura"), Toast.LENGTH_LONG).show();
                        else
                            Toast.makeText(this, Mensajes.get("XNFCErrorEscritura"), Toast.LENGTH_LONG).show();*//*
                    }
                }*/
                    return true;
                case R.id.navegar:
                    LocationManager lm = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
                    if (!lm.isProviderEnabled(LocationManager.GPS_PROVIDER)) {
                        mostrarPreguntaSiNo(Mensajes.get("P0236"), 99);
                    } else {
                        mPresenta.llevameACliente();
                    }
                    return true;
                case R.id.llamar:
                    //Solo tiene un telefono de contacto
                    if (!item.getSubMenu().hasVisibleItems())
                        marcarTelefonoContacto(mPresenta.obtenerTelefonoActual());
                    return true;

                    // ********************** vistas
                    // **********************************
                case R.id.visitados:
                    mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_VISITADOS, null);

                    return true;
                case R.id.novisitados:

                    mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_NO_VISITADOS, null);

                    return true;
                case R.id.fuerafrecuencia:
                    mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_FUERA_FRECUENCIA, null);
                    return true;
                case R.id.todos:
                    mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_TODOS, null);
                    return true;
                case R.id.conmensaje:
                    mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_CON_MENSAJE, null);
                    return true;
                case R.id.concobranza:
                    mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_CON_COBRANZA, null);
                    return true;
                case R.id.improductivos:
                    mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_IMPRODUCTIVOS, null);
                    return true;
                case R.id.nuevos:
                    mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_NUEVOS, null);
                    return true;
                case R.id.porsusrtir:
                    mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_POR_SURTIR, null);
                    return true;
                case R.id.novisitadosrec:
                    mPresenta.mostrarClientes(VistaClientes.VISTA_CLIENTES_NO_VISITADOS_REC, null);
                    return true;
                default:
                    return super.onOptionsItemSelected(item);
            }
        }
    }

    public void navegarAPuntoGPS(float latitud, float longitud){
        Uri gmmIntentUri = Uri.parse("google.navigation:q=" + latitud + "," + longitud + "&mode=d");
        Intent mapIntent = new Intent(Intent.ACTION_VIEW, gmmIntentUri);
        mapIntent.setPackage("com.google.android.apps.maps");
        if (mapIntent.resolveActivity(getPackageManager()) != null) {
            startActivity(mapIntent);
        }
        else
            this.mostrarError(Mensajes.get("I0309"));
    }

    private void marcarTelefonoContacto(final String numeroTelefono) {
        startActivity(new Intent(Intent.ACTION_DIAL, Uri.fromParts("tel", numeroTelefono, null)));
    }

    public void mostrarTelefonos(String[] telefonos){


    }

    @SuppressWarnings("deprecation")
    public void mostrarClientes(ISetDatos clientes, int vista) {
        TextView lblTitulo = (TextView) findViewById(R.id.txtTitulo);

        switch (vista) {
            case Enumeradores.VistaClientes.VISTA_CLIENTES_NO_VISITADOS:
                lblTitulo.setText(Mensajes.get("XClientesNoVisitados") + ": " + clientes.getCount());
                break;
            case Enumeradores.VistaClientes.VISTA_CLIENTES_VISITADOS:
                lblTitulo.setText(Mensajes.get("XClientesVisitados") + ": " + clientes.getCount());
                break;
            case Enumeradores.VistaClientes.VISTA_CLIENTES_FUERA_FRECUENCIA:
                lblTitulo.setText(Mensajes.get("XClientesFueraFrecuencia") + ": " + clientes.getCount());
                break;
            case Enumeradores.VistaClientes.VISTA_CLIENTES_TODOS:
                lblTitulo.setText(Mensajes.get("MDB0125") + ": " + clientes.getCount());
                break;
            case Enumeradores.VistaClientes.VISTA_CLIENTES_CON_MENSAJE:
                lblTitulo.setText(Mensajes.get("XClientesConMensajes") + ": " + clientes.getCount());
                break;
            case Enumeradores.VistaClientes.VISTA_CLIENTES_CON_COBRANZA:
                lblTitulo.setText(Mensajes.get("XClientesConCobranza") + ": " + clientes.getCount());
                break;
            case Enumeradores.VistaClientes.VISTA_CLIENTES_IMPRODUCTIVOS:
                lblTitulo.setText(Mensajes.get("XClientesImproductivos") + ": " + clientes.getCount());
                break;
            case Enumeradores.VistaClientes.VISTA_CLIENTES_NUEVOS:
                lblTitulo.setText(Mensajes.get("XClientesNuevos") + ": " + clientes.getCount());
                break;
            case Enumeradores.VistaClientes.VISTA_CLIENTES_POR_SURTIR:
                lblTitulo.setText(Mensajes.get("XPorSurtir") + ": " + clientes.getCount());
                break;
            case Enumeradores.VistaClientes.VISTA_CLIENTES_NO_VISITADOS_REC:
                lblTitulo.setText(Mensajes.get("XClientesNoVisitadosRec") + ": " + clientes.getCount());
                break;
            default:
                break;
        }

        tipoVista = vista;

        ListView lista_4 = (ListView) findViewById(R.id.lstAgenda);

        Cursor cClientes = (Cursor) clientes.getOriginal();
        startManagingCursor(cClientes);
        try {
            MOTConfiguracion oConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
            String clientesPedido = oConf.get("ClientesPedido").toString();
            if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && clientesPedido.equals("1")) {
                //si es reparto y esta habilitado el parametro clientes pedido, cambiar el adapter para mostrar con fondo gris los clientes con pedidos
                if (cClientes.getCount() != 0) {
                    ArrayList<ClientesVistaReparto> cli = new ArrayList<AtencionClientes.ClientesVistaReparto>();
                    while (cClientes.moveToNext()) {
                        ClientesVistaReparto nuevo = new ClientesVistaReparto(cClientes.getString(cClientes.getColumnIndex(SearchManager.SUGGEST_COLUMN_TEXT_1)), cClientes.getString(cClientes.getColumnIndex("Contacto")), cClientes.getString(cClientes.getColumnIndex(SearchManager.SUGGEST_COLUMN_TEXT_2)), cClientes.getInt(cClientes.getColumnIndex("PedidosXSurtir")), cClientes.getString(cClientes.getColumnIndex(SearchManager.SUGGEST_COLUMN_INTENT_DATA)));
                        cli.add(nuevo);
                    }
                    ClientesVistaReparto[] clientesReparto = cli.toArray(new ClientesVistaReparto[cli.size()]);

                    ClientesAdapter adpt = new ClientesAdapter(this, R.layout.lista_simple3, clientesReparto);
                    lista_4.setAdapter(adpt);
                } else {
                    lista_4.setAdapter(null);
                }
            } else {
                SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple3, cClientes, new String[]
                        {SearchManager.SUGGEST_COLUMN_TEXT_1, "Contacto", SearchManager.SUGGEST_COLUMN_TEXT_2}, new int[]
                        {R.id.texto1, R.id.texto2, R.id.texto3});
                lista_4.setAdapter(adapter);
            }
        } catch (Exception e) {
            mostrarError(e.getMessage());
        }
        lista_4.setOnItemClickListener(mSeleccion);

    }

    public String getCliente() {
        // TODO Auto-generated method stub
        return sClienteClave;
    }

    public void HabilitarPantalla(Boolean Habilitado) {
        ListView lista_5 = (ListView) findViewById(R.id.lstAgenda);
        lista_5.setClickable(Habilitado);
        txtScanner.setClickable(Habilitado);
        lista_5.setEnabled(Habilitado);
        //if(Habilitado && habilitarScanner)
            txtScanner.setEnabled(Habilitado);
        if(!habilitarScanner)
            txtScanner.setOcultarTexto();
        this.doevents();

    }

    public void mostrarMensajeEiniciarActividad(String mensaje, Class<?> actividad) {
        iniciarActividad = true;
        actvdd = actividad;
        mostrarAdvertencia(mensaje);
    }

    //	private void ocultarTeclado()
    //	{
    //		InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
    //		TextView texto = (TextView) findViewById(R.id.txtScanner);
    //		imm.hideSoftInputFromWindow(texto.getWindowToken(), 0);
    //	}


    //*********************************** adapter y vista para cambiar el fondo a color gris, solo se usa en reparto

    private static class ClientesVistaReparto {
        private String _clienteClave;
        private String _texto1;
        private String _texto2;
        private String _texto3;
        private int _pedidosXsurtir;

        public ClientesVistaReparto(String texto1, String texto2, String texto3, int pedidoXsurtir, String clienteClave) {
            _texto1 = texto1;
            _texto2 = texto2;
            _texto3 = texto3;
            _pedidosXsurtir = pedidoXsurtir;
            _clienteClave = clienteClave;
        }

        public String get_texto1() {
            return _texto1;
        }

        public String get_texto2() {
            return _texto2;
        }

        public String get_texto3() {
            return _texto3;
        }

        public int get_pedidosXsurtir() {
            return _pedidosXsurtir;
        }

        public String get_clienteClave() {
            return _clienteClave;
        }
    }

    private class ClientesAdapter extends ArrayAdapter<ClientesVistaReparto> {

        int textViewResourceId;
        Context context;
        ClientesVistaReparto[] clientes;

        public ClientesAdapter(Context context, int textViewResourceId, ClientesVistaReparto[] objects) {
            super(context, textViewResourceId, objects);
            this.context = context;
            this.textViewResourceId = textViewResourceId;
            this.clientes = objects;
        }

        @Override
        public int getViewTypeCount() {
            return clientes.length;
        }

        @Override
        public int getItemViewType(int position) {
            return position;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View view = convertView;
            if (convertView == null) {
                LayoutInflater inflater = ((Activity) context).getLayoutInflater();
                view = inflater.inflate(textViewResourceId, null);
            }

            ClientesVistaReparto cli = clientes[position];

            TextView texto1 = (TextView) view.findViewById(R.id.texto1);
            texto1.setText(cli.get_texto1());

            TextView texto2 = (TextView) view.findViewById(R.id.texto2);
            texto2.setText(cli.get_texto2());

            TextView texto3 = (TextView) view.findViewById(R.id.texto3);
            texto3.setText(cli.get_texto3());

            if (cli.get_pedidosXsurtir() != 0) {
                view.setBackgroundColor(getResources().getColor(R.color.lightGray));
            }

            return view;
        }

    }

    public boolean showAlertDialogUsuario()
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
        alert.setTitle(Mensajes.get("XContrasenaEscrituraTag")).setView(textEntryView).setPositiveButton(Mensajes.get("BTContinuar"), new DialogInterface.OnClickListener() {
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
                            ActivarEscribirNFC();
                        }
                    }
                }
            }
        }).setNegativeButton(Mensajes.get("BTRegresar"), new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int whichButton) {

            }
        });
        alert.show();
        return false;
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

    private void ActivarEscribirNFC(){
        checarNFC();
        if(nfcAdapter != null) {
            if (nfcAdapter.isEnabled()) { //escribir solo si esta encendido el NFC
                escribiendoTag = true;
                dialog = new ProgressDialog(this);
                dialog.setMessage("Acerca el Tag NFC");
                dialog.show();
                //dialog.setCancelable(false);
                dialog.setCanceledOnTouchOutside(false);
                dialog.setOnCancelListener(new DialogInterface.OnCancelListener() {
                    @Override
                    public void onCancel(DialogInterface dialog) {
                        escribiendoTag = false;
                    }
                });
            }
        }
    }

    /*******************METODOS PARA FUNCIONALIDAD NFC*******************/
    @Override
    protected void onResume() {
        super.onResume();
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

    private boolean write(String text, Tag tag) {
        try{
            if(read(tag) == null){
                boolean formateableTag = false;
                String[] techsList = tag.getTechList();
                for(String tech : techsList){
                    if(tech.equalsIgnoreCase("android.nfc.tech.NdefFormatable")){
                        formateableTag = true;
                        break;
                    }
                }

                if(formateableTag)
                    formatNdefFormatable(tag,text);
                else{
                    NdefRecord[] records = { createRecord("@"+text) };
                    NdefMessage message = new NdefMessage(records);
                    // Get an instance of Ndef for the tag.
                    Ndef ndef = Ndef.get(tag);
                    // Enable I/O
                    ndef.connect();
                    // Write the message
                    ndef.writeNdefMessage(message);
                    // Close the connection
                    ndef.close();
                }
                return true;
            } else
                return false;
        } catch (Exception e){
            return false;
        }
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



    private NdefRecord createRecord(String text) throws UnsupportedEncodingException {
        String lang       = "en";
        byte[] textBytes  = text.getBytes();
        byte[] langBytes  = lang.getBytes("US-ASCII");
        int    langLength = langBytes.length;
        int    textLength = textBytes.length;
        byte[] payload    = new byte[1 + langLength + textLength];

        // set status byte (see NDEF spec for actual bits)
        payload[0] = (byte) langLength;

        // copy langbytes and textbytes into payload
        System.arraycopy(langBytes, 0, payload, 1,              langLength);
        System.arraycopy(textBytes, 0, payload, 1 + langLength, textLength);

        NdefRecord recordNFC = new NdefRecord(NdefRecord.TNF_WELL_KNOWN,  NdefRecord.RTD_TEXT,  new byte[0], payload);

        return recordNFC;
    }


    /**
     * Metodo que hace el parseo del intent para regresar el id unico del tag NFC
     * @param intent
     * @return String
     */
    private String getTagUID(Intent intent) {

        byte[] uid = intent.getByteArrayExtra(NfcAdapter.EXTRA_ID);
        return bin2hex(uid);
    }


    /**
     * Metodo que hace el parseo del intent para regresar la informacion completa del tag NFC
     * @param intent
     * @return Tag
     */
    private Tag getTagInfo(Intent intent){

        return intent.getParcelableExtra(NfcAdapter.EXTRA_TAG);
    }


    /**
     * Metodo que convierte el id unico del tag NFC a String
     * @param data
     * @return String
     */
    private String bin2hex(byte[] data) {
        return String.format("%0" + (data.length * 2) + "X", new BigInteger(1, data));
    }

    private void WriteModeOn(){
        //writeMode = true;
        nfcAdapter.enableForegroundDispatch(this, nfcPendingIntent, writeTagFilters, null);
    }

    private void WriteModeOff(){
        //writeMode = false;
        nfcAdapter.disableForegroundDispatch(this);
    }

    private void formatNdefFormatable(Tag tag,String text) throws IOException, FormatException {

        NdefRecord[] records = { createRecord("@"+text) };
        NdefMessage message = new NdefMessage(records);
        // Get an instance of Ndef for the tag.
        NdefFormatable ndef = NdefFormatable.get(tag);
        if(ndef != null){
            // Enable I/O
            ndef.connect();
            // Format the tag and add the message
            ndef.format(message);
            // Close the connection
            ndef.close();
        }
    }

    public NdefMessage createTextMessage(String content) {
        try {
            content = "@"+content;
            // Get UTF-8 byte
            byte[] lang = Locale.getDefault().getLanguage().getBytes("UTF-8");
            byte[] text = content.getBytes("UTF-8"); // Content in UTF-8

            int langSize = lang.length;
            int textLength = text.length;

            ByteArrayOutputStream payload = new ByteArrayOutputStream(1 + langSize + textLength);
            payload.write((byte) (langSize & 0x1F));
            payload.write(lang, 0, langSize);
            payload.write(text, 0, textLength);
            NdefRecord record = new NdefRecord(NdefRecord.TNF_WELL_KNOWN, NdefRecord.RTD_TEXT, new byte[0], payload.toByteArray());
            return new NdefMessage(new NdefRecord[]{record});
        }
        catch (Exception e) {
            e.printStackTrace();
        }

        return null;
    }

    private boolean writeTag(Tag tag, NdefMessage message){
        if (tag != null) {
            if(read(tag) == null){
                try {
                    Ndef ndefTag = Ndef.get(tag);

                    if (ndefTag == null) {
                        // Let's try to format the Tag in NDEF
                        NdefFormatable ndefFormatable  = NdefFormatable.get(tag);
                        if (ndefFormatable  != null) {
                            ndefFormatable.connect();
                            ndefFormatable.format(message);
                            ndefFormatable.close();
                        }
                    }else {
                        ndefTag.connect();
                        ndefTag.writeNdefMessage(message);
                        ndefTag.close();
                    }
                    return true;
                }
                catch(Exception e) {
                    e.printStackTrace();
                    return false;
                }
            }
        }
        return false;
    }

    /*******************METODOS PARA FUNCIONALIDAD NFC*******************/
    @Override
    public void impresionFinalizada(boolean impresionExitosa, String mensajeError) {
        if (!mensajeError.equals(""))
            Toast.makeText(getApplicationContext(), mensajeError, Toast.LENGTH_LONG).show();

        setResult(Enumeradores.Resultados.RESULTADO_BIEN);

        quitarProgreso();

    }

    @Override
    public void noHayDatosImpresion() {
        mostrarAdvertencia(Mensajes.get("XNoExistenRegistros"));
    }
}
