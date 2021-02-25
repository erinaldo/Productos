package com.amesol.routelite.actividades;

public class PromocionDetalle {

	String PromocionClave;
	String ProductoClave;
	String Nombre;
	int PRUTipoUnidad;
	String Unidad;
	float Cantidad;
	boolean SeleccionProducto;
	boolean SeleccionCantidad;
	int DecimalProducto;
    boolean PendienteEntrega;
	int Factor;
    float Precio;
    String PrecioClave;
	String Lote;
	String Caducidad;
	
	boolean Checked = false;
	
	public PromocionDetalle(String promocionClave, String productoClave, String nombre, int tipoUnidad, String unidad, float cantidad, boolean seleccion, boolean captura, int decimalProducto, int factor, boolean pendienteEntrega, String lote, String caducidad, float precio){
		PromocionClave = promocionClave;
		ProductoClave = productoClave;
		Nombre = nombre;
		PRUTipoUnidad = tipoUnidad;
		Unidad = unidad;
		Cantidad = cantidad;
		SeleccionProducto = seleccion;
		SeleccionCantidad = captura;
		DecimalProducto = decimalProducto;
        PendienteEntrega = pendienteEntrega;
		Factor = factor;
		Lote = lote;
		Caducidad = caducidad;
		Precio = precio;
	}

	public boolean isChecked() {
		return Checked;
	}

	public void setChecked(boolean checked) {
		Checked = checked;
	}

	public boolean isSeleccionProducto() {
		return SeleccionProducto;
	}

	public void setSeleccionProducto(boolean seleccionProducto) {
		SeleccionProducto = seleccionProducto;
	}

	public boolean isSeleccionCantidad() {
		return SeleccionCantidad;
	}

    public boolean isPendienteEntrega() {
        return PendienteEntrega;
    }

	public void setSeleccionCantidad(boolean seleccionCantidad) {
		SeleccionCantidad = seleccionCantidad;
	}

	public String getPromocionClave() {
		return PromocionClave;
	}

	public void setPromocionClave(String promocionClave) {
		PromocionClave = promocionClave;
	}

	public String getProducto() {
		return ProductoClave + " " + Nombre;
	}
	
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

	public int getPRUTipoUnidad() {
		return PRUTipoUnidad;
	}

	public void setPRUTipoUnidad(int pRUTipoUnidad) {
		PRUTipoUnidad = pRUTipoUnidad;
	}
	
	public String getUnidad() {
		return Unidad;
	}

	public void setUnidad(String unidad) {
		Unidad = unidad;
	}

	public float getCantidad() {
		return Cantidad;
	}

	public void setCantidad(float cantidad) {
		Cantidad = cantidad;
	}
	
	public int getDecimalProducto() {
		return DecimalProducto;
	}

	public void setDecimalProducto(int decimalProducto) {
		DecimalProducto = decimalProducto;
	}
	
	public int getFactor() {
		return Factor;
	}

	public void setFactor(int factor) {
		Factor= factor;
	}

    public void setPrecio(float precio) {
        Precio= precio;
    }
    public float getPrecio(){
        return  Precio;
    }

    public void setPrecioClave(String precioClave) {
        PrecioClave= precioClave;
    }
    public String getPrecioClave(){
        return  PrecioClave;
    }

	public void setLote(String lote){Lote = lote;}
	public String getLote(){return Lote;}

	public void setCaducidad(String caducidad){Caducidad = caducidad;}
	public String getCaducidad(){return Caducidad;}

}
