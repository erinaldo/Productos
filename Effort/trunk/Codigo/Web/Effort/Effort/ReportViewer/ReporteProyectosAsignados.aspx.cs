using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Effort.Utils;

namespace Effort.ReportViewer
{
    public partial class ReporteProyectosAsignados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowReport();
            }
        }

        private void ShowReport()
        {
            try
            {
                string urlReportServer = "http://matrix/ReportServer";

                rptViewer.ProcessingMode = ProcessingMode.Remote;
                IReportServerCredentials irsc = new CustomReportCredentials("Administrador", "DomainAdmin2014*", "DX");
                rptViewer.ServerReport.ReportServerCredentials = irsc;
                rptViewer.ServerReport.ReportServerUrl = new Uri(urlReportServer);
                rptViewer.ServerReport.ReportPath = "/Effort/Reporte de proyectos asignados";
                rptViewer.ServerReport.Refresh();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}