using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for R108_Report_Design
/// </summary>
public class R108_Report_Design : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel2;
    private GroupHeaderBand groupHeaderBand2;
    private XRLabel xrLabel4;
    private GroupHeaderBand groupHeaderBand3;
    private XRLabel xrLabel6;
    private PageFooterBand pageFooterBand1;
    private ReportHeaderBand reportHeaderBand1;
    private GroupFooterBand groupFooterBand1;
    private GroupFooterBand groupFooterBand2;
    private XRLabel xrLabel28;
    private XRLabel xrLabel29;
    private XRLabel xrLabel30;
    private XRLabel xrLabel31;
    private GroupFooterBand groupFooterBand3;
    private GroupFooterBand groupFooterBand4;
    private XRLabel xrLabel48;
    private XRLabel xrLabel49;
    private XRLabel xrLabel50;
    private XRLabel xrLabel51;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    public XRPictureBox logo;
    public XRLabel report_Name;
    public XRLabel report_Company;
    public XRLabel L_FechaRango;
    public XRLabel L_Ruta;
    public XRLabel L_VendedorNombre;
    public XRLabel L_CEDI;
    public XRLabel headerRuta;
    public XRLabel headerVendedor;
    public XRLabel headerFecha;
    public XRLabel headerCEDI;
    public XRLabel Lb_CEDI_Grupo;
    public XRLabel Lb_Vendedor_Grupo;
    public XRLabel Lb_Ruta_Grupo;
    private PageHeaderBand PageHeader;
    private XRLine xrLine3;
    public XRLabel Label_Clave;
    public XRLabel Label_Cliente;
    public XRLabel Lb_GTotal;
    public XRLabel Lb_Total;
    public XRLabel Lb_Devoluciones;
    public XRLabel Lb_Descuentos;
    private XRLine xrLine4;
    private XRLine xrLine1;
    private XRPageInfo xrPageInfo2;
    public XRLabel Lb_FechaImpresion;
    private XRPageInfo xrPageInfo1;
    private DevExpress.XtraReports.Parameters.Parameter parameterCEDI;
    private DevExpress.XtraReports.Parameters.Parameter parameterSeller;
    private DevExpress.XtraReports.Parameters.Parameter parameterRoutes;
    private DevExpress.XtraReports.Parameters.Parameter parameterDateIni;
    private DevExpress.XtraReports.Parameters.Parameter parameterDateEnd;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public R108_Report_Design()
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
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R108_Report_Design));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Lb_CEDI_Grupo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Lb_Vendedor_Grupo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Lb_Ruta_Grupo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Lb_FechaImpresion = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.L_FechaRango = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Ruta = new DevExpress.XtraReports.UI.XRLabel();
            this.L_VendedorNombre = new DevExpress.XtraReports.UI.XRLabel();
            this.L_CEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.headerRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.headerVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.headerFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.headerCEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.report_Name = new DevExpress.XtraReports.UI.XRLabel();
            this.report_Company = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.groupFooterBand2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupFooterBand3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.groupFooterBand4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel50 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.Lb_Total = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Devoluciones = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Descuentos = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_GTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Cliente = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Clave = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.parameterCEDI = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterSeller = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterRoutes = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDateIni = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDateEnd = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel18,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel21,
            this.xrLabel24,
            this.xrLabel25});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 13F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "DataField";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.CanGrow = false;
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.Clave")});
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(79.58331F, 13F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.Text = "xrLabel18";
            // 
            // xrLabel19
            // 
            this.xrLabel19.CanGrow = false;
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.Cliente")});
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(80.83344F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(369.1666F, 13F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "xrLabel19";
            // 
            // xrLabel20
            // 
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.Descuentos", "{0:n}")});
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(550.4167F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(89.58331F, 13F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UsePadding = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "xrLabel20";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.Devoluciones", "{0:n}")});
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(640.4166F, 0F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(89.58344F, 13F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UsePadding = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "xrLabel21";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel24
            // 
            this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.Total", "{0:n}")});
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(729.9999F, 0F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(90.4165F, 13F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UsePadding = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "xrLabel24";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel25
            // 
            this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.TotalVenta", "{0:n}")});
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(450.4167F, 0F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(99.58331F, 13F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UsePadding = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "xrLabel25";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 10F;
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
            this.sqlDataSource1.ConnectionOptions.CommandTimeout = 300;
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "stpr_R108TotalVentas_ELE";
            queryParameter1.Name = "@FILTROCEDI";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterCEDI]", typeof(string));
            queryParameter2.Name = "@FILTROVENDEDOR";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterSeller]", typeof(string));
            queryParameter3.Name = "@FILTRORUTAS";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterRoutes]", typeof(string));
            queryParameter4.Name = "@FILTROFECHAINI";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterDateIni]", typeof(string));
            queryParameter5.Name = "@FILTROFECHAFIN";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterDateEnd]", typeof(string));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.StoredProcName = "stpr_R108TotalVentas_ELE";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // groupHeaderBand1
            // 
            this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Lb_CEDI_Grupo,
            this.xrLabel2});
            this.groupHeaderBand1.Dpi = 100F;
            this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CEDI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand1.HeightF = 13F;
            this.groupHeaderBand1.Level = 2;
            this.groupHeaderBand1.Name = "groupHeaderBand1";
            // 
            // Lb_CEDI_Grupo
            // 
            this.Lb_CEDI_Grupo.Dpi = 100F;
            this.Lb_CEDI_Grupo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_CEDI_Grupo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Lb_CEDI_Grupo.Name = "Lb_CEDI_Grupo";
            this.Lb_CEDI_Grupo.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_CEDI_Grupo.SizeF = new System.Drawing.SizeF(190F, 13F);
            this.Lb_CEDI_Grupo.StylePriority.UseFont = false;
            this.Lb_CEDI_Grupo.StylePriority.UsePadding = false;
            this.Lb_CEDI_Grupo.StylePriority.UseTextAlignment = false;
            this.Lb_CEDI_Grupo.Text = "Label_CEDI";
            this.Lb_CEDI_Grupo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.CEDI")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(200F, 0F);
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
            this.Lb_Vendedor_Grupo,
            this.xrLabel4});
            this.groupHeaderBand2.Dpi = 100F;
            this.groupHeaderBand2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Vendedor", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand2.HeightF = 14.55F;
            this.groupHeaderBand2.Level = 1;
            this.groupHeaderBand2.Name = "groupHeaderBand2";
            // 
            // Lb_Vendedor_Grupo
            // 
            this.Lb_Vendedor_Grupo.Dpi = 100F;
            this.Lb_Vendedor_Grupo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Vendedor_Grupo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Lb_Vendedor_Grupo.Name = "Lb_Vendedor_Grupo";
            this.Lb_Vendedor_Grupo.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 0, 0, 0, 100F);
            this.Lb_Vendedor_Grupo.SizeF = new System.Drawing.SizeF(190F, 13F);
            this.Lb_Vendedor_Grupo.StylePriority.UseFont = false;
            this.Lb_Vendedor_Grupo.StylePriority.UsePadding = false;
            this.Lb_Vendedor_Grupo.StylePriority.UseTextAlignment = false;
            this.Lb_Vendedor_Grupo.Text = "Label_Vendedor";
            this.Lb_Vendedor_Grupo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.Vendedor")});
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(200F, 0F);
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
            this.Lb_Ruta_Grupo,
            this.xrLabel6});
            this.groupHeaderBand3.Dpi = 100F;
            this.groupHeaderBand3.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Ruta", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand3.HeightF = 20F;
            this.groupHeaderBand3.Name = "groupHeaderBand3";
            // 
            // Lb_Ruta_Grupo
            // 
            this.Lb_Ruta_Grupo.Dpi = 100F;
            this.Lb_Ruta_Grupo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Ruta_Grupo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Lb_Ruta_Grupo.Name = "Lb_Ruta_Grupo";
            this.Lb_Ruta_Grupo.Padding = new DevExpress.XtraPrinting.PaddingInfo(30, 0, 0, 0, 100F);
            this.Lb_Ruta_Grupo.SizeF = new System.Drawing.SizeF(190F, 13F);
            this.Lb_Ruta_Grupo.StylePriority.UseFont = false;
            this.Lb_Ruta_Grupo.StylePriority.UsePadding = false;
            this.Lb_Ruta_Grupo.StylePriority.UseTextAlignment = false;
            this.Lb_Ruta_Grupo.Text = "Label_Ruta";
            this.Lb_Ruta_Grupo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.Ruta")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(200F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(300F, 13F);
            this.xrLabel6.StyleName = "DataField";
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "xrLabel6";
            // 
            // pageFooterBand1
            // 
            this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.Lb_FechaImpresion,
            this.xrPageInfo2});
            this.pageFooterBand1.Dpi = 100F;
            this.pageFooterBand1.HeightF = 20.66663F;
            this.pageFooterBand1.Name = "pageFooterBand1";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.Format = "{0:dd/MM/yyyy hh:mm:ss tt}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(682.19F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(123.81F, 14F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UsePadding = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // Lb_FechaImpresion
            // 
            this.Lb_FechaImpresion.Dpi = 100F;
            this.Lb_FechaImpresion.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_FechaImpresion.LocationFloat = new DevExpress.Utils.PointFloat(532.19F, 0F);
            this.Lb_FechaImpresion.Name = "Lb_FechaImpresion";
            this.Lb_FechaImpresion.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_FechaImpresion.SizeF = new System.Drawing.SizeF(150F, 14F);
            this.Lb_FechaImpresion.StylePriority.UseFont = false;
            this.Lb_FechaImpresion.StylePriority.UsePadding = false;
            this.Lb_FechaImpresion.StylePriority.UseTextAlignment = false;
            this.Lb_FechaImpresion.Text = "Fecha Hora Impresión";
            this.Lb_FechaImpresion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "{0} / {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(130F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 14F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.StylePriority.UsePadding = false;
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_FechaRango,
            this.L_Ruta,
            this.L_VendedorNombre,
            this.L_CEDI,
            this.headerRuta,
            this.headerVendedor,
            this.headerFecha,
            this.headerCEDI,
            this.report_Name,
            this.report_Company,
            this.logo});
            this.reportHeaderBand1.Dpi = 100F;
            this.reportHeaderBand1.HeightF = 190F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // L_FechaRango
            // 
            this.L_FechaRango.Dpi = 100F;
            this.L_FechaRango.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_FechaRango.LocationFloat = new DevExpress.Utils.PointFloat(200F, 141.1458F);
            this.L_FechaRango.Name = "L_FechaRango";
            this.L_FechaRango.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_FechaRango.SizeF = new System.Drawing.SizeF(299.8937F, 13F);
            this.L_FechaRango.StylePriority.UseFont = false;
            this.L_FechaRango.StylePriority.UsePadding = false;
            this.L_FechaRango.StylePriority.UseTextAlignment = false;
            this.L_FechaRango.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_Ruta
            // 
            this.L_Ruta.Dpi = 100F;
            this.L_Ruta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Ruta.LocationFloat = new DevExpress.Utils.PointFloat(200F, 171.1458F);
            this.L_Ruta.Name = "L_Ruta";
            this.L_Ruta.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_Ruta.SizeF = new System.Drawing.SizeF(600F, 13F);
            this.L_Ruta.StylePriority.UseFont = false;
            this.L_Ruta.StylePriority.UsePadding = false;
            this.L_Ruta.StylePriority.UseTextAlignment = false;
            this.L_Ruta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_VendedorNombre
            // 
            this.L_VendedorNombre.Dpi = 100F;
            this.L_VendedorNombre.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_VendedorNombre.LocationFloat = new DevExpress.Utils.PointFloat(200F, 156.1458F);
            this.L_VendedorNombre.Name = "L_VendedorNombre";
            this.L_VendedorNombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_VendedorNombre.SizeF = new System.Drawing.SizeF(299.8937F, 13F);
            this.L_VendedorNombre.StylePriority.UseFont = false;
            this.L_VendedorNombre.StylePriority.UsePadding = false;
            this.L_VendedorNombre.StylePriority.UseTextAlignment = false;
            this.L_VendedorNombre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_CEDI
            // 
            this.L_CEDI.Dpi = 100F;
            this.L_CEDI.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_CEDI.LocationFloat = new DevExpress.Utils.PointFloat(200F, 126.1458F);
            this.L_CEDI.Name = "L_CEDI";
            this.L_CEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_CEDI.SizeF = new System.Drawing.SizeF(299.8937F, 13F);
            this.L_CEDI.StylePriority.UseFont = false;
            this.L_CEDI.StylePriority.UsePadding = false;
            this.L_CEDI.StylePriority.UseTextAlignment = false;
            this.L_CEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // headerRuta
            // 
            this.headerRuta.Dpi = 100F;
            this.headerRuta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerRuta.LocationFloat = new DevExpress.Utils.PointFloat(0F, 171.1458F);
            this.headerRuta.Name = "headerRuta";
            this.headerRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.headerRuta.SizeF = new System.Drawing.SizeF(190F, 13F);
            this.headerRuta.StylePriority.UseFont = false;
            this.headerRuta.StylePriority.UsePadding = false;
            this.headerRuta.StylePriority.UseTextAlignment = false;
            this.headerRuta.Text = "Label_Ruta";
            this.headerRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // headerVendedor
            // 
            this.headerVendedor.Dpi = 100F;
            this.headerVendedor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerVendedor.LocationFloat = new DevExpress.Utils.PointFloat(0F, 156.1458F);
            this.headerVendedor.Name = "headerVendedor";
            this.headerVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.headerVendedor.SizeF = new System.Drawing.SizeF(190F, 13F);
            this.headerVendedor.StylePriority.UseFont = false;
            this.headerVendedor.StylePriority.UsePadding = false;
            this.headerVendedor.StylePriority.UseTextAlignment = false;
            this.headerVendedor.Text = "Label_Vendedor";
            this.headerVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // headerFecha
            // 
            this.headerFecha.Dpi = 100F;
            this.headerFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerFecha.LocationFloat = new DevExpress.Utils.PointFloat(0F, 141.1458F);
            this.headerFecha.Name = "headerFecha";
            this.headerFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.headerFecha.SizeF = new System.Drawing.SizeF(190F, 13F);
            this.headerFecha.StylePriority.UseFont = false;
            this.headerFecha.StylePriority.UsePadding = false;
            this.headerFecha.StylePriority.UseTextAlignment = false;
            this.headerFecha.Text = "Label_Fecha";
            this.headerFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // headerCEDI
            // 
            this.headerCEDI.Dpi = 100F;
            this.headerCEDI.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerCEDI.LocationFloat = new DevExpress.Utils.PointFloat(0F, 126.1458F);
            this.headerCEDI.Name = "headerCEDI";
            this.headerCEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.headerCEDI.SizeF = new System.Drawing.SizeF(190F, 13F);
            this.headerCEDI.StylePriority.UseFont = false;
            this.headerCEDI.StylePriority.UsePadding = false;
            this.headerCEDI.StylePriority.UseTextAlignment = false;
            this.headerCEDI.Text = "Label_CEDI";
            this.headerCEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // report_Name
            // 
            this.report_Name.CanGrow = false;
            this.report_Name.Dpi = 100F;
            this.report_Name.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.report_Name.LocationFloat = new DevExpress.Utils.PointFloat(170F, 55F);
            this.report_Name.Name = "report_Name";
            this.report_Name.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.report_Name.SizeF = new System.Drawing.SizeF(600F, 40F);
            this.report_Name.StyleName = "Title";
            this.report_Name.StylePriority.UseFont = false;
            this.report_Name.StylePriority.UseTextAlignment = false;
            this.report_Name.Text = "report_Name";
            this.report_Name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // report_Company
            // 
            this.report_Company.CanGrow = false;
            this.report_Company.Dpi = 100F;
            this.report_Company.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.report_Company.LocationFloat = new DevExpress.Utils.PointFloat(170F, 15F);
            this.report_Company.Name = "report_Company";
            this.report_Company.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.report_Company.SizeF = new System.Drawing.SizeF(600F, 40F);
            this.report_Company.StylePriority.UseFont = false;
            this.report_Company.StylePriority.UseTextAlignment = false;
            this.report_Company.Text = "report_Company";
            this.report_Company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(15F, 15F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(120F, 100F);
            // 
            // groupFooterBand1
            // 
            this.groupFooterBand1.Dpi = 100F;
            this.groupFooterBand1.HeightF = 1F;
            this.groupFooterBand1.Name = "groupFooterBand1";
            // 
            // groupFooterBand2
            // 
            this.groupFooterBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel28,
            this.xrLabel29,
            this.xrLabel30,
            this.xrLabel31});
            this.groupFooterBand2.Dpi = 100F;
            this.groupFooterBand2.HeightF = 20F;
            this.groupFooterBand2.Name = "groupFooterBand2";
            // 
            // xrLabel28
            // 
            this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.Descuentos")});
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(550.8334F, 0F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(89.16663F, 13F);
            this.xrLabel28.StyleName = "FieldCaption";
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UsePadding = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:n}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel28.Summary = xrSummary1;
            this.xrLabel28.Text = "xrLabel28";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel29
            // 
            this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.Devoluciones")});
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(640.4166F, 0F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(90F, 13F);
            this.xrLabel29.StyleName = "FieldCaption";
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UsePadding = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:n}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel29.Summary = xrSummary2;
            this.xrLabel29.Text = "xrLabel29";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel30
            // 
            this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.Total")});
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(730.4165F, 0F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(89.5835F, 13F);
            this.xrLabel30.StyleName = "FieldCaption";
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UsePadding = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:n}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel30.Summary = xrSummary3;
            this.xrLabel30.Text = "xrLabel30";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel31
            // 
            this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.TotalVenta")});
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(450.8334F, 0F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(99.16663F, 13F);
            this.xrLabel31.StyleName = "FieldCaption";
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UsePadding = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            xrSummary4.FormatString = "{0:n}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel31.Summary = xrSummary4;
            this.xrLabel31.Text = "xrLabel31";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // groupFooterBand3
            // 
            this.groupFooterBand3.Dpi = 100F;
            this.groupFooterBand3.HeightF = 0F;
            this.groupFooterBand3.Level = 1;
            this.groupFooterBand3.Name = "groupFooterBand3";
            // 
            // groupFooterBand4
            // 
            this.groupFooterBand4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.xrLabel48,
            this.xrLabel49,
            this.xrLabel50,
            this.xrLabel51});
            this.groupFooterBand4.Dpi = 100F;
            this.groupFooterBand4.HeightF = 30F;
            this.groupFooterBand4.Level = 2;
            this.groupFooterBand4.Name = "groupFooterBand4";
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(410.4168F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(409.5832F, 6F);
            this.xrLine1.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel48
            // 
            this.xrLabel48.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.Descuentos")});
            this.xrLabel48.Dpi = 100F;
            this.xrLabel48.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel48.LocationFloat = new DevExpress.Utils.PointFloat(550.8334F, 6.00001F);
            this.xrLabel48.Name = "xrLabel48";
            this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel48.SizeF = new System.Drawing.SizeF(89.16663F, 13F);
            this.xrLabel48.StyleName = "FieldCaption";
            this.xrLabel48.StylePriority.UseFont = false;
            this.xrLabel48.StylePriority.UsePadding = false;
            this.xrLabel48.StylePriority.UseTextAlignment = false;
            xrSummary5.FormatString = "{0:n}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel48.Summary = xrSummary5;
            this.xrLabel48.Text = "xrLabel48";
            this.xrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel49
            // 
            this.xrLabel49.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.Devoluciones")});
            this.xrLabel49.Dpi = 100F;
            this.xrLabel49.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(640.4166F, 6.00001F);
            this.xrLabel49.Name = "xrLabel49";
            this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel49.SizeF = new System.Drawing.SizeF(89.58344F, 13F);
            this.xrLabel49.StyleName = "FieldCaption";
            this.xrLabel49.StylePriority.UseFont = false;
            this.xrLabel49.StylePriority.UsePadding = false;
            this.xrLabel49.StylePriority.UseTextAlignment = false;
            xrSummary6.FormatString = "{0:n}";
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel49.Summary = xrSummary6;
            this.xrLabel49.Text = "xrLabel49";
            this.xrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel50
            // 
            this.xrLabel50.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.Total")});
            this.xrLabel50.Dpi = 100F;
            this.xrLabel50.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel50.LocationFloat = new DevExpress.Utils.PointFloat(730.4165F, 6.00001F);
            this.xrLabel50.Name = "xrLabel50";
            this.xrLabel50.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel50.SizeF = new System.Drawing.SizeF(89.5835F, 13F);
            this.xrLabel50.StyleName = "FieldCaption";
            this.xrLabel50.StylePriority.UseFont = false;
            this.xrLabel50.StylePriority.UsePadding = false;
            this.xrLabel50.StylePriority.UseTextAlignment = false;
            xrSummary7.FormatString = "{0:n}";
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel50.Summary = xrSummary7;
            this.xrLabel50.Text = "xrLabel50";
            this.xrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel51
            // 
            this.xrLabel51.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R108TotalVentas_ELE.TotalVenta")});
            this.xrLabel51.Dpi = 100F;
            this.xrLabel51.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel51.LocationFloat = new DevExpress.Utils.PointFloat(450.4167F, 6.999969F);
            this.xrLabel51.Name = "xrLabel51";
            this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel51.SizeF = new System.Drawing.SizeF(99.58331F, 13F);
            this.xrLabel51.StyleName = "FieldCaption";
            this.xrLabel51.StylePriority.UseFont = false;
            this.xrLabel51.StylePriority.UsePadding = false;
            this.xrLabel51.StylePriority.UseTextAlignment = false;
            xrSummary8.FormatString = "{0:n}";
            xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel51.Summary = xrSummary8;
            this.xrLabel51.Text = "xrLabel51";
            this.xrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine4,
            this.Lb_Total,
            this.Lb_Devoluciones,
            this.Lb_Descuentos,
            this.Lb_GTotal,
            this.Label_Cliente,
            this.Label_Clave,
            this.xrLine3});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 32.00001F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 26.00001F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(830F, 6F);
            this.xrLine4.StylePriority.UseBorderWidth = false;
            // 
            // Lb_Total
            // 
            this.Lb_Total.CanGrow = false;
            this.Lb_Total.Dpi = 100F;
            this.Lb_Total.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Total.LocationFloat = new DevExpress.Utils.PointFloat(730F, 6F);
            this.Lb_Total.Name = "Lb_Total";
            this.Lb_Total.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Total.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.Lb_Total.StylePriority.UseFont = false;
            this.Lb_Total.StylePriority.UsePadding = false;
            this.Lb_Total.StylePriority.UseTextAlignment = false;
            this.Lb_Total.Text = "Lb_Total";
            this.Lb_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Devoluciones
            // 
            this.Lb_Devoluciones.CanGrow = false;
            this.Lb_Devoluciones.Dpi = 100F;
            this.Lb_Devoluciones.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Devoluciones.LocationFloat = new DevExpress.Utils.PointFloat(640F, 6F);
            this.Lb_Devoluciones.Name = "Lb_Devoluciones";
            this.Lb_Devoluciones.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Devoluciones.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.Lb_Devoluciones.StylePriority.UseFont = false;
            this.Lb_Devoluciones.StylePriority.UsePadding = false;
            this.Lb_Devoluciones.StylePriority.UseTextAlignment = false;
            this.Lb_Devoluciones.Text = "Lb_Devoluciones";
            this.Lb_Devoluciones.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Descuentos
            // 
            this.Lb_Descuentos.CanGrow = false;
            this.Lb_Descuentos.Dpi = 100F;
            this.Lb_Descuentos.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Descuentos.LocationFloat = new DevExpress.Utils.PointFloat(550F, 6F);
            this.Lb_Descuentos.Name = "Lb_Descuentos";
            this.Lb_Descuentos.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Descuentos.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.Lb_Descuentos.StylePriority.UseFont = false;
            this.Lb_Descuentos.StylePriority.UsePadding = false;
            this.Lb_Descuentos.StylePriority.UseTextAlignment = false;
            this.Lb_Descuentos.Text = "Lb_Descuentos";
            this.Lb_Descuentos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_GTotal
            // 
            this.Lb_GTotal.CanGrow = false;
            this.Lb_GTotal.Dpi = 100F;
            this.Lb_GTotal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_GTotal.LocationFloat = new DevExpress.Utils.PointFloat(450F, 6F);
            this.Lb_GTotal.Name = "Lb_GTotal";
            this.Lb_GTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_GTotal.SizeF = new System.Drawing.SizeF(100F, 20F);
            this.Lb_GTotal.StylePriority.UseFont = false;
            this.Lb_GTotal.StylePriority.UsePadding = false;
            this.Lb_GTotal.StylePriority.UseTextAlignment = false;
            this.Lb_GTotal.Text = "Lb_GTotal";
            this.Lb_GTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label_Cliente
            // 
            this.Label_Cliente.CanGrow = false;
            this.Label_Cliente.Dpi = 100F;
            this.Label_Cliente.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Cliente.LocationFloat = new DevExpress.Utils.PointFloat(80.00005F, 6.00001F);
            this.Label_Cliente.Name = "Label_Cliente";
            this.Label_Cliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Cliente.SizeF = new System.Drawing.SizeF(370F, 20F);
            this.Label_Cliente.StylePriority.UseFont = false;
            this.Label_Cliente.StylePriority.UsePadding = false;
            this.Label_Cliente.StylePriority.UseTextAlignment = false;
            this.Label_Cliente.Text = "Label_Cliente";
            this.Label_Cliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label_Clave
            // 
            this.Label_Clave.CanGrow = false;
            this.Label_Clave.Dpi = 100F;
            this.Label_Clave.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Clave.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6F);
            this.Label_Clave.Name = "Label_Clave";
            this.Label_Clave.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Clave.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.Label_Clave.StylePriority.UseFont = false;
            this.Label_Clave.StylePriority.UsePadding = false;
            this.Label_Clave.StylePriority.UseTextAlignment = false;
            this.Label_Clave.Text = "Label_Clave";
            this.Label_Clave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(830F, 6F);
            this.xrLine3.StylePriority.UseBorderWidth = false;
            // 
            // parameterCEDI
            // 
            this.parameterCEDI.Description = "parameterCEDI";
            this.parameterCEDI.Name = "parameterCEDI";
            this.parameterCEDI.Visible = false;
            // 
            // parameterSeller
            // 
            this.parameterSeller.Description = "parameterSeller";
            this.parameterSeller.Name = "parameterSeller";
            this.parameterSeller.Visible = false;
            // 
            // parameterRoutes
            // 
            this.parameterRoutes.Description = "parameterRoutes";
            this.parameterRoutes.Name = "parameterRoutes";
            this.parameterRoutes.Visible = false;
            // 
            // parameterDateIni
            // 
            this.parameterDateIni.Description = "parameterDateIni";
            this.parameterDateIni.Name = "parameterDateIni";
            this.parameterDateIni.Visible = false;
            // 
            // parameterDateEnd
            // 
            this.parameterDateEnd.Description = "parameterDateEnd";
            this.parameterDateEnd.Name = "parameterDateEnd";
            this.parameterDateEnd.Visible = false;
            // 
            // R108_Report_Design
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.groupHeaderBand1,
            this.groupHeaderBand2,
            this.groupHeaderBand3,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.groupFooterBand2,
            this.groupFooterBand3,
            this.groupFooterBand4,
            this.PageHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_R108TotalVentas_ELE";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterCEDI,
            this.parameterSeller,
            this.parameterRoutes,
            this.parameterDateIni,
            this.parameterDateEnd});
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
