package com.amesol.routelite.datos.basedatos;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;

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
import com.amesol.routelite.actividades.Productos;
import com.amesol.routelite.actividades.PromocionDetalle;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.Agenda;
import com.amesol.routelite.datos.AseguramientoVisita;
import com.amesol.routelite.datos.CamionVendedor;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ConfiguracionRecibo;
import com.amesol.routelite.datos.Deposito;
import com.amesol.routelite.datos.Descuento;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Esquema;
import com.amesol.routelite.datos.FolioReservacion;
import com.amesol.routelite.datos.FrecuenciaExcep;
import com.amesol.routelite.datos.Inventario;
import com.amesol.routelite.datos.PLBPLE;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.Promocion;
import com.amesol.routelite.datos.Recibo;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.VendedorJornada;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.ConsultaInventario.ListaInventario;
import com.amesol.routelite.vistas.RevisionPendientes.pendientes;
import com.amesol.routelite.vistas.utilerias.ServicesCentral;

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
				consulta.append("select -1 as _id, -1 as " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", '" + MensajeSeleccion + "' as " + SearchManager.SUGGEST_COLUMN_TEXT_1 + " ");
				consulta.append("UNION ");
			}
			consulta.append("select VAD.VAVClave as _id, VAD.VAVClave AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", VAD.Descripcion AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + " from ValorReferencia VR ");
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
				BDVend.ejecutarComando("update ruta set FolioClienteNvo = " + folioClt + " where RUTClave  = '" + RUTClave + "'");
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
			sConsulta.append("WHERE Visitado=1 AND DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
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
			sConsulta.append("WHERE DiaClave='" + diaActual.DiaClave + "' AND Agenda.RUTClave='" + rutaActual.RUTClave + "' ");
			sConsulta.append("GROUP BY Agenda.ClienteClave, Cliente.Clave, Cliente.RazonSocial, Cliente.NombreContacto, ClienteDomicilio.Calle, ClienteDomicilio.Numero) as t ");
			if (filtro != null)
				sConsulta.append("WHERE Clave || ' - ' || RazonSocial LIKE '%" + filtro + "%' OR NombreContacto LIKE '%" + filtro + "%' OR Calle || ' ' || Numero LIKE '%" + filtro + "%' ");
			sConsulta.append("ORDER BY Orden ");
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

		public static ISetDatos obtenerAgendado(Cliente clienteActual, Ruta rutaActual) throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("Select CLI.ClienteClave,AGN.DiaClave from Cliente CLI ");
			sConsulta.append("inner join Agenda AGN on CLI.ClienteClave = AGN.ClienteClave ");
			sConsulta.append("where IDElectronico ='" + clienteActual.IdElectronico + "' and AGN.RUTClave='" + rutaActual.RUTClave + "'");
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

			sConsulta.append("select ClienteDomicilioId as _id, ClienteDomicilioId, Calle || ' ' || Numero as Domicilio ");
			sConsulta.append("from ClienteDomicilio ");
			sConsulta.append("where ClienteClave = '" + clienteClave + "' and Tipo = " + sTipo);
			return BDVend.consultar(sConsulta.toString());
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

		public static Productos.vistaProductoUnidadFactor[] obtenerUnidadProducto(String productoClave) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT ProductoDetalle.PRUTipoUnidad, ProductoDetalle.Factor FROM ProductoDetalle ");
			consulta.append("INNER JOIN ProductoUnidad ON ProductoUnidad.ProductoClave = ProductoDetalle.ProductoClave AND ProductoUnidad.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad ");
			consulta.append("AND ProductoDetalle.ProductoDetClave = '" + productoClave + "' AND ProductoDetalle.Productoclave='" + productoClave + "' ");

			ISetDatos setDatos = BDVend.consultar(consulta.toString());

			ArrayList<Productos.vistaProductoUnidadFactor> unidades = new ArrayList<Productos.vistaProductoUnidadFactor>();
			while (setDatos.moveToNext())
			{
				Productos.vistaProductoUnidadFactor unidad = new Productos.vistaProductoUnidadFactor(setDatos.getInt(0), setDatos.getInt(1), ValoresReferencia.getDescripcion("UNIDADV", setDatos.getString(0)));
				unidades.add(unidad);
			}
			return unidades.toArray(new Productos.vistaProductoUnidadFactor[unidades.size()]);
		}

		public static ISetDatos obtenerUnidadesProducto(String productoClave, String precioClave) throws Exception
		{
			StringBuilder consulta = new StringBuilder();

			consulta.append("SELECT ProductoDetalle.PRUTipoUnidad as _id, ProductoDetalle.PRUTipoUnidad, ProductoDetalle.Factor FROM ProductoDetalle ");
			consulta.append("INNER JOIN ProductoUnidad ON ProductoUnidad.ProductoClave = ProductoDetalle.ProductoClave AND ProductoUnidad.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad ");
			consulta.append("AND ProductoDetalle.ProductoDetClave = '" + productoClave + "' AND ProductoDetalle.Productoclave='" + productoClave + "' ");
			if (precioClave != null)
			{
				consulta.append("LEFT JOIN PrecioProductoVig PPV on PPV.ProductoClave = ProductoDetalle.ProductoClave and PPV.ProductoClave = ProductoDetalle.ProductoDetClave and PPV.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad and PPV.PrecioClave='" + precioClave + "' and ");
				consulta.append("DATETIME('now') between PPV.PPVFechaInicio and PPV.FechaFin order by Case when PPV.PrecioClave is null Then 1 Else 0 End, ProductoDetalle.Factor ");
			}
			return BDVend.consultar(consulta.toString());
		}

		public static ISetDatos obtenerUnidadesProductoDifen(String productoClave, String precioClave, int tipoUnidad) throws Exception
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

		public static ISetDatos obtenerUnidadesRestantesProducto(String productoClave, String transProdsId) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT ProductoDetalle.PRUTipoUnidad as _id, ProductoDetalle.PRUTipoUnidad, ProductoDetalle.Factor FROM ProductoDetalle ");
			consulta.append("INNER JOIN ProductoUnidad ON ProductoUnidad.ProductoClave = ProductoDetalle.ProductoClave AND ProductoUnidad.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad ");
			consulta.append("AND ProductoDetalle.ProductoDetClave = '" + productoClave + "' AND ProductoDetalle.Productoclave='" + productoClave + "' ");
			consulta.append("AND ProductoDetalle.PRUTipoUnidad NOT IN (SELECT TipoUnidad FROM TransprodDetalle WHERE ProductoClave = '" + productoClave + "' AND TransProdId in (" + transProdsId + "))");
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

		/*
		 * public static ISetDatos buscarCodigoBarras(String codigoBarras)
		 * throws Exception{ ISetDatos setDatos =
		 * BDVend.consultar(ProductoUnidad.class, new String[]{},
		 * "(UPPER(CodigoBarras) = UPPER(?))", new Object[]{codigoBarras});
		 * if((setDatos != null) && (setDatos.moveToFirst()) &&
		 * (setDatos.getCount()>0)){ return setDatos; } return null; }
		 */
		public static ISetDatos buscarCodigoBarras(String codigoBarras, String precioClave) throws Exception
		{
			StringBuilder consulta = new StringBuilder();

			consulta.append("SELECT ProductoDetalle.PRUTipoUnidad as _id, ProductoDetalle.PRUTipoUnidad, ProductoDetalle.Factor, ProductoDetalle.ProductoClave FROM ProductoDetalle ");
			consulta.append("INNER JOIN ProductoUnidad ON ProductoUnidad.ProductoClave = ProductoDetalle.ProductoClave AND ProductoUnidad.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad and ProductoUnidad.ProductoClave = ProductoDetalle.ProductoDetClave ");
			consulta.append("AND ProductoUnidad.CodigoBarras = '" + codigoBarras + "' ");
			if (precioClave != null)
			{
				consulta.append("LEFT JOIN PrecioProductoVig PPV on PPV.ProductoClave = ProductoDetalle.ProductoClave and PPV.ProductoClave = ProductoDetalle.ProductoDetClave and PPV.PRUTipoUnidad = ProductoDetalle.PRUTipoUnidad and PPV.PrecioClave='" + precioClave + "' and ");
				consulta.append("DATETIME('now') between PPV.PPVFechaInicio and PPV.FechaFin order by Case when PPV.PrecioClave is null Then 1 Else 0 End, ProductoDetalle.Factor ");
			}
			return BDVend.consultar(consulta.toString());
		}

		/*
		 * public static Productos[] obtenerProductosExistencia(String filtro,
		 * String PrecioClave) throws Exception{
		 * ArrayList<Productos.vistaProductos> productos = new
		 * ArrayList<Productos.vistaProductos>(); StringBuilder consulta = new
		 * StringBuilder(); ISetDatos unidades =
		 * Consultas.ConsultasValorReferencia
		 * .obtenerValoresReferencia("UNIDADV"); consulta.append(
		 * "select PRO.ProductoClave,PRO.Nombre,PRO.NombreLargo,PRO.Id,case when INV.Disponible is null then 0 else (INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido) end as Existencia, "
		 * ); consulta.append(
		 * "PRU.PRUTipoUnidad as Unidad, PPV.Precio, 0 as checked from producto PRO inner join productounidad PRU on PRO.ProductoClave = PRU.ProductoClave "
		 * ); consulta.append(
		 * "inner join ProductoEsquema PES on PES.ProductoClave = PRO.ProductoClave left join PrecioProductoVig PPV on PPV.ProductoClave = PRO.ProductoClave and PPV.PRUTipoUnidad = PRU.PRUTipoUnidad left join Inventario INV on PRO.ProductoClave = INV.ProductoClave "
		 * ); //if(!PrecioClave.trim().equals(""))
		 * consulta.append("where PrecioClave = '" + PrecioClave + "' ");
		 * if(!filtro.trim().equals("")) consulta.append(filtro); ISetDatos
		 * datos = BDVend.consultar(consulta.toString());
		 * while(datos.moveToNext()){ //ProductoClave //Nombre //NombreLargo
		 * //Id //Existencia //Unidad //Unidad //Precio //Checked
		 * unidades.moveToPosition(datos.getInt(5)); Productos.vistaProductos
		 * producto = new Productos.vistaProductos(datos.getString(0),
		 * datos.getString(1), datos.getString(2), datos.getString(3),
		 * datos.getFloat(4), datos.getInt(5), unidades.getString(2),
		 * datos.getFloat(6), datos.getBoolean(7)); productos.add(producto); }
		 * return productos.toArray(new Productos[productos.size()]); }
		 */

		// public static ISetDatos obtenerProductosExistencia(String filtro,
		// String PrecioClave, boolean filtrarProductos) throws Exception{
		public static Cursor obtenerProductosExistencia(String filtro, String PrecioClave, boolean filtrarProductos, String transProdIds, int tipoTransProd, boolean validarExistencia) throws Exception
		{

			ArrayList<Cursor> cursores = new ArrayList<Cursor>();
			int limit = 0;
			int rows = 100000;

			boolean aplicarFiltrosPrecio = filtrarProductos;
			boolean aplicarFiltrosExistencia = filtrarProductos;
			while (limit + 6000 < rows)
			{
				StringBuilder consulta = new StringBuilder();

				if (tipoTransProd == TiposTransProd.CAMBIOS || tipoTransProd == TiposTransProd.DEVOLUCIONES_CLIENTE || tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES || tipoTransProd == TiposTransProd.MOV_SIN_INV_SV || tipoTransProd == TiposTransProd.DESCARGAS)
				{
					aplicarFiltrosPrecio = false;
					aplicarFiltrosExistencia = validarExistencia;
				}
				if (tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES)
					consulta.append("select distinct PRO.ProductoClave as _id, PRO.DecimalProducto, PRO.ProductoClave,PRO.Nombre,PRO.NombreLargo,case when PRO.Id is null then '' else PRO.Id end as Id,case when INV.Disponible is null then 0 else (INV.NoDisponible)/PDE.Factor end as Existencia, ");
				else
					consulta.append("select distinct PRO.ProductoClave as _id, PRO.DecimalProducto, PRO.ProductoClave,PRO.Nombre,PRO.NombreLargo,case when PRO.Id is null then '' else PRO.Id end as Id,case when INV.Disponible is null then 0 else (INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido)/PDE.Factor end as Existencia, ");
				consulta.append("PRU.PRUTipoUnidad as Unidad, ");
				if (!PrecioClave.equals(""))
				{
					//consulta.append("case when PPV.Precio is null then 0 else PPV.Precio end as Precio");
					consulta.append("PPV.Precio as Precio ");
				}
				else
				{
					consulta.append("null as Precio");
				}
				consulta.append(", 0 as checked, 0 as Cantidad from producto PRO inner join productounidad PRU on PRO.ProductoClave = PRU.ProductoClave ");
				consulta.append("inner join ProductoEsquema PES on PES.ProductoClave = PRO.ProductoClave inner join ProductoDetalle PDE on PRO.ProductoClave = PDE.ProductoClave and PRU.PRUTipoUnidad = PDE.PRUTipoUnidad and PRO.ProductoClave = PDE.ProductoDetClave and PDE.Factor= ");
				consulta.append("(Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave = '" + PrecioClave + "')");
				//consulta.append((aplicarFiltrosPrecio ? "(Select min(PDE2.factor) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave = '" + PrecioClave + "')" : "1 "));
				consulta.append("left join Inventario INV on PRO.ProductoClave = INV.ProductoClave AND INV.AlmacenID = '" + ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID + "'");
				if (!PrecioClave.equals(""))
				{
					consulta.append("left join PrecioProductoVig PPV on PPV.ProductoClave = PRO.ProductoClave and PPV.PRUTipoUnidad = PRU.PRUTipoUnidad ");
				}
				consulta.append("left join TransProdDetalle TPD on TPD.TransProdId in(" + transProdIds + ") and TPD.ProductoClave = PRO.ProductoClave ");

				if (!PrecioClave.equals(""))
				{
					if (!aplicarFiltrosPrecio)
					{
						consulta.append("where ((PPV.PrecioClave is null) OR (PPV.PrecioClave = '" + PrecioClave + "' AND '" + Generales.getFechaHoraActualStr("yyyy-MM-dd HH:mm:ss") + "' BETWEEN  PPV.PPVFechaInicio AND PPV.FechaFin)) ");
					}
					else
					{
						consulta.append("where PPV.PrecioClave = '" + PrecioClave + "' AND '" + Generales.getFechaHoraActualStr("yyyy-MM-dd HH:mm:ss") + "' BETWEEN  PPV.PPVFechaInicio AND PPV.FechaFin ");
					}
				}

				filtro += (filtro.length() > 0 ? "AND" : "") + " TPD.TransProdID is null ";

				consulta.append((PrecioClave.equals("") ? " WHERE " : " AND ") + filtro);

				if (aplicarFiltrosExistencia && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.PREVENTA)
					if (tipoTransProd == TiposTransProd.DEVOLUCIONES_MANUALES)
						consulta.append(" GROUP BY PRO.ProductoClave HAVING ((INV.NoDisponible)/PDE.Factor)>0 ");
					else
						consulta.append(" GROUP BY PRO.ProductoClave HAVING ((INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido)/PDE.Factor)>0 ");
				if (aplicarFiltrosPrecio && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
					consulta.append(" AND not PPV.Precio is null ");

				consulta.append(" LIMIT " + limit + ",6000");
				ISetDatos datos = BDVend.consultar(consulta.toString());

				// NO FUNCIONA, se congela en el getCount
				if (datos.getCount() > 0)
				{ // si obtiene registros agregarlo al array
					cursores.add((Cursor) datos.getOriginal());
					if (datos.getCount() < 6000) // si la cantidad de registros
													// es menor que el limit,
													// salir del ciclo
						break;
				}
				else
					// sino terminar el ciclo, ya no hay registros
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

			/*
			 * //ArrayList<Productos.vistaProductos> productos = new
			 * ArrayList<Productos.vistaProductos>(); StringBuilder consulta =
			 * new StringBuilder(); //ISetDatos unidades =
			 * Consultas.ConsultasValorReferencia
			 * .obtenerValoresReferencia("UNIDADV"); consulta.append(
			 * "select distinct PRO.ProductoClave as _id, PRO.DecimalProducto, PRO.ProductoClave,PRO.Nombre,PRO.NombreLargo,case when PRO.Id is null then '' else PRO.Id end as Id,case when INV.Disponible is null then 0 else (INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido)/PDE.Factor end as Existencia, "
			 * ); consulta.append("PRU.PRUTipoUnidad as Unidad, ");
			 * //if(filtrarProductos) consulta.append(
			 * "case when PPV.Precio is null then 0 else PPV.Precio end as Precio"
			 * ); //else // consulta.append(" 0 as Precio"); consulta.append(
			 * ", 0 as checked from producto PRO inner join productounidad PRU on PRO.ProductoClave = PRU.ProductoClave "
			 * ); consulta.append(
			 * "inner join ProductoEsquema PES on PES.ProductoClave = PRO.ProductoClave inner join ProductoDetalle PDE on PRO.ProductoClave = PDE.ProductoClave and PRU.PRUTipoUnidad = PDE.PRUTipoUnidad and PRO.ProductoClave = PDE.ProductoDetClave "
			 * ); consulta.append(
			 * "left join Inventario INV on PRO.ProductoClave = INV.ProductoClave AND INV.AlmacenID = '"
			 * + ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID + "'");
			 * //if(filtrarProductos){ consulta.append(
			 * "left join PrecioProductoVig PPV on PPV.ProductoClave = PRO.ProductoClave and PPV.PRUTipoUnidad = PRU.PRUTipoUnidad "
			 * ); if(!PrecioClave.equals("")){ //String parentesis = "";
			 * //if(!filtrarProductos) //parentesis = "(";
			 * //consulta.append("where " + parentesis + "(PPV.PrecioClave = '"
			 * + PrecioClave + "' AND '" +
			 * Generales.getFechaHoraActualStr("yyyy-MM-dd HH:mm:ss") +
			 * "' BETWEEN  PPV.PPVFechaInicio AND PPV.FechaFin) ");
			 * consulta.append("where PPV.PrecioClave = '" + PrecioClave +
			 * "' AND '" +
			 * Generales.getFechaHoraActualStr("yyyy-MM-dd HH:mm:ss") +
			 * "' BETWEEN  PPV.PPVFechaInicio AND PPV.FechaFin "); } //}
			 * //if(!filtrarProductos)
			 * //consulta.append(" OR (PPV.Precio = 0 or PPV.Precio IS NULL)) "
			 * ); if(!filtro.trim().equals(""))
			 * consulta.append(PrecioClave.equals("") ? " WHERE " : " AND " +
			 * filtro); //consulta.append(filtrarProductos ? " AND " : " WHERE "
			 * + filtro); if(filtrarProductos &&
			 * Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) !=
			 * Enumeradores.TiposModulos.PREVENTA) consulta.append(
			 * " GROUP BY PRO.ProductoClave HAVING ((INV.Disponible-INV.Apartado-INV.NoDisponible-INV.Contenido)/PDE.Factor)>0 AND PPV.Precio > 0"
			 * ); if(filtrarProductos &&
			 * Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) ==
			 * Enumeradores.TiposModulos.PREVENTA)
			 * consulta.append(" AND PPV.Precio > 0"); ISetDatos datos =
			 * BDVend.consultar(consulta.toString()); return (Cursor)
			 * datos.getOriginal();
			 */
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

		public static ISetDatos obtenerProductoDetalle(String productoClave, Integer tipoUnidad) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT ProductoDetalle.ProductoClave, ProductoDetalle.ProductoDetClave, ProductoDetalle.Factor FROM ProductoDetalle ");
			consulta.append("WHERE ProductoDetalle.ProductoClave='" + productoClave + "' and ProductoDetalle.PRUTipoUnidad=" + tipoUnidad);
			return BDVend.consultar(consulta.toString());
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
		public static Float obtenerPrecioMinimo(String PrecioClave,String ProductoClave, int PRUTipoUnidad) throws Exception{
			String precioMin;
			precioMin = BDVend.getBD().ejecutarEscalar("SELECT PrecioMinimo FROM PrecioProductoVig PPV WHERE PPV.PrecioClave = '"+PrecioClave+"' AND PPV.ProductoClave = '"+ProductoClave+"' AND PPV.PRUTipoUnidad = "+PRUTipoUnidad+" AND datetime('now') BETWEEN PPV.PPVFechaInicio AND PPV.FechaFin");
			return Float.parseFloat(precioMin);
		}

		public static float obtenerPrecioProducto(String ProductoClave, short TipoUnidad, String PrecioClave)
		{
			try
			{

				Date fechaActual = Generales.getFechaActual();

				String Consulta = "SELECT Precio FROM PrecioProductoVig INNER JOIN Precio ON PrecioProductoVig.PrecioClave = Precio.PrecioClave";
				Consulta += " WHERE PrecioProductoVig.PrecioClave = '" + PrecioClave + "' AND '" + Generales.getUltimaHora(fechaActual) + "'>=PPVFechaInicio AND '" + Generales.getPrimerHora(fechaActual) + "'<=FechaFin  AND Precio.TipoEstado= 1 AND PrecioProductoVig.ProductoClave = '" + ProductoClave + "' and PrecioProductoVig.PRUTipoUnidad = " + Short.toString(TipoUnidad);
				Consulta += " ORDER BY PrecioProductoVig.ProductoClave ";

				String valorRes = "";
				valorRes = BDVend.getBD().ejecutarEscalar(Consulta);

				if (valorRes.equals(""))
				{
					// return (Float) null;
					return -1;
				}
				else
				{
					return Float.parseFloat(valorRes);
				}

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
			else if (nombreTabla.equalsIgnoreCase("Cliente"))
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

			valorRes = BDTerm.getBD().ejecutarEscalar("select  IFNULL(max(ordenx),0) from RECContenido where RECId='" + RECId + "'");

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

		public static ISetDatos obtenerDetalleRecibo(String id, short tipo, short tipoRecibo, String tabla, String campos, String campoLlave, String tablaOrden, String campoOrden, boolean agruparPorSubEmpresa)
		{
			try
			{
				StringBuilder consulta = new StringBuilder();
				if (tipo == 8)
				{
					// TODO Paula, implementar recibo Factura
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

		public static boolean existenVisitas(Dia dia, Cliente cliente) throws Exception
		{
			boolean resultado = false;
			ISetDatos datos = BDVend.consultar("select VisitaClave from Visita where DiaClave = '" + dia.DiaClave + "' and ClienteClave = '" + cliente.ClienteClave + "'");
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
	}

	public static final class ConsultasAgenda
	{
		public static Agenda obtenerAgendaPorDiaClienteRutaVendedor(Dia dia, Ruta ruta, Vendedor vendedor, Cliente cliente) throws Exception
		{
			ISetDatos setDatos = BDVend.consultar(Agenda.class, new String[] {}, "DiaClave = ? and VendedorId = ? and RUTClave = ? and ClienteClave = ?", new Object[]
			{ dia.DiaClave, vendedor.VendedorId, ruta.RUTClave, cliente.ClienteClave });
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

		public static VendedorJornada obtenerJornadaActual(Vendedor vendedor) throws Exception
		{
			ISetDatos setDatos = BDVend.consultar(VendedorJornada.class, new String[] {}, "DiaClave IS NULL AND FechaFinal IS NULL AND VendedorId = ? ORDER BY MFechaHora DESC", new Object[]
			{ vendedor.VendedorId });
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

	}

	public static final class ConsultasTransProd
	{

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
			consulta.append("else case when TRP.TipoFase = 4 Then TRP.FechaFacturacion end end end end end as Fecha ");
			consulta.append("from TransProd TRP inner join Dia D on TRP.DiaClave = D.DiaClave ");
			consulta.append("inner join visita VIS on VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = D.DiaClave ");
			consulta.append("where TRP.Tipo in (1,19,21) "); // pedidos y
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

		public static SeleccionarPedido.VistaPedidos[] obtenerMovimientoInventario(Dia dia, String Tipo) throws Exception
		{
			ArrayList<SeleccionarPedido.VistaPedidos> pedidos = new ArrayList<SeleccionarPedido.VistaPedidos>();
			StringBuilder consulta = new StringBuilder();
			ISetDatos fases = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
			consulta.append("select TRP.TransProdID,TRP.Folio,TRP.TipoFase, ");
			consulta.append("TRP.FechaCaptura as Fecha ");
			consulta.append("from TransProd TRP inner join Dia D on TRP.DiaClave = D.DiaClave ");
			consulta.append("where TRP.Tipo in (" + Tipo + ")  and TRP.DiaClave = '" + dia.DiaClave + "'");

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
				datos = BDVend.consultar("SELECT case when sum(saldo) is null then 0 else sum(saldo) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND ((Tipo = 1 AND CFVTipo = 2) OR Tipo = 24) AND TipoFase > 0");
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

		public static float obtenerSaldoNoCobrarVentas(Cliente oCliente) throws Exception
		{
			ISetDatos datos;
			ISetDatos datos2;
			if (oCliente.ActualizaSaldoCheque)
			{
				datos = BDVend.consultar("SELECT case when sum(saldo) is null then 0 else sum(saldo) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND ((Tipo = 8 AND CFVTipo = 2) or Tipo = 24) AND TipoFase > 0");
				datos2 = BDVend.consultar("SELECT case when sum(saldo) is null then 0 else sum(saldo) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oCliente.ClienteClave + "' AND Tipo = 1 AND CFVTipo = 2 AND TipoFase > 0 AND FacturaId is null");
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
				sConsulta.append("AND Visita.VisitaClave='" + visitaClave + "' ");
				sConsulta.append("AND Visita.DiaClave='" + diaClave + "'");
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

		public static ISetDatos obtenerTransProdAImprimirMovInventario(String lstTrpTipo, String diaClave, String TransProdIDs)
		{
			try
			{
				StringBuilder sConsulta = new StringBuilder();

				sConsulta.append("Select TransProd.TransProdId as _Id, TransProd.Tipo as Tipo, 'TRPTIPO' as VARCodigo,'TRP' as TipoRecibo, TransProd.Folio as Folio, '' as DescTipo,strftime( '%d/%m/%Y', CASE WHEN TransProd.Tipo = " + lstTrpTipo + " THEN TransProd.FechaFacturacion ELSE TransProd.FechaCaptura END) as Fecha, TransProd.Total as Total, TransProd.TipoFase as TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as DiaClave, TransProd.SubEmpresaID as SubEmpresaID, ifnull( TDF.TransProdId, 0) as FacElec ");
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
			sConsulta.append((soloConPrecio ? "inner " : "left ") + " join PrecioProductoVig PPV on PPV.ProductoClave = PRS.ProductoClave and PPV.PRUTipoUnidad = PRS.PRUTipoUnidad and PPV.PrecioClave='" + precioClave + "' ");
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
					sConsulta.append("(Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave = '" + precioClave + "')");
					sConsulta.append((soloConPrecio ? "inner " : "left ") + " join PrecioProductoVig PPV on PPV.ProductoClave = PPE.ProductoClave and PPV.PRUTipoUnidad = PDE.PRUTipoUnidad and PPV.PrecioClave='" + precioClave + "' ");
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
					sConsulta.append("(Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave = '" + precioClave + "')");
					sConsulta.append((soloConPrecio ? "inner " : "left ") + " join PrecioProductoVig PPV on PPV.ProductoClave = EPP.ProductoClave and PPV.PRUTipoUnidad = PDE.PRUTipoUnidad and PPV.PrecioClave='" + precioClave + "' ");
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
					sConsulta.append("(Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave = '" + precioClave + "')");
					sConsulta.append((soloConPrecio ? "inner " : "left ") + " join PrecioProductoVig PPV on PPV.ProductoClave = EPP.ProductoClave and PPV.PRUTipoUnidad = PDE.PRUTipoUnidad and PPV.PrecioClave='" + precioClave + "' ");
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
			// return
			// BDVend.consultar("SELECT COUNT(*) as TotalProductos, SUM(Total) as Total FROM TransProdDetalle WHERE TransProdId in ("
			// + transProdId + ") AND Total > 0 AND Promocion != 2"); //GROUP BY
			// ProductoClave");
			return BDVend.consultar("SELECT COUNT(*) as TotalProductos, SUM(TPD.Total) as Total, SUM(TPD.Cantidad * PRD.Factor) as Unidades FROM TransProdDetalle TPD inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and  TPD.ProductoClave = PRD.ProductoDetClave and TPD.TipoUnidad = PRD.PRUTipoUnidad WHERE TPD.TransProdId in (" + transProdId + ") AND (IFNULL(TPD.Promocion,0) != 2)");
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

					+ " left join PrecioProductoVig PPV on PRO.ProductoClave = PPV.ProductoClave and  PPV.PRUTipoUnidad = ( " + " select PRU.PRUTipoUnidad " + " from ProductoUnidad PRU " + " inner join ProductoDetalle PRD on PRU.ProductoClave = PRD.ProductoClave and PRU.PRUTipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave " + " where PRU.ProductoClave = PRO.ProductoClave " + " order by PRD.Factor limit 1) and PPV.PrecioClave = '" + sPrecioClave + "' and  DATETIME('now') between PPV.PPVFechaInicio and PPV.FechaFin " + "  left join PromocionDetalle PRD on PRM.PromocionClave = PRD.PromocionClave and PRD.TipoEstado = 1 " + " 	where PRM.TipoEstado = 1 and PRP.TipoEstado = 1 and DATETIME('now') between FechaInicial and FechaFinal " + " and ((PRM.Tipo in (2,4) and PRD.EsquemaId in (" + sEsquemasCliente + ")) or PRM.Tipo = 1) " + " group by PRM.PromocionClave, PRM.Nombre, PRM.Tipo, PRM.TipoAplicacion, PRM.FechaFinal, PRM.PermiteCascada, PRM.TipoRango, PRM.TipoRegla, PRM.Obligatoria, " + " PRM.SeleccionProducto, PRM.CapturaCantidad, PRM.PendienteEntrega, PRP.ProductoClave, PRO.Nombre, PPV.Precio " + " order by case when PRM.Tipo <> 4 then 0 else 1 end ";

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

			String Consulta = "select PromocionClave, PromocionReglaID,Minimo,Maximo,Porcentaje,Importe,Cantidad,PRE.Nombre as Precio from PromocionRegla  PR left join Precio PRE on PRE.PrecioClave=PR.PrecioClave and PRE.TipoEstado = 1 ";
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
			sConsulta.append("where strftime('%Y-%m-%d %H:%M:%S','now') between PRM.FechaInicial and PRM.FechaFinal and PRM.TipoEstado = 1 ");
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
			consulta.append("where PRA.PromocionClave = '" + promocion.PromocionClave + "'");
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
				promocion.SeleccionProducto, promocion.CapturaCantidad, datos.getInt(5), datos.getInt("Factor"));
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

			sConsulta.append("SELECT TransProd.TransProdID ");
			sConsulta.append("From TransProd  ");
			sConsulta.append("WHERE TransProd.Tipo in (2,8,10,19,21,23) ");
			sConsulta.append("AND TransProd.FechaHoraAlta < (Select TransProd.FechaHoraAlta From TransProd WHERE Folio='" + FolioID + "' )");

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
		public static ISetDatos obtenerAbonos(String TransProdId) throws Exception
		{
			return BDVend.consultar("SELECT ABNId FROM AbnTrp WHERE TransProdId = '" + TransProdId + "'");
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

			return BDVend.consultar(sConsulta.toString());
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
			consulta.append("where VIS.ClienteClave = '" + clienteClave + "' and VIS.DiaClave = '" + diaClave + "' AND VIS.VisitaClave = '" + visitaClave + "'");

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
			consulta.append("select ABDId, TipoPago, MON.MonedaID, Importe, TipoBanco, Referencia, FechaCheque ");
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

				Cobranza.VistaDetalle detalle = new Cobranza.VistaDetalle(datos.getString("ABDId"), datos.getInt("TipoPago"), formaPago, datos.getString("MonedaID"), moneda, datos.getFloat("Importe"), tipoBanco, banco, datos.getString("Referencia"), datos.getDate("FechaCheque"));
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
		
		public static ListaInventario[] obtenerListaInventario()
		{
			ArrayList<ListaInventario> listInventario = null;
			try
			{
				StringBuilder query = new StringBuilder();
				query.append("select i.ProductoClave, p.Nombre, pd.PRUTipoUnidad, i.disponible as Existencia,(i.disponible - i.nodisponible - i.Apartado -i.contenido - i.pedido) as Disponible, (i.nodisponible + i.Apartado + i.Pedido) as NoDisponible, i.NoDisponible as MalEstado, pu.kglts ");
				query.append("from Inventario i, Producto p, (select * from productodetalle where factor = 1 group by productodetclave) pd, (select * from productounidad group by productoclave) pu ");
				query.append("where i.ProductoClave = p.ProductoClave and p.ProductoClave = pd.ProductoClave and pu.productoclave = pd.productoclave and pd.factor =1 and i.disponible > 0 order by i.ProductoClave");
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

		public static float obtenerExistencia(String productoClave, String precioClave, boolean isDevolucion) throws Exception
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
			consulta.append("PDE.Factor= (Select IFNULL(min(PDE2.factor),1) from ProductoDetalle PDE2 inner join PrecioProductoVig PPV2 on  PPV2.ProductoClave = PDE2.ProductoClave and PPV2.PRUTipoUnidad = PDE2.PRUTipoUnidad where PDE2.ProductoClave = PRO.ProductoClave and PDE2.ProductoDetClave = PRO.ProductoClave and PPV2.PrecioClave = '" + precioClave + "') ");
			consulta.append("Where INV.ProductoClave = '" + productoClave + "'");

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
			consulta.append("Select Sum(Total) as Total ");
			consulta.append("FROM Deposito");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if (datos.getCount() > 0)
			{
				datos.moveToFirst();
				mTotal = datos.getFloat("Total");
			}
			datos.close();
			return mTotal;

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
			consulta.append("Select DEPId as _id, Ficha, FechaDeposito, Total, TipoBanco ");
			consulta.append("From Deposito ");
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

	}

	public static final class ConsultaRegistroInicioFin
	{

		public static TransProd obtenerTransProd() throws Exception
		{

			TransProd mTransProd = new TransProd();

			StringBuilder consulta = new StringBuilder();
			consulta.append("Select Tipo, TipoFase, ClienteClave ");
			consulta.append("FROM TransProd ");
			consulta.append("Where TransProd.Tipo = 1 And TransProd.TipoFase = 1 ");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				mTransProd.Tipo = datos.getShort(0);
				mTransProd.TipoFase = datos.getShort(1);
				mTransProd.ClienteClave = datos.getString(2);
			}
			datos.close();

			return mTransProd;
		}

		public static boolean obtenerRelacion(String VendedorId) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("Select Agenda.ClienteClave, Agenda.VendedorId ");
			consulta.append("From Agenda ");
			consulta.append("Where Agenda.VendedorId= '" + VendedorId + "'");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			ISetDatos datos2 = null;
			while (datos.moveToNext())
			{
				consulta = new StringBuilder();
				consulta.append("Select ClienteClave,  VendedorId ");
				consulta.append("From Visita ");
				consulta.append("Where ClienteClave=' " + datos.getString(0) + "'");
				datos2 = BDVend.consultar(consulta.toString());

			}
			if (datos.getCount() == datos2.getCount())
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

		public static boolean obtenerVendedorJornada(String VendedorId) throws Exception
		{

			StringBuilder consulta = new StringBuilder();
			consulta.append("Select * ");
			consulta.append("From VendedorJornada ");
			consulta.append("Where FechaFinal Is Null And" +
					" VendedorId= '" + VendedorId + "'");
			ISetDatos datos = BDVend.consultar(consulta.toString());

			while (datos.moveToNext())
			{
				return true;
			}

			return false;
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
			String Consulta = "Select t.Tipo ,Td.ProductoClave,TD.TipoUnidad,sum(TD.Cantidad) as Cantidad from TransProdDetalle td inner join transprod t on t.transprodid=td.transprodid where (Tipo=1 or Tipo=24) and (TipoFase=1 or TipoFase=7) group by t.Tipo ,Td.ProductoClave,TD.TipoUnidad";
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
			return frecuenciasObtenidas;
		}
	}
}
