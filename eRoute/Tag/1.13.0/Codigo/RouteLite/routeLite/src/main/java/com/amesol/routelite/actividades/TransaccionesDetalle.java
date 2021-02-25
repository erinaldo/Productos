package com.amesol.routelite.actividades;

import android.widget.EditText;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.ListIterator;
import java.util.concurrent.atomic.AtomicReference;

import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.controles.CapturaProducto;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Descuento;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.InventarioUnidadesAlternas;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.ProductoNegado;
import com.amesol.routelite.datos.TPDDatosExtra;
import com.amesol.routelite.datos.TPDImpuesto;
import com.amesol.routelite.datos.TpdDes;
import com.amesol.routelite.datos.TpdPun;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.TrpPrp;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.presentadores.interfaces.IAplicacionPromocion;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.Vista;

public class TransaccionesDetalle
{

	//Generar un detalle para que la busqueda de producto la regrese
	public static TransProdDetalle GenerarDetalleBusqueda(String ProductoClave, int TipoUnidad, float Cantidad, float Precio,String PrecioClave)
	{
		String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

		TransProdDetalle transProdDetalle = new TransProdDetalle();
		transProdDetalle.TransProdDetalleID = KeyGen.getId();
		transProdDetalle.ProductoClave = ProductoClave;
		transProdDetalle.TipoUnidad = TipoUnidad;
		transProdDetalle.Cantidad = Cantidad;
		transProdDetalle.Precio = Precio;
		transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
		transProdDetalle.MUsuarioID = sUsuarioID;

        if (PrecioClave != null && PrecioClave.length()>0){
            TPDDatosExtra oTDE = new TPDDatosExtra();
            oTDE.TransProdID = transProdDetalle.TransProdID;
            oTDE.TransProdDetalleID = transProdDetalle.TransProdDetalleID;
            oTDE.PrecioClave = PrecioClave.toString();
            oTDE.MFechaHora = Generales.getFechaHoraActual();
            oTDE.MUsuarioID = sUsuarioID;
            oTDE.Enviado = false;
            transProdDetalle.TPDDatosExtra.add(oTDE);
        }

		return transProdDetalle;
	}

	public static TransProdDetalle ObtenerDetalle(String TransProdId, String TransProdDetalleId) throws Exception
	{
		TransProdDetalle transProdDetalle = new TransProdDetalle();
		transProdDetalle.TransProdID = TransProdId;
		transProdDetalle.TransProdDetalleID = TransProdDetalleId;
		BDVend.recuperar(transProdDetalle);
		//BDVend.recuperar(transProdDetalle, TPDImpuesto.class);
		return transProdDetalle;
	}

	public static void EliminarDetalle(String TransProdId) throws Exception
	{
		Consultas.ConsultasTransProdDetalle.eliminarDetalle(TransProdId);
	}

	/*
	 * public static TransProdDetalle ActualizarTipoMotivoTransaccion(String
	 * transProdId, String transProdDetalleId, short tipoMotivo, short
	 * tipoMovimiento) throws Exception{ TransProdDetalle tpd =
	 * ObtenerDetalle(transProdId, transProdDetalleId); tpd.TipoMotivo =
	 * tipoMotivo; String moduloMovDetClave =
	 * Sesion.get(Campo.ModuloMovDetalleClave).toString(); ModuloMovDetalle
	 * modulo = new ModuloMovDetalle(); modulo.ModuloMovDetalleClave =
	 * moduloMovDetClave; BDVend.recuperar(modulo); Vendedor vendedor =
	 * (Vendedor) Sesion.get(Campo.VendedorActual); // actualizar inventario
	 * return tpd; }
	 */

	public static TransProdDetalle ActualizarTipoMotivoTransaccion(TransProdDetalle transprodDetalle, Short tipoMotivo, short tipoTransprod, Float cantidad, boolean cancelar) throws Exception
	{
		TransProdDetalle tpd = transprodDetalle;
		tpd.TipoMotivo = tipoMotivo;
		Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
		String grupoMotivo = "";
        if ( ValoresReferencia.getValor("TRPMOT", tpd.TipoMotivo.toString()) != null) {
            grupoMotivo = ValoresReferencia.getValor("TRPMOT", tpd.TipoMotivo.toString()).getGrupo();
        }
		if (cancelar && tpd.TipoMotivo != 0)
		{
			if (tpd.Cantidad > cantidad)
			{
				AtomicReference<Float> refExistencia = new AtomicReference<Float>();
				StringBuilder error = new StringBuilder();
				if (!Inventario.ValidarExistencia(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad - cantidad, tipoTransprod, grupoMotivo, refExistencia, error))
				{
					throw new Exception(error.toString());
				}
			}
		}
		//TODO: actualizar inventario
		if (tpd.TipoMotivo != 0)
		{
			Inventario.ActualizarInventario(transprodDetalle.ProductoClave, transprodDetalle.TipoUnidad, transprodDetalle.Cantidad, tipoTransprod, TiposMovimientos.ENTRADA, vendedor.AlmacenID, grupoMotivo, cancelar);
		}
		return tpd;
	}


    public static TransProdDetalle ActualizarTipoMotivoTransaccionDobleUnidad(TransProdDetalle transprodDetalle, Short tipoMotivo, short tipoTransprod, HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades, boolean cancelar) throws Exception
    {
        TransProdDetalle tpd = transprodDetalle;
        tpd.TipoMotivo = tipoMotivo;
        if (tpd.TPDDatosExtra == null || tpd.TPDDatosExtra.size() <=0){
            BDVend.recuperar(tpd, TPDDatosExtra.class);
        }
        Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
        String grupoMotivo = ValoresReferencia.getValor("TRPMOT", tpd.TipoMotivo.toString()).getGrupo();

        if (cancelar && tpd.TipoMotivo != 0)
        {
            boolean errorExistencia = false;
            AtomicReference<Float> refExistencia = new AtomicReference<Float>();
            StringBuilder error = new StringBuilder();
            if (tpd.Cantidad != hmDetalleUnidades.get(Short.parseShort(String.valueOf(tpd.TipoUnidad))).Cantidad)
            {
                if (!InventarioDobleUnidad.ValidarExistencia(tpd.ProductoClave, Short.parseShort(String.valueOf(tpd.TipoUnidad)), tpd.Cantidad - hmDetalleUnidades.get(Short.parseShort(String.valueOf(tpd.TipoUnidad))).Cantidad, tipoTransprod, grupoMotivo, refExistencia, error))
                {
                    errorExistencia = true;

                }
            }
            if(tpd.TPDDatosExtra != null && tpd.TPDDatosExtra.size()>0 && tpd.TPDDatosExtra.get(0).UnidadAlterna != null && tpd.TPDDatosExtra.get(0).UnidadAlterna >0){
                if (!InventarioDobleUnidad.ValidarExistencia(tpd.ProductoClave, tpd.TPDDatosExtra.get(0).UnidadAlterna, tpd.TPDDatosExtra.get(0).CantidadAlterna - hmDetalleUnidades.get(tpd.TPDDatosExtra.get(0).UnidadAlterna).Cantidad, tipoTransprod, grupoMotivo, refExistencia, error))
                {
                    errorExistencia = true;

                }
            }

            if (errorExistencia){
                throw new Exception(error.toString());
            }

        }
        //TODO: actualizar inventario
        if (tpd.TipoMotivo != 0)
        {
            HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidadesAnt = new HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad>();
            hmDetalleUnidadesAnt.put(Short.parseShort(String.valueOf(tpd.TipoUnidad)), new InventarioDobleUnidad.DetalleProductoDobleUnidad(Short.parseShort(String.valueOf(tpd.TipoUnidad)), null,tpd.Cantidad, null, null,null,null));
            if(tpd.TPDDatosExtra != null && tpd.TPDDatosExtra.size() >0 && tpd.TPDDatosExtra.get(0).UnidadAlterna != null && tpd.TPDDatosExtra.get(0).UnidadAlterna>0){
                hmDetalleUnidadesAnt.put(tpd.TPDDatosExtra.get(0).UnidadAlterna, new InventarioDobleUnidad.DetalleProductoDobleUnidad(tpd.TPDDatosExtra.get(0).UnidadAlterna,null,tpd.TPDDatosExtra.get(0).CantidadAlterna, null,null,null,null ));
            }
            InventarioDobleUnidad.ActualizarInventario (transprodDetalle.ProductoClave, hmDetalleUnidadesAnt, tipoTransprod, TiposMovimientos.ENTRADA, grupoMotivo, cancelar);
        }
        return tpd;
    }

	public static class Pedidos {

		/*
		 * public static TransProdDetalle GenerarDetallePedido(String
		 * TransProdId, String ProductoClave, int TipoUnidad){ String sUsuarioID
		 * = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
		 * 
		 * TransProdDetalle transProdDetalle = new TransProdDetalle();
		 * transProdDetalle.TransProdDetalleID = KeyGen.getId();
		 * transProdDetalle.TransProdID = TransProdId;
		 * transProdDetalle.ProductoClave = ProductoClave;
		 * transProdDetalle.TipoUnidad = TipoUnidad; transProdDetalle.Cantidad =
		 * 0; transProdDetalle.Precio = 0; transProdDetalle.Subtotal = 0;
		 * transProdDetalle.Total = 0; transProdDetalle.MFechaHora =
		 * Generales.getFechaHoraActual(); transProdDetalle.MUsuarioID =
		 * sUsuarioID;
		 * 
		 * return transProdDetalle;
		 * 
		 * }
		 */

        public static void CalcularTotalesDetallePedido(TransProdDetalle transProdDetalle) throws Exception {

            if (transProdDetalle.Precio >= 0) {
                String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

                //Impuestos
                Impuesto[] listaImpuestos = new Impuesto[]{};
                Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

                listaImpuestos = Impuestos.Buscar(transProdDetalle.ProductoClave, oCliente.TipoImpuesto);

                //Descuentos
                Descuento oDescto = new Descuento();
                oDescto = Descuentos.BuscarDescuentosProductos(transProdDetalle.ProductoClave);

                transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
                transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;//oDescto == null ? 0 : oDescto.PorcentajeCalculado;
                if (oDescto != null)
                    transProdDetalle.DescuentoClave = oDescto.DescuentoClave;
                transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

                transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

                transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
                transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(transProdDetalle.TransProdID) + 1;
                transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
                transProdDetalle.MUsuarioID = sUsuarioID;

                Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);
            }

        }

        public static TransProdDetalle GenerarDetallePedido(String TransProdId, String ProductoClave, int TipoUnidad, float Cantidad, float CantidadOriginal, String listasPrecios, float PrecioEspecial, String TransProdDetalleID) throws Exception {
            StringBuilder sPrecioClave = new StringBuilder();
            float nPrecio = ListaPrecio.BuscarPrecio(ProductoClave, Short.parseShort(String.valueOf(TipoUnidad)), listasPrecios, sPrecioClave,Cantidad);
            if (nPrecio >= 0) {
                String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

                //Impuestos
                Impuesto[] listaImpuestos = new Impuesto[]{};
                Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

                listaImpuestos = Impuestos.Buscar(ProductoClave, oCliente.TipoImpuesto);

                //Descuentos
                Descuento oDescto = new Descuento();
                oDescto = Descuentos.BuscarDescuentosProductos(ProductoClave);

                TransProdDetalle transProdDetalle = new TransProdDetalle();
                if (TransProdDetalleID != null)
                    transProdDetalle.TransProdDetalleID = TransProdDetalleID;
                else
                    transProdDetalle.TransProdDetalleID = KeyGen.getId();


                transProdDetalle.TransProdID = TransProdId;
                transProdDetalle.ProductoClave = ProductoClave;
                transProdDetalle.TipoUnidad = TipoUnidad;
                transProdDetalle.Cantidad = Cantidad;
                if (CantidadOriginal != 0)
                    transProdDetalle.CantidadOriginal = CantidadOriginal;
                else
                    transProdDetalle.CantidadOriginal = (Float) null;
                if (PrecioEspecial != -1 && nPrecio != PrecioEspecial) {
                    transProdDetalle.PrecioBase = nPrecio;
                    transProdDetalle.Precio = PrecioEspecial;
                } else {
                    transProdDetalle.Precio = nPrecio;
                }

                transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
                transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;//oDescto == null ? 0 : oDescto.PorcentajeCalculado;
                if (oDescto != null)
                    transProdDetalle.DescuentoClave = oDescto.DescuentoClave;
                transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

                transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

                transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
                transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
                transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
                transProdDetalle.MUsuarioID = sUsuarioID;

                TPDDatosExtra oTDE = new TPDDatosExtra();
                oTDE.TransProdID = transProdDetalle.TransProdID;
                oTDE.TransProdDetalleID = transProdDetalle.TransProdDetalleID;
                if (Sesion.get(Campo.CambioLPTpdExtra) != null && (Boolean)Sesion.get(Campo.CambioLPTpdExtra)){
                    oTDE.PrecioClave = ((String)Sesion.get(Campo.LPTpdExtra));
                }else{
                    oTDE.PrecioClave = sPrecioClave.toString();
                }
                oTDE.MFechaHora = Generales.getFechaHoraActual();
                oTDE.MUsuarioID = sUsuarioID;
                oTDE.Enviado = false;
                transProdDetalle.TPDDatosExtra.add(oTDE);

                Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

                return transProdDetalle;
            } else {
                return null;
            }

        }

        public static TransProdDetalle GenerarDetallePedidoDobleUnidad(String TransProdId, String ProductoClave, HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetallesDobleUnidad, String listasPrecios, String TransProdDetalleID, Boolean setCantidadOriginal) throws Exception {
            StringBuilder sPrecioClave = new StringBuilder();
            short  unidadAlterna = 0;
            short unidadPrecio = 0;
            float nPrecio = -1;
            float nPrecioValido = -1;
            for (InventarioDobleUnidad.DetalleProductoDobleUnidad value : hmDetallesDobleUnidad.values()) {
                nPrecio = ListaPrecio.BuscarPrecio(ProductoClave, Short.parseShort(String.valueOf(value.PRUTipoUnidad)), listasPrecios, sPrecioClave, value.Cantidad);
                if (nPrecio>=0){
                    nPrecioValido = nPrecio;
                    unidadPrecio =  value.PRUTipoUnidad;
                }else{
                    unidadAlterna = value.PRUTipoUnidad;
                }
            }

            if (unidadPrecio > 0) {//Si no, quiere decir que no se encontro precio para ninguna de las unidades
                String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

                //Impuestos
                Impuesto[] listaImpuestos = new Impuesto[]{};
                Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

                listaImpuestos = Impuestos.Buscar(ProductoClave, oCliente.TipoImpuesto);

                //Descuentos
                Descuento oDescto = new Descuento();
                oDescto = Descuentos.BuscarDescuentosProductos(ProductoClave);

                TransProdDetalle transProdDetalle = new TransProdDetalle();
                if (TransProdDetalleID != null)
                    transProdDetalle.TransProdDetalleID = TransProdDetalleID;
                else
                    transProdDetalle.TransProdDetalleID = KeyGen.getId();


                transProdDetalle.TransProdID = TransProdId;
                transProdDetalle.ProductoClave = ProductoClave;
                transProdDetalle.TipoUnidad = unidadPrecio;
                transProdDetalle.Cantidad = hmDetallesDobleUnidad.get(unidadPrecio).Cantidad;
                if (hmDetallesDobleUnidad.get(unidadPrecio).CantidadOriginal != null && hmDetallesDobleUnidad.get(unidadPrecio).CantidadOriginal != 0 && setCantidadOriginal)
                    transProdDetalle.CantidadOriginal = hmDetallesDobleUnidad.get(unidadPrecio).CantidadOriginal ;
                else
                    transProdDetalle.CantidadOriginal = (Float) null;

                transProdDetalle.Precio = nPrecioValido;

                transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
                transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;//oDescto == null ? 0 : oDescto.PorcentajeCalculado;
                if (oDescto != null)
                    transProdDetalle.DescuentoClave = oDescto.DescuentoClave;
                transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

                transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

                transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
                transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
                transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
                transProdDetalle.MUsuarioID = sUsuarioID;

                TPDDatosExtra oTDE = new TPDDatosExtra();
                oTDE.TransProdID = transProdDetalle.TransProdID;
                oTDE.TransProdDetalleID = transProdDetalle.TransProdDetalleID;
                oTDE.PrecioClave = sPrecioClave.toString();
                if (hmDetallesDobleUnidad.size()>1 && unidadAlterna != unidadPrecio && unidadAlterna>0){
                    oTDE.UnidadAlterna =  Short.parseShort(String.valueOf(unidadAlterna));
                    oTDE.CantidadAlterna = hmDetallesDobleUnidad.get(unidadAlterna).Cantidad;
                    if (hmDetallesDobleUnidad.get(unidadAlterna).CantidadOriginal != null && hmDetallesDobleUnidad.get(unidadAlterna).CantidadOriginal != 0  && setCantidadOriginal)
                        oTDE.CantidadAlternaOriginal = hmDetallesDobleUnidad.get(unidadAlterna).CantidadOriginal ;
                    else
                        oTDE.CantidadAlternaOriginal = (Float) null;
                }
                oTDE.MFechaHora = Generales.getFechaHoraActual();
                oTDE.MUsuarioID = sUsuarioID;
                oTDE.Enviado = false;
                transProdDetalle.TPDDatosExtra.add(oTDE);

                Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

                return transProdDetalle;
            } else {
                return null;
            }

        }

        public static TransProdDetalle GenerarDetalleMovsGenerales(String TransProdId, String ProductoClave, int TipoUnidad, float Cantidad, Short Motivo, String ListaPrecioBase, StringBuilder byRefError) throws Exception {

            String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

            TransProdDetalle transProdDetalle = new TransProdDetalle();
            transProdDetalle.TransProdDetalleID = KeyGen.getId();
            transProdDetalle.TransProdID = TransProdId;
            transProdDetalle.ProductoClave = ProductoClave;
            transProdDetalle.TipoUnidad = TipoUnidad;
            transProdDetalle.Cantidad = Cantidad;
            if (Motivo != null && Motivo != 0) {
                transProdDetalle.TipoMotivo = (short) Motivo;
            }
            transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;

            if (ListaPrecioBase != null && !ListaPrecioBase.equals("")){
                //Si hay una lista de precios definida para el vendedor
                StringBuilder sPrecioClave = new StringBuilder();
                float nPrecio = ListaPrecio.BuscarPrecio(ProductoClave, Short.parseShort(String.valueOf(TipoUnidad)), ListaPrecioBase, sPrecioClave,Cantidad);
                if (nPrecio >= 0) {
                    //Impuestos
                    Impuesto[] listaImpuestos = new Impuesto[]{};

                    //Siempre se envía impuesto General (1)
                    Short tipoImpuesto = 1;
                    listaImpuestos = Impuestos.Buscar(ProductoClave, tipoImpuesto);

                    transProdDetalle.Precio = nPrecio;
                    transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio));
                    transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());
                    transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;

                    TPDDatosExtra tde  = new TPDDatosExtra();
                    tde.TransProdID = transProdDetalle.TransProdID;
                    tde.TransProdDetalleID = transProdDetalle.TransProdDetalleID;
                    tde.PrecioClave = sPrecioClave.toString();
                    tde.MFechaHora = Generales.getFechaHoraActual();
                    tde.MUsuarioID = sUsuarioID;
                    transProdDetalle.TPDDatosExtra.add(tde);
                }else{
                    byRefError.append(Mensajes.get("E0742", ProductoClave, ValoresReferencia.getDescripcion("UNIDADV",String.valueOf(TipoUnidad))));
                    transProdDetalle.Precio = 0;
                    transProdDetalle.Subtotal = 0;
                    transProdDetalle.Impuesto = 0f;
                    transProdDetalle.Total = 0;

                }
            }else{
                transProdDetalle.Precio = 0;
                transProdDetalle.Subtotal = 0;
                transProdDetalle.Impuesto = 0f;
                transProdDetalle.Total = 0;
            }

            transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
            transProdDetalle.MUsuarioID = sUsuarioID;

            return transProdDetalle;

        }

        public static TransProdDetalle GenerarDetalleMovsDobleUnidad(String TransProdId, String ProductoClave, HashMap<Short,InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades, Short Motivo , String ListaPrecioBase, StringBuilder byRefError) throws Exception {

            short unidadAlterna = 0;
            short unidadPrincipal = 0;
            for (InventarioDobleUnidad.DetalleProductoDobleUnidad value : hmDetalleUnidades.values()) {
                if (value.TipoEstado==1){
                    unidadPrincipal =  value.PRUTipoUnidad;
                }else{
                    unidadAlterna = value.PRUTipoUnidad;
                }
            }
            if(unidadPrincipal <=0) return null;

            String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

            TransProdDetalle transProdDetalle = new TransProdDetalle();
            transProdDetalle.TransProdDetalleID = KeyGen.getId();
            transProdDetalle.TransProdID = TransProdId;
            transProdDetalle.ProductoClave = ProductoClave;
            transProdDetalle.TipoUnidad = unidadPrincipal;
            transProdDetalle.Cantidad = hmDetalleUnidades.get(unidadPrincipal).Cantidad;
            if (Motivo != null && Motivo != 0) {
                transProdDetalle.TipoMotivo = (short) Motivo;
            }
            transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
            StringBuilder sPrecioClave = new StringBuilder();
            if (ListaPrecioBase != null && !ListaPrecioBase.equals("")){
                short unidadPrecio = 0;
                float nPrecio = -1;
                for (InventarioDobleUnidad.DetalleProductoDobleUnidad value : hmDetalleUnidades.values()) {
                    nPrecio = ListaPrecio.BuscarPrecio(ProductoClave, Short.parseShort(String.valueOf(value.PRUTipoUnidad)), ListaPrecioBase, sPrecioClave, value.Cantidad);
                    if (nPrecio>=0){
                        unidadPrecio =  value.PRUTipoUnidad;
                        break;
                    }
                }
                if (nPrecio >= 0) {
                    //Impuestos
                    Impuesto[] listaImpuestos = new Impuesto[]{};

                    //Siempre se envía impuesto General (1)
                    Short tipoImpuesto = 1;
                    listaImpuestos = Impuestos.Buscar(ProductoClave, tipoImpuesto);

                    transProdDetalle.Precio = nPrecio;
                    transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio));
                    transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());
                    transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
                }else{
                    byRefError.append(Mensajes.get("E0742", ProductoClave, ValoresReferencia.getDescripcion("UNIDADV",String.valueOf(unidadPrecio))));
                    transProdDetalle.Precio = 0;
                    transProdDetalle.Subtotal = 0;
                    transProdDetalle.Impuesto = 0f;
                    transProdDetalle.Total = 0;
                }
            }else{
                transProdDetalle.Precio = 0;
                transProdDetalle.Subtotal = 0;
                transProdDetalle.Impuesto = 0f;
                transProdDetalle.Total = 0;
            }


            transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
            transProdDetalle.MUsuarioID = sUsuarioID;
            transProdDetalle.Enviado = false;

            TPDDatosExtra oTDE = new TPDDatosExtra();
            oTDE.TransProdID = transProdDetalle.TransProdID;
            oTDE.TransProdDetalleID = transProdDetalle.TransProdDetalleID;
            if (sPrecioClave.length()>0) {
                oTDE.PrecioClave = sPrecioClave.toString();
            }
            if (hmDetalleUnidades.size()>1 && unidadAlterna != unidadPrincipal && unidadAlterna>0){
                oTDE.UnidadAlterna =  Short.parseShort(String.valueOf(unidadAlterna));
                oTDE.CantidadAlterna = hmDetalleUnidades.get(unidadAlterna).Cantidad;
            }
            oTDE.MFechaHora = Generales.getFechaHoraActual();
            oTDE.MUsuarioID = sUsuarioID;
            oTDE.Enviado = false;
            transProdDetalle.TPDDatosExtra.add(oTDE);

            return transProdDetalle;
        }

        public static TransProdDetalle GenerarDetalleMovGenerales(TransProdDetalle transProdDetalle, String ListaPrecioBase) throws Exception {

            String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(transProdDetalle.TransProdID) + 1;
            if (transProdDetalle.TPDDatosExtra != null && transProdDetalle.TPDDatosExtra.size()>0){
                transProdDetalle.TPDDatosExtra.get(0).TransProdID = transProdDetalle.TransProdID;
            }
            if (ListaPrecioBase != null && !ListaPrecioBase.equals("")){
                //Si hay una lista de precios definida para el vendedor
                if (transProdDetalle.getPrecio()>= 0) {
                    //Impuestos
                    Impuesto[] listaImpuestos = new Impuesto[]{};

                    //Siempre se envía impuesto General (1)
                    Short tipoImpuesto = 1;
                    listaImpuestos = Impuestos.Buscar(transProdDetalle.ProductoClave, tipoImpuesto);

                    transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio));
                    transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());
                    transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
                }else{
                    transProdDetalle.Precio = 0;
                    transProdDetalle.Subtotal = 0;
                    transProdDetalle.Impuesto = 0f;
                    transProdDetalle.Total = 0;

                }
            }else{
                transProdDetalle.Precio = 0;
                transProdDetalle.Subtotal = 0;
                transProdDetalle.Impuesto = 0f;
                transProdDetalle.Total = 0;
            }

            //transProdDetalle.Precio = 0;
            //transProdDetalle.Subtotal = 0;
            //transProdDetalle.Impuesto = 0f;
            //transProdDetalle.Total = 0;
            transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
            transProdDetalle.MUsuarioID = sUsuarioID;

            return transProdDetalle;

        }

        public static TransProdDetalle ActualizarDetallePedido(String TransProdId, String TransProdDetalleId, float Cantidad) throws Exception {
            TransProdDetalle transProdDetalle = ObtenerDetallePedido(TransProdId, TransProdDetalleId);

            //Impuestos
            Impuesto[] listaImpuestos = new Impuesto[]{};
            Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
            listaImpuestos = Impuestos.Buscar(transProdDetalle.ProductoClave, oCliente.TipoImpuesto);

            //Descuentos
            Descuento oDescto = new Descuento();
            oDescto = Descuentos.BuscarDescuentosProductos(transProdDetalle.ProductoClave);

            transProdDetalle.Cantidad = Cantidad;

            transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
            transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;
            transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

            transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

            transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;

            Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

            return transProdDetalle;
        }

        public static TransProdDetalle EliminarDetalle(String TransProdId, String TransProdDetalleId) throws Exception {
            Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(TransProdId, TransProdDetalleId);
            Consultas.ConsultasTrpPrp.eliminarPorDetalle(TransProdId, TransProdDetalleId);
            Consultas.ConsultasDescuentos.eliminarDescuentosPorDetalle(TransProdId, TransProdDetalleId);
            Consultas.ConsultasTPDDesVendedor.eliminarDescuentoPorDetalle(TransProdId, TransProdDetalleId);
            Consultas.ConsultasTPDDatosExtra.eliminarPorDetalle(TransProdId, TransProdDetalleId);
            Consultas.ConsultasTPDDesProntoPago.eliminarDescuentoPorDetalle(TransProdId, TransProdDetalleId);

            float nPuntos = Consultas.ConsultasTpdPun.obtenerPuntos(TransProdId);
            if (nPuntos > 0) {
                nPuntos = Math.round(nPuntos);
                Consultas.ConsultasTpdPun.actualizarSaldo(nPuntos);
            }
            Consultas.ConsultasTpdPun.eliminarPorDetalle(TransProdId, TransProdDetalleId);

            TransProdDetalle transProdDetalle = ObtenerDetallePedido(TransProdId, TransProdDetalleId);
            BDVend.eliminar(transProdDetalle);


            return transProdDetalle;
        }

        public static TransProdDetalle EliminarDetalleSinMov(String TransProdId, String TransProdDetalleId) throws Exception {
            //			Consultas.ConsultasTrpPrp.eliminarPorDetalle(TransProdId, TransProdDetalleId);
            TransProdDetalle transProdDetalle = ObtenerDetallePedido(TransProdId, TransProdDetalleId);
            BDVend.eliminar(transProdDetalle);
            return transProdDetalle;
        }

        public static TransProdDetalle EliminarDetalleSinMovDobleUnidad(String TransProdId, String TransProdDetalleId) throws Exception {
            //			Consultas.ConsultasTrpPrp.eliminarPorDetalle(TransProdId, TransProdDetalleId);
            TransProdDetalle transProdDetalle = ObtenerDetallePedido(TransProdId, TransProdDetalleId);
            BDVend.recuperar(transProdDetalle, TPDDatosExtra.class);
            BDVend.eliminar(transProdDetalle);
            return transProdDetalle;
        }

        public static TransProdDetalle EliminarDetalleSinMovPedido(String TransProdId) throws Exception {
            ArrayList<String> mTransProdDetalle = ObtenerTransProdDetalleId(TransProdId);
            TransProdDetalle transProdDetalle = null;
            for (int a = 0; a < mTransProdDetalle.size(); a++) {
                transProdDetalle = ObtenerDetallePedido(TransProdId, mTransProdDetalle.get(a));
                BDVend.eliminar(transProdDetalle);

                TransProd trp = Transacciones.Pedidos.ObtenerPedido(TransProdId);

                BDVend.eliminar(trp);
            }

            return transProdDetalle;
        }

        public static boolean EliminarDetalleAjustesInventario(String TransProdId, boolean Carga) throws Exception {

            Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
            int tipoValidacionExistencia = TiposValidacionInventario.ValidacionRestrictiva;
            String sModuloMovDetalleClave = (String) Sesion.get(Campo.ModuloMovDetalleClave);
            ModuloMovDetalle moduloMovDetalle = new ModuloMovDetalle();
            moduloMovDetalle.ModuloMovDetalleClave = sModuloMovDetalleClave;
            BDVend.recuperar(moduloMovDetalle);

            ArrayList<String> mTransProdDetalle = ObtenerTransProdDetalleId(TransProdId);
            TransProdDetalle transProdDetalle = null;
            for (int a = 0; a < mTransProdDetalle.size(); a++) {
                transProdDetalle = ObtenerDetallePedido(TransProdId, mTransProdDetalle.get(a));
                if (Carga) {
                    AtomicReference<Float> existencia = new AtomicReference<Float>();
                    StringBuilder error = new StringBuilder();
                    if (!Inventario.ValidarExistencia(transProdDetalle.ProductoClave, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, 0.0f, moduloMovDetalle, true, existencia, error)) {
                        return false;
                    }

                    if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
                        Inventario.ActualizarInventario(transProdDetalle.ProductoClave, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID, true);
                    BDVend.eliminar(transProdDetalle);
                }else{
                    Inventario.ActualizarInventario(transProdDetalle.ProductoClave, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID, true);
                    BDVend.eliminar(transProdDetalle);
                }

            }
            TransProd trp = Transacciones.Pedidos.ObtenerPedido(TransProdId);
            BDVend.eliminar(trp);

            return true;
        }

        public static boolean EliminarDetalleAjustesInventarioDobleUnidad(String TransProdId, boolean Carga) throws Exception {

            Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
            int tipoValidacionExistencia = TiposValidacionInventario.ValidacionRestrictiva;
            String sModuloMovDetalleClave = (String) Sesion.get(Campo.ModuloMovDetalleClave);
            ModuloMovDetalle moduloMovDetalle = new ModuloMovDetalle();
            moduloMovDetalle.ModuloMovDetalleClave = sModuloMovDetalleClave;
            BDVend.recuperar(moduloMovDetalle);

            ArrayList<String> mTransProdDetalle = ObtenerTransProdDetalleId(TransProdId);
            TransProdDetalle transProdDetalle = null;
            for (int a = 0; a < mTransProdDetalle.size(); a++) {
                transProdDetalle = ObtenerDetallePedido(TransProdId, mTransProdDetalle.get(a));
                BDVend.recuperar(transProdDetalle, TPDDatosExtra.class);
                HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades = new HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad>();
                hmDetalleUnidades.put(Short.parseShort(String.valueOf(transProdDetalle.TipoUnidad)), new InventarioDobleUnidad.DetalleProductoDobleUnidad(Short.parseShort(String.valueOf(transProdDetalle.TipoUnidad)), null,transProdDetalle.Cantidad, null, null,null,null));
                if(transProdDetalle.TPDDatosExtra != null && transProdDetalle.TPDDatosExtra.size() >0 && transProdDetalle.TPDDatosExtra.get(0).UnidadAlterna != null && transProdDetalle.TPDDatosExtra.get(0).UnidadAlterna>0){
                    hmDetalleUnidades.put(transProdDetalle.TPDDatosExtra.get(0).UnidadAlterna, new InventarioDobleUnidad.DetalleProductoDobleUnidad(transProdDetalle.TPDDatosExtra.get(0).UnidadAlterna,null,transProdDetalle.TPDDatosExtra.get(0).CantidadAlterna, null,null,null,null ));
                }
                if (Carga) {
                    AtomicReference<Float> existencia = new AtomicReference<Float>();
                    StringBuilder error = new StringBuilder();
                    for(Short unidad: hmDetalleUnidades.keySet()) {
                        if (!InventarioDobleUnidad.ValidarExistencia(transProdDetalle.ProductoClave, unidad, hmDetalleUnidades.get(unidad).Cantidad, 0.0f, moduloMovDetalle, true, existencia, error)) {
                            return false;
                        }
                    }

                    if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
                        InventarioDobleUnidad.ActualizarInventario(transProdDetalle.ProductoClave, hmDetalleUnidades, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, true);
                    BDVend.eliminar(transProdDetalle);
                }else{
                    InventarioDobleUnidad.ActualizarInventario(transProdDetalle.ProductoClave, hmDetalleUnidades, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, true);
                    BDVend.eliminar(transProdDetalle);
                }

            }
            TransProd trp = Transacciones.Pedidos.ObtenerPedido(TransProdId);
            BDVend.eliminar(trp);

            return true;
        }

        public static TransProdDetalle EliminarDetalleCarga(String TransProdId, List<TransProdDetalle> transProdDetalleCarga, int tipoTransProd, int tipoMovimiento, String almacenID, boolean cancelar) throws Exception {

            ArrayList<String> mTransProdDetalle = ObtenerTransProdDetalleId(TransProdId);
            TransProdDetalle transProdDetalle = null;
            for (int a = 0; a < mTransProdDetalle.size(); a++) {
                transProdDetalle = ObtenerDetallePedido(TransProdId, mTransProdDetalle.get(a));
                Inventario.ActualizarInventario(transProdDetalleCarga.get(a).ProductoClave, transProdDetalleCarga.get(a).TipoUnidad, transProdDetalleCarga.get(a).Cantidad, tipoTransProd, tipoMovimiento, almacenID, cancelar);
                BDVend.eliminar(transProdDetalle);
            }

            return transProdDetalle;
        }

        public static TransProdDetalle ObtenerDetallePedido(String TransProdId, String TransProdDetalleId) throws Exception {
            TransProdDetalle transProdDetalle = new TransProdDetalle();
            transProdDetalle.TransProdID = TransProdId;
            transProdDetalle.TransProdDetalleID = TransProdDetalleId;
            BDVend.recuperar(transProdDetalle);
            BDVend.recuperar(transProdDetalle, TPDImpuesto.class);
            return transProdDetalle;
        }

        public static ArrayList<String> ObtenerTransProdDetalleId(String TransProdId) throws Exception {
            ArrayList<String> mDatos = new ArrayList<String>();
            ISetDatos mTransProd = Consultas.ConsultasProducto.obtenerTransDetalleid(TransProdId);
            while (mTransProd.moveToNext()) {
                mDatos.add(mTransProd.getString(0));

            }
            mTransProd.close();
            return mDatos;
        }

        //Generar un detalle para que los productosRegalados o los Canjes
        public static TransProdDetalle GuardarDetalleRegaladosYCanjes(TransProd oTransProd, String ProductoClave, int TipoUnidad, float Cantidad, String PromocionClave, int TipoValidacionInventario, boolean PendienteEntrega, String ProductoDisparador, Float Precio, String PrecioClave) throws Exception {
            Boolean esCanje = false;
            if (Precio>0 && PrecioClave.length()>0){
                esCanje=true;
            }
            String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

            float entregado = 0;
            float pendiente = 0;

            if (TipoValidacionInventario != TiposValidacionInventario.NoValidar) {
                AtomicReference<Float> existencia = new AtomicReference<Float>();
                StringBuilder error = new StringBuilder();
                if (!Inventario.ValidarExistencia(ProductoClave, TipoUnidad, Cantidad, (short) TiposMovimientos.SALIDA, (short) oTransProd.Tipo, existencia, error)) {

                    if (TipoValidacionInventario == TiposValidacionInventario.ValidacionInformativa) {
                        entregado = Cantidad;
                        pendiente = 0;
                    } else {
                        //posicionError = pos;
                        //((IAplicacionPromocion) context).setErrorInventario(true);
                        //((Vista) context).mostrarError(error.toString());
                        //seleccionTPD.get(productoClave).Cantidad = Generales.getRound(existencia.get(), decimalProducto);
                        if (PendienteEntrega) {
                            if (existencia.get() != null) {
                                entregado = existencia.get();
                                pendiente = Cantidad - existencia.get();
                            } else {
                                entregado = 0;
                                pendiente = Cantidad;
                            }
                        } else {
                            return null;
                        }
                    }
                }else{
                    entregado = Cantidad;
                    pendiente = 0;
                }
            } else {
                entregado = Cantidad;
                pendiente = 0;
            }

            TransProdDetalle transProdDetalle = null;
            if (entregado > 0) {
                transProdDetalle = new TransProdDetalle();
                transProdDetalle.TransProdID = oTransProd.TransProdID;
                //Se intenta recuperar para el caso de la modificacion del los
                //pedidos de reparto
                String transProdDetalleID = Consultas.ConsultasPromocion.recuperarTransProdDetalleIDPromocion(oTransProd.TransProdID,ProductoClave, TipoUnidad, PromocionClave );
                if (transProdDetalleID != null && transProdDetalleID.length()>0){
                    transProdDetalle.TransProdDetalleID = transProdDetalleID;
                    BDVend.recuperar(transProdDetalle);
                }else{
                    transProdDetalle.TransProdDetalleID = KeyGen.getId();
                    transProdDetalle.ProductoClave = ProductoClave;
                    transProdDetalle.TipoUnidad = TipoUnidad;
                }
                transProdDetalle.Cantidad = entregado;
                if (esCanje){
                    transProdDetalle.Precio = Precio;
                    transProdDetalle.Subtotal = Generales.getRound(Precio * entregado,2);
                    Impuesto[] listaImpuestos = new Impuesto[] {};
                    Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

                    listaImpuestos = Impuestos.Buscar(ProductoClave, oCliente.TipoImpuesto);
                    transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

                    transProdDetalle.Total = (transProdDetalle.Subtotal + transProdDetalle.Impuesto);
                    transProdDetalle.Promocion = 3;

                    Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);
                }else {
                    transProdDetalle.Precio = 0;
                    transProdDetalle.Subtotal = 0;
                    transProdDetalle.Total = 0;
                    transProdDetalle.Promocion = 2;
                }
                transProdDetalle.PromocionClave = PromocionClave;

                transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(oTransProd.TransProdID) + 1;
                transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
                transProdDetalle.MUsuarioID = sUsuarioID;
                transProdDetalle.Enviado = false;
                BDVend.guardarInsertar(transProdDetalle);
                oTransProd.TransProdDetalle.add(transProdDetalle);
                Inventario.ActualizarInventario(ProductoClave, TipoUnidad, entregado, oTransProd.Tipo, TiposMovimientos.SALIDA, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID);
            }

            if (pendiente > 0) {
                ProductoNegado oProductoNegado = new ProductoNegado();
                oProductoNegado.PRGId = KeyGen.getId();
                oProductoNegado.TransProdID = oTransProd.TransProdID;
                oProductoNegado.ProductoClave = ProductoClave;
                oProductoNegado.PromocionClave = PromocionClave;
                oProductoNegado.ProductoClave1 = ProductoDisparador;
                oProductoNegado.TipoUnidad = (short) TipoUnidad;
                oProductoNegado.Cantidad = pendiente;
                oProductoNegado.Saldo = pendiente;
                oProductoNegado.TipoFasePRP = 1;
                oProductoNegado.FechaFase = Generales.getFechaHoraActual();
                oProductoNegado.Cliente = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
                oProductoNegado.FolioPedido = oTransProd.Folio;
                oProductoNegado.PendienteEntrega = true;
                oProductoNegado.MFechaHora = Generales.getFechaHoraActual();
                oProductoNegado.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                oProductoNegado.Enviado = false;
                BDVend.guardarInsertar(oProductoNegado);
                oTransProd.ProductoNegado.add(oProductoNegado);
                //ProductoNegado.Insertar(refparoTransProd.TransProdId, dr("ProductoClave"), Me.PromocionClave, Me.ProductoClave, dr("PRUTipoUnidad"), (dr("Cantidad") - Math.Floor(dCantidadDisponible / dr("Factor"))), 1, refparoTransProd.ClienteActual.ClienteClave, refparoTransProd.FolioActual)
            }

            if (esCanje && transProdDetalle != null ){
                TPDDatosExtra oTPDDatosExtra = new TPDDatosExtra();
                oTPDDatosExtra.TransProdID = transProdDetalle.TransProdID;
                oTPDDatosExtra.TransProdDetalleID = transProdDetalle.TransProdDetalleID;
                //Se intenta recuperar para el caso de la modificacion de pedidos de reparto
                BDVend.recuperar(oTPDDatosExtra);
                oTPDDatosExtra.PrecioClave = PrecioClave;
                oTPDDatosExtra.Enviado = false;
                oTPDDatosExtra.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                oTPDDatosExtra.MFechaHora =  Generales.getFechaHoraActual();
                BDVend.guardarInsertar(oTPDDatosExtra);
                if (!oTPDDatosExtra.isRecuperado()) {
                    transProdDetalle.TPDDatosExtra.add(oTPDDatosExtra);
                }
            }

            return transProdDetalle;
        }
    }

	public static class Cambios
	{

		public static TransProdDetalle GenerarDetalleCambio(String TransProdId, String ProductoClave, int TipoUnidad, float Cantidad, float CantidadOriginal, String listaPrecios) throws Exception
		{

            //Por falta de tiempo no se implementa la funcionalidad de grabar el precio aplicado en TPDDatosExtra
            //se hará hasta que algun cliente lo requiera
            StringBuilder sPrecioClave = new StringBuilder();
			float nPrecio = ListaPrecio.BuscarPrecio(ProductoClave, Short.parseShort(String.valueOf(TipoUnidad)), listaPrecios, sPrecioClave,Cantidad);
			if (nPrecio >= 0)
			{
				String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

				//Impuestos
				Impuesto[] listaImpuestos = new Impuesto[] {};
				Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

				listaImpuestos = Impuestos.Buscar(ProductoClave, oCliente.TipoImpuesto);

				TransProdDetalle transProdDetalle = new TransProdDetalle();
				transProdDetalle.TransProdDetalleID = KeyGen.getId();
				transProdDetalle.TransProdID = TransProdId;
				transProdDetalle.ProductoClave = ProductoClave;
				transProdDetalle.TipoUnidad = TipoUnidad;
				transProdDetalle.Cantidad = Cantidad;
				if (CantidadOriginal != 0)
					transProdDetalle.CantidadOriginal = CantidadOriginal;
				else
					transProdDetalle.CantidadOriginal = (Float) null;
				transProdDetalle.Precio = nPrecio;

				transProdDetalle.DescuentoImp = (Float) null;
				transProdDetalle.DescuentoPor = (Float) null;
				transProdDetalle.Impuesto = (Float) null;
				transProdDetalle.Promocion = (Integer) null;
				transProdDetalle.PrestamoVendido = (Float) null;

				transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio));

				transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

				transProdDetalle.Total = (transProdDetalle.getSubTotal() + transProdDetalle.Impuesto);
				transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
				transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
				transProdDetalle.MUsuarioID = sUsuarioID;

				Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

				return transProdDetalle;
			}
			else
			{
				return null;
			}
		}

        public static TransProdDetalle GenerarDetalleCambioDobleUnidad(String TransProdId, String ProductoClave, HashMap<Short,InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleDobleUnidad, String listaPrecios) throws Exception
        {

            StringBuilder sPrecioClave = new StringBuilder();
            short  unidadAlterna = 0;
            short unidadPrecio = 0;
            float nPrecio = -1;
            float nPrecioValido = -1;
            for (InventarioDobleUnidad.DetalleProductoDobleUnidad value : hmDetalleDobleUnidad.values()) {
                nPrecio = ListaPrecio.BuscarPrecio(ProductoClave, Short.parseShort(String.valueOf(value.PRUTipoUnidad)), listaPrecios, sPrecioClave,value.Cantidad);
                if (nPrecio>=0){
                    nPrecioValido = nPrecio;
                    unidadPrecio =  value.PRUTipoUnidad;
                }else{
                    unidadAlterna = value.PRUTipoUnidad;
                }
            }

            if (unidadPrecio <= 0) return  null;

            if (nPrecioValido >= 0)
            {
                String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

                //Impuestos
                Impuesto[] listaImpuestos = new Impuesto[] {};
                Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

                listaImpuestos = Impuestos.Buscar(ProductoClave, oCliente.TipoImpuesto);

                TransProdDetalle transProdDetalle = new TransProdDetalle();
                transProdDetalle.TransProdDetalleID = KeyGen.getId();
                transProdDetalle.TransProdID = TransProdId;
                transProdDetalle.ProductoClave = ProductoClave;
                transProdDetalle.TipoUnidad = unidadPrecio;
                transProdDetalle.Cantidad = hmDetalleDobleUnidad.get(unidadPrecio).Cantidad;
                if (hmDetalleDobleUnidad.get(unidadPrecio).CantidadOriginal != null && hmDetalleDobleUnidad.get(unidadPrecio).CantidadOriginal > 0)
                    transProdDetalle.CantidadOriginal = hmDetalleDobleUnidad.get(unidadPrecio).CantidadOriginal;
                else
                    transProdDetalle.CantidadOriginal = (Float) null;
                transProdDetalle.Precio = nPrecioValido;

                transProdDetalle.DescuentoImp = (Float) null;
                transProdDetalle.DescuentoPor = (Float) null;
                transProdDetalle.Impuesto = (Float) null;
                transProdDetalle.Promocion = (Integer) null;
                transProdDetalle.PrestamoVendido = (Float) null;

                transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio));

                transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

                transProdDetalle.Total = (transProdDetalle.getSubTotal() + transProdDetalle.Impuesto);
                transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
                transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
                transProdDetalle.MUsuarioID = sUsuarioID;

                Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

                TPDDatosExtra oTDE = new TPDDatosExtra();
                oTDE.TransProdID = transProdDetalle.TransProdID;
                oTDE.TransProdDetalleID = transProdDetalle.TransProdDetalleID;
                oTDE.PrecioClave = sPrecioClave.toString();
                if (hmDetalleDobleUnidad.size()>1 && unidadAlterna != unidadPrecio && unidadAlterna>0){
                    oTDE.UnidadAlterna =  Short.parseShort(String.valueOf(unidadAlterna));
                    oTDE.CantidadAlterna = hmDetalleDobleUnidad.get(unidadAlterna).Cantidad;
                    if (hmDetalleDobleUnidad.get(unidadAlterna).CantidadOriginal != null && hmDetalleDobleUnidad.get(unidadAlterna).CantidadOriginal != 0 )
                        oTDE.CantidadAlternaOriginal = hmDetalleDobleUnidad.get(unidadAlterna).CantidadOriginal ;
                    else
                        oTDE.CantidadAlternaOriginal = (Float) null;
                }
                oTDE.MFechaHora = Generales.getFechaHoraActual();
                oTDE.MUsuarioID = sUsuarioID;
                oTDE.Enviado = false;
                transProdDetalle.TPDDatosExtra.add(oTDE);


                return transProdDetalle;
            }
            else
            {
                return null;
            }
        }
		public static TransProdDetalle CalcularTotales(TransProdDetalle transProdDetalle, String PrecioClave) throws Exception
		{

			if (transProdDetalle.Precio >= 0)
			{
                StringBuilder sbListaAplicada = new StringBuilder();
                Float precioVol = ListaPrecio.BuscarPrecio(transProdDetalle.ProductoClave, Short.parseShort(String.valueOf(transProdDetalle.TipoUnidad)), PrecioClave , sbListaAplicada, transProdDetalle.Cantidad);
                if (precioVol != null  && precioVol>0 && transProdDetalle.Precio != precioVol){
                    transProdDetalle.Precio = precioVol;
                }

                String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

				//Impuestos
				Impuesto[] listaImpuestos = new Impuesto[] {};
				Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

				listaImpuestos = Impuestos.Buscar(transProdDetalle.ProductoClave, oCliente.TipoImpuesto);

				/*
				 * transProdDetalle.DescuentoImp = (Float) null;
				 * transProdDetalle.DescuentoPor = (Float) null;
				 * transProdDetalle.Impuesto = (Float) null;
				 * transProdDetalle.Promocion = (Integer) null;
				 * transProdDetalle.PrestamoVendido = (Float) null;
				 */

				transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio));

				transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

				transProdDetalle.Total = (transProdDetalle.getSubTotal() + transProdDetalle.Impuesto); //+ transProdDetalle.Impuesto;
				//transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(transProdDetalle.TransProdID) + 1;
				transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
				transProdDetalle.MUsuarioID = sUsuarioID;

				Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(transProdDetalle.TransProdID, transProdDetalle.TransProdDetalleID);
				Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

				return transProdDetalle;
			}
			else
			{
				return null;
			}
		}
	}

	public static class DevolucionesCliente
	{
		public static TransProdDetalle GenerarDetalleDevolucion(String TransProdId, String ProductoClave, int TipoUnidad, float Cantidad, float CantidadOriginal, String listasPrecios, boolean ValidarPrecio) throws Exception
		{
            //Por falta de tiempo no se implementa la funcionalidad de grabar el precio aplicado en TPDDatosExtra
            //se hará hasta que algun cliente lo requiera
            StringBuilder sPrecioClave = new StringBuilder();
			float nPrecio = ListaPrecio.BuscarPrecio(ProductoClave, Short.parseShort(String.valueOf(TipoUnidad)), listasPrecios,sPrecioClave,Cantidad );
			if (!ValidarPrecio && nPrecio < 0)
			{
				nPrecio = 0;
			}
			if (nPrecio >= 0)
			{
				String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

				//Impuestos
				Impuesto[] listaImpuestos = new Impuesto[] {};
				Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

				listaImpuestos = Impuestos.Buscar(ProductoClave, oCliente.TipoImpuesto);

				TransProdDetalle transProdDetalle = new TransProdDetalle();
				transProdDetalle.TransProdDetalleID = KeyGen.getId();
				transProdDetalle.TransProdID = TransProdId;
				transProdDetalle.ProductoClave = ProductoClave;
				transProdDetalle.TipoUnidad = TipoUnidad;
				transProdDetalle.Cantidad = Cantidad;
				if (CantidadOriginal != 0)
					transProdDetalle.CantidadOriginal = CantidadOriginal;
				else
					transProdDetalle.CantidadOriginal = (Float) null;
				transProdDetalle.Precio = nPrecio;

				//transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
				//transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;//oDescto == null ? 0 : oDescto.PorcentajeCalculado;
				transProdDetalle.DescuentoImp = (float) 0;
				transProdDetalle.DescuentoPor = (float) 0;
				/*
				 * if(oDescto != null) transProdDetalle.DescuentoClave =
				 * oDescto.DescuentoClave;
				 */
				transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

				transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

				transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
				transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
				transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
				transProdDetalle.MUsuarioID = sUsuarioID;

				Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

				return transProdDetalle;
			}
			else
			{
				return null;
			}
		}

        public static TransProdDetalle GenerarDetalleDevolucionDobleUnidad(String TransProdId, String ProductoClave, HashMap<Short,InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetallesDobleUnidad, float CantidadOriginal, String listasPrecios, boolean ValidarPrecio) throws Exception
        {
            StringBuilder sPrecioClave = new StringBuilder();
            short  unidadAlterna = 0;
            short unidadPrecio = 0;
            float nPrecio = -1;
            float nPrecioValido = -1;
            for (InventarioDobleUnidad.DetalleProductoDobleUnidad value : hmDetallesDobleUnidad.values()) {
                nPrecio = ListaPrecio.BuscarPrecio(ProductoClave, Short.parseShort(String.valueOf(value.PRUTipoUnidad)), listasPrecios, sPrecioClave, value.Cantidad);
                if (nPrecio>=0){
                    nPrecioValido = nPrecio;
                    unidadPrecio =  value.PRUTipoUnidad;
                }else{
                    unidadAlterna = value.PRUTipoUnidad;
                }
            }

            if (unidadPrecio <= 0) return  null;

            if (!ValidarPrecio && nPrecioValido < 0)
            {
                nPrecioValido = 0;
            }
            if (nPrecioValido >= 0)
            {
                String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

                //Impuestos
                Impuesto[] listaImpuestos = new Impuesto[] {};
                Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

                listaImpuestos = Impuestos.Buscar(ProductoClave, oCliente.TipoImpuesto);

                TransProdDetalle transProdDetalle = new TransProdDetalle();
                transProdDetalle.TransProdDetalleID = KeyGen.getId();
                transProdDetalle.TransProdID = TransProdId;
                transProdDetalle.ProductoClave = ProductoClave;
                transProdDetalle.TipoUnidad = unidadPrecio;
                transProdDetalle.Cantidad = hmDetallesDobleUnidad.get(unidadPrecio).Cantidad;;
                if (CantidadOriginal != 0)
                    transProdDetalle.CantidadOriginal = CantidadOriginal;
                else
                    transProdDetalle.CantidadOriginal = (Float) null;
                transProdDetalle.Precio = nPrecioValido;

                //transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
                //transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;//oDescto == null ? 0 : oDescto.PorcentajeCalculado;
                transProdDetalle.DescuentoImp = (float) 0;
                transProdDetalle.DescuentoPor = (float) 0;
				/*
				 * if(oDescto != null) transProdDetalle.DescuentoClave =
				 * oDescto.DescuentoClave;
				 */
                transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

                transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

                transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
                transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
                transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
                transProdDetalle.MUsuarioID = sUsuarioID;

                Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

                TPDDatosExtra oTDE = new TPDDatosExtra();
                oTDE.TransProdID = transProdDetalle.TransProdID;
                oTDE.TransProdDetalleID = transProdDetalle.TransProdDetalleID;
                oTDE.PrecioClave = sPrecioClave.toString();
                if (hmDetallesDobleUnidad.size()>1 && unidadAlterna != unidadPrecio && unidadAlterna>0){
                    oTDE.UnidadAlterna =  Short.parseShort(String.valueOf(unidadAlterna));
                    oTDE.CantidadAlterna = hmDetallesDobleUnidad.get(unidadAlterna).Cantidad;
                    if (hmDetallesDobleUnidad.get(unidadAlterna).CantidadOriginal != null && hmDetallesDobleUnidad.get(unidadAlterna).CantidadOriginal != 0 )
                        oTDE.CantidadAlternaOriginal = hmDetallesDobleUnidad.get(unidadAlterna).CantidadOriginal ;
                    else
                        oTDE.CantidadAlternaOriginal = (Float) null;
                }
                oTDE.MFechaHora = Generales.getFechaHoraActual();
                oTDE.MUsuarioID = sUsuarioID;
                oTDE.Enviado = false;
                transProdDetalle.TPDDatosExtra.add(oTDE);

                return transProdDetalle;
            }
            else
            {
                return null;
            }
        }
        public static TransProdDetalle GenerarDetalleDevolucionEnvase(String TransProdId, String ProductoClave, int TipoUnidad, float Cantidad, int TipoMotivo) throws Exception
        {
            String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            TransProdDetalle transProdDetalle = new TransProdDetalle();
            transProdDetalle.TransProdDetalleID = KeyGen.getId();
            transProdDetalle.TransProdID = TransProdId;
            transProdDetalle.ProductoClave = ProductoClave;
            transProdDetalle.TipoUnidad = TipoUnidad;
            transProdDetalle.Cantidad = Cantidad;
            transProdDetalle.TipoMotivo = (short) TipoMotivo;
            transProdDetalle.Precio = 0;
            transProdDetalle.setSubTotal(0);
            transProdDetalle.Total = 0;
            transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
            transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
            transProdDetalle.MUsuarioID = sUsuarioID;
            transProdDetalle.Enviado = false;
            return transProdDetalle;
        }

		public static TransProdDetalle calcularTotales(TransProdDetalle transProdDetalle, String listaPrecio) throws Exception
		{
			if (transProdDetalle.Precio >= 0)
			{
                StringBuilder sbListaAplicada = new StringBuilder();
                Float precioVol = ListaPrecio.BuscarPrecio(transProdDetalle.ProductoClave, Short.parseShort(String.valueOf(transProdDetalle.TipoUnidad)), listaPrecio , sbListaAplicada, transProdDetalle.Cantidad);
                if (precioVol != null  && precioVol>0 && transProdDetalle.Precio != precioVol){
                    transProdDetalle.Precio = precioVol;
                }

				String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

				//Impuestos
				Impuesto[] listaImpuestos = new Impuesto[] {};
				Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

				listaImpuestos = Impuestos.Buscar(transProdDetalle.ProductoClave, oCliente.TipoImpuesto);

				//Descuentos
				/*
				 * Descuento oDescto = new Descuento(); oDescto =
				 * Descuentos.BuscarDescuentosProductos(ProductoClave);
				 */

				//TransProdDetalle transProdDetalle = new TransProdDetalle();
				/*
				 * transProdDetalle.TransProdDetalleID = KeyGen.getId();
				 * transProdDetalle.TransProdID = TransProdId;
				 * transProdDetalle.ProductoClave = ProductoClave;
				 * transProdDetalle.TipoUnidad = TipoUnidad;
				 * transProdDetalle.Cantidad = Cantidad;
				 */
				/*
				 * if (CantidadOriginal != 0) transProdDetalle.CantidadOriginal
				 * = CantidadOriginal; else transProdDetalle.CantidadOriginal =
				 * (Float) null; transProdDetalle.Precio = nPrecio;
				 */

				//transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
				//transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;//oDescto == null ? 0 : oDescto.PorcentajeCalculado;
				/*
				 * transProdDetalle.DescuentoImp = (float) 0;
				 * transProdDetalle.DescuentoPor = (float) 0;
				 */
				/*
				 * if(oDescto != null) transProdDetalle.DescuentoClave =
				 * oDescto.DescuentoClave;
				 */
				transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

				transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

				transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
				transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(transProdDetalle.TransProdID) + 1;
				transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
				transProdDetalle.MUsuarioID = sUsuarioID;

				Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(transProdDetalle.TransProdID, transProdDetalle.TransProdDetalleID);
				Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

				return transProdDetalle;
			}
			else
			{
				return null;
			}
		}
	}
	
	public static class Reparto{
		public static TransProdDetalle GenerarDetalleReparto(TransProdDetalle Detalle,String listasPrecios) throws Exception
		{
            StringBuilder sPrecioClave = new StringBuilder();
			float nPrecio = ListaPrecio.BuscarPrecio(Detalle.ProductoClave, Short.parseShort(String.valueOf(Detalle.TipoUnidad)), listasPrecios, sPrecioClave,Detalle.Cantidad);
			if (nPrecio >= 0)
			{
				String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

				//Impuestos
				Impuesto[] listaImpuestos = new Impuesto[] {};
				Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

				listaImpuestos = Impuestos.Buscar(Detalle.ProductoClave, oCliente.TipoImpuesto);

				//Descuentos
				Descuento oDescto = new Descuento();
				oDescto = Descuentos.BuscarDescuentosProductos(Detalle.ProductoClave);

				TransProdDetalle transProdDetalle = Detalle;

                BDVend.recuperar(transProdDetalle, TPDImpuesto.class);

				transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
				transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;//oDescto == null ? 0 : oDescto.PorcentajeCalculado;
				if (oDescto != null)
					transProdDetalle.DescuentoClave = oDescto.DescuentoClave;
				transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

				transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

				transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
				//transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
				transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
				transProdDetalle.MUsuarioID = sUsuarioID;

                TPDDatosExtra oTDE;
                if (transProdDetalle.TPDDatosExtra != null && transProdDetalle.TPDDatosExtra.size()>0){
                    //BDVend.recuperar(transProdDetalle, TPDDatosExtra.class);
                    oTDE = transProdDetalle.TPDDatosExtra.get(0);
                }else {
                    oTDE = new TPDDatosExtra();
                    oTDE.TransProdID = transProdDetalle.TransProdID;
                    oTDE.TransProdDetalleID = transProdDetalle.TransProdDetalleID;
                }
                oTDE.PrecioClave = sPrecioClave.toString();
                oTDE.MFechaHora = Generales.getFechaHoraActual();
                oTDE.MUsuarioID = sUsuarioID;
                oTDE.Enviado = false;
                transProdDetalle.TPDDatosExtra.add(oTDE);

				Impuestos.GuardarDetalleReparto(transProdDetalle, listaImpuestos);
				BDVend.guardarInsertar(transProdDetalle);

				return transProdDetalle;
			}
			else
			{
				return null;
			}

		}

    /*    public static TransProdDetalle GenerarDetalleRepartoDobleUnidad(TransProdDetalle Detalle,String listasPrecios) throws Exception
        {
            StringBuilder sPrecioClave = new StringBuilder();
            float nPrecio = ListaPrecio.BuscarPrecio(Detalle.ProductoClave, Short.parseShort(String.valueOf(Detalle.TipoUnidad)), listasPrecios, sPrecioClave);
            if (nPrecio >= 0)
            {
                String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

                //Impuestos
                Impuesto[] listaImpuestos = new Impuesto[] {};
                Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

                listaImpuestos = Impuestos.Buscar(Detalle.ProductoClave, oCliente.TipoImpuesto);

                //Descuentos
                Descuento oDescto = new Descuento();
                oDescto = Descuentos.BuscarDescuentosProductos(Detalle.ProductoClave);

                TransProdDetalle transProdDetalle = Detalle;

                BDVend.recuperar(transProdDetalle, TPDImpuesto.class);

                transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
                transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;//oDescto == null ? 0 : oDescto.PorcentajeCalculado;
                if (oDescto != null)
                    transProdDetalle.DescuentoClave = oDescto.DescuentoClave;
                transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

                transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

                transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
                //transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
                transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
                transProdDetalle.MUsuarioID = sUsuarioID;

                TPDDatosExtra oTDE = new TPDDatosExtra();
                oTDE.TransProdID = transProdDetalle.TransProdID;
                oTDE.TransProdDetalleID = transProdDetalle.TransProdDetalleID;
                oTDE.PrecioClave = sPrecioClave.toString();
                oTDE.MFechaHora = Generales.getFechaHoraActual();
                oTDE.MUsuarioID = sUsuarioID;
                oTDE.Enviado = false;
                transProdDetalle.TPDDatosExtra.add(oTDE);

                Impuestos.GuardarDetalleReparto(transProdDetalle, listaImpuestos);
                BDVend.guardarInsertar(transProdDetalle);

                return transProdDetalle;
            }
            else
            {
                return null;
            }

        }*/
		public static void Actualizar(TransProdDetalle oTransProdDetalle, String listasPrecios) throws Exception{
			//ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
			Descuento oDescuento = new Descuento();
			Impuesto[] oImpuestos;
			//ArrayList<TransProdDetalle> tpdEliminados = new ArrayList<TransProdDetalle>();
			//while (oDetalles.hasNext())
			//{
				TransProdDetalle oTPD = oTransProdDetalle; //oDetalles.next();
				/*if (oTPD.Promocion == 1 && oTPD.Total != 0)
				{*/
					//bHuboPromociones = true;

                    //En este caso el precioclave se mantiene, asi que no se actualiza nada mas
                    StringBuilder sPrecioClave = new StringBuilder();
					float nPrecio = ListaPrecio.BuscarPrecio(oTPD.ProductoClave, (short) oTPD.TipoUnidad, listasPrecios, sPrecioClave, oTransProdDetalle.Cantidad);
					if (nPrecio >= 0)
					{
						oTPD.Precio = nPrecio;
						if (oTPD.Cantidad == 0)
						{
							Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
							Consultas.ConsultasDescuentos.eliminarDescuentosPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
							Consultas.ConsultasTPDDesVendedor.eliminarDescuentoPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
							Consultas.ConsultasTrpPrp.eliminarPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
                            Consultas.ConsultasTPDDatosExtra.eliminarPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
                            Consultas.ConsultasTPDDesProntoPago.eliminarDescuentoPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);

							//limpiar los arrays por que se eliminan todos los registros
							oTPD.TPDImpuesto = new ArrayList<TPDImpuesto>();
							oTPD.TrpPrp = new ArrayList<TrpPrp>();
							//oTPD.TpdPun = new ArrayList<TpdPun>();		
							oTPD.TpdDes = new ArrayList<TpdDes>();


							//if eliminarcero then
							//BDVend.eliminar(oTPD);
							//else
							oTPD.DescuentoClave = null;
							oTPD.Promocion = 0;
							oTPD.Cantidad = 0;
							oTPD.DescuentoPor = (float) 0;
							oTPD.DescuentoImp = (float) 0;
							oTPD.Impuesto = (float) 0;
							oTPD.Subtotal = 0;
							oTPD.Total = 0;
							oTPD.Enviado = false;
							oTPD.MFechaHora = Generales.getFechaActual();
							oTPD.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

						}
						else
						{
							oImpuestos = Impuestos.Buscar(oTPD.ProductoClave, ((Cliente)Sesion.get(Campo.ClienteActual)).TipoImpuesto);
							oDescuento = Descuentos.BuscarDescuentosProductos(oTPD.ProductoClave);

							oTPD.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescuento, oTPD.Cantidad * oTPD.Precio, oTPD.Cantidad);
							oTPD.DescuentoPor = oTPD.DescuentoImp;
							oTPD.setSubTotal(((oTPD.Cantidad * oTPD.Precio) - oTPD.DescuentoImp) < 0 ? 0 : (oTPD.Cantidad * oTPD.Precio) - oTPD.DescuentoImp);
							oTPD.Impuesto = Impuestos.Calcular(oImpuestos, oTPD.getSubTotal(), oTPD.Precio, oTPD.getCantidad());
							oTPD.Total = oTPD.getSubTotal() + oTPD.Impuesto;

							Impuestos.GuardarDetalle(oTPD, oImpuestos);
						}
						BDVend.guardarInsertar(oTPD);
					}
				/*}
				else if (oTPD.Promocion == 2)
				{
					bHuboPromociones = true;
					bHuboRegalados = true;
					tpdEliminados.add(oTPD);
				}*/
			//}
		}

        public static void ActualizarDobleUnidad(TransProdDetalle oTransProdDetalle, String listasPrecios) throws Exception{
            //ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
            Descuento oDescuento = new Descuento();
            Impuesto[] oImpuestos;
            //ArrayList<TransProdDetalle> tpdEliminados = new ArrayList<TransProdDetalle>();
            //while (oDetalles.hasNext())
            //{
            TransProdDetalle oTPD = oTransProdDetalle; //oDetalles.next();
				/*if (oTPD.Promocion == 1 && oTPD.Total != 0)
				{*/
            //bHuboPromociones = true;

            //En este caso el precioclave se mantiene, asi que no se actualiza nada mas
            StringBuilder sPrecioClave = new StringBuilder();
            float nPrecio = ListaPrecio.BuscarPrecio(oTPD.ProductoClave, (short) oTPD.TipoUnidad, listasPrecios, sPrecioClave,oTPD.Cantidad);
            if (nPrecio >= 0)
            {
                oTPD.Precio = nPrecio;
                if (oTPD.Cantidad == 0)
                {
                    Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
                    Consultas.ConsultasDescuentos.eliminarDescuentosPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
                    Consultas.ConsultasTPDDesVendedor.eliminarDescuentoPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
                    Consultas.ConsultasTrpPrp.eliminarPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
                    Consultas.ConsultasTPDDesProntoPago.eliminarDescuentoPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
                    //No se elimina TPDDatosExtra
                    //limpiar los arrays por que se eliminan todos los registros
                    oTPD.TPDImpuesto = new ArrayList<TPDImpuesto>();
                    oTPD.TrpPrp = new ArrayList<TrpPrp>();
                    //oTPD.TpdPun = new ArrayList<TpdPun>();
                    oTPD.TpdDes = new ArrayList<TpdDes>();


                    //if eliminarcero then
                    //BDVend.eliminar(oTPD);
                    //else
                    oTPD.DescuentoClave = null;
                    oTPD.Promocion = 0;
                    oTPD.Cantidad = 0;
                    oTPD.DescuentoPor = (float) 0;
                    oTPD.DescuentoImp = (float) 0;
                    oTPD.Impuesto = (float) 0;
                    oTPD.Subtotal = 0;
                    oTPD.Total = 0;
                    oTPD.Enviado = false;
                    oTPD.MFechaHora = Generales.getFechaActual();
                    oTPD.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

                    BDVend.recuperar(oTPD, TPDDatosExtra.class);
                    if (oTPD.TPDDatosExtra != null && oTPD.TPDDatosExtra.size()>0 && oTPD.TPDDatosExtra.get(0) != null && oTPD.TPDDatosExtra.get(0).UnidadAlterna != null && oTPD.TPDDatosExtra.get(0).UnidadAlterna >0 ){
                        oTPD.TPDDatosExtra.get(0).CantidadAlterna = 0f;
                        oTPD.TPDDatosExtra.get(0).MFechaHora= Generales.getFechaActual();
                        oTPD.TPDDatosExtra.get(0).MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                    }
                }
                else
                {
                    oImpuestos = Impuestos.Buscar(oTPD.ProductoClave, ((Cliente)Sesion.get(Campo.ClienteActual)).TipoImpuesto);
                    oDescuento = Descuentos.BuscarDescuentosProductos(oTPD.ProductoClave);

                    oTPD.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescuento, oTPD.Cantidad * oTPD.Precio, oTPD.Cantidad);
                    oTPD.DescuentoPor = oTPD.DescuentoImp;
                    oTPD.setSubTotal(((oTPD.Cantidad * oTPD.Precio) - oTPD.DescuentoImp) < 0 ? 0 : (oTPD.Cantidad * oTPD.Precio) - oTPD.DescuentoImp);
                    oTPD.Impuesto = Impuestos.Calcular(oImpuestos, oTPD.getSubTotal(), oTPD.Precio, oTPD.getCantidad());
                    oTPD.Total = oTPD.getSubTotal() + oTPD.Impuesto;

                    Impuestos.GuardarDetalle(oTPD, oImpuestos);
                    /*BDVend.recuperar(oTPD, TPDDatosExtra.class);
                    if (oTPD.TPDDatosExtra != null && oTPD.TPDDatosExtra.size()>0 && oTPD.TPDDatosExtra.get(0) != null && oTPD.TPDDatosExtra.get(0).UnidadAlterna != null){
                        oTPD.TPDDatosExtra.get(0).CantidadAlterna = 0f;
                        oTPD.TPDDatosExtra.get(0).MFechaHora= Generales.getFechaActual();
                        oTPD.TPDDatosExtra.get(0).MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                    }*/
                }
                BDVend.guardarInsertar(oTPD);
            }
				/*}
				else if (oTPD.Promocion == 2)
				{
					bHuboPromociones = true;
					bHuboRegalados = true;
					tpdEliminados.add(oTPD);
				}*/
            //}
        }
	}
}
