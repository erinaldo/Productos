package com.amesol.routelite.datos;

import java.util.ArrayList;
import java.util.List;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class PromocionRegla extends Entidad {
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="PromocionClave", tablaPadre=Promocion.class)
	public String PromocionClave;
	
	@Llave()
	public String PromocionReglaID;
		
	@Campo
	@LlaveForanea( nombreCampoForaneo="PrecioClave", tablaPadre=Precio.class)
	public String PrecioClave;
	
	@Campo
	public float Minimo;
	
	@Campo
	public float Maximo;
	
	@Campo
	public float Porcentaje;
	
	@Campo
	public float Importe;
	
	@Campo
	public int Cantidad;

    @Campo
    public int AplicacionMinima;
	
	@Hijos(tablaHijos=PromocionAplicacion.class)
	public List<PromocionAplicacion> PromocionAplicacion;
	
	public PromocionRegla(){		
		PromocionAplicacion = new ArrayList<PromocionAplicacion>();
	}

}
