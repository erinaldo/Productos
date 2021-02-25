package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.PreLiquidacion;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.VisitaHist;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDet;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaPedidoAnticipado;
import com.amesol.routelite.presentadores.parcelables.DatosAbnDetalle;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.CapturaCobranzaDet;
import com.amesol.routelite.vistas.CapturaCobranzaPedidoAnticipado;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.SortedMap;
import java.util.TreeMap;

/**
 * Created by projas on 08/10/2015.
 */
public class CapturarCobranzaPedidoAnticipado extends Presentador {
    ICapturaCobranzaPedidoAnticipado mVista;

    String mAccion;
    TransProd transProd;

    Abono oAbono;
    String Folio;
    Visita vis;

    float saldoInicial;

    public CapturarCobranzaPedidoAnticipado(CapturaCobranzaPedidoAnticipado capturaCobranzaPedidoAnticipado, String accion)
    {
        mVista = capturaCobranzaPedidoAnticipado;
        mAccion = accion;
    }

    public void setTransProdIds(String transProdId) throws Exception {
        transProd = new TransProd();
        transProd.TransProdID = transProdId;
        BDVend.recuperar(transProd);
    }

    public TransProd getTransProd() {
        return transProd;
    }

    public void setFolio(String folio)
    {
        Folio = folio;
    }

    @Override
    public void iniciar()
    {
        try
        {

            saldoInicial = transProd.Saldo;
            generarCobranza();

        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }
    }

    public boolean validarAbono()
    {
        try
        {
                //Cobranza.VistaDetalle det = itDet.next();
                if (!validarImportePago(mVista.getImporte()))
                    return false;

                if (mVista.getTipoPago() != 1)
                    if (!validarBancoPago(mVista.getTipoBanco()))
                        return false;

                if (!((CONHist) Sesion.get(Sesion.Campo.CONHist)).get("ExcederAbono").equals("1"))
                {
                    if (mVista.getImporte() > saldoInicial)
                    {
                        mVista.mostrarError(Mensajes.get("E0038"));
                        return false;
                    }
                }
                if (((MOTConfiguracion) Sesion.get(Sesion.Campo.MOTConfiguracion)).get("SaldarVentasCobranza").equals("1"))
                {
                    if (mVista.getImporte() < saldoInicial)
                    {
                        mVista.mostrarError(Mensajes.get("E0790").replace("$0$", Mensajes.get("XVenta")));
                        return false;
                    }
                }

            //if (importe <= 0)
                //throw new Exception(Mensajes.get("I0246"));

            if (mVista.getTipoPago() != 1 && mVista.getTipoBanco() == 0) {
                mVista.mostrarError(Mensajes.get("I0245"));
                return false;
            }

            //Date fechaCheque = null;
            //if (mVista.getFechaCheque() != null)
               // fechaCheque = mVista.getFechaCheque();

            return true;
        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
            return false;
        }
    }

    public boolean grabarCobranza(){
        try {
            ABNDetalle abt = new ABNDetalle();
            abt.ABNId = oAbono.ABNId;
            abt.ABDId =  KeyGen.getId();
            abt.TipoPago = mVista.getTipoPago();
            abt.Importe = Generales.getRound(mVista.getImporte(),2);
            abt.SaldoDeposito = Generales.getRound(mVista.getImporte(),2);
            abt.MonedaID = mVista.getMonedaId();
            abt.TipoBanco = mVista.getTipoBanco();
            abt.Referencia = mVista.getReferencia();
            abt.FechaCheque = mVista.getFechaCheque();
            abt.MFechaHora = Generales.getFechaHoraActual();
            abt.Enviado = false;
            abt.MUsuarioID = oAbono.MUsuarioID;

            oAbono.ABNDetalle.add(abt);

            Cobranza.guardarCobranzaPagoAnticipado(oAbono, transProd, vis);
            BDVend.commit();

            return true;
        }catch(NullPointerException exNull){
            try {
                BDVend.rollback();
            }catch (Exception ex2){
                mVista.mostrarError("Error al deshacer transaccion");
            }
            mVista.mostrarError("Error de nulos");
        }catch (Exception ex){
            try {
                BDVend.rollback();
            }catch (Exception ex2){
                mVista.mostrarError("Error al deshacer transaccion");
            }
           mVista.mostrarError("grabar Cobranza: " + ex.getMessage());
        }
        return false;
    }


    private Visita generarVisita() throws Exception {
        try {

            Visita vis = new Visita();
            //if (Consultas.ConsultasVisita.obtenerVisitas())
            vis.VisitaClave = transProd.ClienteClave;
            vis.DiaClave = ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave;
            if (BDVend.existe(vis)){
                BDVend.recuperar(vis);
            }else{
                vis.ClienteClave = transProd.ClienteClave;
                vis.VendedorId = ((Vendedor) Sesion.get(Sesion.Campo.VendedorActual)).VendedorId;
                vis.RUTClave = ((Ruta) Sesion.get(Sesion.Campo.RutaActual)).RUTClave;
                vis.Numero = Consultas.ConsultasVisita.obtenerConsecutivo((Dia) Sesion.get(Sesion.Campo.DiaActual));
                vis.FechaHoraInicial = Generales.getFechaHoraActual();
                vis.FechaHoraFinal =  Generales.sumarAFecha(Generales.getFechaHoraActual(), Calendar.MINUTE, 1);
                vis.TipoEstado = 1; // activo
                vis.FueraFrecuencia = false;
                vis.CodigoLeido = 0;
                vis.GPSLeido = false;
                vis.DistanciaGPS = 0;
                vis.Enviado = false;
                vis.MFechaHora = Generales.getFechaHoraActual();
                vis.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;

                VisitaHist vih = new VisitaHist();
                vih.VisitaHistId = KeyGen.getId();
                vih.VisitaClave = vis.VisitaClave;
                vih.FechaHoraInicial = Generales.getFechaHoraActual();
                vih.FechaHoraFinal = Generales.sumarAFecha(Generales.getFechaHoraActual(), Calendar.MINUTE, 1);
                vih.MFechaHora = Generales.getFechaHoraActual();
                vih.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                vih.Enviado = false;
                BDVend.guardarInsertar(vis);
            }
            return vis;
        }catch (NullPointerException e) {
            throw new Exception("Error de null al generar visita");
        }catch(Exception ex){
            throw new Exception("Error generar visita: " + ex.getMessage());
        }
    }
    public boolean validarImportePago(float importe)
    {
        if (importe <= 0)
        {
            mVista.mostrarError(Mensajes.get("E0041"));
            return false;
        }
        return true;
    }

    public boolean validarBancoPago(int tipoBanco)
    {
        if (tipoBanco == 0)
        {
            mVista.mostrarError(Mensajes.get("I0245"));
            return false;
        }
        return true;
    }
    public void generarCobranza() throws Exception
    {
        vis = generarVisita();

        Sesion.set(Sesion.Campo.VisitaActual, vis);
        oAbono = Cobranza.generarCobranza();

        oAbono.ABNId = KeyGen.getId();
        oAbono.Folio = Folio;
        oAbono.SubEmpresaId=transProd.SubEmpresaId;
        String valoresPago = "";
        String valoresBanco = "";

        obtenerFormasPagoConfiguradas(valoresPago, valoresBanco);

        //mVista.capturarCobranzaDet(tiposCP);
        mVista.setFormasPago(obtenerValores(valoresPago,"PAGO", "CP"));
        mVista.setMonedas(obtenerMonedas());
        mVista.setBancos(obtenerValores(valoresPago,"TBANCO", null));
        mVista.setFecha(oAbono.FechaAbono);
        mVista.setFolio(Folio);
        mVista.setSaldoIni(saldoInicial);
        mVista.setSaldoFin(saldoInicial);

    }

    private void obtenerFormasPagoConfiguradas(String valoresPago, String valoresBanco) throws Exception {
        try {
            valoresPago = "";
            valoresBanco = "";
            ISetDatos formaPago = Consultas.ConsultasClientePago.obtenerFormasPago(vis.ClienteClave);
            if (formaPago.getCount() > 0) { // si tiene formas de pago configuradas, cargar solo esas, Quitar los valores de Cheque Posfechado porq no esta la funcionalidad
                while (formaPago.moveToNext()) {
                    if (!formaPago.getString("Tipo").equals("0") && !ValoresReferencia.getValor("PAGO", formaPago.getString("Tipo")).getGrupo().equals("CP")) {
                        valoresPago += formaPago.getString("Tipo") + ",";
                        if (formaPago.getString("TipoBanco") != null)
                            valoresBanco += formaPago.getString("TipoBanco") + ",";
                    }
                }

                if (valoresPago.length() > 1)
                    valoresPago = valoresPago.substring(0, valoresPago.length() - 1);

                if (valoresBanco.length() > 1)
                    valoresBanco = valoresBanco.substring(0, valoresBanco.length() - 1);
            }

            formaPago.close();
        }catch (NullPointerException e){
            throw new Exception("Error de null al obtener Formas de Pago");
        }catch (Exception ex){

            throw new Exception("Obtener formas de Pago : " + ex.getMessage());
        }

    }

    private LinkedList<Cobranza.VistaSpinner> obtenerValores(String valoresCliente, String varCodigo, String gruposExcepcion) throws Exception
    {
        LinkedList<Cobranza.VistaSpinner> valores = new LinkedList<Cobranza.VistaSpinner>();

        ValorReferencia[] var;
        if (valoresCliente.length()<=0){
            //Obtener todos los valores excepto
            if (gruposExcepcion == null || gruposExcepcion.length()<=0 ){
                var = ValoresReferencia.getValores(varCodigo);
            }else{
                var = ValoresReferencia.getValores(varCodigo, null,gruposExcepcion);
            }
        }else{
            String[] varCliente = valoresCliente.split(",");
            ArrayList<ValorReferencia> lista = new ArrayList<ValorReferencia>();
            for (String v:varCliente){
                lista.add(ValoresReferencia.getValor(varCodigo, v));
            }
            var = lista.toArray(new ValorReferencia[lista.size()]);
        }
        SortedMap<Integer, ValorReferencia> sm = new TreeMap<Integer,ValorReferencia>();
        if (var != null && var.length >0) {
            for (ValorReferencia v: var) {
                    sm.put(Integer.valueOf(v.getVavclave()), v);
            }
            for (ValorReferencia v: sm.values()){
                valores.add(new Cobranza.VistaSpinner(v.getVavclave() , v.getDescripcion()));
            }

        }

        return valores;
    }

    private LinkedList<Cobranza.VistaSpinner> obtenerMonedas() throws Exception
    {
        ISetDatos dsMonedas = Consultas.ConsultasMoneda.obtenerMonedas();
        LinkedList<Cobranza.VistaSpinner> monedas = new LinkedList<Cobranza.VistaSpinner>();
        String sNombre = "";
        if (dsMonedas.getCount() > 0)
        {
            while (dsMonedas.moveToNext())
            {
                sNombre = dsMonedas.getString("Nombre") + " " + ValoresReferencia.getValor("CDGOMON", dsMonedas.getString("TipoCodigo")).getDescripcion();
                monedas.add(new Cobranza.VistaSpinner(dsMonedas.getString("_id"), sNombre));
            }
        }

        dsMonedas.close();
        return monedas;
    }

    public void imprimirTicket() throws Exception
    {
        Map<String, String> documento;
        List<Map<String, String>> documentos;

        Recibos recibos = new Recibos();
        documentos = new ArrayList<Map<String, String>>();

        documento = recibos.getDocumentoImpresion(oAbono.ABNId, String.valueOf(10), "TRECIBO", "ABN", oAbono.Folio, "", Generales.getFormatoFecha(oAbono.FechaAbono, "dd/MM/yyyy"), Generales.getFormatoDecimal(oAbono.Total, "$#,##0.00"), "0", transProd.ClienteClave, oAbono.DiaClave, "", "0");
        // Abono.ABNId as _Id, 10 as Tipo, 'TRECIBO' as VARCodigo, 'ABN' as
        // TipoRecibo, Abono.Folio as Folio ,'' as DescTipo, strftime(
        // '%d/%m/%Y',FechaAbono) as Fecha, Abono.Total as Total, null as
        // TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as
        // DiaClave, '' as SubEmpresaID , 0 as FacElec
        documentos.add(documento);

        short numImpresiones = 0;
       /* try {
            if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
                numImpresiones = Short.parseShort (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).toString());
            }
        }catch (Exception ex){
            mVista.mostrarError("Error al recuperar el parámetro NumImpresiones");
            numImpresiones = 0;
        }*/

        recibos.imprimirRecibos(documentos, false, mVista, numImpresiones);
    }
}
