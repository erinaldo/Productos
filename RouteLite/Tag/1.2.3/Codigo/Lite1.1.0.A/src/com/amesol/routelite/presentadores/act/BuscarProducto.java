package com.amesol.routelite.presentadores.act;


import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IBuscaProducto;

public class BuscarProducto extends Presentador {

	IBuscaProducto mVista;
	String mAccion;
	//HashMap<String, Object> oParametros;
	
	public BuscarProducto(IBuscaProducto vista, String accion){
		mVista = vista;
		mAccion = accion;
		//oParametros = new HashMap<String, Object>();
	}
	
	@Override
	public void iniciar() {
		try {
			mVista.iniciar();
			if(mVista.obtenerProductos() != null){
				mVista.mostrarProductos(mVista.obtenerProductos());
			}
		} catch (Exception e) {
			mVista.mostrarError(e.getMessage());
		}
	}
	
	public boolean validarCantMax(float cantidad, int tipoTransProd){
		MOTConfiguracion oMot = ((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion));
		if(Integer.parseInt(oMot.get("CantidadMaxProd").toString()) > 0 && tipoTransProd == 1){ //solo se valida para los pedidos
			if(cantidad > Integer.parseInt(oMot.get("CantidadMaxProd").toString())){
				mVista.mostrarPreguntaSiNo(Mensajes.get("P0245").replace("$0$", oMot.get("CantidadMaxProd").toString()), 30);
				return true;
			}
		}
		return false;
	}

/*	public void setParametros(	HashMap<String, Object> parametros)
	{
		oParametros=parametros;
	}
*/
}
