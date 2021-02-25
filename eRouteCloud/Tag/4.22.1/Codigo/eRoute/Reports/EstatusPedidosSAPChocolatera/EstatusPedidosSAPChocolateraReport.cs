using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for AnalisisSaldosMOODetallado
/// </summary>
public class EstatusPedidosSAPChocolateraReport : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRPictureBox xrPictureBox1;
    private XRLabel xrLabel1;
    private XRLabel xrLabel20;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    public XRLabel headerlabelcedis;
    public XRLabel labelfechaheader;
    public XRLabel labelvendedorheader;
    private XRLine xrLine1;
    private XRLine xrLine2;
    private XRLabel xrLabel33;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrLabel7;
    public GroupHeaderBand GroupHeader2;
    private XRLabel xrLabel9;
    public XRLabel Fecha;
    public XRLabel Vendedor;
    public GroupHeaderBand GroupHeader4;
    private XRLabel xrLabel2;
    public GroupHeaderBand GroupHeader5;
    private GroupFooterBand GroupFooter5;
    private XRLabel xrLabel8;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    public XRLabel cediClave;
    public XRLabel dEstatus;
    public XRLabel dFolioSAP;
    public XRLabel dFechaEnvio;
    public XRLabel dFolioRoute;
    public XRLabel dCliente;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public EstatusPedidosSAPChocolateraReport()
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
            this.dEstatus = new DevExpress.XtraReports.UI.XRLabel();
            this.dFolioSAP = new DevExpress.XtraReports.UI.XRLabel();
            this.dFechaEnvio = new DevExpress.XtraReports.UI.XRLabel();
            this.dFolioRoute = new DevExpress.XtraReports.UI.XRLabel();
            this.dCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.headerlabelcedis = new DevExpress.XtraReports.UI.XRLabel();
            this.labelfechaheader = new DevExpress.XtraReports.UI.XRLabel();
            this.labelvendedorheader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Vendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.cediClave = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter5 = new DevExpress.XtraReports.UI.GroupFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.dEstatus,
            this.dFolioSAP,
            this.dFechaEnvio,
            this.dFolioRoute,
            this.dCliente});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 12.99996F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dEstatus
            // 
            this.dEstatus.CanGrow = false;
            this.dEstatus.Dpi = 100F;
            this.dEstatus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dEstatus.LocationFloat = new DevExpress.Utils.PointFloat(650.9999F, 0F);
            this.dEstatus.Multiline = true;
            this.dEstatus.Name = "dEstatus";
            this.dEstatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dEstatus.SizeF = new System.Drawing.SizeF(422.0001F, 12.99996F);
            this.dEstatus.StylePriority.UseFont = false;
            this.dEstatus.StylePriority.UseTextAlignment = false;
            this.dEstatus.Text = "Estatus";
            this.dEstatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dFolioSAP
            // 
            this.dFolioSAP.CanGrow = false;
            this.dFolioSAP.Dpi = 100F;
            this.dFolioSAP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dFolioSAP.LocationFloat = new DevExpress.Utils.PointFloat(550.5F, 0F);
            this.dFolioSAP.Multiline = true;
            this.dFolioSAP.Name = "dFolioSAP";
            this.dFolioSAP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dFolioSAP.SizeF = new System.Drawing.SizeF(100F, 12.99996F);
            this.dFolioSAP.StylePriority.UseFont = false;
            this.dFolioSAP.StylePriority.UseTextAlignment = false;
            this.dFolioSAP.Text = "Folio SAP";
            this.dFolioSAP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dFechaEnvio
            // 
            this.dFechaEnvio.CanGrow = false;
            this.dFechaEnvio.Dpi = 100F;
            this.dFechaEnvio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dFechaEnvio.LocationFloat = new DevExpress.Utils.PointFloat(400.5F, 0F);
            this.dFechaEnvio.Multiline = true;
            this.dFechaEnvio.Name = "dFechaEnvio";
            this.dFechaEnvio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dFechaEnvio.SizeF = new System.Drawing.SizeF(150F, 12.99996F);
            this.dFechaEnvio.StylePriority.UseFont = false;
            this.dFechaEnvio.StylePriority.UseTextAlignment = false;
            this.dFechaEnvio.Text = "Fecha Envio";
            this.dFechaEnvio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dFolioRoute
            // 
            this.dFolioRoute.CanGrow = false;
            this.dFolioRoute.Dpi = 100F;
            this.dFolioRoute.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dFolioRoute.LocationFloat = new DevExpress.Utils.PointFloat(300.5F, 0F);
            this.dFolioRoute.Multiline = true;
            this.dFolioRoute.Name = "dFolioRoute";
            this.dFolioRoute.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dFolioRoute.SizeF = new System.Drawing.SizeF(100F, 12.99996F);
            this.dFolioRoute.StylePriority.UseFont = false;
            this.dFolioRoute.StylePriority.UseTextAlignment = false;
            this.dFolioRoute.Text = "Folio Route";
            this.dFolioRoute.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dCliente
            // 
            this.dCliente.CanGrow = false;
            this.dCliente.Dpi = 100F;
            this.dCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dCliente.LocationFloat = new DevExpress.Utils.PointFloat(0.4999796F, 0F);
            this.dCliente.Multiline = true;
            this.dCliente.Name = "dCliente";
            this.dCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dCliente.SizeF = new System.Drawing.SizeF(300F, 12.99996F);
            this.dCliente.StylePriority.UseFont = false;
            this.dCliente.StylePriority.UseTextAlignment = false;
            this.dCliente.Text = "Cliente";
            this.dCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLine1,
            this.xrLine2,
            this.xrLabel33,
            this.headerlabelcedis,
            this.labelfechaheader,
            this.labelvendedorheader,
            this.xrLabel20,
            this.xrLabel23,
            this.xrLabel24,
            this.xrLabel1,
            this.xrPictureBox1});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 211.0417F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(651.4999F, 166.6667F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(421.5001F, 12F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Estatus";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(550.5F, 166.6667F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(99.50006F, 12F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Folio SAP";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(401F, 166.6667F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(149.5F, 12F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Fecha Envio";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(300.5F, 166.6667F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(99.50006F, 12F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Folio Route";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 143.6667F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1071F, 23F);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 178.6667F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(1071F, 22.99998F);
            // 
            // xrLabel33
            // 
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(1.499939F, 166.6667F);
            this.xrLabel33.Multiline = true;
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(299F, 12F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "Cliente";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // headerlabelcedis
            // 
            this.headerlabelcedis.Dpi = 100F;
            this.headerlabelcedis.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerlabelcedis.LocationFloat = new DevExpress.Utils.PointFloat(141.125F, 107.6666F);
            this.headerlabelcedis.Name = "headerlabelcedis";
            this.headerlabelcedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerlabelcedis.SizeF = new System.Drawing.SizeF(931.875F, 12F);
            this.headerlabelcedis.StylePriority.UseFont = false;
            // 
            // labelfechaheader
            // 
            this.labelfechaheader.Dpi = 100F;
            this.labelfechaheader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfechaheader.LocationFloat = new DevExpress.Utils.PointFloat(141.125F, 119.6667F);
            this.labelfechaheader.Name = "labelfechaheader";
            this.labelfechaheader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelfechaheader.SizeF = new System.Drawing.SizeF(931.875F, 12F);
            this.labelfechaheader.StylePriority.UseFont = false;
            // 
            // labelvendedorheader
            // 
            this.labelvendedorheader.CanGrow = false;
            this.labelvendedorheader.Dpi = 100F;
            this.labelvendedorheader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelvendedorheader.LocationFloat = new DevExpress.Utils.PointFloat(141.125F, 131.6667F);
            this.labelvendedorheader.Name = "labelvendedorheader";
            this.labelvendedorheader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelvendedorheader.SizeF = new System.Drawing.SizeF(931.875F, 12F);
            this.labelvendedorheader.StylePriority.UseFont = false;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(0F, 107.6666F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(140.625F, 12F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "Centro de Distribución";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(0F, 119.6667F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(140.625F, 12F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "Fecha";
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(0F, 131.6667F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(140.625F, 12F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "Vendedor";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0.4999796F, 38.54167F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(1072.5F, 21.95834F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "ESTATUS PEDIDOS SAP";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 100F;
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(150F, 94.45833F);
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 23.45835F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(760F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 15F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313F, 15F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            // 
            // Vendedor
            // 
            this.Vendedor.Dpi = 100F;
            this.Vendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Vendedor.LocationFloat = new DevExpress.Utils.PointFloat(176.4999F, 0F);
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Vendedor.SizeF = new System.Drawing.SizeF(896.5001F, 12F);
            this.Vendedor.StylePriority.UseFont = false;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(135.625F, 12F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "Centro de Distribución";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Vendedor,
            this.xrLabel2});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 16.66667F;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(40.5F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(95.125F, 12F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Vendedor";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(20.49993F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(115.1251F, 12F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "Fecha";
            // 
            // Fecha
            // 
            this.Fecha.Dpi = 100F;
            this.Fecha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha.LocationFloat = new DevExpress.Utils.PointFloat(156.5F, 0F);
            this.Fecha.Name = "Fecha";
            this.Fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Fecha.SizeF = new System.Drawing.SizeF(916.5F, 12F);
            this.Fecha.StylePriority.UseFont = false;
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Fecha,
            this.xrLabel9});
            this.GroupHeader4.Dpi = 100F;
            this.GroupHeader4.HeightF = 12F;
            this.GroupHeader4.Level = 1;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // GroupHeader5
            // 
            this.GroupHeader5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.cediClave,
            this.xrLabel7});
            this.GroupHeader5.Dpi = 100F;
            this.GroupHeader5.HeightF = 12.95835F;
            this.GroupHeader5.Level = 2;
            this.GroupHeader5.Name = "GroupHeader5";
            // 
            // cediClave
            // 
            this.cediClave.Dpi = 100F;
            this.cediClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cediClave.LocationFloat = new DevExpress.Utils.PointFloat(136.1249F, 0F);
            this.cediClave.Name = "cediClave";
            this.cediClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cediClave.SizeF = new System.Drawing.SizeF(936.8751F, 12F);
            this.cediClave.StylePriority.UseFont = false;
            // 
            // GroupFooter5
            // 
            this.GroupFooter5.Dpi = 100F;
            this.GroupFooter5.HeightF = 0F;
            this.GroupFooter5.Level = 2;
            this.GroupFooter5.Name = "GroupFooter5";
            // 
            // EstatusPedidosSAPChocolateraReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader2,
            this.GroupHeader4,
            this.GroupHeader5,
            this.GroupFooter5});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 211, 23);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
