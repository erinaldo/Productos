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

    public class VendedoresController : ApiController
    {
        RouteEntities db = new RouteEntities();

        //Obtener centros ObtenerModulos
        [HttpGet]
        [ActionName("ObtCentroDistribucion")]
        public IHttpActionResult ObtCentroDistribucion(string usu)
        {
            var lista = new List<cAlmacen>();

            var btipouso = (
                from ua in db.UsuarioAlmacen
                join a in db.Almacen on ua.AlmacenId equals a.AlmacenID
                where ua.USUId == usu
                //select ua.AlmacenId
                select new cAlmacen { AlmacenID = a.AlmacenID, NombreCompuesto = a.Nombre });
            return Json(btipouso);

        }

        // ObtenerModulos
        [HttpGet]
        [ActionName("ObtenerModulos")]
        public IHttpActionResult ObtenerModulos()
        {
           

            var mod = (
                from mt in db.ModuloTerm               
                select new  {
                    modulo = mt.Nombre,
                    clave = mt.ModuloClave
                     });
            return Json(mod);

        }

        // ObtenerSUbModulos
        [HttpGet]
        [ActionName("ObtenerSubModulos")]
        public IHttpActionResult ObtenerSubModulos()
        {


            var mod = (
                from mv in db.ModuloMov 
                select new
                {
                    
                    submodulo = mv.Nombre,
                    clave = mv.ModuloClave,
                    sclave= mv.ModuloMovClave


                });
            return Json(mod);

        }

        // ObtenerHijos
        [HttpGet]
        [ActionName("ObtenerHijos")]
        public IHttpActionResult ObtenerHijos()
        {


            var mod = (
                from md in db.ModuloMovDetalle
                select new
                {

                    nombre = md.Nombre,
                    clave = md.ModuloClave,
                    sclave = md.ModuloMovClave
                });
            return Json(mod);

        }

        //obtenerAlmacen
        [HttpGet]
        [ActionName("Almacen")]
        public IHttpActionResult Almacen(string almacenid)
        {


            var alma = (
                from x in db.Almacen
                where x.AlmacenPadreId == almacenid
                select new { AlmacenID = x.AlmacenID, NombreCompuesto = x.Nombre });
            return Json(alma);

        }

        //obtener Configuracion
        [HttpGet]
        [ActionName("VenConf")]
        public IHttpActionResult VenConf()
        {


            var conf = (
                from MC in db.MOTConfiguracion
                join MT in db.ModuloTerm on MC.ModuloClave equals MT.ModuloClave
                join VD in db.VAVDescripcion on MT.TipoIndice.ToString() equals VD.VAVClave
                where MT.TipoEstado == 1 && MT.Baja == false && VD.VADTipoLenguaje == "EM" && VD.VARCodigo == "TINDMOD"
                select new { Clave = MC.MCNClave, MC.Nombre, MOTNombre = MT.Nombre, TipoIndice = VD.Descripcion }).ToList();
            return Json(conf);

        }

        //obtener Usuario
        [HttpGet]
        [ActionName("VenUsuario")]
        public IHttpActionResult VenUsuario(string almacenid)
        {



            var usu = (
            from us in db.Usuario
            where !(

                from ven in db.Vendedor
                where ven.VendedorID != "" && ven.TipoEstado == 1 && ven.Baja.ToString() == "0"
                select ven.USUId

            ).Contains(us.USUId) && us.AlmacenID == almacenid
            select new { us.Clave, us.Nombre, us.Activo, us.AlmacenID });

            return Json(usu);

        }


        //obtener Terminal
        [HttpGet]
        [ActionName("VenTerminal")]
        public IHttpActionResult VenTerminal(string almacenid)
        {


            var ter = (
                from t in db.Terminal
                where t.TipoFase == 1 && t.AlmacenID == almacenid
                select new { t.TerminalClave, t.Descripcion, t.NumeroSerie, t.GPS, t.AlmacenID });
            return Json(ter);

        }


        //obtener Clientemodelo
        [HttpGet]
        [ActionName("VenCliente")]
        public IHttpActionResult VenCliente(string almacenid)
        {


            var cliente = (
                 from c in db.Cliente
                 where c.TipoEstado.ToString() == "1" && c.AlmacenID.Equals(almacenid) || c.AlmacenID.Equals("") || c.AlmacenID.Equals(null)
                 select new
                 {
                     c.Clave,
                     c.IdFiscal,
                     c.TipoImpuesto,
                     c.RazonSocial,
                     c.NombreContacto,
                     c.TelefonoContacto,
                     c.LimiteCreditoDinero,
                     c.NombreCorto,
                     c.LimiteDescuento,
                     c.SaldoEfectivo,
                     c.Exclusividad,
                     c.VigExclusividad,
                     c.ActualizaSaldoCheque,
                     c.VencimientoVenta,
                     c.DiasVencimiento,
                     c.SaldoGarantia,
                     c.Nuevo,
                     c.FechaFactura,
                     c.DesgloseImpuesto,
                     c.CorreoElectronico,
                     c.AlmacenID
                 });
            return Json(cliente);

        }


        //obtener lista de precios base
        [HttpGet]
        [ActionName("VenLista")]
        public IHttpActionResult VenLista()
        {
            var q = (from cust in db.Precio
                     from ord in db.VAVDescripcion
                     where (cust.CFVTipo == 0 || cust.CFVTipo.ToString() == ord.VAVClave) && ord.VADTipoLenguaje == "EM" && cust.TipoEstado == 1 && ord.VARCodigo == "FVENTA"
                     select new
                     {
                         cust.PrecioClave,
                         cust.Nombre,
                         cust.Jerarquia,
                         CFVTipo = cust.CFVTipo == 0 ? "Ninguna" :
                        cust.CFVTipo.ToString() == ord.VAVClave ? ord.Descripcion : ""

                     }).Distinct();
            return Json(q);

        }

        //Obtener
        [HttpGet]
        [ActionName("ObtenerVendedores")]
        public IHttpActionResult ObtenerVendedores(string usu)
        {
            DateTime Factual = DateTime.Now;

            var valter = (from Ven in db.Vendedor
                              //Descripcion Estado
                          join est in db.VAVDescripcion on Ven.TipoEstado.ToString() equals est.VAVClave
                          where est.VARCodigo == "EDOREG" && est.VADTipoLenguaje == "EM"
                          //Descripcion Tipo
                          join ti in db.VAVDescripcion on Ven.Tipo.ToString() equals ti.VAVClave
                          where ti.VARCodigo == "TVEND" && ti.VADTipoLenguaje == "EM"
                          join U in db.Usuario on Ven.USUId equals U.USUId
                          from VC in db.VENCentroDistHist
                          .Where(c => c.VendedorId.Equals(Ven.VendedorID) && (c.VCHFechaInicial <= Factual.Date && c.FechaFinal >= Factual.Date))//&& ( DateTime.Now >= c.VCHFechaInicial.Date && DateTime.Now  <= c.VCHFechaInicial.Date))
                          .DefaultIfEmpty()//Funciona cono left join
                          from AL in db.Almacen
                          .Where(d => VC.AlmacenId.Equals(d.AlmacenID))
                          .DefaultIfEmpty()
                          where (

                               from ua in db.UsuarioAlmacen
                               join a in db.Almacen on ua.AlmacenId equals a.AlmacenID
                               where ua.USUId == usu
                               select ua.AlmacenId



                            ).Contains(VC.AlmacenId) || (VC.AlmacenId.Equals("") || VC.AlmacenId.Equals(null))
                          select new
                          {
                              Ven.Nombre,
                              Ven.LimiteDescuento,
                              TipoEstado = est.Descripcion,
                              Ven.Baja,
                              Tipo = ti.Descripcion,
                              Usuario = U.Clave,
                              Ven.TerminalClave,
                              Ven.MCNClave,
                              Clave = AL.Clave,
                              VC.VendedorId



                          }).ToList();

            return Json(valter);
        }

    }
}