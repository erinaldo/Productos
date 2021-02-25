using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using eRoute.Models;

namespace eRoute
{
    public partial class R140VentaMensualAsesor : DevExpress.XtraReports.UI.XtraReport
    {
        public R140VentaMensualAsesor()
        {
            InitializeComponent();
        }       

        private void R140VentaMensualAsesor_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            bool ConversionKg = bool.Parse(this.Parameters["parameterKg"].Value.ToString());
            this.lbAsesor.Text = Mensaje.ObtenerDescripcion("X#AVtas", "EM");
            this.lbNombreAsesor.Text = Mensaje.ObtenerDescripcion("XNombreAVentas", "EM");
            this.lbKilogramos.Text = ConversionKg ? Mensaje.ObtenerDescripcion("XKg", "EM") : "";
            this.lbImporte.Text = Mensaje.ObtenerDescripcion("XImporte", "EM");
            this.lbTotalSum.Text = Mensaje.ObtenerDescripcion("XTotalVentas", "EM");
        }
    }
}
