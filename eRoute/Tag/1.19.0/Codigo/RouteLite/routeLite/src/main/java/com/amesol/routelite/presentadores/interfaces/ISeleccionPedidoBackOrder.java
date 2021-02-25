package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.presentadores.act.SeleccionarPedidoBackOrder;

public interface ISeleccionPedidoBackOrder extends IVista
{
	void mostrarPedidosBOCliente(SeleccionarPedidoBackOrder.VistaPedidos[] pedidos);
	SeleccionarPedidoBackOrder.VistaPedidos[] obtenerPedidos();
	String getDescripcionFase(int TipoFase);
//	public void mostrarMensajeEiniciarActividad(String mensaje, Class<?> actividad);
	public void actualizarVista();
	public String getsTransProdIdSeleccionado();
//	public void mostrarDialogoFactura();
}
