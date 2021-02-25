using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for R274_Report_Design
/// </summary>
public class R274_Report_Design : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private PageFooterBand pageFooterBand1;
    private ReportHeaderBand reportHeaderBand1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private TopMarginBand topMarginBand1;
    private BottomMarginBand bottomMarginBand1;
    public XRLabel report_Company;
    public XRLabel report_Name;
    public XRLabel headerVendedor;
    public XRPictureBox logo;
    public XRLabel headerFecha;
    public XRLabel L_FechaRango;
    public XRLabel Label_Telefono;
    public XRLabel Label_Direccion;
    private XRLabel xrLabel16;
    private XRLabel xrLabel15;
    public XRLabel L_VendedorNombre;
    private DetailReportBand DetailReport;
    private DetailBand Detail1;
    private DetailReportBand DetailReport1;
    private DetailBand Detail2;
    private DetailReportBand DetailReport2;
    private DetailBand Detail3;
    private DetailReportBand DetailReport3;
    private DetailBand Detail4;
    private DetailReportBand DetailReport4;
    private DetailBand Detail5;
    private DetailReportBand DetailReport5;
    private DetailBand Detail6;
    private DevExpress.XtraReports.Parameters.Parameter parameterSeller;
    private DevExpress.XtraReports.Parameters.Parameter parameterDateIni;
    public XRSubreport R274Sub01Productos;
    private XRSubreport R274Sub02Contado;
    private XRSubreport R274Sub03Credito;
    private XRSubreport R274Sub04Cobranza;
    private XRSubreport R274Sub05Gastos;
    private XRSubreport R274Sub06Devoluciones;
    private DetailReportBand DetailReport6;
    private DetailBand Detail7;
    private XRSubreport R274Sub07Comisiones;
    private ReportFooterBand ReportFooter;
    private XRPageInfo xrPageInfo1;
    public XRLabel Lb_FechaImpresion;
    private XRPageInfo xrPageInfo2;
    public XRLabel Lb_Liquidacion;
    public XRLabel Lb_TProductos;
    public XRLabel Lb_VtaContado;
    public XRLabel Lb_VtaCredito;
    public XRLabel Lb_TCobranza;
    public XRLabel Lb_TGastos;
    public XRLabel Lb_TComisiones;
    public XRLabel Lb_TDevolucion;
    public XRLabel Lb_TLiquidar;
    public XRLabel Lb_Recibe;
    public XRLabel Lb_Liquida;
    private XRLabel Lb_NombreFirma2;
    private XRLabel Lb_NombreFirma1;
    public XRLabel lb_totalProducto;
    public XRLabel lb_totalLiquidar;
    public XRLabel lb_totalDevoluciones;
    public XRLabel lb_totalComisiones;
    public XRLabel lb_totalGastos;
    public XRLabel lb_totalCobranza;
    public XRLabel lb_totalCredito;
    public XRLabel lb_totalContado;

    private double vtaContado;
    private double cobranza;
    private double comisiones;
    private double gastos;
    private double devoluciones;
    private DetailReportBand DetailReport7;
    private DetailBand Detail8;
    private XRSubreport R274Sub08Envases;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public R274_Report_Design()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R274_Report_Design));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Lb_FechaImpresion = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Telefono = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Direccion = new DevExpress.XtraReports.UI.XRLabel();
            this.L_FechaRango = new DevExpress.XtraReports.UI.XRLabel();
            this.headerFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.report_Company = new DevExpress.XtraReports.UI.XRLabel();
            this.report_Name = new DevExpress.XtraReports.UI.XRLabel();
            this.headerVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.L_VendedorNombre = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.parameterSeller = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDateIni = new DevExpress.XtraReports.Parameters.Parameter();
            this.DetailReport1 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail2 = new DevExpress.XtraReports.UI.DetailBand();
            this.DetailReport2 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail3 = new DevExpress.XtraReports.UI.DetailBand();
            this.DetailReport3 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail4 = new DevExpress.XtraReports.UI.DetailBand();
            this.DetailReport4 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail5 = new DevExpress.XtraReports.UI.DetailBand();
            this.DetailReport5 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail6 = new DevExpress.XtraReports.UI.DetailBand();
            this.DetailReport6 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail7 = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.lb_totalLiquidar = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_totalDevoluciones = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_totalComisiones = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_totalGastos = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_totalCobranza = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_totalCredito = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_totalContado = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_totalProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Recibe = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Liquida = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_NombreFirma2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_NombreFirma1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_TLiquidar = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_TDevolucion = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_TComisiones = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_TGastos = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_TCobranza = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_VtaCredito = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_VtaContado = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_TProductos = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Liquidacion = new DevExpress.XtraReports.UI.XRLabel();
            this.DetailReport7 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail8 = new DevExpress.XtraReports.UI.DetailBand();
            this.R274Sub01Productos = new DevExpress.XtraReports.UI.XRSubreport();
            this.R274Sub02Contado = new DevExpress.XtraReports.UI.XRSubreport();
            this.R274Sub03Credito = new DevExpress.XtraReports.UI.XRSubreport();
            this.R274Sub04Cobranza = new DevExpress.XtraReports.UI.XRSubreport();
            this.R274Sub05Gastos = new DevExpress.XtraReports.UI.XRSubreport();
            this.R274Sub06Devoluciones = new DevExpress.XtraReports.UI.XRSubreport();
            this.R274Sub07Comisiones = new DevExpress.XtraReports.UI.XRSubreport();
            this.R274Sub08Envases = new DevExpress.XtraReports.UI.XRSubreport();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 20F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "eRouteConnection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "stpr_R274Liquidacion_ROV";
            queryParameter1.Name = "@filterSellers";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterSeller]", typeof(string));
            queryParameter2.Name = "@filterDateIni";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterDateIni]", typeof(string));
            queryParameter3.Name = "@numQuery";
            queryParameter3.Type = typeof(int);
            queryParameter3.ValueInfo = "0";
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.StoredProcName = "stpr_R274Liquidacion_ROV";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // pageFooterBand1
            // 
            this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.Lb_FechaImpresion,
            this.xrPageInfo2});
            this.pageFooterBand1.Dpi = 100F;
            this.pageFooterBand1.HeightF = 20F;
            this.pageFooterBand1.Name = "pageFooterBand1";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.Format = "{0:dd/MM/yyyy hh:mm:ss tt}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(936.27F, 5F);
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
            this.Lb_FechaImpresion.LocationFloat = new DevExpress.Utils.PointFloat(786.27F, 5F);
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
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(242F, 5F);
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
            this.xrLabel16,
            this.xrLabel15,
            this.Label_Telefono,
            this.Label_Direccion,
            this.L_FechaRango,
            this.headerFecha,
            this.report_Company,
            this.report_Name,
            this.headerVendedor,
            this.L_VendedorNombre,
            this.logo});
            this.reportHeaderBand1.Dpi = 100F;
            this.reportHeaderBand1.HeightF = 170F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R274Liquidacion_ROV.Telefono")});
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(350F, 115F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.xrLabel16.StyleName = "DataField";
            this.xrLabel16.StylePriority.UseFont = false;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R274Liquidacion_ROV.Domicilio")});
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(350F, 102F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.xrLabel15.StyleName = "DataField";
            this.xrLabel15.StylePriority.UseFont = false;
            // 
            // Label_Telefono
            // 
            this.Label_Telefono.Dpi = 100F;
            this.Label_Telefono.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Telefono.LocationFloat = new DevExpress.Utils.PointFloat(243.125F, 115F);
            this.Label_Telefono.Name = "Label_Telefono";
            this.Label_Telefono.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Telefono.SizeF = new System.Drawing.SizeF(100F, 13F);
            this.Label_Telefono.StylePriority.UseFont = false;
            this.Label_Telefono.StylePriority.UsePadding = false;
            this.Label_Telefono.StylePriority.UseTextAlignment = false;
            this.Label_Telefono.Text = "Label_Telefono";
            this.Label_Telefono.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Label_Direccion
            // 
            this.Label_Direccion.Dpi = 100F;
            this.Label_Direccion.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Direccion.LocationFloat = new DevExpress.Utils.PointFloat(243.125F, 102F);
            this.Label_Direccion.Name = "Label_Direccion";
            this.Label_Direccion.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Direccion.SizeF = new System.Drawing.SizeF(100F, 13F);
            this.Label_Direccion.StylePriority.UseFont = false;
            this.Label_Direccion.StylePriority.UsePadding = false;
            this.Label_Direccion.StylePriority.UseTextAlignment = false;
            this.Label_Direccion.Text = "Label_Direccion";
            this.Label_Direccion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_FechaRango
            // 
            this.L_FechaRango.CanGrow = false;
            this.L_FechaRango.Dpi = 100F;
            this.L_FechaRango.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_FechaRango.LocationFloat = new DevExpress.Utils.PointFloat(200.83F, 151.47F);
            this.L_FechaRango.Name = "L_FechaRango";
            this.L_FechaRango.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_FechaRango.SizeF = new System.Drawing.SizeF(600F, 13F);
            this.L_FechaRango.StylePriority.UseFont = false;
            this.L_FechaRango.StylePriority.UsePadding = false;
            this.L_FechaRango.StylePriority.UseTextAlignment = false;
            this.L_FechaRango.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // headerFecha
            // 
            this.headerFecha.Dpi = 100F;
            this.headerFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerFecha.LocationFloat = new DevExpress.Utils.PointFloat(0F, 151.47F);
            this.headerFecha.Name = "headerFecha";
            this.headerFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.headerFecha.SizeF = new System.Drawing.SizeF(190F, 13F);
            this.headerFecha.StylePriority.UseFont = false;
            this.headerFecha.StylePriority.UsePadding = false;
            this.headerFecha.StylePriority.UseTextAlignment = false;
            this.headerFecha.Text = "Label_Fecha";
            this.headerFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            // headerVendedor
            // 
            this.headerVendedor.Dpi = 100F;
            this.headerVendedor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerVendedor.LocationFloat = new DevExpress.Utils.PointFloat(0F, 138.47F);
            this.headerVendedor.Name = "headerVendedor";
            this.headerVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.headerVendedor.SizeF = new System.Drawing.SizeF(190F, 13F);
            this.headerVendedor.StylePriority.UseFont = false;
            this.headerVendedor.StylePriority.UsePadding = false;
            this.headerVendedor.StylePriority.UseTextAlignment = false;
            this.headerVendedor.Text = "Label_Vendedor";
            this.headerVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_VendedorNombre
            // 
            this.L_VendedorNombre.CanGrow = false;
            this.L_VendedorNombre.Dpi = 100F;
            this.L_VendedorNombre.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_VendedorNombre.LocationFloat = new DevExpress.Utils.PointFloat(200.83F, 138.47F);
            this.L_VendedorNombre.Name = "L_VendedorNombre";
            this.L_VendedorNombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_VendedorNombre.SizeF = new System.Drawing.SizeF(600F, 13F);
            this.L_VendedorNombre.StylePriority.UseFont = false;
            this.L_VendedorNombre.StylePriority.UsePadding = false;
            this.L_VendedorNombre.StylePriority.UseTextAlignment = false;
            this.L_VendedorNombre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(15F, 15F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(120F, 100F);
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
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1});
            this.DetailReport.Dpi = 100F;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            this.DetailReport.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.R274Sub01Productos});
            this.Detail1.Dpi = 100F;
            this.Detail1.HeightF = 50F;
            this.Detail1.Name = "Detail1";
            // 
            // parameterSeller
            // 
            this.parameterSeller.Description = "parameterSeller";
            this.parameterSeller.Name = "parameterSeller";
            this.parameterSeller.ValueInfo = "R1101";
            this.parameterSeller.Visible = false;
            // 
            // parameterDateIni
            // 
            this.parameterDateIni.Description = "parameterDateIni";
            this.parameterDateIni.Name = "parameterDateIni";
            this.parameterDateIni.ValueInfo = "20200303";
            this.parameterDateIni.Visible = false;
            // 
            // DetailReport1
            // 
            this.DetailReport1.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail2});
            this.DetailReport1.Dpi = 100F;
            this.DetailReport1.Level = 1;
            this.DetailReport1.Name = "DetailReport1";
            // 
            // Detail2
            // 
            this.Detail2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.R274Sub02Contado});
            this.Detail2.Dpi = 100F;
            this.Detail2.HeightF = 50F;
            this.Detail2.Name = "Detail2";
            // 
            // DetailReport2
            // 
            this.DetailReport2.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail3});
            this.DetailReport2.Dpi = 100F;
            this.DetailReport2.Level = 2;
            this.DetailReport2.Name = "DetailReport2";
            // 
            // Detail3
            // 
            this.Detail3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.R274Sub03Credito});
            this.Detail3.Dpi = 100F;
            this.Detail3.HeightF = 50F;
            this.Detail3.Name = "Detail3";
            // 
            // DetailReport3
            // 
            this.DetailReport3.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail4});
            this.DetailReport3.Dpi = 100F;
            this.DetailReport3.Level = 3;
            this.DetailReport3.Name = "DetailReport3";
            // 
            // Detail4
            // 
            this.Detail4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.R274Sub04Cobranza});
            this.Detail4.Dpi = 100F;
            this.Detail4.HeightF = 50F;
            this.Detail4.Name = "Detail4";
            // 
            // DetailReport4
            // 
            this.DetailReport4.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail5});
            this.DetailReport4.Dpi = 100F;
            this.DetailReport4.Level = 4;
            this.DetailReport4.Name = "DetailReport4";
            // 
            // Detail5
            // 
            this.Detail5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.R274Sub05Gastos});
            this.Detail5.Dpi = 100F;
            this.Detail5.HeightF = 50F;
            this.Detail5.Name = "Detail5";
            // 
            // DetailReport5
            // 
            this.DetailReport5.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail6});
            this.DetailReport5.Dpi = 100F;
            this.DetailReport5.Level = 5;
            this.DetailReport5.Name = "DetailReport5";
            // 
            // Detail6
            // 
            this.Detail6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.R274Sub06Devoluciones});
            this.Detail6.Dpi = 100F;
            this.Detail6.HeightF = 50F;
            this.Detail6.Name = "Detail6";
            // 
            // DetailReport6
            // 
            this.DetailReport6.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail7});
            this.DetailReport6.Dpi = 100F;
            this.DetailReport6.Level = 6;
            this.DetailReport6.Name = "DetailReport6";
            this.DetailReport6.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            // 
            // Detail7
            // 
            this.Detail7.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.R274Sub07Comisiones});
            this.Detail7.Dpi = 100F;
            this.Detail7.HeightF = 50F;
            this.Detail7.Name = "Detail7";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb_totalLiquidar,
            this.lb_totalDevoluciones,
            this.lb_totalComisiones,
            this.lb_totalGastos,
            this.lb_totalCobranza,
            this.lb_totalCredito,
            this.lb_totalContado,
            this.lb_totalProducto,
            this.Lb_Recibe,
            this.Lb_Liquida,
            this.Lb_NombreFirma2,
            this.Lb_NombreFirma1,
            this.Lb_TLiquidar,
            this.Lb_TDevolucion,
            this.Lb_TComisiones,
            this.Lb_TGastos,
            this.Lb_TCobranza,
            this.Lb_VtaCredito,
            this.Lb_VtaContado,
            this.Lb_TProductos,
            this.Lb_Liquidacion});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 466.6667F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // lb_totalLiquidar
            // 
            this.lb_totalLiquidar.Dpi = 100F;
            this.lb_totalLiquidar.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalLiquidar.LocationFloat = new DevExpress.Utils.PointFloat(243.125F, 180F);
            this.lb_totalLiquidar.Name = "lb_totalLiquidar";
            this.lb_totalLiquidar.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb_totalLiquidar.SizeF = new System.Drawing.SizeF(120F, 13F);
            this.lb_totalLiquidar.StylePriority.UseFont = false;
            this.lb_totalLiquidar.StylePriority.UseTextAlignment = false;
            this.lb_totalLiquidar.Text = "lb_totalLiquidar";
            this.lb_totalLiquidar.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lb_totalLiquidar.PrintOnPage += new DevExpress.XtraReports.UI.PrintOnPageEventHandler(this.lb_totalLiquidar_PrintOnPage);
            // 
            // lb_totalDevoluciones
            // 
            this.lb_totalDevoluciones.Dpi = 100F;
            this.lb_totalDevoluciones.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalDevoluciones.LocationFloat = new DevExpress.Utils.PointFloat(243.125F, 160F);
            this.lb_totalDevoluciones.Name = "lb_totalDevoluciones";
            this.lb_totalDevoluciones.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb_totalDevoluciones.SizeF = new System.Drawing.SizeF(120F, 13F);
            this.lb_totalDevoluciones.StylePriority.UseFont = false;
            this.lb_totalDevoluciones.StylePriority.UseTextAlignment = false;
            this.lb_totalDevoluciones.Text = "lb_totalDevoluciones";
            this.lb_totalDevoluciones.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lb_totalDevoluciones.PrintOnPage += new DevExpress.XtraReports.UI.PrintOnPageEventHandler(this.lb_totalDevoluciones_PrintOnPage);
            // 
            // lb_totalComisiones
            // 
            this.lb_totalComisiones.Dpi = 100F;
            this.lb_totalComisiones.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalComisiones.LocationFloat = new DevExpress.Utils.PointFloat(243.125F, 140F);
            this.lb_totalComisiones.Name = "lb_totalComisiones";
            this.lb_totalComisiones.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb_totalComisiones.SizeF = new System.Drawing.SizeF(120F, 13F);
            this.lb_totalComisiones.StylePriority.UseFont = false;
            this.lb_totalComisiones.StylePriority.UseTextAlignment = false;
            this.lb_totalComisiones.Text = "lb_totalComisiones";
            this.lb_totalComisiones.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lb_totalComisiones.PrintOnPage += new DevExpress.XtraReports.UI.PrintOnPageEventHandler(this.lb_totalComisiones_PrintOnPage);
            // 
            // lb_totalGastos
            // 
            this.lb_totalGastos.Dpi = 100F;
            this.lb_totalGastos.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalGastos.LocationFloat = new DevExpress.Utils.PointFloat(243.125F, 120F);
            this.lb_totalGastos.Name = "lb_totalGastos";
            this.lb_totalGastos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb_totalGastos.SizeF = new System.Drawing.SizeF(120F, 13F);
            this.lb_totalGastos.StylePriority.UseFont = false;
            this.lb_totalGastos.StylePriority.UseTextAlignment = false;
            this.lb_totalGastos.Text = "lb_totalGastos";
            this.lb_totalGastos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lb_totalGastos.PrintOnPage += new DevExpress.XtraReports.UI.PrintOnPageEventHandler(this.lb_totalGastos_PrintOnPage);
            // 
            // lb_totalCobranza
            // 
            this.lb_totalCobranza.Dpi = 100F;
            this.lb_totalCobranza.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalCobranza.LocationFloat = new DevExpress.Utils.PointFloat(243.125F, 100F);
            this.lb_totalCobranza.Name = "lb_totalCobranza";
            this.lb_totalCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb_totalCobranza.SizeF = new System.Drawing.SizeF(120F, 13F);
            this.lb_totalCobranza.StylePriority.UseFont = false;
            this.lb_totalCobranza.StylePriority.UseTextAlignment = false;
            this.lb_totalCobranza.Text = "lb_totalCobranza";
            this.lb_totalCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lb_totalCobranza.PrintOnPage += new DevExpress.XtraReports.UI.PrintOnPageEventHandler(this.lb_totalCobranza_PrintOnPage);
            // 
            // lb_totalCredito
            // 
            this.lb_totalCredito.Dpi = 100F;
            this.lb_totalCredito.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalCredito.LocationFloat = new DevExpress.Utils.PointFloat(243.125F, 79.99998F);
            this.lb_totalCredito.Name = "lb_totalCredito";
            this.lb_totalCredito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb_totalCredito.SizeF = new System.Drawing.SizeF(120F, 13F);
            this.lb_totalCredito.StylePriority.UseFont = false;
            this.lb_totalCredito.StylePriority.UseTextAlignment = false;
            this.lb_totalCredito.Text = "lb_totalCredito";
            this.lb_totalCredito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lb_totalCredito.PrintOnPage += new DevExpress.XtraReports.UI.PrintOnPageEventHandler(this.lb_totalCredito_PrintOnPage);
            // 
            // lb_totalContado
            // 
            this.lb_totalContado.Dpi = 100F;
            this.lb_totalContado.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalContado.LocationFloat = new DevExpress.Utils.PointFloat(243.125F, 60.00001F);
            this.lb_totalContado.Name = "lb_totalContado";
            this.lb_totalContado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb_totalContado.SizeF = new System.Drawing.SizeF(120F, 13F);
            this.lb_totalContado.StylePriority.UseFont = false;
            this.lb_totalContado.StylePriority.UseTextAlignment = false;
            this.lb_totalContado.Text = "lb_totalContado";
            this.lb_totalContado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lb_totalContado.PrintOnPage += new DevExpress.XtraReports.UI.PrintOnPageEventHandler(this.lb_totalContado_PrintOnPage);
            // 
            // lb_totalProducto
            // 
            this.lb_totalProducto.Dpi = 100F;
            this.lb_totalProducto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalProducto.LocationFloat = new DevExpress.Utils.PointFloat(243.125F, 39.99999F);
            this.lb_totalProducto.Name = "lb_totalProducto";
            this.lb_totalProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb_totalProducto.SizeF = new System.Drawing.SizeF(120F, 13F);
            this.lb_totalProducto.StylePriority.UseFont = false;
            this.lb_totalProducto.StylePriority.UseTextAlignment = false;
            this.lb_totalProducto.Text = "lb_totalProducto";
            this.lb_totalProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lb_totalProducto.PrintOnPage += new DevExpress.XtraReports.UI.PrintOnPageEventHandler(this.lb_totalProducto_PrintOnPage);
            // 
            // Lb_Recibe
            // 
            this.Lb_Recibe.CanGrow = false;
            this.Lb_Recibe.Dpi = 100F;
            this.Lb_Recibe.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Recibe.LocationFloat = new DevExpress.Utils.PointFloat(650F, 250F);
            this.Lb_Recibe.Name = "Lb_Recibe";
            this.Lb_Recibe.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_Recibe.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_Recibe.StylePriority.UseFont = false;
            this.Lb_Recibe.StylePriority.UsePadding = false;
            this.Lb_Recibe.StylePriority.UseTextAlignment = false;
            this.Lb_Recibe.Text = "Recibe";
            this.Lb_Recibe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Liquida
            // 
            this.Lb_Liquida.CanGrow = false;
            this.Lb_Liquida.Dpi = 100F;
            this.Lb_Liquida.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Liquida.LocationFloat = new DevExpress.Utils.PointFloat(300F, 250F);
            this.Lb_Liquida.Name = "Lb_Liquida";
            this.Lb_Liquida.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_Liquida.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_Liquida.StylePriority.UseFont = false;
            this.Lb_Liquida.StylePriority.UsePadding = false;
            this.Lb_Liquida.StylePriority.UseTextAlignment = false;
            this.Lb_Liquida.Text = "Liquida";
            this.Lb_Liquida.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_NombreFirma2
            // 
            this.Lb_NombreFirma2.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Lb_NombreFirma2.Dpi = 100F;
            this.Lb_NombreFirma2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_NombreFirma2.LocationFloat = new DevExpress.Utils.PointFloat(650F, 350F);
            this.Lb_NombreFirma2.Name = "Lb_NombreFirma2";
            this.Lb_NombreFirma2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_NombreFirma2.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_NombreFirma2.StylePriority.UseBorders = false;
            this.Lb_NombreFirma2.StylePriority.UseFont = false;
            this.Lb_NombreFirma2.StylePriority.UseTextAlignment = false;
            this.Lb_NombreFirma2.Text = "Nombre y Firma";
            this.Lb_NombreFirma2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_NombreFirma1
            // 
            this.Lb_NombreFirma1.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Lb_NombreFirma1.Dpi = 100F;
            this.Lb_NombreFirma1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_NombreFirma1.LocationFloat = new DevExpress.Utils.PointFloat(300F, 350F);
            this.Lb_NombreFirma1.Name = "Lb_NombreFirma1";
            this.Lb_NombreFirma1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_NombreFirma1.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_NombreFirma1.StylePriority.UseBorders = false;
            this.Lb_NombreFirma1.StylePriority.UseFont = false;
            this.Lb_NombreFirma1.StylePriority.UseTextAlignment = false;
            this.Lb_NombreFirma1.Text = "Nombre y Firma";
            this.Lb_NombreFirma1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_TLiquidar
            // 
            this.Lb_TLiquidar.CanGrow = false;
            this.Lb_TLiquidar.Dpi = 100F;
            this.Lb_TLiquidar.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_TLiquidar.LocationFloat = new DevExpress.Utils.PointFloat(0F, 180F);
            this.Lb_TLiquidar.Name = "Lb_TLiquidar";
            this.Lb_TLiquidar.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_TLiquidar.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_TLiquidar.StylePriority.UseFont = false;
            this.Lb_TLiquidar.StylePriority.UsePadding = false;
            this.Lb_TLiquidar.StylePriority.UseTextAlignment = false;
            this.Lb_TLiquidar.Text = "Total a Liquidar";
            this.Lb_TLiquidar.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_TDevolucion
            // 
            this.Lb_TDevolucion.CanGrow = false;
            this.Lb_TDevolucion.Dpi = 100F;
            this.Lb_TDevolucion.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_TDevolucion.LocationFloat = new DevExpress.Utils.PointFloat(0F, 160F);
            this.Lb_TDevolucion.Name = "Lb_TDevolucion";
            this.Lb_TDevolucion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_TDevolucion.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_TDevolucion.StylePriority.UseFont = false;
            this.Lb_TDevolucion.StylePriority.UsePadding = false;
            this.Lb_TDevolucion.StylePriority.UseTextAlignment = false;
            this.Lb_TDevolucion.Text = "Total Devoluciones";
            this.Lb_TDevolucion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_TComisiones
            // 
            this.Lb_TComisiones.CanGrow = false;
            this.Lb_TComisiones.Dpi = 100F;
            this.Lb_TComisiones.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_TComisiones.LocationFloat = new DevExpress.Utils.PointFloat(0F, 140F);
            this.Lb_TComisiones.Name = "Lb_TComisiones";
            this.Lb_TComisiones.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_TComisiones.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_TComisiones.StylePriority.UseFont = false;
            this.Lb_TComisiones.StylePriority.UsePadding = false;
            this.Lb_TComisiones.StylePriority.UseTextAlignment = false;
            this.Lb_TComisiones.Text = "Total de Comisiones";
            this.Lb_TComisiones.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_TGastos
            // 
            this.Lb_TGastos.CanGrow = false;
            this.Lb_TGastos.Dpi = 100F;
            this.Lb_TGastos.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_TGastos.LocationFloat = new DevExpress.Utils.PointFloat(0F, 120F);
            this.Lb_TGastos.Name = "Lb_TGastos";
            this.Lb_TGastos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_TGastos.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_TGastos.StylePriority.UseFont = false;
            this.Lb_TGastos.StylePriority.UsePadding = false;
            this.Lb_TGastos.StylePriority.UseTextAlignment = false;
            this.Lb_TGastos.Text = "Total de Gastos de Vendedor";
            this.Lb_TGastos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_TCobranza
            // 
            this.Lb_TCobranza.CanGrow = false;
            this.Lb_TCobranza.Dpi = 100F;
            this.Lb_TCobranza.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_TCobranza.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
            this.Lb_TCobranza.Name = "Lb_TCobranza";
            this.Lb_TCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_TCobranza.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_TCobranza.StylePriority.UseFont = false;
            this.Lb_TCobranza.StylePriority.UsePadding = false;
            this.Lb_TCobranza.StylePriority.UseTextAlignment = false;
            this.Lb_TCobranza.Text = "Total Cobranza";
            this.Lb_TCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_VtaCredito
            // 
            this.Lb_VtaCredito.CanGrow = false;
            this.Lb_VtaCredito.Dpi = 100F;
            this.Lb_VtaCredito.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_VtaCredito.LocationFloat = new DevExpress.Utils.PointFloat(0F, 80F);
            this.Lb_VtaCredito.Name = "Lb_VtaCredito";
            this.Lb_VtaCredito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_VtaCredito.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_VtaCredito.StylePriority.UseFont = false;
            this.Lb_VtaCredito.StylePriority.UsePadding = false;
            this.Lb_VtaCredito.StylePriority.UseTextAlignment = false;
            this.Lb_VtaCredito.Text = "Total de Ventas a Crédito";
            this.Lb_VtaCredito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_VtaContado
            // 
            this.Lb_VtaContado.CanGrow = false;
            this.Lb_VtaContado.Dpi = 100F;
            this.Lb_VtaContado.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_VtaContado.LocationFloat = new DevExpress.Utils.PointFloat(0F, 60F);
            this.Lb_VtaContado.Name = "Lb_VtaContado";
            this.Lb_VtaContado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_VtaContado.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_VtaContado.StylePriority.UseFont = false;
            this.Lb_VtaContado.StylePriority.UsePadding = false;
            this.Lb_VtaContado.StylePriority.UseTextAlignment = false;
            this.Lb_VtaContado.Text = "Total de Ventas de Contado";
            this.Lb_VtaContado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_TProductos
            // 
            this.Lb_TProductos.CanGrow = false;
            this.Lb_TProductos.Dpi = 100F;
            this.Lb_TProductos.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_TProductos.LocationFloat = new DevExpress.Utils.PointFloat(0F, 40F);
            this.Lb_TProductos.Name = "Lb_TProductos";
            this.Lb_TProductos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_TProductos.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_TProductos.StylePriority.UseFont = false;
            this.Lb_TProductos.StylePriority.UsePadding = false;
            this.Lb_TProductos.StylePriority.UseTextAlignment = false;
            this.Lb_TProductos.Text = "Total de Ventas de Productos";
            this.Lb_TProductos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_Liquidacion
            // 
            this.Lb_Liquidacion.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.Lb_Liquidacion.Dpi = 100F;
            this.Lb_Liquidacion.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Liquidacion.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 20.00001F);
            this.Lb_Liquidacion.Name = "Lb_Liquidacion";
            this.Lb_Liquidacion.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Liquidacion.SizeF = new System.Drawing.SizeF(1079.583F, 13F);
            this.Lb_Liquidacion.StylePriority.UseBorders = false;
            this.Lb_Liquidacion.StylePriority.UseFont = false;
            this.Lb_Liquidacion.StylePriority.UsePadding = false;
            this.Lb_Liquidacion.StylePriority.UseTextAlignment = false;
            this.Lb_Liquidacion.Text = "Lb_Liquidacion";
            this.Lb_Liquidacion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailReport7
            // 
            this.DetailReport7.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail8});
            this.DetailReport7.Dpi = 100F;
            this.DetailReport7.Level = 7;
            this.DetailReport7.Name = "DetailReport7";
            // 
            // Detail8
            // 
            this.Detail8.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.R274Sub08Envases});
            this.Detail8.Dpi = 100F;
            this.Detail8.HeightF = 50F;
            this.Detail8.Name = "Detail8";
            // 
            // R274Sub01Productos
            // 
            this.R274Sub01Productos.Dpi = 100F;
            this.R274Sub01Productos.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.R274Sub01Productos.Name = "R274Sub01Productos";
            this.R274Sub01Productos.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.R274Sub01Productos.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", this.parameterDateIni));
            this.R274Sub01Productos.ReportSource = new R274_Sub01Productos();
            this.R274Sub01Productos.SizeF = new System.Drawing.SizeF(1079.583F, 50F);
            // 
            // R274Sub02Contado
            // 
            this.R274Sub02Contado.Dpi = 100F;
            this.R274Sub02Contado.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.R274Sub02Contado.Name = "R274Sub02Contado";
            this.R274Sub02Contado.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.R274Sub02Contado.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", this.parameterDateIni));
            this.R274Sub02Contado.ReportSource = new R274_Sub02Contado();
            this.R274Sub02Contado.SizeF = new System.Drawing.SizeF(1079.583F, 50F);
            // 
            // R274Sub03Credito
            // 
            this.R274Sub03Credito.Dpi = 100F;
            this.R274Sub03Credito.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.R274Sub03Credito.Name = "R274Sub03Credito";
            this.R274Sub03Credito.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.R274Sub03Credito.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", this.parameterDateIni));
            this.R274Sub03Credito.ReportSource = new R274_Sub03Credito();
            this.R274Sub03Credito.SizeF = new System.Drawing.SizeF(1079.583F, 50F);
            // 
            // R274Sub04Cobranza
            // 
            this.R274Sub04Cobranza.Dpi = 100F;
            this.R274Sub04Cobranza.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.R274Sub04Cobranza.Name = "R274Sub04Cobranza";
            this.R274Sub04Cobranza.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.R274Sub04Cobranza.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", this.parameterDateIni));
            this.R274Sub04Cobranza.ReportSource = new R274_Sub04Cobranza();
            this.R274Sub04Cobranza.SizeF = new System.Drawing.SizeF(1079.583F, 50F);
            // 
            // R274Sub05Gastos
            // 
            this.R274Sub05Gastos.Dpi = 100F;
            this.R274Sub05Gastos.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.R274Sub05Gastos.Name = "R274Sub05Gastos";
            this.R274Sub05Gastos.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.R274Sub05Gastos.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", this.parameterDateIni));
            this.R274Sub05Gastos.ReportSource = new R274_Sub05Gastos();
            this.R274Sub05Gastos.SizeF = new System.Drawing.SizeF(1079.583F, 50F);
            // 
            // R274Sub06Devoluciones
            // 
            this.R274Sub06Devoluciones.Dpi = 100F;
            this.R274Sub06Devoluciones.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.R274Sub06Devoluciones.Name = "R274Sub06Devoluciones";
            this.R274Sub06Devoluciones.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.R274Sub06Devoluciones.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", this.parameterDateIni));
            this.R274Sub06Devoluciones.ReportSource = new R274_Sub06Devoluciones();
            this.R274Sub06Devoluciones.SizeF = new System.Drawing.SizeF(1079.583F, 50F);
            // 
            // R274Sub07Comisiones
            // 
            this.R274Sub07Comisiones.Dpi = 100F;
            this.R274Sub07Comisiones.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.R274Sub07Comisiones.Name = "R274Sub07Comisiones";
            this.R274Sub07Comisiones.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.R274Sub07Comisiones.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", this.parameterDateIni));
            this.R274Sub07Comisiones.ReportSource = new R274_Sub07Comisiones();
            this.R274Sub07Comisiones.SizeF = new System.Drawing.SizeF(1079.583F, 50F);
            // 
            // R274Sub08Envases
            // 
            this.R274Sub08Envases.Dpi = 100F;
            this.R274Sub08Envases.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.R274Sub08Envases.Name = "R274Sub08Envases";
            this.R274Sub08Envases.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", this.parameterDateIni));
            this.R274Sub08Envases.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.R274Sub08Envases.ReportSource = new R274_Sub08Envases();
            this.R274Sub08Envases.SizeF = new System.Drawing.SizeF(1079.583F, 50F);
            // 
            // R274_Report_Design
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.topMarginBand1,
            this.bottomMarginBand1,
            this.DetailReport,
            this.DetailReport1,
            this.DetailReport2,
            this.DetailReport3,
            this.DetailReport4,
            this.DetailReport5,
            this.DetailReport6,
            this.ReportFooter,
            this.DetailReport7});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_R274Liquidacion_ROV";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterSeller,
            this.parameterDateIni});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "16.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.R274_Report_Design_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void R274_Report_Design_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }

    private void lb_totalProducto_PrintOnPage(object sender, PrintOnPageEventArgs e)
    {
        this.lb_totalProducto.Text = (R274Sub01Productos.ReportSource != null ? ((XRLabel)R274Sub01Productos.ReportSource.FindControl("totalProductos", false)).Text : "0");

        if (String.IsNullOrEmpty(this.lb_totalProducto.Text))
        {
            this.lb_totalProducto.Text = "0.00";
        }
    }

    private void lb_totalContado_PrintOnPage(object sender, PrintOnPageEventArgs e)
    {
        string contado = (R274Sub02Contado.ReportSource != null ? ((XRLabel)R274Sub02Contado.ReportSource.FindControl("totalContado", false)).Text : "0");
        this.vtaContado = (String.IsNullOrEmpty(contado) ? 0.00 : Convert.ToDouble(contado));
        this.lb_totalContado.Text = (R274Sub02Contado.ReportSource != null ? "$" + ((XRLabel)R274Sub02Contado.ReportSource.FindControl("totalContado", false)).Text : "0");
        if (String.IsNullOrEmpty(this.lb_totalContado.Text))
        {
            this.lb_totalContado.Text = "$0.00";
        }
    }

    private void lb_totalCredito_PrintOnPage(object sender, PrintOnPageEventArgs e)
    {
        string credito = (R274Sub03Credito.ReportSource != null ? ((XRLabel)R274Sub03Credito.ReportSource.FindControl("totalCredito", false)).Text : "0");
        this.lb_totalCredito.Text = (String.IsNullOrEmpty(credito) ? "$0.00" : "$" + credito);
    }

    private void lb_totalCobranza_PrintOnPage(object sender, PrintOnPageEventArgs e)
    {
        string cobranz = (R274Sub04Cobranza.ReportSource != null ? ((XRLabel)R274Sub04Cobranza.ReportSource.FindControl("totalCobranza", false)).Text : "0");
        this.cobranza = (String.IsNullOrEmpty(cobranz) ? 0.00 : Convert.ToDouble(cobranz));
        this.lb_totalCobranza.Text = (String.IsNullOrEmpty(cobranz) ? "$0.00" : "$" + cobranz);
    }

    private void lb_totalGastos_PrintOnPage(object sender, PrintOnPageEventArgs e)
    {
        string gasto = (R274Sub05Gastos.ReportSource != null ? ((XRLabel)R274Sub05Gastos.ReportSource.FindControl("totalGastos", false)).Text : "0");
        this.gastos = (String.IsNullOrEmpty(gasto) ? 0.00 : Convert.ToDouble(gasto.Substring(1)));
        this.lb_totalGastos.Text = (R274Sub05Gastos.ReportSource != null ? ((XRLabel)R274Sub05Gastos.ReportSource.FindControl("totalGastos", false)).Text : "0");
        if (String.IsNullOrEmpty(this.lb_totalGastos.Text))
        {
            this.lb_totalGastos.Text = "$0.00";
        }
    }

    private void lb_totalComisiones_PrintOnPage(object sender, PrintOnPageEventArgs e)
    {
        string comision = ((XRLabel)R274Sub07Comisiones.ReportSource.FindControl("totalComisiones", false)).Text;
        this.comisiones = (String.IsNullOrEmpty(comision) ? 0.00 : Convert.ToDouble(comision.Substring(1)));
        this.lb_totalComisiones.Text = (R274Sub07Comisiones.ReportSource != null ? ((XRLabel)R274Sub07Comisiones.ReportSource.FindControl("totalComisiones", false)).Text : "0");
        if (String.IsNullOrEmpty(this.lb_totalComisiones.Text))
        {
            this.lb_totalComisiones.Text = "$0.00";
        }
    }

    private void lb_totalDevoluciones_PrintOnPage(object sender, PrintOnPageEventArgs e)
    {
        string devolucion = (R274Sub06Devoluciones.ReportSource != null ? ((XRLabel)R274Sub06Devoluciones.ReportSource.FindControl("totalDevoluciones", false)).Text : "0");
        this.devoluciones = (String.IsNullOrEmpty(devolucion) ? 0.00 : Convert.ToDouble(devolucion.Substring(1)));
        this.lb_totalDevoluciones.Text = (R274Sub06Devoluciones.ReportSource != null ? ((XRLabel)R274Sub06Devoluciones.ReportSource.FindControl("totalDevoluciones", false)).Text : "0");
        if (String.IsNullOrEmpty(this.lb_totalDevoluciones.Text))
        {
            this.lb_totalDevoluciones.Text = "$0.00";
        }
    }

    private void lb_totalLiquidar_PrintOnPage(object sender, PrintOnPageEventArgs e)
    {
        double liquidar = this.vtaContado + this.cobranza - this.comisiones - this.gastos - this.devoluciones;
        this.lb_totalLiquidar.Text = string.Format("{0:$###,##0.00}", liquidar);
    }
}
