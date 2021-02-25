package com.amesol.routelite.presentadores.act;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import android.database.Cursor;

import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Deposito;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
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
        short numImpresiones = 1;
       /* try {
            if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
                numImpresiones = Short.parseShort (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).toString());
            }
        }catch (Exception ex){
            mVista.mostrarError("Error al recuperar el parámetro NumImpresiones");
            numImpresiones = 0;
        }*/
		recibo.imprimirRecibos(generarDocsAImprimir(), false, mVista,numImpresiones);
	}

	public List<Map<String, String>> generarDocsAImprimir()
	{
		try
		{
			List<Map<String, String>> tabla = new ArrayList<Map<String, String>>();
			Map<String, String> registro;
			registro = new HashMap<String, String>();
			registro.put("TipoRecibo", Recibos.TRECIBO.DEPOSITOS_MANUALES);
			registro.put("Tipo", Recibos.TRECIBO.DEPOSITOS_MANUALES);
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
