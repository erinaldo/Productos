package com.elephantworks.movilvennda.Fragments;


import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.ContextMenu;
import android.view.LayoutInflater;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.elephantworks.movilvennda.Adaptadores.VentasAdapter;
import com.elephantworks.movilvennda.Interfaces.ICategoriasProductos;
import com.elephantworks.movilvennda.Interfaces.IListaVentas;
import com.elephantworks.movilvennda.Interfaces.IVentasMaster;
import com.elephantworks.movilvennda.Modelos.CarritoVentas;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.Modelos.Staff;
import com.elephantworks.movilvennda.Presentadora.PresentadorAperturaCierre;
import com.elephantworks.movilvennda.Presentadora.PresentadorListaVentas;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;
import com.elephantworks.movilvennda.Utilerias.Session;

/**
 * A simple {@link Fragment} subclass.
 */
public class FragmentListaVenta extends Fragment implements IListaVentas{

    ListView lvVentasProductos;
    private PresentadorListaVentas mPresentador;
    private Context context = null;
    private IVentasMaster listener;
    private Session session;

    public FragmentListaVenta() {
        // Required empty public constructor
    }

    public void setVentasMasterListener(IVentasMaster listener){
        this.listener = listener;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment

        View rootView = inflater.inflate(R.layout.fragment_lista_venta, container, false);
        context = rootView.getContext();

        mPresentador = new PresentadorListaVentas(this, context);
        session = new Session(context);

        lvVentasProductos = (ListView) rootView.findViewById(R.id.lvVentas);
        registerForContextMenu(lvVentasProductos);
        setHasOptionsMenu(true);

        return rootView;
    }


    public void agregarProductoLista(){
        mPresentador.agregarProductoVenta();
    }

    @Override
    public void cargarLista(final VentasAdapter adapter) {
        lvVentasProductos.setAdapter(adapter);
    }

    @Override
    public void error(String mensaje) {

    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);


        if(v.getId() == R.id.lvVentas){
            MenuInflater inflater = getActivity().getMenuInflater();
            inflater.inflate(R.menu.menu_ventas_carrito, menu);
        }
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterView.AdapterContextMenuInfo info = null;
        CarritoVentas carritoVentas = null;
        if (item.getMenuInfo() != null) {
            info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
            //lDinero = (PresentadorAperturaCierre.Dinero)  lvDinero.getItemAtPosition((int) info.position);
           carritoVentas = (CarritoVentas) lvVentasProductos.getItemAtPosition((int) info.position);
        }

        switch (item.getItemId()) {
            case R.id.eliminarCarrito:
                if(carritoVentas != null){
                   mPresentador.eliminarProductoCarrito(carritoVentas);
                    listener.actualizarTotales();
                }
                return true;

            case R.id.modificarCarrito:
                if(carritoVentas != null){
                    this.modificarCantidadProducto(carritoVentas);
                }
                return true;

        }

        return false;
    }

    public void modificarCantidadProducto(final CarritoVentas carritoVentas){

        LayoutInflater inflater = getActivity().getLayoutInflater();
        View dialoglayout = inflater.inflate(R.layout.dialogo_cantidades_producto, null);
        final AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        builder.setView(dialoglayout);
        final AlertDialog dialog = builder.show();


        Button btnAceptar = (Button) dialoglayout.findViewById(R.id.btnAceptarDlg);
        final TextView txtProducto = (TextView) dialoglayout.findViewById(R.id.txtProductoDlg);
        final TextView txtCantidad = (TextView) dialoglayout.findViewById(R.id.txtCantidadInventarioDlg);
        final TextView txtPrecio = (TextView) dialoglayout.findViewById(R.id.txtPrecio);
        final EditText etCantidad = (EditText) dialoglayout.findViewById(R.id.etCantidadDlg);
        final EditText etDescuentoPorcentaje = (EditText) dialoglayout.findViewById(R.id.etDescuento);
        final EditText etDescuentoTotal = (EditText) dialoglayout.findViewById(R.id.etDescuentoTotal);
        final CheckBox chkDescuento = (CheckBox) dialoglayout.findViewById(R.id.checkDescuento);
        final double cantidadInventario = mPresentador.cantidadInventarioProducto(carritoVentas.getProducto());

        etCantidad.setText(MetodosEstaticos.getFormatoDecimal(carritoVentas.getCantidad(),"###0"));

        ImageButton btnMas = (ImageButton) dialoglayout.findViewById(R.id.btnMas);
        ImageButton btnMenos = (ImageButton) dialoglayout.findViewById(R.id.btnMenos);

        btnMas.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String cantidad = etCantidad.getText().toString();
                int cant = 0;
                if(!cantidad.equals("")){
                    cant = Integer.parseInt(cantidad);
                }
                int total = cant + 1;
                etCantidad.setText(String.valueOf(total));
            }
        });

        btnMenos.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String cantidad = etCantidad.getText().toString();
                int cant = 0;
                if(!cantidad.equals("")){
                    cant = Integer.parseInt(cantidad);
                }
                if(cant > 0){
                    int total = cant - 1;
                    etCantidad.setText(String.valueOf(total));
                }
            }
        });


        if(!mPresentador.validarDescuntoVendedor()){
            etDescuentoTotal.setEnabled(false);
            etDescuentoPorcentaje.setEnabled(false);
        }

        if(carritoVentas.getDescuento() > 0.0){
            etDescuentoTotal.setEnabled(true);
            etDescuentoPorcentaje.setEnabled(true);

            etDescuentoPorcentaje.setText(MetodosEstaticos.getFormatoDecimal(carritoVentas.getDescuentoVendedor(), "###0.00"));
            double total = ((carritoVentas.getDescuentoVendedor() * carritoVentas.getPrecio()) / 100);
            total = carritoVentas.getPrecio() - total;
            etDescuentoTotal.setText(MetodosEstaticos.getFormatoDecimal(total, "###0.00"));
        }


        txtProducto.setText(carritoVentas.getProducto().getNombre());
        txtCantidad.setText(MetodosEstaticos.getFormatoDecimal(cantidadInventario,"###0.00"));
        Clientes cliente = MetodosEstaticos.getClienteSesion(context, session.getIdClienteVentas());
        final double precio = MetodosEstaticos.getListaPrecio(carritoVentas.getProducto(), cliente.getListaPrecios());
        txtPrecio.setText(MetodosEstaticos.getFormatoDecimal(precio, "###0.00"));

        final Staff staff = MetodosEstaticos.getVendedorSession(context, session.getCorreoElectronicoStaff());
        final double porcentajeDescuento = staff.getPorcentajeDescuento();
        etDescuentoPorcentaje.setEnabled(false);
        etDescuentoTotal.setEnabled(false);

        if (porcentajeDescuento > 0){
            chkDescuento.setEnabled(true);
            etDescuentoPorcentaje.setEnabled(false);
            etDescuentoTotal.setEnabled(false);
        }else {
            chkDescuento.setEnabled(false);
        }

        chkDescuento.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                if(b){
                    etDescuentoPorcentaje.setEnabled(false);
                    etDescuentoTotal.setEnabled(true);
                    etDescuentoPorcentaje.setText("0");
                    etDescuentoTotal.setText("0");
                }else{
                    etDescuentoPorcentaje.setEnabled(true);
                    etDescuentoTotal.setEnabled(false);
                    etDescuentoPorcentaje.setText("0");
                    etDescuentoTotal.setText("0");
                }
            }
        });

        etDescuentoPorcentaje.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void afterTextChanged(Editable editable) {

                if(!chkDescuento.isChecked()){
                    double descuento = 0.0;

                    if(!editable.toString().equals("")){
                        descuento = Double.parseDouble(editable.toString());
                    }

                    double total = ((descuento * precio) / 100);
                    total = precio - total;
                    etDescuentoTotal.setText(MetodosEstaticos.getFormatoDecimal(total, "###0.00"));

                }
            }
        });

        etDescuentoTotal.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {


            }

            @Override
            public void afterTextChanged(Editable editable) {

                if(chkDescuento.isChecked()){
                    double descuentoTotal = 0.0;

                    if(!editable.toString().equals("")){
                        descuentoTotal = Double.parseDouble(editable.toString());
                    }

                    double des = ((descuentoTotal * 100) / precio);
                    des = 100 - des;

                    if(descuentoTotal == 0.0){
                        des = 0;
                    }
                    etDescuentoPorcentaje.setText(MetodosEstaticos.getFormatoDecimal(des, "###0.00"));
                }

            }
        });

        btnAceptar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(!etCantidad.getText().toString().equals("")){

                    Double cantidad = Double.parseDouble(etCantidad.getText().toString());
                    if(cantidad > 0){
                        if(cantidad <= cantidadInventario){
                            double descuentoApp = Double.parseDouble(etDescuentoPorcentaje.getText().toString());
                            if(descuentoApp >= 0 && descuentoApp <= porcentajeDescuento) {
                                mPresentador.guardarVentaCarrito(carritoVentas.getProducto(), cantidad, descuentoApp);
                                dialog.dismiss();
                            }else {
                                //Toast.makeText(context, , Toast.LENGTH_LONG).show();
                                MetodosEstaticos.AlertDialogSimple(context, context.getResources().getString(R.string.msjDescuentoSobrePasado));
                            }
                        }else{
                            MetodosEstaticos.AlertDialogSimple(context, context.getResources().getString(R.string.msjCantidadInventario));
                        }
                    }else{
                        MetodosEstaticos.AlertDialogSimple(context, context.getResources().getString(R.string.msjCantidadNecesaria));
                    }
                }else{
                    MetodosEstaticos.AlertDialogSimple(context, context.getResources().getString(R.string.msjCantidadNecesaria));
                }
            }
        });
    }


}
