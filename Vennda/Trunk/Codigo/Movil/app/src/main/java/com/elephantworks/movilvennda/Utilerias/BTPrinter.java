package com.elephantworks.movilvennda.Utilerias;

import io.realm.RealmResults;
import io.realm.internal.Util;

import android.app.Activity;
import android.app.ProgressDialog;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.Context;
import android.provider.SyncStateContract;
import android.util.Log;
import android.widget.ArrayAdapter;


import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Modelos.Cobranza;
import com.elephantworks.movilvennda.Modelos.Devolucion;
import com.elephantworks.movilvennda.Modelos.DevolucionDetalle;
import com.elephantworks.movilvennda.Modelos.ImpresoraHomologada;
import com.elephantworks.movilvennda.Modelos.PuntoVenta;
import com.elephantworks.movilvennda.Modelos.Venta;
import com.elephantworks.movilvennda.Modelos.VentaDetalle;

import java.io.IOException;
import java.io.OutputStream;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Set;
import java.util.UUID;

import io.realm.Realm;
import io.realm.internal.async.QueryUpdateTask;


/**
 * Created by ldelatorre on 25/07/2017.
 */
public class BTPrinter{

    private Context context;
    private Realm realm;
    private StringBuilder ticket;

    byte FONT_TYPE;
    private static BluetoothSocket btsocket;
    private static OutputStream btoutputstream;
    private ImpresoraHomologada impresoraHomologada;
    private ProgressDialog mProgreso;
    // private static Vendedor vendedor;


    static private BluetoothAdapter mBluetoothAdapter = null;
    // static private ArrayAdapter<String> mArrayAdapter = null;
    static private ArrayAdapter<BluetoothDevice> btDevices = null;
    static private BluetoothSocket mbtSocket = null;

    private int max = 32;


    public BTPrinter(Context context, Activity activity) {
        this.context = context;
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        mProgreso = new ProgressDialog(activity);
    }

    public void cerrarSocket() {
        try {
            if (btsocket != null) {
                btoutputstream.close();
                btsocket.close();
                btsocket = null;
            }

            mProgreso.dismiss();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private void flushData() {
        try {
            if (mbtSocket != null) {
                mbtSocket.close();
                mbtSocket = null;
            }

            if (mBluetoothAdapter != null) {
                mBluetoothAdapter.cancelDiscovery();
            }

            if (btDevices != null) {
                btDevices.clear();
                btDevices = null;
            }

        } catch (Exception ex) {
        } catch (Throwable e) {
        }

    }

    public String conectar(){

        flushData();

        mProgreso.setMessage("Imprimiendo...");
        mProgreso.setCancelable(false);
        mProgreso.show();


        impresoraHomologada = realm.where(ImpresoraHomologada.class).findFirst();
        mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();

        if (mBluetoothAdapter == null) {
            return "El dispositivo no soporta bluetooth";
        }

        if (mBluetoothAdapter.isDiscovering()) {
            mBluetoothAdapter.cancelDiscovery();
        }

        if (btDevices == null) {
            btDevices = new ArrayAdapter<BluetoothDevice>(context, android.R.id.text1);
        }

        if(impresoraHomologada.getMacImpresora().equals("")){
            return "El telefono no tiene configurada una impresora";
        }

        Set<BluetoothDevice> btDeviceList = mBluetoothAdapter.getBondedDevices();


        if (btDeviceList.size() > 0) {
            if (btDevices.getCount() == 0){
                for (BluetoothDevice device : btDeviceList) {
                    if(device.getAddress().equals(impresoraHomologada.getMacImpresora())){
                        btDevices.add(device);
                    }
                }
            }
        }else{
            return "El bluetooth se encuentra apagado, por favor enciendalo para poder imprimir";
        }

        if(btDevices.getCount() > 0){

            try {
                Thread.sleep(2000);

                //boolean gotuuid = btDevices.getItem(0).fetchUuidsWithSdp();
                UUID uuid = btDevices.getItem(0).getUuids()[0].getUuid();
                mbtSocket = btDevices.getItem(0).createRfcommSocketToServiceRecord(uuid);

                btDevices.clear();
                mbtSocket.connect();

            } catch (IOException ex) {
                try {
                    mbtSocket.close();
                } catch (IOException e) {
                    // e.printStackTrace();
                }
                mbtSocket = null;
                return "No se encontro la impresora "+impresoraHomologada.getNombreImpresora();
            }catch (InterruptedException e) {
                e.printStackTrace();
            }
        }



        return "";

    }

    protected void imprimirTikect(String ticket) {

            btsocket = mbtSocket;
            if (btsocket != null) {
                OutputStream opstream = null;
                try {
                    opstream = btsocket.getOutputStream();
                } catch (IOException e) {
                    e.printStackTrace();
                }
                btoutputstream = opstream;
                print_bt(ticket);
            }

    }

    private void print_bt(String ticket) {
        try {

            btoutputstream = btsocket.getOutputStream();
            String espacios = "\n\r";

            if(impresoraHomologada.getNombreImpresora().equals("Sewoo")){
                // btoutputstream.write(new byte[]{27, 77, 0});
                btoutputstream.write(new byte[]{29, 33, 0});
            }else if(impresoraHomologada.getNombreImpresora().equals("Bixolon")){
                btoutputstream.write(new byte[]{27, 77, 0});
            }else{
                byte[] printformat = {0x1B, 0x21, FONT_TYPE};
                btoutputstream.write(printformat);
            }

            btoutputstream.write(espacios.getBytes());
            btoutputstream.write(espacios.getBytes());
            btoutputstream.write(ticket.getBytes());
            btoutputstream.write(espacios.getBytes());
            btoutputstream.write(espacios.getBytes());
            btoutputstream.flush();

            Thread.sleep(2000);

        } catch (IOException e) {
            e.printStackTrace();
        }catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    //Metodos para los tickets Empieza
    private String alineaTexto(int tipoAlineacion, String texto, int longTotal)
    {
        switch (tipoAlineacion)
        {
            case 2:
                return textoCentrado(texto, longTotal);
            case 3:
                return textoDerecha(texto, longTotal);
        }

        return texto;
    }

    private  String textoCentrado(String texto, int longTotal)
    {
        String espacios = "";
        int tamTexto = texto.length();

        for (int i = 1; i < Math.round((longTotal - tamTexto) / 2); i++)
        {
            espacios = espacios.concat(" ");
        }
        return espacios.concat(texto);
    }

    private String textoDerecha(String texto, int longTotal)
    {
        String espacios = "";

        for (int i = 1; i < longTotal - texto.length(); i++)
        {
            espacios = espacios.concat(" ");
        }
        return espacios.concat(texto);
    }

    private String getSeparator()
    {
        String separador = "";

        for (int i = 1; i <= max; i++)
        {
            separador = separador + "-";
        }
        return separador;
    }

    private String completaHasta(String texto, int espacios, short tipoAlineacion, boolean ultimaColumna) {
        String res = "";
        if (texto.length() >= espacios) {
            if (ultimaColumna) {
                return texto.substring(0, espacios);
            } else {
                return texto.substring(0, espacios - 1) + " ";
            }
        } else {
            if (tipoAlineacion == TipoAlineacion.IZQUIERDA) {
                return String.format("%-" + espacios + "s", texto);
                //return String.format("%" + (texto.length() + espacios) + "s", texto);
            } else if (tipoAlineacion == TipoAlineacion.DERECHA) {
                return String.format("%" + espacios + "s", texto);
                //return String.format("%-" + (texto.length() + espacios) + "s", texto);
            }
        }
        return res;
    }

    //Metodos para los tickets Termina


    //Tickets

    public void generateTicketAbono(int idVenta, String recibido, String metodo){

        String cadenaAux = "";
        String ticketString = "";
        double totalSinDescuento = 0;

        try{
            ticket = new StringBuilder();


            Venta venta = realm.where(Venta.class).equalTo("idVenta", idVenta).findFirst();
            RealmResults<Cobranza> cobranzas = realm.where(Cobranza.class).equalTo("venta.idVenta",venta.getIdVenta()).findAll();
            PuntoVenta puntoVenta = venta.getPuntoVenta();


            cadenaAux = alineaTexto(2,puntoVenta.getNombreNegocio(),max);
            ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(2,puntoVenta.getCalle() +" "+puntoVenta.getNoExterior() + " " + puntoVenta.getColonia(),max);
            ticket.append(cadenaAux+"\r\n");

            //TODO Falta agregar ciudad y estado
            cadenaAux = alineaTexto(2,"CP "+puntoVenta.getCodigoPostal(),max);
            ticket.append(cadenaAux+"\r\n");

            //TODO no hay rfc a nivel de punto de venta, solo de empresa
            //cadenaAux = alineaTexto(2,"RFC: "+puntoVenta.getRFC,max);
            //ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(2,"COMPROBANTE DE COBRO",max);
            ticket.append(cadenaAux+"\r\n");

            ticket.append("\r\n");
            ticket.append("\r\n");

            cadenaAux = alineaTexto(1,"Fecha: "+MetodosEstaticos.getFechaActualStr(),max);
            ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(1,"Cte: "+venta.getCliente().getRazonSocial(),max);
            ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(1,"Atendio: "+venta.getStaff().getNombre() + " " + venta.getStaff().getApellidos(),max);
            ticket.append(cadenaAux+"\r\n");

            ticket.append("\r\n");

            ticket.append(getSeparator());

            ticket.append("\r\n");

            cadenaAux = completaHasta("Fecha", 10, TipoAlineacion.IZQUIERDA, false);
            cadenaAux += completaHasta("Folio", 10, TipoAlineacion.IZQUIERDA, false);
            cadenaAux += completaHasta("Total", 6, TipoAlineacion.IZQUIERDA, false);
            cadenaAux += completaHasta("Saldo", 6, TipoAlineacion.IZQUIERDA, false);
            ticket.append(cadenaAux + "\r\n");

            ticket.append(getSeparator());

            for (Cobranza cobranza : cobranzas){
                String texto = "";

                texto = MetodosEstaticos.getFechaStr(cobranza.getFecha());
                cadenaAux = completaHasta(texto, 10, TipoAlineacion.IZQUIERDA, false);
                texto = venta.getFolio();
                cadenaAux += completaHasta(texto, 10, TipoAlineacion.IZQUIERDA, false);
                texto = MetodosEstaticos.getFormatoDecimal(cobranza.getSaldo(), "###0.00");
                cadenaAux += completaHasta(texto, 6, TipoAlineacion.IZQUIERDA, false);
                texto = MetodosEstaticos.getFormatoDecimal(cobranza.getSaldoAbono(), "###0.00");
                cadenaAux += completaHasta(texto, 6, TipoAlineacion.IZQUIERDA, false);
                ticket.append(cadenaAux + "\r\n");
            }

            ticket.append("\r\n");
            ticket.append("\r\n");

            String texto = "";
            texto = "Recibido: "+recibido;
            cadenaAux = alineaTexto(3,texto,max);
            ticket.append(cadenaAux+"\r\n");

            texto = "Metodo: "+metodo;
            cadenaAux = alineaTexto(3,texto,max);
            ticket.append(cadenaAux+"\r\n");

           /* texto = "Cambio: "+cambio;
            cadenaAux = alineaTexto(3,texto,max);
            ticket.append(cadenaAux+"\r\n");*/

            ticket.append("\r\n");
            ticket.append("\r\n");
            texto = "GRACIAS POR SU PAGO";
            cadenaAux = alineaTexto(2,texto,max);
            ticket.append(cadenaAux+"\r\n");

            texto = "www.vennda.com";
            cadenaAux = alineaTexto(2,texto,max);
            ticket.append(cadenaAux+"\r\n");


            ticket.append("\r\n");
            ticket.append("\r\n");
            ticket.append("\r\n");
            ticket.append("\r\n");
            ticket.append("\r\n");
            ticket.append("\r\n");

            ticketString = ticket.toString().replace('ñ', 'n')
                    .replace('Ñ', 'N')
                    .replace('ó', 'o')
                    .replace('Ó', 'O')
                    .replace('á', 'a')
                    .replace('Á', 'A')
                    .replace('é', 'e')
                    .replace('É', 'E')
                    .replace('í', 'i')
                    .replace('Í', 'I')
                    .replace('ú', 'u')
                    .replace('Ú', 'U');


        } catch (Exception e) {
            // Log.e(TAG,e.getMessage(),e);
        }


        imprimirTikect(ticketString);
        //return ticketString;
    }

    public void generateTicketVenta(int idVenta, String metodo){

        String cadenaAux = "";
        String ticketString = "";

        try{
            ticket = new StringBuilder();


            Venta venta = realm.where(Venta.class).equalTo("idVenta", idVenta).findFirst();
            RealmResults<VentaDetalle> ventasDetalle = realm.where(VentaDetalle.class).equalTo("venta.idVenta",venta.getIdVenta()).findAll();
            PuntoVenta puntoVenta = venta.getPuntoVenta();


            cadenaAux = alineaTexto(2,puntoVenta.getNombreNegocio(),max);
            ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(2,puntoVenta.getCalle() +" "+puntoVenta.getNoExterior() + " " + puntoVenta.getColonia(),max);
            ticket.append(cadenaAux+"\r\n");

            //TODO Falta agregar ciudad y estado
            cadenaAux = alineaTexto(2,"CP "+puntoVenta.getCodigoPostal(),max);
            ticket.append(cadenaAux+"\r\n");

            //TODO no hay rfc a nivel de punto de venta, solo de empresa
            //cadenaAux = alineaTexto(2,"RFC: "+puntoVenta.getRFC,max);
            //ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(2,"TICKET DE VENTA",max);
            ticket.append(cadenaAux+"\r\n");

            ticket.append("\r\n");
            ticket.append("\r\n");

            cadenaAux = alineaTexto(1,"Tipo de venta: "+(venta.getTipo() == 1 ? "Contado" : "Credito"),max);
            ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(1,"Fecha: "+MetodosEstaticos.getFechaStr(venta.getFechaCreacion()),max);
            ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(1,"Folio: "+venta.getFolio(),max);
            ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(1,"Cte: "+venta.getCliente().getRazonSocial(),max);
            ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(1,"Atendio: "+venta.getStaff().getNombre() + " " + venta.getStaff().getApellidos(),max);
            ticket.append(cadenaAux+"\r\n");

            ticket.append("\r\n");

            ticket.append(getSeparator());

            ticket.append("\r\n");


            cadenaAux = completaHasta("Cantidad", 8, TipoAlineacion.IZQUIERDA, false);
            cadenaAux += completaHasta("Producto", 24, TipoAlineacion.IZQUIERDA, true);
            ticket.append(cadenaAux + "\r\n");

            cadenaAux = completaHasta("Precio", 7, TipoAlineacion.IZQUIERDA, false);
            cadenaAux += completaHasta("Subtotal", 8, TipoAlineacion.IZQUIERDA, false);
            cadenaAux += completaHasta("Desc.", 5, TipoAlineacion.IZQUIERDA, false);
            cadenaAux += completaHasta("Impts", 5, TipoAlineacion.IZQUIERDA, false);
            cadenaAux += completaHasta("Total", 7, TipoAlineacion.IZQUIERDA, false);
            ticket.append(cadenaAux + "\r\n");

            ticket.append(getSeparator());

            for (VentaDetalle detalle : ventasDetalle){
                String texto = "";

                texto = detalle.getCantidadProducto().toString();
                cadenaAux = completaHasta(texto, 8, TipoAlineacion.IZQUIERDA, false);
                texto = detalle.getProducto().getNombre();
                cadenaAux += completaHasta(texto, 24, TipoAlineacion.IZQUIERDA, true);
                ticket.append(cadenaAux + "\r\n");

                texto = MetodosEstaticos.getFormatoDecimal(detalle.getPrecioUnitario(), "###0.00");
                cadenaAux = completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
                texto = MetodosEstaticos.getFormatoDecimal(detalle.getSubtotal(), "###0.00");
                cadenaAux += completaHasta(texto, 8, TipoAlineacion.IZQUIERDA, false);
                texto = MetodosEstaticos.getFormatoDecimal(detalle.getDescuento(), "###0.00");
                cadenaAux += completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
                texto = MetodosEstaticos.getFormatoDecimal(detalle.getImpuestoTotal(), "###0.00");
                cadenaAux += completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
                texto = MetodosEstaticos.getFormatoDecimal(detalle.getTotal(), "###0.00");
                cadenaAux += completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
                ticket.append(cadenaAux + "\r\n");
            }

            ticket.append("\r\n");
            ticket.append("\r\n");

            String texto = "";
            texto = "Total: "+MetodosEstaticos.getFormatoDecimal(venta.getTotal(), "###0.00");
            cadenaAux = alineaTexto(3,texto,max);
            ticket.append(cadenaAux+"\r\n");

            texto = "Recibido: "+MetodosEstaticos.getFormatoDecimal(venta.getRecibido(), "###0.00");
            cadenaAux = alineaTexto(3,texto,max);
            ticket.append(cadenaAux+"\r\n");

            texto = "Metodo: "+metodo;
            cadenaAux = alineaTexto(3,texto,max);
            ticket.append(cadenaAux+"\r\n");

            texto = "Cambio: "+MetodosEstaticos.getFormatoDecimal(venta.getCambio(), "###0.00");
            cadenaAux = alineaTexto(3,texto,max);
            ticket.append(cadenaAux+"\r\n");

            if(venta.getTipo() == Constantes.TipoVenta.CREDITO){
                ticket.append("\r\n");
                ticket.append("\r\n");
                ticket.append("\r\n");
                ticket.append("\r\n");

                texto = "______________________________";
                cadenaAux = alineaTexto(2,texto,max);
                ticket.append(cadenaAux+"\r\n");

                texto = "Firma";
                cadenaAux = alineaTexto(2,texto,max);
                ticket.append(cadenaAux+"\r\n");

            }



            ticket.append("\r\n");
            ticket.append("\r\n");

            texto = "GRACIAS POR SU COMPRA";
            cadenaAux = alineaTexto(2,texto,max);
            ticket.append(cadenaAux+"\r\n");

            texto = "www.vennda.com";
            cadenaAux = alineaTexto(2,texto,max);
            ticket.append(cadenaAux+"\r\n");

            ticket.append("\r\n");
            texto = "Es necesario tener el ticket de venta para devolver producto.";
            cadenaAux = alineaTexto(2,texto,max);
            ticket.append(cadenaAux+"\r\n");


            ticket.append("\r\n");
            ticket.append("\r\n");
            ticket.append("\r\n");
            ticket.append("\r\n");
            ticket.append("\r\n");
            ticket.append("\r\n");

            ticketString = ticket.toString().replace('ñ', 'n')
                    .replace('Ñ', 'N')
                    .replace('ó', 'o')
                    .replace('Ó', 'O')
                    .replace('á', 'a')
                    .replace('Á', 'A')
                    .replace('é', 'e')
                    .replace('É', 'E')
                    .replace('í', 'i')
                    .replace('Í', 'I')
                    .replace('ú', 'u')
                    .replace('Ú', 'U');


        } catch (Exception e) {
           // Log.e(TAG,e.getMessage(),e);
        }


        imprimirTikect(ticketString);
        //return ticketString;
    }

    public void generateTicketDevolucion(int idDevolucion, String motivo){

        String cadenaAux = "";
        String ticketString = "";

        try{
            ticket = new StringBuilder();


            Devolucion devolucion = realm.where(Devolucion.class).equalTo("idDevolucion", idDevolucion).findFirst();
            RealmResults<DevolucionDetalle> devolucionDetalles = realm.where(DevolucionDetalle.class).equalTo("devolucion.idDevolucion",devolucion.getIdDevolucion()).findAll();
            PuntoVenta puntoVenta = devolucion.getPuntoVenta();


            cadenaAux = alineaTexto(2,puntoVenta.getNombreNegocio(),max);
            ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(2,puntoVenta.getCalle() +" "+puntoVenta.getNoExterior() + " " + puntoVenta.getColonia(),max);
            ticket.append(cadenaAux+"\r\n");

            //TODO Falta agregar ciudad y estado
            cadenaAux = alineaTexto(2,"CP "+puntoVenta.getCodigoPostal(),max);
            ticket.append(cadenaAux+"\r\n");

            //TODO no hay rfc a nivel de punto de venta, solo de empresa
            //cadenaAux = alineaTexto(2,"RFC: "+puntoVenta.getRFC,max);
            //ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(2,"TICKET DE DEVOLUCION",max);
            ticket.append(cadenaAux+"\r\n");

            ticket.append("\r\n");
            ticket.append("\r\n");

            cadenaAux = alineaTexto(1,"Tipo de venta: "+(devolucion.getTipo() == 1 ? "Contado" : "Credito"),max);
            ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(1,"Fecha: "+MetodosEstaticos.getFechaStr(devolucion.getFechaCreacion()),max);
            ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(1,"Cte: "+devolucion.getCliente().getRazonSocial(),max);
            ticket.append(cadenaAux+"\r\n");

            cadenaAux = alineaTexto(1,"Atendio: "+devolucion.getStaff().getNombre() + " " + devolucion.getStaff().getApellidos(),max);
            ticket.append(cadenaAux+"\r\n");

            ticket.append("\r\n");

            ticket.append(getSeparator());

            ticket.append("\r\n");


            cadenaAux = completaHasta("Cantidad", 8, TipoAlineacion.IZQUIERDA, false);
            cadenaAux += completaHasta("Producto", 24, TipoAlineacion.IZQUIERDA, true);
            ticket.append(cadenaAux + "\r\n");

            cadenaAux = completaHasta("Precio", 7, TipoAlineacion.IZQUIERDA, false);
            cadenaAux += completaHasta("Subtotal", 8, TipoAlineacion.IZQUIERDA, false);
            cadenaAux += completaHasta("Desc.", 5, TipoAlineacion.IZQUIERDA, false);
            cadenaAux += completaHasta("Impts", 5, TipoAlineacion.IZQUIERDA, false);
            cadenaAux += completaHasta("Total", 7, TipoAlineacion.IZQUIERDA, false);
            ticket.append(cadenaAux + "\r\n");

            ticket.append(getSeparator());

            for (DevolucionDetalle detalle : devolucionDetalles){
                String texto = "";

                texto = detalle.getCantidadProducto().toString();
                cadenaAux = completaHasta(texto, 8, TipoAlineacion.IZQUIERDA, false);
                texto = detalle.getProducto().getNombre();
                cadenaAux += completaHasta(texto, 24, TipoAlineacion.IZQUIERDA, true);
                ticket.append(cadenaAux + "\r\n");

                texto = MetodosEstaticos.getFormatoDecimal(detalle.getPrecioUnitario(), "###0.00");
                cadenaAux = completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
                texto = MetodosEstaticos.getFormatoDecimal(detalle.getSubtotal(), "###0.00");
                cadenaAux += completaHasta(texto, 8, TipoAlineacion.IZQUIERDA, false);
                texto = MetodosEstaticos.getFormatoDecimal(detalle.getDescuento(), "###0.00");
                cadenaAux += completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
                texto = MetodosEstaticos.getFormatoDecimal(detalle.getImpuestoTotal(), "###0.00");
                cadenaAux += completaHasta(texto, 5, TipoAlineacion.IZQUIERDA, false);
                texto = MetodosEstaticos.getFormatoDecimal(detalle.getTotal(), "###0.00");
                cadenaAux += completaHasta(texto, 7, TipoAlineacion.IZQUIERDA, false);
                ticket.append(cadenaAux + "\r\n");
            }

            ticket.append("\r\n");
            ticket.append("\r\n");

            String texto = "";

            texto = "Motivo: "+motivo;
            cadenaAux = alineaTexto(3,texto,max);
            ticket.append(cadenaAux+"\r\n");

            texto = "Total: "+MetodosEstaticos.getFormatoDecimal(devolucion.getTotal(), "###0.00");
            cadenaAux = alineaTexto(3,texto,max);
            ticket.append(cadenaAux+"\r\n");

            ticket.append("\r\n");
            ticket.append("\r\n");
            ticket.append("\r\n");
            ticket.append("\r\n");

            texto = "______________________________";
            cadenaAux = alineaTexto(2,texto,max);
            ticket.append(cadenaAux+"\r\n");

            texto = "Firma";
            cadenaAux = alineaTexto(2,texto,max);
            ticket.append(cadenaAux+"\r\n");

            ticket.append("\r\n");
            ticket.append("\r\n");
            texto = "GRACIAS POR SU VISITA";
            cadenaAux = alineaTexto(2,texto,max);
            ticket.append(cadenaAux+"\r\n");

            texto = "www.vennda.com";
            cadenaAux = alineaTexto(2,texto,max);
            ticket.append(cadenaAux+"\r\n");


            ticket.append("\r\n");
            ticket.append("\r\n");
            ticket.append("\r\n");
            ticket.append("\r\n");
            ticket.append("\r\n");
            ticket.append("\r\n");

            ticketString = ticket.toString().replace('ñ', 'n')
                    .replace('Ñ', 'N')
                    .replace('ó', 'o')
                    .replace('Ó', 'O')
                    .replace('á', 'a')
                    .replace('Á', 'A')
                    .replace('é', 'e')
                    .replace('É', 'E')
                    .replace('í', 'i')
                    .replace('Í', 'I')
                    .replace('ú', 'u')
                    .replace('Ú', 'U');


        } catch (Exception e) {
            // Log.e(TAG,e.getMessage(),e);
        }


        imprimirTikect(ticketString);
        //return ticketString;
    }

    public final class TipoAlineacion{
        public final static short IZQUIERDA = 0;
        public final static short DERECHA = 1;
    }

}
