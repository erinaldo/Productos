package com.amesol.routelite.vistas;

import android.app.SearchManager;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.os.PersistableBundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.KeyEvent;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.CapturarGastos;
import com.amesol.routelite.presentadores.interfaces.ICapturaGastos;
import com.amesol.routelite.presentadores.interfaces.ISeleccionGastos;
import com.amesol.routelite.utilerias.Generales;
import com.itextpdf.awt.geom.CubicCurve2D;
import com.itextpdf.awt.geom.Line2D;

import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;

/**
 * Created by ldelatorre on 30/05/2017.
 */
public class CapturaGastos extends Vista implements ICapturaGastos {

    private CapturarGastos mPresenta;
    private TextView lblGeneral;
    private Button btnContinuar;
    private EditText txtFecha;
    private Spinner sConcepto;
    private EditText txtFolio;
    private Spinner sFormaPago;
    private EditText txtComentarios;
    private EditText txtImporte;
    private EditText txtImpuesto;
    private EditText txtTotalImpuesto;
    private EditText txtTotal;
    private boolean modificar;
    private Date fechaIdModificar;



    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        // TODO Auto-generated method stub
        super.onCreate(savedInstanceState);
        setContentView(R.layout.captura_gastos);

        setTitulo(Mensajes.get("XGatosVendedor"));
        mPresenta = new CapturarGastos(this);

        this.ponerTitulos();
        this.llenarSpinners(sConcepto,"GASTIPO");
        this.llenarSpinners(sFormaPago,"FPAGOGV");

        txtFecha.setText(((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);
        txtFecha.setEnabled(false);
        txtTotalImpuesto.setEnabled(false);
        txtTotal.setEnabled(false);

        btnContinuar = (Button) findViewById(R.id.btnContinuarGastos);
        btnContinuar.setText(Mensajes.get("XContinuar"));
        this.eventoListenerBotonContinuar();
        this.editextEventoListenerCambio();

        if (getIntent().getExtras() != null) {
            modificar = true;
            HashMap<String, Object> hm = (HashMap<String, Object>) getIntent().getExtras().get("parametros");
            mPresenta.llenarCampos(((Date) hm.get("Fecha")));
            fechaIdModificar = ((Date) hm.get("Fecha"));
            //Toast.makeText(this,"Modificar "+hm.get("Fecha"),Toast.LENGTH_LONG).show();
        }

        if(modificar){
            btnContinuar.setText(Mensajes.get("XModificar"));
        }


    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {

    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
            if(tipoMensaje == 1){
                if(respuesta == Enumeradores.RespuestaMsg.Si){
                    ISetDatos datos = null;
                    try
                    {
                        datos = Consultas2.ConsultarGastos.obtenerGastos();
                    }
                    catch (Exception e)
                    {
                        mostrarError(e.getMessage());
                    }

                    if(datos != null){
                        if(datos.getCount() <= 0){
                            finalizar();
                        }else{
                            iniciarActividad(ISeleccionGastos.class);
                            finalizar(); //con este metodo me regreso al menu anterior
                        }
                    }
                }
            }
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event)
    {
        switch (keyCode)
        {
            case KeyEvent.KEYCODE_BACK: //cacho el valor del "regreso"

                mostrarPreguntaSiNo(Mensajes.get("BP0002"), 1);

                break;

        }
        // TODO Auto-generated method stub
        return super.onKeyDown(keyCode, event);
    }

    public void ponerTitulos(){
        String ruta = Mensajes.get("XRuta")+": "+((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Descripcion;
        String diaTrabajo = Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave;

        lblGeneral = (TextView) findViewById(R.id.txtRutaGastos);
        lblGeneral.setText(ruta);
        lblGeneral = (TextView) findViewById(R.id.txtDiaTrabajoGastos);
        lblGeneral.setText(diaTrabajo);
        lblGeneral = (TextView) findViewById(R.id.lblFechaGatos);
        lblGeneral.setText(Mensajes.get("XFecha"));
        lblGeneral = (TextView) findViewById(R.id.lblConceptoGastos);
        lblGeneral.setText(Mensajes.get("XConcepto"));
        lblGeneral = (TextView) findViewById(R.id.lblFolioGastos);
        lblGeneral.setText(Mensajes.get("XFolio"));
        lblGeneral = (TextView) findViewById(R.id.lblFomasPagoGastos);
        lblGeneral.setText(Mensajes.get("XFormaPago"));
        lblGeneral = (TextView) findViewById(R.id.lblComentariosGastos);
        lblGeneral.setText(Mensajes.get("XComentarios"));
        lblGeneral = (TextView) findViewById(R.id.lblImporteGastos);
        lblGeneral.setText(Mensajes.get("XImporte"));
        lblGeneral = (TextView) findViewById(R.id.lblImpuestoGastos);
        lblGeneral.setText(Mensajes.get("XImpuesto"));
        lblGeneral = (TextView) findViewById(R.id.lblTotalGastos);
        lblGeneral.setText(Mensajes.get("XTotal"));

        txtFecha = (EditText) findViewById(R.id.txtFechaGastos);
        sConcepto = (Spinner) findViewById(R.id.sConceptoGastos);
        txtFolio = (EditText) findViewById(R.id.txtFolioGastos);
        sFormaPago = (Spinner) findViewById(R.id.sFomasPagoGastos);
        txtComentarios = (EditText) findViewById(R.id.txtComentariosGastos);
        txtImporte = (EditText) findViewById(R.id.txtImporteGastos);
        txtImpuesto = (EditText) findViewById(R.id.txtImpuestoGastos);
        txtTotalImpuesto = (EditText) findViewById(R.id.txtTotalImpuetoGastos);
        txtTotal = (EditText) findViewById(R.id.txtTotalGastos);

    }

    public void llenarSpinners(Spinner spin, String varCodigo){
        try{
            ISetDatos motivos = Consultas.ConsultasValorReferencia.obtenerValoresReferencia(varCodigo,"");
            Cursor valores = (Cursor) motivos.getOriginal();
            startManagingCursor(valores);
            if (motivos.getCount() <= 1) //si no hay motivos, mostrar deshabilitado
                spin.setEnabled(false);
            else
            {
                SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, valores,
                        new String[]
                                { SearchManager.SUGGEST_COLUMN_TEXT_1 },
                        new int[]
                                { android.R.id.text1 });
                adapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
                spin.setAdapter(adapter);
            }
        }catch (Exception ex)
        {
            mostrarError(ex.getMessage());
        }

    }

    public void eventoListenerBotonContinuar(){

        btnContinuar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String fecha = txtFecha.getText().toString();
                int concepto = ((int) sConcepto.getSelectedItemId());
                String folio = txtFolio.getText().toString();
                int formaPago = ((int) sFormaPago.getSelectedItemId());
                String comentarios = txtComentarios.getText().toString();
                float importe = 0;
                if(!txtImporte.getText().toString().isEmpty() || !txtImporte.getText().toString().equals("")){
                    if(!txtImporte.getText().toString().equals(".")){
                        importe = Float.parseFloat(txtImporte.getText().toString());
                    }
                }
                float impuesto = 0;
                if(!txtImpuesto.getText().toString().isEmpty() || !txtImpuesto.getText().toString().equals("")){
                    if(!txtImpuesto.getText().toString().equals(".")) {
                        impuesto = Float.parseFloat(txtImpuesto.getText().toString());
                    }
                }
                float impuestoTotal = 0;
                if(!txtTotalImpuesto.getText().toString().isEmpty() || !txtTotalImpuesto.getText().toString().equals("")){
                    if(!txtTotalImpuesto.getText().toString().equals(".")) {
                        impuestoTotal = Float.parseFloat(txtTotalImpuesto.getText().toString());
                    }
                }
                float total = 0;
                if(!txtTotal.getText().toString().isEmpty() || !txtTotal.getText().toString().equals("")){
                    if(!txtTotal.getText().toString().equals(".")) {
                        total = Float.parseFloat(txtTotal.getText().toString());
                    }
                }

                String mensaje = mPresenta.validarGastos(fecha,concepto,folio,formaPago,importe,impuesto,impuestoTotal,total);
                if(!mensaje.equals("")){
                    mostrarError(Mensajes.get("BE0001").replace("$0$", mensaje));
                }else{
                    if(importe == 0){
                        mostrarError(Mensajes.get("E0041"));
                    }else {
                        Date fechaCaptura = ((Dia) Sesion.get(Sesion.Campo.DiaActual)).FechaCaptura;
                        String diaClave = ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave;
                        String vendedorId = ((Vendedor) Sesion.get(Sesion.Campo.VendedorActual)).VendedorId;
                        try{
                            if(modificar){
                                mPresenta.modificarGastos(fechaIdModificar,vendedorId,diaClave,concepto,folio,formaPago,comentarios,importe,impuesto,impuestoTotal,total);
                            }else{
                                mPresenta.guardarGastos(fechaCaptura,vendedorId,diaClave,concepto,folio,formaPago,comentarios,importe,impuesto,impuestoTotal,total);
                            }

                        }catch (Exception e){
                            mostrarError(e.getMessage());
                        }

                        //Toast.makeText(CapturaGastos.this,"Se guardaron los datos", Toast.LENGTH_LONG).show();
                    }
                }
            }
        });
    }

    public void editextEventoListenerCambio(){

        txtImpuesto.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {


            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {

                float importe = 0;
                if(!txtImporte.getText().toString().isEmpty() || !txtImporte.getText().toString().equals("")){
                    if(!txtImporte.getText().toString().equals(".")){
                        importe = Float.parseFloat(txtImporte.getText().toString());
                    }
                }

                float total = 0;
                if(!txtTotal.getText().toString().isEmpty() || !txtTotal.getText().toString().equals("")){
                    if(!txtTotal.getText().toString().equals(".")) {
                        total = Float.parseFloat(txtTotal.getText().toString());
                    }
                }

                if(importe > 0){
                    float impuesto = 0;
                    if(!s.toString().isEmpty()){
                        impuesto = Float.parseFloat(s.toString());
                    }

                    float totalImpuesto = (importe * impuesto) / 100;
                    txtTotalImpuesto.setText(Generales.getFormatoDecimal(totalImpuesto,"###0.00"));

                    total = importe + totalImpuesto;
                    txtTotal.setText(Generales.getFormatoDecimal(total,"###0.00"));


                }
            }
        });

        txtImporte.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {
                float impuesto = 0;
                if(!txtImpuesto.getText().toString().isEmpty() || !txtImpuesto.getText().toString().equals("")){
                    if(!txtImpuesto.getText().toString().equals(".")){
                        impuesto = Float.parseFloat(txtImpuesto.getText().toString());
                    }
                }

                if(impuesto > 0){
                    float importe = 0;
                    float total = 0;
                    if(!s.toString().isEmpty()){
                        importe = Float.parseFloat(s.toString());
                    }

                    float totalImpuesto = (importe * impuesto) / 100;
                    txtTotalImpuesto.setText(Generales.getFormatoDecimal(totalImpuesto,"###0.00"));

                    total = importe + totalImpuesto;
                    txtTotal.setText(Generales.getFormatoDecimal(total,"###0.00"));
                }
            }
        });


       /* txtTotal.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {

                if(!hasFocus) {

                    float impuesto = 0;
                    if (!txtImpuesto.getText().toString().isEmpty() || !txtImpuesto.getText().toString().equals("")) {
                        if (!txtImpuesto.getText().toString().equals(".")) {
                            impuesto = Float.parseFloat("1." + txtImpuesto.getText().toString());
                        }
                    }

                    float importe = 0;

                    if (impuesto > 0) {
                        float total = 0;
                        if (!txtTotal.getText().toString().isEmpty() || !txtTotal.getText().toString().equals("")) {
                            if (!txtTotal.getText().toString().equals(".")) {
                                total = Float.parseFloat(txtTotal.getText().toString());
                            }
                        }

                        importe = total / impuesto;
                        float totalImpuesto = total - importe;
                        txtImporte.setText(Generales.getFormatoDecimal(importe, "###0.00"));
                        txtTotalImpuesto.setText(Generales.getFormatoDecimal(totalImpuesto, "###0.00"));
                    }
                }


            }
        });*/

    }

    @Override
    public void guardadoExito() {
        finalizar();
    }

    @Override
    public void llenarCampos(String fecha, int concepto, String folio, int formaPago, String comentarios, double importe, double impuesto, double totalImpuesto, double total) {
        txtFecha.setText(fecha);
        txtFolio.setText(folio);
        txtComentarios.setText(comentarios);
        txtImporte.setText(Generales.getFormatoDecimal(importe, "###0.00"));
        txtImpuesto.setText(String.valueOf(impuesto));
        txtTotalImpuesto.setText(Generales.getFormatoDecimal(totalImpuesto, "###0.00"));
        txtTotal.setText(Generales.getFormatoDecimal(total, "###0.00"));
        sConcepto.setSelection(concepto);
        sFormaPago.setSelection(formaPago);
    }


}
