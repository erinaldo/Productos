package com.amesol.routelite.presentadores.interfaces;


import com.amesol.routelite.presentadores.IVista;

public interface IObtencionGPS extends IVista {

	void SetProgreso(Integer Pro);
	void SetDatos(String Datos);
	void mostrarConfiguracionGPS();
	//void HabilitarWiFi(boolean habilitado);
	/*void EncenderGPS();
	void ApagarGPS();*/
}