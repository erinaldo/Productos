using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eRoute.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace eRoute.Controllers.API
{
    public class ConfiguracionController : ApiController
    {
        [HttpGet]
        [ActionName("ObtenerLenguaje")]
        public IHttpActionResult ObtenerLenguaje()
        {
            try
            {
                RouteEntities db = new RouteEntities();
                var lenguaje = (from config in db.CONHist
                                orderby config.CONHistFechaInicio descending
                                select config.TipoLenguaje).Take(1).ToList()[0];

                return Json(lenguaje);
            }
            catch (Exception)
            {
                return Json("EM");
            }

        }

        [HttpGet]
        [ActionName("ObtenerConfiguracion")]
        public IHttpActionResult ObtenerConfiguracion()
        {
            RouteEntities db = new RouteEntities();
            var cfg = (from config in db.Configuracion
                       join conhist in db.CONHist on config.ConfiguracionID equals conhist.ConfiguracionID
                       orderby conhist.CONHistFechaInicio descending
                       select new { config, conhist });
            //select new { config.Logotipo, config.NombreEmpresa, config.RFC, config.Telefono, config.Calle, config.Numero, config.NumeroInterior, config.Colonia,
            //             config.CodigoPostal, config.ReferenciaDom, config.Localidad, config.Ciudad, config.Region, config.Pais, config.Contrato,
            //             conhist.TipoLenguaje, conhist.MonedaID, conhist.MostrarLogo, conhist.TipoClaveProducto, conhist.DigitoClaveProd, conhist.DiasSurtido,
            //             conhist.DiasMaxSurtido, conhist.CambioProducto, conhist.ConversionKg, conhist.ActualizarEdoProducto, conhist.FiltroProductos, 
            //             conhist.VariosPedidos, conhist.AbonoProgramado, conhist.VenderApartado, conhist.CalcPromoAuto, conhist.PagoAutomatico, conhist.VentaSinSurtir,
            //             conhist.CancConsigLiqui, conhist.ExcederAbono, conhist.MostrarCEDI, conhist.DecimalesImporte, conhist.TicketConfigurado, conhist.PorcentajeRiesgo,
            //             conhist.TicketConfigCobranza, conhist.ProductosVenta, conhist.TicketConfigFactura, conhist.TipoLimiteCredito, conhist.FormatoNotaVenta,
            //             conhist.TipoCobranza, conhist.ClienteVariasRutas, conhist.DatosCteNuevo, conhist.ValidaInv, conhist.ConsignaSaldada, conhist.ConsignaContado,
            //             conhist.DiasAnteriores, conhist.DiasPosteriores, conhist.MaximoVisitasRDI, conhist.DirectorioSDF, conhist.DirInterfaz, conhist.SpNormalizacionBD,
            //             conhist.TipoEnvioCarga, conhist.DiferenciaPreliqui, conhist.CantidadSerAct, conhist.InterfazTXT, conhist.IntUnidadVta, conhist.Inventario,
            //             conhist.AuditarCarga, conhist.ProductoCarga, conhist.PreLiquidacion, conhist.EnvioParcial, conhist.EliminaEnviado, conhist.ActualizaCliente,
            //             conhist.ServidorSMTP, conhist.SSL, conhist.Puerto, conhist.Correo, conhist.Password, conhist.SemanasCargaPromedio, conhist.ExpCargaSugerida,
            //             conhist.SpCargaSugerida, conhist.FolioAutCarga, conhist.HabilitaInventario, conhist.TicketConfigKardex
            //});
            
            if (cfg.ToList().Count > 0) {
                var img64 = "";
                if (cfg.First().config.Logotipo != null)
                {
                    img64 = Convert.ToBase64String(cfg.First().config.Logotipo);
                }

                string vencimiento = "";
                try {
                    ValidarCertificadoSQL();
                    vencimiento = RecuperarVEF();
                }
                catch (Exception e) {
                }

                var conf = from config in cfg
                           select new
                           {
                               config.config,
                               config.conhist,
                               LogotipoBase64 = img64,
                               FechaVencimiento = vencimiento
                           };


                return Json(conf.First());
            }
            else
                return null;
        }

       
        [HttpGet]
        [ActionName("ObtenerSPNormalizacion")]
        public IHttpActionResult ObtenerSPNormalizacion()
        {
            IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
            string sQuery = "select name from dbo.sysobjects where type = 'P' and name like 'sp_NormalizacionBD%' order by name ";

            List<SPNormalizacion> lstSPNormalizacion = Connection.Query<SPNormalizacion>(sQuery).ToList();
            if (lstSPNormalizacion.Count > 0)
                return Json(lstSPNormalizacion);
            else
                return null;
        }

        [HttpGet]
        [ActionName("ObtenerSPExportarCarga")]
        public IHttpActionResult ObtenerSPExportarCarga()
        {
            IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
            string sQuery = "select name from dbo.sysobjects where type = 'P' and name like 'sp_tg_export%' order by name ";

            List<SPNormalizacion> lstSPNormalizacion = Connection.Query<SPNormalizacion>(sQuery).ToList();
            if (lstSPNormalizacion.Count > 0)
                return Json(lstSPNormalizacion);
            else
                return null;
        }

        [HttpGet]
        [ActionName("ValidarSerial")]
        public IHttpActionResult ValidarSerial(string serial, string contrato) {
            string refContrato = "";
            int factura = 0;
            DateTime vencimiento = DateTime.Now;
            try
            {
                //BASLICLOG.Encoder.ObtenerDatos(serial, ref refContrato, ref factura, ref vencimiento);
                if (contrato.Length > 6)
                    contrato = contrato.Substring(contrato.Length - 6, 6);
                else if (contrato.Length < 6)
                    contrato = contrato.PadLeft(6, '0');               

                if (!refContrato.Equals(contrato.ToUpper())) 
                    return Json("");

                GuardarVEF(vencimiento);

                return Json(vencimiento.ToString("dd/MM/yyyy"));
            }
            catch (Exception e) {
                return null;
            }            
        }

        private void GuardarVEF(DateTime vencimiento) {
            IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
            System.Text.StringBuilder sQuery = new System.Text.StringBuilder();
            sQuery.AppendLine("OPEN SYMMETRIC KEY Arrendamiento_Key");
            sQuery.AppendLine("DECRYPTION BY CERTIFICATE Arrendamiento;");
            sQuery.AppendLine("UPDATE Configuracion");
            sQuery.AppendLine("SET VEF = EncryptByKey(Key_GUID('Arrendamiento_Key'),'" + vencimiento.ToString("dd/MM/yyyy") + "',1,HashBytes('SHA1',CONVERT(varbinary,RFC)));");
            Connection.Execute(sQuery.ToString());
        }

        private void ValidarCertificadoSQL() {
            IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
            System.Text.StringBuilder sQuery = new System.Text.StringBuilder();
            sQuery.AppendLine("IF NOT EXISTS (SELECT * FROM sys.symmetric_keys WHERE symmetric_key_id = 101)");
            sQuery.AppendLine("BEGIN");
            sQuery.AppendLine("CREATE MASTER KEY ENCRYPTION BY ");
            sQuery.AppendLine("PASSWORD = '23987hxJKL95QYV4369#ghf0%lekjg5k3fd117r$$#1946kcj$n44ncjhdlj'");
            sQuery.AppendLine("CREATE CERTIFICATE Arrendamiento");
            sQuery.AppendLine("WITH SUBJECT = 'Fecha de Arrendamiento Route';");
            sQuery.AppendLine("CREATE SYMMETRIC KEY Arrendamiento_Key");
            sQuery.AppendLine("WITH ALGORITHM = AES_256");
            sQuery.AppendLine("ENCRYPTION BY CERTIFICATE Arrendamiento;");
            sQuery.AppendLine("END");
            Connection.Execute(sQuery.ToString());
        }

        private string RecuperarVEF()
        {
            IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
            System.Text.StringBuilder sQuery = new System.Text.StringBuilder();
            try
            {
                sQuery.AppendLine("OPEN SYMMETRIC KEY Arrendamiento_Key");
                sQuery.AppendLine("DECRYPTION BY CERTIFICATE Arrendamiento;");
                sQuery.AppendLine("SELECT CONVERT(varchar,DecryptByKey(VEF,1,HashBytes('SHA1',CONVERT(varbinary, RFC))))");
                sQuery.AppendLine("FROM Configuracion;");
                sQuery.AppendLine("OPEN MASTER KEY DECRYPTION BY PASSWORD = '23987hxJKL95QYV4369#ghf0%lekjg5k3fd117r$$#1946kcj$n44ncjhdlj'");
                sQuery.AppendLine("ALTER MASTER KEY ADD ENCRYPTION BY SERVICE MASTER KEY");
                object vencimiento = Connection.ExecuteScalar(sQuery.ToString());
                if (vencimiento != null)
                    return DateTime.Parse(vencimiento.ToString()).ToString("dd/MM/yyyy");
                else
                    return "";
            } catch (System.Data.OleDb.OleDbException ex) {
                if (ex.Errors[0].NativeError == 15581)
                {
                    sQuery = new System.Text.StringBuilder();
                    sQuery.AppendLine("OPEN MASTER KEY DECRYPTION BY PASSWORD = '23987hxJKL95QYV4369#ghf0%lekjg5k3fd117r$$#1946kcj$n44ncjhdlj'");
                    sQuery.AppendLine("ALTER MASTER KEY ADD ENCRYPTION BY SERVICE MASTER KEY");
                    Connection.Execute(sQuery.ToString());
                }
                else if (ex.Errors[0].NativeError == 15466)
                {
                    sQuery = new System.Text.StringBuilder();
                    sQuery.AppendLine("OPEN MASTER KEY");
                    sQuery.AppendLine("DECRYPTION BY PASSWORD = '23987hxJKL95QYV4369#ghf0%lekjg5k3fd117r$$#1946kcj$n44ncjhdlj';");
                    sQuery.AppendLine("ALTER MASTER KEY");
                    sQuery.AppendLine("DROP ENCRYPTION BY SERVICE MASTER KEY;");
                    sQuery.AppendLine("ALTER MASTER KEY");
                    sQuery.AppendLine("ADD ENCRYPTION BY SERVICE MASTER KEY;");
                    sQuery.AppendLine("CLOSE MASTER KEY;");
                    Connection.Execute(sQuery.ToString());
                }
                return "";            
            }
        }

        [HttpPost]
        public bool Grabar(Configuracion cfg)
        {
            RouteEntities db = new RouteEntities();
            bool nuevo = false;

            Configuracion config;
            if (db.Configuracion.ToList().Count > 0)
                config = db.Configuracion.First();
            else
            {
                config = new Configuracion();
                config.ConfiguracionID = Guid.NewGuid().ToString().Substring(0, 16);
                nuevo = true;
            }

            byte[] newBytes = Convert.FromBase64String(cfg.LogotipoBase64);

            config.Logotipo = newBytes;
            config.NombreEmpresa = cfg.NombreEmpresa;
            config.RFC = cfg.RFC;
            config.Pais = cfg.Pais;
            config.Region = cfg.Region;
            config.Localidad = cfg.Localidad;
            config.ReferenciaDom = cfg.ReferenciaDom;
            config.Ciudad = cfg.Ciudad;
            config.Colonia = cfg.Colonia;
            config.Calle = cfg.Calle;
            config.Numero = cfg.Numero;
            config.NumeroInterior = cfg.NumeroInterior;
            config.CodigoPostal = cfg.CodigoPostal;
            config.Telefono = cfg.Telefono;
            config.Contrato = cfg.Contrato;
            config.MFechaHora = DateTime.Now;
            config.MUsuarioID = cfg.MUsuarioID;
            
            if (nuevo)
                db.Configuracion.Add(config);

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
        public bool GrabarCONHist(CONHist cnh)
        {
            RouteEntities db = new RouteEntities();
            
            CONHist conhist = new CONHist();
            conhist.ConfiguracionID = db.Configuracion.First().ConfiguracionID;
            conhist.CONHistFechaInicio = DateTime.Now;
            conhist.TipoLenguaje = cnh.TipoLenguaje;
            conhist.MonedaID = cnh.MonedaID;
            conhist.MostrarLogo = cnh.MostrarLogo;
            //Productos
            conhist.TipoClaveProducto = cnh.TipoClaveProducto;
            conhist.DigitoClaveProd = cnh.DigitoClaveProd;
            conhist.DiasSurtido = cnh.DiasSurtido;
            conhist.DiasMaxSurtido = cnh.DiasMaxSurtido;
            conhist.CambioProducto = cnh.CambioProducto;
            conhist.ConversionKg = cnh.ConversionKg;
            conhist.ActualizarEdoProducto = cnh.ActualizarEdoProducto;
            conhist.FiltroProductos = cnh.FiltroProductos;
            //Venta
            conhist.VariosPedidos = cnh.VariosPedidos;
            conhist.AbonoProgramado = cnh.AbonoProgramado;
            conhist.VenderApartado = cnh.VenderApartado;
            conhist.CalcPromoAuto = cnh.CalcPromoAuto;
            conhist.PagoAutomatico = cnh.PagoAutomatico;
            conhist.VentaSinSurtir = cnh.VentaSinSurtir;
            conhist.CancConsigLiqui = cnh.CancConsigLiqui;
            conhist.ExcederAbono = cnh.ExcederAbono;
            conhist.MostrarCEDI = cnh.MostrarCEDI;
            conhist.DecimalesImporte = cnh.DecimalesImporte;
            conhist.TicketConfigurado = cnh.TicketConfigurado;
            conhist.PorcentajeRiesgo = cnh.PorcentajeRiesgo;
            conhist.TicketConfigCobranza = cnh.TicketConfigCobranza;
            conhist.ProductosVenta = cnh.ProductosVenta;
            conhist.TicketConfigFactura = cnh.TicketConfigFactura;
            conhist.TipoLimiteCredito = cnh.TipoLimiteCredito;
            conhist.FormatoNotaVenta = cnh.FormatoNotaVenta;
            conhist.TipoCobranza = cnh.TipoCobranza;
            //Visita
            conhist.ClienteVariasRutas = cnh.ClienteVariasRutas;
            conhist.DatosCteNuevo = cnh.DatosCteNuevo;
            conhist.ValidaInv = cnh.ValidaInv;
            conhist.ConsignaSaldada = cnh.ConsignaSaldada;
            conhist.ConsignaContado = cnh.ConsignaContado;
            conhist.DiasAnteriores = cnh.DiasAnteriores;
            conhist.DiasPosteriores = cnh.DiasPosteriores;
            conhist.MaximoVisitasRDI = cnh.MaximoVisitasRDI;
            //Comunicacion
            conhist.DirectorioSDF = cnh.DirectorioSDF;
            conhist.DirInterfaz = cnh.DirInterfaz;
            conhist.SpNormalizacionBD = cnh.SpNormalizacionBD;
            conhist.TipoEnvioCarga = cnh.TipoEnvioCarga;
            conhist.DiferenciaPreliqui = cnh.DiferenciaPreliqui;
            conhist.CantidadSerAct = cnh.CantidadSerAct;
            conhist.InterfazTXT = cnh.InterfazTXT;
            conhist.IntUnidadVta = cnh.IntUnidadVta;
            conhist.Inventario = cnh.Inventario;
            conhist.AuditarCarga = cnh.AuditarCarga;
            conhist.ProductoCarga = cnh.ProductoCarga;
            conhist.PreLiquidacion = cnh.PreLiquidacion;
            conhist.EnvioParcial = cnh.EnvioParcial;
            conhist.EliminaEnviado = cnh.EliminaEnviado;
            conhist.ActualizaCliente = cnh.ActualizaCliente;
            //Correo electrónico
            conhist.ServidorSMTP = cnh.ServidorSMTP;
            conhist.SSL = cnh.SSL;
            conhist.Puerto = cnh.Puerto;
            conhist.Correo = cnh.Correo;
            conhist.Password = cnh.Password;
            //Cargas
            conhist.SemanasCargaPromedio = cnh.SemanasCargaPromedio;
            conhist.ExpCargaSugerida = cnh.ExpCargaSugerida;
            conhist.SpCargaSugerida = cnh.SpCargaSugerida;
            conhist.FolioAutCarga = cnh.FolioAutCarga;
            //Inventario
            conhist.HabilitaInventario = cnh.HabilitaInventario;
            conhist.TicketConfigKardex = cnh.TicketConfigKardex;
            //Ajustes
            conhist.AjusteEntradaBE = cnh.AjusteEntradaBE;
            conhist.AjusteEntradaME = cnh.AjusteEntradaME;
            conhist.AjusteSalidaBE = cnh.AjusteSalidaBE;
            conhist.AjusteSalidaME = cnh.AjusteSalidaME;
            conhist.MFechaHora = DateTime.Now;
            conhist.MUsuarioID = cnh.MUsuarioID;

            db.CONHist.Add(conhist);

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

    public class SPNormalizacion
    {
        public String name { get; set; }
    }
}
