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

Public Class FrmNC
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
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LstDomicilio As System.Windows.Forms.ListBox
    Friend WithEvents TxtRFC As System.Windows.Forms.TextBox
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtIVA As System.Windows.Forms.TextBox
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents LblIVA As System.Windows.Forms.Label
    Friend WithEvents LblSubtotal As System.Windows.Forms.Label
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents TxtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents TxtTicket As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscaFactura As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbMotivo As Selling.StoreCombo
    Friend WithEvents TxtDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbFormaPago As Selling.StoreCombo
    Friend WithEvents TxtTotalFac As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtDisponible As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbCaja As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNC))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox
        Me.TxtTotalFac = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtDisponible = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbMotivo = New Selling.StoreCombo
        Me.CmbTipo = New Selling.StoreCombo
        Me.TxtTicket = New System.Windows.Forms.TextBox
        Me.BtnBuscaFactura = New Janus.Windows.EditControls.UIButton
        Me.Label12 = New System.Windows.Forms.Label
        Me.CmbCaja = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.TxtVendedor = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpDetalle = New System.Windows.Forms.GroupBox
        Me.TxtDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.GrpCliente = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtFolio = New System.Windows.Forms.TextBox
        Me.TxtRFC = New System.Windows.Forms.TextBox
        Me.LstDomicilio = New System.Windows.Forms.ListBox
        Me.lblRFC = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.TxtSubtotal = New System.Windows.Forms.TextBox
        Me.TxtIVA = New System.Windows.Forms.TextBox
        Me.LblTotal = New System.Windows.Forms.Label
        Me.LblIVA = New System.Windows.Forms.Label
        Me.LblSubtotal = New System.Windows.Forms.Label
        Me.TxtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.CmbFormaPago = New Selling.StoreCombo
        Me.GrpGeneral.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Controls.Add(Me.TxtTotalFac)
        Me.GrpGeneral.Controls.Add(Me.Label13)
        Me.GrpGeneral.Controls.Add(Me.TxtDisponible)
        Me.GrpGeneral.Controls.Add(Me.Label10)
        Me.GrpGeneral.Controls.Add(Me.Label6)
        Me.GrpGeneral.Controls.Add(Me.Label3)
        Me.GrpGeneral.Controls.Add(Me.CmbMotivo)
        Me.GrpGeneral.Controls.Add(Me.CmbTipo)
        Me.GrpGeneral.Controls.Add(Me.TxtTicket)
        Me.GrpGeneral.Controls.Add(Me.BtnBuscaFactura)
        Me.GrpGeneral.Controls.Add(Me.Label12)
        Me.GrpGeneral.Controls.Add(Me.CmbCaja)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Controls.Add(Me.ChkEstado)
        Me.GrpGeneral.Controls.Add(Me.TxtVendedor)
        Me.GrpGeneral.Controls.Add(Me.LblNombre)
        Me.GrpGeneral.Location = New System.Drawing.Point(7, 7)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(300, 210)
        Me.GrpGeneral.TabIndex = 1
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos Generales"
        '
        'TxtTotalFac
        '
        Me.TxtTotalFac.Enabled = False
        Me.TxtTotalFac.Location = New System.Drawing.Point(60, 97)
        Me.TxtTotalFac.Name = "TxtTotalFac"
        Me.TxtTotalFac.ReadOnly = True
        Me.TxtTotalFac.Size = New System.Drawing.Size(73, 20)
        Me.TxtTotalFac.TabIndex = 112
        Me.TxtTotalFac.Text = "0.00"
        Me.TxtTotalFac.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtTotalFac.Value = 0
        Me.TxtTotalFac.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(6, 99)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 15)
        Me.Label13.TabIndex = 113
        Me.Label13.Text = "Total Fac."
        '
        'TxtDisponible
        '
        Me.TxtDisponible.Enabled = False
        Me.TxtDisponible.Location = New System.Drawing.Point(217, 96)
        Me.TxtDisponible.Name = "TxtDisponible"
        Me.TxtDisponible.ReadOnly = True
        Me.TxtDisponible.Size = New System.Drawing.Size(74, 20)
        Me.TxtDisponible.TabIndex = 110
        Me.TxtDisponible.Text = "0.00"
        Me.TxtDisponible.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDisponible.Value = 0
        Me.TxtDisponible.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(138, 98)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 19)
        Me.Label10.TabIndex = 111
        Me.Label10.Text = "Imp. Disponible"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(7, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Motivo"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 15)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Tipo"
        '
        'CmbMotivo
        '
        Me.CmbMotivo.Location = New System.Drawing.Point(60, 151)
        Me.CmbMotivo.Name = "CmbMotivo"
        Me.CmbMotivo.Size = New System.Drawing.Size(233, 21)
        Me.CmbMotivo.TabIndex = 4
        '
        'CmbTipo
        '
        Me.CmbTipo.Location = New System.Drawing.Point(60, 122)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(233, 21)
        Me.CmbTipo.TabIndex = 3
        '
        'TxtTicket
        '
        Me.TxtTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTicket.Location = New System.Drawing.Point(60, 44)
        Me.TxtTicket.Name = "TxtTicket"
        Me.TxtTicket.Size = New System.Drawing.Size(192, 21)
        Me.TxtTicket.TabIndex = 1
        '
        'BtnBuscaFactura
        '
        Me.BtnBuscaFactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaFactura.Image = CType(resources.GetObject("BtnBuscaFactura.Image"), System.Drawing.Image)
        Me.BtnBuscaFactura.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaFactura.Location = New System.Drawing.Point(257, 43)
        Me.BtnBuscaFactura.Name = "BtnBuscaFactura"
        Me.BtnBuscaFactura.Size = New System.Drawing.Size(36, 22)
        Me.BtnBuscaFactura.TabIndex = 2
        Me.BtnBuscaFactura.ToolTipText = "Busqueda de Factura"
        Me.BtnBuscaFactura.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(7, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 15)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Caja"
        '
        'CmbCaja
        '
        Me.CmbCaja.Location = New System.Drawing.Point(60, 18)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(233, 21)
        Me.CmbCaja.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Factura"
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(513, 7)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(47, 23)
        Me.ChkEstado.TabIndex = 0
        Me.ChkEstado.Text = "Activo"
        '
        'TxtVendedor
        '
        Me.TxtVendedor.Enabled = False
        Me.TxtVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendedor.Location = New System.Drawing.Point(60, 70)
        Me.TxtVendedor.Multiline = True
        Me.TxtVendedor.Name = "TxtVendedor"
        Me.TxtVendedor.ReadOnly = True
        Me.TxtVendedor.Size = New System.Drawing.Size(233, 19)
        Me.TxtVendedor.TabIndex = 3
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(7, 72)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(46, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Atiende"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(599, 539)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 30)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 539)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 30)
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
        Me.GrpDetalle.Controls.Add(Me.TxtDescuento)
        Me.GrpDetalle.Controls.Add(Me.Label5)
        Me.GrpDetalle.Controls.Add(Me.Label4)
        Me.GrpDetalle.Controls.Add(Me.TxtDescripcion)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(7, 223)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(778, 280)
        Me.GrpDetalle.TabIndex = 3
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'TxtDescuento
        '
        Me.TxtDescuento.Enabled = False
        Me.TxtDescuento.Location = New System.Drawing.Point(75, 18)
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.ReadOnly = True
        Me.TxtDescuento.Size = New System.Drawing.Size(73, 20)
        Me.TxtDescuento.TabIndex = 0
        Me.TxtDescuento.Text = "0.00"
        Me.TxtDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDescuento.Value = 0
        Me.TxtDescuento.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "Porc. Desc."
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(153, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 15)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "Descripción"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Enabled = False
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(221, 18)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(551, 19)
        Me.TxtDescripcion.TabIndex = 1
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(7, 43)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(765, 230)
        Me.GridDetalle.TabIndex = 2
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpCliente
        '
        Me.GrpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCliente.Controls.Add(Me.Label7)
        Me.GrpCliente.Controls.Add(Me.TxtFolio)
        Me.GrpCliente.Controls.Add(Me.TxtRFC)
        Me.GrpCliente.Controls.Add(Me.LstDomicilio)
        Me.GrpCliente.Controls.Add(Me.lblRFC)
        Me.GrpCliente.Controls.Add(Me.Label11)
        Me.GrpCliente.Controls.Add(Me.TxtRazonSocial)
        Me.GrpCliente.Controls.Add(Me.Label2)
        Me.GrpCliente.Controls.Add(Me.TxtClave)
        Me.GrpCliente.Location = New System.Drawing.Point(313, 7)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(472, 210)
        Me.GrpCliente.TabIndex = 2
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "Datos Cliente"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(185, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 15)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "FOL."
        '
        'TxtFolio
        '
        Me.TxtFolio.Enabled = False
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(217, 15)
        Me.TxtFolio.Multiline = True
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.ReadOnly = True
        Me.TxtFolio.Size = New System.Drawing.Size(116, 19)
        Me.TxtFolio.TabIndex = 94
        '
        'TxtRFC
        '
        Me.TxtRFC.Enabled = False
        Me.TxtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRFC.Location = New System.Drawing.Point(67, 89)
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.ReadOnly = True
        Me.TxtRFC.Size = New System.Drawing.Size(160, 21)
        Me.TxtRFC.TabIndex = 93
        '
        'LstDomicilio
        '
        Me.LstDomicilio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LstDomicilio.Enabled = False
        Me.LstDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstDomicilio.ItemHeight = 15
        Me.LstDomicilio.Location = New System.Drawing.Point(7, 115)
        Me.LstDomicilio.Name = "LstDomicilio"
        Me.LstDomicilio.Size = New System.Drawing.Size(458, 64)
        Me.LstDomicilio.TabIndex = 92
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(3, 89)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(34, 15)
        Me.lblRFC.TabIndex = 91
        Me.lblRFC.Text = "RFC"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(3, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 37)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Razón Social"
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(67, 45)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(398, 37)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Enabled = False
        Me.TxtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave.Location = New System.Drawing.Point(67, 15)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.ReadOnly = True
        Me.TxtClave.Size = New System.Drawing.Size(113, 21)
        Me.TxtClave.TabIndex = 3
        '
        'TxtSubtotal
        '
        Me.TxtSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSubtotal.Enabled = False
        Me.TxtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubtotal.Location = New System.Drawing.Point(325, 509)
        Me.TxtSubtotal.Name = "TxtSubtotal"
        Me.TxtSubtotal.ReadOnly = True
        Me.TxtSubtotal.Size = New System.Drawing.Size(114, 26)
        Me.TxtSubtotal.TabIndex = 4
        Me.TxtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtIVA
        '
        Me.TxtIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIVA.Enabled = False
        Me.TxtIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIVA.Location = New System.Drawing.Point(492, 507)
        Me.TxtIVA.Name = "TxtIVA"
        Me.TxtIVA.ReadOnly = True
        Me.TxtIVA.Size = New System.Drawing.Size(113, 26)
        Me.TxtIVA.TabIndex = 16
        Me.TxtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Location = New System.Drawing.Point(612, 516)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(28, 15)
        Me.LblTotal.TabIndex = 90
        Me.LblTotal.Text = "Total"
        '
        'LblIVA
        '
        Me.LblIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblIVA.Location = New System.Drawing.Point(442, 516)
        Me.LblIVA.Name = "LblIVA"
        Me.LblIVA.Size = New System.Drawing.Size(53, 17)
        Me.LblIVA.TabIndex = 91
        Me.LblIVA.Text = "Impuesto"
        '
        'LblSubtotal
        '
        Me.LblSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSubtotal.Location = New System.Drawing.Point(279, 516)
        Me.LblSubtotal.Name = "LblSubtotal"
        Me.LblSubtotal.Size = New System.Drawing.Size(46, 15)
        Me.LblSubtotal.TabIndex = 92
        Me.LblSubtotal.Text = "Subtotal"
        '
        'TxtTotal
        '
        Me.TxtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(645, 507)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(140, 26)
        Me.TxtTotal.TabIndex = 4
        Me.TxtTotal.Text = "0.00"
        Me.TxtTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtTotal.Value = 0
        Me.TxtTotal.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(14, 190)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 15)
        Me.Label9.TabIndex = 111
        Me.Label9.Text = "Forma de Pago"
        '
        'CmbFormaPago
        '
        Me.CmbFormaPago.BackColor = System.Drawing.SystemColors.Window
        Me.CmbFormaPago.ItemHeight = 13
        Me.CmbFormaPago.Location = New System.Drawing.Point(95, 188)
        Me.CmbFormaPago.Name = "CmbFormaPago"
        Me.CmbFormaPago.Size = New System.Drawing.Size(205, 21)
        Me.CmbFormaPago.TabIndex = 109
        '
        'FrmNC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.TxtIVA)
        Me.Controls.Add(Me.CmbFormaPago)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.LblSubtotal)
        Me.Controls.Add(Me.LblIVA)
        Me.Controls.Add(Me.TxtSubtotal)
        Me.Controls.Add(Me.GrpCliente)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.LblTotal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmNC"
        Me.Text = "Nota de Crédito"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Public bLiquidacion As Boolean = False
    Public Facturas() As DataRow

    Public ALMClave As String
    Public SUCClave As String
    Public CAJClave As String

    Public Cajon As Boolean = False
    Public PrinterName As String = ""

    Private Autoriza As String
    Private Moneda As String
    Private MonedaRef As String
    Private MonedaDesc As String
    Private TipoCambio As Double

    Private NCClave As String
    Private hacerBonificacion As Boolean = False

    Private FACClave As String

    Private oCFD As CFD

    Private FOLClave As String
    'Private Serie As String
    'Private Folio As String
    Private MaxRow As Integer

    Private Periodo As Integer
    Private Mes As Integer
    Private Impresora As String

    Private CajaLoad As Boolean = False
    Private dtPAC, dt, dtDetalle, dtImpuestodet As DataTable

    Private dtConcepto, dtImpuesto As DataTable

    Private PathPDF, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP As String
    Private MailPort As Integer
    Private MailSSL As Boolean

    Private PathXML As String

    Private disponible As Double

    Private TotalFactura As Double
    Private SubtotalFactura As Double
    Private ImpuestoFactura As Double

    Private CostoTotal As Double
    Private TotalNC As Double
    Private SubtotalNC As Double
    Private IVANC As Double
    Private DescTotal As Double
    Private PorcDesc As Double
    Private SaldoFactura As Double
    'Private Vencimiento As DateTime
    'Private Credito As Integer


    Private correo As MailMessage
    Private adjuntos As Attachment
    Private autenticar As NetworkCredential
    Private envio As SmtpClient
    Private dato As FileStream
    Private sFolio As String

    Private iTipoPAC As Integer = 0

    'Comprobante

    'Private LlaveFile As String
    'Private ContrasenaClave As String
    'Private noAprobacion As String
    'Private anoAprobacion As String

    'Private TipoCF As Integer
    'Private VersionCF As String
    'Private regimenFiscal As String
    'Private noCertificado As String
    'Private Certificado64 As String


    'Private tipoDeComprobante As String = "egreso"
    'Private formaDePago As String
    'Private metodoDePago As String
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
    'Private SaldoCliente As Double

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
    ''Private sPais As String
    ''Private sEntidad As String
    ''Private sMnpio As String
    ''Private sCalle As String
    ''Private sColonia As String
    ''Private sLocalidad As String
    ''Private sReferencia As String
    ''Private snoExterior As String
    ''Private snoInterior As String
    ''Private sCodigoPostal As String
    ''Private iTipoSucursal As Integer
    ''Private bsnoInterior As Boolean

    ''Private LugarExpedicion As String


    Private Sub SendMail()
        Dim sMailCliente As String = ""
        Dim sPathXML As String = ""

        sMailCliente = oCFD.email

        If MailAdress = "" OrElse MailUser = "" OrElse MailPassword = "" OrElse HostSMTP = "" OrElse MailPort = 0 Then
            MessageBox.Show("No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Verifica que exista el path
        If oCFD.TipoCF <= 2 Then
            Try
                If Not System.IO.Directory.Exists(PathXML) Then
                    MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            If PathXML.Length <= 3 Then
                sPathXML = PathXML & sFolio & ".xml"
            Else
                sPathXML = PathXML & "\" & sFolio & ".xml"
            End If

            If Not System.IO.File.Exists(sPathXML) Then
                MessageBox.Show("No fue posible encontrar el archivo: " & PathXML, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        End If

        PathPDF = pathActual & "Temp\" & sFolio & ".PDF"

        'Genera PDF


        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"

        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", NCClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_detalle", "@NCClave", NCClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", NCClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_referencia_factura", "@NCClave", NCClave))

        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_nc", "@NCClave", NCClave))

        If oCFD.TipoCF = 1 Then
            OpenReport.PrintPDF("CREgresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(TotalNC / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
        ElseIf oCFD.TipoCF = 2 Then
            OpenReport.PrintPDF("CREgresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(TotalNC / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
        ElseIf oCFD.TipoCF = 3 Then
            OpenReport.PrintPDF("CREgresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(TotalNC / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
        End If

        If Not System.IO.File.Exists(PathPDF) Then
            MessageBox.Show("Ha ocurrido un error al generar el archivo: " & PathPDF, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Envia Correo

        Dim frmStatusMessage As New frmStatus
        Try
            correo = New MailMessage
            autenticar = New NetworkCredential
            envio = New SmtpClient

            If oCFD.TipoCF <= 2 Then
                correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Nota de Crédito (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agraciadecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
            ElseIf oCFD.TipoCF = 3 Then
                correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Nota de Crédito (*.PDF), Agraciadecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
            End If

            correo.Subject = "Nota de Crédito " & sFolio
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

            If oCFD.TipoCF <= 2 Then
                dato = New FileStream(sPathXML, FileMode.Open, FileAccess.Read)
                adjuntos = New Attachment(dato, sFolio & ".XML")
                correo.Attachments.Add(adjuntos)
            End If

            dato = New FileStream(PathPDF, FileMode.Open, FileAccess.Read)
            adjuntos = New Attachment(dato, sFolio & ".PDF")
            correo.Attachments.Add(adjuntos)


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

    Public Sub CreaBonificacion()

        If Not TxtDescuento.Text = 0 Then
            PorcDesc = CDbl(TxtDescuento.Text) / 100
            TotalNC = TotalFactura * PorcDesc
            SubtotalNC = SubtotalFactura * PorcDesc
            IVANC = ImpuestoFactura * PorcDesc
            Me.TxtTotal.Text = CStr(Redondear(TotalNC, 2))
            Me.TxtIVA.Text = CStr(Redondear(IVANC, 2))
            Me.TxtSubtotal.Text = CStr(Redondear(SubtotalNC, 2))
        Else
            CostoTotal = 0
            TotalNC = 0
            IVANC = 0
            SubtotalNC = 0
            PorcDesc = 0
            TxtDescuento.Text = 0
            TxtTotal.Text = 0
            TxtIVA.Text = "0"
            TxtSubtotal.Text = "0"
        End If
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

    Private Function recuperaFolio(ByVal Caja As String, ByVal NumFolios As Integer) As Boolean
        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", Caja)
        Impresora = dt.Rows(0)("ImpresoraFac")
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_folioactual", "@TipoComprobante", 7, "@SUCClave", SUCClave, "@CAJClave", CAJClave)

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            If dt.Compute("SUM(FolioFinal) - SUM(FolioActual)", "") >= NumFolios Then
                FOLClave = dt.Rows(0)("FOLClave")
                oCFD.noAprobacion = dt.Rows(0)("NoAprobacion")
                oCFD.anoAprobacion = CStr(dt.Rows(0)("AnoAprobacion"))
                oCFD.Serie = dt.Rows(0)("Serie")
                oCFD.Folio = CStr(dt.Rows(0)("FolioActual") + 1)
                oCFD.fechaAprobacion = IIf(dt.Rows(0)("fechaAprobacion").GetType.Name = "DBNull", Today(), dt.Rows(0)("fechaAprobacion"))

                If Not dt.Rows(0)("CBB") Is System.DBNull.Value Then
                    oCFD.CBB = CType(dt.Rows(0)("CBB"), Byte())
                End If

                dt.Dispose()

                ModPOS.Ejecuta("sp_incrementa_folio", "@FOLClave", FOLClave)

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

    Public Sub CargaDatosCliente(ByVal CTEClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", CTEClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            CTEClave = dt.Rows(0)("CTEClave")
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
        Else
            MessageBox.Show("La información del cliente no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Public Sub CargaDatosFactura(ByVal Folio As String, ByVal esClave As Integer)
        'Valida que el campo Ticket no se encuentre vacio
        Dim dtFactura As DataTable = ModPOS.SiExisteRecupera("sp_busca_factura", "@Folio", Folio, "@Clave", esClave, "@COMClave", ModPOS.CompanyActual)
        If Not dtFactura Is Nothing AndAlso dtFactura.Rows.Count > 0 Then


            Dim TipoCF_fac As Integer = dtFactura.Rows(0)("TipoCF")
            Dim Estado_fac As Integer = dtFactura.Rows(0)("Estado")

            FACClave = dtFactura.Rows(0)("FACClave")
            SaldoFactura = dtFactura.Rows(0)("Saldo")
            SubtotalFactura = dtFactura.Rows(0)("Subtotal")
            ImpuestoFactura = dtFactura.Rows(0)("ImpuestoTot")
            TotalFactura = dtFactura.Rows(0)("Total")
            oCFD.CTEClave = dtFactura.Rows(0)("CTEClave")
            Moneda = IIf(dtFactura.Rows(0)("MONClave").GetType.Name = "DBNull", Moneda, dtFactura.Rows(0)("MONClave"))

            dtFactura.Dispose()


            If TipoCF_fac = 2 AndAlso Estado_fac = 2 Then
                MessageBox.Show("No es posible realizar la NC de una factura que aun no ha sido certificad por el PAC (Timbrada)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
            If dt.Rows.Count > 0 Then
                MonedaRef = dt.Rows(0)("Referencia")
                MonedaDesc = dt.Rows(0)("Descripcion")
                TipoCambio = IIf(dt.Rows(0)("TipoCambio").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambio"))
            Else
                TipoCambio = 1
            End If

            dt.Dispose()

            Dim dtNC As DataTable = ModPOS.SiExisteRecupera("sp_recupera_ncfac", "@FACClave", FACClave)

            If Not dtNC Is Nothing AndAlso dtNC.Rows.Count > 0 Then
                If dtNC.Rows(0)("Importe") Is System.DBNull.Value Then
                    disponible = TotalFactura
                Else
                    disponible = TotalFactura - dtNC.Rows(0)("Importe")
                End If
                dtNC.Dispose()
            Else
                disponible = TotalFactura
            End If


            TxtTotalFac.Text = CStr(ModPOS.Redondear(TotalFactura, 2))
            TxtDisponible.Text = CStr(ModPOS.Redondear(disponible, 2))

            CargaDatosCliente(oCFD.CTEClave)

            If Not dtDetalle Is Nothing Then
                dtDetalle.Dispose()
            End If

            dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_nc", "@FACClave", FACClave)
            GridDetalle.DataSource = dtDetalle
            GridDetalle.RetrieveStructure()
            GridDetalle.AutoSizeColumns()
            GridDetalle.RootTable.Columns("DFAClave").Visible = False
            GridDetalle.CurrentTable.Columns("Factura").Selectable = False
            GridDetalle.CurrentTable.Columns("Disponible").Selectable = False
            GridDetalle.CurrentTable.Columns("Clave").Selectable = False
            GridDetalle.CurrentTable.Columns("Nombre").Selectable = False
            GridDetalle.CurrentTable.Columns("Precio Unitario").Selectable = False
            GridDetalle.CurrentTable.Columns("Dscto").Selectable = False
            GridDetalle.RootTable.Columns("ImpuestoImp").Visible = False
            GridDetalle.RootTable.Columns("Costo").Visible = False
            GridDetalle.RootTable.Columns("PROClave").Visible = False
            GridDetalle.RootTable.Columns("PuntosImp").Visible = False
            GridDetalle.RootTable.Columns("CostoTotal").Visible = False
            GridDetalle.RootTable.Columns("Subtotal").Visible = False
            GridDetalle.RootTable.Columns("IVAtotal").Visible = False
            GridDetalle.RootTable.Columns("Desctotal").Visible = False
            GridDetalle.RootTable.Columns("Seguimiento").Visible = False
            GridDetalle.RootTable.Columns("DiasGarantia").Visible = False
            GridDetalle.RootTable.Columns("TProducto").Visible = False

            dtImpuestodet = ModPOS.Recupera_Tabla("sp_impuestos_nc", "@FACClave", FACClave)
        Else
            MessageBox.Show("No se encontro documento o se encuentra cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub FrmNC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        oCFD = New CFD

        oCFD.tipoDeComprobante = "egreso"

        NCClave = ModPOS.obtenerLlave


        With Me.CmbMotivo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Devolucion"
            .NombreParametro2 = "campo"
            .Parametro2 = "Motivo"
            .llenar()
        End With

        With CmbCaja
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_caja"
            .NombreParametro1 = "Sucursal"
            .Parametro1 = SUCClave
            .llenar()
        End With

        With Me.CmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "NC"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        If CAJClave <> "" Then
            CmbCaja.SelectedValue = CAJClave
            CmbCaja.Enabled = False
        End If

        With CmbFormaPago
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "CFD"
            .NombreParametro2 = "campo"
            .Parametro2 = "FormaPago"
            .llenar()
        End With

        CajaLoad = True

        Dim dtParam As DataTable

        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave ", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "LineasNC"
                        MaxRow = CInt(dtParam.Rows(i)("Valor"))
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

        TxtVendedor.Text = MPrincipal.StUsuario.Text
        LstDomicilio.Items.Clear()
        TxtTicket.Focus()

        If Not Facturas Is Nothing AndAlso Facturas.GetLength(0) = 1 Then
            TxtFolio.Text = Facturas(0)("Folio")
            Me.CargaDatosFactura(Facturas(0)("ID"), 1)
            TxtTicket.Text = Facturas(0)("Folio")
        End If

    End Sub

    Private Sub FrmNC_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoNC Is Nothing Then
            If Not ModPOS.MtoNC.CmbSucursal.SelectedValue Is Nothing AndAlso ModPOS.MtoNC.Periodo > 0 AndAlso ModPOS.MtoNC.Mes > 0 Then
                ModPOS.MtoNC.refrescaGrid()
            End If
        End If


        If bLiquidacion = True AndAlso Not ModPOS.Liquid Is Nothing Then
            ModPOS.Liquid.ActualizaGridTransac()
        End If

        If bLiquidacion = True AndAlso Not ModPOS.MtoVenta Is Nothing Then
            ModPOS.MtoVenta.ActualizaGridTransac()
        End If


        ModPOS.NC.Dispose()
        ModPOS.NC = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub imprimirNC(ByVal tipo As Integer)
        Dim sImpresora As String
        Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", Impresora)
        sImpresora = dtPrinter.Rows(0)("Referencia")
        dtPrinter.Dispose()



        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"

        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", NCClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_detalle", "@NCClave", NCClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", NCClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_referencia_factura", "@NCClave", NCClave))

        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_nc", "@NCClave", NCClave))

        If oCFD.TipoCF = 1 Then
            OpenReport.Print("CREgresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(TotalNC / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
        ElseIf oCFD.TipoCF = 2 Then
            OpenReport.Print("CREgresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(TotalNC / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
        ElseIf oCFD.TipoCF = 3 Then
            OpenReport.Print("CREgresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(TotalNC / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
        End If

    End Sub

    Private Sub CmbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipo.SelectedIndexChanged
        If CajaLoad = True AndAlso Not CmbTipo.SelectedValue Is Nothing Then
            If CmbTipo.SelectedValue = 1 Then
                GridDetalle.Enabled = True
                Me.TxtDescripcion.Text = ""
                Me.TxtDescripcion.Enabled = False
                Me.TxtDescripcion.ReadOnly = True

                Me.TxtDescuento.Text = "0.0"
                Me.TxtDescuento.Enabled = False
                Me.TxtDescuento.ReadOnly = True

                Me.TxtTotal.ReadOnly = True
                'Me.TxtTotal.Enabled = False

                Me.CmbMotivo.Enabled = True


                If Not dtDetalle Is Nothing Then
                    SubtotalNC = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    TxtSubtotal.Text = CStr(ModPOS.Redondear(SubtotalNC, 2))

                    IVANC = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("IVAtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    TxtIVA.Text = CStr(ModPOS.Redondear(IVANC, 2))

                    TotalNC = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    TxtTotal.Text = ModPOS.Redondear(TotalNC, 2)

                    CostoTotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Costo"), Janus.Windows.GridEX.AggregateFunction.Sum)

                    DescTotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Desctotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                End If

            Else
                GridDetalle.Enabled = False
                Me.TxtDescripcion.Text = ""
                Me.TxtDescripcion.Enabled = True
                Me.TxtDescripcion.ReadOnly = False

                Me.TxtDescuento.Text = "0.0"
                Me.TxtDescuento.Enabled = True
                Me.TxtDescuento.ReadOnly = False

                Me.TxtTotal.ReadOnly = False
                'Me.TxtTotal.Enabled = True

                Me.CmbMotivo.Enabled = False

                If Not TxtDescuento.Text = 0 Then
                    PorcDesc = CDbl(TxtDescuento.Text) / 100
                    TotalNC = TotalFactura * PorcDesc
                    SubtotalNC = SubtotalFactura * PorcDesc
                    IVANC = ImpuestoFactura * PorcDesc
                    Me.TxtTotal.Text = CStr(Redondear(TotalNC, 2))
                    Me.TxtIVA.Text = CStr(Redondear(IVANC, 2))
                    Me.TxtSubtotal.Text = CStr(Redondear(SubtotalNC, 2))
                Else
                    TotalNC = 0
                    IVANC = 0
                    SubtotalNC = 0
                    PorcDesc = 0
                    TxtDescuento.Text = 0
                    TxtTotal.Text = 0
                    TxtIVA.Text = "0"
                    TxtSubtotal.Text = "0"
                End If
            End If
        End If
    End Sub

    Private Sub TxtTicket_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTicket.KeyPress
        If Asc(e.KeyChar) = 13 Then

            If CmbCaja.SelectedValue Is Nothing Then
                MessageBox.Show("La Caja seleccionada no tiene un Folio disponible para Nota de Crédito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                If Not TxtTicket.Text = vbNullString Then
                    CargaDatosFactura(TxtTicket.Text.ToUpper.Trim.Replace("'", "''"), 0)
                End If
            End If
        End If
    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Devolución" Then
            If IsNumeric(GridDetalle.GetValue("Devolución")) Then
                If GridDetalle.GetValue("Disponible") >= GridDetalle.GetValue("Devolución") Then
                    Dim Actual, Subtotal, IVAtotal, Desctotal, Costo As Double
                    Actual = Math.Abs(CDbl(GridDetalle.GetValue("Devolución"))) * (GridDetalle.GetValue("Precio Unitario") + GridDetalle.GetValue("ImpuestoImp") - GridDetalle.GetValue("Dscto"))
                    Subtotal = Math.Abs(CDbl(GridDetalle.GetValue("Devolución"))) * (GridDetalle.GetValue("Precio Unitario") - GridDetalle.GetValue("Dscto"))
                    IVAtotal = Math.Abs(CDbl(GridDetalle.GetValue("Devolución"))) * GridDetalle.GetValue("ImpuestoImp")
                    Desctotal = Math.Abs(CDbl(GridDetalle.GetValue("Devolución"))) * GridDetalle.GetValue("Dscto")

                    Costo = Math.Abs(CDbl(GridDetalle.GetValue("Devolución"))) * GridDetalle.GetValue("Costo")

                    GridDetalle.SetValue("Importe", Actual)
                    GridDetalle.SetValue("Subtotal", Subtotal)
                    GridDetalle.SetValue("IVAtotal", IVAtotal)
                    GridDetalle.SetValue("Desctotal", Desctotal)
                    GridDetalle.SetValue("CostoTotal", Costo)
                Else
                    Beep()
                    MessageBox.Show("¡La cantidad a devolver no puede ser mayor al disponible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Devolución", 0)
                End If
            Else
                GridDetalle.SetValue("Devolución", 0)
            End If
        End If
    End Sub

    Private Sub GridDetalle_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.RecordUpdated
        SubtotalNC = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
        TxtSubtotal.Text = CStr(ModPOS.Redondear(SubtotalNC, 2))

        IVANC = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("IVAtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
        TxtIVA.Text = CStr(ModPOS.Redondear(IVANC, 2))

        TotalNC = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
        TxtTotal.Text = ModPOS.Redondear(TotalNC, 2)

        CostoTotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("CostoTotal"), Janus.Windows.GridEX.AggregateFunction.Sum)

        DescTotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Desctotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
    End Sub

    Private Sub TxtTotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTotal.KeyPress
        If Asc(e.KeyChar) = 13 AndAlso CmbTipo.SelectedValue <> 1 Then
            If Not TxtTotal.Text = 0 Then
                TotalNC = CDbl(TxtTotal.Text)
                PorcDesc = ((TotalNC * 100) / TotalFactura) / 100
                IVANC = ImpuestoFactura * PorcDesc
                SubtotalNC = SubtotalFactura * PorcDesc
                Me.TxtDescuento.Text = CStr(Redondear(PorcDesc * 100, 2))
                Me.TxtIVA.Text = CStr(Redondear(IVANC, 2))
                Me.TxtSubtotal.Text = CStr(Redondear(SubtotalNC, 2))
            Else
                CostoTotal = 0
                TotalNC = 0
                IVANC = 0
                SubtotalNC = 0
                PorcDesc = 0
                TxtDescuento.Text = 0
                TxtTotal.Text = 0
                TxtIVA.Text = "0"
                TxtSubtotal.Text = "0"
            End If
        End If
    End Sub

    Private Sub TxtDescuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescuento.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TxtDescripcion.Focus()
        End If
    End Sub

    Private Sub BtnBuscaFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaFactura.Click
        Dim a As New MeSearchDate
        a.ProcedimientoAlmacenado = "sp_search_factura"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.companiaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.CargaDatosFactura(a.valor, 1)
            TxtTicket.Text = a.Descripcion
        End If
        a.Dispose()
    End Sub

    Private Sub TxtDescuento_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDescuento.Leave
        CreaBonificacion()
    End Sub


    'Private Function generarCadenaOriginal(ByVal sVersionCF As String, ByVal Fecha As String) As String

    '    Dim i As Integer

    '    'Recupera encabezado de factura para NodoEncabezado.
    '    Dim sNodoConcepto As String = ""

    '    Dim dSubtotal As Double = 0
    '    Dim dTotal As Double = 0

    '    For i = 0 To dtConcepto.Rows.Count - 1
    '        sNodoConcepto = sNodoConcepto & CStr(dtConcepto.Rows(i)("Cantidad")) & "|" & dtConcepto.Rows(i)("Unidad") & "|" & dtConcepto.Rows(i)("Clave") & "|" & spaceFormat(CStr(dtConcepto.Rows(i)("Descripción")).Trim) & "|" & CStr(Redondear(dtConcepto.Rows(i)("P.U."), 6)) & "|" & CStr(Redondear(dtConcepto.Rows(i)("Cantidad") * dtConcepto.Rows(i)("P.U."), 6)) & "|"
    '        dSubtotal += dtConcepto.Rows(i)("Cantidad") * dtConcepto.Rows(i)("P.U.")
    '    Next

    '    subtotal = CStr(Redondear(dSubtotal, 6))
    '    total = CStr(Redondear(dSubtotal - descuento, 6))


    '    Dim sNodoImpuestosTrasladado As String = ""

    '    impuestos = 0

    '    For i = 0 To dtImpuesto.Rows.Count - 1
    '        sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & dtImpuesto.Rows(i)("Impuesto")
    '        sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & "|" & CStr(dtImpuesto.Rows(i)("Tasa") * 100)
    '        sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & "|" & CStr(Redondear(dtImpuesto.Rows(i)("Importe"), 6)) & "|"
    '        impuestos += dtImpuesto.Rows(i)("Importe")
    '    Next

    '    sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & CStr(Redondear(impuestos, 6)) & "||"

    '    Dim sNodoEncabezado As String = "||" & sVersionCF & "|" & IIf(TipoCF = 2, "", Serie & "|" & Folio & "|") & Fecha & "|" & IIf(TipoCF = 2, "", noAprobacion & "|" & anoAprobacion & "|") & tipoDeComprobante & "|" & formaDePago & "|" & subtotal & "|" & CStr(descuento) & "|" & total & "|"

    '    Dim sNodoRegimenFiscal As String = ""

    '    If sVersionCF = "2.2" OrElse sVersionCF = "3.2" Then
    '        sNodoEncabezado &= metodoDePago & "|" & LugarExpedicion & "|"
    '        sNodoRegimenFiscal = regimenFiscal & "|"
    '    End If

    '    Dim sNodoEmisor As String = spaceFormat(eRFC) & "|" & spaceFormat(eRazonSocial) & "|" & spaceFormat(eCalle) & "|" & enoExterior & IIf(benoInterior, "|" & enoInterior, "") & "|" & spaceFormat(eColonia) & "|" & IIf(eLocalidad = "", "SIN LOCALIDAD", spaceFormat(eLocalidad)) & "|" & spaceFormat(eReferencia) & "|" & eMnpio & "|" & eEntidad & "|" & ePais & "|" & eCodigoPostal & "|"
    '    Dim sNodoExpedicion As String = spaceFormat(sCalle) & "|" & snoExterior & IIf(bsnoInterior, "|" & snoInterior, "") & "|" & spaceFormat(sColonia) & "|" & IIf(sLocalidad = "", "SIN LOCALIDAD", spaceFormat(sLocalidad)) & "|" & spaceFormat(sReferencia) & "|" & sMnpio & "|" & sEntidad & "|" & sPais & "|" & sCodigoPostal & "|"
    '    Dim sNodoReceptor As String = spaceFormat(RFC) & "|" & spaceFormat(RazonSocial) & "|" & spaceFormat(Calle) & "|" & noExterior & IIf(brnoInterior, "|" & noInterior, "") & "|" & spaceFormat(Colonia) & "|" & IIf(Localidad = "", "SIN LOCALIDAD", spaceFormat(Localidad)) & "|" & IIf(Referencia = "", "SIN REFERENCIA", spaceFormat(Referencia)) & "|" & Mnpio & "|" & Entidad & "|" & Pais & "|" & codigoPostal & "|"

    '    If iTipoSucursal = 1 Then
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
    '            MessageBox.Show("El archivo " & LlaveFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Return False
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

    '    dir = "C:\OpenSSL\bin\openssl.exe" '"Openssl\openssl.exe"

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


    'Public Sub crearXML(ByVal sVersionCF As String, ByVal Fecha As String, ByVal elsello As String)
    '    Dim i As Integer
    '    Dim FileXML As String
    '    Dim sPre As String = ""

    '    FileXML = pathActual & "CFD\" & Serie & Folio & ".xml"

    '    If TipoCF = 2 Then
    '        sPre = "cfdi:"
    '    End If

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

    '    If sVersionCF = "2.0" OrElse sVersionCF = "2.2" Then
    '        textWriter.WriteAttributeString("xmlns", "http://www.sat.gob.mx/cfd/2")
    '    ElseIf sVersionCF = "3.0" OrElse sVersionCF = "3.2" Then
    '        textWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")
    '    End If

    '    textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")

    '    Select Case sVersionCF
    '        Case Is = "2.0"
    '            textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv2.xsd")
    '        Case Is = "2.2"
    '            textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv22.xsd")
    '        Case Is = "3.0"
    '            textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv3.xsd")
    '        Case Is = "3.2"
    '            textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd")
    '    End Select

    '    textWriter.WriteAttributeString("version", sVersionCF)

    '    If Serie <> "" Then
    '        textWriter.WriteAttributeString("serie", Serie)
    '    End If

    '    textWriter.WriteAttributeString("folio", Folio)
    '    textWriter.WriteAttributeString("fecha", Fecha)
    '    textWriter.WriteAttributeString("sello", elsello)
    '    If TipoCF = 1 Then
    '        textWriter.WriteAttributeString("noAprobacion", noAprobacion)
    '        textWriter.WriteAttributeString("anoAprobacion", anoAprobacion)
    '    End If
    '    textWriter.WriteAttributeString("formaDePago", formaDePago)
    '    textWriter.WriteAttributeString("noCertificado", noCertificado)
    '    textWriter.WriteAttributeString("certificado", Certificado64)
    '    textWriter.WriteAttributeString("subTotal", Redondear(subtotal, 6))
    '    textWriter.WriteAttributeString("descuento", CStr(Redondear(descuento, 6)))
    '    textWriter.WriteAttributeString("total", Redondear(total, 6))
    '    textWriter.WriteAttributeString("tipoDeComprobante", tipoDeComprobante)

    '    If sVersionCF = "2.2" OrElse sVersionCF = "3.2" Then
    '        textWriter.WriteAttributeString("metodoDePago", metodoDePago)
    '        textWriter.WriteAttributeString("LugarExpedicion", spaceFormat(LugarExpedicion))
    '    End If

    '    textWriter.WriteStartElement(sPre & "Emisor")
    '    textWriter.WriteAttributeString("rfc", spaceFormat(eRFC))
    '    textWriter.WriteAttributeString("nombre", spaceFormat(eRazonSocial))
    '    textWriter.WriteStartElement(sPre & "DomicilioFiscal")
    '    textWriter.WriteAttributeString("calle", spaceFormat(eCalle))
    '    textWriter.WriteAttributeString("noExterior", enoExterior)

    '    If benoInterior Then
    '        textWriter.WriteAttributeString("noInterior", enoInterior)
    '    End If

    '    textWriter.WriteAttributeString("colonia", spaceFormat(eColonia))
    '    textWriter.WriteAttributeString("localidad", IIf(eLocalidad = "", "SIN LOCALIDAD", spaceFormat(eLocalidad)))
    '    textWriter.WriteAttributeString("referencia", spaceFormat(eReferencia))
    '    textWriter.WriteAttributeString("municipio", spaceFormat(eMnpio))
    '    textWriter.WriteAttributeString("estado", eEntidad)
    '    textWriter.WriteAttributeString("pais", ePais)
    '    textWriter.WriteAttributeString("codigoPostal", eCodigoPostal)
    '    'Cierre de Domicilio
    '    textWriter.WriteEndElement()

    '    If iTipoSucursal <> 1 Then
    '        textWriter.WriteStartElement(sPre & "ExpedidoEn")
    '        textWriter.WriteAttributeString("calle", spaceFormat(sCalle))
    '        textWriter.WriteAttributeString("noExterior", snoExterior)

    '        If bsnoInterior Then
    '            textWriter.WriteAttributeString("noInterior", snoInterior)
    '        End If

    '        textWriter.WriteAttributeString("colonia", spaceFormat(sColonia))
    '        textWriter.WriteAttributeString("localidad", IIf(sLocalidad = "", "SIN LOCALIDAD", spaceFormat(sLocalidad)))
    '        textWriter.WriteAttributeString("referencia", spaceFormat(sReferencia))
    '        textWriter.WriteAttributeString("municipio", spaceFormat(sMnpio))
    '        textWriter.WriteAttributeString("estado", sEntidad)
    '        textWriter.WriteAttributeString("pais", sPais)
    '        textWriter.WriteAttributeString("codigoPostal", sCodigoPostal)
    '        'Cierre de centro de expedición
    '        textWriter.WriteEndElement()
    '    End If

    '    If sVersionCF = "2.2" OrElse sVersionCF = "3.2" Then
    '        textWriter.WriteStartElement(sPre & "RegimenFiscal")
    '        textWriter.WriteAttributeString("Regimen", regimenFiscal)
    '        textWriter.WriteEndElement()
    '    End If

    '    'Cierre de Emisor
    '    textWriter.WriteEndElement()

    '    textWriter.WriteStartElement(sPre & "Receptor")
    '    textWriter.WriteAttributeString("rfc", spaceFormat(RFC))
    '    textWriter.WriteAttributeString("nombre", spaceFormat(RazonSocial))
    '    textWriter.WriteStartElement(sPre & "Domicilio")
    '    textWriter.WriteAttributeString("calle", spaceFormat(Calle))
    '    textWriter.WriteAttributeString("noExterior", noExterior)

    '    If brnoInterior Then
    '        textWriter.WriteAttributeString("noInterior", noInterior)
    '    End If

    '    textWriter.WriteAttributeString("colonia", spaceFormat(Colonia))
    '    textWriter.WriteAttributeString("localidad", IIf(Localidad = "", "SIN LOCALIDAD", spaceFormat(Localidad)))
    '    textWriter.WriteAttributeString("referencia", spaceFormat(Referencia))
    '    textWriter.WriteAttributeString("municipio", spaceFormat(Mnpio))
    '    textWriter.WriteAttributeString("estado", Entidad)
    '    textWriter.WriteAttributeString("pais", Pais)
    '    textWriter.WriteAttributeString("codigoPostal", codigoPostal)
    '    'Cierre de Domicilioi
    '    textWriter.WriteEndElement()
    '    'Cierre de Receptor
    '    textWriter.WriteEndElement()


    '    textWriter.WriteStartElement(sPre & "Conceptos")
    '    'Inicia for para llenar detalle

    '    For i = 0 To dtConcepto.Rows.Count - 1
    '        textWriter.WriteStartElement(sPre & "Concepto")
    '        textWriter.WriteAttributeString("cantidad", dtConcepto.Rows(i)("Cantidad"))
    '        textWriter.WriteAttributeString("unidad", dtConcepto.Rows(i)("Unidad"))
    '        textWriter.WriteAttributeString("noIdentificacion", dtConcepto.Rows(i)("Clave"))
    '        textWriter.WriteAttributeString("descripcion", spaceFormat(CStr(dtConcepto.Rows(i)("Descripción")).Trim))
    '        textWriter.WriteAttributeString("valorUnitario", Redondear(dtConcepto.Rows(i)("P.U."), 6))
    '        textWriter.WriteAttributeString("importe", Redondear(dtConcepto.Rows(i)("Cantidad") * dtConcepto.Rows(i)("P.U."), 6))
    '        textWriter.WriteEndElement()

    '    Next
    '    'Fin de ciclo

    '    'Cierre de Conceptos
    '    textWriter.WriteEndElement()

    '    ' Write one more element
    '    textWriter.WriteStartElement(sPre & "Impuestos")
    '    textWriter.WriteAttributeString("totalImpuestosTrasladados", Redondear(impuestos, 6))

    '    textWriter.WriteStartElement(sPre & "Traslados")


    '    'Inicio ciclo de impuestos

    '    For i = 0 To dtImpuesto.Rows.Count - 1
    '        textWriter.WriteStartElement(sPre & "Traslado")
    '        textWriter.WriteAttributeString("impuesto", dtImpuesto.Rows(i)("Impuesto"))
    '        textWriter.WriteAttributeString("tasa", dtImpuesto.Rows(i)("Tasa") * 100)
    '        textWriter.WriteAttributeString("importe", Redondear(dtImpuesto.Rows(i)("Importe"), 6))
    '        textWriter.WriteEndElement()
    '    Next

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

    '    If TipoCF = 2 Then
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
    '            UUID = "NO_VALIDO_FOLIO_FISCAL"
    '            SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
    '            bTimbreError = True
    '            ModPOS.Ejecuta("sp_actualiza_edo_nc", "@NCClave", NCClave, "@Estado", 2)
    '        Else
    '            bTimbreError = False
    '            UUID = oTimbre.UUID
    '            SelloSAT = oTimbre.selloSAT
    '            CertificadoSAT = oTimbre.noCertificadoSAT
    '            fechaTimbrado = oTimbre.FechaTimbrado
    '            versionSAT = oTimbre.version

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
    '            newAttr.Value = SelloSAT
    '            newEle1.Attributes.Append(newAttr)

    '            newAttr = oXml.CreateAttribute("UUID")
    '            newAttr.Value = UUID
    '            newEle1.Attributes.Append(newAttr)


    '            newAttr = oXml.CreateAttribute("FechaTimbrado")
    '            newAttr.Value = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", fechaTimbrado)
    '            newEle1.Attributes.Append(newAttr)


    '            newAttr = oXml.CreateAttribute("version")
    '            newAttr.Value = versionSAT
    '            newEle1.Attributes.Append(newAttr)

    '            newAttr = oXml.CreateAttribute("noCertificadoSAT")
    '            newAttr.Value = CertificadoSAT
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
    '                System.IO.File.Copy(FileXML, PathXML & Serie & Folio & ".xml")
    '            Else
    '                System.IO.File.Copy(FileXML, PathXML & "\" & Serie & Folio & ".xml")
    '            End If
    '        Else
    '            MessageBox.Show("El directorio " & PathXML & " no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Public Function crearCF(ByVal NCClave As String) As Boolean

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

        dt = ModPOS.Recupera_Tabla("sp_recupera_nc", "@NCClave", NCClave)

        dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_conceptonc", "@tipo", dt.Rows(0)("tipo"), "@Clave", NCClave)
        dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_impuestosnc", "@tipo", dt.Rows(0)("tipo"), "@Clave", NCClave)


        oCFD.Serie = dt.Rows(0)("Serie")
        oCFD.Folio = dt.Rows(0)("Folio")

        sFolio = oCFD.Serie & oCFD.Folio

        oCFD.descuento = 0

        oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dt.Rows(0)("fecha"))

        'oCFD.extra = TxtExtra.Text
        oCFD.Moneda = MonedaRef
        oCFD.TipoCambio = TipoCambio

        If oCFD.TipoCF <= 2 Then

            oCFD.DOCClave = NCClave

            If oCFD.TipoCF = 1 Then
                oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
            Else
                oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, 7)
            End If

            oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave)

            

            iTipoPAC = crearXML(1, dtPAC, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, 7)

        Else
            actualizaEdoCFD(oCFD.tipoDeComprobante, oCFD.DOCClave, 1, 7)
        End If

        
        dt.Dispose()
        dtConcepto.Dispose()
        dtImpuesto.Dispose()

        Return True
    End Function

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        Dim frMetodoPagos() As System.Data.DataRow
        Dim Efectivo As Double

        If dtDetalle Is Nothing OrElse dtDetalle.Rows.Count = 0 Then
            MessageBox.Show("Debe seleccionar una Factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Not CmbCaja.SelectedValue Is Nothing Then
            CAJClave = CmbCaja.SelectedValue
        Else
            MessageBox.Show("Debe seleccionar una Caja valida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Not CmbFormaPago.SelectedValue Is Nothing Then
            oCFD.formaDePago = Me.CmbFormaPago.Text.Trim
        Else
            MessageBox.Show("Debe seleccionar una opcion valida de Forma de Pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ModPOS.MetodoPago Is Nothing Then
            ModPOS.MetodoPago = New FrmMetodoPago
            With ModPOS.MetodoPago
                .CTEClave = oCFD.CTEClave
                .FacturaId = ""
                .NCClave = "NCClave"
            End With
        End If

        ModPOS.MetodoPago.StartPosition = FormStartPosition.CenterScreen
        If ModPOS.MetodoPago.ShowDialog = Windows.Forms.DialogResult.OK Then
            frMetodoPagos = ModPOS.MetodoPago.MetodoPagoRows
            If frMetodoPagos.Length = 0 Then
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

        Dim NumNC As Integer

        If CmbTipo.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar el tipo de Nota de Crédito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If disponible <= 0 Then
            MessageBox.Show("El importe disponible de la factura seleccionada para realizar la Nota de Crédito debe ser mayor a cero", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim a As New MeAutorizacion
        a.Sucursal = SUCClave
        a.MontodeAutorizacion = CDbl(TotalNC)
        a.StartPosition = FormStartPosition.CenterScreen
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.Autorizado Then
                a.Dispose()
                Exit Sub
                Autoriza = a.Autoriza
            End If
        ElseIf a.DialogResult = DialogResult.Cancel Then
            a.Dispose()
            Exit Sub
        End If
        a.Dispose()


        If ModPOS.Redondear(TotalNC, 2) <= ModPOS.Redondear(disponible, 2) Then
            Select Case CInt(CmbTipo.SelectedValue)
                Case 1 'Nota de Crédito por Devolución
                    If Not dtDetalle Is Nothing Then
                        Dim i As Integer
                        Dim foundRows() As DataRow
                        Dim foundImp() As DataRow

                        foundRows = dtDetalle.Select("Devolución > 0 and Disponible >= Devolución")

                        If foundRows.GetLength(0) > 0 Then


                            NumNC = Int(foundRows.GetLength(0) / MaxRow)


                            If Not recuperaFolio(CAJClave, NumNC) Then
                                Exit Sub
                            End If


                            ModPOS.Ejecuta("sp_crea_nc", _
                            "@NCClave", NCClave, _
                            "@FACClave", FACClave, _
                            "@CTEClave", oCFD.CTEClave, _
                            "@TipoCF", oCFD.TipoCF, _
                            "@VersionCF", oCFD.VersionCF, _
                            "@RegimenFiscal", oCFD.regimenFiscal, _
                            "@fechaAprobacion", oCFD.fechaAprobacion, _
                            "@Serie", oCFD.Serie, _
                            "@Tipo", CmbTipo.SelectedValue, _
                            "@Folio", oCFD.Folio, _
                            "@CAJClave", CAJClave, _
                            "@Atendio", ModPOS.UsuarioActual, _
                            "@Motivo", CmbMotivo.SelectedValue, _
                            "@PorcDesc", 0, _
                            "@Descripcion", "", _
                            "@Costo", CostoTotal, _
                            "@Subtotal", SubtotalNC, _
                            "@ImpuestoTot", IVANC, _
                            "@DescuentoTot", DescTotal, _
                            "@Total", TotalNC, _
                            "@tipoCertificado", oCFD.tipoDeComprobante, _
                            "@Usuario", ModPOS.UsuarioActual, _
                            "@formaDePago", oCFD.formaDePago, _
                            "@MONClave", Moneda, _
                            "@TipoCambio", TipoCambio)

                            Dim DNCClave As String

                            For i = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_actualiza_cantdev", "@Tipo", 2, "@Documento", FACClave, "@Partida", foundRows(i)(0), "@Cantidad", foundRows(i)(3))

                                DNCClave = ModPOS.obtenerLlave

                                ModPOS.Ejecuta("sp_inserta_ncdetalle", _
                                                "@DNCClave", DNCClave, _
                                                "@NCClave", NCClave, _
                                                "@PROClave", foundRows(i)("PROClave"), _
                                                "@TProducto", foundRows(i)("TProducto"), _
                                                "@Costo", foundRows(i)("Costo"), _
                                                "@Precio", foundRows(i)("Precio Unitario"), _
                                                "@Descuento", foundRows(i)("Dscto"), _
                                                "@Impuesto", foundRows(i)("ImpuestoImp"), _
                                                "@Puntos", foundRows(i)("PuntosImp"), _
                                                "@Cantidad", foundRows(i)("Devolución"), _
                                                "@Subtotal", CDbl(foundRows(i)("Importe") - foundRows(i)("Desctotal") + foundRows(i)("IVAtotal")), _
                                                "@Total", CDbl(foundRows(i)("Devolución") * (foundRows(i)("Importe") - foundRows(i)("Desctotal") + foundRows(i)("IVAtotal"))))


                                'SI REQUIERE SEGUIMIENTO DE SERIAL
                                If foundRows(i)("Seguimiento") = 2 Then
                                    Dim SerialReg As Integer = 0
                                    Dim PorRegistrar As Double
                                    PorRegistrar = foundRows(i)("Devolución")
                                    Do
                                        Dim b As New FrmSerial
                                        b.DOCClave = FACClave
                                        b.PROClave = foundRows(i)("PROClave")
                                        b.Clave = foundRows(i)("Clave")
                                        b.Nombre = foundRows(i)("Nombre")
                                        b.Cantidad = PorRegistrar
                                        b.Dias = foundRows(i)("DiasGarantia")
                                        b.TipoDoc = 4
                                        b.TipoMov = 1
                                        b.ShowDialog()
                                        SerialReg = SerialReg + b.NumSerialRegistrados
                                        PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                                        b.Dispose()
                                    Loop Until SerialReg = foundRows(i)("Devolución") OrElse PorRegistrar = 0
                                End If

                                'SI REQUIERE SEGUIMIENTO DE LOTE
                                If foundRows(i)("Seguimiento") = 3 Then
                                    Dim LoteReg As Integer = 0
                                    Dim PorRegistrar As Double
                                    PorRegistrar = foundRows(i)("Devolución")
                                    Do
                                        Dim b As New FrmLote
                                        b.DOCClave = FACClave
                                        b.PROClave = foundRows(i)("PROClave")
                                        b.Clave = foundRows(i)("Clave")
                                        b.Nombre = foundRows(i)("Nombre")
                                        b.CantXRegistrar = PorRegistrar
                                        b.TipoDoc = 4
                                        b.TipoMov = 1
                                        b.ShowDialog()
                                        LoteReg = LoteReg + b.NumSerialRegistrados
                                        PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                                        b.Dispose()
                                    Loop Until LoteReg = foundRows(i)("Devolución") OrElse PorRegistrar = 0
                                End If


                                foundImp = dtImpuestodet.Select("DFAClave = '" & foundRows(i)("DFAClave") & "'")

                                If foundImp.GetLength(0) > 0 Then
                                    Dim y As Integer

                                    For y = 0 To foundImp.GetUpperBound(0)

                                        ModPOS.Ejecuta("sp_inserta_ncimpuesto", _
                                                        "@DNCClave", DNCClave, _
                                                        "@IMPClave", foundImp(y)("IMPClave"), _
                                                        "@PorcImp", foundImp(y)("PorcImp"), _
                                                        "@Importe", foundImp(y)("Importe"), _
                                                        "@Usuario", ModPOS.UsuarioActual)

                                    Next
                                End If

                            Next
                            dtDetalle.Dispose()

                            ModPOS.GeneraMovInv(1, 3, 4, NCClave, ALMClave, oCFD.Serie & oCFD.Folio, Autoriza)
                            ModPOS.ActualizaExistAlm(1, 4, NCClave, ALMClave)
                            ModPOS.ActualizaExistUbc(1, 4, NCClave, ALMClave)


                        Else
                            MessageBox.Show("Debe indicar una cantidad a devolver mayor o igual al disponible", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Debe ingresar el folio completo de la factura y presionar Enter", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                Case 2 ' Nota de credito por Bonificación


                    If CDbl(TxtDescuento.Text) > 100 Then
                        MessageBox.Show("Debe especificar un porcentaje de descuento menor o igual a 100%", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If TxtDescripcion.Text = vbNullString Then
                        MessageBox.Show("Debe especificar una descripción para el descuento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    ' Create a DataColumn and set various properties. 
                    Dim column As DataColumn = New DataColumn
                    column.DataType = System.Type.GetType("System.Double")
                    column.Caption = "Sub"
                    column.ColumnName = "Sub"
                    column.Expression = "Disponible * ([Precio Unitario] - Dscto)"


                    Dim column1 As DataColumn = New DataColumn
                    column1.DataType = System.Type.GetType("System.Double")
                    column1.Caption = "IVA"
                    column1.ColumnName = "IVA"
                    column1.Expression = "Disponible * (ImpuestoImp)"

                    dtDetalle.Columns.Add(column)
                    dtDetalle.Columns.Add(column1)

                    SubtotalNC = IIf(dtDetalle.Compute("Sum(Sub)", "") Is System.DBNull.Value, 0, dtDetalle.Compute("Sum(Sub)", "")) * PorcDesc
                    IVANC = IIf(dtDetalle.Compute("Sum(IVA)", "") Is System.DBNull.Value, 0, dtDetalle.Compute("Sum(IVA)", "")) * PorcDesc

                    TotalNC = SubtotalNC + IVANC

                    dtDetalle.Columns.Remove(column)
                    dtDetalle.Columns.Remove(column1)

                    Dim dt As DataTable

                    dt = ModPOS.Recupera_Tabla("sp_recupera_nc_factura", "@FACClave", FACClave)

                    If dt.Rows.Count > 0 Then
                        Dim x As Double
                        x = dt.Rows(0)("total")
                        If x + TotalNC > TotalFactura Then
                            MessageBox.Show("El importe maximo de la Nota de Crédito actual no debe ser mayor a " & Format(CStr(ModPOS.Redondear(TotalNC - x, 2)), "Currency") & " debido a que se han aplicado otras Notas de Crédito a esta misma Factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If

                    If Not recuperaFolio(CAJClave, 1) Then
                        Exit Sub
                    End If

                    ModPOS.Ejecuta("sp_crea_nc", _
                      "@NCClave", NCClave, _
                      "@FACClave", FACClave, _
                      "@CTEClave", oCFD.CTEClave, _
                      "@TipoCF", oCFD.TipoCF, _
                      "@VersionCF", oCFD.VersionCF, _
                      "@metodoPago", oCFD.metodoDePago, _
                      "@RegimenFiscal", oCFD.regimenFiscal, _
                      "@fechaAprobacion", oCFD.fechaAprobacion, _
                      "@Tipo", CmbTipo.SelectedValue, _
                      "@Serie", oCFD.Serie, _
                      "@Folio", oCFD.Folio, _
                      "@CAJClave", CAJClave, _
                      "@Atendio", ModPOS.UsuarioActual, _
                      "@Motivo", CmbMotivo.SelectedValue, _
                      "@PorcDesc", PorcDesc, _
                      "@Descripcion", TxtDescripcion.Text.Trim.ToUpper, _
                      "@Costo", 0, _
                      "@Subtotal", SubtotalNC, _
                      "@ImpuestoTot", IVANC, _
                      "@DescuentoTot", 0, _
                      "@Total", TotalNC, _
                      "@tipoCertificado", oCFD.tipoDeComprobante, _
                      "@Usuario", ModPOS.UsuarioActual, _
                      "@formaDePago", oCFD.formaDePago, _
                      "@MONClave", Moneda, _
                      "@TipoCambio", TipoCambio)


            End Select

            'Agregar el actualizar saldo de NC

            If ModPOS.Redondear(SaldoFactura, 2) > 0 Then
                If ModPOS.Redondear(SaldoFactura, 2) >= ModPOS.Redondear(TotalNC, 2) Then
                    ModPOS.Ejecuta("sp_actualiza_saldo_doc", "@Tipo", 2, "@Documento", FACClave, "@Importe", TotalNC)
                    Efectivo = TotalNC
                Else
                    ModPOS.Ejecuta("sp_actualiza_saldo_doc", "@Tipo", 2, "@Documento", FACClave, "@Importe", TotalNC - SaldoFactura)
                    Efectivo = TotalNC - SaldoFactura
                End If
                ModPOS.Ejecuta("sp_vincula_fac", "@NCClave", NCClave, "@FACClave", FACClave, "@Importe", TotalNC, "@Usuario", ModPOS.UsuarioActual)
            Else
                Efectivo = TotalNC
            End If


            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", oCFD.CTEClave, "@Importe", TotalNC)

            Dim j As Integer

            Dim sMetodoPago, sBanco, sReferencia As String

            For j = 0 To frMetodoPagos.GetUpperBound(0)

                sMetodoPago = IIf(frMetodoPagos(j)("Tipo").GetType.Name = "DBNull", "", frMetodoPagos(j)("Tipo"))
                sBanco = IIf(frMetodoPagos(j)("Banco").GetType.Name = "DBNull", "", frMetodoPagos(j)("Banco"))
                sReferencia = IIf(frMetodoPagos(j)("Referencia").GetType.Name = "DBNull", "", CStr(frMetodoPagos(j)("Referencia")).Trim.ToUpper)



                ModPOS.Ejecuta("sp_agregar_metodopagonc", _
                "@NCClave", Me.NCClave, _
                "@MetodoPago", sMetodoPago, _
                "@Banco", sBanco, _
                "@Referencia", sReferencia)


                If j > 0 Then
                    oCFD.metodoDePago &= ","
                    If oCFD.NumCtaPago <> "" AndAlso sReferencia <> "" Then
                        oCFD.NumCtaPago &= ","
                    End If
                End If

                oCFD.metodoDePago &= sMetodoPago & " " & sBanco
                oCFD.NumCtaPago &= sReferencia


            Next

            If crearCF(NCClave) = False Then
                Me.Close()
                Exit Sub
            End If

            If oCFD.TipoCF = 2 AndAlso iTipoPAC = 0 Then
                MessageBox.Show("No ha sido posible certificar este documento, le recomendamos intentar certificarlo más tarde", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Exit Sub
            End If

            Select Case MessageBox.Show("¿Desea imprimir la nota de crédito?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                Case DialogResult.Yes
                    'Imprime NCBonificación
                    imprimirNC(CmbTipo.SelectedValue)

            End Select

            If oCFD.email <> "" Then
                Select Case MessageBox.Show("¿Desea enviar el documento por correo electrónico?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        SendMail()
                End Select
            End If

            If Cajon = True Then
                Select Case MessageBox.Show("¿Desea abrir cajón para retiro de efectivo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        AbrirCajon(PrinterName)
                End Select
            End If

            If Not Facturas Is Nothing AndAlso Facturas.GetLength(0) = 1 AndAlso Not ModPOS.Liquid Is Nothing Then
                ModPOS.Liquid.ActualizaGridTransac()
            End If

            Me.Close()
        Else
            MessageBox.Show("El importe maximo de la Nota de Crédito que puede ser aplicado a la factura es: " & Format(CStr(ModPOS.Redondear(disponible, 2)), "Currency"), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub





    Private Sub TxtTotal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTotal.Leave
        If CmbTipo.SelectedValue <> 1 Then
            If Not TxtTotal.Text = 0 Then
                TotalNC = CDbl(TxtTotal.Text)
                PorcDesc = ((TotalNC * 100) / TotalFactura) / 100
                IVANC = ImpuestoFactura * PorcDesc
                SubtotalNC = SubtotalFactura * PorcDesc
                Me.TxtDescuento.Text = CStr(Redondear(PorcDesc * 100, 2))
                Me.TxtIVA.Text = CStr(Redondear(IVANC, 2))
                Me.TxtSubtotal.Text = CStr(Redondear(SubtotalNC, 2))
            Else
                CostoTotal = 0
                TotalNC = 0
                IVANC = 0
                SubtotalNC = 0
                PorcDesc = 0
                TxtDescuento.Text = 0
                TxtTotal.Text = 0
                TxtIVA.Text = "0"
                TxtSubtotal.Text = "0"
            End If
        End If
    End Sub
End Class
