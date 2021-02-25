package com.amesol.routelite.datos;

import java.util.ArrayList;
import java.util.Date;
import java.util.Hashtable;
import java.util.List;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class Promocion extends Entidad {

	@Llave()
	public String PromocionClave;
	
	@Campo
	public String Nombre;
	
	@Campo
	public short Tipo;
	
	@Campo
	public short TipoAplicacion;
	
	@Campo
	public Date FechaInicial;
	
	@Campo
	public Date FechaFinal;
	
	@Campo
	public boolean PermiteCascada;
	
	@Campo
	public short TipoRango;
	
	@Campo
	public short TipoRegla;

	@Campo
	public boolean Obligatoria;
	
	@Campo
	public boolean SeleccionProducto;
	
	@Campo
	public boolean CapturaCantidad;

	@Campo
	public short TipoEstado;
	
	@Campo
	public boolean PendienteEntrega;

    @Campo
    public boolean InventarioPromocion;

    @Campo
    public boolean NoDisminuirProducto;

    @Campo
    public boolean ValidaMultiplesEsquemas;

    @Campo
    public boolean ValidaEsquemasProducto;

	@Campo
	public boolean AplicaReglaPorProducto;

	@Campo
	public boolean OtorgaSoloMismoProducto;

	public float CantidadAcumulado;
	
	public float ImporteAcumulado;
		
	public String PromocionReglaIdApp;
	
	public int CantidadGrupoApp;
	
	public float RestoAcumulado;
	
	public float PuntosAcumulado;
	
	public boolean PrimeraVez;

	public boolean MostrarPregunta;

    public boolean AplicarKit;

    public int CantidadKit;

    public int AcumuladoKit;

	public int ProductosConCantidadkit;

	public Hashtable<String, Integer> ProductosKit;

    public Hashtable<String, Float> ProductosExcepProntoPago;
	
	//Bandera que se usa para indicar si una promocion de acumulado se acepto para aplicarse o no
	public boolean SeAcepto;
	
	//String que guarda los productos del pedido que aplican a la promocion Acumulado.
	public String ListadoProductosAcumulados;
	
	@Hijos(tablaHijos=PromocionRegla.class)
	public List<PromocionRegla> PromocionRegla;
	
	@Hijos(tablaHijos=PromocionProducto.class)
	public List<PromocionProducto> PromocionProducto;
	
	@Hijos(tablaHijos=PromocionDetalle.class)
	public List<PromocionDetalle> PromocionDetalle;
	
	@Hijos(tablaHijos=PromocionModulo.class)
	public List<PromocionModulo> PromocionModulo;
	
	public Promocion(){		
		PromocionRegla = new ArrayList<PromocionRegla>();
		PromocionProducto = new ArrayList<PromocionProducto>();
		PromocionDetalle = new ArrayList<PromocionDetalle>();
		PromocionModulo = new ArrayList<PromocionModulo>();
		CantidadAcumulado = 0;
		ImporteAcumulado = 0;
		PromocionReglaIdApp = "";
		CantidadGrupoApp = 0;
		RestoAcumulado = 0;
		PuntosAcumulado = 0;
		PrimeraVez = true;
		SeAcepto = false;
		MostrarPregunta = true;
		ListadoProductosAcumulados = "";
	}
	
	
	public String ProductoClave;
	public String ProductoNombre;
	public float Precio;
}
