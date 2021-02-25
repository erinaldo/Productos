package com.amesol.routelite.actividades;

public class ModuloMovDetalle
{

	private String ModuloMovDetalleClave;
	private String ModuloClave;
	private String ModuloMovClave;
	private String Nombre;
	private int TipoIndice;
	private int Orden;
	private int TipoTransprod;
	private int TipoPedido;
	private int TipoMovimiento;
	private int TipoEstado;
	private int Baja;

	public ModuloMovDetalle(String modulomovdetalleclave, String moduloclave, String modulomovclave, String nombre, int tipoindice, int orden, int tipotransprod, int tipopedido, int tipomovimiento, int tipoestado, int baja)
	{
		this.setModuloMovDetalleClave(modulomovdetalleclave);
		this.setModuloClave(moduloclave);
		this.setModuloMovClave(modulomovclave);
		this.setNombre(nombre);
		this.setTipoIndice(tipoindice);
		this.setOrden(orden);
		this.setTipoTransprod(tipotransprod);
		this.setTipoPedido(tipopedido);
		this.setTipoMovimiento(tipomovimiento);
		this.setTipoEstado(tipoestado);
		this.setBaja(baja);
	}

	public ModuloMovDetalle(String modulomovdetalleclave, int tipoindice)
	{
		this.setModuloMovDetalleClave(modulomovdetalleclave);
		this.setTipoIndice(tipoindice);

	}

	public String getModuloMovDetalleClave()
	{
		return ModuloMovDetalleClave;
	}

	public void setModuloMovDetalleClave(String moduloMovDetalleClave)
	{
		ModuloMovDetalleClave = moduloMovDetalleClave;
	}

	public String getModuloClave()
	{
		return ModuloClave;
	}

	public void setModuloClave(String moduloClave)
	{
		ModuloClave = moduloClave;
	}

	public String getModuloMovClave()
	{
		return ModuloMovClave;
	}

	public void setModuloMovClave(String moduloMovClave)
	{
		ModuloMovClave = moduloMovClave;
	}

	public String getNombre()
	{
		return Nombre;
	}

	public void setNombre(String nombre)
	{
		Nombre = nombre;
	}

	public int getTipoIndice()
	{
		return TipoIndice;
	}

	public void setTipoIndice(int tipoIndice)
	{
		TipoIndice = tipoIndice;
	}

	public int getOrden()
	{
		return Orden;
	}

	public void setOrden(int orden)
	{
		Orden = orden;
	}

	public int getTipoTransprod()
	{
		return TipoTransprod;
	}

	public void setTipoTransprod(int tipoTransprod)
	{
		TipoTransprod = tipoTransprod;
	}

	public int getTipoPedido()
	{
		return TipoPedido;
	}

	public void setTipoPedido(int tipoPedido)
	{
		TipoPedido = tipoPedido;
	}

	public int getTipoMovimiento()
	{
		return TipoMovimiento;
	}

	public void setTipoMovimiento(int tipoMovimiento)
	{
		TipoMovimiento = tipoMovimiento;
	}

	public int getTipoEstado()
	{
		return TipoEstado;
	}

	public void setTipoEstado(int tipoEstado)
	{
		TipoEstado = tipoEstado;
	}

	public int getBaja()
	{
		return Baja;
	}

	public void setBaja(int baja)
	{
		Baja = baja;
	}

}
