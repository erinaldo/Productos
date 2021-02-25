package com.amesol.routelite.vistas;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.SearchManager;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.text.InputType;
import android.view.KeyEvent;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;

import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.MERDetalle;
import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.CapturarMercadeo;
import com.amesol.routelite.presentadores.interfaces.ICapturaMercadeo;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;

public class CapturaMercadeo extends Vista implements ICapturaMercadeo {
    String mAccion;
    CapturarMercadeo mPresenta;

    EditText txtProducto;
    EditText txtMarca;
    EditText txtPresentacion;
    EditText txtTipo;
    Spinner spnProducto;
    Spinner spnMarca;
    Spinner spnPresentacion;
    Spinner spnTipo;

    Boolean imprimiendo = false;
    Boolean modificando = false;
    String sMRDId = "";

    static final int DATE_DIALOG_VENCOFERTA = 999;
    Date fechaVigenciaOferta;

    @SuppressWarnings("unchecked")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.captura_mercadeo);
        deshabilitarBarra(true);

        mAccion = getIntent().getAction();

        if (mAccion != null && mAccion.equals(Enumeradores.Acciones.ACCION_MODIFICAR_MERDETALLE)){
            HashMap<String, Object> oParametros = null;
            if (getIntent().getSerializableExtra("parametros") != null)
            {
                oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
                if (oParametros != null)
                {
                    try {
                        if (oParametros.containsKey("MRDId") && !oParametros.get("MRDId").equals("")) {
                            modificando = true;
                            sMRDId = oParametros.get("MRDId").toString();
                        }
                    }catch (Exception ex){
                        mostrarError("Error al recuperar parámetros");
                    }
                }
            }
        }

        TextView texto = (TextView) findViewById(R.id.lblProducto);
        texto.setText(Mensajes.get("XProducto"));

        texto = (TextView) findViewById(R.id.lblMarca);
        texto.setText(Mensajes.get("XMarca") + ":");

        texto = (TextView) findViewById(R.id.lblPresentacion);
        texto.setText(Mensajes.get("MRDPresentacion") + ":");

        texto = (TextView) findViewById(R.id.lblTipo);
        texto.setText(Mensajes.get("XTipo") + ":");

        texto = (TextView) findViewById(R.id.lblPrecio);
        texto.setText(Mensajes.get("XPrecio") + ":");

        texto = (TextView) findViewById(R.id.lblPrecioOferta);
        texto.setText(Mensajes.get("XPrecioOferta") + ":");

        texto = (TextView) findViewById(R.id.lblCantidad);
        texto.setText(Mensajes.get("XCantidad") + ":");

        texto = (TextView) findViewById(R.id.lblVigenciaOferta);
        texto.setText(Mensajes.get("XVigenciaOferta") + ":");

        texto = (TextView) findViewById(R.id.lblNotas);
        texto.setText(Mensajes.get("XNotas") + ":");

        EditText et = (EditText) findViewById(R.id.txtCantidad);
        et.setInputType(InputType.TYPE_CLASS_NUMBER);

        Button btnVigenciaOferta = (Button) findViewById(R.id.btnVigenciaOferta);
        Calendar cal = Calendar.getInstance();
        cal.setTime(((Dia) Sesion.get(Sesion.Campo.DiaActual)).FechaCaptura);
        //fechaVigenciaOferta = cal.getTime();
        //btnVigenciaOferta.setText(new SimpleDateFormat("dd/MMM/yyyy").format(cal.getTime()));
        fechaVigenciaOferta = null;
        btnVigenciaOferta.setText("");
        btnVigenciaOferta.setOnClickListener(mFechaVigenciaOferta);

        Button boton = (Button) findViewById(R.id.btnContinuar);
        boton.setText(Mensajes.get("XContinuar"));
        boton.setOnClickListener(mContinuar);

        txtProducto = (EditText) findViewById(R.id.txtProducto);
        txtMarca = (EditText) findViewById(R.id.txtMarca);
        txtPresentacion = (EditText) findViewById(R.id.txtPresentacion);
        txtTipo = (EditText) findViewById(R.id.txtTipo);

        cargarMercadeoProducto();
        cargarMercadeoMarca();
        cargarPresentaciones();
        cargarTipos();
        if (modificando){
            spnProducto.setEnabled(false);
            spnMarca.setEnabled(false);
            spnPresentacion.setEnabled(false);
            spnTipo.setEnabled(false);
            txtProducto.setEnabled(false);
            txtMarca.setEnabled(false);
            txtPresentacion.setEnabled(false);
            txtTipo.setEnabled(false);
        }

        mPresenta = new CapturarMercadeo(this, mAccion);
        mPresenta.iniciar();

    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {

    }

    @Override
    public void iniciar()
    {

    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
        if (tipoMensaje == 10 && respuesta == Enumeradores.RespuestaMsg.Si){
            try {
                BDVend.rollback();
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }catch(Exception ex){
                if (ex!=null && ex.getMessage()!= null)
                    mostrarError(ex.getMessage());
            }

        }
    }

    @Override
    public void setCliente(String cliente)
    {
        TextView texto = (TextView) findViewById(R.id.lblCliente);
        texto.setText(Mensajes.get("XCliente") + ": " + cliente);
    }

    @Override
    public void setRuta(String ruta)
    {
        TextView texto = (TextView) findViewById(R.id.lblRuta);
        texto.setText(Mensajes.get("XRuta") + ": " + ruta);
    }

    @Override
    public void setDia(String dia)
    {
        TextView texto = (TextView) findViewById(R.id.lblDia);
        texto.setText(Mensajes.get("XDiaTrabajo") + ": " + dia);
    }

    @Override
    public String getMPRId() {
        String sMPRId = null;
        if (spnProducto.getSelectedItem() != null) {
            Cursor c = (Cursor) ((SimpleCursorAdapter) spnProducto.getAdapter()).getItem(spnProducto.getSelectedItemPosition());
            sMPRId= c.getString(c.getColumnIndex("_id"));
        }
        return sMPRId;
    }

    @Override
    public void setMPRId(String pMPRId) {
        SimpleCursorAdapter adapter = (SimpleCursorAdapter) spnProducto.getAdapter();
        for (int i = 0; i < adapter.getCount(); i++) {
            Cursor c = (Cursor) adapter.getItem(i);
            if (c.getString(c.getColumnIndex("_id")).equals(pMPRId)) {
                spnProducto.setSelection(c.getPosition());
                break;
            }
        }
    }

    @Override
    public String getProducto() {
        return txtProducto.getText().toString();
    }

    @Override
    public String getMEMId() {
        String sMEMId = null;
        if (spnMarca.getSelectedItem() != null) {
            Cursor c = (Cursor) ((SimpleCursorAdapter) spnMarca.getAdapter()).getItem(spnMarca.getSelectedItemPosition());
            sMEMId= c.getString(c.getColumnIndex("_id"));
        }
        return sMEMId;
    }

    @Override
    public void setMEMId(String pMEMId) {
        SimpleCursorAdapter adapter = (SimpleCursorAdapter) spnMarca.getAdapter();
        for (int i = 0; i < adapter.getCount(); i++) {
            Cursor c = (Cursor) adapter.getItem(i);
            if (c.getString(c.getColumnIndex("_id")).equals(pMEMId)) {
                spnMarca.setSelection(c.getPosition());
                break;
            }
        }
    }

    @Override
    public String getMarca() {
        return txtMarca.getText().toString();
    }

    @Override
    public short getPresentacion() {
        return (short) spnPresentacion.getSelectedItemId();
    }

    @Override
    public void setPresentacion(String pPresentacion) {
        SimpleCursorAdapter adapter = (SimpleCursorAdapter) spnPresentacion.getAdapter();
        for (int i = 0; i < adapter.getCount(); i++) {
            Cursor c = (Cursor) adapter.getItem(i);
            if (c.getString(2).equals(pPresentacion)) {
                spnPresentacion.setSelection(c.getPosition());
                return;
            }
        }
        txtPresentacion.setText(pPresentacion);
    }

    @Override
    public String getPresentacion2() {
        return txtPresentacion.getText().toString();
    }

    @Override
    public short getTipo() {
        return (short) spnTipo.getSelectedItemId();
    }

    @Override
    public void setTipo(String pTipo) {
        SimpleCursorAdapter adapter = (SimpleCursorAdapter) spnTipo.getAdapter();
        for (int i = 0; i < adapter.getCount(); i++) {
            Cursor c = (Cursor) adapter.getItem(i);
            if (c.getString(2).equals(pTipo)) {
                spnTipo.setSelection(c.getPosition());
                return;
            }
        }
        txtTipo.setText(pTipo);
    }

    @Override
    public String getTipo2() {
        return txtTipo.getText().toString();
    }

    @Override
    public Float getPrecio() {
        EditText et = (EditText) findViewById(R.id.txtPrecio);
        if (et.getText().toString().equals("")){
            return null;
        }
        return Float.parseFloat(et.getText().toString());
    }

    @Override
    public void setPrecio(Float pPrecio) {
        EditText et = (EditText) findViewById(R.id.txtPrecio);
        et.setText(Generales.getFormatoDecimal(pPrecio,2));
    }

    @Override
    public Float getPrecioOferta() {
        EditText et = (EditText) findViewById(R.id.txtPrecioOferta);
        if (et.getText().toString().equals("")){
            return null;
        }
        return Float.parseFloat(et.getText().toString());
    }

    @Override
    public void setPrecioOferta(Float pPrecioOferta) {
        EditText et = (EditText) findViewById(R.id.txtPrecioOferta);
        et.setText(Generales.getFormatoDecimal(pPrecioOferta, 2));
    }

    @Override
    public Integer getCantidad() {
        EditText et = (EditText) findViewById(R.id.txtCantidad);
        if (et.getText().toString().equals("")){
            return null;
        }
        return Integer.parseInt(et.getText().toString());
    }

    @Override
    public void setCantidad(Integer pCantidad) {
        EditText et = (EditText) findViewById(R.id.txtCantidad);
        et.setText(pCantidad.toString());
    }

    @Override
    public Date getVigenciaOferta() {
        Button btnVigenciaOferta = (Button) findViewById(R.id.btnVigenciaOferta);
        if (btnVigenciaOferta.getText().toString().equals("")){
            return null;
        }
        return fechaVigenciaOferta;
    }

    @Override
    public void setVigenciaOferta(Date pVigenciaOferta) {
        Button btn = (Button) findViewById(R.id.btnVigenciaOferta);
        btn.setText(Generales.getFormatoFecha(pVigenciaOferta, "dd/MMM/yyyy"));
    }

    @Override
    public String getNotas() {
        EditText et = (EditText) findViewById(R.id.txtNotas);
        if (et.getText().toString().trim().length()<=0){
            return null;
        }
        return et.getText().toString();
    }

    @Override
    public void setNotas(String pNotas) {
        EditText et = (EditText) findViewById(R.id.txtNotas);
        et.setText(pNotas);
    }

    @Override
    public String getMRDId() {
        return sMRDId;
    }

    @Override
    public void setFocus(String nombreCampo) {
        switch (nombreCampo.toUpperCase()){
            case "PRODUCTO":
                txtProducto.requestFocus();
                break;
            case "MARCA":
                txtMarca.requestFocus();
                break;
            case "PRESENTACION":
                txtPresentacion.requestFocus();
                break;
            case "TIPO":
                txtTipo.requestFocus();
                break;
            case "PRECIO":
                EditText txtPrecio = (EditText) findViewById(R.id.txtPrecio);
                txtPrecio.requestFocus();
                break;
            case "CANTIDAD":
                EditText txtCantidad = (EditText) findViewById(R.id.txtCantidad);
                txtCantidad.requestFocus();
                break;
        }
    }


    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event)
    {
        try {
            switch (keyCode) {
                case KeyEvent.KEYCODE_BACK:
                    if (mPresenta.huboCambios(modificando)){
                        mostrarPreguntaSiNo(Mensajes.get("BP0002"), 10);
                    }else {
                        setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                        finalizar();
                        return true;
                    }
            }
        }catch (Exception ex){
            mostrarError(ex.getMessage());
        }
        return super.onKeyDown(keyCode, event);
    }

    private void cargarMercadeoProducto() {
        try {
            ISetDatos sdMPR = Consultas.ConsultasMercadeo.spinnerMercadeoProducto();
            spnProducto =  (Spinner)findViewById(R.id.spProducto);
            SimpleCursorAdapter adapterMPR = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, (Cursor) sdMPR.getOriginal(), new String[]
                    {"Producto"}, new int[]
                    {android.R.id.text1});
            adapterMPR.setDropDownViewResource(android.R.layout.simple_spinner_item);
            spnProducto.setAdapter(adapterMPR);

            if (spnProducto.getCount() > 0) {
                spnProducto.setSelection(0, true);
            }
            spnProducto.setOnItemSelectedListener(mProducto);

        }catch (Exception ex){
            if (ex != null && ex.getMessage()!= null) {
                mostrarError(ex.getMessage());
            }
        }
    }
    private void cargarMercadeoMarca() {
        try {
            ISetDatos sdMEM = Consultas.ConsultasMercadeo.spinnerMercadeoMarca();
            spnMarca = (Spinner) findViewById(R.id.spMarca);
            SimpleCursorAdapter adapterMEM = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, (Cursor) sdMEM.getOriginal(), new String[]
                    {"Marca"}, new int[]
                    {android.R.id.text1});
            adapterMEM.setDropDownViewResource(android.R.layout.simple_spinner_item);
            spnMarca.setAdapter(adapterMEM);

            if (spnMarca.getCount() > 0)
                spnMarca.setSelection(0, true);

            spnMarca.setOnItemSelectedListener(mMarca);
        }catch (Exception ex){
            if (ex != null && ex.getMessage()!= null) {
                mostrarError(ex.getMessage());
            }
        }
    }
    private void cargarPresentaciones() {
        try {
            ISetDatos sdPRES = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("MRDPRES", "");
            spnPresentacion = (Spinner) findViewById(R.id.spPresentacion);
            SimpleCursorAdapter adapterMEM = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, (Cursor) sdPRES.getOriginal(), new String[]
                    {SearchManager.SUGGEST_COLUMN_TEXT_1}, new int[]
                    {android.R.id.text1});
            adapterMEM.setDropDownViewResource(android.R.layout.simple_spinner_item);
            spnPresentacion.setAdapter(adapterMEM);

            if (spnPresentacion.getCount() > 0)
                spnPresentacion.setSelection(0, true);

            spnPresentacion.setOnItemSelectedListener(mPresentaciones);
        }catch (Exception ex){
            if (ex != null && ex.getMessage()!= null) {
                mostrarError(ex.getMessage());
            }
        }
    }

    private void cargarTipos() {
        try {
            ISetDatos sdPRES = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("MRDTIPO", "");
            spnTipo = (Spinner) findViewById(R.id.spTipo);
            SimpleCursorAdapter adapterMEM = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, (Cursor) sdPRES.getOriginal(), new String[]
                    {SearchManager.SUGGEST_COLUMN_TEXT_1}, new int[]
                    {android.R.id.text1});
            adapterMEM.setDropDownViewResource(android.R.layout.simple_spinner_item);
            spnTipo.setAdapter(adapterMEM);

            if (spnTipo.getCount() > 0)
                spnTipo.setSelection(0, true);

            spnTipo.setOnItemSelectedListener(mTipos);
        }catch (Exception ex){
            if (ex != null && ex.getMessage()!= null) {
                mostrarError(ex.getMessage());
            }
        }
    }

    private Spinner.OnItemSelectedListener mProducto = new Spinner.OnItemSelectedListener() {

        @Override
        public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
            Cursor item = (Cursor) arg0.getItemAtPosition(arg2);
            if (item.getString(item.getColumnIndex("_id")).equals("0")) { //Si se selecciona Ninguno
                txtProducto.setEnabled(true);
            }else{
                txtProducto.setEnabled(false);
            }
        }

        @Override
        public void onNothingSelected(AdapterView<?> parent) {

        }
    };

    private Spinner.OnItemSelectedListener mMarca = new Spinner.OnItemSelectedListener() {

        @Override
        public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
            Cursor item = (Cursor) arg0.getItemAtPosition(arg2);
            if (item.getString(item.getColumnIndex("_id")).equals("0")) { //Si se selecciona Ninguno
                txtMarca.setEnabled(true);
            }else{
                txtMarca.setEnabled(false);
            }
        }

        @Override
        public void onNothingSelected(AdapterView<?> parent) {

        }
    };

    private Spinner.OnItemSelectedListener mPresentaciones = new Spinner.OnItemSelectedListener() {

        @Override
        public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
            Cursor item = (Cursor) arg0.getItemAtPosition(arg2);
            if (item.getString(item.getColumnIndex("_id")).equals("0")) { //Si se selecciona Ninguno
                txtPresentacion.setEnabled(true);
            }else{
                txtPresentacion.setEnabled(false);
            }
        }

        @Override
        public void onNothingSelected(AdapterView<?> parent) {

        }
    };

    private Spinner.OnItemSelectedListener mTipos = new Spinner.OnItemSelectedListener() {

        @Override
        public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
            Cursor item = (Cursor) arg0.getItemAtPosition(arg2);
            if (item.getString(item.getColumnIndex("_id")).equals("0")) { //Si se selecciona Ninguno
                txtTipo.setEnabled(true);
            }else{
                txtTipo.setEnabled(false);
            }
        }

        @Override
        public void onNothingSelected(AdapterView<?> parent) {

        }
    };

    private View.OnClickListener mFechaVigenciaOferta = new View.OnClickListener() {
        @SuppressWarnings("deprecation")
        @Override
        public void onClick(View v) {
            showDialog(DATE_DIALOG_VENCOFERTA);
        }
    };

    @SuppressWarnings("deprecation")
    @Override
    protected Dialog onCreateDialog(int id) {
        if (fechaVigenciaOferta == null){
            fechaVigenciaOferta = Generales.getFechaActual();
        }
        int anio2 = fechaVigenciaOferta.getYear() + 1900;
        int mes2 = fechaVigenciaOferta.getMonth();
        int dia2 = fechaVigenciaOferta.getDate();
        return new DatePickerDialog(this, mVigenciaOfertaListener, anio2, mes2, dia2);
    }

    @SuppressWarnings("deprecation")
    @Override
    protected void onPrepareDialog(int id, Dialog dialog) {
        if (fechaVigenciaOferta == null){
            fechaVigenciaOferta = Generales.getFechaActual();
        }
        int anio2 = fechaVigenciaOferta.getYear() + 1900;
        int mes2 = fechaVigenciaOferta.getMonth();
        int dia2 = fechaVigenciaOferta.getDate();
        ((DatePickerDialog) dialog).updateDate(anio2, mes2, dia2);
    }

    private DatePickerDialog.OnDateSetListener mVigenciaOfertaListener = new DatePickerDialog.OnDateSetListener()
    {

        // when dialog box is closed, below method will be called.
        @SuppressWarnings("deprecation")
        @Override
        public void onDateSet(DatePicker view, int selectedYear, int selectedMonth, int selectedDay) {
            try {
                Calendar tmp = Calendar.getInstance();
                tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(new SimpleDateFormat("dd/MM/").format(new Date(selectedYear, selectedMonth, selectedDay)) + (new Date(selectedYear, selectedMonth, selectedDay)).getYear()));

                fechaVigenciaOferta = tmp.getTime();
                Button btnVigenciaOferta = (Button) findViewById(R.id.btnVigenciaOferta);
                btnVigenciaOferta.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fechaVigenciaOferta));

            } catch (Exception ex) {
                mostrarError(ex.getMessage());
            }
        }

    };
    private View.OnClickListener mContinuar = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            try {
                if (mPresenta.grabarMercadeo()) {
                    setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                    finalizar();
                }
            }catch(Exception ex){
                if (ex != null && ex.getMessage() != null) {
                    mostrarError(ex.getMessage());
                }else{
                    mostrarError("Error al guardar el Mercadeo");
                }
            }
        }
    };


}
