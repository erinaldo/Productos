package com.amesol.routelite.presentadores.act;

import java.text.SimpleDateFormat;
import java.util.Date;

import android.util.Log;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.UsuarioSustituto;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.VendedorJornada;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasMOTConfiguracion;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaInicioFinJornada;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.CapturaInicioFinJornada;

public class CapturarInicioFinJornada extends Presentador
{

	private ICapturaInicioFinJornada mVista;
	private CapturaInicioFinJornada mCamionVendedor;
	private Vendedor mVendedor;

	public CapturarInicioFinJornada(ICapturaInicioFinJornada vista, String accion)
	{
		mVista = vista;
		//		mAccion = accion;

	}

	@Override
	public void iniciar()
	{
		try
		{
			Usuario mUsuario = new Usuario();
			ConfiguracionLocal confLocal = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
			mUsuario = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(confLocal.get(ArchivoConfiguracion.CampoConfiguracion.USUARIO).toString());
			//mUsuario.USUId = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			//			String DiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			mVendedor = Consultas.ConsultasVendedor.obtenerVendedorPorUsuario(mUsuario);
			int VentaSinSurtir = Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("VentaSinSurtir").toString());

			if (Consultas.ConsultasVendedorJornada.obtenerJornadaActual(mVendedor) != null)
			{
				if (Consultas.ConsultasVendedorJornada.obtenerJornadaActual(mVendedor).FechaFinal == null )
				{
					ISetDatos mMOTConfiguracion = ConsultasMOTConfiguracion.obtenerMOTConfiguracion();
					mMOTConfiguracion.moveToFirst();
					if (VentaSinSurtir == 0 && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
						String clientesPorSurtir = Consultas.ConsultaRegistroInicioFin.obtenerClientesPorSurtir();		
						if (!clientesPorSurtir.equals("")){
							mVista.mostrarAdvertencia(Mensajes.get("E0751").replace("$0$",clientesPorSurtir));
						}
					}		
					
			/*		if (!Consultas.ConsultaRegistroInicioFin.obtenerRelacion(mVendedor.VendedorId) && mMOTConfiguracion.getInt("ForzarCapturaImpro") == 1)
						mVista.mostrarAdvertencia(Mensajes.get("I0270"));
					else */if (Consultas.ConsultaRegistroInicioFin.obtenerAgenda(mVendedor.VendedorId))
						mVista.mostrarAdvertencia(Mensajes.get("E0686"));
				}
			}
		}
		catch (Exception e)
		{
			mVista.mostrarAdvertencia(e.getMessage());
			//			e.printStackTrace();
		}

	}

	public String getFechaInicial(Vendedor vendedor)
	{
		ISetDatos datos;
		try
		{
			datos = Consultas.ConsultaRegistroInicioFin.obtenerDatosVendedorJornada(vendedor.VendedorId);
			datos.moveToFirst();
			Date fechaInicio = datos.getDate(1);
			return new SimpleDateFormat("dd/MM/yyyy hh:mm a").format(fechaInicio).toString();
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			e.printStackTrace();
			return null;
		}
	}

	public boolean getJornadaFinalizada()
	{
		try
		{
			ISetDatos datos = Consultas.ConsultaRegistroInicioFin.obtenerVendedorJornadaDatos(mVendedor.VendedorId);
			if (datos.getCount() > 0)
			{
				datos.moveToFirst();
				VendedorJornada mVendedorJornada = new VendedorJornada();
				mVendedorJornada.VendedorId = datos.getString(0);
				mVendedorJornada.VEJFechaInicial = datos.getDate(1);
				BDVend.recuperar(mVendedorJornada);
				return mVendedorJornada.FechaFinal != null;
			}
			else
			{
				return false;
			}

		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			e.printStackTrace();
			return false;
		}
	}

	public boolean registrarValores()
	{
		boolean noHayVisita = true;
		try
		{

            StringBuilder sDiaClaveJornada = new StringBuilder();
			if (!Consultas.ConsultaRegistroInicioFin.obtenerVendedorJornada(mVendedor.VendedorId,sDiaClaveJornada))
			{
				VendedorJornada mVendedorJornada = new VendedorJornada();
				mVendedorJornada.VendedorId = mVendedor.VendedorId;
				mVendedorJornada.VEJFechaInicial = Generales.getFechaHoraActual();
				mVendedorJornada.Enviado = false;
				mVendedorJornada.MFechaHora = Generales.getFechaHoraActual();
				mVendedorJornada.MUsuarioID = mVendedor.USUId;
				BDVend.guardarInsertar(mVendedorJornada);
			}
			else
			{
				ISetDatos datos = Consultas.ConsultaRegistroInicioFin.obtenerDatosVendedorJornada(mVendedor.VendedorId);
				datos.moveToFirst();
				VendedorJornada mVendedorJornada = new VendedorJornada();
				mVendedorJornada.VendedorId = datos.getString(0);
				mVendedorJornada.VEJFechaInicial = datos.getDate(1);
				datos.close();
				BDVend.recuperar(mVendedorJornada);
				if(mVendedorJornada.DiaClave != null) {
					mVendedorJornada.FechaFinal = Generales.getFechaHoraActual();
					mVendedorJornada.MFechaHora = Generales.getFechaHoraActual();
					mVendedorJornada.MUsuarioID = mVendedor.USUId;
					mVendedorJornada.Enviado = false;
					BDVend.guardarInsertar(mVendedorJornada);
				}else{
					noHayVisita = false;
				}
			}

			if(noHayVisita) {
				if (!((Usuario) Sesion.get(Campo.UsuarioActual)).USUId.equals(mVendedor.USUId)) {
					UsuarioSustituto usuarioSustituto = Consultas.ConsultasUsuarioSustituto.recuperarUltimoSustituto();
					if (usuarioSustituto != null) {
						usuarioSustituto.Enviado = false;
						BDVend.guardarInsertar(usuarioSustituto);
					}
				}

				BDVend.commit();
			}


		}
		catch (Exception e)
		{
			mVista.mostrarAdvertencia(e.getMessage());
		}

		return noHayVisita;
	}

	public boolean validaVentaSinSurtir()
	{
		try{
			int VentaSinSurtir = Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("VentaSinSurtir").toString());
			if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && VentaSinSurtir == 0){
				String clientesPorSurtir = Consultas.ConsultaRegistroInicioFin.obtenerClientesPorSurtir();		
				if (!clientesPorSurtir.equals("")){
					mVista.mostrarAdvertencia(Mensajes.get("E0751").replace("$0$",clientesPorSurtir));
					return false;
				}else
					return true;
			}
			else
				return true;
		}
		catch (Exception ex){
			mVista.mostrarError(ex.getMessage());
			return false;
		}
	}

	public boolean validaImproductividad(String diaActual)
	{
		boolean validar = false;

		try
		{
			//Log.i(null, "Pasa por validaImproductividad");
			
		//	Log.i(null, diaActual);
			validar = Consultas.ConsultaRegistroInicioFin.obtenerRelacion(mVendedor.VendedorId, diaActual);
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return validar;
	}
}
