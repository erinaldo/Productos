package com.duxstar.dacza.actividades;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.ListIterator;
import java.util.Map;

import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.ClienteDomicilio;
import com.duxstar.dacza.datos.ClienteTelefono;


public class Clientes
{

	public static List<Map<String, String>> generarListaInfo(Cliente oCliente)
	{
		try
		{
			List<Map<String, String>> lista = new ArrayList<Map<String, String>>();
			Map<String, String> m;

			m = new HashMap<String, String>();
			m.put("descripcion", "Clave");
			m.put("valor", oCliente.Clave);
			lista.add(m);

			m = new HashMap<String, String>();
			m.put("descripcion", "Razón Social");
			m.put("valor", oCliente.RazonSocial);
			lista.add(m);

            m = new HashMap<String, String>();
            m.put("descripcion", "Domicilio");
            m.put("valor", oCliente.Domicilio);
            lista.add(m);

            m = new HashMap<String, String>();
            m.put("descripcion", "Teléfono");
            m.put("valor", oCliente.Telefono);
            lista.add(m);

			/*String domPuntoEnt = "";
			String domFiscal = "";

            if (oCliente.ClienteDomicilio != null) {
                ListIterator<ClienteDomicilio> domicilios = oCliente.ClienteDomicilio.listIterator();
                while (domicilios.hasNext()) {
                    ClienteDomicilio domicilio = domicilios.next();
                    if (domicilio.Tipo == 2) {
                        if (domPuntoEnt != "")
                            domPuntoEnt += "\n";
                        domPuntoEnt += domicilio.Calle + " " + domicilio.NumeroExt + " " + domicilio.NumeroInt;
                    }

                    if (domicilio.Tipo == 1) {
                        if (domFiscal != "")
                            domFiscal += "\n";
                        domFiscal += domicilio.Calle + " " + domicilio.NumeroExt + " " + domicilio.NumeroInt;
                    }
                }

                if (domPuntoEnt != "") {
                    m = new HashMap<String, String>();
                    m.put("descripcion", "Domicilio de Entrega");
                    m.put("valor", domPuntoEnt);
                    lista.add(m);
                }

                if (domFiscal != "") {
                    m = new HashMap<String, String>();
                    m.put("descripcion", "Domicilio Fiscal");
                    m.put("valor", domFiscal);
                    lista.add(m);
                }
            }

            String telOficina = "";
            String telFax = "";
            String telMovil = "";

            if (oCliente.ClienteTelefono != null) {
                ListIterator<ClienteTelefono> telefonos = oCliente.ClienteTelefono.listIterator();
                while (telefonos.hasNext()) {
                    ClienteTelefono telefono = telefonos.next();
                    if (telefono.Tipo == 1) {
                        if (telOficina != "")
                            telOficina += "\n";
                        if (telefono.Lada != "")
                            telOficina += "(" + telefono.Lada + ")";
                        telOficina += telefono.Numero;
                    }

                    if (telefono.Tipo == 2) {
                        if (telFax != "")
                            telFax += "\n";
                        if (telefono.Lada != "")
                            telFax += "(" + telefono.Lada + ")";
                        telFax += telefono.Numero;
                    }

                    if (telefono.Tipo == 3) {
                        if (telMovil != "")
                            telMovil += "\n";
                        if (telefono.Lada != "")
                            telMovil += "(" + telefono.Lada + ")";
                        telMovil += telefono.Numero;
                    }
                }

                if (telOficina != "") {
                    m = new HashMap<String, String>();
                    m.put("descripcion", "Tel. Oficina");
                    m.put("valor", telOficina);
                    lista.add(m);
                }

                if (telFax != "") {
                    m = new HashMap<String, String>();
                    m.put("descripcion", "Tel. Oficina Fax");
                    m.put("valor", telFax);
                    lista.add(m);
                }

                if (telMovil != "") {
                    m = new HashMap<String, String>();
                    m.put("descripcion", "Tel. Móvil");
                    m.put("valor", telMovil);
                    lista.add(m);
                }
            }*/

			return lista;
		}
		catch (Exception e)
		{
			return null;
		}
	}

}
