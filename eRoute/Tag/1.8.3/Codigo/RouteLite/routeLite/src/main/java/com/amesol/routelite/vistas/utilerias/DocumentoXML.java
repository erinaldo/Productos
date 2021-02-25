package com.amesol.routelite.vistas.utilerias;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.StringReader;
import java.io.StringWriter;
import java.lang.reflect.Field;
import java.net.URL;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Enumeration;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;


public class DocumentoXML {

	 public static Document XMLfromString(String xml){  


 		Document doc = null;  
 		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();  

 		try { 
 			DocumentBuilder db = dbf.newDocumentBuilder();  
 			InputSource is = new InputSource();  
 			is.setCharacterStream(new StringReader(xml));  
  			doc = db.parse(is);   
 		} catch (ParserConfigurationException e) {  
 			System.out.println("XML parse error: " + e.getMessage());  
 			return null;  
 		} catch (SAXException e) {  
 			System.out.println("Wrong XML file structure: " + e.getMessage());  
 			return null;  
 		} catch (IOException e) {  
 			System.out.println("I/O exeption: " + e.getMessage());  
 			return null;  
 		}  

 	 return doc;  
 } 
	 
	 
	  public static String ArchivoXMLtoString(String filename) throws Exception {
		  byte[] buffer = new byte[1024];
		  String archivo = new String();
	        BufferedInputStream bufferedInput = null;
	      
	        
	        try {
	        	
	            bufferedInput = new BufferedInputStream(new FileInputStream(filename));
	           int bytesRead = 0;
	           	        	            
	            while ((bytesRead = bufferedInput.read(buffer)) != -1) {

	            	/*if (archivo.length()<=0){
	            		archivo = new String(buffer, 3, bytesRead-3, "utf-8");
	            	}else{*/
	            		archivo += new String(buffer, 0, bytesRead, "utf-8");
	            	//}
	            }
	        } catch (FileNotFoundException ex) {
	            throw new Exception("Error al leer archivo " + filename + " " + ex.getMessage());
	        } catch (IOException ex) {
	        	throw new Exception("Error al leer archivo " + filename + " " + ex.getMessage());
	        } finally {
	            try {
	                if (bufferedInput != null)
	                    bufferedInput.close();
	            } catch (IOException ex) {
	            	throw new Exception("Error al leer archivo " + filename + " " + ex.getMessage());
	            }
	        }
	        return archivo;
	    }
	  
	  public static String CrearDataSetActualiza(String nombreParametro, Document doc, String tablas) throws Exception{
		
			Document xml = DocumentBuilderFactory.newInstance().newDocumentBuilder().newDocument();
			Element parametro = xml.createElement(nombreParametro);
			Element schema = xml.createElement("xs:schema");
			
			schema.setAttribute("id", "ds");
			schema.setAttribute("xmlns", "");
			schema.setAttribute("xmlns:xs", "http://www.w3.org/2001/XMLSchema");
			schema.setAttribute("xmlns:msdata", "urn:schemas-microsoft-com:xml-msdata");
			Element elementSchema = xml.createElement("xs:element");
			elementSchema.setAttribute("name", "ds");
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
			
			Element dataSet = xml.createElement("ds");
			dataSet.setAttribute("xmlns", "");
			diffgr.appendChild(dataSet);
	
			Element elemento = xml.createElement("xs:element");
			elemento.setAttribute("name", "T");
			Element complexType = xml.createElement("xs:complexType");
			elemento.appendChild(complexType);
			Element sequence = xml.createElement("xs:sequence");
			complexType.appendChild(sequence);
			
			Element campoI = xml.createElement("xs:element");
			campoI.setAttribute("name", "I");	
			campoI.setAttribute("type", "xs:string");
			campoI.setAttribute("minOccurs", "0");
			sequence.appendChild(campoI);
			
			Element campoF = xml.createElement("xs:element");
			campoF.setAttribute("name", "F");	
			campoF.setAttribute("type", "xs:string");
			campoF.setAttribute("minOccurs", "0");			
			sequence.appendChild(campoF);
			
		
			choiceSchema.appendChild(elemento);
			
			
			 // DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance(); 
			  // Step 2: create a DocumentBuilder        
			  //DocumentBuilder db = dbf.newDocumentBuilder();        
			  // Step 3: parse the input file to get a Document object        
			  //Document doc = db.parse(new File(filename));
	
			 NodeList detalle = doc.getFirstChild().getChildNodes();
			 for (int i = 0; i< detalle.getLength(); i++){
				 if (tablas.contains("'" + detalle.item(i).getChildNodes().item(0).getTextContent() + "'")){
					 Element det = xml.createElement("T");
					 Element hijoT = xml.createElement("I");
					 hijoT.setTextContent(detalle.item(i).getChildNodes().item(0).getTextContent());
					 det.appendChild(hijoT);
					 Element hijoF = xml.createElement("F");
					 hijoF.setTextContent(detalle.item(i).getChildNodes().item(1).getTextContent());
					 det.appendChild(hijoF);				 
					 dataSet.appendChild(det); 
				 }
			 }
	
			//dataSet.appendChild(new )
			
			/*Element datos  = xml.createElement("NewDataSet");
			datos.setTextContent(file);
			dataSet.appendChild(datos);
			*/
			/*for(EntidadEnvio e: entidadesEnviar){
				ISetDatos sd = obtenerDatos(e.getEntidad());
				choiceSchema.appendChild(e.getSchema(xml, sd));
				while(sd.moveToNext()){
					alMenosUno = true;
					Element tabla = e.getFila(xml,sd);
					dataSet.appendChild(tabla);
				}
				sd.close();
			}*/

			parametro.appendChild(schema);
			parametro.appendChild(diffgr);
			xml.appendChild(parametro);
			
			
			StringWriter stw = new StringWriter(); 
			Transformer serializer = TransformerFactory.newInstance().newTransformer(); 
			serializer.setOutputProperty("omit-xml-declaration", "yes");
			serializer.transform(new DOMSource(xml), new StreamResult(stw)); 
			return stw.toString();
		}


	
}
