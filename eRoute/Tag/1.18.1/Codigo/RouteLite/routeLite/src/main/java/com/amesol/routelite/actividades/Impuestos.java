package com.amesol.routelite.actividades;

import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.UUID;

import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.TPDImpuesto;
import com.amesol.routelite.datos.TpdDes;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasDescuentos;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasImpuesto;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.utilerias.ServicesCentral;
import com.amesol.routelite.vistas.utilerias.ServicesCentral.TiposAplicacionImpuestos;
import com.amesol.routelite.vistas.utilerias.ServicesCentral.TiposValoresAplicacionImpuestos;

public class Impuestos
{

	public static Impuesto[] Buscar(String ProductoClave, Short TipoImpuesto) throws ControlError
	{
		return BuscarPorProducto(ProductoClave, TipoImpuesto);

	}

	public static Impuesto[] Buscar(String ProductoClave, Short TipoImpuesto, Date FechaActual) throws ControlError
	{
		return BuscarPorProducto(ProductoClave, TipoImpuesto, FechaActual);

	}

	public static Impuesto[] BuscarPorProducto(String ProductoClave, Short TipoImpuesto)
	{
		return BuscarPorProducto(ProductoClave, TipoImpuesto, Generales.getFechaActual());
	}

	private static Impuesto[] BuscarPorProducto(String ProductoClave, Short TipoImpuesto, Date FechaActual)
	{

		ISetDatos setDatosImpuestos = null;
		try
		{
			setDatosImpuestos = ConsultasImpuesto.BuscarPorProducto(ProductoClave, TipoImpuesto, FechaActual);
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		Impuesto[] arrayImpuestos = new Impuesto[setDatosImpuestos.getCount()];
		for (int i = 0; i < arrayImpuestos.length; i++)
		{
			setDatosImpuestos.moveToPosition(i);
			arrayImpuestos[i] = new Impuesto();
			arrayImpuestos[i].ImpuestoClave = setDatosImpuestos.getString("ImpuestoClave");

			arrayImpuestos[i].Valor = setDatosImpuestos.getDouble("Valor");
			arrayImpuestos[i].RedondeoDecimales = setDatosImpuestos.getShort("RedondeoDecimales");
			//arrayImpuestos[i].RangoInferior = setDatosImpuestos.getFloat("RangoInferior");
			//arrayImpuestos[i].RangoSuperior = setDatosImpuestos.getFloat("RangoSuperior");
			try
			{
				BDVend.recuperar(arrayImpuestos[i]);
			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

		}

		setDatosImpuestos.close();

		return arrayImpuestos;
	}

	public static Impuesto[] BuscarPorProductoYRango(String ProductoClave, Short TipoImpuesto, Float TRPSubTotal)
	{

		ISetDatos setDatosImpuestos = null;
		try
		{
			setDatosImpuestos = ConsultasImpuesto.BuscarPorProductoYRango(ProductoClave, TipoImpuesto,Generales.getFechaActual(), TRPSubTotal);
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		Impuesto[] arrayImpuestos = new Impuesto[setDatosImpuestos.getCount()];
		for (int i = 0; i < arrayImpuestos.length; i++)
		{
			setDatosImpuestos.moveToPosition(i);
			arrayImpuestos[i] = new Impuesto();
			arrayImpuestos[i].ImpuestoClave = setDatosImpuestos.getString("ImpuestoClave");

			arrayImpuestos[i].Valor = setDatosImpuestos.getDouble("Valor");
			arrayImpuestos[i].RedondeoDecimales = setDatosImpuestos.getShort("RedondeoDecimales");
			arrayImpuestos[i].RangoInferior = setDatosImpuestos.getFloat("RangoInferior");
			arrayImpuestos[i].RangoSuperior = setDatosImpuestos.getFloat("RangoSuperior");
			try
			{
				BDVend.recuperar(arrayImpuestos[i]);
			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

		}

		setDatosImpuestos.close();

		return arrayImpuestos;
	}

	public static float Calcular(Impuesto[] Impuestos, float PrecioBase, float PrecioUnitario, float CantidadUnitaria) throws ControlError
	{
		float nTotalImpuesto = 0f;
		float nTotalImpuestoPU = 0f;
		for (int i = 0; i < Impuestos.length; i++)
		{
			if (Impuestos[i].TipoValor == TiposValoresAplicacionImpuestos.Porcentaje.value)
			{
				if (Impuestos[i].TipoAplicacion == TiposAplicacionImpuestos.SubtotalConImpuestos.value)
				{
					if (Impuestos[i].RedondeoDecimales != null &&  Impuestos[i].RedondeoDecimales >0){
						Impuestos[i].Importe = Generales.getRound ((PrecioBase + nTotalImpuesto) * (Impuestos[i].Valor / 100),Impuestos[i].RedondeoDecimales ) ;
						Impuestos[i].ImportePU = Generales.getRound((PrecioUnitario + nTotalImpuestoPU) * (Impuestos[i].Valor / 100),Impuestos[i].RedondeoDecimales) ;
					}else {
						Impuestos[i].Importe = (float)((PrecioBase + nTotalImpuesto) * (Impuestos[i].Valor / 100));
						Impuestos[i].ImportePU = (float)((PrecioUnitario + nTotalImpuestoPU) * (Impuestos[i].Valor / 100));
					}
				}
				else
				{
					if (Impuestos[i].RedondeoDecimales != null &&  Impuestos[i].RedondeoDecimales >0) {
						Impuestos[i].Importe = Generales.getRound((PrecioBase) * (Impuestos[i].Valor / 100),Impuestos[i].RedondeoDecimales);
						Impuestos[i].ImportePU = Generales.getRound((PrecioUnitario) * (Impuestos[i].Valor / 100),Impuestos[i].RedondeoDecimales );
					}else{
						Impuestos[i].Importe = (float)((PrecioBase) * (Impuestos[i].Valor / 100));
						Impuestos[i].ImportePU = (float)((PrecioUnitario) * (Impuestos[i].Valor / 100));
					}
				}

			}
			else
			{
				if (Impuestos[i].RedondeoDecimales != null &&  Impuestos[i].RedondeoDecimales >0) {
					Impuestos[i].Importe = Generales.getRound(Impuestos[i].Valor * CantidadUnitaria, Impuestos[i].RedondeoDecimales) ;
					Impuestos[i].ImportePU = Generales.getRound(Impuestos[i].Valor, Impuestos[i].RedondeoDecimales) ;
				}else{
					Impuestos[i].Importe = (float)(Impuestos[i].Valor * CantidadUnitaria);
					Impuestos[i].ImportePU = (float)(Impuestos[i].Valor);

				}
			}

			if (Impuestos[i].RedondeoDecimales != null &&  Impuestos[i].RedondeoDecimales >0) {
				nTotalImpuesto += Generales.getRound(Impuestos[i].Importe,Impuestos[i].RedondeoDecimales );
				nTotalImpuestoPU += Generales.getRound(Impuestos[i].ImportePU, Impuestos[i].RedondeoDecimales) ;
			}else{
				nTotalImpuesto += Impuestos[i].Importe;
				nTotalImpuestoPU += Impuestos[i].ImportePU;
			}

		}

		return nTotalImpuesto;
	}

	public static boolean GuardarDetalle(TransProdDetalle oTransprodetalle, Impuesto[] aImpuestos)
	{
		try
		{
			for (int i = 0; i < oTransprodetalle.TPDImpuesto.size(); i++)
			{

				BDVend.eliminar(oTransprodetalle.TPDImpuesto.get(i));

			}

			oTransprodetalle.TPDImpuesto.clear();

			for (int i = 0; i < aImpuestos.length; i++)
			{
				TPDImpuesto tpd = new TPDImpuesto();
				tpd.TransProdID = oTransprodetalle.TransProdID;
				tpd.TransProdDetalleID = oTransprodetalle.TransProdDetalleID;
				tpd.TPDImpuestoID = KeyGen.getId();
				tpd.ImpuestoClave = aImpuestos[i].ImpuestoClave;
				tpd.ImpuestoPor = aImpuestos[i].Valor;
				tpd.ImpuestoImp = aImpuestos[i].Importe;
				tpd.ImpuestoPU = aImpuestos[i].ImportePU;
				tpd.ImpDesGlb = aImpuestos[i].Importe;
				tpd.MFechaHora = Generales.getFechaHoraActual();
				tpd.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				oTransprodetalle.TPDImpuesto.add(tpd);
			}

			return true;
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
			return false;
		}

	}

    public static boolean GuardarDetalleReparto(TransProdDetalle oTransprodetalle, Impuesto[] aImpuestos)
    {
        try
        {
            //Este arreglo graba el ID para que no se pierda y por lo tanto no se duplique
            //al bajar al server
            HashMap<String, String> TPDImpuestoIDs = new HashMap<String, String>();

            for (int i = 0; i < oTransprodetalle.TPDImpuesto.size(); i++)
            {

                BDVend.eliminar(oTransprodetalle.TPDImpuesto.get(i));
                TPDImpuestoIDs.put(oTransprodetalle.TPDImpuesto.get(i).ImpuestoClave, oTransprodetalle.TPDImpuesto.get(i).TPDImpuestoID);
            }

            oTransprodetalle.TPDImpuesto.clear();

            for (int i = 0; i < aImpuestos.length; i++)
            {
                TPDImpuesto tpd = new TPDImpuesto();
                tpd.TransProdID = oTransprodetalle.TransProdID;
                tpd.TransProdDetalleID = oTransprodetalle.TransProdDetalleID;
                if (TPDImpuestoIDs.containsKey( aImpuestos[i].ImpuestoClave)){
                    tpd.TPDImpuestoID =   TPDImpuestoIDs.get( aImpuestos[i].ImpuestoClave);
                }else {
                    tpd.TPDImpuestoID = KeyGen.getId();
                }
                tpd.ImpuestoClave = aImpuestos[i].ImpuestoClave;
                tpd.ImpuestoPor = aImpuestos[i].Valor;
                tpd.ImpuestoImp = aImpuestos[i].Importe;
                tpd.ImpuestoPU = aImpuestos[i].ImportePU;
                tpd.ImpDesGlb = aImpuestos[i].Importe;
                tpd.MFechaHora = Generales.getFechaHoraActual();
                tpd.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                oTransprodetalle.TPDImpuesto.add(tpd);
            }

            return true;
        }
        catch (Exception e)
        {
            // TODO Auto-generated catch block
            e.printStackTrace();
            return false;
        }

    }

    public static boolean GuardarDetalle(TransProdDetalle oTransprodetalle)
	{

		oTransprodetalle.TPDImpuesto.clear();
		TPDImpuesto tpd = new TPDImpuesto();
		tpd.TransProdID = oTransprodetalle.TransProdID;
		tpd.TransProdDetalleID = oTransprodetalle.TransProdDetalleID;
		tpd.TPDImpuestoID = KeyGen.getId();
		tpd.MFechaHora = Generales.getFechaHoraActual();
		tpd.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
		oTransprodetalle.TPDImpuesto.add(tpd);

		return true;

	}

	public static void RecalcularPromocionales(TransProd oTransProd) throws Exception
	{
		Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

		for (int i = 0; i < oTransProd.TransProdDetalle.size(); i++)
		{
			
			TransProdDetalle oTransProdDetalle = oTransProd.TransProdDetalle.get(i);
			if (oTransProdDetalle.Promocion == 1)
			{
				float subtotal = oTransProdDetalle.getSubTotal();
				Impuesto[] arrayImpuestos = Impuestos.BuscarPorProducto(oTransProdDetalle.ProductoClave, oCliente.TipoImpuesto);
				if (arrayImpuestos != null && arrayImpuestos.length > 0)
				{

					float ImpuestoImporte = Impuestos.Calcular(arrayImpuestos, subtotal, oTransProdDetalle.Precio, oTransProdDetalle.getCantidad());
					BDVend.recuperar(oTransProdDetalle, TPDImpuesto.class);
					if (Impuestos.GuardarDetalle(oTransProdDetalle, arrayImpuestos))
					{
						oTransProdDetalle.setSubTotal(subtotal);
						oTransProdDetalle.Impuesto = ImpuestoImporte;
						oTransProdDetalle.Total = subtotal + ImpuestoImporte;
					}
				}
				else
				{
					oTransProdDetalle.Total = subtotal;

				}
				oTransProdDetalle.MFechaHora = Generales.getFechaHoraActual();
				oTransProdDetalle.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				oTransProdDetalle.Enviado = false;
				BDVend.guardarInsertar(oTransProdDetalle);
			}
		}
	}

	public static void RecalcularGlobal(TransProd oTransProd, Boolean[] redondeo) throws Exception
	{
		ISetDatos datosImpuestos = null;
		try
		{
			datosImpuestos = ConsultasImpuesto.BuscarPorTransprod(oTransProd.TransProdID);
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		ISetDatos datosDescuentos = null;

		datosDescuentos = ConsultasDescuentos.BuscarPorTransprod(oTransProd.TransProdID);
		float totalImpGlb = 0;
		boolean bRedondeoImpuesto = false;
		for (int i = 0; i < oTransProd.TransProdDetalle.size(); i++)
		{
			if (datosImpuestos.moveToFirst()) {
                do {

					if (datosImpuestos.getString("TransProdID").equals(oTransProd.TransProdID) && datosImpuestos.getString("TransProdDetalleID").equals( oTransProd.TransProdDetalle.get(i).TransProdDetalleID) ){
						ISetDatos valoresImpuestos = null;
						try {
							valoresImpuestos = ConsultasImpuesto.BuscarValoresTransprod(oTransProd.TransProdID, oTransProd.TransProdDetalle.get(i).TransProdDetalleID, datosImpuestos.getString("ImpuestoClave"));
						} catch (Exception e) {
							e.printStackTrace();
						}

						float dTotImp = 0;
						String sTPDImpuestoId = "";

						if (valoresImpuestos.moveToFirst()) {
							sTPDImpuestoId = valoresImpuestos.getString("TPDImpuestoID");
							dTotImp = valoresImpuestos.getFloat("ImpuestoImp");
						}
						valoresImpuestos.close();
						Float dImpActual = dTotImp;

						if (dTotImp > 0.0) {

							if (datosImpuestos.getShort("TipoValor") == ServicesCentral.TiposValoresAplicacionImpuestos.Porcentaje.value) {
								if (datosDescuentos.moveToFirst()) {
									do {
										if (datosDescuentos.getBoolean("TipoCascada")) {
											dImpActual -= (Float)(dImpActual * datosDescuentos.getFloat("DesPor") / 100);
										} else {
											dImpActual -= (Float) (dTotImp * datosDescuentos.getFloat("DesPor") / 100);
										}
									}
									while (datosDescuentos.moveToNext());
								}
								dImpActual -= dImpActual * oTransProd.DescVendPor / 100 ;
							}
							TPDImpuesto oTPDImpuesto = new TPDImpuesto();
							oTPDImpuesto.TransProdID = oTransProd.TransProdID;
							oTPDImpuesto.TransProdDetalleID = oTransProd.TransProdDetalle.get(i).TransProdDetalleID;
							oTPDImpuesto.TPDImpuestoID = sTPDImpuestoId;
							BDVend.recuperar(oTPDImpuesto);
							if (datosImpuestos.getInt("RedondeoDecimales") >0){
								bRedondeoImpuesto = true;
								oTPDImpuesto.ImpDesGlb = Generales.getRound(dImpActual,datosImpuestos.getInt("RedondeoDecimales") ) ;
								totalImpGlb += Generales.getRound(dImpActual,datosImpuestos.getInt("RedondeoDecimales") ) ;
							}else{
								oTPDImpuesto.ImpDesGlb = dImpActual;
								totalImpGlb +=dImpActual;
							}
							BDVend.guardarInsertar(oTPDImpuesto);
						}
					}
                }
                while (datosImpuestos.moveToNext());
            }
		}

		if (bRedondeoImpuesto){
			oTransProd.Impuesto = totalImpGlb;
			oTransProd.Total = totalImpGlb + oTransProd.Subtotal;
			BDVend.guardarInsertar(oTransProd);
			redondeo[0] = true;
			oTransProd.AplicoRedondeoImpuestos = true;
		}
		datosImpuestos.close();
		datosDescuentos.close();

	}

	public static void RecalcularRangos(TransProd oTransProd) throws Exception
	{
		Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
 		float totalImpuestoDet = 0;
		float totalImpuestoDesc =0;
		for (int i = 0; i < oTransProd.TransProdDetalle.size(); i++)
		{
			TransProdDetalle oTransProdDetalle = oTransProd.TransProdDetalle.get(i);
			float subtotal = oTransProdDetalle.getSubTotal();
			Impuesto[] arrayImpuestos = Impuestos.BuscarPorProductoYRango(oTransProdDetalle.ProductoClave, oCliente.TipoImpuesto,oTransProd.Subtotal);
			if (arrayImpuestos != null && arrayImpuestos.length > 0)
			{

				float ImpuestoImporte = Impuestos.Calcular(arrayImpuestos, subtotal, oTransProdDetalle.Precio, oTransProdDetalle.getCantidad());
				BDVend.recuperar(oTransProdDetalle, TPDImpuesto.class);
				if (Impuestos.GuardarDetalle(oTransProdDetalle, arrayImpuestos))
				{
					oTransProdDetalle.setSubTotal(subtotal);
					oTransProdDetalle.Impuesto = ImpuestoImporte;
					oTransProdDetalle.Total = subtotal + ImpuestoImporte;
					totalImpuestoDet += oTransProdDetalle.Impuesto;
					for (TpdDes oTpdDes: oTransProdDetalle.TpdDes){
						float ImpuestoDescuento = Impuestos.Calcular(arrayImpuestos, oTpdDes.DesImporte, oTransProdDetalle.Precio, oTransProdDetalle.getCantidad());
						oTpdDes.DesImpuesto =ImpuestoDescuento;
						BDVend.guardarInsertar(oTpdDes);
						totalImpuestoDesc += ImpuestoDescuento;
					}
				}
			}
			else
			{
				//Si no hay impuestos ya para calcular, se borran todos.
				BDVend.recuperar(oTransProdDetalle, TPDImpuesto.class);
				for (int j = 0; j < oTransProdDetalle.TPDImpuesto.size(); j++)
				{

					BDVend.eliminar(oTransProdDetalle.TPDImpuesto.get(j));
					for (TpdDes oTpdDes: oTransProdDetalle.TpdDes){
						oTpdDes.DesImpuesto =0;
						BDVend.guardarInsertar(oTpdDes);
					}
				}

				oTransProdDetalle.TPDImpuesto.clear();
				oTransProdDetalle.Total = subtotal;
				oTransProdDetalle.Impuesto = 0f;
			}
			oTransProdDetalle.MFechaHora = Generales.getFechaHoraActual();
			oTransProdDetalle.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			oTransProdDetalle.Enviado = false;
			BDVend.guardarInsertar(oTransProdDetalle);
		}
		oTransProd.DescuentoImpuestoCliente =totalImpuestoDesc;
		oTransProd.Impuesto = totalImpuestoDet- totalImpuestoDesc ;
		oTransProd.Total = oTransProd.Subtotal + oTransProd.Impuesto;

		BDVend.guardarInsertar(oTransProd);
	}
}
