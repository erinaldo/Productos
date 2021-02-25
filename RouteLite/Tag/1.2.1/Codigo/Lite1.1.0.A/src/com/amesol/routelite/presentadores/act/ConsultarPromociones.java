package com.amesol.routelite.presentadores.act;

import android.database.Cursor;
import android.sax.StartElementListener;

import com.amesol.routelite.actividades.Esquemas;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.Promocion;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IConsultaPromociones;

public class ConsultarPromociones  extends Presentador {

	IConsultaPromociones mVista;
	
	String sPrecioClave;
	public ConsultarPromociones(IConsultaPromociones vista, String precioClave){
		this.mVista = vista;
		sPrecioClave= precioClave;
	}

	
	@Override
	public void iniciar() {
		// TODO Auto-generated method stub
		String sEsquemas = Esquemas.ObtenerEsquemas(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, 1);
	
		Producto[] aPro =  Consultas.ConsultasProducto.obtenerProductosConPromocion(sEsquemas,	 (String) Sesion.get(Campo.ModuloMovDetalleClave));
		Promocion[] aPromo = Consultas.ConsultasPromocion.obtenerProductosConPromocion(sEsquemas, sPrecioClave,  (String) Sesion.get(Campo.ModuloMovDetalleClave));
		
		ISetDatos Aplicaiones = Consultas.ConsultasPromocion.RecuperarPromocionAplicaciones();
		ISetDatos Reglas = Consultas.ConsultasPromocion.RecuperarPromocionReglas();
		mVista.manejarCursor((Cursor) Aplicaiones.getOriginal());
		mVista.manejarCursor((Cursor) Reglas.getOriginal());
			mVista.mostrarProductos(aPro,aPromo,Reglas,Aplicaiones);
	}
	
	

}
