package com.duxstar.dacza.actividades;

import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.utilerias.Generales;

import java.util.concurrent.atomic.AtomicReference;

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

	public static boolean ValidarExistencia(String articuloId, Float cantidad, AtomicReference<Float> refExistencia, final StringBuilder error)throws Exception
	{
        refExistencia.set(Consultas.ConsultasInventario.obtenerExistencia(articuloId));
        return ValidarExistenciaDisponible(articuloId, cantidad, refExistencia.get(), error);

	}

    public static boolean ValidarExistencia(String articuloId, Float cantidad, Float cantidadAnterior, AtomicReference<Float> refExistencia, final StringBuilder error)throws Exception
    {
        float cantidadVal = cantidad - cantidadAnterior;
        if (cantidadVal <= 0)
        {
            return true;
        }
        refExistencia.set(Consultas.ConsultasInventario.obtenerExistencia(articuloId));
        if (refExistencia.get() != null ) //&& refExistencia.get() > 0)
        {
            return ValidarExistenciaDisponible(articuloId, cantidadVal, refExistencia.get(), error);
        }

        return false;
    }

	// En caso de que ya se tenga la existencia
	private static boolean ValidarExistenciaDisponible(String ArticuloId, Float Cantidad, Float Existencia, final StringBuilder Error)throws Exception
	{
		if (Cantidad <= Existencia)
		{
			return true;
		}
		else
		{
            Articulo articulo = new Articulo();
            articulo.ArticuloId = ArticuloId;
            BDTerm.recuperar(articulo);
			Error.append("No hay existencia suficiente del Producto " + articulo.Clave);
		}

		return false;
	}
	
	public static boolean ActualizarInventario(String articuloId, float cantidad, int tipoMovimiento) throws Exception
	{
        com.duxstar.dacza.datos.Inventario inv = new com.duxstar.dacza.datos.Inventario();
        inv.ArticuloId = articuloId;
        BDTerm.recuperar(inv);

		if (tipoMovimiento == Enumeradores.TiposMovimientoInv.ENTRADA)
		{
            if (inv.isRecuperado())
			{
                inv.Existencia += cantidad;
			}
			else
			{
				inv.Existencia = cantidad;
                inv.Apartado = 0;
			}

            inv.MFechaHora = Generales.getFechaHoraActual();
			inv.MUsuarioId = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).UsuarioId;
            inv.Enviado = false;
			BDTerm.guardarInsertar(inv);
			return true;
		}
		else if (tipoMovimiento == Enumeradores.TiposMovimientoInv.SALIDA)
		{
			if (inv.isRecuperado())
            {
                inv.Existencia -= cantidad;
                inv.MFechaHora = Generales.getFechaHoraActual();
                inv.MUsuarioId = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).UsuarioId;
                inv.Enviado = false;
                BDTerm.guardarInsertar(inv);
                return true;
            }
            else
            {
                return false;
            }
		}
        else if (tipoMovimiento == Enumeradores.TiposMovimientoInv.SALIDA_APARTADO)
		{
            if (inv.isRecuperado())
            {
                inv.Apartado += cantidad;
                inv.MFechaHora = Generales.getFechaHoraActual();
                inv.MUsuarioId = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).UsuarioId;
                inv.Enviado = false;
                BDTerm.guardarInsertar(inv);
                return true;
            }
            else
            {
                return false;
            }
		}
        else if (tipoMovimiento == Enumeradores.TiposMovimientoInv.ENTRADA_APARTADO)
		{
            if (inv.isRecuperado())
            {
                inv.Apartado -= cantidad;
                inv.MFechaHora = Generales.getFechaHoraActual();
                inv.MUsuarioId = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).UsuarioId;
                inv.Enviado = false;
                BDTerm.guardarInsertar(inv);
                return true;
            }
            else
            {
                return false;
            }
		}

		return false;
	}	
	

}
