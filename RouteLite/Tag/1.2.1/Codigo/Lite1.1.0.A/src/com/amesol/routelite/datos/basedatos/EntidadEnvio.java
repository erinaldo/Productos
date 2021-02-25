package com.amesol.routelite.datos.basedatos;

import java.io.OutputStreamWriter;
import java.io.StringWriter;
import java.lang.reflect.Field;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;

import org.w3c.dom.DOMException;
import org.w3c.dom.Document;
import org.w3c.dom.Element;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.generales.ISetDatos;

public class EntidadEnvio  implements Comparable<Integer>{

		private Integer orden;
		private Class<?> entidad;
		private String nombreTabla = null;
		private HashMap<String, String> campos;
		
		
		public EntidadEnvio(Class<?> entidad, int orden){
			this.entidad = entidad;
			this.orden = orden;
		}
		
		public String getNombreTabla() throws Exception{
			if(nombreTabla == null) nombreTabla = BaseDatos.obtenerNombreTablaSolo(entidad); 
			return nombreTabla;
		}
				
		public Class<?> getEntidad(){
			return entidad;
		}
		
		public int compareTo(Integer another) {			
			return orden.compareTo(another);
		}
		
		public Element getSchema(Document document, ISetDatos setDatos) throws Exception{
			Element elemento = document.createElement("xs:element");
			elemento.setAttribute("name", getNombreTabla());
			Element complexType = document.createElement("xs:complexType");
			elemento.appendChild(complexType);
			Element sequence = document.createElement("xs:sequence");
			complexType.appendChild(sequence);
			campos = new HashMap<String, String>(setDatos.getColumnCount());
			ArrayList<String> nombresCampos = new ArrayList<String>(campos.size());
			
			for(int i = 0; i < setDatos.getColumnCount(); i++){
				String nombreCampo = setDatos.getColumnName(i);
				nombresCampos.add(nombreCampo);
				campos.put(nombreCampo, "xs:string");
			}
			for(Field campo: entidad.getFields()){
				if((campo.isAnnotationPresent(Campo.class))||(campo.isAnnotationPresent(Llave.class))||(campo.isAnnotationPresent(LlaveForanea.class))){
					String nombreCampoTemp = BaseDatos.obtenerNombreCampoSolo(campo);
					if(campos.containsKey(nombreCampoTemp)){
						campos.put(nombreCampoTemp, obtenerTipoCampo(campo));
					}
				}
			}
			for(String campo: nombresCampos){
				Element element = document.createElement("xs:element");
				element.setAttribute("name", campo);	
				element.setAttribute("type", campos.get(campo));
				element.setAttribute("minOccurs", "0");
				sequence.appendChild(element);

			}
			
			
			
			/*for(int i = 0; i < setDatos.getColumnCount(); i++){
				Element element = document.createElement("xs:element");
				String nombreCampo = setDatos.getColumnName(i);
				element.setAttribute("name", nombreCampo);	
				element.setAttribute("type", "xs:string");
				campos.put(nombreCampo, "xs:string");
				for(Field campo: entidad.getFields()){
					if((campo.isAnnotationPresent(Campo.class))||(campo.isAnnotationPresent(Llave.class))||(campo.isAnnotationPresent(LlaveForanea.class))){
						String nombreCampoTemp = BaseDatos.obtenerNombreCampoSolo(campo);

						if(nombreCampoTemp.toUpperCase().equals(nombreCampo.toUpperCase())){
							String tipoCampo = obtenerTipoCampo(campo);
							element.setAttribute("type", tipoCampo);
							campos.put(nombreCampo, tipoCampo);
							break;
						}
					}
				}
				element.setAttribute("minOccurs", "0");
				sequence.appendChild(element);
			}*/
			return elemento;
		}
		
		
		public boolean getSchemaStr(StringBuilder osr, ISetDatos setDatos) throws Exception{
			campos = new HashMap<String, String>(setDatos.getColumnCount());
			ArrayList<String> nombresCampos = new ArrayList<String>(campos.size());
			
			for(int i = 0; i < setDatos.getColumnCount(); i++){
				String nombreCampo = setDatos.getColumnName(i);
				nombresCampos.add(nombreCampo);
				campos.put(nombreCampo, "xs:string");
			}
			for(Field campo: entidad.getFields()){
				if((campo.isAnnotationPresent(Campo.class))||(campo.isAnnotationPresent(Llave.class))||(campo.isAnnotationPresent(LlaveForanea.class))){
					String nombreCampoTemp = BaseDatos.obtenerNombreCampoSolo(campo);
					if(campos.containsKey(nombreCampoTemp)){
						campos.put(nombreCampoTemp, obtenerTipoCampo(campo));
					}
				}
			}
			
			osr.append("<xs:element name=\"" + getNombreTabla() + "\">");
			osr.append("<xs:complexType>");
			osr.append("<xs:sequence>");
		    
		    for(String campo: nombresCampos){
		    	osr.append("<xs:element name=\""+ campo + "\" type=\"" + campos.get(campo) + "\" minOccurs=\"0\"/>");
			}
		    
		    osr.append("</xs:sequence>");
		    osr.append("</xs:complexType>");
		    osr.append("</xs:element>");
		    
			return true;
		}
		
		public boolean getPrimaryKeyStr(StringBuilder osr) throws Exception{
			String nombreTabla = getNombreTabla();
			osr.append("<xs:unique name=\"PK_" + nombreTabla + "\" msdata:ConstraintName=\"PK_" + nombreTabla + "\" msdata:PrimaryKey=\"true\">");
			osr.append("<xs:selector xpath=\".//" + nombreTabla + "\"/>");
			
			Class tablaClase;
			//Entidad entidad = null;
			tablaClase = Class.forName("com.amesol.routelite.datos."  + nombreTabla);
			//entidad = (Entidad)tablaClase.newInstance();
			
			for(Field campo : tablaClase.getFields()){
				if(campo.isAnnotationPresent(Llave.class)){
					osr.append("<xs:field xpath=\"" + campo.getName() + "\"/>");
				}				
			}	
			osr.append("</xs:unique>");
			return true;
		}
		
		public Element getFila(Document documento, ISetDatos setDatos) throws Exception{
			Element fila = documento.createElement(getNombreTabla());
			for(int i = 0; i < setDatos.getColumnCount(); i++){
				if (setDatos.getString(i) != null){
					fila.appendChild(obtenerValorCampo(setDatos, i, documento));
				}
			}
			return fila;
		}
		
		public Element getFila(Document documento, ISetDatos setDatos, String nombreTabla) throws Exception{
			Element fila = documento.createElement(nombreTabla);
			for(int i = 0; i < setDatos.getColumnCount(); i++){
				if (setDatos.getString(i) != null){
					fila.appendChild(obtenerValorCampo(setDatos, i, documento));
				}
			}
			return fila;
		}
		
		public boolean getFilaStr(StringBuilder osr, ISetDatos setDatos, String nombreTabla) throws Exception{
			osr.append("<" + nombreTabla + ">");
			for(int i = 0; i < setDatos.getColumnCount(); i++){
				if (setDatos.getString(i) != null){
					String nombreCampo = setDatos.getColumnName(i);
					String valor = null;
					
					if(campos.get(nombreCampo).equals("xs:dateTime")){
						SimpleDateFormat origen = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
						valor = setDatos.getString(i);
						Date fecha;
						try {
							fecha = origen.parse(valor);
							SimpleDateFormat destino = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");
							valor = destino.format(fecha);
						} catch (ParseException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}				
										
					}else valor = setDatos.getString(i);
					
					osr.append("<" + nombreCampo + ">" + valor + "</" + nombreCampo + ">");
					
				}
			}
			osr.append("</" + nombreTabla + ">");
			return true;
		}
		
		private Element obtenerValorCampo(ISetDatos sd, int indice, Document documento){
			String nombreCampo = sd.getColumnName(indice);						
			Element elemento = documento.createElement(nombreCampo);
			String valor = null;
			if(campos.get(nombreCampo).equals("xs:dateTime")){
				SimpleDateFormat origen = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
				valor = sd.getString(indice);
				Date fecha;
				try {
					fecha = origen.parse(valor);
					SimpleDateFormat destino = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");
					valor = destino.format(fecha);
				} catch (ParseException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}				
								
			}else valor = sd.getString(indice);
			
			/*Field campo = null;
			for(Field c:entidad.getFields()){
				if((c.isAnnotationPresent(Campo.class))||(c.isAnnotationPresent(Llave.class))||(c.isAnnotationPresent(LlaveForanea.class))){
					String nombreCampoTemp = BaseDatos.obtenerNombreCampoSolo(c);
					if(nombreCampoTemp.toUpperCase().equals(nombreCampo)){
						campo = c;
						break;
					}
				}
			}
			String valor = sd.getString(indice);
			if((campo != null)&&(campo.getType().equals(Byte[].class)|| campo.getType().equals(byte[].class))) valor = sd.getBlob(indice).toString();*/			
			elemento.setTextContent(valor);
			return elemento;
		}
		
		private String obtenerTipoCampo(Field campo){
			String valor="";
			if(campo.getType().equals(String.class)) valor = "xs:string";
			else if (campo.getType().equals(Integer.class)||campo.getType().equals(int.class)) valor = "xs:integer";
			else if(campo.getType().equals(Float.class) || campo.getType().equals(float.class)) valor = "xs:decimal";
			else if(campo.getType().equals(Double.class)|| campo.getType().equals(double.class)) valor = "xs:decimal";
			else if(campo.getType().equals(Byte[].class)|| campo.getType().equals(byte[].class)) valor = "xs:hexBinary";
			else if(campo.getType().equals(Long.class) || campo.getType().equals(long.class)) valor = "xs:long";
			else if(campo.getType().equals(Short.class) || campo.getType().equals(short.class)) valor = "xs:short";
			else if(campo.getType().equals(Date.class)) valor = "xs:dateTime";
			else valor = "xs:string";
			return valor;
		}
		
	
}
