package com.elephantworks.movilvennda.Utilerias;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.support.annotation.NonNull;
import android.util.Log;

import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Modelos.Abono;
import com.elephantworks.movilvennda.Modelos.AperturaCierre;
import com.elephantworks.movilvennda.Modelos.CarritoImpuesto;
import com.elephantworks.movilvennda.Modelos.CarritoVentas;
import com.elephantworks.movilvennda.Modelos.Categorias;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.Cobranza;
import com.elephantworks.movilvennda.Modelos.Empresa;
import com.elephantworks.movilvennda.Modelos.FoliosVenta;
import com.elephantworks.movilvennda.Modelos.ImpresoraHomologada;
import com.elephantworks.movilvennda.Modelos.Impuesto;
import com.elephantworks.movilvennda.Modelos.ImpuestoDetalle;
import com.elephantworks.movilvennda.Modelos.Inventario;
import com.elephantworks.movilvennda.Modelos.Plan;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.Modelos.PuntoVenta;
import com.elephantworks.movilvennda.Modelos.Staff;
import com.elephantworks.movilvennda.Modelos.ValoresImpuesto;
import com.elephantworks.movilvennda.Modelos.ValoresReferencia;
import com.elephantworks.movilvennda.Modelos.Venta;
import com.elephantworks.movilvennda.Modelos.VentaDetalle;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.text.DateFormat;
import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;
import java.util.Map;

import io.realm.Realm;
import io.realm.RealmQuery;
import io.realm.RealmResults;

/**
 * Created by ldelatorre on 29/05/2017.
 */
public class MetodosEstaticos {
    static boolean acepto = false;

    public static String getStringFromInputStream(InputStream is) {

        BufferedReader br = null;
        StringBuilder sb = new StringBuilder();

        String line;
        try {

            br = new BufferedReader(new InputStreamReader(is));
            while ((line = br.readLine()) != null) {
                sb.append(line);
            }

        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (br != null) {
                try {
                    br.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }

        return sb.toString();

    }

    public static String getEncodedData(Map<String,String> data) {
        StringBuilder sb = new StringBuilder();
        for(String key : data.keySet()) {
            String value = null;
            try {
                value = data.get(key);
            } catch (Exception e) {
                e.printStackTrace();
            }

            if(sb.length()>0)
                sb.append("&");

            sb.append(key + "=" + value);
        }
        return sb.toString();
    }

    public static void AlertDialogSimple(Context context, String mensaje) {

        AlertDialog alertDialog = new AlertDialog.Builder(context).create();
        alertDialog.setTitle("Error");
        alertDialog.setMessage(mensaje);
        alertDialog.setButton(AlertDialog.BUTTON_NEUTRAL, "OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int i) {
                dialog.dismiss();
            }
        });

        alertDialog.show();
    }

    public static void AlertDialogSimple(Context context, String mensaje, String titulo) {

        AlertDialog alertDialog = new AlertDialog.Builder(context).create();
        alertDialog.setTitle(titulo);
        alertDialog.setMessage(mensaje);
        alertDialog.setButton(AlertDialog.BUTTON_NEUTRAL, "OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int i) {
                dialog.dismiss();
            }
        });

        alertDialog.show();
    }

    public static boolean AlertDialogConRespuesta(Context context, String mensaje, String titulo){

        AlertDialog.Builder dialogo1 = new AlertDialog.Builder(context);
        dialogo1.setTitle(titulo);
        dialogo1.setMessage(mensaje);
        dialogo1.setCancelable(false);
        dialogo1.setPositiveButton("Confirmar", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialogo1, int id) {
                acepto = true;
            }
        });
        dialogo1.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialogo1, int id) {
               acepto = false;
            }
        });
        dialogo1.show();

        return acepto;
    }

    public static String getFormatoDecimal(double numero, String formato) {
        DecimalFormatSymbols dfs = new DecimalFormatSymbols();
        dfs.setDecimalSeparator('.');
        dfs.setGroupingSeparator(',');
        NumberFormat numberFormat = new DecimalFormat(formato, dfs);
        return numberFormat.format(numero);
    }

    public static String getFechaActualStr(){
        Date date = new Date();
        DateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy", Locale.US);
        return dateFormat.format(date);
    }

    public static String getFechaActualFolioStr(){
        Date date = new Date();
        DateFormat dateFormat = new SimpleDateFormat("yyyyMMdd", Locale.US);
        return dateFormat.format(date);
    }

    public static String getFechaStr(Date fecha){

        DateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy", Locale.US);
        return dateFormat.format(fecha);
    }

    public static Empresa getEmpresaSesion(Context context){
        Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        RealmQuery<Empresa> query = realm.where(Empresa.class);
        Empresa empresa = query.findFirst();
        return empresa;
    }

    public static Staff getVendedorSession(Context context, String email){
        Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        RealmQuery<Staff> query = realm.where(Staff.class);
        Staff staff = query.equalTo("email",email).findFirst();
        return staff;
    }

    public static Clientes getClienteSesion(Context context, int id){
        Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        RealmQuery<Clientes> query = realm.where(Clientes.class);
        Clientes cliente = query.equalTo("idCliente",id).findFirst();
        return cliente;
    }

    public static PuntoVenta getPuntoVenta(Context context, int id){
        Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        RealmQuery<PuntoVenta> query = realm.where(PuntoVenta.class);
        PuntoVenta puntoVentaRealmResults = query.equalTo("idPuntoVenta", id).findFirst();
        return puntoVentaRealmResults;
    }

    public static boolean getImpresoraConfiguracion(Context context){
        Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        boolean configurada = false;
        RealmQuery<ImpresoraHomologada> query = realm.where(ImpresoraHomologada.class);
        ImpresoraHomologada impresora = query.findFirst();

        if(impresora != null){
            if(impresora.getMacImpresora() != null){
                configurada = true;
            }
        }

        return configurada;
    }

    public static String getFolio(Context context){
        Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        FoliosVenta folioV = realm.where(FoliosVenta.class).findFirst();
        return folioV.getEmpresa() + "-" + folioV.getPuntoVenta() + "-" + folioV.getFecha() + "-" +folioV.getConsecutivo();
    }

    public static double getListaPrecio(Productos producto, int listaPrecio ){
        double precio = 0.0;
        switch (listaPrecio){
            case 1:
                precio = producto.getPrecio();
                break;
            case 2:
                precio = producto.getPrecio2();
                break;
            case 3:
                precio = producto.getPrecio3();
                break;
            case 4:
                precio = producto.getPrecio4();
                break;
            case 5:
                precio = producto.getPrecio5();
                break;
        }

        return precio;
    }

    public static Date getFechaVencimiento(int dias){
        Calendar calendario = Calendar.getInstance();
        calendario.setTime(new Date());
        calendario.add(Calendar.DAY_OF_YEAR, dias);

        return calendario.getTime();
    }

    public static Date parseFecha(String input ) throws java.text.ParseException {


        //ESTE METODO SE UTILIZA PARA EL SERVICIO Y PARSEAR CORRECTAMENTE LAS FECHAS
        //NOTE: SimpleDateFormat uses GMT[-+]hh:mm for the TZ which breaks
        //things a bit.  Before we go on we have to repair this.
        SimpleDateFormat df = new SimpleDateFormat( "yyyy-MM-dd'T'HH:mm:ssz" );

        //this is zero time so we need to add that TZ indicator for
        if ( input.endsWith( "Z" ) ) {
            input = input.substring( 0, input.length() - 1) + "GMT-00:00";
        } else {
            int inset = 6;

            String s0 = input.substring( 0, input.length() - inset );
            String s1 = input.substring( input.length() - inset, input.length() );

            input = s0 + "GMT" + s1;
        }

        return df.parse( input );

    }

    public static final class ValidarDatosBD{

        public static boolean hayDatosEmpresa(Context context){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<Empresa> query = realm.where(Empresa.class);
            return (query.findAll().size() > 0 );
        }

        public static boolean validarStaff(Context context, String email, String pin){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<Staff> query = realm.where(Staff.class);
            Staff staff = query.equalTo("email", email).equalTo("pin", pin).findFirst();
            return (staff != null);
        }

        public static Empresa existeEmpresaBD(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<Empresa> query = realm.where(Empresa.class);
            return query.equalTo("idEmpresa", id).findFirst();

        }

        public static PuntoVenta existePuntoVentaBD(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<PuntoVenta> query = realm.where(PuntoVenta.class);
            return query.equalTo("idPuntoVenta", id).findFirst();
        }

        public static Staff existeStaffBD(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<Staff> query = realm.where(Staff.class);
            return query.equalTo("idStaff", id).findFirst();
        }

        public static Clientes existeClienteBD(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<Clientes> query = realm.where(Clientes.class);
            return query.equalTo("idCliente", id).findFirst();

        }

        public static Productos existeProductoBD(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<Productos> query = realm.where(Productos.class);
            return query.equalTo("idProducto", id).findFirst();

        }

        public static Categorias existeCategoriaBD(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<Categorias> query = realm.where(Categorias.class);
            return query.equalTo("idCategoria", id).findFirst();

        }

        public static Inventario existeInventarioBD(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<Inventario> query = realm.where(Inventario.class);
            return query.equalTo("idInventario", id).findFirst();

        }

        public static ImpresoraHomologada existeImpresoraBD(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<ImpresoraHomologada> query = realm.where(ImpresoraHomologada.class);
            return query.equalTo("idImpresora", id).findFirst();

        }

        public static Plan existePlanBD(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<Plan> query = realm.where(Plan.class);
            return query.equalTo("idPlan", id).findFirst();

        }

        public static Impuesto existeImpuestoBD(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<Impuesto> query = realm.where(Impuesto.class);
            return query.equalTo("idImpuesto", id).findFirst();

        }

        public static ValoresImpuesto existeValoresImpuestoBD(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<ValoresImpuesto> query = realm.where(ValoresImpuesto.class);
            return query.equalTo("idValoresImpuesto", id).findFirst();

        }

        public static ValoresReferencia existeValoresReferencia(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<ValoresReferencia> query = realm.where(ValoresReferencia.class);
            return query.equalTo("idValoreRef", id).findFirst();

        }

        public static Venta existeVentas(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<Venta> query = realm.where(Venta.class);
            return query.equalTo("idVenta", id).findFirst();
        }

        public static VentaDetalle existeVentaDetalle(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<VentaDetalle> query = realm.where(VentaDetalle.class);
            return query.equalTo("idVentaDetalle", id).findFirst();
        }

        public static Cobranza existeCobranza(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<Cobranza> query = realm.where(Cobranza.class);
            return query.equalTo("idCobranza", id).findFirst();
        }

        public static Abono existeAbono(Context context, int id){
            Realm realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
            RealmQuery<Abono> query = realm.where(Abono.class);
            return query.equalTo("idAbono", id).findFirst();
        }


    }

}
