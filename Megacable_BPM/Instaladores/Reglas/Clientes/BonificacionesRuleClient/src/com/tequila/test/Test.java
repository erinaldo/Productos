package com.tequila.test;

import java.rmi.RemoteException;
import org.apache.axis2.AxisFault;
import rules.tequila.com.bonificaciones.Datos;
import rules.tequila.com.bonificaciones.Bonificaciones;
import rules.tequila.com.bonificaciones.BonificacionesOperation;
import rules.tequila.com.bonificaciones.BonificacionesServiceStub;
import rules.tequila.com.bonificaciones.BonificacionesOperationResponse;

public class Test {

	public static void main(String[] args) {
		try {
			BonificacionesServiceStub bonificacionesServiceStub = new BonificacionesServiceStub("http://192.168.100.5:9763/services/BonificacionesService");
			bonificacionesServiceStub._getServiceClient().getOptions().setManageSession(true);
			
			BonificacionesOperation bonificacionesOperation = new BonificacionesOperation();
			
			Datos datosInput = new Datos();
			datosInput.setHorarioPagado("AA");
			datosInput.setResultado(false);			
			datosInput.setRol(1);
			
			Datos[] datos = new Datos[1];
			datos[0] = datosInput;
			
			Bonificaciones datosInput2 = new Bonificaciones();
			datosInput2.setAaaBonificado(0);
			datosInput2.setAaBonificado(3);
			datosInput2.setABonificado(0);
			datosInput2.setBBonificado(0);			
			
			Bonificaciones[] arraydatosOutput = new Bonificaciones[1];
			arraydatosOutput[0] = datosInput2;
			
			bonificacionesOperation.setProductoBonificado(datos);
			bonificacionesOperation.setDatosInput(arraydatosOutput);
			
			BonificacionesOperationResponse descuntosOperationResponse = bonificacionesServiceStub.bonificacionesOperation(bonificacionesOperation);
			
			Datos[] datosOutput = descuntosOperationResponse.getDatosOutput();					
			
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
