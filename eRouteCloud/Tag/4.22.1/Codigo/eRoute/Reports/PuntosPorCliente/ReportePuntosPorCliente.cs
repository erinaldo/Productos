using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for PuntosPorCliente
/// </summary>
public class ReportePuntosPorCliente : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    public XRPictureBox pcbLogo;
    private XRLabel xrLabel27;
    public XRLabel lblCedi;
    private XRLabel xrLabel1;
    private XRLabel xrLabel3;
    public XRLabel lblClientes;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel4;
    private XRLabel xrLabel2;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    public XRLabel Disponibles;
    public XRLabel Canjeados;
    public XRLabel Otorgados;
    public XRLabel RazonSocial;
    public XRLabel Clave;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel9;
    public XRLabel TotalOtorgados;
    public XRLabel TotalCanjeados;
    public XRLabel TotalDisponibles;
    private XRLine xrLine1;
    private PageHeaderBand PageHeader;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReportePuntosPorCliente()
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
            this.Disponibles = new DevExpress.XtraReports.UI.XRLabel();
            this.Canjeados = new DevExpress.XtraReports.UI.XRLabel();
            this.Otorgados = new DevExpress.XtraReports.UI.XRLabel();
            this.RazonSocial = new DevExpress.XtraReports.UI.XRLabel();
            this.Clave = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblClientes = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCedi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.pcbLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.TotalOtorgados = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalCanjeados = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalDisponibles = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Disponibles,
            this.Canjeados,
            this.Otorgados,
            this.RazonSocial,
            this.Clave});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 23.33333F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Disponibles
            // 
            this.Disponibles.Dpi = 100F;
            this.Disponibles.LocationFloat = new DevExpress.Utils.PointFloat(661.3333F, 0F);
            this.Disponibles.Name = "Disponibles";
            this.Disponibles.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Disponibles.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.Disponibles.StylePriority.UseTextAlignment = false;
            this.Disponibles.Text = "Disponibles";
            this.Disponibles.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Canjeados
            // 
            this.Canjeados.Dpi = 100F;
            this.Canjeados.LocationFloat = new DevExpress.Utils.PointFloat(586.3333F, 0F);
            this.Canjeados.Name = "Canjeados";
            this.Canjeados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Canjeados.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.Canjeados.StylePriority.UseTextAlignment = false;
            this.Canjeados.Text = "Canjeados";
            this.Canjeados.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Otorgados
            // 
            this.Otorgados.Dpi = 100F;
            this.Otorgados.LocationFloat = new DevExpress.Utils.PointFloat(511.3333F, 0F);
            this.Otorgados.Name = "Otorgados";
            this.Otorgados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Otorgados.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.Otorgados.StylePriority.UseTextAlignment = false;
            this.Otorgados.Text = "Otorgados";
            this.Otorgados.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // RazonSocial
            // 
            this.RazonSocial.Dpi = 100F;
            this.RazonSocial.LocationFloat = new DevExpress.Utils.PointFloat(126.3334F, 0F);
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.RazonSocial.SizeF = new System.Drawing.SizeF(384.9999F, 23F);
            this.RazonSocial.Text = "RazonSocial";
            // 
            // Clave
            // 
            this.Clave.Dpi = 100F;
            this.Clave.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.Clave.Name = "Clave";
            this.Clave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Clave.SizeF = new System.Drawing.SizeF(116.3334F, 23F);
            this.Clave.Text = "Clave";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 50.83354F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(10.16663F, 178.8334F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(140.6667F, 23.00001F);
            this.xrLabel3.Text = "Clientes:";
            // 
            // lblClientes
            // 
            this.lblClientes.Dpi = 100F;
            this.lblClientes.LocationFloat = new DevExpress.Utils.PointFloat(150.8333F, 178.8334F);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblClientes.SizeF = new System.Drawing.SizeF(586.1667F, 23.00002F);
            this.lblClientes.Text = "lblClientes";
            // 
            // lblCedi
            // 
            this.lblCedi.Dpi = 100F;
            this.lblCedi.LocationFloat = new DevExpress.Utils.PointFloat(150.8333F, 155.8333F);
            this.lblCedi.Name = "lblCedi";
            this.lblCedi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCedi.SizeF = new System.Drawing.SizeF(586.1667F, 23.00003F);
            this.lblCedi.Text = "lblCedi";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(10.16663F, 155.8333F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(140.6667F, 23.00001F);
            this.xrLabel1.Text = "Centro de Distribución:";
            // 
            // xrLabel27
            // 
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(150F, 27.5F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(586.3333F, 23F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "SALDO DE PUNTOS POR CLIENTES";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // pcbLogo
            // 
            this.pcbLogo.Dpi = 100F;
            this.pcbLogo.LocationFloat = new DevExpress.Utils.PointFloat(10F, 5.833333F);
            this.pcbLogo.Name = "pcbLogo";
            this.pcbLogo.SizeF = new System.Drawing.SizeF(140F, 140F);
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 88.1666F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(2.000122F, 23.83331F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(423.3333F, 23.83331F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel27,
            this.lblCedi,
            this.xrLabel3,
            this.xrLabel1,
            this.pcbLogo,
            this.lblClientes});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 207.6668F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel8
            // 
            this.xrLabel8.BorderColor = System.Drawing.Color.Gray;
            this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(661.9999F, 10F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.xrLabel8.StylePriority.UseBorderColor = false;
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Disponibles";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.BorderColor = System.Drawing.Color.Gray;
            this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(586.9999F, 10F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.xrLabel7.StylePriority.UseBorderColor = false;
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Canjeados";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.BorderColor = System.Drawing.Color.Gray;
            this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(511.9999F, 10F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.xrLabel6.StylePriority.UseBorderColor = false;
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Otorgados";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.BorderColor = System.Drawing.Color.Gray;
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(126.3334F, 10F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(385.6665F, 23F);
            this.xrLabel4.StylePriority.UseBorderColor = false;
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseForeColor = false;
            this.xrLabel4.Text = "Razón Social";
            // 
            // xrLabel2
            // 
            this.xrLabel2.BorderColor = System.Drawing.Color.Gray;
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(10.49988F, 10F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(115.8335F, 23F);
            this.xrLabel2.StylePriority.UseBorderColor = false;
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.Text = "Clave";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.TotalOtorgados,
            this.TotalCanjeados,
            this.xrLabel9,
            this.TotalDisponibles});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 46F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLine1
            // 
            this.xrLine1.BorderColor = System.Drawing.Color.Gray;
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(9.833374F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(727F, 9.666667F);
            this.xrLine1.StylePriority.UseBorderColor = false;
            // 
            // TotalOtorgados
            // 
            this.TotalOtorgados.Dpi = 100F;
            this.TotalOtorgados.LocationFloat = new DevExpress.Utils.PointFloat(511.3332F, 10F);
            this.TotalOtorgados.Name = "TotalOtorgados";
            this.TotalOtorgados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalOtorgados.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.TotalOtorgados.StylePriority.UseTextAlignment = false;
            this.TotalOtorgados.Text = "TotalOtorgados";
            this.TotalOtorgados.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TotalCanjeados
            // 
            this.TotalCanjeados.Dpi = 100F;
            this.TotalCanjeados.LocationFloat = new DevExpress.Utils.PointFloat(586.3333F, 10F);
            this.TotalCanjeados.Name = "TotalCanjeados";
            this.TotalCanjeados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalCanjeados.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.TotalCanjeados.StylePriority.UseTextAlignment = false;
            this.TotalCanjeados.Text = "TotalCanjeados";
            this.TotalCanjeados.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(411.3333F, 10F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel9.Text = "Total";
            // 
            // TotalDisponibles
            // 
            this.TotalDisponibles.Dpi = 100F;
            this.TotalDisponibles.LocationFloat = new DevExpress.Utils.PointFloat(661.3333F, 10F);
            this.TotalDisponibles.Name = "TotalDisponibles";
            this.TotalDisponibles.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalDisponibles.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.TotalDisponibles.StylePriority.UseTextAlignment = false;
            this.TotalDisponibles.Text = "TotalDisponibles";
            this.TotalDisponibles.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8,
            this.xrLabel4,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel2});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 37.5F;
            this.PageHeader.Name = "PageHeader";
            // 
            // ReportePuntosPorCliente
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.PageHeader});
            this.Margins = new System.Drawing.Printing.Margins(51, 52, 51, 88);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
