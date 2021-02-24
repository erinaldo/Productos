package com.elephantworks.movilvennda.Presentadora;

import android.content.Context;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.StrictMode;
import android.widget.ArrayAdapter;
import android.widget.Toast;

import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Interfaces.IAsyncTask;
import com.elephantworks.movilvennda.Interfaces.IPuntoVenta;
import com.elephantworks.movilvennda.Modelos.Abono;
import com.elephantworks.movilvennda.Modelos.AperturaCierre;
import com.elephantworks.movilvennda.Modelos.Categorias;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.Cobranza;
import com.elephantworks.movilvennda.Modelos.Empresa;
import com.elephantworks.movilvennda.Modelos.FoliosVenta;
import com.elephantworks.movilvennda.Modelos.ImpresoraHomologada;
import com.elephantworks.movilvennda.Modelos.Impuesto;
import com.elephantworks.movilvennda.Modelos.Inventario;
import com.elephantworks.movilvennda.Modelos.Plan;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.Modelos.PuntoVenta;
import com.elephantworks.movilvennda.Modelos.Staff;
import com.elephantworks.movilvennda.Modelos.ValoresImpuesto;
import com.elephantworks.movilvennda.Modelos.ValoresReferencia;
import com.elephantworks.movilvennda.Modelos.Venta;
import com.elephantworks.movilvennda.Modelos.VentaDetalle;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.Constantes;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;
import com.elephantworks.movilvennda.Utilerias.Session;
import com.elephantworks.movilvennda.Utilerias.ValoresEstaticos;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.SocketTimeoutException;
import java.net.URISyntaxException;
import java.net.URL;
import java.net.URLConnection;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.LinkedList;
import java.util.Locale;

import io.realm.Realm;
import io.realm.RealmList;
import io.realm.RealmQuery;
import io.realm.RealmResults;

/**
 * Created by Elephant on 04/06/17.
 */

public class PresentadorPuntoVenta implements IAsyncTask {

    private IPuntoVenta mVista;
    private Context context;
    private Realm realm;
    private Session session;
    private int idPuntoVenta;
    private int idEmpresa;
    private boolean error;

    public PresentadorPuntoVenta(IPuntoVenta mVista, Context context) {
        this.mVista = mVista;
        this.context = context;
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        session = new Session(context);
    }

    public void llenarTitulos(){

        RealmQuery<Staff> query = realm.where(Staff.class);
        query.equalTo("email", session.getUsuario());
        RealmResults<Staff> staffResult = query.findAll();

        RealmQuery<Empresa> query2 = realm.where(Empresa.class);
        RealmResults<Empresa> empresaResult = query2.findAll();

        String empresa = empresaResult.first().getNombreEmpresa();
        Staff staff = staffResult.first();
        String nombreCompleto = staff.getNombre()+" "+staff.getApellidos();
        session.setNombreUsuario(nombreCompleto);
        session.setCorreoElectronicoStaff(staff.getEmail());
        String bienvenida = context.getResources().getString(R.string.msjBienvenida).replace("$0$", nombreCompleto);


        mVista.mostrarTitulos(empresa, bienvenida);

    }

    public void llenarSpinner(){

        RealmQuery<PuntoVenta> query = realm.where(PuntoVenta.class);
        RealmResults<PuntoVenta> puntoVentas = query.findAll();
        LinkedList puntosVenta = new LinkedList();

        puntosVenta.add(new ObjetosPuntoVenta(0, context.getResources().getString(R.string.spinnerSeleccionar)));
        for (PuntoVenta pv : puntoVentas) {
            puntosVenta.add(new ObjetosPuntoVenta(pv.getIdPuntoVenta(), pv.getNombreNegocio()));
        }

        ArrayAdapter spinner_adapter = new ArrayAdapter(context, android.R.layout.simple_spinner_item, puntosVenta);
        spinner_adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

        mVista.cargarSpinnerPuntoVenta(spinner_adapter);
    }

    public class ObjetosPuntoVenta{
        int id;
        String nombre;
        //Constructor
        public ObjetosPuntoVenta(int id, String nombre) {
            super();
            this.id = id;
            this.nombre = nombre;
        }
        @Override
        public String toString() {
            return nombre;
        }
        public int getId() {
            return id;
        }
    }

    public void ingresar(int idPunto){
        try{

            session.setPuntoVenta(idPunto);
            RealmQuery<Empresa> query = realm.where(Empresa.class);
            Empresa empresa = query.findFirst();
            idEmpresa = empresa.getIdEmpresa();
            idPuntoVenta = idPunto;

            new PresentadorAsyncTask(context,this).execute();
        }catch (Exception e){
            mVista.error(e.getMessage());
        }
    }

    @Override
    public void before() {

    }

    @Override
    public String toDo() {
        try {
            URL url = new URL(ValoresEstaticos.SERVIDOR + "ConsultaPuntoVenta");
            URLConnection urlConnection = url.openConnection();
            String result = null;

            HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
            httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
            httpUrlConn.setDoOutput(true);
            httpUrlConn.setDoInput(true);
            httpUrlConn.setRequestProperty("Content-Type", "application/json");
            httpUrlConn.setRequestMethod("PUT");

            String stringJSON = "{'puntoVentaId': '"+idPuntoVenta+"','empresaId': '"+idEmpresa+"'}";

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

                        JSONArray resultadoClientes = jsonResult.getJSONArray("resultsClientes");
                        this.llenarCliente(resultadoClientes);

                        JSONArray resultsCategorias = jsonResult.getJSONArray("resultsCategorias");
                        this.llenarCategorias(resultsCategorias);

                        JSONArray resultValoresImp = jsonResult.getJSONArray("resultValoresImp");
                        this.llenarValoresImp(resultValoresImp);

                        JSONArray resultImpuesto = jsonResult.getJSONArray("resultsImpuesto");
                        this.llenarImpuesto(resultImpuesto);

                        JSONArray resultadoProductos = jsonResult.getJSONArray("resultsProducto");
                        this.llenarProductos(resultadoProductos);

                        JSONArray resultsInventario = jsonResult.getJSONArray("resultsInventario");
                        this.llenarInventario(resultsInventario);

                        JSONArray resultsValoresRef = jsonResult.getJSONArray("resultsValoresRef");
                        this.llenarValoresRef(resultsValoresRef);

                        JSONArray resultsVentas = jsonResult.getJSONArray("resultsVentas");
                        this.llenarVentas(resultsVentas);

                        JSONArray resultsVentasDetalle = jsonResult.getJSONArray("resultsVentasDetalle");
                        this.llenarVentasDetalle(resultsVentasDetalle);

                        JSONArray resultsAbono = jsonResult.getJSONArray("resultsAbono");
                        this.llenarAbono(resultsAbono);

                        JSONArray resultCobranza = jsonResult.getJSONArray("resultsCobranza");
                        this.llenarCobranza(resultCobranza);

                        //TODO enlazar el metodo con la web haciendo una peticion web trallendome el unico registro que se tenga de la empresa de la tabla FoliosEmpresa y crear esta tabla en la web
                        llenarFolio();

                        if (jsonResult.has("resultsImpresora")) {

                            String resultImpresora = jsonResult.getJSONObject("resultsImpresora").toString();
                            this.llenarImpresora(resultImpresora);
                        }

                        JSONArray resultPlan = jsonResult.getJSONArray("resultsPlan");
                        this.llenarPlan(resultPlan);

                        if(!error){
                            mVista.ingresarMenu();
                        }


                    }
                }

            } catch (Exception e){
                mVista.error(e.getMessage());
            }
        } else {
            mVista.error(context.getString(R.string.error_servidor_lbl));
        }
    }

    private void llenarCliente(final JSONArray resultadoCliente) throws Exception{

        for(int i=0; i< resultadoCliente.length(); i++){
            final int x = i;
            realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
                @Override
                public void execute(Realm realm2) {
                    try{
                        Object id = resultadoCliente.getJSONObject(x).getInt("id");

                        Clientes cliente = MetodosEstaticos.ValidarDatosBD.existeClienteBD(context, (int) id);

                        if(cliente == null) {
                            cliente = realm2.createObject(Clientes.class, id);
                        }

                        cliente.setClave(resultadoCliente.getJSONObject(x).getString("clave"));
                        cliente.setRazonSocial(resultadoCliente.getJSONObject(x).getString("razonSocial"));
                        cliente.setRfc(resultadoCliente.getJSONObject(x).getString("rfc"));
                        cliente.setDomicilio(resultadoCliente.getJSONObject(x).getString("domicilio"));
                        cliente.setColonia(resultadoCliente.getJSONObject(x).getString("colonia"));
                        cliente.setCp(resultadoCliente.getJSONObject(x).getString("cp"));
                        cliente.setDiasCredito(resultadoCliente.getJSONObject(x).getInt("diasCredito"));
                        cliente.setEmail(resultadoCliente.getJSONObject(x).getString("email"));
                        cliente.setListaPrecios(resultadoCliente.getJSONObject(x).getInt("listaPrecios"));
                        cliente.setTelefonoCelular(resultadoCliente.getJSONObject(x).getString("telefonoCelular"));
                        cliente.setAlta(resultadoCliente.getJSONObject(x).getInt("alta"));
                        cliente.setEnvio(1);

                        Double valor = 0.0;
                        if (!resultadoCliente.getJSONObject(x).getString("limiteCredito").equals("null")) {
                            valor = resultadoCliente.getJSONObject(x).getDouble("limiteCredito");
                        }
                        cliente.setLimiteCredito(valor);

                        if (!resultadoCliente.getJSONObject(x).getString("creditoActual").equals("null")) {
                            valor = resultadoCliente.getJSONObject(x).getDouble("creditoActual");
                        }
                        cliente.setCreditoActual(valor);

                    }catch (Exception ex){
                        error = true;
                        mVista.error(ex.getMessage());
                    }
                }
            });



        }

    }

    private void llenarProductos(final JSONArray resultadoProductos) throws Exception{

        for(int i=0; i< resultadoProductos.length(); i++){
            final int x = i;
            int idCategoria = resultadoProductos.getJSONObject(x).getJSONObject("categoria").getInt("id");
            RealmQuery<Categorias> query = realm.where(Categorias.class).equalTo("idCategoria",idCategoria);
            final Categorias categorias = query.findFirst();

            realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
                @Override
                public void execute(Realm realm2) {
                    try{

                        Object id = resultadoProductos.getJSONObject(x).getInt("id");

                        Productos producto = MetodosEstaticos.ValidarDatosBD.existeProductoBD(context, (int) id);
                        if(producto == null) {
                            producto = realm2.createObject(Productos.class, id);
                        }
                        producto.setClave(resultadoProductos.getJSONObject(x).getString("clave"));
                        producto.setNombre(resultadoProductos.getJSONObject(x).getString("nombre"));
                        producto.setDescripcion(resultadoProductos.getJSONObject(x).getString("descripcion"));
                        producto.setCodigoBarras(resultadoProductos.getJSONObject(x).getString("codigoBarras"));
                        producto.setImagen(resultadoProductos.getJSONObject(x).getString("imagen"));
                        producto.setPrecio(resultadoProductos.getJSONObject(x).getDouble("precio"));
                        Double precio = 0.0;
                        if(!resultadoProductos.getJSONObject(x).getString("precio2").equals("null")){
                            precio = resultadoProductos.getJSONObject(x).getDouble("precio2");
                        }
                        producto.setPrecio2(precio);

                        if(!resultadoProductos.getJSONObject(x).getString("precio3").equals("null")){
                            precio = resultadoProductos.getJSONObject(x).getDouble("precio3");
                        }
                        producto.setPrecio3(precio);

                        if(!resultadoProductos.getJSONObject(x).getString("precio4").equals("null")){
                            precio = resultadoProductos.getJSONObject(x).getDouble("precio4");
                        }
                        producto.setPrecio4(precio);

                        if(!resultadoProductos.getJSONObject(x).getString("precio5").equals("null")){
                            precio = resultadoProductos.getJSONObject(x).getDouble("precio5");
                        }
                        producto.setPrecio5(precio);

                        producto.setActivo(resultadoProductos.getJSONObject(x).getBoolean("activo"));

                        producto.setCategorias(categorias);

                        if(resultadoProductos.getJSONObject(x).getJSONArray("impuesto").length() > 0){
                            producto.setImpuestos(getImpuestos(resultadoProductos.getJSONObject(x).getJSONArray("impuesto")));
                        }



                    }catch (Exception ex){
                        error = true;
                        mVista.error(ex.getMessage());
                    }
                }
            });

        }

    }

    private void llenarCategorias(final JSONArray resultadoCategorias) throws Exception {

        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm2) {
                try {
                    Object id = 0;
                    Categorias categoria = MetodosEstaticos.ValidarDatosBD.existeCategoriaBD(context, 0);
                    if(categoria == null){
                        categoria = realm2.createObject(Categorias.class, id);
                        categoria.setIdentificador(context.getResources().getString(R.string.valorIdentificardorCategoria));
                        categoria.setNombre(context.getResources().getString(R.string.valorNombreCategoria));
                        categoria.setActivo(true);
                    }

                } catch (Exception ex) {
                    mVista.error(ex.getMessage());
                }
            }
        });

        for(int i=0; i< resultadoCategorias.length(); i++){

            final int x = i;
            realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
                @Override
                public void execute(Realm realm2) {
                    try{
                        Object id = resultadoCategorias.getJSONObject(x).getInt("id");
                        Categorias categoria = MetodosEstaticos.ValidarDatosBD.existeCategoriaBD(context, (int) id);
                        if(categoria == null){
                             categoria = realm2.createObject(Categorias.class,id);
                        }
                        categoria.setIdentificador(resultadoCategorias.getJSONObject(x).getString("identificador"));
                        categoria.setNombre(resultadoCategorias.getJSONObject(x).getString("nombre"));
                        categoria.setActivo(resultadoCategorias.getJSONObject(x).getBoolean("activo"));
                        categoria.setImagen(resultadoCategorias.getJSONObject(x).getString("imagen"));

                    }catch (Exception ex){
                        error = true;
                        mVista.error(ex.getMessage());
                    }
                }
            });

        }
    }

    private void llenarInventario(final JSONArray resultsInventario) throws Exception{

        for(int i=0; i< resultsInventario.length(); i++){

            final int x = i;
            int idProducto = resultsInventario.getJSONObject(x).getJSONObject("producto").getInt("id");
            RealmQuery<Productos> query = realm.where(Productos.class).equalTo("idProducto",idProducto);
            final Productos producto = query.findFirst();

            realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
                @Override
                public void execute(Realm realm2) {
                    try{
                        Object id = resultsInventario.getJSONObject(x).getInt("id");
                        Inventario inventario = MetodosEstaticos.ValidarDatosBD.existeInventarioBD(context, (int) id);
                        if(inventario == null){
                             inventario = realm2.createObject(Inventario.class,id);
                        }
                        Double cantidad = 0.0;
                        if(!resultsInventario.getJSONObject(x).getString("cantidad").equals("null")){
                            cantidad = resultsInventario.getJSONObject(x).getDouble("cantidad");
                        }
                        inventario.setCantidad(cantidad);
                        inventario.setActivo(resultsInventario.getJSONObject(x).getBoolean("activo"));
                        inventario.setProductos(producto);
                    }catch (Exception ex){
                        error = true;
                        mVista.error(ex.getMessage());
                    }
                }
            });
        }
    }

    private void llenarImpresora(final String resultImpresora) throws Exception {

            realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
                @Override
                public void execute(Realm realm2) {
                    try{
                        JSONObject impresoraJSON = new JSONObject(resultImpresora);
                        Object id = impresoraJSON.getInt("id");
                        ImpresoraHomologada impresora = MetodosEstaticos.ValidarDatosBD.existeImpresoraBD(context, (int) id);
                        if(impresora == null) {
                            impresora = realm2.createObject(ImpresoraHomologada.class, id);
                        }
                        impresora.setNombreImpresora(impresoraJSON.getString("nombreImpresora"));
                    }catch (Exception ex){
                        error = true;
                        mVista.error(ex.getMessage());
                    }
                }
            });

    }

    private void llenarPlan(final JSONArray resultPlan) throws Exception{
        for(int i=0; i< resultPlan.length(); i++){
            final int x = i;
            realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
                @Override
                public void execute(Realm realm2) {
                    try{
                        Object id = resultPlan.getJSONObject(x).getInt("id");
                        Plan plan = MetodosEstaticos.ValidarDatosBD.existePlanBD(context, (int) id);
                        if(plan == null){
                            plan = realm2.createObject(Plan.class,id);
                        }
                        plan.setIdentificador(resultPlan.getJSONObject(x).getString("identificador"));
                        plan.setCobroTarjeta(resultPlan.getJSONObject(x).getBoolean("cobroTarjeta"));
                        plan.setImpresionTicket(resultPlan.getJSONObject(x).getBoolean("impresionTicket"));
                        plan.setInventario(resultPlan.getJSONObject(x).getBoolean("inventario"));

                    }catch (Exception ex){
                        error = true;
                        mVista.error(ex.getMessage());
                    }
                }
            });
        }
    }

    private void llenarImpuesto(final JSONArray resultPlan) throws Exception {
        for(int i=0; i< resultPlan.length(); i++){
            final int x = i;
            realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
                @Override
                public void execute(Realm realm2) {
                    try{
                        Object id = resultPlan.getJSONObject(x).getInt("id");
                        Impuesto impuesto = MetodosEstaticos.ValidarDatosBD.existeImpuestoBD(context, (int) id);
                        if(impuesto == null){
                            impuesto = realm2.createObject(Impuesto.class,id);
                        }
                        impuesto.setIdentificador(resultPlan.getJSONObject(x).getString("identificador"));
                        impuesto.setJerarquia(resultPlan.getJSONObject(x).getInt("jerarquia"));
                        impuesto.setDespuesDeImpuesto(resultPlan.getJSONObject(x).getBoolean("despuesDeImpuesto"));

                        String resultTipo = resultPlan.getJSONObject(x).getString("tipoAplicacion");
                        JSONObject tipoJSON = new JSONObject(resultTipo);

                        int tipoAplicacion = 0;
                        if (tipoJSON.getString("name").equals("PORCENTAJE")){
                            tipoAplicacion = Constantes.TipoAplicaionImpusto.PORCENTAJE;
                        }else if(tipoJSON.getString("name").equals("IMPORTE")){
                            tipoAplicacion = Constantes.TipoAplicaionImpusto.IMPORTE;
                        }
                        impuesto.setTipoAplicacion(tipoAplicacion);
                        impuesto.setActivo(resultPlan.getJSONObject(x).getBoolean("activo"));

                        if(resultPlan.getJSONObject(x).getJSONArray("valores").length() > 0){
                            impuesto.setValoresImpuestos(getValoresImpuestos(resultPlan.getJSONObject(x).getJSONArray("valores")));
                        }

                    }catch (Exception ex){
                        error = true;
                        mVista.error(ex.getMessage());
                    }
                }
            });



        }
    }

    private void llenarValoresImp(final JSONArray resultValoresImpuesto){
        final SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd", Locale.ENGLISH);
        for(int i=0; i< resultValoresImpuesto.length(); i++){
            final int x = i;

            realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
                @Override
                public void execute(Realm realm2) {
                    try{
                        Object id = resultValoresImpuesto.getJSONObject(x).getInt("id");
                        ValoresImpuesto valores = MetodosEstaticos.ValidarDatosBD.existeValoresImpuestoBD(context, (int) id);
                        if(valores == null){
                                valores = realm2.createObject(ValoresImpuesto.class,id);
                        }
                        Date inicio = formato.parse(resultValoresImpuesto.getJSONObject(x).getString("inicio"));
                        valores.setInicio(inicio);
                        Date fin = formato.parse(resultValoresImpuesto.getJSONObject(x).getString("fin"));
                        valores.setFin(fin);
                        valores.setTasa(resultValoresImpuesto.getJSONObject(x).getDouble("tasa"));
                        valores.setActivo(resultValoresImpuesto.getJSONObject(x).getBoolean("activo"));

                    }catch (Exception ex){
                        error = true;
                        mVista.error(ex.getMessage());
                    }
                }
            });


        }

    }

    private void llenarValoresRef(final JSONArray resultsValoresRef)throws Exception {
        for(int i=0; i< resultsValoresRef.length(); i++){
            final int x = i;
            realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
                @Override
                public void execute(Realm realm2) {
                    try{
                        Object id = resultsValoresRef.getJSONObject(x).getInt("id");

                        ValoresReferencia vReferencia = MetodosEstaticos.ValidarDatosBD.existeValoresReferencia(context, (int) id);
                        if(vReferencia == null){
                            vReferencia = realm2.createObject(ValoresReferencia.class,id);
                        }
                        vReferencia.setClave(resultsValoresRef.getJSONObject(x).getString("clave"));
                        vReferencia.setValor(resultsValoresRef.getJSONObject(x).getInt("valor"));
                        vReferencia.setDescripcion(resultsValoresRef.getJSONObject(x).getString("descripcion"));

                    }catch (Exception ex){
                        error = true;
                        mVista.error(ex.getMessage());
                    }
                }
            });

        }
    }

    private void llenarFolio(){

        final String fechaFolio = MetodosEstaticos.getFechaActualFolioStr();

        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm2) {
                try{

                    //TODO terminar lo del folio con el servidor
                   FoliosVenta query = realm.where(FoliosVenta.class).findFirst();

                    if(query == null){
                        Object id = 1;
                        FoliosVenta foliosVenta = realm2.createObject(FoliosVenta.class,id);
                        foliosVenta.setEmpresa(idEmpresa);
                        foliosVenta.setPuntoVenta(idPuntoVenta);
                        foliosVenta.setFecha(fechaFolio);
                        foliosVenta.setConsecutivo(1);
                    }else{
                        FoliosVenta foliosVenta = realm.where(FoliosVenta.class).findFirst();
                        if(foliosVenta.getFecha().equals(fechaFolio)){
                            int consecutivo = foliosVenta.getConsecutivo() + 1;
                            foliosVenta.setConsecutivo(consecutivo);
                        }else {
                            foliosVenta.setFecha(fechaFolio);
                            foliosVenta.setConsecutivo(1);
                        }
                    }

                }catch (Exception ex){
                    error = true;
                    mVista.error(ex.getMessage());
                }
            }
        });
    }

    private void llenarVentas(final JSONArray resultsVentas)throws Exception{
        for(int i=0; i< resultsVentas.length(); i++){
            final int x = i;
            realm.executeTransaction(new Realm.Transaction() {
                @Override
                public void execute(Realm realm2) {
                    try{
                        Object id = resultsVentas.getJSONObject(x).getInt("id");

                        Venta venta = MetodosEstaticos.ValidarDatosBD.existeVentas(context, (int) id);
                        if(venta == null){
                            venta = realm2.createObject(Venta.class,id);
                        }
                        venta.setTipo(resultsVentas.getJSONObject(x).getInt("tipo"));
                        venta.setFormaPago(resultsVentas.getJSONObject(x).getInt("formaPago"));// falta
                        venta.setFolio(resultsVentas.getJSONObject(x).getString("folio"));
                        double numero = 0.0;
                        if(!resultsVentas.getJSONObject(x).getString("subtotal").equals("null")){
                            numero = resultsVentas.getJSONObject(x).getDouble("subtotal");
                        }
                        venta.setSubtotal(numero);
                        numero = 0.0;

                        if(!resultsVentas.getJSONObject(x).getString("impuestos").equals("null")){
                            numero = resultsVentas.getJSONObject(x).getDouble("impuestos");
                        }
                        venta.setImpuestos(numero);
                        numero = 0.0;

                        if(!resultsVentas.getJSONObject(x).getString("descuento").equals("null")){
                            numero = resultsVentas.getJSONObject(x).getDouble("descuento");
                        }
                        venta.setDescuento(numero);
                        numero = 0.0;

                        if(!resultsVentas.getJSONObject(x).getString("total").equals("null")){
                            numero = resultsVentas.getJSONObject(x).getDouble("total");
                        }
                        venta.setTotal(numero);
                        numero = 0.0;

                        if(!resultsVentas.getJSONObject(x).getString("saldo").equals("null")){
                            numero = resultsVentas.getJSONObject(x).getDouble("saldo");
                        }
                        venta.setSaldo(numero);
                        numero = 0.0;

                        if(!resultsVentas.getJSONObject(x).getString("recibido").equals("null")){
                            numero = resultsVentas.getJSONObject(x).getDouble("recibido");
                        }
                        venta.setRecibido(numero);
                        numero = 0.0;

                        if(!resultsVentas.getJSONObject(x).getString("cambio").equals("null")){
                            numero = resultsVentas.getJSONObject(x).getDouble("cambio");
                        }
                        venta.setCambio(numero);


                        venta.setMotivoCancelacion(resultsVentas.getJSONObject(x).getString("motivoCancelacion"));

                        SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss");
                        Date fecha = null;
                        if(!resultsVentas.getJSONObject(x).getString("fechaCancelacion").equals("null")){
                            fecha = df.parse(resultsVentas.getJSONObject(x).getString("fechaCancelacion"));
                        }
                        venta.setFechaCancelacion(fecha);

                        if(!resultsVentas.getJSONObject(x).getString("fechaVencimiento").equals("null")){
                            fecha = df.parse(resultsVentas.getJSONObject(x).getString("fechaVencimiento"));
                        }
                        venta.setFechaVencimiento(fecha);

                        if(!resultsVentas.getJSONObject(x).getString("fechaCreacion").equals("null")){
                            fecha = df.parse(resultsVentas.getJSONObject(x).getString("fechaCreacion"));
                        }
                        venta.setFechaCreacion(fecha);

                        int idStaff = resultsVentas.getJSONObject(x).getJSONObject("staff").getInt("id");
                        Staff staff = realm2.where(Staff.class).equalTo("idStaff", idStaff).findFirst();
                        venta.setStaff(staff);

                        Staff staffCancelacion = null;
                        if(!resultsVentas.getJSONObject(x).getString("staffCancelacion").equals("null")){
                            int idStaffCancelacion = resultsVentas.getJSONObject(x).getJSONObject("staffCancelacion").getInt("id");
                            staffCancelacion = realm2.where(Staff.class).equalTo("idStaff", idStaffCancelacion).findFirst();
                        }
                        venta.setStaffCancelacion(staffCancelacion);

                        int idCliente = resultsVentas.getJSONObject(x).getJSONObject("cliente").getInt("id");
                        Clientes cliente = realm2.where(Clientes.class).equalTo("idCliente", idCliente).findFirst();
                        venta.setCliente(cliente);

                        int idPunto = resultsVentas.getJSONObject(x).getJSONObject("puntoVenta").getInt("id");
                        PuntoVenta puntoVenta = realm2.where(PuntoVenta.class).equalTo("idPuntoVenta", idPunto).findFirst();
                        venta.setPuntoVenta(puntoVenta);

                        venta.setEnvio(0);

                    }catch (Exception ex){
                        error = true;
                        mVista.error(ex.getMessage());
                    }
                }
            });

        }
    }

    private void llenarVentasDetalle(final JSONArray resultsVentasDetalle)throws Exception{
        for(int i=0; i< resultsVentasDetalle.length(); i++){
            final int x = i;
            realm.executeTransaction(new Realm.Transaction() {
                @Override
                public void execute(Realm realm2) {
                    try{
                        Object id = resultsVentasDetalle.getJSONObject(x).getInt("id");

                        VentaDetalle ventaDetalle = MetodosEstaticos.ValidarDatosBD.existeVentaDetalle(context, (int) id);
                        if(ventaDetalle == null){
                            ventaDetalle = realm2.createObject(VentaDetalle.class,id);
                        }
                        ventaDetalle.setListaPrecio(resultsVentasDetalle.getJSONObject(x).getString("listaPrecio"));
                        ventaDetalle.setmUsuario(resultsVentasDetalle.getJSONObject(x).getString("mUsuario"));
                        double numero = 0.0;
                        if(!resultsVentasDetalle.getJSONObject(x).getString("cantidadProducto").equals("null")){
                            numero = resultsVentasDetalle.getJSONObject(x).getDouble("cantidadProducto");
                        }
                        ventaDetalle.setCantidadProducto(numero);
                        numero = 0.0;

                        if(!resultsVentasDetalle.getJSONObject(x).getString("precioUnitario").equals("null")){
                            numero = resultsVentasDetalle.getJSONObject(x).getDouble("precioUnitario");
                        }
                        ventaDetalle.setPrecioUnitario(numero);
                        numero = 0.0;

                        if(!resultsVentasDetalle.getJSONObject(x).getString("impuestoUnitario").equals("null")){
                            numero = resultsVentasDetalle.getJSONObject(x).getDouble("impuestoUnitario");
                        }
                        ventaDetalle.setImpuestoUnitario(numero);
                        numero = 0.0;

                        if(!resultsVentasDetalle.getJSONObject(x).getString("impuestoTotal").equals("null")){
                            numero = resultsVentasDetalle.getJSONObject(x).getDouble("impuestoTotal");
                        }
                        ventaDetalle.setImpuestoTotal(numero);
                        numero = 0.0;

                        if(!resultsVentasDetalle.getJSONObject(x).getString("subtotal").equals("null")){
                            numero = resultsVentasDetalle.getJSONObject(x).getDouble("subtotal");
                        }
                        ventaDetalle.setSubtotal(numero);
                        numero = 0.0;

                        if(!resultsVentasDetalle.getJSONObject(x).getString("total").equals("null")){
                            numero = resultsVentasDetalle.getJSONObject(x).getDouble("total");
                        }
                        ventaDetalle.setTotal(numero);
                        numero = 0.0;

                        if(!resultsVentasDetalle.getJSONObject(x).getString("descuento").equals("null")){
                            numero = resultsVentasDetalle.getJSONObject(x).getDouble("descuento");
                        }
                        ventaDetalle.setDescuento(numero);
                        numero = 0.0;

                        if(!resultsVentasDetalle.getJSONObject(x).getString("cantidadDevuelta").equals("null")){
                            numero = resultsVentasDetalle.getJSONObject(x).getDouble("cantidadDevuelta");
                        }
                        ventaDetalle.setCantidadDevuelta(numero);
                        ventaDetalle.setPartida(resultsVentasDetalle.getJSONObject(x).getInt("partida"));
                        SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss");
                        Date fecha = null;
                        if(!resultsVentasDetalle.getJSONObject(x).getString("mFechaHora").equals("null")){
                            fecha = df.parse(resultsVentasDetalle.getJSONObject(x).getString("mFechaHora"));
                        }
                        ventaDetalle.setmFechaHora(fecha);

                        int idVenta = resultsVentasDetalle.getJSONObject(x).getJSONObject("venta").getInt("id");
                        Venta venta = realm2.where(Venta.class).equalTo("idVenta", idVenta).findFirst();
                        ventaDetalle.setVenta(venta);

                        int idProducto = resultsVentasDetalle.getJSONObject(x).getJSONObject("producto").getInt("id");
                        Productos producto = realm2.where(Productos.class).equalTo("idProducto", idProducto).findFirst();
                        ventaDetalle.setProducto(producto);

                        venta.setEnvio(1);

                    }catch (Exception ex){
                        error = true;
                        mVista.error(ex.getMessage());
                    }
                }
            });

        }
    }

    private void llenarAbono(final JSONArray resultsAbono)throws Exception{
        for(int i=0; i< resultsAbono.length(); i++){
            final int x = i;
            realm.executeTransaction(new Realm.Transaction() {
                @Override
                public void execute(Realm realm2) {
                    try{
                        Object id = resultsAbono.getJSONObject(x).getInt("id");

                        Abono abono = MetodosEstaticos.ValidarDatosBD.existeAbono(context, (int) id);
                        if(abono == null){
                            abono = realm2.createObject(Abono.class,id);
                        }
                        abono.setMetodoPago(resultsAbono.getJSONObject(x).getInt("metodoPago"));
                        abono.setReferencia(resultsAbono.getJSONObject(x).getString("referencia"));
                        double numero = 0.0;
                        if(!resultsAbono.getJSONObject(x).getString("monto").equals("null")){
                            numero = resultsAbono.getJSONObject(x).getDouble("monto");
                        }
                        abono.setMonto(numero);
                        abono.setEnvio(1);

                    }catch (Exception ex){
                        error = true;
                        mVista.error(ex.getMessage());
                    }
                }
            });

        }
    }

    private void llenarCobranza(final JSONArray resultsCobranza)throws Exception{
        for(int i=0; i< resultsCobranza.length(); i++){
            final int x = i;
            realm.executeTransaction(new Realm.Transaction() {
                @Override
                public void execute(Realm realm2) {
                    try{
                        Object id = resultsCobranza.getJSONObject(x).getInt("id");

                        Cobranza cobranza = MetodosEstaticos.ValidarDatosBD.existeCobranza(context, (int) id);
                        if(cobranza == null){
                            cobranza = realm2.createObject(Cobranza.class,id);
                        }
                        double numero = 0.0;
                        if(!resultsCobranza.getJSONObject(x).getString("saldo").equals("null")){
                            numero = resultsCobranza.getJSONObject(x).getDouble("saldo");
                        }
                        cobranza.setSaldo(numero);
                        numero = 0.0;

                        if(!resultsCobranza.getJSONObject(x).getString("saldoAbono").equals("null")){
                            numero = resultsCobranza.getJSONObject(x).getDouble("saldoAbono");
                        }
                        cobranza.setSaldoAbono(numero);

                        SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss");
                        Date fecha = null;
                        if(!resultsCobranza.getJSONObject(x).getString("fecha").equals("null")){
                            fecha = df.parse(resultsCobranza.getJSONObject(x).getString("fecha"));
                        }
                        cobranza.setFecha(fecha);

                        int idAbono = resultsCobranza.getJSONObject(x).getJSONObject("abono").getInt("id");
                        Abono abono = realm2.where(Abono.class).equalTo("idAbono", idAbono).findFirst();
                        cobranza.setAbono(abono);

                        int idVenta = resultsCobranza.getJSONObject(x).getJSONObject("venta").getInt("id");
                        Venta venta = realm2.where(Venta.class).equalTo("idVenta", idVenta).findFirst();
                        cobranza.setVenta(venta);

                        cobranza.setEnvio(1);

                    }catch (Exception ex){
                        error = true;
                        mVista.error(ex.getMessage());
                    }
                }
            });

        }
    }

    private RealmList<ValoresImpuesto> getValoresImpuestos(JSONArray valoresID){
        RealmList<ValoresImpuesto> lista = new RealmList<ValoresImpuesto>();

        for(int i=0; i< valoresID.length(); i++){
            try{
                int id = valoresID.getJSONObject(i).getInt("id");
                ValoresImpuesto valoresImpuesto = realm.where(ValoresImpuesto.class).equalTo("idValoresImpuesto",id).findFirst();
                lista.add(valoresImpuesto);
            }catch (Exception ex){
                error = true;
                mVista.error(ex.getMessage());
            }
        }

        return lista;
    }

    private RealmList<Impuesto> getImpuestos(JSONArray impuestosID){
        RealmList<Impuesto> lista = new RealmList<Impuesto>();

        for(int i=0; i< impuestosID.length(); i++){
            try{
                int id = impuestosID.getJSONObject(i).getInt("id");
                Impuesto impuesto = realm.where(Impuesto.class).equalTo("idImpuesto",id).findFirst();
                lista.add(impuesto);
            }catch (Exception ex){
                error = true;
                mVista.error(ex.getMessage());
            }
        }

        return lista;
    }

    public boolean validarAperturaCaja(){
        //boolean hayApertura = false;
       if(session.getIdAperturaCierre() != 0)
            return true;


        return false;
    }

}


