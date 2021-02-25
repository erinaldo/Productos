using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using DevExpress.XtraReports.UI;
using eRoute.Models;

namespace eRoute
{
    public partial class R043FacturacionElectronica : DevExpress.XtraReports.UI.XtraReport
    {
        private string Cedis;
        private DateTime FechaInicial;
        private DateTime FechaFinal;
        private string Vendedor;
        private string NombreVendedor;
        private string NombreCEDIS;
        private string NombreReporte;
        private string NombreEmpresa;
        private MemoryStream LogoEmpresa;

        public R043FacturacionElectronica()
        {
            //InitializeComponent();
        }

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreCEDIS, string Cedis, string TipoFecha, string FechaInicial, string FechaFinal, string Vendedor)
        {
            this.Cedis = Cedis;
            this.FechaInicial = DateTime.Parse(FechaInicial);
            if (TipoFecha.Equals("Igual"))
                this.FechaFinal = DateTime.Parse(FechaInicial);
            else
                this.FechaFinal = DateTime.Parse(FechaFinal);
            this.Vendedor = Vendedor;
            this.NombreVendedor = NombreVendedor;
            this.NombreCEDIS = NombreCEDIS;
            this.NombreReporte = NombreReporte;
            this.NombreEmpresa = NombreEmpresa;
            this.LogoEmpresa = LogoEmpresa;

            InitializeComponent();
            return this;
        }

        private void R043FacturacionElectronica_DataSourceDemanded(object sender, EventArgs e)
        {
            this.Parameters["parameterCedis"].Value = this.Cedis;
            this.Parameters["parameterVendedores"].Value = this.Vendedor;
            this.Parameters["parameterFechaInicio"].Value = this.FechaInicial.Date.ToString("s");
            this.Parameters["parameterFechaFin"].Value = this.FechaFinal.Date.ToString("s");
        }

        private void R043FacturacionElectronica_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.empresa.Text = this.NombreEmpresa;
            this.reporte.Text = this.NombreReporte;
            this.logo.Image = Image.FromStream(this.LogoEmpresa);
            this.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.lbCedis.Text = Mensaje.ObtenerDescripcion("XCEDI", "EM");
            this.paramCedis.Text = this.NombreCEDIS;
            this.lbFecha.Text = Mensaje.ObtenerDescripcion("XFecha", "EM");
            this.paramFecha.Text = this.FechaInicial.Date.ToString("dd-MM-yyyy") + (this.FechaInicial == this.FechaFinal ? "" : " - " + this.FechaFinal.Date.ToString("dd-MM-yyyy"));
            this.lbVendedor.Text = Mensaje.ObtenerDescripcion("XVendedor", "EM");
            //this.paramVendedores.Text = this.Vendedor != "" ? this.NombreVendedor : Mensaje.ObtenerDescripcion("XTodosVendedores", "EM");
            this.lbFechaH.Text = Mensaje.ObtenerDescripcion("XFecha", "EM");
            this.lbSerie.Text = Mensaje.ObtenerDescripcion("FOSSerie", "EM");
            this.lbFolio.Text = Mensaje.ObtenerDescripcion("XFolio", "EM");
            this.lbCliente.Text = Mensaje.ObtenerDescripcion("XCliente", "EM");
            this.lbRFC.Text = Mensaje.ObtenerDescripcion("CLDRFC", "EM");
            this.lbNoCertificado.Text = Mensaje.ObtenerDescripcion("XNoCertificado", "EM");
            this.lbAnioAprobacion.Text = Mensaje.ObtenerDescripcion("XAnioAprobacion", "EM");
            this.lbAprobacion.Text = Mensaje.ObtenerDescripcion("XAprobacion", "EM");
            this.lbFase.Text = Mensaje.ObtenerDescripcion("TRPTipoFase", "EM");
            this.lbMotivo.Text = Mensaje.ObtenerDescripcion("TRPTipoMotivo", "EM");
            this.lbTotal.Text = Mensaje.ObtenerDescripcion("XTotal", "EM");
            this.lbTotalFecha.Text = Mensaje.ObtenerDescripcion("XTotalSolicitudesFecha", "EM");
            this.lbTotalVendedor.Text = Mensaje.ObtenerDescripcion("XTotalSolicitudesVendedor", "EM");
            this.lbGranTotal.Text = Mensaje.ObtenerDescripcion("XGRANTOTAL", "EM");
        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
