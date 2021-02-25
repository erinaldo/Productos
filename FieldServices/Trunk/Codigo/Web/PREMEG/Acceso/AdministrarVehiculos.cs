using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODMEG;

namespace PREMEG.Acceso
{
    public class AdministrarVehiculos
    {
        private IAdministracionVehiculos vista;
        public AdministrarVehiculos(IAdministracionVehiculos Vista)
        {
            vista = Vista;
        }

        public List<Vehiculo> ObtenerVehiculos()
        {
            List<Vehiculo> res ;
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var vehiculos = (from veh in contexto.Vehiculo.Include("Sucursal") select veh).OrderBy(v => v.NumeroEconomicoVh);
                res = vehiculos.ToList();
            }
            return res;
        }

        public void CrearModificarVehiculo()
        {
            
        }

        public List<Sucursal> ObtenerSucursales()
        {
            List<Sucursal> res;
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var sucursales = from suc in contexto.Sucursal select suc;
                res = sucursales.ToList();
            }
            return res;
           
        }

        public bool ActualizarVehiculo(Vehiculo vehiculo)
        {

            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                Vehiculo veh = (from v in contexto.Vehiculo where v.NumeroEconomicoVh == vehiculo.NumeroEconomicoVh select v).FirstOrDefault();
                if(veh != null){
                    veh.ClaveSucursal = vehiculo.ClaveSucursal;
                    veh.Placas = vehiculo.Placas;
                    veh.Marca = vehiculo.Marca;
                    veh.SubMarca = vehiculo.SubMarca;
                    veh.Modelo = vehiculo.Modelo;
                    veh.CodigoBarras = vehiculo.CodigoBarras;
                    veh.KmInicial = vehiculo.KmInicial;
                    veh.KmFinal = vehiculo.KmFinal;
                    contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool RegistrarVehiculo(Vehiculo veh)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                try
                {
                    contexto.Vehiculo.AddObject(veh);
                    contexto.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    return false;
                }
                
            }
        }
    }
}
