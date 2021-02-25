using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PREMEG.Util;
using MODMEG;

namespace PREMEG.Catalogos
{
    public class AdministrarConfiguracionesControlador
    {
        IAdministrarConfiguraciones _vista;
        public AdministrarConfiguracionesControlador(IAdministrarConfiguraciones vista)
        {
            _vista = vista;
        }
                
        public List<MODMEG.Configuracion> ObtenerConfiguracionesInicio()
        {
            using (MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities())
            {
                var lista = contexto.Configuracion.Include("Sucursal").Include("ValorConfiguracion").ToList();
                return lista.OrderBy(o=>o.Sucursal.Nombre).ToList();
            }
        }

        public Configuracion ObtenerConfiguraciones(string ClaveSucursal, string Parametro)
        {
            Configuracion obj = null;
            using (MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities())
            {
                obj = contexto.Configuracion.FirstOrDefault(o => o.ClaveSucursal == ClaveSucursal && o.Parametro == Parametro);
                return obj;
            }
        }

        public List<objCombo> ObtenerSucursales()
        {
            using (MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities())
            {
                var lista = contexto.Sucursal.Where(o=>o.Estado == true).Select(obj => new objCombo { Clave = obj.ClaveSucursal, Texto = obj.Nombre }).ToList();
                return lista;
            }
        }

        public List<objCombo> ObtenerValorConfiguracion()
        {
            MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities();
            var lista = contexto.ValorConfiguracion.Select(obj => new objCombo { Clave = obj.Parametro, Texto = obj.Descripcion }).ToList();
            return lista;
        }

        public ValorConfiguracion ObtenerValorConfiguracion(string parametro)
        {
            MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities();
            var res = contexto.ValorConfiguracion.FirstOrDefault(obj=>obj.Parametro == parametro);
            return res;
        }

        public List<objCombo> ObtenerValorReferencia(string clave)
        {
            MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities();
            var lista = contexto.ValorReferencia.Where(obj=>obj.Clave == clave).ToList();
            List<objCombo> res = new List<objCombo>();
            foreach (var o in lista) {
                objCombo obj = new objCombo();
                obj.Clave = o.Valor.ToString();
                obj.Texto = o.Descripcion;
                res.Add(obj);
            }
            return res;
        }

        public void Insertar(Configuracion obj)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                contexto.AddToConfiguracion(obj);
                contexto.SaveChanges();
            }
        }

        public void Actualizar(Configuracion obj)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                contexto.Configuracion.Attach(obj);
                contexto.ObjectStateManager.ChangeObjectState(obj, System.Data.EntityState.Modified);
                contexto.SaveChanges();
            }
        }
    }
}
