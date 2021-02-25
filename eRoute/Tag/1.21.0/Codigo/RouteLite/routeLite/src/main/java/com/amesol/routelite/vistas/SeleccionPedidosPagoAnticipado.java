package com.amesol.routelite.vistas;

import android.app.AlertDialog;
import android.app.Dialog;
import android.app.SearchManager;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Color;
import android.os.Bundle;
import android.text.format.DateFormat;
import android.util.TypedValue;
import android.view.ContextMenu;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.SeleccionarPedidosPagoAnticipado;
import com.amesol.routelite.presentadores.act.SeleccionarVisita;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaPedidoAnticipado;
import com.amesol.routelite.presentadores.interfaces.ISeleccionPedidosPagoAnticipado;
import com.amesol.routelite.utilerias.Generales;

import java.text.SimpleDateFormat;
import java.util.HashMap;


/**
 * Created by projas on 30/09/2015.
 */
public class SeleccionPedidosPagoAnticipado extends Vista implements ISeleccionPedidosPagoAnticipado {
    String mAccion;
    ListView lista;
    SeleccionarPedidosPagoAnticipado mPresenta;

    String transProdIdSeleccionado = "";
    @SuppressWarnings("deprecation")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        try {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.seleccion_pedido);
            deshabilitarBarra(true);

            setTitulo(Mensajes.get("XPedidosPagoAnticipado"));

            TextView mTexto;

            mTexto = (TextView) findViewById(R.id.lblCliente);
            mTexto.setVisibility(View.GONE);
            Button btn = (Button) findViewById(R.id.btnContinuar);
            btn.setVisibility(View.GONE);

            mTexto = (TextView) findViewById(R.id.lblRuta);
            mTexto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Descripcion);
            mTexto = (TextView) findViewById(R.id.lblDia);
            mTexto.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);

            lista = (ListView) findViewById(R.id.lstPedidos);
            lista.setItemsCanFocus(false);
            registerForContextMenu(lista);

            mostrarDocumentos();

            mPresenta = new SeleccionarPedidosPagoAnticipado(this);
            //mPresenta.setParametros(oParametros);
            mPresenta.iniciar();

        }catch (Exception e){
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo)
    {
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) menuInfo;
        Cursor item = ((Cursor)lista.getItemAtPosition((int) info.position));
        //SeleccionarPedido.VistaPedidos pedido = (SeleccionarPedido.VistaPedidos) lista.getItemAtPosition((int) info.position);
        menu.setHeaderTitle(item.getString(item.getColumnIndex("Folio")));
        menu.setHeaderIcon(android.R.drawable.ic_menu_agenda);
        inflater.inflate(R.menu.context_pedidos_pago_anticipado, menu);
        try {
            MenuItem mItem = menu.findItem(R.id.cppa_consultar );
            if (mItem != null) {
                mItem.setVisible(true);
                mItem.setTitle(Mensajes.get("XConsultar"));
            }
            //Solo se puede cancelar cuando la fase es 1
            if (item.getInt(item.getColumnIndex("TipoFase")) == 1) {

                mItem = menu.findItem(R.id.cppa_cancelar );
                mItem.setTitle(Mensajes.get("XCancelar"));
                if (mItem != null) {
                    mItem.setVisible(true);
                }

                //Se le puede abonar si el Saldo >0
                mItem = menu.findItem(R.id.cppa_abonar);
                if ( mItem != null) {
                    if (Generales.getRound( item.getFloat(item.getColumnIndex("Saldo")),2)  > 0) {
                        mItem.setVisible(true);
                        mItem.setTitle(Mensajes.get("XAbonar"));
                    } else {
                        mItem.setVisible(false);
                    }
                }
                //Se le puede abonar si el Saldo >0
                mItem = menu.findItem(R.id.cppa_confirmar);
                if (mItem != null) {
                    if (Generales.getRound(item.getFloat(item.getColumnIndex("Saldo")),2) == Generales.getRound(item.getFloat(item.getColumnIndex("Total")),2) || Generales.getRound(item.getFloat(item.getColumnIndex("Saldo")),2) <= 0) {
                        mItem.setVisible(true);
                        mItem.setTitle(Mensajes.get("XConfirmar"));
                    } else {
                        mItem.setVisible(false);
                    }
                }

                //Solo si tiene abonos hechos en la jornada, te permite eliminarlos
                mItem = menu.findItem(R.id.cppa_eliminarAbonos);
                if (mItem != null) {
                    if (Consultas.ConsultasAbnTrp.tieneAbonosEnJornada(item.getString(item.getColumnIndex("_id")))) {
                        mItem.setVisible(true);
                        mItem.setTitle(Mensajes.get("XEliminar") + " " + Mensajes.get("XAbonos"));
                    } else {
                        mItem.setVisible(false);
                    }
                }
            } else {
                if (menu.findItem(R.id.cppa_cancelar) != null) {
                    menu.findItem(R.id.cppa_cancelar).setVisible(false);
                }
                if (menu.findItem(R.id.cppa_abonar) != null) {
                    menu.findItem(R.id.cppa_abonar).setVisible(false);
                }
                if (menu.findItem(R.id.cppa_confirmar) != null) {
                    menu.findItem(R.id.cppa_confirmar).setVisible(false);
                }
                if (menu.findItem(R.id.cppa_eliminarAbonos) != null) {
                    menu.findItem(R.id.cppa_eliminarAbonos).setVisible(false);
                }
            }
        }catch (Exception e){
            if (e!=null)
                mostrarError(e.getMessage());
            else
                mostrarError("Error de nulos");
            if (menu.findItem(R.id.cppa_cancelar) != null) {
                menu.findItem(R.id.cppa_cancelar).setVisible(false);
            }
            if (menu.findItem(R.id.cppa_abonar) != null) {
                menu.findItem(R.id.cppa_abonar).setVisible(false);
            }
            if (menu.findItem(R.id.cppa_confirmar) != null) {
                menu.findItem(R.id.cppa_confirmar).setVisible(false);
            }
            if (menu.findItem(R.id.cppa_eliminarAbonos) != null) {
                menu.findItem(R.id.cppa_eliminarAbonos).setVisible(false);
            }
        }
    }

    @Override
    public boolean onContextItemSelected(MenuItem item)
    {
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
        ListView lista = (ListView) findViewById(R.id.lstPedidos);
        Cursor itemPedido = ((Cursor)lista.getItemAtPosition((int) info.position));
        //sTransProdIdSeleccionado = pedido.getTransprodID();
        //MOTConfiguracion m = (MOTConfiguracion) Sesion.get(Sesion.Campo.MOTConfiguracion);
        switch (item.getItemId())
        {
            case R.id.cppa_consultar :
                consultar(itemPedido.getString(itemPedido.getColumnIndex("_id")),itemPedido.getString(itemPedido.getColumnIndex("Folio")),itemPedido.getShort(itemPedido.getColumnIndex("TipoFase")), itemPedido.getString(itemPedido.getColumnIndex("FechaCaptura")),itemPedido.getString(itemPedido.getColumnIndex("Clave")) + " - " + itemPedido.getString(itemPedido.getColumnIndex("RazonSocial")),itemPedido.getFloat(itemPedido.getColumnIndex("Total")), itemPedido.getFloat(itemPedido.getColumnIndex("Saldo")));
                return true;
            case R.id.cppa_cancelar :
                cancelar(itemPedido.getString(itemPedido.getColumnIndex("_id")), itemPedido.getString(itemPedido.getColumnIndex("Folio")));
                return true;
            case R.id.cppa_abonar:
                final HashMap<String, Object> parametros = new HashMap<String, Object>();
                parametros.put("TransProdId", itemPedido.getString(itemPedido.getColumnIndex("_id")));
                iniciarActividadConResultado(ICapturaCobranzaPedidoAnticipado.class, Enumeradores.Solicitudes.SOLICITUD_ABONO_DETALLE, Enumeradores.Acciones.ACCION_GENERAR_COBRANZA, parametros);
                return true;
            case R.id.cppa_eliminarAbonos:
                transProdIdSeleccionado= itemPedido.getString(itemPedido.getColumnIndex("_id"));
                mostrarPreguntaSiNo(Mensajes.get("P0243"," eliminar los abonos realizados al pedido durante la jornada de trabajo "),1);
                return true;
            case R.id.cppa_confirmar:
                transProdIdSeleccionado= itemPedido.getString(itemPedido.getColumnIndex("_id"));
                mostrarPreguntaSiNo(Mensajes.get("P0248"),2);
                return true;
        }
        return true;
    }
//Se pasan los datos como parametro porque ya se tienen en la vista; se pretende ahorrar consultas a la BD
    private void consultar(String transProdId, String folio, short tipoFase, String fechaCreacion, String cliente, Float total, Float saldo ){
        try
        {

            LayoutInflater inflater = (LayoutInflater) SeleccionPedidosPagoAnticipado.this
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

            View dialogView = inflater.inflate(R.layout.dialog_encabezado_detalle, null);

            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            TextView txt = (TextView) dialogView.findViewById(R.id.lblTituloDialogo);
            txt.setText(Mensajes.get("XPedido") + ": " + folio);

            txt = (TextView) dialogView.findViewById(R.id.lblTituloDialogoEncabezado );
            txt.setText(Mensajes.get("XGeneral"));
            float tamanoLetra =txt.getTextSize();

            LinearLayout llEncabezado = (LinearLayout) dialogView.findViewById(R.id.layoutDatosEncabezado);
            TextView lblFase = new TextView(this);
            lblFase.setTextAppearance(this, android.R.style.TextAppearance_DeviceDefault_Small);
            lblFase.setText(Mensajes.get("XFase") + ": " + ValoresReferencia.getValor("TRPFASE", String.valueOf(tipoFase)).getDescripcion());
            lblFase.setLayoutParams(new LinearLayout.LayoutParams (
                    LinearLayout.LayoutParams.MATCH_PARENT,
                    LinearLayout.LayoutParams.WRAP_CONTENT));
            llEncabezado.addView(lblFase);

            if (tipoFase == Enumeradores.TiposFasesDocto.CONFIRMADO_SAP){
                String sFolioSAP = Consultas.ConsultasPedidosConfirmadosSAP.obtenerFolioSAP(transProdId);
                TextView lblFolioSAP = new TextView(this);
                lblFolioSAP.setTextAppearance(this, android.R.style.TextAppearance_DeviceDefault_Small);
                lblFolioSAP.setText(Mensajes.get("XNpedidoSap") + ": " + sFolioSAP);
                lblFolioSAP.setLayoutParams(new LinearLayout.LayoutParams (
                        LinearLayout.LayoutParams.MATCH_PARENT,
                        LinearLayout.LayoutParams.WRAP_CONTENT));
                llEncabezado.addView(lblFolioSAP);
            }

            TextView lblFechaCreacion = new TextView(this);
            SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
            java.util.Date dt = sdf.parse(fechaCreacion);

            lblFechaCreacion.setText(Mensajes.get("ABNFechaCreacion") + ": " + DateFormat.format("dd/MM/yyyy", dt));
            lblFechaCreacion.setTextAppearance(this,  android.R.style.TextAppearance_DeviceDefault_Small);
            lblFechaCreacion.setLayoutParams(new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MATCH_PARENT,LinearLayout.LayoutParams.WRAP_CONTENT ));
            llEncabezado.addView(lblFechaCreacion);

            TextView lblCliente = new TextView(this);
            lblCliente.setText(Mensajes.get("XCliente") + ": " + cliente);
            lblCliente.setTextAppearance(this, android.R.style.TextAppearance_DeviceDefault_Small);
            lblCliente.setLayoutParams(new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MATCH_PARENT,LinearLayout.LayoutParams.WRAP_CONTENT ));
            llEncabezado.addView(lblCliente);

            TextView lblTotal = new TextView(this);
            lblTotal.setText(Mensajes.get("XTotalMin") + ": " + Generales.getFormatoDecimal(total,"$#,##0.00"));
            lblTotal.setTextAppearance(this, android.R.style.TextAppearance_DeviceDefault_Small);
            lblTotal.setLayoutParams(new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MATCH_PARENT,LinearLayout.LayoutParams.WRAP_CONTENT ));
            llEncabezado.addView(lblTotal);

            TextView lblSaldo = new TextView(this);
            lblSaldo.setTextAppearance(this, android.R.style.TextAppearance_DeviceDefault_Small);
            lblSaldo.setText(Mensajes.get("XSaldo") + ": " + Generales.getFormatoDecimal(saldo, "$#,##0.00"));
            lblSaldo.setLayoutParams(new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MATCH_PARENT,LinearLayout.LayoutParams.WRAP_CONTENT ));
            llEncabezado.addView(lblSaldo);

            ISetDatos descuentos =  Consultas.ConsultasPedidosConfirmadosSAP.obtenerSubtotalDescuento(transProdId);
            float subtotal = 0;
            float desc1 = 0;
            float desc2 = 0;

            if(descuentos.moveToNext())
            {
                subtotal = descuentos.getFloat(0);
                desc1 = descuentos.getFloat(1);
                desc2 = descuentos.getFloat(2);
            }

            desc1 = ((subtotal * desc1) / 100);
            desc2 = ((subtotal * desc2) / 100);

            TextView lblPagoAnticipado = new TextView(this);
            lblPagoAnticipado.setTextAppearance(this, android.R.style.TextAppearance_DeviceDefault_Small);
            lblPagoAnticipado.setText(Mensajes.get("XDescPagoAnticipado") + ": " + Generales.getFormatoDecimal((desc1 + desc2), "$#,##0.00"));
            lblPagoAnticipado.setLayoutParams(new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MATCH_PARENT,LinearLayout.LayoutParams.WRAP_CONTENT ));
            llEncabezado.addView(lblPagoAnticipado);

            txt = (TextView) dialogView.findViewById(R.id.lblTituloDialogoDetalle );
            txt.setText(Mensajes.get("XDetalle"));

            ListView modeList = (ListView) dialogView.findViewById(R.id.lstDetalle);
            modeList.setBackgroundColor(Color.WHITE);
            ISetDatos tpd = Consultas.ConsultasTransProdDetalle.obtenerDetallePedidoPagoAnticipado(transProdId);

            if (tpd != null){
                SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.elemento_detalle_pedidopagoanticipado,((Cursor) tpd.getOriginal()), new String[]
                        { "ProductoClave", "Cantidad", "TipoUnidad","Precio2","Importe2"}, new int[]
                        {R.id.lblDescripcion, R.id.lblCantidad, R.id.lblPU, R.id.lblPrecioAnticipado, R.id.lblImporteAnticipado});
                adapter.setViewBinder(new vistaDetalle());
                modeList.setAdapter(adapter);
            }

            builder.setPositiveButton(Mensajes.get("XContinuar"), new DialogInterface.OnClickListener()
            {
                public void onClick(DialogInterface dialog, int id)
                {

                    dialog.dismiss();
                }
            });
            builder.setView(dialogView);
            final Dialog dialog = builder.create();

            dialog.show();

        }
        catch (Exception ex)
        {
            mostrarError(ex.getMessage());
        }
    }

    private void cancelar(final String transProdId, String folio){
        LayoutInflater inflater = (LayoutInflater) SeleccionPedidosPagoAnticipado.this
                .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

        View dialogView = inflater.inflate(R.layout.dialog_cancelar_movimiento, null);

        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        TextView txt = (TextView) dialogView.findViewById(R.id.lblTituloDialogo);
        txt.setText(Mensajes.get("XCancelar"));

        txt = (TextView) dialogView.findViewById(R.id.lblFolio );
        txt.setText(folio);

        txt = (TextView) dialogView.findViewById(R.id.lblRuta);
        txt.setText(Mensajes.get("XRuta") + ": " + ((Ruta)Sesion.get(Sesion.Campo.RutaActual)).RUTClave + " - " + ((Ruta)Sesion.get(Sesion.Campo.RutaActual)).Descripcion);

        txt = (TextView) dialogView.findViewById(R.id.lblDia);
        txt.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia)Sesion.get(Sesion.Campo.DiaActual)).DiaClave);

        txt = (TextView) dialogView.findViewById(R.id.lblMotivo);
        txt.setText(Mensajes.get("XMotivo"));

        final Spinner spinMotivo = (Spinner) dialogView.findViewById(R.id.cmbMotivoCancela);
        //Spinner spin = new Spinner(this);
        try {
            ISetDatos motivos = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT", "'Cancelacion'", Mensajes.get("XSeleccionar", new String[]
                    {Mensajes.get("XMotivo")}), false);

            Cursor valores = (Cursor) motivos.getOriginal();
            startManagingCursor(valores);
            if (motivos.getCount() <= 1) //si no hay motivos, mostrar deshabilitado
                spinMotivo.setEnabled(false);
            else {
                SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, valores,
                        new String[]
                                {SearchManager.SUGGEST_COLUMN_TEXT_1},
                        new int[]
                                {android.R.id.text1});
                adapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
                spinMotivo.setAdapter(adapter);
                //spin.setLayoutParams(new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MATCH_PARENT,LinearLayout.LayoutParams.WRAP_CONTENT ));
            }
        }catch(Exception ex){
            if (ex != null){
                mostrarError(ex.getMessage());
            }else{
                mostrarError("Error de nulos");
            }
        }

        builder.setPositiveButton(Mensajes.get("XContinuar"), new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int id) {
                if(getTipoMotivo(spinMotivo)<=0 ){ //No selecciono motivo
                    mostrarError(Mensajes.get("E0161", Mensajes.get("XMotivo")));
                }else{
                    try{
                        if (mPresenta.cancelarPedido(transProdId, getTipoMotivo(spinMotivo))){
                            BDVend.commit();
                            mostrarDocumentos();
                        }else{
                            BDVend.rollback();
                        }

                    }catch (Exception ex){
                        try{
                            BDVend.rollback();
                        }catch(Exception e){

                        }
                        if (ex != null){
                            mostrarError(ex.getMessage());
                        }else{
                            mostrarError("Error de nulos");
                        }
                    }
                    dialog.dismiss();
                }
            }
        });

        builder.setNegativeButton(Mensajes.get("XCancelar"), new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int id) {

                dialog.dismiss();
            }
        });


        builder.setView(dialogView);
        final Dialog dialog = builder.create();

        dialog.show();

    }


        @Override
    public void iniciar()
    {

    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {
        if (requestCode == Enumeradores.Solicitudes.SOLICITUD_ABONO_DETALLE) {
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN){
                mostrarDocumentos();
            }
        }
    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje)
    {
        if (tipoMensaje == 1){//Eliminar abonos
            if (respuesta == Enumeradores.RespuestaMsg.Si){
                try {
                    if(transProdIdSeleccionado.length()>0) {
                        Cobranza.eliminarPagoAnticipado(transProdIdSeleccionado);
                        transProdIdSeleccionado = "";
                        mostrarDocumentos();
                    }
                }catch (NullPointerException nullEx){
                    mostrarError("Eliminar Pago Anticipado: Nulos ");
                }catch (Exception ex){
                    mostrarError("Eliminar Pago Anticipado: " + ex.getMessage());
                }
            }
        }else if (tipoMensaje == 2){//Confirmar Pedido
            if (respuesta == Enumeradores.RespuestaMsg.Si){
                try {
                    if(transProdIdSeleccionado.length()>0) {
                        mPresenta.confirmarPedido(transProdIdSeleccionado);
                    }
                }catch (Exception ex){
                    mostrarError(ex.getMessage());
                }
            }
        }
    }

    public void mostrarDocumentos() {

        try
        {
            boolean existe = false;
            if (lista.getAdapter() != null){
                stopManagingCursor(((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())));
                ((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())).close();
                existe = true;
            }
            ISetDatos stPedidosPagoAnticipado= Consultas.ConsultasTransProd.obtenerPedidosPagoAnticipado();

            Cursor cPedidos = (Cursor) stPedidosPagoAnticipado.getOriginal();
            startManagingCursor(cPedidos);
            try
            {
                SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_docs_pagoanticipado, cPedidos, new String[]
                        { "Folio", "TipoFase", "FechaCaptura", "Clave","Total", "Saldo"}, new int[]
                        { R.id.txtFolio, R.id.txtFase, R.id.txtFechaCreacion, R.id.txtCliente, R.id.txtTotal, R.id.txtSaldo});
                adapter.setViewBinder(new vista());
                lista.setAdapter(adapter);

                lista.setOnItemClickListener(new AdapterView.OnItemClickListener()
                                             {

                                                 public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
                                                 {

                                                 }
                                             }
                );


                stopManagingCursor(cPedidos);
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

    public short getTipoMotivo(Spinner spin)
    {
        //Spinner spin = (Spinner) findViewById(R.id.cmbMotivoCancela);
        if (spin.isEnabled())
            return (short) spin.getSelectedItemId();
        else
            return 0;
    }

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

    @Override
    public void onDestroy()
    {
        super.onDestroy();
        if (lista.getAdapter() != null){
            stopManagingCursor(((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())));
            ((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())).close();
        }
    }

    private class vista implements SimpleCursorAdapter.ViewBinder
    {

        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex)
        {
            int viewId = view.getId();
            switch (viewId)
            {
                case R.id.txtFolio: // para llenar el combo
                    TextView txtFolio = (TextView) view;
                    txtFolio.setText(cursor.getString(cursor.getColumnIndex("Folio")));
                    break;
                case R.id.txtFase: // para llenar el combo
                    TextView txtFase = (TextView) view;
                    txtFase.setText(Mensajes.get("XFase") + ": " + ValoresReferencia.getDescripcion("TRPFASE", cursor.getString(cursor.getColumnIndex("TipoFase"))));
                    break;
                case R.id.txtFechaCreacion:
                    try {
                        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
                        java.util.Date dt = sdf.parse(cursor.getString(cursor.getColumnIndex("FechaCaptura"))); //replace 4 with the column index
                        // Date fechaCaptura = new Date( );
                        TextView txtFechaCreacion = (TextView) view;
                        //Generales.getFormatoFecha()
                        txtFechaCreacion.setText(Mensajes.get("ABNFechaCreacion") + ": " + DateFormat.format("dd/MM/yyyy", dt));
                    }catch(Exception e){
                        if (e==null){
                            mostrarError("Error de nulos");
                        }else{
                            mostrarError(e.getMessage());
                        }
                    }
                    break;
                case R.id.txtCliente:
                    TextView txtCliente = (TextView) view;
                    txtCliente.setText(Mensajes.get("XCliente") +  ": " +  cursor.getString(cursor.getColumnIndex("Clave")) + "-" + cursor.getString(cursor.getColumnIndex("RazonSocial")));
                    break;
                case R.id.txtTotal:
                    TextView txtTotal = (TextView) view;
                    txtTotal.setText(Mensajes.get("XTotalMin") + ": " + Generales.getFormatoDecimal(cursor.getFloat(cursor.getColumnIndex("Total")) ,"$#,##0.00"));
                    break;
                case R.id.txtSaldo:
                    TextView txtSaldo = (TextView) view;
                    txtSaldo.setText(Mensajes.get("XSaldo") + ": " + Generales.getFormatoDecimal(cursor.getFloat(cursor.getColumnIndex("Saldo")) ,"$#,##0.00"));
                    break;
                default:
                    TextView texto = (TextView) view;
                    texto.setText(cursor.getString(columnIndex));
                    break;
            }
            return true;
        }
    }

    private class vistaDetalle implements SimpleCursorAdapter.ViewBinder
    {

        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex)
        {
            try {
                int viewId = view.getId();
                switch (viewId) {
                    case R.id.lblDescripcion: // para llenar el combo
                        TextView txtFolio = (TextView) view;
                        txtFolio.setText(cursor.getString(cursor.getColumnIndex("ProductoClave")) + " - " + cursor.getString(cursor.getColumnIndex("Descripcion")));
                        break;
                    case R.id.lblCantidad: // para llenar el combo
                        TextView txtFase = (TextView) view;
                        txtFase.setText(Generales.getFormatoDecimal(cursor.getFloat(cursor.getColumnIndex("Cantidad")), cursor.getInt(cursor.getColumnIndex("DecimalProducto"))));
                        break;
                    case R.id.lblPU:
                        TextView txtCliente = (TextView) view;
                        txtCliente.setText(ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(cursor.getInt(cursor.getColumnIndex("TipoUnidad")))));
                        break;
                    default:
                        TextView texto = (TextView) view;
                        texto.setText(cursor.getString(columnIndex));
                        break;
                }
            }catch(Exception ex){
                if (ex != null) {
                    mostrarError(ex.getMessage());
                }else{
                    mostrarError ("Error de nulos");
                }
            }
            return true;
        }
    }
}
