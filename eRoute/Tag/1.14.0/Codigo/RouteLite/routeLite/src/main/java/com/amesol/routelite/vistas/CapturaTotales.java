package com.amesol.routelite.vistas;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.SearchManager;
import android.content.ContentValues;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Color;
import android.net.Uri;
import android.os.Bundle;
import android.text.InputFilter;
import android.util.Log;
import android.view.Display;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.MeasureSpec;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.SpinnerAdapter;
import android.widget.TextView;
import android.widget.Toast;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Descuentos;
import com.amesol.routelite.actividades.EnvioPDF;
import com.amesol.routelite.actividades.Impresion;
import com.amesol.routelite.actividades.ListaPrecio;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.NumberPicker;
import com.amesol.routelite.controles.NumberPicker.OnChangedListener;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.FrecuenciaExcep;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Precio;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TRPVtaAcreditada;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasImpresionTicket;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.TipoFecha;
import com.amesol.routelite.presentadores.Enumeradores.TipoPedido;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.presentadores.act.CapturarTotales;
import com.amesol.routelite.presentadores.interfaces.ICapturaTotales;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.EnvioEmail;
import com.amesol.routelite.utilerias.Generales;
import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.Element;
import com.itextpdf.text.Font;
import com.itextpdf.text.Font.FontFamily;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.PdfWriter;

import java.io.File;
import java.io.FileOutputStream;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.Map;
 
@SuppressLint(
{ "SimpleDateFormat", "CutPasteId", "DefaultLocale" })
public class CapturaTotales extends Vista implements ICapturaTotales
{

    static final int DATE_DIALOG_COBRANZA = 999;
    private OnClickListener mFechaCobranza = new OnClickListener() {
        @SuppressWarnings("deprecation")
        @Override
        public void onClick(View v) {
            showDialog(DATE_DIALOG_COBRANZA);
        }
    };
    static final int DATE_DIALOG_ENTREGA = 998;
    private OnClickListener mFechaEntrega = new OnClickListener() {

        @SuppressWarnings("deprecation")
        @Override
        public void onClick(View v) {
            showDialog(DATE_DIALOG_ENTREGA);
        }
    };
    //static final int DESGLOSE_IMPUESTOS = 997;
    // TransProd oTrp;
    CapturarTotales mPresenta;
    String mAccion;
    HashMap<String, Object> oParametros = null;
    ArrayList<String> aTransProdIds;
    //short trueType;
    ISetDatos tiposPedidos;
	ISetDatos tiposFase;
	ISetDatos formasVenta;
	ISetDatos formasPago;
	ISetDatos tiposTurno;
	ISetDatos tiposCodigoMoneda;
	ISetDatos formaVenta;
	ISetDatos puntosEntrega;
	boolean soloLectura = true;
    boolean separarTotalesSubEmpresa = false;
    HashMap<String, Boolean> oTransProdTotalizados;

    String folioSeleccionado = "";
    private OnClickListener mTerminar = new OnClickListener() {
        @Override
        public void onClick(View v) {
            Button btn = (Button) findViewById(R.id.btnTerminar);
            try {
                if (!soloLectura) { // no modificar si esta solo lectura
                    NumberPicker txtDescVend = (NumberPicker)findViewById(R.id.npPorVendedor);
                    if (txtDescVend.isEnabled()) {
                        txtDescVend.clearFocus();
                        txtDescVend = (NumberPicker) findViewById(R.id.npDescVendedor);
                        txtDescVend.clearFocus();
                    }
                    if (separarTotalesSubEmpresa){
                        Spinner spn = (Spinner) findViewById(R.id.spFolio);
                        HashMap<String,TransProd> spinnerMap = (HashMap<String,TransProd>)spn.getTag();
                        mPresenta.asignarGuardarValores(spinnerMap.get(folioSeleccionado));

                        Iterator it = oTransProdTotalizados.entrySet().iterator();
                        while (it.hasNext()) {
                            Map.Entry e = (Map.Entry)it.next();
                            if (!(Boolean)e.getValue()){
                                mostrarError(Mensajes.get("I0295", spinnerMap.get(e.getKey()).Folio) );
                                return;
                            }
                        }
                        mPresenta.terminarPedidosMultiTotales();
                    }else {
                        btn.setEnabled(false);
                        mPresenta.asignarGuardarValores();
                    }
                } else { // si es solo lectura, salir
                    setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                    finalizar();
                    return; //Si es de solo lectura, no se graba nada y te deja salir.
                }

                Runnable accion = new Runnable() {

                    @Override
                    public void run() {
                        while (getMensajeLimiteCredito() || getMensajeLimiteEnvase()) {
                            //esperar hasta que se quite el mensaje de validacion de credito para continuar
                        }
                        runOnUiThread(new Runnable() { //ejecutar en el thread de la ui para poder mostrar el mensaje de impresion
                            @Override
                            public void run() {
                                terminar();
                            }
                        });
                    }
                };
                final Thread hilo = new Thread(accion);
                hilo.start();

				/*MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
                if (motConfig.get("MensajeImpresion").equals("0"))
				{
					// si no esta configurada la pregunta salir
					setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
					finalizar();
				}*/
            } catch (Exception ex) {
                mostrarError(ex.getMessage());
                btn.setEnabled(true);
            }
        }
    };

    public void guardar(String sNombre, String sNombreArchivo) {
        Button btn = (Button) findViewById(R.id.btnTerminar);
        try{
            if (!sNombre.equals("") && !sNombreArchivo.equals(""))
                mPresenta.guardarFirmaDigital(sNombre, sNombreArchivo);

            solicitarImprimirTicket();
        } catch (Exception ex) {
            mostrarError(ex.getMessage());
            btn.setEnabled(true);
        }
    }


	boolean esNuevo;
	float nTotalInicial;
	boolean surtir = false;
	boolean modificando = false;
    boolean modificandoAutoventa = false;
	boolean mensajeValidaCredito = false;
    boolean mensajeLimiteEnvase = false;
	float maxDesctoVendedor = 0;
	float maxImporteDesctoVendedor = 0;
	boolean imprimiendo;
    String GrupoValorRef="";
    float total = 0;
    float SubTotal = 0;
    float Impuestos = 0;
    HashMap<String, Float> totalesCalculadora;
    Boolean bIniciando = false;

	ModuloMovDetalle moduloMovDetalle = new ModuloMovDetalle();
    private Date fechaCobranza;
    private OnChangedListener mDiasCredito = new OnChangedListener() {

        @Override
        public void onChanged(NumberPicker picker, int oldVal, int newVal) {
            Calendar fecha = Calendar.getInstance();
            //fecha.setTime(Generales.getFechaActual());
            fecha.setTime(((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura);
            fecha.add(Calendar.DATE, Math.round(picker.getCurrent()));
            Button btnCobranza = (Button) findViewById(R.id.btnFechaCobranza);
            fechaCobranza = fecha.getTime();
            btnCobranza.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fecha.getTime()));

        }
    };
    private OnItemSelectedListener mFormaVenta = new OnItemSelectedListener() {

        @Override
        public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
            Cursor item = (Cursor) arg0.getItemAtPosition(arg2);
            if (!bIniciando) {
                if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("PrecioSegunCFVTipo").equals("1")) {
                    if (mPresenta.getTransacciones().get(0).CFVTipo != null && mPresenta.getTransacciones().get(0).CFVTipo != item.getShort(0)) {
                        if (mPresenta.getTransacciones().size() > 0) {
                            try {
                                HashMap<Integer, Precio> listasPrecio = ListaPrecio.Determinar(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, moduloMovDetalle, item.getShort(0));
                                //recorrer todas las transacciones, parte de agrupar transacciones
                                for (TransProd tran : mPresenta.getTransacciones()) {
                                    tran.CFVTipo = item.getShort(0);
                                    tran.setListaPrecios(listasPrecio);
                                    tran.PCEPrecioClave = listasPrecio.get(0).PrecioClave;
                                }
                                Transacciones.Pedidos.cambiarListaPrecios(mPresenta.getTransacciones());
                                setResultado(Enumeradores.Resultados.RESULTADO_BIEN, "I0274");
                                finalizar();
                            } catch (Exception ex) {
                                if (ex != null && ex.getMessage() != null) {
                                    mostrarError(ex.getMessage());
                                } else {
                                    mostrarError("Error al cambiar de Forma Venta");
                                }
                                bIniciando = true;
                                setFormaVenta(mPresenta.getTransacciones().get(0).CFVTipo);
                                bIniciando = false;
                                return;
                                //No encontro Precio
                            }
                        }
                    }
                }
            }

            if (item.getInt(0) == 2) { // CREDITO, MOSTRAR DIAS DE CREDITO Y FECHA DE COBRANZA

                // cargar los dias de credito y calcular la fecha cobranza
                // TextView text = (TextView) findViewById(R.id.txtDiasCredito);
                NumberPicker np = (NumberPicker) findViewById(R.id.npDiasCredito);
                np.setWrap(false);
                np.setRange(1, 100);
                np.setOnChangeListener(mDiasCredito);
                formaVenta.moveToFirst();
                do {
                    if (formaVenta.getInt(0) == item.getInt(0)) {
                        break;
                    }
                }
                while (formaVenta.moveToNext());
                // formaVenta.moveToPosition(item.getInt(0) - 1);

                // text.setText(formaVenta.getString("DiasCredito"));
                np.setCurrent(formaVenta.getInt("DiasCredito"));
                Button btnCobranza = (Button) findViewById(R.id.btnFechaCobranza);
                if (formaVenta.getInt("CapturaDias") == 0) {
                    // text.setEnabled(false);
                    np.setEnabled(false);
                    btnCobranza.setEnabled(false);
                }
                Calendar cal = Calendar.getInstance();
                cal.setTime(((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura);
                cal.add(Calendar.DATE, formaVenta.getInt("DiasCredito")); // sumar
                // los
                // dias
                // de
                // credito
                // a
                // la
                // fecha
                // captura
                fechaCobranza = cal.getTime();
                btnCobranza.setText(new SimpleDateFormat("dd/MMM/yyyy").format(cal.getTime()));
                btnCobranza.setOnClickListener(mFechaCobranza);

                TextView lbl = (TextView) findViewById(R.id.lblDiasCredito);
                // EditText txt = (EditText)findViewById(R.id.txtDiasCredito);
                lbl.setVisibility(View.VISIBLE);
                np.setVisibility(View.VISIBLE);

                lbl = (TextView) findViewById(R.id.lblFechaCobranza);
                Button btn = (Button) findViewById(R.id.btnFechaCobranza);
                lbl.setVisibility(View.VISIBLE);
                btn.setVisibility(View.VISIBLE);

            } else { // CONTADO
                TextView lbl = (TextView) findViewById(R.id.lblDiasCredito);
                // EditText txt = (EditText)findViewById(R.id.txtDiasCredito);
                NumberPicker np = (NumberPicker) findViewById(R.id.npDiasCredito);
                lbl.setVisibility(View.GONE);
                np.setVisibility(View.GONE);

                lbl = (TextView) findViewById(R.id.lblFechaCobranza);
                Button btn = (Button) findViewById(R.id.btnFechaCobranza);
                lbl.setVisibility(View.GONE);
                btn.setVisibility(View.GONE);
                /*
				 * try { HabilitarMoneda(mPresenta.getTransProdid()); } catch
				 * (Exception ex) { mostrarError(ex.getMessage()); }
				 */
            }
        }



        @Override
        public void onNothingSelected(AdapterView<?> arg0) {

        }
    };
    private DatePickerDialog.OnDateSetListener mFechaCobranzaListener = new DatePickerDialog.OnDateSetListener()
	{

        // when dialog box is closed, below method will be called.
        @SuppressWarnings("deprecation")
        @Override
        public void onDateSet(DatePicker view, int selectedYear, int selectedMonth, int selectedDay) {
            try {
                Calendar tmp = Calendar.getInstance();
                tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(new Date(selectedYear, selectedMonth, selectedDay)) + (new Date(selectedYear, selectedMonth, selectedDay)).getYear()));
                if (tmp.getTime().compareTo(((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura) < 0) { // la fecha seleccionada es menor a la de captura
                    return;
                }

                fechaCobranza = new Date(selectedYear, selectedMonth, selectedDay);
                Button btnCobranza = (Button) findViewById(R.id.btnFechaCobranza);
                btnCobranza.setText(new SimpleDateFormat("dd/MMM/").format(fechaCobranza) + fechaCobranza.getYear());
                NumberPicker np = (NumberPicker) findViewById(R.id.npDiasCredito);

                Calendar actual = Calendar.getInstance();
                Calendar cobranza = Calendar.getInstance();
                actual.setTime(((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura);
                cobranza.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(fechaCobranza) + fechaCobranza.getYear()));
                int diferencia = (int) ((Math.abs(cobranza.getTimeInMillis() - actual.getTimeInMillis())) / (24 * 60 * 60 * 1000));
                np.setCurrent(diferencia);
                fechaCobranza = cobranza.getTime();

            } catch (Exception ex) {
                mostrarError(ex.getMessage());
            }
        }

    };
    private Date fechaEntrega;
    private OnItemSelectedListener mTipoPedido = new OnItemSelectedListener() {

        @Override
        public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
            Cursor item = (Cursor) arg0.getItemAtPosition(arg2);

            if (item.getInt(0) == TipoPedido.POSFECHADO || item.getInt(0) == TipoPedido.CONSIGNACION || GrupoValorRef != "") { // POSFECHADO O CONSIGNACION, MOSTRAR FECHA DE ENTREGA
                TextView lbl = (TextView) findViewById(R.id.lblFechaEntrega);
                Button btnEntrega = (Button) findViewById(R.id.btnFechaEntrega);
                lbl.setVisibility(View.VISIBLE);
                btnEntrega.setVisibility(View.VISIBLE);
                setFechaEntregaDefault();
            } else {
                // calcular la fecha de entrega y ocultar
                setFechaEntregaDefault();
                //Calendar cal = Calendar.getInstance();
                Button btnEntrega = (Button) findViewById(R.id.btnFechaEntrega);
                /*cal.setTime(((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura);
				cal.add(Calendar.DATE, Integer.parseInt(oConHist.get("DiasSurtido").toString()));*/ // sumar
                // los
                // dias
                // de
                // surtido
                // a
                // la
                // fecha
                // captura
                //fechaEntrega = cal.getTime();
                //btnEntrega.setText(new SimpleDateFormat("dd/MMM/yyyy").format(cal.getTime()));
                btnEntrega.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaEntrega));
                btnEntrega.setOnClickListener(mFechaEntrega);

                TextView lbl = (TextView) findViewById(R.id.lblFechaEntrega);
                Button btnFechaE = (Button) findViewById(R.id.btnFechaEntrega);
                lbl.setVisibility(View.GONE);
                btnFechaE.setVisibility(View.GONE);
            }
        }

        @Override
        public void onNothingSelected(AdapterView<?> arg0) {

        }
    };
    private DatePickerDialog.OnDateSetListener mFechaEntregaListener = new DatePickerDialog.OnDateSetListener()
	{

        // when dialog box is closed, below method will be called.
        @SuppressWarnings("deprecation")
        @Override
        public void onDateSet(DatePicker view, int selectedYear, int selectedMonth, int selectedDay) {
            try {
                MOTConfiguracion motConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
                Calendar tmp = Calendar.getInstance();
                tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(new Date(selectedYear, selectedMonth, selectedDay)) + (new Date(selectedYear, selectedMonth, selectedDay)).getYear()));

                boolean DiasDeSurtido = false;
                int oParamDiasDeSurtido = 0;
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("DiasDeSurtido")) {

                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("DiasDeSurtido", moduloMovDetalle.ModuloMovDetalleClave) == null) {
                        DiasDeSurtido = false;
                    } else {
                        DiasDeSurtido = true;
                    }

                    if (DiasDeSurtido) {
                        DiasDeSurtido = true;
                        oParamDiasDeSurtido = Integer.valueOf(String.valueOf(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("DiasDeSurtido", moduloMovDetalle.ModuloMovDetalleClave)));
                    }
                }

                boolean DiasMaxDeSurtido = false;
                int oParamDiasMaxDeSurtido = 0;
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("DiasMaxDeSurtido")) {

                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("DiasMaxDeSurtido", moduloMovDetalle.ModuloMovDetalleClave) == null) {
                        DiasMaxDeSurtido = false;
                    } else {
                        DiasMaxDeSurtido = true;
                    }

                    if (DiasMaxDeSurtido) {
                        DiasMaxDeSurtido = true;
                        oParamDiasMaxDeSurtido = Integer.valueOf(String.valueOf(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("DiasMaxDeSurtido", moduloMovDetalle.ModuloMovDetalleClave)));
                    }
                }

                if (DiasDeSurtido && DiasMaxDeSurtido) {
                    if (oParamDiasMaxDeSurtido < 0) {
                        if (validarExcepcionesFrecuenciaFechasEntrega(tmp.getTime())) {
                            mostrarAdvertencia(Mensajes.get("E0911").replace("$0$", new SimpleDateFormat("dd/MMM/yyyy").format(tmp.getTime())));
                            return;
                        } else {
                            Date fechaMinima = sumarDias(oParamDiasDeSurtido);
                            if (tmp.getTime().compareTo(fechaMinima) >= 0) {
                                fechaEntrega = tmp.getTime();
                            } else {
                                mostrarAdvertencia(Mensajes.get("E0352").replace("$0$", new SimpleDateFormat("dd/MMM/yyyy").format(fechaMinima)));
                                return;
                            }
                        }
                    } else if (oParamDiasMaxDeSurtido > 0) {
                        if (validarExcepcionesFrecuenciaFechasEntrega(tmp.getTime())) {
                            mostrarAdvertencia(Mensajes.get("E0911").replace("$0$", new SimpleDateFormat("dd/MMM/yyyy").format(tmp.getTime())));
                            return;
                        } else {
                            Date fechaMinima = sumarDias(oParamDiasDeSurtido);
                            Date fechaMaxima = sumarDias(oParamDiasMaxDeSurtido);
                            if (tmp.getTime().compareTo(fechaMinima) >= 0) {
                                if (tmp.getTime().compareTo(fechaMaxima) <= 0) {
                                    fechaEntrega = tmp.getTime();
                                } else {
                                    mostrarAdvertencia(Mensajes.get("E0910").replace("$0$", new SimpleDateFormat("dd/MMM/yyyy").format(fechaMaxima)));
                                }
                            } else {
                                mostrarAdvertencia(Mensajes.get("E0352").replace("$0$", new SimpleDateFormat("dd/MMM/yyyy").format(fechaMinima)));
                                return;
                            }
                        }
                    } else if (oParamDiasMaxDeSurtido == 0) {
                        if (validarExcepcionesFrecuenciaFechasEntrega(tmp.getTime())) {
                            mostrarAdvertencia(Mensajes.get("E0911").replace("$0$", new SimpleDateFormat("dd/MMM/yyyy").format(tmp.getTime())));
                            return;
                        } else {
                            Date fechaMinima = ((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura;
                            if (tmp.getTime().compareTo(fechaMinima) >= 0) {
                                fechaEntrega = tmp.getTime();
                            } else {
                                mostrarAdvertencia(Mensajes.get("E0389"));
                                return;
                            }
                        }
                    }
                } else {
                    if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA || (mPresenta.getTipo() == TiposTransProd.MOV_SIN_INV_EV && motConf.get("MSIEVPreventa").toString().equals("1"))) {
                        if (Integer.parseInt(oConHist.get("DiasMaxSurtido").toString()) < 0) {
                            if (validarExcepcionesFrecuenciaFechasEntrega(tmp.getTime())) {
                                mostrarAdvertencia(Mensajes.get("E0911").replace("$0$", new SimpleDateFormat("dd/MMM/yyyy").format(tmp.getTime())));
                                return;
                            } else {
                                Date fechaMinima = (Date) Sesion.get(Campo.FechaMinimaEntrega);
                                if (tmp.getTime().compareTo(fechaMinima) >= 0) {
                                    fechaEntrega = tmp.getTime();
                                } else {
                                    mostrarAdvertencia(Mensajes.get("E0352").replace("$0$", new SimpleDateFormat("dd/MMM/yyyy").format(fechaMinima)));
                                    return;
                                }
                            }
                        } else if (Integer.parseInt(oConHist.get("DiasMaxSurtido").toString()) > 0) {
                            if (validarExcepcionesFrecuenciaFechasEntrega(tmp.getTime())) {
                                mostrarAdvertencia(Mensajes.get("E0911").replace("$0$", new SimpleDateFormat("dd/MMM/yyyy").format(tmp.getTime())));
                                return;
                            } else {
                                Date fechaMinima = (Date) Sesion.get(Campo.FechaMinimaEntrega);
                                Date fechaMaxima = (Date) Sesion.get(Campo.FechaMaximaEntrega);
                                if (tmp.getTime().compareTo(fechaMinima) >= 0) {
                                    if (tmp.getTime().compareTo(fechaMaxima) <= 0) {
                                        fechaEntrega = tmp.getTime();
                                    } else {
                                        mostrarAdvertencia(Mensajes.get("E0910").replace("$0$", new SimpleDateFormat("dd/MMM/yyyy").format(fechaMaxima)));
                                    }
                                } else {
                                    mostrarAdvertencia(Mensajes.get("E0352").replace("$0$", new SimpleDateFormat("dd/MMM/yyyy").format(fechaMinima)));
                                    return;
                                }
                            }
                        } else if (Integer.parseInt(oConHist.get("DiasMaxSurtido").toString()) == 0) {
                            if (validarExcepcionesFrecuenciaFechasEntrega(tmp.getTime())) {
                                mostrarAdvertencia(Mensajes.get("E0911").replace("$0$", new SimpleDateFormat("dd/MMM/yyyy").format(tmp.getTime())));
                                return;
                            } else {
                                Date fechaMinima = ((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura;
                                if (tmp.getTime().compareTo(fechaMinima) >= 0) {
                                    fechaEntrega = tmp.getTime();
                                } else {
                                    mostrarAdvertencia(Mensajes.get("E0389"));
                                    return;
                                }
                            }
                        }
                    } else {
                        if (tmp.getTime().compareTo(((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura) < 0) { // la fecha seleccionada es menor a la de captura
                            return;
                        }
                        fechaEntrega = tmp.getTime();
                    }
                }


                Button btnEntrega = (Button) findViewById(R.id.btnFechaEntrega);
                btnEntrega.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaEntrega));

				/*Calendar tmp = Calendar.getInstance();
                tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(new Date(selectedYear, selectedMonth, selectedDay)) + (new Date(selectedYear, selectedMonth, selectedDay)).getYear()));
				if (tmp.getTime().compareTo(Generales.getFechaActual()) < 0)
				{ // la fecha seleccionada es menor a la de captura
					return;
				}

				fechaEntrega = new Date(selectedYear, selectedMonth, selectedDay);
				Calendar entrega = Calendar.getInstance();
				entrega.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(fechaEntrega) + fechaEntrega.getYear()));
				Button btnCobranza = (Button) findViewById(R.id.btnFechaEntrega);
				btnCobranza.setText(new SimpleDateFormat("dd/MMM/").format(fechaEntrega) + fechaEntrega.getYear());
				fechaEntrega = entrega.getTime();*/
            } catch (Exception ex) {
                mostrarError(ex.getMessage());
            }
        }

    };

    private CONHist oConHist;
    private int formaVentaInicial = -1;
    private OnClickListener mImpuestos = new OnClickListener()
	{

        @Override
        public void onClick(View v) {
            try {

                LayoutInflater inflater = (LayoutInflater) CapturaTotales.this
                        .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

                View dialogView = inflater.inflate(R.layout.dialog_impuestopromocion, null);

                AlertDialog.Builder builder = new AlertDialog.Builder(v.getContext());
                TextView lblTituloGeneral = (TextView) dialogView.findViewById(R.id.lblTituloDialogoPromocion);
                lblTituloGeneral.setText(Mensajes.get("XDesgloseImpPromo"));

                TextView lblImpuestoPromociones = (TextView) dialogView.findViewById(R.id.lblImpuestoPromociones);
                lblImpuestoPromociones.setText(Mensajes.get("MDBImpuestos"));
                ListView modeList = (ListView) dialogView.findViewById(R.id.lstImpuestoPromociones);
                modeList.setBackgroundColor(Color.WHITE);

                NumberPicker np = (NumberPicker) v.getRootView().findViewById(R.id.npPorVendedor);
                vistaDesgloseImp[] desgloseImpuestos = mPresenta.obtenerDesgloseImpuestos(np.getCurrentDecimal());
                if (desgloseImpuestos != null) {
                    adapterDesgloseImp adapter = new adapterDesgloseImp(v.getContext(), R.layout.elemento_desglose_impuestos, desgloseImpuestos);
                    modeList.setAdapter(adapter);
                    setListViewHeightBasedOnChildren(modeList);
                } else {
                    TextView lblImpuestoPromocionesNoAplica = (TextView) dialogView.findViewById(R.id.lblImpuestoPromocionesNoAplica);
                    lblImpuestoPromocionesNoAplica.setVisibility(View.VISIBLE);
                    lblImpuestoPromocionesNoAplica.setText("No Aplica");
                    modeList.setVisibility(View.GONE);
                }
                /*Promociones*/
                TextView lblPromocionesImpuesto = (TextView) dialogView.findViewById(R.id.lblPromocionesImpuesto);
                lblPromocionesImpuesto.setText(Mensajes.get("XPromocionesAplicadas"));
                ListView modeListlblPromociones = (ListView) dialogView.findViewById(R.id.lstPromocionesImpuesto);
                modeList.setBackgroundColor(Color.WHITE);
                @SuppressWarnings("unchecked")
                ArrayList<vistaDesgloseProm> desglosePromociones = mPresenta.obtenerDesglosePromociones((ArrayList<String>) oParametros.get("TransProdId"));

                if (desglosePromociones != null) {
                    final adapterDesglosePro adapter = new adapterDesglosePro(v.getContext(), R.layout.lista_pedidopromocion_producto, desglosePromociones);
                    modeListlblPromociones.setAdapter(adapter);
                    setListViewHeightBasedOnChildren(modeListlblPromociones);
                }
                /*Promociones de Regalo y Canje*/
                TextView lblPromocionesRegaloCanje = (TextView) dialogView.findViewById(R.id.lblPromocionesRegaloCanje);
                lblPromocionesRegaloCanje.setText(Mensajes.get("XRegalosYCanjes"));
                ListView modeListlblPromocionesRegaloCanje = (ListView) dialogView.findViewById(R.id.lstPromocionesRegaloCanje);
                modeList.setBackgroundColor(Color.WHITE);
                @SuppressWarnings("unchecked")
                ArrayList<vistaPromoRegaloCanje> desglosePromocionesRegaloCanje = mPresenta.obtenerDesglosePromocionesRegaloCanje((ArrayList<String>) oParametros.get("TransProdId"));

                if (desglosePromocionesRegaloCanje != null) {
                    final adapterDesglosePromRegaloCanje adapter = new adapterDesglosePromRegaloCanje(v.getContext(), R.layout.lista_pedidopromocion_producto, desglosePromocionesRegaloCanje);
                    modeListlblPromocionesRegaloCanje.setAdapter(adapter);
                    setListViewHeightBasedOnChildren(modeListlblPromocionesRegaloCanje);
                }
                /*Pronto Pago*/
                TextView lblPromoProntoPago = (TextView) dialogView.findViewById(R.id.lblPromoProntoPago);
                lblPromoProntoPago.setText(Mensajes.get("XSecPromoProntoPago"));
                ListView lstPromoProntoPago = (ListView) dialogView.findViewById(R.id.lstPromoProntoPago);
                modeList.setBackgroundColor(Color.WHITE);
                @SuppressWarnings("unchecked")
                ArrayList<vistaDesgloseProntoPago> desglosePromoProntoPago = mPresenta.obtenerDesglosePromoProntoPago((ArrayList<String>) oParametros.get("TransProdId"));

                if (desglosePromoProntoPago != null) {
                    final adapterDesgloseProntoPago adapter = new adapterDesgloseProntoPago(v.getContext(), R.layout.elemento_promo_pronto_pago, desglosePromoProntoPago);
                    lstPromoProntoPago.setAdapter(adapter);
                    setListViewHeightBasedOnChildren(lstPromoProntoPago);
                }

                builder.setPositiveButton("Aceptar", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.dismiss();
                    }
                });
                builder.setView(dialogView);
                final Dialog dialog = builder.create();

                dialog.show();

            } catch (Exception ex) {
                mostrarError(ex.getMessage());
            }
        }
    };
    private OnChangedListener mPorcentaje = new OnChangedListener() {

        @Override
        public void onChanged(NumberPicker picker, int oldVal, int newVal) {
            if (oldVal != newVal) { // || newVal == 0){
                if (separarTotalesSubEmpresa){
                    Spinner spn = (Spinner) findViewById(R.id.spFolio);
                    HashMap<String,TransProd> spinnerMap = (HashMap<String,TransProd>)spn.getTag();
                    mPresenta.calcularDescVendedor(spinnerMap.get(folioSeleccionado), picker.getCurrentDecimal());
                }else{
                    mPresenta.calcularDescVendedor(picker.getCurrentDecimal());
                }
            }
        }
    };
    private OnChangedListener mImporte = new OnChangedListener() {

        @Override
        public void onChanged(NumberPicker picker, int oldVal, int newVal) {
            if (oldVal != newVal) { // || newVal == 0){
                if (separarTotalesSubEmpresa){
                    Spinner spn = (Spinner) findViewById(R.id.spFolio);
                    HashMap<String,TransProd> spinnerMap = (HashMap<String,TransProd>)spn.getTag();
                    mPresenta.calcularImpDescVendedor(spinnerMap.get(folioSeleccionado), picker.getCurrentDecimal());
                }else {
                    mPresenta.calcularImpDescVendedor(picker.getCurrentDecimal());
                }
            }
        }
    };

    @SuppressLint("CutPasteId")
    @SuppressWarnings("unchecked")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        try {
            bIniciando = true;
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            //Inicializar variables
            imprimiendo = false;
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("SepararTotalesSubEmpresa")) {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("SepararTotalesSubEmpresa").equalsIgnoreCase("1")) {
                    separarTotalesSubEmpresa = true;
                }
            }

            setContentView(R.layout.captura_totales);
            deshabilitarBarra(true);
            setTitulo(Mensajes.get("XTOTALES"));

            EditText edit = (EditText) findViewById(R.id.txtFolio);
            edit.setEnabled(false);
            edit.setSelectAllOnFocus(true);
            edit = (EditText) findViewById(R.id.txtSubtotalProducto);
            edit.setEnabled(false);
            edit.setSelectAllOnFocus(true);
            edit = (EditText) findViewById(R.id.txtDescYBonif);
            edit.setEnabled(false);
            edit.setSelectAllOnFocus(true);
            edit = (EditText) findViewById(R.id.txtSubtotal);
            edit.setEnabled(false);
            edit.setSelectAllOnFocus(true);
            edit = (EditText) findViewById(R.id.txtImpuesto);
            edit.setEnabled(false);
            edit.setSelectAllOnFocus(true);
            edit = (EditText) findViewById(R.id.txtTotal);
            edit.setEnabled(false);
            edit.setSelectAllOnFocus(true);

            TextView texto = (TextView) findViewById(R.id.lblFolio);
            texto.setText(Mensajes.get("XFolio"));

            texto = (TextView) findViewById(R.id.lblTipoPedido);
            texto.setText(Mensajes.get("XTipoPedido"));

            texto = (TextView) findViewById(R.id.lblFormaVenta);
            texto.setText(Mensajes.get("XFormaVenta"));

            texto = (TextView) findViewById(R.id.lblFormaPago);
            texto.setText(Mensajes.get("XFormaPago"));

            texto = (TextView) findViewById(R.id.lblDiasCredito);
            texto.setText(Mensajes.get("XDiasCredito"));

            texto = (TextView) findViewById(R.id.lblFechaCobranza);
            texto.setText(Mensajes.get("XFechaCobranza"));

            texto = (TextView) findViewById(R.id.lblFechaEntrega);
            texto.setText(Mensajes.get("XFechaEntrega"));

            texto = (TextView) findViewById(R.id.lblSubtotalProducto);
            texto.setText(Mensajes.get("XSubtotalProducto"));

            texto = (TextView) findViewById(R.id.lblDescYBonif);
            texto.setText(Mensajes.get("XDescYBonif"));

            TextView descto = (TextView) findViewById(R.id.lblPorVendedor);
            descto.setText(Mensajes.get("X%Vendedor"));
            // descto.addTextChangedListener(mDesctoVendedor);

            TextView impdescto = (TextView) findViewById(R.id.lblDescVendedor);
            impdescto.setText(Mensajes.get("XDesc.Vendedor"));
            // impdescto.addTextChangedListener(mImpDesctoVendedor);

			/*
             * texto = (TextView) findViewById(R.id.lblBonificacion);
			 * texto.setText(Mensajes.get("XBonificacion"));
			 */

            NumberPicker np = (NumberPicker) findViewById(R.id.npDiasCredito);
            np.ocultarBotones(true);
            np.setTextSize(20);
            np.setEditeTextBackgroundToNull();

            np = (NumberPicker) findViewById(R.id.npPorVendedor);
            np.ocultarBotones(true);
            np.setTextSize(20);
            np.setEditeTextBackgroundToNull();

            np = (NumberPicker) findViewById(R.id.npDescVendedor);
            np.ocultarBotones(true);
            np.setTextSize(20);
            np.setEditeTextBackgroundToNull();

            texto = (TextView) findViewById(R.id.lblSubtotal);
            texto.setText(Mensajes.get("XSubtotal"));

            texto = (TextView) findViewById(R.id.lblImpuesto);
            texto.setText(Mensajes.get("XImpuesto"));

            texto = (TextView) findViewById(R.id.lblTotal);
            texto.setText(Mensajes.get("XTotal"));

            texto = (TextView) findViewById(R.id.lblNotas);
            texto.setText(Mensajes.get("XNotas"));

            texto = (TextView) findViewById(R.id.lblPedidoAdicional);
            texto.setText(Mensajes.get("XPedidoAdicional"));

            texto = (TextView) findViewById(R.id.lblObservaciones);
            texto.setText(Mensajes.get("XObservaciones"));
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("MostrarCampoNoPedCte",Sesion.get(Campo.ModuloMovDetalleClave).toString())) {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("MostrarCampoNoPedCte", Sesion.get(Campo.ModuloMovDetalleClave).toString()).toString().equalsIgnoreCase("1")) {
                    LinearLayout layObservaciones2 = (LinearLayout) findViewById(R.id.layObservaciones2);
                    layObservaciones2.setVisibility(View.VISIBLE);
                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("LongitudCampoNoPedCte",Sesion.get(Campo.ModuloMovDetalleClave).toString())) {
                        int longCampo = Integer.parseInt(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("LongitudCampoNoPedCte", Sesion.get(Campo.ModuloMovDetalleClave).toString()).toString());
                        EditText txtObservaciones2 = (EditText) findViewById(R.id.txtObservaciones2);
                        txtObservaciones2.setFilters(new InputFilter[] {new InputFilter.LengthFilter(longCampo)});
                    }
                }
            }

            texto = (TextView) findViewById(R.id.lblFolioNeg);
            texto.setText(Mensajes.get("XFolioNegociacion"));
            if( ((Cliente) Sesion.get(Campo.ClienteActual)).ValidaFolNeg ){
                LinearLayout layFolioNeg = (LinearLayout) findViewById(R.id.layFolioNeg);
                layFolioNeg.setVisibility(View.VISIBLE);
            }

            texto = (TextView) findViewById(R.id.lblObservaciones2);
            texto.setText(Mensajes.get("XNoPedidoCliente"));

            texto = (TextView) findViewById(R.id.lblPuntoEntrega);
            texto.setText(Mensajes.get("XDomPuntoEnt"));

            texto = (TextView) findViewById(R.id.lblTurno);
            texto.setText(Mensajes.get("XTurno"));

            Button btn = (Button) findViewById(R.id.btnImpuestos);
            btn.setText(Mensajes.get("XImpuestoPromocion"));
            btn.setOnClickListener(mImpuestos);

            btn = (Button) findViewById(R.id.btnTerminar);
            btn.setText(Mensajes.get("XTerminar"));
            btn.setOnClickListener(mTerminar);

            // obtener el parametro
            if (getIntent().getSerializableExtra("parametros") != null) {
                oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
			}

            if (oParametros != null) {
                aTransProdIds = (ArrayList<String>) oParametros.get("TransProdId");
                ArrayList<String> nuevo = (ArrayList<String>) oParametros.get("esNuevo");
                esNuevo = Boolean.parseBoolean(nuevo.get(0));
                moduloMovDetalle = (ModuloMovDetalle) oParametros.get("ModuloMovDetalle");
                nTotalInicial = Float.parseFloat(oParametros.get("TotalInicial").toString());
                surtir = Boolean.parseBoolean(oParametros.get("Surtir").toString());
                modificando = Boolean.parseBoolean(oParametros.get("Modificando").toString());
                modificandoAutoventa = Boolean.parseBoolean(oParametros.get("ModificandoAutoventa").toString());
            }

            obtenerValoresPorReferencia();

            if (aTransProdIds != null && aTransProdIds.size() > 0) {
                oConHist = (CONHist) Sesion.get(Campo.CONHist);
                // llenar los combos con los valores por referencia
                cargarTiposPedido();
                cargarFormasVenta();
                cargarFormasPago();
                cargarTurnos();
                cargarPuntosEntrega();
                // validarDesctoVendedor();

                mPresenta = new CapturarTotales(this, mAccion, aTransProdIds);
                mPresenta.iniciar();
            }

            if (soloLectura) {
                HabilitarControles(false);
                getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
            } else {
                //Spinner spin = (Spinner) findViewById(R.id.spFormaPago);
                //spin.setOnItemSelectedListener(mFormaPago);
                Spinner spin = (Spinner) findViewById(R.id.spTipoPedido);
                spin.requestFocus();
            }

			/*
             * String sModuloMovDetalleClave =
			 * (String)Sesion.get(Campo.ModuloMovDetalleClave);
			 * moduloMovDetalle.ModuloMovDetalleClave = sModuloMovDetalleClave;
			 * BDVend.recuperar(moduloMovDetalle);
			 */

		} catch (Exception ex) {
            mostrarError(ex.getMessage());
        }

        Spinner spPtoDeliver = (Spinner) findViewById(R.id.spPuntoEntrega);

        if (!(spPtoDeliver.getCount() > 1))
            spPtoDeliver.setEnabled(false);

        spPtoDeliver = (Spinner) findViewById(R.id.spTipoPedido);
        //spPtoDeliver.setEnabled(false);
        if (!(spPtoDeliver.getCount() > 1))
            spPtoDeliver.setEnabled(false);

        Spinner spFormaVenta = (Spinner) findViewById(R.id.spFormaVenta);
        if (!(spFormaVenta.getCount() > 1))
            spFormaVenta.setEnabled(false);

        spPtoDeliver = (Spinner) findViewById(R.id.spFormaPago);
        if (!(spPtoDeliver.getCount() > 1))
            spPtoDeliver.setEnabled(false);

        bIniciando = false;
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_captura_totales, menu);

        menu.getItem(0).setTitle(Mensajes.get("XVistaPrevia"));

        menu.getItem(1).setTitle(Mensajes.get("XCalculadoraDescuento"));

        menu.getItem(2).setTitle(Mensajes.get("XConvertirProductos"));
        try {
            menu.getItem(1).setVisible(false);
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("CalcularDescuento",Sesion.get(Campo.ModuloMovDetalleClave).toString())) {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("CalcularDescuento", Sesion.get(Campo.ModuloMovDetalleClave).toString()).toString().equalsIgnoreCase("1")) {
                    menu.getItem(1).setVisible(true);
                } else {
                    menu.getItem(1).setVisible(false);
                }
            }
            menu.getItem(2).setVisible(false);
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ConvertirProductos")) {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ConvertirProductos").equalsIgnoreCase("1")) {
                    menu.getItem(2).setVisible(true);
                } else {
                    menu.getItem(2).setVisible(false);
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        NumberPicker txtDescVend = (NumberPicker)findViewById(R.id.npPorVendedor);
        if (txtDescVend.isEnabled()) {
            txtDescVend.clearFocus();
            txtDescVend = (NumberPicker) findViewById(R.id.npDescVendedor);
            txtDescVend.clearFocus();
        }
        switch (item.getItemId()) {
            case R.id.vista_previa:
                try {
                    File file = generarPDFVistaPrevia();

                    //mostrar vista previa PDF
                    Intent intent = new Intent();
                    intent.putExtra("idReporte", -1);
                    intent.putExtra("titulo", Mensajes.get("XVistaPrevia"));
                    intent.setDataAndType(Uri.fromFile(file), "application/pdf");
                    intent.setClass( this, PDFViewer.class);
                    intent.setAction("android.intent.action.VIEW");
                    this.startActivity(intent);
                } catch (Exception ex) {
                    mostrarError("Error al generar la vista previa: " + ex.getMessage());
                }
                break;
            case R.id.convertir_productos:
                try {
                    File file = mPresenta.generarPDFConsolidacionPedidoCOS();

                    //mostrar vista previa PDF
                    Intent intent = new Intent();
                    intent.putExtra("idReporte", -1);
                    intent.putExtra("titulo", Mensajes.get("XConsolidacionPedido"));
                    intent.setDataAndType(Uri.fromFile(file), "application/pdf");
                    intent.setClass( this, PDFViewer.class);
                    intent.setAction("android.intent.action.VIEW");
                    this.startActivity(intent);
                } catch (Exception ex) {
                    mostrarError("Error al generar la Consolidación del Pedido: " + ex.getMessage());
                }
                break;
            case R.id.calcular_promocion:
                try {
                    final Context ctx = this;

                    LayoutInflater inflater = getLayoutInflater();

                    View dialogView = inflater.inflate(R.layout.dialog_calcularpromocion, null);

                    final AlertDialog.Builder builder = new AlertDialog.Builder(this);

                    TextView lblTituloGeneral = (TextView) dialogView.findViewById(R.id.lblTituloDialogoCaluculadoraDes);
                    lblTituloGeneral.setText(Mensajes.get("XCalculadoraDescuento"));

                    TextView label = (TextView) dialogView.findViewById(R.id.lbtotalVenta);
                    label.setText(Mensajes.get("XTotalVent"));

                    label = (TextView) dialogView.findViewById(R.id.lbDesc1);
                    label.setText(Mensajes.get("XDescuento") + " 1");

                    label = (TextView) dialogView.findViewById(R.id.lbDesc2);
                    label.setText(Mensajes.get("XDescuento") + " 2");

                    label = (TextView) dialogView.findViewById(R.id.lbtotalVentaDesc);
                    label.setText(Mensajes.get("XTotalVentaDes"));

                    final EditText edTotalVenta = (EditText) dialogView.findViewById(R.id.ettotalVenta);
                    edTotalVenta.setEnabled(false);

                    edTotalVenta.setText("$ " + Generales.getFormatoDecimal(SubTotal,"#,##0.00"));
                    totalesCalculadora = new HashMap<String, Float>();
                    totalesCalculadora.put("SubTotal",SubTotal );
                    totalesCalculadora.put("Impuesto", Impuestos);
                    totalesCalculadora.put("Total", total);

                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("CalculadoraClasificaciones")) {
                        if (!((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("CalculadoraClasificaciones").equalsIgnoreCase("")) {
                            totalesCalculadora  = Consultas.ConsultasTransProdDetalle.obtenerTotalesPorClasificacion(aTransProdIds.get(0), ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("CalculadoraClasificaciones"));
                        }
                    }

                    final EditText edTotalVentaDes = (EditText) dialogView.findViewById(R.id.ettotalVentaDesc);
                    edTotalVentaDes.setEnabled(false);

                    final EditText edDesc1 = (EditText) dialogView.findViewById(R.id.etdesc1);
                    final EditText edDesc2 = (EditText) dialogView.findViewById(R.id.etdesc2);
                    final Button btnCalcula = (Button) dialogView.findViewById(R.id.btnCalcular);
                    edDesc1.requestFocus();

                    final String lbDescuento = Mensajes.get("XDescuento");

                    /*Validar que el descuento no sea mayor a 100 o menor a 0 cuando pierde el focus*/
                    edDesc1.setOnFocusChangeListener(new View.OnFocusChangeListener() {
                        @Override
                        public void onFocusChange(View v, boolean hasFocus) {
                            edTotalVentaDes.setText("");
                            if (!hasFocus) {
                                if(edDesc1.getText().toString().isEmpty())
                                {
                                    edDesc1.setText("0");
                                }
                                float des1 = Float.parseFloat(edDesc1.getText().toString());

                                if ((des1 > 100 || des1 <= 0)) {
                                    //Mensajes.get("E0911").replace("$0$", new SimpleDateFormat("dd/MMM/yyyy").format(tmp.getTime()))
                                    AlertDialog.Builder bb = new AlertDialog.Builder(ctx);
                                    bb.setMessage(Mensajes.get("E0604").replace("$0$", lbDescuento + " 1").replace("$1$", "0").replace("$2$", "100"));
                                    bb.setCancelable(false);
                                    bb.setPositiveButton(Mensajes.get("XAceptar"), new DialogInterface.OnClickListener() {

                                        @Override
                                        public void onClick(DialogInterface di, int which) {
                                            di.cancel();
                                        }
                                    });
                                    bb.show();


                                }

                            }
                        }
                    });

                    edDesc2.setOnFocusChangeListener(new View.OnFocusChangeListener() {
                        @Override
                        public void onFocusChange(View v, boolean hasFocus) {
                            edTotalVentaDes.setText("");
                            if (!hasFocus) {
                                if(edDesc2.getText().toString().isEmpty())
                                {
                                    edDesc2.setText("0");
                                }
                                float des2 = Float.parseFloat(edDesc2.getText().toString());

                                if ((des2 > 100 || des2 <= 0)) {
                                    AlertDialog.Builder bb = new AlertDialog.Builder(ctx);
                                    bb.setMessage(Mensajes.get("E0604").replace("$0$", lbDescuento + " 1").replace("$1$", "0").replace("$2$", "100"));
                                    bb.setCancelable(false);
                                    bb.setPositiveButton(Mensajes.get("XAceptar"), new DialogInterface.OnClickListener() {

                                        @Override
                                        public void onClick(DialogInterface di, int which) {
                                            di.cancel();
                                        }
                                    });
                                    bb.show();

                                }


                            }
                        }
                    });
                    /*Fin de la validacion*/

                    edDesc1.setText("0");
                    edDesc2.setText("0");

                    builder.setView(dialogView);
                    final Dialog dialog = builder.create();


                    btnCalcula.setText(Mensajes.get("XCalcular"));
                    btnCalcula.setOnClickListener(new OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            edTotalVentaDes.setText("");
                            if (!edDesc1.getText().toString().equals(".") && !edDesc2.getText().toString().equals(".")) {
                                if (!edDesc1.getText().toString().equals("") && !edDesc2.getText().toString().equals("")) {
                                    float des1 = Float.parseFloat(edDesc1.getText().toString());
                                    float des2 = Float.parseFloat(edDesc2.getText().toString());
                                    if (!(des1 > 100 || des1 < 0) && !(des2 > 100 || des2 < 0)) {
                                        float primerDes = 0;
                                        float segundoDes = 0;
                                        float subTotalDescuento = 0;
                                        float impuestoDescuento = 0;
                                        float total = 0;
                                        if (totalesCalculadora.get("SubTotal") > 0) {
                                            primerDes = (totalesCalculadora.get("SubTotal") * des1) / 100;
                                            segundoDes = ((totalesCalculadora.get("SubTotal") - primerDes) * des2) / 100;

                                            subTotalDescuento = totalesCalculadora.get("SubTotal") - (primerDes + segundoDes);
                                        }

                                        if (totalesCalculadora.get("Impuesto") > 0){
                                            primerDes = (totalesCalculadora.get("Impuesto") * des1) / 100;
                                            segundoDes = ((totalesCalculadora.get("Impuesto") - primerDes) * des2) / 100;

                                            impuestoDescuento = totalesCalculadora.get("Impuesto") - (primerDes + segundoDes);
                                        }
                                        total = ((SubTotal - totalesCalculadora.get("SubTotal")) +  subTotalDescuento) + ((Impuestos - totalesCalculadora.get("Impuesto")) +  impuestoDescuento);
                                        edTotalVentaDes.setText("$ " +  Generales.getFormatoDecimal( total,"#,##0.00"));
                                        mPresenta.CapturarDescuento(des1,des2);
                                    } else {
                                        AlertDialog.Builder bb = new AlertDialog.Builder(ctx);
                                        bb.setMessage(Mensajes.get("E0604").replace("$0$", lbDescuento + " 1 y " + lbDescuento + " 2").replace("$1$", "0").replace("$2$", "100"));
                                        bb.setCancelable(false);
                                        bb.setPositiveButton(Mensajes.get("XAceptar"), new DialogInterface.OnClickListener() {

                                            @Override
                                            public void onClick(DialogInterface di, int which) {
                                                di.cancel();
                                            }
                                        });
                                        bb.show();
                                    }


                                } else {
                                    edDesc1.setText("0");
                                    edDesc2.setText("0");
                                }
                            } else {
                                AlertDialog.Builder bb = new AlertDialog.Builder(ctx);
                                bb.setMessage(Mensajes.get("E0353"));
                                bb.setCancelable(false);
                                bb.setPositiveButton(Mensajes.get("XAceptar"), new DialogInterface.OnClickListener() {

                                    @Override
                                    public void onClick(DialogInterface di, int which) {
                                        di.cancel();
                                    }
                                });
                                bb.show();
                            }

                        }
                    });

                    Button btnSalir = (Button) dialogView.findViewById(R.id.btnSalir);
                    btnSalir.setText(Mensajes.get("BTSalir"));
                    btnSalir.setOnClickListener(new OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            dialog.dismiss();

                        }
                    });


                    dialog.show();


                } catch (Exception ex) {
                    mostrarError(ex.getMessage());
                }

                break;
            default:
                break;
        }
        return true;
    }

    public void enableTipoPedido(boolean habilitar) {
        Spinner spTipoPedido = (Spinner) findViewById(R.id.spTipoPedido);
        spTipoPedido.setEnabled(habilitar);
    }

    public boolean getEsNuevo() {
        return esNuevo;
    }

    public boolean getSurtir() {
        return surtir;
    }

    public boolean getModificando() {
        return modificando;
    }

    public boolean getModificandoAutoventa() {
        return modificandoAutoventa;
    }

    public boolean getSepararTotalesSubEmpresa() {
        return separarTotalesSubEmpresa;
    }

	/*
	 * public void setTipoFase(int TipoFase) {
	 * tiposFase.moveToPosition(TipoFase); // mover el cursor del valor por //
	 * referencia EditText text = (EditText) findViewById(R.id.txtFase);
	 * text.setText(tiposFase.getString(2)); // obtener la descripcion del //
	 * valor por referencia }
	 */

	public float getTotalInicial() {
        return nTotalInicial;
    }

	private void HabilitarControles(boolean habilitar) {
        Spinner spin = (Spinner) findViewById(R.id.spTipoPedido);
        spin.setEnabled(habilitar);

        spin = (Spinner) findViewById(R.id.spFormaVenta);
        spin.setEnabled(habilitar);

        spin = (Spinner) findViewById(R.id.spFormaPago);
        spin.setEnabled(habilitar);

        spin = (Spinner) findViewById(R.id.spPuntoEntrega);
        spin.setEnabled(habilitar);
        /*
         * EditText edit = (EditText) findViewById(R.id.txtDiasCredito);
		 * edit.setEnabled(habilitar);
		 */
        NumberPicker np = (NumberPicker) findViewById(R.id.npDiasCredito);
        np.setEnabled(habilitar);

        Button btn = (Button) findViewById(R.id.btnFechaCobranza);
        btn.setEnabled(habilitar);

        btn = (Button) findViewById(R.id.btnFechaEntrega);
        btn.setEnabled(habilitar);

		/*
         * edit = (EditText) findViewById(R.id.txtPorVendedor);
		 * edit.setEnabled(habilitar);
		 */
        np = (NumberPicker) findViewById(R.id.npPorVendedor);
        np.setEnabled(habilitar);

		/*
		 * edit = (EditText) findViewById(R.id.txtDescVendedor);
		 * edit.setEnabled(habilitar);
		 */
        np = (NumberPicker) findViewById(R.id.npDescVendedor);
        np.setEnabled(habilitar);

		/*
		 * EditText edit = (EditText) findViewById(R.id.txtBonificacion);
		 * edit.setEnabled(habilitar);
		 */

        EditText edit = (EditText) findViewById(R.id.txtNotas);
        edit.setEnabled(habilitar);

        edit = (EditText) findViewById(R.id.txtPedidoAdicional);
        edit.setEnabled(habilitar);

        edit = (EditText) findViewById(R.id.txtObservaciones);
        edit.setEnabled(habilitar);

        edit = (EditText) findViewById(R.id.txtObservaciones2);
        edit.setEnabled(habilitar);
	}

    public void validarDesctoVendedor(float subTDetalle, float descuentoImp) throws Exception {
        boolean habilitar = Descuentos.ValidarAplicacion("AplicaVendedor");
        /*
		 * EditText texto = (EditText) findViewById(R.id.txtDescVendedor);
		 * texto.setEnabled(habilitar);
		 */
        NumberPicker npImp = (NumberPicker) findViewById(R.id.npDescVendedor);
        npImp.setEnabled(habilitar);
		/*
		 * texto = (EditText) findViewById(R.id.txtPorVendedor);
		 * texto.setEnabled(habilitar);
		 */
        NumberPicker npPor = (NumberPicker) findViewById(R.id.npPorVendedor);
        npPor.setEnabled(habilitar);

        if (habilitar) {
            Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
            maxDesctoVendedor = vendedor.LimiteDescuento;
            maxImporteDesctoVendedor = (subTDetalle - descuentoImp) * (vendedor.LimiteDescuento <= 0 ? 0 : (vendedor.LimiteDescuento / 100));

            npImp.setDecimal(2);
            // npImp.setStep(100);
            npImp.setStep(1);
            npImp.setWrap(false);
            // npImp.setRange(0, (int) (maxImporteDesctoVendedor * 100));
            npImp.setRangeDecimal(0, Generales.getRound(maxImporteDesctoVendedor, 2));
            npImp.setOnChangeListener(mImporte);

            npPor.setDecimal(4);
            // npPor.setStep(10000);
            npPor.setStep(1);
            npPor.setWrap(false);
            // npPor.setRange(0, (int) (maxDesctoVendedor * 10000));
            npPor.setRangeDecimal(0, Generales.getRound(maxDesctoVendedor, 4));
            npPor.setOnChangeListener(mPorcentaje);
        }
	}

    public void setImpDescVendedor(float descuento) {
        NumberPicker npImp = (NumberPicker) findViewById(R.id.npDescVendedor);
        npImp.setCurrentDecimal(descuento);
    }

    public void setPorDescVendedor(float porcentaje) {
        NumberPicker npPor = (NumberPicker) findViewById(R.id.npPorVendedor);
        npPor.setCurrentDecimal(porcentaje);
    }

    public void setFolio(String Folio) {
        if (separarTotalesSubEmpresa ){
            EditText text = (EditText) findViewById(R.id.txtFolio);
            text.setVisibility(View.GONE);
            Spinner spn = (Spinner) findViewById(R.id.spFolio);
            spn.setVisibility(View.VISIBLE);

            oTransProdTotalizados = new HashMap<String, Boolean>();
            //spn.setFocusable(true);
            //spn.setFocusableInTouchMode(true);

            String[] spinnerArray = new String[mPresenta.getTransacciones().size()];
            HashMap<String,TransProd> spinnerMap = new HashMap<String, TransProd>();
            for (int i = 0; i < mPresenta.getTransacciones().size(); i++)
            {
                spinnerMap.put( mPresenta.getTransacciones().get(i).Folio, mPresenta.getTransacciones().get(i));
                spinnerArray[i] =  mPresenta.getTransacciones().get(i).Folio;
                oTransProdTotalizados.put(mPresenta.getTransacciones().get(i).Folio, false);
            }

            SpinnerAdapter adapter;
            adapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_dropdown_item, android.R.id.text1, spinnerArray);
            spn.setAdapter(adapter);
            spn.setTag(spinnerMap);
            spn.setOnItemSelectedListener(mFolioSeleccionado);
        }else{
            EditText text = (EditText) findViewById(R.id.txtFolio);
            text.setText(Folio);
        }
    }

    private OnItemSelectedListener mFolioSeleccionado = new OnItemSelectedListener() {

        @Override
        public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
            String item =  arg0.getItemAtPosition(arg2).toString();
            Spinner spn = (Spinner) findViewById(R.id.spFolio);
            HashMap<String,TransProd> spinnerMap = (HashMap<String,TransProd>)spn.getTag();
            //Si el folio actual cambio y no es el primero
            if (!folioSeleccionado.equals("") && !folioSeleccionado.equals(item)){
                try {
                    NumberPicker txtDescVend = (NumberPicker)findViewById(R.id.npPorVendedor);
                    if (txtDescVend.isEnabled()) {
                        txtDescVend.clearFocus();
                        txtDescVend = (NumberPicker) findViewById(R.id.npDescVendedor);
                        txtDescVend.clearFocus();
                    }
                    mPresenta.asignarGuardarValores(spinnerMap.get(folioSeleccionado));
                }catch(Exception ex){
                    mostrarError("Error al asignar valores de pedido");
                }
            }
            llenarPedidoActual(spinnerMap.get(item));
            folioSeleccionado = item;
        }
        @Override
        public void onNothingSelected(AdapterView<?> arg0) {

        }
    };

    private void llenarPedidoActual(TransProd oTrp){
        try{
            setTipoPedido(oTrp.TipoPedido);
            if (oTrp.CFVTipo != null)
                setFormaVenta(oTrp.CFVTipo);
            if (oTrp.ClientePagoId != null)
                setFormaPago(oTrp.ClientePagoId);
            setTipoTurno(oTrp.TipoTurno);
            if (oTrp.FechaEntrega != null)
                setFechaEntrega(oTrp.FechaEntrega);
            if (oTrp.FechaCobranza != null)
                setFechaCobranza(oTrp.FechaCobranza);
            setNotas((oTrp.Notas == null ? "" : oTrp.Notas));
            TRPVtaAcreditada pedidoAdicional = new TRPVtaAcreditada();
            pedidoAdicional.TransProdID = oTrp.TransProdID;
            BDVend.recuperar(pedidoAdicional);
            if (pedidoAdicional != null) {
                setPedidoAdicional(pedidoAdicional.PedidoAdicional == null ? "" : pedidoAdicional.PedidoAdicional);
                setObservaciones(pedidoAdicional.Observaciones == null ? "" : pedidoAdicional.Observaciones );
                setObservaciones2(pedidoAdicional.Observaciones2 == null ? "" : pedidoAdicional.Observaciones2 );
            }
            float subTotalProducto = 0;
            float descuentosYBonificaciones = 0;
            for (int i = 0; i < oTrp.TransProdDetalle.size(); i++)
            {
                subTotalProducto += oTrp.TransProdDetalle.get(i).Cantidad * oTrp.TransProdDetalle.get(i).Precio;
                descuentosYBonificaciones += oTrp.TransProdDetalle.get(i).DescuentoImp;
            }

            setSubTProducto(subTotalProducto);
            setDescYBonif(descuentosYBonificaciones);
            setSubTotal(oTrp.Subtotal);
            setImpuesto(oTrp.Impuesto - oTrp.DescuentoImpuestoCliente - oTrp.DescuentoImpuestoVendedor);
            setTotal(oTrp.Total);

            //mVista.validarDesctoVendedor(subTDetalle, descCliente);
            setImpDescVendedor(oTrp.DescuentoVendedor);
            setPorDescVendedor(oTrp.DescVendPor == null ? 0 : oTrp.DescVendPor);
            mPresenta.calcularDescVendedor(oTrp, oTrp.DescVendPor == null ? 0 : oTrp.DescVendPor);
            //calcularDescVendedor(porDescVendedor);

            Spinner spn = (Spinner) findViewById(R.id.spFolio);
            spn.setSelected(true);
            spn.requestFocus();
        }
        catch (Exception ex)
        {
            mostrarError(ex.getMessage());
        }
    }

    public short getTipoPedido() {
        Spinner spin = (Spinner) findViewById(R.id.spTipoPedido);
        return (short) spin.getSelectedItemId();
    }

	public void setTipoPedido(int TipoPedido) {
        Spinner spinMoneda = (Spinner) findViewById(R.id.spTipoPedido);
        SimpleCursorAdapter adapter = (SimpleCursorAdapter) spinMoneda.getAdapter();
        for (int i = 0; i < adapter.getCount(); i++) {
            Cursor c = (Cursor) adapter.getItem(i);
            if (c.getString(0).equals(String.valueOf(TipoPedido))) {
                Spinner spinM = (Spinner) findViewById(R.id.spTipoPedido);
                spinM.setSelection(c.getPosition());
                break;
            }
        }
        /*Spinner spin = (Spinner) findViewById(R.id.spTipoPedido);
		spin.setSelection(TipoPedido);*/
	}

    public short getFormaVenta() {
        Spinner spin = (Spinner) findViewById(R.id.spFormaVenta);
        return (short) spin.getSelectedItemId();
    }

    public void setFormaVenta(int FormaVenta) {
        if (FormaVenta != -1) { // tiene configurada una forma de venta como inicial, seleccionarla

            Spinner spinMoneda = (Spinner) findViewById(R.id.spFormaVenta);
            SimpleCursorAdapter adapter = (SimpleCursorAdapter) spinMoneda.getAdapter();

            for (int i = 0; i < adapter.getCount(); i++) {
                Cursor c = (Cursor) adapter.getItem(i);
                if (c.getString(0).equals(String.valueOf(FormaVenta))) {
                    Spinner spinM = (Spinner) findViewById(R.id.spFormaVenta);
                    spinM.setSelection(c.getPosition());
                    break;
                }
            }

			/*
             * Spinner spin = (Spinner) findViewById(R.id.spFormaVenta);
			 * spin.setSelection(FormaVenta - 1);
			 */
        }
	}

    public short getFormaVentaInicial() {
        return (short) formaVentaInicial;
    }

    public String getFormaPago() {
        Spinner spin = (Spinner) findViewById(R.id.spFormaPago);
        return String.valueOf((short) spin.getSelectedItemId());
    }

    public void setFormaPago(String FormaPago) {

        Spinner spinMoneda = (Spinner) findViewById(R.id.spFormaPago);
        SimpleCursorAdapter adapter = (SimpleCursorAdapter) spinMoneda.getAdapter();
        for (int i = 0; i < adapter.getCount(); i++) {
            Cursor c = (Cursor) adapter.getItem(i);
            if (c.getString(0).equals(FormaPago)) {
                Spinner spinM = (Spinner) findViewById(R.id.spFormaPago);
                spinM.setSelection(c.getPosition());
                break;
            }
        }

		/*
         * Spinner spin = (Spinner) findViewById(R.id.spFormaPago);
		 * spin.setSelection(Integer.parseInt(FormaPago));
		 */
	}

    public void setListaPrecio(String PrecioClave) {
        TextView text = (TextView) findViewById(R.id.txtListaPrecio);
        text.setText(PrecioClave);
    }

    public void setFechaEntregaDefault() {
        MOTConfiguracion motConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
        if ((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO) && mPresenta.getTipo() != TiposTransProd.MOV_SIN_INV_EV) {
            fechaEntrega = ((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura;
        } else if (getTipoPedido() == TipoPedido.POSFECHADO || getTipoPedido() == TipoPedido.CONSIGNACION || (mPresenta.getTipo() == TiposTransProd.MOV_SIN_INV_EV && motConf.get("MSIEVPreventa").toString().equals("1")) || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA  && mPresenta.getTipo() == TiposTransProd.PEDIDO)) {
            fechaEntrega = (Date) Sesion.get(Campo.FechaMinimaEntrega);
            try{
                int oParamDiasDeSurtido = 0;
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("DiasDeSurtido")) {
                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("DiasDeSurtido", moduloMovDetalle.ModuloMovDetalleClave.toString()) != null) {
                        oParamDiasDeSurtido = Integer.valueOf(String.valueOf(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("DiasDeSurtido", moduloMovDetalle.ModuloMovDetalleClave)));
                        fechaEntrega = sumarDias(oParamDiasDeSurtido);
                    }
                }
            }catch (Exception ex){
                mostrarError("Error al recuperar los Dias de Surtido");
            }
        } else {
            fechaEntrega = ((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura;
        }

        //Calendar cal = Calendar.getInstance();
        Button btnEntrega = (Button) findViewById(R.id.btnFechaEntrega);
        /*cal.setTime(((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura);
		// sumar los dias de surtido a la fecha captura
		cal.add(Calendar.DATE, Integer.parseInt(oConHist.get("DiasSurtido").toString()));
		fechaEntrega = cal.getTime();*/
        //btnEntrega.setText(new SimpleDateFormat("dd/MMM/yyyy").format(cal.getTime()));
        btnEntrega.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaEntrega));
        btnEntrega.setOnClickListener(mFechaEntrega);
	}

    public Date getFechaEntrega() {
        return fechaEntrega;
    }

    public void setFechaEntrega(Date FechaEntrega) {
        fechaEntrega = FechaEntrega;
        Button btnEntrega = (Button) findViewById(R.id.btnFechaEntrega);
        btnEntrega.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaEntrega.getTime()));
        btnEntrega.setOnClickListener(mFechaEntrega);
    }

    public Date getFechaCobranza() {
        return fechaCobranza;
    }

    public void setFechaCobranza(Date FechaCobranza) {
        fechaCobranza = FechaCobranza;
    }

    public void setSubTProducto(float subTProducto) {
        EditText text = (EditText) findViewById(R.id.txtSubtotalProducto);
        // text.setText(String.format("%.2f", subTDetalle));
        text.setText(Generales.getFormatoDecimal(subTProducto, "$ #,##0.00"));
    }

    public void setDescYBonif(float descYBonif) {
        EditText text = (EditText) findViewById(R.id.txtDescYBonif);
        // text.setText(String.format("%.2f", descCliente));
        text.setText(Generales.getFormatoDecimal(descYBonif, "$ #,##0.00"));
    }

    public void setSubTotal(float subTotal) {
        EditText text = (EditText) findViewById(R.id.txtSubtotal);
        // text.setText(String.format("%.2f", subTotal));
        text.setText(Generales.getFormatoDecimal(subTotal, "$ #,##0.00"));
        SubTotal = subTotal;
    }

    public void setImpuesto(float impuesto) {
        EditText text = (EditText) findViewById(R.id.txtImpuesto);
        // text.setText(String.format("%.2f", impuesto));
        text.setText(Generales.getFormatoDecimal(impuesto, "$ #,##0.00"));
        Impuestos = impuesto;
    }

    public void setTotal(float total) {
        this.total = total;
        EditText text = (EditText) findViewById(R.id.txtTotal);
        // text.setText(String.format("%.2f", total));
        text.setText(Generales.getFormatoDecimal(total, "$ #,##0.00"));
    }

    public String getNotas() {
        EditText texto = (EditText) findViewById(R.id.txtNotas);
        return texto.getText().toString().trim();
    }

    public void setNotas(String notas) {
        EditText texto = (EditText) findViewById(R.id.txtNotas);
        texto.setText(notas);
    }

	public String getPedidoAdicional() {
        EditText texto = (EditText) findViewById(R.id.txtPedidoAdicional);
        return texto.getText().toString().trim();
    }

    public void setPedidoAdicional(String pedidoAdicional) {
        EditText texto = (EditText) findViewById(R.id.txtPedidoAdicional);
        texto.setText(pedidoAdicional);
    }

    public String getFolioNegociacion() {
        EditText texto = (EditText) findViewById(R.id.txtFolioNeg);
        return texto.getText().toString().trim();
    }

    public void setFolioNegociacion(String folioNegociacion) {
        EditText texto = (EditText) findViewById(R.id.txtFolioNeg);
        texto.setText(folioNegociacion);
    }

    public String getObservaciones() {
        EditText texto = (EditText) findViewById(R.id.txtObservaciones);
        return texto.getText().toString().trim();
    }

    public void setObservaciones(String observaciones) {
        EditText texto = (EditText) findViewById(R.id.txtObservaciones);
        texto.setText(observaciones);
    }

    public String getObservaciones2() {
        EditText texto = (EditText) findViewById(R.id.txtObservaciones2);
        return texto.getText().toString().trim();
    }

    public void setObservaciones2(String observaciones2) {
        EditText texto = (EditText) findViewById(R.id.txtObservaciones2);
        texto.setText(observaciones2);
    }

    public int getDiasCredito() {
        NumberPicker diasCredito = (NumberPicker) findViewById(R.id.npDiasCredito);
        return Math.round(diasCredito.getCurrent());
    }

    public short getTipoTurno() {
        Spinner spin = (Spinner) findViewById(R.id.spTurno);
        return (short) spin.getSelectedItemId();
    }

    public void setTipoTurno(int TipoTurno) {
        Spinner spinTurno = (Spinner) findViewById(R.id.spTurno);
        SimpleCursorAdapter adapter = (SimpleCursorAdapter) spinTurno.getAdapter();
        for (int i = 0; i < adapter.getCount(); i++) {
            Cursor c = (Cursor) adapter.getItem(i);
            if (c.getString(0).equals(String.valueOf(TipoTurno))) {
                Spinner spinM = (Spinner) findViewById(R.id.spTurno);
                spinM.setSelection(c.getPosition());
                break;
            }
        }
    }


    @Override
    public String getPuntoEntrega() {
        Spinner spnPtoEntrega = (Spinner) findViewById(R.id.spPuntoEntrega);
        String ptoEntrega = null;
        if (spnPtoEntrega.getSelectedItem() != null) {
            Cursor c = (Cursor) ((SimpleCursorAdapter) spnPtoEntrega.getAdapter()).getItem(spnPtoEntrega.getSelectedItemPosition());
            ptoEntrega = c.getString(1); // ClienteDomicilioId
        }
        if (!(spnPtoEntrega.getCount() > 1))
            spnPtoEntrega.setEnabled(false);
        return ptoEntrega;
    }

    @Override
    public HashMap<String, Boolean> getTransProdTotalizados(){
        return oTransProdTotalizados;
    }

	  private void cargarTurnos() {
          Spinner spin = (Spinner) findViewById(R.id.spTurno);
          SimpleCursorAdapter adapterTurno = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, (Cursor) tiposTurno.getOriginal(), new String[]
                  {SearchManager.SUGGEST_COLUMN_TEXT_1 }, new int[]
                  { android.R.id.text1 });
	  adapterTurno .setDropDownViewResource(android.R.layout.simple_spinner_item);
          spin.setAdapter(adapterTurno);
      }


	@Override
    public void setPuntoEntrega(String clienteDomicilioId) {
        Spinner spnPtoEntrega = (Spinner) findViewById(R.id.spPuntoEntrega);
        SimpleCursorAdapter adapter = (SimpleCursorAdapter) spnPtoEntrega.getAdapter();
        for (int i = 0; i < adapter.getCount(); i++) {
            Cursor c = (Cursor) adapter.getItem(i);
            if (c.getString(0).equals(clienteDomicilioId)) {
                spnPtoEntrega.setSelection(c.getPosition());
                break;
            }
        }
    }

	@SuppressLint("DefaultLocale")
    public void setFocus(String campo) {
        if (campo.toLowerCase().equals("dias credito")) {
            NumberPicker diasCredito = (NumberPicker) findViewById(R.id.npDiasCredito);
            diasCredito.requestFocus();
        } else if (campo.toLowerCase().equals("fecha cobranza")) {
            Button btn = (Button) findViewById(R.id.btnFechaCobranza);
            btn.requestFocus();
        } else if (campo.toLowerCase().equals("notas")) {
            EditText notas = (EditText) findViewById(R.id.txtNotas);
            notas.requestFocus();
        } else if (campo.toLowerCase().equals("pedido adicional")) {
            EditText pedidoAdicional = (EditText) findViewById(R.id.txtPedidoAdicional);
            pedidoAdicional.requestFocus();
        } else if (campo.toLowerCase().equals("punto entrega")) {
            Spinner spnPtoEntrega = (Spinner) findViewById(R.id.spPuntoEntrega);
            spnPtoEntrega.requestFocus();
        } else if (campo.toLowerCase().equals("observaciones")) {
            EditText observaciones = (EditText) findViewById(R.id.txtObservaciones);
            observaciones.requestFocus();
        } else if (campo.toLowerCase().equals("observaciones2")) {
            EditText observaciones2 = (EditText) findViewById(R.id.txtObservaciones2);
            observaciones2.requestFocus();
        }else if (campo.toLowerCase().equals("folio negociacion")) {
            EditText folioneg = (EditText) findViewById(R.id.txtFolioNeg);
            folioneg.requestFocus();
        }else if (campo.toLowerCase().equals("forma pago")) {
            Spinner spinFormaPago = (Spinner) findViewById(R.id.spFormaPago);
            spinFormaPago.requestFocus();
        }
    }

    @SuppressWarnings("deprecation")
    private void obtenerValoresPorReferencia() throws Exception {
        // formas de venta configuradas para el cliente
        String fVentaCliente = obtenerFormasVentaConfiguradas();
        formasVenta = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("FVENTA", "", fVentaCliente); // Mensajes.get("XSeleccionar",Mensajes.get("XFormaVenta")),
        // valores);
        startManagingCursor((Cursor) formasVenta.getOriginal());

        // formas de pago configuradas para el cliente, si no tiene se muestran
        // todas
        String fPagoCliente = obtenerFormasPagoConfiguradas();
        if (fPagoCliente.equals(""))
            formasPago = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("PAGO", "");
        else
            formasPago = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("PAGO", "", fPagoCliente);
        startManagingCursor((Cursor) formasPago.getOriginal());

        // TIPOS DE PEDIDO
        //tiposPedidos = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("PEDTIPO", ""); // Mensajes.get("XSeleccionar",Mensajes.get("XTipoPedido")));
        if (moduloMovDetalle.TipoIndice == Enumeradores.TiposModuloMovDetalle.PEDIDO || moduloMovDetalle.TipoIndice == Enumeradores.TiposModuloMovDetalle.MOV_SIN_INV_CON_VISITA) {
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("TipoPedido")) {
                if ((((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("TipoPedido", moduloMovDetalle.ModuloMovDetalleClave)) == null) {
                    GrupoValorRef = "";
                } else {
                    GrupoValorRef = (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("TipoPedido", moduloMovDetalle.ModuloMovDetalleClave).toString());
                }
                if (GrupoValorRef != "") {
                    tiposPedidos = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("PEDTIPO", "'" + GrupoValorRef + "'", "", false); // Mensajes.get("XSeleccionar",Mensajes.get("XTipoPedido")));
                } else {
                    tiposPedidos = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("PEDTIPO", "''", "", false); // Mensajes.get("XSeleccionar",Mensajes.get("XTipoPedido")));
                }
            } else {
                tiposPedidos = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("PEDTIPO", "''", "", false); // Mensajes.get("XSeleccionar",Mensajes.get("XTipoPedido")));
            }
        } else {
            tiposPedidos = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("PEDTIPO", "''", "", false); // Mensajes.get("XSeleccionar",Mensajes.get("XTipoPedido")));
        }


        startManagingCursor((Cursor) tiposPedidos.getOriginal());

        // TIPOS DE FASE
        tiposFase = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
        startManagingCursor((Cursor) tiposFase.getOriginal());

        // TIPOS DE TURNO
        tiposTurno = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TURNO", ""); // Mensajes.get("XSeleccionar",Mensajes.get("XTurno")));
        startManagingCursor((Cursor) tiposTurno.getOriginal());

        // TIPOS CODIGO PARA LAS MONEDAS
        tiposCodigoMoneda = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("CDGOMON", "");
        startManagingCursor((Cursor) tiposCodigoMoneda.getOriginal());

        puntosEntrega = Consultas.ConsultasCliente.obtenerPuntosEntrega(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
        startManagingCursor((Cursor) puntosEntrega.getOriginal());
    }

    @SuppressWarnings("deprecation")
    private String obtenerFormasVentaConfiguradas() throws Exception {
        formaVentaInicial = -1;
        String valores = "";
        formaVenta = Consultas.ConsultasCliFormaVenta.obtenerFormaVenta(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
        startManagingCursor((Cursor) formaVenta.getOriginal());
        while (formaVenta.moveToNext()) {
            if (formaVenta.getInt("Inicial") == 1) {
                formaVentaInicial = formaVenta.getInt("CFVTipo");
            }
            valores += formaVenta.getString("CFVTipo") + ",";
        }
        if (valores.length() > 1) {
            valores = valores.substring(0, valores.length() - 1);
        }
        return valores;
    }

    @SuppressWarnings("deprecation")
    private String obtenerFormasPagoConfiguradas() throws Exception {
        String valores = "";
        ISetDatos formaPago = Consultas.ConsultasClientePago.obtenerFormaPago(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
        startManagingCursor((Cursor) formaPago.getOriginal());
        if (formaPago.getCount() > 0) { // si tiene formas de pago configuradas, cargar solo esas
            while (formaPago.moveToNext()) {
                valores += formaPago.getString("Tipo") + ",";
            }
            if (valores.length() > 1) {
                valores = valores.substring(0, valores.length() - 1);
            }
		}
        return valores;
    }

    @SuppressWarnings("deprecation")
    private void cargarTiposPedido() {
        Spinner spin = (Spinner) findViewById(R.id.spTipoPedido);
        SimpleCursorAdapter adapterTPedido = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, (Cursor) tiposPedidos.getOriginal(), new String[]
                {SearchManager.SUGGEST_COLUMN_TEXT_1}, new int[]
                {android.R.id.text1});
        adapterTPedido.setDropDownViewResource(android.R.layout.simple_spinner_item);
        spin.setAdapter(adapterTPedido);
        spin.setOnItemSelectedListener(mTipoPedido);
    }

    private void cargarFormasVenta() {
        Spinner spin = (Spinner) findViewById(R.id.spFormaVenta);
        @SuppressWarnings("deprecation")
        SimpleCursorAdapter adapterFVenta = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, (Cursor) formasVenta.getOriginal(), new String[]
                {SearchManager.SUGGEST_COLUMN_TEXT_1}, new int[]
                {android.R.id.text1});
        adapterFVenta.setDropDownViewResource(android.R.layout.simple_spinner_item);
        spin.setAdapter(adapterFVenta);
        spin.setOnItemSelectedListener(mFormaVenta);
    }

    @SuppressWarnings("deprecation")
    private void cargarFormasPago() {
        Spinner spin = (Spinner) findViewById(R.id.spFormaPago);
        SimpleCursorAdapter adapterFPago = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, (Cursor) formasPago.getOriginal(), new String[]
                {SearchManager.SUGGEST_COLUMN_TEXT_1}, new int[]
                {android.R.id.text1});
        adapterFPago.setDropDownViewResource(android.R.layout.simple_spinner_item);
        spin.setAdapter(adapterFPago);
    }

    @SuppressWarnings("deprecation")
    private void cargarPuntosEntrega() {
        Spinner spin = (Spinner) findViewById(R.id.spPuntoEntrega);
        SimpleCursorAdapter adapterPtoEntrega = new SimpleCursorAdapter(this, R.layout.my_multiline_spinner_item, (Cursor) puntosEntrega.getOriginal(), new String[]
                {"Domicilio"}, new int[]
                {android.R.id.text1});
        adapterPtoEntrega.setDropDownViewResource(R.layout.my_multiline_spinner_item);
        spin.setAdapter(adapterPtoEntrega);

        if (spin.getCount() > 0)
            spin.setSelection(0, true);
    }

    public void recalcularTotales(TransProd oTrp) throws Exception {
        // float descuentoImpuestoCliente = 0;
        ISetDatos desctoCliente = Consultas.ConsultasDescuentos.obtenerDescuentosCliente(oTrp.TransProdID);
        while (desctoCliente.moveToNext()) {
            oTrp.DescuentoImp = desctoCliente.getFloat("DesImporte");
            oTrp.DescuentoImpuestoCliente = desctoCliente.getFloat("DesImpuesto");
            // descuentoImpuestoCliente = desctoCliente.getFloat("DesImpuesto");
            // oTrp.Impuesto -= descuentoImpuestoCliente;
        }
        desctoCliente.close();

        // Hasta aqui el descuento del cliente ya esta calculado y aplicado,
        // tambien al Impuesto
        // Calcular el importe del descuento del subtotal
        oTrp.DescuentoVendedor = ((oTrp.SubTDetalle == null ? 0 : oTrp.SubTDetalle) - (oTrp.DescuentoImp == null ? 0 : oTrp.DescuentoImp)) * (oTrp.DescVendPor == null ? 0 : oTrp.DescVendPor / 100);
        // Calcular el importe del descuento del impuesto
        // float descuentoImpuestoVendedor = (oTrp.Impuesto -
        // descuentoImpuestoCliente) * (oTrp.DescVendPor / 100);
        oTrp.DescuentoImpuestoVendedor = (oTrp.Impuesto == null ? 0 : oTrp.Impuesto - oTrp.DescuentoImpuestoCliente) * (oTrp.DescVendPor == null ? 0 : oTrp.DescVendPor / 100);

        // oTrp.Impuesto -= descuentoImpuestoVendedor;

        oTrp.Subtotal = (oTrp.SubTDetalle == null ? 0 : oTrp.SubTDetalle) - (oTrp.DescuentoImp == null ? 0 : oTrp.DescuentoImp) - (oTrp.DescuentoVendedor == null ? 0 : oTrp.DescuentoVendedor);
        if (oTrp.Subtotal < 0)
            oTrp.Subtotal = (float) 0;
        oTrp.Total = oTrp.Subtotal + (oTrp.Impuesto == null ? 0 : oTrp.Impuesto - oTrp.DescuentoImpuestoCliente - oTrp.DescuentoImpuestoVendedor);
        if (oTrp.Total < 0)
            oTrp.Total = 0;
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        switch (keyCode) {
            case KeyEvent.KEYCODE_BACK:
                setResultado(Enumeradores.Resultados.RESULTADO_MAL, "");
                finalizar();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }

	public void setSoloLectura(boolean bsoloLectura) {
        soloLectura = bsoloLectura;
    }

	private void terminar(){
        mPresenta.solicitarFirma();
    }

    public void solicitarImprimirTicket(){
        String motConfig = (String) ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MensajeImpresion");
        if (motConfig.equals("0")) {
            // si no esta configurada la pregunta salir
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        } else if (motConfig.equals("1")) {
            mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
        } else if (motConfig.equals("2") || motConfig.equals("3")) {
            EnvioPDF.enviarTicketPDF(CapturaTotales.this, Short.valueOf(motConfig));
            //mostrarPreguntaSiNo(Mensajes.get("P0246"), 9);
        }
    }


	@Override
    public void iniciar() {

	}

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {
        try {
            if (requestCode == REQUEST_ENABLE_BT) {
                if (resultCode == RESULT_OK) {
                    try {
                        imprimiendo = true;
                        mPresenta.imprimirTicket();
                    } catch (ControlError e) {
                        e.Mostrar(getVista());
                    } catch (Exception e) {
                        getVista().mostrarError(e.getMessage());
                    }
                } else {
                    mostrarError("No se pudo encender el BT");
                }

                return;
            }
            else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_CAPTURAR_FIRMA)
            {
                if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                    String sNombre = "";
                    String sNombreArchivo = "";
                    if (data != null){
                        sNombre = (String) data.getExtras().getString("Nombre");
                        sNombreArchivo = (String) data.getExtras().getString("NombreArchivo");
                    }
                    guardar(sNombre, sNombreArchivo);
                }else
                {
                    Button boton = (Button) findViewById(R.id.btnTerminar);
                    boton.setEnabled(true);
                }
            }
            else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_ENVIAR_PDF)
            {
                if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                    imprimiendo = true;

                    Sesion.remove(Campo.ArchivoPDF);
                    Sesion.remove(Campo.ArchivosPDFxEnviar);
                    Sesion.remove(Campo.ArchivosPDFxGenerar);

                    try
                    {
                        mPresenta.imprimirTicket();
                    }
                    catch (Exception e)
                    {
                        EnvioPDF.guardarArchivosNoGenerados();
                        this.mostrarError(e.getMessage(), 0);
                    }

                    if (Sesion.get(Campo.ArchivosPDFxEnviar) != null)
                    {
                        EnvioPDF.enviarArchivos(CapturaTotales.this);
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
            }
            else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_ENVIAR_PDF_SERVER){
                if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                    if (Short.valueOf(((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MensajeImpresion").toString()) == 3) {
                        //String sURLServer = Sesion.get(Campo.URLServerPDF).toString();
                        Hashtable<String, ContentValues> htArchivosPDF = (Hashtable<String, ContentValues>)Sesion.get(Campo.ArchivosPDFxEnviar);
                        Iterator<Map.Entry<String, ContentValues>> it =  htArchivosPDF.entrySet().iterator();
                        Map.Entry<String, ContentValues> entry = it.next();
                        Sesion.set(Campo.ArchivoPDF, entry.getKey());
                        Sesion.set(Campo.TransaccionActualPDF, entry.getValue());
                        EnvioPDF.enviarSMS(CapturaTotales.this);
                    }
                    else{
                        this.mostrarMensaje(Mensajes.get("I0307").replace("$0$", Mensajes.get("XCorreoElectronico")), 0, 0);
                    }
                }
                else{
                    EnvioPDF.guardarArchivosNoEnviados();
                    if (data != null) {
                        String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                        if (mensajeError != null) {
                            this.mostrarError(mensajeError, 0);
                        }
                    }
                    else {
                        this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                        this.finalizar();
                    }
                }
            }
            else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_ENVIAR_SMS){
                if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                    EnvioPDF.agregarArchivoEnviado();

                    Sesion.remove(Campo.ArchivoPDF);
                    String sArchivoPDF = EnvioPDF.obtenerSiguienteArchivo();
                    if (sArchivoPDF != "")
                    {
                        EnvioPDF.EnviarSiguiente(CapturaTotales.this, sArchivoPDF);
                    }
                    else
                    {
                        this.mostrarMensaje(Mensajes.get("I0307").replace("$0$", "SMS"), 0, 0);
                    }
                }
                else {
                    this.mostrarPreguntaSiNo(Mensajes.get("P0254"), 2);
                }
            }
        } catch (Exception ex) {
            mostrarError(ex.getMessage());
        }
    }

    @Override
    public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje) {
        if (mensajeValidaCredito) //quitar la bandera del mensaje de limite de credito para continuar
            mensajeValidaCredito = false;

        if (mensajeLimiteEnvase)
            mensajeLimiteEnvase = false;

        if (tipoMensaje == 8) {
            if (respuesta.equals(RespuestaMsg.Si)) { // imprimir recibo
                // Imprimir ticket
                imprimiendo = true;
                try {
                    if (!bluetoothEncendido()) {
                        encenderBluetooth();
                    } else {
                        mPresenta.imprimirTicket();
                    }
                    // getVista().mostrarAdvertencia("Recibos generados");
                } catch (ControlError e) {
                    e.Mostrar(getVista());
                } catch (Exception e) {
                    getVista().mostrarError(e.getMessage());
                }
            } else {
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }
        } /*else if (tipoMensaje == 9) {
            if (respuesta.equals(RespuestaMsg.Si)) {
                Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
                if (cliente.CorreoElectronico != null && !cliente.CorreoElectronico.isEmpty()) {
                    envioEmail = new EnvioEmail(this) {
                        public void envioFinalizado(boolean exito) {
                            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                            finalizar();
                        }
                    };
                    String asunto = "Comprobante de ".
                            concat(((ModuloMovDetalle) oParametros.get("ModuloMovDetalle")).Nombre).
                            concat(" del Folio ").
                            concat(((TextView) findViewById(R.id.txtFolio)).getText().toString());*/
                //Estimado Cliente, por este medio se le hace llegar “la representación impresa (.PDF) de” + <ModuloMovDetalle.Nombre> donde( <ModuloMovDetalle.Clave> = <TransProd.PCEModuloMovDetClave>) + “del Folio“ + <TransProd.Folio>” + “que se realizó el día” + <TransProd.FechaCaptura>*/
                    /*TransProd tp = new TransProd();
                    tp.TransProdID = mPresenta.getTransProdid();
                    try {
                        BDVend.recuperar(tp);
                        String cuerpo = "Estimado Cliente, por este medio se le hace llegar la representación impresa (.PDF) de ".
                                concat(((ModuloMovDetalle) oParametros.get("ModuloMovDetalle")).Nombre).
                                concat(" del Folio ").
                                concat(((TextView) findViewById(R.id.txtFolio)).getText().toString()).
                                concat(" que se realizó el día ").
                                concat(Generales.getFormatoFecha(tp.FechaCaptura, "dd/MM/yyyy"));
                        envioEmail.enviarMail(cliente.CorreoElectronico, asunto, cuerpo, Recibos.generaTicketPedido(mPresenta.getTransProdid(),
                                ((TextView) findViewById(R.id.txtFolio)).getText().toString(), this));
                    } catch (Exception ex) {
                        getVista().mostrarError(ex.getMessage());
                    }
                } else {
                    mostrarToast(Mensajes.get("E0933"));
                    setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                    finalizar();
                }
            } else {
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }
        }*/ else if (tipoMensaje == 0 && imprimiendo) {
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        }
        else if (tipoMensaje == 2){ //Reintentar envio de SMS
            if (respuesta.equals(RespuestaMsg.Si)) {
                EnvioPDF.enviarSMS(CapturaTotales.this);
            }
            else{
                EnvioPDF.guardarArchivosNoEnviados();
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }
        }
	}

    public boolean getMensajeLimiteCredito() {
        return mensajeValidaCredito;
    }

    public void setMensajeLimiteCredito(boolean mostrandoMensaje) {
        mensajeValidaCredito = mostrandoMensaje;
    }

    public boolean getMensajeLimiteEnvase() {
        return mensajeLimiteEnvase;
    }

    public void setMensajeLimiteEnvase(boolean mostrandoMensaje) {
        mensajeLimiteEnvase = mostrandoMensaje;
    }

    @Override
    public void finalizar() {
        if (Sesion.get(Campo.ArrayTransProd) != null) {
            Sesion.remove(Campo.ArrayTransProd);
        }
        BDVend.setGuardarLog(false);
        super.finalizar();
    }

    @SuppressWarnings("deprecation")
    @Override
    protected Dialog onCreateDialog(int id) {
        switch (id) {
            case DATE_DIALOG_ENTREGA:
                int anio = fechaEntrega.getYear() + 1900;
                int mes = fechaEntrega.getMonth();
                int dia = fechaEntrega.getDate();
                return new DatePickerDialog(this, mFechaEntregaListener, anio, mes, dia);
            case DATE_DIALOG_COBRANZA:
                int anio2 = fechaCobranza.getYear() + 1900;
                int mes2 = fechaCobranza.getMonth();
                int dia2 = fechaCobranza.getDate();
                return new DatePickerDialog(this, mFechaCobranzaListener, anio2, mes2, dia2);
        }
        return null;
    }

    @SuppressWarnings("deprecation")
    @Override
    protected void onPrepareDialog(int id, Dialog dialog) {
        switch (id) {
            case DATE_DIALOG_ENTREGA:
                int anio = fechaEntrega.getYear() + 1900;
                int mes = fechaEntrega.getMonth();
                int dia = fechaEntrega.getDate();
                ((DatePickerDialog) dialog).updateDate(anio, mes, dia);
                break;
            case DATE_DIALOG_COBRANZA:
                int anio2 = fechaCobranza.getYear() + 1900;
                int mes2 = fechaCobranza.getMonth();
                int dia2 = fechaCobranza.getDate();
                ((DatePickerDialog) dialog).updateDate(anio2, mes2, dia2);
                break;
        }
    }

    private Date sumarDias(int dias){
        //Dia dia = (Dia) Sesion.get(Campo.DiaActual);
        Date resFecha =  Generales.getFechaActual();
        for(int i = 1; i <= dias; i++){ //sumar los dias uno por uno y validar excepciones de frecuencia
            Calendar cal = Calendar.getInstance();
            cal.setTime(resFecha);
            cal.add(Calendar.DATE, 1);
            resFecha = cal.getTime();
            resFecha = validarExcepcionesFrecuenciaFechasEntregaSumar(resFecha);
        }
        return resFecha;
    }

    @SuppressWarnings({ "unchecked", "deprecation" })
    private Date validarExcepcionesFrecuenciaFechasEntregaSumar(Date fecha){
        ArrayList<FrecuenciaExcep> excepciones = (ArrayList<FrecuenciaExcep>) Sesion.get(Campo.ExcepcionFreq);
        Date resFecha = fecha;
        if(excepciones.size() > 0){
            int dia = fecha.getDate();
            int mes = fecha.getMonth() + 1;
            int year = fecha.getYear() + 1900;
            int diaSemana = fecha.getDay();
            Calendar cal = Calendar.getInstance();
            cal.setTime(fecha);
            cal.add(Calendar.DATE, 1);
            for(FrecuenciaExcep excepcion : excepciones){
                switch(excepcion.TipoFecha){
                    case TipoFecha.DIA_EXACTO:
                        if(excepcion.Dia == dia && excepcion.Mes == mes && excepcion.Anio == year){
                            return validarExcepcionesFrecuenciaFechasEntregaSumar(cal.getTime());
                        }
                        break;
                    case TipoFecha.DIA_DE_LA_SEMANA:
                        try
                        {
                            Calendar tmp = Calendar.getInstance();
                            tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(excepcion.Dia+"/"+excepcion.Mes+"/"+excepcion.Anio));
                            if(tmp.getTime().getDay() == diaSemana){
                                return validarExcepcionesFrecuenciaFechasEntregaSumar(cal.getTime());
                            }
                        }
                        catch (ParseException e)
                        {
                            mostrarAdvertencia(e.getMessage());
                        }
                        break;
                    case TipoFecha.DIA_MES:
                        if(excepcion.Dia == dia && excepcion.Mes == mes){
                            return validarExcepcionesFrecuenciaFechasEntregaSumar(cal.getTime());
                        }
                        break;
                }
            }
        }
        return resFecha;
    }

	@SuppressWarnings({ "unchecked", "deprecation" })
	private boolean validarExcepcionesFrecuenciaFechasEntrega(Date fecha){
		ArrayList<FrecuenciaExcep> excepciones = (ArrayList<FrecuenciaExcep>) Sesion.get(Campo.ExcepcionFreq);
		//Date resFecha = fecha;
		if(excepciones.size() > 0){
			int dia = fecha.getDate();
			int mes = fecha.getMonth() + 1;
			int year = fecha.getYear() + 1900;
			int diaSemana = fecha.getDay();
			Calendar cal = Calendar.getInstance();
			cal.setTime(fecha);
			cal.add(Calendar.DATE, 1);
			for(FrecuenciaExcep excepcion : excepciones){
				switch(excepcion.TipoFecha){
					case TipoFecha.DIA_EXACTO:
						if(excepcion.Dia == dia && excepcion.Mes == mes && excepcion.Anio == year){
							return true;
						}
						break;
					case TipoFecha.DIA_DE_LA_SEMANA:
						try{
							Calendar tmp = Calendar.getInstance();
							tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(excepcion.Dia+"/"+excepcion.Mes+"/"+excepcion.Anio));
							if (tmp.getTime().getDay() == diaSemana){
								return true;
							}
						}
						catch (ParseException e)
						{
							mostrarAdvertencia(e.getMessage());
						}
						break;
					case TipoFecha.DIA_MES:
						if(excepcion.Dia == dia && excepcion.Mes == mes){
							return true;
						}
						break;
				}
			}
		}
		return false;
	}

	//	// view binder para el combo de las monedas
	//	private class vista implements ViewBinder
	//	{
	//
	//		@Override
	//		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
	//		{
	//			int viewId = view.getId();
	//			switch (viewId)
	//			{
	//				case android.R.id.text1:
	//					TextView texto = (TextView) view;
	//					tiposCodigoMoneda.moveToPosition(cursor.getInt(2) - 1);
	//					texto.setText(cursor.getString(1) + " " + tiposCodigoMoneda.getString(2));
	//					break;
	//				/*
	//				 * case R.id.lblPorcentajeImp: TextView por = (TextView) view;
	//				 * por.setText(String.format("%.2f %%",
	//				 * cursor.getFloat(columnIndex))); break; case R.id.lblTotalImp:
	//				 * TextView imp = (TextView) view;
	//				 * imp.setText(String.format("$ %.2f",
	//				 * cursor.getFloat(columnIndex))); break;
	//				 */
	//				default:
	//					TextView text = (TextView) view;
	//					text.setText(cursor.getString(columnIndex));
	//					break;
	//			}
	//			return true;
	//		}
	//
	//	}

	private Vista getVista() {
        return this;
    }

	private void setListViewHeightBasedOnChildren(ListView listView) {
        ListAdapter listAdapter = listView.getAdapter();
        if (listAdapter == null) {
            // pre-condition
            return;
        }

        int totalHeight = 0;
        int desiredWidth = MeasureSpec.makeMeasureSpec(listView.getWidth(), MeasureSpec.AT_MOST);
        for (int i = 0; i < listAdapter.getCount(); i++) {
            View listItem = listAdapter.getView(i, null, listView);
            listItem.measure(MeasureSpec.makeMeasureSpec(0, MeasureSpec.UNSPECIFIED), MeasureSpec.makeMeasureSpec(0, MeasureSpec.UNSPECIFIED));
            totalHeight += listItem.getMeasuredHeight();
        }

        ViewGroup.LayoutParams params = listView.getLayoutParams();
        params.height = totalHeight + (listView.getDividerHeight() * (listAdapter.getCount() - 1));

        listView.setLayoutParams(params);
        listView.requestLayout();
        listView.setTag(true);
    }

    private void setTextViewHeightBasedOnContent(TextView textView, int percent){
        String text = textView.getText().toString();
        WindowManager wm = (WindowManager) this.getBaseContext().getSystemService(Context.WINDOW_SERVICE);
        Display display = wm.getDefaultDisplay();
        int screenWidth = (int)(display.getWidth() * 0.9); // Get full screen width

        int screenPercent = (screenWidth * percent) / 100; // Calculate 80% of it
// as my adapter was having almost 80% of the whole screen width

        float textWidth = textView.getPaint().measureText(text);
// this method will give you the total width required to display total String

        int numberOfLines = ((int) textWidth/screenPercent) + 1;
// calculate number of lines it might take

        textView.setLines(numberOfLines);
    }

	@Override
    public void impresionFinalizada(boolean impresionExitosa, String mensajeError) {
        if (!mensajeError.equals(""))
            Toast.makeText(getApplicationContext(), mensajeError, Toast.LENGTH_LONG).show();

        setResult(Enumeradores.Resultados.RESULTADO_BIEN);

        quitarProgreso();

        try {
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString())) {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("0")) {
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

	/**
     * Se genera el pdf de la vista previa del pedido
     * @return File
     * @throws Exception
     */
    private File generarPDFVistaPrevia() throws Exception {
        String nombreArchivo = "";
        Hashtable<String, ContentValues> archivosGenerados = new Hashtable<String, ContentValues>();

        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
        File impresion = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
        impresion = new File(impresion, "impresion");
        if (!impresion.exists()) {
            if (!impresion.mkdirs()) {
                //TODO Paula, crear mensaje, E0690 provisional
                throw new ControlError("E0690", impresion.getAbsolutePath());
            }
        }

        //Limpiar el directorio de impresion
        if (impresion.isDirectory()) {
            File[] files = impresion.listFiles();
            if (files != null) {
                for (File f : files) {
                    f.delete();
                }
			}
		}

        try {
            nombreArchivo = "VistaPrevia-" + mPresenta.getTransProdid();

            Document document = new Document();
            PdfWriter.getInstance(document, new FileOutputStream(impresion.getAbsolutePath() + "/" + nombreArchivo + ".pdf"));
            document.open();

            if (separarTotalesSubEmpresa){
                construyePDFMultiTotales(document);
            }else {
                construyePDF(document);
            }

            document.close();

        } catch (Exception ex) {
            throw new Exception("Error al generar ticket:" + ex.getMessage());
        }

        if (!archivosGenerados.containsKey(nombreArchivo) && !nombreArchivo.equals("")) {
            ContentValues valoresRecibo = new ContentValues();
            archivosGenerados.put(nombreArchivo, valoresRecibo);
        }
        Sesion.set(Campo.ArchivosGenerados, archivosGenerados);
        return new File(impresion.getAbsolutePath() + "/" + nombreArchivo + ".pdf");
    }

	private void construyePDF(Document document) throws Exception {
        String aux = null;
        Paragraph reportePDF = new Paragraph();
        Paragraph vacio = new Paragraph(" ");

        Font font = new Font(FontFamily.COURIER, 26, Font.BOLD, BaseColor.BLUE);

        ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado();
        encabezado.moveToFirst();

        Paragraph paragraph = new Paragraph(encabezado.getString("NombreEmpresa"), font);
        paragraph.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(paragraph);

        font = new Font(FontFamily.COURIER, 20, Font.BOLD, BaseColor.BLACK);

        paragraph = new Paragraph(encabezado.getString("RFC"), font);
        paragraph.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(paragraph);
        reportePDF.add(vacio);

        encabezado.close();

        paragraph = new Paragraph(Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss"), font);
        paragraph.setAlignment(Element.ALIGN_CENTER);
        reportePDF.add(paragraph);
        reportePDF.add(vacio);

        font = new Font(FontFamily.COURIER, 20, Font.BOLD, BaseColor.BLACK);

        aux = ((Ruta) Sesion.get(Campo.RutaActual)).RUTClave + "-" + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion;

        paragraph = new Paragraph(Mensajes.get("XRuta") + ": " + aux, font);
        paragraph.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(paragraph);

        aux = ((Vendedor) Sesion.get(Campo.VendedorActual)).Nombre;

        paragraph = new Paragraph(Mensajes.get("XVendedor") + ": " + aux, font);
        paragraph.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(paragraph);

        Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

        aux = cliente.Clave + "-" + cliente.RazonSocial;

        paragraph = new Paragraph(Mensajes.get("XCliente") + ": " + aux, font);
        paragraph.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(paragraph);

        BDVend.recuperar(cliente, ClienteDomicilio.class);

        aux = "";
        for (ClienteDomicilio dom : cliente.ClienteDomicilio) {
            if (dom.ClienteDomicilioId.equalsIgnoreCase(getPuntoEntrega())) {
                aux = dom.ClienteDomicilioId + "-" + dom.Calle + " " + dom.Numero + (dom.NumInt != null && !dom.NumInt.isEmpty() ? " INT " + dom.NumInt + " " : " ") +
                        (dom.Colonia != null && !dom.Colonia.isEmpty() ? " " + Mensajes.get("XCol") + " " + dom.Colonia + " " : " ") + " " + dom.Poblacion;
                break;
            }
        }

        paragraph = new Paragraph(Mensajes.get("XDomicilioEntrega") + ": " + aux, font);
        paragraph.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(paragraph);
        reportePDF.add(vacio);

        aux = ((Button) findViewById(R.id.btnFechaEntrega)).getText().toString();

        paragraph = new Paragraph(Mensajes.get("XFechaEntrega") + ": " + aux, font);
        paragraph.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(paragraph);

        aux = ((TextView) findViewById(R.id.txtFolio)).getText().toString();

        paragraph = new Paragraph(Mensajes.get("XFolio") + ": " + aux, font);
        paragraph.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(paragraph);
        reportePDF.add(vacio);

        Font textoNegrita = new Font(Font.FontFamily.COURIER, 17, Font.BOLD);

        aux = Impresion.completaHasta(Mensajes.get("XClave"), 10, Impresion.TipoAlineacion.IZQUIERDA, false);
        aux += Impresion.completaHasta(Mensajes.get("XDescripcion"), 28, Impresion.TipoAlineacion.IZQUIERDA, false);
        aux += Impresion.completaHasta(Mensajes.get("XUnidad"), 11, Impresion.TipoAlineacion.IZQUIERDA, true);

        paragraph = new Paragraph(aux, textoNegrita);
        paragraph.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(paragraph);

        aux = Impresion.completaHasta(Mensajes.get("XCantidad"), 9, Impresion.TipoAlineacion.DERECHA, false);
        aux += Impresion.completaHasta(Mensajes.get("XPrecioUnitario"), 17, Impresion.TipoAlineacion.DERECHA, false);
        aux += Impresion.completaHasta(Mensajes.get("XImpuestos"), 11, Impresion.TipoAlineacion.DERECHA, false);
        aux += Impresion.completaHasta(Mensajes.get("XSubtotal"), 11, Impresion.TipoAlineacion.DERECHA, true);

        paragraph = new Paragraph(aux, textoNegrita);
        paragraph.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(paragraph);
        reportePDF.add(vacio);

        font = new Font(FontFamily.COURIER, 20, Font.NORMAL);

        float volumen = 0, peso = 0, subtotal;
        ISetDatos datos = Consultas.ConsultasTransProdDetalle.obtenerDetallesPedidoPreview(aTransProdIds.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
        while (datos.moveToNext()) {
            aux = Impresion.completaHasta(datos.getString("Clave"), 10, Impresion.TipoAlineacion.IZQUIERDA, false);
            aux += Impresion.completaHasta(datos.getString("Descripcion"), 28, Impresion.TipoAlineacion.IZQUIERDA, false);
            aux += Impresion.completaHasta(ValoresReferencia.getDescripcion("UNIDADV", datos.getString("Unidad")), 11, Impresion.TipoAlineacion.IZQUIERDA, false);

            paragraph = new Paragraph(aux, textoNegrita);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);

            aux = Impresion.completaHasta(Generales.getFormatoDecimal(datos.getFloat("Cantidad"), 2), 9, Impresion.TipoAlineacion.DERECHA, false);
            aux += Impresion.completaHasta(Generales.getFormatoDecimal(datos.getFloat("Precio"), "#,##0.00"), 17, Impresion.TipoAlineacion.DERECHA, false);
            aux += Impresion.completaHasta(Generales.getFormatoDecimal(datos.getFloat("Impuestos"), "#,##0.00"), 11, Impresion.TipoAlineacion.DERECHA, false);
            subtotal = datos.getFloat("Cantidad") * datos.getFloat("Precio") + datos.getFloat("Impuestos");
            aux += Impresion.completaHasta(Generales.getFormatoDecimal(subtotal, "#,##0.00"), 11, Impresion.TipoAlineacion.DERECHA, true);

            volumen += datos.getFloat("Volumen");
            peso += datos.getFloat("Peso");

            paragraph = new Paragraph(aux, textoNegrita);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);
        }
        datos.close();
        reportePDF.add(vacio);
        reportePDF.add(vacio);

        font = new Font(FontFamily.COURIER, 22, Font.BOLD);

        aux = Mensajes.get("XVolumen") + ":  " + Generales.getFormatoDecimal(volumen, 2);

        paragraph = new Paragraph(aux, font);
        paragraph.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(paragraph);

        aux = Mensajes.get("XKgLts") + ":  " + Generales.getFormatoDecimal(peso, 2);

        paragraph = new Paragraph(aux, font);
        paragraph.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(paragraph);

        if (((NumberPicker) findViewById(R.id.npDescVendedor)).getDouble()>0 || ((NumberPicker) findViewById(R.id.npPorVendedor)).getDouble()>0 ){
            aux = Mensajes.get("XDesc.Vendedor") + " " + ((NumberPicker) findViewById(R.id.npPorVendedor)).getDouble()  + "%:  " + ((NumberPicker) findViewById(R.id.npDescVendedor)).getDouble();

            paragraph = new Paragraph(aux, font);
            paragraph.setAlignment(Element.ALIGN_RIGHT);
            reportePDF.add(paragraph);
        }

        aux = Mensajes.get("XSubtotal") + ":  " + ((TextView) findViewById(R.id.txtSubtotal)).getText();

        paragraph = new Paragraph(aux, font);
        paragraph.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(paragraph);

		/* Impuestos */
        datos = Consultas.ConsultasImpuesto.obtenerDetalleImpuestos(aTransProdIds.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
        if (datos.getCount() > 0)
            while (datos.moveToNext()) {
                paragraph = new Paragraph(datos.getString("Abreviatura") + ": " + Generales.getFormatoDecimal(datos.getFloat("ImpDesGlb"), "$  #,##0.00"), font);
                paragraph.setAlignment(Element.ALIGN_RIGHT);
                reportePDF.add(paragraph);
            }
        else {
            paragraph = new Paragraph(Mensajes.get("XImpuestos") + ": " + "$ 0.00", font);
            paragraph.setAlignment(Element.ALIGN_RIGHT);
            reportePDF.add(paragraph);
        }
        datos.close();
        /* Total */
        aux = Mensajes.get("XTotal") + ":  " + ((TextView) findViewById(R.id.txtTotal)).getText();

        paragraph = new Paragraph(aux, font);
        paragraph.setAlignment(Element.ALIGN_RIGHT);
        reportePDF.add(paragraph);
        reportePDF.add(vacio);
        reportePDF.add(vacio);

        font = new Font(FontFamily.COURIER, 20, Font.NORMAL);

        aux = ((TextView) findViewById(R.id.txtNotas)).getText().toString();

        paragraph = new Paragraph(Mensajes.get("XNotas") + ": " + aux, font);
        paragraph.setAlignment(Element.ALIGN_LEFT);
        reportePDF.add(paragraph);
        reportePDF.add(vacio);

        document.add(reportePDF);

	}

    private void construyePDFMultiTotales(Document document) throws Exception {
        String aux = null;
        Paragraph reportePDF = new Paragraph();
        Paragraph vacio = new Paragraph(" ");

        Iterator<TransProd> it = mPresenta.getTransacciones().iterator();
        while (it.hasNext()) {
            TransProd oTrp = it.next();
            ISetDatos encabezado = ConsultasImpresionTicket.obtenerEncabezado(oTrp.SubEmpresaId);
            encabezado.moveToFirst();

            Font font = new Font(FontFamily.COURIER, 26, Font.BOLD, BaseColor.BLUE);

            Paragraph paragraph = new Paragraph(encabezado.getString("NombreEmpresa"), font);
            paragraph.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(paragraph);

            font = new Font(FontFamily.COURIER, 20, Font.BOLD, BaseColor.BLACK);

            paragraph = new Paragraph(encabezado.getString("RFC"), font);
            paragraph.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(paragraph);
            reportePDF.add(vacio);

            encabezado.close();

            paragraph = new Paragraph(Mensajes.get("XImpresion") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy hh:mm:ss"), font);
            paragraph.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(paragraph);
            reportePDF.add(vacio);

            font = new Font(FontFamily.COURIER, 20, Font.BOLD, BaseColor.BLACK);

            aux = ((Ruta) Sesion.get(Campo.RutaActual)).RUTClave + "-" + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion;

            paragraph = new Paragraph(Mensajes.get("XRuta") + ": " + aux, font);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);

            aux = ((Vendedor) Sesion.get(Campo.VendedorActual)).Nombre;

            paragraph = new Paragraph(Mensajes.get("XVendedor") + ": " + aux, font);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);

            Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

            aux = cliente.Clave + "-" + cliente.RazonSocial;

            paragraph = new Paragraph(Mensajes.get("XCliente") + ": " + aux, font);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);

            BDVend.recuperar(cliente, ClienteDomicilio.class);

            aux = "";
            for (ClienteDomicilio dom : cliente.ClienteDomicilio) {
                if (dom.ClienteDomicilioId.equalsIgnoreCase(getPuntoEntrega())) {
                    aux = dom.ClienteDomicilioId + "-" + dom.Calle + " " + dom.Numero + (dom.NumInt != null && !dom.NumInt.isEmpty() ? " INT " + dom.NumInt + " " : " ") +
                            (dom.Colonia != null && !dom.Colonia.isEmpty() ? " " + Mensajes.get("XCol") + " " + dom.Colonia + " " : " ") + " " + dom.Poblacion;
                    break;
                }
            }

            paragraph = new Paragraph(Mensajes.get("XDomicilioEntrega") + ": " + aux, font);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);
            reportePDF.add(vacio);

            aux = ((Button) findViewById(R.id.btnFechaEntrega)).getText().toString();

            paragraph = new Paragraph(Mensajes.get("XFechaEntrega") + ": " + aux, font);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);

            paragraph = new Paragraph(Mensajes.get("XFolio") + ": " + oTrp.Folio, font);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);
            reportePDF.add(vacio);

            Font textoNegrita = new Font(Font.FontFamily.COURIER, 17, Font.BOLD);

            aux = Impresion.completaHasta(Mensajes.get("XClave"), 10, Impresion.TipoAlineacion.IZQUIERDA, false);
            aux += Impresion.completaHasta(Mensajes.get("XDescripcion"), 28, Impresion.TipoAlineacion.IZQUIERDA, false);
            aux += Impresion.completaHasta(Mensajes.get("XUnidad"), 11, Impresion.TipoAlineacion.IZQUIERDA, true);

            paragraph = new Paragraph(aux, textoNegrita);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);

            aux = Impresion.completaHasta(Mensajes.get("XCantidad"), 9, Impresion.TipoAlineacion.DERECHA, false);
            aux += Impresion.completaHasta(Mensajes.get("XPrecioUnitario"), 17, Impresion.TipoAlineacion.DERECHA, false);
            aux += Impresion.completaHasta(Mensajes.get("XImpuestos"), 11, Impresion.TipoAlineacion.DERECHA, false);
            aux += Impresion.completaHasta(Mensajes.get("XSubtotal"), 11, Impresion.TipoAlineacion.DERECHA, true);

            paragraph = new Paragraph(aux, textoNegrita);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);
            reportePDF.add(vacio);

            font = new Font(FontFamily.COURIER, 20, Font.NORMAL);

            float volumen = 0, peso = 0, subtotal;
            ISetDatos datos = Consultas.ConsultasTransProdDetalle.obtenerDetallesPedidoPreview("'" + oTrp.TransProdID + "'");
            while (datos.moveToNext()) {
                aux = Impresion.completaHasta(datos.getString("Clave"), 10, Impresion.TipoAlineacion.IZQUIERDA, false);
                aux += Impresion.completaHasta(datos.getString("Descripcion"), 28, Impresion.TipoAlineacion.IZQUIERDA, false);
                aux += Impresion.completaHasta(ValoresReferencia.getDescripcion("UNIDADV", datos.getString("Unidad")), 11, Impresion.TipoAlineacion.IZQUIERDA, false);

                paragraph = new Paragraph(aux, textoNegrita);
                paragraph.setAlignment(Element.ALIGN_LEFT);
                reportePDF.add(paragraph);

                aux = Impresion.completaHasta(Generales.getFormatoDecimal(datos.getFloat("Cantidad"), 2), 9, Impresion.TipoAlineacion.DERECHA, false);
                aux += Impresion.completaHasta(Generales.getFormatoDecimal(datos.getFloat("Precio"), "#,##0.00"), 17, Impresion.TipoAlineacion.DERECHA, false);
                aux += Impresion.completaHasta(Generales.getFormatoDecimal(datos.getFloat("Impuestos"), "#,##0.00"), 11, Impresion.TipoAlineacion.DERECHA, false);
                subtotal = datos.getFloat("Cantidad") * datos.getFloat("Precio") + datos.getFloat("Impuestos");
                aux += Impresion.completaHasta(Generales.getFormatoDecimal(subtotal, "#,##0.00"), 11, Impresion.TipoAlineacion.DERECHA, true);

                volumen += datos.getFloat("Volumen");
                peso += datos.getFloat("Peso");

                paragraph = new Paragraph(aux, textoNegrita);
                paragraph.setAlignment(Element.ALIGN_LEFT);
                reportePDF.add(paragraph);
            }
            datos.close();
            reportePDF.add(vacio);
            reportePDF.add(vacio);

            font = new Font(FontFamily.COURIER, 22, Font.BOLD);

            aux = Mensajes.get("XVolumen") + ":  " + Generales.getFormatoDecimal(volumen, 2);

            paragraph = new Paragraph(aux, font);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);

            aux = Mensajes.get("XKgLts") + ":  " + Generales.getFormatoDecimal(peso, 2);

            paragraph = new Paragraph(aux, font);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);

            if ((oTrp.DescVendPor != null && oTrp.DescVendPor>0) || (oTrp.DescuentoVendedor != null && oTrp.DescuentoVendedor>0) ){
                aux = Mensajes.get("XDesc.Vendedor") + " " + Generales.getFormatoDecimal(oTrp.DescVendPor,4)  + "%:  " + Generales.getFormatoDecimal(oTrp.DescuentoVendedor,2);

                paragraph = new Paragraph(aux, font);
                paragraph.setAlignment(Element.ALIGN_RIGHT);
                reportePDF.add(paragraph);
            }

            aux = Mensajes.get("XSubtotal") + ":  " +  Generales.getFormatoDecimal(oTrp.Subtotal,2);

            paragraph = new Paragraph(aux, font);
            paragraph.setAlignment(Element.ALIGN_RIGHT);
            reportePDF.add(paragraph);

            /* Impuestos */
            datos = Consultas.ConsultasImpuesto.obtenerDetalleImpuestos("'" + oTrp.TransProdID + "'");
            if (datos.getCount() > 0)
                while (datos.moveToNext()) {
                    paragraph = new Paragraph(datos.getString("Abreviatura") + ": " + Generales.getFormatoDecimal(datos.getFloat("ImpDesGlb"), "$  #,##0.00"), font);
                    paragraph.setAlignment(Element.ALIGN_RIGHT);
                    reportePDF.add(paragraph);
                }
            else {
                paragraph = new Paragraph(Mensajes.get("XImpuestos") + ": " + "$ 0.00", font);
                paragraph.setAlignment(Element.ALIGN_RIGHT);
                reportePDF.add(paragraph);
            }
            datos.close();
            /* Total */
            aux = Mensajes.get("XTotal") + ":  " + Generales.getFormatoDecimal(oTrp.Total, 2);

            paragraph = new Paragraph(aux, font);
            paragraph.setAlignment(Element.ALIGN_RIGHT);
            reportePDF.add(paragraph);
            reportePDF.add(vacio);
            reportePDF.add(vacio);

            font = new Font(FontFamily.COURIER, 20, Font.NORMAL);

            aux = (oTrp.Notas == null ? "" : oTrp.Notas);

            paragraph = new Paragraph(Mensajes.get("XNotas") + ": " + aux, font);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);
            reportePDF.add(vacio);
        }
        document.add(reportePDF);

    }

    // clase para la vista del desglose de impuestos
    public static class vistaDesgloseImp {
        private String abreviatura;
        private float porcentaje;
        private float importe;
        private int tipoValor;

        public vistaDesgloseImp(String sAbreviatura, float fPorcentaje, float fImporte, int iTipoValor) {
            abreviatura = sAbreviatura;
            porcentaje = fPorcentaje;
            importe = fImporte;
            tipoValor = iTipoValor;
        }

        public String getAbreviatura() {
            return abreviatura;
        }

        /*public void setAbreviatura(String abreviatura) {
            this.abreviatura = abreviatura;
        }*/

        public float getPorcentaje() {
            return porcentaje;
        }

        public void setPorcentaje(float porcentaje) {
            this.porcentaje = porcentaje;
        }

        public float getImporte() {
            return importe;
        }

        public void setImporte(float importe) {
            this.importe = importe;
        }

        public int getTipoValor() {
            return tipoValor;
        }

       /* public void setTipoValor(int iTipoValor) {
            this.tipoValor = iTipoValor;
        }*/


	}

    public static class vistaDesgloseProm {
        private String ClaveProducto;
        private String NombreProducto;
        private String ClavePromocion;
        private String NombrePromocion;
        private String Descuento;
        private String ImporteDesc;
        private String Bonificacion;
        private String ProdRegalo;
        private String Cantidad;
        private String Puntos;
        private String Precio;
        private boolean isMasdeUno;
        private ArrayList<vistaDesgloseProm> mvistaDesgloseProm = new ArrayList<vistaDesgloseProm>();

        public vistaDesgloseProm(String claveProducto, String nombreProducto, String clavePromocion, String nombrePromocion, String descuento, String importeDesc, String bonificacion, String prodRegalo, String cantidad, String puntos, String precio, boolean ismasdeUno, ArrayList<vistaDesgloseProm> mVistaDesgloseProm) {
            ClaveProducto = claveProducto;
            NombreProducto = nombreProducto;
            ClavePromocion = clavePromocion;
            NombrePromocion = nombrePromocion;
            Descuento = descuento;
            ImporteDesc = importeDesc;
            ProdRegalo = prodRegalo;
            Bonificacion = bonificacion;
            Cantidad = cantidad;
            Puntos = puntos;
            Precio = precio;
            isMasdeUno = ismasdeUno;
            setMvistaDesgloseProm(mVistaDesgloseProm);

        }

        /*public boolean isMasdeUno() {
            return isMasdeUno;
        }*/

        /*public void setMasdeUno(boolean isMasdeUno) {
            this.isMasdeUno = isMasdeUno;
        }*/

        public String getPrecio() {
            return Precio;
        }

        public void setPrecio(String precio) {
            Precio = precio;
        }

        public String getClaveProducto() {
            return ClaveProducto;
        }

        /*public void setClaveProducto(String claveProducto) {
            ClaveProducto = claveProducto;
        }*/

        public String getNombreProducto() {
            return NombreProducto;
        }

        /*public void setNombreProducto(String nombreProducto) {
            NombreProducto = nombreProducto;
        }*/

        public String getClavePromocion() {
            return ClavePromocion;
        }

       /* public void setClavePromocion(String clavePromocion) {
            ClavePromocion = clavePromocion;
        }*/

        public String getNombrePromocion() {
            return NombrePromocion;
        }

        /*public void setNombrePromocion(String nombrePromocion) {
            NombrePromocion = nombrePromocion;
        }*/

        public String getDescuento() {
            return Descuento;
        }

        public void setDescuento(String descuento) {
            Descuento = descuento;
        }

        public String getImporteDesc() {
            return ImporteDesc;
        }

        /*public void setImporteDesc(String importeDesc) {
            ImporteDesc = importeDesc;
        }*/

        public String getBonificacion() {
            return Bonificacion;
        }

       /* public void setBonificacion(String bonificacion) {
            Bonificacion = bonificacion;
        }*/

        public String getCantidad() {
            return Cantidad;
        }

        public void setCantidad(String cantidad) {
            Cantidad = cantidad;
        }

        public String getProdRegalo() {
            return ProdRegalo;
        }

       /* public void setProdRegalo(String prodRegalo) {
            ProdRegalo = prodRegalo;
        }*/

        public String getPuntos() {
            return Puntos;
        }

        public void setPuntos(String puntos) {
            Puntos = puntos;
        }

        public ArrayList<vistaDesgloseProm> getMvistaDesgloseProm() {
            return mvistaDesgloseProm;
        }

        public void setMvistaDesgloseProm(ArrayList<vistaDesgloseProm> mvistaDesgloseProm) {
            this.mvistaDesgloseProm = mvistaDesgloseProm;
        }

	}

    public static class vistaPromoRegaloCanje {
        private String ClavePromocion;
        private String NombrePromocion;
        private String ClaveNombreProductos;
        private Integer TipoAplicacion;
        private ArrayList<vistaDetalleRegalosCanjes> mvistaDesglose = new ArrayList<vistaDetalleRegalosCanjes>();

        public vistaPromoRegaloCanje(String clavePromocion, String nombrePromocion, String listadoProductos, Integer tipoAplicacion) {
            ClavePromocion = clavePromocion;
            NombrePromocion = nombrePromocion;
            ClaveNombreProductos = listadoProductos;
            TipoAplicacion = tipoAplicacion;
        }

        public String getClavePromocion() {
            return ClavePromocion;
        }

        public String getNombrePromocion() {
            return NombrePromocion;
        }
        public String getClaveNombreProductos() {
            return ClaveNombreProductos;
        }

        public Integer getTipoAplicacion() {
            return TipoAplicacion;
        }

        public ArrayList<vistaDetalleRegalosCanjes> getMvistaDetallePromRegalo() {
            return mvistaDesglose;
        }

        public void setMvistaDesgloseProm(ArrayList<vistaDetalleRegalosCanjes> MvistaDetallePromRegalo) {
            mvistaDesglose = getMvistaDetallePromRegalo();
        }
    }

    public static class vistaDetalleRegalosCanjes {
        private String ProductoRegalo;
        private Float Cantidad;
        private Float Precio;
        private Float Total;

        public vistaDetalleRegalosCanjes(String productoRegalo, Float cantidad, Float precio, Float total) {
            ProductoRegalo = productoRegalo;
            Cantidad = cantidad;
            Precio = precio;
            Total = total;
        }

        public String getProductoRegalo() {
            return ProductoRegalo;
        }
        public Float getCantidad() {
            return Cantidad;
        }

        public Float getPrecio() {
            return Precio;
        }
        public Float getTotal() {
            return Total;
        }

    }

    public static class vistaDesgloseProntoPago {
        private String ClavePromocion;
        private String NombrePromocion;
        private String ClaveProductos;
        private String Importe;
        private String Descuento;

        //private boolean isMasdeUno;
        //private ArrayList<vistaDesglosePromoProntoPago> mvistaDesgloseProm = new ArrayList<vistaDesglosePromoProntoPago>();

        public vistaDesgloseProntoPago(String clavePromocion, String nombrePromocion, String claveProductos, String importe, String descuento){ //, ArrayList<vistaDesglosePromoProntoPago> mVistaDesgloseProm) {
            ClavePromocion = clavePromocion;
            NombrePromocion = nombrePromocion;
            ClaveProductos = claveProductos;
            Importe = importe;
            Descuento = descuento;
            //setMvistaDesgloseProm(mVistaDesgloseProm);

        }
        public String getClaveProductos() {
            return ClaveProductos;
        }

        public String getClavePromocion() {
            return ClavePromocion;
        }

        public String getNombrePromocion() {
            return NombrePromocion;
        }

        public String getDescuento() {
            return Descuento;
        }

        public void setDescuento(String descuento) {
            Descuento = descuento;
        }

        public String getImporte() {
            return Importe;
        }

        /*public ArrayList<vistaDesglosePromoProntoPago> getMvistaDesgloseProm() {
            return mvistaDesgloseProm;
        }

        public void setMvistaDesgloseProm(ArrayList<vistaDesglosePromoProntoPago> mvistaDesgloseProm) {
            this.mvistaDesgloseProm = mvistaDesgloseProm;
        }*/

    }

    // adapter para la lista del desglose de impuestos
    private class adapterDesgloseImp extends ArrayAdapter<vistaDesgloseImp> {

        int textViewResourceId;
        Context context;

        public adapterDesgloseImp(Context context, int textViewResourceId, vistaDesgloseImp[] objects) {
            super(context, textViewResourceId, objects);
            this.textViewResourceId = textViewResourceId;
            this.context = context;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View fila = convertView;

            if (convertView == null) {
                LayoutInflater inflater = ((Activity) context).getLayoutInflater();
                fila = inflater.inflate(textViewResourceId, null);
            }
            vistaDesgloseImp impuesto = getItem(position);

            TextView texto = (TextView) fila.findViewById(R.id.lblNombreImpuesto);
            if (texto != null)
                texto.setText(impuesto.getAbreviatura());

            texto = (TextView) fila.findViewById(R.id.lblPorcentajeImp);
            if (texto != null) {
                if (impuesto.getTipoValor() == 1) {
                    texto.setText(Generales.getFormatoDecimal(impuesto.getPorcentaje() / 100, "##0.00 %"));
                } else {
                    texto.setText(Generales.getFormatoDecimal(impuesto.getPorcentaje(), "##0.00"));
                }

            }
            // texto.setText(String.format("%.2f %%",
            // impuesto.getPorcentaje()));

            texto = (TextView) fila.findViewById(R.id.lblTotalImp);
            if (texto != null)
                texto.setText(Generales.getFormatoDecimal(impuesto.getImporte(), "$ #,##0.00"));
            // texto.setText(String.format("$ %.2f", impuesto.getImporte()));

            return fila;
        }

	}

    private class adapterDesglosePro extends ArrayAdapter<vistaDesgloseProm> {

        int textViewResourceId;
        Context context;
        Boolean blnRegalos;
        public adapterDesglosePro(Context context, int textViewResourceId, ArrayList<vistaDesgloseProm> objects) {
            super(context, textViewResourceId, objects);
            this.textViewResourceId = textViewResourceId;
            this.context = context;
        }

        @SuppressWarnings("unchecked")
        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View fila = convertView;

            if (convertView == null) {
                LayoutInflater inflater = ((Activity) context).getLayoutInflater();
                fila = inflater.inflate(textViewResourceId, null);
            }
            vistaDesgloseProm Promociones = getItem(position);
            try {
                TextView texto = (TextView) fila.findViewById(R.id.txtProductoClavePromociones);
                if (texto != null)
                    texto.setText(Promociones.getNombreProducto());


                ListView modeListlblPromociones = (ListView) fila.findViewById(R.id.lstProductoPromociones);
                ArrayList<vistaDesgloseProm> desglosePromociones;
                    desglosePromociones = mPresenta.obtenerDesglosePromocion((ArrayList<String>) oParametros.get("TransProdId"), Promociones.getClaveProducto());
                    if (desglosePromociones != null) {
                        final adapterDesgloseProDetalle adapter = new adapterDesgloseProDetalle(CapturaTotales.this, R.layout.lista_pedidopromocion, desglosePromociones);
                        modeListlblPromociones.setAdapter(adapter);
                        setListViewHeightBasedOnChildren(modeListlblPromociones);
                    }

            } catch (Exception e) {
                Log.e("", "", e);
            }
            return fila;
        }

	}

    private class adapterDesglosePromRegaloCanje extends ArrayAdapter<vistaPromoRegaloCanje> {

        int textViewResourceId;
        Context context;
        Boolean blnRegalos;
        public adapterDesglosePromRegaloCanje(Context context, int textViewResourceId, ArrayList<vistaPromoRegaloCanje> objects) {
            super(context, textViewResourceId, objects);
            this.textViewResourceId = textViewResourceId;
            this.context = context;
        }

        @SuppressWarnings("unchecked")
        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View fila = convertView;

            if (convertView == null) {
                LayoutInflater inflater = ((Activity) context).getLayoutInflater();
                fila = inflater.inflate(textViewResourceId, null);
            }
            vistaPromoRegaloCanje Promocion = getItem(position);
            try {
                TextView texto = (TextView) fila.findViewById(R.id.txtProductoClavePromociones);
                if (texto != null) {
                    texto.setText(Promocion.ClavePromocion + " - " + Promocion.NombrePromocion);
                    texto.setMaxLines(0);
                    setTextViewHeightBasedOnContent(texto,80);
                }
                LinearLayout layoutListadoProductos = (LinearLayout) fila.findViewById(R.id.layoutListadoProductos);
                if (layoutListadoProductos != null) {
                    layoutListadoProductos.setVisibility(convertView.VISIBLE);
                    TextView lblProductos= (TextView) fila.findViewById(R.id.lblProductos);
                    if (lblProductos != null){
                        lblProductos.setText(Mensajes.get("XProductos") + ": ");
                    }
                    TextView txtProductos = (TextView) fila.findViewById(R.id.txtListadoProductos);
                    if (txtProductos != null) {
                        txtProductos.setText(Promocion.ClaveNombreProductos);
                        setTextViewHeightBasedOnContent(txtProductos, 50);
                    }
                }

                ListView modeListlblPromociones = (ListView) fila.findViewById(R.id.lstProductoPromociones);
                mPresenta.obtenerDesglosePromocionRegaloCanje(aTransProdIds.toString().replace("[", "'").replace("]", "'").replace(", ", "','"), Promocion);
                if (Promocion.getMvistaDetallePromRegalo() != null) {
                    //ListView modeListlblPromociones = (ListView) fila.findViewById(R.id.lvRegalos);
                    modeListlblPromociones.setVisibility(View.VISIBLE);
                    final adapterDesgloseProdRegalo adapter = new adapterDesgloseProdRegalo(CapturaTotales.this, R.layout.lista_pedidopromocion, Promocion.getMvistaDetallePromRegalo());
                    modeListlblPromociones.setAdapter(adapter);
                    setListViewHeightBasedOnChildren(modeListlblPromociones);
                }

            } catch (Exception e) {
                Log.e("", "", e);
            }
            return fila;
        }

    }

    private class adapterDesgloseProDetalle extends ArrayAdapter<vistaDesgloseProm> {

        int textViewResourceId;
        Context context;

        public adapterDesgloseProDetalle(Context context, int textViewResourceId, ArrayList<vistaDesgloseProm> objects) {
            super(context, textViewResourceId, objects);
            this.textViewResourceId = textViewResourceId;
            this.context = context;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View fila = convertView;

            if (convertView == null) {
                LayoutInflater inflater = ((Activity) context).getLayoutInflater();
                fila = inflater.inflate(textViewResourceId, null);
            }
            LinearLayout llayoutClaveNombre = (LinearLayout) fila.findViewById(R.id.layoutClaveNombre);
            LinearLayout llayoutNombrePromocion = (LinearLayout) fila.findViewById(R.id.layoutNombrePromocion);
            LinearLayout mLlayoutImporteDes = (LinearLayout) fila.findViewById(R.id.layoutImporteDes);
            LinearLayout mLlayoutBonificacion = (LinearLayout) fila.findViewById(R.id.layoutBonificacion);
            LinearLayout llayoutCantidad = (LinearLayout) fila.findViewById(R.id.layoutCantidadRegalo);
            LinearLayout llayoutProdRegalo = (LinearLayout) fila.findViewById(R.id.layoutProdRegalo);
            LinearLayout llayoutPuntos = (LinearLayout) fila.findViewById(R.id.layoutPunto);
            LinearLayout llayoutPrecio = (LinearLayout) fila.findViewById(R.id.layoutPrecio);
            vistaDesgloseProm Promociones = getItem(position);
            TextView texto = (TextView) fila.findViewById(R.id.lblClavePromoValue);
            if (texto != null)
                texto.setText(Promociones.getClavePromocion());
            TextView textoCantidad = (TextView) fila.findViewById(R.id.lblNombrePromocionValue);
            if (textoCantidad != null)
                textoCantidad.setText(Promociones.getNombrePromocion());
            if (Promociones.getImporteDesc() != null) {
                llayoutNombrePromocion.setVisibility(View.VISIBLE);
                llayoutClaveNombre.setVisibility(View.VISIBLE);
                mLlayoutBonificacion.setVisibility(View.GONE);
                llayoutCantidad.setVisibility(View.GONE);
                llayoutProdRegalo.setVisibility(View.GONE);
                mLlayoutImporteDes.setVisibility(View.VISIBLE);
                llayoutPuntos.setVisibility(View.GONE);
                llayoutPrecio.setVisibility(View.GONE);
                texto = (TextView) fila.findViewById(R.id.lblImporteDesValue);
                texto.setText("$ " + Promociones.getImporteDesc());
            }
            if (Promociones.getBonificacion() != null) {
                llayoutNombrePromocion.setVisibility(View.VISIBLE);
                llayoutClaveNombre.setVisibility(View.VISIBLE);
                llayoutCantidad.setVisibility(View.GONE);
                llayoutProdRegalo.setVisibility(View.GONE);
                llayoutPuntos.setVisibility(View.GONE);
                mLlayoutImporteDes.setVisibility(View.GONE);
                mLlayoutBonificacion.setVisibility(View.VISIBLE);
                llayoutPrecio.setVisibility(View.GONE);
                texto = (TextView) fila.findViewById(R.id.lblBonificacionValue);
                texto.setText("$ " + Promociones.getBonificacion());
            }

            /*if (Promociones.getMvistaDesgloseProm() != null) {

                ListView modeListlblPromociones = (ListView) fila.findViewById(R.id.lvRegalos);
                modeListlblPromociones.setVisibility(View.VISIBLE);
                final adapterDesgloseProdRegalo adapter = new adapterDesgloseProdRegalo(CapturaTotales.this, R.layout.lista_pedidopromocion, Promociones.getMvistaDesgloseProm());
                modeListlblPromociones.setAdapter(adapter);
                setListViewHeightBasedOnChildren(modeListlblPromociones);

            }*/

            if (Promociones.getPuntos() != null) {
                llayoutNombrePromocion.setVisibility(View.VISIBLE);
                llayoutClaveNombre.setVisibility(View.VISIBLE);
                mLlayoutImporteDes.setVisibility(View.GONE);
                mLlayoutBonificacion.setVisibility(View.GONE);
                llayoutCantidad.setVisibility(View.GONE);
                llayoutPuntos.setVisibility(View.VISIBLE);
                llayoutProdRegalo.setVisibility(View.GONE);
                llayoutPrecio.setVisibility(View.GONE);
                texto = (TextView) fila.findViewById(R.id.lblPunotsValue);
                texto.setText(Promociones.getPuntos());

            }
            if (Promociones.getPrecio() != null) {
                llayoutNombrePromocion.setVisibility(View.VISIBLE);
                llayoutClaveNombre.setVisibility(View.VISIBLE);
                mLlayoutImporteDes.setVisibility(View.GONE);
                mLlayoutBonificacion.setVisibility(View.GONE);
                llayoutCantidad.setVisibility(View.GONE);
                llayoutPuntos.setVisibility(View.GONE);
                llayoutProdRegalo.setVisibility(View.GONE);
                llayoutPrecio.setVisibility(View.VISIBLE);
                ListView modeListlblPromociones = (ListView) fila.findViewById(R.id.lvRegalos);
                modeListlblPromociones.setVisibility(View.GONE);
                texto = (TextView) fila.findViewById(R.id.lblPrecioValue);
                texto.setText("$ " + Promociones.getPrecio());

            }

            return fila;
        }
	}

    private class adapterDesgloseProdRegalo extends ArrayAdapter<vistaDetalleRegalosCanjes> {

        int textViewResourceId;
        Context context;

        public adapterDesgloseProdRegalo(Context context, int textViewResourceId, ArrayList<vistaDetalleRegalosCanjes> objects) {
            super(context, textViewResourceId, objects);
            this.textViewResourceId = textViewResourceId;
            this.context = context;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View fila = convertView;

            if (convertView == null) {
                LayoutInflater inflater = ((Activity) context).getLayoutInflater();
                fila = inflater.inflate(textViewResourceId, null);
            }
            LinearLayout llayoutClaveNombre = (LinearLayout) fila.findViewById(R.id.layoutClaveNombre);
            LinearLayout llayoutNombrePromocion = (LinearLayout) fila.findViewById(R.id.layoutNombrePromocion);
            LinearLayout mLlayoutImporteDes = (LinearLayout) fila.findViewById(R.id.layoutImporteDes);
            LinearLayout mLlayoutBonificacion = (LinearLayout) fila.findViewById(R.id.layoutBonificacion);
            LinearLayout llayoutCantidad = (LinearLayout) fila.findViewById(R.id.layoutCantidadRegalo);
            LinearLayout llayoutProdRegalo = (LinearLayout) fila.findViewById(R.id.layoutProdRegalo);
            LinearLayout llayoutPuntos = (LinearLayout) fila.findViewById(R.id.layoutPunto);
            LinearLayout llayoutPrecio = (LinearLayout) fila.findViewById(R.id.layoutPrecio);
            vistaDetalleRegalosCanjes Promociones = getItem(position);

           /* TextView texto = (TextView) fila.findViewById(R.id.lblClavePromoValue);
            if (texto != null)
                texto.setVisibility(View.GONE);
            TextView textoCantidad = (TextView) fila.findViewById(R.id.lblNombrePromocionValue);
            if (textoCantidad != null)
                textoCantidad.setVisibility(View.GONE);
*/

            llayoutNombrePromocion.setVisibility(View.GONE);
            llayoutClaveNombre.setVisibility(View.GONE);

            mLlayoutImporteDes.setVisibility(View.GONE);
            mLlayoutBonificacion.setVisibility(View.GONE);
            llayoutPuntos.setVisibility(View.GONE);
            llayoutCantidad.setVisibility(View.VISIBLE);
            llayoutProdRegalo.setVisibility(View.VISIBLE);
            llayoutPrecio.setVisibility(View.GONE);
            TextView texto = (TextView) fila.findViewById(R.id.lblCantidadRegaloValue);
            texto.setText(Generales.getFormatoDecimal(Promociones.getCantidad(),"#,##0.##"));
            texto = (TextView) fila.findViewById(R.id.lblProdRegaloValue);
            texto.setText(Promociones.getProductoRegalo());

            if (Promociones.getPrecio() != null){
                llayoutPrecio.setVisibility(View.VISIBLE);
                texto = (TextView) fila.findViewById(R.id.lblProdRegalo);
                texto.setText(Mensajes.get("PROCanje")+ ":");
                texto = (TextView) fila.findViewById(R.id.lblPrecioValue);
                texto.setText(Generales.getFormatoDecimal(Promociones.getPrecio(),"#,##0.00"));
                llayoutPuntos.setVisibility(View.VISIBLE);
                texto = (TextView) fila.findViewById(R.id.lblPunto);
                texto.setText(Mensajes.get("XTotalMin"));
                texto = (TextView) fila.findViewById(R.id.lblPunotsValue);
                texto.setText(Generales.getFormatoDecimal(Promociones.getTotal(), "#,##0.00"));
            }
            return fila;

		}

    }

    private class adapterDesgloseProntoPago extends ArrayAdapter<vistaDesgloseProntoPago>{
        int textViewResourceId;
        Context context;

        public adapterDesgloseProntoPago(Context context, int textViewResourceId, ArrayList<vistaDesgloseProntoPago> objects) {
            super(context, textViewResourceId, objects);
            this.textViewResourceId = textViewResourceId;
            this.context = context;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View fila = convertView;

            if (convertView == null) {
                LayoutInflater inflater = ((Activity) context).getLayoutInflater();
                fila = inflater.inflate(textViewResourceId, null);
            }
            /*LinearLayout layoutPromocion = (LinearLayout) fila.findViewById(R.id.layoutPromocion);
            LinearLayout layoutProductos = (LinearLayout) fila.findViewById(R.id.layoutProductos);
            LinearLayout layoutImporte = (LinearLayout) fila.findViewById(R.id.layoutImporte);
            LinearLayout layoutDescuento = (LinearLayout) fila.findViewById(R.id.layoutDescuento);*/
            vistaDesgloseProntoPago promocion = getItem(position);

            TextView texto = (TextView) fila.findViewById(R.id.txtClavePromocion);
            if (texto != null) {
                texto.setText(promocion.getClavePromocion() + " " + promocion.getNombrePromocion());
                setTextViewHeightBasedOnContent(texto, 100);
            }

            texto = (TextView) fila.findViewById(R.id.lblProductosValue);
            if (texto != null) {
                texto.setText(promocion.getClaveProductos());
                setTextViewHeightBasedOnContent(texto, 70);
            }

            texto = (TextView) fila.findViewById(R.id.lblImporteValue);
            if (texto != null)
                texto.setText(promocion.getImporte());

            texto = (TextView) fila.findViewById(R.id.lblDescuentoValue);
            if (texto != null)
                texto.setText(promocion.getDescuento());

            return fila;
        }
    }


}

