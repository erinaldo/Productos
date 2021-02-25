using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SellingWS.Models;
using SellingWS.Models.API;
using System.Data.SqlClient;

namespace SellingWS.Controllers
{
    public class ConteoController : ApiController
    {
        private SellingEntities db = new SellingEntities();

        [HttpGet]
        public IEnumerable<ApiConteoAsignacion> ObtenerAsignados(string ClaveUsuario)
        {
            if (db.Usuario.ToList().Exists(x => x.Referencia == ClaveUsuario))
            {
                IEnumerable<ApiConteoAsignacion> conteos = (
                   from c in db.Conteo
                   join ca in db.ConteoAsignacion on c.CONClave equals ca.CONClave
                   join u in db.Usuario on ca.USRClave equals u.USRClave
                   join ub in db.Ubicacion on ca.UBCClave equals ub.UBCClave
                   join h in db.Hueco on new { ub.HUEClave, ub.ESTClave } equals new { h.HUEClave, h.ESTClave }
                   join e in db.Estructura on h.ESTClave equals e.ESTClave
                   join a in db.Area on e.AREClave equals a.AREClave
                   join al in db.Almacen on a.ALMClave equals al.ALMClave
                   where c.Estado == 2 && u.Referencia == ClaveUsuario   
                   orderby a.Clave, e.SecuenciaRecoleccion, e.Clave, h.Nivel, h.Columna, ub.Ubicacion1
                   select new ApiConteoAsignacion
                   {
                       USRClave = u.USRClave,
                       CONClave = c.CONClave,
                       ALMClave = al.ALMClave,
                       Almacen = al.Nombre,
                       Area = a.Clave,
                       Estructura = e.Clave,
                       Nivel = h.cNivel,
                       Columna = h.Columna,
                       UBCClave = ub.UBCClave,
                       Ubicacion = ub.Ubicacion1,
                       Estado = (ca.EstadoConteo == null ? 1 : ca.EstadoConteo)
                   }                    
                );               

                if (conteos == null || conteos.Count() == 0) //No existen conteos asignados para el usuario
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.OK, new { conteoNoAsignado = true }));

                return conteos;
            }
            else {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.OK, new { usuarioNoExiste = true }));
            }
            
        }

        [HttpGet]
        public bool ActualizarEstadoUbicacion(string CONClave, string UBCClave, int Estado, string USRClave)
        {
            try
            {
                ConteoAsignacion conteo = db.ConteoAsignacion.SingleOrDefault(x => x.CONClave == CONClave && x.UBCClave == UBCClave);
                conteo.EstadoConteo = Estado;
                conteo.MFechaHora = DateTime.Now;
                conteo.MUsuarioId = USRClave;
                db.SaveChanges();

                return true;
            }
            catch (Exception e) {
                return false;
            }                
        }

        [HttpGet]
        public bool validaUbicacionConteo(string ubicacion, string ALMClave)
        {

            var origen = (from u in db.Ubicacion
                          where (u.Ubicacion1.Replace("-", "") == ubicacion.Replace("-", "") && u.Baja == false)
                          join e in db.Estructura
                              on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                          select new { Estructura = e, Ubicacion = u }
            ).FirstOrDefault();

            
            if(origen == null)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, Resources.Mensajes.Recibo_Ubicacion_NotFound));


            var apartados = (from u in db.Ubicacion
                      where (u.Ubicacion1.Replace("-", "") == ubicacion.Replace("-", "") && u.Baja == false)
                      join peu in db.prd_exist_uba
                            on new { u.UBCClave } equals new { peu.UBCClave}
                      select new { prd_exist_uba = peu }
            ).ToList();

            int cuantos = db.Database.SqlQuery<int>("select count(u.Ubicacion) from Ubicacion u inner join prd_exist_uba peu on peu.UBCClave = u.UBCClave " +
                                "and u.Ubicacion = @Ubicacion and peu.apartado > 0",
                                new SqlParameter("@Ubicacion", ubicacion)).First();

            if (cuantos == 0)
                return true;
            else
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, Resources.Mensajes.Conteo_Ubicacion_Apartado));
        }



        [HttpGet]
        public bool ValidarProducto(string PROClave, string ALMClave)
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
                //throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Producto_NotFound"));
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.OK, new { productoNoExiste = true }));
            }

            return true;
        }

        [HttpGet]
        public bool RealizarConteoManual(string PROClave, string Cantidad, string UBCClave, string ALMClave, string USRClave)
        {
            Almacen alm = db.Almacen.SingleOrDefault(a =>
                 a.Baja == false &&
                 a.ALMClave == ALMClave);

            alm.Stage = db.Database.SqlQuery<String>("select Stage from Almacen where ALMClave = @ALMClave", new SqlParameter("@ALMClave", ALMClave)).FirstOrDefault();

            Usuario user = db.Usuario.SingleOrDefault(u => 
                u.Baja == false &&
                u.Referencia == USRClave);

            if (alm == null || alm.Stage == null || alm.Stage.ToString() == "")
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.OK, new { StageNoExiste = true }));

            Ubicacion ubi = db.Ubicacion.SingleOrDefault(x => x.Ubicacion1.Replace("-", "") == UBCClave.Replace("-", ""));
            
            if(ubi == null)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.OK, new { UbicacionNoExiste = true }));

            string[] PROClaveArray = PROClave.Split(',');
            string[] CantidadArray = Cantidad.Split(',');
            List<prd_exist_uba> detalles = db.prd_exist_uba.Where(x => x.UBCClave == ubi.UBCClave).ToList();
            string productos = "";
            bool encontrado = false;
            int vueltas = 0;
            decimal? diferencia = 0;

            foreach(prd_exist_uba peu in detalles)
            {
                encontrado = false;
                diferencia = 0;
                for (int i = 0; i < PROClaveArray.Length; i++) {
                    PROClave = PROClaveArray[i];
                    Cantidad = CantidadArray[i];

                    Producto producto = db.Producto.SingleOrDefault(p =>
                             p.Baja == false &&
                             p.Clave.Replace("-", "") == PROClave.Replace("-", "") ||
                             p.NumParte == PROClave ||
                             p.Alterno1 == PROClave ||
                             p.Alterno2 == PROClave ||
                             p.Alterno3 == PROClave ||
                             p.ProductoUnidad.Any(x => x.GTIN == PROClave && x.Factor == 1)
                           );

                    if (producto == null && vueltas == 0)
                        productos += PROClave + ",";
                    else if(producto != null)
                    {
                        
                        if (producto.PROClave == peu.PROClave)
                        {
                            diferencia = peu.Existencia - decimal.Parse(Cantidad);
                            peu.Existencia = decimal.Parse(Cantidad);
                            peu.MUsuarioId = user.USRClave;
                            peu.MFechaHora = DateTime.Now;
                            encontrado = true;
                            break;
                        }
                        else
                            encontrado = false;
                    }
                }

                if (!encontrado) 
                {
                    diferencia = peu.Existencia;
                    peu.Existencia = 0;
                    peu.MUsuarioId = user.USRClave;
                    peu.MFechaHora = DateTime.Now;
                }
                vueltas++;
                
                prd_exist_uba destinoPeu = db.prd_exist_uba.FirstOrDefault(x => x.PROClave == peu.PROClave && x.UBCClave == alm.Stage);

                if (destinoPeu != null)
                {
                    destinoPeu.Existencia += diferencia;
                    destinoPeu.MUsuarioId = user.USRClave;
                    destinoPeu.MFechaHora = DateTime.Now;
                }
                else 
                {
                    destinoPeu = new prd_exist_uba
                    {
                        Apartado = 0,
                        Bloqueado = 0,
                        Estado = 1,
                        Existencia = diferencia,
                        PROClave = peu.PROClave,
                        UBCClave = alm.Stage.ToString(),
                        MFechaHora = DateTime.Now,
                        MUsuarioId = user.USRClave
                    };

                    db.prd_exist_uba.Add(destinoPeu);
                }
                db.SaveChanges();
            }

            for (int i = 0; i < PROClaveArray.Length; i++) 
            {
                PROClave = PROClaveArray[i];
                Cantidad = CantidadArray[i];

                Producto producto = db.Producto.SingleOrDefault(p =>
                             p.Baja == false &&
                             p.Clave.Replace("-", "") == PROClave.Replace("-", "") ||
                             p.NumParte == PROClave ||
                             p.Alterno1 == PROClave ||
                             p.Alterno2 == PROClave ||
                             p.Alterno3 == PROClave ||
                             p.ProductoUnidad.Any(x => x.GTIN == PROClave && x.Factor == 1)
                           );

                if (producto != null)
                    PROClave = producto.PROClave;


                prd_exist_uba OrigenPeu = db.prd_exist_uba.FirstOrDefault(x => x.PROClave == PROClave && x.UBCClave == ubi.UBCClave);

                if (OrigenPeu == null) 
                {
                    OrigenPeu = new prd_exist_uba
                    {
                        Apartado = 0,
                        Bloqueado = 0,
                        Estado = 1,
                        Existencia = decimal.Parse(Cantidad),
                        PROClave = PROClave,
                        UBCClave = alm.Stage.ToString(),
                        MFechaHora = DateTime.Now,
                        MUsuarioId = user.USRClave
                    };

                    db.prd_exist_uba.Add(OrigenPeu);

                    prd_exist_uba destinoPeu = db.prd_exist_uba.FirstOrDefault(x => x.PROClave == PROClave && x.UBCClave == alm.Stage);
                    diferencia = 0 - decimal.Parse(Cantidad);

                    if (destinoPeu != null)
                    {
                        destinoPeu.Existencia += diferencia;
                        destinoPeu.MUsuarioId = user.USRClave;
                        destinoPeu.MFechaHora = DateTime.Now;
                    }
                    else
                    {
                        destinoPeu = new prd_exist_uba
                        {
                            Apartado = 0,
                            Bloqueado = 0,
                            Estado = 1,
                            Existencia = diferencia,
                            PROClave = PROClave,
                            UBCClave = alm.Stage.ToString(),
                            MFechaHora = DateTime.Now,
                            MUsuarioId = user.USRClave
                        };

                        db.prd_exist_uba.Add(destinoPeu);
                    }
                    db.SaveChanges();
                }
            }

            return true;
        }

        [HttpGet]
        public ApiProductoContado ActualizarConteo(string CONClave, string UBCClave, string PROClave, decimal Cantidad, string USRClave)
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
                //throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Producto_NotFound"));
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.OK, new { productoNoExiste = true }));
            }

            Conteo conteo = db.Conteo.SingleOrDefault(x => x.CONClave == CONClave);
            if (conteo.Tipo == 2) //Conteo parcial, validar que el producto exista en ConteoConfig
            {
                //String det = db.Database.SqlQuery<String>("select PROClave from ConteoConfig where CONClave = '" + CONClave + "' and PROClave = '" + PROClave + "'", null).FirstOrDefault();
                                
                if (!conteo.ConteoConfig.ToList().Exists(x => x.PROClave == PROClave))
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.OK, new { productoNoConfigurado = true }));
            }

            if (!conteo.ConteoDetalle.ToList().Exists(x => x.UBCClave == UBCClave && x.PROClave == PROClave))
            {
                ConteoDetalle detalle = new ConteoDetalle();
                var nuevoId = db.Database.SqlQuery<string>("SELECT Right(newid(),20)").First();
                detalle.CONClave = conteo.CONClave;
                detalle.CNDClave = nuevoId;
                detalle.UBCClave = UBCClave;
                detalle.PROClave = PROClave;
                detalle.Fisica = Cantidad;
                detalle.MUsuarioId = USRClave;
                detalle.MFechaHora = DateTime.Now;
                conteo.ConteoDetalle.Add(detalle);
            }
            else {
                Cantidad += (decimal)conteo.ConteoDetalle.First(x => x.UBCClave == UBCClave && x.PROClave == PROClave).Fisica;
                if (Cantidad > 0)
                {
                    conteo.ConteoDetalle.First(x => x.UBCClave == UBCClave && x.PROClave == PROClave).Fisica = Cantidad;
                    conteo.ConteoDetalle.First(x => x.UBCClave == UBCClave && x.PROClave == PROClave).MUsuarioId = USRClave;
                    conteo.ConteoDetalle.First(x => x.UBCClave == UBCClave && x.PROClave == PROClave).MFechaHora = DateTime.Now;
                }
                else {
                    conteo.ConteoDetalle.Remove(conteo.ConteoDetalle.First(x => x.UBCClave == UBCClave && x.PROClave == PROClave));
                }
            }

            db.SaveChanges();

            ApiProductoContado prod = new ApiProductoContado();
            prod.PROClave = producto.PROClave;
            prod.Nombre = producto.Nombre;
            prod.Cantidad = (double)Cantidad;
            prod.UBCClave = UBCClave;
            prod.Ubicacion = db.Ubicacion.First(u => u.UBCClave == UBCClave).Ubicacion1;
            return prod;
        }

        [HttpGet]
        public bool ReiniciarConteoUbicacion(string CONClave, string UBCClave, string USRClave)
        {
            try
            {
                Conteo conteo = db.Conteo.SingleOrDefault(x => x.CONClave == CONClave);

                ConteoAsignacion asignacion = conteo.ConteoAsignacion.SingleOrDefault(x => x.UBCClave == UBCClave);
                asignacion.EstadoConteo = 2;
                asignacion.MFechaHora = DateTime.Now;
                asignacion.MUsuarioId = USRClave;

                List<ConteoDetalle> detalles = conteo.ConteoDetalle.Where(x => x.CONClave == CONClave && x.UBCClave == UBCClave).ToList();
                if (detalles.Count > 0) {
                    foreach (ConteoDetalle detalle in detalles) {
                        conteo.ConteoDetalle.Remove(detalle);
                    }
                }
                conteo.MFechaHora = DateTime.Now;
                conteo.MUsuarioId = USRClave;

                db.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
