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
    public class AlmacenController : ApiController
    {
        RouteEntities db = new RouteEntities();

        //Validar Clave Almacen 
        [HttpGet]
        [ActionName("ValidarAlmacenClave")]
        public IHttpActionResult ValidarCodigoUnico(string clave)
        {
            RouteEntities db = new RouteEntities();
            return Json(db.Almacen.ToList().Exists(x => x.Clave == clave));
        }

        [HttpGet]
        [ActionName("ObtenerAlmacenes")]
        public IHttpActionResult ObtenerAlmacenes()
        {
            var almacenes = (from alm in db.Almacen
                             join vd1 in db.VAVDescripcion on "ALMTIPO" equals vd1.VARCodigo
                             join vd2 in db.VAVDescripcion on "EDOREG" equals vd2.VARCodigo
                             where vd1.VAVClave == alm.Tipo && vd1.VADTipoLenguaje == "EM" &&
                             vd2.VAVClave == alm.TipoEstado.ToString() && vd2.VADTipoLenguaje == "EM"
                             select new
                             {
                                 alm.Nombre,
                                 Tipo = vd1.Descripcion,
                                 TipoEstado = vd2.Descripcion,
                                 alm.Clave,
                                 alm.AlmacenPadreId,
                                 alm.AlmacenID
                             }).ToList();
            return Json(almacenes);
        }


        [HttpGet]
        [ActionName("ObtenerCamiones")]
        public IHttpActionResult ObtenerCamiones(string AlmacenID, string Action)
        {

            var list = new List<cCamion>();



            if (Action.Equals("Create"))
            {

                var camion = (from x in db.Camion
                              where x.AlmacenId == "" || x.AlmacenId == null || x.AlmacenId == "NULL"
                              select new cCamion { Placa = x.Placa, Clave = x.Clave, Descripcion = x.Descripcion }
                );
                return Json(camion);

            }
            else
            {
                var camionesAgignados = (from x in db.Camion
                                         where x.AlmacenId == AlmacenID
                                         select new cCamion { Placa = x.Placa, Clave = x.Clave, Descripcion = x.Descripcion, AlmacenID = x.AlmacenId }
                    );
                var camionesDisponibles = (from x in db.Camion
                                           where x.AlmacenId == "" || x.AlmacenId == null || x.AlmacenId == "NULL"
                                           select new cCamion { Placa = x.Placa, Clave = x.Clave, Descripcion = x.Descripcion, AlmacenID = x.AlmacenId }
                );

                //Agregar los asigandos a la lista

                foreach (cCamion c in camionesAgignados)
                {
                    list.Add(new cCamion { Placa = c.Placa, Clave = c.Clave, Descripcion = c.Descripcion, Existe = true });
                }
                //Agregar los disponibles a la lista

                foreach (cCamion c in camionesDisponibles)
                {
                    list.Add(new cCamion { Placa = c.Placa, Clave = c.Clave, Descripcion = c.Descripcion, Existe = false });
                }
                return Json(list);
            }
        }


        [HttpGet]
        [ActionName("ObtenerDetalleAlmacen")]
        public IHttpActionResult ObtenerDetalleAlmacen(string AlmacenID)
        {
            if (AlmacenID == null)
            {
                return Json(true);
            }
            else
            {
                var centro = (from x in db.Camion
                              where x.AlmacenId == AlmacenID
                              select new { Placa = x.Placa, Clave = x.Clave, Descripcion = x.Descripcion }
                );

                if (centro.Count() <= 0)
                {
                    //    centro.Add(new cVARValor { VARCodigo = "", VAVClave = "", Grupo = "", Estado = "" });
                }


                return Json(centro);
            }



        }


        [HttpGet]
        [ActionName("ObtenerAlmacen")]
        public IHttpActionResult ObtenerAlmacen(string AlmacenID)
        {
            var almacen = (from x in db.Almacen
                           where x.AlmacenID == AlmacenID
                           select new { x.AlmacenID, x.AlmacenPadreId, x.Clave, x.Nombre, x.Domicilio, x.Telefono, x.Tipo, x.TipoEstado, x.CodigoBarras, x.Latitud, x.Longitud }
                           ).ToList();

            return Json(almacen);
        }

        [HttpGet]
        [ActionName("obtVehiculos")]
        public IHttpActionResult obtVehiculos()
        {

            //    var vehiculoList = (from x in db.);

            var dc = (from x in db.Almacen
                      where x.Tipo.Equals("1") && x.TipoEstado == 1
                      select new cAlmacen { AlmacenID = x.AlmacenID, Clave = x.Clave, Nombre = x.Nombre, TipoEstado = x.TipoEstado.ToString(), Tipo = x.Tipo, NombreCompuesto = x.Clave + " - " + x.Nombre });

            return Json(dc);
        }



        [HttpPost]
        public bool GuardarAlmacen(Almacen almacen)
        {
            RouteEntities db = new RouteEntities();

            if (almacen != null)
            {

                bool nuevo = !db.Almacen.ToList().Exists(x => x.AlmacenID == almacen.AlmacenID);
                Almacen cAlm;



                if (nuevo)
                {
                    cAlm = new Almacen();
                    //     cAlm.AlmacenID = almacen.AlmacenID;
                    cAlm.AlmacenID = "ALCD" + getClave();
                }
                else
                {
                    cAlm = db.Almacen.ToList().First(x => x.AlmacenID == almacen.AlmacenID);
                }

                cAlm.Clave = almacen.Clave;
                cAlm.Nombre = almacen.Nombre;
                cAlm.Domicilio = almacen.Domicilio;
                cAlm.Telefono = almacen.Telefono;
                cAlm.Tipo = almacen.Tipo;
                cAlm.TipoEstado = almacen.TipoEstado;
                cAlm.CodigoBarras = almacen.CodigoBarras;
                cAlm.Latitud = almacen.Latitud;
                cAlm.Longitud = almacen.Longitud;
                cAlm.MUsuarioID = almacen.MUsuarioID;
                cAlm.MFechaHora = DateTime.Now;


                if (nuevo)
                {
                    if (almacen.Tipo == "2")
                    {
                        foreach (Camion ca in almacen.Camion)
                        {
                            db.Camion.ToList().First(x => x.Placa == ca.Placa).AlmacenId = cAlm.AlmacenID;
                        }
                    }


                    db.Almacen.Add(cAlm);
                }
                else
                {

                    var eliminar = new List<string>();
                    //    foreach (UsuarioAlmacen usuarioA in cUsuario.UsuarioAlmacen)
                    foreach (Camion camion in cAlm.Camion)
                    {

                        if (!almacen.Camion.ToList().Exists(x => x.Placa == camion.Placa))
                        {
                            eliminar.Add(camion.Placa);
                        }


                    }


                    foreach (string cam in eliminar)
                    {
                        //No elimina porque está referenciada la llave foranea
                        db.Camion.ToList().First(x => x.Placa == cam).AlmacenId = null;

                    }




                    if (almacen.Tipo == "2")
                    {
                        foreach (Camion ca in almacen.Camion)
                        {
                            db.Camion.ToList().First(x => x.Placa == ca.Placa).AlmacenId = almacen.AlmacenID;
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
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        //Eliminar Almacen
        [HttpGet]
        [ActionName("EliminarAlmacen")]
        public IHttpActionResult EliminarAlmacen(string AlmacenID)
        {
            try
            {

                if (db.Camion.ToList().FindAll(x => x.AlmacenId == AlmacenID).Count() > 0)
                    db.Camion.ToList().First(x => x.AlmacenId == AlmacenID).AlmacenId = null;

                db.Almacen.Remove(db.Almacen.First(x => x.AlmacenID == AlmacenID));
                db.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        public int getMayor()
        {
            //var a =    db.Usuario.OrderByDescending(x => x.USUId).FirstOrDefault();
            var alm = db.Almacen.ToList();
            var unreal = false;
            var numAux = 0;
            var num = 0;

            //ALCD36

            foreach (Almacen a in alm)
            {

                var palAux = a.AlmacenID;

                palAux = palAux.Replace("ALCD", "");

                try
                {
                    num = Int32.Parse(palAux);
                    unreal = false;
                }
                catch (Exception e)
                {
                    unreal = true;
                    Console.WriteLine("Numeros: " + e.Message);
                }

                if (!unreal)
                {
                    if (num > numAux)
                        numAux = num;
                }

            }
            return numAux;
        }

        public string getClave()
        {
            var repetido = false;
            var mayor = getMayor();
            mayor++;
            do
            {
                if (db.Almacen.ToList().Exists(x => x.AlmacenID == "ALCD" + mayor.ToString()))
                {
                    repetido = true;
                    mayor++;
                }
                else
                    repetido = false;

            } while (repetido);
            return mayor.ToString();
        }
    }
}