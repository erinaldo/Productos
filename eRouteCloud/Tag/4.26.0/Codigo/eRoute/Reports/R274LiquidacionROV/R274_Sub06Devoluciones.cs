using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Diagnostics;

/// <summary>
/// Summary description for R274_Sub06Devoluciones
/// </summary>
public class R274_Sub06Devoluciones : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private ReportHeaderBand reportHeaderBand1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private TopMarginBand topMarginBand1;
    private BottomMarginBand bottomMarginBand1;
    public XRLabel Lb_Devoluciones;
    public XRLabel Label_Cliente;
    public XRLabel Label_Producto;
    public XRLabel Label_Motivo;
    public XRLabel Label_Cantidad;
    public XRLabel Label_Total;
    private ReportFooterBand ReportFooter;
    private XRLabel totalDevoluciones;
    public XRLabel Lb_TDevolucion;
    private DevExpress.XtraReports.Parameters.Parameter parameterSeller;
    private DevExpress.XtraReports.Parameters.Parameter parameterDateIni;
    private string TotalDevolucion;
    private XRLabel xrLabel1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public R274_Sub06Devoluciones()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R274_Sub06Devoluciones));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Label_Total = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Cantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Motivo = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Producto = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Cliente = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Devoluciones = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_TDevolucion = new DevExpress.XtraReports.UI.XRLabel();
            this.totalDevoluciones = new DevExpress.XtraReports.UI.XRLabel();
            this.parameterSeller = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDateIni = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel10});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 13F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R274Liquidacion_ROV.Cliente")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0.8333842F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(349.1666F, 13F);
            this.xrLabel6.StyleName = "DataField";
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R274Liquidacion_ROV.Motivo")});
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(570.4167F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(229.5833F, 13F);
            this.xrLabel7.StyleName = "DataField";
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R274Liquidacion_ROV.Pieza", "{0:n}")});
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(800.4167F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(99.58344F, 13F);
            this.xrLabel8.StyleName = "DataField";
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UsePadding = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R274Liquidacion_ROV.Producto")});
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(350.4167F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(219.5833F, 13F);
            this.xrLabel9.StyleName = "DataField";
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R274Liquidacion_ROV.Total", "{0:c}")});
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(900.4167F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(100F, 13F);
            this.xrLabel10.StyleName = "DataField";
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UsePadding = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            queryParameter3.ValueInfo = "6";
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.StoredProcName = "stpr_R274Liquidacion_ROV";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Label_Total,
            this.Label_Cantidad,
            this.Label_Motivo,
            this.Label_Producto,
            this.Label_Cliente,
            this.Lb_Devoluciones});
            this.reportHeaderBand1.Dpi = 100F;
            this.reportHeaderBand1.HeightF = 60F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // Label_Total
            // 
            this.Label_Total.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Label_Total.Dpi = 100F;
            this.Label_Total.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Total.LocationFloat = new DevExpress.Utils.PointFloat(900.4167F, 25F);
            this.Label_Total.Name = "Label_Total";
            this.Label_Total.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Total.SizeF = new System.Drawing.SizeF(179.5833F, 35F);
            this.Label_Total.StylePriority.UseBorders = false;
            this.Label_Total.StylePriority.UseFont = false;
            this.Label_Total.StylePriority.UsePadding = false;
            this.Label_Total.StylePriority.UseTextAlignment = false;
            this.Label_Total.Text = "Total";
            this.Label_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label_Cantidad
            // 
            this.Label_Cantidad.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Label_Cantidad.Dpi = 100F;
            this.Label_Cantidad.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Cantidad.LocationFloat = new DevExpress.Utils.PointFloat(800.0001F, 25F);
            this.Label_Cantidad.Name = "Label_Cantidad";
            this.Label_Cantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Cantidad.SizeF = new System.Drawing.SizeF(100F, 35F);
            this.Label_Cantidad.StylePriority.UseBorders = false;
            this.Label_Cantidad.StylePriority.UseFont = false;
            this.Label_Cantidad.StylePriority.UsePadding = false;
            this.Label_Cantidad.StylePriority.UseTextAlignment = false;
            this.Label_Cantidad.Text = "Cantidad";
            this.Label_Cantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label_Motivo
            // 
            this.Label_Motivo.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Label_Motivo.Dpi = 100F;
            this.Label_Motivo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Motivo.LocationFloat = new DevExpress.Utils.PointFloat(570.0001F, 25F);
            this.Label_Motivo.Name = "Label_Motivo";
            this.Label_Motivo.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Motivo.SizeF = new System.Drawing.SizeF(230F, 35F);
            this.Label_Motivo.StylePriority.UseBorders = false;
            this.Label_Motivo.StylePriority.UseFont = false;
            this.Label_Motivo.StylePriority.UsePadding = false;
            this.Label_Motivo.StylePriority.UseTextAlignment = false;
            this.Label_Motivo.Text = "Motivo";
            this.Label_Motivo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label_Producto
            // 
            this.Label_Producto.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Label_Producto.Dpi = 100F;
            this.Label_Producto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Producto.LocationFloat = new DevExpress.Utils.PointFloat(350F, 25F);
            this.Label_Producto.Name = "Label_Producto";
            this.Label_Producto.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Producto.SizeF = new System.Drawing.SizeF(220F, 35F);
            this.Label_Producto.StylePriority.UseBorders = false;
            this.Label_Producto.StylePriority.UseFont = false;
            this.Label_Producto.StylePriority.UsePadding = false;
            this.Label_Producto.StylePriority.UseTextAlignment = false;
            this.Label_Producto.Text = "Producto";
            this.Label_Producto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label_Cliente
            // 
            this.Label_Cliente.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Label_Cliente.Dpi = 100F;
            this.Label_Cliente.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Cliente.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.Label_Cliente.Name = "Label_Cliente";
            this.Label_Cliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Cliente.SizeF = new System.Drawing.SizeF(350F, 35F);
            this.Label_Cliente.StylePriority.UseBorders = false;
            this.Label_Cliente.StylePriority.UseFont = false;
            this.Label_Cliente.StylePriority.UsePadding = false;
            this.Label_Cliente.StylePriority.UseTextAlignment = false;
            this.Label_Cliente.Text = "Cliente";
            this.Label_Cliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Devoluciones
            // 
            this.Lb_Devoluciones.Dpi = 100F;
            this.Lb_Devoluciones.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Devoluciones.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Lb_Devoluciones.Name = "Lb_Devoluciones";
            this.Lb_Devoluciones.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Devoluciones.SizeF = new System.Drawing.SizeF(190F, 13F);
            this.Lb_Devoluciones.StylePriority.UseFont = false;
            this.Lb_Devoluciones.StylePriority.UsePadding = false;
            this.Lb_Devoluciones.StylePriority.UseTextAlignment = false;
            this.Lb_Devoluciones.Text = "DEVOLUCIONES CLIENTES";
            this.Lb_Devoluciones.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.Lb_TDevolucion,
            this.totalDevoluciones});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 23.00001F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R274Liquidacion_ROV.Pieza")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(800.4167F, 10.00001F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(99.58344F, 13F);
            this.xrLabel1.StyleName = "DataField";
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:n}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel1.Summary = xrSummary1;
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Lb_TDevolucion
            // 
            this.Lb_TDevolucion.CanGrow = false;
            this.Lb_TDevolucion.Dpi = 100F;
            this.Lb_TDevolucion.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_TDevolucion.LocationFloat = new DevExpress.Utils.PointFloat(570F, 10F);
            this.Lb_TDevolucion.Name = "Lb_TDevolucion";
            this.Lb_TDevolucion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_TDevolucion.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_TDevolucion.StylePriority.UseFont = false;
            this.Lb_TDevolucion.StylePriority.UsePadding = false;
            this.Lb_TDevolucion.StylePriority.UseTextAlignment = false;
            this.Lb_TDevolucion.Text = "Total Devoluciones";
            this.Lb_TDevolucion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // totalDevoluciones
            // 
            this.totalDevoluciones.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R274Liquidacion_ROV.Total")});
            this.totalDevoluciones.Dpi = 100F;
            this.totalDevoluciones.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDevoluciones.LocationFloat = new DevExpress.Utils.PointFloat(900.8333F, 10.00001F);
            this.totalDevoluciones.Name = "totalDevoluciones";
            this.totalDevoluciones.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.totalDevoluciones.SizeF = new System.Drawing.SizeF(99.58344F, 13F);
            this.totalDevoluciones.StyleName = "DataField";
            this.totalDevoluciones.StylePriority.UseFont = false;
            this.totalDevoluciones.StylePriority.UsePadding = false;
            this.totalDevoluciones.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:c}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.totalDevoluciones.Summary = xrSummary2;
            this.totalDevoluciones.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.totalDevoluciones.PrintOnPage += new DevExpress.XtraReports.UI.PrintOnPageEventHandler(this.totalDevoluciones_PrintOnPage);
            this.totalDevoluciones.TextChanged += new System.EventHandler(this.totalDevoluciones_TextChanged);
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
            // R274_Sub06Devoluciones
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.reportHeaderBand1,
            this.topMarginBand1,
            this.bottomMarginBand1,
            this.ReportFooter});
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
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void totalDevoluciones_PrintOnPage(object sender, PrintOnPageEventArgs e)
    {
        TotalDevolucion = (String.IsNullOrEmpty(this.totalDevoluciones.Text) ? "0" : this.totalDevoluciones.Text);
    }

    private void totalDevoluciones_TextChanged(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(TotalDevolucion))
        {
            Debug.WriteLine("is empty");
        }
        else
        {
            this.totalDevoluciones.Text = TotalDevolucion;
        }
    }
}
