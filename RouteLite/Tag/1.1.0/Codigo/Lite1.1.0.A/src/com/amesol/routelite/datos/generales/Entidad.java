package com.amesol.routelite.datos.generales;

import java.lang.reflect.Field;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import android.R.integer;
import android.content.ContentValues;
import android.os.Parcelable;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.basedatos.BaseDatos;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.ParametroMSG;

public abstract class Entidad
{

	private HashMap<String, Object> recuperado = null;

	public boolean isRecuperado()
	{
		return recuperado != null;
	}

	public void quitarRecuperado()
	{
		recuperado = null;
	}
	
	public void setValoresOriginales(HashMap<String, Object> original)
	{
		recuperado = original;
	}

	public void setValores(ContentValues valores) throws Exception
	{
		for (Field campo : getClass().getFields())
		{
			String nombreCampo = BaseDatos.obtenerNombreCampoSolo(campo);
			if (valores.containsKey(nombreCampo))
			{
				if (valores.get(nombreCampo) == null)
				{
					campo.set(this, null);
				}
				else if (campo.getType().equals(String.class))
				{
					campo.set(this, valores.get(nombreCampo).toString());
				}
				else if (campo.getType().equals(Integer.class))
				{
					campo.set(this, Integer.parseInt(valores.get(nombreCampo).toString()));
				}
				else if (campo.getType().equals(int.class))
				{
					campo.setInt(this, Integer.parseInt(valores.get(nombreCampo).toString()));
				}
				else if (campo.getType().equals(Float.class))
				{
					campo.set(this, Float.parseFloat(valores.get(nombreCampo).toString()));
				}
				else if (campo.getType().equals(float.class))
				{
					campo.setFloat(this, Float.parseFloat(valores.get(nombreCampo).toString()));
				}
				else if (campo.getType().equals(Double.class))
				{
					campo.setDouble(this, Double.parseDouble(valores.get(nombreCampo).toString()));
				}
				else if (campo.getType().equals(double.class))
				{
					campo.setDouble(this, Double.parseDouble(valores.get(nombreCampo).toString()));
				}
				else if (campo.getType().equals(Byte[].class))
				{
					campo.setByte(this, Byte.parseByte(valores.get(nombreCampo).toString()));
				}
				else if (campo.getType().equals(byte[].class))
				{
					campo.setByte(this, Byte.parseByte(valores.get(nombreCampo).toString()));
				}
				else if (campo.getType().equals(Long.class))
				{
					campo.setLong(this, Long.parseLong(valores.get(nombreCampo).toString()));
				}
				else if (campo.getType().equals(long.class))
				{
					campo.setLong(this, Long.parseLong(valores.get(nombreCampo).toString()));
				}
				else if (campo.getType().equals(Short.class))
				{
					campo.set(this, Short.parseShort(valores.get(nombreCampo).toString()));
				}
				else if (campo.getType().equals(short.class))
				{
					campo.setShort(this, Short.parseShort(valores.get(nombreCampo).toString()));
				}
				else if (campo.getType().equals(Date.class))
				{
					SimpleDateFormat origen = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");					
					try
					{
						campo.set(this, (Date) origen.parse(valores.get(nombreCampo).toString()));
					}
					catch (ParseException e)
					{
						try{
							SimpleDateFormat origen2 = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ssZ");	
							Date fecha = (Date) origen2.parse(valores.get(nombreCampo).toString());
							campo.set(this, (Date)origen.parse(origen.format(fecha)));
						}catch (ParseException e2){
							try{
								SimpleDateFormat origen3 = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSSZ");	
								Date fecha = (Date) origen3.parse(valores.get(nombreCampo).toString());
								campo.set(this, (Date)origen.parse(origen.format(fecha)));								
							}catch(ParseException e3){
								throw e3;
							}

						}
												
						// TODO Auto-generated catch block
					}

				}
				else if (campo.getType().equals(Boolean.class) || campo.getType().equals(boolean.class))
				{
					campo.set(this, Boolean.parseBoolean(valores.get(nombreCampo).toString()));
				}
				else
				{
					campo.set(this, valores.get(nombreCampo).toString());
				}
			}
		}
	}

	public void validar() throws ControlError
	{
		for (final Field campo : this.getClass().getFields())
		{
			if (campo.isAnnotationPresent(Requerido.class))
			{
				Object valor = null;
				try
				{
					valor = campo.get(this);
				}
				catch (Exception e)
				{
					e.printStackTrace();
				}
				if (valor == null)
				{
					Campo defCampo = campo.getAnnotation(Campo.class);
					ArrayList<ParametroMSG> params = new ArrayList<ParametroMSG>();
					params.add(new ParametroMSG((defCampo.msgDescripcion().equals("") ? campo.getName() : defCampo.msgDescripcion()), (defCampo.msgDescripcion().equals("") ? false : true)));
					throw new ControlError("BE0001", params, this.getClass().getSimpleName(), campo.getName());
				}
			}
		}
	}

	public static void validar(Entidad entidad) throws ControlError
	{
		for (final Field campo : entidad.getClass().getFields())
		{
			if (campo.isAnnotationPresent(Requerido.class))
			{
				Object valor = null;
				try
				{
					valor = campo.get(entidad);
				}
				catch (Exception e)
				{
					e.printStackTrace();
				}
				if (valor == null)
				{
					Campo defCampo = campo.getAnnotation(Campo.class);
					ArrayList<ParametroMSG> params = new ArrayList<ParametroMSG>();
					params.add(new ParametroMSG((defCampo.msgDescripcion().equals("") ? campo.getName() : defCampo.msgDescripcion()), (defCampo.msgDescripcion().equals("") ? false : true)));
					throw new ControlError("BE0001", params, entidad.getClass().getSimpleName(), campo.getName());
				}
			}
		}
		validarHijos(entidad);
	}

	private static void validarHijos(Entidad entidad) throws ControlError
	{
		for (Field campo : entidad.getClass().getFields())
		{
			if (campo.isAnnotationPresent(Hijos.class))
			{
				Object obj = null;
				try
				{
					obj = campo.get(entidad);
				}
				catch (Exception e)
				{
					e.printStackTrace();
				}

				if (obj != null)
				{
					List<Entidad> hijos = (List<Entidad>) obj;
					for (Entidad ent : hijos)
					{
						validar(ent);
					}
				}
			}
		}
	}

	public HashMap<String, Object> getOriginales()
	{
		return recuperado;
	}

	public String filtroEliminacionPorEstado(ContentValues valores, String nombreTabla)
	{
		String filtroEliminacion = "";
		if (valores.containsKey("TipoEstado"))
		{
			filtroEliminacion = "TipoEstado = 0";
		}
		else if (valores.containsKey("Estado"))
		{
			filtroEliminacion = "Estado = 0";
		}
		else if (valores.containsKey("TipoFase") && !nombreTabla.toUpperCase().equals("TRANSPROD"))
		{
			filtroEliminacion = "TipoFase <> 1";
		}

		if (valores.containsKey("Baja"))
		{
			if (filtroEliminacion != "")
			{
				filtroEliminacion += " OR ";
			}
			filtroEliminacion += "Baja = 1";
		}

		return filtroEliminacion;
	}

	public String filtroEliminacionPorEstado(String nombreTabla)
	{
		String filtroEliminacion = "";
		
		for (Field campo : getClass().getFields())
		{
			if (campo.getName().equalsIgnoreCase("TipoEstado"))
			{
				filtroEliminacion = "TipoEstado = 0";
				break;
			}
			else if (campo.getName().equalsIgnoreCase("Estado"))
			{
				filtroEliminacion = "Estado = 0";
				break;
			}
			else if (campo.getName().equalsIgnoreCase("TipoFase") && !nombreTabla.toUpperCase().equals("TRANSPROD"))
			{
				filtroEliminacion = "TipoFase <> 1";
				break;
			}			
			if (campo.getName().equalsIgnoreCase("Baja"))
			{
				if (filtroEliminacion != "")
				{
					filtroEliminacion += " OR ";
				}
				filtroEliminacion += "Baja = 1";
				break;
			}
			
		}

		return filtroEliminacion;
	}

}
