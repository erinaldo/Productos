package com.duxstar.dacza.providers;

import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionOrden;

import android.content.ContentProvider;
import android.content.ContentValues;
import android.content.Intent;
import android.content.pm.PackageInstaller;
import android.database.Cursor;
import android.net.Uri;

public class BusquedaProvider extends ContentProvider {
	
	//IAtencionClientes mVista;
	//AtenderClientes mPresenta;

	@Override
	public int delete(Uri arg0, String arg1, String[] arg2) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public String getType(Uri arg0) {
		// TODO Auto-generated method stub 
		return null;
	}

	@Override
	public Uri insert(Uri arg0, ContentValues arg1) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean onCreate() {
		// TODO Auto-generated method stub
		//mPresenta = new AtenderClientes(mVista, Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_CLIENTE);
		return true;
	}

	@Override
	public Cursor query(Uri arg0, String[] arg1, String arg2, String[] arg3,
			String arg4) {
		// TODO Auto-generated method stub


		String filtro = null;
		if (arg0.getPathSegments().size() > 1)
			filtro = arg0.getLastPathSegment();
		if((filtro!=null)&&(filtro.length()> 2))
		{
			try
			{
                ISetDatos dsDatos;
                if (Sesion.get(Sesion.Campo.TipoCodigoActual) == Enumeradores.TIPOCODIGO.CLIENTE) {
                    String filtroOrig = null;
                    if (Sesion.get(Sesion.Campo.FiltroCliente) != null)
                        filtroOrig = Sesion.get(Sesion.Campo.FiltroCliente).toString();
                    dsDatos = buscarClientes(filtroOrig, filtro);
                }
                else if (Sesion.get(Sesion.Campo.TipoCodigoActual) == Enumeradores.TIPOCODIGO.AGENTE)
                    dsDatos = buscarAgentes(filtro);
                else
                    dsDatos = buscarVin(filtro);

				return (Cursor)dsDatos.getOriginal();
			}
			catch (Exception e)
			{
				e.printStackTrace();
				return null;
			}
		}
		return null;
	}

	@Override
	public int update(Uri arg0, ContentValues arg1, String arg2, String[] arg3) {
		// TODO Auto-generated method stub
		return 0;
	}
	
	public ISetDatos buscarClientes(String filtroOrig, String filtro) throws Exception
	{
        return Consultas.ConsultasCliente.obtenerTodos(filtroOrig, filtro);
	}

    public ISetDatos buscarAgentes(String filtro) throws Exception
    {
        return Consultas.ConsultasUsuario.obtenerTodos(filtro);
    }

    public ISetDatos buscarVin(String filtro) throws Exception
    {
        String clienteId = ((Cliente) Sesion.get(Sesion.Campo.ClienteActual)).ClienteId;
        return Consultas.ConsultasVin.obtenerTodos(filtro, clienteId);
    }

}
