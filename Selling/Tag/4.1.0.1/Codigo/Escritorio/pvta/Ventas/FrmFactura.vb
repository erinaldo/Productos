Imports System.Xml
Imports System.Xml.Schema
Imports System.Text
Imports System
Imports System.Security.Cryptography
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
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LstDomicilio As System.Windows.Forms.ListBox
    Friend WithEvents TxtRFC As System.Windows.Forms.TextBox
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtTicket As System.Windows.Forms.TextBox
    Friend WithEvents TxtVence As System.Windows.Forms.TextBox
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents TxtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents ChkCredito As Selling.ChkStatus
    Friend WithEvents GrpSinAsignar As System.Windows.Forms.GroupBox
    Friend WithEvents LstAsignados As System.Windows.Forms.ListBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAbrir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents BtnDevolucion As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnTC As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents btnNotas As Janus.Windows.EditControls.UIButton
    Friend WithEvents CtxDocumentos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmbUsoCFDI As Selling.StoreCombo
    Friend WithEvents CmbCaja As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFactura))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox()
        Me.LblTipoCambio = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnTC = New Janus.Windows.EditControls.UIButton()
        Me.CtxDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CmbCaja = New Selling.StoreCombo()
        Me.TxtVendedor = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.TxtVence = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ChkCredito = New Selling.ChkStatus(Me.components)
        Me.TxtTicket = New System.Windows.Forms.TextBox()
        Me.BtnBuscaTicket = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.GrpCliente = New System.Windows.Forms.GroupBox()
        Me.TxtBusqueda = New System.Windows.Forms.TextBox()
        Me.BtnAbrir = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.TxtRFC = New System.Windows.Forms.TextBox()
        Me.LstDomicilio = New System.Windows.Forms.ListBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BtnBuscaCte = New Janus.Windows.EditControls.UIButton()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.GrpSinAsignar = New System.Windows.Forms.GroupBox()
        Me.BtnDevolucion = New Janus.Windows.EditControls.UIButton()
        Me.LstAsignados = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnNotas = New Janus.Windows.EditControls.UIButton()
        Me.cmbUsoCFDI = New Selling.StoreCombo()
        Me.GrpGeneral.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCliente.SuspendLayout()
        Me.GrpSinAsignar.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpGeneral.Controls.Add(Me.LblTipoCambio)
        Me.GrpGeneral.Controls.Add(Me.Label3)
        Me.GrpGeneral.Controls.Add(Me.BtnTC)
        Me.GrpGeneral.Controls.Add(Me.Label12)
        Me.GrpGeneral.Controls.Add(Me.CmbCaja)
        Me.GrpGeneral.Controls.Add(Me.TxtVendedor)
        Me.GrpGeneral.Controls.Add(Me.LblNombre)
        Me.GrpGeneral.Controls.Add(Me.TxtVence)
        Me.GrpGeneral.Controls.Add(Me.Label9)
        Me.GrpGeneral.Controls.Add(Me.ChkCredito)
        Me.GrpGeneral.Location = New System.Drawing.Point(508, 4)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(277, 161)
        Me.GrpGeneral.TabIndex = 1
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "General"
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Location = New System.Drawing.Point(50, 53)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(89, 15)
        Me.LblTipoCambio.TabIndex = 112
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 54)
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
        Me.BtnTC.Location = New System.Drawing.Point(145, 46)
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
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(5, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 15)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Caja"
        '
        'CmbCaja
        '
        Me.CmbCaja.Location = New System.Drawing.Point(72, 19)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(200, 21)
        Me.CmbCaja.TabIndex = 97
        '
        'TxtVendedor
        '
        Me.TxtVendedor.Enabled = False
        Me.TxtVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendedor.Location = New System.Drawing.Point(7, 128)
        Me.TxtVendedor.Multiline = True
        Me.TxtVendedor.Name = "TxtVendedor"
        Me.TxtVendedor.ReadOnly = True
        Me.TxtVendedor.Size = New System.Drawing.Size(264, 19)
        Me.TxtVendedor.TabIndex = 3
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(5, 110)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(61, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Vendio"
        '
        'TxtVence
        '
        Me.TxtVence.Enabled = False
        Me.TxtVence.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVence.Location = New System.Drawing.Point(53, 80)
        Me.TxtVence.Name = "TxtVence"
        Me.TxtVence.ReadOnly = True
        Me.TxtVence.Size = New System.Drawing.Size(116, 21)
        Me.TxtVence.TabIndex = 94
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(5, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 14)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "Vence"
        '
        'ChkCredito
        '
        Me.ChkCredito.Location = New System.Drawing.Point(175, 80)
        Me.ChkCredito.Name = "ChkCredito"
        Me.ChkCredito.Size = New System.Drawing.Size(96, 21)
        Me.ChkCredito.TabIndex = 3
        Me.ChkCredito.Text = "Credito"
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
        Me.BtnBuscaTicket.Location = New System.Drawing.Point(126, 15)
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
        Me.GrpDetalle.Location = New System.Drawing.Point(167, 169)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(618, 354)
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
        Me.GridDetalle.Size = New System.Drawing.Size(605, 331)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridDetalle.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.GridDetalle.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
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
        Me.GrpCliente.Location = New System.Drawing.Point(7, 4)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(494, 161)
        Me.GrpCliente.TabIndex = 2
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "Datos Cliente"
        '
        'TxtBusqueda
        '
        Me.TxtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtBusqueda.Location = New System.Drawing.Point(81, 17)
        Me.TxtBusqueda.Name = "TxtBusqueda"
        Me.TxtBusqueda.Size = New System.Drawing.Size(141, 21)
        Me.TxtBusqueda.TabIndex = 96
        '
        'BtnAbrir
        '
        Me.BtnAbrir.Icon = CType(resources.GetObject("BtnAbrir.Icon"), System.Drawing.Icon)
        Me.BtnAbrir.Location = New System.Drawing.Point(298, 16)
        Me.BtnAbrir.Name = "BtnAbrir"
        Me.BtnAbrir.Size = New System.Drawing.Size(58, 24)
        Me.BtnAbrir.TabIndex = 95
        Me.BtnAbrir.ToolTipText = "Modificar datos del Cliente"
        Me.BtnAbrir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(362, 16)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(58, 24)
        Me.BtnAgregar.TabIndex = 94
        Me.BtnAgregar.ToolTipText = "Agregar nuevo Cliente"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRFC
        '
        Me.TxtRFC.Enabled = False
        Me.TxtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRFC.Location = New System.Drawing.Point(82, 44)
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
        Me.LstDomicilio.Location = New System.Drawing.Point(7, 98)
        Me.LstDomicilio.Name = "LstDomicilio"
        Me.LstDomicilio.Size = New System.Drawing.Size(480, 49)
        Me.LstDomicilio.TabIndex = 92
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(7, 46)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(60, 15)
        Me.lblRFC.TabIndex = 91
        Me.lblRFC.Text = "RFC/Clave"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(6, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 20)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Razón Social"
        '
        'BtnBuscaCte
        '
        Me.BtnBuscaCte.Image = CType(resources.GetObject("BtnBuscaCte.Image"), System.Drawing.Image)
        Me.BtnBuscaCte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaCte.Location = New System.Drawing.Point(234, 16)
        Me.BtnBuscaCte.Name = "BtnBuscaCte"
        Me.BtnBuscaCte.Size = New System.Drawing.Size(58, 24)
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
        Me.TxtRazonSocial.Location = New System.Drawing.Point(81, 68)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(405, 23)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Buscar"
        '
        'TxtClave
        '
        Me.TxtClave.Enabled = False
        Me.TxtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave.Location = New System.Drawing.Point(234, 44)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.ReadOnly = True
        Me.TxtClave.Size = New System.Drawing.Size(186, 21)
        Me.TxtClave.TabIndex = 3
        '
        'GrpSinAsignar
        '
        Me.GrpSinAsignar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpSinAsignar.Controls.Add(Me.BtnDevolucion)
        Me.GrpSinAsignar.Controls.Add(Me.LstAsignados)
        Me.GrpSinAsignar.Controls.Add(Me.TxtTicket)
        Me.GrpSinAsignar.Controls.Add(Me.BtnBuscaTicket)
        Me.GrpSinAsignar.Location = New System.Drawing.Point(7, 169)
        Me.GrpSinAsignar.Name = "GrpSinAsignar"
        Me.GrpSinAsignar.Size = New System.Drawing.Size(154, 354)
        Me.GrpSinAsignar.TabIndex = 93
        Me.GrpSinAsignar.TabStop = False
        Me.GrpSinAsignar.Text = "Tickets"
        '
        'BtnDevolucion
        '
        Me.BtnDevolucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDevolucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDevolucion.Image = CType(resources.GetObject("BtnDevolucion.Image"), System.Drawing.Image)
        Me.BtnDevolucion.Location = New System.Drawing.Point(99, 15)
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
        Me.LstAsignados.Size = New System.Drawing.Size(146, 290)
        Me.LstAsignados.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(193, 541)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 14)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Uso del Comprobante"
        '
        'btnNotas
        '
        Me.btnNotas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNotas.Icon = CType(resources.GetObject("btnNotas.Icon"), System.Drawing.Icon)
        Me.btnNotas.Location = New System.Drawing.Point(7, 529)
        Me.btnNotas.Name = "btnNotas"
        Me.btnNotas.Size = New System.Drawing.Size(160, 30)
        Me.btnNotas.TabIndex = 108
        Me.btnNotas.Text = "&Observaciones"
        Me.btnNotas.ToolTipText = "Agregar una nota al documento"
        Me.btnNotas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbUsoCFDI
        '
        Me.cmbUsoCFDI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbUsoCFDI.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUsoCFDI.ItemHeight = 13
        Me.cmbUsoCFDI.Location = New System.Drawing.Point(316, 538)
        Me.cmbUsoCFDI.Name = "cmbUsoCFDI"
        Me.cmbUsoCFDI.Size = New System.Drawing.Size(223, 21)
        Me.cmbUsoCFDI.TabIndex = 105
        '
        'FrmFactura
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.btnNotas)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GrpSinAsignar)
        Me.Controls.Add(Me.cmbUsoCFDI)
        Me.Controls.Add(Me.GrpCliente)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
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
    Public ClienteInicial As String = ""

    Private Moneda As String
    Private MonedaRef As String
    Private MonedaDesc As String
    Private TipoCambio As Double

    Private FACClave, ClaveCaja As String
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

    Private Periodo As Integer
    Private Mes As Integer
    Private Prefijo As String


    Private dtPAC, dtAsignados, dtDetalle, dtConcepto, dtImpuesto, dtDetalleImpuesto, dtRetencionDet, dtRetencion As DataTable
    Private FacturaCreada As Boolean = False
    Private Grabado As Boolean = False

    Private idFactura As String

    Private PathXML As String
    Private InterfazSalida As String = ""

    Private PathPDF, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP As String
    Private MailPort As Integer
    Private MailSSL As Boolean
    Private FormatoFactura As String
    Private Nota As String = Nothing
    Private olineas As Integer = 0
    Private CreditoDisponible As Double
    Private bPedidoCredito As Boolean
    Private iTipoPAC As Integer = 0
    Private bload As Boolean = False
    Private iRegimenFiscal As Double




    Private Sub recalculaImpuestos(ByVal sFACClave As String, ByVal sDETClave As String, ByVal sPROClave As String, ByVal dPrecio As Double, ByVal iTImpuesto As Integer, ByVal sSUCClave As String)

        Dim PrecioImp As Decimal = dPrecio
        Dim ImpImporte As Decimal = 0
        Dim dtImpuesto As DataTable
        Dim i As Integer
        Dim Base As Decimal
        Dim PorcImp As Decimal = 0

        dtImpuesto = ModPOS.SiExisteRecupera("sp_venta_impuesto", "@PROClave", sPROClave, "@TImpuesto", iTImpuesto, "@SUCClave", sSUCClave)
        If Not dtImpuesto Is Nothing AndAlso Not dtImpuesto.Rows(0)("Valor") Is DBNull.Value Then
            For i = 0 To dtImpuesto.Rows.Count() - 1
                If dtImpuesto.Rows(i)("SobreImp") Then ' Si aplica sobre impuesto
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1  = Porcentaje
                        ImpImporte = PrecioImp * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                    Base = PrecioImp
                Else
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1 = Porcentaje
                        ImpImporte = dPrecio * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                    Base = dPrecio
                End If

                ModPOS.Ejecuta("sp_desglosa_impuestos", _
                           "@DFAClave", sDETClave, _
                           "@IMPClave", dtImpuesto.Rows(i)("IMPClave"), _
                           "@Base", Base, _
                           "@PorcImp", dtImpuesto.Rows(i)("Valor"), _
                           "@Importe", Math.Round(ImpImporte, 2), _
                           "@Usuario", ModPOS.UsuarioActual)

                PrecioImp += Math.Round(ImpImporte, 2)

            Next
            dtImpuesto.Dispose()

        End If

    End Sub

    Public Sub CargaDatosCliente(ByVal sCTEClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", sCTEClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            sCTEClave = dt.Rows(0)("CTEClave")
            oCFD.CTEClave = sCTEClave
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
            oCFD.ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))

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

            oCFD.UsoCFDI = IIf(dt.Rows(0)("UsoCFDI").GetType.Name = "DBNull", "G03", dt.Rows(0)("UsoCFDI"))

            dt.Dispose()


            cmbUsoCFDI.SelectedValue = oCFD.UsoCFDI

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
                FormatoFactura = dt.Rows(0)("FormatoFactura")
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
                    .TipoOrigen = IIf(dt.Rows(0)("TipoOrigen").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoOrigen"))
                    .RegFiscal = IIf(dt.Rows(0)("NumRegIdTrib").GetType.Name = "DBNull", "", dt.Rows(0)("NumRegIdTrib"))
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
                    .ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))

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

                    .DescuentoDirecto = IIf(dt.Rows(0)("DescuentoDirecto").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoDirecto"))
                    .DescuentoPostVenta = IIf(dt.Rows(0)("DescuentoPostVenta").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoPostVenta"))
                    .Vendedor = IIf(dt.Rows(0)("Vendedor").GetType.Name = "DBNull", "", dt.Rows(0)("Vendedor"))
                    .ClienteSAP = IIf(dt.Rows(0)("ClienteSAP").GetType.Name = "DBNull", "", dt.Rows(0)("ClienteSAP"))
                    .UsoCFDI = IIf(dt.Rows(0)("UsoCFDI").GetType.Name = "DBNull", "G03", dt.Rows(0)("UsoCFDI"))

                    dt.Dispose()

                End With
            End If

            ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Cliente.Show()
            ModPOS.Cliente.BringToFront()

        End If
    End Sub

    Public Sub CargaTickets(Optional ByVal FacturaId As String = "")

        If FacturaId = "" Then
            FacturaId = idFactura
        End If

        dtAsignados = ModPOS.Recupera_Tabla("sp_filtra_TicketsAsignados", "@FacturaId", FacturaId)
        Me.LstAsignados.DataSource = dtAsignados
        Me.LstAsignados.DisplayMember = dtAsignados.Columns(1).ColumnName
        Me.LstAsignados.ValueMember = dtAsignados.Columns(0).ColumnName
        Me.LstAsignados.ClearSelected()

        dtDetalle = ModPOS.Recupera_Tabla("sp_muestra_detallefactura", "@idFactura", FacturaId)
        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure()
        GridDetalle.RootTable.Columns("PREClave").Visible = False
        GridDetalle.RootTable.Columns("ZDGE").Visible = False
        GridDetalle.RootTable.Columns("PROClave").Visible = False
        GridDetalle.RootTable.Columns("TProducto").Visible = False
        GridDetalle.RootTable.Columns("Costo").Visible = False
        GridDetalle.RootTable.Columns("PorcImp").Visible = False
        GridDetalle.RootTable.Columns("PorcDesc").Visible = False
        GridDetalle.RootTable.Columns("PuntosImp").Visible = False
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("UndKilo").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Precio Unitario").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Subtotal").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Dscto").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Impuesto").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

        GridDetalle.RootTable.Columns("Cantidad").FormatString = "0.00"
        GridDetalle.RootTable.Columns("UndKilo").FormatString = "0.00"


        GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
        GridDetalle.RootTable.Columns("Subtotal").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Dscto").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Impuesto").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Total").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum


        GridDetalle.RootTable.Columns("Subtotal").TotalFormatString = "c"
        GridDetalle.RootTable.Columns("Dscto").TotalFormatString = "c"
        GridDetalle.RootTable.Columns("Impuesto").TotalFormatString = "c"
        GridDetalle.RootTable.Columns("Total").TotalFormatString = "c"




    End Sub


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

        If Not MtoCXC Is Nothing Then
            MtoCXC.AgregarFolio()
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
                    CargaDatosTicket(DateTime.Today.Year(), DateTime.Today.Month(), TxtTicket.Text.ToUpper.Trim.Replace("'", "''"), True)

                    TxtTicket.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
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
                .ClienteInicial = ClienteInicial
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

    'Private Sub BtnVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVendedor.Click
    '    Dim a As New MeSearch
    '    a.ProcedimientoAlmacenado = "sp_search_usuario"
    '    a.TablaCmb = "Usuario"
    '    a.CampoCmb = "Filtro"
    '    a.OcultaID = True
    '    a.CompaniaRequerido = False
    '    a.ShowDialog()
    '    If a.DialogResult = DialogResult.OK Then
    '        If Not a.valor Is Nothing Then
    '            Vendedor = a.valor
    '            TxtVendedor.Text = a.Descripcion
    '        End If
    '    End If
    '    a.Dispose()
    'End Sub

    Public Function CargaDatosTicket(ByVal Periodo As Integer, ByVal Mes As Integer, ByVal Folio As String, ByVal bCargaTickets As Boolean) As Boolean
        'Valida que el campo Ticket no se encuentre vacio
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_busca_ticket", "@Periodo", Periodo, "@Mes", Mes, "@Folio", Folio, "@SUCClave", SUCClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then


            If LstAsignados.Items.Count = 0 Then
                If dt.Rows(0)("Tipo") = 3 Then
                    bPedidoCredito = True
                Else
                    bPedidoCredito = False
                End If
                ChkCredito.Checked = bPedidoCredito

            ElseIf oCFD.CTEClave <> dt.Rows(0)("Cliente") Then
                MessageBox.Show("No es posible incluir ventas de diferentes clientes en una factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            Else
                Dim bCredito As Boolean = False
                If dt.Rows(0)("Tipo") = 3 Then
                    bCredito = True
                End If
                If bPedidoCredito <> bCredito Then
                    MessageBox.Show("No es posible incluir ventas de credito y de contado en una factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If
            End If



            VENClave = dt.Rows(0)("VENClave")
            If oCFD.CTEClave = "" Then
                CargaDatosCliente(dt.Rows(0)("Cliente"))
            End If
            Periodo = dt.Rows(0)("Periodo")
            Mes = dt.Rows(0)("Mes")
            SaldoVenta += dt.Rows(0)("Saldo")
            TotalFactura += dt.Rows(0)("Total")
            Vendedor = dt.Rows(0)("USRClave")
            TxtVendedor.Text = dt.Rows(0)("Vendedor")
            Nota = IIf(dt.Rows(0)("Nota").GetType.Name = "DBNull", "", dt.Rows(0)("Nota"))

            dt.Dispose()




            If Not FacturaCreada Then

                If bPedidoCredito = True Then
                    Dim dtVencimiento As DataTable = ModPOS.SiExisteRecupera("sp_calcula_vencimiento", "@Dias", oCFD.DiasCredito)
                    If Not dtVencimiento Is Nothing Then
                        Vencimiento = dtVencimiento.Rows(0)("Vencimiento")
                        dtVencimiento.Dispose()
                        TxtVence.Text = Vencimiento.ToShortDateString

                    End If
                End If

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


            End If

            ModPOS.Ejecuta("sp_agrega_tickfac", "@idFactura", idFactura, "@VENClave", VENClave)




            If oCFD.LCredito = 0 OrElse Math.Round(SaldoVenta, 2) < Math.Round(TotalFactura, 2) Then
                ChkCredito.Enabled = False
                ChkCredito.Checked = False
            Else
                ChkCredito.Enabled = True
            End If

            If bCargaTickets = True Then
                CargaTickets(idFactura)
            End If

            Return True
        Else
            MessageBox.Show("El folio introducido no esta disponible para facturar o el cliente no cuenta con datos fiscales para facturación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

    End Function

    Private Sub FrmFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt As DataTable

        oCFD = New CFD

        FACClave = ModPOS.obtenerLlave

        With cmbUsoCFDI
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_UsoCFDI"
            .NombreParametro1 = "Grupo"
            .Parametro1 = 1
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

        Dim dtmsg As DataTable

        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "LineasFac"
                        MaxRow = CInt(dtParam.Rows(i)("Valor"))
                 
                    Case "TipoCF"
                        oCFD.TipoCF = CInt(dtParam.Rows(i)("Valor"))
                    Case "VersionCF"

                        dtmsg = Recupera_Tabla("sp_recupera_valorref", "@Tabla", "CFD", "@Campo", "Version", "@estado", CInt(dtParam.Rows(i)("Valor")))
                        oCFD.VersionCF = dtmsg.Rows(0)("Descripcion")
                        dtmsg.Dispose()
                    Case "RegimenFiscal"
                        iRegimenFiscal = CInt(dtParam.Rows(i)("Valor"))

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

                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))

                End Select
            Next
        End With
        dtParam.Dispose()



        dtmsg = Recupera_Tabla("sp_recupera_valor", "@Tabla", "CFD", "@Campo", "RegimenFiscal", "@Valor", iRegimenFiscal)
        If oCFD.VersionCF = "3.3" Then
            oCFD.regimenFiscal = dtmsg.Rows(0)("ClaveSAT")
        Else
            oCFD.regimenFiscal = dtmsg.Rows(0)("Descripcion")
        End If
        dtmsg.Dispose()


        If oCFD.VersionCF = "3.3" Then
            oCFD.tipoDeComprobante = "I"
        Else
            oCFD.tipoDeComprobante = "ingreso"
        End If


        If oCFD.TipoCF = 2 Then
            dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)

            If dtPAC Is Nothing OrElse dtPAC.Rows.Count <= 0 Then
                MessageBox.Show("No se encontraron timbres disponibles, verifique la configuración de timbres en la Compañia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End If



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

        LstDomicilio.Items.Clear()
        TxtTicket.Focus()


        If Not Ventas Is Nothing AndAlso Ventas.GetLength(0) > 0 Then
            For i = 0 To Ventas.GetUpperBound(0)
                Me.CargaDatosTicket(CDate(Ventas(i)("Fecha")).Year, CDate(Ventas(i)("Fecha")).Month, Ventas(i)("Folio"), False)
            Next
            CargaTickets()
            TxtTicket.Focus()
        End If

        bload = True
    End Sub

    Private Function crearCF(ByVal FacturaID As String) As Boolean
        Dim i As Integer

        Dim dt As DataTable



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
            oCFD.Moneda = dt.Rows(i)("Moneda")
            oCFD.TipoCambio = dt.Rows(i)("TipoCambio")
            oCFD.total = dt.Rows(i)("Total")

            If oCFD.TipoCF = 1 OrElse oCFD.TipoCF = 2 Then

                oCFD.DOCClave = dt.Rows(i)("FACClave")

                If oCFD.VersionCF = "3.3" Then
                    dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_det", "@TipoComprobante", "I", "@Tipo", 1, "@Clave", oCFD.DOCClave)
                    dtRetencionDet = ModPOS.Recupera_Tabla("st_recupera_retencion_det", "@TipoComprobante", "I", "@Tipo", 1, "@Clave", oCFD.DOCClave)
                    dtRetencion = ModPOS.Recupera_Tabla("st_recupera_retenciones", "@TipoComprobante", "I", "@Tipo", 1, "@Clave", oCFD.DOCClave)

                End If

              

                If oCFD.TipoCF = 1 Then
                    oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
                Else
                    oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, 1, dtDetalleImpuesto, dtRetencionDet, dtRetencion)
                End If

                oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)


                iTipoPAC = crearXML(1, dtPAC, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, 1, InterfazSalida, dtDetalleImpuesto, dtRetencionDet, dtRetencion)

            Else
                actualizaEdoCFD(oCFD.tipoDeComprobante, oCFD.DOCClave, 1, 1)
            End If


            If oCFD.tieneAddenda = True Then
                If oCFD.Tipo = 1 Then

                    Dim NombreArchivo As String = oCFD.Serie & oCFD.Folio & ".xml"

                    Try
                        'Dim osvSoriana As New com.soriana.www.wseDocRecibo()
                        'osvSoriana.Url = oCFD.Firma
                        'osvSoriana.Timeout = 50000

                        Dim xmlDoc As New System.Xml.XmlDocument()
                        xmlDoc.Load(System.IO.Path.Combine(PathXML, NombreArchivo))

                        ' Now create StringWriter object to get data from xml document.
                        Dim sw As New System.IO.StringWriter()
                        Dim xw As New System.Xml.XmlTextWriter(sw)
                        xmlDoc.WriteTo(xw)

                        Dim res As String ' = osvSoriana.RecibeCFD(sw.ToString())

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
                                                  "@FACClave", dtFacturas.Rows(i)("ID"), _
                                                  "@Abono", dtFacturas.Rows(i)("Saldo"))

                    SaldoDisponible -= dtFacturas.Rows(i)("Saldo")

                Case Is < Redondear(dtFacturas.Rows(i)("Saldo"), 2)
                    ModPOS.Ejecuta("sp_actualiza_saldofac", _
                                   "@FACClave", dtFacturas.Rows(i)("ID"), _
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

    Private Sub recuperaDatosCredito(ByVal Cliente As String)
        Dim dt As DataTable

        dt = ModPOS.SiExisteRecupera("sp_recupera_credito", "@CTEClave", Cliente)

        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                CreditoDisponible = dt.Rows(0)("Disponible")
            Else
                CreditoDisponible = 0.0

            End If
            dt.Dispose()
        Else
            CreditoDisponible = 0.0
        End If
    End Sub


    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim dt As DataTable
        BtnGuardar.Enabled = False
        Dim impresora As String
        Dim NumCopias As Integer

        'Inicia Sección de Validaciones 
        If Not CmbCaja.SelectedValue Is Nothing Then
            CAJClave = CmbCaja.SelectedValue


            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            NumCopias = IIf(dt.Rows(0)("copiaCredito").GetType.Name = "DBNull", 0, dt.Rows(0)("copiaCredito"))
            impresora = dt.Rows(0)("ImpresoraFac")
            dt.Dispose()
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

        If cmbUsoCFDI.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar una opción de Uso del Comprobante", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnGuardar.Enabled = True
            Exit Sub
        End If

        If Not ChkCredito.Checked Then
            Vencimiento = #1/1/1900#
            oCFD.CondicionesDePago = "Contado"
        ElseIf bPedidoCredito = False Then
            Dim iValidaCredito As Integer
            Dim dTotal As Decimal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)


            iValidaCredito = ModPOS.ValidaCredido(oCFD.CTEClave, oCFD.LCredito, oCFD.DiasCredito, dTotal)

            If iValidaCredito = 0 Then
                Exit Sub
            ElseIf iValidaCredito = -1 Then
                recuperaDatosCredito(oCFD.CTEClave)
                If CreditoDisponible < CDbl(dTotal) Then
                    MessageBox.Show("No es posible realizar la factura debido a que el importe total del documento sobrepasa el crédito disponible del cliente " & Format(CStr(ModPOS.Redondear(CreditoDisponible, 2)), "Currency") & ", la venta actual lo sobrepasa por " & Format(CStr(ModPOS.Redondear(CDbl(dTotal) - CreditoDisponible, 2)), "Currency"), "Información", MessageBoxButtons.OK)
                    Exit Sub
                End If

                If oCFD.DiasCredito <= 0 Then
                    MessageBox.Show("El Cliente no cuenta con dias de credito definidos", "Información", MessageBoxButtons.OK)
                    Exit Sub
                End If

                Dim dtValida As DataTable
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

                Dim dtVencimiento As DataTable = ModPOS.SiExisteRecupera("sp_calcula_vencimiento", "@Dias", oCFD.DiasCredito)
                If Not dtVencimiento Is Nothing Then
                    Vencimiento = dtVencimiento.Rows(0)("Vencimiento")
                    dtVencimiento.Dispose()
                    TxtVence.Text = Vencimiento.ToShortDateString
                End If

                oCFD.CondicionesDePago = CStr(oCFD.DiasCredito) & " días"
            ElseIf iValidaCredito = 1 Then
                Dim dtVencimiento As DataTable = ModPOS.SiExisteRecupera("sp_calcula_vencimiento", "@Dias", oCFD.DiasCredito)
                If Not dtVencimiento Is Nothing Then
                    Vencimiento = dtVencimiento.Rows(0)("Vencimiento")
                    dtVencimiento.Dispose()
                    TxtVence.Text = Vencimiento.ToShortDateString
                End If
                oCFD.CondicionesDePago = CStr(oCFD.DiasCredito) & " días"
            End If
        ElseIf bPedidoCredito = True Then
            oCFD.CondicionesDePago = CStr(oCFD.DiasCredito) & " días"
        End If

        oCFD.UsoCFDI = cmbUsoCFDI.SelectedValue

        If oCFD.VersionCF = "3.3" Then
            If ChkCredito.GetEstado = 1 Then
                oCFD.formaDePago = "PPD"
                oCFD.metodoDePago = "99"
            Else
                oCFD.formaDePago = "PUE"
            End If
        Else
            oCFD.formaDePago = "Pago en una sola exhibición"
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


        NumFacturas = Int(dtDetalle.Rows.Count / MaxRow)

        If oCFD.tieneAddenda = True Then
            NumFacturas = 1
        ElseIf NumFacturas = 0 Then
            NumFacturas = 1
        ElseIf NumFacturas < (dtDetalle.Rows.Count / MaxRow) Then
            NumFacturas += 1
        End If



        If Not ModPOS.validaFolio(SUCClave, CAJClave, 1, NumFacturas) Then
            Exit Sub
        End If


        Dim fila As Integer
        Dim contador As Integer = 0


        If oCFD.tieneAddenda And oCFD.Tipo = 1 Then
            oCFD.CantBultos = dtDetalle.Compute("SUM(Cantidad)", "PROClave=PROClave")
            oCFD.CantPedidos = dtAsignados.Rows.Count
        End If

        Dim iPartida, iNumFacturas As Integer
        Dim FolioInicial, FolioFinal, sDFAClave As String

        iNumFacturas = NumFacturas


        'Recupera información del Emisor

        dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)

        oCFD.eRazonSocial = dt.Rows(0)("Nombre")
        oCFD.eTPersona = IIf(dt.Rows(0)("TPersona").GetType.Name = "DBNull", 2, dt.Rows(0)("TPersona"))
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


        For fila = 0 To dtDetalle.Rows.Count - 1

            If contador = MaxRow AndAlso oCFD.tieneAddenda = False Then

                ModPOS.recuperaFolio(SUCClave, CAJClave, 1, oCFD)

                FolioInicial = oCFD.Serie & oCFD.Folio

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
                "@Vendio", Vendedor, _
                "@Facturo", ModPOS.UsuarioActual, _
                "@Desglosar", oCFD.NoDesglosaIEPS, _
                "@formaDePago", oCFD.formaDePago, _
                "@MONClave", Moneda, _
                "@TipoCambio", TipoCambio, _
                "@Formato", FormatoFactura, _
                "@Nota", Nota,
                "@UsoCFDI", oCFD.UsoCFDI)


                FACClave = ModPOS.obtenerLlave
                NumFacturas -= 1

                ModPOS.Ejecuta("sp_crea_factura", _
                "@FACClave", FACClave, _
                "@idFactura", idFactura, _
                "@CAJClave", CmbCaja.SelectedValue, _
                "@tipo", oCFD.tipoDeComprobante, _
                "@Usuario", ModPOS.UsuarioActual)

                contador = 0
            End If

            iPartida = (contador + 1) * 10

            sDFAClave = ModPOS.obtenerLlave

            ModPOS.Ejecuta("sp_inserta_detallefactura", _
            "@DFAClave", sDFAClave, _
            "@FACClave", FACClave, _
            "@Partida", iPartida, _
            "@Producto", dtDetalle.Rows(fila)("PROClave"), _
            "@TProducto", dtDetalle.Rows(fila)("TProducto"), _
            "@Costo", dtDetalle.Rows(fila)("Costo"), _
            "@PrecioBruto", dtDetalle.Rows(fila)("Precio Unitario"), _
            "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
            "@Subtotal", dtDetalle.Rows(fila)("SubTotal"), _
            "@PorcDesc", dtDetalle.Rows(fila)("PorcDesc"), _
            "@DescuentoImp", dtDetalle.Rows(fila)("Dscto"), _
            "@PorcImp", dtDetalle.Rows(fila)("PorcImp"), _
            "@ImpuestoImp", dtDetalle.Rows(fila)("Impuesto"), _
            "@PuntosImp", dtDetalle.Rows(fila)("PuntosImp"), _
            "@ZDGE", dtDetalle.Rows(fila)("ZDGE"), _
            "@Und", dtDetalle.Rows(fila)("UndKilo"), _
            "@PREClave", dtDetalle.Rows(fila)("PREClave"), _
            "@Total", dtDetalle.Rows(fila)("Total"))


            ' recalculaImpuestos(FACClave, sDFAClave, dtDetalle.Rows(fila)("PROClave"), dtDetalle.Rows(fila)("Subtotal") - dtDetalle.Rows(fila)("Dscto"), oCFD.TImpuesto, SUCClave)

            If dtDetalle.Rows(fila)("TProducto") = 4 AndAlso oCFD.eTPersona = 1 AndAlso oCFD.TPersona = 2 Then
                'Calcula retencion
                ModPOS.calculaRetencion("F", sDFAClave, dtDetalle.Rows(fila)("PROClave"), dtDetalle.Rows(fila)("Subtotal") - dtDetalle.Rows(fila)("Dscto"), oCFD.TImpuesto, SUCClave)

            End If

            contador += 1
        Next
        dtDetalle.Dispose()


        ModPOS.recuperaFolio(SUCClave, CAJClave, 1, oCFD)

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
                        "@Vendio", Vendedor, _
                        "@Facturo", ModPOS.UsuarioActual, _
                        "@Desglosar", oCFD.NoDesglosaIEPS, _
                        "@formaDePago", oCFD.formaDePago, _
                        "@MONClave", Moneda, _
                        "@TipoCambio", TipoCambio, _
                        "@Formato", FormatoFactura, _
                        "@Nota", Nota,
                        "@UsoCFDI", oCFD.UsoCFDI)




        FolioFinal = oCFD.Serie & oCFD.Folio

        If iNumFacturas = 1 Then
            MessageBox.Show("Se genero la factura " & FolioFinal, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("Se generaron las facturas del " & FolioInicial & " al " & FolioFinal, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Grabado = True

        dtDetalle.Dispose()

        Dim dtAbonos As DataTable
        Dim i As Integer

        dtAbonos = ModPOS.Recupera_Tabla("sp_obtiene_saldofac", "@idFactura", idFactura)

        ModPOS.Ejecuta("sp_cambia_ticketfactura", "@idFactura", idFactura, "@CTEClave", oCFD.CTEClave)

        If dtAbonos.Rows.Count > 0 Then
            For i = 0 To dtAbonos.Rows.Count - 1
                If CDbl(dtAbonos.Rows(i)("Abonos")) > 0 Then
                    Me.Aplica_Pagos_Tickets(idFactura, CDbl(dtAbonos.Rows(i)("Abonos")), oCFD.CTEClave)
                End If
            Next
        End If

        dtAbonos.Dispose()


        Dim dtFacturas As DataTable
        dtFacturas = ModPOS.Recupera_Tabla("sp_recupera_factura", "@FacturaID", idFactura)

        SaldoFactura = IIf(dtFacturas.Compute("Sum(Saldo)", "Saldo > 0") Is System.DBNull.Value, 0, dtFacturas.Compute("Sum(Saldo)", "Saldo > 0"))

       

        If ChkCredito.GetEstado = 0 AndAlso CajaActiva = True AndAlso SaldoFactura > 0 Then

            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            ClaveCaja = dt.Rows(0)("Clave")
            dt.Dispose()

            If Not ModPOS.MtoCXC Is Nothing Then

                Dim dtAbnSaldo As DataTable
              
                dtAbnSaldo = Recupera_Tabla("sp_aplicar_abn", "@CTEClave", oCFD.CTEClave)
                If dtAbnSaldo.Rows.Count > 0 Then


                    Dim b As New FrmAbnPendiente
                    b.Abonos = dtAbnSaldo

                    b.SaldoDocumento = SaldoFactura
                    b.ShowDialog()

                    If b.DialogResult = DialogResult.OK Then
                        If Not b.drAbonos Is Nothing AndAlso b.drAbonos.Length > 0 Then
                            For i = 0 To b.drAbonos.Length - 1
                                Dim bTieneSello As Boolean = False

                                'Si es un Anticipo y la fecha del anticipo es del mismo dia de la factura 
                                If b.drAbonos(i)("Tipo") = 2 AndAlso DateDiff(DateInterval.Day, CDate(b.drAbonos(i)("Fecha")), CDate(dtFacturas.Rows(0)("fechaFactura"))) = 0 Then


                                    Dim dtSello As DataTable = ModPOS.Recupera_Tabla("st_sello_pago", "@ABNClave", b.drAbonos(i)("ID"))
                                    If dtSello.Rows.Count > 0 Then
                                        If CInt(dtSello.Rows(0)("estado")) = 1 Then
                                            bTieneSello = True
                                        End If
                                    End If
                                    dtSello.Dispose()

                                    If bTieneSello = False Then

                                        Dim ImportePago, ImporteAnticipo As Double
                                        Dim FolioAbono As String

                                        If b.drAbonos(i)("Saldo") > SaldoFactura Then

                                            'Crear anticipo de la diferencia
                                            Dim Folio, Periodo, Mes As Integer
                                            Dim dtFolio As DataTable
                                            dtFolio = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 6, "@PDVClave", CAJClave)
                                            If dtFolio Is Nothing Then
                                                ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 6, "@PDVClave", CAJClave)
                                                Folio = 1
                                                Periodo = Today.Year
                                                Mes = Today.Month
                                            Else
                                                Folio = CInt(dtFolio.Rows(0)("UltimoConsecutivo")) + 1
                                                Periodo = dtFolio.Rows(0)("Periodo")
                                                Mes = dtFolio.Rows(0)("Mes")
                                                ModPOS.Ejecuta("sp_act_folio", "@Tipo", 6, "@PDVClave", CAJClave, "@Incremento", 1)
                                                dtFolio.Dispose()
                                            End If

                                            ImportePago = SaldoFactura
                                            ImporteAnticipo = b.drAbonos(i)("Saldo") - SaldoFactura
                                            FolioAbono = "AB" & ClaveCaja & "-" & CStr(Folio) & "-" & CStr(Periodo) & CStr(Mes)


                                            'Combierte anticipo en Pago

                                            ModPOS.Ejecuta("st_convierte_anticipo", _
                                                          "@ABNClave", b.drAbonos(i)("ID"), _
                                                          "@Folio", FolioAbono, _
                                                          "@CAJClave", CAJClave, _
                                                          "@ImportePago", Math.Round(ImportePago, 2), _
                                                          "@ImporteAnticipo", Math.Round(ImporteAnticipo, 2), _
                                                          "@Usuario", ModPOS.UsuarioActual)
                                        Else
                                            ImportePago = b.drAbonos(i)("Saldo")
                                        End If



                                        ModPOS.Aplica_Pagos(dtFacturas, oCFD.CTEClave, b.drAbonos(i)("ID"), b.drAbonos(i)("TipoPago"), ImportePago, CAJClave, 1)
                                    Else
                                        ModPOS.Aplica_Pagos(dtFacturas, oCFD.CTEClave, b.drAbonos(i)("ID"), b.drAbonos(i)("TipoPago"), b.drAbonos(i)("Saldo"), CAJClave, b.drAbonos(i)("Tipo"))

                                    End If
                                Else
                                    ModPOS.Aplica_Pagos(dtFacturas, oCFD.CTEClave, b.drAbonos(i)("ID"), b.drAbonos(i)("TipoPago"), b.drAbonos(i)("Saldo"), CAJClave, b.drAbonos(i)("Tipo"))

                                End If

                                    If b.drAbonos(i)("Tipo") = 2 AndAlso ( DateDiff(DateInterval.Day, CDate(b.drAbonos(i)("Fecha")), CDate(dtFacturas.Rows(0)("fechaFactura"))) > 0 orelse btienesello = True ) Then
                                        oCFD.AplicaAnticipo = True
                                    End If
                            Next
                        End If
                    End If

                End If
                dtAbnSaldo.Dispose()

                SaldoFactura = IIf(dtFacturas.Compute("Sum(Saldo)", "Saldo > 0") Is System.DBNull.Value, 0, dtFacturas.Compute("Sum(Saldo)", "Saldo > 0"))


                Dim iTPago As Integer
                Dim dTotalCambio, dTotalAbono As Double

                If SaldoFactura > 0 Then



                    Do
                        Dim a As New FrmAbono
                        a.InterfazSalida = InterfazSalida
                        a.VariosPagos = IIf(iNumFacturas = 1, False, True)
                        a.TipoDocumento = 2
                        a.CAJA = CAJClave
                        a.ClaveCaja = ClaveCaja
                        a.ClaveCte = oCFD.CTEClave
                        a.ClaveDocumento = FACClave
                        a.SaldoAcumulado = ModPOS.TruncateToDecimal(SaldoFactura, 2)
                        a.AperturaCajon = Cajon
                        a.ImpresoraCajon = ImpresoraCajon
                        a.ShowDialog()

                        If a.DialogResult = DialogResult.OK Then
                            If a.detallePago.Rows.Count > 0 Then

                                For i = 0 To a.detallePago.Rows.Count - 1
                                    ModPOS.Aplica_Pagos(dtFacturas, oCFD.CTEClave, a.detallePago.Rows(i)("ABNClave"), a.detallePago.Rows(i)("TipoPago"), a.detallePago.Rows(i)("Saldo"), CAJClave, 1)
                                Next

                                iTPago = a.detallePago.Rows(i - 1)("TipoPago")
                                dTotalCambio = a.TotalCambio
                                dTotalAbono = a.TotalAbono

                            End If

                            SaldoFactura -= dTotalAbono - Math.Round(dTotalCambio, 2)

                        End If



                    Loop While TruncateToDecimal(SaldoFactura, 2) > 0

                    If dTotalAbono > 0 Then
                        Dim msg As New FrmMeMsg
                        If iTPago = 1 Then
                            msg.TxtTiulo = "Su Cambio es:"
                        Else
                            msg.TxtTiulo = "Su Saldo a favor es:"
                        End If
                        msg.TxtMsg = Format(CStr(Math.Round(dTotalCambio, 2)), "Currency")
                        msg.TxtMsg2 = Letras(CStr(Math.Round(dTotalCambio, 2))).ToUpper
                        msg.ShowDialog()
                        msg.Dispose()

                        If Not ModPOS.MtoCXC Is Nothing Then
                            ModPOS.MtoCXC.RetiroProgramado()
                        End If

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


        If oCFD.VersionCF = "3.3" AndAlso ChkCredito.GetEstado = 1 Then
            ModPOS.Ejecuta("sp_agregar_metodopagofac", _
             "@FacturaID", idFactura, _
             "@MetodoPago", 0, _
             "@Banco", "", _
             "@Referencia", "", _
             "@SAT", "99")
        Else

            Dim Referencia As String
            Dim Banco As String
            Dim Tipo As String
            Dim SAT As String

            oCFD.metodoDePago = ""
            oCFD.NumCtaPago = ""

            Dim dtMetodosPago As DataTable
            Dim bMetodoCte As Boolean = False

            If ModPOS.TruncateToDecimal(SaldoFactura, 1) > 0 Then
                dtMetodosPago = ModPOS.Recupera_Tabla("sp_recupera_metodospago_cte", "@CTEClave", oCFD.CTEClave)
                bMetodoCte = True
            Else
                dtMetodosPago = ModPOS.Recupera_Tabla("st_recupera_metodospago_fac", "@FacturaId", idFactura)
            End If

            If dtMetodosPago.Rows.Count = 0 OrElse (dtMetodosPago.Rows.Count > 1 AndAlso bMetodoCte = True) Then
                Dim bMetodoPago As Boolean = False
                Do
                    If ModPOS.MetodoPago Is Nothing Then
                        ModPOS.MetodoPago = New FrmMetodoPago
                        With ModPOS.MetodoPago
                            .CTEClave = oCFD.CTEClave
                            .FacturaId = idFactura
                            .VersionCF = oCFD.VersionCF
                        End With
                    End If

                    ModPOS.MetodoPago.StartPosition = FormStartPosition.CenterScreen

                    If ModPOS.MetodoPago.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If ModPOS.MetodoPago.MetodoDePago <> "" Then
                            oCFD.metodoDePago = ModPOS.MetodoPago.MetodoDePago
                            oCFD.NumCtaPago = ModPOS.MetodoPago.NumCtaPago
                            bMetodoPago = True
                        Else
                            MessageBox.Show("Ha ocurrido un error al recuperar los metodos de pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            bMetodoPago = False
                        End If
                    Else
                        MessageBox.Show("Debe seleccionar una opcion valida de Metodo de Pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bMetodoPago = False
                    End If

                    ModPOS.MetodoPago.Dispose()
                    ModPOS.MetodoPago = Nothing
                Loop While bMetodoPago = False
            Else
                'falta agregar un ciclo for donde inserte cada uno de los metodos de pago encontrados.
                For i = 0 To dtMetodosPago.Rows.Count - 1

                    Referencia = IIf(dtMetodosPago.Rows(i)("Referencia").GetType.Name <> "DBNull", CStr(dtMetodosPago.Rows(i)("Referencia")).Trim.ToUpper, "")
                    Banco = IIf(dtMetodosPago.Rows(i)("Banco").GetType.Name <> "DBNull", dtMetodosPago.Rows(i)("Banco"), "")
                    Tipo = IIf(dtMetodosPago.Rows(i)("Tipo").GetType.Name <> "DBNull", dtMetodosPago.Rows(i)("Tipo"), "")
                    SAT = IIf(dtMetodosPago.Rows(i)("SAT").GetType.Name <> "DBNull", dtMetodosPago.Rows(i)("SAT"), "99")


                    ModPOS.Ejecuta("sp_agregar_metodopagofac", _
                           "@FacturaID", idFactura, _
                           "@MetodoPago", Tipo, _
                           "@Banco", Banco, _
                           "@Referencia", Referencia, _
                           "@SAT", SAT)

                    If oCFD.VersionCF <> "3.3" Then
                        If SAT <> "" Then
                            If oCFD.metodoDePago = "" Then
                                oCFD.metodoDePago = SAT
                            Else
                                oCFD.metodoDePago &= "," & SAT
                            End If
                        End If

                        If Referencia <> "" Then
                            If oCFD.NumCtaPago = "" Then
                                oCFD.NumCtaPago = Referencia
                            Else
                                oCFD.NumCtaPago &= "," & Referencia
                            End If
                        End If
                    ElseIf oCFD.metodoDePago = "" And SAT <> "" Then
                        oCFD.metodoDePago = SAT
                        If Referencia <> "" AndAlso oCFD.NumCtaPago = "" Then
                            oCFD.NumCtaPago = Referencia
                        End If
                        Exit For
                    End If
                Next

            End If

            dtMetodosPago.Dispose()

        End If

        crearCF(idFactura)

        'Inicia
        If oCFD.TipoCF = 2 AndAlso iTipoPAC = 0 Then
            MessageBox.Show("No ha sido posible certificar este documento, le recomendamos intentar certificarlo más tarde", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()
            BtnGuardar.Enabled = True
            Exit Sub
        End If

        If oCFD.ImprimirFac = True Then
            Select Case MessageBox.Show("¿Desea imprimir las facturas?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes

                    Dim sImpresora As String
                    Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", impresora)
                    sImpresora = dtPrinter.Rows(0)("Referencia")
                    dtPrinter.Dispose()

                    ModPOS.imprimirFacturas(oCFD.TipoCF, idFactura, SUCClave, TipoCambio, MonedaDesc, MonedaRef, sImpresora, IIf(ChkCredito.GetEstado = 1, NumCopias + 1, 1), oCFD.VersionCF)

            End Select
        End If

        If oCFD.email.Trim <> "" Then
            Select Case MessageBox.Show("¿Desea enviar el documento por correo electrónico?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes

                    Dim dtFactura As DataTable = ModPOS.Recupera_Tabla("sp_lista_facturas", "@FacturaId", idFactura)
                    Dim j As Integer
                    For j = 0 To dtFactura.Rows.Count - 1

                        ModPOS.SendMail(oCFD.VersionCF, oCFD.email, oCFD.TipoCF, dtFactura.Rows(j)("Formato"), CDate(dtFactura.Rows(j)("Fecha")), dtFactura.Rows(j)("Folio"), dtFactura.Rows(j)("FACClave"), dtFactura.Rows(j)("Total"), MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonedaDesc, MonedaRef)
                    Next
                    dtFactura.Dispose()
            End Select
        End If




        Me.Close()
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
