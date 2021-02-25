using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SellingWS.Models;
using SellingWS.Models.API;
using log4net;
using System.Reflection;
using System.Web;
using SellingWS.Resources;
using System.Data.SqlClient;

namespace SellingWS.Controllers
{
    public class SurtidoController : ApiController
    {
        private SellingEntities db = new SellingEntities();
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region CONSTANTES

        //MovUbc
        private readonly int MOV_UBC_TIPO_REUBICACION_MANUAL = 13;
        private readonly int MOV_UBC_MOTIVO_SALIDA = 2;

        //Surtido
        private readonly int? SURTIDO_PRIORIDAD_MOSTRADOR = 1;
        private readonly int? SURTIDO_ESTADO_DISPONIBLE = 1;
        private readonly int? SURTIDO_ESTADO_ASIGNADO = 2;
        private readonly int? SURTIDO_ESTADO_TERMINADO = 3;
        private readonly string SEPARADOR_FOLIO = "-";
        private readonly int? SURTIDO_TIPODOCUMENTO_VENTA = 1;

        //SurtidoDetalle
        private readonly int? SURTIDO_DETALLE_ESTADO_NoAsignable = -1;
        private readonly int? SURTIDO_DETALLE_ESTADO_Asignable = 0;
        private readonly int? SURTIDO_DETALLE_ESTADO_Asignada = 1;
        private readonly int? SURTIDO_DETALLE_ESTADO_Standby = 2;
        private readonly int? SURTIDO_DETALLE_ESTADO_Terminada = 3;

        #endregion CONSTANTES

        #region OPERACIONES

        // GET api/Surtido/areas
        /// <summary>
        /// Areas existentes en el almacen, 'asignado' indica las areas en las que tiene asignaciones sin terminar (Estado != 3).
        /// </summary>
        /// <param name="ALMClave">El identificador del Almacén.</param>
        /// <param name="mostrador">Si los asignados son de mostrador o no.</param>
        /// <returns>IEnumerable{ApiSurtidoAreas} || 404 || 204</returns>
        [HttpGet]
        public IEnumerable<ApiSurtidoAreas> areas(string ALMClave, bool mostrador)
        {
            if (HttpContext.Current.Items["USRClave"] == null)//Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.General_USRClave_NotFound));
            string usrClave = HttpContext.Current.Items["USRClave"].ToString();

            if (ALMClave == null || ALMClave == "")
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NoContent, Mensajes.Surtido_ALMClave_Empty));

            IEnumerable<ApiSurtidoAreas> areas = (
                from a in db.Area
                where a.ALMClave == ALMClave && a.Baja == false && a.Estado == 1
                join sd in db.SurtidoDetalle
                    on a.AREClave equals sd.AREClave
                    into surtidos1
                from s1 in surtidos1.DefaultIfEmpty()//left join con SurtidoDetalle
                join s in db.Surtido
                    on new { s1.DOCClave, s1.TipoDocumento } equals new { s.DOCClave, s.TipoDocumento }
                    into surtidos2
                from s2 in surtidos2.DefaultIfEmpty()//left join con Surtido
                group new { a, s1, Prioridad = s2.Prioridad.Value, Estado = s2.Estado.Value } by new { a.AREClave, a.Clave } into agrupados
                orderby agrupados.Key.Clave
                select new ApiSurtidoAreas
                {
                    AREClave = agrupados.Key.AREClave,
                    Clave = agrupados.Key.Clave,
                    asignado = agrupados.Any(x =>
                        (
                            x.Estado != null && 
                            SURTIDO_ESTADO_ASIGNADO.Value.Equals(x.Estado)
                        ) &&
                        (
                            x.s1 != null &&
                            x.s1.Recolector == usrClave &&
                            x.s1.Estado != SURTIDO_DETALLE_ESTADO_Terminada
                        ) &&
                        (
                            ((mostrador && SURTIDO_PRIORIDAD_MOSTRADOR.Value.Equals(x.Prioridad))) ||
                            (!mostrador && !SURTIDO_PRIORIDAD_MOSTRADOR.Value.Equals(x.Prioridad))
                        )
                    )
                }
            );

            return areas;
        }

        // POST api/Surtido/asignarDocUsu
        /// <summary>
        /// Se asigna el documento al usuario que este logeado 
        /// </summary>
        /// <param name="DOCClave">Clave del documento que se asignara al usuario.</param>
        /// <param name="AREClaves">Areas seleccionadas.</param>
        /// <returns>200 || 404 || 204</returns>
        [HttpPost]
        public HttpResponseMessage asignarDocUsu([FromUri]string DOCClave, [FromUri] List<String> AREClaves)
        {

            if (HttpContext.Current.Items["USRClave"] == null)//Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.General_USRClave_NotFound));
            string usrClave = HttpContext.Current.Items["USRClave"].ToString();

            if (DOCClave == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NoContent, "DOCClave empty"));//TODO:mensaje
          
            IEnumerable<SurtidoDetalle> surtidoAsignado = (
                     from sd in db.SurtidoDetalle
                     where
                         sd.Estado == SURTIDO_DETALLE_ESTADO_Asignada &&
                         DOCClave.Equals(sd.DOCClave) &&
                         sd.Recolector == usrClave
                     select sd
                 );

            if (surtidoAsignado.FirstOrDefault() == null)
            {
                Surtido surtido = (
                   from s in db.Surtido
                   where
                       s.DOCClave == DOCClave &&
                       (s.Estado == SURTIDO_ESTADO_DISPONIBLE || s.Estado == SURTIDO_ESTADO_ASIGNADO)
                   select s
                ).FirstOrDefault();

                if (surtido != null)
                {
                    surtido.Estado = SURTIDO_ESTADO_ASIGNADO;

                    IEnumerable<SurtidoDetalle> surtidos = (
                          from sd in db.SurtidoDetalle
                          where
                              sd.Estado == SURTIDO_DETALLE_ESTADO_Asignable &&
                              DOCClave.Equals(sd.DOCClave) &&
                              AREClaves.Contains(sd.AREClave) &&
                              sd.Recolector == null
                          select sd
                      );

                    if (surtidos != null)
                    {
                        foreach (SurtidoDetalle detalle in surtidos)
                        {

                            detalle.Estado = SURTIDO_DETALLE_ESTADO_Asignada;
                            detalle.Recolector = usrClave;
                        }
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                  
                   return Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.Surtido_Asignado);

                }

                return Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.Surtido_Asignado);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        // POST api/Surtido/asignados
        /// <summary>
        /// Devuelve los SurtidoDetalle asignados de las areas seleccionadas.
        /// </summary>
        /// <param name="AREClaves">Areas seleccionadas</param>
        /// <param name="mostrador">Si los asignados son de mostrador o no.</param>
        /// <returns>IEnumerable[ApiSurtidoAsigancion] || 404 || 204></returns>
        [HttpPost]
        public IEnumerable<ApiSurtidoAsigancion> asignados([FromUri]List<String> AREClaves, bool mostrador)
        {
            
            if (HttpContext.Current.Items["USRClave"] == null)//Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.General_USRClave_NotFound));
            string usrClave = HttpContext.Current.Items["USRClave"].ToString();
            
            if (AREClaves == null || AREClaves.Count() == 0)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.Surtido_AREClaves_Empty));

            IEnumerable<SurtidoAsignado> surtido = (
                from sd in db.SurtidoDetalle
                where
                    AREClaves.Contains(sd.AREClave) &&
                   (usrClave.Equals(sd.Recolector) ||sd.Recolector.Equals (null))   &&
                    //  usrClave.Equals(sd.Recolector) &&
                    (
                        SURTIDO_DETALLE_ESTADO_Asignada.Value.Equals(sd.Estado.Value) ||
                        SURTIDO_DETALLE_ESTADO_Standby.Value.Equals(sd.Estado.Value)
                       || SURTIDO_DETALLE_ESTADO_Asignable.Value.Equals(sd.Estado.Value)
                    )
                join a in db.Area
                    on sd.AREClave equals a.AREClave
                join s in db.Surtido
                    on new { sd.DOCClave, sd.TipoDocumento} equals new {s.DOCClave,s.TipoDocumento}
                where (
                    (SURTIDO_ESTADO_DISPONIBLE.Value.Equals(s.Estado.Value) || SURTIDO_ESTADO_ASIGNADO.Value.Equals(s.Estado.Value)) &&
                    ((mostrador && SURTIDO_PRIORIDAD_MOSTRADOR.Value.Equals(s.Prioridad.Value) && SURTIDO_TIPODOCUMENTO_VENTA.Value.Equals(s.TipoDocumento)) ||
                    (!mostrador && ((SURTIDO_PRIORIDAD_MOSTRADOR.Value != s.Prioridad.Value && SURTIDO_TIPODOCUMENTO_VENTA.Value.Equals(s.TipoDocumento)) || SURTIDO_TIPODOCUMENTO_VENTA.Value != s.TipoDocumento)))
                )
                join u in db.Ubicacion
                    on s.Stage equals u.UBCClave
                group new SurtidoAsignadoDetalle { sd = sd, Area = a.Clave } //Agrupo el detalle y la clave del area
                    by new
                    {
                        sd.DOCClave,
                        sd.TipoDocumento,
                        s.Periodo,
                        s.Mes,
                        s.Folio,
                        Prioridad = s.Prioridad.Value,
                        Stage = u.Ubicacion1,
                        StageClave = u.UBCClave,
                        Estado = s.Estado
                    } into detalles //por DOCClave y TipoDocumento
                orderby detalles.Key.Prioridad descending
                select new SurtidoAsignado
                {
                    DOCClave = detalles.Key.DOCClave,
                    TipoDocumento = detalles.Key.TipoDocumento,
                    Periodo = detalles.Key.Periodo,
                    Mes = detalles.Key.Mes,
                    Folio = detalles.Key.Folio,
                    Prioridad = detalles.Key.Prioridad,
                    Stage = detalles.Key.Stage,
                    StageClave = detalles.Key.StageClave,
                    Estado = detalles.Key.Estado,
                    detalles = detalles.AsEnumerable()
                }
            );

            if (surtido != null)
            {
                List<ApiSurtidoAsigancion> asignados = new List<ApiSurtidoAsigancion>();
                foreach (SurtidoAsignado asignado in surtido)
                {
                    //Se comento por que no se debe asignar todos los documentos de las areas seleccionadas al usuario en curso
                   /* foreach (SurtidoDetalle detalle in asignado.detalles.Select(x => x.sd))
                    {
                        detalle.Recolector = usrClave;
                        detalle.Estado = SURTIDO_DETALLE_ESTADO_Asignada;
                    }*/
                    asignados.Add(
                        new ApiSurtidoAsigancion
                        {
                            TipoDocumento = asignado.TipoDocumento,
                            DOCClave = asignado.DOCClave,
                            Folio = generarFolio(asignado.Periodo, asignado.Mes, asignado.Folio),
                            Prioridad = asignado.Prioridad,
                            Cliente = obtenerCliente(asignado.TipoDocumento, asignado.DOCClave),
                            Stage = asignado.Stage,
                            StageClave = asignado.StageClave,
                            Estado = asignado.Estado,
                            detalles = asignado.detalles.Select(x =>
                                new ApiSurtidoAsignacionDetalle
                                {
                                    DOCClave = x.sd.DOCClave,
                                    AREClave = x.sd.AREClave,
                                    Area = x.Area,
                                    PROClave = x.sd.PROClave,
                                    Producto = x.sd.Producto.Clave,
                                    NumParte = x.sd.Producto.NumParte,
                                    Alterno1 = x.sd.Producto.Alterno1,
                                    Alterno2 = x.sd.Producto.Alterno2,
                                    Alterno3 = x.sd.Producto.Alterno3,
                                    GTIN = x.sd.Producto.ProductoUnidad.FirstOrDefault(pu => pu.Factor == 1).GTIN,
                                    Cantidad = x.sd.Cantidad,
                                    Surtido = x.sd.Surtido,
                                    Transito = x.sd.Transito,
                                    UBCClave = x.sd.UBCClave,
                                    Ubicacion = x.sd.Ubicacion.Ubicacion1,
                                    Tiporechazo = x.sd.TipoRechazo
                                }
                            )
                        }
                    );
                }
                db.SaveChanges();
                return asignados;
            }

            return new List<ApiSurtidoAsigancion>();
        }

        // POST api/Surtido/asignacion
        /// <summary>
        /// Asigna varios SurtidoDetalle de las areas seleccionadas, para el primer Surtido con mayor prioridad.
        /// </summary>
        /// <param name="AREClaves">Areas seleccionadas</param>
        /// <param name="mostrador">Si los asignados son de mostrador o no.</param>
        /// <returns>ApiSurtidoAsigancion || 404 || 204</returns>
        [HttpPost]
        public ApiSurtidoAsigancion asignacion([FromUri]List<String> AREClaves, bool mostrador)
        {
            
            if (HttpContext.Current.Items["USRClave"] == null)//Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.General_USRClave_NotFound));
            string usrClave = HttpContext.Current.Items["USRClave"].ToString();
            
            if (AREClaves == null || AREClaves.Count() == 0)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NoContent, Mensajes.Surtido_AREClaves_Empty));

            var surtido = (
                from sd in db.SurtidoDetalle
                where
                    SURTIDO_DETALLE_ESTADO_Asignable.Value.Equals(sd.Estado.Value) && 
                    AREClaves.Contains(sd.AREClave) &&
                    (null == sd.Surtido || sd.Surtido < sd.Cantidad)
                join a in db.Area
                    on sd.AREClave equals a.AREClave
                join s in db.Surtido
                    on sd.DOCClave equals s.DOCClave
                where (
                    (SURTIDO_ESTADO_DISPONIBLE.Value.Equals(s.Estado.Value) || SURTIDO_ESTADO_ASIGNADO.Value.Equals(s.Estado.Value)) &&
                    ((mostrador && SURTIDO_PRIORIDAD_MOSTRADOR.Value.Equals(s.Prioridad.Value)) ||
                    (!mostrador && (SURTIDO_PRIORIDAD_MOSTRADOR.Value != s.Prioridad.Value)))
                )
                join u in db.Ubicacion
                    on s.Stage equals u.UBCClave
                group new { sd = sd, AreaClave = a.Clave } //Agrupo el detalle y la clave del area
                    by new { 
                        s,
                        sd.DOCClave, 
                        sd.TipoDocumento, 
                        s.Periodo,
                        s.Mes,
                        s.Folio,
                        Prioridad = s.Prioridad.Value,
                        Stage = u.Ubicacion1,
                        StageClave = u.UBCClave,
                        Estado = s.Estado
                    } into detalles //por DOCClave y TipoDocumento
                orderby detalles.Key.Prioridad descending
                select new
                {
                    Surtido = detalles.Key.s,
                    DOCClave = detalles.Key.DOCClave,
                    TipoDocumento = detalles.Key.TipoDocumento,
                    Periodo = detalles.Key.Periodo,
                    Mes = detalles.Key.Mes,
                    Folio = detalles.Key.Folio,
                    Prioridad = detalles.Key.Prioridad,
                    Stage = detalles.Key.Stage,
                    StageClave = detalles.Key.StageClave,
                    detalles = detalles.AsEnumerable()
                }
            ).FirstOrDefault();

            if (surtido != null && surtido.Surtido != null && surtido.detalles != null) {
                foreach(SurtidoDetalle detalle in surtido.detalles.Select(x=>x.sd)){
                    detalle.Recolector = usrClave;
                    detalle.Estado = SURTIDO_DETALLE_ESTADO_Asignada;//Afecto el estado del SurtidoDetalle
                }
                Surtido surtidoDB = surtido.Surtido;
                surtidoDB.Estado = SURTIDO_ESTADO_ASIGNADO;//Afecto el estado del Surtido

                db.SaveChanges();
                return new ApiSurtidoAsigancion
                {
                    TipoDocumento = surtido.TipoDocumento,
                    DOCClave = surtido.DOCClave,
                    Folio = generarFolio(surtido.Periodo,surtido.Mes,surtido.Folio),
                    Prioridad = surtido.Prioridad,
                    Cliente = obtenerCliente(surtido.TipoDocumento,surtido.DOCClave),
                    Stage = surtido.Stage,
                    StageClave = surtido.StageClave,
                    detalles = surtido.detalles.Select(x =>
                        new ApiSurtidoAsignacionDetalle {
                            DOCClave = x.sd.DOCClave,
                            AREClave = x.sd.AREClave,
                            Area = x.AreaClave,
                            PROClave = x.sd.PROClave,
                            Producto = x.sd.Producto.Clave,
                            NumParte = x.sd.Producto.NumParte,
                            Alterno1 = x.sd.Producto.Alterno1,
                            Alterno2 = x.sd.Producto.Alterno2,
                            Alterno3 = x.sd.Producto.Alterno3,
                            GTIN = x.sd.Producto.ProductoUnidad.FirstOrDefault(pu => pu.Factor == 1).GTIN,
                            Cantidad = x.sd.Cantidad,
                            Surtido = x.sd.Surtido,
                            Transito = x.sd.Transito,
                            UBCClave = x.sd.UBCClave,
                            Ubicacion = x.sd.Ubicacion.Ubicacion1,
                            Tiporechazo = x.sd.TipoRechazo
                        }
                    )
                };
            }

            return null;
        }

        // POST api/Surtido/ponerEnStandby
        /// <summary>
        /// Modifica el estado de los SurtidoDetalle a Standby.
        /// </summary>
        /// <param name="DOCClave">Clave del documento al que se actualizara el estado.</param>
        /// <returns>200 || 404 || 204</returns>
        [HttpPost]
        public HttpResponseMessage ponerEnStandby([FromBody]string DOCClave)
        {

            if (HttpContext.Current.Items["USRClave"] == null)//Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.General_USRClave_NotFound));
            string usrClave = HttpContext.Current.Items["USRClave"].ToString();

            if (DOCClave == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NoContent, "DOCClave empty"));//TODO:mensaje

            IEnumerable<SurtidoDetalle> surtidos = (
                from sd in db.SurtidoDetalle
                where 
                    sd.Estado == SURTIDO_DETALLE_ESTADO_Asignada && 
                    usrClave.Equals(sd.Recolector) &&
                    DOCClave.Equals(sd.DOCClave)
                select sd
            );

            if (surtidos != null)
            {
                foreach (SurtidoDetalle detalle in surtidos)
                {
                    detalle.Estado = SURTIDO_DETALLE_ESTADO_Standby;
                }
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // POST api/Surtido/aumentarTransito
        /// <summary>
        /// Aumenta la cantidad del Producto en Transito y/o Asigna un TipoRechazo
        /// </summary>
        /// <param name="surtidos">Objeto con los detalles del surtido</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage actualizaDetalle(List<ApiSurtidoDepositar>surtidos, string RechazoRF)
        {
            if (HttpContext.Current.Items["USRClave"] == null)//Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.General_USRClave_NotFound));
            string usrClave = HttpContext.Current.Items["USRClave"].ToString();

            if (surtidos == null || surtidos.Count() <= 0)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NoContent, "DOCClave empty"));//TODO:mensaje

            foreach(ApiSurtidoDepositar apiSurtido in surtidos){
                foreach (ApiSurtidoDepositarDetalle apiDetalle in apiSurtido.detalles) {

                    SurtidoDetalle surtidoDetalle = (
                        from sd in db.SurtidoDetalle
                        where   sd.DOCClave == apiSurtido.DOCClave && 
                                sd.AREClave == apiDetalle.AREClave &&
                                sd.UBCClave == apiDetalle.UBCClave &&
                                sd.PROClave == apiDetalle.PROClave &&
                                sd.TipoDocumento == apiSurtido.TipoDocumento
                        select sd
                    ).FirstOrDefault();
                    if (surtidoDetalle == null) {
                        log.Error(
                            "SurtidoDetalle no encontrado DOCClave:" + apiSurtido.DOCClave + 
                            " AREClave:" + apiDetalle.AREClave +
                            " UBCClave:" + apiDetalle.UBCClave + 
                            " PROClave:" + apiDetalle.PROClave
                        );
                        continue;
                    }

                    //Afecto el SurtidoDetalle
                    surtidoDetalle.Transito = apiDetalle.Transito;
                    surtidoDetalle.TipoRechazo = apiDetalle.TipoRechazo;
                    surtidoDetalle.MUsuarioId = usrClave;
                    surtidoDetalle.MFechaHora = DateTime.Now;
                    surtidoDetalle.RechazoRF = int.Parse(RechazoRF);

                    db.SaveChanges();
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Surtido/depositar
        /// <summary>
        /// Mueve los productos a la Ubicacion Stage, modifica el estado del SurtidoDetalle y de Surtido. 
        /// </summary>
        /// <param name="COMClave">Clave de la Compania.</param>
        /// <param name="SUCClave">Clave de la Sucursal.</param>
        /// <param name="ALMClave">Clave del Almacén.</param>
        /// <param name="surtidos">Objeto con los detalles del Surtido</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage depositar(string COMClave, string ALMClave, string SUCClave, List<ApiSurtidoDepositar> surtidos)
        {
            if (HttpContext.Current.Items["USRClave"] == null)//Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Mensajes.General_USRClave_NotFound));
            string usrClave = HttpContext.Current.Items["USRClave"].ToString();

            if (surtidos == null || surtidos.Count() <= 0)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NoContent, "DOCClave empty"));//TODO:mensaje

            foreach(ApiSurtidoDepositar apiSurtido in surtidos){
                Surtido surtido = db.Surtido.FirstOrDefault(x =>
                    x.DOCClave == apiSurtido.DOCClave &&
                    x.TipoDocumento == apiSurtido.TipoDocumento
                );
                if(surtido == null) { //existe el surtido en DB?
                    log.Error(
                        "Surtido no encontrado DOCClave:" + apiSurtido.DOCClave +
                        " TipoDocumento:" + apiSurtido.TipoDocumento
                    );
                    continue;
                }
                foreach (ApiSurtidoDepositarDetalle apiDetalle in apiSurtido.detalles) {
                    SurtidoDetalle surtidoDetalle = (
                        from sd in db.SurtidoDetalle
                        where   sd.DOCClave == apiSurtido.DOCClave && 
                                sd.AREClave == apiDetalle.AREClave &&
                                sd.UBCClave == apiDetalle.UBCClave &&
                                sd.PROClave == apiDetalle.PROClave &&
                                sd.TipoDocumento == apiSurtido.TipoDocumento
                        select sd
                    ).FirstOrDefault();
                    if (surtidoDetalle == null) {
                        log.Error(
                            "SurtidoDetalle no encontrado DOCClave:" + apiSurtido.DOCClave + 
                            " AREClave:" + apiDetalle.AREClave +
                            " UBCClave:" + apiDetalle.UBCClave + 
                            " PROClave:" + apiDetalle.PROClave
                        );
                        continue;
                    }

                    if (apiDetalle.Transito != null && apiDetalle.Transito != 0)
                    {
                        //Obtengo prd_exist_uba Origen y Destino
                        prd_exist_uba peuOrigen = db.prd_exist_uba.Where(x =>
                            x.UBCClave == surtidoDetalle.UBCClave &&
                            x.PROClave == surtidoDetalle.PROClave
                        ).FirstOrDefault();
                        prd_exist_uba peuDestino = db.prd_exist_uba.Where(x =>
                            x.UBCClave == surtido.Stage &&
                            x.PROClave == surtidoDetalle.PROClave
                        ).FirstOrDefault();

                        //Afectar prd_exist_uba destino
                        if (peuDestino != null)
                        {
                            peuDestino.Apartado += apiDetalle.Transito;
                            peuDestino.Existencia += apiDetalle.Transito;
                            peuDestino.MFechaHora = DateTime.Now;
                            peuDestino.MUsuarioId = usrClave;
                        }
                        else
                        {
                            peuDestino = new prd_exist_uba //En caso de que no exista, se crea
                            {
                                Apartado = apiDetalle.Transito,
                                Existencia = apiDetalle.Transito,
                                Bloqueado = 0,
                                Estado = 1, //Libre
                                PROClave = peuOrigen.PROClave,
                                UBCClave = surtido.Stage,
                                MFechaHora = DateTime.Now,
                                MUsuarioId = usrClave
                            };

                            db.prd_exist_uba.Add(peuDestino);

                        }

                        //Afectar prd_exist_uba origen
                        peuOrigen.Apartado -= apiDetalle.Transito;
                        peuOrigen.Existencia -= apiDetalle.Transito;
                        peuOrigen.MFechaHora = DateTime.Now;
                        peuOrigen.MUsuarioId = usrClave;

                        //Afecto el SurtidoDetalle
                        surtidoDetalle.Transito = apiDetalle.Transito;
                        surtidoDetalle.Surtido += apiDetalle.Transito;//No deberia sobreescribirse
                        if (surtidoDetalle.Surtido >= surtidoDetalle.Cantidad)
                            surtidoDetalle.Estado = SURTIDO_DETALLE_ESTADO_Terminada;

                        surtidoDetalle.MUsuarioId = usrClave;
                        surtidoDetalle.MFechaHora = DateTime.Now;
                        
                        db.SaveChanges();

                        insertarMovUbc(
                            SUCClave,
                            ALMClave,
                            peuOrigen.UBCClave,
                            peuDestino.UBCClave,
                            peuDestino.PROClave,
                            MOV_UBC_TIPO_REUBICACION_MANUAL,
                            MOV_UBC_MOTIVO_SALIDA,
                            apiDetalle.Transito,
                            peuDestino.Estado,
                            "Surtido",
                            usrClave
                        );
                    }

                    if (apiDetalle.TipoRechazo != null)
                    {
                        surtidoDetalle.TipoRechazo = apiDetalle.TipoRechazo;
                        surtidoDetalle.Estado = SURTIDO_DETALLE_ESTADO_Terminada;
                        surtidoDetalle.MUsuarioId = usrClave;
                        surtidoDetalle.MFechaHora = DateTime.Now;

                        db.SaveChanges();
                    }
                        
                }

                //Cuento los detalles que faltan por Surtir
                bool? detallePorSurtir = (
                    from sd in db.SurtidoDetalle
                    where   sd.DOCClave == surtido.DOCClave &&
                            sd.TipoDocumento == surtido.TipoDocumento &&
                            (!(!sd.TipoRechazo.Equals(null) && sd.TipoRechazo > 0) && !SURTIDO_DETALLE_ESTADO_Terminada.Value.Equals(sd.Estado.Value))
                    select sd
                ).Any();
                if (detallePorSurtir == null || detallePorSurtir == false)//Si no existen detalles por surtir,
                {
                    surtido.Estado = SURTIDO_ESTADO_TERMINADO;//modifico el Estado del Surtido
                    db.SaveChanges();
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // GET api/Surtido/rfActivo
        /// <summary>
        /// Indica si esta activo el surtido por Radio frecuencia
        /// </summary>
        /// <param name="SUCClave">Clave de la Sucursal.</param>
        /// <returns>200 || 204</returns>
        [HttpGet]
        public HttpResponseMessage rfActivo(string SUCClave)
        {
            Sucursal sucursal = db.Sucursal
                .Where(s => SUCClave.Equals(s.SUCClave) && s.Baja == false)
                .FirstOrDefault();

            if (sucursal == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NoContent, "Sucursal no encontrada"));//TODO:mensaje

            return Request.CreateResponse(HttpStatusCode.OK, new ApiSurtidoActivoRF{
                SurtidoRF= true.Equals(sucursal.SurtidoRF), 
                SurtidoRFMostrador= true.Equals(sucursal.SurtidoRFMostrador)
            });
        }


        // GET api/Surtido/validarProducto
        /// <summary>
        /// Indica si acepta decimales o no el producto
        /// </summary>
        /// <param name="PROClave">Clave del producto</param>
        /// <param name="cantidad">Cantidad recibida del producto</param>
        /// <returns>200 || 204</returns>
        [HttpGet]
        public HttpResponseMessage validarProducto(string PROClave, double cantidad)
        {
            Producto producto = (
                    from p in db.Producto
                    where p.PROClave == PROClave
                    select p
                ).FirstOrDefault();

            //1.0 Se valida que la cantidad de decimales no sea mayor al parametro de Num_Decimales en la tabla Producto
            var decimales = producto.Num_Decimales;
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

            return Request.CreateResponse(HttpStatusCode.OK,true);
        }

        #endregion OPERACIONES

        #region AUXILIARES

        private string generarFolio(int? Periodo, int? Mes, int? Folio)
        {
            return string.Concat(Periodo, Mes, SEPARADOR_FOLIO, Folio);
        }

        private string obtenerCliente(int TipoDocumento, string DOCClave)
        {
            string cliente = "";
            switch (TipoDocumento)
            {
                case 1: //Venta
                    cliente = (
                        from ve in db.Venta
                        join cl in db.Cliente
                            on new { CTEClave = ve.Cliente, ve.VENClave } equals new { CTEClave = cl.CTEClave, VENClave = DOCClave }
                        select cl.Clave + " - " + cl.RazonSocial
                    ).FirstOrDefault();
                    break;
                case 6: //MOVALM
                    cliente = (
                        from mov in db.MOVALM
                        join alm in db.Almacen
                            on new { CTEClave = mov.ALMDestino, VENClave = DOCClave } equals new { CTEClave = alm.ALMClave, VENClave = alm.ALMClave }
                        select alm.Clave + " - " + alm.Nombre
                    ).FirstOrDefault();
                    break;
                case 8: //Traslado
                    cliente = (
                        from tr in db.Traslado
                        join suc in db.Sucursal
                            on new { CTEClave = tr.SUCDestino, VENClave = tr.TRSClave } equals new { CTEClave = suc.SUCClave, VENClave = DOCClave }
                        select tr.Almacen.Clave + " - " + tr.Almacen.Nombre
                    ).FirstOrDefault();
                    break;
                case 10: //Compra
                    cliente = (
                        from dc in db.DevCompra
                        join prov in db.Proveedor
                            on new { CTEClave = dc.PRVClave, VENClave = dc.DEVClave } equals new { CTEClave = prov.PRVClave, VENClave = DOCClave }
                        select prov.Clave + " - " + prov.RazonSocial
                    ).FirstOrDefault();
                    break;
            }
            return cliente;
        }
        
        private string insertarMovUbc(
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

        #endregion

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
