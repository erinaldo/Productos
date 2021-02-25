package com.amesol.routelite.vistas;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.HistoricosEstadisticas;
import com.amesol.routelite.presentadores.interfaces.IHistoricoEstadisticas;

import java.util.HashMap;

public class HistoricoEstadisticas extends Vista implements IHistoricoEstadisticas {

    HistoricosEstadisticas mPresenta;
    String mAccion;
    private ListView mLvEstadisticas = null;
    private String sTransprods;
    private Integer NoDocumentos;

    @SuppressWarnings("deprecation")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        try {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.consulta_historico_ventas_estadisticas);
            deshabilitarBarra(true);
            setTitulo(Mensajes.get("ERMHIS_FormHistoricoVtasE"));

            TextView mTexto;
            mTexto = (TextView) findViewById(R.id.txtCol1);
            mTexto.setVisibility(View.GONE);

            mTexto = (TextView) findViewById(R.id.txtCol2);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(Mensajes.get("XProducto"));
            mTexto.setGravity(Gravity.CENTER);
            ViewGroup.LayoutParams param = mTexto.getLayoutParams();
            param.width = 100;
            mTexto.setLayoutParams(param);

            mTexto = (TextView) findViewById(R.id.txtCol3);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(Mensajes.get("XUnidad"));
            mTexto.setGravity(Gravity.CENTER);

            mTexto = (TextView) findViewById(R.id.txtCol4);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(Mensajes.get("XPromedio"));
            mTexto.setGravity(Gravity.CENTER);

            mTexto = (TextView) findViewById(R.id.txtCol5);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(Mensajes.get("HISModa"));
            mTexto.setGravity(Gravity.CENTER);

            mTexto = (TextView) findViewById(R.id.txtCol6);
            mTexto.setVisibility(View.GONE);

            mLvEstadisticas = (ListView) findViewById(R.id.lv_ventas);
            mLvEstadisticas.setItemsCanFocus(false);
            registerForContextMenu(mLvEstadisticas);

            HashMap<String, Object> oParametros = null;
            if (getIntent().getSerializableExtra("parametros") != null)
            {
                oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
            }
            if (oParametros != null)
            {
                sTransprods = oParametros.get("Transprods").toString();
                NoDocumentos = (Integer) oParametros.get("NoDocumentos");
            }

            mPresenta = new HistoricosEstadisticas(this, mAccion);
            mPresenta.iniciar();
        } catch (Exception e) {
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
    }

    @Override
    public void iniciar() {
    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {
    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
    }

    private void salir() {
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        switch (keyCode) {
            case KeyEvent.KEYCODE_BACK:
                salir();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }

    @Override
    @SuppressWarnings("deprecation")
    public void ActualizaLVEstadisticas(){
        try{
            ISetDatos stTransProdDetalle = Consultas.ConsultaHistoricoVentas.obtenerEstadisticas(sTransprods,NoDocumentos);
            Cursor cProductos = (Cursor) stTransProdDetalle.getOriginal();
            startManagingCursor(cProductos);
            try{
                SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple_hor6, cProductos, new String[]
                        { "_id", "Producto", "Unidad", "Promedio", "Moda" }, new int[]
                        { R.id.txtCol1, R.id.txtCol2, R.id.txtCol3, R.id.txtCol4, R.id.txtCol5 });
                adapter.setViewBinder(new vistaEstadisticas());
                mLvEstadisticas.setAdapter(adapter);
            }catch (Exception e){
                mostrarError(e.getMessage());
            }
        }catch (Exception ex){
            mostrarError(ex.getMessage());
        }
    }

    private class vistaEstadisticas implements SimpleCursorAdapter.ViewBinder{
        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex){
            int viewId = view.getId();
            switch (viewId){
                case R.id.txtCol1:
                    TextView combo = (TextView) view;
                    combo.setText(cursor.getString(cursor.getColumnIndex("_id")));
                    combo.setVisibility(View.GONE);
                    break;
                case R.id.txtCol2:
                    combo = (TextView) view;
                    combo.setText(cursor.getString(cursor.getColumnIndex("Producto")));
                    ViewGroup.LayoutParams param = combo.getLayoutParams();
                    param.width = 100;
                    combo.setLayoutParams(param);
                    combo.setMaxLines(2);
                    break;
                case R.id.txtCol3:
                    view.setVisibility(View.VISIBLE);
                    combo = (TextView) view;
                    String mUnidad = ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("Unidad")));
                    combo.setText(mUnidad);
                    combo.setGravity(Gravity.RIGHT);
                    break;
                case R.id.txtCol4:
                    view.setVisibility(View.VISIBLE);
                    combo = (TextView) view;
                    combo.setText(cursor.getString(cursor.getColumnIndex("Promedio")));
                    combo.setGravity(Gravity.RIGHT);
                    break;
                case R.id.txtCol5:
                    view.setVisibility(View.VISIBLE);
                    combo = (TextView) view;
                    combo.setText(cursor.getString(cursor.getColumnIndex("Moda")));
                    combo.setGravity(Gravity.CENTER);
                    break;
                case R.id.txtCol6:
                    view.setVisibility(View.GONE);
                    break;
                default:
                    TextView texto = (TextView) view;
                    texto.setText(cursor.getString(columnIndex));
                    break;
            }
            return true;
        }
    }
}
