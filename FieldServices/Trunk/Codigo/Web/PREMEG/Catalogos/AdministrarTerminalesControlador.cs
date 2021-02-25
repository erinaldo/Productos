using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PREMEG.Util;
using MODMEG;

namespace PREMEG.Catalogos
{
    public class AdministrarTerminalesControlador
    {
        IAdministrarTerminales _vista;
        
        public AdministrarTerminalesControlador(IAdministrarTerminales vista)
        {
            _vista = vista;
        }
                
        public List<MODMEG.Terminal> ObtenerTerminalesInicio()
        {

            MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities();
            var lista = contexto.Terminal.ToList();
            return lista;
        }

        public Terminal ObtenerTerminales(string clave)
        {
            Terminal obj = null;
            using (MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities())
            {
               obj = contexto.Terminal.FirstOrDefault(o=>o.ClaveTerminal == clave);
               return obj;
            }
        }

        public List<objCombo> ObtenerSucursales()
        {
            MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities();
            var lista = contexto.Sucursal.Select(obj => new objCombo { Clave = obj.ClaveSucursal, Texto = obj.Nombre }).ToList();
            return lista;
        }

        public List<objCombo> ObtenerValorReferencia(string clave)
        {
            MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities();
            var lista = contexto.ValorReferencia.Where(obj => obj.Clave == clave).ToList();
            List<objCombo> res = new List<objCombo>();
            foreach (var o in lista)
            {
                objCombo obj = new objCombo();
                obj.Clave = o.Valor.ToString();
                obj.Texto = o.Descripcion;
                res.Add(obj);
            }
            return res;
        }

        public List<objCombo> ObtenerValorReferencia()
        {
            MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities();
            var lista = contexto.ValorReferencia.Where(o => o.Estado == true && o.Clave == "FASETERM").ToList();
            List<objCombo> res = new List<objCombo>();
            foreach (var o in lista)
            {
                objCombo obj = new objCombo();
                obj.Clave = o.Valor.ToString();
                obj.Texto = o.Descripcion;
                res.Add(obj);
            }
            return res;
        }

        public void Insertar(Terminal obj)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                obj.Sucursal = contexto.Sucursal.FirstOrDefault(o => o.ClaveSucursal== obj.ClaveSucursal);                
                contexto.AddToTerminal(obj);
                contexto.SaveChanges();
            }
        }

        public void Actualizar(Terminal obj)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                Terminal objEdit = contexto.Terminal.FirstOrDefault(o => o.ClaveTerminal == obj.ClaveTerminal);
                objEdit.Comentario = obj.Comentario;
                objEdit.Modelo = obj.Modelo;
                objEdit.NumeroSerie = obj.NumeroSerie;
                objEdit.GPS= obj.GPS;
                objEdit.Fase = obj.Fase;
                if (objEdit.ClaveSucursal!= obj.ClaveSucursal)
                    objEdit.Sucursal = contexto.Sucursal.FirstOrDefault(o => o.ClaveSucursal== obj.ClaveSucursal);    
                contexto.SaveChanges();
            }
        }

    }
}
