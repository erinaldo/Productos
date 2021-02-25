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
    public class ValorReferenciaController : ApiController
    {
        RouteEntities db = new RouteEntities();

        [HttpGet]
        [ActionName("ObtenerValores")]
        public IHttpActionResult ObtenerValores(string VARCodigo)
        {


            //var valores = db.VAVDescripcion.ToList().FindAll(x => x.VARValor.VARCodigo == sVARCodigo && x.VADTipoLenguaje == "EM");
            /*  var valores = (from valor in db.VAVDescripcion
                             where valor.VARCodigo == VARCodigo
                                 && valor.VADTipoLenguaje == "EM"
                             select new { valor.VAVClave, valor.Descripcion, valor.DescripcionSAT }).ToList(); */

            // join msg in db.MENDetalle on new { MENClave = m.MENNombreClave, MEDTipoLenguaje = MEDTipoLenguaje } equals new { MENClave = msg.MENClave, MEDTipoLenguaje = msg.MEDTipoLenguaje }

            var valores = (from valor in db.VAVDescripcion
                           join varval in db.VARValor on new { valor.VARCodigo, valor.VAVClave } equals new { varval.VARCodigo, varval.VAVClave }
                           where valor.VARCodigo == VARCodigo
                               && valor.VADTipoLenguaje == "EM"
                           select new { valor.VAVClave, valor.Descripcion, Grupo = (varval.Grupo == "" ? " " : varval.Grupo) }).ToList();



            return Json(valores);
        }

        [HttpGet]
        [ActionName("ObtenerValorClave")]
        public IHttpActionResult ObtenerValorClave(string VARCodigo, string VAVClave)
        {


            //var valores = db.VAVDescripcion.ToList().FindAll(x => x.VARValor.VARCodigo == sVARCodigo && x.VADTipoLenguaje == "EM");
            /*  var valores = (from valor in db.VAVDescripcion
                             where valor.VARCodigo == VARCodigo
                                 && valor.VADTipoLenguaje == "EM"
                             select new { valor.VAVClave, valor.Descripcion, valor.DescripcionSAT }).ToList(); */

            // join msg in db.MENDetalle on new { MENClave = m.MENNombreClave, MEDTipoLenguaje = MEDTipoLenguaje } equals new { MENClave = msg.MENClave, MEDTipoLenguaje = msg.MEDTipoLenguaje }

            var valores = (from valor in db.VAVDescripcion
                           join varval in db.VARValor on new { valor.VARCodigo, valor.VAVClave } equals new { varval.VARCodigo, varval.VAVClave }
                           where valor.VARCodigo == VARCodigo && valor.VAVClave == VAVClave && valor.VADTipoLenguaje == "EM"
                           select new { valor.VAVClave, valor.Descripcion, Grupo = (varval.Grupo == "" ? " " : varval.Grupo) }).ToList();

            return Json(valores);
        }

        [HttpGet]
        [ActionName("ObtenerValor")]
        public IHttpActionResult ObtenerValor(string VARCodigo)
        {


            //var valores = db.VAVDescripcion.ToList().FindAll(x => x.VARValor.VARCodigo == sVARCodigo && x.VADTipoLenguaje == "EM");
            var valores = (from valor in db.ValorReferencia
                           where valor.VARCodigo == VARCodigo
                           select new { valor.VARCodigo,valor.Descripcion, valor.TipoDato, valor.TipoAplicacion, TipoNulo =  valor.TipoNulo.ToString(), TipoModificable = valor.TipoModificable.ToString() }).ToList();

            return Json(valores);
        }

        [HttpGet]
        [ActionName("ObtenerValores")]
        public IHttpActionResult ObtenerValores()
        {
            var valores = (from valor in db.ValorReferencia
                           select new { valor.VARCodigo, valor.Descripcion, valor.TipoDato, valor.TipoAplicacion, valor.TipoNulo, valor.TipoModificable}).ToList();

            return Json(valores);
        }

        [HttpPost]
        public bool Grabar(ValorReferencia valor) //valor = msg
        {
                RouteEntities db = new RouteEntities();



            if (valor != null)
            {
                //   bool nuevo = !db.Mensaje.ToList().Exists(x => x.MENClave == msg.MENClave);

                bool nuevo = !db.ValorReferencia.ToList().Exists(x => x.VARCodigo == valor.VARCodigo);


                ValorReferencia valorNuevo; //mensaje
                if (nuevo)
                {
                    valorNuevo = new ValorReferencia();
                    valorNuevo.VARCodigo = valor.VARCodigo;
                }
                else
                {
                    valorNuevo = db.ValorReferencia.First(x => x.VARCodigo == valor.VARCodigo);
                }

                valorNuevo.Descripcion = valor.Descripcion;
                valorNuevo.TipoDato = valor.TipoDato;
                valorNuevo.TipoAplicacion = valor.TipoAplicacion;
                valorNuevo.TipoNulo = valor.TipoNulo;
                valorNuevo.TipoModificable = valor.TipoModificable;
                valorNuevo.MFechaHora = DateTime.Now;
                valorNuevo.MUsuarioID = valor.MUsuarioID;




                if (nuevo)
                {
                    foreach (VARValor det in valor.VARValor)
                    {
                        VARValor detalle = new VARValor();

                        if (string.IsNullOrEmpty(det.VAVClave))
                        {
                            Console.WriteLine("");
                        }else
                        {
                    
                            detalle.VAVClave = det.VAVClave;
                            detalle.ClaveSAT = det.ClaveSAT;
                            detalle.VARCodigo = valor.VARCodigo;
                            detalle.Grupo = det.Grupo;
                            detalle.Estado = det.Estado;
                            detalle.MUsuarioID = valor.MUsuarioID;
                            detalle.MFechaHora = DateTime.Now;

                            foreach (VAVDescripcion des in det.VAVDescripcion)
                            {

                                VAVDescripcion descripcion = new VAVDescripcion();

                                descripcion.VARCodigo = valor.VARCodigo; ;
                                descripcion.VAVClave = det.VAVClave;
                                descripcion.VADTipoLenguaje = des.VADTipoLenguaje;
                                descripcion.Descripcion = des.Descripcion;
                                descripcion.DescripcionSAT = des.DescripcionSAT;

                                descripcion.MFechaHora = DateTime.Now;
                                descripcion.MUsuarioID = valor.MUsuarioID;


                                detalle.VAVDescripcion.Add(descripcion);
                            }

                            valorNuevo.VARValor.Add(detalle);

                        }


                    }

                    db.ValorReferencia.Add(valorNuevo);
                }else
                {
                    //Modo eliminar

                    List<VARValor> eliminar = new List<VARValor>();

                   // List<string[]> eliminarDes = new List<string[]>();
                    List<VAVDescripcion> eliminarDes = new List<VAVDescripcion>();

                    //Se recorren los datos recuperaados de la consulta y se guardan en 'varValor'
                    foreach (VARValor varValor in valorNuevo.VARValor)
                    {
                        //Si en VARValor no existe un registro que ya existía se guardará en una lista 
                        if (!valor.VARValor.ToList().Exists(x => x.VAVClave == varValor.VAVClave) ){
                            eliminar.Add(varValor);
                            continue;
                        }

                        foreach (VAVDescripcion vavDes in varValor.VAVDescripcion) {
                            if (!valor.VARValor.ToList().First(x => x.VAVClave == varValor.VAVClave).VAVDescripcion.ToList().Exists(x => x.VADTipoLenguaje == vavDes.VADTipoLenguaje)) {
                                eliminarDes.Add(new VAVDescripcion { VARCodigo = vavDes.VARCodigo, VAVClave = vavDes.VAVClave, VADTipoLenguaje = vavDes.VADTipoLenguaje });
                            }
                        }
                    }



                    foreach(VAVDescripcion sVav in eliminarDes)
                    {
                        db.VAVDescripcion.Remove(db.VAVDescripcion.First(y => y.VADTipoLenguaje == sVav.VADTipoLenguaje && y.VAVClave == sVav.VAVClave && y.VARCodigo == sVav.VARCodigo));
                    }


                    //CHECAR PORQUE NO SE PUEDE BORRAR
                    
                    foreach (VARValor sVAVClave in eliminar)
                    {


                        for(int i =0; i < sVAVClave.VAVDescripcion.Count(); i++)
                        {
                            db.VAVDescripcion.Remove(sVAVClave.VAVDescripcion.ToArray()[i]);
                        }
                        valorNuevo.VARValor.Remove(valorNuevo.VARValor.First(x => x.VAVClave == sVAVClave.VAVClave));

                    }
                    //ACTUALIZAR LOS REGISTROS


                    // valorNuevo  = mensaje
                    // valor = msg

                    foreach (VARValor detalle in valor.VARValor)
                    {
                        if (valorNuevo.VARValor.ToList().Exists(x => x.VAVClave == detalle.VAVClave))
                        {
                            valorNuevo.VARValor.First(x => x.VAVClave == detalle.VAVClave).Grupo = detalle.Grupo;
                            valorNuevo.VARValor.First(x => x.VAVClave == detalle.VAVClave).Estado = detalle.Estado;
                            valorNuevo.VARValor.First(x => x.VAVClave == detalle.VAVClave).MUsuarioID = valor.MUsuarioID;
                            valorNuevo.VARValor.First(x => x.VAVClave == detalle.VAVClave).MFechaHora = DateTime.Now;

                            foreach (VAVDescripcion des in detalle.VAVDescripcion)
                            {

                                Console.WriteLine(detalle.VAVClave);

                                if (valorNuevo.VARValor.ToList().Exists(x => x.VAVDescripcion.ToList().Exists(y => y.VADTipoLenguaje == des.VADTipoLenguaje && y.VAVClave == detalle.VAVClave)))
                                {

                                 //   VAVDescripcion nuevaDes = db.VAVDescripcion.First(x => x.VAVClave == detalle.VAVClave && des.VADTipoLenguaje == x.VADTipoLenguaje);
                                    valorNuevo.VARValor.First(x => x.VAVDescripcion.ToList().Exists(y => y.VADTipoLenguaje == des.VADTipoLenguaje && y.VAVClave == detalle.VAVClave)).VAVDescripcion.First(x => x.VADTipoLenguaje == des.VADTipoLenguaje).VADTipoLenguaje = des.VADTipoLenguaje;
                                    valorNuevo.VARValor.First(x => x.VAVDescripcion.ToList().Exists(y => y.VADTipoLenguaje == des.VADTipoLenguaje && y.VAVClave == detalle.VAVClave)).VAVDescripcion.First(x => x.VADTipoLenguaje == des.VADTipoLenguaje).Descripcion = des.Descripcion;
                                    valorNuevo.VARValor.First(x => x.VAVDescripcion.ToList().Exists(y => y.VADTipoLenguaje == des.VADTipoLenguaje && y.VAVClave == detalle.VAVClave)).VAVDescripcion.First(x => x.VADTipoLenguaje == des.VADTipoLenguaje).DescripcionSAT = des.DescripcionSAT;
                                    valorNuevo.VARValor.First(x => x.VAVDescripcion.ToList().Exists(y => y.VADTipoLenguaje == des.VADTipoLenguaje && y.VAVClave == detalle.VAVClave)).VAVDescripcion.First(x => x.VADTipoLenguaje == des.VADTipoLenguaje).MUsuarioID = valor.MUsuarioID;
                                    valorNuevo.VARValor.First(x => x.VAVDescripcion.ToList().Exists(y => y.VADTipoLenguaje == des.VADTipoLenguaje && y.VAVClave == detalle.VAVClave)).VAVDescripcion.First(x => x.VADTipoLenguaje == des.VADTipoLenguaje).MFechaHora = DateTime.Now;
                                 
                                }
                                else
                                {
                                    VAVDescripcion descripcion = new VAVDescripcion();

                                    descripcion.VARCodigo = valorNuevo.VARCodigo;
                                    descripcion.VAVClave = detalle.VAVClave;
                                    descripcion.DescripcionSAT = des.DescripcionSAT;
                                    descripcion.VADTipoLenguaje = des.VADTipoLenguaje;
                                    descripcion.Descripcion = des.Descripcion;
                                    descripcion.MFechaHora = DateTime.Now;
                                    descripcion.MUsuarioID = valor.MUsuarioID;
                                    valorNuevo.VARValor.First(x => x.VAVClave == detalle.VAVClave).VAVDescripcion.Add(descripcion);
                                }
                            }

                        }
                        else
                        {
                            //NUEVO VARValor Nuevo 
                            VARValor varValor = new VARValor();
                            varValor.VARCodigo = valorNuevo.VARCodigo;
                            varValor.VAVClave = detalle.VAVClave;
                            varValor.ClaveSAT = detalle.ClaveSAT;
                            varValor.Grupo = detalle.Grupo;
                            varValor.Estado = detalle.Estado;
                            varValor.MUsuarioID = valor.MUsuarioID;
                            varValor.MFechaHora = DateTime.Now;

                            //Se añaden las descripciones que se agregan
                            foreach (VAVDescripcion des in detalle.VAVDescripcion)
                            {
                                VAVDescripcion descripcion = new VAVDescripcion();
                                descripcion.VARCodigo = valorNuevo.VARCodigo;
                                descripcion.DescripcionSAT = des.DescripcionSAT;
                                descripcion.VAVClave = detalle.VAVClave;
                                descripcion.VADTipoLenguaje = des.VADTipoLenguaje;
                                descripcion.Descripcion = des.Descripcion;
                                descripcion.MFechaHora = DateTime.Now;
                                descripcion.MUsuarioID = valor.MUsuarioID;
                                varValor.VAVDescripcion.Add(descripcion);
                            }
                            valorNuevo.VARValor.Add(varValor);
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
            else
            {
                return false;
            }
        }

        //CONSULTAS

        [HttpGet]
        [ActionName("ObtenerDetalleValores")]
        public IHttpActionResult ObtenerDetalleValores()
        {
        
            RouteEntities db = new RouteEntities();

            string lenguaje = (from config in db.CONHist
                               orderby config.CONHistFechaInicio descending
                               select config.TipoLenguaje).Take(1).ToList()[0];

            var valores = (from valor in db.ValorReferencia
                           join varValor in db.VARValor on valor.VARCodigo equals varValor.VARCodigo
                           where valor.VARCodigo.Equals("")
                           select new cVARValor {Nuevo = false, VARCodigo = varValor.VARCodigo, VAVClave = varValor.VAVClave, ClaveSAT = varValor.ClaveSAT, Grupo = varValor.Grupo, Estado = varValor.Estado.ToString() }
                           ).ToList();



           if(valores.Count() <= 0)
            {
                valores.Add(new cVARValor  { VARCodigo = "", VAVClave ="", ClaveSAT = "", Grupo = "", Estado = "" });

                for (int i = 0; i < valores.Count; i++)
                {
                    cVARValor oValor = valores[i];
                    ObtenerDescripciones(ref oValor, lenguaje);
                }
            }

            return Json(valores);
        }

        [HttpGet]
        [ActionName("ObtenerDetalleValores")]
        public IHttpActionResult ObtenerDetalleValores(string VARCodigo)
        {
            //VARCodigo = "BLABLAH";
            RouteEntities db = new RouteEntities();

            string lenguaje = (from config in db.CONHist
                               orderby config.CONHistFechaInicio descending
                               select config.TipoLenguaje).Take(1).ToList()[0];            
           
            var valores = (from valor in db.ValorReferencia
                           join varValor in db.VARValor on valor.VARCodigo equals varValor.VARCodigo
                           where valor.VARCodigo.Equals(VARCodigo)
                           select new cVARValor {Nuevo = true, VARCodigo = varValor.VARCodigo, VAVClave = varValor.VAVClave, ClaveSAT = varValor.ClaveSAT, Grupo = varValor.Grupo, Estado = varValor.Estado.ToString()  }
                           ).ToList();

            if (valores.Count() <= 0)
            {
                valores.Add(new cVARValor { VARCodigo = "", VAVClave = "", ClaveSAT = "", Grupo = "", Estado = "" });
            }

            for (int i = 0; i<valores.Count; i++)
            {
                cVARValor oValor = valores[i];
                ObtenerDescripciones(ref oValor, lenguaje);
            }
            
            return Json(valores);
        }


        public void ObtenerDescripciones(ref cVARValor oVARValor, String sLenguaje)
        {
            RouteEntities db = new RouteEntities();
            String VARCodigo = oVARValor.VARCodigo;
            String VAVClave = oVARValor.VAVClave;

            var descripciones = (from vad in db.VAVDescripcion
                           where vad.VARCodigo == VARCodigo && vad.VAVClave == VAVClave 
                           select new cVAVDescripcion { VADTipoLenguaje = vad.VADTipoLenguaje, Descripcion = vad.Descripcion, DescripcionSAT = vad.DescripcionSAT }
                           ).ToList();

            
            if (descripciones.Count == 0)
            {
                descripciones.Add(new cVAVDescripcion { VADTipoLenguaje = sLenguaje,  Descripcion = "" });

            }

            oVARValor.VAVDescripcion = descripciones;
        }

        //Validar Codigo Unico
        [HttpGet]
        [ActionName("ValidarCodigoUnico")]
        public IHttpActionResult ValidarCodigoUnico(string VARCodigo)
        {
            RouteEntities db = new RouteEntities();
            return Json(db.ValorReferencia.ToList().Exists(x => x.VARCodigo == VARCodigo));
        }
        //Validar clave unica
        [HttpGet]
        [ActionName("ValidarClave")]
        public IHttpActionResult ValidarClave(string VAVClave, string VARCodigo)
        {
            RouteEntities db = new RouteEntities();
            return Json(db.ValorReferencia.ToList().Exists(x => x.VARCodigo == VAVClave && x.VARCodigo == VARCodigo));
        }

        //Eliminar Valor
        [HttpGet]
        [ActionName("EliminarValor")]
        public IHttpActionResult EliminarValor(string VARCodigo)
        {
            try
            {

                db.VAVDescripcion.RemoveRange(db.VAVDescripcion.ToList().FindAll(x => x.VARCodigo == VARCodigo));
                db.VARValor.RemoveRange(db.VARValor.ToList().FindAll(x => x.VARCodigo == VARCodigo));
                db.ValorReferencia.Remove(db.ValorReferencia.First(x => x.VARCodigo == VARCodigo));
                db.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

    }
}