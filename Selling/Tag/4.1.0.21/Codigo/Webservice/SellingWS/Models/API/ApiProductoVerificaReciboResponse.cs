namespace SellingWS.Models.API
{
    /// <summary>
    /// Respuesta de Producto/VerificaRecibo.
    /// </summary>
    public class ApiProductoVerificaReciboResponse
    {
        /// <summary>Producto.Clave</summary>
        public string PROClave { get; set; }

        /// <summary>Producto.Descripcion</summary>
        public string Descripcion { get; set; }

        /// <summary>Estrategia.Area.Nombre</summary>
        public string AreaPicking { get; set; }

        /// <summary>Estrategia.Ubicacion.Ubicacion1</summary>
        public string UbicacionPicking { get; set; }
    }
}