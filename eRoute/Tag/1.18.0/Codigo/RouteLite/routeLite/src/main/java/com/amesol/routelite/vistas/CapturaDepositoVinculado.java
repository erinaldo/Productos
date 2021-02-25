package com.amesol.routelite.vistas;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Color;
import android.os.Bundle;
import android.text.Editable;
import android.text.Html;
import android.text.Layout;
import android.text.TextWatcher;
import android.util.Log;
import android.view.ContextMenu;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.ScrollView;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.NumberPicker;
import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.AbdDep;
import com.amesol.routelite.datos.Deposito;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.SaldoDeposito;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.CapturarActivo;
import com.amesol.routelite.presentadores.act.CapturarDeposito;
import com.amesol.routelite.presentadores.act.CapturarDepositoVinculado;
import com.amesol.routelite.presentadores.interfaces.ICapturaDepositoVinculado;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;


import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.List;

public class CapturaDepositoVinculado extends Vista implements ICapturaDepositoVinculado {
    private String mAccion;

    private Spinner spBanco = null;
    private EditText txtFicha = null;
    private boolean huboCambios = false;
    private EditText mTxtDeposito = null;
    private EditText mTxtAdicional = null;
    private EditText mTxtTotalDeposito = null;
    private ListView mLvDeposito = null;

    private CapturarDepositoVinculado mPresenta;

    private boolean soloLectura = false;
    private boolean hayConvenios = false;
    private ISetDatos sdConvenios;
    private Integer iTipoReferenciaActual = 0;
    ImageButton btnAgregar;
    ArrayList<ABNDetalle> oAbd = null;
    ArrayList<SaldoDeposito> oSaldos = null;
    private float totalAbonos=0;
    private float totalSaldos=0;
    private float totalSeleccionado = 0;
    private float totalAdicional = 0;
    private float totalDeposito = 0;
    private boolean capturaAdicional = false;
    boolean bIniciando = false;

    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.captura_deposito_vinculado);
        //		deshabilitarBarra(true);
        try
        {
            bIniciando = true;
            sdConvenios = Consultas.ConsultarConvenios.obtenerConvenios();
            if (sdConvenios.getCount()>0){
                hayConvenios = true;
            }
            mAccion = getIntent().getAction();
            lblTitle.setText("Depositos");

            mPresenta = new CapturarDepositoVinculado(this, mAccion);

            if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("RegistrarDepositoAdicional"))
                capturaAdicional = ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("RegistrarDepositoAdicional").toString().equals("1");

            TextView mTexto = (TextView) findViewById(R.id.lblRuta);
            mTexto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Descripcion);
            mTexto = (TextView) findViewById(R.id.lblDia);
            mTexto.setText(((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);//Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);
            mTexto = (TextView) findViewById(R.id.lblFechaDeposito);
            mTexto.setText(Mensajes.get("XFechaDeposito"));
            mTexto = (TextView) findViewById(R.id.lblBanco);
            if (hayConvenios){
                mTexto.setText(Mensajes.get("DEPConvenio"));
            }else{
                mTexto.setText(Mensajes.get("XBanco"));
            }

            mTexto = (TextView) findViewById(R.id.lblFicha);
            mTexto.setText(Mensajes.get("XFichaCheque"));
            if (capturaAdicional){
                mTexto = (TextView) findViewById(R.id.lblDeposito);
                mTexto.setText(Mensajes.get("XDeposito"));
                mTexto = (TextView) findViewById(R.id.lblDepositoAdicional);
                mTexto.setText(Mensajes.get("XDepositoAdicional"));
                mTexto = (TextView) findViewById(R.id.lblTotalDeposito);
                mTexto.setText(Mensajes.get("XTotalDeposito"));
            }else{
                LinearLayout layDeposito = (LinearLayout)findViewById(R.id.layDeposito);
                layDeposito.setVisibility(View.GONE);
                LinearLayout layDepositoAdicional = (LinearLayout)findViewById(R.id.layDepositoAdicional);
                layDepositoAdicional.setVisibility(View.GONE);
                mTexto = (TextView) findViewById(R.id.lblTotalDeposito);
                mTexto.setText(Mensajes.get("XTotalMin"));
            }
            LinearLayout.LayoutParams lParams;
            mTexto = (TextView) findViewById(R.id.txtCol1);
            mTexto.setText(Mensajes.get("XFolio"));
            mTexto.setVisibility(View.GONE);
            mTexto = (TextView) findViewById(R.id.txtCol2);
            mTexto.setText(Mensajes.get("XFicha"));
            if (hayConvenios) {
                lParams= (LinearLayout.LayoutParams) mTexto.getLayoutParams();
                lParams.weight = 1f;
                mTexto.setLayoutParams(lParams);
            }
            mTexto = (TextView) findViewById(R.id.txtCol3);
            mTexto.setText(Mensajes.get("XFecha"));
            if (hayConvenios) {
                lParams = (LinearLayout.LayoutParams) mTexto.getLayoutParams();
                lParams.weight = 1f;
                mTexto.setLayoutParams(lParams);
            }
            mTexto = (TextView) findViewById(R.id.txtCol4);
            if (hayConvenios){
                lParams = (LinearLayout.LayoutParams) mTexto.getLayoutParams();
                lParams.weight = 2f;
                mTexto.setLayoutParams(lParams);
                mTexto.setText(Mensajes.get("DEPConvenio"));
            }else {
                mTexto.setText(Mensajes.get("XBanco"));
            }
            mTexto.setGravity(Gravity.LEFT);
            mTexto = (TextView) findViewById(R.id.txtCol5);
            if (hayConvenios) {
                lParams = (LinearLayout.LayoutParams) mTexto.getLayoutParams(); //or create new LayoutParams...
                lParams.weight = 1f;
                mTexto.setLayoutParams(lParams);
            }
            mTexto.setGravity(Gravity.RIGHT);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(Mensajes.get("XTotalMin"));

            CheckBox chbTipoPago = (CheckBox) findViewById(R.id.chbTipoPago);
            chbTipoPago.setText(Mensajes.get("ABDTipoPago"));
            chbTipoPago.setOnCheckedChangeListener(mSelTodos);
            mTexto = (TextView) findViewById(R.id.lblImporte);
            mTexto.setText(Mensajes.get("XImporte"));
            mTexto = (TextView) findViewById(R.id.lblSaldo);
            mTexto.setText(Mensajes.get("XSaldo"));

            CheckBox chbSaldos;
            if (capturaAdicional){
                chbSaldos = (CheckBox) findViewById(R.id.chbSaldos);
                chbSaldos.setText(Mensajes.get("XSaldosDepositos"));
                chbSaldos.setOnCheckedChangeListener(mSelTodosSaldos);
                mTexto = (TextView) findViewById(R.id.lblFechaSaldo);
                mTexto.setText(Mensajes.get("XFecha"));
                mTexto = (TextView) findViewById(R.id.lblImporteSaldo);
                mTexto.setText(Mensajes.get("XImporte"));
            }
            else{
                LinearLayout laySaldos = (LinearLayout)findViewById(R.id.laySaldos);
                laySaldos.setVisibility(View.GONE);
                //ListView lstSaldos = (ListView)findViewById(R.id.lstSaldos);
                //lstSaldos.setVisibility(View.GONE);
            }

            SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
            final TextView txtDate = (TextView) findViewById(R.id.txtFechaDeposito);
            txtDate.setText(format.format(new Date()));
            txtDate.setEnabled(false);
            spBanco = (Spinner) findViewById(R.id.spBanco);
            if (hayConvenios){
                llenarSpinerBanco(spBanco, sdConvenios);
            }else{
                ISetDatos valores;
                valores = Consultas.ConsultasValorReferencia.obtenerValores("TBANCO", null);
                llenarSpinerBanco(spBanco, valores);
            }

            mLvDeposito = (ListView) findViewById(R.id.lv_deposito);

            spBanco.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener()
            {

                @Override
                public void onItemSelected(AdapterView<?> arg0, View arg1, int position, long arg3)
                {
                    if (hayConvenios) {
                        int iTipoReferencia = ((Cursor) arg0.getItemAtPosition(position)).getInt(((Cursor) arg0.getItemAtPosition(position)).getColumnIndex("TipoReferencia"));
                        if (iTipoReferencia != iTipoReferenciaActual) {
                            EditText editText = (EditText) findViewById(R.id.txtFicha);
                            if (iTipoReferencia == 2) {
                                editText.setText(Generales.getFechaHoraActualStr("dd/MM/yyyy"));
                            } else {
                                editText.setText("");
                            }
                            iTipoReferenciaActual = iTipoReferencia;
                        }
                    }
                    //Se agrega el if porque todo el tiempo desde que se iniciaba la actividad, se marcaban cambios
                    if (!bIniciando && position > 0){
                        huboCambios = true;
                    }
                }

                @Override
                public void onNothingSelected(AdapterView<?> arg0)
                {
                    // TODO Auto-generated method stub

                }
            });

            txtFicha = (EditText) findViewById(R.id.txtFicha);
            txtFicha.addTextChangedListener(new TextWatcher()
            {
                @Override
                public void afterTextChanged(Editable arg0)
                {
                    huboCambios = true;
                }

                @Override
                public void beforeTextChanged(CharSequence arg0, int arg1, int arg2, int arg3)
                {
                }

                @Override
                public void onTextChanged(CharSequence arg0, int arg1, int arg2, int arg3)
                {

                }
            });
            //mTxtDeposito = (EditText) findViewById(R.id.txtDeposito);
            mTxtDeposito = (EditText) findViewById(R.id.txtDeposito);
            mTxtAdicional = (EditText) findViewById(R.id.txtDepositoAdicional);
            mTxtAdicional.addTextChangedListener(new TextWatcher()
            {
                @Override
                public void afterTextChanged(Editable arg0)
                {
                    huboCambios = true;
                    if(!mTxtAdicional.getText().toString().isEmpty() || !mTxtAdicional.getText().toString().equals("")){
                        if(!mTxtAdicional.getText().toString().equals(".")){
                            totalAdicional = Float.parseFloat(mTxtAdicional.getText().toString());
                            actualizaTotalDeposito(totalSeleccionado + totalAdicional);
                        }
                    }
                }

                @Override
                public void beforeTextChanged(CharSequence arg0, int arg1, int arg2, int arg3)
                {

                }

                @Override
                public void onTextChanged(CharSequence arg0, int arg1, int arg2, int arg3)
                {

                }
            });
            mTxtTotalDeposito = (EditText) findViewById(R.id.txtTotalDeposito);

            btnAgregar = (ImageButton) findViewById(R.id.btnAgregar);
            btnAgregar.setOnClickListener(mAgregarDeposito);

            registerForContextMenu(mLvDeposito);
            //mLvDeposito.requestFocus();
            mPresenta.setCapturaAdicional(capturaAdicional);
            mPresenta.iniciar();
            bIniciando = false;

        }
        catch (Exception e)
        {
            if (e!=null && e.getMessage()!= null) {

                mostrarError(e.getMessage());
            }else{
                mostrarError("Error al iniciar pantalla");
            }
        }
    }

    public void mostrarSaldosDepositos(boolean mostrar){
        LinearLayout laySaldos = (LinearLayout)findViewById(R.id.laySaldos);
        ListView lstSaldos = (ListView)findViewById(R.id.lstSaldos);
        //ScrollView svDep = (ScrollView)findViewById(R.id.scrollView1);
        //LinearLayout.LayoutParams lParams;
        //lParams= (LinearLayout.LayoutParams) svDep.getLayoutParams();
        if (!mostrar){
            laySaldos.setVisibility(View.GONE);
            //lstSaldos.setVisibility(View.GONE);
            //lParams.weight = 0.4f;
        }else{
            laySaldos.setVisibility(View.VISIBLE);
            //lstSaldos.setVisibility(View.VISIBLE);
            //lParams.weight = 0.28f;
        }
        //svDep.setLayoutParams(lParams);
    }

    private View.OnClickListener mAgregarDeposito = new View.OnClickListener()
    {
        @Override
        public void onClick(View v) {
            if (mTxtDeposito.getText() == null ||  mTxtDeposito.getText().toString().equals("") || totalDeposito<=0 || oAbd.size() <=0 )
            {
                mostrarError(Mensajes.get("E0215", "Abono"));
                return;
            }

            int tipoBancoSel = 0;
            String cuenta = "";
            if (hayConvenios){
                Cursor banco = ((SimpleCursorAdapter)spBanco.getAdapter()).getCursor();

                if (banco.getString(banco.getColumnIndex("ConvenioID")) == null || banco.getInt(banco.getColumnIndex("TipoBanco")) == 0){
                    mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", "Convenio"));
                    return;
                }
                tipoBancoSel =banco.getInt(banco.getColumnIndex("TipoBanco"));
                cuenta = banco.getString(banco.getColumnIndex("Cuenta"));
            }else{
                if (spBanco.getSelectedItemPosition() == 0)
                {
                    mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", "Banco"));
                    return;
                }
                tipoBancoSel = spBanco.getSelectedItemPosition();
            }

            if (txtFicha.getText().toString().equals(""))
            {
                mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", "Ficha"));
                return;
            }

            mPresenta.AgregarDeposito(String.valueOf(tipoBancoSel), cuenta, txtFicha.getText().toString(), totalDeposito, totalAdicional, oAbd, oSaldos);
            iTipoReferenciaActual = 0;
        }
    };
    @Override
    public void setLimpiarDeposito()
    {
        spBanco.setSelection(0);
        txtFicha.setText("");
        mTxtDeposito.setText("0.00");
        mTxtAdicional.setText("0.00");
        mTxtTotalDeposito.setText("0.00");
        totalAbonos = 0;
        totalSaldos = 0;
        totalSeleccionado = 0;
        totalAdicional = 0;
        totalDeposito = 0;
    }

    @Override
    @SuppressWarnings("deprecation")
    public void refrescarDeposito()
    {
        try
        {
            huboCambios = false;
            ISetDatos stTransProdDetalle = Consultas.ConsultaDeposito.obtenerDepositosRealizados();
            Cursor cProductos = (Cursor) stTransProdDetalle.getOriginal();
            startManagingCursor(cProductos);
            try
            {
                SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple_hor6_wrap, cProductos, new String[]
                        { "_id", "Ficha", "FechaDeposito", "TipoBanco" , "Total"  }, new int[]
                        { R.id.txtCol1, R.id.txtCol2, R.id.txtCol3, R.id.txtCol4, R.id.txtCol5 });
                adapter.setViewBinder(new vistaDeposito());
                mLvDeposito.setAdapter(adapter);

                mLvDeposito.setOnItemClickListener(new AdapterView.OnItemClickListener()
                                                   {

                                                       public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
                                                       {
                                                       }
                                                   }
                );

            }
            catch (Exception e)
            {
                mostrarError(e.getMessage());
            }

        }
        catch (Exception ex)
        {
            mostrarError(ex.getMessage());
        }
    }

    @Override
    public void iniciar() {
        HideKeyboard();
    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {

    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
        if (tipoMensaje == 2)
        {
            if (respuesta == Enumeradores.RespuestaMsg.Si)
            {
                Cursor transacciones = (Cursor) (((SimpleCursorAdapter) mLvDeposito.getAdapter()).getCursor());
                mPresenta.eliminarDeposito(transacciones.getString(transacciones.getColumnIndex("_id")));
            }
        }else if(tipoMensaje == 3){
            if (respuesta == Enumeradores.RespuestaMsg.Si) {
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }
        }
    }



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

    public boolean isSoloLectura()
    {
        return soloLectura;
    }

    private void salir()
    {

        if (huboCambios)
            mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
        else
        {
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        }

    }

    public void llenarSpinerBanco(Spinner control, ISetDatos valores)
    {
        try
        {

            Cursor unidad = (Cursor) valores.getOriginal();
            startManagingCursor(unidad);
            SimpleCursorAdapter adapter = new SimpleCursorAdapter(CapturaDepositoVinculado.this, android.R.layout.simple_spinner_item, unidad, new String[]
                    { (hayConvenios ? "ConvenioID" : "VAVClave") }, new int[]
                    { android.R.id.text1 });
            adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
            adapter.setViewBinder(new llenarSpinnerBanco());
            control.setAdapter(adapter);
            control.setSelection(0);
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

    }

    private class llenarSpinnerBanco implements SimpleCursorAdapter.ViewBinder
    {

        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex)
        {
            int viewId = view.getId();
            switch (viewId)
            {
                case android.R.id.text1: // para llenar el combo de la unidad
                    TextView combo = (TextView) view;
                    combo.setGravity(Gravity.CENTER);
                    if (hayConvenios){
                        combo.setText(ValoresReferencia.getDescripcion("TBANCO", cursor.getString(cursor.getColumnIndex("TipoBanco"))) + "-" + cursor.getString(cursor.getColumnIndex("Cuenta")));
                    }else{
                        combo.setText(ValoresReferencia.getDescripcion("TBANCO", cursor.getString(cursor.getColumnIndex("VAVClave"))));
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

    //@Override
    public void actualizaTotalSeleccionado(float total)
    {
        totalSeleccionado = total;
        mTxtDeposito.setText("$ ".concat(Generales.getFormatoDecimal(total, "#,###,##0.00")));

        actualizaTotalDeposito(totalSeleccionado + totalAdicional);
    }

    public void actualizaTotalDeposito(float total)
    {
        totalDeposito = total;
        mTxtTotalDeposito.setText("$ ".concat(Generales.getFormatoDecimal(total, "#,###,##0.00")));
    }


    @Override
    public void initAdapterView(ArrayAdapter<? extends Entidad> adapter, int idList, View vista )
    {


        ListView listView ;
        if ( vista == null){
            listView = (ListView) findViewById(idList);
        }else {
            listView = (ListView) vista.findViewById(idList);
        }
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
        setListViewHeightBasedOnChildren(listView, (capturaAdicional ? 3 : 5));
    }
    public float getTotalDeposito()
    {
        return totalDeposito;
    }
    private static void setListViewHeightBasedOnChildren(ListView listView, int maximo) {

        ArrayAdapter<? extends Entidad> listAdapter = (ArrayAdapter<? extends Entidad>)listView.getAdapter();
        if (listAdapter == null)
            return;

        int desiredWidth = View.MeasureSpec.makeMeasureSpec(listView.getWidth(), View.MeasureSpec.UNSPECIFIED);
        int totalHeight = 0;
        View view = null;
        int max = listAdapter.getCount();
        if (max >maximo) max = maximo;
        for (int i = 0; i < max; i++) {
            view = listAdapter.getView(i, view, listView);
            if (i == 0)
                view.setLayoutParams(new ViewGroup.LayoutParams(desiredWidth, ViewGroup.LayoutParams.WRAP_CONTENT));

            view.measure(desiredWidth, View.MeasureSpec.UNSPECIFIED);
            totalHeight += view.getMeasuredHeight();
        }
        ViewGroup.LayoutParams params = listView.getLayoutParams();
        params.height = totalHeight + (listView.getDividerHeight() * (listAdapter.getCount() - 1));
        listView.setLayoutParams(params);
    }

    public class AdapterABNDetalle extends ArrayAdapter<ABNDetalle>{

        private int idLayout;
        private HashMap<ABNDetalle,Boolean> seleccionados;
        private float total;
        private CONHist conHist;
        private List<ABNDetalle> entidades;
        private Boolean bModManual = false;
        private boolean bSoloLectura = false;


        public AdapterABNDetalle(int idResource, List<ABNDetalle> entidades, Boolean soloLectura){
            super(CapturaDepositoVinculado.this, idResource, entidades);
            idLayout = idResource;
            this.entidades = entidades;
            seleccionados = new HashMap<ABNDetalle, Boolean>();
            conHist = (CONHist) Sesion.get(Sesion.Campo.CONHist);
            bSoloLectura = soloLectura;
        }

        public HashMap<ABNDetalle,Boolean> getSeleccionados(){
            return seleccionados;
        }

        public List<ABNDetalle> getEntidades(){
            return entidades;
        }
        public float getTotal(){
            return total;
        }


        @Override
        public View getView(final int position, View convertView, ViewGroup parent)
        {
            View fila = convertView;

            if (convertView == null)
            {
                LayoutInflater inflater = (CapturaDepositoVinculado.this).getLayoutInflater();
                fila = inflater.inflate(idLayout, null);
            }
            final ABNDetalle abnDetalle= getItem(position);
            if (!seleccionados.containsKey(abnDetalle)){
                seleccionados.put(abnDetalle,false);
            }
            switch(idLayout)
            {
                case R.layout.lista_abonos_deposito:
                    //if(soloLectura){
                    bModManual = true;
                    if (bSoloLectura){
                        ((RelativeLayout) fila.findViewById(R.id.laySeleccion)).setVisibility(View.GONE);
                        ((CheckBox) fila.findViewById(R.id.chkSeleccion)).setVisibility(View.GONE);
                        LinearLayout layDatos = (LinearLayout) fila.findViewById(R.id.layDatos);
                        //layDatos.setWeightSum(100f);
                        //TextView txt = (TextView)fila.findViewById(R.id.lblFormaPago);
                        //LinearLayout.LayoutParams lParams = (LinearLayout.LayoutParams) txt.getLayoutParams(); //or create new LayoutParams...
                        //lParams.weight = 60f;
                        //txt.setLayoutParams(lParams);
                        TextView txt = (TextView)fila.findViewById(R.id.lblImporte);
                        //lParams.weight = 20f;
                        //txt.setLayoutParams(lParams);
                        txt.setGravity(Gravity.RIGHT);
                        txt = (TextView)fila.findViewById(R.id.lblSaldo);
                        //lParams.weight = 20f;
                        //txt.setLayoutParams(lParams);
                        txt.setGravity(Gravity.RIGHT);
                    }else {
                        ((CheckBox) fila.findViewById(R.id.chkSeleccion)).setChecked(seleccionados.get(abnDetalle));
                    }
                        ((TextView)fila.findViewById(R.id.lblFormaPago)).setText(Html.fromHtml(ValoresReferencia.getDescripcion ("PAGO", String.valueOf(abnDetalle.TipoPago))));
                        ((TextView)fila.findViewById(R.id.lblImporte)).setText(Html.fromHtml(Generales.getFormatoDecimal(abnDetalle.Importe,2)));
                        ((TextView)fila.findViewById(R.id.lblSaldo)).setText( Generales.getFormatoDecimal (abnDetalle.SaldoDeposito,2));
                    bModManual = false;
                    /*}else{
                        ((TextView)fila.findViewById(R.id.lblMetodoPago)).setText(Html.fromHtml("<b>"+Mensajes.get("XMetodoPago")+":</b> "+
                                ValoresReferencia.getDescripcion("PAGO", String.valueOf(((ClientePago)entidad).Tipo))));
                        ((TextView)fila.findViewById(R.id.lblCuenta)).setText(Html.fromHtml("<b>"+Mensajes.get("TDFNumerosCuenta")+":</b> "+
                                ((ClientePago)entidad).Cuenta));
                        ((TextView)fila.findViewById(R.id.lblBanco)).setText(Html.fromHtml("<b>"+Mensajes.get("XBanco")+":</b> "+
                                ValoresReferencia.getDescripcion("TBANCO", String.valueOf(((ClientePago)entidad).TipoBanco))));
                    }*/
                    break;
               /* default :
                    ((TextView)fila.findViewById(R.id.lblFolio)).setText(((TransProd)entidad).Folio);
                    ((TextView)fila.findViewById(R.id.lblFecha)).setText(Generales.getFormatoFecha(((TransProd)entidad).FechaSurtido, "dd/MM/yyyy"));
                    ((TextView)fila.findViewById(R.id.lblTotal)).setText("$ ".concat(Generales.getFormatoDecimal(((TransProd)entidad).Total, "#,###,##0.00")));
                    fila.findViewById(R.id.chkSeleccion).setEnabled(!haySeleccionados() || (!"0".equals(conHist.get("VariosPedidos")) || seleccionados[position]));
*/
            }
            if(isSoloLectura()){
                fila.findViewById(R.id.chkSeleccion).setVisibility(View.GONE);
            }else
            {
                ((CheckBox)fila.findViewById(R.id.chkSeleccion)).setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener()
                {

                    @Override
                    public void onCheckedChanged(CompoundButton check, boolean checked)
                    {
                        if(bModManual) return;
                         //seleccionados[position] = checked;
                        if(idLayout == R.layout.lista_abonos_deposito){
                            if (seleccionados.containsKey(abnDetalle) &&  seleccionados.get(abnDetalle) != checked ){
                                seleccionados.put(abnDetalle, checked);
                                calculaTotal();
                                notifyDataSetChanged();
                            }
                        }
                    }
                });
            }
            return fila;
        }

        public void calculaTotal(){
            total = 0;
            oAbd = new ArrayList<ABNDetalle>();
            for (HashMap.Entry<ABNDetalle, Boolean> entry : seleccionados.entrySet()) {
                if(entry.getValue() || soloLectura){
                    total+= entry.getKey().SaldoDeposito;
                    oAbd.add(entry.getKey());
                }
            }

            totalAbonos = total;
            actualizaTotalSeleccionado(totalAbonos + totalSaldos);
        }
    }

    public class AdapterSaldoDeposito extends ArrayAdapter<SaldoDeposito>{

        private int idLayout;
        private HashMap<SaldoDeposito,Boolean> seleccionados;
        private float total;
        private List<SaldoDeposito> entidades;
        private Boolean bModManual = false;
        private boolean bSoloLectura = false;
        private String msgFavorable = "";
        private String msgDesfavorable = "";

        public AdapterSaldoDeposito(int idResource, List<SaldoDeposito> entidades, Boolean soloLectura){
            super(CapturaDepositoVinculado.this, idResource, entidades);
            idLayout = idResource;
            this.entidades = entidades;
            seleccionados = new HashMap<SaldoDeposito, Boolean>();
            bSoloLectura = soloLectura;
            msgFavorable = Mensajes.get("XFavorable");
            msgDesfavorable = Mensajes.get("XDesfavorable");
        }

        public HashMap<SaldoDeposito,Boolean> getSeleccionados(){
            return seleccionados;
        }

        public List<SaldoDeposito> getEntidades(){
            return entidades;
        }
        public float getTotal(){
            return total;
        }

        @Override
        public View getView(final int position, View convertView, ViewGroup parent)
        {
            View fila = convertView;

            if (convertView == null)
            {
                LayoutInflater inflater = (CapturaDepositoVinculado.this).getLayoutInflater();
                fila = inflater.inflate(idLayout, null);
            }
            final SaldoDeposito saldoDeposito= getItem(position);
            if (!seleccionados.containsKey(saldoDeposito)){
                seleccionados.put(saldoDeposito,false);
            }
            switch(idLayout)
            {
                case R.layout.lista_saldos_deposito:
                    bModManual = true;
                    if (bSoloLectura){
                        ((RelativeLayout) fila.findViewById(R.id.laySeleccion)).setVisibility(View.GONE);
                        ((CheckBox) fila.findViewById(R.id.chkSeleccion)).setVisibility(View.GONE);
                        LinearLayout layDatos = (LinearLayout) fila.findViewById(R.id.layDatos);
                        TextView txt = (TextView)fila.findViewById(R.id.lblFecha);
                        txt.setGravity(Gravity.RIGHT);
                        txt = (TextView)fila.findViewById(R.id.lblSaldo);;
                        txt.setGravity(Gravity.RIGHT);
                    }else {
                        ((CheckBox) fila.findViewById(R.id.chkSeleccion)).setChecked(seleccionados.get(saldoDeposito));
                    }
                    ((TextView)fila.findViewById(R.id.lblTipoSaldo)).setText(Html.fromHtml((saldoDeposito.Saldo < 0 ? msgFavorable : msgDesfavorable)));
                    ((TextView)fila.findViewById(R.id.lblFecha)).setText(Html.fromHtml(saldoDeposito.DiaClave));
                    ((TextView)fila.findViewById(R.id.lblSaldo)).setText( Generales.getFormatoDecimal(saldoDeposito.Saldo,2));
                    bModManual = false;
                    break;
            }
            if(isSoloLectura()){
                fila.findViewById(R.id.chkSeleccion).setVisibility(View.GONE);
            }else
            {
                ((CheckBox)fila.findViewById(R.id.chkSeleccion)).setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener()
                {

                    @Override
                    public void onCheckedChanged(CompoundButton check, boolean checked)
                    {
                        if(bModManual) return;
                        if(idLayout == R.layout.lista_saldos_deposito){
                            if (seleccionados.containsKey(saldoDeposito) &&  seleccionados.get(saldoDeposito) != checked ){
                                seleccionados.put(saldoDeposito, checked);
                                calculaTotal();
                                notifyDataSetChanged();
                            }
                        }
                    }
                });
            }
            return fila;
        }

        public void calculaTotal(){
            total = 0;
            oSaldos = new ArrayList<SaldoDeposito>();
            for (HashMap.Entry<SaldoDeposito, Boolean> entry : seleccionados.entrySet()) {
                if(entry.getValue() || soloLectura){
                    total+= entry.getKey().Saldo;
                    oSaldos.add(entry.getKey());
                }
            }

            totalSaldos = total;
            actualizaTotalSeleccionado(totalAbonos + totalSaldos);
        }
    }

    private class vistaDeposito implements SimpleCursorAdapter.ViewBinder
    {

        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex)
        {
            int viewId = view.getId();
            LinearLayout.LayoutParams lParams;
            switch (viewId) {
                case R.id.txtCol1:
                    TextView combo = (TextView) view;
                    combo.setText(cursor.getString(cursor.getColumnIndex("_id")));
                    combo.setVisibility(View.GONE);
                    break;
                case R.id.txtCol2:
                    combo = (TextView) view;
                    combo.setText(cursor.getString(cursor.getColumnIndex("Ficha")));
                    if (hayConvenios) {
                        lParams = (LinearLayout.LayoutParams) combo.getLayoutParams();
                        lParams.weight = 1f;
                        combo.setLayoutParams(lParams);
                    }
                    break;
                case R.id.txtCol3:
                    combo = (TextView) view;
                    combo.setText(cursor.getString(cursor.getColumnIndex("FechaDeposito")));
                    if (hayConvenios) {
                        lParams = (LinearLayout.LayoutParams) combo.getLayoutParams();
                        lParams.weight = 1f;
                        combo.setLayoutParams(lParams);
                    }
                    break;
                case R.id.txtCol5:
                    view.setVisibility(View.VISIBLE);
                    combo = (TextView) view;
                    combo.setText(Generales.getFormatoDecimal(cursor.getFloat(cursor.getColumnIndex("Total")),"#,##0.00") );
                    combo.setGravity(Gravity.RIGHT);
                    if (hayConvenios) {
                        lParams = (LinearLayout.LayoutParams) combo.getLayoutParams();
                        lParams.weight = 1f;
                        combo.setLayoutParams(lParams);
                    }
                    break;
                case R.id.txtCol4:
                    combo = (TextView) view;
                    String mBancoConvenio = "";
                    if (hayConvenios){
                        mBancoConvenio = ValoresReferencia.getDescripcion("TBANCO", cursor.getString(cursor.getColumnIndex("TipoBanco"))) + "-" + cursor.getString(cursor.getColumnIndex("Cuenta"));
                        lParams= (LinearLayout.LayoutParams) combo.getLayoutParams();
                        lParams.weight = 2f;
                        combo.setLayoutParams(lParams);
                    }else{
                        mBancoConvenio = ValoresReferencia.getDescripcion("TBANCO", cursor.getString(cursor.getColumnIndex("TipoBanco")));
                    }
                    combo.setText(mBancoConvenio);
                    combo.setGravity(Gravity.LEFT);

                    break;
                case R.id.txtCol6:
                        view.setVisibility(View.INVISIBLE);
                        break;
                default:
                    TextView texto = (TextView) view;
                    texto.setText(cursor.getString(columnIndex));
                    break;
            }
            return true;
        }
    }

    public void HideKeyboard()
    {
        InputMethodManager inputManager =
                (InputMethodManager) this.getSystemService(Context.INPUT_METHOD_SERVICE);
        inputManager.hideSoftInputFromWindow(
                this.getCurrentFocus().getWindowToken(),
                0);
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo)
    {
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.context_depositos, menu);
        menu.getItem(0).setTitle(Mensajes.get("XEliminar"));
        menu.getItem(1).setTitle(Mensajes.get("XConsultar"));
    }

    @Override
    public boolean onContextItemSelected(MenuItem item)
    {
        switch (item.getItemId()){
            case R.id.eliminar:
                mostrarPreguntaSiNo(Mensajes.get("P0112").replace("$0$", "registro"), 2);
                break;
            case R.id.consultar:
                ConsultarDetalle();
                break;
        }

        return true;
    }

    private CheckBox.OnCheckedChangeListener mSelTodos= new CompoundButton.OnCheckedChangeListener()
    {
        @Override
        public void onCheckedChanged(CompoundButton check, boolean checked)
        {
            ListView listView = (ListView) findViewById(R.id.lstDocumentos);
            HashMap<ABNDetalle, Boolean> hmSeleccionados =  ((AdapterABNDetalle)listView.getAdapter()).getSeleccionados();
            List<ABNDetalle> lregistros =  ((AdapterABNDetalle)listView.getAdapter()).getEntidades();
            for(int x=0;x<lregistros.size();x++) {
                if (hmSeleccionados.containsKey(lregistros.get(x))){
                    if(hmSeleccionados.get(lregistros.get(x)) != checked){
                        hmSeleccionados.put(lregistros.get(x),checked);
                    }
                }else{
                    hmSeleccionados.put(lregistros.get(x),checked);
                }

            }
            /*for (HashMap.Entry<ABNDetalle, Boolean> entry : hmSeleccionados.entrySet()) {
                if(entry.getValue() != checked){
                        entry.setValue(checked);
                }
            }*/
            ((AdapterABNDetalle)listView.getAdapter()).notifyDataSetChanged();
            ((AdapterABNDetalle)listView.getAdapter()).calculaTotal();
        }
    };

    private CheckBox.OnCheckedChangeListener mSelTodosSaldos= new CompoundButton.OnCheckedChangeListener()
    {
        @Override
        public void onCheckedChanged(CompoundButton check, boolean checked)
        {
            ListView listView = (ListView) findViewById(R.id.lstSaldos);
            HashMap<SaldoDeposito, Boolean> hmSeleccionados =  ((AdapterSaldoDeposito)listView.getAdapter()).getSeleccionados();
            List<SaldoDeposito> lregistros =  ((AdapterSaldoDeposito)listView.getAdapter()).getEntidades();
            for(int x=0;x<lregistros.size();x++) {
                if (hmSeleccionados.containsKey(lregistros.get(x))){
                    if(hmSeleccionados.get(lregistros.get(x)) != checked){
                        hmSeleccionados.put(lregistros.get(x),checked);
                    }
                }else{
                    hmSeleccionados.put(lregistros.get(x),checked);
                }

            }
            ((AdapterSaldoDeposito)listView.getAdapter()).notifyDataSetChanged();
            ((AdapterSaldoDeposito)listView.getAdapter()).calculaTotal();
        }
    };

    private void ConsultarDetalle(){
            try {

                LayoutInflater inflater = (LayoutInflater) CapturaDepositoVinculado.this
                        .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

                View dialogView = inflater.inflate(R.layout.dialog_detalle_deposito, null);


                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                //TextView lblTituloDialogo = (TextView)dialogView.findViewById(R.id.lblTituloDialogo);

                LinearLayout mylayout = (LinearLayout) dialogView.findViewById(R.id.layout_titulos);
                mylayout.setWeightSum(100f);
                TextView txt = (TextView) dialogView.findViewById(R.id.txtCol1);
                txt.setText(Mensajes.get("ABDTipoPago"));
                /*LinearLayout.LayoutParams lParams = (LinearLayout.LayoutParams) txt.getLayoutParams(); //or create new LayoutParams...
                lParams.weight = 40f;
                txt.setLayoutParams(lParams);*/
                txt = (TextView) dialogView.findViewById(R.id.txtCol2);
                txt.setText(Mensajes.get("XImporte"));//or create new LayoutParams...
                /*lParams.weight = 30f;
                txt.setLayoutParams(lParams);*/
                txt.setGravity(Gravity.RIGHT);
                txt = (TextView) dialogView.findViewById(R.id.txtCol3);
                txt.setText(Mensajes.get("XSaldo"));
                /*lParams.weight = 30f;
                txt.setGravity(Gravity.CENTER);
                txt.setLayoutParams(lParams);
                txt = (TextView) dialogView.findViewById(R.id.txtCol4);
                txt.setVisibility(View.INVISIBLE);
                txt = (TextView) dialogView.findViewById(R.id.txtCol5);
                txt.setVisibility(View.INVISIBLE);*/

                Cursor transacciones = (Cursor) (((SimpleCursorAdapter) mLvDeposito.getAdapter()).getCursor());
                String sDEPId = transacciones.getString(transacciones.getColumnIndex("_id"));
                Deposito deposito = new Deposito();
                deposito.DEPId = sDEPId;
                BDVend.recuperar(deposito);
                BDVend.recuperar(deposito, AbdDep.class);

                List<ABNDetalle> abnDetalles = new ArrayList<ABNDetalle>();;
                for (AbdDep abd: deposito.AbdDep) {
                    ABNDetalle abn = new ABNDetalle();
                    abn.ABNId = abd.ABNId;
                    abn.ABDId = abd.ABDId;
                    BDVend.recuperar(abn);
                    abnDetalles.add(abn);
                }
                if (abnDetalles.size()>0){
                    initAdapterView(((CapturaDepositoVinculado) this).new AdapterABNDetalle(R.layout.lista_abonos_deposito, abnDetalles, true), R.id.lstGrid,dialogView);

                }

                if (capturaAdicional){

                    List<SaldoDeposito> saldoDepositos = Consultas.ConsultasSaldoDeposito.obtenerSaldosAplicados(deposito.DEPId);
                    if (saldoDepositos.size()>0){
                        LinearLayout layout_titulos2 = (LinearLayout) dialogView.findViewById(R.id.layout_titulos2);
                        layout_titulos2.setVisibility(View.VISIBLE);
                        layout_titulos2.setWeightSum(100f);
                        txt = (TextView) dialogView.findViewById(R.id.txtCol4);
                        txt.setText(Mensajes.get("XSaldosDepositos"));

                        txt = (TextView) dialogView.findViewById(R.id.txtCol5);
                        txt.setText(Mensajes.get("XFecha"));

                        txt = (TextView) dialogView.findViewById(R.id.txtCol6);
                        txt.setText(Mensajes.get("XImporte"));

                        ListView lstGrid2 = (ListView)dialogView.findViewById(R.id.lstGrid2);
                        lstGrid2.setVisibility(View.VISIBLE);
                        initAdapterView(((CapturaDepositoVinculado) this).new AdapterSaldoDeposito(R.layout.lista_saldos_deposito, saldoDepositos, true), R.id.lstGrid2, dialogView);
                    }

                    SaldoDeposito adicional = Consultas.ConsultasSaldoDeposito.obtenerDepositoAdicional(deposito.DEPId);
                    if (adicional != null){
                        LinearLayout layoutAdicional = (LinearLayout) dialogView.findViewById(R.id.layout_adicional);
                        layoutAdicional.setVisibility(View.VISIBLE);

                        txt = (TextView) dialogView.findViewById(R.id.txtCol7);
                        txt.setText(Mensajes.get("XDepositoAdicional"));

                        txt = (TextView) dialogView.findViewById(R.id.txtCol8);
                        txt.setText(Generales.getFormatoDecimal (Math.abs(adicional.Saldo), 2));

                    }
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


}
