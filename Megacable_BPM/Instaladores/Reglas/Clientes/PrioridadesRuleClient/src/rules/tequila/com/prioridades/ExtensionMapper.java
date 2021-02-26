
/**
 * ExtensionMapper.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.6.1-wso2v10  Built on : Sep 04, 2013 (02:03:08 UTC)
 */

        
            package rules.tequila.com.prioridades;
        
            /**
            *  ExtensionMapper class
            */
            @SuppressWarnings({"unchecked","unused"})
        
        public  class ExtensionMapper{

          public static java.lang.Object getTypeObject(java.lang.String namespaceURI,
                                                       java.lang.String typeName,
                                                       javax.xml.stream.XMLStreamReader reader) throws java.lang.Exception{

              
                  if (
                  "http://com.tequila.rules/prioridades".equals(namespaceURI) &&
                  "Respuesta".equals(typeName)){
                   
                            return  rules.tequila.com.prioridades.Respuesta.Factory.parse(reader);
                        

                  }

              
                  if (
                  "http://com.tequila.rules/prioridades".equals(namespaceURI) &&
                  "Prioridad".equals(typeName)){
                   
                            return  rules.tequila.com.prioridades.Prioridad.Factory.parse(reader);
                        

                  }

              
             throw new org.apache.axis2.databinding.ADBException("Unsupported type " + namespaceURI + " " + typeName);
          }

        }
    