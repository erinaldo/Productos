package com.elephantworks.movilvennda.Presentadora;

import android.Manifest;
import android.content.Context;
import android.content.ContextWrapper;
import android.content.res.Resources;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Environment;
import android.os.StrictMode;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.NotificationCompat;
import android.support.v4.util.SimpleArrayMap;
import android.widget.Toast;

import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Interfaces.IAsyncTask;
import com.elephantworks.movilvennda.Interfaces.IMenu;
import com.elephantworks.movilvennda.Interfaces.IPuntoVenta;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.Empresa;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.Modelos.PuntoVenta;
import com.elephantworks.movilvennda.Modelos.Staff;
import com.elephantworks.movilvennda.Modelos.Venta;
import com.elephantworks.movilvennda.Modelos.VentaDetalle;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;
import com.elephantworks.movilvennda.Utilerias.Session;
import com.elephantworks.movilvennda.Utilerias.ValoresEstaticos;
import com.elephantworks.movilvennda.Vistas.MenuActivity;

import static android.os.Environment.getExternalStorageDirectory;
import static android.os.Environment.isExternalStorageEmulated;
import static android.support.v4.app.ActivityCompat.requestPermissions;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.SocketTimeoutException;
import java.net.URISyntaxException;
import java.net.URL;
import java.net.URLConnection;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;
import java.util.zip.ZipEntry;
import java.util.zip.ZipFile;
import java.util.zip.ZipInputStream;
import java.util.zip.ZipOutputStream;

import io.realm.Realm;
import io.realm.RealmQuery;

/**
 * Created by ldelatorre on 04/06/2017.
 */
public class PresentadorMenu implements IAsyncTask {
    private IMenu mVista;
    private Context context;
    private Session session;
    private Realm realm;
    private Venta ventaDevolucion;
    private String mensajeFinal = "";
    final int BUFFER = 2048;
    private static final int REQUEST_CODE = 0;


    public PresentadorMenu(Context context, IMenu mVista) {
        this.context = context;
        this.mVista = mVista;
        session = new Session(context);
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
    }

    public void llenarTextos(){
        int idPuntoVenta = session.getPuntoVenta();
        RealmQuery<PuntoVenta> query = realm.where(PuntoVenta.class);
        PuntoVenta puntoVenta = query.equalTo("idPuntoVenta",idPuntoVenta).findFirst();

        String nombre = session.getNombreUsuario();

        mVista.llenarTextosVista(nombre, puntoVenta.getNombreNegocio());
        new PresentadorAsyncTask(context,this).execute();

    }

    @Override
    public void before() {

    }

    @Override
    public String toDo() {
        String resultProductos = "";
        String resultCategorias = "";
        try{

            resultProductos = ObtenerZipImagenesProductos();
            resultCategorias = ObtenerZipImagenesCategorias();

        }catch (Exception e) {
            return "!"+context.getString(R.string.error_servidor_getApiImg);
        }
        return resultProductos + resultCategorias;
    }

    @Override
    public void after(String result) {
        if(result != null){
            try{

            } catch (Exception e){
               // mVista.error(e.getMessage());
            }
        } else {
            //mVista.error(context.getString(R.string.error_servidor_lbl));
        }
    }
    public String ObtenerZipImagenesProductos() {
        URL url;
        URLConnection urlConnection;
        HttpURLConnection httpUrlConn = null;
        String result = "";
        try {
            url = new URL(ValoresEstaticos.SERVIDOR + "respondZip");
            urlConnection = url.openConnection();

            httpUrlConn = (HttpURLConnection) urlConnection;
            httpUrlConn.setRequestProperty("Content-Type", "application/json");
            httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
            httpUrlConn.setDoOutput(true);
            httpUrlConn.setDoInput(true);

            httpUrlConn.setRequestMethod("PUT");

            //Obtener ID de la empresa
            String id = String.valueOf(session.getIdEmpresa());

            String stringJSON = "{\"empresaId\": \"" + id + "\",\"carpeta\":\"" + ValoresEstaticos.carpetaAPIImgProductos + "\",\"archivoZip\":\"" + ValoresEstaticos.nombreArchivoZipAPIProductos + "\",\"final\": \"false\"}";


            DataOutputStream dataOutputStream = new DataOutputStream(urlConnection.getOutputStream());
            dataOutputStream.writeBytes(stringJSON);
            dataOutputStream.flush();
            dataOutputStream.close();
            httpUrlConn.connect();


            byte[] buff = ConvertirResponseABytesArray(urlConnection);
            HacerZipConBytes_EnAndroid(buff);

            if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_CREATED || httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_OK ) {
                InputStream is = httpUrlConn.getInputStream();
                result = MetodosEstaticos.getStringFromInputStream(is);
            }
            else if(httpUrlConn.getErrorStream() != null){
                InputStream is = httpUrlConn.getErrorStream();
                result = MetodosEstaticos.getStringFromInputStream(is);
            } else {
                result = null;
            }

            return result;
        }catch (SocketTimeoutException e){
            return "!"+context.getString(R.string.error_servidor_getApiImg);
            //mVista.error(context.getString(R.string.error_servidor_lbl));
        }catch(Exception ex) {
            return "!"+context.getString(R.string.error_servidor_getApiImg);
        }finally {
            httpUrlConn.disconnect();
        }

    }
    public String ObtenerZipImagenesCategorias() {
        URL url;
        URLConnection urlConnection;
        HttpURLConnection httpUrlConn = null;
        String result = "";
        try {
            url = new URL(ValoresEstaticos.SERVIDOR + "respondZip");
            urlConnection = url.openConnection();

            httpUrlConn = (HttpURLConnection) urlConnection;
            httpUrlConn.setRequestProperty("Content-Type", "application/json");
            httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
            httpUrlConn.setDoOutput(true);
            httpUrlConn.setDoInput(true);

            httpUrlConn.setRequestMethod("PUT");

            //Obtener ID de la empresa
            String id = String.valueOf(session.getIdEmpresa());

            String stringJSON = "{\"empresaId\": \"" + id + "\",\"carpeta\":\"" + ValoresEstaticos.carpetaAPIImgCategorias + "\",\"archivoZip\":\"" + ValoresEstaticos.nombreArchivoZipAPICategorias + "\",\"final\": \"true\"}";


            DataOutputStream dataOutputStream = new DataOutputStream(urlConnection.getOutputStream());
            dataOutputStream.writeBytes(stringJSON);
            dataOutputStream.flush();
            dataOutputStream.close();
            httpUrlConn.connect();


            byte[] buff = ConvertirResponseABytesArray(urlConnection);
            HacerZipConBytes_EnAndroid(buff);

            if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_CREATED || httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_OK ) {
                InputStream is = httpUrlConn.getInputStream();
                result = MetodosEstaticos.getStringFromInputStream(is);
            }
            else if(httpUrlConn.getErrorStream() != null){
                InputStream is = httpUrlConn.getErrorStream();
                result = MetodosEstaticos.getStringFromInputStream(is);
            } else {
                result = null;
            }

            return result;
        }catch (SocketTimeoutException e){
            return "!"+context.getString(R.string.error_servidor_getApiImg);

            //mVista.error(context.getString(R.string.error_servidor_lbl));
        }catch(Exception ex) {
            System.out.print(ex);
            return "!"+context.getString(R.string.error_servidor_getApiImg);
        }finally {
            httpUrlConn.disconnect();
        }

    }
    public byte[] ConvertirResponseABytesArray(URLConnection connection){
        byte[] array = null;
        try{
            // Since you get a URLConnection, use it to get the InputStream
            InputStream in = connection.getInputStream();
            // Now that the InputStream is open, get the content length
            int contentLength = connection.getContentLength();

            // To avoid having to resize the array over and over and over as
            // bytes are written to the array, provide an accurate estimate of
            // the ultimate size of the byte array
            ByteArrayOutputStream tmpOut;
            if (contentLength != -1) {
                tmpOut = new ByteArrayOutputStream(contentLength);
            } else {
                tmpOut = new ByteArrayOutputStream(16384); // Pick some appropriate size
            }

            byte[] buf = new byte[512];
            while (true) {
                int len = in.read(buf);
                if (len == -1) {
                    break;
                }
                tmpOut.write(buf, 0, len);
            }
            in.close();
            tmpOut.close();

            array = tmpOut.toByteArray();
        }catch(Exception ex){
            System.out.print(ex);
            //return "!"+context.getString(R.string.error_servidor_getApiImg);
        }
        return array;
    }
    public void HacerZipConBytes_EnAndroid(byte[] buff){
        try{
            ZipInputStream zipStream = new ZipInputStream(new ByteArrayInputStream(buff));
            ZipEntry entry = null;
            while ((entry = zipStream.getNextEntry()) != null) {

                String entryName = entry.getName();
                File f = new File(context.getFilesDir().getPath());
                File[] lista = f.listFiles();
                EliminarArchivos(context.getFilesDir().getPath()  + "/" + entryName);
                FileOutputStream out = new FileOutputStream(context.getFilesDir().getPath()  + "/" + entryName);

                byte[] byteBuff = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = zipStream.read(byteBuff)) != -1)
                {
                    out.write(byteBuff, 0, bytesRead);
                }

                out.close();
                zipStream.closeEntry();
            }
            zipStream.close();
            File f = new File(context.getFilesDir().getPath());
            File[] lista = f.listFiles();
            int t = lista.length;
        }catch(Exception ex){
            System.out.print(ex);
            //return "!"+context.getString(R.string.error_servidor_getApiImg);
        }
    }

    public void EliminarArchivos(String rutaNombreArchivo){
        try {
            File f = new File(rutaNombreArchivo);
            if(f.exists()) {
                f.delete();
            }
        }catch (Exception ex){
            System.out.print(ex);
            //return "!"+context.getString(R.string.error_servidor_getApiImg);
        }
    }

    public void VerImagenesEnMemoria(String buscador){
        try {
            File f = new File(context.getFilesDir().getPath());
            File[] lista = f.listFiles();
            for(int x = 0; x<lista.length;x++){
                String texto = lista[x].toString();
                //if(lista[x].toString().contains("2_")){
                if(lista[x].toString().contains(buscador)){
                    File pruebaFile = new File(lista[x].toString());
                    pruebaFile.delete();
                }
            }
            int  le= lista.length;
        }catch (Exception ex){
            System.out.print(ex);
            //return "!"+context.getString(R.string.error_servidor_getApiImg);
        }
    }

    public String buscarTicket(String ticket){
        mVista.mostrarProgreso("Buscando folio...");
        String mensaje = "";
        ventaDevolucion = realm.where(Venta.class).equalTo("folio", ticket).findFirst();

        if(ventaDevolucion == null){

            mVista.cambiarMensajeProgreso("Buscando folio en el servidor...");

            String result = buscarTicketServidor(ticket);
            mensaje = validarTicketServidor(result);

            if(!mensaje.equals("")){
                mVista.cerrarProgeso();
                return mensaje;
            }

        }

        if(ventaDevolucion.getStaffCancelacion() != null){
            mensaje = "La venta se encuentra cancelada";
            return mensaje;
        }

        session.setDevolucion(ventaDevolucion.getFolio());
        mVista.cerrarProgeso();
        return mensaje;
    }

    private String buscarTicketServidor(String ticket){

        try {
            URL url = new URL(ValoresEstaticos.SERVIDOR + "ConsultaVentaDevolucion");
            URLConnection urlConnection = url.openConnection();
            String result = null;

            HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
            httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
            httpUrlConn.setDoOutput(true);
            httpUrlConn.setDoInput(true);
            httpUrlConn.setRequestProperty("Content-Type", "application/json");
            httpUrlConn.setRequestMethod("PUT");

            String stringJSON = "{'puntoVenta': '"+session.getPuntoVenta()+"','ventaFolio': '"+ticket+"'}";

            DataOutputStream dataOutputStream = new DataOutputStream(urlConnection.getOutputStream());
            dataOutputStream.writeBytes(stringJSON);
            dataOutputStream.flush();
            dataOutputStream.close();
            InputStream responseStream = new BufferedInputStream(urlConnection.getInputStream());
            //responseStream.close();


            httpUrlConn.connect();
            if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_CREATED || httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_OK ) {
                InputStream is = httpUrlConn.getInputStream();
                result = MetodosEstaticos.getStringFromInputStream(is);
            }
            else if(httpUrlConn.getErrorStream() != null){
                InputStream is = httpUrlConn.getErrorStream();
                result = MetodosEstaticos.getStringFromInputStream(is);
            } else {
                result = null;
            }

            return result;

        }catch (SocketTimeoutException e){
            return "!"+context.getString(R.string.error_servidor_lbl);
            //mVista.error(context.getString(R.string.error_servidor_lbl));
        } catch (Exception e) {
            return null;
        }

    }


    private String validarTicketServidor(final String result){

            if (result.contains("!")) {
                return result;
            } else {

                realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
                    @Override
                    public void execute(Realm realm2) {
                        try {
                            JSONObject jsonResult = new JSONObject(result);
                            if(!jsonResult.isNull("resultsVentaDevolucion")) {

                                //Guardar Venta
                                String resultadoVentaSTR = jsonResult.getJSONObject("resultsVentaDevolucion").toString();
                                JSONObject resultadoVenta = new JSONObject(resultadoVentaSTR);

                                Object id = resultadoVenta.getInt("id");
                                Venta venta = realm.createObject(Venta.class, id);
                                venta.setTipo(resultadoVenta.getInt("tipo"));
                                if (resultadoVenta.getString("fechaCreacion").equals("null")) {
                                    venta.setFechaCreacion(null);
                                } else {
                                    venta.setFechaCreacion(MetodosEstaticos.parseFecha(resultadoVenta.getString("fechaCreacion").replace("z","")));
                                }
                                venta.setFolio(resultadoVenta.getString("folio"));
                                venta.setSubtotal(resultadoVenta.getDouble("subtotal"));
                                venta.setImpuestos(resultadoVenta.getDouble("impuestos"));
                                venta.setTotal(resultadoVenta.getDouble("total"));
                                venta.setSaldo(resultadoVenta.getDouble("saldo"));
                                venta.setDescuento(resultadoVenta.getDouble("descuento"));
                                if (resultadoVenta.getString("fechaCancelacion").equals("null")) {
                                    venta.setFechaCancelacion(null);
                                } else {
                                    venta.setFechaCancelacion(MetodosEstaticos.parseFecha(resultadoVenta.getString("fechaCancelacion")));
                                }
                                venta.setMotivoCancelacion(resultadoVenta.getString("motivoCancelacion"));
                                if (resultadoVenta.getString("fechaVencimiento").equals("null")) {
                                    venta.setFechaVencimiento(null);
                                } else {
                                    venta.setFechaVencimiento(MetodosEstaticos.parseFecha(resultadoVenta.getString("fechaVencimiento")));
                                }

                                Staff staff = realm2.where(Staff.class).equalTo("idStaff", resultadoVenta.getJSONObject("staff").getInt("id")).findFirst();
                                venta.setStaff(staff);
                                venta.setStaffCancelacion(null);
                                Clientes clientes = realm2.where(Clientes.class).equalTo("idCliente", resultadoVenta.getJSONObject("cliente").getInt("id")).findFirst();
                                venta.setCliente(clientes);
                                PuntoVenta puntoVenta = realm2.where(PuntoVenta.class).equalTo("idPuntoVenta", resultadoVenta.getJSONObject("puntoVenta").getInt("id")).findFirst();
                                venta.setPuntoVenta(puntoVenta);

                                ventaDevolucion = venta;


                                //Guardar venta detalle
                                if(!jsonResult.isNull("resultsVentaDetalle")) {
                                    JSONArray resultsVentaDetalle = jsonResult.getJSONArray("resultsVentaDetalle");
                                    for(int i=0; i< resultsVentaDetalle.length(); i++){
                                        Object idDetalle = resultsVentaDetalle.getJSONObject(i).getInt("id");
                                        VentaDetalle detalle = realm.createObject(VentaDetalle.class, id);
                                        detalle.setListaPrecio(resultsVentaDetalle.getJSONObject(i).getString("listaPrecio"));
                                        detalle.setCantidadProducto(resultsVentaDetalle.getJSONObject(i).getDouble("cantidadProducto"));
                                        detalle.setPrecioUnitario(resultsVentaDetalle.getJSONObject(i).getDouble("precioUnitario"));
                                        detalle.setImpuestoUnitario(resultsVentaDetalle.getJSONObject(i).getDouble("impuestoUnitario"));
                                        detalle.setImpuestoTotal(resultsVentaDetalle.getJSONObject(i).getDouble("impuestoTotal"));
                                        detalle.setSubtotal(resultsVentaDetalle.getJSONObject(i).getDouble("subtotal"));
                                        detalle.setTotal(resultsVentaDetalle.getJSONObject(i).getDouble("total"));
                                        detalle.setDescuento(resultsVentaDetalle.getJSONObject(i).getDouble("descuento"));
                                        detalle.setPartida(resultsVentaDetalle.getJSONObject(i).getInt("partida"));
                                        if(resultsVentaDetalle.getJSONObject(i).getString("mFechaHora").equals("null")){
                                            detalle.setmFechaHora(null);
                                        }else {
                                            detalle.setmFechaHora(MetodosEstaticos.parseFecha(resultsVentaDetalle.getJSONObject(i).getString("mFechaHora")));
                                        }
                                        if(resultsVentaDetalle.getJSONObject(i).getString("cantidadDevuelta").equals("null")){
                                            detalle.setCantidadDevuelta(null);
                                        }else{
                                            detalle.setCantidadDevuelta(resultsVentaDetalle.getJSONObject(i).getDouble("cantidadDevuelta"));
                                        }

                                        detalle.setmUsuario(resultsVentaDetalle.getJSONObject(i).getString("mUsuario"));

                                        Productos producto = realm2.where(Productos.class).equalTo("idProducto", resultsVentaDetalle.getJSONObject(i).getJSONObject("producto").getInt("id")).findFirst();
                                        detalle.setProducto(producto);
                                        detalle.setVenta(venta);

                                    }

                                }

                            }else {
                                mensajeFinal = "No se encontro el folio en la base de datos";
                            }



                        }catch (Exception e){
                            realm2.cancelTransaction();
                            e.printStackTrace();
                           mensajeFinal = e.getMessage();
                        }
                    }

                });
            }

        return mensajeFinal;
    }


}
