using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eRoute.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace eRoute.Controllers.API
{
    public class PromocionesController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;
        RouteEntities db = new RouteEntities();

        //Primera Pestaña
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Obtener las Promociones existentes
        [HttpGet]
        [ActionName("ObtenerPromociones")]
        public IHttpActionResult ObtenerPromociones()
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                var promociones = (
                    from P in db.Promocion
                    join VD in db.VAVDescripcion on new { Tipo = P.Tipo.ToString(), Aux1 = "TPROM", Aux2 = "EM" } equals new { Tipo = VD.VAVClave, Aux1 = VD.VARCodigo, Aux2 = VD.VADTipoLenguaje }
                    join VDD in db.VAVDescripcion on new { Tipo = P.TipoEstado.ToString(), Aux1 = "EDOREG", Aux2 = "EM" } equals new { Tipo = VDD.VAVClave, Aux1 = VDD.VARCodigo, Aux2 = VDD.VADTipoLenguaje }
                    select new { Clave = P.PromocionClave, Nombre = P.Nombre, Tipo = VD.Descripcion, FechaI = P.FechaInicial, FechaF = P.FechaFinal, Estado = VDD.Descripcion }
                             ).ToList();
                return Json(promociones);
            }

            //var promociones = (
            //    from P in db.Promocion
            //    join VD in db.VAVDescripcion on new { Tipo = P.Tipo.ToString(), Aux1 = "TPROM", Aux2 = "EM" } equals new { Tipo = VD.VAVClave, Aux1 = VD.VARCodigo, Aux2 = VD.VADTipoLenguaje }
            //    join VDD in db.VAVDescripcion on new { Tipo = P.TipoEstado.ToString(), Aux1 = "EDOREG", Aux2 = "EM" } equals new { Tipo = VDD.VAVClave, Aux1 = VDD.VARCodigo, Aux2 = VDD.VADTipoLenguaje }
            //    select new { Clave = P.PromocionClave, Nombre = P.Nombre, Tipo = VD.Descripcion, FechaI = P.FechaInicial, FechaF = P.FechaFinal, Estado = VDD.Descripcion }
            //             ).ToList();
            //return Json(promociones);
        }

        //Esquemas de productos relacionados a la ruta
        [HttpGet]
        [ActionName("ObtenerEsquemas")]
        public IHttpActionResult ObtenerEsquemas()
        {
            //using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            //{

            //Connection.Open();
            //StringBuilder sConsulta = new StringBuilder();
            //sConsulta.Append("select * from FNEsquemasClientesCloud(2)");

            //QueryString = sConsulta.ToString();
            //List<Esquema> Esquemas = Connection.Query<Esquema>(QueryString).ToList();
            //Connection.Close();

            //var padres = (from x in Esquemas
            //              select new
            //              {
            //                  Nombre = x.Nombre + " - " + x.Clave,
            //                  Abreviatura = x.Abreviatura,
            //                  EsquemaID = x.EsquemaID,
            //                  EsquemaIDPadre = x.EsquemaIDPadre,
            //                  Tipo = x.Tipo,
            //                  Orden = x.Orden,
            //                  TipoEstado = x.TipoEstado,
            //                  NivelHijo = x.Nivel,
            //                  Clasificacion = x.Clasificacion,
            //                  Clave = x.Clave
            //              }).ToList();
            var padres = (from x in db.Esquema
                          where x.Baja == false && x.Nivel == 0 && x.Tipo == 2 && x.TipoEstado == 1
                          select new cEsquema
                          {
                              Nombre = x.Nombre + " - " + x.Clave,
                              Abreviatura = x.Abreviatura,
                              EsquemaID = x.EsquemaID,
                              EsquemaIDPadre = x.EsquemaIDPadre,
                              Tipo = x.Tipo,
                              Orden = x.Orden,
                              TipoEstado = x.TipoEstado,
                              NivelHijo = x.Nivel.ToString(),
                              Clasificacion = x.Clasificacion,
                              Clave = x.Clave

                          }).ToList();

            foreach (cEsquema esq in padres)
            {
                //Se busca sobre los padres sí tiene hijos
                obtenerHijos(esq, esq.NivelHijo);
            }
            return Json(padres);
            //}
        }

        //Esquemas de productos relacionados a la ruta
        [HttpGet]
        [ActionName("ObtenerEsquemasCli")]
        public IHttpActionResult ObtenerEsquemasCli()
        {
            //using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            //{

            //Connection.Open();
            //StringBuilder sConsulta = new StringBuilder();
            //sConsulta.Append("select * from FNEsquemasClientesCloud(1)");

            //QueryString = sConsulta.ToString();
            //List<Esquema> Esquemas = Connection.Query<Esquema>(QueryString).ToList();
            //Connection.Close();

            //var padres = (from x in Esquemas
            //              select new
            //              {
            //                  Nombre = x.Nombre + " - " + x.Clave,
            //                  Abreviatura = x.Abreviatura,
            //                  EsquemaID = x.EsquemaID,
            //                  EsquemaIDPadre = x.EsquemaIDPadre,
            //                  Tipo = x.Tipo,
            //                  Orden = x.Orden,
            //                  TipoEstado = x.TipoEstado,
            //                  NivelHijo = x.Nivel,
            //                  Clasificacion = x.Clasificacion,
            //                  Clave = x.Clave
            //              }).ToList();
            var padres = (from x in db.Esquema
                          where x.Baja == false && x.Nivel == 0 && x.Tipo == 1 && x.TipoEstado == 1
                          select new cEsquema
                          {
                              Nombre = x.Nombre + " - " + x.Clave,
                              Abreviatura = x.Abreviatura,
                              EsquemaID = x.EsquemaID,
                              EsquemaIDPadre = x.EsquemaIDPadre,
                              Tipo = x.Tipo,
                              Orden = x.Orden,
                              TipoEstado = x.TipoEstado,
                              NivelHijo = x.Nivel.ToString(),
                              Clasificacion = x.Clasificacion,
                              Clave = x.Clave

                          }).ToList();

            //foreach (cEsquema esq in padres)
            //{
            //    //Se busca sobre los padres sí tiene hijos
            //    obtenerHijos(esq, esq.NivelHijo);
            //}
            return Json(padres);
            //}
        }

        public void obtenerHijos(cEsquema esquema, string nivel)
        {
            //using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            //{
                int nivelAux = (nivel == null ? 0 : Convert.ToInt32((nivel).ToString()));
                int nivelHijo = nivelAux + 1;
                var hijos = (from x in db.Esquema
                             where x.EsquemaIDPadre == esquema.EsquemaID
                             select new cEsquema
                             {

                                 Nombre = x.Nombre + " - " + x.Clave,
                                 Abreviatura = x.Abreviatura,
                                 EsquemaID = x.EsquemaID,
                                 EsquemaIDPadre = x.EsquemaIDPadre,
                                 Tipo = x.Tipo,
                                 Orden = x.Orden,
                                 TipoEstado = x.TipoEstado,
                                 NivelHijo = nivelHijo.ToString(),
                                 Clasificacion = x.Clasificacion,
                                 Clave = x.Clave

                             }).ToList();
            //using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            //{
            //hijos = (from x in db.Esquema
            //             where x.EsquemaIDPadre == esquema.EsquemaID
            //             select new cEsquema
            //             {

            //                 Nombre = x.Nombre + " - " + x.Clave,
            //                 Abreviatura = x.Abreviatura,
            //                 EsquemaID = x.EsquemaID,
            //                 EsquemaIDPadre = x.EsquemaIDPadre,
            //                 Tipo = x.Tipo,
            //                 Orden = x.Orden,
            //                 TipoEstado = x.TipoEstado,
            //                 NivelHijo = nivelHijo.ToString(),
            //                 Clasificacion = x.Clasificacion,
            //                 Clave = x.Clave

            //             }).ToList();
            //}
            if (hijos.Count > 0)
                {
                    foreach (cEsquema esq in hijos)
                    {
                        //Se busca sobre los padres sí tiene hijos
                        obtenerHijos(esq, esq.NivelHijo);
                    }
                    esquema.esquemas = hijos;
                    esquema.children = hijos;

                }

        //}
    }

        //Verificar existencia de una Promocion
        [HttpGet]
        [ActionName("ValidarPromocion")]
        public IHttpActionResult ValidarPromocion(string Clave)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                return Json(db.Promocion.ToList().Exists(x => x.PromocionClave == Clave));
            }
        }

        //Obtener Detalles de un cliente
        [HttpGet]
        [ActionName("ObtCliente")]
        public IHttpActionResult ObtCliente(string Clave)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                var Esquemas = (
                from E in db.Esquema
                where E.Clave == Clave && E.Tipo == 1
                select new { Clave = E.Clave, Nombre = E.Nombre, EsquemaID = E.EsquemaID, TipoEstado = E.TipoEstado, Editable = "1" }
                         ).ToList();
                return Json(Esquemas);
            }
        }

        //Obtener Detalles de un cliente
        [HttpGet]
        [ActionName("ObtModulo")]
        public IHttpActionResult ObtModulo(string Clave)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                var Modulos = (
                from M in db.ModuloMovDetalle
                where M.TipoEstado == 1 && M.Baja == false && (M.TipoIndice == 9 || M.TipoIndice == 22 || M.TipoIndice == 26) && M.ModuloMovDetalleClave == Clave.Replace(" ", "+")
                select new { M.ModuloMovDetalleClave, M.Nombre, M.TipoEstado }
                         ).ToList();
                return Json(Modulos);
            }
        }

        //Esquemas de clientes tree-grid
        [HttpGet]
        [ActionName("EsquemaCliente")]
        public IHttpActionResult Esquemas()
        {
            //using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            //{
            //    Connection.Open();
            //    StringBuilder sConsulta = new StringBuilder();
            //    sConsulta.Append("select * from FNEsquemasClientesCloud(1)");

            //    QueryString = sConsulta.ToString();
            //    List<Esquema> Esquemas = Connection.Query<Esquema>(QueryString).ToList();
            //    Connection.Close();

                //var padres = (from x in Esquemas
                //              select new
                //              {
                //                  Nombre = x.Nombre + " - " + x.Clave,
                //                  Abreviatura = x.Abreviatura,
                //                  EsquemaID = x.EsquemaID,
                //                  EsquemaIDPadre = x.EsquemaIDPadre,
                //                  Tipo = x.Tipo,
                //                  Orden = x.Orden,
                //                  TipoEstado = x.TipoEstado,
                //                  NivelHijo = x.Nivel,
                //                  Clasificacion = x.Clasificacion,
                //                  Clave = x.Clave
                //              }).ToList();
                var padres = (from x in db.Esquema
                              where x.Baja == false && x.Nivel == 0 && x.Tipo == 1 && x.TipoEstado == 1
                              select new cEsquema
                              {
                                  Nombre = x.Nombre,
                                  Abreviatura = x.Abreviatura,
                                  EsquemaID = x.EsquemaID,
                                  EsquemaIDPadre = x.EsquemaIDPadre,
                                  Tipo = x.Tipo,
                                  Orden = x.Orden,
                                  TipoEstado = x.TipoEstado,
                                  NivelHijo = x.Nivel.ToString(),
                                  Clasificacion = x.Clasificacion,
                                  Clave = x.Clave

                              }).ToList();

                foreach (cEsquema esq in padres)
                {
                    //Se busca sobre los padres sí tiene hijos
                    obtenerHijos(esq, esq.NivelHijo);
                }
                return Json(padres);
            //}
        }

        //Obtener los Modulos Activos
        [HttpGet]
        [ActionName("ObtenerModulos")]
        public IHttpActionResult ObtenerModulos()
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                var Modulos = (
                from M in db.ModuloMovDetalle
                where M.TipoEstado == 1 && M.Baja == false && (M.TipoIndice == 9 || M.TipoIndice == 22 || M.TipoIndice == 26)
                select new { M.ModuloMovDetalleClave, M.Nombre, M.TipoEstado, M.Orden, M.TipoIndice }
                         ).ToList();
                return Json(Modulos);
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Segunda Pestaña
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Obtener las subempresas
        [HttpGet]
        [ActionName("ObtenerSubEmpresa")]
        public IHttpActionResult ObtenerSubEmpresa()
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                var SubEmpresas = (
                from S in db.SubEmpresa
                where S.TipoEstado == 1
                select new { S.NombreCorto, S.SubEmpresaId }
                         ).ToList();
                return Json(SubEmpresas);
            }
        }

        //Obtener los Productos
        [HttpGet]
        [ActionName("ObtenerProductos")]
        public IHttpActionResult ObtenerProductos()
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                var Productos = (
                from P in db.Producto
                join PE in db.ProductoEsquema on new { Clave = P.ProductoClave } equals new { Clave = PE.ProductoClave }
                where (P.Tipo != 5 && P.TipoFase == 1)
                select new { P.ProductoClave, P.Nombre, P.SubEmpresaID, EsquemaID = "", Estado = "0", Checked = false, Cantidad = 0 }

                //from P in db.Producto
                //join PE in db.ProductoEsquema on new { Clave = P.ProductoClave } equals new { Clave = PE.ProductoClave}
                //join PP in db.PromocionProducto on new { Clave = PE.ProductoClave, Promocion = Clave} equals new { Clave = PP.ProductoClave, Promocion = PP.PromocionClave} into details
                //from d in details.Where( a => a.ProductoClave == P.ProductoClave).DefaultIfEmpty()
                //where (P.Tipo != 5 && P.TipoFase == 1)
                //select new { P.ProductoClave, P.Nombre, P.SubEmpresaID, PE.EsquemaID, Estado = "0", d.Cantidad }
                         ).Distinct().ToList();
                return Json(Productos);
            }
        }

        [HttpGet]
        [ActionName("ObtenerProductosE")]
        public IHttpActionResult ObtenerProductosE(string Condicion)
        {   
            //Connection.Open();
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.Append("select * from FNEsquemasProductosCloud('" + Condicion + "')");

            QueryString = sConsulta.ToString();
            List<String> Esquemas = Connection.Query<String>(QueryString).ToList();
            //Connection.Close();

            string[] con = Esquemas.ToArray();
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                var Productos = (
                from P in db.Producto
                join PE in db.ProductoEsquema on new { Clave = P.ProductoClave } equals new { Clave = PE.ProductoClave }
                where (P.Tipo != 5 && P.TipoFase == 1 && Esquemas.Contains(PE.EsquemaID))
                select new { P.ProductoClave, P.Nombre, P.SubEmpresaID/*, PE.EsquemaID*/, EsquemaID = "", Estado = "0", Checked = false, Cantidad = 0 }

                //from P in db.Producto
                //join PE in db.ProductoEsquema on new { Clave = P.ProductoClave } equals new { Clave = PE.ProductoClave}
                //join PP in db.PromocionProducto on new { Clave = PE.ProductoClave, Promocion = Clave} equals new { Clave = PP.ProductoClave, Promocion = PP.PromocionClave} into details
                //from d in details.Where( a => a.ProductoClave == P.ProductoClave).DefaultIfEmpty()
                //where (P.Tipo != 5 && P.TipoFase == 1)
                //select new { P.ProductoClave, P.Nombre, P.SubEmpresaID, PE.EsquemaID, Estado = "0", d.Cantidad }
                         ).Distinct().ToList();
                return Json(Productos);
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Tercera Pestaña
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Editar Promoción
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Obtener datos de la promocion seleccionada
        [HttpGet]
        [ActionName("CargarPromocion")]
        public IHttpActionResult CargarPromocion(string Clave)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                var Promocion = (
                    from Pr in db.Promocion
                    where Pr.PromocionClave == Clave
                    select new { Pr.PromocionClave, Pr.TipoEstado, Pr.Nombre, Pr.Obligatoria, Pr.FechaInicial, Pr.FechaFinal, Pr.Tipo, Pr.TipoAplicacion, Pr.TipoRegla,
                                 Pr.PermiteCascada, Pr.TipoRango, Pr.SeleccionProducto, Pr.CapturaCantidad, Pr.PendienteEntrega, Pr.InventarioPromocion, Pr.NoDisminuirProducto, Pr.ValidaMultiplesEsquemas }
                             ).ToList();
                return Json(Promocion);
            }
            //var Promocion = (
            //    from Pr in db.Promocion
            //    where Pr.PromocionClave == Clave
            //    select new { Pr.PromocionClave, Pr.TipoEstado, Pr.Nombre, Pr.Obligatoria, Pr.FechaInicial, Pr.FechaFinal, Pr.Tipo, Pr.TipoAplicacion, Pr.TipoRegla,
            //                 Pr.PermiteCascada, Pr.TipoRango, Pr.SeleccionProducto, Pr.CapturaCantidad, Pr.PendienteEntrega, Pr.InventarioPromocion, Pr.NoDisminuirProducto, Pr.ValidaMultiplesEsquemas }
            //             ).ToList();
            //return Json(Promocion);
        }

        [HttpGet]
        [ActionName("CargarPromocionDetalle")]
        public IHttpActionResult CargarPromocionDetalle(string Clave)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                var PromocionDetalle = (
                from Pr in db.PromocionDetalle
                join E in db.Esquema on Pr.EsquemaID equals E.EsquemaID
                where Pr.PromocionClave == Clave
                select new
                {
                    E.Clave,
                    E.Nombre,
                    Pr.EsquemaID,
                    Pr.TipoEstado,
                }
                         ).ToList();
                return Json(PromocionDetalle);
            }
        }

        [HttpGet]
        [ActionName("CargarPromocionModulo")]
        public IHttpActionResult CargarPromocionModulo(string Clave)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                var PromocionModulo = (
                from Pr in db.PromocionModulo
                join E in db.ModuloMovDetalle on Pr.ModuloMovDetalleClave equals E.ModuloMovDetalleClave
                where Pr.PromocionClave == Clave
                select new
                {
                    E.ModuloMovDetalleClave,
                    E.Nombre,
                    Pr.AplicaDescuento,
                    Pr.TipoEstado,
                }
                         ).ToList();
                return Json(PromocionModulo);
            }
        }

        [HttpGet]
        [ActionName("CargarPromocionProducto")]
        public IHttpActionResult CargarPromocionProducto(string Clave)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                var PromocionProducto = (
                from Pr in db.PromocionProducto
                where Pr.PromocionClave == Clave
                select new
                {
                    Pr.PromocionClave,
                    Pr.ProductoClave,
                    Pr.Cantidad,
                    Pr.Jerarquia,
                    Pr.TipoEstado,
                }
                         ).ToList();
                return Json(PromocionProducto);
            }
        }

        [HttpGet]
        [ActionName("CargarPromocionRegla")]
        public IHttpActionResult CargarPromocionRegla(string Clave)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                var PromocionRegla = (
                from Pr in db.PromocionRegla
                where Pr.PromocionClave == Clave
                select new
                {
                    Pr.PromocionClave,
                    Pr.PromocionReglaID,
                    Pr.PrecioClave,
                    Pr.Minimo,
                    Pr.Maximo,
                    Pr.Porcentaje,
                    Pr.Importe,
                    Pr.Cantidad,
                    Pr.AplicacionMinima
                }
                         ).ToList();
                return Json(PromocionRegla);
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Guardar datos de la promocion seleccionada
        [HttpPost]
        public bool GuardarPromocion(Promocion promocion)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                Promocion cPromocion;
                var nuevo = !db.Promocion.ToList().Exists(x => x.PromocionClave == promocion.PromocionClave);
                if (nuevo)
                {
                    cPromocion = new Promocion();
                    cPromocion.PromocionClave = promocion.PromocionClave;
                }
                else
                {
                    cPromocion = db.Promocion.ToList().First(x => x.PromocionClave == promocion.PromocionClave);
                }
                cPromocion.TipoEstado = promocion.TipoEstado;
                cPromocion.Nombre = promocion.Nombre;
                cPromocion.Obligatoria = promocion.Obligatoria;
                cPromocion.FechaInicial = promocion.FechaInicial;
                cPromocion.FechaFinal = promocion.FechaFinal;
                cPromocion.Tipo = promocion.Tipo;
                cPromocion.TipoAplicacion = promocion.TipoAplicacion;
                cPromocion.TipoRegla = promocion.TipoRegla;
                cPromocion.PermiteCascada = promocion.PermiteCascada;
                cPromocion.TipoRango = promocion.TipoRango;
                cPromocion.SeleccionProducto = promocion.SeleccionProducto;
                cPromocion.CapturaCantidad = promocion.CapturaCantidad;
                cPromocion.PendienteEntrega = promocion.PendienteEntrega;
                cPromocion.InventarioPromocion = promocion.InventarioPromocion;
                cPromocion.NoDisminuirProducto = promocion.NoDisminuirProducto;
                cPromocion.ValidaMultiplesEsquemas = promocion.ValidaMultiplesEsquemas;
                cPromocion.MFechaHora = DateTime.Now;
                cPromocion.MUsuarioID = promocion.MUsuarioID;
                if (nuevo)
                {
                    db.Promocion.Add(cPromocion);
                }

                PromocionProducto cPromocionProducto;
                foreach (PromocionProducto promocionP in promocion.PromocionProducto)
                {
                    nuevo = !db.PromocionProducto.ToList().Exists(x => x.PromocionClave == promocion.PromocionClave && x.ProductoClave == promocionP.ProductoClave);
                    if (nuevo)
                    {
                        cPromocionProducto = new PromocionProducto();
                        cPromocionProducto.PromocionClave = promocion.PromocionClave;
                    }
                    else
                    {
                        cPromocionProducto = db.PromocionProducto.ToList().First(x => x.PromocionClave == promocion.PromocionClave && x.ProductoClave == promocionP.ProductoClave);
                    }
                    cPromocionProducto.ProductoClave = promocionP.ProductoClave;
                    cPromocionProducto.Cantidad = promocionP.Cantidad;
                    cPromocionProducto.Jerarquia = promocionP.Jerarquia;
                    cPromocionProducto.TipoEstado = promocionP.TipoEstado;
                    cPromocionProducto.MFechaHora = DateTime.Now;
                    cPromocionProducto.MUsuarioID = promocion.MUsuarioID;
                    if (nuevo && cPromocionProducto.PromocionClave != "")
                    {
                        db.PromocionProducto.Add(cPromocionProducto);
                    }
                }
                try
                {
                    db.SaveChanges();
                    Console.WriteLine("Exitoso");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                    {
                        // Get entry

                        DbEntityEntry entry = item.Entry;
                        string entityTypeName = entry.Entity.GetType().Name;

                        // Display or log error messages

                        foreach (DbValidationError subItem in item.ValidationErrors)
                        {
                            string message = string.Format("Error '{0}' occurred in {1} at {2}",
                            subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                            Console.WriteLine(message);
                        }
                    }
                    return false;
                }
                return true;
            }
        }

        //Guardar datos de la promocion seleccionada
        [HttpPost]
        public bool GuardarPromocionD(PromocionDetalle promocionD)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                //Esquemas Clientes
                PromocionDetalle cPromocionDetalle;
                var nuevo = !db.PromocionDetalle.ToList().Exists(x => x.PromocionClave == promocionD.PromocionClave && x.EsquemaID == promocionD.EsquemaID);
                if (nuevo)
                {
                    cPromocionDetalle = new PromocionDetalle();
                    cPromocionDetalle.PromocionClave = promocionD.PromocionClave;
                }
                else
                {
                    cPromocionDetalle = db.PromocionDetalle.ToList().First(x => x.PromocionClave == promocionD.PromocionClave && x.EsquemaID == promocionD.EsquemaID);
                }
                cPromocionDetalle.EsquemaID = promocionD.EsquemaID;
                cPromocionDetalle.TipoEstado = promocionD.TipoEstado;
                cPromocionDetalle.MFechaHora = DateTime.Now;
                cPromocionDetalle.MUsuarioID = promocionD.MUsuarioID;
                if (nuevo && cPromocionDetalle.PromocionClave != "")
                {
                    db.PromocionDetalle.Add(cPromocionDetalle);
                }
                try
                {
                    db.SaveChanges();
                    Console.WriteLine("Exitoso");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                    {
                        // Get entry

                        DbEntityEntry entry = item.Entry;
                        string entityTypeName = entry.Entity.GetType().Name;

                        // Display or log error messages

                        foreach (DbValidationError subItem in item.ValidationErrors)
                        {
                            string message = string.Format("Error '{0}' occurred in {1} at {2}",
                            subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                            Console.WriteLine(message);
                        }
                    }
                    return false;
                }
                return true;
            }
        }

        //Guardar datos de la promocion seleccionada
        [HttpPost]
        public bool GuardarPromocionM(PromocionModulo promocionM)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                //Esquemas Clientes
                PromocionModulo cPromocionModulo;
                var nuevo = !db.PromocionModulo.ToList().Exists(x => x.PromocionClave == promocionM.PromocionClave && x.ModuloMovDetalleClave == promocionM.ModuloMovDetalleClave);
                if (nuevo)
                {
                    cPromocionModulo = new PromocionModulo();
                    cPromocionModulo.PromocionClave = promocionM.PromocionClave;
                }
                else
                {
                    cPromocionModulo = db.PromocionModulo.ToList().First(x => x.PromocionClave == promocionM.PromocionClave && x.ModuloMovDetalleClave == promocionM.ModuloMovDetalleClave);
                }
                cPromocionModulo.ModuloMovDetalleClave = promocionM.ModuloMovDetalleClave;
                cPromocionModulo.TipoEstado = promocionM.TipoEstado;
                cPromocionModulo.AplicaDescuento = promocionM.AplicaDescuento;
                cPromocionModulo.MFechaHora = DateTime.Now;
                cPromocionModulo.MUsuarioID = promocionM.MUsuarioID;
                if (nuevo && cPromocionModulo.PromocionClave != "")
                {
                    db.PromocionModulo.Add(cPromocionModulo);
                }
                try
                {
                    db.SaveChanges();
                    Console.WriteLine("Exitoso");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                    {
                        // Get entry

                        DbEntityEntry entry = item.Entry;
                        string entityTypeName = entry.Entity.GetType().Name;

                        // Display or log error messages

                        foreach (DbValidationError subItem in item.ValidationErrors)
                        {
                            string message = string.Format("Error '{0}' occurred in {1} at {2}",
                            subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                            Console.WriteLine(message);
                        }
                    }
                    return false;
                }
                return true;
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}