package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;

public interface ICapturaKilometraje extends IVista
{

	public void setCapturaInicial(boolean isTrue);

	public void setPlacaClave(String Placa, String Clave);

	public void setValores(String Placa, String Clave, String KMInicial);

}
