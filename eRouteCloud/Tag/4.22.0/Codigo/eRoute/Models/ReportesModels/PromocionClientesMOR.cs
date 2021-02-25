using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using Dapper;
using System.IO;
using System.Drawing;
using System.Threading;

namespace eRoute.Models.ReportesModels
{
    public class PromocionClientesMOR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string ftPromo, string ftAlmacen, string ftRuta, string ftFecha, string ftFechaCentro, string promocion, string nombreReport,string nombreCedis, string Rutas, string FechaInicial, string FechaFinal)
        {
            try
            {

                Boolean tieneOrden = Connection.Query<string>("Select * from OrdenProductos (NOLOCK) where ReporteW = '189'", null, null, true, 9000).ToList().Count > 0;

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("Select Distinct A.Clave + '-' + A.Nombre As Agencia, R.RUTClave +'-'+R.Descripcion  AS Ruta, C.Clave, C.ClienteClave, C.RazonSocial, TRPR.PromocionClave, PM.Nombre AS Promocion, TPD.ProductoClave,P.Nombre as Producto, TPD.Cantidad, (TPD.Precio - (isnull(TRPR.PromocionImp,0) / TPD.Cantidad)) As PrecioPromocion, TPD.Precio " + (tieneOrden ? ", OP.Orden " : ""));
                sConsulta.AppendLine("From TransProd TP (NOLOCK) ");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on TP.VisitaClave = V.VisitaClave " + ftRuta);
                sConsulta.AppendLine("inner join cliente C (NOLOCK) on V.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join Ruta R (NOLOCK) on R.RUTClave = V.RUTClave ");
                sConsulta.AppendLine("inner join Almacen A (NOLOCK) on R.AlmacenId = A.AlmacenID " + ftAlmacen);
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on D.DiaClave = ISNULL(TP.DiaClave, TP.DiaClave1) " + ftFecha);
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TP.TransProdID = TPD.TransProdID and TPD.Promocion in (1,2) ");
                sConsulta.AppendLine("inner join Producto P (NOLOCK) on TPD.ProductoClave = P.ProductoClave ");
                sConsulta.AppendLine("inner join TrpPrp TRPR (NOLOCK) on TRPR.TransProdID = TP.TransProdID and TRPR.TransProdDetalleID = TPD.TransProdDetalleID ");
                sConsulta.AppendLine("inner join Promocion PM (NOLOCK) on TRPR.PromocionClave = PM.PromocionClave " + ftPromo);
                sConsulta.AppendLine((tieneOrden ? "left join OrdenProductos OP (NOLOCK) on TPD.ProductoClave = OP.ProductoClave " : ""));
                sConsulta.AppendLine((tieneOrden ? "order by OP.Orden DESC" : "order by C.Clave,  TRPR.PromocionClave, Agencia, Ruta, C.ClienteClave,C.RazonSocial, Promocion, TPD.ProductoClave, Producto, TPD.Cantidad "));

                QueryString = sConsulta.ToString();

                List<PCDatosModel> Datos = Connection.Query<PCDatosModel>(QueryString, null, null, true, 600).ToList();

                if (Datos.Count() <= 0)
                {
                    return null;
                }


                PromocionClientesMORReport report = new PromocionClientesMORReport();
                report.DataSource = Datos;

                DateTime fInicio = DateTime.Parse(FechaInicial);
                DateTime fFin = DateTime.Now;
                if (String.IsNullOrEmpty(FechaFinal) || FechaFinal == "null")
                {
                    FechaFinal = "";
                }
                else
                {
                    fFin = DateTime.Parse(FechaFinal);
                    FechaFinal = " - " + fFin.Date.ToShortDateString();
                }

                if (String.IsNullOrEmpty(Rutas) || Rutas == "null")
                {
                    Rutas = "";
                }

                string LogoQuery = "Select Logotipo from Configuracion (NOLOCK) ";


                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.xrPictureBox1.Image = Image.FromStream(mStream);
                report.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                string empresaQuery = "select NombreEmpresa from Configuracion (NOLOCK) ";
                string nombreEmpresa = Connection.Query<string>(empresaQuery, null, null, true, 9000).FirstOrDefault();

                report.EmpresaHeader.Text = nombreEmpresa;
                report.ReporteHeader.Text = nombreReport;

                report.ReporteAgencia.Text = nombreCedis;
                report.ReporteRuta.Text = Rutas;
                report.ReportePeriodo.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                report.ReportePromociones.Text = promocion;

                //GroupHeaderAgencia
                GroupField groupAgencia = new GroupField("Agencia");
                report.GHeaderAgencia.GroupFields.Add(groupAgencia);

                //GroupHeaderRuta
                GroupField groupRuta = new GroupField("Ruta");
                report.GHeaderRuta.GroupFields.Add(groupRuta);

                report.CediLabel.DataBindings.Add("Text", null, "Agencia");

                report.labelRuta.DataBindings.Add("Text", null, "Ruta");

                //detalle
                report.detalleClaveCliente.DataBindings.Add("Text", null, "ClienteClave");
                report.detalleNombreCliente.DataBindings.Add("Text", null, "RazonSocial");
                report.detalleClavePromocion.DataBindings.Add("Text", null, "PromocionClave");
                report.detalleNombrePromocion.DataBindings.Add("Text", null, "Promocion");
                report.detalleClaveProducto.DataBindings.Add("Text", null, "ProductoClave");
                report.detalleNombreProducto.DataBindings.Add("Text", null, "Producto");
                report.detalleCantidad.DataBindings.Add("Text", null, "Cantidad");
                report.detallePrecioPromocion.DataBindings.Add("Text", null, "PrecioPromocion", "{0:#,##0.00}");
                report.detallePrecioDeListas.DataBindings.Add("Text", null, "Precio", "{0:#,##0.00}");





                return report;
            }
            catch
            {
                return new ReportePuntosGPS();
            }
        }
    }

    class PCDatosModel
    {
        public string Agencia { get; set; }
        public string Ruta { get; set; }
        public string Clave { get; set; }
        public string ClienteClave { get; set; }
        public string RazonSocial { get; set; }
        public string PromocionClave { get; set; }
        public string Promocion { get; set; }
        public string ProductoClave { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public Decimal PrecioPromocion { get; set; }
        public Decimal Precio { get; set; }

    }


}