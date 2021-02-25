package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;

public interface ISeleccionPedido extends IVista
{

	void mostrarVentasCliente(SeleccionarPedido.VistaPedidos[] pedidos);

	SeleccionarPedido.VistaPedidos[] obtenerPedidos();

	String getDescripcionFase(int TipoFase);

	public void mostrarMensajeEiniciarActividad(String mensaje, Class<?> actividad);

	public void actualizarVista();

    public String getsTransProdIdSeleccionado();
}
