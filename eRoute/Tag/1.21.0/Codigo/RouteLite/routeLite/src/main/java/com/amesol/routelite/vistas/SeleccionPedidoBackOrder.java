package com.amesol.routelite.vistas;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.Point;
import android.os.Bundle;
import android.text.format.DateFormat;
import android.view.ContextMenu;
import android.view.Display;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.SeleccionarPedidoBackOrder;
import com.amesol.routelite.presentadores.interfaces.ICancelaPedido;
import com.amesol.routelite.presentadores.interfaces.ISeleccionPedidoBackOrder;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.PedidosBackOrderAdapter;

import java.util.HashMap;


public class SeleccionPedidoBackOrder extends Vista implements ISeleccionPedidoBackOrder
{

    SeleccionarPedidoBackOrder mPresenta;
    String mAccion;
    Vendedor oVendedor;
    SeleccionarPedidoBackOrder.VistaPedidos[] pedidos;
    ISetDatos fases;
    SeleccionarPedidoBackOrder.VistaPedidos pedidoC;
    boolean iniciarActividad;
    Class<?> actvdd;
    String codigoSolicita;
    String sTransProdIdSeleccionado;
    Cliente cliente;
    private boolean resultadoActividad = false;
    private TextView mTexto;
    private TransProd mTransProd;
    private String Cadena1 = "";
    private String Cadena2 = "";
    private int NumElemento = 0;
    private boolean bBuscandoFolio = false;
    private String sFacturaDev;
    boolean confirmarDescarga = false;
    boolean ConfirmarDevAlmacen = false;

    @SuppressWarnings("deprecation")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        try {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.seleccion_pedido_backorder);
            deshabilitarBarra(true);
            setTitulo(Mensajes.get("XBackOrder"));

            mTexto = (TextView) findViewById(R.id.lblRuta);
            mTexto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion);
            mTexto = (TextView) findViewById(R.id.lblDia);
            mTexto.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
            mTexto = (TextView) findViewById(R.id.lblCliente);
            cliente = (Cliente) Sesion.get(Campo.ClienteActual);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(cliente.Clave + " - " + cliente.RazonSocial);
            ListView lista = (ListView) findViewById(R.id.lstPedidos);
            registerForContextMenu(lista);

            oVendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
            iniciarActividad = false;

            actualizarVista();

            mPresenta = new SeleccionarPedidoBackOrder(this, mAccion);
            mPresenta.iniciar();
        } catch (Exception e) {
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
    }

    public void actualizarVista() {
        try {
            Visita visita = (Visita) Sesion.get(Campo.VisitaActual);
            pedidos = Consultas.ConsultasTransProd.obtenerPedidosBackOrder(visita, cliente);
            mostrarPedidosBOCliente(pedidos);
        } catch (Exception e) {
            mostrarError(e.getMessage());
        }
    }

    public void actualizarDetalles(String TransprodID, ListView lista) {
        try {
//            Dia dia = (Dia) Sesion.get(Campo.DiaActual);
//            Visita visita = (Visita) Sesion.get(Campo.VisitaActual);
            pedidos = Consultas.ConsultasTransProd.ObtenerDetallesBackOrder(TransprodID);
            mostrarDetallePedidosBOCliente(pedidos, lista);
        } catch (Exception e) {
            mostrarError(e.getMessage());
        }
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_backorder, menu);
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) menuInfo;
        ListView lista = (ListView) findViewById(R.id.lstPedidos);
        SeleccionarPedidoBackOrder.VistaPedidos pedido = (SeleccionarPedidoBackOrder.VistaPedidos) lista.getItemAtPosition((int) info.position);
        menu.setHeaderTitle(pedido.getFolio());
        menu.setHeaderIcon(android.R.drawable.ic_menu_agenda);

        menu.getItem(0).setTitle(Mensajes.get("XConsultar"));
        menu.getItem(0).setVisible(true);
        if (pedido.getTipoPedido() == Enumeradores.TipoPedido.BACKORDER) {
            menu.getItem(1).setTitle(Mensajes.get("XCancelar"));
            menu.getItem(1).setVisible(true);
            menu.getItem(2).setTitle(Mensajes.get("XConfirmar"));
            menu.getItem(2).setVisible(true);
        }
        else{
            menu.getItem(1).setVisible(false);
            menu.getItem(2).setVisible(false);
        }

    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
        ListView lista = (ListView) findViewById(R.id.lstPedidos);
        SeleccionarPedidoBackOrder.VistaPedidos pedido = (SeleccionarPedidoBackOrder.VistaPedidos) lista.getItemAtPosition((int) info.position);
        sTransProdIdSeleccionado = pedido.getTransprodID();
        MOTConfiguracion m = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
        pedidoC = pedido;
        switch (item.getItemId()) {
            case R.id.Consultar:
                ConsultarPedidoBackOrder(pedido);
                return true;
            case R.id.Cancelar:
                mostrarPreguntaSiNo(Mensajes.get("P0231"), 1);
                return true;
            case R.id.Confirmar:
                mostrarPreguntaSiNo(Mensajes.get("P0243").replace("$0$", "confirmar el pedido"), 2);
                return true;
        }
        return true;
    }

    public String getDescripcionFase(int TipoFase) {
        fases.moveToPosition(TipoFase);
        return fases.getString(2);
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event)
    {
        switch (keyCode){
            case KeyEvent.KEYCODE_BACK:
                finalizar();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }

    public void mostrarPedidosBOCliente(SeleccionarPedidoBackOrder.VistaPedidos[] pedidos) {
        ListView lista = (ListView) findViewById(R.id.lstPedidos);
        PedidosBackOrderAdapter adapter = new PedidosBackOrderAdapter(this, R.layout.lista_simple4, pedidos, 1);
        lista.setAdapter(adapter);

        if(resultadoActividad){
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        }
    }

    public void mostrarDetallePedidosBOCliente(SeleccionarPedidoBackOrder.VistaPedidos[] pedidos, ListView lista) {
        PedidosBackOrderAdapter adapter = new PedidosBackOrderAdapter(this, R.layout.lista_simple4, pedidos, 2);
        lista.setAdapter(adapter);

        if(resultadoActividad){
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        }
    }

    public SeleccionarPedidoBackOrder.VistaPedidos[] obtenerPedidos() {
        return pedidos;
    }

    @Override
    public void iniciar() {
    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data)
    {
//
        if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN){
        }
        else{
            if (data != null) {
                String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                if (mensajeError != null) {
                    this.mostrarError(mensajeError);
                }
            }
        }
    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
        try {
            if (tipoMensaje == 1 && respuesta == Enumeradores.RespuestaMsg.Si) { //cancelar el pedido
                mPresenta.cancelar(pedidoC);
                finalizar();
            }
            else if (tipoMensaje == 2 && respuesta == Enumeradores.RespuestaMsg.Si) {//confirmar pedido
                mPresenta.confirmar(pedidoC, cliente);
                finalizar();
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }

    public String getsTransProdIdSeleccionado() {
        return sTransProdIdSeleccionado;
    }

    private void ConsultarPedidoBackOrder(SeleccionarPedidoBackOrder.VistaPedidos pedido){
        try{
            LayoutInflater inflater = (LayoutInflater) this.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            View dialogView = inflater.inflate(R.layout.dialog_vista_backorder, null);
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.setPositiveButton("Aceptar", new DialogInterface.OnClickListener()
            {
                public void onClick(DialogInterface dialog, int id)
                {
                    dialog.dismiss();
                }
            });

            builder.setView(dialogView);
            final Dialog dialog = builder.create();
            dialog.show();

            TextView lblTituloGeneral = (TextView) dialogView.findViewById(R.id.lblTitulo);
            lblTituloGeneral.setText(Mensajes.get("XPedido")+": "+pedido.getFolio());

            TextView lblGenerales = (TextView) dialogView.findViewById(R.id.lblGenerales);
            lblGenerales.setText(Mensajes.get("XGrales"));

            TextView lblFase = (TextView) dialogView.findViewById(R.id.lblFase);
            TextView lblFolio = (TextView) dialogView.findViewById(R.id.lblFolio);
            TextView lblFecha = (TextView) dialogView.findViewById(R.id.lblFecha);
            TextView lblCliente = (TextView) dialogView.findViewById(R.id.lblCliente);

            lblFase.setText(Mensajes.get("XFase") + ": " + pedido.getFase());
            if (pedido.getTipoPedido() == Enumeradores.TipoPedido.BACKORDER)
                lblFolio.setVisibility(View.GONE);
            else
                lblFolio.setText(Mensajes.get("XFolio") + ": " + pedido.getFolioConfirmado());
            lblFecha.setText(Mensajes.get("XFecha") + ": " + pedido.getFecha());
            lblCliente.setText(Mensajes.get("XCliente") + ": " + cliente.ClienteClave + " - " + cliente.RazonSocial);

            TextView lblDetalle = (TextView) dialogView.findViewById(R.id.lblDetalle);
            lblDetalle.setText(Mensajes.get("MDBDetalle"));

            ListView lista = (ListView) dialogView.findViewById(R.id.LstDetallesBO);
            actualizarDetalles(pedido.getTransprodID(), lista);

        }catch(Exception e){
            mostrarError(e.getMessage());
            e.printStackTrace();
        }
    }

}
