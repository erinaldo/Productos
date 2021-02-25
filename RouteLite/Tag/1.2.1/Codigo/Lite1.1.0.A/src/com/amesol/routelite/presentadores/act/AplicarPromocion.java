package com.amesol.routelite.presentadores.act;

import java.util.HashMap;

import android.os.Handler;

import com.amesol.routelite.actividades.Promociones;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IAplicacionPromocion;

public class AplicarPromocion extends Presentador{

	IAplicacionPromocion mVista;
	String mAccion;
	HashMap<String, Object> oParametros;
	Promociones promociones;
	AplicarPromocion mPresenta;
	TransProd oTrp;
	final Handler h = new Handler();

	
	
	public AplicarPromocion(IAplicacionPromocion vista, String accion){
		mVista = vista;
		mAccion = accion;
		oParametros = new HashMap<String, Object>();
	}
	
	@Override
	public void iniciar() {
		
		mPresenta = this;

		try{
			Cliente oClienteAct = (Cliente) Sesion.get(Campo.ClienteActual);
			
			if (Sesion.get(Campo.ArrayTransProd) != null){
				oTrp = ((HashMap<String, TransProd>)Sesion.get(Campo.ArrayTransProd)).get(oParametros.get("SubEmpresaID"));
			    promociones = (Promociones)oParametros.get("ActPromociones");
				mVista.setFolioRazonSocial(oClienteAct, oTrp);
			}else{
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL);
				mVista.finalizar();
			}
			/*
			//oTRP.TransProdID = oParametros.get("TransProdID");{ set
			//precioClave = oParametros.get("PrecioClave"); 
				
			if(Sesion.get(Campo.ModuloMovDetalleClave) == null){
				//Sesion.set
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL);
				mVista.finalizar();
			}
			
			try {
				BDVend.recuperar(oTRP, TransProdDetalle.class);
			} catch (Exception e) {
				e.printStackTrace();
			}
			
			//pasarle la presentadora a la clase de promociones para tener acceso a los metodos para mostrar la pregunta
			promociones = new Promociones(oTRP);
			
			if (promociones.Preparar()){			
				try {
					BDVend.recuperar(oTRP);
					BDVend.recuperar(oTRP, TransProdDetalle.class);
					//obtener todos los impuestos para que se recalculen correctamente
					for(TransProdDetalle oTpd : oTRP.TransProdDetalle){
						BDVend.recuperar(oTpd, TPDImpuesto.class);
					}
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
			mVista.setDiaClave(oDia);
			
			promociones.Aplicar();
			
			if(promociones.getPromocionesAplicadas().size() <= 0){ //si no hay promociones que aplicar pasar a la siguiente actividad
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				mVista.finalizar();
				return;
			}*/
			
			mVista.mostrarProductosPromocion();
			
			//marcar el transprod
			//oTRP.Promocion = true;
			//BDVend.guardarInsertar(oTRP);
			
		}catch(Exception ex){
			mVista.mostrarError(ex.getMessage());
		}
					
	}
	
	public void setParametros(	HashMap<String, Object> parametros)
	{
		oParametros=parametros;
	}

	public Promociones getPromociones(){
		return promociones;
	}
	
	public TransProd getTransProd(){
		return oTrp;		
	}
	/*public void mostrarOpcional(final String Mensaje){
		mVista.mostrarPreguntaOpcional(Mensaje);
	}*/
	
	/*public boolean getAplicarPromocion(){
		return mVista.getAplicarPromo();
	}
	
	public void setAplicarPromocion(boolean baplicar){
		mVista.setAplicarPromo(baplicar);
	}*/
	
	/*public Object getPausaCiclo(){
		return mVista.getmPausa();
	}*/
	
	/*public void setPausaCiclo(Object pausa){
		mVista.setmPausa(pausa);
	}*/
	
	/*public boolean getContinuar(){
		return mVista.getContinuar();
	}*/
	
	/*public void setContinuar(boolean bcontinuar){
		mVista.setContinuar(bcontinuar);
	}*/
	
	/*public boolean getTerminar(){
		return mVista.getTerminar();
	}*/
	
	/*public void setTerminar(boolean terminar){
		mVista.setTerminar(terminar);
	}*/
	
	/*public Thread getThreadPregunta(){
		return mVista.getPregunta();
	}*/
	
	/*public void setThreadPregunta(Thread pregunta){
		mVista.setPregunta(pregunta);
	}*/
	
	/*public Runnable getRunnablePregunta(){
		return mVista.getHiloPausa();
	}*/
	
	/*public void setRunnablePregunta(Runnable pregunta){
		mVista.setHiloPausa(pregunta);
	}*/
	
}
