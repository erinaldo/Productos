using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using log4net;
using SellingWS.Models;
using SellingWS.Models.API;
using SellingWS.Models.RawQuery;
using SellingWS.Resources;
using SellingWS.Security;

namespace SellingWS.Controllers
{
    /// <summary>
    /// Controlador de Productos
    /// </summary>
    public class ProductoController : ApiController
    {
        private SellingEntities db = new SellingEntities();
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region CONSTANTES

            private readonly int TGrupoFamilia = 2;
            private readonly int TClasificacionProducto = 3;
            private readonly int TGrupoFamiliaTC = 1;

        #endregion

        // GET api/Producto/UbicacionesInventario
        /// <summary>
        /// Ubicaciones en las que existe Producto.
        /// </summary>
        /// <param name="id">El identificador del Producto.</param>
        /// <param name="ALMClave">Clave del Almacén.</param>
        /// <returns>ApiUbicacionInventario</returns>
        [HttpGet]
        public IEnumerable<ApiUbicacionInventario> UbicacionesInventario(string id, string ALMClave)
        {
            Producto producto = db.Producto.SingleOrDefault(p=> 
                p.Baja == false &&
                p.Clave.Replace("-", "") == id.Replace("-", "") || 
                p.NumParte == id ||
                p.Alterno1 == id ||
                p.Alterno2 == id ||
                p.Alterno3 == id ||
                p.ProductoUnidad.Any(x => x.GTIN == id && x.Factor == 1)
            );
            if (producto == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Recibo_Producto_NotFound));
            }

            IEnumerable<ApiUbicacionInventario> ubicaciones = from u in db.Ubicacion
                                                              join peu in db.prd_exist_uba
                                                                on new { u.UBCClave, producto.PROClave, u.Baja } equals new { peu.UBCClave, peu.PROClave, Baja = (bool?)false }
                                                              where peu.Existencia > 0
                                                              join e in db.Estructura
                                                                on new { u.ESTClave, Baja = (bool?)false } equals new { e.ESTClave, e.Baja }
                                                              where e.ALMClave == ALMClave
                                                              select new ApiUbicacionInventario
                                                              {
                                                                  UBCClave = u.UBCClave,
                                                                  Nombre = u.Ubicacion1,
                                                                  Estado = peu.Estado,
                                                                  Existencia = peu.Existencia,
                                                                  Apartado = peu.Apartado,
                                                                  Bloqueado = peu.Bloqueado
                                                              };

            return ubicaciones;
        }

        // GET api/Producto/VerificaUbicacionCambioEstado
        /// <summary>
        /// Detalles del producto en una ubicacion
        /// </summary>
        /// <param name="UBCClave">Clave de la ubicacion.</param>
        /// <param name="PROClave">Clave del producto.</param>
        /// <param name="ALMClave">Clave del Almacén.</param>
        /// <returns>ApiProductoInventario</returns>
        [HttpGet]
        public ApiProductoInventario VerificaUbicacionCambioEstado(string UBCClave, string PROClave, string ALMClave)
        {
            ApiProductoInventario producto = (
                from p in db.Producto
                where   p.Baja == false && 
                        (p.Clave.Replace("-", "") == PROClave.Replace("-", "") ||
                        p.NumParte.Replace("-", "") == PROClave.Replace("-", "") ||
                        p.Alterno1.Replace("-", "") == PROClave.Replace("-", "") ||
                        p.Alterno2.Replace("-", "") == PROClave.Replace("-", "") ||
                        p.Alterno3.Replace("-", "") == PROClave.Replace("-", "") ||
                        p.ProductoUnidad.Any(x => x.GTIN.Replace("-", "") == PROClave.Replace("-", "") && x.Factor == 1))
                join peu in db.prd_exist_uba
                    on p.PROClave equals peu.PROClave
                where peu.Existencia > 0
                join u in db.Ubicacion
                    on new { peu.UBCClave, Ubicacion1 = UBCClave.Replace("-", ""), Baja = (bool?)false } equals new { u.UBCClave, Ubicacion1 = u.Ubicacion1.Replace("-", ""), u.Baja }
                join e in db.Estructura
                    on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                select new ApiProductoInventario
                {
                    PROClave = p.Clave,
                    Nombre = p.Nombre,
                    Estado = peu.Estado,
                    Existencia = peu.Existencia,
                    Apartado = peu.Apartado,
                    Bloqueado = peu.Bloqueado
                }
            ).FirstOrDefault();

            if (producto == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.CambioEstado_Ubicacion_NotFound2));

            return producto;
        }

        // GET api/Producto/VerificaOrigenAlmacenaje
        /// <summary>
        /// Que un Producto en una Ubicacion pueda ser considerado para Almacenaje.
        /// </summary>
        /// <param name="ALMClave">Clave del Almacén.</param>
        /// <param name="UBCClave">Clave de la ubicacion.</param>
        /// <param name="PROClave">Clave del producto.</param>
        /// <param name="cantidad">Cantidad de producto.</param>
        /// <returns>ApiProductoInventario</returns>
        [HttpGet]
        public ApiProductoInventarioHuella VerificaOrigenAlmacenaje(string ALMClave, string UBCClave, string PROClave, decimal cantidad)
        {
            var origen = (
                from p in db.Producto
                where   p.Baja == false &&
                        (p.Clave.Replace("-", "") == PROClave.Replace("-", "") ||
                        p.NumParte.Replace("-", "") == PROClave.Replace("-", "") ||
                        p.Alterno1.Replace("-", "") == PROClave.Replace("-", "") ||
                        p.Alterno2.Replace("-", "") == PROClave.Replace("-", "") ||
                        p.Alterno3.Replace("-", "") == PROClave.Replace("-", "") ||
                        p.ProductoUnidad.Any(x => x.GTIN.Replace("-", "") == PROClave.Replace("-", "") && x.Factor == 1))
                join peu in db.prd_exist_uba
                    on p.PROClave equals peu.PROClave
                where peu.Existencia > 0
                join u in db.Ubicacion
                    on new { peu.UBCClave, Ubicacion1 = UBCClave.Replace("-", ""), Baja = (bool?)false } equals new { u.UBCClave, Ubicacion1 = u.Ubicacion1.Replace("-", ""), u.Baja }
                join e in db.Estructura
                    on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                select new
                {
                    Producto = new ApiProductoInventarioHuella
                    {
                        PROClave = p.Clave,
                        Nombre = p.Nombre,
                        Estado = peu.Estado,
                        Existencia = peu.Existencia,
                        Apartado = peu.Apartado,
                        Bloqueado = peu.Bloqueado,
                        //3.3 Si el material existe se verificara que tenga la huella completa
                        Huella = p.ProductoUnidad.Any(pu => pu.Factor == 1 && pu.Volumen != null)
                    },
                    Estructura = e,
                    PEU = peu
                }
            ).SingleOrDefault();

            //3.1 Valida que el material exista dentro de la ubicación, de lo contrario enviara mensaje de que el material no existe en la ubicación.
            if (origen == null || origen.Producto == null || origen.PEU == null || origen.PEU.Existencia <= 0 || origen.Estructura == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Almacenaje_Producto_NotFound));

            //3 Validara que la cantidad a mover no sea mayor que (Existencia – Apartado – Bloqueado) de lo contrario enviar error.
            if (origen.Estructura.TESTClave != 3 && cantidad > origen.PEU.Existencia - origen.PEU.Apartado - origen.PEU.Bloqueado)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Almacenaje_Producto_NoContent4));

            //C 2.4 Si la ubicación es de tipo Stage valida que la ubicación que tenga existencia de producto disponible (Existencia > Apartado + Bloqueado)
            if (origen.Estructura.TESTClave == 2 && origen.PEU.Existencia <= origen.PEU.Apartado + origen.PEU.Bloqueado)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Almacenaje_Ubicacion_NoContent3));
            
            //C 2.5 Si la ubicación es tipo Transito, podrá mover el producto aunque este se encuentre bloqueado ya que su naturaleza es que siempre esta bloqueado.
            if (origen.Estructura.TESTClave != 3 && origen.PEU.Estado == 0)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Almacenaje_Ubicacion_NoContent4));

            return origen.Producto;
        }

        // GET api/Producto/VerificaReubicacion
        /// <summary>
        /// Si un producto en una ubicación puede ser reubicado
        /// </summary>
        /// <param name="ALMClave">Clave del Almacén</param>
        /// <param name="UBCClave">Clave de la ubicacion</param>
        /// <param name="PROClave">Clave del producto</param>
        /// <returns>ApiProductoInventario</returns>
        [HttpGet]
        public ApiProductoInventario VerificaReubicacion(string ALMClave, string UBCClave, string PROClave)
        {
            ApiProductoInventario producto = (
                from p in db.Producto
                where p.Baja == false &&
                      (p.Clave.Replace("-", "") == PROClave.Replace("-", "") ||
                      p.NumParte.Replace("-", "") == PROClave.Replace("-", "") ||
                      p.Alterno1.Replace("-", "") == PROClave.Replace("-", "") ||
                      p.Alterno2.Replace("-", "") == PROClave.Replace("-", "") ||
                      p.Alterno3.Replace("-", "") == PROClave.Replace("-", "") ||
                      p.ProductoUnidad.Any(x => x.GTIN.Replace("-", "") == PROClave.Replace("-", "") && x.Factor == 1))
                join peu in db.prd_exist_uba
                    on p.PROClave equals peu.PROClave
                where peu.Existencia > 0
                join talla in db.ValorRef
                            on p.Talla equals talla.Valor
                where talla.Campo == "Talla" && talla.Tabla == "Producto"
                join u in db.Ubicacion
                    on new { peu.UBCClave, Ubicacion1 = UBCClave.Replace("-", ""), Baja = (bool?)false } equals new { u.UBCClave, Ubicacion1 = u.Ubicacion1.Replace("-", ""), u.Baja }
                join e in db.Estructura
                    on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                select new ApiProductoInventario
                {
                    PROClave = p.Clave,
                    Nombre = p.Nombre,
                    Estado = peu.Estado,
                    Existencia = peu.Existencia,
                    Apartado = peu.Apartado,
                    Bloqueado = peu.Bloqueado,
                    Talla = talla.Descripcion 
                }
            ).FirstOrDefault();

            if (producto == null || producto.Existencia <= 0)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Reubicacion_Material_NotFound));

            //D 3. Valida que la cantidad a reubicar sea menor o igual  a la cantidad disponible en la ubicación (Existencia – Apartado – Bloqueado) 
            if (producto.Existencia - producto.Apartado - producto.Bloqueado<=0)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Reubicacion_UbicacionDestino_NoContent3));

            //return Request.CreateResponse(HttpStatusCode.OK);
            return producto;
        }

        // GET api/Producto/VerificaRecibo
        /// <summary>
        /// Verifica si un producto está en una ubicación de recibo y las cantidades recibidas
        /// </summary>
        /// <param name="IdRecibo">Identificador del Recibo</param>
        /// <param name="PROClave">Clave del producto</param>
        /// <param name="cantidad">Cantidad recibida del producto</param>
        /// <returns>ApiProductoInventario</returns>
        [HttpGet]
        public HttpResponseMessage VerificaRecibo(string IdRecibo,string PROClave, double cantidad)
        {
            string mensaje = "";

            if(cantidad<=0)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Recibo_Cantidad_Incorrecta));

            var producto = (
                from ra in db.ReciboAlmacen
                where ra.IdRecibo == IdRecibo
                join rad in db.ReciboAlmacenD
                    on ra.IdRecibo equals IdRecibo
                join p in db.Producto
                    on new { rad.PROClave, Baja = (bool?)false } equals new { p.PROClave, p.Baja }
                where   p.Clave.Replace("-", "") == PROClave.Replace("-", "") ||
                        p.NumParte == PROClave ||
                        p.Alterno1 == PROClave ||
                        p.Alterno2 == PROClave ||
                        p.Alterno3 == PROClave ||
                        p.ProductoUnidad.Any(x => x.GTIN == PROClave && x.Factor == 1)
                join estra in db.Estrategia
                    on p.PROClave equals estra.PROClave into joined //left join
                from j in joined.DefaultIfEmpty()
                select new
                {
                    ra.ALMClave,
                    PROClave = p.Clave,
                    p.TProducto,
                    ra.Anden,
                    p.Nombre,
                    p.Descripcion,
                    p.Num_Decimales,
                    rad.Cantidad,
                    rad.Recibido,
                    AreaPicking = j.Area.Nombre,
                    UbicacionPicking = j.Ubicacion.Ubicacion1,
                    ra.Estado
                }
            ).ToArray();

            //2.1 Si no se encuentra alguna coincidencia enviara mensaje de que No se encontró coincidencia en el sistema
            if (producto == null || !producto.Any())
                mensaje = Mensajes.Recibo_Material_NotFound;
                //throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Recibo_Material_NotFound));

            //2.2 Si el material existe, se validara que se encuentre dentro del detalle de la orden de ReciboAlmacenD y que la cantidad recibida sea menor a la solicitada(cantidad)
            /****
             * se movió esta validación al servicio 
            ****/

            //2.3 Se valida que la cantidad de decimales no sea mayor al parametro de Num_Decimales en la tabla Producto
            if (mensaje == "")
            {
                var decimales = producto.FirstOrDefault().Num_Decimales;
                if (decimales == 0)
                {
                    bool esEntero = cantidad % 1 == 0;
                    if (!esEntero)
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.General_No_Decimales));
                }
                else if (decimales > 0)
                {
                    var strDecimal = cantidad.ToString().Split('.');
                    var cantidadDecimales = 0;
                    if (strDecimal.Length > 1)
                    {
                        cantidadDecimales = strDecimal[1].Length;
                    }

                    if (cantidadDecimales > decimales)
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format(Mensajes.General_Mayor_Decimales, decimales)));
                }

                //Si el recibo ya no está en Proceso (Estado == 1) regresar error
                if (producto.Any(x => x.Estado != 1))
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.OK, new { enProceso = false }));
            }
            else
            {
                decimal codigo;
                if (PROClave.Length >= 14 && decimal.TryParse(PROClave.Substring(PROClave.Length - 12, 12), out codigo))
                {
                    var sucursal = (from ra in db.ReciboAlmacen
                                    where ra.IdRecibo == IdRecibo
                                    join alm in db.Almacen
                                        on new { ra.ALMClave } equals new { alm.ALMClave }
                                    join suc in db.Sucursal
                                        on new { alm.SUCClave, Baja = (bool?)false } equals new { suc.SUCClave, suc.Baja }
                                    select new
                                    {
                                        suc.Clave
                                    }).FirstOrDefault();

                    if (sucursal != null)
                    {
                        if (sucursal.Clave != PROClave.Substring(0, PROClave.Length - 12))
                            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Paquete_Sucursal_Incorrecto));
                        else
                        {
                            List<PaqueteDetalle> paqueteDetalle = db.Database.SqlQuery<PaqueteDetalle>(
                                   "select pd.PROClave, pd.Cantidad from PaqueteDetalle pd inner join Paquete p on p.IdPaquete = pd.IdPaquete " +
                                   "and p.IdPaquete=@IdPaquete and p.Estado=1 and Baja=0",
                                   new SqlParameter("@IdPaquete", PROClave)
                                    ).ToList();

                            foreach (PaqueteDetalle paqDet in paqueteDetalle)
                            {
                                var reciboDet = (from ra in db.ReciboAlmacen
                                                 where ra.IdRecibo == IdRecibo
                                                 join rad in db.ReciboAlmacenD
                                                        on new { ra.IdRecibo, PROClave = PROClave, Cantidad = (decimal?)cantidad } equals new { IdRecibo, rad.PROClave, rad.Cantidad }
                                                 select new
                                                 {
                                                     rad.PROClave,
                                                     rad.Cantidad
                                                 });
                                if (reciboDet == null)
                                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Contenido_Paquete_Invalido));
                            }
                        }
                    }
                    else
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Paquete_Sucursal_Incorrecto));

                    return Request.CreateResponse(HttpStatusCode.OK, PROClave);

                }
            }
            //mostrara la clave de material,  el nombre y  el área de la ubicación de picking que tiene asignada
            return Request.CreateResponse(HttpStatusCode.OK, producto.Select(x=> new ApiProductoVerificaReciboResponse
            {
                PROClave = x.PROClave,
                Descripcion = x.Descripcion,
                AreaPicking = x.AreaPicking,
                UbicacionPicking = x.UbicacionPicking,
                Nombre = x.Nombre
            }).First());

        }

        // GET api/Producto/MotivoSobrante
        /// <summary>
        /// Registra un Motivo para un evento de Sobrante de Material
        /// </summary>
        /// <param name="idReciboSobrante">Identificador del ReciboSobrante</param>
        /// <param name="MotivoSobrante">Motivo del sobrante (ValorRef)</param>
        /// <returns>ApiProductoInventario</returns>
        [HttpGet]
        public HttpResponseMessage MotivoSobrante(string idReciboSobrante, int MotivoSobrante)
        {
            if (!db.ValorRef.Any(x=>x.Valor == MotivoSobrante))
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Recibo_Producto_MotivoSobrante_NotFound));

            try {
                ReciboSobrante reciboSobrante = db.ReciboSobrante.Find(idReciboSobrante);
                if (reciboSobrante == null)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Recibo_Producto_ReciboSobrante_NotFound));

                reciboSobrante.MotivoSobrante = MotivoSobrante;

                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.General_Error));
            }
        }

        // POST api/Producto/MoverProductoReubicacion
        /// <summary>
        /// Reubica un producto, de UbicaciónOrigen a UbicaciónDestino
        /// </summary>
        /// <param name="requestData">COMClave=Clave de la Compania, SUCClave = Clave de la Sucursal,ALMClave = Clave del Almacen,origenUBCClave = Clave Ubicacion origen, destinoUBCClave = Clave Ubicacion destino, PROClave = Clave del Producto, cantidad = Cantidad a reubicar</param>
        /// <returns>Double</returns>
        [HttpPost]
        public decimal? MoverProductoReubicacion([FromBody]ApiProductoMoverRequest requestData)
        {
           string[] productoArray = requestData.PROClave.Split(',');
           string[] cantidadArray = requestData.cantString.Split(',');

           string usrClave = HttpContext.Current.Items["USRClave"].ToString();
            if (usrClave == null)//Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.General_USRClave_NotFound));

            //4.1 Validara que la ubicación destino leída exista de lo contrario enviara error.
            Ubicacion ubicacionDestino = (
                from u in db.Ubicacion
                where u.Ubicacion1.Replace("-", "") == requestData.destinoUBCClave.Replace("-", "") && u.Baja == false
                join e in db.Estructura
                    on new { u.ESTClave, requestData.ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                join a in db.Almacen
                    on new { e.ALMClave, ALMClave1 = e.ALMClave, Baja = (bool?)false } equals new { requestData.ALMClave, ALMClave1 = a.ALMClave, a.Baja }
                join s in db.Sucursal
                    on new { requestData.SUCClave, SUCClave1 = a.SUCClave, Baja = (bool?)false } equals new { s.SUCClave, SUCClave1 = s.SUCClave, s.Baja }
                select u
            ).Distinct().SingleOrDefault();

            if (ubicacionDestino == null) //Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Reubicacion_UbicacionDestino_NotFound));

            if (ubicacionDestino.Estado == 2)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Almacenaje_Ubicacion_NoContent2));

            var cantidadMovida = ubicacionDestino.Volumen - ubicacionDestino.Volumen;

            for (int i = 0; i < productoArray.Length; i++) { 

                requestData.PROClave = productoArray[i];
                requestData.cantidad = int.Parse(cantidadArray[i]);


                prd_exist_uba peuOrigen = (
                from u in db.Ubicacion
                where u.Ubicacion1.Replace("-", "") == requestData.origenUBCClave.Replace("-", "") && u.Baja == false
                join e in db.Estructura
                    on new { u.ESTClave, requestData.ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                where e.ALMClave == requestData.ALMClave
                join peu in db.prd_exist_uba
                    on u.UBCClave equals peu.UBCClave
                join p in db.Producto
                    on new { peu.PROClave, Baja = (bool?)false } equals new { p.PROClave, p.Baja }
                where peu.Producto.Clave.Replace("-", "") == requestData.PROClave.Replace("-", "") ||
                      peu.Producto.NumParte == requestData.PROClave ||
                      peu.Producto.Alterno1 == requestData.PROClave ||
                      peu.Producto.Alterno2 == requestData.PROClave ||
                      peu.Producto.Alterno3 == requestData.PROClave ||
                      peu.Producto.ProductoUnidad.Any(x => x.GTIN == requestData.PROClave && x.Factor == 1)
                select peu
            ).SingleOrDefault();

                if (peuOrigen == null)//Existe?
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Reubicacion_Material_NotFound +"("+ requestData.PROClave+")"));

                Estructura estructuraDestino = db.Estructura.First(e => e.ESTClave == ubicacionDestino.ESTClave && e.ALMClave == requestData.ALMClave && e.Baja == false);

                //4.2 Si es de tipo Transito(3) o Anden(0) enviara Error.
                if (estructuraDestino.TESTClave == 3 || estructuraDestino.TESTClave == 0)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Reubicacion_UbicacionDestino_NoContent + "(" + requestData.PROClave + ")"));

                prd_exist_uba peuDestino = (
                    from u in db.Ubicacion
                    where u.Ubicacion1.Replace("-", "") == requestData.destinoUBCClave.Replace("-", "") && u.Baja == false
                    join e in db.Estructura
                        on new { u.ESTClave, requestData.ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                    join peu in db.prd_exist_uba
                        on u.UBCClave equals peu.UBCClave
                    join p in db.Producto
                        on new { peu.PROClave, Baja = (bool?)false } equals new { p.PROClave, p.Baja }
                    where p.Clave.Replace("-", "") == requestData.PROClave.Replace("-", "") ||
                          p.NumParte == requestData.PROClave ||
                          p.Alterno1 == requestData.PROClave ||
                          p.Alterno2 == requestData.PROClave ||
                          p.Alterno3 == requestData.PROClave ||
                          p.ProductoUnidad.Any(x => x.GTIN == requestData.PROClave && x.Factor == 1)
                    select peu
                ).FirstOrDefault();

                var disponibleOrigen = peuOrigen.Existencia - peuOrigen.Apartado - peuOrigen.Bloqueado;
                cantidadMovida = disponibleOrigen - requestData.cantidad >= 0 ?
                    requestData.cantidad :
                    disponibleOrigen;

                    /* 4.3 Si es de tipo almacenaje, deberá validar que el producto de esa ubicación pertenezca a la misma familia de material
                    * -y este en la misma área- y tenga volumen disponible.*/
                if (estructuraDestino.TESTClave == 1)
                {
                    //tenga volumen disponible.
                    var volumenOcupar = peuOrigen.Producto.ProductoUnidad.First(x => x.Factor == 1).Volumen * cantidadMovida;
                    VolumenUbicacion volumenUbicacion = db.Database.SqlQuery<VolumenUbicacion>(
                        "select a.AREClave,a.Nombre as Area,u.Ubicacion,u.UBCClave,u.Volumen * (t.Porc_Aprob_Hueco /100) as Volumen,ISNULL((select sum(pe.Existencia * pu.Volumen ) " +
                        "from prd_exist_uba pe   inner join ProductoUnidad pu on pe.UBCClave=u.UBCClave and pe.PROClave=pu.PROClave and pu.Factor=1 and pe.Existencia > 0 and pe.PROClave= @PROClave),0) VolumenOcupado " +
                        "from Estructura e inner join TipoEstructura t on e.Baja = 0 and e.TESTClave=t.TESTClave and t.TESTClave = 1 and e.ALMClave = @ALMClave inner join Ubicacion u on u.Baja = 0 and e.ESTClave=u.ESTClave and u.UBCClave = @Ubicacion inner join Area a on a.Baja = 0 and e.AREClave=a.AREClave",
                        new SqlParameter("@ALMClave", estructuraDestino.ALMClave),
                        new SqlParameter("@PROClave", peuOrigen.PROClave),
                        new SqlParameter("@Ubicacion", ubicacionDestino.UBCClave)
                    ).FirstOrDefault();

                    if (volumenUbicacion != null && volumenUbicacion.Volumen > 0 && volumenUbicacion.Volumen - volumenUbicacion.VolumenOcupado < volumenOcupar)
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Reubicacion_UbicacionDestino_NoContent4 + "(" + requestData.PROClave + ")"));

                    CompanyParam tallaColor = db.CompanyParam.FirstOrDefault
                                        (tc => tc.PARClave == "TallaColor");

                    if (tallaColor == null && tallaColor.Valor == "0")
                    {
                        //Por lo menos un producto del mismo grupo en la ubicacion destino
                        if (ubicacionDestino.prd_exist_uba.Count(u => u.Existencia > 0) > 0 &&
                            !ubicacionDestino.prd_exist_uba.Any(u =>
                                    u.Existencia > 0 &&
                                    u.Producto.ClasProd.Any(cp =>
                                        cp.CLAClave == peuOrigen.Producto.ClasProd.FirstOrDefault(cp1 =>
                                            cp1.Clasificacion.TClasificacion == TClasificacionProducto &&
                                            cp1.Clasificacion.TGrupo == TGrupoFamilia
                                        ).CLAClave &&
                                        cp.Clasificacion.TClasificacion == TClasificacionProducto &&
                                        cp.Clasificacion.TGrupo == TGrupoFamilia
                                    )
                            )
                        )
                        {
                            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Reubicacion_UbicacionDestino_NoContent2 + "(" + requestData.PROClave + ")"));
                        }
                    }
                    /*
                                    //Este en la misma área
                                    if (ubicacionDestino.prd_exist_uba.Count(u => u.Existencia > 0) > 0 && 
                                        !ubicacionDestino.prd_exist_uba.Any(u =>
                                            u.Existencia > 0 &&
                                            u.Producto.Estrategia.Any(cp => cp.AREClave == peuOrigen.Producto.Estrategia.First(x=>x.ALMClave==requestData.ALMClave && x.Ubicacion.Baja==false).AREClave)
                                        )
                                    )
                                    {
                                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Reubicacion_UbicacionDestino_NoContent5));
                                    }
                    */
                }

                //3 Valida que la cantidad a reubicar sea menor o igual  a la cantidad disponible en la ubicación (Existencia – Apartado – Bloqueado) prd_exist_uba

                if (disponibleOrigen <= 0)//hay disponibilidad?
                    //throw new HttpResponseException(HttpStatusCode.NotFound);
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Reubicacion_UbicacionDestino_NoContent3 + "(" + requestData.PROClave + ")"));

                peuOrigen.Existencia -= cantidadMovida;
                peuOrigen.MFechaHora = DateTime.Now;
                peuOrigen.MUsuarioId = usrClave;
                peuOrigen.Bloqueado -= (peuOrigen.Estado == 0) ? cantidadMovida : 0;//Si Origen esta bloqueada restar a peuOrigen.bloqueado

                if (peuDestino != null)
                {

                    peuDestino.Existencia += cantidadMovida;
                    peuDestino.MFechaHora = DateTime.Now;
                    peuDestino.MUsuarioId = usrClave;
                    peuDestino.Bloqueado += (peuDestino.Estado == 0) ? cantidadMovida : 0;//Si Destino esta bloqueada sumar a peuDestino.bloqueado
                }
                else
                {
                    peuDestino = new prd_exist_uba
                    {
                        Apartado = 0,
                        Bloqueado = (ubicacionDestino.Estado == 0) ? cantidadMovida : 0,//Si Destino esta bloqueada agregar a peuDestino.bloqueado
                        Estado = ubicacionDestino.Estado,
                        Existencia = cantidadMovida,
                        PROClave = peuOrigen.PROClave,
                        UBCClave = ubicacionDestino.UBCClave,
                        MFechaHora = DateTime.Now,
                        MUsuarioId = usrClave
                    };

                    db.prd_exist_uba.Add(peuDestino);

                }

                //Modificar la cantidad de bloqueados en Existencia de Almacen
                decimal? diferenciaBloqueados = ((peuDestino.Estado == 0) ? cantidadMovida : 0) - ((peuOrigen.Estado == 0) ? cantidadMovida : 0);
                if (diferenciaBloqueados != null && diferenciaBloqueados != 0)
                {
                    Existencia existenciaAlmacen = db.Existencia.First(x =>
                        x.ALMClave == requestData.ALMClave &&
                        x.PROClave == requestData.PROClave
                    );

                    existenciaAlmacen.Bloqueado += diferenciaBloqueados;
                }

                try
                {
                    //Agregar un MovUbc
                    var nuevaReferencia = insertarMovUbc(
                        requestData.SUCClave,
                        estructuraDestino.ALMClave,
                        peuOrigen.UBCClave,
                        peuDestino.UBCClave,
                        peuOrigen.PROClave,
                        3,
                        13,
                        cantidadMovida,
                        peuDestino.Estado,
                        "MoverProductoReubicacion",
                        usrClave
                    );

                    if (estructuraDestino.TESTClave == 1 && peuOrigen.Estado != peuDestino.Estado)
                    {
                        //Obtengo el path de destino para el archivo de la 

                        CompanyParam path = db.CompanyParam.SingleOrDefault(x => x.COMClave.Equals(requestData.COMClave) && x.PARClave.Equals("InterfazSalida"));

                        //Obtengo el nombre del SP de la interfaz
                        st_recupera_interfaz_Result st_recupera_interfaz_Result_Instance = db.st_recupera_interfaz("CambioEstado", requestData.COMClave).SingleOrDefault();
                        if (st_recupera_interfaz_Result_Instance != null)
                        {
                            String procedimiento = st_recupera_interfaz_Result_Instance.sp;

                            //Ejecuto el SP según st_recupera_interfaz()
                            SqlConnection dbCon = db.Database.Connection as SqlConnection;
                            SqlCommand cmd = new SqlCommand(procedimiento, dbCon);
                            cmd.Parameters.Clear();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("Folio", nuevaReferencia);
                            cmd.Parameters.AddWithValue("TipoDocumento", 0);
                            cmd.Parameters.AddWithValue("Path", path.Valor);
                            cmd.Parameters.AddWithValue("Fecha", DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                            dbCon.Open();
                            cmd.ExecuteNonQuery();
                            dbCon.Close();
                        }
                    }

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, Mensajes.General_Error + "(" + requestData.PROClave + ")"));
                }
            }
            return cantidadMovida;
        }
        
        // POST api/Producto/MoverAlmacenajeNoDirigido
        /// <summary>
        /// Mueve un producto, de una UbicacionTransito a UbicacionAlmacenaje
        /// </summary>
        /// <param name="COMClave">Clave de la Compania.</param>
        /// <param name="SUCClave">Clave de la Sucursal.</param>
        /// <param name="ALMClave">Clave del Almacén.</param>
        /// <param name="UbicacionTransito">Clave de la ubicacion de Tránsito.</param>
        /// <param name="UbicacionAlmacenaje">Clave de la ubicacion de Almacenaje.</param>
        /// <param name="Producto">Clave del producto.</param>>
        /// <param name="cantidad">Cantidad de producto.</param>>
        /// 
        [HttpGet]
        public decimal? MoverAlmacenajeNoDirigido(string COMClave, string SUCClave, string ALMClave, string UbicacionTransito, string UbicacionAlmacenaje, string Producto, decimal cantidad)
        {
            if(cantidad <=0)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Almacenaje_Cantidad_Incorrecta));

            string usrClave = HttpContext.Current.Items["USRClave"].ToString();
            if (usrClave == null)//Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.General_USRClave_NotFound));

            var origen = (
                from u in db.Ubicacion
                where u.Ubicacion1.Replace("-", "") == UbicacionTransito.Replace("-", "") && u.Baja == false
                join est in db.Estructura
                    on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { est.ESTClave, est.ALMClave, est.Baja }
                join a in db.Almacen
                    on new { est.ALMClave, ALMClave1 = est.ALMClave, Baja = (bool?)false } equals new { ALMClave, ALMClave1 = a.ALMClave, a.Baja }
                join s in db.Sucursal
                    on new { SUCClave, SUCClave1 = a.SUCClave, Baja = (bool?)false } equals new { s.SUCClave, SUCClave1 = s.SUCClave, s.Baja }
                join peu in db.prd_exist_uba
                    on u.UBCClave equals peu.UBCClave
                join p in db.Producto
                    on new { peu.PROClave, Baja = (bool?)false } equals new { p.PROClave, p.Baja }
                join exist in db.Existencia
                    on new { p.PROClave, ALMClave } equals new { exist.PROClave, exist.ALMClave }
                where p.Clave.Replace("-", "") == Producto.Replace("-", "") ||
                      p.NumParte == Producto ||
                      p.Alterno1 == Producto ||
                      p.Alterno2 == Producto ||
                      p.Alterno3 == Producto ||
                      p.ProductoUnidad.Any(x => x.GTIN == Producto && x.Factor == 1)
                select new { prd_exist_uba = peu, Estructura = est, Existencia = exist }
            ).Distinct().SingleOrDefault();

            if (origen == null)//Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Almacenaje_UbicacionTransito_NotFound));

            //Si la cantidad a mover no está disponible en el origen
            decimal? disponibleOrigen;
            if (origen.Estructura.TESTClave == 3) //Tránsito
                disponibleOrigen = origen.prd_exist_uba.Existencia - origen.prd_exist_uba.Apartado;
            else
                disponibleOrigen = origen.prd_exist_uba.Existencia - origen.prd_exist_uba.Apartado - origen.prd_exist_uba.Bloqueado;

            if(disponibleOrigen == null || disponibleOrigen - cantidad < 0)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format(Mensajes.Almacenaje_ProductoCantidad_Origen_NotFound,disponibleOrigen)));
            //>Si la cantidad a mover está disponible en el origen

            var destino = (
                from u in db.Ubicacion
                where u.Ubicacion1.Replace("-", "") == UbicacionAlmacenaje.Replace("-", "") && u.Baja == false
                join e in db.Estructura
                    on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                join a in db.Almacen
                    on new { e.ALMClave, ALMClave1 = e.ALMClave, Baja = (bool?)false } equals new { ALMClave, ALMClave1 = a.ALMClave, a.Baja }
                join s in db.Sucursal
                    on new { SUCClave, SUCClave1 = a.SUCClave, Baja = (bool?)false } equals new { s.SUCClave, SUCClave1 = s.SUCClave, s.Baja }
                select new {
                    Ubicacion = u,
                    Estructura = e
                }
            ).Distinct().SingleOrDefault();

            //C 4.3.2 Validara que la ubicación destino leída exista
            if (destino == null || destino.Ubicacion == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Almacenaje_UbicacionAlmacenaje_NotFound));

            //C 4.3.2 Validara que la ubicación destino no este bloqueada
            if(destino.Ubicacion.Estado == 0)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Almacenaje_UbicacionAlmacenaje_Bloqueada));

            prd_exist_uba origenPeu = origen.prd_exist_uba; //
            prd_exist_uba destinoPeu; //

            //C 4.3.4 Si es una ubicación asignada a picking pero para un material diferente enviar error.
            Estrategia estrategia = db.Estrategia.Include("Ubicacion").Where(
                x=> x.ALMClave == ALMClave && x.UBCClave == destino.Ubicacion.UBCClave && destino.Ubicacion.Baja == false && x.PROClave == origen.prd_exist_uba.PROClave
            ).SingleOrDefault();
            if (estrategia != null)
            {
                prd_exist_uba peuDestino = estrategia.Ubicacion.prd_exist_uba.FirstOrDefault(x => x.PROClave == origen.prd_exist_uba.PROClave);

                if (peuDestino == null && cantidad > estrategia.Capacidad)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format(Mensajes.Almacenaje_ProductoCantidad_Destino_NotFound, estrategia.Capacidad - cantidad)));
                else if (peuDestino != null && (peuDestino.Existencia + cantidad) > estrategia.Capacidad)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format(Mensajes.Almacenaje_ProductoCantidad_Destino_NotFound, estrategia.Capacidad - (peuDestino.Existencia + cantidad))));
                
                destinoPeu = peuDestino;
            }
            else
            {
                //C 4.3.4 si es una ubicación de tipo almacenaje y el producto contenido pertenece a una Familia diferente
                if (
                    destino.Estructura.TESTClave == 3 && 
                    !destino.Ubicacion.prd_exist_uba.Any(
                        x => x.Existencia > 0 && x.Producto.ClasProd.Any(
                            cp => cp.CLAClave == origen.prd_exist_uba.Producto.ClasProd.First(
                                cp1 => cp1.Clasificacion.TClasificacion == TClasificacionProducto && cp1.Clasificacion.TGrupo == TGrupoFamilia
                            ).CLAClave && cp.Clasificacion.TClasificacion == TClasificacionProducto && cp.Clasificacion.TGrupo == TGrupoFamilia
                        )
                    )
                )
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Almacenaje_UbicacionAlmacenaje_DiferenteGrupo));
                //>C 4.3.4 si es una ubicación de tipo almacenaje y el producto contenido pertenece a un grupo de material diferente


                //C 4.3.5 Si el volumen disponible no es suficiente enviar error.
                decimal? volumenOcupar = origen.prd_exist_uba.Producto.ProductoUnidad.First(x => x.Factor == 1).Volumen * cantidad;

                VolumenUbicacion volumenUbicacion = db.Database.SqlQuery<VolumenUbicacion>(
                    "select a.AREClave,a.Nombre as Area,u.UBCClave,u.Ubicacion,u.Volumen * (t.Porc_Aprob_Hueco /100) as Volumen,ISNULL((select sum(pe.Existencia * pu.Volumen ) " +
                    "from prd_exist_uba pe inner join ProductoUnidad pu on pe.UBCClave=u.UBCClave and pe.PROClave=pu.PROClave and pu.Factor=1 and pe.Existencia > 0 and pe.PROClave= @PROClave),0) VolumenOcupado " +
                    "from Estructura e inner join TipoEstructura t on e.Baja = 0 and e.TESTClave=t.TESTClave and e.ALMClave = @ALMClave inner join Ubicacion u on u.Baja = 0 and e.ESTClave=u.ESTClave and u.UBCClave = @Ubicacion inner join Area a on a.Baja = 0 and e.AREClave=a.AREClave",
                    new SqlParameter("@ALMClave", origen.Estructura.ALMClave),
                    new SqlParameter("@PROClave", origen.prd_exist_uba.PROClave),
                    new SqlParameter("@Ubicacion", destino.Ubicacion.UBCClave)
                ).FirstOrDefault();

                if (volumenUbicacion == null || volumenUbicacion.Volumen - volumenUbicacion.VolumenOcupado < volumenOcupar && volumenUbicacion.Volumen > 0)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Almacenaje_Ubicacion_SobrepasaVolumen));
                //>C 4.3.5 Si el volumen disponible no es suficiente enviar error.

                destinoPeu = destino.Ubicacion.prd_exist_uba.FirstOrDefault(x => x.PROClave == origen.prd_exist_uba.PROClave);

            }
                
            //C 6 se confirma la ubicación  disminuyendo la existencia de la ubicación origen (prd_exist_uba.Existencia)
            origenPeu.Existencia -= cantidad;
            if (origen.Estructura.TESTClave == 3){ //C 6 en caso de que la ubicación origen sea de tipo Transito se disminuye además de la cantidad de piezas bloqueadas.
                origenPeu.Bloqueado -= cantidad;

                Existencia existenciaAlmacen = origen.Existencia;//Si la Estructura de origen es de Transito, modificar cantidad de bloqueados en Existencia
                existenciaAlmacen.Bloqueado -= cantidad;
            }
            origenPeu.MFechaHora = DateTime.Now;
            origenPeu.MUsuarioId = usrClave;

            if (destinoPeu != null)
            {
                destinoPeu.Existencia += cantidad;
                destinoPeu.MFechaHora = DateTime.Now;
                destinoPeu.MUsuarioId = usrClave;
            }
            else
            {
                destinoPeu = new prd_exist_uba
                {
                    Apartado = 0,
                    Bloqueado = 0,
                    Estado = destino.Ubicacion.Estado,
                    Existencia = cantidad,
                    PROClave = origenPeu.PROClave,
                    UBCClave = destino.Ubicacion.UBCClave,
                    MFechaHora = DateTime.Now,
                    MUsuarioId = usrClave
                };

                db.prd_exist_uba.Add(destinoPeu);
            }

            db.SaveChanges();

            try
            {
                //Agregar un MovUbc
                var nuevaReferencia = insertarMovUbc(
                    SUCClave,
                    destino.Estructura.ALMClave,
                    origen.prd_exist_uba.UBCClave,
                    destino.Ubicacion.UBCClave,
                    origen.prd_exist_uba.PROClave,
                    3, //Cambio de Estado
                    14, //Almacenaje
                    cantidad,
                    origenPeu.Estado,
                    "MoverProductoReubicacion",
                    usrClave
                );
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, Mensajes.General_Error));
            }

            return cantidad;
        }

        // POST api/Producto/ModificarProductoEstado
        /// <summary>
        /// Modifica el Estado de un Producto, Bloquear o Desbloquear 
        /// </summary>
        /// <param name="requestData">COMClave = Clave de la compania, SUCClave = Clave de la Sucursal, ALMClave = Clave del Almacén, UBCClave = Clave de la ubicacion, PROClave = Clave del producto, Bloquear = Bloquear o Desbloquear.</param>
        /// <returns>Double</returns>
        [HttpPost]
        public decimal? ModificarProductoEstado([FromBody]ApiProductoCambioEstadoRequest requestData)
        {
            string usrClave = HttpContext.Current.Items["USRClave"].ToString();
            if (usrClave == null)//Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Forbidden, Mensajes.General_USRClave_NotFound));

            //E.1 Solicitara la lectura del la ubicación, valida que exista.
            Ubicacion ubicacion = (
                from u in db.Ubicacion
                where u.Ubicacion1.Replace("-", "") == requestData.UBCClave.Replace("-", "") && u.Baja==false
                join e in db.Estructura
                    on new { u.ESTClave, requestData.ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                join a in db.Almacen
                    on new { e.ALMClave, ALMClave1 = e.ALMClave, Baja = (bool?)false } equals new { requestData.ALMClave, ALMClave1 = a.ALMClave, a.Baja }
                join s in db.Sucursal
                    on new { requestData.SUCClave, SUCClave1 = a.SUCClave, Baja = (bool?)false } equals new { s.SUCClave, SUCClave1 = s.SUCClave, s.Baja }
                select u
            ).Distinct().SingleOrDefault();
            
            if (ubicacion == null) //Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.CambioEstado_Ubicacion_NotFound));

            //Podrá realizar el cambio de estado de un material dentro de una ubicación de cualquier tipo exceptuando las de tipo Transito
            Estructura estructuraDestino = db.Estructura.First(e => e.ESTClave == ubicacion.ESTClave && e.ALMClave == requestData.ALMClave && e.Baja==false);
            if (estructuraDestino.TESTClave == 3)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.CambioEstado_Ubicacion_NoContent));

            //E.2 Solicitara lectura de material, validara que exista dentro de la ubicación.
            prd_exist_uba peuOrigen = (
                from u in db.Ubicacion
                where u.Ubicacion1.Replace("-", "") == requestData.UBCClave.Replace("-", "")
                join e in db.Estructura
                    on new { u.ESTClave, requestData.ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                join peu in db.prd_exist_uba
                    on u.UBCClave equals peu.UBCClave
                join p in db.Producto
                    on new { peu.PROClave, Baja = (bool?)false } equals new { p.PROClave, p.Baja }
                where peu.Producto.Clave.Replace("-", "") == requestData.PROClave.Replace("-", "") || 
                      peu.Producto.NumParte == requestData.PROClave ||
                      peu.Producto.Alterno1 == requestData.PROClave ||
                      peu.Producto.Alterno2 == requestData.PROClave ||
                      peu.Producto.Alterno3 == requestData.PROClave ||
                      peu.Producto.ProductoUnidad.Any(x => x.GTIN == requestData.PROClave && x.Factor == 1)
                select peu
            ).SingleOrDefault();

            if (peuOrigen == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.CambioEstado_Material_NotFound));

            var disponibleParaBloqueo = requestData.Bloquear == true ? peuOrigen.Existencia - peuOrigen.Apartado - peuOrigen.Bloqueado : peuOrigen.Bloqueado;
            if (disponibleParaBloqueo <= 0)//hay disponibilidad?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.CambioEstado_Material_NoContent));

            if (requestData.Bloquear) //Bloquear
            {
                peuOrigen.Estado = 0;
                peuOrigen.Bloqueado = disponibleParaBloqueo;
            }
            else{ //Desbloquear
                peuOrigen.Estado = 1;
                peuOrigen.Bloqueado = 0;
            }

            //Modificar la cantidad de bloqueados en Existencia de Almacen
            decimal? diferenciaBloqueados = ((requestData.Bloquear == true) ? disponibleParaBloqueo : -disponibleParaBloqueo);
            if (diferenciaBloqueados != null && diferenciaBloqueados != 0)
            {
                Existencia existenciaAlmacen = db.Existencia.First(x =>
                    x.ALMClave == requestData.ALMClave &&
                    x.PROClave == requestData.PROClave
                );

                existenciaAlmacen.Bloqueado += diferenciaBloqueados;
            }
                
            peuOrigen.MFechaHora = DateTime.Now;
            peuOrigen.MUsuarioId = usrClave;

            try
            {
                //Agregar un MovUbc
                var nuevaReferencia = insertarMovUbc(
                    requestData.SUCClave,
                    estructuraDestino.ALMClave,
                    peuOrigen.UBCClave,
                    peuOrigen.UBCClave,
                    peuOrigen.PROClave,
                    3, //Cambio de estado
                    11, //Cambio de estado
                    disponibleParaBloqueo,
                    peuOrigen.Estado,
                    "ModificarProductoEstado",
                    usrClave
                );

                //Obtengo el path de destino para el archivo de la interfaz
                CompanyParam path = db.CompanyParam.SingleOrDefault(x => x.COMClave.Equals(requestData.COMClave) && x.PARClave.Equals("InterfazSalida"));

                //Obtengo el nombre del SP de la interfaz
                st_recupera_interfaz_Result st_recupera_interfaz_Result_Instance = db.st_recupera_interfaz("CambioEstado", requestData.COMClave).SingleOrDefault();
                if (st_recupera_interfaz_Result_Instance != null)
                {
                    String procedimiento = st_recupera_interfaz_Result_Instance.sp;

                    //Ejecuto el SP según st_recupera_interfaz()
                    SqlConnection dbCon = db.Database.Connection as SqlConnection;
                    SqlCommand cmd = new SqlCommand(procedimiento, dbCon);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Folio", nuevaReferencia);
                    cmd.Parameters.AddWithValue("TipoDocumento", 0);
                    cmd.Parameters.AddWithValue("Path", path.Valor);
                    cmd.Parameters.AddWithValue("Fecha", DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                    dbCon.Open();
                    cmd.ExecuteNonQuery();
                    dbCon.Close();
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, Mensajes.General_Error));
            }

            return disponibleParaBloqueo;

        }

        // GET api/Producto/AgregarHuella
        /// <summary>
        /// Agrega la Huella para un producto (ProductoUnidad).
        /// </summary>
        /// <param name="PROClave">La Clave del Producto</param>
        /// <param name="volumen">Volumen del producto</param>
        /// <param name="alto">Alto del producto</param>
        /// <param name="largo">Largo del producto</param>
        /// <param name="ancho">Ancho del producto</param>
        /// <returns>ApiProductoInventario</returns>
        [HttpGet]
        public HttpResponseMessage AgregarHuella(string PROClave, decimal volumen, decimal? alto = null, decimal? largo = null, decimal? ancho = null)
        {
            int? factor = 1;
            var producto = (
                from p in db.Producto
                where p.Baja==false &&
                      (p.Clave.Replace("-", "") == PROClave.Replace("-", "") || 
                      p.NumParte == PROClave ||
                      p.Alterno1 == PROClave ||
                      p.Alterno2 == PROClave ||
                      p.Alterno3 == PROClave ||
                      p.ProductoUnidad.Any(x => x.GTIN == PROClave && x.Factor == 1))
                join pu in db.ProductoUnidad
                    on new { p.PROClave, Factor = factor }  equals new { pu.PROClave, pu.Factor } into joined //left join
                from j in joined.DefaultIfEmpty()
                select new { Producto = p, Huella = j }
            ).FirstOrDefault();

            if (producto == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Almacenaje_Producto_NotFound));

            ProductoUnidad huella;

            if(producto.Huella!=null)
                huella = producto.Huella;
            else{
                string usrClave = HttpContext.Current.Items["USRClave"].ToString();
                var nuevoId = db.Database.SqlQuery<string>("SELECT Right(newid(),20)").First();

                huella = new ProductoUnidad
                {
                    PUDClave = nuevoId,
                    UNDClave = "PZA",
                    PROClave = producto.Producto.PROClave,
                    GTIN = "",
                    Factor = 1,
                    MFechaHora = DateTime.Now,
                    MUsuarioId = usrClave
                };

                db.ProductoUnidad.Add(huella);
            }
            huella.Volumen = volumen;
            if(alto!=null)
                huella.Alto = alto;
            if (largo != null)
                huella.Largo = largo;
            if (ancho != null)
                huella.Ancho = ancho;

            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
            
        }

        // GET api/Producto/AjustarInventario
        /// <summary>
        /// Realiza el ajuste de inventario de un producto en una Ubicacion
        /// </summary>
        /// <param name="COMClave">Clave de la Compania.</param>
        /// <param name="SUCClave">Clave de la Sucursal.</param>
        /// <param name="ALMClave">Clave del Almacén.</param>
        /// <param name="Ubicacion">Clave de la ubicacion de Tránsito.</param>
        /// <param name="Producto">Clave del producto.</param>
        /// <param name="cantidad">Cantidad de producto.</param>
        /// <param name="Login">(Optional)Login del Usuario autorizador.</param>
        /// <param name="Password">(Optional)Password del Usuario autorizador.</param>
        /// <returns>Double</returns>
        [HttpGet]
        public HttpResponseMessage AjustarInventario(string COMClave, string SUCClave, string ALMClave, string Ubicacion, string Producto, decimal cantidad, string Login = "", string Password = "")
        {
            string usrClave = HttpContext.Current.Items["USRClave"].ToString();
            if (usrClave == null)//Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Forbidden, Mensajes.General_USRClave_NotFound));

            //G.2 Solicitara lectura de material, validara que exista dentro de la ubicación.
            var producto = (
                from p in db.Producto
                where p.Baja==false &&
                      (p.Clave.Replace("-", "") == Producto.Replace("-", "") ||
                      p.NumParte.Replace("-", "") == Producto.Replace("-", "") ||
                      p.Alterno1.Replace("-", "") == Producto.Replace("-", "") ||
                      p.Alterno2.Replace("-", "") == Producto.Replace("-", "") ||
                      p.Alterno3.Replace("-", "") == Producto.Replace("-", "") ||
                      p.ProductoUnidad.Any(x => x.GTIN.Replace("-", "") == Producto.Replace("-", "") && x.Factor == 1))
                join exist in db.Existencia
                    on new {p.PROClave, ALMClave } equals new {exist.PROClave, exist.ALMClave }
                select new { p, exist }
            ).SingleOrDefault();
            
            //G 2 Se validara que el producto exista en el sistema, de lo contrario enviara error.
            if (producto == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.AjusteInventario_Producto_NotFound));

            //Obtengo la instancia de la Ubicacion, Estructura y en caso de que exista, tambien el prd_exist_uba
            var origen = (
                from u in db.Ubicacion
                where u.Ubicacion1.Replace("-", "") == Ubicacion.Replace("-", "") && u.Baja==false
                join e in db.Estructura
                    on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                join peu1 in db.prd_exist_uba
                    on new {producto.p.PROClave, u.UBCClave} equals new {peu1.PROClave, peu1.UBCClave} into peuJ
                from peu in peuJ.DefaultIfEmpty()
                select new
                {
                    Ubicacion = u,
                    Estructura = e,
                    prd_exist_uba = peu
                }
            ).SingleOrDefault();

            if(origen==null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.AjusteInventario_Ubicacion_NotFound));

            //G SI el producto no existe en prd_exist_uba donde la UBCClave sea igual a la clave de la ubicación leida se considera que existencia, apartado y bloqueado son igual a cero.
            prd_exist_uba prdExistUba  = origen.prd_exist_uba ?? new prd_exist_uba
            {
                Existencia = 0,
                Apartado = 0,
                Bloqueado = 0,
                PROClave = producto.p.PROClave,
                UBCClave = origen.Ubicacion.UBCClave,
                Estado = 1
            };

            decimal? diferencia = cantidad - prdExistUba.Existencia;

            //G Se obtendrá diferencia ( Cantidad capturada - prd_exist_uba.Existencia)
            //  si la diferencia es igual a cero, se envía mensaje informando de que no se encontró diferencia por lo que no es posible realizar ajuste.
            if (diferencia == 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { diferencia });
            }
            //G 4 Si la diferencia es diferente a Cero,  
            //    se validara que la (Existencia – Apartado – Bloqueado) sea mayor o igual a la diferencia absoluta(Abs(cantidad)). 
            if (diferencia < 0 && prdExistUba.Existencia - prdExistUba.Apartado - prdExistUba.Bloqueado < Math.Abs(cantidad))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.AjusteInventario_Ubicacion_ApartadoBloqueado));
            }

            //Si no hay datos para autorización
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Login))
            {
                //mandar el listado de usuarios autorizados
                var autorizados =
                from aut in db.Autorizacion
                join usr in db.Usuario
                    on new {aut.USRClave, aut.SUCClave, Baja=(bool?)false } equals new {usr.USRClave, usr.SUCClave, usr.Baja }
                join suc in db.Sucursal
                    on new { usr.SUCClave, Baja = (bool?)false } equals new { suc.SUCClave, suc.Baja }
                join alm in db.Almacen
                    on new { ALMClave, suc.SUCClave, Baja = (bool?)false } equals new { alm.ALMClave, alm.SUCClave, alm.Baja }
                select usr.Login;

                return Request.CreateResponse(HttpStatusCode.OK, new { diferencia, autorizados, producto.p.Clave, producto.p.Descripcion, Ubicacion = origen.Ubicacion.Ubicacion1 });
            }

            //Si hay datos de autorizacion
            Usuario usuarioInstance = 
            (
                from aut in db.Autorizacion
                    join usr in db.Usuario
                        on new { Login, aut.USRClave, aut.SUCClave, Baja = (bool?)false } equals new { usr.Login, usr.USRClave, usr.SUCClave, usr.Baja }
                    join suc in db.Sucursal
                        on new { usr.SUCClave, Baja = (bool?)false } equals new { suc.SUCClave, suc.Baja }
                    join alm in db.Almacen
                        on new { ALMClave, suc.SUCClave, Baja = (bool?)false } equals new { alm.ALMClave, alm.SUCClave, alm.Baja }
                    select usr
            ).SingleOrDefault();

            if (usuarioInstance == null || !HashPass.ValidatePassword(Password, usuarioInstance.Password))
            {
                string errorAutenticacion = Mensajes.AjusteInventario_Autenticacion_Error;
                //mandar el listado de usuarios autorizados
                var autorizados =
                from aut in db.Autorizacion
                join usr in db.Usuario
                    on new { aut.USRClave, aut.SUCClave, Baja = (bool?)false } equals new { usr.USRClave, usr.SUCClave, usr.Baja }
                join suc in db.Sucursal
                    on new { usr.SUCClave, Baja = (bool?)false } equals new { suc.SUCClave, suc.Baja }
                join alm in db.Almacen
                    on new { ALMClave, suc.SUCClave, Baja = (bool?)false } equals new { alm.ALMClave, alm.SUCClave, alm.Baja }
                select usr.Login;

                return Request.CreateResponse(HttpStatusCode.OK, new { errorAutenticacion, diferencia, autorizados, producto.p.Clave, producto.p.Descripcion, Ubicacion = origen.Ubicacion.Ubicacion1 });
            }
            
            //G 6 SI LA AUTORIZACION ES CORRECTA

            //G 6 a. Incrementa o decrementa la existencia del almacen para ese producto en la tabla Existencia.Existencia.
            Existencia existenciaAlmacen = producto.exist;
            existenciaAlmacen.Existencia1 += diferencia;

            //G 6 b. Incrementa o decrementa la existencia en la ubicación para ese producto en la tabla prd_exist_uba.Existencia.(si no existe el producto en prd_exist_uba, se inserta el registro)
            prdExistUba.Existencia += diferencia;
            prdExistUba.MFechaHora = DateTime.Now;
            prdExistUba.MUsuarioId = usrClave;

            if (origen.prd_exist_uba == null) //si no existe el producto en prd_exist_uba, se inserta el registro
                db.prd_exist_uba.Add(prdExistUba);

            try
            {
                int tipo = diferencia > 0 ? 1 /*Entrada*/ : 2 /*Salida*/;

                //Agregar un Movimiento
                db.Database.ExecuteSqlCommand(
                    "INSERT INTO Movimiento(MOVClave,Periodo,Mes,ALMClave,Referencia,PROClave,TipoMov,Motivo,Cantidad,Nota,MFechaHora,MUsuarioId,Autorizo) " +
                    " VALUES(Right(newid(),20),@Periodo,@Mes,@ALMClave,@Referencia,@PROClave,@TipoMov,@Motivo,@Cantidad,@Nota,@MFechaHora,@MUsuarioId,@Autorizo)",
                    new SqlParameter("@Periodo", DateTime.Now.Year),
                    new SqlParameter("@Mes", DateTime.Now.Month),
                    new SqlParameter("@ALMClave", ALMClave),
                    new SqlParameter("@Referencia", ""),
                    new SqlParameter("@PROClave", prdExistUba.PROClave),
                    new SqlParameter("@TipoMov", tipo), //Entrada o Salida
                    new SqlParameter("@Motivo", 4), //Ajuste
                    new SqlParameter("@Cantidad", Math.Abs((double)diferencia)),
                    new SqlParameter("@Nota", "Ajuste"),
                    new SqlParameter("@MFechaHora", DateTime.Now),
                    new SqlParameter("@MUsuarioId", usrClave),
                    new SqlParameter("@Autorizo", usuarioInstance.USRClave)
                );

                //Agregar un MovUbc
                var nuevaReferencia = insertarMovUbc(
                    SUCClave,
                    ALMClave,
                    prdExistUba.UBCClave,
                    prdExistUba.UBCClave,
                    prdExistUba.PROClave,
                    tipo, //Entrada o Salida
                    4, //Ajuste
                    Math.Abs((decimal)diferencia),
                    prdExistUba.Estado,
                    "Ajuste",
                    usrClave
                );

                //Obtengo el path de destino para el archivo de la interfaz
                CompanyParam path = db.CompanyParam.SingleOrDefault(x => x.COMClave.Equals(COMClave) && x.PARClave.Equals("InterfazSalida"));

                //Obtengo el nombre del SP de la interfaz
                st_recupera_interfaz_Result st_recupera_interfaz_Result_Instance = db.st_recupera_interfaz("Ajuste", COMClave).SingleOrDefault();
                String procedimiento = st_recupera_interfaz_Result_Instance.sp;

                //Ejecuto el SP según st_recupera_interfaz()
                SqlConnection dbCon = db.Database.Connection as SqlConnection;
                SqlCommand cmd = new SqlCommand(procedimiento, dbCon);
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Folio", nuevaReferencia);
                cmd.Parameters.AddWithValue("TipoDocumento", 0);
                cmd.Parameters.AddWithValue("Path", path.Valor);
                cmd.Parameters.AddWithValue("Fecha", DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                dbCon.Open();
                cmd.ExecuteNonQuery();
                dbCon.Close();

                db.SaveChanges();

            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, Mensajes.General_Error));
            }

            db.SaveChanges();
            
            return Request.CreateResponse(HttpStatusCode.OK, new {Exito=true});

        }

        protected string insertarMovUbc(
            string SUCClave, 
            string ALMClave, 
            string UBCClaveOrigen, 
            string UBCClaveDestino, 
            string PROClave,
            int TipoMov,
            int Motivo,
            decimal? Cantidad,
            int? Estado,
            string Nota,
            string usrClave
        )
        {
            //Agregar un MovUbc
            string nuevaReferencia = "";

            try
            {
                nuevaReferencia = db.Database.SqlQuery<string>("SELECT Right(newid(),20)").First();
                db.Database.ExecuteSqlCommand(
                    "INSERT INTO MovUbc(MOVClave,Periodo,Mes,SUCClave,ALMClave,UBCClaveO,UBCClaveD,PROClave,TipoMov,Motivo,Cantidad,TipoEstado,Nota,Referencia,MFechaHora,MUsuarioId,Plataforma) " +
                    " VALUES(Right(newid(),20),@Periodo,@Mes,@SUCClave,@ALMClave,@UBCClaveO,@UBCClaveD,@PROClave,@TipoMov,@Motivo,@Cantidad,@TipoEstado,@Nota,@Referencia,@MFechaHora,@MUsuarioId,@Plataforma)",
                    new SqlParameter("@Periodo", DateTime.Now.Year),
                    new SqlParameter("@Mes", DateTime.Now.Month),
                    new SqlParameter("@SUCClave", SUCClave),
                    new SqlParameter("@ALMClave", ALMClave),
                    new SqlParameter("@UBCClaveO", UBCClaveOrigen),
                    new SqlParameter("@UBCClaveD", UBCClaveDestino),
                    new SqlParameter("@PROClave", PROClave),
                    new SqlParameter("@TipoMov", TipoMov), //Cambio de estado
                    new SqlParameter("@Motivo", Motivo), //Reubicacion Manual
                    new SqlParameter("@Cantidad", Cantidad),
                    new SqlParameter("@TipoEstado", Estado),
                    new SqlParameter("@Nota", Nota),
                    new SqlParameter("@Referencia", nuevaReferencia),
                    new SqlParameter("@MFechaHora", DateTime.Now),
                    new SqlParameter("@MUsuarioId", usrClave),
                    new SqlParameter("@Plataforma", "RF")
                );
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            return nuevaReferencia;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        
        [HttpGet]
        public IEnumerable<ApiProveedor> ProveedorProducto(string PROClave) 
        {
            Producto producto = db.Producto.SingleOrDefault(p =>
                p.Baja == false &&
                p.Clave.Replace("-", "") == PROClave.Replace("-", "") ||
                p.NumParte == PROClave ||
                p.Alterno1 == PROClave ||
                p.Alterno2 == PROClave ||
                p.Alterno3 == PROClave ||
                p.ProductoUnidad.Any(x => x.GTIN == PROClave && x.Factor == 1)
            );
            if (producto == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Recibo_Producto_NotFound));
            }

            /*IEnumerable<ApiProveedor> prvprod = from p in db.Proveedor
                                                join pp in db.PrvProd*/

            DataTable dtu = new DataTable();
            SqlDataAdapter du = new SqlDataAdapter();
            SqlConnection dbCon = db.Database.Connection as SqlConnection;
            
            String procedimiento = "st_recupera_prvprod";

            du.SelectCommand = new SqlCommand(procedimiento, dbCon);
            du.SelectCommand.CommandType = CommandType.StoredProcedure;
            du.SelectCommand.Parameters.Add("@PROClave", SqlDbType.VarChar).Value = producto.PROClave;
            du.Fill(dtu);
            du.Dispose();

            dtu.TableName = procedimiento;
            
            //dbCon.Open();
            //dbCon.Close();

            return dtu.AsEnumerable().Select(row => new ApiProveedor
            {
                PRVClave = row.Field<string>("PRVClave"),
                Clave = row.Field<string>("Clave"),
                RazonSocial = row.Field<string>("RazonSocial")
            });

        }

    }
}