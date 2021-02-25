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
    public class FoliosController : ApiController
    {
        RouteEntities db = new RouteEntities();

        //Obtener folios para index
        [HttpGet]
        [ActionName("ObtenerFolios")]
        public IHttpActionResult ObtenerFolios(string usu)
        {
            var valter = (from f in db.Folio
                          join vd in db.VAVDescripcion on f.TipoEstado.ToString() equals vd.VAVClave
                          where vd.VARCodigo == "EDOREG" && vd.VADTipoLenguaje == "EM" && f.Fiscal == false
                          orderby f.Descripcion descending
                          select new
                          {
                              f.FolioID,
                              f.Descripcion,
                              TipoEstado = vd.Descripcion
                          }).ToList();

            return Json(valter);
        }

        [HttpGet]
        [ActionName("ObtenerFolioUsuario")]
        public bool ObtenerFolioUsuario(string folioID)
        {
            var valter = (from f in db.FolioUsuario
                          where f.FolioID==folioID
                          select new
                          {
                              f.FolioID
                          }).ToList();
            if (valter.Count==0)
            {
                return false;
            }
            return true;
        }

        //obtener folioDetalle para editar folio
        [HttpGet]
        [ActionName("ObtenerFolioDet")]
        public IHttpActionResult ObtenerFolioDet(string folId)
        {
            var valter = (from f in db.FolioDetalle
                          where f.FolioID == folId
                          select new
                          {
                              f.FolioDetClave,
                              f.TipoContenido,
                              f.Formato,
                              f.TipoEstado
                          }).ToList();
            return Json(valter);
        }

        //Mandar y Editar
        [HttpGet]
        [ActionName("ObtenerValorFolio")]
        public IHttpActionResult ObtenerValorFolio(string FolioId)
        {
            var valter = (from fol in db.Folio
                          where fol.FolioID == FolioId
                          select new {
                              fol.FolioID,
                              fol.Descripcion,
                              fol.ValorInicial,
                              fol.TipoEstado
                          }).ToList();

            return Json(valter);
        }



        [HttpGet]
        [ActionName("obtenerFolio")]
        public IHttpActionResult obtenerFolio(string folioID)
        {
            var valter = (from fd in db.FolioDetalle
                          where fd.FolioID == folioID
                          select new
                          {
                              fd.FolioDetClave,
                              fd.TipoContenido,
                              fd.Formato,
                              fd.TipoEstado
                          }
        ).ToList();
            return Json(valter);
        }


        ///guardar
        [HttpPost]
        public bool Grabar(Folio folio)
        {
            bool nuevo = !db.Folio.ToList().Exists(x => x.FolioID == folio.FolioID);



            if (nuevo){
                //Nuevo Folio
                Folio fol = new Folio();
                while (true)
                {
                    fol.FolioID = (Guid.NewGuid()).ToString().ToUpper().Substring(0, 16);
                    if (db.Folio.ToList().Exists(x => x.FolioID==fol.FolioID))
                    {
                        fol.FolioID = (Guid.NewGuid()).ToString().ToUpper().Substring(0, 16);
                    }else
                    {
                        break;
                    }
                }
                fol.ModuloMovDetalleClave = null;
                fol.Descripcion = folio.Descripcion;
                fol.ValorInicial = folio.ValorInicial;
                fol.TipoEstado = folio.TipoEstado;
                fol.Fiscal = false;
                fol.SubEmpresaId = "";
                fol.MFechaHora = DateTime.Now;
                fol.MUsuarioID = folio.MUsuarioID;
                db.Folio.Add(fol);
                

                // nuevos FolioDetalle
                int cont = 1;
                foreach (FolioDetalle i in folio.FolioDetalle)
                {
                    FolioDetalle fd = new FolioDetalle();
                    fd.FolioID = fol.FolioID;
                    fd.FolioDetClave = ("" + cont);
                    fd.TipoContenido = i.TipoContenido;
                    fd.Formato = i.Formato;
                    fd.TipoEstado = i.TipoEstado;
                    fd.MFechaHora = DateTime.Now;
                    fd.MUsuarioID = i.MUsuarioID;
                    db.FolioDetalle.Add(fd);
                    cont++;
                }

            }
            else
            {
                //editar folio
                Folio updateFolio = (from f in db.Folio where f.FolioID == folio.FolioID select f).SingleOrDefault();
                updateFolio.ModuloMovDetalleClave = folio.ModuloMovDetalleClave;
                updateFolio.Descripcion = folio.Descripcion;
                updateFolio.ValorInicial = folio.ValorInicial;
                updateFolio.TipoEstado = folio.TipoEstado;
                updateFolio.Fiscal = folio.Fiscal;
                if (folio.SubEmpresaId == null)
                {
                    updateFolio.SubEmpresaId = "";
                }
                else
                {
                    updateFolio.SubEmpresaId = folio.SubEmpresaId;
                }
                updateFolio.MFechaHora = DateTime.Now;
                updateFolio.MUsuarioID = folio.MUsuarioID;

                //Editar folioDetalle

                //FolioID FolioDetClave   TipoContenido Formato TipoEstado MFechaHora  MUsuarioID

                int cont = 1;
                foreach (FolioDetalle i in folio.FolioDetalle)
                {
                    bool ban = db.FolioDetalle.ToList().Exists(x=> x.FolioID==updateFolio.FolioID && x.FolioDetClave==""+cont);
                    if (ban)
                    {
                        FolioDetalle updateFolioDet = (from f in db.FolioDetalle where f.FolioID == updateFolio.FolioID && f.FolioDetClave==""+cont select f).SingleOrDefault();
                        updateFolioDet.TipoContenido = i.TipoContenido;
                        updateFolioDet.Formato = i.Formato;
                        updateFolioDet.TipoEstado = i.TipoEstado;
                        updateFolioDet.MFechaHora = DateTime.Now;
                        updateFolioDet.MUsuarioID = i.MUsuarioID;
                    }else
                    {
                        FolioDetalle fd = new FolioDetalle();
                        fd.FolioID = updateFolio.FolioID;
                        fd.FolioDetClave = ("" + cont);
                        fd.TipoContenido = i.TipoContenido;
                        fd.Formato = i.Formato;
                        fd.TipoEstado = i.TipoEstado;
                        fd.MFechaHora = DateTime.Now;
                        fd.MUsuarioID = i.MUsuarioID;
                        db.FolioDetalle.Add(fd);
                    }
                    cont++;
                    
                }

            }






            ///////folio detalle
            //int cont = 1;
            //List<FolioDetalle> fdList = new List<FolioDetalle>();
            //foreach (FolioDetalle i in folio.FolioDetalle)
            //{
            //    FolioDetalle fd = new FolioDetalle();
            //    fd.FolioID = fol.FolioID;
            //    fd.FolioDetClave = ("" + cont);
            //    fd.TipoContenido = i.TipoContenido;
            //    fd.Formato = i.Formato;
            //    fd.TipoEstado = i.TipoEstado;
            //    fd.MFechaHora = DateTime.Now;
            //    fd.MUsuarioID = i.MUsuarioID;
            //    cont++;
            //    fdList.Add(fd);
            //}


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

    }
}