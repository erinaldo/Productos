package com.tequila.test;

import org.apache.axis2.AxisFault;
import java.rmi.RemoteException;
import rules.tequila.com.descuentos.DescuentosServiceStub;
import rules.tequila.com.descuentos.DescuentosOperation;
import rules.tequila.com.descuentos.Datos;
import rules.tequila.com.descuentos.DescuntosOperationResponse;
import rules.tequila.com.descuentos.DatosOutput;


public class Test {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		try {
			DescuentosServiceStub descuentosServiceStub = new DescuentosServiceStub("http://192.168.100.5:9763/services/DescuentosService");
			descuentosServiceStub._getServiceClient().getOptions().setManageSession(true);
			
			DescuentosOperation descuentosOperation = new DescuentosOperation();
			
			Datos datosInput = new Datos();
			datosInput.setDescuento(30);
			datosInput.setHorario("AAA");
			datosInput.setMontoCompra(100);
			datosInput.setRol(1);
			
			Datos[] datos = new Datos[1];
			datos[0] = datosInput;
			
			DatosOutput datosInput2 = new DatosOutput();
			datosInput2.setResultado(false);			
			
			DatosOutput[] arraydatosOutput = new DatosOutput[1];
			arraydatosOutput[0] = datosInput2;
			
			descuentosOperation.setDatos(datos);
			descuentosOperation.setDatosSalida(arraydatosOutput);
			
			DescuntosOperationResponse descuntosOperationResponse = descuentosServiceStub.descuentosOperation(descuentosOperation);
			
			DatosOutput[] datosOutput = descuntosOperationResponse.getRespuesta();
			
			//System.out.println("Respuesta: " + descuntosOperationResponse.getRespuesta());
			
			for(int x = 0; x < datosOutput.length; x++) {
				System.out.println("Resultado: " + datosOutput[x].getResultado());
			}						
		} catch (AxisFault axisFault) {
            axisFault.printStackTrace();
        } catch (RemoteException e) {
            e.printStackTrace();
        } catch (Exception exc){
        	exc.printStackTrace();
        }
	}

}
