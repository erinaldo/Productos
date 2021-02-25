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

namespace eRoute.Controllers.API
{
    public class ProductoController : ApiController
    {
        RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            //string idioma;

            var lenguaje = (from config in db.CONHist
                            orderby config.CONHistFechaInicio descending
                            select config.TipoLenguaje).Take(1).ToList();
            //var cad = lenguaje[0];
            //idioma = lenguaje[0];
            return lenguaje[0];
        }

        [HttpGet]
        [ActionName("ObtenerProductos")]
        public IHttpActionResult ObtenerProductos()
        {
            string lenguaje = ObtenerLenguaje();

            var producto = (from pro in db.Producto
                            join VAV1 in db.VAVDescripcion on "PROTIPO" equals VAV1.VARCodigo
                            where pro.Tipo.ToString() == VAV1.VAVClave && VAV1.VADTipoLenguaje == lenguaje
                            join VAV2 in db.VAVDescripcion on "PROFASE" equals VAV2.VARCodigo
                            where pro.TipoFase.ToString() == VAV2.VAVClave && VAV2.VADTipoLenguaje == lenguaje
                            select new
                            {
                                pro.ProductoClave,
                                pro.Nombre,
                                pro.NombreLargo,
                                pro.Id,
                                Tipo = VAV1.Descripcion,
                                TipoFase = VAV2.Descripcion
                            }
                            ).ToList();

            return Json(producto);
        }


        [HttpGet]
        [ActionName("ValidarClaveProducto")]
        public IHttpActionResult ValidarClaveProducto(string ProductoClave)
        {
            return Json(db.Producto.ToList().Exists(x => x.ProductoClave == ProductoClave));
        }

        [HttpGet]
        [ActionName("ObtenerDetalleEsquemaProducto")]
        public IHttpActionResult ObtenerDetalleEsquemaProducto(string ProductoClave)
        {
            var esquemas = (from x in db.ProductoEsquema
                            join e in db.Esquema on x.EsquemaID equals e.EsquemaID
                            where x.ProductoClave == ProductoClave
                            select new cEsquema { EsquemaID = x.EsquemaID, Nombre = e.Nombre, Clave = e.Clave }).ToList();

            return Json(esquemas);

        }

        //Obtener Esquemas asignados a la Ruta seleccionada
        [HttpGet]
        [ActionName("ObtEsquemas")]
        public IHttpActionResult ObtEsquemas(string ProductoClave)
        {
            var Esquemas = (
                from x in db.ProductoEsquema
                join e in db.Esquema on x.EsquemaID equals e.EsquemaID
                where x.ProductoClave == ProductoClave
                select new cEsquema { Clave = e.Clave, Nombre = e.Nombre, EsquemaID = x.EsquemaID }).ToList();
            return Json(Esquemas);
        }
        [HttpGet]
        [ActionName("ObtenerDetalleImpuestoProducto")]
        public IHttpActionResult ObtenerDetalleImpuestoProducto(string ProductoClave)
        {
            var impuestos = (
                from x in db.ProductoImpuesto
                join e in db.Impuesto on x.ImpuestoClave equals e.ImpuestoClave
                where x.ProductoClave == ProductoClave
                select new { x.ImpuestoClave, x.ProductoClave, e.Nombre, e.Abreviatura, TipoEstado = x.TipoEstado.ToString() }).ToList();

            return Json(impuestos);
        }

        [HttpGet]
        [ActionName("ObtenerDetalleProductoUnidad")]
        public IHttpActionResult ObtenerDetalleProductoUnidad(string ProductoClave)
        {
            var productoUnidad = (from x in db.ProductoUnidad
                                  where x.ProductoClave == ProductoClave
                                  select new cProductoUnidad
                                  {
                                      PRUTipoUnidad = x.PRUTipoUnidad.ToString(),
                                      CodigoBarras = x.CodigoBarras,
                                      TipoEstado = x.TipoEstado.ToString(),
                                      KgLts = x.KgLts,
                                      Volumen = x.Volumen,
                                      PorcentajeVariacion = x.PorcentajeVariacion,
                                      DecimalProducto = x.DecimalProducto,
                                      ValorPuntos = x.ValorPuntos,
                                      Contenedor = x.Contenedor
                                  }).ToList();

            for (int i = 0; i < productoUnidad.Count; i++)
            {
                cProductoUnidad oProductoUnidad = productoUnidad[i];
                ObtenerProductoDetalle(ref oProductoUnidad, productoUnidad[i].PRUTipoUnidad, ProductoClave);
            }

            return Json(productoUnidad);
        }
        public void ObtenerProductoDetalle(ref cProductoUnidad prodUni, string pruTipo, string productoClave)
        {
            var productoDetalle = (from pd in db.ProductoDetalle
                                   join p in db.Producto on pd.ProductoDetClave equals p.ProductoClave
                                   where pd.PRUTipoUnidad.ToString() == pruTipo && pd.ProductoClave == productoClave
                                   select new cProductoDetalle { ProductoClave = pd.ProductoClave, NombreProducto = p.Nombre, PRUTipoUnidad = pd.PRUTipoUnidad, ProductoDetClave = pd.ProductoDetClave, Prestamo = pd.Prestamo, Factor = pd.Factor }
               ).ToList();

            prodUni.ProductoDetalle = productoDetalle;
        }

        [HttpGet]
        [ActionName("ObtenerDetalleProductoEquivalente")]
        public IHttpActionResult ObtenerDetalleProductoEquivalente(string ProductoClave)
        {
            var productoEquiv = (from x in db.ProductoEquivalente
                                 join e in db.Producto on x.ProductoPqvClave equals e.ProductoClave
                                 where x.ProductoClave == ProductoClave
                                 select new { ProductoClave = x.ProductoClave, Nombre = e.Nombre, Estado = x.Estado.ToString(), ProductoPqvClave = x.ProductoPqvClave }).ToList();

            return Json(productoEquiv);
        }

        [HttpGet]
        [ActionName("ObtenerEmpresas")]
        public IHttpActionResult ObtenerEmpresas()
        {
            var empresas = (from x in db.SubEmpresa
                            where x.TipoEstado == 1
                            select new
                            {
                                x.SubEmpresaId,
                                x.NombreCorto,
                                x.NombreEmpresa
                            }
                ).ToList();

            return Json(empresas);
        }



        [HttpGet]
        [ActionName("BuscarProductosEquivalentes")]
        public IHttpActionResult BuscarProductosEquivalentes()
        {
            var producto = (from pro in db.Producto
                            join VAV1 in db.VAVDescripcion on "PROTIPO" equals VAV1.VARCodigo
                            where pro.Tipo.ToString() == VAV1.VAVClave && VAV1.VADTipoLenguaje == "EM"
                            join VAV2 in db.VAVDescripcion on "PROFASE" equals VAV2.VARCodigo
                            where pro.TipoFase.ToString() == VAV2.VAVClave && VAV2.VADTipoLenguaje == "EM"
                            where pro.TipoFase == 1
                            select new
                            {
                                pro.ProductoClave,
                                pro.Nombre,
                                pro.NombreLargo,
                                pro.Id,
                                Tipo = VAV1.Descripcion,
                                TipoFase = VAV2.Descripcion
                            }
                            ).ToList();

            return Json(producto);
        }

        [HttpGet]
        [ActionName("obtenerProductosRelacionados")]
        public IHttpActionResult obtenerProductosRelacionados()
        {
            var producto = (from pro in db.Producto
                            where pro.Contenido == true
                            select new { pro.ProductoClave, pro.Nombre, pro.NombreLargo, pro.Id, pro.Tipo, pro.TipoFase }).ToList();

            return Json(producto);
        }

        [HttpGet]
        [ActionName("ObtenerProducto")]
        public IHttpActionResult ObtenerProducto(string ProductoClave)
        {
            var producto = (from pro in db.Producto
                                //join Em in db.SubEmpresa on pro.SubEmpresaID equals Em.SubEmpresaId
                            where pro.ProductoClave == ProductoClave
                            select new
                            {
                                pro.ProductoClave,
                                pro.Nombre,
                                pro.LimiteDescuento,
                                pro.CaducoPermitido,
                                pro.Nota,
                                pro.Venta,
                                pro.DecimalProducto,
                                pro.Contenido,
                                TipoAdquisicion = pro.TipoAdquisicion.ToString(),
                                SubEmpresaID = pro.SubEmpresaID.ToString(),
                                //SubEmpresaID = Em.NombreCorto,
                                pro.NombreLargo,
                                pro.Id,
                                Tipo = pro.Tipo.ToString(),
                                TipoFase = pro.TipoFase.ToString(),
                                pro.CantidadProduccion,
                                pro.ClaveSAT,
                                UnidadProduccion = pro.UnidadProduccion.ToString(),
                            }).ToList();

            return Json(producto);
        }

        [HttpPost]
        public bool GuardarProducto(Producto producto)
        {
            var innerQuery = (from x in db.ProductoUnidad where x.ProductoClave == "100100" && x.TipoEstado == 1 select x.PRUTipoUnidad.ToString());
            var result = (from f in db.VAVDescripcion where f.VARCodigo == "UNIDADV" && f.VADTipoLenguaje == "EM" && innerQuery.ToList().Contains(f.VAVClave) select new { f.Descripcion }).ToList();

            if (producto != null)
            {
                bool nuevo = !db.Producto.ToList().Exists(x => x.ProductoClave == producto.ProductoClave);
                Producto cProducto;

                if (nuevo)
                {
                    cProducto = new Producto();
                    cProducto.ProductoClave = producto.ProductoClave;
                }
                else
                {
                    cProducto = db.Producto.ToList().First(x => x.ProductoClave == producto.ProductoClave);
                }

                //Aqui van los datos que se van a guardar
                cProducto.Nombre = producto.Nombre;
                cProducto.NombreLargo = producto.NombreLargo;
                cProducto.Id = producto.Id;
                cProducto.ClaveSAT = producto.ClaveSAT;
                cProducto.Tipo = producto.Tipo;
                cProducto.SubEmpresaID = producto.SubEmpresaID;
                //cProducto.SubEmpresaID = "3HE1XZOGAFZ3XKL";
                cProducto.LimiteDescuento = producto.LimiteDescuento;
                cProducto.TipoFase = producto.TipoFase;
                cProducto.Contenido = producto.Contenido;
                cProducto.Venta = producto.Venta;
                cProducto.DecimalProducto = producto.DecimalProducto;
                cProducto.CaducoPermitido = producto.CaducoPermitido;
                cProducto.TipoAdquisicion = producto.TipoAdquisicion;
                cProducto.Nota = producto.Nota;

                cProducto.CantidadProduccion = (producto.CantidadProduccion == null) ? 0 : producto.CantidadProduccion;
                cProducto.UnidadProduccion = (producto.UnidadProduccion == null) ? 0 : producto.UnidadProduccion;

                cProducto.MFechaHora = DateTime.Now;
                cProducto.MUsuarioID = producto.MUsuarioID;

                if (nuevo)
                {
                    //Se agregan los esquemas correspondientes al producto
                    if (producto.ProductoEsquema.Count > 0)
                    {
                        foreach (ProductoEsquema pro in producto.ProductoEsquema)
                        {
                            ProductoEsquema prodEsq = new ProductoEsquema();
                            prodEsq.EsquemaID = pro.EsquemaID;
                            prodEsq.ProductoClave = cProducto.ProductoClave;
                            prodEsq.MFechaHora = DateTime.Now;
                            prodEsq.MUsuarioID = producto.MUsuarioID;
                            db.ProductoEsquema.Add(prodEsq);
                        }
                    }
                    //Se agregan los impuestos correspondientes al producto
                    if (producto.ProductoImpuesto.Count > 0)
                    {
                        foreach (ProductoImpuesto pro in producto.ProductoImpuesto)
                        {
                            ProductoImpuesto prodImp = new ProductoImpuesto();
                            prodImp.ImpuestoClave = pro.ImpuestoClave;
                            prodImp.ProductoClave = cProducto.ProductoClave;
                            prodImp.TipoEstado = 1;
                            prodImp.MFechaHora = DateTime.Now;
                            prodImp.MUsuarioID = producto.MUsuarioID;
                            db.ProductoImpuesto.Add(prodImp);
                        }
                    }
                    //Se agregan las unidades de venta
                    if (producto.ProductoUnidad.Count > 0)
                    {
                        foreach (ProductoUnidad pro in producto.ProductoUnidad)
                        {
                            ProductoUnidad prodUni = new ProductoUnidad();
                            prodUni.ProductoClave = cProducto.ProductoClave;
                            prodUni.PRUTipoUnidad = pro.PRUTipoUnidad;
                            prodUni.CodigoBarras = pro.CodigoBarras;
                            prodUni.TipoEstado = pro.TipoEstado;
                            prodUni.KgLts = pro.KgLts == null ? 0 : pro.KgLts;
                            prodUni.Volumen = pro.Volumen == null ? 0 : pro.Volumen;
                            prodUni.PorcentajeVariacion = pro.PorcentajeVariacion == null ? 0 : pro.PorcentajeVariacion;
                            prodUni.DecimalProducto = pro.DecimalProducto;
                            prodUni.MFechaHora = DateTime.Now;
                            prodUni.MUsuarioID = producto.MUsuarioID;

                            /*Se agregan los productos relacionados por tipo**/
                            foreach (ProductoDetalle proDet in pro.ProductoDetalle)
                            {
                                ProductoDetalle proDeta = new ProductoDetalle();
                                proDeta.ProductoClave = proDet.ProductoClave;
                                proDeta.PRUTipoUnidad = proDet.PRUTipoUnidad;
                                proDeta.ProductoDetClave = proDet.ProductoDetClave;
                                proDeta.Factor = proDet.Factor;
                                proDeta.MFechaHora = DateTime.Now;
                                proDeta.MUsuarioID = producto.MUsuarioID;
                                db.ProductoDetalle.Add(proDeta);
                            }

                            db.ProductoUnidad.Add(prodUni);
                        }
                    }
                    //Se agregan los productos equivalentes
                    if (producto.ProductoEquivalente.Count > 0)
                    {
                        foreach (ProductoEquivalente pro in producto.ProductoEquivalente)
                        {
                            ProductoEquivalente proEqui = new ProductoEquivalente();
                            proEqui.ProductoClave = cProducto.ProductoClave;
                            proEqui.ProductoPqvClave = pro.ProductoClave;
                            proEqui.Estado = 1;
                            proEqui.MFechaHora = DateTime.Now;
                            proEqui.MUsuarioID = producto.MUsuarioID;
                            db.ProductoEquivalente.Add(proEqui);
                        }
                    }
                    //Se agregan los productos relaciones en la unidad de venta
                    if (producto.ProductoDetalle.Count > 0)
                    {
                        foreach (ProductoDetalle pro in producto.ProductoDetalle)
                        {
                            ProductoDetalle proDet = new ProductoDetalle();
                            //  proDet.
                        }
                    }

                    db.Producto.Add(cProducto);
                }
                else
                {
                    //Se eliminan los productos esquema -- ProductoEsquema
                    var eliminarEsq = new List<string>();
                    //    foreach (UsuarioAlmacen usuarioA in cUsuario.UsuarioAlmacen)
                    foreach (ProductoEsquema prodEsq in cProducto.ProductoEsquema)
                    {
                        if (!producto.ProductoEsquema.ToList().Exists(x => x.EsquemaID == prodEsq.EsquemaID))
                        {
                            eliminarEsq.Add(prodEsq.EsquemaID);
                        }
                    }

                    foreach (string esq in eliminarEsq)
                    {
                        db.ProductoEsquema.Remove(db.ProductoEsquema.First(x => x.EsquemaID == esq && x.ProductoClave == cProducto.ProductoClave));
                    }

                    eliminarEsq = new List<string>();
                    //Eliminar los impuestos del producto
                    foreach (ProductoImpuesto prodImp in cProducto.ProductoImpuesto)
                    {
                        if (!producto.ProductoImpuesto.ToList().Exists(x => x.ImpuestoClave == prodImp.ImpuestoClave))
                        {
                            eliminarEsq.Add(prodImp.ImpuestoClave);
                        }
                    }

                    foreach (string esq in eliminarEsq)
                    {
                        db.ProductoImpuesto.Remove(db.ProductoImpuesto.First(x => x.ImpuestoClave == esq && x.ProductoClave == cProducto.ProductoClave));
                    }

                    //Eliminar los equivalentes del producto
                    eliminarEsq = new List<string>();
                    foreach (ProductoEquivalente prodImp in cProducto.ProductoEquivalente)
                    {
                        if (!producto.ProductoEquivalente.ToList().Exists(x => x.ProductoPqvClave == prodImp.ProductoPqvClave))
                        {
                            eliminarEsq.Add(prodImp.ProductoPqvClave);
                        }
                    }

                    foreach (string esq in eliminarEsq)
                    {
                        db.ProductoEquivalente.Remove(db.ProductoEquivalente.First(x => x.ProductoPqvClave == esq && x.ProductoClave == cProducto.ProductoClave));
                    }

                    List<ProductoUnidad> eliminar = new List<ProductoUnidad>();

                    // List<string[]> eliminarDes = new List<string[]>();
                    List<ProductoDetalle> eliminarProd = new List<ProductoDetalle>();

                    //Se recorren los datos recuperaados de la consulta y se guardan en 'varValor'
                    foreach (ProductoUnidad prodUnid in cProducto.ProductoUnidad)
                    {
                        var existe = false;

                        foreach (ProductoUnidad proU in producto.ProductoUnidad)
                        {
                            if (proU.PRUTipoUnidad == prodUnid.PRUTipoUnidad && proU.PRUTipoUnidad == proU.PRUTipoUnidad)
                            {
                                existe = true;
                            }
                        }
                        if (existe == false)
                        {
                            eliminar.Add(prodUnid);
                        }

                        existe = false;
                        /*   foreach (ProductoDetalle proDet in prodUnid.ProductoDetalle)
                           {

                              //Console.wr

                           if (!cProducto.ProductoUnidad.ToList().Exists(x => x.PRUTipoUnidad == prodUnid.PRUTipoUnidad && x.ProductoClave == cProducto.ProductoClave && x.ProductoDetClave == proDet.ProductoDetClave))
                               {
                                   eliminarProd.Add(new ProductoDetalle {
                                       PRUTipoUnidad = proDet.PRUTipoUnidad,
                                       ProductoDetClave = proDet.ProductoDetClave,
                                       ProductoClave = cProducto.ProductoClave
                                   });
                               }
                           }*/
                    }

                    foreach (ProductoDetalle sProdDet in eliminarProd)
                    {
                        db.ProductoDetalle.Remove(db.ProductoDetalle.First(x => x.PRUTipoUnidad == sProdDet.PRUTipoUnidad && x.ProductoDetClave == sProdDet.ProductoDetClave && x.ProductoClave == cProducto.ProductoClave));
                    }

                    foreach (ProductoUnidad sProdUni in eliminar)
                    {
                        for (int i = 0; i < sProdUni.ProductoDetalle.Count(); i++)
                        {
                            db.ProductoDetalle.Remove(sProdUni.ProductoDetalle.ToArray()[i]);
                        }
                        db.ProductoUnidad.Remove(cProducto.ProductoUnidad.First(x => x.ProductoClave == sProdUni.ProductoClave && x.PRUTipoUnidad == sProdUni.PRUTipoUnidad));

                    }

                    //Actualizar el productoEsquema
                    foreach (ProductoEsquema pro in producto.ProductoEsquema)
                    {
                        if (!db.ProductoEsquema.ToList().Exists(x => x.EsquemaID == pro.EsquemaID && x.ProductoClave == cProducto.ProductoClave))
                        {
                            //Se agrega uno nuevo
                            ProductoEsquema prodEsq = new ProductoEsquema();
                            prodEsq.EsquemaID = pro.EsquemaID;
                            prodEsq.ProductoClave = cProducto.ProductoClave;
                            prodEsq.MFechaHora = DateTime.Now;
                            prodEsq.MUsuarioID = producto.MUsuarioID;
                            db.ProductoEsquema.Add(prodEsq);
                        }
                    }
                    //Actualizar la tabla ProductoImpuesto
                    foreach (ProductoImpuesto pro in producto.ProductoImpuesto)
                    {
                        //  ACTUALIZAR EL IMPUESTO
                        if (db.ProductoImpuesto.ToList().Exists(x => x.ImpuestoClave == pro.ImpuestoClave && x.ProductoClave == cProducto.ProductoClave))
                        {
                            if (producto.ProductoImpuesto.Count > 0)
                            {
                                foreach (var item in producto.ProductoImpuesto)
                                {
                                    var regis = db.ProductoImpuesto.ToList().First(x => x.ImpuestoClave == pro.ImpuestoClave && x.ProductoClave == cProducto.ProductoClave);
                                    ProductoImpuesto prodImp;
                                    prodImp = db.ProductoImpuesto.ToList().First(x => x.ImpuestoClave == pro.ImpuestoClave && x.ProductoClave == cProducto.ProductoClave);
                                    prodImp.TipoEstado = pro.TipoEstado;
                                    prodImp.MFechaHora = DateTime.Now;
                                    prodImp.MUsuarioID = producto.MUsuarioID;
                                }
                            }
                        }
                        //  EN CASO DE QUE NO EXISTA SE AGREGA EL IMPUESTO AL PRODUCTO
                        else
                        {
                            ProductoImpuesto prodImp = new ProductoImpuesto();
                            prodImp.ImpuestoClave = pro.ImpuestoClave;
                            prodImp.ProductoClave = cProducto.ProductoClave;
                            prodImp.TipoEstado = 1;
                            prodImp.MFechaHora = DateTime.Now;
                            prodImp.MUsuarioID = producto.MUsuarioID;
                            db.ProductoImpuesto.Add(prodImp);
                        }
                        //Se valida de que no exista un impuesto del producto de o ser así se agrega uno nuevo
                        //if (!db.ProductoImpuesto.ToList().Exists(x => x.ImpuestoClave == pro.ImpuestoClave && x.ProductoClave == cProducto.ProductoClave))
                        //{
                        //    ProductoImpuesto prodImp = new ProductoImpuesto();
                        //    prodImp.ImpuestoClave = pro.ImpuestoClave;
                        //    prodImp.ProductoClave = cProducto.ProductoClave;
                        //    prodImp.TipoEstado = 1;
                        //    prodImp.MFechaHora = DateTime.Now;
                        //    prodImp.MUsuarioID = producto.MUsuarioID;
                        //    db.ProductoImpuesto.Add(prodImp);
                        //}
                    }

                    //Actualizar la tabla ProductoEquivalente
                    foreach (ProductoEquivalente pro in producto.ProductoEquivalente)
                    {
                        //  ACTUALIZAR PRODUCTO EQUIVALENTE
                        if (db.ProductoEquivalente.ToList().Exists(x => x.ProductoPqvClave == pro.ProductoPqvClave && x.ProductoClave == cProducto.ProductoClave))
                        {
                            if (producto.ProductoEquivalente.Count > 0)
                            {
                                foreach (var item in producto.ProductoEquivalente)
                                {
                                    ProductoEquivalente proEqui;
                                    proEqui = db.ProductoEquivalente.ToList().First(x => x.ProductoClave == cProducto.ProductoClave && x.ProductoPqvClave == pro.ProductoPqvClave);
                                    proEqui.Estado = pro.Estado;
                                    proEqui.MFechaHora = DateTime.Now;
                                    proEqui.MUsuarioID = producto.MUsuarioID;
                                }
                            }
                        }
                        //  EN CASO DE QUE NO EXISTA SE AGREGA EL IMPUESTO AL PRODUCTO
                        else
                        {
                            ProductoEquivalente proEqui = new ProductoEquivalente();
                            proEqui.ProductoClave = cProducto.ProductoClave;
                            proEqui.ProductoPqvClave = pro.ProductoClave;
                            proEqui.Estado = 1;
                            proEqui.MFechaHora = DateTime.Now;
                            proEqui.MUsuarioID = producto.MUsuarioID;
                            db.ProductoEquivalente.Add(proEqui);
                        }
                        //Se valida de que no exista un impuesto del producto de o ser así se agrega uno nuevo
                        //if (!db.ProductoEquivalente.ToList().Exists(x => x.ProductoPqvClave == pro.ProductoPqvClave && x.ProductoClave == cProducto.ProductoClave))
                        //{
                        //    ProductoEquivalente proEqui = new ProductoEquivalente();
                        //    proEqui.ProductoClave = cProducto.ProductoClave;
                        //    proEqui.ProductoPqvClave = pro.ProductoClave;
                        //    proEqui.Estado = 1;
                        //    proEqui.MFechaHora = DateTime.Now;
                        //    proEqui.MUsuarioID = producto.MUsuarioID;
                        //    db.ProductoEquivalente.Add(proEqui);
                        //}
                    }

                    if (producto.ProductoUnidad.Count > 0)
                    {
                        foreach (ProductoUnidad pro in producto.ProductoUnidad)
                        {

                            if (!db.ProductoUnidad.ToList().Exists(x => x.PRUTipoUnidad == pro.PRUTipoUnidad && x.ProductoClave == cProducto.ProductoClave))
                            {
                                ProductoUnidad prodUni = new ProductoUnidad();
                                prodUni.ProductoClave = cProducto.ProductoClave;
                                prodUni.PRUTipoUnidad = pro.PRUTipoUnidad;
                                prodUni.CodigoBarras = pro.CodigoBarras;
                                prodUni.TipoEstado = pro.TipoEstado;
                                prodUni.KgLts = pro.KgLts == null ? 0 : pro.KgLts;
                                prodUni.Volumen = pro.Volumen == null ? 0 : pro.Volumen;
                                prodUni.PorcentajeVariacion = pro.PorcentajeVariacion == null ? 0 : pro.PorcentajeVariacion;
                                prodUni.DecimalProducto = pro.DecimalProducto;
                                prodUni.MFechaHora = DateTime.Now;
                                prodUni.MUsuarioID = producto.MUsuarioID;

                                /*Se agregan los productos relacionados por tipo**/
                                foreach (ProductoDetalle proDet in pro.ProductoDetalle)
                                {
                                    ProductoDetalle proDeta = new ProductoDetalle();
                                    proDeta.ProductoClave = proDet.ProductoClave;
                                    proDeta.PRUTipoUnidad = proDet.PRUTipoUnidad;
                                    proDeta.ProductoDetClave = proDet.ProductoDetClave;
                                    proDeta.Factor = proDet.Factor;
                                    proDeta.MFechaHora = DateTime.Now;
                                    proDeta.MUsuarioID = producto.MUsuarioID;
                                    db.ProductoDetalle.Add(proDeta);
                                }
                                db.ProductoUnidad.Add(prodUni);
                            }
                            else
                            {
                                db.ProductoUnidad.ToList().First(x => x.PRUTipoUnidad == pro.PRUTipoUnidad && x.ProductoClave == cProducto.ProductoClave).PRUTipoUnidad = pro.PRUTipoUnidad;
                                db.ProductoUnidad.ToList().First(x => x.PRUTipoUnidad == pro.PRUTipoUnidad && x.ProductoClave == cProducto.ProductoClave).CodigoBarras = pro.CodigoBarras;
                                db.ProductoUnidad.ToList().First(x => x.PRUTipoUnidad == pro.PRUTipoUnidad && x.ProductoClave == cProducto.ProductoClave).KgLts = pro.KgLts == null ? 0 : pro.KgLts;
                                db.ProductoUnidad.ToList().First(x => x.PRUTipoUnidad == pro.PRUTipoUnidad && x.ProductoClave == cProducto.ProductoClave).Volumen = pro.Volumen == null ? 0 : pro.Volumen;
                                db.ProductoUnidad.ToList().First(x => x.PRUTipoUnidad == pro.PRUTipoUnidad && x.ProductoClave == cProducto.ProductoClave).PorcentajeVariacion = pro.PorcentajeVariacion == null ? 0 : pro.PorcentajeVariacion;
                                db.ProductoUnidad.ToList().First(x => x.PRUTipoUnidad == pro.PRUTipoUnidad && x.ProductoClave == cProducto.ProductoClave).DecimalProducto = pro.DecimalProducto;

                                /**SÍ YA EXISTE SE BUSCA SI EXISTEN DETALLE PRODUCTOS*/
                                foreach (ProductoDetalle proDet in pro.ProductoDetalle)
                                {
                                    //   if (valorNuevo.VARValor.ToList().Exists(x => x.VAVDescripcion.ToList().Exists(y => y.VADTipoLenguaje == des.VADTipoLenguaje && y.VAVClave == detalle.VAVClave)))

                                    if (cProducto.ProductoUnidad.ToList().Exists(y => y.ProductoDetalle.ToList().Exists(x => x.PRUTipoUnidad == pro.PRUTipoUnidad && x.ProductoClave == cProducto.ProductoClave && x.ProductoDetClave == proDet.ProductoDetClave)))
                                    {
                                        db.ProductoDetalle.ToList().First(x => x.PRUTipoUnidad == pro.PRUTipoUnidad && x.ProductoDetClave == proDet.ProductoDetClave && x.ProductoClave == cProducto.ProductoClave).Factor = proDet.Factor;
                                        db.ProductoDetalle.ToList().First(x => x.PRUTipoUnidad == pro.PRUTipoUnidad && x.ProductoDetClave == proDet.ProductoDetClave && x.ProductoClave == cProducto.ProductoClave).Prestamo = proDet.Prestamo;
                                    }
                                    else
                                    {
                                        ProductoDetalle proDeta = new ProductoDetalle();
                                        proDeta.ProductoClave = proDet.ProductoClave;
                                        proDeta.PRUTipoUnidad = proDet.PRUTipoUnidad;
                                        proDeta.ProductoDetClave = proDet.ProductoDetClave;
                                        proDeta.Factor = proDet.Factor;
                                        proDeta.MFechaHora = DateTime.Now;
                                        proDeta.MUsuarioID = producto.MUsuarioID;
                                        db.ProductoDetalle.Add(proDeta);
                                    }
                                }
                            }
                        }
                    }
                }
                try
                {
                    db.SaveChanges();
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

            }
            return true;
        }

        [HttpGet]
        [ActionName("ObtenerImpuestos")]
        public IHttpActionResult ObtenerImpuestos()
        {
            return Json((from x in db.Impuesto select new { x.ImpuestoClave, x.Abreviatura, x.Nombre, x.TipoEstado }));
        }

        [HttpGet]
        [ActionName("ObtenerEsquema")]
        public IHttpActionResult ObtenerEsquema()
        {
            var esquemas = (from x in db.Esquema
                            where x.EsquemaIDPadre == null && x.Tipo == 2 && x.TipoEstado == 1 && x.Nivel == 0
                            select new cEsquema
                            {
                                EsquemaID = x.EsquemaID,
                                Abreviatura = x.Abreviatura,
                                Nombre = x.Nombre,
                                TipoEstado = x.TipoEstado,
                                EsquemaIDPadre = x.EsquemaIDPadre,
                                Clave = x.Clave
                            }).ToList();

            foreach (cEsquema cEsq in esquemas)
            {
                ObtenerEsquemas(cEsq, cEsq.EsquemaID);
            }
            return Json(esquemas);
        }

        public void ObtenerEsquemas(cEsquema Esquema, string EsquemaId)
        {
            var esquemaHijos = (from x in db.Esquema
                                    //where x.EsquemaIDPadre == "PROD"
                                where x.EsquemaIDPadre == EsquemaId
                                select new cEsquema { EsquemaID = x.EsquemaID, Abreviatura = x.Abreviatura, Nombre = x.Nombre, TipoEstado = x.TipoEstado, EsquemaIDPadre = x.EsquemaIDPadre, Clave = x.Clave }).ToList();
            foreach (cEsquema cEsq in esquemaHijos)
            {
                ObtenerEsquemaHijos(cEsq, cEsq.EsquemaID);
            }

            Esquema.esquemas = esquemaHijos;
        }
        public void ObtenerEsquemaHijos(cEsquema Esquema, string EsquemaId)
        {
            var esquemaHijos = (from x in db.Esquema
                                where x.EsquemaIDPadre == EsquemaId
                                select new cEsquema { EsquemaID = x.EsquemaID, Abreviatura = x.Abreviatura, Nombre = x.Nombre, TipoEstado = x.TipoEstado, EsquemaIDPadre = x.EsquemaIDPadre, Clave = x.Clave }).ToList();
            foreach (cEsquema cEsq in esquemaHijos)
            {
                ObtenerEsquemaHijosMayor(cEsq, cEsq.EsquemaID);
            }
            Esquema.esquemas = esquemaHijos;
        }
        public void ObtenerEsquemaHijosMayor(cEsquema Esquema, string EsquemaId)
        {
            var esquemaHijos = (from x in db.Esquema
                                where x.EsquemaIDPadre == EsquemaId
                                select new cEsquema { EsquemaID = x.EsquemaID, Abreviatura = x.Abreviatura, Nombre = x.Nombre, TipoEstado = x.TipoEstado, EsquemaIDPadre = x.EsquemaIDPadre, Clave = x.Clave }).ToList();
            foreach (cEsquema cEsq in esquemaHijos)
            {
                ObtenerEsquemaHijosMayorUltimo(cEsq, cEsq.EsquemaID);
            }
            Esquema.esquemas = esquemaHijos;
        }
        public void ObtenerEsquemaHijosMayorUltimo(cEsquema Esquema, string EsquemaId)
        {
            var esquemaHijos = (from x in db.Esquema
                                where x.EsquemaIDPadre == EsquemaId
                                select new cEsquema { EsquemaID = x.EsquemaID, Abreviatura = x.Abreviatura, Nombre = x.Nombre, TipoEstado = x.TipoEstado, EsquemaIDPadre = x.EsquemaIDPadre, Clave = x.Clave }).ToList();

            Esquema.esquemas = esquemaHijos;
        }

        [HttpGet]
        [ActionName("ObtenerProductosPrioritarios")]
        public IHttpActionResult ObtenerProductosPrioritarios()
        {
            var producto = (from pro in db.Producto
                            join vad in db.VAVDescripcion on new { VARCodigo = "PROTIPO", VADTipoLenguaje = "EM", VAVClave = pro.Tipo.ToString() } equals new { VARCodigo = vad.VARCodigo, VADTipoLenguaje = vad.VADTipoLenguaje, VAVClave = vad.VAVClave }
                            where pro.TipoFase == 1 && (!pro.Contenido || (pro.Contenido && pro.Venta))
                            select new
                            {
                                Seleccionado = false,
                                pro.ProductoClave,
                                pro.Id,
                                pro.Nombre,
                                Tipo = vad.Descripcion
                            }).ToList();
            return Json(producto);
        }

        [HttpGet]
        [ActionName("ValidarEstadoProducto")]
        public IHttpActionResult ValidarEstadoProducto(string ProductoClave)
        {
            DateTime hoy = DateTime.Now;
            //  s = 2008-06-15T21:15:07
            //  d = 13/08/2018
            string[] format = { "s", "d" };
            var fecha_hora = hoy.ToString(format[0]);
            var fecha = hoy.ToString(format[1]);
            DateTime f = DateTime.Parse(fecha);
            DateTime Factual = DateTime.Now;
            var relaciones = new List<string>();

            var carga = (from T in db.TransProd
                         join D in db.TransProdDetalle on T.TransProdID equals D.TransProdID
                         where D.ProductoClave == ProductoClave && T.Tipo == 2 && T.TipoFase == 5
                         && T.DiaClave == fecha
                         //&& DateTime.Parse(T.DiaClave).Date >= Factual.Date
                         select new { ProductoClave = D.ProductoClave }
                ).Count();
            var pedidos = (from D in db.TransProdDetalle
                           join T in db.TransProd on D.TransProdID equals T.TransProdID
                           where D.ProductoClave == ProductoClave && T.Tipo == 1 && T.TipoFase != 2
                           select new { ProductoClave = D.ProductoClave }
                ).Count();
            var prestamo = (from P in db.ProductoPrestamoCli
                            where P.ProductoClave == ProductoClave && P.Saldo != 0
                            select new { ProductoClave = P.ProductoClave }
                ).Count();
            //var cuota = ();

            //var promocion1 = ();
            //var promocion2 = ();

            var precio = (from PPV in db.PrecioProductoVig
                          join Pr in db.Precio on PPV.PrecioClave equals Pr.PrecioClave
                          where PPV.ProductoClave == ProductoClave && Pr.TipoEstado == 1 && PPV.TipoEstado == 1
                          select new { ProductoClave = PPV.ProductoClave }
                ).Count();

            //var descuento = ();
            //var contenido = (from PD in db.ProductoDetalle
            //                 where PD.ProductoClave 
            //    );

            if (carga != 0)
            {
                relaciones.Add("Carga");
            }
            if (pedidos != 0)
            {
                relaciones.Add("Pedidos");
            }
            if (prestamo != 0)
            {
                relaciones.Add("Préstamo");
            }
            if (precio != 0)
            {
                relaciones.Add("Precio");
            }

            return Json(relaciones);
        }
    }
}