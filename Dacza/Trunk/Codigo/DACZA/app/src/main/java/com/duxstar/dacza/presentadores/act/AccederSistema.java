package com.duxstar.dacza.presentadores.act;

import android.os.Build;

import java.io.File;
import java.util.Calendar;
import java.util.Date;

//import com.amesol.routelite.actividades.Mensajes;
//import com.amesol.routelite.actividades.ValorReferencia;
//import com.amesol.routelite.actividades.ValoresReferencia;
//import com.amesol.routelite.datos.Dia;
//import com.amesol.routelite.datos.PoliticaContrasenaHist;
import com.duxstar.dacza.actividades.Comunicaciones;
import com.duxstar.dacza.datos.Taller;
import com.duxstar.dacza.datos.Usuario;
//import com.amesol.routelite.datos.UsuarioSustituto;
//import com.amesol.routelite.datos.Vendedor;
//import com.amesol.routelite.datos.basedatos.BDTerm;
//import com.amesol.routelite.datos.basedatos.BDVend;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ConfiguracionLocal;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.IAccesoSistema;
import com.duxstar.dacza.presentadores.interfaces.IConfiguracionTerminal;
//import com.amesol.routelite.presentadores.interfaces.IRecepcionInformacion;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionActividades;
//import com.amesol.routelite.presentadores.interfaces.ISolicitudAgendaVendedor;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionFecha;
import com.duxstar.dacza.presentadores.interfaces.IServidorComunicaciones;
import com.duxstar.dacza.utilerias.EncriptaDesencripta;
//import com.amesol.routelite.utilerias.Generales;
//import com.amesol.routelite.utilerias.KeyGen;
//import com.amesol.routelite.utilerias.Log;

public class AccederSistema extends Presentador
{

	IAccesoSistema mVista;
	//private UsuarioSustituto sustituto;

	public AccederSistema(IAccesoSistema vista)
	{
		this.mVista = vista;
	}

	@Override
	public void iniciar()
	{
		mVista.iniciar();
		mVista.setTitulo("Bienvenido");
		ConfiguracionLocal confLocal = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
        //mVista.setFecha((Date)confLocal.get(CampoConfiguracion.FECHA));
		mVista.setAlmacen(confLocal.get(CampoConfiguracion.ALMACEN).toString());
        mVista.setAgente(confLocal.get(CampoConfiguracion.AGENTE).toString());
        mVista.setPassword(confLocal.get(CampoConfiguracion.PASSWORD).toString());
        //cargaSustituto();
	}

	public void intentarSalir(String clave, String password)
	{
		//String clave = mVista.getUsuario();
		//String password = mVista.getPassword();

//		Usuario usuario = null;
//		try
//		{
//			usuario = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(clave);
//		}
//		catch (Exception e)
//		{
//			e.printStackTrace();
//			mVista.mostrarError(e.getMessage());
//			return;
//		}
//		if ((usuario == null) || (!EncriptaDesencripta.encripta(password).equals(usuario.ClaveAcceso)))
//		{
//			mVista.mostrarAdvertencia(Mensajes.get("MDB050601"));
//			return;
//		}
//		if (!usuario.PERClave.toUpperCase().equals("ADMIN"))
//		{
//			mVista.mostrarAdvertencia(Mensajes.get("MI0222"));
//			return;
//		}
		mVista.mostrarPreguntaSiNo("¿Está seguro?", 1);
	}

    public void intentarSalir()
    {
        mVista.mostrarPreguntaSiNo("¿Está seguro?", 1);
    }

	public void salir()
	{
		//mVista.iniciarSelector();
        //Sesion.set(Campo.UsuarioSustitutoPendiente,false);
		mVista.finalizar();
		System.exit(0);
	}

	public void configuracion()
	{
		mVista.iniciarActividadConResultado(IConfiguracionTerminal.class, Enumeradores.Solicitudes.SOLICITUD_CONFIGURACION, Enumeradores.Acciones.ACCION_CONFIGURAR);
	}

    public void confirmarActualizarDatos()
    {
        mVista.mostrarPreguntaSiNo("Esta operación borrara su base de datos, ¿Está seguro de continuar?", 2);
    }

    public boolean existenDatosSinEnviar(String vieneDe)
    {
        if (Comunicaciones.ExistenDatosSinEnviar()) {
            if (vieneDe.equals("OpcionRecibir"))
                mVista.mostrarAdvertencia("Existe información que no ha sido enviada al servidor, no se pueden actualizar los datos");
            else if (vieneDe.equals("OpcionCambioTaller"))
                mVista.mostrarAdvertencia("Existe información que no ha sido enviada al servidor, no se pueden realizar el cambio de taller");
            return true;
        }
        return false;
    }

    public void actualizarDatos()
    {
        try {
            if (BDTerm.estaAbierta())
                BDTerm.cerrar();

            ArchivoConfiguracion conf = new ArchivoConfiguracion(mVista);
            File archivo = new File(conf.getValor(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
            archivo = new File(archivo, "bd");
            archivo = new File(archivo, conf.getValor(CampoConfiguracion.NUMERO_SERIE).toString() + ".db");
            if (archivo.exists())
                archivo.delete();


            mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_OBTENER_BD_TERMINAL);
            return;
        }catch (Exception e)
        {
            e.printStackTrace();
        }

    }

	public void acceder() {
        ArchivoConfiguracion conf = new ArchivoConfiguracion(mVista);
        String almacen = mVista.getAlmacen();
        String agente = mVista.getAgente();
        String password = mVista.getPassword();
        if (conf.getValor(CampoConfiguracion.ALMACEN).toString().toUpperCase().equals(almacen.toUpperCase()))
            this.acceder(almacen, agente, password);
        else {
            if (!existenDatosSinEnviar("OpcionCambioTaller"))
                mVista.mostrarPreguntaSiNo("¿Desea cambiar de Taller?", 3);
        }
	}
	
	public void acceder(String almacen, String agente, String password)
	{
        //TODO: Validar cambio de taller
		if (validarDatosUsuario(almacen, agente, password) && validarUsuarioConfigurado())
        {
            mVista.iniciarActividad(ISeleccionFecha.class, false);
            //mVista.iniciarActividad(ISeleccionActividades.class, false);
		}
	}


	
	public boolean validarDatosUsuario(String almacen, String agente, String password)
	{
        Taller taller = null;
		Usuario usuario = null;
		try
		{
            taller = Consultas.ConsultasTaller.obtenerTaller(almacen);
			usuario = Consultas.ConsultasUsuario.obtenerUsuario(almacen, agente);
		}
		catch (Exception e)
		{
			e.printStackTrace();
			mVista.mostrarError(e.getMessage());
			return false;
		}
        if (taller == null)
        {
            mVista.mostrarAdvertencia("Clave de almacen no válida");
            return false;
        }
		if ((usuario == null) || (!EncriptaDesencripta.encripta(password).equals(usuario.ClaveAcceso)))
		{
			mVista.mostrarAdvertencia("Clave de agente o contraseña no válidos");
			return false;
		}
        Sesion.set(Campo.TallerActual, taller);
		Sesion.set(Campo.UsuarioActual, usuario);
        String ModeloDispositivo= Build.MANUFACTURER.toUpperCase();
        Sesion.set(Campo.ModeloDispositivo, ModeloDispositivo);
		return true;
	}

    private boolean validarUsuarioConfigurado()
    {
        String agente = mVista.getAgente();
        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
        if (!conf.get(CampoConfiguracion.AGENTE).toString().toUpperCase().equals(agente.toUpperCase()))
        {
            mVista.mostrarPreguntaSiNo("¿Desea cambiar de Agente?", 0);
            return false;
        }
        return true;
    }

    public void cambiarUsuario(boolean acceder)
    {
        String almacen = mVista.getAlmacen();
        String agente = mVista.getAgente();
        ArchivoConfiguracion conf = new ArchivoConfiguracion(mVista);
        conf.iniciarEdicion();
        conf.setValor(CampoConfiguracion.ALMACEN, almacen);
        conf.setValor(CampoConfiguracion.AGENTE, agente);
        conf.commit();
        if (acceder)
            acceder();
    }

    public void cargarDatos()
    {
        mVista.mostrarProgreso("loading..", 3);
        Runnable accion = new Runnable()
        {
            public void run()
            {
                try
                {
                    BDTerm.Iniciar();
                }
                catch (Exception e)
                {
                    mVista.mostrarError(e.getMessage());
                    mVista.finalizar();
                    System.exit(0);
                }
                mVista.actualizarProgreso(1);
                mVista.actualizarProgreso(2);
                mVista.quitarProgreso();
                mVista.iniciarActividad(IAccesoSistema.class);
            }
        };
        new Thread(accion).start();
    }
}
