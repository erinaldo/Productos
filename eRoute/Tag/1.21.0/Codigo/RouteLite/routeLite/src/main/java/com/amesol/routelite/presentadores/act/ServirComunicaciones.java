package com.amesol.routelite.presentadores.act;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.Date;
import java.util.Calendar;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;
import java.util.zip.ZipOutputStream;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;

import org.w3c.dom.Document;
import org.w3c.dom.NodeList;

import android.app.Activity;
import android.content.ContentValues;
import android.content.pm.PackageInstaller;
import android.database.Cursor;
import android.provider.ContactsContract.Directory;
import android.text.TextUtils;
import android.widget.Toast;

import com.amesol.routelite.actividades.Enumeradores.Inventario.TipoEnvioMovimientosAutomaticos;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.InventarioDobleUnidad;
import com.amesol.routelite.actividades.InventarioLotes;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.CamionVendedor;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.UsuarioSustituto;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.VendedorJornada;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Envio;
import com.amesol.routelite.datos.basedatos.Recepcion;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasMOTConfiguracion;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.LogFile;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TipoEnvioInfo;
import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.utilerias.Dispositivo;
import com.amesol.routelite.vistas.utilerias.DocumentoXML;
import com.amesol.routelite.vistas.utilerias.ServicesCentral;

public class ServirComunicaciones extends Presentador  //I0162
{

	private IServidorComunicaciones mVista;
	private String mAccion;
	private Date mfechaIni;
	private Date mfechaFin;
	private String mTablas;
	private int tipoEnvioInformacion = TipoEnvioInfo.ENVIO_JORNADA;
	private boolean mContinuar;
	private boolean bRecargas = false;
    private boolean bPrecios = false;
    private boolean bCobranza = false;
    private boolean bPromociones = false;
	private boolean bProductos = false;
    private String UsuarioMod;
    private String ContrasenaMod;
	private String sFolioDoctos;

	public ServirComunicaciones(IServidorComunicaciones vista, String accion)
	{
		this.mVista = vista;
		this.mAccion = accion;
	}

	public ServirComunicaciones(IServidorComunicaciones vista, String accion, int ptipoEnvioInformacion)
	{
		this.mVista = vista;
		this.mAccion = accion;
		tipoEnvioInformacion = ptipoEnvioInformacion;
	}

	public ServirComunicaciones(boolean continuarSinDatos, IServidorComunicaciones vista, String accion, int tipoEnvioInfo)
	{
		this.mVista = vista;
		this.mAccion = accion;
		tipoEnvioInformacion = tipoEnvioInfo;
		mContinuar = continuarSinDatos;
	}

	public ServirComunicaciones(IServidorComunicaciones vista, String accion, boolean envioParcial, int tipoEnvioInf)
	{
		this.mVista = vista;
		this.mAccion = accion;
		tipoEnvioInformacion = tipoEnvioInf;
	}

	public ServirComunicaciones(IServidorComunicaciones vista, String accion, Date fechaIni, Date fechaFin)
	{
		this.mVista = vista;
		this.mAccion = accion;
		this.mfechaIni = fechaIni;
		this.mfechaFin = fechaFin;
	}

	/*public ServirComunicaciones(IServidorComunicaciones vista, String accion, String tablas, boolean recarga, boolean precios)
	{
		this.mVista = vista;
		this.mAccion = accion;
		this.mTablas = tablas;
		bRecargas = recarga;
        bPrecios = precios;
	}*/

    public ServirComunicaciones(IServidorComunicaciones vista, String accion,String folioDoctos)
    {
        this.mVista = vista;
        this.mAccion = accion;
        sFolioDoctos = folioDoctos;
    }


	public ServirComunicaciones(boolean continuarSinDatos, IServidorComunicaciones vista, String accion, String tablas, boolean recarga, boolean precios, boolean cobranza, boolean promociones, boolean productos)
	{
		this.mVista = vista;
		this.mAccion = accion;
		this.mTablas = tablas;
		bRecargas = recarga;
		bPrecios = precios;
        bCobranza = cobranza;
        bPromociones = promociones;
		bProductos = productos;
		mContinuar = continuarSinDatos;
	}

    public ServirComunicaciones(IServidorComunicaciones vista, String accion, String UsuarioMod, String ContrasenaMod){
        this.mVista = vista;
        this.mAccion = accion;
        this.UsuarioMod = UsuarioMod;
        this.ContrasenaMod = ContrasenaMod;
    }

	@Override
	public void iniciar()
	{
		mVista.iniciar();
		if (mAccion != null)
		{
			if (mAccion.equals(Enumeradores.Acciones.ACCION_OBTENER_BD_VENDEDOR))
			{
				if (BDVend.estaAbierta())
				{
					try
					{
						Consultas.ConsultasVisita.eliminarVisitasSinMovimientos(false);
						boolean bEnviar = false;
                        Sesion.set(Campo.tipoEnvioInformacion, TipoEnvioInfo.ENVIO_JORNADA);
						if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_JORNADA )
                            bEnviar = Envio.hayDatosSinEnviar(Envio.TABLAS_ENVIO_JORNADA);
                        else if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_PARCIAL )
                            bEnviar = Envio.hayDatosSinEnviar(Envio.TABLAS_ENVIO_PARCIAL);
                        else if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_PENDIENTES_VENDEDOR)
                            bEnviar = Envio.hayDatosSinEnviar(Envio.TABLAS_ENVIO_PENDIENTES);

						if (bEnviar)
						{//Cliente.class, ClienteDomicilio.class, ClienteEsquema.class, CLIFormaVenta.class, Visita.class, VisitaHist.class, Agenda.class, TiempoMuerto.class, PuntoGPS.class, TransProd.class, TransProdDetalle.class, TPDImpuesto.class, TrpPrp.class, TpdDes.class, TPDDesVendedor.class, TpdPun.class, VendedorMensaje.class, Abono.class, AbonoHist.class, ABNDetalle.class, AbnTrp.class, AbnTrpHist.class, TRPCheque.class, CuotaCumplida.class, CucCcu.class, CupCcu.class, CueCcu.class, FolioReservacion.class)){
							mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("E0550"));
							mVista.finalizar();
							return;
						}
					}
					catch (Exception ex)
					{
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, ex.getMessage());
						mVista.finalizar();
						return;
					}
				}

			}
			if (mAccion.equals(Enumeradores.Acciones.ACCION_OBTENER_BD_VENDEDOR) || mAccion.equals(Enumeradores.Acciones.ACCION_OBTENER_BD_TERMINAL))
			{
				obtenerBDAsync();
			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_ENVIAR_BD_VENDEDOR))
			{
				try
				{
					Consultas.ConsultasVisita.eliminarVisitasSinMovimientos(false);
					if (validarJornada()) {
                        Recibos recibos = new Recibos();
                        recibos.generarPendientesPDF(mVista);
                        enviarDatosAsync();
                    }
				}
				catch (Exception e)
				{
					e.printStackTrace();
				}
			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_TERMINAL) || mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_VENDEDOR) || mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_PENDIENTES) || mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_INVENTARIO) || mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_CONFIRMACIONPEDIDO) || mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_DOCUMENTO) || mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_TIMBRADO_CDFIs) || mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_CLIENTES_NUEVOS) || mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_ACT_CLIENTES_AGENDA))
			{
				recibirDatosAsync();
			}else if (mAccion.equals(Enumeradores.Acciones.ACCION_MODIFICAR_CONTRASENA_USUARIO)){
                ModificarContrasenaAsync();
            }else if (mAccion.equals(Enumeradores.Acciones.ACCION_OBTENER_NOFECHAFINAGENDA)){
                ObtenerNoFechaFinAgendaAsync();
            }else if (mAccion.equals(Enumeradores.Acciones.ACCION_OBTENER_FECHAINICIALAGENDANOMENOR)){
                ObtenerFechaInicialAgendaNoMenorAsync();
            }
            else if (mAccion.equals(Enumeradores.Acciones.ACCION_ENVIAR_MOV_SIN_INV_SIN_VISITA)){
                try
                {
                    tipoEnvioInformacion=TipoEnvioInfo.ENVIO_MOV_SIN_INV_SIN_VISITA;
                    if (HayMovSinInvVisitaSinEnviar())
                        enviarMovSinInvVisitaAsync();
                }catch (Exception e)
                {
                    e.printStackTrace();
                }
            }else if (mAccion.equals(Enumeradores.Acciones.ACCION_LIMPIAR_CLAVEACCESO)){
				ObtenerLimpiarClaveAccesoAsync();
			}
            else if (mAccion.equals(Enumeradores.Acciones.ACCION_ENVIAR_ARCHIVO_PDF)){
                enviarTicketPDFAsync();
            }
            else if (mAccion.equals(Enumeradores.Acciones.ACCION_CONSULTAR_ESTADO_CUENTA)){
                obtenerEstadoCuentaAsync();
            }

		}
	}

	private boolean validarJornada() throws Exception
	{

		if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_JORNADA ){
			Vendedor vendedor = (Vendedor)
					Sesion.get(Campo.VendedorActual);
			Dia dia = (Dia) Sesion.get(Campo.DiaActual);
			int Inventario = Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("Inventario").toString());
			int ValidaInv = Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("ValidaInv").toString());
			int VentaSinSurtir = Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("VentaSinSurtir").toString());

			if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && VentaSinSurtir == 0) //no validar ventas sin surtir en envio parcial
			{
				String clientesPorSurtir = Consultas.ConsultaRegistroInicioFin.obtenerClientesPorSurtir();		
				if (!clientesPorSurtir.equals("")){
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("E0751").replace("$0$", clientesPorSurtir));
					mVista.finalizar();
					return false;
				}
			}

			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ValidarInvFinJornada") && (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ValidarInvFinJornada").toString().equals("1"))){
				String ProductosFaltantes = Consultas.ConsultaRegistroInicioFin.obtenerDiferenciasInventario();
				if (!ProductosFaltantes.equals("")){
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("I0355").replace("$0$",ProductosFaltantes));
					mVista.finalizar();
					return false;
				}
			}

            if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("ValidaInvNoDisp", ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString())){
                try{
                    if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("ValidaInvNoDisp", ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString()).equals("1")){
                        if (Consultas.ConsultaRegistroInicioFin.ValidarInventarioABordoNosDisp()){
                            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("E0970"));
                            mVista.finalizar();
                            return false;
                        }
                    }
                }catch(Exception ex){
                    mVista.mostrarError("Error al obtener parámetro ValidaInvNoDisp ");
                    mVista.finalizar();
                    return false;
                }
            }

			if (vendedor.JornadaTrabajo )
			{
				if (!Consultas.ConsultasVendedorJornada.todasLasJornadasCerradas()){
					if(Inventario == 0 && ValidaInv ==1) {
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("E0687"));
						mVista.finalizar();
						return false;
					}
				}else{
					//Si ya estan cerradas todas las jornadas, se eliminan Jornadas sin asignacion (por escenario no encontrado que crea jornadas de mas)
					Consultas.ConsultasVendedorJornada.eliminarJornadaSinAsignacionDeDia(vendedor);
				}
				
				VendedorJornada vendedorJornada = Consultas.ConsultasVendedorJornada.obtenerUltimaJornada(vendedor);
				if(vendedorJornada == null || vendedorJornada.FechaFinal == null){
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("E0687"));
					mVista.finalizar();
					return false;
				}
				//Se ejecuta para el escenario en el que el registro con Fechas vacias en mas reciente que en el que se cerro jornada (escenario no encontrado)
				Consultas.ConsultasVendedorJornada.eliminarJornadaSinAsignacionDeDia(vendedor);
			}

			
			if (((Vendedor) Sesion.get(Campo.VendedorActual)).Kilometraje ) 
			{
				CamionVendedor mCamionVendedor = Consultas.ConsultasKilometraje.obtenerCamiondeVendedor();
				if (mCamionVendedor.KmInicial != 0.0 && mCamionVendedor.KmFinal == 0.0)
				{
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("E0720"));
					mVista.finalizar();
					return false;
				}
			}
		}

		return true;
	}


    private boolean HayMovSinInvVisitaSinEnviar() throws Exception
    {
        if (!Consultas.ConsultasTransProd.HayMovSinInvSinVisitaSinEnviar()){
            Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("I0162"));
            mVista.finalizar();
            return false;
        }
        return true;
    }

    private Dia validarAgenda(){
        try{
            return Consultas.ConsultasAgenda.obtenerDiaClaveAgendaFechaCaptura();
        }catch(Exception ex){
            mVista.mostrarError(ex.getMessage());
            return null;
        }
    }

	public void obtenerBDAsync()
	{
		LogFile logFile;
		logFile = new LogFile("ObtenerBD");
		logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | obtenerBDAsync");

		Runnable obtenerBD = new Runnable()
		{
			public void run()
			{
				obtenerBD();
			}
		};
		new Thread(obtenerBD).start();
	}

	private void enviarDatosAsync()
	{
		LogFile logFile;
		logFile = new LogFile("EnviarDatos");
		logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | enviarDatosAsync");
		Runnable enviarDatos = new Runnable()
		{
			public void run()
			{
				enviarDatos();
			}
		};
		new Thread(enviarDatos).start();
	}

	private void recibirDatosAsync()
	{
		Runnable recibirDatos = new Runnable()
		{
			public void run()
			{
				recibirDatos();
			}
		};
		new Thread(recibirDatos).start();
	}

    public void obtenerEstadoCuentaAsync()
    {
        Runnable obtenerEdoCta = new Runnable()
        {
            public void run()
            {
                obtenerEstadoCuentaCliente();
            }
        };
        new Thread(obtenerEdoCta).start();
    }

    private void ModificarContrasenaAsync()
    {
        Runnable ModificarContrasena = new Runnable()
        {
            public void run()
            {
                ModificarContrasena();
            }
        };
        new Thread(ModificarContrasena).start();
    }

    private void ObtenerFechaInicialAgendaNoMenorAsync()
    {
        Runnable ObtenerFechaInicialAgendaNoMenor = new Runnable()
        {
            public void run()
            {
                ObtenerFechaInicialAgendaNoMenor();
            }
        };
        new Thread(ObtenerFechaInicialAgendaNoMenor).start();
    }

    private void ObtenerNoFechaFinAgendaAsync()
    {
        Runnable ObtenerNoFechaFinAgenda = new Runnable()
        {
            public void run()
            {
                ObtenerNoFechaFinAgenda();
            }
        };
        new Thread(ObtenerNoFechaFinAgenda).start();
    }

	private void ObtenerLimpiarClaveAccesoAsync()
	{
		Runnable ObtenerLimpiarClaveAcceso = new Runnable()
		{
			public void run()
			{
				ObtenerLimpiarClaveAcceso();
			}
		};
		new Thread(ObtenerLimpiarClaveAcceso).start();
	}

	private void enviarMovSinInvVisitaAsync()
    {
        Runnable enviarDatos = new Runnable()
        {
            public void run()
            {
                enviarDatosMovSinInvSinVisita();
            }
        };
        new Thread(enviarDatos).start();
    }

    private void enviarTicketPDFAsync()
    {
        Runnable enviarDatos = new Runnable()
        {
            public void run()
            {
                enviarTicketPDF();
            }
        };
        new Thread(enviarDatos).start();
    }

	private void enviarDatos()
	{
		LogFile logFile;
		logFile = new LogFile("EnviarDatos");
		logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | EnviarDatos");
		SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");

		ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

        mVista.setMaxPasos(8);

		mVista.setTextoPasos(Mensajes.get("MDBPreparando"));
		String nombreArchivo = "";
		try
		{
			//Folio CAI 5869 Se valida que si el transprod tiene productos con envase se haya generado su contraparte de tipo devolucion, si no es el caso, se repite el proceso
			if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("RecAutoEnvVenta").equals("1")) {
				try {
					if (!Transacciones.verificarRecoleccionAutomaticaEnvase()) {
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL,"No puede continuar debido a que se encontraron descuadres en envase.");
						mVista.finalizar();
						return;
					}
				} catch (Exception ex) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL,"No puede continuar debido a que se encontraron descuadres en envase.");
					mVista.finalizar();
					return;
				}
			}
			//Se agregó este metodo para eliminar los registros de CamionVendedor que se queden con diaClave = null folio: 4537
			Consultas.ConsultasKilometraje.eliminarCamionVendedorDiaClaveNull();

			mVista.setProgresoPasos(1);
			mVista.setTextoPasos("Probando Acceso al servicio");

			if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
			{
				Dispositivo.EncenderApagarWiFi(mVista, true, 4);
			}

			//Validar Conexion con el servicio
			if (!ServicesCentral.ProbarAccesoServicio())
			{
				logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | F0008");
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("F0008"));
				mVista.finalizar();
				return;
			}

            mVista.setProgresoPasos(2);
            mVista.setTextoPasos("Validando Licenciamiento");
            if (! ServicesCentral.WSLicenciamientoVigente()){
                String fechaVencimiento = ServicesCentral.WSFechaVencimientoUltimaFactura();
                if (fechaVencimiento.equalsIgnoreCase("Inactivo")){
					logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | E0891");
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0891] El contrato que ampara el licenciamiento de Route se encuentra dado de baja. Será deshabilitado el servicio de comunicaciones ");
                    mVista.finalizar();
                    return;
                }else if (fechaVencimiento.equalsIgnoreCase("NoDisponible")) {
					logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | E0895");
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0895] El servicio para validación del periodo de licenciamiento no se encuentra disponible. Comuníquese con el Proveedor ");
                    mVista.finalizar();
                    return;
				}else if (fechaVencimiento.equalsIgnoreCase("RFCIncorrecto")) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al cliente que solicita licencia. Comuníquese con el Proveedor ");
					mVista.finalizar();
					return;
				}else if (fechaVencimiento.equalsIgnoreCase("TipoProductoIncorrecto")) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al producto que solicita licencia. Comuníquese con el Proveedor ");
					mVista.finalizar();
					return;
                }else if(fechaVencimiento.equals("") ){
					logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | E0895");
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0895] El servicio para validación del periodo de licenciamiento no se encuentra disponible. Comuníquese con el Proveedor ");
                    mVista.finalizar();
                    return;
                }else{
                    try{
                        Calendar cal = Calendar.getInstance();
                        cal.set(Integer.parseInt(fechaVencimiento.substring(6,10)),(Integer.parseInt(fechaVencimiento.substring(3,5)))-1,Integer.parseInt(fechaVencimiento.substring(0,2)));
                        Date dateRepresentation = cal.getTime();
                        if (dateRepresentation.before(Generales.getFechaActual())){
							logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | E0894");
                            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0894] El periodo de licenciamiento pagado ha caducado. Será deshabilitado el servicio de comunicaciones");
                            mVista.finalizar();
                            return;
                        }else if (dateRepresentation.after(Generales.getFechaActual())){
							logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSActualizarFechaVencimiento");
                            ServicesCentral.WSActualizarFechaVencimiento();
                        }
                    }catch (Exception ex){
						logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | Fecha de contrato inválida");
                        mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "Fecha de contrato inválida");
                        mVista.finalizar();
                        return;
                    }
                }
            }

            mVista.setProgresoPasos(3);
            mVista.setTextoPasos("Verificando Licencia");

			ServicesCentral.TipoLicencia tipoLicencia = ServicesCentral.WSTipo_Licencia();

            //Validar Licencia
            if (tipoLicencia != ServicesCentral.TipoLicencia.Definitivo)
            {
				if (tipoLicencia == ServicesCentral.TipoLicencia.RFCIncorrecto) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al cliente que solicita licencia. Comuníquese con el Proveedor ");
				}else if (tipoLicencia == ServicesCentral.TipoLicencia.TipoProductoIncorrecto ){
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al producto que solicita licencia. Comuníquese con el Proveedor ");
				}else {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El dispositivo no tiene una licencia válida");
				}
                mVista.finalizar();
                return;
            }

			if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_JORNADA){				
				if (((CONHist) Sesion.get(Campo.CONHist)).get("Preliquidacion").equals("1")) //no validar preliquidacion en envio parcial
				{
					float MontoTotalPreLiquidacion = 0;
					float DiferenciaPreliqui = Float.parseFloat(((CONHist) Sesion.get(Campo.CONHist)).get("DiferenciaPreliqui").toString());
					ISetDatos mPreliquidacion = Consultas.ConsultaPreLiquidacion.obtenerPreLiquidacion();
					while (mPreliquidacion.moveToNext())
					{
						MontoTotalPreLiquidacion = mPreliquidacion.getFloat(2);
					}
					if (Math.abs(MontoTotalPreLiquidacion) > DiferenciaPreliqui)
					{
						logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | E0894");
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("E0586"));
						mVista.finalizar();
						return;
					}
				}

                //Se agrega la validacion aquí ya que estando dentro del metodo fileDatosEnviar(...) se ejecuta antes el proceso de crear los movimientos en automatico
                //y estos se crean con el Enviado=0, lo cual hace que siempre que llega a la validacion del metodo fileDatosEnviar(...) hay algo pendiente de enviar
                if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_JORNADA ) {
                    if (!Envio.HayDatosSinEnviar(Envio.TABLAS_ENVIO_JORNADA)){//Cliente.class, ClienteDomicilio.class, ClienteEsquema.class, CLIFormaVenta.class, Visita.class, VisitaHist.class, Agenda.class, TiempoMuerto.class, PuntoGPS.class, TransProd.class, TransProdDetalle.class, TPDImpuesto.class, TrpPrp.class, TpdDes.class, TPDDesVendedor.class, TpdPun.class, VendedorMensaje.class, Abono.class, AbonoHist.class, ABNDetalle.class, AbnTrp.class, AbnTrpHist.class, TRPCheque.class, CuotaCumplida.class, CucCcu.class, CupCcu.class, CueCcu.class, FolioReservacion.class);
                        throw new Exception(Mensajes.get("I0162"));
                    }
                } else if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_PARCIAL ) {
                    if (!Envio.HayDatosSinEnviar(Envio.TABLAS_ENVIO_PARCIAL)){//Cliente.class, ClienteDomicilio.class, ClienteEsquema.class, CLIFormaVenta.class, Visita.class, VisitaHist.class, Agenda.class, TiempoMuerto.class, PuntoGPS.class, TransProd.class, TransProdDetalle.class, TPDImpuesto.class, TrpPrp.class, TpdDes.class, TPDDesVendedor.class, TpdPun.class, VendedorMensaje.class, Abono.class, AbonoHist.class, ABNDetalle.class, AbnTrp.class, AbnTrpHist.class, TRPCheque.class, CuotaCumplida.class, CucCcu.class, CupCcu.class, CueCcu.class, FolioReservacion.class);
                        throw new Exception(Mensajes.get("I0162"));
                    }
                } else if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_PENDIENTES_VENDEDOR ) {
                    if (!Envio.HayDatosSinEnviar(Envio.TABLAS_ENVIO_PENDIENTES)) {
                        throw new Exception(Mensajes.get("I0162"));
                    }
                }

				MOTConfiguracion oMOT = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
				
				//Creación de movimiento de inventario a bordo (Tipo = 23), solo se genera si no esta activa la descarga automatica
				if (((CONHist) Sesion.get(Campo.CONHist)).get("Inventario").equals("1") && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != TiposModulos.PREVENTA) && oMOT.get("DescargaAutomatica").toString().equals("0") ) 
				{
					Inventario.CrearMovimientoAutomatico(TipoEnvioMovimientosAutomaticos.InventarioABordo );
				}
				
				//Creacion de movimiento de descarga automatica (Tipo = 7)
				if(oMOT.get("DescargaAutomatica").toString().equals("1") && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != TiposModulos.PREVENTA)){
					Inventario.CrearMovimientoAutomatico(TipoEnvioMovimientosAutomaticos.DescargaAutomatica);
				}

				//Creacion de movimiento devolucion al almacen (Tipo = 4)
				if(oMOT.get("DevolucionAutomatica").toString().equals("1") && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != TiposModulos.PREVENTA)){
					Inventario.CrearMovimientoAutomatico(TipoEnvioMovimientosAutomaticos.DevolucionAutomatica);
				}
			}

			
			mVista.setProgresoPasos(4);
			mVista.setTextoPasos("Preparando paquete de envio");

			StringBuilder sbMsgError = new StringBuilder();
			if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_JORNADA ) {
                nombreArchivo = Envio.fileDatosEnviar(Envio.TABLAS_ENVIO_JORNADA); //Cliente.class, ClienteDomicilio.class, ClienteEsquema.class, CLIFormaVenta.class, Visita.class, VisitaHist.class, Agenda.class, TiempoMuerto.class, PuntoGPS.class, TransProd.class, TransProdDetalle.class, TPDImpuesto.class, TrpPrp.class, TpdDes.class, TPDDesVendedor.class, TpdPun.class, VendedorMensaje.class, Abono.class, AbonoHist.class, ABNDetalle.class, AbnTrp.class, AbnTrpHist.class, TRPCheque.class, CuotaCumplida.class, CucCcu.class, CupCcu.class, CueCcu.class, FolioReservacion.class);
            }
			else if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_PARCIAL ) {
                //TODO: No enviar CamionVendedor, Preliquidacion, PLIBancario, PLIEfectivo
                nombreArchivo = Envio.fileDatosEnviar(Envio.TABLAS_ENVIO_PARCIAL); //Cliente.class, ClienteDomicilio.class, ClienteEsquema.class, CLIFormaVenta.class, Visita.class, VisitaHist.class, Agenda.class, TiempoMuerto.class, PuntoGPS.class, TransProd.class, TransProdDetalle.class, TPDImpuesto.class, TrpPrp.class, TpdDes.class, TPDDesVendedor.class, TpdPun.class, VendedorMensaje.class, Abono.class, AbonoHist.class, ABNDetalle.class, AbnTrp.class, AbnTrpHist.class, TRPCheque.class, CuotaCumplida.class, CucCcu.class, CupCcu.class, CueCcu.class, FolioReservacion.class);
            }
			else if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_PENDIENTES_VENDEDOR )
				nombreArchivo = Envio.fileDatosEnviar(Envio.TABLAS_ENVIO_PENDIENTES);

		}
		catch (Exception e)
		{
			e.printStackTrace();
			if (e.getMessage().indexOf("I0162") != -1 && mContinuar)
			{
				logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_BIEN | " + e.getMessage());
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN, e.getMessage());
			}
			else
			{
				logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | " + e.getMessage());
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			}
			mVista.finalizar();
			return;
		}
		mVista.setProgresoPasos(5);
		mVista.setTextoPasos("Creando ZIP");

		File zipSal = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString(), "bd");
		try
		{
			File bdComprimir = new File(zipSal.getAbsolutePath(), nombreArchivo);
			zipSal = new File(zipSal.getAbsolutePath(), nombreArchivo.replace(".db", ".zip"));

			byte[] buffer = new byte[1024];
			FileOutputStream fout = new FileOutputStream(zipSal.getAbsolutePath());
			ZipOutputStream zout = new ZipOutputStream(fout);
			FileInputStream fin = new FileInputStream(bdComprimir.getAbsolutePath());
			zout.putNextEntry(new ZipEntry(bdComprimir.getName()));
			int length;
			Integer total = (int) (bdComprimir.length() / 1024);
			mVista.setMaxDetallePasos(total);
			long actual = 0;
			while ((length = fin.read(buffer)) > 0)
			{
				zout.write(buffer, 0, length);
				actual += length;
				Integer actualKB = (int) (actual / 1024);
				mVista.setProgresoDetallePasos(actualKB);
				mVista.setTextoProgreso("Comprimiendo base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
			}
			zout.closeEntry();
			fin.close();
			zout.close();
			bdComprimir.delete();
		}
		catch (IOException e)
		{
			e.printStackTrace();
			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | " + e.getMessage());
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			mVista.finalizar();
			return;
		}
		catch (Exception e)
		{
			e.printStackTrace();
			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | " + e.getMessage());
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			mVista.finalizar();
			return;
		}

		mVista.setProgresoPasos(6);
		mVista.setTextoPasos(Mensajes.get("I0160"));

		Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
        String dirImagenEnc = "";
        String dirImagenImprod = "";
        String dirImagenActivo = "";
		try
		{
            String directorioImagenes = obtenerDirectorioArchivos("ImagenEncuesta"); //imagenesEncuestas();
            if (directorioImagenes.length()>0){
				logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSEnviarArchivoZip | " + Enumeradores.TipoArchivoZip.ENCUESTA);
                ServicesCentral.WSEnviarArchivoZip(directorioImagenes, Enumeradores.TipoArchivoZip.ENCUESTA); // llamamos el metodo para comprimir las imagenes
                dirImagenEnc = directorioImagenes.replace(".zip", "");
            }

            directorioImagenes = obtenerDirectorioArchivos("ImagenFirma");
            if (directorioImagenes.length()>0){
				logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSEnviarArchivoZip | " + Enumeradores.TipoArchivoZip.FIRMA);
                ServicesCentral.WSEnviarArchivoZip(directorioImagenes, Enumeradores.TipoArchivoZip.FIRMA); // llamamos el metodo para comprimir las imagenes
            }

            directorioImagenes = obtenerDirectorioArchivos("TicketsPDF");
            if (directorioImagenes.length()>0){
				logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSEnviarArchivoZip | " + Enumeradores.TipoArchivoZip.TICKET_PDF);
                ServicesCentral.WSEnviarArchivoZip(directorioImagenes, Enumeradores.TipoArchivoZip.TICKET_PDF); // llamamos el metodo para comprimir las imagenes
            }

            directorioImagenes = obtenerDirectorioArchivos("ImagenImproductividad");
            if (directorioImagenes.length()>0){
				logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSEnviarArchivoZip | " + Enumeradores.TipoArchivoZip.IMPRODUCTIVIDAD);
                ServicesCentral.WSEnviarArchivoZip(directorioImagenes, Enumeradores.TipoArchivoZip.IMPRODUCTIVIDAD); // llamamos el metodo para comprimir las imagenes
                dirImagenImprod = directorioImagenes.replace(".zip", "");
            }

            directorioImagenes = obtenerDirectorioArchivos("ImagenActivo");
            if (directorioImagenes.length()>0){
				logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSEnviarArchivoZip | " + Enumeradores.TipoArchivoZip.ACTIVO);
                ServicesCentral.WSEnviarArchivoZip(directorioImagenes, Enumeradores.TipoArchivoZip.ACTIVO); // llamamos el metodo para comprimir las imagenes
                dirImagenActivo = directorioImagenes.replace(".zip", "");
            }

			Date fechaPrimerDia = Consultas.ConsultasServidorComunicaciones.obtenerFechaPrimerDia();
			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSActualizarCapturaSQLite | <parsVendedorID>" + vendedor.VendedorId + "</parsVendedorID><pardFechaInicial>" + formato.format(vendedor.Fecha) + "</pardFechaInicial><pardFechaPrimerDia>" + formato.format(fechaPrimerDia) + "</pardFechaPrimerDia><parsNombreZip>" + zipSal.getName() + "</parsNombreZip>");
            ServicesCentral.WSActualizarCapturaSQLite(vendedor.VendedorId, vendedor.Fecha, fechaPrimerDia, false, zipSal.getAbsolutePath());
			//mVista.mostrarError(Mensajes.get("MDBTodos"));
			zipSal.delete();	
			zipSal = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString(), "bd");
			zipSal = new File(zipSal.getAbsolutePath(), nombreArchivo.replace(".db", ".db-journal"));
			
			zipSal.delete();		
		}
		catch (Exception e)
		{
			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | " + e.getMessage());
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			zipSal.delete();	
			zipSal = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString(), "bd");
			zipSal = new File(zipSal.getAbsolutePath(), nombreArchivo.replace(".db", ".db-journal"));			
			zipSal.delete();	
			mVista.finalizar();
			return;
		}
		mVista.setProgresoPasos(7);
		mVista.setTextoPasos(Mensajes.get("I0160"));
		try
		{
			if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_JORNADA)
				Envio.marcarEnviados(tipoEnvioInformacion,Envio.TABLAS_ENVIO_JORNADA);
			else if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_PARCIAL)
				Envio.marcarEnviados(tipoEnvioInformacion,Envio.TABLAS_ENVIO_PARCIAL);
			else if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_PENDIENTES_VENDEDOR)
				Envio.marcarEnviados(tipoEnvioInformacion,Envio.TABLAS_ENVIO_PENDIENTES);

		}
		catch (Exception e)
		{
			e.printStackTrace();
			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | " + e.getMessage());
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			mVista.finalizar();
			return;
		}

		mVista.setProgresoPasos(8);
		mVista.setTextoPasos(Mensajes.get("MDBEnvInt"));
		try
		{
			Date fechaPrimerDia = Consultas.ConsultasServidorComunicaciones.obtenerFechaPrimerDia();
			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSEjecutarInterfaces | <parsVendedorID>" + vendedor.VendedorId + "</parsVendedorID><pardFechaInicial>" + formato.format(vendedor.Fecha) + "</pardFechaInicial><pardFechaPrimerDia>" + formato.format(fechaPrimerDia) + "</pardFechaPrimerDia>");
			ServicesCentral.WSEjecutarInterfaces(vendedor.VendedorId, vendedor.Fecha, Consultas.ConsultasServidorComunicaciones.obtenerFechaPrimerDia(), false);

		}
		catch (Exception e)
		{
			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | " + e.getMessage());
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			mVista.finalizar();
			return;
		}

		//CAI 5480
		try
		{
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ConfirmarPedidoProtheus") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ConfirmarPedidoProtheus").equals("1")) {
				ServicesCentral.WSObtenerConfirmacionPedidoProtheus(vendedor.Fecha, vendedor.Fecha,  vendedor.VendedorId);
			}
		}
		catch (Exception e)
		{
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
			mVista.finalizar();
			return;
		}

        try
        {
			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSOrganizarArchivosPDFxCliente");
            ServicesCentral.WSOrganizarArchivosPDFxCliente();

        }
        catch (Exception e)
        {
            /*mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;*/
        }
		 
		//CAI 3297, Actualizar la tabla de sincronizacion con la fecha y hora del dispositivo
		try
		{
			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSOrganizarArchivosPDFxCliente | <parsVendedorID>" + vendedor.VendedorId + "</parsVendedorID><pardFechaHoraDispositivo>" + formato.format(Generales.getFechaHoraActual()) + "</pardFechaHoraDispositivo>");
			ServicesCentral.WSActualizarSincronizacion(vendedor.VendedorId, Generales.getFechaHoraActual());
		}
		catch (Exception e)
		{
			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | " + e.getMessage());
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			mVista.finalizar();
			return;
		}

        //Se agrega la actualizacion de confirmaciones de pedido aqui mismo para aprovechar la conexion que ya esta abierta, sin embargo la falla
        //debe ser independiente.
        //Se llama solo cuando sea envío parcial
        /*try
        {
            if (tipoEnvioInformacion == TipoEnvioInfo.ENVIO_PARCIAL) {
                String errorActualizacionUsuarios = "";
                if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("SincronizarConfirmPedido").equals("1")) {
                    mVista.setProgresoPasos(9);
                    mVista.setTextoPasos("Sincronizando confirmación de pedidos....");
                    //Si se tiene que sincronizar las confirmaciones de pedido
                    StringBuilder resultado = new StringBuilder();
                    if (!actualizarDatosPorSp(resultado, false)) {
                        mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, resultado.toString());
                        mVista.finalizar();
                        return;
                    }
                }
            }
        }
        catch (Exception e)
        {
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }*/

        try
        {
            //Eliminar imagenes enviadas
            BorrarDirectorio(dirImagenEnc);
            BorrarDirectorio(dirImagenImprod);
            BorrarDirectorio(dirImagenActivo);
        }
        catch (Exception e){}

		logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_BIEN ");
		mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
		mVista.finalizar();
	}


    private void BorrarDirectorio(String directorio){
        if (directorio != "") {
            File dir = new File(directorio);
            File[] archivos = dir.listFiles();
            for (int i= 0; i<archivos.length; i++){
                archivos[i].delete();
            }
        }
    }

    private void BorrarImagenesTemporales(String directorio){
        if (directorio != "") {
            File dir = new File(directorio);
            File[] archivos = dir.listFiles();
            for (int i= 0; i<archivos.length; i++){
                if (archivos[i].getName().endsWith("_tmp.jpg"))
                    archivos[i].delete();
            }
        }
    }

	private void obtenerBD()
	{
		ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		LogFile logFile;
		logFile = new LogFile("ObtenerBD");
		logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | obtenerBD| Url: " + conf.get(CampoConfiguracion.URL).toString());

		String nombreArchivo = "";

		try
		{
            mVista.setMaxPasos(7);
			mVista.setTextoPasos("Probando Acceso a Servicio");

			if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
			{
				Dispositivo.EncenderApagarWiFi(mVista, true, 4);
			}
			//Validar Conexion con el servicio
			if (!ServicesCentral.ProbarAccesoServicio())
			{
				logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | F0008");
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[F0008] No se puede establecer conexión de Area Local. Avisar a Soporte Técnico.");
				mVista.finalizar();
				return;
			}

            //Se comenta este if porque las verificaciones no se hacian cuando ya existia la BD y se volvia a pedir agenda
			//if (!(mAccion.equals(Enumeradores.Acciones.ACCION_OBTENER_BD_VENDEDOR) && BDVend.estaAbierta()))
			//{
				mVista.setProgresoPasos(1);
				mVista.setTextoPasos("Validando Licenciamiento");
				if (! ServicesCentral.WSLicenciamientoVigente()){
					String fechaVencimiento = ServicesCentral.WSFechaVencimientoUltimaFactura();
					if (fechaVencimiento.equalsIgnoreCase("Inactivo")){
						logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | E0891");
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0891] El contrato que ampara el licenciamiento de Route se encuentra dado de baja. Será deshabilitado el servicio de comunicaciones ");
						mVista.finalizar();
						return;
					}else if (fechaVencimiento.equalsIgnoreCase("NoDisponible")) {
						logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | E0895");
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0895] El servicio para validación del periodo de licenciamiento no se encuentra disponible. Comuníquese con el Proveedor ");
						mVista.finalizar();
						return;
					}else if (fechaVencimiento.equalsIgnoreCase("RFCIncorrecto")) {
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al cliente que solicita licencia. Comuníquese con el Proveedor ");
						mVista.finalizar();
						return;
					}else if (fechaVencimiento.equalsIgnoreCase("TipoProductoIncorrecto")) {
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al producto que solicita licencia. Comuníquese con el Proveedor ");
						mVista.finalizar();
						return;
					}else if(fechaVencimiento.equals("") ){
						logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | E0895");
                        mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0895] El servicio para validación del periodo de licenciamiento no se encuentra disponible. Comuníquese con el Proveedor ");
                        mVista.finalizar();
                        return;
					}else{
                        try{
                            Calendar cal = Calendar.getInstance();
                            cal.set(Integer.parseInt(fechaVencimiento.substring(6,10)),(Integer.parseInt(fechaVencimiento.substring(3,5)))-1,Integer.parseInt(fechaVencimiento.substring(0,2)));
                            Date dateRepresentation = cal.getTime();
                            if (dateRepresentation.before(Generales.getFechaActual())){
								logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | E0894");
                                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0894] El periodo de licenciamiento pagado ha caducado. Será deshabilitado el servicio de comunicaciones");
                                mVista.finalizar();
                                return;
                            }else if (dateRepresentation.after(Generales.getFechaActual())){
								logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSActualizarFechaVencimiento");
                                ServicesCentral.WSActualizarFechaVencimiento();
                            }
                        }catch (Exception ex){
							logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | Fecha de contrato inválida");
                            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "Fecha de contrato inválida");
                            mVista.finalizar();
                            return;
                        }
                    }
				}

				mVista.setProgresoPasos(2);
				mVista.setTextoPasos("Verificando Licencia");

				ServicesCentral.TipoLicencia tipoLicencia = ServicesCentral.WSTipo_Licencia();

				//Validar Licencia
				if (tipoLicencia != ServicesCentral.TipoLicencia.Definitivo)
				{
					if (tipoLicencia == ServicesCentral.TipoLicencia.RFCIncorrecto) {
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al cliente que solicita licencia. Comuníquese con el Proveedor ");
					}else if (tipoLicencia == ServicesCentral.TipoLicencia.TipoProductoIncorrecto ){
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al producto que solicita licencia. Comuníquese con el Proveedor ");
					}else {
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El dispositivo no tiene una licencia válida");
					}

					mVista.finalizar();
					return;
				}

			//}
			


			mVista.setProgresoPasos(3);
			mVista.setTextoPasos("Creando Base Datos");

			/*
			 * if (!ServicesCentral.WSAuditoriaVerificar(mVista)){
			 * mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL,
			 * "[E0562] El resultado de la auditoria de la información refleja que existen datos incorrectos o existen Objetos que no han sido Auditados."
			 * ); mVista.finalizar(); return; }
			 */
			if (mAccion.equals(Enumeradores.Acciones.ACCION_OBTENER_BD_TERMINAL))
			{
				logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSAplicacionObtenerBDSqLite | <parsTerminalNumeroSerie>" + conf.get(CampoConfiguracion.NUMERO_SERIE) + "</parsTerminalNumeroSerie><parsUsuarioClave>" + conf.get(CampoConfiguracion.USUARIO) + "</parsUsuarioClave>");
				nombreArchivo = ServicesCentral.WSAplicacionObtenerBDSqLite();
			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_OBTENER_BD_VENDEDOR))
			{
				SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");
				Date fechaFin = mfechaFin;
				fechaFin.setHours(23);
				fechaFin.setMinutes(59);
				logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSVendedorObtenerBDSQLite | <parsTerminalNumeroSerie>" + conf.get(CampoConfiguracion.NUMERO_SERIE).toString() + "</parsTerminalNumeroSerie><parsUsuarioClave>" + conf.get(CampoConfiguracion.USUARIO) + "</parsUsuarioClave><parsContrasena>" + conf.get(CampoConfiguracion.PASSWORD) + "</parsContrasena><pardFechaIni>" + formato.format(mfechaIni) + "</pardFechaIni><pardFechaFin>" + formato.format(fechaFin) + "</pardFechaFin><parsTiposConsulta>1,3,6,10</parsTiposConsulta>");
				nombreArchivo = ServicesCentral.WSVendedorObtenerBDSQLite(mfechaIni, mfechaFin);
			}
		}
		catch (Exception e)
		{
			e.printStackTrace();
			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | " + e.getMessage());
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			mVista.finalizar();
			return;
		}

		mVista.setProgresoPasos(4);
		mVista.setTextoPasos("Descargando Archivo");

		try
		{

			File destino = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
			destino = new File(destino, "bd");
			destino.mkdirs();
			String dirDestino = destino.getAbsolutePath();
			destino = new File(destino, nombreArchivo + ".zip");

			if (destino.exists())
				destino.delete();
			destino.createNewFile();

			int[] tamanioArchivo =
			{ 0 };

			InputStream in = ServicesCentral.DescargarBD(nombreArchivo, tamanioArchivo);
			OutputStream out = new FileOutputStream(destino);
			Integer total = (int) (tamanioArchivo[0] / 1024);
			mVista.setMaxDetallePasos(total);
			long actual = 0;
			byte[] buf = new byte[1024];
			int len;
			while ((len = in.read(buf)) > 0)
			{
				out.write(buf, 0, len);
				actual += len;
				Integer actualKB = (int) (actual / 1024);
				mVista.setProgresoDetallePasos(actualKB);
				mVista.setTextoProgreso("descargando base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
			}
			in.close();
			out.close();

			mVista.setMaxDetallePasos(0);
			mVista.setTextoProgreso("");

			mVista.setProgresoPasos(5);
			mVista.setTextoPasos("Descomprimiendo Archivo");

			FileInputStream fin = new FileInputStream(destino.getAbsolutePath());
			ZipInputStream zin = new ZipInputStream(fin);
			ZipEntry ze = null;
			while ((ze = zin.getNextEntry()) != null)
			{
				File resFile = new File(dirDestino, ze.getName());
				if (resFile.exists())
					resFile.delete();
				FileOutputStream fout = new FileOutputStream(resFile.getAbsolutePath());

				byte[] tempBuffer = new byte[8192 * 2];
				total = (int) (ze.getSize() / (8192 * 2));
				total = (total * 2);
				mVista.setMaxDetallePasos(total);
				actual = 0;
				while ((len = zin.read(tempBuffer)) != -1)
				{
					fout.write(tempBuffer, 0, len);
					actual += len;
					Integer actualKB = (int) (actual / 8192 * 2);
					mVista.setProgresoDetallePasos(actualKB);
					mVista.setTextoProgreso("descomprimiendo base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
				}

				zin.closeEntry();
				fout.close();
			}
			zin.close();
			fin.close();
			destino.delete();

			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSEliminarArchivoBases | <parsNombreArchivo>" + nombreArchivo + "</parsNombreArchivo>");
			ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");

			if (mAccion.equals(Enumeradores.Acciones.ACCION_OBTENER_BD_VENDEDOR))
			{
				BDVend.cerrar();
				BDVend.Iniciar();
				boolean InventarioPorLotes = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("InventarioPorLotes") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("InventarioPorLotes").equals("1");
				if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").equals("1")) {
					InventarioDobleUnidad.CargarInventarioPedido();
				}else{
					if (InventarioPorLotes)
						InventarioLotes.CargarInventarioPedido();
					else
						Inventario.CargarInventarioPedido();
				}
				
				BDVend.cerrar();
				BDVend.Iniciar();
				if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").equals("1")){
					InventarioDobleUnidad.CargasFaseTransferir();
				}else {
					if (InventarioPorLotes)
						InventarioLotes.CargasFaseTransferir();
					else
						Inventario.CargasFaseTransferir();
				}

				BDVend.cerrar();
				BDVend.Iniciar();

				if (InventarioPorLotes)
					InventarioLotes.CargarInventarioABordo();
				else
					Inventario.CargarInventarioABordo();
				
                /*If Not oVendedor.motconfiguracion.descargaAutomatica Then
                Dim ldtInventarioABordo As DataTable = oDBVen.RealizarConsultaSQL("Select distinct TPD.TransProdId, TPD.TransProdDetalleId, TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad from TransProd TP Inner Join TransProdDetalle TPD ON TP.TransProdId=TPD.TransProdId and TP.Tipo=23 and TP.TipoFase<>0 and TP.MUsuarioId='" & oVendedor.UsuarioId & "'", "InventarioABordo")
                Inventario.CargarInventarioABordo(ldtInventarioABordo)
                ldtInventarioABordo.Dispose()
            End If*/
			}

			mVista.setProgresoPasos(6);
            mVista.setTextoPasos("Actualizando Usuarios....");
            String errorActualizacionUsuarios = "";
            if (mAccion.equals(Enumeradores.Acciones.ACCION_OBTENER_BD_VENDEDOR)) {
                if (ValoresReferencia.getValor("ACTSMLO","2") != null) {
                    StringBuilder resultado = new StringBuilder();
                    if (!actualizarUsuariosPoliticas(resultado)) {

                        errorActualizacionUsuarios =  resultado.toString();
                    }
                }

                try{
                    //Si se usa la confirmacion de pedido
                    if (Sesion.get(Campo.MOTConfiguracion) != null && ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("SincronizarConfirmPedido").equals("1")){
                        String sTransProdID = Consultas.ConsultasPedidosConfirmadosSAP.obtenerIdsConfirmadosSAP();
                        if (sTransProdID.length() >0){
							logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSMarcarRegistrosActualizados | <pariTipoActualizacion>" + ServicesCentral.TiposActualizacion.ConfirmacionPedidosCos + "</pariTipoActualizacion><parsIdsCargados>" + sTransProdID + "</parsIdsCargados>");
                            ServicesCentral.WSMarcarRegistrosActualizados(ServicesCentral.TiposActualizacion.ConfirmacionPedidosCos, sTransProdID);
                        }
                    }
                }catch(Exception ex){
                    if (ex != null) {
                        errorActualizacionUsuarios += ex.getMessage();
                    }
                }
            }

			//Imagenes
			boolean imagenesProducto = false;
			try{
				imagenesProducto = ServicesCentral.WSValidarParametro("BusquedaConImagenes");
				if(imagenesProducto){
					mVista.setProgresoPasos(7);
					mVista.setTextoPasos("Descargando Imagenes");

					File destinoImg = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
					destinoImg = new File(destinoImg, "ImgProd");
					destinoImg.mkdirs();
					String dirDestinoImg = destinoImg.getAbsolutePath();

					//Verificar si existen imagenes
					File file = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString()+"/ImgProd/");
					File imageList[] = file.listFiles();
					if(imageList.length>0){
						Date lastModified = new Date(file.lastModified());
						nombreArchivo = ServicesCentral.WSVendedorObtenerImagenes(lastModified, false);
					}else{
						nombreArchivo = ServicesCentral.WSVendedorObtenerImagenes(Generales.getFechaHoraActual(), true);
					}
					//Verificar si existen imagenes
					destinoImg = new File(destinoImg, nombreArchivo + ".zip");

					if (destinoImg.exists())
						destinoImg.delete();
					destinoImg.createNewFile();

					int[] tamanioArchivoImg = { 0 };

					InputStream inImg = ServicesCentral.DescargarImagenes(nombreArchivo, tamanioArchivoImg);
					OutputStream outImg = new FileOutputStream(destinoImg);
					Integer totalImg = (int) (tamanioArchivoImg[0] / 1024);
					mVista.setMaxDetallePasos(totalImg);
					long actualImg = 0;
					byte[] bufImg = new byte[1024];
					int lenImg;
					while ((lenImg = inImg.read(bufImg)) > 0)
					{
						outImg.write(bufImg, 0, lenImg);
						actualImg += lenImg;
						Integer actualKB = (int) (actualImg / 1024);
						mVista.setProgresoDetallePasos(actualKB);
						mVista.setTextoProgreso("descargando base de datos (" + actualKB.toString() + " de " + totalImg.toString() + ")");
					}
					inImg.close();
					outImg.close();

					mVista.setMaxDetallePasos(0);
					mVista.setTextoProgreso("");

					mVista.setProgresoPasos(8);
					mVista.setTextoPasos("Descomprimiendo Archivo Imagenes");

					FileInputStream finImg = new FileInputStream(destinoImg.getAbsolutePath());
					ZipInputStream zinImg = new ZipInputStream(finImg);
					ZipEntry zeImg = null;
					while ((zeImg = zinImg.getNextEntry()) != null)
					{
						File resFile = new File(dirDestinoImg, zeImg.getName());
						if (resFile.exists())
							resFile.delete();
						FileOutputStream fout = new FileOutputStream(resFile.getAbsolutePath());

						byte[] tempBuffer = new byte[8192 * 2];
						total = (int) (zeImg.getSize() / (8192 * 2));
						total = (total * 2);
						mVista.setMaxDetallePasos(total);
						actualImg = 0;
						while ((lenImg = zinImg.read(tempBuffer)) != -1)
						{
							fout.write(tempBuffer, 0, lenImg);
							actualImg += lenImg;
							Integer actualKB = (int) (actualImg / 8192 * 2);
							mVista.setProgresoDetallePasos(actualKB);
							mVista.setTextoProgreso("descomprimiendo base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
						}

						zinImg.closeEntry();
						fout.close();
					}
					zinImg.close();
					finImg.close();
					destinoImg.delete();

					logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSEliminarArchivoImagenes | <parsNombreArchivo>" + nombreArchivo + "</parsNombreArchivo>");
					ServicesCentral.WSEliminarArchivoImagenes(nombreArchivo + ".zip");
				}
			}catch(Exception ex){
				String msg = ex.getMessage();
			}
			//Imagenes

			//Logo
			boolean imagenLogo = false;
			try{
				imagenLogo = ServicesCentral.WSValidarParametro("FormatoConfigPDFWApp");
				if(imagenesProducto){
					mVista.setProgresoPasos(7);
					mVista.setTextoPasos("Descargando Logo");

					File destinoImg = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
					destinoImg = new File(destinoImg, "ImgLogo");
					destinoImg.mkdirs();
					String dirDestinoImg = destinoImg.getAbsolutePath();

					//Verificar si existen imagenes
					File file = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString()+"/ImgLogo/");
					File imageList[] = file.listFiles();
					if(imageList.length>0){
						Date lastModified = new Date(file.lastModified());
						nombreArchivo = ServicesCentral.WSVendedorObtenerLogo(lastModified, false);
					}else{
						nombreArchivo = ServicesCentral.WSVendedorObtenerLogo(Generales.getFechaHoraActual(), true);
					}
					//Verificar si existen imagenes
					destinoImg = new File(destinoImg, nombreArchivo + ".zip");

					if (destinoImg.exists())
						destinoImg.delete();
					destinoImg.createNewFile();

					int[] tamanioArchivoImg = { 0 };

					InputStream inImg = ServicesCentral.DescargarImagenes(nombreArchivo, tamanioArchivoImg);
					OutputStream outImg = new FileOutputStream(destinoImg);
					Integer totalImg = (int) (tamanioArchivoImg[0] / 1024);
					mVista.setMaxDetallePasos(totalImg);
					long actualImg = 0;
					byte[] bufImg = new byte[1024];
					int lenImg;
					while ((lenImg = inImg.read(bufImg)) > 0)
					{
						outImg.write(bufImg, 0, lenImg);
						actualImg += lenImg;
						Integer actualKB = (int) (actualImg / 1024);
						mVista.setProgresoDetallePasos(actualKB);
						mVista.setTextoProgreso("descargando base de datos (" + actualKB.toString() + " de " + totalImg.toString() + ")");
					}
					inImg.close();
					outImg.close();

					mVista.setMaxDetallePasos(0);
					mVista.setTextoProgreso("");

					mVista.setProgresoPasos(8);
					mVista.setTextoPasos("Descomprimiendo Archivo Logo");

					FileInputStream finImg = new FileInputStream(destinoImg.getAbsolutePath());
					ZipInputStream zinImg = new ZipInputStream(finImg);
					ZipEntry zeImg = null;
					while ((zeImg = zinImg.getNextEntry()) != null)
					{
						File resFile = new File(dirDestinoImg, zeImg.getName());
						if (resFile.exists())
							resFile.delete();
						FileOutputStream fout = new FileOutputStream(resFile.getAbsolutePath());

						byte[] tempBuffer = new byte[8192 * 2];
						total = (int) (zeImg.getSize() / (8192 * 2));
						total = (total * 2);
						mVista.setMaxDetallePasos(total);
						actualImg = 0;
						while ((lenImg = zinImg.read(tempBuffer)) != -1)
						{
							fout.write(tempBuffer, 0, lenImg);
							actualImg += lenImg;
							Integer actualKB = (int) (actualImg / 8192 * 2);
							mVista.setProgresoDetallePasos(actualKB);
							mVista.setTextoProgreso("descomprimiendo base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
						}

						zinImg.closeEntry();
						fout.close();
					}
					zinImg.close();
					finImg.close();
					destinoImg.delete();

					logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | WSEliminarArchivoLogo | <parsNombreArchivo>" + nombreArchivo + "</parsNombreArchivo>");
					ServicesCentral.WSEliminarArchivoLogo(nombreArchivo + ".zip");
				}
			}catch(Exception ex){
				String msg = ex.getMessage();
			}
			//Imagenes

			if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
			{
				Dispositivo.EncenderApagarWiFi(mVista, false, 0);
			}

			if(imagenesProducto && imagenLogo)
				mVista.setProgresoPasos(11);
			else {
				if(imagenesProducto || imagenLogo){
					mVista.setProgresoPasos(9);
				}
				else
					mVista.setProgresoPasos(7);
			}
			mVista.setTextoPasos("Proceso Finalizado.....");

            if (Sesion.get(Campo.UsuarioSustitutoPendiente)== true){
                BDVend.cerrar();
                BDVend.Iniciar();

                UsuarioSustituto ust = new UsuarioSustituto();
                ust =(UsuarioSustituto)Sesion.get(Campo.ObjUsuarioSustitutoPendiente);
                ust.quitarRecuperado();

                Dia dia = validarAgenda();
                ust.DiaClave=dia.DiaClave;

                ust.FechaHoraInicio = Generales.getFechaHoraActual();

                Calendar cal = Calendar.getInstance();
                cal.setTime(ust.FechaHoraInicio);
                cal.set(Calendar.HOUR_OF_DAY, 23);
                cal.set(Calendar.MINUTE, 59);
                cal.set(Calendar.SECOND, 59);
                ust.FechaHoraFin = cal.getTime();

                BDVend.guardarInsertar(ust);
                BDVend.commit();
            }

            if (errorActualizacionUsuarios.length()>0){
				logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | " + errorActualizacionUsuarios);
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL,errorActualizacionUsuarios);
                mVista.finalizar();
                return;
            }
		}
		catch (FileNotFoundException e)
		{
			e.printStackTrace();
			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | " + e.getMessage());
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			mVista.finalizar();
			return;
		}
		catch (IOException e)
		{
			e.printStackTrace();
			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | " + e.getMessage());
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			mVista.finalizar();
			return;
		}
		catch (Exception e)
		{
			e.printStackTrace();
			logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_MAL | " + e.getMessage());
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			mVista.finalizar();
			return;
		}

		logFile.appendLog(Generales.getFechaHoraActualStr("hh:mm:ss") + " | RESULTADO_BIEN");

		mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
		mVista.finalizar();
	}

  /*  private void actualizarDatosPorSPInicioConexion(){
        try {
            mVista.setMaxPasos(7);
            mVista.setTextoPasos("Obteniendo Datos ultima actualización");
            mVista.setProgresoPasos(1);
            mVista.setTextoPasos("Probando Acceso al servicio");

            if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString())) {
                Dispositivo.EncenderApagarWiFi(mVista, true, 4);
            }

            //Validar Conexion con el servicio
            if (!ServicesCentral.ProbarAccesoServicio()) {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("F0008"));
                mVista.finalizar();
                return;
            }


            if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString())) {
                Dispositivo.EncenderApagarWiFi(mVista, false, 0);
            }
        }
        catch (FileNotFoundException e)
        {
            if (!archivosEliminados){
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")){
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if(!archivosServerEliminados){
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }
        catch (IOException e)
        {
            if (!archivosEliminados){
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")){
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if(!archivosServerEliminados){
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }
        catch (NullPointerException e)
        {
            if (!archivosEliminados){
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")){
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if(!archivosServerEliminados){
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "Error de nulos");
            mVista.finalizar();
            return;
        }
        catch (Exception e)
        {
            if (!archivosEliminados){
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")){
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if(!archivosServerEliminados){
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }

        mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
        mVista.finalizar();
    }*/

    private boolean actualizarDatosPorSp(StringBuilder mensajeError, boolean limpiarTablas) {
        //if (ValoresReferencia.getValor("ACTSMLO","2") == null ) return true;
        boolean archivosEliminados = true;
        boolean archivosServerEliminados = true;
        String extensionBorrar = "";
        String dirDestino = "";
        String nombreArchivo ="";

        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        DocumentBuilder db;

        Document xmlActualiza;
        try {
            ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

            File archXML = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
            archXML = new File(archXML, "bd");
            archXML = new File(archXML, BDVend.nombreBaseDatos().replace("db", "xml"));

            db = dbf.newDocumentBuilder();
            xmlActualiza = db.parse(new File(archXML.getAbsolutePath()));

            Date[] fechas = new Date[2];

            Consultas.ConsultasDia.obtenerRangoAgenda(fechas);
            if (fechas[0] != null && fechas[1] != null) {
                nombreArchivo = ServicesCentral.WSObtenerActualizacionPorSPSQLite(ServicesCentral.TiposActualizacion.ConfirmacionPedidosCos,fechas[0], fechas[1],"" );
            }

            if (nombreArchivo.length()<=0){
                return true;
            }

            archivosServerEliminados = false;
            File destino = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
            destino = new File(destino, "bd");
            destino.mkdirs();
            dirDestino = destino.getAbsolutePath();
            destino = new File(destino, nombreArchivo + ".zip");

            if (destino.exists())
                destino.delete();
            destino.createNewFile();

            int[] tamanioArchivo =
                    {0};
            InputStream in = ServicesCentral.DescargarBD(nombreArchivo, tamanioArchivo);
            OutputStream out = new FileOutputStream(destino);

            Integer total = (int) (tamanioArchivo[0] / 1024);
            mVista.setMaxDetallePasos(total);
            long actual = 0;
            byte[] buf = new byte[1024];
            int len;
            while ((len = in.read(buf)) > 0) {
                out.write(buf, 0, len);
                actual += len;
                Integer actualKB = (int) (actual / 1024);
                mVista.setProgresoDetallePasos(actualKB);
                mVista.setTextoProgreso("descargando base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
            }
            in.close();
            out.close();

            FileInputStream fin = new FileInputStream(destino.getAbsolutePath());
            ZipInputStream zin = new ZipInputStream(fin);
            ZipEntry ze = null;
            while ((ze = zin.getNextEntry()) != null) {
                File resFile = new File(dirDestino, ze.getName());
                if (resFile.exists())
                    resFile.delete();
                FileOutputStream fout = new FileOutputStream(resFile.getAbsolutePath());

                byte[] tempBuffer = new byte[8192 * 2];
                total = (int) (ze.getSize() / (8192 * 2));
                total = (total * 2);
                mVista.setMaxDetallePasos(total);
                actual = 0;
                while ((len = zin.read(tempBuffer)) != -1) {
                    fout.write(tempBuffer, 0, len);
                    actual += len;
                    Integer actualKB = (int) (actual / 8192 * 2);
                    mVista.setProgresoDetallePasos(actualKB);
                    mVista.setTextoProgreso("descomprimiendo base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
                }

                zin.closeEntry();
                fout.close();
            }
            zin.close();
            fin.close();
            destino.delete();

            mVista.setProgresoDetallePasos(0);
            mVista.setTextoProgreso("");

            // mVista.setProgresoPasos(5);
            //mVista.setTextoPasos("Procesando datos");
            archivosEliminados = false;

            extensionBorrar = ".db";
            Recepcion.procesarInfoRecibida(nombreArchivo + ".db", Enumeradores.TipoBD.BD_VENDEDOR , xmlActualiza, limpiarTablas);

            File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
            dataSet.delete();
            if (extensionBorrar.equalsIgnoreCase(".db")) {
                dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                dataSet.delete();
            }

            //ServicesCentral.WSActualizarFechaTablas(ServicesCentral.TiposSincronizacion.Terminal, "'Usuario','PoliticaContrasenaHist'");

            archivosEliminados = true;

            ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            archivosServerEliminados = true;

            return true;
        } catch (FileNotFoundException e) {
            if (!archivosEliminados) {
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")) {
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if (!archivosServerEliminados) {
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            if (mensajeError != null)
                mensajeError.append(e.getMessage());
            return false;

        } catch (IOException e) {
            if (!archivosEliminados) {
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")) {
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if (!archivosServerEliminados) {
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            if (mensajeError != null)
                mensajeError.append(e.getMessage());
            return false;
        } catch (NullPointerException e) {
            if (!archivosEliminados) {
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")) {
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if (!archivosServerEliminados) {
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            if (mensajeError != null)
                mensajeError.append(e.getMessage());
            return false;
        } catch (Exception e) {
            if (!archivosEliminados) {
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")) {
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if (!archivosServerEliminados) {
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            if (mensajeError != null)
                mensajeError.append(e.getMessage());
            return false;
        }
    }

    //El metodo no inicia conexion al SC, la debe estar iniciada
    //Si hay algun error se regresa en el parametro mensajeError, el cual ya debe estar inicializado desde donde se llama
    private boolean actualizarUsuariosPoliticas(StringBuilder mensajeError) {
        if (ValoresReferencia.getValor("ACTSMLO","2") == null ) return true;
        boolean archivosEliminados = true;
        boolean archivosServerEliminados = true;
        String extensionBorrar = "";
        String dirDestino = "";
        String nombreArchivo ="";

        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        DocumentBuilder db;

        Document xmlActualiza;
        try {
            ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

            File archXML = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
            archXML = new File(archXML, "bd");
            archXML = new File(archXML, conf.get(CampoConfiguracion.NUMERO_SERIE).toString() + ".xml");

            db = dbf.newDocumentBuilder();
            xmlActualiza = db.parse(new File(archXML.getAbsolutePath()));

            String tablasActualizadas = "''Usuario'',''PoliticaContrasenaHist''";
            nombreArchivo = ServicesCentral.WSAplicacionObtenerActualizacionSQLiteMetodo2(tablasActualizadas);

            if (nombreArchivo.length()<=0){
                return true;
            }

            archivosServerEliminados = false;
            File destino = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
            destino = new File(destino, "bd");
            destino.mkdirs();
            dirDestino = destino.getAbsolutePath();
            destino = new File(destino, nombreArchivo + ".zip");

            if (destino.exists())
                destino.delete();
            destino.createNewFile();

            int[] tamanioArchivo =
                    {0};
            InputStream in = ServicesCentral.DescargarBD(nombreArchivo, tamanioArchivo);
            OutputStream out = new FileOutputStream(destino);

            Integer total = (int) (tamanioArchivo[0] / 1024);
            mVista.setMaxDetallePasos(total);
            long actual = 0;
            byte[] buf = new byte[1024];
            int len;
            while ((len = in.read(buf)) > 0) {
                out.write(buf, 0, len);
                actual += len;
                Integer actualKB = (int) (actual / 1024);
                mVista.setProgresoDetallePasos(actualKB);
                mVista.setTextoProgreso("descargando base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
            }
            in.close();
            out.close();

            FileInputStream fin = new FileInputStream(destino.getAbsolutePath());
            ZipInputStream zin = new ZipInputStream(fin);
            ZipEntry ze = null;
            while ((ze = zin.getNextEntry()) != null) {
                File resFile = new File(dirDestino, ze.getName());
                if (resFile.exists())
                    resFile.delete();
                FileOutputStream fout = new FileOutputStream(resFile.getAbsolutePath());

                byte[] tempBuffer = new byte[8192 * 2];
                total = (int) (ze.getSize() / (8192 * 2));
                total = (total * 2);
                mVista.setMaxDetallePasos(total);
                actual = 0;
                while ((len = zin.read(tempBuffer)) != -1) {
                    fout.write(tempBuffer, 0, len);
                    actual += len;
                    Integer actualKB = (int) (actual / 8192 * 2);
                    mVista.setProgresoDetallePasos(actualKB);
                    mVista.setTextoProgreso("descomprimiendo base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
                }

                zin.closeEntry();
                fout.close();
            }
            zin.close();
            fin.close();
            destino.delete();

            mVista.setProgresoDetallePasos(0);
            mVista.setTextoProgreso("");

            // mVista.setProgresoPasos(5);
            //mVista.setTextoPasos("Procesando datos");
            archivosEliminados = false;

            extensionBorrar = ".db";
            Recepcion.procesarInfoRecibida(nombreArchivo + ".db", Enumeradores.TipoBD.BD_TERMINAL, xmlActualiza, true);

            File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
            dataSet.delete();
            if (extensionBorrar.equalsIgnoreCase(".db")) {
                dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                dataSet.delete();
            }

            ServicesCentral.WSActualizarFechaTablas(ServicesCentral.TiposSincronizacion.Terminal, "'Usuario','PoliticaContrasenaHist'");

            archivosEliminados = true;

            ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            archivosServerEliminados = true;

            return true;
        } catch (FileNotFoundException e) {
            if (!archivosEliminados) {
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")) {
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if (!archivosServerEliminados) {
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            if (mensajeError != null)
                mensajeError.append(e.getMessage());
            return false;

        } catch (IOException e) {
            if (!archivosEliminados) {
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")) {
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if (!archivosServerEliminados) {
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            if (mensajeError != null)
                mensajeError.append(e.getMessage());
            return false;
        } catch (NullPointerException e) {
            if (!archivosEliminados) {
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")) {
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if (!archivosServerEliminados) {
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            if (mensajeError != null)
                mensajeError.append(e.getMessage());
            return false;
        } catch (Exception e) {
            if (!archivosEliminados) {
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")) {
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if (!archivosServerEliminados) {
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            if (mensajeError != null)
                mensajeError.append(e.getMessage());
            return false;
        }
    }

	private void recibirDatos()
	{
		mVista.setMaxPasos(7);
		mVista.setTextoPasos("Obteniendo Datos ultima actualización");
		ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		String nombreArchivo = "";

		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		DocumentBuilder db;
		Document xmlActualiza;
        boolean archivosServerEliminados = true;
		try
		{
            File archXML = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
            archXML = new File(archXML, "bd");
            if (mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_TERMINAL)) {
                archXML = new File(archXML, conf.get(CampoConfiguracion.NUMERO_SERIE).toString() + ".xml");
            } else {
                archXML = new File(archXML, BDVend.nombreBaseDatos().replace("db", "xml"));
            }

            db = dbf.newDocumentBuilder();
            xmlActualiza = db.parse(new File(archXML.getAbsolutePath()));

			mVista.setProgresoPasos(1);
			mVista.setTextoPasos("Probando Acceso al servicio");

			if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
			{
				Dispositivo.EncenderApagarWiFi(mVista, true, 4);
			}

			//Validar Conexion con el servicio
			if (!ServicesCentral.ProbarAccesoServicio())
			{
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("F0008"));
				mVista.finalizar();
				return;
			}

			mVista.setProgresoPasos(2);
			mVista.setTextoPasos("Solicitando Actualización");

			if (mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_TERMINAL))
			{
				String dsXML = DocumentoXML.CrearDataSetActualiza("parsXMLUltActualizacion", xmlActualiza, mTablas);
				nombreArchivo = ServicesCentral.WSAplicacionObtenerActualizacion(dsXML, mTablas);
			}else if (mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_INVENTARIO))
			{
				String dsXML = DocumentoXML.CrearDataSetActualiza("parsXMLUltActualizacion", xmlActualiza, mTablas);
				nombreArchivo = ServicesCentral.WSVendedorObtenerActualizacionInventario(dsXML, ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId);
			}else if (mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_CONFIRMACIONPEDIDO)){
                Date[] fechas = new Date[2];

                Consultas.ConsultasDia.obtenerRangoAgenda(fechas);
                if (fechas[0] != null && fechas[1] != null) {
                    nombreArchivo = ServicesCentral.WSObtenerActualizacionPorSPSQLite(ServicesCentral.TiposActualizacion.ConfirmacionPedidosCos,fechas[0], fechas[1],"" );
                }
            }else if(mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_DOCUMENTO)){
					nombreArchivo = ServicesCentral.WSObtenerDocumentoSQLite(sFolioDoctos);
			}else if(mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_TIMBRADO_CDFIs )){
					nombreArchivo = ServicesCentral.WSVendedorObtenerTimbradoCFDIs(sFolioDoctos);
			}else if (mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_CLIENTES_NUEVOS)){
				nombreArchivo = ServicesCentral.WSVendedorObtenerClientesNuevos(((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura, ((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura);
//			}else if (mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_ACT_CLIENTES_AGENDA)){
//				Date[] fechas = new Date[2];
//				Consultas.ConsultasDia.obtenerRangoAgenda(fechas);
//				if (fechas[0] != null && fechas[1] != null) {
//					nombreArchivo = ServicesCentral.WSActualizarClientesAgenda(((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura, ((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura);
//				}
			}else
			{
                if (bPrecios){
                    //String dsXML = DocumentoXML.CrearDataSetActualiza("parsXMLUltActualizacion", xmlActualiza, mTablas);
                    Date[] fechas = new Date[2];

                    Consultas.ConsultasDia.obtenerRangoAgenda(fechas);
                    if (fechas[0] != null && fechas[1] != null){
                        nombreArchivo = ServicesCentral.WSObtenerActualizacionPreciosSQLite(fechas[0], fechas[1]);
                    }
                }else if (bCobranza) {
                    String dsXML = DocumentoXML.CrearDataSetActualiza("parsXMLUltActualizacion", xmlActualiza, mTablas);
                    Date[] fechas = new Date[2];
                    Consultas.ConsultasDia.obtenerRangoAgenda(fechas);
                    if (fechas[0] != null && fechas[1] != null) {
                        nombreArchivo = ServicesCentral.WSVendedorObtenerCobranzaSQLite(dsXML, mTablas, fechas[0], fechas[1]);
                    }
                }else if (bPromociones){
                    String dsXML = DocumentoXML.CrearDataSetActualiza("parsXMLUltActualizacion", xmlActualiza, mTablas);
                    Date[] fechas = new Date[2];
                    Consultas.ConsultasDia.obtenerRangoAgenda(fechas);
                    if (fechas[0] != null && fechas[1] != null) {
                        nombreArchivo = ServicesCentral.WSVendedorObtenerActualizacionPromociones(dsXML, mTablas, fechas[0], fechas[1]);
                    }
				}else if (bProductos){
					String dsXML = DocumentoXML.CrearDataSetActualiza("parsXMLUltActualizacion", xmlActualiza, mTablas);
					Date[] fechas = new Date[2];
					Consultas.ConsultasDia.obtenerRangoAgenda(fechas);
					if (fechas[0] != null && fechas[1] != null) {
						nombreArchivo = ServicesCentral.WSVendedorObtenerActualizacionProductos(dsXML, mTablas, fechas[0], fechas[1]);
					}
                }else {
                    String dsXML = DocumentoXML.CrearDataSetActualiza("parsXMLUltActualizacion", xmlActualiza, mTablas);
                    Date[] fechas = new Date[2];
                    String sTransProdID = Consultas.ConsultasCargas.obtenerIdsCargas();
                    Consultas.ConsultasDia.obtenerRangoAgenda(fechas);
                    if (fechas[0] != null && fechas[1] != null) {
                        nombreArchivo = ServicesCentral.WSVendedorObtenerActualizacionSQLite(dsXML, mTablas, sTransProdID, fechas[0], fechas[1]);
                    }
                }
			}

			if (nombreArchivo.equals(""))
			{
                if (bPrecios){
                    NodeList tablasXml = xmlActualiza.getFirstChild().getChildNodes();
                    String nombreTabla;
                    for (int i = 0; i <= tablasXml.getLength() - 1; i++)
                    {
                        nombreTabla = tablasXml.item(i).getChildNodes().item(0).getTextContent();
                        if (nombreTabla.equalsIgnoreCase("Precio") || nombreTabla.equalsIgnoreCase("PrecioProductoVig"))
                        {
                            tablasXml.item(i).getChildNodes().item(1).setTextContent(Generales.getFechaHoraActualStr("yyyy-MM-dd'T'HH:mm:ss'Z'"));
                        }
                    }
                    TransformerFactory transformerFactory = TransformerFactory.newInstance();
                    Transformer transformer = transformerFactory.newTransformer();
                    DOMSource source = new DOMSource(xmlActualiza);
                    StreamResult result = new StreamResult(archXML);
                    transformer.transform(source, result);
                }

                if (mContinuar){
					//Folio 04234: Se pidio omitir el mensaje cuando es actualizacion de inventario
					if (!mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_INVENTARIO)) {
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN, "No existen datos para actualizar");
						mVista.finalizar();
					}else{
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
						mVista.finalizar();
					}
                }else {
                    if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
                    {
                        Dispositivo.EncenderApagarWiFi(mVista, false, 4);
                    }
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "No existen datos para actualizar");
                    mVista.finalizar();
                }
				return;
			}

		}
		catch (Exception e)
		{
			e.printStackTrace();
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			mVista.finalizar();
			return;
		}

		mVista.setProgresoPasos(3);
		mVista.setTextoPasos(Mensajes.get("I0031"));

		boolean archivosEliminados = true;
        archivosServerEliminados = false;
		String extensionBorrar="";
		String dirDestino="";
		try
		{

			File destino = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
			destino = new File(destino, "bd");
			destino.mkdirs();
			dirDestino = destino.getAbsolutePath();
			destino = new File(destino, nombreArchivo + ".zip");

			if (destino.exists())
				destino.delete();
			destino.createNewFile();

			int[] tamanioArchivo =
			{ 0 };
			InputStream in = ServicesCentral.DescargarBD(nombreArchivo, tamanioArchivo);
			OutputStream out = new FileOutputStream(destino);

			Integer total = (int) (tamanioArchivo[0] / 1024);
			mVista.setMaxDetallePasos(total);
			long actual = 0;
			byte[] buf = new byte[1024];
			int len;
			while ((len = in.read(buf)) > 0)
			{
				out.write(buf, 0, len);
				actual += len;
				Integer actualKB = (int) (actual / 1024);
				mVista.setProgresoDetallePasos(actualKB);
				mVista.setTextoProgreso("descargando base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
			}
			in.close();
			out.close();

			mVista.setProgresoPasos(4);
			mVista.setTextoPasos("Descomprimiendo Archivo");

			FileInputStream fin = new FileInputStream(destino.getAbsolutePath());
			ZipInputStream zin = new ZipInputStream(fin);
			ZipEntry ze = null;
			while ((ze = zin.getNextEntry()) != null)
			{
				File resFile = new File(dirDestino, ze.getName());
				if (resFile.exists())
					resFile.delete();
                if (mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_CLIENTES_NUEVOS) || mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_ACT_CLIENTES_AGENDA))
                    nombreArchivo = ze.getName().replace(".xml", "").replace(".db", "");
				FileOutputStream fout = new FileOutputStream(resFile.getAbsolutePath());

				byte[] tempBuffer = new byte[8192 * 2];
				total = (int) (ze.getSize() / (8192 * 2));
				total = (total * 2);
				mVista.setMaxDetallePasos(total);
				actual = 0;
				while ((len = zin.read(tempBuffer)) != -1)
				{
					fout.write(tempBuffer, 0, len);
					actual += len;
					Integer actualKB = (int) (actual / 8192 * 2);
					mVista.setProgresoDetallePasos(actualKB);
					mVista.setTextoProgreso("descomprimiendo base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
				}

				zin.closeEntry();
				fout.close();
			}
			zin.close();
			fin.close();
			destino.delete();

			mVista.setProgresoDetallePasos(0);
			mVista.setTextoProgreso("");

			mVista.setProgresoPasos(5);
			mVista.setTextoPasos("Procesando datos");
			archivosEliminados = false;			
			if (mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_TERMINAL))
			{
                extensionBorrar = ".xml";
				Recepcion.procesarDataSet(nombreArchivo + ".xml", Enumeradores.TipoBD.BD_TERMINAL, xmlActualiza,false);
			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_INVENTARIO))
			{
                extensionBorrar = ".xml";
				Recepcion.procesarDataSetInventario(nombreArchivo + ".xml", xmlActualiza);
			}
            else if (mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_CONFIRMACIONPEDIDO) || mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_DOCUMENTO) || mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_TIMBRADO_CDFIs )  || mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_ACT_CLIENTES_AGENDA))
            {
                extensionBorrar = ".db";
                Recepcion.procesarInfoRecibida(nombreArchivo + ".db", Enumeradores.TipoBD.BD_VENDEDOR, xmlActualiza,false);
            }
            else if (mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_CLIENTES_NUEVOS)){
                extensionBorrar = ".db";
				Recepcion.procesarInfoRecibida(nombreArchivo + ".db", Enumeradores.TipoBD.BD_VENDEDOR, xmlActualiza,false);
            }
			else
			{
                //Hasta el momento no hay tablas de vendedor que al actualizar tengan que limpiarse, por lo tanto
                //el parámetro de limpiar se deja como false
                extensionBorrar = ".db";
				Recepcion.procesarInfoRecibida(nombreArchivo + ".db", Enumeradores.TipoBD.BD_VENDEDOR, xmlActualiza,false);
			}

			File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
			dataSet.delete();
			if (extensionBorrar.equalsIgnoreCase(".db")){
				dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
				dataSet.delete();
			}
			archivosEliminados = true;
			
			ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            archivosServerEliminados = true;
            if (bPrecios) {
                String tablasPrecios = TextUtils.join("','",Recepcion.TABLAS_PRECIOS);
                tablasPrecios = "'" + tablasPrecios + "'";
                ServicesCentral.WSActualizarFechaTablas(ServicesCentral.TiposSincronizacion.Vendedor, tablasPrecios);
            }

            if (mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_CONFIRMACIONPEDIDO))
            {
                String sTransProdID = Consultas.ConsultasPedidosConfirmadosSAP.obtenerIdsConfirmadosSAP();
                if (sTransProdID.length() >0){
                    ServicesCentral.WSMarcarRegistrosActualizados(ServicesCentral.TiposActualizacion.ConfirmacionPedidosCos, sTransProdID);
                }
            }

            if (mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_CLIENTES_NUEVOS)){
                ServicesCentral.WSGuardarAgendaClientesNuevos();
            }

//			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ConfirmarPedidoProtheus") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ConfirmarPedidoProtheus").equals("1")) {
//				ServicesCentral.WSRecalcularPedidoConfirmado(mfechaIni, mfechaFin,  vendedor.VendedorId);
//			}

			if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
			{
				Dispositivo.EncenderApagarWiFi(mVista, false, 0);
			}

			mVista.setProgresoPasos(6);
			mVista.setTextoPasos(Mensajes.get("I0021"));

			if (mTablas != null && mTablas.contains("'MENDetalle'"))
			{
				Mensajes.actualizarMensajes();
			}
			if (mTablas != null && mTablas.contains("'ValorReferencia'"))
			{
				ValoresReferencia.actualizarValoresReferencia();
			}

			if(bRecargas){
				BDVend.cerrar();
				BDVend.Iniciar();
				if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").equals("1")){
					InventarioDobleUnidad.CargasFaseTransferir();
				}else {
					if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("InventarioPorLotes") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("InventarioPorLotes").equals("1"))
						InventarioLotes.CargasFaseTransferir();
					else
						Inventario.CargasFaseTransferir();
				}
			}
			mVista.setProgresoPasos(7);
			mVista.setTextoPasos("Proceso Finalizado.....");

		}
		catch (FileNotFoundException e)
		{
			if (!archivosEliminados){
				File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
				dataSet.delete();
				if (extensionBorrar.equalsIgnoreCase(".db")){
					dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
					dataSet.delete();
				}
			}
            if(!archivosServerEliminados){
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			mVista.finalizar();
			return;
		}
		catch (IOException e)
		{
			if (!archivosEliminados){
				File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
				dataSet.delete();
				if (extensionBorrar.equalsIgnoreCase(".db")){
					dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
					dataSet.delete();
				}
			}
            if(!archivosServerEliminados){
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			mVista.finalizar();
			return;
		}
        catch (NullPointerException e)
        {
            if (!archivosEliminados){
                File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
                dataSet.delete();
                if (extensionBorrar.equalsIgnoreCase(".db")){
                    dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
                    dataSet.delete();
                }
            }
            if(!archivosServerEliminados){
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "Error de nulos");
            mVista.finalizar();
            return;
        }
		catch (Exception e)
		{
			if (!archivosEliminados){
				File dataSet = new File(dirDestino, nombreArchivo + extensionBorrar);
				dataSet.delete();
				if (extensionBorrar.equalsIgnoreCase(".db")){
					dataSet = new File(dirDestino, nombreArchivo + ".db-journal");
					dataSet.delete();
				}
			}
            if(!archivosServerEliminados){
                ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");
            }
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			mVista.finalizar();
			return;
		}
		/*Disponibilidad BackOrder 5730*/
		String ClientesBackOrder="";
		try{
			ClientesBackOrder = Consultas.ConsultasPedidosConfirmadosPRS.obtenerBackOrderDisConfirmacion();
		}
		catch(Exception ex){
		}
		if(ClientesBackOrder != ""){
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("I0352").replace("$0$", ClientesBackOrder));
		}
		else {
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
		}
		mVista.finalizar();
	}

    private String imagenesEncuestas()
    {
        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

        File destino = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
        String directorio = destino.getAbsolutePath();
        File dire = new File(destino, "ImagenEncuesta");


        if(dire.isDirectory() && dire.exists())
        {
            try
            {

                ZipOutputStream out = new ZipOutputStream(new FileOutputStream(directorio+"/ImagenEncuesta.zip"));

                agregarDir(dire, out, "ImagenEncuesta"); // manda a llamar el metodo agregar Dir y mandamos el path donde estan las imagenes y donde se guardara el zip
                out.close();
                dire.delete();

                return directorio+"/ImagenEncuesta.zip";
            }
            catch (FileNotFoundException e)
            {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
            catch (IOException e)
            {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }

        }

        return "";
    }

    private String obtenerDirectorioArchivos(String sDirArchivos)
    {
        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

        File destino = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
        String directorio = destino.getAbsolutePath();
        File dire = new File(destino, sDirArchivos);


        if(dire.isDirectory() && dire.exists() && dire.listFiles().length > 0)
        {
            try
            {
                BorrarImagenesTemporales(directorio + "/" + sDirArchivos);
                ZipOutputStream out = new ZipOutputStream(new FileOutputStream(directorio + "/" + sDirArchivos + ".zip"));

                agregarDir(dire, out, sDirArchivos); // manda a llamar el metodo agregar Dir y mandamos el path donde estan las imagenes y donde se guardara el zip
                out.close();
                dire.delete();

                return directorio + "/" + sDirArchivos + ".zip";
            }
            catch (FileNotFoundException e)
            {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
            catch (IOException e)
            {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }

        }

        return "";
    }

    public void agregarDir(File dirObj, ZipOutputStream out, String dirImagenes) throws IOException
    {
        File[] files = dirObj.listFiles();
        byte[] tmpBuf = new byte[1024];

        for (int i = 0; i < files.length; i++) {
            //Log.v("Directorio", files[i].getName());
            if (files[i].isDirectory()) {
                agregarDir(files[i], out, dirImagenes);
                continue;
            }
            FileInputStream in = new FileInputStream(files[i].getAbsolutePath());
            //Log.v(" Adding: ", "ImagenEncuesta/"+files[i].getName());
            out.putNextEntry(new ZipEntry(dirImagenes + "/" + files[i].getName()));
            int len;
            while ((len = in.read(tmpBuf)) > 0) {
                out.write(tmpBuf, 0, len);
            }
            out.closeEntry();
            in.close();
        }
    }

    public void ObtenerNoFechaFinAgenda(){
        try {
            ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

            mVista.setMaxPasos(2);
            mVista.setTextoPasos(Mensajes.get("MDBPreparando"));
            String nombreArchivo = "";

            mVista.setProgresoPasos(1);
            mVista.setTextoPasos("Probando Acceso al servicio");

            if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString())) {
                Dispositivo.EncenderApagarWiFi(mVista, true, 4);
            }

            //Validar Conexion con el servicio
            if (!ServicesCentral.ProbarAccesoServicio()) {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("F0008"));
                mVista.finalizar();
            }


            mVista.setProgresoPasos(2);
            mVista.setTextoPasos("Obteniendo parámetro");
            Boolean respuesta = ServicesCentral.WSUsuarioRecibirConfigFechasAgendas();

            mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN, respuesta.toString());
            mVista.finalizar();

            //No se apaga el wifi, porque inmediatamente después se pedira agenda, y se requiere el wifi

        } catch (Exception e){
            if (e == null || e.getMessage() == null) {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "Error al obtener el parámetro");
            }else{
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            }
            mVista.finalizar();
        }
    }

    public void ObtenerFechaInicialAgendaNoMenor(){
        try {
            ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

            mVista.setMaxPasos(2);
            mVista.setTextoPasos(Mensajes.get("MDBPreparando"));
            String nombreArchivo = "";

            mVista.setProgresoPasos(1);
            mVista.setTextoPasos("Probando Acceso al servicio");

            if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString())) {
                Dispositivo.EncenderApagarWiFi(mVista, true, 4);
            }

            //Validar Conexion con el servicio
            if (!ServicesCentral.ProbarAccesoServicio()) {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("F0008"));
                mVista.finalizar();
            }


            mVista.setProgresoPasos(2);
            mVista.setTextoPasos("Obteniendo parámetro");
            Boolean respuesta = ServicesCentral.WSUsuarioRecibirConfigFechaInicialAgendaNoMenor();

            mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN, respuesta.toString());
            mVista.finalizar();

            //No se apaga el wifi, porque inmediatamente después se pedira agenda, y se requiere el wifi

        } catch (Exception e){
            if (e == null || e.getMessage() == null) {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "Error al obtener el parámetro");
            }else{
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            }
            mVista.finalizar();
        }
    }

	public void ObtenerLimpiarClaveAcceso(){
		try {
			ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

			mVista.setMaxPasos(2);
			mVista.setTextoPasos(Mensajes.get("MDBPreparando"));
			String nombreArchivo = "";

			mVista.setProgresoPasos(1);
			mVista.setTextoPasos("Probando Acceso al servicio");

			if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString())) {
				Dispositivo.EncenderApagarWiFi(mVista, true, 4);
			}

			//Validar Conexion con el servicio
			if (!ServicesCentral.ProbarAccesoServicio()) {
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("F0008"));
				mVista.finalizar();
			}


			mVista.setProgresoPasos(2);
			mVista.setTextoPasos("Obteniendo parámetro");
			Boolean respuesta = ServicesCentral.WSLimpiarClaveAcceso();

			mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN, respuesta.toString());
			if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString())) {
				Dispositivo.EncenderApagarWiFi(mVista, false, 4);
			}

			mVista.finalizar();

		} catch (Exception e){
			if (e == null || e.getMessage() == null) {
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "Error al obtener el parámetro");
			}else{
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			}
			mVista.finalizar();
		}
	}

    public String ModificarContrasena(){
        try {
            ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

            mVista.setMaxPasos(4);
            mVista.setTextoPasos(Mensajes.get("MDBPreparando"));
            String nombreArchivo = "";

            mVista.setProgresoPasos(1);
            mVista.setTextoPasos("Probando Acceso al servicio");

            if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString())) {
                Dispositivo.EncenderApagarWiFi(mVista, true, 4);
            }

            //Validar Conexion con el servicio
            if (!ServicesCentral.ProbarAccesoServicio()) {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("F0008"));
                mVista.finalizar();
                return "";
            }

            mVista.setProgresoPasos(2);
            mVista.setTextoPasos("Validando Licenciamiento");
            if (!ServicesCentral.WSLicenciamientoVigente()) {
                String fechaVencimiento = ServicesCentral.WSFechaVencimientoUltimaFactura();
                if (fechaVencimiento.equalsIgnoreCase("Inactivo")) {
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0891] El contrato que ampara el licenciamiento de Route se encuentra dado de baja. Será deshabilitado el servicio de comunicaciones ");
                    mVista.finalizar();
                    return "";
                } else if (fechaVencimiento.equalsIgnoreCase("NoDisponible")) {
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0895] El servicio para validación del periodo de licenciamiento no se encuentra disponible. Comuníquese con el Proveedor ");
                    mVista.finalizar();
                    return "";
				}else if (fechaVencimiento.equalsIgnoreCase("RFCIncorrecto")) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al cliente que solicita licencia. Comuníquese con el Proveedor ");
					mVista.finalizar();
					return "";
				}else if (fechaVencimiento.equalsIgnoreCase("TipoProductoIncorrecto")) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al producto que solicita licencia. Comuníquese con el Proveedor ");
					mVista.finalizar();
					return "";
                } else if (fechaVencimiento.equals("")) {
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0895] El servicio para validación del periodo de licenciamiento no se encuentra disponible. Comuníquese con el Proveedor ");
                    mVista.finalizar();
                    return "";
                } else {
                    try {
                        Calendar cal = Calendar.getInstance();
                        cal.set(Integer.parseInt(fechaVencimiento.substring(6, 10)), (Integer.parseInt(fechaVencimiento.substring(3, 5))) - 1, Integer.parseInt(fechaVencimiento.substring(0, 2)));
                        Date dateRepresentation = cal.getTime();
                        if (dateRepresentation.before(Generales.getFechaActual())) {
                            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0894] El periodo de licenciamiento pagado ha caducado. Será deshabilitado el servicio de comunicaciones");
                            mVista.finalizar();
                            return "";
                        } else if (dateRepresentation.after(Generales.getFechaActual())) {
                            ServicesCentral.WSActualizarFechaVencimiento();
                        }
                    } catch (Exception ex) {
                        mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "Fecha de contrato inválida");
                        mVista.finalizar();
                        return "";
                    }
                }
            }

            mVista.setProgresoPasos(3);
            mVista.setTextoPasos("Verificando Licencia");

			ServicesCentral.TipoLicencia tipoLicencia = ServicesCentral.WSTipo_Licencia();
            //Validar Licencia
			if (tipoLicencia != ServicesCentral.TipoLicencia.Definitivo)
			{
				if (tipoLicencia == ServicesCentral.TipoLicencia.RFCIncorrecto) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al cliente que solicita licencia. Comuníquese con el Proveedor ");
				}else if (tipoLicencia == ServicesCentral.TipoLicencia.TipoProductoIncorrecto ){
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al producto que solicita licencia. Comuníquese con el Proveedor ");
				}else {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El dispositivo no tiene una licencia válida");
				}
                mVista.finalizar();
                return "";
            }

            mVista.setProgresoPasos(4);
            mVista.setTextoPasos("Actualizando Información");
            String Respuesta = ServicesCentral.WSVendedorNotificarModContrasena(UsuarioMod,ContrasenaMod);

            String[] SplitRespuesta = Respuesta.split(",/");

            if (SplitRespuesta[0].equals("True")){
                StringBuilder MsjRecibirUsuarios= new StringBuilder();
                boolean RecibirUsuariosCorrecto=false;
                RecibirUsuariosCorrecto=actualizarUsuariosPoliticas(MsjRecibirUsuarios);
                if (RecibirUsuariosCorrecto){
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN, SplitRespuesta[1]);
                }else{
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, MsjRecibirUsuarios.toString());
                }

                mVista.finalizar();
                return "";
            }else{
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, SplitRespuesta[1]);
                mVista.finalizar();
                return "";
            }
        } catch (Exception e){
            e.printStackTrace();
            return"";
        }
    }

    private void enviarDatosMovSinInvSinVisita()
    {
        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

        mVista.setMaxPasos(8);
        mVista.setTextoPasos(Mensajes.get("MDBPreparando"));
        String nombreArchivo = "";
        try
        {
            mVista.setProgresoPasos(1);
            mVista.setTextoPasos("Probando Acceso al servicio");

            if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
            {
                Dispositivo.EncenderApagarWiFi(mVista, true, 4);
            }

            //Validar Conexion con el servicio
            if (!ServicesCentral.ProbarAccesoServicio())
            {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("F0008"));
                Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
                mVista.finalizar();
                return;
            }

            mVista.setProgresoPasos(2);
            mVista.setTextoPasos("Validando Licenciamiento");
            if (! ServicesCentral.WSLicenciamientoVigente()){
                String fechaVencimiento = ServicesCentral.WSFechaVencimientoUltimaFactura();
                if (fechaVencimiento.equalsIgnoreCase("Inactivo")){
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0891] El contrato que ampara el licenciamiento de Route se encuentra dado de baja. Será deshabilitado el servicio de comunicaciones ");
                    Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
                    mVista.finalizar();
                    return;
                }else if (fechaVencimiento.equalsIgnoreCase("NoDisponible")) {
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0895] El servicio para validación del periodo de licenciamiento no se encuentra disponible. Comuníquese con el Proveedor ");
                    Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
                    mVista.finalizar();
                    return;
				}else if (fechaVencimiento.equalsIgnoreCase("RFCIncorrecto")) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al cliente que solicita licencia. Comuníquese con el Proveedor ");
					Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
					mVista.finalizar();
					return;
				}else if (fechaVencimiento.equalsIgnoreCase("TipoProductoIncorrecto")) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al producto que solicita licencia. Comuníquese con el Proveedor ");
					Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
					mVista.finalizar();
					return;
                }else if(fechaVencimiento.equals("") ){
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0895] El servicio para validación del periodo de licenciamiento no se encuentra disponible. Comuníquese con el Proveedor ");
                    Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
                    mVista.finalizar();
                    return;
                }else{
                    try{
                        Calendar cal = Calendar.getInstance();
                        cal.set(Integer.parseInt(fechaVencimiento.substring(6,10)),(Integer.parseInt(fechaVencimiento.substring(3,5)))-1,Integer.parseInt(fechaVencimiento.substring(0,2)));
                        Date dateRepresentation = cal.getTime();
                        if (dateRepresentation.before(Generales.getFechaActual())){
                            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0894] El periodo de licenciamiento pagado ha caducado. Será deshabilitado el servicio de comunicaciones");
                            Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
                            mVista.finalizar();
                            return;
                        }else if (dateRepresentation.after(Generales.getFechaActual())){
                            ServicesCentral.WSActualizarFechaVencimiento();
                        }
                    }catch (Exception ex){
                        mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "Fecha de contrato inválida");
                        Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
                        mVista.finalizar();
                        return;
                    }
                }
            }

            mVista.setProgresoPasos(3);
            mVista.setTextoPasos("Verificando Licencia");

			ServicesCentral.TipoLicencia tipoLicencia = ServicesCentral.WSTipo_Licencia();

			//Validar Licencia
			if (tipoLicencia != ServicesCentral.TipoLicencia.Definitivo)
			{
				if (tipoLicencia == ServicesCentral.TipoLicencia.RFCIncorrecto) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al cliente que solicita licencia. Comuníquese con el Proveedor ");
				}else if (tipoLicencia == ServicesCentral.TipoLicencia.TipoProductoIncorrecto ){
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al producto que solicita licencia. Comuníquese con el Proveedor ");
				}else {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El dispositivo no tiene una licencia válida");
				}
                Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
                mVista.finalizar();
                return;
            }

            mVista.setProgresoPasos(4);
            mVista.setTextoPasos("Preparando paquete de envio");

            StringBuilder sbMsgError = new StringBuilder();
            nombreArchivo = Envio.fileDatosEnviarMSISV(Envio.TABLAS_ENVIO_MOV_SIN_INV_SIN_VISITA);
        }
        catch (Exception e)
        {
            e.printStackTrace();
            if (e.getMessage().indexOf("I0162") != -1 && mContinuar)
            {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN, e.getMessage());
            }
            else
            {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            }
            Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
            mVista.finalizar();
            return;
        }
        mVista.setProgresoPasos(5);
        mVista.setTextoPasos("Creando ZIP");

        File zipSal = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString(), "bd");
        try
        {
            File bdComprimir = new File(zipSal.getAbsolutePath(), nombreArchivo);
            zipSal = new File(zipSal.getAbsolutePath(), nombreArchivo.replace(".db", ".zip"));

            byte[] buffer = new byte[1024];
            FileOutputStream fout = new FileOutputStream(zipSal.getAbsolutePath());
            ZipOutputStream zout = new ZipOutputStream(fout);
            FileInputStream fin = new FileInputStream(bdComprimir.getAbsolutePath());
            zout.putNextEntry(new ZipEntry(bdComprimir.getName()));
            int length;
            Integer total = (int) (bdComprimir.length() / 1024);
            mVista.setMaxDetallePasos(total);
            long actual = 0;
            while ((length = fin.read(buffer)) > 0)
            {
                zout.write(buffer, 0, length);
                actual += length;
                Integer actualKB = (int) (actual / 1024);
                mVista.setProgresoDetallePasos(actualKB);
                mVista.setTextoProgreso("Comprimiendo base de datos (" + actualKB.toString() + " de " + total.toString() + ")");
            }
            zout.closeEntry();
            fin.close();
            zout.close();
            bdComprimir.delete();
        }
        catch (IOException e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
            mVista.finalizar();
            return;
        }
        catch (Exception e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
            mVista.finalizar();
            return;
        }

        mVista.setProgresoPasos(6);
        mVista.setTextoPasos(Mensajes.get("I0160"));

        Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
        try
        {
            ServicesCentral.WSActualizarCapturaSQLite(vendedor.VendedorId, vendedor.Fecha, Consultas.ConsultasServidorComunicaciones.obtenerFechaPrimerDia(), false, zipSal.getAbsolutePath());
            //mVista.mostrarError(Mensajes.get("MDBTodos"));
            zipSal.delete();
            zipSal = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString(), "bd");
            zipSal = new File(zipSal.getAbsolutePath(), nombreArchivo.replace(".db", ".db-journal"));

            zipSal.delete();
        }
        catch (Exception e)
        {
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            zipSal.delete();
            zipSal = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString(), "bd");
            zipSal = new File(zipSal.getAbsolutePath(), nombreArchivo.replace(".db", ".db-journal"));
            zipSal.delete();
            Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
            mVista.finalizar();
            return;
        }
        mVista.setProgresoPasos(7);
        mVista.setTextoPasos(Mensajes.get("I0160"));
        try
        {
            Envio.marcarEnviados(tipoEnvioInformacion,Envio.TABLAS_ENVIO_MOV_SIN_INV_SIN_VISITA);

        }
        catch (Exception e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
            mVista.finalizar();
            return;
        }

        mVista.setProgresoPasos(8);
        mVista.setTextoPasos(Mensajes.get("MDBEnvInt"));

        try
        {
            ServicesCentral.WSEjecutarInterfaces(vendedor.VendedorId, vendedor.Fecha, Consultas.ConsultasServidorComunicaciones.obtenerFechaPrimerDia(), false);

        }
        catch (Exception e)
        {
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
            mVista.finalizar();
            return;
        }

		//CAI 5480
		try
		{
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ConfirmarPedidoProtheus") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ConfirmarPedidoProtheus").equals("1")) {
				ServicesCentral.WSObtenerConfirmacionPedidoProtheus(vendedor.Fecha, vendedor.Fecha,  vendedor.VendedorId);
			}
		}
		catch (Exception e)
		{
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
			Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
			mVista.finalizar();
			return;
		}

        //CAI 3297, Actualizar la tabla de sincronizacion con la fecha y hora del dispositivo
        try
        {
            ServicesCentral.WSActualizarSincronizacion(vendedor.VendedorId, Generales.getFechaHoraActual());
        }
        catch (Exception e)
        {
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
            mVista.finalizar();
            return;
        }

        Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,false);
//		boolean BackOrder = false;
//		if(BackOrder){
//			mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN, );
//		}
//		else {
			mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
//		}
        mVista.finalizar();
    }

    private void enviarTicketPDF()
    {
        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
        //String sNombrePDF = Sesion.get(Campo.ArchivoPDF).toString();
        Hashtable<String, ContentValues> htArchivosPDF = (Hashtable<String, ContentValues>)Sesion.get(Campo.ArchivosPDFxEnviar);

        mVista.setMaxPasos(5);
        mVista.setTextoPasos(Mensajes.get("MDBPreparando"));

        try
        {
            mVista.setProgresoPasos(1);
            mVista.setTextoPasos("Probando Acceso al servicio");

            if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
                Dispositivo.EncenderApagarWiFi(mVista, true, 4);

            //Validar Conexion con el servicio
            if (!ServicesCentral.ProbarAccesoServicio())
            {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("F0008"));
                mVista.finalizar();
                return;
            }

            mVista.setProgresoPasos(2);
            mVista.setTextoPasos("Validando Licenciamiento");
            if (! ServicesCentral.WSLicenciamientoVigente()){
                String fechaVencimiento = ServicesCentral.WSFechaVencimientoUltimaFactura();
                if (fechaVencimiento.equalsIgnoreCase("Inactivo")){
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0891] El contrato que ampara el licenciamiento de Route se encuentra dado de baja. Será deshabilitado el servicio de comunicaciones ");
                    mVista.finalizar();
                    return;
                }else if (fechaVencimiento.equalsIgnoreCase("NoDisponible")) {
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0895] El servicio para validación del periodo de licenciamiento no se encuentra disponible. Comuníquese con el Proveedor ");
                    mVista.finalizar();
                    return;
				}else if (fechaVencimiento.equalsIgnoreCase("RFCIncorrecto")) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al cliente que solicita licencia. Comuníquese con el Proveedor ");
					mVista.finalizar();
					return;
				}else if (fechaVencimiento.equalsIgnoreCase("TipoProductoIncorrecto")) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al producto que solicita licencia. Comuníquese con el Proveedor ");
					mVista.finalizar();
					return;
				}else if(fechaVencimiento.equals("") ){
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0895] El servicio para validación del periodo de licenciamiento no se encuentra disponible. Comuníquese con el Proveedor ");
                    mVista.finalizar();
                    return;
                }else{
                    try{
                        Calendar cal = Calendar.getInstance();
                        cal.set(Integer.parseInt(fechaVencimiento.substring(6,10)),(Integer.parseInt(fechaVencimiento.substring(3,5)))-1,Integer.parseInt(fechaVencimiento.substring(0,2)));
                        Date dateRepresentation = cal.getTime();
                        if (dateRepresentation.before(Generales.getFechaActual())){
                            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0894] El periodo de licenciamiento pagado ha caducado. Será deshabilitado el servicio de comunicaciones");
                            mVista.finalizar();
                            return;
                        }else if (dateRepresentation.after(Generales.getFechaActual())){
                            ServicesCentral.WSActualizarFechaVencimiento();
                        }
                    }catch (Exception ex){
                        mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "Fecha de contrato inválida");
                        mVista.finalizar();
                        return;
                    }
                }
            }

            mVista.setProgresoPasos(3);
            mVista.setTextoPasos("Verificando Licencia");

			ServicesCentral.TipoLicencia tipoLicencia = ServicesCentral.WSTipo_Licencia();

			//Validar Licencia
			if (tipoLicencia != ServicesCentral.TipoLicencia.Definitivo)
			{
				if (tipoLicencia == ServicesCentral.TipoLicencia.RFCIncorrecto) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al cliente que solicita licencia. Comuníquese con el Proveedor ");
				}else if (tipoLicencia == ServicesCentral.TipoLicencia.TipoProductoIncorrecto ){
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al producto que solicita licencia. Comuníquese con el Proveedor ");
				}else {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El dispositivo no tiene una licencia válida");
				}
                mVista.finalizar();
                return;
            }

        }
        catch (Exception e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }
        mVista.setProgresoPasos(4);
        mVista.setTextoPasos("Creando ZIP");

        String sClienteClave = ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave;
        String sCorreoCliente = ((Cliente)Sesion.get(Campo.ClienteActual)).CorreoElectronico;
        String sIDs = "";
        String sTipos = "";
        String sFolios = "";
        String sArchivosPDF = "";

        File zipSal = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString(), "TicketsPDF");
        try
        {

            zipSal = new File(zipSal.getAbsolutePath(), sClienteClave + ".zip");
            if (zipSal.exists())
                zipSal.delete();

            byte[] buffer = new byte[1024];
            FileOutputStream fout = new FileOutputStream(zipSal.getAbsolutePath());
            ZipOutputStream zout = new ZipOutputStream(fout);
            int length;
            Integer total;

            Iterator<Map.Entry<String, ContentValues>> it =  htArchivosPDF.entrySet().iterator();
            String sArchivoPDF = "";
            while (it.hasNext()) {
                Map.Entry<String, ContentValues> entry = it.next();
                sArchivoPDF = entry.getKey();

                sArchivosPDF += sArchivoPDF + ".pdf,";
                sIDs += entry.getValue().get("Id").toString() + ",";
                sTipos += entry.getValue().get("Tipo").toString() + ",";
                sFolios += entry.getValue().get("Folio").toString() + ",";

                File pdfComprimir = new File(zipSal.getParent(), sArchivoPDF + ".pdf");
                FileInputStream fin = new FileInputStream(pdfComprimir.getAbsolutePath());
                zout.putNextEntry(new ZipEntry(pdfComprimir.getName()));
                total = (int) (pdfComprimir.length() / 1024);
                mVista.setMaxDetallePasos(total);
                long actual = 0;
                while ((length = fin.read(buffer)) > 0)
                {
                    zout.write(buffer, 0, length);
                    actual += length;
                    Integer actualKB = (int) (actual / 1024);
                    mVista.setProgresoDetallePasos(actualKB);
                    mVista.setTextoProgreso("Comprimiendo PDF (" + actualKB.toString() + " de " + total.toString() + ")");
                }
                fin.close();
            }
            zout.closeEntry();
            zout.close();
            //pdfComprimir.delete();
        }
        catch (IOException e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }
        catch (Exception e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }

        mVista.setProgresoPasos(5);
        mVista.setTextoPasos(Mensajes.get("I0160"));

        String sURLServer = "";
        try
        {
            sURLServer = ServicesCentral.WSAlmacenarTicketPDF(sClienteClave, zipSal.getAbsolutePath());
            zipSal.delete();

            if (Short.valueOf(((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MensajeImpresion").toString()) == 2) {
                if (sFolios.length() > 0)
                    sFolios = sFolios.substring(0, sFolios.length() - 1);
                if (sIDs.length() > 0)
                    sIDs = sIDs.substring(0, sIDs.length() - 1);
                if (sTipos.length() > 0)
                    sTipos = sTipos.substring(0, sTipos.length() - 1);
                if (sArchivosPDF.length() > 0)
                    sArchivosPDF = sArchivosPDF.substring(0, sArchivosPDF.length() - 1);

                Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
                ServicesCentral.WSEnviarCorreoArchivosPDF(vendedor.VendedorId, sClienteClave, sCorreoCliente, sIDs, sTipos, sFolios, sArchivosPDF);
            }
        }
        catch (Exception e)
        {
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            zipSal.delete();
            mVista.finalizar();
            return;
        }

        try{
            if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
            {
                Dispositivo.EncenderApagarWiFi(mVista, false, 0);
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

        Sesion.set(Campo.URLServerPDF, sURLServer);
        mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
        mVista.finalizar();
    }

    private void obtenerEstadoCuentaCliente()
    {
        String nombreArchivo = "";
        String clienteClave = ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave;
        Date fechaIni = (Date)Sesion.get(Campo.FiltroReporteFechaIni);
        Date fechaFin = (Date)Sesion.get(Campo.FiltroReporteFechaFin);

        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
        try
        {
            mVista.setMaxPasos(7);
            mVista.setTextoPasos("Probando Acceso a Servicio");

            if (Boolean.parseBoolean(conf.get(CampoConfiguracion.WIFI).toString()))
            {
                Dispositivo.EncenderApagarWiFi(mVista, true, 4);
            }
            //Validar Conexion con el servicio
            if (!ServicesCentral.ProbarAccesoServicio())
            {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[F0008] No se puede establecer conexión de Area Local. Avisar a Soporte Técnico.");
                mVista.finalizar();
                return;
            }

            //Se comenta este if porque las verificaciones no se hacian cuando ya existia la BD y se volvia a pedir agenda
            //if (!(mAccion.equals(Enumeradores.Acciones.ACCION_OBTENER_BD_VENDEDOR) && BDVend.estaAbierta()))
            //{
            mVista.setProgresoPasos(1);
            mVista.setTextoPasos("Validando Licenciamiento");
            if (! ServicesCentral.WSLicenciamientoVigente()){
                String fechaVencimiento = ServicesCentral.WSFechaVencimientoUltimaFactura();
                if (fechaVencimiento.equalsIgnoreCase("Inactivo")){
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0891] El contrato que ampara el licenciamiento de Route se encuentra dado de baja. Será deshabilitado el servicio de comunicaciones ");
                    mVista.finalizar();
                    return;
                }else if (fechaVencimiento.equalsIgnoreCase("NoDisponible")) {
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0895] El servicio para validación del periodo de licenciamiento no se encuentra disponible. Comuníquese con el Proveedor ");
                    mVista.finalizar();
                    return;
				}else if (fechaVencimiento.equalsIgnoreCase("RFCIncorrecto")) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al cliente que solicita licencia. Comuníquese con el Proveedor ");
					mVista.finalizar();
					return;
				}else if (fechaVencimiento.equalsIgnoreCase("TipoProductoIncorrecto")) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al producto que solicita licencia. Comuníquese con el Proveedor ");
					mVista.finalizar();
					return;
                }else if(fechaVencimiento.equals("") ){
                    mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0895] El servicio para validación del periodo de licenciamiento no se encuentra disponible. Comuníquese con el Proveedor ");
                    mVista.finalizar();
                    return;
                }else{
                    try{
                        Calendar cal = Calendar.getInstance();
                        cal.set(Integer.parseInt(fechaVencimiento.substring(6,10)),(Integer.parseInt(fechaVencimiento.substring(3,5)))-1,Integer.parseInt(fechaVencimiento.substring(0,2)));
                        Date dateRepresentation = cal.getTime();
                        if (dateRepresentation.before(Generales.getFechaActual())){
                            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "[E0894] El periodo de licenciamiento pagado ha caducado. Será deshabilitado el servicio de comunicaciones");
                            mVista.finalizar();
                            return;
                        }else if (dateRepresentation.after(Generales.getFechaActual())){
                            ServicesCentral.WSActualizarFechaVencimiento();
                        }
                    }catch (Exception ex){
                        mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "Fecha de contrato inválida");
                        mVista.finalizar();
                        return;
                    }
                }
            }

            mVista.setProgresoPasos(2);
            mVista.setTextoPasos("Verificando Licencia");

			ServicesCentral.TipoLicencia tipoLicencia = ServicesCentral.WSTipo_Licencia();

			//Validar Licencia
			if (tipoLicencia != ServicesCentral.TipoLicencia.Definitivo)
			{
				if (tipoLicencia == ServicesCentral.TipoLicencia.RFCIncorrecto) {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al cliente que solicita licencia. Comuníquese con el Proveedor ");
				}else if (tipoLicencia == ServicesCentral.TipoLicencia.TipoProductoIncorrecto ){
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El contrato no corresponde al producto que solicita licencia. Comuníquese con el Proveedor ");
				}else {
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, "El dispositivo no tiene una licencia válida");
				}
                mVista.finalizar();
                return;
            }

            mVista.setProgresoPasos(3);
            mVista.setTextoPasos("Generando archivo XML");
            nombreArchivo = ServicesCentral.WSObtenerEstadoCuentaCliente(clienteClave, fechaIni, fechaFin);
        }
        catch (Exception e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }

        mVista.setProgresoPasos(4);
        mVista.setTextoPasos("Descargando Archivo");

        try
        {
            File destino = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
            destino = new File(destino, "bd");
            destino.mkdirs();
            String dirDestino = destino.getAbsolutePath();
            destino = new File(destino, nombreArchivo + ".zip");

            if (destino.exists())
                destino.delete();
            destino.createNewFile();

            int[] tamanioArchivo =
                    { 0 };

            InputStream in = ServicesCentral.DescargarBD(nombreArchivo, tamanioArchivo);
            OutputStream out = new FileOutputStream(destino);
            Integer total = (int) (tamanioArchivo[0] / 1024);
            mVista.setMaxDetallePasos(total);
            long actual = 0;
            byte[] buf = new byte[1024];
            int len;
            while ((len = in.read(buf)) > 0)
            {
                out.write(buf, 0, len);
                actual += len;
                Integer actualKB = (int) (actual / 1024);
                mVista.setProgresoDetallePasos(actualKB);
                mVista.setTextoProgreso("Descargando Archivo (" + actualKB.toString() + " de " + total.toString() + ")");
            }
            in.close();
            out.close();

            mVista.setMaxDetallePasos(0);
            mVista.setTextoProgreso("");

            mVista.setProgresoPasos(5);
            mVista.setTextoPasos("Descomprimiendo Archivo");

            FileInputStream fin = new FileInputStream(destino.getAbsolutePath());
            ZipInputStream zin = new ZipInputStream(fin);
            ZipEntry ze = null;
            while ((ze = zin.getNextEntry()) != null)
            {
                File resFile = new File(dirDestino, ze.getName());
                if (resFile.exists())
                    resFile.delete();
                FileOutputStream fout = new FileOutputStream(resFile.getAbsolutePath());

                byte[] tempBuffer = new byte[8192 * 2];
                total = (int) (ze.getSize() / (8192 * 2));
                total = (total * 2);
                mVista.setMaxDetallePasos(total);
                actual = 0;
                while ((len = zin.read(tempBuffer)) != -1)
                {
                    fout.write(tempBuffer, 0, len);
                    actual += len;
                    Integer actualKB = (int) (actual / 8192 * 2);
                    mVista.setProgresoDetallePasos(actualKB);
                    mVista.setTextoProgreso("Descomprimiendo Archivo (" + actualKB.toString() + " de " + total.toString() + ")");
                }

                zin.closeEntry();
                fout.close();
            }
            zin.close();
            fin.close();
            destino.delete();

            ServicesCentral.WSEliminarArchivoBases(nombreArchivo + ".zip");

            mVista.setProgresoPasos(6);
            mVista.setTextoPasos("Proceso Finalizado.....");

        }
        catch (FileNotFoundException e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }
        catch (IOException e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }
        catch (Exception e)
        {
            e.printStackTrace();
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, e.getMessage());
            mVista.finalizar();
            return;
        }

        Sesion.set(Campo.ResultadoActividad, nombreArchivo);
        mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
        mVista.finalizar();
    }

}
