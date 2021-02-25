package com.amesol.routelite.datos.basedatos;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.SearchManager;
import android.database.Cursor;
import android.database.MergeCursor;
import android.text.TextUtils;
import android.util.Log;

import com.amesol.routelite.actividades.Clientes;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Esquemas;
import com.amesol.routelite.actividades.FoliosFiscales;
import com.amesol.routelite.actividades.InventarioDobleUnidad;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ModuloMov;
import com.amesol.routelite.actividades.ModuloMovDetalle;
import com.amesol.routelite.actividades.Productos;
import com.amesol.routelite.actividades.PromocionDetalle;
import com.amesol.routelite.actividades.Promociones2;
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
import com.amesol.routelite.datos.SaldoDeposito;
import com.amesol.routelite.datos.TPDDatosExtra;
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
import com.amesol.routelite.vistas.CapturaTotales;
import com.amesol.routelite.vistas.CentroExpedicion;
import com.amesol.routelite.vistas.ConsultaInventario;
import com.amesol.routelite.vistas.ConsultaInventario.ListaInventario;
import com.amesol.routelite.vistas.RevisionPendientes.pendientes;
import com.amesol.routelite.vistas.Vista;
import com.amesol.routelite.vistas.utilerias.ServicesCentral;

import java.lang.reflect.Field;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.Formatter;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.SortedMap;
import java.util.TreeMap;

@SuppressLint("SimpleDateFormat")
public final class Consultas
{
	public static final class ConsultasValorReferencia
	{
		public static ISetDatos obtenerValores() throws Exception 
		{
			return BDTerm.consultar("SELECT VV.VARCodigo || VV.VAVClave _id, VV.VARCodigo, VV.VAVClave, VV.Grupo, VD.Descripcion, VV.ClaveSAT, VD.DescripcionSAT FROM VARValor VV INNER JOIN VAVDescripcion VD ON VV.VARCodigo = VD.VARCodigo AND VV.VAVClave = VD.VAVClave");
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

        public static ISetDatos obtenerValoresOrdenadoDescripcion(String VARCodigo, String SoloEstosValores, String Grupo) throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select _id, VAVClave, Descripcion from (");
            consulta.append("select VAD.VAVClave as _id, VAD.VAVClave, VAD.Descripcion, VVA.Grupo from ValorReferencia VR ");
            consulta.append("inner join VARValor VVA on VR.VARCodigo = VVA.VARCodigo ");
            consulta.append("inner join VAVDescripcion VAD on VR.VARCodigo = VAD.VARCodigo and VAD.VAVClave = VVA.VAVClave ");
            consulta.append("where VR.VARCodigo = '" + VARCodigo + "' ");
            if (SoloEstosValores != null)
                consulta.append("AND VVA.VAVClave in (" + SoloEstosValores + ") ");
            if (Grupo != null)
                consulta.append("and VVA.Grupo in (" + Grupo + ") ");
            consulta.append(")  order by case when Grupo = 'NO DEFINIDO' then 0 else 1 end,  Descripcion ");
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

        public static ISetDatos obtenerValoresReferenciaVariosFiltros(String VARCodigo, String SoloEstosValores, String ExeptoEstosValores, String Grupo, String OrderByCampo) throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select X.VavClave as VavClave, X.Descripcion as Descripcion, X.Grupo as Grupo ");
            consulta.append("from (");
            consulta.append("   select VAD.VAVClave as _id, VAD.VAVClave, VAD.Descripcion, VVA.Grupo ");
            consulta.append("   from ValorReferencia VR ");
            consulta.append("   inner join VARValor VVA on VR.VARCodigo = VVA.VARCodigo ");
            consulta.append("   inner join VAVDescripcion VAD on VR.VARCodigo = VAD.VARCodigo and VAD.VAVClave = VVA.VAVClave ");
            consulta.append("   where VR.VARCodigo = '" + VARCodigo + "' ");
            if (SoloEstosValores != null & SoloEstosValores != "")
                consulta.append("       AND VVA.VAVClave in (" + SoloEstosValores + ") ");
            if (ExeptoEstosValores != null & ExeptoEstosValores != "")
                consulta.append("       AND VVA.VAVClave not in (" + ExeptoEstosValores + ") ");
            if (Grupo != null & Grupo != "")
                consulta.append("       and VVA.Grupo in (" + Grupo + ") ");
            consulta.append(") X ");
            if (OrderByCampo != null & OrderByCampo != "")
                consulta.append("order by " + OrderByCampo);
            return BDTerm.consultar(consulta.toString());
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

        public static Date obtenerFechaUltimoDia() throws Exception
        {
            Date resultado;
            ISetDatos setDatos = BDVend.consultar("select max(fechaCaptura) from dia");
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
			sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Ifnull(Calle, ' ') || ' ' || Ifnull(numero, ' ') AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + ", HorarioVisita ");
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
			sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '') as HorarioVisita ");
			sConsulta.append("FROM Agenda ");
			sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
			sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
			sConsulta.append("INNER join visita VIS on VIS.ClienteClave = Agenda.ClienteClave and VIS.DiaClave = '" + diaActual.DiaClave + "' and Agenda.RUTClave = VIS.RutClave and VIS.VendedorID = Agenda.VendedorID ");
			sConsulta.append("WHERE Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
			sConsulta.append("GROUP BY Cliente.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '')) as t ");
			if (filtro != null)
				sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
			sConsulta.append("ORDER BY Orden ");
			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerNoVisitados(Dia diaActual, Ruta rutaActual, String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Ifnull(Calle, ' ') || ' ' || Ifnull(numero, ' ') AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + ", HorarioVisita ");
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
			sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '') as HorarioVisita ");
			sConsulta.append("FROM Agenda ");
			sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
			sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
			sConsulta.append("WHERE Visitado=2 AND DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
			sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '')) as t ");
			if (filtro != null)
				sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
			sConsulta.append("ORDER BY Orden ");
			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerFueraFrecuencia(Dia diaActual, Ruta rutaActual, String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT AGN.ClienteClave AS _id, AGN.ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Ifnull(Calle, ' ') || ' ' || Ifnull(numero, ' ') AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + ", ifnull(AGN.HorarioVisita, '') as HorarioVisita ");
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
			sConsulta.append("group by AGN.ClienteClave, CLI.Clave, CLI.RazonSocial, CLI.NombreContacto, CLD.Calle, CLD.Numero, ifnull(AGN.HorarioVisita, '') ");
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
			sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Ifnull(Calle, ' ') || ' ' || Ifnull(numero, ' ') AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + ", HorarioVisita ");
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
			sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '') as HorarioVisita ");
			sConsulta.append("FROM Agenda ");
			sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
			sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
			if(diaActual != null && rutaActual != null) sConsulta.append("WHERE DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
			sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '')) as t ");
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
			sConsulta.append("SELECT AGN.ClienteClave AS _id, AGN.ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Ifnull(Calle, ' ') || ' ' || Ifnull(numero, ' ') AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + ", ifnull(AGN.HorarioVisita, '') as HorarioVisita ");
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
			sConsulta.append("group by AGN.ClienteClave, CLI.Clave, CLI.RazonSocial, CLI.NombreContacto, CLD.Calle, CLD.Numero, ifnull(AGN.HorarioVisita, '') ");
			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerConMensaje(String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Ifnull(Calle, ' ') || ' ' || Ifnull(numero, ' ') AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + ", HorarioVisita ");
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
			sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '') as HorarioVisita ");
			sConsulta.append("FROM Agenda ");
			sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
			sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
			sConsulta.append("WHERE Cliente.ClienteClave in (select ClienteClave  from ClienteMensaje where TipoEstado=1) ");
			sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '')) as t ");
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
				sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Ifnull(Calle, ' ') || ' ' || Ifnull(numero, ' ') AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + ", HorarioVisita ");
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
				sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '') as HorarioVisita ");
				sConsulta.append("FROM Agenda ");
				sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
				sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
				sConsulta.append("WHERE DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
				sConsulta.append("and cliente.clienteclave  in( select v.clienteclave from transprod t inner join visita v on t.visitaclave=v.visitaclave and t.diaclave=v.diaclave left join AbnTrp At on At.TransprodID=t.TransprodID left join Abono A on A.AbnID =At.ABnID and A.DiaClave=  '" + diaActual.DiaClave + "' ");
				sConsulta.append("where t.diaclave <> '" + diaActual.DiaClave + "' and (t.DiaClave1 <> '" + diaActual.DiaClave + "' or t.DiaClave1 is null) and A.AbnID is null and t.TipoFase not in (0,1) and t.saldo>0 and ((Tipo = 1 AND FechaCobranza  <= '" + sFecha + "' ) or Tipo = 24) ) ");
				sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '')) as t ");
				if (filtro != null)
					sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
				sConsulta.append("ORDER BY Orden ");
			} // ___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---
			else if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 0)
			{
				sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Ifnull(Calle, ' ') || ' ' || Ifnull(numero, ' ') AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + ", HorarioVisita ");
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
				sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '') as HorarioVisita ");
				sConsulta.append("FROM Agenda ");
				sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
				sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
				sConsulta.append("WHERE DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
				sConsulta.append("and cliente.clienteclave  in( select v.clienteclave from transprod t inner join visita v on t.visitaclave=v.visitaclave and t.diaclave=v.diaclave left join AbnTrp At on At.TransprodID=t.TransprodID left join Abono A on A.AbnID =At.ABnID and A.DiaClave=  '" + diaActual.DiaClave + "' ");
				sConsulta.append("where t.diaclave <> '" + diaActual.DiaClave + "' and (t.DiaClave1 <> '" + diaActual.DiaClave + "' or t.DiaClave1 is null) and A.AbnID is null and t.TipoFase not in (0) and t.saldo>0 and ((Tipo = 8 AND FechaCobranza  <= '" + sFecha + "' ) or Tipo = 24) ) ");
				sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '')) as t ");
				if (filtro != null)
					sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
				sConsulta.append("ORDER BY Orden ");
			} // ___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---___---
			else if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
			{
				sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Ifnull(Calle, ' ') || ' ' || Ifnull(numero, ' ') AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + ", HorarioVisita ");
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
				sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '') as HorarioVisita ");
				sConsulta.append("FROM Agenda ");
				sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
				sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
				sConsulta.append("WHERE DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
				sConsulta.append("and cliente.clienteclave  in( select v.clienteclave from transprod t inner join visita v on t.visitaclave=v.visitaclave and t.diaclave=v.diaclave left join AbnTrp At on At.TransprodID=t.TransprodID left join Abono A on A.AbnID =At.ABnID and A.DiaClave=  '" + diaActual.DiaClave + "' ");
				//sConsulta.append("where t.diaclave <> '" + diaActual.DiaClave + "' and (t.DiaClave1 <> '" + diaActual.DiaClave + "' or t.DiaClave1 is null) and A.AbnID is null ");
				//sConsulta.append("and t.saldo>0 and (FechaCobranza  <= '" + sFecha + "' ) and t.TipoFase (CASE WHEN Cliente.TipoFiscal=1 Then 1 Else 8 END) and (t.Tipo=(CASE WHEN Cliente.TipoFiscal=1 Then 1 Else 8 END) or t.Tipo=24)) ");
				sConsulta.append("where t.diaclave <> '" + diaActual.DiaClave + "' and (t.DiaClave1 <> '" + diaActual.DiaClave + "' or t.DiaClave1 is null) and A.AbnID is null ");
				sConsulta.append("and t.saldo > 0 and FechaCobranza  <= '" + sFecha + "' ");
				sConsulta.append("and ((t.Tipo=(CASE WHEN Cliente.TipoFiscal=1 Then 1 Else 8 END) ");
				sConsulta.append("and t.TipoFase <> 0 and t.TipoFase <> (CASE WHEN Cliente.TipoFiscal=1 Then 1 else 0 end)) ");
				sConsulta.append("or (t.Tipo = 24 and t.TipoFase <> 0))) ");
				sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '')) as t ");

				if (filtro != null)
					sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
				sConsulta.append("ORDER BY Orden ");
			}

			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerImproductivos(Dia diaActual, Ruta rutaActual, String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Ifnull(Calle, ' ') || ' ' || Ifnull(numero, ' ') AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + ", HorarioVisita ");
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
			sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '') as HorarioVisita ");
			sConsulta.append("FROM Agenda ");
			sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
			sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
			sConsulta.append("WHERE Visitado=4 AND DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
			sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '')) as t ");
			if (filtro != null)
				sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
			sConsulta.append("ORDER BY Orden ");

			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerPorSurtir(Dia diaActual, Ruta rutaActual, String filtro) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto,  Ifnull(Calle, ' ') || ' ' || Ifnull(numero, ' ') AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + ", HorarioVisita ");
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
			sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '') as HorarioVisita ");
			sConsulta.append("FROM Agenda ");
			sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
			sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
			sConsulta.append("WHERE Agenda.DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' AND Cliente.ClienteClave in (select v.clienteclave ");
			sConsulta.append("from transprod t inner join visita v on t.visitaclave=v.visitaclave and t.diaclave=v.diaclave ");
			sConsulta.append("where ((t.TipoFase = 1 and t.TipoPedido=2) or (t.TipoFase = 7 and t.FechaEntrega = '" + diaActual.FechaCaptura + "')) and (Tipo = 1 or Tipo = 24))");
			sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '')) as t ");
			if (filtro != null)
				sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
			sConsulta.append("ORDER BY Orden");

			return BDVend.consultar(sConsulta.toString());
		}

        public static ISetDatos obtenerPorRecolectar(Dia diaActual, Ruta rutaActual, String filtro) throws Exception
        {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("SELECT ClienteClave AS _id, ClienteClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", Clave || ' - ' || RazonSocial AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", CASE WHEN NombreContacto IS NULL OR NombreContacto = ''  THEN 'Sin datos de Contacto' ELSE NombreContacto END AS Contacto, Ifnull(Calle, ' ') || ' ' || Ifnull(numero, ' ') AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + ", HorarioVisita ");
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
            sConsulta.append("SELECT Min(Agenda.Orden) as Orden,Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '') as HorarioVisita ");
            sConsulta.append("FROM Agenda ");
            sConsulta.append("INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave ");
            sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
            sConsulta.append("WHERE Agenda.DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' AND Cliente.ClienteClave in (select v.clienteclave ");
            sConsulta.append("from transprod t inner join visita v on t.visitaclave=v.visitaclave and t.diaclave=v.diaclave ");
            sConsulta.append("where t.Tipo = 3 and t.FechaEntrega <= '" + diaActual.FechaCaptura + "' and t.FechaSurtido is null and t.TipoFase = 1) ");
            sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero, ifnull(Agenda.HorarioVisita, '')) as t ");
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
			sConsulta.append("ClienteDomicilio.Calle || ' ' || ClienteDomicilio.Numero AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + ", '' as HorarioVisita, 0 as PedidosXSurtir ");
			sConsulta.append("FROM Cliente ");
			sConsulta.append("INNER JOIN ClienteDomicilio ON Cliente.ClienteClave = ClienteDomicilio.ClienteClave AND ClienteDomicilio.Tipo = 2 ");
			sConsulta.append("WHERE Cliente.Clave LIKE '" + ((Ruta)Sesion.get(Campo.RutaActual)).RUTClave + "%' and FechaRegistroSistema between '" + Generales.getPrimerHora(((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura) + "' and '" + Generales.getUltimaHora(((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura) + "' ");
			sConsulta.append("GROUP BY Cliente.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero ");

			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerMensajesCliente(String clienteClave, String tipoModulo) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();

			sConsulta.append("select CAST(MMS.MDBMensajeTipo AS nvarchar) || CAST(MMS.Numero AS nvarchar) as _id, CAST(MMS.MDBMensajeTipo AS nvarchar) || CAST(MMS.Numero AS nvarchar) || ' - ' || MMS.Descripcion as Descripcion ");
			sConsulta.append("from ClienteMensaje CLM ");
			sConsulta.append("inner join MDBMensaje MMS on MMS.MDBMensajeID = CLM.MDBMensajeID ");
			sConsulta.append("inner join ModuloMensaje MME on MME.MDBMensajeID =  MMS.MDBMensajeID ");
			sConsulta.append("where CLM.Tipoestado=1 and CLM.ClienteClave='" + clienteClave + "' ");
			sConsulta.append("and MME.TipoIndice = " + tipoModulo + " ");
			sConsulta.append("order by CLM.MFechaHora ");

			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerMensajes(String clienteClave) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();

			sConsulta.append("SELECT CM.ClienteMensajeId, CM.ClienteClave, MM.Descripcion FROM ClienteMensaje AS CM ");
			sConsulta.append("INNER JOIN MDBMensaje AS MM ON MM.MDBMensajeID = CM.MDBMensajeID ");
			sConsulta.append("WHERE (CM.TipoEstado = 1 OR CM.TipoEstado = 2) AND CM.ClienteClave = '" + clienteClave + "'");

			return BDVend.consultar(sConsulta.toString());
		}

		public static void actualizarEstadoMensaje(String clienteMensajeId) throws Exception
		{
			BDVend.ejecutarComando("UPDATE ClienteMensaje SET TipoEstado = 0 WHERE ClienteMensajeId = '" + clienteMensajeId + "'");
		}

		public static short obtenerTiempoMinVisita() throws Exception
		{
			ISetDatos datos = BDVend.consultar("SELECT Valor FROM ConfigParametro WHERE Parametro = 'TiempoMinVisita'");
			short res = 0;
			if (datos.moveToNext())
			{
				res = datos.getShort(0);
			}
			datos.close();
			return res;
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

            sConsulta.append("select ClienteDomicilioId as _id, ClienteDomicilioId, ifnull(Calle,'') || ' ' || ifnull(Numero,'')  || ' ' || ifnull(Poblacion,'') ");
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("MostrarClienteDomicilioID") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("MostrarClienteDomicilioID").equals("1"))
                sConsulta.append(" || ' ' || ClienteDomicilioID ");
            sConsulta.append("as Domicilio ");
			sConsulta.append("from ClienteDomicilio ");
			sConsulta.append("where ClienteClave = '" + clienteClave + "' and Tipo = " + sTipo);
			return BDVend.consultar(sConsulta.toString());
		}

        public static boolean existeCFVTipo(String ClienteClave) throws Exception
        {
            ISetDatos datos = BDVend.consultar("SELECT count(*) as NumCFVTipo from CLIFormaVenta WHERE ClienteClave = '" + ClienteClave + "' and Estado=1");
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

        public static String[] obtenerTelefonosContacto(String clienteClave){
            try {
                String telefonos = BDVend.bd.ejecutarEscalar("select ifnull(TelefonoContacto, '') from Cliente where ClienteClave = '" + clienteClave + "'");
                if (!telefonos.equals(""))
                    return telefonos.split(",");
                else
                    return null;
            }catch(Exception e){
                return null;
            }
        }

        public static ISetDatos obtenerFacturasEdoCta(Cliente oCliente) throws Exception {
            StringBuilder sConsulta = new StringBuilder();
            int tipoTRP;
            CONHist conh = (CONHist) Sesion.get(Campo.CONHist);
            if (conh.get("TipoCobranza").toString().equals("1") || (conh.get("TipoCobranza").toString().equals("2") && oCliente.TipoFiscal == 1))
                tipoTRP = 1;
            else
                tipoTRP = 8;

            String notaCredito = ValoresReferencia.getStringVAVClave("PAGO", "NC");
            if (( notaCredito == null) || notaCredito.length() == 0)
                notaCredito = "0";

            sConsulta.append("select * from ( ");
            sConsulta.append("select 'F' as Tipo, TRP.TransProdID, TRP.FechaCaptura, TRP.Folio, TRP.Total as Importe, TRP.Saldo, ifnull(TRP.Notas, '') as Notas, ifnull(TDC.Importe, 0) as Descuento, ifnull(TDC.Porcentaje, 0) as DescPorcentaje ");
            sConsulta.append("from TransProd TRP ");
            sConsulta.append("left join TRPDescCalculadora TDC on TRP.TransProdID = TDC.TransProdID and TDC.AplicadoCobranza = 1 ");
            sConsulta.append("where TRP.TransProdID in ( ");
            sConsulta.append("  select TRP.TransProdID ");
            sConsulta.append("  from TransProd TRP ");
            sConsulta.append("  inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ");
            sConsulta.append("  where TRP.Tipo = " + tipoTRP + " and Saldo >= 0 and VIS.ClienteClave = '" + oCliente.ClienteClave + "' ");
            sConsulta.append("  union ");
            sConsulta.append("  select ABT.TransProdID ");
            sConsulta.append("  from AbnTrp ABT ");
            sConsulta.append("  inner join ABNDetalle ABD on ABT.ABNId = ABD.ABNId ");
            sConsulta.append("  inner join Visita VIS on VIS.VisitaClave = ABT.VisitaClave and VIS.DiaClave = ABT.DiaClave ");
            sConsulta.append("  inner join Dia on VIS.DiaClave = Dia.DiaClave ");
            sConsulta.append("  where ABD.TipoPago = " + notaCredito + " and VIS.ClienteClave = '" + oCliente.ClienteClave + "' ");
            sConsulta.append("  union ");
            sConsulta.append("  select ABT.TransProdID ");
            sConsulta.append("  from Abono ABN ");
            sConsulta.append("  inner join ABNDetalle ABD on ABN.ABNId = ABD.ABNId ");
            sConsulta.append("  inner join AbnTrp ABT on ABN.ABNId = ABT.ABNId ");
            sConsulta.append("  inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave and VIS.DiaClave = ABN.DiaClave ");
            sConsulta.append("  where ABD.TipoPago <> " + notaCredito + " and VIS.ClienteClave = '" + oCliente.ClienteClave + "') ");
            sConsulta.append("union ");
            sConsulta.append("select 'S' as Tipo, ABN.ABNId, ABN.FechaAbono, ABN.Folio, ABN.Total, ABN.Saldo, ifnull(ABD.Observaciones, '') as Notas, 0, 0 ");
            sConsulta.append("from Abono ABN ");
            sConsulta.append("inner join ABNDetalle ABD on ABN.ABNId = ABD.ABNId ");
            sConsulta.append("inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave and VIS.DiaClave = ABN.DiaClave ");
            sConsulta.append("where ABN.Saldo > 0 and VIS.ClienteClave = '" + oCliente.ClienteClave + "' ");
            sConsulta.append(") as t ");
            sConsulta.append("order by FechaCaptura ");

            return BDVend.consultar(sConsulta.toString());
        }

		public static ISetDatos obtenerMovimientosEdoCta(Cliente oCliente) throws Exception {
			StringBuilder sConsulta = new StringBuilder();

			String notaCredito = ValoresReferencia.getStringVAVClave("PAGO", "NC");
			if (( notaCredito == null) || notaCredito.length() == 0)
				notaCredito = "0";

			sConsulta.append("select * from ( ");
			sConsulta.append("select 'N' as Tipo, ABT.ABNId as MovimientoID, ABT.TransProdID as FacturaID, Dia.FechaCaptura, ABN.Folio, ABT.Importe, ifnull(ABD.Observaciones, '') as Observaciones, ABD.MFechaHora ");
			sConsulta.append("from AbnTrp ABT ");
			sConsulta.append("inner join ABNDetalle ABD on ABT.ABNId = ABD.ABNId ");
			sConsulta.append("inner join Abono ABN on ABN.ABNId = ABT.ABNId ");
			sConsulta.append("inner join TransProd FAC on ABT.TransProdID = FAC.TransProdID ");
			sConsulta.append("inner join Visita VIS on VIS.VisitaClave = ABT.VisitaClave and VIS.DiaClave = ABT.DiaClave ");
			sConsulta.append("inner join Dia on VIS.DiaClave = Dia.DiaClave ");
			sConsulta.append("where ABD.TipoPago = " + notaCredito +" and VIS.ClienteClave = '" + oCliente.ClienteClave + "' ");
			sConsulta.append("union ");
			sConsulta.append("select 'A' as Tipo, ABT.ABNId, ABT.TransProdID, ABN.FechaAbono, ABN.Folio, ABT.Importe, ifnull(ABD.Observaciones, '') as Observaciones, ABD.MFechaHora ");
			sConsulta.append("from Abono ABN ");
			sConsulta.append("inner join ABNDetalle ABD on ABN.ABNId = ABD.ABNId ");
			sConsulta.append("inner join AbnTrp ABT on ABN.ABNId = ABT.ABNId ");
			sConsulta.append("inner join TransProd FAC on ABT.TransProdID = FAC.TransProdID ");
			sConsulta.append("inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave and VIS.DiaClave = ABN.DiaClave ");
			sConsulta.append("where ABD.TipoPago <> " + notaCredito + " and VIS.ClienteClave = '" + oCliente.ClienteClave + "' ");
			sConsulta.append(") as t ");
			sConsulta.append("order by FacturaID, MFechaHora ");

			return BDVend.consultar(sConsulta.toString());
		}

        public static String obtenerClienteDomicilioIdPE(String clienteClave) throws Exception {
            return (BDVend.bd.ejecutarEscalar("select ClienteDomicilioId from ClienteDomicilio where ClienteClave = '" + clienteClave + "' and Tipo = 2"));
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

        public static ISetDatos obtenerPreciosProducto(String sProductoClave, short sPruTipoUnidad, String sClienteClave, String sPrecioClave, short sJerarquiaMin, short sJerarquiaMax) throws Exception
        {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select p.PrecioClave _id, p.Nombre, ppv.Precio, (p.PrecioClave || ' ' || p.Nombre) as Descripcion ");
            sConsulta.append("from PrecioProductoVig ppv ");
            sConsulta.append("inner join Precio p on ppv.PrecioClave=p.PrecioClave ");
            sConsulta.append("where ppv.ProductoClave='" + sProductoClave + "' and ppv.PRUTipoUnidad='" + sPruTipoUnidad + "' ");
            sConsulta.append("and ppv.PrecioClave not in ('" + sPrecioClave + "') and p.Jerarquia between " + sJerarquiaMax + " and " + sJerarquiaMin + " ");

            return BDVend.consultar(sConsulta.toString());
        }

		public static ISetDatos obtenerPreciosProducto(String productoClave, int tipoUnidad, String clienteClave) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			String modulo = (String)Sesion.get(Campo.ModuloMovDetalleClave);
			consulta.append("SELECT Pre.PrecioClave _id, Pre.Nombre as Descripcion, PPV.Precio ");
			consulta.append("FROM PrecioProductoVig PPV ");
			consulta.append("INNER JOIN Precio Pre ON Pre.PrecioClave = PPV.PrecioClave AND PPV.ProductoClave = '" +productoClave+ "' ");
			consulta.append("AND PPV.PRUTipoUnidad = '" +tipoUnidad+ "' AND PPV.FechaFin >= DATETIME('now') ");
			consulta.append("AND Pre.PrecioClave IN (SELECT PrecioClave FROM PrecioClienteEsquema WHERE ModuloMovDetalleClave = '" +modulo+ "' ");
			consulta.append("AND EsquemaID IN (SELECT EsquemaID FROM ClienteEsquema WHERE ClienteClave = '" +clienteClave+ "')) ");
			consulta.append("ORDER BY Pre.Jerarquia ASC");

			return BDVend.consultar(consulta.toString());

		}

        public static ISetDatos obtenerJerarquiaMinMaxCliente(String sClienteClave) throws Exception
        {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select MIN(p.Jerarquia) as JerarquiaMaxima, MAX(p.Jerarquia) as JerarquiaMinima ");
            sConsulta.append("from Precio p  ");
            sConsulta.append("inner join PrecioClienteEsquema pce on p.PrecioClave=pce.PrecioClave ");
            sConsulta.append("inner join Esquema e on pce.EsquemaID=e.EsquemaID ");
            sConsulta.append("inner join ClienteEsquema ce on pce.EsquemaID=ce.EsquemaID ");
            sConsulta.append("where ce.ClienteClave='" + sClienteClave + "' ");

            return BDVend.consultar(sConsulta.toString());
        }

		public static String ObtenerMinimaPPVFechaInicio(String PrecioClave, Short TipoUnidad, String ProductoClave) throws Exception
		{
			String resultado;
			ISetDatos setDatos = BDVend.consultar("select min(PPVFechaInicio) from PrecioProductoVig where PrecioClave = '"+PrecioClave+"' and PRUTipoUnidad ="+TipoUnidad+" and ProductoClave = '"+ProductoClave+"'");
			if (!setDatos.moveToNext())
				return null;
			resultado = setDatos.getString(0);
			setDatos.close();
			return resultado;
		}

		public static String ObtenerMaximaPPVFechaInicio(String PrecioClave, Short TipoUnidad, String ProductoClave) throws Exception
		{
			String resultado;
			ISetDatos setDatos = BDVend.consultar("select max(PPVFechaInicio) from PrecioProductoVig where PrecioClave = '"+PrecioClave+"' and PRUTipoUnidad ="+TipoUnidad+" and ProductoClave = '"+ProductoClave+"'");
			if (!setDatos.moveToNext())
				return null;
			resultado = setDatos.getString(0);
			setDatos.close();
			return resultado;
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

		public static ISetDatos ObtenerCantidad(String TransProdID, String ProductoClave, int TipoUnidad) throws Exception
		{
			try
			{
				return BDVend.consultar("select Cantidad from TransProdDetalle where ProductoClave='" + ProductoClave + "' and TipoUnidad = " + TipoUnidad + " and TransProdID='" + TransProdID.replace("'", "") + "'");
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

        public static ISetDatos obtenerEsquemas(ServicesCentral.TiposEsquemas Tipo, int Clasificacion)
        {
            try
            {
                return BDVend.getBD().consultar("SELECT EsquemaID as _id, * FROM Esquema WHERE Tipo = " + Tipo.value + " AND Clasificacion = " + Clasificacion);
            }
            catch (Exception ex)
            {
                ex.printStackTrace();
                return null;
            }

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

	public static final class ConsultasProducto {

		public static Producto obtenerProducto(String ProductoClave) throws Exception {
			Producto oProducto = new Producto();
			oProducto.ProductoClave = ProductoClave;
			BDVend.recuperar(oProducto);
			return oProducto;
		}

		public static Producto[] obtenerProductosConPromocion(String EsquemasCliente, String ModuloMovDetalleClave) {
			try {

				// String fechaactualformat =
				// Generales.getFormatoFecha(Generales.getFechaActual(),"yyyy-MM-dd");
				String Consult = "select distinct PRP.ProductoClave, PRO.Nombre" + " from Promocion PRM" + " inner join PromocionModulo PMD on PRM.PromocionClave = PMD.PromocionClave and PMD.ModuloMovDetalleClave = '" + ModuloMovDetalleClave + "' and PMD.TipoEstado = 1" + " inner join PromocionProducto PRP on PRM.PromocionClave = PRP.PromocionClave" + " inner join Producto PRO on PRP.ProductoClave = PRO.ProductoClave and PRO.TipoFase = 1" + " left join PromocionDetalle PDT on PRP.PromocionClave = PDT.PromocionClave and PDT.TipoEstado = 1" + " inner join ProductoDetalle PRD on PRP.ProductoClave = PRD.ProductoClave and PRD.ProductoClave = PRD.ProductoDetClave" + " where PRM.TipoEstado = 1 and PRP.TipoEstado = 1 and DATETIME('now') between FechaInicial and FechaFinal" + " and ((PRM.Tipo in (2,4) and PDT.EsquemaId in (" + EsquemasCliente + ")) or PRM.Tipo = 1) ";

				ISetDatos datos = BDVend.consultar(Consult);
				Producto[] aProductos = new Producto[datos.getCount()];
				int i = 0;
				while (datos.moveToNext()) {
					aProductos[i] = new Producto();
					aProductos[i].ProductoClave = datos.getString("ProductoClave");
					aProductos[i].Nombre = datos.getString("Nombre");

					i++;
				}
				datos.close();
				return aProductos;

			} catch (Exception ex) {
				ex.printStackTrace();
				return null;
			}

		}

		public static ISetDatos obtenerUnidadesProducto(String productoClave, String listaPrecios, boolean manejoDobleUnidad, boolean esCanje, boolean capturarContenedor) throws Exception {
			StringBuilder consulta = new StringBuilder();
			String estados = "";
			String orderByUnidades = "";
			if (manejoDobleUnidad) {
				estados = "1,3";
				try {
					if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrdenCapturaUnidad", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
						String orderCapturaUnidad = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrdenCapturaUnidad", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).toString();
						String[] aOrdenCapturaUnidad = orderCapturaUnidad.split(",");
						short cant = 0;
						for (String unidad : aOrdenCapturaUnidad) {
							if (orderByUnidades.length() <= 0) {
								orderByUnidades = "order by CASE ";
							}
							orderByUnidades += "WHEN ProductoDetalle.PRUTipoUnidad = " + unidad + " THEN " + cant + " ";
							cant += 1;
						}
						if (orderByUnidades.length() > 0) {
							//Se dejan hasta el final las unidades no configuradas
							orderByUnidades += " ELSE 20 END ";
						}
					} else {
						orderByUnidades = "order by ProductoUnidad.TipoEstado ";
					}
				} catch (Exception ex) {
					throw new Exception("Error al obtener parámetro OrdenCapturaUnidad ");
				}
				//orderBy = ""
			} else {
				estados = "1";
			}

			consulta.append("SELECT distinct ProductoDetalle.PRUTipoUnidad as _id, ProductoDetalle.PRUTipoUnidad as PRUTipoUnidad, ProductoDetalle.Factor as Factor, ");
			consulta.append("ProductoUnidad.TipoEstado as TipoEstado, IFNULL(ProductoUnidad.DecimalProducto,0) as DecimalProducto, ProductoUnidad.KgLts as KgLts, ");
			consulta.append("ProductoUnidad.PorcentajeVariacion as PorcentajeVariacion, ProductoUnidad.ValorPuntos ");
			consulta.append("FROM ProductoDetalle ");
			consulta.append("INNER JOIN ProductoUnidad ON ProductoUnidad.ProductoClave = ProductoDetalle.ProductoClave AND ProductoUnidad.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad and ProductoUnidad.TipoEstado in(" + estados + " ) ");
			consulta.append("AND ProductoDetalle.ProductoDetClave = '" + productoClave + "' AND ProductoDetalle.Productoclave='" + productoClave + "' ");
			/*if (capturarContenedor){
				consulta.append(" AND not ProductoUnidad.Contenedor is null ");
			}*/
			if (esCanje)
				consulta.append("AND ProductoUnidad.ValorPuntos > 0 ");
			if (listaPrecios != null && listaPrecios.length() > 0) {
				consulta.append("LEFT JOIN PrecioProductoVig PPV on PPV.ProductoClave = ProductoDetalle.ProductoClave and PPV.ProductoClave = ProductoDetalle.ProductoDetClave and PPV.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad and PPV.PrecioClave in(" + listaPrecios + ") and ");
				consulta.append("DATETIME('now') between PPV.PPVFechaInicio and PPV.FechaFin  ");
				if (!manejoDobleUnidad) {
					if (capturarContenedor) {
						consulta.append(" order by Case when ProductoUnidad.Contenedor is null Then 1 Else 0 End, ProductoDetalle.Factor ");
					} else {
						consulta.append(" order by Case when PPV.PrecioClave is null Then 1 Else 0 End, ProductoDetalle.Factor ");
					}
				}
			}
			if (manejoDobleUnidad) {
				consulta.append(orderByUnidades);
			}
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerUnidadesProductoDifen(String productoClave, int tipoUnidad) throws Exception {
			StringBuilder consulta = new StringBuilder();

			consulta.append("SELECT ProductoDetalle.PRUTipoUnidad as _id, ProductoDetalle.PRUTipoUnidad, ProductoDetalle.Factor FROM ProductoDetalle ");
			consulta.append("INNER JOIN ProductoUnidad ON ProductoUnidad.ProductoClave = ProductoDetalle.ProductoClave AND ProductoUnidad.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad ");
			consulta.append("AND ProductoDetalle.ProductoDetClave = '" + productoClave + "' AND ProductoDetalle.Productoclave='" + productoClave + "' ");
			consulta.append("Where ProductoDetalle.PRUTipoUnidad = '" + tipoUnidad + "' ");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerTransDetalleid(String TransPordID) throws Exception {
			StringBuilder consulta = new StringBuilder();

			consulta.append("Select TransProdDetalleID From TransProdDetalle Where TransProdID='" + TransPordID + "'");

			return BDVend.consultar(consulta.toString());
		}

		public static int obtenerUnidadMinima(String productoClave) throws Exception {
			StringBuilder consulta = new StringBuilder();
			consulta.append("select PRUTipoUnidad ");
			consulta.append("from ProductoDetalle ");
			consulta.append("where ProductoClave = ProductoDetClave and ProductoClave = '" + productoClave + "' ");
			consulta.append("order by Factor ");
			consulta.append("limit 1 ");

			return BDVend.bd.ejecutarEscalarInteger(consulta.toString());
		}

		public static Producto obtenerProductoIdentico(String cadenaBusqueda) throws Exception {
			ISetDatos setDatos = BDVend.consultar(Producto.class, new String[]{}, "(UPPER(ProductoClave) = UPPER(?) or UPPER(Id) = UPPER(?))", new Object[]
					{cadenaBusqueda, cadenaBusqueda});
			Producto producto = null;
			if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
				producto = (Producto) BDVend.instanciar(Producto.class, setDatos);
				setDatos.close();
				return producto;
			}
			setDatos.close();
			return null;
		}


		public static ISetDatos buscarCodigoBarras(String codigoBarras, String listasPrecios) throws Exception {
			StringBuilder consulta = new StringBuilder();

			consulta.append("SELECT distinct ProductoDetalle.PRUTipoUnidad as _id, ProductoDetalle.PRUTipoUnidad, ProductoDetalle.Factor, ProductoDetalle.ProductoClave, Producto.NombreLargo ");
			consulta.append("FROM ProductoDetalle ");
			consulta.append("INNER JOIN Producto ON ProductoUnidad.ProductoClave = Producto.ProductoClave ");
			consulta.append("INNER JOIN ProductoUnidad ON ProductoUnidad.ProductoClave = ProductoDetalle.ProductoClave AND ProductoUnidad.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad and ProductoUnidad.ProductoClave = ProductoDetalle.ProductoDetClave ");
			consulta.append("AND ProductoUnidad.CodigoBarras = '" + codigoBarras + "' AND ProductoUnidad.TipoEstado = 1 ");
			if (listasPrecios != null && listasPrecios.length() > 0) {
				consulta.append("LEFT JOIN PrecioProductoVig PPV on PPV.ProductoClave = ProductoDetalle.ProductoClave and PPV.ProductoClave = ProductoDetalle.ProductoDetClave and PPV.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad and PPV.PrecioClave in(" + listasPrecios + ") and ");
				consulta.append("DATETIME('now') between PPV.PPVFechaInicio and PPV.FechaFin order by Case when PPV.PrecioClave is null Then 1 Else 0 End, ProductoDetalle.Factor ");
			}
			return BDVend.consultar(consulta.toString());
		}

		public static boolean existeCodigoBarras(String codigoBarras) throws Exception {
			boolean resultado = false;
			ISetDatos datos = BDVend.consultar("Select * from ProductoUnidad where CodigoBarras = '" + codigoBarras + "'");
			if (datos.moveToNext()) {
				resultado = true;
			}
			datos.close();

			return resultado;
		}

		public static boolean codigoBarrasRepetido(String codigoBarras) throws Exception {
			int resultado = 0;
			ISetDatos datos = BDVend.consultar("Select count(*) as Cantidad from ProductoUnidad where CodigoBarras = '" + codigoBarras + "'");
			if (datos.moveToNext()) {
				resultado = datos.getInt("Cantidad");
			}
			datos.close();

			return (resultado > 1);
		}

		public static Cursor obtenerProductosExistencia(String filtro, String listasPrecios, boolean filtrarProductos, String transProdIds, int tipoTransProd, boolean validarExistencia, int tipoMovimiento, String esquemasModulo, int ubicacionExistencia, boolean excluirCanjes) throws Exception
		{

			ArrayList<Cursor> cursores = new ArrayList<Cursor>();
			int limit = 0;
			int rows = 100000;

			boolean aplicarFiltrosPrecio = filtrarProductos;
			boolean aplicarFiltrosExistencia = filtrarProductos;
			boolean filtrarContenedor = false;
			boolean calcularKardexUnidad = false;

			if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("CalcularKardexUnidad")) {
				if (tipoTransProd == TiposTransProd.DESCARGAS && ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("CalcularKardexUnidad").toString().equals("1")) {
					calcularKardexUnidad = true;
				}
			}

			while (limit + 6000 < rows)
			{
				StringBuilder consulta = new StringBuilder();

				//if (tipoTransProd == TiposTransProd.CAMBIOS || tipoTransProd == TiposTransProd.DEVOLUCIONES_CLIENTE || tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES || tipoTransProd == TiposTransProd.MOV_SIN_INV_SV || tipoTransProd == TiposTransProd.DESCARGAS)
				if (tipoTransProd == TiposTransProd.CAMBIOS || tipoTransProd == TiposTransProd.DEVOLUCIONES_CLIENTE || tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES || tipoTransProd == TiposTransProd.MOV_SIN_INV_SV || tipoTransProd == TiposTransProd.DESCARGAS || tipoTransProd == TiposTransProd.CARGAS)
				{
                    if (tipoTransProd != TiposTransProd.CAMBIOS && tipoTransProd != TiposTransProd.DEVOLUCIONES_CLIENTE)
					    aplicarFiltrosPrecio = false;

					if (tipoTransProd == TiposTransProd.CARGAS && ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("CapturarUnidadesConContenedor")) {
						if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("CapturarUnidadesConContenedor").equals("1")){
							filtrarContenedor =true;
						}
					}


					if (tipoMovimiento ==TiposMovimientos.ENTRADA ){
						aplicarFiltrosExistencia = false;
					}else{
						aplicarFiltrosExistencia = validarExistencia;						
					}
				}else if (tipoTransProd == TiposTransProd.MOV_SIN_INV_EV){
					aplicarFiltrosExistencia = false;
				}

				consulta.append("select distinct PRO.ProductoClave as _id, PRO.DecimalProducto, PRO.ProductoClave,PRO.Nombre,PRO.NombreLargo,case when PRO.Id is null then '' else PRO.Id end as Id, ");
				if (tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES)
					consulta.append("case when INV.Disponible is null then 0 else (INV.NoDisponible)/PDE.Factor end as Existencia, ");
				else if (tipoTransProd == TiposTransProd.NO_DEFINIDO && ubicacionExistencia != 0){
					String ubicacion = "";
					if(ubicacionExistencia == 1){
						ubicacion = "INV.Disponible";
					}else if (ubicacionExistencia == 2){
						ubicacion = "INV.NoDisponible";
					}
					consulta.append("case when "+ubicacion+" is null then 0 else ("+ubicacion+")/PDE.Factor end as Existencia, ");
				}
                else if (tipoTransProd == TiposTransProd.DESCARGAS && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) {
					if (calcularKardexUnidad)
						consulta.append("sum(case when KDU.EntradaDisponible is null then 0 else (KDU.EntradaDisponible-KDU.Salida-KDU.EntradaNoDisponible) * PDE.Factor end) as Existencia, ");
					else
						consulta.append("case when INV.Disponible is null then 0 else (INV.Disponible-INV.NoDisponible-INV.Contenido)/PDE.Factor end as Existencia, ");
				}
				else {
					if (tipoTransProd == TiposTransProd.DESCARGAS && calcularKardexUnidad)
						consulta.append("sum(case when KDU.EntradaDisponible is null then 0 else (KDU.EntradaDisponible-KDU.Salida-KDU.EntradaNoDisponible) * PDE.Factor end) as Existencia, ");
					else
						consulta.append("case when INV.Disponible is null then 0 else (INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido)/PDE.Factor end as Existencia, ");
				}

				if (calcularKardexUnidad)
					consulta.append("(select PRUTipoUnidad from ProductoDetalle PRD where PRU.ProductoClave = PRD.ProductoClave order by Factor limit 1) as Unidad, ");
				else
					consulta.append("PRU.PRUTipoUnidad as Unidad, ");

				if (!listasPrecios.equals(""))
					consulta.append("PPV.Precio as Precio,PPV.PrecioSugerido, PPV.Precioclave as PrecioClave ");
				else
					consulta.append("null as Precio,null as PrecioSugerido, null as PrecioClave ");

                consulta.append(", 0 as checked, 0 as Cantidad, PRO.Tipo as TipoProducto ");

				if ((tipoTransProd == Enumeradores.TiposTransProd.PEDIDO || tipoTransProd == Enumeradores.TiposTransProd.VENTA_CONSIGNACION) && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.PREVENTA)
					if(((Cliente)Sesion.get(Campo.ClienteActual)).Prestamo){
						consulta.append(", case when PRO.Contenido and PRO.Venta then ifnull(PPC.Saldo, 0) else '' end as SaldoEnvase, PRU.ValorPuntos ");
					}else{
						consulta.append(", null as SaldoEnvase, PRU.ValorPuntos ");
					}
				else
					consulta.append(", null as SaldoEnvase, PRU.ValorPuntos ");

                consulta.append("from producto PRO ");
                consulta.append("inner join productounidad PRU on PRO.ProductoClave = PRU.ProductoClave and PRU.TipoEstado in(1,3) ");
				if (filtrarContenedor) {
					consulta.append(" and not PRU.Contenedor is null ");
				}
                consulta.append("inner join ProductoEsquema PES on PES.ProductoClave = PRO.ProductoClave ");
                consulta.append("inner join ProductoDetalle PDE on PRO.ProductoClave = PDE.ProductoClave and PRU.PRUTipoUnidad = PDE.PRUTipoUnidad and PRO.ProductoClave = PDE.ProductoDetClave  ");
				if (!filtrarContenedor && !calcularKardexUnidad) {
					if (!listasPrecios.equals(""))
						consulta.append("and PDE.Factor= (Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave in (" + listasPrecios + "))");
					else
						consulta.append("and PDE.Factor= (Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave)");
				}
					//consulta.append((aplicarFiltrosPrecio ? "(Select min(PDE2.factor) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave = '" + PrecioClave + "')" : "1 "));
				if (calcularKardexUnidad)
					consulta.append("left join KardexUnidad KDU on PRU.ProductoClave = KDU.ProductoClave AND PRU.PRUTipoUnidad = KDU.PRUTipoUnidad ");
				else
					consulta.append("left join Inventario INV on PRO.ProductoClave = INV.ProductoClave AND INV.AlmacenID = '" + ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID + "'");

				if (!listasPrecios.equals(""))
				{
					consulta.append("left join PrecioProductoVig PPV on PPV.ProductoClave = PRO.ProductoClave and PPV.PRUTipoUnidad = PRU.PRUTipoUnidad ");
					if (listasPrecios.contains(",")){ //Si la cadena contiene mas de una lista de precios
						consulta.append(" and PPV.PrecioClave = (Select  PRE2.PrecioClave from PrecioProductoVig PPV3 inner join Precio PRE2 on PRE2.PrecioClave = PPV3.PrecioClave where  PPV3.ProductoClave = PRO.ProductoClave and PPV3.PRUTipoUnidad = PRU.PRUTipoUnidad and PPV3.PrecioClave in(" + listasPrecios + ")  order by PRE2.Jerarquia asc LIMIT 1 ) ");
					}
				}
				consulta.append("left join TransProdDetalle TPD on TPD.TransProdId in(" + transProdIds + ") and TPD.ProductoClave = PRO.ProductoClave ");

				if ((tipoTransProd == Enumeradores.TiposTransProd.PEDIDO || tipoTransProd == Enumeradores.TiposTransProd.VENTA_CONSIGNACION) && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.PREVENTA)
                    consulta.append("left join ProductoPrestamoCli PPC on PPC.ProductoClave = PRO.ProductoClave and PPC.ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' ");

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

				if (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO  && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO &&
					((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("SoloVentaEnvase").equals("1")){
					consulta.append(" AND PRO.Contenido = 1 AND PRO.Venta = 1 ");
				}

                if(tipoTransProd == TiposTransProd.CANJES)
                    consulta.append(" AND PRO.Tipo in (2, 3) and PRU.ValorPuntos > 0 ");
                else if (excluirCanjes)
                    consulta.append(" AND PRO.Tipo <> 2 ");

				if (aplicarFiltrosExistencia && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.PREVENTA) {
					if (tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES)
						consulta.append(" GROUP BY PRO.ProductoClave HAVING ((INV.NoDisponible)/PDE.Factor)>0 ");
					else if (tipoTransProd == TiposTransProd.DESCARGAS && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) {
						if (calcularKardexUnidad)
							consulta.append(" GROUP BY PRO.ProductoClave HAVING sum(KDU.EntradaDisponible-KDU.Salida-KDU.EntradaNoDisponible)>0 ");
						else
							consulta.append(" GROUP BY PRO.ProductoClave HAVING ((INV.Disponible-INV.NoDisponible-INV.Contenido)/PDE.Factor)>0 ");
					}else {
						if (tipoTransProd == TiposTransProd.DESCARGAS && calcularKardexUnidad)
							consulta.append(" GROUP BY PRO.ProductoClave HAVING sum(KDU.EntradaDisponible-KDU.Salida-KDU.EntradaNoDisponible)>0 ");
						else
							consulta.append(" GROUP BY PRO.ProductoClave HAVING ((INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido)/PDE.Factor)>0 ");
					}
				}

				if (aplicarFiltrosPrecio && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
					consulta.append(" AND not PPV.Precio is null ");

				if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("OrdenBusqProducto").length()>0)
					consulta.append("ORDER BY " + ((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("OrdenBusqProducto") );
				else
					consulta.append("ORDER BY PRO.ProductoClave ");

				
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

		public static Cursor obtenerProductosExistenciaDobleUnidad(String filtro, String listasPrecios, boolean filtrarProductos, String transProdIds, int tipoTransProd, boolean validarExistencia, int tipoMovimiento, String esquemasModulo, int ubicacionExistencia, boolean excluirCanjes) throws Exception
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
					consulta.append("select distinct PRO.ProductoClave as _id, PRO.DecimalProducto, PRO.ProductoClave,PRO.Nombre,PRO.NombreLargo,case when PRO.Id is null then '' else PRO.Id end as Id,case when INV.Disponible is null then 0 else (INV.NoDisponible) end as Existencia, ");
				else if (tipoTransProd == TiposTransProd.NO_DEFINIDO && ubicacionExistencia != 0){
					String ubicacion = "";
					if(ubicacionExistencia == 1){
						ubicacion = "INV.Disponible";
					}else if (ubicacionExistencia == 2){
						ubicacion = "INV.NoDisponible";
					}
					consulta.append("select distinct PRO.ProductoClave as _id, PRO.DecimalProducto, PRO.ProductoClave,PRO.Nombre,PRO.NombreLargo,case when PRO.Id is null then '' else PRO.Id end as Id,case when "+ubicacion+" is null then 0 else ("+ubicacion+") end as Existencia, ");
				}
                else if (tipoTransProd == TiposTransProd.DESCARGAS && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO)
                    consulta.append("select distinct PRO.ProductoClave as _id, PRO.DecimalProducto, PRO.ProductoClave,PRO.Nombre,PRO.NombreLargo,case when PRO.Id is null then '' else PRO.Id end as Id,case when INV.Disponible is null then 0 else round(INV.Disponible-INV.NoDisponible-INV.Contenido, PRU.DecimalProducto) end as Existencia, ");
				else
					consulta.append("select distinct PRO.ProductoClave as _id, PRO.DecimalProducto, PRO.ProductoClave,PRO.Nombre,PRO.NombreLargo,case when PRO.Id is null then '' else PRO.Id end as Id,case when INV.Disponible is null then 0 else round(INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido, PRU.DecimalProducto) end as Existencia, ");
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
				consulta.append(", 0 as checked, 0 as Cantidad, PRO.Tipo as TipoProducto,'' as SaldoEnvase, PRU.ValorPuntos from producto PRO inner join productounidad PRU on PRO.ProductoClave = PRU.ProductoClave and PRU.TipoEstado =1 ");
				consulta.append("inner join ProductoEsquema PES on PES.ProductoClave = PRO.ProductoClave inner join ProductoDetalle PDE on PRO.ProductoClave = PDE.ProductoClave and PRU.PRUTipoUnidad = PDE.PRUTipoUnidad and PRO.ProductoClave = PDE.ProductoDetClave and PDE.Factor= ");
				consulta.append("(Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave in (" + listasPrecios + "))");
				//consulta.append((aplicarFiltrosPrecio ? "(Select min(PDE2.factor) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave = '" + PrecioClave + "')" : "1 "));
				consulta.append("left join InventarioUnidadesAlternas INV on PRO.ProductoClave = INV.ProductoClave  and INV.PRUTipoUnidad = PRU.PRUTipoUnidad ");
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

				if (excluirCanjes){
					//Excluir los productos Tipo = Canje (2)
					consulta.append(" AND PRO.Tipo <>2 ");
				}

				if (aplicarFiltrosExistencia && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.PREVENTA)
					if (tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES)
						consulta.append(" GROUP BY PRO.ProductoClave HAVING ((INV.NoDisponible))>0 ");
					else
						consulta.append(" GROUP BY PRO.ProductoClave HAVING ((INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido))>0 ");
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

		public static ISetDatos obtenerProductoDetalle(String productoClave, int tipoUnidad) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT ProductoDetalle.ProductoClave, ProductoDetalle.ProductoDetClave, ProductoDetalle.Factor FROM ProductoDetalle ");
			consulta.append("WHERE ProductoDetalle.ProductoClave='" + productoClave + "' and ProductoDetalle.PRUTipoUnidad=" + tipoUnidad);
			return BDVend.consultar(consulta.toString());
		}
		
		public static ProductoCalculadora obtenerProductoCalculaPorKilo(String productoClave, int unidad) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT P.ProductoClave, PU.PRUTipoUnidad, PU.KgLts, ifnull(PV.Precio, 0) as Precio ");
            consulta.append("FROM Producto as P ");
			consulta.append("INNER JOIN ProductoUnidad as PU ON PU.ProductoClave = P.ProductoClave ");
			consulta.append("LEFT JOIN PrecioProductoVig as PV ON PV.ProductoClave = P.ProductoClave ");
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

        public static String obtenerExcepcionSubEmpresaID(String productoClave, String clienteClave)
        {
            try {
                StringBuilder consulta = new StringBuilder();
                consulta.append("select  ifnull(SubEmpresaId, '') as SubEmpresaId ");
                consulta.append("from ExcepcionFac EXF ");
                consulta.append("inner join ProductoEsquema PES on EXF.EsquemaId = PES.EsquemaID ");
                consulta.append("where ClienteClave = '" + clienteClave + "' and ProductoClave = '" + productoClave + "' ");
                consulta.append("limit 1 ");

                return BDVend.bd.ejecutarEscalar(consulta.toString());
            }catch (Exception e)
            {
                return "";
            }
        }
	}

	public static final class ConsultasPrecioClienteEsquema
	{

		public static ISetDatos obtenerIdEsquemaCte(String ModuloMovDetalleClave, Short iCFVTipo)
		{
			try
			{
				if (iCFVTipo != null && iCFVTipo >0)
					return BDVend.consultar("SELECT EsquemaID, ModuloMovDetalleClave, PrecioClienteEsquema.PrecioClave FROM PrecioClienteEsquema inner join Precio on Precio.PrecioCLave = PrecioClienteEsquema.PrecioClave and Precio.CFVTipo = " + iCFVTipo.toString() + " WHERE ModuloMovDetalleClave='" + ModuloMovDetalleClave + "' and Precio.TipoEstado = 1 ");
				else
					return BDVend.consultar("SELECT EsquemaID, ModuloMovDetalleClave, PrecioClienteEsquema.PrecioClave FROM PrecioClienteEsquema inner join Precio on Precio.PrecioCLave = PrecioClienteEsquema.PrecioClave WHERE ModuloMovDetalleClave='" + ModuloMovDetalleClave + "' and Precio.TipoEstado = 1 ");

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


		public static float obtenerPrecioProducto(String ProductoClave, short TipoUnidad, String listasPrecios, StringBuilder precioClave, float Cantidad)
		{
			try
			{
				Date fechaActual = Generales.getFechaActual();
				float precio = -1;
				String Consulta = "SELECT IFNULL(PrecioEscala.Precio, PrecioProductoVig.Precio) as Precio,  Precio.PrecioClave as PrecioClave FROM PrecioProductoVig INNER JOIN Precio ON PrecioProductoVig.PrecioClave = Precio.PrecioClave ";
				Consulta += " LEFT JOIN PrecioEscala ON PrecioProductoVig.PPVId = PrecioEscala.PPVId and  PrecioEscala.RangoInicial = (Select RangoInicial from PrecioEscala PE where PE.PPVId =  PrecioProductoVig.PPVId ";
				Consulta += " and " + Cantidad + ">=RangoInicial order by RangoInicial desc Limit 1) ";
				Consulta += " WHERE PrecioProductoVig.PrecioClave in(" + listasPrecios + ") ";
				//Consulta += " AND '" + Generales.getUltimaHora(fechaActual) + "'>=PPVFechaInicio AND '" + Generales.getPrimerHora(fechaActual) + "'<=FechaFin
				Consulta += " AND datetime('now') BETWEEN PrecioProductoVig.PPVFechaInicio AND PrecioProductoVig.FechaFin ";
				Consulta += " AND Precio.TipoEstado= 1 AND PrecioProductoVig.ProductoClave = '" + ProductoClave + "' and PrecioProductoVig.PRUTipoUnidad = " + Short.toString(TipoUnidad);
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
		public static ISetDatos obtenerEncuestasCte(String sClienteClave) throws Exception
		{
			return BDVend.consultar("SELECT CENClave, Puntos, IniAplicacion, FinAplicacion FROM CENCli where ClienteClave='" + sClienteClave + "' ");
		}
	}

	public static final class ConsultasImpresionTicket
	{
		public static ISetDatos obtenerEncabezado() throws Exception{
			return BDTerm.consultar("SELECT NombreEmpresa,Calle, RFC, Numero, Colonia, Ciudad, Region, Telefono FROM Configuracion");
		}

		public static ISetDatos obtenerEncabezado2() throws Exception{
			return BDTerm.consultar("SELECT NombreEmpresa,Calle, RFC, Numero, Colonia, Ciudad, Region, Telefono, CodigoPostal FROM Configuracion");
		}

        public static ISetDatos obtenerEncabezado(String subEmpresaId) throws Exception{
            return BDVend.consultar("SELECT NombreEmpresa,Calle, RFC, Numero, Colonia, Ciudad, Region, Telefono, NumeroInterior, CodigoPostal FROM SubEmpresa where SubEmpresaID='" + subEmpresaId + "'");
        }

		public static ISetDatos obtenerEncabezado2(String subEmpresaId) throws Exception{
			return BDVend.consultar("SELECT NombreEmpresa,Calle,Localidad, RFC, Numero, Colonia, Ciudad, Region, Telefono, NumeroInterior, CodigoPostal FROM SubEmpresa where SubEmpresaID='" + subEmpresaId + "'");
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
            else if (nombreTabla.equalsIgnoreCase("TransProd") && tipoRecibo == 26)
            {
                if (nombreCampo.equalsIgnoreCase("TotalLiquidar"))
                    sb.append("select sum(TransProdDetalle.Total - ifnull(TrpTpd.Total,0)) as TotalLiquidar ");
                else if(nombreCampo.equalsIgnoreCase("TotalDevolucion"))
                    sb.append("select ifnull(sum(ifnull(TrpTpd.Total, 0)), 0) as TotalDevolucion ");
                else
                    sb.append("Select " + nombreCampo + ", typeof(" + nombreCampo + ")");
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
                else if (tipoRecibo == 26)
                {
                    if (nombreCampo.equalsIgnoreCase("TotalLiquidar") ||  nombreCampo.equalsIgnoreCase("TotalDevolucion"))
                    {
                        sb.append(" inner join TransProdDetalle on TransProd.TransProdID = TransProdDetalle.TransProdID ");
                        sb.append("left join TrpTpd on TransProdDetalle.TransProdID = TrpTpd.TransProdID1 and TransProdDetalle.TransProdDetalleID = TrpTpd.TransProdDetalleID ");
                        sb.append("where TransProd.TransProdID = '" + id + "'");
                    }
                    else
                        sb.append(" where TransProdId ='" + id + "'");
                }
				else
				{
					sb.append(" where TransProdId ='" + id + "'");
				}
			}
			else if (nombreTabla.equalsIgnoreCase("TRPDatoFiscal") || nombreTabla.equalsIgnoreCase("TrpVtaAcreditada"))
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
                else if (tipoCampo == 1){
                    try {
                        valorRes = Generales.getFormatoDecimal((Float) BDVend.getBD().ejecutarEscalarObject(sb.toString()), 2);
                    }catch(Exception e){
                        valorRes = BDVend.getBD().ejecutarEscalar(sb.toString());
                    }
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
				sConsulta.append("inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and TPD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ");
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
                sConsulta.append("inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and TPD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ");
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
                    campos = campos.replace("TrpTpd.Devolucion", "ifnull(TrpTpd.Cantidad, 0) as Devolucion");
                    campos = campos.replace("TrpTpd.NombreProducto", "Producto.Nombre as NombreProducto");
                    campos = campos.replace("TrpTpd.ClaveProducto", "TransProdDetalle.ProductoClave as ClaveProducto");
                    campos = campos.replace("TransProdDetalle.Liquidar", "TransProdDetalle.Cantidad - ifnull(TrpTpd.Cantidad, 0) as Liquidar");
                    campos = campos.replace("TransProdDetalle.Importe", "TransProdDetalle.Total / TransProdDetalle.Cantidad as Importe");
                    campos = campos.replace("TransProdDetalle.SubTotal", "TransProdDetalle.Subtotal - ifnull(TrpTpd.Subtotal, 0) as SubTotal");

                    consulta.append("Select ");
                    consulta.append(campos);
                    consulta.append(" from TransProdDetalle ");
                    consulta.append("inner join Producto on TransProdDetalle.ProductoClave = Producto.ProductoClave ");
                    consulta.append("left join TrpTpd on TransProdDetalle.TransProdID = TrpTpd.TransProdID1 and TransProdDetalle.TransProdDetalleID = TrpTpd.TransProdDetalleID ");
                    consulta.append("where TransProdDetalle.TransProdID = '").append(id).append("' ");
				}
				else if (tipo == 1 || tipo == 24 || tipo == 19 || tipo == 21)
				{ // Pedido, Consignacion, Mov sin Inv s/Visita, MovSinInv
					// c/Visita
					campos = campos.toUpperCase().replace("TRANSPRODDETALLE.IMPORTE", "ifnull((TransProdDetalle.Total/TransProdDetalle.Cantidad),0.0) as Importe ");
					campos = campos.toUpperCase().replace("TRANSPRODDETALLE.DESCUENTOIMP", "ifnull(TransProdDetalle.DescuentoImp, 0) as DescuentoImp ");
					campos = campos.toUpperCase().replace("TRANSPRODDETALLE.PRECIO", "TransProdDetalle.Precio - (SELECT ifnull(SUM(TProm.PromocionImp/TransProdDetalle.Cantidad),0) FROM TrpPrp TProm WHERE TProm.TransProdID = TransProdDetalle.TransProdID and TProm.TransProdDetalleID = TransProdDetalle.TransProdDetalleID) as Precio ");
					consulta.append("Select ");
					consulta.append(campos);
					consulta.append(" from ");
					consulta.append(tabla);
					if (tabla.toUpperCase().contains("TPDDATOSEXTRA") && tabla.toUpperCase().contains("TRANSPRODDETALLE")){
						consulta.append(" where TRANSPRODDETALLE." + campoLlave + " = '" + id + "'");
					}else{
						consulta.append(" where " + campoLlave + " = '" + id + "'");
					}

					if(seccionProdPromo){
						consulta.append("and (promocion != 2 or promocion is null)");
					}
				}
                /*else if (tipo == 5){ // Canjes
                    campos = campos.toUpperCase().replace("TRANSPRODDETALLE.TOTAL", "(TransProdDetalle.Cantidad * ProductoUnidad.ValorPuntos) as Total ");
                    consulta.append("Select ");
                    consulta.append(campos);
                    consulta.append(" from ");
                    consulta.append(tabla);
                    consulta.append(" where " + campoLlave + " = '" + id + "'");
                }*/
				else
				{
					consulta.append("Select ");
					consulta.append(campos);
					consulta.append(" from ");
					consulta.append(tabla);
					if (tabla.toUpperCase().contains("TPDDATOSEXTRA") && tabla.toUpperCase().contains("TRANSPRODDETALLE")){
						consulta.append(" where TRANSPRODDETALLE." + campoLlave + " = '" + id + "'");
					}else{
						consulta.append(" where " + campoLlave + " = '" + id + "'");
					}
				}

				if (campos.toUpperCase().contains("PRODUCTO.NOMBRE") && !(campos.toUpperCase().contains("TRPTPD") && tipo == 24))
				{
					consulta.append(" and Producto.ProductoClave = TransProdDetalle.ProductoClave ");
				}

				if (campos.toUpperCase().contains("TPDDATOSEXTRA.UNIDADALTERNA") || campos.toUpperCase().contains("TPDDATOSEXTRA.CANTIDADALTERNA"))
				{
					consulta.append(" and TPDDatosExtra.TransProdID = TransProdDetalle.TransProdID and TPDDatosExtra.TransProdDetalleID = TransProdDetalle.TransProdDetalleID  ");
				}

                if (tabla.toUpperCase().contains("TRANSPRODDETALLE") && tabla.toUpperCase().contains("PRODUCTOUNIDAD")){
                    consulta.append("and TransProdDetalle.ProductoClave = ProductoUnidad.ProductoClave and TransProdDetalle.TipoUnidad = ProductoUnidad.PRUTipoUnidad ");
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
                        if (tipo == 24 && tabla.toUpperCase().contains("TRPTPD")) {
                            if (campoOrden.toUpperCase().equals("DEVOLUCION"))
                                campoOrden = "Cantidad";
                            else if (campoOrden.toUpperCase().equals("NOMBREPRODUCTO")) {
                                tablaOrden = "Producto";
                                campoOrden = "Nombre";
                            } else if (campoOrden.toUpperCase().equals("CLAVEPRODUCTO")) {
                                tablaOrden = "TransProdDetalle";
                                campoOrden = "ProductoClave";
                            } else if (campoOrden.toUpperCase().equals("LIQUIDAR"))
                                campoOrden = "Cantidad";
                        }

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
                consulta.append("where td.TransProdId = '" + transprodId + "' and td.Promocion in(2,3) ");
                return  BDVend.consultar(consulta.toString());
            }catch(Exception e){
                e.printStackTrace();
                return null;
            }
        }

        public static ISetDatos obtenerPendientesGenerarPDF(){
            try{
                StringBuilder sConsulta = new StringBuilder();

                sConsulta.append("Select TransProd.TransProdId as _Id, TransProd.Tipo as Tipo, 'TRPTIPO' as VARCodigo,'TRP' as TipoRecibo, TransProd.Folio as Folio, '' as DescTipo,strftime( '%d/%m/%Y', CASE WHEN TransProd.Tipo = 8 THEN TransProd.FechaFacturacion ELSE TransProd.FechaCaptura END) as Fecha, TransProd.Total as Total, TransProd.TipoFase as TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as DiaClave, TransProd.SubEmpresaID as SubEmpresaID, IFNull( TDF.TransProdId, 0) as FacElec ");
                sConsulta.append("From TransProd ");
                sConsulta.append("LEFT JOIN Visita ON TransProd.VisitaClave = Visita.VisitaClave ");
                sConsulta.append("LEFT JOIN TRPDatoFiscal TDF on TDF.TransProdId = TransProd.TransProdId ");
                sConsulta.append("INNER JOIN EnvioPendientePDF PDF on TransProd.TransProdID = PDF.TransProdID ");
                sConsulta.append("WHERE PDF.Archivo IS NULL ");
                sConsulta.append("UNION ");
                sConsulta.append("Select TransProd.TransProdId as _Id, TransProd.Tipo as Tipo, 'TRPTIPO' as VARCodigo, 'TRP' as TipoRecibo, TransProd.Folio as Folio, '' as DescTipo, strftime( '%d/%m/%Y',CASE WHEN TransProd.Tipo = 8 THEN TransProd.FechaFacturacion ELSE TransProd.FechaCaptura END) as Fecha, TransProd.Total as Total, TransProd.TipoFase as TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as DiaClave, TransProd.SubEmpresaID as SubEmpresaID, 0 as FacElec ");
                sConsulta.append("From TransProd ");
                sConsulta.append("INNER JOIN Visita ON TransProd.VisitaClave1 = Visita.VisitaClave AND TransProd.DiaClave1 = Visita.DiaClave and TransProd.Tipofase <> 0 ");
                sConsulta.append("INNER JOIN EnvioPendientePDF PDF on TransProd.TransProdID = PDF.TransProdID ");
                sConsulta.append("WHERE PDF.Archivo IS NULL ");
                sConsulta.append("UNION ");
                sConsulta.append("select Abono.ABNId as _Id, 10 as Tipo, 'TRECIBO' as VARCodigo,  'ABN' as TipoRecibo, Abono.Folio as Folio ,'' as DescTipo, strftime( '%d/%m/%Y',FechaAbono) as Fecha, Abono.Total as Total, null as TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as DiaClave, '' as SubEmpresaID , 0 as FacElec ");
                sConsulta.append("from Abono ");
                sConsulta.append("inner join Visita on Abono.visitaclave=Visita.visitaclave ");
                sConsulta.append("INNER JOIN EnvioPendientePDF PDF on Abono.ABNId = PDF.ABNId ");
                sConsulta.append("WHERE PDF.Archivo IS NULL ");

                return BDVend.consultar(sConsulta.toString());
            }
            catch (Exception ex)
            {
                ex.printStackTrace();
                return null;
            }
        }

        public static String diaClavesEnFrecuencia() throws Exception{
            ISetDatos dias = BDVend.consultar("select DiaClave from Dia where FueraFrecuencia=0");
            String DiasClaves="";
            while (dias.moveToNext()){
                DiasClaves += "'" + dias.getString("DiaClave") + "', ";
            }
            dias.close();
            return DiasClaves.substring(0,(DiasClaves.length()-2));
        }

		public static String obtenerCampoNotas(String sTabla, String sCampo, String sCampoClave, String sClave) {
			try
			{
				return BDVend.getBD().ejecutarEscalar("Select " + sCampo + " from " + sTabla + " where " + sCampoClave + " = '" + sClave + "' ");
			}
			catch (Exception ex)
			{
				ex.printStackTrace();
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

		public static ISetDatos obtenerCodigoBarras() throws Exception
		{

			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT ClienteClave, IFNULL(LENGTH(IdElectronico), 0) AS CodigoBarras FROM CLIENTE ");
			sConsulta.append("WHERE Cliente.Clave LIKE '" + ((Ruta)Sesion.get(Campo.RutaActual)).RUTClave + "%' AND FechaRegistroSistema BETWEEN ");
			sConsulta.append("'" + Generales.getPrimerHora(((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura) + "' ");
			sConsulta.append("AND '" + Generales.getUltimaHora(((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura) + "' ");

			return BDVend.consultar(sConsulta.toString());
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
			//consulta.append("select count(*) as Cantidad from CLICAP Where VisitaClave ='" + VisitaClave + "' or  VisitaClave1 ='" + VisitaClave + "' UNION ");
			consulta.append("select count(*) as Cantidad from AbnTrp Where VisitaClave ='" + VisitaClave + "' UNION ");
            consulta.append("select count(*) as Cantidad from ActivoClienteHist Where VisitaClave ='" + VisitaClave + "' ");

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

        public static boolean existenEncuestasSinAplicar(String diaClave, String clienteClave) throws Exception{

            String sEsquemasCte= Esquemas.ObtenerEsquemas(clienteClave, com.amesol.routelite.actividades.Enumeradores.Esquema.TipoEsquema.Cliente);

            StringBuilder consulta = new StringBuilder();
            consulta.append("select count(*) from ( ");
            consulta.append("   select distinct CenEsq.CENClave ");
            consulta.append("   from CenEsq ");
            consulta.append("   inner join ConfigEncuesta on CenEsq.CENClave = ConfigEncuesta.CENClave ");
            consulta.append("   where Obligatoria = 1 and EsquemaId in(" + sEsquemasCte + ") ");
            consulta.append("   union ");
            consulta.append("   select distinct CenCli.CENClave ");
            consulta.append("   from CenCli ");
            consulta.append("   inner join ConfigEncuesta on CenCli.CENClave = ConfigEncuesta.CENClave ");
            consulta.append("   where Obligatoria = 1 and ClienteClave = '" + clienteClave + "' ");
            consulta.append(") t where CENClave not in ( ");
            consulta.append("   select CENClave from Encuesta ");
            consulta.append("   inner join Visita on Encuesta.VisitaClave = Visita.VisitaClave ");
            consulta.append("   where Visita.DiaClave = '" + diaClave + "' and Visita.ClienteClave = '" + clienteClave + "' and Fase <> 0) ");
            return BDVend.getBD().ejecutarEscalarInteger(consulta.toString()) > 0;
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

		public static String horarioProgramado(String diaClave, String rutClave, String ClienteClave) throws Exception{
			StringBuilder consulta = new StringBuilder();
			String horarioProgramado = "NULL";
			consulta.append("SELECT HorarioVisita FROM Agenda ");
			consulta.append("WHERE DiaClave = '" +diaClave+ "' AND RUTClave = '" +rutClave+ "' ");
			consulta.append("AND ClienteClave = '" +ClienteClave+ "'");
			ISetDatos datos = BDVend.consultar(consulta.toString());

			if(datos.moveToFirst()){
				horarioProgramado = datos.getString("HorarioVisita");
				if(horarioProgramado == ""){
					horarioProgramado = null;
				}
			}
			return horarioProgramado;
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
            consulta.append("   and MMD.ModuloMovDetalleClave not in (select ModuloMovDetalleClave from ClienteMMDExcepcion where ClienteClave='" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "')");
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
            consulta.append("   and MMD.ModuloMovDetalleClave not in (select ModuloMovDetalleClave from ClienteMMDExcepcion where ClienteClave='" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "')");
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
			String Consula = "SELECT Impuesto.ImpuestoClave, Impuesto.Abreviatura, Impuesto.Jerarquia, Impuesto.TipoAplicacion, Impuesto.TipoValor, ImpuestoVig.Valor, Impuesto.ValidaRFC, ImpuestoVig.RedondeoDecimales FROM ProductoImpuesto ";
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
			String Consulta = "SELECT TransProdDetalle.TransProdID as TransProdID, TransProdDetalle.TransProdDetalleID as TransProdDetalleID,Impuesto.ImpuestoClave as ImpuestoClave,  Impuesto.Jerarquia as Jerarquia,  Impuesto.TipoValor as TipoValor, ImpuestoVig.RedondeoDecimales as RedondeoDecimales FROM Transprod";
			// Consula+=" INNER JOIN TransProdDetalle ON TransProdDetalle.TransProdDetalleID = TransProd.TransProdDetalleID and TransProdDetalle.TransProdID = TransProd.TransProdID";
			Consulta += " INNER JOIN TransProdDetalle ON TransProdDetalle.TransProdID = TransProd.TransProdID";
			Consulta += " INNER JOIN TPDImpuesto ON TransProdDetalle.TransProdDetalleID = TPDImpuesto.TransProdDetalleID and TransProdDetalle.TransProdID = TPDImpuesto.TransProdID";
			Consulta += " INNER JOIN Impuesto ON TPDImpuesto.ImpuestoClave = Impuesto.ImpuestoClave";
			Consulta += " INNER JOIN ImpuestoVig ON Impuesto.ImpuestoClave = ImpuestoVig.ImpuestoClave ";
			Consulta += " AND '" + Generales.getFormatoFecha(Generales.getFechaActual(), "yyyy-MM-dd'T'HH:mm:ss") + "'>=ImpuestoVig.FechaInicial AND '" + Generales.getFormatoFecha(Generales.getFechaActual(), "yyyy-MM-dd'T'HH:mm:ss") + "'<=ImpuestoVig.FechaFinal";
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

        public static void ActualizaImpDesGlb(String sTransprodId, String sTransprodDetalleId, String sImpuestoClave, float nImporte, short redondeoDecimales) throws Exception
        {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("update TPDImpuesto ");
			if (redondeoDecimales >0) {
				sConsulta.append("set ImpDesGlb=" + Generales.getRound(nImporte, redondeoDecimales) + " ");
			}else{
				sConsulta.append("set ImpDesGlb=" + nImporte + " ");
			}

            sConsulta.append("where TransprodID = '" + sTransprodId + "' and TransprodDetalleId = '" + sTransprodDetalleId + "' and ImpuestoClave = '" + sImpuestoClave + "'");
            BDVend.ejecutarComando(sConsulta.toString());
        }

		public static short ObtenerImpuestoClienteModelo(String clienteModelo) throws Exception
		{
			ISetDatos datos = BDVend.consultar("SELECT TipoImpuesto FROM Cliente WHERE Clave = '" + clienteModelo + "'");
			short res = 0;
			if (datos.moveToNext())
			{
				res = datos.getShort("TipoImpuesto");
			}
			datos.close();
			return res;
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
			consulta.append("SELECT CLI.Clave, CLI.RazonSocial, IFNULL(SUM(Saldo - ROUND(CASE WHEN TRCP.AbnChequePosfechado IS NULL THEN 0 ELSE TRCP.AbnChequePosfechado END, 2) + ");
			consulta.append("CASE WHEN CLI.ActualizaSaldoCheque = 0 THEN CASE WHEN TRC.AbnCheque IS NULL THEN 0 ELSE TRC.AbnCheque END ELSE 0 END), 0) AS SaldoEfectivo ");
			consulta.append("FROM TransProd TRP ");
			consulta.append("INNER JOIN Visita VIS ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
			consulta.append("INNER JOIN Cliente CLI ON VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("LEFT JOIN (SELECT TRPCheque.TransProdID, SUM(AbnCheque) AS AbnCheque FROM TRPCheque GROUP BY TRPCheque.TransProdID) TRC ON TRC.TransProdID = TRP.TransProdID ");
			consulta.append("LEFT JOIN (SELECT TransProdId, SUM(AbnChequePosfechado) AS AbnChequePosfechado FROM TRPCheque GROUP BY TransProdID) TRCP ON TRCP.TransProdID = TRP.TransProdID ");
			consulta.append("WHERE TRP.Saldo > 0 AND CLI.ClienteClave IN (" + clienteClaves + ") AND ");
			if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 0) //FACTURAS
				consulta.append("TRP.Tipo = 8 AND TRP.TipoFase <> 0 ");
			else if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 1) //VENTAS
				consulta.append("TRP.Tipo = 1 AND  TRP.TipoFase NOT IN (0, 1) ");
			else if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2) //AMBAS
				consulta.append("TRP.Tipo = (CASE WHEN CLI.TipoFiscal = 1 Then 1 Else 8 END) AND TRP.TipoFase <> 0 AND TRP.TipoFase <> (CASE WHEN CLI.TipoFiscal = 1 THEN 1 ELSE 0 END) ");
			consulta.append("ORDER BY CLI.Clave ASC ");

			return BDVend.consultar(consulta.toString());

		}
		public static ISetDatos obtenerDevolucionesCambiosGeneral(String diaClave, String tipos) throws Exception{
			if(tipos.equals("")){
				tipos = "'9','3'";
			}

			StringBuilder consulta = new StringBuilder();
			consulta.append("select group_concat(distinct t.Tipo) as 'tipoM', td.TipoMotivo,td.ProductoClave, p.Nombre,sum(pd.Factor*td.Cantidad) as 'Cant' from TransProd t  ")
					.append("inner join Visita v on t.VisitaClave = v.VisitaClave and v.DiaClave = '"+diaClave+"' ")
					.append("inner join TransProdDetalle td on t.TransProdID = td.TransProdID ")
					.append("inner join Producto p on td.ProductoClave = p.ProductoClave ")
					.append("inner join ProductoDetalle pd on td.ProductoClave = pd.ProductoClave and td.TipoUnidad = pd.PRUTipoUnidad ")
					.append("inner join ProductoUnidad pu on pd.ProductoClave = pu.ProductoClave and pd.PRUTipoUnidad = pu.PRUTipoUnidad ")
					//.append("inner join ProductoEsquema pe on p.ProductoClave = pe.ProductoClave ")
					//.append("inner join Esquema e on pe.EsquemaID = e.EsquemaID ")
					.append("where  t.Tipo in ("+tipos+") and t.TipoFase != '0' and t.TipoMovimiento = '1' ")
					.append("group by td.TipoMotivo,td.ProductoClave, p.Nombre ")
					.append("order by td.TipoMotivo,td.ProductoClave desc,pu.KgLts desc ");

			return BDVend.consultar(consulta.toString());

		}

		public static ISetDatos obtenerDevolucionesCambiosDetallado(String diaClave,String tipos) throws Exception {

			if(tipos.equals("")){
				tipos = "'9','3'";
			}

			StringBuilder consulta = new StringBuilder();
			consulta.append("select  t.Tipo,c.Clave,c.NombreCorto,td.ProductoClave, p.Nombre,sum(pd.Factor*td.Cantidad) as 'Cant',  td.TipoMotivo from TransProd t ")
					.append("inner join Visita v on t.VisitaClave = v.VisitaClave and v.DiaClave = '" + diaClave + "' ")
					.append("inner join Cliente c on v.ClienteClave = c.ClienteClave ")
					.append("inner join TransProdDetalle td on t.TransProdID = td.TransProdID ")
					.append("inner join Producto p on td.ProductoClave = p.ProductoClave ")
					.append("inner join ProductoDetalle pd on td.ProductoClave = pd.ProductoClave and td.TipoUnidad = pd.PRUTipoUnidad ")
					.append("inner join ProductoUnidad pu on pd.ProductoClave = pu.ProductoClave and pd.PRUTipoUnidad = pu.PRUTipoUnidad ")
					//.append("inner join ProductoEsquema pe on p.ProductoClave = pe.ProductoClave ")
					//.append("inner join Esquema e on pe.EsquemaID = e.EsquemaID ")
					.append("where  t.Tipo in (" + tipos + ") and t.TipoFase != '0' and t.TipoMovimiento = '1' ")
					.append("group by t.Tipo,c.Clave,c.NombreCorto, td.ProductoClave, p.Nombre,td.TipoMotivo ")
					.append("order by c.NombreCorto, t.Tipo desc, c.Clave asc, pu.KgLts desc ");

			return BDVend.consultar(consulta.toString());

		}

		public static ISetDatos obtenerDevolucionesCambiosCosteoGeneral(String diaClave, String tipos) throws Exception{
			if(tipos.equals("")){
				tipos = "'9','3'";
			}

			StringBuilder consulta = new StringBuilder();
			consulta.append("select group_concat(distinct t.Tipo) as 'tipoM', td.TipoMotivo,td.ProductoClave, p.Nombre,sum(pd.Factor*td.Cantidad) as 'Cant', sum((td.Precio + td.Impuesto) * td.Cantidad) as 'Mont' from TransProd t  ")
					.append("inner join Visita v on t.VisitaClave = v.VisitaClave and v.DiaClave = '"+diaClave+"' ")
					.append("inner join TransProdDetalle td on t.TransProdID = td.TransProdID ")
					.append("inner join Producto p on td.ProductoClave = p.ProductoClave ")
					.append("inner join ProductoDetalle pd on td.ProductoClave = pd.ProductoClave and td.TipoUnidad = pd.PRUTipoUnidad ")
					.append("inner join ProductoUnidad pu on pd.ProductoClave = pu.ProductoClave and pd.PRUTipoUnidad = pu.PRUTipoUnidad ")
					.append("where  t.Tipo in ("+tipos+") and t.TipoFase != '0' and t.TipoMovimiento = '1' ")
					.append("group by td.TipoMotivo,td.ProductoClave, p.Nombre ")
					.append("order by td.TipoMotivo,td.ProductoClave desc,pu.KgLts desc ");

			return BDVend.consultar(consulta.toString());

		}

		public static ISetDatos obtenerDevolucionesCambiosCosteoDetallado(String diaClave,String tipos) throws Exception {

			if(tipos.equals("")){
				tipos = "'9','3'";
			}

			StringBuilder consulta = new StringBuilder();
			consulta.append("select  t.Tipo,c.Clave,c.NombreCorto,td.ProductoClave, p.Nombre,sum(pd.Factor*td.Cantidad) as 'Cant', sum((td.Precio + td.Impuesto) * td.Cantidad) as 'Mont', td.TipoMotivo from TransProd t ")
					.append("inner join Visita v on t.VisitaClave = v.VisitaClave and v.DiaClave = '" + diaClave + "' ")
					.append("inner join Cliente c on v.ClienteClave = c.ClienteClave ")
					.append("inner join TransProdDetalle td on t.TransProdID = td.TransProdID ")
					.append("inner join Producto p on td.ProductoClave = p.ProductoClave ")
					.append("inner join ProductoDetalle pd on td.ProductoClave = pd.ProductoClave and td.TipoUnidad = pd.PRUTipoUnidad ")
					.append("inner join ProductoUnidad pu on pd.ProductoClave = pu.ProductoClave and pd.PRUTipoUnidad = pu.PRUTipoUnidad ")
					.append("where  t.Tipo in (" + tipos + ") and t.TipoFase != '0' and t.TipoMovimiento = '1' ")
					.append("group by t.Tipo,c.Clave,c.NombreCorto, td.ProductoClave, p.Nombre,td.TipoMotivo ")
					.append("order by c.NombreCorto, t.Tipo desc, c.Clave asc, pu.KgLts desc ");

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

        public static ISetDatos obtenerSubEmpresasSpinner() throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select SubEmpresaId as _id, SubEmpresaId AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", case when ifnull(NombreCorto, '') = '' then NombreEmpresa else NombreCorto end AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + " ");
            consulta.append("from SubEmpresa ");

            return BDVend.consultar(consulta.toString());

//            StringBuilder consulta = new StringBuilder();
//            if (!MensajeSeleccion.equals(""))
//            {
//                consulta.append("select -1 as _id, '' as Grupo, -1 as " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", '" + MensajeSeleccion + "' as " + SearchManager.SUGGEST_COLUMN_TEXT_1 + " ");
//                consulta.append("UNION ");
//            }
//            consulta.append("select VAD.VAVClave as _id,VVA.Grupo, VAD.VAVClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", VAD.Descripcion AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + " from ValorReferencia VR ");
//            consulta.append("inner join VARValor VVA on VR.VARCodigo = VVA.VARCodigo ");
//            consulta.append("inner join VAVDescripcion VAD on VR.VARCodigo = VAD.VARCodigo and VAD.VAVClave = VVA.VAVClave ");
//            consulta.append("where VR.VARCodigo = '" + VARCodigo + "' and VVA.Grupo in (" + grupo + ") ");
//            if (incluirNoDefinido)
//                consulta.append(" OR (VR.VARCodigo = '" + VARCodigo + "' and VAD.VAVClave = '0')");
//            return BDTerm.consultar(consulta.toString());
        }

        public static ISetDatos obtenerInventarioGeneral (String subEmpresaId, boolean inventarioCero) throws  Exception {
            StringBuilder consulta = new StringBuilder();

			/*boolean inventarioCero = true;
			if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("MostrarReporteInventarioCero"))
				inventarioCero = (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("MostrarReporteInventarioCero").toString().equals("1"));*/

			consulta.append("select pro.ProductoClave, pro.Nombre, inv.Disponible as Exis, (inv.Disponible - inv.NoDisponible - inv.Apartado - inv.Contenido) as Disp, (inv.NoDisponible + inv.Apartado) as 'No D', max(ifnull(ppv.Precio, 0)) as Precio ");
			consulta.append("from Inventario inv ");
			consulta.append("inner join Producto pro on inv.ProductoClave = pro.ProductoClave ");
			consulta.append("inner join ProductoUnidad pru on pro.ProductoClave = pru.ProductoClave ");
			consulta.append("inner join ( ");
			consulta.append("select prd.ProductoClave, prd.PRUTipoUnidad, min(prd.Factor) as Factor ");
			consulta.append("from ProductoDetalle prd ");
			consulta.append("inner join Inventario inv on prd.ProductoClave = inv.ProductoClave and prd.ProductoClave = prd.ProductoDetClave ");
			consulta.append("group by prd.ProductoClave ");
			consulta.append(") as prd on pru.ProductoClave = prd.ProductoClave and pru.PRUTipoUnidad = prd.PRUTipoUnidad ");
			consulta.append("left join PrecioProductoVig ppv on pru.ProductoClave = ppv.ProductoClave and pru.PRUTipoUnidad = ppv.PRUTipoUnidad ");
			if (((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase != null && ((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase.length()>0)
				consulta.append("and ppv.PrecioClave = '" + ((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase + "' ");
			consulta.append("where pro.SubEmpresaId = '" + subEmpresaId + "' ");
			if (!inventarioCero)
				consulta.append("and inv.Disponible > 0 ");
			consulta.append("group by pro.ProductoClave ");
			consulta.append("order by pro.ProductoClave ");

            /*consulta.append("select distinct p.ProductoClave, p.Nombre, i.Disponible as Exis, (i.Disponible - i.NoDisponible - i.Apartado - i.Contenido) as Disp, (i.NoDisponible + i.Apartado) as 'No D', pu.PRUTipoUnidad, pd.Factor from Inventario i ")
                    .append("inner join Producto p on i.ProductoClave = p.ProductoClave and p.SubEmpresaId = '" + subEmpresaId + "' ")
                    .append("inner join ProductoUnidad pu on p.ProductoClave = pu.ProductoClave ")
                    .append("inner join ProductoDetalle pd on p.ProductoClave = pd.ProductoClave and pu.PRUTipoUnidad = pd.PRUTipoUnidad and pd.Factor = (select MIN(pd.Factor) from inventario i inner join Producto p on i.ProductoClave = p.ProductoClave and p.SubEmpresaId = '" + subEmpresaId + "' inner join ProductoDetalle pd on i.ProductoClave = pd.ProductoClave ) ")
                    .append("order by i.ProductoClave asc");*/

            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerInventarioDetallado(String subEmpresaId, boolean inventarioCero) throws Exception{

			StringBuilder consulta = new StringBuilder();

			consulta.append("select pro.ProductoClave, pro.Nombre, inv.Disponible as Exis, (inv.Disponible - inv.NoDisponible - inv.Apartado - inv.Contenido) as Disp, (inv.NoDisponible + inv.Apartado) as 'No D', pru.PRUTipoUnidad, prd.Factor, max(ifnull(ppv.Precio, 0)) as Precio ");
			consulta.append("from Inventario inv ");
			consulta.append("inner join Producto pro on inv.ProductoClave = pro.ProductoClave ");
			consulta.append("inner join ProductoUnidad pru on pro.ProductoClave = pru.ProductoClave ");
			consulta.append("inner join ProductoDetalle prd on pru.ProductoClave = prd.ProductoClave and pru.PRUTipoUnidad = prd.PRUTipoUnidad and prd.ProductoClave = prd.ProductoDetClave ");
			consulta.append("left join PrecioProductoVig ppv on pru.ProductoClave = ppv.ProductoClave and pru.PRUTipoUnidad = ppv.PRUTipoUnidad ");
			if (((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase != null && ((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase.length()>0)
				consulta.append("and ppv.PrecioClave = '" + ((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase + "' ");
			consulta.append("where pro.SubEmpresaId = '" + subEmpresaId + "' ");
			if (!inventarioCero)
				consulta.append("and inv.Disponible > 0 ");
			consulta.append("group by pro.ProductoClave, PRU.PRUTipoUnidad ");
			consulta.append("order by pro.ProductoClave, prd.Factor desc");

            /*consulta.append("select distinct p.ProductoClave, p.Nombre, i.Disponible as Exis, (i.Disponible - i.NoDisponible - i.Apartado - i.Contenido) as Disp, (i.NoDisponible + i.Apartado) as 'No D', pu.PRUTipoUnidad, pd.Factor, max(pv.Precio) as Precio from Inventario i ")
                    .append("inner join Producto p on i.ProductoClave = p.ProductoClave and p.SubEmpresaId = '" + subEmpresaId + "' ")
                    .append("inner join ProductoUnidad pu on p.ProductoClave = pu.ProductoClave ")
                    .append("inner join ProductoDetalle pd on p.ProductoClave = pd.ProductoClave and pu.PRUTipoUnidad = pd.PRUTipoUnidad ")
                    .append("left join PrecioProductoVig pv  on pv.ProductoClave = pd.ProductoClave and pv.PRUTipoUnidad = pu.PRUTipoUnidad ")
                    .append("group by p.ProductoClave, p.Nombre ")
                    .append("order by i.ProductoClave asc, pd.Factor desc, pv.Precio desc");*/

            return BDVend.consultar(consulta.toString());
        }

		public static ISetDatos obtenerInventarioTotalProductos (String subEmpresaId, boolean inventarioCero) throws  Exception {
			StringBuilder consulta = new StringBuilder();
			consulta.append("select sum(inv.Disponible) as Exis, sum(inv.Disponible - inv.NoDisponible - inv.Apartado - inv.Contenido) as Disp, sum(inv.NoDisponible + inv.Apartado) as 'No D' ");
            consulta.append("from Inventario inv ");
            consulta.append("inner join Producto pro on inv.ProductoClave = pro.ProductoClave ");
            consulta.append("where pro.SubEmpresaId = '" + subEmpresaId + "' ");
			if (!inventarioCero)
				consulta.append("and inv.Disponible > 0 ");
            consulta.append("order by pro.ProductoClave ");

            /*consulta.append("select distinct sum( i.Disponible) as Exis, sum( (i.Disponible - i.NoDisponible - i.Apartado - i.Contenido) ) as Disp, sum( (i.NoDisponible + i.Apartado)  ) as 'No D' from Inventario i ")
                    .append("inner join Producto p on i.ProductoClave = p.ProductoClave and p.SubEmpresaId = '" + subEmpresaId + "' ")
                    .append("inner join ProductoUnidad pu on p.ProductoClave = pu.ProductoClave ")
                    .append("inner join ProductoDetalle pd on p.ProductoClave = pd.ProductoClave and pu.PRUTipoUnidad = pd.PRUTipoUnidad and pd.Factor = (select MIN(pd.Factor) from inventario i inner join Producto p on i.ProductoClave = p.ProductoClave and p.SubEmpresaId = '" + subEmpresaId + "' inner join ProductoDetalle pd on i.ProductoClave = pd.ProductoClave ) ")
                    .append("order by i.ProductoClave asc");*/

			return BDVend.consultar(consulta.toString());
		}

		public static float obtenerInventarioTotalUnitario (String subEmpresaId, boolean inventarioCero) throws  Exception {
			StringBuilder consulta = new StringBuilder();
			/*consulta.append("select distinct pv.ProductoClave, pv.Precio, inv.disponible, inv.Factor from PrecioProductoVig pv ")
					.append("inner join (select distinct pd.ProductoClave, pd.PRUTipoUnidad, i.Disponible, pd.Factor from inventario i ")
					.append("inner join Producto p on i.ProductoClave = p.ProductoClave and p.SubEmpresaId = '" + subEmpresaId + "' ")
					.append("inner join ProductoDetalle pd on i.ProductoClave = pd.ProductoClave and i.ProductoClave = pd.ProductoDetClave and pd.Factor = (select MIN(pd.Factor) from inventario i inner join Producto p on i.ProductoClave = p.ProductoClave and p.SubEmpresaId = '" + subEmpresaId + "' inner join ProductoDetalle pd on i.ProductoClave = pd.ProductoClave and i.ProductoClave = pd.ProductoDetClave) order by i.ProductoClave asc) inv on pv.ProductoClave = inv.ProductoClave and pv.PRUTipoUnidad = inv.PRUTipoUnidad ")
					.append("order by pv.ProductoClave asc, pv.Precio desc");*/

            if (((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase != null && ((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase.length()>0){
                consulta.append("select ifnull(sum(ifnull(ppv.Precio, 0) * (inv.Disponible * prd.Factor)), 0) as TotalUnitario ");
                consulta.append("from Inventario inv ");
                consulta.append("inner join Producto pro on inv.ProductoClave = pro.ProductoClave ");
                consulta.append("inner join ProductoUnidad pru on pro.ProductoClave = pru.ProductoClave ");
                consulta.append("inner join ( ");
                consulta.append("select prd.ProductoClave, prd.PRUTipoUnidad, min(prd.Factor) as Factor ");
                consulta.append("from ProductoDetalle prd ");
                consulta.append("inner join Inventario inv on prd.ProductoClave = inv.ProductoClave and prd.ProductoClave = prd.ProductoDetClave ");
                consulta.append("group by prd.ProductoClave ");
                consulta.append(") as prd on pru.ProductoClave = prd.ProductoClave and pru.PRUTipoUnidad = prd.PRUTipoUnidad ");
                consulta.append("left join PrecioProductoVig ppv on pru.ProductoClave = ppv.ProductoClave and pru.PRUTipoUnidad = ppv.PRUTipoUnidad  and ppv.PrecioClave = '" + ((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase + "'  ");
                consulta.append("where pro.SubEmpresaId = '" + subEmpresaId + "' ");
				if (!inventarioCero)
					consulta.append("and inv.Disponible > 0 ");
            }
            else{
                consulta.append("select ifnull(sum(Precio * (Disponible * Factor)), 0) as TotalUnitario ");
                consulta.append("from ( ");
                consulta.append("select inv.ProductoClave, inv.Disponible, prd.Factor, max(ifnull(ppv.Precio, 0)) as Precio ");
                consulta.append("from Inventario inv ");
                consulta.append("inner join Producto pro on inv.ProductoClave = pro.ProductoClave ");
                consulta.append("inner join ProductoUnidad pru on pro.ProductoClave = pru.ProductoClave ");
                consulta.append("inner join ( ");
                consulta.append("select prd.ProductoClave, prd.PRUTipoUnidad, min(prd.Factor) as Factor ");
                consulta.append("from ProductoDetalle prd ");
                consulta.append("inner join Inventario inv on prd.ProductoClave = inv.ProductoClave and prd.ProductoClave = prd.ProductoDetClave ");
                consulta.append("group by prd.ProductoClave ");
                consulta.append(") as prd on pru.ProductoClave = prd.ProductoClave and pru.PRUTipoUnidad = prd.PRUTipoUnidad ");
                consulta.append("left join PrecioProductoVig ppv on pru.ProductoClave = ppv.ProductoClave and pru.PRUTipoUnidad = ppv.PRUTipoUnidad ");
                consulta.append("where pro.SubEmpresaId = '" + subEmpresaId + "' ");
				if (!inventarioCero)
					consulta.append("and inv.Disponible > 0 ");
                consulta.append("group by inv.ProductoClave ");
                consulta.append(") as t ");
            }

			return (Float)BDVend.getBD().ejecutarEscalarObject(consulta.toString());
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

		/*public static void eliminarPorFacturaId(String facturaId) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("DELETE FROM TransProd WHERE FacturaID = '" + facturaId + "'");
			BDVend.ejecutarComando(sConsulta.toString());
		}*/

        public static ArrayList<Promociones2.ProductoPRM> obtenerProductosSinPromocion(String sTransProdId)
        {
            try
            {
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.append("SELECT TPD.ProductoClave, SUM(TPD.Cantidad * PRD.Factor) AS Cantidad, SUM(TPD.Subtotal) AS Subtotal ");
                sConsulta.append("FROM TransProdDetalle TPD ");
                sConsulta.append("INNER JOIN ProductoDetalle PRD ON TPD.ProductoClave = PRD.ProductoClave AND TPD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ");
                sConsulta.append("WHERE TPD.TransProdId = '" + sTransProdId + "' and  IFNULL(TPD.Promocion, 0) <> 2  and  IFNULL(TPD.Promocion, 0) <> 3 ");
                sConsulta.append("GROUP BY TPD.ProductoClave ");
                ISetDatos datos = BDVend.consultar(sConsulta.toString());
                ArrayList<Promociones2.ProductoPRM> res = new ArrayList<Promociones2.ProductoPRM>();
                while (datos.moveToNext())
                {
                    res.add(new Promociones2.ProductoPRM(datos.getString("ProductoClave"), datos.getFloat("Cantidad"), datos.getFloat("Subtotal")));
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

		public static ISetDatos obtenerCantidadesPorProducto(String sTransProdId, String sProductoClave)
		{
			try
			{
				StringBuilder sConsulta = new StringBuilder();
				sConsulta.append("SELECT SUM(TPD.Cantidad * PRD.Factor) AS Cantidad, SUM(TPD.Subtotal) AS Subtotal, SUM(TPD.Impuesto) AS Impuesto ");
				sConsulta.append("FROM TransProdDetalle TPD ");
				sConsulta.append("INNER JOIN ProductoDetalle PRD ON TPD.ProductoClave = PRD.ProductoClave AND TPD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ");
				sConsulta.append("WHERE TPD.TransProdId = '" + sTransProdId + "' and TPD.ProductoClave = '" + sProductoClave + "' and IFNULL(TPD.Promocion,0) <> 2 and IFNULL(TPD.Promocion,0) <> 3 ");
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
			consulta.append("and TRP.TransProdID not in (select IFNULL(FacturaID,'') from TransProd where Tipo = 24 and TipoFase = 8) ");
			
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

		public static SeleccionarPedido.VistaPedidos[] obtenerPedidosEnviados(Dia dia) throws Exception
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

			ModuloMovDetalle moduloMovDetalle = ConsultasModuloMovDetalle.obtenerModuloMovDetallePorIndice(Integer.valueOf(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString()));
			consulta.append("where TRP.Tipo in (" + moduloMovDetalle.getTipoTransprod() + ") ");

			consulta.append("and TRP.ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' and TRP.DiaClave = '" + dia.DiaClave + "' ");
			consulta.append("and TRP.TransProdID not in (select FacturaID from TransProd where Tipo = 24 and TipoFase = 8) and VIS.Enviado = 1 and TRP.VisitaClave1 is null ");

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
			consulta.append("Select Distinct * from(");
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
			consulta.append("and VIS.ClienteClave = '" + cliente.ClienteClave + "' and TRP.DiaClave = '" + dia.DiaClave + "' AND VIS.VisitaClave = '" + visita.VisitaClave + "' ");
			consulta.append("union all ");
			consulta.append("select TransProdID, Folio, TipoFase, FechaCaptura as Fecha ");
			consulta.append("from TransProd TRP inner join Visita V on TRP.VisitaClave = V.VisitaClave ");
			consulta.append("where Tipo in (9) and TipoFase in (0,1,15) and TipoMovimiento = 1 ");
			consulta.append("and V.ClienteClave = '"+cliente.ClienteClave+"' ");
			consulta.append(") as a");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				//int fase = datos.getInt(2) + 1;
				String strFase = "";
				while (fases.moveToNext()){
					if(fases.getInt(0) == datos.getInt(2)){
						strFase = fases.getString(2);
						break;
					}
				}
				fases.moveToFirst();
				//fases.moveToPosition(fase - 1);
				SeleccionarPedido.VistaPedidos pedido = new SeleccionarPedido.VistaPedidos(datos.getString(0), datos.getString(1), datos.getInt(2), strFase, datos.getDate(3));// datos.getDate(3)
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
			consulta.append("select TRP.TransProdID, TRP.Folio, TRP.TipoFase, ");
            consulta.append("case when TRP.TipoFase = 0 then TRP.FechaCancelacion else case when TRP.FechaEntrega is null then TRP.FechaCaptura else case when TRP.VisitaClave = '" + visita.VisitaClave + "' then TRP.FechaCaptura else case when TRP.FechaSurtido is null then TRP.FechaEntrega else TRP.FechaSurtido end end end end as Fecha, ");
            consulta.append("case when TRP.FechaEntrega is null then 0 else case when TRP.VisitaClave = '" + visita.VisitaClave + "' or TRP.TipoFase = 0 then 0 else case when TRP.FechaSurtido is null then 1 else 2 end end end as Recoleccion  "); //0-NORMAL //1-POR RECOLECTAR //2-RECOLECTADO
            consulta.append("from TransProd TRP ");
			consulta.append("inner join visita VIS on VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
			consulta.append("where TRP.Tipo in (3) and TRP.TipoFase in (0,1) and VIS.ClienteClave = '" + cliente.ClienteClave + "' and ");
			consulta.append("((TRP.DiaClave = '" + dia.DiaClave + "' AND VIS.VisitaClave = '" + visita.VisitaClave + "') or TRP.FechaEntrega <= '" + dia.FechaCaptura + "')");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				int fase = datos.getInt(2) + 1;
				fases.moveToPosition(fase - 1);
                String sFase;
                if(datos.getInt(4) == 1)
                    sFase = Mensajes.get("XPorRecolectar");
                else if(datos.getInt(4) == 2)
                    sFase = Mensajes.get("XRecolectado");
                else
                    sFase = fases.getString(2);
                SeleccionarPedido.VistaPedidos pedido = new SeleccionarPedido.VistaPedidos(datos.getString(0), datos.getString(1), datos.getInt(2), sFase, datos.getDate(3), datos.getString(4));
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
			//ISetDatos fases = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
			consulta.append("select TRP.TransProdID,TRP.Folio,TRP.TipoFase,TRP.TipoMotivo, ");
			consulta.append("TRP.FechaCaptura as Fecha ");
			consulta.append("from TransProd TRP inner join Dia D on TRP.DiaClave = D.DiaClave ");
			consulta.append("where TRP.Tipo in (" + Tipo + ")  and TRP.DiaClave = '" + dia.DiaClave + "'");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				//int fase = datos.getInt(2) + 1;
				//fases.moveToPosition(fase - 1);
				//SeleccionarPedido.VistaPedidos pedido = new SeleccionarPedido.VistaPedidos(datos.getString("TransProdID"), datos.getString("Folio"), datos.getInt("TipoFase"), fases.getString(2), datos.getDate("Fecha"), grupoMotivo);// datos.getDate(3)
																																															// Generales.getFechaHoraActual()
				SeleccionarPedido.VistaPedidos pedido;
				if(accion != null && accion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)){
					//se agrega el grupo motivo como extras
					com.amesol.routelite.actividades.ValorReferencia vr = ValoresReferencia.getValor("TRPMOT", datos.getString("TipoMotivo"));
					String grupoMotivo = vr.getGrupo();
					pedido = new SeleccionarPedido.VistaPedidos(datos.getString("TransProdID"), datos.getString("Folio"), datos.getInt("TipoFase"), ValoresReferencia.getDescripcion("TRPFASE", datos.getString("TipoFase")), datos.getDate("Fecha"), grupoMotivo);// datos.getDate(3)
				}else{
					pedido = new SeleccionarPedido.VistaPedidos(datos.getString("TransProdID"), datos.getString("Folio"), datos.getInt("TipoFase"), ValoresReferencia.getDescripcion("TRPFASE", datos.getString("TipoFase")), datos.getDate("Fecha"));// datos.getDate(3)
				}
				pedidos.add(pedido);
			}

			//fases.close();
			datos.close();

			return pedidos.toArray(new SeleccionarPedido.VistaPedidos[pedidos.size()]);
		}


        public static SeleccionarPedido.VistaPedidos[] obtenerCanjesPorVisita(Dia dia, Cliente cliente, Visita visita) throws Exception
        {
            ArrayList<SeleccionarPedido.VistaPedidos> pedidos = new ArrayList<SeleccionarPedido.VistaPedidos>();
            StringBuilder consulta = new StringBuilder();
            //ISetDatos fases = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
            consulta.append("select TRP.TransProdID,TRP.Folio,TRP.TipoFase, ");
            consulta.append("TRP.FechaCaptura as Fecha ");
            consulta.append("from TransProd TRP inner join Dia D on TRP.DiaClave = D.DiaClave ");
            consulta.append("inner join visita VIS on VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = D.DiaClave ");
            consulta.append("where TRP.Tipo = 5 ");
            consulta.append("and VIS.ClienteClave = '" + cliente.ClienteClave + "' and TRP.DiaClave = '" + dia.DiaClave + "' AND VIS.VisitaClave = '" + visita.VisitaClave + "'");

            ISetDatos datos = BDVend.consultar(consulta.toString());
            while (datos.moveToNext())
            {
                SeleccionarPedido.VistaPedidos pedido = new SeleccionarPedido.VistaPedidos(datos.getString(0), datos.getString(1), datos.getInt(2), ValoresReferencia.getDescripcion("TRPFASE", datos.getString(2)), datos.getDate(3));// datos.getDate(3)
                // Generales.getFechaHoraActual()
                pedidos.add(pedido);
            }

            datos.close();

            return pedidos.toArray(new SeleccionarPedido.VistaPedidos[pedidos.size()]);
        }
		/*public static void eliminarFactura(String TransProdId) throws Exception
		{
			BDVend.consultar("DELETE FROM TransProd WHERE FacturaID='" + TransProdId + "'");
		}

		public static ISetDatos obtenerPorTipo(String TransProdId, int Tipo) throws Exception
		{
			return BDVend.consultar("SELECT TransProd.TransProdID,ProductoClave,TipoUnidad, Cantidad FROM TransProdDetalle inner join TransProd on TransProd.TransProdID = TransProdDetalle.TransProdID WHERE FacturaID='" + TransProdId + "' and Tipo = " + Tipo);
		}*/

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
			//consulta.append("WHERE Tipo in (" + trueType + ", 24) and TipoFase <> 0 AND FechaCobranza < date('now',(-CLI.DiasVencimiento)||' day') ");
            if (trueType == 8)
                consulta.append("WHERE ((Tipo=24 and TipoFase<>0) or (Tipo=8 and TipoFase=1)) AND FechaCobranza < date('now',(-CLI.DiasVencimiento)||' day') ");
            else
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
			//consulta.append("WHERE Tipo in (" + trueType + ", 24) and TipoFase <> 0 ");
            if (trueType == 8)
                consulta.append("WHERE ((Tipo=24 and TipoFase <> 0) or (Tipo=8 and TipoFase=1)) ");
            else
                consulta.append("WHERE Tipo in (" + trueType + ", 24) and TipoFase <> 0 ");
			consulta.append("AND CLI.ClienteClave = '" + clienteClave + "' ");
			consulta.append("AND FechaHoraAlta > (SELECT FechaAbono FROM Abono WHERE ABNId = '" + abnid + "') ");

			return (BDVend.bd.ejecutarEscalarInteger(consulta.toString()) > 0);
		}

		public static float obtenerSaldoCliente(String ClienteClave,String sTransProdIdsExcep) throws Exception
		{

			ISetDatos datos = BDVend.consultar("SELECT case when sum(total) is null then 0 else sum(total) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave inner join ModuloMovDetalle MMD on TRP.PCEModuloMovDetClave = MMD.ModuloMovDetalleClave WHERE v.ClienteClave = '" + ClienteClave + "' AND (MMD.TipoIndice = 9  AND CFVTipo = 2) AND TipoFase = 1 and not TRP.TransProdId in(" + sTransProdIdsExcep + ")");
			float res = 0;
			if (datos.moveToNext())
			{
				res = datos.getFloat(0);
			}
			datos.close();
			return res;
		}

		public static float obtenerSaldoCliente(String ClienteClave) throws Exception
		{

			ISetDatos datos = BDVend.consultar("SELECT case when sum(total) is null then 0 else sum(total) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave inner join ModuloMovDetalle MMD on TRP.PCEModuloMovDetClave = MMD.ModuloMovDetalleClave WHERE v.ClienteClave = '" + ClienteClave + "' AND (MMD.TipoIndice = 9  AND CFVTipo = 2) AND TipoFase = 1 ");
			float res = 0;
			if (datos.moveToNext())
			{
				res = datos.getFloat(0);
			}
			datos.close();
			return res;
		}

		public static float obtenerSaldoVencidoCliente(String ClienteClave) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT case when sum(total) is null then 0 else sum(total) end ");
			consulta.append("FROM Transprod TRP ");
			consulta.append("inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave ");
			consulta.append("inner join ModuloMovDetalle MMD on TRP.PCEModuloMovDetClave = MMD.ModuloMovDetalleClave ");
			consulta.append("WHERE v.ClienteClave = '" + ClienteClave + "' AND (MMD.TipoIndice = 9  AND CFVTipo = 2) AND TipoFase = 1 ");
			consulta.append("AND TRP.FechaCobranza < '" + Generales.getPrimerHora(Generales.getFechaActual()) + "'");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			float res = 0;
			if (datos.moveToNext())
			{
				res = datos.getFloat(0);
			}
			datos.close();
			return res;
		}

		public static float obtenerSaldoCobrarVentas(Cliente oCliente, String transProdExcep) throws Exception
		{
			ISetDatos datos;
			if (oCliente.ActualizaSaldoCheque)
			{
				datos = BDVend.consultar("SELECT case when sum(saldo) is null then 0 else sum(saldo) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND ((Tipo = 1 AND CFVTipo = 2) OR Tipo = 24) AND TipoFase <> 0 " + (transProdExcep.length() > 0 ? " and TRP.TransProdID not in (" + transProdExcep + ")" : ""));
			}
			else
			{
				datos = BDVend.consultar("SELECT case when sum(saldo+(Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END)) is null then 0 else sum(saldo+(Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END)) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave Left Join (Select TRPCheque.TransProdID,sum(AbnCheque) as AbnCheque from TRPCheque  group by TRPCheque.TransProdID) TRC on TRC.TransProdID = TRP.TransProdID WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND ((Tipo = 1 AND CFVTipo = 2) OR Tipo = 24) AND TipoFase > 0"  + (transProdExcep.length() > 0 ? " and TRP.TransProdID not in (" + transProdExcep + ")" : ""));
			}
			float res = 0;
			if (datos.moveToNext())
			{
				res = datos.getFloat(0);
			}
			datos.close();
			return res;
		}
		
		public static float obtenerSaldoPedidosConsignaciones(Cliente oCliente, String transProdExcep) throws Exception
		{
			ISetDatos datos;
			datos = BDVend.consultar("SELECT case when sum(saldo) is null then 0 else sum(saldo) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND ((Tipo = 1 AND CFVTipo = 2) OR Tipo = 24) AND TipoFase <> 0" + (transProdExcep.length() > 0 ? " and TRP.TransProdID not in (" + transProdExcep + ")" : ""));
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

		public static float obtenerSaldoNoCobrarVentas(Cliente oCliente, String transProdExcep) throws Exception
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
				datos2 = BDVend.consultar("SELECT case when sum(total) is null then 0 else sum(total) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND Tipo = 1 AND CFVTipo = 2 AND TipoFase > 0 AND FacturaId is null" + (transProdExcep.length() > 0 ? " and TRP.TransProdID not in ('" + transProdExcep + "')" : ""));
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

        public static float obtenerSaldoVentasContado(Visita visita, Cliente cliente, int tipoTransProd) throws Exception{
            StringBuilder sConsulta = new StringBuilder();

            if (cliente.ActualizaSaldoCheque) {
                sConsulta.append("select ifnull(sum(Saldo - (Round(case when TRC.AbnChequePosfechado is null then 0 else TRC.AbnChequePosfechado end,2))), 0) as Saldo ");
                sConsulta.append("from TransProd TRP ");
                sConsulta.append("inner join Visita VIS on VIS.VisitaClave = ifnull(TRP.VisitaClave1, TRP.VisitaClave) and VIS.DiaClave = ifnull(TRP.DiaClave1, TRP.DiaClave) ");
				sConsulta.append("left join (Select TransProdId, sum(AbnChequePosfechado) as AbnChequePosfechado from TRPCheque group by TransProdID) TRC on TRC.TransProdID = TRP.TransProdID ");
                sConsulta.append("where VIS.VisitaClave = '" + visita.VisitaClave + "' and VIS.DiaClave = '" + visita.DiaClave + "' and TRP.CFVTipo = 1 ");
				sConsulta.append("and TRP.Tipo = " + tipoTransProd + " and " + (tipoTransProd == 1 ? " TRP.TipoFase in (2,3) " : " TRP.TipoFase <> 0 " ));
            }else{
                sConsulta.append("select ifnull(sum(Saldo - (Round(case when TRCP.AbnChequePosfechado is null then 0 else TRCP.AbnChequePosfechado end,2)) + (case when TRC.AbnCheque is null then 0 else TRC.AbnCheque end)), 0) as Saldo ");
                sConsulta.append("from TransProd TRP ");
                sConsulta.append("inner join Visita VIS on VIS.VisitaClave = ifnull(TRP.VisitaClave1, TRP.VisitaClave) and VIS.DiaClave = ifnull(TRP.DiaClave1, TRP.DiaClave) ");
                sConsulta.append("left join (select TRPCheque.TransProdID, sum(AbnCheque) as AbnCheque from TRPCheque group by TRPCheque.TransProdID) TRC on TRC.TransProdID = TRP.TransProdID ");
				sConsulta.append("left join (Select TransProdId, sum(AbnChequePosfechado) as AbnChequePosfechado from TRPCheque group by TransProdID) TRCP on TRCP.TransProdID = TRP.TransProdID ");
                sConsulta.append("where VIS.VisitaClave = '" + visita.VisitaClave + "' and VIS.DiaClave = '" + visita.DiaClave + "' and TRP.CFVTipo = 1 ");
				sConsulta.append("and TRP.tipo = " + tipoTransProd + " and " + (tipoTransProd == 1 ? " TRP.TipoFase in (2,3) " : " TRP.TipoFase <> 0 " ));
            }

            return (Float)BDVend.getBD().ejecutarEscalarObject(sConsulta.toString());
        }

		public static int obtenerVentasVencidas(Cliente oCliente) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			int resultado = 0;
			short tipoMov =0;
			if (oCliente.ActualizaSaldoCheque)
			{
				consulta.append("select case when sum(saldo) is null then 0 else sum(saldo) end From transprod tr ");
				consulta.append("inner join visita v on v.visitaclave = TR.visitaclave and v.diaClave = TR.Diaclave ");
				consulta.append("where tr.FechaCobranza < datetime('now','-" + oCliente.DiasVencimiento + " day') and ");
				consulta.append("v.clienteclave = '" + oCliente.ClienteClave + "' and ");
				consulta.append("(tr.tipo =1) and tr.VisitaClave <> '" + ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave + "'  and tr.TipoFase <>0 ");
			}
			else
			{
				consulta.append("select case when sum(saldo+(Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END)) is null then 0 else sum(saldo+(Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END)) end From transprod tr ");
				consulta.append("inner join visita v on v.visitaclave = TR.visitaclave and v.diaClave = TR.Diaclave ");
				consulta.append("left Join (Select TRPCheque.TransProdID,sum(AbnCheque) as AbnCheque from TRPCheque  group by TRPCheque.TransProdID) TRC on TRC.TransProdID = TR.TransProdID ");
				consulta.append("where tr.FechaCobranza < datetime('now','-" + oCliente.DiasVencimiento + " day') and ");
				consulta.append("v.clienteclave = '" + oCliente.ClienteClave + "' and ");
				consulta.append("(tr.tipo =1) and tr.VisitaClave <> '" + ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave + "'  and tr.TipoFase <>0 ");
			}
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if (datos.moveToNext())
			{
				resultado = datos.getInt(0);
			}
			datos.close();
			return resultado;
		}

		public static float obtenerFacturasVencidas(Cliente oCliente) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			float resultado = 0;
			short tipoMov =0;
			if (oCliente.ActualizaSaldoCheque)
			{
				consulta.append("SELECT IFNULL(sum(round(IFNULL(TRP.Saldo,0),2)),0) from transprod TRP ");
				consulta.append("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				consulta.append("where trp.FechaFacturacion < datetime('now','-" + oCliente.DiasVencimiento + " day') and ");
				consulta.append("vis.clienteclave = '" + oCliente.ClienteClave + "' and ");
				consulta.append("(trp.tipo =8) and trp.VisitaClave <> '" + ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave + "'  and trp.TipoFase <>0 ");
			}
			else
			{
				consulta.append("SELECT IFNULL(sum(round(TRP.Saldo + IFNULL((Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END),0),2)),0) as Saldo from transprod TRP ");
				consulta.append("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
				consulta.append("where trp.FechaFacturacion < datetime('now','-" + oCliente.DiasVencimiento + " day') and ");
				consulta.append("vis.clienteclave = '" + oCliente.ClienteClave + "' and ");
				consulta.append("(trp.tipo =8) and trp.VisitaClave <> '" + ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave + "'  and trp.TipoFase <>0 ");
			}
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if (datos.moveToNext())
			{
				resultado = datos.getFloat(0);
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
				sConsulta.append("From TransProd LEFT JOIN Visita ON TransProd.VisitaClave = Visita.VisitaClave and TransProd.DiaClave = Visita.DiaClave LEFT JOIN TRPDatoFiscal TDF on TDF.TransProdId = TransProd.TransProdId   ");
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
				sConsulta.append("From TransProd LEFT JOIN Visita ON TransProd.VisitaClave = Visita.VisitaClave  and TransProd.DiaClave = Visita.DiaClave LEFT JOIN TRPDatoFiscal TDF on TDF.TransProdId = TransProd.TransProdId   ");
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

		public static Cursor obtenerPedidoSugerido(String clienteClave, int frecuenciaDia, String precioClave, String transProdIds, ArrayList<Integer> tipoPedido, boolean soloConPrecio, String filtrosExistencia) throws Exception {
			StringBuilder sConsulta = new StringBuilder();
			ISetDatos dsProducto;
			int nTipoPedido = 1; // Pedido sugerido

			sConsulta.append("select PRS.ProductoClave as _id, PRS.ProductoClave as ProductoClave, PRS.ProductoClave || ' - ' || PRO.Nombre as Producto, PRO.DecimalProducto as DecimalProducto, PRS.PRUTipoUnidad as PRUTipoUnidad, PRS.Cantidad as Sugerido, PPV.Precio as Precio  " + ((transProdIds != null && transProdIds.length() > 0) ? ",TPD.Cantidad as Cantidad " : ""));
			sConsulta.append("from PedidoSugerido PRS ");
			sConsulta.append("inner join Producto PRO on PRS.ProductoClave = PRO.ProductoClave ");
			sConsulta.append("inner join ProductoUnidad PDE on PDE.ProductoClave = PRO.ProductoClave and PDE.PRUTipoUnidad = PRS.PRUTipoUnidad ");
			sConsulta.append((soloConPrecio ? "inner " : "left ") + " join PrecioProductoVig PPV on PPV.ProductoClave = PRS.ProductoClave and PPV.PRUTipoUnidad = PRS.PRUTipoUnidad and PPV.PrecioClave in(" + precioClave + ") ");
			sConsulta.append("and DATETIME('now')  between PPV.PPVFechaInicio and PPV.FechaFin ");
			if (transProdIds != null && transProdIds.length() > 0) {
				sConsulta.append("left join TransProdDetalle TPD on TPD.TransProdId in(" + transProdIds + ") and TPD.ProductoClave = PRS.ProductoClave and TPD.TipoUnidad=PRS.PRUTipoUnidad ");
			}
			sConsulta.append("where PRS.ClienteClave = '" + clienteClave + "' and PRS.Frecuencia = " + frecuenciaDia);
			if (filtrosExistencia.length() > 0) {
				sConsulta.append(" and not(" + filtrosExistencia + ")");
			}

			dsProducto = BDVend.consultar(sConsulta.toString());

			if (dsProducto.getCount() == 0) {
				nTipoPedido = 2; // Producto prioritario

				ArrayList<String> aEsquemas = Clientes.recuperarEsquemasPPE(clienteClave);
				if (!aEsquemas.isEmpty()) {
					sConsulta = new StringBuilder();
					sConsulta.append("select PPE.ProductoClave as _id, PPE.ProductoClave as ProductoClave,PPE.ProductoClave || ' - ' || PRO.Nombre as Producto, PRO.DecimalProducto as DecimalProducto, PDE.PRUTipoUnidad as PRUTipoUnidad, 1 as Sugerido, PPV.Precio as Precio " + ((transProdIds != null && transProdIds.length() > 0) ? ",TPD.Cantidad as Cantidad " : ""));

					sConsulta.append("from ProductoPrioritarioEsq PPE ");
					sConsulta.append("inner join Producto PRO on PPE.ProductoClave = PRO.ProductoClave ");
					sConsulta.append("inner join ProductoDetalle PDE on PPE.ProductoClave = PDE.ProductoClave and PPE.ProductoClave = PDE.ProductoDetClave and PDE.Factor in ");
					sConsulta.append("(Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave in(" + precioClave + "))");
					sConsulta.append((soloConPrecio ? "inner " : "left ") + " join PrecioProductoVig PPV on PPV.ProductoClave = PPE.ProductoClave and PPV.PRUTipoUnidad = PDE.PRUTipoUnidad and PPV.PrecioClave in(" + precioClave + ") ");
					sConsulta.append("and DATETIME('now')  between PPV.PPVFechaInicio and PPV.FechaFin ");
					if (transProdIds != null && transProdIds.length() > 0) {
						sConsulta.append("left join TransProdDetalle TPD on TPD.TransProdId in(" + transProdIds + ") and TPD.ProductoClave = PPE.ProductoClave and TPD.TipoUnidad=PDE.PRUTipoUnidad ");
					}

					sConsulta.append("where PPE.EsquemaID in (" + aEsquemas.toString().replace("[", "").replace("]", "") + ") and PPE.ProductoClave not in( ");
					sConsulta.append("select ProductoClave ");
					sConsulta.append("from ExcepcionProductoPri ");
					sConsulta.append("where ClienteClave = '" + clienteClave + "' and TipoExcepcion = 2) ");
					if (filtrosExistencia.length() > 0) {
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
					if (transProdIds != null && transProdIds.length() > 0) {
						sConsulta.append("left join TransProdDetalle TPD on TPD.TransProdId in(" + transProdIds + ") and TPD.ProductoClave = EPP.ProductoClave and TPD.TipoUnidad=PDE.PRUTipoUnidad ");
					}

					sConsulta.append("where EPP.ClienteClave = '" + clienteClave + "' and EPP.TipoExcepcion = 1 ");
					if (filtrosExistencia.length() > 0) {
						sConsulta.append(" and not(" + filtrosExistencia + ")");
					}
				} else {
					sConsulta = new StringBuilder();
					sConsulta.append("select EPP.ProductoClave as _id,  EPP.ProductoClave as ProductoClave, EPP.ProductoClave || ' - ' || PRO.Nombre as Producto, PRO.DecimalProducto as DecimalProducto, PDE.PRUTipoUnidad as PRUTipoUnidad, 1 as Sugerido, PPV.Precio as Precio " + ((transProdIds != null && transProdIds.length() > 0) ? ",TPD.Cantidad as Cantidad " : ""));

					sConsulta.append(" from ExcepcionProductoPri EPP ");
					sConsulta.append("inner join Producto PRO on EPP.ProductoClave = PRO.ProductoClave ");
					sConsulta.append("inner join ProductoDetalle PDE on EPP.ProductoClave = PDE.ProductoClave and EPP.ProductoClave = PDE.ProductoDetClave and PDE.Factor in ");
					sConsulta.append("(Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave in(" + precioClave + "))");
					sConsulta.append((soloConPrecio ? "inner " : "left ") + " join PrecioProductoVig PPV on PPV.ProductoClave = EPP.ProductoClave and PPV.PRUTipoUnidad = PDE.PRUTipoUnidad and PPV.PrecioClave in(" + precioClave + ") ");
					sConsulta.append("and DATETIME('now')  between PPV.PPVFechaInicio and PPV.FechaFin ");
					if (transProdIds != null && transProdIds.length() > 0) {
						sConsulta.append("left join TransProdDetalle TPD on TPD.TransProdId in(" + transProdIds + ") and TPD.ProductoClave = EPP.ProductoClave and TPD.TipoUnidad=PDE.PRUTipoUnidad ");
					}
					sConsulta.append("where EPP.ClienteClave = '" + clienteClave + "' and EPP.TipoExcepcion = 1 ");
					if (filtrosExistencia.length() > 0) {
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

		public static String obtenerDevolucionAutomatica(Date fechaMinima, Date fechaMaxima) throws Exception{
			ISetDatos datos = BDVend.consultar("Select TransProdID from TransProd where Tipo = 4 and FechaCaptura between '" + Generales.getFormatoFecha(fechaMinima, "yyyy-MM-dd HH:mm:ss") +  "' and '" + Generales.getUltimaHora(fechaMaxima, "yyyy-MM-dd HH:mm:ss") +  "' ");
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
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave  ");
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
			consulta.append("SELECT TP.TransProdID as TransProdID, SE.SubEmpresaId as SubEmpresaId, Folio, Tipo, TipoFase, FechaCaptura, TP.Enviado as Enviado, SE.NombreCorto as NombreCorto, TDF.UUID as UUID FROM TransProd as TP inner join Visita as V ").
			append("on V.VisitaClave = TP.VisitaClave ").
			append("inner join SubEmpresa as SE on SE.SubEmpresaId = TP.SubEmpresaId  ").
			append("inner join TRPDatoFiscal TDF on TP.TransProdID = TDF.TransProdID ").
			append("WHERE TP.Tipo = 8 AND TP.VisitaClave ='").append(visitaActual.VisitaClave).append("' ");
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("TimbradoCFDIMovil") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("TimbradoCFDIMovil").toString().equals("1") ) {
				consulta.append("UNION ").
				append("SELECT TP.TransProdID as TransProdID, SE.SubEmpresaId as SubEmpresaId, Folio, Tipo, TipoFase, FechaCaptura, TP.Enviado as Enviado, SE.NombreCorto as NombreCorto, TDF.UUID as UUID ").
				append("FROM TransProd as TP ").
				append("inner join Visita as V on V.VisitaClave = TP.VisitaClave  and TP.DiaClave = V.DiaClave ").
				append("inner join SubEmpresa as SE on SE.SubEmpresaId = TP.SubEmpresaId ").
				append("inner join TRPDatoFiscal TDF on TP.TransProdID = TDF.TransProdID ").
				append("WHERE TP.Tipo = 8 AND TP.VisitaClave <>'" + visitaActual.VisitaClave + "' and V.DiaClave = '" + visitaActual.DiaClave + "'  and V.ClienteClave = '" + visitaActual.ClienteClave + "' and TP.Enviado = 1 ").
				append("order by Folio ");
			}
			
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
					fac.UUID =datos.getString("UUID");
					list.add(fac);
				}
			}
			datos.close();
			return list;
		}

		public static String obtenerFacturasConTimbradoPendiente(String clienteClaveActual) throws Exception{
			List<TransProdFactura> list = new ArrayList<TransProdFactura>();
			TransProdFactura fac = null;
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TP.TransProdID as TransProdID FROM TransProd as TP inner join Visita as V ").
					append("on V.VisitaClave = TP.VisitaClave ").
					append("inner join SubEmpresa as SE on SE.SubEmpresaId = TP.SubEmpresaId  ").
					append("inner join TRPDatoFiscal TDF on TP.TransProdID = TDF.TransProdID ").
					append("WHERE TP.Tipo = 8 and IFNULL(TDF.UUID,'') = '' and V.DiaClave = '" +  ((Dia)Sesion.get(Campo.DiaActual)).DiaClave + "' ");
					if (clienteClaveActual.length()>0){
						consulta.append(" and V.ClienteClave ='" +  clienteClaveActual + "' ");
					}

			ISetDatos datos = BDVend.consultar(consulta.toString());
			String listadoFacturas = "";
			if(datos != null && datos.getCount()>0){
				while(datos.moveToNext())
				{
					listadoFacturas += datos.getString("TransProdID") + ",";
				}
				if (listadoFacturas.length()>0) {
					listadoFacturas = listadoFacturas.substring(0, listadoFacturas.length() - 1);
				}
			}
			datos.close();
			return listadoFacturas;
		}


		public static HashMap<String, String> obtenerTipoRegimen(String transProdID) throws Exception{
			/*Regresa el TipoRegimen y el Numero de Certificado*/
			HashMap<String, String> resultado = new HashMap<String,String>();
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select distinct CR.TipoRegimen as TipoRegimen, FF.NumCertificado as NumCertificado ").
					append("from TRPDatoFiscal TDF ").
					append("inner join FolioFiscal FF on TDF.FolioID = FF.FolioID and TDF.FosId = FF.FosId ").
					append("inner join CentroExpedicion CE on CE.NumCertificado = FF.NumCertificado ").
					append("inner join CEERegimenFiscal CR on CE.CentroExpId = CR.CentroExpId ").
					append("where TDF.TransProdID = '" + transProdID + "' ");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			if(datos != null) {
				while (datos.moveToNext()) {
					resultado.put("TipoRegimen",datos.getString("TipoRegimen"));
					resultado.put("NumCertificado",datos.getString("NumCertificado"));
				}
			}
			datos.close();
			return resultado;
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
			append(CFVTipo).append(" AND SubEmpresaID = '").append(subEmpresaId).append("' ");
			if (CFVTipo == 1){
				consulta.append("UNION ALL ").
				append("SELECT TransProdID, SubEmpresaId, Folio, Tipo, TipoFase, FechaCaptura, TP.Enviado, CFVTipo, FechaSurtido, ").
				append("Subtotal, Impuesto, Total, Saldo, FechaCobranza ").
				append("FROM TransProd as TP inner join Visita as V ").
				append("on (V.VisitaClave = TP.VisitaClave) OR (V.VisitaClave = TP.VisitaClave1) WHERE TP.Tipo = 1 AND TP.TipoFase = 2 AND ").
				append("V.DiaClave ='").append(dia.DiaClave).append("' AND V.ClienteClave = '").append(cliente.ClienteClave).append("' AND ").
				append("V.VisitaClave = '").append(visita.VisitaClave).append("' AND TP.CFVTipo =2 ").
				append(" AND SubEmpresaID = '").append(subEmpresaId).append("' and TP.Saldo = 0 ");
			}

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

		public static boolean existenSoloVentas(String DiaClave, String ClienteClave) throws Exception
		{
			boolean resultado = false;
			ISetDatos datos = BDVend.consultar("select VIS.VisitaClave from Visita VIS inner join TransProd TRP on VIS.VisitaClave = CASE WHEN  TRP.VisitaClave1 is null THEN TRP.VisitaClave  ELSE TRP.VisitaClave1 END and  VIS.DiaClave = CASE WHEN  TRP.DiaClave1 is null THEN TRP.DiaClave  ELSE TRP.DiaClave1 END where VIS.DiaClave = '" + DiaClave + "' and VIS.ClienteClave = '" + ClienteClave + "' and (TRP.Tipo = 1 or TRP.Tipo = 24) ");
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
					.append("inner join Visita v on v.ClienteClave = a.ClienteClave and v.FueraFrecuencia = 1 and v.RUTClave = '" + ruta + "' and v.DiaClave = '" + diaClave + "' ")
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

		public static ISetDatos obtenerCONHist() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT * FROM CONHist ORDER BY CONHistFechaInicio DESC LIMIT 1");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerCobranzaPorCliente(String clienteClave, int tipoTransProd, int tipoFiscal) throws Exception{

			if ( tipoFiscal == 1 ){
				tipoTransProd = 1;
			} else if ( tipoFiscal == 2 ){
				tipoTransProd = 8;
			}

			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct c.Clave, c.NombreCorto, t.TransProdID,t.Folio,t.FechaCaptura,t.Total as Importe,t.Saldo from TransProd t ")
					.append("inner join Visita v on t.VisitaClave = v.VisitaClave ")
					.append("inner join Cliente c on v.ClienteClave = c.ClienteClave and c.ClienteClave = '" + clienteClave + "' ")
					.append("where t.Tipo = " + tipoTransProd + " and t.TipoFase != 0 and t.Saldo > 0 ")
					.append("order by c.Clave,t.Folio ");

			return BDVend.consultar(consulta.toString());
		}

        public static ISetDatos obtenerCobranzaPorCliente(String clienteClave) throws Exception{

            StringBuilder consulta = new StringBuilder();
            consulta.append("select distinct c.Clave, c.NombreCorto, t.TransProdID,t.Folio,t.FechaCaptura,t.Total as Importe,t.Saldo from TransProd t ")
                    .append("inner join Visita v on t.VisitaClave = v.VisitaClave ")
                    .append("inner join Cliente c on v.ClienteClave = c.ClienteClave and c.ClienteClave = '" + clienteClave + "' ")
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

		public static ISetDatos obtenerDescripcionPago(String ClientePagoId) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select V.Descripcion from VAVDescripcion V ")
					.append("where V.VARCodigo = 'PAGO' and V.VAVClave = '" + ClientePagoId +"'");

			ISetDatos result = BDTerm.consultar(consulta.toString());
			return result;
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
                        mTransProdDetalle.TipoUnidad = datos.getShort("Tipounidad");
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
					.append("WHERE tp.Tipo = 2 AND tp.TipoFase = 1 AND tp.FechaCaptura = '" + diaClave + "' ")
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
					.append("WHERE tp.Tipo = 2 AND tp.TipoFase = 1 AND tp.FechaCaptura = '" + diaClave + "' ")
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
					.append("WHERE tp.Tipo = 2 AND tp.TipoFase = 1 AND tp.FechaCaptura = '" + diaClave + "' ")
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

        public static ISetDatos obtenerFolios(String visitaClave) throws Exception{
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select trp.Folio from Visita vis inner join Transprod trp on vis.VisitaClave=trp.VisitaClave and trp.Tipo=1 and TipoFase<>0 ");
            sConsulta.append("where vis.VisitaClave='" + visitaClave + "'");
            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerFechasEntrega(String visitaClave) throws Exception{
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select distinct trp.FechaEntrega from Visita vis inner join Transprod trp on vis.VisitaClave=trp.VisitaClave and trp.Tipo=1 and TipoFase<>0 ");
            sConsulta.append("where vis.VisitaClave='" + visitaClave + "'");
            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerOrdenesCompra(String visitaClave) throws Exception{
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select distinct trpvta.PedidoAdicional from Visita vis inner join Transprod trp on vis.VisitaClave=trp.VisitaClave and trp.Tipo=1 and TipoFase<>0 ");
            sConsulta.append("left join TrpVtaAcreditada trpvta on trp.TransprodId=trpvta.TransprodId ");
            sConsulta.append("where vis.VisitaClave='" + visitaClave + "'");
            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerDetalles(String visitaClave) throws Exception{
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select pro.ProductoClave, pro.Nombre, tpd.TipoUnidad, sum(tpd.Cantidad) as Cantidad, tpd.Precio, sum(tpd.SubTotal) as Subtotal, sum(tpd.Impuesto) as Impuesto ");
            sConsulta.append("from Visita vis ");
            sConsulta.append("inner join Transprod trp on vis.VisitaClave=trp.VisitaClave and trp.Tipo=1 and trp.TipoFase<>0 ");
            sConsulta.append("inner join TransprodDetalle tpd on trp.TransprodId=tpd.TransprodId and coalesce(tpd.Promocion,0)<>2 ");
            sConsulta.append("inner join Producto pro on tpd.ProductoClave=pro.ProductoClave ");
            sConsulta.append("where vis.VisitaClave='" + visitaClave + "' ");
            sConsulta.append("group by pro.ProductoClave, pro.Nombre, tpd.TipoUnidad, tpd.Precio");
            return BDVend.consultar(sConsulta.toString());
        }

		public static ISetDatos obtenerVent(String TransProdID) throws Exception{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("select pro.ProductoClave, pro.Nombre, tpd.TipoUnidad, sum(tpd.Cantidad) as Cantidad, tpd.Precio, sum(tpd.SubTotal) as Subtotal, sum(tpd.Impuesto) as Impuesto ");
			sConsulta.append("from Visita vis ");
			sConsulta.append("inner join Transprod trp on vis.VisitaClave=trp.VisitaClave and trp.Tipo=1 and trp.TipoFase<>0 ");
			sConsulta.append("inner join TransprodDetalle tpd on trp.TransprodId=tpd.TransprodId and coalesce(tpd.Promocion,0)<>2 ");
			sConsulta.append("inner join Producto pro on tpd.ProductoClave=pro.ProductoClave ");
			sConsulta.append("where trp.TransprodId='" + TransProdID + "' ");
			sConsulta.append("group by pro.ProductoClave, pro.Nombre, tpd.TipoUnidad, tpd.Precio");
			return BDVend.consultar(sConsulta.toString());
		}

        public static ISetDatos obtenerPromociones(String visitaClave) throws Exception{
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select pro.ProductoClave, pro.Nombre, tpd.TipoUnidad, sum(tpd.Cantidad) as Cantidad ");
            sConsulta.append("from Visita vis inner join Transprod trp on vis.VisitaClave=trp.VisitaClave and trp.Tipo=1 and trp.TipoFase<>0 ");
            sConsulta.append("inner join TransprodDetalle tpd on trp.TransprodId=tpd.TransprodId and tpd.Promocion=2 ");
            sConsulta.append("inner join Producto pro on tpd.ProductoClave=pro.ProductoClave ");
            sConsulta.append("where vis.VisitaClave='" + visitaClave + "' ");
            sConsulta.append("group by pro.ProductoClave, pro.Nombre, tpd.TipoUnidad ");
            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerObservaciones(String visitaClave) throws Exception{
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select distinct trpvta.Observaciones ");
            sConsulta.append("from Visita vis ");
            sConsulta.append("inner join Transprod trp on vis.VisitaClave=trp.VisitaClave and trp.Tipo=1 and trp.TipoFase<>0 ");
            sConsulta.append("left join TrpVtaAcreditada trpvta on trp.TransprodId=trpvta.TransprodId ");
            sConsulta.append("where vis.VisitaClave='" + visitaClave + "' ");
            return BDVend.consultar(sConsulta.toString());
        }

		public static String obtenerTransProdIdXFolio(String folio) throws Exception{
			return BDVend.bd.ejecutarEscalar ("Select TransProdID from TransProd where Folio='" + folio + "' LIMIT 1 ");
		}

		public static ISetDatos obtenerDetallesVentaPreventa(String transprodID) throws Exception{
			StringBuilder sConsulta = new StringBuilder();

			sConsulta.append("select pro.Id, pro.ProductoClave, pro.Nombre, tpd.TipoUnidad, sum(tpd.Cantidad) as Cantidad, tpd.Precio, sum(tpd.SubTotal) as Subtotal, sum(tpd.Impuesto) as Impuesto ");
			sConsulta.append("from Transprod trp ");
			sConsulta.append("inner join TransprodDetalle tpd on trp.TransprodId=tpd.TransprodId and coalesce(tpd.Promocion,0)<>2 ");
			sConsulta.append("inner join Producto pro on tpd.ProductoClave=pro.ProductoClave ");
			sConsulta.append("where trp.TransProdID='" + transprodID + "' ");
			if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)){
				sConsulta.append("and trp.Tipo=1 and trp.TipoFase<>0 ");
			}else if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA)){
				sConsulta.append("and trp.Tipo=1 and trp.TipoFase=2 ");
			}
			sConsulta.append("group by pro.Id, pro.ProductoClave, pro.Nombre, tpd.TipoUnidad, tpd.Precio ");
			sConsulta.append("order by pro.Id");


			return BDVend.consultar(sConsulta.toString());
		}

        public static ISetDatos obtenerDescuentosPorProducto(String transprodID, String productoClave) throws Exception{
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select prm.Porcentaje, sum(tpp.PromocionImp) as Descuento ");
            sConsulta.append("from TransProdDetalle tpd ");
            sConsulta.append("inner join TrpPrp tpp on tpd.TransProdID = tpp.TransProdID and tpd.TransProdDetalleID = tpp.TransProdDetalleID ");
            sConsulta.append("inner join PromocionRegla prm on tpp.PromocionClave = prm.PromocionClave ");
            sConsulta.append("where tpd.TransProdId = '" + transprodID + "' and tpd.ProductoClave = '" + productoClave + "' ");
            sConsulta.append("group by prm.Porcentaje ");

            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerConsignasLiquidadasConSaldo(String clienteClave) throws Exception {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select TRP.Folio ");
            sConsulta.append("from TransProd TRP ");
            sConsulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
            sConsulta.append("where TRP.Tipo = 24 and TRP.TipoFase = 6 and TRP.Saldo > 0 and VIS.ClienteClave = '" + clienteClave + "' ");
            return BDVend.consultar(sConsulta.toString());
        }

        public static float obtenerImpuestoPorAbreviatura(String transProdID, String abreviatura) throws Exception {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select ifnull(sum(tdi.ImpuestoImp),0) as ImpuestoImp ");
            sConsulta.append("from TpdImpuesto tdi ");
            sConsulta.append("inner join Impuesto imp on tdi.ImpuestoClave = imp.ImpuestoClave ");
            sConsulta.append("where tdi.TransProdId = '" + transProdID + "' and imp.Abreviatura = '" + abreviatura + "' ");
            return (Float)BDVend.bd.ejecutarEscalarObject(sConsulta.toString());
        }

        public static ISetDatos obtenerImpuestosConDesc(String facturaID, String clienteClave) throws Exception {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select IMP.ImpuestoClave, IMP.Abreviatura, TDI.ImpuestoPor, sum(TDI.ImpDesGlb) as ImpDesGlb ");
            sConsulta.append("from TPDImpuesto TDI ");
            sConsulta.append("inner join TransProdDetalle TPD on TDI.TransProdId = TPD.TransProdId and TDI.TransProdDetalleId = TPD.TransProdDetalleId ");
            sConsulta.append("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ");
            sConsulta.append("inner join Impuesto IMP on TDI.ImpuestoClave = IMP.ImpuestoClave ");
            sConsulta.append("where TRP.TransProdId in (select TransProdID from TransProd where FacturaId = '" + facturaID + "') and Trp.Tipo = 1 ");
            sConsulta.append("and TDI.ImpuestoClave not in (");
            sConsulta.append("        select ImpuestoClave ");
            sConsulta.append("        from CLINoDesImp ");
            sConsulta.append("        where ClienteClave = '" + clienteClave + "' and datetime('now') between FechaInicio and FechaFin ) ");
            sConsulta.append("and TPD.Cantidad > 0 ");
            sConsulta.append("group by IMP.ImpuestoClave, IMP.Abreviatura, TDI.ImpuestoPor, IMP.Jerarquia ");
            sConsulta.append("order by IMP.Jerarquia ");
            return BDVend.consultar(sConsulta.toString());
        }

        public static double obtenerDescuentoImp(String facturaID) throws Exception{
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select case when sum(DescuentoImp) is null then 0 else sum(DescuentoImp) end as DescuentoImp ");
            sConsulta.append("from TransProd ");
            sConsulta.append("where FacturaID = '" + facturaID + "' and TipoFase <> 0 ");
            return (double)BDVend.bd.ejecutarEscalarObject(sConsulta.toString());
        }

        public static double obtenerSubtDetalle(String facturaID) throws Exception{
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select case when sum(SubtDetalle) is null then 0 else sum(SubtDetalle) end as SubtDetalle ");
            sConsulta.append("from TransProd ");
            sConsulta.append("where FacturaID = '" + facturaID + "' and TipoFase <> 0 ");
            return (double)BDVend.bd.ejecutarEscalarObject(sConsulta.toString());
        }

        public static String obtenerDatoFiscal(String facturaID, String campo) throws Exception{
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select ifnull(FOL." + campo + ", '') as " + campo + " from TRPDatoFiscal TDF ");
            sConsulta.append("inner join FolioFiscal  FOL on TDF.FolioId = FOL.FolioId and TDF.FOSId = FOL.FOSId ");
            sConsulta.append("where TransProdID = '" + facturaID + "' ");
            return BDVend.bd.ejecutarEscalar(sConsulta.toString());
        }

        public static double obtenerDesImporte(String facturaID, String tabla) throws Exception{
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select ifnull(round(sum(DesImporte),2) , 0) as DesImporte ");
            sConsulta.append("from " + tabla + " ");
            sConsulta.append("where TransProdId in (select TransProdId from TransProd where FacturaId = '" + facturaID + "') ");
            return (double)BDVend.bd.ejecutarEscalarObject(sConsulta.toString());
        }

		public static ISetDatos obtenerTransProdYSaldo(String transProdIds) throws Exception {

			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TRP.TransProdId as _id, TRP.TransProdId as TransProdID, TRP.Folio as Folio, TRP.Saldo - IFNULL(TRC.AbnChequePosfechado,0) as Saldo , 0 as Cantidad from TransProd TRP ");
			consulta.append("left join (Select TransProdId, sum(AbnChequePosfechado) as AbnChequePosfechado from TRPCheque group by TransProdID) TRC on TRC.TransProdID = TRP.TransProdID ");
			consulta.append(" where TRP.TransProdID in(" + transProdIds + ")");


			return BDVend.consultar(consulta.toString());
		}

        public static float obtenerPuntosPorCanjear(String transProdId){
            try{
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.append("select ifnull(sum(TPD.Cantidad * PRU.ValorPuntos), 0) as Puntos ");
                sConsulta.append("from TransProdDetalle TPD ");
                sConsulta.append("inner join ProductoUnidad PRU on TPD.ProductoClave = PRU.ProductoClave and TPD.TipoUnidad = PRU.PRUTipoUnidad ");
                sConsulta.append("where TPD.TransProdID = '" + transProdId + "' ");
                return (float)BDVend.bd.ejecutarEscalarObject(sConsulta.toString());
            }catch(Exception e)
            {
                return 0;
            }
        }

		public static String obtenerFoliosPorFacturarVisita() throws Exception{
			String visitaActual = ((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave;
			String resultado = "";
			ISetDatos datos = BDVend.consultar( "select Folio from TransProd where Tipo = 1 and TipoFase in (1,2) and (VisitaClave = '" + visitaActual + "' or VisitaClave1 = '" + visitaActual + "') ");
			while (datos.moveToNext()) {
				resultado +=datos.getString("Folio") + ",";
			}
			if(resultado.length()>0) {
				resultado = resultado.substring(0, resultado.length() - 1);
			}
			datos.close();
			return resultado;
		}
	}

	public static final class ConsultasTransProdDetalle
	{
		public static void eliminarRegaladosYCanjes(String TransProdId) throws Exception
		{
            BDVend.ejecutarComando("DELETE FROM TPDDatosExtra where TransProdID ='" + TransProdId + "' and TransProdDetalleID in(Select TransProdDetalleID  from TransProdDetalle TPD where TPD.TransProdID ='" + TransProdId + "'  and IFNULL(Promocion,0) in (2,3)) ");
            BDVend.ejecutarComando("DELETE FROM TPDImpuesto where TransProdID ='" + TransProdId + "' and TransProdDetalleID in(Select TransProdDetalleID  from TransProdDetalle TPD where TPD.TransProdID='" + TransProdId + "'  and IFNULL(Promocion,0) in (2,3)) ");
            BDVend.ejecutarComando("DELETE FROM TransProdDetalle WHERE TransProdID='" + TransProdId + "' AND IFNULL(Promocion,0) in (2,3) ");
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
            String clienteClave = ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave;
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select TPD.TransProdDetalleID as _id, TPD.*, PRO.Nombre as Descripcion, case when CantidadOriginal is null then '' else 'SUG:' end as Sugerido, ");
			consulta.append("case when INV.Disponible is null then 0 else CAST(((INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido)/PDE.Factor) as int) end as Existencia, PRO.DecimalProducto,");

            consulta.append("ifnull((select ex.SubEmpresaId ");
            consulta.append("from ExcepcionFac ex ");
            consulta.append("inner join ProductoEsquema pe on ex.EsquemaId = pe.EsquemaID ");
            consulta.append("inner join Producto pr on pe.ProductoClave = pr.ProductoClave ");
            consulta.append("where pr.ProductoClave = TPD.ProductoClave and ex.ClienteClave = '" + clienteClave + "' ");
            consulta.append("limit 1), PRO.SubEmpresaId) as SubEmpresaId, ");

            consulta.append("PRO.Venta, PRO.Contenido, P.Nombre, PRO.Tipo as TipoProducto, P.PrecioClave ");
			consulta.append("from TransProdDetalle TPD inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ");
			consulta.append("inner join productodetalle PDE on PRO.ProductoClave = PDE.ProductoClave AND PDE.ProductoDetClave = PRO.ProductoClave AND TPD.TipoUnidad = PDE.PRUTipoUnidad ");
			consulta.append("left join inventario INV on PRO.ProductoClave = INV.ProductoClave AND INV.AlmacenID = '" + ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID + "' ");
			consulta.append("left join TPDDatosExtra TPE on TPD.TransProdID = TPE.TransProdID and TPD.TransProdDetalleID = TPE.TransProdDetalleID ");
			consulta.append("left join Precio P on TPE.PrecioClave = P.PrecioClave ");
			// consulta.append("where TPD.TransProdID in (" + transProdId +
			// ") AND TPD.Total > 0 AND TPD.Promocion != 2 order by TPD.ProductoClave");
			consulta.append("where TPD.TransProdID in (" + transProdId + ") AND (IFNULL(TPD.Promocion,0) != 2) AND (IFNULL(TPD.Promocion,0) != 3)  order by TPD.ProductoClave");

            return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerDetalleDobleUnidad(String transProdId) throws Exception
		{
			// obtener todos los productos, excepto aquellos que se otorgaron
			// como promocion
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select TPD.TransProdDetalleID as _id, TPD.*,TDE.UnidadAlterna, TDE.CantidadAlterna, TDE.CantidadAlternaOriginal, PRO.Nombre as Descripcion, case when CantidadOriginal is null then '' else 'SUG:' end as Sugerido, ");
			consulta.append(" PRU.DecimalProducto as DecimalProd1, PRU2.DecimalProducto as DecimalProd2, PRO.SubEmpresaId, PRO.Venta, PRO.Contenido, PRO.Tipo as TipoProducto ");
			consulta.append("from TransProdDetalle TPD inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ");
			consulta.append("inner join TPDDatosExtra TDE on TPD.TransProdID = TDE.TransProdID and TPD.TransProdDetalleID = TDE.TransProdDetalleID ");
			consulta.append("left join ProductoUnidad PRU on PRO.ProductoClave = PRU.ProductoClave and TPD.TipoUnidad = PRU.PRUTipoUnidad ");
			consulta.append("left join ProductoUnidad PRU2 on PRO.ProductoClave = PRU2.ProductoClave and TDE.UnidadAlterna = PRU2.PRUTipoUnidad ");
			consulta.append("where TPD.TransProdID in (" + transProdId + ") AND (IFNULL(TPD.Promocion,0) != 2) AND (IFNULL(TPD.Promocion,0) != 3)  order by TPD.ProductoClave");
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerDetalle_Mov(String transProdId) throws Exception
		{
			// obtener todos los productos, excepto aquellos que se otorgaron
			// como promocion
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select TPD.TransProdDetalleID as _id, TPD.TransProdID as mTransProdID, TPD.ProductoClave as ProductoClave, TPD.Cantidad as Cantidad, PRO.Nombre as Descripcion, TPD.TipoMotivo as TipoMotivo, TPD.TipoUnidad as TipoUnidad, TPD.Total as Total ");
			consulta.append("from TransProdDetalle TPD inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ");
			consulta.append("inner join productodetalle PDE on PRO.ProductoClave = PDE.ProductoClave AND PDE.ProductoDetClave = PRO.ProductoClave AND TPD.TipoUnidad = PDE.PRUTipoUnidad ");
			consulta.append("left join inventario INV on PRO.ProductoClave = INV.ProductoClave AND INV.AlmacenID = '" + ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID + "' ");
			// consulta.append("where TPD.TransProdID in (" + transProdId +
			// ") AND TPD.Total > 0 AND TPD.Promocion != 2 order by TPD.ProductoClave");
			consulta.append("where TPD.TransProdID in ('" + transProdId + "')  order by TPD.ProductoClave");
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerDetalle_MovDobleUnidad(String transProdId) throws Exception
		{
			// obtener todos los productos, excepto aquellos que se otorgaron
			// como promocion
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select TPD.TransProdDetalleID as _id, TPD.TransProdID as mTransProdID, TPD.ProductoClave as ProductoClave, TPD.Cantidad as Cantidad, PRO.Nombre as Descripcion, TPD.TipoMotivo as TipoMotivo, TPD.TipoUnidad as TipoUnidad, ");
			consulta.append("PRU.DecimalProducto as DecimalProducto, TDE.UnidadAlterna as UnidadAlterna, TDE.CantidadAlterna as CantidadAlterna, PRU2.DecimalProducto as DecimalProductoAlterna, TPD.Total as Total ");
			consulta.append("from TransProdDetalle TPD inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ");
			consulta.append("inner join ProductoUnidad PRU on PRU.ProductoClave  = TPD.ProductoClave and PRU.PRUTipoUnidad= TPD.TipoUnidad ");
			consulta.append("left join TPDDatosExtra  TDE on TDE.TransProdID = TPD.TransProdID and TPD.TransProdDetalleID = TDE.TransProdDetalleID ");
			consulta.append("left join ProductoUnidad PRU2 on PRU2.ProductoClave  = TPD.ProductoClave and PRU2.PRUTipoUnidad= TDE.UnidadAlterna ");
			consulta.append("where TPD.TransProdID in ('" + transProdId + "')  order by TPD.ProductoClave");
			return BDVend.consultar(consulta.toString());
		}

        public static ISetDatos obtenerDetalleCanje(String transProdId) throws Exception
        {
            // obtener todos los productos, excepto aquellos que se otorgaron
            // como promocion
            StringBuilder consulta = new StringBuilder();
            consulta.append("select TPD.TransProdDetalleID as _id, TPD.TransProdID as mTransProdID, TPD.ProductoClave as ProductoClave, TPD.Cantidad as Cantidad, PRO.Nombre as Descripcion, TPD.TipoUnidad as TipoUnidad, PRU.ValorPuntos, (TPD.Cantidad * PRU.ValorPuntos) as TotalPuntos ");
            consulta.append("from TransProdDetalle TPD ");
            consulta.append("inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ");
            consulta.append("inner join ProductoDetalle PDE on PRO.ProductoClave = PDE.ProductoClave and PDE.ProductoDetClave = PRO.ProductoClave and TPD.TipoUnidad = PDE.PRUTipoUnidad ");
            consulta.append("inner join ProductoUnidad PRU on TPD.ProductoClave = PRU.ProductoClave and TPD.TipoUnidad = PRU.PRUTipoUnidad ");
            consulta.append("where TPD.TransProdID in ('" + transProdId + "')  order by TPD.ProductoClave ");
            return BDVend.consultar(consulta.toString());
        }

		public static void actualizarTipoMotivo(String transProdId, String transProdDetalleId, short tipoMotivo) throws Exception
		{
			BDVend.ejecutarComando("UPDATE TransProdDetalle SET TipoMotivo = " + tipoMotivo + " WHERE TransProdId = '" + transProdId + "' AND TransProdDetalleId = '" + transProdDetalleId + "'");
		}

		public static ISetDatos obtenerTotales(String transProdId) throws Exception
		{
			
			return BDVend.consultar("SELECT COUNT(*) as TotalProductos, SUM(TPD.Total) as Total, SUM(TPD.Cantidad * PRD.Factor) as Unidades,SUM(TPD.Cantidad*PU.KgLts) as Peso, SUM(TPD.Cantidad*PU.Volumen) as Volumen " +
					"FROM TransProdDetalle TPD inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and  TPD.ProductoClave = PRD.ProductoDetClave and TPD.TipoUnidad = PRD.PRUTipoUnidad " +
					"inner join ProductoUnidad PU on PU.ProductoClave = TPD.ProductoClave  and PU.PRUTipoUnidad = TPD.TipoUnidad WHERE TPD.TransProdId in (" + transProdId + ") AND (IFNULL(TPD.Promocion,0) != 2)  AND (IFNULL(TPD.Promocion,0) != 3) ");
		}

		public static ISetDatos obtenerTotalesDetalle(String transProdId) throws Exception
		{
			return BDVend.consultar("SELECT SUM(SubTotal) as SubTDetalle, SUM(Impuesto) as Impuesto, SUM(Total) as Total FROM TransProdDetalle WHERE TransProdId = '" + transProdId + "'"); // GROUP
																																															// BY
																																															// ProductoClave");
		}
        public static Float obtenerTotalesCanjes(String transProdId) throws Exception
        {
            return ((Float) BDVend.bd.ejecutarEscalarObject("SELECT SUM(Total) as TotalCanjes FROM TransProdDetalle WHERE TransProdId in(" + transProdId + ") and Promocion = 3 "));
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

		public static TransProdDetalle obtenerTPDDobleUnidadPorProducto(String productoClave,  String transProdsId) throws Exception
		{
			//El método no busca por la unidad, porque la unidad que esta en TransProdDetalle es la del precio.
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TransProdID, TransProdDetalleId FROM TransProdDetalle WHERE ProductoClave = '" + productoClave + "'  AND TransProdId in (" + transProdsId + ") AND (IFNULL(Promocion,0) <> 2) AND (IFNULL(Promocion,0) <> 3) ");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			TransProdDetalle oTPD;
			if (datos.getCount() > 0)
			{
				oTPD = new TransProdDetalle();
				datos.moveToNext();
				//Si se cambia el contenido del objeto, revisar donde se utiliza
				oTPD.TransProdID  = datos.getString("TransProdID");
				oTPD.TransProdDetalleID = datos.getString("TransProdDetalleID");

				datos.close();
				BDVend.recuperar(oTPD);
				if (oTPD.isRecuperado()){
					BDVend.recuperar(oTPD, TPDDatosExtra.class);
					return oTPD;
				}else{
					return null;
				}

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

		public static int obtenerPartida(String transProdId, String transProdDetalleId) throws Exception
		{
			int partida = 0;
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT Partida FROM TransProdDetalle WHERE TransProdId = '" + transProdId + "' and TransProdDetalleId = '" + transProdDetalleId + "' ");
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
			consulta.append("(TPD.Total / TPD.Cantidad)  as Precio, ((TPD.Total / TPD.Cantidad) * TPD.Cantidad) as Importe, ");
			consulta.append("CASE WHEN IMP.Abreviatura = 'IEPS' THEN 'C' ELSE ");
			consulta.append("CASE WHEN IMP.Abreviatura = 'IVA' THEN 'I' ELSE '' END END as Impuesto ");
			consulta.append("FROM TransprodDetalle TPD ");
			consulta.append("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ");
            consulta.append("inner join ProductoEsquema PRE on PRO.ProductoClave = PRE.ProductoClave ");
            consulta.append("inner join Esquema ESQ on PRE.EsquemaID = ESQ.EsquemaID ");
            consulta.append("left join Esquema ESQ2 on ESQ2.Clave= substr(ESQ.Clave, 1,  length(ESQ2.Clave)) and ESQ2.Nivel = 1 ");
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
			consulta.append("Select TPD.TransProdDetalleID as _id, TPD.*, PRO.Nombre as Descripcion, PRO.DecimalProducto as DecimalProducto, '$ ' || ROUND((TPD.Total / TPD.Cantidad),2)  as Precio2, '$ ' || ROUND(((TPD.Total / TPD.Cantidad) * TPD.Cantidad),2) as Importe2 ");
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
            consulta.append("SELECT TPD.Precio + sum(ifnull(TPI.ImpuestoPU, 0)) as PrecioImpuesto FROM TransProdDetalle TPD ").
                    append("left join TPDImpuesto TPI on TPD.TransProdID = TPI.TransProdID and TPD.TransProdDetalleID = TPI.TransProdDetalleID ").
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

        public static double obtenerNoDesglosablesPU(String TransProdID, String ProductoClave, String ClienteClave) throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select case when sum(ImpuestoPU) is null then 0 else sum(ImpuestoPU) end as ImpuestoPU ");
            consulta.append("from TpdImpuesto TDI ");
            consulta.append("inner join TransProdDetalle TPD on TDI.TransProdID = TPD.TransProdID and TDI.TransProdDetalleID = TPD.TransProdDetalleID ");
            consulta.append("where TPD.TransProdID = '" + TransProdID + "' and TPD.ProductoClave= '" + ProductoClave + "' and ifnull(TPD.Promocion, 0) <> 2 and ImpuestoClave in ( ");
            consulta.append("select ImpuestoClave ");
            consulta.append("from CLINoDesImp ");
            consulta.append("where ClienteClave = '" + ClienteClave + "' and datetime('now') between FechaInicio and FechaFin) ");

            ISetDatos sdPrecio =  BDVend.consultar(consulta.toString());
            double precio = 0;
            if (sdPrecio.moveToFirst()){
                precio = sdPrecio.getDouble("ImpuestoPU");
            }
            sdPrecio.close();
            return precio;
        }

        public static double obtenerNoDesglosablesDes(String TransProdID, String ProductoClave, String ClienteClave) throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select case when sum((TPD.Cantidad * ImpuestoPU) - ImpDesGlb) is null then 0 else sum((TPD.Cantidad * ImpuestoPU) - ImpDesGlb) end as ImpDesGlb ");
            consulta.append("from TpdImpuesto TDI ");
            consulta.append("inner join TransProdDetalle TPD on TDI.TransProdId = TPD.TransProdId and TDI.TransProdDetalleId = TPD.TransProdDetalleId ");
            consulta.append("where TDI.TransProdID = '" + TransProdID + "' and TPD.ProductoClave = '" + ProductoClave + "' and ifnull(TPD.Promocion, 0) <> 2 and TDI.ImpuestoClave in ( ");
            consulta.append("select ImpuestoClave ");
            consulta.append("from CLINoDesImp ");
            consulta.append("where ClienteClave = '" + ClienteClave + "' and datetime('now') between FechaInicio and FechaFin) ");

            ISetDatos sdPrecio =  BDVend.consultar(consulta.toString());
            double precio = 0;
            if (sdPrecio.moveToFirst()){
				precio = sdPrecio.getDouble("ImpDesGlb");
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
		public static void obtenerDetallesFactura(String folio, HashMap<String, HashMap<Integer,Float>> hmDetalles,String transProdIDDev) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("Select TPD.ProductoClave as ProductoClave, TPD.TipoUnidad as TipoUnidad, sum(TPD.Cantidad) - IFNULL( (Select sum(DEVD.Cantidad) from TransProd DEV inner join TransProdDetalle DEVD on DEV.TransProdID = DEVD.TransProdID and DEV.FacturaID =  FAC.TransProdID and DEVD.ProductoClave = TPD.ProductoClave and DEVD.TipoUnidad = TPD.TipoUnidad and DEV.TransProdId <> '" + transProdIDDev + "'),0)  as Cantidad ");
			sConsulta.append("from TransProd FAC ");
			sConsulta.append("inner join Visita VIS on VIS.VisitaClave = FAC.VisitaClave and VIS.DiaClave = FAC.DiaClave ");
			sConsulta.append("inner join TransProd VTA on VTA.FacturaID = FAC.TransProdID ");
			sConsulta.append("inner join TransProdDetalle TPD on VTA.TransProdID = TPD.TransProdID ");
			sConsulta.append("where FAC.Folio = '" + folio + "' and FAC.tipo = 8 and FAC.TipoFase = 1 and VIS.ClienteClave='" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' ");
			sConsulta.append("group by TPD.ProductoClave, TPD.TipoUnidad ");
			sConsulta.append("UNION ");
			sConsulta.append("Select TPD.ProductoClave as ProductoClave, TPD.TipoUnidad as TipoUnidad, sum(TPD.Cantidad) - IFNULL( (Select sum(DEVD.Cantidad) from TransProd DEV inner join TransProdDetalle DEVD on DEV.TransProdID = DEVD.TransProdID and DEV.FacturaID =  TRP.TransProdID and DEVD.ProductoClave = TPD.ProductoClave and DEVD.TipoUnidad = TPD.TipoUnidad and DEV.TransProdId <> '" + transProdIDDev + "') ,0)  as Cantidad ");
			sConsulta.append("from TransProd TRP ");
			sConsulta.append("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ");
			sConsulta.append("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
			sConsulta.append("where TRP.Folio = '" + folio + "' and TRP.tipo = 1 and TRP.TipoFase in(2,3) and VIS.ClienteClave ='" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' ");
			sConsulta.append("group by TPD.ProductoClave, TPD.TipoUnidad ");


			ISetDatos datos = BDVend.consultar(sConsulta.toString());


			while (datos.moveToNext()){
				HashMap<Integer, Float> unidCant = new HashMap<Integer,Float>();
				unidCant.put(datos.getInt("TipoUnidad"), datos.getFloat("Cantidad"));
				hmDetalles.put(datos.getString("ProductoClave"),  unidCant);
			}
			datos.close();
		}
		public static ISetDatos obtenerDetallesFacturaTimbrada(String TransProdID) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();

			sConsulta.append("Select TPD.ProductoClave as ProductoClave, PRO.Nombre as Nombre, IFNULL(PRO.ClaveSAT, '01010101') as PROClaveSAT, TPD.TipoUnidad as TipoUnidad, ");
			sConsulta.append("TPD.Cantidad as Cantidad, (TPD.Precio + case when TDI.ImpuestoPU is null then 0 else TDI.ImpuestoPU end) as Precio, ");
			sConsulta.append("IFNULL(TPD.DescuentoImp, 0) + ");
			sConsulta.append("IFNULL((Select sum(DesImporte) from TPDDes TDD where TDD.TransProdID = TPD.TransProdID and TDD.TransProdDetalleID = TPD.TransProdDetalleID),0) + ");
			sConsulta.append("IFNULL((Select sum(DesImporte) from TPDDesVendedor TDV where TDV.TransProdID = TPD.TransProdID and TDV.TransProdDetalleID = TPD.TransProdDetalleID),0) + ");
			sConsulta.append("case when TDI.ImpuestoPU is null then 0 else (TPD.Cantidad * TDI.ImpuestoPU) - TDI.ImpDesGlb end as Descuento, ");
			sConsulta.append("IFNULL(TPD.Promocion,0) as Promocion, TPD.Precio as PrecioPromo ");
			sConsulta.append("from TransProd TRP ");
			sConsulta.append("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
			sConsulta.append("left join ( ");
			sConsulta.append("	select TDI.TransProdId, TransProdDetalleId, sum(ImpuestoPU) as ImpuestoPU, sum(ImpDesGlb) as ImpDesGlb ");
			sConsulta.append("	from TpdImpuesto TDI ");
			sConsulta.append("	inner join TransProd TRP on TDI.TransProdId = TRP.TransProdID ");
			sConsulta.append("	inner join TransProd FAC on TRP.FacturaId = FAC.TransProdID ");
    		sConsulta.append("	inner join Visita VIS on FAC.VisitaClave = VIS.VisitaClave and FAC.DiaClave = VIS.DiaClave ");
			sConsulta.append("	where TRP.FacturaID = '" + TransProdID + "' ");
			sConsulta.append("	and ImpuestoClave in ( ");
			sConsulta.append("		select ImpuestoClave ");
			sConsulta.append("		from CLINoDesImp ");
			sConsulta.append("		where ClienteClave = VIS.ClienteClave and FAC.FechaHoraAlta between FechaInicio and FechaFin ) ");
			sConsulta.append("	group by TDI.TransProdId, TransProdDetalleId ");
			sConsulta.append(")as TDI on TPD.TransProdId = TDI.TransProdId and TPD.TransProdDetalleId = TDI.TransProdDetalleId ");
			sConsulta.append("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ");
			sConsulta.append("where TRP.FacturaID = '" + TransProdID + "' and not (IFNULL(TPD.Promocion,0) = 2 and TPD.Precio = 0) ");
			sConsulta.append("UNION ");
			sConsulta.append("Select TPD.ProductoClave as ProductoClave, PRO.Nombre as Nombre, IFNULL(PRO.ClaveSAT, '01010101') as PROClaveSAT, ");
			sConsulta.append("TPD.TipoUnidad as TipoUnidad, TPD.Cantidad as Cantidad,");
			sConsulta.append("IFNULL(PPV.Precio,IFNULL(PPVVen.Precio,1)) as Precio, ");
			sConsulta.append("TPD.DescuentoImp + IFNULL((Select sum(DesImporte) from TPDDes TDD where TDD.TransProdID = TPD.TransProdID and TDD.TransProdDetalleID = TPD.TransProdDetalleID),0) + IFNULL((Select sum(DesImporte) from TPDDesVendedor TDV where TDV.TransProdID = TPD.TransProdID and TDV.TransProdDetalleID = TPD.TransProdDetalleID),0)  as Descuento, ");
			sConsulta.append("IFNULL(TPD.Promocion,0) as Promocion, TPD.Precio as PrecioPromo ");
			sConsulta.append("from TransProd TRP ");
			sConsulta.append("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
			sConsulta.append("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ");
			sConsulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
			sConsulta.append("inner join Vendedor VEN on VEN.VendedorID = VIS.VendedorID ");
			sConsulta.append("left join PrecioProductoVig PPV on PPV.PrecioClave = TRP.PCEPrecioClave and PPV.ProductoClave = TPD.ProductoClave and PPV.PRUTipoUnidad = TPD.TipoUnidad ");
			sConsulta.append("and TRP.FechaCaptura between PPV.PPVFechaInicio and PPV.FechaFin ");
			sConsulta.append("left join PrecioProductoVig PPVVen on PPVVen.PrecioClave = VEN.ListaPrecioBase and PPVVen.ProductoClave = TPD.ProductoClave and PPVVen.PRUTipoUnidad = TPD.TipoUnidad ");
			sConsulta.append("and TRP.FechaCaptura between PPVVen.PPVFechaInicio and PPVVen.FechaFin ");
			sConsulta.append("where TRP.FacturaID = '" + TransProdID + "' and  IFNULL(TPD.Promocion,0) = 2 and TPD.Precio = 0 ");
			sConsulta.append("order by PROClaveSAT ");
			return BDVend.consultar(sConsulta.toString());
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

		//Obtener las cargas cuando se usa DobleUnidad
		public static ISetDatos obtenerDetalleCargasDUPorTransferir()
		{
			StringBuilder Consulta = new StringBuilder();
			Consulta.append("Select distinct TPD.ProductoClave as ProductoClave, TPD.TipoUnidad as TipoUnidad, sum(TPD.Cantidad) as Cantidad,  PRU1.DecimalProducto as DecimalProducto, ");
			Consulta.append("TDE.UnidadAlterna as UnidadAlterna, sum(TDE.CantidadAlterna) as CantidadAlterna,PRU2.DecimalProducto as DecimalProductoAlterna ");
			Consulta.append("from TransProd TP ");
			Consulta.append("Inner Join TransProdDetalle TPD ON TP.TransProdId=TPD.TransProdId and TP.Tipo=2 and TP.TipoFase=5 and TP.MUsuarioId='" + ((Vendedor) Sesion.get(Campo.VendedorActual)).USUId + "' ");
			Consulta.append("inner join ProductoUnidad PRU1 on PRU1.ProductoClave=TPD.ProductoClave and PRU1.PRUTipoUnidad = TPD.TipoUnidad ");//"='" + ((Vendedor) Sesion.get(Campo.VendedorActual)).USUId + "' Inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave group by TPD.ProductoClave, TPD.TipoUnidad, PRO.DecimalProducto ";
			Consulta.append("left join TPDDatosExtra TDE on TDE.TransProdID = TPD.TransProdID and TDE.TransProdDetalleID = TPD.TransProdDetalleID ");
			Consulta.append("left join ProductoUnidad PRU2 on PRU2.ProductoClave  = TPD.ProductoClave and PRU2.PRUTipoUnidad = TDE.UnidadAlterna ");
			Consulta.append("group by TPD.ProductoClave, TPD.TipoUnidad, PRU1.DecimalProducto, TDE.UnidadAlterna, PRU2.DecimalProducto ");
			try
			{
				return BDVend.consultar(Consulta.toString());
			}
			catch (Exception e)
			{
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

			String Consulta = "select PRM.PromocionClave, PRM.Nombre, PRM.Tipo, PRM.TipoAplicacion, PRM.FechaFinal, PRM.PermiteCascada, PRM.TipoRango, PRM.TipoRegla, PRM.Obligatoria, ";
            Consulta += " PRM.SeleccionProducto, PRM.CapturaCantidad, PRM.PendienteEntrega, PRP.ProductoClave, PRO.Nombre as ProductoNombre, ifnull(PPV.Precio, 0) as Precio, ifnull(PRP.Cantidad, 0) as CantidadKit ";
            Consulta += " from Promocion PRM ";
            Consulta += " inner join PromocionModulo PMD on PRM.PromocionClave = PMD.PromocionClave and PMD.ModuloMovDetalleClave = '" + sModuloMovDetalleClave + "' and PMD.TipoEstado = 1 ";
            Consulta += " inner join PromocionProducto PRP on PRM.PromocionClave = PRP.PromocionClave ";
            Consulta += " inner join Producto PRO on PRP.ProductoClave = PRO.ProductoClave and PRO.TipoFase = 1 ";
            Consulta += " left join PrecioProductoVig PPV on PRO.ProductoClave = PPV.ProductoClave and  PPV.PRUTipoUnidad = (  select PRU.PRUTipoUnidad  from ProductoUnidad PRU  inner join ProductoDetalle PRD on PRU.ProductoClave = PRD.ProductoClave and PRU.PRUTipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave and PRU.TipoEstado = 1  where PRU.ProductoClave = PRO.ProductoClave  order by PRD.Factor limit 1)";
            Consulta += " and PPV.PrecioClave = '" + sPrecioClave + "' and  DATETIME('now') between PPV.PPVFechaInicio and PPV.FechaFin ";
            Consulta += " left join PromocionDetalle PRD on PRM.PromocionClave = PRD.PromocionClave and PRD.TipoEstado = 1 ";
            Consulta += " where PRM.TipoEstado = 1 and PRP.TipoEstado = 1 and DATETIME('now') between FechaInicial and FechaFinal ";
            Consulta += " and ((PRM.Tipo in (2,4) and PRD.EsquemaId in (" + sEsquemasCliente + ")) or PRM.Tipo = 1) ";
            Consulta += " group by PRM.PromocionClave, PRM.Nombre, PRM.Tipo, PRM.TipoAplicacion, PRM.FechaFinal, PRM.PermiteCascada, PRM.TipoRango, PRM.TipoRegla, PRM.Obligatoria, ";
            Consulta += " PRM.SeleccionProducto, PRM.CapturaCantidad, PRM.PendienteEntrega, PRP.ProductoClave, PRO.Nombre, PPV.Precio ";
            Consulta += " order by case when PRM.Tipo <> 4 then 0 else 1 end ";

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
                    aPromociones[i].CantidadKit = datos.getInt("CantidadKit");

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

		public static ISetDatos obtenerAplicables(String sModuloMovDetalleClave, String sEsquemasId, boolean bProntoPago) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			// sConsulta.append("select PRM.PromocionClave ");
			sConsulta.append("select distinct PRM.PromocionClave, PRM.Tipo, PRM.ValidaMultiplesEsquemas ");
			sConsulta.append("from Promocion PRM ");
			sConsulta.append("inner join PromocionModulo PMD on PRM.PromocionClave = PMD.PromocionClave ");
			sConsulta.append("left join PromocionDetalle PDE on PRM.PromocionClave = PDE.PromocionClave ");
			// sConsulta.append("where date('now') between PRM.FechaInicial and PRM.FechaFinal and PRM.TipoEstado = 1 ");
			sConsulta.append("where strftime('%Y-%m-%d','now','localtime') between strftime('%Y-%m-%d',PRM.FechaInicial) and strftime('%Y-%m-%d',PRM.FechaFinal) and PRM.TipoEstado = 1 ");
			sConsulta.append("and PMD.ModuloMovDetalleClave = '" + sModuloMovDetalleClave + "' and PMD.TipoEstado = 1 ");
			sConsulta.append("and (PRM.Tipo = 1 or (PRM.Tipo in (2,4,5,6) and PDE.EsquemaID in (" + sEsquemasId + "))) ");
            if (bProntoPago)
                sConsulta.append("and PRM.TipoAplicacion = 7 ");
            else
                sConsulta.append("and PRM.TipoAplicacion <> 7 "); //Excluir las promociones de pronto pago para aplicarlas al final

            ISetDatos dsPromocion = BDVend.consultar(sConsulta.toString());
            String sPromociones = "";
            while (dsPromocion.moveToNext())
            {
                if (dsPromocion.getBoolean("ValidaMultiplesEsquemas")){
                    if (validarEsquemas(dsPromocion.getString("PromocionClave"), sEsquemasId))
                        sPromociones += "'" + dsPromocion.getString("PromocionClave") + "',";
                }else{
                    sPromociones += "'" + dsPromocion.getString("PromocionClave") + "',";
                }
            }

            if (sPromociones.length() > 0)
                sPromociones = sPromociones.substring(0, sPromociones.length()-1);

            sConsulta = new StringBuilder();
            sConsulta.append("select distinct PRM.PromocionClave, PRM.Tipo ");
            sConsulta.append("from Promocion PRM ");
            sConsulta.append("where PRM.PromocionClave in (" + sPromociones + ")");
            return BDVend.consultar(sConsulta.toString());
		}

        public static boolean validarEsquemas(String sPromocionClave, String sEsquemasId) throws Exception {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select EsquemaId ");
            sConsulta.append("from PromocionDetalle ");
            sConsulta.append("where PromocionClave='" + sPromocionClave + "'"); //'and EsquemaId in (" + sEsquemasId + ") ");

            List<String> aEsquemas = Arrays.asList(sEsquemasId.replace("'", "").split(","));
            ISetDatos dsResult = BDVend.consultar(sConsulta.toString());
            boolean bResult = true;
            //int nCount = 0;

            while (dsResult.moveToNext()){
                if (!aEsquemas.contains(dsResult.getString("EsquemaId"))) {
                    bResult = false;
                    break;
                }
                //else
                //    nCount += 1;
            }
            //if (bResult && nCount < aEsquemas.size())
            //    bResult = false;

            dsResult.close();
            return bResult;
        }

        public static boolean validarEsquemasProducto(String sProductoClave, String sEsquemasId) throws Exception {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select EsquemaId ");
            sConsulta.append("from ProductoEsquema ");
            sConsulta.append("where ProductoClave ='" + sProductoClave + "'"); //'and EsquemaId in (" + sEsquemasId + ") ");

            List<String> aEsquemas = Arrays.asList(sEsquemasId.replace("'", "").split(","));
            ISetDatos dsResult = BDVend.consultar(sConsulta.toString());
            boolean bResult = true;
            int nCount = 0;

            while (dsResult.moveToNext()) {
                if (!aEsquemas.contains(dsResult.getString("EsquemaId"))) {
                    bResult = false;
                    break;
                }
                else
                    nCount += 1;

            }
            if (bResult && nCount < aEsquemas.size())
                bResult = false;

            dsResult.close();
            return bResult;
        }

        public static boolean obtenerValidaEsquemaProductos(String sPromocionClave) throws Exception {
            ISetDatos dsResult = BDVend.consultar("select ValidaEsquemasProducto from Promocion where PromocionClave = '" + sPromocionClave + "'");
            boolean bResult = false;
            while (dsResult.moveToNext()){
                    bResult = dsResult.getBoolean("ValidaEsquemasProducto");
                    break;
            }
            dsResult.close();
            return bResult;
        }

        /*public static ArrayList<Promociones2.PromocionProducto> obtenerProductosKit(String sPromocionClave){

        }*/

        public static HashMap<String, ArrayList<Promociones2.PromocionProducto>> obtenerProductosTrans(String sPromocionesClave, ArrayList<String> aPromocionesEsq, String sTransProdId, HashMap<String, ArrayList<Promociones2.PromocionProducto>> promocionProducto) throws Exception
        {
			HashMap<String, ArrayList<Promociones2.PromocionProducto>> res = new HashMap<String, ArrayList<Promociones2.PromocionProducto>>();
			if (sPromocionesClave.length()>0) {
				StringBuilder sConsulta = new StringBuilder();
				sConsulta.append("select distinct PRP.PromocionClave, PRP.ProductoClave, PRP.Jerarquia, IFNULL(PRP.Cantidad, 0) as Cantidad, IFNULL(TPD.TransProdID, '') as TransProdID ");
				sConsulta.append("from Promocion PRM ");
				sConsulta.append("inner join PromocionProducto PRP on PRM.PromocionClave = PRP.PromocionClave ");
				sConsulta.append("left join TransProdDetalle TPD on PRP.ProductoClave = TPD.ProductoClave and TPD.TransProdID = '" + sTransProdId + "'");
				sConsulta.append("left join TPDDatosExtra TDE on TPD.TransProdID = TDE.TransProdID and TPD.TransProdDetalleID = TDE.TransProdDetalleID ");
				sConsulta.append("left join PrecioProductoVig PPV on PPV.PrecioClave = TDE.PrecioClave and TPD.ProductoClave = PPV.ProductoClave and TPD.TipoUnidad= PPV.PRUTipoUnidad and ");
				sConsulta.append("DATETIME('now') between PPV.PPVFechaInicio and PPV.FechaFin ");
				sConsulta.append("where PRM.PromocionClave in (" + sPromocionesClave + ") AND IFNULL(TPD.Promocion,0) <> 2 AND IFNULL(TPD.Promocion,0) <> 3 ");
				sConsulta.append("and ifnull(PPV.Exclusion ,0) = 0 ");
				sConsulta.append("order by PRP.ProductoClave, PRP.Jerarquia, PRP.PromocionClave ");


				ISetDatos datos = BDVend.consultar(sConsulta.toString());

				while (datos.moveToNext()) {
                    if ((datos.getString("TransProdID").equals("") && datos.getInt("Cantidad") > 0) || !datos.getString("TransProdID").equals("")) {
                        if (promocionProducto.containsKey(datos.getString("PromocionClave"))) {
                                promocionProducto.get(datos.getString("PromocionClave")).add(new Promociones2.PromocionProducto(datos.getString("ProductoClave"), datos.getString("PromocionClave"), datos.getInt("Jerarquia"), datos.getInt("Cantidad")));
                        } else {
                            ArrayList<Promociones2.PromocionProducto> al = new ArrayList<Promociones2.PromocionProducto>();
                            al.add(new Promociones2.PromocionProducto(datos.getString("ProductoClave"), datos.getString("PromocionClave"), datos.getInt("Jerarquia"), datos.getInt("Cantidad")));
                            promocionProducto.put(datos.getString("PromocionClave"), al);
                        }

                        if (res.containsKey(datos.getString("ProductoClave"))) {
                            res.get(datos.getString("ProductoClave")).add(new Promociones2.PromocionProducto(datos.getString("ProductoClave"), datos.getString("PromocionClave"), datos.getInt("Jerarquia"), datos.getInt("Cantidad")));
                        } else {
                            ArrayList<Promociones2.PromocionProducto> al = new ArrayList<Promociones2.PromocionProducto>();
                            al.add(new Promociones2.PromocionProducto(datos.getString("ProductoClave"), datos.getString("PromocionClave"), datos.getInt("Jerarquia"), datos.getInt("Cantidad")));
                            res.put(datos.getString("ProductoClave"), al);
                        }
                    }
				}

				datos.close();
			}
			for (int i = 0 ; aPromocionesEsq.size()>i; i++){

				ArrayList<String> refaArreglo = new ArrayList<String>();
				ISetDatos sdPromocionEsquema =  BDVend.consultar("Select EsquemaId from PromocionEsquema where PromocionClave ='" + aPromocionesEsq.get(i) + "' ");

				while (sdPromocionEsquema.moveToNext()) {
					Productos.obtenerEsquemasHijos(sdPromocionEsquema.getString("EsquemaId"), refaArreglo);
				}
				sdPromocionEsquema.close();
				String esquemasPromocion = "";

				if (refaArreglo.size()>0){
					esquemasPromocion = TextUtils.join(",", refaArreglo);
				}

                refaArreglo.clear();
                boolean bValidarEsqProd = obtenerValidaEsquemaProductos(aPromocionesEsq.get(i));
                ISetDatos sdPromocionEsquemaExcep = BDVend.consultar("select EsquemaId from PromocionEsquemaExcep where PromocionClave = '" + aPromocionesEsq.get(i) + "' and IFNULL(Porcentaje, 0) = 0");
                while (sdPromocionEsquemaExcep.moveToNext()) {
                    Productos.obtenerEsquemasHijos(sdPromocionEsquemaExcep.getString("EsquemaId"), refaArreglo);
                }
                sdPromocionEsquemaExcep.close();
                String esquemasPromocionExcep = "";

                if (refaArreglo.size()>0){
                    esquemasPromocionExcep = TextUtils.join(",", refaArreglo);
                }

				if (esquemasPromocion.length()>0){
					StringBuilder sConsulta = new StringBuilder();
					sConsulta.append("select distinct PRM.PromocionClave, PRE.ProductoClave, 0 as Jerarquia, 0 as Cantidad from Promocion PRM, ProductoEsquema PRE ");
					sConsulta.append("inner join TransProdDetalle TPD on PRE.ProductoClave = TPD.ProductoClave ");
					sConsulta.append("left join TPDDatosExtra TDE on TPD.TransProdID = TDE.TransProdID and TPD.TransProdDetalleID = TDE.TransProdDetalleID  ");
					sConsulta.append("left join PrecioProductoVig PPV on PPV.PrecioClave = TDE.PrecioClave and TPD.ProductoClave = PRE.ProductoClave and TPD.TipoUnidad= PPV.PRUTipoUnidad and DATETIME('now') between ");
					sConsulta.append("PPV.PPVFechaInicio and PPV.FechaFin ");
					sConsulta.append("where PRM.Tipo = 6 and PRM.PromocionClave = '" + aPromocionesEsq.get(i) + "' and TPD.TransProdID = '" + sTransProdId + "' AND IFNULL(TPD.Promocion,0) <> 2 AND IFNULL(TPD.Promocion,0) <> 3 ");
					sConsulta.append("and ifnull(PPV.Exclusion ,0) = 0 and PRE.EsquemaID in(" + esquemasPromocion + ") ");
                    if (esquemasPromocionExcep.length() > 0) {
                        sConsulta.append("and PRE.ProductoClave not in (select ProductoClave from ProductoEsquema where EsquemaId in (" + esquemasPromocionExcep + ")) ");
                    }
					sConsulta.append("order by PRE.ProductoClave, PRM.PromocionClave  ");

					ISetDatos datos = BDVend.consultar(sConsulta.toString());

					while (datos.moveToNext()) {
                        if (bValidarEsqProd){
                            if (!validarEsquemasProducto(datos.getString("ProductoClave"), esquemasPromocion))
                                continue;
                        }

						if (promocionProducto.containsKey(datos.getString("PromocionClave"))) {
							promocionProducto.get(datos.getString("PromocionClave")).add(new Promociones2.PromocionProducto(datos.getString("ProductoClave"), datos.getString("PromocionClave"), datos.getInt("Jerarquia"), datos.getInt("Cantidad")));
						} else {
							ArrayList<Promociones2.PromocionProducto> al = new ArrayList<Promociones2.PromocionProducto>();
							al.add(new Promociones2.PromocionProducto(datos.getString("ProductoClave"), datos.getString("PromocionClave"), datos.getInt("Jerarquia"), datos.getInt("Cantidad")));
							promocionProducto.put(datos.getString("PromocionClave"), al);
						}

						if (res.containsKey(datos.getString("ProductoClave"))) {
							res.get(datos.getString("ProductoClave")).add(new Promociones2.PromocionProducto(datos.getString("ProductoClave"), datos.getString("PromocionClave"), datos.getInt("Jerarquia"), datos.getInt("Cantidad")));
						} else {
							ArrayList<Promociones2.PromocionProducto> al = new ArrayList<Promociones2.PromocionProducto>();
							al.add(new Promociones2.PromocionProducto(datos.getString("ProductoClave"), datos.getString("PromocionClave"), datos.getInt("Jerarquia"), datos.getInt("Cantidad")));
							res.put(datos.getString("ProductoClave"), al);
						}
					}

					datos.close();
				}
			}

/*			sConsulta.append("select distinct PRM.PromocionClave, PRE.ProductoClave, 0 as Jerarquia from Promocion PRM, ProductoEsquema PRE");
            sConsulta.append("inner join TransProdDetalle TPD on PRE.ProductoClave = TPD.ProductoClave ");
			sConsulta.append("left join TPDDatosExtra TDE on TPD.TransProdID = TDE.TransProdID and TPD.TransProdDetalleID = TDE.TransProdDetalleID ");
			sConsulta.append("left join PrecioProductoVig PPV on PPV.PrecioClave = TDE.PrecioClave and TPD.ProductoClave = PRE.ProductoClave and TPD.TipoUnidad= PPV.PRUTipoUnidad and DATETIME('now') between ");
			sConsulta.append("PPV.PPVFechaInicio and PPV.FechaFin ");
			sConsulta.append("where PRM.Tipo = 6  and PRE.EsquemaID ='" + + "' ");
			sConsulta.append("")*/
            return res;
        }

        public static ISetDatos obtenerPorcentajesExcep(String sPromocionClave) throws Exception{
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select EsquemaID, Porcentaje ");
            sConsulta.append("from PromocionEsquemaExcep ");
            sConsulta.append("where PromocionClave = '" + sPromocionClave + "' and IFNULL(Porcentaje,0) <> 0 ");

            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerProductosExcep(String sEsquemas, String sProductos) throws Exception{
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select ProductoClave from ProductoEsquema ");
            sConsulta.append("where EsquemaId in (" + sEsquemas + ") and ProductoClave in (" + sProductos + ") ");

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

		public static PromocionDetalle[] obtenerVistaDetalle(Promocion promocion, Integer cantidadGrupo, String productosDisparadores) throws Exception
		{
			ArrayList<PromocionDetalle> detalle = new ArrayList<PromocionDetalle>();
			StringBuilder consulta = new StringBuilder();

            consulta.append("select PRA.PromocionClave as PromocionClave,PRO.ProductoClave as ProductoClave, PRO.Nombre as Nombre, PRA.PRUTipoUnidad as PRUTipoUnidad, ");
			consulta.append("(PRA.Cantidad * " + cantidadGrupo + ") as Cantidad, PRO.DecimalProducto, PDE.Factor, PRA.Precio ");
			consulta.append("from Producto PRO ");
			consulta.append("inner join PromocionAplicacion PRA on PRO.ProductoClave = PRA.ProductoClave ");
			consulta.append("inner join ProductoDetalle PDE on PDE.ProductoClave = PRA.ProductoClave and PRA.PRUTipoUnidad = PDE.PRUTipoUnidad and  PRA.ProductoClave = PDE.ProductoDetClave ");
            consulta.append("where PRA.PromocionClave = '" + promocion.PromocionClave + "' and PRA.PromocionReglaId='" + promocion.PromocionReglaIdApp + "'");
			if (promocion.OtorgaSoloMismoProducto){
				consulta.append(" and PRA.ProductoClave in(" + productosDisparadores + ") ");
			}

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				String und = "";
				if (promocion.TipoAplicacion == 4  || promocion.TipoAplicacion == 6)
				{
                    und = ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(datos.getString("PRUTipoUnidad")));
				}
				PromocionDetalle pedido = new PromocionDetalle(datos.getString("PromocionClave"),
						datos.getString("ProductoClave"),
						datos.getString("Nombre"),
						datos.getInt("PRUTipoUnidad"),
						und, // Unidad
						datos.getFloat("Cantidad"), // Cantidad
						promocion.SeleccionProducto,
						promocion.CapturaCantidad,
						datos.getInt(5),
						datos.getInt("Factor"),
						promocion.PendienteEntrega,
						datos.getFloat("Precio"));
				detalle.add(pedido);
			}
			datos.close();

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
			String consulta = "SELECT Producto.ProductoClave as ProductoClave, Producto.Nombre as Nombre, TrpPrp.PromocionClave as PromocionClave, Promocion.Nombre as PromocionNombre, ";
            consulta += "Promocion.TipoAplicacion as TipoAplicacion, TrpPrp.PromocionImp as PromocionImp, TransProdDetalle.Precio as Precio, TransProdDetalle.TransProdDetalleID as TransProdDetalleID, ifnull(PromocionProducto.Cantidad, 0) as Cantidad ";
            consulta += "FROM Producto ";
            consulta += "JOIN TransProdDetalle ON Producto.ProductoClave = TransProdDetalle.ProductoClave ";
            consulta += "JOIN TrpPrp ON TransProdDetalle.TransProdDetalleID = TrpPrp.TransProdDetalleId AND TransProdDetalle.TransProdID = TrpPrp.TransProdId ";
            consulta += "JOIN Promocion ON Promocion.PromocionClave = TrpPrp.PromocionClave ";
            consulta += "LEFT JOIN PromocionProducto ON Promocion.PromocionClave = PromocionProducto.PromocionClave AND Producto.ProductoClave = PromocionProducto.ProductoClave ";
            consulta += "WHERE TrpPrp.TransProdId='" + TransProdsId + "'And  Producto.ProductoClave='" + ClaveProducto + "' and not Promocion.TipoAplicacion in(4,6) ";
			consulta += "UNION ";
			consulta += "SELECT Producto.ProductoClave as ProductoClave, Producto.Nombre as Nombre, TpdPun.PromocionClave as PromocionClave,  Promocion.Nombre as PromocionNombre, ";
            consulta += "Promocion.TipoAplicacion as TipoAplicacion, TpdPun.Puntos as PromocionImp, TransProdDetalle.Precio as Precio, TransProdDetalle.TransProdDetalleID as TransProdDetalleID, ifnull(PromocionProducto.Cantidad, 0) as Cantidad ";
            consulta += "FROM Producto ";
            consulta += "JOIN TransProdDetalle ON Producto.ProductoClave = TransProdDetalle.ProductoClave ";
            consulta += "JOIN TpdPun ON TransProdDetalle.TransProdDetalleID = TpdPun.TransProdDetalleId AND TransProdDetalle.TransProdID = TpdPun.TransProdId ";
            consulta += "JOIN Promocion ON Promocion.PromocionClave = TpdPun.PromocionClave ";
            consulta += "LEFT JOIN PromocionProducto ON Promocion.PromocionClave = PromocionProducto.PromocionClave AND Producto.ProductoClave = PromocionProducto.ProductoClave ";
            consulta += "WHERE TpdPun.TransProdId='" + TransProdsId + "' And  Producto.ProductoClave='" + ClaveProducto + "'  and not Promocion.TipoAplicacion in(4,6) ";
			return BDVend.consultar(consulta);
		}

		public static ISetDatos obtenerDesglosePromocionesClave(String TransProdsId) throws Exception
		{
			String consulta = "SELECT Producto.ProductoClave as ProductoClave,Producto.Nombre as Nombre FROM Producto JOIN TransProdDetalle ON Producto.ProductoClave = TransProdDetalle.ProductoClave JOIN TrpPrp ON TransProdDetalle.TransProdDetalleID = TrpPrp.TransProdDetalleId AND TransProdDetalle.TransProdID = TrpPrp.TransProdId JOIN Promocion ON Promocion.PromocionClave = TrpPrp.PromocionClave WHERE TrpPrp.TransProdId='" + TransProdsId + "' and not Promocion.TipoAplicacion in(4,6) GROUP BY Producto.ProductoClave ";
			consulta += "UNION ";
			consulta +="SELECT Producto.ProductoClave as ProductoClave,Producto.Nombre as Nombre FROM Producto JOIN TransProdDetalle ON  Producto.ProductoClave = TransProdDetalle.ProductoClave JOIN TpdPun ON TransProdDetalle.TransProdDetalleID = TpdPun.TransProdDetalleId AND TransProdDetalle.TransProdID = TpdPun.TransProdId JOIN Promocion ON Promocion.PromocionClave = TpdPun.PromocionClave WHERE TpdPun.TransProdId='" + TransProdsId + "' and not Promocion.TipoAplicacion in(4,6) GROUP BY Producto.ProductoClave";
			return BDVend.consultar(consulta);
		}

		public static ISetDatos obtenerDesglosePromocionesRegaloClave(String TransProdsId) throws Exception
		{
			String consulta = "SELECT Promocion.Promocionclave as PromocionClave,  Promocion.Nombre as PromocionNombre, Promocion.TipoAplicacion as TipoAplicacion,  Producto.ProductoClave as ProductoClave, Producto.Nombre as ProductoNombre FROM Producto JOIN TransProdDetalle ON Producto.ProductoClave = TransProdDetalle.ProductoClave JOIN TrpPrp ON TransProdDetalle.TransProdDetalleID = TrpPrp.TransProdDetalleId AND TransProdDetalle.TransProdID = TrpPrp.TransProdId JOIN Promocion ON Promocion.PromocionClave = TrpPrp.PromocionClave WHERE TrpPrp.TransProdId='" + TransProdsId + "' and Promocion.TipoAplicacion in(4,6) ";
			consulta += "UNION ";
			consulta +="SELECT Promocion.Promocionclave as PromocionClave,  Promocion.Nombre as PromocionNombre, Promocion.TipoAplicacion as TipoAplicacion, Producto.ProductoClave as ProductoClave, Producto.Nombre as ProductoNombre FROM Producto JOIN TransProdDetalle ON  Producto.ProductoClave = TransProdDetalle.ProductoClave JOIN TpdPun ON TransProdDetalle.TransProdDetalleID = TpdPun.TransProdDetalleId AND TransProdDetalle.TransProdID = TpdPun.TransProdId JOIN Promocion ON Promocion.PromocionClave = TpdPun.PromocionClave WHERE TpdPun.TransProdId='" + TransProdsId + "' and Promocion.TipoAplicacion in(4,6) ORDER BY  Promocion.PromocionClave ";
			return BDVend.consultar(consulta);
		}

        public static ISetDatos obtenerDesglosePromocionesProntoPago(String TransProdId)
        {
            try {
                String consulta = "select PRM.PromocionClave, PRM.Nombre, TPD.ProductoClave, TPD.Total, TPP.Porcentaje ";
                consulta += "from TransProdDetalle TPD ";
                consulta += "inner join TPDDesProntoPago TPP on TPD.TransProdID = TPP.TransProdID and TPD.TransProdDetalleID = TPP.TransProdDetalleID ";
                consulta += "inner join Promocion PRM on TPP.PromocionClave = PRM.PromocionClave ";
                consulta += "where TPD.TransProdID = '" + TransProdId + "' ";
                consulta += "order by PRM.PromocionClave, TPP.Porcentaje ";
                return BDVend.consultar(consulta);
            }catch (Exception e){
                return null;
            }
        }

        public static boolean validarProntoPagoAplicadas(String TransProdId) {
            try {
                String consulta = "select count(*) as Total ";
                consulta += "from TPDDesProntoPago ";
                consulta += "where TransProdID in (" + TransProdId + ") ";
                ISetDatos dsResult = BDVend.consultar(consulta);

                if (dsResult.getCount() > 0) {
                    dsResult.moveToFirst();
                    return (dsResult.getInt("Total") > 0);
                }
                return false;
            }catch (Exception e){
                return false;
            }
        }

		public static ISetDatos obtenerDescuento(String ClaveDescuento) throws Exception
		{
			return BDVend.consultar("Select PromocionRegla.Porcentaje, TrpPrp.PromocionImp from PromocionRegla join  TrpPrp  on PromocionRegla.PromocionClave = TrpPrp.PromocionClave where TrpPrp.PromocionClave='" + ClaveDescuento + "'");
		}

		public static ISetDatos obtenerRegalo(String TransProdsId, String TransProdDetalleId) throws Exception
		{
			return BDVend.consultar("Select distinct Producto.ProductoClave, TransProdDetalle.Cantidad, Producto.Nombre,TransProdDetalle.TipoUnidad  From  TransProdDetalle inner Join Producto on Producto.ProductoClave = TransProdDetalle.ProductoClave inner Join  TrpPrp on TransProdDetalle.PromocionClave = TrpPrp.PromocionClave and TransProdDetalle.TransProdID = TrpPrp.TransProdID  Where TrpPrp.TransProdId='" + TransProdsId + "' and TrpPrp.TransProdDetalleID='" + TransProdDetalleId + "'");
		}
		/*public static ISetDatos obtenerRegaloPromocion(String TransProdsId, String PromocionClave) throws Exception
		{
			return BDVend.consultar("Select distinct Producto.ProductoClave, TransProdDetalle.Cantidad, Producto.Nombre,TransProdDetalle.TipoUnidad  From  TransProdDetalle inner Join Producto on Producto.ProductoClave = TransProdDetalle.ProductoClave inner Join  TrpPrp on TransProdDetalle.PromocionClave = TrpPrp.PromocionClave and TransProdDetalle.TransProdID = TrpPrp.TransProdID  Where TrpPrp.TransProdId='" + TransProdsId + "' and TrpPrp.PromocionClave='" + PromocionClave + "'");
		}*/
        public static ISetDatos obtenerRegaloCanjes(String TransProdsId, String PromocionClave) throws Exception
        {
            return BDVend.consultar("Select distinct Producto.ProductoClave as ProductoClave, TransProdDetalle.Cantidad as Cantidad, Producto.Nombre as Nombre,TransProdDetalle.TipoUnidad as TipoUnidad, TransProdDetalle.Precio as Precio, TransProdDetalle.Total as Total  From  TransProdDetalle inner Join Producto on Producto.ProductoClave = TransProdDetalle.ProductoClave inner Join  TrpPrp on TransProdDetalle.PromocionClave = TrpPrp.PromocionClave and TransProdDetalle.TransProdID = TrpPrp.TransProdID  Where TrpPrp.TransProdId in(" + TransProdsId + ") and TrpPrp.PromocionClave='" + PromocionClave + "'");
        }
		public static ISetDatos obtenerPuntos(String TransProdId, String ProductoClave) throws Exception
		{
			return BDVend.consultar("Select TpdPun.Puntos From TpdPun Join TransProdDetalle On TpdPun.TransProdDetalleId = TransProdDetalle.TransProdDetalleId Where TpdPun.TransProdID='" + TransProdId + "' and TransProdDetalle.ProductoClave = '" + ProductoClave + "' and ifnull(TransProdDetalle.Promocion, 0) <> 2");
		}
        public static String recuperarTransProdDetalleIDPromocion(String transProdID, String productoClave, int tipoUnidad,  String promocionClave) throws Exception{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("Select TransProdDetalleID ");
			sConsulta.append("from TransProdDetalle ");
			sConsulta.append("where TransProdID ='" + transProdID + "' and ProductoClave = '" + productoClave + "' and TipoUnidad=" + tipoUnidad + " ");
			sConsulta.append("and (PromocionClave='" + promocionClave + "' or (Promocion = 2 and Cantidad = 0))");
            return BDVend.bd.ejecutarEscalar(sConsulta.toString());
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
			BDVend.ejecutarComando("DELETE FROM TPDImpuesto where TransProdId = '" + TransProdId + "' and TransProdDetalleID in(Select TransProdDetalle.TransProdDetalleID from TransProdDetalle WHERE TransProdDetalle.TransProdID='" + TransProdId + "' AND IFNULL(TransProdDetalle.Promocion,0) in(2,3))");
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

		public static ISetDatos obtenerImpuestosPrefactura(String TransProdID, String clienteClave) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT Imp.Abreviatura, SUM(TImp.ImpuestoImp) AS Impuesto FROM TPDImpuesto AS TImp ");
			consulta.append("INNER JOIN Impuesto AS Imp ON Imp.ImpuestoClave = TImp.ImpuestoClave ");
			consulta.append("WHERE TImp.TransProdID = (SELECT TransProdID FROM TransProd WHERE FacturaID = '" +TransProdID+ "') ");
			consulta.append("AND TImp.ImpuestoClave NOT IN(SELECT ImpuestoClave FROM CLINoDesImp WHERE FechaFin >= date() AND ClienteClave ='" +clienteClave+ "') ");
			consulta.append("GROUP BY Imp.Abreviatura, Imp.Jerarquia ");
			consulta.append("ORDER BY Imp.Jerarquia ASC");

			return BDVend.consultar(consulta.toString());
		}

		public static  HashMap<String, HashMap<String, HashMap<String,Object>>> obtenerImpuestosXProducto(String TransProdID) throws Exception{
			HashMap<String, HashMap<String, HashMap<String,Object>>> resultado = new HashMap<String, HashMap<String, HashMap<String,Object>>>();
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select TPD.ProductoClave as ProductoClave, ((sum(TDI.ImpDesGlb)/TDI.ImpuestoPor)*100) as SubTotal, ");
			consulta.append("IMP.ImpuestoClave as ImpuestoClave, IMP.Abreviatura as Abreviatura, TDI.ImpuestoPor as ImpuestoPor, ");
			consulta.append("sum(TDI.ImpDesGlb) as ImpDesGlb, IMP.Jerarquia as Jerarquia ");
			consulta.append("from TPDImpuesto TDI ");
			consulta.append("inner join TransProdDetalle TPD on TDI.TransProdId = TPD.TransProdId and TDI.TransProdDetalleId = TPD.TransProdDetalleId ");
			consulta.append("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ");
			consulta.append("inner join Impuesto IMP on TDI.ImpuestoClave = IMP.ImpuestoClave ");
			consulta.append("inner join TransProd FAC on TRP.FacturaID = FAC.TransProdID ");
			consulta.append("where TRP.FacturaId = '" + TransProdID + "' and Trp.Tipo = 1 ");
			consulta.append("and TPD.Cantidad > 0 and TDI.ImpuestoClave not in ( ");
			consulta.append("select ImpuestoClave ");
			consulta.append("from CLINoDesImp ");
			consulta.append("where ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' and FAC.FechaHoraAlta between FechaInicio and FechaFin) ");
			consulta.append("and not(IFNULL(TPD.Promocion, 0) = 2 and TPD.Precio = 0) ");
			consulta.append("and TDI.ImpuestoPor >0 ");
			consulta.append("group by TPD.ProductoClave,IMP.ImpuestoClave, IMP.Abreviatura , TDI.ImpuestoPor, IMP.Jerarquia ");
			consulta.append("UNION ");
			consulta.append("select  TPD.ProductoClave as ProductoClave, sum(TPD.Subtotal -(IFNULL((Select sum(DesImporte) from TPDDes TDD where TDD.TransProdID = TPD.TransProdID and TDD.TransProdDetalleID = TPD.TransProdDetalleID),0) + IFNULL((Select sum(DesImporte) from TPDDesVendedor TDD where TDD.TransProdID = TPD.TransProdID and TDD.TransProdDetalleID = TPD.TransProdDetalleID),0)))  as SubTotal, IMP.ImpuestoClave, IMP.Abreviatura as Abreviatura, TDI.ImpuestoPor, sum(TDI.ImpDesGlb) as ImpDesGlb, IMP.Jerarquia ");
			consulta.append("from TPDImpuesto TDI ");
			consulta.append("inner join TransProdDetalle TPD on TDI.TransProdId = TPD.TransProdId and TDI.TransProdDetalleId = TPD.TransProdDetalleId ");
			consulta.append("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ");
			consulta.append("inner join Impuesto IMP on TDI.ImpuestoClave = IMP.ImpuestoClave ");
			consulta.append("inner join TransProd FAC on TRP.FacturaID = FAC.TransProdID ");
			consulta.append("where TRP.FacturaId = '" + TransProdID + "' and Trp.Tipo = 1 ");
			consulta.append("and TPD.Cantidad > 0 and TDI.ImpuestoClave not in ( ");
			consulta.append("select ImpuestoClave ");
			consulta.append("from CLINoDesImp ");
			consulta.append("where ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' and FAC.FechaHoraAlta between FechaInicio and FechaFin) ");
			consulta.append("and not(IFNULL(TPD.Promocion, 0) = 2 and TPD.Precio = 0) ");
			consulta.append("and TDI.ImpuestoPor =0 ");
			consulta.append("group by TPD.ProductoClave,IMP.ImpuestoClave, IMP.Abreviatura, TDI.ImpuestoPor, IMP.Jerarquia ");
			consulta.append("order by ProductoClave, IMP.Jerarquia ");

			ISetDatos datos = BDVend.consultar(consulta.toString());

			String sProductoActual = "";
			String sImpuestoActual = "";
			float subTotal = 0;
			while (datos.moveToNext())
			{
				if (!sProductoActual.equals(datos.getString("ProductoClave"))){
					sProductoActual = datos.getString("ProductoClave");
					subTotal = datos.getFloat("SubTotal");
					resultado.put(sProductoActual, new HashMap<String, HashMap<String,Object>>());
					sImpuestoActual = "";
				}
				if (!sImpuestoActual.equals(datos.getString("Jerarquia") + "-" + datos.getString("ImpuestoClave"))){
					sImpuestoActual =  datos.getString("Jerarquia") + "-" + datos.getString("ImpuestoClave");
					if (!resultado.get(sProductoActual).containsKey(sImpuestoActual)){
						resultado.get(sProductoActual).put(sImpuestoActual, new HashMap<String,Object>());
					}
				}
				subTotal += datos.getFloat("ImpDesGlb");
				if (datos.getFloat("ImpuestoPor") == 0){
					if (Generales.getRound(subTotal ,2) != Generales.getRound(datos.getFloat("SubTotal"),2)){
						resultado.get(sProductoActual).get(sImpuestoActual).put("Base", subTotal);
					}else{
						resultado.get(sProductoActual).get(sImpuestoActual).put("Base", datos.getFloat("SubTotal"));
					}
				}else{
					resultado.get(sProductoActual).get(sImpuestoActual).put("Base", datos.getFloat("SubTotal"));
				}

				resultado.get(sProductoActual).get(sImpuestoActual).put("Impuesto", datos.getString("Abreviatura"));
				resultado.get(sProductoActual).get(sImpuestoActual).put("Tasa", datos.getFloat("ImpuestoPor"));
				resultado.get(sProductoActual).get(sImpuestoActual).put("Importe", datos.getFloat("ImpDesGlb"));
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
			//BDVend.ejecutarComando("update Punto set Saldo = Saldo - " + Puntos + ", Enviado = 0, MFechaHora = '" + Generales.getFechaHoraActualStr("yyyy-MM-dd HH:mm:ss") + "', MUsuarioID = '" + ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId + "' where ClienteClave ='" + ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave + "'");
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
		public static Short obtenerFormaVentaInicial(String ClienteClave) throws Exception
		{
			Integer iCFVTipo = BDVend.getBD().ejecutarEscalarInteger ("SELECT CFVTipo FROM CliFormaVenta WHERE Inicial = 1 AND Estado = 1 AND ClienteClave = '" + ClienteClave + "'");
			Short res = Short.parseShort(iCFVTipo.toString()) ;
			return res;
		}

		public static ISetDatos obtenerFormaVenta(String ClienteClave) throws Exception
		{
			return BDVend.consultar("SELECT CFVTipo, LimiteCredito, DiasCredito, Inicial, CapturaDias FROM CliFormaVenta WHERE Estado = 1 AND ClienteClave = '" + ClienteClave + "'");
		}

		public static ISetDatos obtenerFormaVenta(String ClienteClave, int CFVTipo) throws Exception
		{
			return BDVend.consultar("SELECT CFVTipo, ValidaLimite, LimiteCredito, DiasCredito, Inicial, CapturaDias FROM CliFormaVenta WHERE Estado = 1 AND ClienteClave = '" + ClienteClave + "' and CFVTipo = " + CFVTipo);
		}

        public static boolean obtenerValidaPagoContado(String ClienteClave) throws Exception {
            boolean validaPago = false;
            ISetDatos datos = BDVend.consultar("select ValidaPago from CLIFormaVenta where ClienteClave = '" + ClienteClave + "' and CFVTipo = 1");
            if (datos.getCount() > 0) {
                datos.moveToFirst();
                validaPago = datos.getBoolean("ValidaPago");
            }
            datos.close();
            return validaPago;
        }
	}

	public static final class ConsultasClientePago
	{
		public static ISetDatos obtenerFormaPago(String ClienteClave) throws Exception
		{
			return BDVend.consultar("SELECT ClienteClave, Tipo FROM ClientePago WHERE TipoEstado = 1 AND ClienteClave = '" + ClienteClave + "'");
		}

		public static String obtenerCuentaFormaPago(String ClienteClave, String Tipo) throws Exception{
			String tipo = "";
			ISetDatos datos = BDVend.consultar("SELECT Cuenta FROM ClientePago WHERE TipoEstado = 1 AND ClienteClave = '" +ClienteClave+ "' AND Tipo = '" +Tipo+ "'" );
			while (datos.moveToNext())
				tipo = datos.getString("Cuenta");

			return tipo;
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
			return BDVend.consultar("SELECT MonedaID as _id, Nombre, TipoCodigo, IFNULL(Simbolo, '') AS Simbolo FROM Moneda WHERE MonedaID = '" + MonedaID + "'");
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

		public static String obtenerPrecioClave(String TransProdId, String TransProdDetalleId) throws Exception
		{
			return BDVend.bd.ejecutarEscalar("select PrecioClave from TPDDatosExtra where TransProdId = '" + TransProdId + "' and TransProdDetalleId = '" + TransProdDetalleId + "'");
		}
    }

    public static final class ConsultasTPDDesProntoPago
    {
        public static void eliminarDescuentoPorDetalle(String TransProdId, String TransProdDetalleId) throws Exception
        {
            BDVend.ejecutarComando("DELETE FROM TPDDesProntoPago WHERE TransProdId = '" + TransProdId + "' AND TransProdDetalleId = '" + TransProdDetalleId + "'");
        }

        public static void eliminarPorTransProd(String TransProdId) throws Exception
        {
            BDVend.ejecutarComando("DELETE FROM TPDDesProntoPago WHERE TransProdId = '" + TransProdId + "'");
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
		public static ArrayList<Cobranza.VistaCobranza> obtenerCobranzaPorVisita(String diaClave, String clienteClave, String visitaClave) throws Exception {
			String notaCredito = ValoresReferencia.getStringVAVClave("PAGO", "NC");

			ArrayList<Cobranza.VistaCobranza> abonos = new ArrayList<Cobranza.VistaCobranza>();
			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct ABN.ABNId, ABN.Folio, Dia.FechaCaptura, ABN.Total, VIS.VisitaClave, VIS.DiaClave ");
			consulta.append("from Abono ABN ");
			consulta.append("inner join Dia on ABN.DiaClave = Dia.DiaClave ");
			consulta.append("inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave AND VIS.DiaClave = ABN.DiaClave ");
			consulta.append("inner join AbnTrp ABT on ABT.ABNId = ABN.ABNId  ");
			consulta.append("inner join Transprod TRP on TRP.TransProdID= ABT.TransProdID ");
			consulta.append("where VIS.ClienteClave = '" + clienteClave + "' and VIS.DiaClave = '" + diaClave + "' AND VIS.VisitaClave = '" + visitaClave + "'");
			if (((CONHist) Sesion.get(Campo.CONHist)).get("PagoAutomatico").equals("1")) {
				consulta.append(" AND (TRP.CFVTipo is null or TRP.CFVTipo=2 Or (TRP.CFVTipo = 1 AND TRP.ClientePagoId <> 1 ))  ");
			}
			if (( notaCredito != null) && notaCredito.length()>0){
				consulta.append("UNION ");
				//Se muestran los datos del abono original, porque si no, se repite la informacion por cada transprod
				consulta.append("select distinct ABN.ABNId, ABN.Folio, ABN.FechaCreacion as FechaCaptura,  ABN.Total, VIS.VisitaClave, VIS.DiaClave  from Abono ABN ");
				consulta.append("inner join ABNDetalle ABD on ABD.ABNId = ABN.ABNId ");
				consulta.append("inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave AND VIS.DiaClave = ABN.DiaClave ");
				consulta.append("inner join Transprod TRP on TRP.TransProdID= ABT.TransProdID ");
				consulta.append("inner join AbnTrp ABT on ABT.ABNId = ABN.ABNId ");
				consulta.append("inner join Visita VIS2 on VIS2.VisitaClave = ABT.VisitaClave AND VIS2.DiaClave = ABT.DiaClave ");
				consulta.append("where VIS2.ClienteClave = '" + clienteClave + "' and VIS2.DiaClave = '" + diaClave + "' AND VIS2.VisitaClave = '" + visitaClave + "' AND (ABD.TipoPago in(" + notaCredito + ")) ");
			}

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext()) {
				Cobranza.VistaCobranza abono = new Cobranza.VistaCobranza(datos.getString(0), datos.getString(1), datos.getDate(2), datos.getFloat(3), datos.getString(4), datos.getString(5));
				abonos.add(abono);
			}

			datos.close();

			return abonos;
		}

		public static Cobranza.VistaDocumentos[] obtenerDocumentosEnCobranza(String abnid) throws Exception
		{
			ArrayList<Cobranza.VistaDocumentos> documentos = new ArrayList<Cobranza.VistaDocumentos>();
			StringBuilder consulta = new StringBuilder();
			consulta.append("select TransProdId, Folio, Fecha, Total - (case when DevolucionCons is null then 0 else DevolucionCons end) as Total, Saldo, FechaCobranza, ifnull(Notas, '') as Referencia ");
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").equals("1")) {
				consulta.append(", Porc as DescProntoPago, Importe as ImporteDescPP ");
			}
			consulta.append("from ( select TRP.TransProdId, TRP.Folio, case when TRP.Tipo = 1 or TRP.Tipo = 24 then FechaSurtido else FechaFacturacion end as Fecha, Total, Saldo, ");
			consulta.append("(select sum(Total) from TrpTpd TTP where TTP.TransProdId1 = TRP.TransProdId) as DevolucionCons, TRP.FechaCobranza, TRP.Notas  ");
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").equals("1")) {
				consulta.append(", TDC.Porcentaje as Porc, TDC.Importe ");
			}
			consulta.append("from AbnTrp ABT ");
			consulta.append("inner join TransProd TRP on ABT.TransProdId = TRP.TransProdId ");
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").equals("1")) {
				consulta.append("left join TRPDescCalculadora TDC on TDC.TransProdId = TRP.TransProdId ");
			}
			consulta.append("where ABT.ABNId = '" + abnid + "' ");
			consulta.append(") as t ");
			consulta.append("order by Folio, Fecha ");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				Cobranza.VistaDocumentos documento = new Cobranza.VistaDocumentos(datos.getString(0), datos.getString(1), datos.getDate(2), datos.getFloat(3), datos.getFloat(4), datos.getDate(5), (datos.getColumnIndex("DescProntoPago") >0 ? datos.getFloat(datos.getColumnIndex("DescProntoPago")):0 ), (datos.getColumnIndex("ImporteDescPP") >0 ? datos.getFloat(datos.getColumnIndex("ImporteDescPP")):0 ), datos.getString(6));
				documentos.add(documento);
			}
			datos.close();

			return documentos.toArray(new Cobranza.VistaDocumentos[documentos.size()]);
		}

		public static Cobranza.VistaDocumentos[] obtenerDocumentosPorCobrar(String clienteClave, short tipoCobranza,String camposOrderBy) throws Exception
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

			consulta.append("select TransProdId, Folio, Fecha, Total - (case when DevolucionCons is null then 0 else DevolucionCons end) as Total, Saldo - Cheque as Saldo, FechaCobranza, ifnull(Notas, '') as Referencia ");
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").equals("1")) {
				consulta.append(", Porc as DescProntoPago, Importe as ImporteDescPP ");
			}
			consulta.append(" from ( select TRP.TransProdId, TRP.Folio, case when TRP.Tipo = 1 or TRP.Tipo = 24 then FechaSurtido else FechaFacturacion end as Fecha, Total, Saldo, ");
			consulta.append("(select sum(Total) from TrpTpd TTP where TTP.TransProdId1 = TRP.TransProdId) as DevolucionCons, ");
			consulta.append("(Round(case WHEN TRC.AbnChequePosfechado is null THEN 0 ELSE TRC.AbnChequePosfechado END,2)) as Cheque, TRP.FechaCobranza, TRP.Notas ");
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").equals("1")) {
				consulta.append(", TDC.Porcentaje as Porc, TDC.Importe ");
			}
			consulta.append(" from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").equals("1")) {
				consulta.append("left join TRPDescCalculadora TDC on TDC.TransProdId = TRP.TransProdId ");
			}
			consulta.append("left join (Select TransProdId, sum(AbnChequePosfechado) as AbnChequePosfechado from TRPCheque group by TransProdID) TRC on TRC.TransProdID = TRP.TransProdID ");
			//consulta.append("where TRP.Tipo in (" + trueType + ", 24) ");
            //consulta.append("and TRP.TipoFase <> 0 and TRP.Saldo > 0 and VIS.ClienteClave = '" + clienteClave + "' ");
            if (trueType == 8){
                consulta.append("where ((TRP.Tipo=24 and TRP.TipoFase<>0) or (TRP.Tipo=8 and TRP.TipoFase=1)) ");
                consulta.append("and TRP.Saldo > 0 and VIS.ClienteClave = '" + clienteClave + "' ");
            } else {
                consulta.append("where TRP.Tipo in (" + trueType + ", 24) ");
                consulta.append("and TRP.TipoFase <> 0 and TRP.Saldo > 0 and VIS.ClienteClave = '" + clienteClave + "' ");
            }
            if (((CONHist) Sesion.get(Campo.CONHist)).get("PagoAutomatico").equals("1")) {
                consulta.append(" AND (TRP.CFVTipo is null or TRP.CFVTipo=2 Or (TRP.CFVTipo = 1 AND TRP.ClientePagoId <> 1 ))  ");
            }
			consulta.append(") as t ");
			consulta.append("order by " + camposOrderBy);

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				if (Generales.getRound(datos.getFloat(4), 2) > 0)
				{
					Cobranza.VistaDocumentos documento = new Cobranza.VistaDocumentos(datos.getString(0), datos.getString(1), datos.getDate(2), datos.getFloat(3), datos.getFloat(4), datos.getDate(5), (datos.getColumnIndex("DescProntoPago") >0 ? datos.getFloat(datos.getColumnIndex("DescProntoPago")):0 ), (datos.getColumnIndex("ImporteDescPP") >0 ? datos.getFloat(datos.getColumnIndex("ImporteDescPP")):0 ), datos.getString(6));
					documentos.add(documento);
				}
			}
			datos.close();

			return documentos.toArray(new Cobranza.VistaDocumentos[documentos.size()]);
		}

        public static Cobranza.VistaDocumentos[] obtenerDocumentosPorCobrarPorSubEmpresa(String clienteClave, short tipoCobranza, String camposOrderBy, String sSubEmpresaId) throws Exception
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

            consulta.append("select TransProdId, Folio, Fecha, Total - (case when DevolucionCons is null then 0 else DevolucionCons end) as Total, Saldo - Cheque as Saldo, FechaCobranza, ifnull(Notas, '') as Referencia ");
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").equals("1")) {
                consulta.append(", Porc as DescProntoPago, Importe as ImporteDescPP ");
            }
            consulta.append(" from ( select TRP.TransProdId, TRP.Folio, case when TRP.Tipo = 1 or TRP.Tipo = 24 then FechaSurtido else FechaFacturacion end as Fecha, Total, Saldo, ");
            consulta.append("(select sum(Total) from TrpTpd TTP where TTP.TransProdId1 = TRP.TransProdId) as DevolucionCons, ");
            consulta.append("(Round(case WHEN TRC.AbnChequePosfechado is null THEN 0 ELSE TRC.AbnChequePosfechado END,2)) as Cheque, TRP.FechaCobranza, TRP.Notas ");
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").equals("1")) {
                consulta.append(", TDC.Porcentaje as Porc, TDC.Importe ");
            }
            consulta.append(" from TransProd TRP ");
            consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").equals("1")) {
                consulta.append("left join TRPDescCalculadora TDC on TDC.TransProdId = TRP.TransProdId ");
            }
            consulta.append("left join (Select TransProdId, sum(AbnChequePosfechado) as AbnChequePosfechado from TRPCheque group by TransProdID) TRC on TRC.TransProdID = TRP.TransProdID ");
            //consulta.append("where TRP.SubEmpresaId='" + sSubEmpresaId + "' and TRP.Tipo in (" + trueType + ", 24) ");
            //consulta.append("and TRP.TipoFase <> 0 and TRP.Saldo > 0 and VIS.ClienteClave = '" + clienteClave + "' ");
            if (trueType == 8){
                consulta.append("where TRP.SubEmpresaId='" + sSubEmpresaId + "' and ((TRP.Tipo=24 and TRP.TipoFase<>0) or (TRP.Tipo=8 and TRP.TipoFase=1)) ");
                consulta.append("and TRP.Saldo > 0 and VIS.ClienteClave = '" + clienteClave + "' ");
            } else {
                consulta.append("where TRP.SubEmpresaId='" + sSubEmpresaId + "' and TRP.Tipo in (" + trueType + ", 24) ");
                consulta.append("and TRP.TipoFase <> 0 and TRP.Saldo > 0 and VIS.ClienteClave = '" + clienteClave + "' ");
            }
            if (((CONHist) Sesion.get(Campo.CONHist)).get("PagoAutomatico").equals("1")) {
                consulta.append(" AND (TRP.CFVTipo is null or TRP.CFVTipo=2 Or (TRP.CFVTipo = 1 AND TRP.ClientePagoId <> 1 ))  ");
            }
            consulta.append(") as t ");
            consulta.append("order by " + camposOrderBy);

            ISetDatos datos = BDVend.consultar(consulta.toString());
            while (datos.moveToNext())
            {
                if (Generales.getRound(datos.getFloat(4), 2) > 0)
                {
                    Cobranza.VistaDocumentos documento = new Cobranza.VistaDocumentos(datos.getString(0), datos.getString(1), datos.getDate(2), datos.getFloat(3), datos.getFloat(4), datos.getDate(5), (datos.getColumnIndex("DescProntoPago") >0 ? datos.getFloat(datos.getColumnIndex("DescProntoPago")):0 ), (datos.getColumnIndex("ImporteDescPP") >0 ? datos.getFloat(datos.getColumnIndex("ImporteDescPP")):0 ), datos.getString(6));
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
			consulta.append("select ABDId, TipoPago, MON.MonedaID, Importe, TipoBanco, Cuenta, Referencia, FechaCheque, Observaciones ");
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

				Cobranza.VistaDetalle detalle = new Cobranza.VistaDetalle(datos.getString("ABDId"), datos.getInt("TipoPago"), formaPago, datos.getString("MonedaID"), moneda, datos.getFloat("Importe"), tipoBanco, banco, datos.getString("Cuenta"), datos.getString("Referencia"), datos.getDate("FechaCheque"), datos.getString("Observaciones"));
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

        public static float obtenerDescuentoProntoPago(ArrayList<String> transprodids) throws Exception
        {
            float descuento = 0;
            StringBuilder consulta = new StringBuilder();
            String fechaActual = Generales.getUltimaHora(Generales.getFechaActual(), "yyyy-MM-dd HH:mm:ss");

            int diasTolerancia = 0;

            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("DiasToleranciaProntoPago"))
                diasTolerancia =  Integer.parseInt(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("DiasToleranciaProntoPago"));

            consulta.append("select ifnull(sum(TDC.Importe), 0) as Descuento ");
            consulta.append("from TRPDescCalculadora TDC ");
            consulta.append("inner join TransProd TRP on TRP.TransProdID = TDC.TransProdID ");
            consulta.append("where  TDC.TransProdId in (" + transprodids.toString().replace("[", "").replace("]", "") + ") and datetime(TRP.FechaCobranza, '+"+ diasTolerancia + " day') >= '" + fechaActual + "' ");

            descuento = (Float) BDVend.bd.ejecutarEscalarObject(consulta.toString());
            return Generales.getRound(descuento, 2);
        }

        public static ISetDatos obtenerDetalleDescProntoPago(ArrayList<String> transprodids) throws Exception
        {
            float descuento = 0;
            StringBuilder consulta = new StringBuilder();
            String fechaActual = Generales.getUltimaHora(Generales.getFechaActual(), "yyyy-MM-dd HH:mm:ss");

            int diasTolerancia = 0;

            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("DiasToleranciaProntoPago"))
                diasTolerancia =  Integer.parseInt(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("DiasToleranciaProntoPago"));

            consulta.append("select TRP.TransProdID, TRP.Folio, TRP.Total, Saldo - (Round(case WHEN TRC.AbnChequePosfechado is null THEN 0 ELSE TRC.AbnChequePosfechado END,2)) as Saldo, TRP.FechaCobranza, TDC.Porcentaje, TDC.Importe ");
            consulta.append("from TransProd TRP ");
            consulta.append("left join (Select TransProdId, sum(AbnChequePosfechado) as AbnChequePosfechado from TRPCheque group by TransProdID) TRC on TRC.TransProdID = TRP.TransProdID ");
            consulta.append("inner join TRPDescCalculadora TDC on TRP.TransProdID = TDC.TransProdID ");
            consulta.append("where TRP.TransProdId in (" + transprodids.toString().replace("[", "").replace("]", "") + ") and datetime(TRP.FechaCobranza, '+"+ diasTolerancia + " day') >= '" + fechaActual + "' ");

            return BDVend.consultar(consulta.toString());
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
			//consulta.append("and TRP.Tipo in (" + trueType + ", 24) ");
			//consulta.append("and TRP.TipoFase <> 0 and VIS.ClienteClave = '" + clienteClave + "' and ");
            if (trueType == 8) {
                consulta.append("and ((TRP.Tipo=24 and TRP.TipoFase<>0) or (TRP.Tipo=8 and TRP.TipoFase=1)) ");
                consulta.append("and VIS.ClienteClave = '" + clienteClave + "' ");
            } else {
                consulta.append("and TRP.Tipo in (" + trueType + ", 24) ");
                consulta.append("and TRP.TipoFase <> 0 and VIS.ClienteClave = '" + clienteClave + "' and ");
            }
			consulta.append("TRP.Transprodid in ( select TransProdID from AbnTrp ABT where ABT.ABNId = '" + abnid + "')");

			return BDVend.consultar(consulta.toString());
		}

		public static String[] obtenerCriteriosCobranza() throws Exception
		{
			ISetDatos dsCriterios = BDVend.consultar("Select TipoCriterio, Ordenacion from CriterioCobranza order by Prioridad ");
			String sCampo = "";
			String criterioOrdenacion = "";
			String vistaCampos = "";
			while (dsCriterios.moveToNext())
			{
				sCampo = Consultas.ConsultasValorReferencia.obtenerDescripcion("TIPCRI", dsCriterios.getString("TipoCriterio"));
				criterioOrdenacion += sCampo + " " + (dsCriterios.getInt("Ordenacion") == 1 ? " asc" : " desc") + ",";
				if (!sCampo.toUpperCase().equals("SALDO"))
					vistaCampos += sCampo + (sCampo.contains("Fecha") ? " as Fecha" : "") + ",";
			}

			if (criterioOrdenacion.length() > 0)
				criterioOrdenacion = criterioOrdenacion.substring(0, criterioOrdenacion.length() - 1);

			if (vistaCampos.length() > 0)
				vistaCampos = vistaCampos.substring(0, vistaCampos.length() - 1);

			dsCriterios.close();

			String[] valores = new String[2];
			valores[0] = criterioOrdenacion;
			valores[1] = vistaCampos;

			return valores;
		}

		public static ISetDatos obtenerDocumentosCriterio(ArrayList<String> transprodids, String sListadoCampos, String sCriterioOrdenacion) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select TransProd.TransprodId, ROUND(Saldo  - (CASE WHEN TRC.AbnChequePosfechado is null THEN 0 ELSE TRC.AbnChequePosfechado END),2) as Saldo, TransProd.FechaCobranza as FechaCobranza ");
			consulta.append((sListadoCampos.equals("") ? " " : "," + sListadoCampos + " "));
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").equals("1")) {
                consulta.append(", TDC.Porcentaje as DescProntoPago, TDC.Importe as ImporteDescPP ");
			}
			consulta.append("from transprod ");
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").equals("1")) {
				consulta.append("left join TRPDescCalculadora TDC on TDC.TransProdId = transprod.TransProdId ");
			}
			consulta.append("left join (Select TransProdId, sum(AbnChequePosfechado) as AbnChequePosfechado from TRPCheque group by TransProdID) TRC on TRC.TransProdID = TransProd.TransProdID ");
			consulta.append("where TransProd.Transprodid in (" + transprodids.toString().replace("[", "").replace("]", "") + ") ");
			consulta.append((sCriterioOrdenacion.equals("") ? " " : "order by " + sCriterioOrdenacion));

			return BDVend.consultar(consulta.toString());
		}

        public static String obtenerSubEmpresaIdDocumentos(ArrayList<String> transprodids) throws Exception{
            StringBuilder consulta = new StringBuilder();
            consulta.append("Select TransProd.SubEmpresaId ");
            consulta.append("from transprod ");
            consulta.append("where TransProd.Transprodid in (" + transprodids.toString().replace("[", "").replace("]", "") + ") ");

            ISetDatos datos = BDVend.consultar(consulta.toString());
            String sSubEmpresaId = "";
            if (datos.getCount() > 0)
            {
                datos.moveToFirst();
                sSubEmpresaId = datos.getString(0);
            }
            datos.close();
            return sSubEmpresaId;
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
			consulta.append("ROUND(Saldo  - (CASE WHEN TRC.AbnChequePosfechado is null THEN 0 ELSE TRC.AbnChequePosfechado END),2) as Saldo, TransProd.FechaCobranza ");
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").equals("1")) {
                consulta.append(", TDC.Porcentaje as DescProntoPago, TDC.Importe as ImporteDescPP ");
			}
			consulta.append("from transprod ");
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").equals("1")) {
				consulta.append("left join TRPDescCalculadora TDC on TDC.TransProdId = transprod.TransProdId ");
			}
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
			consulta.append("and tp.CFVTipo = 2 and (tp.Tipo = ".concat(tipo).concat(" or tp.Tipo = 24) and tp.TipoFase <> 0"));
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
		public static List<Abono> AbonosConSaldoTipoNotaCredito()throws Exception
		{
			List<Abono> list = new ArrayList<Abono>();
			Abono abn = null;

			String notaCredito = ValoresReferencia.getStringVAVClave("PAGO", "NC");

			StringBuilder consulta = new StringBuilder();

			consulta.append("SELECT ABN.ABNId ");
			consulta.append("FROM Abono ABN inner join ABNDetalle ABD on ABN.ABNId = ABD.ABNId ");
			consulta.append("inner join Visita VIS on ABN.Visitaclave = VIS.VisitaClave and ABN.DiaClave = VIS.DiaClave ");
			consulta.append("where ABD.TipoPago in(" + notaCredito + ") and ABN.Saldo>0 and VIS.ClienteClave = '" + ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave + "' ");
			ISetDatos datos=  BDVend.consultar(consulta.toString());
			if (datos != null) {
				while (datos.moveToNext()) {
					abn = new Abono();
					abn.ABNId = datos.getString("ABNId");
					BDVend.recuperar(abn);
					BDVend.recuperar(abn,ABNDetalle.class);
					list.add(abn);
				}
			}
			datos.close();

			return list;
		}

        public static void ActualizaDescProntoPagoAplicado(String sTransprodId, boolean bAplicado) throws Exception
        {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("update TRPDescCalculadora ");
            sConsulta.append("set AplicadoCobranza=" + (bAplicado ? "1" : "0") + ", Enviado=0, ");
            sConsulta.append("MFechaHora='" + Generales.getFechaHoraActualStr("yyyy-MM-dd HH:mm:ss") + "', MUsuarioID='" + ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId + "'");
            sConsulta.append("where TransprodID = '" + sTransprodId + "'");
            BDVend.ejecutarComando(sConsulta.toString());
        }

        public static  float ObtenerDescProntoPagoAplicado(String sTransprodId) throws Exception
        {
            float descuento = 0;
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select Importe from TRPDescCalculadora ");
            sConsulta.append("where TransProdID = '" + sTransprodId + "' and AplicadoCobranza = 1 ");
            ISetDatos datos = BDVend.consultar(sConsulta.toString());
            if (datos.moveToNext())
            {
                descuento = datos.getFloat(0);
            }
            datos.close();

            return descuento;
        }

		public static int obtenerAbonosTarjeta(String AbnID) throws Exception{
			int cuantos = 0;
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT COUNT(TipoPago) AS Cuantos FROM ABNDetalle WHERE ABNId = '" +AbnID+ "' AND ");
			consulta.append("(TipoPago = 3 OR TipoPago = 4) AND PagoBillPocket = '1'");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if(datos.moveToFirst())
				cuantos = datos.getInt("Cuantos");

			return cuantos;
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

		public static ISetDatos obtenerInventarioDevolucion(String motivos) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select td.ProductoClave,sum(td.cantidad * pde.Factor) as NoDisponible, ");
			consulta.append("(Select PRUTipoUnidad from ProductoDetalle PDE2 where PDE2.ProductoClave = TD.ProductoClave and TD.ProductoClave = PDE2.ProductoDetClave and PDE2.Factor= ");
			consulta.append("(Select IFNULL(min(PDE3.factor),1) from ProductoDetalle PDE3 where PDE3.ProductoClave = PDE2.ProductoClave and PDE3.ProductoDetClave = PDE2.ProductoDetClave) limit 1) as TipoUnidadMin ");
			consulta.append("from transprod t ");
			consulta.append("inner join transproddetalle td  on td.transprodid=t.transprodid ");
			consulta.append("inner join ProductoDetalle pde on td.ProductoClave = PDE.ProductoClave and td.ProductoClave = PDE.ProductoDetClave and td.TipoUnidad = PDE.PRUTipoUnidad ");
			consulta.append("where ( (tipo=9 and tipomovimiento=1) or (tipo=3) ) and tipofase=1 and (t.Escritorio is null OR t.Escritorio = 0) and  td.tipomotivo in ("+motivos+") ");
			consulta.append("group by td.ProductoClave, (Select PRUTipoUnidad from ProductoDetalle PDE2 where PDE2.ProductoClave = TD.ProductoClave and TD.ProductoClave = PDE2.ProductoDetClave and PDE2.Factor= ");
			consulta.append("(Select IFNULL(min(PDE3.factor),1) from ProductoDetalle PDE3 where PDE3.ProductoClave = PDE2.ProductoClave and PDE3.ProductoDetClave = PDE2.ProductoDetClave) limit 1) ");

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

		public static ConsultaInventario.ListaInventarioDobleUnidad[] obtenerListaInventarioDobleUnidad()
		{
			ArrayList<ConsultaInventario.ListaInventarioDobleUnidad> listInventario = null;
			try
			{
				StringBuilder query = new StringBuilder();
				//query.append("select i.ProductoClave, p.Nombre, pd.PRUTipoUnidad, i.disponible as Existencia,(i.disponible - i.nodisponible - i.Apartado -i.contenido - i.pedido) as Disponible, (i.nodisponible + i.Apartado + i.Pedido) as NoDisponible, i.NoDisponible as MalEstado, pu.kglts ");
				query.append("select i.ProductoClave, p.Nombre, i.PRUTipoUnidad, i.disponible as Existencia,(i.disponible - i.nodisponible - i.Apartado -i.contenido) as Disponible, (i.nodisponible + i.Apartado) as NoDisponible, i.NoDisponible as MalEstado, pu.kglts,pu.DecimalProducto ");
				query.append("from InventarioUnidadesAlternas i ");
				query.append("inner join Producto p on i.ProductoClave = p.ProductoClave ");
				query.append("inner join productounidad pu  on pu.productoclave = i.productoclave and pu.PRUTipoUnidad = i.PRUTipoUnidad ");
				query.append("where i.disponible > 0  order by i.ProductoClave, pu.TipoEstado");
				ISetDatos dataQuery = BDVend.consultar(query.toString());
				listInventario = new ArrayList<ConsultaInventario.ListaInventarioDobleUnidad>();
				String productoClave= "";
				ConsultaInventario.ListaInventarioDobleUnidad itemInventory = null;
				while (dataQuery.moveToNext())
				{
					if (productoClave.equalsIgnoreCase(dataQuery.getString("ProductoClave"))){
						itemInventory.tipoUnidadAlt = dataQuery.getShort("PRUTipoUnidad");
						itemInventory.existenciaAlt = dataQuery.getFloat("Existencia");
						itemInventory.disponibleAlt = dataQuery.getFloat("Disponible");
						itemInventory.noDisponibleAlt = dataQuery.getFloat("NoDisponible");
						itemInventory.malEstadoAlt = dataQuery.getFloat("MalEstado");
						itemInventory.kgLtsAlt = dataQuery.getFloat("KgLts");
						itemInventory.decimalProductoAlt = dataQuery.getShort("DecimalProducto");
					}else{
						productoClave = dataQuery.getString("ProductoClave");
						itemInventory = new ConsultaInventario.ListaInventarioDobleUnidad();
						itemInventory.productoClave = dataQuery.getString("ProductoClave");
						itemInventory.productoNombre = dataQuery.getString("Nombre");

						itemInventory.tipoUnidad = dataQuery.getShort("PRUTipoUnidad");
						itemInventory.existencia = dataQuery.getFloat("Existencia");
						itemInventory.disponible = dataQuery.getFloat("Disponible");
						itemInventory.noDisponible = dataQuery.getFloat("NoDisponible");
						itemInventory.malEstado = dataQuery.getFloat("MalEstado");
						itemInventory.kgLts = dataQuery.getFloat("KgLts");
						itemInventory.decimalProducto = dataQuery.getShort("DecimalProducto");
						listInventario.add(itemInventory);
					}

				}
				dataQuery.close();
			}
			catch (Exception ex)
			{

			}
			if (listInventario.size() > 0)
			{
				return listInventario.toArray(new ConsultaInventario.ListaInventarioDobleUnidad[listInventario.size()]);
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

        public static float obtenerExistenciaDifNoDisponible(String productoClave, String listaPrecios) throws Exception
        {

            StringBuilder consulta = new StringBuilder();

            float existencia = 0;
            consulta.append("Select IFNULL(sum(INV.Disponible-INV.NoDisponible-INV.Contenido)/PDE.Factor,0) as Existencia ");
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

		public static float obtenerExistenciaDobleUnidad(String productoClave, short tipoUnidad, int tipoInventario ) throws Exception
		{

			StringBuilder consulta = new StringBuilder();

			float existencia = 0;
			if (tipoInventario == InventarioDobleUnidad.TiposInventario.NODISPONIBLE)
				consulta.append("Select IFNULL(sum(INV.NoDisponible),0) as Existencia ");
			else
				consulta.append("Select IFNULL(sum(INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido),0) as Existencia ");
			consulta.append("From InventarioUnidadesAlternas INV ");
			consulta.append("Inner join ProductoUnidad PRU on PRU.ProductoClave = INV.ProductoClave and PRU.PRUTipoUnidad = INV.PRUTipoUnidad ");
			consulta.append("Where INV.ProductoClave = '" + productoClave + "'  and INV.PRUTipoUnidad='" + tipoUnidad + "' ");

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

        public static ISetDatos ObtenerInventarioNGO() throws Exception{
            String noVenta = ValoresReferencia.getStringVAVClave("TRPMOT", "No Venta");
            int tipoModulo = Integer.parseInt(Sesion.get(Campo.TipoModulo).toString());

            StringBuilder query = new StringBuilder();

            if (tipoModulo == Enumeradores.TiposModulos.REPARTO){
                query.append("select ProductoClave, Nombre, sum(carga) as Carga, sum(Contado) as Contado, sum(Bonificacion) as Bonificacion, sum(Credito) as Credito, sum(Devolucion) as Devolucion ");
                query.append("from ( ");
                query.append("select TPD.ProductoClave, PRO.Nombre, 0 as Carga, ");
                query.append("sum(case when TRP.Tipo=1 and TRP.CFVTipo = 1 and TRP.TipoFase in (2,3) and TRP.FacturaId is null then TPD.Cantidad else 0 end) as Contado, ");
                query.append("sum(case when TRP.Tipo=1 and TRP.TipoFase in (2,3) and TRP.FacturaId is not null then TPD.Cantidad else 0 end) as Bonificacion, ");
                query.append("sum(case when TRP.Tipo=1 and TRP.CFVTipo = 2 and TRP.TipoFase in (2,3) and TRP.FacturaId is null then TPD.Cantidad else 0 end) as Credito, ");
                query.append("sum(case when TRP.Tipo = 7 then TPD.Cantidad else 0 end) as Devolucion ");
                query.append("from TransProd TRP ");
                query.append("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ");
                query.append("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido = 0 ");
                query.append("where (TRP.Tipo in (1, 7) or (TRP.Tipo = 9 and TRP.TipoMovimiento = 1 ");
                if (( noVenta != null) && noVenta.length()>0){
                    query.append("and TRP.TipoMotivo in ('" + noVenta + "') ");
                }
                query.append(")) ");
                query.append("and TRP.TipoFase <> 0 and (TRP.DiaClave in (select DiaClave from Dia where FueraFrecuencia = 0) or TRP.DiaClave1 in (select DiaClave from Dia where FueraFrecuencia = 0)) ");
                query.append("group by TPD.ProductoClave, PRO.Nombre ");
                query.append("union ");
                query.append("select TPD.ProductoClave, PRO.Nombre, sum(TPD.Cantidad) as Carga, 0 as Contado, 0 as Bonificacion, 0 as Credito, 0 as Devolucion ");
                query.append("from TransProd TRP ");
                query.append("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ");
                query.append("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ");
                query.append("where TRP.Tipo in (2) and TRP.TipoFase <> 0 ");
                query.append("group by TPD.ProductoClave, PRO.Nombre ");
                query.append(") as t ");
                query.append("group by ProductoClave, Nombre ");
            }
            else {
                query.append("select ProductoClave, Nombre, sum(Carga) as Carga, sum(Contado) as Contado, sum(Bonificacion) as Bonificacion, sum(Credito) as Credito, sum(Devolucion) as Devolucion ");
                query.append("from ( ");
                query.append("select TPD.ProductoClave, PRO.Nombre, 0 as Carga, ");
                query.append("sum(case when TRP.Tipo = 1 and TRP.CFVTipo = 1 then TPD.Cantidad else 0 end) as Contado, ");
                query.append("sum(case when TRP.Tipo = 9 then TPD.Cantidad else 0 end) as Bonificacion, ");
                query.append("sum(case when TRP.Tipo = 1 and TRP.CFVTipo = 2 then TPD.Cantidad else 0 end) as Credito, ");
                query.append("sum(case when TRP.Tipo = 7 then TPD.Cantidad else 0 end) as Devolucion ");
                query.append("from TransProd TRP ");
                query.append("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ");
                query.append("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido = 0 ");
                query.append("where (TRP.Tipo in (1, 7) or (TRP.Tipo = 9 and TRP.TipoMovimiento = 1 ");
                if (( noVenta != null) && noVenta.length()>0){
                    query.append("and TRP.TipoMotivo in ('" + noVenta + "') ");
                }
                query.append(")) ");
                query.append("and TRP.TipoFase <> 0 and (TRP.DiaClave in (select DiaClave from Dia where FueraFrecuencia = 0) or TRP.DiaClave1 in (select DiaClave from Dia where FueraFrecuencia = 0)) ");
                query.append("group by TPD.ProductoClave, PRO.Nombre ");
                query.append("union ");
                query.append("select TPD.ProductoClave, PRO.Nombre, sum(TPD.Cantidad) as Carga, 0 as Contado, 0 as Bonificacion, 0 as Credito, 0 as Devolucion ");
                query.append("from TransProd TRP ");
                query.append("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ");
                query.append("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ");
                query.append("where TRP.Tipo in (2) and TRP.TipoFase <> 0 ");
                query.append("group by TPD.ProductoClave, PRO.Nombre ");
                query.append(") as t ");
                query.append("group by ProductoClave, Nombre ");
            }

            return BDVend.consultar(query.toString());
        }
	}

	public static final class ConsultaPreLiquidacion
	{
		public static void verificarMonto() throws Exception {
			StringBuilder consulta = new StringBuilder();
			consulta.append("select PLIId, MontoTotal ");
			consulta.append("from Preliquidacion ");
			consulta.append("where Enviado = 0 ");
			ISetDatos dsPreliquidacion = BDVend.consultar(consulta.toString());

			if (dsPreliquidacion.getCount() > 0){
				dsPreliquidacion.moveToFirst();
				float MontoTotal = dsPreliquidacion.getFloat("MontoTotal");

				consulta = new StringBuilder();
				consulta.append("select sum(abd.Importe) as Importe ");
				consulta.append("from Abono abn ");
				consulta.append("inner join AbnDetalle abd on abn.ABNId = abd.ABNId ");
				consulta.append("where abd.TipoPago = 1 and abn.Enviado = 0 ");
				float ImporteTotal = (float)BDVend.getBD().ejecutarEscalarObject(consulta.toString());

				float ImporteEfectivo = obtenerSuma(dsPreliquidacion.getString("PLIId"), true);
				float ImporteDeposito = obtenerSuma(dsPreliquidacion.getString("PLIId"), false);

				if ((MontoTotal + ImporteDeposito + ImporteEfectivo) != ImporteTotal){
					consulta = new StringBuilder();
					consulta.append("update Preliquidacion ");
					consulta.append("set MontoTotal = MontoTotal + " + (ImporteTotal - (MontoTotal + ImporteDeposito + ImporteEfectivo)) + " ");
					consulta.append("where Enviado = 0 ");
					BDVend.ejecutarComando(consulta.toString());
				}

			}
		}

		public static ISetDatos obtenerPreLiquidacion() throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT PLIId, FechaPreLiquidacion ,MontoTotal , Enviado ");
			consulta.append("FROM PreLiquidacion ");
			consulta.append("Where Enviado=0 ");
			return BDVend.consultar(consulta.toString());

		}

		public static float obtenerVentasSinSaldar() throws Exception
	{
		StringBuilder consulta = new StringBuilder();

		consulta.append("select ifnull(sum(Saldo - round(case when TRCP.AbnChequePosfechado is null then 0 else TRCP.AbnChequePosfechado end,2) + ");
		consulta.append("case when CLI.ActualizaSaldoCheque = 0 then case when TRC.AbnCheque is null then 0 else TRC.AbnCheque end else 0 end), 0) as Saldo ");
		consulta.append("from TransProd TRP ");
		consulta.append("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ");
		consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
		consulta.append("left join (select TRPCheque.TransProdID, sum(AbnCheque) as AbnCheque from TRPCheque group by TRPCheque.TransProdID) TRC on TRC.TransProdID = TRP.TransProdID ");
		consulta.append("left join (Select TransProdId, sum(AbnChequePosfechado) as AbnChequePosfechado from TRPCheque group by TransProdID) TRCP on TRCP.TransProdID = TRP.TransProdID ");
		consulta.append("where TRP.CFVTipo = 1 and TRP.Saldo > 0 and ");
		if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 0) //FACTURAS
			consulta.append("TRP.Tipo = 8 and TRP.TipoFase <> 0 ");
		else if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 1) //VENTAS
			consulta.append("TRP.Tipo = 1 and  TRP.TipoFase not in (0,1) ");
		else if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2) //AMBAS
			consulta.append("TRP.Tipo=(CASE WHEN CLI.TipoFiscal=1 Then 1 Else 8 END) and TRP.TipoFase <> 0 and TRP.TipoFase <> (CASE WHEN CLI.TipoFiscal = 1 Then 1 else 0 end) ");

		//return BDVend.consultar(consulta.toString());
		return (Float)BDVend.getBD().ejecutarEscalarObject(consulta.toString());
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
			if(Tipo)
				consulta.append("SELECT Total, TipoEfectivo ");
			else
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
				if(Tipo)
				{
					while(datos.moveToNext())
						mTotal += (datos.getFloat("Total") * (Float.parseFloat(ValoresReferencia.getDescripcion("DENOMINA", datos.getString("TipoEfectivo")))));
				}else{
					datos.moveToFirst();
					mTotal = datos.getFloat("Total");
				}
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

    public static final class ConsultaHistoricoVentas
    {
        public static ISetDatos obtenerVentas(Integer filtroFecha, Date fechaIni, Date fechaFin) throws Exception {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select t.TransprodId as _id, t.Folio as Venta, t.FechaCaptura as Fecha, t.Total as Total, t.Saldo as Saldo ");
            consulta.append("from Transprod t ");
            consulta.append("inner join Visita v on t.DiaClave=v.DiaClave and t.VisitaClave=v.VisitaClave ");
            if( ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza").equals("1") || ((((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza").equals("2") && ((Cliente) Sesion.get(Campo.ClienteActual)).TipoFiscal==1))) {
                consulta.append("where t.Tipo=1 ");
            }else{
                consulta.append("where t.Tipo=8 ");
            }
            consulta.append("and t.TipoFase<>0 and v.ClienteClave='" + ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave + "' ");
            consulta.append("and " + Generales.generaCadenaFecha(filtroFecha, "t.FechaCaptura", fechaIni, fechaFin) + " ");
            if( ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza").equals("0") || ((((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza").equals("2") && ((Cliente) Sesion.get(Campo.ClienteActual)).TipoFiscal==2))) {
                consulta.append("and t.TransProdId in (select t2.FacturaId from TransProd t2 where t2.Tipo=1) ");
            }
            consulta.append("order by t.FechaCaptura ");

            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerDetalleVenta(String sTransprodid) throws Exception
        {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select td.TransprodId as _id, Nombre as Producto, td.Cantidad as Cantidad, td.TipoUnidad as Unidad, td.Precio as Precio ");
            sConsulta.append("from TransprodDetalle td ");
            sConsulta.append("inner join Producto p on td.ProductoClave=p.ProductoClave ");
            sConsulta.append("where td.TransprodId='" + sTransprodid + "' ");
            sConsulta.append("order by td.Partida ");

            return BDVend.consultar(sConsulta.toString());
        }

		public static ISetDatos obtenerEstadisticasHistorico(String transProds, int tipoEstadistica) throws Exception{
			StringBuilder consulta = new StringBuilder();
			String estadistica;
			consulta.append("SELECT Pro.ProductoClave AS _id, (Pro.ProductoClave || ' - ' || Pro.Nombre) AS Producto, TPD.TipoUnidad AS Unidad, ");
			if(tipoEstadistica == 0){
				estadistica = "SUM(TPD.Cantidad)";
			}else if(tipoEstadistica == 1){
				estadistica = "SUM(TPD.Cantidad) / COUNT(Pro.ProductoClave)";
			}else{
				estadistica = "MAX(TPD.Cantidad)";
			}
			consulta.append(estadistica + " AS Estadistica, (PU.KgLts * " + estadistica + ") AS KG ");
			consulta.append("FROM TransProd TP ");
			consulta.append("INNER JOIN TransProdDetalle TPD ON TP.TransProdID = TPD.TransProdID ");
			consulta.append("INNER JOIN Producto Pro ON TPD.ProductoClave = Pro.ProductoClave ");
			consulta.append("INNER JOIN ProductoUnidad PU ON TPD.ProductoClave = PU.ProductoClave AND TPD.TipoUnidad = PU.PRUTipoUnidad ");
			consulta.append("WHERE TP.TransProdID IN (" + transProds + ") ");
			//consulta.append("WHERE TP.TransProdID IN ('1060F9318E95824D','10722D3F91FCD76D','10CE26B1A96A1B00','1173D893132E1EC8','12934E88DC454723')");
			consulta.append("GROUP BY Pro.ProductoClave, Pro.Nombre, TPD.TipoUnidad, PU.KgLts");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerTransProdFactura(String factura) throws  Exception{
			return BDVend.consultar("SELECT TransProdID FROM TransProd WHERE FacturaID IN (" + factura + ")");
		}

		public static ISetDatos obtenerTransProdPedido(String Pedido) throws  Exception{
			return BDVend.consultar("SELECT TransProdID FROM TransProd WHERE Folio IN (" + Pedido + ")");
		}

        public static ISetDatos obtenerEstadisticas(String sTransprods, Integer NoDocumentos) throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("select p.ProductoClave as _id, (p.ProductoClave || ' - ' || p.Nombre) as Producto, td.TipoUnidad as Unidad, round((sum(td.Cantidad)/" + NoDocumentos + "),2) as Promedio, ");
            consulta.append("ifnull((select m2.Cantidad from (select td2.Cantidad, COUNT(*) as Repeticiones ");
            consulta.append("from TransProd t2 ");
            consulta.append("inner join TransProdDetalle td2 on t2.TransProdID=td2.TransProdID ");
            consulta.append("inner join Producto p2 on td2.ProductoClave=p2.ProductoClave ");
            consulta.append("where t2.TransProdID in (" + sTransprods + ") ");
            consulta.append("and td2.ProductoClave=td.ProductoClave and td2.TipoUnidad=td.TipoUnidad ");
            consulta.append("group by p2.ProductoClave, td2.TipoUnidad, td2.Cantidad ");
            consulta.append("order by Repeticiones desc ");
            consulta.append("limit 1) m2 ");
            consulta.append("where m2.Repeticiones>1),0) as Moda ");
            consulta.append("from TransProd t ");
            consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID ");
            consulta.append("inner join Producto p on td.ProductoClave=p.ProductoClave ");
            consulta.append("where t.TransProdID in (" + sTransprods + ") ");
            consulta.append("group by p.ProductoClave, p.Nombre, td.TipoUnidad, td.ProductoClave ");
            consulta.append("order by p.ProductoClave, p.Nombre ");
            consulta.append("");
            return BDVend.consultar(consulta.toString());
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
			consulta.append("select t._id as _id, t.Ficha as Ficha, t.FechaDeposito as FechaDeposito, t.Total as Total, t.TipoBanco as TipoBanco, t.Cuenta as Cuenta ");
            consulta.append("from ( ");
            consulta.append("select DEPId as _id, Ficha, FechaDeposito, Total, TipoBanco, Cuenta ");
            consulta.append("from Deposito ");
            consulta.append("union all ");
            consulta.append("select PBEId as _id, Ficha, FechaDeposito, Total, TipoBanco,'' as Cuenta ");
            consulta.append("from PlbPle ");
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
            consulta.append("select a.ABNId as ABNId, a.VisitaClave as VisitaClave, a.DiaClave as DiaClave, a.FechaAbono as FechaAbono, a.Folio as Folio, a.Total as Total, v.RUTClave, e.Nombre as VENNombre ");
            consulta.append("from Abono a ");
            consulta.append("inner join Visita v on a.VisitaClave = v.VisitaClave and a.DiaClave = v.DiaClave ");
            consulta.append("inner join Ruta r on v.RutClave = r.RutClave ");
            consulta.append("inner join Vendedor e on v.VendedorId = e.VendedorId ");
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
            consulta.append("select Clave as Clave, RazonSocial as RazonSocial, TipoFiscal as TipoFiscal, IdFiscal ");
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

		public static ISetDatos DatosDetallePagosCobranzaAvila(String claveCliente) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select distinct Folio as Folio, FechaHoraAlta as FechaHoraAlta, Total as Total, Saldo as Saldo ");
			consulta.append("from TransProd ");
			consulta.append("where saldo > 0  and ClienteClave = '" + claveCliente + "'");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos DatosDetallePagosLaFlorida(String sABNId) throws Exception {
			StringBuilder consulta = new StringBuilder();
			consulta.append("select TRP.TransProdID, TRP.Folio, case when TRP.DiaClave1 is null then TRP.DiaClave else TRP.DiaClave1 end as DiaClave, TRP.Total, ABT.Importe, TRP.Saldo,(case when TRP.SaldoCarga is null then 0 else TRP.SaldoCarga end) as SaldoCarga, T.TA as TotalAbonos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join AbnTrp ABT on TRP.TransProdID = ABT.TransProdID ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
			consulta.append("inner join (select AT.TransprodId,sum(AT.Importe) as TA from AbnTrp AT group by AT.Transprodid) T on TRP.TransprodId=T.TransprodId ");
			consulta.append("where ABT.ABNId = '" + sABNId + "' ");
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos DatosDetallePagosConsLaFlorida(boolean bVentas, String sTransProdIds, String sClienteClave) throws Exception {
			StringBuilder consulta = new StringBuilder();
			consulta.append("select TRP.Folio, case when TRP.DiaClave1 is null then TRP.DiaClave else TRP.DiaClave1 end as DiaClave, TRP.Total, TRP.Saldo,(case when TRP.SaldoCarga is null then 0 else TRP.SaldoCarga end) as SaldoCarga ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
			if (bVentas)
				consulta.append("where ((TRP.Tipo = 1 and TRP.TipoFase = 2) or (TRP.Tipo = 24 and TRP.TipoFase <> 0)) ");
			else
				consulta.append("where TRP.Tipo in (8, 24) and TRP.TipoFase <> 0 ");
			consulta.append("and TRP.Saldo > 0 and VIS.ClienteClave = '" + sClienteClave + "' ");
			consulta.append("and TRP.TransProdId not in (" + sTransProdIds + ")");
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

		public static CamionVendedor obtenerCamionVendedor() throws Exception
		{
			CamionVendedor mCamionVendedor = new CamionVendedor();
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select CAMVENId, Placa, FechaHoraInicial, KMInicial, KMFinal ");
			consulta.append("FROM CamionVendedor ");
			consulta.append("Where Enviado=0 ");
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

		public static void eliminarCamionVendedorDiaClaveNull() throws Exception
		{
			BDVend.ejecutarComando("Delete from CamionVendedor where Enviado = 0 and IFNULL(DiaClave,0) = 0 ");
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

        public static boolean ValidarAbonosVinculados() throws Exception{
            String consulta;
            float tolerancia = 0;
            if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("ToleranciaAbnDepVin"))
                tolerancia = Float.parseFloat(((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("ToleranciaAbnDepVin"));

            consulta ="select ifnull(sum(Importe), 0) as Importe from AbnTrp";
            float abono = (float)BDVend.bd.ejecutarEscalarObject(consulta);

            consulta = "select ifnull(sum(Total), 0) as Importe from Deposito";
            float deposito = (float)BDVend.bd.ejecutarEscalarObject(consulta);

            return ( Math.abs(Generales.getRound(abono, 2) - Generales.getRound(deposito, 2)) <= tolerancia);
        }

        public static ISetDatos obtenerUsuariosTripulacion() throws Exception{
            StringBuilder consulta = new StringBuilder();
            consulta.append("select t.USUId as _id, t.TipoTripulacion, t.USUId, t.TripId ");
            consulta.append("from Tripulacion t ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static String obtenerUsuario(String sUsuId) throws Exception{
            StringBuilder consulta = new StringBuilder();
            consulta.append("select u.Nombre ");
            consulta.append("from Usuario u ");
            consulta.append("where u.UsuId='" + sUsuId +"' ");
            ISetDatos datos = BDTerm.consultar(consulta.toString());

            String res = "";
            while (datos.moveToNext()) {
                res = datos.getString("Nombre");
            }
            datos.close();

            return res;
        }

        public static String obtenerClaveUsuario(String sUsuId) throws Exception{
            StringBuilder consulta = new StringBuilder();
            consulta.append("select u.Clave ");
            consulta.append("from Usuario u ");
            consulta.append("where u.UsuId='" + sUsuId +"' ");
            ISetDatos datos = BDTerm.consultar(consulta.toString());

            String res = "";
            while (datos.moveToNext()) {
                res = datos.getString("Nombre");
            }
            datos.close();

            return res;
        }

        public static ISetDatos obtenerUsuarios() throws Exception{
            StringBuilder consulta = new StringBuilder();
            consulta.append("select u.Usuid as _id, u.Clave, u.Nombre ");
            consulta.append("from Usuario u ");
            consulta.append("where u.Activo=1 ");
            ISetDatos datos = BDTerm.consultar(consulta.toString());

            return datos;
        }

        public static String obtenerUsuarioId(String sClaveUsuario) throws Exception{
            StringBuilder consulta = new StringBuilder();
            consulta.append("select u.USUId ");
            consulta.append("from Usuario u ");
            consulta.append("where u.Clave='" + sClaveUsuario +"' ");
            ISetDatos datos = BDTerm.consultar(consulta.toString());

            String res = "";
            while (datos.moveToNext()){
                res = datos.getString("USUId");
            }
            datos.close();

            return res;
        }

        public static int HayRegistroTripulacion() throws Exception{
            StringBuilder consulta = new StringBuilder();
            consulta.append("select count(*) as HayRegistroTripulacion ");
            consulta.append("from VendedorJornada vj ");
            consulta.append("inner join Tripulacion t on vj.VendedorId=t.VendedorId and vj.VEJFechaInicial=t.VEJFechaInicial ");
            ISetDatos datos = BDVend.consultar(consulta.toString());

            int res = 0;
            while (datos.moveToNext()) {
                res = datos.getInt("HayRegistroTripulacion");
            }
            datos.close();

            return res;
        }

        public static ISetDatos obtenerRegTripulacionUsuario(String sUsuId, String sDiaClave) throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("Select * ");
            consulta.append("from VendedorJornada vj ");
            consulta.append("inner join Tripulacion t on vj.VendedorId=t.VendedorId and vj.VEJFechaInicial=t.VEJFechaInicial ");
            consulta.append("where t.USUId= '" + sUsuId + "' and vj.DiaClave='" + sDiaClave + "' ");
            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

		public static void eliminarRegTripulacionUsuario(String sTripId) throws Exception {
			 BDVend.ejecutarComando("Delete from Tripulacion where TripId ='" + sTripId + "' ") ;
		}


        public static boolean ExisteRegTripulacionUsuario(String sClaveUsuario, String sDiaClave) throws Exception {
            StringBuilder consulta = new StringBuilder();
            String sUSUId = Consultas.ConsultaRegistroInicioFin.obtenerUsuarioId(sClaveUsuario);

            consulta.append("Select count(*) as Existe ");
            consulta.append("from VendedorJornada vj ");
            consulta.append("inner join Tripulacion t on vj.VendedorId=t.VendedorId and vj.VEJFechaInicial=t.VEJFechaInicial ");
            consulta.append("where t.USUId= '" + sUSUId + "' and vj.DiaClave='" + sDiaClave + "' ");
            ISetDatos datos = BDVend.consultar(consulta.toString());

            int res = 0;
            while (datos.moveToNext()) {
                res = datos.getInt("Existe");
            }
            datos.close();

            return (res > 0);
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

		public static ISetDatos obtenerPedidosDU(){
			String tiposPagoAnticipado = ValoresReferencia.getCadenaValores("PEDTIPO", "PagoAnticipado" );
			String Consulta = "Select t.Tipo as Tipo ,Td.ProductoClave as ProductoClave,TD.TipoUnidad as TipoUnidad,sum(TD.Cantidad) as Cantidad, tde.UnidadAlterna, sum(tde.CantidadAlterna) as CantidadAlterna, PRU.DecimalProducto as DecimalProducto, PRU2.DecimalProducto as DecimalProductoAlterna " ;
			Consulta +="from TransProdDetalle td inner join transprod t on t.transprodid=td.transprodid ";
			Consulta +="inner join ProductoUnidad PRU on PRU.ProductoClave = TD.ProductoClave  and PRU.PRUTipoUnidad = TD.TipoUnidad ";
			Consulta +="left join TPDDatosExtra tde on td.TransProdID = tde.TransProdID and td.TransProdDetalleID = tde.TransProdDetalleID ";
			Consulta +="left join ProductoUnidad PRU2 on PRU2.ProductoClave = td.ProductoClave  and PRU2.PRUTipoUnidad = tde.UnidadAlterna ";
			Consulta +=" where (Tipo=1 or Tipo=24) and (TipoFase=1 or TipoFase=7) ";
			if (tiposPagoAnticipado.length() > 0) {
				Consulta += " and (not TipoPedido in(" + tiposPagoAnticipado + "))  ";
			}
			Consulta += " group by t.Tipo ,Td.ProductoClave,TD.TipoUnidad, tde.UnidadAlterna, pru.DecimalProducto, pru2.DecimalProducto  ";
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

		public static List<FolioFiscal> obtieneFoliosFiscalesPorCentroExp(String subEmpresaID, Vista vista) throws Exception
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
					try{
						String sFolio = datos.getString(9) + new Formatter().format("%0" + datos.getString(8).length() + "d" ,  datos.getInt(12)+datos.getInt(2));
						int iExiste = BDVend.getBD().ejecutarEscalarInteger("Select count(*) from TransProd where Tipo = 8 and Folio = '" + sFolio + "'");
						if (iExiste>0){
							BDVend.setOrigenLog("Facturacion:obtieneFoliosFiscalesPorCentroExp");
							BDVend.writeInLog("Facturacion:FolioRepetido");
							FoliosFiscales.actualizarFolioFiscal(folio.FolioId,folio.FOSId);
							datos.close();
							BDVend.enviarCorreoLog(vista);
							return obtieneFoliosFiscalesPorCentroExp(subEmpresaID, vista);
						}
					}catch(Exception ex){
						throw new Exception("Error al obtener folio fiscal" + ex.getMessage());

					}
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

        public static String obtenerSubEmpresaID() throws Exception {
            String consulta = "SELECT SubEmpresaId FROM SubEmpresa";
            ISetDatos dato = BDVend.consultar(consulta);
            String subEmpresaId = "";
            if(dato.moveToNext())
            {
                subEmpresaId = dato.getString("SubEmpresaId");
            }
            dato.close();
            return subEmpresaId;
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
			BDVend.ejecutarComando("Delete from ImproductividadVenta where VisitaClave || DiaClave in( Select VIS.VisitaClave || VIS.DiaClave from Visita VIS where VIS.ClienteClave ='" + clienteClave + "' and VIS.VendedorID = '" + vendedorID + "' and VIS.RUTClave = '" + RUTClave + "' and VIS.DiaClave = '"  + diaClave + "' )" );
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

        public static boolean validarTieneAbonos(String id) throws Exception
        {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select count(*) from AbnTrp ");
            consulta.append("where TransProdId = '" + id + "'");

            return BDVend.bd.ejecutarEscalarInteger(consulta.toString()) > 0;
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

        public static String obtienePliId() throws Exception{
            ISetDatos Preliquidacion = BDVend.consultar("Select * from Preliquidacion");

            if(Preliquidacion.moveToNext()){
                return Preliquidacion.getString("PLIId");
            }
            Preliquidacion.close();

            return null;
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

		//Elimina los registros de TransProd que no tienen registros en TransProdDetalle
		public static void eliminarVentasInconsistentes() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select TRP.TransProdID as TransProdID, TRP.Folio ");
			consulta.append("from Transprod TRP ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoPedido = 1 and TRP.TipoFase = 1 and TRP.SubTotal is null ");
			consulta.append("and TransProdID not in (select TransProdId from TransProdDetalle)");
			ISetDatos datos = BDVend.consultar(consulta.toString());

			if(datos != null)
			{
				while(datos.moveToNext())
				{
					TransProd trp = new TransProd();
					trp.TransProdID = datos.getString("TransProdID");
					BDVend.recuperar(trp);
					BDVend.eliminar(trp);
				}
			}
		}

        //Verifica si existe alguna preventa con totales nulos y detalles y regresa los TransProdID y los folios
        public static ArrayList<TransProd> regresaPreventasInconsistentes() throws Exception{

            ArrayList<TransProd> TRPResultado = new ArrayList<TransProd>();
            ISetDatos datos = BDVend.consultar("Select distinct TRP.TransProdID as TransProdID from Transprod TRP inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID where TRP.Tipo = 1 and TRP.TipoPedido = 2 and TRP.TipoFase = 1 and TRP.SubTotal is null ");
            if(datos != null){
                if (datos.getCount() <= 0){
                    datos.close();
                    return TRPResultado;
                }
            }else{
                return TRPResultado;
            }

            if(datos != null){
                while(datos.moveToNext()){
                    TransProd trp = new TransProd();
                    trp.TransProdID = datos.getString("TransProdID");
                    BDVend.recuperar(trp);
                    TRPResultado.add(trp);
                }
            }
            datos.close();
            return TRPResultado;
        }

		public static boolean existenPromocionesInconsistentes(String TransProdId) throws Exception {
			boolean hayInconsistencia = false;
			StringBuilder consulta = new StringBuilder();
			consulta.append("select TPD.TransProdDetalleID ");
			consulta.append("from TransProdDetalle TPD ");
			consulta.append("inner join TransProd TRP on TPD.TransProdID = TRP.TransProdID ");
			consulta.append("where TRP.TipoFase <> 0 and abs(ifnull(TPD.DescuentoImp,0) - ifnull((select sum(PromocionImp) from TrpPrp TPP where TPP.TransProdID = TPD.TransProdID and TPP.TransProdDetalleID = TPD.TransProdDetalleID  ),0)) > 0.2 ");
			consulta.append("and TPD.TransProdID = '" + TransProdId + "' ");
			ISetDatos dsDatos = BDVend.consultar(consulta.toString());
			hayInconsistencia = (dsDatos.getCount() > 0);
			dsDatos.close();
			return hayInconsistencia;
		}

		public static boolean eliminarImpuestosDuplicados(String TransProdId) throws Exception {
			boolean bEliminados = false;
			if (!existenPromocionesInconsistentes(TransProdId))
			{
				StringBuilder consulta = new StringBuilder();
				consulta.append("select TPI.TransProdID, TransProdDetalleID, ImpuestoClave, COUNT(*) as NumeroImpuestos ");
				consulta.append("from TPDImpuesto TPI ");
				consulta.append("inner join TransProd TRP on TRP.TransProdID = TPI.TransProdID ");
				consulta.append("where TRP.TransProdID = '" + TransProdId + "' ");
				consulta.append("group by TPI.TransProdID, TransProdDetalleID, ImpuestoClave ");
				consulta.append("having COUNT(*) > 1 ");

				ISetDatos dsImpDuplicado = BDVend.consultar(consulta.toString());
				if (dsImpDuplicado.getCount() > 0) {
					while (dsImpDuplicado.moveToNext()) {
						String sTransProdId = dsImpDuplicado.getString("TransProdID");
						String sTransProdDetalleId = dsImpDuplicado.getString("TransProdDetalleID");
						String sImpuestoClave = dsImpDuplicado.getString("ImpuestoClave");

						consulta = new StringBuilder();
						consulta.append("select TPDImpuestoID ");
						consulta.append("from TPDImpuesto ");
						consulta.append("where TransProdID='" + sTransProdId + "' and TransProdDetalleID='" + sTransProdDetalleId + "' and ImpuestoClave='" + sImpuestoClave + "' ");
						consulta.append("order by MFechaHora desc ");
						consulta.append("limit 1");
						ISetDatos dsImpuesto = BDVend.consultar(consulta.toString());

						dsImpuesto.moveToFirst();
						consulta = new StringBuilder();
						consulta.append("delete from TPDImpuesto ");
						consulta.append("where TransProdID='" + sTransProdId + "' and TransProdDetalleID='" + sTransProdDetalleId + "' and ImpuestoClave='" + sImpuestoClave + "' and TPDImpuestoID<>'" + dsImpuesto.getString("TPDImpuestoID") + "'");

						BDVend.ejecutarComando(consulta.toString());
						dsImpuesto.close();

						bEliminados = true;
					}
				}
				dsImpDuplicado.close();;
			}
			return bEliminados;
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

	public static final class ConsultasStock{
		public static String obtenerUltimaVisita(String ClienteClave, boolean MSIEV) throws Exception{
			String TransProdID = "";
			StringBuilder consulta = new StringBuilder();

			consulta.append("SELECT TP.TransProdID FROM TransProd AS TP ");
			consulta.append("INNER JOIN Visita AS V ON V.VisitaClave = TP.VisitaClave ");
			consulta.append("WHERE ClienteClave = '" + ClienteClave + "' AND ");
			if(MSIEV){
				consulta.append(" TP.Tipo = '21' AND TP.TipoFase <> '0'");
			}else{
				consulta.append(" TP.Tipo = '1' AND TP.TipoFase = '2'");
			}
			consulta.append(" ORDER BY V.MFechaHora DESC");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if(datos.getCount() > 0) {
				datos.moveToNext();
				TransProdID = datos.getString("TransProdID");
				datos.close();
			}
			return TransProdID;
		}

		public static ISetDatos obtenerDetalleStock(String ultimaVenta, String MSIEV) throws Exception{
			StringBuilder consulta = new StringBuilder();

			consulta.append("SELECT UV.ProductoClave AS _id, UV.Nombre AS Nombre, UV.TipoUnidad AS TipoUnidad, (UV.Cantidad + MSIEV.Cantidad) AS Cantidad FROM ");
			consulta.append("(SELECT Pro.ProductoClave AS ProductoClave, Pro.Nombre, TPD.TipoUnidad, TPD.Cantidad FROM TransProd AS TP ");
			consulta.append("INNER JOIN TransProdDetalle AS TPD ON TP.TransProdID = TPD.TransProdID ");
			consulta.append("INNER JOIN Producto AS Pro ON TPD.ProductoClave = Pro.ProductoClave ");
			//consulta.append("INNER JOIN VAVDescripcion AS VD ON TPD.TipoUnidad = VD.VAVClave ");
			consulta.append("WHERE TP.TransProdID = '" + ultimaVenta + "' ) AS UV ");
			//consulta.append("AND VD.VARCodigo = 'UNIDADV'");// AND VD.VADTipoLenguaje = (SELECT TOP 1 TipoLenguaje FROM CONHist ORDER BY CONHistFechaInicio DESC)");
			consulta.append("INNER JOIN (SELECT TPD.ProductoClave, TPD.Cantidad FROM TransProd AS TP ");
			consulta.append("INNER JOIN TransProdDetalle AS TPD ON TP.TransProdID = TPD.TransProdID ");
			consulta.append("INNER JOIN Producto AS Pro ON TPD.ProductoClave = Pro.ProductoClave ");
			consulta.append("WHERE TP.TransProdID= '" +MSIEV+ "') AS MSIEV ON UV.ProductoClave = MSIEV.ProductoClave");
			return  BDVend.bd.consultar(consulta.toString());
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

        public static int obtenerSaldoEnvasePreventa(String clienteClave) throws Exception{
            StringBuilder sConsulta = new StringBuilder();
            int envase = 0;

            sConsulta.append("select ifnull(sum(Saldo), 0) as Envase from ProductoPrestamoCli where ClienteClave='" + clienteClave + "'");
            envase = BDVend.getBD().ejecutarEscalarInteger(sConsulta.toString());

            sConsulta = new StringBuilder();
            sConsulta.append("select ifnull(sum(TPD.Cantidad),0) as Envase ");
            sConsulta.append("from TransProdDetalle TPD ");
            sConsulta.append("inner join ProductoDetalle PDT on TPD.ProductoClave=PDT.ProductoClave AND TPD.TipoUnidad=PDT.PRUTipoUnidad AND TPD.ProductoClave<>PDT.ProductoDetClave ");
            sConsulta.append("inner join Transprod TRP on TPD.TransprodID=TRP.TransprodId ");
            sConsulta.append("inner join Visita VIS on TRP.VisitaClave=VIS.VisitaClave and TRP.DiaClave=VIS.DiaClave  ");
            sConsulta.append("where PDT.Prestamo=1 and TRP.Tipo=1 and TRP.TipoFase=1 and VIS.ClienteClave = '" + clienteClave + "' ");
            sConsulta.append("and TRP.DiaClave in (select DiaClave from Dia where FueraFrecuencia=0) ");
            envase +=  BDVend.getBD().ejecutarEscalarInteger(sConsulta.toString());

            return envase;
        }

        public static int obtenerEnvaseTransProdActual(String transProdId) throws Exception{
            StringBuilder sConsulta = new StringBuilder();
            int envase = 0;

            sConsulta.append("select ifnull(sum(TPD.Cantidad), 0) as Envase ");
            sConsulta.append("from TransProdDetalle TPD ");
            sConsulta.append("inner join ProductoDetalle PDT on TPD.ProductoClave = PDT.ProductoClave and TPD.TipoUnidad = PDT.PRUTipoUnidad and TPD.ProductoClave <> PDT.ProductoDetClave ");
            sConsulta.append("where PDT.Prestamo = 1 and TPD.TransProdID = '" + transProdId + "' ");
            envase = BDVend.getBD().ejecutarEscalarInteger(sConsulta.toString());

            return envase;
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

            sConsulta.append("SELECT TRP.TransProdID,CLI.ClienteClave, CLI.Clave, CLI.RazonSocial,  TVA.FolioCliente as ClienteSAP,  TRP.FechaCaptura as FechaPedido, TVA.PedidoAdicional as PedidoSAP, TRP.Total as ValorNeto, CMGST.Descripcion as Estatus, ");
            sConsulta.append("ESQ.Clave, TPD.ProductoClave, PRO.Nombre, TPD.TipoUnidad, TPD.CantidadOriginal,TPD. Cantidad, TPD.Total, IFNULL(TVA.Observaciones2,'') as NoPedidoCte, TRP.Folio, TRP.ClientePagoId ");
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

        public static ISetDatos obtenerSubtotalDescuento(String transProdID)throws Exception{
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("Select SUM(Subtotal) as Subtotal, sum(Impuesto) as Impuesto, SUM(Descuento1) as Descuneto1, SUM(Descuento2) as Descuento2 ");
            sConsulta.append("from( ");
            sConsulta.append("Select SUM(TPD.SubTotal) as Subtotal, IFNULL(sum(Impuesto),0) as Impuesto, 0 as Descuento1, 0 as Descuento2 ");
            sConsulta.append("from TransProdDetalle TPD ");
            sConsulta.append("inner join ProductoEsquema PE on TPD.ProductoClave = PE.ProductoClave ");
            sConsulta.append("inner join Esquema E on PE.EsquemaID = E.EsquemaID ");
            sConsulta.append("inner join ConfigParametro CP on E.Clasificacion = CP.Valor and CP.Parametro = 'CalculadoraClasificaciones' ");
            sConsulta.append("where TransProdID = '"+ transProdID +"' ");
            sConsulta.append("");
            sConsulta.append("Union all ");
            sConsulta.append("");
            sConsulta.append("Select 0 as Subtotal, 0 as Impuesto, ");
            sConsulta.append("case when Orden = 1 then Porcentaje else 0.0 end as Descuento1, ");
            sConsulta.append("case when Orden = 2 then Porcentaje else 0.0 end as Descuento2 ");
            sConsulta.append("from TRPDescCalculadora ");
            sConsulta.append("where TransProdID = '"+ transProdID +"' ");
            sConsulta.append(") as Tabla");

            ISetDatos datos = BDVend.consultar(sConsulta.toString());

            return datos;
        }
    }

    public static final class ConsultasEstatusPedidosSAP{
        public static ISetDatos obtenerPedidosSAP(String filtroFecha, String clienteClave)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select (c.Clave || ' - ' || c.RazonSocial) as Cliente, t.Folio as FolioRoute, ifnull(tva.PedidoAdicional,'') as NoCompra, ifnull(tva.Observaciones2,'') as Respuesta, t.TipoFase ");
            sConsulta.append("from Transprod t ");
            sConsulta.append("inner join Visita v on t.DiaClave=v.DiaClave and t.VisitaClave=v.VisitaClave ");
            sConsulta.append("inner join Cliente c on v.ClienteClave=c.ClienteClave ");
            sConsulta.append("left join TrpVtaAcreditada tva on t.TransprodId=tva.TransprodId ");
            sConsulta.append("where t.Tipo=1 and t.TipoFase in (1,12) ");
            if (!clienteClave.equals("")){
                sConsulta.append(" and v.ClienteClave = '" +  clienteClave + "' ");
            }
            if (!filtroFecha.equals("")){
                sConsulta.append(" and " + filtroFecha);
            }
            sConsulta.append("order by c.Clave ");

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

    public static final class ReporteVtaProductoMovEnvase{
        public static ISetDatos obtenerResumenVentas(String sfiltroDiasClaves)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select t.ProductoClave as ProductoClave, sum(VtaReg) as VtaReg, sum(VtaCan) as VtaCan, sum(VtaNeta) as VtaNeta, sum(Prom) as Prom, sum(Con) as Con, t.PCEPrecioClave ");
            sConsulta.append("from (   ");
            sConsulta.append("select PRO.ProductoClave as ProductoClave, ");
            sConsulta.append("  case when ifnull(TPD.Promocion,0) <> 2 then sum(PRD.Factor *  TPD.Cantidad) else 0 end as VtaReg, ");
            sConsulta.append("  case when TRP.TipoFase = 0 and ifnull(TPD.Promocion,0) <> 2 then sum(PRD.Factor * TPD.Cantidad) else 0 end as VtaCan, ");
            sConsulta.append("  case when TRP.TipoFase <> 0 and ifnull(TPD.Promocion,0) <> 2 then sum(PRD.Factor * TPD.Cantidad) else 0 end as VtaNeta, ");
            sConsulta.append("  case when TRP.TipoFase <> 0 and ifnull(TPD.Promocion,0) = 2 then sum(PRD.Factor *  TPD.Cantidad) else 0 end as Prom, ");
            sConsulta.append("  0 as Con, min(TRP.PCEPrecioClave) as PCEPrecioClave ");
            sConsulta.append("from TransProd TRP ");
            sConsulta.append("inner join Dia on ifnull(TRP.DiaClave1,TRP.DiaClave)=Dia.DiaClave ");
            sConsulta.append("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ");
            sConsulta.append("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ");
            sConsulta.append("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and TPD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ");
            sConsulta.append("where TRP.Tipo = 1  and (ifnull(TRP.DiaClave1,TRP.DiaClave) in ("+ sfiltroDiasClaves +") and Dia.FueraFrecuencia = 0) and TRP.TipoFase in (0,2,3) ");
            sConsulta.append("group by PRO.ProductoClave, ifnull(TPD.Promocion,0), TRP.TipoFase ");
            sConsulta.append("");
            sConsulta.append("union all ");
            sConsulta.append("");
            sConsulta.append("select PRO.ProductoClave as ProductoClave, 0 as VtaReg, 0 as VtaCan, 0 as VtaNeta, 0 as Prom, ");
            sConsulta.append("  sum (PRD.Factor * (TPD.Cantidad - ifnull(TTD.Cantidad,0))) as Con, ");
            sConsulta.append("  TRP.PCEPrecioClave as PCEPrecioClave ");
            sConsulta.append("from TransProd TRP ");
            sConsulta.append("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ");
            sConsulta.append("left join TrpTpd TTD on TPD.TransProdId = TTD.TransProdId1 and TPD.TransProdDetalleId = TTD.TransProdDetalleId ");
            sConsulta.append("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ");
            sConsulta.append("inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and TPD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ");
            sConsulta.append("where TRP.Tipo = 24 and TRP.TipoFase = 6 and TRP.DiaClave1 in ("+ sfiltroDiasClaves +") ");
            sConsulta.append("group by PRO.ProductoClave, ifnull(TPD.Promocion,0), TRP.TipoFase, TRP.PCEPrecioClave, TTD.Cantidad ");
            sConsulta.append("");
            sConsulta.append("order by PRO.ProductoClave ");
            sConsulta.append(") t ");
            sConsulta.append("group by t.ProductoClave ");
            sConsulta.append("order by t.ProductoClave ");

            return BDVend.consultar(sConsulta.toString());
        }

		public static ISetDatos obtenerTotalesDetalle(String sfiltroDiasClaves)throws  Exception {
			StringBuilder sConsulta = new StringBuilder();

			sConsulta.append("select case when p.contenido=0 and ifnull(td.promocion,0)<>2 then  sum(td.precio * TD.Cantidad)  else 0 end as vtaliquido, ");
			sConsulta.append("case when p.contenido=1 and ifnull(td.promocion,0)<>2 then  sum(td.precio * TD.Cantidad)  else 0 end as vtaenvase, ");
			sConsulta.append("case when p.contenido=0 and ifnull(td.promocion,0)<>2 then  sum(td.Impuesto)  else 0 end as impuestoliquido, ");
			sConsulta.append("case when p.contenido=1 and ifnull(td.promocion,0)<>2 then  sum(td.Impuesto)  else 0 end as impuestoenvase, ");
			sConsulta.append("case when p.contenido=0 and ifnull(td.promocion,0)<>2 then  sum(ifnull(TpdDes.DesImpuesto,0)) else 0 end as DesImpuestoliquido, ");
			sConsulta.append("case when p.contenido=1 and ifnull(td.promocion,0)<>2 then  sum(ifnull(TpdDes.DesImpuesto,0)) else 0 end as DesImpuestoenvase, ");
			sConsulta.append("case when p.contenido=0 and ifnull(td.promocion,0)<>2 then  sum(ifnull(TpdDesVendedor.DesImpuesto,0)) else 0 end as VenDesImpuestoliquido, ");
			sConsulta.append("case when p.contenido=1 and ifnull(td.promocion,0)<>2 then  sum(ifnull(TpdDesVendedor.DesImpuesto,0)) else 0 end as VenDesImpuestoenvase,");
			sConsulta.append("case when ifnull(td.promocion,0)<>2 then  sum(td.precio * TD.Cantidad)  else 0 end as vtatotal, ");
			sConsulta.append("case when t.tipofase=0 then  sum(td.precio*TD.Cantidad)  else 0 end as vtacanceladas, ");
			sConsulta.append("case when t.tipofase=0 then  sum(td.impuesto)  else 0 end as impcanceladas ");
			//sConsulta.append("case when t.tipofase<>0 then  sum(td.descuentoimp) else 0 end as tddescuento  ");
			sConsulta.append("from transprod T ");
			sConsulta.append("inner join transproddetalle TD on T.transprodid=TD.transprodid   ");
			sConsulta.append("inner join producto P on TD.productoclave=P.productoclave ");
			sConsulta.append("inner join ProductoDetalle PRD on P.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave  ");
			sConsulta.append("left join TpdDes on TpdDes.transprodid=TD.transprodid and TpdDes.transproddetalleid=TD.transproddetalleid ");
			sConsulta.append("left join TpdDesVendedor on TpdDesVendedor.transprodid=TD.transprodid and TpdDesVendedor.transproddetalleid=TD.transproddetalleid  ");
			sConsulta.append("where t.tipo =1  and (t.diaclave in ("+ sfiltroDiasClaves +") or t.diaclave1 in ("+ sfiltroDiasClaves +")) and t.tipofase in (0,2,3)  ");
			sConsulta.append("group by t.tipofase,p.contenido,ifnull(td.promocion,0)  ");

			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerTotalesDescuentos(String sfiltroDiasClaves)throws  Exception {
			StringBuilder sConsulta = new StringBuilder();

			sConsulta.append("select sum(DescuentoProm) as DescuentoProm, sum(DescuentoPromEsp) as DescuentoPromEsp from ( ");
			sConsulta.append("select case when TrpPrp.PromocionClave not like 'DEX%' then TrpPrp.PromocionImp else 0 end as DescuentoProm, ");
			sConsulta.append("case when TrpPrp.PromocionClave like 'DEX%' then TrpPrp.PromocionImp else 0 end as DescuentoPromEsp ");
			sConsulta.append("from TransProd T ");
			sConsulta.append("inner join TransProdDetalle TD on T.TransProdId=TD.TransProdId ");
			sConsulta.append("inner join TrpPrp on TD.TransProdId = TrpPrp.TransProdId and TD.TransProdDetalleId = TrpPrp.TransProdDetalleId ");
			sConsulta.append("where T.Tipo = 1  and (T.DiaClave in ("+ sfiltroDiasClaves +") or T.DiaClave1 in ("+ sfiltroDiasClaves +")) and T.TipoFase in (2,3)) ");

			return BDVend.consultar(sConsulta.toString());
		}

        public static ISetDatos obtenerTotales(String sfiltroDiasClaves)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select sum(t.descuentoimp) as descuentoimp, ");
            sConsulta.append("  sum(t.descuentovendedor)  as descuentovendedor, ");
            sConsulta.append("  sum(t.impuesto) as impuesto, ");
            sConsulta.append("  sum(t.total) as total ");
            sConsulta.append("from transprod T  ");
            sConsulta.append("where t.tipo =1 and tipofase in (2,3) and (diaclave in ("+ sfiltroDiasClaves +") or diaclave1 in ("+ sfiltroDiasClaves +"))  ");

            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerConsignas(String sfiltroDiasClaves)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select sum( tcon.total) as TotalConsigna ");
            sConsulta.append("from transprod TCon ");
            sConsulta.append("where TCon.tipo =24  and TCon.tipofase =6 and strftime('%d/%m/%Y', TCon.FechaFacturacion) in ("+ sfiltroDiasClaves +") ");

            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerDevolucionesConsignas(String sfiltroDiasClaves)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select sum (ifnull(TrpTpd.total,0)) as TotalDevolucionConsigna ");
            sConsulta.append("from transprod TCon   ");
            sConsulta.append("left join TrpTpd on TrpTpd.Transprodid1=TCon.transprodid   ");
            sConsulta.append("where TCon.tipo=24 and TCon.tipofase =6 and strftime('%d/%m/%Y', TCon.FechaFacturacion) in ("+ sfiltroDiasClaves +") ");

            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerTotalAbonos(String sfiltroDiasClaves)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select sum(ifnull(total,0)) as TotalAbonos ");
            sConsulta.append("from abono ");
            sConsulta.append("where diaclave in ("+ sfiltroDiasClaves +")    ");

            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerSaldoEfectivo()throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select sum(SaldoEfectivo) as TotalSaldoEfectivo ");
            sConsulta.append("from Cliente ");

            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerSaldoEfectivoCarga()throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select sum(SaldoEfectivoCarga) as TotalSaldoEfectivoCarga ");
            sConsulta.append("from Cliente ");

            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerSaldoEnvases()throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select p.nombre as Nombre, sum(saldocarga) as saldocarga, sum(cargo) as cargo, sum(abono) as abono, sum(ppc.venta) as venta ");
            sConsulta.append("from productoprestamocli ppc ");
            sConsulta.append("inner join producto p on ppc.productoclave = p.productoclave ");
            sConsulta.append("group by nombre ");
            sConsulta.append("order by nombre ");

            return BDVend.consultar(sConsulta.toString());
        }
    }

    public static final class ReporteExtensionAlmacenABordo{
        public static ISetDatos obtenerInventario(String sfiltroDiasClaves)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            ISetDatos PrimerCarga = BDVend.consultar("select ifnull(transprodid,'') as TransprodId from transprod where tipo=2 and tipofase<>0 order by mfechahora");
            String sPrimerCarga="";
            if(PrimerCarga.moveToNext()){
                sPrimerCarga=PrimerCarga.getString("TransprodId");
            }

            sConsulta.append("select t.ProductoClave as ProductoClave, ");
            sConsulta.append("  sum(Ini) as Ini,");
            sConsulta.append("  sum(Rec) as Rec,");
            sConsulta.append("  sum(Vta) as Vta,");
            sConsulta.append("  sum(Prom) as Prom,");
            sConsulta.append("  sum(Con) as Con,");
            sConsulta.append("  sum(DevCon) as DevCon,");
            sConsulta.append("  sum(xDec) as xDec, ");
            sConsulta.append("  sum(Can) as Can ");
            sConsulta.append("from ( ");
            sConsulta.append("  select p.productoclave as ProductoClave, ");
            sConsulta.append("      case when t.tipo=23 or (t.tipo=2 and t.transprodid='" + sPrimerCarga + "')then sum(PRD.Factor * TD.Cantidad) else 0 end as Ini, ");
            sConsulta.append("      case when (t.tipo=2 and t.transprodid<>'" + sPrimerCarga + "') or (t.tipo=3 and tt.transprodid is null) then sum(PRD.Factor * TD.Cantidad) else 0 end as Rec, ");
            sConsulta.append("      case when t.tipo=1 then case when ifnull(td.promocion,0) <> 2  then sum(PRD.Factor * TD.Cantidad) else 0 end else 0 end as Vta, ");
            sConsulta.append("      case when t.tipo=1 then case when ifnull(td.promocion,0) = 2  then sum(PRD.Factor * TD.Cantidad) else 0 end else 0 end as Prom, ");
            sConsulta.append("      case when t.tipo=24 then sum(PRD.Factor * TD.Cantidad) else 0 end as Con, ");
            sConsulta.append("      case when (t.tipo=3 and not tt.transprodid is null) then sum(PRD.Factor * TD.Cantidad) else 0 end as DevCon, ");
            sConsulta.append("      case when t.tipo=7 then sum(PRD.Factor * TD.Cantidad) else 0 end as xDec, ");
            sConsulta.append("      case when t.tipo=5 then sum(PRD.Factor * TD.Cantidad) else 0 end as Can ");
            sConsulta.append("  from transprod T ");
            sConsulta.append("  inner join transproddetalle TD on T.transprodid=TD.transprodid ");
            sConsulta.append("  inner join producto P on TD.productoclave=P.productoclave ");
            sConsulta.append("  inner join ProductoDetalle PRD on P.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ");
            sConsulta.append("  left join dia d on t.diaclave=d.diaclave ");
            sConsulta.append("  left join dia d1 on t.diaclave1=d1.diaclave ");
            sConsulta.append("  left join (select distinct TransProdId from TrpTpd) as TT on T.TransProdId = TT.TransProdId ");
            sConsulta.append("  where P.Contenido <> 1 and t.tipofase <>0 and ((t.tipo in (23) and t.DiaClave not in (" + sfiltroDiasClaves + ")) or ");
            sConsulta.append("      (t.tipo = 1 and t.tipofase in (2,3) and (t.diaclave in (" + sfiltroDiasClaves + ") or t.diaclave1 in (" + sfiltroDiasClaves + ")) and ((t.diaclave1 is null and d.fuerafrecuencia=0)or (not t.diaclave1 is null and d1.fuerafrecuencia=0))) or ");
            sConsulta.append("      ((t.tipo in (24,2,7,5) or (t.tipo =3 and (t.tipomotivo=12 or t.tipomotivo=1))) and t.diaclave in (" + sfiltroDiasClaves + ") and d.fuerafrecuencia=0 )) ");
            sConsulta.append("  group by p.productoclave, t.tipo, ifnull(td.promocion,0), tt.transprodid,t.transprodid ");
            sConsulta.append(") t ");
            sConsulta.append("group by t.ProductoClave ");
            sConsulta.append("order by t.ProductoClave ");

            return BDVend.consultar(sConsulta.toString());
        }
    }

    public static final class ReporteNotaVentaModeloOriente{
        public static ISetDatos obtenerDatosCliente(String sClienteClave)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select c.Clave as Clave, c.RazonSocial as RazonSocial, c.NombreContacto as NombreContacto, cd.Calle as Calle, cd.Numero as Numero, cd.NumInt as NumInt, cd.Colonia as Colonia ");
            sConsulta.append("from Cliente c ");
            sConsulta.append("inner join ClienteDomicilio cd on c.ClienteClave=cd.ClienteClave ");
            sConsulta.append("where Tipo=2 and c.ClienteClave ='" + sClienteClave + "'");

            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerVentas(String sVisitaClave, String sDiaClave)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select TransprodId as TransprodId, Folio, DescuentoImp, DescuentoVendedor, Impuesto, Total, CFVTipo ");
            sConsulta.append("from TransProd ");
            sConsulta.append("where ((VisitaClave = '" + sVisitaClave + "' and DiaClave = '" + sDiaClave + "') ");
            sConsulta.append("  or (VisitaClave1 = '" + sVisitaClave + "' and DiaClave1 = '" + sDiaClave + "')) ");
            sConsulta.append("  and Tipo = 1 and TipoFase in (2, 3)");

            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerVentaDetalle(String sTransProdId)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select distinct td.productoclave as ProductoClave, p.nombre as Nombre, td.tipounidad as TipoUnidad, max(td.precio) as Precio, ifnull(sum(ti.ImpuestoPU), 0) as Impuesto ");
            sConsulta.append("from transproddetalle td ");
            sConsulta.append("inner join producto p on p.productoclave = td.productoclave ");
            sConsulta.append("left join tpdimpuesto ti on td.transprodid=ti.transprodid and td.transproddetalleid=ti.transproddetalleid ");
            sConsulta.append("where td.transprodid='" + sTransProdId + "' ");
            sConsulta.append("group by  td.productoclave,p.nombre ,td.tipounidad ");
            sConsulta.append("order by p.nombre ");

            return BDVend.consultar(sConsulta.toString());
        }

        public static double obtenerPrecio(String sTransProdId, String sProductoClave, String sTipoUnidad)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select (sum(ifnull(impuesto,0)) -  sum(ifnull(ts.desimpuesto,0)) - sum(ifnull(tv.desimpuesto,0))) as Precio ");
            sConsulta.append("from transproddetalle td ");
            sConsulta.append("left join tpddes ts on td.transproddetalleid=ts.transproddetalleid and td.transprodid=ts.transprodid ");
            sConsulta.append("left join tpddesvendedor tv on td.transproddetalleid=tv.transproddetalleid and td.transprodid=tv.transprodid ");
            sConsulta.append("where td.transprodid='" + sTransProdId + "' and td.productoclave='" + sProductoClave + "' and TD.TIPOUNIDAD='" + sTipoUnidad + "' ");

            ISetDatos datos = BDVend.consultar(sConsulta.toString());
            datos.moveToNext();

            return datos.getDouble("Precio");
        }

        public static double obtenerCantidad(String sCampo, String sFiltro, String sTransprodId, String sProductoClave, String sTipoUnidad)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select sum(" + sCampo + ") as " + sCampo + " ");
            sConsulta.append("from transproddetalle td ");
            sConsulta.append("where ifnull(promocion,0) " + sFiltro + " and td.transprodid='" + sTransprodId + "' and productoclave='" + sProductoClave + "' and tipounidad='" + sTipoUnidad + "' ");

            ISetDatos datos = BDVend.consultar(sConsulta.toString());
            datos.moveToNext();

            return datos.getDouble(sCampo);
        }

		public static double obtenerDescuentoPromocion(String sFiltro, String sTransprodId, String sProductoClave, String sTipoUnidad)throws  Exception {
			StringBuilder sConsulta = new StringBuilder();

			sConsulta.append("select sum(pr.PromocionImp) as Descuento ");
			sConsulta.append("from TransProdDetalle td ");
			sConsulta.append("inner join TrpPrp pr on td.TransProdId = pr.TransProdId and td.TransProdDetalleId = pr.TransProdDetalleId ");
			sConsulta.append("where ifnull(Promocion,0) and pr.PromocionClave " + sFiltro + " and td.TransProdId='" + sTransprodId + "' and ProductoClave='" + sProductoClave + "' and TipoUnidad='" + sTipoUnidad + "' ");

			ISetDatos datos = BDVend.consultar(sConsulta.toString());
			datos.moveToNext();

			return datos.getDouble("Descuento");
		}

        public static ISetDatos obtenerConsignas(String sVisitaClave, String sDiaClave)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select distinct TCon.folio as Folio, tcon.transprodid as IdConsignacion, TDev.transprodid as IdDevolucion, tcon.impuesto as ImpuestoCon ");
            sConsulta.append("from transprod TCon ");
            sConsulta.append("left join TrpTpd on TrpTpd.Transprodid1=TCon.transprodid ");
            sConsulta.append("left  join transprod TDev on TrpTpd.transprodid=TDev.transprodid ");
            sConsulta.append("where TCon.tipo =24  and TCon.tipofase =6");
            sConsulta.append("    and TCon.diaclave1='" + sDiaClave + "' and tcon.visitaclave1='" + sVisitaClave + "' ");

            return BDVend.consultar(sConsulta.toString());
        }

        public static ISetDatos obtenerConsignasDetalle(String sTransprodId)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select td.productoclave as ProductoClave, p.nombre as Nombre, td.precio as Precio, td.tipounidad as TipoUnidad, sum(td.cantidad) as Cantidad ");
            sConsulta.append("from transproddetalle td ");
            sConsulta.append("inner join producto p on td.productoclave = p.productoclave ");
            sConsulta.append("where transprodid='" + sTransprodId + "' ");
            sConsulta.append("group by td.productoclave,p.nombre,td.precio,td.tipounidad ");
            sConsulta.append("order by p.nombre ");

            return BDVend.consultar(sConsulta.toString());
        }

        public static Integer obtenerDevolucionConsigna(String sTransprodId, String sProductoClave, String Tipounidad)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select ifnull(sum(cantidad),0) as Cantidad ");
            sConsulta.append("from transproddetalle ");
            sConsulta.append("where transprodid='" + sTransprodId + "' and productoclave='" + sProductoClave + "' and TipoUnidad = '" + Tipounidad + "'");

            ISetDatos datos = BDVend.consultar(sConsulta.toString());
            datos.moveToNext();

            return datos.getInt("Cantidad");
        }

        public static Integer obtenerConsignaDetalleImpuesto(String sTransprodId, String sProductoClave, String Tipounidad)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select (sum(ifnull(impuesto,0)) -  sum(ifnull(ts.desimpuesto,0)) - sum(ifnull(tv.desimpuesto,0))) as Impuesto ");
            sConsulta.append("from transproddetalle td  ");
            sConsulta.append("left join tpddes ts on td.transproddetalleid=ts.transproddetalleid and td.transprodid=ts.transprodid  ");
            sConsulta.append("left join tpddesvendedor tv on td.transproddetalleid=tv.transproddetalleid and td.transprodid=tv.transprodid ");
            sConsulta.append("where td.transprodid='" + sTransprodId + "' and td.productoclave='" + sProductoClave + "' and td.TipoUnidad = '" + Tipounidad + "'");

            ISetDatos datos = BDVend.consultar(sConsulta.toString());
            datos.moveToNext();

            return datos.getInt("Impuesto");
        }

        public static ISetDatos obtenerCobranza(String sVisitaClave, String sDiaClave)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select sum(ABT.Importe) as Abono, TRP.CFVTipo as CFVTipo, TRP.Tipo as Tipo ");
            sConsulta.append("from Abono ABN ");
            sConsulta.append("inner join AbnTrp ABT on ABN.ABNId = ABT.ABNId ");
            sConsulta.append("inner join TransProd TRP on ABT.TransProdId = TRP.TransProdId ");
            sConsulta.append("where ABN.DiaClave = '" + sDiaClave + "' and ABN.VisitaClave = '" + sVisitaClave + "' ");
            sConsulta.append("group by TRP.CFVTipo, TRP.Tipo ");
            sConsulta.append("order by TRP.Tipo  ");

            return BDVend.consultar(sConsulta.toString());
        }

        public static double obtenerCargos(String sClienteClave, String sDiasClave, String sVisitaClave)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select sum(ifnull(Total,0)) as Total ");
            sConsulta.append("from( ");
            sConsulta.append("  select sum(ifnull(TRP.Total,0)) as Total ");
            sConsulta.append("  from TransProd TRP ");
            sConsulta.append("  inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave  ");
            sConsulta.append("  where VIS.ClienteClave = '" + sClienteClave + "'");
            sConsulta.append("  and VIS.DiaClave in (" + sDiasClave + ") and VIS.VisitaClave <> '" + sVisitaClave + "' ");
            sConsulta.append("  and ((TRP.Tipo = 1 and TRP.TipoFase in (2, 3)) or (TRP.Tipo = 24 and TRP.TipoFase <> 0)) ");
            sConsulta.append("  union ");
            sConsulta.append("  select sum(TRP.Total) as Total ");
            sConsulta.append("  from TransProd TRP ");
            sConsulta.append("  inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave1 and VIS.DiaClave = TRP.DiaClave1 ");
            sConsulta.append("  where VIS.ClienteClave = '" + sClienteClave + "'");
            sConsulta.append("  and VIS.DiaClave in (" + sDiasClave + ") and VIS.VisitaClave <> '" + sVisitaClave + "'");
            sConsulta.append("  and TRP.TipoFase in (2, 3) and TRP.Tipo = 1 ");
            sConsulta.append(") as t");

            ISetDatos datos = BDVend.consultar(sConsulta.toString());
            datos.moveToNext();

            return datos.getInt("Total");
        }

        public static double obtenerTotalAbonos(String sClienteClave, String sDiasClave, String sVisitaClave)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select sum(ifnull(ABN.Total,0)) as Total ");
            sConsulta.append("from Abono ABN ");
            sConsulta.append("inner join Visita VIS on VIS.VisitaClave = ABN.VisitaClave and VIS.DiaClave = ABN.DiaClave ");
            sConsulta.append("where VIS.ClienteClave = '" + sClienteClave + "' ");
            sConsulta.append("and VIS.VisitaClave <> '" + sVisitaClave + "' and VIS.DiaClave in (" + sDiasClave + ")  ");

            ISetDatos datos = BDVend.consultar(sConsulta.toString());
            datos.moveToNext();

            return datos.getInt("Total");
        }

        public static double obtenerTotalDevConsigna(String sClienteClave, String sDiasClave, String sVisitaClave)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select sum(ifnull(TPD.Total,0)) as Total ");
            sConsulta.append("from TransProd TRP ");
            sConsulta.append("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId  ");
            sConsulta.append("inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ");
            sConsulta.append("where TRP.Tipo = 3 and TRP.TipoMotivo = 12 and VIS.ClienteClave = '" + sClienteClave + "' ");
            sConsulta.append("and VIS.VisitaClave <> '" + sVisitaClave + "' and VIS.DiaClave in (" + sDiasClave + ") ");

            ISetDatos datos = BDVend.consultar(sConsulta.toString());
            datos.moveToNext();

            return datos.getInt("Total");
        }

        public static ISetDatos obtenerInventarioEnvase(String sClienteclave)throws  Exception {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select p.nombre as Nombre, SaldoCarga, Cargo, Abono, ppc.venta as Venta ");
            sConsulta.append("from productoprestamocli ppc  ");
            sConsulta.append("inner join producto  p on ppc.productoclave = p.productoclave  ");
            sConsulta.append("where ppc.clienteclave = '" + sClienteclave + "'");

            return BDVend.consultar(sConsulta.toString());
        }
    }

	public static final class ConsultasTicketPreventaMOO{
		public static ISetDatos obtenerDetallePedido(String sTransProdId)throws  Exception {
			StringBuilder sConsulta = new StringBuilder();

			sConsulta.append("select distinct p.Nombre, td.TipoUnidad, td.Cantidad, td.Precio, td.Total ");
			sConsulta.append("from TransProdDetalle td ");
			sConsulta.append("inner join Producto p on p.ProductoClave = td.ProductoClave ");
			sConsulta.append("where td.TransProdId='" + sTransProdId + "' ");
			sConsulta.append("group by td.productoclave,p.nombre ,td.tipounidad ");
			sConsulta.append("order by p.Nombre ");

			return BDVend.consultar(sConsulta.toString());
		}

		public static ISetDatos obtenerDescuentosPedido(String sTransProdId)throws  Exception {
			StringBuilder sConsulta = new StringBuilder();

			sConsulta.append("select sum(DescuentoProm) as DescuentoProm, sum(DescuentoPromEsp) as DescuentoPromEsp from ( ");
			sConsulta.append("select case when TrpPrp.PromocionClave not like 'DEX%' then TrpPrp.PromocionImp else 0 end as DescuentoProm, ");
			sConsulta.append("case when TrpPrp.PromocionClave like 'DEX%' then TrpPrp.PromocionImp else 0 end as DescuentoPromEsp ");
			sConsulta.append("from TransProd T ");
			sConsulta.append("inner join TransProdDetalle TD on T.TransProdId=TD.TransProdId ");
			sConsulta.append("inner join TrpPrp on TD.TransProdId = TrpPrp.TransProdId and TD.TransProdDetalleId = TrpPrp.TransProdDetalleId ");
			sConsulta.append("where T.TransProdId = '" + sTransProdId + "' )");

			return BDVend.consultar(sConsulta.toString());
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

        public static String obtenerFolioFactura(String transprodId) throws Exception{
            ISetDatos stFactura;
            String sFolioFactura = "";
            StringBuilder consulta = new StringBuilder();
            consulta.append("select Folio from Transprod where TransProdId = '"+transprodId+"'");

            stFactura = BDVend.consultar(consulta.toString());

            while(stFactura.moveToNext()){
                sFolioFactura = stFactura.getString(0);
            }

            return sFolioFactura;
        }

        public static boolean obtenerProgramadaParaRecoleccion(String transprodId)
        {
            try {
                ISetDatos datos;
                String sObservaciones = "";
                StringBuilder consulta = new StringBuilder();
                consulta.append("Select Observaciones ")
                        .append("from TRPVtaAcreditada where TransProdId = '" + transprodId + "'");
                datos = BDVend.consultar(consulta.toString());

                while (datos.moveToNext()) {
                    sObservaciones = datos.getString(0);
                }

                return sObservaciones.equals("1");
            }catch(Exception e){
                return false;
            }
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
            int tipoModulo = Integer.parseInt(Sesion.get(Campo.TipoModulo).toString());

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
                consulta.append("where t.Tipo in (2,3,4,6,7,21,5) and t.TipoFase<>0 and t.DiaClave='"+ diaClave +"'  ");
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
                consulta.append("inner join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave and ifnull(t.DiaClave1,t.DiaClave)=v.DiaClave ");
                consulta.append("inner join Cliente c on v.ClienteClave=c.ClienteClave  ");
                consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID  ");
                consulta.append("inner join Producto p on p.ProductoClave=td.ProductoClave ");
                consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.Tipounidad=pd.PruTipoUnidad and td.ProductoClave=pd.ProductoDetClave  ");
                consulta.append("where t.Tipo in (1) and t.TipoFase=" + (tipoModulo == Enumeradores.TiposModulos.PREVENTA ? "1" : "2") + " and v.DiaClave='"+ diaClave +"' ");
                consulta.append(") as z ");
                consulta.append("order by z.Tipo, z.FolioMovimiento, z.Producto ");
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
                consulta.append("where t.Tipo in (2,3,4,6,7,21,5) and t.TipoFase<>0 and t.DiaClave='"+ diaClave +"'   ");
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
                consulta.append("inner join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave and ifnull(t.DiaClave1,t.DiaClave)=v.DiaClave ");
                consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID ");
                consulta.append("inner join Producto p on p.ProductoClave=td.ProductoClave ");
                consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.Tipounidad=pd.PruTipoUnidad and td.ProductoClave=pd.ProductoDetClave ");
                consulta.append("where t.Tipo in (1) and t.TipoFase=" + (tipoModulo == Enumeradores.TiposModulos.PREVENTA ? "1" : "2") + " and v.DiaClave='"+ diaClave +"' ");
                consulta.append(") as z ");
                consulta.append("group by z.Tipo, z.Producto, z.TipoUnidad, z.TipoMovimiento ");
                consulta.append("order by z.Tipo, z.TipoMovimiento, z.Producto ");
            }

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }
    }

    public static final class ConsultaReporteVentas{

        public static ISetDatos obtenerVentasGeneral(String diaClave)throws Exception {
            StringBuilder consulta = new StringBuilder();
            int tipoModulo = Integer.parseInt(Sesion.get(Campo.TipoModulo).toString());

            consulta.append("select t.Folio as Folio, c.NombreCorto as NombreCorto, t.Total as Total ");
            consulta.append("from TransProd t ");
            consulta.append("inner join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave and ifnull(t.DiaClave1,t.DiaClave)=v.DiaClave ");
            consulta.append("inner join Cliente c on v.ClienteClave=c.ClienteClave ");
            consulta.append("where t.Tipo=1 and t.TipoFase in (" + (tipoModulo == Enumeradores.TiposModulos.PREVENTA ? "1" : "2,3") + ") ");
            consulta.append("and v.DiaClave='"+ diaClave +"' ");
            consulta.append("order by t.Folio ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static ISetDatos obtenerVentasPorProductoPorPrecio(String diaClave)throws Exception {
            StringBuilder consulta = new StringBuilder();
            int tipoModulo = Integer.parseInt(Sesion.get(Campo.TipoModulo).toString());

            consulta.append("select td.TipoUnidad as TipoUnidad, td.Precio as Precio, sum(td.Cantidad) as Cantidad ");
            consulta.append("from TransProd t ");
            consulta.append("inner join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave and ifnull(t.DiaClave1,t.DiaClave)=v.DiaClave ");
            consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID  ");
            consulta.append("where t.Tipo=1 and t.TipoFase in (" + (tipoModulo == Enumeradores.TiposModulos.PREVENTA ? "1" : "2,3") + ")");
            consulta.append("and v.DiaClave='"+ diaClave +"' ");
            consulta.append("group by td.TipoUnidad, td.Precio ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static ISetDatos obtenerVentasKiloLitros(String diaClave)throws Exception {
            StringBuilder consulta = new StringBuilder();
            int tipoModulo = Integer.parseInt(Sesion.get(Campo.TipoModulo).toString());

            consulta.append("select sum(td.Cantidad * ifnull(pu.KgLts,0)) as KiloLitros ");
            consulta.append("from TransProd t ");
            consulta.append("inner join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave and ifnull(t.DiaClave1,t.DiaClave)=v.DiaClave ");
            consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID ");
            consulta.append("inner join ProductoUnidad pu on td.ProductoClave=pu.ProductoClave and td.TipoUnidad=pu.PRUTipoUnidad ");
            consulta.append("where t.Tipo=1 and t.TipoFase in (" + (tipoModulo == Enumeradores.TiposModulos.PREVENTA ? "1" : "2,3") + ") ");
            consulta.append("and v.DiaClave='"+ diaClave +"' ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static ISetDatos obtenerVentasDetallado(String diaClave)throws Exception {
            StringBuilder consulta = new StringBuilder();
            int tipoModulo = Integer.parseInt(Sesion.get(Campo.TipoModulo).toString());

			consulta.append("select t.Tipo as Tipo, ifnull(c.Clave,'') || ' - ' || ifnull(c.RazonSocial,'') as Cliente, t.Folio as Folio, p.ProductoClave || ' - ' || p.Nombre as Producto, td.TipoUnidad as TipoUnidad, td.Cantidad as Cantidad,  ");
            consulta.append("case when ifnull(td.Promocion,0)=2 then '*' else td.Precio end as Precio, ");
            consulta.append("case when ifnull(td.Promocion,0)=2 then '' else ((td.Subtotal+td.Impuesto)-ifnull(tds.DesImporte,0)-ifnull(tdsv.DesImporte,0)-ifnull(tds.DesImpuesto,0)-ifnull(tdsv.DesImpuesto,0)) end as Total ");
            consulta.append("from TransProd t ");
            consulta.append("inner join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave and ifnull(t.DiaClave1,t.DiaClave)=v.DiaClave ");
            consulta.append("inner join Cliente c on v.ClienteClave=c.ClienteClave ");
            consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID ");
            consulta.append("left join TpdDes tds on td.TransProdID=tds.TransProdId and td.TransProdDetalleID=tds.TransProdDetalleId ");
            consulta.append("left join TPDDesVendedor tdsv on td.TransProdID=tdsv.TransProdId and td.TransProdDetalleID=tdsv.TransProdDetalleId ");
            consulta.append("inner join Producto p on td.ProductoClave=p.ProductoClave ");
            consulta.append("where t.Tipo=1 and t.TipoFase in (" + (tipoModulo == Enumeradores.TiposModulos.PREVENTA ? "1" : "2,3") + ") ");
            consulta.append("and v.DiaClave='"+ diaClave +"' ");
            consulta.append("order by t.Folio, td.ProductoClave, td.TipoUnidad ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static ISetDatos obtenerVentasPorProducto(String diaClave)throws Exception {
            StringBuilder consulta = new StringBuilder();
            int tipoModulo = Integer.parseInt(Sesion.get(Campo.TipoModulo).toString());

            consulta.append("select p.ProductoClave || ' - ' || p.Nombre as Producto, td.TipoUnidad as TipoUnidad, sum(td.Cantidad) as Cantidad,");
            consulta.append("sum(td.Total) as Total ");
            consulta.append("from TransProd t ");
            consulta.append("inner join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave and ifnull(t.DiaClave1,t.DiaClave)=v.DiaClave ");
            consulta.append("inner join Cliente c on v.ClienteClave=c.ClienteClave ");
            consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID ");
            consulta.append("left join TpdDes tds on td.TransProdID=tds.TransProdId and td.TransProdDetalleID=tds.TransProdDetalleId ");
            consulta.append("left join TPDDesVendedor tdsv on td.TransProdID=tdsv.TransProdId and td.TransProdDetalleID=tdsv.TransProdDetalleId ");
            consulta.append("inner join Producto p on td.ProductoClave=p.ProductoClave ");
            consulta.append("where t.Tipo=1 and t.TipoFase in (" + (tipoModulo == Enumeradores.TiposModulos.PREVENTA ? "1" : "2,3") + ") and ifnull(td.Promocion,0)<>2 ");
            consulta.append("and v.DiaClave='"+ diaClave +"' ");
            consulta.append("group by p.ProductoClave, p.Nombre, td.TipoUnidad ");
            consulta.append("order by p.ProductoClave, p.Nombre ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static ISetDatos obtenerVentasPromocionales(String diaClave)throws Exception {
            StringBuilder consulta = new StringBuilder();
            int tipoModulo = Integer.parseInt(Sesion.get(Campo.TipoModulo).toString());

            consulta.append("select p.ProductoClave || ' - ' || p.Nombre as Producto, td.TipoUnidad as TipoUnidad, sum(td.Cantidad) as Cantidad,");
            consulta.append("sum(td.Total) as Total ");
            consulta.append("from TransProd t ");
            consulta.append("inner join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave and ifnull(t.DiaClave1,t.DiaClave)=v.DiaClave ");
            consulta.append("inner join Cliente c on v.ClienteClave=c.ClienteClave ");
            consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID ");
            consulta.append("left join TpdDes tds on td.TransProdID=tds.TransProdId and td.TransProdDetalleID=tds.TransProdDetalleId ");
            consulta.append("left join TPDDesVendedor tdsv on td.TransProdID=tdsv.TransProdId and td.TransProdDetalleID=tdsv.TransProdDetalleId ");
            consulta.append("inner join Producto p on td.ProductoClave=p.ProductoClave ");
            consulta.append("where t.Tipo=1 and t.TipoFase in (" + (tipoModulo == Enumeradores.TiposModulos.PREVENTA ? "1" : "2,3") + ") and ifnull(td.Promocion,0)=2 ");
            consulta.append("and v.DiaClave='"+ diaClave +"' ");
            consulta.append("group by p.ProductoClave, p.Nombre, td.TipoUnidad ");
            consulta.append("order by p.ProductoClave, p.Nombre ");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static ISetDatos obtenerVentasDetalladoNombreCorto(String diaClave)throws Exception {
            StringBuilder consulta = new StringBuilder();
            int tipoModulo = Integer.parseInt(Sesion.get(Campo.TipoModulo).toString());

			consulta.append("select t.Tipo as Tipo, ifnull(c.Clave,'') || ' - ' || ifnull(c.NombreCorto,'') as Cliente, t.Folio as Folio, p.ProductoClave || ' - ' || p.Nombre as Producto, td.TipoUnidad as TipoUnidad, td.Cantidad as Cantidad,  ");
            consulta.append("case when ifnull(td.Promocion,0)=2 then '*' else td.Precio end as Precio, ");
            consulta.append("case when ifnull(td.Promocion,0)=2 then '' else ((td.Subtotal+td.Impuesto)-ifnull(tds.DesImporte,0)-ifnull(tdsv.DesImporte,0)-ifnull(tds.DesImpuesto,0)-ifnull(tdsv.DesImpuesto,0)) end as Total ");
            consulta.append("from TransProd t ");
            consulta.append("inner join Visita v on ifnull(t.VisitaClave1,t.VisitaClave)=v.VisitaClave and ifnull(t.DiaClave1,t.DiaClave)=v.DiaClave ");
            consulta.append("inner join Cliente c on v.ClienteClave=c.ClienteClave ");
            consulta.append("inner join TransProdDetalle td on t.TransProdID=td.TransProdID ");
            consulta.append("left join TpdDes tds on td.TransProdID=tds.TransProdId and td.TransProdDetalleID=tds.TransProdDetalleId ");
            consulta.append("left join TPDDesVendedor tdsv on td.TransProdID=tdsv.TransProdId and td.TransProdDetalleID=tdsv.TransProdDetalleId ");
            consulta.append("inner join Producto p on td.ProductoClave=p.ProductoClave ");
            consulta.append("where t.Tipo=1 and t.TipoFase in (" + (tipoModulo == Enumeradores.TiposModulos.PREVENTA ? "1" : "2,3") + ") ");
            consulta.append("and v.DiaClave='"+ diaClave +"' ");
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
            consulta.append("Order by Case when TP.Tipo = 7 then 'Descarga' else 'Devolucion' end, TP.Folio, TPD.ProductoClave");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static ISetDatos obtenerProductosAgrupadoTransaccion(String filtroFecha)throws Exception {

            StringBuilder consulta = new StringBuilder();

            consulta.append("Select TP.TransProdID, ");
            consulta.append("   Case when TP.Tipo = 7 then 'Descarga' else 'Devolucion' end as TipoTransaccion, ");
            consulta.append("   TPD.ProductoClave, ");
            consulta.append("   P.Nombre, ");
            consulta.append("   TPD.TipoUnidad, ");
            consulta.append("   sum(TPD.Cantidad * PD.Factor) as Total ");
            consulta.append("From TransProd TP ");
            consulta.append("inner join TransProdDetalle TPD on TPD.TransProdID = TP.TransProdID and TP.Tipo in (4,7) and TP.TipoFase <> 0 ");
            consulta.append("inner join ProductoDetalle PD on PD.ProductoDetClave = TPD.ProductoClave and PD.ProductoClave=TPD.ProductoClave ");
            consulta.append("inner join Producto P on P.ProductoClave = PD.ProductoDetClave ");
            consulta.append("inner join Dia D on D.DiaClave = TP.DiaClave ");
            consulta.append("where P.Contenido = 0 ");
            consulta.append("   and "+filtroFecha + " ");
            consulta.append("group by Case when TP.Tipo = 7 then 'Descarga' else 'Devolucion' end,");
            consulta.append("   TPD.ProductoClave, ");
            consulta.append("   P.Nombre, ");
            consulta.append("   TPD.TipoUnidad ");
            consulta.append("Order by Case when TP.Tipo = 7 then 'Descarga' else 'Devolucion' end, ");
            consulta.append("   TPD.ProductoClave");

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
            consulta.append("Order by Case when TP.Tipo = 7 then 'Descarga' else 'Devolucion' end, TP.Folio, TPD.ProductoClave");

            ISetDatos datos = BDVend.consultar(consulta.toString());

            return datos;
        }

        public static ISetDatos obtenerEnvaseAgrupadoTransaccion(String filtroFecha)throws Exception {

            StringBuilder consulta = new StringBuilder();

            consulta.append("Select TP.TransProdID, ");
            consulta.append("   Case when TP.Tipo = 7 then 'Descarga' else 'Devolucion' end as TipoTransaccion, ");
            consulta.append("   TPD.ProductoClave, ");
            consulta.append("   P.Nombre, ");
            consulta.append("   TPD.TipoUnidad, ");
            consulta.append("   sum(TPD.Cantidad * PD.Factor) as Total ");
            consulta.append("From TransProd TP ");
            consulta.append("inner join TransProdDetalle TPD on TPD.TransProdID = TP.TransProdID and TP.Tipo in (4,7) and TP.TipoFase <> 0 ");
            consulta.append("inner join ProductoDetalle PD on PD.ProductoDetClave = TPD.ProductoClave and PD.ProductoClave=TPD.ProductoClave ");
            consulta.append("inner join Producto P on P.ProductoClave = PD.ProductoDetClave ");
            consulta.append("inner join Dia D on D.DiaClave = TP.DiaClave ");
            consulta.append("where P.Contenido = 1 ");
            consulta.append("   and "+filtroFecha + " ");
            consulta.append("group by Case when TP.Tipo = 7 then 'Descarga' else 'Devolucion' end,");
            consulta.append("   TPD.ProductoClave, ");
            consulta.append("   P.Nombre, ");
            consulta.append("   TPD.TipoUnidad ");
            consulta.append("Order by Case when TP.Tipo = 7 then 'Descarga' else 'Devolucion' end, ");
            consulta.append("   TPD.ProductoClave");

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

	public static final class ConsultasTRPDescCalculadora {
		public static boolean existeDescuento(String transProdID, int orden)throws Exception
		{
			ISetDatos datos = BDVend.consultar("SELECT * from TRPDescCalculadora where TransProdID ='" + transProdID + "' and orden = "+orden);
			boolean res = false;
			if (datos.moveToNext())
			{
				res = true;
			}
			datos.close();
			return res;
		}
	}

	public static final class ConsultasFrecuencias {
		public static ISetDatos recuperarFrecuenciasOrden()throws Exception
		{
			StringBuilder consulta = new StringBuilder();

			consulta.append("SELECT FRE.FrecuenciaClave as _id,  FRE.FrecuenciaClave || ' - ' || FRE.Descripcion as ClaveDescripcion, FRE.Descripcion as Descripcion, FRE.Tipo as Tipo, FRE.Tipo as Tipo,  (CASE WHEN IFNULL(SEC.Orden,0) + 1 > IFNULL(AGE.Orden,0) + 1 THEN  IFNULL(SEC.Orden,0) + 1 ELSE IFNULL(AGE.Orden,0) + 1 END)as SigOrden ");
			consulta.append("from Frecuencia FRE ");
			consulta.append("left join (Select FrecuenciaClave, Max(Orden) as Orden from Agenda group by FrecuenciaClave) AGE on AGE.FrecuenciaClave = FRE.FrecuenciaClave ");
			consulta.append("left join (Select FrecuenciaClave, Max(Orden) as Orden from Secuencia group by FrecuenciaClave) SEC on SEC.FrecuenciaClave = FRE.FrecuenciaClave ");
			return BDVend.consultar(consulta.toString());
		}
	}

	public static final class ConsutasNotaVentaUNI{

		public static ISetDatos obtenerPedidos(int tipoModulo, String clienteClave, String visitaClave) throws Exception
		{
			StringBuilder consulta = new StringBuilder();

			consulta.append("Select TP.Folio, P.ProductoClave, P.Nombre, TPD.Cantidad, TPD.Precio, TPD.Subtotal, ifnull(ti.ImpuestoPU, 0) as Impuesto ");
			consulta.append("from TransProd as TP ");
			consulta.append("inner join TransProdDetalle as TPD on TP.TransProdID = TPD.TransProdID ");
			consulta.append("inner join Producto as P on TPD.ProductoClave = P.ProductoClave ");
			consulta.append("left join tpdimpuesto ti on TPD.transprodid=ti.transprodid and TPD.transproddetalleid=ti.transproddetalleid ");
			consulta.append("where ");
			if(tipoModulo == Enumeradores.TiposModulos.PREVENTA){
				consulta.append("TP.Tipo = 1 and TP.TipoFase = 1 ");
			}else if(tipoModulo == Enumeradores.TiposModulos.VENTA || tipoModulo == Enumeradores.TiposModulos.REPARTO){
				consulta.append("TP.Tipo = 1 and TP.TipoFase = 2 ");
			}
			consulta.append("and TPD.PromocionClave is null ");
			consulta.append("and TP.ClienteClave = '"+clienteClave+"' ");
			consulta.append("and (TP.VisitaClave ='"+visitaClave+"' or TP.VisitaClave1 ='"+visitaClave+"')");


			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerProductosPromo(int tipoModulo, String clienteClave, String visitaClave) throws Exception
		{
			StringBuilder consulta = new StringBuilder();

			consulta.append("select tpd.ProductoClave, p.Nombre, tpd.Cantidad, tpp.PromocionImp as Importe ");
			consulta.append("from Transprod trp ");
			consulta.append("inner join TransprodDetalle tpd on trp.TransprodId=tpd.TransprodId and tpd.Promocion = 1 ");
			consulta.append("inner join TrpPrp tpp on trp.TransProdID = tpp.TransProdID and tpd.TransProdDetalleID = tpp.TransProdDetalleID ");
			consulta.append("inner join Promocion pp on tpp.PromocionClave = pp.PromocionClave and pp.TipoAplicacion <> 4 ");
			consulta.append("inner join Producto p on tpd.ProductoClave = p.ProductoClave ");
			consulta.append("where ");
			if(tipoModulo == Enumeradores.TiposModulos.PREVENTA){
				consulta.append("trp.Tipo = 1 and trp.TipoFase = 1 ");
			}else if(tipoModulo == Enumeradores.TiposModulos.VENTA || tipoModulo == Enumeradores.TiposModulos.REPARTO){
				consulta.append("trp.Tipo = 1 and trp.TipoFase = 2 ");
			}
			consulta.append("and trp.ClienteClave = '"+clienteClave+"' ");
			consulta.append("and (trp.VisitaClave ='"+visitaClave+"' or trp.VisitaClave1 ='"+visitaClave+"')");

			consulta.append("Union all ");
			consulta.append("select tpd.ProductoClave, p.Nombre, tpd.Cantidad, 0 as Importe ");
			consulta.append("from Transprod trp ");
			consulta.append("inner join TransprodDetalle tpd on trp.TransprodId=tpd.TransprodId and  tpd.Promocion = 2 ");
			consulta.append("inner join Producto p on tpd.ProductoClave = p.ProductoClave ");
			consulta.append("where ");
			if(tipoModulo == Enumeradores.TiposModulos.PREVENTA){
				consulta.append("trp.Tipo = 1 and trp.TipoFase = 1 ");
			}else if(tipoModulo == Enumeradores.TiposModulos.VENTA || tipoModulo == Enumeradores.TiposModulos.REPARTO){
				consulta.append("trp.Tipo = 1 and trp.TipoFase = 2 ");
			}
			consulta.append("and trp.ClienteClave = '"+clienteClave+"' ");
			consulta.append("and (trp.VisitaClave ='"+visitaClave+"' or trp.VisitaClave1 ='"+visitaClave+"')");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerCambios(int tipoModulo, String clienteClave, String visitaClave) throws Exception
		{
			StringBuilder consulta = new StringBuilder();

			consulta.append("Select TP.Folio, case when TP.Tipo = 9 then 'C' else 'D' end as Tipo, P.ProductoClave, P.Nombre, TPD.Cantidad ");
			consulta.append("from TransProd TP ");
			consulta.append("inner join TransProdDetalle TPD on TP.TransProdID = TPD.TransProdID ");
			consulta.append("inner join Producto P on TPD.ProductoClave = P.ProductoClave ");
			consulta.append("inner join Visita V on TP.VisitaClave = V.VisitaClave ");
			consulta.append("where TP.tipo in (3,9) ");
			consulta.append("and TP.TipoFase <> 0 ");
			consulta.append("and TP.TipoMovimiento = 1 ");
			consulta.append("and V.ClienteClave = '"+clienteClave+"' ");
			consulta.append("and  (TP.VisitaClave ='"+visitaClave+"' or TP.VisitaClave1 ='"+visitaClave+"')");

			return BDVend.consultar(consulta.toString());
		}

		public static boolean ValidaPendienteConfirmar(String folio) throws Exception
		{
			//Este metodo sirve para ver si el dpcumento estubo en la fase 15, pendiente por confirmar
			//si viene en esa fase entonces manda true
			//si no viene en esa fase manda false
			boolean pasa = false;

			ISetDatos datos = BDVend.consultar("Select ifnull(VisitaClave1,0) as VisitaClave1 from TransProd where Folio = '"+folio+"' and Tipo = 9 and TipoMovimiento = 1");
			if (datos.getCount() > 0)
			{
				datos.moveToNext();
				String resultado = datos.getString("VisitaClave1");
				if(!resultado.equalsIgnoreCase("0")){
					pasa = true;
				}
			}
			datos.close();

			return pasa;
		}


	}

	public static final class ConsultasLiquidacionDis{

		public static ISetDatos obtenerDatosLiquidacion(int tipoConsulta) throws Exception {

			StringBuilder consulta = new StringBuilder();

			switch (tipoConsulta){
				case 1:
					consulta.append("select TransProd.Tipo,TransProdDetalle.ProductoClave , Producto.Nombre, TransProdDetalle.TipoUnidad,sum(case when ifnull(TransProdDetalle.Promocion, 0) <> 2 then TransProdDetalle.Cantidad else 0 end) as Cantidad, sum(case when TransProdDetalle.Promocion = 2 then TransProdDetalle.Cantidad else 0 end) as Promocion, sum(TransProdDetalle.DescuentoImp) as DescuentoDet ");
					consulta.append("from TransProd ");
					consulta.append("inner join TransProdDetalle on TransProd.TransProdID = TransProdDetalle.TransProdID ");
					consulta.append("inner join Producto on TransProdDetalle.ProductoClave = Producto.ProductoClave ");
					consulta.append("where TransProd.Tipo in (1,24)  and TransProd.TipoFase<>0  ");
					consulta.append("group by TransProd.Tipo, TransProdDetalle.ProductoClave,Producto.Nombre, TransProdDetalle.TipoUnidad ");
					consulta.append("order by TransProd.Tipo, Producto.Nombre, TransProdDetalle.TipoUnidad ");
					break;
				case 2:
					consulta.append("Select sum(transprod.total) as Total,sum(transprod.descuentovendedor) as DescuentoVendedor, sum(transprod.descuentoimp) as DescuentoImp ");
					consulta.append("from TransProd ");
					consulta.append("where TransProd.Tipo in (1,24) and TransProd.TipoFase <>0 ");
					break;
			}

			return BDVend.consultar(consulta.toString());
		}

		public static float obtenerTotalCredito() throws Exception{
			float total = 0;
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select case when ifnull(sum(transprod.total),0)=1 then 0 else sum(transprod.total) end as Total ");
			consulta.append("from TransProd ");
			consulta.append("where TransProd.TipoFase<>0 ");
			consulta.append("and ((transprod.tipo=1 and cfvtipo=2)or transprod.tipo=24)");

			ISetDatos datos = BDVend.consultar(consulta.toString());

			if(datos != null){
				if(datos.moveToNext()){
					total = datos.getFloat("Total");
				}
			}

			return total;
		}

		public static float obtenerTotalContado() throws Exception{
			float total = 0;
			StringBuilder consulta = new StringBuilder();
			consulta.append("select ifnull(sum(abndetalle.importe), 0) as Total ");
			consulta.append("from abono ");
			consulta.append("inner join dia on abono.diaclave = dia.diaclave ");
			consulta.append("inner join abndetalle on abono.abnid=abndetalle.abnid  ");
			consulta.append("inner join visita on  abono.visitaclave=visita.visitaclave and abono.diaclave=visita.diaclave  ");
			consulta.append("inner join abntrp on abntrp.abnid=abono.abnid ");
			consulta.append("inner join transprod on abntrp.transprodid=transprod.transprodid ");
			consulta.append("where transprod.cfvtipo=1 and transprod.tipo=1 and transprod.tipofase<>0 ");

			ISetDatos datos = BDVend.consultar(consulta.toString());

			if(datos != null){
				if(datos.moveToNext()){
					total = datos.getFloat("Total");
				}
			}

			return total;
		}

		public static float obtenerTotalCobranza() throws Exception{
			float total = 0;
			StringBuilder consulta = new StringBuilder();
			consulta.append("select ifnull(sum(abndetalle.importe), 0) as Total  ");
			consulta.append("from abono ");
			consulta.append("inner join dia on abono.diaclave = dia.diaclave ");
			consulta.append("inner join abndetalle on abono.abnid=abndetalle.abnid  ");
			consulta.append("inner join visita on  abono.visitaclave=visita.visitaclave and abono.diaclave=visita.diaclave  ");
			consulta.append("inner join abntrp on abntrp.abnid=abono.abnid  ");
			consulta.append("inner join transprod on abntrp.transprodid=transprod.transprodid ");
			consulta.append("where transprod.tipofase<>0 and ((transprod.tipo=1 and transprod.cfvtipo=2) or transprod.tipo=24)");

			ISetDatos datos = BDVend.consultar(consulta.toString());

			if(datos != null){
				if(datos.moveToNext()){
					total = datos.getFloat("Total");
				}
			}

			return total;
		}

	}

	public static final class ConsultasTransaccionDia{

		public static ISetDatos obtenerDatosPreventa(String diaClave) throws Exception {

			StringBuilder consulta = new StringBuilder();

			consulta.append("Select c.Clave || ' - ' || c.RazonSocial as Cliente, v.FechaHoraInicial, v.FechaHoraFinal, tp.Folio, tpd.ProductoClave, p.Nombre, tpd.Cantidad, tpd.Total ");
			consulta.append("from TransProd tp ");
			consulta.append("inner join Visita v on tp.VisitaClave = v.VisitaClave ");
			consulta.append("inner join TransProdDetalle tpd on tp.TransProdID = tpd.TransProdID ");
			consulta.append("inner join Producto p on tpd.ProductoClave = p.ProductoClave ");
			consulta.append("inner join Cliente c on v.ClienteClave = c.ClienteClave ");
			consulta.append("where tp.Tipo = 21 and tp.TipoFase = 1 and v.DiaClave = '"+diaClave+"' ");
			consulta.append("order by tp.Folio, tpd.ProductoClave ");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerDatosPreventaTotales(String diaClave) throws Exception {

			StringBuilder consulta = new StringBuilder();

			consulta.append("Select tpd.ProductoClave, p.Nombre, SUM(tpd.Cantidad) as Cantidad, SUM(tpd.total) as total ");
			consulta.append("from TransProd tp ");
			consulta.append("inner join Visita v on tp.VisitaClave = v.VisitaClave ");
			consulta.append("inner join TransProdDetalle tpd on tp.TransProdID = tpd.TransProdID ");
			consulta.append("inner join Producto p on tpd.ProductoClave = p.ProductoClave ");
			consulta.append("where tp.Tipo = 21 and tp.TipoFase = 1 and v.DiaClave = '"+diaClave+"' ");
			consulta.append("group by tpd.ProductoClave, p.Nombre ");
			consulta.append("order by tpd.ProductoClave ");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerDatosReparto(String diaClave, boolean total) throws Exception{

			StringBuilder consulta = new StringBuilder();

			if(!total){
				consulta.append("Select * from ( ");
				consulta.append("Select tp.Tipo, c.Clave || ' ' || c.RazonSocial as Cliente, v.FechaHoraInicial, v.FechaHoraFinal, tp.Folio, tpd.ProductoClave, p.Nombre, tpd.Cantidad, 0 as Importe, tpd.Total ");
				consulta.append("from TransProd tp ");
				consulta.append("inner join TransProdDetalle tpd on tp.TransProdID = tpd.TransProdID ");
				consulta.append("inner join Producto p on tpd.ProductoClave = p.ProductoClave ");
				consulta.append("inner join Visita v on tp.VisitaClave = v.VisitaClave OR tp.VisitaClave1 = v.VisitaClave ");
				consulta.append("inner join Cliente c on v.ClienteClave = c.ClienteClave ");
				consulta.append("where tp.Tipo = 1 and tp.TipoFase = 2 and v.DiaClave = '"+diaClave+"' ");
				consulta.append("union all ");
				consulta.append("Select tp.Tipo, c.Clave || ' ' || c.RazonSocial as Cliente, v.FechaHoraInicial, v.FechaHoraFinal, tp.Folio, tpd.ProductoClave, p.Nombre, tpd.Cantidad, 0 as Importe, tpd.Total ");
				consulta.append("from TransProd tp ");
				consulta.append("inner join TransProdDetalle tpd on tp.TransProdID = tpd.TransProdID ");
				consulta.append("inner join Producto p on tpd.ProductoClave = p.ProductoClave ");
				consulta.append("inner join Visita v on tp.VisitaClave = v.VisitaClave OR tp.VisitaClave1 = v.VisitaClave ");
				consulta.append("inner join Cliente c on v.ClienteClave = c.ClienteClave ");
				consulta.append("where tp.Tipo = 3 and tp.TipoFase = 1 and v.DiaClave = '"+diaClave+"' ");
				consulta.append("union all ");
				consulta.append("Select 99 as Tipo, c.Clave || ' ' || c.RazonSocial as Cliente, v.FechaHoraInicial, v.FechaHoraFinal, a.Folio, '' as ProductoClave, '' as Nombre, 0 as cantidad, ad.Importe, a.Total  ");
				consulta.append("from Abono a ");
				consulta.append("inner join ABNDetalle ad on a.ABNId = ad.ABNId ");
				consulta.append("inner join Visita v on a.VisitaClave = v.VisitaClave ");
				consulta.append("inner join Cliente c on v.ClienteClave = c.ClienteClave ");
				consulta.append("where v.DiaClave = '"+diaClave+"' and ad.TipoPago = 1 ");
				consulta.append(") as t ");
				consulta.append("order by t.cliente, t.Tipo,  t.Folio, t.ProductoClave");
			}else{
				consulta.append("Select Tipo, ProductoClave, Nombre, SUM(Cantidad) as Cantidad, SUM(Importe) as Importe, SUM(total) as total from( ");
				consulta.append("Select tp.Tipo, tpd.ProductoClave, p.Nombre,tpd.Cantidad, 0 as Importe, 0 as Total ");
				consulta.append("from TransProd tp ");
				consulta.append("inner join TransProdDetalle tpd on tp.TransProdID = tpd.TransProdID ");
				consulta.append("inner join Producto p on tpd.ProductoClave = p.ProductoClave ");
				consulta.append("inner join Visita v on tp.VisitaClave = v.VisitaClave OR tp.VisitaClave1 = v.VisitaClave ");
				consulta.append("where tp.Tipo = 1 and tp.TipoFase = 2 and v.DiaClave = '"+diaClave+"' ");
				consulta.append("union all ");
				consulta.append("Select tp.Tipo, tpd.ProductoClave, p.Nombre,tpd.Cantidad, 0 as Importe, 0 as Total ");
				consulta.append("from TransProd tp ");
				consulta.append("inner join TransProdDetalle tpd on tp.TransProdID = tpd.TransProdID ");
				consulta.append("inner join Producto p on tpd.ProductoClave = p.ProductoClave ");
				consulta.append("inner join Visita v on tp.VisitaClave = v.VisitaClave OR tp.VisitaClave1 = v.VisitaClave ");
				consulta.append("where tp.Tipo = 3 and tp.TipoFase = 1 and v.DiaClave = '"+diaClave+"' ");
				consulta.append("union all ");
				consulta.append("Select 99 as Tipo, '' as ProductoClave, '' as Nombre, 0 as Cantidad,  ad.Importe, a.Total ");
				consulta.append("from Abono a ");
				consulta.append("inner join ABNDetalle ad on a.ABNId = ad.ABNId ");
				consulta.append("inner join Visita v on a.VisitaClave = v.VisitaClave ");
				consulta.append("inner join Cliente c on v.ClienteClave = c.ClienteClave ");
				consulta.append("where v.DiaClave = '"+diaClave+"' and ad.TipoPago = 1  ");
				consulta.append(") as t ");
				consulta.append("group by t.Tipo, t.ProductoClave, t.Nombre ");
				consulta.append("order by t.Tipo, t.ProductoClave ");
			}

			return BDVend.consultar(consulta.toString());
		}

	}

    public static final class ConsultasReporteIndicadoresCRJ {

        public static String obtenerRutas()throws Exception {
            String sRutas = "";
            ISetDatos rutas = BDVend.consultar("select RUTClave from Ruta");
            while(rutas.moveToNext()) {
                sRutas += rutas.getString("RUTClave") + ", ";
            }
            rutas.close();
            if (sRutas.length() > 0)
                sRutas = sRutas.substring(0, sRutas.length() - 2);
            return sRutas;
        }

        public static ISetDatos obtenerVentas(String DiaClave) throws Exception{
            StringBuilder consulta = new StringBuilder();

            if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA) {
                consulta.append("select sum(TPD.Cantidad) as Cajas, sum(TPD.Cantidad * PRU.KgLts) as Hlts ");
                consulta.append("from TransProd TRP ");
                consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                consulta.append("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
                consulta.append("inner join ProductoUnidad PRU on TPD.ProductoClave = PRU.ProductoClave and TPD.TipoUnidad = PRU.PRUTipoUnidad ");
                consulta.append("where TRP.Tipo in (1, 21) and TRP.TipoFase <> 0 and VIS.RUTClave <> 'RUT001' ");
            }else {
                consulta.append("select sum(TPD.Cantidad) as Cajas, sum(TPD.Cantidad * PRU.KgLts) as Hlts ");
                consulta.append("from TransProd TRP ");
                consulta.append("inner join Visita VIS on case when (TRP.VisitaClave1 is null) then TRP.VisitaClave else TRP.VisitaClave1 end = VIS.VisitaClave ");
                consulta.append("and case when (TRP.DiaClave1 is null) then TRP.DiaClave else TRP.DiaClave1 end = VIS.DiaClave ");
                consulta.append("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
                consulta.append("inner join ProductoUnidad PRU on TPD.ProductoClave = PRU.ProductoClave and TPD.TipoUnidad = PRU.PRUTipoUnidad ");
                consulta.append("where TRP.Tipo = 1 and TRP.TipoFase in (2,3) and VIS.RUTClave <> 'RUT001' ");
            }
            consulta.append("and VIS.DiaClave = '" + DiaClave + "' ");

            return BDVend.consultar(consulta.toString());
        }


        public static int obtenerVisitasProgramadas(String DiaClave) throws Exception {
            ISetDatos agenda;
            int visitas = 0;
            StringBuilder consulta = new StringBuilder();
            consulta.append("select count(ClienteClave) as VisitasProgramadas ");
            consulta.append("from Agenda ");
            consulta.append("where RUTClave <> 'RUT001' ");
            consulta.append("and DiaClave = '" + DiaClave + "' ");
            agenda = BDVend.consultar(consulta.toString());

            agenda.moveToFirst();
            visitas = agenda.getInt("VisitasProgramadas");
            agenda.close();

            return visitas;
        }

        public static ISetDatos obtenerVisitasRealizadas(String DiaClave) throws Exception{
            StringBuilder consulta = new StringBuilder();
            consulta.append("select count(distinct VIS.ClienteClave) as VisitasRealizadas, ");
            consulta.append("count(distinct case when (VIS.FueraFrecuencia = 0) then null else VIS.ClienteClave end) as VisitasFueraFrecuencia, ");
            consulta.append("count(distinct case when (TRP.VisitaClave is null) then null else VIS.ClienteClave end) as VisitasConVenta ");
            consulta.append("from Visita VIS ");
            consulta.append("left join ( ");
            if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA) {
                consulta.append("   select distinct VisitaClave, DiaClave ");
                consulta.append("   from TransProd TRP ");
                consulta.append("   where TRP.Tipo in (1, 21) and TRP.TipoFase <> 0 ");
                consulta.append("   and TRP.DiaClave = '" + DiaClave + "' ");
            }
            else {
                consulta.append("   select distinct case when VisitaClave1 is null then VisitaClave else VisitaClave1 end as VisitaClave, ");
                consulta.append("   case when DiaClave1 is null then DiaClave else DiaClave1 end as DiaClave ");
                consulta.append("   from TransProd TRP ");
                consulta.append("   where TRP.Tipo = 1 and TRP.TipoFase in (2, 3) ");
                consulta.append("   and case when DiaClave1 is null then TRP.DiaClave else TRP.DiaClave1 end = '" + DiaClave + "' ");
            }
            consulta.append(") TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ");
            consulta.append("where VIS.RUTClave <> 'RUT001' and VIS.DiaClave = '" + DiaClave + "' ");
            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerTiemposVisitas(String DiaClave) throws Exception {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select min(FechaHoraInicial) as PrimerHoraVisita, max(FechaHoraFinal) as UltimaHoraVisita, ");
            consulta.append("sum((julianday(FechaHoraFinal)-julianday(FechaHoraInicial))*(86400000)) as TiempoServicio ");
            consulta.append("from Visita ");
            consulta.append("where RUTClave <> 'RUT001' and DiaClave = '" + DiaClave + "' ");
            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerClienteMayorTiempo(String DiaClave) throws Exception {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select CLI.Clave, CLI.RazonSocial, VIS.FechaHoraInicial, VIS.FechaHoraFinal, VIS.TiempoServicio ");
            consulta.append("from Cliente CLI ");
            consulta.append("inner join ( ");
            consulta.append("select ClienteClave, FechaHoraInicial, FechaHoraFinal, max((julianday(FechaHoraFinal)-julianday(FechaHoraInicial))*(86400000)) as TiempoServicio ");
            consulta.append("from Visita ");
            consulta.append("where RUTClave <> 'RUT001' and DiaClave = '" + DiaClave + "' ");
            consulta.append(")as VIS on CLI.ClienteClave = VIS.ClienteClave ");
            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerClientesCodigoNoLeido(String DiaClave) throws Exception {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select distinct CLI.Clave, CLI.RazonSocial ");
            consulta.append("from Visita VIS ");
            consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
            consulta.append("where VIS.RUTClave <> 'RUT001' and VIS.DiaClave = '" + DiaClave + "' ");
            consulta.append("and VIS.CodigoLeido = 0 ");
            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerImproductividadVenta(String DiaClave) throws Exception {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select CLI.Clave, CLI.RazonSocial, VIS.FechaHoraInicial, IMV.TipoMotivo ");
            consulta.append("from ImproductividadVenta IMV ");
            consulta.append("inner join Visita VIS on IMV.VisitaClave = VIS.VisitaClave and IMV.DiaClave = VIS.DiaClave ");
            consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
            consulta.append("where VIS.RutClave <> 'RUT001' --and VIS.DiaClave = '" + DiaClave + "' ");
            return BDVend.consultar(consulta.toString());
        }

    }

    public static final class ConsultasReporteDifInventarioCRJ {

        public static ISetDatos obtenerCargas(String DiaClave) throws Exception{
            StringBuilder consulta = new StringBuilder();

            consulta.append("select PRO.ProductoClave, PRO.Nombre, TPD.TipoUnidad, sum(TPD.Cantidad) as Cantidad ");
            consulta.append("from TransProd TRP ");
            consulta.append("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
            consulta.append("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ");
            consulta.append("where TRP.Tipo = 2 and TRP.TipoFase <> 0 ");
            consulta.append("and TRP.DiaClave = '" + DiaClave + "' ");
            consulta.append("group by PRO.ProductoClave, PRO.Nombre, TPD.TipoUnidad ");

            return BDVend.consultar(consulta.toString());
        }
    }

    public static final class ConsultasReportesBYD {

        public static ISetDatos obtenerHorasJornada(String DiaClave) throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("select VEJFechaInicial, FechaFinal ");
            consulta.append("from VendedorJornada ");
            consulta.append("where DiaClave = '" + DiaClave + "' ");

            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerHorasVenta(String DiaClave) throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("select min(VIS.FechaHoraInicial) as HoraPrimerVenta, max(VIS.FechaHoraInicial) as HoraUltimaVenta ");
            consulta.append("from TransProd TRP ");
            if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA) {
                consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                consulta.append("where TRP.Tipo in (1, 21, 24) and TRP.TipoFase <> 0 ");
            }else {
                consulta.append("inner join Visita VIS on case when (TRP.VisitaClave1 is null) then TRP.VisitaClave else TRP.VisitaClave1 end = VIS.VisitaClave ");
                consulta.append("and case when (TRP.DiaClave1 is null) then TRP.DiaClave else TRP.DiaClave1 end = VIS.DiaClave ");
                consulta.append("where ((TRP.Tipo = 1 and TRP.TipoFase in (2,3)) or (TRP.Tipo = 24 and TRP.TipoFase <> 0)) ");
            }
            consulta.append("and VIS.DiaClave = '" + DiaClave + "' ");

            return BDVend.consultar(consulta.toString());
        }

        public static int obtenerVisitasProgramadas(String DiaClave) throws Exception {
            ISetDatos agenda;
            int visitas = 0;
            StringBuilder consulta = new StringBuilder();
            consulta.append("select count(ClienteClave) as VisitasProgramadas ");
            consulta.append("from Agenda ");
            consulta.append("where DiaClave = '" + DiaClave + "' ");
            agenda = BDVend.consultar(consulta.toString());

            agenda.moveToFirst();
            visitas = agenda.getInt("VisitasProgramadas");
            agenda.close();

            return visitas;
        }

        public static ISetDatos obtenerVisitasRealizadas(String DiaClave) throws Exception{
            StringBuilder consulta = new StringBuilder();
            consulta.append("select count(distinct VIS.ClienteClave) as VisitasRealizadas, ");
            consulta.append("count(distinct case when (VIS.FueraFrecuencia = 0) then null else VIS.ClienteClave end) as VisitasFueraFrecuencia, ");
            consulta.append("count(distinct case when (TRP.VisitaClave is null) then null else VIS.ClienteClave end) as VisitasConVenta, ");
            consulta.append("count(distinct case when (CLI.PublicoGeneral = 0) then null else VIS.ClienteClave end) as VisitasPublicoGeneral, ");
            consulta.append("count(distinct case when (VIS.CodigoLeido = 1) then null else VIS.ClienteClave end) as VisitasSinLector ");
            consulta.append("from Visita VIS ");
            consulta.append("left join ( ");
            if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA) {
                consulta.append("   select distinct VisitaClave, DiaClave ");
                consulta.append("   from TransProd TRP ");
                consulta.append("   where TRP.Tipo in (1, 21, 24) and TRP.TipoFase <> 0 ");
                consulta.append("   and TRP.DiaClave = '" + DiaClave + "' ");
            }
            else {
                consulta.append("   select distinct case when VisitaClave1 is null then VisitaClave else VisitaClave1 end as VisitaClave, ");
                consulta.append("   case when DiaClave1 is null then DiaClave else DiaClave1 end as DiaClave ");
                consulta.append("   from TransProd TRP ");
                consulta.append("   where ((TRP.Tipo = 1 and TRP.TipoFase in (2, 3)) or (TRP.Tipo = 24 and TRP.TipoFase <> 0)) ");
                consulta.append("   and case when DiaClave1 is null then TRP.DiaClave else TRP.DiaClave1 end = '" + DiaClave + "' ");
            }
            consulta.append(") TRP on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ");
            consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
            consulta.append("where VIS.DiaClave = '" + DiaClave + "' ");
            return BDVend.consultar(consulta.toString());
        }

        public static int obtenerProductosConVenta(String DiaClave) throws Exception {
            StringBuilder consulta = new StringBuilder();
            int productos = 0;

            consulta.append("select count(distinct TPD.ProductoClave) as ProductosConVenta ");
            consulta.append("from TransProd TRP ");
            consulta.append("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ");
            if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA) {
                consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                consulta.append("where TRP.Tipo in (1, 21, 24) and TRP.TipoFase <> 0 ");
            }else {
                consulta.append("inner join Visita VIS on case when (TRP.VisitaClave1 is null) then TRP.VisitaClave else TRP.VisitaClave1 end = VIS.VisitaClave ");
                consulta.append("and case when (TRP.DiaClave1 is null) then TRP.DiaClave else TRP.DiaClave1 end = VIS.DiaClave ");
                consulta.append("where ((TRP.Tipo = 1 and TRP.TipoFase in (2,3)) or (TRP.Tipo = 24 and TRP.TipoFase <> 0)) ");
            }
            consulta.append("and VIS.DiaClave = '" + DiaClave + "' ");
            productos = BDVend.bd.ejecutarEscalarInteger(consulta.toString());

            return productos;
        }

        public static int obtenerTotalProductos() throws Exception{
            StringBuilder consulta = new StringBuilder();
            int productos = 0;

            consulta.append("select count(ProductoClave) as TotalProductos from Inventario ");
            productos = BDVend.bd.ejecutarEscalarInteger(consulta.toString());

            return productos;
        }

		public static ISetDatos obtenerDistribucionesBYD(int modo, String DiaClave) throws Exception {

			StringBuilder consulta = new StringBuilder();

			if(modo == Enumeradores.TiposModulos.PREVENTA) {
				consulta.append("Select p.ProductoClave, p.Nombre, SUM(tpd.Cantidad) as Ventas, COUNT(distinct v.ClienteClave)  as Clientes ");
				consulta.append("from TransProd as tp ");
				consulta.append("inner join Visita as v on tp.DiaClave = v.DiaClave and tp.VisitaClave = v.VisitaClave ");
				consulta.append("inner join TransProdDetalle as tpd on tp.TransProdID = tpd.TransProdID ");
				consulta.append("inner join Producto as p on tpd.ProductoClave = p.ProductoClave ");
				consulta.append("where tp.Tipo in (1,21) and tp.TipoFase <> 0 and v.DiaClave = '"+DiaClave+"' ");
				consulta.append("Group By p.ProductoClave, p.Nombre ");
				consulta.append("Order by p.Nombre ");

			}else if(modo == Enumeradores.TiposModulos.REPARTO || modo == Enumeradores.TiposModulos.VENTA) {
				consulta.append("Select p.ProductoClave, p.Nombre, SUM(tpd.Cantidad) as Ventas, COUNT(distinct v.ClienteClave)  as Clientes ");
				consulta.append("from TransProd as tp ");
				consulta.append("inner join Visita as v on tp.DiaClave = v.DiaClave and (tp.VisitaClave = v.VisitaClave or tp.VisitaClave1 = v.ClienteClave) ");
				consulta.append("inner join TransProdDetalle as tpd on tp.TransProdID = tpd.TransProdID ");
				consulta.append("inner join Producto as p on tpd.ProductoClave = p.ProductoClave ");
				consulta.append("where tp.Tipo = 1 and tp.TipoFase = 2 and v.DiaClave = '"+DiaClave+"' ");
				consulta.append("Group By p.ProductoClave, p.Nombre ");
				consulta.append("Order by p.Nombre ");
			}

			return BDVend.consultar(consulta.toString());
		}

        public static ISetDatos obtenerClientesConVenta(String DiaClave) throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("select vis.ClienteClave, cli.RazonSocial, count(distinct(vis.VisitaClave)) as Visitas, ");
            consulta.append("sum(case when vis.CodigoLeido = 0 then 1 else 0 end) as CodigoNoLeido, ");
            consulta.append("sum(case when trp.TipoFase = 0 then 1 else 0 end) as VentaCancelada, ");
            consulta.append("sum(case when trp.TipoFase <> 0 then trp.Total else 0 end) as TotalVenta ");
            consulta.append("from TransProd trp ");
            consulta.append("inner join Visita vis on ifnull(trp.VisitaClave1, trp.VisitaClave) = vis.VisitaClave and ifnull(trp.DiaClave1, trp.DiaClave) = vis.DiaClave ");
            consulta.append("inner join Cliente cli on vis.ClienteClave = cli.ClienteClave ");
            consulta.append("where trp.Tipo in (1, 24) and vis.DiaClave = '" + DiaClave + "' ");
            consulta.append("group by vis.ClienteClave, cli.RazonSocial ");
            consulta.append("order by cli.RazonSocial ");

            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerClientesNoVisitados(String DiaClave) throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("select distinct cli.RazonSocial ");
            consulta.append("from Agenda agv ");
            consulta.append("inner join Cliente cli on agv.ClienteClave = cli.ClienteClave ");
            consulta.append("left join Visita vis on agv.ClienteClave = vis.ClienteClave and agv.DiaClave = vis.DiaClave ");
            consulta.append("where agv.DiaClave = '" + DiaClave + "' and vis.DiaClave is null ");
            consulta.append("order by cli.RazonSocial ");

            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerClientesSinVenta(String DiaClave) throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("select cli.RazonSocial, imv.TipoMotivo ");
            consulta.append("from Visita vis ");
            consulta.append("inner join ImproductividadVenta imv on vis.VisitaClave = imv.VisitaClave and vis.DiaClave = imv.DiaClave ");
            consulta.append("inner join Cliente cli on vis.ClienteClave = cli.ClienteClave ");
            consulta.append("where vis.DiaClave = '" + DiaClave + "' ");
            consulta.append("order by cli.RazonSocial ");

            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerDepositos(String DiaClave) throws Exception {
            StringBuilder consulta = new StringBuilder();

            consulta.append("select abd.TipoPago, sum(adp.Importe) as Importe ");
            consulta.append("from Deposito dep ");
            consulta.append("inner join AbdDep adp on dep.DEPId = adp.DEPId ");
            consulta.append("inner join ABNDetalle abd on adp.ABNId = abd.ABNId ");
            consulta.append("where dep.DiaClave = '" + DiaClave + "' ");
            consulta.append("group by abd.TipoPago ");

            return BDVend.consultar(consulta.toString());
        }

		public static ISetDatos obtenerCargas(String transProdId, boolean contenedor) throws Exception{
			StringBuilder consulta = new StringBuilder();

			if(contenedor){
				consulta.append("Select p2.ProductoClave, p2.Nombre as Articulo, SUM(tpd.Cantidad) as Piezas, ppv.Precio *  SUM(tpd.Cantidad ) AS Monto ");
				consulta.append("from TransProd tp ");
				consulta.append("inner join Vendedor v on v.USUid = tp.MUsuarioId ");
				consulta.append("inner join Cliente c on v.ClienteModelo = c.ClienteClave ");
				consulta.append("inner join TransProdDetalle tpd on tp.TransProdID = tpd.TransProdID ");
				consulta.append("inner join Producto p on tpd.ProductoClave = p.ProductoClave ");
				consulta.append("inner join ProductoDetalle pd on p.ProductoClave = pd.ProductoClave and tpd.TipoUnidad = pd.PRUTipoUnidad and p.ProductoClave = pd.ProductoDetClave ");
				consulta.append("inner join ProductoUnidad pu on p.ProductoClave = pu.ProductoClave and tpd.TipoUnidad = pu.PRUTipoUnidad ");
				consulta.append("inner join ProductoDetalle pum on pum.ProductoClave=p2.ProductoClave and pum.Factor=1 ");
				consulta.append("inner join PrecioProductoVig ppv on ppv.ProductoClave = pum.ProductoClave and ppv.PRUTipoUnidad =  pum.PRUTipoUnidad  and v.ListaPrecioBase= ppv.PrecioClave and DATE('Now') between ppv.PPVFechaInicio and ppv.FechaFin ");
				consulta.append("inner join Producto p2 on p2.ProductoClave = pu.contenedor ");
				consulta.append("where tp.Tipo = 2 and tp.TransProdId = '"+transProdId+"' ");
				consulta.append("Group by  p2.ProductoClave,p2.Nombre");

			}else{
				consulta.append("Select p.ProductoClave ,p.Nombre as Articulo, (tpd.Cantidad * pd.Factor) as Piezas , (ppv.Precio * (tpd.Cantidad * pd.Factor)) AS Monto,ppv.Precio as PrecioBase,c.TipoImpuesto ");
				consulta.append("from TransProd tp  ");
				consulta.append("inner join Vendedor v on v.USUid = tp.MUsuarioId ");
				consulta.append("inner join Cliente c on v.ClienteModelo = c.ClienteClave ");
				consulta.append("inner join TransProdDetalle tpd on tp.TransProdID = tpd.TransProdID ");
				consulta.append("inner join Producto p on tpd.ProductoClave = p.ProductoClave ");
				consulta.append("inner join ProductoDetalle pd on p.ProductoClave = pd.ProductoClave and tpd.TipoUnidad = pd.PRUTipoUnidad and p.ProductoClave = pd.ProductoDetClave ");
				consulta.append("inner join ProductoDetalle pum on pum.ProductoClave=p.ProductoClave and pum.Factor=1 ");
				consulta.append("inner join PrecioProductoVig ppv on ppv.ProductoClave = pum.ProductoClave and ppv.PRUTipoUnidad =  pum.PRUTipoUnidad  and v.ListaPrecioBase= ppv.PrecioClave and DATE('Now') between ppv.PPVFechaInicio and ppv.FechaFin ");
				consulta.append("where tp.Tipo = 2 and tp.TransProdId = '"+transProdId+"' ");
				consulta.append("order by p.ProductoClave ,p.Nombre");

			}

			return BDVend.consultar(consulta.toString());
		}

        public static ISetDatos obtenerDetallesTicketVenta(String transprodID) throws Exception{
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.append("select pro.ProductoClave, pro.Nombre, sum(tpd.Cantidad) as Cantidad, tpd.Precio, sum(tpd.Impuesto) as Impuesto ");
            sConsulta.append("from Transprod trp ");
            sConsulta.append("inner join TransprodDetalle tpd on trp.TransprodId=tpd.TransprodId and coalesce(tpd.Promocion,0)<>2 ");
            sConsulta.append("inner join Producto pro on tpd.ProductoClave=pro.ProductoClave ");
            sConsulta.append("where trp.TransProdID='" + transprodID + "' ");
            sConsulta.append("group by pro.ProductoClave, pro.Nombre, tpd.Precio ");
            sConsulta.append("order by tpd.Precio, pro.Nombre ");

            return BDVend.consultar(sConsulta.toString());
        }

    }

	public static final class ConsultasTicketCOM{
		public static ISetDatos obtenerDetallesTicket(String transProdID) throws Exception{
			StringBuilder consulta = new StringBuilder();
			ISetDatos datos = null;
			consulta.append("SELECT (TPD.ProductoClave || ' ' || Pro.Nombre) AS Producto, TPD.ProductoClave, TPD.Cantidad, TPD.Precio, TPD.TransProdDetalleID FROM TransProd TP ");
			consulta.append("INNER JOIN TransProdDetalle TPD ON TP.TransProdID = TPD.TransProdID ");
			consulta.append("INNER JOIN Producto Pro ON TPD.ProductoClave = Pro.ProductoClave ");
			consulta.append("WHERE TP.TransProdID = '" +transProdID+ "' ");
			consulta.append("ORDER BY TPD.ProductoClave");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos getPromocionProducto(String transProdDetalleID, boolean promocionPR, String clienteClave) throws Exception{

			StringBuilder consulta = new StringBuilder();
			String tipoPromocion = "'DD%'";
			if(promocionPR)
				tipoPromocion = "'PR%'";

			/*consulta.append("SELECT Prom.Nombre, SUM(PromocionImp) AS Promocion");
			consulta.append("FROM TrpPrp AS TP");
			consulta.append("INNER JOIN Promocion AS Prom ON Prom.PromocionClave = TP.PromocionClave");
			consulta.append("WHERE TP.TransProdDetalleID IN (" +transProdDetalleID+ ") AND TP.PromocionClave LIKE " +tipoPromocion);
			consulta.append("GROUP BY Prom.Nombre");*/
			consulta.append("SELECT  ");
			//if(!promocionPR)
			//	consulta.append("DISTINCT");
			consulta.append(" Esq.Nombre, PR.Porcentaje, PR.Importe, Pro.TipoAplicacion, TP.PromocionImp ");
			consulta.append("FROM TrpPrp TP ");
			consulta.append("INNER JOIN PromocionRegla PR ON TP.PromocionClave = PR.PromocionClave AND TP.PromocionReglaID = PR.PromocionReglaID ");
			consulta.append("INNER JOIN PromocionDetalle PD ON PR.PromocionClave = PD.PromocionClave ");
			consulta.append("INNER JOIN Promocion Pro ON PR.PromocionClave = Pro.PromocionClave ");
			consulta.append("INNER JOIN Esquema Esq ON PD.EsquemaID = Esq.EsquemaID ");
			consulta.append("WHERE TP.TransProdDetalleID IN (" +transProdDetalleID+ ") AND TP.PromocionClave LIKE " + tipoPromocion);
			consulta.append(" AND Esq.EsquemaID IN (SELECT EsquemaID FROM ClienteEsquema WHERE ClienteClave = '" +clienteClave+ "')");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos getPromocionProductoDD(String transProdDetalleID, String clienteClave) throws Exception{

			StringBuilder consulta = new StringBuilder();

			consulta.append("SELECT  ");
			consulta.append(" Esq.Nombre, SUM(TP.PromocionImp) AS PromocionImp ");
			consulta.append("FROM TrpPrp TP ");
			consulta.append("INNER JOIN PromocionRegla PR ON TP.PromocionClave = PR.PromocionClave AND TP.PromocionReglaID = PR.PromocionReglaID ");
			consulta.append("INNER JOIN PromocionDetalle PD ON PR.PromocionClave = PD.PromocionClave ");
			consulta.append("INNER JOIN Promocion Pro ON PR.PromocionClave = Pro.PromocionClave ");
			consulta.append("INNER JOIN Esquema Esq ON PD.EsquemaID = Esq.EsquemaID ");
			consulta.append("WHERE TP.TransProdDetalleID IN (" +transProdDetalleID+ ") AND TP.PromocionClave LIKE 'DD%'" );
			consulta.append(" AND Esq.EsquemaID IN (SELECT EsquemaID FROM ClienteEsquema WHERE ClienteClave = '" +clienteClave+ "')");
			consulta.append(" GROUP BY Esq.Nombre");

			return BDVend.consultar(consulta.toString());
		}
	}

    public static final class ConsultasKardexUnidad {

        public static void generarInventarioKardex() throws Exception {
            StringBuilder consulta = new StringBuilder();
            consulta.append("delete from KardexUnidad ");
            BDVend.getBD().ejecutarComando(consulta.toString());

            consulta = new StringBuilder();
            consulta.append("insert into KardexUnidad ");
            consulta.append("select t.ProductoClave, t.TipoUnidad, sum(t.EntradaDisponible) as EntradaDisponible, ");
            consulta.append("sum(t.EntradaNoDisponible) as EntradaNoDisponible, sum(t.Salida) as Salida ");
            consulta.append("from ( ");
            //consulta.append("   --Entradas Disponible ");
            consulta.append("   select td.ProductoClave, td.TipoUnidad, sum(td.Cantidad) as EntradaDisponible, 0 as EntradaNoDisponible, 0 as Salida ");
            consulta.append("   from Transprod t ");
            consulta.append("   inner join Dia d on t.DiaClave=d.DiaClave ");
            consulta.append("   inner join TransprodDetalle td on t.TransprodId=td.TransprodId ");
            consulta.append("   inner join Producto p on td.ProductoClave=p.ProductoClave and p.Contenido=0 ");
            consulta.append("   left join TrpTpd tt on t.TransprodId=tt.TransprodId and td.TransprodDetalleId=tt.TransprodDetalleId ");
            consulta.append("   where d.DiaClave in (select DiaClave from Dia where FueraFrecuencia=0) and (t.Tipo in (2,3) and t.TipoFase<>0) ");
            consulta.append("   group by td.ProductoClave, td.TipoUnidad ");
            consulta.append("   union all ");
            //consulta.append("   --Entradas No Disponible ");
            consulta.append("   select td.ProductoClave, td.TipoUnidad, 0 as EntradaDisponible, sum(td.Cantidad) as EntradaNoDisponible, 0 as Salida ");
            consulta.append("   from Transprod t ");
            consulta.append("   inner join TransprodDetalle td on t.TransprodId=td.TransprodId ");
            consulta.append("   inner join Producto p on td.ProductoClave=p.ProductoClave and p.Contenido=0 ");
            consulta.append("   where (t.Tipo in (1) and t.TipoFase=1) and td.ProductoClave in ( ");
            consulta.append("       select td.ProductoClave ");
            consulta.append("       from Transprod t ");
            consulta.append("       inner join Dia d on t.DiaClave=d.DiaClave ");
            consulta.append("       inner join TransprodDetalle td on t.TransprodId=td.TransprodId ");
            consulta.append("       inner join Producto p on td.ProductoClave=p.ProductoClave and p.Contenido=0 ");
            consulta.append("       left join TrpTpd tt on t.TransprodId=tt.TransprodId ");
            consulta.append("       where d.DiaClave in (select DiaClave from Dia where FueraFrecuencia=0) and (t.Tipo in (2,3) and t.TipoFase<>0) ");
            consulta.append("       group by td.ProductoClave, td.TipoUnidad ");
            consulta.append("   ) ");
            consulta.append("   group by td.ProductoClave, td.TipoUnidad ");
            consulta.append("   union all ");
            //consulta.append("   --Salidas ");
            consulta.append("   select td.ProductoClave, td.TipoUnidad, 0 as EntradaDisponible, 0 as EntradaNoDisponible, sum(case when t.Tipo=24 and t.TipoFase=8 and t.DiaClave<>t.DiaClave1 then 0 else td.Cantidad end) as Salidas ");
            consulta.append("   from Transprod t ");
            consulta.append("   inner join Dia d on ifnull(t.DiaClave1,t.DiaClave)=d.DiaClave ");
            consulta.append("   inner join TransprodDetalle td on t.TransprodId=td.TransprodId ");
            consulta.append("   inner join Producto p on td.ProductoClave=p.ProductoClave and p.Contenido=0 ");
            consulta.append("   left join TrpTpd tt on t.TransprodId=tt.TransprodId ");
            consulta.append("   where d.DiaClave in (select DiaClave from Dia where FueraFrecuencia=0) and ((t.Tipo=1 and t.TipoFase in (2,3) and t.TransprodId not in (select coalesce(FacturaId,'') from Transprod where Tipo=24)) or (t.Tipo=7 and t.TipoFase=1) or (t.Tipo=24 and t.TipoFase in (2,8)) ) ");
            consulta.append("   group by td.ProductoClave, td.TipoUnidad ");
            consulta.append(") as t ");
            consulta.append("group by t.ProductoClave, t.TipoUnidad ");

            BDVend.getBD().ejecutarComando(consulta.toString());
        }

        public static ISetDatos obtenerInventarioGeneral() throws Exception {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select ku.ProductoClave, p.Nombre, ku.PRUTipoUnidad, (ku.EntradaDisponible-ku.Salida) as Existencia, (ku.EntradaDisponible-ku.Salida-ku.EntradaNoDisponible) as Disponible, ku.EntradaNoDisponible as NoDisponible ");
            consulta.append("from KardexUnidad ku ");
            consulta.append("inner join Producto p on ku.ProductoClave=p.ProductoClave ");
            consulta.append("inner join ProductoDetalle pd on ku.ProductoClave=pd.ProductoClave and ku.PRUTipoUnidad=pd.PRUTipoUnidad and pd.ProductoClave=pd.ProductoDetClave ");
            consulta.append("where (ku.EntradaDisponible-ku.Salida)>0 ");
            consulta.append("order by ku.ProductoClave, pd.Factor desc ");

            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerInventarioGeneralTotales() throws Exception {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select ku.PRUTipoUnidad, sum(ku.EntradaDisponible-ku.Salida) as Existencia, sum(ku.EntradaDisponible-ku.Salida-ku.EntradaNoDisponible) as Disponible, sum(ku.EntradaNoDisponible) as NoDisponible ");
            consulta.append("from KardexUnidad ku ");
            consulta.append("inner join ProductoDetalle pd on ku.ProductoClave=pd.ProductoClave and ku.PRUTipoUnidad=pd.PRUTipoUnidad and pd.ProductoClave=pd.ProductoDetClave ");
            consulta.append("where (ku.EntradaDisponible-ku.Salida)>0 ");
            consulta.append("group by ku.PRUTipoUnidad ");
            consulta.append("order by pd.Factor desc ");

            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerInventarioEnvase() throws Exception {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select i.ProductoClave, p.Nombre, pd.PRUTipoUnidad, (i.Disponible) as Existencia, (i.Disponible-(i.NoDisponible+i.Apartado)) as Disponible, (i.NoDisponible+i.Apartado) as NoDisponible ");
            consulta.append("from Inventario i ");
            consulta.append("inner join Producto p on i.ProductoClave=p.ProductoClave and p.Contenido=1 ");
            consulta.append("inner join ProductoDetalle pd on i.ProductoClave=pd.ProductoClave and i.ProductoClave=pd.ProductoDetClave ");

            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerInventarioEnvaseTotales() throws Exception {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select pd.PRUTipoUnidad, sum(i.Disponible) as Existencia, sum(i.Disponible-(i.NoDisponible+i.Apartado)) as Disponible, sum(i.NoDisponible+i.Apartado) as NoDisponible ");
            consulta.append("from Inventario i ");
            consulta.append("inner join Producto p on i.ProductoClave=p.ProductoClave and p.Contenido=1 ");
            consulta.append("inner join ProductoDetalle pd on i.ProductoClave=pd.ProductoClave and i.ProductoClave=pd.ProductoDetClave ");
            consulta.append("group by pd.PRUTipoUnidad ");

            return BDVend.consultar(consulta.toString());
        }

        public static ISetDatos obtenerInventarioDetalle()throws Exception {
            StringBuilder consulta = new StringBuilder();
            consulta.append("select ku.ProductoClave, p.Nombre, ku.PRUTipoUnidad, (ku.EntradaDisponible-ku.Salida) as Existencia, (ku.EntradaDisponible-ku.Salida-ku.EntradaNoDisponible) as Disponible, ku.EntradaNoDisponible as NoDisponible, ");
            consulta.append("(i.Disponible) as ExistenciaMin, (i.Disponible-(i.NoDisponible+i.Apartado)) as DisponibleMin, (i.NoDisponible+i.Apartado) as NoDisponibleMin ");
            consulta.append("from KardexUnidad ku ");
            consulta.append("inner join Producto p on ku.ProductoClave=p.ProductoClave ");
            consulta.append("inner join ProductoDetalle pd on ku.ProductoClave=pd.ProductoClave and ku.PRUTipoUnidad=pd.PRUTipoUnidad and pd.ProductoClave=pd.ProductoDetClave ");
            consulta.append("inner join Inventario i on ku.ProductoClave=i.ProductoClave ");
            consulta.append("where (ku.EntradaDisponible-ku.Salida)>0 ");
            consulta.append("order by ku.ProductoClave, pd.Factor desc ");

            return BDVend.consultar(consulta.toString());
        }

		public static float obtenerDisponibleProductoUnidad(String productoClave, int tipoUnidad) throws Exception {
			StringBuilder consulta = new StringBuilder();
			consulta.append("select (ku.EntradaDisponible-ku.Salida-ku.EntradaNoDisponible) as Disponible ");
			consulta.append("from KardexUnidad ku ");
			consulta.append("where ku.ProductoClave='" + productoClave + "' and ku.PRUTipoUnidad='" + tipoUnidad + "' ");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			float disponible = 0;
			if(datos != null){
				if(datos.moveToNext()){
					disponible = datos.getFloat("Disponible");
				}
			}

			return disponible;
		}

		public static float obtenerExistenciaDifNoDisponibleKU(String productoClave) throws Exception
		{

			StringBuilder consulta = new StringBuilder();

			float existencia = 0;
			consulta.append("select sum(case when KDU.EntradaDisponible is null then 0 else (KDU.EntradaDisponible-KDU.Salida-KDU.EntradaNoDisponible) * PDE.Factor end) as Existencia ");
			consulta.append("from KardexUnidad KDU ");
			consulta.append("inner join Producto PRO on PRO.ProductoClave = KDU.ProductoClave ");
			consulta.append("inner join ProductoUnidad PRU on PRU.ProductoClave = KDU.ProductoClave and PRU.PRUTipoUnidad = KDU.PRUTipoUnidad ");
			consulta.append("inner join ProductoDetalle PDE on PRO.ProductoClave = PDE.ProductoClave and PRU.PRUTipoUnidad = PDE.PRUTipoUnidad and PRO.ProductoClave = PDE.ProductoDetClave ");
			consulta.append("where KDU.ProductoClave = '" + productoClave + "' and PRU.TipoEstado = 1 ");

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

	public static final class EntragasASurtirDisposur {

		public static ISetDatos ObtenerEntregasGeneral(String clienteClave) throws Exception {
			StringBuilder consulta = new StringBuilder();
			consulta = new StringBuilder();
			consulta.append("select distinct TP.Folio, C.ClienteClave, C.NombreContacto, C.RazonSocial ");
			consulta.append("from TransProd TP ");
			consulta.append("inner join Visita V on TP.VisitaClave = V.VisitaClave ");
			consulta.append("inner join Cliente C on V.ClienteClave = C.ClienteClave ");
			consulta.append("left join Agenda A on C.ClienteClave = A.ClienteClave ");
			consulta.append("where TP.Tipo = 1 and TP.TipoFase = 1 ");
			if (!clienteClave.equals("")) {
				consulta.append(" and V.ClienteClave in (" + clienteClave + ") ");
			}
			consulta.append("order by A.Orden, TP.Folio ");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			return datos;
		}

		public static ISetDatos ObtenerEntregasDetallado(String clienteClave, String Ordenamiento) throws Exception {
			StringBuilder consulta = new StringBuilder();
			consulta = new StringBuilder();
			consulta.append("select distinct TP.Folio, C.ClienteClave, C.RazonSocial, TPD.ProductoClave, P.Nombre, ");
			consulta.append("TPD.TipoUnidad, IFNULL(TPD.Cantidad, 0) as Cantidad,  ");
			consulta.append("IFNULL(TPD.Precio + round((TPD.Impuesto/TPD.Cantidad),3),0) as Precio, IFNULL(TPD.Total,0) as Total ");
			consulta.append("from TransProd TP  ");
			consulta.append("inner join TransProdDetalle TPD on TP.TransProdID = TPD.TransProdID ");
			consulta.append("inner join Producto P on TPD.ProductoClave = P.ProductoClave ");
			consulta.append("inner join Visita V on TP.VisitaClave = V.VisitaClave ");
			consulta.append("inner join Cliente C on V.ClienteClave = C.ClienteClave ");
			consulta.append("where TP.Tipo = 1 and TP.TipoFase = 1 ");
			if (!clienteClave.equals("")) {
				consulta.append(" and V.ClienteClave in (" + clienteClave + ") ");
			}
//			consulta.append("order by TP.Folio, C.ClienteClave, TPD.Partida ");
			if (Ordenamiento == "1"){
				consulta.append("order by TP.Folio, C.ClienteClave, TPD.Partida ");
			}
			if (Ordenamiento == "2"){
				consulta.append("order by TPD.ProductoClave, TPD.TipoUnidad ");
			}
			if (Ordenamiento == "3"){
				consulta.append("order by TPD.TipoUnidad ");
			}
			ISetDatos datos = BDVend.consultar(consulta.toString());
			return datos;
		}

//		public static ISetDatos ObtenerResumenProductos(String clienteClave) throws Exception {
//			StringBuilder consulta = new StringBuilder();
//			consulta = new StringBuilder();
//			consulta.append("select distinct TPD.ProductoClave, P.Nombre, ");
//			consulta.append("TPD.TipoUnidad, sum(IFNULL(TPD.Cantidad, 0)) as Cantidad, sum(IFNULL(TPD.Total,0)) as Total ");
//			consulta.append("from TransProd TP  ");
//			consulta.append("inner join TransProdDetalle TPD on TP.TransProdID = TPD.TransProdID ");
//			consulta.append("inner join Producto P on TPD.ProductoClave = P.ProductoClave ");
//			consulta.append("inner join Visita V on TP.VisitaClave = V.VisitaClave ");
//			consulta.append("inner join Cliente C on V.ClienteClave = C.ClienteClave ");
//			consulta.append("where TP.Tipo = 1 and TP.TipoFase = 1 ");
//			if (!clienteClave.equals("")) {
//				consulta.append(" and V.ClienteClave = '" + clienteClave + "' ");
//			}
//			consulta.append("group by TPD.ProductoClave, P.Nombre, TPD.TipoUnidad ");
//			consulta.append("order by TPD.ProductoClave ");
//			ISetDatos datos = BDVend.consultar(consulta.toString());
//			return datos;
//		}
//
//		public static ISetDatos ObtenerResumenTipoUnidad(String clienteClave) throws Exception {
//			StringBuilder consulta = new StringBuilder();
//			consulta = new StringBuilder();
//			consulta.append("select distinct TPD.TipoUnidad, sum(IFNULL(TPD.Cantidad, 0)) as Cantidad, round(sum(IFNULL(TPD.Total,0)),3) as Total ");
//			consulta.append("from TransProd TP  ");
//			consulta.append("inner join TransProdDetalle TPD on TP.TransProdID = TPD.TransProdID ");
//			consulta.append("inner join Producto P on TPD.ProductoClave = P.ProductoClave ");
//			consulta.append("inner join Visita V on TP.VisitaClave = V.VisitaClave ");
//			consulta.append("inner join Cliente C on V.ClienteClave = C.ClienteClave ");
//			consulta.append("where TP.Tipo = 1 and TP.TipoFase = 1 ");
//			if (!clienteClave.equals("")) {
//				consulta.append(" and V.ClienteClave = '" + clienteClave + "' ");
//			}
//			consulta.append("group by TPD.TipoUnidad ");
//			consulta.append("order by TPD.TipoUnidad ");
//			ISetDatos datos = BDVend.consultar(consulta.toString());
//			return datos;
//		}
	}

	public static class ConsultarConvenios {
		public static ISetDatos obtenerConvenios() throws Exception {
			return BDVend.consultar("Select ConvenioID as _id, ConvenioID, TipoBanco, Cuenta, TipoReferencia from ConvenioAlmacen order by Orden ");
		}
	}

    public static final class ConsultasSaldoDeposito{
        public static List<SaldoDeposito> obtenerSaldosPorAplicar() throws Exception{
            List<SaldoDeposito> list = new ArrayList<SaldoDeposito>();
            SaldoDeposito saldo = null;
            String consulta = "select * from SaldoDeposito where Aplicado = 0";
            ISetDatos datos = BDVend.consultar(consulta);
            if (datos != null) {
                while (datos.moveToNext()) {
                    saldo = new SaldoDeposito();
                    saldo.SaldoDepositoID = datos.getString("SaldoDepositoID");
                    saldo.DiaClave = datos.getString("DiaClave");
                    saldo.Saldo = datos.getFloat("Saldo");
                    list.add(saldo);
                }
            }
            datos.close();

            return list;
        }

        public static List<SaldoDeposito> obtenerSaldosAplicados(String DEPId) throws Exception{
            List<SaldoDeposito> list = new ArrayList<SaldoDeposito>();
            SaldoDeposito saldo = null;
            String consulta = "select * from SaldoDeposito where DepositoAplicadoID = '" + DEPId + "'";
            ISetDatos datos = BDVend.consultar(consulta);
            if (datos != null) {
                while (datos.moveToNext()) {
                    saldo = new SaldoDeposito();
                    saldo.SaldoDepositoID = datos.getString("SaldoDepositoID");
                    saldo.DiaClave = datos.getString("DiaClave");
                    saldo.Saldo = datos.getFloat("Saldo");
                    list.add(saldo);
                }
            }
            datos.close();

            return list;
        }

        public static SaldoDeposito obtenerDepositoAdicional(String DEPId) throws Exception{
            SaldoDeposito adicional = null;
            String consulta = "select SaldoDepositoID from SaldoDeposito where DepositoCapturaID = '" + DEPId + "'";
            ISetDatos datos = BDVend.consultar(consulta);
            if (datos.getCount() > 0) {
                datos.moveToFirst();
                adicional = new SaldoDeposito();
                adicional.SaldoDepositoID = datos.getString("SaldoDepositoID");
                BDVend.recuperar(adicional);
            }
            datos.close();

            return adicional;
        }

        public static float obtenerAbonosNoVinculados() throws Exception{
            StringBuilder consulta = new StringBuilder();
            consulta.append("select sum(Importe) as Importe ");
            consulta.append("from AbnDetalle ");
            consulta.append("where ABNId || ABDId not in (select ABNId || ABDId from AbdDep) ");

            float res = 0;
            ISetDatos datos = BDVend.consultar(consulta.toString());
            if (datos.moveToNext())
            {
                res = datos.getFloat(0);
            }
            datos.close();
            return res;
        }
    }

	public static final class ConsultasConteoInventario{
		public static ISetDatos obtenerConteoInventario()throws Exception {
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select ContId, FechaHoraAlta, TipoFase, Enviado from ConteoInventario where FechaHoraAlta= '" + Generales.getFechaHoraActualStr("yyyy-MM-dd HH:mm:ss") + "' "  );

			return BDVend.consultar(consulta.toString());
		}
	}

	public static final class ConsultasTiempoMuerto{
		public static String obtenerTiempoMuerto(String DiaClave, String rutaClave)throws Exception{
			String TIMId = "";
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TIMId FROM TiempoMuerto WHERE MFechaHora = FechaHoraInicial ");
			consulta.append("AND DiaClave = '" +DiaClave+ "' AND RUTClave = '" +rutaClave+ "'");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if(datos.getCount() > 0){
				datos.moveToFirst();
				TIMId = datos.getString("TIMId");
			}
			return TIMId;
		}
	}

	public static final class ConsultasReporteIndicadoresPreventaCPC {

		public static String vendedorId =  ((Vendedor)Sesion.get(Campo.VendedorActual)).VendedorId ;

		public static String diaClavesEnFrecuencia() throws Exception{
			ISetDatos dias = BDVend.consultar("select DiaClave from Dia where FueraFrecuencia=0");
			String DiasClaves="";
			while (dias.moveToNext()){
				DiasClaves += "'" + dias.getString("DiaClave") + "', ";
			}
			dias.close();
			return DiasClaves.substring(0,(DiasClaves.length()-2));
		}

		public static ISetDatos obtenerPreventaHLtsFamilia() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select e.EsquemaId, e.Nombre as Familia, sum(td.Cantidad * pu.KgLts) as Hlts, sum(td.cantidad * pd.Factor) as Cajas ");
			consulta.append("from Transprod t ");
			consulta.append("inner join TransprodDetalle td on t.TransprodId=td.TransprodId ");
			consulta.append("inner join ProductoUnidad pu on td.ProductoClave=pu.ProductoClave and td.TipoUnidad=pu.PRUTipoUnidad ");
			consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.ProductoClave=pd.ProductoDetClave ");
			consulta.append("inner join ProductoEsquema pe on td.ProductoClave=pe.ProductoClave ");
			consulta.append("inner join Esquema e on pe.EsquemaId=e.EsquemaId and e.EsquemaIdPadre is null and e.Orden in (8) ");
			consulta.append("inner join Dia d on t.DiaClave=d.DiaClave ");
			consulta.append("inner join Visita v on t.VisitaClave=v.VisitaClave ");
			consulta.append("where(t.Tipo = 1 And t.TipoFase = 1) ");
			consulta.append("and t.DiaClave in (" + diaClavesEnFrecuencia() + ") ");
			consulta.append("and v.VendedorId='" + vendedorId + "' ");
			consulta.append("and d.FueraFrecuencia=0 ");
			consulta.append("group by e.EsquemaId, e.Nombre ");

			return BDVend.consultar(consulta.toString());
		}

		public static String obtenerEsquemaPCerveza() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select EsquemaId ");
			consulta.append("from Esquema ");
			consulta.append("where Tipo=2 and Nombre='Cerveza' ");
			ISetDatos Esquema = BDVend.consultar(consulta.toString());
			String EsquemasID="";
			while (Esquema.moveToNext()){
				EsquemasID += "'" + Esquema.getString("EsquemaId") + "', ";
			}
			Esquema.close();
			return EsquemasID.substring(0,(EsquemasID.length()-2));
		}

		public static Integer obtenerTotalClientes() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select count(*) as Total from ( ");
			consulta.append("select t.ClienteClave as TotalClientes ");
			consulta.append("from Transprod t ");
			consulta.append("inner join TransprodDetalle td on t.TransprodId=td.TransprodId ");
			consulta.append("inner join ProductoUnidad pu on td.ProductoClave=pu.ProductoClave and td.TipoUnidad=pu.PRUTipoUnidad ");
			consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.ProductoClave=pd.ProductoDetClave ");
			consulta.append("inner join ProductoEsquema pe on td.ProductoClave=pe.ProductoClave ");
			consulta.append("inner join Esquema e on pe.EsquemaId=e.EsquemaId and e.Orden in (1) and e.EsquemaIdPadre in (" + obtenerEsquemaPCerveza() + ") ");
			consulta.append("inner join Dia d on t.DiaClave=d.DiaClave ");
			consulta.append("inner join Visita v on t.VisitaClave=v.VisitaClave ");
			consulta.append("where(t.Tipo = 1 And t.TipoFase = 1) ");
			consulta.append("and t.DiaClave in (" + diaClavesEnFrecuencia() + ") ");
			consulta.append("and v.VendedorId='" + vendedorId + "' ");
			consulta.append("and d.FueraFrecuencia=0 ");
			consulta.append("group by t.ClienteClave ");
			consulta.append(") as t ");

			ISetDatos Clientes = BDVend.consultar(consulta.toString());
			int Total=0;
			while (Clientes.moveToNext()){
				Total += Integer.parseInt(Clientes.getString("Total"));
			}
			Clientes.close();
			return Total;
		}

		public static ISetDatos obtenerTotalClientesFamilia() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select tt.EsquemaID, tt.Nombre, count(tt.ClienteClave) as TotalClientesFamilia ");
			consulta.append("from ( ");
			consulta.append("select distinct e.EsquemaID, e.Nombre, t.ClienteClave ");
			consulta.append("from Transprod t ");
			consulta.append("inner join TransprodDetalle td on t.TransprodId=td.TransprodId ");
			consulta.append("inner join ProductoUnidad pu on td.ProductoClave=pu.ProductoClave and td.TipoUnidad=pu.PRUTipoUnidad ");
			consulta.append("inner join ProductoDetalle pd on td.ProductoClave=pd.ProductoClave and td.ProductoClave=pd.ProductoDetClave ");
			consulta.append("inner join ProductoEsquema pe on td.ProductoClave=pe.ProductoClave ");
			consulta.append("inner join Esquema e on pe.EsquemaId=e.EsquemaId and e.EsquemaIdPadre is null and e.Orden in (9) ");
			consulta.append("inner join Dia d on t.DiaClave=d.DiaClave ");
			consulta.append("inner join Visita v on t.VisitaClave=v.VisitaClave ");
			consulta.append("where(t.Tipo = 1 And t.TipoFase = 1) ");
			consulta.append("and t.DiaClave in (" + diaClavesEnFrecuencia() + ") ");
			consulta.append("and v.VendedorId='" + vendedorId + "' ");
			consulta.append("and d.FueraFrecuencia=0 ");
			consulta.append(")tt ");
			consulta.append("group by tt.EsquemaID, tt.Nombre ");

			return BDVend.consultar(consulta.toString());
		}

		public static Integer obtenerTotalClientesAgenda() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select count(*) as TotalClientesAgenda ");
			consulta.append("from Dia d ");
			consulta.append("inner join Agenda a on d.DiaClave=a.DiaClave ");;
			consulta.append("and d.DiaClave in (" + diaClavesEnFrecuencia() + ") ");
			consulta.append("and a.VendedorId='" + vendedorId + "' ");
			consulta.append("and d.FueraFrecuencia=0 ");

			ISetDatos Clientes = BDVend.consultar(consulta.toString());
			int Total=0;
			while (Clientes.moveToNext()){
				Total += Integer.parseInt(Clientes.getString("TotalClientesAgenda"));
			}
			Clientes.close();
			return Total;
		}

		public static Integer obtenerTotalClientesPedido() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select count(*) as TotalClientesPedido from ( ");
			consulta.append("select t.ClienteClave ");
			consulta.append("from Transprod t ");
			consulta.append("inner join Visita v on t.VisitaClave=v.VisitaClave ");
			consulta.append("where(t.Tipo = 1 And t.TipoFase = 1) ");
			consulta.append("and t.DiaClave in (" + diaClavesEnFrecuencia() + ") ");
			consulta.append("and v.VendedorId='" + vendedorId + "' ");
			consulta.append("group by t.ClienteClave ");
			consulta.append(") as t ");

			ISetDatos Clientes = BDVend.consultar(consulta.toString());
			int Total=0;
			while (Clientes.moveToNext()){
				Total += Integer.parseInt(Clientes.getString("TotalClientesPedido"));
			}
			Clientes.close();
			return Total;
		}

	}

	public static final class ConsultasVentasYupik{
		public static ISetDatos obtenerDetalle(String transProd) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT PRO.ProductoClave, PRO.Nombre, TPD.Cantidad, TPD.Precio, TPD.Precio * TPD.Cantidad AS SubTotal, IFNULL(TPD.Promocion, 0) AS Promocion, PRP.PromocionImp ");
			consulta.append("FROM TransProdDetalle TPD ");
			consulta.append("INNER JOIN Producto PRO ON TPD.ProductoClave = PRO.ProductoClave AND TPD.TransProdID ='" +transProd+ "' AND TPD.Cantidad > 0 " );
			consulta.append("LEFT JOIN TRPPRP PRP ON PRP.TransProdID = TPD.TransProdID AND PRP.TransProdDetalleID = TPD.TransProdDetalleID ");
			consulta.append("ORDER BY TPD.ProductoClave, TPD.TipoUnidad");

			return BDVend.consultar(consulta.toString());
		}
	}

	public static final class ConsultasPedidoFloricultura{
		public static ISetDatos obtenerDetallePedido(String transProd) throws Exception{

			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT PRO.ProductoClave, PRO.Nombre, TPD.Cantidad, TPD.Precio, TPD.Precio * TPD.Cantidad AS SubTotal, IFNULL(TPD.Promocion, 0) AS Promocion ");
			consulta.append("FROM TransProdDetalle TPD ");
			consulta.append("INNER JOIN Producto PRO ON TPD.ProductoClave = PRO.ProductoClave AND TransProdID ='" +transProd+ "' AND TPD.Cantidad > 0 " );
			consulta.append("ORDER BY TPD.ProductoClave, TPD.TipoUnidad");

			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerEquivalencia(String transProd) throws Exception{
			StringBuilder consulta = new StringBuilder();
			CONHist oConHist = (CONHist)Sesion.get(Campo.CONHist);
			consulta.append("SELECT MON.Simbolo, MON.TipoCodigo, MON.Valor, sum(ABD.Importe) AS Importe ");
			consulta.append("FROM ABNDetalle ABD ");
			consulta.append("INNER JOIN AbnTrp ABT ON ABD.ABNId = ABT.ABNId AND ABT.TransProdId = '" +transProd+ "' ");
			consulta.append("AND ABD.TipoPago = 1 AND NOT ABD.MonedaId IS NULL ");
			consulta.append("AND ABD.MonedaID <> '" +oConHist.get("MonedaID")+ "' ");
			consulta.append("INNER JOIN Moneda MON ON ABD.MonedaId = MON.MonedaId ");
			consulta.append("GROUP BY ABD.MonedaId, MON.Simbolo, MON.TipoCodigo, MON.Valor");

			return BDVend.consultar(consulta.toString());
		}
	}

	public static class ConsultasVentasNUTCol{
		public static ISetDatos obtenerDetallesVenta(String transProd) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TPD.ProductoClave, Pro.Nombre, TPD.Cantidad, TPD.Precio, TPD.Total ");
			consulta.append("FROM TransProdDetalle TPD ");
			consulta.append("INNER JOIN Producto Pro ON Pro.ProductoClave = TPD.ProductoClave AND TPD.TransProdID = '"+transProd+"' ");
			consulta.append("ORDER BY TPD.ProductoClave");
			return BDVend.consultar(consulta.toString());
		}

		public static CapturaTotales.vistaDesgloseImp[] obtenerDesgloseImpuestos(float descuentoVendedor, String transProd) throws Exception
		{
			transProd = "'"+transProd+"'";
			ISetDatos impuestos = Consultas.ConsultasTPDImpuesto.obtenerDesgloseImpuestos(transProd);
			if (impuestos.getCount() <= 0)
			{
				impuestos.close();
				return null;
			}

			ISetDatos descCliente = Consultas.ConsultasDescuentos.obtenerDescuentosAplicados(transProd);
			float descVendPor = descuentoVendedor;
			float subTotConDesc = Consultas.ConsultasTransProdDetalle.obtenerSubtotalConDescto(transProd);
			subTotConDesc -= subTotConDesc * descVendPor / 100;
			ISetDatos detalles = Consultas.ConsultasTransProdDetalle.obtenerTodos(transProd);

			CapturaTotales.vistaDesgloseImp[] desgloseImpuestos = new CapturaTotales.vistaDesgloseImp[impuestos.getCount()];

			while (detalles.moveToNext())
			{
				impuestos.moveToFirst();
				do
				{
					float totImp = Consultas.ConsultasTPDImpuesto.obtenerImpuestoImp(detalles.getString("TransProdID"), detalles.getString("TransProdDetalleID"), impuestos.getString("ImpuestoClave"));
					float impActual = totImp;
					//if (totImp >= 0) Se quito la validación para el folio 5097 ya que se ocupaba mostrar los impuestos negativos
					//{
					if (impuestos.getInt("TipoValor") == 1)
					{
						if (descCliente.getCount() > 0)
						{
							descCliente.moveToFirst();
							do
							{
								if (descCliente.getBoolean("TipoCascada"))
								{
									impActual -= impActual * descCliente.getFloat("DesPor") / 100;
								}
								else
								{
									impActual -= totImp * descCliente.getFloat("DesPor") / 100;
								}
							}
							while (descCliente.moveToNext());
						}
						impActual -= impActual * descVendPor / 100;
					}

					// agregar al array
					if (desgloseImpuestos[impuestos.getPosition()] == null)
					{
						desgloseImpuestos[impuestos.getPosition()] = new CapturaTotales.vistaDesgloseImp(impuestos.getString("Abreviatura"), impuestos.getFloat("ImpuestoPor"), impActual, impuestos.getInt("TipoValor"));
					}
					else
					{
						desgloseImpuestos[impuestos.getPosition()].setImporte(desgloseImpuestos[impuestos.getPosition()].getImporte() + impActual);
					}
					//}
				}
				while (impuestos.moveToNext());
			}

			impuestos.close();
			detalles.close();
			descCliente.close();

			if(desgloseImpuestos.length == 1)
				if(desgloseImpuestos[0] == null)
					return null;

			return desgloseImpuestos;

		}
	}
	public static final class ReporteVisitasAEjecutarDIS {

		public static ISetDatos ObtenerClientesAgenda(String diaClave) throws Exception {
			StringBuilder consulta = new StringBuilder();
			consulta = new StringBuilder();
			consulta.append("Select distinct CLI.Clave, CLI.NombreContacto, CLI.RazonSocial, CLD.Poblacion ");
			consulta.append("from Agenda AGE ");
			consulta.append("inner join Cliente CLI on AGE.ClienteClave = CLI.ClienteClave ");
			consulta.append("inner join ClienteDomicilio CLD on CLI.ClienteClave = CLD.ClienteClave and CLD.Tipo = 2 ");
			consulta.append("where AGE.DiaClave = '" + diaClave + "'");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			return datos;
		}
	}
}
