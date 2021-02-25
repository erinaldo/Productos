package com.amesol.routelite.presentadores.act;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.datos.Deposito;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaDeposito;
import com.amesol.routelite.utilerias.Log;

public class CapturarDeposito extends Presentador
{

	private ICapturaDeposito mVista;
	String mAccion;

	public CapturarDeposito(ICapturaDeposito vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
	}

	@Override
	public void iniciar()
	{
		SetValoresDefault();
	}

	public void AgregarDeposito(String TipoBanco, String Ficha, float Deposito, boolean isCheck)
	{
		try
		{
			Deposito mGenerarDeposito = Transacciones.Deposito.GenerarDeposito(Integer.parseInt(TipoBanco), Ficha, Deposito);
			BDVend.guardarInsertar(mGenerarDeposito);
			BDVend.commit();
			mVista.setLimpiarDeposito();
			mVista.refrescarDeposito();
			if (!isCheck)
				SetValoresDefault();
			else
				activarDevoluciones();

		}
		catch (Exception ex)
		{
			Log.e("", "" + ex.getMessage());

		}

	}

	public void eliminarDeposito(String DEPId, boolean isCheck)
	{

		try
		{
			Deposito mDeposito = new Deposito();
			mDeposito.DEPId = DEPId;
			BDVend.eliminar(mDeposito);
			BDVend.commit();
			mVista.refrescarDeposito();
			if (!isCheck)
				SetValoresDefault();
			else
				activarDevoluciones();
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}

	}

	public void activarDevoluciones()
	{

		try
		{
			float TotalD = Consultas.ConsultaDeposito.obtenerTotalDepyEf();
			float TotalDev = Consultas.ConsultaDeposito.obtenerTotalDevoluciones();
			float TotalE = Consultas.ConsultaDeposito.obtenerTotalDeposito();
			mVista.setTotalEfyDep(TotalD);
			mVista.setTotalDevoluciones(TotalDev);
			mVista.setTotalDeposito(TotalE);
			mVista.setTotalDepositar(TotalD - TotalDev - TotalE);

		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}

	public void SetValoresDefault()
	{
		try
		{
			float TotalD = Consultas.ConsultaDeposito.obtenerTotalDepyEf();
			float TotalE = Consultas.ConsultaDeposito.obtenerTotalDeposito();
			mVista.setTotalEfyDep(TotalD);
			mVista.setTotalDeposito(TotalE);
			mVista.setTotalDepositar(TotalD - TotalE);
			mVista.refrescarDeposito();
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}

	public void imprimirTicket() throws Exception
	{
		Recibos recibo = new Recibos();

		recibo.imprimirRecibos(generarDocsAImprimir(), false, mVista);

	}

	public List<Map<String, String>> generarDocsAImprimir()
	{
		//		String lstTrpTipo = ValoresReferencia.getStringVAVClave("TRPTIPO", "Visita");
		//
		//		ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimirMovInventario(lstTrpTipo, ((Dia) Sesion.get(Campo.DiaActual)).DiaClave, getTransaccionesIds());
		//		Cursor c = (Cursor) datos.getOriginal();
		//
		List<Map<String, String>> tabla = new ArrayList<Map<String, String>>();
		//		Map<String, String> registro;
		//		String descValor = "";
		//		while (c.moveToNext())
		//		{
		//			registro = new HashMap<String, String>();
		//			for (int i = 0; i < c.getColumnCount(); i++)
		//			{
		//				registro.put(c.getColumnName(i), c.getString(i));
		//			}
		//			NumberFormat numberFormat = new DecimalFormat("$#,##0.00");
		//			registro.put("Total", numberFormat.format(c.getDouble(c.getColumnIndex("Total"))));
		//			descValor = ValoresReferencia.getDescripcion(c.getString(c.getColumnIndex("VARCodigo")), c.getString(c.getColumnIndex("Tipo")));
		//			registro.put("DescTipo", descValor);
		//			registro.put("TipoRecibo", obtenerTipoRecibo(registro));
		//			tabla.add(registro);
		//		}
		//
		//		datos.close();
		//
		//		// aTransProdIds.toString().replace("[", "'").replace("]",
		//		// "'").replace(", ", "','")
		return tabla;
	}

	public String obtenerTipoRecibo(Map<String, String> registro)
	{
		String tipoRecibo = "0";

		int tipo = Integer.parseInt(registro.get("Tipo"));
		if (registro.get("TipoRecibo").equals("TRP"))
		{
			if ((tipo == 3 && !registro.get("TipoFase").equals(3)) || (tipo != 3))
			{
				switch (tipo)
				{
					case 8:
						if (registro.get("FacElec").equals(1))
						{
							return "24"; // Facturacion Electronica
						}
						else
						{
							return "8"; // Facturacion
						}
					case 24:
						if (registro.get("TipoFase").equals(6))
						{
							return "26"; // Liquidacion
						}
						else
						{
							return "25"; // Consignación
						}
					case 1:
						if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA)
						{
							return "1";
						}
						else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
						{
							return "27";
						}
						else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO)
						{
							return "28";
						}
					default:
						return registro.get("Tipo");
				}
			}
		}
		else if (registro.get("TipoRecibo").equals("ABN"))
		{
			return "10"; // Recibo de cobranza
		}
		return tipoRecibo;
	}
}
