using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for AnalisisSaldosMOODetallado
/// </summary>
public class ResumenLargo : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel20;
    private XRLabel xrlLabelCli;
    private XRLabel xrLabel25;
    public XRLabel clienteProg;
    public XRLabel clientesVisitado;
    public XRLabel PedidosEntreg;
    private XRLabel xrLabel1;
    public XRLabel tiempoPromedio;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    public XRLabel EfectivaDeEntrega;
    public XRLabel clientesConPedidosEntr;
    public XRLabel efectividadCompra;
    private XRLabel xrLabel10;
    public XRLabel ImporteTotalPedidos;
    private XRLabel xrLabel12;
    public XRLabel clientesConPedidosNoEnt;
    private XRLabel xrLabel6;
    public XRLabel efectividadVisita;
    private XRLabel xrLabel8;
    private XRLabel xrLabel15;
    public XRLabel FinDeJornada;
    private XRLabel xrLabel13;
    public XRLabel InicioDeJornada;
    private XRLabel xrLabel2;
    public XRLabel PedidosPorEntregar;
    private ReportHeaderBand ReportHeader;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ResumenLargo()
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
            this.tiempoPromedio = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.EfectivaDeEntrega = new DevExpress.XtraReports.UI.XRLabel();
            this.clientesConPedidosEntr = new DevExpress.XtraReports.UI.XRLabel();
            this.clienteProg = new DevExpress.XtraReports.UI.XRLabel();
            this.clientesVisitado = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlLabelCli = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PedidosEntreg = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.clientesConPedidosNoEnt = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.efectividadVisita = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.efectividadCompra = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.ImporteTotalPedidos = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.InicioDeJornada = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.FinDeJornada = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.PedidosPorEntregar = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
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
            this.TopMargin.HeightF = 15F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // tiempoPromedio
            // 
            this.tiempoPromedio.Dpi = 100F;
            this.tiempoPromedio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempoPromedio.LocationFloat = new DevExpress.Utils.PointFloat(193.8698F, 311.0835F);
            this.tiempoPromedio.Name = "tiempoPromedio";
            this.tiempoPromedio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tiempoPromedio.SizeF = new System.Drawing.SizeF(877.3026F, 22.99997F);
            this.tiempoPromedio.StylePriority.UseFont = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0.3201803F, 311.0835F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(192.9498F, 22.99997F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Tiempo Promedio (Por cliente)";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 242.0834F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(193.8201F, 23.00002F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Efectividad de Entrega ";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0.3055691F, 127.0834F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(193.4013F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Clientes con Pedidos entregado";
            // 
            // EfectivaDeEntrega
            // 
            this.EfectivaDeEntrega.Dpi = 100F;
            this.EfectivaDeEntrega.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EfectivaDeEntrega.LocationFloat = new DevExpress.Utils.PointFloat(194.3068F, 242.0834F);
            this.EfectivaDeEntrega.Name = "EfectivaDeEntrega";
            this.EfectivaDeEntrega.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EfectivaDeEntrega.SizeF = new System.Drawing.SizeF(878.0999F, 23.00002F);
            this.EfectivaDeEntrega.StylePriority.UseFont = false;
            // 
            // clientesConPedidosEntr
            // 
            this.clientesConPedidosEntr.Dpi = 100F;
            this.clientesConPedidosEntr.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesConPedidosEntr.LocationFloat = new DevExpress.Utils.PointFloat(193.86F, 127.0834F);
            this.clientesConPedidosEntr.Name = "clientesConPedidosEntr";
            this.clientesConPedidosEntr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.clientesConPedidosEntr.SizeF = new System.Drawing.SizeF(878.9355F, 22.99999F);
            this.clientesConPedidosEntr.StylePriority.UseFont = false;
            // 
            // clienteProg
            // 
            this.clienteProg.Dpi = 100F;
            this.clienteProg.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteProg.LocationFloat = new DevExpress.Utils.PointFloat(193.9248F, 35.08334F);
            this.clienteProg.Name = "clienteProg";
            this.clienteProg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.clienteProg.SizeF = new System.Drawing.SizeF(878.8708F, 22.99999F);
            this.clienteProg.StylePriority.UseFont = false;
            // 
            // clientesVisitado
            // 
            this.clientesVisitado.Dpi = 100F;
            this.clientesVisitado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesVisitado.LocationFloat = new DevExpress.Utils.PointFloat(193.7958F, 58.08337F);
            this.clientesVisitado.Name = "clientesVisitado";
            this.clientesVisitado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.clientesVisitado.SizeF = new System.Drawing.SizeF(879.1012F, 23.00002F);
            this.clientesVisitado.StylePriority.UseFont = false;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(0.3055691F, 35.08334F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(193.4013F, 22.99999F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "Clientes programados";
            // 
            // xrlLabelCli
            // 
            this.xrlLabelCli.Dpi = 100F;
            this.xrlLabelCli.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrlLabelCli.LocationFloat = new DevExpress.Utils.PointFloat(0.2800853F, 58.08337F);
            this.xrlLabelCli.Multiline = true;
            this.xrlLabelCli.Name = "xrlLabelCli";
            this.xrlLabelCli.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlLabelCli.SizeF = new System.Drawing.SizeF(193.4268F, 23.00002F);
            this.xrlLabelCli.StylePriority.UseFont = false;
            this.xrlLabelCli.Text = "Clientes visitados";
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(0.3055691F, 104.0834F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(193.4013F, 22.99999F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.Text = "Pedidos Entregados";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(403.07F, 21.95834F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "I - RESUMEN";
            // 
            // PedidosEntreg
            // 
            this.PedidosEntreg.Dpi = 100F;
            this.PedidosEntreg.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PedidosEntreg.LocationFloat = new DevExpress.Utils.PointFloat(193.9248F, 104.0834F);
            this.PedidosEntreg.Name = "PedidosEntreg";
            this.PedidosEntreg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PedidosEntreg.SizeF = new System.Drawing.SizeF(878.8708F, 23.00001F);
            this.PedidosEntreg.StylePriority.UseFont = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // clientesConPedidosNoEnt
            // 
            this.clientesConPedidosNoEnt.Dpi = 100F;
            this.clientesConPedidosNoEnt.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesConPedidosNoEnt.LocationFloat = new DevExpress.Utils.PointFloat(194.0983F, 150.0834F);
            this.clientesConPedidosNoEnt.Name = "clientesConPedidosNoEnt";
            this.clientesConPedidosNoEnt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.clientesConPedidosNoEnt.SizeF = new System.Drawing.SizeF(878.6972F, 23F);
            this.clientesConPedidosNoEnt.StylePriority.UseFont = false;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0.3055691F, 150.0834F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(193.753F, 22.99998F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "Clientes con Pedidos NO entregado";
            // 
            // efectividadVisita
            // 
            this.efectividadVisita.Dpi = 100F;
            this.efectividadVisita.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.efectividadVisita.LocationFloat = new DevExpress.Utils.PointFloat(193.9248F, 173.0834F);
            this.efectividadVisita.Name = "efectividadVisita";
            this.efectividadVisita.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.efectividadVisita.SizeF = new System.Drawing.SizeF(878.4078F, 23F);
            this.efectividadVisita.StylePriority.UseFont = false;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 173.0834F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(193.6944F, 23.00002F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "Efectividad Visita ";
            // 
            // efectividadCompra
            // 
            this.efectividadCompra.Dpi = 100F;
            this.efectividadCompra.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.efectividadCompra.LocationFloat = new DevExpress.Utils.PointFloat(193.8601F, 196.0833F);
            this.efectividadCompra.Name = "efectividadCompra";
            this.efectividadCompra.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.efectividadCompra.SizeF = new System.Drawing.SizeF(879.0511F, 23.00002F);
            this.efectividadCompra.StylePriority.UseFont = false;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0.3055691F, 196.0834F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(193.4944F, 22.99998F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "Efectividad Compra";
            // 
            // ImporteTotalPedidos
            // 
            this.ImporteTotalPedidos.Dpi = 100F;
            this.ImporteTotalPedidos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImporteTotalPedidos.LocationFloat = new DevExpress.Utils.PointFloat(193.8601F, 219.0834F);
            this.ImporteTotalPedidos.Name = "ImporteTotalPedidos";
            this.ImporteTotalPedidos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ImporteTotalPedidos.SizeF = new System.Drawing.SizeF(879.1071F, 22.99998F);
            this.ImporteTotalPedidos.StylePriority.UseFont = false;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(0.3201987F, 219.0834F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(193.54F, 22.99998F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "Importe Total Pedidos por entregar";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0.294125F, 265.0834F);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(193.3889F, 23.00003F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "Inicio de Jornada";
            // 
            // InicioDeJornada
            // 
            this.InicioDeJornada.Dpi = 100F;
            this.InicioDeJornada.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InicioDeJornada.LocationFloat = new DevExpress.Utils.PointFloat(193.6829F, 265.0834F);
            this.InicioDeJornada.Name = "InicioDeJornada";
            this.InicioDeJornada.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.InicioDeJornada.SizeF = new System.Drawing.SizeF(878.1044F, 23.00003F);
            this.InicioDeJornada.StylePriority.UseFont = false;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(0.01734311F, 288.0835F);
            this.xrLabel15.Multiline = true;
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(193.6656F, 23.00003F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.Text = "Fin de Jornada";
            // 
            // FinDeJornada
            // 
            this.FinDeJornada.Dpi = 100F;
            this.FinDeJornada.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinDeJornada.LocationFloat = new DevExpress.Utils.PointFloat(193.6829F, 288.0835F);
            this.FinDeJornada.Name = "FinDeJornada";
            this.FinDeJornada.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.FinDeJornada.SizeF = new System.Drawing.SizeF(878.4427F, 23.00003F);
            this.FinDeJornada.StylePriority.UseFont = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 81.0834F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(194.0455F, 22.99999F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Pedidos por Entregar";
            // 
            // PedidosPorEntregar
            // 
            this.PedidosPorEntregar.Dpi = 100F;
            this.PedidosPorEntregar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PedidosPorEntregar.LocationFloat = new DevExpress.Utils.PointFloat(194.3068F, 81.0834F);
            this.PedidosPorEntregar.Name = "PedidosPorEntregar";
            this.PedidosPorEntregar.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PedidosPorEntregar.SizeF = new System.Drawing.SizeF(877.8889F, 23.00001F);
            this.PedidosPorEntregar.StylePriority.UseFont = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.PedidosEntreg,
            this.xrLabel25,
            this.xrlLabelCli,
            this.xrLabel20,
            this.clientesVisitado,
            this.clienteProg,
            this.clientesConPedidosEntr,
            this.EfectivaDeEntrega,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.tiempoPromedio,
            this.xrLabel8,
            this.efectividadVisita,
            this.xrLabel6,
            this.clientesConPedidosNoEnt,
            this.xrLabel12,
            this.ImporteTotalPedidos,
            this.xrLabel10,
            this.efectividadCompra,
            this.InicioDeJornada,
            this.xrLabel13,
            this.FinDeJornada,
            this.xrLabel15,
            this.PedidosPorEntregar,
            this.xrLabel2});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 337.2085F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ResumenLargo
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 15, 0);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
