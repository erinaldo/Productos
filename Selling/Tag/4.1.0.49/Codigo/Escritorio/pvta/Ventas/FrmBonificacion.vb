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

Public Class FrmBonificacion
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LstDomicilio As System.Windows.Forms.ListBox
    Friend WithEvents TxtRFC As System.Windows.Forms.TextBox
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAbrir As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents CtxDocumentos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnTC As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtClaveProd As System.Windows.Forms.TextBox
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbMotivo As Selling.StoreCombo
    Friend WithEvents GrpSinAsignar As System.Windows.Forms.GroupBox
    Friend WithEvents btnDevolucion As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtFactura As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscaFactura As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAdd As Janus.Windows.EditControls.UIButton
    Friend WithEvents gridFacturas As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPorcentaje As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUsoCFDI As Selling.StoreCombo
    Friend WithEvents CmbCaja As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBonificacion))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNota = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnTC = New Janus.Windows.EditControls.UIButton()
        Me.CtxDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.txtPorcentaje = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAdd = New Janus.Windows.EditControls.UIButton()
        Me.BtnDel = New Janus.Windows.EditControls.UIButton()
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.TxtClaveProd = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GrpCliente = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbUsoCFDI = New Selling.StoreCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbMotivo = New Selling.StoreCombo()
        Me.LblTipoCambio = New System.Windows.Forms.Label()
        Me.TxtBusqueda = New System.Windows.Forms.TextBox()
        Me.CmbCaja = New Selling.StoreCombo()
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
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.gridFacturas = New Janus.Windows.GridEX.GridEX()
        Me.btnDevolucion = New Janus.Windows.EditControls.UIButton()
        Me.TxtFactura = New System.Windows.Forms.TextBox()
        Me.btnBuscaFactura = New Janus.Windows.EditControls.UIButton()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCliente.SuspendLayout()
        Me.GrpSinAsignar.SuspendLayout()
        CType(Me.gridFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(6, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 15)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Nota"
        '
        'TxtNota
        '
        Me.TxtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtNota.Location = New System.Drawing.Point(83, 180)
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(379, 21)
        Me.TxtNota.TabIndex = 115
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(558, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Moneda"
        '
        'BtnTC
        '
        Me.BtnTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTC.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.BtnTC.ContextMenuStrip = Me.CtxDocumentos
        Me.BtnTC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTC.Enabled = False
        Me.BtnTC.Location = New System.Drawing.Point(615, 42)
        Me.BtnTC.Name = "BtnTC"
        Me.BtnTC.Size = New System.Drawing.Size(157, 23)
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
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Location = New System.Drawing.Point(558, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 15)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Caja"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(599, 540)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 29)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 540)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 29)
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
        Me.GrpDetalle.Controls.Add(Me.txtPorcentaje)
        Me.GrpDetalle.Controls.Add(Me.Label7)
        Me.GrpDetalle.Controls.Add(Me.btnAdd)
        Me.GrpDetalle.Controls.Add(Me.BtnDel)
        Me.GrpDetalle.Controls.Add(Me.BtnBuscaProd)
        Me.GrpDetalle.Controls.Add(Me.TxtDescripcion)
        Me.GrpDetalle.Controls.Add(Me.TxtClaveProd)
        Me.GrpDetalle.Controls.Add(Me.PictureBox2)
        Me.GrpDetalle.Controls.Add(Me.TxtImporte)
        Me.GrpDetalle.Controls.Add(Me.PictureBox1)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Controls.Add(Me.Label4)
        Me.GrpDetalle.Controls.Add(Me.Label9)
        Me.GrpDetalle.Enabled = False
        Me.GrpDetalle.Location = New System.Drawing.Point(173, 218)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(612, 316)
        Me.GrpDetalle.TabIndex = 3
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.DecimalDigits = 6
        Me.txtPorcentaje.Location = New System.Drawing.Point(83, 44)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(126, 20)
        Me.txtPorcentaje.TabIndex = 1
        Me.txtPorcentaje.Text = "0.000000"
        Me.txtPorcentaje.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPorcentaje.Value = 0.0R
        Me.txtPorcentaje.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(6, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 15)
        Me.Label7.TabIndex = 143
        Me.Label7.Text = "Porcentaje"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Icon = CType(resources.GetObject("btnAdd.Icon"), System.Drawing.Icon)
        Me.btnAdd.Location = New System.Drawing.Point(486, 41)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(58, 24)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.ToolTipText = "Agregar Concepto de Bonificación"
        Me.btnAdd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(550, 41)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(58, 24)
        Me.BtnDel.TabIndex = 3
        Me.BtnDel.ToolTipText = "Elimina la partida seleccionada"
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(550, 13)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(58, 24)
        Me.BtnBuscaProd.TabIndex = 4
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Enabled = False
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(218, 14)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(326, 21)
        Me.TxtDescripcion.TabIndex = 139
        '
        'TxtClaveProd
        '
        Me.TxtClaveProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClaveProd.Location = New System.Drawing.Point(83, 14)
        Me.TxtClaveProd.Name = "TxtClaveProd"
        Me.TxtClaveProd.Size = New System.Drawing.Size(126, 21)
        Me.TxtClaveProd.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(303, 44)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(17, 20)
        Me.PictureBox2.TabIndex = 135
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtImporte
        '
        Me.TxtImporte.Location = New System.Drawing.Point(344, 44)
        Me.TxtImporte.Name = "TxtImporte"
        Me.TxtImporte.Size = New System.Drawing.Size(126, 20)
        Me.TxtImporte.TabIndex = 3
        Me.TxtImporte.Text = "0.00"
        Me.TxtImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtImporte.Value = 0.0R
        Me.TxtImporte.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(42, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(17, 19)
        Me.PictureBox1.TabIndex = 134
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
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
        Me.GridDetalle.Location = New System.Drawing.Point(8, 68)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(600, 240)
        Me.GridDetalle.TabIndex = 5
        Me.GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridDetalle.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.GridDetalle.TotalRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.GridDetalle.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 14)
        Me.Label4.TabIndex = 140
        Me.Label4.Text = "Prod. Cve."
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(267, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 15)
        Me.Label9.TabIndex = 130
        Me.Label9.Text = "Importe"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GrpCliente
        '
        Me.GrpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCliente.Controls.Add(Me.Label6)
        Me.GrpCliente.Controls.Add(Me.cmbUsoCFDI)
        Me.GrpCliente.Controls.Add(Me.Label5)
        Me.GrpCliente.Controls.Add(Me.CmbMotivo)
        Me.GrpCliente.Controls.Add(Me.LblTipoCambio)
        Me.GrpCliente.Controls.Add(Me.TxtBusqueda)
        Me.GrpCliente.Controls.Add(Me.Label1)
        Me.GrpCliente.Controls.Add(Me.CmbCaja)
        Me.GrpCliente.Controls.Add(Me.Label12)
        Me.GrpCliente.Controls.Add(Me.TxtNota)
        Me.GrpCliente.Controls.Add(Me.BtnTC)
        Me.GrpCliente.Controls.Add(Me.Label3)
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
        Me.GrpCliente.Location = New System.Drawing.Point(7, 3)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(778, 209)
        Me.GrpCliente.TabIndex = 2
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "General"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(498, 185)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 14)
        Me.Label6.TabIndex = 121
        Me.Label6.Text = "Uso "
        '
        'cmbUsoCFDI
        '
        Me.cmbUsoCFDI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbUsoCFDI.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUsoCFDI.ItemHeight = 13
        Me.cmbUsoCFDI.Location = New System.Drawing.Point(556, 182)
        Me.cmbUsoCFDI.Name = "cmbUsoCFDI"
        Me.cmbUsoCFDI.Size = New System.Drawing.Size(216, 21)
        Me.cmbUsoCFDI.TabIndex = 120
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 15)
        Me.Label5.TabIndex = 119
        Me.Label5.Text = "Motivo"
        '
        'CmbMotivo
        '
        Me.CmbMotivo.Location = New System.Drawing.Point(83, 151)
        Me.CmbMotivo.Name = "CmbMotivo"
        Me.CmbMotivo.Size = New System.Drawing.Size(270, 21)
        Me.CmbMotivo.TabIndex = 118
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTipoCambio.Location = New System.Drawing.Point(612, 74)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(160, 15)
        Me.LblTipoCambio.TabIndex = 117
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtBusqueda
        '
        Me.TxtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtBusqueda.Location = New System.Drawing.Point(84, 16)
        Me.TxtBusqueda.Name = "TxtBusqueda"
        Me.TxtBusqueda.Size = New System.Drawing.Size(141, 21)
        Me.TxtBusqueda.TabIndex = 96
        '
        'CmbCaja
        '
        Me.CmbCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbCaja.Location = New System.Drawing.Point(615, 18)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(157, 21)
        Me.CmbCaja.TabIndex = 97
        '
        'BtnAbrir
        '
        Me.BtnAbrir.Icon = CType(resources.GetObject("BtnAbrir.Icon"), System.Drawing.Icon)
        Me.BtnAbrir.Location = New System.Drawing.Point(295, 15)
        Me.BtnAbrir.Name = "BtnAbrir"
        Me.BtnAbrir.Size = New System.Drawing.Size(58, 24)
        Me.BtnAbrir.TabIndex = 95
        Me.BtnAbrir.ToolTipText = "Modificar datos del Cliente"
        Me.BtnAbrir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(359, 15)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(58, 24)
        Me.BtnAgregar.TabIndex = 94
        Me.BtnAgregar.ToolTipText = "Agregar nuevo Cliente"
        Me.BtnAgregar.Visible = False
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRFC
        '
        Me.TxtRFC.Enabled = False
        Me.TxtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRFC.Location = New System.Drawing.Point(83, 42)
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
        Me.LstDomicilio.Location = New System.Drawing.Point(83, 96)
        Me.LstDomicilio.Name = "LstDomicilio"
        Me.LstDomicilio.Size = New System.Drawing.Size(457, 49)
        Me.LstDomicilio.TabIndex = 92
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(6, 47)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(60, 15)
        Me.lblRFC.TabIndex = 91
        Me.lblRFC.Text = "RFC/Clave"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(6, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 16)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Razón Social"
        '
        'BtnBuscaCte
        '
        Me.BtnBuscaCte.Image = CType(resources.GetObject("BtnBuscaCte.Image"), System.Drawing.Image)
        Me.BtnBuscaCte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaCte.Location = New System.Drawing.Point(231, 15)
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
        Me.TxtRazonSocial.Location = New System.Drawing.Point(83, 68)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(457, 21)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Buscar"
        '
        'TxtClave
        '
        Me.TxtClave.Enabled = False
        Me.TxtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave.Location = New System.Drawing.Point(231, 42)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.ReadOnly = True
        Me.TxtClave.Size = New System.Drawing.Size(186, 21)
        Me.TxtClave.TabIndex = 3
        '
        'GrpSinAsignar
        '
        Me.GrpSinAsignar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpSinAsignar.Controls.Add(Me.txtTotal)
        Me.GrpSinAsignar.Controls.Add(Me.gridFacturas)
        Me.GrpSinAsignar.Controls.Add(Me.btnDevolucion)
        Me.GrpSinAsignar.Controls.Add(Me.TxtFactura)
        Me.GrpSinAsignar.Controls.Add(Me.btnBuscaFactura)
        Me.GrpSinAsignar.Location = New System.Drawing.Point(7, 218)
        Me.GrpSinAsignar.Name = "GrpSinAsignar"
        Me.GrpSinAsignar.Size = New System.Drawing.Size(160, 351)
        Me.GrpSinAsignar.TabIndex = 115
        Me.GrpSinAsignar.TabStop = False
        Me.GrpSinAsignar.Text = "Facturas"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(6, 322)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtTotal.TabIndex = 17
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotal.Value = 0.0R
        Me.txtTotal.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'gridFacturas
        '
        Me.gridFacturas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gridFacturas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridFacturas.ColumnAutoResize = True
        Me.gridFacturas.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.gridFacturas.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridFacturas.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridFacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridFacturas.GroupByBoxVisible = False
        Me.gridFacturas.Location = New System.Drawing.Point(5, 43)
        Me.gridFacturas.Name = "gridFacturas"
        Me.gridFacturas.RecordNavigator = True
        Me.gridFacturas.Size = New System.Drawing.Size(149, 273)
        Me.gridFacturas.TabIndex = 16
        Me.gridFacturas.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.gridFacturas.TotalRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.gridFacturas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnDevolucion
        '
        Me.btnDevolucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDevolucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDevolucion.Image = CType(resources.GetObject("btnDevolucion.Image"), System.Drawing.Image)
        Me.btnDevolucion.Location = New System.Drawing.Point(100, 15)
        Me.btnDevolucion.Name = "btnDevolucion"
        Me.btnDevolucion.Size = New System.Drawing.Size(23, 22)
        Me.btnDevolucion.TabIndex = 14
        Me.btnDevolucion.ToolTipText = "Remueve el Ticket Seleccionado de la Factura Actual"
        Me.btnDevolucion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtFactura
        '
        Me.TxtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFactura.Location = New System.Drawing.Point(5, 16)
        Me.TxtFactura.Name = "TxtFactura"
        Me.TxtFactura.Size = New System.Drawing.Size(91, 21)
        Me.TxtFactura.TabIndex = 1
        '
        'btnBuscaFactura
        '
        Me.btnBuscaFactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscaFactura.Image = CType(resources.GetObject("btnBuscaFactura.Image"), System.Drawing.Image)
        Me.btnBuscaFactura.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnBuscaFactura.Location = New System.Drawing.Point(127, 15)
        Me.btnBuscaFactura.Name = "btnBuscaFactura"
        Me.btnBuscaFactura.Size = New System.Drawing.Size(23, 22)
        Me.btnBuscaFactura.TabIndex = 2
        Me.btnBuscaFactura.ToolTipText = "Busqueda de Ticket"
        Me.btnBuscaFactura.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmBonificacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.GrpSinAsignar)
        Me.Controls.Add(Me.GrpCliente)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmBonificacion"
        Me.Text = "Bonificación"
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.GrpSinAsignar.ResumeLayout(False)
        Me.GrpSinAsignar.PerformLayout()
        CType(Me.gridFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Facturas() As DataRow
    Public bLiquidacion As Boolean = False
    Public CAJClave As String = ""
    Public ClienteInicial As String = ""
    'Public Cajon As Boolean = False
    'Public ImpresoraCajon As String = ""
    'Public Cajero As String
    'Public CajaActiva As Boolean = False
    Private Logo As Integer = 1
    Public SUCClave, Autoriza As String
    Public SeleccionaCaja As Boolean = False

    Private Moneda, MonedaBase, formaDePagoFactura As String
    Private MonedaRef, MonRefBase As String
    Private MonedaDesc, MonedaDescBase As String
    Private TipoCambio, TipoCambioBase As Decimal

    Private NCClave As String

    Private oCFD As CFD
    Private fechaPath As Date

    Private CostoTot, Subtotal, ImpuestoTot, Total As Decimal
    Private Saldo As Double
    Private MaxRow As Integer
    Private Folio As String

    '   Private Prefijo As String

    Private Impresora As String

    Private dtPAC, dtDetalle, dtConcepto, dtImpuesto, dtImpuestoDet, dtDetalleImpuesto, dtRetencionDet, dtFacturas, dtMetodosPago, dtRetencion As DataTable
    '    Private Grabado As Boolean = False

    Private PathXML, FormatNC, InterfazSalida As String

    Private PathPDF, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP As String
    Private MailPort As Integer
    Private MailSSL As Boolean
    Private Nota As String = Nothing
    Private olineas As Integer = 0

    Private correo As MailMessage
    Private adjuntos As Attachment
    Private autenticar As NetworkCredential
    Private envio As SmtpClient
    Private dato As FileStream

    Private iTipoPAC As Integer = 0
    Private alerta(1) As PictureBox
    Private reloj As parpadea


    Private Tasa, Costo As Double
    Private dImpuesto As Double
    Private bLoad As Boolean = False

    Private PROClave, Clave, Nombre As String
    Private iRegimenFiscal As Integer

    Private Sub RecalculaImporte(ByVal obj As String)
        Dim total As Decimal = CDec(txtTotal.Text)

        If total > 0 Then

            Select Case obj
                Case Is = "Porcentaje"
                    If txtPorcentaje.Text <> "" Then
                        Dim Porc As Decimal = CDec(txtPorcentaje.Text)

                        If Porc > 100 Then
                            Porc = 100
                        End If

                        If Porc < 0 Then
                            Porc = 1
                        End If

                        TxtImporte.Text = Math.Round(total * (Porc / 100), 2)
                    Else
                        txtPorcentaje.Text = "0"
                    End If

                Case Is = "Importe"
                    If TxtImporte.Text <> "" Then
                        Dim Importe As Decimal = CDec(TxtImporte.Text)

                        If Importe > total Then
                            Importe = total
                        End If

                        If Importe < 0 Then
                            Importe = 1
                        End If

                        txtPorcentaje.Text = Math.Round((Importe * 100) / total, 6)
                    Else
                        TxtImporte.Text = "0"
                    End If
            End Select

        Else
            MessageBox.Show("¡Debe referenciar el concepto a una o más facturas!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtPorcentaje.Text = "0"
            TxtImporte.Text = "0"
        End If

    End Sub




    Public Sub CargaDatosCliente(ByVal CTEClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", CTEClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            oCFD.CTEClave = dt.Rows(0)("CTEClave")
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

         
            dt.Dispose()

            TxtBusqueda.Text = ""
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

            GrpDetalle.Enabled = True

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
                    .fromForm = "Bonificacion"

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
                    .Facturable = IIf(dt.Rows(0)("facturable").GetType.Name = "DBNull", True, dt.Rows(0)("facturable"))
                  
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
                    .fechaNacimiento = IIf(dt.Rows(0)("fechaNacimiento").GetType.Name = "DBNull", Today.Date, dt.Rows(0)("fechaNacimiento"))
                    .Genero = IIf(dt.Rows(0)("Genero").GetType.Name = "DBNull", 0, dt.Rows(0)("Genero"))
                    .tipoTel1 = IIf(dt.Rows(0)("tipoTel1").GetType.Name = "DBNull", 1, dt.Rows(0)("tipoTel1"))
                    .tipoTel2 = IIf(dt.Rows(0)("tipoTel2").GetType.Name = "DBNull", 1, dt.Rows(0)("tipoTel2"))

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
                    .AccesoWeb = IIf(dt.Rows(0)("AccesoWeb").GetType.Name = "DBNull", False, dt.Rows(0)("AccesoWeb"))
                    .CtaMaestra = IIf(dt.Rows(0)("CtaMaestra").GetType.Name = "DBNull", dt.Rows(0)("CTEClave"), dt.Rows(0)("CtaMaestra"))
                    dt.Dispose()

                End With
            End If

            ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Cliente.Show()
            ModPOS.Cliente.BringToFront()

        End If
    End Sub

    Private Sub FrmBonificacion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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

        ModPOS.Bonificacion.Dispose()
        ModPOS.Bonificacion = Nothing
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
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Cliente Is Nothing Then
            ModPOS.Cliente = New FrmCliente
            ModPOS.Cliente.fromForm = "Bonificacion"
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

    Private Sub FrmBonificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2


        oCFD = New CFD

       
        NCClave = ModPOS.obtenerLlave

         With cmbUsoCFDI
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_UsoCFDI"
            .NombreParametro1 = "Grupo"
            .Parametro1 = 2
            .llenar()
        End With

        With CmbCaja
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_caja"
            .NombreParametro1 = "Sucursal"
            .Parametro1 = SUCClave
            .llenar()
        End With

        With Me.CmbMotivo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Bonificacion"
            .NombreParametro2 = "campo"
            .Parametro2 = "Motivo"
            .llenar()
        End With

        If CAJClave <> "" Then
            CmbCaja.SelectedValue = CAJClave
            CmbCaja.Enabled = SeleccionaCaja
        End If

        Dim dtParam As DataTable

        If Not CmbCaja.SelectedValue Is Nothing Then
            CAJClave = CmbCaja.SelectedValue

            If ClienteInicial = "" Then
                dtParam = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
                ClienteInicial = IIf(dtParam.Rows(0)("Mostrador").GetType.Name = "DBNull", "", dtParam.Rows(0)("Mostrador"))
                dtParam.Dispose()
            End If
        End If

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


        dtmsg = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        MonedaBase = Moneda
        TipoCambioBase = dtmsg.Rows(0)("TipoCambio")
        MonRefBase = dtmsg.Rows(0)("Referencia")
        MonedaDescBase = dtmsg.Rows(0)("Descripcion")
        dtmsg.Dispose()

        BtnTC.Text = MonRefBase

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


        bLoad = True

        LstDomicilio.Items.Clear()

        dtDetalle = ModPOS.CrearTabla("NCDetalle", _
                                                 "DNCClave", "System.String", _
                                                 "PROClave", "System.String", _
                                                 "Clave", "System.String", _
                                                 "Nombre", "System.String", _
                                                 "Costo", "System.Double", _
                                                 "Subtotal", "System.Decimal", _
                                                 "Tasa", "System.Double", _
                                                 "Impuesto", "System.Decimal", _
                                                 "Total", "System.Decimal")


        dtFacturas = ModPOS.CrearTabla("Facturas", _
                                                "FacturaID", "System.String", _
                                               "FACClave", "System.String", _
                                               "Folio", "System.String", _
                                               "Total", "System.Decimal", _
                                               "Saldo", "System.Decimal", _
                                               "Bonificar", "System.Decimal", _
                                               "MONClave", "System.String", _
                                               "TipoCambio", "System.Decimal", _
                                               "TipoImpuesto", "System.Int32")

        gridFacturas.DataSource = dtFacturas
        gridFacturas.RetrieveStructure(True)
        gridFacturas.RootTable.Columns("FacturaID").Visible = False
        gridFacturas.RootTable.Columns("FACClave").Visible = False
        gridFacturas.RootTable.Columns("Total").Visible = False
        gridFacturas.RootTable.Columns("Saldo").Visible = False
        gridFacturas.RootTable.Columns("MONClave").Visible = False
        gridFacturas.RootTable.Columns("TipoCambio").Visible = False
        gridFacturas.RootTable.Columns("TipoImpuesto").Visible = False


        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("DNCClave").Visible = False
        GridDetalle.RootTable.Columns("Tasa").Visible = False
        GridDetalle.RootTable.Columns("PROClave").Visible = False
        GridDetalle.RootTable.Columns("Costo").Visible = False


        GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
        GridDetalle.RootTable.Columns("Subtotal").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Impuesto").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridDetalle.RootTable.Columns("Total").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum

        GridDetalle.RootTable.Columns("Subtotal").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Impuesto").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

        GridDetalle.RootTable.Columns("Subtotal").TotalFormatString = "c"
        GridDetalle.RootTable.Columns("Impuesto").TotalFormatString = "c"
        GridDetalle.RootTable.Columns("Total").TotalFormatString = "c"

        If Not Facturas Is Nothing AndAlso Facturas.GetLength(0) > 0 Then
            For i = 0 To Facturas.GetUpperBound(0)
                Me.CargaDatosFactura(Facturas(i)("ID"), True)
            Next
        End If


    End Sub

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
            MessageBox.Show("La siguiente información del cliente No es valida ó es requerida : " & Cadena & " para completarla, edite la información del cliente seleccionado presionando el botón de Abrir junto al Filtro de busqueda y selección de cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Valido = False
        End If


        Return Valido
    End Function

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
                BtnBuscaCte.PerformClick()
        End Select

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

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If PROClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CDbl(TxtImporte.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

      

        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Function recuperaFolio(ByVal Caja As String, ByVal NumFolios As Integer) As Boolean
        Dim dt As DataTable
        Dim FOLClave As String
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

    Private Function crearCF(ByVal NCClave As String) As Boolean

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

        dt = ModPOS.Recupera_Tabla("sp_recupera_nc", "@NCClave", NCClave)

        dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_conceptonc", "@Clave", NCClave)
        dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_impuestosnc", "@Clave", NCClave)


        oCFD.Serie = dt.Rows(0)("Serie")
        oCFD.Folio = dt.Rows(0)("Folio")
        oCFD.descuento = 0
        oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dt.Rows(0)("fecha"))
        fechaPath = CDate(oCFD.Fecha)
        oCFD.total = dt.Rows(0)("total")
        'oCFD.extra = TxtExtra.Text
        oCFD.Moneda = MonedaRef
        oCFD.TipoCambio = TipoCambio

        If oCFD.TipoCF = 1 OrElse oCFD.TipoCF = 2 Then
            oCFD.DOCClave = dt.Rows(0)("NCClave")


            If oCFD.VersionCF = "3.3" Then
                dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_det", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", 7, "@Clave", oCFD.DOCClave)

            End If

            oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, 7, dtDetalleImpuesto, dtRetencionDet, dtRetencion)

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

    'Private Sub imprimirBonificacion(ByVal iTipoCF As Integer)
    '    Dim sImpresora As String
    '    Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", Impresora)
    '    sImpresora = dtPrinter.Rows(0)("Referencia")
    '    dtPrinter.Dispose()

    '    Dim OpenReport As New Report
    '    Dim pvtaDataSet As New DataSet
    '    pvtaDataSet.DataSetName = "pvtaDataSet"

    '    Select Case FormatNC
    '        Case Is = "Clasico"
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", NCClave))
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_detalle", "@NCClave", NCClave))
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", NCClave))
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_nc", "@NCClave", NCClave))

    '            If oCFD.TipoCF = 1 Then
    '                OpenReport.Print(1, "CREgresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(Total, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
    '            ElseIf oCFD.TipoCF = 2 Then
    '                OpenReport.Print(1, "CREgresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(Total , 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
    '            ElseIf oCFD.TipoCF = 3 Then
    '                OpenReport.Print(1, "CREgresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(Total , 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
    '            End If
    '        Case Is = "Radec"
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_nc_radec", "@NCClave", NCClave))
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_nc_radec", "@NCClave", NCClave))
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

    '            OpenReport.Print(1, "CFDNotaCredito.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(Total, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)

    '    End Select
    'End Sub

    'Private Sub SendMail(ByVal iTipoCF As Integer)

    '    Dim sPathXML, sMailCliente As String

    '    sMailCliente = oCFD.email

    '    If MailAdress = "" OrElse MailUser = "" OrElse MailPassword = "" OrElse HostSMTP = "" OrElse MailPort = 0 Then
    '        MessageBox.Show("No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    End If

    '    'Verifica que exista el path
    '    If iTipoCF <= 2 Then
    '        Try
    '            If Not System.IO.Directory.Exists(PathXML) Then
    '                MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Exit Sub
    '            End If
    '        Catch ex As Exception
    '        End Try
    '    End If



    '    PathPDF = pathActual & "Temp\" & Folio & ".PDF"

    '    'Genera PDF

    '    Dim OpenReport As New Report
    '    Dim pvtaDataSet As New DataSet
    '    pvtaDataSet.DataSetName = "pvtaDataSet"

    '    Select Case FormatNC
    '        Case Is = "Clasico"
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", NCClave))
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_detalle", "@NCClave", NCClave))
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", NCClave))
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_nc", "@NCClave", NCClave))

    '            If oCFD.TipoCF = 1 Then
    '                OpenReport.PrintPDF("CREgresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(Total , 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
    '            ElseIf oCFD.TipoCF = 2 Then
    '                OpenReport.PrintPDF("CREgresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(Total, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
    '            ElseIf oCFD.TipoCF = 3 Then
    '                OpenReport.PrintPDF("CREgresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(Total , 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
    '            End If

    '        Case Is = "Radec"
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_nc_radec", "@NCClave", NCClave))
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_nc_radec", "@NCClave", NCClave))
    '            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

    '            OpenReport.PrintPDF("CFDNotaCredito.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(Total , 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)

    '    End Select

    '    If Not System.IO.File.Exists(PathPDF) Then
    '        MessageBox.Show("Ha ocurrido un error al generar el archivo: " & PathPDF, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    End If

    '    'Envia Correo

    '    Dim frmStatusMessage As New frmStatus
    '    Try
    '        correo = New MailMessage
    '        autenticar = New NetworkCredential
    '        envio = New SmtpClient

    '        correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Bonificación (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agradecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
    '        correo.Subject = "Bonificación " & Folio
    '        correo.IsBodyHtml = True
    '        correo.To.Clear()
    '        correo.CC.Clear()
    '        correo.Bcc.Clear()


    '        If sMailCliente.Split(",").Length >= 1 Then
    '            Dim i As Integer
    '            For i = 0 To sMailCliente.Split(",").Length - 1
    '                If sMailCliente.Split(",")(i) <> "" Then
    '                    correo.To.Add(sMailCliente.Split(",")(i))
    '                End If
    '            Next
    '        Else
    '            correo.To.Add(sMailCliente)
    '        End If

    '        correo.From = New MailAddress(MailAdress, DisplayName)
    '        envio.Credentials = New NetworkCredential(MailUser, MailPassword)
    '        envio.Host = HostSMTP  '"smtp.live.com"
    '        envio.Port = MailPort  '587
    '        envio.EnableSsl = MailSSL 'True

    '        frmStatusMessage.Show("Enviando correo electrónico...")


    '        If iTipoCF <= 2 Then


    '            sPathXML = PathXML
    '            If sPathXML.Length > 3 AndAlso sPathXML.Substring(sPathXML.Length - 1, 1) <> "\" Then
    '                sPathXML &= "\"
    '            End If

    '            sPathXML &= fechaPath.Year.ToString & "\" & fechaPath.Month.ToString & "\" & fechaPath.Day.ToString & "\" & Folio & ".xml"



    '            If Not System.IO.File.Exists(sPathXML) Then
    '                If PathXML.Length <= 3 Then
    '                    sPathXML = PathXML & Folio & ".xml"
    '                Else
    '                    sPathXML = PathXML & "\" & Folio("Folio") & ".xml"
    '                End If

    '            End If


    '            dato = New FileStream(sPathXML, FileMode.Open, FileAccess.Read)
    '            adjuntos = New Attachment(dato, Folio & ".XML")
    '            correo.Attachments.Add(adjuntos)

    '        End If

    '        dato = New FileStream(PathPDF, FileMode.Open, FileAccess.Read)
    '        adjuntos = New Attachment(dato, Folio & ".PDF")
    '        correo.Attachments.Add(adjuntos)

    '        envio.Send(correo)
    '        correo.Dispose()

    '        MessageBox.Show("El mensaje fue enviado correctamente a el destinatario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        frmStatusMessage.Dispose()
    '    Catch ex As Exception
    '        frmStatusMessage.Dispose()
    '        MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    '    dato.Close()

    '    Try
    '        My.Computer.FileSystem.DeleteFile(PathPDF, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
    '    Catch ex As Exception
    '        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
    '    End Try

    'End Sub

    Public Sub recuperaProducto(ByVal sClave As String, ByVal iTipo As Integer)

        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("st_recupera_servicio", "@Tipo", iTipo, "@Busca", sClave, "@SUCClave", SUCClave)
        If Not dtProducto Is Nothing Then

            PROClave = dtProducto.Rows(0)("PROClave")
            Clave = dtProducto.Rows(0)("Clave")
            Nombre = dtProducto.Rows(0)("Nombre")
            Costo = dtProducto.Rows(0)("Costo")
            Tasa = ModPOS.RecuperaImpuesto(SUCClave, PROClave, oCFD.TImpuesto)
            dtProducto.Dispose()

            TxtClaveProd.Text = Clave
            TxtDescripcion.Text = Nombre
            TxtImporte.Text = 0
            txtPorcentaje.Text = 0
            txtPorcentaje.Focus()
        Else
            PROClave = ""
            Clave = ""
            Nombre = ""
            Tasa = 0
            Costo = 0
            TxtClaveProd.Text = Clave
            TxtDescripcion.Text = Nombre
            TxtImporte.Text = 0
            txtPorcentaje.Text = 0
            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub BtnBuscaProd_Click(sender As Object, e As EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "st_busca_servicios"
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.BusquedaInicial = True
        a.CompaniaRequerido = True
        a.Busqueda = IIf(TxtClaveProd.Text = "", "%", TxtClaveProd.Text.Trim)
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                recuperaProducto(a.valor, 3)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub TxtClaveProd_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtClaveProd.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtClaveProd.Text <> "" Then
                    recuperaProducto(TxtClaveProd.Text.Trim, 2)
                End If
            Case Is = Keys.Right
                BtnBuscaProd.PerformClick()
        End Select

    End Sub

    Private Sub InsertaImpuesto(ByVal PartidaId As String, ByVal sPROClave As String, ByVal dPrecio As Double, ByVal iTImpuesto As Integer, ByVal sSUCClave As String)
        Dim PrecioImp As Decimal = dPrecio
        Dim ImpImporte As Decimal = 0
        Dim Base As Decimal
        Dim dtImpuesto As DataTable
        Dim i As Integer
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
                ModPOS.Ejecuta("sp_inserta_ncimpuesto", "@DNCClave", PartidaId, "@IMPClave", dtImpuesto.Rows(i)("IMPClave"), "@Base", Base, "@PorcImp", dtImpuesto.Rows(i)("Valor"), "@Importe", Math.Round(ImpImporte, 2), "@Usuario", ModPOS.UsuarioActual)
                PrecioImp += ImpImporte
            Next
            dtImpuesto.Dispose()
        End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If GridDetalle.RowCount >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se removera el concepto: " & GridDetalle.GetValue("Clave"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtDetalle.Select("DNCClave = '" & GridDetalle.GetValue("DNCClave") & "'")
                    dtDetalle.Rows.Remove(foundRows(0))

                
                    CostoTot = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Costo"), Janus.Windows.GridEX.AggregateFunction.Sum)

                    Subtotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    ImpuestoTot = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)

                 

                    If GridDetalle.RowCount = 0 Then
                        TxtBusqueda.Enabled = True
                        BtnBuscaCte.Enabled = True
                        BtnAgregar.Enabled = True
                        Dim k As Integer
                        For k = 0 To dtFacturas.Rows.Count - 1
                            dtFacturas.Rows(k)("Bonificar") = 0
                        Next
                    End If
            End Select
        End If
    End Sub

   

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        'Inicia Sección de Validaciones 

        Dim dt As DataTable

        If Not CmbCaja.SelectedValue Is Nothing Then
            CAJClave = CmbCaja.SelectedValue

        
            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            Impresora = dt.Rows(0)("ImpresoraFac")
            dt.Dispose()

        Else
            MessageBox.Show("Debe seleccionar una Caja valida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If CmbMotivo.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar un motivo valido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If GridDetalle.RowCount <= 0 Then
            MessageBox.Show("No es posible generar la nota de cargo debido a que no se encontraron conceptos en el detalle", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Not VerificaDatoFiscalCte() Then
            BtnGuardar.Enabled = True
            Exit Sub
        End If

        If Total > CDec(txtTotal.Text) Then
            MessageBox.Show("El importe de la bonificación no puede ser mayor al importe de las facturas referenciadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If cmbUsoCFDI.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar una opcion Uso del Comprobante", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnGuardar.Enabled = True
            Exit Sub
        End If

        oCFD.UsoCFDI = cmbUsoCFDI.SelectedValue
        oCFD.tipoNC = 2

        Dim a As New MeAutorizacion
        a.Sucursal = SUCClave
        a.MontodeAutorizacion = CDbl(Total * TipoCambio)
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

        Dim k As Integer

      


        ' Termina Sección de Validaciones

        If Not recuperaFolio(CAJClave, 1) Then
            Exit Sub
        End If

        Nota = TxtNota.Text


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
                  "@CTEClave", oCFD.CTEClave, _
                  "@TipoImpuesto", oCFD.TImpuesto, _
                  "@TipoCF", oCFD.TipoCF, _
                  "@VersionCF", oCFD.VersionCF, _
                  "@RegimenFiscal", oCFD.regimenFiscal, _
                  "@Serie", oCFD.Serie, _
                  "@Folio", oCFD.Folio, _
                  "@CAJClave", CAJClave, _
                  "@Atendio", ModPOS.UsuarioActual, _
                  "@fechaAprobacion", oCFD.fechaAprobacion, _
                  "@formaDePago", oCFD.formaDePago, _
                  "@Motivo", CmbMotivo.SelectedValue, _
                  "@Observacion", Nota, _
                  "@Costo", CostoTot, _
                  "@Subtotal", Subtotal, _
                  "@ImpuestoTot", ImpuestoTot, _
                  "@DescuentoTot", 0, _
                  "@Total", Total, _
                  "@tipoCertificado", oCFD.tipoDeComprobante, _
                  "@Tipo", 2, _
                  "@MONClave", Moneda, _
                  "@TipoCambio", TipoCambio, _
                  "@UsoCFDI", oCFD.UsoCFDI, _
                  "@Logo", Logo, _
                  "@Usuario", ModPOS.UsuarioActual)


        Dim fila As Integer

        For fila = 0 To dtDetalle.Rows.Count - 1

            ModPOS.Ejecuta("sp_inserta_ncdetalle", _
                                    "@DNCClave", dtDetalle.Rows(fila)("DNCClave"), _
                                    "@NCClave", NCClave, _
                                    "@Partida", (fila + 1) * 10, _
                                    "@PROClave", dtDetalle.Rows(fila)("PROClave"), _
                                    "@TProducto", 4, _
                                    "@Costo", dtDetalle.Rows(fila)("Costo"), _
                                    "@Precio", dtDetalle.Rows(fila)("Subtotal"), _
                                    "@Descuento", 0, _
                                    "@Impuesto", dtDetalle.Rows(fila)("Impuesto"), _
                                    "@Puntos", 0, _
                                    "@Cantidad", 1, _
                                    "@Subtotal", dtDetalle.Rows(fila)("Subtotal"), _
                                    "@Total", dtDetalle.Rows(fila)("Total"))

            InsertaImpuesto(dtDetalle.Rows(fila)("DNCClave"), dtDetalle.Rows(fila)("PROClave"), dtDetalle.Rows(fila)("Subtotal"), oCFD.TImpuesto, SUCClave)

            If oCFD.eTPersona = 1 AndAlso oCFD.TPersona = 2 Then
                'Calcula retencion
                ModPOS.calculaRetencion("N", dtDetalle.Rows(fila)("DNCClave"), dtDetalle.Rows(fila)("PROClave"), dtDetalle.Rows(fila)("Subtotal"), oCFD.TImpuesto, SUCClave)
            End If

        Next
        dtDetalle.Dispose()

        ModPOS.Ejecuta("st_actualiza_nc", _
                                "@NCClave", NCClave)

        'Obtener retenciones

        If oCFD.eTPersona = 1 AndAlso oCFD.TPersona = 2 Then
            Dim dRetenciones As Decimal = 0
            dtRetencion = ModPOS.Recupera_Tabla("st_recupera_retenciones", "@TipoComprobante", "E", "@Tipo", 7, "@Clave", NCClave)
            dtRetencionDet = ModPOS.Recupera_Tabla("st_recupera_retencion_det", "@TipoComprobante", "E", "@Tipo", 7, "@Clave", NCClave)
            If dtRetencion.Rows.Count > 0 Then
                dRetenciones = dtRetencion.Compute("SUM(Importe)", "NCClave = '" & NCClave & "'")

                Total -= dRetenciones

                ModPOS.Ejecuta("st_aplica_retencion", "@Clave", NCClave, "@Tipo", "N", "@Retencion", dRetenciones)
            End If
        End If

        ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", oCFD.CTEClave, "@Importe", Total * TipoCambio)




        'Se insertan los documentos referenciados
        For k = 0 To dtFacturas.Rows.Count - 1

            ModPOS.Ejecuta("st_nc_factura", "@NCClave", NCClave, "@FACClave", dtFacturas.Rows(k)("FACClave"), "@Saldo", dtFacturas.Rows(k)("Saldo"), "@Bonificar", dtFacturas.Rows(k)("Bonificar"))

            If CDec(dtFacturas.Rows(k)("Saldo")) > 0 AndAlso CDec(dtFacturas.Rows(k)("Saldo")) <= CDec(dtFacturas.Rows(k)("Bonificar")) Then
                ModPOS.Ejecuta("sp_paga_documento", _
                               "@CAJClave", CAJClave, _
                               "@ABNClave", NCClave, _
                               "@TipoDoc", 2, _
                               "@Documento", dtFacturas.Rows(k)("FACClave"), _
                               "@Pago", CDec(dtFacturas.Rows(k)("Saldo")) * TipoCambio, _
                               "@AcumulaPuntos", 0, _
                               "@Tipo", -1, _
                               "@Usuario", ModPOS.UsuarioActual)

            ElseIf CDec(dtFacturas.Rows(k)("Saldo")) > CDec(dtFacturas.Rows(k)("Bonificar")) Then

                ModPOS.Ejecuta("sp_actualiza_saldo", _
                                "@CAJClave", CAJClave, _
                               "@ABNClave", NCClave, _
                               "@Pago", CDec(dtFacturas.Rows(k)("Bonificar") * TipoCambio), _
                               "@TipoDoc", 2, _
                               "@Documento", dtFacturas.Rows(k)("FACClave"), _
                               "@Tipo", -1, _
                               "@SaldoRemanente", Math.Round((CDec(dtFacturas.Rows(k)("Saldo")) - CDec(dtFacturas.Rows(k)("Bonificar"))), 2), _
                               "@Usuario", ModPOS.UsuarioActual)


            End If

        Next


        Dim j As Integer

        Dim sMetodoPago, sBanco, sReferencia, sSAT As String

        oCFD.metodoDePago = ""
        oCFD.NumCtaPago = ""

        Dim frMetodoPagos() As System.Data.DataRow



        If oCFD.VersionCF = "3.3" AndAlso (formaDePagoFactura = "PPD" OrElse dtFacturas.Rows.Count > 1) Then

            sMetodoPago = "Condonación"
            sBanco = ""
            sSAT = "15"
            sReferencia = ""


            ModPOS.Ejecuta("sp_agregar_metodopagonc", _
              "@NCClave", NCClave, _
              "@MetodoPago", sMetodoPago, _
              "@Banco", sBanco, _
              "@SAT", sSAT, _
              "@Referencia", sReferencia)

            oCFD.metodoDePago = sSAT
            If sReferencia <> "" AndAlso oCFD.NumCtaPago = "" Then
                oCFD.NumCtaPago = sReferencia
            End If

        Else

            dtMetodosPago = ModPOS.Recupera_Tabla("st_recupera_metodopago_fac", "@FacturaID", dtFacturas.Rows(0)("FacturaID"))
            frMetodoPagos = dtMetodosPago.Select()
           

            For j = 0 To frMetodoPagos.GetUpperBound(0)

                sMetodoPago = IIf(frMetodoPagos(j)("Tipo").GetType.Name = "DBNull", "", frMetodoPagos(j)("Tipo"))
                sBanco = IIf(frMetodoPagos(j)("Banco").GetType.Name = "DBNull", "", frMetodoPagos(j)("Banco"))
                sReferencia = IIf(frMetodoPagos(j)("Referencia").GetType.Name = "DBNull", "", CStr(frMetodoPagos(j)("Referencia")).Trim.ToUpper)
                sSAT = IIf(frMetodoPagos(j)("SAT").GetType.Name = "DBNull", "99", frMetodoPagos(j)("SAT"))



                ModPOS.Ejecuta("sp_agregar_metodopagonc", _
                "@NCClave", NCClave, _
                "@MetodoPago", sMetodoPago, _
                "@Banco", sBanco, _
                "@SAT", sSAT, _
                "@Referencia", sReferencia)

                If oCFD.VersionCF <> "3.3" Then
                    If j > 0 Then
                        oCFD.metodoDePago &= ","
                        If oCFD.NumCtaPago <> "" AndAlso sReferencia <> "" Then
                            oCFD.NumCtaPago &= ","
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

        End If

      

        If oCFD.metodoDePago = "" Then
            If oCFD.VersionCF <> "3.3" Then
                oCFD.metodoDePago = "Por Definir"
            Else
                oCFD.metodoDePago = "99"
            End If
        End If


        Folio = oCFD.Serie & CStr(oCFD.Folio)
        oCFD.total = Total
        MessageBox.Show("Se genero la Bonificación " & Folio, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)


        crearCF(NCClave)

        'Inicia
        If oCFD.TipoCF = 2 AndAlso iTipoPAC = 0 Then
            MessageBox.Show("No ha sido posible certificar este documento, le recomendamos intentar certificarlo más tarde", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            Exit Sub
        End If


        Select Case MessageBox.Show("¿Desea imprimir la Bonificación?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case DialogResult.Yes
                Dim sImpresora As String
                Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", Impresora)
                sImpresora = dtPrinter.Rows(0)("Referencia")
                dtPrinter.Dispose()

                imprimirNC(oCFD.TipoCF, FormatNC, NCClave, Total, SUCClave, TipoCambio, MonedaDesc, MonedaRef, sImpresora, 1, oCFD.VersionCF, Logo)

        End Select

        If oCFD.email <> "" Then
            Select Case MessageBox.Show("¿Desea enviar el documento por correo electrónico?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    ModPOS.SendMailNC(oCFD.VersionCF, oCFD.email, oCFD.TipoCF, FormatNC, CDate(oCFD.Fecha), Folio, NCClave, Total, MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonedaDesc, MonedaRef, Logo, True)

            End Select
        End If

        Me.Close()
    End Sub



    Private Sub btnDevolucion_Click(sender As Object, e As EventArgs) Handles btnDevolucion.Click
        If GridDetalle.RowCount > 0 Then
            MessageBox.Show("No es posible remover una factura debido a que se han  agregado detalles a la bonificación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf gridFacturas.RowCount > 0 Then
            Beep()
            Select Case MessageBox.Show("Se removera el Factura: " & gridFacturas.GetValue("Folio"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtFacturas.Select("FACClave = '" & gridFacturas.GetValue("FACClave") & "'")
                    dtFacturas.Rows.Remove(foundRows(0))
                    txtTotal.Text = gridFacturas.GetTotal(gridFacturas.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
            End Select
        End If
    End Sub

    Public Function CargaDatosFactura(ByVal Folio As String, ByVal esClave As Boolean) As Boolean
        'Valida que el campo Ticket no se encuentre vacio
        If GridDetalle.RowCount > 0 Then
            MessageBox.Show("No es posible agregar más facturas debido a que se han  agregado detalles a la bonificación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        Else
            Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_busca_factura", "@Folio", Folio, "@Clave", esClave, "@COMClave", ModPOS.CompanyActual)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

                Dim foundRows() As System.Data.DataRow
                Dim fr() As System.Data.DataRow

                If oCFD.CTEClave = "" Then
                    CargaDatosCliente(dt.Rows(0)("CTEClave"))
                ElseIf oCFD.CTEClave <> dt.Rows(0)("CTEClave") Then
                    MessageBox.Show("No es posible incluir facturas de diferentes clientes en una Bonificación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    dt.Dispose()
                    Return False
                End If



                foundRows = dtFacturas.Select("FACClave = '" & dt.Rows(0)("FACClave") & "'")
                If foundRows.Length = 0 Then


                    fr = dtFacturas.Select("MONClave <>'" & CStr(IIf(dt.Rows(0)("MONClave").GetType.Name = "DBNull", Moneda, dt.Rows(0)("MONClave"))) & "'")
                    If foundRows.Length > 0 Then
                        MessageBox.Show("No es posible incluir facturas de diferentes Monedas en una Bonificación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        dt.Dispose()
                        Return False
                    End If

                    fr = dtFacturas.Select("TipoCambio <> " & CStr(IIf(dt.Rows(0)("TipoCambio").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambio"))))
                    If foundRows.Length > 0 Then
                        MessageBox.Show("No es posible incluir facturas de diferentes Tipos de Cambio en una Bonificación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        dt.Dispose()
                        Return False

                    End If


                    fr = dtFacturas.Select("TipoImpuesto <> " & CStr(IIf(dt.Rows(0)("TipoImpuesto").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoImpuesto"))))
                    If foundRows.Length > 0 Then
                        MessageBox.Show("No es posible incluir facturas de diferentes Tipos de Impuesto (General/Frontera) en una Bonificación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        dt.Dispose()
                        Return False

                    End If

                    Moneda = IIf(dt.Rows(0)("MONClave").GetType.Name = "DBNull", Moneda, dt.Rows(0)("MONClave"))
                    TipoCambio = IIf(dt.Rows(0)("TipoCambio").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambio"))
                    Logo = IIf(dt.Rows(0)("Logo").GetType.Name = "DBNull", 1, dt.Rows(0)("Logo"))
                    formaDePagoFactura = IIf(dt.Rows(0)("formaDePago").GetType.Name = "DBNull", 1, dt.Rows(0)("formaDePago"))

                    oCFD.TImpuesto = dt.Rows(0)("TipoImpuesto")

                    If Moneda <> MonedaBase Then
                        Dim dtm As DataTable
                        dtm = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
                        If dtm.Rows.Count > 0 Then
                            MonedaRef = dtm.Rows(0)("Referencia")
                            MonedaDesc = dtm.Rows(0)("Descripcion")
                        End If
                        dtm.Dispose()
                    Else
                        MonedaRef = MonRefBase
                        MonedaDesc = MonedaDescBase
                    End If

                    BtnTC.Text = MonedaRef


                    Dim row1 As DataRow
                    row1 = dtFacturas.NewRow()
                    'declara el nombre de la fila
                    row1.Item("FacturaID") = dt.Rows(0)("FacturaID")
                    row1.Item("FACClave") = dt.Rows(0)("FACClave")
                    row1.Item("Folio") = CStr(dt.Rows(0)("Serie")) & CStr(dt.Rows(0)("Folio"))
                    row1.Item("Total") = dt.Rows(0)("Total")
                    row1.Item("Saldo") = dt.Rows(0)("Saldo")
                    row1.Item("Bonificar") = 0
                    row1.Item("MONClave") = Moneda
                    row1.Item("TipoCambio") = TipoCambio
                    row1.Item("TipoImpuesto") = dt.Rows(0)("TipoImpuesto")
                    dtFacturas.Rows.Add(row1)




                    oCFD.formaDePago = IIf(dt.Rows(0)("formaDePago").GetType.Name = "DBNull", "Pago en una sola exhibición", dt.Rows(0)("formaDePago"))

                    If oCFD.VersionCF = "3.3" Then
                        oCFD.formaDePago = "PUE"
                        oCFD.CondicionesDePago = "Contado"
                    End If




                    'agrega la fila completo a la tabla
                    dt.Dispose()
                    txtTotal.Text = gridFacturas.GetTotal(gridFacturas.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    Return True
                End If
            Else
                MessageBox.Show("El folio introducido no se encuentra Activo o no existe ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        End If
    End Function


    Private Sub btnBuscaFactura_Click(sender As Object, e As EventArgs) Handles btnBuscaFactura.Click
        Dim a As New MeSearchDate
        a.ProcedimientoAlmacenado = "sp_search_factura"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            CargaDatosFactura(a.valor, True)

        End If
        a.Dispose()
    End Sub

 
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If gridFacturas.RowCount > 0 Then
            If validaForm() Then

                Dim foundRows() As System.Data.DataRow
                foundRows = dtDetalle.Select("PROClave = '" & PROClave & "'")
                If foundRows.Length = 0 Then

                    If GridDetalle.RowCount = 0 Then
                        TxtBusqueda.Enabled = False
                        BtnBuscaCte.Enabled = False
                        BtnAgregar.Enabled = False
                    End If

                    Dim k As Integer
                    Dim dSubtotal, dTotal As Decimal
                    Dim dBonificar As Decimal = 0
                    For k = 0 To dtFacturas.Rows.Count - 1
                        dBonificar += Math.Round(dtFacturas.Rows(k)("Total") * (CDec(txtPorcentaje.Text) / 100), 2)
                        dtFacturas.Rows(k)("Bonificar") += Math.Round(dtFacturas.Rows(k)("Total") * (CDec(txtPorcentaje.Text) / 100), 2)
                    Next

                    dSubtotal = Math.Round(dBonificar / (1 + Tasa), 2)
                    dImpuesto = Math.Round(dSubtotal * Tasa, 2)

                    dTotal = dSubtotal + dImpuesto

                    TxtImporte.Text = dTotal

                    Dim row1 As DataRow
                    row1 = dtDetalle.NewRow()
                    'declara el nombre de la fila
                    row1.Item("DNCClave") = ModPOS.obtenerLlave
                    row1.Item("PROClave") = PROClave
                    row1.Item("Clave") = Clave
                    row1.Item("Nombre") = Nombre
                    row1.Item("Costo") = Costo
                    row1.Item("Subtotal") = dSubtotal
                    row1.Item("Tasa") = Tasa
                    row1.Item("Impuesto") = dImpuesto
                    row1.Item("Total") = dTotal

                    dtDetalle.Rows.Add(row1)
                    'agrega la fila completo a la tabla

                    TxtDescripcion.Text = ""
                    TxtImporte.Text = ""
                    TxtClaveProd.Text = ""

                    CostoTot = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Costo"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    Subtotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    ImpuestoTot = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)



                Else
                    PROClave = ""
                    Clave = ""
                    Nombre = ""
                    Tasa = 0
                    Costo = 0
                    TxtClaveProd.Text = Clave
                    TxtDescripcion.Text = Nombre
                    TxtImporte.Text = 0
                    MessageBox.Show("¡El concepto que intenta agregar ya existe ne la nota de cargo actual!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else
            Beep()
            MessageBox.Show("¡Debe referenciar el concepto a una o más facturas!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub TxtFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFactura.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtFactura.Text = vbNullString Then
                CargaDatosFactura(TxtFactura.Text.ToUpper.Trim.Replace("'", "''"), False)
                TxtFactura.Text = ""
            End If
        End If
    End Sub

    Private Sub Txtobj_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtImporte.KeyDown, txtPorcentaje.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtImporte_Leave(sender As Object, e As EventArgs) Handles TxtImporte.Leave
        RecalculaImporte("Importe")
    End Sub

    Private Sub txtPorcentaje_Leave(sender As Object, e As EventArgs) Handles txtPorcentaje.Leave
        RecalculaImporte("Porcentaje")
    End Sub
End Class
