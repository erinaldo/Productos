package com.amesol.routelite.actividades;

import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.ProductoDetalle;
import com.amesol.routelite.datos.ProductoPrestamoCli;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

import java.util.concurrent.atomic.AtomicReference;

public class ManejoEnvase
{
	private static ProductoPrestamoCli crearPrestamo(String ClienteClave, String ProductoClave){
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
	
	private static ProductoPrestamoCli actualizarPrestamo(String ClienteClave, String ProductoClave, int TipoTransProd, float Cantidad, int TipoUnidad, int Vendido, ProductoPrestamoCli ppc){
		if(TipoTransProd == TiposTransProd.PEDIDO || TipoTransProd == TiposTransProd.VENTA_CONSIGNACION){ //pedido o consigna
			if(Vendido == 0){
				ppc.Cargo += Cantidad;
				ppc.Saldo += Cantidad;
			}else if(Vendido == 1){
				ppc.Venta += Cantidad;
				ppc.Saldo -= Cantidad;
			}
		}else if(TipoTransProd == TiposTransProd.DEVOLUCIONES_CLIENTE){ //dev cliente
			//if(Vendido == 2){
				ppc.Abono += Cantidad;
				ppc.Saldo -= Cantidad;
			//}
		}
		ppc.MFechaHora = Generales.getFechaHoraActual();
		ppc.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
		ppc.Enviado = false;
		
		return ppc;
	}
	
	public static boolean manejoEnvase(Producto producto, int tipoUnidad, Float cantidad, TransProdDetalle tpd, TransProd trp) throws Exception{
		//try{
			float saldoPrestamoIni = 0;
			Cliente cli = ((Cliente)Sesion.get(Campo.ClienteActual));
			for(ProductoDetalle prod : Consultas2.ConsultasProductoDetalle.obtenerProductosConPrestamo(producto.ProductoClave, tipoUnidad)){
					saldoPrestamoIni = 0;
					ProductoPrestamoCli ppc = new ProductoPrestamoCli();
					ppc.ClienteClave = cli.ClienteClave;
					ppc.ProductoClave = prod.ProductoDetClave;
					BDVend.recuperar(ppc);
					if(ppc.isRecuperado()) 
						saldoPrestamoIni = ppc.Saldo;
					else{
						ppc = ManejoEnvase.crearPrestamo(cli.ClienteClave, prod.ProductoDetClave);
					}
					float CantidadUM = cantidad * prod.Factor;
					if(ppc.Saldo >= CantidadUM){
						if(producto.ProductoClave.equals(prod.ProductoDetClave))
							ppc = ManejoEnvase.actualizarPrestamo(cli.ClienteClave, prod.ProductoDetClave, trp.Tipo, CantidadUM, tipoUnidad, 1, ppc);	
						else
							ppc = ManejoEnvase.actualizarPrestamo(cli.ClienteClave, prod.ProductoDetClave, trp.Tipo, CantidadUM, tipoUnidad, 0, ppc);
					}else if(ppc.Saldo < CantidadUM){
						AtomicReference<Float> existencia = new AtomicReference<Float>(); 
						StringBuilder error = new StringBuilder();

						float cant = 0;
						cant = CantidadUM;
						/*if(!producto.Contenido || trp.Tipo == TiposTransProd.DEVOLUCIONES_CLIENTE){ //para manejar envase asociado a un producto
							cant = CantidadUM;
						}else{ //para manejar el envase solo (cuando se vende por separado)
							cant = CantidadUM - ppc.Saldo;
						}*/

						//if(!Inventario.ValidarExistencia(prod.ProductoDetClave, tipoUnidad, (Float) CantidadUM, transProdGeneral.TipoMovimiento, transProdGeneral.Tipo, existencia, error)){
						/*if(!Inventario.ValidarExistencia(prod.ProductoDetClave, tipoUnidad, (Float) cant, trp.TipoMovimiento, trp.Tipo, existencia, error)){
							//mVista.setCapturaCantidad(ppc.Saldo + existencia.get());
							ppc = ManejoEnvase.actualizarPrestamo(cli.ClienteClave, prod.ProductoDetClave, trp.Tipo, CantidadUM, tipoUnidad, 0, ppc);
							//return false;
						}else{*/
						ppc = ManejoEnvase.actualizarPrestamo(cli.ClienteClave, prod.ProductoDetClave, trp.Tipo, cant, tipoUnidad, 0, ppc);
						if(producto.ProductoClave.equals(prod.ProductoDetClave) && trp.Tipo != TiposTransProd.DEVOLUCIONES_CLIENTE){
							Inventario.ActualizarInventario(prod.ProductoDetClave, tipoUnidad, cant, trp.Tipo, trp.TipoMovimiento, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID );
							ppc = ManejoEnvase.actualizarPrestamo(cli.ClienteClave, prod.ProductoDetClave, trp.Tipo, CantidadUM, tipoUnidad, 1, ppc);
						}
						//}
					}
					if(CantidadUM >= saldoPrestamoIni && producto.ProductoClave.equals(prod.ProductoDetClave)){
						tpd.PrestamoVendido = saldoPrestamoIni;
					}else if(CantidadUM < saldoPrestamoIni && producto.ProductoClave.equals(prod.ProductoDetClave)){
						tpd.PrestamoVendido = CantidadUM;
					}
					BDVend.guardarInsertar(ppc);
			}
			return true;
	}
	
	public static boolean manejoEnvaseEliminar(String ProductoClave, int tipoUnidad, Float cantidad, TransProdDetalle tpd, TransProd trp) throws Exception{
			Cliente cli = ((Cliente)Sesion.get(Campo.ClienteActual));
			for(ProductoDetalle prod : Consultas2.ConsultasProductoDetalle.obtenerProductosConPrestamo(ProductoClave, tipoUnidad)){
				ProductoPrestamoCli ppc = new ProductoPrestamoCli();
				ppc.ClienteClave = cli.ClienteClave;
				ppc.ProductoClave = prod.ProductoDetClave;
				BDVend.recuperar(ppc);
				if(tpd.PrestamoVendido == null || tpd.PrestamoVendido == 0){
					ppc = actualizarPrestamo(cli.ClienteClave, prod.ProductoClave, trp.Tipo, tpd.Cantidad * -1, tpd.TipoUnidad, 0, ppc);
					
					if(ProductoClave.equals(prod.ProductoDetClave)){
						ppc = actualizarPrestamo(cli.ClienteClave, prod.ProductoClave, trp.Tipo, tpd.Cantidad * -1, tpd.TipoUnidad, 1, ppc);
					}
				}else if (tpd.PrestamoVendido != null || tpd.PrestamoVendido != 0){
					float CantidadUM = cantidad * prod.Factor;
					if(CantidadUM > tpd.PrestamoVendido){
						//ppc = actualizarPrestamo(cli.ClienteClave, prod.ProductoClave, trp.Tipo, CantidadUM - tpd.PrestamoVendido * -1, tpd.TipoUnidad, 0, ppc);
						ppc = actualizarPrestamo(cli.ClienteClave, prod.ProductoClave, trp.Tipo,  tpd.Cantidad * -1, tpd.TipoUnidad, 0, ppc);
						if(ProductoClave.equals(prod.ProductoDetClave)){
							ppc = actualizarPrestamo(cli.ClienteClave, prod.ProductoClave, trp.Tipo, tpd.Cantidad * -1, tpd.TipoUnidad, 1, ppc);
						}
					}else if (tpd.PrestamoVendido == CantidadUM){
						ppc = actualizarPrestamo(cli.ClienteClave, prod.ProductoClave, trp.Tipo, tpd.Cantidad * -1, tpd.TipoUnidad, 1, ppc);
					}
				}
				BDVend.guardarInsertar(ppc);
			}
			return true;
	}

    public static boolean manejoEnvaseEliminar(Producto producto, int tipoUnidad, Float cantidad, TransProdDetalle tpd, TransProd trp) throws Exception{
        return manejoEnvaseEliminar(producto.ProductoClave, tipoUnidad, cantidad, tpd, trp);
    }

    public static void validarLimitePrestamoEnvase(AtomicReference<String> mensaje) throws Exception{
        Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
        if(oCliente.Prestamo && oCliente.LimiteEnvase > 0){
            float saldoGeneral = Consultas2.ConsultasProductoPrestamoCli.obtenerSaldoGeneralEnvase(oCliente.ClienteClave);

            if(saldoGeneral > oCliente.LimiteEnvase){
				throw new ControlError("E0917");
            }else{
                MOTConfiguracion motConfiguracion = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
                float porcentajeLimEnvase = (saldoGeneral * 100) / oCliente.LimiteEnvase;
                if(porcentajeLimEnvase >= Float.parseFloat(motConfiguracion.get("PorLimEnvase").toString())){
                    mensaje.set(Mensajes.get("I0276").replace("$0$", String.valueOf(Generales.getRound(porcentajeLimEnvase, 2))+"%"));
                }
            }
        }
    }
}
