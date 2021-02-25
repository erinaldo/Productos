package com.amesol.routelite.actividades;

import com.amesol.routelite.controles.CapturaProducto;
import com.amesol.routelite.datos.*;
import com.amesol.routelite.datos.ValorReferencia;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

import java.util.Date;
import java.util.HashMap;
import java.util.concurrent.atomic.AtomicReference;

/*Esta clase se utiliza cuando se maneja la doble unidad, ya que no hay una conversion
 *entre unidades para el inventario, es decir, la unidad que se maneja para el inventario
 * puede ser independiente a la que tiene el precio, y tener un factor, pero solo es una
 * la que lo afecta, por lo tanto se excluye la multiplicacion por el factor.
 * */

public class InventarioDobleUnidad {
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

    public final class TiposInventario
    {
        public final static int NO_DEFINIDO = 0;
        public final static int DISPONIBLE = 1;
        public final static int NODISPONIBLE= 2;
    }


    public static class DetalleProductoDobleUnidad{
        public Short PRUTipoUnidad;
        public Float KgLts;
        public Float Cantidad;
        public Float CantidadOriginal;
        public Short TipoEstado;
        public Short DecimalProducto;
        public Float PorcentajeVariacion;

        public DetalleProductoDobleUnidad(Short pPRUTipoUnidad, Float pKgLts, Float pCantidad, Float pCantidadOriginal, Short pTipoEstado, Short pDecimalProducto, Float pPorcentajeVariacion){
            PRUTipoUnidad = pPRUTipoUnidad;
            KgLts= pKgLts;
            Cantidad = pCantidad;
            CantidadOriginal = pCantidadOriginal;
            TipoEstado = pTipoEstado;
            DecimalProducto = pDecimalProducto;
            PorcentajeVariacion = pPorcentajeVariacion;
        }

    }
    /***********************/

    public static boolean ValidarExistencia(String productoClave, short tipoUnidad, Float cantidad, short tipoTransProd, String grupoMotivo, AtomicReference<Float> refExistencia, final StringBuilder error)
    {

        if (Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
        {
            return true;
        }
        if (grupoMotivo.equalsIgnoreCase("Venta"))
        {
            return ValidarExistenciaDisponible(productoClave, tipoUnidad, cantidad, tipoTransProd, refExistencia, error);
        }
        else
        {
            return ValidarExistenciaNoDisponible(productoClave, tipoUnidad, cantidad, refExistencia, error);
        }
    }

    //No se utiliza el pedido sugerido con la doble unidad
   /* public static boolean ValidarExistencia(String productoClave, int tipoUnidad, Float cantidad, short tipoMovimiento, short tipoTransProd, AtomicReference<Float> refExistencia, HashMap<String, com.amesol.routelite.datos.InventarioUnidadesAlternas> hmInventario, final StringBuilder error)
    {
        if ((tipoMovimiento == Enumeradores.TiposMovimientos.ENTRADA) || ((Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA && !((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Inventario) && tipoTransProd == Enumeradores.TiposTransProd.PEDIDO))
        {
            return true;
        }
        else
        {
            if (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO)
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
    }*/

    public static boolean ValidarExistencia(String productoClave, short tipoUnidad, Float cantidad, Float cantidadAnterior, short tipoMovimiento, short tipoTransProd, boolean cancelacion, AtomicReference<Float> refExistencia, final StringBuilder error)
    {
        if ((tipoMovimiento == Enumeradores.TiposMovimientos.ENTRADA) || ((Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA && !((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Inventario) && tipoTransProd == Enumeradores.TiposTransProd.PEDIDO))
        {

            if (tipoTransProd == Enumeradores.TiposTransProd.CARGAS)
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
            if (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO || tipoTransProd == Enumeradores.TiposTransProd.AJUSTES || tipoTransProd == Enumeradores.TiposTransProd.DESCARGAS || tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES || tipoTransProd == Enumeradores.TiposTransProd.CAMBIOS || tipoTransProd == Enumeradores.TiposTransProd.CARGAS || tipoTransProd == Enumeradores.TiposTransProd.VENTA_CONSIGNACION)
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
                {//revisado
                    return ValidarExistenciaDisponible(productoClave, tipoUnidad, cantidadVal, tipoTransProd, refExistencia, error);
                }
            }
        }
        return false;
    }

    public static boolean ValidarExistencia(String productoClave, short tipoUnidad, Float cantidad, com.amesol.routelite.datos.ModuloMovDetalle moduloMovDetalle, AtomicReference<Float> refExistencia, final StringBuilder error)
    {
        return ValidarExistencia(productoClave, tipoUnidad, cantidad, Float.valueOf(0), moduloMovDetalle, false, refExistencia, error);
    }

    public static boolean ValidarExistencia(String productoClave, short tipoUnidad, Float cantidad, short tipoMovimiento, short tipoTransProd, AtomicReference<Float> refExistencia, final StringBuilder error)
    {
        return ValidarExistencia(productoClave, tipoUnidad, cantidad, Float.valueOf(0), tipoMovimiento, tipoTransProd, false, refExistencia, error);
    }

    public static boolean ValidarExistencia(String productoClave, short tipoUnidad, Float cantidad, Float cantidadAnterior, com.amesol.routelite.datos.ModuloMovDetalle moduloMovDetalle, boolean cancelacion, AtomicReference<Float> refExistencia, final StringBuilder error)
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

   /* private static boolean ValidarExistenciaDisponible(String productoClave, int tipoUnidad, Float cantidad, short tipoTransProd, HashMap<String, com.amesol.routelite.datos.InventarioUnidadesAlternas> hmInventario, AtomicReference<Float> refExistencia, final StringBuilder error)
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
            //ISetDatos productoDetalle = Consultas.ConsultasProducto.obtenerProductoDetalle(productoClave, tipoUnidad);
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
                    //Si hay disponible y aparto en memoria la cantidad de producto que solicité
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
                        //Si hay disponible y aparto en memoria la cantidad de producto que solicité
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
                        //En este caso aparto todo lo que queda disponible del producto que solicité
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
    }*/

    //Modificado - Revisado
    private static boolean ValidarExistenciaDisponible(String productoClave, short tipoUnidad, Float cantidad, int tipoTransProd, AtomicReference<Float> refExistencia, final StringBuilder error)
    {

        if (cantidad == 0)
            return true;

        float dDisponible = 0;
        boolean bRes = false;

        try
        {
            InventarioUnidadesAlternas inv = new InventarioUnidadesAlternas();
            inv.ProductoClave = productoClave;
            inv.PRUTipoUnidad = tipoUnidad;
            BDVend.recuperar(inv);

            Producto producto = new Producto();
            producto.ProductoClave = productoClave;
            BDVend.recuperar(producto);

            if (inv.isRecuperado() && producto.isRecuperado())
            {
                if (inv.Disponible <= 0)
                {
                    error.append(Mensajes.get("E0714", productoClave + ": " + ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad))));
                    return false;
                }


                //Problemas con los redondeos
                ProductoUnidad pru = new ProductoUnidad();
                pru.ProductoClave = productoClave;
                pru.PRUTipoUnidad = tipoUnidad;
                BDVend.recuperar(pru);

                if (!producto.Contenido)
                {
                    dDisponible = Generales.getRound(inv.Disponible - inv.NoDisponible - inv.Apartado,  Short.parseShort(String.valueOf(pru.DecimalProducto))) ;
                }
                else
                {
                    dDisponible =  Generales.getRound(inv.Disponible - inv.NoDisponible - inv.Apartado - inv.Contenido, Short.parseShort(String.valueOf(pru.DecimalProducto))) ;
                }

                if (tipoTransProd == Enumeradores.TiposTransProd.CARGAS)
                {
                    dDisponible += inv.Pedido;
                }
                if (tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES)
                {
                    dDisponible = inv.NoDisponible;
                }


                if ((cantidad <= dDisponible ))
                {
                    refExistencia.set(dDisponible);
                    bRes = true;
                }
                else if (cantidad > dDisponible )
                {
                    refExistencia.set(dDisponible);
                    error.append(Mensajes.get("E0714", productoClave + ": " + ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad))));
                    return false;
                }
            }
            if (dDisponible <= 0 && cantidad > 0)
            {
                error.append(Mensajes.get("E0714", productoClave + ": " + ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad))));
                return false;
            }
            else
            {
                if (!bRes)
                    error.append(Mensajes.get("E0714", productoClave+ ": " + ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(tipoUnidad))));
                return bRes;
            }
        }
        catch (Exception ex)
        {
            error.append(ex.getMessage() + " ");
            return false;
        }
    }

    private static boolean ValidarExistenciaNoDisponible(String productoClave, Short tipoUnidad, Float cantidad, AtomicReference<Float> refExistencia, final StringBuilder error)
    {
        if (cantidad == 0)
            return true;
        try
        {
            InventarioUnidadesAlternas inv = new InventarioUnidadesAlternas();
            inv.ProductoClave = productoClave;
            inv.PRUTipoUnidad = tipoUnidad;
            BDVend.recuperar(inv);

            Producto producto = new Producto();
            producto.ProductoClave = productoClave;
            BDVend.recuperar(producto);

            if (inv.isRecuperado() && producto.isRecuperado())
            {
                if (inv.NoDisponible <=0)
                {
                    error.append(Mensajes.get("E0714", productoClave));
                    return false;
                }

                if (cantidad <= inv.NoDisponible)
                {
                    return true;
                }
                else
                {
                    refExistencia.set(inv.NoDisponible);
                    error.append(Mensajes.get("E0714", productoClave));
                    return false;
                }
            }
            return false;
        }
        catch (Exception ex)
        {
            error.append(ex.getMessage());
            return false;
        }
    }

    public static boolean ValidarExistenciaDifNoDisponible(String productoClave, Short tipoUnidad, Float cantidad, AtomicReference<Float> refExistencia, final StringBuilder error)
    {
        //float dCantidad = 0;
        float dDisponible = 0;
        boolean res = false;
        try
        {
            InventarioUnidadesAlternas inv = new InventarioUnidadesAlternas();
            inv.ProductoClave = productoClave;
            inv.PRUTipoUnidad = tipoUnidad;
            BDVend.recuperar(inv);

            Producto producto = new Producto();
            producto.ProductoClave = productoClave;
            BDVend.recuperar(producto);
            if (inv.isRecuperado() && producto.isRecuperado())
            {
                float diferenciaApartado = 0;

                //Se quita esto porque al restarlo provoca que nunca puedas surtir ningun pedido
                /*if(inv.Pedido > 0){
                    diferenciaApartado = inv.Pedido - cantidad;
                }*/

                dDisponible = inv.Disponible - inv.NoDisponible - inv.Contenido - diferenciaApartado;

                 if(Generales.getRound(cantidad, 4) > Generales.getRound(dDisponible, 4) ){
                     refExistencia.set(dDisponible);
                     res = false;
                }else{
                     refExistencia.set(dDisponible);
                     return true;
                 }

            }

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
        if (Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA ){
            //Si es preventa no aplica
            return true;
        }

        ISetDatos dtCargas = Consultas.ConsultasCargas.obtenerDetalleCargasDUPorTransferir();

        while (dtCargas.moveToNext())
        {
            HashMap<Short, DetalleProductoDobleUnidad> hmUnidadCantidad = new HashMap<Short, DetalleProductoDobleUnidad>();
            //Short pPRUTipoUnidad, Float pKgLts, Float pCantidad, Float pCantidadOriginal, Short pTipoEstado, Short pDecimalProducto
            hmUnidadCantidad.put(dtCargas.getShort("TipoUnidad"), new DetalleProductoDobleUnidad(dtCargas.getShort("TipoUnidad"),null, Generales.getRound(dtCargas.getFloat("Cantidad"), dtCargas.getShort("DecimalProducto")),null, null, dtCargas.getShort("DecimalProducto"),null) );
            if (dtCargas.getShort("UnidadAlterna") >0 && dtCargas.getFloat("CantidadAlterna") >0 ){
                hmUnidadCantidad.put(dtCargas.getShort("UnidadAlterna"),new DetalleProductoDobleUnidad(dtCargas.getShort("UnidadAlterna"),null, Generales.getRound(dtCargas.getFloat("CantidadAlterna"), dtCargas.getShort("DecimalProductoAlterna")),null, null, dtCargas.getShort("DecimalProductoAlterna"), null));
            }

            ActualizarInventario(dtCargas.getString("ProductoClave"), hmUnidadCantidad, Enumeradores.TiposTransProd.CARGAS, Enumeradores.TiposMovimientos.ENTRADA);
        }

        if (dtCargas.getCount() > 0)
        {
            Consultas.ConsultasCargas.actualizarFaseTransferirACaptura();
        }

        dtCargas.close();
        BDVend.commit();
        return true;
    }

    /*public static void CargarInventarioABordo() throws Exception
    {
        if (Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA ){
            //Si es preventa no aplica
            return;
        }
        //Si no se usa descargaAutomatica
        if (((MOTConfiguracion)Sesion.get(Sesion.Campo.MOTConfiguracion)).get("DescargaAutomatica").equals("1")) return;
        ISetDatos dtInventarioABordo = Consultas.ConsultasCargas.obtenerDetalleInventarioABordo();

        while (dtInventarioABordo.moveToNext())
        {
            ActualizarInventario(dtInventarioABordo.getString("ProductoClave"), dtInventarioABordo.getInt("TipoUnidad"), Generales.getRound(dtInventarioABordo.getFloat("Cantidad"), dtInventarioABordo.getInt("DecimalProducto")), Enumeradores.TiposTransProd.CARGAS, Enumeradores.TiposMovimientos.ENTRADA, ((Vendedor) Sesion.get(Sesion.Campo.VendedorActual)).AlmacenID, "", false);
        }

        dtInventarioABordo.close();
        BDVend.commit();
    }*/

   /* public static void CrearMovimientoAutomatico(int tipoEnvioMovimientosAutomaticos ) throws Exception {
        try{
            StringBuilder cadena = new StringBuilder();
            Date[] fechas = new Date[2];
            String sTransProdID = "";
            Consultas.ConsultasDia.obtenerRangoAgenda(fechas);
            if (fechas[0] != null && fechas[1] != null){
                switch(tipoEnvioMovimientosAutomaticos){
                    case com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos.InventarioABordo:
                        sTransProdID = Consultas.ConsultasTransProd.obtenerInventarioABordo(fechas[0], fechas[1]);
                        break;
                    case com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos.DescargaAutomatica:
                        sTransProdID = Consultas.ConsultasTransProd.obtenerDescargaAutomatica(fechas[0], fechas[1]);
                        break;
                }
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
                switch(tipoEnvioMovimientosAutomaticos){
                    case com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos.InventarioABordo:
                        oTransProd.Folio = "0";
                        oTransProd.Tipo = Enumeradores.TiposTransProd.INVENTARIO_A_BORDO;
                        oTransProd.TipoFase = Enumeradores.TiposFasesDocto.CAPTURA;
                        oTransProd.TipoMovimiento = Enumeradores.TiposMovimientos.ENTRADA;
                        oTransProd.Total = 0;
                        oTransProd.Notas = ((Vendedor) Sesion.get(Sesion.Campo.VendedorActual)).ClaveCEDI;
                        oTransProd.FechaCaptura = fechaCaptura;
                        break;
                    case com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos.DescargaAutomatica:
                        try{
                            oTransProd.Folio = Folios.Obtener(15, cadena);
                        }catch(Exception e){
                            throw new Exception(cadena.toString());
                        }
                        oTransProd.Tipo = Enumeradores.TiposTransProd.DESCARGAS;
                        oTransProd.TipoFase = Enumeradores.TiposFasesDocto.CAPTURA;
                        oTransProd.TipoMovimiento = Enumeradores.TiposMovimientos.SALIDA;
                        oTransProd.Total = 0;
                        oTransProd.Notas = ((Vendedor) Sesion.get(Sesion.Campo.VendedorActual)).ClaveCEDI;
                        oTransProd.FechaCaptura = Generales.getFechaHoraActual();
                        break;
                }
                oTransProd.TransProdID = KeyGen.getId();
                oTransProd.DiaClave = sDiaClave;
                oTransProd.FechaHoraAlta = Generales.getFechaHoraActual();
                oTransProd.MFechaHora = Generales.getFechaHoraActual();
                oTransProd.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                oTransProd.Enviado = false;
                blnNuevo = true;
            }else{
                oTransProd.TransProdID = sTransProdID ;
                BDVend.recuperar(oTransProd);
                if (tipoEnvioMovimientosAutomaticos != com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos.InventarioABordo ) {
                    oTransProd.MFechaHora = Generales.getFechaHoraActual();
                    oTransProd.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                    oTransProd.Enviado = false;
                }
                blnNuevo = false;
            }
            boolean bCambioDetalle = false;
            //BDVend.guardarInsertar(oTransProd);

            ISetDatos dtInventario = null;

            switch(tipoEnvioMovimientosAutomaticos){
                case com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos.InventarioABordo:
                    dtInventario = Consultas.ConsultasInventario.obtenerInventario();
                    break;
                case com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos.DescargaAutomatica:
                    dtInventario = Consultas.ConsultasInventario.obtenerInventarioDescarga();
                    //Folios.confirmar(15);
                    break;
            }

            if(dtInventario.getCount() <= 0) //continuar solo si tiene detalle
                return;

            if(tipoEnvioMovimientosAutomaticos == com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos.DescargaAutomatica) //confirmar el folio solo si hay detalle
                Folios.confirmar(15);

            BDVend.guardarInsertar(oTransProd);

            if (blnNuevo){
                int iPartida;
                switch(tipoEnvioMovimientosAutomaticos){
                    case com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos.InventarioABordo:
                        iPartida = 1;
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
                                oTpd.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                                oTpd.Enviado = false;
                                BDVend.guardarInsertar(oTpd);
                                iPartida += 1;
                            }
                        }
                        break;
                    case com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos.DescargaAutomatica:
                        iPartida = 1;
                        while (dtInventario.moveToNext()){
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
                            oTpd.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                            oTpd.Enviado = false;
                            BDVend.guardarInsertar(oTpd);
                            iPartida += 1;

                            ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, oTransProd.Tipo, oTransProd.TipoMovimiento, ((Vendedor)Sesion.get(Sesion.Campo.VendedorActual)).AlmacenID);
                        }
                        break;
                }
            }else{
                switch(tipoEnvioMovimientosAutomaticos){
                    case com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos.InventarioABordo:
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
                                    oTpd.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                                    oTpd.Enviado = false;
                                    BDVend.guardarInsertar(oTpd);
                                    bCambioDetalle = true;
                                }
                            }else{
                                TransProdDetalle oTpd = oTransProd.getTransProdDetalle(aTransProdDetalle[1].toString());
                                if (oTpd.Cantidad != (dtInventario.getFloat("Disponible") / dtInventario.getInt("Factor"))) {
                                    oTpd.Cantidad = (dtInventario.getFloat("Disponible") / dtInventario.getInt("Factor"));
                                    oTpd.MFechaHora = Generales.getFechaHoraActual();
                                    oTpd.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                                    oTpd.Enviado = false;
                                    BDVend.guardarInsertar(oTpd);
                                    bCambioDetalle = true;
                                }
                            }
                        }
                        if (bCambioDetalle){
                            oTransProd.MFechaHora = Generales.getFechaHoraActual();
                            oTransProd.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                            oTransProd.Enviado = false;
                        }
                        break;
                    case com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos.DescargaAutomatica:
                        BDVend.recuperar(oTransProd, TransProdDetalle.class);
                        while (dtInventario.moveToNext()){
                            Object aTransProdDetalle[] = Consultas.ConsultasTransProdDetalle.obtenerDetallePorProductoClaveUnidad(dtInventario.getString("ProductoClave"), dtInventario.getString("PRUTipoUnidad"), "'" + oTransProd.TransProdID + "'");
                            if (aTransProdDetalle == null)
                            {
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
                                oTpd.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                                oTpd.Enviado = false;
                                BDVend.guardarInsertar(oTpd);
                            }else{
                                TransProdDetalle oTpd = oTransProd.getTransProdDetalle(aTransProdDetalle[1].toString());
                                oTpd.Cantidad  = (dtInventario.getFloat("Disponible")/dtInventario.getInt("Factor"));
                                oTpd.MFechaHora = Generales.getFechaHoraActual();
                                oTpd.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                                oTpd.Enviado = false;
                                BDVend.guardarInsertar(oTpd);

                                ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, oTransProd.Tipo, oTransProd.TipoMovimiento, ((Vendedor)Sesion.get(Sesion.Campo.VendedorActual)).AlmacenID);
                            }
                        }
                        break;
                }
            }

            dtInventario.close();
            BDVend.commit();
        }catch (Exception ex){
            BDVend.rollback();
            throw ex;
        }

    }*/

    public static boolean CargarInventarioPedido() throws Exception
    {
        if (Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.REPARTO ){

            //Si no es reparto, esta funcion no aplica
            return true;
        }
        ISetDatos pedidos = Consultas.ConsultasReparto.obtenerPedidosDU();
        while(pedidos.moveToNext()){
            HashMap<Short, DetalleProductoDobleUnidad> hmUnidadCantidad = new HashMap<Short, DetalleProductoDobleUnidad>();
            hmUnidadCantidad.put(pedidos.getShort("TipoUnidad"), new DetalleProductoDobleUnidad(pedidos.getShort("TipoUnidad"),null, Generales.getRound(pedidos.getFloat("Cantidad"), pedidos.getShort("DecimalProducto")),null, null, pedidos.getShort("DecimalProducto"),null) );
            if (pedidos.getShort("UnidadAlterna") >0 && pedidos.getFloat("CantidadAlterna") >0 ){
                hmUnidadCantidad.put(pedidos.getShort("UnidadAlterna"),new DetalleProductoDobleUnidad(pedidos.getShort("UnidadAlterna"),null, Generales.getRound(pedidos.getFloat("CantidadAlterna"), pedidos.getShort("DecimalProductoAlterna")),null, null, pedidos.getShort("DecimalProductoAlterna"),null));
            }

            ActualizarInventario(pedidos.getString("ProductoClave"), hmUnidadCantidad, Enumeradores.TiposTransProd.PEDIDO, Enumeradores.TiposMovimientos.ENTRADA);
        }
        pedidos.close();
        pedidos = null;
        BDVend.commit();
        return true;
    }

    public static boolean ActualizarInventario(String productoClave, HashMap<Short,DetalleProductoDobleUnidad> hmUnidadCantidad, int tipoTransProd, int tipoMovimiento) throws Exception
    {
        return ActualizarInventario(productoClave, hmUnidadCantidad, tipoTransProd, tipoMovimiento,  "", false);
    }

    public static boolean ActualizarInventario(String productoClave, HashMap<Short,DetalleProductoDobleUnidad>hmUnidadCantidad, int tipoTransProd, int tipoMovimiento, boolean cancelar) throws Exception
    {
        return ActualizarInventario(productoClave, hmUnidadCantidad, tipoTransProd, tipoMovimiento,  "", cancelar);
    }

    public static boolean ActualizarInventario(String productoClave, HashMap<Short,DetalleProductoDobleUnidad> hmUnidadCantidad, int tipoTransProd, int tipoMovimiento, boolean cancelacion, int tipoFase) throws Exception
    {
        return ActualizarInventario(productoClave, hmUnidadCantidad, tipoTransProd, tipoMovimiento, "", cancelacion, "",  false, tipoFase);
    }

    public static boolean ActualizarInventario(String productoClave, HashMap<Short, DetalleProductoDobleUnidad> hmUnidadCantidad, int tipoTransProd, int tipoMovimiento, String grupoMotivo, boolean cancelacion) throws Exception
    {
        return ActualizarInventario(productoClave, hmUnidadCantidad, tipoTransProd, tipoMovimiento,  grupoMotivo, cancelacion, "",  false, 0);
    }

    public static boolean ActualizarInventario(String productoClave, HashMap<Short, DetalleProductoDobleUnidad> hmUnidadCantidad, int tipoTransProd, int tipoMovimiento, String grupoMotivo, boolean cancelacion, String clienteClave, /*float prestamoVendido,*/ boolean surtirPedido) throws Exception{
        return ActualizarInventario(productoClave,hmUnidadCantidad, tipoTransProd, tipoMovimiento,  grupoMotivo, cancelacion, "", surtirPedido,0);
    }
    //Modificado
    public static boolean ActualizarInventario(String productoClave, HashMap<Short,DetalleProductoDobleUnidad> hmUnidadCantidad, int tipoTransProd, int tipoMovimiento, String grupoMotivo, boolean cancelacion, String clienteClave, /*float prestamoVendido,*/ boolean surtirPedido, int tipoFase) throws Exception
    {
        int tipoMovInventario = TiposMovInventario.NO_DEFINIDO;
        if (Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || (Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && (tipoTransProd == Enumeradores.TiposTransProd.CARGAS || tipoTransProd == Enumeradores.TiposTransProd.CAMBIOS || tipoTransProd == Enumeradores.TiposTransProd.DESCARGAS || tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_CLIENTE || tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES || (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO && !surtirPedido ) || (tipoTransProd == Enumeradores.TiposTransProd.NO_DEFINIDO && clienteClave.equals("") && tipoFase == 0 && !grupoMotivo.equals("")) )))
        {
            if (tipoMovimiento == Enumeradores.TiposMovimientos.ENTRADA)
            {
                if (!cancelacion && tipoTransProd == Enumeradores.TiposTransProd.CARGAS)
                    tipoMovInventario = TiposMovInventario.ENTRADA_DISPONIBLE;
                else if (cancelacion && tipoTransProd == Enumeradores.TiposTransProd.CARGAS)

                    tipoMovInventario = TiposMovInventario.SALIDA_DISPONIBLE;
                else if (tipoTransProd == Enumeradores.TiposTransProd.CAMBIOS || tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_CLIENTE)
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

                }else if( (tipoTransProd == Enumeradores.TiposTransProd.NO_DEFINIDO && clienteClave.equals("") && tipoFase == 0 && !grupoMotivo.equals("")) ){ //traspaso de inventario
                    if(grupoMotivo.equalsIgnoreCase("Venta"))
                        tipoMovInventario = TiposMovInventario.ENTRADA_DISPONIBLE;
                    else if(grupoMotivo.equalsIgnoreCase("No Venta")){
                        //sobreescribir el tipotransprod para que se comporte como dev manual
                        if(!cancelacion)
                            tipoMovInventario = TiposMovInventario.ENTRADA_NODISPONIBLE;
                        else
                            tipoMovInventario = TiposMovInventario.SALIDA_NODISPONIBLE;
                        tipoTransProd = Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES;
                    }
                }else if(tipoTransProd == Enumeradores.TiposTransProd.PEDIDO){ //movs usados en reparto!!!
                    if(!cancelacion) //mov para llenar las columnas apartado y pedido en reparto
                        tipoMovInventario = TiposMovInventario.ENTRADA_PEDIDO;
                    else if(tipoFase != Enumeradores.TiposFasesDocto.SURTIDO) //mov para cancelar lineas al modificar pedido
                        tipoMovInventario = TiposMovInventario.CANCELAR_PEDIDO_X_SURTIR;
                    else if(tipoFase == Enumeradores.TiposFasesDocto.SURTIDO) //mov para cancelar pedido generados en visita
                        tipoMovInventario = TiposMovInventario.CANCELAR_VENTA_REPARTO;
                }

            }
            else if (tipoMovimiento == Enumeradores.TiposMovimientos.SALIDA)
            {
                if (!cancelacion && (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO || tipoTransProd == Enumeradores.TiposTransProd.CAMBIOS || tipoTransProd == Enumeradores.TiposTransProd.AJUSTES || tipoTransProd == Enumeradores.TiposTransProd.DESCARGAS || tipoTransProd == Enumeradores.TiposTransProd.VENTA_CONSIGNACION))
                    tipoMovInventario = TiposMovInventario.SALIDA_DISPONIBLE;
                else if (cancelacion && (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO || tipoTransProd == Enumeradores.TiposTransProd.CAMBIOS || tipoTransProd == Enumeradores.TiposTransProd.AJUSTES || tipoTransProd == Enumeradores.TiposTransProd.DESCARGAS || tipoTransProd == Enumeradores.TiposTransProd.VENTA_CONSIGNACION))
                    tipoMovInventario = TiposMovInventario.ENTRADA_DISPONIBLE;
                else if (tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES)
                {
                    if (!cancelacion)
                        tipoMovInventario = TiposMovInventario.SALIDA_NODISPONIBLE;
                    else
                        tipoMovInventario = TiposMovInventario.ENTRADA_NODISPONIBLE;
                }else if( (tipoTransProd == Enumeradores.TiposTransProd.NO_DEFINIDO && clienteClave.equals("") && tipoFase == 0 && !grupoMotivo.equals("")) ){ //traspaso de inventario
                    if(grupoMotivo.equalsIgnoreCase("Venta"))
                        tipoMovInventario = TiposMovInventario.SALIDA_DISPONIBLE;
                    else if(grupoMotivo.equalsIgnoreCase("No Venta")){
                        //sobreescribir el tipotransprod para que se comporte como dev manual
                        if(!cancelacion)
                            tipoMovInventario = TiposMovInventario.SALIDA_NODISPONIBLE;
                        else
                            tipoMovInventario = TiposMovInventario.ENTRADA_NODISPONIBLE;
                        tipoTransProd = Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES;
                    }
                }

            }
        }
        else if (Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA && ((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Inventario)
        {
            if (tipoMovimiento == Enumeradores.TiposMovimientos.SALIDA || tipoMovimiento == Enumeradores.TiposMovimientos.NO_DEFINIDO)
            {
                if (!cancelacion && (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO || tipoTransProd == Enumeradores.TiposTransProd.CAMBIOS))
                    tipoMovInventario = TiposMovInventario.SALIDA_APARTADO;
                else if (cancelacion && (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO || tipoTransProd == Enumeradores.TiposTransProd.CAMBIOS))
                    tipoMovInventario = TiposMovInventario.ENTRADA_APARTADO;
            }
        }else if(tipoMovimiento == Enumeradores.TiposMovimientos.PEDIDO && (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO) && Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
            tipoMovInventario = TiposMovInventario.ENTRADA_PEDIDO;
        }else if(
                (((tipoTransProd == Enumeradores.TiposTransProd.PEDIDO && Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.PREVENTA)
                        || (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO && Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.REPARTO)
                        || (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO && Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && tipoMovimiento != Enumeradores.TiposMovimientos.PEDIDO))
                        || (tipoTransProd == Enumeradores.TiposTransProd.VENTA_CONSIGNACION && ((Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && surtirPedido) || Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA))
                ) && (tipoMovimiento == Enumeradores.TiposMovimientos.SALIDA)
                ){
            //surtir pedido, 2
            tipoMovInventario = TiposMovInventario.SURTIR_REPARTO;
        }else if(tipoMovimiento == Enumeradores.TiposMovimientos.ENTRADA && tipoTransProd == Enumeradores.TiposTransProd.PEDIDO && Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && !cancelacion){
            //salida pedido reparto, 14
            tipoMovInventario = TiposMovInventario.SALIDA_REPARTO;
        }else if(tipoMovimiento == Enumeradores.TiposMovimientos.NO_DEFINIDO && Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO
                && (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO || tipoTransProd == Enumeradores.TiposTransProd.VENTA_CONSIGNACION) && cancelacion){
            //cancelar pedido reparto, 17
            tipoMovInventario = TiposMovInventario.CANCELAR_PEDIDO_X_SURTIR;
        }else if(tipoMovimiento == Enumeradores.TiposMovimientos.ENTRADA && Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO
                && tipoTransProd == Enumeradores.TiposTransProd.PEDIDO && cancelacion){
            //cancelar venta reparto, 16
            tipoMovInventario = TiposMovInventario.CANCELAR_VENTA_REPARTO;
        }

        if (tipoMovInventario == TiposMovInventario.ENTRADA_DISPONIBLE)
        {
            for (Short unidad : hmUnidadCantidad.keySet()) {
                com.amesol.routelite.datos.InventarioUnidadesAlternas inv = new com.amesol.routelite.datos.InventarioUnidadesAlternas();
                inv.ProductoClave = productoClave;
                inv.PRUTipoUnidad = unidad;
                BDVend.recuperar(inv);

                if (hmUnidadCantidad.get(unidad).DecimalProducto ==null) {
                    ProductoUnidad pru = new ProductoUnidad();
                    pru.ProductoClave = productoClave;
                    pru.PRUTipoUnidad = unidad;
                    BDVend.recuperar(pru);
                    hmUnidadCantidad.get(unidad).DecimalProducto = Short.parseShort(String.valueOf(pru.DecimalProducto));
                }

                if (inv.isRecuperado())
                {
                    inv.Disponible = Generales.getRound(inv.Disponible + hmUnidadCantidad.get(unidad).Cantidad , hmUnidadCantidad.get(unidad).DecimalProducto );
                    inv.Apartado = inv.Pedido;
                }
                else
                {
                        inv.Disponible = Generales.getRound(inv.Disponible + hmUnidadCantidad.get(unidad).Cantidad , hmUnidadCantidad.get(unidad).DecimalProducto);
                        inv.NoDisponible = 0;
                        inv.Apartado = 0;
                        inv.Contenido = 0;
                        inv.Pedido = 0;
                }
                inv.MFechaHora = Generales.getFechaHoraActual();
                inv.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                BDVend.guardarInsertar(inv);
            }
            return true;
        }
        else if (tipoMovInventario == TiposMovInventario.ENTRADA_NODISPONIBLE)
        {
            for (Short unidad : hmUnidadCantidad.keySet()) {
                com.amesol.routelite.datos.InventarioUnidadesAlternas inv = new com.amesol.routelite.datos.InventarioUnidadesAlternas();
                inv.ProductoClave = productoClave;
                inv.PRUTipoUnidad = unidad;
                BDVend.recuperar(inv);

                if (hmUnidadCantidad.get(unidad).DecimalProducto ==null) {
                    ProductoUnidad pru = new ProductoUnidad();
                    pru.ProductoClave = productoClave;
                    pru.PRUTipoUnidad = unidad;
                    BDVend.recuperar(pru);
                    hmUnidadCantidad.get(unidad).DecimalProducto = Short.parseShort(String.valueOf(pru.DecimalProducto));
                }

                if (inv.isRecuperado())
                {
                        inv.Disponible = Generales.getRound(inv.Disponible + hmUnidadCantidad.get(unidad).Cantidad,hmUnidadCantidad.get(unidad).DecimalProducto) ;
                        inv.NoDisponible = Generales.getRound(inv.NoDisponible + hmUnidadCantidad.get(unidad).Cantidad, hmUnidadCantidad.get(unidad).DecimalProducto);
                }
                else
                {
                    inv.Disponible = Generales.getRound(inv.Disponible + hmUnidadCantidad.get(unidad).Cantidad,hmUnidadCantidad.get(unidad).DecimalProducto ) ;
                    inv.NoDisponible = Generales.getRound(inv.NoDisponible + hmUnidadCantidad.get(unidad).Cantidad, hmUnidadCantidad.get(unidad).DecimalProducto ) ;
                    inv.Apartado = 0;
                    inv.Contenido = 0;
                    inv.Pedido = 0;
                }
                inv.MFechaHora = Generales.getFechaHoraActual();
                inv.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                BDVend.guardarInsertar(inv);
            }
            return true;
        }
        else if (tipoMovInventario == TiposMovInventario.SALIDA_DISPONIBLE)
        {
            for (Short unidad : hmUnidadCantidad.keySet()) {
                com.amesol.routelite.datos.InventarioUnidadesAlternas inv = new com.amesol.routelite.datos.InventarioUnidadesAlternas();
                inv.ProductoClave = productoClave;
                inv.PRUTipoUnidad= unidad;

                BDVend.recuperar(inv);

                if (hmUnidadCantidad.get(unidad).DecimalProducto ==null) {
                    ProductoUnidad pru = new ProductoUnidad();
                    pru.ProductoClave = productoClave;
                    pru.PRUTipoUnidad = unidad;
                    BDVend.recuperar(pru);
                    hmUnidadCantidad.get(unidad).DecimalProducto = Short.parseShort(String.valueOf(pru.DecimalProducto));
                }

                if (inv.isRecuperado())
                {

                    inv.Disponible = Generales.getRound(inv.Disponible - hmUnidadCantidad.get(unidad).Cantidad, hmUnidadCantidad.get(unidad).DecimalProducto) ;
                    inv.MFechaHora = Generales.getFechaHoraActual();
                    inv.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                    BDVend.guardarInsertar(inv);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        else if (tipoMovInventario == TiposMovInventario.SALIDA_APARTADO)
        {
            for (Short unidad : hmUnidadCantidad.keySet()) {
                com.amesol.routelite.datos.InventarioUnidadesAlternas inv = new com.amesol.routelite.datos.InventarioUnidadesAlternas();
                inv.ProductoClave = productoClave;
                inv.PRUTipoUnidad = unidad;

                BDVend.recuperar(inv);

                if (hmUnidadCantidad.get(unidad).DecimalProducto ==null) {
                    ProductoUnidad pru = new ProductoUnidad();
                    pru.ProductoClave = productoClave;
                    pru.PRUTipoUnidad = unidad;
                    BDVend.recuperar(pru);
                    hmUnidadCantidad.get(unidad).DecimalProducto = Short.parseShort(String.valueOf(pru.DecimalProducto));
                }

                if (inv.isRecuperado())
                {
                    inv.Apartado = Generales.getRound(inv.Apartado + hmUnidadCantidad.get(unidad).Cantidad,hmUnidadCantidad.get(unidad).DecimalProducto ) ;
                    inv.MFechaHora = Generales.getFechaHoraActual();
                    inv.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                    BDVend.guardarInsertar(inv);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        else if (tipoMovInventario == TiposMovInventario.SALIDA_NODISPONIBLE)
        {
            for (Short unidad : hmUnidadCantidad.keySet()) {
                com.amesol.routelite.datos.InventarioUnidadesAlternas inv = new com.amesol.routelite.datos.InventarioUnidadesAlternas();
                inv.ProductoClave =productoClave;
                inv.PRUTipoUnidad = unidad;

                BDVend.recuperar(inv);

                if (hmUnidadCantidad.get(unidad).DecimalProducto ==null) {
                    ProductoUnidad pru = new ProductoUnidad();
                    pru.ProductoClave = productoClave;
                    pru.PRUTipoUnidad = unidad;
                    BDVend.recuperar(pru);
                    hmUnidadCantidad.get(unidad).DecimalProducto = Short.parseShort(String.valueOf(pru.DecimalProducto));
                }

                if (inv.isRecuperado())
                {
                    inv.Disponible = Generales.getRound(inv.Disponible - hmUnidadCantidad.get(unidad).Cantidad,  hmUnidadCantidad.get(unidad).DecimalProducto) ;
                    inv.NoDisponible = Generales.getRound(inv.NoDisponible - hmUnidadCantidad.get(unidad).Cantidad, hmUnidadCantidad.get(unidad).DecimalProducto) ;
                    inv.MFechaHora = Generales.getFechaHoraActual();
                    inv.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                    BDVend.guardarInsertar(inv);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        else if (tipoMovInventario == TiposMovInventario.ENTRADA_APARTADO)
        {
            for (Short unidad : hmUnidadCantidad.keySet()) {
                com.amesol.routelite.datos.InventarioUnidadesAlternas  inv = new com.amesol.routelite.datos.InventarioUnidadesAlternas();
                inv.ProductoClave = productoClave;
                inv.PRUTipoUnidad = unidad;

                BDVend.recuperar(inv);

                if (hmUnidadCantidad.get(unidad).DecimalProducto ==null) {
                    ProductoUnidad pru = new ProductoUnidad();
                    pru.ProductoClave = productoClave;
                    pru.PRUTipoUnidad = unidad;
                    BDVend.recuperar(pru);
                    hmUnidadCantidad.get(unidad).DecimalProducto = Short.parseShort(String.valueOf(pru.DecimalProducto));
                }

                if (inv.isRecuperado())
                {
                    inv.Apartado = Generales.getRound(inv.Apartado - hmUnidadCantidad.get(unidad).Cantidad, hmUnidadCantidad.get(unidad).DecimalProducto ) ;
                    inv.MFechaHora = Generales.getFechaHoraActual();
                    inv.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                    BDVend.guardarInsertar(inv);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }else if (tipoMovInventario == TiposMovInventario.ENTRADA_PEDIDO){

            for (Short unidad : hmUnidadCantidad.keySet()) {
                com.amesol.routelite.datos.InventarioUnidadesAlternas inv = new com.amesol.routelite.datos.InventarioUnidadesAlternas();
                inv.ProductoClave = productoClave;
                inv.PRUTipoUnidad = unidad;
                BDVend.recuperar(inv);

                if (hmUnidadCantidad.get(unidad).DecimalProducto ==null) {
                    ProductoUnidad pru = new ProductoUnidad();
                    pru.ProductoClave = productoClave;
                    pru.PRUTipoUnidad = unidad;
                    BDVend.recuperar(pru);
                    hmUnidadCantidad.get(unidad).DecimalProducto = Short.parseShort(String.valueOf(pru.DecimalProducto));
                }
                //SE modifica esta funcion para que entre tanto el apartado como el pedido, antes se incrementaba solo el pedido
                //Pero eso descuadraba el apartado. Si se regresa a como estaba, revisar el escenario de modificacion de partida
                //en pedido de reparto, cuando solo hay una parte de inventario
                //Revisar si en algun momento se da un escenario donde solo deba incrementarse la columna pedido
                if(inv.isRecuperado()){
                        inv.Pedido = Generales.getRound(inv.Pedido + hmUnidadCantidad.get(unidad).Cantidad, hmUnidadCantidad.get(unidad).DecimalProducto ) ;
                        inv.MFechaHora = Generales.getFechaHoraActual();
                        inv.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                        BDVend.guardarInsertar(inv);
                }else{
                        inv.Pedido = hmUnidadCantidad.get(unidad).Cantidad;
                        inv.MFechaHora = Generales.getFechaHoraActual();
                        inv.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                        BDVend.guardarInsertar(inv);
                }
            }
            return true;
        }else if(tipoMovInventario == TiposMovInventario.SURTIR_REPARTO){
            for (Short unidad : hmUnidadCantidad.keySet()) {
                com.amesol.routelite.datos.InventarioUnidadesAlternas inv = new com.amesol.routelite.datos.InventarioUnidadesAlternas();
                inv.ProductoClave = productoClave;
                inv.PRUTipoUnidad = unidad;
                BDVend.recuperar(inv);

                if (hmUnidadCantidad.get(unidad).DecimalProducto ==null) {
                    ProductoUnidad pru = new ProductoUnidad();
                    pru.ProductoClave = productoClave;
                    pru.PRUTipoUnidad = unidad;
                    BDVend.recuperar(pru);
                    hmUnidadCantidad.get(unidad).DecimalProducto = Short.parseShort(String.valueOf(pru.DecimalProducto));
                }

                if(Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
                    inv.Pedido =Generales.getRound(inv.Pedido - hmUnidadCantidad.get(unidad).Cantidad, hmUnidadCantidad.get(unidad).DecimalProducto) ;
                    inv.Apartado =Generales.getRound(inv.Apartado - hmUnidadCantidad.get(unidad).Cantidad, hmUnidadCantidad.get(unidad).DecimalProducto ) ;
                    inv.Disponible = Generales.getRound(inv.Disponible - hmUnidadCantidad.get(unidad).Cantidad,hmUnidadCantidad.get(unidad).DecimalProducto ) ;
                }else{
                    inv.Apartado = Generales.getRound(inv.Apartado - hmUnidadCantidad.get(unidad).Cantidad,hmUnidadCantidad.get(unidad).DecimalProducto ) ;
                    inv.Disponible = Generales.getRound(inv.Disponible - hmUnidadCantidad.get(unidad).Cantidad, hmUnidadCantidad.get(unidad).DecimalProducto) ;
                }

                if(inv.Apartado < 0)
                    inv.Apartado = 0;
                if(inv.Pedido < 0)
                    inv.Pedido = 0;

                inv.MFechaHora = Generales.getFechaHoraActual();
                inv.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                BDVend.guardarInsertar(inv);
            }
            return true;
        }else if(tipoMovInventario == TiposMovInventario.SALIDA_REPARTO){

            for (Short unidad : hmUnidadCantidad.keySet()) {
                com.amesol.routelite.datos.InventarioUnidadesAlternas inv = new com.amesol.routelite.datos.InventarioUnidadesAlternas();
                inv.ProductoClave = productoClave;
                inv.PRUTipoUnidad = unidad;
                BDVend.recuperar(inv);

                if (hmUnidadCantidad.get(unidad).DecimalProducto ==null) {
                    ProductoUnidad pru = new ProductoUnidad();
                    pru.ProductoClave = productoClave;
                    pru.PRUTipoUnidad = unidad;
                    BDVend.recuperar(pru);
                    hmUnidadCantidad.get(unidad).DecimalProducto = Short.parseShort(String.valueOf(pru.DecimalProducto));
                }

                AtomicReference<Float> existencia = new AtomicReference<Float>();
                StringBuilder error = new StringBuilder();
                ValidarExistenciaDisponible(productoClave, unidad, hmUnidadCantidad.get(unidad).Cantidad, tipoTransProd, existencia, error);

                if(hmUnidadCantidad.get(unidad).Cantidad > 0){
                    if(existencia.get() > 0 && hmUnidadCantidad.get(unidad).Cantidad > 0){
                        if(existencia.get() > hmUnidadCantidad.get(unidad).Cantidad){
                            inv.Pedido = (inv.Pedido + hmUnidadCantidad.get(unidad).Cantidad);
                            inv.Apartado = (inv.Apartado + hmUnidadCantidad.get(unidad).Cantidad);
                        }else{
                            inv.Pedido = (inv.Pedido + hmUnidadCantidad.get(unidad).Cantidad);
                            inv.Apartado = (inv.Apartado + existencia.get());
                        }
                    }else{
                        inv.Pedido += (hmUnidadCantidad.get(unidad).Cantidad);
                    }
                }
                if(inv.Apartado > inv.Pedido)
                    inv.Apartado = inv.Pedido;

                inv.MFechaHora = Generales.getFechaHoraActual();
                inv.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                BDVend.guardarInsertar(inv);
            }
            return true;
        }else if(tipoMovInventario == TiposMovInventario.CANCELAR_PEDIDO_X_SURTIR){

            for (Short unidad : hmUnidadCantidad.keySet()) {
                com.amesol.routelite.datos.InventarioUnidadesAlternas inv = new com.amesol.routelite.datos.InventarioUnidadesAlternas();
                inv.ProductoClave = productoClave;
                inv.PRUTipoUnidad= unidad;
                BDVend.recuperar(inv);

                if (hmUnidadCantidad.get(unidad).DecimalProducto ==null) {
                    ProductoUnidad pru = new ProductoUnidad();
                    pru.ProductoClave = productoClave;
                    pru.PRUTipoUnidad = unidad;
                    BDVend.recuperar(pru);
                    hmUnidadCantidad.get(unidad).DecimalProducto = Short.parseShort(String.valueOf(pru.DecimalProducto));
                }

                float pedido = Generales.getRound(inv.Pedido - hmUnidadCantidad.get(unidad).Cantidad , hmUnidadCantidad.get(unidad).DecimalProducto ) ;
                if(pedido <= 0)
                    pedido = 0;
                //inv.Pedido = inv.Pedido - cantidadxFactor;
                if(pedido <= (Generales.getRound( inv.Disponible - inv.Contenido, hmUnidadCantidad.get(unidad).DecimalProducto ))){
                    inv.Apartado = pedido;
                }else{
                    inv.Apartado = Generales.getRound(inv.Disponible - inv.Contenido, hmUnidadCantidad.get(unidad).DecimalProducto ) ;
                }
                inv.Pedido = pedido;
                inv.MFechaHora = Generales.getFechaHoraActual();
                inv.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                BDVend.guardarInsertar(inv);
            }
            return true;
        }else if(tipoMovInventario == TiposMovInventario.CANCELAR_VENTA_REPARTO){

            for (Short unidad : hmUnidadCantidad.keySet()) {
                com.amesol.routelite.datos.InventarioUnidadesAlternas inv = new com.amesol.routelite.datos.InventarioUnidadesAlternas();
                inv.ProductoClave = productoClave;
                inv.PRUTipoUnidad = unidad;
                BDVend.recuperar(inv);

                if (hmUnidadCantidad.get(unidad).DecimalProducto ==null) {
                    ProductoUnidad pru = new ProductoUnidad();
                    pru.ProductoClave = productoClave;
                    pru.PRUTipoUnidad = unidad;
                    BDVend.recuperar(pru);
                    hmUnidadCantidad.get(unidad).DecimalProducto = Short.parseShort(String.valueOf(pru.DecimalProducto));
                }

                if(hmUnidadCantidad.get(unidad).Cantidad > 0){
                    if(Generales.getRound(inv.Pedido - inv.Apartado,hmUnidadCantidad.get(unidad).DecimalProducto )  >= hmUnidadCantidad.get(unidad).Cantidad){
                        inv.Disponible = Generales.getRound (inv.Disponible + hmUnidadCantidad.get(unidad).Cantidad,hmUnidadCantidad.get(unidad).DecimalProducto );
                        inv.Apartado = Generales.getRound (inv.Apartado + hmUnidadCantidad.get(unidad).Cantidad,hmUnidadCantidad.get(unidad).DecimalProducto );
                    }else{
                        inv.Disponible = Generales.getRound (inv.Disponible + hmUnidadCantidad.get(unidad).Cantidad, hmUnidadCantidad.get(unidad).DecimalProducto);
                        inv.Apartado = Generales.getRound (inv.Apartado + (inv.Pedido - inv.Apartado), hmUnidadCantidad.get(unidad).DecimalProducto);
                    }
                }

                inv.MFechaHora = Generales.getFechaHoraActual();
                inv.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                BDVend.guardarInsertar(inv);
            }
            return true;
        }

        return false;
    }
}
