package com.elephantworks.movilvennda.Presentadora;

import android.content.Context;
import android.widget.ArrayAdapter;

import com.elephantworks.movilvennda.Adaptadores.DineroAdapter;
import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Interfaces.IAperturaCierre;
import com.elephantworks.movilvennda.Interfaces.IAsyncTask;
import com.elephantworks.movilvennda.Modelos.AperturaCierre;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.Cobranza;
import com.elephantworks.movilvennda.Modelos.Devolucion;
import com.elephantworks.movilvennda.Modelos.DevolucionDetalle;
import com.elephantworks.movilvennda.Modelos.Empresa;
import com.elephantworks.movilvennda.Modelos.ImpuestoDetalle;
import com.elephantworks.movilvennda.Modelos.Inventario;
import com.elephantworks.movilvennda.Modelos.PuntoVenta;
import com.elephantworks.movilvennda.Modelos.Staff;
import com.elephantworks.movilvennda.Modelos.ValoresReferencia;
import com.elephantworks.movilvennda.Modelos.Venta;
import com.elephantworks.movilvennda.Modelos.VentaDetalle;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;
import com.elephantworks.movilvennda.Utilerias.Session;
import com.elephantworks.movilvennda.Utilerias.ValoresEstaticos;
import com.elephantworks.movilvennda.Vistas.ClienteActivity;

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
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

import io.realm.Realm;
import io.realm.RealmQuery;
import io.realm.RealmResults;

/**
 * Created by ldelatorre on 17/06/2017.
 */
public class PresentadorAperturaCierre implements IAsyncTask {

    private IAperturaCierre mVista;
    private Context context;
    private Realm realm;
    private Session session;
    private HashMap<String, Dinero> dineroHashMap = new HashMap<>();
    private DineroAdapter mDinero;
    private String respuestaJson;

    public PresentadorAperturaCierre(IAperturaCierre mVista, Context context) {
        this.mVista = mVista;
        this.context = context;
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        session = new Session(context);
    }

    public void llenarSpinnerDeniminacion(){

        RealmQuery<ValoresReferencia> query = realm.where(ValoresReferencia.class);
        RealmResults<ValoresReferencia> valores = query.equalTo("clave","DINER").findAll();
        LinkedList vReferencia = new LinkedList();

        for (ValoresReferencia pv : valores) {
            vReferencia.add(new ObjetosValoresReferencia(pv.getIdValoreRef(), pv.getDescripcion()));
        }

        ArrayAdapter spinner_adapter = new ArrayAdapter(context, android.R.layout.simple_spinner_item, vReferencia);
        spinner_adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

        mVista.cargarSpinnerDenominacion(spinner_adapter);
    }

    public void agregarDenominacion(int denominacion, String cantidad, String importe){

        RealmQuery<ValoresReferencia> query = realm.where(ValoresReferencia.class);
        ValoresReferencia valor = query.equalTo("clave","DINER").equalTo("valor",denominacion).findFirst();

        dineroHashMap.put(valor.getDescripcion(), new Dinero(cantidad,valor.getDescripcion(),importe));

        // Inicializar el adaptador con la fuente de datos.
        mDinero = new DineroAdapter(context, new ArrayList<>(dineroHashMap.values()));
        mVista.cargarLista(mDinero);

    }

    public class ObjetosValoresReferencia{
        int id;
        String nombre;
        //Constructor
        public ObjetosValoresReferencia(int id, String nombre) {
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

    public class Dinero{
        String denominacion;
        String cantidad;
        String importe;

        public Dinero(String cantidad, String denominacion, String importe) {
            this.cantidad = cantidad;
            this.denominacion = denominacion;
            this.importe = importe;
        }

        public String getCantidad() {
            return cantidad;
        }

        public void setCantidad(String cantidad) {
            this.cantidad = cantidad;
        }

        public String getDenominacion() {
            return denominacion;
        }

        public void setDenominacion(String denominacion) {
            this.denominacion = denominacion;
        }

        public String getImporte() {
            return importe;
        }

        public void setImporte(String impuesto) {
            this.importe = impuesto;
        }
    }

    public double obtenerValorDenominacion(int denominacion){

        double valor = 0.0;

        switch (denominacion){
            case 1: valor = 0.50; break;
            case 2: valor = 1; break;
            case 3: valor = 2; break;
            case 4: valor = 5; break;
            case 5: valor = 10; break;
            case 6: valor = 20; break;
            case 7: valor = 50; break;
            case 8: valor = 100; break;
            case 9: valor = 200; break;
            case 10: valor = 500; break;
            case 11: valor = 1000; break;
        }

        return valor;
    }

    public void eliminarDinero(String denominacion){
        dineroHashMap.remove(denominacion);

        // Inicializar el adaptador con la fuente de datos.
        mDinero = new DineroAdapter(context, new ArrayList<>(dineroHashMap.values()));
        mVista.cargarLista(mDinero);
    }

    public void mostrarTotal(){
        double total = 0.0;

        for (Map.Entry<String, Dinero> entry : dineroHashMap.entrySet()) {
            total = total + Double.parseDouble(entry.getValue().getImporte());
        }

        mVista.cargarTotal(MetodosEstaticos.getFormatoDecimal(total,"###0.00"));
    }

    public void guardarAperturaCierre(final boolean apertura, final double total){

        RealmQuery<Staff> query = realm.where(Staff.class);
        final Staff staff = query.equalTo("email",session.getUsuario()).findFirst();

        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm2) {
                try{
                    if(apertura){
                        Number currentIdNum = realm.where(AperturaCierre.class).max("idApertura");
                        int id;
                        if(currentIdNum == null) {
                            id = 1;
                        } else {
                            id = currentIdNum.intValue() + 1;
                        }

                        AperturaCierre aperturaCierre = realm2.createObject(AperturaCierre.class,id); // Create a new object
                        aperturaCierre.setFechaAbre(new Date());
                        aperturaCierre.setUsuarioAbre(staff);
                        aperturaCierre.setMontoAbre(total);
                        aperturaCierre.setEnvio(0);

                        session.setIdAperturaCierre(id);
                    }else {

                        RealmQuery<AperturaCierre> query = realm.where(AperturaCierre.class);
                        AperturaCierre aperturaCierre = query.equalTo("idApertura",session.getIdAperturaCierre()).findFirst();

                        aperturaCierre.setFechaCierra(new Date());
                        aperturaCierre.setUsuarioCierra(staff);
                        aperturaCierre.setMontoCierra(total);

                    }

                    //mVista.salir();

                }catch (Exception ex){
                    mVista.error(ex.getMessage());
                }
            }
        });

        if(!apertura){
            try {
                respuestaJson = crearJSON();
                new PresentadorAsyncTask(context,this).execute();
            } catch (JSONException e) {
                mVista.error(e.getMessage());
            }

        }
    }

    public boolean existeApertura(){
        if(session.getIdAperturaCierre() != 0){
            return true;
        }

        return false;
    }

    @Override
    public void before() {

    }

    @Override
    public String toDo() {
        try {
            URL url = new URL(ValoresEstaticos.SERVIDOR + "CierreDeCaja");
            URLConnection urlConnection = url.openConnection();
            String result = null;

            HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
            httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
            httpUrlConn.setDoOutput(true);
            httpUrlConn.setDoInput(true);
            httpUrlConn.setRequestProperty("Content-Type", "application/json");
            httpUrlConn.setRequestMethod("PUT");

            DataOutputStream dataOutputStream = new DataOutputStream(urlConnection.getOutputStream());
            dataOutputStream.writeBytes(respuestaJson);
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
        if(result != null) {
            try {
                if (result.contains("!")) {
                    mVista.error(result);
                }else{
                    //TODO cambiar por texto string
                    session.setIdAperturaCierre(0);
                    session.setIdClienteVentas(0);
                    mVista.salir("Información enviada correctamente");
                }
            } catch (Exception ex) {
                mVista.error(ex.getMessage());
            }
        }
    }


    private String crearJSON() throws JSONException {

        //consultas
        Empresa empresa = realm.where(Empresa.class).findFirst();
        RealmResults<Clientes> clientes = realm.where(Clientes.class).equalTo("envio",0).findAll();
        AperturaCierre aperturaCierre = realm.where(AperturaCierre.class).equalTo("envio",0).findFirst();
        RealmResults<Inventario> inventarios = realm.where(Inventario.class).findAll();
        RealmResults<Venta> ventas = realm.where(Venta.class).equalTo("envio",0).findAll();
        RealmResults<Devolucion> devoluciones = realm.where(Devolucion.class).equalTo("envio", 0).findAll();

        int contador = 0;
        JSONObject jsonGeneral = new JSONObject();

        for (Clientes cliente : clientes){
            JSONObject manCli = new JSONObject();
            if(contador == 0){
                jsonGeneral.accumulate("Clientes",manCli);
            }
            manCli.put("clave", cliente.getClave());
            manCli.put("razonSocial",cliente.getRazonSocial());
            manCli.put("rfc", cliente.getRfc());
            manCli.put("domicilio", cliente.getDomicilio());
            manCli.put("colonia", cliente.getColonia());
            manCli.put("cp", cliente.getCp());
            manCli.put("diasCredito", cliente.getDiasCredito());
            manCli.put("limiteCredito", cliente.getLimiteCredito());
            manCli.put("creditoActual", cliente.getCreditoActual());
            manCli.put("email", cliente.getEmail());
            manCli.put("listaPrecios", cliente.getListaPrecios());
            manCli.put("telefonoCelular", cliente.getTelefonoCelular());
            manCli.put("alta", cliente.getAlta());
            manCli.put("empresa",empresa.getIdEmpresa());
            jsonGeneral.accumulate("Clientes",manCli);
            setEnvioCliente(cliente.getIdCliente());
            contador++;
        }
        contador = 0;
        if(aperturaCierre != null){
            JSONObject manApe = new JSONObject();
            manApe.put("usuarioAbre",aperturaCierre.getUsuarioAbre().getIdStaff());
            manApe.put("fechaAbre",aperturaCierre.getFechaAbre());
            manApe.put("montoAbre",aperturaCierre.getMontoAbre());
            manApe.put("usuarioCierra",aperturaCierre.getUsuarioCierra().getIdStaff());
            manApe.put("fechaCierra",aperturaCierre.getFechaCierra());
            manApe.put("montoCierra",aperturaCierre.getMontoCierra());
            jsonGeneral.accumulate("AperturaCierre", manApe);
            setEnvioAperturaCierre(aperturaCierre.getIdApertura());
        }

        for (Inventario inventario : inventarios){
            JSONObject manInv = new JSONObject();
            if(contador == 0){
                jsonGeneral.accumulate("Inventarios",manInv);
            }
            manInv.put("idInventario",inventario.getIdInventario());
            manInv.put("cantidad",inventario.getCantidad());
            manInv.put("activo",inventario.isActivo());
            manInv.put("producto",inventario.getProductos().getIdProducto());
            jsonGeneral.accumulate("Inventarios",manInv);
            contador++;
        }
        contador = 0;
        for (Venta venta : ventas){ //ventas, ventaDetalle, ImpuestoDetalle
            JSONObject manVen = new JSONObject();
            if(contador == 0){
                jsonGeneral.accumulate("Ventas",manVen);
            }
            manVen.put("tipo", venta.getTipo());
            manVen.put("fechaCreacion",venta.getFechaCreacion());
            manVen.put("folio",venta.getFolio());
            manVen.put("subtotal", venta.getSubtotal());
            manVen.put("impuestos", venta.getImpuestos());
            manVen.put("descuento", venta.getDescuento());
            manVen.put("total", venta.getTotal());
            manVen.put("saldo", venta.getSaldo());
            manVen.put("fechaCancelacion", venta.getFechaCancelacion());
            manVen.put("motivoCancelacion", venta.getMotivoCancelacion());
            manVen.put("staff", venta.getStaff().getIdStaff());
            manVen.put("staffCancelacion", (venta.getStaffCancelacion() != null ? venta.getStaffCancelacion().getIdStaff() : ""));
            manVen.put("fechaVencimiento", venta.getFechaVencimiento());
            manVen.put("cliente", venta.getCliente().getIdCliente());
            manVen.put("puntoVenta", venta.getPuntoVenta().getIdPuntoVenta());
            manVen.put("empresa", empresa.getIdEmpresa());
            manVen.put("formaPago", venta.getFormaPago());
            manVen.put("recibido", venta.getRecibido());
            manVen.put("cambio", venta.getCambio());
            manVen.put("id", venta.getIdVenta());

            VentaDetalle ventasDetalle = realm.where(VentaDetalle.class).equalTo("envio",0).equalTo("venta.idVenta",venta.getIdVenta()).findFirst();
            manVen.put("listaPrecioD", ventasDetalle.getListaPrecio());
            manVen.put("cantidadProductoD",ventasDetalle.getCantidadProducto());
            manVen.put("precioUnitarioD", ventasDetalle.getPrecioUnitario());
            manVen.put("impuestoUnitarioD", ventasDetalle.getImpuestoUnitario());
            manVen.put("impuestoTotalD",ventasDetalle.getImpuestoTotal());
            manVen.put("subtotalD",ventasDetalle.getSubtotal());
            manVen.put("totalD",ventasDetalle.getTotal());
            manVen.put("descuentoD", ventasDetalle.getDescuento());
            manVen.put("partidaD", ventasDetalle.getPartida());
            manVen.put("mFechaHoraD",ventasDetalle.getmFechaHora());
            manVen.put("mUsuarioD",ventasDetalle.getmUsuario());
            manVen.put("productoD", ventasDetalle.getProducto().getIdProducto());
            setEnvioVentaDetalle(ventasDetalle.getIdVentaDetalle());

            ImpuestoDetalle impuesto = realm.where(ImpuestoDetalle.class).equalTo("envio",0).equalTo("ventaDetalle.idVentaDetalle", ventasDetalle.getIdVentaDetalle()).findFirst();
            if(impuesto != null) {
                manVen.put("precioBaseI", impuesto.getPrecioBase());
                manVen.put("tasaI", impuesto.getTasa());
                manVen.put("importeI", impuesto.getImporte());
                setEnvioImpuesto(impuesto.getIdImpuestoDetalle());
            }

            RealmResults<Cobranza> cobranzas = realm.where(Cobranza.class).equalTo("envio",0).equalTo("venta.idVenta", venta.getIdVenta()).findAll();
            for (Cobranza cobranza: cobranzas){
                manVen.put("fechaC",cobranza.getFecha());
                manVen.put("saldoC",cobranza.getSaldo());
                manVen.put("saldoAbonoC",cobranza.getSaldoAbono());
                manVen.put("metodoPagoA",cobranza.getAbono().getMetodoPago());
                manVen.put("referenciaA",cobranza.getAbono().getReferencia());
                manVen.put("montoA",cobranza.getAbono().getMonto());
                setEnvioCobranza(cobranza.getIdCobranza());
            }
            setEnvioVenta(venta.getIdVenta());
            jsonGeneral.accumulate("Ventas",manVen);
            contador++;
        }

        contador = 0;
        for (Devolucion devolucion : devoluciones){
            JSONObject manInv = new JSONObject();
            if(contador == 0){
                jsonGeneral.accumulate("Devoluciones",manInv);
            }
            manInv.put("tipo", devolucion.getTipo());
            manInv.put("formaPago", devolucion.getFormaPago());
            manInv.put("fechaCreacion", devolucion.getFechaCreacion());
            manInv.put("folio", devolucion.getFolio());
            manInv.put("subtotal", devolucion.getSubtotal());
            manInv.put("impuestos", devolucion.getImpuestos());
            manInv.put("descuento", devolucion.getDescuento());
            manInv.put("total", devolucion.getTotal());
            manInv.put("saldo", devolucion.getSaldo());
            manInv.put("motivo", devolucion.getMotivo());
            manInv.put("staff", devolucion.getStaff().getIdStaff());
            manInv.put("staffDevolucion", devolucion.getStaffDevolucion().getIdStaff());
            manInv.put("cliente", devolucion.getCliente().getIdCliente());
            manInv.put("puntoVenta", devolucion.getPuntoVenta().getIdPuntoVenta());
            manInv.put("venta", devolucion.getVenta().getIdVenta());
            manInv.put("empresa", empresa.getIdEmpresa());

            DevolucionDetalle detalle = realm.where(DevolucionDetalle.class).equalTo("envio",0).equalTo("devolucion.idDevolucion", devolucion.getIdDevolucion()).findFirst();
            manInv.put("listaPrecioD", detalle.getListaPrecio());
            manInv.put("cantidadProductoD", detalle.getCantidadProducto());
            manInv.put("precioUnitarioD", detalle.getPrecioUnitario());
            manInv.put("impuestoUnitarioD", detalle.getImpuestoUnitario());
            manInv.put("impuestoTotalD", detalle.getImpuestoTotal());
            manInv.put("subtotalD", detalle.getSubtotal());
            manInv.put("totalD", detalle.getTotal());
            manInv.put("descuentoD", detalle.getDescuento());
            manInv.put("partidaD", detalle.getPartida());
            manInv.put("mFechaHoraD", detalle.getmFechaHora());
            manInv.put("mUsuarioD", detalle.getmUsuario());
            manInv.put("devolucionD", detalle.getDevolucion().getIdDevolucion());
            manInv.put("productoD", detalle.getProducto().getIdProducto());

            setEnvioDevolucionDetalle(detalle.getIdDevolucionDetalle());
            setEnvioDevolucion(devolucion.getIdDevolucion());
            jsonGeneral.accumulate("Devoluciones",manInv);
            contador++;
        }

        return jsonGeneral.toString();

    }

    private void setEnvioCliente(final int idCliente){
        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm) {
                try {
                    RealmQuery<Clientes> query = realm.where(Clientes.class);
                    Clientes clientes = query.equalTo("idCliente", idCliente).findFirst();
                    clientes.setEnvio(1);
                } catch (Exception ex) {
                    mVista.error(ex.getMessage());
                }
            }
        });
    }

    private void setEnvioVenta(final int idVenta){
        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm) {
                try {
                    RealmQuery<Venta> query = realm.where(Venta.class);
                    Venta venta = query.equalTo("idVenta", idVenta).findFirst();
                    venta.setEnvio(1);
                } catch (Exception ex) {
                    mVista.error(ex.getMessage());
                }
            }
        });
    }

    private void setEnvioVentaDetalle(final int idVentaDetalle){
        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm) {
                try {
                    RealmQuery<VentaDetalle> query = realm.where(VentaDetalle.class);
                    VentaDetalle ventaDetalle = query.equalTo("idVentaDetalle", idVentaDetalle).findFirst();
                    ventaDetalle.setEnvio(1);
                } catch (Exception ex) {
                    mVista.error(ex.getMessage());
                }
            }
        });
    }

    private void setEnvioCobranza(final int idCobranza){
        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm) {
                try {
                    RealmQuery<Cobranza> query = realm.where(Cobranza.class);
                    Cobranza cobranza = query.equalTo("idCobranza", idCobranza).findFirst();
                    cobranza.setEnvio(1);
                } catch (Exception ex) {
                    mVista.error(ex.getMessage());
                }
            }
        });
    }

    private void setEnvioImpuesto(final int idImpuesto){
        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm) {
                try {
                    RealmQuery<ImpuestoDetalle> query = realm.where(ImpuestoDetalle.class);
                    ImpuestoDetalle impuestoDetalle = query.equalTo("idImpuestoDetalle", idImpuesto).findFirst();
                    impuestoDetalle.setEnvio(1);
                } catch (Exception ex) {
                    mVista.error(ex.getMessage());
                }
            }
        });
    }

    private void setEnvioAperturaCierre(final int id){
        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm) {
                try {
                    RealmQuery<AperturaCierre> query = realm.where(AperturaCierre.class);
                    AperturaCierre aperturaCierre = query.equalTo("idApertura", id).findFirst();
                    aperturaCierre.setEnvio(1);
                } catch (Exception ex) {
                    mVista.error(ex.getMessage());
                }
            }
        });
    }

    private void setEnvioDevolucion(final int id){
        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm) {
                try {
                    RealmQuery<Devolucion> query = realm.where(Devolucion.class);
                    Devolucion devolucion = query.equalTo("idDevolucion", id).findFirst();
                    devolucion.setEnvio(1);
                } catch (Exception ex) {
                    mVista.error(ex.getMessage());
                }
            }
        });
    }

    private void setEnvioDevolucionDetalle(final int id){
        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm) {
                try {
                    RealmQuery<DevolucionDetalle> query = realm.where(DevolucionDetalle.class);
                    DevolucionDetalle devolucionDetalle = query.equalTo("idDevolucionDetalle", id).findFirst();
                    devolucionDetalle.setEnvio(1);
                } catch (Exception ex) {
                    mVista.error(ex.getMessage());
                }
            }
        });
    }

}
