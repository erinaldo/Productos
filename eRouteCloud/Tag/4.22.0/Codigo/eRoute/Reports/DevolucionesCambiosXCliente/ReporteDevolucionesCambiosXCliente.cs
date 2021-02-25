using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class ReporteDevolucionesCambiosXCliente : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    public TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    public GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;
    public GroupHeaderBand GroupHeader2;
    public GroupHeaderBand GroupHeader3;
    public GroupHeaderBand GroupHeader4;
    public XRLabel lCliente;
    public XRLabel lRuta;
    public XRLabel lFecha;
    public XRLabel lCedi;
    public XRLabel dClave;
    public XRLabel dProducto;
    public XRLabel dUnidad;
    public XRLabel dPrecio;
    public XRLabel ddCantidad;
    public XRLabel ddImporte;
    public XRLabel ddKg;
    public XRLabel ddMotivo;
    public XRLabel dcCantidad;
    public XRLabel dcKg;
    public XRLabel dcImporte;
    public XRLabel dcMotivo;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel1;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel12;
    public XRLabel lcKg;
    private XRLabel xrLabel10;
    private XRLabel xrLabel13;
    private XRLabel xrLabel18;
    public XRLabel ldKg;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    public XRLabel ldtCantidad;
    public XRLabel ldtKg;
    public XRLabel ldtImporte;
    public XRLabel lctCantidad;
    public XRLabel lctKg;
    public XRLabel lctImporte;
    private XRLabel xrLabel14;
    public XRLabel lcNKg;
    public XRLabel ldNKg;
    public XRLabel empresa;
    public XRLabel rutas;
    public XRLabel fechas;
    public XRLabel cedis;
    public XRLabel labelRuta;
    public XRLabel labelFecha;
    public XRLabel labelCedis;
    public XRLabel reporte;
    public XRPictureBox logo;
    public XRLabel labelSegmento;
    public XRLabel labelProducto;
    public XRLabel labelCliente;
    public XRLabel segmentos;
    public XRLabel productos;
    public XRLabel clientes;
    private PageFooterBand PageFooter;
    private XRLine xrLine2;
    private XRLine xrLine1;
    private XRLabel xrLabel83;
    private XRLabel xrLabel85;
    private XRLabel xrLabel86;
    private XRLine xrLine3;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteDevolucionesCambiosXCliente()
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
            this.dClave = new DevExpress.XtraReports.UI.XRLabel();
            this.dProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.dUnidad = new DevExpress.XtraReports.UI.XRLabel();
            this.dPrecio = new DevExpress.XtraReports.UI.XRLabel();
            this.ddCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.ddImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.ddKg = new DevExpress.XtraReports.UI.XRLabel();
            this.ddMotivo = new DevExpress.XtraReports.UI.XRLabel();
            this.dcCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.dcKg = new DevExpress.XtraReports.UI.XRLabel();
            this.dcImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.dcMotivo = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.labelSegmento = new DevExpress.XtraReports.UI.XRLabel();
            this.labelProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.segmentos = new DevExpress.XtraReports.UI.XRLabel();
            this.productos = new DevExpress.XtraReports.UI.XRLabel();
            this.clientes = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.rutas = new DevExpress.XtraReports.UI.XRLabel();
            this.fechas = new DevExpress.XtraReports.UI.XRLabel();
            this.cedis = new DevExpress.XtraReports.UI.XRLabel();
            this.labelRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCedis = new DevExpress.XtraReports.UI.XRLabel();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.lCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.lcNKg = new DevExpress.XtraReports.UI.XRLabel();
            this.ldNKg = new DevExpress.XtraReports.UI.XRLabel();
            this.ldtCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.ldtKg = new DevExpress.XtraReports.UI.XRLabel();
            this.ldtImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.lctCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.lctKg = new DevExpress.XtraReports.UI.XRLabel();
            this.lctImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel86 = new DevExpress.XtraReports.UI.XRLabel();
            this.lRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel85 = new DevExpress.XtraReports.UI.XRLabel();
            this.lFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel83 = new DevExpress.XtraReports.UI.XRLabel();
            this.lCedi = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.lcKg = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.ldKg = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.dClave,
            this.dProducto,
            this.dUnidad,
            this.dPrecio,
            this.ddCantidad,
            this.ddImporte,
            this.ddKg,
            this.ddMotivo,
            this.dcCantidad,
            this.dcKg,
            this.dcImporte,
            this.dcMotivo});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 15F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dClave
            // 
            this.dClave.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dClave.Dpi = 100F;
            this.dClave.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dClave.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.dClave.Name = "dClave";
            this.dClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dClave.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.dClave.StylePriority.UseBorders = false;
            this.dClave.StylePriority.UseFont = false;
            this.dClave.StylePriority.UseTextAlignment = false;
            this.dClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // dProducto
            // 
            this.dProducto.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dProducto.Dpi = 100F;
            this.dProducto.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dProducto.LocationFloat = new DevExpress.Utils.PointFloat(80F, 0F);
            this.dProducto.Name = "dProducto";
            this.dProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dProducto.SizeF = new System.Drawing.SizeF(200F, 15F);
            this.dProducto.StylePriority.UseBorders = false;
            this.dProducto.StylePriority.UseFont = false;
            this.dProducto.StylePriority.UseTextAlignment = false;
            this.dProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // dUnidad
            // 
            this.dUnidad.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dUnidad.Dpi = 100F;
            this.dUnidad.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dUnidad.LocationFloat = new DevExpress.Utils.PointFloat(280F, 0F);
            this.dUnidad.Name = "dUnidad";
            this.dUnidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dUnidad.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.dUnidad.StylePriority.UseBorders = false;
            this.dUnidad.StylePriority.UseFont = false;
            this.dUnidad.StylePriority.UseTextAlignment = false;
            this.dUnidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // dPrecio
            // 
            this.dPrecio.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dPrecio.Dpi = 100F;
            this.dPrecio.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dPrecio.LocationFloat = new DevExpress.Utils.PointFloat(330F, 0F);
            this.dPrecio.Name = "dPrecio";
            this.dPrecio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dPrecio.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.dPrecio.StylePriority.UseBorders = false;
            this.dPrecio.StylePriority.UseFont = false;
            this.dPrecio.StylePriority.UseTextAlignment = false;
            this.dPrecio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ddCantidad
            // 
            this.ddCantidad.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ddCantidad.Dpi = 100F;
            this.ddCantidad.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.ddCantidad.LocationFloat = new DevExpress.Utils.PointFloat(380.0001F, 0F);
            this.ddCantidad.Name = "ddCantidad";
            this.ddCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddCantidad.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.ddCantidad.StylePriority.UseBorders = false;
            this.ddCantidad.StylePriority.UseFont = false;
            this.ddCantidad.StylePriority.UseTextAlignment = false;
            this.ddCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ddImporte
            // 
            this.ddImporte.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ddImporte.Dpi = 100F;
            this.ddImporte.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.ddImporte.LocationFloat = new DevExpress.Utils.PointFloat(540.0001F, 0F);
            this.ddImporte.Name = "ddImporte";
            this.ddImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddImporte.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.ddImporte.StylePriority.UseBorders = false;
            this.ddImporte.StylePriority.UseFont = false;
            this.ddImporte.StylePriority.UseTextAlignment = false;
            this.ddImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ddKg
            // 
            this.ddKg.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ddKg.Dpi = 100F;
            this.ddKg.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.ddKg.LocationFloat = new DevExpress.Utils.PointFloat(460.0001F, 0F);
            this.ddKg.Name = "ddKg";
            this.ddKg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddKg.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.ddKg.StylePriority.UseBorders = false;
            this.ddKg.StylePriority.UseFont = false;
            this.ddKg.StylePriority.UseTextAlignment = false;
            this.ddKg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ddMotivo
            // 
            this.ddMotivo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ddMotivo.Dpi = 100F;
            this.ddMotivo.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.ddMotivo.LocationFloat = new DevExpress.Utils.PointFloat(620.0001F, 0F);
            this.ddMotivo.Name = "ddMotivo";
            this.ddMotivo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddMotivo.SizeF = new System.Drawing.SizeF(110F, 15F);
            this.ddMotivo.StylePriority.UseBorders = false;
            this.ddMotivo.StylePriority.UseFont = false;
            this.ddMotivo.StylePriority.UseTextAlignment = false;
            this.ddMotivo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // dcCantidad
            // 
            this.dcCantidad.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dcCantidad.Dpi = 100F;
            this.dcCantidad.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dcCantidad.LocationFloat = new DevExpress.Utils.PointFloat(730.0001F, 0F);
            this.dcCantidad.Name = "dcCantidad";
            this.dcCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dcCantidad.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.dcCantidad.StylePriority.UseBorders = false;
            this.dcCantidad.StylePriority.UseFont = false;
            this.dcCantidad.StylePriority.UseTextAlignment = false;
            this.dcCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // dcKg
            // 
            this.dcKg.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dcKg.Dpi = 100F;
            this.dcKg.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dcKg.LocationFloat = new DevExpress.Utils.PointFloat(810.0001F, 0F);
            this.dcKg.Name = "dcKg";
            this.dcKg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dcKg.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.dcKg.StylePriority.UseBorders = false;
            this.dcKg.StylePriority.UseFont = false;
            this.dcKg.StylePriority.UseTextAlignment = false;
            this.dcKg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // dcImporte
            // 
            this.dcImporte.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dcImporte.Dpi = 100F;
            this.dcImporte.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dcImporte.LocationFloat = new DevExpress.Utils.PointFloat(890.0001F, 0F);
            this.dcImporte.Name = "dcImporte";
            this.dcImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dcImporte.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.dcImporte.StylePriority.UseBorders = false;
            this.dcImporte.StylePriority.UseFont = false;
            this.dcImporte.StylePriority.UseTextAlignment = false;
            this.dcImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // dcMotivo
            // 
            this.dcMotivo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dcMotivo.Dpi = 100F;
            this.dcMotivo.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dcMotivo.LocationFloat = new DevExpress.Utils.PointFloat(969.9999F, 0F);
            this.dcMotivo.Name = "dcMotivo";
            this.dcMotivo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dcMotivo.SizeF = new System.Drawing.SizeF(110F, 15F);
            this.dcMotivo.StylePriority.UseBorders = false;
            this.dcMotivo.StylePriority.UseFont = false;
            this.dcMotivo.StylePriority.UseTextAlignment = false;
            this.dcMotivo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            this.labelSegmento,
            this.labelProducto,
            this.labelCliente,
            this.segmentos,
            this.productos,
            this.clientes,
            this.empresa,
            this.rutas,
            this.fechas,
            this.cedis,
            this.labelRuta,
            this.labelFecha,
            this.labelCedis,
            this.reporte,
            this.logo});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.ReportHeader.HeightF = 200F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.StylePriority.UseFont = false;
            // 
            // labelSegmento
            // 
            this.labelSegmento.CanGrow = false;
            this.labelSegmento.Dpi = 100F;
            this.labelSegmento.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelSegmento.LocationFloat = new DevExpress.Utils.PointFloat(0F, 145F);
            this.labelSegmento.Name = "labelSegmento";
            this.labelSegmento.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSegmento.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelSegmento.StylePriority.UseFont = false;
            this.labelSegmento.StylePriority.UseTextAlignment = false;
            this.labelSegmento.Text = "Segmento(s):";
            this.labelSegmento.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelProducto
            // 
            this.labelProducto.CanGrow = false;
            this.labelProducto.Dpi = 100F;
            this.labelProducto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelProducto.LocationFloat = new DevExpress.Utils.PointFloat(0F, 160F);
            this.labelProducto.Name = "labelProducto";
            this.labelProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelProducto.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelProducto.StylePriority.UseFont = false;
            this.labelProducto.StylePriority.UseTextAlignment = false;
            this.labelProducto.Text = "Producto(s):";
            this.labelProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelCliente
            // 
            this.labelCliente.CanGrow = false;
            this.labelCliente.Dpi = 100F;
            this.labelCliente.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelCliente.LocationFloat = new DevExpress.Utils.PointFloat(0F, 175F);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCliente.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelCliente.StylePriority.UseFont = false;
            this.labelCliente.StylePriority.UseTextAlignment = false;
            this.labelCliente.Text = "Cliente(s):";
            this.labelCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // segmentos
            // 
            this.segmentos.CanGrow = false;
            this.segmentos.Dpi = 100F;
            this.segmentos.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.segmentos.LocationFloat = new DevExpress.Utils.PointFloat(150F, 145F);
            this.segmentos.Name = "segmentos";
            this.segmentos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.segmentos.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.segmentos.StylePriority.UseFont = false;
            this.segmentos.StylePriority.UseTextAlignment = false;
            this.segmentos.Text = "segmentos";
            this.segmentos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // productos
            // 
            this.productos.CanGrow = false;
            this.productos.Dpi = 100F;
            this.productos.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.productos.LocationFloat = new DevExpress.Utils.PointFloat(150F, 160F);
            this.productos.Name = "productos";
            this.productos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.productos.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.productos.StylePriority.UseFont = false;
            this.productos.StylePriority.UseTextAlignment = false;
            this.productos.Text = "productos";
            this.productos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // clientes
            // 
            this.clientes.CanGrow = false;
            this.clientes.Dpi = 100F;
            this.clientes.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.clientes.LocationFloat = new DevExpress.Utils.PointFloat(150F, 175F);
            this.clientes.Name = "clientes";
            this.clientes.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.clientes.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.clientes.StylePriority.UseFont = false;
            this.clientes.StylePriority.UseTextAlignment = false;
            this.clientes.Text = "clientes";
            this.clientes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // empresa
            // 
            this.empresa.CanGrow = false;
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(295F, 10F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(490F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // rutas
            // 
            this.rutas.CanGrow = false;
            this.rutas.Dpi = 100F;
            this.rutas.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.rutas.LocationFloat = new DevExpress.Utils.PointFloat(150F, 130F);
            this.rutas.Name = "rutas";
            this.rutas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.rutas.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.rutas.StylePriority.UseFont = false;
            this.rutas.StylePriority.UseTextAlignment = false;
            this.rutas.Text = "rutas";
            this.rutas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // fechas
            // 
            this.fechas.CanGrow = false;
            this.fechas.Dpi = 100F;
            this.fechas.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.fechas.LocationFloat = new DevExpress.Utils.PointFloat(150F, 115F);
            this.fechas.Name = "fechas";
            this.fechas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fechas.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.fechas.StylePriority.UseFont = false;
            this.fechas.StylePriority.UseTextAlignment = false;
            this.fechas.Text = "fechas";
            this.fechas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // cedis
            // 
            this.cedis.CanGrow = false;
            this.cedis.Dpi = 100F;
            this.cedis.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.cedis.LocationFloat = new DevExpress.Utils.PointFloat(150F, 100F);
            this.cedis.Name = "cedis";
            this.cedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cedis.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.cedis.StylePriority.UseFont = false;
            this.cedis.StylePriority.UseTextAlignment = false;
            this.cedis.Text = "cedis";
            this.cedis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelRuta
            // 
            this.labelRuta.CanGrow = false;
            this.labelRuta.Dpi = 100F;
            this.labelRuta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelRuta.LocationFloat = new DevExpress.Utils.PointFloat(0F, 130F);
            this.labelRuta.Name = "labelRuta";
            this.labelRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelRuta.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelRuta.StylePriority.UseFont = false;
            this.labelRuta.StylePriority.UseTextAlignment = false;
            this.labelRuta.Text = "Ruta(s):";
            this.labelRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelFecha
            // 
            this.labelFecha.CanGrow = false;
            this.labelFecha.Dpi = 100F;
            this.labelFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelFecha.LocationFloat = new DevExpress.Utils.PointFloat(0F, 115F);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFecha.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelFecha.StylePriority.UseFont = false;
            this.labelFecha.StylePriority.UseTextAlignment = false;
            this.labelFecha.Text = "Fecha(s):";
            this.labelFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelCedis
            // 
            this.labelCedis.CanGrow = false;
            this.labelCedis.Dpi = 100F;
            this.labelCedis.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelCedis.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
            this.labelCedis.Name = "labelCedis";
            this.labelCedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCedis.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelCedis.StylePriority.UseFont = false;
            this.labelCedis.StylePriority.UseTextAlignment = false;
            this.labelCedis.Text = "Centro De Distribución:";
            this.labelCedis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // reporte
            // 
            this.reporte.CanGrow = false;
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(295F, 50F);
            this.reporte.Name = "reporte";
            this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.reporte.SizeF = new System.Drawing.SizeF(490F, 40F);
            this.reporte.StylePriority.UseFont = false;
            this.reporte.StylePriority.UseTextAlignment = false;
            this.reporte.Text = "reporte";
            this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(50F, 10F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(140F, 80F);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lCliente});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 15F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // lCliente
            // 
            this.lCliente.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lCliente.Dpi = 100F;
            this.lCliente.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lCliente.LocationFloat = new DevExpress.Utils.PointFloat(60F, 0F);
            this.lCliente.Name = "lCliente";
            this.lCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lCliente.SizeF = new System.Drawing.SizeF(1020F, 15F);
            this.lCliente.StylePriority.UseBorders = false;
            this.lCliente.StylePriority.UseFont = false;
            this.lCliente.StylePriority.UseTextAlignment = false;
            this.lCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine3,
            this.lcNKg,
            this.ldNKg,
            this.ldtCantidad,
            this.ldtKg,
            this.ldtImporte,
            this.lctCantidad,
            this.lctKg,
            this.lctImporte,
            this.xrLabel14});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 17F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(380.0001F, 0F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(700F, 2F);
            // 
            // lcNKg
            // 
            this.lcNKg.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lcNKg.Dpi = 100F;
            this.lcNKg.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lcNKg.LocationFloat = new DevExpress.Utils.PointFloat(810.0001F, 2F);
            this.lcNKg.Name = "lcNKg";
            this.lcNKg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lcNKg.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.lcNKg.StylePriority.UseBorders = false;
            this.lcNKg.StylePriority.UseFont = false;
            this.lcNKg.StylePriority.UseTextAlignment = false;
            this.lcNKg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lcNKg.Visible = false;
            // 
            // ldNKg
            // 
            this.ldNKg.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ldNKg.Dpi = 100F;
            this.ldNKg.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.ldNKg.LocationFloat = new DevExpress.Utils.PointFloat(460.0001F, 2F);
            this.ldNKg.Name = "ldNKg";
            this.ldNKg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ldNKg.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.ldNKg.StylePriority.UseBorders = false;
            this.ldNKg.StylePriority.UseFont = false;
            this.ldNKg.StylePriority.UseTextAlignment = false;
            this.ldNKg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.ldNKg.Visible = false;
            // 
            // ldtCantidad
            // 
            this.ldtCantidad.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ldtCantidad.Dpi = 100F;
            this.ldtCantidad.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.ldtCantidad.LocationFloat = new DevExpress.Utils.PointFloat(380.0001F, 2F);
            this.ldtCantidad.Name = "ldtCantidad";
            this.ldtCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ldtCantidad.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.ldtCantidad.StylePriority.UseBorders = false;
            this.ldtCantidad.StylePriority.UseFont = false;
            this.ldtCantidad.StylePriority.UseTextAlignment = false;
            this.ldtCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ldtKg
            // 
            this.ldtKg.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ldtKg.Dpi = 100F;
            this.ldtKg.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.ldtKg.LocationFloat = new DevExpress.Utils.PointFloat(460.0001F, 1.999982F);
            this.ldtKg.Name = "ldtKg";
            this.ldtKg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ldtKg.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.ldtKg.StylePriority.UseBorders = false;
            this.ldtKg.StylePriority.UseFont = false;
            this.ldtKg.StylePriority.UseTextAlignment = false;
            this.ldtKg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ldtImporte
            // 
            this.ldtImporte.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ldtImporte.Dpi = 100F;
            this.ldtImporte.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.ldtImporte.LocationFloat = new DevExpress.Utils.PointFloat(540.0001F, 2F);
            this.ldtImporte.Name = "ldtImporte";
            this.ldtImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ldtImporte.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.ldtImporte.StylePriority.UseBorders = false;
            this.ldtImporte.StylePriority.UseFont = false;
            this.ldtImporte.StylePriority.UseTextAlignment = false;
            this.ldtImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lctCantidad
            // 
            this.lctCantidad.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lctCantidad.Dpi = 100F;
            this.lctCantidad.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lctCantidad.LocationFloat = new DevExpress.Utils.PointFloat(730.0001F, 2F);
            this.lctCantidad.Name = "lctCantidad";
            this.lctCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lctCantidad.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.lctCantidad.StylePriority.UseBorders = false;
            this.lctCantidad.StylePriority.UseFont = false;
            this.lctCantidad.StylePriority.UseTextAlignment = false;
            this.lctCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lctKg
            // 
            this.lctKg.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lctKg.Dpi = 100F;
            this.lctKg.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lctKg.LocationFloat = new DevExpress.Utils.PointFloat(810.0001F, 1.999982F);
            this.lctKg.Name = "lctKg";
            this.lctKg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lctKg.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.lctKg.StylePriority.UseBorders = false;
            this.lctKg.StylePriority.UseFont = false;
            this.lctKg.StylePriority.UseTextAlignment = false;
            this.lctKg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lctImporte
            // 
            this.lctImporte.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lctImporte.Dpi = 100F;
            this.lctImporte.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lctImporte.LocationFloat = new DevExpress.Utils.PointFloat(890.0001F, 1.999982F);
            this.lctImporte.Name = "lctImporte";
            this.lctImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lctImporte.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.lctImporte.StylePriority.UseBorders = false;
            this.lctImporte.StylePriority.UseFont = false;
            this.lctImporte.StylePriority.UseTextAlignment = false;
            this.lctImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(260.0001F, 1.999982F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(120F, 15F);
            this.xrLabel14.StylePriority.UseBorders = false;
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Total De Unidades:";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel86,
            this.lRuta});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 15F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrLabel86
            // 
            this.xrLabel86.Dpi = 100F;
            this.xrLabel86.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel86.LocationFloat = new DevExpress.Utils.PointFloat(40F, 0F);
            this.xrLabel86.Name = "xrLabel86";
            this.xrLabel86.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel86.SizeF = new System.Drawing.SizeF(40F, 15F);
            this.xrLabel86.StylePriority.UseFont = false;
            this.xrLabel86.StylePriority.UseTextAlignment = false;
            this.xrLabel86.Text = "Ruta:";
            this.xrLabel86.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lRuta
            // 
            this.lRuta.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lRuta.Dpi = 100F;
            this.lRuta.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.lRuta.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
            this.lRuta.Name = "lRuta";
            this.lRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lRuta.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.lRuta.StylePriority.UseBorders = false;
            this.lRuta.StylePriority.UseFont = false;
            this.lRuta.StylePriority.UseTextAlignment = false;
            this.lRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel85,
            this.lFecha});
            this.GroupHeader3.Dpi = 100F;
            this.GroupHeader3.HeightF = 15F;
            this.GroupHeader3.Level = 2;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // xrLabel85
            // 
            this.xrLabel85.Dpi = 100F;
            this.xrLabel85.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel85.LocationFloat = new DevExpress.Utils.PointFloat(20F, 0F);
            this.xrLabel85.Name = "xrLabel85";
            this.xrLabel85.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel85.SizeF = new System.Drawing.SizeF(45F, 15F);
            this.xrLabel85.StylePriority.UseFont = false;
            this.xrLabel85.StylePriority.UseTextAlignment = false;
            this.xrLabel85.Text = "Fecha:";
            this.xrLabel85.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lFecha
            // 
            this.lFecha.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lFecha.Dpi = 100F;
            this.lFecha.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.lFecha.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
            this.lFecha.Name = "lFecha";
            this.lFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lFecha.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.lFecha.StylePriority.UseBorders = false;
            this.lFecha.StylePriority.UseFont = false;
            this.lFecha.StylePriority.UseTextAlignment = false;
            this.lFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel83,
            this.lCedi});
            this.GroupHeader4.Dpi = 100F;
            this.GroupHeader4.HeightF = 15F;
            this.GroupHeader4.Level = 3;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // xrLabel83
            // 
            this.xrLabel83.Dpi = 100F;
            this.xrLabel83.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel83.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel83.Name = "xrLabel83";
            this.xrLabel83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel83.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel83.StylePriority.UseFont = false;
            this.xrLabel83.StylePriority.UseTextAlignment = false;
            this.xrLabel83.Text = "Centro De Distribución:";
            this.xrLabel83.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lCedi
            // 
            this.lCedi.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lCedi.Dpi = 100F;
            this.lCedi.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.lCedi.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
            this.lCedi.Name = "lCedi";
            this.lCedi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lCedi.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.lCedi.StylePriority.UseBorders = false;
            this.lCedi.StylePriority.UseFont = false;
            this.lCedi.StylePriority.UseTextAlignment = false;
            this.lCedi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrLine1,
            this.xrLabel1,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel12,
            this.lcKg,
            this.xrLabel10,
            this.xrLabel13,
            this.xrLabel18,
            this.ldKg,
            this.xrLabel15,
            this.xrLabel16});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 35F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 32F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(1080F, 2F);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1080F, 2F);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 2F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(80F, 30F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Clave";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(80F, 2F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(200F, 30F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Producto";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(280F, 2.000014F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(50F, 30F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Unidad";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(330F, 2.000014F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(50F, 30F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Precio";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(380F, 2F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(350F, 15F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Existencia";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(730F, 2.000014F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(350F, 15F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Cambio";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(540F, 17.00001F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Importe";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lcKg
            // 
            this.lcKg.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lcKg.Dpi = 100F;
            this.lcKg.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lcKg.LocationFloat = new DevExpress.Utils.PointFloat(460.0001F, 17.00001F);
            this.lcKg.Name = "lcKg";
            this.lcKg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lcKg.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.lcKg.StylePriority.UseBorders = false;
            this.lcKg.StylePriority.UseFont = false;
            this.lcKg.StylePriority.UseTextAlignment = false;
            this.lcKg.Text = "Kg/Lt";
            this.lcKg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(380.0001F, 17.00001F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Cantidad";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(620F, 17.00002F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(110F, 15F);
            this.xrLabel13.StylePriority.UseBorders = false;
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Motivo";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(730F, 17.00001F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.xrLabel18.StylePriority.UseBorders = false;
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Cantidad";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ldKg
            // 
            this.ldKg.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ldKg.Dpi = 100F;
            this.ldKg.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.ldKg.LocationFloat = new DevExpress.Utils.PointFloat(810.0001F, 17.00001F);
            this.ldKg.Name = "ldKg";
            this.ldKg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ldKg.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.ldKg.StylePriority.UseBorders = false;
            this.ldKg.StylePriority.UseFont = false;
            this.ldKg.StylePriority.UseTextAlignment = false;
            this.ldKg.Text = "Kg/Lt";
            this.ldKg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(890.0001F, 17.00002F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.xrLabel15.StylePriority.UseBorders = false;
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "Importe";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(969.9999F, 17.00001F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(110F, 15F);
            this.xrLabel16.StylePriority.UseBorders = false;
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "Motivo";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 15F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(200F, 15F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(980F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReporteDevolucionesCambiosXCliente
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader1,
            this.GroupFooter1,
            this.GroupHeader2,
            this.GroupHeader3,
            this.GroupHeader4,
            this.PageHeader,
            this.PageFooter});
            this.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
