namespace eRoute
{
    partial class R140VentaMensual
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R140VentaMensual));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.lbTotalSum = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.parameterCedis = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterFechaFin = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterFechaInicio = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterRutas = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterVendedor = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterKg = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.paramFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.paramRutaVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.paramCedis = new DevExpress.XtraReports.UI.XRLabel();
            this.lbRutaVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCedis = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.lbAsesor = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.lbDescuenos = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.lbRazonSocial = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClave = new DevExpress.XtraReports.UI.XRLabel();
            this.Total = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.xrLabel4});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 25.00001F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW140VentaMensualCliente.Total", "{0:$0.00}")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(573.5422F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(99.70807F, 23F);
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW140VentaMensualCliente.Descuento", "{0:$0.00}")});
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(485.2091F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(88.29138F, 23F);
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW140VentaMensualCliente.RazonSocial")});
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(100.125F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(262.3758F, 23F);
            this.xrLabel3.Text = "xrLabel3";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW140VentaMensualCliente.Asesor")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(686.2501F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(76.74994F, 23F);
            this.xrLabel2.Text = "xrLabel2";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW140VentaMensualCliente.Clave")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0.08335114F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(99.95833F, 23F);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW140VentaMensualCliente.TotalVta", "{0:$0.00}")});
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(362.5008F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(122.7083F, 23F);
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 38.58334F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 59.12501F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(56.4167F, 9.999974F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(381.4167F, 9.999974F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "eRouteConnection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "stpr_RW140VentaMensualCliente";
            queryParameter1.Name = "@filtroCEDIS";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterCedis]", typeof(string));
            queryParameter2.Name = "@filtroFechaInicio";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterFechaInicio]", typeof(string));
            queryParameter3.Name = "@filtroFechaFin";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterFechaFin]", typeof(string));
            queryParameter4.Name = "@filtroRutas";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterRutas]", typeof(string));
            queryParameter5.Name = "@filtroVendedor";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterVendedor]", typeof(string));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.StoredProcName = "stpr_RW140VentaMensualCliente";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbTotalSum,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrSubreport1});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 100F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // lbTotalSum
            // 
            this.lbTotalSum.CanGrow = false;
            this.lbTotalSum.Dpi = 100F;
            this.lbTotalSum.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotalSum.LocationFloat = new DevExpress.Utils.PointFloat(285.4592F, 0F);
            this.lbTotalSum.Name = "lbTotalSum";
            this.lbTotalSum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalSum.SizeF = new System.Drawing.SizeF(77.0416F, 23F);
            this.lbTotalSum.StylePriority.UseFont = false;
            this.lbTotalSum.StylePriority.UseTextAlignment = false;
            this.lbTotalSum.Text = "Total";
            this.lbTotalSum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW140VentaMensualCliente.Total")});
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(573.5005F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(99.74976F, 23F);
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:$0.00}";
            xrSummary1.IgnoreNullValues = true;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel9.Summary = xrSummary1;
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW140VentaMensualCliente.Descuento")});
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(485.2091F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(88.29138F, 23F);
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:$0.00}";
            xrSummary2.IgnoreNullValues = true;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel8.Summary = xrSummary2;
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW140VentaMensualCliente.TotalVta")});
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(362.5008F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(122.7083F, 23F);
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:$0.00}";
            xrSummary3.IgnoreNullValues = true;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel7.Summary = xrSummary3;
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrSubreport1
            // 
            this.xrSubreport1.Dpi = 100F;
            this.xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 48.87498F);
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterCedis", this.parameterCedis));
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFechaFin", this.parameterFechaFin));
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFechaInicio", this.parameterFechaInicio));
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterRutas", this.parameterRutas));
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedor", this.parameterVendedor));
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterKg", this.parameterKg));
            this.xrSubreport1.ReportSource = new eRoute.R140VentaMensualAsesor();
            this.xrSubreport1.SizeF = new System.Drawing.SizeF(694.4167F, 51.125F);
            // 
            // parameterCedis
            // 
            this.parameterCedis.Description = "parameterCedis";
            this.parameterCedis.Name = "parameterCedis";
            this.parameterCedis.Visible = false;
            // 
            // parameterFechaFin
            // 
            this.parameterFechaFin.Description = "parameterFechaFin";
            this.parameterFechaFin.Name = "parameterFechaFin";
            this.parameterFechaFin.Visible = false;
            // 
            // parameterFechaInicio
            // 
            this.parameterFechaInicio.Description = "parameterFechaInicio";
            this.parameterFechaInicio.Name = "parameterFechaInicio";
            this.parameterFechaInicio.Visible = false;
            // 
            // parameterRutas
            // 
            this.parameterRutas.Description = "parameterRutas";
            this.parameterRutas.Name = "parameterRutas";
            this.parameterRutas.Visible = false;
            // 
            // parameterVendedor
            // 
            this.parameterVendedor.Description = "parameterVendedor";
            this.parameterVendedor.Name = "parameterVendedor";
            this.parameterVendedor.Visible = false;
            // 
            // parameterKg
            // 
            this.parameterKg.Description = "parameterKg";
            this.parameterKg.Name = "parameterKg";
            this.parameterKg.Type = typeof(bool);
            this.parameterKg.ValueInfo = "False";
            this.parameterKg.Visible = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.paramFecha,
            this.paramRutaVendedor,
            this.paramCedis,
            this.lbRutaVendedor,
            this.lbCedis,
            this.lbFecha,
            this.reporte,
            this.logo,
            this.empresa});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 163.5417F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // paramFecha
            // 
            this.paramFecha.CanGrow = false;
            this.paramFecha.Dpi = 100F;
            this.paramFecha.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.paramFecha.LocationFloat = new DevExpress.Utils.PointFloat(104.1668F, 123.4375F);
            this.paramFecha.Name = "paramFecha";
            this.paramFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.paramFecha.SizeF = new System.Drawing.SizeF(645.8332F, 15F);
            this.paramFecha.StylePriority.UseFont = false;
            this.paramFecha.StylePriority.UseTextAlignment = false;
            this.paramFecha.Text = "paramFecha";
            this.paramFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // paramRutaVendedor
            // 
            this.paramRutaVendedor.CanGrow = false;
            this.paramRutaVendedor.Dpi = 100F;
            this.paramRutaVendedor.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.paramRutaVendedor.LocationFloat = new DevExpress.Utils.PointFloat(104.1668F, 138.4375F);
            this.paramRutaVendedor.Name = "paramRutaVendedor";
            this.paramRutaVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.paramRutaVendedor.SizeF = new System.Drawing.SizeF(645.8332F, 15F);
            this.paramRutaVendedor.StylePriority.UseFont = false;
            this.paramRutaVendedor.StylePriority.UseTextAlignment = false;
            this.paramRutaVendedor.Text = "paramRutaVendedor";
            this.paramRutaVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // paramCedis
            // 
            this.paramCedis.CanGrow = false;
            this.paramCedis.Dpi = 100F;
            this.paramCedis.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.paramCedis.LocationFloat = new DevExpress.Utils.PointFloat(104.1668F, 108.4375F);
            this.paramCedis.Name = "paramCedis";
            this.paramCedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.paramCedis.SizeF = new System.Drawing.SizeF(645.8332F, 15F);
            this.paramCedis.StylePriority.UseFont = false;
            this.paramCedis.StylePriority.UseTextAlignment = false;
            this.paramCedis.Text = "paramCedis";
            this.paramCedis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbRutaVendedor
            // 
            this.lbRutaVendedor.CanGrow = false;
            this.lbRutaVendedor.Dpi = 100F;
            this.lbRutaVendedor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbRutaVendedor.LocationFloat = new DevExpress.Utils.PointFloat(0.2084414F, 138.4375F);
            this.lbRutaVendedor.Name = "lbRutaVendedor";
            this.lbRutaVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbRutaVendedor.SizeF = new System.Drawing.SizeF(103.9584F, 15F);
            this.lbRutaVendedor.StylePriority.UseFont = false;
            this.lbRutaVendedor.StylePriority.UseTextAlignment = false;
            this.lbRutaVendedor.Text = "Ruta/Vendedor:";
            this.lbRutaVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbCedis
            // 
            this.lbCedis.CanGrow = false;
            this.lbCedis.Dpi = 100F;
            this.lbCedis.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbCedis.LocationFloat = new DevExpress.Utils.PointFloat(0.2084414F, 108.4375F);
            this.lbCedis.Name = "lbCedis";
            this.lbCedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCedis.SizeF = new System.Drawing.SizeF(103.9584F, 15F);
            this.lbCedis.StylePriority.UseFont = false;
            this.lbCedis.StylePriority.UseTextAlignment = false;
            this.lbCedis.Text = "CEDI:";
            this.lbCedis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbFecha
            // 
            this.lbFecha.CanGrow = false;
            this.lbFecha.Dpi = 100F;
            this.lbFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbFecha.LocationFloat = new DevExpress.Utils.PointFloat(0.2084414F, 123.4375F);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFecha.SizeF = new System.Drawing.SizeF(103.9584F, 15F);
            this.lbFecha.StylePriority.UseFont = false;
            this.lbFecha.StylePriority.UseTextAlignment = false;
            this.lbFecha.Text = "Fecha:";
            this.lbFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // reporte
            // 
            this.reporte.CanGrow = false;
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(150.1668F, 0F);
            this.reporte.Name = "reporte";
            this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.reporte.SizeF = new System.Drawing.SizeF(622.8332F, 40F);
            this.reporte.StylePriority.UseFont = false;
            this.reporte.StylePriority.UseTextAlignment = false;
            this.reporte.Text = "reporte";
            this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(0.04167557F, 0F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150.1251F, 80F);
            // 
            // empresa
            // 
            this.empresa.CanGrow = false;
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(0.1667023F, 79.99998F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(749.8333F, 23.54168F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbAsesor,
            this.lbTotal,
            this.lbDescuenos,
            this.lbTotalVenta,
            this.lbRazonSocial,
            this.lbClave});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 53.125F;
            this.PageHeader.Name = "PageHeader";
            // 
            // lbAsesor
            // 
            this.lbAsesor.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbAsesor.Dpi = 100F;
            this.lbAsesor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbAsesor.LocationFloat = new DevExpress.Utils.PointFloat(673.2502F, 0F);
            this.lbAsesor.Name = "lbAsesor";
            this.lbAsesor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbAsesor.SizeF = new System.Drawing.SizeF(99.74979F, 46.875F);
            this.lbAsesor.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            this.lbAsesor.StylePriority.UseBorders = false;
            this.lbAsesor.StylePriority.UseFont = false;
            this.lbAsesor.StylePriority.UseTextAlignment = false;
            this.lbAsesor.Text = "Numero de Asesor de Ventas";
            this.lbAsesor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbTotal
            // 
            this.lbTotal.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbTotal.Dpi = 100F;
            this.lbTotal.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotal.LocationFloat = new DevExpress.Utils.PointFloat(573.5005F, 0F);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotal.SizeF = new System.Drawing.SizeF(99.74979F, 46.875F);
            this.lbTotal.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            this.lbTotal.StylePriority.UseBorders = false;
            this.lbTotal.StylePriority.UseFont = false;
            this.lbTotal.StylePriority.UseTextAlignment = false;
            this.lbTotal.Text = "Total (Despues de descuentos)";
            this.lbTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbDescuenos
            // 
            this.lbDescuenos.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbDescuenos.Dpi = 100F;
            this.lbDescuenos.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbDescuenos.LocationFloat = new DevExpress.Utils.PointFloat(485.2091F, 0F);
            this.lbDescuenos.Name = "lbDescuenos";
            this.lbDescuenos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbDescuenos.SizeF = new System.Drawing.SizeF(88.29138F, 46.875F);
            this.lbDescuenos.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            this.lbDescuenos.StylePriority.UseBorders = false;
            this.lbDescuenos.StylePriority.UseFont = false;
            this.lbDescuenos.StylePriority.UseTextAlignment = false;
            this.lbDescuenos.Text = "Descuentos Aplicados";
            this.lbDescuenos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbTotalVenta
            // 
            this.lbTotalVenta.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbTotalVenta.Dpi = 100F;
            this.lbTotalVenta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotalVenta.LocationFloat = new DevExpress.Utils.PointFloat(362.5008F, 0F);
            this.lbTotalVenta.Name = "lbTotalVenta";
            this.lbTotalVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalVenta.SizeF = new System.Drawing.SizeF(122.7083F, 46.875F);
            this.lbTotalVenta.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            this.lbTotalVenta.StylePriority.UseBorders = false;
            this.lbTotalVenta.StylePriority.UseFont = false;
            this.lbTotalVenta.StylePriority.UseTextAlignment = false;
            this.lbTotalVenta.Text = "Total de Ventas (Precios de Lista)";
            this.lbTotalVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbRazonSocial
            // 
            this.lbRazonSocial.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbRazonSocial.Dpi = 100F;
            this.lbRazonSocial.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbRazonSocial.LocationFloat = new DevExpress.Utils.PointFloat(100.125F, 0F);
            this.lbRazonSocial.Name = "lbRazonSocial";
            this.lbRazonSocial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbRazonSocial.SizeF = new System.Drawing.SizeF(262.3758F, 46.875F);
            this.lbRazonSocial.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            this.lbRazonSocial.StylePriority.UseBorders = false;
            this.lbRazonSocial.StylePriority.UseFont = false;
            this.lbRazonSocial.StylePriority.UseTextAlignment = false;
            this.lbRazonSocial.Text = "Razon Social";
            this.lbRazonSocial.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbClave
            // 
            this.lbClave.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbClave.Dpi = 100F;
            this.lbClave.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbClave.LocationFloat = new DevExpress.Utils.PointFloat(0.08335114F, 0F);
            this.lbClave.Name = "lbClave";
            this.lbClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClave.SizeF = new System.Drawing.SizeF(99.95833F, 46.875F);
            this.lbClave.StylePriority.UseBorders = false;
            this.lbClave.StylePriority.UseFont = false;
            this.lbClave.StylePriority.UseTextAlignment = false;
            this.lbClave.Text = "Clave";
            this.lbClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Total
            // 
            this.Total.DataMember = "stpr_RW140VentaMensualCliente";
            this.Total.Expression = "[TotalVta] - [Descuento]";
            this.Total.FieldType = DevExpress.XtraReports.UI.FieldType.Decimal;
            this.Total.Name = "Total";
            // 
            // R140VentaMensual
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader,
            this.PageHeader});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.Total});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_RW140VentaMensualCliente";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(39, 38, 39, 59);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterCedis,
            this.parameterRutas,
            this.parameterVendedor,
            this.parameterFechaInicio,
            this.parameterFechaFin,
            this.parameterKg});
            this.Version = "16.1";
            this.DataSourceDemanded += new System.EventHandler<System.EventArgs>(this.R140VentaMensual_DataSourceDemanded);
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.R140VentaMensual_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }


        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.Parameters.Parameter parameterCedis;
        private DevExpress.XtraReports.Parameters.Parameter parameterRutas;
        private DevExpress.XtraReports.Parameters.Parameter parameterVendedor;
        private DevExpress.XtraReports.Parameters.Parameter parameterFechaInicio;
        private DevExpress.XtraReports.Parameters.Parameter parameterFechaFin;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreport1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRPictureBox logo;
        private DevExpress.XtraReports.UI.XRLabel empresa;
        private DevExpress.XtraReports.UI.XRLabel reporte;
        public DevExpress.XtraReports.UI.XRLabel lbCedis;
        public DevExpress.XtraReports.UI.XRLabel lbFecha;
        public DevExpress.XtraReports.UI.XRLabel lbRutaVendedor;
        public DevExpress.XtraReports.UI.XRLabel paramFecha;
        public DevExpress.XtraReports.UI.XRLabel paramRutaVendedor;
        public DevExpress.XtraReports.UI.XRLabel paramCedis;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        public DevExpress.XtraReports.UI.XRLabel lbAsesor;
        public DevExpress.XtraReports.UI.XRLabel lbTotal;
        public DevExpress.XtraReports.UI.XRLabel lbDescuenos;
        public DevExpress.XtraReports.UI.XRLabel lbTotalVenta;
        public DevExpress.XtraReports.UI.XRLabel lbRazonSocial;
        public DevExpress.XtraReports.UI.XRLabel lbClave;
        private DevExpress.XtraReports.UI.CalculatedField Total;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        public DevExpress.XtraReports.UI.XRLabel lbTotalSum;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.Parameters.Parameter parameterKg;
    }
}
