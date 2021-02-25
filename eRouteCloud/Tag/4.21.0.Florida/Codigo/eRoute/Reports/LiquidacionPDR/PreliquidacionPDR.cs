using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

/// <summary>
/// Summary description for PreliquidacionPDR
/// </summary>
public class PreliquidacionPDR : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel1;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private DevExpress.XtraReports.Parameters.Parameter VendedorId;
    public XRLabel lbCobranzaCredito;
    private XRLabel xrLabel2;
    private DevExpress.XtraReports.Parameters.Parameter VentaCredito;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private DevExpress.XtraReports.Parameters.Parameter VentaTotal;
    public XRLabel lbVentaContado;
    public XRLabel lbVentaCredito;
    public XRLabel lbVentaTotal;
    private CalculatedField VentaContado;
    private XRLabel xrLabel7;
    public XRLabel lbTotalLiquidar;
    private CalculatedField TotalLiquidacion;
    private ReportHeaderBand ReportHeader;
    public XRLabel lbPreliquidacion;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public PreliquidacionPDR()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    public void SetDataSource(string cons)
    {
        try
        {
            sqlDataSource1.Queries.RemoveAt(0);
            CustomSqlQuery query = new CustomSqlQuery("Query", cons);
            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
        }
        catch (Exception e) {
            string es = e.Message;
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreliquidacionPDR));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalLiquidar = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.VentaTotal = new DevExpress.XtraReports.Parameters.Parameter();
            this.lbVentaContado = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVentaCredito = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVentaTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.VentaCredito = new DevExpress.XtraReports.Parameters.Parameter();
            this.lbCobranzaCredito = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.VendedorId = new DevExpress.XtraReports.Parameters.Parameter();
            this.VentaContado = new DevExpress.XtraReports.UI.CalculatedField();
            this.TotalLiquidacion = new DevExpress.XtraReports.UI.CalculatedField();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lbPreliquidacion = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel7,
            this.lbTotalLiquidar,
            this.xrLabel5,
            this.xrLabel4,
            this.lbVentaContado,
            this.lbVentaCredito,
            this.lbVentaTotal,
            this.xrLabel2,
            this.lbCobranzaCredito,
            this.xrLabel1});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 75F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(170F, 45F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(15F, 15F);
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "+";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(170F, 30F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(15F, 15F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "=";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(170F, 15F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(15F, 15F);
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "-";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(170F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(15F, 15F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "+";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel7.BorderWidth = 2F;
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TotalLiquidacion", "{0:$#,##0.00}")});
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(185F, 60F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseBorderWidth = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lbTotalLiquidar
            // 
            this.lbTotalLiquidar.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lbTotalLiquidar.Dpi = 100F;
            this.lbTotalLiquidar.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotalLiquidar.LocationFloat = new DevExpress.Utils.PointFloat(20F, 60F);
            this.lbTotalLiquidar.Name = "lbTotalLiquidar";
            this.lbTotalLiquidar.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalLiquidar.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.lbTotalLiquidar.StylePriority.UseBorders = false;
            this.lbTotalLiquidar.StylePriority.UseFont = false;
            this.lbTotalLiquidar.StylePriority.UseTextAlignment = false;
            this.lbTotalLiquidar.Text = "lbTotalLiquidar";
            this.lbTotalLiquidar.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.VentaContado", "{0:$#,##0.00}")});
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(185F, 30F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.VentaTotal, "Text", "{0:$#,##0.00}")});
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(185F, 3.814697E-05F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // VentaTotal
            // 
            this.VentaTotal.Description = "VentaTotal";
            this.VentaTotal.Name = "VentaTotal";
            this.VentaTotal.Type = typeof(double);
            this.VentaTotal.ValueInfo = "0";
            this.VentaTotal.Visible = false;
            // 
            // lbVentaContado
            // 
            this.lbVentaContado.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lbVentaContado.Dpi = 100F;
            this.lbVentaContado.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbVentaContado.LocationFloat = new DevExpress.Utils.PointFloat(20F, 30F);
            this.lbVentaContado.Name = "lbVentaContado";
            this.lbVentaContado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVentaContado.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.lbVentaContado.StylePriority.UseBorders = false;
            this.lbVentaContado.StylePriority.UseFont = false;
            this.lbVentaContado.StylePriority.UseTextAlignment = false;
            this.lbVentaContado.Text = "lbVentaContado";
            this.lbVentaContado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbVentaCredito
            // 
            this.lbVentaCredito.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lbVentaCredito.Dpi = 100F;
            this.lbVentaCredito.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbVentaCredito.LocationFloat = new DevExpress.Utils.PointFloat(20F, 15F);
            this.lbVentaCredito.Name = "lbVentaCredito";
            this.lbVentaCredito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVentaCredito.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.lbVentaCredito.StylePriority.UseBorders = false;
            this.lbVentaCredito.StylePriority.UseFont = false;
            this.lbVentaCredito.StylePriority.UseTextAlignment = false;
            this.lbVentaCredito.Text = "lbVentaCredito";
            this.lbVentaCredito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbVentaTotal
            // 
            this.lbVentaTotal.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lbVentaTotal.Dpi = 100F;
            this.lbVentaTotal.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbVentaTotal.LocationFloat = new DevExpress.Utils.PointFloat(20F, 0F);
            this.lbVentaTotal.Name = "lbVentaTotal";
            this.lbVentaTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVentaTotal.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.lbVentaTotal.StylePriority.UseBorders = false;
            this.lbVentaTotal.StylePriority.UseFont = false;
            this.lbVentaTotal.StylePriority.UseTextAlignment = false;
            this.lbVentaTotal.Text = "lbVentaTotal";
            this.lbVentaTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.VentaCredito, "Text", "{0:$#,##0.00}")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(185F, 15F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // VentaCredito
            // 
            this.VentaCredito.Description = "VentaCredito";
            this.VentaCredito.Name = "VentaCredito";
            this.VentaCredito.Type = typeof(double);
            this.VentaCredito.ValueInfo = "0";
            this.VentaCredito.Visible = false;
            // 
            // lbCobranzaCredito
            // 
            this.lbCobranzaCredito.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lbCobranzaCredito.Dpi = 100F;
            this.lbCobranzaCredito.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbCobranzaCredito.LocationFloat = new DevExpress.Utils.PointFloat(20F, 45F);
            this.lbCobranzaCredito.Name = "lbCobranzaCredito";
            this.lbCobranzaCredito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCobranzaCredito.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.lbCobranzaCredito.StylePriority.UseBorders = false;
            this.lbCobranzaCredito.StylePriority.UseFont = false;
            this.lbCobranzaCredito.StylePriority.UseTextAlignment = false;
            this.lbCobranzaCredito.Text = "lbCobranzaCredito";
            this.lbCobranzaCredito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Cobranza", "{0:$#,##0.00}")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(185F, 45F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // VendedorId
            // 
            this.VendedorId.Description = "VendedorId";
            this.VendedorId.Name = "VendedorId";
            this.VendedorId.Visible = false;
            // 
            // VentaContado
            // 
            this.VentaContado.DataMember = "Query";
            this.VentaContado.Expression = "[Parameters.VentaTotal] - [Parameters.VentaCredito]";
            this.VentaContado.Name = "VentaContado";
            // 
            // TotalLiquidacion
            // 
            this.TotalLiquidacion.DataMember = "Query";
            this.TotalLiquidacion.Expression = "[Parameters.VentaTotal] - [Parameters.VentaCredito] + [Cobranza]";
            this.TotalLiquidacion.Name = "TotalLiquidacion";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbPreliquidacion});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 15F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lbPreliquidacion
            // 
            this.lbPreliquidacion.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lbPreliquidacion.Dpi = 100F;
            this.lbPreliquidacion.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbPreliquidacion.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lbPreliquidacion.Name = "lbPreliquidacion";
            this.lbPreliquidacion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbPreliquidacion.SizeF = new System.Drawing.SizeF(200F, 15F);
            this.lbPreliquidacion.StylePriority.UseBorders = false;
            this.lbPreliquidacion.StylePriority.UseFont = false;
            this.lbPreliquidacion.StylePriority.UseTextAlignment = false;
            this.lbPreliquidacion.Text = "lbPreliquidacion";
            this.lbPreliquidacion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PreliquidacionPDR
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.VentaContado,
            this.TotalLiquidacion});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.FilterString = "[VendedorId] = ?VendedorId";
            this.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.Margins = new System.Drawing.Printing.Margins(200, 200, 10, 10);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.VendedorId,
            this.VentaCredito,
            this.VentaTotal});
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
