using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for R277_Report_Design
/// </summary>
public class R277_Report_Design : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel18;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRLabel xrLabel22;
    private XRLabel xrLabel24;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel2;
    private GroupHeaderBand groupHeaderBand2;
    private XRLabel xrLabel4;
    private GroupHeaderBand groupHeaderBand3;
    private XRLabel xrLabel6;
    private GroupHeaderBand groupHeaderBand4;
    private XRLabel xrLabel8;
    private GroupHeaderBand groupHeaderBand5;
    private XRLabel xrLabel10;
    private GroupHeaderBand groupHeaderBand6;
    private PageFooterBand pageFooterBand1;
    private ReportHeaderBand reportHeaderBand1;
    private GroupFooterBand groupFooterBand1;
    private GroupFooterBand groupFooterBand2;
    private GroupFooterBand groupFooterBand3;
    private GroupFooterBand groupFooterBand4;
    private XRLabel xrLabel36;
    private GroupFooterBand groupFooterBand5;
    private GroupFooterBand groupFooterBand6;
    private ReportFooterBand reportFooterBand1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    public XRPictureBox logo;
    public XRLabel headerFecha;
    public XRLabel headerCEDI;
    public XRLabel L_CEDI;
    public XRLabel L_FechaRango;
    public XRLabel report_Name;
    public XRLabel report_Company;
    public XRLabel headerRuta;
    public XRLabel L_Ruta;
    public XRLabel lb_Total;
    private PageHeaderBand PageHeader;
    public XRLabel lb_Folio;
    public XRLabel lb_Clave;
    public XRLabel lb_Cliente;
    public XRLabel lb_Producto;
    public XRLabel lb_Pzs;
    public XRLabel lb_Precio;
    private XRLabel xrLabel19;
    public XRLabel groupCEDI;
    public XRLabel groupVendedor;
    public XRLabel groupFecha;
    public XRLabel groupRuta;
    public XRLabel lb_TotalRuta;
    private XRLabel xrLabel11;
    private XRPageInfo xrPageInfo3;
    public XRLabel lb_DateTimeImpresion;
    private XRPageInfo xrPageInfo4;
    public XRLabel lb_Gtotal;
    private DevExpress.XtraReports.Parameters.Parameter parameterCedis;
    private DevExpress.XtraReports.Parameters.Parameter parameterRoutes;
    private DevExpress.XtraReports.Parameters.Parameter parameterDateIni;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public R277_Report_Design()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R277_Report_Design));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.groupCEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.groupVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.groupFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.groupRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand6 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.lb_DateTimeImpresion = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo4 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.headerFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.headerCEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.L_CEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.L_FechaRango = new DevExpress.XtraReports.UI.XRLabel();
            this.report_Name = new DevExpress.XtraReports.UI.XRLabel();
            this.report_Company = new DevExpress.XtraReports.UI.XRLabel();
            this.headerRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Ruta = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.groupFooterBand2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.groupFooterBand3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.groupFooterBand4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.lb_TotalRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupFooterBand5 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.groupFooterBand6 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.reportFooterBand1 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.lb_Total = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.lb_Folio = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_Clave = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_Cliente = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_Producto = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_Pzs = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_Precio = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_Gtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.parameterCedis = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterRoutes = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDateIni = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel20,
            this.xrLabel21,
            this.xrLabel22});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 13F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "DataField";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R277Liquidacion_NOR.Piezas", "{0:#,#}")});
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(780.4165F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(99.58344F, 13F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UsePadding = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "xrLabel20";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R277Liquidacion_NOR.Precio", "{0:n}")});
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(879.9999F, 0F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(99.58344F, 13F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UsePadding = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "xrLabel21";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel22
            // 
            this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R277Liquidacion_NOR.Producto Clave")});
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(649.9999F, 0F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(129.5832F, 13F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "xrLabel22";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 1F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 10F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "eRouteConnection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "stpr_R277Liquidacion_NOR";
            queryParameter1.Name = "@filterCedi";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterCedis]", typeof(string));
            queryParameter2.Name = "@filterRoutes";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterRoutes]", typeof(string));
            queryParameter3.Name = "@filterDateIni";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterDateIni]", typeof(string));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.StoredProcName = "stpr_R277Liquidacion_NOR";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // groupHeaderBand1
            // 
            this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.groupCEDI,
            this.xrLabel2});
            this.groupHeaderBand1.Dpi = 100F;
            this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CEDI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand1.HeightF = 14.55F;
            this.groupHeaderBand1.Level = 5;
            this.groupHeaderBand1.Name = "groupHeaderBand1";
            // 
            // groupCEDI
            // 
            this.groupCEDI.CanGrow = false;
            this.groupCEDI.Dpi = 100F;
            this.groupCEDI.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupCEDI.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.groupCEDI.Name = "groupCEDI";
            this.groupCEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.groupCEDI.SizeF = new System.Drawing.SizeF(130F, 14.55F);
            this.groupCEDI.StylePriority.UseFont = false;
            this.groupCEDI.StylePriority.UseTextAlignment = false;
            this.groupCEDI.Text = "Centro de Distribución:";
            this.groupCEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R277Liquidacion_NOR.CEDI")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(300F, 13F);
            this.xrLabel2.StyleName = "DataField";
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "xrLabel2";
            // 
            // groupHeaderBand2
            // 
            this.groupHeaderBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.groupVendedor,
            this.xrLabel4});
            this.groupHeaderBand2.Dpi = 100F;
            this.groupHeaderBand2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Vendedor", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand2.HeightF = 14.55F;
            this.groupHeaderBand2.Level = 4;
            this.groupHeaderBand2.Name = "groupHeaderBand2";
            // 
            // groupVendedor
            // 
            this.groupVendedor.CanGrow = false;
            this.groupVendedor.Dpi = 100F;
            this.groupVendedor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupVendedor.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.groupVendedor.Name = "groupVendedor";
            this.groupVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(12, 2, 0, 0, 100F);
            this.groupVendedor.SizeF = new System.Drawing.SizeF(130F, 14.55F);
            this.groupVendedor.StylePriority.UseFont = false;
            this.groupVendedor.StylePriority.UsePadding = false;
            this.groupVendedor.StylePriority.UseTextAlignment = false;
            this.groupVendedor.Text = "Vendedor";
            this.groupVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R277Liquidacion_NOR.Vendedor")});
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(300F, 13F);
            this.xrLabel4.StyleName = "DataField";
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "xrLabel4";
            // 
            // groupHeaderBand3
            // 
            this.groupHeaderBand3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.groupFecha,
            this.xrLabel6});
            this.groupHeaderBand3.Dpi = 100F;
            this.groupHeaderBand3.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Fecha Captura", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand3.HeightF = 14.55F;
            this.groupHeaderBand3.Level = 3;
            this.groupHeaderBand3.Name = "groupHeaderBand3";
            // 
            // groupFecha
            // 
            this.groupFecha.CanGrow = false;
            this.groupFecha.Dpi = 100F;
            this.groupFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupFecha.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.groupFecha.Name = "groupFecha";
            this.groupFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(24, 2, 0, 0, 100F);
            this.groupFecha.SizeF = new System.Drawing.SizeF(130F, 14.55F);
            this.groupFecha.StylePriority.UseFont = false;
            this.groupFecha.StylePriority.UsePadding = false;
            this.groupFecha.StylePriority.UseTextAlignment = false;
            this.groupFecha.Text = "Fecha";
            this.groupFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R277Liquidacion_NOR.Fecha Captura", "{0:dd/MM/yy}")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.xrLabel6.StyleName = "DataField";
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "xrLabel6";
            // 
            // groupHeaderBand4
            // 
            this.groupHeaderBand4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.groupRuta,
            this.xrLabel8});
            this.groupHeaderBand4.Dpi = 100F;
            this.groupHeaderBand4.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Ruta", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand4.HeightF = 14.55F;
            this.groupHeaderBand4.Level = 2;
            this.groupHeaderBand4.Name = "groupHeaderBand4";
            // 
            // groupRuta
            // 
            this.groupRuta.CanGrow = false;
            this.groupRuta.Dpi = 100F;
            this.groupRuta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupRuta.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.groupRuta.Name = "groupRuta";
            this.groupRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(36, 2, 0, 0, 100F);
            this.groupRuta.SizeF = new System.Drawing.SizeF(130F, 14.55F);
            this.groupRuta.StylePriority.UseFont = false;
            this.groupRuta.StylePriority.UsePadding = false;
            this.groupRuta.StylePriority.UseTextAlignment = false;
            this.groupRuta.Text = "Ruta";
            this.groupRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R277Liquidacion_NOR.Ruta")});
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(300F, 13F);
            this.xrLabel8.StyleName = "DataField";
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "xrLabel8";
            // 
            // groupHeaderBand5
            // 
            this.groupHeaderBand5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel19,
            this.xrLabel10,
            this.xrLabel18,
            this.xrLabel24});
            this.groupHeaderBand5.Dpi = 100F;
            this.groupHeaderBand5.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Folio", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand5.HeightF = 13F;
            this.groupHeaderBand5.Level = 1;
            this.groupHeaderBand5.Name = "groupHeaderBand5";
            // 
            // xrLabel19
            // 
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R277Liquidacion_NOR.Cliente Clave")});
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(150.4167F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(119.5833F, 13F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "xrLabel19";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R277Liquidacion_NOR.Folio")});
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(149.5833F, 13F);
            this.xrLabel10.StyleName = "DataField";
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "xrLabel10";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R277Liquidacion_NOR.Cliente")});
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(270.8335F, 0F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(379.1664F, 13F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "xrLabel18";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel24
            // 
            this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R277Liquidacion_NOR.Total Detalle")});
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(980.4165F, 0F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(99.5835F, 13F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UsePadding = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:c}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel24.Summary = xrSummary1;
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // groupHeaderBand6
            // 
            this.groupHeaderBand6.Dpi = 100F;
            this.groupHeaderBand6.HeightF = 10F;
            this.groupHeaderBand6.Name = "groupHeaderBand6";
            this.groupHeaderBand6.StyleName = "FieldCaption";
            // 
            // pageFooterBand1
            // 
            this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo3,
            this.lb_DateTimeImpresion,
            this.xrPageInfo4});
            this.pageFooterBand1.Dpi = 100F;
            this.pageFooterBand1.HeightF = 29F;
            this.pageFooterBand1.Name = "pageFooterBand1";
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.Dpi = 100F;
            this.xrPageInfo3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo3.Format = "{0} / {1}";
            this.xrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(242F, 5F);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPageInfo3.SizeF = new System.Drawing.SizeF(313F, 14F);
            this.xrPageInfo3.StylePriority.UseFont = false;
            this.xrPageInfo3.StylePriority.UsePadding = false;
            this.xrPageInfo3.StylePriority.UseTextAlignment = false;
            this.xrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lb_DateTimeImpresion
            // 
            this.lb_DateTimeImpresion.Dpi = 100F;
            this.lb_DateTimeImpresion.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DateTimeImpresion.LocationFloat = new DevExpress.Utils.PointFloat(786.27F, 5F);
            this.lb_DateTimeImpresion.Name = "lb_DateTimeImpresion";
            this.lb_DateTimeImpresion.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lb_DateTimeImpresion.SizeF = new System.Drawing.SizeF(150F, 14F);
            this.lb_DateTimeImpresion.StylePriority.UseFont = false;
            this.lb_DateTimeImpresion.StylePriority.UsePadding = false;
            this.lb_DateTimeImpresion.StylePriority.UseTextAlignment = false;
            this.lb_DateTimeImpresion.Text = "Fecha Hora Impresión";
            this.lb_DateTimeImpresion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrPageInfo4
            // 
            this.xrPageInfo4.Dpi = 100F;
            this.xrPageInfo4.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo4.Format = "{0:dd/MM/yyyy hh:mm:ss tt}";
            this.xrPageInfo4.LocationFloat = new DevExpress.Utils.PointFloat(936.27F, 5F);
            this.xrPageInfo4.Name = "xrPageInfo4";
            this.xrPageInfo4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPageInfo4.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo4.SizeF = new System.Drawing.SizeF(123.81F, 14F);
            this.xrPageInfo4.StylePriority.UseFont = false;
            this.xrPageInfo4.StylePriority.UsePadding = false;
            this.xrPageInfo4.StylePriority.UseTextAlignment = false;
            this.xrPageInfo4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.headerFecha,
            this.headerCEDI,
            this.L_CEDI,
            this.L_FechaRango,
            this.report_Name,
            this.report_Company,
            this.headerRuta,
            this.L_Ruta,
            this.logo});
            this.reportHeaderBand1.Dpi = 100F;
            this.reportHeaderBand1.HeightF = 120F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // headerFecha
            // 
            this.headerFecha.Dpi = 100F;
            this.headerFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerFecha.LocationFloat = new DevExpress.Utils.PointFloat(220.05F, 83.27F);
            this.headerFecha.Name = "headerFecha";
            this.headerFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.headerFecha.SizeF = new System.Drawing.SizeF(188.3619F, 13F);
            this.headerFecha.StylePriority.UseFont = false;
            this.headerFecha.StylePriority.UsePadding = false;
            this.headerFecha.StylePriority.UseTextAlignment = false;
            this.headerFecha.Text = "Fecha";
            this.headerFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // headerCEDI
            // 
            this.headerCEDI.Dpi = 100F;
            this.headerCEDI.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerCEDI.LocationFloat = new DevExpress.Utils.PointFloat(220.42F, 67.69F);
            this.headerCEDI.Name = "headerCEDI";
            this.headerCEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.headerCEDI.SizeF = new System.Drawing.SizeF(187.9904F, 13F);
            this.headerCEDI.StylePriority.UseFont = false;
            this.headerCEDI.StylePriority.UsePadding = false;
            this.headerCEDI.StylePriority.UseTextAlignment = false;
            this.headerCEDI.Text = "Centro de Distribución";
            this.headerCEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_CEDI
            // 
            this.L_CEDI.Dpi = 100F;
            this.L_CEDI.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_CEDI.LocationFloat = new DevExpress.Utils.PointFloat(423.89F, 67.69F);
            this.L_CEDI.Name = "L_CEDI";
            this.L_CEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_CEDI.SizeF = new System.Drawing.SizeF(299.8937F, 13F);
            this.L_CEDI.StylePriority.UseFont = false;
            this.L_CEDI.StylePriority.UsePadding = false;
            this.L_CEDI.StylePriority.UseTextAlignment = false;
            this.L_CEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_FechaRango
            // 
            this.L_FechaRango.Dpi = 100F;
            this.L_FechaRango.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_FechaRango.LocationFloat = new DevExpress.Utils.PointFloat(423.89F, 83.27F);
            this.L_FechaRango.Name = "L_FechaRango";
            this.L_FechaRango.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_FechaRango.SizeF = new System.Drawing.SizeF(299.5219F, 12.99999F);
            this.L_FechaRango.StylePriority.UseFont = false;
            this.L_FechaRango.StylePriority.UsePadding = false;
            this.L_FechaRango.StylePriority.UseTextAlignment = false;
            this.L_FechaRango.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // report_Name
            // 
            this.report_Name.Dpi = 100F;
            this.report_Name.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_Name.LocationFloat = new DevExpress.Utils.PointFloat(220.42F, 25F);
            this.report_Name.Name = "report_Name";
            this.report_Name.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.report_Name.SizeF = new System.Drawing.SizeF(840.0859F, 25F);
            this.report_Name.StylePriority.UseFont = false;
            this.report_Name.StylePriority.UseTextAlignment = false;
            this.report_Name.Text = "NAME REPORT";
            this.report_Name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // report_Company
            // 
            this.report_Company.Dpi = 100F;
            this.report_Company.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_Company.LocationFloat = new DevExpress.Utils.PointFloat(220.42F, 0F);
            this.report_Company.Name = "report_Company";
            this.report_Company.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.report_Company.SizeF = new System.Drawing.SizeF(839.666F, 25F);
            this.report_Company.StylePriority.UseFont = false;
            this.report_Company.StylePriority.UseTextAlignment = false;
            this.report_Company.Text = "COMPANY";
            this.report_Company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // headerRuta
            // 
            this.headerRuta.Dpi = 100F;
            this.headerRuta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerRuta.LocationFloat = new DevExpress.Utils.PointFloat(220.05F, 96.27F);
            this.headerRuta.Name = "headerRuta";
            this.headerRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.headerRuta.SizeF = new System.Drawing.SizeF(188.3619F, 13F);
            this.headerRuta.StylePriority.UseFont = false;
            this.headerRuta.StylePriority.UsePadding = false;
            this.headerRuta.StylePriority.UseTextAlignment = false;
            this.headerRuta.Text = "Ruta(s)";
            this.headerRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_Ruta
            // 
            this.L_Ruta.Dpi = 100F;
            this.L_Ruta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Ruta.LocationFloat = new DevExpress.Utils.PointFloat(423.89F, 96.27F);
            this.L_Ruta.Name = "L_Ruta";
            this.L_Ruta.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_Ruta.SizeF = new System.Drawing.SizeF(300.2653F, 13F);
            this.L_Ruta.StylePriority.UseFont = false;
            this.L_Ruta.StylePriority.UsePadding = false;
            this.L_Ruta.StylePriority.UseTextAlignment = false;
            this.L_Ruta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(6.42F, 10F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(100F, 100F);
            // 
            // groupFooterBand1
            // 
            this.groupFooterBand1.Dpi = 100F;
            this.groupFooterBand1.HeightF = 1F;
            this.groupFooterBand1.Name = "groupFooterBand1";
            // 
            // groupFooterBand2
            // 
            this.groupFooterBand2.Dpi = 100F;
            this.groupFooterBand2.HeightF = 10F;
            this.groupFooterBand2.Level = 1;
            this.groupFooterBand2.Name = "groupFooterBand2";
            // 
            // groupFooterBand3
            // 
            this.groupFooterBand3.Dpi = 100F;
            this.groupFooterBand3.HeightF = 10F;
            this.groupFooterBand3.Level = 2;
            this.groupFooterBand3.Name = "groupFooterBand3";
            // 
            // groupFooterBand4
            // 
            this.groupFooterBand4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb_TotalRuta,
            this.xrLabel36});
            this.groupFooterBand4.Dpi = 100F;
            this.groupFooterBand4.HeightF = 24.00001F;
            this.groupFooterBand4.Level = 3;
            this.groupFooterBand4.Name = "groupFooterBand4";
            // 
            // lb_TotalRuta
            // 
            this.lb_TotalRuta.CanGrow = false;
            this.lb_TotalRuta.Dpi = 100F;
            this.lb_TotalRuta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TotalRuta.LocationFloat = new DevExpress.Utils.PointFloat(780F, 0F);
            this.lb_TotalRuta.Name = "lb_TotalRuta";
            this.lb_TotalRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb_TotalRuta.SizeF = new System.Drawing.SizeF(120F, 13F);
            this.lb_TotalRuta.StylePriority.UseFont = false;
            this.lb_TotalRuta.StylePriority.UsePadding = false;
            this.lb_TotalRuta.StylePriority.UseTextAlignment = false;
            this.lb_TotalRuta.Text = "Total por Ruta";
            this.lb_TotalRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel36
            // 
            this.xrLabel36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R277Liquidacion_NOR.Total Detalle")});
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(929.3921F, 0F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(150F, 13F);
            this.xrLabel36.StyleName = "FieldCaption";
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UsePadding = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:c}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel36.Summary = xrSummary2;
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // groupFooterBand5
            // 
            this.groupFooterBand5.Dpi = 100F;
            this.groupFooterBand5.HeightF = 10F;
            this.groupFooterBand5.Level = 4;
            this.groupFooterBand5.Name = "groupFooterBand5";
            // 
            // groupFooterBand6
            // 
            this.groupFooterBand6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb_Gtotal,
            this.xrLabel11});
            this.groupFooterBand6.Dpi = 100F;
            this.groupFooterBand6.HeightF = 20F;
            this.groupFooterBand6.Level = 5;
            this.groupFooterBand6.Name = "groupFooterBand6";
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R277Liquidacion_NOR.Total Detalle")});
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(929.3921F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(150F, 13F);
            this.xrLabel11.StyleName = "FieldCaption";
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UsePadding = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:c}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel11.Summary = xrSummary3;
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // reportFooterBand1
            // 
            this.reportFooterBand1.Dpi = 100F;
            this.reportFooterBand1.HeightF = 10F;
            this.reportFooterBand1.Name = "reportFooterBand1";
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Times New Roman", 21F);
            this.Title.ForeColor = System.Drawing.Color.Black;
            this.Title.Name = "Title";
            // 
            // FieldCaption
            // 
            this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
            this.FieldCaption.BorderColor = System.Drawing.Color.Black;
            this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FieldCaption.BorderWidth = 1F;
            this.FieldCaption.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.FieldCaption.ForeColor = System.Drawing.Color.Black;
            this.FieldCaption.Name = "FieldCaption";
            // 
            // PageInfo
            // 
            this.PageInfo.BackColor = System.Drawing.Color.Transparent;
            this.PageInfo.BorderColor = System.Drawing.Color.Black;
            this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageInfo.BorderWidth = 1F;
            this.PageInfo.Font = new System.Drawing.Font("Arial", 8F);
            this.PageInfo.ForeColor = System.Drawing.Color.Black;
            this.PageInfo.Name = "PageInfo";
            // 
            // DataField
            // 
            this.DataField.BackColor = System.Drawing.Color.Transparent;
            this.DataField.BorderColor = System.Drawing.Color.Black;
            this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataField.BorderWidth = 1F;
            this.DataField.Font = new System.Drawing.Font("Arial", 9F);
            this.DataField.ForeColor = System.Drawing.Color.Black;
            this.DataField.Name = "DataField";
            this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // lb_Total
            // 
            this.lb_Total.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lb_Total.Dpi = 100F;
            this.lb_Total.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Total.LocationFloat = new DevExpress.Utils.PointFloat(979.9999F, 0F);
            this.lb_Total.Name = "lb_Total";
            this.lb_Total.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lb_Total.SizeF = new System.Drawing.SizeF(100F, 35F);
            this.lb_Total.StylePriority.UseBorders = false;
            this.lb_Total.StylePriority.UseFont = false;
            this.lb_Total.StylePriority.UsePadding = false;
            this.lb_Total.StylePriority.UseTextAlignment = false;
            this.lb_Total.Text = "Total";
            this.lb_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb_Folio,
            this.lb_Clave,
            this.lb_Cliente,
            this.lb_Producto,
            this.lb_Pzs,
            this.lb_Precio,
            this.lb_Total});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 35F;
            this.PageHeader.Name = "PageHeader";
            // 
            // lb_Folio
            // 
            this.lb_Folio.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lb_Folio.Dpi = 100F;
            this.lb_Folio.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Folio.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lb_Folio.Name = "lb_Folio";
            this.lb_Folio.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lb_Folio.SizeF = new System.Drawing.SizeF(150F, 35F);
            this.lb_Folio.StylePriority.UseBorders = false;
            this.lb_Folio.StylePriority.UseFont = false;
            this.lb_Folio.StylePriority.UsePadding = false;
            this.lb_Folio.StylePriority.UseTextAlignment = false;
            this.lb_Folio.Text = "Folio";
            this.lb_Folio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lb_Clave
            // 
            this.lb_Clave.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lb_Clave.Dpi = 100F;
            this.lb_Clave.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Clave.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
            this.lb_Clave.Name = "lb_Clave";
            this.lb_Clave.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lb_Clave.SizeF = new System.Drawing.SizeF(120F, 35F);
            this.lb_Clave.StylePriority.UseBorders = false;
            this.lb_Clave.StylePriority.UseFont = false;
            this.lb_Clave.StylePriority.UsePadding = false;
            this.lb_Clave.StylePriority.UseTextAlignment = false;
            this.lb_Clave.Text = "Clave";
            this.lb_Clave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lb_Cliente
            // 
            this.lb_Cliente.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lb_Cliente.Dpi = 100F;
            this.lb_Cliente.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Cliente.LocationFloat = new DevExpress.Utils.PointFloat(270.4168F, 0F);
            this.lb_Cliente.Name = "lb_Cliente";
            this.lb_Cliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lb_Cliente.SizeF = new System.Drawing.SizeF(379.5831F, 35F);
            this.lb_Cliente.StylePriority.UseBorders = false;
            this.lb_Cliente.StylePriority.UseFont = false;
            this.lb_Cliente.StylePriority.UsePadding = false;
            this.lb_Cliente.StylePriority.UseTextAlignment = false;
            this.lb_Cliente.Text = "Cliente";
            this.lb_Cliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lb_Producto
            // 
            this.lb_Producto.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lb_Producto.Dpi = 100F;
            this.lb_Producto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Producto.LocationFloat = new DevExpress.Utils.PointFloat(649.9999F, 0F);
            this.lb_Producto.Name = "lb_Producto";
            this.lb_Producto.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lb_Producto.SizeF = new System.Drawing.SizeF(130F, 35F);
            this.lb_Producto.StylePriority.UseBorders = false;
            this.lb_Producto.StylePriority.UseFont = false;
            this.lb_Producto.StylePriority.UsePadding = false;
            this.lb_Producto.StylePriority.UseTextAlignment = false;
            this.lb_Producto.Text = "Producto";
            this.lb_Producto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lb_Pzs
            // 
            this.lb_Pzs.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lb_Pzs.Dpi = 100F;
            this.lb_Pzs.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Pzs.LocationFloat = new DevExpress.Utils.PointFloat(779.9999F, 0F);
            this.lb_Pzs.Name = "lb_Pzs";
            this.lb_Pzs.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lb_Pzs.SizeF = new System.Drawing.SizeF(100F, 35F);
            this.lb_Pzs.StylePriority.UseBorders = false;
            this.lb_Pzs.StylePriority.UseFont = false;
            this.lb_Pzs.StylePriority.UsePadding = false;
            this.lb_Pzs.StylePriority.UseTextAlignment = false;
            this.lb_Pzs.Text = "Pzs";
            this.lb_Pzs.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lb_Precio
            // 
            this.lb_Precio.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lb_Precio.Dpi = 100F;
            this.lb_Precio.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Precio.LocationFloat = new DevExpress.Utils.PointFloat(879.9999F, 0F);
            this.lb_Precio.Name = "lb_Precio";
            this.lb_Precio.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lb_Precio.SizeF = new System.Drawing.SizeF(100F, 35F);
            this.lb_Precio.StylePriority.UseBorders = false;
            this.lb_Precio.StylePriority.UseFont = false;
            this.lb_Precio.StylePriority.UsePadding = false;
            this.lb_Precio.StylePriority.UseTextAlignment = false;
            this.lb_Precio.Text = "Precio";
            this.lb_Precio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lb_Gtotal
            // 
            this.lb_Gtotal.CanGrow = false;
            this.lb_Gtotal.Dpi = 100F;
            this.lb_Gtotal.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Gtotal.LocationFloat = new DevExpress.Utils.PointFloat(780F, 0F);
            this.lb_Gtotal.Name = "lb_Gtotal";
            this.lb_Gtotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb_Gtotal.SizeF = new System.Drawing.SizeF(120F, 13F);
            this.lb_Gtotal.StylePriority.UseFont = false;
            this.lb_Gtotal.StylePriority.UsePadding = false;
            this.lb_Gtotal.StylePriority.UseTextAlignment = false;
            this.lb_Gtotal.Text = "GRAN TOTAL";
            this.lb_Gtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // parameterCedis
            // 
            this.parameterCedis.Description = "parameterCedis";
            this.parameterCedis.Name = "parameterCedis";
            this.parameterCedis.ValueInfo = "20";
            this.parameterCedis.Visible = false;
            // 
            // parameterRoutes
            // 
            this.parameterRoutes.Description = "parameterRoutes";
            this.parameterRoutes.Name = "parameterRoutes";
            this.parameterRoutes.ValueInfo = "TEP02,TEP05,TEP17";
            this.parameterRoutes.Visible = false;
            // 
            // parameterDateIni
            // 
            this.parameterDateIni.Description = "parameterDateIni";
            this.parameterDateIni.Name = "parameterDateIni";
            this.parameterDateIni.ValueInfo = "20200122";
            this.parameterDateIni.Visible = false;
            // 
            // R277_Report_Design
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.groupHeaderBand1,
            this.groupHeaderBand2,
            this.groupHeaderBand3,
            this.groupHeaderBand4,
            this.groupHeaderBand5,
            this.groupHeaderBand6,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.groupFooterBand2,
            this.groupFooterBand3,
            this.groupFooterBand4,
            this.groupFooterBand5,
            this.groupFooterBand6,
            this.reportFooterBand1,
            this.PageHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_R277Liquidacion_NOR";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 1, 10);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterCedis,
            this.parameterRoutes,
            this.parameterDateIni});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
