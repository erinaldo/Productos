using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

/// <summary>
/// Summary description for CobranzaFacturaGlobalPDR
/// </summary>
public class CobranzaFacturaGlobalPDR : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    public XRLabel lbTituloCobranza;
    public XRLabel lbFolio;
    public XRLabel lbFecha;
    public XRLabel lbRazon;
    public XRLabel lbImporte;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRLabel xrLabel8;
    public XRLabel lbTotal;
    private XRLabel xrLabel6;
    public XRLabel lbTotalCobranza;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private CalculatedField ImporteAbonos;
    private DevExpress.XtraReports.Parameters.Parameter TotalVenta;
    private CalculatedField Total;
    private XRLabel xrLabel7;
    public XRLabel lbNombre;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public CobranzaFacturaGlobalPDR()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
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

    public void SetDataSource(string cons)
    {
        sqlDataSource1.Queries.RemoveAt(0);
        CustomSqlQuery query = new CustomSqlQuery("Query", cons);
        sqlDataSource1.Queries.Add(query);
        sqlDataSource1.RebuildResultSchema();
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CobranzaFacturaGlobalPDR));
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.lbTituloCobranza = new DevExpress.XtraReports.UI.XRLabel();
        this.lbFolio = new DevExpress.XtraReports.UI.XRLabel();
        this.lbFecha = new DevExpress.XtraReports.UI.XRLabel();
        this.lbRazon = new DevExpress.XtraReports.UI.XRLabel();
        this.lbImporte = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.lbTotal = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.lbTotalCobranza = new DevExpress.XtraReports.UI.XRLabel();
        this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
        this.ImporteAbonos = new DevExpress.XtraReports.UI.CalculatedField();
        this.TotalVenta = new DevExpress.XtraReports.Parameters.Parameter();
        this.Total = new DevExpress.XtraReports.UI.CalculatedField();
        this.lbNombre = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel7,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
        this.Detail.Dpi = 100F;
        this.Detail.HeightF = 27F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel4.CanGrow = false;
        this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.RazonSocial")});
        this.xrLabel4.Dpi = 100F;
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(379.3747F, 0F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(270.6253F, 19F);
        this.xrLabel4.StylePriority.UseBorders = false;
        this.xrLabel4.Text = "xrLabel4";
        // 
        // xrLabel3
        // 
        this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel3.CanGrow = false;
        this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Importe", "{0:$0.00}")});
        this.xrLabel3.Dpi = 100F;
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(650F, 0F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(99F, 19F);
        this.xrLabel3.StylePriority.UseBorders = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "xrLabel3";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel2.CanGrow = false;
        this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FechaAbono", "{0:dd/MM/yyyy}")});
        this.xrLabel2.Dpi = 100F;
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(84.99985F, 0F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(86.25006F, 19F);
        this.xrLabel2.StylePriority.UseBorders = false;
        this.xrLabel2.Text = "xrLabel2";
        // 
        // xrLabel1
        // 
        this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel1.CanGrow = false;
        this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Folio")});
        this.xrLabel1.Dpi = 100F;
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0.4165649F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(84.375F, 19F);
        this.xrLabel1.StylePriority.UseBorders = false;
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
        this.BottomMargin.HeightF = 0F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbNombre,
            this.lbTituloCobranza,
            this.lbFolio,
            this.lbFecha,
            this.lbRazon,
            this.lbImporte});
        this.ReportHeader.Dpi = 100F;
        this.ReportHeader.HeightF = 44F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // lbTituloCobranza
        // 
        this.lbTituloCobranza.BackColor = System.Drawing.Color.LightGray;
        this.lbTituloCobranza.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lbTituloCobranza.Dpi = 100F;
        this.lbTituloCobranza.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.lbTituloCobranza.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.lbTituloCobranza.Name = "lbTituloCobranza";
        this.lbTituloCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(50, 2, 0, 0, 100F);
        this.lbTituloCobranza.SizeF = new System.Drawing.SizeF(749F, 25F);
        this.lbTituloCobranza.StylePriority.UseBackColor = false;
        this.lbTituloCobranza.StylePriority.UseBorders = false;
        this.lbTituloCobranza.StylePriority.UseFont = false;
        this.lbTituloCobranza.StylePriority.UsePadding = false;
        this.lbTituloCobranza.StylePriority.UseTextAlignment = false;
        this.lbTituloCobranza.Text = "COBRANZA PUBLICO GENERAL";
        this.lbTituloCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lbFolio
        // 
        this.lbFolio.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lbFolio.Dpi = 100F;
        this.lbFolio.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.lbFolio.LocationFloat = new DevExpress.Utils.PointFloat(0.6248474F, 25F);
        this.lbFolio.Name = "lbFolio";
        this.lbFolio.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.lbFolio.SizeF = new System.Drawing.SizeF(84.16672F, 19F);
        this.lbFolio.StylePriority.UseBorders = false;
        this.lbFolio.StylePriority.UseFont = false;
        this.lbFolio.StylePriority.UsePadding = false;
        this.lbFolio.StylePriority.UseTextAlignment = false;
        this.lbFolio.Text = "FOLIO";
        this.lbFolio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lbFecha
        // 
        this.lbFecha.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lbFecha.Dpi = 100F;
        this.lbFecha.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.lbFecha.LocationFloat = new DevExpress.Utils.PointFloat(84.79156F, 25F);
        this.lbFecha.Name = "lbFecha";
        this.lbFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.lbFecha.SizeF = new System.Drawing.SizeF(86.45834F, 19F);
        this.lbFecha.StylePriority.UseBorders = false;
        this.lbFecha.StylePriority.UseFont = false;
        this.lbFecha.StylePriority.UsePadding = false;
        this.lbFecha.StylePriority.UseTextAlignment = false;
        this.lbFecha.Text = "FECHA";
        this.lbFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lbRazon
        // 
        this.lbRazon.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lbRazon.Dpi = 100F;
        this.lbRazon.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.lbRazon.LocationFloat = new DevExpress.Utils.PointFloat(379.3747F, 25F);
        this.lbRazon.Name = "lbRazon";
        this.lbRazon.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.lbRazon.SizeF = new System.Drawing.SizeF(270.6253F, 19F);
        this.lbRazon.StylePriority.UseBorders = false;
        this.lbRazon.StylePriority.UseFont = false;
        this.lbRazon.StylePriority.UsePadding = false;
        this.lbRazon.StylePriority.UseTextAlignment = false;
        this.lbRazon.Text = "RAZON SOCIAL";
        this.lbRazon.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lbImporte
        // 
        this.lbImporte.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lbImporte.Dpi = 100F;
        this.lbImporte.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.lbImporte.LocationFloat = new DevExpress.Utils.PointFloat(650F, 25F);
        this.lbImporte.Name = "lbImporte";
        this.lbImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.lbImporte.SizeF = new System.Drawing.SizeF(99F, 19F);
        this.lbImporte.StylePriority.UseBorders = false;
        this.lbImporte.StylePriority.UseFont = false;
        this.lbImporte.StylePriority.UsePadding = false;
        this.lbImporte.StylePriority.UseTextAlignment = false;
        this.lbImporte.Text = "IMPORTE";
        this.lbImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8,
            this.lbTotal,
            this.xrLabel6,
            this.lbTotalCobranza});
        this.ReportFooter.Dpi = 100F;
        this.ReportFooter.HeightF = 48.33333F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel8
        // 
        this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel8.CanGrow = false;
        this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Total", "{0:$0.00}")});
        this.xrLabel8.Dpi = 100F;
        this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(650F, 25F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(99F, 23.33333F);
        this.xrLabel8.StylePriority.UseBorders = false;
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "xrLabel8";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // lbTotal
        // 
        this.lbTotal.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lbTotal.Dpi = 100F;
        this.lbTotal.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.lbTotal.LocationFloat = new DevExpress.Utils.PointFloat(250F, 25F);
        this.lbTotal.Name = "lbTotal";
        this.lbTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.lbTotal.SizeF = new System.Drawing.SizeF(400F, 23.33333F);
        this.lbTotal.StylePriority.UseBorders = false;
        this.lbTotal.StylePriority.UseFont = false;
        this.lbTotal.StylePriority.UsePadding = false;
        this.lbTotal.StylePriority.UseTextAlignment = false;
        this.lbTotal.Text = "TOTAL";
        this.lbTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel6.CanGrow = false;
        this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ImporteAbonos", "{0:$0.00}")});
        this.xrLabel6.Dpi = 100F;
        this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(650F, 0F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(99F, 25F);
        this.xrLabel6.StylePriority.UseBorders = false;
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "xrLabel6";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // lbTotalCobranza
        // 
        this.lbTotalCobranza.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lbTotalCobranza.Dpi = 100F;
        this.lbTotalCobranza.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.lbTotalCobranza.LocationFloat = new DevExpress.Utils.PointFloat(250F, 0F);
        this.lbTotalCobranza.Name = "lbTotalCobranza";
        this.lbTotalCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.lbTotalCobranza.SizeF = new System.Drawing.SizeF(400F, 25F);
        this.lbTotalCobranza.StylePriority.UseBorders = false;
        this.lbTotalCobranza.StylePriority.UseFont = false;
        this.lbTotalCobranza.StylePriority.UsePadding = false;
        this.lbTotalCobranza.StylePriority.UseTextAlignment = false;
        this.lbTotalCobranza.Text = "SUBTOTAL COBRANZA PUBLICO GENERAL";
        this.lbTotalCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // sqlDataSource1
        // 
        this.sqlDataSource1.ConnectionName = "eRouteConnection";
        this.sqlDataSource1.Name = "sqlDataSource1";
        customSqlQuery1.Name = "Query";
        customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
        this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
        this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
        // 
        // ImporteAbonos
        // 
        this.ImporteAbonos.DataMember = "Query";
        this.ImporteAbonos.Expression = "[].Sum([Importe])";
        this.ImporteAbonos.Name = "ImporteAbonos";
        // 
        // TotalVenta
        // 
        this.TotalVenta.Description = "TotalVenta";
        this.TotalVenta.Name = "TotalVenta";
        this.TotalVenta.Type = typeof(double);
        this.TotalVenta.ValueInfo = "0";
        // 
        // Total
        // 
        this.Total.DataMember = "Query";
        this.Total.Expression = "[Parameters.TotalVenta] + [ImporteAbonos]";
        this.Total.Name = "Total";
        // 
        // lbNombre
        // 
        this.lbNombre.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lbNombre.Dpi = 100F;
        this.lbNombre.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.lbNombre.LocationFloat = new DevExpress.Utils.PointFloat(171.4582F, 25F);
        this.lbNombre.Name = "lbNombre";
        this.lbNombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.lbNombre.SizeF = new System.Drawing.SizeF(207.7082F, 19F);
        this.lbNombre.StylePriority.UseBorders = false;
        this.lbNombre.StylePriority.UseFont = false;
        this.lbNombre.StylePriority.UsePadding = false;
        this.lbNombre.StylePriority.UseTextAlignment = false;
        this.lbNombre.Text = "NOMBRE COMERCIAL";
        this.lbNombre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.NombreCorto")});
        this.xrLabel7.Dpi = 100F;
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(171.4582F, 0F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(207.7082F, 19F);
        this.xrLabel7.StylePriority.UseBorders = false;
        this.xrLabel7.Text = "xrLabel7";
        // 
        // CobranzaFacturaGlobalPDR
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
        this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.ImporteAbonos,
            this.Total});
        this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
        this.DataMember = "Query";
        this.DataSource = this.sqlDataSource1;
        this.Margins = new System.Drawing.Printing.Margins(55, 46, 0, 0);
        this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.TotalVenta});
        this.Version = "16.1";
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
