package com.amesol.routelite.actividades;

import java.util.Date;
import java.util.HashMap;
import java.util.concurrent.atomic.AtomicReference;

import com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos;
import com.amesol.routelite.datos.Producto;
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

public class Inventario
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

	public static boolean ValidarExistencia(String productoClave, int tipoUnidad, Float cantidad, short tipoTransProd, String grupoMotivo, AtomicReference<Float> refExistencia, final StringBuilder error)
	{

		if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
		{
			return true;
		}
		if (grupoMotivo.equals("VENTA"))
		{
			return ValidarExistenciaDisponible(productoClave, tipoUnidad, cantidad, tipoTransProd, refExistencia, error);
		}
		else
		{
			return ValidarExistenciaNoDisponible(productoClave, tipoUnidad, cantidad, refExistencia, error);
		}
	}

	public static boolean ValidarExistencia(String productoClave, int tipoUnidad, Float cantidad, short tipoMovimiento, short tipoTransProd, AtomicReference<Float> refExistencia, HashMap<String, com.amesol.routelite.datos.Inventario> hmInventario, final StringBuilder error)
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
					return ValidarExistenciaDisponible(productoClave, cantidad, refExistencia.get(), error);
				}
				else
				{
					return ValidarExistenciaDisponible(productoClave, tipoUnidad, cantidad, tipoTransProd, hmInventario, refExistencia, error);
				}
			}
		}
		return false;
	}

	public static boolean ValidarExistencia(String productoClave, int tipoUnidad, Float cantidad, Float cantidadAnterior, short tipoMovimiento, short tipoTransProd, boolean cancelacion, AtomicReference<Float> refExistencia, final StringBuilder error)
	{
		if ((tipoMovimiento == TiposMovimientos.ENTRADA) || ((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA && !((Ruta) Sesion.get(Campo.RutaActual)).Inventario) && tipoTransProd == TiposTransProd.PEDIDO))
		{

			if (tipoTransProd == TiposTransProd.CARGAS)
			{
				if (cantidadAnterior == 0)
					if (cancelacion)
						return ValidarExistenciaDisponible(productoClave, tipoUnidad, cantidad, tipoTransProd, refExistencia, error);
					else
						return true;
				else
				{
					float cantidadVal = cantidadAnterior - cantidad;
					if (cantidad >= cantidadAnterior)
					{
						return true;
					}
					return ValidarExistenciaDisponible(productoClave, tipoUnidad, cantidadVal, tipoTransProd, refExistencia, error);
				}
			}
			else
				return true;

		}
		else
		{
			if (tipoTransProd == TiposTransProd.PEDIDO || tipoTransProd == TiposTransProd.AJUSTES || tipoTransProd == TiposTransProd.DESCARGAS || tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES || tipoTransProd == TiposTransProd.CAMBIOS || tipoTransProd == TiposTransProd.CARGAS)
			{
				float cantidadVal = cantidad - cantidadAnterior;
				if (cantidadVal <= 0)
				{
					return true;
				}
				if (refExistencia.get() != null && refExistencia.get() > 0)
				{
					return ValidarExistenciaDisponible(productoClave, cantidadVal, refExistencia.get(), error);
				}
				else
				{
					return ValidarExistenciaDisponible(productoClave, tipoUnidad, cantidadVal, tipoTransProd, refExistencia, error);
				}
			}
		}
		return false;
	}

	public static boolean ValidarExistencia(String productoClave, int tipoUnidad, Float cantidad, com.amesol.routelite.datos.ModuloMovDetalle moduloMovDetalle, AtomicReference<Float> refExistencia, final StringBuilder error)
	{
		return ValidarExistencia(productoClave, tipoUnidad, cantidad, Float.valueOf(0), moduloMovDetalle, false, refExistencia, error);
	}

	public static boolean ValidarExistencia(String productoClave, int tipoUnidad, Float cantidad, short tipoMovimiento, short tipoTransProd, AtomicReference<Float> refExistencia, final StringBuilder error)
	{
		return ValidarExistencia(productoClave, tipoUnidad, cantidad, Float.valueOf(0), tipoMovimiento, tipoTransProd, false, refExistencia, error);
	}

	public static boolean ValidarExistencia(String productoClave, int tipoUnidad, Float cantidad, Float cantidadAnterior, com.amesol.routelite.datos.ModuloMovDetalle moduloMovDetalle, boolean cancelacion, AtomicReference<Float> refExistencia, final StringBuilder error)
	{
		return ValidarExistencia(productoClave, tipoUnidad, cantidad, cantidadAnterior, moduloMovDetalle.TipoMovimiento, moduloMovDetalle.TipoTransProd, cancelacion, refExistencia, error);
	}

	// En caso de que ya se tenga la existencia
	private static boolean ValidarExistenciaDisponible(String ProductoClave, Float Cantidad, Float Existencia, final StringBuilder Error)
	{
		if (Cantidad <= Existencia)
		{
			return true;
		}
		else
		{
			Error.append(Mensajes.get("E0714", ProductoClave));
		}

		return false;
	}

	private static boolean ValidarExistenciaDisponible(String productoClave, int tipoUnidad, Float cantidad, short tipoTransProd, HashMap<String, com.amesol.routelite.datos.Inventario> hmInventario, AtomicReference<Float> refExistencia, final StringBuilder error)
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
				error.append(Mensajes.get("E0714", productoClave));
				return false;
			}
			ISetDatos productoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
			while (productoDetalle.moveToNext())
			{
				dCantidad = cantidad * productoDetalle.getFloat(productoDetalle.getColumnIndex("Factor"));
				//si el producto no esta en el inventario
				if (!hmInventario.containsKey(productoDetalle.getString("ProductoDetClave")) || hmInventario.get(productoDetalle.getString("ProductoDetClave")) == null || hmInventario.get(productoDetalle.getString("ProductoDetClave")).Disponible <= 0)
				{
					error.append(Mensajes.get("E0714", productoClave));
					return false;
				}
				//Si es el producto Terminado
				if (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))
				{
					dDisponible = hmInventario.get(productoDetalle.getString("ProductoDetClave")).Disponible - hmInventario.get(productoDetalle.getString("ProductoDetClave")).NoDisponible - hmInventario.get(productoDetalle.getString("ProductoDetClave")).Apartado - hmInventario.get(productoDetalle.getString("ProductoDetClave")).Contenido;
					//}
					if (tipoTransProd == Enumeradores.TiposTransProd.CARGAS)
					{
						dDisponible += hmInventario.get(productoDetalle.getString("ProductoDetClave")).Pedido;
						hmInventario.get(productoDetalle.getString("ProductoDetClave")).Apartado -= hmInventario.get(productoDetalle.getString("ProductoDetClave")).Pedido;
					}
				}
				//Si es un producto contenido
				else if (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && !productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))
				{
					if (dCantidad < hmInventario.get(productoDetalle.getString("ProductoDetClave")).Contenido)
					{
						iContenido = 1;
					}
				}

				if ((dCantidad <= dDisponible && (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))) || (iContenido == 1))
				{
					if (productoDetalle.getInt("Factor") == 1)
					{
						refExistencia.set(dDisponible);

					}
					else
					{
						// Se convierte primero a entero para truncarlo.
						refExistencia.set((float) ((int) (dDisponible / productoDetalle.getInt("Factor"))));
					}
					//Si hay disponible y aparto en memoria la cantidad de producto que solicit�
					hmInventario.get(productoDetalle.getString("ProductoDetClave")).Apartado = hmInventario.get(productoDetalle.getString("ProductoDetClave")).Apartado + dCantidad;

					bRes = true;
				}
				else if ((dCantidad > dDisponible && (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))) || (iContenido == 0))
				{
					if (dDisponible > dCantidad)
					{
						if (productoDetalle.getInt("Factor") == 1)
						{
							refExistencia.set(dCantidad);
						}
						else
						{
							// Se convierte primero a entero para truncarlo.
							refExistencia.set((float) ((int) (dCantidad / productoDetalle.getInt("Factor"))));
						}
						//Si hay disponible y aparto en memoria la cantidad de producto que solicit�
						hmInventario.get(productoDetalle.getString("ProductoDetClave")).Apartado = hmInventario.get(productoDetalle.getString("ProductoDetClave")).Apartado + dCantidad;

					}
					else
					{
						if (productoDetalle.getInt("Factor") == 1)
						{
							refExistencia.set(dDisponible);
						}
						else
						{
							// Se convierte primero a entero para truncarlo.
							refExistencia.set((float) ((int) (dDisponible / productoDetalle.getInt("Factor"))));
						}
						//En este caso aparto todo lo que queda disponible del producto que solicit�
						hmInventario.get(productoDetalle.getString("ProductoDetClave")).Apartado = hmInventario.get(productoDetalle.getString("ProductoDetClave")).Apartado + dDisponible;
					}

					error.append(Mensajes.get("E0714", productoClave));
					return false;
				}
			}
			if (dDisponible <= 0 && cantidad > 0)
			{
				error.append(Mensajes.get("E0714", productoClave));
				return false;
			}
			else
			{
				if (!bRes)
				{
					error.append(Mensajes.get("E0714", productoClave));
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

	private static boolean ValidarExistenciaDisponible(String productoClave, int tipoUnidad, Float cantidad, int tipoTransProd, AtomicReference<Float> refExistencia, final StringBuilder error)
	{

		if (cantidad == 0)
			return true;

		float dDisponible = 0;
		float dCantidad = 0;
		float iContenido = 0;
		boolean bRes = false;

		try
		{
			ISetDatos productoDetalle = Consultas.ConsultasInventario.obtenerProductoInventario(productoClave, tipoUnidad);
			while (productoDetalle.moveToNext())
			{
				dCantidad = cantidad * productoDetalle.getFloat(productoDetalle.getColumnIndex("Factor"));
				if (productoDetalle.isNull(productoDetalle.getColumnIndex("Disponible")) || productoDetalle.getFloat("Disponible") <= 0)
				{
					error.append(Mensajes.get("E0714", productoClave));
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
				}
				else if (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && !productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))
				{
					if (dCantidad < productoDetalle.getFloat("Contenido"))
					{
						iContenido = 1;
					}
				}

				if ((dCantidad <= dDisponible && (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))) || (iContenido == 1))
				{
					if (productoDetalle.getInt("Factor") == 1)
					{
						refExistencia.set(dDisponible);

					}
					else
					{
						// Se convierte primero a entero para truncarlo.
						refExistencia.set((float) ((int) (dDisponible / productoDetalle.getInt("Factor"))));
					}
					bRes = true;
				}
				else if ((dCantidad > dDisponible && (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave))) || (iContenido == 0))
				{
					if (dDisponible > dCantidad)
					{
						if (productoDetalle.getInt("Factor") == 1)
						{
							refExistencia.set(dCantidad);
						}
						else
						{
							// Se convierte primero a entero para truncarlo.
							refExistencia.set((float) ((int) (dCantidad / productoDetalle.getInt("Factor"))));
						}
					}
					else
					{
						if (productoDetalle.getInt("Factor") == 1)
						{
							refExistencia.set(dDisponible);
						}
						else
						{
							// Se convierte primero a entero para truncarlo.
							refExistencia.set((float) ((int) (dDisponible / productoDetalle.getInt("Factor"))));
						}
					}
					error.append(Mensajes.get("E0714", productoClave));
					return false;
				}
			}
			if (dDisponible <= 0 && cantidad > 0)
			{
				error.append(Mensajes.get("E0714", productoClave));
				return false;
			}
			else
			{
				if (!bRes)
					error.append(Mensajes.get("E0714", productoClave));
				return bRes;
			}
		}
		catch (Exception ex)
		{
			error.append(ex.getMessage());
			return false;
		}
	}

	private static boolean ValidarExistenciaNoDisponible(String productoClave, int tipoUnidad, Float cantidad, AtomicReference<Float> refExistencia, final StringBuilder error)
	{
		if (cantidad == 0)
			return true;

		float dCantidad = 0;

		try
		{
			ISetDatos productoDetalle = Consultas.ConsultasInventario.obtenerProductoInventario(productoClave, tipoUnidad);
			while (productoDetalle.moveToNext())
			{
				dCantidad = cantidad * productoDetalle.getFloat(productoDetalle.getColumnIndex("Factor"));
				if (productoDetalle.isNull(productoDetalle.getColumnIndex("NoDisponible")) || productoDetalle.getFloat("NoDisponible") <= 0)
				{
					error.append(Mensajes.get("E0714", productoClave));
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
						error.append(Mensajes.get("E0714", productoClave));
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
	
	public static boolean ValidarExistenciaDifNoDisponible(String productoClave, int tipoUnidad, Float cantidad, AtomicReference<Float> refExistencia, final StringBuilder error)
	{
		float dCantidad = 0;
		float dDisponible = 0;

		try
		{
			ISetDatos productoDetalle = Consultas.ConsultasInventario.obtenerProductoInventario(productoClave, tipoUnidad);
			ISetDatos productoPedido = Consultas.ConsultasInventario.obtenerInventarioPedido(productoClave, tipoUnidad, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID);
			while (productoDetalle.moveToNext())
			{
				dCantidad = cantidad * productoDetalle.getFloat(productoDetalle.getColumnIndex("Factor"));
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
					if(productoDetalle.getFloat("Factor") == 1){
						refExistencia.set(dDisponible / productoDetalle.getFloat("Factor"));
					}else{
						refExistencia.set((float) ((int) (dDisponible / productoDetalle.getInt("Factor"))));
					}
					productoDetalle.close();
					productoDetalle = null;
					productoPedido.close();
					productoPedido = null;
					return true;
				}else if(Generales.getRound(dCantidad, 4) > Generales.getRound(dDisponible, 4) && (productoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && productoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave) ||contenido == 0)){
					if(dDisponible > dCantidad){
						if(productoDetalle.getFloat("Factor") == 1){
							refExistencia.set(dCantidad / productoDetalle.getFloat("Factor"));
						}else{
							refExistencia.set((float) ((int) (dCantidad / productoDetalle.getInt("Factor"))));
						}
					}else{
						if(productoDetalle.getFloat("Factor") == 1){
							refExistencia.set(dDisponible / productoDetalle.getFloat("Factor"));
						}else{
							refExistencia.set((float) ((int) (dDisponible / productoDetalle.getInt("Factor"))));
						}
					}
				}

			}
			productoDetalle.close();
			productoDetalle = null;
			productoPedido.close();
			productoPedido = null;
			return false;
		}
		catch (Exception ex)
		{
			error.append(ex.getMessage());
			return false;
		}
	}

	public static boolean CargasFaseTransferir() throws Exception
	{
		ISetDatos dtCargas = Consultas.ConsultasCargas.obtenerDetalleCargasPorTransferir();

		while (dtCargas.moveToNext())
		{
			ActualizarInventario(dtCargas.getString("ProductoClave"), dtCargas.getInt("TipoUnidad"), Generales.getRound(dtCargas.getFloat("Cantidad"), dtCargas.getInt("DecimalProducto")), TiposTransProd.CARGAS, TiposMovimientos.ENTRADA, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID, "", false);
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
		//Si no se usa descargaAutomatica
		if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("DescargaAutomatica").equals("1")) return;
		ISetDatos dtInventarioABordo = Consultas.ConsultasCargas.obtenerDetalleInventarioABordo();

		while (dtInventarioABordo.moveToNext())
		{
			ActualizarInventario(dtInventarioABordo.getString("ProductoClave"), dtInventarioABordo.getInt("TipoUnidad"), Generales.getRound(dtInventarioABordo.getFloat("Cantidad"), dtInventarioABordo.getInt("DecimalProducto")), TiposTransProd.CARGAS, TiposMovimientos.ENTRADA, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID, "", false);
		}

		dtInventarioABordo.close();
		BDVend.commit();
	}
	
	public static void CrearMovimientoAutomatico(int tipoEnvioMovimientosAutomaticos ) throws Exception {
		try{
			Date[] fechas = new Date[2];
			String sTransProdID = "";
			Consultas.ConsultasDia.obtenerRangoAgenda(fechas);
			if (fechas[0] != null && fechas[1] != null){
				sTransProdID = Consultas.ConsultasTransProd.obtenerInventarioABordo(fechas[0], fechas[1]);
			}
			String sDiaClave = "";
			Date fechaCaptura = null;
			ISetDatos dtDiasAgenda = Consultas.ConsultasDia.obtenerDiasAgenda();
			if ((dtDiasAgenda != null) && (dtDiasAgenda.moveToFirst()) && (dtDiasAgenda.getCount() > 0))
			{
				sDiaClave = dtDiasAgenda.getString("DiaClave");
				fechaCaptura =  dtDiasAgenda.getDate("FechaCaptura");
			}
			
			dtDiasAgenda.close();
			
			boolean blnNuevo = false;
			TransProd oTransProd = new TransProd();
			
			if (sTransProdID == ""){
				oTransProd.TransProdID =KeyGen.getId();
				oTransProd.DiaClave = sDiaClave;
				oTransProd.Folio = "0";
				oTransProd.Tipo = TiposTransProd.INVENTARIO_A_BORDO;
				oTransProd.TipoFase = TiposFasesDocto.CAPTURA;
				oTransProd.TipoMovimiento = TiposMovimientos.ENTRADA;
				oTransProd.FechaCaptura = fechaCaptura;
				oTransProd.FechaHoraAlta = Generales.getFechaHoraActual();
				oTransProd.Total = 0;
				oTransProd.Notas = ((Vendedor) Sesion.get(Campo.VendedorActual)).ClaveCEDI;
				oTransProd.MFechaHora = Generales.getFechaHoraActual();
				oTransProd.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				oTransProd.Enviado = false;
				blnNuevo = true;
			}else{
				oTransProd.TransProdID = sTransProdID ;
				BDVend.recuperar(oTransProd);
				oTransProd.MFechaHora = Generales.getFechaHoraActual();
				oTransProd.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				oTransProd.Enviado = false;
				blnNuevo = false;
			}
				
			BDVend.guardarInsertar(oTransProd);
			
			ISetDatos dtInventario = Consultas.ConsultasInventario.obtenerInventario();
			
			if (blnNuevo){
				int iPartida = 1;
				while (dtInventario.moveToNext()){
					if (dtInventario.getFloat("Disponible") >0f){
						TransProdDetalle oTpd = new TransProdDetalle();
						oTpd.TransProdID =oTransProd.TransProdID; 
						oTpd.TransProdDetalleID = KeyGen.getId();
						oTpd.Partida = iPartida;
						oTpd.ProductoClave = dtInventario.getString("ProductoClave");
						oTpd.TipoUnidad = dtInventario.getInt("PRUTipoUnidad");
						oTpd.Cantidad = (dtInventario.getFloat("Disponible")/dtInventario.getInt("Factor"));
						oTpd.Precio = 0;
						oTpd.Subtotal = 0;
						oTpd.Total = 0;
						oTpd.MFechaHora = Generales.getFechaHoraActual();
						oTpd.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
						oTpd.Enviado = false;				
						BDVend.guardarInsertar(oTpd);				
						iPartida += 1;
					}
				}
			}else{
				BDVend.recuperar(oTransProd, TransProdDetalle.class);
				while (dtInventario.moveToNext()){
					Object aTransProdDetalle[] = Consultas.ConsultasTransProdDetalle.obtenerDetallePorProductoClaveUnidad(dtInventario.getString("ProductoClave"), dtInventario.getString("PRUTipoUnidad"), "'" + oTransProd.TransProdID + "'");
					if (aTransProdDetalle == null)
					{ 
						if (dtInventario.getFloat("Disponible") >0f){
							TransProdDetalle oTpd = new TransProdDetalle();
							oTpd.TransProdID =oTransProd.TransProdID; 
							oTpd.TransProdDetalleID = KeyGen.getId();
							oTpd.Partida =  Consultas.ConsultasTransProdDetalle.obtenerPartida(oTransProd.TransProdID) + 1;
							oTpd.ProductoClave = dtInventario.getString("ProductoClave");
							oTpd.TipoUnidad = dtInventario.getInt("PRUTipoUnidad");
							oTpd.Cantidad = (dtInventario.getFloat("Disponible")/dtInventario.getInt("Factor"));
							oTpd.Precio = 0;
							oTpd.Subtotal = 0;
							oTpd.Total = 0;
							oTpd.MFechaHora = Generales.getFechaHoraActual();
							oTpd.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
							oTpd.Enviado = false;				
							BDVend.guardarInsertar(oTpd);		
						}
					}else{
						TransProdDetalle oTpd = oTransProd.getTransProdDetalle(aTransProdDetalle[1].toString());
						oTpd.Cantidad  = (dtInventario.getFloat("Disponible")/dtInventario.getInt("Factor"));
						oTpd.MFechaHora = Generales.getFechaHoraActual();
						oTpd.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
						oTpd.Enviado = false;	
						BDVend.guardarInsertar(oTpd);
					}
				}
			}
			
			dtInventario.close();
			BDVend.commit();
		}catch (Exception ex){
			BDVend.rollback();
			throw ex;
		}
		
	}
	
	public static boolean CargarInventarioPedido() throws Exception
	{
		ISetDatos pedidos = Consultas.ConsultasReparto.obtenerPedidos();
		while(pedidos.moveToNext()){
			ActualizarInventario(pedidos.getString("ProductoClave"), pedidos.getInt("TipoUnidad"), pedidos.getFloat("Cantidad"), pedidos.getInt("Tipo"), TiposMovimientos.PEDIDO, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID);
		}
		pedidos.close();
		pedidos = null;
		BDVend.commit();
		return true;
	}

	public static boolean ActualizarInventario(String productoClave, int tipoUnidad, float cantidad, int tipoTransProd, int tipoMovimiento, String almacenID) throws Exception
	{
		return ActualizarInventario(productoClave, tipoUnidad, cantidad, tipoTransProd, tipoMovimiento, almacenID, "", false);
	}

	public static boolean ActualizarInventario(String productoClave, int tipoUnidad, float cantidad, int tipoTransProd, int tipoMovimiento, String almacenID, boolean cancelar) throws Exception
	{
		return ActualizarInventario(productoClave, tipoUnidad, cantidad, tipoTransProd, tipoMovimiento, almacenID, "", cancelar);
	}

	public static boolean ActualizarInventario(String productoClave, int tipoUnidad, float cantidad, int tipoTransProd, int tipoMovimiento, String almacenID, String grupoMotivo, boolean cancelacion) throws Exception
	{
		return ActualizarInventario(productoClave, tipoUnidad, cantidad, tipoTransProd, tipoMovimiento, almacenID, grupoMotivo, cancelacion, "", 0, false);
	}
	
	public static boolean ActualizarInventario(String productoClave, int tipoUnidad, float cantidad, int tipoTransProd, int tipoMovimiento, String almacenID, String grupoMotivo, boolean cancelacion, String clienteClave, float prestamoVendido, boolean surtirPedido) throws Exception
	{
		int tipoMovInventario = TiposMovInventario.NO_DEFINIDO;
		if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO && tipoTransProd == TiposTransProd.CARGAS))
		{
			if (tipoMovimiento == TiposMovimientos.ENTRADA)
			{
				if (!cancelacion && tipoTransProd == TiposTransProd.CARGAS)
					tipoMovInventario = TiposMovInventario.ENTRADA_DISPONIBLE;
				else if (cancelacion && tipoTransProd == TiposTransProd.CARGAS)

					tipoMovInventario = TiposMovInventario.SALIDA_DISPONIBLE;
				else if (tipoTransProd == TiposTransProd.CAMBIOS || tipoTransProd == TiposTransProd.DEVOLUCIONES_CLIENTE)
				{
					if (!cancelacion)
					{
						if (grupoMotivo.equalsIgnoreCase("Venta"))
							tipoMovInventario = TiposMovInventario.ENTRADA_DISPONIBLE;
						else
							tipoMovInventario = TiposMovInventario.ENTRADA_NODISPONIBLE;
					}
					else
					{
						if (grupoMotivo.equalsIgnoreCase("Venta"))
							tipoMovInventario = TiposMovInventario.SALIDA_DISPONIBLE;
						else
							tipoMovInventario = TiposMovInventario.SALIDA_NODISPONIBLE;
					}

				}

			}
			else if (tipoMovimiento == TiposMovimientos.SALIDA)
			{
				if (!cancelacion && (tipoTransProd == TiposTransProd.PEDIDO || tipoTransProd == TiposTransProd.CAMBIOS || tipoTransProd == TiposTransProd.AJUSTES || tipoTransProd == TiposTransProd.DESCARGAS))
					tipoMovInventario = TiposMovInventario.SALIDA_DISPONIBLE;
				else if (cancelacion && (tipoTransProd == TiposTransProd.PEDIDO || tipoTransProd == TiposTransProd.CAMBIOS || tipoTransProd == TiposTransProd.AJUSTES || tipoTransProd == TiposTransProd.DESCARGAS))
					tipoMovInventario = TiposMovInventario.ENTRADA_DISPONIBLE;
				else if (tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES)
				{
					if (!cancelacion)
						tipoMovInventario = TiposMovInventario.SALIDA_NODISPONIBLE;
					else
						tipoMovInventario = TiposMovInventario.ENTRADA_NODISPONIBLE;
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
				com.amesol.routelite.datos.Inventario inv = new com.amesol.routelite.datos.Inventario();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;
				cantidadxFactor = cantidad * dtProductoDetalle.getFloat("Factor");
				BDVend.recuperar(inv);

				if (inv.isRecuperado())
				{
					if (dtProductoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave.toUpperCase()))
					{
						inv.Disponible = inv.Disponible + cantidadxFactor;
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
			return true;
		}
		else if (tipoMovInventario == TiposMovInventario.ENTRADA_NODISPONIBLE)
		{
			ISetDatos dtProductoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
			float cantidadxFactor = 0;

			while (dtProductoDetalle.moveToNext())
			{
				com.amesol.routelite.datos.Inventario inv = new com.amesol.routelite.datos.Inventario();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;
				cantidadxFactor = cantidad * dtProductoDetalle.getFloat("Factor");
				BDVend.recuperar(inv);

				if (inv.isRecuperado())
				{
					if (dtProductoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave.toUpperCase()))
					{
						if (tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES)
							inv.NoDisponible = inv.NoDisponible + cantidadxFactor;
						else
						{
							inv.Disponible = inv.Disponible + cantidadxFactor;
							inv.NoDisponible = inv.NoDisponible + cantidadxFactor;
						}
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
				com.amesol.routelite.datos.Inventario inv = new com.amesol.routelite.datos.Inventario();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;
				cantidadxFactor = cantidad * dtProductoDetalle.getFloat("Factor");

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
				com.amesol.routelite.datos.Inventario inv = new com.amesol.routelite.datos.Inventario();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;
				cantidadxFactor = cantidad * dtProductoDetalle.getFloat("Factor");

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
				com.amesol.routelite.datos.Inventario inv = new com.amesol.routelite.datos.Inventario();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;
				cantidadxFactor = cantidad * dtProductoDetalle.getFloat("Factor");

				BDVend.recuperar(inv);

				if (inv.isRecuperado())
				{
					if (dtProductoDetalle.getString("ProductoClave").equalsIgnoreCase(productoClave) && dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave.toUpperCase()))
					{
						if (tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES)
							inv.NoDisponible = inv.NoDisponible - cantidadxFactor;
						else
						{
							inv.Disponible = inv.Disponible - cantidadxFactor;
							inv.NoDisponible = inv.NoDisponible - cantidadxFactor;
						}
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
				com.amesol.routelite.datos.Inventario inv = new com.amesol.routelite.datos.Inventario();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;
				cantidadxFactor = cantidad * dtProductoDetalle.getFloat("Factor");

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
				com.amesol.routelite.datos.Inventario inv = new com.amesol.routelite.datos.Inventario();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;
				float cantidadxFactor = cantidad * dtProductoDetalle.getFloat("Factor");
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
				com.amesol.routelite.datos.Inventario inv = new com.amesol.routelite.datos.Inventario();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;
				cantidadxFactor = cantidad * dtProductoDetalle.getFloat("Factor");
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
				com.amesol.routelite.datos.Inventario inv = new com.amesol.routelite.datos.Inventario();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;
				cantidadxFactor = cantidad * dtProductoDetalle.getFloat("Factor");
				BDVend.recuperar(inv);
				
				AtomicReference<Float> existencia = new AtomicReference<Float>();
				StringBuilder error = new StringBuilder();
				ValidarExistenciaDisponible(productoClave, tipoUnidad, cantidad, tipoTransProd, existencia, error);
				
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
				com.amesol.routelite.datos.Inventario inv = new com.amesol.routelite.datos.Inventario();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;
				float cantidadxFactor = cantidad * dtProductoDetalle.getFloat("Factor");
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
				com.amesol.routelite.datos.Inventario inv = new com.amesol.routelite.datos.Inventario();
				inv.ProductoClave = dtProductoDetalle.getString("ProductoDetClave");
				inv.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;
				float cantidadxFactor = cantidad * dtProductoDetalle.getFloat("Factor");
				BDVend.recuperar(inv);
				
				if(dtProductoDetalle.getString("ProductoDetClave").equalsIgnoreCase(productoClave)){
					if(cantidadxFactor - prestamoVendido > 0){
						if(inv.Pedido - inv.Apartado >= cantidadxFactor){
							inv.Disponible += (cantidadxFactor - prestamoVendido);
							inv.Apartado += (cantidadxFactor - prestamoVendido);
						}else{
							inv.Disponible += (cantidadxFactor - prestamoVendido);
							inv.Apartado += (inv.Pedido - inv.Apartado) - prestamoVendido;
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
