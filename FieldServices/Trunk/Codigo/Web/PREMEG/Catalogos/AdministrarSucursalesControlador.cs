using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PREMEG.Util;
using MODMEG;

namespace PREMEG.Catalogos
{
    public class AdministrarSucursalesControlador
    {
         IAdministrarSucursales _vista;
         public AdministrarSucursalesControlador(IAdministrarSucursales vista)
        {
            _vista = vista;
        }


         public Sucursal ObtenerSucursal(string clave , MegaCableEntities ctx) {
             Sucursal obj = null;             
             obj = ctx.Sucursal.FirstOrDefault(o => o.ClaveSucursal == clave);             
             return obj;
         }

         public Sucursal ObtenerSucursal(string clave)
         {
             Sucursal obj = null;
             using (MegaCableEntities ctx = new MegaCableEntities()) {                
                 obj = ctx.Sucursal.FirstOrDefault(o => o.ClaveSucursal == clave); 
             }            
             return obj;
         }

        public List<Sucursal> ObtenerSucursalesInicio()
        {
            MegaCableEntities contexto = new MegaCableEntities();
            var lista = contexto.Sucursal.OrderBy(obj=>obj.ClaveSucursal).ToList();
            return lista;
        }

        public List<objCombo> ObtenerCiudades()
        {
            MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities();
            var lista = contexto.Ciudad.Select(obj => new objCombo { Clave = obj.ClaveCiudad, Texto = obj.Nombre }).ToList();
            return lista;

        }

        public List<objCombo> ObtenerRegionesActivas()
        {
            MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities();
            var lista = contexto.Region.Where(obj=>obj.Estado == true).Select(obj => new objCombo { Clave = obj.ClaveRegion, Texto = obj.Nombre }).ToList();
            return lista;
        }

        public void Insertar(Sucursal obj) {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                obj.Ciudad = contexto.Ciudad.FirstOrDefault(o => o.ClaveCiudad == obj.ClaveCiudad);
                obj.Region = contexto.Region.FirstOrDefault(o => o.ClaveRegion == obj.ClaveRegion);
                contexto.AddToSucursal(obj);
                contexto.SaveChanges();
            }
        }

        public void Actualizar(Sucursal obj)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                Sucursal objEdit = ObtenerSucursal(obj.ClaveSucursal,contexto);
                objEdit.CodigoBarrasLlegada = obj.CodigoBarrasLlegada;
                objEdit.CodigoBarrasSalida = obj.CodigoBarrasSalida;
                objEdit.Estado = obj.Estado;
                objEdit.Nombre = obj.Nombre;
                if (objEdit.ClaveCiudad != obj.ClaveCiudad)
                    objEdit.Ciudad = contexto.Ciudad.FirstOrDefault(o => o.ClaveCiudad == obj.ClaveCiudad);
                if (objEdit.ClaveRegion != obj.ClaveRegion)
                    objEdit.Region = contexto.Region.FirstOrDefault(o => o.ClaveRegion == obj.ClaveRegion);
                contexto.SaveChanges();
            }
        }

        public bool validaEstadoSucursal(string claveSucursal) {

            using (MegaCableEntities ctx = new MegaCableEntities()) {

                if (ctx.Cuadrilla.Any(o => o.ClaveSucursal == claveSucursal))
                    return false;

                if (ctx.Configuracion.Any(o => o.ClaveSucursal == claveSucursal))
                    return false;

                if (ctx.Vehiculo.Any(o => o.ClaveSucursal == claveSucursal))
                    return false;

                if (ctx.Usuario.Any(o => o.ClaveSucursal == claveSucursal))
                    return false;

                if (ctx.Terminal.Any(o => o.ClaveSucursal == claveSucursal))
                    return false;

                if (ctx.AuditoriaRecepcion.Any(o => o.ClaveSucursal == claveSucursal))
                    return false;            
            }

            return true;
        }


        

    }
}
