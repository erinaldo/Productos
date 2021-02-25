using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using MODMEG;

namespace PREMEG.Acceso
{
    public class AdministrarUsuarios
    {
        IAdministracionUsuarios _vista;
        public AdministrarUsuarios(IAdministracionUsuarios vista)
        {
            _vista = vista;
        }
        public List<ListaUsuarios> ObtenerUsuariosInicio()
        {

            using (MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities())
            {
                var usuarios = (from usu in contexto.Usuario
                                select new ListaUsuarios
                                {
                                    ClaveUsuario = usu.ClaveUsuario,
                                    Nombre = usu.Nombre,
                                    NombrePerfil = usu.Perfil.Nombre,
                                    NombreSucursal = usu.Sucursal.Nombre,
                                    Estado = usu.Estado,
                                    ClavePerfil = usu.ClavePerfil,
                                    Contrasenia = usu.Contrasenia,
                                    Tipo = usu.Tipo,
                                    ClaveCuadrilla = usu.ClaveCuadrilla,
                                    ClaveSucursal = usu.ClaveSucursal
                                }).OrderBy(u => u.ClaveUsuario);
                return usuarios.ToList();
            }
        }

        public class ListaUsuarios
        {
            public ListaUsuarios()
            {
            }
            public string ClaveUsuario { get; set; }
            public string Nombre { get; set; }
            public string NombrePerfil { get; set; }
            public string NombreSucursal { get; set; }
            public bool Estado { get; set; }
            public string ClavePerfil { get; set; }
            public string Contrasenia { get; set; }
            public short Tipo { get; set; }
            public string ClaveCuadrilla { get; set; }
            public string ClaveSucursal { get; set; }
        }

        public class ListaValoresReferencia
        {
            public ListaValoresReferencia()
            {
            }
            public short Valor { get; set; }
            public string Descripcion { get; set; } 
            public short? Grupo { get; set; }
        }

        public bool ActualizarUsuario(string ClaveUsuario, string ClavePerfil, string ClaveCuadrilla, string ClaveSucursal, short Tipo, string Contrasenia, string Nombre, bool Activo)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                Usuario usuario = (from usu in contexto.Usuario where usu.ClaveUsuario == (string)ClaveUsuario select usu).FirstOrDefault();
                if (usuario != null)
                {
                    usuario.ClavePerfil = ClavePerfil;
                    usuario.ClaveCuadrilla = ClaveCuadrilla;
                    usuario.ClaveSucursal = ClaveSucursal;
                    usuario.Tipo = Tipo;
                    usuario.Contrasenia = Contrasenia;
                    usuario.Nombre = Nombre;
                    usuario.Estado = Activo;
                    contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool RegistrarUsuario(string ClaveUsuario, string ClavePerfil, string ClaveCuadrilla, string ClaveSucursal, short Tipo, string Contrasenia, string Nombre, bool Activo)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                Usuario usuario = new Usuario();
                if (usuario != null)
                {
                    usuario.ClaveUsuario = ClaveUsuario;
                    usuario.ClavePerfil = ClavePerfil;
                    usuario.ClaveCuadrilla = (Tipo == 7 ? ClaveCuadrilla : null);
                    usuario.ClaveSucursal = ClaveSucursal;
                    usuario.Tipo = Tipo;
                    usuario.Contrasenia = Contrasenia;
                    usuario.Nombre = Nombre;
                    usuario.Estado = Activo;
                    contexto.Usuario.AddObject(usuario);
                    contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public void CrearModificarPerfil()
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {

                var perfiles = (from per in contexto.Perfil where per.Estado select new { per.ClavePerfil, per.Nombre }).ToList();
                //perfiles.Insert(0, new { ClavePerfil = "", Nombre = "" });

                var valores = (from val in contexto.ValorReferencia where val.Clave == "TIPUSU" && val.Estado select new ListaValoresReferencia { Valor = val.Valor, Descripcion = val.Descripcion, Grupo = val.Grupo }).ToList();
                //valores.Insert(0, new ListaValoresReferencia { Valor = (short)0, Descripcion = "", Grupo = (short?)0 });

                var sucursales = (from suc in contexto.Sucursal where suc.Estado select new { suc.ClaveSucursal, suc.Nombre }).ToList();
                //sucursales.Insert(0, new { ClaveSucursal = "", Nombre = "" });

                List<EleCuadrilla> cuadrillas = (from cua in contexto.Cuadrilla where cua.Estado select new EleCuadrilla() { ClaveCuadrilla = cua.ClaveCuadrilla, Nombre = cua.Nombre, ClaveSucursal = cua.ClaveSucursal }).ToList();
                //cuadrillas.Insert(0, new { ClaveCuadrilla = "", Nombre = "" });
                _vista.CargarCatalogos(perfiles, valores, sucursales, cuadrillas);
            }

        }

        public class EleCuadrilla
        {
            public string ClaveCuadrilla { get; set; }
            public string Nombre { get; set; }
            public string ClaveSucursal { get; set; }
        }
        public enum ResultadoValidacion
        {
            Relacionado,
            UsuarioExistente,
            CuadrillaAsignada,
            TodoBien
        }
        public ResultadoValidacion ValidarDatos(bool Estado, string ClaveUsuario, string ClaveCuadrilla, bool Nuevo)
        {
            bool res = true;
            using (MegaCableEntities ctx = new MegaCableEntities())
            {
                if (!Estado)
                    res = !ctx.ActivoFijo.Any(o => o.ClaveUsuario == ClaveUsuario);
                if( !res)
                    return   ResultadoValidacion.Relacionado;
                if (Nuevo)
                    res = !ctx.Usuario.Any(o => o.ClaveUsuario == ClaveUsuario);
                if (!res)
                    return ResultadoValidacion.UsuarioExistente;

                /*res = !ctx.Usuario.Any(o => o.ClaveUsuario != ClaveUsuario && o.ClaveCuadrilla == ClaveCuadrilla);
                if (!res)
                    return ResultadoValidacion.CuadrillaAsignada;*/
            }
            return  ResultadoValidacion.TodoBien;
        }

    }
}
