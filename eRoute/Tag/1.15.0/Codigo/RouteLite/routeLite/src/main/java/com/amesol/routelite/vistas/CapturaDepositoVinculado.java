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
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
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
    private ListView mLvDeposito = null;

    private CapturarDepositoVinculado mPresenta;

    private boolean soloLectura = false;
    private boolean hayConvenios = false;
    private ISetDatos sdConvenios;
    private Integer iTipoReferenciaActual = 0;
    ImageButton btnAgregar;
    ArrayList<ABNDetalle> oAbd = null;
    private float totalDeposito=0;

    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.captura_deposito_vinculado);
        //		deshabilitarBarra(true);
        try
        {
            sdConvenios = Consultas.ConsultarConvenios.obtenerConvenios();
            if (sdConvenios.getCount()>0){
                hayConvenios = true;
            }
            mAccion = getIntent().getAction();
            lblTitle.setText("Depositos");

            mPresenta = new CapturarDepositoVinculado(this, mAccion);

            TextView mTexto = (TextView) findViewById(R.id.lblRuta);
            mTexto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Descripcion);
            mTexto = (TextView) findViewById(R.id.lblDia);
            mTexto.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);
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
            mTexto = (TextView) findViewById(R.id.lblDeposito);
            mTexto.setText(Mensajes.get("XTotalMin"));
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
                public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3)
                {
                    if (hayConvenios) {
                        int iTipoReferencia = ((Cursor) arg0.getItemAtPosition(arg2)).getInt(((Cursor) arg0.getItemAtPosition(arg2)).getColumnIndex("TipoReferencia"));
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
                    huboCambios = true;
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

            btnAgregar = (ImageButton) findViewById(R.id.btnAgregar);
            btnAgregar.setOnClickListener(mAgregarDeposito);

            registerForContextMenu(mLvDeposito);
            //mLvDeposito.requestFocus();
            mPresenta.iniciar();

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

            mPresenta.AgregarDeposito(String.valueOf(tipoBancoSel), cuenta, txtFicha.getText().toString(), totalDeposito, oAbd);
            iTipoReferenciaActual = 0;
        }
    };
    @Override
    public void setLimpiarDeposito()
    {
        spBanco.setSelection(0);
        txtFicha.setText("");
        mTxtDeposito.setText("0.00");
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
                SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple_hor6, cProductos, new String[]
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
    public void actualizaTotalDeposito(float total)
    {
        totalDeposito = total;
        mTxtDeposito.setText("$ ".concat(Generales.getFormatoDecimal(total, "#,###,##0.00")));
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
        setListViewHeightBasedOnChildren(listView);
    }
    public float getTotalDeposito()
    {
        return totalDeposito;
    }
    private static void setListViewHeightBasedOnChildren(ListView listView) {
        ArrayAdapter<? extends Entidad> listAdapter = (ArrayAdapter<? extends Entidad>)listView.getAdapter();
        if (listAdapter == null)
            return;

        int desiredWidth = View.MeasureSpec.makeMeasureSpec(listView.getWidth(), View.MeasureSpec.UNSPECIFIED);
        int totalHeight = 0;
        View view = null;
        int max = listAdapter.getCount();
        if (max >5) max = 5;
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

            actualizaTotalDeposito(total);
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

    private void ConsultarDetalle(){
            try {

                LayoutInflater inflater = (LayoutInflater) CapturaDepositoVinculado.this
                        .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

                View dialogView = inflater.inflate(R.layout.dialogo_grid, null);


                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                LinearLayout mylayout = (LinearLayout) dialogView.findViewById(R.id.layout_titulos);
                mylayout.setWeightSum(100f);
                TextView txt = (TextView) dialogView.findViewById(R.id.txtCol1);
                txt.setText(Mensajes.get("ABDTipoPago"));
                LinearLayout.LayoutParams lParams = (LinearLayout.LayoutParams) txt.getLayoutParams(); //or create new LayoutParams...
                lParams.weight = 40f;
                txt.setLayoutParams(lParams);
                txt = (TextView) dialogView.findViewById(R.id.txtCol2);
                txt.setText(Mensajes.get("XImporte"));//or create new LayoutParams...
                lParams.weight = 30f;
                txt.setLayoutParams(lParams);
                txt.setGravity(Gravity.RIGHT);
                txt = (TextView) dialogView.findViewById(R.id.txtCol3);
                txt.setText(Mensajes.get("XSaldo"));
                lParams.weight = 30f;
                txt.setGravity(Gravity.CENTER);
                txt.setLayoutParams(lParams);
                txt = (TextView) dialogView.findViewById(R.id.txtCol4);
                txt.setVisibility(View.INVISIBLE);
                txt = (TextView) dialogView.findViewById(R.id.txtCol5);
                txt.setVisibility(View.INVISIBLE);

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
