package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;

public interface ICapturaPreLiquidacion extends IVista
{
	void llenarValores(String var1, String var2);

	void refrescarEfectivo(String PLIId);

	void refrescarDeposito(String PLIId);

	void setLimpiarEfectivo();

	void setLimpiarDeposito();

	void setTotales(float Efectivo, float Deposito);

	void setError(boolean isError);

}
