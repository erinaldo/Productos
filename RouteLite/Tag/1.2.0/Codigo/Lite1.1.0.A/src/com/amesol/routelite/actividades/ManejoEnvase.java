package com.amesol.routelite.actividades;

import com.amesol.routelite.datos.ProductoPrestamoCli;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.utilerias.Generales;

public class ManejoEnvase
{
	public static ProductoPrestamoCli crearPrestamo(String ClienteClave, String ProductoClave){
		ProductoPrestamoCli ppc = new ProductoPrestamoCli();
		ppc.ClienteClave = ClienteClave;
		ppc.ProductoClave = ProductoClave;
		ppc.Cargo = 0;
		ppc.Abono = 0;
		ppc.Venta = 0;
		ppc.Saldo = 0;
		ppc.SaldoCarga = 0;
		ppc.MFechaHora = Generales.getFechaHoraActual();
		ppc.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
		ppc.Enviado = false;
		return ppc;
	}
	
	public static ProductoPrestamoCli actualizarPrestamo(String ClienteClave, String ProductoClave, int TipoTransProd, float Cantidad, int TipoUnidad, int Vendido, ProductoPrestamoCli ppc){
		if(TipoTransProd == TiposTransProd.PEDIDO || TipoTransProd == TiposTransProd.VENTA_CONSIGNACION){ //pedido o consigna
			if(Vendido == 0){
				ppc.Cargo += Cantidad;
				ppc.Saldo += Cantidad;
			}else if(Vendido == 1){
				ppc.Venta += Cantidad;
				ppc.Saldo -= Cantidad;
			}
		}else if(TipoTransProd == TiposTransProd.DEVOLUCIONES_CLIENTE){ //dev cliente
			if(Vendido == 2){
				ppc.Abono += Cantidad;
				ppc.Saldo -= Cantidad;
			}
		}
		ppc.MFechaHora = Generales.getFechaHoraActual();
		ppc.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
		ppc.Enviado = false;
		
		return ppc;
	}
}
