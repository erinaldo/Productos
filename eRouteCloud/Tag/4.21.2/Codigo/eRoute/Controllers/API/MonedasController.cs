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
    public class MonedasController : ApiController
    {
        RouteEntities db = new RouteEntities();

        //Validando Clave Precio
        [HttpGet]
        [ActionName("ValidarCodigoMoneda")]
        public IHttpActionResult ValidarCodigoUnico(short codigo)
        {
            RouteEntities db = new RouteEntities();
            return Json(db.Moneda.ToList().Exists(x => x.TipoCodigo == codigo));
        }

        //Validando Tipo Estado Moneda
        [HttpGet]
        [ActionName("ValidarTipoEstado")]
        public IHttpActionResult ValidarTipoEstado(short codigo)
        {
            var configID = db.Configuracion.FirstOrDefault().ConfiguracionID;
            var confHist = db.CONHist.OrderByDescending(x => x.CONHistFechaInicio).FirstOrDefault(x => x.ConfiguracionID == configID).MonedaID;
            return Json(db.Moneda.ToList().Exists(x => x.MonedaID == confHist && x.TipoCodigo == codigo));
        }

        //Obtener
        [HttpGet]
        [ActionName("ObtenerMonedas")]
        public IHttpActionResult ObtenerMonedas()
        {
            var valter = (from m in db.Moneda
                          join d in db.VAVDescripcion on  "CDGOMON"  equals d.VARCodigo
                          join d2 in db.VAVDescripcion on "EDOREG" equals d2.VARCodigo
                          where
                           m.TipoCodigo.ToString() == d.VAVClave  &&
                           d.VADTipoLenguaje == "EM"   &&
                           m.TipoEstado.ToString() == d2.VAVClave &&
                           d2.VADTipoLenguaje == "EM"
                          select new {
                              TipoCodigo = d.Descripcion,
                              m.Nombre,
                              m.Simbolo,
                              TipoEstado = d2.Descripcion,
                              TipoC = m.TipoCodigo,
                              m.MonedaID

                          }
                           );

            return Json(valter);
        }


        //Guardando Moneda
        [HttpPost]
        public bool Grabar(Moneda moneda) //valor = msg
        {
            Moneda mone;
            MONRedondeoVig redon;
            MONTipoCambioVig tipovi;

            bool nuevo = !db.Moneda.ToList().Exists(x => x.TipoCodigo == moneda.TipoCodigo);
            if (nuevo)
            {
                Guid id = Guid.NewGuid();//creando ID

                mone = new Moneda();
                mone.MonedaID = id.ToString().Remove(6, 20).ToUpper();

                redon = new MONRedondeoVig();
                redon.MonedaId = mone.MonedaID;

                tipovi = new MONTipoCambioVig();
                tipovi.MonedaId = mone.MonedaID;

                mone.TipoCodigo = moneda.TipoCodigo;
                mone.Nombre = moneda.Nombre;
                mone.Simbolo = moneda.Simbolo;
                mone.TipoEstado = moneda.TipoEstado;
                mone.MFechaHora = DateTime.Now;
                mone.MUsuarioID = moneda.MUsuarioID;

                redon.FechaFinal = DateTime.MaxValue.Date;
                redon.FechaInicial = DateTime.Now.Date;
                redon.Tipo = 0;
                redon.UnidadMinima = 0;
                redon.Decimal = 0;
                redon.LimiteRedondeo = 0;
                redon.mFechaHora = DateTime.Now;
                redon.mUsuarioID = mone.MUsuarioID;



                tipovi.FechaInicial = moneda.FechaInicial.Date;
                tipovi.FechaFinal = DateTime.MaxValue.Date;
                tipovi.valor = moneda.Valor;
                tipovi.mFechaHora = DateTime.Now;
                tipovi.mUsuarioID = mone.MUsuarioID;

            }
            else
            {
                mone = db.Moneda.ToList().First(x => x.MonedaID == moneda.MonedaID);//primer resultado con la clave
                redon = db.MONRedondeoVig.ToList().First(x => x.MonedaId == moneda.MonedaID);//primer resultado con la clave
                tipovi = db.MONTipoCambioVig.ToList().First(x => x.MonedaId == moneda.MonedaID);//primer resultado con la clave

            }
            // AGREGANDO NUEVA MONEDA           
            if (nuevo)
            {

                db.Moneda.Add(mone);



                db.MONRedondeoVig.Add(redon);

                db.MONTipoCambioVig.Add(tipovi);

            }
            else
            {//MODIFICANDO se editan datos de tabla de Moneda

                mone.TipoCodigo = moneda.TipoCodigo;
                mone.Nombre = moneda.Nombre;
                mone.Simbolo = moneda.Simbolo;
                mone.TipoEstado = moneda.TipoEstado;
                mone.MFechaHora = DateTime.Now;
                mone.MUsuarioID = moneda.MUsuarioID;
                //Se agrega un solo registro por la fecha actual en la que se generan cambios
                if (!db.MONRedondeoVig.ToList().Exists(x => x.MonedaId == moneda.MonedaID && DateTime.Now.Date == x.FechaInicial.Date))
                {
                    DateTime time = DateTime.Now;

                   // db.MONRedondeoVig.ToList().First(x => x.MonedaId == moneda.MonedaID && DateTime.MaxValue.Date == x.FechaFinal.Date).FechaFinal = DateTime.Now.AddDays(-1).Date;
                   
                    MONRedondeoVig obj = db.MONRedondeoVig.ToList().First(x => x.MonedaId == moneda.MonedaID && DateTime.MaxValue.Date == x.FechaFinal.Date);
                    MONRedondeoVig obj1 = new MONRedondeoVig();
                    //obj1 = obj;
                    obj1.MonedaId = obj.MonedaId;
                    obj1.FechaInicial = obj.FechaInicial;
                    obj1.FechaFinal = DateTime.Now.AddDays(-1).Date;
                    obj1.Tipo = obj.Tipo;
                    obj1.UnidadMinima = obj.UnidadMinima;
                    obj1.Decimal = obj.Decimal;
                    obj1.LimiteRedondeo = obj.LimiteRedondeo;
                    obj1.mFechaHora = obj.mFechaHora;
                    obj1.mUsuarioID = obj.mUsuarioID;

                    db.MONRedondeoVig.Remove(obj);

                    db.MONRedondeoVig.Add(obj1);

                    redon = new MONRedondeoVig();
                    redon.MonedaId = mone.MonedaID;
                    redon.FechaFinal = DateTime.MaxValue.Date;
                    redon.FechaInicial = DateTime.Now.Date;
                    redon.Tipo = 0;
                    redon.UnidadMinima = 0;
                    redon.Decimal = 0;
                    redon.LimiteRedondeo = 0;
                    redon.mFechaHora = DateTime.Now;
                    redon.mUsuarioID = mone.MUsuarioID;
                    db.MONRedondeoVig.Add(redon);


                    //MONTipoCambioVig obj2 = db.MONTipoCambioVig.ToList().First(x => x.MonedaId == moneda.MonedaID && DateTime.MaxValue.Date == x.FechaFinal.Date);
                    //MONTipoCambioVig obj22 = new MONTipoCambioVig();

                    ////db.MONTipoCambioVig.ToList().First(x => x.MonedaId == moneda.MonedaID && DateTime.MaxValue.Date == x.FechaFinal.Date).FechaFinal = moneda.FechaInicial.AddDays(-1).Date;
                    //obj22.FechaFinal = DateTime.Now.AddDays(-1).Date;
                    //obj22.MonedaId = obj2.MonedaId;
                    //obj22.FechaInicial = obj2.FechaInicial;
                    //obj22.valor = obj2.valor;
                    //obj22.mFechaHora = obj2.mFechaHora;
                    //obj22.mUsuarioID = obj2.mUsuarioID;

                    //db.MONTipoCambioVig.Remove(obj2);

                    //db.MONTipoCambioVig.Add(obj22);

                    // tipovi = new MONTipoCambioVig();
                    // tipovi.MonedaId = mone.MonedaID;
                    // tipovi.FechaInicial = moneda.FechaInicial.Date;
                    // tipovi.FechaFinal = DateTime.MaxValue.Date;
                    // tipovi.valor = moneda.Valor;
                    // tipovi.mFechaHora = DateTime.Now;
                    // tipovi.mUsuarioID = mone.MUsuarioID;

                    // db.MONTipoCambioVig.Add(tipovi);

                }
               
                 else if (db.MONTipoCambioVig.ToList().Exists(x => x.MonedaId == moneda.MonedaID ))
                    {

                    var valter = (
                 from m in db.Moneda
                 join mt in db.MONTipoCambioVig on m.MonedaID equals mt.MonedaId
                 where m.TipoCodigo == moneda.TipoCodigo
                 select new
                 {
                     mt.FechaInicial,
                     mt.valor,
                     mt.FechaFinal

                 });

                    var s= 0;
                    foreach (var dom in valter)
                    {
                        var f = dom.FechaInicial.Date;
                        if ( f == moneda.FechaInicial.Date || f >= moneda.FechaInicial.Date  ) {

                            MONTipoCambioVig obj21 = db.MONTipoCambioVig.ToList().First(x => x.MonedaId == moneda.MonedaID && f == x.FechaInicial.Date);
                           

                            db.MONTipoCambioVig.Remove(obj21);

                            s++;

                        }
                    }

                   

                    if (moneda.FechaInicial.Date == DateTime.Now.Date)
                    {
                        tipovi = new MONTipoCambioVig();
                        tipovi.MonedaId = mone.MonedaID;
                        tipovi.FechaInicial = moneda.FechaInicial.Date;
                        tipovi.FechaFinal = DateTime.MaxValue.Date;
                        tipovi.valor = moneda.Valor;
                        tipovi.mFechaHora = DateTime.Now;
                        tipovi.mUsuarioID = mone.MUsuarioID;

                        db.MONTipoCambioVig.Add(tipovi);
                    }
                    else {
                        MONTipoCambioVig obj2 = db.MONTipoCambioVig.ToList().First(x => x.MonedaId == moneda.MonedaID && DateTime.MaxValue.Date == x.FechaFinal.Date);
                        MONTipoCambioVig obj22 = new MONTipoCambioVig();

                        //db.MONTipoCambioVig.ToList().First(x => x.MonedaId == moneda.MonedaID && DateTime.MaxValue.Date == x.FechaFinal.Date).FechaFinal = moneda.FechaInicial.AddDays(-1).Date;

                        obj22.FechaFinal = moneda.FechaInicial.AddDays(-1).Date;
                        obj22.MonedaId = obj2.MonedaId;
                        obj22.FechaInicial = obj2.FechaInicial;
                        obj22.valor = obj2.valor;
                        obj22.mFechaHora = obj2.mFechaHora;
                        obj22.mUsuarioID = obj2.mUsuarioID;

                        db.MONTipoCambioVig.Remove(obj2);

                        db.MONTipoCambioVig.Add(obj22);

                        tipovi = new MONTipoCambioVig();
                        tipovi.MonedaId = mone.MonedaID;
                        tipovi.FechaInicial = moneda.FechaInicial.Date;
                        tipovi.FechaFinal = DateTime.MaxValue.Date;
                        tipovi.valor = moneda.Valor;
                        tipovi.mFechaHora = DateTime.Now;
                        tipovi.mUsuarioID = mone.MUsuarioID;

                        db.MONTipoCambioVig.Add(tipovi);

                    }
                    var p = s;
                  
                    }
                    
                
            

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


        //Editar
        [HttpGet]
        [ActionName("ObtenerValorMoneda")]
        public IHttpActionResult ObtenerValorMoneda(short TipoCodigo)
        {
            DateTime Factual = DateTime.Now;
            var valter = (
                from m in db.Moneda
                join mt in db.MONTipoCambioVig on m.MonedaID equals mt.MonedaId
                where m.TipoCodigo == TipoCodigo && (mt.FechaInicial <= Factual.Date && mt.FechaFinal >= Factual.Date)

                select new 
                {
                    m.MonedaID,
                    m.Nombre,
                    TipoCodigo= m.TipoCodigo.ToString(),
                    TipoEstado=m.TipoEstado.ToString(),
                    m.Simbolo,
                    mt.FechaInicial,
                    mt.valor

                }


                );
            return Json(valter);
        }

        //vigencias Monedas
        
        [HttpGet]
        [ActionName("ObtenerVigenciaMonedas")]
        public IHttpActionResult ObtenerVigenciaMonedas(short TipoCodigo)
        {

            var valter = (
                from m in db.Moneda
                join mt in db.MONTipoCambioVig on m.MonedaID equals mt.MonedaId
                where m.TipoCodigo == TipoCodigo
                select new
                {
                   mt.FechaInicial,
                   mt.valor,
                   mt.FechaFinal,
                   mt.mFechaHora,
                   mt.mUsuarioID

                }


                );
            return Json(valter);
        }

        //Validando  si el precio esta cambiadoPrecioCambiado
        [HttpGet]
        [ActionName("ValidarCcambiado")]
        public IHttpActionResult ValidarCcambiado(short TipoCodigo, string Nombre, string Simbolo, short TipoEstado)
        {
            RouteEntities db = new RouteEntities();
            return Json(db.Moneda.ToList().Exists(x => x.TipoEstado == TipoEstado && x.Nombre == Nombre && x.Simbolo == Simbolo && x.TipoCodigo != TipoCodigo));
        }


        [HttpGet]
        [ActionName("ObtenerMonedasActivas")]
        public IHttpActionResult ObtenerMonedasActivas()
        {
            RouteEntities db = new RouteEntities();
            var monedas = (from moneda in db.Moneda
                           where moneda.TipoEstado == 1
                           select new { moneda.MonedaID, moneda.Nombre }).ToList();

            return Json(monedas);
        }
    }
    
}