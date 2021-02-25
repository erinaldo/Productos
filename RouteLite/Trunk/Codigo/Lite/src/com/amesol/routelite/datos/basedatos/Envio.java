package com.amesol.routelite.datos.basedatos;

import java.io.BufferedReader;
import java.io.File;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.lang.reflect.Field;
import java.net.HttpURLConnection;
import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Enumeration;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.net.Uri;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.AbnTrp;
import com.amesol.routelite.datos.AbnTrpHist;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.AbonoHist;
import com.amesol.routelite.datos.Agenda;
import com.amesol.routelite.datos.CLIFormaVenta;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.ClienteEsquema;
import com.amesol.routelite.datos.CucCcu;
import com.amesol.routelite.datos.CueCcu;
import com.amesol.routelite.datos.CuotaCumplida;
import com.amesol.routelite.datos.CupCcu;
import com.amesol.routelite.datos.FolioReservacion;
import com.amesol.routelite.datos.ImproductividadVenta;
import com.amesol.routelite.datos.InventarioTraspaso;
import com.amesol.routelite.datos.PLBPLE;
import com.amesol.routelite.datos.PedidoModificado;
import com.amesol.routelite.datos.PreLiquidacion;
import com.amesol.routelite.datos.PuntoGPS;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TPDDesVendedor;
import com.amesol.routelite.datos.TPDImpuesto;
import com.amesol.routelite.datos.TRPCheque;
import com.amesol.routelite.datos.TRPVtaAcreditada;
import com.amesol.routelite.datos.TiempoMuerto;
import com.amesol.routelite.datos.TpdDes;
import com.amesol.routelite.datos.TpdPun;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.TrpPrp;
import com.amesol.routelite.datos.TrpTpd;
import com.amesol.routelite.datos.UsuarioSustituto;
import com.amesol.routelite.datos.VendedorJornada;
import com.amesol.routelite.datos.VendedorMensaje;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.VisitaHist;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores.TipoEnvioInfo;
import com.amesol.routelite.vistas.TRPDatoFiscal;


public class Envio {
	
	public static final Class<?>[] TABLAS_ENVIO_JORNADA = new Class<?>[]{Cliente.class, ClienteDomicilio.class, ClienteEsquema.class, CLIFormaVenta.class, Visita.class, VisitaHist.class, Agenda.class, TiempoMuerto.class, PuntoGPS.class, TransProd.class, TransProdDetalle.class, TPDImpuesto.class, TrpPrp.class, TrpTpd.class, TpdDes.class, TPDDesVendedor.class, TpdPun.class, TRPVtaAcreditada.class, VendedorMensaje.class, Abono.class, AbonoHist.class, ABNDetalle.class, AbnTrp.class, AbnTrpHist.class, TRPCheque.class, CuotaCumplida.class, CucCcu.class, CupCcu.class, CueCcu.class, FolioReservacion.class, Ruta.class, PLBPLE.class, PreLiquidacion.class,PedidoModificado.class, VendedorJornada.class, UsuarioSustituto.class,InventarioTraspaso.class, ImproductividadVenta.class, TRPDatoFiscal.class};
	//Vendedor Jornada no se manda parcial porque si no causa problemas con la validacion final.
	public static final Class<?>[] TABLAS_ENVIO_PARCIAL = new Class<?>[]{Cliente.class, ClienteDomicilio.class, ClienteEsquema.class, CLIFormaVenta.class, Visita.class, VisitaHist.class, Agenda.class, TiempoMuerto.class, PuntoGPS.class, TransProd.class, TransProdDetalle.class, TPDImpuesto.class, TrpPrp.class, TrpTpd.class, TpdDes.class, TPDDesVendedor.class, TpdPun.class, TRPVtaAcreditada.class, VendedorMensaje.class, Abono.class, AbonoHist.class, ABNDetalle.class, AbnTrp.class, AbnTrpHist.class, TRPCheque.class, CuotaCumplida.class, CucCcu.class, CupCcu.class, CueCcu.class, FolioReservacion.class, Ruta.class,PreLiquidacion.class,PedidoModificado.class, ImproductividadVenta.class, TRPDatoFiscal.class};
	public static final Class<?>[] TABLAS_ENVIO_PENDIENTES = new Class<?>[]{ VendedorMensaje.class };
	
	public static String getDatosEnviar(String nombreParametro, Class<?>... clases) throws Exception{
		if((clases == null)||(clases.length == 0)){
			String ruta = "com.amesol.routelite.datos";
			Enumeration<URL> elementos = Thread.currentThread().getContextClassLoader().getResources(ruta.replace('.', '/'));
			ArrayList<Class<?>> arrClases = new ArrayList<Class<?>>();
			if(elementos != null){
				while(elementos.hasMoreElements()){
					String nombreClase = elementos.nextElement().getFile();
					if(nombreClase.endsWith(".class")){
						nombreClase = nombreClase.substring(0,nombreClase.length()-6);
						try{
							Class<?> clase = Class.forName(ruta + "." + nombreClase);
							arrClases.add(clase);
						} catch (ClassNotFoundException  e){}						
					}
				}
				
			}
			if(arrClases.size()> 0){
				clases = arrClases.toArray(new Class<?>[arrClases.size()]);
			}
		}
		if((clases == null)||(clases.length == 0)) throw new Exception("Al menos tiene que existir una entidad a enviar");
		ArrayList<EntidadEnvio> entidades = new ArrayList<EntidadEnvio>();
		for(Class<?> clase: clases){
			if(clase.isAnnotationPresent(TablaDef.class)){
				TablaDef anotacion = clase.getAnnotation(TablaDef.class);
				if(anotacion.orden() > 0){
					for(Field campo: clase.getFields()){
						String nombreCampo = BaseDatos.obtenerNombreCampoSolo(campo).toUpperCase();
						if(nombreCampo.equals("ENVIADO")){
							entidades.add(new EntidadEnvio(clase, anotacion.orden()));
							break;
						}
					}
				}
			}
		}
		
		if(entidades.size() == 0) throw new Exception("Al menos tiene que existir una entidad a enviar");		
		EntidadEnvio[] entidadesEnviar = entidades.toArray(new EntidadEnvio[entidades.size()]);	
		
		
		// TODO Falta ordenar las entidades, el metodo Arrays.sort truena por un cast 
		/*try {
			Arrays.sort(entidadesEnviar);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}*/		
		
		
		StringBuilder osr = new StringBuilder(); 
		
		osr.append("<paroDataSet>");
		osr.append("<xs:schema xmlns=\"\" id=\"NewDataSet\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">");
		osr.append("<xs:element msdata:UseCurrentLocale=\"true\" msdata:IsDataSet=\"true\" name=\"NewDataSet\">");
		osr.append("<xs:complexType>");
		osr.append("<xs:choice maxOccurs=\"unbounded\" minOccurs=\"0\">");
		//Tablas
		for(EntidadEnvio e: entidadesEnviar){
			// TODO Generar un metodo que solo obtenga los campos
			ISetDatos sd = obtenerDatos(e.getEntidad());
			e.getSchemaStr(osr, sd);
			sd.close();
		}
		osr.append("</xs:choice>");
		osr.append("</xs:complexType>");		
		//Llaves primarias
		for(EntidadEnvio e: entidadesEnviar){
			e.getPrimaryKeyStr(osr);
		}		
		osr.append("</xs:element>");
		osr.append("</xs:schema>");
		osr.append("<diffgr:diffgram xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\" xmlns:diffgr=\"urn:schemas-microsoft-com:xml-diffgram-v1\">");
		osr.append("<NewDataSet xmlns=\"\">");
		//Datos
		for(EntidadEnvio e: entidadesEnviar){
			String nombreTabla = e.getNombreTabla();
			ISetDatos sd = obtenerDatos(e.getEntidad());
			while(sd.moveToNext()){
				e.getFilaStr(osr, sd, nombreTabla);
			}
			sd.close();
		}
		osr.append("</NewDataSet>");
		osr.append("</diffgr:diffgram>");
		osr.append("</paroDataSet>");
						
		return osr.toString();
		
		/*Document xml = DocumentBuilderFactory.newInstance().newDocumentBuilder().newDocument();
		Element parametro = xml.createElement(nombreParametro);
		Element schema = xml.createElement("xs:schema");
		
		schema.setAttribute("id", "NewDataSet");
		schema.setAttribute("xmlns", "");
		schema.setAttribute("xmlns:xs", "http://www.w3.org/2001/XMLSchema");
		schema.setAttribute("xmlns:msdata", "urn:schemas-microsoft-com:xml-msdata");
		Element elementSchema = xml.createElement("xs:element");
		elementSchema.setAttribute("name", "NewDataSet");
		elementSchema.setAttribute("msdata:IsDataSet", "true");
		elementSchema.setAttribute("msdata:UseCurrentLocale", "true");
		schema.appendChild(elementSchema);
		Element complexTypeSchema = xml.createElement("xs:complexType");
		elementSchema.appendChild(complexTypeSchema);
		Element choiceSchema = xml.createElement("xs:choice");
		choiceSchema.setAttribute("minOccurs", "0");
		choiceSchema.setAttribute("maxOccurs", "unbounded");
		complexTypeSchema.appendChild(choiceSchema);
					
		Element diffgr = xml.createElement("diffgr:diffgram");
		diffgr.setAttribute("xmlns:msdata", "urn:schemas-microsoft-com:xml-msdata");
		diffgr.setAttribute("xmlns:diffgr", "urn:schemas-microsoft-com:xml-diffgram-v1");
		
		Element dataSet = xml.createElement("NewDataSet");
		dataSet.setAttribute("xmlns", "");
		diffgr.appendChild(dataSet);
		boolean alMenosUno = false;
			
		
		for(EntidadEnvio e: entidadesEnviar){
			String nombreTabla = e.getNombreTabla();
			Element uniqueSchema = xml.createElement("xs:unique");
			uniqueSchema.setAttribute("name", "PK_" + nombreTabla);
			uniqueSchema.setAttribute("msdata:PrimaryKey", "true");
			uniqueSchema.setAttribute("msdata:ConstraintName", "PK_" + nombreTabla);
			
			Element selectorSchema = xml.createElement("xs:selector");
			selectorSchema.setAttribute("xpath", ".//" + nombreTabla);
			uniqueSchema.appendChild(selectorSchema);
			
			Class tablaClase;
			//Entidad entidad = null;
			tablaClase = Class.forName("com.amesol.routelite.datos."  + nombreTabla);
			//entidad = (Entidad)tablaClase.newInstance();
			
			for(Field campo : tablaClase.getFields()){
				if(campo.isAnnotationPresent(Llave.class)){
					Element fieldSchema = xml.createElement("xs:field");
					fieldSchema.setAttribute("xpath", campo.getName());
					uniqueSchema.appendChild(fieldSchema);
				}				
			}
			
			elementSchema.appendChild(uniqueSchema);		
			
			ISetDatos sd = obtenerDatos(e.getEntidad());
			choiceSchema.appendChild(e.getSchema(xml, sd));
			
			while(sd.moveToNext()){
				alMenosUno = true;
				Element tabla = e.getFila(xml, sd, nombreTabla);
				dataSet.appendChild(tabla);				
			}
			sd.close();
		}
		if(!alMenosUno) throw new Exception("Al menos tiene que existir una entidad a enviar");
		
		
		parametro.appendChild(schema);
		parametro.appendChild(diffgr);
		xml.appendChild(parametro);

		StringWriter stw = new StringWriter(); 
		Transformer serializer = TransformerFactory.newInstance().newTransformer(); 
		serializer.setOutputProperty("omit-xml-declaration", "yes");
		serializer.transform(new DOMSource(xml), new StreamResult(stw)); */
		
		/*File archivo = Environment.getExternalStorageDirectory();		
		archivo = new File(archivo, "archivo.xml");
		
		StreamResult srArchivo = new StreamResult(archivo);
		serializer.transform(new DOMSource(xml), srArchivo);*/
		
		//return stw.toString();
				
	}
	
	public static String fileDatosEnviar( Class<?>... clases) throws Exception{
		String nombreBD = "";
		if((clases == null)||(clases.length == 0)){
			String ruta = "com.amesol.routelite.datos";
			Enumeration<URL> elementos = Thread.currentThread().getContextClassLoader().getResources(ruta.replace('.', '/'));
			ArrayList<Class<?>> arrClases = new ArrayList<Class<?>>();
			if(elementos != null){
				while(elementos.hasMoreElements()){
					String nombreClase = elementos.nextElement().getFile();
					if(nombreClase.endsWith(".class")){
						nombreClase = nombreClase.substring(0,nombreClase.length()-6);
						try{
							Class<?> clase = Class.forName(ruta + "." + nombreClase);
							arrClases.add(clase);
						} catch (ClassNotFoundException  e){}						
					}
				}
				
			}
			if(arrClases.size()> 0){
				clases = arrClases.toArray(new Class<?>[arrClases.size()]);
			}
		}
		if((clases == null)||(clases.length == 0)) throw new Exception("Al menos tiene que existir una entidad a enviar");
		ArrayList<EntidadEnvio> entidades = new ArrayList<EntidadEnvio>();
		for(Class<?> clase: clases){
			if(clase.isAnnotationPresent(TablaDef.class)){
				TablaDef anotacion = clase.getAnnotation(TablaDef.class);
				if(anotacion.orden() > 0){
					for(Field campo: clase.getFields()){						
						if (!campo.isAnnotationPresent(Hijos.class)){
							String nombreCampo = BaseDatos.obtenerNombreCampoSolo(campo).toUpperCase();
							if(nombreCampo.equals("ENVIADO")){
								entidades.add(new EntidadEnvio(clase, anotacion.orden()));
								break;
							}	
						}
					}
				}
			}
		}
		
		if(entidades.size() == 0) throw new Exception("Al menos tiene que existir una entidad a enviar");		
		EntidadEnvio[] entidadesEnviar = entidades.toArray(new EntidadEnvio[entidades.size()]);	
		
		if (!hayDatosSinEnviar(entidadesEnviar)){
			throw new Exception(Mensajes.get("I0162"));
		}
				
		ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		File archivoBD = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
		archivoBD = new File(archivoBD, "bd");
	
		SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMddHHmmss");    
		String currentDateTimeString = sdf.format(new Date()); 
		nombreBD =  BDVend.nombreBaseDatos().replace(".db", "-" + currentDateTimeString + ".db");
		File BDOrig = new File(archivoBD, BDVend.nombreBaseDatos());
		archivoBD = new File(archivoBD,nombreBD);
		
		SQLiteDatabase db;
		db = SQLiteDatabase.openOrCreateDatabase(archivoBD.getAbsolutePath() , null);
		db.execSQL("ATTACH DATABASE '" + BDOrig.getAbsolutePath() + "' AS 'original'");
		db.beginTransaction();
		for(EntidadEnvio e: entidadesEnviar){
			Cursor cur = db.rawQuery("Select sql from 'original'.sqlite_master  where name = '" + e.getNombreTabla() + "'", null);
			SetDatos sd = new SetDatos();
			sd.iniciar(cur);
			//ISetDatos result = BDVend.consultar("Select sql from sqlite_master  where name = '" + e.getNombreTabla() + "'");
			String consultaCreate = ""; 
			if (sd.moveToFirst()){
				consultaCreate = sd.getString(0);
			}
			sd.close();
		
			db.execSQL(consultaCreate);
			//db.execSQL( "INSERT into " + e.getNombreTabla() + " " +  obtenerConsulta(e.getEntidad()));
			db.execSQL( "INSERT into " + e.getNombreTabla() + " SELECT * from 'original'." + e.getNombreTabla() + " WHERE Enviado=0 or Enviado is null ");
		}
		db.setTransactionSuccessful();
		db.endTransaction();
		db.execSQL("DETACH DATABASE 'original'");
		return nombreBD;
	}

	
	public static boolean hayDatosSinEnviar(Class<?>... clases) throws Exception{
		if((clases == null)||(clases.length == 0)) throw new Exception("al menos tiene que existir una entidad a enviar");
		ArrayList<EntidadEnvio> entidades = new ArrayList<EntidadEnvio>();
		for(Class<?> clase: clases){
			if(clase.isAnnotationPresent(TablaDef.class)){
				TablaDef anotacion = clase.getAnnotation(TablaDef.class);
				if(anotacion.orden() > 0){
					for(Field campo: clase.getFields()){
						if (!campo.isAnnotationPresent(Hijos.class)){
							String nombreCampo = BaseDatos.obtenerNombreCampoSolo(campo).toUpperCase();
							if(nombreCampo.equals("ENVIADO")){
								entidades.add(new EntidadEnvio(clase, anotacion.orden()));
								break;
							}
						}
					
					}
				}
			}
		}
		if(entidades.size() == 0) throw new Exception("al menos tiene que existir una entidad a enviar");
		
		EntidadEnvio[] entidadesEnviar = entidades.toArray(new EntidadEnvio[entidades.size()]);					
		//Arrays.sort(entidadesEnviar);
		for(EntidadEnvio e: entidadesEnviar){
			ISetDatos sd = obtenerDatos(e.getEntidad());  			
			if(sd.moveToNext()){
				sd.close();
				return true;				
			}
			else{
				sd.close();
			}
		}
		return false;
	}
	
	
	public static boolean hayDatosSinEnviar(EntidadEnvio[] entidadesEnviar) throws Exception{				
		//Arrays.sort(entidadesEnviar);
		for(EntidadEnvio e: entidadesEnviar){
			ISetDatos sd = obtenerDatos(e.getEntidad());  			
			if(sd.moveToNext()){
				sd.close();
				return true;				
			}
			else{
				sd.close();
			}
		}
		return false;
	}
	
	private static ISetDatos obtenerDatos(Class<?> clase) throws Exception{
		
		if(clase.equals(Cliente.class)){
			return BDVend.consultar("SELECT ClienteClave,CNPId,Clave,IdElectronico,IdFiscal,RazonSocial,TipoFiscal,TipoImpuesto,NombreContacto,TelefonoContacto,FechaRegistroSistema,FechaNacimiento,LimiteCreditoDinero,NombreCorto,TipoEstado,LimiteDescuento,(Case When SaldoEfectivo is null Then 0 Else SaldoEfectivo End) - (Case When SaldoEfectivoCarga is null Then 0 Else SaldoEfectivoCarga End) as SaldoEfectivo,Prestamo, (Case When SaldoGarantia is null Then 0 Else SaldoGarantia End) - (Case When SaldoGarantiaCarga is null Then 0 Else SaldoGarantiaCarga End) as SaldoGarantia,Exclusividad,VigExclusividad, ActualizaSaldoCheque, VencimientoVenta, DiasVencimiento,DesgloseImpuesto,ExigirOrdenCompra, MFechaHora,MUsuarioID FROM Cliente WHERE Enviado=0 or Enviado is null");
		}
		if(clase.equals(ClienteDomicilio.class)){
			return BDVend.consultar("SELECT ClienteClave, ClienteDomicilioId, Tipo, Calle, Numero, NumInt, CodigoPostal, ReferenciaDom, Colonia, Localidad, Poblacion, Entidad, Pais, CoordenadaX, CoordenadaY, MFechaHora, MUsuarioId FROM ClienteDomicilio WHERE Enviado=0 or Enviado is null");			
		}
		return BDVend.consultar(clase, null, "Enviado = 0", null);
	}
	
	private static String obtenerConsulta(Class<?> clase) throws Exception{
		
		if(clase.equals(Cliente.class)){
			return "SELECT ClienteClave,CNPId,Clave,IdElectronico,IdFiscal,RazonSocial,TipoFiscal,TipoImpuesto,NombreContacto,TelefonoContacto,FechaRegistroSistema,FechaNacimiento,LimiteCreditoDinero,NombreCorto,TipoEstado,LimiteDescuento,(Case When SaldoEfectivo is null Then 0 Else SaldoEfectivo End) - (Case When SaldoEfectivoCarga is null Then 0 Else SaldoEfectivoCarga End) as SaldoEfectivo,Prestamo, (Case When SaldoGarantia is null Then 0 Else SaldoGarantia End) - (Case When SaldoGarantiaCarga is null Then 0 Else SaldoGarantiaCarga End) as SaldoGarantia,Exclusividad,VigExclusividad, ActualizaSaldoCheque, VencimientoVenta, DiasVencimiento,DesgloseImpuesto,ExigirOrdenCompra, MFechaHora,MUsuarioID FROM original.Cliente WHERE Enviado=0 or Enviado is null";
		}
		if(clase.equals(ClienteDomicilio.class)){
			return "SELECT ClienteClave, ClienteDomicilioId, Tipo, Calle, Numero, NumInt, CodigoPostal, ReferenciaDom, Colonia, Localidad, Poblacion, Entidad, Pais, CoordenadaX, CoordenadaY, MFechaHora, MUsuarioId FROM original.ClienteDomicilio WHERE Enviado=0 or Enviado is null";			
		}
		return "Select * from original." + clase.getName() + " where Enviado = 0 or Enviado is null ";
	}

	public static void enviarTodo(String xml) throws Exception{
		 String message = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" " +   
	                "xmlns:tem=\"http://tempuri.org/services/MobileClient\">" +   
	                "<soap:Body>" +   
	                "<WSActualizarCapturaLite xmlns=\"http://tempuri.org/services/MobileClient\">" +
	                "<parsVendedorID>162</parsVendedorID>" +
	                /*"<paroDataSet>" +
	                	"<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\" id=\"NewDataSet\" xmlns=\"\">" +
	                		"<xs:element name=\"NewDataSet\" msdata:IsDataSet=\"true\" msdata:UseCurrentLocale=\"true\">" +
	                			"<xs:complexType>" +
	                				"<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">" +
	                					"<xs:element name=\"Cliente\">" +
	                						"<xs:complexType>" +
	                							"<xs:sequence>" +
	                								"<xs:element name=\"ClienteClave\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"CNPId\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"Clave\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"IdElectronico\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"IdFiscal\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"RazonSocial\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"TipoFiscal\" type=\"xs:long\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"TipoImpuesto\" type=\"xs:long\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"NombreContacto\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"TelefonoContacto\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"FechaRegistroSistema\" type=\"xs:dateTime\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"FechaNacimiento\" type=\"xs:dateTime\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"LimiteCreditoDinero\" type=\"xs:decimal\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"NombreCorto\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"TipoEstado\" type=\"xs:long\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"LimiteDescuento\" type=\"xs:decimal\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"SaldoEfectivo\" type=\"xs:decimal\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"Prestamo\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"SaldoGarantia\" type=\"xs:decimal\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"Exclusividad\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"VigExclusividad\" type=\"xs:dateTime\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"ActualizaSaldoCheque\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"VencimientoVenta\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"DiasVencimiento\" type=\"xs:integer\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"DesgloseImpuesto\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"ExigirOrdenCompra\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"MFechaHora\" type=\"xs:dateTime\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"MUsuarioID\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                								"<xs:element name=\"Enviado\" type=\"xs:string\" minOccurs=\"0\"/>" +
	                							"</xs:sequence>" +
	                						"</xs:complexType>" +
	                					"</xs:element>" +
	                				"</xs:choice>" +
	                			"</xs:complexType>" +
	                		"</xs:element>" +
	                	"</xs:schema>" +
	                	"<diffgr:diffgram xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\" xmlns:diffgr=\"urn:schemas-microsoft-com:xml-diffgram-v1\">" +
	                		"<NewDataSet xmlns=\"\">" +
	                			"<Cliente>" +
	                				"<ClienteClave>6829</ClienteClave>" +
	                				"<CNPId/>" +
	                				"<Clave>6829</Clave>" +
	                				"<IdElectronico>6829</IdElectronico>" +
	                				"<IdFiscal>COSA910424IWA</IdFiscal>" +
	                				"<RazonSocial>Alfredo Covarrubias Sanchez</RazonSocial>" +
	                				"<TipoFiscal>1</TipoFiscal>" +
	                				"<TipoImpuesto>1</TipoImpuesto>" +
	                				"<NombreContacto>Ferremateriales San Diego</NombreContacto>" +
	                				"<TelefonoContacto>4186840148</TelefonoContacto>" +
	                				"<FechaRegistroSistema>2011-07-18T12:16:34Z</FechaRegistroSistema>" +
	                				"<FechaNacimiento>2011-07-18T12:16:34Z</FechaNacimiento>" +
	                				"<LimiteCreditoDinero>50000</LimiteCreditoDinero>" +
	                				"<NombreCorto>Ferremateriales San Diego</NombreCorto>" +
	                				"<TipoEstado>1</TipoEstado>" +
	                				"<LimiteDescuento>0</LimiteDescuento>" +
	                				"<SaldoEfectivo>0</SaldoEfectivo>" +
	                				"<Prestamo>0</Prestamo>" +
	                				"<SaldoGarantia>0</SaldoGarantia>" +
	                				"<Exclusividad>0</Exclusividad>" +
	                				"<VigExclusividad>9998-12-31T00:00:00Z</VigExclusividad>" +
	                				"<ActualizaSaldoCheque>0</ActualizaSaldoCheque>" +
	                				"<VencimientoVenta>1</VencimientoVenta>" +
	                				"<DiasVencimiento>8</DiasVencimiento>" +
	                				"<DesgloseImpuesto>0</DesgloseImpuesto>" +
	                				"<ExigirOrdenCompra>0</ExigirOrdenCompra>" +
	                				"<MFechaHora>2011-12-12T01:00:08.657Z</MFechaHora>" +
	                				"<MUsuarioID>Interfaz</MUsuarioID>" +
	                				"<Enviado>0</Enviado>" +
	                			"</Cliente>" +
	                			"<Cliente>" +
	                				"<ClienteClave>6854</ClienteClave>" +
	                				"<CNPId/>" +
	                				"<Clave>6854</Clave>" +
	                				"<IdElectronico>6854</IdElectronico>" +
	                				"<IdFiscal>MEVA760828RX6</IdFiscal>" +
	                				"<RazonSocial>Mendez Velazquez Agustin</RazonSocial>" +
	                				"<TipoFiscal>1</TipoFiscal>" +
	                				"<TipoImpuesto>1</TipoImpuesto>" +
	                				"<NombreContacto>Materiales La Hacienda</NombreContacto>" +
	                				"<TelefonoContacto>468-109-8061</TelefonoContacto><" +
	                				"FechaRegistroSistema>2011-08-06T10:35:11Z</FechaRegistroSistema>" +
	                				"<FechaNacimiento>2011-08-06T10:35:11Z</FechaNacimiento>" +
	                				"<LimiteCreditoDinero>80000</LimiteCreditoDinero>" +
	                				"<NombreCorto>Materiales La Hacienda</NombreCorto>" +
	                				"<TipoEstado>1</TipoEstado>" +
	                				"<LimiteDescuento>0</LimiteDescuento>" +
	                				"<SaldoEfectivo>0</SaldoEfectivo>" +
	                				"<Prestamo>0</Prestamo>" +
	                				"<SaldoGarantia>0</SaldoGarantia>" +
	                				"<Exclusividad>0</Exclusividad>" +
	                				"<VigExclusividad>9998-12-31T00:00:00Z</VigExclusividad>" +
	                				"<ActualizaSaldoCheque>0</ActualizaSaldoCheque>" +
	                				"<VencimientoVenta>1</VencimientoVenta>" +
	                				"<DiasVencimiento>8</DiasVencimiento>" +
	                				"<DesgloseImpuesto>0</DesgloseImpuesto>" +
	                				"<ExigirOrdenCompra>0</ExigirOrdenCompra>" +
	                				"<MFechaHora>2011-12-12T01:00:08.657Z</MFechaHora>" +
	                				"<MUsuarioID>Interfaz</MUsuarioID>" +
	                				"<Enviado>0</Enviado>" +
	                			"</Cliente>" +
	                		"</NewDataSet>" +
	                	"</diffgr:diffgram>" +
	                "</paroDataSet>"+*/
	                xml +
	                /*"<xs:schema id=\"NewDataSet\" xmlns=\"\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">"+
                "<xs:element name=\"NewDataSet\" msdata:IsDataSet=\"true\" msdata:UseCurrentLocale=\"true\">"+
                    "<xs:complexType>"+
                        "<xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">"+
                            "<xs:element name=\"Table1\">"+
                            "<xs:complexType>"+
                                "<xs:sequence>"+
                                    "<xs:element name=\"DEPCD\" type=\"xs:string\" minOccurs=\"0\"/>"+
                                    "<xs:element name=\"DEPNAME\" type=\"xs:string\" minOccurs=\"0\"/>"+
                                "</xs:sequence>"+
                            "</xs:complexType>"+
                            "</xs:element>"+
                        "</xs:choice>"+
                    "</xs:complexType>"+
                "</xs:element>"+
            "</xs:schema>"+
            "<diffgr:diffgram xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\" xmlns:diffgr=\"urn:schemas-microsoft-com:xml-diffgram-v1\">"+
                "<NewDataSet  xmlns=\"\">"+
                    "<Table1>"+
                        "<DEPCD>001</DEPCD>"+
                        "<DEPNAME>IT</DEPNAME>"+
                    "</Table1>"+                    
                "</NewDataSet>"+
            "</diffgr:diffgram>" +*/
            //"</paroDataSet>"+
	                "<pardFechaInicial>2012-01-01T01:00:00Z</pardFechaInicial>"+
	                "<pardFechaPrimerDia>2012-01-01T01:00:00Z</pardFechaPrimerDia>"+
	                "<refparsMensaje></refparsMensaje>" +      
	                "<refparbReintentar>false</refparbReintentar>"+
	                "</WSActualizarCapturaLite>" +
	                "</soap:Body>" + 
	                "</soap:Envelope>";   
		
	 
		 String url = Uri.withAppendedPath(Uri.parse("http://192.168.0.60/ServicesCentral2005") , "ServiceMobileClient.asmx").toString() ;
	        
		 HttpURLConnection hc = (HttpURLConnection) new URL(url).openConnection(); 
	        hc.setRequestMethod("POST");   

	        hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient/WSActualizarCapturaLite");
	        //hc.setRequestProperty("SOAPAction", "http://tempuri.org/services/MobileClient#WSActualizarCapturaLite");
	        hc.setRequestProperty("User-Agent", "Profile/MIDP-1.0 Configuration/CLDC-1.0");   
	        hc.setRequestProperty("Content-Type", "text/xml;charset=utf-8");
	        //hc.setRequestProperty("Content-Type", "application/soap+xml; charset=utf-8");

	        hc.setRequestProperty("Content-Length", Integer.toString(message.length()));
	        hc.setRequestProperty("Connection", "close");
	        hc.setAllowUserInteraction(true);
	        hc.setDoOutput(true);
	        hc.setDoInput(true);
	        hc.setChunkedStreamingMode(0);
	        OutputStream os = hc.getOutputStream();   
	        os.write(message.getBytes());   
	        os.close();  
	        try{
	        String outputString = "";  
	        InputStreamReader isr = null;
	        BufferedReader in = null; 
	        String responseString = null; 
	        
	        
	        isr = new InputStreamReader(hc.getInputStream());   
	        in = new BufferedReader(isr);   
	        while ((responseString = in.readLine()) != null)    
	        {   
	            outputString = outputString + responseString;   
	        }   
	        isr.close();
	        }catch(Exception ex){
	        	int i = hc.getResponseCode();
		        if(i != 200){
		        	InputStream isr = hc.getErrorStream();
		        	byte[] bytes = new byte[100];
		        	String tmp= "";
		        	while (isr.read(bytes)> 0){
		        		tmp += new String(bytes);
		        	}
		        	System.out.print(tmp);
		        }
	        }
	}

	public static void marcarEnviados(int tipoEnvioInfo, Class<?>... clases) throws Exception {
		ArrayList<EntidadEnvio> entidades = new ArrayList<EntidadEnvio>();
		for(Class<?> clase: clases){
			if(clase.isAnnotationPresent(TablaDef.class)){
				TablaDef anotacion = clase.getAnnotation(TablaDef.class);
				if(anotacion.orden() > 0){
					for(Field campo: clase.getFields()){
						if (!campo.isAnnotationPresent(Hijos.class)){
							String nombreCampo = BaseDatos.obtenerNombreCampoSolo(campo).toUpperCase();
							if(nombreCampo.equals("ENVIADO")){
								entidades.add(new EntidadEnvio(clase, anotacion.orden()));
								break;
							}					
						}
					}
				}
			}
		}
		for(EntidadEnvio entidad:entidades){
			if(entidad.getNombreTabla().compareToIgnoreCase("Preliquidacion") == 0){ //no actualizar la tabla preliquidacion cuando es envio parcial
				if(tipoEnvioInfo == TipoEnvioInfo.ENVIO_JORNADA)
					BDVend.ejecutarComando("UPDATE "+ entidad.getNombreTabla() + " SET Enviado = 1");
			}else{
				BDVend.ejecutarComando("UPDATE "+ entidad.getNombreTabla() + " SET Enviado = 1");
			}		}
		
	}
}
