package com.amesol.routelite.datos;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.Date;
import java.util.List;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.utilerias.Generales;

@TablaDef(orden=9)
public class TransProdDetalle extends Entidad {
	@Llave
	@LlaveForanea(nombreCampoForaneo = "TransProdID", tablaPadre = TransProd.class)
	public String TransProdID;
	
	@Llave
	public String TransProdDetalleID;
	 
	@Campo
	public String ProductoClave;
	public String getProductoClave() { return ProductoClave; }
	
	
	@Campo
	public String DescuentoClave;
	 
	@Campo
	public String PRGId;
	
	@Campo
	public int TipoUnidad;
	
	@Campo
	public int Partida;
	
	@Campo
	public float Cantidad;
	public float getCantidad() { return Cantidad; }
	
	@Campo
	public Float CantidadOriginal;
	
	@Campo
	public float Precio;
	public float getPrecio() { return Generales.getRound(Precio, Integer.parseInt(((CONHist)Sesion.get(Sesion.Campo.CONHist)).get("DecimalesImporte").toString())) ; }; 
	public void setPrecio(float precio) {Precio = Generales.getRound(precio, Integer.parseInt(((CONHist)Sesion.get(Sesion.Campo.CONHist)).get("DecimalesImporte").toString()));};

	@Campo
	public Float PrecioBase;
	public Float getPrecioBase() { return Generales.getRound(PrecioBase, Integer.parseInt(((CONHist)Sesion.get(Sesion.Campo.CONHist)).get("DecimalesImporte").toString())) ; }; 
	public void setPrecioBase(Float precioBase) {PrecioBase = Generales.getRound(precioBase, Integer.parseInt(((CONHist)Sesion.get(Sesion.Campo.CONHist)).get("DecimalesImporte").toString()));};

	@Campo
	public Short TipoMotivo;
	
	@Campo
	public Float DescuentoPor;
	
	@Campo
	public Float DescuentoImp;
	
	@Campo
	public float Subtotal;
	public float getSubTotal() { return Generales.getRound(Subtotal, 2) ; }; 
	public void setSubTotal(float subTotal) {Subtotal = Generales.getRound(subTotal, 2);};

	@Campo
	public Float Impuesto;
	
	@Campo
	public float Total;
	
	@Campo
	public Integer Promocion;
	
	@Campo
	public String PromocionClave;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
	
	@Campo
	public Float PrestamoVendido;
	
	@Campo
	public float DesImporteT;
	
	@Campo
	public float DesImpuestoT;
	
	@Hijos(tablaHijos=TPDImpuesto.class)
	public List<TPDImpuesto> TPDImpuesto;
	
	@Hijos(tablaHijos=TrpPrp.class)
	public List<TrpPrp> TrpPrp;
	
	@Hijos(tablaHijos=TpdPun.class)
	public List<TpdPun> TpdPun;
	
	@Hijos(tablaHijos=TpdDes.class)
	public List<TpdDes> TpdDes;

    @Hijos(tablaHijos=TPDDatosExtra.class)
    public List<TPDDatosExtra> TPDDatosExtra;

	public TransProdDetalle(){
		TPDImpuesto = new ArrayList<TPDImpuesto>();
		TrpPrp = new ArrayList<TrpPrp>();
		TpdPun = new ArrayList<TpdPun>();		
		TpdDes = new ArrayList<TpdDes>();
        TPDDatosExtra = new ArrayList<TPDDatosExtra>();
	}	
	
	
	public Producto producto;
	public boolean recienAgregado;
	public boolean cantidadModificada;
	public boolean modificado;
	
	public static class comparator implements Comparator<TransProdDetalle>{
		@Override
		public int compare(TransProdDetalle arg0, TransProdDetalle arg1) {
			if(arg0.ProductoClave != null && arg1.ProductoClave != null)
				return arg0.ProductoClave.compareToIgnoreCase(arg1.ProductoClave);
			return 0;
		}
	}
	
}
