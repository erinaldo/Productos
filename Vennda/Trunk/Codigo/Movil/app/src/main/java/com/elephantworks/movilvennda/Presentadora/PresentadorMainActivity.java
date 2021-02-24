package com.elephantworks.movilvennda.Presentadora;

import android.content.Context;
import android.util.Log;

import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Interfaces.IAsyncTask;
import com.elephantworks.movilvennda.Interfaces.IMainActivity;
import com.elephantworks.movilvennda.Modelos.Empresa;
import com.elephantworks.movilvennda.Modelos.Impuesto;
import com.elephantworks.movilvennda.Modelos.PuntoVenta;
import com.elephantworks.movilvennda.Modelos.Staff;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;
import com.elephantworks.movilvennda.Utilerias.Session;
import com.elephantworks.movilvennda.Utilerias.ValoresEstaticos;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedInputStream;
import java.io.DataOutputStream;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.SocketTimeoutException;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.atomic.AtomicInteger;

import io.realm.Realm;

/**
 * Created by ldelatorre on 29/05/2017.
 */
public class PresentadorMainActivity implements IAsyncTask {

    private IMainActivity mVista;
    private Context context;
    private String usuario;
    private String contrasena;
    private Realm realm;
    private Session sesion;
    private boolean error = false;

    public PresentadorMainActivity(IMainActivity mVista, Context context) {
        this.mVista = mVista;
        this.context = context;
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        sesion = new Session(context);
    }

    public void validarUsuario(String usuario, String contrasena)
    {
        //Log.d("Usuario y Contraseña", usuario + " " + contrasena);
        this.usuario = usuario;
        this.contrasena = contrasena;
        if(!usuario.equalsIgnoreCase("") && !contrasena.equalsIgnoreCase("")) {

           /* if(MetodosEstaticos.ValidarDatosBD.hayDatosEmpresa(context)){
                if(MetodosEstaticos.ValidarDatosBD.validarStaff(context, usuario, contrasena)){
                    sesion.setUsuario(usuario);
                    mVista.usuarioCorrecto();
                }else {
                    mVista.error(context.getString(R.string.error_inicio_sesion_lbl));
                }
            }else {
                new PresentadorAsyncTask(context,this).execute();
            }*/

            new PresentadorAsyncTask(context,this).execute();

        } else {
            mVista.error("Los campos no tienen que ir vacios");
        }

    }

    @Override
    public void before() {

    }

    @Override
    public String toDo() {
        try {
            URL url = new URL(ValoresEstaticos.SERVIDOR + "LoginStaff");
            URLConnection urlConnection = url.openConnection();
            String result = null;

            HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
            httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
            httpUrlConn.setDoOutput(true);
            httpUrlConn.setDoInput(true);
            httpUrlConn.setRequestProperty("Content-Type", "application/json");
            httpUrlConn.setRequestMethod("PUT");

            String stringJSON = "{'email': '"+usuario+"','pin': '"+contrasena+"'}";

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

    @Override
    public void after(String result) {
       // mVista.usuarioCorrecto();
       if(result != null){
            try{
                if(result.contains("!")){
                    mVista.error(result);
                }else{
                    JSONObject jsonResult = new JSONObject(result);
                    if (jsonResult.has("ResultMensaje")) {
                        String resultadoMensaje = jsonResult.getJSONObject("ResultMensaje").toString();
                        JSONObject mensaje = new JSONObject(resultadoMensaje);
                        mVista.error(mensaje.getString("mensaje"));
                    }else{

                        String resultadoEmpresa = jsonResult.getJSONObject("ResultsEmpresa").toString();
                        this.llenarEmpresa(resultadoEmpresa);

                        JSONArray resultadoPuntoVenta = jsonResult.getJSONArray("ResultsPuntoVenta");
                        this.llenarPuntoVenta(resultadoPuntoVenta);

                        JSONArray resultadoStaff = jsonResult.getJSONArray("ResultsStaff");
                        this.llenarStaff(resultadoStaff);

                        if(!error) {
                            sesion.setUsuario(usuario);
                            mVista.usuarioCorrecto();
                        }

                    }
                }

            } catch (Exception e){
                mVista.error(e.getMessage());
            }
        } else {
            mVista.error(context.getString(R.string.error_inicio_sesion_lbl));
        }
    }

    private void llenarEmpresa(final String resultadoEmpresa) throws Exception{

        realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
            @Override
            public void execute(Realm realm2) {
                try{

                    JSONObject empresaJSON = new JSONObject(resultadoEmpresa);

                    Object id = empresaJSON.getInt("id");
                    Empresa empresa = MetodosEstaticos.ValidarDatosBD.existeEmpresaBD(context, (int) id);
                    if(empresa == null){
                        empresa = realm2.createObject(Empresa.class,id); // Create a new object
                    }
                    empresa.setNombreEmpresa(empresaJSON.getString("nombreEmpresa"));
                    empresa.setDireccion(empresaJSON.getString("direccion"));
                    empresa.setCp(empresaJSON.getString("cp"));
                    empresa.setColonia(empresaJSON.getString("colonia"));
                    empresa.setRfc(empresaJSON.getString("rfc"));
                    empresa.setNombre(empresaJSON.getString("nombre"));
                    empresa.setApellidoPaterno(empresaJSON.getString("apellidoPaterno"));
                    empresa.setApellidoMaterno(empresaJSON.getString("apellidoMaterno"));
                    empresa.setCurp(empresaJSON.getString("curp"));
                    empresa.setPin(empresaJSON.getString("pin"));
                    empresa.setFormaPago(empresaJSON.getInt("formaPago"));
                    empresa.setLogo(empresaJSON.getString("logo"));

                    sesion.setIdEmpresa((int)id);

                }catch (Exception ex){
                    error = true;
                   mVista.error(ex.getMessage());
                }
            }
        });
    }

    private void llenarPuntoVenta(final JSONArray resultadoPuntoVenta) throws Exception{

            for(int i=0; i< resultadoPuntoVenta.length(); i++){

                final int x = i;
                realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
                    @Override
                    public void execute(Realm realm2) {
                        try{
                            Object id = resultadoPuntoVenta.getJSONObject(x).getInt("id");
                            PuntoVenta puntoVenta = MetodosEstaticos.ValidarDatosBD.existePuntoVentaBD(context, (int) id);
                            if (puntoVenta == null){
                                puntoVenta = realm2.createObject(PuntoVenta.class,id); // Create a new object
                            }
                            puntoVenta.setNumeroNegocio(resultadoPuntoVenta.getJSONObject(x).getString("numeroNegocio"));
                            puntoVenta.setNombreNegocio(resultadoPuntoVenta.getJSONObject(x).getString("nombreNegocio"));
                            puntoVenta.setTelefono(resultadoPuntoVenta.getJSONObject(x).getString("telefono"));
                            puntoVenta.setCelular(resultadoPuntoVenta.getJSONObject(x).getString("celular"));
                            puntoVenta.setCorreoElectronico(resultadoPuntoVenta.getJSONObject(x).getString("correoElectronico"));
                            puntoVenta.setCalle(resultadoPuntoVenta.getJSONObject(x).getString("calle"));
                            puntoVenta.setNoExterior(resultadoPuntoVenta.getJSONObject(x).getString("noExterior"));
                            puntoVenta.setNoInterior(resultadoPuntoVenta.getJSONObject(x).getString("noInterior"));
                            puntoVenta.setColonia(resultadoPuntoVenta.getJSONObject(x).getString("colonia"));
                            puntoVenta.setCodigoPostal(resultadoPuntoVenta.getJSONObject(x).getString("codigoPostal"));
                            //Todo: checar lo del float
                            // puntoVenta.setLatitud(resultadoPuntoVenta.getJSONObject(i).getString("latitud"));
                            // puntoVenta.setLongitud(resultadoPuntoVenta.getJSONObject(i).getString("longitud"));
                            puntoVenta.setCerrado(resultadoPuntoVenta.getJSONObject(x).getBoolean("cerrado"));
                            puntoVenta.setInventario(resultadoPuntoVenta.getJSONObject(x).getBoolean("inventario"));
                            puntoVenta.setImpresoraActivo(resultadoPuntoVenta.getJSONObject(x).getBoolean("impresoraActivo"));
                            puntoVenta.setActivo(resultadoPuntoVenta.getJSONObject(x).getBoolean("activo"));


                        }catch (Exception ex){
                            error = true;
                            mVista.error(ex.getMessage());
                        }
                    }
                });


            }
    }

    private void llenarStaff(final JSONArray resultadoStaff) throws Exception{

        for(int i=0; i< resultadoStaff.length(); i++){

            final int x = i;
            realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
                @Override
                public void execute(Realm realm2) {
                    try{

                        Object id = resultadoStaff.getJSONObject(x).getInt("id");
                        Staff staff = MetodosEstaticos.ValidarDatosBD.existeStaffBD(context, (int) id);
                        if(staff == null){
                            staff = realm2.createObject(Staff.class,id); // Create a new object
                        }
                        staff.setNumEmpleado(resultadoStaff.getJSONObject(x).getString("numEmpleado"));
                        staff.setNombre(resultadoStaff.getJSONObject(x).getString("nombre"));
                        staff.setApellidos(resultadoStaff.getJSONObject(x).getString("apellidos"));
                        staff.setPin(resultadoStaff.getJSONObject(x).getString("pin"));
                        staff.setEmail(resultadoStaff.getJSONObject(x).getString("email"));
                        staff.setActivo(resultadoStaff.getJSONObject(x).getBoolean("activo"));
                        staff.setAutorizaCancelacion(resultadoStaff.getJSONObject(x).getBoolean("autorizaCancelacion"));
                        Double porcentaje = 0.0;
                        if(!resultadoStaff.getJSONObject(x).getString("porcentajeDescuento").equals("null")){
                            porcentaje = resultadoStaff.getJSONObject(x).getDouble("porcentajeDescuento");
                        }
                        staff.setPorcentajeDescuento(porcentaje);


                    }catch (Exception ex){
                        error = true;
                        mVista.error(ex.getMessage());
                    }
                }
            });

        }
    }


}
