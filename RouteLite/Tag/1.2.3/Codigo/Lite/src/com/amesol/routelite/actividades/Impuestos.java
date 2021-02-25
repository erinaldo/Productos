package com.amesol.routelite.actividades;

import java.util.Date;
import java.util.UUID;

import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.TPDImpuesto;
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

	private static Impuesto[] BuscarPorProducto(String ProductoClave, Short TipoImpuesto)
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
					Impuestos[i].Importe = (PrecioBase + nTotalImpuesto) * (Impuestos[i].Valor / 100);
					Impuestos[i].ImportePU = (PrecioUnitario + nTotalImpuestoPU) * (Impuestos[i].Valor / 100);
				}
				else
				{
					Impuestos[i].Importe = (PrecioBase) * (Impuestos[i].Valor / 100);
					Impuestos[i].ImportePU = (PrecioUnitario) * (Impuestos[i].Valor / 100);
				}

			}
			else
			{
				Impuestos[i].Importe = Impuestos[i].Valor * CantidadUnitaria;
				Impuestos[i].ImportePU = Impuestos[i].Valor;
			}

			nTotalImpuesto += Impuestos[i].Importe;
			nTotalImpuestoPU += Impuestos[i].ImportePU;

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

	public static void RecalcularGlobal(TransProd oTransProd) throws Exception
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

		for (int i = 0; i < oTransProd.TransProdDetalle.size(); i++)
		{
			datosImpuestos.moveToFirst();
			do
			{

				ISetDatos valoresImpuestos = null;
				try
				{
					valoresImpuestos = ConsultasImpuesto.BuscarValoresTransprod(oTransProd.TransProdID, oTransProd.TransProdDetalle.get(i).TransProdDetalleID, datosImpuestos.getString("ImpuestoClave"));
				}
				catch (Exception e)
				{
					// TODO Auto-generated catch block
					e.printStackTrace();
				}

				double dTotImp = 0;
				String sTPDImpuestoId = "";

				if (valoresImpuestos.moveToNext())
				{
					sTPDImpuestoId = valoresImpuestos.getString("TPDImpuestoId");
					dTotImp = valoresImpuestos.getDouble("ImpuestoImp");
				}
				valoresImpuestos.close();
				Double dImpActual = dTotImp;

				if (dTotImp > 0.0)
				{

					if (datosImpuestos.getShort("TipoValor") == ServicesCentral.TiposValoresAplicacionImpuestos.Porcentaje.value)
					{
						datosDescuentos.moveToFirst();
						do
						{
							if (datosDescuentos.getBoolean("TipoCascada"))
							{
								dImpActual -= dImpActual * datosDescuentos.getDouble("DesPor") / 100;
							}
							else
							{
								dImpActual -= dTotImp * datosDescuentos.getDouble("DesPor") / 100;
							}
						}
						while (datosDescuentos.moveToNext());

						dImpActual -= dImpActual * oTransProd.DescVendPor / 100;

					}
					TPDImpuesto oTPDImpuesto = new TPDImpuesto();
					oTPDImpuesto.TransProdID = oTransProd.TransProdID;
					oTPDImpuesto.TransProdDetalleID = oTransProd.TransProdDetalle.get(i).TransProdDetalleID;
					oTPDImpuesto.TPDImpuestoID = sTPDImpuestoId;
					BDVend.recuperar(oTPDImpuesto);
					oTPDImpuesto.ImpuestoPU = dImpActual;
					BDVend.guardarInsertar(oTPDImpuesto);
				}

			}
			while (datosImpuestos.moveToNext());
		}

		datosImpuestos.close();
		datosDescuentos.close();

	}

}
