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
    public class TerminalesController : ApiController
    {
        RouteEntities db = new RouteEntities();

        [HttpGet]
        [ActionName("ObtCentroDistribucion")]
        public IHttpActionResult ObtCentroDistribucion()
        {
            var lista = new List<cAlmacen>();
            
                var btipouso = (
                    from x in db.Almacen
                    where x.Tipo.Equals("1") && x.TipoEstado == 1
                    select new cAlmacen { AlmacenID = x.AlmacenID, NombreCompuesto = x.Clave + " - " + x.Nombre });
                return Json(btipouso);
           
        }

        [HttpGet]
        [ActionName("ObtenerTerminales")]
        public IHttpActionResult ObtenerTerminales(string usu)
        {
            var valter = (from ter in db.Terminal
                          join varval in db.VAVDescripcion on ter.TipoFase.ToString() equals varval.VAVClave
                          where varval.VARCodigo == "TERFASE" && varval.VADTipoLenguaje == "EM"
                          from al in db.Almacen
                          .Where(c => c.AlmacenID.Equals(ter.AlmacenID))
                          .DefaultIfEmpty()
                          where (

                               from ua in db.UsuarioAlmacen
                               join a in db.Almacen on ua.AlmacenId equals a.AlmacenID
                               where ua.USUId == usu
                               select ua.AlmacenId



                            ).Contains(al.AlmacenID) || (al.AlmacenID.Equals("") || al.AlmacenID.Equals(null))


                          select new { ter.TerminalClave, ter.Descripcion, ter.NumeroSerie, TipoFase = varval.Descripcion, ter.GPS, al.Nombre }
                           );

            return Json(valter);
        }

        //Obtenereditar
        [HttpGet]
        [ActionName("ObtenerValorterminal")]
        public IHttpActionResult ObtenerValorterminal(string TerminalClave)
        {
            //var valores = db.VAVDescripcion.ToList().FindAll(x => x.VARValor.VARCodigo == sVARCodigo && x.VADTipoLenguaje == "EM");

            var valores = (from terminal in db.Terminal
                           where terminal.TerminalClave == TerminalClave
                           select new { terminal.TerminalClave, TipoFase = terminal.TipoFase.ToString(), terminal.NumeroSerie, terminal.Comentario, terminal.GPS, terminal.AlmacenID, terminal.Descripcion}).ToList();

            return Json(valores);
        }

        [HttpPost]
        public bool Grabar(Terminal terminales) //valor = msg
        {

            bool nuevo =!db.Terminal.ToList().Exists(x => x.TerminalClave== terminales.TerminalClave);
            Terminal ter;
            if (nuevo)
            {
                ter = new Terminal();
                ter.TerminalClave = terminales.TerminalClave;
            }
            else {
               ter = db.Terminal.ToList().First(x => x.TerminalClave == terminales.TerminalClave);//primer resultado con la clave

            }
            
                        
                        ter.TipoFase = terminales.TipoFase;
                        ter.Descripcion = terminales.Descripcion;
                        ter.NumeroSerie = terminales.NumeroSerie;
                        ter.Comentario = terminales.Comentario;
                        ter.GPS = terminales.GPS;
                        ter.AlmacenID = terminales.AlmacenID;
                        ter.MFechaHora = DateTime.Now;
                        ter.MUsuarioID = "Interfaz";

            if (nuevo)
            {
                db.Terminal.Add(ter);
            }
            else {//eliminar

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
            }
            return true;


        }


        [HttpPost]
        public bool Actualizar(Terminal terminales) //valor = msg
        {
            if (terminales.TerminalClave != "")
            {
                Terminal ter = db.Terminal.ToList().First(x => x.TerminalClave == terminales.TerminalClave);//primer resultado con la clave

                ter.NumeroSerie = null;
                ter.MFechaHora = DateTime.Now;
                ter.MUsuarioID = terminales.MUsuarioID;

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
                }
            }
            else
            {
                foreach (Terminal ter in db.Terminal.ToList())
                {
                    ter.NumeroSerie = null;
                    ter.MFechaHora = DateTime.Now;
                    ter.MUsuarioID = terminales.MUsuarioID;
                    db.SaveChanges();
                }
            }
            return true;
        }


        //Validar Clave Terminal 
        [HttpGet]
        [ActionName("ValidarTerminalClave")]
        public IHttpActionResult ValidarCodigoUnico(string TerminalClave)
        {
            RouteEntities db = new RouteEntities();
            return Json(db.Precio.ToList().Exists(x => x.PrecioClave == TerminalClave));
        }


    }
}