using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

/// <summary>
/// Summary description for VentasCreditoPDR
/// </summary>
public class VentasCreditoPDR : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    public XRLabel lbImporte;
    public XRLabel lbCliente;
    public XRLabel lbFecha;
    public XRLabel lbVenta;
    public XRLabel lbVentasCredito;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private XRLabel xrLabel8;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRLabel xrLabel9;
    private DevExpress.XtraReports.Parameters.Parameter VendedorId;
    private ReportFooterBand ReportFooter;
    public XRLabel lbTotalVentasCredito;
    private CalculatedField XTotal;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public VentasCreditoPDR()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentasCreditoPDR));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lbImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVentasCredito = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.VendedorId = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.lbTotalVentasCredito = new DevExpress.XtraReports.UI.XRLabel();
            this.XTotal = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 15F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Total", "{0:$#,##0.00}")});
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(820F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Cliente")});
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(220F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(600F, 15F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FechaHoraAlta", "{0:dd/MM/yyyy}")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Folio")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(140F, 15F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbImporte,
            this.lbCliente,
            this.lbFecha,
            this.lbVenta,
            this.lbVentasCredito});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 30F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lbImporte
            // 
            this.lbImporte.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbImporte.BorderWidth = 2F;
            this.lbImporte.Dpi = 100F;
            this.lbImporte.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbImporte.LocationFloat = new DevExpress.Utils.PointFloat(820F, 15F);
            this.lbImporte.Name = "lbImporte";
            this.lbImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbImporte.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.lbImporte.StylePriority.UseBorders = false;
            this.lbImporte.StylePriority.UseBorderWidth = false;
            this.lbImporte.StylePriority.UseFont = false;
            this.lbImporte.StylePriority.UseTextAlignment = false;
            this.lbImporte.Text = "lbImporte";
            this.lbImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbCliente
            // 
            this.lbCliente.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbCliente.BorderWidth = 2F;
            this.lbCliente.Dpi = 100F;
            this.lbCliente.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbCliente.LocationFloat = new DevExpress.Utils.PointFloat(220F, 15F);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCliente.SizeF = new System.Drawing.SizeF(600F, 15F);
            this.lbCliente.StylePriority.UseBorders = false;
            this.lbCliente.StylePriority.UseBorderWidth = false;
            this.lbCliente.StylePriority.UseFont = false;
            this.lbCliente.StylePriority.UseTextAlignment = false;
            this.lbCliente.Text = "lbCliente";
            this.lbCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbFecha
            // 
            this.lbFecha.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbFecha.BorderWidth = 2F;
            this.lbFecha.Dpi = 100F;
            this.lbFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbFecha.LocationFloat = new DevExpress.Utils.PointFloat(140F, 15F);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFecha.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.lbFecha.StylePriority.UseBorders = false;
            this.lbFecha.StylePriority.UseBorderWidth = false;
            this.lbFecha.StylePriority.UseFont = false;
            this.lbFecha.StylePriority.UseTextAlignment = false;
            this.lbFecha.Text = "lbFecha";
            this.lbFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbVenta
            // 
            this.lbVenta.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbVenta.BorderWidth = 2F;
            this.lbVenta.Dpi = 100F;
            this.lbVenta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbVenta.LocationFloat = new DevExpress.Utils.PointFloat(0F, 15F);
            this.lbVenta.Name = "lbVenta";
            this.lbVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVenta.SizeF = new System.Drawing.SizeF(140F, 15F);
            this.lbVenta.StylePriority.UseBorders = false;
            this.lbVenta.StylePriority.UseBorderWidth = false;
            this.lbVenta.StylePriority.UseFont = false;
            this.lbVenta.StylePriority.UseTextAlignment = false;
            this.lbVenta.Text = "lbVenta";
            this.lbVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbVentasCredito
            // 
            this.lbVentasCredito.Dpi = 100F;
            this.lbVentasCredito.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbVentasCredito.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lbVentasCredito.Name = "lbVentasCredito";
            this.lbVentasCredito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVentasCredito.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.lbVentasCredito.StylePriority.UseFont = false;
            this.lbVentasCredito.StylePriority.UseTextAlignment = false;
            this.lbVentasCredito.Text = "lbVentasCredito";
            this.lbVentasCredito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            // xrLabel9
            // 
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Total")});
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(820F, 2.543131E-05F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:$#,##0.00}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel9.Summary = xrSummary1;
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // VendedorId
            // 
            this.VendedorId.Description = "VendedorId";
            this.VendedorId.Name = "VendedorId";
            this.VendedorId.Visible = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbTotalVentasCredito,
            this.xrLabel9});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 15.00003F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // lbTotalVentasCredito
            // 
            this.lbTotalVentasCredito.Dpi = 100F;
            this.lbTotalVentasCredito.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotalVentasCredito.LocationFloat = new DevExpress.Utils.PointFloat(220F, 0F);
            this.lbTotalVentasCredito.Name = "lbTotalVentasCredito";
            this.lbTotalVentasCredito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalVentasCredito.SizeF = new System.Drawing.SizeF(600F, 15F);
            this.lbTotalVentasCredito.StylePriority.UseFont = false;
            this.lbTotalVentasCredito.StylePriority.UseTextAlignment = false;
            this.lbTotalVentasCredito.Text = "lbTotalVentasCredito";
            this.lbTotalVentasCredito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // XTotal
            // 
            this.XTotal.DataMember = "Query";
            this.XTotal.Expression = "Iif([TipoFase] == 0,  \'Cancelada\', [Total])";
            this.XTotal.Name = "XTotal";
            // 
            // VentasCreditoPDR
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
            this.BorderWidth = 2F;
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.XTotal});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.FilterString = "[VendedorId] = ?VendedorId";
            this.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.VendedorId});
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
