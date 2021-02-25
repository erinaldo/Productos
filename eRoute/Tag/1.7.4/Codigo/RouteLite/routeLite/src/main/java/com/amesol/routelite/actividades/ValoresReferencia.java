package com.amesol.routelite.actividades;

import java.security.acl.Group;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Map;
import java.util.Hashtable;

import android.annotation.SuppressLint;

import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.google.android.gms.location.places.AutocompletePrediction;

public class ValoresReferencia
{

	private static Map<String, Map<String, ValorReferencia>> valores = null;

	private static synchronized Map<String, Map<String, ValorReferencia>> get()
	{
		if (valores == null)
		{
			valores = new Hashtable<String, Map<String, ValorReferencia>>();
			try
			{
				ISetDatos setdatos = Consultas.ConsultasValorReferencia.obtenerValores();
				int iVarCodigo = setdatos.getColumnIndex("VARCodigo");
				int iVavClave = setdatos.getColumnIndex("VAVClave");
				int iGrupo = setdatos.getColumnIndex("Grupo");
				int iDescripcion = setdatos.getColumnIndex("Descripcion");
				while (setdatos.moveToNext())
				{
					String VARCodigo = setdatos.getString(iVarCodigo);
					if (VARCodigo == null)
						VARCodigo = "";
					else
						VARCodigo = VARCodigo.toUpperCase().trim();
					if (VARCodigo.equals("TCARSU"))
						VARCodigo = "TCARSU";
					String VAVClave = setdatos.getString(iVavClave);
					if (VAVClave == null)
						VAVClave = "";
					else
						VAVClave = VAVClave.toUpperCase().trim();
					String Grupo = setdatos.getString(iGrupo);
					if (Grupo == null)
						Grupo = "";
					else
						Grupo = Grupo.toUpperCase().trim();
					String Descripcion = setdatos.getString(iDescripcion);
					if (Descripcion == null)
						Descripcion = "";

					Map<String, ValorReferencia> claves = null;
					if (!valores.containsKey(VARCodigo))
					{
						claves = new Hashtable<String, ValorReferencia>();
						valores.put(VARCodigo, claves);
					}
					else
						claves = valores.get(VARCodigo);
					claves.put(VAVClave, new ValorReferencia(VARCodigo, VAVClave, Descripcion, Grupo));

				}
				setdatos.close();
			}
			catch (Exception e)
			{
				e.printStackTrace();
			}
		}
		return valores;
	}

	public static synchronized void actualizarValoresReferencia()
	{
		valores = new Hashtable<String, Map<String, ValorReferencia>>();
		try
		{
			ISetDatos setdatos = Consultas.ConsultasValorReferencia.obtenerValores();
			int iVarCodigo = setdatos.getColumnIndex("VARCodigo");
			int iVavClave = setdatos.getColumnIndex("VAVClave");
			int iGrupo = setdatos.getColumnIndex("Grupo");
			int iDescripcion = setdatos.getColumnIndex("Descripcion");
			while (setdatos.moveToNext())
			{
				String VARCodigo = setdatos.getString(iVarCodigo);
				if (VARCodigo == null)
					VARCodigo = "";
				else
					VARCodigo = VARCodigo.toUpperCase().trim();
				if (VARCodigo.equals("TCARSU"))
					VARCodigo = "TCARSU";
				String VAVClave = setdatos.getString(iVavClave);
				if (VAVClave == null)
					VAVClave = "";
				else
					VAVClave = VAVClave.toUpperCase().trim();
				String Grupo = setdatos.getString(iGrupo);
				if (Grupo == null)
					Grupo = "";
				else
					Grupo = Grupo.toUpperCase().trim();
				String Descripcion = setdatos.getString(iDescripcion);
				if (Descripcion == null)
					Descripcion = "";

				Map<String, ValorReferencia> claves = null;
				if (!valores.containsKey(VARCodigo))
				{
					claves = new Hashtable<String, ValorReferencia>();
					valores.put(VARCodigo, claves);
				}
				else
					claves = valores.get(VARCodigo);
				claves.put(VAVClave, new ValorReferencia(VARCodigo, VAVClave, Descripcion, Grupo));

			}
			setdatos.close();
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}

	public static ValorReferencia[] getValores(String VARCodigo)
	{
		VARCodigo = VARCodigo.toUpperCase().trim();
		Map<String, ValorReferencia> valores = get().get(VARCodigo);
		if (valores != null)
		{
			return valores.values().toArray(new ValorReferencia[valores.values().size()]);
		}
		return null;
	}

	public static ValorReferencia[] getValores(String VARCodigo, String Grupo, String... exceptoGrupo)
	{
		VARCodigo = VARCodigo.toUpperCase().trim();
		if (Grupo != null)
			Grupo = Grupo.toUpperCase().trim();
		if (exceptoGrupo != null)
		{
			for (int i = 0; i < exceptoGrupo.length; i++)
				exceptoGrupo[i] = exceptoGrupo[i].toUpperCase().trim();
		}
		Map<String, ValorReferencia> valores = get().get(VARCodigo);
		if (valores != null)
		{
			ArrayList<ValorReferencia> lista = new ArrayList<ValorReferencia>();
			for (ValorReferencia v : valores.values())
			{
				if ((Grupo != null) && (!v.getGrupo().equals(Grupo)))
					continue;
				if ((exceptoGrupo != null) && (v.getGrupo() != null) && (Arrays.binarySearch(exceptoGrupo, v.getGrupo()) == 0))
					continue;
				/*if((VARCodigo.equals("ACTROL") && Grupo.equals("INVENTARIO") && v.getVavclave().equals("26")) && !(((Ruta) Sesion.get(Campo.RutaActual)).Inventario && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)){
					continue;
				}*/
				lista.add(v);
			}
			return lista.toArray(new ValorReferencia[lista.size()]);
		}
		return null;
	}

    public static String getCadenaValores(String VARCodigo, String Grupo)
    {
        VARCodigo = VARCodigo.toUpperCase().trim();
        if (Grupo != null)
            Grupo = Grupo.toUpperCase().trim();

        Map<String, ValorReferencia> valores = get().get(VARCodigo);
        if (valores != null)
        {
            String valoresRes = "";
            for (ValorReferencia v : valores.values())
            {
                if ((Grupo != null) && (!v.getGrupo().equals(Grupo)))
                    continue;
				/*if((VARCodigo.equals("ACTROL") && Grupo.equals("INVENTARIO") && v.getVavclave().equals("26")) && !(((Ruta) Sesion.get(Campo.RutaActual)).Inventario && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)){
					continue;
				}*/
                valoresRes += v.getVavclave() + ",";
            }
            if (valoresRes.length()>0){
                valoresRes = valoresRes.substring(0, valoresRes.length() -1);
            }

            return valoresRes;
        }
        return "";
    }


    public static ValorReferencia getValor(String VARCodigo, String VAVClave)
	{
		VARCodigo = VARCodigo.toUpperCase().trim();
		VAVClave = VAVClave.toUpperCase().trim();
		Map<String, ValorReferencia> valores = get().get(VARCodigo);
		if (valores != null)
		{
			return valores.get(VAVClave);
		}
		return null;
	}

	public static String getDescripcion(String VARCodigo, String VAVClave)
	{
		VARCodigo = VARCodigo.toUpperCase().trim();
		VAVClave = VAVClave.toUpperCase().trim();
		Map<String, ValorReferencia> valores = get().get(VARCodigo);
		if (valores != null)
		{
			ValorReferencia valRef = valores.get(VAVClave);
			if (valRef != null)
				return valRef.getDescripcion();
		}
		return "";
	}

	// Devuelve un string separado por comas con los VAVClave solicitados
	public static String getStringVAVClave(String VARCodigo, String Grupo)
	{
		VARCodigo = VARCodigo.toUpperCase().trim();
		if (Grupo != null)
			Grupo = Grupo.toUpperCase().trim();

		Map<String, ValorReferencia> valores = get().get(VARCodigo);
		if (valores != null)
		{
			String lista = "";
			for (ValorReferencia v : valores.values())
			{
				if ((Grupo != null) && (!v.getGrupo().equals(Grupo)))
					continue;
				lista += v.getVavclave() + ",";
				// lista.add(v);
			}
			if (lista.length() > 0)
			{
				lista = lista.substring(0, lista.length() - 1);
			}
			return lista;
		}
		return null;
	}

}
