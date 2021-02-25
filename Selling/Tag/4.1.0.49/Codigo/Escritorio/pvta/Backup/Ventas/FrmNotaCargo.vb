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



Public Class FrmNotaCargo
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
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnAdd As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LstDomicilio As System.Windows.Forms.ListBox
    Friend WithEvents TxtRFC As System.Windows.Forms.TextBox
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtIVA As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents LblIVA As System.Windows.Forms.Label
    Friend WithEvents LblSubtotal As System.Windows.Forms.Label
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAbrir As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents BtnRemover As Janus.Windows.EditControls.UIButton
    Friend WithEvents CtxDocumentos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnTC As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents TxtUnidad As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbImpuesto As Selling.StoreCombo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPartida As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbFormaPago As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents CmbCaja As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNotaCargo))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtNota = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmbFormaPago = New Selling.StoreCombo
        Me.LblTipoCambio = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnTC = New Janus.Windows.EditControls.UIButton
        Me.CtxDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label12 = New System.Windows.Forms.Label
        Me.CmbCaja = New Selling.StoreCombo
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.BtnAdd = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpDetalle = New System.Windows.Forms.GroupBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtPartida = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbImpuesto = New Selling.StoreCombo
        Me.TxtImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.BtnRemover = New Janus.Windows.EditControls.UIButton
        Me.TxtUnidad = New System.Windows.Forms.TextBox
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
        Me.GrpGeneral.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Controls.Add(Me.TxtNota)
        Me.GrpGeneral.Controls.Add(Me.Label6)
        Me.GrpGeneral.Controls.Add(Me.CmbFormaPago)
        Me.GrpGeneral.Controls.Add(Me.LblTipoCambio)
        Me.GrpGeneral.Controls.Add(Me.Label3)
        Me.GrpGeneral.Controls.Add(Me.BtnTC)
        Me.GrpGeneral.Controls.Add(Me.Label12)
        Me.GrpGeneral.Controls.Add(Me.CmbCaja)
        Me.GrpGeneral.Controls.Add(Me.ChkEstado)
        Me.GrpGeneral.Location = New System.Drawing.Point(7, 7)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(300, 181)
        Me.GrpGeneral.TabIndex = 1
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos Generales"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(6, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 15)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Nota"
        '
        'TxtNota
        '
        Me.TxtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtNota.Location = New System.Drawing.Point(60, 134)
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(232, 21)
        Me.TxtNota.TabIndex = 115
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(4, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 14)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "F. Pago"
        '
        'CmbFormaPago
        '
        Me.CmbFormaPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CmbFormaPago.BackColor = System.Drawing.SystemColors.Window
        Me.CmbFormaPago.ItemHeight = 13
        Me.CmbFormaPago.Location = New System.Drawing.Point(60, 94)
        Me.CmbFormaPago.Name = "CmbFormaPago"
        Me.CmbFormaPago.Size = New System.Drawing.Size(232, 21)
        Me.CmbFormaPago.TabIndex = 113
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Location = New System.Drawing.Point(60, 22)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(101, 15)
        Me.LblTipoCambio.TabIndex = 112
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(5, 25)
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
        Me.BtnTC.Location = New System.Drawing.Point(166, 14)
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
        Me.Label12.Location = New System.Drawing.Point(4, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 15)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Caja"
        '
        'CmbCaja
        '
        Me.CmbCaja.Location = New System.Drawing.Point(60, 57)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(233, 21)
        Me.CmbCaja.TabIndex = 97
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
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.Icon = CType(resources.GetObject("BtnAdd.Icon"), System.Drawing.Icon)
        Me.BtnAdd.Location = New System.Drawing.Point(614, 67)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 22)
        Me.BtnAdd.TabIndex = 6
        Me.BtnAdd.Text = "Agregar"
        Me.BtnAdd.ToolTipText = "Busqueda de Ticket"
        Me.BtnAdd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        Me.GrpDetalle.Controls.Add(Me.PictureBox5)
        Me.GrpDetalle.Controls.Add(Me.PictureBox4)
        Me.GrpDetalle.Controls.Add(Me.PictureBox3)
        Me.GrpDetalle.Controls.Add(Me.PictureBox2)
        Me.GrpDetalle.Controls.Add(Me.PictureBox1)
        Me.GrpDetalle.Controls.Add(Me.Label13)
        Me.GrpDetalle.Controls.Add(Me.txtPartida)
        Me.GrpDetalle.Controls.Add(Me.Label10)
        Me.GrpDetalle.Controls.Add(Me.Label9)
        Me.GrpDetalle.Controls.Add(Me.Label8)
        Me.GrpDetalle.Controls.Add(Me.cmbImpuesto)
        Me.GrpDetalle.Controls.Add(Me.TxtImporte)
        Me.GrpDetalle.Controls.Add(Me.TxtCantidad)
        Me.GrpDetalle.Controls.Add(Me.Label7)
        Me.GrpDetalle.Controls.Add(Me.Label5)
        Me.GrpDetalle.Controls.Add(Me.BtnAdd)
        Me.GrpDetalle.Controls.Add(Me.TxtDescripcion)
        Me.GrpDetalle.Controls.Add(Me.BtnRemover)
        Me.GrpDetalle.Controls.Add(Me.TxtUnidad)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(7, 193)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(778, 253)
        Me.GrpDetalle.TabIndex = 3
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(513, 19)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox5.TabIndex = 138
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(422, 19)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox4.TabIndex = 137
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(152, 16)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 136
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(81, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 135
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(11, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 134
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(724, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 15)
        Me.Label13.TabIndex = 133
        Me.Label13.Text = "Total"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPartida
        '
        Me.txtPartida.Enabled = False
        Me.txtPartida.Location = New System.Drawing.Point(653, 36)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(116, 20)
        Me.txtPartida.TabIndex = 132
        Me.txtPartida.Text = "0.00"
        Me.txtPartida.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPartida.Value = 0
        Me.txtPartida.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(513, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(124, 15)
        Me.Label10.TabIndex = 131
        Me.Label10.Text = "Impuesto"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(419, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 15)
        Me.Label9.TabIndex = 130
        Me.Label9.Text = "Importe"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(81, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 15)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "Cantidad"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbImpuesto
        '
        Me.cmbImpuesto.Location = New System.Drawing.Point(513, 36)
        Me.cmbImpuesto.Name = "cmbImpuesto"
        Me.cmbImpuesto.Size = New System.Drawing.Size(124, 21)
        Me.cmbImpuesto.TabIndex = 5
        '
        'TxtImporte
        '
        Me.TxtImporte.Location = New System.Drawing.Point(419, 37)
        Me.TxtImporte.Name = "TxtImporte"
        Me.TxtImporte.Size = New System.Drawing.Size(88, 20)
        Me.TxtImporte.TabIndex = 4
        Me.TxtImporte.Text = "0.00"
        Me.TxtImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtImporte.Value = 0
        Me.TxtImporte.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(79, 37)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(68, 20)
        Me.TxtCantidad.TabIndex = 2
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 0
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(153, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(432, 15)
        Me.Label7.TabIndex = 100
        Me.Label7.Text = "Descripción"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 15)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Unidad"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtDescripcion.Location = New System.Drawing.Point(152, 36)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(262, 21)
        Me.TxtDescripcion.TabIndex = 3
        '
        'BtnRemover
        '
        Me.BtnRemover.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRemover.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRemover.Icon = CType(resources.GetObject("BtnRemover.Icon"), System.Drawing.Icon)
        Me.BtnRemover.Location = New System.Drawing.Point(695, 67)
        Me.BtnRemover.Name = "BtnRemover"
        Me.BtnRemover.Size = New System.Drawing.Size(75, 22)
        Me.BtnRemover.TabIndex = 7
        Me.BtnRemover.Text = "Remover"
        Me.BtnRemover.ToolTipText = "Remueve el concepto seleccionado"
        Me.BtnRemover.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtUnidad
        '
        Me.TxtUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtUnidad.Location = New System.Drawing.Point(8, 36)
        Me.TxtUnidad.Name = "TxtUnidad"
        Me.TxtUnidad.Size = New System.Drawing.Size(68, 21)
        Me.TxtUnidad.TabIndex = 1
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
        Me.GridDetalle.Location = New System.Drawing.Point(8, 96)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(766, 149)
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
        Me.TxtBusqueda.Location = New System.Drawing.Point(66, 17)
        Me.TxtBusqueda.Name = "TxtBusqueda"
        Me.TxtBusqueda.Size = New System.Drawing.Size(113, 21)
        Me.TxtBusqueda.TabIndex = 96
        '
        'BtnAbrir
        '
        Me.BtnAbrir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAbrir.Icon = CType(resources.GetObject("BtnAbrir.Icon"), System.Drawing.Icon)
        Me.BtnAbrir.Location = New System.Drawing.Point(347, 12)
        Me.BtnAbrir.Name = "BtnAbrir"
        Me.BtnAbrir.Size = New System.Drawing.Size(53, 24)
        Me.BtnAbrir.TabIndex = 95
        Me.BtnAbrir.Text = "&Abrir"
        Me.BtnAbrir.ToolTipText = "Modificar datos del Cliente"
        Me.BtnAbrir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(405, 12)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(58, 24)
        Me.BtnAgregar.TabIndex = 94
        Me.BtnAgregar.Text = "&Nuevo"
        Me.BtnAgregar.ToolTipText = "Agregar nuevo Cliente"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRFC
        '
        Me.TxtRFC.Enabled = False
        Me.TxtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRFC.Location = New System.Drawing.Point(66, 44)
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
        Me.LstDomicilio.Location = New System.Drawing.Point(7, 108)
        Me.LstDomicilio.Name = "LstDomicilio"
        Me.LstDomicilio.Size = New System.Drawing.Size(458, 49)
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
        Me.Label11.Size = New System.Drawing.Size(60, 34)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Razón Social"
        '
        'BtnBuscaCte
        '
        Me.BtnBuscaCte.Image = CType(resources.GetObject("BtnBuscaCte.Image"), System.Drawing.Image)
        Me.BtnBuscaCte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaCte.Location = New System.Drawing.Point(184, 15)
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
        Me.TxtRazonSocial.Location = New System.Drawing.Point(66, 68)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(398, 37)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Buscar"
        '
        'TxtClave
        '
        Me.TxtClave.Enabled = False
        Me.TxtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave.Location = New System.Drawing.Point(218, 44)
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
        Me.TxtSubtotal.Location = New System.Drawing.Point(660, 451)
        Me.TxtSubtotal.Name = "TxtSubtotal"
        Me.TxtSubtotal.ReadOnly = True
        Me.TxtSubtotal.Size = New System.Drawing.Size(125, 26)
        Me.TxtSubtotal.TabIndex = 4
        Me.TxtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtIVA
        '
        Me.TxtIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIVA.Enabled = False
        Me.TxtIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIVA.Location = New System.Drawing.Point(660, 479)
        Me.TxtIVA.Name = "TxtIVA"
        Me.TxtIVA.ReadOnly = True
        Me.TxtIVA.Size = New System.Drawing.Size(125, 26)
        Me.TxtIVA.TabIndex = 16
        Me.TxtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotal
        '
        Me.TxtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(660, 508)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(125, 26)
        Me.TxtTotal.TabIndex = 17
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Location = New System.Drawing.Point(619, 517)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(39, 15)
        Me.LblTotal.TabIndex = 90
        Me.LblTotal.Text = "Total"
        '
        'LblIVA
        '
        Me.LblIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblIVA.Location = New System.Drawing.Point(598, 490)
        Me.LblIVA.Name = "LblIVA"
        Me.LblIVA.Size = New System.Drawing.Size(60, 15)
        Me.LblIVA.TabIndex = 91
        Me.LblIVA.Text = "Impuestos"
        '
        'LblSubtotal
        '
        Me.LblSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSubtotal.Location = New System.Drawing.Point(606, 462)
        Me.LblSubtotal.Name = "LblSubtotal"
        Me.LblSubtotal.Size = New System.Drawing.Size(47, 14)
        Me.LblSubtotal.TabIndex = 92
        Me.LblSubtotal.Text = "Subtotal"
        '
        'FrmNotaCargo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.LblSubtotal)
        Me.Controls.Add(Me.LblIVA)
        Me.Controls.Add(Me.GrpCliente)
        Me.Controls.Add(Me.TxtIVA)
        Me.Controls.Add(Me.TxtSubtotal)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.LblTotal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmNotaCargo"
        Me.Text = "Nota de Cargo"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public bLiquidacion As Boolean = False
    Public CAJClave As String
    'Public Cajon As Boolean = False
    'Public ImpresoraCajon As String = ""
    'Public Cajero As String
    ' Public CajaActiva As Boolean = False

    Public SUCClave As String

    Private Moneda As String
    Private MonedaRef As String
    Private MonedaDesc As String
    Private TipoCambio As Double

    Private CARClave As String
 
    Private oCFD As CFD

    Private Subtotal, ImpuestoTot, Total As Double
    Private Saldo As Double
    Private MaxRow As Integer
    Private Folio As String

    '   Private Prefijo As String

    Private Impresora As String

    Private dtPAC, dtDetalle, dtConcepto, dtImpuesto, dtImpuestoDet As DataTable
    '    Private Grabado As Boolean = False

    Private PathXML As String

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
    Private alerta(4) As PictureBox
    Private reloj As parpadea


    Private Tasa As Double
    Private dImpuesto As Double
    Private bLoad As Boolean = False


    Public Sub CargaDatosCliente(ByVal CTEClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", CTEClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            CTEClave = dt.Rows(0)("CTEClave")
            oCFD.CURP = dt.Rows(0)("CURP")
            oCFD.Clave = dt.Rows(0)("Clave")
            oCFD.TImpuesto = dt.Rows(0)("TImpuesto")
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
                    .fromForm = "NotaCargo"

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

    Private Sub FrmNotaCargo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoNotaCargo Is Nothing Then
            If Not ModPOS.MtoNotaCargo.CmbSucursal.SelectedValue Is Nothing AndAlso ModPOS.MtoNotaCargo.Periodo > 0 AndAlso ModPOS.MtoNotaCargo.Mes > 0 Then
                ModPOS.MtoNotaCargo.refrescaGrid()
            End If
        End If

        If bLiquidacion = True AndAlso Not ModPOS.Liquid Is Nothing Then
            ModPOS.Liquid.ActualizaGridTransac()
        End If

        If bLiquidacion = True AndAlso Not ModPOS.MtoVenta Is Nothing Then
            ModPOS.MtoVenta.ActualizaGridTransac()
        End If

        ModPOS.NotaCargo.Dispose()
        ModPOS.NotaCargo = Nothing
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

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Cliente Is Nothing Then
            ModPOS.Cliente = New FrmCliente
            ModPOS.Cliente.fromForm = "NotaCargo"
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

    Private Sub FrmNotaCargo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5

        oCFD = New CFD

        oCFD.tipoDeComprobante = "ingreso"

        CARClave = ModPOS.obtenerLlave

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


        With Me.cmbImpuesto
            .Conexion = BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_impuesto"
            .llenar()
        End With

        bLoad = True

        LstDomicilio.Items.Clear()

        dtDetalle = ModPOS.CrearTabla("NotaCargoDet", _
                                                 "DCRClave", "System.String", _
                                                 "Unidad", "System.String", _
                                                 "Cantidad", "System.Double", _
                                                 "Descripción", "System.String", _
                                                 "Importe", "System.Double", _
                                                 "IMPClave", "System.String", _
                                                 "Tasa", "System.Double", _
                                                 "Impuesto", "System.Double", _
                                                 "Subtotal", "System.Double", _
                                                 "ImpuestoTotal", "System.Double", _
                                                 "ImporteTotal", "System.Double", _
                                                 "Total", "System.Double")

        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("DCRClave").Visible = False
        GridDetalle.RootTable.Columns("IMPClave").Visible = False
        GridDetalle.RootTable.Columns("Impuesto").Visible = False
        GridDetalle.RootTable.Columns("Subtotal").Visible = False
        GridDetalle.RootTable.Columns("ImporteTotal").Visible = False
        GridDetalle.RootTable.Columns("ImpuestoTotal").Visible = False


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
            MessageBox.Show("La siguiente información del cliente No es valida ó es requerida para facturar: " & Cadena & " para completarla, edite la información del cliente seleccionado presionando el botón de Abrir junto al Filtro de busqueda y selección de cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        If TxtUnidad.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtCantidad.Text = "" OrElse CDbl(TxtCantidad.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtDescripcion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtImporte.Text = "" OrElse CDbl(TxtImporte.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbImpuesto.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
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

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If validaForm() Then

            Dim foundRows() As System.Data.DataRow
            foundRows = dtDetalle.Select("Descripción Like '" & TxtDescripcion.Text.ToUpper.Trim & "'")
            If foundRows.Length = 0 Then
                Dim row1 As DataRow
                row1 = dtDetalle.NewRow()
                'declara el nombre de la fila
                row1.Item("DCRClave") = ModPOS.obtenerLlave
                row1.Item("Unidad") = TxtUnidad.Text.ToUpper.Trim
                row1.Item("Cantidad") = TxtCantidad.Text
                row1.Item("Descripción") = TxtDescripcion.Text.ToUpper.Trim
                row1.Item("Importe") = TxtImporte.Text
                row1.Item("IMPClave") = cmbImpuesto.SelectedValue
                row1.Item("Tasa") = Tasa
                row1.Item("Impuesto") = dImpuesto
                row1.Item("ImporteTotal") = CDbl(TxtImporte.Text) * CDbl(TxtCantidad.Text)
                row1.Item("ImpuestoTotal") = (CDbl(TxtImporte.Text) * CDbl(TxtCantidad.Text)) * Tasa
                row1.Item("Subtotal") = CDbl(TxtImporte.Text) + dImpuesto
                row1.Item("Total") = (CDbl(TxtImporte.Text) + dImpuesto) * CDbl(TxtCantidad.Text)
                dtDetalle.Rows.Add(row1)
                'agrega la fila completo a la tabla
             
                TxtUnidad.Text = ""
                TxtDescripcion.Text = ""
                TxtImporte.Text = ""
                TxtCantidad.Text = ""

                Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)
                ImpuestoTot = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("ImpuestoTotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                Subtotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("ImporteTotal"), Janus.Windows.GridEX.AggregateFunction.Sum)

                TxtSubtotal.Text = Format(CStr(ModPOS.Redondear(Subtotal, 2)), "Currency")
                TxtIVA.Text = Format(CStr(ModPOS.Redondear(ImpuestoTot, 2)), "Currency")
                TxtTotal.Text = Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")

            Else
                MessageBox.Show("¡El concepto que intenta agregar ya existe ne la nota de cargo actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub recuperaImpuesto(ByVal IMPClave As String)
        Dim dt As DataTable
        Dim dCant As Double
        dt = ModPOS.Recupera_Tabla("sp_recupera_impuesto", "@Impuesto", IMPClave)
        Tasa = dt.Rows(0)("Valor")
        dImpuesto = CDbl(TxtImporte.Text) * Tasa

        If CDbl(TxtCantidad.Text) <= 0 Then
            dCant = 1
        Else
            dCant = CDbl(TxtCantidad.Text)
        End If

        txtPartida.Text = dCant * (CDbl(TxtImporte.Text) * (1 + Tasa))
        dt.Dispose()
    End Sub

    Private Sub TxtImporte_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtImporte.Leave
        If CDbl(TxtImporte.Text) > 0 Then
            If Not cmbImpuesto.SelectedValue Is Nothing Then
                recuperaImpuesto(cmbImpuesto.SelectedValue)
            End If
        End If
    End Sub

    Private Sub cmbImpuesto_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbImpuesto.SelectedValueChanged
        If Not cmbImpuesto.SelectedValue Is Nothing Then
            If CDbl(TxtImporte.Text) > 0 Then
                recuperaImpuesto(cmbImpuesto.SelectedValue)
            End If
        End If
    End Sub

    Private Sub BtnRemover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemover.Click
        If GridDetalle.Row >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se removera el concepto: " & GridDetalle.GetValue("Descripción"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtDetalle.Select("DCRClave Like '" & GridDetalle.GetValue("DCRClave") & "'")
                    dtDetalle.Rows.Remove(foundRows(0))

                    Dim Impuesto, Subtotal As Double

                    Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    Impuesto = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("ImpuestoTotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    Subtotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("ImporteTotal"), Janus.Windows.GridEX.AggregateFunction.Sum)

                    TxtSubtotal.Text = Format(CStr(ModPOS.Redondear(Subtotal, 2)), "Currency")
                    TxtIVA.Text = Format(CStr(ModPOS.Redondear(Impuesto, 2)), "Currency")
                    TxtTotal.Text = Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")

            End Select
        End If
    End Sub

    Private Function recuperaFolio(ByVal Caja As String, ByVal NumFolios As Integer) As Boolean
        Dim dt As DataTable
        Dim FOLClave As String
        dt = ModPOS.Recupera_Tabla("sp_recupera_folioactual", "@TipoComprobante", 6, "@SUCClave", SUCClave, "@CAJClave", CAJClave)

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

    Public Function crearCF(ByVal CARClave As String) As Boolean
        
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
        dt = ModPOS.Recupera_Tabla("sp_recupera_notacargo", "@CARClave", CARClave)

        dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_conceptocargo", "@CARClave", CARClave)

        dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_impuestocargo", "@CARClave", CARClave)

        oCFD.Serie = dt.Rows(0)("Serie")
        oCFD.Folio = dt.Rows(0)("Folio")
        oCFD.descuento = 0
        oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dt.Rows(0)("fecha"))
        'oCFD.extra = TxtExtra.Text
        oCFD.Moneda = MonedaRef
        oCFD.TipoCambio = TipoCambio

        If oCFD.TipoCF = 1 OrElse oCFD.TipoCF = 2 Then
            oCFD.DOCClave = dt.Rows(0)("CARClave")

            oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, 6)
        
            oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave)

            iTipoPAC = crearXML(1, dtPAC, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, 6)

        Else
            actualizaEdoCFD(oCFD.tipoDeComprobante, oCFD.DOCClave, 1, 6)
        End If

        dt.Dispose()
        dtConcepto.Dispose()
        dtImpuesto.Dispose()

        Return True
    End Function

    Private Sub imprimirNotaCargo(ByVal iTipoCF As Integer)
        Dim sImpresora As String
        Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", Impresora)
        sImpresora = dtPrinter.Rows(0)("Referencia")
        dtPrinter.Dispose()

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"

        'OpenReport.PrintPreview("Factura", "CRFactura.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.Redondear(TotalFactura, 2)).ToUpper)
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", CARClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_cargo", "@CARClave", CARClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", CARClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", CARClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_cargo", "@CARClave", CARClave))

        OpenReport.Print("CRNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)

    End Sub

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



        PathPDF = pathActual & "Temp\" & Folio & ".PDF"

        'Genera PDF

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"

        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", CARClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_cargo", "@CARClave", CARClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", CARClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", CARClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_cargo", "@CARClave", CARClave))

        OpenReport.PrintPDF("CRNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)

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

            correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Nota de Cargo (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agraciadecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
            correo.Subject = "Nota de Cargo " & Folio
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

           
            If iTipoCF <= 2 Then
                If PathXML.Length <= 3 Then
                    sPathXML = PathXML & Folio & ".xml"
                Else
                    sPathXML = PathXML & "\" & Folio & ".xml"
                End If

                dato = New FileStream(sPathXML, FileMode.Open, FileAccess.Read)
                adjuntos = New Attachment(dato, Folio & ".XML")
                correo.Attachments.Add(adjuntos)

            End If

            dato = New FileStream(PathPDF, FileMode.Open, FileAccess.Read)
            adjuntos = New Attachment(dato, Folio & ".PDF")
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

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        'Inicia Sección de Validaciones 
        If Not CmbCaja.SelectedValue Is Nothing Then
            CAJClave = CmbCaja.SelectedValue

            Dim dt As DataTable

            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            Impresora = dt.Rows(0)("ImpresoraFac")
            dt.Dispose()

        Else
            MessageBox.Show("Debe seleccionar una Caja valida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        If Not CmbFormaPago.SelectedValue Is Nothing Then
            oCFD.formaDePago = Me.CmbFormaPago.Text.Trim
        Else
            MessageBox.Show("Debe seleccionar una opcion valida de Forma de Pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Seccion para agregar multiples metodos de pago
        If ModPOS.MetodoPago Is Nothing Then
            ModPOS.MetodoPago = New FrmMetodoPago
            With ModPOS.MetodoPago
                .CTEClave = oCFD.CTEClave
                .FacturaId = ""
                .NCClave = CARClave
            End With
        End If

        Dim frMetodoPagos() As System.Data.DataRow

        ModPOS.MetodoPago.StartPosition = FormStartPosition.CenterScreen
        If ModPOS.MetodoPago.ShowDialog = Windows.Forms.DialogResult.OK Then
            frMetodoPagos = ModPOS.MetodoPago.MetodoPagoRows
            If frMetodoPagos.Length = 0 Then
                MessageBox.Show("Ha ocurrido un error al recuperar los metodos de pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Else
            MessageBox.Show("Debe seleccionar una opcion valida de Metodo de Pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ModPOS.MetodoPago.Dispose()
        ModPOS.MetodoPago = Nothing

        ' Termina Sección de Validaciones
      
        If Not recuperaFolio(CAJClave, 1) Then
            Exit Sub
        End If

        Nota = TxtNota.Text

        ModPOS.Ejecuta("sp_inserta_notacargo", _
                        "@CARClave", CARClave, _
                        "@TipoCF", oCFD.TipoCF, _
                        "@VersionCF", oCFD.VersionCF, _
                        "@RegimenFiscal", oCFD.regimenFiscal, _
                        "@Serie", oCFD.Serie, _
                        "@Folio", oCFD.Folio, _
                        "@CAJClave", CmbCaja.SelectedValue, _
                        "@CTEClave", oCFD.CTEClave, _
                        "@formaDePago", oCFD.formaDePago, _
                        "@noCertificado", oCFD.noCertificado, _
                        "@subTotal", Subtotal, _
                        "@impuestoTot", ImpuestoTot, _
                        "@total", Total, _
                        "@saldo", Total, _
                        "@tipo", oCFD.tipoDeComprobante, _
                        "@MONClave", Moneda, _
                        "@TipoCambio", TipoCambio, _
                        "@Nota", Nota, _
                        "@Usuario", ModPOS.UsuarioActual)

        Dim fila As Integer

        For fila = 0 To dtDetalle.Rows.Count - 1
            ModPOS.Ejecuta("sp_inserta_detallecargo", _
            "@DCRClave", dtDetalle.Rows(fila)("DCRClave"), _
            "@CARClave", CARClave, _
            "@Unidad", dtDetalle.Rows(fila)("Unidad"), _
            "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
            "@Descripcion", dtDetalle.Rows(fila)("Descripción"), _
            "@PrecioBruto", dtDetalle.Rows(fila)("Importe"), _
            "@IMPClave", dtDetalle.Rows(fila)("IMPClave"), _
            "@PorcImp", dtDetalle.Rows(fila)("Tasa"), _
            "@ImpuestoImp", dtDetalle.Rows(fila)("Impuesto"), _
            "@SubtotalPartida", dtDetalle.Rows(fila)("Subtotal"), _
            "@TotalPartida", dtDetalle.Rows(fila)("Total"))

        Next
        dtDetalle.Dispose()

        ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", oCFD.CTEClave, "@Importe", Total)

        Dim j As Integer

        Dim sMetodoPago, sBanco, sReferencia As String

        For j = 0 To frMetodoPagos.GetUpperBound(0)

            sMetodoPago = IIf(frMetodoPagos(j)("Tipo").GetType.Name = "DBNull", "", frMetodoPagos(j)("Tipo"))
            sBanco = IIf(frMetodoPagos(j)("Banco").GetType.Name = "DBNull", "", frMetodoPagos(j)("Banco"))
            sReferencia = IIf(frMetodoPagos(j)("Referencia").GetType.Name = "DBNull", "", CStr(frMetodoPagos(j)("Referencia")).Trim.ToUpper)



            ModPOS.Ejecuta("sp_agregar_metodopagocargo", _
            "@CARClave", CARClave, _
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

        Folio = oCFD.Serie & CStr(oCFD.Folio)

        MessageBox.Show("Se genero la nota de cargo " & Folio, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)


        crearCF(CARClave)

        'Inicia
        If oCFD.TipoCF = 2 AndAlso iTipoPAC = 0 Then
            MessageBox.Show("No ha sido posible certificar este documento, le recomendamos intentar certificarlo más tarde", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            Exit Sub
        End If


        Select Case MessageBox.Show("¿Desea imprimir la nota de cargo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case DialogResult.Yes
                imprimirNotaCargo(oCFD.TipoCF)
        End Select

        If oCFD.email <> "" Then
            Select Case MessageBox.Show("¿Desea enviar el documento por correo electrónico?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    SendMail(oCFD.TipoCF)
            End Select
        End If

        Me.Close()
    End Sub

End Class
