package com.amesol.routelite.presentadores.act;

import java.util.ArrayList;
import java.util.LinkedList;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IElementoCobranzaDet;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.ElementoCobranzaDet;

public class CapturarDetalleCobranza extends Presentador {

	float saldoInicial;
	float saldoResto;
    float saldoInicialDesc;
    float saldoRestoDesc;
    boolean aplicarDescProntoPago;
	IElementoCobranzaDet mVista;
	//Se cambia el nombre porque se usaba el CP para otros grupos
	ArrayList<Integer> tiposPagoConFecha;
	LinkedList<Cobranza.VistaSpinner> pagos;
	LinkedList<Cobranza.VistaSpinner> monedas;
	LinkedList<Cobranza.VistaSpinner> bancos;
	
	public CapturarDetalleCobranza(ElementoCobranzaDet elementoCobranzaDet){
		mVista = elementoCobranzaDet;
	}	
	
	@Override
	public void iniciar() {	
		obtenerDatos();
		mVista.setTiposPagoConFecha(tiposPagoConFecha);
		mVista.setSaldoIni(saldoInicial);
		mVista.setSaldoFin(saldoResto);
        if (aplicarDescProntoPago) {
            mVista.mostrarDescuento();
            mVista.setSaldoDescIni(saldoInicialDesc);
            mVista.setSaldoDescFin(saldoRestoDesc);
        }
		mVista.poblarFormaPago(pagos);
		mVista.poblarMoneda(monedas);
		mVista.poblarBanco(bancos);
		//mVista.setImporte(0);
		
	}
	
	public void setSaldoInicial(float saldoInicial){
		this.saldoInicial = saldoInicial;
	}
	
	public void setSaldoResto(float saldoResto){
		this.saldoResto = saldoResto;
	}

    public void setAplicarDescProntoPago(boolean aplicarDescProntoPago){
        this.aplicarDescProntoPago = aplicarDescProntoPago;
    }
    public void setSaldoInicialDesc(float saldoInicialDesc){
        this.saldoInicialDesc = saldoInicialDesc;
    }

    public void setSaldoRestoDesc(float saldoRestoDesc){
        this.saldoRestoDesc = saldoRestoDesc;
    }
		
	private void obtenerDatos(){
		try{
			tiposPagoConFecha = new ArrayList<Integer>();
			ValorReferencia[] valoresPagoConFecha = ValoresReferencia.getValores("PAGO", "CP");
			for (int i = 0; i<valoresPagoConFecha.length; i++)
				tiposPagoConFecha.add(Integer.parseInt(valoresPagoConFecha[i].getVavclave()));

			valoresPagoConFecha = ValoresReferencia.getValores("PAGO","TR");
			for (int i = 0; i<valoresPagoConFecha.length; i++)
				tiposPagoConFecha.add(Integer.parseInt(valoresPagoConFecha[i].getVavclave()));

			valoresPagoConFecha = ValoresReferencia.getValores("PAGO","FP");
			for (int i = 0; i<valoresPagoConFecha.length; i++)
				tiposPagoConFecha.add(Integer.parseInt(valoresPagoConFecha[i].getVavclave()));

			String tiposExcep ="0";
			ValorReferencia[] valoresNC = ValoresReferencia.getValores("PAGO", "NC");
			for (int i = 0; i<valoresNC.length; i++)
				tiposExcep += "," + valoresNC[i].getVavclave();
			
			String valoresPago = "";
			String valoresBanco = "";
			
			obtenerFormasPagoConfiguradas(valoresPago, valoresBanco);
					
			ISetDatos valores;
			if (valoresPago.length() > 0)
				valores = Consultas.ConsultasValorReferencia.obtenerValores("PAGO", valoresPago);
			else
				valores = Consultas.ConsultasValorReferencia.obtenerValoresExcepcion("PAGO", tiposExcep);
			
			pagos = obtenerValores(valores);
			valores.close();
			
			monedas = obtenerMonedas();		
			
			if (valoresBanco.length() > 0)
				valores = Consultas.ConsultasValorReferencia.obtenerValores("TBANCO", valoresBanco);
			else
				valores = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TBANCO");
			
			bancos = obtenerValores(valores);		
			valores.close();
		} catch (Exception e) {
			mVista.mostrarError(e.getMessage());
		}
	}
	
	private void obtenerFormasPagoConfiguradas(String valoresPago, String valoresBanco) throws Exception{
		valoresPago = "";
		valoresBanco = "";
		ISetDatos formaPago = Consultas.ConsultasClientePago.obtenerFormasPago(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave);
		if(formaPago.getCount() > 0){ //si tiene formas de pago configuradas, cargar solo esas
			while(formaPago.moveToNext()){
				if (!formaPago.getString("Tipo").equals("0")){
					valoresPago += formaPago.getString("Tipo") + ",";
					if (formaPago.getString("TipoBanco") != null)
						valoresBanco += formaPago.getString("TipoBanco") + ",";
				}
			}
			
			if(valoresPago.length() > 1)
				valoresPago = valoresPago.substring(0, valoresPago.length() - 1);
			
			if(valoresBanco.length() > 1)
				valoresBanco = valoresBanco.substring(0, valoresBanco.length() - 1);			
		}
		
		formaPago.close();
	}
	
	private LinkedList<Cobranza.VistaSpinner> obtenerMonedas() throws Exception{
		ISetDatos dsMonedas = Consultas.ConsultasMoneda.obtenerMonedas();
		LinkedList<Cobranza.VistaSpinner> monedas = new LinkedList<Cobranza.VistaSpinner>();
		String sNombre = "";
		String sCodigo = "";
		
		if(dsMonedas.getCount() > 0){
			while(dsMonedas.moveToNext()){
				sCodigo = Consultas.ConsultasValorReferencia.obtenerDescripcion("CDGOMON", dsMonedas.getString("TipoCodigo"));
				sNombre = dsMonedas.getString("Nombre") + " " + sCodigo;
				monedas.add(new Cobranza.VistaSpinner(dsMonedas.getString("_id"), sNombre));
			}
		}
			
		dsMonedas.close();
		return monedas;
	}
	
	private LinkedList<Cobranza.VistaSpinner> obtenerValores(ISetDatos dsValores) throws Exception{
		LinkedList<Cobranza.VistaSpinner> valores = new LinkedList<Cobranza.VistaSpinner>();
		String sNombre = "";
		String sCodigo = "";
		
		if(dsValores.getCount() > 0){
			while(dsValores.moveToNext()){							
				valores.add(new Cobranza.VistaSpinner(dsValores.getString("_id"), dsValores.getString("Descripcion")));
			}
		}		
		
		return valores;
	}
	
	public void validarDetalle() throws Exception{
		int tipoPago = mVista.getTipoPago();
		float importe = mVista.getImporte();
		//String monedaId = mVistaDet.getMonedaId();
		int tipoBanco = mVista.getTipoBanco();
		//String referencia = mVistaDet.getReferencia();
		//Date fechaCheque = mVistaDet.getFechaCheque();		
		
		if (importe <= 0)
			throw new Exception(Mensajes.get("I0246"));
		
		if (tipoPago != 1 && tipoBanco == 0)
			throw new Exception(Mensajes.get("I0245"));	
	}

}
