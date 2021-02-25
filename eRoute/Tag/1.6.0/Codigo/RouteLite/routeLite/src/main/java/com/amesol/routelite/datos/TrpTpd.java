package com.amesol.routelite.datos;

import java.util.Comparator;
import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.utilerias.Generales;

@TablaDef(orden=10)
public class TrpTpd extends Entidad {
	@Llave
	public String TransProdID;
	
	@Llave
	public String TransProdID1;
	
	@Llave
	public String TransProdDetalleID;
	
	@Campo
	public float Cantidad;
	public float getCantidad() { return Cantidad; }
	
	@Campo
	public float Precio;
	public float getPrecio() { return Generales.getRound(Precio, Integer.parseInt(((CONHist)Sesion.get(Sesion.Campo.CONHist)).get("DecimalesImporte").toString())) ; }; 
	public void setPrecio(float precio) {Precio = Generales.getRound(precio, Integer.parseInt(((CONHist)Sesion.get(Sesion.Campo.CONHist)).get("DecimalesImporte").toString()));};
	
	@Campo
	public float Subtotal;
	public float getSubTotal() { return Generales.getRound(Subtotal, 2) ; }; 
	public void setSubTotal(float subTotal) {Subtotal = Generales.getRound(subTotal, 2);};

	@Campo
	public Float Impuesto;
	
	@Campo
	public float Total;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
	
	public static class comparator implements Comparator<TrpTpd>{
		@Override
		public int compare(TrpTpd arg0, TrpTpd arg1) {
			if(arg0.TransProdID != null && arg1.TransProdID != null)
				return arg0.TransProdID.compareToIgnoreCase(arg1.TransProdID);
			return 0;
		}
	}
	
}
