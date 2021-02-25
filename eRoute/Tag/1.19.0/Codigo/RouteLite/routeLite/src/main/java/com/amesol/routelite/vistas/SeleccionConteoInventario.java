package com.amesol.routelite.vistas;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.KeyEvent;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.SeleccionarConteoInventario;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;
import com.amesol.routelite.presentadores.interfaces.ISeleccionConteoInventario;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.PedidosAdapter;

public class SeleccionConteoInventario  extends Vista implements ISeleccionConteoInventario {
    SeleccionarConteoInventario mPresenta;
    String mAccion;

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        try
        {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.seleccion_transaccion);
            deshabilitarBarra(true);

            lblTitle.setText(Mensajes.get("XAConteoInv"));
            Button btn = (Button) findViewById(R.id.btnContinuar);
            btn.setVisibility(View.GONE);

            TextView mTexto;
            mTexto = (TextView) findViewById(R.id.lblRuta);
            mTexto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Descripcion);
            mTexto = (TextView) findViewById(R.id.lblDia);
            mTexto.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);
            mTexto = (TextView) findViewById(R.id.lblCliente);
            mTexto.setVisibility(View.GONE);

            ListView lista = (ListView) findViewById(R.id.lstTransaccion);
            lista.setOnItemClickListener(mSeleccion);
            registerForContextMenu(lista);

            mPresenta = new SeleccionarConteoInventario(this, mAccion);
            mPresenta.iniciar();
        }
        catch (Exception e)
        {
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


    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo)
    {
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.context_manto_conteo_inventario, menu);
        menu.getItem(0).setTitle(Mensajes.get("XEliminar"));
    }


    @Override
    public boolean onContextItemSelected(MenuItem item)
    {
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
        ListView lista = (ListView) findViewById(R.id.lstTransaccion);
        Cursor mercadeo = (Cursor) lista.getItemAtPosition((int) info.position);
        mercadeo.moveToPosition((int)info.position);
        //sMRDIdSeleccionado = mercadeo.getString(mercadeo.getColumnIndex("_id"));
        switch (item.getItemId()) {
            case R.id.eliminar:
                mostrarPreguntaSiNo(Mensajes.get("P0001"), 9);
                return true;
        }
        return true;
    }

    private AdapterView.OnItemClickListener mSeleccion = new AdapterView.OnItemClickListener()
    {
        public void onItemClick(AdapterView<?> parent, View v, int position, long id)
        {

        }
    };

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event)
    {
        switch (keyCode)
        {
            case KeyEvent.KEYCODE_BACK:
                this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                this.finalizar();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }

    public void mostrarConteosInventario(ISetDatos sdConteosInventario) {
        ListView lista = (ListView) findViewById(R.id.lstTransaccion);
        Cursor cProductos = (Cursor) sdConteosInventario.getOriginal();
        startManagingCursor(cProductos);
        try {

            SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple3, cProductos, new String[]
                    {"Nombre", "TipoFase", "FechaHoraAlta"}, new int[]
                    {R.id.texto1, R.id.texto2, R.id.texto3});
            adapter.setViewBinder(new vista());
            lista.setAdapter(adapter);

               /* lista.setOnItemClickListener(new AdapterView.OnItemClickListener()
                                             {

                                                 public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
                                                 {
                                                     Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
                                                     lista.requestFocusFromTouch();
                                                     lista.setSelection(pos);
                                                     // Se crea el objeto producto con lo que se trae en la
                                                     // consulta para eficientar tiempos.
                                                     Producto oProducto = new Producto();
                                                     oProducto.ProductoClave = producto.getString(producto.getColumnIndex("ProductoClave"));
                                                     oProducto.Nombre = producto.getString(producto.getColumnIndex("Descripcion"));
                                                     //oProducto.SubEmpresaId = producto.getString(producto.getColumnIndex("SubEmpresaId"));
                                                     //oProducto.Venta = ((producto.getShort(producto.getColumnIndex("Venta")) == 1) ? true : false);
                                                     //oProducto.Contenido = ((producto.getShort(producto.getColumnIndex("Contenido")) == 1) ? true : false);
                                                     llenarProductoUnidad(oProducto, producto.getInt(producto.getColumnIndex("TipoUnidad")), producto.getFloat(producto.getColumnIndex("Inventario")), producto.getFloat(producto.getColumnIndex("PEntregado")));
                                                 }
                                             }
                );*/

            stopManagingCursor(cProductos);
        } catch (Exception e) {
            mostrarError(e.getMessage());
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
                    case R.id.texto2:
                        TextView tipoFase = (TextView) view;
                        if (cursor.getColumnName(columnIndex).equalsIgnoreCase("TipoFase")) { // tipo unidad
                            tipoFase.setText(Mensajes.get("XFase") + ": " + ValoresReferencia.getDescripcion("TMOVFASE", cursor.getString(cursor.getColumnIndex("TipoFase"))));
                        }
                        break;
                    case R.id.texto3:
                        TextView fecha = (TextView) view;
                        fecha.setText(Mensajes.get("XFecha") + ": " + cursor.getString(columnIndex));
                        break;
                    case R.id.texto1:
                        TextView titulo = (TextView) view;
                        titulo.setText(Mensajes.get("XRegistroConteo"));
                         break;
                    default:
                        TextView texto = (TextView) view;
                        texto.setVisibility(View.GONE);
                        break;
                }
            }catch(Exception ex){
                mostrarError(ex.getMessage());
            }
            return true;

        }
    }
}
