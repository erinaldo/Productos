using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODMEG;

namespace PREMEG.Acceso
{
    public class AdministrarSucursalEquipo
    {
        IAdministracionSucursalEquipo vista;
        public class ResultadoAutocompletar
        {
            public string id { get; set; }
            public string value { get; set; }
        }
        public AdministrarSucursalEquipo()
        {
        }
        public AdministrarSucursalEquipo(IAdministracionSucursalEquipo Vista)
        {
            vista = Vista;
        }


        public List<Sucursal> ObtenerSucursales()
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var lista = from suc in contexto.Sucursal where suc.Estado select suc;
                return lista.ToList();
            }
        }

        public void ObtenerMateriales(string ClaveSucursal)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var lista = (from suc in contexto.Sucursal
                             where suc.ClaveSucursal == ClaveSucursal
                             select suc).FirstOrDefault().Material.OrderBy(m => m.Descripcion);
                vista.ListaMateriales = lista.ToList();
            }
        }

        public List<ResultadoAutocompletar> ObtenerMaterialesContenido(string term, string ClaveSucursal)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var lista = (from mat in contexto.Material
                             orderby mat.Descripcion
                             where (mat.Descripcion.Contains(term) || mat.ClaveMaterial.Contains(term)) &&
                             !mat.Sucursal.Any(s => s.ClaveSucursal == ClaveSucursal)
                             select new ResultadoAutocompletar() { id = mat.ClaveMaterial, value = mat.ClaveMaterial + ":" + mat.Descripcion }).Take(20);
                return lista.ToList();
            }
        }

        public void AgregarSucursalEquipo(string ClaveSucursal, string ClaveMaterial)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                if (!contexto.Sucursal.Any(s => s.Material.Any(m => m.ClaveMaterial == ClaveMaterial) && s.ClaveSucursal == ClaveSucursal))
                {
                    Sucursal sucursal = (from suc in contexto.Sucursal where suc.ClaveSucursal == ClaveSucursal select suc).First();
                    if (sucursal != null)
                    {
                        sucursal.Material.Add(contexto.Material.Where(m => m.ClaveMaterial == ClaveMaterial).First());
                        contexto.SaveChanges();
                    }
                }
                
            }
        }


        public void EliminarSucursalEquipo(string ClaveSucursal, string ClaveMaterial)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                if (contexto.Sucursal.Any(s => s.Material.Any(m => m.ClaveMaterial == ClaveMaterial)))
                {
                    Sucursal sucursal = (from suc in contexto.Sucursal where suc.ClaveSucursal == ClaveSucursal select suc).First();
                    if (sucursal != null)
                    {
                        sucursal.Material.Remove(sucursal.Material.Where(m => m.ClaveMaterial == ClaveMaterial).First());
                        contexto.SaveChanges();
                    }
                }

            }
        }
    }
}
