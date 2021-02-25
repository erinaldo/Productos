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
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LstDomicilio As System.Windows.Forms.ListBox
    Friend WithEvents TxtRFC As System.Windows.Forms.TextBox
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents TxtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtTicket As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscaFactura As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbMotivo As Selling.StoreCombo
    Friend WithEvents TxtTotalFac As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ChkDevolver As Selling.ChkStatus
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbUsoCFDI As Selling.StoreCombo
    Friend WithEvents CmbCaja As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNC))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox()
        Me.TxtTotalFac = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbMotivo = New Selling.StoreCombo()
        Me.TxtTicket = New System.Windows.Forms.TextBox()
        Me.BtnBuscaFactura = New Janus.Windows.EditControls.UIButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CmbCaja = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.TxtVendedor = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.TxtObservacion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GrpCliente = New System.Windows.Forms.GroupBox()
        Me.TxtRFC = New System.Windows.Forms.TextBox()
        Me.LstDomicilio = New System.Windows.Forms.ListBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.ChkDevolver = New Selling.ChkStatus(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbUsoCFDI = New Selling.StoreCombo()
        Me.GrpGeneral.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpGeneral.Controls.Add(Me.Label4)
        Me.GrpGeneral.Controls.Add(Me.cmbUsoCFDI)
        Me.GrpGeneral.Controls.Add(Me.TxtTotalFac)
        Me.GrpGeneral.Controls.Add(Me.Label13)
        Me.GrpGeneral.Controls.Add(Me.Label6)
        Me.GrpGeneral.Controls.Add(Me.CmbMotivo)
        Me.GrpGeneral.Controls.Add(Me.TxtTicket)
        Me.GrpGeneral.Controls.Add(Me.BtnBuscaFactura)
        Me.GrpGeneral.Controls.Add(Me.Label12)
        Me.GrpGeneral.Controls.Add(Me.CmbCaja)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Controls.Add(Me.ChkEstado)
        Me.GrpGeneral.Location = New System.Drawing.Point(485, 4)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(300, 192)
        Me.GrpGeneral.TabIndex = 1
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos Generales"
        '
        'TxtTotalFac
        '
        Me.TxtTotalFac.Enabled = False
        Me.TxtTotalFac.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.TxtTotalFac.Location = New System.Drawing.Point(114, 110)
        Me.TxtTotalFac.Name = "TxtTotalFac"
        Me.TxtTotalFac.ReadOnly = True
        Me.TxtTotalFac.Size = New System.Drawing.Size(179, 20)
        Me.TxtTotalFac.TabIndex = 112
        Me.TxtTotalFac.Text = "$0.00"
        Me.TxtTotalFac.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtTotalFac.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(7, 113)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 15)
        Me.Label13.TabIndex = 113
        Me.Label13.Text = "Total Fac."
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(7, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Motivo"
        '
        'CmbMotivo
        '
        Me.CmbMotivo.Location = New System.Drawing.Point(77, 136)
        Me.CmbMotivo.Name = "CmbMotivo"
        Me.CmbMotivo.Size = New System.Drawing.Size(216, 21)
        Me.CmbMotivo.TabIndex = 4
        '
        'TxtTicket
        '
        Me.TxtTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTicket.Location = New System.Drawing.Point(60, 47)
        Me.TxtTicket.Name = "TxtTicket"
        Me.TxtTicket.Size = New System.Drawing.Size(192, 21)
        Me.TxtTicket.TabIndex = 1
        '
        'BtnBuscaFactura
        '
        Me.BtnBuscaFactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaFactura.Image = CType(resources.GetObject("BtnBuscaFactura.Image"), System.Drawing.Image)
        Me.BtnBuscaFactura.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaFactura.Location = New System.Drawing.Point(257, 46)
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
        Me.Label1.Location = New System.Drawing.Point(6, 52)
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
        Me.TxtVendedor.Location = New System.Drawing.Point(83, 134)
        Me.TxtVendedor.Multiline = True
        Me.TxtVendedor.Name = "TxtVendedor"
        Me.TxtVendedor.ReadOnly = True
        Me.TxtVendedor.Size = New System.Drawing.Size(380, 19)
        Me.TxtVendedor.TabIndex = 3
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(7, 136)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(46, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Atendio"
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
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(7, 202)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(778, 331)
        Me.GrpDetalle.TabIndex = 3
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
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
        Me.GridDetalle.Location = New System.Drawing.Point(7, 19)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(765, 305)
        Me.GridDetalle.TabIndex = 2
        Me.GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridDetalle.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.GridDetalle.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TxtObservacion
        '
        Me.TxtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtObservacion.Location = New System.Drawing.Point(83, 160)
        Me.TxtObservacion.Name = "TxtObservacion"
        Me.TxtObservacion.Size = New System.Drawing.Size(380, 21)
        Me.TxtObservacion.TabIndex = 96
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 15)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Observación"
        '
        'GrpCliente
        '
        Me.GrpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCliente.Controls.Add(Me.TxtRFC)
        Me.GrpCliente.Controls.Add(Me.Label3)
        Me.GrpCliente.Controls.Add(Me.LstDomicilio)
        Me.GrpCliente.Controls.Add(Me.TxtObservacion)
        Me.GrpCliente.Controls.Add(Me.lblRFC)
        Me.GrpCliente.Controls.Add(Me.Label11)
        Me.GrpCliente.Controls.Add(Me.TxtRazonSocial)
        Me.GrpCliente.Controls.Add(Me.Label2)
        Me.GrpCliente.Controls.Add(Me.TxtClave)
        Me.GrpCliente.Controls.Add(Me.TxtVendedor)
        Me.GrpCliente.Controls.Add(Me.LblNombre)
        Me.GrpCliente.Location = New System.Drawing.Point(7, 4)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(472, 192)
        Me.GrpCliente.TabIndex = 2
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "Datos Cliente"
        '
        'TxtRFC
        '
        Me.TxtRFC.Enabled = False
        Me.TxtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRFC.Location = New System.Drawing.Point(305, 15)
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
        Me.LstDomicilio.Location = New System.Drawing.Point(5, 74)
        Me.LstDomicilio.Name = "LstDomicilio"
        Me.LstDomicilio.Size = New System.Drawing.Size(458, 49)
        Me.LstDomicilio.TabIndex = 92
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(219, 20)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(34, 15)
        Me.lblRFC.TabIndex = 91
        Me.lblRFC.Text = "RFC"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(3, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 20)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Razón Social"
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(83, 45)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(382, 21)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Enabled = False
        Me.TxtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave.Location = New System.Drawing.Point(83, 15)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.ReadOnly = True
        Me.TxtClave.Size = New System.Drawing.Size(113, 21)
        Me.TxtClave.TabIndex = 3
        '
        'ChkDevolver
        '
        Me.ChkDevolver.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkDevolver.Location = New System.Drawing.Point(12, 547)
        Me.ChkDevolver.Name = "ChkDevolver"
        Me.ChkDevolver.Size = New System.Drawing.Size(158, 22)
        Me.ChkDevolver.TabIndex = 115
        Me.ChkDevolver.Text = "Devolver Todos"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(6, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 14)
        Me.Label4.TabIndex = 115
        Me.Label4.Text = "Uso"
        '
        'cmbUsoCFDI
        '
        Me.cmbUsoCFDI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbUsoCFDI.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUsoCFDI.ItemHeight = 13
        Me.cmbUsoCFDI.Location = New System.Drawing.Point(77, 162)
        Me.cmbUsoCFDI.Name = "cmbUsoCFDI"
        Me.cmbUsoCFDI.Size = New System.Drawing.Size(216, 21)
        Me.cmbUsoCFDI.TabIndex = 114
        '
        'FrmNC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.ChkDevolver)
        Me.Controls.Add(Me.GrpCliente)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmNC"
        Me.Text = "Nota de Crédito"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        Me.GrpDetalle.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public AplicaReembolso As Boolean = True
    Private fechaPath As Date
    Public SeleccionaCaja As Boolean = False
    Public bLiquidacion As Boolean = False
    Public Facturas() As DataRow

    Public ALMClave As String
    Public SUCClave As String
    Public CAJClave As String

    Public Cajon As Boolean = False
    Public PrinterName As String = ""

    Private Autoriza, Atendio, InterfazSalida As String
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
    Private Impresora, Stage As String

    Private CajaLoad As Boolean = False
    Private dtPAC, dt, dtDetalle, dtImpuestodet As DataTable
    Private folioFactura, FacturaID As String
    Private fechaFactura As DateTime

    Private dtConcepto, dtImpuesto, dtDetalleImpuesto, dtRetencionDet, dtRetencion As DataTable

    Private PathPDF, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP As String
    Private MailPort As Integer
    Private MailSSL As Boolean

    Private PathXML As String

    '  Private disponible As Double

    Private TotalFactura As Double
    Private SubtotalFactura As Double
    Private ImpuestoFactura As Double

    Private CostoTotal As Decimal
    Private SubtotalNC As Decimal
    Private DescuentoNC As Decimal
    Private ImpuestoNC As Decimal
    Private TotalNC As Decimal

    Private PorcDesc As Double
    Private SaldoFactura As Double
    'Private Vencimiento As DateTime
    'Private Credito As Integer

    Private FormatNC As String


    Private correo As MailMessage
    Private adjuntos As Attachment
    Private autenticar As NetworkCredential
    Private envio As SmtpClient
    Private dato As FileStream
    Private sFolio As String

    Private iTipoPAC As Integer = 0
    Private Folio As String
    Private dtBloqueados As DataTable
    Private iRegimenFiscal As Integer



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
        Stage = IIf(dt.Rows(0)("Stage").GetType.Name = "DBNull", "", dt.Rows(0)("Stage"))
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
            oCFD.ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))

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

            Dim formaPago As String

            Dim TipoCF_fac As Integer = dtFactura.Rows(0)("TipoCF")
            Dim Estado_fac As Integer = dtFactura.Rows(0)("Estado")

            FacturaID = dtFactura.Rows(0)("FacturaID")
            folioFactura = CStr(dtFactura.Rows(0)("Serie")) & CStr(dtFactura.Rows(0)("Folio"))
            fechaFactura = CDate(dtFactura.Rows(0)("fechaFactura"))
            FACClave = dtFactura.Rows(0)("FACClave")
            SaldoFactura = dtFactura.Rows(0)("Saldo")
            SubtotalFactura = dtFactura.Rows(0)("Subtotal")
            ImpuestoFactura = dtFactura.Rows(0)("ImpuestoTot")
            TotalFactura = dtFactura.Rows(0)("Total")
            oCFD.CTEClave = dtFactura.Rows(0)("CTEClave")
            Moneda = IIf(dtFactura.Rows(0)("MONClave").GetType.Name = "DBNull", Moneda, dtFactura.Rows(0)("MONClave"))
            Atendio = IIf(dtFactura.Rows(0)("Vendio").GetType.Name = "DBNull", "", dtFactura.Rows(0)("Vendio"))

            formaPago = IIf(dtFactura.Rows(0)("formaDePago").GetType.Name = "DBNull", "Pago en una sola exhibición", dtFactura.Rows(0)("formaDePago"))

            oCFD.formaDePago = formaPago

            If oCFD.VersionCF = "3.3" Then
                oCFD.formaDePago = "PUE"
                oCFD.CondicionesDePago = "Contado"
            End If

            dtFactura.Dispose()

            If Atendio <> "" Then
                dtFactura = ModPOS.Recupera_Tabla("sp_recupera_UsuarioActual", "@Usuario", Atendio)
                TxtVendedor.Text = dtFactura.Rows(0)("Nombre")
                dtFactura.Dispose()
            Else
                TxtVendedor.Text = ""
            End If


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


            TxtTotalFac.Text = CStr(TruncateToDecimal(TotalFactura, 2))

            CargaDatosCliente(oCFD.CTEClave)

            If Not dtDetalle Is Nothing Then
                dtDetalle.Dispose()
            End If

            dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_nc", "@FACClave", FACClave)
            GridDetalle.DataSource = dtDetalle
            GridDetalle.RetrieveStructure()
            GridDetalle.AutoSizeColumns()
            GridDetalle.RootTable.Columns("DFAClave").Visible = False
            GridDetalle.CurrentTable.Columns("Fact.").Selectable = False
            GridDetalle.CurrentTable.Columns("Disp.").Selectable = False

            GridDetalle.RootTable.Columns("PROClave").Visible = False
            GridDetalle.CurrentTable.Columns("Clave").Selectable = False
            GridDetalle.CurrentTable.Columns("Nombre").Selectable = False
            GridDetalle.RootTable.Columns("Costo").Visible = False
            GridDetalle.CurrentTable.Columns("Precio Unitario").Selectable = False
            GridDetalle.RootTable.Columns("PorcDesc").Visible = False
            GridDetalle.RootTable.Columns("PorcImp").Visible = False
            GridDetalle.RootTable.Columns("CostoTotal").Visible = False
            GridDetalle.RootTable.Columns("Subtotal").Selectable = False
            GridDetalle.CurrentTable.Columns("Descuento").Selectable = False
            GridDetalle.RootTable.Columns("Impuesto").Selectable = False
            GridDetalle.RootTable.Columns("Total").Selectable = False

            GridDetalle.RootTable.Columns("PuntosImp").Visible = False
            GridDetalle.RootTable.Columns("Seguimiento").Visible = False
            GridDetalle.RootTable.Columns("DiasGarantia").Visible = False
            GridDetalle.RootTable.Columns("TProducto").Visible = False
            GridDetalle.RootTable.Columns("PartidaFactura").Visible = False
            GridDetalle.RootTable.Columns("Num_Decimales").Visible = False
            GridDetalle.RootTable.Columns("Fact.").FormatString = "0.00"
            GridDetalle.RootTable.Columns("Disp.").FormatString = "0.00"
            GridDetalle.RootTable.Columns("Dev.").FormatString = "0.00"

            GridDetalle.RootTable.Columns("Precio Unitario").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Subtotal").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Descuento").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Impuesto").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far


            dtImpuestodet = ModPOS.Recupera_Tabla("sp_impuestos_nc", "@FACClave", FACClave)

            GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
            GridDetalle.RootTable.Columns("Subtotal").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            GridDetalle.RootTable.Columns("Descuento").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            GridDetalle.RootTable.Columns("Impuesto").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            GridDetalle.RootTable.Columns("Total").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum


            GridDetalle.RootTable.Columns("Subtotal").TotalFormatString = "c"
            GridDetalle.RootTable.Columns("Descuento").TotalFormatString = "c"
            GridDetalle.RootTable.Columns("Impuesto").TotalFormatString = "c"
            GridDetalle.RootTable.Columns("Total").TotalFormatString = "c"

        Else
            MessageBox.Show("No se encontro documento o se encuentra cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub FrmNC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        oCFD = New CFD

        NCClave = ModPOS.obtenerLlave

        With Me.CmbMotivo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "NC"
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

        If CAJClave <> "" Then
            CmbCaja.SelectedValue = CAJClave
            CmbCaja.Enabled = SeleccionaCaja
        End If

        With cmbUsoCFDI
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_UsoCFDI"
            .NombreParametro1 = "Grupo"
            .Parametro1 = 2
            .llenar()
        End With

        CajaLoad = True

        Dim dtParam As DataTable
        Dim dtmsg As DataTable
        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave ", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "LineasNC"
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
                    Case "FormatNC"
                        FormatNC = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
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
            oCFD.tipoDeComprobante = "E"
            oCFD.CondicionesDePago = ""
        Else
            oCFD.tipoDeComprobante = "egreso"
        End If

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


        LstDomicilio.Items.Clear()
        TxtTicket.Focus()

      

        If Not Facturas Is Nothing AndAlso Facturas.GetLength(0) = 1 Then
            Me.CargaDatosFactura(Facturas(0)("ID"), 1)
            TxtTicket.Text = Facturas(0)("Folio")
        End If



        dtBloqueados = ModPOS.CrearTabla("Bloqueados", _
                                               "PROClave", "System.String", _
                                               "Bloquear", "System.Double")


    End Sub

    Private Sub FrmNC_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoNC Is Nothing Then
            If Not ModPOS.MtoNC.CmbSucursal.SelectedValue Is Nothing AndAlso ModPOS.MtoNC.Periodo > 0 AndAlso ModPOS.MtoNC.Mes > 0 Then
                ModPOS.MtoNC.refrescaGrid()
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


        ModPOS.NC.Dispose()
        ModPOS.NC = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
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
        If GridDetalle.CurrentColumn.Caption = "Dev." Then
            If IsNumeric(GridDetalle.GetValue("Dev.")) Then
                If GridDetalle.GetValue("Disp.") >= Math.Abs(GridDetalle.GetValue("Dev.")) Then
                    Dim Subtotal, IVAtotal, Desctotal, Costo, Total, Cant As Decimal

                    Cant = Math.Round(Math.Abs(GridDetalle.GetValue("Dev.")), GridDetalle.GetValue("Num_Decimales"))

                    Costo = Math.Round(Cant * GridDetalle.GetValue("Costo"), 2)
                    Subtotal = Math.Round(Cant * GridDetalle.GetValue("Precio Unitario"), 2)
                    Desctotal = Math.Round(GridDetalle.GetValue("PorcDesc") * Subtotal, 2)
                    IVAtotal = Math.Round(GridDetalle.GetValue("PorcImp") * (Subtotal - Desctotal), 2)
                    Total = Subtotal - Desctotal + IVAtotal

                    GridDetalle.SetValue("Dev.", Cant)
                    GridDetalle.SetValue("CostoTotal", Costo)
                    GridDetalle.SetValue("Subtotal", Subtotal)
                    GridDetalle.SetValue("Descuento", Desctotal)
                    GridDetalle.SetValue("Impuesto", IVAtotal)
                    GridDetalle.SetValue("Total", Total)

                    dtDetalle.AcceptChanges()

                    GridDetalle.Refresh()
                Else
                    Beep()
                    MessageBox.Show("¡La cantidad a devolver no puede ser mayor al disponible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Dev.", 0)
                    GridDetalle.SetValue("Subtotal", 0)
                    GridDetalle.SetValue("Descuento", 0)
                    GridDetalle.SetValue("Impuesto", 0)
                    GridDetalle.SetValue("Total", 0)
                    GridDetalle.SetValue("CostoTotal", 0)
                    dtDetalle.AcceptChanges()

                    GridDetalle.Refresh()
                End If
            Else
                GridDetalle.SetValue("Dev.", 0)
                GridDetalle.SetValue("Subtotal", 0)
                GridDetalle.SetValue("Descuento", 0)
                GridDetalle.SetValue("Impuesto", 0)
                GridDetalle.SetValue("Total", 0)
                GridDetalle.SetValue("CostoTotal", 0)
                dtDetalle.AcceptChanges()

                GridDetalle.Refresh()
            End If


          


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

    Private Function crearCF(ByVal NCClave As String) As Boolean



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

        dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_conceptonc", "@Clave", NCClave)
        dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_impuestosnc", "@Clave", NCClave)


        oCFD.Serie = dt.Rows(0)("Serie")
        oCFD.Folio = dt.Rows(0)("Folio")

        sFolio = oCFD.Serie & oCFD.Folio

        oCFD.descuento = IIf(dt.Rows(0)("DescuentoTot").GetType.ToString = "System.DBNull", 0, dt.Rows(0)("DescuentoTot"))

        oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dt.Rows(0)("fecha"))

        fechaPath = CDate(oCFD.Fecha)

        'oCFD.extra = TxtExtra.Text
        oCFD.Moneda = MonedaRef
        oCFD.TipoCambio = TipoCambio

        If oCFD.TipoCF <= 2 Then

            oCFD.DOCClave = NCClave

            If oCFD.VersionCF = "3.3" Then
                dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_det", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", 7, "@Clave", oCFD.DOCClave)
            End If


            If oCFD.TipoCF = 1 Then
                oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
            Else
                oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, 7, dtDetalleImpuesto, dtRetencionDet, dtRetencion)
            End If

            oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)



            iTipoPAC = crearXML(1, dtPAC, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, 7, InterfazSalida, dtDetalleImpuesto, dtRetencionDet, dtRetencion)

        Else
            actualizaEdoCFD(oCFD.tipoDeComprobante, oCFD.DOCClave, 1, 7)
        End If


        dt.Dispose()
        dtConcepto.Dispose()
        dtImpuesto.Dispose()

        Return True
    End Function

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        BtnGuardar.Enabled = False


        ' Dim Efectivo As Double

        If dtDetalle Is Nothing OrElse dtDetalle.Rows.Count = 0 Then
            MessageBox.Show("Debe seleccionar una Factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnGuardar.Enabled = True
            Exit Sub
        End If

        If Not CmbCaja.SelectedValue Is Nothing Then
            CAJClave = CmbCaja.SelectedValue
        Else
            MessageBox.Show("Debe seleccionar una Caja valida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnGuardar.Enabled = True
            Exit Sub
        End If

        If cmbUsoCFDI.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar una opcion Uso del Comprobante", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnGuardar.Enabled = True
            Exit Sub
        End If

        oCFD.UsoCFDI = cmbUsoCFDI.SelectedValue
        oCFD.tipoNC = 1

        'Nota de Crédito por Devolución
        If Not dtDetalle Is Nothing Then
            Dim i As Integer
            Dim foundRows() As DataRow
            Dim foundImp() As DataRow

            foundRows = dtDetalle.Select("[Dev.] > 0 and [Disp.] >= [Dev.]")

            If foundRows.GetLength(0) > 0 Then

               

                Dim NumNC As Integer


                SubtotalNC = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                DescuentoNC = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Descuento"), Janus.Windows.GridEX.AggregateFunction.Sum)
                ImpuestoNC = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)
                TotalNC = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)
                CostoTotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("CostoTotal"), Janus.Windows.GridEX.AggregateFunction.Sum)

                Dim a As New MeAutorizacion
                a.Sucursal = SUCClave
                a.MontodeAutorizacion = CDbl(TotalNC)
                a.StartPosition = FormStartPosition.CenterScreen
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.Autorizado Then
                        a.Dispose()
                        BtnGuardar.Enabled = True
                        Exit Sub
                        Autoriza = a.Autoriza
                    End If
                ElseIf a.DialogResult = DialogResult.Cancel Then
                    a.Dispose()
                    BtnGuardar.Enabled = True
                    Exit Sub
                End If
                a.Dispose()

                NumNC = Int(foundRows.GetLength(0) / MaxRow)

                Dim EstadoUBC, EstadoPEU As Integer

                If Stage <> "" Then

                    Dim dtU As DataTable = ModPOS.Recupera_Tabla("sp_recupera_ubicacion", "@UBCClave", Stage)
                    If dtU.Rows.Count > 0 Then
                        EstadoUBC = CInt(dtU.Rows(0)("Estado"))
                    Else
                        dtU.Dispose()
                        MessageBox.Show("No se encontro la ubicación del almacén para realizar las cancelaciones y devoluciones de productos", "Error", MessageBoxButtons.OK)
                        BtnGuardar.Enabled = True
                        Exit Sub
                    End If
                    dtU.Dispose()
                End If


                If Not recuperaFolio(CAJClave, NumNC) Then
                    BtnGuardar.Enabled = True
                    Exit Sub
                End If

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


                ModPOS.Ejecuta("sp_crea_nc", _
                "@NCClave", NCClave, _
                "@FACClave", FACClave, _
                "@folioFactura", folioFactura, _
                "@fechaFactura", fechaFactura, _
                "@CTEClave", oCFD.CTEClave, _
                "@TipoCF", oCFD.TipoCF, _
                "@VersionCF", oCFD.VersionCF, _
                "@RegimenFiscal", oCFD.regimenFiscal, _
                "@Serie", oCFD.Serie, _
                "@Folio", oCFD.Folio, _
                "@CAJClave", CAJClave, _
                "@Atendio", Atendio, _
                "@fechaAprobacion", oCFD.fechaAprobacion, _
                "@formaDePago", oCFD.formaDePago, _
                "@Motivo", CmbMotivo.SelectedValue, _
                "@Observacion", TxtObservacion.Text, _
                "@Costo", CostoTotal, _
                "@Subtotal", SubtotalNC, _
                "@ImpuestoTot", ImpuestoNC, _
                "@DescuentoTot", DescuentoNC, _
                "@Total", TotalNC, _
                "@tipoCertificado", oCFD.tipoDeComprobante, _
                "@Tipo", 1, _
                "@MONClave", Moneda, _
                "@TipoCambio", TipoCambio, _
                "@UsoCFDI", oCFD.UsoCFDI, _
                "@Usuario", ModPOS.UsuarioActual)

                Dim DNCClave As String
                Dim Referencia As String = NCClave
                Dim CambioEstado As Boolean = False
                dtBloqueados.Clear()


                For i = 0 To foundRows.GetUpperBound(0)
                    ModPOS.Ejecuta("sp_actualiza_cantdev", "@Tipo", 2, "@Documento", FACClave, "@Partida", foundRows(i)("DFAClave"), "@Cantidad", foundRows(i)("Dev."))

                    DNCClave = ModPOS.obtenerLlave

                    ModPOS.Ejecuta("sp_inserta_ncdetalle", _
                                    "@DNCClave", DNCClave, _
                                    "@NCClave", NCClave, _
                                    "@Partida", (i + 1) * 10, _
                                    "@PROClave", foundRows(i)("PROClave"), _
                                    "@TProducto", foundRows(i)("TProducto"), _
                                    "@Costo", foundRows(i)("Costo"), _
                                    "@Precio", foundRows(i)("Precio Unitario"), _
                                    "@Subtotal", foundRows(i)("Subtotal"), _
                                    "@Cantidad", foundRows(i)("Dev."), _
                                    "@Descuento", foundRows(i)("Descuento"), _
                                    "@Impuesto", foundRows(i)("Impuesto"), _
                                    "@Total", foundRows(i)("Total"), _
                                    "@Puntos", foundRows(i)("PuntosImp"), _
                                    "@PartidaFactura", foundRows(i)("PartidaFactura"))


                    If foundRows(i)("TProducto") = 4 AndAlso oCFD.eTPersona = 1 AndAlso oCFD.TPersona = 2 Then
                        'Calcula retencion
                        ModPOS.calculaRetencion("N", DNCClave, foundRows(i)("PROClave"), foundRows(i)("Subtotal") - foundRows(i)("Descuento"), oCFD.TImpuesto, SUCClave)

                    End If

                    'SI REQUIERE SEGUIMIENTO DE SERIAL
                    If foundRows(i)("Seguimiento") = 2 Then
                        Dim SerialReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = foundRows(i)("Dev.")
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
                        Loop Until SerialReg = foundRows(i)("Dev.") OrElse PorRegistrar = 0
                    End If

                    'SI REQUIERE SEGUIMIENTO DE LOTE
                    If foundRows(i)("Seguimiento") = 3 Then
                        Dim LoteReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = foundRows(i)("Dev.")
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
                        Loop Until LoteReg = foundRows(i)("Dev.") OrElse PorRegistrar = 0
                    End If


                    foundImp = dtImpuestodet.Select("DFAClave = '" & foundRows(i)("DFAClave") & "'")

                    If foundImp.GetLength(0) > 0 Then
                        Dim y As Integer

                        For y = 0 To foundImp.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_inserta_ncimpuesto", _
                                            "@DNCClave", DNCClave, _
                                            "@IMPClave", foundImp(y)("IMPClave"), _
                                            "@Base", foundImp(y)("Base") * foundRows(i)("Dev."), _
                                            "@PorcImp", foundImp(y)("PorcImp"), _
                                            "@Importe", foundImp(y)("Importe") * foundRows(i)("Dev."), _
                                            "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If

                    If Stage <> "" Then
                        dt = Recupera_Tabla("st_recupera_peu", "@PROClave", foundRows(i)("PROClave"), "@UBCClave", Stage)
                        If dt.Rows.Count = 1 Then
                            EstadoPEU = CInt(dt.Rows(0)("Estado"))
                            If CDbl(dt.Rows(0)("Existencia")) <= 0 Then
                                EstadoPEU = EstadoUBC
                            End If
                        Else
                            EstadoPEU = EstadoUBC
                        End If
                        dt.Dispose()

                        If 1 <> EstadoPEU Then


                            Dim row1 As DataRow
                            row1 = dtBloqueados.NewRow()
                            'declara el nombre de la fila
                            row1.Item("PROClave") = foundRows(i)("PROClave")
                            row1.Item("Bloquear") = foundRows(i)("Dev.")
                            dtBloqueados.Rows.Add(row1)

                            CambioEstado = True
                        End If

                    End If

                Next
                dtDetalle.Dispose()

                ModPOS.GeneraMovInv(1, 3, 4, NCClave, ALMClave, oCFD.Serie & oCFD.Folio, Autoriza)
                ModPOS.ActualizaExistAlm(1, 4, NCClave, ALMClave)

                If Stage = "" Then
                    ModPOS.ActualizaExistUbc(1, 4, NCClave, ALMClave)
                Else
                    ModPOS.ActualizaExistUbc(1, 4, NCClave, ALMClave, Stage)





                    If CambioEstado = True AndAlso InterfazSalida <> "" Then

                        For i = 0 To dtBloqueados.Rows.Count - 1

                            ModPOS.Ejecuta("st_act_bloqueado_ubc", _
                                       "@UBCClave", Stage, _
                                       "@PROClave", dtBloqueados.Rows(i)("PROClave"), _
                                       "@Cantidad", dtBloqueados.Rows(i)("Bloquear"))

                            ModPOS.Ejecuta("st_cambio_estado", _
                                        "@SUCClave", SUCClave, _
                                        "@ALMClave", ALMClave, _
                                        "@UBCClave", Stage, _
                                        "@PROClave", dtBloqueados.Rows(i)("PROClave"), _
                                        "@Cantidad", dtBloqueados.Rows(i)("Bloquear"), _
                                        "@Estado", EstadoPEU, _
                                        "@Referencia", Referencia, _
                                        "@Actualiza", 1, _
                                        "@Usuario", ModPOS.UsuarioActual)

                        Next



                    End If

                End If

                'Agregar el actualizar saldo de NC

                If oCFD.eTPersona = 1 AndAlso oCFD.TPersona = 2 Then
                    Dim dRetenciones As Decimal = 0
                    dtRetencion = ModPOS.Recupera_Tabla("st_recupera_retenciones", "@TipoComprobante", "E", "@Tipo", 7, "@Clave", NCClave)
                    dtRetencionDet = ModPOS.Recupera_Tabla("st_recupera_retencion_det", "@TipoComprobante", "E", "@Tipo", 7, "@Clave", NCClave)
                    If dtRetencion.Rows.Count > 0 Then
                        dRetenciones = dtRetencion.Compute("SUM(Importe)", "NCClave = '" & NCClave & "'")

                        TotalNC -= dRetenciones

                        ModPOS.Ejecuta("st_aplica_retencion", "@Clave", NCClave, "@Tipo", "N", "@Retencion", dRetenciones)
                    End If
                End If


                Dim dReembolso, dAplicar As Double
                If TruncateToDecimal(SaldoFactura, 2) > 0 Then
                    If TruncateToDecimal(SaldoFactura, 2) >= TruncateToDecimal(TotalNC, 2) Then
                        ModPOS.Ejecuta("sp_actualiza_saldo_doc", "@Tipo", 2, "@Documento", FACClave, "@Importe", TotalNC)
                        dReembolso = 0
                        dAplicar = TotalNC
                    Else
                        ModPOS.Ejecuta("sp_actualiza_saldo_doc", "@Tipo", 2, "@Documento", FACClave, "@Importe", TotalNC - SaldoFactura)
                        dReembolso = TruncateToDecimal(TotalNC - SaldoFactura, 2)
                        dAplicar = SaldoFactura
                    End If
                    ModPOS.Ejecuta("sp_vincula_fac", "@NCClave", NCClave, "@FACClave", FACClave, "@Importe", dAplicar, "@CAJClave", CAJClave, "@Usuario", ModPOS.UsuarioActual)
                Else
                    dReembolso = TruncateToDecimal(TotalNC, 2)
                End If


                ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", oCFD.CTEClave, "@Importe", TotalNC)


                If dReembolso > 0 AndAlso AplicaReembolso = True Then
                    Select Case MessageBox.Show("¿Desea aplicar un reembolso por " & Format(CStr(TruncateToDecimal(dReembolso, 2)), "Currency") & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            ModPOS.Ejecuta("st_aplica_reembolso", _
                                           "@CTEClave", oCFD.CTEClave, _
                                           "@DOCClave", NCClave, _
                                           "@TipoDocumento", 4, _
                                           "@CAJClave", CAJClave, _
                                           "@Moneda", Moneda, _
                                           "@TipoCambio", TipoCambio, _
                                           "@Saldo", dReembolso, _
                                           "@Usuario", ModPOS.UsuarioActual)
                            If Cajon = True Then
                                AbrirCajon(PrinterName)
                            End If
                    End Select
                End If

                Dim j As Integer

                Dim sMetodoPago, sBanco, sReferencia, sSAT As String

                oCFD.metodoDePago = ""
                oCFD.NumCtaPago = ""


                Dim dtMetodosPago As DataTable = ModPOS.Recupera_Tabla("st_recupera_metodospago_fac", "@FacturaID", FacturaID)

                Dim frMetodoPagos() As System.Data.DataRow

                Dim foundRows1() As System.Data.DataRow
                foundRows1 = dtMetodosPago.Select()
                frMetodoPagos = foundRows1
                'End If
                dtMetodosPago.Dispose()

                For j = 0 To frMetodoPagos.GetUpperBound(0)

                    sMetodoPago = IIf(frMetodoPagos(j)("Tipo").GetType.Name = "DBNull", "", frMetodoPagos(j)("Tipo"))
                    sBanco = IIf(frMetodoPagos(j)("Banco").GetType.Name = "DBNull", "", frMetodoPagos(j)("Banco"))
                    sReferencia = IIf(frMetodoPagos(j)("Referencia").GetType.Name = "DBNull", "", CStr(frMetodoPagos(j)("Referencia")).Trim.ToUpper)
                    sSAT = IIf(frMetodoPagos(j)("SAT").GetType.Name = "DBNull", "99", frMetodoPagos(j)("SAT"))



                    ModPOS.Ejecuta("sp_agregar_metodopagonc", _
                    "@NCClave", Me.NCClave, _
                    "@MetodoPago", sMetodoPago, _
                    "@Banco", sBanco, _
                    "@SAT", sSAT, _
                    "@Referencia", sReferencia)

                    If oCFD.VersionCF <> "3.3" Then
                        If j > 0 Then
                            oCFD.metodoDePago &= ", "
                            If oCFD.NumCtaPago <> "" AndAlso sReferencia <> "" Then
                                oCFD.NumCtaPago &= ", "
                            End If
                        End If

                        oCFD.metodoDePago &= sSAT
                        oCFD.NumCtaPago &= sReferencia
                    ElseIf oCFD.metodoDePago = "" And sSAT <> "" Then
                        oCFD.metodoDePago = sSAT
                        If sReferencia <> "" AndAlso oCFD.NumCtaPago = "" Then
                            oCFD.NumCtaPago = sReferencia
                        End If
                        Exit For
                    End If

                Next


                Folio = oCFD.Serie & CStr(oCFD.Folio)
                oCFD.total = TotalNC
                MessageBox.Show("Se genero la nota de crédito " & Folio, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)


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

                        Dim sImpresora As String
                        Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", Impresora)
                        sImpresora = dtPrinter.Rows(0)("Referencia")
                        dtPrinter.Dispose()

                        imprimirNC(oCFD.TipoCF, FormatNC, NCClave, TotalNC, SUCClave, TipoCambio, MonedaDesc, MonedaRef, sImpresora, 1, oCFD.VersionCF)

                End Select

               

                If oCFD.email.Trim <> "" Then
                    Select Case MessageBox.Show("¿Desea enviar el documento por correo electrónico?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            ModPOS.SendMailNC(oCFD.VersionCF, oCFD.email, oCFD.TipoCF, FormatNC, CDate(oCFD.Fecha), sFolio, NCClave, TotalNC, MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonedaDesc, MonedaRef, True)

                    End Select
                End If



                If Not Facturas Is Nothing AndAlso Facturas.GetLength(0) = 1 AndAlso Not ModPOS.Liquid Is Nothing Then
                    ModPOS.Liquid.ActualizaGridTransac()
                End If

                Me.Close()

            Else
                MessageBox.Show("Debe indicar una cantidad a devolver mayor o igual al disponible", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BtnGuardar.Enabled = True
            End If
        Else
            MessageBox.Show("Debe ingresar el folio completo de la factura y presionar Enter", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnGuardar.Enabled = True
        End If
    End Sub

    Private Sub ChkDevolver_CheckedChanged(sender As Object, e As EventArgs) Handles ChkDevolver.CheckedChanged
        If GridDetalle.RowCount > 0 Then
            Dim i As Integer

            If ChkDevolver.Checked Then
                For i = 0 To GridDetalle.GetDataRows.Length - 1
                    GridDetalle.GetDataRows(i).DataRow("Dev.") = GridDetalle.GetDataRows(i).DataRow("Disp.")

                    Dim Subtotal, IVAtotal, Desctotal, Costo, Total As Double
                    Costo = Math.Round(Math.Abs(CDbl(GridDetalle.GetDataRows(i).DataRow("Disp."))) * GridDetalle.GetDataRows(i).DataRow("Costo"), 2)
                    Subtotal = Math.Round(Math.Abs(CDbl(GridDetalle.GetDataRows(i).DataRow("Disp."))) * GridDetalle.GetDataRows(i).DataRow("Precio Unitario"), 2)
                    Desctotal = Math.Round(GridDetalle.GetDataRows(i).DataRow("PorcDesc") * Subtotal, 2)
                    IVAtotal = Math.Round(GridDetalle.GetDataRows(i).DataRow("PorcImp") * (Subtotal - Desctotal), 2)
                    Total = Subtotal - Desctotal + IVAtotal

                    GridDetalle.GetDataRows(i).DataRow("CostoTotal") = Costo
                    GridDetalle.GetDataRows(i).DataRow("Subtotal") = Subtotal
                    GridDetalle.GetDataRows(i).DataRow("Descuento") = Desctotal
                    GridDetalle.GetDataRows(i).DataRow("Impuesto") = IVAtotal
                    GridDetalle.GetDataRows(i).DataRow("Total") = Total
                Next
            Else
                For i = 0 To GridDetalle.GetDataRows.Length - 1
                    GridDetalle.GetDataRows(i).DataRow("Dev.") = 0
                    GridDetalle.GetDataRows(i).DataRow("CostoTotal") = 0
                    GridDetalle.GetDataRows(i).DataRow("Subtotal") = 0
                    GridDetalle.GetDataRows(i).DataRow("Descuento") = 0
                    GridDetalle.GetDataRows(i).DataRow("Impuesto") = 0
                    GridDetalle.GetDataRows(i).DataRow("Total") = 0
                Next
            End If
            dtDetalle.AcceptChanges()
            GridDetalle.Refresh()


         

        End If
    End Sub
End Class
