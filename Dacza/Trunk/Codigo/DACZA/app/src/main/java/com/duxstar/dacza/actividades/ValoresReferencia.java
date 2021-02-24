package com.duxstar.dacza.actividades;

import java.util.ArrayList;
import java.util.Map;

public class ValoresReferencia
{

	private static Map<String, Map<String, ValorReferencia>> valores = null;


	public static ValorReferencia[] getValores(String VARCodigo)
	{
        ArrayList<ValorReferencia> lista = new ArrayList<ValorReferencia>();
        if(VARCodigo.equals("ACTAGENTE")) {
            lista.add(new ValorReferencia("ACTAGENTE", "1", "Orden de Trabajo", "Agente"));
            lista.add(new ValorReferencia("ACTAGENTE", "2", "Inventario", "Agente"));
            lista.add(new ValorReferencia("ACTAGENTE", "3", "Enviar Información", "Agente"));
        }
        else if(VARCodigo.equals("ACTINVENT")) {
            lista.add(new ValorReferencia("ACTINVENT", "1", "Consultar", "Inventario"));
            lista.add(new ValorReferencia("ACTINVENT", "2", "Solicitudes de Traspaso", "Inventario"));
            lista.add(new ValorReferencia("ACTINVENT", "3", "Devoluciones", "Inventario"));
            lista.add(new ValorReferencia("ACTINVENT", "4", "Enviar Información", "Inventario"));
        }
        else if(VARCodigo.equals("DOCTOFASE"))
        {

            lista.add(new ValorReferencia("DOCTOFASE", "0", "Cancelado", ""));
            lista.add(new ValorReferencia("DOCTOFASE", "1", "Captura", ""));
            lista.add(new ValorReferencia("DOCTOFASE", "2", "Cerrado", ""));
            lista.add(new ValorReferencia("DOCTOFASE", "3", "Surtido", ""));
        }
        else if(VARCodigo.equals("TIPOTEL"))
        {

            lista.add(new ValorReferencia("TIPOTEL", "1", "Oficina", ""));
            lista.add(new ValorReferencia("TIPOTEL", "2", "Oficina Fax", ""));
            lista.add(new ValorReferencia("TIPOTEL", "3", "Móvil", ""));
        }
		return lista.toArray(new ValorReferencia[lista.size()]);
	}

    public static ValorReferencia getValor(String VARCodigo, String VAVClave)
    {
        ValorReferencia[] valores = getValores(VARCodigo);
        for (ValorReferencia valor : valores)
        {
            if (valor.getVavclave().equals(VAVClave))
                return valor;
        }
        return null;
    }

}
