Imports System.Xml
Imports System.Xml.Schema
Imports System.IO
Imports System.Text
Imports System
Imports System.Security.Cryptography
Imports System.Net
Imports System.Net.Mail
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmFactura
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaTicket As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LstDomicilio As System.Windows.Forms.ListBox
    Friend WithEvents TxtRFC As System.Windows.Forms.TextBox
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtTicket As System.Windows.Forms.TextBox
    Friend WithEvents TxtIVA As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents LblIVA As System.Windows.Forms.Label
    Friend WithEvents LblSubtotal As System.Windows.Forms.Label
    Friend WithEvents TxtVence As System.Windows.Forms.TextBox
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents TxtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents ChkCredito As Selling.ChkStatus
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpSinAsignar As System.Windows.Forms.GroupBox
    Friend WithEvents LstAsignados As System.Windows.Forms.ListBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAbrir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnVendedor As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbFormaPago As Selling.StoreCombo
    Friend WithEvents TxtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents BtnDevolucion As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnTC As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents btnNotas As Janus.Windows.EditControls.UIButton
    Friend WithEvents CtxDocumentos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CmbCaja As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFactura))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox
        Me.LblTipoCambio = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnTC = New Janus.Windows.EditControls.UIButton
        Me.CtxDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtFecha = New System.Windows.Forms.TextBox
        Me.BtnVendedor = New Janus.Windows.EditControls.UIButton
        Me.Label12 = New System.Windows.Forms.Label
        Me.CmbCaja = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtVendedor = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.TxtFolio = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtVence = New System.Windows.Forms.TextBox
        Me.TxtTicket = New System.Windows.Forms.TextBox
        Me.BtnBuscaTicket = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpDetalle = New System.Windows.Forms.GroupBox
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.GrpCliente = New System.Windows.Forms.GroupBox
        Me.TxtBusqueda = New System.Windows.Forms.TextBox
        Me.BtnAbrir = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.TxtRFC = New System.Windows.Forms.TextBox
        Me.LstDomicilio = New System.Windows.Forms.ListBox
        Me.lblRFC = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.BtnBuscaCte = New Janus.Windows.EditControls.UIButton
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.TxtSubtotal = New System.Windows.Forms.TextBox
        Me.TxtIVA = New System.Windows.Forms.TextBox
        Me.TxtTotal = New System.Windows.Forms.TextBox
        Me.LblTotal = New System.Windows.Forms.Label
        Me.LblIVA = New System.Windows.Forms.Label
        Me.LblSubtotal = New System.Windows.Forms.Label
        Me.GrpSinAsignar = New System.Windows.Forms.GroupBox
        Me.BtnDevolucion = New Janus.Windows.EditControls.UIButton
        Me.LstAsignados = New System.Windows.Forms.ListBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmbFormaPago = New Selling.StoreCombo
        Me.ChkCredito = New Selling.ChkStatus(Me.components)
        Me.btnNotas = New Janus.Windows.EditControls.UIButton
        Me.GrpGeneral.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCliente.SuspendLayout()
        Me.GrpSinAsignar.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Controls.Add(Me.LblTipoCambio)
        Me.GrpGeneral.Controls.Add(Me.Label3)
        Me.GrpGeneral.Controls.Add(Me.BtnTC)
        Me.GrpGeneral.Controls.Add(Me.Label4)
        Me.GrpGeneral.Controls.Add(Me.TxtFecha)
        Me.GrpGeneral.Controls.Add(Me.BtnVendedor)
        Me.GrpGeneral.Controls.Add(Me.Label12)
        Me.GrpGeneral.Controls.Add(Me.CmbCaja)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Controls.Add(Me.TxtVendedor)
        Me.GrpGeneral.Controls.Add(Me.LblNombre)
        Me.GrpGeneral.Controls.Add(Me.TxtFolio)
        Me.GrpGeneral.Location = New System.Drawing.Point(7, 7)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(300, 181)
        Me.GrpGeneral.TabIndex = 1
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos Generales"
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Location = New System.Drawing.Point(59, 74)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(101, 15)
        Me.LblTipoCambio.TabIndex = 112
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(5, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Moneda"
        '
        'BtnTC
        '
        Me.BtnTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnTC.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.BtnTC.ContextMenuStrip = Me.CtxDocumentos
        Me.BtnTC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTC.Location = New System.Drawing.Point(166, 64)
        Me.BtnTC.Name = "BtnTC"
        Me.BtnTC.Size = New System.Drawing.Size(126, 28)
        Me.BtnTC.TabIndex = 110
        Me.BtnTC.Text = "MXN"
        Me.BtnTC.ToolTipText = "Elejir Moneda"
        Me.BtnTC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CtxDocumentos
        '
        Me.CtxDocumentos.Name = "CtxDocumentos"
        Me.CtxDocumentos.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CtxDocumentos.Size = New System.Drawing.Size(61, 4)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 15)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "Fecha"
        '
        'TxtFecha
        '
        Me.TxtFecha.Enabled = False
        Me.TxtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFecha.Location = New System.Drawing.Point(107, 37)
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.ReadOnly = True
        Me.TxtFecha.Size = New System.Drawing.Size(185, 21)
        Me.TxtFecha.TabIndex = 108
        '
        'BtnVendedor
        '
        Me.BtnVendedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnVendedor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnVendedor.Enabled = False
        Me.BtnVendedor.Icon = CType(resources.GetObject("BtnVendedor.Icon"), System.Drawing.Icon)
        Me.BtnVendedor.Location = New System.Drawing.Point(166, 145)
        Me.BtnVendedor.Name = "BtnVendedor"
        Me.BtnVendedor.Size = New System.Drawing.Size(127, 29)
        Me.BtnVendedor.TabIndex = 101
        Me.BtnVendedor.Text = "Cambiar Vendedor"
        Me.BtnVendedor.ToolTipText = "Cambiar Vendedor"
        Me.BtnVendedor.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(4, 99)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 15)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Caja"
        '
        'CmbCaja
        '
        Me.CmbCaja.Location = New System.Drawing.Point(60, 95)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(233, 21)
        Me.CmbCaja.TabIndex = 97
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 15)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Folio"
        '
        'TxtVendedor
        '
        Me.TxtVendedor.Enabled = False
        Me.TxtVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendedor.Location = New System.Drawing.Point(60, 121)
        Me.TxtVendedor.Multiline = True
        Me.TxtVendedor.Name = "TxtVendedor"
        Me.TxtVendedor.ReadOnly = True
        Me.TxtVendedor.Size = New System.Drawing.Size(233, 19)
        Me.TxtVendedor.TabIndex = 3
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(4, 125)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(61, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Vendedor"
        '
        'TxtFolio
        '
        Me.TxtFolio.Enabled = False
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(107, 13)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.ReadOnly = True
        Me.TxtFolio.Size = New System.Drawing.Size(185, 21)
        Me.TxtFolio.TabIndex = 94
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(466, 200)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 14)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "Fecha de Vencimiento"
        '
        'TxtVence
        '
        Me.TxtVence.Enabled = False
        Me.TxtVence.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVence.Location = New System.Drawing.Point(591, 194)
        Me.TxtVence.Name = "TxtVence"
        Me.TxtVence.ReadOnly = True
        Me.TxtVence.Size = New System.Drawing.Size(185, 21)
        Me.TxtVence.TabIndex = 94
        '
        'TxtTicket
        '
        Me.TxtTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTicket.Location = New System.Drawing.Point(7, 16)
        Me.TxtTicket.Name = "TxtTicket"
        Me.TxtTicket.Size = New System.Drawing.Size(89, 21)
        Me.TxtTicket.TabIndex = 1
        '
        'BtnBuscaTicket
        '
        Me.BtnBuscaTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaTicket.Image = CType(resources.GetObject("BtnBuscaTicket.Image"), System.Drawing.Image)
        Me.BtnBuscaTicket.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaTicket.Location = New System.Drawing.Point(127, 15)
        Me.BtnBuscaTicket.Name = "BtnBuscaTicket"
        Me.BtnBuscaTicket.Size = New System.Drawing.Size(23, 22)
        Me.BtnBuscaTicket.TabIndex = 2
        Me.BtnBuscaTicket.ToolTipText = "Busqueda de Ticket"
        Me.BtnBuscaTicket.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(599, 533)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 533)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(167, 218)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(618, 280)
        Me.GrpDetalle.TabIndex = 3
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Enabled = False
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 15)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(605, 257)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpCliente
        '
        Me.GrpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCliente.Controls.Add(Me.TxtBusqueda)
        Me.GrpCliente.Controls.Add(Me.BtnAbrir)
        Me.GrpCliente.Controls.Add(Me.BtnAgregar)
        Me.GrpCliente.Controls.Add(Me.TxtRFC)
        Me.GrpCliente.Controls.Add(Me.LstDomicilio)
        Me.GrpCliente.Controls.Add(Me.lblRFC)
        Me.GrpCliente.Controls.Add(Me.Label11)
        Me.GrpCliente.Controls.Add(Me.BtnBuscaCte)
        Me.GrpCliente.Controls.Add(Me.TxtRazonSocial)
        Me.GrpCliente.Controls.Add(Me.Label2)
        Me.GrpCliente.Controls.Add(Me.TxtClave)
        Me.GrpCliente.Location = New System.Drawing.Point(313, 7)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(472, 181)
        Me.GrpCliente.TabIndex = 2
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "Datos Cliente"
        '
        'TxtBusqueda
        '
        Me.TxtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtBusqueda.Location = New System.Drawing.Point(66, 27)
        Me.TxtBusqueda.Name = "TxtBusqueda"
        Me.TxtBusqueda.Size = New System.Drawing.Size(113, 21)
        Me.TxtBusqueda.TabIndex = 96
        '
        'BtnAbrir
        '
        Me.BtnAbrir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAbrir.Icon = CType(resources.GetObject("BtnAbrir.Icon"), System.Drawing.Icon)
        Me.BtnAbrir.Location = New System.Drawing.Point(278, 21)
        Me.BtnAbrir.Name = "BtnAbrir"
        Me.BtnAbrir.Size = New System.Drawing.Size(90, 30)
        Me.BtnAbrir.TabIndex = 95
        Me.BtnAbrir.Text = "&Abrir"
        Me.BtnAbrir.ToolTipText = "Modificar datos del Cliente"
        Me.BtnAbrir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(373, 21)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 30)
        Me.BtnAgregar.TabIndex = 94
        Me.BtnAgregar.Text = "&Nuevo"
        Me.BtnAgregar.ToolTipText = "Agregar nuevo Cliente"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRFC
        '
        Me.TxtRFC.Enabled = False
        Me.TxtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRFC.Location = New System.Drawing.Point(66, 54)
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.ReadOnly = True
        Me.TxtRFC.Size = New System.Drawing.Size(141, 21)
        Me.TxtRFC.TabIndex = 93
        '
        'LstDomicilio
        '
        Me.LstDomicilio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LstDomicilio.Enabled = False
        Me.LstDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstDomicilio.ItemHeight = 15
        Me.LstDomicilio.Location = New System.Drawing.Point(7, 119)
        Me.LstDomicilio.Name = "LstDomicilio"
        Me.LstDomicilio.Size = New System.Drawing.Size(458, 49)
        Me.LstDomicilio.TabIndex = 92
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(7, 56)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(60, 15)
        Me.lblRFC.TabIndex = 91
        Me.lblRFC.Text = "RFC/Clave"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(6, 81)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 38)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Razón Social"
        '
        'BtnBuscaCte
        '
        Me.BtnBuscaCte.Image = CType(resources.GetObject("BtnBuscaCte.Image"), System.Drawing.Image)
        Me.BtnBuscaCte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaCte.Location = New System.Drawing.Point(184, 25)
        Me.BtnBuscaCte.Name = "BtnBuscaCte"
        Me.BtnBuscaCte.Size = New System.Drawing.Size(23, 22)
        Me.BtnBuscaCte.TabIndex = 1
        Me.BtnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.BtnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(66, 78)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(398, 37)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Buscar"
        '
        'TxtClave
        '
        Me.TxtClave.Enabled = False
        Me.TxtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave.Location = New System.Drawing.Point(218, 54)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.ReadOnly = True
        Me.TxtClave.Size = New System.Drawing.Size(114, 21)
        Me.TxtClave.TabIndex = 3
        '
        'TxtSubtotal
        '
        Me.TxtSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSubtotal.Enabled = False
        Me.TxtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubtotal.Location = New System.Drawing.Point(345, 504)
        Me.TxtSubtotal.Name = "TxtSubtotal"
        Me.TxtSubtotal.ReadOnly = True
        Me.TxtSubtotal.Size = New System.Drawing.Size(94, 26)
        Me.TxtSubtotal.TabIndex = 4
        Me.TxtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtIVA
        '
        Me.TxtIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIVA.Enabled = False
        Me.TxtIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIVA.Location = New System.Drawing.Point(523, 502)
        Me.TxtIVA.Name = "TxtIVA"
        Me.TxtIVA.ReadOnly = True
        Me.TxtIVA.Size = New System.Drawing.Size(89, 26)
        Me.TxtIVA.TabIndex = 16
        Me.TxtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotal
        '
        Me.TxtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(660, 502)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(125, 26)
        Me.TxtTotal.TabIndex = 17
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Location = New System.Drawing.Point(619, 511)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(39, 15)
        Me.LblTotal.TabIndex = 90
        Me.LblTotal.Text = "Total"
        '
        'LblIVA
        '
        Me.LblIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblIVA.Location = New System.Drawing.Point(452, 511)
        Me.LblIVA.Name = "LblIVA"
        Me.LblIVA.Size = New System.Drawing.Size(60, 15)
        Me.LblIVA.TabIndex = 91
        Me.LblIVA.Text = "Impuestos"
        '
        'LblSubtotal
        '
        Me.LblSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSubtotal.Location = New System.Drawing.Point(299, 511)
        Me.LblSubtotal.Name = "LblSubtotal"
        Me.LblSubtotal.Size = New System.Drawing.Size(46, 15)
        Me.LblSubtotal.TabIndex = 92
        Me.LblSubtotal.Text = "Subtotal"
        '
        'GrpSinAsignar
        '
        Me.GrpSinAsignar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpSinAsignar.Controls.Add(Me.BtnDevolucion)
        Me.GrpSinAsignar.Controls.Add(Me.LstAsignados)
        Me.GrpSinAsignar.Controls.Add(Me.TxtTicket)
        Me.GrpSinAsignar.Controls.Add(Me.BtnBuscaTicket)
        Me.GrpSinAsignar.Location = New System.Drawing.Point(7, 218)
        Me.GrpSinAsignar.Name = "GrpSinAsignar"
        Me.GrpSinAsignar.Size = New System.Drawing.Size(160, 313)
        Me.GrpSinAsignar.TabIndex = 93
        Me.GrpSinAsignar.TabStop = False
        Me.GrpSinAsignar.Text = "Tickets"
        '
        'BtnDevolucion
        '
        Me.BtnDevolucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDevolucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDevolucion.Image = CType(resources.GetObject("BtnDevolucion.Image"), System.Drawing.Image)
        Me.BtnDevolucion.Location = New System.Drawing.Point(100, 15)
        Me.BtnDevolucion.Name = "BtnDevolucion"
        Me.BtnDevolucion.Size = New System.Drawing.Size(23, 22)
        Me.BtnDevolucion.TabIndex = 14
        Me.BtnDevolucion.ToolTipText = "Remueve el Ticket Seleccionado de la Factura Actual"
        Me.BtnDevolucion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LstAsignados
        '
        Me.LstAsignados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LstAsignados.HorizontalScrollbar = True
        Me.LstAsignados.Location = New System.Drawing.Point(7, 42)
        Me.LstAsignados.Name = "LstAsignados"
        Me.LstAsignados.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LstAsignados.ScrollAlwaysVisible = True
        Me.LstAsignados.Size = New System.Drawing.Size(146, 238)
        Me.LstAsignados.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(7, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 14)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Forma de Pago"
        '
        'CmbFormaPago
        '
        Me.CmbFormaPago.BackColor = System.Drawing.SystemColors.Window
        Me.CmbFormaPago.ItemHeight = 13
        Me.CmbFormaPago.Location = New System.Drawing.Point(95, 196)
        Me.CmbFormaPago.Name = "CmbFormaPago"
        Me.CmbFormaPago.Size = New System.Drawing.Size(181, 21)
        Me.CmbFormaPago.TabIndex = 105
        '
        'ChkCredito
        '
        Me.ChkCredito.Location = New System.Drawing.Point(313, 194)
        Me.ChkCredito.Name = "ChkCredito"
        Me.ChkCredito.Size = New System.Drawing.Size(71, 21)
        Me.ChkCredito.TabIndex = 3
        Me.ChkCredito.Text = "Credito"
        '
        'btnNotas
        '
        Me.btnNotas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNotas.Icon = CType(resources.GetObject("btnNotas.Icon"), System.Drawing.Icon)
        Me.btnNotas.Location = New System.Drawing.Point(7, 537)
        Me.btnNotas.Name = "btnNotas"
        Me.btnNotas.Size = New System.Drawing.Size(160, 30)
        Me.btnNotas.TabIndex = 108
        Me.btnNotas.Text = "&Observaciones"
        Me.btnNotas.ToolTipText = "Agregar una nota al documento"
        Me.btnNotas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmFactura
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.btnNotas)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GrpSinAsignar)
        Me.Controls.Add(Me.CmbFormaPago)
        Me.Controls.Add(Me.LblSubtotal)
        Me.Controls.Add(Me.LblIVA)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.TxtIVA)
        Me.Controls.Add(Me.TxtSubtotal)
        Me.Controls.Add(Me.GrpCliente)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.ChkCredito)
        Me.Controls.Add(Me.TxtVence)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Me.Label9)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmFactura"
        Me.Text = "Factura"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        Me.GrpDetalle.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.GrpSinAsignar.ResumeLayout(False)
        Me.GrpSinAsignar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Ventas() As DataRow

    Public bLiquidacion As Boolean = False

    Public CAJClave As String
    Public Cajon As Boolean = False
    Public ImpresoraCajon As String = ""
    Public Cajero As String
    Public Recibo As String
    Public PrintGeneric As Boolean
    Public CajaActiva As Boolean = False

    Public SUCClave As String

    Private Moneda As String
    Private MonedaRef As String
    Private MonedaDesc As String
    Private TipoCambio As Double

    Private FACClave As String
    Private VENClave As String

    Private oCFD As CFD

    Private SaldoCliente As Double
    Private TotalFactura As Double
    Private SaldoFactura As Double
    Private SaldoVenta As Double
    Private Vencimiento As DateTime
    Private Credito As Integer
    Private MaxRow As Integer
    Private Vendedor As String
    Private PorcRiesgo As Double

    Private Periodo As Integer
    Private Mes As Integer
    Private Prefijo As String

    Private Impresora As String

    Private dtPAC, dtAsignados, dtDetalle, dtConcepto, dtImpuesto, dtImpuestoDet As DataTable
    Private FacturaCreada As Boolean = False
    Private Grabado As Boolean = False

    Private idFactura As String

    Private PathXML As String

    Private PathPDF, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP As String
    Private MailPort As Integer
    Private MailSSL As Boolean
    Private FormatoFactura As String
    Private Nota As String = Nothing
    Private olineas As Integer = 0

    Private ClienteTicket As String = ""
    '    Private tipoDeComprobante As String = "ingreso"
    ' Private LimiteCredito As Double
    'Receptor
    'Private CTEClave As String
    'Private CURP As String
    'Private Clave As String
    'Private TImpuesto As Integer
    'Private NombreCorto As String
    'Private RazonSocial As String
    'Private TPersona As Integer
    'Private RFC As String
    'Private LCredito As Double
    'Private DiasCredito As Integer
    'Private Contacto As String
    'Private Tel1 As String
    'Private Tel2 As String
    'Private email As String
    'Private listaPrecio As String
    'Private Desglosaiva As Boolean = False
    'Private Estado As Integer
    'Private FechaReg As Date
    'Private DCTEClave As String

    'Private Pais As String
    'Private Entidad As String
    'Private Mnpio As String
    'Private Calle As String
    'Private Colonia As String
    'Private Localidad As String
    'Private Referencia As String
    'Private noExterior As String
    'Private noInterior As String
    'Private codigoPostal As String
    'Private brnoInterior As Boolean

    'Private FOLClave As String
    'Private Serie As String
    'Private Folio As String

    'Comprobante


    'Private TipoCF As Integer
    'Private VersionCF As String
    'Private regimenFiscal As String
    'Private noCertificado As String
    'Private Certificado64 As String

    'Private formaDePago As String
    'Private metodoDePago As String

    'Private LlaveFile As String
    'Private ContrasenaClave As String
    'Private noAprobacion As String
    'Private anoAprobacion As String
    'Private fechaAprobacion As Date
    'Private CBB As Byte()
    'Private UUID As String
    'Private SelloSAT As String
    'Private CertificadoSAT As String
    'Private fechaTimbrado As Date = #1/1/1900#
    'Private versionSAT As String

    'Private subtotal As String
    'Private descuento As Double
    'Private impuestos As Double
    'Private total As String


    'Emisor

    'Private eRFC As String
    'Private eRazonSocial As String

    'Private ePais As String
    'Private eEntidad As String
    'Private eMnpio As String
    'Private eCalle As String
    'Private eColonia As String
    'Private eLocalidad As String
    'Private eReferencia As String
    'Private enoExterior As String
    'Private enoInterior As String
    'Private eCodigoPostal As String
    'Private benoInterior As Boolean
    'Sucursal
    'Private LugarExpedicion As String
    'Private sPais As String
    'Private sEntidad As String
    'Private sMnpio As String


    'Private sCalle As String
    'Private sColonia As String
    'Private sLocalidad As String
    'Private sReferencia As String
    'Private snoExterior As String
    'Private snoInterior As String
    'Private sCodigoPostal As String
    'Private iTipoSucursal As Integer
    'Private bsnoInterior As Boolean

    Private correo As MailMessage
    Private adjuntos As Attachment
    Private autenticar As NetworkCredential
    Private envio As SmtpClient
    Private dato As FileStream

    Private iTipoPAC As Integer = 0

    Private Sub SendMail(ByVal iTipoCF As Integer)

        Dim sPathXML, sMailCliente As String

        sMailCliente = oCFD.email

        If MailAdress = "" OrElse MailUser = "" OrElse MailPassword = "" OrElse HostSMTP = "" OrElse MailPort = 0 Then
            MessageBox.Show("No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Verifica que exista el path
        If iTipoCF <= 2 Then
            Try
                If Not System.IO.Directory.Exists(PathXML) Then
                    MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try
        End If

        Dim dtFactura As DataTable = ModPOS.Recupera_Tabla("sp_lista_facturas", "@FacturaId", idFactura)
        Dim fila As Integer

        For fila = 0 To dtFactura.Rows.Count - 1

            PathPDF = pathActual & "Temp\" & dtFactura.Rows(fila)("Folio") & ".PDF"

            'Genera PDF

            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "pvtaDataSet"

            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", dtFactura.Rows(fila)("FACClave")))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", dtFactura.Rows(fila)("FACClave")))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", dtFactura.Rows(fila)("FACClave")))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", dtFactura.Rows(fila)("FACClave")))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", dtFactura.Rows(fila)("FACClave")))

            If iTipoCF = 1 Then
                If FormatoFactura = "Clasico" Then
                    OpenReport.PrintPDF("CRIngresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(Redondear(dtFactura.Rows(fila)("total") / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                Else
                    OpenReport.PrintPDF("CRIngresoNCFD.rpt", pvtaDataSet, ModPOS.LetrasM(Redondear(dtFactura.Rows(fila)("total") / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                End If
            ElseIf iTipoCF = 2 Then

                If FormatoFactura = "Clasico" Then
                    OpenReport.PrintPDF("CRIngresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dtFactura.Rows(fila)("total") / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                Else
                    OpenReport.PrintPDF("CRIngresoNCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dtFactura.Rows(fila)("total") / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                End If

            ElseIf iTipoCF = 3 Then
                OpenReport.PrintPDF("CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dtFactura.Rows(fila)("total") / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
            End If

            If Not System.IO.File.Exists(PathPDF) Then
                MessageBox.Show("Ha ocurrido un error al generar el archivo: " & PathPDF, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Next

        'Envia Correo

        Dim frmStatusMessage As New frmStatus
        Try
            correo = New MailMessage
            autenticar = New NetworkCredential
            envio = New SmtpClient

            correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Factura (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agraciadecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
            correo.Subject = "Facturas"
            correo.IsBodyHtml = True
            correo.To.Clear()
            correo.CC.Clear()
            correo.Bcc.Clear()


            If sMailCliente.Split(",").Length >= 1 Then
                Dim i As Integer
                For i = 0 To sMailCliente.Split(",").Length - 1
                    correo.To.Add(sMailCliente.Split(",")(i))
                Next
            Else
                correo.To.Add(sMailCliente)
            End If


            correo.From = New MailAddress(MailAdress, DisplayName)
            envio.Credentials = New NetworkCredential(MailUser, MailPassword)
            envio.Host = HostSMTP  '"smtp.live.com"
            envio.Port = MailPort  '587
            envio.EnableSsl = MailSSL 'True

            frmStatusMessage.Show("Enviando correo electrónico...")

            For fila = 0 To dtFactura.Rows.Count - 1

                PathPDF = pathActual & "Temp\" & dtFactura.Rows(fila)("Folio") & ".PDF"

                If iTipoCF <= 2 Then
                    If PathXML.Length <= 3 Then
                        sPathXML = PathXML & dtFactura.Rows(fila)("Folio") & ".xml"
                    Else
                        sPathXML = PathXML & "\" & dtFactura.Rows(fila)("Folio") & ".xml"
                    End If



                    dato = New FileStream(sPathXML, FileMode.Open, FileAccess.Read)
                    adjuntos = New Attachment(dato, CStr(dtFactura.Rows(fila)("Folio")) & ".XML")
                    correo.Attachments.Add(adjuntos)

                End If

                dato = New FileStream(PathPDF, FileMode.Open, FileAccess.Read)
                adjuntos = New Attachment(dato, CStr(dtFactura.Rows(fila)("Folio")) & ".PDF")
                correo.Attachments.Add(adjuntos)
            Next
            dtFactura.Dispose()

            envio.Send(correo)
            correo.Dispose()

            MessageBox.Show("El mensaje fue enviado correctamente a el destinatario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmStatusMessage.Dispose()
        Catch ex As Exception
            frmStatusMessage.Dispose()
            MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dato.Close()

        Try
            My.Computer.FileSystem.DeleteFile(PathPDF, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub Aplica_Pagos(ByVal FacturaID As String, ByVal CTEClave As String, ByVal AbonoClave As String, ByVal TPago As Integer, ByVal TotalAbono As Double, ByVal TotalCambio As Double, ByVal ShowCambio As Boolean)
        Dim i As Integer
        Dim dts As DataTable
        Dim AcumulaPuntos As Integer
        dts = ModPOS.Recupera_Tabla("sp_recupera_cte_mostrador", "@Cliente", CTEClave)
        If dts.Rows(0)("POS") = 0 Then
            AcumulaPuntos = 1
        Else
            AcumulaPuntos = 0
        End If

        dts.Dispose()


        Dim dtFacturas As DataTable

        dtFacturas = ModPOS.Recupera_Tabla("sp_recupera_factura", "@FacturaID", FacturaID)

        Dim SaldoDisponible As Double

        SaldoDisponible = TotalAbono

        For i = 0 To dtFacturas.Rows.Count - 1

            Select Case Redondear(SaldoDisponible, 2)
                Case Is >= Redondear(dtFacturas.Rows(i)("Saldo"), 2)
                    ModPOS.Ejecuta("sp_paga_documento", _
                                                  "@ABNClave", AbonoClave, _
                                                  "@TipoDoc", 2, _
                                                  "@Documento", dtFacturas.Rows(i)("FACClave"), _
                                                  "@Pago", dtFacturas.Rows(i)("Saldo"), _
                                                  "@AcumulaPuntos", AcumulaPuntos, _
                                                  "Tipo", TPago, _
                                                  "@Usuario", ModPOS.UsuarioActual)
                    SaldoDisponible -= dtFacturas.Rows(i)("Saldo")
                Case Is < Redondear(dtFacturas.Rows(i)("Saldo"), 2)
                    ModPOS.Ejecuta("sp_actualiza_saldo", _
                                   "@ABNClave", AbonoClave, _
                                   "@Pago", SaldoDisponible, _
                                   "@TipoDoc", 2, _
                                   "@Documento", dtFacturas.Rows(i)("FACClave"), _
                                   "Tipo", TPago, _
                                   "@Usuario", ModPOS.UsuarioActual)
                    SaldoDisponible -= SaldoDisponible

            End Select


            If SaldoDisponible <= 0 Then
                Exit For
            End If
        Next

        ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", CTEClave, "@Importe", TotalAbono)

        If TotalAbono > 0 Then
            If ShowCambio = True Then
                Dim msg As New FrmMeMsg
                If TPago = 1 Then
                    msg.TxtTiulo = "Su Cambio es:"
                Else
                    msg.TxtTiulo = "Su Saldo a favor es:"
                End If
                msg.TxtMsg = Format(CStr(ModPOS.Redondear(TotalCambio, 2)), "Currency")
                msg.TxtMsg2 = Letras(CStr(ModPOS.Redondear(TotalCambio, 2))).ToUpper
                msg.ShowDialog()
                msg.Dispose()


                Select Case MessageBox.Show("¿Desea imprimir un recibo de los pagos realizados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes


                        ModPOS.MtoCXC.imprimeRecibo(AbonoClave, TotalAbono, TotalCambio, Impresora, PrintGeneric, Recibo, Cajero, oCFD.RazonSocial)

                        Dim bReimprimir As Boolean = True
                        Do
                            Select Case MessageBox.Show("¿Desea reimprimir un recibo de los pagos realizados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                Case DialogResult.Yes
                                    ModPOS.MtoCXC.imprimeRecibo(AbonoClave, TotalAbono, TotalCambio, Impresora, PrintGeneric, Recibo, Cajero, oCFD.RazonSocial)
                                Case Else
                                    bReimprimir = False
                            End Select
                        Loop While bReimprimir = True

                    Case Else
                End Select

            End If

        End If

    End Sub

    Private Function recalculaImpuestos(ByVal sFACClave As String, ByVal sDETClave As String, ByVal sPROClave As String, ByVal dPrecio As Double, ByVal Cantidad As Double, ByVal iTImpuesto As Integer, ByVal sSUCClave As String) As Double

        Dim PrecioImp As Double = dPrecio
        Dim ImpImporte As Double = 0
        Dim dtImpuesto As DataTable
        Dim i As Integer

        Dim PorcImp As Double = 0

        dtImpuesto = ModPOS.SiExisteRecupera("sp_venta_impuesto", "@PROClave", sPROClave, "@TImpuesto", iTImpuesto, "@SUCClave", sSUCClave)
        If Not dtImpuesto Is Nothing AndAlso Not dtImpuesto.Rows(0)("Valor") Is DBNull.Value Then
            For i = 0 To dtImpuesto.Rows.Count() - 1
                If dtImpuesto.Rows(i)("SobreImp") Then ' Si aplica sobre impuesto
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1  = Porcentaje
                        ImpImporte = PrecioImp * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                Else
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1 = Porcentaje
                        ImpImporte = dPrecio * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                End If
                PrecioImp += ImpImporte

                Dim row1 As DataRow
                row1 = dtImpuestoDet.NewRow()
                'declara el nombre de la fila
                row1.Item("FACClave") = sFACClave
                row1.Item("DFAClave") = sDETClave
                row1.Item("IMPClave") = dtImpuesto.Rows(i)("IMPClave")
                row1.Item("Impuesto") = dtImpuesto.Rows(i)("Nombre")
                row1.Item("Tasa") = dtImpuesto.Rows(i)("Valor")
                row1.Item("Importe") = ImpImporte
                row1.Item("Subtotal") = ImpImporte * Cantidad
                dtImpuestoDet.Rows.Add(row1)

            Next
            dtImpuesto.Dispose()
            PorcImp = (PrecioImp - dPrecio) / dPrecio
        End If
        Return ModPOS.Redondear(PorcImp, 4)
    End Function

    Public Sub CargaDatosCliente(ByVal sCTEClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", sCTEClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            sCTEClave = dt.Rows(0)("CTEClave")
            oCFD.CURP = dt.Rows(0)("CURP")
            oCFD.Clave = dt.Rows(0)("Clave")
            oCFD.TImpuesto = dt.Rows(0)("TipoImpuesto")
            oCFD.NombreCorto = dt.Rows(0)("NombreCorto")
            oCFD.RazonSocial = dt.Rows(0)("RazonSocial")
            oCFD.TPersona = dt.Rows(0)("TPersona")
            oCFD.RFC = dt.Rows(0)("id_Fiscal")
            oCFD.LCredito = dt.Rows(0)("LimiteCredito")
            oCFD.DiasCredito = dt.Rows(0)("DiasCredito")
            oCFD.Contacto = dt.Rows(0)("Contacto")
            oCFD.Tel1 = dt.Rows(0)("Tel1")
            oCFD.Tel2 = dt.Rows(0)("Tel2")
            oCFD.email = dt.Rows(0)("Email")
            oCFD.listaPrecio = dt.Rows(0)("PREClave")
            oCFD.NoDesglosaIEPS = dt.Rows(0)("DesglosaIVA")
            SUCClave = dt.Rows(0)("SUCClave")
            oCFD.GLN = IIf(dt.Rows(0)("GLN").GetType.Name = "DBNull", "", dt.Rows(0)("GLN"))

            oCFD.FechaReg = dt.Rows(0)("FechaRegistro")
            oCFD.Estado = dt.Rows(0)("Estado")
            oCFD.DCTEClave = dt.Rows(0)("DCTEClave")

            oCFD.Pais = dt.Rows(0)("Pais")
            oCFD.Entidad = dt.Rows(0)("Entidad")
            oCFD.Mnpio = dt.Rows(0)("Municipio")
            oCFD.Colonia = dt.Rows(0)("Colonia")
            oCFD.Calle = dt.Rows(0)("Calle")
            oCFD.Localidad = dt.Rows(0)("Localidad")
            oCFD.Referencia = dt.Rows(0)("referencia")
            oCFD.noExterior = dt.Rows(0)("noExterior")
            oCFD.noInterior = dt.Rows(0)("noInterior")
            oCFD.codigoPostal = dt.Rows(0)("codigoPostal")

            oCFD.NoDesglosaIEPS = dt.Rows(0)("DesglosaIVA")

            dt.Dispose()

            TxtClave.Text = oCFD.Clave
            TxtRazonSocial.Text = oCFD.RazonSocial
            TxtRFC.Text = oCFD.RFC

            LstDomicilio.Items.Clear()
            LstDomicilio.Items.Add(oCFD.Calle & " " & oCFD.noExterior & " " & oCFD.noInterior)
            LstDomicilio.Items.Add(oCFD.Colonia & ", " & oCFD.codigoPostal)
            LstDomicilio.Items.Add(oCFD.Mnpio & ", " & oCFD.Entidad)

            dt = ModPOS.SiExisteRecupera("sp_recupera_addcte", "@CTEClave", oCFD.CTEClave)

            If Not dt Is Nothing Then
                oCFD.tieneAddenda = True
                oCFD.Tipo = dt.Rows(0)("Tipo")
                oCFD.TipoConexion = dt.Rows(0)("TipoConexion")
                oCFD.UsuarioFTP = dt.Rows(0)("UsuarioFTP")
                oCFD.PwdFTP = dt.Rows(0)("PwdFTP")
                oCFD.FTP = dt.Rows(0)("FTP")
                oCFD.Firma = dt.Rows(0)("FirmaWeb")
                oCFD.emailAdd = dt.Rows(0)("email")
                oCFD.NoProveedor = dt.Rows(0)("NoProveedor")
            End If

        Else
            MessageBox.Show("La información del cliente no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Public Sub modificarCTE()
        If oCFD.CTEClave <> "" Then
            If ModPOS.Cliente Is Nothing Then
                ModPOS.Cliente = New FrmCliente
                With ModPOS.Cliente
                    .Text = "Modificar Cliente"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True
                    .fromForm = "Factura"

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", oCFD.CTEClave)

                    .CTEClave = dt.Rows(0)("CTEClave")
                    .TPersona = dt.Rows(0)("TPersona")
                    .Clave = dt.Rows(0)("Clave")
                    .NombreCorto = dt.Rows(0)("NombreCorto")
                    .RazonSocial = dt.Rows(0)("RazonSocial")
                    .RFC = dt.Rows(0)("id_Fiscal")
                    .CURP = dt.Rows(0)("CURP")
                    .TipoCanal = IIf(dt.Rows(0)("TipoCanal").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoCanal"))
                    .listaPrecio = IIf(dt.Rows(0)("PREClave").GetType.Name = "DBNull", "", dt.Rows(0)("PREClave"))
                    .Responsable = IIf(dt.Rows(0)("Responsable").GetType.Name = "DBNull", 0, dt.Rows(0)("Responsable"))
                    .CtaContable = IIf(dt.Rows(0)("CtaContable").GetType.Name = "DBNull", "", dt.Rows(0)("CtaContable"))

                    .FechaReg = dt.Rows(0)("FechaRegistro")
                    .Estado = dt.Rows(0)("Estado")
                    .Alterno = IIf(dt.Rows(0)("Alterno").GetType.Name = "DBNull", "", dt.Rows(0)("Alterno"))
                    .GLN = IIf(dt.Rows(0)("GLN").GetType.Name = "DBNull", "", dt.Rows(0)("GLN"))
                    .Ramo = IIf(dt.Rows(0)("Ramo").GetType.Name = "DBNull", 0, dt.Rows(0)("Ramo"))
                    .DesglosaIVA = dt.Rows(0)("DesglosaIVA")
                    .TipoImpuesto = dt.Rows(0)("TipoImpuesto")
                    .LCredito = dt.Rows(0)("LimiteCredito")
                    .DiasCredito = dt.Rows(0)("DiasCredito")

                    .PaisF = dt.Rows(0)("Pais")
                    .EntidadF = dt.Rows(0)("Entidad")
                    .MnpioF = dt.Rows(0)("Municipio")
                    .ColoniaF = dt.Rows(0)("Colonia")
                    .CalleF = dt.Rows(0)("Calle")
                    .LocalidadF = dt.Rows(0)("Localidad")
                    .referenciaF = dt.Rows(0)("referencia")
                    .noExteriorF = dt.Rows(0)("noExterior")
                    .noInteriorF = dt.Rows(0)("noInterior")
                    .codigoPostalF = dt.Rows(0)("codigoPostal")
                    .ZonaVentaF = IIf(dt.Rows(0)("ZonaVenta").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaVenta"))
                    .ZonaRepartoF = IIf(dt.Rows(0)("ZonaReparto").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaReparto"))

                    .Contacto = dt.Rows(0)("Contacto")
                    .Tel1 = dt.Rows(0)("Tel1")
                    .Tel2 = dt.Rows(0)("Tel2")
                    .email = dt.Rows(0)("Email")

                    .Saldo = dt.Rows(0)("Saldo")
                    .CreditoDisponible = dt.Rows(0)("Disponible")

                    .DCTEClaveFiscal = IIf(dt.Rows(0)("DCTEClave").GetType.Name = "DBNull", "", dt.Rows(0)("DCTEClave"))
                    dt.Dispose()

                End With
            End If

            ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Cliente.Show()
            ModPOS.Cliente.BringToFront()

        End If
    End Sub

    Private Sub CargaTickets(ByVal idFactura As String)
        dtAsignados = ModPOS.Recupera_Tabla("sp_filtra_TicketsAsignados", "@FacturaId", idFactura)
        Me.LstAsignados.DataSource = dtAsignados
        Me.LstAsignados.DisplayMember = dtAsignados.Columns(1).ColumnName
        Me.LstAsignados.ValueMember = dtAsignados.Columns(0).ColumnName
        Me.LstAsignados.ClearSelected()
    End Sub

    Private Function recuperaFolio(ByVal Caja As String, ByVal NumFolios As Integer) As Boolean
        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", Caja)

        SUCClave = dt.Rows(0)("SUCClave")
        Impresora = dt.Rows(0)("ImpresoraFac")

        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_folioactual", "@TipoComprobante", 1, "@SUCClave", SUCClave, "@CAJClave", CAJClave)

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            If dt.Compute("SUM(FolioFinal) - SUM(FolioActual)", "") >= NumFolios Then
                'If dt.Rows(0)("FolioActual") + NumFolios <= dt.Rows(0)("FolioFinal") Then
                oCFD.FOLClave = dt.Rows(0)("FOLClave")
                oCFD.noAprobacion = dt.Rows(0)("NoAprobacion")
                oCFD.anoAprobacion = CStr(dt.Rows(0)("AnoAprobacion"))
                oCFD.Serie = dt.Rows(0)("Serie")
                oCFD.Folio = CStr(dt.Rows(0)("FolioActual") + 1)
                oCFD.fechaAprobacion = IIf(dt.Rows(0)("fechaAprobacion").GetType.Name = "DBNull", Today(), dt.Rows(0)("fechaAprobacion"))

                If Not dt.Rows(0)("CBB") Is System.DBNull.Value Then
                    oCFD.CBB = CType(dt.Rows(0)("CBB"), Byte())
                End If

                dt.Dispose()

                ModPOS.Ejecuta("sp_incrementa_folio", "@FOLClave", oCFD.FOLClave)

                Return True
            Else
                MessageBox.Show("No existen suficientes folios disponibles para el tipo de comprobante seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Else
            MessageBox.Show("No existen folios disponibles para el tipo de comprobante seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function

    Private Sub ActualizaPuntos(ByVal FACID As String, ByVal CTE As String)
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_busca_puntos", "@FacturaId", FACID, "@CTEClave", CTE)
        If dt.Rows.Count > 0 Then
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                ModPOS.Ejecuta("sp_resta_puntos", "@FacturaId", FACID, "@CTEClave", dt.Rows(i)("Cliente"))
            Next
            ModPOS.Ejecuta("sp_suma_puntos", "@FacturaId", FACID, "@CTEClave", CTE)
        End If
        dt.Dispose()
    End Sub

    Private Sub FrmFactura_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If FacturaCreada AndAlso Not Grabado Then
            ModPOS.Ejecuta("sp_elimina_factura", _
                    "@idFactura", idFactura)
        ElseIf Not ModPOS.MtoFacturas Is Nothing Then
            If Not ModPOS.MtoFacturas.CmbSucursal.SelectedValue Is Nothing AndAlso ModPOS.MtoFacturas.Periodo > 0 AndAlso ModPOS.MtoFacturas.Mes > 0 Then
                ModPOS.MtoFacturas.refrescaGrid()
            End If
        End If

        If bLiquidacion = True AndAlso Not ModPOS.Liquid Is Nothing Then
            ModPOS.Liquid.ActualizaGridTransac()
        End If

        If bLiquidacion = True AndAlso Not ModPOS.MtoVenta Is Nothing Then
            ModPOS.MtoVenta.ActualizaGridTransac()
        End If

        ModPOS.Factura.Dispose()
        ModPOS.Factura = Nothing
    End Sub

    Private Sub TxtTicket_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTicket.KeyPress
        If Asc(e.KeyChar) = 13 Then

            If CmbCaja.SelectedValue Is Nothing Then
                MessageBox.Show("Debe seleccionar una Caja disponible para Facturar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If Not TxtTicket.Text = vbNullString Then
                    If CargaDatosTicket(DateTime.Today.Year(), DateTime.Today.Month(), TxtTicket.Text.ToUpper.Trim.Replace("'", "''")) Then
                        If oCFD.CTEClave <> "" AndAlso TxtClave.Text = "" Then
                            CargaDatosCliente(oCFD.CTEClave)
                        End If
                    End If
                    TxtTicket.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub ChkCredito_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkCredito.CheckedChanged
        If ChkCredito.Checked Then

            Dim dtRiesgo As DataTable
            dtRiesgo = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "PorcRiesgoCred", "@COMClave", ModPOS.CompanyActual)
            Dim Riesgo As Double = oCFD.LCredito * (CDbl(dtRiesgo.Rows(0)("Valor")) / 100)
            dtRiesgo.Dispose()

            If (oCFD.LCredito + Riesgo - SaldoCliente) > SaldoVenta Then
                Dim dtVencimiento As DataTable = ModPOS.SiExisteRecupera("sp_calcula_vencimiento", "@Dias", oCFD.DiasCredito)
                If Not dtVencimiento Is Nothing Then
                    Vencimiento = dtVencimiento.Rows(0)("Vencimiento")
                    dtVencimiento.Dispose()
                    TxtVence.Text = Vencimiento.ToLongDateString
                    CmbFormaPago.SelectedValue = 2
                End If
            Else
                CmbFormaPago.SelectedValue = 1
                TxtVence.Text = ""
                ChkCredito.Estado = 0
                MessageBox.Show("El importe total de la factura sobrepasa el credito disponible", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else

            TxtVence.Text = ""
        End If
    End Sub

    Private Sub BtnBuscaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaCte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                oCFD.CTEClave = a.valor
                CargaDatosCliente(oCFD.CTEClave)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub BtnBuscaTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaTicket.Click
        Dim a As New FrmBuscaTicket
        a.ShowDialog()
        a.Dispose()

        If oCFD.CTEClave <> "" AndAlso TxtClave.Text = "" Then
            CargaDatosCliente(oCFD.CTEClave)
        End If
        TxtTicket.Focus()
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Cliente Is Nothing Then
            ModPOS.Cliente = New FrmCliente
            ModPOS.Cliente.fromForm = "Factura"
            With ModPOS.Cliente
                .Text = "Agregar Cliente"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .UiTabSaldos.Enabled = False
            End With
        End If
        ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Cliente.Show()
        ModPOS.Cliente.BringToFront()
    End Sub

    Private Sub BtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbrir.Click
        If Me.TxtClave.Text <> "" Then
            modificarCTE()
        End If
    End Sub

    Private Sub BtnVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVendedor.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_usuario"
        a.TablaCmb = "Usuario"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = False
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                Vendedor = a.valor
                TxtVendedor.Text = a.Descripcion
            End If
        End If
        a.Dispose()
    End Sub

    Public Function CargaDatosTicket(ByVal Periodo As Integer, ByVal Mes As Integer, ByVal Folio As String) As Boolean
        'Valida que el campo Ticket no se encuentre vacio
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_busca_ticket", "@Periodo", Periodo, "@Mes", Mes, "@Folio", Folio, "@SUCClave", SUCClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then


            If LstAsignados.Items.Count = 0 Then
                ClienteTicket = dt.Rows(0)("Cliente")
            ElseIf ClienteTicket <> dt.Rows(0)("Cliente") Then
                MessageBox.Show("No es posible incluir ventas de diferentes clientes en una factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If



            VENClave = dt.Rows(0)("VENClave")
            If oCFD.CTEClave = "" Then
                oCFD.CTEClave = dt.Rows(0)("Cliente")
            End If
            Periodo = dt.Rows(0)("Periodo")
            Mes = dt.Rows(0)("Mes")
            SaldoVenta += dt.Rows(0)("Saldo")
            TotalFactura += dt.Rows(0)("Total")
            Vendedor = dt.Rows(0)("USRClave")
            TxtVendedor.Text = dt.Rows(0)("Vendedor")



            dt.Dispose()

            If Not FacturaCreada Then

                idFactura = ModPOS.obtenerLlave
                FACClave = ModPOS.obtenerLlave

                ModPOS.Ejecuta("sp_crea_factura", _
                "@FACClave", FACClave, _
                "@idFactura", idFactura, _
                "@CAJClave", CmbCaja.SelectedValue, _
                "@tipo", oCFD.tipoDeComprobante, _
                "@Usuario", ModPOS.UsuarioActual)

                FacturaCreada = True

                CmbCaja.Enabled = False

                BtnVendedor.Enabled = True

            End If

            ModPOS.Ejecuta("sp_agrega_tickfac", "@idFactura", idFactura, "@VENClave", VENClave)

            CargaTickets(idFactura)

            ModPOS.ActualizaGrid(False, Me.GridDetalle, "sp_muestra_detallefactura", "@idFactura", idFactura)
            GridDetalle.RootTable.Columns("Costo").Visible = False
            GridDetalle.RootTable.Columns("Impuesto").Visible = False
            GridDetalle.GroupByBoxVisible = False

            Dim dSubtotal As Double = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
            Dim dImpuesto As Double = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)

            TxtSubtotal.Text = Format(Redondear(dSubtotal, 2).ToString, "Currency")
            TxtIVA.Text = Format(Redondear(dImpuesto, 2).ToString, "Currency")
            TxtTotal.Text = Format(Redondear(dSubtotal + dImpuesto, 2).ToString, "Currency")


            If oCFD.LCredito = 0 OrElse SaldoVenta = 0 Then
                ChkCredito.Enabled = False
            Else
                ChkCredito.Enabled = True
                ChkCredito.Checked = True
            End If

            Return True
        Else
            MessageBox.Show("El folio introducido no esta disponible para facturar o el cliente no cuenta con datos fiscales para facturación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

    End Function

    Private Sub FrmFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oCFD = New CFD

        oCFD.tipoDeComprobante = "ingreso"

        FACClave = ModPOS.obtenerLlave

        With CmbFormaPago
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "CFD"
            .NombreParametro2 = "campo"
            .Parametro2 = "FormaPago"
            .llenar()
        End With

        With CmbCaja
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_caja"
            .NombreParametro1 = "Sucursal"
            .Parametro1 = SUCClave
            .llenar()
        End With


        If CAJClave <> "" Then
            CmbCaja.SelectedValue = CAJClave
            CmbCaja.Enabled = False
        End If

        Dim dtParam As DataTable
        Dim i As Integer



        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "LineasFac"
                        MaxRow = CInt(dtParam.Rows(i)("Valor"))
                    Case "PorcRiesgoCred"
                        PorcRiesgo = (CDbl(dtParam.Rows(i)("Valor")) / 100)
                    Case "DirXML"
                        PathXML = dtParam.Rows(i)("Valor")
                    Case "TipoCF"
                        oCFD.TipoCF = CInt(dtParam.Rows(i)("Valor"))
                    Case "VersionCF"
                        Dim dtmsg As DataTable
                        dtmsg = Recupera_Tabla("sp_recupera_valorref", "@Tabla", "CFD", "@Campo", "Version", "@estado", CInt(dtParam.Rows(i)("Valor")))
                        oCFD.VersionCF = dtmsg.Rows(0)("Descripcion")
                        dtmsg.Dispose()
                    Case "RegimenFiscal"
                        Dim dtmsg As DataTable
                        dtmsg = Recupera_Tabla("sp_recupera_valorref", "@Tabla", "CFD", "@Campo", "RegimenFiscal", "@estado", CInt(dtParam.Rows(i)("Valor")))
                        oCFD.regimenFiscal = dtmsg.Rows(0)("Descripcion")
                        dtmsg.Dispose()
                    Case "DirXML"
                        PathXML = dtParam.Rows(i)("Valor")
                    Case "MailAdress"
                        MailAdress = dtParam.Rows(i)("Valor")
                    Case "DisplayName"
                        DisplayName = dtParam.Rows(i)("Valor")
                    Case "MailUser"
                        MailUser = dtParam.Rows(i)("Valor")
                    Case "MailPassword"
                        MailPassword = dtParam.Rows(i)("Valor")
                    Case "HostSMTP"
                        HostSMTP = dtParam.Rows(i)("Valor")
                    Case "MailPort"
                        MailPort = IIf(IsNumeric(dtParam.Rows(i)("Valor")) = True, CInt(dtParam.Rows(i)("Valor")), 0)
                    Case "MailSSL"
                        MailSSL = IIf(dtParam.Rows(i)("Valor") = 1, True, False)
                    Case "Moneda"
                        Moneda = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "FormatFac"
                        FormatoFactura = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))



                End Select
            Next
        End With
        dtParam.Dispose()

        If oCFD.TipoCF = 2 Then
            dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)

            If dtPAC Is Nothing OrElse dtPAC.Rows.Count <= 0 Then
                MessageBox.Show("No se encontraron timbres disponibles, verifique la configuración de timbres en la Compañia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End If

        Dim dt As DataTable


        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        BtnTC.Text = dt.Rows(0)("Referencia")
        MonedaRef = dt.Rows(0)("Referencia")
        MonedaDesc = dt.Rows(0)("Descripcion")
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_muestra_monedas", Nothing)
        For i = 0 To dt.Rows.Count - 1
            Me.CtxDocumentos.Items.Add(dt.Rows(i)("Referencia"))
        Next
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            oCFD.noCertificado = dt.Rows(0)("Serie")
            oCFD.Certificado64 = dt.Rows(0)("Certificado")
            oCFD.LlaveFile = dt.Rows(0)("Llave")
            oCFD.ContrasenaClave = dt.Rows(0)("Password")
            dt.Dispose()
        Else
            MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        'Verifica que exista el path
        Try
            If Not System.IO.Directory.Exists(PathXML) Then
                MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        Catch ex As Exception
        End Try

        'Verifica que exista el path del .Key
        Try
            If Not System.IO.File.Exists(oCFD.LlaveFile) Then
                MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        Catch ex As Exception
        End Try

        Dim datetime As Date
        datetime = Now
        TxtVence.Text = Today
        Me.TxtFecha.Text = String.Format("{0:dd/MM/yyyy}", datetime)


        LstDomicilio.Items.Clear()
        TxtTicket.Focus()

        dtImpuestoDet = ModPOS.CrearTabla("ImpuestoDet", _
                                                 "FACClave", "System.String", _
                                                 "DFAClave", "System.String", _
                                                 "IMPClave", "System.String", _
                                                 "Impuesto", "System.String", _
                                                 "Tasa", "System.Double", _
                                                 "Importe", "System.Double", _
                                                 "Subtotal", "System.Double")


        If Not Ventas Is Nothing AndAlso Ventas.GetLength(0) > 0 Then
            For i = 0 To Ventas.GetUpperBound(0)
                Me.CargaDatosTicket(CDate(Ventas(i)("Fecha")).Year, CDate(Ventas(i)("Fecha")).Month, Ventas(i)("Folio"))
            Next

            If oCFD.CTEClave <> "" AndAlso TxtClave.Text = "" Then
                CargaDatosCliente(oCFD.CTEClave)
            End If
            TxtTicket.Focus()

        End If
    End Sub


    'Private Function generarCadenaOriginal(ByVal oCFD As CFD, ByVal FACClave As String) As String

    '    Dim i As Integer

    '    'Recupera encabezado de factura para NodoEncabezado.
    '    Dim sNodoConcepto As String = ""

    '    Dim foundRows() As DataRow
    '    foundRows = dtConcepto.Select("FACClave = '" & FACClave & "'")
    '    If foundRows.GetLength(0) > 0 Then


    '        Dim dSubtotal As Double = 0
    '        Dim dTotal As Double = 0

    '        For i = 0 To foundRows.GetUpperBound(0)
    '            sNodoConcepto = sNodoConcepto & CStr(foundRows(i)("Cantidad")) & "|" & foundRows(i)("Unidad") & "|" & foundRows(i)("Clave") & "|" & spaceFormat(CStr(foundRows(i)("Descripción")).Trim) & "|" & CStr(Redondear(foundRows(i)("P.U."), 6)) & "|" & CStr(ModPOS.Redondear(foundRows(i)("Cantidad") * foundRows(i)("P.U."), 6)) & "|"
    '            dSubtotal += foundRows(i)("Cantidad") * foundRows(i)("P.U.")
    '        Next
    '        oCFD.subtotal = CStr(Redondear(dSubtotal, 6))
    '        oCFD.total = CStr(Redondear(dSubtotal - oCFD.descuento, 6))
    '    End If


    '    Dim sNodoImpuestosTrasladado As String = ""

    '    foundRows = dtImpuesto.Select("FACClave = '" & FACClave & "'")

    '    oCFD.impuestos = 0

    '    If foundRows.GetLength(0) > 0 Then

    '        For i = 0 To foundRows.GetUpperBound(0)
    '            sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & foundRows(i)("Impuesto")
    '            sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & "|" & CStr(foundRows(i)("Tasa") * 100)
    '            sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & "|" & CStr(Redondear(foundRows(i)("Importe"), 6)) & "|"
    '            oCFD.impuestos += foundRows(i)("Importe")
    '        Next
    '    End If

    '    sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & CStr(Redondear(oCFD.impuestos, 6)) & "||"

    '    Dim sNodoEncabezado As String = "||" & oCFD.VersionCF & "|" & IIf(oCFD.TipoCF = 2, "", oCFD.Serie & "|" & oCFD.Folio & "|") & oCFD.Fecha & "|" & IIf(oCFD.TipoCF = 2, "", oCFD.noAprobacion & "|" & oCFD.anoAprobacion & "|") & oCFD.tipoDeComprobante & "|" & oCFD.formaDePago & "|" & oCFD.subtotal & "|" & CStr(oCFD.descuento) & "|" & oCFD.total & "|"

    '    Dim sNodoRegimenFiscal As String = ""

    '    If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then

    '        sNodoEncabezado &= oCFD.metodoDePago & "|" & oCFD.LugarExpedicion & "|"

    '        sNodoRegimenFiscal = oCFD.regimenFiscal & "|"

    '    End If

    '    Dim sNodoEmisor As String = spaceFormat(oCFD.eRFC) & "|" & spaceFormat(oCFD.eRazonSocial) & "|" & spaceFormat(oCFD.eCalle) & "|" & oCFD.enoExterior & IIf(oCFD.benoInterior, "|" & oCFD.enoInterior, "") & "|" & spaceFormat(oCFD.eColonia) & "|" & IIf(oCFD.eLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.eLocalidad)) & "|" & spaceFormat(oCFD.eReferencia) & "|" & oCFD.eMnpio & "|" & oCFD.eEntidad & "|" & oCFD.ePais & "|" & oCFD.eCodigoPostal & "|"
    '    Dim sNodoExpedicion As String = spaceFormat(oCFD.sCalle) & "|" & oCFD.snoExterior & IIf(oCFD.bsnoInterior, "|" & oCFD.snoInterior, "") & "|" & spaceFormat(oCFD.sColonia) & "|" & IIf(oCFD.sLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.sLocalidad)) & "|" & spaceFormat(oCFD.sReferencia) & "|" & oCFD.sMnpio & "|" & oCFD.sEntidad & "|" & oCFD.sPais & "|" & oCFD.sCodigoPostal & "|"
    '    Dim sNodoReceptor As String = spaceFormat(oCFD.RFC) & "|" & spaceFormat(oCFD.RazonSocial) & "|" & spaceFormat(oCFD.Calle) & "|" & oCFD.noExterior & IIf(oCFD.brnoInterior, "|" & oCFD.noInterior, "") & "|" & oCFD.Colonia & "|" & IIf(oCFD.Localidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.Localidad)) & "|" & IIf(oCFD.Referencia = "", "SIN REFERENCIA", spaceFormat(oCFD.Referencia)) & "|" & oCFD.Mnpio & "|" & oCFD.Entidad & "|" & oCFD.Pais & "|" & oCFD.codigoPostal & "|"

    '    If oCFD.iTipoSucursal = 1 Then
    '        sNodoExpedicion = ""
    '    End If

    '    Dim sCadenaOriginal As String = sNodoEncabezado & sNodoEmisor & sNodoExpedicion & sNodoRegimenFiscal & sNodoReceptor & sNodoConcepto & sNodoImpuestosTrasladado


    '    Return sCadenaOriginal

    'End Function

    'Private Function generarSelloDigital(ByVal scadenaOriginal As String) As String
    '    Dim FileName As String

    '    FileName = Serie & Folio

    '    'Verifica que exista el path
    '    Try
    '        If Not System.IO.Directory.Exists("C:\SelladoDigital\") Then
    '            System.IO.Directory.CreateDirectory("C:\SelladoDigital\")
    '        End If
    '    Catch ex As Exception
    '    End Try

    '    Dim DirSello As String = "C:\SelladoDigital\" & Path.GetFileName(LlaveFile)

    '    If Not System.IO.File.Exists(DirSello) Then
    '        If System.IO.File.Exists(LlaveFile) Then
    '            System.IO.File.Copy(LlaveFile, DirSello)
    '        Else
    '            Return False
    '            MessageBox.Show("El archivo " & LlaveFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Exit Function
    '        End If
    '    End If

    '    Dim cadenaOriginal As String = "C:\SelladoDigital\" & FileName & ".txt"

    '    Dim file_stream As New FileStream(cadenaOriginal, FileMode.Create)
    '    Dim bytes As Byte() = New UTF8Encoding().GetBytes(scadenaOriginal)

    '    file_stream.Write(bytes, 0, bytes.Length)
    '    file_stream.Close()


    '    'Donde
    '    'cadenaOriginal: es el directorio donde se creara el archivo que contiene la cadena original

    '    Dim frmStatusMessage As New frmStatus
    '    frmStatusMessage.Show("Generando Sello Digital...")


    '    Dim dir As String
    '    Dim DirArchivoPEM As String = DirSello & ".pem"

    '    dir = "C:\OpenSSL\bin\openssl.exe"

    '    Shell(dir & " pkcs8 -inform DER -in " & DirSello & " -passin pass:" & ContrasenaClave & " -out " & DirArchivoPEM, AppWinStyle.Hide, True)


    '    'Donde
    '    'DirSello: es el directorio donde se encuentra el archivo.key
    '    'ContrasenaClave: es la contraseña

    '    Dim sello As String = "C:\SelladoDigital\" & FileName & "_sello.txt"
    '    ' Dim digestioncadena As String = "C:\" & "digestioncadena.txt"




    '    'Donde 
    '    'cadenaOriginal : es el directorio deonde se creo el archivo que contiene la cadenaOriginal
    '    'Sello: es el directorio donde se realizara el sellado del archivo donde se realizo la digestion de la cadena original
    '    'DirArchivoPEM: es el directorio y archivo .key.pem

    '    Shell(dir & " dgst -sha1 -out " & sello & " -sign " & DirArchivoPEM & " " & cadenaOriginal, AppWinStyle.Hide, True)


    '    Dim sello64 As String = "C:\SelladoDigital\" & FileName & "_sello64.txt"



    '    'Donde
    '    'Sello: nombre del archivo.txt donde fue creado el sellado de la digestion de la cadena original
    '    'Sello64: nombre del archivo.txt donde se creara el sello en caracteres imprimibles


    '    Shell(dir & " enc -base64 -in " & sello & " -out " & sello64 & " -A", AppWinStyle.Hide, True)


    '    Dim elsello As String

    '    Dim file As New System.IO.StreamReader(sello64)
    '    elsello = file.ReadLine()

    '    file.Close()

    '    frmStatusMessage.Dispose()

    '    If elsello = "" Then
    '        MessageBox.Show("Error al generar el sello digital, verifique que la contraseña del Certificado de Sello Digital que ingreso en la configuración de la compañia sea la correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If

    '    Try
    '        My.Computer.FileSystem.DeleteFile(cadenaOriginal, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
    '        My.Computer.FileSystem.DeleteFile(sello, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
    '        My.Computer.FileSystem.DeleteFile(sello64, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

    '    Catch ex As Exception
    '        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
    '    End Try

    '    Return elsello

    'End Function

    'Public Sub crearQR()
    '    Try
    '        Dim encoderQR As New ThoughtWorks.QRCode.Codec.QRCodeEncoder

    '        '122 bytes de datos en este encode!!
    '        encoderQR.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE
    '        encoderQR.QRCodeScale = 3
    '        encoderQR.QRCodeVersion = 7
    '        encoderQR.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.M

    '        Dim imagen As System.Drawing.Bitmap
    '        're	RFC del Emisor, a 12/13 posiciones, precedido por el texto ”?re=”--------------------------------------------------------------------------------------- 17
    '        'rr	RFC del Receptor, a 12/13 posiciones, precedido por el texto “&rr=” ------------------------------------------------------------------------------------ 17
    '        'tt	Total del comprobante a 17 posiciones (10 para los enteros, 1 para carácter “.”, 6 para los decimales), precedido por el texto “&tt=” ---------21
    '        'id	UUID del comprobante, precedido por el texto “&id=”------------------------------------------------------------------------------------------------------- 40
    '        imagen = encoderQR.Encode("?re=" & oCFD.eRFC & "&rr=" & oCFD.RFC & "&tt=" & cFormat(CStr(Redondear(CDbl(oCFD.total), 6))) & "&id=" & oCFD.UUID)
    '        oCFD.CBB = ModPOS.ConvertBitmapToByteArray(imagen)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error al generar QR Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub



    'Public Sub crearXML(ByVal FACClave As String, ByVal elsello As String)
    '    Dim i As Integer
    '    Dim FileXML As String
    '    Dim sPre As String = ""

    '    If oCFD.TipoCF = 2 Then
    '        sPre = "cfdi:"
    '    End If

    '    FileXML = pathActual & "CFD\" & oCFD.Serie & oCFD.Folio & ".xml"


    '    Dim textWriter As XmlTextWriter = New XmlTextWriter(FileXML, Encoding.UTF8)
    '    textWriter.Formatting = Formatting.None
    '    ' Opens the document
    '    textWriter.WriteStartDocument()

    '    ' Write comments

    '    If TxtExtra.Text.Trim <> "" Then
    '        textWriter.WriteComment(Me.TxtExtra.Text.Trim)
    '    End If

    '    ' Write first element

    '    textWriter.WriteStartElement(sPre & "Comprobante")

    '    If oCFD.VersionCF = "2.0" OrElse oCFD.VersionCF = "2.2" Then
    '        textWriter.WriteAttributeString("xmlns", "http://www.sat.gob.mx/cfd/2")
    '    ElseIf oCFD.VersionCF = "3.0" OrElse oCFD.VersionCF = "3.2" Then
    '        textWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")
    '    End If

    '    textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")

    '    Select Case oCFD.VersionCF
    '        Case Is = "2.0"
    '            textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv2.xsd")
    '        Case Is = "2.2"
    '            textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv22.xsd")
    '        Case Is = "3.0"
    '            textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv3.xsd")
    '        Case Is = "3.2"
    '            textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd")
    '    End Select

    '    textWriter.WriteAttributeString("version", oCFD.VersionCF)

    '    If oCFD.Serie <> "" Then
    '        textWriter.WriteAttributeString("serie", oCFD.Serie)
    '    End If

    '    textWriter.WriteAttributeString("folio", oCFD.Folio)
    '    textWriter.WriteAttributeString("fecha", oCFD.Fecha)
    '    textWriter.WriteAttributeString("sello", elsello)
    '    If oCFD.TipoCF = 1 Then
    '        textWriter.WriteAttributeString("noAprobacion", oCFD.noAprobacion)
    '        textWriter.WriteAttributeString("anoAprobacion", oCFD.anoAprobacion)
    '    End If
    '    textWriter.WriteAttributeString("formaDePago", oCFD.formaDePago)
    '    textWriter.WriteAttributeString("noCertificado", oCFD.noCertificado)
    '    textWriter.WriteAttributeString("certificado", oCFD.Certificado64)
    '    textWriter.WriteAttributeString("subTotal", Redondear(oCFD.subtotal, 6))
    '    textWriter.WriteAttributeString("descuento", CStr(Redondear(oCFD.descuento, 6)))
    '    textWriter.WriteAttributeString("total", Redondear(oCFD.total, 6))
    '    textWriter.WriteAttributeString("tipoDeComprobante", oCFD.tipoDeComprobante)

    '    If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then
    '        textWriter.WriteAttributeString("metodoDePago", oCFD.metodoDePago)
    '        textWriter.WriteAttributeString("LugarExpedicion", spaceFormat(oCFD.LugarExpedicion))
    '    End If

    '    textWriter.WriteStartElement(sPre & "Emisor")
    '    textWriter.WriteAttributeString("rfc", spaceFormat(oCFD.eRFC))
    '    textWriter.WriteAttributeString("nombre", spaceFormat(oCFD.eRazonSocial))
    '    textWriter.WriteStartElement(sPre & "DomicilioFiscal")
    '    textWriter.WriteAttributeString("calle", spaceFormat(oCFD.eCalle))
    '    textWriter.WriteAttributeString("noExterior", oCFD.enoExterior)

    '    If oCFD.benoInterior Then
    '        textWriter.WriteAttributeString("noInterior", oCFD.enoInterior)
    '    End If

    '    textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.eColonia))
    '    textWriter.WriteAttributeString("localidad", IIf(oCFD.eLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.eLocalidad)))
    '    textWriter.WriteAttributeString("referencia", spaceFormat(oCFD.eReferencia))
    '    textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.eMnpio))
    '    textWriter.WriteAttributeString("estado", oCFD.eEntidad)
    '    textWriter.WriteAttributeString("pais", oCFD.ePais)
    '    textWriter.WriteAttributeString("codigoPostal", oCFD.eCodigoPostal)
    '    'Cierre de Domicilio
    '    textWriter.WriteEndElement()

    '    If oCFD.iTipoSucursal <> 1 Then
    '        textWriter.WriteStartElement(sPre & "ExpedidoEn")
    '        textWriter.WriteAttributeString("calle", spaceFormat(oCFD.sCalle))
    '        textWriter.WriteAttributeString("noExterior", oCFD.snoExterior)

    '        If oCFD.bsnoInterior Then
    '            textWriter.WriteAttributeString("noInterior", oCFD.snoInterior)
    '        End If

    '        textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.sColonia))
    '        textWriter.WriteAttributeString("localidad", IIf(oCFD.sLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.sLocalidad)))
    '        textWriter.WriteAttributeString("referencia", spaceFormat(oCFD.sReferencia))
    '        textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.sMnpio))
    '        textWriter.WriteAttributeString("estado", oCFD.sEntidad)
    '        textWriter.WriteAttributeString("pais", oCFD.sPais)
    '        textWriter.WriteAttributeString("codigoPostal", oCFD.sCodigoPostal)
    '        'Cierre de centro de expedición
    '        textWriter.WriteEndElement()
    '    End If

    '    If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then
    '        textWriter.WriteStartElement(sPre & "RegimenFiscal")
    '        textWriter.WriteAttributeString("Regimen", oCFD.regimenFiscal)
    '        textWriter.WriteEndElement()
    '    End If

    '    'Cierre de Emisor
    '    textWriter.WriteEndElement()

    '    textWriter.WriteStartElement(sPre & "Receptor")
    '    textWriter.WriteAttributeString("rfc", spaceFormat(oCFD.RFC))
    '    textWriter.WriteAttributeString("nombre", spaceFormat(oCFD.RazonSocial))
    '    textWriter.WriteStartElement(sPre & "Domicilio")
    '    textWriter.WriteAttributeString("calle", spaceFormat(oCFD.Calle))
    '    textWriter.WriteAttributeString("noExterior", oCFD.noExterior)

    '    If oCFD.brnoInterior Then
    '        textWriter.WriteAttributeString("noInterior", oCFD.noInterior)
    '    End If

    '    textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.Colonia))
    '    textWriter.WriteAttributeString("localidad", IIf(oCFD.Localidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.Localidad)))
    '    textWriter.WriteAttributeString("referencia", spaceFormat(oCFD.Referencia))
    '    textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.Mnpio))
    '    textWriter.WriteAttributeString("estado", oCFD.Entidad)
    '    textWriter.WriteAttributeString("pais", oCFD.Pais)
    '    textWriter.WriteAttributeString("codigoPostal", oCFD.codigoPostal)
    '    'Cierre de Domicilioi
    '    textWriter.WriteEndElement()
    '    'Cierre de Receptor
    '    textWriter.WriteEndElement()


    '    textWriter.WriteStartElement(sPre & "Conceptos")
    '    'Inicia for para llenar detalle
    '    Dim foundRows() As DataRow
    '    foundRows = dtConcepto.Select("FACClave = '" & FACClave & "'")
    '    If foundRows.GetLength(0) > 0 Then
    '        For i = 0 To foundRows.GetUpperBound(0)
    '            textWriter.WriteStartElement(sPre & "Concepto")
    '            textWriter.WriteAttributeString("cantidad", foundRows(i)("Cantidad"))
    '            textWriter.WriteAttributeString("unidad", foundRows(i)("Unidad"))
    '            textWriter.WriteAttributeString("noIdentificacion", foundRows(i)("Clave"))
    '            textWriter.WriteAttributeString("descripcion", spaceFormat(CStr(foundRows(i)("Descripción")).Trim))
    '            textWriter.WriteAttributeString("valorUnitario", Redondear(foundRows(i)("P.U."), 6))
    '            textWriter.WriteAttributeString("importe", Redondear(foundRows(i)("Cantidad") * foundRows(i)("P.U."), 6))
    '            textWriter.WriteEndElement()

    '        Next
    '        'Fin de ciclo
    '    End If
    '    'Cierre de Conceptos
    '    textWriter.WriteEndElement()

    '    ' Write one more element
    '    textWriter.WriteStartElement(sPre & "Impuestos")
    '    textWriter.WriteAttributeString("totalImpuestosTrasladados", Redondear(oCFD.impuestos, 6))

    '    textWriter.WriteStartElement(sPre & "Traslados")

    '    foundRows = dtImpuesto.Select("FACClave = '" & FACClave & "'")

    '    'Inicio ciclo de impuestos
    '    If foundRows.GetLength(0) > 0 Then

    '        For i = 0 To foundRows.GetUpperBound(0)
    '            textWriter.WriteStartElement(sPre & "Traslado")
    '            textWriter.WriteAttributeString("impuesto", foundRows(i)("Impuesto"))
    '            textWriter.WriteAttributeString("tasa", foundRows(i)("Tasa") * 100)
    '            textWriter.WriteAttributeString("importe", Redondear(foundRows(i)("Importe"), 6))
    '            textWriter.WriteEndElement()
    '        Next

    '    End If
    '    'fin de ciclo de impuestos

    '    'Cierre de Traslados
    '    textWriter.WriteEndElement()
    '    'Cierre de Impuesto
    '    textWriter.WriteEndElement()

    '    'Cierre de Comprobante
    '    textWriter.WriteEndElement()
    '    ' Ends the document.
    '    textWriter.WriteEndDocument()
    '    ' close writer
    '    textWriter.Close()

    '    If oCFD.TipoCF = 2 Then
    '        Dim oCfdi As New LibCFDiTralix.CFDiTralix()
    '        Dim oXml As New Xml.XmlDocument()
    '        oXml.Load(FileXML)
    '        Dim oTimbre As LibCFDiTralix.com.tralix.pac.TimbreFiscalDigital

    '        Dim frmStatusMessage As New frmStatus
    '        frmStatusMessage.Show("Solicitado Timbre Fiscal...")
    '        'https://pruebastfd.tralix.com:7070
    '        oTimbre = oCfdi.TimbrarCFDi(oXml.OuterXml, ServidorTimbrado, CustomerKey)
    '        frmStatusMessage.Dispose()

    '        If oTimbre Is Nothing Then
    '            MsgBox("Se tuvo el siguiente error " + vbCrLf + "[" + CType(LibCFDiTralix.CodigoMensaje.eCodigo, Integer).ToString() + "]" + LibCFDiTralix.CodigoMensaje.eCodigo.ToString() + ": " + LibCFDiTralix.CodigoMensaje.sMensaje)
    '            oCFD.UUID = "NO_VALIDO_FOLIO_FISCAL"
    '            oCFD.SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
    '            bTimbreError = True
    '            ModPOS.Ejecuta("sp_actualiza_edo_fac", "@FACClave", FACClave, "@Estado", 2)
    '        Else
    '            bTimbreError = False
    '            oCFD.UUID = oTimbre.UUID
    '            oCFD.SelloSAT = oTimbre.selloSAT
    '            oCFD.CertificadoSAT = oTimbre.noCertificadoSAT
    '            oCFD.fechaTimbrado = oTimbre.FechaTimbrado
    '            oCFD.versionSAT = oTimbre.version

    '            Dim newElem As Xml.XmlElement = oXml.CreateElement("cfdi", "Complemento", "http://www.sat.gob.mx/cfd/3")

    '            Dim newEle1 As Xml.XmlElement = oXml.CreateElement("tfd", "TimbreFiscalDigital", "http://www.sat.gob.mx/TimbreFiscalDigital")
    '            ' 1. Create a new Book element.


    '            Dim newAttr As Xml.XmlAttribute

    '            newAttr = oXml.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
    '            newAttr.Value = "http://www.sat.gob.mx/TimbreFiscalDigital TimbreFiscalDigital.xsd"
    '            newEle1.Attributes.Append(newAttr)

    '            newAttr = oXml.CreateAttribute("selloCFD")
    '            newAttr.Value = elsello
    '            newEle1.Attributes.Append(newAttr)

    '            newAttr = oXml.CreateAttribute("selloSAT")
    '            newAttr.Value = oCFD.SelloSAT
    '            newEle1.Attributes.Append(newAttr)

    '            newAttr = oXml.CreateAttribute("UUID")
    '            newAttr.Value = oCFD.UUID
    '            newEle1.Attributes.Append(newAttr)


    '            newAttr = oXml.CreateAttribute("FechaTimbrado")
    '            newAttr.Value = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", oCFD.fechaTimbrado)
    '            newEle1.Attributes.Append(newAttr)


    '            newAttr = oXml.CreateAttribute("version")
    '            newAttr.Value = oCFD.versionSAT
    '            newEle1.Attributes.Append(newAttr)

    '            newAttr = oXml.CreateAttribute("noCertificadoSAT")
    '            newAttr.Value = oCFD.CertificadoSAT
    '            newEle1.Attributes.Append(newAttr)

    '            newElem.AppendChild(newEle1)
    '            oXml.DocumentElement.AppendChild(newElem)
    '            oXml.Save(FileXML)

    '        End If
    '    End If

    '    'Verifica que exista el path
    '    Try
    '        If System.IO.Directory.Exists(PathXML) Then
    '            If PathXML.Length <= 3 Then
    '                System.IO.File.Copy(FileXML, PathXML & oCFD.Serie & oCFD.Folio & ".xml")
    '            Else
    '                System.IO.File.Copy(FileXML, PathXML & "\" & oCFD.Serie & oCFD.Folio & ".xml")
    '            End If
    '        Else
    '            MessageBox.Show("El directorio " & PathXML & " no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub


    Public Function crearCF(ByVal FacturaID As String) As Boolean
        Dim i As Integer

        Dim dt As DataTable

        'Recupera información del Emisor

        dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)

        oCFD.eRazonSocial = dt.Rows(0)("Nombre")
        oCFD.eRFC = dt.Rows(0)("id_Fiscal")
        oCFD.ePais = dt.Rows(0)("Pais")
        oCFD.eEntidad = dt.Rows(0)("Estado")
        oCFD.eMnpio = dt.Rows(0)("Municipio")
        oCFD.eColonia = dt.Rows(0)("Colonia")
        oCFD.eCalle = dt.Rows(0)("Calle")
        oCFD.eCodigoPostal = dt.Rows(0)("CodigoPostal")
        oCFD.eReferencia = dt.Rows(0)("Referencia")
        oCFD.eLocalidad = dt.Rows(0)("Localidad")
        oCFD.enoExterior = dt.Rows(0)("noExterior")
        oCFD.enoInterior = dt.Rows(0)("noInterior")
        dt.Dispose()

        If oCFD.eReferencia = "" Then
            oCFD.eReferencia = "SIN REFERENCIA"
        End If

        If oCFD.enoInterior <> "" Then
            oCFD.benoInterior = True
        Else
            oCFD.benoInterior = False
        End If

        'Recupera Información del Centro de Expedición

        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)

        oCFD.iTipoSucursal = dt.Rows(0)("Tipo")
        oCFD.sPais = dt.Rows(0)("Pais")
        oCFD.sEntidad = dt.Rows(0)("Entidad")
        oCFD.sMnpio = dt.Rows(0)("Municipio")
        oCFD.sColonia = dt.Rows(0)("Colonia")
        oCFD.sCalle = dt.Rows(0)("Calle")
        oCFD.sCodigoPostal = dt.Rows(0)("CodigoPostal")
        oCFD.sReferencia = dt.Rows(0)("Referencia")
        oCFD.sLocalidad = dt.Rows(0)("Localidad")
        oCFD.snoExterior = dt.Rows(0)("noExterior")
        oCFD.snoInterior = dt.Rows(0)("noInterior")
        dt.Dispose()

        If oCFD.sReferencia = "" Then
            oCFD.sReferencia = "SIN REFERENCIA"
        End If

        If oCFD.snoInterior <> "" Then
            oCFD.bsnoInterior = True
        Else
            oCFD.bsnoInterior = False
        End If

        oCFD.LugarExpedicion = oCFD.sCalle & " " & oCFD.snoExterior & IIf(oCFD.bsnoInterior, " INT " & oCFD.snoInterior, "") & "," & oCFD.sMnpio & "," & oCFD.sEntidad

        'Receptor

        If oCFD.Referencia = "" Then
            oCFD.Referencia = "SIN REFERENCIA"
        End If

        If oCFD.noInterior <> "" Then
            oCFD.brnoInterior = True
        Else
            oCFD.brnoInterior = False
        End If

        'Se llena la tabla dt con todos los FACClave relacionados al FacturaID
        dt = ModPOS.Recupera_Tabla("sp_recupera_facturas", "@FacturaID", FacturaID)

        dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_concepto", "@FacturaID", FacturaID)

        dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_impuestos", "@FacturaID", FacturaID)

        For i = 0 To dt.Rows.Count - 1
            oCFD.Serie = dt.Rows(i)("Serie")
            oCFD.Folio = dt.Rows(i)("Folio")
            oCFD.descuento = dt.Rows(i)("descuentoTot")
            oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dt.Rows(i)("fechaFactura"))
            'oCFD.extra = TxtExtra.Text
            oCFD.Moneda = MonedaRef
            oCFD.TipoCambio = TipoCambio

            If oCFD.TipoCF = 1 OrElse oCFD.TipoCF = 2 Then
                oCFD.DOCClave = dt.Rows(i)("FACClave")

                If oCFD.TipoCF = 1 Then
                    oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
                Else
                    oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, 1)
                End If

                oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave)


                iTipoPAC = crearXML(1, dtPAC, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, 1)

            Else
                actualizaEdoCFD(oCFD.tipoDeComprobante, oCFD.DOCClave, 1, 1)
            End If


            If oCFD.tieneAddenda = True Then
                If oCFD.Tipo = 1 Then

                    Dim NombreArchivo As String = oCFD.Serie & oCFD.Folio & ".xml"

                    Try
                        Dim osvSoriana As New com.soriana.www.wseDocRecibo()
                        osvSoriana.Url = oCFD.Firma
                        osvSoriana.Timeout = 50000

                        Dim xmlDoc As New System.Xml.XmlDocument()
                        xmlDoc.Load(System.IO.Path.Combine(PathXML, NombreArchivo))

                        ' Now create StringWriter object to get data from xml document.
                        Dim sw As New System.IO.StringWriter()
                        Dim xw As New System.Xml.XmlTextWriter(sw)
                        xmlDoc.WriteTo(xw)

                        Dim res As String = osvSoriana.RecibeCFD(sw.ToString())

                        Dim dsRes As New System.Data.DataSet()
                        Dim ms As System.IO.MemoryStream
                        Dim buf As [Byte]()

                        buf = System.Text.ASCIIEncoding.ASCII.GetBytes(res)
                        ms = New System.IO.MemoryStream(buf)
                        dsRes.ReadXml(ms)

                        If dsRes.Tables("AckErrorApplication").Rows(0)("documentStatus").ToString().ToUpper() = "ACCEPTED" Then
                            Dim sAPERAK As String = System.IO.Path.Combine(PathXML, "APERAK_" & System.IO.Path.GetFileNameWithoutExtension(NombreArchivo) & "_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".xml")
                            Using fs As System.IO.FileStream = System.IO.File.Open(sAPERAK, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                                ms.WriteTo(fs)
                                ms.Dispose()
                            End Using
                            dsRes.Dispose()


                            ModPOS.Ejecuta("sp_upd_complemento_envio", "@FACClave", oCFD.FACClave)

                            MessageBox.Show("XML Aceptado : FACTURA " & oCFD.Serie & oCFD.Folio & ": Revisar " & sAPERAK, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            Dim sAPERAK As String = System.IO.Path.Combine(PathXML, "APERAK_" & System.IO.Path.GetFileNameWithoutExtension(NombreArchivo) & "_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".xml")
                            Using fs As System.IO.FileStream = System.IO.File.Open(sAPERAK, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                                ms.WriteTo(fs)
                                ms.Dispose()
                            End Using
                            Throw New Exception("XML Rechazado: Revisar " & sAPERAK)
                        End If
                    Catch ex As System.Exception
                        MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try

                End If
            End If

        Next
        dt.Dispose()
        dtConcepto.Dispose()
        dtImpuesto.Dispose()

        Return True
    End Function

    Private Function VerificaDatoFiscalCte() As Boolean
        Dim Cadena As String = ""
        Dim Valido As Boolean = True

        If oCFD.Pais = "" Then
            Cadena &= "Pais,"
        End If

        If oCFD.Entidad = "" Then
            Cadena &= "Entidad,"
        End If

        If oCFD.Mnpio = "" Then
            Cadena &= "Municipio,"
        End If
        If oCFD.Colonia = "" Then
            Cadena &= "Colonia,"
        End If

        If oCFD.Calle = "" Then
            Cadena &= "Calle,"
        End If

        If oCFD.noExterior = "" Then
            Cadena &= "No. Exterior,"
        End If

        If oCFD.codigoPostal = "" Then
            Cadena &= "Código Postal,"
        End If

        If TxtRazonSocial.Text = "" Then
            Cadena &= "Razón Social,"
        End If


        If LstDomicilio.Items.Count = 0 Then
            Cadena &= "Domicilio de Facturación"
        End If


        If oCFD.RFC <> "" AndAlso oCFD.RFC.Length >= 12 AndAlso oCFD.RFC.Length <= 13 Then
            If oCFD.TPersona = 1 Then
                If ModPOS.soloLetras(oCFD.RFC.Substring(3, 1)) = False Then
                    Cadena &= "RFC,"
                End If
            End If
        Else
            Cadena &= "RFC,"
        End If


        If Cadena = "" Then
            Valido = True
        Else
            MessageBox.Show("La siguiente información del cliente No es valida ó es requerida para facturar: " & Cadena & " para completarla, edite la información del cliente seleccionado presionando el botón de Abrir junto al Filtro de busqueda y selección de cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Valido = False
        End If


        Return Valido
    End Function

    Private Sub Aplica_Pagos_Tickets(ByVal FacturaID As String, ByVal TotalAbono As Double, ByVal sCTEClave As String)
        Dim i As Integer
        Dim dtFacturas As DataTable
        Dim SaldoDisponible As Double

        SaldoDisponible = TotalAbono

        dtFacturas = ModPOS.Recupera_Tabla("sp_recupera_factura", "@FacturaID", FacturaID)


        For i = 0 To dtFacturas.Rows.Count - 1

            Select Case Redondear(SaldoDisponible, 2)
                Case Is >= Redondear(dtFacturas.Rows(i)("Saldo"), 2)
                    ModPOS.Ejecuta("sp_actualiza_saldofac", _
                                                  "@FACClave", dtFacturas.Rows(i)("FACClave"), _
                                                  "@Abono", dtFacturas.Rows(i)("Saldo"))

                    SaldoDisponible -= dtFacturas.Rows(i)("Saldo")

                Case Is < Redondear(dtFacturas.Rows(i)("Saldo"), 2)
                    ModPOS.Ejecuta("sp_actualiza_saldofac", _
                                   "@FACClave", dtFacturas.Rows(i)("FACClave"), _
                                   "@Abono", SaldoDisponible)

                    SaldoDisponible -= SaldoDisponible
            End Select



            If SaldoDisponible <= 0 Then
                Exit For
            End If
        Next

        ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", sCTEClave, "@Importe", TotalAbono)

        dtFacturas.Dispose()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        BtnGuardar.Enabled = False

        'Inicia Sección de Validaciones 
        If Not CmbCaja.SelectedValue Is Nothing Then
            CAJClave = CmbCaja.SelectedValue
        Else
            MessageBox.Show("Debe seleccionar una Caja valida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnGuardar.Enabled = True
            Exit Sub
        End If

        If GridDetalle.RowCount <= 0 Then
            MessageBox.Show("No es posible generar la factura debido a que no se encontraron productos disponibles para los tickets seleccionados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnGuardar.Enabled = True
            Exit Sub
        End If

        If Not VerificaDatoFiscalCte() Then
            BtnGuardar.Enabled = True
            Exit Sub
        End If

        If Not CmbFormaPago.SelectedValue Is Nothing Then
            oCFD.formaDePago = Me.CmbFormaPago.Text.Trim
        Else
            MessageBox.Show("Debe seleccionar una opcion valida de Forma de Pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnGuardar.Enabled = True
            Exit Sub
        End If

        'Seccion para agregar multiples metodos de pago
        If ModPOS.MetodoPago Is Nothing Then
            ModPOS.MetodoPago = New FrmMetodoPago
            With ModPOS.MetodoPago
                .CTEClave = oCFD.CTEClave
                .FacturaId = idFactura
            End With
        End If

        ModPOS.MetodoPago.StartPosition = FormStartPosition.CenterScreen

        If ModPOS.MetodoPago.ShowDialog = Windows.Forms.DialogResult.OK Then
            If ModPOS.MetodoPago.MetodoDePago <> "" Then
                oCFD.metodoDePago = ModPOS.MetodoPago.MetodoDePago
                oCFD.NumCtaPago = ModPOS.MetodoPago.NumCtaPago
            Else
                MessageBox.Show("Ha ocurrido un error al recuperar los metodos de pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BtnGuardar.Enabled = True
                Exit Sub
            End If
        Else
            MessageBox.Show("Debe seleccionar una opcion valida de Metodo de Pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnGuardar.Enabled = True
            Exit Sub
        End If

        ModPOS.MetodoPago.Dispose()
        ModPOS.MetodoPago = Nothing

        If Not ChkCredito.Checked Then
            Vencimiento = #1/1/1900#
        Else
            'Recupera Factura Vencida con Saldo y Porcentaje de Riesgo
            Dim dtValida As DataTable

            Dim Riesgo As Double = oCFD.LCredito * PorcRiesgo

            If CDbl(TxtTotal.Text) > (oCFD.LCredito + Riesgo - SaldoCliente) Then
                MessageBox.Show("No es posible realizar la factura debido a que el importe total de la factura sobrepasa el crédito disponible del cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            dtValida = ModPOS.Recupera_Tabla("sp_valida_credito", "@Cliente", oCFD.CTEClave, "@DiasCredito", oCFD.DiasCredito)

            If dtValida.Rows.Count > 0 Then
                If MessageBox.Show("El cliente actual tiene la factura " & dtValida.Rows(0)("Serie") & dtValida.Rows(0)("Folio") & " con saldo de " & CStr(Redondear(dtValida.Rows(0)("Saldo"), 2)) & " vencida desde el " & CStr(dtValida.Rows(0)("FechaVencimiento")) & "¿Desea continuar y facturar la venta actual?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                    dtValida.Dispose()
                    Exit Sub
                Else
                    dtValida.Dispose()
                End If
            Else
                dtValida.Dispose()
            End If

        End If

        ' Termina Sección de Validaciones

        If oCFD.tieneAddenda = True Then
            If oCFD.Tipo = 1 Then
                'abrir cuadro de dialogo para registro de 

                Dim a As New FrmComplemento
                a.FacturaId = idFactura

                a.ShowDialog()

                If a.DialogResult = DialogResult.OK Then
                    If a.Autorizado Then
                        oCFD.FechaEntrega = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", a.FechaEntrega)
                        oCFD.NotaEntrada = a.NotaEntrada
                        oCFD.NoCita = a.NoCita
                        oCFD.FACClave = FACClave
                    Else
                        a.Dispose()
                        Exit Sub
                    End If
                ElseIf a.DialogResult = DialogResult.Cancel Then
                    a.Dispose()
                    Exit Sub
                End If

                a.Dispose()

            End If
        End If

        Dim NumFacturas As Integer

        dtDetalle = ModPOS.Recupera_Tabla("sp_detallefactura", "@idFactura", idFactura)

        NumFacturas = Int(dtDetalle.Rows.Count / MaxRow)

        If oCFD.tieneAddenda = True Then
            NumFacturas = 1
        ElseIf NumFacturas = 0 Then
            NumFacturas = 1
        ElseIf NumFacturas < (dtDetalle.Rows.Count / MaxRow) Then
            NumFacturas += 1
        End If

        Dim NumFacturasAbn As Integer

        NumFacturasAbn = NumFacturas

        If Not recuperaFolio(CAJClave, NumFacturas) Then
            Exit Sub
        End If

        Dim FolioInicial As String
        Dim FolioFinal As String

        FolioInicial = oCFD.Serie & CStr(oCFD.Folio)

        Dim fila As Integer
        Dim contador As Integer


        If oCFD.tieneAddenda Then
            oCFD.CantBultos = dtDetalle.Compute("SUM(Cantidad)", "PROClave=PROClave")
            oCFD.CantPedidos = dtAsignados.Rows.Count
        End If

        For fila = 0 To dtDetalle.Rows.Count - 1

            If contador = MaxRow AndAlso oCFD.tieneAddenda = False Then

                ModPOS.Ejecuta("sp_actualiza_factura", _
                "@FACClave", FACClave, _
                "@TipoCF", oCFD.TipoCF, _
                "@VersionCF", oCFD.VersionCF, _
                "@RegimenFiscal", oCFD.regimenFiscal, _
                "@fechaAprobacion", oCFD.fechaAprobacion, _
                "@Serie", oCFD.Serie, _
                "@Folio", oCFD.Folio, _
                "@CTEClave", oCFD.CTEClave, _
                "@Credito", ChkCredito.GetEstado, _
                "@DiasCredito", oCFD.DiasCredito, _
                "@FechaVencimiento", Vencimiento, _
                "@CAJClave", CmbCaja.SelectedValue, _
                "@Facturo", Vendedor, _
                "@Desglosar", oCFD.NoDesglosaIEPS, _
                "@formaDePago", oCFD.formaDePago, _
                "@MONClave", Moneda, _
                "@TipoCambio", TipoCambio, _
                "@Nota", Nota)

                FACClave = ModPOS.obtenerLlave
                NumFacturas -= 1
                recuperaFolio(CAJClave, NumFacturas)

                ModPOS.Ejecuta("sp_crea_factura", _
                "@FACClave", FACClave, _
                "@idFactura", idFactura, _
                "@CAJClave", CmbCaja.SelectedValue, _
                "@tipo", oCFD.tipoDeComprobante, _
                "@Usuario", ModPOS.UsuarioActual)

                contador = 0
            End If

            Dim PorcImp As Double = recalculaImpuestos(FACClave, dtDetalle.Rows(fila)("DFAClave"), dtDetalle.Rows(fila)("PROClave"), dtDetalle.Rows(fila)("PrecioBruto") - dtDetalle.Rows(fila)("DescuentoImp"), dtDetalle.Rows(fila)("Cantidad"), oCFD.TImpuesto, SUCClave)

            ModPOS.Ejecuta("sp_inserta_detallefactura", _
            "@DFAClave", dtDetalle.Rows(fila)("DFAClave"), _
            "@FACClave", FACClave, _
            "@Producto", dtDetalle.Rows(fila)("PROClave"), _
            "@TProducto", dtDetalle.Rows(fila)("TProducto"), _
            "@Costo", dtDetalle.Rows(fila)("Costo"), _
            "@PrecioBruto", dtDetalle.Rows(fila)("PrecioBruto"), _
            "@DescuentoImp", dtDetalle.Rows(fila)("DescuentoImp"), _
            "@ImpuestoImp", (dtDetalle.Rows(fila)("PrecioBruto") - dtDetalle.Rows(fila)("DescuentoImp")) * PorcImp, _
            "@PuntosImp", dtDetalle.Rows(fila)("PuntosImp"), _
            "@Cantidad", dtDetalle.Rows(fila)("Cantidad"))


            contador += 1
        Next
        dtDetalle.Dispose()

        ModPOS.Ejecuta("sp_actualiza_factura", _
                        "@FACClave", FACClave, _
                        "@TipoCF", oCFD.TipoCF, _
                        "@VersionCF", oCFD.VersionCF, _
                        "@RegimenFiscal", oCFD.regimenFiscal, _
                        "@fechaAprobacion", oCFD.fechaAprobacion, _
                        "@Serie", oCFD.Serie, _
                        "@Folio", oCFD.Folio, _
                        "@CTEClave", oCFD.CTEClave, _
                        "@Credito", ChkCredito.GetEstado, _
                        "@DiasCredito", oCFD.DiasCredito, _
                        "@FechaVencimiento", Vencimiento, _
                        "@CAJClave", CmbCaja.SelectedValue, _
                        "@Facturo", Vendedor, _
                        "@Desglosar", oCFD.NoDesglosaIEPS, _
                        "@formaDePago", oCFD.formaDePago, _
                        "@MONClave", Moneda, _
                        "@TipoCambio", TipoCambio, _
                        "@Nota", Nota)

        For fila = 0 To dtImpuestoDet.Rows.Count - 1
            ModPOS.Ejecuta("sp_desglosa_impuestos", _
                            "@DFAClave", dtImpuestoDet.Rows(fila)("DFAClave"), _
                            "@IMPClave", dtImpuestoDet.Rows(fila)("IMPClave"), _
                            "@PorcImp", dtImpuestoDet.Rows(fila)("Tasa"), _
                            "@Importe", dtImpuestoDet.Rows(fila)("Importe"), _
                            "@Usuario", ModPOS.UsuarioActual)
        Next

        dtImpuestoDet.Dispose()


        FolioFinal = oCFD.Serie & CStr(oCFD.Folio)

        TxtFolio.Text = oCFD.Serie & CStr(oCFD.Folio)



        If Int(dtDetalle.Rows.Count / MaxRow) <= 1 OrElse oCFD.tieneAddenda = True Then
            MessageBox.Show("Se genero la factura " & FolioInicial, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("Se generaron las facturas del " & FolioInicial & " al " & FolioFinal, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


        dtDetalle.Dispose()

        crearCF(idFactura)

        Dim dtAbonos, dtSaldos As DataTable

        dtAbonos = ModPOS.Recupera_Tabla("sp_obtiene_saldofac", "@idFactura", idFactura)

        ModPOS.Ejecuta("sp_cambia_ticketfactura", "@idFactura", idFactura, "@CTEClave", oCFD.CTEClave)

        If dtAbonos.Rows.Count > 0 Then

            If CDbl(dtAbonos.Rows(0)("Abonos")) > 0 Then
                Me.Aplica_Pagos_Tickets(idFactura, CDbl(dtAbonos.Rows(0)("Abonos")), oCFD.CTEClave)
            End If

        End If

        dtAbonos.Dispose()


        dtSaldos = ModPOS.Recupera_Tabla("sp_recupera_factura", "@FacturaID", idFactura)
        SaldoFactura = IIf(dtSaldos.Compute("Sum(Saldo)", "Saldo > 0") Is System.DBNull.Value, 0, dtSaldos.Compute("Sum(Saldo)", "Saldo > 0"))
        dtSaldos.Dispose()

        If ChkCredito.GetEstado = 0 AndAlso CajaActiva = True AndAlso SaldoFactura > 0 Then
            If Not ModPOS.MtoCXC Is Nothing Then

                If ModPOS.SiExite(ModPOS.BDConexion, "sp_aplicar_abn", "@CTEClave", oCFD.CTEClave) > 0 Then
                    Dim b As New FrmAbnPendiente
                    b.Cliente = oCFD.CTEClave
                    b.CAJClave = CAJClave
                    b.SaldoDocumento = SaldoFactura
                    b.ShowDialog()

                    If b.DialogResult = DialogResult.OK Then
                        If Not b.drAbonos Is Nothing AndAlso b.drAbonos.Length > 0 Then
                            Dim i As Integer
                            For i = 0 To b.drAbonos.Length - 1
                                Aplica_Pagos(idFactura, oCFD.CTEClave, b.drAbonos(i)("ID"), b.drAbonos(i)("TipoPago"), b.drAbonos(i)("Saldo"), IIf(b.drAbonos(i)("Saldo") > SaldoFactura, b.drAbonos(i)("Saldo") - SaldoFactura, 0), False)
                            Next
                        End If
                    End If

                    dtSaldos = ModPOS.Recupera_Tabla("sp_recupera_factura", "@FacturaID", idFactura)
                    SaldoFactura = IIf(dtSaldos.Compute("Sum(Saldo)", "Saldo > 0") Is System.DBNull.Value, 0, dtSaldos.Compute("Sum(Saldo)", "Saldo > 0"))
                    dtSaldos.Dispose()

                End If

                If SaldoFactura > 0 Then
                    Dim a As New FrmAbono
                    a.VariosPagos = IIf(NumFacturasAbn = 1, False, True)
                    a.TipoDocumento = 2
                    a.CAJA = CAJClave
                    a.ClaveCte = oCFD.CTEClave
                    a.ClaveDocumento = FACClave
                    a.SaldoAcumulado = SaldoFactura
                    a.AperturaCajon = Cajon
                    a.ImpresoraCajon = ImpresoraCajon
                    a.ShowDialog()

                    If a.DialogResult = DialogResult.OK Then
                        Aplica_Pagos(idFactura, oCFD.CTEClave, a.AbonoClave, a.TPago, a.TotalAbono, a.TotalCambio, True)
                    End If
                End If

                If Not ModPOS.MtoCXC Is Nothing Then
                    ModPOS.MtoCXC.AgregarFolio()
                End If

                If Not Ventas Is Nothing AndAlso Ventas.GetLength(0) > 0 AndAlso Not ModPOS.Liquid Is Nothing Then
                    ModPOS.Liquid.ActualizaGridTransac()
                End If

            End If
        End If

        '  ModPOS.Ejecuta("sp_act_saldo_cte", "@Cliente", oCFD.CTEClave)

        'Inicia
        If oCFD.TipoCF = 2 AndAlso iTipoPAC = 0 Then
            MessageBox.Show("No ha sido posible certificar este documento, le recomendamos intentar certificarlo más tarde", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Grabado = True
            Me.Close()
            BtnGuardar.Enabled = True
            Exit Sub
        End If



        Select Case MessageBox.Show("¿Desea imprimir las facturas?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case DialogResult.Yes
                imprimirFactura(oCFD.TipoCF)

                If ChkCredito.GetEstado = 1 Then
                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
                    Dim NumCopias As Integer = IIf(dt.Rows(0)("copiaCredito").GetType.Name = "DBNull", 0, dt.Rows(0)("copiaCredito"))
                    If NumCopias > 0 Then
                        Dim i As Integer
                        For i = 1 To NumCopias
                            imprimirFactura(oCFD.TipoCF)
                        Next
                    End If
                End If

        End Select

        If oCFD.email <> "" Then
            Select Case MessageBox.Show("¿Desea enviar el documento por correo electrónico?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    SendMail(oCFD.TipoCF)
            End Select
        End If


        Grabado = True

        Me.Close()
    End Sub

    Private Sub imprimirFactura(ByVal iTipoCF As Integer)
        Dim sImpresora As String
        Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", Impresora)
        sImpresora = dtPrinter.Rows(0)("Referencia")
        dtPrinter.Dispose()

        Dim dtFactura As DataTable = ModPOS.Recupera_Tabla("sp_lista_facturas", "@FacturaId", idFactura)
        Dim fila As Integer

        For fila = 0 To dtFactura.Rows.Count - 1

            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "pvtaDataSet"

            'OpenReport.PrintPreview("Factura", "CRFactura.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.Redondear(TotalFactura, 2)).ToUpper)
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", dtFactura.Rows(fila)("FACClave")))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", dtFactura.Rows(fila)("FACClave")))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", dtFactura.Rows(fila)("FACClave")))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", dtFactura.Rows(fila)("FACClave")))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", dtFactura.Rows(fila)("FACClave")))

            If iTipoCF = 1 Then
                If FormatoFactura = "Clasico" Then
                    OpenReport.Print("CRIngresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dtFactura.Rows(fila)("total") / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
                Else
                    OpenReport.Print("CRIngresoNCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dtFactura.Rows(fila)("total") / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
                End If
                'OpenReport.PrintPDF("CRIngresoCFD.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.Redondear(dtFactura.Rows(fila)("total"), 2)).ToUpper, "E:\" & Me.Serie & Me.Folio & ".PDF")
            ElseIf iTipoCF = 2 Then
                If FormatoFactura = "Clasico" Then
                    OpenReport.Print("CRIngresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dtFactura.Rows(fila)("total") / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
                Else
                    OpenReport.Print("CRIngresoNCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dtFactura.Rows(fila)("total") / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
                End If
            ElseIf iTipoCF = 3 Then
                OpenReport.Print("CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dtFactura.Rows(fila)("total") / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
            End If

        Next
        dtFactura.Dispose()
    End Sub

    Private Sub TxtBusqueda_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBusqueda.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtBusqueda.Text <> "" Then
                    Dim dtCliente As DataTable
                    dtCliente = ModPOS.SiExisteRecupera("sp_consulta_clientedomicilio", "@Cliente", TxtBusqueda.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                    If Not dtCliente Is Nothing AndAlso dtCliente.Rows.Count > 0 Then
                        oCFD.CTEClave = dtCliente.Rows(0)("CTEClave")
                        dtCliente.Dispose()
                        CargaDatosCliente(oCFD.CTEClave)
                    End If
                End If
            Case Is = Keys.Right

                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_cliente"
                a.TablaCmb = "Cliente"
                a.CampoCmb = "Filtro"
                a.OcultaID = True
                a.BusquedaInicial = True
                a.CompaniaRequerido = True
                a.Busqueda = TxtBusqueda.Text.Trim.ToUpper
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.valor Is Nothing Then
                        oCFD.CTEClave = a.valor
                        CargaDatosCliente(oCFD.CTEClave)
                    End If
                End If
                a.Dispose()
        End Select

    End Sub

    Private Sub BtnDevolucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDevolucion.Click
        If Me.LstAsignados.SelectedIndex <> -1 Then

            If MessageBox.Show("¿Esta seguro de remover el ticket " & Me.LstAsignados.Items(Me.LstAsignados.SelectedIndex)(1) & " de la factura actual?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                ModPOS.Ejecuta("sp_elimina_ticket_fac", "@VENClave", Me.LstAsignados.Items(Me.LstAsignados.SelectedIndex)(0))

                CargaTickets(idFactura)

                ModPOS.ActualizaGrid(False, Me.GridDetalle, "sp_muestra_detallefactura", "@idFactura", idFactura)
                GridDetalle.RootTable.Columns("Costo").Visible = False
                GridDetalle.RootTable.Columns("Impuesto").Visible = False
                GridDetalle.GroupByBoxVisible = False

                Dim dSubtotal As Double = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
                Dim dImpuesto As Double = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)

                TxtSubtotal.Text = Format(Redondear(dSubtotal, 2).ToString, "Currency")
                TxtIVA.Text = Format(Redondear(dImpuesto, 2).ToString, "Currency")
                TxtTotal.Text = Format(Redondear(dSubtotal + dImpuesto, 2).ToString, "Currency")
            End If

        Else
            MessageBox.Show("No se encuentra algun ticket seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub CtxDocumentos_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles CtxDocumentos.ItemClicked
        BtnTC.Text = e.ClickedItem.Text

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_tipocambio", "@Moneda", e.ClickedItem.Text)
        Moneda = dt.Rows(0)("MONClave")
        MonedaRef = dt.Rows(0)("Referencia")
        MonedaDesc = dt.Rows(0)("Descripcion")
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()

        If CInt(TipoCambio) <> 1 Then
            LblTipoCambio.Text = "T.C. " & Format(CStr(ModPOS.Redondear(TipoCambio, 2)), "Currency")
        Else
            LblTipoCambio.Text = ""
        End If
        SendKeys.Send("{TAB}")

    End Sub

    Private Sub BtnTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTC.Click
        BtnTC.ContextMenuStrip.Show(BtnTC, New Point(0, 0), ToolStripDropDownDirection.AboveRight)
    End Sub

    Private Sub btnNotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotas.Click

        Dim a As New FrmObservaciones
        a.Nota = Me.Nota
        a.lineas = Me.olineas
        a.ShowDialog()
        Me.Nota = a.Nota
        Me.olineas = a.lineas
        a.Dispose()
    End Sub
End Class
