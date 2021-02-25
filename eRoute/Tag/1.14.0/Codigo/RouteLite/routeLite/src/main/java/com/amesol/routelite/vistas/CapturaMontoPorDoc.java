package com.amesol.routelite.vistas;

import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.text.InputType;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;
import android.widget.Toast;

import com.amesol.routelite.R;

import com.amesol.routelite.actividades.Mensajes;

import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.interfaces.ICapturaMontoPorDoc;
import com.amesol.routelite.utilerias.Generales;


import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class CapturaMontoPorDoc extends Vista implements ICapturaMontoPorDoc {

    ListView lista;
    ArrayList<String> aTransProdIds;
    Float totalAbonos = 0f;
    Float totalAplicado = 0f;
    private HashMap<String, Float> eCantidades = new HashMap<String, Float>();
    private HashMap<String, Float> eSaldos = new HashMap<String,Float>();
    EditText etAplicado;
    EditText etPorAplicar;
    EditText editTextError = null;
    boolean errorDeCaptura = false;

    private boolean bEsVisible = false;

    @SuppressWarnings("unchecked")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.captura_desglose_importe);
        deshabilitarBarra(true);

        HashMap<String, Object> oParametros = null;
        if (getIntent().getSerializableExtra("parametros") != null)
        {
            oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
            if (oParametros != null && (oParametros.containsKey("TransProdIds")))
            {
                aTransProdIds = (ArrayList<String>)oParametros.get("TransProdIds");
            }
            if (oParametros != null && (oParametros.containsKey("PorAplicar")))
            {
                totalAbonos = (Float)oParametros.get("PorAplicar");
            }
        }

        setTitulo(Mensajes.get("BTDesglosarImporte"));

        TextView texto = (TextView) findViewById(R.id.lblPorAplicar);
        texto.setText(Mensajes.get("XPorAplicar"));

        texto = (TextView) findViewById(R.id.lblAplicado);
        texto.setText(Mensajes.get("XAplicado") + ":");

        etPorAplicar = (EditText) findViewById(R.id.txtPorAplicar);
        etPorAplicar.setText(String.format("$ %.2f", totalAbonos));

        etAplicado = (EditText) findViewById(R.id.txtAplicado);
        etAplicado.setText(String.format("$ %.2f", 0f));

        Button boton = (Button) findViewById(R.id.btnContinuar);
        boton.setText(Mensajes.get("XContinuar"));
        boton.setOnClickListener(mContinuar);

        lista = (ListView) findViewById(R.id.lstDocumentos);
        lista.setDescendantFocusability(ViewGroup.FOCUS_BEFORE_DESCENDANTS);
        lista.setChoiceMode(1);
        lista.setItemsCanFocus(true);
        lista.setClickable(false);

        mostrarDocumentos();

    }

    @Override
    public void iniciar() {

    }

    @Override
    public void onWindowFocusChanged(boolean hasFocus)
    {

        super.onWindowFocusChanged(hasFocus);

        if (hasFocus)
            if (!bEsVisible)
            {
                lista.requestFocusFromTouch();
                lista.setSelection(0);
                //eCantidades.get(0).requestFocus();
                bEsVisible = true;
            }
    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {

    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
        if (tipoMensaje == 1 && respuesta.equals(Enumeradores.RespuestaMsg.Si) ){
            this.finish();
        }else if (tipoMensaje ==2 && errorDeCaptura){
            editTextError.requestFocus();
            editTextError = null;
            errorDeCaptura = false;
        }
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event)
    {
        switch (keyCode)
        {
            case KeyEvent.KEYCODE_BACK:
                    mostrarPreguntaSiNo(Mensajes.get("BP0002") ,1) ;

                    return true;

        }
        return super.onKeyDown(keyCode, event);
    }

    private View.OnClickListener mContinuar = new View.OnClickListener()
    {
        @Override
        public void onClick(View v)
        {
            Button boton = (Button) findViewById(R.id.btnContinuar);
            boton.setEnabled(false);

            Integer numImportesAsignados = 0;
            for (Map.Entry<String, Float> entry : eCantidades.entrySet()) {
                if (entry.getValue()>0) {
                    numImportesAsignados += 1;
                }
            }
            if (numImportesAsignados<aTransProdIds.size()){
                mostrarAdvertencia(Mensajes.get("I0246"));
                boton.setEnabled(true);
                return;
            }
            if (Generales.getRound(totalAplicado ,2) < Generales.getRound(totalAbonos, 2) ){
                mostrarAdvertencia(Mensajes.get("I0317"));
                boton.setEnabled(true);
                return;
             }
            if (Generales.getRound(totalAplicado,2)  > Generales.getRound(totalAbonos,2)){
                mostrarAdvertencia(Mensajes.get("I0318", String.format("$ %.2f", totalAbonos)));
                boton.setEnabled(true);
                return;
            }

            lista.clearFocus();
            if (errorDeCaptura)
                return;
            if (lista.getVisibility() == View.VISIBLE)
            {

                Sesion.set(Sesion.Campo.ResultadoActividad, eCantidades);
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN, null);
            }

            finalizar();

           /* if (oInventarioMercadeo == null || oInventarioMercadeo.InventarioMercadeoDetalle == null || oInventarioMercadeo.InventarioMercadeoDetalle.size()<=0 )
            {
                mostrarError(Mensajes.get("MDBAsignarProducto"));
                boton.setEnabled(true);
            }
            else
            {
                seleccionTPD = generarSeleccionados();
                terminar();
            }*/
        }
    };
    @SuppressWarnings("deprecation")
    public void mostrarDocumentos()
    {
        try
        {
            if (lista.getAdapter() != null){
                stopManagingCursor(((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())));
                ((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())).close();
            }
            ISetDatos stDoctosSel= Consultas.ConsultasTransProd.obtenerTransProdYSaldo(aTransProdIds.toString().replace("[", "").replace("]", ""));

            Cursor cDoctosSel = (Cursor) stDoctosSel.getOriginal();
            startManagingCursor(cDoctosSel);
            try
            {
                //obtenerTotales(TransProdId);
                MySimpleCursorAdapter adapter = new MySimpleCursorAdapter(this, R.layout.elemento_captura_importe_docto, cDoctosSel, new String[]
                        { "Folio", "Cantidad" }, new int[]
                        { R.id.lblFolio, R.id.npCantidad});
                adapter.setViewBinder(new vista());
                lista.setAdapter(adapter);
                eCantidades.clear();
                lista.requestFocusFromTouch();
                lista.setSelection(0);

                stopManagingCursor(cDoctosSel);
            }
            catch (Exception e)
            {
                mostrarError(e.getMessage());
            }

            //calculando = false;

        }
        catch (Exception ex)
        {
            mostrarError(ex.getMessage());
        }
    }


    private class vista implements SimpleCursorAdapter.ViewBinder
    {

        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex)
        {
            try {
                int viewId = view.getId();
                switch (viewId) {
                    case R.id.lblFolio:
                        TextView combo = (TextView) view;
                        combo.setText(cursor.getString(cursor.getColumnIndex("Folio")) + "-" + String.format("$ %.2f", cursor.getFloat(cursor.getColumnIndex("Saldo"))) );
                        if (!eSaldos.containsKey(cursor.getString(cursor.getColumnIndex("TransProdID")))){
                            eSaldos.put(cursor.getString(cursor.getColumnIndex("TransProdID")),cursor.getFloat(cursor.getColumnIndex("Saldo")) );
                        }
                        break;
                    case R.id.npCantidad:
                        EditText et = (EditText) view;
                        String clave = (cursor.getString(cursor.getColumnIndex("TransProdID")));
                        et.setTag(clave);
                        et.setFocusable(true);
                        et.setSelectAllOnFocus(true);
                        et.setClickable(false);
                        et.setFocusableInTouchMode(true);
                        et.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL | InputType.TYPE_CLASS_NUMBER);

                        et.setOnFocusChangeListener(new View.OnFocusChangeListener()
                        {
                            @Override
                            public void onFocusChange(View v, boolean hasFocus)
                            {
                                if (!hasFocus)
                                {
                                    EditText et = (EditText) v;

                                    if (et.getText().toString().equals("")){
                                        et.setText(String.valueOf(0f));
                                    }
                                    if(Float.parseFloat(et.getText().toString()) >0) {
                                        if (eSaldos.containsKey(et.getTag().toString())){
                                            if (Float.parseFloat(et.getText().toString())> eSaldos.get(et.getTag().toString())){
                                                errorDeCaptura = true;
                                                editTextError = et;
                                                mostrarError(Mensajes.get("E0038"),2);
                                                et.setText(String.valueOf(eSaldos.get(et.getTag().toString())));
                                                return;
                                            }
                                        }
                                    }

                                    if (eCantidades.containsKey(et.getTag().toString())){
                                        eCantidades.put(et.getTag().toString(), Float.parseFloat(et.getText().toString()));
                                    }else {
                                        if(Float.parseFloat(et.getText().toString()) >0) {
                                            eCantidades.put(et.getTag().toString(), Float.parseFloat(et.getText().toString()));
                                        }
                                    }

                                    //if (bMostrandoError) return;
                                    //if (cargando) return;
                                    totalAplicado = 0f;
                                    for (Map.Entry<String, Float> entry : eCantidades.entrySet()) {
                                        totalAplicado += entry.getValue();
                                    }
                                    etAplicado.setText(String.format("$ %.2f", totalAplicado));
                                    etPorAplicar.setText(String.format("$ %.2f", totalAbonos - totalAplicado));
                                }
                                else
                                {
                                    EditText et = (EditText) v;
                                    et.selectAll();
                                }

                            }
                        });

                        et.setOnKeyListener(new View.OnKeyListener() {
                            @Override
                            public boolean onKey(View v, int keyCode, KeyEvent event) {
                                switch (keyCode) {
                                    case KeyEvent.KEYCODE_ENTER:

                                        EditText et = (EditText) v;

                                        if (et.getText().toString().equals("")){
                                            et.setText(String.valueOf(0f));
                                        }
                                        if(Float.parseFloat(et.getText().toString()) >0) {
                                            if (eSaldos.containsKey(et.getTag().toString())){
                                                if (Float.parseFloat(et.getText().toString())> eSaldos.get(et.getTag().toString())){
                                                    errorDeCaptura = true;
                                                    editTextError = et;
                                                    mostrarError(Mensajes.get("E0038"),2);
                                                    et.setText(String.valueOf(eSaldos.get(et.getTag().toString())));
                                                    return false;
                                                }
                                            }
                                        }

                                        if (eCantidades.containsKey(et.getTag().toString())){
                                            eCantidades.put(et.getTag().toString(), Float.parseFloat(et.getText().toString()));
                                        }else {
                                            if(Float.parseFloat(et.getText().toString()) >0) {
                                                eCantidades.put(et.getTag().toString(), Float.parseFloat(et.getText().toString()));
                                            }
                                        }

                                        totalAplicado = 0f;
                                        for (Map.Entry<String, Float> entry : eCantidades.entrySet()) {
                                            totalAplicado += entry.getValue();
                                        }
                                        etAplicado.setText(String.format("$ %.2f", totalAplicado));
                                        etPorAplicar.setText(String.format("$ %.2f", totalAbonos - totalAplicado));
                                        return false;

                                    default:
                                        return false;
                                }
                            }
                        });

                        et.setOnTouchListener(new View.OnTouchListener()
                        {

                            @Override
                            public boolean onTouch(View v, MotionEvent event)
                            {
                                v.onTouchEvent(event);
                                ((EditText) v).selectAll();
                                return true;
                            }
                        });

                        break;
                }
            }catch(Exception ex){
                mostrarError(ex.getMessage());
            }
            return true;

        }
    }

    private class MySimpleCursorAdapter extends SimpleCursorAdapter
    {
        Cursor c;

        @SuppressWarnings("deprecation")
        public MySimpleCursorAdapter(Context context, int layout, Cursor c, String[] from, int[] to)
        {
            super(context, layout, c, from, to);
            this.c = c;
        }

        @Override
        public View getView(final int pos, View v, ViewGroup parent)
        {

                v = super.getView(pos, v, parent);

                Cursor c = ((SimpleCursorAdapter) ((ListView) parent).getAdapter()).getCursor();
                String clave = c.getString(c.getColumnIndex("TransProdID"));
                EditText et = (EditText)v.findViewWithTag(clave);
                if (eCantidades.containsKey(clave)){
                    if (et != null){
                        et.setText(eCantidades.get(clave).toString());
                    }
                }else {
                    et.setText(String.valueOf(0f));
                }
            return v;
        }

    }

}
