package com.tequila.test;

import java.rmi.RemoteException;

import org.apache.axis2.AxisFault;

import rules.tequila.com.prioridades.PrioridadesServiceStub;
import rules.tequila.com.prioridades.PrioridadesOperation;
import rules.tequila.com.prioridades.Prioridad;
import rules.tequila.com.prioridades.PrioridadesOperationResponse;
import rules.tequila.com.prioridades.Respuesta;

public class Test {

	public static void main(String[] args) {		
		try {
			PrioridadesServiceStub prioridadesServiceStub = new PrioridadesServiceStub("http://192.168.100.5:9763/services/PrioridadesService");
			prioridadesServiceStub._getServiceClient().getOptions().setManageSession(true);
			
			PrioridadesOperation prioridadesOperation = new PrioridadesOperation();
			
			Prioridad datosInput = new Prioridad();
			datosInput.setTipoClienteContratado(1);
			datosInput.setTipoClienteExistente(0);
			datosInput.setTipoVentaContratado(1);
			datosInput.setTipoVentaExistente(1);
			
			Prioridad[] datos = new Prioridad[1];
			datos[0] = datosInput;
								
			prioridadesOperation.setPrioridad(datos);					
			
			PrioridadesOperationResponse descuntosOperationResponse = prioridadesServiceStub.prioridadesOperation(prioridadesOperation);
			
			Respuesta[] datosOutput = descuntosOperationResponse.getRespuesta();										
			
			for(int x = 0; x < datosOutput.length; x++) {
				System.out.println("Resultado: " + datosOutput[x].getRespuesta());
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