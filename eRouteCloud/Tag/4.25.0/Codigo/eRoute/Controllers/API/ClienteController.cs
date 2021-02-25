using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eRoute.Models;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;
using Dapper;

namespace eRoute.Controllers.API
{
    public class ClienteController : ApiController
    {
        RouteEntities db = new RouteEntities();
        
        [HttpGet]
        [ActionName("ObtenerClientes")]
        public IHttpActionResult ObtenerClientes(string USUId)
        {
            var cliente = (from cte in db.Cliente
                            join usu in db.UsuarioAlmacen on cte.AlmacenID equals usu.AlmacenId
                            join edo in db.VAVDescripcion on cte.TipoEstado.ToString() equals edo.VAVClave
                            where edo.VARCodigo == "EDOREG" && edo.VADTipoLenguaje == "EM" && usu.USUId == USUId
                            select new { cte.ClienteClave, cte.Clave, cte.NombreCorto, cte.NombreContacto, TipoEstado = edo.Descripcion, cte.RazonSocial }
                                      ).ToList();

            return Json(cliente);
        }

        [HttpGet]
        [ActionName("ObtenerZonas")]
        public IHttpActionResult ObtenerZonas()
        {
            var zonas = (from x in db.Zona
                           select new {
                               x.ZonaClave, x.Nombre
                            }
                           );
            return Json(zonas);
        }

        [HttpPost]
        public bool Grabar(Cliente cliente)
        {
            bool existe = (from c in db.Cliente
                          where c.ClienteClave == cliente.ClienteClave
                          select c).Any();

            Cliente cCliente;
            if (!existe) {
                cCliente = new Cliente();
                cCliente.ClienteClave = cliente.ClienteClave;
            } else {                
                cCliente = db.Cliente.First(x => x.Clave == cliente.Clave);
            }

            cCliente.Clave = cliente.Clave;
            cCliente.FechaRegistroSistema = cliente.FechaRegistroSistema;
            cCliente.TipoEstado = cliente.TipoEstado;
            cCliente.IdElectronico = cliente.IdElectronico;
            cCliente.FechaInactivacion = cliente.FechaInactivacion;
            cCliente.MotivoInactivacion = cliente.MotivoInactivacion;
            cCliente.RazonSocial = cliente.RazonSocial;
            cCliente.IdFiscal = cliente.IdFiscal;
            cCliente.FechaNacimiento = cliente.FechaNacimiento;
            cCliente.NombreCorto = cliente.NombreCorto;
            cCliente.NumeroSAP = cliente.NumeroSAP;
            cCliente.AlmacenID = cliente.AlmacenID;
            cCliente.DatosExtra = cliente.DatosExtra;
            cCliente.NombreContacto = cliente.NombreContacto;
            cCliente.TelefonoContacto = cliente.TelefonoContacto;
            cCliente.CorreoElectronico = cliente.CorreoElectronico;
            cCliente.PublicoGeneral = cliente.PublicoGeneral;
            cCliente.AseguramientoGPS = cliente.AseguramientoGPS;
            cCliente.TipoFiscal = cliente.TipoFiscal;
            cCliente.ActualizaSaldoCheque = cliente.ActualizaSaldoCheque;
            cCliente.Exclusividad = cliente.Exclusividad;
            cCliente.VigExclusividad = cliente.VigExclusividad;
            cCliente.ExigirOrdenCompra = cliente.ExigirOrdenCompra;
            cCliente.ExigirPedidoAdicional = cliente.ExigirPedidoAdicional;
            cCliente.FormatoPedidoAdicional = cliente.FormatoPedidoAdicional;
            cCliente.ValidaFolNeg = cliente.ValidaFolNeg;
            cCliente.VencimientoVenta = cliente.VencimientoVenta;
            cCliente.DiasVencimiento = cliente.DiasVencimiento;
            cCliente.Prestamo = cliente.Prestamo;
            cCliente.ValidarLimEnvase = cliente.ValidarLimEnvase;
            cCliente.LimiteEnvase = cliente.LimiteEnvase;
            cCliente.ExigirTomaInvMer = cliente.ExigirTomaInvMer;
            cCliente.BonificacionMasiva = cliente.BonificacionMasiva;
            cCliente.TipoCamion = cliente.TipoCamion;
            cCliente.ZonaClave = cliente.ZonaClave;
            cCliente.SaldoEfectivo = cliente.SaldoEfectivo;
            cCliente.FechaFactura = cliente.FechaFactura;
            cCliente.DesgloseImpuesto = cliente.DesgloseImpuesto;
            cCliente.FacturacionMasiva = cliente.FacturacionMasiva;
            cCliente.FacturaFolioVenta = cliente.FacturaFolioVenta;
            cCliente.FacturaVentasMensual = cliente.FacturaVentasMensual;
            cCliente.GrabarDecXML = cliente.GrabarDecXML;
            cCliente.TipoImpuesto = cliente.TipoImpuesto;
            cCliente.UsoCFDI = cliente.UsoCFDI;
            cCliente.SitioWeb = cliente.SitioWeb;
            cCliente.SolicitarCapturaCompensacion = cliente.SolicitarCapturaCompensacion;
            cCliente.MFechaHora = DateTime.Now;
            cCliente.MUsuarioID = cliente.MUsuarioID;

            //ClienteEsquema
            foreach (ClienteEsquema ces in cliente.ClienteEsquema) {
                if (!cCliente.ClienteEsquema.ToList().Exists(x => x.EsquemaID == ces.EsquemaID))
                {
                    ClienteEsquema nces = new ClienteEsquema();
                    nces.ClienteClave = cCliente.ClienteClave;
                    nces.EsquemaID = ces.EsquemaID;
                    nces.TipoEstado = ces.TipoEstado;
                    nces.MFechaHora = DateTime.Now;
                    nces.MUsuarioID = cCliente.MUsuarioID;
                    cCliente.ClienteEsquema.Add(nces);
                }
                else {
                    cCliente.ClienteEsquema.First(x => x.EsquemaID == ces.EsquemaID).TipoEstado = ces.TipoEstado;
                    cCliente.ClienteEsquema.First(x => x.EsquemaID == ces.EsquemaID).MFechaHora = DateTime.Now;
                    cCliente.ClienteEsquema.First(x => x.EsquemaID == ces.EsquemaID).MUsuarioID = cCliente.MUsuarioID;
                }
            }

            //ClienteDomicilio
            bool agregar;
            foreach (ClienteDomicilio cld in cliente.ClienteDomicilio)
            {
                agregar = false;
                ClienteDomicilio ncld;
                if (!cCliente.ClienteDomicilio.ToList().Exists(x => x.ClienteDomicilioID == cld.ClienteDomicilioID))
                {
                    ncld = new ClienteDomicilio();
                    ncld.ClienteClave = cCliente.ClienteClave;
                    ncld.ClienteDomicilioID = cld.ClienteDomicilioID;
                    agregar = true;
                }
                else
                    ncld = cCliente.ClienteDomicilio.First(x => x.ClienteDomicilioID == cld.ClienteDomicilioID);

                ncld.Tipo = cld.Tipo;
                ncld.Calle = cld.Calle;
                ncld.Numero = cld.Numero;
                ncld.NumInt = cld.NumInt;
                ncld.CodigoPostal = cld.CodigoPostal;
                ncld.ReferenciaDom = cld.ReferenciaDom;
                ncld.Colonia = cld.Colonia;
                ncld.Localidad = cld.Localidad;
                ncld.Poblacion = cld.Poblacion;
                ncld.Entidad = cld.Entidad;
                ncld.Pais = cld.Pais;
                ncld.CoordenadaX = cld.CoordenadaX;
                ncld.CoordenadaY = cld.CoordenadaY;
                ncld.GLN = cld.GLN;
                ncld.CrTienda = cld.CrTienda;
                ncld.NombreTienda = cld.NombreTienda;
                ncld.Sucursal = cld.Sucursal;
                ncld.TipoEstado = cld.TipoEstado;
                ncld.MFechaHora = DateTime.Now;
                ncld.MUsuarioID = cCliente.MUsuarioID;

                if (ncld.Tipo == 2)
                {
                    if (agregar)
                    {
                        foreach (Secuencia sec in cld.Secuencia)
                        {
                            if (sec.Seleccionado)
                            {
                                Secuencia nsec = new Secuencia();
                                nsec.SECId = Guid.NewGuid().ToString().Substring(0, 16);
                                nsec.ClienteClave = cCliente.ClienteClave;
                                nsec.ClienteDomicilioID = ncld.ClienteDomicilioID;
                                nsec.FrecuenciaClave = sec.FrecuenciaClave;
                                nsec.MFechaHora = DateTime.Now;
                                nsec.MUsuarioID = cCliente.MUsuarioID;
                                ncld.Secuencia.Add(nsec);
                            }
                        }
                    }
                    else {
                        List<string> borrar = new List<string>();
                        if (cld.Secuencia.ToList().Count > 0) 
                        {
                            foreach (Secuencia sec in ncld.Secuencia)
                            {
                                if (!cld.Secuencia.ToList().Exists(x => x.FrecuenciaClave == sec.FrecuenciaClave && x.RUTClave == sec.RUTClave && x.Seleccionado))
                                    borrar.Add(sec.FrecuenciaClave + '|' + (sec.RUTClave == null ? "null" : sec.RUTClave));
                            }
                        }
                        foreach (string llave in borrar)
                        {
                            string FrecuenciaClave = llave.Split('|')[0];
                            string RUTClave = llave.Split('|')[1];

                            db.Secuencia.Remove(ncld.Secuencia.First(x => x.FrecuenciaClave == FrecuenciaClave && x.RUTClave == (RUTClave == "null" ? null : RUTClave)));
                            //ncld.Secuencia.Remove(ncld.Secuencia.First(x => x.FrecuenciaClave == FrecuenciaClave && x.RUTClave == (RUTClave == "null" ? null : RUTClave)));
                        }
                        foreach (Secuencia sec in cld.Secuencia)
                        {
                            if (sec.Seleccionado)
                            {
                                if (!ncld.Secuencia.ToList().Exists(x => x.FrecuenciaClave == sec.FrecuenciaClave && x.RUTClave == sec.RUTClave))
                                {
                                    Secuencia nsec = new Secuencia();
                                    nsec.SECId = Guid.NewGuid().ToString().Substring(0, 16);
                                    nsec.ClienteClave = cCliente.ClienteClave;
                                    nsec.ClienteDomicilioID = ncld.ClienteDomicilioID;
                                    nsec.FrecuenciaClave = sec.FrecuenciaClave;
                                    nsec.MFechaHora = DateTime.Now;
                                    nsec.MUsuarioID = cCliente.MUsuarioID;
                                    ncld.Secuencia.Add(nsec);
                                }
                            }
                        }

                    }
                }                

                if (agregar)
                    cCliente.ClienteDomicilio.Add(ncld);
            }

            //ClienteMensaje
            foreach (ClienteMensaje clm in cliente.ClienteMensaje) {
                ClienteMensaje nclm;
                agregar = false;
                if (!cCliente.ClienteMensaje.ToList().Exists(x => x.MDBMensajeID == clm.MDBMensajeID))
                {
                    nclm = new ClienteMensaje();
                    nclm.ClienteMensajeId = Guid.NewGuid().ToString().Substring(0, 16);
                    nclm.ClienteClave = cCliente.ClienteClave;
                    nclm.MDBMensajeID = clm.MDBMensajeID;
                    agregar = true;
                }
                else
                    nclm = cCliente.ClienteMensaje.First(x => x.MDBMensajeID == clm.MDBMensajeID);

                nclm.TipoEstado = clm.TipoEstado;
                nclm.MFechaHora = DateTime.Now;
                nclm.MUsuarioID = cCliente.MUsuarioID;

                if (agregar)
                    cCliente.ClienteMensaje.Add(nclm);
            }

            //ClientePago
            foreach (ClientePago clp in cliente.ClientePago)
            {
                ClientePago nclp;
                agregar = false;
                if (!cCliente.ClientePago.ToList().Exists(x => x.ClientePagoID == clp.ClientePagoID))
                {
                    nclp = new ClientePago();
                    nclp.ClienteClave = cCliente.ClienteClave;
                    nclp.ClientePagoID = clp.ClientePagoID;
                    agregar = true;
                }
                else
                    nclp = cCliente.ClientePago.First(x => x.ClientePagoID == clp.ClientePagoID);

                nclp.Tipo = clp.Tipo;
                nclp.TipoBanco = clp.TipoBanco;
                nclp.Cuenta = clp.Cuenta;
                nclp.TipoEstado = clp.TipoEstado;
                nclp.MFechaHora = DateTime.Now;
                nclp.MUsuarioID = cCliente.MUsuarioID;

                if (agregar)
                    cCliente.ClientePago.Add(nclp);
            }

            //CLIFormaVenta
            foreach (CLIFormaVenta cfv in cliente.CLIFormaVenta)
            {
                CLIFormaVenta ncfv;
                agregar = false;
                if (!cCliente.CLIFormaVenta.ToList().Exists(x => x.CFVTipo == cfv.CFVTipo))
                {
                    ncfv = new CLIFormaVenta();
                    ncfv.ClienteClave = cCliente.ClienteClave;
                    ncfv.CFVTipo = cfv.CFVTipo;
                    agregar = true;
                }
                else
                    ncfv = cCliente.CLIFormaVenta.First(x => x.CFVTipo == cfv.CFVTipo);

                ncfv.LimiteCredito = cfv.LimiteCredito;
                ncfv.DiasCredito = cfv.DiasCredito;
                ncfv.Inicial = cfv.Inicial;
                ncfv.CapturaDias = cfv.CapturaDias;
                ncfv.ValidaLimite = cfv.ValidaLimite;
                ncfv.ValidaPago = cfv.ValidaPago;
                ncfv.Estado = cfv.Estado;
                ncfv.MFechaHora = DateTime.Now;
                ncfv.MUsuarioID = cCliente.MUsuarioID;

                if (agregar)
                    cCliente.CLIFormaVenta.Add(ncfv);
            }

            //CliNoDesImp            
            List<string> eliminar = new List<string>();
            foreach (CLINoDesImp cnd in cCliente.CLINoDesImp)
            {
                if (!cliente.CLINoDesImp.ToList().Exists(x => x.CNDIID == cnd.CNDIID))
                    eliminar.Add(cnd.CNDIID);
            }
            foreach (string llave in eliminar)
            {
                cCliente.CLINoDesImp.First(x => x.CNDIID == llave).FechaFin = DateTime.Now;
                cCliente.CLINoDesImp.First(x => x.CNDIID == llave).MFechaHora = DateTime.Now;
                cCliente.CLINoDesImp.First(x => x.CNDIID == llave).MUsuarioID = cCliente.MUsuarioID;
            }

            foreach (CLINoDesImp cnd in cliente.CLINoDesImp)
            {                   
                if (cnd.CNDIID == "") {
                    CLINoDesImp ncnd = new CLINoDesImp();
                    ncnd.CNDIID = Guid.NewGuid().ToString().Substring(0, 16);
                    ncnd.ClienteClave = cCliente.ClienteClave;
                    ncnd.ImpuestoClave = cnd.ImpuestoClave;
                    ncnd.FechaInicio = DateTime.Now;
                    ncnd.FechaFin = DateTime.MaxValue;
                    ncnd.MFechaHora = DateTime.Now;
                    ncnd.MUsuarioID = cCliente.MUsuarioID;

                    cCliente.CLINoDesImp.Add(ncnd);
                }
            }

            //CLIConfNumCta
            eliminar = new List<string>();
            foreach (CLIConfNumCta cnc in cCliente.CLIConfNumCta)
            {
                
                if (!cliente.CLIConfNumCta.ToList().Exists(x => x.Campo == cnc.Campo))
                    eliminar.Add(cnc.Campo.ToString());
                else if (!cliente.CLIConfNumCta.First(x => x.Campo == cnc.Campo).Seleccionado)
                    eliminar.Add(cnc.Campo.ToString());
            }
            foreach (string llave in eliminar)
            {
                cCliente.CLIConfNumCta.Remove(cCliente.CLIConfNumCta.First(x => x.Campo.ToString() == llave));
            }

            foreach (CLIConfNumCta cnc in cliente.CLIConfNumCta)
            {
                if (cnc.Seleccionado) {
                    if (!cCliente.CLIConfNumCta.ToList().Exists(x => x.Campo == cnc.Campo))
                    {
                        CLIConfNumCta ncnc = new CLIConfNumCta();
                        ncnc.ClienteClave = cCliente.ClienteClave;
                        ncnc.Campo = cnc.Campo;
                        ncnc.Orden = cnc.Orden;
                        ncnc.MFechaHora = DateTime.Now;
                        ncnc.MUsuarioId = cCliente.MUsuarioID;
                        cCliente.CLIConfNumCta.Add(ncnc);
                    }
                    else {
                        cCliente.CLIConfNumCta.First(x => x.Campo == cnc.Campo).Orden = cnc.Orden;
                        cCliente.CLIConfNumCta.First(x => x.Campo == cnc.Campo).MFechaHora = DateTime.Now;
                        cCliente.CLIConfNumCta.First(x => x.Campo == cnc.Campo).MUsuarioId = cCliente.MUsuarioID;
                    }              
                }
            }

            //ExcepcionFac
            eliminar = new List<string>();
            foreach (ExcepcionFac exf in cCliente.ExcepcionFac)
            {
                if (!cliente.ExcepcionFac.ToList().Exists(x => x.EsquemaId == exf.EsquemaId && x.SubEmpresaId == exf.SubEmpresaId))
                    eliminar.Add(exf.EsquemaId + "|" + exf.SubEmpresaId);
            }
            foreach (string llave in eliminar)
            {
                string EsquemaId = llave.Split('|')[0];
                string SubEmpresaId = llave.Split('|')[1];
                cCliente.ExcepcionFac.Remove(cCliente.ExcepcionFac.First(x => x.EsquemaId == EsquemaId && x.SubEmpresaId == SubEmpresaId));
            }

            foreach (ExcepcionFac exf in cliente.ExcepcionFac)
            {
                if (!cCliente.ExcepcionFac.ToList().Exists(x => x.EsquemaId == exf.EsquemaId && x.SubEmpresaId == exf.SubEmpresaId)) { 
                    ExcepcionFac nexf = new ExcepcionFac();
                    nexf.ClienteClave = cCliente.ClienteClave;
                    nexf.EsquemaId = exf.EsquemaId;
                    nexf.SubEmpresaId = exf.SubEmpresaId;
                    nexf.MFechaHora = DateTime.Now;
                    nexf.MUsuarioID = cCliente.MUsuarioID;

                    cCliente.ExcepcionFac.Add(nexf);
                }
            }

            //ExcepcionProductoPri
            eliminar = new List<string>();
            foreach (ExcepcionProductoPri epp in cCliente.ExcepcionProductoPri)
            {
                if (!cliente.ExcepcionProductoPri.ToList().Exists(x => x.ProductoClave == epp.ProductoClave))
                    eliminar.Add(epp.ProductoClave);
            }
            foreach (string llave in eliminar)
            {
                cCliente.ExcepcionProductoPri.Remove(cCliente.ExcepcionProductoPri.First(x => x.ProductoClave == llave));
            }

            foreach (ExcepcionProductoPri epp in cliente.ExcepcionProductoPri)
            {
                if (!cCliente.ExcepcionProductoPri.ToList().Exists(x => x.ProductoClave == epp.ProductoClave))
                {
                    ExcepcionProductoPri nepp = new ExcepcionProductoPri();
                    nepp.ClienteClave = cCliente.ClienteClave;
                    nepp.ProductoClave = epp.ProductoClave;
                    nepp.TipoExcepcion = epp.TipoExcepcion;
                    nepp.MFechaHora = DateTime.Now;
                    nepp.MUsuarioId = cCliente.MUsuarioID;

                    cCliente.ExcepcionProductoPri.Add(nepp);
                }
                else {
                    cCliente.ExcepcionProductoPri.First(x => x.ProductoClave == epp.ProductoClave).TipoExcepcion = epp.TipoExcepcion;
                    cCliente.ExcepcionProductoPri.First(x => x.ProductoClave == epp.ProductoClave).MFechaHora = DateTime.Now;
                    cCliente.ExcepcionProductoPri.First(x => x.ProductoClave == epp.ProductoClave).MUsuarioId = cCliente.MUsuarioID;
                }
            }

            if (!existe)
                db.Cliente.Add(cCliente);

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

        [HttpGet]
        [ActionName("validarClaveCliente")]
        public bool validarClaveCliente(string clave, string clienteClave)
        {
            var cod = (from x in db.Cliente where x.Clave == clave && x.ClienteClave != clienteClave select x);

            if(cod.ToList().Count > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }

        [HttpGet]
        [ActionName("validarCodigo")]
        public string validarCodigo(string codigo, string clienteClave)
        {
            var cod = (from x in db.Cliente where x.IdElectronico == codigo && x.ClienteClave != clienteClave select x);

            if (cod.ToList().Count > 0)
            {
                return cod.ToList()[0].Clave;
            }
            else
            {
                return "";
            }
        }

        [HttpGet]
        [ActionName("ObtenerEsquemas")]
        public IHttpActionResult ObtenerEsquemas()
        {

            var padres = (from x in db.Esquema
                          where x.Nivel == 0 && x.Tipo == 1 && x.TipoEstado == 1 
                          select new cEsquema
                          {
                              Nombre = x.Nombre,
                              Abreviatura = x.Abreviatura,
                              EsquemaID = x.EsquemaID,
                              EsquemaIDPadre = x.EsquemaIDPadre,
                              Tipo = x.Tipo,
                              Orden = x.Orden,
                              Clasificacion = x.Clasificacion,
                              TipoEstado = x.TipoEstado,
                              NivelHijo = x.Nivel.ToString()
                          }).ToList();

            foreach (cEsquema esq in padres)
            {
                //Se busca sobre los padres sí tiene hijos
                obtenerHijos(esq, esq.NivelHijo);
            }
            return Json(padres);
        }

        public void obtenerHijos(cEsquema esquema, string nivel)
        {
            int nivelAux = (nivel == null ? 0 : Convert.ToInt32((nivel).ToString()));
            int nivelHijo = nivelAux + 1;
            var hijos = (from x in db.Esquema
                         where x.EsquemaIDPadre == esquema.EsquemaID
                         select new cEsquema
                         {

                             Nombre = x.Nombre,
                             Abreviatura = x.Abreviatura,
                             EsquemaID = x.EsquemaID,
                             EsquemaIDPadre = x.EsquemaIDPadre,
                             Tipo = x.Tipo,
                             Clasificacion = x.Clasificacion,
                             Orden = x.Orden,
                             TipoEstado = x.TipoEstado,
                             NivelHijo = nivelHijo.ToString()

                         }).ToList();

            if (hijos.Count > 0)
            {
                foreach (cEsquema esq in hijos)
                {
                    //Se busca sobre los padres sí tiene hijos
                    obtenerHijos(esq, esq.NivelHijo);
                }
                esquema.esquemas = hijos;
                esquema.children = hijos;

            }

        }

        [HttpGet]
        [ActionName("MensajeContador")]
        public IHttpActionResult MensajeContador(short tipo)
        {
            var cont = (from x in db.MDBMensaje where x.MDBMensajeTipo == tipo select new { x.ClienteMensaje }).ToList().Count;
            return Json(cont);
        }        

        [HttpGet]
        [ActionName("ObtenerCentroDistribucion")]
        public IHttpActionResult ObtenerCentroDistribucion()
        {
            var lista = new List<cAlmacen>();

            var cedi = (
                from x in db.Almacen
                where x.Tipo.Equals("1") && x.TipoEstado == 1
                select new cAlmacen { AlmacenID = x.AlmacenID, NombreCompuesto = x.Clave + " - " + x.Nombre });
            return Json(cedi);

        }

                
        public bool TieneCobranzaPendiente(string ClienteClave)
        {
            IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
            System.Text.StringBuilder sQuery = new System.Text.StringBuilder();
            sQuery.AppendLine("select top 1 TipoCobranza from CONHist order by CONHistFechaInicio desc ");

            int tipoCobranza = (int)Connection.ExecuteScalar(sQuery.ToString());
            sQuery.Clear();
            sQuery.AppendLine("select count(TransProdID) as Total from ( ");
            if (tipoCobranza == 0 || tipoCobranza == 2)
            {
                //--FACTURAS
                sQuery.AppendLine("select distinct TRP.TransProdID ");
                sQuery.AppendLine("from TransProd TRP ");
                sQuery.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                sQuery.AppendLine("where TRP.Tipo = 8 and TRP.TipoFase <> 0 and ");
                sQuery.AppendLine("(TRP.Saldo - (select isnull(sum(TRC.AbnChequePosfechado),0) from TRPCheque TRC where TRC.TransProdID = TRP.TransProdID)) > 0 ");
                sQuery.AppendLine("and VIS.ClienteClave = '" + ClienteClave + "' ");
            }
            if (tipoCobranza == 2)
            {
                sQuery.AppendLine("union ");
            }
            if (tipoCobranza == 1 || tipoCobranza == 2)
            {
                //--VENTAS
                sQuery.AppendLine("select distinct TRP.TransProdID ");
                sQuery.AppendLine("from TransProd TRP ");
                sQuery.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                sQuery.AppendLine("where TRP.Tipo = 1 and TRP.TipoFase in (2,3) and ");
                sQuery.AppendLine("(TRP.Saldo - (select isnull(sum(TRC.AbnChequePosfechado),0) from TRPCheque TRC where TRC.TransProdID = TRP.TransProdID)) > 0 ");
                sQuery.AppendLine("and VIS.ClienteClave = '" + ClienteClave + "' ");
            }
            sQuery.AppendLine(") as t ");
            int cantCobranza = (int)Connection.ExecuteScalar(sQuery.ToString());
            return (cantCobranza > 0);
        }
        
        [HttpGet]
        [ActionName("ObtenerCliente")]
        public IHttpActionResult ObtenerCliente(string ClienteClave)
        {
            RouteEntities db = new RouteEntities();
            int saldoPrestamo = db.ProductoPrestamoCli.Where(c => c.ClienteClave == ClienteClave).ToList().Sum(c => c.Saldo);

            bool tieneCobranza = TieneCobranzaPendiente(ClienteClave);

            var msg = (from cli in db.Cliente
                       where cli.ClienteClave == ClienteClave
                       select new {
                           cli.ClienteClave,
                           cli.Clave,
                           cli.FechaRegistroSistema,
                           TipoEstado = cli.TipoEstado.ToString(),
                           cli.IdElectronico,
                           FechaInactivacion = (cli.FechaInactivacion == null ? DateTime.Now : cli.FechaInactivacion),
                           cli.MotivoInactivacion,
                           cli.RazonSocial,
                           cli.IdFiscal,
                           FechaNacimiento = (cli.FechaNacimiento == null ? DateTime.Now : cli.FechaNacimiento),
                           cli.NombreCorto,
                           cli.NumeroSAP,
                           cli.AlmacenID,
                           cli.DatosExtra,
                           cli.NombreContacto,
                           cli.TelefonoContacto,
                           cli.CorreoElectronico,
                           PublicoGeneral = (cli.PublicoGeneral == 1 ? true : false),
                           AseguramientoGPS = (cli.AseguramientoGPS == 1 ? true : false),
                           TipoFiscal = cli.TipoFiscal.ToString(),
                           cli.ActualizaSaldoCheque,
                           cli.Exclusividad,
                           cli.VigExclusividad,
                           cli.ExigirOrdenCompra,
                           cli.ExigirPedidoAdicional,
                           cli.FormatoPedidoAdicional,
                           cli.ValidaFolNeg,
                           cli.VencimientoVenta,
                           cli.DiasVencimiento,
                           cli.Prestamo,
                           cli.ValidarLimEnvase,
                           cli.LimiteEnvase,
                           cli.ExigirTomaInvMer,
                           BonificacionMasiva = (cli.BonificacionMasiva == 1 ? true : false),
                           TipoCamion = cli.TipoCamion.ToString(),
                           cli.ZonaClave,
                           cli.SaldoEfectivo,
                           FechaFactura = (cli.FechaFactura == null ? new DateTime(2999, 1, 1) : cli.FechaFactura),
                           SaldoPrestamo = saldoPrestamo,
                           cli.DesgloseImpuesto,
                           cli.FacturacionMasiva,
                           FacturaFolioVenta = (cli.FacturaFolioVenta == 1 ? true : false),
                           FacturaVentasMensual = (cli.FacturaVentasMensual == 1 ? true : false),
                           cli.GrabarDecXML,
                           TipoImpuesto = cli.TipoImpuesto.ToString(),
                           UsoCFDI = cli.UsoCFDI.ToString(),
                           cli.SitioWeb,
                           SolicitarCapturaCompensacion = (cli.SolicitarCapturaCompensacion == 1 ? true : false),
                           CobranzaPendiente = tieneCobranza });

            if (msg.ToList().Count > 0)
                return Json(msg.ToList()[0]);
            else
                return null;
        }

        [HttpGet]
        [ActionName("ObtenerClienteEsquema")]
        public IHttpActionResult ObtenerClienteEsquema(string ClienteClave)
        {
            RouteEntities db = new RouteEntities();
            var esquemas = (from esq in db.Esquema
                       join ces in db.ClienteEsquema on esq.EsquemaID equals ces.EsquemaID
                       where ces.ClienteClave == ClienteClave
                       select new {
                           esq.EsquemaID,
                           esq.Clave,
                           esq.Nombre,
                           TipoEstado = ces.TipoEstado.ToString(),
                           Nuevo = false
                       }).ToList();
            return Json(esquemas);
        }

        [HttpGet]
        [ActionName("ObtenerClienteDomicilio")]
        public IHttpActionResult ObtenerClienteDomicilio(string ClienteClave)
        {
            RouteEntities db = new RouteEntities();
            var domicilios = (from cld in db.ClienteDomicilio
                              join vad in db.VAVDescripcion on cld.Tipo.ToString() equals vad.VAVClave
                              where cld.ClienteClave == ClienteClave && vad.VARCodigo == "DOMTIPO" && vad.VADTipoLenguaje == "EM"
                            select new
                            {
                                cld.ClienteDomicilioID,
                                Tipo = cld.Tipo.ToString(),
                                cld.Calle,
                                cld.Numero,
                                cld.NumInt,
                                cld.CodigoPostal,
                                cld.ReferenciaDom,
                                cld.Colonia,
                                cld.Localidad,
                                cld.Poblacion,
                                cld.Entidad,
                                cld.Pais,
                                CoordenadaX = cld.CoordenadaX, //Longitud
                                CoordenadaY = cld.CoordenadaY, //Latitud
                                cld.GLN,
                                cld.CrTienda,
                                cld.NombreTienda,
                                cld.Sucursal,
                                cld.TipoEstado,
                                TipoDescripcion = vad.Descripcion,
                                Nuevo = false
                            }).ToList();
            return Json(domicilios);
        }

        [HttpGet]
        [ActionName("ObtenerClienteMensaje")]
        public IHttpActionResult ObtenerClienteMensaje(string ClienteClave)
        {
            RouteEntities db = new RouteEntities();

            var modulos = (from mdb in db.MDBMensaje                           
                           join mod in db.ModuloMensaje on mdb.MDBMensajeID equals mod.MDBMensajeID
                           //join mdt in db.ModuloTerm on mod.TipoIndice equals mdt.TipoIndice
                           join vav in db.VAVDescripcion on new { VARCodigo = "TINDMOD", VAVClave = mod.TipoIndice.ToString(), VADTipoLenguaje = "EM" } equals new { VARCodigo = vav.VARCodigo, VAVClave = vav.VAVClave, VADTipoLenguaje = vav.VADTipoLenguaje }
                           //where mdt.Tipo == 1
                           orderby mdb.MDBMensajeID
                           select new { mdb.MDBMensajeID, Modulo = vav.Descripcion }).ToList();

            List<ModulosMensaje> modulosMen = new List<ModulosMensaje>();
            string id = "";
            string mods = "";
            foreach (var mod in modulos) {                
                if (id != "" && id != mod.MDBMensajeID) {
                    mods = mods.Substring(0, mods.Length - 2);
                    modulosMen.Add(new ModulosMensaje { MDBMensajeID = id, Modulos = mods });
                    mods = "";
                }
                id = mod.MDBMensajeID;
                mods += mod.Modulo + ", ";
            }
            if (mods.Length > 0) {
                mods = mods.Substring(0, mods.Length - 2);
                modulosMen.Add(new ModulosMensaje { MDBMensajeID = id, Modulos = mods });
            }
                        
            var mensajes = (from clm in db.ClienteMensaje
                              join mdb in db.MDBMensaje on clm.MDBMensajeID equals mdb.MDBMensajeID
                              //join vad1 in db.VAVDescripcion on clm.TipoEstado.ToString() equals vad1.VAVClave
                              join vad2 in db.VAVDescripcion on mdb.MDBMensajeTipo.ToString() equals vad2.VAVClave
                              where clm.ClienteClave == ClienteClave //&& vad1.VARCodigo == "EDOREG" && vad1.VADTipoLenguaje == "EM" 
                              && vad2.VARCodigo == "MDBMENT" && vad2.VADTipoLenguaje == "EM"
                              select new
                              {
                                 clm.MDBMensajeID,
                                 mdb.Numero,
                                 mdb.Asunto,
                                 TipoMensaje = vad2.Descripcion,
                                 mdb.Descripcion,
                                 TipoEstado = clm.TipoEstado.ToString() //vad1.Descripcion
                              }).ToList();


            List<VistaClienteMensaje> cteMensaje = new List<VistaClienteMensaje>();
            foreach (var msg in mensajes) {
                string sModulos = "";

                if (modulosMen.Exists(x => x.MDBMensajeID == msg.MDBMensajeID))
                    sModulos = modulosMen.Find(x => x.MDBMensajeID == msg.MDBMensajeID).Modulos;

                cteMensaje.Add(new Models.VistaClienteMensaje {
                    MDBMensajeID = msg.MDBMensajeID,
                    Numero = msg.Numero,
                    Asunto = msg.Asunto,
                    TipoMensaje = msg.TipoMensaje,
                    Descripcion = msg.Descripcion,
                    TipoEstado = msg.TipoEstado,
                    Modulos = sModulos,
                    Nuevo = false
                });
            }            
            
            return Json(cteMensaje);
        }

        [HttpGet]
        [ActionName("ObtenerClientePago")]
        public IHttpActionResult ObtenerClientePago(string ClienteClave)
        {
            RouteEntities db = new RouteEntities();

            var mensajes = (from pago in db.ClientePago
                                join vad in db.VAVDescripcion on pago.Tipo.ToString() equals vad.VAVClave
                                //join vav in db.VARValor on pago.Tipo.ToString() equals vav.VAVClave
                            where pago.ClienteClave == ClienteClave
                            && vad.VARCodigo == "PAGO" && vad.VADTipoLenguaje == "EM" && vad.VARCodigo == "PAGO"
                            select new
                            {
                                pago.ClientePagoID,
                                Tipo = pago.Tipo.ToString(),
                                TipoBanco = pago.TipoBanco.ToString(),
                                pago.Cuenta,
                                TipoEstado = pago.TipoEstado.ToString(),
                                Nuevo = false,
                                Efectivo = (vad.Descripcion.ToUpper() == "EFECTIVO")
                            }).ToList();

            return Json(mensajes);
        }

        [HttpGet]
        [ActionName("ObtenerCLIFormaVenta")]
        public IHttpActionResult ObtenerCLIFormaVenta(string ClienteClave)
        {
            RouteEntities db = new RouteEntities();

            var formas = (from cfv in db.CLIFormaVenta
                            //join vad1 in db.VAVDescripcion on cfv.CFVTipo.ToString() equals vad1.VAVClave
                            //join vad2 in db.VAVDescripcion on cfv.Estado.ToString() equals vad2.VAVClave
                            where cfv.ClienteClave == ClienteClave
                            //&& vad1.VARCodigo == "FVENTA" && vad1.VADTipoLenguaje == "EM" 
                            //&& vad2.VARCodigo == "EDOREG" && vad2.VADTipoLenguaje == "EM"
                            select new
                            {
                                CFVTipo = cfv.CFVTipo.ToString(),
                                cfv.LimiteCredito,
                                cfv.DiasCredito,
                                cfv.Inicial,
                                cfv.CapturaDias,
                                cfv.ValidaLimite,
                                cfv.ValidaPago,
                                Estado = cfv.Estado.ToString(),
                                Nuevo = false
                            }).ToList();

            return Json(formas);
        }

        [HttpGet]
        [ActionName("ObtenerProductoPrestamoCLI")]
        public IHttpActionResult ObtenerProductoPrestamoCLI(string ClienteClave)
        {
            RouteEntities db = new RouteEntities();

            var productos = (from ppc in db.ProductoPrestamoCli 
                          join pro in db.Producto on ppc.ProductoClave equals pro.ProductoClave 
                          where ppc.ClienteClave == ClienteClave && ppc.Saldo != 0
                          select new
                          {
                              pro.ProductoClave,
                              pro.NombreLargo,
                              ppc.Saldo
                          }).ToList();

            return Json(productos);
        }

        [HttpGet]
        [ActionName("ObtenerCLINoDesImp")]
        public IHttpActionResult ObtenerCLINoDesImp(string ClienteClave)
        {
            RouteEntities db = new RouteEntities();

            var formas = (from cnd in db.CLINoDesImp
                          join imp in db.Impuesto on cnd.ImpuestoClave equals imp.ImpuestoClave 
                          where cnd.ClienteClave == ClienteClave && cnd.FechaFin > DateTime.Now
                          select new
                          {
                             cnd.CNDIID,
                             imp.ImpuestoClave,
                             imp.Nombre,
                             imp.Abreviatura 
                          }).ToList();

            return Json(formas);
        }

        [HttpGet]
        [ActionName("ObtenerCliConfNumCta")]
        public IHttpActionResult ObtenerCliConfNumCta(string ClienteClave)
        {
            RouteEntities db = new RouteEntities();

            var config = (from val in db.VARValor
                          //join vad in db.VAVDescripcion on new { VARCodigo = val.VARCodigo, VAVClave = val.VAVClave } equals new { VARCodigo = vad.VARCodigo, VAVClave = vad.VAVClave }
                          join cnc in db.CLIConfNumCta on new { ClienteClave = ClienteClave, Campo = val.VAVClave } equals new { ClienteClave = cnc.ClienteClave, Campo = cnc.Campo.ToString() } into left 
                          from cnc in left.DefaultIfEmpty()
                          where val.VARCodigo == "CONFCTA" //&& vad.VADTipoLenguaje == "EM"
                          select new
                          {
                              Seleccionado = (val.VAVClave.Equals("1") || val.VAVClave.Equals("3") ? true : (cnc.ClienteClave != null ? true : false )),
                              Campo = val.VAVClave,
                              Orden = (cnc.ClienteClave == null ? 0 : cnc.Orden)
                          }).ToList();

            return Json(config);
        }

        [HttpGet]
        [ActionName("ObtenerExcepcionFac")]
        public IHttpActionResult ObtenerExcepcionFac(string ClienteClave)
        {
            RouteEntities db = new RouteEntities();

            var formas = (from exf in db.ExcepcionFac
                          join esq in db.Esquema on exf.EsquemaId equals esq.EsquemaID
                          //join sub in db.SubEmpresa on exf.SubEmpresaId equals sub.SubEmpresaId 
                          where exf.ClienteClave == ClienteClave
                          select new
                          {
                              esq.EsquemaID,
                              esq.Clave,
                              esq.Nombre,
                              exf.SubEmpresaId 
                          }).ToList();

            return Json(formas);
        }

        [HttpGet]
        [ActionName("ObtenerExcepcionProductoPri")]
        public IHttpActionResult ObtenerExcepcionProductoPri(string ClienteClave)
        {
            RouteEntities db = new RouteEntities();

            var formas = (from exp in db.ExcepcionProductoPri
                          join pro in db.Producto on exp.ProductoClave equals pro.ProductoClave
                          where exp.ClienteClave == ClienteClave
                          select new
                          {
                              pro.ProductoClave,
                              pro.Nombre,
                              TipoExcepcion = exp.TipoExcepcion.ToString()
                          }).ToList();

            return Json(formas);
        }

        [HttpGet]
        [ActionName("ObtenerSubEmpresas")]
        public IHttpActionResult ObtenerSubEmpresas()
        {
            var subEmpresas = (
                from sub in db.SubEmpresa
                where sub.TipoEstado == 1
                select new
                {
                    sub.SubEmpresaId,
                    sub.NombreEmpresa
                });

            return Json(subEmpresas);
        }

        [HttpGet]
        [ActionName("ObtenerNuevoID")]
        public IHttpActionResult ObtenerNuevoID()
        {
            return Json(Guid.NewGuid().ToString().Substring(0, 16));
        }

        [HttpGet]
        [ActionName("ObtenerSecuenciaVisita")]
        public IHttpActionResult ObtenerSecuenciaVisita(string ClienteClave, string ClienteDomicilioID)
        {
            RouteEntities db = new RouteEntities();

            var mensajes = (from fre in db.Frecuencia
                            join sec in db.Secuencia on new { FrecuenciaClave = fre.FrecuenciaClave, ClienteClave = ClienteClave, ClienteDomicilioID = ClienteDomicilioID } equals new { FrecuenciaClave = sec.FrecuenciaClave, ClienteClave = sec.ClienteClave, ClienteDomicilioID = sec.ClienteDomicilioID } into left
                            from sec in left.DefaultIfEmpty()
                            where fre.FechaFinal >= DateTime.Now
                            select new
                            {                                
                                Seleccionado = (sec.FrecuenciaClave != null ? true : false),
                                sec.ClienteClave,
                                sec.ClienteDomicilioID,
                                fre.FrecuenciaClave,
                                fre.Descripcion,
                                Tipo = fre.Tipo.ToString(),
                                fre.FechaInicio,
                                fre.FechaFinal,
                                UnidadInicio = fre.UnidadInicio.ToString(),
                                fre.Repeticion,
                                fre.Intervalo,
                                sec.RUTClave
                            }).ToList();

            return Json(mensajes);
        }

        [HttpGet]
        [ActionName("ValidarExisteTipoDomicilio")]
        public bool ValidarExisteTipoDomicilio(string ClienteClave, string Tipo)
        {
            RouteEntities db = new RouteEntities();
            var tipos = (from cld in db.ClienteDomicilio
                              where cld.ClienteClave == ClienteClave && cld.Tipo.ToString() == Tipo
                              select new
                              {
                                  Tipo = cld.Tipo.ToString()
                              }).ToList();

            return tipos.Count > 0;
        }

    }
}