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
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace eRoute.Controllers.API
{
    public class SubEmpresaController : ApiController
    {
        RouteEntities db = new RouteEntities();
        private string QueryString;

        [HttpGet]
        [ActionName("ObtenerSubEmpresa")]
        public IHttpActionResult ObtenerSubEmpresa()
        {
           
            var sub = (from d in db.VAVDescripcion
                       join x in db.SubEmpresa on d.VARCodigo equals "EDOREG"
                       where x.TipoEstado.ToString() == d.VAVClave && d.VADTipoLenguaje == "EM"
                       select new {
                           x.SubEmpresaId,
                           x.NombreEmpresa,                           
                           x.NombreCorto,
                           x.RFC,
                           TipoEstado = d.Descripcion.ToString()
                       });
            return Json(sub);
        }

        [HttpGet]
        [ActionName("ObtenerHistorialSemHist")]
        public IHttpActionResult ObtenerHistorialSemHist(string SubEmpresaID)
        {
            var Hist = (from h in db.SEMHist
                        where h.SubEmpresaId ==SubEmpresaID
                        select new
                        {
                            FechaInicio = h.SEMHistFechaInicio,
                            Comprobante = h.ComprobanteDig,
                            FoliosFiscales = h.FoliosTerminal,
                            DirReportesMensuales = h.DirRepMensual,
                            FormatoFactura = h.FormatoFactura,
                            ClienteGenerico = h.ClienteClave,
                            FormatoNC = h.FormatoNC,
                            VersionCFD = h.VersionCFD,
                            ProveedorTimbre = h.ProveedorTimbre,
                            CustomerID = h.CustomerId,
                            CustomerKey = h.CustomerKey,
                            ServidorTimbre = h.ServidorTimbre,
                            ServidorCancelacion = h.ServidorCancelacion,
                            ArchivoPFX64 = h.AchivoPFX64,
                            CerFinKok = h.CerFinkok,
                            KeyFinKok = h.KeyFinkok,
                            ReciboElecPago = h.ReciboElecPago,
                            MFechaHora = h.MFechaHora,
                            MUsuarioID = h.MUsuarioID
                        }).ToList();
            return Json(Hist);
        }

        [HttpGet]
        [ActionName("ValidarEstadoSubEmpresa")]
        public IHttpActionResult ValidarEstadoSubEmpresa(string SubEmpresaID)
        {

            var sub = (from p in db.Producto
                       where p.SubEmpresaID == SubEmpresaID && p.TipoFase==1
                       select new
                       {
                           Productos = p.ProductoClave
                       }).Count();
            return Json(sub);
        }


        [HttpGet]
        [ActionName("ObtenerSubEmpresa")]
        public IHttpActionResult ObtenerSubEmpresa(string sub)
        {
            var lista = new List<cSubEmpresa>();
            var listaFactura = new List<cFactura>();




            var subSrc = (from subEm in db.SubEmpresa
                          where subEm.SubEmpresaId == sub
                          select new cSubEmpresa
                          {
                              SubEmpresaId = subEm.SubEmpresaId,
                              NombreCorto = subEm.NombreCorto,
                              NombreEmpresa = subEm.NombreEmpresa,
                              ClaveSubEmpresa = subEm.ClaveSubEmpresa,
                              Logotipo = subEm.Logotipo,
                              RFC = subEm.RFC,
                              Pais = subEm.Pais,
                              Region = subEm.Region,
                              Localidad = subEm.Localidad,
                              ReferenciaDom = subEm.ReferenciaDom,
                              Ciudad = subEm.Ciudad,
                              Colonia = subEm.Colonia,
                              Calle = subEm.Calle,
                              Numero = subEm.Numero,
                              NumeroInterior = subEm.NumeroInterior,
                              CodigoPostal = subEm.CodigoPostal,
                              Telefono = subEm.Telefono,
                              TipoEstado = subEm.TipoEstado.ToString()
                          }
                       );



            var factura = (from se in db.SEMHist
                           where se.SubEmpresaId == sub
                           select new cFactura
                           {
                               SubEmpresaId = se.SubEmpresaId,
                               ClienteClave = se.ClienteClave,
                               ComprobanteDig = se.ComprobanteDig,
                               FormatoFactura = se.FormatoFactura.ToString(),
                               FormatoNC = se.FormatoNC,
                               FoliosTerminal = se.FoliosTerminal,
                               DirRepMensual = se.DirRepMensual,
                               DirDocXML = se.DirDocXML,
                               DirArchivosFacElec = se.DirArchivosFacElec,
                               ContrasenaClave = se.ContrasenaClave,
                               ArchivoPEM = se.ArchivoPEM,
                               CerBase64 = se.CerBase64,
                               VersionCFD = se.VersionCFD.ToString(),
                               ProveedorTimbre = se.ProveedorTimbre.ToString(),
                               CustomerId = se.CustomerId,
                               CustomerKey = se.CustomerKey,
                               ServidorTimbre = se.ServidorTimbre,
                               ServidorCancelacion = se.ServidorCancelacion,
                           }
                 ).ToList();

            foreach (cFactura se in factura)
            {
                listaFactura.Add(new cFactura
                {
                    SubEmpresaId = se.SubEmpresaId,
                    ClienteClave = se.ClienteClave,
                    ComprobanteDig = se.ComprobanteDig,
                    FormatoFactura = se.FormatoFactura,
                    FormatoNC = se.FormatoNC,
                    FoliosTerminal = se.FoliosTerminal,
                    DirRepMensual = se.DirRepMensual,
                    DirDocXML = se.DirDocXML,
                    DirArchivosFacElec = se.DirArchivosFacElec,
                    ContrasenaClave = se.ContrasenaClave,
                    ArchivoPEM = se.ArchivoPEM,
                    CerBase64 = se.CerBase64,
                    VersionCFD = se.VersionCFD,
                    ProveedorTimbre = se.ProveedorTimbre,
                    CustomerId = se.CustomerId,
                    CustomerKey = se.CustomerKey,
                    ServidorTimbre = se.ServidorTimbre,
                    ServidorCancelacion = se.ServidorCancelacion,
                });
            }


            //     select new cSubEmpresa { SubEmpresaId = x.SubEmpresaId, NombreCorto = x.NombreCorto, NombreEmpresa = x.NombreEmpresa, Logotipo = x.Logotipo }

            foreach (cSubEmpresa subEm in subSrc)
            {
                var img64 = "";
                if (subEm.Logotipo != null)
                {
                    img64 = Convert.ToBase64String(subEm.Logotipo);
                }

                lista.Add(new cSubEmpresa
                {
                    SubEmpresaId = subEm.SubEmpresaId,
                    NombreCorto = subEm.NombreCorto,
                    NombreEmpresa = subEm.NombreEmpresa,
                    ClaveSubEmpresa = subEm.ClaveSubEmpresa,
                    BaseImg = img64,
                    RFC = subEm.RFC,
                    Pais = subEm.Pais,
                    Region = subEm.Region,
                    Localidad = subEm.Localidad,
                    ReferenciaDom = subEm.ReferenciaDom,
                    Factura = listaFactura,
                    Ciudad = subEm.Ciudad,
                    Colonia = subEm.Colonia,
                    Calle = subEm.Calle,
                    Numero = subEm.Numero,
                    NumeroInterior = subEm.NumeroInterior,
                    CodigoPostal = subEm.CodigoPostal,
                    Telefono = subEm.Telefono,
                    TipoEstado = subEm.TipoEstado
                });
            }
            return Json(lista);
        }

        [HttpPost]
        public bool Guardar(SubEmpresa subEm)
        {
            /* byte[] bytes = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
             Console.WriteLine("The byte array: ");
             Console.WriteLine("   {0}\n", BitConverter.ToString(bytes));*/

            // Convert the array to a base 64 sring.

            byte[] newBytes = null;

            if (subEm.BaseImg != null)
            {
                newBytes = Convert.FromBase64String(subEm.BaseImg);
            }

            var nuevo = !db.SubEmpresa.ToList().Exists(x => x.SubEmpresaId == subEm.SubEmpresaId);

            SubEmpresa subEmpresa;

            if (nuevo)
            {
                subEmpresa = new SubEmpresa();
                subEmpresa.SubEmpresaId = getSubEmpresaID();
                //subEmpresa.SubEmpresaId = getSubId();
            }
            else
            {
                subEmpresa = db.SubEmpresa.ToList().First(x => x.SubEmpresaId == subEm.SubEmpresaId);
            }

            subEmpresa.ClaveSubEmpresa = subEm.ClaveSubEmpresa;
            subEmpresa.NombreEmpresa = subEm.NombreEmpresa;
            subEmpresa.NombreCorto = subEm.NombreCorto;
            subEmpresa.RFC = subEm.RFC;
            subEmpresa.Pais = subEm.Pais;
            subEmpresa.Region = subEm.Region;
            subEmpresa.Localidad = subEm.Localidad;
            subEmpresa.ReferenciaDom = subEm.ReferenciaDom;
            subEmpresa.Ciudad = subEm.Ciudad;
            subEmpresa.Colonia = subEm.Colonia;
            subEmpresa.Calle = subEm.Calle;
            subEmpresa.Numero = subEm.Numero;
            subEmpresa.NumeroInterior = subEm.NumeroInterior;
            subEmpresa.CodigoPostal = subEm.CodigoPostal;
            subEmpresa.Logotipo = newBytes;
            subEmpresa.Telefono = subEm.Telefono;
            subEmpresa.TipoEstado = subEm.TipoEstado;
            subEmpresa.MFechaHora = DateTime.Now;
            subEmpresa.MUsuarioID = subEm.MUsuarioID;

            if (nuevo)
            {
                db.SubEmpresa.Add(subEmpresa);

                //Solo si se pide comprobante digital
                if (subEm.FacturaActiva != true)
                {
                    SEMHist factura = new SEMHist();

                    foreach (SEMHist fact in subEm.SEMHist)
                    {
                        factura.SubEmpresaId = subEmpresa.SubEmpresaId;
                        factura.SEMHistFechaInicio = DateTime.Now;
                        factura.ClienteClave = fact.ClienteClave;
                        factura.ComprobanteDig = fact.ComprobanteDig;
                        factura.FormatoFactura = fact.FormatoFactura;
                        //factura.FormatoNC = fact.FormatoNC;
                        factura.FormatoNC = 1;
                        factura.FoliosTerminal = fact.FoliosTerminal;
                        factura.DirRepMensual = fact.DirRepMensual;
                        factura.DirDocXML = fact.DirDocXML;
                        factura.DirArchivosFacElec = fact.DirArchivosFacElec;
                        factura.ContrasenaClave = fact.ContrasenaClave;
                        factura.ArchivoPEM = fact.ArchivoPEM;
                        factura.CerBase64 = fact.CerBase64;
                        factura.VersionCFD = fact.VersionCFD;
                        //factura.ProveedorTimbre = fact.ProveedorTimbre;
                        factura.ProveedorTimbre = 0;
                        factura.CustomerId = fact.CustomerId;
                        factura.CustomerKey = fact.CustomerKey;
                        factura.ServidorTimbre = fact.ServidorTimbre;
                        factura.ServidorCancelacion = fact.ServidorCancelacion;
                        factura.AchivoPFX64 = fact.AchivoPFX64;
                        factura.CerFinkok = fact.CerFinkok;
                        factura.KeyFinkok = fact.KeyFinkok;
                        factura.ReciboElecPago = fact.ReciboElecPago;
                        factura.MFechaHora = DateTime.Now;
                        factura.MUsuarioID = subEm.MUsuarioID;
                    }
                    db.SEMHist.Add(factura);
                }
            }
            else
            {
                if (subEm.FacturaActiva)
                {
                    var factura = db.SEMHist.First(x => x.SubEmpresaId == subEm.SubEmpresaId);

                    foreach (SEMHist fact in subEm.SEMHist)
                    {
                        factura.ComprobanteDig = fact.ComprobanteDig;
                        factura.FoliosTerminal = fact.FoliosTerminal;
                        factura.VersionCFD = fact.VersionCFD;
                        factura.FormatoFactura = fact.FormatoFactura;
                        factura.FormatoNC = fact.FormatoNC;
                        factura.ClienteClave = fact.ClienteClave;
                        factura.DirRepMensual = fact.DirRepMensual;
                        factura.DirDocXML = fact.DirDocXML;
                        factura.DirArchivosFacElec = fact.DirArchivosFacElec;
                        factura.ContrasenaClave = fact.ContrasenaClave;
                        factura.ProveedorTimbre = fact.ProveedorTimbre;
                        factura.CustomerId = fact.CustomerId;
                        factura.CustomerKey = fact.CustomerKey;
                        factura.ServidorTimbre = fact.ServidorTimbre;
                        factura.ServidorCancelacion = fact.ServidorCancelacion;
                        factura.ReciboElecPago = fact.ReciboElecPago;
                        factura.MFechaHora = DateTime.Now;
                        factura.MUsuarioID = fact.MUsuarioID;
                    }
                }else
                {
                    var factu = db.SEMHist.ToList().Exists(x => x.SubEmpresaId == subEm.SubEmpresaId);

                    if (factu)
                    {
                        //Aqui debe de eliminarse en caso de ser necesario
                        var factura = db.SEMHist.First(x => x.SubEmpresaId == subEm.SubEmpresaId);
                        foreach (SEMHist fact in subEm.SEMHist)
                        {
                            factura.ComprobanteDig = fact.ComprobanteDig;
                        }
                    }

                }
            }

            try
            {
                db.SaveChanges();
                return true;
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

        [HttpGet]
        [ActionName("EliminarSubEmpresa")]
        public IHttpActionResult EliminarSubEmpresa(string SubEmpresaId)
        {
            try
            {
                db.SEMHist.Remove(db.SEMHist.First(x => x.SubEmpresaId == SubEmpresaId));
                db.SubEmpresa.Remove(db.SubEmpresa.First(x => x.SubEmpresaId == SubEmpresaId));
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Json(false);
            }



            return Json(true);
        }

        [HttpGet]
        [ActionName("VerificarRuta")]
        public IHttpActionResult VerificarRuta(string ruta)
        {
            var existe = false;

            if (Directory.Exists(ruta))
            {
                Console.WriteLine("Existe");
                existe = true;
            }

            if (File.Exists(ruta))
            {
                Console.WriteLine("Existe");
                existe = true;
            }
            else
            {
                Console.WriteLine("No Existe");
            }

            return Json(existe);
        }
        [HttpGet]
        [ActionName("ObtenerClientes")]
        public IHttpActionResult ObtenerClientes()
        {
            var clientes = (from x in db.Cliente
                            select new { x.ClienteClave, x.Clave, x.IdFiscal, x.RazonSocial, x.NombreContacto }
                            );
            return Json(clientes);
        }
        [HttpGet]
        [ActionName("ValidarClaveCliente")]
        public IHttpActionResult ValidarClaveCliente(string ClienteClave)
        {
            var clientes = (from x in db.Cliente
                            where x.ClienteClave == ClienteClave
                            select new { x.ClienteClave, x.Clave, x.IdFiscal, x.RazonSocial, x.NombreContacto }
                            );

            return Json(clientes);
        }

        [HttpGet]
        [ActionName("ObtenerClienteLimite")]
        public IHttpActionResult ObtenerClienteLimite()
        {

            var numRow = 2;
            var clientes = (from x in db.Cliente
                            select new { x.ClienteClave, x.Clave, x.IdFiscal, x.RazonSocial, x.NombreContacto }
                   ).OrderByDescending(x => x.ClienteClave).Skip(numRow).Take(10);

            return Json(clientes);
        }

        [HttpGet]
        [ActionName("ObtenerFormatos")]
        public IHttpActionResult ObtenerFormatos(string VARCodigo, string grupo)
        {
            //Se declara la consulta SQL
            //  QueryString = "select distinct vd.VAVClave, vd.Descripcion, vd.VARCodigo from  VAVDescripcion as vd inner join VARValor as vv on vv.VARCodigo = vd.VARCodigo WHERE vv.VARCodigo = 'FRMFAC' AND Grupo = '"+ grupo + "' and vd.VADTipoLenguaje = 'EM' order by vd.VAVClave";
            //Se almacenan los datos en una variable en la cual se guardan en una lista con los datos que regresará
            //   var results = db.Database.SqlQuery<cValores>(QueryString).ToList();

            var lista = new List<cValores>();

            //WHERE vv.VARCodigo = 'FRMFAC' AND Grupo = 'CFD' 
            var valores = (from x in db.VARValor
                           where x.VARCodigo == "FRMFAC" && x.Grupo == grupo
                           select new { x.VARCodigo, x.Grupo, x.VAVClave, x.Estado, x.VAVDescripcion }
                           ).ToList();

            foreach (var v in valores)
            {
                foreach (VAVDescripcion vv in v.VAVDescripcion)
                {
                    if (vv.VADTipoLenguaje == "EM")
                    {
                        lista.Add(new cValores
                        {
                            VAVClave = vv.VAVClave,
                            Descripcion = vv.Descripcion,
                            VARCodigo = vv.VARCodigo
                        });
                    }
                }
            }



            return Json(lista);
        }

        [HttpGet]
        [ActionName("ObtenerGrupo")]
        public IHttpActionResult ObtenerGrupo(string vavclave)
        {
            var valor = (from x in db.VARValor
                         where x.VAVClave == vavclave && x.VARCodigo == "verfacte"
                         select new { x.VARCodigo, x.Grupo, x.VAVClave }
                         );
            return Json(valor);
        }

        [HttpGet]
        [ActionName("ObtenerVersionNC")]
        public IHttpActionResult ObtenerVersionNC(string vavclave)
        {
            var valor = (from x in db.VAVDescripcion
                         where x.VAVClave == vavclave && x.VARCodigo == "verfacte"
                         select new { x.VARCodigo, x.VAVClave, x.Descripcion }
                         );
            return Json(valor);
        }

        [HttpGet]
        [ActionName("ObtenerProveedorTimbre")]
        public IHttpActionResult ObtenerProveedorTimbre(string vavclave)
        {
            var valor = (from x in db.VAVDescripcion
                         where x.VAVClave == vavclave && x.VARCodigo == "PROTIMB"
                         select new { x.VARCodigo, x.VAVClave, x.Descripcion }
                         );
            return Json(valor);
        }

        public string getSubId()
        {
            Random r = new Random();
            string subID = "SubEm";
            do
            {
                int num = r.Next(0, 1000000);
                subID = subID + num.ToString();
            } while (verificarNum(subID));
            return subID;
        }

        public string getSubEmpresaID()
        {
            string SubEmpresaID = "";
            int tam = 15;
            const string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            System.Text.StringBuilder token = new System.Text.StringBuilder();
            Random rnd = new Random();

            do
            {
                for (int i = 0; i < tam; i++)
                {
                    int indice = rnd.Next(alfabeto.Length);
                    SubEmpresaID = token.Append(alfabeto[indice]).ToString();
                }

            } while (verificarNum(SubEmpresaID));
            return SubEmpresaID;
        }

        public bool verificarNum(string subId)
        {
            return db.SubEmpresa.ToList().Exists(x => x.SubEmpresaId == subId);
        }

    }

}