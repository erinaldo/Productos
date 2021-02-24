package com.elephantworks.movilvennda.Vistas;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.SearchView;
import android.widget.TextView;

import com.elephantworks.movilvennda.Adaptadores.ConsultaDevolucionAdapter;
import com.elephantworks.movilvennda.Adaptadores.ConsultaVentaAdapter;
import com.elephantworks.movilvennda.Adaptadores.VentasAdapter;
import com.elephantworks.movilvennda.Interfaces.IConsultarVentas;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.Devolucion;
import com.elephantworks.movilvennda.Modelos.Venta;
import com.elephantworks.movilvennda.Presentadora.PresentadorConsultaVentas;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.BTPrinter;
import com.elephantworks.movilvennda.Utilerias.Constantes;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;

public class ConsultarVentas extends AppCompatActivity implements IConsultarVentas, SearchView.OnQueryTextListener {

    private PresentadorConsultaVentas mPresentador;
    private Context context = ConsultarVentas.this;
    ListView lvConsultaVentas;
    RadioButton rbContado;
    RadioButton rbCredito;
    RadioButton rbAmbos;
    RadioButton rbDevoluciones;
    SearchView searchView;
    int tipoBusqueda;
    int lvVista = 0;
    private Venta venta;
    private int idVenta;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_consultar_ventas);

        mPresentador = new PresentadorConsultaVentas(this, context);
        lvConsultaVentas = (ListView) findViewById(R.id.lvConsultarVentas);
        registerForContextMenu(lvConsultaVentas);
        searchView = (SearchView) findViewById(R.id.busquedaVentas);
        searchView.setIconifiedByDefault(false);
        searchView.setOnQueryTextListener(this);
        searchView.setSubmitButtonEnabled(true);
        searchView.setQueryHint(getResources().getString(R.string.txtBuscarClientes));

        rbContado = (RadioButton) findViewById(R.id.rbContado);
        rbCredito = (RadioButton) findViewById(R.id.rbCredito);
        rbDevoluciones = (RadioButton) findViewById(R.id.rbDevoluciones);
        rbAmbos = (RadioButton) findViewById(R.id.rbAmbos);

        tipoBusqueda = Constantes.TipoVenta.AMBAS;

        rbContado.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                if(b){
                    tipoBusqueda = Constantes.TipoVenta.CONTADO;
                    mPresentador.cargarLista(tipoBusqueda);
                }
            }
        });

        rbCredito.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                if(b){
                    tipoBusqueda = Constantes.TipoVenta.CREDITO;
                    mPresentador.cargarLista(tipoBusqueda);
                }
            }
        });

        rbDevoluciones.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                if(b){
                    tipoBusqueda = Constantes.TipoVenta.DEVOLUCION;
                    mPresentador.cargarLista(tipoBusqueda);
                }
            }
        });

        rbAmbos.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                if(b){
                    tipoBusqueda = Constantes.TipoVenta.AMBAS;
                    mPresentador.cargarLista(tipoBusqueda);
                }
            }
        });

        mPresentador.cargarLista(tipoBusqueda);
    }

    @Override
    public void cargarLista(ConsultaVentaAdapter adapter) {
        lvVista = 0;
        lvConsultaVentas.setAdapter(adapter);
    }

    @Override
    public void cargarListaDevolucion(ConsultaDevolucionAdapter adapter) {
        lvVista = 1;
        lvConsultaVentas.setAdapter(adapter);
    }

    @Override
    public void error(String mensaje) {
        MetodosEstaticos.AlertDialogSimple(context, mensaje);
    }

    @Override
    public boolean onQueryTextSubmit(String s) {
        mPresentador.cargarLista(tipoBusqueda,s);
        return false;
    }

    @Override
    public boolean onQueryTextChange(String s) {
        mPresentador.cargarLista(tipoBusqueda,s);
        return false;
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo)
    {
        super.onCreateContextMenu(menu,v,menuInfo);
        MenuInflater inflater = new MenuInflater(this);

        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) menuInfo;
        Venta venta = null;
        if(lvVista == 0){
            venta = (Venta) lvConsultaVentas.getItemAtPosition((int) info.position);
        }

        switch(v.getId()){
            case R.id.lvConsultarVentas:
                inflater.inflate(R.menu.menu_consulta_ventas, menu);
                if(venta != null) {
                    if (venta.getTipo() == Constantes.TipoVenta.CONTADO) {
                        menu.getItem(1).setVisible(false);
                    }
                }
                if(lvVista == 1){
                    menu.getItem(0).setVisible(false);
                    menu.getItem(1).setVisible(false);
                    menu.getItem(2).setVisible(false);
                }
                break;
        }
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterView.AdapterContextMenuInfo info = null;
        Venta venta = null;
        if (item.getMenuInfo() != null) {
            info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
            venta = (Venta) lvConsultaVentas.getItemAtPosition((int) info.position);
        }

        switch (item.getItemId()) {
            case R.id.cancelarVenta:
                this.cancelarVenta(venta);
                return true;
            case R.id.cobranzaVenta:
                this.abonarVenta(venta);
                return true;
            case R.id.imprimirTicket:
                if(MetodosEstaticos.getImpresoraConfiguracion(context)) {
                    idVenta = venta.getIdVenta();
                    this.venta = venta;
                    imprimirTicket("", "", 2);
                }else {
                    //Todo Cambiar el texto por string
                    MetodosEstaticos.AlertDialogSimple(context, "No hay impresora configurada desde la web o desde la aplicacion.");
                }
                return true;
        }

        return false;
    }

    public void cancelarVenta(final Venta venta){

        LayoutInflater inflater = ((Activity) context).getLayoutInflater();
        View dialoglayout = inflater.inflate(R.layout.dialogo_cancelar_venta, null);
        final AlertDialog.Builder builder = new AlertDialog.Builder(context);
        builder.setView(dialoglayout);
        final AlertDialog dialog = builder.show();

        Button btnAceptar = (Button) dialoglayout.findViewById(R.id.btnAceptarCancelacion);
        final EditText etMotivo = (EditText) dialoglayout.findViewById(R.id.etMotivoCancelacion);
        final EditText etUsuario = (EditText) dialoglayout.findViewById(R.id.etNumEmpleadoVentaCancelacion);
        final EditText etPin = (EditText) dialoglayout.findViewById(R.id.etPinCancelacion);

        btnAceptar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String usuario = etUsuario.getText().toString();
                String pin = etPin.getText().toString();
                String motivo = etMotivo.getText().toString();
                String mensaje = mPresentador.validarUsuario(usuario, pin);
                if(mensaje.equals("")){
                    if (mPresentador.tieneAbono((venta.getSaldo() > 0), venta)){
                        mPresentador.cancelarVenta(venta,motivo);
                        mPresentador.cargarLista(Constantes.TipoVenta.AMBAS);
                        dialog.dismiss();
                    }else {
                        MetodosEstaticos.AlertDialogSimple(context, getResources().getString(R.string.msjVentaConAbonos) );
                    }
                }else {
                    MetodosEstaticos.AlertDialogSimple(context, mensaje);
                    etUsuario.setText("");
                    etPin.setText("");
                }
            }
        });

    }

    public void abonarVenta(final Venta venta){

        idVenta = venta.getIdVenta();

        LayoutInflater inflater = ((Activity) context).getLayoutInflater();
        View dialoglayout = inflater.inflate(R.layout.dialogo_abono, null);
        final AlertDialog.Builder builder = new AlertDialog.Builder(context);
        builder.setView(dialoglayout);
        final AlertDialog dialog = builder.show();

        Button btnAceptar = (Button) dialoglayout.findViewById(R.id.btnAceptarAbonoDlg);
        final TextView txtSaldoAbono = (TextView) dialoglayout.findViewById(R.id.txtSaldoAbono);
        final EditText etReferencia = (EditText) dialoglayout.findViewById(R.id.etReferenciaAbono);
        final EditText etMonto = (EditText) dialoglayout.findViewById(R.id.etMontoAbono);
        final RadioButton rbContado = (RadioButton) dialoglayout.findViewById(R.id.rbContadoAbono);
        final RadioButton rbCredito = (RadioButton) dialoglayout.findViewById(R.id.rbCreditoAbono);

        txtSaldoAbono.setText(MetodosEstaticos.getFormatoDecimal(venta.getSaldo(), "###0.00"));

        btnAceptar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(!etMonto.getText().toString().equals("")){
                    if(realizarAbono(etReferencia.getText().toString(), etMonto.getText().toString(), rbCredito.isChecked(), venta)){
                        dialog.dismiss();
                    }
                }else {
                    MetodosEstaticos.AlertDialogSimple(context,context.getResources().getString(R.string.msjErrorMonto));
                }
            }
        });

        etMonto.setOnKeyListener(new View.OnKeyListener() {
            @Override
            public boolean onKey(View view, int keyCode, KeyEvent event) {
                if ((event.getAction() == KeyEvent.ACTION_DOWN) && (keyCode == KeyEvent.KEYCODE_ENTER)) {
                    if(!etMonto.getText().toString().equals("")){
                        if(realizarAbono(etReferencia.getText().toString(), etMonto.getText().toString(), rbCredito.isChecked(), venta)){
                            dialog.dismiss();
                        }
                        return true;
                    }else {
                        MetodosEstaticos.AlertDialogSimple(context, context.getResources().getString(R.string.msjErrorMonto));
                        return false;
                    }
                }
                return false;
            }
        });
    }


    public void imprimirTicket(final String recibido, final String metodo, final int recibo){
        if(MetodosEstaticos.getImpresoraConfiguracion(context)) {
            AlertDialog.Builder dialogo1 = new AlertDialog.Builder(context);
            dialogo1.setTitle(context.getResources().getString(R.string.dialog_advertencia));
            dialogo1.setMessage(context.getResources().getString(R.string.msjImprimirTicket));
            dialogo1.setCancelable(false);
            dialogo1.setPositiveButton("Confirmar", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialogo1, int id) {

                    BTPrinter btPrinter = new BTPrinter(context, ConsultarVentas.this);
                    btPrinter.conectar();
                    if (recibo == 1) {
                        btPrinter.generateTicketAbono(idVenta, recibido, metodo);
                    } else if (recibo == 2) {
                        //todo cambiar por string texto
                        String metodo = (venta.getTipo() == 1 ? "Contado" : "Credito");
                        btPrinter.generateTicketVenta(idVenta,metodo);
                    }

                    btPrinter.cerrarSocket();

                }
            });
            dialogo1.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialogo1, int id) {
                    dialogo1.dismiss();
                }
            });
            dialogo1.show();
        }else {
            //Todo Cambiar el texto por string
            MetodosEstaticos.AlertDialogSimple(context, "No hay impresora configurada desde la web o desde la aplicacion.");
        }
    }

    public boolean realizarAbono(String referencia, String montoStr, boolean acredito, Venta venta){
        boolean todoBien = false;
        double monto = Double.parseDouble(montoStr);
        /*boolean acredito = false;
        if(rbCredito.isChecked()){
            acredito = true;
        }*/

        if(venta.getSaldo() >= monto){
            mPresentador.abonarSaldo(venta,referencia,monto,acredito);
            mPresentador.cargarLista(Constantes.TipoVenta.AMBAS);
            String metodo = (acredito ? "Tarjeta" : "Efectivo");
            imprimirTicket(MetodosEstaticos.getFormatoDecimal(monto,"###0.00"),metodo,1);
            //dialog.dismiss();
            todoBien = true;
        }else {
            MetodosEstaticos.AlertDialogSimple(context,context.getResources().getString(R.string.msjMontoMayorSaldo));
        }

        return todoBien;
    }

}
