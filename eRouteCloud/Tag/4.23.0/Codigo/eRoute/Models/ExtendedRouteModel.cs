using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRoute.Models
{
    public partial class PrecioProductoVig
    {

        public System.DateTime FechaAux { get; set; }
    }

    public partial class Usuario {

        public bool ConfVendedor { get; set; }
        public bool ConfTerminal { get; set; }
        public bool ConfRuta { get; set; }
        public bool ConfAlmacen { get; set; }
        public short TipoRuta { get; set; }
      //  public List<SupervisorRuta> RutasSuper { get; set; }

    }

    public partial class Moneda
    {
        public System.DateTime FechaInicial { get; set; }
        public double Valor { get; set; }

    }
    public partial class IntUsu
    {
        public bool PERAct { get; set; }
        public bool Asignada { get; set; }
    }

    public class cCamion
    {
        public string AlmacenID { get; set; }
        public string Placa { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public bool Existe { get; set; }
    }

    public partial class SubEmpresa
    {
        public string BaseImg { get; set; }
        public List<cFactura> Factura { get; set; }
        public bool FacturaActiva { get; set; }
    }


    public class cSubEmpresa
    {
        public string SubEmpresaId { get; set; }
        public string ClaveSubEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string NombreCorto { get; set; }
        public string RFC { get; set; }
        public string Pais { get; set; }
        public string Region { get; set; }
        public string Localidad { get; set; }
        public string ReferenciaDom { get; set; }
        public string Ciudad { get; set; }
        public string Colonia { get; set; }
        public List<cFactura> Factura { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string BaseImg { get; set; }
        public string NumeroInterior { get; set; }
        public string CodigoPostal { get; set; }
        public byte[] Logotipo { get; set; }
        public string Telefono { get; set; }
        public string TipoEstado { get; set; }

        public void SetImagenBase64()
        {
            BaseImg = Convert.ToBase64String(Logotipo);
        }

    }

    public partial class ValorReferencia {
        public static string ObtenerDescripcion(string VARCodigo, string VAVClave, string lenguaje) {            
            try
            {
                RouteEntities db = new RouteEntities();
                VAVDescripcion vad = db.VAVDescripcion.ToList().First(x => x.VARCodigo == VARCodigo && x.VAVClave == VAVClave && x.VADTipoLenguaje == lenguaje);
                return vad.Descripcion;
            }
            catch (Exception e) {
                return "No se encontró el valor " + VARCodigo + '-' + VAVClave;
            }            
        }
    }

    public partial class Mensaje {
        public static string ObtenerDescripcion(string MENClave, string MEDTipoLenguaje)
        {
            try
            {
                RouteEntities db = new RouteEntities();
                MENDetalle det = db.MENDetalle.ToList().First(x => x.MENClave == MENClave && x.MEDTipoLenguaje == MEDTipoLenguaje);
                return det.Descripcion;
            }
            catch (Exception)
            {
                return "No se encontró el mensaje " + MENClave;
            }

        }
    }
    /**Lista de objetos para mostrar los valores por referencia*/
    public class cValores
    {
        public string VAVClave {get; set;}
        public string Descripcion {get; set;}
        public string VARCodigo { get; set; }
    }
    /***/
    public class cFactura
    {
        public string SubEmpresaId { get; set; }
        public string ClienteClave { get; set; }
        public bool ComprobanteDig { get; set; }
        public string FormatoFactura { get; set; }
        public short FormatoNC { get; set; }
        public bool FoliosTerminal { get; set; }
        public string DirRepMensual { get; set; }
        public string DirDocXML { get; set; }
        public string DirArchivosFacElec { get; set; }
        public string ContrasenaClave { get; set; }
        public string ArchivoPEM { get; set; }
        public string CerBase64 { get; set; }
        public string VersionCFD { get; set; }
        public string ProveedorTimbre { get; set; }
        public string CustomerId { get; set; }
        public string CustomerKey { get; set; }
        public string ServidorTimbre { get; set; }
        public string ServidorCancelacion { get; set; }

    }
    public class cEsquema{
        public string EsquemaID { get; set; }
        public List<cEsquema> Hijos { get; set; }
        public string EsquemaIDPadre { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public int Orden { get; set; }
        public string Clave { get; set; }
        public short Tipo { get; set; }
        public Nullable<short> Clasificacion { get; set; }
        public Nullable<double> PorCambiosCaduco { get; set; }
        public short TipoEstado { get; set; }
        public bool Baja { get; set; }
        public string NivelHijo { get; set; }
        public List<cEsquema> children { get; set; }
        public Nullable<short> Nivel { get; set; }
        public System.DateTime MFechaHora { get; set; }
        public string MUsuarioID { get; set; }
        public List<cEsquema> esquemas { get; set; }

    }

    public class cProductoUnidad
    {

        public string ProductoClave { get; set; }
        public string PRUTipoUnidad { get; set; }
        public string CodigoBarras { get; set; }
        public Nullable<double> KgLts { get; set; }
        public Nullable<double> Volumen { get; set; }
        public Nullable<double> PorcentajeVariacion { get; set; }
        public short DecimalProducto { get; set; }
        public string TipoEstado { get; set; }
        public int ValorPuntos { get; set; }
        public string Contenedor { get; set; }
        public List<cProductoDetalle> ProductoDetalle { get; set; }
    }
    public class cProductoDetalle
    {
        public string ProductoClave { get; set; }
        public short PRUTipoUnidad { get; set; }
        public string ProductoDetClave { get; set; }
        public string NombreProducto { get; set; }
        public bool Prestamo { get; set; }
        public double Factor { get; set; }

    }
    public class cReportHeader
    {
        public string display { get; set; }
        public string value { get; set; }
    }
    public partial class Esquema
    {
        public string NombrePadre { get; set; }
    }
    public class EsquemaDisponible
    {
        public bool Disponible { get; set; }
        public string Nombre { get; set; }
    }

    public partial class Configuracion
    {   
        public string LogotipoBase64 { get; set; }
    }    

    public partial class Secuencia
    {
        public bool Seleccionado { get; set; }
    }

    public class ModulosMensaje {
        public string MDBMensajeID;
        public string Modulos;

        //public ModulosMensaje(string sMDBMensajeID, string sModulos) {
        //    MDBMensajeID = sMDBMensajeID;
        //    Modulos = sModulos;
        //}
    }

    public class VistaClienteMensaje
    {
        public bool Seleccionado;
        public string MDBMensajeID;
        public int Numero;
        public string Asunto;
        public string TipoMensaje;
        public string Descripcion;
        public string TipoEstado;
        public string Modulos;
        public bool Nuevo;
    }

    public partial class ModuloMensaje
    {
        public bool Seleccionado { get; set; }
    }

    public partial class CLIConfNumCta
    {
        public bool Seleccionado { get; set; }
    }

    
}