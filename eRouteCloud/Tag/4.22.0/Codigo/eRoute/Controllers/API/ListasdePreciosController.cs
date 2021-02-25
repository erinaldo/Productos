using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eRoute.Models;
using System.Web.Script.Serialization;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;

namespace eRoute.Controllers.API
{
    
    public class ListasdePreciosController : ApiController
    {
        RouteEntities db = new RouteEntities();
        //obteniendo el detalle de producto
        [HttpGet]
        [ActionName("ObtenerlistasdePrecios")]
        public IHttpActionResult ObtenerlistasdePrecios()
        {

            var product = (from pro in db.Producto
                           join proV in db.PrecioProductoVig on pro.ProductoClave equals proV.ProductoClave
                           select new { pro.ProductoClave, pro.Nombre, UnidadProduccion = pro.UnidadProduccion.ToString(), proV.PPVFechaInicio, proV.Precio, proV.PrecioMinimo, proV.PrecioSugerido, TipoEstado = proV.TipoEstado.ToString() }

                          );
            if (product.Count() <= 0)
            {
                //    centro.Add(new cVARValor { VARCodigo = "", VAVClave = "", Grupo = "", Estado = "" });
            }


            return Json(product);
        }



        //Mostrando datos en tabla Precios 
        [HttpGet]
        [ActionName("ObtenerPrecios")]
        public IHttpActionResult ObtenerPrecios()
        {
            var q = (from cust in db.Precio
                     from ord in db.VAVDescripcion
                     from VD2 in db.VAVDescripcion
                     where (cust.CFVTipo == 0 || cust.CFVTipo.ToString() == ord.VAVClave) && ord.VADTipoLenguaje == "EM" && cust.TipoEstado == 1 && ord.VARCodigo == "FVENTA" && cust.TipoEstado.ToString() == VD2.VAVClave && VD2.VADTipoLenguaje == "EM" && VD2.VARCodigo == "EDOREG"
                     select new
                     {
                         cust.PrecioClave,
                         cust.Nombre,
                         TipoEstado = VD2.Descripcion,
                         CFVTipo = cust.CFVTipo == 0 ? "Ninguna" :
                        cust.CFVTipo.ToString() == ord.VAVClave ? ord.Descripcion : ""
                     }).Distinct();
            return Json(q);
        }

        //Mostrando datos en tabla Producto
        [HttpGet]
        [ActionName("ObtenerProductos")]
        public IHttpActionResult ObtenerProductos()
        {

            var valter = (
                from PRO in db.Producto
                join PRU in db.ProductoUnidad on PRO.ProductoClave equals PRU.ProductoClave
                join SEM in db.SubEmpresa on PRO.SubEmpresaID equals SEM.SubEmpresaId
                join VD in db.VAVDescripcion on "UNIDADV" equals VD.VARCodigo
                join VDF in db.VAVDescripcion on "PRUEDO" equals VDF.VARCodigo
                where PRO.TipoFase == 1 && PRU.TipoEstado == 1 && VD.VADTipoLenguaje == "EM" && PRU.PRUTipoUnidad.ToString() == VD.VAVClave && PRU.TipoEstado.ToString() == VDF.VAVClave
                select new
                {
                    PRO.ProductoClave,
                    PRO.Nombre,
                    PRO.NombreLargo,
                    PRO.Id,
                    TipoFase = VDF.Descripcion,
                    // VD.Descripcion
                }


                ).Distinct();
            return Json(valter);
        }

        //mostar Vigencias x producto seleccionado
        [HttpGet]
        [ActionName("ObtenerVigencia")]
        public IHttpActionResult ObtenerVigencia(string PrecioClave,string ProductoClave, short PRUTipoUnidad, string Nombre)
        {
                 
            var valter = (
                from PPV in db.PrecioProductoVig
                join est in db.VAVDescripcion on PPV.TipoEstado.ToString() equals est.VAVClave
                where est.VARCodigo == "EDOREG" && est.VADTipoLenguaje == "EM"
                join p in db.Producto on ProductoClave equals p.ProductoClave
                where PPV.PrecioClave == PrecioClave && PPV.ProductoClave == ProductoClave && PPV.PRUTipoUnidad == PRUTipoUnidad
                select new
                {
                   PPV.PPVFechaInicio,
                   PPV.Precio,
                   TipoEstado = est.Descripcion,
                   PPV.FechaFin,
                   p.Nombre,
                   p.MUsuarioID,
                   PPV.MFechaHora
                   
                }


                );
            return Json(valter);
        }

        //mostarValorPrecio
        [HttpGet]
        [ActionName("ObtenerValorPrecio")]
        public IHttpActionResult ObtenerValorPrecio(string PrecioClave)
        {

            var valter = (
                from P in db.Precio
                where P.PrecioClave == PrecioClave
                select new
                {
                    P.PrecioClave,
                    TipoEstado=P.TipoEstado.ToString(),
                    P.Nombre,
                    P.Jerarquia,
                    CFVtipo= P.CFVTipo.ToString()

                }


                );
            return Json(valter);
        }
        //obtenerUNIDADV
        [HttpGet]
        [ActionName("ObtenerUNIDADV")]
        public IHttpActionResult ObtenerUNIDADV(string ProductoClave)
        {

            var innerQuery = (from x in db.ProductoUnidad
                              where x.ProductoClave == ProductoClave && x.TipoEstado == 1
                              select x.PRUTipoUnidad.ToString());
            var result = (from f in db.VAVDescripcion
                          where f.VARCodigo == "UNIDADV" && f.VADTipoLenguaje == "EM" && innerQuery.ToList().Contains(f.VAVClave)
                          select new { f.Descripcion, f.VAVClave }).ToList();
            return Json(result);
        }

        //Validando Clave Precio
        [HttpGet]
        [ActionName("ValidarTerminalClave")]
        public IHttpActionResult ValidarCodigoUnico(string TerminalClave)
        {
            RouteEntities db = new RouteEntities();
            return Json(db.Precio.ToList().Exists(x => x.PrecioClave == TerminalClave));
        }

        //Validando  si el precio esta cambiadoPrecioCambiado
        [HttpGet]
        [ActionName("ValidarPcambiado")]
        public IHttpActionResult ValidarPcambiado(string PrecioClave, string ProductoClave, short Unidad, double Precio)
        {
            RouteEntities db = new RouteEntities();
            return Json(db.PrecioProductoVig.ToList().Exists(x => x.PrecioClave == PrecioClave && x.ProductoClave == ProductoClave && x.PRUTipoUnidad == Unidad && x.Precio != Precio ));
        }

       
        //¨GuardarListadePrecios
        [HttpPost]
        public bool Grabar(Precio listaPrecios)
        {
            Precio cLista;

            bool nuevo = !db.Precio.ToList().Exists(x => x.PrecioClave == listaPrecios.PrecioClave);

            if (nuevo) {
                cLista = new Precio();
                cLista.PrecioClave = listaPrecios.PrecioClave;

            }
            else
            {
                cLista = db.Precio.ToList().First(x => x.PrecioClave == listaPrecios.PrecioClave);
            }

            
            if (listaPrecios.CFVTipo==null) {
                cLista.CFVTipo = 0;
            }
            else
            {
                cLista.CFVTipo = listaPrecios.CFVTipo;
            }
            cLista.Jerarquia = listaPrecios.Jerarquia;
            cLista.Nombre = listaPrecios.Nombre;            
            cLista.TipoEstado = listaPrecios.TipoEstado;
            cLista.MUsuarioID = listaPrecios.MUsuarioID;
            cLista.MFechaHora = DateTime.Now;
            if (nuevo) {


                db.Precio.Add(cLista);
                if (listaPrecios.PrecioProductoVig.Count > 0) {
                    foreach (PrecioProductoVig preciovig in listaPrecios.PrecioProductoVig)
                    {
                        

                        PrecioProductoVig pre = new PrecioProductoVig();
                        pre.ProductoClave = preciovig.ProductoClave;
                        pre.PrecioClave = listaPrecios.PrecioClave;
                        pre.PRUTipoUnidad = preciovig.PRUTipoUnidad;
                        pre.PPVFechaInicio = preciovig.PPVFechaInicio.Date;
                        pre.Precio = preciovig.Precio;
                        pre.PrecioMinimo = preciovig.PrecioMinimo;
                        pre.PrecioSugerido = preciovig.PrecioSugerido;
                        pre.TipoEstado = preciovig.TipoEstado;
                        pre.FechaFin = DateTime.MaxValue;
                        pre.Exclusion = preciovig.Exclusion;
                        pre.MFechaHora = preciovig.PPVFechaInicio.Date;
                        pre.MUsuarioID = listaPrecios.MUsuarioID;

                        db.PrecioProductoVig.Add(pre);
                    }


                }
            }
            else {//editar
                foreach (PrecioProductoVig preciovig in listaPrecios.PrecioProductoVig)
                {

                    if (db.PrecioProductoVig.ToList().Exists(x => x.PrecioClave == preciovig.PrecioClave && preciovig.ProductoClave == x.ProductoClave && preciovig.PRUTipoUnidad == x.PRUTipoUnidad))
                    {


                        if (!db.PrecioProductoVig.ToList().Exists(x => x.PrecioClave == preciovig.PrecioClave && preciovig.ProductoClave == x.ProductoClave && preciovig.PRUTipoUnidad == x.PRUTipoUnidad && x.PPVFechaInicio == preciovig.PPVFechaInicio.Date && x.Precio == preciovig.Precio  ))

                        {
                            PrecioProductoVig pre = new PrecioProductoVig();
                            db.PrecioProductoVig.ToList().First(x => x.PrecioClave == preciovig.PrecioClave && preciovig.ProductoClave == x.ProductoClave && preciovig.PRUTipoUnidad == x.PRUTipoUnidad).FechaFin = preciovig.FechaAux.AddDays(-1).Date;
                            pre.ProductoClave = preciovig.ProductoClave;
                            pre.PrecioClave = listaPrecios.PrecioClave;
                            pre.PRUTipoUnidad = preciovig.PRUTipoUnidad;
                            pre.PPVFechaInicio = preciovig.PPVFechaInicio.Date;
                            pre.Precio = preciovig.Precio;
                            pre.PrecioMinimo = preciovig.PrecioMinimo;
                            pre.PrecioSugerido = preciovig.PrecioSugerido;
                            pre.TipoEstado = preciovig.TipoEstado;
                            pre.FechaFin = DateTime.MaxValue.Date;
                            pre.Exclusion = preciovig.Exclusion;
                            pre.MFechaHora = DateTime.Now;
                            pre.MUsuarioID = listaPrecios.MUsuarioID;
                            db.PrecioProductoVig.Add(pre);

                        }
                        
                    }
                    else {

                        PrecioProductoVig pre = new PrecioProductoVig();
                        pre.ProductoClave = preciovig.ProductoClave;
                        pre.PrecioClave = listaPrecios.PrecioClave;
                        pre.PRUTipoUnidad = preciovig.PRUTipoUnidad;
                        pre.PPVFechaInicio = preciovig.PPVFechaInicio.Date;
                        pre.Precio = preciovig.Precio;
                        pre.PrecioMinimo = preciovig.PrecioMinimo;
                        pre.PrecioSugerido = preciovig.PrecioSugerido;
                        pre.TipoEstado = preciovig.TipoEstado;
                        pre.FechaFin = preciovig.FechaFin;
                        pre.Exclusion = preciovig.Exclusion;
                        pre.MFechaHora = DateTime.Now;
                        pre.MUsuarioID = listaPrecios.MUsuarioID;

                        db.PrecioProductoVig.Add(pre);
                    }
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
            }
            return true;
        }

        
        //ObtenerPrecioProductoVig
        [HttpGet]
        [ActionName("ObtenerlistaDetalle")]
        public IHttpActionResult ObtenerlistaDetalle(string PrecioClave)
        {

           // DateTime fnac = Convert.ToDateTime("15/08/2008");
               //    DateTime fnac = DateTime.Parse("9999-12-31 00:00:00.000");
            DateTime Factual = DateTime.Now;
            var valores = (from PPV in db.PrecioProductoVig
                           join p in db.Producto on PPV.ProductoClave equals p.ProductoClave
                           where PPV.PrecioClave == PrecioClave && (PPV.PPVFechaInicio <= Factual.Date && PPV.FechaFin >= Factual.Date)
                           select new {
                               
                               PPV.ProductoClave,
                               p.Nombre,
                               PRUTipoUnidad = PPV.PRUTipoUnidad.ToString(),
                               PPVFechaInicio = PPV.PPVFechaInicio,
                               PPV.Precio,
                               PPV.PrecioMinimo,
                               PPV.PrecioSugerido,
                               TipoEstado = PPV.TipoEstado.ToString(),
                               Consultado = 1,
                               id = ""
                               
                                
                           });

            return Json(valores);
        }
    }
}