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
    public class FrecuenciadeRutasController : ApiController
    {
        RouteEntities db = new RouteEntities();

        //Obtener las Frecuencias de Rutas existentes
        [HttpGet]
        [ActionName("ObtenerFrecuenciaRutas")]
        public IHttpActionResult ObtenerFrecuenciaRutas()
        {
            var Frecuencias = (
                from S in db.Secuencia
                join R in db.Ruta on S.RUTClave equals R.RUTClave
                join F in db.Frecuencia on S.FrecuenciaClave equals F.FrecuenciaClave
                select new { S.RUTClave, R.Descripcion, S.FrecuenciaClave, FDes = F.Descripcion }
                         ).Distinct().ToList();
            return Json(Frecuencias);
        }

        //Verificar existencia y estado de una Ruta
        [HttpGet]
        [ActionName("ValidarClaveRuta")]
        public IHttpActionResult ValidarClaveRuta(string ClaveRuta)
        {
            if (ClaveRuta != "" && ClaveRuta != null)
                return Json(db.Ruta.ToList().Exists(x => x.RUTClave == ClaveRuta && x.TipoEstado == 1));
            else
                return Json(true);
        }

        //Verificar intervalo de fechas de una frecuencia
        [HttpGet]
        [ActionName("ValidarVigenciaFrecuencia")]
        public IHttpActionResult ValidarVigenciaFrecuencia(string ClaveFrecuencia)
        {
            if (ClaveFrecuencia != "" && ClaveFrecuencia != null && db.Frecuencia.ToList().Exists(x => x.FrecuenciaClave == ClaveFrecuencia))
                return Json(db.Frecuencia.ToList().Exists(x => x.FrecuenciaClave == ClaveFrecuencia && x.FechaInicio <= DateTime.Now && x.FechaFinal >= DateTime.Now));
            else
                return Json(true);
        }

        //Verificar existencia de una frecuencia
        [HttpGet]
        [ActionName("ValidarClaveFrecuencia")]
        public IHttpActionResult ValidarClaveFrecuencia(string ClaveFrecuencia)
        {
            if (ClaveFrecuencia != "" && ClaveFrecuencia != null)
                return Json(db.Frecuencia.ToList().Exists(x => x.FrecuenciaClave == ClaveFrecuencia));
            else
                return Json(true);
        }

        //Verificar existencia de la clave combinada
        [HttpGet]
        [ActionName("ValidarClaveCombo")]
        public IHttpActionResult ValidarClaveCombo(string ClaveFrecuencia, String ClaveRuta)
        {
            if (ClaveFrecuencia != "" && ClaveFrecuencia != null && ClaveFrecuencia != "null" && ClaveRuta  != "" && ClaveRuta != null && ClaveRuta != "null")
            {
                var Frecuencias = (
                from S in db.Secuencia
                join R in db.Ruta on S.RUTClave equals R.RUTClave
                join F in db.Frecuencia on S.FrecuenciaClave equals F.FrecuenciaClave
                select new { S.RUTClave, R.Descripcion, S.FrecuenciaClave, FDes = F.Descripcion }
                         ).Distinct();


                return Json(Frecuencias.ToList().Exists(x => x.FrecuenciaClave == ClaveFrecuencia && x.RUTClave == ClaveRuta));
            }
                
            else
                return Json(false);
        }

        //Obtener las Rutas Existentes
        [HttpGet]
        [ActionName("ObtenerRutas")]
        public IHttpActionResult ObtenerRutas()
        {
            var Rutas = (
                from R in db.Ruta
                join VD in db.VAVDescripcion on new { Tipo = R.Tipo.ToString(), Aux1 = "TINDMOD", Aux2 = "EM" } equals new { Tipo = VD.VAVClave, Aux1 = VD.VARCodigo, Aux2 = VD.VADTipoLenguaje}
                join VDD in db.VAVDescripcion on new { Tipo = R.TipoEstado.ToString(), Aux1 = "EDOREG", Aux2 = "EM" } equals new { Tipo = VDD.VAVClave, Aux1 = VDD.VARCodigo, Aux2 = VDD.VADTipoLenguaje}
                select new { R.RUTClave, R.Descripcion, Tipo = VD.Descripcion, TipoEstado = VDD.Descripcion }
                         ).ToList();
            return Json(Rutas);
        }

        //Obtener las Frecuencias Existentes
        [HttpGet]
        [ActionName("ObtenerFrecuencias")]
        public IHttpActionResult ObtenerFrecuencias()
        {
            var Frecuencias = (
                from F in db.Frecuencia
                join VD in db.VAVDescripcion on new { Tipo = F.Tipo.ToString(), Aux1 = "TINDMOD", Aux2 = "EM" } equals new { Tipo = VD.VAVClave, Aux1 = VD.VARCodigo, Aux2 = VD.VADTipoLenguaje }
                select new { F.FrecuenciaClave, F.Descripcion, Tipo = VD.Descripcion, F.FechaInicio, F.FechaFinal }
                         ).ToList();
            return Json(Frecuencias);
        }

        //Obtener los datos de una ruta si es que existe
        [HttpGet]
        [ActionName("VerificarRuta")]
        public IHttpActionResult VerificarRuta(String Clave)
        {
            var Rutas = (
                from R in db.Ruta
                join VD in db.VAVDescripcion on new { TipoE = R.TipoEstado.ToString(), Tipo = R.Tipo.ToString(), Aux1 = "TINDMOD", Aux2 = "EM" } equals new { TipoE = "1", Tipo = VD.VAVClave, Aux1 = VD.VARCodigo, Aux2 = VD.VADTipoLenguaje }
                where R.RUTClave == Clave
                select new { R.RUTClave, R.Descripcion, Tipo = VD.Descripcion}
                         ).ToList();
            return Json(Rutas);
        }

        //Obtener los datos de una frecuencia si es que existe
        [HttpGet]
        [ActionName("VerificarFrecuencia")]
        public IHttpActionResult VerificarFrecuencia(String Clave)
        {
            var Frecuencias = (
                from F in db.Frecuencia
                where F.FrecuenciaClave == Clave
                select new { F.FrecuenciaClave, F.Descripcion }
                         ).ToList();
            return Json(Frecuencias);
        }

        //Verificar existencia de la clave de secuencia
        [HttpGet]
        [ActionName("VerificarSecuencia")]
        public IHttpActionResult VerificarSecuencia(String Clave)
        {
            var Secuencia = (
                from S in db.Secuencia
                where S.SECId == Clave
                select new { S.SECId }
                         ).ToList();
            return Json(Secuencia);
        }

        //Obtener los datos de los clientes relacionados a la combinacion Frecuencia y Ruta
        [HttpGet]
        [ActionName("ObtenerClientes")]
        public IHttpActionResult ObtenerClientes(String RUTClave, String Frecuencia)
        {
            var Clientes = (
                from S in db.Secuencia
                join C in db.Cliente on S.ClienteClave equals C.ClienteClave
                join CD in db.ClienteDomicilio on new { C.ClienteClave, Tipo = "2" } equals new { CD.ClienteClave, Tipo = CD.Tipo.ToString()} 
                where S.RUTClave == RUTClave && S.FrecuenciaClave == Frecuencia
                orderby S.Orden
                select new { S.Orden, C.Clave, C.ClienteClave, C.RazonSocial, C.NombreCorto, C.NombreContacto, CD.ClienteDomicilioID, CD.Calle, CD.Colonia, CD.Poblacion, Checked = true, SECId = S.SECId }
                         ).ToList().Distinct();
            return Json(Clientes);
        }

        //Obtener los datos de los clientes relacionados a la combinacion Frecuencia y Ruta
        [HttpGet]
        [ActionName("ObtenerClientesEliminar")]
        public IHttpActionResult ObtenerClientesEliminar(String RUTClave, String Frecuencia)
        {
            var Clientes = (
                from S in db.Secuencia
                join C in db.Cliente on S.ClienteClave equals C.ClienteClave
                join CD in db.ClienteDomicilio on new { C.ClienteClave, Tipo = "2" } equals new { CD.ClienteClave, Tipo = CD.Tipo.ToString() }
                where S.RUTClave == RUTClave && S.FrecuenciaClave == Frecuencia
                orderby S.Orden
                select new { SECId = S.SECId, ClienteClave = S.ClienteClave, ClienteDomicilioID = S.ClienteDomicilioID, RUTClave = S.RUTClave, FrecuenciaClave = S.FrecuenciaClave, Orden = S.Orden, MFechaHora = S.MFechaHora, MUsuarioID = S.MUsuarioID }
                         ).ToList().Distinct();
            return Json(Clientes);
        }

        //Obtener los datos de los clientes para asignarlos
        [HttpGet]
        [ActionName("AsignarClientesNuevos")]
        public IHttpActionResult AsignarClientesNuevos(String RUTClave, String Frecuencia, String Opcion)
        {
            var Clientes = (
                from C in db.Cliente
                join CD in db.ClienteDomicilio on new { C.ClienteClave, Tipo = "2" } equals new { CD.ClienteClave, Tipo = CD.Tipo.ToString() }
                join S in db.Secuencia on CD.ClienteClave equals S.ClienteClave
                where S.FrecuenciaClave == Frecuencia
                orderby C.Clave
                select new { C.Clave, C.ClienteClave, C.RazonSocial, C.NombreCorto, C.NombreContacto, CD.ClienteDomicilioID, CD.Calle, CD.Numero, CD.Colonia, CD.CodigoPostal, CD.Poblacion, CD.Entidad, CD.Pais, Checked = false, SECId = "" }
                         ).ToList().Distinct();
            if (Opcion == "2")
            {
                var MultipleCliente = (
                    from CON in db.CONHist
                    orderby CON.MFechaHora descending
                    select CON.ClienteVariasRutas
                    );
                bool Valor = MultipleCliente.FirstOrDefault();
                if (Valor == true)
                {
                    Clientes = (
                    from C in db.Cliente
                    join CD in db.ClienteDomicilio on new { C.ClienteClave, Tipo = "2" } equals new { CD.ClienteClave, Tipo = CD.Tipo.ToString() }
                    join S in db.Secuencia on CD.ClienteClave equals S.ClienteClave
                    where !(from S in db.Secuencia
                            where S.FrecuenciaClave == Frecuencia
                            select S.ClienteClave).Contains(C.ClienteClave) && C.TipoEstado == 1 && C.VencimientoVenta == false
                    orderby C.Clave
                    select new { C.Clave, C.ClienteClave, C.RazonSocial, C.NombreCorto, C.NombreContacto, CD.ClienteDomicilioID, CD.Calle, CD.Numero, CD.Colonia, CD.CodigoPostal, CD.Poblacion, CD.Entidad, CD.Pais, Checked = false, SECId = "" }
                         ).ToList().Distinct();
                }
                else
                {
                    Clientes = (
                    from C in db.Cliente
                    join CD in db.ClienteDomicilio on new { C.ClienteClave, Tipo = "2" } equals new { CD.ClienteClave, Tipo = CD.Tipo.ToString() }
                    where !(from S in db.Secuencia
                            select S.ClienteClave).Contains(C.ClienteClave) || (from S in db.Secuencia
                                                                                where "Null".Contains(S.RUTClave) || RUTClave.Contains(S.RUTClave)
                                                                                select S.ClienteClave).Contains(C.ClienteClave)
                    orderby C.Clave
                    select new { C.Clave, C.ClienteClave, C.RazonSocial, C.NombreCorto, C.NombreContacto, CD.ClienteDomicilioID, CD.Calle, CD.Numero, CD.Colonia, CD.CodigoPostal, CD.Poblacion, CD.Entidad, CD.Pais, Checked = false, SECId = "" }
                         ).ToList().Distinct();
                }
            }
            if (Opcion == "3")
            {
                Clientes = (
                from C in db.Cliente
                join CD in db.ClienteDomicilio on new { C.ClienteClave, Tipo = "2" } equals new { CD.ClienteClave, Tipo = CD.Tipo.ToString() }
                where !(from S in db.Secuencia
                        select S.ClienteClave).Contains(C.ClienteClave)
                orderby C.Clave
                select new { C.Clave, C.ClienteClave, C.RazonSocial, C.NombreCorto, C.NombreContacto, CD.ClienteDomicilioID, CD.Calle, CD.Numero, CD.Colonia, CD.CodigoPostal, CD.Poblacion, CD.Entidad, CD.Pais, Checked = false, SECId = "" }
                         ).ToList().Distinct();
            }
            return Json(Clientes);
        }

        [HttpPost]
        public bool GuardarFrecuencia(Ruta ruta)
        {
            Secuencia Sec = new Secuencia();
            Secuencia cSecuencia;
            foreach(Secuencia detalle in ruta.Secuencia)
            {
                var nuevo = true;
                var Exist = (from S in db.Secuencia where S.SECId == detalle.SECId select S.SECId).ToList();
                if (Exist.Count > 0)
                {
                    nuevo = false;
                }
                //
                if (nuevo)
                {
                    cSecuencia = new Secuencia();
                    cSecuencia.SECId = detalle.SECId;
                }
                else
                {
                    cSecuencia = db.Secuencia.Where(S => S.RUTClave == ruta.RUTClave && S.SECId == detalle.SECId).ToList().FirstOrDefault();
                }
                cSecuencia.ClienteClave = detalle.ClienteClave;
                cSecuencia.ClienteDomicilioID = detalle.ClienteDomicilioID;
                cSecuencia.RUTClave = ruta.RUTClave;
                cSecuencia.FrecuenciaClave = ruta.Descripcion;
                cSecuencia.Orden = detalle.Orden;
                cSecuencia.MFechaHora = DateTime.Now;
                cSecuencia.MUsuarioID = ruta.MUsuarioID;
                if (nuevo && cSecuencia.SECId != "")
                {
                    db.Secuencia.Add(cSecuencia);
                }
                else if (!nuevo && cSecuencia.SECId != "")
                {
                    Sec = db.Secuencia.First(x => x.SECId == cSecuencia.SECId);
                    Sec.ClienteClave = cSecuencia.ClienteClave;
                    Sec.ClienteDomicilioID = cSecuencia.ClienteDomicilioID;
                    Sec.RUTClave = cSecuencia.RUTClave;
                    Sec.FrecuenciaClave = cSecuencia.FrecuenciaClave;
                    Sec.Orden = cSecuencia.Orden;
                    Sec.MFechaHora = cSecuencia.MFechaHora;
                    Sec.MUsuarioID = cSecuencia.MUsuarioID;
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

        [HttpPost]
        public bool EliminarFrecuencia(Ruta ruta)
        {
            RouteEntities db = new RouteEntities();
            Secuencia cSecuencia;
            List<string> eliminar = new List<string>();
            foreach (Secuencia detalle in ruta.Secuencia)
            {
                if (ruta.Secuencia.ToList().Exists(x => x.SECId == detalle.SECId))
                {
                    eliminar.Add(detalle.SECId);
                }
            }
            foreach (string sec in eliminar)
            {
                cSecuencia = db.Secuencia.Where(S => S.FrecuenciaClave == ruta.Descripcion && S.RUTClave == ruta.RUTClave && S.SECId == sec).FirstOrDefault();
                db.Secuencia.Remove(cSecuencia);
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

    }
}