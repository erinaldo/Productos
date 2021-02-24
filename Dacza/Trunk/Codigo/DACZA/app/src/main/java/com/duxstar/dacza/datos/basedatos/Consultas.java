package com.duxstar.dacza.datos.basedatos;

import android.annotation.SuppressLint;
import android.app.SearchManager;
import android.database.Cursor;
import android.database.MergeCursor;
import android.util.Log;

import com.duxstar.dacza.actividades.ValorReferencia;
import com.duxstar.dacza.datos.OrdenTrabajo;
import com.duxstar.dacza.datos.Taller;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.Vin;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.Folio;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.act.SeleccionarDevolucion;
import com.duxstar.dacza.presentadores.act.SeleccionarOrden;
import com.duxstar.dacza.presentadores.act.SeleccionarRecarga;
import com.duxstar.dacza.vistas.ConsultaInventario.ListaInventario;
import com.duxstar.dacza.actividades.ValoresReferencia;
import com.duxstar.dacza.vistas.ConsultaTraspaso.ListaTRPDetalle;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Hashtable;

@SuppressLint("SimpleDateFormat")
public final class Consultas
{
    public static final class ConsultasTaller {

        public static Taller obtenerTaller(String almacen) throws Exception {
            ISetDatos setDatos = BDTerm.consultar(Taller.class, new String[]{}, "Clave LIKE ?", new Object[]
                    {almacen});
            Taller taller = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                taller = (Taller) BDTerm.instanciar(Taller.class, setDatos);
            }
            setDatos.close();
            return taller;
        }
    }

	public static final class ConsultasUsuario
	{
        public static Usuario obtenerUsuarioPorId(String usuarioId) throws Exception
        {
            ISetDatos setDatos = BDTerm.consultar(Usuario.class, new String[]{}, "UsuarioId LIKE ?", new Object[]
                    {usuarioId});
            Usuario usuario = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                usuario = (Usuario) BDTerm.instanciar(Usuario.class, setDatos);
            }
            setDatos.close();
            return usuario;
        }

		public static Usuario obtenerUsuario(String almacen, String agente) throws Exception
		{

            ISetDatos setDatos = BDTerm.consultar("select u.* " +
                    "from Usuario u " +
                    "inner join Taller t on u.TallerId = t.TallerId " +
                    "where u.Clave = '" + agente + "' and t.Clave = '" + almacen + "'");

           	Usuario usuario = null;
			if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0))
			{
				usuario = (Usuario) BDTerm.instanciar(Usuario.class, setDatos);
                setDatos.close();
			}

			return usuario;
		}

        public static Usuario obtenerUsuarioIdentico(String cadenaBusqueda) throws Exception {
            ISetDatos setDatos = BDTerm.consultar(Usuario.class, new String[] {}, "(UPPER(Clave) = UPPER(?) or UPPER(UsuarioId) = UPPER(?))", new Object[]
                    { cadenaBusqueda, cadenaBusqueda });
            Usuario usuario = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                usuario = (Usuario) BDTerm.instanciar(Usuario.class, setDatos);
            }
            setDatos.close();
            return usuario;
        }

        public static Usuario obtenerUsuario(String clave) throws Exception {
            ISetDatos setDatos = BDTerm.consultar(Usuario.class, new String[]{}, "Clave LIKE ?", new Object[]
                    {clave});
            Usuario usuario = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                usuario = (Usuario) BDTerm.instanciar(Usuario.class, setDatos);
            }
            setDatos.close();
            return usuario;
        }

        public static ISetDatos obtenerTodos(String filtro)throws Exception {
            StringBuilder query = new StringBuilder();

            query.append("select UsuarioId as _id, Clave as " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", ");
            query.append("Clave || ' - ' || Nombre as " + SearchManager.SUGGEST_COLUMN_TEXT_1 + " ");
            query.append("from Usuario ");
            if (filtro != null) {
                query.append("where Clave || ' - ' || Nombre LIKE '%" + filtro + "%' ");
            }
            query.append("order by Clave ");

            ISetDatos datos = BDTerm.consultar(query.toString());
            return datos;
        }
	}

    public static final class ConsultasInventario
    {
        public static ListaInventario[] obtenerListaInventario()
        {
            ArrayList<ListaInventario> listInventario = null;
            try
            {
                StringBuilder query = new StringBuilder();
                //query.append("select i.ProductoClave, p.Nombre, pd.PRUTipoUnidad, i.disponible as Existencia,(i.disponible - i.nodisponible - i.Apartado -i.contenido - i.pedido) as Disponible, (i.nodisponible + i.Apartado + i.Pedido) as NoDisponible, i.NoDisponible as MalEstado, pu.kglts ");
                query.append("select a.Clave, a.Descripcion, a.Unidad, i.Existencia ");
                query.append("from Inventario i ");
                query.append("inner join Articulo a on i.ArticuloId = a.ArticuloId ");
                //query.append("where i.Existencia > 0 ");
                query.append("order by a.Clave ");

                ISetDatos dataQuery = BDTerm.consultar(query.toString());
                listInventario = new ArrayList<ListaInventario>();
                while (dataQuery.moveToNext())
                {
                    ListaInventario itemInventory = new ListaInventario();
                    itemInventory.Clave = dataQuery.getString("Clave");
                    itemInventory.Descripcion = dataQuery.getString("Descripcion");
                    itemInventory.Unidad = dataQuery.getString("Unidad");
                    itemInventory.Existencia = dataQuery.getFloat("Existencia");
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

        public static float obtenerExistencia(String articuloId) throws Exception
        {
            float existencia = 0;
            StringBuilder query = new StringBuilder();
            query.append("select IFNULL(sum(Existencia-Apartado),0) as Existencia ");
            query.append("from Inventario ");
            query.append("where ArticuloId = '" + articuloId + "' ");

            ISetDatos datos = BDTerm.consultar(query.toString());
            if (datos.getCount() > 0)
            {
                datos.moveToFirst();
                existencia = datos.getFloat("Existencia");
            }

            datos.close();

            return existencia;
        }

        public static boolean haySinEnviar() throws Exception{
            StringBuilder query = new StringBuilder();
            query.append("select * from Inventario where Enviado = 0");

            ISetDatos datos = BDTerm.consultar(query.toString());
            if (datos.getCount()>0)
                return true;
            return false;
        }
    }

    public static final class ConsultasOrdenTrabajo
    {
        public static SeleccionarOrden.VistaOrdenes[] obtenerOrdenesCliente(int vista)throws Exception
        {
            ArrayList<SeleccionarOrden.VistaOrdenes> ordenes = new ArrayList<SeleccionarOrden.VistaOrdenes>();

            StringBuilder query = new StringBuilder();
            query.append("select o.OrdenId, o.Folio, c.Clave as ClienteClave, c.RazonSocial, u.Clave as UsuarioClave, ");
            query.append("u.Nombre as UsuarioNombre, v.Clave as VinClave, a.Descripcion as VinDescripcion, o.Fase, o.FechaIni, o.FechaFin ");
            query.append("from OrdenTrabajo o ");
            query.append("inner join Usuario u on o.AgenteId = u.UsuarioId ");
            query.append("inner join Cliente c on o.ClienteId = c.ClienteId ");
            query.append("inner join Vin v on o.VinId = v.VinId ");
            query.append("inner join Articulo a on v.ArticuloId = a.ArticuloId ");
            switch (vista)
            {
                case Enumeradores.Vista.VISTA_TODAS:
                    break;
                case Enumeradores.Vista.VISTA_CAPTURA:
                    query.append("where o.Fase = " + Enumeradores.TiposFasesDocto.CAPTURA + " ");
                    break;
                case Enumeradores.Vista.VISTA_CANCELADAS:
                    query.append("where o.Fase = " + Enumeradores.TiposFasesDocto.CANCELADO + " ");
                    break;
                case Enumeradores.Vista.VISTA_CERRADAS:
                    query.append("where o.Fase = " + Enumeradores.TiposFasesDocto.CERRADO + " ");
                    break;
                case Enumeradores.Vista.VISTA_NO_ENVIADAS:
                    query.append("where o.Enviado = 0 ");
                    break;
            }
            query.append("order by o.Folio ");

            ISetDatos datos = BDTerm.consultar(query.toString());
            while (datos.moveToNext())
            {
                int fase = datos.getInt(8);
                ValorReferencia vFase = ValoresReferencia.getValor("DOCTOFASE", String.valueOf(fase));

                SeleccionarOrden.VistaOrdenes orden = new SeleccionarOrden.VistaOrdenes();
                //datos.getString(0), datos.getString(1), datos.getInt(2), fases.getString(2), datos.getDate(3));// datos.getDate(3)
                orden.setOrdenId(datos.getString(0));
                orden.setFolio(datos.getString(1));
                orden.setCliente(datos.getString(2) + " - " + datos.getString(3));
                orden.setAgente(datos.getString(4) + " - " + datos.getString(5));
                orden.setVin(datos.getString(6) + " - " + datos.getString(7));
                orden.setTipoFase(fase);
                orden.setFase(vFase.getDescripcion());
                orden.setFechaIni(new SimpleDateFormat("dd/MM/yyyy").format(datos.getDate(9))); //datos.getString(9));
                orden.setFechaFin(new SimpleDateFormat("dd/MM/yyyy").format(datos.getDate(10))); //datos.getString(10));
                // Generales.getFechaHoraActual()
                ordenes.add(orden);
            }
            datos.close();

            return ordenes.toArray(new SeleccionarOrden.VistaOrdenes[ordenes.size()]);
        }

        public static OrdenTrabajo obtenerOrden(String ordenId) throws Exception {
            ISetDatos setDatos = BDTerm.consultar(OrdenTrabajo.class, new String[]{}, "OrdenId LIKE ?", new Object[]
                    {ordenId});
            OrdenTrabajo orden = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                orden = (OrdenTrabajo) BDTerm.instanciar(OrdenTrabajo.class, setDatos);
            }
            setDatos.close();
            return orden;
        }

        public static boolean haySinEnviar() throws Exception{
            StringBuilder query = new StringBuilder();
            query.append("select * from OrdenTrabajo where Enviado = 0 or Fase = 1");

            ISetDatos datos = BDTerm.consultar(query.toString());
            if (datos.getCount()>0)
                return true;
            return false;
        }
    }

    public static final class ConsultasCliente{

        public static Cliente obtenerClienteIdentico(String cadenaBusqueda) throws Exception {
            ISetDatos setDatos = BDTerm.consultar(Cliente.class, new String[] {}, "(UPPER(Clave) = UPPER(?) or UPPER(ClienteId) = UPPER(?))", new Object[]
                    { cadenaBusqueda, cadenaBusqueda });
            Cliente cliente = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                cliente = (Cliente) BDTerm.instanciar(Cliente.class, setDatos);
            }
            setDatos.close();
            return cliente;
        }

        public static Cliente obtenerCliente(String clave) throws Exception {
            ISetDatos setDatos = BDTerm.consultar(Cliente.class, new String[]{}, "Clave LIKE ?", new Object[]
                    {clave});
            Cliente cliente = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                cliente = (Cliente) BDTerm.instanciar(Cliente.class, setDatos);
            }
            setDatos.close();
            return cliente;
        }

        public static Cliente obtenerClientePorId(String clienteId) throws Exception {
            ISetDatos setDatos = BDTerm.consultar(Cliente.class, new String[]{}, "ClienteId LIKE ?", new Object[]
                    {clienteId});
            Cliente cliente = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                cliente = (Cliente) BDTerm.instanciar(Cliente.class, setDatos);
            }
            setDatos.close();
            return cliente;
        }

        public static ISetDatos obtenerTodos(String filtroOrig, String filtro)throws Exception {
            StringBuilder query = new StringBuilder();
            query.append("select c.ClienteId as _id, c.ClienteId as " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", ");
            query.append("Clave || ' - ' || RazonSocial as " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", ");
            //query.append("cd.Calle || ' ' || cd.NumeroExt || ' ' || cd.NumeroInt AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + " ");
            query.append("c.Domicilio AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + " ");
            query.append("from Cliente c ");
            //query.append("inner join ClienteDomicilio cd on c.ClienteId = cd.ClienteId " );
            //query.append("where cd.Tipo = 1 ");
            query.append("where 1 = 1 ");
            if (filtroOrig != null) {
                query.append("and c.Clave || ' - ' || c.RazonSocial LIKE '%" + filtroOrig + "%' ");
            }
            if (filtro != null) {
                query.append("and (c.Clave || ' - ' || c.RazonSocial LIKE '%" + filtro + "%' ");
                //query.append("OR cd.Calle || ' ' || cd.NumeroExt || ' ' || cd.NumeroInt LIKE '%" + filtro + "%') ");
                query.append("or c.Domicilio LIKE '%" + filtro + "%') ");
            }
            //query.append("group by c.ClienteId, Clave || ' - ' || RazonSocial, cd.Calle || ' ' || cd.NumeroExt || ' ' || cd.NumeroInt ");
            query.append("order by c.Clave ");

            ISetDatos datos = BDTerm.consultar(query.toString());
            return datos;
        }
    }

    public static final class ConsultasVin{

        public static Vin obtenerVinIdentico(String cadenaBusqueda, String clienteId) throws Exception {
            ISetDatos setDatos = BDTerm.consultar(Vin.class, new String[] {}, "(UPPER(Clave) = UPPER(?) or UPPER(VinId) = UPPER(?))", new Object[]
                    { cadenaBusqueda, cadenaBusqueda });
            Vin vin = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                vin = (Vin) BDTerm.instanciar(Vin.class, setDatos);
            }
            setDatos.close();
            if (vin != null) {
                if (vin.ClienteId.equals(clienteId))
                    return vin;
                else
                    return null;
            }
            else
                return null;
        }

        public static Vin obtenerVin(String clave, String clienteId) throws Exception {
            ISetDatos setDatos = BDTerm.consultar(Vin.class, new String[]{}, "Clave LIKE ?", new Object[]
                    {clave});
            Vin vin = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                vin = (Vin) BDTerm.instanciar(Vin.class, setDatos);
            }
            setDatos.close();
            if (vin != null) {
                if (vin.ClienteId.equals(clienteId))
                    return vin;
                else
                    return null;
            }
            else
                return null;
        }

        public static Vin obtenerVinPorId(String vinId) throws Exception {
            ISetDatos setDatos = BDTerm.consultar(Vin.class, new String[]{}, "VinId LIKE ?", new Object[]
                    {vinId});
            Vin vin = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                vin = (Vin) BDTerm.instanciar(Vin.class, setDatos);
            }
            setDatos.close();

            return vin;
        }

        public static ISetDatos obtenerTodos(String filtro, String clienteId)throws Exception {
            StringBuilder query = new StringBuilder();

            query.append("select v.VinId as _id, v.Clave as " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ", ");
            query.append("v.Clave || ' - ' || a.Descripcion as " + SearchManager.SUGGEST_COLUMN_TEXT_1 + ", ");
            query.append("'Placas: ' || v.Placas  AS " + SearchManager.SUGGEST_COLUMN_TEXT_2 + " ");
            query.append("from Vin v ");
            query.append("inner join Articulo a on v.ArticuloId = a.ArticuloId " );
            query.append("where v.ClienteId = '" + clienteId + "' ");
            if (filtro != null) {
                query.append("and (v.Clave || ' - ' || a.Descripcion LIKE '%" + filtro + "%' ");
                query.append("or 'Placas: ' || v.Placas LIKE '%" + filtro + "%' )");
            }

            query.append("order by v.Clave || ' - ' || a.Descripcion ");

            ISetDatos datos = BDTerm.consultar(query.toString());
            return datos;
        }
    }

    public static final class ConsultasArticulo{

        public static Articulo obtenerArticuloPorId(String articuloId) throws Exception{
            ISetDatos setDatos = BDTerm.consultar(Articulo.class, new String[]{}, "ArticuloId LIKE ? and Tipo = 2", new Object[]
                    {articuloId});
            Articulo articulo = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                articulo = (Articulo) BDTerm.instanciar(Articulo.class, setDatos);
            }
            setDatos.close();
            return articulo;
        }

        public static Articulo obtenerVinPorId(String articuloId) throws Exception{
            ISetDatos setDatos = BDTerm.consultar(Articulo.class, new String[]{}, "ArticuloId LIKE ? and Tipo = 3", new Object[]
                    {articuloId});
            Articulo articulo = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                articulo = (Articulo) BDTerm.instanciar(Articulo.class, setDatos);
            }
            setDatos.close();
            return articulo;
        }

        public static Articulo obtenerArticuloIdentico(String cadenaBusqueda) throws Exception {
            ISetDatos setDatos = BDTerm.consultar(Articulo.class, new String[] {}, "(UPPER(Clave) = UPPER(?) or UPPER(ArticuloId) = UPPER(?)) and Tipo = 2", new Object[]
                    { cadenaBusqueda, cadenaBusqueda });
            Articulo articulo = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                articulo = (Articulo) BDTerm.instanciar(Articulo.class, setDatos);
            }
            setDatos.close();
            return articulo;
        }

        public static Articulo obtenerArticulo(String clave) throws Exception {
            ISetDatos setDatos = BDTerm.consultar(Articulo.class, new String[]{}, "Clave LIKE ? and Tipo = 2", new Object[]
                    {clave});
            Articulo articulo = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                articulo = (Articulo) BDTerm.instanciar(Articulo.class, setDatos);
            }
            setDatos.close();
            return articulo;
        }

        public static Cursor obtenerArticulosParaOrden(String filtro, String ordenId) throws Exception
        {

            ArrayList<Cursor> cursores = new ArrayList<Cursor>();
            int limit = 0;
            int rows = 100000;

            while (limit + 6000 < rows)
            {
                StringBuilder consulta = new StringBuilder();

                consulta.append("select a.ArticuloId as _id, a.ArticuloId, a.Clave, a.Descripcion, a.Grupo, case when i.Existencia is null then 0 else (i.Existencia - i.Apartado) end as Existencia, 0 as Cantidad ");
                consulta.append("from Articulo a ");
                consulta.append("left join Inventario i on a.ArticuloId = i.ArticuloId ");
                consulta.append("left join ODTDetalle o on o.OrdenId = '" + ordenId + "' and a.ArticuloId = o.ArticuloId ");
                consulta.append("where a.Tipo = 2 and o.OrdenId is null ");
                if (filtro != "")
                    consulta.append("and (a.Clave like '%" + filtro + "%' or a.Descripcion like '%" + filtro + "%' or a.Grupo like '%" + filtro + "%')");
                consulta.append("group by a.ArticuloId ");
                consulta.append("having (i.Existencia-i.Apartado)>0 ");
                consulta.append("order by a.Grupo, a.Clave ");
                consulta.append("limit " + limit + ", 6000");

                ISetDatos datos = BDTerm.consultar(consulta.toString());

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

        public static Cursor obtenerArticulosParaRecarga(String filtro, String recargaId) throws Exception
        {

            ArrayList<Cursor> cursores = new ArrayList<Cursor>();
            int limit = 0;
            int rows = 100000;

            while (limit + 6000 < rows)
            {
                StringBuilder consulta = new StringBuilder();

                consulta.append("select a.ArticuloId as _id, a.ArticuloId, a.Clave, a.Descripcion, a.Grupo, case when i.Existencia is null then 0 else (i.Existencia - i.Apartado) end as Existencia, 0 as Cantidad ");
                consulta.append("from Articulo a ");
                consulta.append("left join Inventario i on a.ArticuloId = i.ArticuloId ");
                consulta.append("left join RECDetalle r on r.RecargaId = '" + recargaId + "' and a.ArticuloId = r.ArticuloId ");
                consulta.append("where a.Tipo = 2 and r.RecargaId is null ");
                if (filtro != "")
                    consulta.append("and (a.Clave like '%" + filtro + "%' or a.Descripcion like '%" + filtro + "%' or a.Grupo like '%" + filtro + "%')");
                consulta.append("order by a.Grupo, a.Clave ");
                consulta.append("limit " + limit + ", 6000");

                ISetDatos datos = BDTerm.consultar(consulta.toString());

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

        public static Cursor obtenerArticulosParaDevolucion(String filtro, String devolucionId) throws Exception
        {

            ArrayList<Cursor> cursores = new ArrayList<Cursor>();
            int limit = 0;
            int rows = 100000;

            while (limit + 6000 < rows)
            {
                StringBuilder consulta = new StringBuilder();

                consulta.append("select a.ArticuloId as _id, a.ArticuloId, a.Clave, a.Descripcion, a.Grupo, case when i.Existencia is null then 0 else (i.Existencia - i.Apartado) end as Existencia, 0 as Cantidad ");
                consulta.append("from Articulo a ");
                consulta.append("inner join Inventario i on a.ArticuloId = i.ArticuloId ");
                consulta.append("left join DEVDetalle r on r.DevolucionId = '" + devolucionId + "' and a.ArticuloId = r.ArticuloId ");
                consulta.append("where a.Tipo = 2 and r.DevolucionId is null ");
                consulta.append("and (i.Existencia - i.Apartado) > 0 ");
                if (filtro != "")
                    consulta.append("and (a.Clave like '%" + filtro + "%' or a.Descripcion like '%" + filtro + "%' or a.Grupo like '%" + filtro + "%')");
                consulta.append("order by a.Grupo, a.Clave ");
                consulta.append("limit " + limit + ", 6000");

                ISetDatos datos = BDTerm.consultar(consulta.toString());

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
    }

    public static final class ConsultasRecarga
    {
        public static SeleccionarRecarga.VistaRecargas[] obtenerRecargas(int vista)throws Exception
        {
            ArrayList<SeleccionarRecarga.VistaRecargas> recargas = new ArrayList<SeleccionarRecarga.VistaRecargas>();

            StringBuilder query = new StringBuilder();
            query.append("select RecargaId, Folio, Fase, FechaSolicitud, FechaSurtido ");
            query.append("from Recarga ");
            switch (vista)
            {
                case Enumeradores.Vista.VISTA_TODAS:
                    break;
                case Enumeradores.Vista.VISTA_CAPTURA:
                    query.append("where Fase = " + Enumeradores.TiposFasesDocto.CAPTURA + " ");
                    break;
                case Enumeradores.Vista.VISTA_CANCELADAS:
                    query.append("where Fase = " + Enumeradores.TiposFasesDocto.CANCELADO + " ");
                    break;
                case Enumeradores.Vista.VISTA_CERRADAS:
                    query.append("where Fase = " + Enumeradores.TiposFasesDocto.CERRADO + " ");
                    break;
                case Enumeradores.Vista.VISTA_NO_ENVIADAS:
                    query.append("where Enviado = 0 ");
                    break;
                case Enumeradores.Vista.VISTA_SURTIDAS:
                    query.append("where Fase = " + Enumeradores.TiposFasesDocto.SURTIDO + " ");
                    break;
            }
            query.append("order by Folio ");

            ISetDatos datos = BDTerm.consultar(query.toString());
            while (datos.moveToNext())
            {
                int fase = datos.getInt(2);
                ValorReferencia vFase = ValoresReferencia.getValor("DOCTOFASE", String.valueOf(fase));

                SeleccionarRecarga.VistaRecargas recarga = new SeleccionarRecarga.VistaRecargas();
                recarga.setRecargaId(datos.getString(0));
                recarga.setFolio(datos.getString(1));
                recarga.setTipoFase(fase);
                recarga.setFase(vFase.getDescripcion());
                recarga.setFechaSolicitud(new SimpleDateFormat("dd/MM/yyyy").format(datos.getDate(3))); //datos.getString(3));
                if (datos.getDate(4) != null)
                    recarga.setFechaSurtido(new SimpleDateFormat("dd/MM/yyyy").format(datos.getDate(4))); //datos.getString(4));
                else
                    recarga.setFechaSurtido("");
                // Generales.getFechaHoraActual()
                recargas.add(recarga);
            }
            datos.close();

            return recargas.toArray(new SeleccionarRecarga.VistaRecargas[recargas.size()]);
        }

        public static ISetDatos obtenerTraspasos(String recargaId)throws Exception
        {
            StringBuilder query = new StringBuilder();
            query.append("select TraspasoId, Folio, Fecha ");
            query.append("from Traspaso ");
            query.append("where RecargaId = '" + recargaId + "'");

            ISetDatos datos = BDTerm.consultar(query.toString());
            return datos;
        }

        public static ListaTRPDetalle[] obtenerTRPDetalle(String traspasosIds)
        {
            ArrayList<ListaTRPDetalle> listInventario = null;
            try
            {
                StringBuilder query = new StringBuilder();
                query.append("select a.Clave, a.Descripcion, a.Unidad, sum(d.Cantidad) as Cantidad ");
                query.append("from TRPDetalle d ");
                query.append("inner join Articulo a on d.ArticuloId = a.ArticuloId ");
                query.append("where TraspasoId in (" + traspasosIds + ") ");
                query.append("group by d.ArticuloId ");
                query.append("order by d.Partida ");

                ISetDatos dataQuery = BDTerm.consultar(query.toString());
                listInventario = new ArrayList<ListaTRPDetalle>();
                while (dataQuery.moveToNext())
                {
                    ListaTRPDetalle itemInventory = new ListaTRPDetalle();
                    itemInventory.Clave = dataQuery.getString("Clave");
                    itemInventory.Descripcion = dataQuery.getString("Descripcion");
                    itemInventory.Unidad = dataQuery.getString("Unidad");
                    itemInventory.Cantidad = dataQuery.getFloat("Cantidad");
                    listInventario.add(itemInventory);
                }
                dataQuery.close();
            }
            catch (Exception ex)
            {

            }
            if (listInventario.size() > 0)
            {
                return listInventario.toArray(new ListaTRPDetalle[listInventario.size()]);
            }
            else
                return null;
        }

        public static boolean haySinEnviar() throws Exception{
            StringBuilder query = new StringBuilder();
            query.append("select * from Recarga where Enviado = 0");

            ISetDatos datos = BDTerm.consultar(query.toString());
            if (datos.getCount()>0)
                return true;
            return false;
        }

        public static Hashtable obtenerImagenes(String idDocumento)throws Exception{
            StringBuilder query = new StringBuilder();
            query.append("select d.Imagen, d.DetalleId ");
            query.append("from RECDetalle d ");
            query.append("inner join Recarga r on d.RecargaId = r.RecargaId ");
            query.append("where (r.Enviado is null or r.Enviado = 0) ");
            query.append("and r.Fase in (2) and not d.Imagen is null ");
            if (!idDocumento.equals(""))
                query.append("and r.RecargaId = '" + idDocumento + "'");

            ISetDatos datos = BDTerm.consultar(query.toString());

            Hashtable htImagenes = new Hashtable();
            while (datos.moveToNext()) {
                htImagenes.put(datos.getString("Imagen"), datos.getString("DetalleId"));
            }
            datos.close();
            return htImagenes;
        }
    }

    public static final class ConsultasDevolucion
    {
        public static SeleccionarDevolucion.VistaDevoluciones[] obtenerDevoluciones(int vista)throws Exception
        {
            ArrayList<SeleccionarDevolucion.VistaDevoluciones> devoluciones = new ArrayList<SeleccionarDevolucion.VistaDevoluciones>();

            StringBuilder query = new StringBuilder();
            query.append("select DevolucionId, Folio, Fase, Fecha ");
            query.append("from Devolucion ");
            switch (vista)
            {
                case Enumeradores.Vista.VISTA_TODAS:
                    break;
                case Enumeradores.Vista.VISTA_CAPTURA:
                    query.append("where Fase = " + Enumeradores.TiposFasesDocto.CAPTURA + " ");
                    break;
                case Enumeradores.Vista.VISTA_CANCELADAS:
                    query.append("where Fase = " + Enumeradores.TiposFasesDocto.CANCELADO + " ");
                    break;
                case Enumeradores.Vista.VISTA_CERRADAS:
                    query.append("where Fase = " + Enumeradores.TiposFasesDocto.CERRADO + " ");
                    break;
                case Enumeradores.Vista.VISTA_NO_ENVIADAS:
                    query.append("where Enviado = 0 ");
                    break;
                case Enumeradores.Vista.VISTA_SURTIDAS:
                    query.append("where Fase = " + Enumeradores.TiposFasesDocto.SURTIDO + " ");
                    break;
            }
            query.append("order by Folio ");

            ISetDatos datos = BDTerm.consultar(query.toString());
            while (datos.moveToNext())
            {
                int fase = datos.getInt(2);
                ValorReferencia vFase = ValoresReferencia.getValor("DOCTOFASE", String.valueOf(fase));

                SeleccionarDevolucion.VistaDevoluciones devolucion = new SeleccionarDevolucion.VistaDevoluciones();
                devolucion.setDevolucionId(datos.getString(0));
                devolucion.setFolio(datos.getString(1));
                devolucion.setTipoFase(fase);
                devolucion.setFase(vFase.getDescripcion());
                devolucion.setFecha(new SimpleDateFormat("dd/MM/yyyy").format(datos.getDate(3))); //datos.getString(3));
                devoluciones.add(devolucion);
            }
            datos.close();

            return devoluciones.toArray(new SeleccionarDevolucion.VistaDevoluciones[devoluciones.size()]);
        }

        public static boolean haySinEnviar() throws Exception{
            StringBuilder query = new StringBuilder();
            query.append("select * from Devolucion where Enviado = 0");

            ISetDatos datos = BDTerm.consultar(query.toString());
            if (datos.getCount()>0)
                return true;
            return false;
        }
    }

    public static final class ConsultasFolio{

        public static Folio obtenerFolio(int tipoMovimiento) throws Exception {
            ISetDatos setDatos = BDTerm.consultar(Folio.class, new String[]{}, "TipoMovimiento = ?", new Object[]
                    {tipoMovimiento});
            Folio folio = null;
            if ((setDatos != null) && (setDatos.moveToFirst()) && (setDatos.getCount() > 0)) {
                folio = (Folio) BDTerm.instanciar(Folio.class, setDatos);
            }
            setDatos.close();
            return folio;
        }

        public static ISetDatos obtenerDetalles(String folioId) throws Exception
        {
            StringBuilder query = new StringBuilder();
            query.append("select TipoContenido, Formato ");
            query.append("from FolioDetalle ");
            query.append("where FolioId = '" + folioId + "' ");
            query.append("order by TipoContenido ");

            ISetDatos datos = BDTerm.consultar(query.toString());
            return datos;
        }

        public static boolean haySinEnviar() throws Exception{
            StringBuilder query = new StringBuilder();
            query.append("select * from Folio where Enviado = 0");

            ISetDatos datos = BDTerm.consultar(query.toString());
            if (datos.getCount()>0)
                return true;
            return false;
        }
    }

	/*public static final class ConsultasServidorComunicaciones
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
	}*/
}
