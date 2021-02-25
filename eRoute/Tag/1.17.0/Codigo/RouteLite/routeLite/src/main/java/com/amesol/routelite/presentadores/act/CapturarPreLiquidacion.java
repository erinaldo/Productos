package com.amesol.routelite.presentadores.act;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Deposito;
import com.amesol.routelite.datos.PLBPLE;
import com.amesol.routelite.datos.PreLiquidacion;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaPreLiquidacion;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.Log;

public class CapturarPreLiquidacion extends Presentador
{

	private ICapturaPreLiquidacion mVista;
	//	private String mAccion;
	private PLBPLE mGenerarPreliquidacion;
	private ISetDatos mPreliquidacion;
	float TotalPreLiquidacion;
	float MontoTotalPreLiquidacion;

	public CapturarPreLiquidacion(ICapturaPreLiquidacion vista, String accion)
	{
		mVista = vista;
		//		mAccion = accion;
	}

	@SuppressWarnings("deprecation")
	@Override
	public void iniciar()
	{
		try
		{
			Consultas.ConsultaPreLiquidacion.verificarMonto();
			mPreliquidacion = Consultas.ConsultaPreLiquidacion.obtenerPreLiquidacion();
			mPreliquidacion.moveToFirst();
			if (mPreliquidacion.getCount() != 0)
			{
				ISetDatos mDetallePre = Consultas.ConsultaPreLiquidacion.obtenerDetallePreLiquidacion(mPreliquidacion.getString(0), false, false);
				if (mDetallePre.getCount() != 0)
				{
					TotalPreLiquidacion = Generales.getRound(Float.parseFloat(mPreliquidacion.getString(2)), 2) ;
					MontoTotalPreLiquidacion = TotalPreLiquidacion;
					while (mDetallePre.moveToNext())
					{
						MontoTotalPreLiquidacion = Generales.getRound(MontoTotalPreLiquidacion + mDetallePre.getFloat("Total"), 2) ;
					}
					mVista.llenarValores(mPreliquidacion.getString(1), "" + TotalPreLiquidacion);
				}
				else
				{
					TotalPreLiquidacion = Float.parseFloat(mPreliquidacion.getString(2));
					MontoTotalPreLiquidacion = TotalPreLiquidacion;
					mVista.llenarValores(Generales.getFechaActualStr(), "" + TotalPreLiquidacion);
				}
				mGenerarPreliquidacion = Transacciones.Preliquidacion.generarPreliquidacion(mPreliquidacion.getString(0));
				setTotal();
				mVista.refrescarEfectivo(mPreliquidacion.getString(0));
				mVista.refrescarDeposito(mPreliquidacion.getString(0));
				mVista.setError(false);
				ArrayList<Deposito> ArrayDepositos = Consultas.ConsultaPreLiquidacion.obtenerTotalDeposito(mPreliquidacion.getString(0));
				if (ArrayDepositos.size() != 0)
				{
					for (int a = 0; a < ArrayDepositos.size(); a++)
					{
						mGenerarPreliquidacion = Transacciones.Preliquidacion.ActualizarPreliquidacionDeposito(ArrayDepositos.get(a).DiaClave, "", String.valueOf(ArrayDepositos.get(a).TipoBanco), "", String.valueOf(ArrayDepositos.get(a).Total), ArrayDepositos.get(a).Ficha, mGenerarPreliquidacion);
						BDVend.guardarInsertar(mGenerarPreliquidacion);
						Deposito mDeposito = new Deposito();
						mDeposito.DEPId = ArrayDepositos.get(a).DEPId;
						BDVend.eliminar(mDeposito);
						setTotal();
						mVista.refrescarDeposito(mGenerarPreliquidacion.PLIId);
						TotalPreLiquidacion = Generales.getRound( TotalPreLiquidacion - ArrayDepositos.get(a).Total, 2);
						mVista.llenarValores(mPreliquidacion.getString(1), "" + TotalPreLiquidacion);
						asignarGuardarValores();
					}

				}
			}
			else
			{
				mVista.setError(true);
				mVista.mostrarAdvertencia(Mensajes.get("I0156"));
			}

		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}

	}

	public String PLIId()
	{
		return mPreliquidacion.getString(0);
	}

	public void AgregarEfectivo(int mTipo, String PBEId, String mDenominador, float mTotal, boolean esNuevo)
	{
		try
		{
			mGenerarPreliquidacion = Transacciones.Preliquidacion.ActualizarPreliquidacionEfectivo(mDenominador, PBEId, mTotal, mGenerarPreliquidacion);
			BDVend.guardarInsertar(mGenerarPreliquidacion);
			setTotal();
			mVista.setLimpiarEfectivo();
			mVista.refrescarEfectivo(mGenerarPreliquidacion.PLIId);
			TotalPreLiquidacion = TotalPreLiquidacion - (mTotal *(Float.parseFloat(ValoresReferencia.getDescripcion("DENOMINA", mGenerarPreliquidacion.TipoEfectivo))));
			mVista.llenarValores(mPreliquidacion.getString(1), "" + TotalPreLiquidacion);
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
		}

	}

	public void AgregarDeposito(String mFecha, String PBEId, String TipoBanco, String Referencia, String TotalDep, String Ficha)
	{
		try
		{
			mGenerarPreliquidacion = Transacciones.Preliquidacion.ActualizarPreliquidacionDeposito(mFecha, PBEId, TipoBanco, Referencia, TotalDep, Ficha, mGenerarPreliquidacion);
			BDVend.guardarInsertar(mGenerarPreliquidacion);
			setTotal();
			mVista.setLimpiarDeposito();
			mVista.refrescarDeposito(mGenerarPreliquidacion.PLIId);
			TotalPreLiquidacion = TotalPreLiquidacion - Float.parseFloat(TotalDep);
			mVista.llenarValores(mPreliquidacion.getString(1), "" + TotalPreLiquidacion);
		}
		catch (Exception ex)
		{
			Log.e("", "" + ex.getMessage());

		}

	}

	public void asignarGuardarValores() throws Exception
	{
		PreLiquidacion mPreLiquidacion = new PreLiquidacion();
		mPreLiquidacion.PLIId = mPreliquidacion.getString(0);
		BDVend.recuperar(mPreLiquidacion);
		mPreLiquidacion.MontoTotal = TotalPreLiquidacion;
		BDVend.guardarInsertar(mPreLiquidacion);
		BDVend.commit();
	}

	public boolean validarTotal()
	{
		ISetDatos mDetallePre;
		try
		{
			//mDetallePre = Consultas.ConsultaPreLiquidacion.obtenerDetallePreLiquidacion(mPreliquidacion.getString(0), false, false);
			//TotalPreLiquidacion = Generales.getRound(MontoTotalPreLiquidacion, 2)  ;
			//while (mDetallePre.moveToNext())
			//{
			//	TotalPreLiquidacion = Generales.getRound( TotalPreLiquidacion - mDetallePre.getFloat("Total"), 2);
			//}

			String DiferenciaPreliqui = ((CONHist) Sesion.get(Campo.CONHist)).get("DiferenciaPreliqui").toString();
			float Diferencia = Generales.getRound( Float.parseFloat(DiferenciaPreliqui), 2);
			if (Math.abs(TotalPreLiquidacion) > Diferencia)
			{
				if (TotalPreLiquidacion < 0)
				{
					mVista.setError(false);
					mVista.mostrarAdvertencia((Mensajes.get("E0589").replace("$0$", DiferenciaPreliqui)));
					return false;
				}
				else if (TotalPreLiquidacion > 0)
				{
					mVista.setError(false);
					mVista.mostrarAdvertencia((Mensajes.get("E0585").replace("$0$", DiferenciaPreliqui)));
					return false;
				}

			}
			return true;
		}
		catch (Exception e)
		{
			e.printStackTrace();
			return false;
		}

	}

	public void eliminarDetalle(String PLIId, String PBEId)
	{

		try
		{
			PLBPLE mPLBPLE = Consultas.ConsultaPreLiquidacion.obtenerPreLiquidacion(PLIId, PBEId);
			setTotal();
			float total = mPLBPLE.Total;
			if(mPLBPLE.Referencia == null)
				//total *= (Float.parseFloat(ValoresReferencia.getDescripcion("DENOMINA", mGenerarPreliquidacion.TipoEfectivo)));
				total *= (Float.parseFloat(ValoresReferencia.getDescripcion("DENOMINA", mPLBPLE.TipoEfectivo)));
			TotalPreLiquidacion = TotalPreLiquidacion + total;
			mVista.llenarValores(mPreliquidacion.getString(1), "" + TotalPreLiquidacion);
			mVista.refrescarEfectivo(PLIId);
			mVista.refrescarDeposito(PLIId);
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}

	}

	public void setTotal()
	{
		try
		{
			mVista.setTotales(Generales.getRound(Consultas.ConsultaPreLiquidacion.obtenerSuma(mGenerarPreliquidacion.PLIId, true),2), Generales.getRound(Consultas.ConsultaPreLiquidacion.obtenerSuma(mGenerarPreliquidacion.PLIId, false), 2) );
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}
	public void imprimirTicket() throws Exception
	{
		Recibos recibo = new Recibos();
		short numImpresiones = 1;
		recibo.imprimirRecibos(generarDocsAImprimir(), false, mVista,numImpresiones);
	}

	public List<Map<String, String>> generarDocsAImprimir()
	{
		try
		{
			List<Map<String, String>> tabla = new ArrayList<Map<String, String>>();
			Map<String, String> registro;
			registro = new HashMap<String, String>();
			registro.put("TipoRecibo", Recibos.TRECIBO.PRELIQUIDACION);
			registro.put("Tipo", Recibos.TRECIBO.PRELIQUIDACION);
			registro.put("_Id", mPreliquidacion.getString(0));
			tabla.add(registro);
			return tabla;
		}
		catch (Exception e)
		{
			e.printStackTrace();
			mVista.mostrarError(e.getMessage());
			return new ArrayList<Map<String, String>>();
		}
	}
}
