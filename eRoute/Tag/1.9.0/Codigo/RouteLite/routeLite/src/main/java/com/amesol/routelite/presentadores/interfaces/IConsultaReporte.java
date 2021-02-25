package com.amesol.routelite.presentadores.interfaces;

import android.widget.ListView;

import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.presentadores.IVista;

import java.util.ArrayList;
import java.util.Date;

public interface IConsultaReporte extends IVista
{
	public int getReporteId();

    public Date getFechaIni();

    public Date getFechaFin();

    public int getBFNUMERI();

    public Cliente getCliente();

    public ArrayList<Cliente> getClientes();

    public String getDiaClave();

    public void setCliente(Cliente cliente);

    public ListView getListaCtes();

    public void setVieneDeImpresion(Boolean vieneDeImpresion);

}
