package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class Producto extends Entidad {

	public String getProductoClave() {
		return ProductoClave;
	}

	public void setProductoClave(String productoClave) {
		ProductoClave = productoClave;
	}

	public String getNombre() {
		return Nombre;
	}

	public void setNombre(String nombre) {
		Nombre = nombre;
	}

	public String getNombreLargo() {
		return NombreLargo;
	}

	public void setNombreLargo(String nombreLargo) {
		NombreLargo = nombreLargo;
	}

	public String getId() {
		return Id;
	}

	public void setId(String id) {
		Id = id;
	}

	public short getTipo() {
		return Tipo;
	}

	public void setTipo(short tipo) {
		Tipo = tipo;
	}

	public String getSubEmpresaId() {
		return SubEmpresaId;
	}

	public void setSubEmpresaId(String subEmpresaId) {
		SubEmpresaId = subEmpresaId;
	}

	public float getLimiteDescuento() {
		return LimiteDescuento;
	}

	public void setLimiteDescuento(float limiteDescuento) {
		LimiteDescuento = limiteDescuento;
	}

	public short getTipoFase() {
		return TipoFase;
	}

	public void setTipoFase(short tipoFase) {
		TipoFase = tipoFase;
	}

	public boolean isContenido() {
		return Contenido;
	}

	public void setContenido(boolean contenido) {
		Contenido = contenido;
	}

	public boolean isVenta() {
		return Venta;
	}

	public void setVenta(boolean venta) {
		Venta = venta;
	}

	public short getDecimalProducto() {
		return DecimalProducto;
	}

	public void setDecimalProducto(short decimalProducto) {
		DecimalProducto = decimalProducto;
	}

    public float getCantidadProduccion() {
        return CantidadProduccion;
    }

    public void setCantidadProduccion(short cantidadProduccion) {
        CantidadProduccion = cantidadProduccion;
    }

	@Llave()
	public String ProductoClave;
	
	@Campo
	public String Nombre;
	
	@Campo
	public String NombreLargo;
	
	@Campo
	public String Id;
	
	@Campo
	public short Tipo;
	
	@Campo
	public String SubEmpresaId;
	
	@Campo
	public float LimiteDescuento;
	
	@Campo
	public short TipoFase;
	
	@Campo
	public boolean Contenido;
	
	@Campo
	public boolean Venta;
	
	@Campo
	public short DecimalProducto;

	@Campo
    public float CantidadProduccion;

    @Campo
    public String FamiliaProducto;
}
