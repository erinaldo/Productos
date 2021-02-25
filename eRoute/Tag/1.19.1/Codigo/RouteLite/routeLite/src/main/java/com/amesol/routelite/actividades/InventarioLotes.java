package com.amesol.routelite.actividades;

import java.util.Date;
import java.util.HashMap;
import java.util.concurrent.atomic.AtomicReference;

import com.amesol.routelite.actividades.Enumeradores.Folio;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.ProductoUnidad;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.basedatos.BDTerm;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposFasesDocto;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

public class InventarioLotes
{

	/**** ENUMERADORES ******/
	private final class TiposMovInventario
	{
		public final static int NO_DEFINIDO = 0;
		public final static int SALIDA_DISPONIBLE = 1;
		public final static int ENTRADA_DISPONIBLE = 2;
		public final static int ENTRADA_NODISPONIBLE = 3;
		public final static int SALIDA_APARTADO = 4;
		public final static int ENTRADA_APARTADO = 5;
		public final static int SALIDA_NODISPONIBLE = 6;
		public final static int ENTRADA_PEDIDO = 7;
		public final static int SURTIR_REPARTO = 8;
		public final static int SALIDA_REPARTO = 9;
		public final static int CANCELAR_PEDIDO_X_SURTIR = 10;
		public final static int CANCELAR_VENTA_REPARTO = 11;
	}


	/***********************/

	public static boolean ValidarExistencia(String productoClave, int tipoUnidad, String lote, Float cantidad, short tipoTransProd, String grupoMotivo, AtomicReference<Float> refExistencia, final StringBuilder error)
	{

		if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
		{
			return true;
		}
		if (grupoMotivo.equalsIgnoreCase("Venta"))
		{
			return ValidarExistenciaDisponible(productoClave, tipoUnidad, lote, cantidad, tipoTransProd, refExistencia, error);
		}
		else
		{
			return ValidarExistenciaNoDisponible(productoClave, tipoUnidad, lote, cantidad, refExistencia, error);
		}
	}

	public static boolean ValidarExistencia(String productoClave, int tipoUnidad, String lote, Float cantidad, short tipoMovimiento, short tipoTransProd, AtomicReference<Float> refExistencia, HashMap<InventarioLotesKey, com.amesol.routelite.datos.InventarioLotes> hmInventario, final StringBuilder error)
	{
		if ((tipoMovimiento == TiposMovimientos.ENTRADA) || ((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA && !((Ruta) Sesion.get(Campo.RutaActual)).Inventario) && tipoTransProd == TiposTransProd.PEDIDO))
		{
			return true;
		}
		else
		{
			if (tipoTransProd == TiposTransProd.PEDIDO)
			{
				if (cantidad <= 0)
				{
					return true;
				}
				if (refExistencia.get() != null && refExistencia.get() > 0)
				{
					return ValidarExistenciaDisponible(productoClave, tipoUnidad, lote, cantidad, refExistencia.get(), error);
				}
				else
				{
					return ValidarExistenciaDisponible(productoClave, tipoUnidad, lote, cantidad, tipoTransProd, hmInventario, refExistencia, error);
				}
			}
		}
		return false;
	}

	public static boolean ValidarExistencia(String productoClave, int tipoUnidad, String lote, Float cantidad, Float cantidadAnterior, short tipoMovimiento, short tipoTransProd, boolean cancelacion, AtomicReference<Float> refExistencia, final StringBuilder error)
	{
		if ((tipoMovimiento == TiposMovimientos.ENTRADA) || ((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA && !((Ruta) Sesion.get(Campo.RutaActual)).Inventario) && tipoTransProd == TiposTransProd.PEDIDO))
		{

			if (tipoTransProd == TiposTransProd.CARGAS)
			{
				if (cantidadAnterior == 0)
					if (cancelacion)
						return ValidarExistenciaDisponible(productoClave, tipoUnidad, lote, cantidad, tipoTransProd, refExistencia, error);
					else
						return true;
				else
				{
					float cantidadVal = cantidadAnterior - cantidad;
					if (cantidad >= cantidadAnterior)
					{
						return true;
					}
					return ValidarExistenciaDisponible(productoClave, tipoUnidad, lote, cantidadVal, tipoTransProd, refExistencia, error);
				}
			}
			else
				return true;

		}
		else
		{
			if (tipoTransProd == TiposTransProd.PEDIDO || tipoTransProd == TiposTransProd.AJUSTES || tipoTransProd == TiposTransProd.DESCARGAS || tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES || tipoTransProd == TiposTransProd.CAMBIOS || tipoTransProd == TiposTransProd.CARGAS || tipoTransProd == TiposTransProd.VENTA_CONSIGNACION || tipoTransProd == TiposTransProd.CANJES)
			{
				float cantidadVal = cantidad - cantidadAnterior;
				if (cantidadVal <= 0)
				{
					return true;
				}
                if (tipoTransProd == TiposTransProd.DESCARGAS && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO))
                {
                    return ValidarExistenciaDifNoDisponible(productoClave, tipoUnidad, lote, cantidadVal, refExistencia, error);
                }
                else {
                    if (refExistencia.get() != null && refExistencia.get() > 0) {
                        return ValidarExistenciaDisponible(productoClave, tipoUnidad, lote, cantidadVal, refExistencia.get(), error);
                    } else {
                        return ValidarExistenciaDisponible(productoClave, tipoUnidad, lote, cantidadVal, tipoTransProd, refExistencia, error);
                    }
                }
			}
		}
		return false;
	}

	public static boolean ValidarExistencia(String productoClave, int tipoUnidad, String lote, Float cantidad, com.amesol.routelite.datos.ModuloMovDetalle moduloMovDetalle, AtomicReference<Float> refExistencia, final StringBuilder error)
	{
		return ValidarExistencia(productoClave, tipoUnidad, lote, cantidad, Float.valueOf(0), moduloMovDetalle, false, refExistencia, error);
	}

	public static boolean ValidarExistencia(String productoClave, int tipoUnidad, String lote, Float cantidad, short tipoMovimiento, short tipoTransProd, AtomicReference<Float> refExistencia, final StringBuilder error)
	{
		return ValidarExistencia(productoClave, tipoUnidad, lote, cantidad, Float.valueOf(0), tipoMovimiento, tipoTransProd, false, refExistencia, error);
	}

	public static boolean ValidarExistencia(String productoClave, int tipoUnidad, String lote, Float cantidad, Float cantidadAnterior, com.amesol.routelite.datos.ModuloMovDetalle moduloMovDetalle, boolean cancelacion, AtomicReference<Float> refExistencia, final StringBuilder error)
	{
		return ValidarExistencia(productoClave, tipoUnidad, lote, cantidad, cantidadAnterior, moduloMovDetalle.TipoMovimiento, moduloMovDetalle.TipoTransProd, cancelacion, refExistencia, error);
	}

	// En caso de que ya se tenga la existencia
	private static boolean ValidarExistenciaDisponible(String ProductoClave, int tipoUnidad, String Lote, Float Cantidad, Float Existencia, final StringBuilder Error)
	{
		if (Cantidad <= Existencia)
		{
			return true;
		}
		else
		{
			Error.append(Mensajes.get("E1019", ProductoClave, ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad)), Lote));
		}

		return false;
	}

	private static boolean ValidarExistenciaDisponible(String productoClave, int tipoUnidad, String lote, Float cantidad, short tipoTransProd, HashMap<InventarioLotesKey, com.amesol.routelite.datos.InventarioLotes> hmInventario, AtomicReference<Float> refExistencia, final StringBuilder error)
	{

		if (cantidad == 0)
			return true;

		float dDisponible = 0;
		float dCantidad = 0;
		float iContenido = 0;
		boolean bRes = false;

		try
		{
			if (hmInventario.size() <= 0)
			{
				error.append(Mensajes.get("E1019", productoClave, ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad)), lote));
				return false;
			}
			ISetDatos productoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
			while (productoDetalle.moveToNext())
			{
				dCantidad = cantidad; // * productoDetalle.getFloat(productoDetalle.getColumnIndex("Factor"));
				//si el producto no esta en el inventario

				//InventarioLotesKey inventarioKey = new InventarioLotesKey(productoDetalle.getString("ProductoDetClave"), (short)tipoUnidad, lote);
				InventarioLotesKey inventarioKey = null;
				if (hmInventario.size() > 0)
					for (InventarioLotesKey inv: hmInventario.keySet()) {
						if (inv.ProductoClave.equals(productoDetalle.getString("ProductoDetClave")) && inv.TipoUnidad == (short)tipoUnidad && inv.Lote.equals(lote)) {
							inventarioKey = inv;
							break;
						}
					}
				if (inventarioKey == null)
					inventarioKey = new InventarioLotesKey(productoDetalle.getString("ProductoDetClave"), (short)tipoUnidad, lote);

				if (!hmInventario.containsKey(inventarioKey) || hmInventario.get(inventarioKey) == null || hmInventario.get(inventarioKey).Disponible <= 0)
				{
					error.append(Mensajes.get("E1019", productoClave, ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad)), lote));
					return false;
				}
				//Si es el producto Terminado
				if (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))
				{
					dDisponible = hmInventario.get(inventarioKey).Disponible - hmInventario.get(inventarioKey).NoDisponible - hmInventario.get(inventarioKey).Apartado - hmInventario.get(inventarioKey).Contenido;
					//}
					if (tipoTransProd == Enumeradores.TiposTransProd.CARGAS)
					{
						dDisponible += hmInventario.get(inventarioKey).Pedido;
						hmInventario.get(inventarioKey).Apartado -= hmInventario.get(inventarioKey).Pedido;
					}
				}
				//Si es un producto contenido
				else if (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && !productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))
				{
					if (dCantidad < hmInventario.get(inventarioKey).Contenido)
					{
						iContenido = 1;
					}
				}

				if ((dCantidad <= dDisponible && (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))) || (iContenido == 1))
				{
					refExistencia.set(dDisponible);
					//Si hay disponible y aparto en memoria la cantidad de producto que solicité
					hmInventario.get(inventarioKey).Apartado = hmInventario.get(inventarioKey).Apartado + dCantidad;

					bRes = true;
				}
				else if ((dCantidad > dDisponible && (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))) || (iContenido == 0))
				{
					if (dDisponible > dCantidad)
					{
						refExistencia.set(dCantidad);
						//Si hay disponible y aparto en memoria la cantidad de producto que solicité
						hmInventario.get(inventarioKey).Apartado = hmInventario.get(inventarioKey).Apartado + dCantidad;

					}
					else
					{
						refExistencia.set(dDisponible);
						//En este caso aparto todo lo que queda disponible del producto que solicité
						hmInventario.get(inventarioKey).Apartado = hmInventario.get(inventarioKey).Apartado + dDisponible;
					}

					error.append(Mensajes.get("E0714", productoClave));
					return false;
				}
			}
			if (dDisponible <= 0 && cantidad > 0)
			{
				error.append(Mensajes.get("E1019", productoClave, ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad)), lote));
				return false;
			}
			else
			{
				if (!bRes)
				{
					error.append(Mensajes.get("E1019", productoClave, ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad)), lote));
				}
				return bRes;
			}
		}
		catch (Exception ex)
		{
			error.append(ex.getMessage());
			return false;
		}
	}

	private static boolean ValidarExistenciaDisponible(String productoClave, int tipoUnidad, String lote, Float cantidad, int tipoTransProd, AtomicReference<Float> refExistencia, final StringBuilder error)
	{

		if (cantidad == 0)
			return true;

		float dDisponible = 0;
		float dCantidad = 0;
		float iContenido = 0;
		boolean bRes = false;

		try
		{
			ISetDatos productoDetalle = Consultas.ConsultasInventarioLotes.obtenerProductoInventario(productoClave, tipoUnidad, lote);
			while (productoDetalle.moveToNext())
			{
				dCantidad = cantidad; //* productoDetalle.getFloat(productoDetalle.getColumnIndex("Factor"));
				if (productoDetalle.isNull(productoDetalle.getColumnIndex("Disponible")) || productoDetalle.getFloat("Disponible") <= 0)
				{
					error.append(Mensajes.get("E1019", productoClave, ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad)), lote));
					return false;
				}

				if (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))
				{
					if (!productoDetalle.getBoolean("PROContenido"))
					{
						dDisponible = productoDetalle.getFloat("Disponible") - productoDetalle.getFloat("NoDisponible") - productoDetalle.getFloat("Apartado");
					}
					else
					{
						dDisponible = productoDetalle.getFloat("Disponible") - productoDetalle.getFloat("NoDisponible") - productoDetalle.getFloat("Apartado") - productoDetalle.getFloat("Contenido");
					}

					if (tipoTransProd == Enumeradores.TiposTransProd.CARGAS)
					{
						dDisponible += productoDetalle.getFloat("Pedido");
					}
					if (tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES)
					{
						dDisponible = productoDetalle.getFloat("NoDisponible");
					}
					/*if(tipoTransProd == 0){ //existencia para traspaso de inventario //COMENTADO POR QUE SE DEJA LA EXISTENCIA COMO EN EL PEDIDO Disponible-NoDisponible-Apartado
						dDisponible = productoDetalle.getFloat("Disponible");
					}*/
				}
				else if (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && !productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))
				{
					if (dCantidad <= productoDetalle.getFloat("Contenido"))
					{
						iContenido = 1;
					}
				}

				if ((dCantidad <= dDisponible && (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))) || (iContenido == 1))
				{
					refExistencia.set(dDisponible);
					bRes = true;
				}
				else if ((dCantidad > dDisponible && (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))) || (iContenido == 0))
				{
					if (dDisponible > dCantidad)
					{
						refExistencia.set(dCantidad);
					}
					else
					{
						refExistencia.set(dDisponible);
					}
					error.append(Mensajes.get("E1019", productoClave, ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad)), lote));
					return false;
				}
			}
			if (dDisponible <= 0 && cantidad > 0)
			{
				error.append(Mensajes.get("E1019", productoClave, ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad)), lote));
				return false;
			}
			else
			{
				if (!bRes)
					error.append(Mensajes.get("E1019", productoClave, ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad)), lote));
				return bRes;
			}
		}
		catch (Exception ex)
		{
			error.append(ex.getMessage());
			return false;
		}
	}

	private static boolean ValidarExistenciaNoDisponible(String productoClave, int tipoUnidad, String lote, Float cantidad, AtomicReference<Float> refExistencia, final StringBuilder error)
	{
		if (cantidad == 0)
			return true;

		float dCantidad = 0;

		try
		{
			ISetDatos productoDetalle = Consultas.ConsultasInventarioLotes.obtenerProductoInventario(productoClave, tipoUnidad, lote);
			while (productoDetalle.moveToNext())
			{
				dCantidad = cantidad; //* productoDetalle.getFloat(productoDetalle.getColumnIndex("Factor"));
				if (productoDetalle.isNull(productoDetalle.getColumnIndex("NoDisponible")) || productoDetalle.getFloat("NoDisponible") <= 0)
				{
					error.append(Mensajes.get("E1019", productoClave, ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad)), lote));
					return false;
				}

				if (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))
				{
					if (dCantidad <= productoDetalle.getFloat("NoDisponible"))
					{
						productoDetalle.close();
						return true;
					}
					else
					{
						refExistencia.set(productoDetalle.getFloat("NoDisponible"));
						error.append(Mensajes.get("E1019", productoClave, ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad)), lote));
						return false;
					}

				}

			}
			productoDetalle.close();
			productoDetalle = null;
			return false;
		}
		catch (Exception ex)
		{
			error.append(ex.getMessage());
			return false;
		}
	}
	
	public static boolean ValidarExistenciaDifNoDisponible(String productoClave, int tipoUnidad, String lote, Float cantidad, AtomicReference<Float> refExistencia, final StringBuilder error)
	{
		float dCantidad = 0;
		float dDisponible = 0;
		boolean res = false;
		try
		{
			ISetDatos productoDetalle = Consultas.ConsultasInventarioLotes.obtenerProductoInventario(productoClave, tipoUnidad, lote);
			ISetDatos productoPedido = Consultas.ConsultasInventarioLotes.obtenerInventarioPedido(productoClave, tipoUnidad, lote);
			while (productoDetalle.moveToNext())
			{
				dCantidad = cantidad;
				float diferenciaApartado = 0;
				int contenido = 0;
				
				if(productoPedido.getCount() > 0){
					productoPedido.moveToFirst();
					diferenciaApartado = productoDetalle.getFloat("Pedido") - productoPedido.getFloat("Pedido"); 
				}

				if (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))
				{
					dDisponible = productoDetalle.getFloat("Disponible") - productoDetalle.getFloat("NoDisponible") - productoDetalle.getFloat("Contenido") - diferenciaApartado;
					
				}else if(productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && !productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave)){
					if(dCantidad <= productoDetalle.getFloat("Contenido")){
						contenido = 1;
					}
				}
				
				if(Generales.getRound(dCantidad, 4) <= Generales.getRound(dDisponible, 4) && (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave) ||contenido == 1)){
					refExistencia.set(dDisponible);
					res = true;
				}else if(Generales.getRound(dCantidad, 4) > Generales.getRound(dDisponible, 4) && (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave) ||contenido == 0)){
					if(dDisponible > dCantidad){
						refExistencia.set(dCantidad);
					}else{
						refExistencia.set(dDisponible);
					}
				}

			}
			productoDetalle.close();
			productoDetalle = null;
			productoPedido.close();
			productoPedido = null;
			//return false;
            if (!res)
                error.append(Mensajes.get("E1019", productoClave, ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad)), lote));
			return res;
		}
		catch (Exception ex)
		{
			error.append(ex.getMessage());
			//return false;
			return res;
		}
	}

	public static boolean CargasFaseTransferir() throws Exception
	{
        if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA ){
            //Si es preventa no aplica
            return true;
        }

		ISetDatos dtCargas = Consultas.ConsultasCargas.obtenerDetalleCargasPorTransferir();

		while (dtCargas.moveToNext())
		{
			ActualizarInventario(dtCargas.getString("ProductoClave"), dtCargas.getInt("TipoUnidad"), dtCargas.getString("Lote"), Generales.getRound(dtCargas.getFloat("Cantidad"), dtCargas.getInt("DecimalProducto")), TiposTransProd.CARGAS, TiposMovimientos.ENTRADA, "", false);
		}

		if (dtCargas.getCount() > 0)
		{
			Consultas.ConsultasCargas.actualizarFaseTransferirACaptura();
		}

		dtCargas.close();
		BDVend.commit();
		return true;
	}
	
	public static void CargarInventarioABordo() throws Exception
	{
        if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA ){
            //Si es preventa no aplica
            return;
        }
		//Si no se usa descargaAutomatica
		if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("DescargaAutomatica").equals("1")) return;
		ISetDatos dtInventarioABordo = Consultas.ConsultasCargas.obtenerDetalleInventarioABordo();

		while (dtInventarioABordo.moveToNext())
		{
			ActualizarInventario(dtInventarioABordo.getString("ProductoClave"), dtInventarioABordo.getInt("TipoUnidad"), dtInventarioABordo.getString("Lote"), Generales.getRound(dtInventarioABordo.getFloat("Cantidad"), dtInventarioABordo.getInt("DecimalProducto")), TiposTransProd.CARGAS, TiposMovimientos.ENTRADA, "", false);
		}

		dtInventarioABordo.close();
		BDVend.commit();
	}
	
	//public static void CrearMovimientoAutomatico
	
	public static boolean CargarInventarioPedido() throws Exception
	{
        if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != TiposModulos.REPARTO ){

            //Si no es reparto, esta funcion no aplica
            return true;
        }
		ISetDatos pedidos = Consultas.ConsultasReparto.obtenerPedidos();
		while(pedidos.moveToNext()){
			ActualizarInventario(pedidos.getString("ProductoClave"), pedidos.getInt("TipoUnidad"), pedidos.getString("Lote"), pedidos.getFloat("Cantidad"), TiposTransProd.PEDIDO, TiposMovimientos.ENTRADA);
		}
		pedidos.close();
		pedidos = null;
		BDVend.commit();
		return true;
	}

	public static boolean ActualizarInventario(String productoClave, int tipoUnidad, String lote, float cantidad, int tipoTransProd, int tipoMovimiento) throws Exception
	{
		return ActualizarInventario(productoClave, tipoUnidad, lote, cantidad, tipoTransProd, tipoMovimiento, "", false);
	}

	public static boolean ActualizarInventario(String productoClave, int tipoUnidad, String lote, float cantidad, int tipoTransProd, int tipoMovimiento, boolean cancelar) throws Exception
	{
		return ActualizarInventario(productoClave, tipoUnidad, lote, cantidad, tipoTransProd, tipoMovimiento, "", cancelar);
	}

    public static boolean ActualizarInventario(String productoClave, int tipoUnidad, String lote, float cantidad, int tipoTransProd, int tipoMovimiento, boolean cancelar, float prestamoVendido) throws Exception
    {
        return ActualizarInventario(productoClave, tipoUnidad, lote, cantidad, tipoTransProd, tipoMovimiento, "", cancelar, prestamoVendido);
    }
	
	public static boolean ActualizarInventario(String productoClave, String lote, int tipoUnidad, float cantidad, int tipoTransProd, int tipoMovimiento, boolean cancelacion, int tipoFase) throws Exception
	{
		return ActualizarInventario(productoClave, tipoUnidad, lote, cantidad, tipoTransProd, tipoMovimiento, "", cancelacion, "", 0, false, tipoFase);
	}

    public static boolean ActualizarInventario(String productoClave, int tipoUnidad, String lote, float cantidad, int tipoTransProd, int tipoMovimiento, boolean cancelacion, int tipoFase, float prestamoVendido) throws Exception
    {
        return ActualizarInventario(productoClave, tipoUnidad, lote, cantidad, tipoTransProd, tipoMovimiento, "", cancelacion, "", prestamoVendido, false, tipoFase);
    }

    public static boolean ActualizarInventario(String productoClave, int tipoUnidad, String lote, float cantidad, int tipoTransProd, int tipoMovimiento, String grupoMotivo, boolean cancelacion) throws Exception
	{
		return ActualizarInventario(productoClave, tipoUnidad, lote, cantidad, tipoTransProd, tipoMovimiento, grupoMotivo, cancelacion, "", 0, false, 0);
	}

    public static boolean ActualizarInventario(String productoClave, int tipoUnidad, String lote, float cantidad, int tipoTransProd, int tipoMovimiento, String grupoMotivo, boolean cancelacion, float prestamoVendido) throws Exception
    {
        return ActualizarInventario(productoClave, tipoUnidad, lote, cantidad, tipoTransProd, tipoMovimiento, grupoMotivo, cancelacion, "", prestamoVendido, false, 0);
    }
	
	public static boolean ActualizarInventario(String productoClave, int tipoUnidad, String lote, float cantidad, int tipoTransProd, int tipoMovimiento, String grupoMotivo, boolean cancelacion, String clienteClave, float prestamoVendido, boolean surtirPedido) throws Exception{
		return ActualizarInventario(productoClave, tipoUnidad, lote, cantidad, tipoTransProd, tipoMovimiento, grupoMotivo, cancelacion, "", 0, surtirPedido,0);
	}
	
	public static boolean ActualizarInventario(String productoClave, int tipoUnidad, String lote, float cantidad, int tipoTransProd, int tipoMovimiento, String grupoMotivo, boolean cancelacion, String clienteClave, float prestamoVendido, boolean surtirPedido, int tipoFase) throws Exception
	{
		int tipoMovInventario = TiposMovInventario.NO_DEFINIDO;
		boolean incluirContenedor = false;
		if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA ||
		   (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO && (
				tipoTransProd == TiposTransProd.CANJES || tipoTransProd == TiposTransProd.CARGAS ||
				tipoTransProd == TiposTransProd.CAMBIOS || tipoTransProd == TiposTransProd.DESCARGAS ||
				tipoTransProd == TiposTransProd.DEVOLUCIONES_CLIENTE || tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES ||
				(tipoTransProd == TiposTransProd.VENTA_CONSIGNACION && !surtirPedido) ||
				(tipoTransProd == TiposTransProd.PEDIDO && !surtirPedido ) ||
				(tipoTransProd == TiposTransProd.NO_DEFINIDO && clienteClave.equals("") && tipoFase == 0 && !grupoMotivo.equals(""))
		   )))
		{
			if (tipoMovimiento == TiposMovimientos.ENTRADA)
			{
				if (!cancelacion && tipoTransProd == TiposTransProd.CARGAS) {
					tipoMovInventario = TiposMovInventario.ENTRADA_DISPONIBLE;
					incluirContenedor = true;
				}
				else if (cancelacion && tipoTransProd == TiposTransProd.CARGAS) {
					tipoMovInventario = TiposMovInventario.SALIDA_DISPONIBLE;
				}
				else if (tipoTransProd == TiposTransProd.CAMBIOS || tipoTransProd == TiposTransProd.DEVOLUCIONES_CLIENTE)
				{
					if (!cancelacion)
					{
						if (grupoMotivo.equalsIgnoreCase("Venta") || grupoMotivo.equalsIgnoreCase("Consignacion"))
							tipoMovInventario = TiposMovInventario.ENTRADA_DISPONIBLE;
						else
							tipoMovInventario = TiposMovInventario.ENTRADA_NODISPONIBLE;
					}
					else
					{
						if (grupoMotivo.equalsIgnoreCase("Venta") || grupoMotivo.equalsIgnoreCase("Consignacion"))
							tipoMovInventario = TiposMovInventario.SALIDA_DISPONIBLE;
						else
							tipoMovInventario = TiposMovInventario.SALIDA_NODISPONIBLE;
					}

				}else if( (tipoTransProd == TiposTransProd.NO_DEFINIDO && clienteClave.equals("") && tipoFase == 0 && !grupoMotivo.equals("")) ){ //traspaso de inventario
					if(grupoMotivo.equalsIgnoreCase("Venta")) {
                        if(!cancelacion)
                            tipoMovInventario = TiposMovInventario.ENTRADA_DISPONIBLE;
                        else
                            tipoMovInventario = TiposMovInventario.SALIDA_DISPONIBLE;
                    }
					else if(grupoMotivo.equalsIgnoreCase("No Venta")){
						//sobreescribir el tipotransprod para que se comporte como dev manual
						if(!cancelacion)
							tipoMovInventario = TiposMovInventario.ENTRADA_NODISPONIBLE;
						else
							tipoMovInventario = TiposMovInventario.SALIDA_NODISPONIBLE;
						tipoTransProd = TiposTransProd.DEVOLUCIONES_MANUALES;
					}
				}else if(tipoTransProd == TiposTransProd.PEDIDO){ //movs usados en reparto!!!
					if(!cancelacion) //mov para llenar las columnas apartado y pedido en reparto
						tipoMovInventario = TiposMovInventario.ENTRADA_PEDIDO;
					else if(tipoFase != TiposFasesDocto.SURTIDO) //mov para cancelar lineas al modificar pedido
						tipoMovInventario = TiposMovInventario.CANCELAR_PEDIDO_X_SURTIR;
					else if(tipoFase == TiposFasesDocto.SURTIDO) //mov para cancelar pedido generados en visita
						tipoMovInventario = TiposMovInventario.CANCELAR_VENTA_REPARTO;
				}

			}
			else if (tipoMovimiento == TiposMovimientos.SALIDA)
			{
				if (!cancelacion && (tipoTransProd == TiposTransProd.PEDIDO || tipoTransProd == TiposTransProd.CAMBIOS || tipoTransProd == TiposTransProd.AJUSTES || tipoTransProd == TiposTransProd.DESCARGAS || tipoTransProd == TiposTransProd.VENTA_CONSIGNACION || tipoTransProd == TiposTransProd.CANJES))
					tipoMovInventario = TiposMovInventario.SALIDA_DISPONIBLE;
				else if (cancelacion && (tipoTransProd == TiposTransProd.PEDIDO || tipoTransProd == TiposTransProd.CAMBIOS || tipoTransProd == TiposTransProd.AJUSTES || tipoTransProd == TiposTransProd.DESCARGAS || tipoTransProd == TiposTransProd.VENTA_CONSIGNACION || tipoTransProd == TiposTransProd.CANJES))
					tipoMovInventario = TiposMovInventario.ENTRADA_DISPONIBLE;
				else if (tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES)
				{
					if (!cancelacion)
						tipoMovInventario = TiposMovInventario.SALIDA_NODISPONIBLE;
					else
						tipoMovInventario = TiposMovInventario.ENTRADA_NODISPONIBLE;
				}else if( (tipoTransProd == TiposTransProd.NO_DEFINIDO && clienteClave.equals("") && tipoFase == 0 && !grupoMotivo.equals("")) ){ //traspaso de inventario
					if(grupoMotivo.equalsIgnoreCase("Venta")) {
                        if(!cancelacion)
                            tipoMovInventario = TiposMovInventario.SALIDA_DISPONIBLE;
                        else
                            tipoMovInventario = TiposMovInventario.ENTRADA_DISPONIBLE;
                    }
					else if(grupoMotivo.equalsIgnoreCase("No Venta")){
						//sobreescribir el tipotransprod para que se comporte como dev manual
						if(!cancelacion)
							tipoMovInventario = TiposMovInventario.SALIDA_NODISPONIBLE;
						else
							tipoMovInventario = TiposMovInventario.ENTRADA_NODISPONIBLE;
						tipoTransProd = TiposTransProd.DEVOLUCIONES_MANUALES;
					}
				}

			}
		}
		else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA && ((Ruta) Sesion.get(Campo.RutaActual)).Inventario)
		{
			if (tipoMovimiento == TiposMovimientos.SALIDA || tipoMovimiento == TiposMovimientos.NO_DEFINIDO)
			{
				if (!cancelacion && (tipoTransProd == TiposTransProd.PEDIDO || tipoTransProd == TiposTransProd.CAMBIOS))
					tipoMovInventario = TiposMovInventario.SALIDA_APARTADO;
				else if (cancelacion && (tipoTransProd == TiposTransProd.PEDIDO || tipoTransProd == TiposTransProd.CAMBIOS))
					tipoMovInventario = TiposMovInventario.ENTRADA_APARTADO;
			}
		}else if(tipoMovimiento == TiposMovimientos.PEDIDO && (tipoTransProd == TiposTransProd.PEDIDO) && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO){
			tipoMovInventario = TiposMovInventario.ENTRADA_PEDIDO;
		}else if(
				(((tipoTransProd == TiposTransProd.PEDIDO && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != TiposModulos.PREVENTA)
				|| (tipoTransProd == TiposTransProd.PEDIDO && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != TiposModulos.REPARTO)
				|| (tipoTransProd == TiposTransProd.PEDIDO && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO && tipoMovimiento != TiposMovimientos.PEDIDO))
				|| (tipoTransProd == TiposTransProd.VENTA_CONSIGNACION && ((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO && surtirPedido) || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA))
				) && (tipoMovimiento == TiposMovimientos.SALIDA)
				){ 
			//surtir pedido, 2			
			tipoMovInventario = TiposMovInventario.SURTIR_REPARTO;
		}else if(tipoMovimiento == TiposMovimientos.ENTRADA && tipoTransProd == TiposTransProd.PEDIDO && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO && !cancelacion){
			//salida pedido reparto, 14
			tipoMovInventario = TiposMovInventario.SALIDA_REPARTO;
		}else if(tipoMovimiento == TiposMovimientos.NO_DEFINIDO && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO
				&& (tipoTransProd == TiposTransProd.PEDIDO || tipoTransProd == TiposTransProd.VENTA_CONSIGNACION) && cancelacion){
			//cancelar pedido reparto, 17
			tipoMovInventario = TiposMovInventario.CANCELAR_PEDIDO_X_SURTIR;
		}else if(tipoMovimiento == TiposMovimientos.ENTRADA && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO
				&& tipoTransProd == TiposTransProd.PEDIDO && cancelacion){
			//cancelar venta reparto, 16
			tipoMovInventario = TiposMovInventario.CANCELAR_VENTA_REPARTO;
		}

		if (tipoMovInventario == TiposMovInventario.ENTRADA_DISPONIBLE)
		{
			ISetDatos dtProductoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
			float cantidadxFactor = 0;

			while (dtProductoDetalle.moveToNext())
			{
				com.amesol.routelite.datos.InventarioLotes inv = new com.amesol.routelite.datos.InventarioLotes();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.TipoUnidad = (short)tipoUnidad;
				inv.Lote = lote;
				cantidadxFactor = cantidad; // * dtProductoDetalle.getFloat("Factor");
				BDVend.recuperar(inv);

				if (inv.isRecuperado())
				{
					if (dtProductoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave.toUpperCase()))
					{
                        inv.Disponible += (cantidadxFactor - prestamoVendido);
                        inv.Apartado = inv.Pedido;
					}
					else
					{
						inv.Disponible = inv.Disponible + cantidadxFactor;
						inv.Contenido = inv.Contenido + cantidadxFactor;
					}
				}
				else
				{
					if (dtProductoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))
					{
						inv.Disponible = inv.Disponible + cantidadxFactor;
						inv.NoDisponible = 0;
						inv.Apartado = 0;
						inv.Contenido = 0;
						inv.Pedido = 0;
					}
					else
					{
						inv.Disponible = inv.Disponible + cantidadxFactor;
						inv.NoDisponible = 0;
						inv.Apartado = 0;
						inv.Contenido = inv.Contenido + cantidadxFactor;
						inv.Pedido = 0;
					}
				}
				inv.MFechaHora = Generales.getFechaHoraActual();
				inv.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				BDVend.guardarInsertar(inv);
			}
			dtProductoDetalle.close();

			if (incluirContenedor){
				ProductoUnidad pru = new ProductoUnidad();
				pru.ProductoClave = productoClave;
				pru.PRUTipoUnidad = Short.parseShort(String.valueOf(tipoUnidad));
				BDVend.recuperar(pru);
				if (pru.Contenedor != null && pru.Contenedor.length() >0){
					com.amesol.routelite.datos.InventarioLotes inv = new com.amesol.routelite.datos.InventarioLotes();
					inv.ProductoClave = pru.Contenedor;
					inv.TipoUnidad = (short)tipoUnidad;
					inv.Lote = lote;
					BDVend.recuperar(inv);

					if (inv.isRecuperado())
					{
							inv.Disponible += cantidad;
					}
					else
					{
							inv.Disponible = cantidad;
							inv.NoDisponible = 0;
							inv.Apartado = 0;
							inv.Contenido = 0;
							inv.Pedido = 0;

					}
					inv.MFechaHora = Generales.getFechaHoraActual();
					inv.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
					BDVend.guardarInsertar(inv);
				}
			}
			return true;
		}
		else if (tipoMovInventario == TiposMovInventario.ENTRADA_NODISPONIBLE)
		{
			ISetDatos dtProductoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
			float cantidadxFactor = 0;

			while (dtProductoDetalle.moveToNext())
			{
				com.amesol.routelite.datos.InventarioLotes inv = new com.amesol.routelite.datos.InventarioLotes();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.TipoUnidad = (short)tipoUnidad;
				inv.Lote = lote;
				cantidadxFactor = cantidad; // * dtProductoDetalle.getFloat("Factor");
				BDVend.recuperar(inv);

				if (inv.isRecuperado())
				{
					if (dtProductoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave.toUpperCase()))
					{
						inv.Disponible = inv.Disponible + cantidadxFactor;
						inv.NoDisponible = inv.NoDisponible + cantidadxFactor;
					}
					else
					{
						inv.Disponible = inv.Disponible + cantidadxFactor;
						inv.Contenido = inv.Contenido + cantidadxFactor;
					}
				}
				else
				{
					if (dtProductoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))
					{
						inv.Disponible = inv.Disponible + cantidadxFactor;
						inv.NoDisponible = inv.NoDisponible + cantidadxFactor;
						inv.Apartado = 0;
						inv.Contenido = 0;
						inv.Pedido = 0;
					}
					else
					{
						inv.Disponible = inv.Disponible + cantidadxFactor;
						inv.NoDisponible = 0;
						inv.Apartado = 0;
						inv.Contenido = inv.Contenido + cantidadxFactor;
						inv.Pedido = 0;
					}
				}
				inv.MFechaHora = Generales.getFechaHoraActual();
				inv.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				BDVend.guardarInsertar(inv);
			}
			dtProductoDetalle.close();
			return true;
		}
		else if (tipoMovInventario == TiposMovInventario.SALIDA_DISPONIBLE)
		{
			ISetDatos dtProductoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
			float cantidadxFactor = 0;

			while (dtProductoDetalle.moveToNext())
			{
				com.amesol.routelite.datos.InventarioLotes inv = new com.amesol.routelite.datos.InventarioLotes();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.TipoUnidad = (short)tipoUnidad;
				inv.Lote = lote;
				cantidadxFactor = cantidad; // * dtProductoDetalle.getFloat("Factor");

				BDVend.recuperar(inv);

				if (inv.isRecuperado())
				{
					if (dtProductoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave.toUpperCase()))
					{
						inv.Disponible = inv.Disponible - cantidadxFactor;
					}
					else
					{
						inv.Disponible = inv.Disponible - cantidadxFactor;
						inv.Contenido = inv.Contenido - cantidadxFactor;
					}
					inv.MFechaHora = Generales.getFechaHoraActual();
					inv.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
					BDVend.guardarInsertar(inv);
				}
				else
				{
					dtProductoDetalle.close();
					return false;
				}
			}
			dtProductoDetalle.close();
			return true;
		}
		else if (tipoMovInventario == TiposMovInventario.SALIDA_APARTADO)
		{
			ISetDatos dtProductoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
			float cantidadxFactor = 0;

			while (dtProductoDetalle.moveToNext())
			{
				com.amesol.routelite.datos.InventarioLotes inv = new com.amesol.routelite.datos.InventarioLotes();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.TipoUnidad = (short)tipoUnidad;
				inv.Lote = lote;
				cantidadxFactor = cantidad; // * dtProductoDetalle.getFloat("Factor");

				BDVend.recuperar(inv);

				if (inv.isRecuperado())
				{
					if (dtProductoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave.toUpperCase()))
					{
						inv.Apartado = inv.Apartado + cantidadxFactor;
					}
					inv.MFechaHora = Generales.getFechaHoraActual();
					inv.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
					BDVend.guardarInsertar(inv);
				}
				else
				{
					dtProductoDetalle.close();
					return false;
				}
			}
			dtProductoDetalle.close();
			return true;
		}
		else if (tipoMovInventario == TiposMovInventario.SALIDA_NODISPONIBLE)
		{
			ISetDatos dtProductoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
			float cantidadxFactor = 0;

			while (dtProductoDetalle.moveToNext())
			{
				com.amesol.routelite.datos.InventarioLotes inv = new com.amesol.routelite.datos.InventarioLotes();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.TipoUnidad = (short)tipoUnidad;
				inv.Lote = lote;
				cantidadxFactor = cantidad; //* dtProductoDetalle.getFloat("Factor");

				BDVend.recuperar(inv);

				if (inv.isRecuperado())
				{
					if (dtProductoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave.toUpperCase()))
					{
						inv.Disponible = inv.Disponible - cantidadxFactor;
						inv.NoDisponible = inv.NoDisponible - cantidadxFactor;
					}
					else
					{
						inv.Contenido = inv.Contenido - cantidadxFactor;
						if (inv.Disponible < inv.Contenido)
						{
							inv.Disponible = inv.Contenido;
						}
						else
						{
							inv.Disponible = inv.Disponible - cantidadxFactor;
						}

					}
					inv.MFechaHora = Generales.getFechaHoraActual();
					inv.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
					BDVend.guardarInsertar(inv);
				}
				else
				{
					dtProductoDetalle.close();
					return false;
				}
			}
			dtProductoDetalle.close();
			return true;
		}
		else if (tipoMovInventario == TiposMovInventario.ENTRADA_APARTADO)
		{
			ISetDatos dtProductoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
			float cantidadxFactor = 0;

			while (dtProductoDetalle.moveToNext())
			{
				com.amesol.routelite.datos.InventarioLotes inv = new com.amesol.routelite.datos.InventarioLotes();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.TipoUnidad = (short)tipoUnidad;
				inv.Lote = lote;
				cantidadxFactor = cantidad; //* dtProductoDetalle.getFloat("Factor");

				BDVend.recuperar(inv);

				if (inv.isRecuperado())
				{
					if (dtProductoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave.toUpperCase()))
					{
						inv.Apartado = inv.Apartado - cantidadxFactor;
					}
					inv.MFechaHora = Generales.getFechaHoraActual();
					inv.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
					BDVend.guardarInsertar(inv);
				}
				else
				{
					dtProductoDetalle.close();
					return false;
				}
			}
			dtProductoDetalle.close();
			return true;
		}else if (tipoMovInventario == TiposMovInventario.ENTRADA_PEDIDO){
			ISetDatos dtProductoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
			while (dtProductoDetalle.moveToNext()){
				com.amesol.routelite.datos.InventarioLotes inv = new com.amesol.routelite.datos.InventarioLotes();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.TipoUnidad = (short)tipoUnidad;
				inv.Lote = lote;
				float cantidadxFactor = cantidad; //* dtProductoDetalle.getFloat("Factor");
				BDVend.recuperar(inv);
				
				if(inv.isRecuperado()){
					if(dtProductoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave)){
						inv.Pedido = inv.Pedido + cantidadxFactor;
						inv.MFechaHora = Generales.getFechaHoraActual();
						inv.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
						BDVend.guardarInsertar(inv);
					}
				}else{
					if(dtProductoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave)){
						inv.Pedido = cantidadxFactor;
						inv.MFechaHora = Generales.getFechaHoraActual();
						inv.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
						BDVend.guardarInsertar(inv);
					}
				}
			}
			dtProductoDetalle.close();
			return true;
		}else if(tipoMovInventario == TiposMovInventario.SURTIR_REPARTO){
			ISetDatos dtProductoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
			float cantidadxFactor = 0;
		
			while (dtProductoDetalle.moveToNext())
			{
				com.amesol.routelite.datos.InventarioLotes inv = new com.amesol.routelite.datos.InventarioLotes();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.TipoUnidad = (short)tipoUnidad;
				inv.Lote = lote;
				cantidadxFactor = cantidad; //* dtProductoDetalle.getFloat("Factor");
				cantidadxFactor -= prestamoVendido;
				BDVend.recuperar(inv);
				
				if (dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave.toUpperCase())){
					float cantidadApartado = cantidadxFactor;					
					
					if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO){
						inv.Pedido -= cantidadxFactor;
						inv.Apartado -= cantidadApartado;
						inv.Disponible -= cantidadxFactor;
					}else{
						inv.Apartado -= cantidadApartado;
						inv.Disponible -= cantidadxFactor;
					}
					
					if(inv.Apartado < 0)
						inv.Apartado = 0;
					if(inv.Pedido < 0)
						inv.Pedido = 0;
				}else{
					inv.Contenido -= cantidadxFactor;
					inv.Disponible -= cantidadxFactor;
					if(inv.Disponible < inv.Contenido)
						inv.Contenido = inv.Disponible;
				}
				inv.MFechaHora = Generales.getFechaHoraActual();
				inv.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				BDVend.guardarInsertar(inv);
			}
			dtProductoDetalle.close();
			return true;
		}else if(tipoMovInventario == TiposMovInventario.SALIDA_REPARTO){
			ISetDatos dtProductoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
			float cantidadxFactor = 0;
			
			while (dtProductoDetalle.moveToNext())
			{
				com.amesol.routelite.datos.InventarioLotes inv = new com.amesol.routelite.datos.InventarioLotes();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.TipoUnidad = (short)tipoUnidad;
				inv.Lote = lote;
				cantidadxFactor = cantidad; //* dtProductoDetalle.getFloat("Factor");
				BDVend.recuperar(inv);
				
				AtomicReference<Float> existencia = new AtomicReference<Float>();
				StringBuilder error = new StringBuilder();
                if (tipoTransProd == TiposTransProd.DESCARGAS)
                    ValidarExistenciaDifNoDisponible(productoClave,tipoUnidad, lote, cantidad,existencia, error);
                else
                    ValidarExistenciaDisponible(productoClave, tipoUnidad, lote, cantidad, tipoTransProd, existencia, error);
				
				if(dtProductoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave)){
					if(cantidadxFactor - prestamoVendido > 0){
						if(existencia.get() > 0 && cantidadxFactor > 0){
							if(existencia.get() > cantidadxFactor){
								inv.Pedido += (cantidadxFactor - prestamoVendido);
								inv.Apartado += (cantidadxFactor - prestamoVendido);
							}else{
								inv.Pedido += (cantidadxFactor - prestamoVendido);
								inv.Apartado += existencia.get();
							}
						}else{
							inv.Pedido += (cantidadxFactor - prestamoVendido);							
						}
					}
					if(inv.Apartado > inv.Pedido)
						inv.Apartado = inv.Pedido;
					
					inv.MFechaHora = Generales.getFechaHoraActual();
					inv.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
					BDVend.guardarInsertar(inv);
				}
			}
			dtProductoDetalle.close();
			return true;
		}else if(tipoMovInventario == TiposMovInventario.CANCELAR_PEDIDO_X_SURTIR){
			ISetDatos dtProductoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
			while (dtProductoDetalle.moveToNext()){
				com.amesol.routelite.datos.InventarioLotes inv = new com.amesol.routelite.datos.InventarioLotes();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.TipoUnidad = (short)tipoUnidad;
				inv.Lote = lote;
				float cantidadxFactor = cantidad; //* dtProductoDetalle.getFloat("Factor");
				BDVend.recuperar(inv);
				
				if(dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave)){
					float pedido = inv.Pedido - cantidadxFactor;
					if(pedido <= 0)
						pedido = 0;
					//inv.Pedido = inv.Pedido - cantidadxFactor;
					if(pedido <= (inv.Disponible - inv.Contenido)){
						inv.Apartado = pedido; //inv.Pedido - cantidadxFactor;
					}else{
						inv.Apartado = inv.Disponible - inv.Contenido;
					}
					inv.Pedido = pedido;
					inv.MFechaHora = Generales.getFechaHoraActual();
					inv.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
					BDVend.guardarInsertar(inv);
				}
			}
			dtProductoDetalle.close();
			return true;
		}else if(tipoMovInventario == TiposMovInventario.CANCELAR_VENTA_REPARTO){
			ISetDatos dtProductoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
			while (dtProductoDetalle.moveToNext()){
				com.amesol.routelite.datos.InventarioLotes inv = new com.amesol.routelite.datos.InventarioLotes();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.TipoUnidad = (short)tipoUnidad;
				inv.Lote = lote;
				float cantidadxFactor = cantidad; //* dtProductoDetalle.getFloat("Factor");
				BDVend.recuperar(inv);
				
				if(dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave)){
					if(cantidadxFactor - prestamoVendido > 0){
                        if((inv.Pedido - inv.Apartado) >= (cantidadxFactor - prestamoVendido)){
                            inv.Disponible += (cantidadxFactor - prestamoVendido);
                            inv.Apartado += (cantidadxFactor - prestamoVendido);
                        }else{
                            inv.Disponible += (cantidadxFactor - prestamoVendido);
                            inv.Apartado += (inv.Pedido - inv.Apartado);
                        }
					}
				}else{
					if(inv.Pedido - inv.Apartado >= cantidadxFactor){
						inv.Contenido += cantidadxFactor;
						inv.Disponible += cantidadxFactor;
						inv.Apartado += cantidadxFactor;
					}else{
						inv.Contenido += cantidadxFactor;
						inv.Disponible += cantidadxFactor;
						inv.Apartado += (inv.Pedido - inv.Apartado);
					}
				}
				inv.MFechaHora = Generales.getFechaHoraActual();
				inv.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				BDVend.guardarInsertar(inv);
			}
			dtProductoDetalle.close();
			return true;
		}

		return false;
	}	
	

}
