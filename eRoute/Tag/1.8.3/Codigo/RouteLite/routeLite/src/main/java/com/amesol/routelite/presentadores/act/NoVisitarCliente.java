package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.datos.Agenda;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.ImproductividadVenta;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IAtencionClientes;
import com.amesol.routelite.presentadores.interfaces.INoVisitaCliente;
import com.amesol.routelite.utilerias.Generales;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class NoVisitarCliente extends Presentador
{

	INoVisitaCliente mVista;
	String mAccion;

	public NoVisitarCliente(INoVisitaCliente vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
	}

	@Override
	public void iniciar()
	{
		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE)))
			mVista.mostrarMotivosNoVisita("'Terminar Visita'");
		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VENTA)))
			mVista.mostrarMotivosNoVisita("'Venta','Terminar Visita'");
		mVista.iniciar();
	}

	private void guardarAgenda(Agenda agenda)
	{
		try
		{
			agenda.TipoMotivo = mVista.getMotivoNoVisita();
			agenda.Comentario = mVista.getComentario();
			agenda.Visitado = 4;
			agenda.Enviado = false;
			BDVend.guardarInsertar(agenda);
			BDVend.commit();
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getCause().toString() + ". " + e.getMessage());
			e.printStackTrace();
		}
	}

	public void mContinuar()
	{

		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE)))
			if (validar())
			{
				guardarAgenda(obtenerAgenda());
				//mVista.finalizar();
				//mVista.iniciarActividad(IAtencionClientes.class, false);
			}
		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VENTA)))
			if (validar())
			{
				guardarInproductividad();
				//mVista.finalizar();
                //ImprimirTicket ();
			}
	}

	private void guardarInproductividad()
	{
		try
		{
			Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
			ImproductividadVenta mImproductividadVenta = new ImproductividadVenta();
			mImproductividadVenta.VisitaClave = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;
			mImproductividadVenta.DiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			mImproductividadVenta.MUsuarioID = vendedor.USUId;
			mImproductividadVenta.MFechaHora = Generales.getFechaHoraActual();
			mImproductividadVenta.Comentario = mVista.getComentario();
			mImproductividadVenta.TipoMotivo = mVista.getMotivoNoVisita();
			mImproductividadVenta.Enviado = false;
			BDVend.guardarInsertar(mImproductividadVenta);
			BDVend.commit();
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}

	}

	private boolean validar()
	{
		if (mVista.getMotivoNoVisita() == -1)
		{
			mVista.mostrarMensajeRequerido();
			return false;
		}
		return true;
	}

	private Agenda obtenerAgenda()
	{
		try
		{
			Dia dia = (Dia) Sesion.get(Campo.DiaActual);
			Ruta ruta = (Ruta) Sesion.get(Campo.RutaActual);
			Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
			Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

			return Consultas.ConsultasAgenda.obtenerAgendaPorDiaClienteRutaVendedor(dia.DiaClave, ruta.RUTClave, vendedor.VendedorId, cliente.ClienteClave);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			e.printStackTrace();
			return null;
		}
	}

    public boolean imprimir(){
        try {
            String sGrupo = Consultas.ConsultasValorReferencia.obtenerGrupo("MOTIMPRO", String.valueOf(mVista.getMotivoNoVisita()));

            if(sGrupo.toUpperCase().equals("TERMINAR VISITA")){
                MOTConfiguracion motConfiguracion = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
                if (motConfiguracion.get("MensajeImpresion").equals("1")) {
                    mVista.mostrarPreguntaSiNo(Mensajes.get("P0103"), 2);
                    return true;
                } else if (motConfiguracion.get("MensajeImpresion").equals("2")) {
                    mVista.mostrarToast(Mensajes.get("E0934"));
                    return false;
                } else
                    return false;
            }else{
                return false;
            }
        }catch (Exception e){
            e.printStackTrace();
            return false;
        }
    }

    public void imprimirTicket() throws Exception
    {
        Map<String, String> documento;
        List<Map<String, String>> documentos;

        Recibos recibos = new Recibos();
        documentos = new ArrayList<Map<String, String>>();

        documento = recibos.getDocumentoImpresion("VisitaoCliente", "29", "TRECIBO", "IMP", "", "", Generales.getFechaActual().toString(), "", "0", ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, Generales.getFechaActual().toString(), "", "0");
        documentos.add(documento);

        short numImpresiones = 0;
        try {
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString())) {
                numImpresiones = Short.parseShort (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString()).toString());
            }
        }catch (Exception ex){
            mVista.mostrarError("Error al recuperar el parámetro NumImpresiones");
            numImpresiones = 0;
        }
        recibos.imprimirRecibos(documentos, false, mVista, numImpresiones);
    }
}
