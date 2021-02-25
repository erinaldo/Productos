package com.amesol.routelite.vistas;

import android.annotation.SuppressLint;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.content.Intent;
import android.os.Bundle;
import android.text.format.DateFormat;
import android.view.KeyEvent;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.CapturarCobranzaPedidoAnticipado;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaPedidoAnticipado;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedList;

/**
 * Created by projas on 08/10/2015.
 */
public class CapturaCobranzaPedidoAnticipado  extends Vista implements ICapturaCobranzaPedidoAnticipado {
    String mAccion;
    CapturarCobranzaPedidoAnticipado mPresenta;
    static final int DATE_DIALOG_ID = 0;

    /*LinkedList<Cobranza.VistaSpinner> pagos;*/
    LinkedList<Cobranza.VistaSpinner> monedas;
    LinkedList<Cobranza.VistaSpinner> bancos;
    //ArrayList<Integer> tiposCP;

    Spinner spnTipoPago;
    Spinner spnTipoBanco;
    EditText txtReferencia;

    boolean imprimiendo;
    boolean errorFinalizar = false;

    boolean huboCambios = true;
    Date fechaCheque = null;
    EditText ebSaldoFin;
    EditText ebSaldoIni;


    @SuppressWarnings("unchecked")
    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        try
        {
            super.onCreate(savedInstanceState);
            imprimiendo = false;

            mAccion = getIntent().getAction();

            setContentView(R.layout.captura_cobranza_pago_anticipado);
            deshabilitarBarra(true);

            setTitulo(Mensajes.get("XCobranza"));

            TextView lbFolio = (TextView) findViewById(R.id.lblFolio);
            lbFolio.setText(Mensajes.get("XFolio"));

            TextView lbFecha = (TextView) findViewById(R.id.lblFecha);
            lbFecha.setText(Mensajes.get("XFecha"));

            TextView lbSaldoIni = (TextView) findViewById(R.id.lblSaldoIni);
            lbSaldoIni.setText(Mensajes.get("XSaldoInicial"));

             ebSaldoIni = (EditText)findViewById(R.id.ebSaldoIni);

             ebSaldoFin = (EditText)findViewById(R.id.ebSaldoFin);

            TextView lbSaldoFin = (TextView) findViewById(R.id.lblSaldoFin);
            lbSaldoFin.setText(Mensajes.get("XSaldoRestante"));

            TextView lbFormaPagoTit = (TextView) findViewById(R.id.lblFormaPago);
            lbFormaPagoTit.setText(Mensajes.get("XFormaPago"));

            TextView lblMoneda = (TextView) findViewById(R.id.lblMoneda);
            lblMoneda.setText(Mensajes.get("XMoneda"));

            TextView lblImporte = (TextView) findViewById(R.id.lblImporte);
            lblImporte.setText(Mensajes.get("XImporte"));

            TextView lblBanco = (TextView) findViewById(R.id.lblBanco);
            lblBanco.setText(Mensajes.get("XBanco"));

            TextView lblReferencia = (TextView) findViewById(R.id.lblReferencia);
            lblReferencia.setText(Mensajes.get("XReferencia"));

            TextView lblFechaCheque = (TextView) findViewById(R.id.lblFechaCheque);
            lblFechaCheque.setText(Mensajes.get("XFechaCheque"));

            EditText ebFechaCheque = (EditText) findViewById(R.id.ebFechaCheque);
            ebFechaCheque.setOnClickListener(mSeleccionarFecha);
            //No se habilita porque no hay posfechados
            ebFechaCheque.setEnabled(false);
            fechaCheque = Generales.getFechaActual();
            ebFechaCheque.setText(DateFormat.format("dd/MM/yyyy", Generales.getFechaActual()));

            //TextView lbTotal = (TextView) findViewById(R.id.lblTotalAbono);
            //lbTotal.setText(Mensajes.get("ABNTotal"));

            final EditText ebImporte = (EditText)  findViewById(R.id.ebImporte);

            Button btnContinuar = (Button) findViewById(R.id.btnContinuar);
            btnContinuar.setText(Mensajes.get("XContinuar"));
            btnContinuar.setOnClickListener(mContinuar);

            spnTipoBanco = (Spinner) findViewById(R.id.spnBanco);
            txtReferencia = (EditText)findViewById(R.id.ebReferencia);

            spnTipoPago = (Spinner) findViewById(R.id.spnFormaPago);
            spnTipoPago.setOnItemSelectedListener(
                    new  Spinner.OnItemSelectedListener() {
                        public void onItemSelected(
                                AdapterView<?> parent, View view, int position, long id) {
                            if (((Cobranza.VistaSpinner)spnTipoPago.getItemAtPosition(position)).getId().equals("1")){
                                spnTipoBanco.setEnabled(false);
                                spnTipoBanco.setAdapter(null);
                                txtReferencia.setEnabled(false);
                                txtReferencia.setText("");
                            }else{
                                spnTipoBanco.setEnabled(true);
                                poblarSpinner(spnTipoBanco, bancos);
                                txtReferencia.setEnabled(true);
                            }
                        }

                        public void onNothingSelected(AdapterView<?> parent) {
                            //showToast("Spinner1: unselected");
                        }
                    });

            ebImporte.setOnFocusChangeListener(
                    new View.OnFocusChangeListener() {
                        @Override
                        public void onFocusChange(View v, boolean hasFocus) {
                            if (!hasFocus){
                                if (ebImporte.getText().toString().length()>0){
                                    ebSaldoFin.setText(Generales.getFormatoDecimal( Generales.getRound(mPresenta.getTransProd().Saldo,2) - Generales.getFloat(((EditText)findViewById(R.id.ebImporte)).getText().toString(),2) ,2));
                                }
                            }
                        }
                    }
            );

            mPresenta = new CapturarCobranzaPedidoAnticipado(this, mAccion);
            try{
                if (getIntent().getSerializableExtra("parametros") != null)
                {
                    if (mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA))
                    {
                        HashMap<String, Object> oParam2 = null;
                        oParam2 = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
                        if (oParam2.containsKey("TransProdId")) {
                            mPresenta.setTransProdIds(oParam2.get("TransProdId").toString());
                        }else{
                            errorFinalizar = true;
                            mostrarError("No se pudo recuperar el TransProd");
                            return;
                        }
                    }
                }
                StringBuilder byRefError = new StringBuilder();
                String Folio = "";

                Folio= Folios.Obtener(Enumeradores.TiposModuloMovDetalle.PAGOS, byRefError);
                if (byRefError.length() >0){
                    mostrarAdvertencia(byRefError.toString());
                }
                byRefError = null;

                ((EditText)findViewById(R.id.ebImporte)).requestFocus();

                mPresenta.setFolio(Folio);
                mPresenta.iniciar();

            }catch(Exception ex){
                errorFinalizar = true;
                BDVend.rollback();
                mostrarError(ex.getMessage());
                return;
            }
        }
        catch(NullPointerException ex){
            errorFinalizar = true;
            mostrarError("Error de nulos");
        }
        catch (Exception e)
        {
            errorFinalizar = true;
            if (e.getCause() != null){
                mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            }else{
                mostrarError(e.getMessage());
            }

        }
    }

    @SuppressWarnings("deprecation")
    @Override
    protected Dialog onCreateDialog(int id)
    {
        Date fecha = null;
        fecha = Generales.getFechaActual();

        try
        {
            if (fecha != null)
                return new DatePickerDialog(this, mDateSetListener, fecha.getYear() + 1900, fecha.getMonth(), fecha.getDate());
            else
                return null;

        }
        catch (Exception e)
        {
            e.printStackTrace();
            return null;
        }

    }

    @SuppressWarnings("deprecation")
    @Override
    protected void onPrepareDialog(int id, Dialog dialog)
    {
        Date fecha = null;
        //ListView lista = (ListView) findViewById(R.id.lstPagos);
        //CobranzaDetAdapter adapter = (CobranzaDetAdapter) lista.getAdapter();
        //fecha = adapter.getDetalle().getFechaCheque();
        //if (fecha == null)
            fecha = Generales.getFechaActual();

        try
        {
            if (fecha != null)
            {
                ((DatePickerDialog) dialog).updateDate(fecha.getYear() + 1900, fecha.getMonth(), fecha.getDate());
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event)
    {
       switch (keyCode)
        {
            case KeyEvent.KEYCODE_BACK:
                if (!getImprimiendo()) {

                    try {
                        if (huboCambios) {
                            mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
                        } else {
                            BDVend.rollback();
                            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                            finalizar();
                        }
                    } catch (Exception ex) {
                        mostrarError(ex.getMessage());
                    }
                }else
                    return true;
        }
        return super.onKeyDown(keyCode, event);

    }



    private View.OnClickListener mContinuar = new View.OnClickListener()
    {

        @Override
        public void onClick(View v)
        {
            if (mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA))
            {
                Button btnContinuar = (Button) findViewById(R.id.btnContinuar);
                btnContinuar.setEnabled(false);
                try
                {
                    if (mPresenta.validarAbono())
                    {
                            if (mPresenta.grabarCobranza()) {
                                String motConfig = (String) ((MOTConfiguracion) Sesion.get(Sesion.Campo.MOTConfiguracion)).get("MensajeImpresion");
                                if (motConfig.equals("0"))
                                {
                                    setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                                    finalizar();
                                }else if(motConfig.equals("1")){
                                    mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
                                } else if (motConfig.equals("2")) {
                                    mostrarAdvertencia(Mensajes.get ("E0934"));
                                }
                            }
                    }
                    else
                    {
                        btnContinuar.setEnabled(true);
                    }
                }
                catch (NullPointerException eNull) {
                    mostrarError("Error de null al continuar");
                }catch (Exception e)
                {
                    mostrarError(e.getMessage());
                }
            }
            else
            {
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }
        }
    };

    private View.OnClickListener mSeleccionarFecha = new View.OnClickListener()
    {

        @SuppressWarnings("deprecation")
        @Override
        public void onClick(View v)
        {
            //if (tiposCP.contains(tipoPago))
                showDialog(DATE_DIALOG_ID);
        }
    };

    private DatePickerDialog.OnDateSetListener mDateSetListener = new DatePickerDialog.OnDateSetListener()
    {
        @SuppressLint("SimpleDateFormat")
        @SuppressWarnings("deprecation")
        public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            try
            {
                Calendar tmp = Calendar.getInstance();
                tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(new Date(year, monthOfYear, dayOfMonth)) + (new Date(year, monthOfYear, dayOfMonth)).getYear()));
                if (tmp.getTime().compareTo(Generales.getFechaActual()) < 0)
                { //la fecha seleccionada es menor a la de captura
                    return;
                }

                Date fecha = new Date(year - 1900, monthOfYear, dayOfMonth);
                ActualizaFecha(fecha);
            }
            catch (Exception ex)
            {
                mostrarError(ex.getMessage());
            }
        }
    };

    @Override
    public void iniciar()
    {
        // TODO Auto-generated method stub

    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data)
    {
        try
        {
            if (requestCode == REQUEST_ENABLE_BT)
            {
                if (resultCode == RESULT_OK)
                {
                    try
                    {
                        imprimiendo = true;
                        mPresenta.imprimirTicket();
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
                    mostrarError("No se pudo encender el BT");
                }

                return;
            }
        }
        catch (Exception ex)
        {
            mostrarError(ex.getMessage());
        }
    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje)
    {
        if (tipoMensaje == 1)
        {
            //Finalizar sin guardar cambios
            if (respuesta.equals(Enumeradores.RespuestaMsg.Si))
            {
                this.finish();
            }
        }else if (tipoMensaje == 8) {
            if (respuesta.equals(Enumeradores.RespuestaMsg.Si)) { // imprimir recibo
                // Imprimir ticket
                imprimiendo = true;
                try {
                    if (!bluetoothEncendido()) {
                        encenderBluetooth();
                    } else {
                        mPresenta.imprimirTicket();
                    }
                } catch (ControlError e) {
                    e.Mostrar(getVista());
                } catch (Exception e) {
                    getVista().mostrarError(e.getMessage());
                }
            } else {
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }
        }else if (tipoMensaje == 3) {
            if (respuesta == Enumeradores.RespuestaMsg.Si) {
                try {
                    BDVend.rollback();
                    setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                    finalizar();
                }catch(NullPointerException ex){
                    mostrarError("Error de null");
                }catch (Exception ex){
                    mostrarError(ex.getMessage());
                }
            }
        }else if (tipoMensaje == 0 && imprimiendo)
        {
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        }
        else if(tipoMensaje == 0 && errorFinalizar){
            finalizar();
        }
    }


   /* @Override
    public void capturarCobranzaDet(ArrayList<Integer> tiposCP)
    {
        EditText txtTotal = (EditText) findViewById(R.id.txtTotal);
        txtTotal.setText(String.format("$ %.2f", 0.0));
        txtTotal.setEnabled(false);

        this.tiposCP = tiposCP;
    }*/

    @Override
    public void setFolio(String folio)
    {
        EditText txtFolio = (EditText) findViewById(R.id.eFolio);
        txtFolio.setText(folio);
        txtFolio.setEnabled(false);
    }

    @Override
    public void setFecha(Date fecha)
    {
        EditText txtFecha = (EditText) findViewById(R.id.eFecha);
        txtFecha.setText(DateFormat.format("dd/MM/yyyy", fecha));
        txtFecha.setEnabled(false);
    }

    @Override
    public void setSaldoIni(float saldoini)
    {
        EditText txtSaldoIni = (EditText) findViewById(R.id.ebSaldoIni);
        txtSaldoIni.setText(String.format("$ %.2f", saldoini));
        txtSaldoIni.setEnabled(false);
    }

    @Override
    public void setSaldoFin(float saldofin)
    {
        EditText txtSaldoFin = (EditText) findViewById(R.id.ebSaldoFin);
        txtSaldoFin.setText(String.format("$ %.2f", saldofin));
        txtSaldoFin.setEnabled(false);
    }

   /* @Override
    public void setTotal(float total)
    {
        EditText txtTotal = (EditText) findViewById(R.id.ebTotalAbono);
        txtTotal.setText(String.format("$ %.2f", total));
        txtTotal.setEnabled(false);
    }

    @Override
    public float getTotal()
    {
        EditText txtTotal = (EditText) findViewById(R.id.ebTotalAbono);
        return Float.valueOf(txtTotal.getText().toString());
    }*/

    @Override
    public float getImporte()
    {
        EditText txtTotal = (EditText) findViewById(R.id.ebImporte);

        if (txtTotal.getText().toString().equals(""))
            return 0;

        return Float.valueOf(txtTotal.getText().toString());
    }

    @Override
    public short getTipoBanco()
    {
        if (spnTipoBanco.getAdapter() == null)
            return 0;
        return Short.valueOf (((Cobranza.VistaSpinner) spnTipoBanco.getItemAtPosition(spnTipoBanco.getSelectedItemPosition())).getId());
    }

    @Override
    public String getMonedaId()
    {
        Spinner spnMoneda = (Spinner) findViewById(R.id.spnMoneda);
        return ((Cobranza.VistaSpinner) spnMoneda.getItemAtPosition(spnMoneda.getSelectedItemPosition())).getId();
    }

    @Override
    public short getTipoPago()
    {
        return Short.valueOf (((Cobranza.VistaSpinner) spnTipoPago.getItemAtPosition(spnTipoPago.getSelectedItemPosition())).getId());
    }

    @Override
    public String getReferencia()
    {
        EditText ebReferencia = (EditText) findViewById(R.id.ebReferencia);
        return ebReferencia.getText().toString();
    }

    @Override
    public Date getFechaCheque()
    {
        return fechaCheque;
    }

    @Override
    public void setFormasPago(LinkedList<Cobranza.VistaSpinner> oPagos)
    {
        //pagos = oPagos;
        poblarSpinner((Spinner) findViewById(R.id.spnFormaPago), oPagos);
    }

    @Override
    public void setMonedas(LinkedList<Cobranza.VistaSpinner> oMonedas)
    {
        poblarSpinner((Spinner) findViewById(R.id.spnMoneda), oMonedas);
        if (oMonedas.size()<=1){
            ((Spinner) findViewById(R.id.spnMoneda)).setEnabled(false);
        }
    }

    @Override
    public void setBancos(LinkedList<Cobranza.VistaSpinner> oBancos)
    {
        bancos = oBancos;
    }

    private void poblarSpinner(Spinner control, LinkedList<Cobranza.VistaSpinner> oValores)
    {
        ArrayAdapter<Cobranza.VistaSpinner> adapter = new ArrayAdapter<Cobranza.VistaSpinner>(this, android.R.layout.simple_spinner_item, oValores);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
        control.setAdapter(adapter);
    }

    private void ActualizaFecha(Date fecha)
    {
        EditText txtFecha = (EditText) findViewById(R.id.ebFechaCheque);
        txtFecha.setText(DateFormat.format("dd/MM/yyyy", fecha));
        fechaCheque = fecha;
    }

    private Vista getVista()
    {
        return this;
    }

    @Override
    public void impresionFinalizada(boolean impresionExitosa, String mensajeError)
    {
        if (mensajeError.equals(""))
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
        else
            setResultado(Enumeradores.Resultados.RESULTADO_MAL, mensajeError);

        quitarProgreso();
        //No hay un moduloMovDetalleClave en sesion para manejar esto, asi que se deja siempre ciclico, hasta que alguna cliente lo pida distinto
        //try {
            //if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
                //if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).equals("0")) {
                    mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
                //} else {
                //    finalizar();
                //}
            //} else {
            //    mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
            //}
        //}catch(Exception ex){
        //    mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
        //}
    }
}
