namespace eRoute
{
    partial class R140VentaMensualAsesor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R140VentaMensualAsesor));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.ocultarKG = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.parameterCedis = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterFechaFin = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterFechaInicio = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterRutas = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterVendedor = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lbAsesor = new DevExpress.XtraReports.UI.XRLabel();
            this.lbNombreAsesor = new DevExpress.XtraReports.UI.XRLabel();
            this.lbKilogramos = new DevExpress.XtraReports.UI.XRLabel();
            this.lbImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.Importe = new DevExpress.XtraReports.UI.CalculatedField();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalSum = new DevExpress.XtraReports.UI.XRLabel();
            this.parameterKg = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.R140VentaMensualAsesor_BeforePrint);
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW140VentaMensualAsesor.Importe", "{0:$0.00}")});
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(540F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW140VentaMensualAsesor.Kglts", "{0:#.00}")});
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.FormattingRules.Add(this.ocultarKG);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(440F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // ocultarKG
            // 
            this.ocultarKG.Condition = "[Parameters.parameterKg] == False";
            // 
            // 
            // 
            this.ocultarKG.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.ocultarKG.Name = "ocultarKG";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW140VentaMensualAsesor.Nombre")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(100F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(340F, 23F);
            this.xrLabel2.Text = "xrLabel2";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW140VentaMensualAsesor.Asesor")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 2.083333F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "eRouteConnection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "stpr_RW140VentaMensualAsesor";
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
            storedProcQuery1.StoredProcName = "stpr_RW140VentaMensualAsesor";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // parameterCedis
            // 
            this.parameterCedis.Description = "parameterCedis";
            this.parameterCedis.Name = "parameterCedis";
            // 
            // parameterFechaFin
            // 
            this.parameterFechaFin.Description = "parameterFechaFin";
            this.parameterFechaFin.Name = "parameterFechaFin";
            // 
            // parameterFechaInicio
            // 
            this.parameterFechaInicio.Description = "parameterFechaInicio";
            this.parameterFechaInicio.Name = "parameterFechaInicio";
            // 
            // parameterRutas
            // 
            this.parameterRutas.Description = "parameterRutas";
            this.parameterRutas.Name = "parameterRutas";
            // 
            // parameterVendedor
            // 
            this.parameterVendedor.Description = "parameterVendedor";
            this.parameterVendedor.Name = "parameterVendedor";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbAsesor,
            this.lbNombreAsesor,
            this.lbKilogramos,
            this.lbImporte});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 39.58333F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lbAsesor
            // 
            this.lbAsesor.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbAsesor.Dpi = 100F;
            this.lbAsesor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbAsesor.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.lbAsesor.Name = "lbAsesor";
            this.lbAsesor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbAsesor.SizeF = new System.Drawing.SizeF(99.95833F, 27.08334F);
            this.lbAsesor.StylePriority.UseBorders = false;
            this.lbAsesor.StylePriority.UseFont = false;
            this.lbAsesor.StylePriority.UseTextAlignment = false;
            this.lbAsesor.Text = "Asesor";
            this.lbAsesor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbNombreAsesor
            // 
            this.lbNombreAsesor.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbNombreAsesor.Dpi = 100F;
            this.lbNombreAsesor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbNombreAsesor.LocationFloat = new DevExpress.Utils.PointFloat(99.95833F, 10.00001F);
            this.lbNombreAsesor.Name = "lbNombreAsesor";
            this.lbNombreAsesor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNombreAsesor.SizeF = new System.Drawing.SizeF(340.3335F, 27.08334F);
            this.lbNombreAsesor.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            this.lbNombreAsesor.StylePriority.UseBorders = false;
            this.lbNombreAsesor.StylePriority.UseFont = false;
            this.lbNombreAsesor.StylePriority.UseTextAlignment = false;
            this.lbNombreAsesor.Text = "NombreAsesor";
            this.lbNombreAsesor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbKilogramos
            // 
            this.lbKilogramos.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbKilogramos.Dpi = 100F;
            this.lbKilogramos.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbKilogramos.LocationFloat = new DevExpress.Utils.PointFloat(440.2918F, 10.00001F);
            this.lbKilogramos.Name = "lbKilogramos";
            this.lbKilogramos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbKilogramos.SizeF = new System.Drawing.SizeF(99.70819F, 27.08334F);
            this.lbKilogramos.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            this.lbKilogramos.StylePriority.UseBorders = false;
            this.lbKilogramos.StylePriority.UseFont = false;
            this.lbKilogramos.StylePriority.UseTextAlignment = false;
            this.lbKilogramos.Text = "Kilogramos";
            this.lbKilogramos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbImporte
            // 
            this.lbImporte.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbImporte.Dpi = 100F;
            this.lbImporte.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbImporte.LocationFloat = new DevExpress.Utils.PointFloat(540F, 10.00001F);
            this.lbImporte.Name = "lbImporte";
            this.lbImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbImporte.SizeF = new System.Drawing.SizeF(99.74979F, 27.08334F);
            this.lbImporte.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            this.lbImporte.StylePriority.UseBorders = false;
            this.lbImporte.StylePriority.UseFont = false;
            this.lbImporte.StylePriority.UseTextAlignment = false;
            this.lbImporte.Text = "Importe";
            this.lbImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Importe
            // 
            this.Importe.DataMember = "stpr_RW140VentaMensualAsesor";
            this.Importe.Expression = "[TotalVta] - [Descuento]";
            this.Importe.Name = "Importe";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.lbTotalSum});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 34.375F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW140VentaMensualAsesor.Importe")});
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(539.4579F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(100.2919F, 23F);
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:$0.00}";
            xrSummary1.IgnoreNullValues = true;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel5.Summary = xrSummary1;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbTotalSum
            // 
            this.lbTotalSum.CanGrow = false;
            this.lbTotalSum.Dpi = 100F;
            this.lbTotalSum.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotalSum.LocationFloat = new DevExpress.Utils.PointFloat(390.8331F, 0F);
            this.lbTotalSum.Name = "lbTotalSum";
            this.lbTotalSum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalSum.SizeF = new System.Drawing.SizeF(148.6248F, 23F);
            this.lbTotalSum.StylePriority.UseFont = false;
            this.lbTotalSum.StylePriority.UseTextAlignment = false;
            this.lbTotalSum.Text = "Total";
            this.lbTotalSum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // parameterKg
            // 
            this.parameterKg.Description = "parameterKg";
            this.parameterKg.Name = "parameterKg";
            this.parameterKg.Type = typeof(bool);
            this.parameterKg.ValueInfo = "False";
            // 
            // R140VentaMensualAsesor
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.Importe});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_RW140VentaMensualAsesor";
            this.DataSource = this.sqlDataSource1;
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.ocultarKG});
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 0, 2);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterCedis,
            this.parameterFechaFin,
            this.parameterFechaInicio,
            this.parameterRutas,
            this.parameterVendedor,
            this.parameterKg});
            this.Version = "16.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.R140VentaMensualAsesor_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.Parameters.Parameter parameterCedis;
        private DevExpress.XtraReports.Parameters.Parameter parameterFechaFin;
        private DevExpress.XtraReports.Parameters.Parameter parameterFechaInicio;
        private DevExpress.XtraReports.Parameters.Parameter parameterRutas;
        private DevExpress.XtraReports.Parameters.Parameter parameterVendedor;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        public DevExpress.XtraReports.UI.XRLabel lbAsesor;
        public DevExpress.XtraReports.UI.XRLabel lbNombreAsesor;
        public DevExpress.XtraReports.UI.XRLabel lbKilogramos;
        public DevExpress.XtraReports.UI.XRLabel lbImporte;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.CalculatedField Importe;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.FormattingRule ocultarKG;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        public DevExpress.XtraReports.UI.XRLabel lbTotalSum;
        private DevExpress.XtraReports.Parameters.Parameter parameterKg;
    }
}
