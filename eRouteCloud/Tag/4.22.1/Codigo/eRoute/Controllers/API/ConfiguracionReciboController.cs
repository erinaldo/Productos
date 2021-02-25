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
    public class ConfiguracionReciboController : ApiController
    {
        RouteEntities db = new RouteEntities();

        //Obtener la Configuracion de Recibos existentes
        [HttpGet]
        [ActionName("ObtenerConfiguracionRecibo")]
        public IHttpActionResult ObtenerConfiguracionRecibo()
        {
            var Recibos = (
                from R in db.Recibo
                join V in db.VAVDescripcion on ("TRECIBO") equals V.VARCodigo
                where V.VADTipoLenguaje == "EM" && V.VAVClave == R.Tipo.ToString()
                join V2 in db.VAVDescripcion on ("EDOREG") equals V2.VARCodigo
                where V2.VADTipoLenguaje == "EM" && V2.VAVClave == R.TipoEstado.ToString()
                select new
                {
                    R.RECId,
                    Tipo = V.Descripcion,
                    Estado = V2.Descripcion
                }
                ).Distinct().ToList();
            return Json(Recibos);
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
        public bool GuardarFrecuencia(Secuencia secuencia)
        {
            Secuencia cSecuencia;
            var nuevo = true;
            var Exist = (from S in db.Secuencia where S.SECId == secuencia.SECId select S.SECId).ToList();
            if (Exist.Count > 0)
            {
                nuevo = false;
            }
            //
            if (nuevo)
            {
                cSecuencia = new Secuencia();
                cSecuencia.SECId = secuencia.SECId;
            }
            else
            {
                cSecuencia = db.Secuencia.Where(S => S.RUTClave == secuencia.RUTClave && S.SECId == secuencia.SECId).ToList().FirstOrDefault();
            }
            cSecuencia.ClienteClave = secuencia.ClienteClave;
            cSecuencia.ClienteDomicilioID = secuencia.ClienteDomicilioID;
            cSecuencia.RUTClave = secuencia.RUTClave;
            cSecuencia.FrecuenciaClave = secuencia.FrecuenciaClave;
            cSecuencia.Orden = secuencia.Orden;
            cSecuencia.MFechaHora = DateTime.Now;
            cSecuencia.MUsuarioID = secuencia.MUsuarioID;
            if (nuevo && cSecuencia.SECId != "")
            {
                db.Secuencia.Add(cSecuencia);
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
        //public bool EliminarFrecuencia(Secuencia secuencia)
        public bool EliminarFrecuencia(Secuencia secuencia)
        {
            Secuencia cSecuencia;
            var nuevo = true;
            var Exist = (from S in db.Secuencia where S.SECId == secuencia.SECId select S.SECId).ToList();
            if (Exist.Count > 0)
            {
                nuevo = false;
            }
            //
            if (nuevo)
            {
                cSecuencia = new Secuencia();
                cSecuencia.SECId = secuencia.SECId;
            }
            else
            {
                cSecuencia = db.Secuencia.Where(S => S.FrecuenciaClave == secuencia.FrecuenciaClave && S.RUTClave == secuencia.RUTClave && S.SECId == secuencia.SECId).FirstOrDefault();
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