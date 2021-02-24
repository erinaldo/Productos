package com.duxstar.dacza.presentadores.act;
 
import java.text.SimpleDateFormat;

import com.duxstar.dacza.actividades.Folios;
import com.duxstar.dacza.actividades.OrdenesTrabajo;
import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.OrdenTrabajo;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.Vin;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.IBuscaCliente;
import com.duxstar.dacza.presentadores.interfaces.ICapturaOrden;

public class CapturarOrden extends Presentador
{

	ICapturaOrden mVista;
	String mAccion;
	String sOrdenId;
	OrdenTrabajo ordenTrabajo;

	boolean bEsNuevo = true;
	public boolean errorFinalizar = false;

    public CapturarOrden(ICapturaOrden vista)
    {
        mVista = vista;
    }

	public CapturarOrden(ICapturaOrden vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
	}

	@Override
	public void iniciar()
	{
		try
		{
			mVista.iniciar();

            if (bEsNuevo)
            {
                StringBuilder byRefMensaje = new StringBuilder();
                ordenTrabajo = OrdenesTrabajo.generarOrden(byRefMensaje);
                if (byRefMensaje.length()>0){
                    mVista.mostrarAdvertencia(byRefMensaje.toString());
                }

                if (Sesion.get(Campo.AgenteActual) == null )
                    Sesion.set(Campo.AgenteActual, (Usuario)Sesion.get(Campo.UsuarioActual));

                Usuario usuario = (Usuario)Sesion.get(Campo.AgenteActual);
                ordenTrabajo.AgenteId = usuario.UsuarioId;
                mVista.setAgenteActual(usuario);

                Cliente cliente = (Cliente)Sesion.get(Campo.ClienteActual);
                if (cliente != null) {
                    ordenTrabajo.ClienteId = cliente.ClienteId;
                    mVista.setClienteActual(cliente);
                }

                Sesion.remove(Campo.VinActual);
            }
            else {
                ordenTrabajo = OrdenesTrabajo.recuperarOrden(sOrdenId);

                Usuario usuario = Consultas.ConsultasUsuario.obtenerUsuarioPorId(ordenTrabajo.AgenteId);
                Cliente cliente = Consultas.ConsultasCliente.obtenerClientePorId(ordenTrabajo.ClienteId);
                Vin vin = Consultas.ConsultasVin.obtenerVinPorId(ordenTrabajo.VinId);
                Articulo articulo = new Articulo();
                articulo.ArticuloId = vin.ArticuloId;
                BDTerm.recuperar(articulo);//Consultas.ConsultasArticulo.obtenerArticuloPorId(vin.ArticuloId);

                Sesion.set(Campo.AgenteActual, usuario);
                Sesion.set(Campo.ClienteActual, cliente);
                Sesion.set(Campo.VinActual, vin);

                mVista.setClienteActual(cliente);
                mVista.setAgenteActual(usuario);

                mVista.setVinActual(vin, articulo, ordenTrabajo);
            }

            mVista.setFolio(ordenTrabajo.Folio);
            mVista.setFecha(new SimpleDateFormat("dd/MM/yyyy").format(ordenTrabajo.FechaIni));

            //Sesion.set(Campo.ClienteActual, null);
            //Sesion.set(Campo.VinActual, null);
            //BDTerm.guardarInsertar(ordenTrabajo);
		}
		catch (Exception e)
		{
			errorFinalizar = true;
			mVista.mostrarError(e.getMessage());
		}
	}

    public void setOrdenId(String ordenId){
        bEsNuevo = false;
        sOrdenId = ordenId;
    }

    public String getOrdenId(){
        return ordenTrabajo.OrdenId;
    }

    public void Guardar()
    {
        try
        {
            if(bEsNuevo)
                Folios.confirmar(Enumeradores.TiposMovimientos.ORDEN_TRABAJO);

            Usuario usuario = (Usuario)Sesion.get(Campo.AgenteActual);
            Cliente cliente = (Cliente)Sesion.get(Campo.ClienteActual);
            Vin vin = (Vin)Sesion.get(Campo.VinActual);
            Float kilometraje = (Float)Sesion.get(Campo.Kilometraje);

            ordenTrabajo.AgenteId = usuario.UsuarioId;
            ordenTrabajo.ClienteId = cliente.ClienteId;
            ordenTrabajo.VinId = vin.VinId;
            ordenTrabajo.Kilometraje = kilometraje;

            BDTerm.guardarInsertar(ordenTrabajo);
            BDTerm.commit();
        }
        catch (Exception e)
        {
            errorFinalizar = true;
            mVista.mostrarError(e.getMessage());
        }
    }

    public void ValidarCambios() {
        Usuario agente = null;
        Cliente cliente = null;
        Vin vin = null;
        float kilometraje = 0;

        if (Sesion.get(Campo.AgenteActual)!= null)
            agente = (Usuario) Sesion.get(Campo.AgenteActual);
        if (Sesion.get(Campo.ClienteActual)!= null)
            cliente = (Cliente) Sesion.get(Campo.ClienteActual);
        if (Sesion.get(Campo.VinActual)!= null)
            vin = (Vin) Sesion.get(Campo.VinActual);

        kilometraje = mVista.getKilometrajeActual();


        if (agente != null && ordenTrabajo.AgenteId != null) {
            if (!ordenTrabajo.AgenteId.equals(agente.UsuarioId)) {
                mVista.setHuboCambios(true);
                return;
            }
        }else if (agente != null && ordenTrabajo.AgenteId == null) {
            mVista.setHuboCambios(true);
            return;
        }

        if (cliente != null && ordenTrabajo.ClienteId != null) {
            if (!ordenTrabajo.ClienteId.equals(cliente.ClienteId)) {
                mVista.setHuboCambios(true);
                return;
            }
        }else if (cliente != null && ordenTrabajo.ClienteId == null) {
            mVista.setHuboCambios(true);
            return;
        }

        if (vin != null && ordenTrabajo.VinId != null) {
            if (!ordenTrabajo.VinId.equals(vin.VinId)) {
                mVista.setHuboCambios(true);
                return;
            }
        }else if (vin != null && ordenTrabajo.VinId == null) {
            mVista.setHuboCambios(true);
            return;
        }

        if (kilometraje != ordenTrabajo.Kilometraje) {
            mVista.setHuboCambios(true);
            return;
        }

        mVista.setHuboCambios(false);
    }
	
	public boolean getEsNuevo()
	{
		return bEsNuevo;
	}

    public Articulo getArticulo(String sArticuloId)
    {
        try {
            Articulo articulo = new Articulo();
            articulo.ArticuloId = sArticuloId;
            BDTerm.recuperar(articulo);
            return articulo;
        }catch (Exception ex)
        {
            mVista.mostrarError(ex.getMessage());
            return null;
        }
    }

    public Cliente buscarCliente(boolean codigoLeido, String cadenaBusqueda)
    {
        try {
            Cliente oCliente = null;
            if (!codigoLeido)
                oCliente = Consultas.ConsultasCliente.obtenerClienteIdentico(cadenaBusqueda);
            else
                oCliente = Consultas.ConsultasCliente.obtenerCliente(cadenaBusqueda);
            return oCliente;
        }catch (Exception e)
        {
            e.printStackTrace();
            return null;
        }
    }

    public void cancelarCaptura()
    {
        try {
            BDTerm.rollback();
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }
    }

    public void mostrarBuscarCliente(){
        mVista.iniciarActividad(IBuscaCliente.class, false);
        //mVista.iniciarActividadConResultado(IBuscaCliente.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_CLIENTES, Enumeradores.Acciones.ACCION_OBTENER_CLIENTE_SELECCIONADO);

    }
	
}
