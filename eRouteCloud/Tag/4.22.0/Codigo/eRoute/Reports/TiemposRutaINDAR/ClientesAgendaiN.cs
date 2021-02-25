using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ClientesAgenda
/// </summary>
public class ClientesAgendaIN : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel3;
    private XRLabel xrLabel37;
    private XRLabel xrLabel38;
    private XRLabel xrLabel39;
    private XRLabel xrLabel42;
    private XRLabel xrLabel41;
    private XRLabel xrLabel40;
    public XRLabel labelca1;
    public XRLabel labelca2;
    public XRLabel labelca3;
    public XRLabel labelca6;
    public XRLabel labelca5;
    public XRLabel labelca4;
    public GroupHeaderBand GroupHeader1;
    public GroupHeaderBand GroupHeader2;
    public GroupHeaderBand GroupHeader3;
    private XRLabel xrLabel4;
    public XRLabel labelRuta;
    private XRLabel xrLabel2;
    public XRLabel labelvendedor;
    public XRLabel labelcedi;
    private XRLabel xrLabel1;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ClientesAgendaIN()
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelca4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelca1 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelca2 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelca3 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelca6 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelca5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.labelcedi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelvendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelRuta = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel37,
            this.labelca5,
            this.labelca6,
            this.labelca3,
            this.labelca2,
            this.labelca1,
            this.xrLabel40,
            this.xrLabel41,
            this.xrLabel42,
            this.xrLabel39,
            this.xrLabel38,
            this.labelca4});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 91.66666F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 23F;
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
            // ReportFooter
            // 
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 0F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(158.7916F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Clientes en Agenda";
            // 
            // labelca4
            // 
            this.labelca4.Dpi = 100F;
            this.labelca4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelca4.LocationFloat = new DevExpress.Utils.PointFloat(296.4792F, 0F);
            this.labelca4.Multiline = true;
            this.labelca4.Name = "labelca4";
            this.labelca4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelca4.SizeF = new System.Drawing.SizeF(112.9583F, 23F);
            this.labelca4.StylePriority.UseFont = false;
            // 
            // xrLabel38
            // 
            this.xrLabel38.Dpi = 100F;
            this.xrLabel38.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23.00002F);
            this.xrLabel38.Multiline = true;
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(108.7916F, 23F);
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.Text = "No Visitados";
            // 
            // xrLabel39
            // 
            this.xrLabel39.Dpi = 100F;
            this.xrLabel39.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(0F, 46.00003F);
            this.xrLabel39.Multiline = true;
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(108.7916F, 23F);
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.Text = "Total Clientes";
            // 
            // xrLabel42
            // 
            this.xrLabel42.Dpi = 100F;
            this.xrLabel42.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(186.4999F, 46.00003F);
            this.xrLabel42.Multiline = true;
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(108.7916F, 23F);
            this.xrLabel42.StylePriority.UseFont = false;
            this.xrLabel42.Text = "Efectividad Compra";
            // 
            // xrLabel41
            // 
            this.xrLabel41.Dpi = 100F;
            this.xrLabel41.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(186.4999F, 23.00002F);
            this.xrLabel41.Multiline = true;
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(108.7916F, 23F);
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.Text = "Visitas sin Venta";
            // 
            // xrLabel40
            // 
            this.xrLabel40.Dpi = 100F;
            this.xrLabel40.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(186.4999F, 0F);
            this.xrLabel40.Multiline = true;
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(108.7916F, 23F);
            this.xrLabel40.StylePriority.UseFont = false;
            this.xrLabel40.Text = "Visita Efectiva";
            // 
            // labelca1
            // 
            this.labelca1.Dpi = 100F;
            this.labelca1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelca1.LocationFloat = new DevExpress.Utils.PointFloat(108.7916F, 0F);
            this.labelca1.Multiline = true;
            this.labelca1.Name = "labelca1";
            this.labelca1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelca1.SizeF = new System.Drawing.SizeF(67.08331F, 23F);
            this.labelca1.StylePriority.UseFont = false;
            // 
            // labelca2
            // 
            this.labelca2.Dpi = 100F;
            this.labelca2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelca2.LocationFloat = new DevExpress.Utils.PointFloat(108.7916F, 23.00002F);
            this.labelca2.Multiline = true;
            this.labelca2.Name = "labelca2";
            this.labelca2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelca2.SizeF = new System.Drawing.SizeF(67.49998F, 23F);
            this.labelca2.StylePriority.UseFont = false;
            // 
            // labelca3
            // 
            this.labelca3.Dpi = 100F;
            this.labelca3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelca3.LocationFloat = new DevExpress.Utils.PointFloat(108.7916F, 46.00003F);
            this.labelca3.Multiline = true;
            this.labelca3.Name = "labelca3";
            this.labelca3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelca3.SizeF = new System.Drawing.SizeF(67.49998F, 23F);
            this.labelca3.StylePriority.UseFont = false;
            // 
            // labelca6
            // 
            this.labelca6.Dpi = 100F;
            this.labelca6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelca6.LocationFloat = new DevExpress.Utils.PointFloat(296.4792F, 46.00003F);
            this.labelca6.Multiline = true;
            this.labelca6.Name = "labelca6";
            this.labelca6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelca6.SizeF = new System.Drawing.SizeF(112.9583F, 23F);
            this.labelca6.StylePriority.UseFont = false;
            // 
            // labelca5
            // 
            this.labelca5.Dpi = 100F;
            this.labelca5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelca5.LocationFloat = new DevExpress.Utils.PointFloat(296.4792F, 23.00002F);
            this.labelca5.Multiline = true;
            this.labelca5.Name = "labelca5";
            this.labelca5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelca5.SizeF = new System.Drawing.SizeF(112.9583F, 23F);
            this.labelca5.StylePriority.UseFont = false;
            // 
            // xrLabel37
            // 
            this.xrLabel37.Dpi = 100F;
            this.xrLabel37.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel37.Multiline = true;
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(108.7916F, 23F);
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.Text = "Visitados";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.labelRuta});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 23.95835F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.labelvendedor});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 23F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelcedi,
            this.xrLabel1});
            this.GroupHeader3.Dpi = 100F;
            this.GroupHeader3.HeightF = 23F;
            this.GroupHeader3.Level = 2;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // labelcedi
            // 
            this.labelcedi.Dpi = 100F;
            this.labelcedi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelcedi.ForeColor = System.Drawing.Color.Black;
            this.labelcedi.LocationFloat = new DevExpress.Utils.PointFloat(198.0625F, 0F);
            this.labelcedi.Multiline = true;
            this.labelcedi.Name = "labelcedi";
            this.labelcedi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelcedi.SizeF = new System.Drawing.SizeF(449.4167F, 23F);
            this.labelcedi.StylePriority.UseFont = false;
            this.labelcedi.StylePriority.UseForeColor = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(137.9583F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Vendedor";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(137.9583F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Centro de distribución";
            // 
            // labelvendedor
            // 
            this.labelvendedor.Dpi = 100F;
            this.labelvendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelvendedor.ForeColor = System.Drawing.Color.Black;
            this.labelvendedor.LocationFloat = new DevExpress.Utils.PointFloat(198.0625F, 0F);
            this.labelvendedor.Multiline = true;
            this.labelvendedor.Name = "labelvendedor";
            this.labelvendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelvendedor.SizeF = new System.Drawing.SizeF(449.4167F, 23F);
            this.labelvendedor.StylePriority.UseFont = false;
            this.labelvendedor.StylePriority.UseForeColor = false;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(137.9583F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Ruta";
            // 
            // labelRuta
            // 
            this.labelRuta.Dpi = 100F;
            this.labelRuta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRuta.ForeColor = System.Drawing.Color.Black;
            this.labelRuta.LocationFloat = new DevExpress.Utils.PointFloat(198.0625F, 0.9583473F);
            this.labelRuta.Multiline = true;
            this.labelRuta.Name = "labelRuta";
            this.labelRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelRuta.SizeF = new System.Drawing.SizeF(449.4167F, 23F);
            this.labelRuta.StylePriority.UseFont = false;
            this.labelRuta.StylePriority.UseForeColor = false;
            // 
            // ClientesAgenda
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupHeader3});
            this.Margins = new System.Drawing.Printing.Margins(15, 12, 23, 0);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
