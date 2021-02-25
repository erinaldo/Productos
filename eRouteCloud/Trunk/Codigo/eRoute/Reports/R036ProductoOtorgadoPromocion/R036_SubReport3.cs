using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for R036_SubReport3
/// </summary>
public class R036_SubReport3 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRLabel xrLabel22;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel2;
    private GroupHeaderBand groupHeaderBand2;
    private XRLabel xrLabel4;
    private GroupHeaderBand groupHeaderBand3;
    private ReportHeaderBand reportHeaderBand1;
    private GroupFooterBand groupFooterBand1;
    private GroupFooterBand groupFooterBand2;
    private GroupFooterBand groupFooterBand3;
    private ReportFooterBand reportFooterBand1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private TopMarginBand topMarginBand1;
    private BottomMarginBand bottomMarginBand1;
    public XRLabel Label_ProducNoEntr;
    private XRLine xrLine3;
    public XRLabel Label_Producto;
    public XRLabel Label_Unidad;
    public XRLabel Label_Cantidad;
    public XRLabel Label_Saldo;
    public XRLabel Label_Pedidos;
    public XRLabel Label_Fecha;
    public XRLabel Label_Promocion;
    public XRLabel Label_Cliente;
    public XRLabel Label_FechaFase;
    public XRLabel Label_Fase;
    private XRLine xrLine4;
    public XRLabel Lb_Ruta_Grupo;
    public XRLabel Lb_Vendedor_Grupo;
    private DevExpress.XtraReports.Parameters.Parameter parameterSeller;
    private DevExpress.XtraReports.Parameters.Parameter parameterRoutes;
    private DevExpress.XtraReports.Parameters.Parameter parameterDateIni;
    private DevExpress.XtraReports.Parameters.Parameter parameterDateEnd;
    private XRSubreport xrSubreport1;
    private XRSubreport xrSubreport2;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public R036_SubReport3()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R036_SubReport3));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Lb_Ruta_Grupo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Lb_Vendedor_Grupo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.Label_Fase = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_FechaFase = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Cliente = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Promocion = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Pedidos = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Saldo = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Cantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Unidad = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Producto = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.Label_ProducNoEntr = new DevExpress.XtraReports.UI.XRLabel();
            this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.groupFooterBand2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.parameterDateIni = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDateEnd = new DevExpress.XtraReports.Parameters.Parameter();
            this.groupFooterBand3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.reportFooterBand1 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.parameterSeller = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterRoutes = new DevExpress.XtraReports.Parameters.Parameter();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrSubreport2 = new DevExpress.XtraReports.UI.XRSubreport();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel21,
            this.xrLabel22,
            this.xrLabel23,
            this.xrLabel24,
            this.xrLabel25});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 13F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "DataField";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R036ProductoOtorgadoPromo.Cantidad", "{0:n}")});
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(250.4167F, 0F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(64.58331F, 13F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "xrLabel16";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel17
            // 
            this.xrLabel17.CanGrow = false;
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R036ProductoOtorgadoPromo.Cliente")});
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(725.4167F, 0F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(199.5834F, 13F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "xrLabel17";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R036ProductoOtorgadoPromo.Fase")});
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(925.0001F, 0F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(74.58F, 13F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "xrLabel18";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel19
            // 
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R036ProductoOtorgadoPromo.Fecha", "{0:dd/MM/yyyy}")});
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(465.4167F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(79.58328F, 13F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "xrLabel19";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R036ProductoOtorgadoPromo.FechaFase", "{0:dd/MM/yyyy}")});
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(999.58F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(74.58331F, 13F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "xrLabel20";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R036ProductoOtorgadoPromo.Pedido")});
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(380.4167F, 0F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(84.58331F, 13F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "xrLabel21";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel22
            // 
            this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R036ProductoOtorgadoPromo.Producto")});
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(189.5833F, 13F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "xrLabel22";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel23
            // 
            this.xrLabel23.CanGrow = false;
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R036ProductoOtorgadoPromo.Promocion")});
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(545.4167F, 0F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(179.5833F, 13F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "xrLabel23";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel24
            // 
            this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R036ProductoOtorgadoPromo.Saldo", "{0:n}")});
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(315.4167F, 0F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(64.58331F, 13F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "xrLabel24";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel25
            // 
            this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R036ProductoOtorgadoPromo.Unidad")});
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(190.4167F, 0F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(59.58328F, 13F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "xrLabel25";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "eRouteConnection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "stpr_R036ProductoOtorgadoPromo";
            queryParameter1.Name = "@filterSeller";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterSeller]", typeof(string));
            queryParameter2.Name = "@filterRoutes";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterRoutes]", typeof(string));
            queryParameter3.Name = "@filterDateIni";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterDateIni]", typeof(string));
            queryParameter4.Name = "@filterDateEnd";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterDateEnd]", typeof(string));
            queryParameter5.Name = "@numQuery";
            queryParameter5.Type = typeof(int);
            queryParameter5.ValueInfo = "3";
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.StoredProcName = "stpr_R036ProductoOtorgadoPromo";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // groupHeaderBand1
            // 
            this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Lb_Ruta_Grupo,
            this.xrLabel2});
            this.groupHeaderBand1.Dpi = 100F;
            this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Ruta", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand1.HeightF = 15F;
            this.groupHeaderBand1.Level = 2;
            this.groupHeaderBand1.Name = "groupHeaderBand1";
            // 
            // Lb_Ruta_Grupo
            // 
            this.Lb_Ruta_Grupo.Dpi = 100F;
            this.Lb_Ruta_Grupo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Ruta_Grupo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Lb_Ruta_Grupo.Name = "Lb_Ruta_Grupo";
            this.Lb_Ruta_Grupo.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Ruta_Grupo.SizeF = new System.Drawing.SizeF(190F, 13F);
            this.Lb_Ruta_Grupo.StylePriority.UseFont = false;
            this.Lb_Ruta_Grupo.StylePriority.UsePadding = false;
            this.Lb_Ruta_Grupo.StylePriority.UseTextAlignment = false;
            this.Lb_Ruta_Grupo.Text = "Ruta";
            this.Lb_Ruta_Grupo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R036ProductoOtorgadoPromo.Ruta")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(209.72F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(250F, 13F);
            this.xrLabel2.StyleName = "DataField";
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
            this.groupHeaderBand2.HeightF = 15F;
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
            this.Lb_Vendedor_Grupo.Text = "Vendedor";
            this.Lb_Vendedor_Grupo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R036ProductoOtorgadoPromo.Vendedor")});
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(209.72F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(250F, 13F);
            this.xrLabel4.StyleName = "DataField";
            this.xrLabel4.Text = "xrLabel4";
            // 
            // groupHeaderBand3
            // 
            this.groupHeaderBand3.Dpi = 100F;
            this.groupHeaderBand3.HeightF = 27F;
            this.groupHeaderBand3.Name = "groupHeaderBand3";
            this.groupHeaderBand3.StyleName = "FieldCaption";
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine4,
            this.Label_Fase,
            this.Label_FechaFase,
            this.Label_Cliente,
            this.Label_Promocion,
            this.Label_Fecha,
            this.Label_Pedidos,
            this.Label_Saldo,
            this.Label_Cantidad,
            this.Label_Unidad,
            this.Label_Producto,
            this.xrLine3,
            this.Label_ProducNoEntr});
            this.reportHeaderBand1.Dpi = 100F;
            this.reportHeaderBand1.HeightF = 60F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 47F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(1075F, 2F);
            // 
            // Label_Fase
            // 
            this.Label_Fase.CanGrow = false;
            this.Label_Fase.Dpi = 100F;
            this.Label_Fase.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Fase.LocationFloat = new DevExpress.Utils.PointFloat(925.0001F, 27F);
            this.Label_Fase.Name = "Label_Fase";
            this.Label_Fase.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Fase.SizeF = new System.Drawing.SizeF(75F, 20F);
            this.Label_Fase.StylePriority.UseFont = false;
            this.Label_Fase.StylePriority.UsePadding = false;
            this.Label_Fase.StylePriority.UseTextAlignment = false;
            this.Label_Fase.Text = "Fase";
            this.Label_Fase.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label_FechaFase
            // 
            this.Label_FechaFase.CanGrow = false;
            this.Label_FechaFase.Dpi = 100F;
            this.Label_FechaFase.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_FechaFase.LocationFloat = new DevExpress.Utils.PointFloat(1000F, 27F);
            this.Label_FechaFase.Name = "Label_FechaFase";
            this.Label_FechaFase.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_FechaFase.SizeF = new System.Drawing.SizeF(79.16675F, 20F);
            this.Label_FechaFase.StylePriority.UseFont = false;
            this.Label_FechaFase.StylePriority.UsePadding = false;
            this.Label_FechaFase.StylePriority.UseTextAlignment = false;
            this.Label_FechaFase.Text = "Fecha Fase";
            this.Label_FechaFase.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label_Cliente
            // 
            this.Label_Cliente.CanGrow = false;
            this.Label_Cliente.Dpi = 100F;
            this.Label_Cliente.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Cliente.LocationFloat = new DevExpress.Utils.PointFloat(725.0001F, 27F);
            this.Label_Cliente.Name = "Label_Cliente";
            this.Label_Cliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Cliente.SizeF = new System.Drawing.SizeF(200F, 20F);
            this.Label_Cliente.StylePriority.UseFont = false;
            this.Label_Cliente.StylePriority.UsePadding = false;
            this.Label_Cliente.StylePriority.UseTextAlignment = false;
            this.Label_Cliente.Text = "Cliente";
            this.Label_Cliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label_Promocion
            // 
            this.Label_Promocion.CanGrow = false;
            this.Label_Promocion.Dpi = 100F;
            this.Label_Promocion.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Promocion.LocationFloat = new DevExpress.Utils.PointFloat(545.0001F, 27F);
            this.Label_Promocion.Name = "Label_Promocion";
            this.Label_Promocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Promocion.SizeF = new System.Drawing.SizeF(180F, 20F);
            this.Label_Promocion.StylePriority.UseFont = false;
            this.Label_Promocion.StylePriority.UsePadding = false;
            this.Label_Promocion.StylePriority.UseTextAlignment = false;
            this.Label_Promocion.Text = "Promocion";
            this.Label_Promocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label_Fecha
            // 
            this.Label_Fecha.CanGrow = false;
            this.Label_Fecha.Dpi = 100F;
            this.Label_Fecha.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Fecha.LocationFloat = new DevExpress.Utils.PointFloat(465F, 27F);
            this.Label_Fecha.Name = "Label_Fecha";
            this.Label_Fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Fecha.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.Label_Fecha.StylePriority.UseFont = false;
            this.Label_Fecha.StylePriority.UsePadding = false;
            this.Label_Fecha.StylePriority.UseTextAlignment = false;
            this.Label_Fecha.Text = "Fecha";
            this.Label_Fecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label_Pedidos
            // 
            this.Label_Pedidos.CanGrow = false;
            this.Label_Pedidos.Dpi = 100F;
            this.Label_Pedidos.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Pedidos.LocationFloat = new DevExpress.Utils.PointFloat(380.0001F, 27F);
            this.Label_Pedidos.Name = "Label_Pedidos";
            this.Label_Pedidos.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 10, 0, 0, 100F);
            this.Label_Pedidos.SizeF = new System.Drawing.SizeF(85F, 20F);
            this.Label_Pedidos.StylePriority.UseFont = false;
            this.Label_Pedidos.StylePriority.UsePadding = false;
            this.Label_Pedidos.StylePriority.UseTextAlignment = false;
            this.Label_Pedidos.Text = "Pedido";
            this.Label_Pedidos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Label_Saldo
            // 
            this.Label_Saldo.CanGrow = false;
            this.Label_Saldo.Dpi = 100F;
            this.Label_Saldo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Saldo.LocationFloat = new DevExpress.Utils.PointFloat(315F, 27F);
            this.Label_Saldo.Name = "Label_Saldo";
            this.Label_Saldo.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Saldo.SizeF = new System.Drawing.SizeF(65F, 20F);
            this.Label_Saldo.StylePriority.UseFont = false;
            this.Label_Saldo.StylePriority.UsePadding = false;
            this.Label_Saldo.StylePriority.UseTextAlignment = false;
            this.Label_Saldo.Text = "Saldo";
            this.Label_Saldo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label_Cantidad
            // 
            this.Label_Cantidad.CanGrow = false;
            this.Label_Cantidad.Dpi = 100F;
            this.Label_Cantidad.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Cantidad.LocationFloat = new DevExpress.Utils.PointFloat(250F, 27F);
            this.Label_Cantidad.Name = "Label_Cantidad";
            this.Label_Cantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Cantidad.SizeF = new System.Drawing.SizeF(65F, 20F);
            this.Label_Cantidad.StylePriority.UseFont = false;
            this.Label_Cantidad.StylePriority.UsePadding = false;
            this.Label_Cantidad.StylePriority.UseTextAlignment = false;
            this.Label_Cantidad.Text = "Cantidad";
            this.Label_Cantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Label_Unidad
            // 
            this.Label_Unidad.CanGrow = false;
            this.Label_Unidad.Dpi = 100F;
            this.Label_Unidad.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Unidad.LocationFloat = new DevExpress.Utils.PointFloat(190F, 27F);
            this.Label_Unidad.Name = "Label_Unidad";
            this.Label_Unidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Unidad.SizeF = new System.Drawing.SizeF(60F, 20F);
            this.Label_Unidad.StylePriority.UseFont = false;
            this.Label_Unidad.StylePriority.UsePadding = false;
            this.Label_Unidad.StylePriority.UseTextAlignment = false;
            this.Label_Unidad.Text = "Unidad";
            this.Label_Unidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Label_Producto
            // 
            this.Label_Producto.Dpi = 100F;
            this.Label_Producto.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Producto.LocationFloat = new DevExpress.Utils.PointFloat(0F, 27F);
            this.Label_Producto.Name = "Label_Producto";
            this.Label_Producto.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Producto.SizeF = new System.Drawing.SizeF(190F, 20F);
            this.Label_Producto.StylePriority.UseFont = false;
            this.Label_Producto.StylePriority.UsePadding = false;
            this.Label_Producto.StylePriority.UseTextAlignment = false;
            this.Label_Producto.Text = "Producto";
            this.Label_Producto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(1075F, 2F);
            // 
            // Label_ProducNoEntr
            // 
            this.Label_ProducNoEntr.Dpi = 100F;
            this.Label_ProducNoEntr.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ProducNoEntr.LocationFloat = new DevExpress.Utils.PointFloat(20F, 5F);
            this.Label_ProducNoEntr.Name = "Label_ProducNoEntr";
            this.Label_ProducNoEntr.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_ProducNoEntr.SizeF = new System.Drawing.SizeF(327.317F, 20F);
            this.Label_ProducNoEntr.StylePriority.UseFont = false;
            this.Label_ProducNoEntr.StylePriority.UsePadding = false;
            this.Label_ProducNoEntr.StylePriority.UseTextAlignment = false;
            this.Label_ProducNoEntr.Text = "Productos No Entregados";
            this.Label_ProducNoEntr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            this.xrSubreport1});
            this.groupFooterBand2.Dpi = 100F;
            this.groupFooterBand2.HeightF = 100F;
            this.groupFooterBand2.Level = 1;
            this.groupFooterBand2.Name = "groupFooterBand2";
            // 
            // parameterDateIni
            // 
            this.parameterDateIni.Description = "parameterDateIni";
            this.parameterDateIni.Name = "parameterDateIni";
            this.parameterDateIni.ValueInfo = "20180101";
            this.parameterDateIni.Visible = false;
            // 
            // parameterDateEnd
            // 
            this.parameterDateEnd.Description = "parameterDateEnd";
            this.parameterDateEnd.Name = "parameterDateEnd";
            this.parameterDateEnd.ValueInfo = "20201104";
            this.parameterDateEnd.Visible = false;
            // 
            // groupFooterBand3
            // 
            this.groupFooterBand3.Dpi = 100F;
            this.groupFooterBand3.HeightF = 10F;
            this.groupFooterBand3.Level = 2;
            this.groupFooterBand3.Name = "groupFooterBand3";
            // 
            // reportFooterBand1
            // 
            this.reportFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport2});
            this.reportFooterBand1.Dpi = 100F;
            this.reportFooterBand1.HeightF = 100F;
            this.reportFooterBand1.Name = "reportFooterBand1";
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
            this.parameterRoutes.ValueInfo = "SCC1,SCC10,SCC2,SCC3,SCC4";
            this.parameterRoutes.Visible = false;
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
            // xrSubreport1
            // 
            this.xrSubreport1.Dpi = 100F;
            this.xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(0.42F, 20F);
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", null, "stpr_R036ProductoOtorgadoPromo.VendedorID"));
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterRoutes", null, "stpr_R036ProductoOtorgadoPromo.Ruta"));
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", this.parameterDateIni));
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateEnd", this.parameterDateEnd));
            this.xrSubreport1.ReportSource = new R036_SubReport4();
            this.xrSubreport1.SizeF = new System.Drawing.SizeF(1079.58F, 50F);
            // 
            // xrSubreport2
            // 
            this.xrSubreport2.Dpi = 100F;
            this.xrSubreport2.LocationFloat = new DevExpress.Utils.PointFloat(0.42F, 20F);
            this.xrSubreport2.Name = "xrSubreport2";
            this.xrSubreport2.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterSeller", this.parameterSeller));
            this.xrSubreport2.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterRoutes", this.parameterRoutes));
            this.xrSubreport2.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateIni", this.parameterDateIni));
            this.xrSubreport2.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterDateEnd", this.parameterDateEnd));
            this.xrSubreport2.ReportSource = new R036_SubReport5();
            this.xrSubreport2.SizeF = new System.Drawing.SizeF(1079.58F, 50F);
            // 
            // R036_SubReport3
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.groupHeaderBand1,
            this.groupHeaderBand2,
            this.groupHeaderBand3,
            this.reportHeaderBand1,
            this.groupFooterBand2,
            this.groupFooterBand3,
            this.reportFooterBand1,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_R036ProductoOtorgadoPromo";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterSeller,
            this.parameterRoutes,
            this.parameterDateIni,
            this.parameterDateEnd});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
