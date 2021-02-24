package com.elephantworks.movilvennda.Fragments;


import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.text.Editable;
import android.text.InputType;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.SearchView;
import android.widget.TextView;
import android.widget.Toast;

import com.elephantworks.movilvennda.Adaptadores.ProductoAdapter;
import com.elephantworks.movilvennda.Interfaces.IProductos;
import com.elephantworks.movilvennda.Interfaces.IProductosVentas;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.Modelos.PuntoVenta;
import com.elephantworks.movilvennda.Modelos.Staff;
import com.elephantworks.movilvennda.Presentadora.PresentadorProductos;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.Constantes;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;
import com.elephantworks.movilvennda.Utilerias.Session;

/**
 * A simple {@link Fragment} subclass.
 */
public class FragmentListaProductos extends Fragment implements IProductos, SearchView.OnQueryTextListener {

    private Context context = null;
    private PresentadorProductos mPresentador;
    ListView lvProductos;
    SearchView searchView;
    private Session session;
    int idCategoria;
   // private IProductosVentas listener;

    public FragmentListaProductos() {
        // Required empty public constructor
    }

   /* public void setProductosVentasListener(IProductosVentas listener){
        this.listener = listener;
    }*/


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View rootView = inflater.inflate(R.layout.fragment_lista_productos, container, false);
        context = rootView.getContext();

        session = new Session(context);

        mPresentador = new PresentadorProductos(this,context);
        lvProductos = (ListView) rootView.findViewById(R.id.lvProductos);

        searchView = (SearchView) rootView.findViewById(R.id.busqueda_productos);
        searchView.setIconifiedByDefault(false);
        searchView.setOnQueryTextListener(this);
        searchView.setSubmitButtonEnabled(true);
        searchView.setQueryHint(getResources().getString(R.string.txtBuscarProductos));

        //mPresentador.defaultDatosLista();

        lvProductos.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int pos, long l) {
                Productos productos = (Productos) lvProductos.getItemAtPosition(pos);
                mostrarDialgoCantidades(productos);
            }
        });

        return rootView;
    }

    public void cambiarLista(int id){
       // txtHola.setText("Cambio: "+ id);
        if(session.getIdClienteVentas() > 0){
            idCategoria = id;
            mPresentador.cambiarDatosLista(id);
        }else{
            MetodosEstaticos.AlertDialogSimple(context, context.getResources().getString(R.string.msjClienteRequeridoListaPrecio));
        }

    }

    @Override
    public void cargarListaProductos(ProductoAdapter adapter) {
        lvProductos.setAdapter(adapter);
    }

    @Override
    public void error(String error) {
        MetodosEstaticos.AlertDialogSimple(getContext(), error);
    }

    @Override
    public boolean onQueryTextSubmit(String texto) {
        mPresentador.filtrarDatosLista(idCategoria,texto);

        return true;
    }

    @Override
    public boolean onQueryTextChange(String texto) {
        mPresentador.filtrarDatosLista(idCategoria,texto);

        return false;
    }


    public void mostrarDialgoCantidades(final Productos producto) {

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
        final double cantidadInventario = mPresentador.cantidadInventarioProducto(producto);
        final PuntoVenta puntoVenta = MetodosEstaticos.getPuntoVenta(context, session.getPuntoVenta());

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

        txtProducto.setText(producto.getNombre());
        txtCantidad.setText(MetodosEstaticos.getFormatoDecimal(cantidadInventario,"###0.00"));
        Clientes cliente = MetodosEstaticos.getClienteSesion(context, session.getIdClienteVentas());
        final double precio = MetodosEstaticos.getListaPrecio(producto, cliente.getListaPrecios());
        txtPrecio.setText(MetodosEstaticos.getFormatoDecimal(precio, "###0.00"));

        final Staff staff = MetodosEstaticos.getVendedorSession(context, session.getCorreoElectronicoStaff());
        final double porcentajeDescuento = staff.getPorcentajeDescuento();
        etDescuentoPorcentaje.setEnabled(false);
        etDescuentoTotal.setEnabled(false);

        if (porcentajeDescuento > 0){
            chkDescuento.setEnabled(true);
            etDescuentoPorcentaje.setEnabled(true);
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
                        if(cantidad <= cantidadInventario || puntoVenta.getInventario()){
                            double descuentoApp = Double.parseDouble(etDescuentoPorcentaje.getText().toString());
                            if(descuentoApp >= 0 && descuentoApp <= porcentajeDescuento) {
                                mPresentador.guardarVentaCarrito(producto, cantidad, descuentoApp);
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
                    MetodosEstaticos.AlertDialogSimple(context, context.getResources().getString(R.string.msjCantidadEmpty));
                }
            }
        });





    }
}
