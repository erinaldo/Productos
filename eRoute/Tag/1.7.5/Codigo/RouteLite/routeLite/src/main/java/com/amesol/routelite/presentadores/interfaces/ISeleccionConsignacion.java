package com.amesol.routelite.presentadores.interfaces;

import java.util.List;

import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.presentadores.act.SeleccionarConsignacion;

public interface ISeleccionConsignacion extends IVista
{

	public SeleccionarConsignacion.VistaConsignacion[] obtenerConsignaciones(Cliente clienteActual); 
	
	public void actualizaListado(SeleccionarConsignacion.VistaConsignacion[] listadoConsignas);
	
	public void actualizaSaldoTotal(SeleccionarConsignacion.VistaConsignacion[] listadoConsignas);
	
	public void ejecutaAccionMenuContext(int idAccion);
	
	public void ejecutaModificacionLiquidacion();
}
