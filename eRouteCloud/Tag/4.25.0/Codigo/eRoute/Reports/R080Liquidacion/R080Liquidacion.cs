using System;
using System.Drawing;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.ComponentModel;

/// <summary>
/// Summary description for R080Liquidacion
/// </summary>
public class R080Liquidacion : XtraReport
{
    private DetailBand Detail;
    private TopMarginBand TopMargin;
    private BottomMarginBand BottomMargin;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private DevExpress.XtraReports.Parameters.Parameter parameterCedis;
    private DevExpress.XtraReports.Parameters.Parameter parameterSeller;
    private DevExpress.XtraReports.Parameters.Parameter parameterStartDate;
    private ReportHeaderBand ReportHeader;
    private XRLabel company;
    private XRLabel center;
    private XRLabel xrLabel25;
    private XRPictureBox logo;
    private XRLabel report;
    private XRLabel labelFilter;
    private XRLabel filter;
    private XRLabel date;
    private XRLabel labelDate;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private GroupFooterBand GroupFooter1;
    private XRSubreport R080LiquidacionCobranzaNoRecuperada;
    private XRSubreport R080LiquidacionCobranzaCredito;
    private XRSubreport R080LiquidacionVentasCredito;
    private XRSubreport R080LiquidacionVentasContado;
    private XRSubreport R080LiquidacionMovimientosDeProductos;
    private ReportFooterBand ReportFooter;
    private XRPanel xrPanel2;
    private XRLabel xrLabel15;
    private XRLabel TotalALiquidar;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel ImporteMovimientos;
    private XRLabel ImporteCredito;
    private XRLabel labelCobranza;
    private XRPanel xrPanel1;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private CalculatedField Efectividad;
    private CalculatedField ClientesNoVisitados;
    private XRLabel xrLabel65;
    private XRLabel xrLabel64;

    private double ventasTotales;
    private double ventascredito;
    private double cobranza;
    private double valueTemp;
    private dynamic temp;

    private string sellerFilter;
    private string sellerName;
    private string cedisFilter;
    private string cedisName;
    private string reportName;
    private string companyName;
    private MemoryStream CompanyLogo;
    private DateTime startD;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;
    private CalculatedField CobranzaTotal;
    private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);

    public XtraReport GetReport(string ReportName, string CompanyName, MemoryStream CompanyLogo, string CedisName, string Cedis, string SellerName, string Seller, string StartDate)
    {
        startD = DateTime.Parse(StartDate);
        cedisFilter = Cedis;
        cedisName = CedisName;
        sellerFilter = Seller;
        sellerName = SellerName;
        reportName = ReportName;
        companyName = CompanyName;
        this.CompanyLogo = CompanyLogo;
        if (CountRows() > 0)
        {
            InitializeComponent();
            return this;
        }
        else
        {
            return null;
        }
    }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R080Liquidacion));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.parameterCedis = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterSeller = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterStartDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.company = new DevExpress.XtraReports.UI.XRLabel();
            this.center = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.report = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFilter = new DevExpress.XtraReports.UI.XRLabel();
            this.filter = new DevExpress.XtraReports.UI.XRLabel();
            this.date = new DevExpress.XtraReports.UI.XRLabel();
            this.labelDate = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.R080LiquidacionCobranzaNoRecuperada = new DevExpress.XtraReports.UI.XRSubreport();
            this.R080LiquidacionCobranzaCredito = new DevExpress.XtraReports.UI.XRSubreport();
            this.R080LiquidacionVentasCredito = new DevExpress.XtraReports.UI.XRSubreport();
            this.R080LiquidacionVentasContado = new DevExpress.XtraReports.UI.XRSubreport();
            this.R080LiquidacionMovimientosDeProductos = new DevExpress.XtraReports.UI.XRSubreport();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel65 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel64 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel2 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalALiquidar = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.ImporteMovimientos = new DevExpress.XtraReports.UI.XRLabel();
            this.ImporteCredito = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCobranza = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Efectividad = new DevExpress.XtraReports.UI.CalculatedField();
            this.ClientesNoVisitados = new DevExpress.XtraReports.UI.CalculatedField();
            this.CobranzaTotal = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 5F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 5F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "eRouteConnection";
            this.sqlDataSource1.ConnectionOptions.CommandTimeout = 5000;
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "stpr_RW080Liquidacion";
            queryParameter1.Name = "@filterCEDIS";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterCedis]", typeof(string));
            queryParameter2.Name = "@filterSeller";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterSeller]", typeof(string));
            queryParameter3.Name = "@filterStartDate";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterStartDate]", typeof(string));
            queryParameter4.Name = "@filterQueryNumber";
            queryParameter4.Type = typeof(int);
            queryParameter4.ValueInfo = "1";
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.StoredProcName = "stpr_RW080Liquidacion";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // parameterCedis
            // 
            this.parameterCedis.Name = "parameterCedis";
            this.parameterCedis.ValueInfo = "3YWLUNURDJOUKAD";
            this.parameterCedis.Visible = false;
            // 
            // parameterSeller
            // 
            this.parameterSeller.Name = "parameterSeller";
            this.parameterSeller.ValueInfo = "3YWLUSPX28K5B1Q";
            this.parameterSeller.Visible = false;
            // 
            // parameterStartDate
            // 
            this.parameterStartDate.Name = "parameterStartDate";
            this.parameterStartDate.ValueInfo = "2020-01-15";
            this.parameterStartDate.Visible = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.company,
            this.center,
            this.xrLabel25,
            this.logo,
            this.report,
            this.labelFilter,
            this.filter,
            this.date,
            this.labelDate});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 135F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // company
            // 
            this.company.CanGrow = false;
            this.company.Dpi = 100F;
            this.company.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.company.LocationFloat = new DevExpress.Utils.PointFloat(147.5F, 0F);
            this.company.Name = "company";
            this.company.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.company.SizeF = new System.Drawing.SizeF(545F, 40F);
            this.company.StylePriority.UseFont = false;
            this.company.StylePriority.UseTextAlignment = false;
            this.company.Text = "company";
            this.company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // center
            // 
            this.center.CanGrow = false;
            this.center.Dpi = 100F;
            this.center.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.center.LocationFloat = new DevExpress.Utils.PointFloat(150F, 90F);
            this.center.Name = "center";
            this.center.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.center.SizeF = new System.Drawing.SizeF(690F, 15F);
            this.center.StylePriority.UseFont = false;
            this.center.StylePriority.UseTextAlignment = false;
            this.center.Text = "center";
            this.center.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel25
            // 
            this.xrLabel25.CanGrow = false;
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(0F, 90F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "Centro De Distribucion:";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(7.5F, 0F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(140F, 80F);
            // 
            // report
            // 
            this.report.CanGrow = false;
            this.report.Dpi = 100F;
            this.report.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.report.LocationFloat = new DevExpress.Utils.PointFloat(147.5F, 40F);
            this.report.Name = "report";
            this.report.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.report.SizeF = new System.Drawing.SizeF(545F, 40F);
            this.report.StylePriority.UseFont = false;
            this.report.StylePriority.UseTextAlignment = false;
            this.report.Text = "report";
            this.report.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // labelFilter
            // 
            this.labelFilter.CanGrow = false;
            this.labelFilter.Dpi = 100F;
            this.labelFilter.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelFilter.LocationFloat = new DevExpress.Utils.PointFloat(0F, 105F);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFilter.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelFilter.StylePriority.UseFont = false;
            this.labelFilter.StylePriority.UseTextAlignment = false;
            this.labelFilter.Text = "labelFilter";
            this.labelFilter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // filter
            // 
            this.filter.CanGrow = false;
            this.filter.Dpi = 100F;
            this.filter.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.filter.LocationFloat = new DevExpress.Utils.PointFloat(150F, 105F);
            this.filter.Name = "filter";
            this.filter.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.filter.SizeF = new System.Drawing.SizeF(690F, 15F);
            this.filter.StylePriority.UseFont = false;
            this.filter.StylePriority.UseTextAlignment = false;
            this.filter.Text = "filter";
            this.filter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // date
            // 
            this.date.CanGrow = false;
            this.date.Dpi = 100F;
            this.date.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.date.LocationFloat = new DevExpress.Utils.PointFloat(150F, 120F);
            this.date.Name = "date";
            this.date.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.date.SizeF = new System.Drawing.SizeF(690F, 15F);
            this.date.StylePriority.UseFont = false;
            this.date.StylePriority.UseTextAlignment = false;
            this.date.Text = "date";
            this.date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelDate
            // 
            this.labelDate.CanGrow = false;
            this.labelDate.Dpi = 100F;
            this.labelDate.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelDate.LocationFloat = new DevExpress.Utils.PointFloat(0F, 120F);
            this.labelDate.Name = "labelDate";
            this.labelDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelDate.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelDate.StylePriority.UseFont = false;
            this.labelDate.StylePriority.UseTextAlignment = false;
            this.labelDate.Text = "Fecha:";
            this.labelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 15F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(200F, 15F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(740F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.R080LiquidacionCobranzaNoRecuperada,
            this.R080LiquidacionCobranzaCredito,
            this.R080LiquidacionVentasCredito,
            this.R080LiquidacionVentasContado,
            this.R080LiquidacionMovimientosDeProductos});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 190F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // R080LiquidacionCobranzaNoRecuperada
            // 
            this.R080LiquidacionCobranzaNoRecuperada.Dpi = 100F;
            this.R080LiquidacionCobranzaNoRecuperada.LocationFloat = new DevExpress.Utils.PointFloat(0F, 160F);
            this.R080LiquidacionCobranzaNoRecuperada.Name = "R080LiquidacionCobranzaNoRecuperada";
            this.R080LiquidacionCobranzaNoRecuperada.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterCedis", this.parameterCedis));
            this.R080LiquidacionCobranzaNoRecuperada.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.R080LiquidacionCobranzaNoRecuperada.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterStartDate", this.parameterStartDate));
            this.R080LiquidacionCobranzaNoRecuperada.ReportSource = new R080LiquidacionCobranzaNoRecuperada();
            this.R080LiquidacionCobranzaNoRecuperada.SizeF = new System.Drawing.SizeF(840F, 30F);
            // 
            // R080LiquidacionCobranzaCredito
            // 
            this.R080LiquidacionCobranzaCredito.Dpi = 100F;
            this.R080LiquidacionCobranzaCredito.LocationFloat = new DevExpress.Utils.PointFloat(0F, 120F);
            this.R080LiquidacionCobranzaCredito.Name = "R080LiquidacionCobranzaCredito";
            this.R080LiquidacionCobranzaCredito.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterCedis", this.parameterCedis));
            this.R080LiquidacionCobranzaCredito.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.R080LiquidacionCobranzaCredito.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterStartDate", this.parameterStartDate));
            this.R080LiquidacionCobranzaCredito.ReportSource = new R080LiquidacionCobranzaCredito();
            this.R080LiquidacionCobranzaCredito.SizeF = new System.Drawing.SizeF(840F, 30F);
            // 
            // R080LiquidacionVentasCredito
            // 
            this.R080LiquidacionVentasCredito.Dpi = 100F;
            this.R080LiquidacionVentasCredito.LocationFloat = new DevExpress.Utils.PointFloat(0F, 80F);
            this.R080LiquidacionVentasCredito.Name = "R080LiquidacionVentasCredito";
            this.R080LiquidacionVentasCredito.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterCedis", this.parameterCedis));
            this.R080LiquidacionVentasCredito.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.R080LiquidacionVentasCredito.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterStartDate", this.parameterStartDate));
            this.R080LiquidacionVentasCredito.ReportSource = new R080LiquidacionVentasCredito();
            this.R080LiquidacionVentasCredito.SizeF = new System.Drawing.SizeF(840F, 30F);
            // 
            // R080LiquidacionVentasContado
            // 
            this.R080LiquidacionVentasContado.Dpi = 100F;
            this.R080LiquidacionVentasContado.LocationFloat = new DevExpress.Utils.PointFloat(0F, 40F);
            this.R080LiquidacionVentasContado.Name = "R080LiquidacionVentasContado";
            this.R080LiquidacionVentasContado.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterCedis", this.parameterCedis));
            this.R080LiquidacionVentasContado.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.R080LiquidacionVentasContado.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterStartDate", this.parameterStartDate));
            this.R080LiquidacionVentasContado.ReportSource = new R080LiquidacionVentasContado();
            this.R080LiquidacionVentasContado.SizeF = new System.Drawing.SizeF(840F, 30F);
            // 
            // R080LiquidacionMovimientosDeProductos
            // 
            this.R080LiquidacionMovimientosDeProductos.Dpi = 100F;
            this.R080LiquidacionMovimientosDeProductos.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.R080LiquidacionMovimientosDeProductos.Name = "R080LiquidacionMovimientosDeProductos";
            this.R080LiquidacionMovimientosDeProductos.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterCedis", this.parameterCedis));
            this.R080LiquidacionMovimientosDeProductos.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.R080LiquidacionMovimientosDeProductos.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterStartDate", this.parameterStartDate));
            this.R080LiquidacionMovimientosDeProductos.ReportSource = new R080LiquidacionMovimientosDeProductos();
            this.R080LiquidacionMovimientosDeProductos.SizeF = new System.Drawing.SizeF(840F, 30F);
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel65,
            this.xrLabel64,
            this.xrPanel2,
            this.xrPanel1});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.ReportFooter.HeightF = 300F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.StylePriority.UseFont = false;
            // 
            // xrLabel65
            // 
            this.xrLabel65.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel65.BorderWidth = 2F;
            this.xrLabel65.CanGrow = false;
            this.xrLabel65.Dpi = 100F;
            this.xrLabel65.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel65.LocationFloat = new DevExpress.Utils.PointFloat(570F, 280F);
            this.xrLabel65.Name = "xrLabel65";
            this.xrLabel65.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel65.SizeF = new System.Drawing.SizeF(200F, 20F);
            this.xrLabel65.StylePriority.UseBorders = false;
            this.xrLabel65.StylePriority.UseBorderWidth = false;
            this.xrLabel65.StylePriority.UseFont = false;
            this.xrLabel65.StylePriority.UseTextAlignment = false;
            this.xrLabel65.Text = "Recibio";
            this.xrLabel65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel64
            // 
            this.xrLabel64.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel64.BorderWidth = 2F;
            this.xrLabel64.CanGrow = false;
            this.xrLabel64.Dpi = 100F;
            this.xrLabel64.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel64.LocationFloat = new DevExpress.Utils.PointFloat(70F, 280F);
            this.xrLabel64.Name = "xrLabel64";
            this.xrLabel64.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel64.SizeF = new System.Drawing.SizeF(200F, 20F);
            this.xrLabel64.StylePriority.UseBorders = false;
            this.xrLabel64.StylePriority.UseBorderWidth = false;
            this.xrLabel64.StylePriority.UseFont = false;
            this.xrLabel64.StylePriority.UseTextAlignment = false;
            this.xrLabel64.Text = "Vendedor";
            this.xrLabel64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPanel2
            // 
            this.xrPanel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel2.BorderWidth = 2F;
            this.xrPanel2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel15,
            this.TotalALiquidar,
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel10,
            this.xrLabel11,
            this.ImporteMovimientos,
            this.ImporteCredito,
            this.labelCobranza});
            this.xrPanel2.Dpi = 100F;
            this.xrPanel2.LocationFloat = new DevExpress.Utils.PointFloat(460F, 10F);
            this.xrPanel2.Name = "xrPanel2";
            this.xrPanel2.SizeF = new System.Drawing.SizeF(310F, 100F);
            this.xrPanel2.StylePriority.UseBorders = false;
            this.xrPanel2.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel15.CanGrow = false;
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(10.00002F, 69.99998F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(190F, 15F);
            this.xrLabel15.StylePriority.UseBorders = false;
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "Total a Liquidar (Venta - Credito)";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TotalALiquidar
            // 
            this.TotalALiquidar.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalALiquidar.CanGrow = false;
            this.TotalALiquidar.Dpi = 100F;
            this.TotalALiquidar.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.TotalALiquidar.LocationFloat = new DevExpress.Utils.PointFloat(200F, 69.99998F);
            this.TotalALiquidar.Name = "TotalALiquidar";
            this.TotalALiquidar.NullValueText = "0";
            this.TotalALiquidar.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalALiquidar.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.TotalALiquidar.StylePriority.UseBorders = false;
            this.TotalALiquidar.StylePriority.UseFont = false;
            this.TotalALiquidar.StylePriority.UseTextAlignment = false;
            this.TotalALiquidar.Text = "TotalALiquidar";
            this.TotalALiquidar.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.TotalALiquidar.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.TotalALiquidar_BeforePrint);
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel8.CanGrow = false;
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(10F, 10F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Pre-Liquidacion";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel9.CanGrow = false;
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(10F, 25F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(190F, 15F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Ventas Totales De Producto";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel10.CanGrow = false;
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(10F, 40F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(190F, 15F);
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "(-) Ventas Credito";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel11.CanGrow = false;
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(10F, 55F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(190F, 15F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "(+) Cobranza";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ImporteMovimientos
            // 
            this.ImporteMovimientos.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ImporteMovimientos.CanGrow = false;
            this.ImporteMovimientos.Dpi = 100F;
            this.ImporteMovimientos.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.ImporteMovimientos.LocationFloat = new DevExpress.Utils.PointFloat(200F, 25F);
            this.ImporteMovimientos.Name = "ImporteMovimientos";
            this.ImporteMovimientos.NullValueText = "0";
            this.ImporteMovimientos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ImporteMovimientos.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.ImporteMovimientos.StylePriority.UseBorders = false;
            this.ImporteMovimientos.StylePriority.UseFont = false;
            this.ImporteMovimientos.StylePriority.UseTextAlignment = false;
            this.ImporteMovimientos.Text = "ImporteMovimientos";
            this.ImporteMovimientos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ImporteCredito
            // 
            this.ImporteCredito.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ImporteCredito.CanGrow = false;
            this.ImporteCredito.Dpi = 100F;
            this.ImporteCredito.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.ImporteCredito.LocationFloat = new DevExpress.Utils.PointFloat(200F, 39.99996F);
            this.ImporteCredito.Name = "ImporteCredito";
            this.ImporteCredito.NullValueText = "0";
            this.ImporteCredito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ImporteCredito.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.ImporteCredito.StylePriority.UseBorders = false;
            this.ImporteCredito.StylePriority.UseFont = false;
            this.ImporteCredito.StylePriority.UseTextAlignment = false;
            this.ImporteCredito.Text = "ImporteCredito";
            this.ImporteCredito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelCobranza
            // 
            this.labelCobranza.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelCobranza.CanGrow = false;
            this.labelCobranza.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW080Liquidacion.Cobranza")});
            this.labelCobranza.Dpi = 100F;
            this.labelCobranza.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.labelCobranza.LocationFloat = new DevExpress.Utils.PointFloat(200F, 54.99999F);
            this.labelCobranza.Name = "labelCobranza";
            this.labelCobranza.NullValueText = "0";
            this.labelCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCobranza.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.labelCobranza.StylePriority.UseBorders = false;
            this.labelCobranza.StylePriority.UseFont = false;
            this.labelCobranza.StylePriority.UseTextAlignment = false;
            this.labelCobranza.Text = "0";
            this.labelCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrPanel1
            // 
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.BorderWidth = 2F;
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7});
            this.xrPanel1.Dpi = 100F;
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(100F, 10F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(270F, 80F);
            this.xrPanel1.StylePriority.UseBorders = false;
            this.xrPanel1.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(9.791692F, 9.999974F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Cobranza";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(9.791692F, 25F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "% Efectividad";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.CanGrow = false;
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(9.791692F, 39.99996F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Clientes Visitados";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(9.791692F, 54.99999F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Clientes No Visitados";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel5.CanGrow = false;
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW080Liquidacion.Efectividad")});
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(159.7917F, 25F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.NullValueText = "0";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel6.CanGrow = false;
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW080Liquidacion.Visitados")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(159.7917F, 39.99996F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.NullValueText = "0";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel7.CanGrow = false;
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW080Liquidacion.ClientesNoVisitados")});
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(159.7917F, 54.99999F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.NullValueText = "0";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "xrLabel7";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Efectividad
            // 
            this.Efectividad.DataMember = "stpr_RW080Liquidacion";
            this.Efectividad.Expression = "Iif([Agendados] > 0,  [Visitados] * 100 / [Agendados], 0)";
            this.Efectividad.Name = "Efectividad";
            // 
            // ClientesNoVisitados
            // 
            this.ClientesNoVisitados.DataMember = "stpr_RW080Liquidacion";
            this.ClientesNoVisitados.Expression = "[Agendados] - [Visitados]";
            this.ClientesNoVisitados.Name = "ClientesNoVisitados";
            // 
            // CobranzaTotal
            // 
            this.CobranzaTotal.DataMember = "stpr_RW080Liquidacion";
            this.CobranzaTotal.Expression = "[].Sum([Cobranza])";
            this.CobranzaTotal.Name = "CobranzaTotal";
            // 
            // R080Liquidacion
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageFooter,
            this.GroupFooter1,
            this.ReportFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.Efectividad,
            this.ClientesNoVisitados,
            this.CobranzaTotal});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_RW080Liquidacion";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.Margins = new System.Drawing.Printing.Margins(5, 5, 5, 5);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterCedis,
            this.parameterSeller,
            this.parameterStartDate});
            this.Version = "16.1";
            this.DataSourceDemanded += new System.EventHandler<System.EventArgs>(this.R080Liquidacion_DataSourceDemanded);
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.R080Liquidacion_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void TotalALiquidar_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        temp = (R080LiquidacionMovimientosDeProductos.ReportSource as XtraReport).GetCurrentColumnValue("ImporteMovimiento");
        valueTemp = double.Parse((temp ?? 0).ToString());
        ventasTotales = valueTemp;
        temp = (R080LiquidacionVentasCredito.ReportSource as XtraReport).GetCurrentColumnValue("ImporteCredito");
        valueTemp = double.Parse((temp ?? 0).ToString());
        ventascredito = valueTemp;
        cobranza = double.Parse(labelCobranza.Text);
        labelCobranza.Text = string.Format("{0:$#,##0.00}", cobranza);
        ImporteMovimientos.Text = string.Format("{0:$#,##0.00}", ventasTotales);
        ImporteCredito.Text = string.Format("{0:$#,##0.00}", ventascredito);
        (sender as XRControl).Text = string.Format("{0:$#,##0.00}", (ventasTotales - ventascredito + cobranza));
    }

    private int CountRows()
    {
        StringBuilder sConsulta = new StringBuilder();
        sConsulta.AppendLine("EXEC [dbo].[stpr_RW080Liquidacion] ");
        sConsulta.AppendLine(string.Format("@filterCEDIS = '{0}', ", cedisFilter));
        sConsulta.AppendLine(string.Format("@filterSeller = '{0}', ", sellerFilter));
        sConsulta.AppendLine(string.Format("@filterStartDate = '{0}', ", startD.Date.ToString("yyyy-MM-dd")));
        sConsulta.AppendLine("@filterQueryNumber = 1");
        List<object> objectData = Connection.Query<object>(sConsulta.ToString(), null, null, true, 9000).ToList();
        return objectData.Count;
    }

    private void R080Liquidacion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        string startDate = startD.Date.ToShortDateString();
        company.Text = companyName;
        logo.Image = Image.FromStream(CompanyLogo);
        logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
        date.Text = startDate;
        report.Text = reportName;
        labelFilter.Text = "Vendedor: ";
        filter.Text = sellerName;
        center.Text = cedisName;
    }

    private void R080Liquidacion_DataSourceDemanded(object sender, EventArgs e)
    {
        this.Parameters["parameterCedis"].Value = cedisFilter;
        this.Parameters["parameterSeller"].Value = sellerFilter;
        this.Parameters["parameterStartDate"].Value = startD.Date.ToString("yyyy-MM-dd");
    }
}
