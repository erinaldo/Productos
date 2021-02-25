package com.amesol.routelite.datos.basedatos;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.SearchManager;
import android.database.Cursor;
import android.database.MergeCursor;
import android.util.Log;

import com.amesol.routelite.actividades.Clientes;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ModuloMov;
import com.amesol.routelite.actividades.ModuloMovDetalle;
import com.amesol.routelite.actividades.PromocionDetalle;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.CalcularPorKilo.ProductoCalculadora;
import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.Agenda;
import com.amesol.routelite.datos.AseguramientoVisita;
import com.amesol.routelite.datos.CamionVendedor;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteVentaMensual;
import com.amesol.routelite.datos.ConfiguracionRecibo;
import com.amesol.routelite.datos.Deposito;
import com.amesol.routelite.datos.Descuento;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Esquema;
import com.amesol.routelite.datos.FolioFiscal;
import com.amesol.routelite.datos.FolioReservacion;
import com.amesol.routelite.datos.FrecuenciaExcep;
import com.amesol.routelite.datos.Inventario;
import com.amesol.routelite.datos.MercadeoMarca;
import com.amesol.routelite.datos.MercadeoProducto;
import com.amesol.routelite.datos.PLBPLE;
import com.amesol.routelite.datos.PoliticaContrasenaHist;
import com.amesol.routelite.datos.PreLiquidacion;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.Promocion;
import com.amesol.routelite.datos.PuntoGPS;
import com.amesol.routelite.datos.Recibo;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.SEMHist;
import com.amesol.routelite.datos.SaldoCambiosVendedor;
import com.amesol.routelite.datos.TRPGrupo;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.TrpTpd;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.UsuarioSustituto;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.VendedorJornada;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.presentadores.act.SeleccionarConsignacion;
import com.amesol.routelite.presentadores.act.SeleccionarFacturacion.TransProdFactura;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.CentroExpedicion;
import com.amesol.routelite.vistas.ConsultaInventario.ListaInventario;
import com.amesol.routelite.vistas.RevisionPendientes.pendientes;
import com.amesol.routelite.vistas.utilerias.ServicesCentral;

import java.lang.reflect.Field;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.SortedMap;
import java.util.TreeMap;
import java.util.concurrent.ExecutionException;

@SuppressLint("SimpleDateFormat")
public final class Consultas
{
	public static final class ConsultasValorReferencia
	{
		public static ISetDatos obtenerValores() throws Exception 
		{
			return BDTerm.consultar("SELECT VV.VARCodigo || VV.VAVClave _id, VV.VARCodigo, VV.VAVClave, VV.Grupo, VD.Descripcion FROM VARValor VV INNER JOIN VAVDescripcion VD ON VV.VARCodigo = VD.VARCodigo AND VV.VAVClave = VD.VAVClave");
		}

		public static ISetDatos obtenerValoresPorGrupo(String VARCodigo, String grupo, String MensajeSeleccion, boolean incluirNoDefinido) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			if (!MensajeSeleccion.equals(""))
			{
				consulta.append("select -1 as _id, '' as Grupo, -1 as " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", '" + MensajeSeleccion + "' as " + SearchManager.SUGGEST_COLUMN_TEXT_1 + " ");
				consulta.append("UNION ");
			}
			consulta.append("select VAD.VAVClave as _id,VVA.Grupo, VAD.VAVClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", VAD.Descripcion AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + " from ValorReferencia VR ");
			consulta.append("inner join VARValor VVA on VR.VARCodigo = VVA.VARCodigo ");
			consulta.append("inner join VAVDescripcion VAD on VR.VARCodigo = VAD.VARCodigo and VAD.VAVClave = VVA.VAVClave ");
			consulta.append("where VR.VARCodigo = '" + VARCodigo + "' and VVA.Grupo in (" + grupo + ") ");
			if (incluirNoDefinido)
				consulta.append(" OR (VR.VARCodigo = '" + VARCodigo + "' and VAD.VAVClave = '0')");
			return BDTerm.consultar(consulta.toString());
		}

		public static ISetDatos obtenerValoresReferencia(String VARCodigo) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select * from (");
			consulta.append("select VAD.VAVClave as _id, VAD.VAVClave, VAD.Descripcion from ValorReferencia VR ");
			consulta.append("inner join VARValor VVA on VR.VARCodigo = VVA.VARCodigo ");
			consulta.append("inner join VAVDescripcion VAD on VR.VARCodigo = VAD.VARCodigo and VAD.VAVClave = VVA.VAVClave ");
			consulta.append("where VR.VARCodigo = '" + VARCodigo + "'");
			consulta.append(") order by cast(_id as int)");
			return BDTerm.consultar(consulta.toString());
		}

		public static ISetDatos obtenerValoresReferencia(String VARCodigo, String MensajeSeleccion) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select * from (");
			// consulta.append("select -1 as _id, -1 as " +
			// SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", '" +
			// Mensajes.get("XSeleccionar", new
			// String[]{Mensajes.get("XMotivo")}) + "' as " +
			// SearchManager.SUGGEST_COLUMN_TEXT_1 + " ");
			if (!MensajeSeleccion.equals(""))
			{
				consulta.append("select -1 as _id, -1 as " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", '" + MensajeSeleccion + "' as " + SearchManager.SUGGEST_COLUMN_TEXT_1 + " ");
				consulta.append("UNION ");
			}
			consulta.append("select VAD.VAVClave as _id, VAD.VAVClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", VAD.Descripcion AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + " from ValorReferencia VR ");
			consulta.append("inner join VARValor VVA on VR.VARCodigo = VVA.VARCodigo ");
			consulta.append("inner join VAVDescripcion VAD on VR.VARCodigo = VAD.VARCodigo and VAD.VAVClave = VVA.VAVClave ");
			consulta.append("where VR.VARCodigo = '" + VARCodigo + "'");
			consulta.append(") order by cast(_id as int)");
			return BDTerm.consultar(consulta.toString());
		}

		public static ISetDatos obtenerValoresReferencia(String VARCodigo, String MensajeSeleccion, String SoloEstosValores) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select * from (");
			// consulta.append("select -1 as _id, -1 as " +
			// SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", '" +
			// Mensajes.get("XSeleccionar", new
			// String[]{Mensajes.get("XMotivo")}) + "' as " +
			// SearchManager.SUGGEST_COLUMN_TEXT_1 + " ");
			if (!MensajeSeleccion.equals(""))
			{
				consulta.append("select -1 as _id, -1 as " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", '" + MensajeSeleccion + "' as " + SearchManager.SUGGEST_COLUMN_TEXT_1 + " ");
				consulta.append("UNION ");
			}
			consulta.append("select VAD.VAVClave as _id, VAD.VAVClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", VAD.Descripcion AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + " from ValorReferencia VR ");
			consulta.append("inner join VARValor VVA on VR.VARCodigo = VVA.VARCodigo ");
			consulta.append("inner join VAVDescripcion VAD on VR.VARCodigo = VAD.VARCodigo and VAD.VAVClave = VVA.VAVClave ");
			consulta.append("where VR.VARCodigo = '" + VARCodigo + "' AND VVA.VAVClave in (" + SoloEstosValores + ")");
			consulta.append(") order by cast(_id as int)");
			return BDTerm.consultar(consulta.toString());
		}

		public static ISetDatos obtenerValores(String VARCodigo, String SoloEstosValores) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select * from (");
			consulta.append("select VAD.VAVClave as _id, VAD.VAVClave, VAD.Descripcion from ValorReferencia VR ");
			consulta.append("inner join VARValor VVA on VR.VARCodigo = VVA.VARCodigo ");
			consulta.append("inner join VAVDescripcion VAD on VR.VARCodigo = VAD.VARCodigo and VAD.VAVClave = VVA.VAVClave ");
			consulta.append("where VR.VARCodigo = '" + VARCodigo + "' ");
			if (SoloEstosValores != null)
				consulta.append("AND VVA.VAVClave in (" + SoloEstosValores + ")");
			consulta.append(") order by cast(_id as int)");
			return BDTerm.consultar(consulta.toString());
		}

		public static ISetDatos obtenerValoresExcepcion(String VARCodigo, String exceptoValores) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select * from (");
			consulta.append("select VAD.VAVClave as _id, VAD.VAVClave, VAD.Descripcion from ValorReferencia VR ");
			consulta.append("inner join VARValor VVA on VR.VARCodigo = VVA.VARCodigo ");
			consulta.append("inner join VAVDescripcion VAD on VR.VARCodigo = VAD.VARCodigo and VAD.VAVClave = VVA.VAVClave ");
			consulta.append("where VR.VARCodigo = '" + VARCodigo + "' AND VVA.VAVClave not in (" + exceptoValores + ")");
			consulta.append(") order by cast(_id as int)");
			return BDTerm.consultar(consulta.toString());
		}

		public static String obtenerDescripcion(String VARCodigo, String VAVClave) throws Exception
		{
			String resultado = "";
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT Descripcion FROM VAVDescripcion WHERE VARCodigo = '" + VARCodigo + "' AND VAVClave = " + VAVClave);
			ISetDatos datos = BDTerm.consultar(consulta.toString());
			if (datos.getCount() > 0)
			{
				datos.moveToNext();
				resultado = datos.getString("Descripcion");
			}
			datos.close();
			return resultado;
		}

		public static String obtenerGrupo(String VARCodigo, String VAVClave) throws Exception
		{
			String res = "";
			ISetDatos datos = BDTerm.consultar("SELECT Grupo FROM VARValor WHERE VARCodigo = '" + VARCodigo + "' AND VAVClave = '" + VAVClave + "'");
			if (datos.getCount() > 0)
			{
				datos.moveToNext();
				res = datos.getString("Grupo");
			}
			datos.close();
			return res;
		}
	}

	public static final class ConsultasUsuario
	{
		public static ISetDatos obtenerUsuarios() throws Exception {
			//SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", VAD.Descripcion AS " + SearchManager.SUGGEST_COLUMN_TEXT_1
			return BDTerm.consultar("SELECT USUId as _id,USUId, USUId as "+SearchManager.SUGGEST_COLUMN_TEXT_1+", Nombre as "+SearchManager.SUGGEST_COLUMN_INTENT_DATA+" FROM Usuario");
		}

		public static Usuario obtenerUsuarioPorClave(String Clave) throws Exception
		{
			ISetDatos setDatos = BDTerm.consultar(Usuario.class, new String[] {}, "Clave LIKE ?", new Object[]
			{ Clave });
			Usuario usuario = null;
			if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0))
			{
				usuario = (Usuario) BDTerm.instanciar(Usuario.class, setDatos);
			}
			setDatos.close();
			return usuario;
		}

        public static PoliticaContrasenaHist obtenerPoliticaContrasenaUsuario(String Clave) throws Exception{
            ISetDatos setDatos = BDTerm.consultar("select pch.PoliticaHid, pch.USUId, pch.FechaHoraMod, pch.Caducidad, pch.ValidarContAnt, pch.ValidarContBlanco " +
                    "from PoliticaContrasenaHist pch " +
                    "inner join Usuario u on pch.UsuId=u.UsuId " +
                    "where u.Clave='"+Clave+"' ");

            PoliticaContrasenaHist politica = null;
            if(setDatos.moveToNext()){
                politica = new PoliticaContrasenaHist();
                politica.PoliticaHid = setDatos.getString(0);
                politica.USUId = setDatos.getString(1);
                politica.FechaHoraMod = setDatos.getDate(2);
                politica.Caducidad = setDatos.getDate(3);
                politica.ValidarContAnt = setDatos.getBoolean(4);
                politica.ValidarContBlanco = setDatos.getBoolean(5);
            }
            setDatos.close();
            return politica;
        }
	}
	
	public static final class ConsultasUsuarioSustituto
	{
		public static UsuarioSustituto obtenerUltimoSustituto() throws Exception{
			UsuarioSustituto ust = null;
			String fecha = Generales.getFormatoFecha(Generales.getFechaActual(), "yyyy-MM-dd HH:mm:ss");
			ISetDatos setDatos = BDVend.consultar("SELECT SustitucionId, VendedorId, USUIdTitular, USUIdSustituto, UST.DiaClave, " +
					"FechaHoraInicio, FechaHoraFin FROM UsuarioSustituto as UST INNER JOIN Dia as D ON D.DiaClave = UST.DiaClave " +
					" AND D.FechaCaptura = '" + fecha + "' ORDER BY FechaHoraInicio DESC");
			if(setDatos != null && setDatos.moveToNext() && setDatos.getCount() > 0){
				ust = new UsuarioSustituto();
				ust.SustitucionId = setDatos.getString(0);
				ust.VendedorId = setDatos.getString(1);
				ust.USUIdTitular = setDatos.getString(2);
				ust.USUIdSustituto = setDatos.getString(3);
				ust.DiaClave = setDatos.getString(4);
				ust.FechaHoraInicio = setDatos.getDate(5);
				ust.FechaHoraFin = setDatos.getDate(6);
			}
			return ust;
		}
		
		public static UsuarioSustituto recuperarUltimoSustituto() throws Exception{
			UsuarioSustituto ust = null;
			String fecha = Generales.getFormatoFecha(Generales.getFechaActual(), "yyyy-MM-dd HH:mm:ss");
			ISetDatos setDatos = BDVend.consultar("SELECT SustitucionId, VendedorId, USUIdTitular, USUIdSustituto, UST.DiaClave, " +
					"FechaHoraInicio, FechaHoraFin FROM UsuarioSustituto as UST INNER JOIN Dia as D ON D.DiaClave = UST.DiaClave " +
					" AND D.FechaCaptura = '" + fecha + "' ORDER BY FechaHoraInicio DESC");
			if(setDatos != null && setDatos.moveToNext() && setDatos.getCount() > 0){
				ust = (UsuarioSustituto)BDVend.instanciar(UsuarioSustituto.class, setDatos);				
				ust.SustitucionId = setDatos.getString(0);
				ust.VendedorId = setDatos.getString(1);
				ust.USUIdTitular = setDatos.getString(2);
				ust.USUIdSustituto = setDatos.getString(3);
				ust.DiaClave = setDatos.getString(4);
				ust.FechaHoraInicio = setDatos.getDate(5);
				ust.FechaHoraFin = setDatos.getDate(6);
			}
			return ust;
		}
        public static UsuarioSustituto obtenerUltimoSustituto(String diaClave) throws Exception{
            UsuarioSustituto ust = null;
            String fecha = Generales.getFormatoFecha(Generales.getFechaActual(), "yyyy-MM-dd HH:mm:ss");
            ISetDatos setDatos = BDVend.consultar("SELECT SustitucionId, VendedorId, USUIdTitular, USUIdSustituto, UST.DiaClave, " +
                    "FechaHoraInicio, FechaHoraFin FROM UsuarioSustituto as UST INNER JOIN Dia as D ON D.DiaClave = UST.DiaClave " +
                    " AND D.DiaClave = '" + diaClave + "' ORDER BY FechaHoraInicio DESC LIMIT 1");
            if(setDatos != null && setDatos.moveToNext() && setDatos.getCount() > 0){
                ust = new UsuarioSustituto();
                ust.SustitucionId = setDatos.getString(0);
                ust.VendedorId = setDatos.getString(1);
                ust.USUIdTitular = setDatos.getString(2);
                ust.USUIdSustituto = setDatos.getString(3);
                ust.DiaClave = setDatos.getString(4);
                ust.FechaHoraInicio = setDatos.getDate(5);
                ust.FechaHoraFin = setDatos.getDate(6);
            }
            return ust;
        }

        public static UsuarioSustituto obtenerUltimoSustitutoCualquierDia() throws Exception{
            UsuarioSustituto ust = null;
            ISetDatos setDatos = BDVend.consultar("SELECT SustitucionId, VendedorId, USUIdTitular, USUIdSustituto, UST.DiaClave, " +
                    "FechaHoraInicio, FechaHoraFin FROM UsuarioSustituto as UST INNER JOIN Dia as D ON D.DiaClave = UST.DiaClave " +
                    " ORDER BY FechaHoraInicio DESC Limit 1 ");
            if(setDatos != null && setDatos.moveToNext() && setDatos.getCount() > 0){
                ust = new UsuarioSustituto();
                ust.SustitucionId = setDatos.getString(0);
                ust.VendedorId = setDatos.getString(1);
                ust.USUIdTitular = setDatos.getString(2);
                ust.USUIdSustituto = setDatos.getString(3);
                ust.DiaClave = setDatos.getString(4);
                ust.FechaHoraInicio = setDatos.getDate(5);
                ust.FechaHoraFin = setDatos.getDate(6);
            }
            setDatos.close();
            return ust;
        }
	}

	public static final class ConsultasServidorComunicaciones
	{
		public static Date obtenerFechaPrimerDia() throws Exception
		{
			Date resultado;
			ISetDatos setDatos = BDVend.consultar("select min(fechaCaptura) from dia where FueraFrecuencia =0");
			if (!setDatos.moveToNext())
				return null;
			resultado = setDatos.getDate(0);
			setDatos.close();
			return resultado;
		}
	}

	public static final class ConsultasVendedor
	{
		public static Vendedor obtenerVendedorPorUsuario(Usuario usuario) throws Exception
		{
			ISetDatos setDatos = BDVend.consultar(Vendedor.class, new String[] {}, "USUId Like ?", new Object[]
			{ usuario.USUId });
			Vendedor vendedor = null;
			if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0))
			{
				vendedor = (Vendedor) BDTerm.instanciar(Vendedor.class, setDatos);
			}
			setDatos.close();
			return vendedor;
		}

        public static HashMap<String, SaldoCambiosVendedor> obtenerSaldoCambiosVendedor() throws Exception
        {
            String vendedorId =  ((Vendedor)Sesion.get(Campo.VendedorActual)).VendedorId ;
            //Los meses inician en 0
            int Mes  = ((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura.getMonth() + 1;
            HashMap<String,SaldoCambiosVendedor> resultado = new HashMap<String,SaldoCambiosVendedor>();

            ISetDatos setDatos = BDVend.consultar("Select VendedorId as VendedorId, Mes, EsquemaID as EsquemaId from SaldoCambiosVendedor where VendedorId = '" + vendedorId + "' and Mes =" + Mes );
            while (setDatos.moveToNext())
            {
                SaldoCambiosVendedor saldoCambiosVendedor = new SaldoCambiosVendedor();
                saldoCambiosVendedor.VendedorID = setDatos.getString("VendedorId");
                saldoCambiosVendedor.Mes = setDatos.getShort("Mes");
                saldoCambiosVendedor.EsquemaID = setDatos.getString("EsquemaId");
                BDVend.recuperar(saldoCambiosVendedor);
                resultado.put(setDatos.getString("EsquemaId"), saldoCambiosVendedor);
            }
            setDatos.close();
            return resultado;
        }

        public static ISetDatos obtenerCursorSaldoCambiosVendedor() throws Exception
        {
            String vendedorId =  ((Vendedor)Sesion.get(Campo.VendedorActual)).VendedorId ;
            //Los meses inician en 0
            int Mes  = ((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura.getMonth() + 1;

            return BDVend.consultar("Select EsquemaID as _id, EsquemaID as EsquemaId, SaldoDisponible - SaldoUsado as SaldoDisponible from SaldoCambiosVendedor where VendedorId = '" + vendedorId + "' and Mes =" + Mes );
        }
	}

	public static final class ConsultasDia
	{
		public static ISetDatos obtenerDiasAgenda() throws Exception
		{
			return BDVend.consultar("SELECT DiaClave _id, DiaClave, FechaCaptura FROM Dia WHERE FueraFrecuencia = 0 ORDER BY FechaCaptura");

		}
		public static void obtenerRangoAgenda(Date[] fechas) throws Exception
		{
			ISetDatos setDatos = BDVend.consultar("Select min(FechaCaptura) as FechaMinima, max(FechaCaptura) as FechaMaxima from dia where FueraFrecuencia = 0");
			if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0))
			{
				//vendedor = (Vendedor) BDTerm.instanciar(Vendedor.class, setDatos);
				fechas[0]= setDatos.getDate("FechaMinima");
				fechas[1] = setDatos.getDate("FechaMaxima");
			}
			setDatos.close();

		}
	}

	public static final class ConsultasRuta
	{
		public static void setNewFolioClienteNvo(String RUTClave, short folioClt)
		{
			try
			{
				BDVend.ejecutarComando("update ruta set FolioClienteNvo = " + folioClt + ", Enviado = 0 where RUTClave  = '" + RUTClave + "'");
			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

		}

		public static short getFolioClteNvo() throws Exception
		{
			ISetDatos datos = BDVend.consultar("SELECT FolioClienteNvo FROM ruta");
			short res = 0;
			if (datos.moveToNext())
			{
				res = datos.getShort(0);
			}
			datos.close();
			return res;
		}

		public static ISetDatos obtenerRutas() throws Exception
		{
			return BDVend.consultar("SELECT RUTClave _id, RUTClave, RUTClave || ' - ' || Descripcion Descripcion, Inventario FROM Ruta");
		}
	}

	public static final class ConsultasCliente
	{
		public static ISetDatos obtenerVisitados(Dia diaActual, Ruta rutaActual, String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Calle || ' ' || Numero AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + " ");
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				//si es reparto, agregar esta columna para saber si tiene pedidos pendientes por surtir
				sConsulta.append(",case when (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("is null then 0 else (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("end as PedidosXSurtir ");				
			}
			sConsulta.append(" FROM( ");
			sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero ");
			sConsulta.append("FROM Agenda ");
			sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
			sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
			sConsulta.append("INNER join visita VIS on VIS.ClienteClave = Agenda.ClienteClave and VIS.DiaClave = '" + diaActual.DiaClave + "' and Agenda.RUTClave = VIS.RutClave and VIS.VendedorID = Agenda.VendedorID ");
			sConsulta.append("WHERE Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
			sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero) as t ");
			if (filtro != null)
				sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
			sConsulta.append("ORDER BY Orden ");
			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerNoVisitados(Dia diaActual, Ruta rutaActual, String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Calle || ' ' || Numero AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + " ");
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				//si es reparto, agregar esta columna para saber si tiene pedidos pendientes por surtir
				sConsulta.append(",case when (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("is null then 0 else (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("end as PedidosXSurtir ");				
			}
			sConsulta.append(" FROM( ");
			sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero ");
			sConsulta.append("FROM Agenda ");
			sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
			sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
			sConsulta.append("WHERE Visitado=2 AND DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
			sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero) as t ");
			if (filtro != null)
				sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
			sConsulta.append("ORDER BY Orden ");
			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerFueraFrecuencia(Dia diaActual, Ruta rutaActual, String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT AGN.ClienteClave AS _id, AGN.ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Calle || ' ' || Numero AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + " ");
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				//si es reparto, agregar esta columna para saber si tiene pedidos pendientes por surtir
				sConsulta.append(",case when (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = CLI.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("is null then 0 else (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = CLI.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("end as PedidosXSurtir ");				
			}
			sConsulta.append("FROM Agenda AGN ");
			sConsulta.append("INNER JOIN Cliente CLI ON AGN.ClienteClave = CLI.ClienteClave ");
			sConsulta.append("INNER JOIN ClienteDomicilio CLD ON AGN.ClienteClave = CLD.ClienteClave and CLD.Tipo = 2 ");
			sConsulta.append("WHERE AGN.ClienteClave not in(Select ClienteClave from Agenda where DiaClave='" + diaActual.DiaClave + "') ");
			sConsulta.append("and AGN.RUTClave='" + rutaActual.RUTClave + "' ");
			if (filtro != null)
				sConsulta.append("AND (Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%') ");
			sConsulta.append("group by AGN.ClienteClave, CLI.Clave, CLI.RazonSocial, CLI.NombreContacto, CLD.Calle, CLD.Numero ");
			if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("OrdenVistaCtesFF").length()>0){
				sConsulta.append("ORDER BY " + ((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("OrdenVistaCtesFF") );
			}else{
				sConsulta.append("ORDER BY CLI.Clave ");
			}
			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerTodos(Dia diaActual, Ruta rutaActual, String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Calle || ' ' || Numero AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + " ");
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				//si es reparto, agregar esta columna para saber si tiene pedidos pendientes por surtir
				sConsulta.append(",case when (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("is null then 0 else (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("end as PedidosXSurtir ");				
			}
			sConsulta.append(" FROM( ");
			sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero ");
			sConsulta.append("FROM Agenda ");
			sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
			sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
			if(diaActual != null && rutaActual != null) sConsulta.append("WHERE DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
			sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero) as t ");
			if (filtro != null)
				sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
			if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("OrdenVistaCtes").length()>0){
				sConsulta.append("ORDER BY " + ((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("OrdenVistaCtes") );
			}else{
				sConsulta.append("ORDER BY Orden ");
			}
			return BDVend.consultar(sConsulta.toString());
		}
		
		public static ISetDatos obtenerNoVisitadosRec(Dia diaActual, Ruta rutaActual, String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT AGN.ClienteClave AS _id, AGN.ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Calle || ' ' || Numero AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + " ");
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				//si es reparto, agregar esta columna para saber si tiene pedidos pendientes por surtir
				/*sConsulta.append(",case when (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = CLI.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("is null then 0 else (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = CLI.ClienteClave group by VIS.ClienteClave) ");*/
				sConsulta.append(",0 as PedidosXSurtir ");				
			}
			sConsulta.append("FROM Agenda AGN ");
			sConsulta.append("INNER JOIN ClienteSinVisitaRec CSV ON AGN.ClienteClave = CSV.ClienteClave AND CSV.RUTClave='" + rutaActual.RUTClave + "' ");
			sConsulta.append("INNER JOIN Cliente CLI ON CSV.ClienteClave = CLI.ClienteClave ");
			sConsulta.append("INNER JOIN ClienteDomicilio CLD ON AGN.ClienteClave = CLD.ClienteClave and CLD.Tipo = 2 ");
			sConsulta.append("WHERE AGN.ClienteClave not in(Select ClienteClave from Agenda where DiaClave='" + diaActual.DiaClave + "') ");
			sConsulta.append("and AGN.RUTClave='" + rutaActual.RUTClave + "' ");
			if (filtro != null)
				sConsulta.append("AND (Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%') ");
			sConsulta.append("group by AGN.ClienteClave, CLI.Clave, CLI.RazonSocial, CLI.NombreContacto, CLD.Calle, CLD.Numero ");
			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerConMensaje(String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Calle || ' ' || Numero AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + " ");
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				//si es reparto, agregar esta columna para saber si tiene pedidos pendientes por surtir
				sConsulta.append(",case when (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("is null then 0 else (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("end as PedidosXSurtir ");				
			}
			sConsulta.append(" FROM( ");
			sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero ");
			sConsulta.append("FROM Agenda ");
			sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
			sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
			sConsulta.append("WHERE Cliente.ClienteClave in (select ClienteClave  from ClienteMensaje where TipoEstado=1) ");
			sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero) as t ");
			if (filtro != null)
				sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
			sConsulta.append("ORDER BY Orden ");
			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerConCobranza(Dia diaActual, Ruta rutaActual, String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();

			SimpleDateFormat destino = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss");
			String sFecha = destino.format(diaActual.FechaCaptura);

			if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 1)
			{
				sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Calle || ' ' || Numero AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + " ");
				if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
					//si es reparto, agregar esta columna para saber si tiene pedidos pendientes por surtir
					sConsulta.append(",case when (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
					sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
					sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
					sConsulta.append("is null then 0 else (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
					sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
					sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
					sConsulta.append("end as PedidosXSurtir ");				
				}
				sConsulta.append(" FROM( ");
				sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero ");
				sConsulta.append("FROM Agenda ");
				sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
				sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
				sConsulta.append("WHERE DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
				sConsulta.append("and cliente.clienteclave  in( select v.clienteclave from transprod t inner join visita v on t.visitaclave=v.visitaclave and t.diaclave=v.diaclave left join AbnTrp At on At.TransprodID=t.TransprodID left join Abono A on A.AbnID =At.ABnID and A.DiaClave=  '" + diaActual.DiaClave + "' ");
				sConsulta.append("where t.diaclave <> '" + diaActual.DiaClave + "' and (t.DiaClave1 <> '" + diaActual.DiaClave + "' or t.DiaClave1 is null) and A.AbnID is null and t.TipoFase not in (0,1) and t.saldo>0 and ((Tipo = 1 AND FechaCobranza  <= '" + sFecha + "' ) or Tipo = 24) ) ");
				sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero) as t ");
				if (filtro != null)
					sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
				sConsulta.append("ORDER BY Orden ");
			} // ___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---
			else if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 0)
			{
				sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Calle || ' ' || Numero AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + " ");
				if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
					//si es reparto, agregar esta columna para saber si tiene pedidos pendientes por surtir
					sConsulta.append(",case when (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
					sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
					sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
					sConsulta.append("is null then 0 else (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
					sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
					sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
					sConsulta.append("end as PedidosXSurtir ");				
				}
				sConsulta.append(" FROM( ");
				sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero ");
				sConsulta.append("FROM Agenda ");
				sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
				sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
				sConsulta.append("WHERE DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
				sConsulta.append("and cliente.clienteclave  in( select v.clienteclave from transprod t inner join visita v on t.visitaclave=v.visitaclave and t.diaclave=v.diaclave left join AbnTrp At on At.TransprodID=t.TransprodID left join Abono A on A.AbnID =At.ABnID and A.DiaClave=  '" + diaActual.DiaClave + "' ");
				sConsulta.append("where t.diaclave <> '" + diaActual.DiaClave + "' and (t.DiaClave1 <> '" + diaActual.DiaClave + "' or t.DiaClave1 is null) and A.AbnID is null and t.TipoFase not in (0) and t.saldo>0 and ((Tipo = 8 AND FechaCobranza  <= '" + sFecha + "' ) or Tipo = 24) ) ");
				sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero) as t ");
				if (filtro != null)
					sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
				sConsulta.append("ORDER BY Orden ");
			} // ___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---
			else if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
			{
				sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Calle || ' ' || Numero AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + " ");
				if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
					//si es reparto, agregar esta columna para saber si tiene pedidos pendientes por surtir
					sConsulta.append(",case when (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
					sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
					sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
					sConsulta.append("is null then 0 else (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
					sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
					sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
					sConsulta.append("end as PedidosXSurtir ");				
				}
				sConsulta.append(" FROM( ");
				sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero ");
				sConsulta.append("FROM Agenda ");
				sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
				sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
				sConsulta.append("WHERE DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
				sConsulta.append("and cliente.clienteclave  in( select v.clienteclave from transprod t inner join visita v on t.visitaclave=v.visitaclave and t.diaclave=v.diaclave left join AbnTrp At on At.TransprodID=t.TransprodID left join Abono A on A.AbnID =At.ABnID and A.DiaClave=  '" + diaActual.DiaClave + "' ");
				sConsulta.append("where t.diaclave <> '" + diaActual.DiaClave + "' and (t.DiaClave1 <> '" + diaActual.DiaClave + "' or t.DiaClave1 is null) and A.AbnID is null and t.TipoFase not in (0) and t.saldo>0 and (FechaCobranza  <= '" + sFecha + "' ) and t.TipoFase not in (0,1) and t.saldo > 0 and ( FechaCobranza  <= '" + sFecha + "' ) and t.Tipo=(CASE WHEN Cliente.TipoFiscal=1 Then 1 Else 8 END) or t.Tipo=24) ");
				sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero) as t ");
				if (filtro != null)
					sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
				sConsulta.append("ORDER BY Orden ");
			}

			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerImproductivos(Dia diaActual, Ruta rutaActual, String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Calle || ' ' || Numero AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + " ");
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				//si es reparto, agregar esta columna para saber si tiene pedidos pendientes por surtir
				sConsulta.append(",case when (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("is null then 0 else (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("end as PedidosXSurtir ");				
			}
			sConsulta.append(" FROM( ");
			sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero ");
			sConsulta.append("FROM Agenda ");
			sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
			sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
			sConsulta.append("WHERE Visitado=4 AND DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
			sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero) as t ");
			if (filtro != null)
				sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
			sConsulta.append("ORDER BY Orden ");

			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerPorSurtir(Dia diaActual, Ruta rutaActual, String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Calle || ' ' || Numero AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + " ");
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				//si es reparto, agregar esta columna para saber si tiene pedidos pendientes por surtir
				sConsulta.append(",case when (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("is null then 0 else (select case when count(*) > 0 then 1 else 0 end as PedidoXSurtir ");
				sConsulta.append("from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (1,7) and VIS.ClienteClave = t.ClienteClave group by VIS.ClienteClave) ");
				sConsulta.append("end as PedidosXSurtir ");				
			}
			sConsulta.append(" FROM( ");
			sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero ");
			sConsulta.append("FROM Agenda ");
			sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
			sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
			sConsulta.append("WHERE Agenda.DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' AND Cliente.ClienteClave in (select v.clienteclave ");
			sConsulta.append("from transprod t inner join visita v on t.visitaclave=v.visitaclave and t.diaclave=v.diaclave ");
			sConsulta.append("where (t.TipoFase = 1 or (t.TipoFase = 7 and t.FechaEntrega = '" + diaActual.FechaCaptura + "')) and (Tipo = 1 or Tipo = 24))");
			sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero) as t ");
			if (filtro != null)
				sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
			sConsulta.append("ORDER BY Orden");

			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerNuevos(String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();

			sConsulta.append("SELECT Cliente.ClienteClave as _id, Cliente.ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", ");
			sConsulta.append("Cliente.Clave || ' - ' || Cliente.RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", ");
			sConsulta.append("CASE WHEN Cliente.NombreContacto IS NULL OR Cliente.NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE Cliente.NombreContacto END AS Contacto, ");
			sConsulta.append("ClienteDomicilio.Calle || ' ' || ClienteDomicilio.Numero AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + ", 0 as PedidosXSurtir ");
			sConsulta.append("FROM Cliente ");
			sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
			sConsulta.append("WHERE Cliente.Clave LIKE 'NUEVO%' ");
			sConsulta.append("GROUP BY Cliente.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero ");

			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerMensajesCliente(String clienteClave, String tipoModulo) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();

			sConsulta.append("select MMS.MDBMensajeTipo || MMS.Numero as _id, MMS.MDBMensajeTipo || MMS.Numero || ' - ' || MMS.Descripcion as Descripcion ");
			sConsulta.append("from ClienteMensaje CLM ");
			sConsulta.append("inner join MDBMensaje MMS on MMS.MDBMensajeID = CLM.MDBMensajeID ");
			sConsulta.append("inner join ModuloMensaje MME on MME.MDBMensajeID =  MMS.MDBMensajeID ");
			sConsulta.append("where CLM.Tipoestado=1 and CLM.ClienteClave='" + clienteClave + "' ");
			sConsulta.append("and MME.TipoIndice = " + tipoModulo + " ");
			sConsulta.append("order by CLM.MFechaHora ");

			return BDVend.consultar(sConsulta.toString());
		}

		public static String obtenerClaveClienteNuevo()
		{
			try
			{
				StringBuilder sConsulta = new StringBuilder();
				sConsulta.append("SELECT MAX(CAST(REPLACE(Clave, 'NUEVO', '') AS INT)) AS Clave FROM Cliente WHERE Clave like 'NUEVO%'");

				String sMax = BDVend.getBD().ejecutarEscalar(sConsulta.toString());
				int nMax = 0;
				if (sMax != "")
					nMax = Integer.parseInt(sMax);
				nMax += 1;
				return "NUEVO" + nMax;

			}
			catch (Exception e)
			{
				e.printStackTrace();
				return "NUEVO1";
			}

		}

	public static ISetDatos obtenerAgendado(String clienteClave, Ruta rutaActual) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("Select CLI.ClienteClave,AGN.DiaClave from Cliente CLI ");
			sConsulta.append("inner join Agenda AGN on CLI.ClienteClave = AGN.ClienteClave ");
			sConsulta.append("where CLI.ClienteClave ='" + clienteClave + "' and AGN.RUTClave='" + rutaActual.RUTClave + "'");
			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerCoordenadasCliente(String clienteClave) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("Select CoordenadaX, CoordenadaY, ClienteDomicilioID  From ClienteDomicilio where Tipo=2 and ClienteClave='" + clienteClave + "' ");

			return BDVend.consultar(sConsulta.toString());
		}

		public static void actualizarSaldo(String ClienteClave, float Total) throws Exception
		{
			BDVend.ejecutarComando("UPDATE Cliente SET SaldoEfectivo = SaldoEfectivo + " + Total + " WHERE ClienteClave = '" + ClienteClave + "'");
		}

		/*
		 * public static ISetDatos obtenerLimiteCredito (String clienteClave)
		 * throws Exception{ StringBuilder sConsulta = new StringBuilder();
		 * sConsulta.append(
		 * "SELECT ValidaLimite, LimiteCredito FROM CLIFormaVenta WHERE CFVTipo = 2 AND ClienteClave = '"
		 * + clienteClave + "'");
		 * 
		 * return BDVend.consultar(sConsulta.toString()); }
		 */

		public static float obtenerSaldoEfectivo(String ClienteClave) throws Exception
		{
			ISetDatos datos = BDVend.consultar("SELECT saldoefectivo FROM Cliente WHERE ClienteClave = '" + ClienteClave + "'");
			float res = 0;
			if (datos.moveToNext())
			{
				res = datos.getFloat(0);
			}
			datos.close();
			return res;
		}

		public static int obtenerSumFechaFacturaCliente(Cliente oCliente) throws Exception
		{
			ISetDatos datos = BDVend.consultar("SELECT count(*) FechaFactura FROM Cliente WHERE ClienteClave = '" + oCliente.ClienteClave + "' AND FechaFactura < datetime('now','-" + oCliente.DiasVencimiento + " day')");
			int resultado = 0;
			if (datos.moveToNext())
			{
				resultado = datos.getInt(0);
			}
			datos.close();
			return resultado;
		}

		public static ISetDatos obtenerPuntosEntrega(String clienteClave) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			String sTipo;
			if (BDVend.bd.ejecutarEscalarInteger("select count(*) from ClienteDomicilio where ClienteClave = '" + clienteClave + "' and Tipo = 3") > 0)
				sTipo = "3";
			else
				sTipo = "2";

			sConsulta.append("select ClienteDomicilioId as _id, ClienteDomicilioId, ifnull(Calle,'') || ' ' || ifnull(Numero,'')  || ' ' || ifnull(Poblacion,'') || ' ' || ClienteDomicilioID as Domicilio ");
			sConsulta.append("from ClienteDomicilio ");
			sConsulta.append("where ClienteClave = '" + clienteClave + "' and Tipo = " + sTipo);
			return BDVend.consultar(sConsulta.toString());
		}

        public static boolean existeCFVTipo(String ClienteClave) throws Exception
        {
            ISetDatos datos = BDVend.consultar("SELECT count(*) as NumCFVTipo from CLIFormaVenta WHERE ClienteClave = '" + ClienteClave + "'");
            boolean res = false;
            if (datos.moveToNext())
            {
                if (datos.getInt("NumCFVTipo") >0){
                    return true;
                }
            }
            datos.close();
            return res;
        }

        public static boolean validarIdElectronico(String IdElectronico) throws Exception {
            ISetDatos datos = BDVend.consultar("SELECT * from cliente WHERE idElectronico = '" + IdElectronico + "'");
            boolean res = false;
            if (datos.moveToNext()) {
                if (datos.getString("IdElectronico").equals(IdElectronico)) {
                    return true;
                }
            }
            datos.close();
            return res;
        }

        public static String validarClienteClave(String IdElectronico) throws Exception {
            ISetDatos datos = BDVend.consultar("SELECT * from cliente WHERE idElectronico = '" + IdElectronico + "'");
            String res = "";
            if (datos.moveToNext()) {
                res = datos.getString("ClienteClave").toString();
            }
            datos.close();
            return res;
        }
    }



    public static final class ConsultasCONHist
	{
		public static ISetDatos obtenerCONHist() throws Exception
		{
			return BDVend.consultar("SELECT * FROM CONHist");
		}
	}

	public static final class ConsultasMOTConfiguracion
	{
		public static ISetDatos obtenerMOTConfiguracion() throws Exception
		{
			return BDVend.consultar("SELECT * FROM MOTConfiguracion");
		}
		
	}

	public static final class ConsultasConfigParametro
	{
		public static ISetDatos obtenerConfigParametro() throws Exception
		{
			return BDVend.consultar("SELECT Parametro, Valor, Identificador FROM ConfigParametro");
		}
	}
	
	public static final class ConsultasPrecio
	{
		public static ISetDatos OrdenarPrecios(ArrayList<String> Precios) throws Exception
		{

			String sCondicion = "";
			for (int i = 0; i < Precios.size(); i++)
			{
				sCondicion += "'" + Precios.get(i) + "',";

			}
			sCondicion = sCondicion.substring(0, sCondicion.length() - 1);
			try
			{
				return BDVend.consultar("SELECT PrecioClave FROM Precio WHERE PrecioClave IN (" + sCondicion + ") ORDER BY Jerarquia");
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}
        public static String obtenerListasCargadas() throws Exception
        {
            String listasCargadas = "";
            try
            {
                ISetDatos datos = BDVend.consultar("SELECT PrecioClave FROM Precio ");

                while (datos.moveToNext())
                {
                    listasCargadas += datos.getString("PrecioClave") + ",";
                }
                datos.close();

                if (listasCargadas.length()>0){
                    listasCargadas = listasCargadas.substring(0, listasCargadas.length() - 1);
                }
            }
            catch (Exception ex)
            {
                ex.printStackTrace();
                return "";
            }
            return listasCargadas;
        }

		public static String obtenerNombreListaPorClave(String precioClave){
			String nombre = "";
			try{
				ISetDatos lista = BDVend.consultar("select nombre from precio where precioclave='" + precioClave + "'");
				if(lista.moveToNext()){
					nombre = lista.getString("Nombre");
				}
			}catch (Exception e){
				return nombre;
			}
			return nombre;
		}
	}

	public static final class ConsultasCantidad
	{
		public static ISetDatos OptenerCantidad(String TransProdID, String ProductoClave) throws Exception
		{
			try
			{
				return BDVend.consultar("Select Cantidad From TransProdDetalle Where ProductoClave='" + ProductoClave + "' And TransProdID='" + TransProdID.replace("'", "") + "'");
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}
	}

	public static final class ConsultasEsquema
	{
		public static String obtenerIdEsquemaCteNuevo()
		{
			try
			{
				return BDVend.getBD().ejecutarEscalar("SELECT EsquemaId FROM Esquema WHERE Clave = 'NVO001'");
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}

		}

		public static ISetDatos obtenerHijosEsquema(String EsquemaId) throws Exception
		{
			return BDVend.consultar("SELECT * FROM Esquema WHERE EsquemaIdPadre = '" + EsquemaId + "'");					
		}
		
		public static ISetDatos obtenerEsquemaPorId(String EsquemaId) throws Exception
		{
			return BDVend.consultar("SELECT * FROM Esquema WHERE EsquemaId = '" + EsquemaId + "'");
		}

		public static ISetDatos obtenerEsquemasPorTipo(ServicesCentral.TiposEsquemas Tipo)
		{
			try
			{
				return BDVend.getBD().consultar("SELECT * FROM Esquema WHERE Tipo=" + Tipo.value);
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}

		}
		
		public static SortedMap<String,Esquema> obtenerEsquemasJerarquia(ServicesCentral.TiposEsquemas Tipo, String filtro) throws Exception
		{
				StringBuilder consulta = new StringBuilder();

				/*consulta.append("WITH ");
				consulta.append("Jerarquia(EsquemaId, Clave, Nombre, Nivel) AS ( ");
				consulta.append("Select  Esquema.EsquemaId, Esquema.Clave, Esquema.Nombre, Nivel ");
				consulta.append("from Esquema ");
				consulta.append("where Esquema.Tipo = " + Tipo.value + " and Esquema.Nivel = 0 ");
				consulta.append("UNION ALL ");
				consulta.append("SELECT Esquema.EsquemaId, Esquema.Clave, Esquema.Nombre, Esquema.Nivel ");
				consulta.append("FROM esquema JOIN Jerarquia ON esquema.EsquemaIdPadre=Jerarquia.EsquemaId ");
				consulta.append("where Esquema.Tipo =  " + Tipo.value + " ");
				consulta.append("ORDER BY 2 DESC ");
				consulta.append(") ");
				consulta.append("SELECT  CASE WHEN Nivel >1 THEN  substr('            ',1,nivel-1*4) ELSE '' END || Clave as Clave, Nombre FROM Jerarquia WHERE Nivel >0; ");*/

				consulta.append("Select  distinct CASE WHEN b.Nivel >1 THEN  substr('                      ',1,((b.nivel-1)*4)) ELSE '' END || b.Clave as Clave,  b.Nombre as Nombre,");
				consulta.append("b.EsquemaIdPadre as EsquemaIdPadre, b.Nivel as Nivel, b.EsquemaId as EsquemaId, ");
				consulta.append("(Select  count(*) from Esquema a ");
				consulta.append("where a.Tipo = 2 and a.Nivel >0 and a.Nivel||CASE WHEN a.Nivel >1 THEN  substr('          ',1,a.nivel*4) ELSE '' END || a.EsquemaID< b.Nivel||CASE WHEN b.Nivel >1 THEN  substr('          ',1,b.nivel*4) ELSE '' END || b.EsquemaID ");
				consulta.append("order by a.Nivel||CASE WHEN a.Nivel >1 THEN  substr('          ',1,a.nivel*4) ELSE '' END || a.EsquemaID) as indice ");
				consulta.append("from Esquema b ");
                if (filtro.length()>0) {
                    consulta.append("inner join ProductoEsquema pe on pe.EsquemaID = b.EsquemaID ");
                    consulta.append("inner join Producto PRO on pe.ProductoClave = PRO.ProductoClave ");
                }
				consulta.append("where b.Tipo = 2 and b.Nivel >0 ");
                if (filtro.length()>0){
                    consulta.append(" and " + filtro);
                }
				consulta.append("order by indice , Clave ");
				ISetDatos datos  = BDVend.consultar(consulta.toString());
				
				SortedMap<String, Esquema> tm = new TreeMap<String, Esquema>();
				HashMap<String, String> hm = new HashMap<String, String>();
				while (datos.moveToNext())
				{
					hm.put(datos.getString("EsquemaId"), datos.getString("Nombre") + datos.getString("EsquemaId"));
								
					Esquema esq = new Esquema();
					esq.EsquemaId = datos.getString("EsquemaId");
					esq.Clave = datos.getString("Clave");
					esq.Nombre = datos.getString("Nombre");
					if (datos.getInt("Nivel") == 1){
						tm.put(datos.getString("Nombre") + datos.getString("EsquemaId"), esq);
					}else{
						if (hm.containsKey(datos.getString("EsquemaIdPadre"))|| filtro.length()>0){
							tm.put(hm.get(datos.getString("EsquemaIdPadre")) + "." + datos.getString("Nombre") + datos.getString("EsquemaId"), esq);
							hm.put(datos.getString("EsquemaId"), hm.get(datos.getString("EsquemaIdPadre")) + "." + datos.getString("Nombre") + datos.getString("EsquemaId"));
						}
					}
				}
				datos.close();
				hm.clear();
				hm = null;

				return tm;
		}

		public static String obtenerIdEsquemaPadre(String sEsquemaId)
		{
			try
			{
				return BDVend.bd.ejecutarEscalar("SELECT EsquemaIdPadre FROM Esquema WHERE EsquemaId = '" + sEsquemaId + "'");
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

		public static Esquema obtenerEsquemaPorClaveNombre(String ClaveONombre, String Tipo) throws Exception
		{
			ISetDatos setDatos = BDVend.consultar(Esquema.class, new String[] {}, "(UPPER(Clave) = UPPER(?) or UPPER(Nombre) = UPPER(?)) and Tipo = ?", new Object[]
			{ ClaveONombre, ClaveONombre, Tipo });
			Esquema esquema = null;
			if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0))
				esquema = (Esquema) BDVend.instanciar(Esquema.class, setDatos);
			return esquema;
		}

		public static ISetDatos obtenerEsquemasConPadre(ServicesCentral.TiposEsquemas Tipo) throws Exception
		{
			return BDVend.getBD().consultar("SELECT EsquemaId, EsquemaIdPadre FROM Esquema WHERE Tipo = " + Tipo.value);
		}
	}

	public static final class ConsultasClienteEsquema
	{
		public static ISetDatos obtenerIdEsquemaCte(String ClienteClave)
		{
			try
			{
				return BDVend.consultar("SELECT EsquemaId FROM ClienteEsquema WHERE ClienteClave = '" + ClienteClave + "'");
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}

		}

		/*
		 * public static ISetDatos obtenerIdEsquemasCtePPE(String ClienteClave){
		 * 
		 * }
		 */

	}

	public static final class ConsultasProductoEsquema
	{
		public static ISetDatos obtenerIdEsquemaProducto(String ProductoClave)
		{
			try
			{
				return BDVend.consultar("SELECT EsquemaId FROM ProductoEsquema WHERE ProductoClave = '" + ProductoClave + "'");
				// return
				// BDVend.consultar("SELECT EsquemaId FROM ProductoEsquemaEsquema WHERE ClienteClave = '"+ProductoClave+"'");
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}

		}

		public static ISetDatos obtenerIdEsquemaProductoPri() throws Exception
		{
			return BDVend.consultar("SELECT DISTINCT EsquemaID FROM ProductoPrioritarioEsq");
		}
		
		public static boolean productoEsquemaValido(String productoClave, String moduloEsquemas )throws Exception
		{
			
			ISetDatos dtEsquema = BDVend.consultar("Select * from ProductoEsquema where ProductoClave='" + productoClave + "' and EsquemaID in(" + moduloEsquemas + ")");
			boolean res = false;
			
			if (dtEsquema.getCount()>0){
				res = true;				
			}
			dtEsquema.close();
			return res;
		}


	}

	public static final class ConsultasProducto
	{

		public static Producto obtenerProducto(String ProductoClave) throws Exception
		{
			Producto oProducto = new Producto();
			oProducto.ProductoClave = ProductoClave;
			BDVend.recuperar(oProducto);
			return oProducto;
		}

		public static Producto[] obtenerProductosConPromocion(String EsquemasCliente, String ModuloMovDetalleClave)
		{
			try
			{

				// String fechaactualformat =
				// Generales.getFormatoFecha(Generales.getFechaActual(),"yyyy-MM-dd");
				String Consult = "select distinct PRP.ProductoClave, PRO.Nombre" + " from Promocion PRM" + " inner join PromocionModulo PMD on PRM.PromocionClave = PMD.PromocionClave and PMD.ModuloMovDetalleClave = '" + ModuloMovDetalleClave + "' and PMD.TipoEstado = 1" + " inner join PromocionProducto PRP on PRM.PromocionClave = PRP.PromocionClave" + " inner join Producto PRO on PRP.ProductoClave = PRO.ProductoClave and PRO.TipoFase = 1" + " left join PromocionDetalle PDT on PRP.PromocionClave = PDT.PromocionClave and PDT.TipoEstado = 1" + " inner join ProductoDetalle PRD on PRP.ProductoClave = PRD.ProductoClave and PRD.ProductoClave = PRD.ProductoDetClave" + " where PRM.TipoEstado = 1 and PRP.TipoEstado = 1 and DATETIME('now') between FechaInicial and FechaFinal" + " and ((PRM.Tipo in (2,4) and PDT.EsquemaId in (" + EsquemasCliente + ")) or PRM.Tipo = 1) ";

				ISetDatos datos = BDVend.consultar(Consult);
				Producto[] aProductos = new Producto[datos.getCount()];
				int i = 0;
				while (datos.moveToNext())
				{
					aProductos[i] = new Producto();
					aProductos[i].ProductoClave = datos.getString("ProductoClave");
					aProductos[i].Nombre = datos.getString("Nombre");

					i++;
				}
				datos.close();
				return aProductos;

			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}

		}

		public static ISetDatos obtenerUnidadesProducto(String productoClave, String listaPrecios) throws Exception
		{
			StringBuilder consulta = new StringBuilder();

			consulta.append("SELECT distinct ProductoDetalle.PRUTipoUnidad as _id, ProductoDetalle.PRUTipoUnidad, ProductoDetalle.Factor FROM ProductoDetalle ");
			consulta.append("INNER JOIN ProductoUnidad ON ProductoUnidad.ProductoClave = ProductoDetalle.ProductoClave AND ProductoUnidad.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad and ProductoUnidad.TipoEstado = 1 ");
			consulta.append("AND ProductoDetalle.ProductoDetClave = '" + productoClave + "' AND ProductoDetalle.Productoclave='" + productoClave + "' ");
			if (listaPrecios != null && listaPrecios.length()>0)
			{
				consulta.append("LEFT JOIN PrecioProductoVig PPV on PPV.ProductoClave = ProductoDetalle.ProductoClave and PPV.ProductoClave = ProductoDetalle.ProductoDetClave and PPV.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad and PPV.PrecioClave in(" + listaPrecios + ") and ");
				consulta.append("DATETIME('now') between PPV.PPVFechaInicio and PPV.FechaFin order by Case when PPV.PrecioClave is null Then 1 Else 0 End, ProductoDetalle.Factor ");
			}
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerUnidadesProductoDifen(String productoClave, int tipoUnidad) throws Exception
		{
			StringBuilder consulta = new StringBuilder();

			consulta.append("SELECT ProductoDetalle.PRUTipoUnidad as _id, ProductoDetalle.PRUTipoUnidad, ProductoDetalle.Factor FROM ProductoDetalle ");
			consulta.append("INNER JOIN ProductoUnidad ON ProductoUnidad.ProductoClave = ProductoDetalle.ProductoClave AND ProductoUnidad.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad ");
			consulta.append("AND ProductoDetalle.ProductoDetClave = '" + productoClave + "' AND ProductoDetalle.Productoclave='" + productoClave + "' ");
			consulta.append("Where ProductoDetalle.PRUTipoUnidad = '" + tipoUnidad + "' ");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerTransDetalleid(String TransPordID) throws Exception
		{
			StringBuilder consulta = new StringBuilder();

			consulta.append("Select TransProdDetalleID From TransProdDetalle Where TransProdID='" + TransPordID + "'");

			return BDVend.consultar(consulta.toString());
		}

		public static int obtenerUnidadMinima(String productoClave) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select PRUTipoUnidad ");
			consulta.append("from ProductoDetalle ");
			consulta.append("where ProductoClave = ProductoDetClave and ProductoClave = '" + productoClave + "' ");
			consulta.append("order by Factor ");
			consulta.append("limit 1 ");

			return BDVend.bd.ejecutarEscalarInteger(consulta.toString());
		}

		public static Producto obtenerProductoIdentico(String cadenaBusqueda) throws Exception
		{
			ISetDatos setDatos = BDVend.consultar(Producto.class, new String[] {}, "(UPPER(ProductoClave) = UPPER(?) or UPPER(Id) = UPPER(?))", new Object[]
			{ cadenaBusqueda, cadenaBusqueda });
			Producto producto = null;
			if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0))
			{
				producto = (Producto) BDVend.instanciar(Producto.class, setDatos);
				setDatos.close();
				return producto;
			}
			setDatos.close();
			return null;
		}


		public static ISetDatos buscarCodigoBarras(String codigoBarras, String listasPrecios) throws Exception
		{
			StringBuilder consulta = new StringBuilder();

			consulta.append("SELECT distinct ProductoDetalle.PRUTipoUnidad as _id, ProductoDetalle.PRUTipoUnidad, ProductoDetalle.Factor, ProductoDetalle.ProductoClave FROM ProductoDetalle ");
			consulta.append("INNER JOIN ProductoUnidad ON ProductoUnidad.ProductoClave = ProductoDetalle.ProductoClave AND ProductoUnidad.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad and ProductoUnidad.ProductoClave = ProductoDetalle.ProductoDetClave ");
			consulta.append("AND ProductoUnidad.CodigoBarras = '" + codigoBarras + "' AND ProductoUnidad.TipoEstado = 1 ");
			if (listasPrecios != null && listasPrecios.length()>0)
			{
				consulta.append("LEFT JOIN PrecioProductoVig PPV on PPV.ProductoClave = ProductoDetalle.ProductoClave and PPV.ProductoClave = ProductoDetalle.ProductoDetClave and PPV.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad and PPV.PrecioClave in(" + listasPrecios + ") and ");
				consulta.append("DATETIME('now') between PPV.PPVFechaInicio and PPV.FechaFin order by Case when PPV.PrecioClave is null Then 1 Else 0 End, ProductoDetalle.Factor ");
			}
			return BDVend.consultar(consulta.toString());
		}

		public static Cursor obtenerProductosExistencia(String filtro, String listasPrecios, boolean filtrarProductos, String transProdIds, int tipoTransProd, boolean validarExistencia, int tipoMovimiento, String esquemasModulo, int ubicacionExistencia) throws Exception
		{

			ArrayList<Cursor> cursores = new ArrayList<Cursor>();
			int limit = 0;
			int rows = 100000;

			boolean aplicarFiltrosPrecio = filtrarProductos;
			boolean aplicarFiltrosExistencia = filtrarProductos;
			while (limit + 6000 < rows)
			{
				StringBuilder consulta = new StringBuilder();

				//if (tipoTransProd == TiposTransProd.CAMBIOS || tipoTransProd == TiposTransProd.DEVOLUCIONES_CLIENTE || tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES || tipoTransProd == TiposTransProd.MOV_SIN_INV_SV || tipoTransProd == TiposTransProd.DESCARGAS)
				if (tipoTransProd == TiposTransProd.CAMBIOS || tipoTransProd == TiposTransProd.DEVOLUCIONES_CLIENTE || tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES || tipoTransProd == TiposTransProd.MOV_SIN_INV_SV || tipoTransProd == TiposTransProd.DESCARGAS || tipoTransProd == TiposTransProd.CARGAS)
				{
					aplicarFiltrosPrecio = false;
					if (tipoMovimiento ==TiposMovimientos.ENTRADA ){
						aplicarFiltrosExistencia = false;
					}else{
						aplicarFiltrosExistencia = validarExistencia;						
					}
				}else if (tipoTransProd == TiposTransProd.MOV_SIN_INV_EV){
					aplicarFiltrosExistencia = false;
				}
				if (tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES)
					consulta.append("select distinct PRO.ProductoClave as _id, PRO.DecimalProducto, PRO.ProductoClave,PRO.Nombre,PRO.NombreLargo,case when PRO.Id is null then '' else PRO.Id end as Id,case when INV.Disponible is null then 0 else (INV.NoDisponible)/PDE.Factor end as Existencia, ");
				else if (tipoTransProd == TiposTransProd.NO_DEFINIDO && ubicacionExistencia != 0){
					String ubicacion = "";
					if(ubicacionExistencia == 1){
						ubicacion = "INV.Disponible";
					}else if (ubicacionExistencia == 2){
						ubicacion = "INV.NoDisponible";
					}
					consulta.append("select distinct PRO.ProductoClave as _id, PRO.DecimalProducto, PRO.ProductoClave,PRO.Nombre,PRO.NombreLargo,case when PRO.Id is null then '' else PRO.Id end as Id,case when "+ubicacion+" is null then 0 else ("+ubicacion+")/PDE.Factor end as Existencia, ");	
				}
				else
					consulta.append("select distinct PRO.ProductoClave as _id, PRO.DecimalProducto, PRO.ProductoClave,PRO.Nombre,PRO.NombreLargo,case when PRO.Id is null then '' else PRO.Id end as Id,case when INV.Disponible is null then 0 else (INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido)/PDE.Factor end as Existencia, ");
				consulta.append("PRU.PRUTipoUnidad as Unidad, ");
				if (!listasPrecios.equals(""))
				{
					//consulta.append("case when PPV.Precio is null then 0 else PPV.Precio end as Precio");
					consulta.append("PPV.Precio as Precio,PPV.PrecioSugerido, PPV.Precioclave as PrecioClave ");
				}
				else
				{
					consulta.append("null as Precio,null as PrecioSugerido, null as PrecioClave ");
				}
				consulta.append(", 0 as checked, 0 as Cantidad from producto PRO inner join productounidad PRU on PRO.ProductoClave = PRU.ProductoClave and PRU.TipoEstado = 1 ");
				consulta.append("inner join ProductoEsquema PES on PES.ProductoClave = PRO.ProductoClave inner join ProductoDetalle PDE on PRO.ProductoClave = PDE.ProductoClave and PRU.PRUTipoUnidad = PDE.PRUTipoUnidad and PRO.ProductoClave = PDE.ProductoDetClave and PDE.Factor= ");
				consulta.append("(Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave in (" + listasPrecios + "))");
				//consulta.append((aplicarFiltrosPrecio ? "(Select min(PDE2.factor) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave = '" + PrecioClave + "')" : "1 "));
				consulta.append("left join Inventario INV on PRO.ProductoClave = INV.ProductoClave AND INV.AlmacenID = '" + ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID + "'");
				if (!listasPrecios.equals(""))
				{
					consulta.append("left join PrecioProductoVig PPV on PPV.ProductoClave = PRO.ProductoClave and PPV.PRUTipoUnidad = PRU.PRUTipoUnidad ");
					if (listasPrecios.contains(",")){ //Si la cadena contiene mas de una lista de precios
						consulta.append(" and PPV.PrecioClave = (Select  PRE2.PrecioClave from PrecioProductoVig PPV3 inner join Precio PRE2 on PRE2.PrecioClave = PPV3.PrecioClave where  PPV3.ProductoClave = PRO.ProductoClave and PPV3.PRUTipoUnidad = PRU.PRUTipoUnidad and PPV3.PrecioClave in(" + listasPrecios + ")  order by PRE2.Jerarquia asc LIMIT 1 ) ");
					}
				}
				consulta.append("left join TransProdDetalle TPD on TPD.TransProdId in(" + transProdIds + ") and TPD.ProductoClave = PRO.ProductoClave ");

				if (!listasPrecios.equals(""))
				{
					if (!aplicarFiltrosPrecio)
					{
						consulta.append("where ((PPV.PrecioClave is null) OR (PPV.PrecioClave in (" + listasPrecios + ") AND '" + Generales.getFechaHoraActualStr("yyyy-MM-dd HH:mm:ss") + "' BETWEEN  PPV.PPVFechaInicio AND PPV.FechaFin)) ");
					}
					else
					{
						consulta.append("where PPV.PrecioClave in (" + listasPrecios + ") AND '" + Generales.getFechaHoraActualStr("yyyy-MM-dd HH:mm:ss") + "' BETWEEN  PPV.PPVFechaInicio AND PPV.FechaFin ");
					}
				}

				filtro += (filtro.length() > 0 ? "AND" : "") + " TPD.TransProdID is null ";

				consulta.append((listasPrecios.equals("") ? " WHERE " : " AND ") + filtro);
				
				if (esquemasModulo.length() > 0){
					consulta.append(" AND PES.EsquemaID in(" + esquemasModulo  + ")");
				}

                if(tipoTransProd == TiposTransProd.DEVOLUCIONES_CLIENTE &&
						((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("RecoleccionEnvase").toString().equalsIgnoreCase("1") &&
						Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.PREVENTA){
                    consulta.append(" AND PRO.Contenido = 1 ");
                }

				if (aplicarFiltrosExistencia && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.PREVENTA)
					if (tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES)
						consulta.append(" GROUP BY PRO.ProductoClave HAVING ((INV.NoDisponible)/PDE.Factor)>0 ");
					else
						consulta.append(" GROUP BY PRO.ProductoClave HAVING ((INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido)/PDE.Factor)>0 ");
				if (aplicarFiltrosPrecio && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
					consulta.append(" AND not PPV.Precio is null ");

				if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("OrdenBusqProducto").length()>0){
					consulta.append("ORDER BY " + ((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("OrdenBusqProducto") );
				}else{
					consulta.append("ORDER BY PRO.ProductoClave ");
				}
				
				consulta.append(" LIMIT " + limit + ",6000");
				ISetDatos datos = BDVend.consultar(consulta.toString());

				// NO FUNCIONA, se congela en el getCount
				if (datos.moveToFirst())
				{ // si obtiene registros agregarlo al array		
					cursores.add((Cursor) datos.getOriginal());
					if (datos.getCount() < 6000) // si la cantidad de registros
													// es menor que el limit,
													// salir del ciclo
						break;
				}
				else
					 //sino terminar el ciclo, ya no hay registros
					break;
				limit += 6000;
				datos.close();
			}

			MergeCursor productos = null;
			if (cursores.size() > 0)
			{
				productos = new MergeCursor(cursores.toArray(new Cursor[cursores.size()]));
				Log.d("BusquedaProductos", "Productos encontrados: " + productos.getCount());
			}

			return productos;

		}

		public static float obtenerFactor(String ProductoClave, int TipoUnidad) throws Exception
		{
			float resultado = 0;
			ISetDatos datos = BDVend.consultar("SELECT Factor FROM ProductoDetalle WHERE ProductoClave = '" + ProductoClave + "' AND ProductoDetClave = '" + ProductoClave + "' AND PRUTipoUnidad = " + TipoUnidad);
			if (datos.getCount() > 0)
			{
				datos.moveToNext();
				resultado = datos.getFloat("Factor");
			}
			datos.close();
			return resultado;
		}

        public static float obtenerCantidadProduccion(String ProductoClave) throws Exception
        {
            float resultado = 0;
            ISetDatos datos = BDVend.consultar("SELECT CantidadProduccion FROM Producto WHERE ProductoClave = '" + ProductoClave + "' ");
            if (datos.getCount() > 0)
            {
                datos.moveToNext();
                resultado = datos.getFloat("CantidadProduccion");
            }
            datos.close();
            return resultado;
        }

		public static ISetDatos obtenerProductoDetalle(String productoClave, Integer tipoUnidad) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT ProductoDetalle.ProductoClave, ProductoDetalle.ProductoDetClave, ProductoDetalle.Factor FROM ProductoDetalle ");
			consulta.append("WHERE ProductoDetalle.ProductoClave='" + productoClave + "' and ProductoDetalle.PRUTipoUnidad=" + tipoUnidad);
			return BDVend.consultar(consulta.toString());
		}
		
		public static ProductoCalculadora obtenerProductoCalculaPorKilo(String productoClave, int unidad) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT P.ProductoClave, PU.PRUTipoUnidad, PU.KgLts, PV.Precio FROM Producto as P ");
			consulta.append("INNER JOIN ProductoUnidad as PU ON PU.ProductoClave = P.ProductoClave ");
			consulta.append("INNER JOIN PrecioProductoVig as PV ON PV.ProductoClave = P.ProductoClave ");
			consulta.append("WHERE P.ProductoClave='" + productoClave + "' and PU.PRUTipoUnidad=" + unidad);
			ISetDatos datos = BDVend.consultar(consulta.toString());
			ProductoCalculadora  producto = null;
			if(datos.moveToNext()){
				producto = new ProductoCalculadora();
				producto.kgLitros = datos.getFloat("KgLts");
				producto.productoClave = datos.getString("ProductoClave");
				producto.PRUtipoUnidad = datos.getInt("PRUTipoUnidad");
				producto.precioProductoVig = datos.getFloat("Precio");
			}
			datos.close();
			return producto;
		}
		
		public static boolean validarProductoEnvase (String productoClave) throws Exception
		{
			ISetDatos producto = BDVend.consultar("Select * from Producto where ProductoClave = '"+productoClave+"'");
			if(producto.moveToFirst())
			{
				Log.i(null,"Contenido: "+producto.getInt("Contenido")+" Venta: "+producto.getInt("Venta"));
			  if(producto.getInt("Contenido") == 0 && producto.getInt("Venta") == 0)
			  {
				  return false;
			  }
			}
			
			return true;
		}

        public static Short obtenerClasificacionProducto(String productoClave) throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select ifnull(ESQ.Clasificacion,0) as Clasificacion ");
            consulta.append("from ProductoEsquema PRE ");
            consulta.append("inner join Esquema ESQ on PRE.EsquemaID = ESQ.EsquemaID ");
            consulta.append("where PRE.ProductoClave = '" + productoClave + "' ");
            consulta.append("limit 1 ");

            return Short.parseShort(BDVend.bd.ejecutarEscalar(consulta.toString()));
        }
	}

	public static final class ConsultasPrecioClienteEsquema
	{

		public static ISetDatos obtenerIdEsquemaCte(String ModuloMovDetalleClave)
		{
			try
			{
				return BDVend.consultar("SELECT EsquemaID, ModuloMovDetalleClave, PrecioClienteEsquema.PrecioClave FROM PrecioClienteEsquema inner join Precio on Precio.PrecioCLave = PrecioClienteEsquema.PrecioClave WHERE ModuloMovDetalleClave='" + ModuloMovDetalleClave + "' and Precio.TipoEstado = 1");
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}

		}

	}

	public static final class ConsultasPrecioProductoVig
	{
		public static Float obtenerPrecioMinimo(String listasPrecios,String ProductoClave, int PRUTipoUnidad) throws Exception{
			String precioMin;
			precioMin = BDVend.getBD().ejecutarEscalar("SELECT PrecioMinimo FROM PrecioProductoVig PPV inner join Precio PRE on PRE.PrecioClave = PPV.PrecioClave WHERE PPV.PrecioClave in("+ listasPrecios +") AND PPV.ProductoClave = '"+ProductoClave+"' AND PPV.PRUTipoUnidad = '"+PRUTipoUnidad+"' AND datetime('now') BETWEEN PPV.PPVFechaInicio AND PPV.FechaFin ORDER BY PRE.Jerarquia LIMIT 1 ");
			return Float.parseFloat(precioMin);
		}
		
		public static Float obtenerPrecioSugerido(String listasPrecios,String ProductoClave, int PRUTipoUnidad) throws Exception{
			String precioMin;
			precioMin = BDVend.getBD().ejecutarEscalar("SELECT PrecioSugerido FROM PrecioProductoVig PPV inner join Precio PRE on PRE.PrecioClave = PPV.PrecioClave WHERE PPV.PrecioClave in("+ listasPrecios +") AND PPV.ProductoClave = '"+ProductoClave+"' AND PPV.PRUTipoUnidad = '"+PRUTipoUnidad+"' AND datetime('now') BETWEEN PPV.PPVFechaInicio AND PPV.FechaFin ORDER BY PRE.Jerarquia LIMIT 1 ");
			return precioMin.isEmpty() ? 0 : Float.parseFloat(precioMin);
		}


		public static float obtenerPrecioProducto(String ProductoClave, short TipoUnidad, String listasPrecios, StringBuilder precioClave)
		{
			try
			{
				Date fechaActual = Generales.getFechaActual();
                float precio = -1;
				String Consulta = "SELECT PrecioProductoVig.Precio as Precio, Precio.PrecioClave as PrecioClave FROM PrecioProductoVig INNER JOIN Precio ON PrecioProductoVig.PrecioClave = Precio.PrecioClave";
				Consulta += " WHERE PrecioProductoVig.PrecioClave in(" + listasPrecios + ") AND '" + Generales.getUltimaHora(fechaActual) + "'>=PPVFechaInicio AND '" + Generales.getPrimerHora(fechaActual) + "'<=FechaFin  AND Precio.TipoEstado= 1 AND PrecioProductoVig.ProductoClave = '" + ProductoClave + "' and PrecioProductoVig.PRUTipoUnidad = " + Short.toString(TipoUnidad);
				Consulta += " ORDER BY Precio.Jerarquia LIMIT 1 ";

				ISetDatos res;
				res = BDVend.consultar(Consulta);
                if (res.moveToFirst()){
                    precioClave.append( res.getString("PrecioClave"));
                    precio = res.getFloat("Precio");
                }
                res.close();

				return precio;

			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				// return (Float) null;
				return -1;
			}

		}

	}

	public static final class ConsultasEncuesta
	{
		public static ISetDatos obtenerEncuestasCteNuevo() throws Exception
		{
			return BDVend.consultar("SELECT CENClave, Puntos, IniAplicacion, FinAplicacion FROM CENClienteNuevo");
		}
	}

	public static final class ConsultasImpresionTicket
	{
		public static ISetDatos obtenerEncabezado() throws Exception{
			return BDTerm.consultar("SELECT NombreEmpresa,Calle, RFC, Numero, Colonia, Ciudad, Region, Telefono FROM Configuracion");
		}

        public static ISetDatos obtenerEncabezado(String subEmpresaId) throws Exception{
            return BDVend.consultar("SELECT NombreEmpresa,Calle, RFC, Numero, Colonia, Ciudad, Region, Telefono FROM SubEmpresa where SubEmpresaID='" + subEmpresaId + "'");
        }

		public static ISetDatos obtenerTicketsConVisita(String lstTrpTipo, int tipoModulo, String clienteClave, String visitaClave, String diaClave)
		{
			try
			{
				StringBuilder sConsulta = new StringBuilder();

				sConsulta.append("Select TransProd.TransProdId as _Id, TransProd.Tipo as Tipo, 'TRPTIPO' as VARCodigo,'TRP' as TipoRecibo, TransProd.Folio as Folio, '' as DescTipo,strftime( '%d/%m/%Y', CASE WHEN TransProd.Tipo = 8 THEN TransProd.FechaFacturacion ELSE TransProd.FechaCaptura END) as Fecha, TransProd.Total as Total, TransProd.TipoFase as TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as DiaClave, TransProd.SubEmpresaID as SubEmpresaID, IFNull( TDF.TransProdId, 0) as FacElec ");
				sConsulta.append("From TransProd LEFT JOIN Visita ON TransProd.VisitaClave = Visita.VisitaClave LEFT JOIN TRPDatoFiscal TDF on TDF.TransProdId = TransProd.TransProdId   ");
				sConsulta.append("WHERE TransProd.Tipofase <> 0  ");
				sConsulta.append("AND TransProd.Tipo in (" + lstTrpTipo + ") ");
				sConsulta.append("AND Visita.ClienteClave='" + clienteClave + "' ");
				sConsulta.append("AND Visita.VisitaClave='" + visitaClave + "' ");
				sConsulta.append("AND Visita.DiaClave='" + diaClave + "'");
				if (tipoModulo == Enumeradores.TiposModulos.REPARTO)
				{
					sConsulta.append(" UNION ");
					sConsulta.append("Select TransProd.TransProdId as _Id, TransProd.Tipo as Tipo, 'TRPTIPO' as VARCodigo, 'TRP' as TipoRecibo, TransProd.Folio as Folio, '' as DescTipo, strftime( '%d/%m/%Y',CASE WHEN TransProd.Tipo = 8 THEN TransProd.FechaFacturacion ELSE TransProd.FechaCaptura END) as Fecha, TransProd.Total as Total, TransProd.TipoFase as TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as DiaClave, TransProd.SubEmpresaID as SubEmpresaID, 0 as FacElec ");
					sConsulta.append("From TransProd INNER JOIN Visita ON ");
					sConsulta.append("TransProd.VisitaClave1 = Visita.VisitaClave AND TransProd.DiaClave1 = Visita.DiaClave  ");
					sConsulta.append("WHERE Visita.ClienteClave='" + clienteClave + "' and TransProd.Tipofase <> 0 ");
				}
				sConsulta.append(" UNION ");
				sConsulta.append("select Abono.ABNId as _Id, 10 as Tipo, 'TRECIBO' as VARCodigo,  'ABN' as TipoRecibo, Abono.Folio as Folio ,'' as DescTipo, strftime( '%d/%m/%Y',FechaAbono) as Fecha, Abono.Total as Total, null as TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as DiaClave, '' as SubEmpresaID , 0 as FacElec ");
				sConsulta.append("from Abono inner join Visita on ");
				sConsulta.append("Abono.visitaclave=Visita.visitaclave ");
				sConsulta.append("where visita.clienteclave='" + clienteClave + "' ");
				sConsulta.append("and visita.diaclave='" + diaClave + "'");
                sConsulta.append(" UNION ");
                sConsulta.append("select IM.InventarioID as _Id, 101 as Tipo, 'TRECIBO' as VARCodigo,  'INV' as TipoRecibo, VIS.ClienteClave as Folio ,'' as DescTipo, strftime( '%d/%m/%Y',Dia.FechaCaptura) as Fecha, null as Total, null as TipoFase, ");
                sConsulta.append("VIS.ClienteClave as ClienteClave, VIS.DiaClave as DiaClave, '' as SubEmpresaID , 0 as FacElec ");
                sConsulta.append("from InventarioMercadeo IM ");
                sConsulta.append("inner join Visita VIS on IM.visitaclave=VIS.visitaclave and IM.diaclave=VIS.diaclave ");
                sConsulta.append("inner join Dia on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.append("where VIS.ClienteClave='" + clienteClave + "' ");
                sConsulta.append("and VIS.VisitaClave='" + visitaClave + "' ");
                sConsulta.append("and VIS.DiaClave='" + diaClave + "'");

				return BDVend.consultar(sConsulta.toString());
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

		public static ISetDatos obtenerTicketsSinVisita(String lstTrpTipo)
		{
			try
			{
				StringBuilder sConsulta = new StringBuilder();

				sConsulta.append("Select TransProd.TransProdId as Id, TransProd.Tipo, 'TRPTIPO' as VarCodigo, TransProd.Folio, CASE WHEN TransProd.Tipo = 8 THEN TransProd.FechaFacturacion ELSE TransProd.FechaCaptura END as Fecha, TransProd.Total, TransProd.TipoFase, Visita.ClienteClave, Visita.DiaClave, TransProd.SubEmpresaID ");
				sConsulta.append("From TransProd LEFT JOIN Visita ON TransProd.VisitaClave = Visita.VisitaClave  ");
				sConsulta.append("WHERE TransProd.Tipofase <> 0  ");
				sConsulta.append("AND TransProd.Tipo in (" + lstTrpTipo + ") ");

				return BDVend.consultar(sConsulta.toString());
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

		public static Recibo obtenerReciboPorTipoRecibo(short tipoRecibo, short vendedorTipoPapel, String[] byRefMsgError) throws Exception
		{
			ISetDatos setDatos = BDTerm.consultar(Recibo.class, new String[] {}, "Tipo Like ? and Predeterminado = 1 ", new Object[]
			{ tipoRecibo });
			Recibo recibo = null;

			if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0))
			{
				if (setDatos.getCount() == 1)
				{
					recibo = (Recibo) BDTerm.instanciar(Recibo.class, setDatos);
					setDatos.close();
					return recibo;
				}
				else
				{
					do
					{
						if (vendedorTipoPapel == setDatos.getShort(setDatos.getColumnIndex("TipoPapel")))
						{
							recibo = (Recibo) BDTerm.instanciar(Recibo.class, setDatos);
							setDatos.close();
							return recibo;
						}
					}
					while (setDatos.moveToNext());

					setDatos.close();
					byRefMsgError[0] = Mensajes.get("ME0838", ValoresReferencia.getDescripcion("TRECIBO", Short.toString(tipoRecibo)), ValoresReferencia.getDescripcion("TPAPEL", Short.toString(vendedorTipoPapel)));
					return null;

				}
			}else if(tipoRecibo >= 100){ //tickets amarrados
				recibo = new Recibo();
				recibo.Tipo = tipoRecibo;
				recibo.TipoPapel = ((Vendedor)Sesion.get(Campo.VendedorActual)).TipoModImp;
				return recibo;
			}

			byRefMsgError[0] = Mensajes.get("E0492", ValoresReferencia.getDescripcion("TRECIBO", Short.toString(tipoRecibo)));
			return null;
		}

		public static ConfiguracionRecibo obtenerConfiguracionReciboPorTipoRecibo(short tipoRecibo, String[] byRefMsgError) throws Exception
		{
			ISetDatos setDatos = BDTerm.consultar(ConfiguracionRecibo.class, new String[] {}, " TipoRecibo = ? and TipoEstado = 1 ", new Object[]
			{ tipoRecibo });
			ConfiguracionRecibo configuracionRecibo = null;
			if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0))
			{
				configuracionRecibo = (ConfiguracionRecibo) BDTerm.instanciar(ConfiguracionRecibo.class, setDatos);
				setDatos.close();
				return configuracionRecibo;
			}
			byRefMsgError[0] = Mensajes.get("E0492", ValoresReferencia.getDescripcion("TRECIBO", Short.toString(tipoRecibo)));
			return null;
		}

		public static ISetDatos obtenerCOTCampoPorCORId(String CORId)
		{
			try
			{
				return BDTerm.consultar("Select CORId,COTId,COCId,Nombre,Descripcion from COTCampo where CORId='" + CORId + "' ");
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

		public static ISetDatos obtenerCORTablaPorCORId(String CORId)
		{
			try
			{
				return BDTerm.consultar("select CORId,COTId,Nombre from CORTabla where CORId='" + CORId + "' ");
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

		public static ISetDatos obtenerRECEncabezadoPiePorRECId(String RECId, short tipo)
		{
			try
			{
				return BDTerm.consultar("Select * from RECEncabezadoPie where RECid='" + RECId + "' and Tipo=" + tipo + " order by Orden ");
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

		public static ISetDatos obtenerRECNotaPorRECId(String RECId, short tipo)
		{
			try
			{
				return BDTerm.consultar("Select Texto, RenglonBlanco, TipoAlineacion, TipoLetra from  RECNota where RECId='" + RECId + "' and Tipo=" + tipo + " order by Orden");
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

		public static String obtenerValorCampo(String id, String nombreCampo, String nombreTabla, short tipoRecibo, short tipoCampo) throws Exception
		{
			String valorRes = "";
			StringBuilder sb = new StringBuilder();

			boolean aplicaBDTerm = false;
			if (nombreTabla.equalsIgnoreCase("TransProd") && tipoRecibo == 10)
			{
				sb.append("Select " + nombreCampo + ", typeof(t." + nombreCampo + ")");
			}
			else
			{
				sb.append("Select " + nombreCampo + ", typeof(" + nombreCampo + ")");
			}

			sb.append(" from " + nombreTabla);
			if (nombreTabla.equalsIgnoreCase("TransProd"))
			{
				if (tipoRecibo == 10)
				{
					sb.append(" t inner join AbnTrp a on a.transprodid=t.transprodid where a.abnid='" + id + "'");
				}
				else
				{
					sb.append(" where TransProdId ='" + id + "'");
				}
			}
			else if (nombreTabla.equalsIgnoreCase("TRPDatoFiscal"))
			{
				sb.append(" where TransProdId = '" + id + "'");
			}
			else if (nombreTabla.equalsIgnoreCase("Abono"))
			{
				sb.append(" where ABNId='" + id + "'");
			}
			else if (nombreTabla.equalsIgnoreCase("Cliente") || nombreTabla.equalsIgnoreCase("ClienteDomicilio"))
			{
				sb.append(" where ClienteClave='" + id + "'");
			}
			else if (nombreTabla.equalsIgnoreCase("SubEmpresa"))
			{
				sb.append(" where SubEmpresaID='" + id + "'");
			}
			else if (nombreTabla.equalsIgnoreCase("Preliquidacion"))
			{
				sb.append(" where PLIId='" + id + "'");
			}
			else if (nombreTabla.equalsIgnoreCase("Configuracion"))
			{
				aplicaBDTerm = true;
			}

			if (aplicaBDTerm)
			{
				valorRes = BDTerm.getBD().ejecutarEscalar(sb.toString());
			}
			else
			{
				if (tipoCampo == 4)
				{
					Date fecha = BDVend.getBD().ejecutarEscalarDate(sb.toString());
					valorRes = Generales.getFormatoFecha(fecha, "dd/MM/yyyy");

				}
				else
				{
					valorRes = BDVend.getBD().ejecutarEscalar(sb.toString());
				}
			}
			return valorRes;

		}

		public static String obtenerMaxOrdenXRECContenido(String RECId) throws Exception
		{
			String valorRes = "";

			valorRes = BDTerm.getBD().ejecutarEscalar("select IFNULL(max(ordenx),0)  from RECContenido where RECId='" + RECId + "'");

			return valorRes;
		}

		public static ISetDatos obtenerRECContenidoPorRECId(String RECId)
		{
			try
			{
				return BDTerm.consultar("Select * from  RECContenido where RECId='" + RECId + "' order by ordeny, ordenx ");
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

		public static String obtenerDiasCredito(String id) throws Exception
		{
			String valorRes = "";

			valorRes = BDTerm.getBD().ejecutarEscalar("Select datediff(day, FechaCaptura, FechaCobranza) as DiasCredito from TransProd where TransProdId = '" + id + "'");

			return valorRes;
		}

		public static int obtenerMaxOrdenXREODetalle(String RECId) throws Exception
		{
			String valorRes = "";

			valorRes = BDTerm.getBD().ejecutarEscalar("select max(ordenx) from REODetalle where RECId='" + RECId + "'");

			if (valorRes.equals(""))
			{
				return 0;
			}
			else
			{
				return Integer.parseInt(valorRes);
			}
		}

		public static ISetDatos obtenerREODetallePorRECId(String RECId)
		{
			try
			{
				return BDTerm.consultar("Select * from  REODetalle where RECId='" + RECId + "' order by ordeny, ordenx ");
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

		public static ISetDatos obtenerUnidadPrecioCantidad(String transProdId)
		{
			try
			{
				StringBuilder sConsulta = new StringBuilder();

				sConsulta.append("select TPD.TipoUnidad, TPD.Precio, sum(TPD.Cantidad * PRD.Factor) as CantidadProducto ");
				sConsulta.append("from TransProdDetalle TPD ");
				sConsulta.append("inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and TPD.TipoUnidad = PRD.PRUTipoUnidad ");
				sConsulta.append("where TPD.TransProdId = '" + transProdId + "' ");
				sConsulta.append("group by TPD.TipoUnidad, TPD.Precio ");
				sConsulta.append("order by TPD.TipoUnidad, TPD.Precio ");

				return BDVend.consultar(sConsulta.toString());
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

        public static ISetDatos obtenerTotalPiezas(String transProdId){
            try{
                StringBuilder sConsulta = new StringBuilder();

                sConsulta.append("select sum(TPD.Cantidad * PRD.Factor) as CantidadProducto ");
                sConsulta.append("from TransProdDetalle TPD ");
                sConsulta.append("inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and TPD.TipoUnidad = PRD.PRUTipoUnidad ");
                sConsulta.append("where TPD.TransProdId = '" + transProdId + "' ");

                return BDVend.consultar(sConsulta.toString());
            }catch (Exception ex){
                ex.printStackTrace();
                return null;
            }
        }

		public static ISetDatos obtenerDetalleRecibo(String id, short tipo, short tipoRecibo, String tabla, String campos, String campoLlave, String tablaOrden, String campoOrden, boolean agruparPorSubEmpresa, boolean seccionProdPromo)
		{
			try
			{
				StringBuilder consulta = new StringBuilder();
				if (tipo == 8)
				{	
					campos = campos.replace("TransProdDetalle.Subtotal", "SUM(TransProdDetalle.Subtotal) as Subtotal");
					campos = campos.replace("TransProdDetalle.Cantidad", "SUM(TransProdDetalle.Cantidad) as Cantidad");
					campos = campos.replace("TransProdDetalle.Impuesto", "SUM(TransProdDetalle.Impuesto) as Impuesto");
					campos = campos.replace("TransProdDetalle.Total", "SUM(TransProdDetalle.Total) as Total");
					consulta.append("Select ");
					consulta.append(campos);
					consulta.append(" from ");
					consulta.append(tabla);
					consulta.append(" inner join TransProd on TransProd.TransProdID = TransProdDetalle.TransProdID");
					consulta.append(" where TransProd.FacturaID = '").append(id).append("' ");
				}
				else if (tipoRecibo == 10 && tabla.toUpperCase().contains("TRANSPROD"))
				{
					tabla = tabla.toUpperCase().replace(",TRANSPROD", "");
					tabla = tabla.toUpperCase().replace("TRANSPROD,", "");
					consulta.append("Select ");
					consulta.append(campos);
					consulta.append(" from ");
					consulta.append(tabla);
					consulta.append(" left join abntrp on abntrp.abnid=abndetalle.abnid left join transprod on transprod.transprodid=abntrp.transprodid where abndetalle.abnid='" + id + "'");
				}
				else if (tipo == 24 && tabla.toUpperCase().contains("TRPTPD"))
				{
					// TODO Paula, implementar Recibo consignacion
				}
				else if (tipo == 1 || tipo == 24 || tipo == 19 || tipo == 21)
				{ // Pedido, Consignacion, Mov sin Inv s/Visita, MovSinInv
					// c/Visita
					campos = campos.toUpperCase().replace("TRANSPRODDETALLE.IMPORTE", "(TransProdDetalle.Total/TransProdDetalle.Cantidad) as importe ");
					consulta.append("Select ");
					consulta.append(campos);
					consulta.append(" from ");
					consulta.append(tabla);
					consulta.append(" where " + campoLlave + " = '" + id + "'");
					if(seccionProdPromo){
						consulta.append("and (promocion != 2 or promocion is null)");
					}
				}
				else
				{
					consulta.append("Select ");
					consulta.append(campos);
					consulta.append(" from ");
					consulta.append(tabla);
					consulta.append(" where " + campoLlave + " = '" + id + "'");
				}

				if (campos.toUpperCase().contains("PRODUCTO.NOMBRE") && !(campos.toUpperCase().contains("TRPTPD") && tipo == 24))
				{
					consulta.append(" and Producto.ProductoClave = TransProdDetalle.ProductoClave ");
				}
				
				/* Si es una factura consolidar el detalle */
				if(tipo == 8)
				{
					consulta.append("group by TransProdDetalle.ProductoClave, TransProdDetalle.TipoUnidad, TransProdDetalle.Precio ");
				}

				if (!tablaOrden.equals("") && !campoOrden.equals(""))
				{
					if (agruparPorSubEmpresa)
					{
						consulta.append("order by Producto.SubEmpresaId, " + tablaOrden + "." + campoOrden);
					}
					else
					{
						consulta.append("order by " + tablaOrden + "." + campoOrden);
					}
				}

				return BDVend.consultar(consulta.toString());
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}

		}

        public static  ISetDatos obtenerProductosPromo(String transprodId){
            try{
                StringBuilder consulta = new StringBuilder();
                consulta.append("select p.ProductoClave, p.Nombre, td.TipoUnidad, td.Cantidad, td.Precio, t.PCEPrecioClave ");
                consulta.append("from TransprodDetalle td ");
                consulta.append("inner join Producto p on td.ProductoClave=p.ProductoClave ");
                consulta.append("inner join Transprod t on td.TransprodId=t.TransprodId ");
                consulta.append("where td.TransProdId = '" + transprodId + "' and td.Promocion=2");
                return  BDVend.consultar(consulta.toString());
            }catch(Exception e){
                e.printStackTrace();
                return null;
            }
        }

	}

	public static final class ConsultarAseguramientoVisita
	{
		public static AseguramientoVisita obtenerAseguramientoPorVendedor(Vendedor vendedor) throws Exception
		{
			ISetDatos setDatos = BDVend.consultar(AseguramientoVisita.class, new String[] {}, "MCNClave Like ?", new Object[]
			{ vendedor.MCNClave });
			AseguramientoVisita aseguramiento = null;
			if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0))
				aseguramiento = (AseguramientoVisita) BDVend.instanciar(AseguramientoVisita.class, setDatos);
			setDatos.close();
			return aseguramiento;
		}
	}

	public static final class ConsultasVisita
	{
		public static ISetDatos obtenerVisitas(Dia dia, Cliente cliente) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT VisitaClave as _id, VisitaClave, '" + Mensajes.get("XVisita") + " ' || cast( Numero as text ) as Descripcion, strftime('" + Mensajes.get("XHoraInicio") + ": %H:%M:%S', FechaHoraInicial) as FechaHoraInicial, strftime('" + Mensajes.get("XHoraFin") + ": %H:%M:%S',FechaHoraFinal) as FechaHoraFinal FROM visita V2 ");
			consulta.append("where DiaClave = '" + dia.DiaClave + "' and ClienteClave = '" + cliente.ClienteClave + "' and (Enviado = 0 or Enviado is null)");
			return BDVend.consultar(consulta.toString());
		}

		public static boolean existenVisitas(String DiaClave, String ClienteClave) throws Exception
		{
			boolean resultado = false;
			ISetDatos datos = BDVend.consultar("select VisitaClave from Visita where DiaClave = '" + DiaClave + "' and ClienteClave = '" + ClienteClave + "'");
			if (datos.moveToNext())
			{
				resultado = true;
			}
			datos.close();
			return resultado;
		}

		public static int obtenerConsecutivo(Dia dia) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			int resultado = 0;
			consulta.append("SELECT MAX(Numero) AS UltimaVisita FROM Visita WHERE DiaClave='" + dia.DiaClave + "'");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if (datos.moveToNext())
			{
				resultado = datos.getInt(0) + 1;
			}
			datos.close();
			return resultado;
		}

		public static boolean hayMovimientos(String VisitaClave) throws Exception
		{
			boolean hayMovs = false;

			StringBuilder consulta = new StringBuilder();
			consulta.append("select count(*) as Cantidad from TransProd Where (VisitaClave ='" + VisitaClave + "' or VisitaClave1 ='" + VisitaClave + "') UNION ");
			consulta.append("select count(*) as Cantidad from Abono Where VisitaClave ='" + VisitaClave + "' UNION ");
			consulta.append("select count(*) as Cantidad from AbonoHist where VisitaClave = '" + VisitaClave + "' UNION ");
			consulta.append("select count(*) as Cantidad from AbonoProgramado Where VisitaClave ='" + VisitaClave + "' UNION ");
			consulta.append("select count(*) as Cantidad from Encuesta Where VisitaClave ='" + VisitaClave + "' UNION ");
			consulta.append("select count(*) as Cantidad from ImproductividadProd Where VisitaClave ='" + VisitaClave + "' UNION ");
			consulta.append("select count(*) as Cantidad from ImproductividadVenta Where VisitaClave ='" + VisitaClave + "' UNION ");
			consulta.append("select count(*) as Cantidad from MERDetalle Where VisitaClave ='" + VisitaClave + "' UNION ");
			consulta.append("select count(*) as Cantidad from Solicitud Where VisitaClave ='" + VisitaClave + "' UNION ");
			consulta.append("select count(*) as Cantidad from CLICAP Where VisitaClave ='" + VisitaClave + "' or  VisitaClave1 ='" + VisitaClave + "'");

			ISetDatos datos = BDVend.consultar(consulta.toString());

			while (datos.moveToNext())
			{
				if (datos.getInt("Cantidad") > 0)
				{
					hayMovs = true;
					break;
				}
			}

			datos.close();

			return hayMovs;
		}

        public static boolean existeVisitaPosterior(String visitaClave, String diaClave)throws Exception
        {
            boolean resultado = false;
            ISetDatos datos = BDVend.consultar("select * from Visita where FechaHoraInicial > (select FechaHoraInicial from Visita where VisitaClave = '" + visitaClave + "' and DiaClave = '" + diaClave + "')  and DiaClave = '" + diaClave + "' ");
            if (datos.moveToNext())
            {
                resultado = true;
            }
            datos.close();
            return resultado;
        }
	}

	public static final class ConsultasAgenda
	{
		public static Agenda obtenerAgendaPorDiaClienteRutaVendedor(String diaClave, String RUTClave, String vendedorId, String clienteClave) throws Exception
		{
			ISetDatos setDatos = BDVend.consultar(Agenda.class, new String[] {}, "DiaClave = ? and VendedorId = ? and RUTClave = ? and ClienteClave = ?", new Object[]
				{ diaClave, vendedorId, RUTClave, clienteClave });
			Agenda agenda = null;
			if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0))
				agenda = (Agenda) BDVend.instanciar(Agenda.class, setDatos);
			setDatos.close();
			return agenda;
		}

		public static Agenda obtenerAgendaPorDiaClienteRutaVendedor(Dia dia, Ruta ruta, Vendedor vendedor) throws Exception
		{
			ISetDatos setDatos = BDVend.consultar(Agenda.class, new String[] {}, "DiaClave = ? and VendedorId = ? and RUTClave = ? and ClienteClave = ?", new Object[]
			{ dia.DiaClave, vendedor.VendedorId, ruta.RUTClave });
			Agenda agenda = null;
			if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0))
				agenda = (Agenda) BDVend.instanciar(Agenda.class, setDatos);
			setDatos.close();
			return agenda;
		}
		
		public static Dia obtenerDiaClaveAgendaFechaCaptura() throws Exception{
			String fecha = Generales.getFormatoFecha(Generales.getFechaActual(), "yyyy-MM-dd HH:mm:ss");
			ISetDatos setDatos = BDVend.consultar("SELECT D.DiaClave, D.Referencia, D.FechaCaptura, D.FueraFrecuencia, D.Frecuencia FROM Agenda as A INNER JOIN Dia as D on A.DiaClave = D.DiaClave "+
												  "WHERE D.FechaCaptura = '"+ fecha +"' AND D.FueraFrecuencia = 0");
			Dia dia = null;
			if(setDatos.moveToNext()){
				dia = new Dia();
				dia.DiaClave = setDatos.getString(0);
				dia.Referencia = setDatos.getString(1);
				dia.FechaCaptura = setDatos.getDate(2);
				dia.FueraFrecuencia = setDatos.getBoolean(3);
				dia.Frecuencia = setDatos.getShort(4);
			}
			setDatos.close();
			return dia;
		}
	    
	}

	public static final class ConsultasActividades
	{
		@SuppressWarnings("deprecation")
		public static ModuloMov[] obtenerModulos(Vendedor vendedor, Activity actividad) throws Exception
		{
			ArrayList<ModuloMov> modulos = new ArrayList<ModuloMov>();
			StringBuilder consulta = new StringBuilder();
			consulta.append("select MOV.ModuloClave,MOV.ModuloMovClave,MOV.Nombre,MOV.TipoIndice,MOV.Orden,MOV.TipoEstado,MOV.Baja from Vendedor VEN inner join ModuloTerm MOD on VEN.ModuloClave = MOD.ModuloClave ");
			consulta.append("inner join ModuloMov MOV on MOD.ModuloClave = MOV.ModuloClave ");
			consulta.append("inner join ModuloMovDetalle MDE on MOV.ModuloClave = MDE.ModuloClave and MOV.ModuloMovClave = MDE.ModuloMovClave ");
			consulta.append("inner join MmdMcn MMD on MMD.ModuloMovDetalleClave = MDE.ModuloMovDetalleClave ");
			consulta.append("where VEN.VendedorID = '" + vendedor.VendedorId + "' AND MOV.TipoEstado = 1 AND MDE.TipoEstado = 1 group by MOV.Nombre order by MOV.Orden");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			actividad.startManagingCursor((Cursor) datos.getOriginal());
			while (datos.moveToNext())
			{
				ModuloMov mod = new ModuloMov(datos.getString(0), datos.getString(1), datos.getString(2), datos.getInt(3), datos.getInt(4), datos.getInt(5), datos.getInt(6));
				modulos.add(mod);
			}
			return modulos.toArray(new ModuloMov[modulos.size()]);
		}

		public static ModuloMovDetalle[] obtenerActividadesPorModulo(String modulomovclave, Vendedor vendedor) throws Exception
		{
			ArrayList<ModuloMovDetalle> actividades = new ArrayList<ModuloMovDetalle>();
			StringBuilder consulta = new StringBuilder();
			consulta.append("select MDE.ModuloMovDetalleClave,MDE.ModuloClave,MDE.ModuloMovClave,MDE.Nombre,MDE.TipoIndice,MDE.Orden,MDE.TipoTransProd,MDE.TipoPedido,MDE.TipoMovimiento,MDE.TipoEstado,MDE.Baja from Vendedor VEN inner join ModuloTerm MOD on VEN.ModuloClave = MOD.ModuloClave ");
			consulta.append("inner join ModuloMov MOV on MOD.ModuloClave = MOV.ModuloClave ");
			consulta.append("inner join ModuloMovDetalle MDE on MOV.ModuloClave = MDE.ModuloClave and MOV.ModuloMovClave = MDE.ModuloMovClave ");
			consulta.append("inner join MmdMcn MMD on MMD.ModuloMovDetalleClave = MDE.ModuloMovDetalleClave "); // obtener
																												// solo
																												// las
																												// actividades
																												// que
																												// tiene
																												// asignadas
			consulta.append("where VEN.VendedorID = '" + vendedor.VendedorId + "' and MOV.ModuloMovClave = '" + modulomovclave + "' AND MOV.TipoEstado = 1 AND MDE.TipoEstado = 1 order by MDE.Orden");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				ModuloMovDetalle detalle = new ModuloMovDetalle(datos.getString(0), datos.getString(1), datos.getString(2), datos.getString(3), datos.getInt(4), datos.getInt(5), datos.getInt(6), datos.getInt(7), datos.getInt(8), datos.getInt(9), datos.getInt(10));
				actividades.add(detalle);
			}
			datos.close();
			return actividades.toArray(new ModuloMovDetalle[actividades.size()]);
		}

		public static ModuloMovDetalle[] obtenerActividadesVisita(Vendedor vendedor) throws Exception
		{
			ArrayList<ModuloMovDetalle> actividades = new ArrayList<ModuloMovDetalle>();
			StringBuilder consulta = new StringBuilder();
			consulta.append("select MDE.ModuloMovDetalleClave,MDE.ModuloClave,MDE.ModuloMovClave,MDE.Nombre,MDE.TipoIndice,MDE.Orden,MDE.TipoTransProd,MDE.TipoPedido,MDE.TipoMovimiento,MDE.TipoEstado,MDE.Baja from Vendedor VEN inner join ModuloTerm MOD on VEN.ModuloClave = MOD.ModuloClave ");
			consulta.append("inner join ModuloMov MOV on MOD.ModuloClave = MOV.ModuloClave ");
			consulta.append("inner join ModuloMovDetalle MDE on MOV.ModuloClave = MDE.ModuloClave and MOV.ModuloMovClave = MDE.ModuloMovClave ");
			consulta.append("inner join MmdMcn MMD on MMD.ModuloMovDetalleClave = MDE.ModuloMovDetalleClave "); // obtener
																												// solo
																												// las
																												// actividades
																												// que
																												// tiene
																												// asignadas
			consulta.append("where VEN.VendedorID = '" + vendedor.VendedorId + "' AND MOV.TipoEstado = 1 AND MDE.TipoEstado = 1 order by MDE.Orden");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				ModuloMovDetalle detalle = new ModuloMovDetalle(datos.getString(0), datos.getString(1), datos.getString(2), datos.getString(3), datos.getInt(4), datos.getInt(5), datos.getInt(6), datos.getInt(7), datos.getInt(8), datos.getInt(9), datos.getInt(10));
				actividades.add(detalle);
			}
			datos.close();
			return actividades.toArray(new ModuloMovDetalle[actividades.size()]);
		}

		//		public static ArrayList<AtenderaMisClientes> obtenerAtenderaMisClientes(String Tipo) throws Exception
		//		{
		//			ArrayList<AtenderaMisClientes> ArrayAtenderaMisClientes = new ArrayList<AtenderaMisClientes>();
		//
		//			ISetDatos datos = BDVend.consultar("Select Descripcion, VAVClave From VAVDescripcion Where VARCodigo='" + Tipo + "'");
		//			while (datos.moveToNext())
		//			{
		//				AtenderaMisClientes mAtenderaMisClientes = new AtenderaMisClientes();
		//				mAtenderaMisClientes.setVAVClave(datos.getString(0));
		//				mAtenderaMisClientes.setDescripcion(datos.getString(1));
		//			}
		//			datos.close();
		//			return ArrayAtenderaMisClientes;
		//		}
		public static ModuloMovDetalle[] obtenerActividadesInventario(Vendedor vendedor, int TipoIndice) throws Exception
		{
			ArrayList<ModuloMovDetalle> actividades = new ArrayList<ModuloMovDetalle>();
			StringBuilder consulta = new StringBuilder();
			consulta.append("select ModuloMovDetalleClave, TipoIndice ");
			consulta.append("from   ModuloMovDetalle ");
			consulta.append("where  TipoIndice =" + TipoIndice); // obtener
			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				ModuloMovDetalle detalle = new ModuloMovDetalle(datos.getString(0), datos.getInt(1));
				actividades.add(detalle);
			}
			datos.close();
			return actividades.toArray(new ModuloMovDetalle[actividades.size()]);
		}

	}

	public static final class ConsultasVendedorJornada
	{

		public static VendedorJornada obtenerJornada(Vendedor vendedor, Dia dia) throws Exception
		{
			ISetDatos setDatos = BDVend.consultar(VendedorJornada.class, new String[] {}, "VendedorId = ? and DiaClave = ? ORDER BY MFechaHora DESC", new Object[]
			{ vendedor.VendedorId, dia.DiaClave });
			VendedorJornada vendedorJornada = null;
			if (setDatos != null && setDatos.moveToFirst() && setDatos.getCount() > 0)
				vendedorJornada = (VendedorJornada) BDVend.instanciar(VendedorJornada.class, setDatos);
			return vendedorJornada;
		}

		public static boolean todasLasJornadasCerradas() throws Exception{
			String Consulta = "select count(Dia.DiaClave) as TotalDIA, sum(case when not VEJ.FechaFinal is null then 1 else 0 end) as TotalVEJ from Dia ";
			Consulta += "left join VendedorJornada VEJ on Dia.DiaClave = VEJ.DiaClave where Dia.FueraFrecuencia = 0 ";

			ISetDatos datos = BDVend.consultar(Consulta.toString());

			int totalDia = 0;
			int totalVej = 0;
			if (datos.moveToFirst())
			{
				totalDia = datos.getInt("TotalDIA");
				totalVej = datos.getInt("TotalVEJ");
			}

			datos.close();

			return (totalDia == totalVej);

		}

        public static boolean JornadasAbiertas() throws Exception{
            String Consulta = "select count(*) as JornadasAbiertas ";
            Consulta += "from VendedorJornada VEJ ";
            Consulta += "where VEJ.FechaFinal is null ";

            ISetDatos datos = BDVend.consultar(Consulta.toString());

            int totalJornadasAbiertas = 0;

            if (datos.moveToFirst()){
                totalJornadasAbiertas = datos.getInt("JornadasAbiertas");
            }

            datos.close();

            return (totalJornadasAbiertas > 0);
        }

		public static VendedorJornada obtenerJornadaActual(Vendedor vendedor) throws Exception
		{
			ISetDatos setDatos = BDVend.consultar(VendedorJornada.class, new String[] {}, "FechaFinal IS NULL AND VendedorId = ? ORDER BY MFechaHora DESC", new Object[]
			{ vendedor.VendedorId });
			VendedorJornada vendedorJornada = null;
			if (setDatos != null && setDatos.moveToFirst() && setDatos.getCount() > 0)
				vendedorJornada = (VendedorJornada) BDVend.instanciar(VendedorJornada.class, setDatos);
            setDatos.close();
			return vendedorJornada;
		}

        public static VendedorJornada obtenerUltimaJornadaActual(Vendedor vendedor) throws Exception
        {
            ISetDatos setDatos = BDVend.consultar(VendedorJornada.class, new String[] {}, " VendedorId = ? ORDER BY MFechaHora DESC", new Object[]
                    { vendedor.VendedorId });
            VendedorJornada vendedorJornada = null;
            if (setDatos != null && setDatos.moveToFirst() && setDatos.getCount() > 0)
                vendedorJornada = (VendedorJornada) BDVend.instanciar(VendedorJornada.class, setDatos);
            setDatos.close();
            return vendedorJornada;
        }

		public static VendedorJornada obtenerJornadaSinFinalizar(Vendedor vendedor) throws Exception
		{
			ISetDatos setDatos = BDVend.consultar(VendedorJornada.class, new String[] {}, " FechaFinal IS NULL AND VendedorId = ? ORDER BY MFechaHora DESC", new Object[]
			{ vendedor.VendedorId });
			VendedorJornada vendedorJornada = null;
			if (setDatos != null && setDatos.moveToFirst() && setDatos.getCount() > 0)
				vendedorJornada = (VendedorJornada) BDVend.instanciar(VendedorJornada.class, setDatos);
			return vendedorJornada;
		}
		
		public static void eliminarJornadaSinAsignacionDeDia(Vendedor vendedor) throws Exception
		{
			BDVend.ejecutarComando("DELETE FROM VendedorJornada where DiaClave is null and FechaFinal is null ");
			BDVend.commit();
		}
		
		public static VendedorJornada obtenerUltimaJornada(Vendedor vendedor) throws Exception{
			ISetDatos setDatos = BDVend.consultar(VendedorJornada.class, new String[] {}, " VendedorId = ? ORDER BY VEJFechaInicial DESC LIMIT 1", new Object[]{vendedor.VendedorId} );
			VendedorJornada vendedorJornada = null;
			if (setDatos != null && setDatos.moveToFirst() && setDatos.getCount() > 0)
				vendedorJornada = (VendedorJornada) BDVend.instanciar(VendedorJornada.class, setDatos);
			return vendedorJornada;
		}
	} 

	public static final class ConsultasDescuentos
	{
		public static ISetDatos BuscarPorTransprod(String TransprodID) throws Exception
		{
			String Consula = "SELECT DesPor,Jerarquia,TipoCascada FROM TpdDes WHERE TransProdId = '" + TransprodID + "' group by DescuentoClave,DesPor,Jerarquia,TipoCascada ORDER BY Jerarquia ASC";

			return BDVend.consultar(Consula);

		}

		public static Descuento[] BuscarDescuentosCliente(String ClienteClave, Boolean EsNuevo) throws Exception
		{
			String Consulta = "SELECT Descuento.DescuentoClave, Descuento.Nombre, Descuento.Tipo, Descuento.PermiteCascada, Descuento.TipoAplicacion, Descuento.ValorAplicacion, ";
			Consulta += " Descuento.TipoValor, DESCliente.Jerarquia FROM Descuento INNER JOIN DESCliente ON Descuento.DescuentoClave = DESCliente.DescuentoClave";
			// Consulta +=" WHERE DESCliente.ClienteClave='" + ClienteClave +
			// "'";
			Consulta += " WHERE DESCliente.ClienteClave=?";
			if (EsNuevo)
			{
				Consulta += "AND Descuento.TipoEstado=1 AND DESCliente.TipoEstado=1 AND Descuento.Baja<>1  ";
			}
			Consulta += " ORDER BY DESCliente.Jerarquia ";

			ArrayList<Descuento> descuentos = new ArrayList<Descuento>();

			// ISetDatos datos = BDVend.consultar(Consulta);
			ISetDatos datos = BDVend.consultar(Consulta, new Object[]
			{ ClienteClave });

			while (datos.moveToNext())
			{
				Descuento des = new Descuento();
				des.DescuentoClave = datos.getString("DescuentoClave");
				des.Nombre = datos.getString("Nombre");
				des.Tipo = datos.getShort("Tipo");
				des.PermiteCascada = datos.getInt("PermiteCascada");
				des.TipoAplicacion = datos.getShort("TipoAplicacion");
				des.ValorAplicacion = datos.getFloat("ValorAplicacion");
				des.TipoValor = datos.getShort("TipoValor");
				des.Jerarquia = datos.getInt("Jerarquia");

				descuentos.add(des);
			}

			datos.close();
			return descuentos.toArray(new Descuento[descuentos.size()]);

		}

		public static Descuento[] BuscarDescuentosClientePorEsquema(String ClienteClave, String Esquemas, Boolean EsNuevo) throws Exception
		{
			String Consulta = "SELECT Descuento.DescuentoClave, Descuento.Nombre, Descuento.Tipo, Descuento.PermiteCascada, Descuento.TipoAplicacion, Descuento.ValorAplicacion,  ";
			Consulta += " Descuento.TipoValor, DESDetalle.Jerarquia, DESDetalle.EsquemaID FROM Descuento INNER JOIN DESDetalle ON Descuento.DescuentoClave = DESDetalle.DescuentoClave Where ";

			if (EsNuevo)
			{
				Consulta += "  Descuento.TipoEstado=1 AND DESDetalle.TipoEstado=1 AND Descuento.Baja<>1  ";
				Consulta += " AND DESDetalle.EsquemaID in (" + Esquemas + ") and";
			}
			Consulta += "  DESDetalle.EsquemaID in (" + Esquemas + ")";
			Consulta += " ORDER BY DESDetalle.Jerarquia ";

			ArrayList<Descuento> descuentos = new ArrayList<Descuento>();

			ISetDatos datos = BDVend.consultar(Consulta);
			while (datos.moveToNext())
			{
				Descuento des = new Descuento();
				des.DescuentoClave = datos.getString("DescuentoClave");
				des.Nombre = datos.getString("Nombre");
				des.Tipo = datos.getShort("Tipo");
				des.PermiteCascada = datos.getInt("PermiteCascada");
				des.TipoAplicacion = datos.getShort("TipoAplicacion");
				des.ValorAplicacion = datos.getFloat("ValorAplicacion");
				des.TipoValor = datos.getShort("TipoValor");
				des.Jerarquia = datos.getInt("Jerarquia");

				descuentos.add(des);
			}
			datos.close();
			return descuentos.toArray(new Descuento[descuentos.size()]);

		}

		public static Descuento BuscarDescuentosProducto(String ProductoClave) throws Exception
		{
			String Consulta = "SELECT Descuento.DescuentoClave, Descuento.Nombre, Descuento.Tipo, Descuento.PermiteCascada, Descuento.TipoAplicacion, Descuento.ValorAplicacion, Descuento.TipoValor FROM Descuento ";
			Consulta += " INNER JOIN DESRegla ON Descuento.DescuentoClave = DESRegla.DescuentoClave ";
			Consulta += " WHERE DESRegla.ProductoClave='" + ProductoClave + "'    ";
			Consulta += " AND Descuento.TipoEstado=1 AND DESRegla.TipoEstado=1 AND Descuento.Baja<>1 ";

			ISetDatos datos = BDVend.consultar(Consulta);

			Descuento des = null;
			if (datos.getCount() > 0)
			{
				datos.moveToNext();
				des = new Descuento();
				des.DescuentoClave = datos.getString("DescuentoClave");
				des.Nombre = datos.getString("Nombre");
				des.Tipo = datos.getShort("Tipo");
				des.PermiteCascada = datos.getInt("PermiteCascada");
				des.TipoAplicacion = datos.getShort("TipoAplicacion");
				des.ValorAplicacion = datos.getFloat("ValorAplicacion");
				des.TipoValor = datos.getShort("TipoValor");
				// des.Jerarquia=datos.getInt("Jerarquia");
			}

			datos.close();

			return des;

		}

		public static Descuento BuscarDescuentosProductoPorEsquema(String sEsquemas, boolean bEsNuevo) throws Exception
		{
			String Consulta = "SELECT Descuento.DescuentoClave, Descuento.Nombre, Descuento.Tipo, Descuento.PermiteCascada, Descuento.TipoAplicacion, Descuento.ValorAplicacion, ";
			Consulta += " Descuento.TipoValor, DESDetalle.Jerarquia, DESDetalle.EsquemaID FROM Descuento ";
			Consulta += " INNER JOIN DESDetalle ON Descuento.DescuentoClave = DESDetalle.DescuentoClave   ";
			Consulta += " AND Descuento.TipoEstado=1 AND DESDetalle.TipoEstado=1 AND Descuento.Baja<>1 ";
			if (bEsNuevo)
			{
				Consulta += " WHERE Descuento.TipoEstado=1 ";
				Consulta += " AND DESDetalle.TipoEstado=1 ";
				Consulta += " AND Descuento.Baja<>1";
				Consulta += " AND Descuento.Baja<>1";
				Consulta += " AND  DESDetalle.EsquemaID in (" + sEsquemas + ")";
			}
			else
			{
				Consulta += " WHERE  DESDetalle.EsquemaID in (" + sEsquemas + ")";
			}

			Consulta += " ORDER BY DESDetalle.Jerarquia ";
			ISetDatos datos = BDVend.consultar(Consulta);

			Descuento des = null;
			if (datos.getCount() > 0)
			{
				datos.moveToNext();
				des = new Descuento();
				des.DescuentoClave = datos.getString("DescuentoClave");
				des.Nombre = datos.getString("Nombre");
				des.Tipo = datos.getShort("Tipo");
				des.PermiteCascada = datos.getInt("PermiteCascada");
				des.TipoAplicacion = datos.getShort("TipoAplicacion");
				des.ValorAplicacion = datos.getFloat("ValorAplicacion");
				des.TipoValor = datos.getShort("TipoValor");
				des.Jerarquia = datos.getInt("Jerarquia");
			}

			datos.close();

			return des;

		}

		public static ModuloMov[] obtenerModulos(Vendedor vendedor) throws Exception
		{
			ArrayList<ModuloMov> modulos = new ArrayList<ModuloMov>();
			StringBuilder consulta = new StringBuilder();
			consulta.append("select MOV.ModuloClave,MOV.ModuloMovClave,MOV.Nombre,MOV.TipoIndice,MOV.Orden,MOV.TipoEstado,MOV.Baja from Vendedor VEN inner join ModuloTerm MOD on VEN.ModuloClave = MOD.ModuloClave ");
			consulta.append("inner join ModuloMov MOV on MOD.ModuloClave = MOV.ModuloClave ");
			consulta.append("inner join ModuloMovDetalle MDE on MOV.ModuloClave = MDE.ModuloClave and MOV.ModuloMovClave = MDE.ModuloMovClave ");
			consulta.append("where VEN.VendedorID = '" + vendedor.VendedorId + "' group by MOV.Nombre order by MOV.Orden");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				ModuloMov mod = new ModuloMov(datos.getString(0), datos.getString(1), datos.getString(2), datos.getInt(3), datos.getInt(4), datos.getInt(5), datos.getInt(6));
				modulos.add(mod);
			}
			return modulos.toArray(new ModuloMov[modulos.size()]);

		}

		public static void eliminarDescuentos(String TransProdID) throws Exception
		{
			BDVend.ejecutarComando("DELETE FROM TPDDes where TransProdId = '" + TransProdID + "' and TransProdDetalleID in(Select TransProdDetalle.TransProdDetalleID from TransProdDetalle WHERE TransProdDetalle.TransProdID='" + TransProdID + "')");
		}

		public static void eliminarDescuentosPorDetalle(String TransProdID, String TransProdDetalleID) throws Exception
		{
			BDVend.ejecutarComando("DELETE FROM TPDDes where TransProdId = '" + TransProdID + "' and TransProdDetalleID = '" + TransProdDetalleID + "'");
		}

		public static ISetDatos obtenerDescuentosCliente(String TransProdID) throws Exception
		{
			return BDVend.consultar("Select sum(DesImporte) as DesImporte,sum(DesImpuesto) as DesImpuesto from TpdDes where TransProdID='" + TransProdID + "' ");
		}

		public static ISetDatos obtenerAplicacionPorModulo(String ModuloMovDetalleClave, String VendedorId, String CampoAplicacion) throws Exception
		{
			return BDVend.consultar("SELECT " + CampoAplicacion + " FROM VendedorDescuento WHERE VendedorID = '" + VendedorId + "' AND ModuloMovDetalleClave = '" + ModuloMovDetalleClave + "' AND TipoEstado = 1");
		}

		public static ISetDatos obtenerDescuentosAplicados(String transProdsId) throws Exception
		{
			return BDVend.consultar("SELECT DesPor,Jerarquia,TipoCascada FROM TpdDes WHERE TransProdId in(" + transProdsId + ") group by DescuentoClave,DesPor,Jerarquia,TipoCascada ORDER BY Jerarquia ASC");
		}

		public static ISetDatos obtenerDescuentosClientePorTransProdId(String TransProdId) throws Exception
		{
			return BDVend.consultar("Select TransProdDetalleID, sum(DesImporte) as DescuentoCliente from TpdDes where TransProdID='" + TransProdId + "' group by TransProdDetalleID");
		}

		public static ISetDatos obtenerDescuentosClientePorTPD(String TransProdId, String TransProdDetalleId) throws Exception
		{
			return BDVend.consultar("Select sum(DesImporte) as DescuentoCliente from TpdDes where TransProdID='" + TransProdId + "' and TransProdDetalleID = '" + TransProdDetalleId + "' ");
		}

	}

	public static final class ConsultasImpuesto
	{

		public static ISetDatos BuscarPorProducto(String ProductoClave, Short TipoImpuesto, Date FechaActual) throws Exception
		{
			String Consula = "SELECT Impuesto.ImpuestoClave, Impuesto.Abreviatura, Impuesto.Jerarquia, Impuesto.TipoAplicacion, Impuesto.TipoValor, ImpuestoVig.Valor, Impuesto.ValidaRFC FROM ProductoImpuesto";
			Consula += " INNER JOIN Impuesto ON ProductoImpuesto.ImpuestoClave = Impuesto.ImpuestoClave";
			Consula += " INNER JOIN ImpuestoVig ON Impuesto.ImpuestoClave = ImpuestoVig.ImpuestoClave";
			Consula += " WHERE ProductoImpuesto.ProductoClave = '" + ProductoClave + "' ";
			Consula += " AND '" + Generales.getFormatoFecha(FechaActual, "yyyy-MM-dd'T'HH:mm:ss") + "'>=ImpuestoVig.FechaInicial AND '" + Generales.getFormatoFecha(FechaActual, "yyyy-MM-dd'T'HH:mm:ss") + "'<=ImpuestoVig.FechaFinal";
			Consula += " AND ImpuestoVig.TipoImpuesto=" + Short.toString(TipoImpuesto);
			Consula += " ORDER BY Impuesto.Jerarquia";
			return BDVend.consultar(Consula);

		}

		public static ISetDatos BuscarPorTransprod(String TransprodID) throws Exception
		{
			String Consulta = "SELECT Impuesto.ImpuestoClave,  Impuesto.Jerarquia,  Impuesto.TipoValor FROM Transprod";
			// Consula+=" INNER JOIN TransProdDetalle ON TransProdDetalle.TransProdDetalleID = TransProd.TransProdDetalleID and TransProdDetalle.TransProdID = TransProd.TransProdID";
			Consulta += " INNER JOIN TransProdDetalle ON TransProdDetalle.TransProdID = TransProd.TransProdID";
			Consulta += " INNER JOIN TPDImpuesto ON TransProdDetalle.TransProdDetalleID = TPDImpuesto.TransProdDetalleID and TransProdDetalle.TransProdID = TPDImpuesto.TransProdID";
			Consulta += " INNER JOIN Impuesto ON TPDImpuesto.ImpuestoClave = Impuesto.ImpuestoClave";
			Consulta += " WHERE TransProd.TransProdID = '" + TransprodID + "' ";
			Consulta += " ORDER BY Impuesto.Jerarquia";
			return BDVend.consultar(Consulta);

		}

		public static ISetDatos BuscarValoresTransprod(String TransprodID, String TransprodDetalleID, String ImpuestoClave) throws Exception
		{
			String Consula = "SELECT ImpuestoImp, TPDImpuestoId FROM TPDImpuesto WHERE TransProdId ='" + TransprodID + "' AND TransProdDetalleId='" + TransprodDetalleID + "' AND ImpuestoClave='" + ImpuestoClave + "'";

			return BDVend.consultar(Consula);

		}

		public static ISetDatos obtenerDetalleImpuestos(String transProdid) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT  I.Abreviatura || ' ' || CASE WHEN I.TipoValor = 1 THEN  Round(IMV.Valor,2) || '%' ELSE Round(IMV.Valor,2) END as Abreviatura, SUM(TPDI.ImpuestoImp) as ImpuestoImp, SUM(TPDI.ImpDesGlb) as ImpDesGlb FROM TPDImpuesto TPDI inner join TransProd TP on TP.TransProdID = TPDI.TransProdID ").
			append("inner join TransProdDetalle TPD on TPD.TransProdDetalleID = TPDI.TransProdDetalleID ").
			append("inner join Impuesto I on I.ImpuestoClave = TPDI.ImpuestoClave ").
			append("inner join ImpuestoVig IMV on IMV.ImpuestoClave = I.ImpuestoClave  and  datetime('now') between FechaInicial and FechaFinal ").
			append("where TP.TransProdID in (").append(transProdid).append(") group by I.ImpuestoClave, I.Abreviatura ").
			append("order by I.Abreviatura, I.TipoValor ");
			
			return BDVend.consultar(consulta.toString());
		}

        public static void ActualizaImpDesGlb(String sTransprodId, String sTransprodDetalleId, String sImpuestoClave, double nImporte) throws Exception
        {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("update TPDImpuesto ");
            sConsulta.append("set ImpDesGlb=" + nImporte + " ");
            sConsulta.append("where TransprodID = '" + sTransprodId + "' and TransprodDetalleId = '" + sTransprodDetalleId + "' and ImpuestoClave = '" + sImpuestoClave + "'");
            BDVend.ejecutarComando(sConsulta.toString());
        }
	}

	public static final class ConsultasTransProd
	{


		public static ISetDatos obtenerMovimientosSinInventarioSinVisita(String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select  t.FechaCaptura, t.Folio, td.ProductoClave, p.Nombre, td.TipoUnidad, td.Cantidad from TransProd t ")
					.append("inner join TransProdDetalle td on t.TransProdID = td.TransProdID ")
					.append("inner join Producto p on td.ProductoClave = p.ProductoClave ")
					.append("where t.Tipo = '19' and t.TipoFase != '0' and t.DiaClave = '"+diaClave+"' ")
					.append("order by t.FechaCaptura asc,t.Folio asc, td.ProductoClave asc ");

			return BDVend.consultar(consulta.toString());

		}

		public static ISetDatos obtenerSaldoClienteEfectivo(String clienteClaves) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select c.Clave, c.RazonSocial, c.SaldoEfectivo from Cliente c ")
					.append("where c.SaldoEfectivo > 0 and c.ClienteClave in ("+clienteClaves+") ")
					.append("order by c.Clave asc ");

			return BDVend.consultar(consulta.toString());

		}
		public static ISetDatos obtenerDevolucionesCambiosGeneral(String diaClave) throws Exception{


			StringBuilder consulta = new StringBuilder();
			consulta.append("select group_concat(distinct t.Tipo) as 'tipoM', td.TipoMotivo,td.ProductoClave, p.Nombre,sum(pd.Factor*td.Cantidad) as 'Cant' from TransProd t  ")
					.append("inner join Visita v on t.VisitaClave = v.VisitaClave and v.DiaClave = '"+diaClave+"' ")
					.append("inner join TransProdDetalle td on t.TransProdID = td.TransProdID ")
					.append("inner join Producto p on td.ProductoClave = p.ProductoClave ")
					.append("inner join ProductoDetalle pd on p.ProductoClave = pd.ProductoClave ")
					.append("inner join ProductoUnidad pu on p.ProductoClave = pu.ProductoClave ")
					.append("inner join ProductoEsquema pe on p.ProductoClave = pe.ProductoClave ")
					.append("inner join Esquema e on pe.EsquemaID = e.EsquemaID ")
					.append("where  t.Tipo in ('9','3') and t.TipoFase != '0' and t.TipoMovimiento = '1' ")
					.append("group by td.TipoMotivo,td.ProductoClave, p.Nombre ")
					.append("order by td.TipoMotivo,td.ProductoClave desc,e.Clave asc, pu.KgLts desc ");

			return BDVend.consultar(consulta.toString());

		}

		public static ISetDatos obtenerDevolucionesCambiosDetallado(String diaClave,String tipos) throws Exception {

			StringBuilder consulta = new StringBuilder();
			consulta.append("select  t.Tipo,c.Clave,c.NombreCorto,td.ProductoClave, p.Nombre,sum(pd.Factor*td.Cantidad) as 'Cant',  td.TipoMotivo from TransProd t ")
					.append("inner join Visita v on t.VisitaClave = v.VisitaClave and v.DiaClave = '" + diaClave + "' ")
					.append("inner join Cliente c on v.ClienteClave = c.ClienteClave ")
					.append("inner join TransProdDetalle td on t.TransProdID = td.TransProdID ")
					.append("inner join Producto p on td.ProductoClave = p.ProductoClave ")
					.append("inner join ProductoDetalle pd on p.ProductoClave = pd.ProductoClave ")
					.append("inner join ProductoUnidad pu on p.ProductoClave = pu.ProductoClave ")
					.append("inner join ProductoEsquema pe on p.ProductoClave = pe.ProductoClave ")
					.append("inner join Esquema e on pe.EsquemaID = e.EsquemaID ")
					.append("where  t.Tipo in (" + tipos + ") and t.TipoFase != '0' and t.TipoMovimiento = '1' ")
					.append("group by t.Tipo,c.Clave,c.NombreCorto, td.ProductoClave, p.Nombre,td.TipoMotivo ")
					.append("order by c.NombreCorto, t.Tipo desc, c.Clave asc,e.Clave asc, pu.KgLts desc ");

			return BDVend.consultar(consulta.toString());

		}

		public static ISetDatos obtenerClientesConAbono(String diaClave) throws Exception {

			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct c.ClienteClave, c.RazonSocial from Cliente c ")
					.append("inner join Visita v on c.ClienteClave = v.ClienteClave and v.DiaClave = '"+diaClave+"' ")
					.append("inner join Abono a on v.VisitaClave = a.VisitaClave ");

			return BDVend.consultar(consulta.toString());

		}
		public static ISetDatos obtenerPreLiquidacionCreditos(String diaClave, String claveCliente) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct ad.TipoPago,sum( abt.Importe ) as 'Importe' from Abono a  ")
					.append("inner join Visita v on a.VisitaClave = v.VisitaClave and v.DiaClave = '"+diaClave+"' ")
					.append("inner join Cliente c on v.ClienteClave = c.ClienteClave  " + (claveCliente != null?"and c.ClienteClave = '"+claveCliente+"'":""))
					.append("inner join ABNDetalle ad on a.ABNId = ad.ABNId and (ad.TipoPago = 1 or ad.TipoPago = 2 or ad.TipoPago = 5) ")
					.append("inner join AbnTrp abt on a.ABNId = abt.ABNId ")
					.append("inner join Dia d on v.DiaClave = d.DiaClave ")
					.append("inner join TransProd t on abt.TransProdId = t.TransProdId  and t.FechaCaptura != d.FechaCaptura and t.CFVTipo = '2' ")
					.append("group by ad.TipoPago order by ad.TipoPago asc ");

			return BDVend.consultar(consulta.toString());

		}

		public static ISetDatos obtenerPreLiquidacionVentas(String diaClave, String claveCliente) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct ad.TipoPago,sum( abt.Importe ) as 'Importe',sum(t.Saldo) as 'Credito' from Abono a  ")
					.append("inner join Visita v on a.VisitaClave = v.VisitaClave and v.DiaClave = '"+diaClave+"' ")
					.append("inner join Cliente c on v.ClienteClave = c.ClienteClave " + (claveCliente != null?"and c.ClienteClave = '"+claveCliente+"'":""))
					.append("inner join ABNDetalle ad on a.ABNId = ad.ABNId and (ad.TipoPago = 1 or ad.TipoPago = 2 or ad.TipoPago = 5) ")
					.append("inner join AbnTrp abt on a.ABNId = abt.ABNId ")
					.append("inner join Dia d on v.DiaClave = d.DiaClave ")
					.append("inner join TransProd t on abt.TransProdId = t.TransProdId  and t.FechaCaptura = d.FechaCaptura ")
					.append("group by ad.TipoPago order by ad.TipoPago asc ");

			return BDVend.consultar(consulta.toString());

		}

		public static ISetDatos obtenerCreditoVentas(String diaClave,String claveCliente) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select sum(t.Saldo) as Credito ")
					.append("from Transprod t ")
					.append("inner join Visita v on t.VisitaClave=v.VisitaClave and t.DiaClave=v.DiaClave ")
					.append("where v.DiaClave in ('"+diaClave+"') ")
					.append("and t.CfvTipo in (1,2) and t.DiaClave in ('" + diaClave + "') " + (claveCliente != null ? "and v.ClienteClave = '" + claveCliente + "'" : ""));

			return BDVend.consultar(consulta.toString());

		}

		public static ISetDatos obtenerSubEmpresas() throws Exception {

			StringBuilder consulta = new StringBuilder();
			consulta.append("select SubEmpresaId, NombreEmpresa, RFC, Calle, Numero, Colonia, Ciudad, Region from SubEmpresa");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerInventarioGeneral (String subEmpresaId) throws  Exception {
			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct p.ProductoClave, p.Nombre, i.Disponible as Exis, (i.Disponible - i.NoDisponible - i.Apartado - i.Contenido) as Disp, (i.NoDisponible + i.Apartado) as 'No D', pu.PRUTipoUnidad, pd.Factor from Inventario i ")
					.append("inner join Producto p on i.ProductoClave = p.ProductoClave and p.SubEmpresaId = '" + subEmpresaId + "' ")
					.append("inner join ProductoUnidad pu on p.ProductoClave = pu.ProductoClave ")
					.append("inner join ProductoDetalle pd on p.ProductoClave = pd.ProductoClave and pu.PRUTipoUnidad = pd.PRUTipoUnidad and pd.Factor = (select MIN(pd.Factor) from inventario i inner join Producto p on i.ProductoClave = p.ProductoClave and p.SubEmpresaId = '" + subEmpresaId + "' inner join ProductoDetalle pd on i.ProductoClave = pd.ProductoClave ) ")
					.append("order by i.ProductoClave asc");

			return BDVend.consultar(consulta.toString());
		}


        public static ISetDatos obtenerInventarioDetallado(String subEmpresaId) throws Exception{

            StringBuilder consulta = new StringBuilder();
            consulta.append("select distinct p.ProductoClave, p.Nombre, i.Disponible as Exis, (i.Disponible - i.NoDisponible - i.Apartado - i.Contenido) as Disp, (i.NoDisponible + i.Apartado) as 'No D', pu.PRUTipoUnidad, pd.Factor, pv.Precio from Inventario i ")
                    .append("inner join Producto p on i.ProductoClave = p.ProductoClave and p.SubEmpresaId = '" + subEmpresaId + "' ")
                    .append("inner join ProductoUnidad pu on p.ProductoClave = pu.ProductoClave ")
                    .append("inner join ProductoDetalle pd on p.ProductoClave = pd.ProductoClave and pu.PRUTipoUnidad = pd.PRUTipoUnidad ")
                    .append("left join PrecioProductoVig pv  on pv.ProductoClave = pd.ProductoClave and pv.PRUTipoUnidad = pu.PRUTipoUnidad ")
                    .append("order by i.ProductoClave asc, pd.Factor desc, pv.Precio desc");

            return BDVend.consultar(consulta.toString());
        }

		public static ISetDatos obtenerInventarioTotalProductos (String subEmpresaId) throws  Exception {
			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct sum( i.Disponible) as Exis, sum( (i.Disponible - i.NoDisponible - i.Apartado - i.Contenido) ) as Disp, sum( (i.NoDisponible + i.Apartado)  ) as 'No D' from Inventario i ")
					.append("inner join Producto p on i.ProductoClave = p.ProductoClave and p.SubEmpresaId = '" + subEmpresaId + "' ")
					.append("inner join ProductoUnidad pu on p.ProductoClave = pu.ProductoClave ")
					.append("inner join ProductoDetalle pd on p.ProductoClave = pd.ProductoClave and pu.PRUTipoUnidad = pd.PRUTipoUnidad and pd.Factor = (select MIN(pd.Factor) from inventario i inner join Producto p on i.ProductoClave = p.ProductoClave and p.SubEmpresaId = '" + subEmpresaId + "' inner join ProductoDetalle pd on i.ProductoClave = pd.ProductoClave ) ")
					.append("order by i.ProductoClave asc");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerInventarioTotalUnitario (String subEmpresaId) throws  Exception {
			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct pv.ProductoClave, pv.Precio, inv.disponible, inv.Factor from PrecioProductoVig pv ")
					.append("inner join (select distinct pd.ProductoClave, pd.PRUTipoUnidad, i.Disponible, pd.Factor from inventario i ")
					.append("inner join Producto p on i.ProductoClave = p.ProductoClave and p.SubEmpresaId = '" + subEmpresaId + "' ")
					.append("inner join ProductoDetalle pd on i.ProductoClave = pd.ProductoClave and i.ProductoClave = pd.ProductoDetClave and pd.Factor = (select MIN(pd.Factor) from inventario i inner join Producto p on i.ProductoClave = p.ProductoClave and p.SubEmpresaId = '" + subEmpresaId + "' inner join ProductoDetalle pd on i.ProductoClave = pd.ProductoClave and i.ProductoClave = pd.ProductoDetClave) order by i.ProductoClave asc) inv on pv.ProductoClave = inv.ProductoClave and pv.PRUTipoUnidad = inv.PRUTipoUnidad ")
					.append("order by pv.ProductoClave asc, pv.Precio desc");

			return BDVend.consultar(consulta.toString());
		}

        
        public static ArrayList<String> agruparTransacciones(String sTransProdId){
			ArrayList<String> res = new ArrayList<>();
			res.add(sTransProdId);
			try
            {
                String sConsulta = "SELECT TransProdID from TRPGrupo where GrupoID = (select GrupoID from TRPGrupo where TransProdID = '" + sTransProdId + "') AND TransProdID != '" + sTransProdId + "'";
				ISetDatos trans = BDVend.consultar(sConsulta);
				while(trans.moveToNext()){
					res.add(trans.getString("TransProdID"));
				}
                return res;
            }
            catch (Exception e)
            {
                e.printStackTrace();
                return res;
            }
        }

		public static void eliminarPorFacturaId(String facturaId) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("DELETE FROM TransProd WHERE FacturaID = '" + facturaId + "'");
			BDVend.ejecutarComando(sConsulta.toString());
		}

		public static ISetDatos obtenerProductosSinPromocion(String sTransProdId)
		{
			try
			{
				StringBuilder sConsulta = new StringBuilder();
				sConsulta.append("SELECT TPD.ProductoClave, SUM(TPD.Cantidad * PRD.Factor) AS Cantidad, SUM(TPD.Subtotal) AS Subtotal, SUM(TPD.Impuesto) AS Impuesto ");
				sConsulta.append("FROM TransProdDetalle TPD ");
				sConsulta.append("INNER JOIN ProductoDetalle PRD ON TPD.ProductoClave = PRD.ProductoClave AND TPD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ");
				sConsulta.append("WHERE TPD.TransProdId = '" + sTransProdId + "' and  IFNULL(TPD.Promocion, 0) <> 2 ");
				sConsulta.append("GROUP BY TPD.ProductoClave ");

				return BDVend.consultar(sConsulta.toString());
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

		public static ISetDatos obtenerCantidadesPorProducto(String sTransProdId, String sProductoClave)
		{
			try
			{
				StringBuilder sConsulta = new StringBuilder();
				sConsulta.append("SELECT SUM(TPD.Cantidad * PRD.Factor) AS Cantidad, SUM(TPD.Subtotal) AS Subtotal, SUM(TPD.Impuesto) AS Impuesto ");
				sConsulta.append("FROM TransProdDetalle TPD ");
				sConsulta.append("INNER JOIN ProductoDetalle PRD ON TPD.ProductoClave = PRD.ProductoClave AND TPD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ");
				sConsulta.append("WHERE TPD.TransProdId = '" + sTransProdId + "' and TPD.ProductoClave = '" + sProductoClave + "' and IFNULL(TPD.Promocion,0) <> 2 ");
				// sConsulta.append("GROUP BY TPD.ProductoClave ");

				return BDVend.consultar(sConsulta.toString());
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

		public static int obtenerSiguientePartida(String sTransProdId)
		{
			try
			{
				StringBuilder sConsulta = new StringBuilder();
				sConsulta.append("SELECT MAX(Partida) AS Partida FROM TransProdDetalle WHERE TransProdId = '" + sTransProdId + "'");

				String sMax = BDVend.getBD().ejecutarEscalar(sConsulta.toString());
				int nMax = 0;
				if (sMax != "")
					nMax = Integer.parseInt(sMax);
				nMax += 1;
				return nMax;

			}
			catch (Exception e)
			{
				e.printStackTrace();
				return 0;
			}
		}

		public static SeleccionarPedido.VistaPedidos[] obtenerPedidosPorVisita(Dia dia, Cliente cliente, Visita visita) throws Exception
		{
			ArrayList<SeleccionarPedido.VistaPedidos> pedidos = new ArrayList<SeleccionarPedido.VistaPedidos>();
			StringBuilder consulta = new StringBuilder();
			ISetDatos fases = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
			consulta.append("select TRP.TransProdID,TRP.Folio,TRP.TipoFase, ");
			consulta.append("case when TRP.TipoFase = 1 Then TRP.FechaCaptura  ");
			consulta.append("else case when TRP.TipoFase = 7 Then TRP.FechaEntrega ");
			consulta.append("else case when TRP.TipoFase = 0 Then TRP.FechaCancelacion ");
			consulta.append("else case when TRP.TipoFase = 2 Then TRP.FechaSurtido ");
			consulta.append("else case when TRP.TipoFase = 3 Then TRP.FechaFacturacion end end end end end as Fecha ");
			consulta.append("from TransProd TRP inner join Dia D on TRP.DiaClave = D.DiaClave ");
			consulta.append("inner join visita VIS on VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = D.DiaClave ");
			//consulta.append("where TRP.Tipo in (1) ");

			ModuloMovDetalle moduloMovDetalle = ConsultasModuloMovDetalle.obtenerModuloMovDetallePorIndice(Integer.valueOf(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString()));
			consulta.append("where TRP.Tipo in (" + moduloMovDetalle.getTipoTransprod() + ") ");

			//consulta.append("where TRP.Tipo in (1,19,21) "); // pedidos y
																// movimientos
																// sin
																// inventario
			consulta.append("and TRP.ClienteClave = '" + cliente.ClienteClave + "' and TRP.DiaClave = '" + dia.DiaClave + "' AND VIS.VisitaClave = '" + visita.VisitaClave + "' ");
            consulta.append("and TRP.PCEModuloMovDetClave = '" + Sesion.get(Campo.ModuloMovDetalleClave).toString() + "' ");
			consulta.append("and TRP.TransProdID not in (select FacturaID from TransProd where Tipo = 24 and TipoFase = 8) ");
			
			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				int fase = datos.getInt(2) + 1;
				fases.moveToPosition(fase - 1);
				SeleccionarPedido.VistaPedidos pedido = new SeleccionarPedido.VistaPedidos(datos.getString(0), datos.getString(1), datos.getInt(2), fases.getString(2), datos.getDate(3));// datos.getDate(3)
																																															// Generales.getFechaHoraActual()
				pedidos.add(pedido);
			}

			fases.close();
			datos.close();

			return pedidos.toArray(new SeleccionarPedido.VistaPedidos[pedidos.size()]);
		}
		
		public static SeleccionarPedido.VistaPedidos[] obtenerMovSinInvPorVisita(Dia dia, Cliente cliente, Visita visita) throws Exception
		{
			ArrayList<SeleccionarPedido.VistaPedidos> pedidos = new ArrayList<SeleccionarPedido.VistaPedidos>();
			StringBuilder consulta = new StringBuilder();
			ISetDatos fases = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
			consulta.append("select TRP.TransProdID,TRP.Folio,TRP.TipoFase, ");
			consulta.append("case when TRP.TipoFase = 1 Then TRP.FechaCaptura  ");
			consulta.append("else case when TRP.TipoFase = 0 Then TRP.FechaCancelacion ");
			consulta.append("else case when TRP.TipoFase = 1 Then TRP.FechaCaptura ");
			consulta.append("else case when TRP.TipoFase = 2 Then TRP.FechaSurtido ");
			consulta.append("else case when TRP.TipoFase = 3 Then TRP.FechaFacturacion end end end end end as Fecha ");
			consulta.append("from TransProd TRP inner join Dia D on TRP.DiaClave = D.DiaClave ");
			consulta.append("inner join visita VIS on VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = D.DiaClave ");
			consulta.append("where TRP.Tipo in (21) "); // pedidos y
																// movimientos
																// sin
																// inventario
			consulta.append("and TRP.ClienteClave = '" + cliente.ClienteClave + "' and TRP.DiaClave = '" + dia.DiaClave + "' AND VIS.VisitaClave = '" + visita.VisitaClave + "'");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				int fase = datos.getInt(2) + 1;
				fases.moveToPosition(fase - 1);
				SeleccionarPedido.VistaPedidos pedido = new SeleccionarPedido.VistaPedidos(datos.getString(0), datos.getString(1), datos.getInt(2), fases.getString(2), datos.getDate(3));// datos.getDate(3)
																																															// Generales.getFechaHoraActual()
				pedidos.add(pedido);
			}

			fases.close();
			datos.close();

			return pedidos.toArray(new SeleccionarPedido.VistaPedidos[pedidos.size()]);
		}

		public static SeleccionarPedido.VistaPedidos[] obtenerCambiosPorVisita(Dia dia, Cliente cliente, Visita visita) throws Exception
		{
			ArrayList<SeleccionarPedido.VistaPedidos> pedidos = new ArrayList<SeleccionarPedido.VistaPedidos>();
			StringBuilder consulta = new StringBuilder();
			ISetDatos fases = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
			consulta.append("select TRP.TransProdID,TRP.Folio,TRP.TipoFase, ");
			consulta.append("TRP.FechaCaptura as Fecha ");
			consulta.append("from TransProd TRP inner join Dia D on TRP.DiaClave = D.DiaClave ");
			consulta.append("inner join visita VIS on VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = D.DiaClave ");
			consulta.append("where TRP.Tipo in (9) and TRP.TipoMovimiento = 1 and TRP.TipoFase = 1 "); // cambios
																										// de
																										// producto
																										// en
																										// fase
																										// captura
																										// y
																										// tipo
																										// movimiento
																										// entrada
			consulta.append("and VIS.ClienteClave = '" + cliente.ClienteClave + "' and TRP.DiaClave = '" + dia.DiaClave + "' AND VIS.VisitaClave = '" + visita.VisitaClave + "'");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				int fase = datos.getInt(2) + 1;
				fases.moveToPosition(fase - 1);
				SeleccionarPedido.VistaPedidos pedido = new SeleccionarPedido.VistaPedidos(datos.getString(0), datos.getString(1), datos.getInt(2), fases.getString(2), datos.getDate(3));// datos.getDate(3)
																																															// Generales.getFechaHoraActual()
				pedidos.add(pedido);
			}

			fases.close();
			datos.close();

			return pedidos.toArray(new SeleccionarPedido.VistaPedidos[pedidos.size()]);
		}

		public static SeleccionarPedido.VistaPedidos[] obtenerDevolucionesPorVisita(Dia dia, Cliente cliente, Visita visita) throws Exception
		{
			ArrayList<SeleccionarPedido.VistaPedidos> pedidos = new ArrayList<SeleccionarPedido.VistaPedidos>();
			StringBuilder consulta = new StringBuilder();
			ISetDatos fases = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
			consulta.append("select TRP.TransProdID,TRP.Folio,TRP.TipoFase, ");
			consulta.append("TRP.FechaCaptura as Fecha ");
			consulta.append("from TransProd TRP inner join Dia D on TRP.DiaClave = D.DiaClave ");
			consulta.append("inner join visita VIS on VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = D.DiaClave ");
			consulta.append("where TRP.Tipo in (3) and TRP.TipoFase = 1 "); // cambios
																			// de
																			// producto
																			// en
																			// fase
																			// captura
																			// y
																			// tipo
																			// movimiento
																			// entrada
			consulta.append("and VIS.ClienteClave = '" + cliente.ClienteClave + "' and TRP.DiaClave = '" + dia.DiaClave + "' AND VIS.VisitaClave = '" + visita.VisitaClave + "'");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				int fase = datos.getInt(2) + 1;
				fases.moveToPosition(fase - 1);
				SeleccionarPedido.VistaPedidos pedido = new SeleccionarPedido.VistaPedidos(datos.getString(0), datos.getString(1), datos.getInt(2), fases.getString(2), datos.getDate(3));// datos.getDate(3)
																																															// Generales.getFechaHoraActual()
				pedidos.add(pedido);
			}

			fases.close();
			datos.close();

			return pedidos.toArray(new SeleccionarPedido.VistaPedidos[pedidos.size()]);
		}

		public static SeleccionarPedido.VistaPedidos[] obtenerMovimientoInventario(Dia dia, String Tipo) throws Exception{
			return obtenerMovimientoInventario(dia, Tipo, null);
		}

		public static SeleccionarPedido.VistaPedidos[] obtenerMovimientoInventario(Dia dia, String Tipo, String accion) throws Exception
		{
			ArrayList<SeleccionarPedido.VistaPedidos> pedidos = new ArrayList<SeleccionarPedido.VistaPedidos>();
			StringBuilder consulta = new StringBuilder();
			ISetDatos fases = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
			consulta.append("select TRP.TransProdID,TRP.Folio,TRP.TipoFase,TRP.TipoMotivo, ");
			consulta.append("TRP.FechaCaptura as Fecha ");
			consulta.append("from TransProd TRP inner join Dia D on TRP.DiaClave = D.DiaClave ");
			consulta.append("where TRP.Tipo in (" + Tipo + ")  and TRP.DiaClave = '" + dia.DiaClave + "'");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				int fase = datos.getInt(2) + 1;
				fases.moveToPosition(fase - 1);
				//SeleccionarPedido.VistaPedidos pedido = new SeleccionarPedido.VistaPedidos(datos.getString("TransProdID"), datos.getString("Folio"), datos.getInt("TipoFase"), fases.getString(2), datos.getDate("Fecha"), grupoMotivo);// datos.getDate(3)
																																															// Generales.getFechaHoraActual()
				SeleccionarPedido.VistaPedidos pedido;
				if(accion != null && accion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)){
					//se agrega el grupo motivo como extras
					com.amesol.routelite.actividades.ValorReferencia vr = ValoresReferencia.getValor("TRPMOT", datos.getString("TipoMotivo"));
					String grupoMotivo = vr.getGrupo();
					pedido = new SeleccionarPedido.VistaPedidos(datos.getString("TransProdID"), datos.getString("Folio"), datos.getInt("TipoFase"), fases.getString(2), datos.getDate("Fecha"), grupoMotivo);// datos.getDate(3)
				}else{
					pedido = new SeleccionarPedido.VistaPedidos(datos.getString("TransProdID"), datos.getString("Folio"), datos.getInt("TipoFase"), fases.getString(2), datos.getDate("Fecha"));// datos.getDate(3)
				}
				pedidos.add(pedido);
			}

			fases.close();
			datos.close();

			return pedidos.toArray(new SeleccionarPedido.VistaPedidos[pedidos.size()]);
		}

		public static void eliminarFactura(String TransProdId) throws Exception
		{
			BDVend.consultar("DELETE FROM TransProd WHERE FacturaID='" + TransProdId + "'");
		}

		public static ISetDatos obtenerPorTipo(String TransProdId, int Tipo) throws Exception
		{
			return BDVend.consultar("SELECT TransProd.TransProdID,ProductoClave,TipoUnidad, Cantidad FROM TransProdDetalle inner join TransProd on TransProd.TransProdID = TransProdDetalle.TransProdID WHERE FacturaID='" + TransProdId + "' and Tipo = " + Tipo);
		}

		public static ISetDatos obtenerTransProd(String TransProdId) throws Exception
		{
			return BDVend.consultar("SELECT * from TransProd where TransProdId='" + TransProdId + "'");
		}

		public static TransProd obtenerTransProdsPorSubEmpresa(String TransProds, String SubEmpresaId) throws Exception
		{
			ISetDatos datos = BDVend.consultar("SELECT TransProdId, SubEmpresaId FROM TransProd WHERE TransProdId in (" + TransProds + ") AND SubEmpresaId = '" + SubEmpresaId + "'");
			if (datos.getCount() == 1)
			{
				TransProd transprod = (TransProd) BDVend.instanciar(TransProd.class, datos);
				datos.close();
				return transprod;
			}
			datos.close();
			return null;
		}

		public static ISetDatos obtenerTransProdsPorIds(String TransProds) throws Exception
		{
			return BDVend.consultar("SELECT TransProdId, SubEmpresaId FROM TransProd WHERE TransProdId in (" + TransProds + ")");
		}

		public static void eliminarPorTransProdId(String TransProdId) throws Exception
		{
			BDVend.consultar("DELETE FROM TransProd WHERE TransProdID='" + TransProdId + "'");
		}

		public static ISetDatos obtenerEncabezadosResumen(Dia dia, Cliente cliente, Visita visita) throws Exception
		{
			// obtiene la descripcion de los diferentes movientos realizados en
			// la visita
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TRP.Tipo as _id, MMD.Nombre, TRP.Tipo ");
			consulta.append("FROM TransProd TRP INNER JOIN ModuloMovDetalle MMD ON TRP.Tipo = MMD.TipoTransProd ");
			consulta.append("WHERE TRP.Tipo in (1,3,8,9,10,20,21,24) AND "); // pedidos,
																				// dev.
																				// cliente,
																				// factura,
																				// cambio
																				// producto,
																				// nota
																				// credito,
																				// surtir
																				// producto
																				// promo,
																				// mov.
																				// sin
																				// inv.,
																				// consignacion
			consulta.append("TRP.DiaClave = '" + dia.DiaClave + "' AND TRP.VisitaClave = '" + visita.VisitaClave + "' AND TRP.ClienteClave = '" + cliente.ClienteClave + "' ");
			consulta.append("GROUP BY TRP.Tipo");
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerEncabezadosResumen(Dia dia, Cliente cliente, Visita visita, int Tipo) throws Exception
		{
			// obtiene la descripcion de los diferentes movientos realizados en
			// la visita
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT MMD.TipoTransProd as _id, MMD.Nombre, MMD.TipoTransProd as Tipo ");
			consulta.append("FROM ModuloMovDetalle MMD ");
			consulta.append("WHERE MMD.TipoTransProd in (" + Tipo + ") "); // pedidos,
																			// dev.
																			// cliente,
																			// factura,
																			// cambio
																			// producto,
																			// nota
																			// credito,
																			// surtir
																			// producto
																			// promo,
																			// mov.
																			// sin
																			// inv.,
																			// consignacion
			// consulta.append("AND TRP.DiaClave = '" + dia.DiaClave +
			// "' AND TRP.VisitaClave = '" + visita.VisitaClave +
			// "' AND TRP.ClienteClave = '" + cliente.ClienteClave +
			// "' AND TRP.Tipo = " + Tipo + " ");
			// consulta.append("GROUP BY TRP.Tipo");
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerMovimientosResumen(Dia dia, Cliente cliente, Visita visita, String TipoTransProd) throws Exception
		{
			// obtiene todos los movimientos del tipo solicitado
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TRP.TransProdId as _id, TRP.Folio, TRP.TipoMotivo, TRP.Total, TRP.Tipo, TRP.SubTDetalle as Subtotal, TRP.Impuesto, TRP.DescuentoVendedor + TRP.DescuentoImp as Descuento, TRP.FacturaID ");
			consulta.append("FROM TransProd TRP INNER JOIN ModuloMovDetalle MMD ON TRP.Tipo = MMD.TipoTransProd ");
			// consulta.append("INNER JOIN Visita VIS ON TRP.VisitaClave = VIS.VisitaClave OR TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("WHERE TRP.Tipo in (" + TipoTransProd + ") AND "); // pedidos,
																				// dev.
																				// cliente,
																				// factura,
																				// cambio
																				// producto,
																				// nota
																				// credito,
																				// surtir
																				// producto
																				// promo,
																				// mov.
																				// sin
																				// inv.,
																				// consignacion
			consulta.append("TRP.DiaClave = '" + dia.DiaClave + "' AND TRP.VisitaClave = '" + visita.VisitaClave + "' AND TRP.ClienteClave = '" + cliente.ClienteClave + "' ");
			consulta.append("UNION ");
			consulta.append("SELECT TRP.TransProdId as _id, TRP.Folio, TRP.TipoMotivo, TRP.Total, TRP.Tipo, TRP.SubTDetalle as Subtotal, TRP.Impuesto, TRP.DescuentoVendedor + TRP.DescuentoImp as Descuento, TRP.FacturaID ");
			consulta.append("FROM TransProd TRP INNER JOIN ModuloMovDetalle MMD ON TRP.Tipo = MMD.TipoTransProd ");
			consulta.append("INNER JOIN Visita VIS ON TRP.VisitaClave = VIS.VisitaClave OR TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("WHERE TRP.Tipo in (" + TipoTransProd + ") AND TRP.TipoMovimiento = 1 AND "); // pedidos,
																											// dev.
																											// cliente,
																											// factura,
																											// cambio
																											// producto,
																											// nota
																											// credito,
																											// surtir
																											// producto
																											// promo,
																											// mov.
																											// sin
																											// inv.,
																											// consignacion
			consulta.append("TRP.DiaClave = '" + dia.DiaClave + "' AND TRP.VisitaClave = '" + visita.VisitaClave + "' AND VIS.ClienteClave = '" + cliente.ClienteClave + "' ");
			consulta.append("UNION ");
			consulta.append("SELECT ABN.ABNId as _id, ABN.Folio, ABD.TipoPago as TipoMotivo, sum(ABD.Importe), 11 as Tipo, 0 as Subtotal, 0 as Impuesto, 0 as Descuento, '' as FacturaID ");
			consulta.append("FROM Abono ABN inner join ABNDetalle ABD on ABN.ABNId = ABD.ABNId WHERE ABN.DiaClave = '" + dia.DiaClave + "' AND ABN.VisitaClave = '" + visita.VisitaClave + "' GROUP BY ABD.TipoPago ");

			consulta.append("ORDER BY TRP.Tipo,TRP.Folio ");
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerDetalleMovResumen(String TransProdId) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TPD.TransProdId as _id, PRO.ProductoClave, PRO.Nombre, TPD.Cantidad, TPD.TipoUnidad, TPD.Precio, TPD.Subtotal, TPD.Total ");
			consulta.append("FROM TransProdDetalle TPD INNER JOIN Producto PRO ON TPD.ProductoClave = PRO.ProductoClave ");
			consulta.append("WHERE TPD.TransProdId = '" + TransProdId + "' ORDER BY PRO.ProductoClave");
			return BDVend.consultar(consulta.toString());
		}

		public static short getTipoFiscalCliente(String clienteClave) throws Exception
		{
			ISetDatos datos = BDVend.consultar("SELECT TipoFiscal FROM Cliente where ClienteClave = '" + clienteClave + "'");
			short res = 0;
			if (datos.moveToNext())
			{
				res = datos.getShort(0);
			}
			datos.close();
			return res;
		}

		public static float obtenerEfectivo() throws Exception
		{
			ISetDatos datos = BDVend.consultar("SELECT SUM(Importe) FROM ABNDetalle where TipoPago = 1");
			float res = 0;
			if (datos.moveToNext())
			{
				res = datos.getFloat(0);
			}
			datos.close();
			return res;
		}

		public static String obtenerPreLiquidacionTrans(String PLIId) throws Exception
		{
			ISetDatos datos = BDVend.consultar("SELECT * FROM TransProd where PLIId = '" + PLIId + "'");
			String res = "";
			if (datos.moveToNext())
			{
				res = datos.getString(0);
			}
			datos.close();
			return res;
		}

		public static String obtenerPreLiquidacionPLBPLE(String PLIId) throws Exception
		{
			ISetDatos datos = BDVend.consultar("SELECT * FROM PLBPLE where PLIId = '" + PLIId + "'");
			String res = "";
			if (datos.moveToNext())
			{
				res = datos.getString(0);
			}
			datos.close();
			return res;
		}

		public static short obtenerTipoIndice(String clienteClave) throws Exception
		{
			ISetDatos datos = BDVend.consultar("SELECT TipoFiscal FROM Cliente where ClienteClave = '" + clienteClave + "'");
			short res = 0;
			if (datos.moveToNext())
			{
				res = datos.getShort(0);
			}
			datos.close();
			return res;
		}

		public static ISetDatos obtenerVentasVencidas(String clienteClave, short tipoCobranza) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			short trueType;
			if (tipoCobranza == 2)
				trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(clienteClave);
			else
				trueType = tipoCobranza;
			consulta.append("SELECT TransProdId ");
			consulta.append("FROM TransProd TRP ");
			consulta.append("INNER JOIN Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
			consulta.append("INNER JOIN Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("WHERE Tipo in (" + trueType + ", 24) and TipoFase <> 0 AND FechaCobranza < date('now',(-CLI.DiasVencimiento)||' day') ");
			consulta.append("AND CLI.ClienteClave = '" + clienteClave + "' ");

			return BDVend.consultar(consulta.toString());
		}

		public static boolean existenVentasPosteriores(String clienteClave, String abnid, short tipoCobranza) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			short trueType;
			if (tipoCobranza == 2)
				trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(clienteClave);
			else
				trueType = tipoCobranza;

			if (trueType == 1)
				trueType = 1;
			else if (trueType == 0)
				trueType = 8;

			consulta.append("SELECT COUNT(TransProdId) AS Ventas ");
			consulta.append("FROM TransProd TRP ");
			consulta.append("INNER JOIN Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
			consulta.append("INNER JOIN Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("WHERE Tipo in (" + trueType + ", 24) and TipoFase <> 0 ");
			consulta.append("AND CLI.ClienteClave = '" + clienteClave + "' ");
			consulta.append("AND FechaHoraAlta > (SELECT FechaAbono FROM Abono WHERE ABNId = '" + abnid + "') ");

			return (BDVend.bd.ejecutarEscalarInteger(consulta.toString()) > 0);
		}

		public static float obtenerSaldoCliente(String ClienteClave) throws Exception
		{
			ISetDatos datos = BDVend.consultar("SELECT case when sum(total) is null then 0 else sum(total) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave inner join ModuloMovDetalle MMD on TRP.PCEModuloMovDetClave = MMD.ModuloMovDetalleClave WHERE v.ClienteClave = '" + ClienteClave + "' AND (MMD.TipoIndice = 9  AND CFVTipo = 2) AND TipoFase = 1");
			float res = 0;
			if (datos.moveToNext())
			{
				res = datos.getFloat(0);
			}
			datos.close();
			return res;
		}

		public static float obtenerSaldoCobrarVentas(Cliente oCliente) throws Exception
		{
			ISetDatos datos;
			if (oCliente.ActualizaSaldoCheque)
			{
				datos = BDVend.consultar("SELECT case when sum(saldo) is null then 0 else sum(saldo) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND ((Tipo = 1 AND CFVTipo = 2) OR Tipo = 24) AND TipoFase <> 0");
			}
			else
			{
				datos = BDVend.consultar("SELECT case when sum(saldo+(Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END)) is null then 0 else sum(saldo+(Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END)) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave Left Join (Select TRPCheque.TransProdID,sum(AbnCheque) as AbnCheque from TRPCheque  group by TRPCheque.TransProdID) TRC on TRC.TransProdID = TRP.TransProdID WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND ((Tipo = 1 AND CFVTipo = 2) OR Tipo = 24) AND TipoFase > 0");
			}
			float res = 0;
			if (datos.moveToNext())
			{
				res = datos.getFloat(0);
			}
			datos.close();
			return res;
		}
		
		public static float obtenerSaldoPedidosConsignaciones(Cliente oCliente) throws Exception
		{
			ISetDatos datos;
			datos = BDVend.consultar("SELECT case when sum(saldo) is null then 0 else sum(saldo) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND ((Tipo = 1 AND CFVTipo = 2) OR Tipo = 24) AND TipoFase <> 0");
			float res = 0;
			if (datos.moveToNext())
			{
				res = datos.getFloat(0);
			}
			datos.close();
			return res;
		}
		
		public static float obtenerSaldoConsignasLiquidadas(Cliente oCliente) throws Exception
		{
			ISetDatos datos;
			ISetDatos datos2;
				datos = BDVend.consultar("SELECT case when sum(saldo) is null then 0 else sum(saldo) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND ((Tipo = 8 AND CFVTipo = 2) or Tipo = 24) AND TipoFase <> 0");
				datos2 = BDVend.consultar("SELECT case when sum(saldo) is null then 0 else sum(saldo) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND Tipo = 1 AND CFVTipo = 2 AND TipoFase <> 0 AND FacturaId is null");
			float res = 0;
			if (datos.moveToNext())
			{
				res = datos.getFloat(0);
			}
			if (datos2.moveToNext())
			{
				res += datos2.getFloat(0);
			}
			datos.close();
			datos2.close();
			return res;
		}

		public static float obtenerSaldoNoCobrarVentas(Cliente oCliente) throws Exception
		{
			ISetDatos datos;
			ISetDatos datos2;
			if (oCliente.ActualizaSaldoCheque)
			{
				datos = BDVend.consultar("SELECT case when sum(saldo) is null then 0 else sum(saldo) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND ((Tipo = 8 AND CFVTipo = 2) or Tipo = 24) AND TipoFase > 0");
				datos2 = BDVend.consultar("SELECT case when sum(saldo) is null then 0 else sum(saldo) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND Tipo = 1 AND CFVTipo = 2 AND TipoFase <> 0 AND FacturaId is null");
			}
			else
			{
				datos = BDVend.consultar("SELECT case when sum(saldo+(Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END)) is null then 0 else sum(saldo+(Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END)) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave Left Join (Select TRPCheque.TransProdID,sum(AbnCheque) as AbnCheque from TRPCheque  group by TRPCheque.TransProdID) TRC on TRC.TransProdID = TRP.TransProdID WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND ((Tipo = 8 AND CFVTipo = 2) or Tipo = 24) AND TipoFase > 0");
				datos2 = BDVend.consultar("SELECT case when sum(total) is null then 0 else sum(total) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND Tipo = 1 AND CFVTipo = 2 AND TipoFase > 0 AND FacturaId is null");
			}
			float res = 0;
			if (datos.moveToNext())
			{
				res = datos.getFloat(0);
			}
			if (datos2.moveToNext())
			{
				res += datos2.getFloat(0);
			}
			datos.close();
			datos2.close();
			return res;
		}

		public static int obtenerVentasVencidas(Cliente oCliente, short tipoMov) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			int resultado = 0;
			if (oCliente.ActualizaSaldoCheque)
			{
				consulta.append("select case when sum(saldo) is null then 0 else sum(saldo) end From transprod tr ");
				consulta.append("inner join visita v on v.visitaclave = TR.visitaclave and v.diaClave = TR.Diaclave ");
				consulta.append("where tr.FechaCobranza < datetime('now','-" + oCliente.DiasVencimiento + " day') and ");
				consulta.append("v.clienteclave = '" + oCliente.ClienteClave + "' and ");
				consulta.append("(tr.tipo =" + tipoMov + ") and tr.VisitaClave <> '" + ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave + "'  and tr.TipoFase <>0 ");
			}
			else
			{
				consulta.append("select case when sum(saldo+(Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END)) is null then 0 else sum(saldo+(Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END)) end From transprod tr ");
				consulta.append("inner join visita v on v.visitaclave = TR.visitaclave and v.diaClave = TR.Diaclave ");
				consulta.append("left Join (Select TRPCheque.TransProdID,sum(AbnCheque) as AbnCheque from TRPCheque  group by TRPCheque.TransProdID) TRC on TRC.TransProdID = TR.TransProdID ");
				consulta.append("where tr.FechaCobranza < datetime('now','-" + oCliente.DiasVencimiento + " day') and ");
				consulta.append("v.clienteclave = '" + oCliente.ClienteClave + "' and ");
				consulta.append("(tr.tipo =" + tipoMov + ") and tr.VisitaClave <> '" + ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave + "'  and tr.TipoFase <>0 ");
			}
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if (datos.moveToNext())
			{
				resultado = datos.getInt(0);
			}
			datos.close();
			return resultado;
		}

		//obtener todo el listado de documentos a imprimir para actividad ImprimirTicket
		public static ISetDatos obtenerTransProdAImprimir(String lstTrpTipo, int tipoModulo, String clienteClave, String visitaClave, String diaClave, String TransProdIDs)
		{
			try
			{
				StringBuilder sConsulta = new StringBuilder();

				sConsulta.append("Select TransProd.TransProdId as _Id, TransProd.Tipo as Tipo, 'TRPTIPO' as VARCodigo,'TRP' as TipoRecibo, TransProd.Folio as Folio, '' as DescTipo,strftime( '%d/%m/%Y', CASE WHEN TransProd.Tipo = 8 THEN TransProd.FechaFacturacion ELSE TransProd.FechaCaptura END) as Fecha, TransProd.Total as Total, TransProd.TipoFase as TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as DiaClave, TransProd.SubEmpresaID as SubEmpresaID, ifnull( TDF.TransProdId, 0) as FacElec ");
				sConsulta.append("From TransProd LEFT JOIN Visita ON TransProd.VisitaClave = Visita.VisitaClave LEFT JOIN TRPDatoFiscal TDF on TDF.TransProdId = TransProd.TransProdId   ");
				sConsulta.append("WHERE TransProd.Tipofase <> 0  ");
				sConsulta.append("AND Transprod.TransProdID in (" + TransProdIDs + ")");
				sConsulta.append("AND TransProd.Tipo in (" + lstTrpTipo + ") ");
				sConsulta.append("AND Visita.ClienteClave='" + clienteClave + "' ");
				/* Comentar para que obtenga los documentos a imprimir no solo cuando estoy en la visita de los transprod */
//				sConsulta.append("AND Visita.VisitaClave='" + visitaClave + "' ");
//				sConsulta.append("AND Visita.DiaClave='" + diaClave + "'");
				if (tipoModulo == Enumeradores.TiposModulos.REPARTO)
				{
					sConsulta.append(" UNION ");
					sConsulta.append("Select TransProd.TransProdId as _Id, TransProd.Tipo as Tipo, 'TRPTIPO' as VARCodigo, 'TRP' as TipoRecibo, TransProd.Folio as Folio, '' as DescTipo, strftime( '%d/%m/%Y',CASE WHEN TransProd.Tipo = 8 THEN TransProd.FechaFacturacion ELSE TransProd.FechaCaptura END) as Fecha, TransProd.Total as Total, TransProd.TipoFase as TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as DiaClave, TransProd.SubEmpresaID as SubEmpresaID, 0 as FacElec ");
					sConsulta.append("From TransProd INNER JOIN Visita ON ");
					sConsulta.append("TransProd.VisitaClave1 = Visita.VisitaClave AND TransProd.DiaClave1 = Visita.DiaClave  ");
					sConsulta.append("WHERE Visita.ClienteClave='" + clienteClave + "' and TransProd.Tipofase <> 0 ");
					sConsulta.append("AND Transprod.TransProdID in (" + TransProdIDs + ")");
				}
				sConsulta.append(" UNION ");
				sConsulta.append("select Abono.ABNId as _Id, 10 as Tipo, 'TRECIBO' as VARCodigo,  'ABN' as TipoRecibo, Abono.Folio as Folio ,'' as DescTipo, strftime( '%d/%m/%Y',FechaAbono) as Fecha, Abono.Total as Total, null as TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as DiaClave, '' as SubEmpresaID , 0 as FacElec ");
				sConsulta.append("from Abono inner join Visita on ");
				sConsulta.append("Abono.visitaclave=Visita.visitaclave ");
				sConsulta.append("where visita.clienteclave='" + clienteClave + "' ");
				sConsulta.append("and visita.diaclave='" + diaClave + "'");

				return BDVend.consultar(sConsulta.toString());
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

		public static ISetDatos obtenerTransProdAImprimir(String TransProdIDs)
		{
			try
			{
				StringBuilder sConsulta = new StringBuilder();

				sConsulta.append("Select TransProd.TransProdId as _Id, TransProd.Tipo as Tipo, 'TRPTIPO' as VARCodigo,'TRP' as TipoRecibo, TransProd.Folio as Folio, '' as DescTipo,strftime( '%d/%m/%Y', CASE WHEN TransProd.Tipo = 8 THEN TransProd.FechaFacturacion ELSE TransProd.FechaCaptura END) as Fecha, TransProd.Total as Total, TransProd.TipoFase as TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as DiaClave, TransProd.SubEmpresaID as SubEmpresaID, ifnull( TDF.TransProdId, 0) as FacElec ");
				sConsulta.append("From TransProd LEFT JOIN Visita ON TransProd.VisitaClave = Visita.VisitaClave LEFT JOIN TRPDatoFiscal TDF on TDF.TransProdId = TransProd.TransProdId   ");
				sConsulta.append("WHERE TransProd.Tipofase <> 0  ");
				sConsulta.append("AND Transprod.TransProdID in (" + TransProdIDs + ") ");
                //ordenar para que salgan las ventas/pedidos primero en caso de existir una devolucion
                if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.PREVENTA){
                    sConsulta.append("ORDER BY Transprod.Tipo ASC");
                }
				
				return BDVend.consultar(sConsulta.toString());
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

        public static String obtenerTransProdPorFacturaID(String FacturaID)
        {
            try
            {
                StringBuilder sConsulta = new StringBuilder();

                sConsulta.append("Select TransProd.TransProdId as TransProdId ");
                sConsulta.append("From TransProd ");
                sConsulta.append("WHERE Transprod.FacturaID in (" + FacturaID + ")  ");

                ISetDatos datos = BDVend.consultar(sConsulta.toString());
                String res = "";
                if (datos.moveToNext())
                {
                    res = datos.getString(0);
                }
                datos.close();
                return res;
            }
            catch (Exception ex)
            {
                ex.printStackTrace();
                return null;
            }
        }

		public static ISetDatos obtenerTransProdAImprimirMovInventario(String lstTrpTipo, String diaClave, String TransProdIDs)
		{
			try
			{
				StringBuilder sConsulta = new StringBuilder();

				sConsulta.append("Select TransProd.TransProdId as _Id, TransProd.Tipo as Tipo, 'TRPTIPO' as VARCodigo,'TRP' as TipoRecibo, TransProd.Folio as Folio, '' as DescTipo,strftime( '%d/%m/%Y', CASE WHEN TransProd.Tipo = 8 THEN TransProd.FechaFacturacion ELSE TransProd.FechaCaptura END) as Fecha, TransProd.Total as Total, TransProd.TipoFase as TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as DiaClave, TransProd.SubEmpresaID as SubEmpresaID, ifnull( TDF.TransProdId, 0) as FacElec ");
				sConsulta.append("From TransProd LEFT JOIN Visita ON TransProd.VisitaClave = Visita.VisitaClave LEFT JOIN TRPDatoFiscal TDF on TDF.TransProdId = TransProd.TransProdId   ");
				sConsulta.append("WHERE TransProd.Tipofase <> 0  ");
				sConsulta.append("AND Transprod.TransProdID in ('" + TransProdIDs + "')");
				if (!lstTrpTipo.equals(""))
				{
					sConsulta.append(" AND TransProd.Tipo in (" + lstTrpTipo + ") ");
				}
				sConsulta.append(" AND TransProd.DiaClave='" + diaClave + "'");

				return BDVend.consultar(sConsulta.toString());
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
				return null;
			}
		}

		public static Cursor obtenerPedidoSugerido(String clienteClave, int frecuenciaDia, String precioClave, String transProdIds, ArrayList<Integer> tipoPedido, boolean soloConPrecio, String filtrosExistencia) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			ISetDatos dsProducto;
			int nTipoPedido = 1; // Pedido sugerido

			sConsulta.append("select PRS.ProductoClave as _id, PRS.ProductoClave as ProductoClave, PRS.ProductoClave || ' - ' || PRO.Nombre as Producto, PRO.DecimalProducto as DecimalProducto, PRS.PRUTipoUnidad as PRUTipoUnidad, PRS.Cantidad as Sugerido, PPV.Precio as Precio  " + ((transProdIds != null && transProdIds.length() > 0) ? ",TPD.Cantidad as Cantidad " : ""));
			sConsulta.append("from PedidoSugerido PRS ");
			sConsulta.append("inner join Producto PRO on PRS.ProductoClave = PRO.ProductoClave ");
			sConsulta.append("inner join ProductoUnidad PDE on PDE.ProductoClave = PRO.ProductoClave and PDE.PRUTipoUnidad = PRS.PRUTipoUnidad ");
			sConsulta.append((soloConPrecio ? "inner " : "left ") + " join PrecioProductoVig PPV on PPV.ProductoClave = PRS.ProductoClave and PPV.PRUTipoUnidad = PRS.PRUTipoUnidad and PPV.PrecioClave in(" + precioClave + ") ");
			sConsulta.append("and DATETIME('now')  between PPV.PPVFechaInicio and PPV.FechaFin ");
			if (transProdIds != null && transProdIds.length() > 0)
			{
				sConsulta.append("left join TransProdDetalle TPD on TPD.TransProdId in(" + transProdIds + ") and TPD.ProductoClave = PRS.ProductoClave and TPD.TipoUnidad=PRS.PRUTipoUnidad ");
			}
			sConsulta.append("where PRS.ClienteClave = '" + clienteClave + "' and PRS.Frecuencia = " + frecuenciaDia);
			if (filtrosExistencia.length() > 0)
			{
				sConsulta.append(" and not(" + filtrosExistencia + ")");
			}

			dsProducto = BDVend.consultar(sConsulta.toString());

			if (dsProducto.getCount() == 0)
			{
				nTipoPedido = 2; // Producto prioritario

				ArrayList<String> aEsquemas = Clientes.recuperarEsquemasPPE(clienteClave);
				if (!aEsquemas.isEmpty())
				{
					sConsulta = new StringBuilder();
					sConsulta.append("select PPE.ProductoClave as _id, PPE.ProductoClave as ProductoClave,PPE.ProductoClave || ' - ' || PRO.Nombre as Producto, PRO.DecimalProducto as DecimalProducto, PDE.PRUTipoUnidad as PRUTipoUnidad, 1 as Sugerido, PPV.Precio as Precio " + ((transProdIds != null && transProdIds.length() > 0) ? ",TPD.Cantidad as Cantidad " : ""));

					sConsulta.append("from ProductoPrioritarioEsq PPE ");
					sConsulta.append("inner join Producto PRO on PPE.ProductoClave = PRO.ProductoClave ");
					sConsulta.append("inner join ProductoDetalle PDE on PPE.ProductoClave = PDE.ProductoClave and PPE.ProductoClave = PDE.ProductoDetClave and PDE.Factor in ");
					sConsulta.append("(Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave in(" + precioClave + "))");
					sConsulta.append((soloConPrecio ? "inner " : "left ") + " join PrecioProductoVig PPV on PPV.ProductoClave = PPE.ProductoClave and PPV.PRUTipoUnidad = PDE.PRUTipoUnidad and PPV.PrecioClave in(" + precioClave + ") ");
					sConsulta.append("and DATETIME('now')  between PPV.PPVFechaInicio and PPV.FechaFin ");
					if (transProdIds != null && transProdIds.length() > 0)
					{
						sConsulta.append("left join TransProdDetalle TPD on TPD.TransProdId in(" + transProdIds + ") and TPD.ProductoClave = PPE.ProductoClave and TPD.TipoUnidad=PDE.PRUTipoUnidad ");
					}

					sConsulta.append("where PPE.EsquemaID in (" + aEsquemas.toString().replace("[", "").replace("]", "") + ") and PPE.ProductoClave not in( ");
					sConsulta.append("select ProductoClave ");
					sConsulta.append("from ExcepcionProductoPri ");
					sConsulta.append("where ClienteClave = '" + clienteClave + "' and TipoExcepcion = 2) ");
					if (filtrosExistencia.length() > 0)
					{
						sConsulta.append(" and not(" + filtrosExistencia + ")");
					}
					sConsulta.append("union ");
					sConsulta.append("select EPP.ProductoClave as _Id, EPP.ProductoClave as ProductoClave,  EPP.ProductoClave || ' - ' || PRO.Nombre as Producto, PRO.DecimalProducto as DecimalProducto, PDE.PRUTipoUnidad as PRUTipoUnidad, 1 as Sugerido, PPV.Precio as Precio " + ((transProdIds != null && transProdIds.length() > 0) ? ",TPD.Cantidad as Cantidad " : ""));

					sConsulta.append("from ExcepcionProductoPri EPP ");
					sConsulta.append("inner join Producto PRO on EPP.ProductoClave = PRO.ProductoClave ");
					sConsulta.append("inner join ProductoDetalle PDE on EPP.ProductoClave = PDE.ProductoClave and EPP.ProductoClave = PDE.ProductoDetClave and PDE.Factor in ");
					sConsulta.append("(Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave in(" + precioClave + "))");
					sConsulta.append((soloConPrecio ? "inner " : "left ") + " join PrecioProductoVig PPV on PPV.ProductoClave = EPP.ProductoClave and PPV.PRUTipoUnidad = PDE.PRUTipoUnidad and PPV.PrecioClave in(" + precioClave + ") ");
					sConsulta.append("and DATETIME('now')  between PPV.PPVFechaInicio and PPV.FechaFin ");
					if (transProdIds != null && transProdIds.length() > 0)
					{
						sConsulta.append("left join TransProdDetalle TPD on TPD.TransProdId in(" + transProdIds + ") and TPD.ProductoClave = EPP.ProductoClave and TPD.TipoUnidad=PDE.PRUTipoUnidad ");
					}

					sConsulta.append("where EPP.ClienteClave = '" + clienteClave + "' and EPP.TipoExcepcion = 1 ");
					if (filtrosExistencia.length() > 0)
					{
						sConsulta.append(" and not(" + filtrosExistencia + ")");
					}
				}
				else
				{
					sConsulta = new StringBuilder();
					sConsulta.append("select EPP.ProductoClave as _id,  EPP.ProductoClave as ProductoClave, EPP.ProductoClave || ' - ' || PRO.Nombre as Producto, PRO.DecimalProducto as DecimalProducto, PDE.PRUTipoUnidad as PRUTipoUnidad, 1 as Sugerido, PPV.Precio as Precio " + ((transProdIds != null && transProdIds.length() > 0) ? ",TPD.Cantidad as Cantidad " : ""));

					sConsulta.append(" from ExcepcionProductoPri EPP ");
					sConsulta.append("inner join Producto PRO on EPP.ProductoClave = PRO.ProductoClave ");
					sConsulta.append("inner join ProductoDetalle PDE on EPP.ProductoClave = PDE.ProductoClave and EPP.ProductoClave = PDE.ProductoDetClave and PDE.Factor in ");
					sConsulta.append("(Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave in(" + precioClave + "))");
					sConsulta.append((soloConPrecio ? "inner " : "left ") + " join PrecioProductoVig PPV on PPV.ProductoClave = EPP.ProductoClave and PPV.PRUTipoUnidad = PDE.PRUTipoUnidad and PPV.PrecioClave in(" + precioClave + ") ");
					sConsulta.append("and DATETIME('now')  between PPV.PPVFechaInicio and PPV.FechaFin ");
					if (transProdIds != null && transProdIds.length() > 0)
					{
						sConsulta.append("left join TransProdDetalle TPD on TPD.TransProdId in(" + transProdIds + ") and TPD.ProductoClave = EPP.ProductoClave and TPD.TipoUnidad=PDE.PRUTipoUnidad ");
					}
					sConsulta.append("where EPP.ClienteClave = '" + clienteClave + "' and EPP.TipoExcepcion = 1 ");
					if (filtrosExistencia.length() > 0)
					{
						sConsulta.append(" and not(" + filtrosExistencia + ")");
					}
				}

			}
			dsProducto.close();
			tipoPedido.add(nTipoPedido);
			return (Cursor) BDVend.consultar(sConsulta.toString()).getOriginal(); // dsProducto;
		}
		
		public static float obtenerEfectivo(Abono abono) throws Exception
		{
			ISetDatos datos = BDVend.consultar("SELECT SUM(Importe) FROM ABNDetalle where TipoPago = 1 And ABNId='" + abono.ABNId + "'");
			float res = 0;
			if (datos.moveToNext())
			{
				res = datos.getFloat(0);
			}
			datos.close();
			return res;
		}
		
		public static String obtenerInventarioABordo(Date fechaMinima, Date fechaMaxima) throws Exception{
			ISetDatos datos = BDVend.consultar("Select TransProdID from TransProd where Tipo = 23 and FechaCaptura between '" + Generales.getFormatoFecha(fechaMinima, "yyyy-MM-dd HH:mm:ss") +  "' and '" + Generales.getUltimaHora(fechaMaxima, "yyyy-MM-dd HH:mm:ss") +  "' ");
			String res = "";
			if (datos.moveToNext())
			{
				res = datos.getString(0);
			}
			datos.close();
			return res;			
		}
		
		public static String obtenerDescargaAutomatica(Date fechaMinima, Date fechaMaxima) throws Exception{
			ISetDatos datos = BDVend.consultar("Select TransProdID from TransProd where Tipo = 7 and FechaCaptura between '" + Generales.getFormatoFecha(fechaMinima, "yyyy-MM-dd HH:mm:ss") +  "' and '" + Generales.getUltimaHora(fechaMaxima, "yyyy-MM-dd HH:mm:ss") +  "' ");
			String res = "";
			if (datos.moveToNext())
			{
				res = datos.getString(0);
			}
			datos.close();
			return res;	
		}
		
		/**
		 * Obtiene de la base de datos las transaciones que pertenecen al tipo 24 (Consignaciones), posteriormente 
		 * las empaqueta en una estructura más pequeña (VistaConsignacion) con los datos minimos requeridos para el proceso.
		 * @param cliente El cliente al que se le realiza la consignacion
		 * @return Array de vistas-consignacion
		 * @throws Exception
		 */
		public static SeleccionarConsignacion.VistaConsignacion[] obtenerConsignacionesPorCliente(Cliente cliente) throws Exception
		{
			ArrayList<SeleccionarConsignacion.VistaConsignacion> consignaciones = new ArrayList<SeleccionarConsignacion.VistaConsignacion>();
			StringBuilder consulta = new StringBuilder();
			ISetDatos fases = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
			consulta.append("select TRP.TransProdID,TRP.Folio,TRP.TipoFase,TRP.FechaCaptura,TRP.DiaClave,TRP.VisitaClave,TRP.Enviado,TRP.Tipo,TRP.Total,TRP.Saldo ");
			consulta.append("from TransProd TRP ");
			consulta.append("where TRP.Tipo in (24) ");
			consulta.append("and TRP.ClienteClave = '" + cliente.ClienteClave + "'");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				int fase = datos.getInt(2) + 1;
				fases.moveToPosition(fase - 1);
				SeleccionarConsignacion.VistaConsignacion consignacion = new SeleccionarConsignacion.VistaConsignacion();
				consignacion.TransProdId = datos.getString(0);
				consignacion.Folio = datos.getString(1);
				consignacion.Tipofase = datos.getInt(2);
				consignacion.FechaCreacion = datos.getDate(3);
				consignacion.DiaClave = datos.getString(4);
				consignacion.VisitaClave = datos.getString(5);
				consignacion.Enviado = datos.getBoolean(6);
				consignacion.Tipo = datos.getInt(7);
				consignacion.Total = datos.getFloat(8);
				consignacion.Saldo = datos.getFloat(9);
				consignacion.Fase = fases.getString(2);
				consignaciones.add(consignacion);
			}

			fases.close();
			datos.close();

			return consignaciones.toArray(new SeleccionarConsignacion.VistaConsignacion[consignaciones.size()]);
		}
		
		public static ISetDatos obtenerTotalVentasCostena() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(ifnull(TPD.Total,0)) as Total, ESQ.Clasificacion ");
			consulta.append("from Esquema ESQ ");
			consulta.append("inner join ProductoEsquema PRE on PRE.EsquemaID = ESQ.EsquemaID ");
			consulta.append("left join TransProdDetalle TPD on TPD.ProductoClave = PRE.ProductoClave ");
			consulta.append("left join TransProd TRP on TRP.TransProdID = TPD.TransProdID ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 2 ");
			consulta.append("group by ESQ.Clasificacion ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerTotalPedidosCostena(Short tipoTransProd, String tipoFase, Boolean GrupoMasivo) throws Exception{
            StringBuilder consulta = new StringBuilder();
            if (!GrupoMasivo) {
               /* String tipoTransprod = "0";
                if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA) {
                    tipoTransprod = "1";
                } else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) {
                    tipoTransprod = "21";
                }*/

                consulta.append("select SUM(ifnull(TPD.Total,0)) as Total, ESQ.Clasificacion ");
                consulta.append("from Esquema ESQ ");
                consulta.append("inner join ProductoEsquema PRE on PRE.EsquemaID = ESQ.EsquemaID ");
                consulta.append("left join TransProdDetalle TPD on TPD.ProductoClave = PRE.ProductoClave ");
                consulta.append("left join TransProd TRP on TRP.TransProdID = TPD.TransProdID ");
                consulta.append("where TRP.TransProdID is null or (TRP.Tipo = " + tipoTransProd.toString() + " and TRP.TipoFase = " + tipoFase + ") ");
                consulta.append("group by ESQ.Clasificacion ");
            }else{
                consulta.append("Select SUM(ifnull(TPD.Total,0)) as Total, SUM(ifnull(TPD.Cantidad,0)/ifnull(PRD.Factor, 1)) as Cajas, ESQ.Clasificacion ");
                consulta.append("from Esquema ESQ ");
                consulta.append("inner join ProductoEsquema PRE on PRE.EsquemaID = ESQ.EsquemaID ");
                consulta.append("left join TransProdDetalle TPD on TPD.ProductoClave = PRE.ProductoClave ");
                consulta.append("left join TransProd TRP on TRP.TransProdID = TPD.TransProdID ");
                consulta.append("left join Dia on TRP.DiaClave = Dia.DiaClave and Dia.FueraFrecuencia = 0 ");
                consulta.append("left join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and PRD.PRUTipoUnidad = 3 ");
                consulta.append(" where TRP.TransProdID is null or (TRP.Tipo = 1 and TRP.TipoFase in(12,13)) ");
                consulta.append("group by ESQ.Clasificacion ");
            }
			return BDVend.consultar(consulta.toString());
        }
		
		public static ISetDatos obtenerTotalMSIEV() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("where TRP.Tipo = 21 and TRP.TipoFase = 1 ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerNotasVentaCanceladas() throws Exception{
            String organizacionVentas = "MX";
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
                organizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
            }
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave AND (TRP.VisitaClave1 IS NULL AND TRP.DiaClave1 IS NULL)");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 0 and CLI.Clave not like '" + organizacionVentas + "%' ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerNotasVentaCanceladasOp() throws Exception{
            String organizacionVentas = "MX";
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
                organizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
            }
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave AND (TRP.VisitaClave1 IS NULL AND TRP.DiaClave1 IS NULL)");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 0 and CLI.Clave like '" + organizacionVentas + "%' ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerPedidosCanceladosCostena() throws Exception{
            String organizacionVentas = "MX";
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
                organizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
            }
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave AND (TRP.VisitaClave1 IS NOT NULL AND TRP.DiaClave1 IS NOT NULL)");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 0 and CLI.Clave not like '" + organizacionVentas + "%' ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerPedidosCanceladosCostenaOp() throws Exception{
            String organizacionVentas = "MX";
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
                organizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
            }
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave AND (TRP.VisitaClave1 IS NOT NULL AND TRP.DiaClave1 IS NOT NULL)");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 0 and CLI.Clave like '" + organizacionVentas + "%' ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerMSIEVCancelados() throws Exception{
            String organizacionVentas = "MX";
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
                organizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
            }
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = 21 and TRP.TipoFase = 0 and CLI.Clave not like '" + organizacionVentas + "%' ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerMSIEVCanceladosOp() throws Exception{
            String organizacionVentas = "MX";
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
                organizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
            }
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = 21 and TRP.TipoFase = 0 and CLI.Clave like '" + organizacionVentas + "%' ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerPedidosCancelados() throws Exception{
			String tipoTransprod = "0";
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA){
				tipoTransprod = "1";
			}else if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				tipoTransprod = "21";
			}
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("where TRP.Tipo = "+tipoTransprod+" and TRP.TipoFase = 0 ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerPedidosCanceladosOp() throws Exception{
			String tipoTransprod = "0";
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA){
				tipoTransprod = "1";
			}else if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				tipoTransprod = "21";
			}
            String organizacionVentas = "MX";
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
                organizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
            }
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = "+tipoTransprod+" and TRP.TipoFase = 0 and CLI.Clave like '" + organizacionVentas + "%' ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerPedidosDelDia() throws Exception{
			String tipoTransprod = "0";
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA){
				tipoTransprod = "1";
			}else if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				tipoTransprod = "21";
			}
            String organizacionVentas = "MX";
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
                organizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
            }
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = "+tipoTransprod+" and TRP.TipoFase = 1 and CLI.Clave not like '" + organizacionVentas + "%' and VIS.FueraFrecuencia = 0 ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerTotalVentas() throws Exception{
            String organizacionVentas = "MX";
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
                organizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
            }
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 2 and CLI.Clave not like '" + organizacionVentas + "%' and VIS.FueraFrecuencia = 0 ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerPedidosOp() throws Exception{
			String tipoTransprod = "0";
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA){
				tipoTransprod = "1";
			}else if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				tipoTransprod = "21";
			}
            String organizacionVentas = "MX";
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
                organizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
            }
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = "+tipoTransprod+" and TRP.TipoFase = 1 and CLI.Clave like '" + organizacionVentas + "%' ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerVentasOp() throws Exception{
            String organizacionVentas = "MX";
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
                organizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
            }
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 2 and CLI.Clave like '" + organizacionVentas + "%' ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerPedidosFueraFrecuencia() throws Exception{
			String tipoTransprod = "0";
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA){
				tipoTransprod = "1";
			}else if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				tipoTransprod = "21";
			}
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("where TRP.Tipo = "+tipoTransprod+" and TRP.TipoFase = 1 and VIS.FueraFrecuencia = 1 ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerVentasFueraFrecuencia() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 2 and VIS.FueraFrecuencia = 1 ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerPedidosContado() throws Exception{
			String tipoTransprod = "0";
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA){
				tipoTransprod = "1";
			}else if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				tipoTransprod = "21";
			}
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("where TRP.Tipo = "+tipoTransprod+" and TRP.TipoFase = 1 and TRP.CFVTipo = 1 ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerVentasContado() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 2 and TRP.CFVTipo = 1 ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerPedidosCredito() throws Exception{
			String tipoTransprod = "0";
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA){
				tipoTransprod = "1";
			}else if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
				tipoTransprod = "21";
			}
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("where TRP.Tipo = "+tipoTransprod+" and TRP.TipoFase = 1 and TRP.CFVTipo = 2 ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerVentasCredito() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 2 and TRP.CFVTipo = 2 ");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}

		public static float obtenerTotalPedidosPosfechados() throws Exception
		{
			float total = 0;
			StringBuilder consulta = new StringBuilder();
			consulta.append("select ifnull(sum(Total),0) ");
			consulta.append("from TransProd where Tipo = 21 and TipoFase = 1");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				total = datos.getFloat(0);
			}
			datos.close();
			return total;
		}
		
		public static List<TransProdFactura> obtenerFacturasPorVisita(Visita visitaActual) throws Exception{
			List<TransProdFactura> list = new ArrayList<TransProdFactura>();
			TransProdFactura fac = null;
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TransProdID, SE.SubEmpresaId, Folio, Tipo, TipoFase, FechaCaptura, TP.Enviado, SE.NombreCorto FROM TransProd as TP inner join Visita as V ").
			append("on V.VisitaClave = TP.VisitaClave ").
			append("inner join SubEmpresa as SE on SE.SubEmpresaId = TP.SubEmpresaId WHERE TP.Tipo = 8 AND ").
			append("TP.VisitaClave ='").append(visitaActual.VisitaClave).append("'");
			
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if(datos != null && datos.getCount()>0){
				while(datos.moveToNext())
				{
					fac = new TransProdFactura();
					fac.TransProdId = datos.getString("TransProdID");
					fac.SubEmpresaID = datos.getString("SubEmpresaId");
					fac.Folio = datos.getString("Folio");
					fac.TipoFase = datos.getInt("TipoFase");
					fac.Fase = ValoresReferencia.getDescripcion("TRPFASE", datos.getString("TipoFase"));
					fac.FechaCaptura = datos.getDate("FechaCaptura");
					fac.Enviado = datos.getBoolean("Enviado");
					fac.NombreCorto = datos.getString("NombreCorto");
					list.add(fac);
				}
			}
			datos.close();
			return list;
		}
		
		public static List<Entidad> obtenerPedidosPorFacturar(Visita visita, Dia dia, Cliente cliente, int CFVTipo, String subEmpresaId) throws Exception{
			List<Entidad> list = new ArrayList<Entidad>();
			TransProd fac = null;
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TransProdID, SubEmpresaId, Folio, Tipo, TipoFase, FechaCaptura, TP.Enviado, CFVTipo, FechaSurtido, ").
			append("Subtotal, Impuesto, Total, Saldo, FechaCobranza ").
			append("FROM TransProd as TP inner join Visita as V ").
			append("on (V.VisitaClave = TP.VisitaClave) OR (V.VisitaClave = TP.VisitaClave1) WHERE TP.Tipo = 1 AND TP.TipoFase = 2 AND ").
			append("V.DiaClave ='").append(dia.DiaClave).append("' AND V.ClienteClave = '").append(cliente.ClienteClave).append("' AND ").
			append("V.VisitaClave = '").append(visita.VisitaClave).append("' AND TP.CFVTipo = ").
			append(CFVTipo).append(" AND SubEmpresaID = '").append(subEmpresaId).append("'");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if(datos != null){
				while(datos.moveToNext())
				{
					fac = new TransProd();
					fac.TransProdID = datos.getString("TransProdID");
					fac.SubEmpresaId = datos.getString("SubEmpresaId");
					fac.Folio = datos.getString("Folio");
					fac.Tipo = datos.getShort("Tipo");
					fac.TipoFase = datos.getShort("TipoFase");
					fac.Enviado = datos.getBoolean("Enviado");
					fac.CFVTipo = datos.getShort("CFVTipo");
					fac.FechaSurtido = datos.getDate("FechaSurtido");
					fac.Subtotal = datos.getFloat("Subtotal");
					fac.Impuesto = datos.getFloat("Impuesto");
					fac.Total = datos.getFloat("Total");
					fac.Saldo = datos.getFloat("Saldo");
					fac.FechaCobranza = datos.getDate("FechaCobranza");
					list.add(fac);
				}
			}
			datos.close();
			return list;
		}
		
		public static List<Entidad> obtenerPedidosDeFactura(String transProdId) throws Exception{
			List<Entidad> list = new ArrayList<Entidad>();
			TransProd fac = null;
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TransProdID, SubEmpresaId, Folio, Tipo, TipoFase, FechaCaptura, Enviado, CFVTipo, FechaSurtido, ").
			append("Subtotal, Impuesto, Total, Saldo, FechaCobranza ").
			append("FROM TransProd WHERE FacturaID = '").append(transProdId).append("'");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if(datos != null){
				while(datos.moveToNext())
				{
					fac = new TransProd();
					fac.TransProdID = datos.getString("TransProdID");
					fac.SubEmpresaId = datos.getString("SubEmpresaId");
					fac.Folio = datos.getString("Folio");
					fac.Tipo = datos.getShort("Tipo");
					fac.TipoFase = datos.getShort("TipoFase");
					fac.Enviado = datos.getBoolean("Enviado");
					fac.CFVTipo = datos.getShort("CFVTipo");
					fac.FechaSurtido = datos.getDate("FechaSurtido");
					fac.Subtotal = datos.getFloat("Subtotal");
					fac.Impuesto = datos.getFloat("Impuesto");
					fac.Total = datos.getFloat("Total");
					fac.Saldo = datos.getFloat("Saldo");
					fac.FechaCobranza = datos.getDate("FechaCobranza");
					list.add(fac);
				}
			}
			datos.close();
			return list;
		}
		
		public static boolean existenVentas(String DiaClave, String ClienteClave) throws Exception
		{
			boolean resultado = false;
			ISetDatos datos = BDVend.consultar("select VIS.VisitaClave from Visita VIS inner join TransProd TRP on VIS.VisitaClave = CASE WHEN  TRP.VisitaClave1 is null THEN TRP.VisitaClave  ELSE TRP.VisitaClave1 END and  VIS.DiaClave = CASE WHEN  TRP.DiaClave1 is null THEN TRP.DiaClave  ELSE TRP.DiaClave1 END where VIS.DiaClave = '" + DiaClave + "' and VIS.ClienteClave = '" + ClienteClave + "' and (TRP.Tipo = 1 or TRP.Tipo = 21 or TRP.Tipo = 24) ");
			if (datos.moveToNext())
			{
				resultado = true;
			}
			datos.close();
			return resultado;
		}
		
		public static ISetDatos obtenerTotalVentas(String rutas) throws Exception{
            String organizacionVentas = "MX";
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
                organizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
            }
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 2 and CLI.Clave not like '" + organizacionVentas + "%' and VIS.FueraFrecuencia = 0 and VIS.RUTClave in ("+rutas+")");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerPedidosPreventaParaReporte() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TP.TransProdID, TP.Folio, C.ClienteClave||'-'||C.RazonSocial as Cliente,").
			append("case when CD.ClienteDomicilioID is null then '' else ").
			append("(CD.ClienteDomicilioID || '-' || (case when CD.Calle is null then '' else CD.Calle end) || ' ' || (case when CD.Numero is null then '' else CD.Numero end) || ").
			append("(case when CD.NumInt is null then '' else ' INT ' || CD.NumInt end)) end as Domicilio,D.FechaCaptura,").
			append("case when TP.Enviado = 1 then 'Enviado' else 'Pendiente' end as Fase,TP.FechaEntrega,R.Descripcion as Ruta,").
			append("ifnull(SUM(TPD.Cantidad*PU.Volumen),0) as Volumen,").
			append("ifnull(SUM(TPD.Cantidad*PU.KgLts),0) as Peso,TP.Total as Monto ").
			append("FROM TransProd TP inner join Visita V on V.VisitaClave = TP.VisitaClave ").
			append("inner join Dia D on D.DiaClave = V.DiaClave and D.FueraFrecuencia = 0 ").
			append("left join Cliente C on C.ClienteClave = V.ClienteClave ").
			append("left join Ruta R on R.RUTClave = V.RUTClave ").
			append("left join ClienteDomicilio CD on CD.ClienteDomicilioId =  TP.ClienteDomicilioIdPE and CD.Tipo = 2 ").
			append("left join TransProdDetalle TPD on TPD.TransProdID = TP.TransProdID ").
			append("left join ProductoUnidad PU on PU.ProductoClave = TPD.ProductoClave and TPD.TipoUnidad = PU.PRUTipoUnidad and PU.TipoEstado = 1 ").
			append("WHERE TP.Tipo = 1 and TP.TipoFase = 1 ").
			append("GROUP BY TP.TransProdID ORDER BY TP.Folio");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerDetalleReporteCobranza(String clienteClave) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TP.Folio, TP.FacturaID, TP.TipoFase, TP.FechaCobranza, TP.FechaEntrega, TP.Total, TP.Saldo, CFV.DiasCredito FROM TransProd as TP ").
			append("INNER JOIN Cliente as C on C.ClienteClave = TP.ClienteClave AND C.ClienteClave = '").append(clienteClave).append("' ").
			append("INNER JOIN CLIFormaVenta as CFV on CFV.ClienteClave = C.ClienteClave AND CFV.CFVTipo = 2 ").
			append("WHERE TP.Saldo <> 0 AND TP.Tipo = 1 AND TP.TipoFase <> 0");
			
			return BDVend.consultar(consulta.toString());
		}

        public static ISetDatos obtenerFacturasReporteCobranza(String clienteClave) throws Exception{
            StringBuilder consulta = new StringBuilder();
            consulta.append("SELECT TP.Folio, TP.FacturaID, TP.TipoFase, TP.FechaCobranza, TP.FechaFacturacion, TP.Total, TP.Saldo, CFV.DiasCredito ").
                    append(" FROM TransProd as TP ").
                    append("INNER JOIN Visita VIS on VIS.VisitaClave = TP.VisitaClave and VIS.DiaClave = TP.DiaClave ").
                    append("INNER JOIN Cliente as C on C.ClienteClave = VIS.ClienteClave AND C.ClienteClave = '").append(clienteClave).append("' ").
                    append("INNER JOIN CLIFormaVenta as CFV on CFV.ClienteClave = C.ClienteClave AND CFV.CFVTipo = 2 ").
                    append("WHERE TP.Saldo <> 0 AND TP.Tipo = 8 AND TP.TipoFase <> 0");

            return BDVend.consultar(consulta.toString());
        }

		public static float obtenerTotalCobranza(String clienteClave) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT ifnull(SUM(TP.Saldo), 0) as SaldoTotal FROM TransProd as TP ").
			append("INNER JOIN Cliente as C on C.ClienteClave = TP.ClienteClave AND C.ClienteClave = '").append(clienteClave).append("' ").
			append("INNER JOIN CLIFormaVenta as CFV on CFV.ClienteClave = C.ClienteClave AND CFV.CFVTipo = 2 ").
			append("WHERE TP.Saldo <> 0 AND TP.Tipo = 1 AND TP.TipoFase <> 0");
			float saldo = 0;
			ISetDatos data = BDVend.consultar(consulta.toString());
			if(data.moveToNext()){
				saldo = data.getFloat("SaldoTotal");
			}
			data.close();
			return saldo;
		}

        public static ISetDatos obtenerDiferenciaEnvase(String sTransprodIds) throws Exception {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select t.ProductoDetClave, t.TipoUnidad, sum(VentaTotalLiquido) as VentaTotalLiquido, sum(VentaTotalEnvase) as VentaTotalEnvase, ");
			//consulta.append("printf('%.'||DecimalProducto||'f',(sum(VentaTotalLiquido)-sum(VentaTotalEnvase))) as Diferencia from ( ");
			consulta.append("(sum(VentaTotalLiquido)-sum(VentaTotalEnvase)) as Diferencia, DecimalProducto from ( ");
			consulta.append("select pd.ProductoDetClave, pu.PRUTipoUnidad as TipoUnidad, SUM(td.Cantidad) as VentaTotalLiquido, 0 as VentaTotalEnvase, pr.DecimalProducto ");
            consulta.append("from TransProdDetalle td ");
            consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.TipoUnidad=pd.PRUTipoUnidad and td.ProductoClave<>pd.ProductoDetClave and pd.Prestamo=1 ");
            consulta.append("inner join ProductoUnidad pu on pd.ProductoDetClave=pu.ProductoClave ");
			consulta.append("inner join Producto pr on pd.ProductoDetClave=pr.ProductoClave ");
            consulta.append("where td.TransProdID in (" + sTransprodIds + ") ");
            consulta.append("group by pd.ProductoDetClave, pu.PRUTipoUnidad ");
            consulta.append("union all ");
            consulta.append("select pd.ProductoDetClave,td.TipoUnidad, 0 as VentaTotalLiquido, SUM(Cantidad) as VentaTotalEnvase, pr.DecimalProducto ");
            consulta.append("from TransProdDetalle td ");
            consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.TipoUnidad=pd.PRUTipoUnidad and td.ProductoClave=pd.ProductoDetClave and pd.Prestamo=1 ");
			consulta.append("inner join Producto pr on pd.ProductoDetClave=pr.ProductoClave ");
            consulta.append("where td.TransProdID in (" + sTransprodIds + ") ");
            consulta.append("group by pd.ProductoDetClave,td.TipoUnidad ");
            consulta.append(") as t ");
            consulta.append("group by t.ProductoDetClave, t.TipoUnidad ");
            return BDVend.consultar(consulta.toString());
        }
        public static ISetDatos obtenerPedidosPagoAnticipado() throws Exception
        {
            String tiposPagoAnticipado = ValoresReferencia.getCadenaValores("PEDTIPO", "PagoAnticipado" );
            StringBuilder consulta = new StringBuilder();
            consulta.append("SELECT TRP.TransProdID as _id, (CASE WHEN IFNULL(TVA.Observaciones2, '') == '' THEN TRP.Folio ELSE TVA.Observaciones2 END) as Folio, TRP.TipoPedido as TipoPedido, TRP.TipoFase as TipoFase, datetime(TRP.FechaCaptura) as FechaCaptura, TRP.Subtotal as Subtotal, TRP.Impuesto as Impuesto, TRP.Total as Total, TRP.Saldo as Saldo, ");
            consulta.append("CLI.ClienteClave as ClienteClave, CLI.RazonSocial as RazonSocial, CLI.Clave as Clave ");
            consulta.append("FROM Transprod TRP ");
            consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
            consulta.append("inner join Cliente CLI on CLI.ClienteClave = VIS.ClienteClave ");
            consulta.append("left join TRPVtaAcreditada TVA on TRP.TransProdID = TVA.TransProdID ");
            consulta.append("where Tipo = 1 and TipoPedido in(" + tiposPagoAnticipado + ") ");
            return BDVend.consultar(consulta.toString());
        }

		public static ISetDatos obtenerClientesEnAgenda(String ruta, String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select  distinct c.RazonSocial,CASE WHEN e.VisitaClave is not null THEN 'Si' ELSE 'No' END Encuestado,c.ClienteClave  from Cliente c ")
					.append("inner join Agenda a on a.ClienteClave = c.ClienteClave and a.RUTClave = '" + ruta + "' ")
					.append("inner join Visita v on v.ClienteClave = c.ClienteClave and v.RUTClave = '" + ruta + "' and v.DiaClave = '" + diaClave + "' ")
					.append("left join Encuesta e on e.VisitaClave = v.VisitaClave and e.DiaClave = '" + diaClave + "' ");

			return  BDVend.consultar(consulta.toString());
		}


		public static ISetDatos obtenerDiasFrecuencia() throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select D.DiaClave from Dia D where D.FueraFrecuencia = 0 and date( substr(D.DiaClave, 7, 4) || '-' || substr(D.DiaClave, 4, 2) || '-' || substr(D.DiaClave, 1, 2) ) <= date('now')");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerConteoVisitadosEnFrecuencia(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct count(a.ClienteClave) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 0 and a.RUTClave = '" + ruta + "' ")
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 0 and v.RUTClave = '" + ruta + "' and v.DiaClave = '" + diaClave + "' ")
					.append("WHERE a.DiaClave = '" + diaClave + "' ");

			return  BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerConteoVisitadosNoFrecuencia(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select count(distinct(v.ClienteClave)) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 1 and a.RUTClave = '" + ruta + "' ")
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 1 and v.RUTClave = '" + ruta + "' and v.DiaClave = '" + diaClave + "' ");

			return  BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerConteoNoVisitadosEnFrecuencia(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct count(a.ClienteClave) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 0 and a.RUTClave = '" + ruta + "' ")
					.append("left join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 0 and v.RUTClave = '" + ruta + "' and v.DiaClave = '" + diaClave + "' ")
					.append("WHERE a.DiaClave = '" + diaClave + "' and v.VisitaClave is null ");

			return  BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerConteoVisitadosConVenta(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select count(distinct (a.ClienteClave)) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 0 and a.RUTClave = '" + ruta + "' ")
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 0 and v.RUTClave = '" + ruta + "' and v.DiaClave = '" + diaClave + "' ")
					.append("inner join TransProd t on t.VisitaClave = v.VisitaClave ")
					.append("WHERE a.DiaClave = '" + diaClave + "' ");

			return  BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerConteoVisitadosConVentaFueraFrecuencia(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select count(distinct(v.ClienteClave)) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 1 and a.RUTClave = '" + ruta + "' ")
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 1 and v.RUTClave = '" + ruta + "' and v.DiaClave = '" + diaClave + "' ")
					.append("inner join TransProd t on t.VisitaClave = v.VisitaClave ");

			return  BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerConteoVisitadosSinVenta(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct count(a.ClienteClave) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 0 and a.RUTClave = '" + ruta + "' ")
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 0 and v.RUTClave = '" + ruta + "' and v.DiaClave = '" + diaClave + "' ")
					.append("left join TransProd t on t.VisitaClave = v.VisitaClave ")
					.append("WHERE a.DiaClave = '" + diaClave + "' and t.TransProdID is null ");

			return  BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerConteoVisitadosSinVentaFueraFrecuencia(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select count(distinct(v.ClienteClave)) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 1 and a.RUTClave = '" + ruta + "' ")
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 1 and v.RUTClave = '" + ruta + "' and v.DiaClave = '" + diaClave + "' ")
					.append("left join TransProd t on t.VisitaClave = v.VisitaClave ")
					.append("where t.TransProdID is null ");

			return  BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerEncuestasAplicadas(String ruta, String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select count( distinct cen.CENClave) from CenCli cen ")
					.append("inner join Encuesta e on cen.CENClave = e.CENClave ")
					.append("inner join Visita v on e.VisitaClave = v.VisitaClave and v.ClienteClave = cen.ClienteClave and v.FueraFrecuencia = 0 and v.RUTClave = '"+ruta+"' and v.DiaClave = '" + diaClave + "' ");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerEncuestasAplicadasFueraFrecuencia(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select count( distinct cen.CENClave) from CenCli cen ")
					.append("inner join Encuesta e on cen.CENClave = e.CENClave ")
					.append("inner join Visita v on e.VisitaClave = v.VisitaClave and v.ClienteClave = cen.ClienteClave and v.FueraFrecuencia = 1 and v.RUTClave = '"+ruta+"' and v.DiaClave = '" + diaClave + "' ");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerEncuestasNoAplicadas(String ruta, String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct count(cen.CENClave) from Agenda a  ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 0 and a.RUTClave = '" + ruta + "' ")
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 0 and v.RUTClave = '" + ruta + "' and v.DiaClave = '" + diaClave + "' ")
					.append("left join Encuesta e on e.VisitaClave = v.VisitaClave ")
					.append("left join CenCli cen on cen.ClienteClave = a.ClienteClave ")
					.append("WHERE a.DiaClave = '" + diaClave + "' and e.CENClave is null ");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerClientesEncuestados(String ruta, String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct count(a.ClienteClave) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 0 and a.RUTClave = '" + ruta + "' ")
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 0 and v.RUTClave = '" + ruta + "' and v.DiaClave = '" + diaClave + "' ")
					.append("inner join Encuesta e on e.VisitaClave = v.VisitaClave ")
					.append("WHERE a.DiaClave = '" + diaClave + "'");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerClientesEncuestadosFueraFrecuencia(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select count(distinct(v.ClienteClave)) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 1 and a.RUTClave = '"+ruta+"' ")
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 1 and v.RUTClave = '"+ruta+"' and v.DiaClave = '" + diaClave + "' ")
					.append("inner join Encuesta e on e.VisitaClave = v.VisitaClave");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerClientesNoEncuestados(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct count(a.ClienteClave) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 0 and a.RUTClave = '" + ruta + "' ")
					.append("left join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 0 and v.RUTClave = '" + ruta + "' and v.DiaClave = '" + diaClave + "' ")
					.append("left join Encuesta e on e.VisitaClave = v.VisitaClave ")
					.append("WHERE a.DiaClave = '" + diaClave + "' and e.CENClave is null ");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerClientesNoEncuestadosFueraFrecuencia(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select count(distinct(v.ClienteClave)) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 1 and a.RUTClave = '"+ruta+"' ")
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 1 and v.RUTClave = '"+ruta+"' and v.DiaClave = '" + diaClave + "' ")
					.append("left join Encuesta e on e.VisitaClave = v.VisitaClave ")
					.append("where e.CENClave is null");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerCodigosLeidos(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct count(a.ClienteClave) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 0 and a.RUTClave = '" + ruta + "' ")
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 0 and v.RUTClave = '" + ruta + "' and v.DiaClave = '" + diaClave + "' and v.CodigoLeido = 1 ")
					.append("WHERE a.DiaClave = '" + diaClave + "'");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerCodigosLeidosFueraFrecuencia(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select count(distinct(v.ClienteClave)) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 1 and a.RUTClave = '" + ruta + "' ")
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 1 and v.RUTClave = '" + ruta + "' and v.CodigoLeido = 1  and v.DiaClave = '" + diaClave + "' ");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerCodigosNoLeidos(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct count(a.ClienteClave) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 0 and a.RUTClave = '" + ruta + "' ")
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 0 and v.RUTClave = '" + ruta + "' and v.DiaClave = '" + diaClave + "' and v.CodigoLeido = 0 ")
					.append("WHERE a.DiaClave = '" + diaClave + "'");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerCodigosNoLeidosFueraFrecuencia(String ruta,String diaClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("select count(distinct(v.ClienteClave)) from Agenda a ")
					.append("inner join Dia d on a.DiaClave = d.DiaClave and d.FueraFrecuencia = 1 and a.RUTClave = '" + ruta + "' ")
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 1 and v.RUTClave = '" + ruta + "' and v.CodigoLeido = 0  and v.DiaClave = '" + diaClave + "' ");

			return BDVend.consultar(consulta.toString());
		}

        public static ISetDatos obtenerCobranzaPorCliente(String clienteClave) throws Exception{

            StringBuilder consulta = new StringBuilder();
            consulta.append("select distinct c.Clave, c.NombreCorto, t.TransProdID,t.Folio,t.FechaCaptura,t.Total as Importe,t.Saldo from TransProd t ")
                    .append("inner join Visita v on t.VisitaClave = v.VisitaClave ")
                    .append("inner join Cliente c on v.ClienteClave = c.ClienteClave and c.ClienteClave = '"+clienteClave+"' ")
                    .append("where t.Tipo = 1 and t.TipoFase != 0 and t.Saldo > 0 ")
                    .append("order by c.Clave,t.Folio ");

            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerResumenCobranzaPorCliente(String diaClave, String clienteClave) throws Exception{

            StringBuilder consulta = new StringBuilder();
            consulta.append("")
		            .append("SELECT c.Clave, c.NombreCorto,  t.Folio, t.CFVTipo AS FormaVenta , t.Total AS Importe, t.Saldo, SUM(at.Importe)as Abono ")
		            .append("FROM Abono a ")
		            .append("INNER JOIN Visita v ON a.VisitaClave = v.VisitaClave  and v.DiaClave = '" + diaClave + "' ")
		            .append("INNER JOIN Cliente c ON v.ClienteClave = c.ClienteClave and c.ClienteClave = '" + clienteClave + "' ")
		            .append("INNER JOIN AbnTrp at ON at.ABNId=a.ABNId ")
		            .append("INNER JOIN Transprod t ON at.TransprodID= t.TransprodID ")
		            .append("GROUP BY  c.Clave, c.NombreCorto, t.Folio, t.CFVTipo , t.Total, t.Saldo ")
		            .append("ORDER BY c.Clave,t.Folio ");

            return BDVend.consultar(consulta.toString());
        }

		public static ISetDatos obtenerResumenCobranzaPorClientes(String diaClave, String clientesClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("")
					.append("SELECT c.Clave, c.NombreCorto,  t.Folio, t.CFVTipo AS FormaVenta , t.Total AS Importe, t.Saldo, SUM(at.Importe)as Abono ")
					.append("FROM Abono a ")
					.append("INNER JOIN Visita v ON a.VisitaClave = v.VisitaClave  and v.DiaClave = '"+diaClave+"' ")
					.append("INNER JOIN Cliente c ON v.ClienteClave = c.ClienteClave and c.ClienteClave in (" + clientesClave + ") ")
					.append("INNER JOIN AbnTrp at ON at.ABNId=a.ABNId ")
					.append("INNER JOIN Transprod t ON at.TransprodID= t.TransprodID ")
					.append("GROUP BY  c.Clave, c.NombreCorto, t.Folio, t.CFVTipo , t.Total, t.Saldo ")
					.append("ORDER BY c.Clave,t.Folio");

			return BDVend.consultar(consulta.toString());
		}

        public static ISetDatos obtenerPrepedidos(String diaClave, String clienteClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT DISTINCT ")
					.append("t.TransProdID,t.Folio,t.FechaCaptura, ")
					.append("v.VisitaClave,  ")
					.append("c.ClienteClave, c.Clave, c.NombreCorto, ")
					.append("tpd.TransProdDetalleID,tpd.ProductoClave,tpd.TipoUnidad,tpd.Precio,tpd.Cantidad,tpd.Promocion, ")
					.append("p.ProductoClave,p.Nombre ")
					.append("FROM TransProd t  ")
					.append("INNER JOIN Visita v ON t.VisitaClave = v.VisitaClave and v.FueraFrecuencia = 0 ")
					.append("INNER JOIN Dia d ON ((t.DiaClave IS NOT NULL and t.DiaClave = d.DiaClave) OR (t.DiaClave1 IS NOT NULL and t.DiaClave1 = d.DiaClave)) and d.DiaClave = '" + diaClave + "' ")
					.append("INNER JOIN Cliente c ON v.ClienteClave = c.ClienteClave and c.ClienteClave = '" + clienteClave + "' ")
					.append("INNER JOIN TransProdDetalle tpd ON tpd.TransProdID = t.TransProdID ")
					.append("INNER JOIN Producto p ON tpd.ProductoClave = p.ProductoClave ")
					.append("WHERE t.Tipo = 21 and t.TipoFase <> 0 ")
					.append("ORDER BY t.TransProdID,t.FechaCaptura,tpd.ProductoClave");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerAlmacen() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select a.Nombre, a.Domicilio, a.Telefono from Almacen a ")
					.append("where a.Tipo = 1");

			return  BDVend.consultar(consulta.toString());
		}

        public static boolean HayMovSinInvSinVisitaSinEnviar() throws Exception{
            String Consulta = "SELECT count(*) as Registros FROM Transprod WHERE Tipo=19 and (Enviado=0 or Enviado is null) ";

            ISetDatos datos = BDVend.consultar(Consulta.toString());

            int totalMovSinInvSinVis = 0;

            if (datos.moveToFirst())
            {
                totalMovSinInvSinVis = datos.getInt("Registros");
            }

            datos.close();

            return (totalMovSinInvSinVis>0);

        }

        public static TransProd obtenerTransProdObj(String TransProd) throws Exception
        {
            String sConsulta;

            sConsulta = "Select t.TransProdId as Transprodid, t.MUsuarioID as Musuarioid, t.Folio as Folio, t.DiaClave as Diaclave ";
            sConsulta += "from Transprod t ";
            sConsulta += "where t.TransProdId='" + TransProd + "'";

            ISetDatos datos = BDVend.consultar(sConsulta);

            if (datos.getCount() == 1)
            {
                if (datos.moveToPosition(0)) {
                    TransProd mTransProd = new TransProd();
                    mTransProd.TransProdID = datos.getString("Transprodid");
                    mTransProd.MUsuarioID = datos.getString("Musuarioid");
                    mTransProd.Folio = datos.getString("Folio");
                    mTransProd.DiaClave = datos.getString("Diaclave");

                    sConsulta = "Select td.ProductoClave as Productoclave, td.TipoUnidad as Tipounidad, td.Cantidad as Cantidad ";
                    sConsulta += "from TransprodDetalle td ";
                    sConsulta += "where td.TransProdId='" + TransProd + "'";

                    datos = BDVend.consultar(sConsulta);

                    while (datos.moveToNext()) {
                        TransProdDetalle mTransProdDetalle = new TransProdDetalle();
                        mTransProdDetalle.ProductoClave = datos.getString("Productoclave");
                        mTransProdDetalle.TipoUnidad = datos.getInt("Tipounidad");
                        mTransProdDetalle.Cantidad = datos.getInt("Cantidad");
                        mTransProd.TransProdDetalle.add(mTransProdDetalle);
                    }

                    datos.close();
                    return mTransProd;
                }
            }

            datos.close();
            return null;
        }

		public static ISetDatos obtenerCargasDetallado(String diaClave) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT ")
					.append("tp.Total, ")
					.append("tp.FechaCaptura, ")
					.append("tp.TransProdID, tp.Folio, ")
					.append("tpd.TransProdDetalleID, tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, ")
					.append("p.Nombre, ")
					.append("pd.PRUTipoUnidad, pd.Factor ")
					.append("FROM TransProd tp ")
					.append("INNER JOIN TransProdDetalle tpd ON tpd.TransProdID = tp.TransProdID ")
					.append("INNER JOIN Producto p ON p.ProductoClave = tpd.ProductoClave ")
					.append("INNER JOIN ProductoDetalle pd ON pd.ProductoClave = p.ProductoClave AND tpd.TipoUnidad = pd.PRUTipoUnidad AND pd.ProductoDetClave = p.ProductoClave ")
					.append("WHERE tp.Tipo = 2 AND tp.FechaCaptura = '" + diaClave + "' ")
					.append("ORDER BY tp.FechaCaptura ASC, tp.TransProdID, p.ProductoClave ");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerCargasGeneral(String diaClave) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT ")
					.append("detallado.TransProdID as TransProdID, detallado.ProductoClave as ProductoClave, detallado.Nombre as Nombre, ")
					.append("SUM(detallado.Cantidad * detallado.Factor) as CantidadTotal, ")
					.append("(")
					.append("SELECT ")
					.append("MIN(pd.Factor) ")
					.append("FROM ProductoDetalle pd ")
					.append("WHERE ")
					.append("pd.ProductoClave = detallado.ProductoClave AND ")
					.append("pd.ProductoDetClave = detallado.ProductoClave ")
					.append(") AS FactorMinimo ")
					.append("FROM ( ")
					.append("SELECT ")
					.append("tp.Total, ")
					.append("tp.FechaCaptura, ")
					.append("tp.TransProdID, tp.Folio, ")
					.append("tpd.TransProdDetalleID, tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, ")
					.append("p.Nombre, ")
					.append("pd.PRUTipoUnidad, pd.Factor ")
					.append("FROM TransProd tp ")
					.append("INNER JOIN TransProdDetalle tpd ON tpd.TransProdID = tp.TransProdID ")
					.append("INNER JOIN Producto p ON p.ProductoClave = tpd.ProductoClave ")
					.append("INNER JOIN ProductoDetalle pd ")
					.append("ON pd.ProductoClave = p.ProductoClave ")
					.append("AND tpd.TipoUnidad = pd.PRUTipoUnidad ")
					.append("AND pd.ProductoDetClave = p.ProductoClave ")
					.append("WHERE tp.Tipo = 2 AND tp.FechaCaptura = '" + diaClave + "' ")
					.append(")  detallado ")
					.append("GROUP BY detallado.TransProdID, detallado.ProductoClave, detallado.Nombre, detallado.FechaCaptura ")
					.append("ORDER BY detallado.FechaCaptura ASC, detallado.TransProdID, detallado.ProductoClave ASC ");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerCargasResumen(String diaClave) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT  ")
					.append("detallado.ProductoClave as ProductoClave, detallado.Nombre as Nombre,  ")
					.append("SUM(detallado.Cantidad * detallado.Factor) AS CantidadTotal, ")
					.append("( ")
					.append("SELECT  ")
					.append("MIN(pd.Factor) ")
					.append("FROM ProductoDetalle pd  ")
					.append("WHERE  ")
					.append("pd.ProductoClave = detallado.ProductoClave AND ")
					.append("pd.ProductoDetClave = detallado.ProductoClave ")
					.append(") AS FactorMinimo ")
					.append("FROM ( ")
					.append("SELECT  ")
					.append("tp.Total, ")
					.append("tp.FechaCaptura, ")
					.append("tp.TransProdID, tp.Folio, ")
					.append("tpd.TransProdDetalleID, tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, ")
					.append("p.Nombre, ")
					.append("pd.PRUTipoUnidad, pd.Factor ")
					.append("FROM TransProd tp ")
					.append("INNER JOIN TransProdDetalle tpd ON tpd.TransProdID = tp.TransProdID ")
					.append("INNER JOIN Producto p ON p.ProductoClave = tpd.ProductoClave ")
					.append("INNER JOIN ProductoDetalle pd ")
					.append("ON pd.ProductoClave = p.ProductoClave ")
					.append("AND tpd.TipoUnidad = pd.PRUTipoUnidad ")
					.append("AND pd.ProductoDetClave = p.ProductoClave ")
					.append("WHERE tp.Tipo = 2 AND tp.FechaCaptura = '" + diaClave + "' ")
					.append(")  detallado ")
					.append("GROUP BY detallado.ProductoClave, detallado.Nombre ");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerRecoleccionEnvase(String tiposMotivo) throws Exception{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("select TRP.Folio || ' ' || CLI.Clave || '-' || IFNULL(CLI.NombreCorto,'') as Cliente, PRO.ProductoClave, PRO.Nombre, TPD.Cantidad ");
			sConsulta.append("from transprod TRP ");
			sConsulta.append("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransprodID ");
			sConsulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave ");
			sConsulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			sConsulta.append("Inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ");
			sConsulta.append("where TRP.tipo = 3 and TRP.TipoFase <>0 ");
			if(!tiposMotivo.equals(""))
				sConsulta.append("and TPD.TipoMotivo in (" + tiposMotivo + ") ");
			//sConsulta.append("and CLI.ClienteClave in (" + ClienteClave + ") ");
			sConsulta.append("order by trp.folio, PRO.ProductoClave ");
			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerRecoleccionEnvaseTotalesXClave(String tiposMotivo) throws Exception{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("select PRO.ProductoClave, PRO.Nombre, sum(TPD.Cantidad) as Cantidad ");
			sConsulta.append("from transprod TRP ");
			sConsulta.append("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransprodID ");
			sConsulta.append("Inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ");
			sConsulta.append("where TRP.tipo = 3 and TRP.TipoFase <>0 ");
			if(!tiposMotivo.equals(""))
				sConsulta.append("and TPD.TipoMotivo in (" + tiposMotivo + ") ");
			//sConsulta.append("and CLI.ClienteClave in (" + ClienteClave + ") ");
			sConsulta.append("group by PRO.ProductoClave, PRO.Nombre order by PRO.ProductoClave ");
			return BDVend.consultar(sConsulta.toString());
		}
	}

	public static final class ConsultasTransProdDetalle
	{
		public static void eliminarRegalados(String TransProdId) throws Exception
		{
			BDVend.ejecutarComando("DELETE FROM TransProdDetalle WHERE TransProdID='" + TransProdId + "' AND IFNULL(Promocion,0)=2");
		}

		public static void actualizarMarcaPromocion(String TransProdId) throws Exception
		{
			BDVend.ejecutarComando("UPDATE TransProdDetalle SET Promocion=0,Enviado=0,MFechaHora='" + Generales.getFechaHoraActualStr("yyyy-MM-dd HH:mm:ss") + "',MUsuarioID='" + ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId + "' WHERE TransProdID='" + TransProdId + "' AND IFNULL(Promocion,0)=1");
		}

		public static void eliminar(String TransProdId) throws Exception
		{
			BDVend.consultar("DELETE FROM TransProdDetalle WHERE TransProdID='" + TransProdId + "'");
		}

		public static void eliminarDetalle(String transProdId) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("DELETE FROM TransProdDetalle WHERE TransProdID = '" + transProdId + "'");
			BDVend.ejecutarComando(sConsulta.toString());
		}

		public static ISetDatos obtenerDetalle(String transProdId) throws Exception
		{
			// obtener todos los productos, excepto aquellos que se otorgaron
			// como promocion
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select TPD.TransProdDetalleID as _id, TPD.*, PRO.Nombre as Descripcion, case when CantidadOriginal is null then '' else 'SUG:' end as Sugerido, ");
			consulta.append("case when INV.Disponible is null then 0 else CAST(((INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido)/PDE.Factor) as int) end as Existencia, PRO.DecimalProducto, PRO.SubEmpresaId, PRO.Venta, PRO.Contenido ");
			consulta.append("from TransProdDetalle TPD inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ");
			consulta.append("inner join productodetalle PDE on PRO.ProductoClave = PDE.ProductoClave AND PDE.ProductoDetClave = PRO.ProductoClave AND TPD.TipoUnidad = PDE.PRUTipoUnidad ");
			consulta.append("left join inventario INV on PRO.ProductoClave = INV.ProductoClave AND INV.AlmacenID = '" + ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID + "' ");
			// consulta.append("where TPD.TransProdID in (" + transProdId +
			// ") AND TPD.Total > 0 AND TPD.Promocion != 2 order by TPD.ProductoClave");
			consulta.append("where TPD.TransProdID in (" + transProdId + ") AND (IFNULL(TPD.Promocion,0) != 2) order by TPD.ProductoClave");
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerDetalle_Mov(String transProdId) throws Exception
		{
			// obtener todos los productos, excepto aquellos que se otorgaron
			// como promocion
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select TPD.TransProdDetalleID as _id, TPD.TransProdID as mTransProdID, TPD.ProductoClave as ProductoClave, TPD.Cantidad as Cantidad, PRO.Nombre as Descripcion, TPD.TipoMotivo as TipoMotivo, TPD.TipoUnidad as TipoUnidad ");
			consulta.append("from TransProdDetalle TPD inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ");
			consulta.append("inner join productodetalle PDE on PRO.ProductoClave = PDE.ProductoClave AND PDE.ProductoDetClave = PRO.ProductoClave AND TPD.TipoUnidad = PDE.PRUTipoUnidad ");
			consulta.append("left join inventario INV on PRO.ProductoClave = INV.ProductoClave AND INV.AlmacenID = '" + ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID + "' ");
			// consulta.append("where TPD.TransProdID in (" + transProdId +
			// ") AND TPD.Total > 0 AND TPD.Promocion != 2 order by TPD.ProductoClave");
			consulta.append("where TPD.TransProdID in ('" + transProdId + "')  order by TPD.ProductoClave");
			return BDVend.consultar(consulta.toString());
		}

		public static void actualizarTipoMotivo(String transProdId, String transProdDetalleId, short tipoMotivo) throws Exception
		{
			BDVend.ejecutarComando("UPDATE TransProdDetalle SET TipoMotivo = " + tipoMotivo + " WHERE TransProdId = '" + transProdId + "' AND TransProdDetalleId = '" + transProdDetalleId + "'");
		}

		public static ISetDatos obtenerTotales(String transProdId) throws Exception
		{
			/*return
			BDVend.consultar("SELECT COUNT(*) as TotalProductos, SUM(Total) as Total FROM TransProdDetalle WHERE TransProdId in ("
			+ transProdId + ") AND Total > 0 AND IFNULL(Promocion,0) != 2"); //GROUP BY
			//ProductoClave");*/
			
			return BDVend.consultar("SELECT COUNT(*) as TotalProductos, SUM(TPD.Total) as Total, SUM(TPD.Cantidad * PRD.Factor) as Unidades,SUM(TPD.Cantidad*PU.KgLts) as Peso, SUM(TPD.Cantidad*PU.Volumen) as Volumen " +
					"FROM TransProdDetalle TPD inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and  TPD.ProductoClave = PRD.ProductoDetClave and TPD.TipoUnidad = PRD.PRUTipoUnidad " +
					"inner join ProductoUnidad PU on PU.ProductoClave = TPD.ProductoClave  and PU.PRUTipoUnidad = TPD.TipoUnidad WHERE TPD.TransProdId in (" + transProdId + ") AND (IFNULL(TPD.Promocion,0) != 2)");
		}

		public static ISetDatos obtenerTotalesDetalle(String transProdId) throws Exception
		{
			return BDVend.consultar("SELECT SUM(SubTotal) as SubTDetalle, SUM(Impuesto) as Impuesto, SUM(Total) as Total FROM TransProdDetalle WHERE TransProdId = '" + transProdId + "'"); // GROUP
																																															// BY
																																															// ProductoClave");
		}

		// Regresa el TransProdId, TransProdDetalleId, Cantidad
		public static Object[] obtenerDetallePorProductoClaveUnidad(String productoClave, String tipoUnidad, String transProdsId) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TransProdID, TransProdDetalleId,Cantidad,TipoMotivo FROM TransProdDetalle WHERE ProductoClave = '" + productoClave + "' AND TipoUnidad = " + tipoUnidad + " AND TransProdId in (" + transProdsId + ") AND (IFNULL(Promocion,0) <> 2) ");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			Object res[];
			if (datos.getCount() > 0)
			{
				res = new Object[4];
				datos.moveToNext();
                //Si se cambia el contenido del objeto, revisar donde se utiliza
				res[0] = datos.getString("TransProdID");
				res[1] = datos.getString("TransProdDetalleID");
				res[2] = datos.getFloat("Cantidad");
				res[3] = datos.getShort("TipoMotivo");

				datos.close();
				return res;
			}
			datos.close();

			return null;
		}

		public static int obtenerPartida(String transProdid) throws Exception
		{
			int partida = 0;
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT MAX(Partida) as Partida FROM TransProdDetalle WHERE TransProdId = '" + transProdid + "'");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			datos.moveToNext();
			// if(datos.getCount() > 0)
			partida = datos.getInt("Partida");
			datos.close();
			return partida;
		}

		public static void actualizarPartidas(String transProdId, int PartidaEliminada) throws Exception
		{
			BDVend.ejecutarComando("UPDATE TransProdDetalle SET Partida = Partida - 1 WHERE TransProdId = '" + transProdId + "' AND Partida > " + PartidaEliminada);
		}

		public static float obtenerSubtotalConDescto(String transProdsId) throws Exception
		{
			float resultado = 0;
			ISetDatos datos = BDVend.consultar("SELECT SUM(Subtotal - DesImporteT) FROM TransProdDetalle WHERE TransProdId in(" + transProdsId + ")");
			if (datos.getCount() > 0)
			{
				datos.moveToNext();
				resultado = datos.getFloat(0);
			}
			datos.close();
			return resultado;
		}

		public static ISetDatos obtenerTodos(String transProdsId) throws Exception
		{
			return BDVend.consultar("SELECT TransProdID, TransProdDetalleID FROM TransProdDetalle WHERE TransProdId in(" + transProdsId + ")");
		}

		public static float obtenerDescuentoProducto(String TransProdId) throws Exception
		{
			float resultado = 0;
			ISetDatos datos = BDVend.consultar("SELECT SUM(DescuentoPor) as Descuento FROM TransProdDetalle WHERE TransProdId = '" + TransProdId + "' GROUP BY TransProdId");
			if (datos.getCount() > 0)
			{
				datos.moveToNext();
				resultado = datos.getFloat("Descuento");
			}
			datos.close();
			return resultado;
		}

		public static ISetDatos obtenerDetalleLiquidacionConsignacion(String transProdID) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TPD.TransProdDetalleID, PRO.Nombre, PRO.ProductoClave, TPD.Cantidad, TPD.Precio, TPD.Total, PRO.DecimalProducto, TPD.TipoUnidad, ifnull(Dev.Cantidad,0), ifnull(Dev.Total,0) ");
			consulta.append("FROM TransProdDetalle as TPD inner join Producto as PRO on TPD.ProductoClave = PRO.ProductoClave ");
			consulta.append("LEFT JOIN (SELECT TPD2.Cantidad, TPD2.ProductoClave, TPD2.Total FROM TransProdDetalle as TPD2 WHERE TPD2.TransProdId = ");
			consulta.append("(SELECT TransProdId FROM TrpTpd WHERE TransProdID1 ='").append(transProdID).append("')) as Dev on Dev.ProductoClave = TPD.ProductoClave ");
			consulta.append("WHERE TPD.TransProdId ='").append(transProdID).append("'");
			
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerDetallesTicketCostena(String transProdId) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT Partida, PRO.ProductoClave, PRO.Nombre as Descripcion, TPD.TipoUnidad, TPD.Cantidad, ");
			consulta.append("TPD.Precio + IFNULL(TPDI.ImpuestoPU,0) as Precio, (TPD.Precio + IFNULL(TPDI.ImpuestoPU,0)) * TPD.Cantidad as Importe, ");
			consulta.append("CASE WHEN IMP.Abreviatura = 'IEPS' THEN 'C' ELSE ");
			consulta.append("CASE WHEN IMP.Abreviatura = 'IVA' THEN 'I' ELSE '' END END as Impuesto ");
			consulta.append("FROM TransprodDetalle TPD ");
			consulta.append("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ");
            consulta.append("inner join ProductoEsquema PRE on PRO.ProductoClave = PRE.ProductoClave ");
            consulta.append("inner join Esquema ESQ on PRE.EsquemaID = ESQ.EsquemaID ");
            consulta.append("inner join Esquema ESQ2 on ESQ2.Clave= substr(ESQ.Clave, 1,  length(ESQ2.Clave)) and ESQ2.Nivel = 1 ");
			consulta.append("left join TPDImpuesto TPDI on TPD.TransProdId = TPDI.TransProdId and TPD.TransProdDetalleId = TPDI.TransprodDetalleId ");
			consulta.append("left join Impuesto IMP on IMP.ImpuestoClave = TPDI.ImpuestoClave ");
			consulta.append("WHERE TPD.TransProdID = '" + transProdId + "'");
			consulta.append("ORDER BY ESQ2.Clave, TPD.ProductoClave ");
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerSubtotalParaFactura(String sClienteClave, String pedidosFacturados) throws Exception
		{
//			String fecha = Generales.getFormatoFecha(Generales.getFechaHoraActual(), "yyyy-MM-dd HH:mm:ss");
//			ISetDatos datos = null;
//			StringBuilder consulta = new StringBuilder();
//			consulta.append("SELECT SUM(TPD.Cantidad*(TPD.Precio+ifnull((SELECT SUM(Imp.ImpuestoPU) FROM TPDImpuesto as Imp inner join CLINoDesImp as CND on Imp.ImpuestoClave = CND.ImpuestoClave ").
//			append("WHERE CND.ClienteClave = TP.ClienteClave AND '").append(fecha).append("' BETWEEN CND.FechaInicio AND CND.FechaFin),0))) as Subtotal ").
//			append("FROM TransProdDetalle as TPD inner join TransProd as TP on TP.TransProdID = TPD.TransProdID WHERE TPD.TransProdId IN (").append(pedidosFacturados).append(")");
//			datos = BDVend.consultar(consulta.toString());
//			return datos;

            String fecha = Generales.getFormatoFecha(Generales.getFechaHoraActual(), "yyyy-MM-dd HH:mm:ss");
            ISetDatos datos = null;
            StringBuilder sconsulta = new StringBuilder();
            sconsulta.append("select sum((Subtotal - Descuento)) as Subtotal ");
            sconsulta.append("from ( ");
            sconsulta.append("select TRP.TransProdID, ");
            sconsulta.append("sum(TPD.Cantidad * (TPD.Precio + case when TDI.ImpuestoPU is null then 0 else TDI.ImpuestoPU end)) as SubTotal, ");
            sconsulta.append("(trp.descuentoimp + trp.descuentovendedor + sum(tpd.descuentoimp) + SUM(case when TDI.ImpuestoPU is null then 0 else (TPD.Cantidad * TDI.ImpuestoPU) - TDI.ImpDesGlb end)) as Descuento ");
            sconsulta.append("from TransProd TRP ");
            sconsulta.append("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ");
            sconsulta.append("left join ( ");
            sconsulta.append("select TransProdId, TransProdDetalleId, sum(ImpuestoPU) as ImpuestoPU, sum(ImpDesGlb) as ImpDesGlb ");
            sconsulta.append("from TpdImpuesto ");
            sconsulta.append("where  TransProdId in (" + pedidosFacturados + ")");
            sconsulta.append("and ImpuestoClave in ( ");
            sconsulta.append("select ImpuestoClave ");
            sconsulta.append("from CLINoDesImp ");
            sconsulta.append("where ClienteClave = '" + sClienteClave + "' and '" + fecha + "' between FechaInicio and FechaFin");
            sconsulta.append(")");
            sconsulta.append("group by TransProdId, TransProdDetalleId ");
            sconsulta.append(")as TDI on TPD.TransProdId = TDI.TransProdId and TPD.TransProdDetalleId = TDI.TransProdDetalleId ");
            sconsulta.append("where  TRP.TransProdId in (" + pedidosFacturados + ") ");
            sconsulta.append("group by TRP.TransProdID, trp.descuentoimp,trp.descuentovendedor, trp.total ");
            sconsulta.append(") as t ");

            datos = BDVend.consultar(sconsulta.toString());
            return datos;
		}

		public static ISetDatos obtenerImpuestoParaFactura(String sClienteClave, String pedidosFacturados) throws Exception
		{
//			String fecha = Generales.getFormatoFecha(Generales.getFechaHoraActual(), "yyyy-MM-dd HH:mm:ss");
//			ISetDatos datos = null;
//			StringBuilder consulta = new StringBuilder();
//			consulta.append("SELECT SUM(ifnull(TPDImp.ImpDesGlb,0)) as Impuesto FROM TPDImpuesto as TPDImp inner join Impuesto as Imp on Imp.ImpuestoClave = TPDImp.ImpuestoClave inner join TransProd as TP on ").
//			append("TPDImp.TransProdID = TP.TransProdID WHERE Imp.ImpuestoClave NOT IN (SELECT CND.ImpuestoClave FROM CLINoDesImp as CND WHERE CND.ClienteClave = TP.ClienteClave AND '").
//			append(fecha).append("' BETWEEN CND.FechaInicio AND CND.FechaFin) ").
//			append("AND TP.TransProdID IN (").append(pedidosFacturados).append(")");
//			datos = BDVend.consultar(consulta.toString());
//			return datos;

            String fecha = Generales.getFormatoFecha(Generales.getFechaHoraActual(), "yyyy-MM-dd HH:mm:ss");
            ISetDatos datos = null;
            StringBuilder sconsulta = new StringBuilder();
            sconsulta.append("select ifnull(sum(TDI.ImpDesGlb),0) as Impuesto ");
            sconsulta.append("from TPDImpuesto TDI ");
            sconsulta.append("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ");
            sconsulta.append("inner join Impuesto IMP on TDI.ImpuestoClave = IMP.ImpuestoClave ");
            sconsulta.append("where  TRP.TransProdId in (" + pedidosFacturados + ") ");
            sconsulta.append("and Trp.Tipo = 1 ");
            sconsulta.append("and TDI.ImpuestoClave not in ( ");
            sconsulta.append("select ImpuestoClave ");
            sconsulta.append("from CLINoDesImp ");
            sconsulta.append("where ClienteClave = '" + sClienteClave + "' and '" + fecha + "' between FechaInicio and FechaFin  ");
            sconsulta.append(") ");

            datos = BDVend.consultar(sconsulta.toString());
            return datos;
		}

		public static ISetDatos obtenerDetallesPedidoPreview(String transProdid) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TPD.ProductoClave as Clave, TPD.TipoUnidad as Unidad, P.Nombre as Descripcion, TPD.Cantidad as Cantidad,").
			append("TPD.Precio - (SELECT ifnull(SUM(TProm.PromocionImp/TPD.Cantidad),0) FROM TrpPrp TProm WHERE TProm.TransProdID = TP.TransProdID and TProm.TransProdDetalleID = TPD.TransProdDetalleID) as Precio, TPD.Impuesto as Impuestos,").
			append("(SELECT TPD.Cantidad * Volumen FROM ProductoUnidad WHERE ProductoClave = TPD.ProductoClave and PRUTipoUnidad = TPD.TipoUnidad and TipoEstado = 1)as Volumen,").
			append("(SELECT TPD.Cantidad * KgLts FROM ProductoUnidad WHERE ProductoClave = TPD.ProductoClave and PRUTipoUnidad = TPD.TipoUnidad and TipoEstado = 1)as Peso FROM TransProdDetalle TPD inner join TransProd TP on TP.TransProdID = TPD.TransProdID ").	
			append("inner join Producto P on P.ProductoClave = TPD.ProductoClave ").
			append("inner join ProductoUnidad PU on PU.ProductoClave = P.ProductoClave and PU.PRUTipoUnidad = TPD.TipoUnidad ").
			append("WHERE TP.TransProdID in(").append(transProdid).append(")");
			
			return BDVend.consultar(consulta.toString());
		}

        public static ISetDatos obtenerDetallePedidoPagoAnticipado(String transProdId) throws Exception
        {
            // obtener todos los productos, excepto aquellos que se otorgaron
            // como promocion
            StringBuilder consulta = new StringBuilder();
            consulta.append("Select TPD.TransProdDetalleID as _id, TPD.*, PRO.Nombre as Descripcion, PRO.DecimalProducto as DecimalProducto ");
            consulta.append("from TransProdDetalle TPD inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ");
             consulta.append("where TPD.TransProdID = '" + transProdId + "' order by TPD.ProductoClave");
            return BDVend.consultar(consulta.toString());
        }
        public static HashMap<String, Float> obtenerTotalesPorClasificacion(String transProdsId, String clasificacion) throws Exception
        {
            HashMap<String, Float> resultado = new HashMap<String, Float>();
            StringBuilder consulta = new StringBuilder();
            consulta.append("SELECT IFNULL(sum(TPD.SubTotal),0) as SubTotal, IFNULL(sum(Impuesto),0) as Impuesto, IFNULL(sum(Total),0) as Total ");
            consulta.append("FROM TransProdDetalle TPD ");
            consulta.append("inner join ProductoEsquema PRE on PRE.ProductoClave = TPD.ProductoClave ");
            consulta.append("inner join Esquema ESQ on PRE.EsquemaID = ESQ.EsquemaID ");
            consulta.append("WHERE TPD.TransProdID ='" + transProdsId + "' and ESQ.Clasificacion in(" + clasificacion + ") ");
            ISetDatos datos = BDVend.consultar(consulta.toString());
            if (datos.getCount() > 0)
            {
                datos.moveToNext();
                resultado.put("SubTotal",datos.getFloat("SubTotal") );
                resultado.put("Impuesto", datos.getFloat("Impuesto"));
                resultado.put("Total", datos.getFloat("Total"));

            }
            datos.close();
            return resultado;
        }
        public static double obtenerPrecioConImpuesto(String transProdID, String productoClave)throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("SELECT TPD.Precio + sum(TPI.ImpuestoPU) as PrecioImpuesto FROM TransProdDetalle TPD ").
                    append("inner join TPDImpuesto TPI on TPD.TransProdID = TPI.TransProdID and TPD.TransProdDetalleID = TPI.TransProdDetalleID ").
                    append("where TPD.TransProdID = '" + transProdID + "' and TPD.ProductoClave = '" + productoClave + "' and IFNULL(TPD.Promocion,0)<>2 ").
                    append("group by TPD.ProductoClave, TPD.Precio ");

            ISetDatos sdPrecio =  BDVend.consultar(consulta.toString());
            double precio = 0;
            if (sdPrecio.moveToFirst()){
                precio = sdPrecio.getDouble("PrecioImpuesto");
            }
            sdPrecio.close();
            return precio;
        }

        public static ISetDatos obtenerDetallesDesctosVendedorCliente(String sTranprodid) throws Exception {
            String fecha = Generales.getFormatoFecha(Generales.getFechaHoraActual(), "yyyy-MM-dd HH:mm:ss");
            ISetDatos datos = null;
            StringBuilder sconsulta = new StringBuilder();
            sconsulta.append("SELECT TransProdID, TransProdDetalleID, ProductoClave, SubTotal, Cantidad, Precio, ifnull(DesImporteT,0) as DesImporteT ");
            sconsulta.append("from TransProdDetalle ");
            sconsulta.append("where TransProdId= +'" + sTranprodid + "' ");

            datos = BDVend.consultar(sconsulta.toString());
            return datos;
        }

	}

	public static final class ConsultasCargas
	{

		public static ISetDatos obtenerDetalleCargasPorTransferir()
		{
			String Consulta = "Select distinct TPD.ProductoClave, TPD.TipoUnidad, sum(TPD.Cantidad) as Cantidad, PRO.DecimalProducto from TransProd TP Inner Join TransProdDetalle TPD ON TP.TransProdId=TPD.TransProdId and TP.Tipo=2 and TP.TipoFase=5 and TP.MUsuarioId='" + ((Vendedor) Sesion.get(Campo.VendedorActual)).USUId + "' Inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave group by TPD.ProductoClave, TPD.TipoUnidad, PRO.DecimalProducto ";
			try
			{
				return BDVend.consultar(Consulta);
			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block
				return null;
			}
		}

		public static String obtenerIdsCargas() throws Exception
		{

			StringBuilder sConsulta = new StringBuilder();
			String sCargas ="";

			sConsulta.append("Select TransProdID from TransProd where Tipo = 2 and Escritorio = 1 ");

			ISetDatos datos = BDVend.consultar(sConsulta.toString());

			while (datos.moveToNext())
			{
				sCargas += "''" + datos.getString("TransProdID") + "'',";
			}
			if(sCargas.length()>0){
				sCargas = sCargas.substring(0, sCargas.length() - 1);
			}
			return sCargas;
		}
		
		public static ISetDatos obtenerDetalleInventarioABordo()
		{
			String Consulta = "Select distinct TPD.TransProdId, TPD.TransProdDetalleId, TPD.ProductoClave, TPD.TipoUnidad, sum(TPD.Cantidad) as Cantidad, PRO.DecimalProducto from TransProd TP Inner Join TransProdDetalle TPD ON TP.TransProdId=TPD.TransProdId and TP.Tipo=23 and TP.TipoFase<>0 and TPD.Cantidad >0 and TP.MUsuarioId='" + ((Vendedor) Sesion.get(Campo.VendedorActual)).USUId + "' Inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave group by TPD.ProductoClave, TPD.TipoUnidad, PRO.DecimalProducto ";
			try
			{
				return BDVend.consultar(Consulta);
			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block
				return null;
			}
		}
		
		public static void actualizarFaseTransferirACaptura() throws Exception
		{
			BDVend.ejecutarComando("Update TransProd Set TipoFase=1, Notas = null, Enviado=0, MFechaHora = DATETIME('now') where TransProd.Tipo = 2 and TransProd.TipoFase = 5 and MUsuarioID='" + ((Vendedor) Sesion.get(Campo.VendedorActual)).USUId + "' ");
		}

	}

	public static final class ConsultasPromocion
	{
		public static Promocion[] obtenerProductosConPromocion(String sEsquemasCliente, String sPrecioClave, String sModuloMovDetalleClave)
		{

			// String fechaactualformat =
			// Generales.getFormatoFecha(Generales.getFechaActual(),"yyyy-MM-dd");

			String Consulta = "select PRM.PromocionClave, PRM.Nombre, PRM.Tipo, PRM.TipoAplicacion, PRM.FechaFinal, PRM.PermiteCascada, PRM.TipoRango, PRM.TipoRegla, PRM.Obligatoria, " + " PRM.SeleccionProducto, PRM.CapturaCantidad, PRM.PendienteEntrega, PRP.ProductoClave, PRO.Nombre as ProductoNombre, ifnull(PPV.Precio, 0) as Precio " + " from Promocion PRM " + " inner join PromocionModulo PMD on PRM.PromocionClave = PMD.PromocionClave and PMD.ModuloMovDetalleClave = '" + sModuloMovDetalleClave + "' and PMD.TipoEstado = 1 " + "  inner join PromocionProducto PRP on PRM.PromocionClave = PRP.PromocionClave " + " inner join Producto PRO on PRP.ProductoClave = PRO.ProductoClave and PRO.TipoFase = 1 "

					+ " left join PrecioProductoVig PPV on PRO.ProductoClave = PPV.ProductoClave and  PPV.PRUTipoUnidad = (  select PRU.PRUTipoUnidad  from ProductoUnidad PRU  inner join ProductoDetalle PRD on PRU.ProductoClave = PRD.ProductoClave and PRU.PRUTipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave and PRU.TipoEstado = 1  where PRU.ProductoClave = PRO.ProductoClave  order by PRD.Factor limit 1) and PPV.PrecioClave = '" + sPrecioClave + "' and  DATETIME('now') between PPV.PPVFechaInicio and PPV.FechaFin " + "  left join PromocionDetalle PRD on PRM.PromocionClave = PRD.PromocionClave and PRD.TipoEstado = 1 " + " 	where PRM.TipoEstado = 1 and PRP.TipoEstado = 1 and DATETIME('now') between FechaInicial and FechaFinal " + " and ((PRM.Tipo in (2,4) and PRD.EsquemaId in (" + sEsquemasCliente + ")) or PRM.Tipo = 1) " + " group by PRM.PromocionClave, PRM.Nombre, PRM.Tipo, PRM.TipoAplicacion, PRM.FechaFinal, PRM.PermiteCascada, PRM.TipoRango, PRM.TipoRegla, PRM.Obligatoria, " + " PRM.SeleccionProducto, PRM.CapturaCantidad, PRM.PendienteEntrega, PRP.ProductoClave, PRO.Nombre, PPV.Precio " + " order by case when PRM.Tipo <> 4 then 0 else 1 end ";

			ISetDatos datos;
			Promocion[] aPromociones = null;
			try
			{
				datos = BDVend.consultar(Consulta);

				aPromociones = new Promocion[datos.getCount()];
				int i = 0;
				while (datos.moveToNext())
				{
					aPromociones[i] = new Promocion();
					aPromociones[i].PromocionClave = datos.getString("PromocionClave");
					aPromociones[i].Nombre = datos.getString("Nombre");
					aPromociones[i].Tipo = datos.getShort("Tipo");
					aPromociones[i].TipoAplicacion = datos.getShort("TipoAplicacion");
					aPromociones[i].FechaFinal = datos.getDate("FechaFinal");
					aPromociones[i].PermiteCascada = datos.getBoolean("PermiteCascada");
					aPromociones[i].TipoRango = datos.getShort("TipoRango");
					aPromociones[i].TipoRegla = datos.getShort("TipoRegla");
					aPromociones[i].Obligatoria = datos.getBoolean("Obligatoria");
					aPromociones[i].SeleccionProducto = datos.getBoolean("SeleccionProducto");
					aPromociones[i].CapturaCantidad = datos.getBoolean("CapturaCantidad");
					aPromociones[i].PendienteEntrega = datos.getBoolean("PendienteEntrega");
					aPromociones[i].ProductoClave = datos.getString("ProductoClave");
					aPromociones[i].ProductoNombre = datos.getString("ProductoNombre");
					aPromociones[i].Precio = datos.getFloat("Precio");

					i++;
				}
			}
			catch (Exception e)
			{
				return null;
			}
			datos.close();
			return aPromociones;
		}

		public static ISetDatos obtenerPromocionProductosEsquema(String PromocionClave)
		{

			String Consulta = "select PD.EsquemaID,E.Nombre from PromocionDetalle PD inner join Esquema E on E.EsquemaID=PD.EsquemaID where PD.TipoEstado =1 and  PD.PromocionClave='" + PromocionClave + "'  ";
			try
			{
				return BDVend.consultar(Consulta);
			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block
				return null;
			}

			// "select PD.EsquemaID,E.Nombre from PromocionDetalle PD inner join Esquema E on E.EsquemaID=PD.EsquemaID where PD.TipoEstado =1 and E.TipoEstado = 1 and E.Baja = 0 and PD.PromocionClave='"
			// + PromocionClave + "'  "

		}

		public static ISetDatos RecuperarPromocionReglas()
		{

			String Consulta = "select PromocionClave, PromocionReglaID,Minimo,Maximo,Porcentaje,Importe,Cantidad,PRE.Nombre as Precio, AplicacionMinima from PromocionRegla  PR left join Precio PRE on PRE.PrecioClave=PR.PrecioClave and PRE.TipoEstado = 1 ";
			try
			{
				return BDVend.consultar(Consulta);
			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block
				return null;
			}

			// "select PD.EsquemaID,E.Nombre from PromocionDetalle PD inner join Esquema E on E.EsquemaID=PD.EsquemaID where PD.TipoEstado =1 and E.TipoEstado = 1 and E.Baja = 0 and PD.PromocionClave='"
			// + PromocionClave + "'  "

		}

		public static ISetDatos RecuperarPromocionAplicaciones()
		{

			String Consulta = "select PA.PromocionClave,Pa.PromocionReglaID, Pro.Nombre,PRUTipoUnidad,Cantidad from PromocionAplicacion PA inner join Producto Pro on Pro.ProductoClave=PA.ProductoClave where TipoEstado=1 and Pro.TipoFase = 1  ";
			try
			{
				return BDVend.consultar(Consulta);
			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block
				return null;
			}

			// "select PD.EsquemaID,E.Nombre from PromocionDetalle PD inner join Esquema E on E.EsquemaID=PD.EsquemaID where PD.TipoEstado =1 and E.TipoEstado = 1 and E.Baja = 0 and PD.PromocionClave='"
			// + PromocionClave + "'  "

		}

		public static ISetDatos obtenerAplicables(String sModuloMovDetalleClave, String sEsquemasId) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			// sConsulta.append("select PRM.PromocionClave ");
			sConsulta.append("select distinct PRM.PromocionClave ");
			sConsulta.append("from Promocion PRM ");
			sConsulta.append("inner join PromocionModulo PMD on PRM.PromocionClave = PMD.PromocionClave ");
			sConsulta.append("left join PromocionDetalle PDE on PRM.PromocionClave = PDE.PromocionClave ");
			// sConsulta.append("where date('now') between PRM.FechaInicial and PRM.FechaFinal and PRM.TipoEstado = 1 ");
			sConsulta.append("where strftime('%Y-%m-%d','now') between strftime('%Y-%m-%d',PRM.FechaInicial) and strftime('%Y-%m-%d',PRM.FechaFinal) and PRM.TipoEstado = 1 ");
			sConsulta.append("and PMD.ModuloMovDetalleClave = '" + sModuloMovDetalleClave + "' and PMD.TipoEstado = 1 ");
			sConsulta.append("and (PRM.Tipo = 1 or (PRM.Tipo in (2,4) and PDE.EsquemaID in (" + sEsquemasId + "))) ");

			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerProductosTrans(String sPromocionesClave, String sTransProdId) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("select distinct PRP.PromocionClave, PRP.ProductoClave, PRP.Jerarquia ");
			sConsulta.append("from Promocion PRM ");
			sConsulta.append("inner join PromocionProducto PRP on PRM.PromocionClave = PRP.PromocionClave ");
			sConsulta.append("inner join TransProdDetalle TPD on PRP.ProductoClave = TPD.ProductoClave ");
			sConsulta.append("where PRM.PromocionClave in (" + sPromocionesClave + ") and TPD.TransProdID = '" + sTransProdId + "' AND IFNULL(TPD.Promocion,0) <> 2 ");
			sConsulta.append("order by PRP.ProductoClave, PRP.Jerarquia, PRP.PromocionClave ");

			/*
			 * sConsulta.append(
			 * "select distinct PRP.PromocionClave, PRP.ProductoClave, PRP.Jerarquia, SUM(TPD.Cantidad * PRD.Factor) AS Cantidad, SUM(TPD.Subtotal) AS Subtotal, SUM(TPD.Impuesto) AS Impuesto "
			 * ); sConsulta.append("from Promocion PRM "); sConsulta.append(
			 * "inner join PromocionProducto PRP on PRM.PromocionClave = PRP.PromocionClave "
			 * ); sConsulta.append(
			 * "inner join TransProdDetalle TPD on PRP.ProductoClave = TPD.ProductoClave "
			 * ); sConsulta.append(
			 * "INNER JOIN ProductoDetalle PRD ON TPD.ProductoClave = PRD.ProductoClave AND TPD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave "
			 * ); sConsulta.append("where PRM.PromocionClave in ('" +
			 * sPromocionesClave + "') ");
			 * sConsulta.append("and TPD.TransProdID = '" + sTransProdId +
			 * "' AND TPD.Promocion <> 2 "); sConsulta.append(
			 * "group by PRP.PromocionClave, PRP.ProductoClave, PRP.Jerarquia "
			 * ); sConsulta.append(
			 * "order by PRP.ProductoClave, PRP.Jerarquia, PRP.PromocionClave "
			 * );
			 */

			return BDVend.consultar(sConsulta.toString());
		}

		public static Promocion[] obtenerPromocionesPorProductos(String sProductoClave) throws Exception
		{
			/*
			 * StringBuilder sConsulta = new StringBuilder(); sConsulta.append(
			 * "select distinct PRP.PromocionClave, PRP.ProductoClave, PRP.Jerarquia "
			 * ); sConsulta.append("from Promocion PRM "); sConsulta.append(
			 * "inner join PromocionProducto PRP on PRM.PromocionClave = PRP.PromocionClave "
			 * ); sConsulta.append(
			 * "inner join TransProdDetalle TPD on PRP.ProductoClave = TPD.ProductoClave "
			 * ); //sConsulta.append("where PRM.PromocionClave in ('" +
			 * sPromocionesClave + "') and TPD.TransProdID = '" + sTransProdId +
			 * "' AND TPD.Promocion <> 2 "); sConsulta.append(
			 * "order by PRP.ProductoClave, PRP.Jerarquia, PRP.PromocionClave "
			 * ); BDVend.consultar(sConsulta.toString());
			 */
			return new Promocion[0];
		}

		public static ISetDatos obtenerReglas(String sPromocionesClave) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("select PRM.PromocionClave, PRE.PromocionReglaID, PRE.Minimo, PRE.Maximo, PRE.PrecioClave, PRE.Porcentaje, PRE.Importe, PRE.Cantidad ");
			sConsulta.append("from Promocion PRM ");
			sConsulta.append("inner join PromocionRegla PRE on PRM.PromocionClave = PRE.PromocionClave ");
			sConsulta.append("where PRM.PromocionClave in (" + sPromocionesClave + ") ");
			sConsulta.append("order by PRM.PromocionClave, PRE.Minimo, PRE.Maximo  ");

			return BDVend.consultar(sConsulta.toString());
		}

		public static PromocionDetalle[] obtenerVistaDetalle(Promocion promocion, Integer cantidadGrupo) throws Exception
		{
			ArrayList<PromocionDetalle> detalle = new ArrayList<PromocionDetalle>();
			StringBuilder consulta = new StringBuilder();
			//			ISetDatos cantidades = null;

			ISetDatos unidades = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("UNIDADV", "");
			
			consulta.append("select PRA.PromocionClave,PRO.ProductoClave, PRO.Nombre, PRA.PRUTipoUnidad, (PRA.Cantidad * " + cantidadGrupo + ") as Cantidad, PRO.DecimalProducto, PDE.Factor from Producto PRO ");
			consulta.append("inner join PromocionAplicacion PRA on PRO.ProductoClave = PRA.ProductoClave ");
			consulta.append("inner join ProductoDetalle PDE on PDE.ProductoClave = PRA.ProductoClave and PRA.PRUTipoUnidad = PDE.PRUTipoUnidad and  PRA.ProductoClave = PDE.ProductoDetClave ");
			consulta.append("where PRA.PromocionClave = '" + promocion.PromocionClave + "' and PRA.PromocionReglaId='" + promocion.PromocionReglaIdApp + "'");
			// }

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				String und = "";
				if (promocion.TipoAplicacion == 4)
				{
					int unidad = datos.getInt(3);
					unidades.moveToPosition(unidad - 1);
					und = unidades.getString(2);
				}
				PromocionDetalle pedido = new PromocionDetalle(datos.getString(0), 
				datos.getString(1), 
				datos.getString(2), 
				datos.getInt(3),
				und, // Unidad
				datos.getFloat(4), // Cantidad
				promocion.SeleccionProducto, promocion.CapturaCantidad, datos.getInt(5), datos.getInt("Factor"),promocion.NoDisminuirProducto);
				detalle.add(pedido);
			}
			datos.close();
			unidades.close();

			return detalle.toArray(new PromocionDetalle[detalle.size()]);
		}

		public static ISetDatos obtenerCantidadesProducto(String TransProdId, String Productos) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT SUM(Cantidad) FROM TransProdDetalle WHERE TransProdId = '" + TransProdId + "' AND ProductoClave in (" + Productos + ") GROUP BY TransProdId");
			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerDesglosePromociones(String TransProdsId, String ClaveProducto) throws Exception
		{
			String consulta = "SELECT Producto.ProductoClave as ProductoClave,Producto.Nombre as Nombre, TrpPrp.PromocionClave as PromocionClave,  Promocion.Nombre as PromocionNombre,Promocion.TipoAplicacion as TipoAplicacion,TrpPrp.PromocionImp as PromocionImp, TransProdDetalle.Precio as Precio,TransProdDetalle.TransProdDetalleID as TransProdDetalleID FROM Producto JOIN TransProdDetalle ON Producto.ProductoClave = TransProdDetalle.ProductoClave JOIN TrpPrp ON TransProdDetalle.TransProdDetalleID = TrpPrp.TransProdDetalleId AND TransProdDetalle.TransProdID = TrpPrp.TransProdId JOIN Promocion ON Promocion.PromocionClave = TrpPrp.PromocionClave WHERE TrpPrp.TransProdId='" + TransProdsId + "'And  Producto.ProductoClave='" + ClaveProducto + "' ";
			consulta += "UNION ";
			consulta += "SELECT Producto.ProductoClave as ProductoClave,Producto.Nombre as Nombre, TpdPun.PromocionClave as PromocionClave,  Promocion.Nombre as PromocionNombre,Promocion.TipoAplicacion as TipoAplicacion,TpdPun.Puntos as PromocionImp, TransProdDetalle.Precio as Precio,TransProdDetalle.TransProdDetalleID as TransProdDetalleID FROM Producto JOIN TransProdDetalle ON Producto.ProductoClave = TransProdDetalle.ProductoClave JOIN TpdPun ON TransProdDetalle.TransProdDetalleID = TpdPun.TransProdDetalleId AND TransProdDetalle.TransProdID = TpdPun.TransProdId JOIN Promocion ON Promocion.PromocionClave = TpdPun.PromocionClave WHERE TpdPun.TransProdId='" + TransProdsId + "' And  Producto.ProductoClave='" + ClaveProducto + "' ";
			return BDVend.consultar(consulta);
		}

		public static ISetDatos obtenerDesglosePromocionesClave(String TransProdsId) throws Exception
		{
			String consulta = "SELECT Producto.ProductoClave as ProductoClave,Producto.Nombre as Nombre FROM Producto JOIN TransProdDetalle ON Producto.ProductoClave = TransProdDetalle.ProductoClave JOIN TrpPrp ON TransProdDetalle.TransProdDetalleID = TrpPrp.TransProdDetalleId AND TransProdDetalle.TransProdID = TrpPrp.TransProdId JOIN Promocion ON Promocion.PromocionClave = TrpPrp.PromocionClave WHERE TrpPrp.TransProdId='" + TransProdsId + "' GROUP BY Producto.ProductoClave ";
			consulta += "UNION ";
			consulta +="SELECT Producto.ProductoClave as ProductoClave,Producto.Nombre as Nombre FROM Producto JOIN TransProdDetalle ON  Producto.ProductoClave = TransProdDetalle.ProductoClave JOIN TpdPun ON TransProdDetalle.TransProdDetalleID = TpdPun.TransProdDetalleId AND TransProdDetalle.TransProdID = TpdPun.TransProdId JOIN Promocion ON Promocion.PromocionClave = TpdPun.PromocionClave WHERE TpdPun.TransProdId='" + TransProdsId + "' GROUP BY Producto.ProductoClave";
			return BDVend.consultar(consulta);
		}

		public static ISetDatos obtenerDescuento(String ClaveDescuento) throws Exception
		{
			return BDVend.consultar("Select PromocionRegla.Porcentaje, TrpPrp.PromocionImp from PromocionRegla join  TrpPrp  on PromocionRegla.PromocionClave = TrpPrp.PromocionClave where TrpPrp.PromocionClave='" + ClaveDescuento + "'");
		}

		public static ISetDatos obtenerRegalo(String TransProdsId, String TransProdDetalleId) throws Exception
		{
			return BDVend.consultar("Select distinct Producto.ProductoClave, TransProdDetalle.Cantidad, Producto.Nombre,TransProdDetalle.TipoUnidad  From  TransProdDetalle inner Join Producto on Producto.ProductoClave = TransProdDetalle.ProductoClave inner Join  TrpPrp on TransProdDetalle.PromocionClave = TrpPrp.PromocionClave and TransProdDetalle.TransProdID = TrpPrp.TransProdID  Where TrpPrp.TransProdId='" + TransProdsId + "' and TrpPrp.TransProdDetalleID='" + TransProdDetalleId + "'");
		}

		public static ISetDatos obtenerPuntos(String TransProdsId) throws Exception
		{
			return BDVend.consultar("Select TpdPun.Puntos From TpdPun Join TransProdDetalle On TpdPun.TransProdDetalleId = TransProdDetalle.TransProdDetalleId Where TpdPun.TransProdID='" + TransProdsId + "'");
		}

        public static ISetDatos obtenerReporteGeneralPromo() throws Exception {
            return BDVend.consultar("Select promocionclave, promocion.nombre, promocion.tipoaplicacion, promocion.fechafinal, promocion.tiporegla, promocion.seleccionproducto, promocion.capturacantidad, promocion.Tipo from promocion where promocion.TipoEstado=1 and date('now') between promocion.FechaInicial and promocion.FechaFinal");
        }

        public static ISetDatos obtenerProductosPorPromocion(String promocionClave) throws Exception{
            return  BDVend.consultar("select distinct producto.productoclave,producto.nombre from producto inner join promocionproducto on promocionproducto.productoclave=producto.productoclave where promocionproducto.promocionclave='" + promocionClave + "' order by Producto.Nombre");
        }

        public static ISetDatos obtenerEsquemasPorPromocion(String promocionClave) throws Exception{
            return  BDVend.consultar("Select Esquema.Nombre from promociondetalle inner join Esquema on Esquema.EsquemaID = promociondetalle.EsquemaID where promociondetalle.promocionclave='" + promocionClave + "' order by Esquema.Nombre");
        }

		public static ISetDatos obtenerReglaPorPromocion(String promocionClave) throws Exception{
			return BDVend.consultar("select minimo, maximo, porcentaje, importe, precioclave, promocionreglaid from promocionregla where promocionclave='" + promocionClave + "'");
		}

		public static ISetDatos obtenerProductosPorPromocionRegla(String promocionClave, String promocionReglaId) throws  Exception{
			return BDVend.consultar("select distinct Producto.nombre, PromocionAplicacion.PRUTipoUnidad,PromocionAplicacion.Cantidad  from PromocionAplicacion inner join Producto on PromocionAplicacion.ProductoClave = Producto.ProductoClave where PromocionAplicacion.promocionclave='" + promocionClave + "' and PromocionAplicacion.PromocionReglaId='" + promocionReglaId + "' order by Producto.Nombre");
		}
	}

	public static final class ConsultasTPDImpuesto
	{
		public static void eliminarImpuestosPromocion(String TransProdId) throws Exception
		{
			BDVend.ejecutarComando("DELETE FROM TPDImpuesto where TransProdId = '" + TransProdId + "' and TransProdDetalleID in(Select TransProdDetalle.TransProdDetalleID from TransProdDetalle WHERE TransProdDetalle.TransProdID='" + TransProdId + "' AND IFNULL(TransProdDetalle.Promocion,0)=2)");
		}

		public static void eliminarImpuestos(String TransProdId) throws Exception
		{
			BDVend.ejecutarComando("DELETE FROM TPDImpuesto where TransProdId = '" + TransProdId + "' and TransProdDetalleID in(Select TransProdDetalle.TransProdDetalleID from TransProdDetalle WHERE TransProdDetalle.TransProdID='" + TransProdId + "')");
		}

		public static void eliminarImpuestosPorDetalle(String TransProdId, String TransProdDetalleId) throws Exception
		{
			BDVend.ejecutarComando("DELETE FROM TPDImpuesto where TransProdId = '" + TransProdId + "' and TransProdDetalleID = '" + TransProdDetalleId + "'");
		}

		public static ISetDatos obtenerDesgloseImpuestos(String TransProdsId) throws Exception
		{
			return BDVend.consultar("SELECT IMP.ImpuestoClave, IMP.Abreviatura, TPDI.ImpuestoPor, IMP.TipoValor FROM TPDImpuesto TPDI INNER JOIN Impuesto IMP ON TPDI.ImpuestoClave = IMP.ImpuestoClave WHERE TransProdId in (" + TransProdsId + ") GROUP BY IMP.ImpuestoClave");
		}

		public static float obtenerImpuestoImp(String transProdId, String transProdDetalleId, String impuestoClave) throws Exception
		{
			float resultado = 0;
			ISetDatos datos = BDVend.consultar("SELECT ImpuestoImp FROM TPDImpuesto WHERE TransProdId ='" + transProdId + "' AND TransProdDetalleId='" + transProdDetalleId + "' AND ImpuestoClave='" + impuestoClave + "'");
			if (datos.getCount() > 0)
			{
				datos.moveToNext();
				resultado = datos.getFloat(0);
			}
			datos.close();
			return resultado;
		}
		
		public static float obtenerIEPS(String TransProdId) throws Exception{
			float resultado = 0;
			ISetDatos datos = BDVend.consultar("SELECT SUM(TPDI.ImpuestoImp) FROM TPDImpuesto TPDI inner join Impuesto IMP on IMP.ImpuestoClave = TPDI.ImpuestoClave WHERE TPDI.TransProdId ='" + TransProdId + "' AND IMP.Abreviatura = 'IEPS' GROUP BY TPDI.TransProdId");
			if (datos.getCount() > 0)
			{
				datos.moveToNext();
				resultado = datos.getFloat(0);
			}
			datos.close();
			return resultado;
		}
		
		public static float obtenerIVA(String TransProdId) throws Exception{
			float resultado = 0;
			ISetDatos datos = BDVend.consultar("SELECT SUM(TPDI.ImpuestoImp) FROM TPDImpuesto TPDI inner join Impuesto IMP on IMP.ImpuestoClave = TPDI.ImpuestoClave WHERE TPDI.TransProdId ='" + TransProdId + "' AND IMP.Abreviatura = 'IVA' GROUP BY TPDI.TransProdId");
			if (datos.getCount() > 0)
			{
				datos.moveToNext();
				resultado = datos.getFloat(0);
			}
			datos.close();
			return resultado;
		}
	}

	public static final class ConsultasProductoNegado
	{
		public static void eliminarProductosNegadosXPromocion(String TransProdId) throws Exception
		{
			BDVend.ejecutarComando("DELETE FROM ProductoNegado where TransProdID='" + TransProdId + "' and not PromocionClave is null");
		}
	}

	public static final class ConsultasTpdPun
	{

		public static void eliminar(String TransprodId) throws Exception
		{
			BDVend.ejecutarComando("delete from TpdPun where TransProdID = '" + TransprodId + "'");
		}

		public static void eliminarPorDetalle(String TransprodId, String TransProdDetalleId) throws Exception
		{
			BDVend.ejecutarComando("delete from TpdPun where TransProdID = '" + TransprodId + "' AND TransProdDetalleId = '" + TransProdDetalleId + "'");
		}

		public static void actualizarSaldo(float Puntos) throws Exception
		{
			BDVend.ejecutarComando("update Punto set Saldo = Saldo - " + Puntos + ", Enviado = 0, MFechaHora = '" + Generales.getFechaHoraActualStr("yyyy-MM-dd HH:mm:ss") + "', MUsuarioID = '" + ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId + "' where ClienteClave ='" + ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave + "'");
		}

		public static float obtenerPuntos(String TransProdId) throws Exception
		{
			float pntos = 0;
			ISetDatos puntos = BDVend.consultar("select case when sum(Puntos) is null then 0 else sum(Puntos) end as Puntos from TpdPun where TransProdId = '" + TransProdId + "'");
			puntos.moveToNext();
			pntos = puntos.getFloat(0);
			puntos.close();
			return pntos;
		}
	}

	public static final class ConsultasFolios
	{

		public static FolioReservacion obtenerPropiedadesFolio(boolean mostrarMensajeError, String moduloMovDetalleClave) throws Exception
		{
			String Consulta = "SELECT FolioReservacion.* FROM FolioReservacion ";
			Consulta += " INNER JOIN Folio ON FolioReservacion.FolioID = Folio.FolioID ";
			Consulta += " WHERE Folio.ModuloMovDetalleClave='" + moduloMovDetalleClave + "' ";
			Consulta += " AND FolioReservacion.TipoEstado=1 AND Usados < ((Fin - Inicio) + 1) order by Inicio ";

			ISetDatos datos = BDVend.consultar(Consulta);

			FolioReservacion folioReservacion = null;
			if ((datos != null) && (datos.moveToFirst()) && (datos.getCount() > 0))
			{
				folioReservacion = new FolioReservacion();
				folioReservacion.FolioId = datos.getString("FolioId");
				folioReservacion.VendedorId = datos.getString("VendedorId");
				folioReservacion.RangoID = datos.getString("RangoID");
				folioReservacion.FechaHora = datos.getDate("FechaHora");
				folioReservacion.Inicio = datos.getInt("Inicio");
				folioReservacion.Fin = datos.getInt("Fin");
				folioReservacion.Usados = datos.getInt("Usados");
				folioReservacion.TipoEstado = datos.getShort("TipoEstado");
				folioReservacion.MFechaHora = datos.getDate("MFechaHora");
				folioReservacion.MUsuarioID = datos.getString("MUsuarioID");
			}
			else
			{
				if (mostrarMensajeError)
				{
					datos.close();
					throw new Exception(Mensajes.get("E0208"));
				}
			}
			datos.close();
			return folioReservacion;
		}

		public static FolioReservacion obtenerPropiedadesFolio(boolean mostrarMensajeError, int tipoModulo) throws Exception
		{

			ISetDatos modulo = BDVend.consultar("SELECT ModuloMovDetalleClave FROM ModuloMovDetalle WHERE TipoIndice=" + tipoModulo);

			String moduloMovDetalleClave = "";
			if ((modulo != null) && (modulo.moveToFirst()) && (modulo.getCount() > 0))
			{
				moduloMovDetalleClave = modulo.getString("ModuloMovDetalleClave");
			}

			modulo.close();

			FolioReservacion folioReservacion = null;
			if (!moduloMovDetalleClave.equals(""))
			{
				String Consulta = "SELECT FolioReservacion.* FROM FolioReservacion ";
				Consulta += " INNER JOIN Folio ON FolioReservacion.FolioID = Folio.FolioID ";
				Consulta += " WHERE Folio.ModuloMovDetalleClave='" + moduloMovDetalleClave + "' ";
				Consulta += " AND FolioReservacion.TipoEstado=1 AND Usados < ((Fin - Inicio) + 1) order by Inicio ";

				ISetDatos datos = BDVend.consultar(Consulta);

				if ((datos != null) && (datos.moveToFirst()) && (datos.getCount() > 0))
				{
					folioReservacion = (FolioReservacion) BDVend.instanciar(FolioReservacion.class, datos);
				}
				else
				{
					if (mostrarMensajeError)
					{
						throw new Exception(Mensajes.get("E0208"));
					}
				}
			}else{
				if (mostrarMensajeError)
				{
					throw new Exception(Mensajes.get("E0208"));
				}
			}

			return folioReservacion;
		}

		public static ISetDatos obtenerFolioDetalle(String folioId) throws Exception
		{

			ISetDatos datos = BDVend.consultar("SELECT TipoContenido,Formato FROM FolioDetalle WHERE FolioId='" + folioId + "' ORDER BY FolioDetClave");

			return datos;
		}

		public static boolean obtenerFolioTransProd(String FolioID) throws Exception
		{

			ISetDatos datos = BDVend.consultar("SELECT Folio From TransProd WHERE Folio='" + FolioID + "' ");

			while (datos.moveToNext())
			{
				return true;
			}
			return false;
		}

		public static boolean obtenerTransProdRelacionados(String FolioID, String DiaClave) throws Exception
		{

			StringBuilder sConsulta = new StringBuilder();

            //sConsulta.append("SELECT TransProd.TransProdID ");
            //sConsulta.append("From TransProd  ");
            //sConsulta.append("WHERE TransProd.Tipo in (2,8,10,19,21,23) ");
            //sConsulta.append("AND TransProd.FechaHoraAlta < (Select TransProd.FechaHoraAlta From TransProd WHERE Folio='" + FolioID + "' )");
            sConsulta.append("Select * from Visita ");
            sConsulta.append("where TipoEstado=1 AND ");
            sConsulta.append("RUTClave in (select rutclave from ruta) ");

			ISetDatos datos = BDVend.consultar(sConsulta.toString());

			while (datos.moveToNext())
			{
				return true;
			}
			return false;
		}
	}

	public static final class ConsultasAbnTrp
	{
        public static boolean tieneAbonosEnJornada(String TransProdId) throws Exception
        {
            return ((Float) BDVend.bd.ejecutarEscalarObject("SELECT count(*) FROM AbnTrp WHERE TransProdId = '" + TransProdId + "'")  <=0 ? false : true );
        }

		public static ISetDatos obtenerAbonos(String TransProdId) throws Exception
		{
			return BDVend.consultar("SELECT ABNId, Importe FROM AbnTrp WHERE TransProdId = '" + TransProdId + "'");
		}


		public static String obtenerMonedaId(String TransProdId) throws Exception
		{
			String id = null;
			ISetDatos datos = BDVend.consultar("SELECT MonedaID from AbnTrp inner join AbnDetalle on AbnTrp.ABNId = AbnDetalle.ABNId WHERE TransProdId = '" + TransProdId + "'");
			if (datos.getCount() > 0)
				id = datos.getString("MonedaId");
			datos.close();
			return id;
		}
	}

	public static final class ConsultasCliFormaVenta
	{
		/*
		 * public static ISetDatos obtenerFormaVentaInicial(String ClienteClave)
		 * throws Exception{ return BDVend.consultar(
		 * "SELECT CFVTipo, LimiteCredito, DiasCredito, Inicial FROM CliFormaVenta WHERE Inicial = 1 AND Estado = 1 AND ClienteClave = '"
		 * + ClienteClave + "'"); }
		 */

		public static ISetDatos obtenerFormaVenta(String ClienteClave) throws Exception
		{
			return BDVend.consultar("SELECT CFVTipo, LimiteCredito, DiasCredito, Inicial, CapturaDias FROM CliFormaVenta WHERE Estado = 1 AND ClienteClave = '" + ClienteClave + "'");
		}

		public static ISetDatos obtenerFormaVenta(String ClienteClave, int CFVTipo) throws Exception
		{
			return BDVend.consultar("SELECT CFVTipo, ValidaLimite, LimiteCredito, DiasCredito, Inicial, CapturaDias FROM CliFormaVenta WHERE Estado = 1 AND ClienteClave = '" + ClienteClave + "' and CFVTipo = " + CFVTipo);
		}
	}

	public static final class ConsultasClientePago
	{
		public static ISetDatos obtenerFormaPago(String ClienteClave) throws Exception
		{
			return BDVend.consultar("SELECT ClienteClave, Tipo FROM ClientePago WHERE TipoEstado = 1 AND ClienteClave = '" + ClienteClave + "'");
		}

		public static ISetDatos obtenerFormasPago(String clienteClave) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();

			sConsulta.append("SELECT Tipo, TipoBanco, Cuenta ");
			sConsulta.append("FROM ClientePago ");
			sConsulta.append("WHERE ClienteClave = '" + clienteClave + "' and TipoEstado = 1 ");

            ISetDatos FormasPagoCliente = BDVend.consultar(sConsulta.toString());

            if (FormasPagoCliente.getCount() == 0){
                sConsulta = new StringBuilder();
                sConsulta.append("SELECT VavClave as Tipo, 'No Definido' as TipoBanco, 'No Definido' as Cuenta ");
                sConsulta.append("FROM VarValor ");
                sConsulta.append("WHERE VarCodigo = 'PAGO' and Estado = 1 ");

                FormasPagoCliente = BDTerm.consultar(sConsulta.toString());
            }

            return FormasPagoCliente;
		}
	}

	public static final class ConsultasMoneda
	{
		public static ISetDatos obtenerMoneda(String MonedaID) throws Exception
		{
			return BDVend.consultar("SELECT MonedaID as _id, Nombre, TipoCodigo FROM Moneda WHERE MonedaID = '" + MonedaID + "'");
		}

		public static ISetDatos obtenerMonedas() throws Exception
		{
			return BDVend.consultar("SELECT MonedaID as _id, Nombre, TipoCodigo FROM Moneda");
		}

		public static ISetDatos obtenerMonedaSistema() throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct Moneda.MonedaID as _id, Moneda.Nombre as Descripcion ");
			consulta.append("from CONHist ");
			consulta.append("inner join Moneda on CONHist.MonedaID = Moneda.MonedaID ");

			return BDVend.consultar(consulta.toString());
		}

		public static String obtenerMonedaNombre(String MonedaID) throws Exception
		{
			ISetDatos dsMoneda = BDVend.consultar("SELECT Nombre, TipoCodigo FROM Moneda WHERE MonedaID = '" + MonedaID + "'");
			String nombre = "";
			while (dsMoneda.moveToNext())
			{
				nombre = dsMoneda.getString("Nombre") + " " + Consultas.ConsultasValorReferencia.obtenerDescripcion("CDGOMON", dsMoneda.getString("TipoCodigo"));
			}

			dsMoneda.close();
			return nombre;
		}
	}

	public static final class ConsultasTPDDesVendedor
	{
		public static void eliminarDescuentoPorDetalle(String TransProdId, String TransProdDetalleId) throws Exception
		{
			BDVend.ejecutarComando("DELETE FROM TPDDesVendedor WHERE TransProdId = '" + TransProdId + "' AND TransProdDetalleId = '" + TransProdDetalleId + "'");
		}

		public static void eliminarPorTransProd(String TransProdId) throws Exception
		{
			BDVend.ejecutarComando("DELETE FROM TPDDesVendedor WHERE TransProdId = '" + TransProdId + "'");
		}

		public static void obtenerDescuentoVendedor(String TransProdId) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("insert into TPDDesVendedor ");
			consulta.append("select TPD.TransProdId, TPD.TransProdDetalleId, avg(TRP.DescVendPor), ");
			consulta.append("(avg(TPD.SubTotal) - case when sum(TDD.DesImporte) is null then 0 else sum(TDD.DesImporte) end) * avg(TRP.DescVendPor)/100 as DesImporte, ");
			consulta.append("(avg(TPD.Impuesto) - case when sum(TDD.DesImpuesto) is null then 0 else sum(TDD.DesImpuesto) end) * avg(TRP.DescVendPor)/100 as DesImpuesto,  ");
			consulta.append("datetime('now'), '" + ((Vendedor) Sesion.get(Campo.VendedorActual)).USUId + "', 0 ");
			consulta.append("from TransProdDetalle TPD ");
			consulta.append("inner join TransProd TRP on TPD.TransProdId = TRP.TransProdId ");
			consulta.append("left join TpdDes TDD on TDD.TransProdId = TPD.TransProdId and TDD.TransProdDetalleId = TPD.TransProdDetalleId ");
			consulta.append("where TPD.TransProdId = '" + TransProdId + "' and (TRP.DescVendPor/100)>0 group by TPD.TransProdId, TPD.TransProdDetalleId ");
			BDVend.ejecutarComando(consulta.toString());
		}
	}

	public static final class ConsultasTrpPrp
	{
		public static void eliminarPorDetalle(String TransProdId, String TransProdDetalleId) throws Exception
		{
			BDVend.ejecutarComando("DELETE FROM TrpPrp WHERE TransProdId = '" + TransProdId + "' AND TransProdDetalleId = '" + TransProdDetalleId + "'");
		}

		public static void eliminarPorTransProd(String TransProdId) throws Exception
		{
			BDVend.ejecutarComando("DELETE FROM TrpPrp WHERE TransProdId = '" + TransProdId + "'");
		}
	}

    public static final class ConsultasTPDDatosExtra
    {
        public static void eliminarPorDetalle(String TransProdId, String TransProdDetalleId) throws Exception
        {
            BDVend.ejecutarComando("DELETE FROM TPDDatosExtra WHERE TransProdId = '" + TransProdId + "' AND TransProdDetalleId = '" + TransProdDetalleId + "'");
        }

        public static void eliminarPorTransProd(String TransProdId) throws Exception
        {
            BDVend.ejecutarComando("DELETE FROM TPDDatosExtra WHERE TransProdId = '" + TransProdId + "'");
        }
    }
	public static final class ConsultasCuotas
	{
		public static ISetDatos obtenerCuotasAsigVendedor(String vendedorID) throws Exception
		{
			return BDVend.consultar("SELECT CUOClave FROM CUOVen WHERE VendedorID = '" + vendedorID + "' AND Estado = 1");
		}

		public static ISetDatos obtenerCUOCliente(String CUOClave) throws Exception
		{
			return BDVend.consultar("SELECT * FROM CUOCliente WHERE CUOClave = '" + CUOClave + "' AND Estado = 1");
		}

		public static ISetDatos obtenerCUOCliente(String CUOClave, String ClienteClave, int Tipo) throws Exception
		{
			return BDVend.consultar("SELECT * FROM CUOCliente WHERE CUOClave = '" + CUOClave + "' AND ClienteClave = '" + ClienteClave + "' AND Tipo=" + Tipo + " AND Estado = 1");
		}

		public static ISetDatos obtenerCUOEsquema(String CUOClave) throws Exception
		{
			return BDVend.consultar("SELECT * FROM CUOEsquema WHERE CUOClave = '" + CUOClave + "' AND Estado = 1");
		}

		public static ISetDatos obtenerCUOProducto(String CUOClave) throws Exception
		{
			return BDVend.consultar("SELECT * FROM CUOProducto WHERE CUOClave = '" + CUOClave + "' AND Estado = 1");
		}

		public static ISetDatos obtenerCUOVendedor(String CUOClave) throws Exception
		{
			return BDVend.consultar("SELECT * FROM CUOVendedor WHERE CUOClave = '" + CUOClave + "' AND Estado = 1");
		}

		public static ISetDatos obtenerCuotaCumplida(String vendedorID) throws Exception
		{
			return BDVend.consultar("SELECT * FROM CuotaCumplida WHERE VendedorID = '" + vendedorID + "'");
		}

		public static ISetDatos obtenerCuotaCumplida(String cuoClave, String vendedorID, int tipo) throws Exception
		{
			return BDVend.consultar("SELECT * FROM CuotaCumplida WHERE VendedorID = '" + vendedorID + "' and CuoClave='" + cuoClave + "' and tipo=" + String.valueOf(tipo));
		}

		public static ISetDatos obtenerCUOEsquemasPorEsquemas(String CUOClave, String EsquemasId, int Tipo) throws Exception
		{
			return BDVend.consultar("SELECT DISTINCT EsquemaId FROM CUOEsquema WHERE CUOClave = '" + CUOClave + "' AND EsquemaId in (" + EsquemasId + ") AND Tipo = " + Tipo);
		}

		public static ISetDatos obtenerCUOProductoPorProductoClaveTipo(String CUOClave, String ProductoClave, int Tipo) throws Exception
		{
			return BDVend.consultar("SELECT CUOClave FROM CUOProducto WHERE CUOClave = '" + CUOClave + "' AND ProductoClave = '" + ProductoClave + "' AND Tipo = " + Tipo);
		}

		public static ISetDatos obtenerCUOClientePorClienteClaveTipo(String CUOClave, String ClienteClave, int Tipo) throws Exception
		{
			return BDVend.consultar("SELECT CUOCliente.* FROM CUOCliente WHERE CUOClave = '" + CUOClave + "' AND ClienteClave = '" + ClienteClave + "' AND Tipo = " + Tipo);
		}

		public static ISetDatos obtenerCuotasCliente() throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT CUV.CUOClave as _id,CUO.Descripcion,CLI.Clave || ' - ' || CLI.RazonSocial as Nombre,CUOC.Minimo,CUOC.Tipo, CUC.Cantidad ");
			consulta.append("FROM CUOVen CUV INNER JOIN CUOCliente CUOC on CUV.CUOClave = CUOC.CUOClave ");
			consulta.append("INNER JOIN CucCcu CUC ON CUV.CUOClave = CUC.CUOClave AND CUV.VendedorID = CUC.VendedorID AND CUOC.ClienteClave = CUC.ClienteClave ");
			consulta.append("INNER JOIN Cliente CLI ON CLI.ClienteClave = CUOC.ClienteClave ");
			consulta.append("INNER JOIN Cuota CUO on CUV.CUOClave = CUO.CUOClave ");
			consulta.append("WHERE CUV.VendedorID = '" + ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId + "' AND CUV.Estado = 1 AND CUOC.Estado = 1 ");
			consulta.append("ORDER BY CLI.Clave ");
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerCuotasEsquemaProducto() throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT CUV.CUOClave as _id,CUO.Descripcion,ESQ.Clave || ' - ' || ESQ.Nombre as Nombre,CUOE.Minimo,CUOE.Tipo, CUE.Cantidad ");
			consulta.append("FROM CUOVen CUV INNER JOIN CUOEsquema CUOE on CUV.CUOClave = CUOE.CUOClave ");
			consulta.append("INNER JOIN CueCcu CUE ON CUV.CUOClave = CUE.CUOClave AND CUV.VendedorID = CUE.VendedorID AND CUOE.EsquemaID = CUE.EsquemaID ");
			consulta.append("INNER JOIN Esquema ESQ ON ESQ.EsquemaID = CUOE.EsquemaID ");
			consulta.append("INNER JOIN Cuota CUO on CUV.CUOClave = CUO.CUOClave ");
			consulta.append("WHERE CUV.VendedorID = '" + ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId + "' AND CUV.Estado = 1 AND CUOE.Estado = 1 AND ESQ.Tipo = 2 ");
			consulta.append("ORDER BY ESQ.Clave ");
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerCuotasEsquemaCliente() throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT CUV.CUOClave as _id,CUO.Descripcion,ESQ.Clave || ' - ' || ESQ.Nombre as Nombre,CUOE.Minimo,CUOE.Tipo, CUE.Cantidad ");
			consulta.append("FROM CUOVen CUV INNER JOIN CUOEsquema CUOE on CUV.CUOClave = CUOE.CUOClave ");
			consulta.append("INNER JOIN CueCcu CUE ON CUV.CUOClave = CUE.CUOClave AND CUV.VendedorID = CUE.VendedorID AND CUOE.EsquemaID = CUE.EsquemaID ");
			consulta.append("INNER JOIN Esquema ESQ ON ESQ.EsquemaID = CUOE.EsquemaID ");
			consulta.append("INNER JOIN Cuota CUO on CUV.CUOClave = CUO.CUOClave ");
			consulta.append("WHERE CUV.VendedorID = '" + ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId + "' AND CUV.Estado = 1 AND CUOE.Estado = 1 AND ESQ.Tipo = 1 ");
			consulta.append("ORDER BY ESQ.Clave ");
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerCuotasProducto() throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT CUV.CUOClave as _id,CUO.Descripcion,CUOP.ProductoClave || ' - ' || PRO.Nombre as Nombre,CUOP.Minimo,CUOP.Tipo, CUP.Cantidad ");
			consulta.append("FROM CUOVen CUV INNER JOIN CUOProducto CUOP on CUV.CUOClave = CUOP.CUOClave ");
			consulta.append("INNER JOIN CupCcu CUP ON CUV.CUOClave = CUP.CUOClave AND CUV.VendedorID = CUP.VendedorID AND CUOP.ProductoClave = CUP.ProductoClave ");
			consulta.append("INNER JOIN Producto PRO ON PRO.ProductoClave = CUOP.ProductoClave ");
			consulta.append("INNER JOIN Cuota CUO on CUV.CUOClave = CUO.CUOClave ");
			consulta.append("WHERE CUV.VendedorID = '" + ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId + "' AND CUV.Estado = 1 AND CUOP.Estado = 1 ");
			consulta.append("ORDER BY CUOP.ProductoClave ");
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerCuotasVendedor() throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
			Usuario usuario = (Usuario) Sesion.get(Campo.UsuarioActual);
			consulta.append("SELECT CUV.CUOClave as _id,CUO.Descripcion,'" + usuario.Clave + " - " + vendedor.Nombre + "' as Nombre,CUOV.Minimo,CUOV.Tipo, CUC.Cantidad ");
			consulta.append("FROM CUOVen CUV INNER JOIN CUOVendedor CUOV on CUV.CUOClave = CUOV.CUOClave ");
			consulta.append("INNER JOIN CuotaCumplida CUC ON CUV.CUOClave = CUC.CUOClave AND CUV.VendedorID = CUC.VendedorID AND CUOV.Tipo = CUC.Tipo ");
			// consulta.append("INNER JOIN Vendedor VEN ON VEN.VendedorID = CUC.VendedorID ");
			// consulta.append("INNER JOIN Usuario USU ON USU.USUId = VEN.USUId ");
			consulta.append("INNER JOIN Cuota CUO on CUV.CUOClave = CUO.CUOClave ");
			consulta.append("WHERE CUV.VendedorID = '" + ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId + "' AND CUV.Estado = 1 AND CUOV.Estado = 1 ");
			// consulta.append("ORDER BY USU.Clave ");
			return BDVend.consultar(consulta.toString());
		}
	}

	public static final class ConsultasAbono
	{
		public static ArrayList<Cobranza.VistaCobranza> obtenerCobranzaPorVisita(String diaClave, String clienteClave, String visitaClave) throws Exception
		{
			ArrayList<Cobranza.VistaCobranza> abonos = new ArrayList<Cobranza.VistaCobranza>();
			StringBuilder consulta = new StringBuilder();
			consulta.append("select ABN.ABNId, ABN.Folio, Dia.FechaCaptura, ABN.Total ");
			consulta.append("from Abono ABN ");
			consulta.append("inner join Dia on ABN.DiaClave = Dia.DiaClave ");
			consulta.append("inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave AND VIS.DiaClave = ABN.DiaClave ");
            consulta.append("inner join AbnTrp ABT on ABT.ABNId = ABN.ABNId  ");
            consulta.append("inner join Transprod TRP on TRP.TransProdID= ABT.TransProdID ");
			consulta.append("where VIS.ClienteClave = '" + clienteClave + "' and VIS.DiaClave = '" + diaClave + "' AND VIS.VisitaClave = '" + visitaClave + "'");
            if (((CONHist) Sesion.get(Campo.CONHist)).get("PagoAutomatico").equals("1")) {
                consulta.append(" AND (TRP.CFVTipo is null or TRP.CFVTipo=2 Or (TRP.CFVTipo = 1 AND TRP.ClientePagoId <> 1 ))  ");
            }

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				Cobranza.VistaCobranza abono = new Cobranza.VistaCobranza(datos.getString(0), datos.getString(1), datos.getDate(2), datos.getFloat(3));
				abonos.add(abono);
			}

			datos.close();

			return abonos;
		}

		public static Cobranza.VistaDocumentos[] obtenerDocumentosEnCobranza(String abnid) throws Exception
		{
			ArrayList<Cobranza.VistaDocumentos> documentos = new ArrayList<Cobranza.VistaDocumentos>();
			StringBuilder consulta = new StringBuilder();
			consulta.append("select TransProdId, Folio, Fecha, Total - (case when DevolucionCons is null then 0 else DevolucionCons end) as Total, Saldo  from ( ");
			consulta.append("select TRP.TransProdId, TRP.Folio, case when TRP.Tipo = 1 or TRP.Tipo = 24 then FechaSurtido else FechaFacturacion end as Fecha, Total, Saldo, ");
			consulta.append("(select sum(Total) from TrpTpd TTP where TTP.TransProdId1 = TRP.TransProdId) as DevolucionCons ");
			consulta.append("from AbnTrp ABT ");
			consulta.append("inner join TransProd TRP on ABT.TransProdId = TRP.TransProdId ");
			consulta.append("where ABT.ABNId = '" + abnid + "' ");
			consulta.append(") as t ");
			consulta.append("order by Folio, Fecha ");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				Cobranza.VistaDocumentos documento = new Cobranza.VistaDocumentos(datos.getString(0), datos.getString(1), datos.getDate(2), datos.getFloat(3), datos.getFloat(4));
				documentos.add(documento);
			}
			datos.close();

			return documentos.toArray(new Cobranza.VistaDocumentos[documentos.size()]);
		}

		public static Cobranza.VistaDocumentos[] obtenerDocumentosPorCobrar(String clienteClave, short tipoCobranza) throws Exception
		{
			ArrayList<Cobranza.VistaDocumentos> documentos = new ArrayList<Cobranza.VistaDocumentos>();
			StringBuilder consulta = new StringBuilder();
			short trueType = 0;
			if (tipoCobranza == 2)
				trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(clienteClave);
			else
				trueType = tipoCobranza;

			if (trueType == 1)
				trueType = 1;
			else if (trueType == 0 || trueType == 2)
				trueType = 8;

			consulta.append("select TransProdId, Folio, Fecha, Total - (case when DevolucionCons is null then 0 else DevolucionCons end) as Total, Saldo - Cheque as Saldo from ( ");
			consulta.append("select TRP.TransProdId, TRP.Folio, case when TRP.Tipo = 1 or TRP.Tipo = 24 then FechaSurtido else FechaFacturacion end as Fecha, Total, Saldo, ");
			consulta.append("(select sum(Total) from TrpTpd TTP where TTP.TransProdId1 = TRP.TransProdId) as DevolucionCons, ");
			consulta.append("(Round(case WHEN TRC.AbnChequePosfechado is null THEN 0 ELSE TRC.AbnChequePosfechado END,2)) as Cheque ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
			consulta.append("left join (Select TransProdId, sum(AbnChequePosfechado) as AbnChequePosfechado from TRPCheque group by TransProdID) TRC on TRC.TransProdID = TRP.TransProdID ");
			consulta.append("where TRP.Tipo in (" + trueType + ", 24) ");
			consulta.append("and TRP.TipoFase <> 0 and TRP.Saldo > 0 and VIS.ClienteClave = '" + clienteClave + "' ");
            if (((CONHist) Sesion.get(Campo.CONHist)).get("PagoAutomatico").equals("1")) {
                consulta.append(" AND (TRP.CFVTipo is null or TRP.CFVTipo=2 Or (TRP.CFVTipo = 1 AND TRP.ClientePagoId <> 1 ))  ");
            }
			consulta.append(") as t ");
			consulta.append("order by Folio, Fecha ");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				if (Generales.getRound(datos.getFloat(4), 2) > 0)
				{
					Cobranza.VistaDocumentos documento = new Cobranza.VistaDocumentos(datos.getString(0), datos.getString(1), datos.getDate(2), datos.getFloat(3), datos.getFloat(4));
					documentos.add(documento);
				}
			}
			datos.close();

			return documentos.toArray(new Cobranza.VistaDocumentos[documentos.size()]);
		}

		public static ArrayList<Cobranza.VistaDetalle> obtenerDetallesEnCobranza(String abnid) throws Exception
		{

			ArrayList<Cobranza.VistaDetalle> detalles = new ArrayList<Cobranza.VistaDetalle>();
			// ISetDatos tiposPago =
			// Consultas.ConsultasValorReferencia.obtenerValoresReferencia("PAGO",
			// "");

			StringBuilder consulta = new StringBuilder();
			consulta.append("select ABDId, TipoPago, MON.MonedaID, Importe, TipoBanco, Referencia, FechaCheque, Observaciones ");
			consulta.append("from ABNDetalle ABD ");
			consulta.append("inner join Moneda MON on ABD.MonedaID = MON.MonedaID ");
			consulta.append("where ABNId = '" + abnid + "' ");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				String formaPago = Consultas.ConsultasValorReferencia.obtenerDescripcion("PAGO", datos.getString("TipoPago"));
				String banco = "";
				int tipoBanco = 0;
				if (!datos.isNull(4))
				{
					tipoBanco = datos.getInt("TipoBanco");
					banco = Consultas.ConsultasValorReferencia.obtenerDescripcion("TBANCO", datos.getString("TipoBanco"));
				}
				String moneda = Consultas.ConsultasMoneda.obtenerMonedaNombre(datos.getString("MonedaID"));

				Cobranza.VistaDetalle detalle = new Cobranza.VistaDetalle(datos.getString("ABDId"), datos.getInt("TipoPago"), formaPago, datos.getString("MonedaID"), moneda, datos.getFloat("Importe"), tipoBanco, banco, datos.getString("Referencia"), datos.getDate("FechaCheque"), datos.getString("Observaciones"));
				detalles.add(detalle);

			}
			datos.close();

			return detalles; // .toArray(new
								// Cobranza.VistaDetalle[detalles.size()]);
		}
		
		public static float obtenerSaldoDocumentos(ArrayList<String> transprodids) throws Exception
		{
			float saldo = 0;
			StringBuilder consulta = new StringBuilder();

			consulta.append("select sum(Saldo - (Round(case WHEN TRC.AbnChequePosfechado is null THEN 0 ELSE TRC.AbnChequePosfechado END,2))) as Saldo ");
			consulta.append("from TransProd TRP ");
			consulta.append("left join (Select TransProdId, sum(AbnChequePosfechado) as AbnChequePosfechado from TRPCheque group by TransProdID) TRC on TRC.TransProdID = TRP.TransProdID ");
			consulta.append("where TRP.TransProdId in (" + transprodids.toString().replace("[", "").replace("]", "") + ")");

			saldo = (Float) BDVend.bd.ejecutarEscalarObject(consulta.toString());
			return Generales.getRound(saldo, 2);
		}

		public static boolean tieneDocumentosFacturados(String abnid) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select count(TRP.TransProdId) as Facturados ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join AbnTrp ABT on TRP.TransProdId = ABT.TransProdId ");
			consulta.append("where ABT.ABNId = '" + abnid + "' and TRP.TipoFase = 3");

			return (BDVend.bd.ejecutarEscalarInteger(consulta.toString())) > 0;
		}

		public static ISetDatos obtenerDocumentosVencimiento(String clienteClave, String abnid, short tipoCobranza) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			short trueType;
			if (tipoCobranza == 2)
				trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(clienteClave);
			else
				trueType = tipoCobranza;

			if (trueType == 1)
				trueType = 1;
			else if (trueType == 0)
				trueType = 8;

			consulta.append("select distinct Folio,FechaSurtido,FechaCobranza,Total,Saldo,Transprodid ");
			consulta.append("from Transprod TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave ");
			consulta.append("where exists( select * from AbnTrp ABT1 where TRP.TransProdID = ABT1.TransProdID) ");
			consulta.append("and TRP.Tipo in (" + trueType + ", 24) ");
			consulta.append("and TRP.TipoFase <> 0 and VIS.ClienteClave = '" + clienteClave + "' and ");
			consulta.append("TRP.Transprodid in ( select TransProdID from AbnTrp ABT where ABT.ABNId = '" + abnid + "')");

			return BDVend.consultar(consulta.toString());
		}

		public static void obtenerCriteriosCobranza(String criterioOrdenacion, String vistaCampos) throws Exception
		{
			ISetDatos dsCriterios = BDVend.consultar("Select TipoCriterio, Ordenacion from CriterioCobranza order by Prioridad ");
			String sCampo = "";
			criterioOrdenacion = "";
			vistaCampos = "";
			while (dsCriterios.moveToNext())
			{
				sCampo = Consultas.ConsultasValorReferencia.obtenerDescripcion("TIPCRI", dsCriterios.getString("TipoCriterio"));
				criterioOrdenacion += sCampo + " " + (dsCriterios.getInt("Ordenacion") == 1 ? " asc" : " desc") + ",";
				if (!sCampo.toUpperCase().equals("SALDO"))
					vistaCampos += sCampo + ",";
			}

			if (criterioOrdenacion.length() > 0)
				criterioOrdenacion = criterioOrdenacion.substring(0, criterioOrdenacion.length() - 1);

			if (vistaCampos.length() > 0)
				vistaCampos = vistaCampos.substring(0, vistaCampos.length() - 1);

			dsCriterios.close();
		}

		public static ISetDatos obtenerDocumentosCriterio(ArrayList<String> transprodids, String sListadoCampos, String sCriterioOrdenacion) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select TransProd.TransprodId, ROUND(Saldo  - (CASE WHEN TRC.AbnChequePosfechado is null THEN 0 ELSE TRC.AbnChequePosfechado END),2) as Saldo ");
			consulta.append((sListadoCampos.equals("") ? " " : "," + sListadoCampos + " "));
			consulta.append("from transprod ");
			consulta.append("left join (Select TransProdId, sum(AbnChequePosfechado) as AbnChequePosfechado from TRPCheque group by TransProdID) TRC on TRC.TransProdID = TransProd.TransProdID ");
			consulta.append("where TransProd.Transprodid in (" + transprodids.toString().replace("[", "").replace("]", "") + ") ");
			consulta.append((sCriterioOrdenacion.equals("") ? " " : "order by " + sCriterioOrdenacion));

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerDocumentosCriterio(ArrayList<String> transprodids, short tipoCobranza) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			short trueType;
			if (tipoCobranza == 2)
				trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
			else
				trueType = tipoCobranza;

			if (trueType == 1)
				trueType = 1;
			else if (trueType == 0)
				trueType = 8;

			consulta.append("Select TransProd.TransprodId, ");
			consulta.append(((trueType == 1 ? true : false) ? "FechaCaptura" : "FechaFacturacion") + " as Fecha, ");
			consulta.append("ROUND(Saldo  - (CASE WHEN TRC.AbnChequePosfechado is null THEN 0 ELSE TRC.AbnChequePosfechado END),2) as Saldo ");
			consulta.append("from transprod ");
			consulta.append("left join (Select TransProdId, sum(AbnChequePosfechado) as AbnChequePosfechado from TRPCheque group by TransProdID) TRC on TRC.TransProdID = TransProd.TransProdID ");
			consulta.append("where TransProd.Transprodid in(" + transprodids.toString().replace("[", "").replace("]", "") + ") ");
			consulta.append("order by " + ((trueType == 1 ? true : false) ? "FechaCaptura" : "FechaFacturacion") + " , saldo ");

			return BDVend.consultar(consulta.toString());
		}
		
		public static float obtenerAbonosCheque(Cliente cliente, String tipo) throws Exception{
			float saldoAbono = 0f;
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT ifnull(sum(ABNDetalle.Importe),0) FROM ABNDetalle inner join AbnTrp on AbnTrp.ABNId = ABNDetalle.ABNId ");
			consulta.append("inner join TransProd as tp on AbnTrp.TransProdId = tp.TransProdId inner join Visita as v on v.VisitaClave = tp.VisitaClave ");
			consulta.append("and v.DiaClave = tp.DiaClave and tp.ClienteClave = v.ClienteClave where v.ClienteClave = '" + cliente.ClienteClave + "' and ABNDetalle.TipoPago = 2 ");
			consulta.append("tp.CFVTipo = 2 and (tp.Tipo = ".concat(tipo).concat(" or tp.Tipo = 24) and tp.TipoFase <> 0"));
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if (datos.moveToNext())
			{
				saldoAbono = datos.getFloat(0);
			}
			datos.close();
			
			return saldoAbono;
		}
		
		public static float obtenerTotalCobranza() throws Exception{
			float total = 0;
			StringBuilder consulta = new StringBuilder();
			consulta.append("select ifnull(sum(Total),0) ");
			consulta.append("from Abono");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			
			while (datos.moveToNext())
			{
				total = datos.getFloat(0);
			}
			datos.close();
			return total;
		}
		
		/**
		 * Obtiene el saldo de los abonos del cliente especificado, incluyendo o excluyendo
		 * las formas de pago especificadas en el argumento.
		 * @param cliente Cliente asociado a los abonos contemplados en la sumatoria
		 * @param in especifica en caso de ser vedadero que los tipos de pago son incluyentes, de 
		 * lo contrario no se incluyen.
		 * @param formasPago varags con los enteros que determinan las formas de pago de los abonos
		 * @return
		 * @throws Exception
		 */
		public static float obtenerSaldoAbonos(Cliente cliente, boolean in, int...formasPago) throws Exception{
			float saldoAbono = 0f;
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT ifnull(sum(Abn.Saldo),0) FROM Abono as Abn inner join Visita as v on v.VisitaClave = Abn.VisitaClave ");
			consulta.append("and Abn.DiaClave = v.DiaClave inner join ABNDetalle as AbnDet on AbnDet.ABNId = Abn.ABNId where v.ClienteClave = '" + cliente.ClienteClave + "'" );
			if(formasPago.length > 0){
				consulta.append(" and AbnDet.TipoPago ");
				consulta.append(in ? "in(" : "not in(");
				for(int i = 0; i < formasPago.length; i++){
					consulta.append(String.valueOf(formasPago[i]));
					if(i == formasPago.length - 1){
						consulta.append(")");
					}else{
						consulta.append(",");
					}
				}
			}
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if (datos.moveToNext())
			{
				saldoAbono = datos.getFloat(0);
			}
			datos.close();
			
			return saldoAbono;
		}
		public static List<ABNDetalle> obtenerAbonosConSaldoDeposito() throws Exception{
			List<ABNDetalle> list = new ArrayList<ABNDetalle>();
			ABNDetalle abd = null;
			String consulta = "Select distinct ABD.ABNId as ABNId, ABD.ABDId,IFNULL(ADEP.Importe, ABD.SaldoDeposito) as Importe, ABD.TipoPago as TipoPago,ABD.SaldoDeposito as SaldoDeposito from ABNDetalle  ABD left join AbdDep ADEP on ADEP.ABNId = ABD.ABNId and ADEP.ABDId= ABD.ABDId where ABD.SaldoDeposito>0  ";
			ISetDatos datos = BDVend.consultar(consulta);
			if (datos != null) {
				while (datos.moveToNext()) {
					abd = new ABNDetalle();
					abd.ABNId = datos.getString("ABNId");
					abd.ABDId = datos.getString("ABDId");
					abd.TipoPago = datos.getInt("TipoPago");
					abd.Importe = datos.getFloat("Importe");
					abd.SaldoDeposito = datos.getFloat("SaldoDeposito");
					list.add(abd);
				}
			}
			datos.close();

			return list;
		}
	}

	public static final class ConsultasVendedorMensaje
	{
		public static ISetDatos obtenerMensajes() throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT VendedorMensajeId as _id,VEM.*,Asunto,Descripcion FROM VendedorMensaje VEM inner join MDBMensaje MDB on VEM.MDBMensajeID = MDB.MDBMensajeID");
			return BDVend.consultar(consulta.toString());
		}

		public static pendientes[] obtenerListaMensajes() throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT VendedorMensajeId as _id,VEM.*,Asunto,Descripcion FROM VendedorMensaje VEM inner join MDBMensaje MDB on VEM.MDBMensajeID = MDB.MDBMensajeID order by VEM.MFechaHora desc");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			ArrayList<pendientes> mensajes = new ArrayList<pendientes>();
			while (datos.moveToNext())
			{
				pendientes nuevo = new pendientes();
				nuevo.VendedorMensajeId = datos.getString("VendedorMensajeId");
				nuevo.Asunto = datos.getString("Asunto");
				nuevo.Fecha = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss").parse(((Cursor) datos.getOriginal()).getString(6).substring(0, 19).replace("T", " ")); // datos.getDate("MFechaHora");
				nuevo.Descripcion = datos.getString("Descripcion");
				nuevo.Posponer = datos.getInt("Posponer");
				mensajes.add(nuevo);
			}
			datos.close();
			// return BDVend.consultar(consulta.toString());
			if (mensajes.size() > 0)
				return mensajes.toArray(new pendientes[mensajes.size()]);
			else
				return null;
		}
	}

	public static final class ConsultasInventario
	{
		public static ISetDatos obtenerProductoInventario(String productoClave, Integer tipoUnidad) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT ProductoDetalle.ProductoClave, ProductoDetalle.ProductoDetClave, ProductoDetalle.Factor, Producto.Venta as PROVenta, Producto.Contenido as PROContenido, INV.Disponible, INV.NoDisponible, INV.Apartado, INV.Contenido, INV.Pedido FROM ProductoDetalle inner join Producto on ProductoDetalle.ProductoClave = Producto.ProductoClave ");
			consulta.append("left join Inventario INV on INV.ProductoClave = ProductoDetalle.ProductoDetClave WHERE ProductoDetalle.ProductoClave='" + productoClave + "' and ProductoDetalle.PRUTipoUnidad=" + tipoUnidad);
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerInventarioPedido(String productoClave, Integer tipoUnidad, String AlmacenID) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select inventario.Pedido from productodetalle, inventario where inventario.almacenid='" + AlmacenID + "' and '");
			consulta.append(productoClave + "'=inventario.productoclave and inventario.productoclave=productodetalle.productoclave and inventario.productoclave=productodetalle.productodetclave and productodetalle.prutipounidad=" + tipoUnidad);
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerInventario() throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select INV.ProductoClave, INV.AlmacenID, INV.Disponible-INV.Contenido-INV.NoDisponible as Disponible,0 as NoDisponible, PDE.PRUTipoUnidad, PDE.Factor from Inventario INV ");
			consulta.append("inner join ProductoDetalle PDE on INV.ProductoClave = PDE.ProductoClave and INV.ProductoClave = PDE.ProductoDetClave and PDE.Factor=( ");
			consulta.append("Select min(PDE2.factor) from ProductoDetalle PDE2 where PDE2.ProductoClave = PDE.ProductoClave ) ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerInventarioDescarga() throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select INV.ProductoClave, INV.AlmacenID, INV.Disponible-INV.NoDisponible-INV.Contenido as Disponible,0 as NoDisponible, PDE.PRUTipoUnidad, PDE.Factor from Inventario INV ");
			consulta.append("inner join ProductoDetalle PDE on INV.ProductoClave = PDE.ProductoClave and INV.ProductoClave = PDE.ProductoDetClave and PDE.Factor=( ");
			consulta.append("Select min(PDE2.factor) from ProductoDetalle PDE2 where PDE2.ProductoClave = PDE.ProductoClave ) ");
			consulta.append("GROUP BY INV.ProductoClave,PDE.PRUTipoUnidad,PDE.Factor ");
			consulta.append("HAVING (INV.Disponible-INV.NoDisponible-INV.Contenido)>0 ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ListaInventario[] obtenerListaInventario()
		{
			ArrayList<ListaInventario> listInventario = null;
			try
			{
				StringBuilder query = new StringBuilder();
				//query.append("select i.ProductoClave, p.Nombre, pd.PRUTipoUnidad, i.disponible as Existencia,(i.disponible - i.nodisponible - i.Apartado -i.contenido - i.pedido) as Disponible, (i.nodisponible + i.Apartado + i.Pedido) as NoDisponible, i.NoDisponible as MalEstado, pu.kglts "); 
				query.append("select i.ProductoClave, p.Nombre, pd.PRUTipoUnidad, i.disponible as Existencia,(i.disponible - i.nodisponible - i.Apartado -i.contenido) as Disponible, (i.nodisponible + i.Apartado) as NoDisponible, i.NoDisponible as MalEstado, pu.kglts ");
				query.append("from Inventario i ");
				query.append("inner join Producto p on i.ProductoClave = p.ProductoClave ");
				query.append("inner join productounidad pu  on pu.productoclave = pd.productoclave ");
				//query.append("inner join ProductoDetalle pd on p.ProductoClave = pd.ProductoClave and pd.factor = 1 and p.ProductoClave = pd.ProductoDetClave ");
				query.append("inner join ProductoDetalle pd on p.ProductoClave = pd.ProductoClave and pd.factor = 1 and p.ProductoClave = pd.ProductoDetClave and pd.PRUTipoUnidad = pu.PRUTipoUnidad ");
				query.append("where  pu.TipoEstado = 1 and i.disponible > 0  order by i.ProductoClave");
				ISetDatos dataQuery = BDVend.consultar(query.toString());
				listInventario = new ArrayList<ListaInventario>();
				while (dataQuery.moveToNext())
				{
					ListaInventario itemInventory = new ListaInventario();
					itemInventory.productoClave = dataQuery.getString("ProductoClave");
					itemInventory.productoNombre = dataQuery.getString("Nombre");
					itemInventory.tipoUnidad = dataQuery.getInt("PRUTipoUnidad");
					itemInventory.existencia = dataQuery.getFloat("Existencia");
					itemInventory.disponible = dataQuery.getFloat("Disponible");
					itemInventory.noDisponible = dataQuery.getFloat("NoDisponible");
					itemInventory.malEstado = dataQuery.getFloat("MalEstado");
					itemInventory.kgLts = dataQuery.getFloat("KgLts");
					listInventario.add(itemInventory);
				}
				dataQuery.close();
			}
			catch (Exception ex)
			{

			}
			if (listInventario.size() > 0)
			{
				return listInventario.toArray(new ListaInventario[listInventario.size()]);
			}
			else
				return null;
		}
		
		public static ISetDatos obtenerInventarioParaReporte() throws Exception{
			StringBuilder query = new StringBuilder();
			query.append("select INV.ProductoClave, p.Nombre, PD.PRUTipoUnidad,");
			query.append("(select ifnull(sum(TPD.Cantidad*PDF.Factor),0) from transprod TRP ");
			query.append("inner join transproddetalle TPD on TRP.TransProdId = TPD.TransProdid and PD.ProductoClave = TPD.ProductoClave ");
			query.append("inner join ProductoDetalle as PDF on PDF.ProductoClave = TPD.ProductoClave and PDF.PRUTipoUnidad = TPD.TipoUnidad ");
            query.append("where INV.ProductoClave = TPD.ProductoClave and  ((TRP.Tipo = 2) or (TRP.Tipo=23 and not (TRP.DiaClave in (Select DiaClave from Dia where Dia.FueraFrecuencia = 0)))) and TRP.TipoFase = 1) as II,");

            query.append("(select ifnull(sum(TPD.Cantidad*PDF.Factor),0) from transprod TRP ");
			query.append("inner join Visita as V on V.VisitaClave = IFNULL(TRP.VisitaClave1,TRP.VisitaClave) ");
			query.append("inner join Dia on Dia.DiaClave = V.DiaClave and Dia.FueraFrecuencia = 0 ");
			query.append("inner join transproddetalle TPD on TRP.TransProdId = TPD.TransProdid ");
			query.append("inner join ProductoDetalle as PDF on PDF.ProductoClave = TPD.ProductoClave and PDF.PRUTipoUnidad = TPD.TipoUnidad ");
			query.append("and PD.ProductoClave = TPD.ProductoClave where INV.ProductoClave = TPD.ProductoClave and TRP.Tipo = 1 and TRP.TipoFase = 2) as Vta,");
			
			query.append("(INV.disponible - INV.nodisponible - INV.contenido) as IB,");
			
			query.append("(select ifnull(sum(TPD.Cantidad*PDF.Factor),0) from transprod TRP ");
			query.append("inner join transproddetalle TPD on TRP.TransProdId = TPD.TransProdid and TPD.TipoMotivo between 200 and 210 ");
			query.append("and PD.ProductoClave = TPD.ProductoClave ");
			query.append("inner join ProductoDetalle as PDF on PDF.ProductoClave = TPD.ProductoClave and PDF.PRUTipoUnidad = TipoUnidad ");
			query.append("where INV.ProductoClave = TPD.ProductoClave and TRP.Tipo = 9 and TRP.TipoFase = 1 and TipoMovimiento = 1)+");
			query.append("(select ifnull(sum(IT.Cantidad * PDF.Factor),0) from InventarioTraspaso as IT ");
			query.append("inner join ProductoDetalle as PDF on PDF.ProductoClave = IT.ProductoClave and PDF.PRUTipoUnidad = IT.TipoUnidad ");
			query.append("where IT.ProductoClave = INV.ProductoClave and IT.TipoMotivo between 30 and 34)as IM,");
			
			query.append("(select ifnull(sum(TPD.Cantidad*PDF.Factor),0) from transprod TRP ");
			query.append("inner join transproddetalle TPD on TRP.TransProdId = TPD.TransProdid and TPD.TipoMotivo = 211 ");
			query.append("and PD.ProductoClave = TPD.ProductoClave ");
			query.append("inner join ProductoDetalle as PDF on PDF.ProductoClave = TPD.ProductoClave and PDF.PRUTipoUnidad = TPD.TipoUnidad ");
			query.append("where INV.ProductoClave = TPD.ProductoClave and TRP.Tipo = 9 and TRP.TipoFase = 1 and TipoMovimiento = 1)+");
			query.append("(select ifnull(sum(IT.Cantidad * PD.Factor),0) from InventarioTraspaso as IT ");
			query.append("inner join ProductoDetalle as PDF on PDF.ProductoClave = IT.ProductoClave and PDF.PRUTipoUnidad = IT.TipoUnidad ");
			query.append("where IT.ProductoClave = INV.ProductoClave and IT.TipoMotivo = 35) as IF,");
			
			query.append("ifnull((select TPD.Precio from TransProdDetalle TPD inner join TransProd TRP on TPD.TransProdId = TRP.TransProdId where TRP.Tipo = 1 and TRP.TipoFase = 2 and TPD.ProductoClave = INV.ProductoClave order by TPD.MFechaHora desc limit 1),0) as Precio,");
			
			query.append("ifnull((select sum(TPD.Impuesto) from TransProdDetalle TPD inner join TransProd TRP on TPD.TransProdId = TRP.TransProdId where TRP.Tipo = 1 and TRP.TipoFase = 2 and TPD.ProductoClave = INV.ProductoClave),0) as Imp ");
			
			query.append("from Inventario INV inner join (select ProductoClave, PRUTipoUnidad, Factor from ProductoDetalle where Factor = 1) as PD on PD.ProductoClave = INV.ProductoClave inner join Producto p on ");
			query.append("INV.ProductoClave = p.ProductoClave order by INV.ProductoClave");
			ISetDatos dataQuery = BDVend.consultar(query.toString());
			return dataQuery;
		}
		
		public static float obtenerTotalProductosPorEsquemaClasificacionYTipoMotivo(int esquema, int...tipoMotivo) throws Exception{
			float total = 0;
			StringBuilder query = new StringBuilder();
			query.append("select ifnull(sum(TPD.Total),0) from transprod TRP ");
			query.append("inner join transproddetalle TPD on TRP.TransProdId = TPD.TransProdid ");
			query.append("inner join ProductoEsquema PE on PE.ProductoClave = TPD.ProductoClave ");
			query.append("inner join Esquema E on E.EsquemaId = PE.EsquemaId and E.Clasificacion = ").append(esquema);
			query.append(" where TRP.Tipo = 9 and TRP.TipoFase = 1 and TipoMovimiento = 1 and TPD.TipoMotivo ");
			if(tipoMotivo.length == 2)
				query.append("between ").append(tipoMotivo[0]).append(" and ").append(tipoMotivo[1]);
			else if(tipoMotivo.length == 1){
				query.append("= ").append(tipoMotivo[0]);
			}else throw new IllegalArgumentException();
			
			ISetDatos dataQuery = BDVend.consultar(query.toString());
			if(dataQuery.moveToNext())
			{
				total = dataQuery.getFloat(0);
			}
			dataQuery.close();
			return total;
		}
		
		public static float obtenerTotalCajasVendidasPorEsquemaClasificacion(String clasificacion) throws Exception{
			float total = 0;
			StringBuilder query = new StringBuilder();
			query.append("select ifnull(sum(TPD.Cantidad/PD.Factor),0) from ProductoDetalle PD ");
			query.append("inner join TransProdDetalle TPD on PD.ProductoClave = TPD.ProductoClave ");
			query.append("inner join ProductoUnidad PU on PU.ProductoClave = PD.ProductoClave ");
			query.append("inner join TransProd TRP on TRP.TransProdId = TPD.TransProdId ");
			query.append("inner join ProductoEsquema PES on PES.ProductoClave = TPD.ProductoClave ");
			query.append("inner join Esquema E on E.EsquemaId = PES.EsquemaId ");
			query.append("where TRP.Tipo = 1 and TRP.TipoFase = 2 and ((TPD.TipoUnidad <> 3 and PD.PRUTipoUnidad = 3 and PU.TipoEstado = 2) or TPD.TipoUnidad == 3) ");
			query.append("and E.Clasificacion = ").append(clasificacion);
			ISetDatos dataQuery = BDVend.consultar(query.toString());
			if(dataQuery.moveToNext())
			{
				total = dataQuery.getFloat(0);
			}
			dataQuery.close();
			return total;
		}

		public static HashMap<String, Inventario> obtenerInventarioProducto(String productoClave) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			ISetDatos dsProducto;
			HashMap<String, Inventario> hpRes = new HashMap<String, Inventario>();

			sConsulta.append("Select * from Inventario where ProductoClave in(Select ProductoDetClave from productodetalle where  ProductoClave ='" + productoClave + "')");
			dsProducto = BDVend.consultar(sConsulta.toString());

			if (dsProducto != null && dsProducto.getCount() > 0)
			{
				while (dsProducto.moveToNext())
				{
					hpRes.put(dsProducto.getString("ProductoClave"), (Inventario) BDVend.instanciar(Inventario.class, dsProducto));
				}
			}

			return hpRes;
		}

		public static float obtenerExistencia(String productoClave, String listaPrecios, boolean isDevolucion) throws Exception
		{

			StringBuilder consulta = new StringBuilder();

			float existencia = 0;
			if (isDevolucion)
				consulta.append("Select IFNULL(sum(INV.NoDisponible)/PDE.Factor,0) as Existencia ");
			else
				consulta.append("Select IFNULL(sum(INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido)/PDE.Factor,0) as Existencia ");
			consulta.append("From Inventario INV ");
			consulta.append("Inner join Producto PRO on PRO.ProductoClave = INV.ProductoClave ");
			consulta.append("Inner join ProductoUnidad PRU on PRU.ProductoClave = INV.ProductoClave ");
			consulta.append("Inner join ProductoDetalle PDE on PRO.ProductoClave = PDE.ProductoClave and PRU.PRUTipoUnidad = PDE.PRUTipoUnidad and PRO.ProductoClave = PDE.ProductoDetClave and ");
			consulta.append("PDE.Factor= (Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave in (" + listaPrecios + ")) ");
			consulta.append("Where INV.ProductoClave = '" + productoClave + "' and PRU.TipoEstado = 1 ");

			ISetDatos datos = BDVend.consultar(consulta.toString());

			if (datos.getCount() > 0)
			{
				datos.moveToFirst();
				existencia = datos.getFloat("Existencia");
			}

			datos.close();

			return existencia;
		}
		
		public static float obtenerExistencia(String productoClave, int ubicacionExistencia) throws Exception
		{

			StringBuilder consulta = new StringBuilder();

			float existencia = 0;
			if(ubicacionExistencia == 1)
				consulta.append("Select IFNULL(sum(INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido)/PDE.Factor,0) as Existencia ");
			else if(ubicacionExistencia == 2)
				consulta.append("Select IFNULL(sum(INV.NoDisponible)/PDE.Factor,0) as Existencia ");
			consulta.append("From Inventario INV ");
			consulta.append("Inner join Producto PRO on PRO.ProductoClave = INV.ProductoClave ");
			consulta.append("Inner join ProductoUnidad PRU on PRU.ProductoClave = INV.ProductoClave ");
			consulta.append("Inner join ProductoDetalle PDE on PRO.ProductoClave = PDE.ProductoClave and PRU.PRUTipoUnidad = PDE.PRUTipoUnidad and PRO.ProductoClave = PDE.ProductoDetClave and ");
			consulta.append("PDE.Factor = (Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 where ProductoClave = ProductoDetClave and ProductoClave = '"+productoClave+"') ");
			consulta.append("Where INV.ProductoClave = '" + productoClave + "' and PRU.TipoEstado = 1 ");

			ISetDatos datos = BDVend.consultar(consulta.toString());

			if (datos.getCount() > 0)
			{
				datos.moveToFirst();
				existencia = datos.getFloat("Existencia");
			}

			datos.close();

			return existencia;
		}
	}

	public static final class ConsultaPreLiquidacion
	{
		public static ISetDatos obtenerPreLiquidacion() throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT PLIId, FechaPreLiquidacion ,MontoTotal , Enviado ");
			consulta.append("FROM PreLiquidacion ");
			consulta.append("Where Enviado=0 ");
			return BDVend.consultar(consulta.toString());

		}

		public static ISetDatos obtenerDetallePreLiquidacion(String PLIId, boolean Tipo, boolean Busqueda) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT PLBPLE.PLIId as _id, PLBPLE.PBEId, FechaDeposito, TipoBanco, Referencia, Total, Ficha, TipoEfectivo, PLBPLE.Enviado ");
			consulta.append("FROM PLBPLE JOIN PreLiquidacion on PLBPLE.PLIId = PreLiquidacion.PLIId ");
			consulta.append("Where PLBPLE.Enviado=0 and PreLiquidacion.PLIId ='" + PLIId + "'");
			if (Busqueda)
				if (Tipo)
					consulta.append(" And PLBPLE.TipoBanco IS Null");
				else
					consulta.append(" And PLBPLE.TipoBanco IS Not Null");

			return BDVend.consultar(consulta.toString());

		}

		public static float obtenerSuma(String PLIId, boolean Tipo) throws Exception
		{

			float mTotal = 0;
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT SUM(Total) as Total ");
			consulta.append("FROM PLBPLE JOIN PreLiquidacion on PLBPLE.PLIId = PreLiquidacion.PLIId ");
			consulta.append("Where PLBPLE.Enviado=0 and PreLiquidacion.PLIId ='" + PLIId + "'");
			if (Tipo)
				consulta.append(" And PLBPLE.TipoBanco IS Null");
			else
				consulta.append(" And PLBPLE.TipoBanco IS Not Null");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			if (datos.getCount() > 0)
			{
				datos.moveToFirst();
				mTotal = datos.getFloat("Total");
			}
			datos.close();
			return mTotal;

		}

		public static PLBPLE obtenerPreLiquidacion(String PLIId, String PBEId) throws Exception
		{

			PLBPLE mPLBPLE = new PLBPLE();
			mPLBPLE.PBEId = PBEId;
			BDVend.recuperar(mPLBPLE);
			BDVend.eliminar(mPLBPLE);
			return mPLBPLE;

		}

		public static PLBPLE obtenerPreLiquidacionUnidad(String PLIId, String TipoEfectivo) throws Exception
		{

			PLBPLE mPLBPLE = new PLBPLE();
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT PLBPLE.PLIId ,PBEId ,TipoEfectivo ");
			consulta.append("FROM PLBPLE JOIN PreLiquidacion on PLBPLE.PLIId = PreLiquidacion.PLIId ");
			consulta.append("Where PLBPLE.Enviado=0 and PreLiquidacion.PLIId ='" + PLIId + "'");
			consulta.append(" And PLBPLE.TipoBanco IS Null");
			consulta.append(" and PLBPLE.TipoEfectivo=" + TipoEfectivo);

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				mPLBPLE.PBEId = datos.getString(1);
				mPLBPLE.PLIId = datos.getString(0);
				mPLBPLE.TipoEfectivo = datos.getString(2);
				return mPLBPLE;
			}
			datos.close();
			return null;

		}

		public static ArrayList<Deposito> obtenerTotalDeposito(String DEPId) throws Exception
		{

			ArrayList<Deposito> mArrayDeposito = new ArrayList<Deposito>();

			StringBuilder consulta = new StringBuilder();
			consulta.append("Select DEPId, DiaClave, TipoBanco, FechaCreacion, FechaDeposito, Ficha, Total, MFechaHora, MUsuarioID ");
			consulta.append("FROM Deposito ");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				Deposito mDeposito = new Deposito();
				mDeposito.DEPId = datos.getString(0);
				mDeposito.DiaClave = datos.getString(1);
				mDeposito.TipoBanco = datos.getShort(2);
				mDeposito.FechaCreacion = datos.getString(3);
				mDeposito.FechaDeposito = datos.getDate(4);
				mDeposito.Ficha = datos.getString(5);
				mDeposito.Total = datos.getFloat(6);
				mDeposito.MFechaHora = datos.getDate(7);
				mDeposito.MUsuarioID = datos.getString(8);
				mArrayDeposito.add(mDeposito);
			}
			datos.close();
			return mArrayDeposito;

		}
	}

	public static final class ConsultaDeposito
	{
		
		/*public static ISetDatos obtenerDepositosAImprimir() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select DEPId as _id, 0 as Tipo, 'DEP' as TipoRecibo, Ficha, FechaDeposito, Total, TipoBanco ");
			consulta.append("From Deposito ORDER BY FechaDeposito");
			return BDVend.consultar(consulta.toString());
		}*/
		
		public static float obtenerTotalVenta() throws Exception{
			float mTotal = 0;
			StringBuilder consulta = new StringBuilder();
			consulta.append("select ifnull(sum(ATRP.Importe),0) as Total from Abono ABN inner join AbnTrp ATRP on ABN.ABNId = ATRP.ABNId inner join TransProd TRP on TRP.TransProdId = ATRP.TransProdId WHERE ABN.DiaClave in (select DiaClave from Dia where FueraFrecuencia = 0) AND (TRP.DiaClave in (select DiaClave from Dia where FueraFrecuencia = 0) or TRP.DiaClave1 in (select DiaClave from Dia where FueraFrecuencia = 0)) AND TRP.Tipo = 1 AND  TRP.TipoFase in (2,3)");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if (datos.getCount() > 0)
			{
				datos.moveToFirst();
				mTotal = datos.getFloat("Total");
			}
			datos.close();
			return mTotal;
		}
		
		public static float obtenerTotalDev() throws Exception{
			float mTotal = 0;
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT ifnull(SUM(Total),0) as Total FROM Transprod WHERE Tipo = 3 AND TipoFase != 0 GROUP BY Tipo");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if (datos.getCount() > 0)
			{
				datos.moveToFirst();
				mTotal = datos.getFloat("Total");
			}
			datos.close();
			return mTotal;
		}
		
		public static float obtenerTotalDepyEf() throws Exception
		{

			float mTotal = 0;
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select Sum(Abono.Total) as Total ");
			consulta.append("FROM Abono JOIN Dia ON Abono.DiaClave = Dia.DiaClave ");
			consulta.append("Where Dia.FueraFrecuencia = 0");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if (datos.getCount() > 0)
			{
				datos.moveToFirst();
				mTotal = datos.getFloat("Total");
			}
			datos.close();
			return mTotal;

		}

		public static float obtenerTotalDeposito() throws Exception
		{

			float mTotal = 0;
			StringBuilder consulta = new StringBuilder();
			//consulta.append("Select Sum(Total) as Total ");
			//consulta.append("FROM Deposito");
            consulta.append("select sum(t.Total) as Total ");
            consulta.append("from ( ");
            consulta.append("select DEPId as _id, Ficha, FechaDeposito, Total, TipoBanco ");
            consulta.append("from Deposito ");
            consulta.append("union all ");
            consulta.append("select PBEId as _id, Ficha, FechaDeposito, Total, TipoBanco ");
            consulta.append("from PlbPle ");
            consulta.append("where TipoBanco is not null ");
            consulta.append(") as t ");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if (datos.getCount() > 0)
			{
				datos.moveToFirst();
				mTotal = datos.getFloat("Total");
			}
			datos.close();
			return mTotal;

		}

        public static float obtenerTotalEfectivoPreliquidacion() throws Exception {
            float mTotalEfectivoPre = 0;
            StringBuilder consulta = new StringBuilder();
            consulta.append("select ifnull(sum(Total),0) as Total ");
            consulta.append("from PlbPle ");
            consulta.append("where TipoBanco is null ");
            ISetDatos datos = BDVend.consultar(consulta.toString());
            if (datos.getCount() > 0){
                datos.moveToFirst();
                mTotalEfectivoPre = datos.getFloat("Total");
            }
            datos.close();
            return mTotalEfectivoPre;
        }

		public static float obtenerTotalDevoluciones() throws Exception
		{

			float mTotal = 0;
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select Sum(TransProd.Total) as Total ");
			consulta.append("FROM TransProd ");
			consulta.append("WHERE TransProd.Tipo = 3 And TransProd.TipoFase <> 0 ");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if (datos.getCount() > 0)
			{
				datos.moveToFirst();
				mTotal = datos.getFloat("Total");
			}
			datos.close();
			return mTotal;

		}

		public static ISetDatos obtenerDepositosRealizados() throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			//consulta.append("Select DEPId as _id, Ficha, FechaDeposito, Total, TipoBanco ");
			//consulta.append("From Deposito ORDER BY FechaDeposito");
            consulta.append("select t._id as _id, t.Ficha as Ficha, t.FechaDeposito as FechaDeposito, t.Total as Total, t.TipoBanco as TipoBanco ");
            consulta.append("from ( ");
            consulta.append("select DEPId as _id, Ficha, FechaDeposito, Total, TipoBanco ");
            consulta.append("from Deposito ");
            consulta.append("union all ");
            consulta.append("select PBEId as _id, Ficha, FechaDeposito, Total, TipoBanco ");
            consulta.append("from PlbPle ");
            consulta.append("where TipoBanco is not null ");
            consulta.append(") as t ");
            consulta.append("order by t.FechaDeposito ");
			return BDVend.consultar(consulta.toString());

		}

		public static String obtenerDiaCreacion(String DiaClave) throws Exception
		{
			String mTotal = null;
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select Dia.FechaCaptura ");
			consulta.append("From Dia ");
			consulta.append("Where Dia.DiaClave = '" + DiaClave + "'");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if (datos.getCount() > 0)
			{
				datos.moveToFirst();
				mTotal = datos.getString(0);
			}
			datos.close();
			return mTotal;

		}
	}

    public static final class ConsultaCobranzaMultiple{
        public static String obtenerFolioAbono(String sAbnId) throws Exception{
            String sFolio = "";
            StringBuilder consulta = new StringBuilder();
            consulta.append("Select Folio as Folio ");
            consulta.append("From Abono ");
            consulta.append("Where AbnId = '" + sAbnId + "'");
            consulta.append("limit 1 ");
            ISetDatos datos = BDVend.consultar(consulta.toString());
            if (datos.moveToNext())
            {
                sFolio = datos.getString(0);
            }
            datos.close();
            return sFolio;
        }

        public static ISetDatos DatosCobranza(String sAbnId) throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select a.ABNId as ABNId, a.VisitaClave as VisitaClave, a.DiaClave as DiaClave, a.FechaAbono as FechaAbono, a.Folio as Folio, a.Total as Total ");
            consulta.append("from Abono a ");
            consulta.append("inner join Visita v on a.VisitaClave = v.VisitaClave and a.DiaClave = v.DiaClave ");
            consulta.append("inner join Ruta r on v.RutClave = r.RutClave ");
            //consulta.append("where a.ABNId='" + sAbnId + "'");
            consulta.append("where a.Folio='" + sAbnId + "'");
            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos DatosEmpresa() throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("Select NombreEmpresa as NombreEmpresa, Calle as Calle, Numero as Numero, Colonia as Colonia, Ciudad as Ciudad, Region as Region, RFC as RFC, Telefono as Telefono ");
            consulta.append("from Configuracion");
            return BDTerm.consultar(consulta.toString());
        }

        public static ISetDatos DatosCliente(String sClienteClave) throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select Clave as Clave, RazonSocial as RazonSocial, TipoFiscal as TipoFiscal ");
            consulta.append("from Cliente ");
            consulta.append("where ClienteClave='" + sClienteClave + "'");
            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos DatosDetalleAbono(String sAbnId) throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("Select ad.Importe as Importe, ad.Referencia as Referencia, ad.TipoPago as TipoPago, ad.TipoBanco as TipoBanco ");
            consulta.append("from Abono a ");
            consulta.append("inner join ABNDetalle ad on a.AbnId=ad.AbnId ");
            //consulta.append("where a.ABNId='" + sAbnId + "'");
            consulta.append("where a.Folio='" + sAbnId + "'");
            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos DatosDetallePagos(String sAbnId) throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select distinct t.Folio as Folio, t.FechaHoraAlta as FechaHoraAlta, t.Total as Total, t.Saldo as Saldo ");
            consulta.append("from Abono a ");
            consulta.append("inner join AbnTrp at on a.Abnid = at.Abnid ");
            consulta.append("inner join TransProd t on at.TransprodID=t.TransprodID ");
            //consulta.append("where a.AbnId='" + sAbnId + "'");
            consulta.append("where a.Folio='" + sAbnId + "'");
            return BDVend.consultar(consulta.toString());
        }
    }

    public static final class ConsultaCobranzaMultipleGeneral{
        public static String obtenerFolioAbono(String sAbnId) throws Exception{
            String sFolio = "";
            StringBuilder consulta = new StringBuilder();
            consulta.append("Select Folio as Folio ");
            consulta.append("From Abono ");
            consulta.append("Where AbnId = '" + sAbnId + "'");
            consulta.append("limit 1 ");
            ISetDatos datos = BDVend.consultar(consulta.toString());
            if (datos.moveToNext())
            {
                sFolio = datos.getString(0);
            }
            datos.close();
            return sFolio;
        }

        public static ISetDatos DatosCobranza(String sAbnId) throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select a.ABNId as ABNId, a.VisitaClave as VisitaClave, a.DiaClave as DiaClave, a.FechaAbono as FechaAbono, a.Folio as Folio, a.Total as Total ");
            consulta.append("from Abono a ");
            consulta.append("inner join Visita v on a.VisitaClave = v.VisitaClave and a.DiaClave = v.DiaClave ");
            consulta.append("inner join Ruta r on v.RutClave = r.RutClave ");
            //consulta.append("where a.ABNId='" + sAbnId + "'");
            consulta.append("where a.Folio='" + sAbnId + "'");
            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos DatosEmpresa() throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("Select NombreEmpresa as NombreEmpresa, Calle as Calle, Numero as Numero, Colonia as Colonia, Ciudad as Ciudad, Region as Region, RFC as RFC, Telefono as Telefono ");
            consulta.append("from Configuracion");
            return BDTerm.consultar(consulta.toString());
        }

        public static ISetDatos DatosCliente(String sClienteClave) throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select Clave as Clave, RazonSocial as RazonSocial, TipoFiscal as TipoFiscal ");
            consulta.append("from Cliente ");
            consulta.append("where ClienteClave='" + sClienteClave + "'");
            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos DatosDetalleAbono(String sAbnId) throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("Select ad.Importe as Importe, ad.Referencia as Referencia, ad.TipoPago as TipoPago, ad.TipoBanco as TipoBanco ");
            consulta.append("from Abono a ");
            consulta.append("inner join ABNDetalle ad on a.AbnId=ad.AbnId ");
            //consulta.append("where a.ABNId='" + sAbnId + "'");
            consulta.append("where a.Folio='" + sAbnId + "'");
            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos DatosDetallePagos(String sAbnId) throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select distinct t.Folio as Folio, t.FechaHoraAlta as FechaHoraAlta, (sum(at.Importe)+t.Saldo) as SaldoAnterior, sum(at.Importe) as Importe, t.Saldo as Saldo ");
            consulta.append("from Abono a ");
            consulta.append("inner join AbnTrp at on a.Abnid = at.Abnid ");
            consulta.append("inner join TransProd t on at.TransprodID=t.TransprodID ");
            //consulta.append("where a.AbnId='" + sAbnId + "'");
            consulta.append("where a.Folio='" + sAbnId + "'");
            consulta.append("group by t.Folio, t.FechaHoraAlta, t.Saldo ");
            return BDVend.consultar(consulta.toString());
        }
    }

	public static final class ConsultasKilometraje
	{
		public static boolean existeKilometrajeCapturado() throws Exception{			
			ISetDatos datos = BDVend.consultar("select count(CAMVENId) from CamionVendedor where IFNULL(KmFinal,0) = 0 and Enviado = 0");
			if (datos.getCount() >0 ){
				if (datos.moveToFirst()){
					if (datos.getInt(0) >0){
						return true;
					}
				}				
			}
			datos.close();
			return false;
		}
		public static CamionVendedor obtenerCamiondeVendedor() throws Exception
		{
			CamionVendedor mCamionVendedor = new CamionVendedor();
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select CAMVENId, Placa, FechaHoraInicial, KMInicial, KMFinal ");
			consulta.append("FROM CamionVendedor ");
			consulta.append("Where KMFinal = 0.0 And Enviado=0 ");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				mCamionVendedor.CAMVENId = datos.getString(0);
				mCamionVendedor.Placa = datos.getString(1);
				mCamionVendedor.FechaHoraInicial = datos.getDate(2);
				mCamionVendedor.KmInicial = datos.getFloat(3);
				mCamionVendedor.KmFinal = datos.getFloat(4);
			}
			datos.close();
			return mCamionVendedor;

		}

		public static CamionVendedor obtenerCamiondeVendedor(String Placa) throws Exception
		{
			CamionVendedor mCamionVendedor = new CamionVendedor();
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select CAMVENId, Placa, FechaHoraInicial, KMInicial, KMFinal ");
			consulta.append("FROM CamionVendedor ");
			consulta.append("Where Placa = '" + Placa + "'");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				mCamionVendedor.CAMVENId = datos.getString(0);
				mCamionVendedor.Placa = datos.getString(1);
				mCamionVendedor.FechaHoraInicial = datos.getDate(2);
				mCamionVendedor.KmInicial = datos.getFloat(3);
				mCamionVendedor.KmFinal = datos.getFloat(4);
			}
			datos.close();
			return mCamionVendedor;

		}

		public static CamionVendedor obtenerCamion(String Placas) throws Exception
		{
			CamionVendedor mCamionVendedor = new CamionVendedor();
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select Placa, Clave ");
			consulta.append("FROM Camion ");
			consulta.append("Where Camion.Placa = '" + Placas + "'");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				mCamionVendedor.Placa = datos.getString(0);
				mCamionVendedor.Clave = datos.getString(1);
			}
			datos.close();
			return mCamionVendedor;

		}

        public static String obtenerKilometrajeFinal(String placa, String clave) throws Exception {
            String kmFinal = "";
            StringBuilder consulta = new StringBuilder();
            consulta.append("Select KmFinal ");
            consulta.append("FROM CamionVendedor ");
            consulta.append("Where Placa = '" + placa + "'");

            ISetDatos datos = BDVend.consultar(consulta.toString());
            while (datos.moveToNext()) {

                //kmFinal = String.valueOf(datos.getFloat(0));
                kmFinal = datos.getString(0);
            }

            return kmFinal;
        }

	}

	public static final class ConsultaRegistroInicioFin
	{

		public static String obtenerClientesPorSurtir() throws Exception
		{
			
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select distinct CLI.Clave as Clave ");
			consulta.append("FROM TransProd TRP inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ");
			consulta.append("inner join Cliente CLI on CLI.ClienteClave = VIS.ClienteClave ");
			consulta.append("Where TRP.Tipo = 1 And TRP.TipoFase = 1 ");

			String res = "";
			ISetDatos datos = BDVend.consultar(consulta.toString());			
			while (datos.moveToNext())
			{
				res += datos.getString("Clave") + ",";
			}
			datos.close();

			return res;
		}

		public static boolean obtenerRelacion(String VendedorId, String diaClave) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select Agenda.ClienteClave, Agenda.VendedorId ");
			consulta.append("From Agenda ");
			consulta.append("Where Agenda.VendedorId= '" + VendedorId + "' and DiaClave = '"+diaClave+"'");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			ISetDatos datos2 = null;
			int contador = 0;
			while (datos.moveToNext())
			{
				
				consulta = new StringBuilder();
				consulta.append("Select ClienteClave,  VendedorId ");
				consulta.append("From Visita ");
				consulta.append("Where ClienteClave='" + datos.getString(0) + "'");

				datos2 = BDVend.consultar(consulta.toString());
				
				if(datos2.getCount() > 0)
				{
					contador++;
				}

			}
		//	Log.i(null,"datos: "+datos.getCount()+" datos2: "+datos2.getCount()+" Vendedor: "+VendedorId);
			if (datos.getCount() == contador)
			{
				return true;
			}

			return false;
		}

		public static boolean obtenerAgenda(String VendedorId) throws Exception
		{

			StringBuilder consulta = new StringBuilder();
			consulta.append("Select Agenda.VendedorID, Agenda.DiaClave, Dia.DiaClave, FueraFrecuencia, VEJFechaInicial, FechaFinal ");
			consulta.append("From Agenda Join Dia On Dia.DiaClave = Agenda.DiaClave Join VendedorJornada On VendedorJornada.VendedorId = Agenda.VendedorId ");
			consulta.append("Where Dia.FueraFrecuencia = 0 And VendedorJornada.FechaFinal Is Null And VendedorJornada.VEJFechaInicial Is Not Null And" +
					" Agenda.VendedorId= '" + VendedorId + "'");
			ISetDatos datos = BDVend.consultar(consulta.toString());

			while (datos.moveToNext())
			{
				if (Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("ValidaInv").toString()) == 0 && Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("Inventario").toString()) == 1)
				{

					StringBuilder consultaInv = new StringBuilder();
					consultaInv.append("Select Contenido,Disponible,NoDisponible,Apartado ");
					consultaInv.append("From Inventario ");
					consultaInv.append("Where Inventario.Contenido !=0 And Inventario.Disponible != 0 And Inventario.NoDisponible != 0 And Inventario.Apartado != 0 ");
					ISetDatos Inventario = BDVend.consultar(consultaInv.toString());
					Inventario.moveToFirst();
					Log.e("", "" + Inventario.getCount());

					if (Inventario.getCount() != 0)
					{
						return true;
					}

				}
			}
			return false;
		}

        public static boolean UltimoDiaDeTrabajo() throws Exception{
            Integer nTotalDia = 0;
            Integer nTotalVej = 0;

            StringBuilder consulta = new StringBuilder();
            consulta.append("select count(Dia.DiaClave) as TotalDIA, ");
            consulta.append("sum(case when not VEJ.FechaFinal is null then 1 else 0 end) as TotalVEJ from Dia ");
            consulta.append("left join VendedorJornada VEJ on Dia.DiaClave = VEJ.DiaClave ");
            consulta.append("where Dia.FueraFrecuencia = 0 ");
            ISetDatos datos = BDVend.consultar(consulta.toString());

           if (datos.getCount()>0) {
               datos.moveToFirst();
               nTotalDia = datos.getInt("TotalDIA");
               nTotalVej = datos.getInt("TotalVEJ");
            }

            return (nTotalVej == (nTotalDia - 1));
        }

        public static boolean ValidarInventarioABordo() throws Exception{
            StringBuilder consulta = new StringBuilder();
            consulta.append("select count(*) as Cant from Inventario where Disponible > 0 or NoDisponible > 0 ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            datos.moveToFirst();
            if (datos.getInt("Cant")>0)
                return true;
            else
                return false;
        }

        public static boolean ValidarInventarioABordoNosDisp() throws Exception{
            StringBuilder consulta = new StringBuilder();
            consulta.append("select count(*) as Cant from Inventario where NoDisponible > 0 ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            datos.moveToFirst();
            if (datos.getInt("Cant")>0)
                return true;
            else
                return false;
        }

        public static boolean obtenerVendedorJornada(String VendedorId, StringBuilder DiaClave) throws Exception
        {
            boolean resultado = false;
            StringBuilder consulta = new StringBuilder();
            consulta.append("Select * ");
            consulta.append("From VendedorJornada ");
            consulta.append("Where FechaFinal Is Null And" +
                    " VendedorId= '" + VendedorId + "'");
            ISetDatos datos = BDVend.consultar(consulta.toString());

            while (datos.moveToNext())
            {
                if (DiaClave != null && datos.getString("DiaClave") != null){
                    DiaClave.append(datos.getString("DiaClave"));
                }
                resultado = true;
                break;
            }
            datos.close();
            return resultado;
        }

		public static ISetDatos obtenerDatosVendedorJornada(String VendedorId) throws Exception
		{

			StringBuilder consulta = new StringBuilder();
			consulta.append("Select * ");
			consulta.append("From VendedorJornada ");
			consulta.append("Where FechaFinal Is Null And" +
					" VendedorId= '" + VendedorId + "'");
			ISetDatos datos = BDVend.consultar(consulta.toString());

			return datos;
		}
		
		public static ISetDatos obtenerVendedorJornadaDatos(String VendedorId) throws Exception
		{

			StringBuilder consulta = new StringBuilder();
			consulta.append("Select * ");
			consulta.append("From VendedorJornada ");
			consulta.append("Where " +
					" VendedorId= '" + VendedorId + "'");
			ISetDatos datos = BDVend.consultar(consulta.toString());

			return datos;
		}
	}
	
	public static final class ConsultasReparto
	{
		public static ISetDatos obtenerPedidos(){
            String tiposPagoAnticipado = ValoresReferencia.getCadenaValores("PEDTIPO", "PagoAnticipado" );
			String Consulta = "Select t.Tipo ,Td.ProductoClave,TD.TipoUnidad,sum(TD.Cantidad) as Cantidad from TransProdDetalle td inner join transprod t on t.transprodid=td.transprodid where (Tipo=1 or Tipo=24) and (TipoFase=1 or TipoFase=7) " ;
            if (tiposPagoAnticipado.length() > 0) {
                  Consulta += " and (not TipoPedido in(" + tiposPagoAnticipado + "))  ";
            }
            Consulta += " group by t.Tipo ,Td.ProductoClave,TD.TipoUnidad ";
			try
			{
				return BDVend.consultar(Consulta);
			}
			catch (Exception e)
			{
				return null;
			}
		}
		
		/*public static void insertarPedidoModificado(String TransProdId) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("INSERT INTO PedidoModificado(TransProdId, MFechaHora, MUsuarioId, Enviado) VALUES (");
			consulta.append("'"+TransProdId+"',");
			consulta.append("'"+Generales.getFechaHoraActualStr("yyyy-MM-dd hh:mm:ss")+"',");
			consulta.append("'"+((Usuario)Sesion.get(Campo.UsuarioActual)).USUId+"',0)");
			BDVend.ejecutarComando(consulta.toString());
		}*/
	}
	
	public static final class ConsultasModuloMovDetalle{
		public static String obtenerTitulo() throws Exception{
			String res = "";
			ISetDatos titulo = BDVend.consultar("SELECT Nombre FROM ModuloMovDetalle WHERE ModuloMovDetalleClave = '" + Sesion.get(Campo.ModuloMovDetalleClave).toString() + "'");
			while(titulo.moveToNext()){
				res = titulo.getString("Nombre");
			}
			titulo.close();
			return res;
		}
		
		public static ModuloMovDetalle obtenerModuloMovDetallePorIndice(int indice) throws Exception{
			ISetDatos movDetalleSet = BDVend.consultar("SELECT ModuloMovDetalleClave, TipoTransProd, TipoPedido, TipoMovimiento FROM ModuloMovDetalle WHERE TipoIndice = " + indice);
			ModuloMovDetalle clave = null;
			if(movDetalleSet.moveToNext()){
				clave = new ModuloMovDetalle(movDetalleSet.getString(0), indice);
				clave.setTipoTransprod(movDetalleSet.getShort(1));
				clave.setTipoPedido(movDetalleSet.getShort(2));
				clave.setTipoMovimiento(movDetalleSet.getInt(3));
			}
			movDetalleSet.close();
			return clave;
		}
		
		public static ISetDatos obtenerModuloEsquema(String moduloMovDetalleClave) throws Exception{
			return BDVend.consultar("Select ESQ.EsquemaIDPadre as EsquemaIDPadre, MOE.EsquemaID as EsquemaID from ModuloEsquema  MOE inner join Esquema ESQ on ESQ.EsquemaID = MOE.EsquemaID where MOE.ModuloMovDetalleClave = '" + moduloMovDetalleClave  + "'");
		}
	}
	
	public static final class ConsultasFrecuenciaExcep
	{
		public static ArrayList<FrecuenciaExcep> obtenerTodasFrecuenciaExcep() throws Exception{
			ArrayList<FrecuenciaExcep> frecuenciasObtenidas = new ArrayList<FrecuenciaExcep>();
			ISetDatos frecuencias = BDVend.consultar("SELECT FrecuenciaExcepID FROM FrecuenciaExcep");
			while(frecuencias.moveToNext()){
				FrecuenciaExcep frecuenciaNueva = new FrecuenciaExcep();
				frecuenciaNueva.FrecuenciaExcepID = frecuencias.getString("FrecuenciaExcepID");
				BDVend.recuperar(frecuenciaNueva);
				frecuenciasObtenidas.add(frecuenciaNueva);
			}
			frecuencias.close();
			return frecuenciasObtenidas;
		}
	}
	
	public static final class ConsultasMaster{
		public static ISetDatos obtenerTablas(BaseDatos bd){
			String Consulta = "Select name from sqlite_master  where type = 'table' and not name = 'android_metadata' ";
			try
			{
				return bd.consultar(Consulta);
			}
			catch (Exception e)
			{
				return null;
			}
		}
		
		public static ISetDatos obtenerRegistrosTabla(BaseDatos bd, String nombreTabla){
			String Consulta = "Select * from " + nombreTabla;
			try
			{
				
				return bd.consultar(Consulta);
			}
			catch (Exception e)
			{
				return null;
			}
		}
	}
	
	public static final class ConsultasTrpTpd{
		public static float obtenerSumatoriaTotalPorTransProdId(String transProdId, String campo) throws Exception{
			float total = 0f;
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select sum(Total) as Total ");
			consulta.append("From TrpTpd ");
			consulta.append("Where " + campo + " = '" + transProdId + "'");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				total = datos.getFloat(0);
			}
			datos.close();
			return total;
		}
		
		public static List<TrpTpd> obtenerTransProdDevolucionDeConsignacion(String transProdId) throws Exception{
			ISetDatos trptpdSet = BDVend.consultar("SELECT * FROM TrpTpd where TrpTpd.TransProdID1 ='" + transProdId + "'");
			List<TrpTpd> listTrpTpd = new ArrayList<TrpTpd>();
			TrpTpd trptpd = null;
			if (trptpdSet.moveToNext()){
				trptpd = new TrpTpd();
				trptpd.TransProdID = trptpdSet.getString("TransProdID");
				trptpd.TransProdID1 = trptpdSet.getString("TransProdID1");
				trptpd.TransProdDetalleID = trptpdSet.getString("TransProdDetalleID");
				trptpd.Cantidad = trptpdSet.getFloat("Cantidad");
				trptpd.Enviado = trptpdSet.getBoolean("Enviado");
				trptpd.Impuesto = trptpdSet.getFloat("Impuesto");
				trptpd.MFechaHora = trptpdSet.getDate("MFechaHora");
				trptpd.MUsuarioID = trptpdSet.getString("MUsuarioID");
				trptpd.setPrecio(trptpdSet.getFloat("Precio"));
				trptpd.setSubTotal(trptpdSet.getFloat("Subtotal"));
				trptpd.Total = trptpdSet.getFloat("Total");
				
				listTrpTpd.add(trptpd);
			}
			trptpdSet.close();
			return listTrpTpd;
		}

		public static void eliminaTrpTpdAsociadasAConsignacion(String transProdID) throws Exception
		{
			BDVend.ejecutarComando("DELETE FROM TrpTpd where TransProdID1 = '" + transProdID + "'");
		}
	}
	
	public static final class ConsultasPuntoGPS{
		public static PuntoGPS obtenerPuntoGPS(String VisitaClave, String DiaClave) throws Exception{
			ISetDatos puntosGPS = BDVend.consultar("SELECT PuntoGPSId FROM PuntoGPS where VisitaClave ='" + VisitaClave + "' and DiaClave1='" + DiaClave + "' ");
			PuntoGPS puntoGPS = null;
			if (puntosGPS.moveToNext()){
				puntoGPS = new PuntoGPS();
				puntoGPS.PuntoGPSId = puntosGPS.getString("PuntoGPSId");
				BDVend.recuperar(puntoGPS);
			}
			puntosGPS.close();
			return puntoGPS;
		}
	}
	
	public static final class ConsultasFoliosFiscales{
		public static boolean existenFoliosFiscales() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT FolioId FROM FolioFiscal as FF inner join CentroExpedicion as CE on FF.CentroExpID = CE.CentroExpID");
			ISetDatos setDatos = BDVend.consultar(consulta.toString());
			boolean result = setDatos.moveToNext();
			setDatos.close();
			return result;
		}

		public static List<FolioFiscal> obtieneFoliosFiscalesPorCentroExp(String subEmpresaID) throws Exception
		{
			String fechaActual = Generales.getFechaHoraActualStr("yyyy-MM-dd HH:mm:ss");
			List<FolioFiscal> listResult = new ArrayList<FolioFiscal>();
			StringBuilder consulta = new StringBuilder();
			FolioFiscal folio;
			consulta.append("SELECT ").
			append("FolioID,").
			append("FOSID,").
			append("Inicio,").
			append("ModuloMovDetalleClave,").
			append("VendedorId,").
			append("TerminalClave,").
			append("FF.NumCertificado,").
			append("FF.CentroExpID,").
			append("Formato,").
			append("Serie,").
			append("Aprobacion,").
			append("AnioAprobacion,").
			append("Usados,").
			append("Fin,").
			append("FSHFechaInicio,").
			append("FechaFinal,").
//			append("FechaCreacion,").
			append("Enviado").
			append(" FROM FolioFiscal as FF inner join CentroExpedicion as CE on FF.CentroExpID = CE.CentroExpID WHERE CE.SubEmpresaId = '").append(subEmpresaID).append("' AND ");
			consulta.append("Fin >= Usados + Inicio AND FechaFinal >='").append(fechaActual).append("'");
			
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if(datos != null){
				while(datos.moveToNext()){
					folio = new FolioFiscal();
					folio.FolioId = datos.getString(0);
					folio.FOSId = datos.getString(1);
					folio.Inicio = datos.getInt(2);
					folio.ModuloMovDetalleClave = datos.getString(3);
					folio.VendedorId = datos.getString(4);
					folio.TerminalClave = datos.getString(5);
					folio.NumCertificado = datos.getString(6);
					folio.CentroExpID = datos.getString(7);
					folio.Formato = datos.getString(8);
					folio.Serie = datos.getString(9);
					folio.Aprobacion = datos.getInt(10);
					folio.AnioAprobacion = datos.getInt(11);
					folio.Usados = datos.getInt(12);
					folio.Fin = datos.getInt(13);
					folio.FSHFechaInicio = datos.getDate(14);
					folio.FechaFinal = datos.getDate(15);
//					folio.FechaCreacion = datos.getDate(14);
					folio.Enviado = datos.getBoolean(16);
					listResult.add(folio);
				}
				datos.close();
			}
			return listResult;
		}
	}
	
	public static final class ConsultasSEMHist{
		
		public static List<SEMHist> obtenerSubEmpresasPuedanEmitirFacturas() throws Exception{
			List<SEMHist> listResult = new ArrayList<SEMHist>();
			StringBuilder consulta = new StringBuilder();
			SEMHist semHist = null;
			consulta.append("SELECT SH.SubEmpresaId, SH.SEMHistFechaInicio, SH.ComprobanteDig, SH.FoliosTerminal, SH.ArchivoPEM, SH.VersionCFD, SE.NombreCorto, SE.Telefono ");
			consulta.append("FROM SEMHist as SH inner join SubEmpresa as SE on SH.SubEmpresaId = SE.SubEmpresaId WHERE ComprobanteDig=1");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if(datos != null){
				while(datos.moveToNext()){
					semHist = new SEMHist();
					semHist.SubEmpresaId = datos.getString(0);
					semHist.SEMHistFechaInicio = datos.getDate(1);
					semHist.ComprobanteDig = datos.getBoolean(2);
					semHist.FoliosTerminal = datos.getBoolean(3);
					semHist.ArchivoPEM = datos.getString(4);
					semHist.VersionCFD = datos.getShort(5);
					semHist.NombreCorto = datos.getString(6);
					semHist.Telefono = datos.getString(7);
					listResult.add(semHist);
				}
			}
			datos.close();
			return listResult;
		}

		public static SEMHist obtenerSubEmpresa(String subEmpresaId) throws Exception
		{
			String consulta = "SELECT NombreCorto FROM SubEmpresa WHERE SubEmpresaId = '" + subEmpresaId +"'";
			ISetDatos dato = BDVend.consultar(consulta);
			SEMHist shist = new SEMHist();
			if(dato.moveToNext())
			{
				shist.NombreCorto = dato.getString("NombreCorto");
			}
			dato.close();
			return shist;
		}
	}
	
	public static final class ConsultasInventarioTraspaso
	{
		public static ISetDatos obtenerDetalleTraspaso(String DiaClave) throws Exception
		{ 
			//obtener todos los registros del dia actual
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select INV.InventarioTraspasoId as _id, INV.ProductoClave, INV.Cantidad, INV.ProductoClave || ' - ' || PRO.Nombre as Descripcion, INV.TipoMotivo, INV.TipoUnidad, INV.Origen, INV.Destino, '' as De, '' as A, '' as Motivo, INV.Enviado ");
			consulta.append("from InventarioTraspaso INV inner join Producto PRO on PRO.ProductoClave = INV.ProductoClave ");
			consulta.append("where INV.DiaClave = '"+DiaClave+"' ORDER BY PRO.ProductoClave,INV.TipoUnidad");
			return BDVend.consultar(consulta.toString());
		}
	}
	
	public static final class ConsultasCentroExpedicion{

		public static CentroExpedicion obtenerCentroExpedicion(String subEmpresaId) throws Exception
		{
			CentroExpedicion centro = null;
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT * FROM CentroExpedicion WHERE SubEmpresaId = '").append(subEmpresaId).append("'");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if(datos.moveToNext())
			{
				centro = new CentroExpedicion();
				for(Field campo : CentroExpedicion.class.getFields())
				{
					if(campo.getType() == String.class)
						campo.set(centro, datos.getString(campo.getName()));
					else if(campo.getType() == Short.class)
						campo.set(centro, datos.getShort(campo.getName()));
				}
			}
			datos.close();
			return centro;
		}
		
	}
	
	public static final class ConsultasImproductividades{
		public static boolean existeImproductividadVisita(String DiaClave, String ClienteClave) throws Exception
		{
			boolean resultado = false;
			ISetDatos datos = BDVend.consultar("select ClienteClave from Agenda where DiaClave = '" + DiaClave + "' and ClienteClave = '" + ClienteClave + "' and not TipoMotivo is null ");
			if (datos.moveToNext())
			{
				resultado = true;
			}
			datos.close();
			return resultado;
		}
		
		public static void eliminarImproductividadVenta(String clienteClave, String diaClave, String vendedorID, String RUTClave) throws Exception
		{
			BDVend.ejecutarComando("Delete from ImproductividadVenta where VisitaClave + DiaClave in( Select VIS.VisitaClave + VIS.DiaClave from Visita VIS where VIS.ClienteClave ='" + clienteClave + "' and VIS.VendedorID = '" + vendedorID + "' and VIS.RUTClave = '" + RUTClave + "' and VIS.DiaClave = '"  + diaClave + "' )" );
		}

        public static boolean existeImproductividadEnVisita(String visitaClave, String diaClave)throws Exception
        {
            boolean resultado = false;
            ISetDatos datos = BDVend.consultar("select * from ImproductividadVenta where VisitaClave = '" + visitaClave + "' and DiaClave = '" + diaClave + "' ");
            if (datos.moveToNext())
            {
                resultado = true;
            }
            datos.close();
            return resultado;
        }

        public static void borrarImproductividadEnVisita(String visitaClave, String diaClave){
            try {
                BDVend.ejecutarComando("delete from ImproductividadVenta where VisitaClave = '" + visitaClave + "' and DiaClave = '" + diaClave + "' ");
            }catch(Exception ex){
                ex.printStackTrace();
            }
        }

	}
	
	public static final class ConsultasClienteVentaMensual {
		public static boolean existeInformacion(String clienteClave) {
			ISetDatos datos = null;
			try{
				datos = BDVend.consultar("SELECT * FROM ClienteVentaMensual as VM WHERE VM.ClienteClave = '" + clienteClave + "' ");
				return datos.getCount() > 0;
			}catch(Exception ex){
				return false;
			}finally{
				if(datos != null)
					datos.close();
			}
		}
		public static List<ClienteVentaMensual> obtieneVentaMensual(String clienteClave) throws Exception {
			StringBuilder consulta = new StringBuilder();
			List<ClienteVentaMensual> result = new ArrayList<ClienteVentaMensual>();
			consulta.append("SELECT Fecha, MontoMensual FROM ClienteVentaMensual as VM ");
			consulta.append("WHERE VM.ClienteClave = '" + clienteClave + "'");
			ISetDatos datos  = BDVend.consultar(consulta.toString());
			ClienteVentaMensual cvm;
			while(datos.moveToNext()){
				cvm = new ClienteVentaMensual();
				cvm.Fecha = datos.getString("Fecha");
				cvm.MontoMensual = datos.getFloat("MontoMensual");
				result.add(cvm);
			}
			
			return result;
		}
	}
//	public static final class ConsultasClienteDomicilio{
//		
//		public static List<ClienteDomicilio> obtieneDomicilioFiscalCliente(String clienteClave) throws Exception{
//			List<ClienteDomicilio> listResult = new ArrayList<ClienteDomicilio>();
//			ClienteDomicilio clienteDomicilio;
//			StringBuilder consulta = new StringBuilder();
//			consulta.append("SELECT ")
//			.append("FROM ClienteDomicilio WHERE Tipo=1 AND ")
//			.append("ClienteClave ='").append(clienteClave).append("'");
//			
//			ISetDatos datos = BDVend.consultar(consulta.toString());
//			if(datos != null && datos.getCount() > 0)
//			{
//				while(datos.moveToNext())
//				{
//					clienteDomicilio = new ClienteDomicilio();
//					clienteDomicilio.ClienteDomicilioId = datos.getString(0);
//					listResult.add(clienteDomicilio);
//				}
//			}
//			datos.close();
//			return listResult;
//		}
//	}

	
	public static final class ConsultasValidacionPreliquidacion{
		
		public static int getModuloMovDetalleTipoIndice(String clave) throws Exception
		{
			int valor = 0;
			ISetDatos ModuloDetalle = BDVend.consultar("SELECT * from ModuloMovDetalle where ModuloMovDetalleClave = '"+clave+"'");
			
			if(ModuloDetalle.moveToNext())
			{
				valor = ModuloDetalle.getInt("TipoIndice");
			}
			ModuloDetalle.close();
			return valor;
		}

        public static int getTransProdCFVTipo(String id) throws Exception
        {
            int valor = 0;
            //ISetDatos CFVTipo = BDVend.consultar("SELECT * from TransProd where VisitaClave = '"+visitaClave+"' and DiaClave = '"+diaClave+"'");
            ISetDatos CFVTipo = BDVend.consultar("SELECT CFVTipo from TransProd where TransProdID = '"+ id +"'");

            if(CFVTipo.moveToNext())
            {
                valor = CFVTipo.getInt("CFVTipo");
            }
            CFVTipo.close();
            return valor;
        }



        public static int getTransProdClientePago(String id) throws Exception
        {
            int valor = 0;
            //ISetDatos clientePagoID = BDVend.consultar("SELECT * from TransProd where VisitaClave = '"+visitaClave+"' and DiaClave = '"+diaClave+"'");
            ISetDatos clientePagoID = BDVend.consultar("SELECT ClientePagoID from TransProd where TransProdID = '"+ id +"'");

            if(clientePagoID.moveToNext())
            {
                valor = clientePagoID.getInt("ClientePagoId");
            }
            clientePagoID.close();
            return valor;
        }


        public static boolean validarTotal (String id) throws Exception
        {
            boolean confirmado = false;

            ISetDatos Transprod = BDVend.consultar("SELECT * from TransProd where TransProdID = '"+ id +"'");

            if(Transprod.moveToNext())
            {

                ISetDatos Preliquidacion = BDVend.consultar("Select * from Preliquidacion");

                if(Preliquidacion.moveToNext())
                {
                    float total = Transprod.getFloat("Total");
                    float montoTotal = Preliquidacion.getFloat("MontoTotal");
                    float resultado = 0;
                    Log.i(null, montoTotal+" > "+total);
                    if(montoTotal >= total)
                    {
                        resultado = montoTotal - total;

                        PreLiquidacion preLiquidacion = new PreLiquidacion();
                        preLiquidacion.PLIId = Preliquidacion.getString("PLIId");

                        BDVend.recuperar(preLiquidacion);

                        preLiquidacion.MontoTotal = resultado;

                        BDVend.guardarInsertar(preLiquidacion);

                        if(resultado == 0)
                        {
                            if(Transprod.getString("PLIId").toString() != Preliquidacion.getString("PLIId"))
                            {
                                ISetDatos plbple = BDVend.consultar("Select * from PLBPLE");

                                if(!plbple.moveToNext())
                                {
                                    BDVend.eliminar(preLiquidacion);
                                }
                                plbple.close();
                            }
                        }

                        confirmado = true;

                    }
                }

                Preliquidacion.close();
            }

            Transprod.close();
            return confirmado;
        }


        public static float totalTransportModificar(String transProdID) throws Exception
		{
			ISetDatos transprod = BDVend.consultar("Select Total from TransProd where TransProdID = '"+transProdID+"'");
			transprod.moveToFirst();
			float trans = transprod.getFloat("Total");
			transprod.close();
			return trans;
			
		}
		
		public static void eliminarPreliquidacion(String pliid, String diaClave, String visitaClave) throws Exception
		{
			ISetDatos transProd = BDVend.consultar("Select PLIId from TransProd where VisitaClave = '"+visitaClave+"' and DiaClave = '"+diaClave+"' and PLIId = '"+pliid+"'");
			if(transProd.getCount() == 0)
			{
				ISetDatos plbple = BDVend.consultar("Select * from PLBPLE");
				
				if(plbple.getCount() == 0)
				{
					ISetDatos preliquidacion = BDVend.consultar("Select * from Preliquidacion where PLIId = '"+pliid+"'");
					preliquidacion.moveToFirst();
					PreLiquidacion pre = new PreLiquidacion();
					pre.PLIId = preliquidacion.getString("PLIId");
					BDVend.recuperar(pre);
					BDVend.eliminar(pre);
					
					preliquidacion.close();
					
				}
				
				plbple.close();
			}
			
			transProd.close();
			
		}
	
	}
	
	public static final class ConsultasVentasInconsistentes{
		//Verifica si existe alguna venta con totales nulos y detalles y regresa los TransProdID y los folios
		public static ArrayList<TransProd> regresaVentasInconsistentes() throws Exception{
			
			ArrayList<TransProd> TRPResultado = new ArrayList<TransProd>();
			ISetDatos datos = BDVend.consultar("Select distinct TRP.TransProdID as TransProdID from Transprod TRP inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID where TRP.Tipo = 1 and TRP.TipoPedido = 1 and TRP.TipoFase = 1 and TRP.SubTotal is null ");
			if(datos != null){
				if (datos.getCount() <= 0){
					datos.close();
					return TRPResultado;
				}
			}else{
				return TRPResultado;
			}
			
			String motivosNoDisp = "";
			String noVenta = ValoresReferencia.getStringVAVClave("TRPMOT", "No Venta");
			if (( noVenta != null) && noVenta.length()>0){
				motivosNoDisp =   noVenta;
			}
			String caduco = ValoresReferencia.getStringVAVClave("TRPMOT", "Caducidad");
			if ( caduco!= null && caduco.length()>0){
				motivosNoDisp +=  (motivosNoDisp.length()>0 ? "," : "") + caduco;
			}
			
			StringBuilder consultaDescuadres = new StringBuilder();
			consultaDescuadres.append("Select ProductoClave, SUM(Cargas) as Cargas, SUM(ventas) as Ventas, sum(Cambios) as Cambios, SUM(descargas) as Descargas ");
			consultaDescuadres.append("from( Select TPD.ProductoClave, 0 as Cargas,sum(TPD.Cantidad) as ventas ,0 as Cambios, 0 as Descargas ");
			consultaDescuadres.append("from TransProd TRP ");
			consultaDescuadres.append("inner join TransProdDetalle TPD on TRP.TransProdID  = TPD.TransProdID ");
			consultaDescuadres.append("inner join Visita VIS on VIS.VisitaClave = (CASE WHEN TRP.VisitaClave1 IS null THEN TRP.VisitaClave ELSE TRP.VisitaClave1 END) ");
			consultaDescuadres.append("and VIS.DiaClave  = (CASE WHEN TRP.DiaClave1 IS null THEN TRP.DiaClave ELSE TRP.DiaClave1 END) ");
			consultaDescuadres.append("where TRP.Tipo = 1 and  TRP.TipoFase in(2)  and TRP.TipoPedido = 1 and not TRP.Subtotal is null ");
			consultaDescuadres.append("group by TPD.ProductoClave ");
			if (motivosNoDisp.length() > 0){ //Si hay motivos de no disponible
				consultaDescuadres.append("union ");
				consultaDescuadres.append("Select TPD.ProductoClave, 0 as Cargas, 0 as Ventas, SUM(TPD.Cantidad) as Cambios, 0 as Descargas ");
				consultaDescuadres.append("from TransProd TRP ");
				consultaDescuadres.append("inner join TransProdDetalle TPD on TRP.TransProdID  = TPD.TransProdID ");
				consultaDescuadres.append("where TRP.Tipo = 9 and TRP.TipoMovimiento = 1 and TPD.TipoMotivo in(" + motivosNoDisp + ") ");
				consultaDescuadres.append("group by TPD.ProductoClave ");
			}
			consultaDescuadres.append("union ");
			consultaDescuadres.append("Select TPD.ProductoClave , SUM(TPD.Cantidad) as Cargas, 0 as Ventas, 0 as Cambios, 0 as Descargas ");
			consultaDescuadres.append("from TransProd TRP ");
			consultaDescuadres.append("inner join TransProdDetalle TPD on TRP.TransProdID  = TPD.TransProdID ");
			consultaDescuadres.append("inner join Vendedor VEN on VEN.USUId = TRP.MUsuarioID ");
			consultaDescuadres.append("where TRP.Tipo = 2  ");
			consultaDescuadres.append("group by TPD.ProductoClave ");
			consultaDescuadres.append("union ");
			consultaDescuadres.append("Select  INV.ProductoClave , 0 as Cargas, 0 as Ventas, 0 as Cambios, sum(INV.Disponible-INV.NoDisponible-INV.Contenido) as Descargas ");
			consultaDescuadres.append("from Inventario INV ");
			consultaDescuadres.append("group by  INV.ProductoClave ");
			consultaDescuadres.append(") as movtos ");
			consultaDescuadres.append("group by ProductoClave ");
			consultaDescuadres.append("having SUM(Cargas) <> SUM(Ventas) + SUM(Descargas) + Sum(Cambios) "); 	
			
			HashMap <String, Float> inventario = new HashMap<String,Float>();
			
			ISetDatos descuadresInventario = BDVend.consultar(consultaDescuadres.toString());
			if(descuadresInventario != null){
				while(descuadresInventario.moveToNext()){
					inventario.put(descuadresInventario.getString("ProductoClave"), (descuadresInventario.getFloat("Cargas") - (descuadresInventario.getFloat("Ventas") + descuadresInventario.getFloat("Cambios") + descuadresInventario.getFloat("Descargas"))));
				}
			}
			descuadresInventario.close();
			
			//Si no hay descuadres de inventario, no se podra cancelar el pedido
			if (inventario.size() <=0){
				datos.close();
				return TRPResultado;
			}
				
			if(datos != null){
				while(datos.moveToNext()){
					TransProd trp = new TransProd();
					trp.TransProdID = datos.getString("TransProdID");
					BDVend.recuperar(trp);
					BDVend.recuperar(trp, TransProdDetalle.class);
					
					boolean verificarInv = true;
					
					Iterator<TransProdDetalle> it = trp.TransProdDetalle.iterator();
					while (it.hasNext())
					{
						TransProdDetalle oTpd = it.next();
						if ((inventario.containsKey(oTpd.ProductoClave)) && (inventario.get(oTpd.ProductoClave) >= oTpd.Cantidad )){
							inventario.put(oTpd.ProductoClave, inventario.get(oTpd.ProductoClave) - oTpd.Cantidad);
						}else{							
							verificarInv = false;
							break;
						}
					}					
					if (verificarInv){
						TRPResultado.add(trp);
					}					
				}
			}
			datos.close();
			inventario.clear();
			inventario = null;
			return TRPResultado;
		}
				
	}
	
	public static final class ConsultasPermisos{
		
		public static String validarPermisos(String ACTId)throws Exception
		{
			String permiso = "1";
			ISetDatos consulta = BDVend.consultar("Select Permiso from IntPer where ACTId = '"+ACTId+"'");
			if(consulta.getCount() > 0)
			{
				consulta.moveToNext();
				permiso = consulta.getString("Permiso");
				consulta.close();
			}
			
			return permiso;
			
		}
	}

    public static final class ConsultasTRPGrupo{

        public static void eliminarTransaccionGrupo(String TransprodID) throws Exception {
            //BDVend.ejecutarComando("DELETE FROM TRPGrupo WHERE TransprodID = '" + TransprodID + "'");
            ISetDatos grupo = BDVend.consultar("SELECT * FROM TRPGrupo WHERE GrupoID IN (SELECT GrupoID FROM TRPGrupo WHERE TransprodID = '" + TransprodID + "')");
            while(grupo.moveToNext()){
                TRPGrupo grp = (TRPGrupo) BDVend.instanciar(TRPGrupo.class, grupo);
                BDVend.eliminar(grp);
            }
        }

    }

    public static final class ConsultasProductoPrestamoCli{

        public static ISetDatos obtenerSaldoEnvase(String ClienteClave) throws  Exception {
            return BDVend.consultar("SELECT ProductoClave _id,ProductoClave,Cargo,Abono,Venta,Saldo FROM ProductoPrestamoCli WHERE ClienteClave = '" + ClienteClave + "'");
        }

		public static ISetDatos obtenerSaldoClienteGeneral(String ClienteClave) throws Exception{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT  (Cliente.clave || ' ' || Cliente.razonsocial) AS RazonSocial, sum(ProductoPrestamoCli.saldo) AS Saldo ");
			sConsulta.append("from ProductoPrestamoCli ");
			sConsulta.append("inner join cliente on cliente.clienteclave=ProductoPrestamoCli.clienteclave ");
			sConsulta.append("inner join producto on producto.productoclave = ProductoPrestamoCli.productoclave ");
			sConsulta.append("where cliente.clienteclave in (" + ClienteClave + ") ");
			//sConsulta.append("where cliente.clienteclave = '" + ClienteClave + "' ");
			sConsulta.append("group by cliente.clave,cliente.razonsocial ");
			sConsulta.append("having sum(ProductoPrestamoCli.saldo) <> 0 ");
			sConsulta.append("order by cliente.clave ");
			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerSaldoClienteDetallado(String ClienteClave) throws Exception {
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("select  (cliente.clave || ' ' || cliente.razonsocial) as RazonSocial, producto.nombre,sum(ProductoPrestamoCli.saldo) as Saldo ");
			sConsulta.append("from ProductoPrestamoCli ");
			sConsulta.append("inner join cliente on cliente.clienteclave=ProductoPrestamoCli.clienteclave ");
			sConsulta.append("inner join producto on producto.productoclave = ProductoPrestamoCli.productoclave ");
			sConsulta.append("where cliente.clienteclave in (" + ClienteClave + ") ");
			sConsulta.append("group by cliente.clave,cliente.razonsocial, producto.nombre ");
			sConsulta.append("having sum(ProductoPrestamoCli.saldo) <> 0 ");
			sConsulta.append("order by cliente.clave,producto.nombre ");
			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerSaldoClienteDetalladoResumen(String ClienteClave) throws Exception{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("select   producto.nombre,sum(ProductoPrestamoCli.saldo) as Saldo ");
			sConsulta.append("from ProductoPrestamoCli ");
			sConsulta.append("inner join cliente on cliente.clienteclave=ProductoPrestamoCli.clienteclave ");
			sConsulta.append("inner join producto on producto.productoclave = ProductoPrestamoCli.productoclave ");
			sConsulta.append("where cliente.clienteclave in (" + ClienteClave + ") ");
			sConsulta.append("group by  producto.nombre ");
			sConsulta.append("having sum(ProductoPrestamoCli.saldo) <> 0 ");
			sConsulta.append("order by producto.nombre ");
			return BDVend.consultar(sConsulta.toString());
		}

    }

    public static final class ConsultasPedidosConfirmadosSAP{

        public static String obtenerIdsConfirmadosSAP() throws  Exception {
            StringBuilder sConsulta = new StringBuilder();
            String sConfirmadosSAP ="";

            sConsulta.append("Select TransProdID from TransProd where Tipo = 1 and TipoFase = 12 ");

            ISetDatos datos = BDVend.consultar(sConsulta.toString());

            while (datos.moveToNext())
            {
                sConfirmadosSAP += "'" + datos.getString("TransProdID") + "',";
            }
            if(sConfirmadosSAP.length()>0){
                sConfirmadosSAP = sConfirmadosSAP.substring(0, sConfirmadosSAP.length() - 1);
            }
            datos.close();

            return sConfirmadosSAP;
        }

        public static String obtenerFolioSAP(String transProdId) throws  Exception {
            StringBuilder sConsulta = new StringBuilder();
            String sFolioSAP ="";

            sConsulta.append("Select PedidoAdicional from TRPVtaAcreditada where TransProdID ='"  + transProdId + "' ");

            ISetDatos datos = BDVend.consultar(sConsulta.toString());

            if(datos.getCount() > 0)
            {
                datos.moveToNext();
                sFolioSAP =  datos.getString("PedidoAdicional");
            }
            datos.close();

            return sFolioSAP;
        }

        public static ISetDatos obtenerReporteConfirmadosSAP(String filtroFecha, String clienteClave)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("SELECT CLI.ClienteClave, CLI.Clave, CLI.RazonSocial,  TVA.FolioCliente as ClienteSAP,  TRP.FechaCaptura as FechaPedido, TVA.PedidoAdicional as PedidoSAP, TRP.Total as ValorNeto, CMGST.Descripcion as Estatus, ");
            sConsulta.append("ESQ.Clave, TPD.ProductoClave, PRO.Nombre, TPD.TipoUnidad, TPD.CantidadOriginal,TPD. Cantidad, TPD.Total, IFNULL(TVA.Observaciones2,'') as NoPedidoCte, TRP.Folio ");
            sConsulta.append("FROM TransProd TRP ");
            sConsulta.append("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ");
            sConsulta.append("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
            sConsulta.append("inner join TRPVtaAcreditada TVA on TRP.TransProdID = TVA.TransProdID ");
            sConsulta.append("inner join Cliente CLI on CLI.ClienteClave = VIS.ClienteClave ");
            sConsulta.append("inner join tmp_CMGST CMGST on CMGST.Valor = TVA.Observaciones ");
            sConsulta.append("inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ");
            sConsulta.append("inner join ProductoEsquema PRE on PRO.ProductoClave = PRE.ProductoClave ");
            sConsulta.append("inner join Esquema ESQ on PRE.EsquemaID = ESQ.EsquemaID ");
            sConsulta.append("inner join Esquema ESQ2 on ESQ2.Clave= substr(ESQ.Clave, 1,  length(ESQ2.Clave)) and ESQ2.Nivel = 1 ");
            sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 12 ");
            if (!clienteClave.equals("")){
                sConsulta.append(" and VIS.ClienteClave = '" +  clienteClave + "' ");
            }
            if (!filtroFecha.equals("")){
                sConsulta.append(" and " + filtroFecha);
            }
            sConsulta.append("order by CLI.ClienteClave, TVA.PedidoAdicional, TRP.FechaCaptura, ESQ2.Clave, TPD.ProductoClave ");

            ISetDatos datos = BDVend.consultar(sConsulta.toString());

            return datos;
        }
    }

    public static final class ConsultasConversionProducto{
        public static ISetDatos obtenerConsolidacionPedido(String transProdId) throws  Exception {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("SELECT ESQ.Clasificacion, PRO.ProductoClave, PRO.Nombre, ");
            sConsulta.append("(CASE WHEN TPD.TipoUnidad = 3 THEN TPD.Cantidad ELSE  TPD.Cantidad / ifnull(PRDCaja.Factor, 1) END) as CtdPedidos, ");
            sConsulta.append("(CASE WHEN PRDPallet.Factor is null THEN -1 ELSE round(TPD.Cantidad / PRDPallet.Factor ,2) END) as Tarimas, ");
            sConsulta.append("(CASE WHEN PRDPallet.Factor is null THEN -1 ELSE cast(TPD.Cantidad / PRDPallet.Factor as int) END) as Pallets, ");
            sConsulta.append("(CASE WHEN PRDPallet.Factor is null  or PRDCama.Factor is null THEN -1 ELSE  cast( ((TPD.Cantidad % PRDPallet.Factor) / PRDCama.Factor) as int) END) as Camas,");
            sConsulta.append("(CASE WHEN PRDPallet.Factor is null  or PRDCama.Factor is null THEN -1 ELSE  (CASE WHEN  TPD.TipoUnidad = 3 THEN  cast(((TPD.Cantidad % PRDPallet.Factor) % PRDCama.Factor) as int)  ELSE ");
            sConsulta.append("(((TPD.Cantidad % PRDPallet.Factor) % PRDCama.Factor)/ifnull(PRDCaja.Factor,1)) END)  END) as CajasSueltas, (TPD.Cantidad * PRU.KgLts) as Peso, (TPD.Cantidad * PRU.Volumen)  as Volumen ");
            sConsulta.append("FROM TransProd TRP ");
            sConsulta.append("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
            sConsulta.append("inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ");
            sConsulta.append("inner join ProductoEsquema PRE on PRE.ProductoClave = PRO.ProductoClave ");
            sConsulta.append("inner join Esquema ESQ on ESQ.EsquemaID = PRE.EsquemaID ");
            sConsulta.append("inner join ProductoUnidad PRU on PRU.ProductoClave = TPD.ProductoClave and PRU.PRUTipoUnidad  = TPD.TipoUnidad ");
            sConsulta.append("left join ProductoUnidad PRUCaja on PRUCaja.ProductoClave = PRO.ProductoClave and PRUCaja.TipoEstado = 2 and PRUCaja.PRUTipoUnidad = 3 ");
            sConsulta.append("left join ProductoDetalle PRDCaja on PRDCaja.ProductoClave = PRUCaja.ProductoClave and PRDCaja.PRUTipoUnidad = PRUCaja.PRUTipoUnidad ");
            sConsulta.append("left join ProductoUnidad PRUPallet on PRUPallet.ProductoClave = PRO.ProductoClave and PRUPallet.TipoEstado = 2 and PRUPallet.PRUTipoUnidad = 6 ");
            sConsulta.append("left join ProductoDetalle PRDPallet on PRDPallet.ProductoClave = PRUPallet.ProductoClave and PRDPallet.PRUTipoUnidad = PRUPallet.PRUTipoUnidad ");
            sConsulta.append("left join ProductoUnidad PRUCama on PRUCama.ProductoClave = PRO.ProductoClave and PRUCama.TipoEstado = 2 and PRUCama.PRUTipoUnidad = 4 ");
            sConsulta.append("left join ProductoDetalle PRDCama on PRDCama.ProductoClave = PRUCama.ProductoClave and PRDCama.PRUTipoUnidad = PRUCama.PRUTipoUnidad ");
            sConsulta.append("where TRP.TransProdID = '" + transProdId + "' order by ESQ.Clasificacion");

            ISetDatos datos = BDVend.consultar(sConsulta.toString());

            return datos;

        }

        public static ISetDatos obtenerConsolidacionPedidosJornada() throws  Exception {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("Select Clasificacion, sum(Tarimas) as Tarimas, sum(Pallets) as Pallets, sum(Camas) as Camas, sum(CajasSueltas) as CajasSueltas, round(sum(Peso),0) as Peso, sum(Volumen) as Volumen from(");
            sConsulta.append("SELECT ESQ.Clasificacion, PRO.ProductoClave,  (CASE WHEN TPD.TipoUnidad = 3 THEN sum(TPD.Cantidad) ELSE  sum(TPD.Cantidad) / ifnull(PRDCaja.Factor, 1) END) as CtdPedidos, ");
            sConsulta.append("(CASE WHEN PRDPallet.Factor is null THEN -1 ELSE round(sum(TPD.Cantidad) / PRDPallet.Factor ,2) END) as Tarimas, ");
            sConsulta.append("(CASE WHEN PRDPallet.Factor is null THEN -1 ELSE cast(sum(TPD.Cantidad) / PRDPallet.Factor as int) END) as Pallets, ");
            sConsulta.append("(CASE WHEN PRDPallet.Factor is null  or PRDCama.Factor is null THEN -1 ELSE  cast( ((sum(TPD.Cantidad) % PRDPallet.Factor) / PRDCama.Factor) as int) END) as Camas, ");
            sConsulta.append("(CASE WHEN PRDPallet.Factor is null  or PRDCama.Factor is null THEN -1 ELSE  (CASE WHEN  TPD.TipoUnidad = 3 THEN  cast(((sum(TPD.Cantidad) % PRDPallet.Factor) % PRDCama.Factor) as int)  ELSE (((sum(TPD.Cantidad)% PRDPallet.Factor) % PRDCama.Factor)/ifnull(PRDCaja.Factor,1)) END)  END) as CajasSueltas, ");
            sConsulta.append("(sum(TPD.Cantidad) * PRU.KgLts)as Peso, (sum(TPD.Cantidad) * PRU.Volumen) as Volumen ");
            sConsulta.append("FROM TransProd TRP ");
            sConsulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
            sConsulta.append("inner join Dia on VIS.DiaClave = Dia.DiaClave and Dia.FueraFrecuencia = 0 ");
            sConsulta.append("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
            sConsulta.append("inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ");
            sConsulta.append("inner join ProductoEsquema PRE on PRE.ProductoClave = PRO.ProductoClave ");
            sConsulta.append("inner join Esquema ESQ on ESQ.EsquemaID = PRE.EsquemaID ");
            sConsulta.append("inner join ProductoUnidad PRU on PRU.ProductoClave = TPD.ProductoClave and PRU.PRUTipoUnidad  = TPD.TipoUnidad ");
            sConsulta.append("left join ProductoUnidad PRUCaja on PRUCaja.ProductoClave = PRO.ProductoClave and PRUCaja.TipoEstado = 2 and PRUCaja.PRUTipoUnidad = 3 ");
            sConsulta.append("left join ProductoDetalle PRDCaja on PRDCaja.ProductoClave = PRUCaja.ProductoClave and PRDCaja.PRUTipoUnidad = PRUCaja.PRUTipoUnidad ");
            sConsulta.append("left join ProductoUnidad PRUPallet on PRUPallet.ProductoClave = PRO.ProductoClave and PRUPallet.TipoEstado = 2 and PRUPallet.PRUTipoUnidad = 6 ");
            sConsulta.append("left join ProductoDetalle PRDPallet on PRDPallet.ProductoClave = PRUPallet.ProductoClave and PRDPallet.PRUTipoUnidad = PRUPallet.PRUTipoUnidad ");
            sConsulta.append("left join ProductoUnidad PRUCama on PRUCama.ProductoClave = PRO.ProductoClave and PRUCama.TipoEstado = 2 and PRUCama.PRUTipoUnidad = 4 ");
            sConsulta.append("left join ProductoDetalle PRDCama on PRDCama.ProductoClave = PRUCama.ProductoClave and PRDCama.PRUTipoUnidad = PRUCama.PRUTipoUnidad ");
            sConsulta.append("where TRP.Tipo = 1 and TRP.TipoFase <>0 group by ESQ.Clasificacion, PRO.ProductoClave) as tmp group by Clasificacion order by Clasificacion ");

            ISetDatos datos = BDVend.consultar(sConsulta.toString());

            return datos;
        }
    }

    /*Inicio codigo luis de la torre*/
    public static final class ConsultasDevolucionCliente
    {

        public static ISetDatos obtenerClienteDomicilioDevolucion(String clienteClave) throws Exception
        {
            StringBuilder consulta = new StringBuilder();

            //consulta.append("select VAD.VAVClave as _id, VAD.VAVClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", VAD.Descripcion AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + " from ValorReferencia VR ");
            consulta.append("select Calle || ' ' || Numero || ' ' || Poblacion || ' ' || ClienteDomicilioID as Domicilio")
                    .append(" from ClienteDomicilio ")
                    .append("where Tipo = 3 and ClienteClave = '"+ clienteClave +"' ");

            //Log.e("ERROR CONSULTA",consulta.toString());
            ISetDatos stDomicilio = BDVend.consultar(consulta.toString());
            if (stDomicilio != null && stDomicilio.getCount() > 0)
            {
                return stDomicilio;
            }
            else
            {
                String consultaTipo2 = consulta.toString().replace("3", "2");
                stDomicilio = BDVend.consultar(consultaTipo2);
                if(stDomicilio != null && stDomicilio.getCount() > 0)
                {
                    return stDomicilio;
                }
            }
            return stDomicilio;

        }

        public static String obtenerTelefonoTRPVtaAcreditada(String transprodId) throws Exception
        {
            ISetDatos stTelefono;
            String sTelefono = "";
            StringBuilder consulta = new StringBuilder();
            consulta.append("Select Observaciones2 ")
                    .append("from TRPVtaAcreditada where TransProdId = '"+transprodId+"'");
            stTelefono = BDVend.consultar(consulta.toString());

            while(stTelefono.moveToNext())
            {
                sTelefono = stTelefono.getString(0);
            }

            return sTelefono;

        }

        public static void eliminarLoteCaducidad(String transProdId, String transProdDetalleId)throws Exception
        {
            StringBuilder queryEliminar = new StringBuilder();

            queryEliminar.append("DELETE FROM ManejoLotesCaducidad where TransProdId = '"+transProdId+"' and TransProdDetalleId = '"+transProdDetalleId+"'");

            BDVend.ejecutarComando(queryEliminar.toString());
        }

        public static void eliminarTelefono(String transProdId)throws Exception
        {
            StringBuilder queryEliminar = new StringBuilder();

            queryEliminar.append("DELETE FROM TRPVtaAcreditada where TransProdId = '"+transProdId+"'");

            BDVend.ejecutarComando(queryEliminar.toString());
        }


    }
	/*Fin codigo luis de la torre*/

    public static final class ConsultasInventarioMercadeo
    {
        public static ISetDatos obtenerDetalle(String inventarioID) throws Exception
        {

            StringBuilder consulta = new StringBuilder();
            consulta.append("Select IMD.ProductoClave as _id, IMD.*,  PRO.Nombre as Descripcion, PRO.DecimalProducto as DecimalProducto ");
            consulta.append("from InventarioMercadeoDetalle IMD ");
            consulta.append("inner join Producto PRO on IMD.ProductoClave = PRO.ProductoClave ");
            consulta.append("where IMD.InventarioID ='" + inventarioID + "' ");
            return BDVend.consultar(consulta.toString());
        }
    }

    public static final class ConsultaResumenMovimientos{

        public static ISetDatos obtenerResumenMovimientos(String diaClave, boolean TipoDetallado)throws Exception
        {
            StringBuilder consulta = new StringBuilder();

            if (TipoDetallado){
                consulta.append("select z.Tipo as Tipo, z.FolioMovimiento as FolioMovimiento, z.Producto as Producto, z.TipoUnidad as TipoUnidad, z.Cantidad as Cantidad, z.TotalPiezas as TotalPiezas, z.FacturaId as FacturaId, z.TipoMovimiento as TipoMovimiento ");
                consulta.append("from ( ");
                consulta.append("/*Cargas, Cambios, Dev. Alamacen, Ajustes, Descargas, Mov. sin Inv. en Visita*/ ");
                consulta.append("Select t.Tipo as Tipo, ");
                consulta.append("(t.Folio || (ifnull(' - ' || c.NombreCorto || ' - ','')) || (ifnull(c.RazonSocial,''))) as FolioMovimiento, ");
                consulta.append("td.ProductoClave || ' ' || P.Nombre as Producto, ");
                consulta.append("td.TipoUnidad as TipoUnidad, ");
                consulta.append("td.Cantidad as Cantidad, ");
                consulta.append("(td.Cantidad * pd.Factor) as TotalPiezas, ");
                consulta.append("null as FacturaId,  ");
                consulta.append("t.TipoMovimiento as TipoMovimiento  ");
                consulta.append("from TransProd t  ");
                consulta.append("left join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave ");
                consulta.append("left join Cliente c on v.ClienteClave=c.ClienteClave  ");
                consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID  ");
                consulta.append("inner join Producto p on p.ProductoClave=td.ProductoClave ");
                consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.Tipounidad=pd.PruTipoUnidad and td.ProductoClave=pd.ProductoDetClave  ");
                consulta.append("where t.Tipo in (2,3,4,6,7,21) and t.TipoFase<>0 and t.DiaClave='"+ diaClave +"'  ");
                consulta.append("union all ");
                consulta.append("/*Facturas*/ ");
                consulta.append("Select tf.Tipo as Tipo, ");
                consulta.append("(tf.Folio || (ifnull(' - ' || c.NombreCorto || ' - ','')) || (ifnull(c.RazonSocial,''))) as FolioMovimiento,  ");
                consulta.append("td.ProductoClave || ' ' || P.Nombre as Producto, ");
                consulta.append("td.TipoUnidad as TipoUnidad,  ");
                consulta.append("td.Cantidad as Cantidad, ");
                consulta.append("(td.Cantidad * pd.Factor) as TotalPiezas, ");
                consulta.append("null as FacturaID, ");
                consulta.append("tf.TipoMovimiento as TipoMovimiento  ");
                consulta.append("from TransProd tf ");
                consulta.append("inner join TransProd tv on tf.TransProdID=tv.FacturaID ");
                consulta.append("left join Visita v on ifnull(tf.VisitaClave1,tf.VisitaClave)=v.VisitaClave ");
                consulta.append("left join Cliente c on v.ClienteClave=c.ClienteClave  ");
                consulta.append("inner join TransProdDetalle td on tv.TransProdID=td.TransProdID  ");
                consulta.append("inner join Producto p on p.ProductoClave=td.ProductoClave ");
                consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.Tipounidad=pd.PruTipoUnidad and td.ProductoClave=pd.ProductoDetClave  ");
                consulta.append("where tf.Tipo in (8) and tf.TipoFase<>0 and tf.DiaClave='"+ diaClave +"'  ");
                consulta.append("union all ");
                consulta.append("/*Cambios*/ ");
                consulta.append("Select t.Tipo as Tipo, ");
                consulta.append("(t.Folio || (ifnull(' - ' || c.NombreCorto || ' - ','')) || (ifnull(c.RazonSocial,''))) as FolioMovimiento,  ");
                consulta.append("td.ProductoClave || ' ' || P.Nombre as Producto, ");
                consulta.append("td.TipoUnidad as TipoUnidad,  ");
                consulta.append("td.Cantidad as Cantidad, ");
                consulta.append("(td.Cantidad * pd.Factor) as TotalPiezas,");
                consulta.append("t.FacturaID, ");
                consulta.append("t.TipoMovimiento as TipoMovimiento  ");
                consulta.append("from TransProd t ");
                consulta.append("left join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave ");
                consulta.append("left join Cliente c on v.ClienteClave=c.ClienteClave  ");
                consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID  ");
                consulta.append("inner join Producto p on p.ProductoClave=td.ProductoClave ");
                consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.Tipounidad=pd.PruTipoUnidad and td.ProductoClave=pd.ProductoDetClave  ");
                consulta.append("where t.Tipo in (9) and t.TipoFase<>0 and t.DiaClave='"+ diaClave +"'  ");
                consulta.append("union all ");
                consulta.append("/*Consignas*/ ");
                consulta.append("Select t.Tipo as Tipo, ");
                consulta.append("(t.Folio || (ifnull(' - ' || c.NombreCorto || ' - ','')) || (ifnull(c.RazonSocial,''))) as FolioMovimiento,  ");
                consulta.append("td.ProductoClave || ' ' || P.Nombre as Producto, ");
                consulta.append("td.TipoUnidad as TipoUnidad,  ");
                consulta.append("td.Cantidad as Cantidad, ");
                consulta.append("(td.Cantidad * pd.Factor) as TotalPiezas, ");
                consulta.append("t.FacturaID, ");
                consulta.append("t.TipoMovimiento as TipoMovimiento  ");
                consulta.append("from TransProd t ");
                consulta.append("left join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave ");
                consulta.append("left join Cliente c on v.ClienteClave=c.ClienteClave  ");
                consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID  ");
                consulta.append("inner join Producto p on p.ProductoClave=td.ProductoClave ");
                consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.Tipounidad=pd.PruTipoUnidad and td.ProductoClave=pd.ProductoDetClave  ");
                consulta.append("where t.Tipo in (24) and t.TipoFase<>8 and t.DiaClave='"+ diaClave +"' ");
                consulta.append("union all ");
                consulta.append("/*Ventas Surtidas*/ ");
                consulta.append("Select t.Tipo as Tipo, ");
                consulta.append("(t.Folio || (ifnull(' - ' || c.NombreCorto || ' - ','')) || (ifnull(c.RazonSocial,''))) as FolioMovimiento,  ");
                consulta.append("td.ProductoClave || ' ' || P.Nombre as Producto, ");
                consulta.append("td.TipoUnidad as TipoUnidad,  ");
                consulta.append("td.Cantidad as Cantidad, ");
                consulta.append("(td.Cantidad * pd.Factor) as TotalPiezas, ");
                consulta.append("t.FacturaID, ");
                consulta.append("t.TipoMovimiento as TipoMovimiento  ");
                consulta.append("from TransProd t ");
                consulta.append("left join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave ");
                consulta.append("left join Cliente c on v.ClienteClave=c.ClienteClave  ");
                consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID  ");
                consulta.append("inner join Producto p on p.ProductoClave=td.ProductoClave ");
                consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.Tipounidad=pd.PruTipoUnidad and td.ProductoClave=pd.ProductoDetClave  ");
                consulta.append("where t.Tipo in (1) and t.TipoFase=2 and t.DiaClave='"+ diaClave +"' ");
                consulta.append(") as z ");
                consulta.append("order by z.Tipo, z.FolioMovimiento ");
            }else{
                consulta.append("select z.Tipo as Tipo, z.Producto as Producto, z.TipoUnidad as TipoUnidad, sum(z.Cantidad) as Cantidad, sum(z.TotalPiezas) as TotalPiezas, z.TipoMovimiento ");
                consulta.append("from ( ");
                consulta.append("/*Cargas, Cambios, Dev. Alamacen, Ajustes, Descargas, Mov. sin Inv. en Visita*/ ");
                consulta.append("Select t.Tipo as Tipo, ");
                consulta.append("td.ProductoClave || ' ' || P.Nombre as Producto,  ");
                consulta.append("td.TipoUnidad as TipoUnidad,   ");
                consulta.append("td.Cantidad as Cantidad,  ");
                consulta.append("(td.Cantidad * pd.Factor) as TotalPiezas, ");
                consulta.append("t.TipoMovimiento as TipoMovimiento  ");
                consulta.append("from TransProd t   ");
                consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID  ");
                consulta.append("inner join Producto p on p.ProductoClave=td.ProductoClave  ");
                consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.Tipounidad=pd.PruTipoUnidad and td.ProductoClave=pd.ProductoDetClave   ");
                consulta.append("where t.Tipo in (2,3,4,6,7,21) and t.TipoFase<>0 and t.DiaClave='"+ diaClave +"'   ");
                consulta.append("union all ");
                consulta.append("/*Facturas*/ ");
                consulta.append("Select tf.Tipo as Tipo, ");
                consulta.append("td.ProductoClave || ' ' || P.Nombre as Producto,  ");
                consulta.append("td.TipoUnidad as TipoUnidad,   ");
                consulta.append("td.Cantidad as Cantidad,  ");
                consulta.append("(td.Cantidad * pd.Factor) as TotalPiezas, ");
                consulta.append("tf.TipoMovimiento as TipoMovimiento  ");
                consulta.append("from TransProd tf ");
                consulta.append("inner join TransProd tv on tf.TransProdID=tv.FacturaID ");
                consulta.append("inner join TransProdDetalle td on tv.TransProdID=td.TransProdID   ");
                consulta.append("inner join Producto p on p.ProductoClave=td.ProductoClave  ");
                consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.Tipounidad=pd.PruTipoUnidad and td.ProductoClave=pd.ProductoDetClave   ");
                consulta.append("where tf.Tipo in (8) and tf.TipoFase<>0 and tf.DiaClave='"+ diaClave +"'  ");
                consulta.append("union all ");
                consulta.append("/*Cambios*/ ");
                consulta.append("Select t.Tipo as Tipo, ");
                consulta.append("td.ProductoClave || ' ' || P.Nombre as Producto,  ");
                consulta.append("td.TipoUnidad as TipoUnidad,   ");
                consulta.append("td.Cantidad as Cantidad,  ");
                consulta.append("(td.Cantidad * pd.Factor) as TotalPiezas, ");
                consulta.append("t.TipoMovimiento as TipoMovimiento  ");
                consulta.append("from TransProd t ");
                consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID   ");
                consulta.append("inner join Producto p on p.ProductoClave=td.ProductoClave  ");
                consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.Tipounidad=pd.PruTipoUnidad and td.ProductoClave=pd.ProductoDetClave   ");
                consulta.append("where t.Tipo in (9) and t.TipoFase<>0 and t.DiaClave='"+ diaClave +"'  ");
                consulta.append("union all ");
                consulta.append("/*Cosignas*/ ");
                consulta.append("Select t.Tipo as Tipo, ");
                consulta.append("td.ProductoClave || ' ' || P.Nombre as Producto,  ");
                consulta.append("td.TipoUnidad as TipoUnidad,   ");
                consulta.append("td.Cantidad as Cantidad,  ");
                consulta.append("(td.Cantidad * pd.Factor) as TotalPiezas, ");
                consulta.append("t.TipoMovimiento as TipoMovimiento  ");
                consulta.append("from TransProd t ");
                consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID   ");
                consulta.append("inner join Producto p on p.ProductoClave=td.ProductoClave  ");
                consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.Tipounidad=pd.PruTipoUnidad and td.ProductoClave=pd.ProductoDetClave   ");
                consulta.append("where t.Tipo in (24) and t.TipoFase<>8 and t.DiaClave='"+ diaClave +"' ");
                consulta.append("union all ");
                consulta.append("/*Ventas Surtidas*/ ");
                consulta.append("Select t.Tipo as Tipo, ");
                consulta.append("td.ProductoClave || ' ' || P.Nombre as Producto,  ");
                consulta.append("td.TipoUnidad as TipoUnidad, ");
                consulta.append("td.Cantidad as Cantidad, ");
                consulta.append("(td.Cantidad * pd.Factor) as TotalPiezas, ");
                consulta.append("t.TipoMovimiento as TipoMovimiento  ");
                consulta.append("from TransProd t ");
                consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID ");
                consulta.append("inner join Producto p on p.ProductoClave=td.ProductoClave ");
                consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.Tipounidad=pd.PruTipoUnidad and td.ProductoClave=pd.ProductoDetClave ");
                consulta.append("where t.Tipo in (1) and t.TipoFase=2 and t.DiaClave='"+ diaClave +"' ");
                consulta.append(") as z ");
                consulta.append("group by z.Tipo, z.Producto, z.TipoUnidad, z.TipoMovimiento ");
                consulta.append("order by z.Tipo, z.TipoMovimiento ");
            }

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }
    }

    public static final class ConsultaReporteVentas{

        public static ISetDatos obtenerVentasGeneral(String diaClave)throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("select t.Folio as Folio, c.NombreCorto as NombreCorto, t.Total as Total ");
            consulta.append("from TransProd t ");
            consulta.append("inner join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave and ifnull(t.DiaClave1,t.DiaClave)=v.DiaClave ");
            consulta.append("inner join Cliente c on v.ClienteClave=c.ClienteClave ");
            consulta.append("where t.Tipo=1 and t.TipoFase in (2,3) ");
            consulta.append("and t.DiaClave='"+ diaClave +"' ");
            consulta.append("order by t.Folio ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static ISetDatos obtenerVentasPorProductoPorPrecio(String diaClave)throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("select td.TipoUnidad as TipoUnidad, td.Precio as Precio, sum(td.Cantidad) as Cantidad ");
            consulta.append("from TransProd t ");
            consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID  ");
            consulta.append("where t.Tipo=1 and t.TipoFase in (2,3)");
            consulta.append("and t.DiaClave='"+ diaClave +"' ");
            consulta.append("group by td.TipoUnidad, td.Precio ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static ISetDatos obtenerVentasKiloLitros(String diaClave)throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("select sum(td.Cantidad * ifnull(pu.KgLts,0)) as KiloLitros ");
            consulta.append("from TransProd t ");
            consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID ");
            consulta.append("inner join ProductoUnidad pu on td.ProductoClave=pu.ProductoClave and td.TipoUnidad=pu.PRUTipoUnidad ");
            consulta.append("where t.Tipo=1 and t.TipoFase in (2,3) ");
            consulta.append("and t.DiaClave='"+ diaClave +"' ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static ISetDatos obtenerVentasDetallado(String diaClave)throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("select t.Tipo as Tipo, c.Clave || ' - ' || c.RazonSocial as Cliente, t.Folio as Folio, p.ProductoClave || ' - ' || p.Nombre as Producto, td.TipoUnidad as TipoUnidad, td.Cantidad as Cantidad,  ");
            consulta.append("case when ifnull(td.Promocion,0)=2 then '*' else td.Precio end as Precio, ");
            consulta.append("case when ifnull(td.Promocion,0)=2 then '' else ((td.Subtotal+td.Impuesto)-ifnull(tds.DesImporte,0)-ifnull(tdsv.DesImporte,0)-ifnull(tds.DesImpuesto,0)-ifnull(tdsv.DesImpuesto,0)) end as Total ");
            consulta.append("from TransProd t ");
            consulta.append("inner join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave and ifnull(t.DiaClave1,t.DiaClave)=v.DiaClave ");
            consulta.append("inner join Cliente c on v.ClienteClave=c.ClienteClave ");
            consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID ");
            consulta.append("left join TpdDes tds on td.TransProdID=tds.TransProdId and td.TransProdDetalleID=tds.TransProdDetalleId ");
            consulta.append("left join TPDDesVendedor tdsv on td.TransProdID=tdsv.TransProdId and td.TransProdDetalleID=tdsv.TransProdDetalleId ");
            consulta.append("inner join Producto p on td.ProductoClave=p.ProductoClave ");
            consulta.append("where t.Tipo=1 and t.TipoFase in (2,3)");
            consulta.append("and t.DiaClave='"+ diaClave +"' ");
            consulta.append("order by t.Folio, td.ProductoClave, td.TipoUnidad ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static ISetDatos obtenerVentasPorProducto(String diaClave)throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("select p.ProductoClave || ' - ' || p.Nombre as Producto, td.TipoUnidad as TipoUnidad, sum(td.Cantidad) as Cantidad,");
            consulta.append("sum(td.Total) as Total ");
            consulta.append("from TransProd t ");
            consulta.append("inner join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave and ifnull(t.DiaClave1,t.DiaClave)=v.DiaClave ");
            consulta.append("inner join Cliente c on v.ClienteClave=c.ClienteClave ");
            consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID ");
            consulta.append("left join TpdDes tds on td.TransProdID=tds.TransProdId and td.TransProdDetalleID=tds.TransProdDetalleId ");
            consulta.append("left join TPDDesVendedor tdsv on td.TransProdID=tdsv.TransProdId and td.TransProdDetalleID=tdsv.TransProdDetalleId ");
            consulta.append("inner join Producto p on td.ProductoClave=p.ProductoClave ");
            consulta.append("where t.Tipo=1 and t.TipoFase in (2,3) and ifnull(td.Promocion,0)<>2 ");
            consulta.append("and t.DiaClave='"+ diaClave +"' ");
            consulta.append("group by p.ProductoClave, p.Nombre, td.TipoUnidad ");
            consulta.append("order by p.ProductoClave, p.Nombre ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static ISetDatos obtenerVentasPromocionales(String diaClave)throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("select p.ProductoClave || ' - ' || p.Nombre as Producto, td.TipoUnidad as TipoUnidad, sum(td.Cantidad) as Cantidad,");
            consulta.append("sum(td.Total) as Total ");
            consulta.append("from TransProd t ");
            consulta.append("inner join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave and ifnull(t.DiaClave1,t.DiaClave)=v.DiaClave ");
            consulta.append("inner join Cliente c on v.ClienteClave=c.ClienteClave ");
            consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID ");
            consulta.append("left join TpdDes tds on td.TransProdID=tds.TransProdId and td.TransProdDetalleID=tds.TransProdDetalleId ");
            consulta.append("left join TPDDesVendedor tdsv on td.TransProdID=tdsv.TransProdId and td.TransProdDetalleID=tdsv.TransProdDetalleId ");
            consulta.append("inner join Producto p on td.ProductoClave=p.ProductoClave ");
            consulta.append("where t.Tipo=1 and t.TipoFase in (2,3) and ifnull(td.Promocion,0)=2 ");
            consulta.append("and t.DiaClave='"+ diaClave +"' ");
            consulta.append("group by p.ProductoClave, p.Nombre, td.TipoUnidad ");
            consulta.append("order by p.ProductoClave, p.Nombre ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static ISetDatos obtenerVentasDetalladoNombreCorto(String diaClave)throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("select t.Tipo as Tipo, c.Clave || ' - ' || c.NombreCorto as Cliente, t.Folio as Folio, p.ProductoClave || ' - ' || p.Nombre as Producto, td.TipoUnidad as TipoUnidad, td.Cantidad as Cantidad,  ");
            consulta.append("case when ifnull(td.Promocion,0)=2 then '*' else td.Precio end as Precio, ");
            consulta.append("case when ifnull(td.Promocion,0)=2 then '' else ((td.Subtotal+td.Impuesto)-ifnull(tds.DesImporte,0)-ifnull(tdsv.DesImporte,0)-ifnull(tds.DesImpuesto,0)-ifnull(tdsv.DesImpuesto,0)) end as Total ");
            consulta.append("from TransProd t ");
            consulta.append("inner join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave and ifnull(t.DiaClave1,t.DiaClave)=v.DiaClave ");
            consulta.append("inner join Cliente c on v.ClienteClave=c.ClienteClave ");
            consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID ");
            consulta.append("left join TpdDes tds on td.TransProdID=tds.TransProdId and td.TransProdDetalleID=tds.TransProdDetalleId ");
            consulta.append("left join TPDDesVendedor tdsv on td.TransProdID=tdsv.TransProdId and td.TransProdDetalleID=tdsv.TransProdDetalleId ");
            consulta.append("inner join Producto p on td.ProductoClave=p.ProductoClave ");
            consulta.append("where t.Tipo=1 and t.TipoFase in (2,3)");
            consulta.append("and t.DiaClave='"+ diaClave +"' ");
            consulta.append("order by t.Folio, td.ProductoClave, td.TipoUnidad ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

    }

    public static final class ConsultasManejoLotesCaducidad {
        public static ISetDatos recuperarManejoLotesCaducidad(String transProdID)throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("SELECT * from ManejoLotesCaducidad where TransProdID ='" + transProdID + "'");

            return BDVend.consultar(consulta.toString());
        }
        /*public static void eliminarManejoLotesCaducidad(String transProdID, String transProdDetalleID)throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("DELETE from ManejoLotesCaducidad where TransProdID ='" + transProdID + "' and TransProdDetalleID='" + transProdDetalleID + "'");

            BDVend.ejecutarComando(consulta.toString());
        }*/
    }
	public static final class ConsultaReporteDescargasDevolucion
	{
		public static ISetDatos obtenerProdcutos(String filtroFecha)throws Exception {

			StringBuilder consulta = new StringBuilder();

			consulta.append("Select Distinct TP.TransProdID, ");
			consulta.append("Case when TP.Tipo = 7 then 'Descarga' else 'Devolucion' end as TipoTransaccion, ");
			consulta.append("TP.Folio, TPD.ProductoClave, P.Nombre, TPD.TipoUnidad, TPD.Cantidad, (TPD.Cantidad * PD.Factor) as Total ");
			consulta.append("From TransProd TP ");
			consulta.append("inner join TransProdDetalle TPD on TPD.TransProdID = TP.TransProdID and TP.Tipo in (4,7) and TP.TipoFase <> 0 ");
			consulta.append("inner join ProductoDetalle PD on PD.ProductoDetClave = TPD.ProductoClave ");
			consulta.append("inner join Producto P on P.ProductoClave = PD.ProductoDetClave ");
			consulta.append("inner join Dia D on D.DiaClave = TP.DiaClave ");
			consulta.append("where P.Contenido = 0 ");
			consulta.append("and "+filtroFecha);
			consulta.append("Order by Case when TP.Tipo = 7 then 'Descarga' else 'Devolucion' end, TP.Folio");

			ISetDatos datos = BDVend.consultar(consulta.toString());

			return datos;
		}

		public static ISetDatos obtenerEnvace(String filtroFecha)throws Exception {

			StringBuilder consulta = new StringBuilder();

			consulta.append("Select Distinct TP.TransProdID, ");
			consulta.append("Case when TP.Tipo = 7 then 'Descarga' else 'Devolucion' end as TipoTransaccion, ");
			consulta.append("TP.Folio, TPD.ProductoClave, P.Nombre, TPD.TipoUnidad, TPD.Cantidad, (TPD.Cantidad * PD.Factor) as Total ");
			consulta.append("From TransProd TP ");
			consulta.append("inner join TransProdDetalle TPD on TPD.TransProdID = TP.TransProdID and TP.Tipo in (4,7) and TP.TipoFase <> 0 ");
			consulta.append("inner join ProductoDetalle PD on PD.ProductoClave = TPD.ProductoClave ");
			consulta.append("inner join Producto P on P.ProductoClave = PD.ProductoClave ");
			consulta.append("inner join Dia D on D.DiaClave = TP.DiaClave ");
			consulta.append("where P.Contenido = 1 ");
			consulta.append("and "+filtroFecha);
			consulta.append("Order by Case when TP.Tipo = 7 then 'Descarga' else 'Devolucion' end, TP.Folio");

			ISetDatos datos = BDVend.consultar(consulta.toString());

			return datos;
		}

		public static ISetDatos obtenerResumenGeneral(String filtroFecha)throws Exception {

			StringBuilder consulta = new StringBuilder();

			consulta.append("Select Distinct ");
			consulta.append("TPD.ProductoClave, P.Nombre,SUM((TPD.Cantidad * PD.Factor))  as Total  ");
			consulta.append("From TransProd TP  ");
			consulta.append("inner join TransProdDetalle TPD on TPD.TransProdID = TP.TransProdID and TP.Tipo in (4,7) and TP.TipoFase <> 0 ");
			consulta.append("inner join ProductoDetalle PD on PD.ProductoDetClave = TPD.ProductoClave ");
			consulta.append("inner join Producto P on P.ProductoClave = PD.ProductoClave and P.ProductoClave = PD.ProductoDetClave ");
			consulta.append("inner join Dia D on D.DiaClave = TP.DiaClave ");
			consulta.append("where ");
			consulta.append(filtroFecha);
			consulta.append("Group by TPD.ProductoClave, P.Nombre");

			ISetDatos datos = BDVend.consultar(consulta.toString());

			return datos;
		}

	}

    public static final class ConsultasMercadeo{
        public static ISetDatos recuperarMERDetalleNavegacion(String visitaClave, String diaClave)throws Exception
        {
            StringBuilder consulta = new StringBuilder();

            consulta.append("SELECT MRD.MRDId as _id,  MPR.Producto as Producto, MEM.Marca as Marca, MRD.Tipo || ' ' || MRD.Presentacion as Presentacion ");
            consulta.append("from MERDetalle MRD ");
            consulta.append("inner join MercadeoProducto MPR on MRD.MPRId = MPR.MPRId ");
            consulta.append("inner join MercadeoMarca MEM on MEM.MEMId = MRD.MEMId ");
            consulta.append("where MRD.VisitaClave ='" + visitaClave + "' and MRD.DiaClave ='" + diaClave + "' and MRD.Enviado = 0 ");

            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos spinnerMercadeoProducto()throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("SELECT MPRId as _id, Producto as Producto from MercadeoProducto where Estado = 1 UNION Select 0 as _id, 'Ninguno'  as Producto ");

            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos spinnerMercadeoMarca()throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("SELECT MEMId as _id, Marca as Marca from MercadeoMarca where Estado = 1 UNION Select 0 as _id, 'Ninguno'  as Marca ");

            return BDVend.consultar(consulta.toString());
        }
        public static MercadeoProducto recuperarMercadeoProducto(String producto)throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("SELECT MPRId from MercadeoProducto where Producto ='" + producto + "' ");

            ISetDatos sdMPR =  BDVend.consultar(consulta.toString());
            if (sdMPR != null && sdMPR.getCount() >0){
                sdMPR.moveToFirst();
                MercadeoProducto oMPR = new MercadeoProducto();
                oMPR.MPRId = sdMPR.getString("MPRId");
                BDVend.recuperar(oMPR);
                if (oMPR.isRecuperado()){
                    sdMPR.close();
                    return oMPR;
                }
            }
            sdMPR.close();
            return null;
        }

        public static MercadeoMarca recuperarMercadeoMarca(String marca)throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("SELECT MEMId from MercadeoMarca where Marca ='" + marca + "' ");

            ISetDatos sdMEM =  BDVend.consultar(consulta.toString());
            if (sdMEM != null && sdMEM.getCount() >0){
                sdMEM.moveToFirst();
                MercadeoMarca oMEM = new MercadeoMarca();
                oMEM.MEMId = sdMEM.getString("MEMId");
                BDVend.recuperar(oMEM);
                if (oMEM.isRecuperado()){
                    sdMEM.close();
                    return oMEM;
                }
            }
            sdMEM.close();
            return null;
        }
    }
}
