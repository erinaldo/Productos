using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;
using eRoute.Models;

namespace eRoute
{
    public partial class R140VentaMensual : DevExpress.XtraReports.UI.XtraReport
    {
        private string Cedis;
        private DateTime FechaInicial;
        private DateTime FechaFinal;
        private string Rutas;
        private string Vendedor;
        private string NombreCEDIS;
        private string NombreReporte;
        private string NombreEmpresa;
        private MemoryStream LogoEmpresa;
        private bool ConversionKg;

        public R140VentaMensual()
        {
            //InitializeComponent();
        }

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreCEDIS, string Cedis, string TipoFecha, string FechaInicial, string FechaFinal, string Rutas, string Vendedor, bool ConversionKg)
        {
            this.Cedis = Cedis;
            this.FechaInicial = DateTime.Parse(FechaInicial);
            if (TipoFecha.Equals("Igual"))
                this.FechaFinal = DateTime.Parse(FechaInicial);
            else
                this.FechaFinal = DateTime.Parse(FechaFinal);
            this.Rutas = Rutas;
            this.Vendedor = Vendedor;
            this.NombreCEDIS = NombreCEDIS;
            this.NombreReporte = NombreReporte;
            this.NombreEmpresa = NombreEmpresa;
            this.LogoEmpresa = LogoEmpresa;
            this.ConversionKg = ConversionKg;
           // Name = string.Format("Ventas{0:yyyy'-'MM'-'dd'T'HH':'mm':'ss}.xlsx", DateTime.Now);

            InitializeComponent();
            return this;
        }

        private void R140VentaMensual_DataSourceDemanded(object sender, EventArgs e)
        {
            this.Parameters["parameterCedis"].Value = this.Cedis;
            this.Parameters["parameterRutas"].Value = this.Rutas;
            this.Parameters["parameterVendedor"].Value = this.Vendedor;
            this.Parameters["parameterFechaInicio"].Value = this.FechaInicial.Date.ToString("s");
            this.Parameters["parameterFechaFin"].Value = this.FechaFinal.Date.ToString("s");
            this.Parameters["parameterKg"].Value = this.ConversionKg;
        }

        private void R140VentaMensual_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {            
            this.empresa.Text = this.NombreEmpresa;
            this.reporte.Text = this.NombreReporte;
            this.logo.Image = Image.FromStream(this.LogoEmpresa);
            this.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.lbCedis.Text = Mensaje.ObtenerDescripcion("XCEDI", "EM");
            this.paramCedis.Text = this.NombreCEDIS;
            this.lbFecha.Text = Mensaje.ObtenerDescripcion("XFecha", "EM");
            this.paramFecha.Text = this.FechaInicial.Date.ToString("dd-MM-yyyy") + (this.FechaInicial == this.FechaFinal ? "" : " - " + this.FechaFinal.Date.ToString("dd-MM-yyyy"));
            this.lbRutaVendedor.Text = this.Vendedor != "" ? Mensaje.ObtenerDescripcion("XVendedor", "EM") : Mensaje.ObtenerDescripcion("XRutas", "EM");
            this.paramRutaVendedor.Text = this.Vendedor != "" ? this.Vendedor : (this.Rutas != "" ? this.Rutas : Mensaje.ObtenerDescripcion("XTodasRutas", "EM"));
            this.lbClave.Text = Mensaje.ObtenerDescripcion("XClave", "EM");
            this.lbRazonSocial.Text = Mensaje.ObtenerDescripcion("XDetallePorCliente", "EM");
            this.lbTotalVenta.Text = Mensaje.ObtenerDescripcion("XTotalVentas", "EM") + "(" + Mensaje.ObtenerDescripcion("XPreciosDeListas", "EM") + ")";
            this.lbDescuenos.Text = Mensaje.ObtenerDescripcion("XDescuentosAplicados", "EM");
            this.lbTotal.Text = Mensaje.ObtenerDescripcion("XTotalMin", "EM") + "(" + Mensaje.ObtenerDescripcion("XDespuesDeDescuentos", "EM") + ")";
            this.lbAsesor.Text = Mensaje.ObtenerDescripcion("XNumeroAsesorVentas", "EM");
            this.lbTotalSum.Text = Mensaje.ObtenerDescripcion("XTotal", "EM");
        }

    }
}
