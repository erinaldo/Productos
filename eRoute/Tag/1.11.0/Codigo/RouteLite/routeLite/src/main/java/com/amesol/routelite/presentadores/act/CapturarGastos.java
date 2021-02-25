package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Gasto;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaGastos;
import com.amesol.routelite.utilerias.Generales;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;

/**
 * Created by ldelatorre on 30/05/2017.
 */
public class CapturarGastos extends Presentador {
    private ICapturaGastos mVista;

    public CapturarGastos(ICapturaGastos mVista) {
        this.mVista = mVista;
    }

    @Override
    public void iniciar() {

    }

    public String validarGastos(String fecha, int concepto, String folio, int formasPago, float importe, float impuesto, float impuestoTotal, float total){

        if(fecha.equals("") || fecha.isEmpty()){
            return Mensajes.get("XFecha");
        }

        if(concepto <= 0){
            return Mensajes.get("XConcepto");
        }

        if(folio.equals("") || folio.isEmpty()){
            return Mensajes.get("XFolio");
        }

        if(formasPago <= 0){
            return Mensajes.get("XFormaPago");
        }

        if(importe == 0){
            return Mensajes.get("XImporte");
        }

        if(impuesto == 0){
            return Mensajes.get("XImpuesto");
        }

        if(impuestoTotal == 0){
            return Mensajes.get("XImpuesto");
        }

        if(total == 0){
            return Mensajes.get("XTotal");
        }

        return "";
    }

    public void guardarGastos(Date fecha, String vendedorID, String diaClave, int concepto, String folio, int formasPago, String comentarios, float importe, float impuesto, float impuestoTotal, float total)throws Exception{

        Gasto nuevoGasto = new Gasto();

        nuevoGasto.fecha = obtenerFecha(fecha);
        nuevoGasto.vendedorID = vendedorID;
        nuevoGasto.diaClave = diaClave;
        nuevoGasto.tipoConcepto = concepto;
        nuevoGasto.formaPago = formasPago;
        nuevoGasto.folio = folio;
        nuevoGasto.total = total;
        nuevoGasto.comentario = comentarios;
        nuevoGasto.porcentaje = impuesto;
        nuevoGasto.importe = importe;
        nuevoGasto.impuesto = impuestoTotal;
        nuevoGasto.MFechaHora = Generales.getFechaHoraActual();
        nuevoGasto.MUsuarioId = vendedorID;
        BDVend.guardarInsertar(nuevoGasto);
        BDVend.commit();

        mVista.guardadoExito();

    }

    public void modificarGastos(Date fecha, String vendedorID, String diaClave, int concepto, String folio, int formasPago, String comentarios, float importe, float impuesto, float impuestoTotal, float total)throws Exception{
        Gasto nuevoGasto = new Gasto();
        nuevoGasto.fecha = fecha;
        BDVend.recuperar(nuevoGasto);

        if(nuevoGasto.isRecuperado())
        {
            nuevoGasto.vendedorID = vendedorID;
            nuevoGasto.diaClave = diaClave;
            nuevoGasto.tipoConcepto = concepto;
            nuevoGasto.formaPago = formasPago;
            nuevoGasto.folio = folio;
            nuevoGasto.total = total;
            nuevoGasto.comentario = comentarios;
            nuevoGasto.porcentaje = impuesto;
            nuevoGasto.importe = importe;
            nuevoGasto.impuesto = impuestoTotal;
            nuevoGasto.MFechaHora = Generales.getFechaHoraActual();
            nuevoGasto.MUsuarioId = vendedorID;
            BDVend.guardarInsertar(nuevoGasto);
            BDVend.commit();
        } else {
            mVista.mostrarError("No se encontro el registro");
        }

        mVista.guardadoExito();
    }

    public Date obtenerFecha(Date fecha){

        SimpleDateFormat sdf = new SimpleDateFormat("HH:mm:ss");
        String currentDateTimeString = sdf.format(new Date());
        String[] horas = currentDateTimeString.split(":");
        int hora = Integer.parseInt(horas[0]);
        int minutos = Integer.parseInt(horas[1]);
        int segundos = Integer.parseInt(horas[2]);
        Calendar calendar = Calendar.getInstance();
        calendar.setTime(fecha);
        calendar.add(Calendar.HOUR, hora);
        calendar.add(Calendar.MINUTE, minutos);
        calendar.add(Calendar.SECOND, segundos);

        return calendar.getTime();
    }

    public void llenarCampos(Date fecha){
        try {

            ISetDatos datos = Consultas2.ConsultarGastos.buscarGasto(fecha);

            SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
            String strFecha = "";

            if(datos.moveToNext()){
                strFecha = format.format(datos.getDate("Fecha"));
                mVista.llenarCampos(strFecha, datos.getInt("TipoConcepto"), datos.getString("Folio"), datos.getInt("FormaPago"),datos.getString("Comentario"),datos.getDouble("Importe"), datos.getDouble("Porcentaje"),datos.getDouble("Impuesto"),datos.getDouble("Total"));
            }

        } catch (Exception e) {
            mVista.mostrarError(e.getMessage());
        }

    }
}
