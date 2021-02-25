package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.datos.CamionVendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaKilometraje;

public class CapturarKilometraje extends Presentador
{
	CamionVendedor mCamionVendedor;
    private ICapturaKilometraje mVista;

	public CapturarKilometraje(ICapturaKilometraje vista, String accion)
	{
		mVista = vista;
		//		mAccion = accion;

	}

	@Override
	public void iniciar()
	{
		try
		{
			mCamionVendedor = Consultas.ConsultasKilometraje.obtenerCamiondeVendedor();
			if (mCamionVendedor.KmInicial == 0 && mCamionVendedor.KmFinal == 0)
			{
				mVista.setCapturaInicial(false);
			}
			else if (mCamionVendedor.KmInicial != 0 && mCamionVendedor.KmFinal == 0)
			{
				mVista.setCapturaInicial(true);
				CamionVendedor mCamion = Consultas.ConsultasKilometraje.obtenerCamion(mCamionVendedor.Placa);
				mVista.setValores(mCamionVendedor.Placa, mCamion.Clave, String.valueOf(mCamionVendedor.KmInicial));
			}
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}

	}

	public boolean validarPlacas(String Placas)
	{
		try
		{
			CamionVendedor mCamion = Consultas.ConsultasKilometraje.obtenerCamion(Placas);
			if (!mCamion.Placa.equals(""))
			{
				mVista.setPlacaClave(mCamion.Placa, mCamion.Clave);
			}
			else
			{
				return false;
			}
		}
		catch (Exception e)
		{
			return false;
		}
		return true;
	}

	public void asignarValoresCamion(String Placa, String KMInicial, String KMFinal, String LitrosGasolina, String ImporteGasolina)
	{
		try
		{
			if (mCamionVendedor.KmInicial == 0 && mCamionVendedor.KmFinal == 0)
			{
				if (Float.parseFloat(KMInicial) <= 0)
				{
					mVista.mostrarError(Mensajes.get("E0012"));
					return;
				}
				CamionVendedor mCamionVendedor = Consultas.ConsultasKilometraje.obtenerCamiondeVendedor(Placa);
                if (((int) mCamionVendedor.KmFinal) > Integer.parseInt(KMInicial)) {
                    //mVista.mostrarError(Mensajes.get("E0716").replace("$0$", "Kilometraje Inicial").replace("$1$", "Final Anterior"));
                    mVista.mostrarError(Mensajes.get("E0920"));
                    return;
                }
                mCamionVendedor = Transacciones.Kilometraje.GenerarCamionVendedor(Placa, Float.parseFloat(KMInicial));
				BDVend.guardarInsertar(mCamionVendedor);

			}
			else if (mCamionVendedor.KmInicial != 0 && mCamionVendedor.KmFinal == 0)
			{
                if (Float.parseFloat(KMInicial) >= Float.parseFloat(KMFinal)) {
                    mVista.mostrarError(Mensajes.get("E0716").replace("$0$", "Kilometraje Inicial").replace("$1$", "Final Anterior"));
                }
                CamionVendedor mCamionVendedor1 = new CamionVendedor();
				mCamionVendedor1.CAMVENId = mCamionVendedor.CAMVENId;
				BDVend.recuperar(mCamionVendedor1);
				mCamionVendedor1 = Transacciones.Kilometraje.GenerarCamionVendedorFinal(mCamionVendedor1, Float.parseFloat(KMFinal), Float.parseFloat(LitrosGasolina), Float.parseFloat(ImporteGasolina));
				BDVend.guardarInsertar(mCamionVendedor1);
			}
			BDVend.commit();
			mVista.finalizar();
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	}
}
