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
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace eRoute.Controllers.API
{
    public class UsuarioController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        RouteEntities db = new RouteEntities();


        [HttpGet]
        [ActionName("ValidarClaveUsuario")]
        public IHttpActionResult ValidarClaveUsuario(string ClaveUsuario)
        {
            return Json(db.Usuario.ToList().Exists(x => x.Clave == ClaveUsuario));
        }


        [HttpGet]
        [ActionName("obtCentroDistribucion")]
        public IHttpActionResult obtCentroDistribucion(string USUId, string Action)
        {

            var lista = new List<cAlmacen>();
            USUId = (USUId != null ? (USUId.Length > 0 ? USUId.Replace(" ", "+") : USUId) : null);
            if (Action.Equals("Create"))
            {
                var centroList = (
                    from x in db.Almacen
                    where x.Tipo.Equals("1") && x.TipoEstado == 1
                    select new cAlmacen { AlmacenID = x.AlmacenID, Clave = x.Clave, Nombre = x.Nombre, TipoEstado = x.TipoEstado.ToString(), Tipo = x.Tipo, NombreCompuesto = x.Clave + " - " + x.Nombre });
                return Json(centroList);
            }
            else
            {
                var centro = (from u in db.Almacen
                              join ua in db.UsuarioAlmacen on u.AlmacenID equals ua.AlmacenId
                              where ua.USUId == USUId
                              select new { ua.USUId, ua.AlmacenId, u.Clave, u.Nombre }

                              );

                foreach (Almacen almacen in db.Almacen.ToList())
                {
                    var encontrado = false;
                    foreach (var userA in centro)
                    {
                        if (userA.AlmacenId == almacen.AlmacenID && userA.USUId == USUId)
                        {
                            encontrado = true;
                        }
                    }
                    if (encontrado == true)
                    {
                        lista.Add(new cAlmacen { AlmacenID = almacen.AlmacenID, Clave = almacen.Clave, Nombre = almacen.Nombre, TipoEstado = almacen.TipoEstado.ToString(), Tipo = almacen.Tipo, NombreCompuesto = almacen.Clave + " - " + almacen.Nombre, Existe = true });
                    }
                    else
                    {
                        lista.Add(new cAlmacen { AlmacenID = almacen.AlmacenID, Clave = almacen.Clave, Nombre = almacen.Nombre, TipoEstado = almacen.TipoEstado.ToString(), Tipo = almacen.Tipo, NombreCompuesto = almacen.Clave + " - " + almacen.Nombre, Existe = false });
                    }
                }
                return Json(lista);
            }
        }

        [HttpGet]
        [ActionName("obtPoliticas")]
        public IHttpActionResult obtPoliticas()
        {
            var politicaList = (from x in db.PoliticaContrasena
                                where x.TipoEstado == 1
                                select new cPoliticaPriv { PoliticaId = x.PoliticaId, Descripcion = x.Descripcion, DescripcionCompuesta = x.PoliticaId + " - " + x.Descripcion });
            return Json(politicaList);
        }

        [HttpGet]
        [ActionName("obtPerfil")]
        public IHttpActionResult obtPerfil()
        {
            var perfilList = (from x in db.Perfil
                              where x.Activo == true
                              select new cPerfil { PERClave = x.PERClave, Descripcion = x.Descripcion, DescripcionCompuesta = x.PERClave + " - " + x.Descripcion });
            return Json(perfilList);
        }


        [HttpPost]
        public bool Grabar(Usuario usuario) //valor = msg
        {
            RouteEntities db = new RouteEntities();



            var USUId = "";


            if (usuario != null)
            {
                var nuevo = !db.Usuario.ToList().Exists(x => x.USUId == usuario.USUId);

                Usuario cUsuario;



                if (nuevo)
                {
                    //Solo es una prueba hasta que se implemente el metodo KeyGen()
                    USUId = getClave();
                    // USUId = "101014";

                    cUsuario = new Usuario();
                    // cUsuario.USUId = usuario.USUId;
                    cUsuario.USUId = USUId;
                }
                else
                {
                    cUsuario = db.Usuario.First(x => x.USUId == usuario.USUId);
                }

                cUsuario.Clave = usuario.Clave;
                cUsuario.Nombre = usuario.Nombre;
                cUsuario.Tipo = usuario.Tipo;
                cUsuario.Activo = usuario.Activo;
                cUsuario.DiasLimite = usuario.DiasLimite;
                Connection.Open();
                string QueryString = "SELECT dbo.FNCrypt('" + usuario.ClaveAcceso + "')";

                var fncrypt = Connection.Query(QueryString).ToList();
                System.Collections.Generic.IDictionary<string, object> dic = fncrypt.ElementAt(0);
                Connection.Close();
                
                cUsuario.ClaveAcceso = (cUsuario.ClaveAcceso == usuario.ClaveAcceso ? usuario.ClaveAcceso : dic.Values.First().ToString());
                cUsuario.AlmacenID = usuario.AlmacenID;
                cUsuario.FechaMod = usuario.FechaMod;
                cUsuario.PoliticaId = usuario.PoliticaId;
                cUsuario.PERClave = usuario.PERClave;
                cUsuario.MUsuarioId = usuario.MUsuarioId;
                cUsuario.MFechaHora = DateTime.Now;



                if (nuevo)
                {

                    //Configurar USUID

                    if (usuario.ConfTerminal == true)
                    {
                        Terminal terminal = new Terminal();

                        terminal.TerminalClave = USUId;
                        terminal.TipoFase = 3;
                        terminal.Descripcion = USUId + " - " + usuario.Nombre;
                        terminal.NumeroSerie = "";
                        terminal.Comentario = "Term, " + USUId + " - " + usuario.Nombre;
                        terminal.AlmacenID = usuario.AlmacenID;
                        terminal.MFechaHora = DateTime.Now;
                        terminal.MUsuarioID = usuario.MUsuarioId;

                        db.Terminal.Add(terminal);

                    }


                    if (usuario.Tipo == 3)
                    {
                        if (usuario.SupervisorRuta.Count() > 0)
                        {
                            foreach (SupervisorRuta sRuta in usuario.SupervisorRuta)
                            {
                                SupervisorRuta sRutaSuper = new SupervisorRuta();

                                sRutaSuper.RUTClave = sRuta.RUTClave;
                                sRutaSuper.USUIdSupervisor = USUId;
                                sRutaSuper.MFechaHora = DateTime.Now;
                                sRutaSuper.MUsuarioID = usuario.MUsuarioId;

                                db.SupervisorRuta.Add(sRutaSuper);
                            }
                        }
                    }


                    if (usuario.ConfRuta == true)
                    {
                        Ruta ruta = new Ruta();
                        ruta.RUTClave = USUId;
                        ruta.Descripcion = "Ruta " + USUId + " - " + usuario.Nombre;
                        ruta.Tipo = usuario.TipoRuta;
                        ruta.TipoEstado = 1;
                        ruta.Inventario = false;
                        ruta.FolioClienteNvo = 0;
                        ruta.AlmacenID = usuario.AlmacenID;
                        ruta.MFechaHora = DateTime.Now;
                        ruta.MUsuarioID = usuario.MUsuarioId;

                        db.Ruta.Add(ruta);

                    }


                    db.Usuario.Add(cUsuario);

                    if (usuario.UsuarioAlmacen.Count() > 0)
                    {
                        //Guardar los almacenes extras del usuario
                        foreach (UsuarioAlmacen var in usuario.UsuarioAlmacen)
                        {
                            UsuarioAlmacen usrAlm = new UsuarioAlmacen();

                            usrAlm.AlmacenId = var.AlmacenId;
                            usrAlm.MUsuarioID = usuario.MUsuarioId;
                            usrAlm.USUId = USUId;
                            usrAlm.MFechaHora = DateTime.Now;

                            db.UsuarioAlmacen.Add(usrAlm);
                        }
                    }
                }
                else
                {

                    //Borrar centro de distribución

                    List<string> eliminar = new List<string>();
                    foreach (UsuarioAlmacen usuarioA in cUsuario.UsuarioAlmacen)
                    {

                        if (!usuario.UsuarioAlmacen.ToList().Exists(x => x.USUId == usuarioA.USUId && x.AlmacenId == usuarioA.AlmacenId))
                        {
                            eliminar.Add(usuarioA.AlmacenId);
                        }


                    }


                    foreach (string centro in eliminar)
                    {
                        cUsuario.UsuarioAlmacen.Remove(cUsuario.UsuarioAlmacen.First(x => x.USUId == cUsuario.USUId && x.AlmacenId == centro));
                    }



                    //Eliminar rutas
                    List<string> eliminarRuta = new List<string>();
                    foreach (SupervisorRuta superRuta in cUsuario.SupervisorRuta)
                    {

                        if (!usuario.SupervisorRuta.ToList().Exists(x => x.RUTClave == superRuta.RUTClave))
                        {
                            eliminarRuta.Add(superRuta.RUTClave);
                        }


                    }


                    foreach (string ruta in eliminarRuta)
                    {
                        cUsuario.SupervisorRuta.Remove(cUsuario.SupervisorRuta.First(x => x.USUIdSupervisor == cUsuario.USUId && x.RUTClave == ruta));
                    }


                    //Guardar los almacenes extras del usuario
                    foreach (UsuarioAlmacen var in usuario.UsuarioAlmacen)
                    {
                        if (!db.UsuarioAlmacen.ToList().Exists(x => x.AlmacenId == var.AlmacenId && x.USUId == usuario.USUId))
                        {
                            UsuarioAlmacen usrAlm = new UsuarioAlmacen();
                            usrAlm.AlmacenId = var.AlmacenId;
                            usrAlm.MUsuarioID = usuario.MUsuarioId;
                            usrAlm.USUId = usuario.USUId;
                            usrAlm.MFechaHora = DateTime.Now;
                            db.UsuarioAlmacen.Add(usrAlm);
                        }

                    }


                    if (usuario.Tipo == 3)
                    {
                        if (usuario.SupervisorRuta.Count() > 0)
                        {
                            foreach (SupervisorRuta sRuta in usuario.SupervisorRuta)
                            {
                                if (!db.SupervisorRuta.ToList().Exists(x => x.USUIdSupervisor == cUsuario.USUId && x.RUTClave == sRuta.RUTClave))
                                {
                                    SupervisorRuta sRutaSuper = new SupervisorRuta();

                                    sRutaSuper.RUTClave = sRuta.RUTClave;
                                    sRutaSuper.USUIdSupervisor = cUsuario.USUId;
                                    sRutaSuper.MFechaHora = DateTime.Now;
                                    sRutaSuper.MUsuarioID = usuario.MUsuarioId;

                                    db.SupervisorRuta.Add(sRutaSuper);
                                }


                            }
                        }
                    }

                    //Añadir y eliminar excepciones del Usuario

                    if (usuario.IntUsu.Count > 0)
                    {
                        List<string> eliminar3 = new List<string>();
                        foreach (IntUsu det in cUsuario.IntUsu)
                        {
                            if (!det.PERAct)
                            {
                                if (!usuario.IntUsu.ToList().Exists(x => x.ACTId == det.ACTId))
                                {
                                    eliminar3.Add(det.ACTId);
                                }
                            }


                        }
                        foreach (string act in eliminar3)
                        {
                            cUsuario.IntUsu.Remove(cUsuario.IntUsu.First(x => x.ACTId == act));
                        }

                        foreach (IntUsu det in usuario.IntUsu)
                        {

                            if (det.ACTId == "2C3W3U6PPDS4ANT")
                            {
                                Console.WriteLine("fghgjhkh");
                            }

                            if (cUsuario.IntUsu.ToList().Exists(x => x.ACTId == det.ACTId))
                            {
                                cUsuario.IntUsu.First(x => x.ACTId == det.ACTId).Permiso = det.Permiso;
                                cUsuario.IntUsu.First(x => x.ACTId == det.ACTId).Secuencia = det.Secuencia;
                                cUsuario.IntUsu.First(x => x.ACTId == det.ACTId).MFechaHora = DateTime.Now;
                                cUsuario.IntUsu.First(x => x.ACTId == det.ACTId).MUsuarioId = cUsuario.MUsuarioId;
                            }
                            else
                            {
                                if (det.PERAct == false)
                                {
                                    IntUsu detalle = new IntUsu();
                                    detalle.USUId = cUsuario.USUId;
                                    detalle.ACTId = det.ACTId;
                                    detalle.INTTipoInterfaz = det.INTTipoInterfaz;
                                    detalle.MODId = det.MODId;
                                    detalle.TipoVisible = 1;
                                    detalle.Permiso = det.Permiso;
                                    detalle.Secuencia = det.Secuencia;
                                    detalle.MFechaHora = DateTime.Now;
                                    detalle.MUsuarioId = cUsuario.MUsuarioId;
                                    cUsuario.IntUsu.Add(detalle);
                                }
                                else
                                {
                                    if (db.IntPer.FirstOrDefault(x => x.ACTId == det.ACTId).Permiso.Trim() != det.Permiso)
                                    {
                                        IntUsu detalle = new IntUsu();
                                        detalle.USUId = cUsuario.USUId;
                                        detalle.ACTId = det.ACTId;
                                        detalle.INTTipoInterfaz = det.INTTipoInterfaz;
                                        detalle.MODId = det.MODId;
                                        detalle.Permiso = det.Permiso;
                                        detalle.Secuencia = det.Secuencia;
                                        detalle.MFechaHora = DateTime.Now;
                                        detalle.MUsuarioId = cUsuario.MUsuarioId;
                                        cUsuario.IntUsu.Add(detalle);
                                    }
                                }
                            }
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

        [HttpGet]
        [ActionName("ObtenerUsuario")]
        public IHttpActionResult ObtenerUsuario(string USUId)
        {
            USUId = USUId.Replace(" ", "+");
            var terminales = 0;
            var rutas = 0;
            if ((from x in db.Terminal where x.TerminalClave == USUId select x).ToList().Count > 0) { terminales = 1; }
            if ((from x in db.Ruta where x.RUTClave == USUId select x).ToList().Count > 0) { rutas = 1; }

            if(rutas == 0)
            {
                var usr = (from user in db.Usuario
                          where user.USUId == USUId
                          select new { user.USUId, user.Clave, user.Nombre, ConfTerminal = terminales, ConfRuta = rutas, Tipo = user.Tipo.ToString(), user.DiasLimite, user.ClaveAcceso, user.AlmacenID, user.FechaMod, user.PoliticaId, user.PERClave, Activo = (user.Activo ? 1 : 0)}
                );
                return Json(usr);
            }
            else
            {
                var usr = (from user in db.Usuario
                           join ruta in db.Ruta on user.USUId equals ruta.RUTClave
                           where user.USUId == USUId
                           select new { user.USUId, user.Clave, user.Nombre, ConfTerminal = terminales, ConfRuta = rutas, TipoRuta = ruta.Tipo.ToString(), Tipo = user.Tipo.ToString(), user.DiasLimite, user.ClaveAcceso, user.AlmacenID, user.FechaMod, user.PoliticaId, user.PERClave, Activo = (user.Activo ? 1 : 0) });
                return Json(usr);
            }
        }

        [HttpGet]
        [ActionName("ObtenerUsuarios")]
        public IHttpActionResult ObtenerUsuarios()
        {
            var usr = (from user in db.Usuario
                       select new { user.USUId, user.Clave, user.Nombre, user.Tipo, user.DiasLimite, user.ClaveAcceso, user.AlmacenID, user.FechaMod, user.PoliticaId, user.PERClave, user.Activo }
                           );
            return Json(usr);
        }

        [HttpGet]
        [ActionName("ObtenerDetalleUsuario")]
        public IHttpActionResult ObtenerDetalleUsuario(string USUId)
        {
            USUId = (USUId != null ? (USUId.Length > 0 ? USUId.Replace(" ", "+") : USUId) : null );
            var centro = (from u in db.Almacen
                          join ua in db.UsuarioAlmacen on u.AlmacenID equals ua.AlmacenId
                          where ua.USUId == USUId
                          select new { ua.USUId, ua.AlmacenId, u.Clave, u.Nombre }

                          );
            if (centro.Count() <= 0)
            {
                //    centro.Add(new cVARValor { VARCodigo = "", VAVClave = "", Grupo = "", Estado = "" });
            }


            return Json(centro);
        }


        [HttpGet]
        [ActionName("ObtenerRutasSuper")]
        public IHttpActionResult ObtenerRutasSuper(string USUId)
        {
            USUId = (USUId != null ? (USUId.Length > 0 ? USUId.Replace(" ", "+") : USUId) : USUId );
            var rutas = (from xb in db.SupervisorRuta
                         join x in db.Ruta on xb.RUTClave equals x.RUTClave
                         where xb.USUIdSupervisor == USUId
                         select new cRutaDisponible { RUTClave = xb.RUTClave, Descripcion = x.Descripcion, Tipo = x.Tipo, TipoEstado = x.TipoEstado, Inventario = x.Inventario, FolioClienteNvo = x.FolioClienteNvo, AlmacenID = x.AlmacenID }
                         );

            if (rutas.Count() <= 0)
            {
                //    centro.Add(new cVARValor { VARCodigo = "", VAVClave = "", Grupo = "", Estado = "" });
            }


            return Json(rutas);
        }

        [HttpGet]
        [ActionName("ContrasenaBlanco")]
        public IHttpActionResult ContrasenaBlanco(string PoliticaId)
        {

            var cont = (from x in db.PoliticaContrasena
                        where x.PoliticaId == PoliticaId
                        select new { x.ContrasenaBlanco }
                        );


            return Json(cont);
        }

        [HttpGet]
        [ActionName("ObtenerPERClave")]
        public IHttpActionResult ObtenerPERClave(string USUId)
        {
            USUId = USUId.Replace(" ", "+");
            var PERClave = (from x in db.Usuario
                            where x.USUId == USUId
                            select new { x.PERClave }
                          );

            return Json(PERClave);
        }



        //Buscar Ruta libres



        [HttpGet]
        [ActionName("RutasDisponibles")]
        public IHttpActionResult RutasDisponibles(string AlmacenId)
        {
            var rutasDisponibles = new List<cRutaDisponible>();
            var disponible = true;
            var rutasSupervisor = (from x in db.SupervisorRuta select x);
            var rutasTotales = (from x in db.Ruta where x.TipoEstado == 1 && x.AlmacenID == AlmacenId select new cRutaDisponible { RUTClave = x.RUTClave, Descripcion = x.Descripcion, Tipo = x.Tipo, TipoEstado = x.TipoEstado, Inventario = x.Inventario, FolioClienteNvo = x.FolioClienteNvo, AlmacenID = x.AlmacenID });
            foreach (cRutaDisponible ruta in rutasTotales)
            {
                foreach (SupervisorRuta super in rutasSupervisor)
                {
                    if (ruta.RUTClave == super.RUTClave)
                    {
                        disponible = false;
                        break;
                    }
                    else
                        disponible = true;
                }
                if (disponible == true)
                    rutasDisponibles.Add(ruta);
            }
            return Json(rutasDisponibles);
        }

        //Excepciones de Usuario
        [HttpGet]
        [ActionName("ObtenerModulos")]
        public IHttpActionResult ObtenerModulos(string Clave, int TipoInterfaz, bool Disponibles, string PERClave)
        {
            string MEDTipoLenguaje = "EM";
            Clave = Clave.Replace(" ", "+");
            RouteEntities db = new RouteEntities();
            var modulos = (from m in db.Modulo
                           join msg in db.MENDetalle on new { MENClave = m.MENNombreClave, MEDTipoLenguaje = MEDTipoLenguaje } equals new { MENClave = msg.MENClave, MEDTipoLenguaje = msg.MEDTipoLenguaje }
                           //where m.TipoInterfaz == TipoInterfaz
                           orderby m.TipoInterfaz, m.Secuencia
                           select new cModulo { MODId = m.MODId, Clave = m.MENNombreClave, Nombre = msg.Descripcion, Imagen = m.Imagen, TipoInterfaz = m.TipoInterfaz }).ToList();

            foreach (cModulo oModulo in modulos)
            {
                oModulo.SetImagenBase64();
                if (Disponibles)
                    ObtenerActividadesDisponibles(oModulo, Clave, MEDTipoLenguaje, PERClave);
                else
                    ObtenerActividadesAsignadas(oModulo, Clave, MEDTipoLenguaje, PERClave);
            }

            return Json(modulos);
        }

        public void ObtenerActividadesDisponibles(cModulo Modulo, string clave, string MEDTipoLenguaje, string PERClave)
        {
            getClave();

            RouteEntities db = new RouteEntities();

            var actividadesPerfil = (from a in db.Actividad
                                     join i in db.Interfaz on a.ACTId equals i.ACTId
                                     join m in db.MENDetalle on new { MENClave = a.MENNombreClave, MEDTipoLenguaje = MEDTipoLenguaje } equals new { MENClave = m.MENClave, MEDTipoLenguaje = m.MEDTipoLenguaje }
                                     //   join p in db.IntUsu on new { ACTId = a.ACTId, clave = clave } equals new { ACTId = p.ACTId, clave = p.USUId } into pl
                                     join p in db.IntPer on new { ACTId = a.ACTId, PERClave = PERClave } equals new { ACTId = p.ACTId, PERClave = p.PERClave } into pl
                                     from p in pl.DefaultIfEmpty()
                                     where i.MODId == Modulo.MODId && p == null
                                     orderby i.Secuencia
                                     select new cActividad { ACTId = a.ACTId, Nombre = m.Descripcion, Permiso = i.Permiso, PermisoA = "", PERAct = true, Asignada = false }).ToList();


            var actividadesUsu = (from a in db.Actividad
                                  join i in db.Interfaz on a.ACTId equals i.ACTId
                                  join m in db.MENDetalle on new { MENClave = a.MENNombreClave, MEDTipoLenguaje = MEDTipoLenguaje } equals new { MENClave = m.MENClave, MEDTipoLenguaje = m.MEDTipoLenguaje }
                                  join p in db.IntUsu on a.ACTId equals p.ACTId
                                  where i.MODId == Modulo.MODId && p.USUId == clave
                                  orderby i.Secuencia
                                  select new cActividad { ACTId = a.ACTId, Nombre = m.Descripcion, Permiso = i.Permiso, PermisoA = "", PERAct = false, Asignada = false }).ToList();


            var actividades = new List<cActividad>();
            var eliminada = new List<int>();

            var contElim = 0;

            foreach (cActividad acti in actividadesPerfil)
            {
                foreach (cActividad act2 in actividadesUsu)
                {

                    if (acti.ACTId == "26JAQ+1MJDA2OVT")
                    {
                        Console.WriteLine("hfghf");
                    }

                    if (acti.ACTId == act2.ACTId)
                    {
                        //Ya existe el registrp
                        actividades.Add(new cActividad { ACTId = act2.ACTId, Nombre = act2.Nombre, Permiso = act2.Permiso, PermisoA = act2.PermisoA, PERAct = false, Asignada = false });
                        eliminada.Add(contElim);
                    }
                }
                contElim++;
            }

            eliminada.Reverse();

            foreach (int a in eliminada)
            {
                actividadesPerfil.RemoveAt(a);
            }

            actividades = actividadesPerfil;

            foreach (cActividad act in actividades)
            {
                try
                {
                    if (act.ACTId.ToUpper().StartsWith("TINDMMD"))
                    {
                        act.Nombre = db.VAVDescripcion.First(x => x.VARCodigo == "TINDMMD" && x.VAVClave == act.ACTId.ToUpper().Replace("TINDMMD", "") && x.VADTipoLenguaje == MEDTipoLenguaje).Descripcion;
                    }
                    else if (act.ACTId.ToUpper().StartsWith("REPORTEW"))
                    {
                        act.Nombre = db.VAVDescripcion.First(x => x.VARCodigo == "REPORTEW" && x.VAVClave == act.ACTId.ToUpper().Replace("REPORTEW", "") && x.VADTipoLenguaje == MEDTipoLenguaje).Descripcion;
                    }
                    else if (act.ACTId.ToUpper().StartsWith("MAPAW"))
                    {
                        act.Nombre = db.VAVDescripcion.First(x => x.VARCodigo == "MAPAW" && x.VAVClave == act.ACTId.ToUpper().Replace("MAPAW", "") && x.VADTipoLenguaje == MEDTipoLenguaje).Descripcion;
                    }
                }
                catch { }
            }

            Modulo.Actividades = actividades;
        }

        public void ObtenerActividadesAsignadas(cModulo Modulo, string clave, string MEDTipoLenguaje, string PERClave)
        {

            RouteEntities db = new RouteEntities();

            var actividades = (from a in db.Actividad
                               join z in db.Interfaz on a.ACTId equals z.ACTId
                               join i in db.IntUsu on new { ACTId = a.ACTId, clave = clave } equals new { ACTId = i.ACTId, clave = i.USUId }
                               join m in db.MENDetalle on new { MENClave = a.MENNombreClave, MEDTipoLenguaje = MEDTipoLenguaje } equals new { MENClave = m.MENClave, MEDTipoLenguaje = m.MEDTipoLenguaje }
                               where i.MODId == Modulo.MODId && i.USUId == clave
                               orderby i.Secuencia
                               select new cActividad { ACTId = a.ACTId, Nombre = m.Descripcion, Permiso = z.Permiso, PermisoA = i.Permiso, PERAct = false, Asignada = true }).ToList();

            var actividadesPerfil = (from a in db.Actividad
                                     join z in db.Interfaz on a.ACTId equals z.ACTId
                                     join i in db.IntPer on new { ACTId = a.ACTId, PERClave = PERClave } equals new { ACTId = i.ACTId, PERClave = i.PERClave }
                                     join m in db.MENDetalle on new { MENClave = a.MENNombreClave, MEDTipoLenguaje = MEDTipoLenguaje } equals new { MENClave = m.MENClave, MEDTipoLenguaje = m.MEDTipoLenguaje }
                                     where i.MODId == Modulo.MODId
                                     orderby i.Secuencia
                                     select new cActividad { ACTId = a.ACTId, Nombre = m.Descripcion, Permiso = z.Permiso, PermisoA = i.Permiso, PERAct = true, Asignada = true }).ToList();

            var eliminados = new List<int>();
            var actNuevas = new List<cActividad>();

            if (actividadesPerfil.Count > 0)
            {
                foreach(cActividad act in actividades)
                {
                    if(actividadesPerfil.Where(a => a.ACTId == act.ACTId).Count() == 0)
                    {
                        actividadesPerfil.Add(new cActividad { ACTId = act.ACTId, Nombre = act.Nombre, Permiso = act.Permiso, PermisoA = act.PermisoA, PERAct = false, Asignada = true });
                    }
                }
                //var cont2 = 0;
                //foreach (cActividad act in actividadesPerfil)
                //{
                //    var cont = 0;
                //    foreach (cActividad act2 in actividades)
                //    {
                //        if (act.ACTId == act2.ACTId)
                //        {
                //            Console.WriteLine("ddfgfhgg" + act.Nombre + " - " + act.Permiso);


                //            eliminados.Add(cont);

                //        }
                //        if (cont2 < 1)
                //        {
                //            actNuevas.Add(new cActividad { ACTId = act2.ACTId, Nombre = act2.Nombre, Permiso = act2.Permiso, PermisoA = act2.PermisoA, PERAct = false, Asignada = true });
                //        }
                //        cont++;

                //    }
                //    cont2++;
                //}
            }
            else
            {
                foreach (cActividad act2 in actividades)
                {
                    //actNuevas.Add(new cActividad { ACTId = act2.ACTId, Nombre = act2.Nombre, Permiso = act2.Permiso, PermisoA = act2.PermisoA, Asignada = true });
                    actividadesPerfil.Add(new cActividad { ACTId = act2.ACTId, Nombre = act2.Nombre, Permiso = act2.Permiso, PermisoA = act2.PermisoA, Asignada = true });
                }

            }
            //foreach (cActividad c in actNuevas)
            //{
            //    actividadesPerfil.Add(c);
            //}


            //foreach (int a in eliminados)
            //{
            //    actividadesPerfil.RemoveAt(a);
            //}
            //prueba

            actividadesPerfil.OrderBy(x => x.Nombre);

            actividades = actividadesPerfil;
            for(int i = 0; i < actividades.Count; i++)
            {
                string permiso = actividades[i].PermisoA;
                actividades[i].Create = permiso.Contains("C");
                actividades[i].Read = permiso.Contains("R");
                actividades[i].Update = permiso.Contains("U");
                actividades[i].Delete = permiso.Contains("D");
                actividades[i].Execute = permiso.Contains("E");
                actividades[i].Others = permiso.Contains("O");
                actividades[i].Print = permiso.Contains("P");
                actividades[i].Sign = permiso.Contains("S");
            }
            //foreach (cActividad act in actividades)
            //{
            //    act.Create = act.PermisoA.Contains("C");
            //    act.Read = act.PermisoA.Contains("R");
            //    act.Update = act.PermisoA.Contains("U");
            //    act.Delete = act.PermisoA.Contains("D");
            //    act.Execute = act.PermisoA.Contains("E");
            //    act.Others = act.PermisoA.Contains("O");
            //    act.Print = act.PermisoA.Contains("P");
            //    act.Sign = act.PermisoA.Contains("S");

            //    try
            //    {
            //        if (act.ACTId.ToUpper().StartsWith("TINDMMD"))
            //        {
            //            act.Nombre = db.VAVDescripcion.First(x => x.VARCodigo == "TINDMMD" && x.VAVClave == act.ACTId.ToUpper().Replace("TINDMMD", "") && x.VADTipoLenguaje == MEDTipoLenguaje).Descripcion;
            //        }
            //        else if (act.ACTId.ToUpper().StartsWith("REPORTEW"))
            //        {
            //            act.Nombre = db.VAVDescripcion.First(x => x.VARCodigo == "REPORTEW" && x.VAVClave == act.ACTId.ToUpper().Replace("REPORTEW", "") && x.VADTipoLenguaje == MEDTipoLenguaje).Descripcion;
            //        }
            //        else if (act.ACTId.ToUpper().StartsWith("MAPAW"))
            //        {
            //            act.Nombre = db.VAVDescripcion.First(x => x.VARCodigo == "MAPAW" && x.VAVClave == act.ACTId.ToUpper().Replace("MAPAW", "") && x.VADTipoLenguaje == MEDTipoLenguaje).Descripcion;
            //        }
            //    }
            //    catch { }
            //}

            Modulo.Actividades = actividades;
        }



        public int getMayor()
        {
            //var a =    db.Usuario.OrderByDescending(x => x.USUId).FirstOrDefault();
            var users = db.Usuario.ToList();
            var unreal = false;
            var numAux = 0;
            var num = 0;
            foreach (Usuario a in users)
            {
                try
                {
                    num = Int32.Parse(a.USUId);
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
            var repetido = true;
            var mayor = getMayor();
            mayor++;

            while (!repetido)
            {
                if (db.Usuario.ToList().Exists(x => x.USUId == mayor.ToString()))
                {
                    repetido = true;
                    mayor++;
                }
                else
                {
                    repetido = false;
                }
            }



            return mayor.ToString();
        }

        [HttpGet]
        [ActionName("Prueba")]
        public IHttpActionResult Prueba(string valorDato)
        {
            var usuarios = (from x in db.Usuario 
                            where x.Clave==valorDato
                            select new { x.Nombre, x.Tipo, x.USUId }
                            );


            return Json(usuarios);
        }
        [HttpPost]
        public bool GuardarDatos(Usuario usuario) //valor = msg
        {

            var usr = new Usuario();
            usr.Clave = usuario.Clave;
            usr.Tipo = usuario.Tipo;
            usr.Nombre = usuario.Nombre;
            usr.USUId = "prueba3";
            usr.PERClave = "Prueba";
            usr.ClaveAcceso = "www";
            usr.DiasLimite = 2;
            usr.FechaMod = DateTime.Now;
            usr.Activo = true ;
            usr.AlmacenID = "DETA";
            usr.MFechaHora = DateTime.Now;
            usr.MUsuarioId = "Interfaz";

            db.Usuario.Add(usr);

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
           

            return true;

        }
    }
}