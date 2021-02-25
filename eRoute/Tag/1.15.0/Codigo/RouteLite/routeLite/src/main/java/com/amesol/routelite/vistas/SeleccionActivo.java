package com.amesol.routelite.vistas;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.app.SearchManager;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
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
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.TextBoxScanner;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.SeleccionarActivo;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActivo;

import java.util.HashMap;

/**
 * Created by Adriana on 26/12/2016.
 */
public class SeleccionActivo extends Vista implements ISeleccionActivo {

    SeleccionarActivo mPresenta;
    String mAccion;
    private TextView mTexto;
    Cliente cliente;
    Vendedor oVendedor;
    boolean iniciarActividad;
    //SeleccionActivo.VistaActivos[] activos;
    TextBoxScanner txtScanner;

    @SuppressWarnings("deprecation")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        try {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.seleccion_activo);
            deshabilitarBarra(true);
            setTitulo(Mensajes.get("XActivos"));

            mTexto = (TextView) findViewById(R.id.lblCliente);
            mTexto.setVisibility(View.GONE);
            cliente = (Cliente) Sesion.get(Sesion.Campo.ClienteActual);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(cliente.Clave + " - " + cliente.RazonSocial);

            mTexto = (TextView) findViewById(R.id.lblRuta);
            mTexto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Descripcion);

            mTexto = (TextView) findViewById(R.id.lblDia);
            mTexto.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);

            ListView lista = (ListView) findViewById(R.id.lstActivos);
            registerForContextMenu(lista);

            txtScanner = (TextBoxScanner) findViewById(R.id.textBoxScanner);

            txtScanner.setOnCodigoIngresado(mCodigoBarras);
            txtScanner.setEnabled(false);

            mPresenta = new SeleccionarActivo(this, mAccion) ;
            mPresenta.iniciar();
        } catch (Exception e) {
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
    }

    public void mostrarActivos(SeleccionActivo.VistaActivos[] activos) {
        ListView lista = (ListView) findViewById(R.id.lstActivos);
        ActivosAdapter adapter = new ActivosAdapter(this, R.layout.lista_div2_rojo, activos);
        lista.setAdapter(adapter);

        /*if(resultadoActividad){
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        }*/
    }


    @Override
    public void iniciar() {

    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {

    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
        setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
        finalizar();
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        switch (keyCode) {
            case KeyEvent.KEYCODE_BACK:
                this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                this.finalizar();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_activos , menu);

        menu.getItem(0).setTitle(Mensajes.get("XModificar"));
        menu.getItem(1).setTitle(Mensajes.get("XDesasignar"));
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
        ListView lista = (ListView) findViewById(R.id.lstActivos);
        VistaActivos activo = (VistaActivos) lista.getItemAtPosition((int) info.position);

        switch (item.getItemId()) {
            case R.id.editar:
                mPresenta.modificar(activo.getActivoDetalleID());
                return true;
            case R.id.eliminar:
                desasignar(activo);
                return true;
        }

        return true;
    }

    private TextBoxScanner.OnCodigoIngresadoListener mCodigoBarras = new TextBoxScanner.OnCodigoIngresadoListener() {

        public void OnCodigoIngresado(String Codigo, int codigoLeido) {
            if (Codigo.length() == 0)
                return;

            HabilitarPantalla(false);
            String activoDetalleID = "";
            try {
                activoDetalleID = Consultas2.ConsultasActivos.obtenerDetalleID(Codigo);
            } catch (Exception ex) {
                ex.printStackTrace();
            }
            if (!activoDetalleID.equals(""))
                mPresenta.modificar(activoDetalleID);
            else
                mPresenta.asignar(Codigo);

            HabilitarPantalla(true);
        }

    };

    public void HabilitarPantalla(Boolean Habilitado) {
        ListView lista = (ListView) findViewById(R.id.lstActivos);
        lista.setClickable(Habilitado);
        txtScanner.setClickable(Habilitado);
        lista.setEnabled(Habilitado);
        //if(Habilitado && habilitarScanner)
        txtScanner.setEnabled(Habilitado);

        this.doevents();
    }


    private void desasignar(VistaActivos activo){
        LayoutInflater inflater = (LayoutInflater) SeleccionActivo.this
                .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

        View dialogView = inflater.inflate(R.layout.dialog_desasignar_activo, null);

        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        TextView txt = (TextView) dialogView.findViewById(R.id.lblTitulo);
        txt.setText(Mensajes.get("XDesasignarActivo"));

        txt = (TextView) dialogView.findViewById(R.id.lblActivo );
        txt.setText(activo.getIdElectronico() + " - " + activo.getDescripcion());

        txt = (TextView) dialogView.findViewById(R.id.lblComentario );
        txt.setText(Mensajes.get("XComentario"));

        final EditText txtComentario = (EditText) dialogView.findViewById(R.id.txtComentario);
        final String activoDetalleID = activo.getActivoDetalleID();

        builder.setPositiveButton(Mensajes.get("XContinuar"), new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int id) {
                if(txtComentario.getText().toString().trim().equals("")){
                    mostrarError(Mensajes.get("BE0001", Mensajes.get("XComentario")));
                }else{
                    try{
                        if (mPresenta.desasignar(activoDetalleID, txtComentario.getText().toString().trim())){
                            BDVend.commit();
                            mPresenta.mostrarActivos();
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

    public String getComentario(EditText texto)
    {
        return texto.getText().toString();
    }

    public static class VistaActivos
    {
        private String ActivoDetalleID;
        private String IdElectronico;
        private String Descripcion;
        private String Tipo;
        private String TipoFase;

        public VistaActivos(String activoDetalleID, String idElectronico, String descripcion, String tipo, String tipoFase)
        {
            ActivoDetalleID = activoDetalleID;
            IdElectronico = idElectronico;
            Descripcion = descripcion;
            Tipo = tipo;
            TipoFase = tipoFase;
        }

        public String getActivoDetalleID()
        {
            return ActivoDetalleID;
        }

        /*public void setActivoDetalleID(String activoDetalleID)
        {
            ActivoDetalleID = activoDetalleID;
        }*/

        public String getIdElectronico()
        {
            return IdElectronico;
        }

        public String getDescripcion()
        {
            return Descripcion;
        }

        public String getTipo()
        {
            return Tipo;
        }

        public String getTipoFase()
        {
            return TipoFase;
        }

    }

    public class ActivosAdapter extends ArrayAdapter<VistaActivos>
    {

        int textViewResourceId;
        Context context;

        public ActivosAdapter(Context context, int textViewResourceId, VistaActivos[] objects)
        {
            super(context, textViewResourceId, objects);
            this.textViewResourceId = textViewResourceId;
            this.context = context;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent)
        {
            View fila = convertView;

            if (convertView == null)
            {
                LayoutInflater inflater = ((Activity) context).getLayoutInflater();
                fila = inflater.inflate(textViewResourceId, null);
            }
            VistaActivos activo = getItem(position);

            TextView texto = (TextView) fila.findViewById(R.id.texto1);
            if (texto != null)
                texto.setText(activo.getDescripcion());

            texto = (TextView) fila.findViewById(R.id.texto2);
            if (texto != null)
                texto.setText(activo.getTipo());

            texto = (TextView) fila.findViewById(R.id.texto3);
            if (texto != null)
                texto.setText(activo.getTipoFase());

            return fila;
        }
    }


}
