package com.elephantworks.movilvennda.Vistas;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import com.elephantworks.movilvennda.Adaptadores.DevolucionProductosAdapter;
import com.elephantworks.movilvennda.Interfaces.IDevolucion;
import com.elephantworks.movilvennda.Modelos.Devolucion;
import com.elephantworks.movilvennda.Modelos.Inventario;
import com.elephantworks.movilvennda.Modelos.Venta;
import com.elephantworks.movilvennda.Modelos.VentaDetalle;
import com.elephantworks.movilvennda.Presentadora.PresentadorConsultaVentas;
import com.elephantworks.movilvennda.Presentadora.PresentadorDevolucion;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.BTPrinter;
import com.elephantworks.movilvennda.Utilerias.Constantes;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;

import java.util.Map;

/**
 * Created by elephantworkss.adec.v on 09/12/17.
 */

public class DevolucionActivity extends AppCompatActivity implements IDevolucion, View.OnClickListener{
    private PresentadorDevolucion mPresentador;
    private Context context = DevolucionActivity.this;
    public TextView txtCliente;
    public TextView txtFolio;
    public TextView txtFecha;
    public TextView txtTotal;
    public ListView lvProductos;
    public Button btnAceptar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_devolucion);

        mPresentador = new PresentadorDevolucion(this, context);
        txtCliente = (TextView) findViewById(R.id.txtClienteDevolucion);
        txtFolio = (TextView) findViewById(R.id.txtFolioDevolucion);
        txtFecha = (TextView) findViewById(R.id.txtFechaDevolucion);
        txtTotal = (TextView) findViewById(R.id.txtTotalDevolucion);

        lvProductos = (ListView)findViewById(R.id.lvProductosDevolucion);
        btnAceptar  = (Button) findViewById(R.id.btnAceptarDevolucion);
        btnAceptar.setOnClickListener(this);

        mPresentador.iniciar();
        mPresentador.cargarLista();

    }

    @Override
    public void llenarTitulos(String cliente, String folio, String fecha, String total) {
        txtCliente.setText(cliente);
        txtFolio.setText(folio);
        txtFecha.setText(fecha);
        txtTotal.setText(total);
    }

    @Override
    public void cargarLista(DevolucionProductosAdapter adapter) {
        lvProductos.setAdapter(adapter);
    }

    @Override
    public void mostrarError(String error) {
        MetodosEstaticos.AlertDialogSimple(context, error);
    }


    @Override
    public void onClick(View view) {

        if (view.getId() == R.id.btnAceptarDevolucion){

            DevolucionProductosAdapter adapter = ((DevolucionProductosAdapter) lvProductos.getAdapter());
            Map<Integer, Double> mapDevoluciones = adapter.obtenerDevolucionesLista();

            String mensaje = mPresentador.validarDevolucion(mapDevoluciones, adapter);
           if(!mensaje.equals("")){
               mostrarError(mensaje);
           }else{
               devolverProducto(mapDevoluciones, adapter);
           }


        }
    }

    public void terminar(){
        this.finish();
    }


    public void devolverProducto(final Map<Integer, Double> mapa, final DevolucionProductosAdapter adapter){

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
                if(!motivo.equals("")) {
                    String mensaje = mPresentador.validarUsuario(usuario, pin);
                    if (mensaje.equals("")) {
                        int idDevolucion = mPresentador.guardarDevoluciones(mapa, adapter,motivo);
                        imprimirTicket(idDevolucion, motivo);
                        dialog.dismiss();


                    } else {
                        MetodosEstaticos.AlertDialogSimple(context, mensaje);
                        etUsuario.setText("");
                        etPin.setText("");
                    }
                }else {
                    MetodosEstaticos.AlertDialogSimple(context, "Es necesario poner un motivo a la devolución.");
                }
            }
        });

    }


    public void imprimirTicket(final int idDevolucion, final String motivo){

        if(MetodosEstaticos.getImpresoraConfiguracion(context)){

            AlertDialog.Builder dialogo1 = new AlertDialog.Builder(context);
            dialogo1.setTitle(context.getResources().getString(R.string.dialog_advertencia));
            dialogo1.setMessage(context.getResources().getString(R.string.msjImprimirTicket));
            dialogo1.setCancelable(false);
            dialogo1.setPositiveButton("Confirmar", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialogo1, int id) {

                    BTPrinter btPrinter = new BTPrinter(context, DevolucionActivity.this);
                    btPrinter.conectar();
                    btPrinter.generateTicketDevolucion(idDevolucion, motivo);
                    btPrinter.cerrarSocket();

                    reimprimirTicket(idDevolucion, motivo);

                }
            });
            dialogo1.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialogo1, int id) {
                    dialogo1.dismiss();
                    terminar();
                }
            });
            dialogo1.show();
        }else {
            terminar();
        }

    }

    public void reimprimirTicket(final int idDevolucion, final String motivo){


        AlertDialog.Builder dialogo1 = new AlertDialog.Builder(context);
        dialogo1.setTitle(context.getResources().getString(R.string.dialog_advertencia));
        dialogo1.setMessage(context.getResources().getString(R.string.msjImprimirTicket));
        dialogo1.setCancelable(false);
        dialogo1.setPositiveButton("Confirmar", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialogo1, int id) {
                BTPrinter btPrinter = new BTPrinter(context, DevolucionActivity.this);
                btPrinter.conectar();
                btPrinter.generateTicketDevolucion(idDevolucion, motivo);
                btPrinter.cerrarSocket();

                imprimirTicket(idDevolucion, motivo);

            }
        });
        dialogo1.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialogo1, int id) {
                dialogo1.dismiss();
                terminar();

            }
        });
        dialogo1.show();
    }

}