package com.elephantworks.movilvennda.Fragments;


import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.renderscript.Double2;
import android.support.v4.app.Fragment;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.SearchView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.elephantworks.movilvennda.Adaptadores.CambiarClienteAdapter;
import com.elephantworks.movilvennda.Adaptadores.ClienteAdapter;
import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Interfaces.IVentas;
import com.elephantworks.movilvennda.Interfaces.IVentasMaster;
import com.elephantworks.movilvennda.Modelos.Categorias;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.PuntoVenta;
import com.elephantworks.movilvennda.Modelos.Venta;
import com.elephantworks.movilvennda.Presentadora.PresentadorVentas;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.BTPrinter;
import com.elephantworks.movilvennda.Utilerias.Constantes;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;
import com.elephantworks.movilvennda.Utilerias.Session;
import com.elephantworks.movilvennda.Vistas.MenuActivity;

import java.util.ArrayList;

import io.realm.Realm;
import io.realm.RealmQuery;
import io.realm.RealmResults;

/**
 * A simple {@link Fragment} subclass.
 */
public class FragmnetVentaMenu extends Fragment implements IVentas, View.OnClickListener {

    private PresentadorVentas mPresenta;
    TextView txtPuntoVenta;
    TextView txtFecha;
    TextView txtFolio;
    TextView txtCliente;
    TextView txtLimiteCredito;
    TextView txtSaldoCredito;

    TextView txtSubtotal;
    TextView txtDescuento;
    TextView txtImpuesto;
    TextView txtTotal;
    Button btnCambiarCliente;
    Button btnPagar;
    private Context context = null;
    private View generalView;
    private Session session;
    private double totalPagar = 0;
    boolean pagoAcredito = false;
    private IVentasMaster listener;
    private Realm realm;
    private int idVenta;


    public FragmnetVentaMenu() {
        // Required empty public constructor
    }

    public void setVentasMasterListener(IVentasMaster listener){
        this.listener = listener;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View rootView = inflater.inflate(R.layout.fragmnet_venta_menu, container, false);
        generalView = rootView;
        context = rootView.getContext();
        mPresenta = new PresentadorVentas(this,context);
        inicializar(rootView);
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();

        return rootView;
    }

    public void inicializar(View view){
        session = new Session(context);
        txtPuntoVenta = (TextView) view.findViewById(R.id.txtPuntoVentaVenta);
        txtFecha = (TextView) view.findViewById(R.id.txtFechaVenta);
        txtFolio = (TextView) view.findViewById(R.id.txtFolioVenta);
        txtCliente = (TextView) view.findViewById(R.id.txtClienteVenta);
        txtLimiteCredito = (TextView) view.findViewById(R.id.txtLimiteCredito);
        txtSaldoCredito = (TextView) view.findViewById(R.id.txtSaldoCredito);

        txtSubtotal = (TextView) view.findViewById(R.id.txtSubtotal);
        txtDescuento = (TextView) view.findViewById(R.id.txtDescuento);
        txtImpuesto = (TextView) view.findViewById(R.id.txtImpuesto);
        txtTotal = (TextView) view.findViewById(R.id.txtTotal);

        btnCambiarCliente = (Button) view.findViewById(R.id.btnCambiarCliente);
        btnPagar = (Button) view.findViewById(R.id.btnPagar);

        btnCambiarCliente.setOnClickListener(this);
        btnPagar.setOnClickListener(this);

        mPresenta.llenarDatosMenuVenta();

    }

    public void refrescarTotales(){
        mPresenta.refrescarTotales();
        mPresenta.llenarDatosMenuVenta();
    }


    @Override
    public void actualizarTotales(String subtotal, String descuento, String impuesto, String total) {
        txtSubtotal.setText("$"+subtotal);
        txtDescuento.setText("$"+descuento);
        txtImpuesto.setText("$"+impuesto);
        txtTotal.setText("$"+total);
        totalPagar = Double.parseDouble(total);
    }

    @Override
    public void llenarTitulosMenuVenta(String puntoVenta, String fecha, String folio, String cliente,  String limiteCredito, String saldoCredito) {
        txtPuntoVenta.setText(puntoVenta);
        txtFecha.setText(fecha);
        txtFolio.setText(folio);
        txtCliente.setText(cliente);
        txtLimiteCredito.setText(limiteCredito);
        txtSaldoCredito.setText(saldoCredito);
    }

    @Override
    public void error(String mensaje) {
        MetodosEstaticos.AlertDialogSimple(context, mensaje);
    }

    @Override
    public void onClick(View view) {
        if (view.getId() == generalView.findViewById(R.id.btnCambiarCliente).getId()) {

            if(!mPresenta.validarProductosCambioCliente()){
                this.cambiarCliente();
            }else {
                AlertDialog.Builder dialogo1 = new AlertDialog.Builder(context);
                dialogo1.setTitle(context.getResources().getString(R.string.dialog_advertencia));
                dialogo1.setMessage(context.getResources().getString(R.string.msjCambioClienteProductos));
                dialogo1.setCancelable(false);
                dialogo1.setPositiveButton("Confirmar", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialogo1, int id) {
                        mPresenta.eliminarProductosPorCambioCliente();
                        mPresenta.refrescarTotales();
                        listener.limpiarListas();
                        cambiarCliente();
                    }
                });
                dialogo1.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialogo1, int id) {

                    }
                });
                dialogo1.show();
            }
        }

        if (view.getId() == generalView.findViewById(R.id.btnPagar).getId()) {
            if(totalPagar > 0){
                if(session.getIdClienteVentas() > 0){
                    this.pagar();

                }else {
                    MetodosEstaticos.AlertDialogSimple(context,context.getResources().getString(R.string.msjClienteRequerido));
                }
            }else{
                MetodosEstaticos.AlertDialogSimple(context, context.getResources().getString(R.string.msjPagarTotal0));
            }
        }
    }

    public void cambiarCliente(){

        LayoutInflater inflater = getActivity().getLayoutInflater();
        View dialoglayout = inflater.inflate(R.layout.dialogo_cambiar_cliente, null);
        final AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        builder.setView(dialoglayout);
        final AlertDialog dialog = builder.show();

        Button btnAceptar = (Button) dialoglayout.findViewById(R.id.btnAceptarClienteDlg);
        final ListView lvCliente = (ListView) dialoglayout.findViewById(R.id.lvListaCliente);
        SearchView searchView = (SearchView) dialoglayout.findViewById(R.id.busquedaClientesDlg);
        searchView.setIconifiedByDefault(false);
        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String nombreCliente) {
                try {
                    RealmQuery<Clientes> query;
                    if (nombreCliente.equals("")){
                        query = realm.where(Clientes.class);
                    }else{
                        query = realm.where(Clientes.class).contains("razonSocial", nombreCliente);
                    }
                    RealmResults<Clientes> listaClientes = query.findAll();

                    CambiarClienteAdapter adapter = new CambiarClienteAdapter(context, listaClientes);
                    lvCliente.setAdapter(adapter);
                }catch (Exception ex){
                    MetodosEstaticos.AlertDialogSimple(context,ex.getMessage());
                }
                return false;
            }

            @Override
            public boolean onQueryTextChange(String nombreCliente) {

                try {
                    RealmQuery<Clientes> query;
                    if (nombreCliente.equals("")){
                        query = realm.where(Clientes.class);
                    }else{
                        query = realm.where(Clientes.class).contains("razonSocial", nombreCliente);
                    }
                    RealmResults<Clientes> listaClientes = query.findAll();

                    CambiarClienteAdapter adapter = new CambiarClienteAdapter(context, listaClientes);
                    lvCliente.setAdapter(adapter);
                }catch (Exception ex){
                    MetodosEstaticos.AlertDialogSimple(context,ex.getMessage());
                }
                return false;
            }
        });
        searchView.setSubmitButtonEnabled(true);
        searchView.setQueryHint(getResources().getString(R.string.txtBuscarClientes));

        CambiarClienteAdapter clienteAdapter = mPresenta.llenarListaClientes();
        if(clienteAdapter != null){
            lvCliente.setAdapter(clienteAdapter);
        }

        lvCliente.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int pos, long l) {
                Clientes cliente = (Clientes) lvCliente.getItemAtPosition(pos);
                session.setIdClienteVentas(cliente.getIdCliente());
            }
        });

        btnAceptar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mPresenta.llenarDatosMenuVenta();
                dialog.dismiss();
            }
        });

    }

    public void pagar(){

        LayoutInflater inflater = getActivity().getLayoutInflater();
        View dialoglayout = inflater.inflate(R.layout.dialogo_pagar, null);
        final AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        builder.setView(dialoglayout);
        final AlertDialog dialog = builder.show();


        Button btnAceptar = (Button) dialoglayout.findViewById(R.id.btnAceptarPagarDlg);
        TextView txtTotalPagar = (TextView) dialoglayout.findViewById(R.id.txtTotalPagar);
        final EditText etRecibi = (EditText) dialoglayout.findViewById(R.id.etRecibi);
        final EditText etCambio = (EditText) dialoglayout.findViewById(R.id.etCambio);
        RadioButton rbContado = (RadioButton) dialoglayout.findViewById(R.id.rbContado);
        RadioButton rbCredito = (RadioButton) dialoglayout.findViewById(R.id.rbCredito);
        final Spinner sFormaPago = (Spinner) dialoglayout.findViewById(R.id.sFormaPago);

        ArrayList<String> aFormaPago = new ArrayList<String>();
        //Todo Cambiar pot strings
        aFormaPago.add("Selecciona...");
        aFormaPago.add("Efectivo");
        aFormaPago.add("Tarjeta");

        ArrayAdapter<String> namesAdapter = new ArrayAdapter<String>(dialoglayout.getContext(),android.R.layout.simple_spinner_dropdown_item,aFormaPago);
        namesAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        sFormaPago.setAdapter(namesAdapter);

        pagoAcredito = false;

        rbContado.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                if(b){
                    etRecibi.setEnabled(true);
                    sFormaPago.setEnabled(true);
                    pagoAcredito = false;
                }
            }
        });

        rbCredito.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                if(b){
                    etRecibi.setEnabled(false);
                    sFormaPago.setEnabled(false);
                    pagoAcredito = true;
                }
            }
        });

        txtTotalPagar.setText("$"+MetodosEstaticos.getFormatoDecimal(totalPagar, "###0.00"));

        etRecibi.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                double recibi = 0.0;

                if(!charSequence.toString().equals("")){
                     recibi = Double.parseDouble(charSequence.toString());
                }

                double cambio = recibi - totalPagar;
                if(cambio < 0){
                    cambio = 0.0;
                }
                etCambio.setText(MetodosEstaticos.getFormatoDecimal(cambio,"$###0.00"));
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });


        btnAceptar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(eventoPagar(etCambio.getText().toString(), sFormaPago.getSelectedItem().toString(), etRecibi.getText().toString())){
                    dialog.dismiss();
                }
            }
        });

        etCambio.setOnKeyListener(new View.OnKeyListener() {
            @Override
            public boolean onKey(View view, int keyCode, KeyEvent event) {
                if ((event.getAction() == KeyEvent.ACTION_DOWN) && (keyCode == KeyEvent.KEYCODE_ENTER)) {
                    if(eventoPagar(etCambio.getText().toString(), sFormaPago.getSelectedItem().toString(), etRecibi.getText().toString())){
                        dialog.dismiss();
                    }
                    return true;
                }
                return false;
            }
        });

    }


    public void imprimirTicket(final String metodo){

        if(MetodosEstaticos.getImpresoraConfiguracion(context)){

            AlertDialog.Builder dialogo1 = new AlertDialog.Builder(context);
            dialogo1.setTitle(context.getResources().getString(R.string.dialog_advertencia));
            dialogo1.setMessage(context.getResources().getString(R.string.msjImprimirTicket));
            dialogo1.setCancelable(false);
            dialogo1.setPositiveButton("Confirmar", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialogo1, int id) {

                    BTPrinter btPrinter = new BTPrinter(context, getActivity());
                    btPrinter.conectar();
                    btPrinter.generateTicketVenta(idVenta,metodo);
                    btPrinter.cerrarSocket();

                    reimprimirTicket(metodo);

                }
            });
            dialogo1.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialogo1, int id) {
                    dialogo1.dismiss();
                }
            });
            dialogo1.show();
        }

    }

    public void reimprimirTicket(final String metodo){


        AlertDialog.Builder dialogo1 = new AlertDialog.Builder(context);
        dialogo1.setTitle(context.getResources().getString(R.string.dialog_advertencia));
        dialogo1.setMessage(context.getResources().getString(R.string.msjImprimirTicket));
        dialogo1.setCancelable(false);
        dialogo1.setPositiveButton("Confirmar", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialogo1, int id) {
                    BTPrinter btPrinter = new BTPrinter(context, getActivity());
                    btPrinter.conectar();
                    btPrinter.generateTicketVenta(idVenta,metodo);
                    btPrinter.cerrarSocket();

                    imprimirTicket(metodo);

                }
        });
        dialogo1.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialogo1, int id) {
                    dialogo1.dismiss();

                }
        });
        dialogo1.show();
    }

    public void transaccionTarjetaCredito(String importe, String pin, String transaccion, String identificador, String email){
        Intent intent = new Intent("billpocket.payments.START");

        intent.putExtra("amount", importe);
        intent.putExtra("pin", "2519");
        intent.putExtra("transaction", transaccion);
        intent.putExtra("identifier", identificador);
        intent.putExtra("email", email);

        if(intent.resolveActivity(this.getActivity().getPackageManager()) != null){
            ((MenuActivity) getActivity()).iniciarBillPocket(intent);
            //getActivity().startActivityForResult(intent, Constantes.BillPocket.CREDIT_CARD_INTENT);
        }else{
            //Todo Cambiar el texto por string
            MetodosEstaticos.AlertDialogSimple(context, "No tienes la aplicación de Bill Pocket.");
        }

    }

    public boolean eventoPagar(String cambio, String valorFormaPago, String recibiStr){

        boolean todoBien = false;
        Clientes clienteBD = MetodosEstaticos.getClienteSesion(context, session.getIdClienteVentas());
        PuntoVenta puntoVenta = MetodosEstaticos.getPuntoVenta(context, session.getPuntoVenta());


        if (clienteBD != null){

            if (!pagoAcredito){
                if(recibiStr.equals("")){
                    MetodosEstaticos.AlertDialogSimple(context,context.getResources().getString(R.string.msjRecibi));
                    return false;
                }

                if(!valorFormaPago.equals("Selecciona...")){
                    int formaPago = 0;
                    if(valorFormaPago.equals("Efectivo")){
                        formaPago = Constantes.FormaPago.EFECTIVO;
                    }else {
                        formaPago = Constantes.FormaPago.TARJETA;
                    }

                    double recibi = Double.parseDouble(recibiStr.replace("$",""));
                    if(recibi >= totalPagar){
                        idVenta = mPresenta.guardarVenta(pagoAcredito,clienteBD, puntoVenta,formaPago,recibi);
                        mPresenta.refrescarTotales();
                        mPresenta.llenarDatosMenuVenta();
                        listener.limpiarListas();
                        imprimirTicket("Contado");
                        //dialog.dismiss();
                         todoBien = true;
                    }else {
                        MetodosEstaticos.AlertDialogSimple(context,context.getResources().getString(R.string.msjRecibidoMenor));
                    }
                }else {
                    MetodosEstaticos.AlertDialogSimple(context,context.getResources().getString(R.string.msjNecesarioFormaPago));
                }
            }else{
                if(mPresenta.validarClienteCredito(clienteBD)){
                    idVenta = mPresenta.guardarVenta(pagoAcredito,clienteBD, puntoVenta,0,0);
                    mPresenta.refrescarTotales();
                    mPresenta.llenarDatosMenuVenta();
                    listener.limpiarListas();
                    imprimirTicket("Credito");
                    todoBien = true;
                   // dialog.dismiss();
                }else{
                    MetodosEstaticos.AlertDialogSimple(context,context.getResources().getString(R.string.msjClienteCredito));
                }
            }
        }else{
            MetodosEstaticos.AlertDialogSimple(context,context.getResources().getString(R.string.msjClienteRequerido));
        }
        //Todo Cambiar numero por constantes
        // if(formaPago == 2){
        //Venta venta = realm.where(Venta.class).equalTo("idVenta",idVenta).findFirst();
        //transaccionTarjetaCredito(venta.getTotal().toString(), venta.getStaff().getPin(),"Venta",venta.getFolio(), venta.getCliente().getEmail());
        // }

        return todoBien;
    }

}
