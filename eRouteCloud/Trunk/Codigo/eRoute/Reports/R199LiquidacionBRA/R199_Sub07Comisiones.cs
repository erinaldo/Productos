using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Diagnostics;

/// <summary>
/// Summary description for R199_Sub07Comisiones
/// </summary>
public class R199_Sub07Comisiones : DevExpress.XtraReports.UI.XtraReport
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
    public XRLabel Lb_Comisiones;
    public XRLabel Label_ListaPrecio;
    public XRLabel Label_Esquema;
    public XRLabel Label_Cantidad;
    public XRLabel Label_Comision;
    public XRLabel Label_Importe;
    private ReportFooterBand ReportFooter;
    private XRLabel totalComisiones;
    public XRLabel Lb_TComisiones;
    private DevExpress.XtraReports.Parameters.Parameter parameterSeller;
    private DevExpress.XtraReports.Parameters.Parameter parameterDateIni;
    private string TotalComision;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public R199_Sub07Comisiones()
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
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Label_Importe = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Comision = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Cantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Esquema = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_ListaPrecio = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Comisiones = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Lb_TComisiones = new DevExpress.XtraReports.UI.XRLabel();
            this.totalComisiones = new DevExpress.XtraReports.UI.XRLabel();
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
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R199Liquidacion_BRA.CantidadVendida", "{0:#,#}")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(270.4166F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(99.58344F, 13F);
            this.xrLabel6.StyleName = "DataField";
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R199Liquidacion_BRA.Comision", "{0:n}")});
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(370.4168F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(109.5833F, 13F);
            this.xrLabel7.StyleName = "DataField";
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UsePadding = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "xrLabel7";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R199Liquidacion_BRA.Esquema")});
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(150.4167F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(119.5833F, 13F);
            this.xrLabel8.StyleName = "DataField";
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R199Liquidacion_BRA.ImporteComision", "{0:c}")});
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(480.4167F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(114.5833F, 13F);
            this.xrLabel9.StyleName = "DataField";
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UsePadding = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R199Liquidacion_BRA.ListaPrecio")});
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
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "eRouteConnection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "stpr_R199Liquidacion_BRA";
            queryParameter1.Name = "@filterSellers";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterSeller]", typeof(string));
            queryParameter2.Name = "@filterDateIni";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterDateIni]", typeof(string));
            queryParameter3.Name = "@numQuery";
            queryParameter3.Type = typeof(int);
            queryParameter3.ValueInfo = "7";
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.StoredProcName = "stpr_R199Liquidacion_BRA";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Label_Importe,
            this.Label_Comision,
            this.Label_Cantidad,
            this.Label_Esquema,
            this.Label_ListaPrecio,
            this.Lb_Comisiones});
            this.reportHeaderBand1.Dpi = 100F;
            this.reportHeaderBand1.HeightF = 60F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // Label_Importe
            // 
            this.Label_Importe.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Label_Importe.Dpi = 100F;
            this.Label_Importe.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Importe.LocationFloat = new DevExpress.Utils.PointFloat(480.0001F, 25F);
            this.Label_Importe.Name = "Label_Importe";
            this.Label_Importe.Padding = new DevExpress.XtraPrinting.PaddingInfo(40, 0, 0, 0, 100F);
            this.Label_Importe.SizeF = new System.Drawing.SizeF(350F, 35F);
            this.Label_Importe.StylePriority.UseBorders = false;
            this.Label_Importe.StylePriority.UseFont = false;
            this.Label_Importe.StylePriority.UsePadding = false;
            this.Label_Importe.StylePriority.UseTextAlignment = false;
            this.Label_Importe.Text = "Importe";
            this.Label_Importe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Label_Comision
            // 
            this.Label_Comision.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Label_Comision.Dpi = 100F;
            this.Label_Comision.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Comision.LocationFloat = new DevExpress.Utils.PointFloat(370.0001F, 25F);
            this.Label_Comision.Name = "Label_Comision";
            this.Label_Comision.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Comision.SizeF = new System.Drawing.SizeF(110F, 35F);
            this.Label_Comision.StylePriority.UseBorders = false;
            this.Label_Comision.StylePriority.UseFont = false;
            this.Label_Comision.StylePriority.UsePadding = false;
            this.Label_Comision.StylePriority.UseTextAlignment = false;
            this.Label_Comision.Text = "% Comisión";
            this.Label_Comision.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label_Cantidad
            // 
            this.Label_Cantidad.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Label_Cantidad.Dpi = 100F;
            this.Label_Cantidad.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Cantidad.LocationFloat = new DevExpress.Utils.PointFloat(270.0001F, 25F);
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
            // Label_Esquema
            // 
            this.Label_Esquema.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Label_Esquema.Dpi = 100F;
            this.Label_Esquema.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Esquema.LocationFloat = new DevExpress.Utils.PointFloat(150F, 25F);
            this.Label_Esquema.Name = "Label_Esquema";
            this.Label_Esquema.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_Esquema.SizeF = new System.Drawing.SizeF(120F, 35F);
            this.Label_Esquema.StylePriority.UseBorders = false;
            this.Label_Esquema.StylePriority.UseFont = false;
            this.Label_Esquema.StylePriority.UsePadding = false;
            this.Label_Esquema.StylePriority.UseTextAlignment = false;
            this.Label_Esquema.Text = "Esquema";
            this.Label_Esquema.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label_ListaPrecio
            // 
            this.Label_ListaPrecio.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Label_ListaPrecio.Dpi = 100F;
            this.Label_ListaPrecio.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ListaPrecio.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.Label_ListaPrecio.Name = "Label_ListaPrecio";
            this.Label_ListaPrecio.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Label_ListaPrecio.SizeF = new System.Drawing.SizeF(150F, 35F);
            this.Label_ListaPrecio.StylePriority.UseBorders = false;
            this.Label_ListaPrecio.StylePriority.UseFont = false;
            this.Label_ListaPrecio.StylePriority.UsePadding = false;
            this.Label_ListaPrecio.StylePriority.UseTextAlignment = false;
            this.Label_ListaPrecio.Text = "Lista de Precio";
            this.Label_ListaPrecio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Comisiones
            // 
            this.Lb_Comisiones.Dpi = 100F;
            this.Lb_Comisiones.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Comisiones.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Lb_Comisiones.Name = "Lb_Comisiones";
            this.Lb_Comisiones.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Comisiones.SizeF = new System.Drawing.SizeF(190F, 13F);
            this.Lb_Comisiones.StylePriority.UseFont = false;
            this.Lb_Comisiones.StylePriority.UsePadding = false;
            this.Lb_Comisiones.StylePriority.UseTextAlignment = false;
            this.Lb_Comisiones.Text = "COMISIONES";
            this.Lb_Comisiones.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            this.Lb_TComisiones,
            this.totalComisiones});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 23.00001F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // Lb_TComisiones
            // 
            this.Lb_TComisiones.CanGrow = false;
            this.Lb_TComisiones.Dpi = 100F;
            this.Lb_TComisiones.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_TComisiones.LocationFloat = new DevExpress.Utils.PointFloat(270.0001F, 10.00001F);
            this.Lb_TComisiones.Name = "Lb_TComisiones";
            this.Lb_TComisiones.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_TComisiones.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_TComisiones.StylePriority.UseFont = false;
            this.Lb_TComisiones.StylePriority.UsePadding = false;
            this.Lb_TComisiones.StylePriority.UseTextAlignment = false;
            this.Lb_TComisiones.Text = "Total de Comisiones";
            this.Lb_TComisiones.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // totalComisiones
            // 
            this.totalComisiones.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R199Liquidacion_BRA.ImporteComision")});
            this.totalComisiones.Dpi = 100F;
            this.totalComisiones.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalComisiones.LocationFloat = new DevExpress.Utils.PointFloat(480F, 10F);
            this.totalComisiones.Name = "totalComisiones";
            this.totalComisiones.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.totalComisiones.SizeF = new System.Drawing.SizeF(114.5833F, 13F);
            this.totalComisiones.StyleName = "DataField";
            this.totalComisiones.StylePriority.UseFont = false;
            this.totalComisiones.StylePriority.UsePadding = false;
            this.totalComisiones.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:c}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.totalComisiones.Summary = xrSummary1;
            this.totalComisiones.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.totalComisiones.PrintOnPage += new DevExpress.XtraReports.UI.PrintOnPageEventHandler(this.totalComisiones_PrintOnPage);
            this.totalComisiones.TextChanged += new System.EventHandler(this.totalComisiones_TextChanged);
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
            // R199_Sub07Comisiones
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.reportHeaderBand1,
            this.topMarginBand1,
            this.bottomMarginBand1,
            this.ReportFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_R199Liquidacion_BRA";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
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

    private void totalComisiones_PrintOnPage(object sender, PrintOnPageEventArgs e)
    {
        TotalComision = (String.IsNullOrEmpty(this.totalComisiones.Text) ? "0" : this.totalComisiones.Text);
    }

    private void totalComisiones_TextChanged(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(TotalComision))
        {
            Debug.WriteLine("is empty");
        }
        else
        {
            this.totalComisiones.Text = TotalComision;
        }   
    }
}
