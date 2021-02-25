package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;

public interface ICapturaDeposito extends IVista
{
	public void setTotalEfyDep(float Total);

	public void setTotalDevoluciones(float Total);

	public void setTotalDeposito(float Total);

	public void setTotalDepositar(float Total);

	public void refrescarDeposito();

	public void setLimpiarDeposito();
}
