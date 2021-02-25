package com.amesol.routelite.presentadores.act;

import android.app.Activity;
import android.content.Intent;
import android.location.Location;
import android.text.SpannableStringBuilder;
import android.text.style.RelativeSizeSpan;
import android.view.Gravity;
import android.widget.Toast;

import com.amesol.routelite.actividades.Clientes;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.datos.AseguramientoVisita;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.VistaClientes;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IAtencionClientes;
import com.amesol.routelite.presentadores.interfaces.IAutorizaMovimiento;
import com.amesol.routelite.presentadores.interfaces.IConsultaCliente;
import com.amesol.routelite.presentadores.interfaces.INoVisitaCliente;
import com.amesol.routelite.presentadores.interfaces.INuevoCliente;
import com.amesol.routelite.presentadores.interfaces.IObtencionGPS;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVend;
import com.amesol.routelite.presentadores.interfaces.ISeleccionVisita;
import com.amesol.routelite.presentadores.interfaces.ISolicitudAgendaVendedor;
import com.amesol.routelite.presentadores.parcelables.DatosGPS;
import com.amesol.routelite.utilerias.Generales;

import java.util.ArrayList;
import java.util.HashMap;

public class AtenderClientes extends Presentador
{
	IAtencionClientes mVista;
	String mAccion;
	int mVistaCli;
	String mFiltro;
	HashMap<String, Object> oParametros;

	// Me.CodigoLeido = oFormClientes.bCodigoLeido

	// Me.FueraFrecuencia = oFormClientes.FueraFrecuencia
	// Me.GPSLeido = oFormClientes.bGPSLeido
	// Me.DistanciaGPS = oFormClientes.nDistanciaGPS
	// Me.LatitudGPS = oFormClientes.nLatitudGPS
	// Me.LongitudGPS = oFormClientes.nLongitudGPS
	// Me.TieneCoordenadas = oFormClientes.bTieneCoordenadas
	// Me.LatitudCliente = oFormClientes.nLatitudCliente
	// Me.LongitudCliente = oFormClientes.nLongitudCliente
    boolean Aseguramientogps;
    Vendedor oVendedor;
    String ClienteDomicilioID;
    Boolean bTieneCoordenadas = false;
    AseguramientoVisita aseguramiento;

    public AtenderClientes(IAtencionClientes vista, String accion, int vistaCli, String filtro) {
        this.mVista = vista;
        this.mAccion = accion;
        this.mVistaCli = vistaCli;
        this.mFiltro = filtro;
        oParametros = new HashMap<String, Object>();

	}

	/*
	 * private void asignarClienteActual(String clienteClave) { Cliente
	 * clienteActual = new Cliente(); clienteActual.ClienteClave = clienteClave;
	 * try{ BDVend.recuperar(clienteActual); BDVend.recuperar(clienteActual,
	 * ClienteDomicilio.class); BDVend.recuperar(clienteActual,
	 * ClienteMensaje.class); Sesion.set(Campo.ClienteActual, clienteActual); }
	 * catch(Exception e){ e.printStackTrace(); } }
	 */

    public void SeleccionVisita() {
        mVista.finalizar();
        mVista.iniciarActividad(ISeleccionVisita.class, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null, false, oParametros);
    }

	private void ReiniciarParametrosHash() {

        oParametros.put("CodigoLeido", 0); // false);
        oParametros.put("FueraFrecuencia", false);
        oParametros.put("GPSLeido", false);
        oParametros.put("DistanciaGPS", 0.0f);
        oParametros.put("LatitudGPS", 0d);
        oParametros.put("LongitudGPS", 0d);
        oParametros.put("TieneCoordenadas", false);
        oParametros.put("LatitudCliente", 0f);
        oParametros.put("LongitudCliente", 0f);
        oParametros.put("bVisitado", false);
    }

    public HashMap<String, Object> obtenerParametros() {
        return oParametros;
    }

    @Override
    public void iniciar() {
        try {

            mVista.iniciar();
            if ((mAccion != null) && (mAccion.equals(Intent.ACTION_SEARCH)))
                this.mostrarClientes(mVistaCli, mFiltro);
            else {
                /*
				 * if
				 * (((CONHist)Sesion.get(Campo.CONHist)).get("ClientesVisitados"
				 * ).equals("1"))
				 * this.mostrarClientes(Enumeradores.VistaClientes
				 * .VISTA_CLIENTES_VISITADOS, null); else
				 * this.mostrarClientes(Enumeradores
				 * .VistaClientes.VISTA_CLIENTES_NO_VISITADOS, null);
				 */
                mostrarClientes(obtenerVistaListado(), null);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public int obtenerVistaListado() {
        MOTConfiguracion configuracion = new MOTConfiguracion();
        switch (Integer.parseInt(configuracion.get("VistaListado").toString())) {
            case 1:
                return Enumeradores.VistaClientes.VISTA_CLIENTES_VISITADOS;
            case 2:
                return Enumeradores.VistaClientes.VISTA_CLIENTES_NO_VISITADOS;
            case 3:
                return Enumeradores.VistaClientes.VISTA_CLIENTES_TODOS;
            case 4:
                return Enumeradores.VistaClientes.VISTA_CLIENTES_CON_MENSAJE;
            case 5:
                return Enumeradores.VistaClientes.VISTA_CLIENTES_CON_COBRANZA;
            case 6:
                return Enumeradores.VistaClientes.VISTA_CLIENTES_POR_SURTIR;
            case 7:
                return Enumeradores.VistaClientes.VISTA_CLIENTES_NO_VISITADOS_REC;
            default:
                return 0;
        }
    }

	public void mostrarClientes(int vista, String filtro) {
        Sesion.set(Campo.VistaAtualClientes, vista); //se guarda en sesion la vista actual para buscar los clientes solo en esa vista FIX CAI: 3178
        ISetDatos clientes = null;
        try
		{
            switch (vista) {
                case Enumeradores.VistaClientes.VISTA_CLIENTES_NO_VISITADOS:
                    clientes = Consultas.ConsultasCliente.obtenerNoVisitados((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
                    break;
                case Enumeradores.VistaClientes.VISTA_CLIENTES_VISITADOS:
                    clientes = Consultas.ConsultasCliente.obtenerVisitados((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
                    break;
                case Enumeradores.VistaClientes.VISTA_CLIENTES_FUERA_FRECUENCIA:
                    clientes = Consultas.ConsultasCliente.obtenerFueraFrecuencia((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
                    break;
                case Enumeradores.VistaClientes.VISTA_CLIENTES_TODOS:
                    clientes = Consultas.ConsultasCliente.obtenerTodos((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
                    break;
                case Enumeradores.VistaClientes.VISTA_CLIENTES_CON_MENSAJE:
                    clientes = Consultas.ConsultasCliente.obtenerConMensaje(filtro);
                    break;
                case Enumeradores.VistaClientes.VISTA_CLIENTES_CON_COBRANZA:
                    clientes = Consultas.ConsultasCliente.obtenerConCobranza((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
                    break;
                case Enumeradores.VistaClientes.VISTA_CLIENTES_IMPRODUCTIVOS:
                    clientes = Consultas.ConsultasCliente.obtenerImproductivos((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
                    break;
                case Enumeradores.VistaClientes.VISTA_CLIENTES_NUEVOS:
                    clientes = Consultas.ConsultasCliente.obtenerNuevos(filtro);
                    break;
                case Enumeradores.VistaClientes.VISTA_CLIENTES_POR_SURTIR:
                    clientes = Consultas.ConsultasCliente.obtenerPorSurtir((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
                    break;
                case VistaClientes.VISTA_CLIENTES_NO_VISITADOS_REC:
                    clientes = Consultas.ConsultasCliente.obtenerNoVisitadosRec((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
                    break;
                default:
                    break;
            }
        }
		catch (Exception e)
		{
			e.printStackTrace();
		}
        if (clientes != null) {
            mVista.mostrarClientes(clientes, vista);

		}
	}

	public boolean iniciarGPS() {
        return Aseguramientogps;
    }

    private void seleccionar(int Codigoleido) {
        try {
            ArrayList<TransProd> TRPResultado = Consultas.ConsultasVentasInconsistentes.regresaVentasInconsistentes();
            if (TRPResultado.size() > 0) {
                for (TransProd t : TRPResultado) {
                    String text = "Ocurrió un problema en la aplicación, ten en cuenta las acciones realizadas en el último pedido. ";
                    SpannableStringBuilder biggerText = new SpannableStringBuilder(text);
                    biggerText.setSpan(new RelativeSizeSpan(3f), 0, text.length(), 0);
                    Toast toast = Toast.makeText((Activity) mVista, biggerText, Toast.LENGTH_LONG);
                    toast.setGravity(Gravity.CENTER | Gravity.CENTER_HORIZONTAL, 0, 0);
                    toast.show();
                    Transacciones.Pedidos.cancelarPedidoInconsistente(t);
                    toast.show();
                }
            }
        } catch (Exception ex) {
            Toast.makeText((Activity) mVista, "Error al revisar incosistencias ", Toast.LENGTH_LONG).show();
        }

        ReiniciarParametrosHash();
        oParametros.put("CodigoLeido", Codigoleido);

        try {
            Dia dia = (Dia) Sesion.get(Campo.DiaActual);
            Cliente cliente = new Cliente();
            cliente.ClienteClave = mVista.getCliente();
            BDVend.recuperar(cliente);

            Sesion.set(Campo.ClienteActual, cliente);

            ISetDatos visitas = Consultas.ConsultasVisita.obtenerVisitas(dia, cliente);
            oParametros.put("bVisitado", visitas.getCount() > 0);
            visitas.close();
        } catch (Exception e) {
            e.printStackTrace();
        }

        String respuesta = validarClienteAgendado((Cliente) (Sesion.get(Campo.ClienteActual)));
        boolean[] array =
                {true, false};
        boolean autorizacion = validarMostrarAutorizacion(array);
        boolean iniciarAutorizacion = array[0];
        Aseguramientogps = array[1];
        oVendedor = (Vendedor) Sesion.get(Campo.VendedorActual);

        if (respuesta.equals("") || respuesta.equals("I0159")) {

            mVista.reiniciarPantalla();

            if (!respuesta.equals("") && iniciarAutorizacion)
                mVista.mostrarMensajeEiniciarActividad(Mensajes.get(respuesta), autorizacion ? IAutorizaMovimiento.class : ISeleccionVisita.class);
            else if (iniciarAutorizacion) {
                if (autorizacion) {
                    //mVista.finalizar();
                    mVista.iniciarActividadConResultado(IAutorizaMovimiento.class, Enumeradores.Solicitudes.SOLICITUD_AUTORIZARMOVIMIENTO, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA);
                    return;
                } else {
                    if ((oVendedor.GPS) && !(Boolean) oParametros.get("bVisitado")) {

                        IniciarGPS();
                        //mVista.finalizar();
                        return;
                    }

                    SeleccionVisita();
                    // mVista.iniciarActividad(ISeleccionVisita.class,
                    // Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA,
                    // null, false);

                }

            }
        } else
            mVista.mostrarError(Mensajes.get(respuesta));

	}

	// Private Function ObtenerCoordenadasCliente(ByVal sClienteClave As String)
	// As Boolean
	// 'Falta agregar validacion de Vendedor.GPS
	// If oVendedor.GPS Then
	// Dim sConsulta As String
	// Dim dtResult As DataTable
	// Dim bResult As Boolean = False
	// Dim bResultTmp As Boolean = False
	// sConsulta =
	// "select CoordenadaX, CoordenadaY from ClienteDomicilio where ClienteClave = '"
	// & sClienteClave & "' and Tipo = 2"
	// dtResult = oDBVen.RealizarConsultaSQL(sConsulta, "ClienteDomicilio")
	// If dtResult.Rows.Count > 0 Then
	// If Not IsDBNull(dtResult.Rows(0)("CoordenadaX")) AndAlso
	// dtResult.Rows(0)("CoordenadaX") <> 0 Then
	// nLongitudCliente = dtResult.Rows(0)("CoordenadaX")
	// bResultTmp = True
	// End If
	// If Not IsDBNull(dtResult.Rows(0)("CoordenadaY")) AndAlso
	// dtResult.Rows(0)("CoordenadaY") <> 0 Then
	// nLatitudCliente = dtResult.Rows(0)("CoordenadaY")
	// bResult = bResultTmp And True
	// End If
	// End If
	// Return bResult
	// Else
	// Return False
	// End If
	// End Function

    public void seleccionar() {
        // seleccionar(false);
        seleccionar(0);

    }

	public void IniciarGPS() {
        mVista.iniciarActividadConResultado(IObtencionGPS.class, Enumeradores.Solicitudes.SOLICITUD_GPS, Enumeradores.Acciones.ACCION_OBTENER_GPS);
    }

    private Boolean ObtenerCoordenadasCliente() {
        try {
            ISetDatos cli = Consultas.ConsultasCliente.obtenerCoordenadasCliente(mVista.getCliente());

            if (cli.getCount() > 0) {

                cli.moveToNext();

                if (!(cli.isNull(0) || cli.getFloat(0) == 0)) {

                    oParametros.put("LongitudCliente", cli.getFloat(0));
                }
                if (!(cli.isNull(1) || cli.getFloat(1) == 0)) {
                    oParametros.put("LatitudCliente", cli.getFloat(1));

                }
                if (!(cli.isNull(2))) {
                    ClienteDomicilioID = cli.getString(2);
                }

                cli.close();
                if ((Float) oParametros.get("LongitudCliente") != 0 && (Float) oParametros.get("LongitudCliente") != 0) {
                    return true;
                }
            }
            return false;

        } catch (Exception e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
        return false;

    }

	public void ValidarDatosGPS(DatosGPS datosGPS)
	{

		oParametros.put("LongitudGPS", datosGPS.getLongitud());
		oParametros.put("LatitudGPS", datosGPS.getLatitud());

		oParametros.put("TieneCoordenadas", ObtenerCoordenadasCliente());
		if ((Boolean) oParametros.get("TieneCoordenadas") && ((Cliente) (Sesion.get(Campo.ClienteActual))).PublicoGeneral == 0)
		{
			AseguramientoVisita aseguramiento = obtenerAseguramiento();
			if (aseguramiento.TipoAseguramiento == 2 || aseguramiento.TipoAseguramiento == 3 || aseguramiento.TipoAseguramiento == 5)
			{
				Location Puntoleido = new Location("");
				Puntoleido.setLatitude(datosGPS.getLatitud());
				Puntoleido.setLongitude(datosGPS.getLongitud());
				Location PuntoCliente = new Location("");
				PuntoCliente.setLatitude(((Float) oParametros.get("LatitudCliente")).doubleValue());

				PuntoCliente.setLongitude(((Float) oParametros.get("LongitudCliente")).doubleValue());
				oParametros.put("DistanciaGPS", Puntoleido.distanceTo(PuntoCliente));

				CONHist oConHist = (CONHist) Sesion.get(Campo.CONHist);

				if ((Float) oParametros.get("DistanciaGPS") > aseguramiento.LimiteGPS)
				{
					oParametros.put("GPSLeido", true);
					mVista.mostrarPreguntaSiNo(Mensajes.get("P0207"), 1);

					return;
				}
				else
				{
					oParametros.put("GPSLeido", true);
					SeleccionVisita();
					// mVista.iniciarActividad(ISeleccionVisita.class,
					// Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA,
					// null, false);

				}

			}
			else
			{
				oParametros.put("GPSLeido", true);
				SeleccionVisita();
				// mVista.iniciarActividad(ISeleccionVisita.class,
				// Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null,
				// false);
			}

		}
		else
		{
			oParametros.put("GPSLeido", true);
			// if((Boolean)oParametros.get("CodigoLeido") ==true)
			if (Integer.parseInt(oParametros.get("CodigoLeido").toString()) == 1)
			{
				ClienteDomicilio clidom = new ClienteDomicilio();
				clidom.ClienteClave = mVista.getCliente();
				clidom.ClienteDomicilioId = ClienteDomicilioID;
				try
				{
					BDVend.recuperar(clidom);
					clidom.CoordenadaX = (float) datosGPS.getLongitud();
					clidom.CoordenadaY = (float) datosGPS.getLatitud();
					clidom.Enviado = false;
					BDVend.guardarInsertar(clidom);
					BDVend.commit();
				}
				catch (Exception e)
				{
					// TODO Auto-generated catch block
					mVista.mostrarError(e.getMessage());
				}

			}
			else
			{
				ClienteDomicilio clidom = new ClienteDomicilio();
				clidom.ClienteClave = mVista.getCliente();
				clidom.ClienteDomicilioId = ClienteDomicilioID;
				try
				{
					BDVend.recuperar(clidom);
					clidom.CoordenadaX = (float) datosGPS.getLongitud();
					clidom.CoordenadaY = (float) datosGPS.getLatitud();
					clidom.MFechaHora = Generales.getFechaHoraActual();
					clidom.Enviado = false;
					BDVend.guardarInsertar(clidom);
					BDVend.commit();
				}
				catch (Exception e)
				{
					// TODO Auto-generated catch block
					mVista.mostrarError(e.getMessage());
				}

			}
			SeleccionVisita();
		}

	}

	// Private Function ValidarDatosGPS() As Boolean
	// 'Dim nDistancia As Decimal
	// If bTieneCoordenadas Then
	// 'If (nTipoIniciarVisita = 2 Or nTipoIniciarVisita = 3) Then
	// If (oAseguramiento.TipoAseguramiento = 2 Or
	// oAseguramiento.TipoAseguramiento = 3) Then
	// nDistanciaGPS = DistanciaAB(nLatitudCliente, nLongitudCliente,
	// nLatitudGPS, nLongitudGPS)
	// bIniciarVisita = nDistanciaGPS <=
	// IIf(IsDBNull(oConHist.Campos("LimiteGPS")), 0,
	// oConHist.Campos("LimiteGPS"))
	// Else
	// bIniciarVisita = True
	// End If
	// Else
	// If bCodigoLeido Then
	// oDBVen.EjecutarComandoSQL("Update clientedomicilio set MusuarioID='" &
	// oVendedor.UsuarioId & "',Enviado=0,MfechaHora=getdate(), CoordenadaX =" &
	// nLongitudGPS & " , CoordenadaY =" & nLatitudGPS &
	// " where ClienteClave = '" & oClienteActual.ClienteClave &
	// "' and Tipo = 2")
	// Else
	// oDBVen.EjecutarComandoSQL("Update clientedomicilio set ReferenciaDom = 'FormClientes_ValidarDatosGPS', MusuarioID='"
	// & oVendedor.UsuarioId & "',Enviado=0,MfechaHora=getdate(), CoordenadaX ="
	// & nLongitudGPS & " , CoordenadaY =" & nLatitudGPS &
	// " where ClienteClave = '" &
	// Me.FlexGridClientes.Item(Me.FlexGridClientes.Row, "ClienteClave") &
	// "' and Tipo = 2")
	// End If
	// bIniciarVisita = True
	// End If
	// End Function

	public boolean validarTextCodigoBarra()
	{
        aseguramiento = obtenerAseguramiento();
		if (aseguramiento.TipoContrasena != 0 && (aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.COD_BARRAS ||
                aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.COD_BARRAS_INI_FIN ||
                aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.COD_BARRAS_INI_FIN_GPS ||
                aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.NFC_INI_FIN ||
                aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.COD_BARRAS_NFC_INI_FIN)) {
            //deshabilitar textview CAI 3901
            return false;
		}else
            return true;
	}

    public boolean soloNFC(){
        return aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.NFC_INI_FIN;
    }

    public boolean aseguramientoNFC(){
        return aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.NFC_INI_FIN || aseguramiento.TipoAseguramiento == Enumeradores.TipoAseguramiento.COD_BARRAS_NFC_INI_FIN;
    }

	public void consultarCliente()
	{
		Cliente cliente = new Cliente();
		cliente.ClienteClave = mVista.getCliente();
		try
		{
			BDVend.recuperar(cliente);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		Sesion.set(Campo.ClienteActual, cliente);
		mVista.iniciarActividad(IConsultaCliente.class, Enumeradores.Acciones.ACCION_CONSULTAR_CLIENTE, null, false);
	}

	public void mostrarImproductividadCliente()
	{
		Cliente cliente = new Cliente();
		cliente.ClienteClave = mVista.getCliente();
		try
		{
			BDVend.recuperar(cliente);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		Sesion.set(Campo.ClienteActual, cliente);
		mVista.finalizar();
		mVista.iniciarActividad(INoVisitaCliente.class, Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE, null, false);
	}

	public void crearCliente()
	{
		if (((CONHist) Sesion.get(Campo.CONHist)).get("DatosCteNuevo").equals("1"))
			mVista.iniciarActividad(INuevoCliente.class, false);
		else
		{
			Clientes.crearNuevo();
			mVista.mostrarAdvertencia("Crear cliente con valores default e iniciar visita");
		}
	}

	public String validarClienteAgendado(Cliente cliente)
	{
		try
		{

			if (cliente.Clave.contains("Nuevo")) return "";
			oParametros.put("FueraFrecuencia", true);
			ISetDatos cli = Consultas.ConsultasCliente.obtenerAgendado(cliente.ClienteClave, (Ruta) Sesion.get(Campo.RutaActual));
			if (cli.getCount() > 0)
			{

				while (cli.moveToNext())
				{
					if (((Dia) Sesion.get(Campo.DiaActual)).DiaClave.equals(cli.getString(1)))
					{
						oParametros.put("FueraFrecuencia", false);
						break;
					}
				}

				cli.close();

				/*
				 * cli.moveToFirst(); if(!cli.isLast()){ //si regresa varios
				 * registros, recorrerlos para saber si esta o no dentro de la
				 * frecuencia for(int i = 0; i < cli.getCount(); i++){
				 * if(((Dia)Sesion
				 * .get(Campo.DiaActual)).DiaClave.equals(cli.getString(1))){
				 * Sesion.set(Campo.ClienteFueraFrecuencia, false); break; }
				 * cli.moveToNext(); } }else
				 * Sesion.set(Campo.ClienteFueraFrecuencia, false);
				 */

				if ((Boolean) oParametros.get("FueraFrecuencia"))
				{
					// mostrarAdvertencia(Mensajes.get("I0159"));
					return "I0159";
				}

				return "";
			}
			else
			{
				cli.close();
				// mostrarError(Mensajes.get("E0355"));
				return "E0355";
			}
		}
		catch (Exception e)
		{
			e.printStackTrace();
			return "";
		}
	}

	public boolean validarMostrarAutorizacion(boolean[] array)
	{
		AseguramientoVisita aseguramiento = obtenerAseguramiento();
		if (!aseguramiento.EdoContraFija || aseguramiento.TipoAseguramiento == 0)
		{
			return false;
		}
		else
		{
			if (((aseguramiento.TipoAseguramiento == 1 || aseguramiento.TipoAseguramiento == 3 || aseguramiento.TipoAseguramiento == 4 || aseguramiento.TipoAseguramiento == 5)) && Integer.parseInt(oParametros.get("CodigoLeido").toString()) == 0)
			{// !(Boolean)oParametros.get("CodigoLeido")){

				if (aseguramiento.TipoAseguramiento == 3 || aseguramiento.TipoAseguramiento == 5)
					array[1] = true;

				if (aseguramiento.TipoContrasena == 2)
					return true;
				else if (aseguramiento.EdoContraFija && (aseguramiento.TipoContrasena == 1 || aseguramiento.TipoContrasena == 0))
				{
					mVista.mostrarError(Mensajes.get("E0783"));
					array[0] = false;
					return false;
				}

			}
			else
			{
				if (aseguramiento.TipoAseguramiento != 2 && (aseguramiento.TipoAseguramiento != 3 || aseguramiento.TipoAseguramiento != 5) && aseguramiento.TipoContrasena == 2 && Integer.parseInt(oParametros.get("CodigoLeido").toString()) == 0)
					return true;
				else
					array[1] = true;
				return false;
			}
		}
		return true;
	}

	private AseguramientoVisita obtenerAseguramiento()
	{
		try
		{
			Vendedor vendedor = (Vendedor) Sesion.get(Sesion.Campo.VendedorActual);
			return Consultas.ConsultarAseguramientoVisita.obtenerAseguramientoPorVendedor(vendedor);
		}
		catch (Exception e)
		{
			e.printStackTrace();
			return null;
		}
	}

	private Cliente obtenerClientePorClave(String clienteClave)
	{
		try
		{
			Cliente cliente = new Cliente();
			cliente.ClienteClave = clienteClave;
			BDVend.recuperar(cliente);
			return cliente;
		}
		catch (Exception e)
		{
			e.printStackTrace();
			return null;
		}
	}

	public void seleccionarCodigoBarras(int codigoLeido)
	{

		Cliente cliente = new Cliente();
		cliente.ClienteClave = mVista.getCliente();

		boolean bExisteCliente;
		try
		{
			bExisteCliente = BDVend.existe(cliente);
		}
		catch (Exception e1)
		{
			// TODO Auto-generated catch block
			bExisteCliente = false;
		}

		if (bExisteCliente)
		{

			// seleccionar(true);
			// seleccionar(1);
			seleccionar(codigoLeido);

		}
		else
		{

			mVista.mostrarError(Mensajes.get("E0355"));
			mVista.reiniciarPantalla();
		}

	}

    public void seleccionarCodigoBarras(int codigoLeido, String codigoBarras) {

        Cliente cliente = new Cliente();
        cliente.ClienteClave = mVista.getCliente();

        boolean bExisteCliente = false;
        try {
            bExisteCliente = Consultas.ConsultasCliente.validarIdElectronico(codigoBarras);
        } catch (Exception e1) {
            // TODO Auto-generated catch block
            bExisteCliente = false;
        }

        if (bExisteCliente) {

            // seleccionar(true);
            // seleccionar(1);
            seleccionar(codigoLeido);

        } else {

            mVista.mostrarError(Mensajes.get("E0355"));
            mVista.reiniciarPantalla();
        }

    }

	public void toActividadesVed()
	{
		try
		{
			BDVend.cerrar();
			BDVend.Iniciar();
		}
		catch (Exception e)
		{
			e.printStackTrace();
			mVista.mostrarError(e.getMessage());
			return;
		}
		if (!BDVend.estaAbierta())
		{
			try
			{
				mVista.iniciarActividadConResultado(ISolicitudAgendaVendedor.class, Enumeradores.Solicitudes.SOLICITUD_AGENDA, Enumeradores.Acciones.ACCION_AGENDA_VENDEDOR);
			}
			catch (Exception e)
			{
				e.printStackTrace();
				mVista.mostrarError(e.getMessage());
				return;
			}
		}
		if (BDVend.estaAbierta())
		{
			mVista.iniciarActividad(ISeleccionActividadesVend.class, false);
		}
	}

}
