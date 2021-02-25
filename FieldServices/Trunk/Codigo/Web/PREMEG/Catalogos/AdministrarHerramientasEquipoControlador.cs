using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODMEG;
using PREMEG.Util;

namespace PREMEG.Catalogos
{
    public class AdministrarHerramientasEquipoControlador
    {
        IAdministrarHerramientasEquipo _vista;
        public AdministrarHerramientasEquipoControlador(IAdministrarHerramientasEquipo vista)
        {
            _vista = vista;
        }
                
        public List<MODMEG.ActivoFijo> ObtenerActivos()
        {
            List<ActivoFijo> lista;
            using (MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities())
            {
                 lista = contexto.ActivoFijo.Include("Usuario").Include("Usuario.Sucursal").ToList();                
            }
            return lista;
        }

        public ActivoFijo ObtenerActivos(string clave)
        {
            ActivoFijo obj = null;
            using (MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities())
            {
                obj = contexto.ActivoFijo.Include("Usuario").FirstOrDefault(o => o.ClaveActivo == clave);
            }
            return obj;
        }




        public List<objCombo> ObtenerUsuarios()
        {
            List<objCombo> lista;
            using (MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities()) {
                lista = contexto.Usuario.Where(u=>u.Tipo == 7 && u.Estado).Select(obj => new objCombo { Clave = obj.ClaveUsuario, Texto = obj.Nombre, ClaveSucursal = obj.ClaveSucursal }).ToList();            
            }                        
            return lista;
        }

        public void Insertar(ActivoFijo  obj)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                obj.Usuario = contexto.Usuario.FirstOrDefault(o => o.ClaveSucursal== obj.ClaveUsuario);                
                contexto.AddToActivoFijo(obj);
                contexto.SaveChanges();
            }
        }

        public void Actualizar(ActivoFijo obj)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                contexto.ActivoFijo.Attach(obj);
                contexto.ObjectStateManager.ChangeObjectState(obj, System.Data.EntityState.Modified);                                               
                contexto.SaveChanges();
            }
        }


        public bool validaEstadoHerramientas(string clave)
        {
            using (MegaCableEntities ctx = new MegaCableEntities())
            {
                if (ctx.InventarioActivosFijos.Any(o => o.ClaveActivo == clave))
                    return false;
            }
            return true;
        }


        public List<Sucursal> ObtenerSucursales()
        {
            List<Sucursal> lista;
            using (MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities())
            {
                lista = contexto.Sucursal.ToList();
            }
            return lista;
        }
    }
}
