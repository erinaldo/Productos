using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for R092_Report_Design
/// </summary>
public class R092_Report_Design : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private XRLabel xrLabel26;
    private XRLabel xrLabel28;
    private XRLabel xrLabel29;
    private XRLabel xrLabel30;
    private XRLabel xrLabel31;
    private XRLabel xrLabel32;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel2;
    private GroupHeaderBand groupHeaderBand2;
    private XRLabel xrLabel4;
    private GroupHeaderBand groupHeaderBand3;
    private XRLabel xrLabel6;
    private GroupHeaderBand groupHeaderBand4;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private GroupHeaderBand groupHeaderBand5;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private PageFooterBand pageFooterBand1;
    private ReportHeaderBand reportHeaderBand1;
    public XRPictureBox logo;
    public XRLabel L_FechaRango;
    public XRLabel L_Ruta;
    public XRLabel L_VendedorNombre;
    public XRLabel L_CEDI;
    public XRLabel headerRuta;
    public XRLabel headerVendedor;
    public XRLabel headerFecha;
    public XRLabel headerCEDI;
    public XRLabel report_Name;
    public XRLabel report_Company;
    private GroupFooterBand groupFooterBand1;
    private GroupFooterBand groupFooterBand2;
    private XRLabel xrLabel36;
    private XRLabel xrLabel37;
    private XRLabel xrLabel38;
    private XRLabel xrLabel39;
    private GroupFooterBand groupFooterBand3;
    private GroupFooterBand groupFooterBand4;
    private GroupFooterBand groupFooterBand5;
    private GroupFooterBand groupFooterBand6;
    private ReportFooterBand reportFooterBand1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private TopMarginBand topMarginBand1;
    private BottomMarginBand bottomMarginBand1;
    public XRLabel Lb_CEDI_Grupo;
    public XRLabel Lb_Fecha_Grupo;
    public XRLabel Lb_Vendedor_Grupo;
    public XRLabel Lb_Ruta_Grupo;
    private PageHeaderBand PageHeader;
    private XRLine xrLine3;
    public XRLabel Label_Clave;
    public XRLabel Label_Nombre;
    public XRLabel Label_Descuentos;
    public XRLabel Label_Total;
    public XRLabel Label_Unidades;
    public XRLabel Label_Importe;
    private XRLine xrLine1;
    public XRLabel Label_Marca;
    public XRLabel Lb_Total;
    private XRSubreport xrSubreport1;
    private DevExpress.XtraReports.Parameters.Parameter parameterCedi;
    private DevExpress.XtraReports.Parameters.Parameter parameterSeller;
    private DevExpress.XtraReports.Parameters.Parameter parameterRoutes;
    private DevExpress.XtraReports.Parameters.Parameter parameterDateIni;
    private DevExpress.XtraReports.Parameters.Parameter parameterDateEnd;
    private XRSubreport xrSubreport2;
    private XRSubreport xrSubreport3;
    private XRSubreport xrSubreport4;
    private XRSubreport xrSubreport5;
    private XRPageInfo xrPageInfo2;
    public XRLabel Lb_FechaImpresion;
    private XRPageInfo xrPageInfo1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public R092_Report_Design()
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
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R092_Report_Design));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Lb_CEDI_Grupo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Lb_Fecha_Grupo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Lb_Vendedor_Grupo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Lb_Ruta_Grupo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Label_Marca = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Lb_FechaImpresion = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
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
            this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.groupFooterBand2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.Lb_Total = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupFooterBand3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.parameterCedi = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterSeller = new DevExpress.XtraReports.Parameters.Parameter();
            this.groupFooterBand4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrSubreport2 = new DevExpress.XtraReports.UI.XRSubreport();
            this.groupFooterBand5 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrSubreport3 = new DevExpress.XtraReports.UI.XRSubreport();
            this.parameterRoutes = new DevExpress.XtraReports.Parameters.Parameter();
            this.groupFooterBand6 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrSubreport4 = new DevExpress.XtraReports.UI.XRSubreport();
            this.parameterDateIni = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDateEnd = new DevExpress.XtraReports.Parameters.Parameter();
            this.reportFooterBand1 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrSubreport5 = new DevExpress.XtraReports.UI.XRSubreport();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.Label_Unidades = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Importe = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Descuentos = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Total = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Nombre = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Clave = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel26,
            this.xrLabel28,
            this.xrLabel29,
            this.xrLabel30,
            this.xrLabel31,
            this.xrLabel32});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 13F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "DataField";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel26
            // 
            this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.Descuentos", "{0:c}")});
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(630.4165F, 0F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(99.5835F, 13F);
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UsePadding = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "xrLabel26";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel28
            // 
            this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.Importe", "{0:c}")});
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(530.4166F, 0F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(99.58337F, 13F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UsePadding = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "xrLabel28";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel29
            // 
            this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.Producto")});
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(100.4167F, 0F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(329.5833F, 13F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.Text = "xrLabel29";
            // 
            // xrLabel30
            // 
            this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.ProductoClave")});
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(99.58331F, 13F);
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.Text = "xrLabel30";
            // 
            // xrLabel31
            // 
            this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.Total", "{0:c}")});
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(730.4165F, 0F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(99.5835F, 13F);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UsePadding = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "xrLabel31";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel32
            // 
            this.xrLabel32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.Unidades")});
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(430.4166F, 0F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(99.58337F, 13F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UsePadding = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "xrLabel32";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "eRouteConnection";
            this.sqlDataSource1.ConnectionOptions.CommandTimeout = 800;
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "stpr_R092VentasPorMarca";
            queryParameter1.Name = "@filterCedi";
            queryParameter1.Type = typeof(string);
            queryParameter1.ValueInfo = "1";
            queryParameter2.Name = "@filterSeller";
            queryParameter2.Type = typeof(string);
            queryParameter3.Name = "@filterRoutes";
            queryParameter3.Type = typeof(string);
            queryParameter3.ValueInfo = "1001,1002,1003,1004,1005,1006,1007,1008,1009,1010,1011,1012,1013,1014,1015,1016,1" +
    "017,1018,1019,1020,99,RUT003,RUTCOB0,RUTF00";
            queryParameter4.Name = "@filterDateIni";
            queryParameter4.Type = typeof(string);
            queryParameter4.ValueInfo = "20191101";
            queryParameter5.Name = "@filterDateEnd";
            queryParameter5.Type = typeof(string);
            queryParameter5.ValueInfo = "20191110";
            queryParameter6.Name = "@numQuery";
            queryParameter6.Type = typeof(int);
            queryParameter6.ValueInfo = "0";
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.Parameters.Add(queryParameter6);
            storedProcQuery1.StoredProcName = "stpr_R092VentasPorMarca";
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
            this.groupHeaderBand1.HeightF = 15F;
            this.groupHeaderBand1.Level = 4;
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
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.CEDI")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(198.1748F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(300F, 13F);
            this.xrLabel2.StyleName = "DataField";
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // groupHeaderBand2
            // 
            this.groupHeaderBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Lb_Fecha_Grupo,
            this.xrLabel4});
            this.groupHeaderBand2.Dpi = 100F;
            this.groupHeaderBand2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Fecha", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand2.HeightF = 15F;
            this.groupHeaderBand2.Level = 3;
            this.groupHeaderBand2.Name = "groupHeaderBand2";
            // 
            // Lb_Fecha_Grupo
            // 
            this.Lb_Fecha_Grupo.Dpi = 100F;
            this.Lb_Fecha_Grupo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Fecha_Grupo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Lb_Fecha_Grupo.Name = "Lb_Fecha_Grupo";
            this.Lb_Fecha_Grupo.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 0, 0, 0, 100F);
            this.Lb_Fecha_Grupo.SizeF = new System.Drawing.SizeF(190F, 13F);
            this.Lb_Fecha_Grupo.StylePriority.UseFont = false;
            this.Lb_Fecha_Grupo.StylePriority.UsePadding = false;
            this.Lb_Fecha_Grupo.StylePriority.UseTextAlignment = false;
            this.Lb_Fecha_Grupo.Text = "Label_Fecha";
            this.Lb_Fecha_Grupo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.Fecha", "{0:dd/MM/yyyy}")});
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(198.1748F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(300F, 13F);
            this.xrLabel4.StyleName = "DataField";
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // groupHeaderBand3
            // 
            this.groupHeaderBand3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Lb_Vendedor_Grupo,
            this.xrLabel6});
            this.groupHeaderBand3.Dpi = 100F;
            this.groupHeaderBand3.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Vendedor", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand3.HeightF = 15F;
            this.groupHeaderBand3.Level = 2;
            this.groupHeaderBand3.Name = "groupHeaderBand3";
            // 
            // Lb_Vendedor_Grupo
            // 
            this.Lb_Vendedor_Grupo.Dpi = 100F;
            this.Lb_Vendedor_Grupo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Vendedor_Grupo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Lb_Vendedor_Grupo.Name = "Lb_Vendedor_Grupo";
            this.Lb_Vendedor_Grupo.Padding = new DevExpress.XtraPrinting.PaddingInfo(30, 0, 0, 0, 100F);
            this.Lb_Vendedor_Grupo.SizeF = new System.Drawing.SizeF(190F, 13F);
            this.Lb_Vendedor_Grupo.StylePriority.UseFont = false;
            this.Lb_Vendedor_Grupo.StylePriority.UsePadding = false;
            this.Lb_Vendedor_Grupo.StylePriority.UseTextAlignment = false;
            this.Lb_Vendedor_Grupo.Text = "Label_Vendedor";
            this.Lb_Vendedor_Grupo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.Vendedor")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(198.1748F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(300F, 13F);
            this.xrLabel6.StyleName = "DataField";
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // groupHeaderBand4
            // 
            this.groupHeaderBand4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Lb_Ruta_Grupo,
            this.xrLabel9,
            this.xrLabel10});
            this.groupHeaderBand4.Dpi = 100F;
            this.groupHeaderBand4.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("RUTClave", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("RutaNombre", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand4.HeightF = 18F;
            this.groupHeaderBand4.Level = 1;
            this.groupHeaderBand4.Name = "groupHeaderBand4";
            // 
            // Lb_Ruta_Grupo
            // 
            this.Lb_Ruta_Grupo.Dpi = 100F;
            this.Lb_Ruta_Grupo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Ruta_Grupo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Lb_Ruta_Grupo.Name = "Lb_Ruta_Grupo";
            this.Lb_Ruta_Grupo.Padding = new DevExpress.XtraPrinting.PaddingInfo(45, 0, 0, 0, 100F);
            this.Lb_Ruta_Grupo.SizeF = new System.Drawing.SizeF(170F, 13F);
            this.Lb_Ruta_Grupo.StylePriority.UseFont = false;
            this.Lb_Ruta_Grupo.StylePriority.UsePadding = false;
            this.Lb_Ruta_Grupo.StylePriority.UseTextAlignment = false;
            this.Lb_Ruta_Grupo.Text = "Label_Ruta";
            this.Lb_Ruta_Grupo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.RUTClave")});
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(180F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(90F, 13F);
            this.xrLabel9.StyleName = "DataField";
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.RutaNombre")});
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(270F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(250F, 13F);
            this.xrLabel10.StyleName = "DataField";
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "xrLabel10";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // groupHeaderBand5
            // 
            this.groupHeaderBand5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Label_Marca,
            this.xrLabel13,
            this.xrLabel14});
            this.groupHeaderBand5.Dpi = 100F;
            this.groupHeaderBand5.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Clave", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Nombre", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand5.HeightF = 13F;
            this.groupHeaderBand5.Name = "groupHeaderBand5";
            // 
            // Label_Marca
            // 
            this.Label_Marca.Dpi = 100F;
            this.Label_Marca.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Marca.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Label_Marca.Name = "Label_Marca";
            this.Label_Marca.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Marca.SizeF = new System.Drawing.SizeF(110F, 13F);
            this.Label_Marca.StylePriority.UseFont = false;
            this.Label_Marca.StylePriority.UsePadding = false;
            this.Label_Marca.StylePriority.UseTextAlignment = false;
            this.Label_Marca.Text = "Marca";
            this.Label_Marca.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.Clave")});
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(120F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(90F, 13F);
            this.xrLabel13.StyleName = "DataField";
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "xrLabel13";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.Nombre")});
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(210F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(250F, 13F);
            this.xrLabel14.StyleName = "DataField";
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "xrLabel14";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // pageFooterBand1
            // 
            this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.Lb_FechaImpresion,
            this.xrPageInfo1});
            this.pageFooterBand1.Dpi = 100F;
            this.pageFooterBand1.HeightF = 18F;
            this.pageFooterBand1.Name = "pageFooterBand1";
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
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.L_FechaRango,
            this.L_Ruta,
            this.L_VendedorNombre,
            this.L_CEDI,
            this.headerRuta,
            this.headerVendedor,
            this.headerFecha,
            this.headerCEDI,
            this.report_Name,
            this.report_Company});
            this.reportHeaderBand1.Dpi = 100F;
            this.reportHeaderBand1.HeightF = 180F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(14.9999F, 11.29165F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(120F, 100F);
            // 
            // L_FechaRango
            // 
            this.L_FechaRango.Dpi = 100F;
            this.L_FechaRango.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_FechaRango.LocationFloat = new DevExpress.Utils.PointFloat(191.1301F, 155.7083F);
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
            this.L_Ruta.CanGrow = false;
            this.L_Ruta.Dpi = 100F;
            this.L_Ruta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Ruta.LocationFloat = new DevExpress.Utils.PointFloat(191.1301F, 142.7083F);
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
            this.L_VendedorNombre.LocationFloat = new DevExpress.Utils.PointFloat(191.1301F, 129.7084F);
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
            this.L_CEDI.LocationFloat = new DevExpress.Utils.PointFloat(191.1301F, 116.7083F);
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
            this.headerRuta.LocationFloat = new DevExpress.Utils.PointFloat(0F, 142.7083F);
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
            this.headerVendedor.LocationFloat = new DevExpress.Utils.PointFloat(0F, 129.7084F);
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
            this.headerFecha.LocationFloat = new DevExpress.Utils.PointFloat(0F, 155.7083F);
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
            this.headerCEDI.LocationFloat = new DevExpress.Utils.PointFloat(0F, 116.7083F);
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
            this.report_Name.LocationFloat = new DevExpress.Utils.PointFloat(170F, 51.29166F);
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
            this.report_Company.LocationFloat = new DevExpress.Utils.PointFloat(170F, 11.29165F);
            this.report_Company.Name = "report_Company";
            this.report_Company.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.report_Company.SizeF = new System.Drawing.SizeF(600F, 40F);
            this.report_Company.StylePriority.UseFont = false;
            this.report_Company.StylePriority.UseTextAlignment = false;
            this.report_Company.Text = "report_Company";
            this.report_Company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
            this.Lb_Total,
            this.xrLabel36,
            this.xrLabel37,
            this.xrLabel38,
            this.xrLabel39});
            this.groupFooterBand2.Dpi = 100F;
            this.groupFooterBand2.HeightF = 15F;
            this.groupFooterBand2.Name = "groupFooterBand2";
            // 
            // Lb_Total
            // 
            this.Lb_Total.CanGrow = false;
            this.Lb_Total.Dpi = 100F;
            this.Lb_Total.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Total.LocationFloat = new DevExpress.Utils.PointFloat(198.1748F, 0F);
            this.Lb_Total.Name = "Lb_Total";
            this.Lb_Total.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_Total.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_Total.StylePriority.UseFont = false;
            this.Lb_Total.StylePriority.UsePadding = false;
            this.Lb_Total.StylePriority.UseTextAlignment = false;
            this.Lb_Total.Text = "Lb_Total";
            this.Lb_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel36
            // 
            this.xrLabel36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.Descuentos")});
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(630.8331F, 0F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(99.16693F, 13F);
            this.xrLabel36.StyleName = "FieldCaption";
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UsePadding = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:c}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel36.Summary = xrSummary1;
            this.xrLabel36.Text = "xrLabel36";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel37
            // 
            this.xrLabel37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.Importe")});
            this.xrLabel37.Dpi = 100F;
            this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(530.8333F, 0F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(99.16669F, 13F);
            this.xrLabel37.StyleName = "FieldCaption";
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.StylePriority.UsePadding = false;
            this.xrLabel37.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:c}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel37.Summary = xrSummary2;
            this.xrLabel37.Text = "xrLabel37";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel38
            // 
            this.xrLabel38.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.Total")});
            this.xrLabel38.Dpi = 100F;
            this.xrLabel38.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(730.4165F, 0F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(99.5835F, 13F);
            this.xrLabel38.StyleName = "FieldCaption";
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.StylePriority.UsePadding = false;
            this.xrLabel38.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:c}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel38.Summary = xrSummary3;
            this.xrLabel38.Text = "xrLabel38";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel39
            // 
            this.xrLabel39.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R092VentasPorMarca.Unidades")});
            this.xrLabel39.Dpi = 100F;
            this.xrLabel39.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(430.4166F, 0F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(99.58337F, 13F);
            this.xrLabel39.StyleName = "FieldCaption";
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.StylePriority.UsePadding = false;
            this.xrLabel39.StylePriority.UseTextAlignment = false;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel39.Summary = xrSummary4;
            this.xrLabel39.Text = "xrLabel39";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // groupFooterBand3
            // 
            this.groupFooterBand3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport1});
            this.groupFooterBand3.Dpi = 100F;
            this.groupFooterBand3.HeightF = 25F;
            this.groupFooterBand3.Level = 1;
            this.groupFooterBand3.Name = "groupFooterBand3";
            // 
            // xrSubreport1
            // 
            this.xrSubreport1.Dpi = 100F;
            this.xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 4.999987F);
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterCedi", this.parameterCedi));
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterRoutes", null, "stpr_R092VentasPorMarca.RUTClave"));
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", null, "stpr_R092VentasPorMarca.FechaFormato"));
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateEnd", null, "stpr_R092VentasPorMarca.FechaFormato"));
            this.xrSubreport1.ReportSource = new R092_SubReport_02();
            this.xrSubreport1.SizeF = new System.Drawing.SizeF(829.58F, 20F);
            // 
            // parameterCedi
            // 
            this.parameterCedi.Description = "parameterCedi";
            this.parameterCedi.Name = "parameterCedi";
            this.parameterCedi.ValueInfo = "1";
            this.parameterCedi.Visible = false;
            // 
            // parameterSeller
            // 
            this.parameterSeller.Description = "parameterSeller";
            this.parameterSeller.Name = "parameterSeller";
            this.parameterSeller.Visible = false;
            // 
            // groupFooterBand4
            // 
            this.groupFooterBand4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport2});
            this.groupFooterBand4.Dpi = 100F;
            this.groupFooterBand4.HeightF = 30F;
            this.groupFooterBand4.Level = 2;
            this.groupFooterBand4.Name = "groupFooterBand4";
            // 
            // xrSubreport2
            // 
            this.xrSubreport2.Dpi = 100F;
            this.xrSubreport2.LocationFloat = new DevExpress.Utils.PointFloat(0.42F, 0F);
            this.xrSubreport2.Name = "xrSubreport2";
            this.xrSubreport2.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterCedi", this.parameterCedi));
            this.xrSubreport2.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.xrSubreport2.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterRoutes", null, "stpr_R092VentasPorMarca.RUTClave"));
            this.xrSubreport2.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", null, "stpr_R092VentasPorMarca.FechaFormato"));
            this.xrSubreport2.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateEnd", null, "stpr_R092VentasPorMarca.FechaFormato"));
            this.xrSubreport2.ReportSource = new R092_SubReport_03();
            this.xrSubreport2.SizeF = new System.Drawing.SizeF(829.58F, 20F);
            // 
            // groupFooterBand5
            // 
            this.groupFooterBand5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport3});
            this.groupFooterBand5.Dpi = 100F;
            this.groupFooterBand5.HeightF = 30F;
            this.groupFooterBand5.Level = 3;
            this.groupFooterBand5.Name = "groupFooterBand5";
            // 
            // xrSubreport3
            // 
            this.xrSubreport3.Dpi = 100F;
            this.xrSubreport3.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.xrSubreport3.Name = "xrSubreport3";
            this.xrSubreport3.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterCedi", this.parameterCedi));
            this.xrSubreport3.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.xrSubreport3.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterRoutes", this.parameterRoutes));
            this.xrSubreport3.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", null, "stpr_R092VentasPorMarca.FechaFormato"));
            this.xrSubreport3.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateEnd", null, "stpr_R092VentasPorMarca.FechaFormato"));
            this.xrSubreport3.ReportSource = new R092_SubReport_04();
            this.xrSubreport3.SizeF = new System.Drawing.SizeF(829.58F, 20F);
            // 
            // parameterRoutes
            // 
            this.parameterRoutes.Description = "parameterRoutes";
            this.parameterRoutes.Name = "parameterRoutes";
            this.parameterRoutes.ValueInfo = "1001,1002,1003,1004,1005,1006,1007,1008,1009,1010,1011,1012,1013,1014,1015,1016,1" +
    "017,1018,1019,1020,99,RUT003,RUTCOB0,RUTF00";
            this.parameterRoutes.Visible = false;
            // 
            // groupFooterBand6
            // 
            this.groupFooterBand6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport4});
            this.groupFooterBand6.Dpi = 100F;
            this.groupFooterBand6.HeightF = 30F;
            this.groupFooterBand6.Level = 4;
            this.groupFooterBand6.Name = "groupFooterBand6";
            // 
            // xrSubreport4
            // 
            this.xrSubreport4.Dpi = 100F;
            this.xrSubreport4.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.xrSubreport4.Name = "xrSubreport4";
            this.xrSubreport4.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterCedi", this.parameterCedi));
            this.xrSubreport4.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.xrSubreport4.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterRoutes", this.parameterRoutes));
            this.xrSubreport4.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", this.parameterDateIni));
            this.xrSubreport4.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateEnd", this.parameterDateEnd));
            this.xrSubreport4.ReportSource = new R092_SubReport_05();
            this.xrSubreport4.SizeF = new System.Drawing.SizeF(829.5833F, 20F);
            // 
            // parameterDateIni
            // 
            this.parameterDateIni.Description = "parameterDateIni";
            this.parameterDateIni.Name = "parameterDateIni";
            this.parameterDateIni.ValueInfo = "20191101";
            this.parameterDateIni.Visible = false;
            // 
            // parameterDateEnd
            // 
            this.parameterDateEnd.Description = "parameterDateEnd";
            this.parameterDateEnd.Name = "parameterDateEnd";
            this.parameterDateEnd.ValueInfo = "20191110";
            this.parameterDateEnd.Visible = false;
            // 
            // reportFooterBand1
            // 
            this.reportFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport5});
            this.reportFooterBand1.Dpi = 100F;
            this.reportFooterBand1.HeightF = 70F;
            this.reportFooterBand1.Name = "reportFooterBand1";
            // 
            // xrSubreport5
            // 
            this.xrSubreport5.Dpi = 100F;
            this.xrSubreport5.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 9.999974F);
            this.xrSubreport5.Name = "xrSubreport5";
            this.xrSubreport5.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterCedi", this.parameterCedi));
            this.xrSubreport5.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.xrSubreport5.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterRoutes", this.parameterRoutes));
            this.xrSubreport5.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", this.parameterDateIni));
            this.xrSubreport5.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateEnd", this.parameterDateEnd));
            this.xrSubreport5.ReportSource = new R092_SubReport_06();
            this.xrSubreport5.SizeF = new System.Drawing.SizeF(829.58F, 50F);
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
            // topMarginBand1
            // 
            this.topMarginBand1.Dpi = 100F;
            this.topMarginBand1.HeightF = 10F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Dpi = 100F;
            this.bottomMarginBand1.HeightF = 10F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.Label_Unidades,
            this.Label_Importe,
            this.Label_Descuentos,
            this.Label_Total,
            this.Label_Nombre,
            this.Label_Clave,
            this.xrLine3});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 32F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 26F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(830F, 6F);
            this.xrLine1.StylePriority.UseBorderWidth = false;
            // 
            // Label_Unidades
            // 
            this.Label_Unidades.CanGrow = false;
            this.Label_Unidades.Dpi = 100F;
            this.Label_Unidades.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Unidades.LocationFloat = new DevExpress.Utils.PointFloat(430F, 6F);
            this.Label_Unidades.Name = "Label_Unidades";
            this.Label_Unidades.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 10, 0, 0, 100F);
            this.Label_Unidades.SizeF = new System.Drawing.SizeF(100F, 20F);
            this.Label_Unidades.StylePriority.UseFont = false;
            this.Label_Unidades.StylePriority.UsePadding = false;
            this.Label_Unidades.StylePriority.UseTextAlignment = false;
            this.Label_Unidades.Text = "Label_Unidades";
            this.Label_Unidades.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Label_Importe
            // 
            this.Label_Importe.CanGrow = false;
            this.Label_Importe.Dpi = 100F;
            this.Label_Importe.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Importe.LocationFloat = new DevExpress.Utils.PointFloat(530F, 6F);
            this.Label_Importe.Name = "Label_Importe";
            this.Label_Importe.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 10, 0, 0, 100F);
            this.Label_Importe.SizeF = new System.Drawing.SizeF(100F, 20F);
            this.Label_Importe.StylePriority.UseFont = false;
            this.Label_Importe.StylePriority.UsePadding = false;
            this.Label_Importe.StylePriority.UseTextAlignment = false;
            this.Label_Importe.Text = "Label_Importe";
            this.Label_Importe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Label_Descuentos
            // 
            this.Label_Descuentos.CanGrow = false;
            this.Label_Descuentos.Dpi = 100F;
            this.Label_Descuentos.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Descuentos.LocationFloat = new DevExpress.Utils.PointFloat(630F, 6F);
            this.Label_Descuentos.Name = "Label_Descuentos";
            this.Label_Descuentos.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 10, 0, 0, 100F);
            this.Label_Descuentos.SizeF = new System.Drawing.SizeF(100F, 20F);
            this.Label_Descuentos.StylePriority.UseFont = false;
            this.Label_Descuentos.StylePriority.UsePadding = false;
            this.Label_Descuentos.StylePriority.UseTextAlignment = false;
            this.Label_Descuentos.Text = "Label_Descuentos";
            this.Label_Descuentos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Label_Total
            // 
            this.Label_Total.CanGrow = false;
            this.Label_Total.Dpi = 100F;
            this.Label_Total.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Total.LocationFloat = new DevExpress.Utils.PointFloat(730F, 6F);
            this.Label_Total.Name = "Label_Total";
            this.Label_Total.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 10, 0, 0, 100F);
            this.Label_Total.SizeF = new System.Drawing.SizeF(100F, 20F);
            this.Label_Total.StylePriority.UseFont = false;
            this.Label_Total.StylePriority.UsePadding = false;
            this.Label_Total.StylePriority.UseTextAlignment = false;
            this.Label_Total.Text = "Label_Total";
            this.Label_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Label_Nombre
            // 
            this.Label_Nombre.CanGrow = false;
            this.Label_Nombre.Dpi = 100F;
            this.Label_Nombre.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Nombre.LocationFloat = new DevExpress.Utils.PointFloat(100F, 5.999994F);
            this.Label_Nombre.Name = "Label_Nombre";
            this.Label_Nombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 0, 0, 0, 100F);
            this.Label_Nombre.SizeF = new System.Drawing.SizeF(330F, 20F);
            this.Label_Nombre.StylePriority.UseFont = false;
            this.Label_Nombre.StylePriority.UsePadding = false;
            this.Label_Nombre.StylePriority.UseTextAlignment = false;
            this.Label_Nombre.Text = "Label_Nombre";
            this.Label_Nombre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Label_Clave
            // 
            this.Label_Clave.Dpi = 100F;
            this.Label_Clave.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Clave.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6F);
            this.Label_Clave.Name = "Label_Clave";
            this.Label_Clave.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100F);
            this.Label_Clave.SizeF = new System.Drawing.SizeF(100F, 20F);
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
            // R092_Report_Design
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.groupHeaderBand1,
            this.groupHeaderBand2,
            this.groupHeaderBand3,
            this.groupHeaderBand4,
            this.groupHeaderBand5,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.groupFooterBand2,
            this.groupFooterBand3,
            this.groupFooterBand4,
            this.groupFooterBand5,
            this.groupFooterBand6,
            this.reportFooterBand1,
            this.topMarginBand1,
            this.bottomMarginBand1,
            this.PageHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_R092VentasPorMarca";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterCedi,
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
