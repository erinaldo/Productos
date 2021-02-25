package com.amesol.routelite.datos.basedatos;

import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.PushbackInputStream;
import java.io.Reader;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.HashMap;
import java.util.List;

import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;

import org.w3c.dom.Document;
import org.w3c.dom.NodeList;
import org.xmlpull.v1.XmlPullParser;

import android.content.ContentValues;
import android.util.Log;
import android.util.Xml;

import com.amesol.routelite.datos.FrecuenciaExcep;
import com.amesol.routelite.datos.Inventario;
import com.amesol.routelite.datos.PrecioProductoVig;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.ProductoDetalle;
import com.amesol.routelite.datos.ProductoEsquema;
import com.amesol.routelite.datos.ProductoImpuesto;
import com.amesol.routelite.datos.ProductoUnidad;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.VendedorMensaje;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.utilerias.Generales;

import dalvik.system.BaseDexClassLoader;

public class Recepcion
{
	private static ArrayList<String> tablasEliminar;
	public static final List<String> TABLAS_RECARGA =Arrays.asList("TransProd","TransProdDetalle","Producto","PrecioProductoVig","ProductoDetalle", "ProductoEsquema", "ProductoImpuesto", "ProductoUnidad" );
    public static final List<String> TABLAS_PRECIOS =Arrays.asList("Precio","PrecioProductoVig","Esquema","ClienteEsquema","PrecioClienteEsquema", "Producto", "ProductoUnidad","ProductoDetalle","ProductoImpuesto");

	public static boolean procesarDataSet(String nombreArchivo, int tipoBD, Document xmlActualiza, boolean bRecarga) throws Exception
	{
		try
		{
			ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
			File archivoBD = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
			archivoBD = new File(archivoBD, "bd");

			File dataset = new File(archivoBD, nombreArchivo);

			tablasEliminar = new ArrayList<String>();

			File dirXml;
			BaseDatos bd;
			ISetDatos sd = null;
			if (tipoBD == Enumeradores.TipoBD.BD_TERMINAL)
			{
				bd = BDTerm.getBD();
				sd = BDTerm.consultar("Select Nombre from Tabla where Grupo = 2 and TipoBase = 1");
				dirXml = new File(archivoBD, BDTerm.nombreBaseDatos().replace(".db", ".xml"));
			}
			else
			{
				bd = BDVend.getBD();
				sd = BDTerm.consultar("Select Nombre from Tabla where Grupo = 2 and TipoBase = 2");
				dirXml = new File(archivoBD, BDVend.nombreBaseDatos().replace(".db", ".xml"));
			}
			if (sd != null)
			{
				while (sd.moveToNext())
				{
					tablasEliminar.add(sd.getString(0));
				}
			}
			sd.close();

			XmlPullParser parser = Xml.newPullParser();
			try
			{
				InputStream is = new FileInputStream(dataset);
				//				InputStreamReader isr = new InputStreamReader(fIn, "UTF-8");

				Reader reader = new InputStreamReader(checkForUtf8BOMAndDiscardIfAny(is));
				parser.setInput(reader);
				//				parser.setInput(new StringReader(xmlAsString.toString()));
				//				parser.setInput(isr);
				// auto-detect the encoding from the stream    
				int eventType = 0;
				for (int type = parser.getEventType(); type != XmlPullParser.START_TAG; type = parser.next())
				{
					Log.e("", "" + type);
				}

				//Category currentCategory = null;  
				boolean done = false;

				String nombreTabla = "";
				String nombreCampoActual = "";
				String valorCampoActual = "";
				String listadoCampos = "";
				boolean bTablaNueva = false;
				ContentValues valoresCampos = new ContentValues();

				Class tablaClase;
				Entidad entidad = null;
				SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");
				boolean tablaLimpia = false;

				ContentValues fechasActualizacion = new ContentValues();

				while (eventType != XmlPullParser.END_DOCUMENT && !done)
				{
					switch (eventType)
					{
						case XmlPullParser.START_DOCUMENT:
							break;
						case XmlPullParser.TEXT:
							valorCampoActual = parser.getText();
							break;
						case XmlPullParser.START_TAG:
							//Si es tabla						
							if (parser.getDepth() == 2)
							{
								if (!nombreTabla.equals(parser.getName()))
								{
									if (!nombreTabla.equals(""))
									{
										if (!tablaLimpia)
										{
											String filtroEliminacion = entidad.filtroEliminacionPorEstado(valoresCampos, nombreTabla);
											if (filtroEliminacion != "")
											{
												bd.eliminar(entidad, filtroEliminacion);
											}
										}
										Calendar cal = new GregorianCalendar();
										Date date = cal.getTime();
										String formatteDate = df.format(date);
										fechasActualizacion.put(nombreTabla, formatteDate);

									}
									bTablaNueva = true;
									listadoCampos = "";
									nombreTabla = parser.getName();
									tablaClase = Class.forName("com.amesol.routelite.datos." + nombreTabla);
									entidad = (Entidad) tablaClase.newInstance();
									if (tablasEliminar.contains(nombreTabla) && !bRecarga )
									{
										tablaLimpia = true;
										bd.eliminarTodo(entidad);
									}
									else
									{
										tablaLimpia = false;
									}
								}
								valoresCampos.clear();
							}
							else if (parser.getDepth() == 3)
							{
								nombreCampoActual = parser.getName();
							}
							break;
						case XmlPullParser.END_TAG:
							if (parser.getDepth() == 2)
							{
								bTablaNueva = false;
								if (tablaLimpia)
								{
									bd.COMInsertarSinHijos(nombreTabla, listadoCampos, valoresCampos);
								}
								else
								{
									entidad.setValores(valoresCampos);
									if (bd.existe(entidad))
									{
										bd.recuperar(entidad);
										entidad.setValores(valoresCampos);
										bd.COMguardarSinHijos(entidad);
									}
									else
									{
										bd.COMInsertarSinHijos(nombreTabla, listadoCampos, valoresCampos);
									}
								}
							}
							else if (parser.getDepth() == 3)
							{
								if (bTablaNueva)
								{
									listadoCampos += "\"" + nombreCampoActual + "\",";
								}
								if (valorCampoActual.equalsIgnoreCase("true") || valorCampoActual.equalsIgnoreCase("false"))
								{
									valoresCampos.put(nombreCampoActual, (valorCampoActual.equalsIgnoreCase("true") ? 1 : 0));
								}
								else
								{
									valoresCampos.put(nombreCampoActual, valorCampoActual);									
								}
								valorCampoActual = "";

							}

							break;
					}

					//Falla Aqui
					eventType = parser.next();
				}

				if (!nombreTabla.equals(""))
				{
					if (!tablaLimpia)
					{
						String filtroEliminacion = entidad.filtroEliminacionPorEstado(valoresCampos, nombreTabla);
						if (filtroEliminacion != "")
						{
							bd.eliminar(entidad, filtroEliminacion);
						}
					}
					Calendar cal = new GregorianCalendar();
					Date date = cal.getTime();
					String formatteDate = df.format(date);
					fechasActualizacion.put(nombreTabla, formatteDate);
				}

				NodeList tablas = xmlActualiza.getFirstChild().getChildNodes();

				for (int i = 0; i <= tablas.getLength() - 1; i++)
				{
					nombreTabla = tablas.item(i).getChildNodes().item(0).getTextContent();
					if (fechasActualizacion.containsKey(nombreTabla))
					{
						tablas.item(i).getChildNodes().item(1).setTextContent(fechasActualizacion.get(nombreTabla).toString());
					}
				}
				bd.commit();

				TransformerFactory transformerFactory = TransformerFactory.newInstance();
				Transformer transformer = transformerFactory.newTransformer();
				DOMSource source = new DOMSource(xmlActualiza);
				StreamResult result = new StreamResult(dirXml);

				//				fIn.close();
				transformer.transform(source, result);
				return true;
			}

			catch (FileNotFoundException e)
			{
				bd.rollback();
				throw e;
			}
			catch (IOException e)
			{
				bd.rollback();
				throw e;
			}
			catch (Exception e)
			{
				bd.rollback();
				throw e;
			}

		}
		catch (Exception e)
		{
			throw e;
		}

	}
	
	public static boolean procesarInfoRecibida(String nombreArchivo, int tipoBD, Document xmlActualiza, boolean bRecarga, boolean bPrecios) throws Exception
	{
		try
		{
			//Cuando en el menú de actualizar se agreguen mas menus ademas del de Vendedor y Recarga, tendra que 
			//cambiarse lo de la limpieza de tablas
			ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

			File archivoBD = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
			archivoBD = new File(archivoBD, "bd");		
			archivoBD = new File(archivoBD,nombreArchivo);		
			if(!archivoBD.exists()) return false;
			BaseDatos tmpActualizacion = new BaseDatos(archivoBD.getAbsolutePath());
			tmpActualizacion.crearInstancia();	
			

			//File dataset = new File(archivoBD, nombreArchivo);

			tablasEliminar = new ArrayList<String>();

			File dirXml = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
			dirXml  = new File(dirXml, "bd");	
			
			BaseDatos bd;
			ISetDatos sd = null;
			if (tipoBD == Enumeradores.TipoBD.BD_TERMINAL)
			{
				bd = BDTerm.getBD();
				sd = BDTerm.consultar("Select Nombre from Tabla where Grupo = 2 and TipoBase = 1");
				dirXml = new File(dirXml, BDTerm.nombreBaseDatos().replace(".db", ".xml"));
			}
			else
			{
				bd = BDVend.getBD();
				sd = BDTerm.consultar("Select Nombre from Tabla where Grupo = 2 and TipoBase = 2");
				dirXml = new File(dirXml, BDVend.nombreBaseDatos().replace(".db", ".xml"));
			}
			if (sd != null)
			{
				while (sd.moveToNext())
				{
					if (!TABLAS_RECARGA.contains(sd.getString(0)) && !TABLAS_PRECIOS.contains(sd.getString(0)))
						tablasEliminar.add(sd.getString(0));
				}
			}
			sd.close();

            Entidad entidad = null;
			try
			{
				ISetDatos tablas = Consultas.ConsultasMaster.obtenerTablas(tmpActualizacion);
				Class tablaClase;
								
				SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

				ContentValues fechasActualizacion = new ContentValues();
				boolean tablaLimpia = false;
				while(tablas.moveToNext()){
					ISetDatos registros = Consultas.ConsultasMaster.obtenerRegistrosTabla(tmpActualizacion, tablas.getString("name"));	
					tablaClase = Class.forName("com.amesol.routelite.datos." + tablas.getString("name"));
					if (tablasEliminar.contains(tablas.getString("name")) )
					{											
						tablaLimpia = true;
						bd.eliminarTodo(tablaClase);
					}
					else
					{
						tablaLimpia = false;
					}
					while(registros.moveToNext()){
						//La tabla Vendedor es una excepcion porque no actualiza todos los datos
						if (tablas.getString("name").equalsIgnoreCase("Vendedor")){
							entidad = new Vendedor();
							((Vendedor)entidad).VendedorId = registros.getString("VendedorId");							
							bd.recuperar(entidad);
							((Vendedor)entidad).Nombre = registros.getString("Nombre"); 
							((Vendedor)entidad).MostrarEsquema = registros.getBoolean("MostrarEsquema"); 
							((Vendedor)entidad).TipoModImp =  registros.getShort("TipoModImp"); 
							((Vendedor)entidad).GPS =  registros.getBoolean("GPS");
							bd.guardarInsertar(entidad);
						}else{
							entidad = (Entidad) tmpActualizacion.instanciar(tablaClase, registros);
							//se le quita es estado de recuperado porque si no, no lo inserta en la otra BD

                            if (!bd.existe(entidad)){
                                entidad.quitarRecuperado();
                            }
                            bd.guardarInsertar(entidad);
                        }
					}		

					if (!tablaLimpia)
					{
						String filtroEliminacion = entidad.filtroEliminacionPorEstado(tablas.getString("name"));
						if (filtroEliminacion != "")
						{
							bd.eliminar(entidad, filtroEliminacion);
						}
					}
					
					Calendar cal = new GregorianCalendar();
					Date date = cal.getTime();
					String formatteDate = df.format(date);
					fechasActualizacion.put(tablas.getString("name"), formatteDate);
					registros.close();
				}				
				tablas.close();
				
				NodeList tablasXml = xmlActualiza.getFirstChild().getChildNodes();
				String nombreTabla;
				for (int i = 0; i <= tablasXml.getLength() - 1; i++)
				{
					nombreTabla = tablasXml.item(i).getChildNodes().item(0).getTextContent();
					if (fechasActualizacion.containsKey(nombreTabla))
					{
						tablasXml.item(i).getChildNodes().item(1).setTextContent(fechasActualizacion.get(nombreTabla).toString());
					}
				}
				
				bd.commit();
				tmpActualizacion.cerrar();
				TransformerFactory transformerFactory = TransformerFactory.newInstance();
				Transformer transformer = transformerFactory.newTransformer();
				DOMSource source = new DOMSource(xmlActualiza);
				StreamResult result = new StreamResult(dirXml);

				//				fIn.close();
				transformer.transform(source, result);
				return true;
			}

			catch (FileNotFoundException e)
			{
				bd.rollback();
				if (tmpActualizacion.estaAbierta()){
					tmpActualizacion.cerrar();
				}
				throw e;
			}
			catch (IOException e)
			{
				bd.rollback();
				if (tmpActualizacion.estaAbierta()){
					tmpActualizacion.cerrar();
				}
                if (e== null){
                    throw new Exception("Error de nulos");
                }else{
                    throw e;
                }

			}
			catch (Exception e)
			{
				bd.rollback();
				if (tmpActualizacion.estaAbierta()){
					tmpActualizacion.cerrar();
				}
                if (e== null){
                    throw new Exception("Error de nulos");
                }else{
                    throw e;
                }
			}

		}
		catch (Exception e)
		{
            if (e== null){
                throw new Exception("Error de nulos");
            }else{
                throw e;
            }
		}

	}
	
	public static boolean procesarDataSetInventario(String nombreArchivo, Document xmlActualiza) throws Exception
	{
		try
		{
			ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
			File archivoBD = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
			archivoBD = new File(archivoBD, "bd");

			File dataset = new File(archivoBD, nombreArchivo);

			tablasEliminar = new ArrayList<String>();

			File dirXml;
			BaseDatos bd;
			ISetDatos sd = null;
			/*if (tipoBD == Enumeradores.TipoBD.BD_TERMINAL)
			{
				bd = BDTerm.getBD();
				sd = BDTerm.consultar("Select Nombre from Tabla where Grupo = 2 and TipoBase = 1");
				dirXml = new File(archivoBD, BDTerm.nombreBaseDatos().replace(".db", ".xml"));
			}
			else
			{*/
				bd = BDVend.getBD();
				sd = BDTerm.consultar("Select Nombre from Tabla where Grupo = 2 and TipoBase = 2");
				dirXml = new File(archivoBD, BDVend.nombreBaseDatos().replace(".db", ".xml"));
			/*}
			if (sd != null)
			{
				while (sd.moveToNext())
				{
					tablasEliminar.add(sd.getString(0));
				}
			}
			sd.close();*/

			XmlPullParser parser = Xml.newPullParser();
			try
			{
				InputStream is = new FileInputStream(dataset);
				//				InputStreamReader isr = new InputStreamReader(fIn, "UTF-8");

				Reader reader = new InputStreamReader(checkForUtf8BOMAndDiscardIfAny(is));
				parser.setInput(reader);
				//				parser.setInput(new StringReader(xmlAsString.toString()));
				//				parser.setInput(isr);
				// auto-detect the encoding from the stream    
				int eventType = 0;
				for (int type = parser.getEventType(); type != XmlPullParser.START_TAG; type = parser.next())
				{
					Log.e("", "" + type);
				}

				//Category currentCategory = null;  
				boolean done = false;

				String nombreTabla = "";
				String nombreCampoActual = "";
				String valorCampoActual = "";
				String listadoCampos = "";
				boolean bTablaNueva = false;
				ContentValues valoresCampos = new ContentValues();

				Class tablaClase;
				Entidad entidad = null;
				SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");
				boolean tablaLimpia = false;

				ContentValues fechasActualizacion = new ContentValues();

				while (eventType != XmlPullParser.END_DOCUMENT && !done)
				{
					switch (eventType)
					{
						case XmlPullParser.START_DOCUMENT:
							break;
						case XmlPullParser.TEXT:
							valorCampoActual = parser.getText();
							break;
						case XmlPullParser.START_TAG:
							//Si es tabla						
							if (parser.getDepth() == 2)
							{
								if (!nombreTabla.equals(parser.getName()))
								{
									/*if (!nombreTabla.equals(""))
									{
										if (!tablaLimpia)
										{
											String filtroEliminacion = entidad.filtroEliminacionPorEstado(valoresCampos);
											if (filtroEliminacion != "")
											{
												bd.eliminar(entidad, filtroEliminacion);
											}
										}
										Calendar cal = new GregorianCalendar();
										Date date = cal.getTime();
										String formatteDate = df.format(date);
										fechasActualizacion.put(nombreTabla, formatteDate);

									}*/
									bTablaNueva = true;
									listadoCampos = "";
									nombreTabla = parser.getName();
									tablaClase = Class.forName("com.amesol.routelite.datos." + nombreTabla);
									entidad = (Entidad) tablaClase.newInstance();
									/*if (tablasEliminar.contains(nombreTabla))
									{
										tablaLimpia = true;
										bd.eliminarTodo(entidad);
									}
									else
									{*/
										tablaLimpia = false;
									//}
								}
								valoresCampos.clear();
							}
							else if (parser.getDepth() == 3)
							{
								nombreCampoActual = parser.getName();
							}
							break;
						case XmlPullParser.END_TAG:
							if (parser.getDepth() == 2)
							{
								bTablaNueva = false;
								/*if (tablaLimpia)
								{
									bd.COMInsertarSinHijos(nombreTabla, listadoCampos, valoresCampos);
								}
								else
								{*/
									entidad.setValores(valoresCampos);
									Inventario oInvds = ((Inventario) entidad); 
									oInvds.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;
									Producto oPro = new Producto();
									oPro.ProductoClave = oInvds.ProductoClave;
									bd.recuperar(oPro);
									//actualizar o insertar solo si existe en el catalogo de productos
									//si no existe no hace nada, no se puede insertar ya que no trae toda la info del producto (catalogo, desc, promos, etc ...)
									if(bd.existe(oPro)){
										if (bd.existe(entidad))
										{
											bd.recuperar(entidad);
											entidad.setValores(valoresCampos);
											Inventario oInv = ((Inventario) entidad);
											oInv.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;
											oInv.Disponible = oInvds.Disponible; //asignar el disponible obtenido del data set
											oInv.Apartado = 0; //resetear el apartado
											oInv.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId; //usuario actual
											Calendar cal = new GregorianCalendar();
											Date date = cal.getTime();
											oInv.MFechaHora = date; //fecha hora actual
											bd.COMguardarSinHijos(entidad);
										}
										else
										{
											//llenar todos los campos, ya que todos estan definidos como not null
											listadoCampos += "\"AlmacenID\",\"NoDisponible\",\"Apartado\",\"Contenido\",\"Pedido\",\"MFechaHora\",\"MUsuarioID\"";
											valoresCampos.put("AlmacenID",((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID);
											valoresCampos.put("NoDisponible", 0);
											valoresCampos.put("Apartado", 0);
											valoresCampos.put("Contenido", 0);
											valoresCampos.put("Pedido", 0);
											valoresCampos.put("MUsuarioID", ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId);
											Calendar cal = new GregorianCalendar();
											Date date = cal.getTime();
											SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
											String fecha = format.format(date);
											valoresCampos.put("MFechaHora", fecha);
											bd.COMInsertarSinHijos(nombreTabla, listadoCampos, valoresCampos);
										}	
									}
								//}
							}
							else if (parser.getDepth() == 3)
							{
								if (bTablaNueva)
								{
									listadoCampos += "\"" + nombreCampoActual + "\",";
								}
								if (valorCampoActual.equalsIgnoreCase("true") || valorCampoActual.equalsIgnoreCase("false"))
								{
									valoresCampos.put(nombreCampoActual, (valorCampoActual.equalsIgnoreCase("true") ? 1 : 0));
								}
								else
								{
									valoresCampos.put(nombreCampoActual, valorCampoActual);
								}

							}

							break;
					}

					//Falla Aqui
					eventType = parser.next();
				}

				if (!nombreTabla.equals(""))
				{
					if (!tablaLimpia)
					{
						String filtroEliminacion = entidad.filtroEliminacionPorEstado(valoresCampos,nombreTabla);
						if (filtroEliminacion != "")
						{
							bd.eliminar(entidad, filtroEliminacion);
						}
					}
					Calendar cal = new GregorianCalendar();
					Date date = cal.getTime();
					String formatteDate = df.format(date);
					fechasActualizacion.put(nombreTabla, formatteDate);
				}

				NodeList tablas = xmlActualiza.getFirstChild().getChildNodes();

				for (int i = 0; i <= tablas.getLength() - 1; i++)
				{
					nombreTabla = tablas.item(i).getChildNodes().item(0).getTextContent();
					if (fechasActualizacion.containsKey(nombreTabla))
					{
						tablas.item(i).getChildNodes().item(1).setTextContent(fechasActualizacion.get(nombreTabla).toString());
					}
				}
				bd.commit();

				TransformerFactory transformerFactory = TransformerFactory.newInstance();
				Transformer transformer = transformerFactory.newTransformer();
				DOMSource source = new DOMSource(xmlActualiza);
				StreamResult result = new StreamResult(dirXml);

				//				fIn.close();
				transformer.transform(source, result);
				return true;
			}

			catch (FileNotFoundException e)
			{
				bd.rollback();
				throw e;
			}
			catch (IOException e)
			{
				bd.rollback();
				throw e;
			}
			catch (Exception e)
			{
				bd.rollback();
				throw e;
			}

		}
		catch (Exception e)
		{
			throw e;
		}

	}

	private static InputStream checkForUtf8BOMAndDiscardIfAny(InputStream inputStream) throws IOException
	{
		PushbackInputStream pushbackInputStream = new PushbackInputStream(new BufferedInputStream(inputStream), 3);
		byte[] bom = new byte[3];
		if (pushbackInputStream.read(bom) != -1)
		{
			if (!(bom[0] == (byte) 0xEF && bom[1] == (byte) 0xBB && bom[2] == (byte) 0xBF))
			{
				pushbackInputStream.unread(bom);
			}
		}
		return pushbackInputStream;
	}
}
