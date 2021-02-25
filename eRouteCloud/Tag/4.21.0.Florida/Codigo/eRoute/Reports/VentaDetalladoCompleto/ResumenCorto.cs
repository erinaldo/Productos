using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for AnalisisSaldosMOODetallado
/// </summary>
public class ResumenCorto : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel20;
    private XRLabel xrlLabelCli;
    private XRLabel xrLabel25;
    public XRLabel clienteProg;
    public XRLabel clientesVisitado;
    public XRLabel inicioJornada;
    private XRLabel xrLabel1;
    private ReportHeaderBand ReportHeader;
    public XRLabel clientesNuevos;
    public XRLabel totalVenta;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    public XRLabel dropSize;
    public XRLabel totalPresupuesto;
    public XRLabel cumplimientoVenta;
    private XRLabel xrLabel27;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    public XRLabel efectividadVisita;
    public XRLabel efectividadCompra;
    public XRLabel clientesConCompra;
    public XRLabel clientesNoCompra;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel4;
    public XRLabel tiempoPromedio;
    private XRLabel xrLabel2;
    public XRLabel finJornada;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ResumenCorto()
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
            this.clienteProg = new DevExpress.XtraReports.UI.XRLabel();
            this.clientesVisitado = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlLabelCli = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.inicioJornada = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.finJornada = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.tiempoPromedio = new DevExpress.XtraReports.UI.XRLabel();
            this.clientesConCompra = new DevExpress.XtraReports.UI.XRLabel();
            this.clientesNoCompra = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.efectividadVisita = new DevExpress.XtraReports.UI.XRLabel();
            this.efectividadCompra = new DevExpress.XtraReports.UI.XRLabel();
            this.clientesNuevos = new DevExpress.XtraReports.UI.XRLabel();
            this.totalVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.dropSize = new DevExpress.XtraReports.UI.XRLabel();
            this.totalPresupuesto = new DevExpress.XtraReports.UI.XRLabel();
            this.cumplimientoVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // clienteProg
            // 
            this.clienteProg.Dpi = 100F;
            this.clienteProg.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteProg.LocationFloat = new DevExpress.Utils.PointFloat(162.2735F, 42.37506F);
            this.clienteProg.Name = "clienteProg";
            this.clienteProg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.clienteProg.SizeF = new System.Drawing.SizeF(314.2695F, 22.99999F);
            this.clienteProg.StylePriority.UseFont = false;
            // 
            // clientesVisitado
            // 
            this.clientesVisitado.Dpi = 100F;
            this.clientesVisitado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesVisitado.LocationFloat = new DevExpress.Utils.PointFloat(162.2735F, 65.37505F);
            this.clientesVisitado.Name = "clientesVisitado";
            this.clientesVisitado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.clientesVisitado.SizeF = new System.Drawing.SizeF(314.2695F, 23.00004F);
            this.clientesVisitado.StylePriority.UseFont = false;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(0F, 42.37502F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(161.7638F, 22.99999F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "Clientes programados";
            // 
            // xrlLabelCli
            // 
            this.xrlLabelCli.Dpi = 100F;
            this.xrlLabelCli.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrlLabelCli.LocationFloat = new DevExpress.Utils.PointFloat(0.2549115F, 65.37505F);
            this.xrlLabelCli.Multiline = true;
            this.xrlLabelCli.Name = "xrlLabelCli";
            this.xrlLabelCli.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlLabelCli.SizeF = new System.Drawing.SizeF(161.5089F, 23.00004F);
            this.xrlLabelCli.StylePriority.UseFont = false;
            this.xrlLabelCli.Text = "Clientes visitados";
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(1.172415F, 204.7966F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(160.5914F, 23F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.Text = "Inicio por jornada";
            // 
            // inicioJornada
            // 
            this.inicioJornada.Dpi = 100F;
            this.inicioJornada.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inicioJornada.LocationFloat = new DevExpress.Utils.PointFloat(162.2735F, 204.7966F);
            this.inicioJornada.Name = "inicioJornada";
            this.inicioJornada.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.inicioJornada.SizeF = new System.Drawing.SizeF(314.2487F, 23F);
            this.inicioJornada.StylePriority.UseFont = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(9.999982F, 9.999997F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(403.07F, 21.95834F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "I - RESUMEN OPERATIVO DEL DÍA";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.clientesNuevos,
            this.totalVenta,
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel19,
            this.dropSize,
            this.totalPresupuesto,
            this.cumplimientoVenta,
            this.xrLabel27,
            this.xrLabel10,
            this.xrLabel11,
            this.efectividadVisita,
            this.efectividadCompra,
            this.clientesConCompra,
            this.clientesNoCompra,
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel4,
            this.tiempoPromedio,
            this.xrLabel2,
            this.finJornada,
            this.xrLabel1,
            this.inicioJornada,
            this.xrLabel25,
            this.xrlLabelCli,
            this.xrLabel20,
            this.clientesVisitado,
            this.clienteProg});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 280.1472F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(1.682313F, 227.7966F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(160.0815F, 22.99998F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Fin de jornada";
            // 
            // finJornada
            // 
            this.finJornada.Dpi = 100F;
            this.finJornada.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finJornada.LocationFloat = new DevExpress.Utils.PointFloat(162.2735F, 227.7966F);
            this.finJornada.Name = "finJornada";
            this.finJornada.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.finJornada.SizeF = new System.Drawing.SizeF(314.5036F, 23.00002F);
            this.finJornada.StylePriority.UseFont = false;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0.3064155F, 250.7966F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(161.4574F, 22.99998F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Tiempo Promedio (Por cliente)";
            // 
            // tiempoPromedio
            // 
            this.tiempoPromedio.Dpi = 100F;
            this.tiempoPromedio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempoPromedio.LocationFloat = new DevExpress.Utils.PointFloat(162.2735F, 250.7966F);
            this.tiempoPromedio.Name = "tiempoPromedio";
            this.tiempoPromedio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tiempoPromedio.SizeF = new System.Drawing.SizeF(314.5036F, 23.00002F);
            this.tiempoPromedio.StylePriority.UseFont = false;
            // 
            // clientesConCompra
            // 
            this.clientesConCompra.Dpi = 100F;
            this.clientesConCompra.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesConCompra.LocationFloat = new DevExpress.Utils.PointFloat(162.2735F, 88.37511F);
            this.clientesConCompra.Name = "clientesConCompra";
            this.clientesConCompra.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.clientesConCompra.SizeF = new System.Drawing.SizeF(314.2695F, 22.99999F);
            this.clientesConCompra.StylePriority.UseFont = false;
            // 
            // clientesNoCompra
            // 
            this.clientesNoCompra.Dpi = 100F;
            this.clientesNoCompra.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesNoCompra.LocationFloat = new DevExpress.Utils.PointFloat(162.2735F, 111.3751F);
            this.clientesNoCompra.Name = "clientesNoCompra";
            this.clientesNoCompra.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.clientesNoCompra.SizeF = new System.Drawing.SizeF(314.2695F, 23.00005F);
            this.clientesNoCompra.StylePriority.UseFont = false;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 88.37508F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(161.7638F, 22.99999F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "Clientes con Compra";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0.2549115F, 111.3751F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(161.5089F, 23.00005F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "Clientes NO Compra";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0.2549115F, 157.3752F);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(161.5089F, 23.00005F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "Efectividad Compra";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(0F, 134.3752F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(161.7638F, 22.99999F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "Efectividad visita";
            // 
            // efectividadVisita
            // 
            this.efectividadVisita.Dpi = 100F;
            this.efectividadVisita.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.efectividadVisita.LocationFloat = new DevExpress.Utils.PointFloat(162.0187F, 134.3752F);
            this.efectividadVisita.Name = "efectividadVisita";
            this.efectividadVisita.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.efectividadVisita.SizeF = new System.Drawing.SizeF(314.5244F, 22.99998F);
            this.efectividadVisita.StylePriority.UseFont = false;
            // 
            // efectividadCompra
            // 
            this.efectividadCompra.Dpi = 100F;
            this.efectividadCompra.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.efectividadCompra.LocationFloat = new DevExpress.Utils.PointFloat(162.2735F, 157.3752F);
            this.efectividadCompra.Name = "efectividadCompra";
            this.efectividadCompra.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.efectividadCompra.SizeF = new System.Drawing.SizeF(314.2695F, 23.00005F);
            this.efectividadCompra.StylePriority.UseFont = false;
            // 
            // clientesNuevos
            // 
            this.clientesNuevos.Dpi = 100F;
            this.clientesNuevos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesNuevos.LocationFloat = new DevExpress.Utils.PointFloat(705.2422F, 42.37506F);
            this.clientesNuevos.Name = "clientesNuevos";
            this.clientesNuevos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.clientesNuevos.SizeF = new System.Drawing.SizeF(314.2695F, 22.99999F);
            this.clientesNuevos.StylePriority.UseFont = false;
            // 
            // totalVenta
            // 
            this.totalVenta.Dpi = 100F;
            this.totalVenta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalVenta.LocationFloat = new DevExpress.Utils.PointFloat(705.2422F, 65.37502F);
            this.totalVenta.Name = "totalVenta";
            this.totalVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalVenta.SizeF = new System.Drawing.SizeF(314.2695F, 23.00004F);
            this.totalVenta.StylePriority.UseFont = false;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(542.9687F, 42.37502F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(161.7638F, 22.99999F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.Text = "Clientes nuevos";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(543.2236F, 65.37502F);
            this.xrLabel17.Multiline = true;
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(161.5089F, 23.00004F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.Text = "Total Venta";
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(543.2236F, 111.3751F);
            this.xrLabel18.Multiline = true;
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(161.5089F, 23.00005F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.Text = "Drop Size";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(542.9687F, 88.37508F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(161.7638F, 22.99999F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "Total Presupuesto";
            // 
            // dropSize
            // 
            this.dropSize.Dpi = 100F;
            this.dropSize.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropSize.LocationFloat = new DevExpress.Utils.PointFloat(705.2422F, 111.3751F);
            this.dropSize.Name = "dropSize";
            this.dropSize.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dropSize.SizeF = new System.Drawing.SizeF(314.2695F, 23.00005F);
            this.dropSize.StylePriority.UseFont = false;
            // 
            // totalPresupuesto
            // 
            this.totalPresupuesto.Dpi = 100F;
            this.totalPresupuesto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPresupuesto.LocationFloat = new DevExpress.Utils.PointFloat(705.2422F, 88.37511F);
            this.totalPresupuesto.Name = "totalPresupuesto";
            this.totalPresupuesto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPresupuesto.SizeF = new System.Drawing.SizeF(314.2695F, 22.99999F);
            this.totalPresupuesto.StylePriority.UseFont = false;
            // 
            // cumplimientoVenta
            // 
            this.cumplimientoVenta.Dpi = 100F;
            this.cumplimientoVenta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cumplimientoVenta.LocationFloat = new DevExpress.Utils.PointFloat(704.9874F, 134.3752F);
            this.cumplimientoVenta.Name = "cumplimientoVenta";
            this.cumplimientoVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cumplimientoVenta.SizeF = new System.Drawing.SizeF(314.5244F, 22.99998F);
            this.cumplimientoVenta.StylePriority.UseFont = false;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(542.9687F, 134.3752F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(161.7638F, 22.99999F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.Text = "Cumplimiento Vta Vs Ppto";
            // 
            // ResumenCorto
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 0, 0);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
